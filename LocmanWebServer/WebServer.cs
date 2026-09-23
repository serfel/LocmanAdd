using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web.Script.Serialization;

namespace LocmanWebServer
{
    // Маршрутизация HTTP-запросов: веб-интерфейс + JSON API + выгрузка отчётов.
    public static class WebServer
    {
        static readonly Settings Cfg = Settings.Load();
        static readonly Db Database = new Db(Cfg);
        static readonly JavaScriptSerializer Json = new JavaScriptSerializer();

        public static void Handle(HttpListenerContext c)
        {
            var req = c.Request;
            var res = c.Response;
            string path = req.Url.AbsolutePath.TrimEnd('/');
            if (path == "") path = "/";

            try
            {
                switch (path)
                {
                    case "/": SendHtml(res, Index.Html); break;
                    case "/app.js": SendText(res, Scripts.AppJs, "application/javascript"); break;
                    case "/api/cities": SendJson(res, GetCities()); break;
                    case "/api/streets": SendJson(res, GetStreets(Query(req, "city"))); break;
                    case "/api/houses": SendJson(res, GetHouses(Query(req, "city"), Query(req, "street"))); break;
                    case "/api/flats": SendJson(res, GetFlats(Query(req, "city"), Query(req, "street"), Query(req, "house"))); break;
                    case "/api/residents": SendJson(res, GetResidents(Query(req, "city"), Query(req, "street"), Query(req, "house"), Query(req, "flats"))); break;
                    case "/report": Report(req, res); break;
                    default:
                        res.StatusCode = 404;
                        byte[] b = Encoding.UTF8.GetBytes("404. Не найдено.");
                        res.ContentType = "text/plain; charset=utf-8";
                        res.OutputStream.Write(b, 0, b.Length);
                        break;
                }
            }
            catch (Exception ex)
            {
                try
                {
                    res.StatusCode = 500;
                    SendJson(res, new { error = ex.Message });
                }
                catch { }
            }
            finally { res.Close(); }
        }

        static string Query(HttpListenerRequest req, string key)
        {
            return req.QueryString[key] ?? "";
        }

        static void SendHtml(HttpListenerResponse res, string html) { SendText(res, html, "text/html"); }

        static void SendText(HttpListenerResponse res, string text, string mime)
        {
            byte[] b = Encoding.UTF8.GetBytes(text);
            res.ContentType = mime + "; charset=utf-8";
            res.ContentLength64 = b.Length;
            res.OutputStream.Write(b, 0, b.Length);
        }

        static void SendJson(HttpListenerResponse res, object o)
        {
            SendText(res, Json.Serialize(o), "application/json");
        }

        // ---------- API ----------

        static object GetCities()
        {
            return Database.GetCities().Select(x => new { value = x.Key, name = x.Value }).ToList();
        }

        static object GetStreets(string city)
        {
            if (string.IsNullOrEmpty(city)) return new List<string>();
            return Database.GetStreets(city);
        }

        static object GetHouses(string city, string street)
        {
            if (string.IsNullOrEmpty(city) || string.IsNullOrEmpty(street)) return new List<string>();
            return Database.GetHouses(city, street);
        }

        static object GetFlats(string city, string street, string house)
        {
            if (string.IsNullOrEmpty(city) || string.IsNullOrEmpty(street) || string.IsNullOrEmpty(house))
                return new List<object>();
            return Database.GetFlats(city, street, house)
                           .Select(x => new { num = x.Key, id = x.Value }).ToList();
        }

        static List<KeyValuePair<int, int>> ParseFlats(string city, string street, string house, string flatsCsv)
        {
            var all = Database.GetFlats(city, street, house);
            if (string.IsNullOrEmpty(flatsCsv)) return all;
            var nums = new HashSet<string>(flatsCsv.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                                                  .Select(x => x.Trim()));
            return all.Where(x => nums.Contains(x.Key.ToString())).ToList();
        }

        static object GetResidents(string city, string street, string house, string flatsCsv)
        {
            if (string.IsNullOrEmpty(city) || string.IsNullOrEmpty(street) || string.IsNullOrEmpty(house))
                return new List<object>();
            var flats = ParseFlats(city, street, house, flatsCsv);
            return Database.GetResidents(city, flats).Select(r => new
            {
                flat = r.Flat,
                fio = r.FIO,
                contract = r.ContractType,
                date = r.RegDate
            }).ToList();
        }

        // ---------- Отчёты ----------
        // GET /report?format=xls|csv|txt&kind=flats|residents&city=..&street=..&house=..&flats=1,2,3

        static void Report(HttpListenerRequest req, HttpListenerResponse res)
        {
            string format = Query(req, "format").ToLowerInvariant();
            string kind = Query(req, "kind").ToLowerInvariant();
            string city = Query(req, "city"), street = Query(req, "street"),
                   house = Query(req, "house"), flatsCsv = Query(req, "flats");

            var rows = new List<string[]>();
            string fname;

            if (kind == "residents")
            {
                rows.Add(new[] { "Квартира", "Ф.И.О.", "Тип договора", "Дата записи" });
                var flats = ParseFlats(city, street, house, flatsCsv);
                foreach (var r in Database.GetResidents(city, flats))
                    rows.Add(new[] { r.Flat.ToString(), r.FIO, r.ContractType, r.RegDate });
                fname = "Жители_" + street + "_" + house;
            }
            else
            {
                rows.Add(new[] { "Номер квартиры", "ID объекта" });
                foreach (var f in ParseFlats(city, street, house, flatsCsv))
                    rows.Add(new[] { f.Key.ToString(), f.Value.ToString() });
                fname = "Квартиры_" + street + "_" + house;
            }

            byte[] data;
            string mime, ext;
            switch (format)
            {
                case "csv":
                    data = Reports.ToCsv(rows); mime = "text/csv"; ext = "csv"; break;
                case "txt":
                    data = Reports.ToTxt(rows); mime = "text/plain"; ext = "txt"; break;
                default:
                    data = Reports.ToExcelXml(rows, kind == "residents" ? "Жители" : "Квартиры");
                    mime = "application/vnd.ms-excel"; ext = "xls"; break;
            }

            res.ContentType = mime + "; charset=utf-8";
            res.AddHeader("Content-Disposition", "attachment; filename*=UTF-8''" +
                       Uri.EscapeDataString(fname + "." + ext));
            res.ContentLength64 = data.Length;
            res.OutputStream.Write(data, 0, data.Length);
        }
    }
}
