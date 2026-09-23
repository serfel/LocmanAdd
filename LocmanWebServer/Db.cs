using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace LocmanWebServer
{
    // Слой доступа к базе MSSQL (Лоцман). Запросы соответствуют оригинальному
    // проекту «Лоцман добавка» (ПоискАдреса.cs): vwObjects / vwLinks / stAttributes.
    public class Db
    {
        readonly Settings cfg;

        public Db(Settings settings) { cfg = settings; }

        static string Esc(string s)
        {
            return (s ?? "").Replace("'", "''");
        }

        static List<KeyValuePair<string, string>> AllCatalogs()
        {
            var list = new List<KeyValuePair<string, string>>();
            foreach (var pair in cfg.CitiesRaw.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries))
            {
                var kv = pair.Split(new[] { '=' }, 2);
                string catalog = kv[0].Trim();
                string name = kv.Length > 1 ? kv[1].Trim() : catalog;
                if (catalog.Length > 0) list.Add(new KeyValuePair<string, string>(catalog, name));
            }
            return list;
        }

        // Улицы сразу по всем городам (поле «Город» из интерфейса удалено):
        // Select _PRODUCT From vwObjects Where _TYPE Like 'Струк%'
        public List<string> GetStreets()
        {
            var result = new List<string>();
            foreach (var catalog in AllCatalogs())
            {
                try
                {
                    using (var con = new SqlConnection(cfg.ConnectionString(catalog.Key)))
                    using (var sc = new SqlCommand(
                        "Select vwObjects._PRODUCT From vwObjects Where vwObjects._TYPE Like 'Струк%'", con))
                    {
                        con.Open();
                        using (var dr = sc.ExecuteReader())
                            while (dr.Read()) result.Add(dr.GetString(0));
                    }
                }
                catch (SqlException)
                {
                    // Город временно недоступен — пропускаем его улицы.
                }
            }
            return result.Distinct().OrderBy(x => x).ToList();
        }

        // Номера домов по улице сразу по всем городам: атрибут «Дом номер» у
        // дочерних объектов улицы.
        public List<string> GetHouses(string street)
        {
            var items = new SortedList<int, string>();
            var others = new List<string>();
            foreach (var catalog in AllCatalogs())
            {
                try
                {
                    CollectHouses(catalog.Key, street, items, others);
                }
                catch (SqlException)
                {
                    // город временно недоступен
                }
            }
            var res = items.Values.ToList();
            res.AddRange(others.Distinct().OrderBy(x => x));
            return res;
        }

        void CollectHouses(string catalog, string street, SortedList<int, string> items, List<string> others)
        {
            using (var con = new SqlConnection(cfg.ConnectionString(catalog)))
            using (var sc = new SqlCommand(
                @"Select stAttributes.stValue
                  From vwObjects
                  Inner Join vwLinks On vwObjects._ID = vwLinks.inIdParent
                  Inner Join vwObjects vwObjects1 On vwLinks.inIdChild = vwObjects1._ID
                  Inner Join stVersions On vwObjects1._ID = stVersions.inId
                  Inner Join stAttributes On stVersions.inId = stAttributes.inIdVersion
                  Inner Join vwTypesAndAttributes On stAttributes.inIdTypeAttr = vwTypesAndAttributes.inId
                  Where vwObjects._TYPE Like 'Струк%' And vwTypesAndAttributes.stAttrName = 'Дом номер'
                    And vwObjects._PRODUCT = '" + Esc(street) + "'", con))
            {
                con.Open();
                using (var dr = sc.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        string v = dr.IsDBNull(0) ? "" : dr.GetValue(0).ToString().Trim();
                        if (v.Length == 0) continue;
                        int n;
                        if (int.TryParse(v, out n)) items[n] = v;
                        else if (!others.Contains(v)) others.Add(v);
                    }
                }
            }
        }

        // Квартиры дома: цепочка связей Структурная единица -> Описание внутренних помещений
        // -> Расчет площади основного строения; атрибут «Номер помещения...».
        // Возвращает пары: номер квартиры -> _ID объекта квартиры.
        public List<KeyValuePair<int, int>> GetFlats(string catalog, string street, string house)
        {
            var flats = new Dictionary<int, int>();
            using (var con = new SqlConnection(cfg.ConnectionString(catalog)))
            using (var sc = new SqlCommand(
                @"Select vwObjects5._ID, stAttributes1.stValue
                  From vwObjects
                  Inner Join vwLinks On vwObjects._ID = vwLinks.inIdParent
                  Inner Join vwObjects vwObjects1 On vwLinks.inIdChild = vwObjects1._ID
                  Inner Join stAttributes On vwObjects1._ID = stAttributes.inIdVersion
                  Inner Join vwTypesAndAttributes On stAttributes.inIdTypeAttr = vwTypesAndAttributes.inId
                  Inner Join vwLinks vwLinks1 On vwObjects1._ID = vwLinks1.inIdParent
                  Inner Join vwObjects vwObjects2 On vwLinks1.inIdChild = vwObjects2._ID
                  Inner Join vwLinks vwLinks2 On vwObjects2._ID = vwLinks2.inIdParent
                  Inner Join vwObjects vwObjects3 On vwLinks2.inIdChild = vwObjects3._ID
                  Inner Join vwLinks vwLinks3 On vwObjects3._ID = vwLinks3.inIdParent
                  Inner Join vwObjects vwObjects4 On vwLinks3.inIdChild = vwObjects4._ID
                  Inner Join vwLinks vwLinks4 On vwObjects4._ID = vwLinks4.inIdParent
                  Inner Join vwObjects vwObjects5 On vwLinks4.inIdChild = vwObjects5._ID
                  Inner Join stAttributes stAttributes1 On vwObjects5._ID = stAttributes1.inIdVersion
                  Inner Join vwTypesAndAttributes vwTypesAndAttributes1 On vwTypesAndAttributes1.inId = stAttributes1.inIdTypeAttr
                  Where vwObjects._TYPE Like 'Струк%'
                    And vwTypesAndAttributes.stAttrName = 'Дом номер'
                    And vwTypesAndAttributes1.stAttrName = 'Номер помещения (квартиры торгового складского и др. п.)'
                    And vwObjects._PRODUCT = '" + Esc(street) + @"'
                    And stAttributes.stValue = '" + Esc(house) + "' ", con))
            {
                con.Open();
                using (var dr = sc.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        int id = Convert.ToInt32(dr.GetValue(0));
                        int num;
                        if (int.TryParse(dr.GetValue(1).ToString().Trim(), out num) && num >= 0)
                            flats[num] = id;
                    }
                }
            }
            return flats.OrderBy(x => x.Key).ToList();
        }

        // Квартиры без выбора города: ищем по всем каталогам, где встречается
        // такая же улица+дом. Дубликаты номеров не повторяем.
        public List<KeyValuePair<int, int>> GetFlatsAllCatalogs(string street, string house)
        {
            var result = new List<KeyValuePair<int, int>>();
            var seen = new HashSet<int>();
            foreach (var catalog in AllCatalogs())
            {
                List<KeyValuePair<int, int>> flats;
                try
                {
                    flats = GetFlats(catalog.Key, street, house);
                }
                catch (SqlException)
                {
                    continue; // город временно недоступен
                }
                foreach (var f in flats)
                    if (seen.Add(f.Key)) result.Add(f);
            }
            return result.OrderBy(x => x.Key).ToList();
        }

        // Жители (собственники) квартир: дочерние объекты квартиры, у которых есть
        // атрибут «Ф.И.О.», а также тип договора и дата записи по договору.
        public List<Resident> GetResidents(string catalog, IEnumerable<KeyValuePair<int, int>> flats)
        {
            var result = new List<Resident>();
            using (var con = new SqlConnection(cfg.ConnectionString(catalog)))
            {
                con.Open();
                foreach (var flat in flats)
                {
                    using (var sc = new SqlCommand(
                        @"Select vwObjects._ID
                          From vwLinks
                          Inner Join vwObjects On vwLinks.inIdChild = vwObjects._ID
                          Where vwLinks.inIdParent = @id", con))
                    {
                        sc.Parameters.AddWithValue("@id", flat.Value);
                        var ids = new List<int>();
                        using (var dr = sc.ExecuteReader())
                            while (dr.Read()) ids.Add(Convert.ToInt32(dr.GetValue(0)));

                        foreach (int id in ids)
                        {
                            var r = new Resident { Flat = flat.Key };
                            using (var scn = new SqlCommand(
                                @"Select vwTypesAndAttributes1.stAttrName, stAttributes1.stValue
                                  From vwObjects
                                  Inner Join stAttributes stAttributes1 On stAttributes1.inIdVersion = vwObjects._ID
                                  Inner Join vwTypesAndAttributes vwTypesAndAttributes1 On vwTypesAndAttributes1.inId = stAttributes1.inIdTypeAttr
                                  Where vwObjects._ID = @id", con))
                            {
                                scn.Parameters.AddWithValue("@id", id);
                                using (var drn = scn.ExecuteReader())
                                {
                                    while (drn.Read())
                                    {
                                        string attr = drn.GetValue(0).ToString();
                                        string val = drn.GetValue(1).ToString();
                                        switch (attr)
                                        {
                                            case "Ф.И.О.": r.FIO = val; break;
                                            case "Тип договора": r.ContractType = val; break;
                                            case "Дата записи": r.RegDate = val; break;
                                        }
                                    }
                                }
                            }
                            if (!string.IsNullOrWhiteSpace(r.FIO)) result.Add(r);
                        }
                    }
                }
            }
            return result.OrderBy(x => x.Flat).ThenBy(x => x.FIO).ToList();
        }
    }

    public class Resident
    {
        public int Flat;
        public string FIO = "";
        public string ContractType = "";
        public string RegDate = "";
    }
}
