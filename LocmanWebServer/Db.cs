using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace LocmanWebServer
{
    // Слой доступа к базе MSSQL (Лоцман). Запросы соответствуют оригинальному
    // проекту «Лоцман добавка» (ПоискАдреса.cs): vwObjects / vwLinks / stAttributes.
    public class Db
    {
        readonly Settings cfg;
        string АдресБезДома = "";
        public string baseCatalog = "Murmansk";
        public Db(Settings settings) { cfg = settings; }

        // Разбирает строку настроек «каталог=Название;...» в список каталогов.
        public static List<KeyValuePair<string, string>> ParseCatalogs(string citiesRaw)
        {
            var list = new List<KeyValuePair<string, string>>();
            foreach (var pair in (citiesRaw ?? "").Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries))
            {
                var kv = pair.Split(new[] { '=' }, 2);
                string catalog = kv[0].Trim();
                string name = kv.Length > 1 ? kv[1].Trim() : catalog;
                if (catalog.Length > 0) list.Add(new KeyValuePair<string, string>(catalog, name));
            }
            return list;
        }

        List<KeyValuePair<string, string>> AllCatalogs()
        {
            return ParseCatalogs(cfg.CitiesRaw);
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

        void _CollectHouses(string catalog, string street, SortedList<int, string> items, List<string> others)
        {
            // ВАЖНО (исправление фильтра): в Лоцмане «улица» — родитель дома,
            // т.е. дом является ПОТОМКОМ улицы: улица._ID = vwLinks.inIdChild,
            // дом._ID = vwLinks.inIdParent (стрелка связи «из родителя в потомка»:
            // inIdParent -> inIdChild). Ранее было переставлено наоборот
            // (улица как parent), поэтому список домов всегда возвращал пустым.
            // Номер дома хранится в атрибуте самого объекта-дома (stVersions по
            // дому, а не по улице).
            using (var con = new SqlConnection(cfg.ConnectionString(catalog)))
            using (var sc = new SqlCommand(
                /*
                @"Select stAttributes.stValue
                  From vwObjects
                  Inner Join vwLinks On vwObjects._ID = vwLinks.inIdChild
                  Inner Join vwObjects vwObjects1 On vwLinks.inIdParent = vwObjects1._ID
                  Inner Join stVersions On vwObjects1._ID = stVersions.inId
                  Inner Join stAttributes On stVersions.inId = stAttributes.inIdVersion
                  Inner Join vwTypesAndAttributes On stAttributes.inIdTypeAttr = vwTypesAndAttributes.inId
                  Where vwObjects._TYPE Like 'Струк%' And vwTypesAndAttributes.stAttrName = 'Дом номер'
                    And vwObjects._PRODUCT = @street"
                */
                $@"Select vwObjects._PRODUCT As vwObjects__PRODUCT, vwObjects1._TYPE As vwObjects1__TYPE, stAttributes.stValue As stAttributes_stValue From vwObjects Inner Join vwLinks On vwObjects._ID = vwLinks.inIdParent Inner Join vwObjects vwObjects1 On vwLinks.inIdChild = vwObjects1._ID Inner Join stVersions On vwObjects1._ID = stVersions.inId Inner Join stAttributes On stVersions.inId = stAttributes.inIdVersion Inner Join vwTypesAndAttributes On stAttributes.inIdTypeAttr =  vwTypesAndAttributes.inId Where vwObjects._TYPE Like 'Струк%' And vwTypesAndAttributes.stAttrName = 'Дом номер' And vwObjects._PRODUCT = '{street}'"
                , con))
            {
                //sc.Parameters.AddWithValue("@street", street ?? "");
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

        private void __CollectHouses(string Catalog, string Улица, SortedList<int, string> items, List<string> others)
        {
            //АдресБезДома = "";
            using (var con = new SqlConnection(cfg.ConnectionString(Catalog)))
            {
                con.Open();
                using (SqlCommand sc = new SqlCommand($@"Select vwObjects._PRODUCT As vwObjects__PRODUCT, vwObjects1._TYPE As vwObjects1__TYPE, stAttributes.stValue As stAttributes_stValue From vwObjects Inner Join vwLinks On vwObjects._ID = vwLinks.inIdParent Inner Join vwObjects vwObjects1 On vwLinks.inIdChild = vwObjects1._ID Inner Join stVersions On vwObjects1._ID = stVersions.inId Inner Join stAttributes On stVersions.inId = stAttributes.inIdVersion Inner Join vwTypesAndAttributes On stAttributes.inIdTypeAttr =  vwTypesAndAttributes.inId Where vwObjects._TYPE Like 'Струк%' And vwTypesAndAttributes.stAttrName = 'Дом номер' And vwObjects._PRODUCT = '{Улица}'"))
                {
                    var stVers = new DataTable("Table");
                    sc.Connection = con;
                    using (SqlDataReader dr = sc.ExecuteReader())
                    {
                        stVers.Load(dr);

                        ArrayList _items = new ArrayList();
                        for (int x = 0; x < stVers.Rows.Count; x++)
                        {
                            string key = "";
                            int ky = 0;
                            int.TryParse(stVers.Rows[x]["stAttributes_stValue"].ToString(), out ky);
                            if (ky < 0) stVers.Rows[x]["Свойства_Значение"].ToString();
                            else
                            {
                                if (ky < 10) key = "  " + ky.ToString();
                                else if (ky < 100) key = " " + ky.ToString();
                                else key = ky.ToString();
                            }
                            if (!_items.Contains(key))
                            {
                                _items.Add(key);
                            }
                            else
                            {

                            }
                            if (!_items.Contains(stVers.Rows[x]["stAttributes_stValue"].ToString()))
                            {
                                _items.Add(stVers.Rows[x]["stAttributes_stValue"].ToString());
                                baseCatalog = Catalog;
                            }
                            else
                            {

                            }
                        }
                        _items.Sort();
                        for (int x = 0; x < _items.Count; x++)
                        {
                            while (_items[x].ToString()[0] == ' ')
                                _items[x] = _items[x].ToString().Remove(0, 1);
                        }
                        //items.AddRange(items.ToArray());
                    }
                }
                using (SqlCommand sc = new SqlCommand($@"Select vwTypesAndAttributes.stAttrName As vwTypesAndAttributes_stAttrName, stAttributes.stValue As stAttributes_stValue From vwObjects Inner Join stAttributes On vwObjects._ID = stAttributes.inIdVersion Inner Join vwTypesAndAttributes On stAttributes.inIdTypeAttr = vwTypesAndAttributes.inId Where vwObjects._PRODUCT = '{Улица}' And vwObjects._TYPE Like 'Струк%' And (vwTypesAndAttributes.stAttrName = 'Тип' Or vwTypesAndAttributes.stAttrName = 'Наименование')"))
                {
                    var stVers = new DataTable("Table");
                    sc.Connection = con;
                    using (SqlDataReader dr = sc.ExecuteReader())
                    {
                        string Тип = "";
                        string Наименование = "";
                        stVers.Load(dr);
                        for (int x = 0; x < stVers.Rows.Count; x++)
                        {
                            if (stVers.Rows[x]["vwTypesAndAttributes_stAttrName"].ToString() == "Тип")
                                Тип = stVers.Rows[x]["stAttributes_stValue"].ToString();
                            if (stVers.Rows[x]["vwTypesAndAttributes_stAttrName"].ToString() == "Наименование")
                                Наименование = stVers.Rows[x]["stAttributes_stValue"].ToString();

                            АдресБезДома = $@"{Тип} {Наименование}";
                        }
                    }
                }
                //con.Close();

                if (АдресБезДома == "") return;
                //using (SqlConnection con = new SqlConnection(string.Format(ConnectionStrings.SQL, new object[] { tbServer, Catalog, tbUser, tbPassword, ConnectionTimeout })))
                {
                    //con.Open();
                    using (SqlCommand sc = new SqlCommand($@"Select vwObjects1._PRODUCT As vwObjects1__PRODUCT, vwObjects1._TYPE As vwObjects1__TYPE, vwObjects2._PRODUCT As vwObjects2__PRODUCT, vwObjects2._TYPE As vwObjects2__TYPE, vwObjects2._ID As vwObjects2__ID From vwObjects vwObjects1 Inner Join vwLinks vwLinks1 On vwObjects1._ID = vwLinks1.inIdChild Inner Join vwObjects vwObjects2 On vwObjects2._ID = vwLinks1.inIdParent Where vwObjects1._PRODUCT = '{Улица}' And vwObjects1._TYPE = 'Структурная единица'"))
                    {
                        var stVers = new DataTable("Table");
                        sc.Connection = con;
                        using (SqlDataReader dr = sc.ExecuteReader())
                        {
                            stVers.Load(dr);
                            for (int x = 0; x < stVers.Rows.Count; x++)
                            {
                                if (stVers.Rows[x]["vwObjects2__TYPE"].ToString() != "Округ")
                                    АдресБезДома = stVers.Rows[x]["vwObjects2__TYPE"].ToString() + " " + stVers.Rows[x]["vwObjects2__PRODUCT"].ToString() + ", " + АдресБезДома;
                                else
                                {
                                    // Для Мурманска - еще один уровень
                                    using (SqlCommand scn = new SqlCommand($@"Select vwObjects2._PRODUCT As vwObjects2__PRODUCT, vwObjects2._TYPE As vwObjects2__TYPE, vwObjects2._ID As vwObjects2__ID, vwLinks1.inIdChild As vwLinks1_inIdChild From vwLinks vwLinks1 Inner Join vwObjects vwObjects2 On vwObjects2._ID = vwLinks1.inIdParent Where vwLinks1.inIdChild = {stVers.Rows[x]["vwObjects2__ID"].ToString()}"))
                                    {
                                        var stVersn = new DataTable("Table");
                                        scn.Connection = con;
                                        using (SqlDataReader drn = scn.ExecuteReader())
                                        {
                                            stVersn.Load(drn);
                                            for (int xn = 0; xn < stVersn.Rows.Count; xn++)
                                            {
                                                if (stVersn.Rows[xn]["vwObjects2__TYPE"].ToString() != "Округ")
                                                    АдресБезДома = stVersn.Rows[xn]["vwObjects2__TYPE"].ToString() + " " + stVersn.Rows[xn]["vwObjects2__PRODUCT"].ToString() + ", " + АдресБезДома;
                                                else
                                                {

                                                }
                                            }
                                        }
                                    }

                                }
                            }
                        }
                    }
                    con.Close();
                }
            }
        }

        void CollectHouses(string Catalog, string Улица, SortedList<int, string> items, List<string> others)
        {
            // Запрос — точно как в рабочем коде оригинального проекта
            // («Лоцман добавка», ПоискАдреса.cs): УЛИЦА = vwLinks.inIdParent,
            // ДОМ = vwLinks.inIdChild, атрибут «Дом номер» берётся из версии
            // объекта-дома (stVersions по vwObjects1). Отличие одно — вместо
            // подстановки '{Улица}' в строку используется параметр @street
            // (результат тот же, но защищены кавычки в названиях улиц и нет
            // риска SQL-инъекций).
            var stVers = new DataTable("Table");
            using (var con = new SqlConnection(cfg.ConnectionString(Catalog)))
            {
                con.Open();
                using (SqlCommand sc = new SqlCommand($@"Select vwObjects._PRODUCT As vwObjects__PRODUCT, vwObjects1._TYPE As vwObjects1__TYPE, stAttributes.stValue As stAttributes_stValue From vwObjects Inner Join vwLinks On vwObjects._ID = vwLinks.inIdParent Inner Join vwObjects vwObjects1 On vwLinks.inIdChild = vwObjects1._ID Inner Join stVersions On vwObjects1._ID = stVersions.inId Inner Join stAttributes On stVersions.inId = stAttributes.inIdVersion Inner Join vwTypesAndAttributes On stAttributes.inIdTypeAttr =  vwTypesAndAttributes.inId Where vwObjects._TYPE Like 'Струк%' And vwTypesAndAttributes.stAttrName = 'Дом номер' And vwObjects._PRODUCT = @street"))
                {
                    sc.Connection = con;
                    sc.Parameters.AddWithValue("@street", Улица ?? "");
                    using (SqlDataReader dr = sc.ExecuteReader())
                    {
                        stVers.Load(dr);
                    }
                }


                // Обход строк результата — построчно как в оригинале, но с
                // заполнением целевых коллекций вызывающего кода:
                //   items  (SortedList<int,string>) — числовые номера домов,
                //            ключ = int для сортировки по возрастанию, значение = исходная строка;
                //   others (List<string>)           — нечисловые варианты ("2к1", "А", "10/2").
                for (int x = 0; x < stVers.Rows.Count; x++)
                {
                    string val = stVers.Rows[x]["stAttributes_stValue"].ToString().Trim();
                    if (val.Length == 0) continue;

                    int ky = 0;
                    bool numeric = int.TryParse(val, out ky);

                    if (numeric && ky >= 0)
                    {
                        // Числовой дом: ключ ky (для сортировки), значение val.
                        // Дубликаты перезаписываются — как дубликаты ключей в
                        // SortedList в оригинальном коде пропускались (_items.Contains).
                        items[ky] = val;
                    }
                    else
                    {
                        // Нечисловой/отрицательный вариант — в others без дубликатов.
                        if (!others.Contains(val)) others.Add(val);
                    }
                }
                using (SqlCommand sc = new SqlCommand($@"Select vwTypesAndAttributes.stAttrName As vwTypesAndAttributes_stAttrName, stAttributes.stValue As stAttributes_stValue From vwObjects Inner Join stAttributes On vwObjects._ID = stAttributes.inIdVersion Inner Join vwTypesAndAttributes On stAttributes.inIdTypeAttr = vwTypesAndAttributes.inId Where vwObjects._PRODUCT = '{Улица}' And vwObjects._TYPE Like 'Струк%' And (vwTypesAndAttributes.stAttrName = 'Тип' Or vwTypesAndAttributes.stAttrName = 'Наименование')"))
                {
                    stVers = new DataTable("Table");
                    sc.Connection = con;
                    using (SqlDataReader dr = sc.ExecuteReader())
                    {
                        string Тип = "";
                        string Наименование = "";
                        stVers.Load(dr);
                        for (int x = 0; x < stVers.Rows.Count; x++)
                        {
                            if (stVers.Rows[x]["vwTypesAndAttributes_stAttrName"].ToString() == "Тип")
                                Тип = stVers.Rows[x]["stAttributes_stValue"].ToString();
                            if (stVers.Rows[x]["vwTypesAndAttributes_stAttrName"].ToString() == "Наименование")
                                Наименование = stVers.Rows[x]["stAttributes_stValue"].ToString();

                            АдресБезДома = $@"{Тип} {Наименование}";
                        }
                    }
                }
                //con.Close();

                if (АдресБезДома == "") return;
                //using (SqlConnection con = new SqlConnection(string.Format(ConnectionStrings.SQL, new object[] { tbServer, Catalog, tbUser, tbPassword, ConnectionTimeout })))
                {
                    //con.Open();
                    using (SqlCommand sc = new SqlCommand($@"Select vwObjects1._PRODUCT As vwObjects1__PRODUCT, vwObjects1._TYPE As vwObjects1__TYPE, vwObjects2._PRODUCT As vwObjects2__PRODUCT, vwObjects2._TYPE As vwObjects2__TYPE, vwObjects2._ID As vwObjects2__ID From vwObjects vwObjects1 Inner Join vwLinks vwLinks1 On vwObjects1._ID = vwLinks1.inIdChild Inner Join vwObjects vwObjects2 On vwObjects2._ID = vwLinks1.inIdParent Where vwObjects1._PRODUCT = '{Улица}' And vwObjects1._TYPE = 'Структурная единица'"))
                    {
                        stVers = new DataTable("Table");
                        sc.Connection = con;
                        using (SqlDataReader dr = sc.ExecuteReader())
                        {
                            stVers.Load(dr);
                            for (int x = 0; x < stVers.Rows.Count; x++)
                            {
                                if (stVers.Rows[x]["vwObjects2__TYPE"].ToString() != "Округ")
                                    АдресБезДома = stVers.Rows[x]["vwObjects2__TYPE"].ToString() + " " + stVers.Rows[x]["vwObjects2__PRODUCT"].ToString() + ", " + АдресБезДома;
                                else
                                {
                                    // Для Мурманска - еще один уровень
                                    using (SqlCommand scn = new SqlCommand($@"Select vwObjects2._PRODUCT As vwObjects2__PRODUCT, vwObjects2._TYPE As vwObjects2__TYPE, vwObjects2._ID As vwObjects2__ID, vwLinks1.inIdChild As vwLinks1_inIdChild From vwLinks vwLinks1 Inner Join vwObjects vwObjects2 On vwObjects2._ID = vwLinks1.inIdParent Where vwLinks1.inIdChild = {stVers.Rows[x]["vwObjects2__ID"].ToString()}"))
                                    {
                                        var stVersn = new DataTable("Table");
                                        scn.Connection = con;
                                        using (SqlDataReader drn = scn.ExecuteReader())
                                        {
                                            stVersn.Load(drn);
                                            for (int xn = 0; xn < stVersn.Rows.Count; xn++)
                                            {
                                                if (stVersn.Rows[xn]["vwObjects2__TYPE"].ToString() != "Округ")
                                                    АдресБезДома = stVersn.Rows[xn]["vwObjects2__TYPE"].ToString() + " " + stVersn.Rows[xn]["vwObjects2__PRODUCT"].ToString() + ", " + АдресБезДома;
                                                else
                                                {

                                                }
                                            }
                                        }
                                    }

                                }
                            }
                        }
                    }
                }
                con.Close();
            }
        }

        private void FillFlats(string Catalog, string Улица, string Дом)
        {
            if (baseCatalog != Catalog) return;
            //using (SqlConnection con = new SqlConnection(string.Format(ConnectionStrings.SQL, new object[] { tbServer, Catalog, tbUser, tbPassword, ConnectionTimeout })))
            {
                /*
                con.Open();

                while (Дом[0] == ' ') Дом = Дом.Remove(0, 1);
                using (SqlCommand sc = new SqlCommand($@"Select vwObjects5._ID As vwObjects5__ID, vwObjects._ID As vwObjects__ID, vwObjects._PRODUCT As vwObjects__PRODUCT, stAttributes.stValue As stAttributes_stValue, vwObjects5._TYPE As vwObjects5__TYPE, stAttributes1.stValue As stAttributes1_stValue, vwObjects1._PRODUCT As vwObjects1__PRODUCT, vwTypesAndAttributes2.stAttrName As vwTypesAndAttributes2_stAttrName, stAttributes2.stValue As stAttributes2_stValue From vwObjects Inner Join vwLinks On vwObjects._ID = vwLinks.inIdParent Inner Join vwObjects vwObjects1 On vwLinks.inIdChild = vwObjects1._ID Inner Join vwLinks vwLinks1 On vwObjects1._ID = vwLinks1.inIdParent Inner Join vwObjects vwObjects2 On vwLinks1.inIdChild = vwObjects2._ID Inner Join vwLinks vwLinks2 On vwObjects2._ID = vwLinks2.inIdParent Inner Join vwObjects vwObjects3 On vwLinks2.inIdChild = vwObjects3._ID Inner Join vwLinks vwLinks3 On vwObjects3._ID = vwLinks3.inIdParent Inner Join vwObjects vwObjects4 On vwLinks3.inIdChild = vwObjects4._ID Inner Join vwLinks vwLinks4 On vwObjects4._ID = vwLinks4.inIdParent Inner Join vwObjects vwObjects5 On vwLinks4.inIdChild = vwObjects5._ID Inner Join stAttributes stAttributes1 On vwObjects5._ID = stAttributes1.inIdVersion Inner Join vwTypesAndAttributes vwTypesAndAttributes1 On vwTypesAndAttributes1.inId = stAttributes1.inIdTypeAttr Inner Join stAttributes On vwObjects1._ID = stAttributes.inIdVersion Inner Join vwTypesAndAttributes On stAttributes.inIdTypeAttr = vwTypesAndAttributes.inId Inner Join stAttributes stAttributes2 On stAttributes2.inIdVersion = vwObjects1._ID Inner Join vwTypesAndAttributes vwTypesAndAttributes2 On vwTypesAndAttributes2.inId = stAttributes2.inIdTypeAttr Where vwObjects._PRODUCT = '{Улица}' And stAttributes.stValue = '{Дом}' And(vwTypesAndAttributes2.stAttrName = 'Стоимость 1 кв.м. в ценах на 01.01.1995 года' Or vwTypesAndAttributes2.stAttrName = 'Стоимость 1 кв.м. в ценах на 01.01.2007 года' Or vwTypesAndAttributes2.stAttrName = 'Стоимость 1 кв.м. в ценах на 01.01.2009 года' Or vwTypesAndAttributes2.stAttrName = 'Стоимость 1 кв.м. в ценах на 01.01.2010 года') And vwObjects._TYPE Like 'Струк%' And vwTypesAndAttributes.stAttrName = 'Дом номер' And vwObjects3._TYPE = 'Расчет площади основного строения' And vwObjects2._TYPE = 'Описание внутренних помещений' And vwTypesAndAttributes1.stAttrName = 'Номер помещения (квартиры торгового складского и др. п.)'"))
                {
                    var stVers = new DataTable("Table");
                    sc.Connection = con;
                    using (SqlDataReader dr = sc.ExecuteReader())
                    {
                        stVers.Load(dr);
                        ArrayList items = new ArrayList();
                        for (int x = 0; x < stVers.Rows.Count; x++)
                        {
                            string key = "";
                            int ky = -1;
                            int.TryParse(stVers.Rows[x]["stAttributes1_stValue"].ToString(), out ky);
                            if (ky < 0)
                                int.TryParse(stVers.Rows[x]["Свойства_Значение"].ToString(), out ky);
                            if (ky < 0) continue;
                            if (ky < 10) key = "  " + ky.ToString();
                            else if (ky < 100) key = " " + ky.ToString();
                            else key = ky.ToString();
                            if (!items.Contains(key))
                            {
                                items.Add(key);
                                while (key[0] == ' ') key = key.Remove(0, 1);
                                Flats.Add(int.Parse(key), int.Parse(stVers.Rows[x]["vwObjects5__ID"].ToString()));
                            }
                            else
                            {

                            }
                        }
                        items.Sort();
                        txFlat.Items.AddRange(items.ToArray());
                    }
                }
                */
                /*
                string kId = "";
                using (SqlCommand sc = new SqlCommand($@"Select vwObjects1._ID As vwObjects1__ID From vwObjects Inner Join vwLinks On vwObjects._ID = vwLinks.inIdParent Inner Join vwObjects vwObjects1 On vwLinks.inIdChild = vwObjects1._ID Inner Join stAttributes On vwObjects1._ID = stAttributes.inIdVersion Inner Join vwTypesAndAttributes On stAttributes.inIdTypeAttr = vwTypesAndAttributes.inId Where vwObjects._PRODUCT = '{Улица}' And stAttributes.stValue = '{Дом}' And vwObjects._TYPE Like 'Струк%' And vwTypesAndAttributes.stAttrName = 'Дом номер'"))
                {
                    var stVers = new DataTable("Table");
                    sc.Connection = con;
                    using (SqlDataReader dr = sc.ExecuteReader())
                    {
                        stVers.Load(dr);
                        ArrayList items = new ArrayList();
                        for (int x = 0; x < stVers.Rows.Count; x++)
                        {
                            kId = stVers.Rows[x]["vwObjects1__ID"].ToString();
                        }
                        items.Sort();
                        txFlat.Items.AddRange(items.ToArray());
                    }
                }
                if (kId == "") return;
                
                using (SqlCommand sc = new SqlCommand($@"Select vwObjects1._ID As vwObjects1__ID, vwObjects1._PRODUCT As vwObjects1__PRODUCT, vwTypesAndAttributes.stAttrName As vwTypesAndAttributes_stAttrName, stAttributes.stValue As stAttributes_stValue From vwObjects Inner Join vwLinks On vwObjects._ID = vwLinks.inIdParent Inner Join vwObjects vwObjects1 On vwLinks.inIdChild = vwObjects1._ID Inner Join stAttributes On vwObjects1._ID = stAttributes.inIdVersion Inner Join vwTypesAndAttributes On stAttributes.inIdTypeAttr = vwTypesAndAttributes.inId Where vwObjects1._ID = '{kId}' And vwObjects._PRODUCT = 'Бабикова (Заполярный)' And vwObjects._TYPE Like 'Струк%' And (vwTypesAndAttributes.stAttrName = 'Стоимость 1 кв.м. в ценах на 01.01.1995 года' Or vwTypesAndAttributes.stAttrName = 'Стоимость 1 кв.м. в ценах на 01.01.2007 года' Or vwTypesAndAttributes.stAttrName = 'Стоимость 1 кв.м. в ценах на 01.01.2009 года' Or vwTypesAndAttributes.stAttrName = 'Стоимость 1 кв.м. в ценах на 01.01.2010 года')"))
                {
                    var stVers = new DataTable("Table");
                    sc.Connection = con;
                    using (SqlDataReader dr = sc.ExecuteReader())
                    {
                        string Стоимость1квмвценахна01_01_1995года = "";
                        string Стоимость1квмвценахна01_01_2007года = "";
                        string Стоимость1квмвценахна01_01_2009года = "";
                        string Стоимость1квмвценахна01_01_2010года = "";

                        stVers.Load(dr);
                        ArrayList items = new ArrayList();
                        for (int x = 0; x < stVers.Rows.Count; x++)
                        {
                            switch (stVers.Rows[x]["vwTypesAndAttributes_stAttrName"].ToString())
                            {
                                case "Стоимость 1 кв.м. в ценах на 01.01.1995 года": Стоимость1квмвценахна01_01_1995года = stVers.Rows[x]["stAttributes_stValue"].ToString(); break;
                                case "Стоимость 1 кв.м. в ценах на 01.01.2007 года": Стоимость1квмвценахна01_01_2007года = stVers.Rows[x]["stAttributes_stValue"].ToString(); break;
                                case "Стоимость 1 кв.м. в ценах на 01.01.2009 года": Стоимость1квмвценахна01_01_2009года = stVers.Rows[x]["stAttributes_stValue"].ToString(); break;
                                case "Стоимость 1 кв.м. в ценах на 01.01.2010 года": Стоимость1квмвценахна01_01_2010года = stVers.Rows[x]["stAttributes_stValue"].ToString(); break;
                            }
                        }
                        double dСтоимость1квмвценахна01_01_1995года = 0D;
                        double.TryParse(Стоимость1квмвценахна01_01_1995года.Replace(".", ","), out dСтоимость1квмвценахна01_01_1995года);
                        double dСтоимость1квмвценахна01_01_2007года = 0D;
                        double.TryParse(Стоимость1квмвценахна01_01_2007года.Replace(".", ","), out dСтоимость1квмвценахна01_01_2007года);
                        double dСтоимость1квмвценахна01_01_2009года = 0D;
                        double.TryParse(Стоимость1квмвценахна01_01_2009года.Replace(".", ","), out dСтоимость1квмвценахна01_01_2009года);
                        double dСтоимость1квмвценахна01_01_2010года = 0D;
                        double.TryParse(Стоимость1квмвценахна01_01_2010года.Replace(".", ","), out dСтоимость1квмвценахна01_01_2010года);
                        
                        //if (dСтоимость1квмвценахна01_01_1995года == 0D) MessageBox.Show("Не заполнено поле \"Стоимость 1 кв.м.в ценах на 01.01.1995 года\" по адресу " + Адрес );
                        //if (dСтоимость1квмвценахна01_01_2007года == 0D) MessageBox.Show("Не заполнено поле \"Стоимость 1 кв.м.в ценах на 01.01.2007 года\" по адресу " + Адрес);
                        //if (dСтоимость1квмвценахна01_01_2009года == 0D) MessageBox.Show("Не заполнено поле \"Стоимость 1 кв.м.в ценах на 01.01.2009 года\" по адресу " + Адрес);
                        //if (dСтоимость1квмвценахна01_01_2010года == 0D) MessageBox.Show("Не заполнено поле \"Стоимость 1 кв.м.в ценах на 01.01.2010 года\" по адресу " + Адрес);
                                                
                        //if (dСтоимость1квмвценахна01_01_1995года != 0D)
                        {
                            if (dСтоимость1квмвценахна01_01_2007года != dСтоимость1квмвценахна01_01_1995года * 20) MessageBox.Show("Неправильно заполнено поле \"Стоимость 2007 года\" по адресу " + Адрес);
                            if (dСтоимость1квмвценахна01_01_2009года != dСтоимость1квмвценахна01_01_1995года * 33.74) MessageBox.Show("Неправильно заполнено поле \"Стоимость 2009 года\" по адресу " + Адрес);
                            if (dСтоимость1квмвценахна01_01_2010года != dСтоимость1квмвценахна01_01_1995года * 40.54) MessageBox.Show("Неправильно заполнено поле \"Стоимость 2010 года\" по адресу " + Адрес);
                            ИнвСтоимость = (dСтоимость1квмвценахна01_01_1995года * 40.54).ToString();
                            ИнвСтоимость2 = Стоимость1квмвценахна01_01_2010года;
                        }
                        
                        items.Sort();
                        txFlat.Items.AddRange(items.ToArray());
                    }
                }
                */
                //con.Close();
            }
            //Flats.processInSortedOrder();
        }

        // Квартиры дома: цепочка связей Структурная единица -> Описание внутренних помещений
        // -> Расчет площади основного строения; атрибут «Номер помещения...».
        // Возвращает пары: номер квартиры -> _ID объекта квартиры.
        public List<KeyValuePair<int, int>> GetFlats(string catalog, string Улица, string Дом)
        {
            var flats = new Dictionary<int, int>();
            using (var con = new SqlConnection(cfg.ConnectionString(catalog)))
            using (var sc = new SqlCommand( 
                // Цепочка потомков (дом -> ... -> квартира): каждый следующий
                // объект является ПОТОМКОМ предыдущего, т.е. связь идём от
                // inIdChild предыдущего к inIdParent следующего (см. комментарий
                // в CollectHouses: улица = inIdChild, дом = inIdParent).
                $@"Select vwObjects5._ID As vwObjects5__ID, vwObjects._ID As vwObjects__ID, vwObjects._PRODUCT As vwObjects__PRODUCT, stAttributes.stValue As stAttributes_stValue, vwObjects5._TYPE As vwObjects5__TYPE, stAttributes1.stValue As stAttributes1_stValue, vwObjects1._PRODUCT As vwObjects1__PRODUCT, vwTypesAndAttributes2.stAttrName As vwTypesAndAttributes2_stAttrName, stAttributes2.stValue As stAttributes2_stValue From vwObjects Inner Join vwLinks On vwObjects._ID = vwLinks.inIdParent Inner Join vwObjects vwObjects1 On vwLinks.inIdChild = vwObjects1._ID Inner Join vwLinks vwLinks1 On vwObjects1._ID = vwLinks1.inIdParent Inner Join vwObjects vwObjects2 On vwLinks1.inIdChild = vwObjects2._ID Inner Join vwLinks vwLinks2 On vwObjects2._ID = vwLinks2.inIdParent Inner Join vwObjects vwObjects3 On vwLinks2.inIdChild = vwObjects3._ID Inner Join vwLinks vwLinks3 On vwObjects3._ID = vwLinks3.inIdParent Inner Join vwObjects vwObjects4 On vwLinks3.inIdChild = vwObjects4._ID Inner Join vwLinks vwLinks4 On vwObjects4._ID = vwLinks4.inIdParent Inner Join vwObjects vwObjects5 On vwLinks4.inIdChild = vwObjects5._ID Inner Join stAttributes stAttributes1 On vwObjects5._ID = stAttributes1.inIdVersion Inner Join vwTypesAndAttributes vwTypesAndAttributes1 On vwTypesAndAttributes1.inId = stAttributes1.inIdTypeAttr Inner Join stAttributes On vwObjects1._ID = stAttributes.inIdVersion Inner Join vwTypesAndAttributes On stAttributes.inIdTypeAttr = vwTypesAndAttributes.inId Inner Join stAttributes stAttributes2 On stAttributes2.inIdVersion = vwObjects1._ID Inner Join vwTypesAndAttributes vwTypesAndAttributes2 On vwTypesAndAttributes2.inId = stAttributes2.inIdTypeAttr Where vwObjects._PRODUCT = '{Улица}' And stAttributes.stValue = '{Дом}' And(vwTypesAndAttributes2.stAttrName = 'Стоимость 1 кв.м. в ценах на 01.01.1995 года' Or vwTypesAndAttributes2.stAttrName = 'Стоимость 1 кв.м. в ценах на 01.01.2007 года' Or vwTypesAndAttributes2.stAttrName = 'Стоимость 1 кв.м. в ценах на 01.01.2009 года' Or vwTypesAndAttributes2.stAttrName = 'Стоимость 1 кв.м. в ценах на 01.01.2010 года') And vwObjects._TYPE Like 'Струк%' And vwTypesAndAttributes.stAttrName = 'Дом номер' And vwObjects3._TYPE = 'Расчет площади основного строения' And vwObjects2._TYPE = 'Описание внутренних помещений' And vwTypesAndAttributes1.stAttrName = 'Номер помещения (квартиры торгового складского и др. п.)'", con))
            /*
            @"Select vwObjects5._ID, stAttributes1.stValue
              From vwObjects
              Inner Join vwLinks On vwObjects._ID = vwLinks.inIdChild
              Inner Join vwObjects vwObjects1 On vwLinks.inIdParent = vwObjects1._ID
              Inner Join stAttributes On vwObjects1._ID = stAttributes.inIdVersion
              Inner Join vwTypesAndAttributes On stAttributes.inIdTypeAttr = vwTypesAndAttributes.inId
              Inner Join vwLinks vwLinks1 On vwObjects1._ID = vwLinks1.inIdChild
              Inner Join vwObjects vwObjects2 On vwLinks1.inIdParent = vwObjects2._ID
              Inner Join vwLinks vwLinks2 On vwObjects2._ID = vwLinks2.inIdChild
              Inner Join vwObjects vwObjects3 On vwLinks2.inIdParent = vwObjects3._ID
              Inner Join vwLinks vwLinks3 On vwObjects3._ID = vwLinks3.inIdChild
              Inner Join vwObjects vwObjects4 On vwLinks3.inIdParent = vwObjects4._ID
              Inner Join vwLinks vwLinks4 On vwObjects4._ID = vwLinks4.inIdChild
              Inner Join vwObjects vwObjects5 On vwLinks4.inIdParent = vwObjects5._ID
              Inner Join stAttributes stAttributes1 On vwObjects5._ID = stAttributes1.inIdVersion
              Inner Join vwTypesAndAttributes vwTypesAndAttributes1 On vwTypesAndAttributes1.inId = stAttributes1.inIdTypeAttr
              Where vwObjects._TYPE Like 'Струк%'
                And vwTypesAndAttributes.stAttrName = 'Дом номер'
                And vwTypesAndAttributes1.stAttrName = 'Номер помещения (квартиры торгового складского и др. п.)'
                And vwObjects._PRODUCT = @street
                And stAttributes.stValue = @house", con))
            */
            {
                //sc.Parameters.AddWithValue("@street", street ?? "");
                //sc.Parameters.AddWithValue("@house", house ?? "");
                //con.ConnectionTimeout = 480;
                con.Open();
                using (var dr = sc.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        int id = Convert.ToInt32(dr.GetValue(0));
                        int num;
                        if (int.TryParse(dr.GetValue(5).ToString().Trim(), out num) && num >= 0)
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
                        // Житель — ПОТОМОК квартиры: квартира._ID = inIdChild,
                        // объект жителя = inIdParent (см. CollectHouses).
                        @"Select vwObjects._ID
                          From vwLinks
                          Inner Join vwObjects On vwLinks.inIdParent = vwObjects._ID
                          Where vwLinks.inIdChild = @id", con))
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
