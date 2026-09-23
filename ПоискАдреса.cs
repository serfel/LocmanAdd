using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GlacialComponents.Controls;
using TX_Text_Control_Words;

namespace Лоцман_добавка
{
    public partial class ПоискАдреса : Form
   {
      //public string tbServer = "LOCMANGL";
      public string tbServer = "192.168.50.15";
        public string tbCatalog = "Murmansk";
        
        public string baseCatalog = "Murmansk";

        public string tbUser = "ctx";
        public string tbPassword = "super";
        public string ConnectionTimeout = "480";
        string АдресБезДома = "";

        public void FillStreets(string Catalog)
        {
            //АдресБезДома = "";
            using (SqlConnection con = new SqlConnection(string.Format(ConnectionStrings.SQL, new object[] { tbServer, Catalog, tbUser, tbPassword, ConnectionTimeout })))
            {
                con.Open();
                using (SqlCommand sc = new SqlCommand("Select vwObjects._PRODUCT As vwObjects__PRODUCT From vwObjects Where vwObjects._TYPE Like 'Струк%'"))
                {
                    var stVers = new DataTable("Table");
                    sc.Connection = con;
                    using (SqlDataReader dr = sc.ExecuteReader())
                    {
                        stVers.Load(dr);
                        for (int x = 0; x < stVers.Rows.Count; x++)
                        {
                            string name = stVers.Rows[x]["vwObjects__PRODUCT"].ToString();
                            if (!glПоискУлица.Items.Contains(name))
                            {
                                glПоискУлица.Items.Add(name);                                                                
                            }
                            else
                            {

                            }
                        }
                    }
                }
                con.Close();
            }
        }

        public ПоискАдреса()
        {
            InitializeComponent();
            FillStreets("Murmansk");
            FillStreets("Apatit");
            FillStreets("Кандалакша");
            FillStreets("Печенга");
            FillStreets("Североморск");
            FillStreets("Мончегорск");
            glПоискУлица.Sorted = true;
        }

        private void FillHouses(string Catalog, string Улица)
        {
            //АдресБезДома = "";
            using (SqlConnection con = new SqlConnection(string.Format(ConnectionStrings.SQL, new object[] { tbServer, Catalog, tbUser, tbPassword, ConnectionTimeout })))
            {
                con.Open();
                using (SqlCommand sc = new SqlCommand($@"Select vwObjects._PRODUCT As vwObjects__PRODUCT, vwObjects1._TYPE As vwObjects1__TYPE, stAttributes.stValue As stAttributes_stValue From vwObjects Inner Join vwLinks On vwObjects._ID = vwLinks.inIdParent Inner Join vwObjects vwObjects1 On vwLinks.inIdChild = vwObjects1._ID Inner Join stVersions On vwObjects1._ID = stVersions.inId Inner Join stAttributes On stVersions.inId = stAttributes.inIdVersion Inner Join vwTypesAndAttributes On stAttributes.inIdTypeAttr =  vwTypesAndAttributes.inId Where vwObjects._TYPE Like 'Струк%' And vwTypesAndAttributes.stAttrName = 'Дом номер' And vwObjects._PRODUCT = '{Улица}'"))
                {
                    var stVers = new DataTable("Table");
                    sc.Connection = con;
                    using (SqlDataReader dr = sc.ExecuteReader())
                    {
                        stVers.Load(dr);
                        
                        /*
                        for (int x = 0; x < stVers.Rows.Count; x++)
                        {

                            if (!txHouse.Items.Contains(stVers.Rows[x]["stAttributes_stValue"].ToString()))
                            {
                                txHouse.Items.Add(stVers.Rows[x]["stAttributes_stValue"].ToString());
                                baseCatalog = Catalog;                                
                            }
                            else
                            {

                            }
                        }
                        */
                        ArrayList items = new ArrayList();
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
                            if (!items.Contains(key))
                            {
                                items.Add(key);
                            }
                            else
                            {

                            }
                            if (!items.Contains(stVers.Rows[x]["stAttributes_stValue"].ToString()))
                            {
                                items.Add(stVers.Rows[x]["stAttributes_stValue"].ToString());
                                baseCatalog = Catalog;
                            }
                            else
                            {

                            }                            
                        }
                        items.Sort();
                        for (int x = 0; x < items.Count; x++)
                        {
                            while (items[x].ToString()[0] == ' ')
                                items[x] = items[x].ToString().Remove(0,1);
                        }
                        txHouse.Items.AddRange(items.ToArray());
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
                con.Close();
            }
            if (АдресБезДома == "") return;
            using (SqlConnection con = new SqlConnection(string.Format(ConnectionStrings.SQL, new object[] { tbServer, Catalog, tbUser, tbPassword, ConnectionTimeout })))
            {
                con.Open();
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
                                // Для Мурманска - еще один урровень
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
                
        private void glПоискУлица_Leave(object sender, EventArgs e)
        {
            txHouse.Items.Clear();
            string Улица = glПоискУлица.Text;
            FillHouses("Murmansk", Улица);
            FillHouses("Apatit", Улица);
            FillHouses("Кандалакша", Улица);
            FillHouses("Печенга", Улица);
            FillHouses("Североморск", Улица);
            FillHouses("Мончегорск", Улица);
            //txHouse.Sorted = true;
        }

        SortedDictionary<int, int> Flats = new SortedDictionary<int, int>();
        private void FillFullFlats(string Catalog, string Улица, string Дом, string Список)
        {
            if (baseCatalog != Catalog) return;
            foreach (var NumKv in Flats.Keys.OrderBy(x => x))
            {
                Application.DoEvents();
                if (Список != "")
                {
                    var split = Список.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                }

                SortedDictionary<string, int> Sobstv = new SortedDictionary<string, int>();
                ArrayList ar = new ArrayList();
                using (SqlConnection con = new SqlConnection(string.Format(ConnectionStrings.SQL, new object[] { tbServer, Catalog, tbUser, tbPassword, ConnectionTimeout })))
                {
                    int Id = Flats[NumKv];
                    con.Open(); // Список собственников
                    using (SqlCommand sc = new SqlCommand($@"Select vwObjects._ID As vwObjects__ID From vwLinks Inner Join vwObjects On vwLinks.inIdChild = vwObjects._ID Where vwLinks.inIdParent = '{Id}'"))
                    {
                        Dictionary<string, ArrayList> dogovors = new Dictionary<string, ArrayList>();

                        sc.Connection = con;
                        using (SqlDataReader dr = sc.ExecuteReader())
                        {
                            var stVers = new DataTable("Table");
                            stVers.Load(dr);
                            for (int x = 0; x < stVers.Rows.Count; x++) // Список Id Собственников
                            {
                                int id = int.Parse(stVers.Rows[x][0].ToString());

                                using (SqlConnection conn = new SqlConnection(string.Format(ConnectionStrings.SQL, new object[] { tbServer, Catalog, tbUser, tbPassword, ConnectionTimeout })))
                                {
                                    conn.Open(); // Список собственников
                                    using (SqlCommand scn = new SqlCommand($@"Select vwObjects._ID As vwObjects__ID, vwTypesAndAttributes1.stAttrName As vwTypesAndAttributes1_stAttrName, stAttributes1.stValue As stAttributes1_stValue From vwObjects Inner Join stAttributes stAttributes1 On stAttributes1.inIdVersion =  vwObjects._ID Inner Join vwTypesAndAttributes vwTypesAndAttributes1 On  vwTypesAndAttributes1.inId = stAttributes1.inIdTypeAttr Where vwObjects._ID = '{id}'"))
                                    {
                                        
                                        scn.Connection = conn;
                                        using (SqlDataReader drn = scn.ExecuteReader())
                                        {
                                            var stVersn = new DataTable("Table");
                                            stVersn.Load(drn);
                                            for (int xn = 0; xn < stVersn.Rows.Count; xn++)
                                            {
                                                int idn = int.Parse(stVersn.Rows[xn]["vwObjects__ID"].ToString());
                                                if (stVersn.Rows[xn]["vwTypesAndAttributes1_stAttrName"].ToString() == "Тип договора")
                                                {
                                                    if (!dogovors.ContainsKey(stVersn.Rows[xn]["stAttributes1_stValue"].ToString()))
                                                         dogovors.Add(stVersn.Rows[xn]["stAttributes1_stValue"].ToString(), new ArrayList() { idn });
                                                    else dogovors[stVersn.Rows[xn]["stAttributes1_stValue"].ToString()].Add( idn );
                                                    break;
                                                }
                                            }
                                        }                                        
                                    }
                                    conn.Close();
                                }
                                Application.DoEvents();
                            }
                            foreach (var d in dogovors.Keys)
                            {
                                if (dogovors[d].Count > 1)
                                {

                                }
                                foreach (var a in dogovors[d])
                                {

                                }
                            }
                        }
                    }
                    con.Close();
                }
            }
        }

        Справка справка = new Справка();
        ArrayList Квартиры = new ArrayList();
        private void button2_Click(object sender, EventArgs e)
        {
            string Улица = glПоискУлица.Text;
            string Дом = txHouse.Text;
            var n = "Номер помещения (квартиры торгового складского и др. п.)";

            ArrayList Поля = new ArrayList();
            if (checkBox3.Checked) Поля.Add(checkBox3);
            if (checkBox2.Checked) Поля.Add(checkBox2);
            if (checkBox1.Checked) Поля.Add(checkBox1);
                        
            //if (checkBox4.Checked) Поля.Add(checkBox4);
            //if (checkBox5.Checked) Поля.Add(checkBox5);
            if (checkBox6.Checked) Поля.Add(checkBox6);
            if (checkBox7.Checked) Поля.Add(checkBox7);
            if (checkBox8.Checked) Поля.Add(checkBox8);
            if (checkBox9.Checked) Поля.Add(checkBox9);
            //if (checkBox10.Checked) Поля.Add(checkBox10);
            if (checkBox11.Checked) Поля.Add(checkBox11);
            if (checkBox12.Checked) Поля.Add(checkBox12);
            
            ArrayList outFlats = new ArrayList();
            SortedDictionary<int, int> _Flats = new SortedDictionary<int, int>();
            if (txFlat.Text != "")
            {
                var split = new ArrayList(txFlat.Text.Split(new string[] { " ", "," }, StringSplitOptions.RemoveEmptyEntries));
                foreach (var NumKv in Flats.Keys.OrderBy(x => x))
                {
                    if (split.Contains(NumKv.ToString()))
                    {
                        _Flats.Add(NumKv, Flats[NumKv]);
                    }
                }
            }
            else _Flats = Flats;
            //справка = new Справка();
            справка.Show();
            справка.CreateЗапрос(Улица, Дом, АдресБезДома + ", дом № " + Дом + ":", Поля, _Flats, tbServer, baseCatalog, tbUser, tbPassword, ConnectionTimeout, stVers);
        }

        //-----------------------------------------------------------------------------------------------------------------------
        private void GetSelectionStart(Control cntrl, out System.Reflection.PropertyInfo _SelectionStart, out string _Text, out int _TextLength, out int _TabIndex)
        {
            _SelectionStart = null;
            _TextLength = -1;
            _TabIndex = -1;
            _Text = "";
            if (cntrl == null) return;
            Type t = cntrl.GetType();
            if (t == null) return;

            while (t != null && t.Name != "TextBoxBase" && t.Name != "ComboBox")
            {
                t = t.BaseType;
            }
            if (t != null && (t.Name == "TextBoxBase" || t.Name == "ComboBox"))
            {
                _SelectionStart = t.GetProperty("SelectionStart");

                var _Txt = t.GetProperty("Text");
                _Text = _Txt.GetValue(cntrl, new object[0]).ToString();
                _TextLength = _Text.Length;

                var tabIndex = t.GetProperty("TabIndex");
                _TabIndex = int.Parse(tabIndex.GetValue(cntrl, new object[0]).ToString());
            }
        }

        /// <summary>
        /// Processes a command key.
        /// </summary>
        /// <param name="msg">A <see cref="T:System.Windows.Forms.Message"/>, passed by reference, that represents the Win32 message to process.</param>
        /// <param name="keyData">One of the <see cref="T:System.Windows.Forms.Keys"/> values that represents the key to process.</param>
        /// <returns>
        /// true if the keystroke was processed and consumed by the control; otherwise, false to allow further processing.
        /// </returns>
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            //A key was pressed!
            if (this.ActiveControl == null) return base.ProcessCmdKey(ref msg, keyData);

            Control selected = this.ActiveControl;
            var typeName = selected?.GetType().Name;

            System.Reflection.PropertyInfo _SelectionStart;
            int _TextLength, _TabIndex;
            string _Text;

            GetSelectionStart(selected, out _SelectionStart, out _Text, out _TextLength, out _TabIndex);
            object pos = _SelectionStart?.GetValue(selected, new object[0]);
            if (pos != null)
            {
                int curPos = int.Parse(pos.ToString());
                if (curPos == (typeName != "DTPicker" ? curPos : 10) && 
                    keyData == Keys.Right) // Дошли до конца, переключаем на следующего
                {
                    selected = FindControl(selected, _TabIndex + 1);

                    if (selected != null && !selected.CanFocus)
                    {
                        if (selected.Parent != null && !selected.Parent.CanFocus)
                        {
                            if (selected.Parent.GetType() == typeof(TabPage))
                            {
                                ((TabControl)selected.Parent.Parent).SelectedTab = ((TabPage)selected.Parent);
                            }
                        }
                    }

                    selected?.Focus();
                    GetSelectionStart(selected, out _SelectionStart, out _Text, out _TextLength, out _TabIndex);
                    _SelectionStart?.SetValue(selected, 0, new object[0]);
                    return true;
                }
                else
                if (curPos == 0 && keyData == Keys.Left) // Дошли до начала, переключаем на предыдущего
                {
                    selected = FindControl(selected, _TabIndex - 1);
                    selected?.Focus();
                    GetSelectionStart(selected, out _SelectionStart, out _Text, out _TextLength, out _TabIndex);
                    _SelectionStart?.SetValue(selected, 0, new object[0]);
                    return true;
                }
                else return base.ProcessCmdKey(ref msg, keyData);
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private Control FindControl(Control thisControl, int tabIndex)
        {
            string ТипОбъекта = thisControl.GetType().Name;
            //int TabIndex = thisControl.TabIndex;
            var ctrl = Fnd_Ctrl(this, tabIndex);
            if (ctrl != null)
            {
                return ctrl;
            }
            return null;
        }

        public Control Fnd_CtrlRecurse(Control CtrlNew, int tabIndex)
        {
            Control CtrlRec = null;
            for (int x = 0; x < CtrlNew.Controls.Count; x++)
            {
                Control c = CtrlNew.Controls[x];
                string ТипОбъекта = c.GetType().Name;
                if (c.TabIndex == tabIndex) return c;
                CtrlRec = Fnd_CtrlRecurse(c, tabIndex);
                if (CtrlRec != null && CtrlRec.TabIndex == tabIndex) return CtrlRec;
            }
            return CtrlRec;
        }

        public Control Fnd_Ctrl(Control CtrlNew, int tabIndex)
        {
            Control CtrlRec = null;
            for (int x = 0; x < CtrlNew.Controls.Count; x++)
            {
                Control c = CtrlNew.Controls[x];
                string ТипОбъекта = c.GetType().Name;
                if (c.TabIndex == tabIndex) return c;
                CtrlRec = Fnd_CtrlRecurse(c, tabIndex);
                if (CtrlRec != null && CtrlRec.TabIndex == tabIndex) return CtrlRec;
            }
            return CtrlRec;
        }

        private void txHouse_Leave(object sender, EventArgs e)
        {
            txFlat.Items.Clear();
            string Улица = glПоискУлица.Text;
            string Дом = txHouse.Text;
            //Адрес = АдресБезДома + ", дом № " + Дом + ":";
            Flats = new SortedDictionary<int, int>();
            FillFlats("Murmansk", Улица, Дом);
            FillFlats("Apatit", Улица, Дом);
            FillFlats("Кандалакша", Улица, Дом);
            FillFlats("Печенга", Улица, Дом);
            FillFlats("Североморск", Улица, Дом);
            FillFlats("Мончегорск", Улица, Дом);
            txFlat.Sorted = true;
        }

        string ИнвСтоимость = "";
        string ИнвСтоимость2 = "";

        DataTable stVers = new DataTable("Table");

        private void FillFlats(string Catalog, string Улица, string Дом)
        {
            if (baseCatalog != Catalog) return;
            using (SqlConnection con = new SqlConnection(string.Format(ConnectionStrings.SQL, new object[] { tbServer, Catalog, tbUser, tbPassword, ConnectionTimeout })))
            {
                con.Open();

                while (Дом[0] == ' ') Дом = Дом.Remove(0,1);
                using (SqlCommand sc = new SqlCommand($@"Select vwObjects5._ID As vwObjects5__ID, vwObjects._ID As vwObjects__ID, vwObjects._PRODUCT As vwObjects__PRODUCT, stAttributes.stValue As stAttributes_stValue, vwObjects5._TYPE As vwObjects5__TYPE, stAttributes1.stValue As stAttributes1_stValue, vwObjects1._PRODUCT As vwObjects1__PRODUCT, vwTypesAndAttributes2.stAttrName As vwTypesAndAttributes2_stAttrName, stAttributes2.stValue As stAttributes2_stValue From vwObjects Inner Join vwLinks On vwObjects._ID = vwLinks.inIdParent Inner Join vwObjects vwObjects1 On vwLinks.inIdChild = vwObjects1._ID Inner Join vwLinks vwLinks1 On vwObjects1._ID = vwLinks1.inIdParent Inner Join vwObjects vwObjects2 On vwLinks1.inIdChild = vwObjects2._ID Inner Join vwLinks vwLinks2 On vwObjects2._ID = vwLinks2.inIdParent Inner Join vwObjects vwObjects3 On vwLinks2.inIdChild = vwObjects3._ID Inner Join vwLinks vwLinks3 On vwObjects3._ID = vwLinks3.inIdParent Inner Join vwObjects vwObjects4 On vwLinks3.inIdChild = vwObjects4._ID Inner Join vwLinks vwLinks4 On vwObjects4._ID = vwLinks4.inIdParent Inner Join vwObjects vwObjects5 On vwLinks4.inIdChild = vwObjects5._ID Inner Join stAttributes stAttributes1 On vwObjects5._ID = stAttributes1.inIdVersion Inner Join vwTypesAndAttributes vwTypesAndAttributes1 On vwTypesAndAttributes1.inId = stAttributes1.inIdTypeAttr Inner Join stAttributes On vwObjects1._ID = stAttributes.inIdVersion Inner Join vwTypesAndAttributes On stAttributes.inIdTypeAttr = vwTypesAndAttributes.inId Inner Join stAttributes stAttributes2 On stAttributes2.inIdVersion = vwObjects1._ID Inner Join vwTypesAndAttributes vwTypesAndAttributes2 On vwTypesAndAttributes2.inId = stAttributes2.inIdTypeAttr Where vwObjects._PRODUCT = '{Улица}' And stAttributes.stValue = '{Дом}' And(vwTypesAndAttributes2.stAttrName = 'Стоимость 1 кв.м. в ценах на 01.01.1995 года' Or vwTypesAndAttributes2.stAttrName = 'Стоимость 1 кв.м. в ценах на 01.01.2007 года' Or vwTypesAndAttributes2.stAttrName = 'Стоимость 1 кв.м. в ценах на 01.01.2009 года' Or vwTypesAndAttributes2.stAttrName = 'Стоимость 1 кв.м. в ценах на 01.01.2010 года') And vwObjects._TYPE Like 'Струк%' And vwTypesAndAttributes.stAttrName = 'Дом номер' And vwObjects3._TYPE = 'Расчет площади основного строения' And vwObjects2._TYPE = 'Описание внутренних помещений' And vwTypesAndAttributes1.stAttrName = 'Номер помещения (квартиры торгового складского и др. п.)'"))
                {
                    stVers = new DataTable("Table");
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
                con.Close();
            }
            //Flats.processInSortedOrder();
        }

        private void glПоискУлица_Enter(object sender, EventArgs e)
        {
            АдресБезДома = "";
        }

        private void txFlat_Enter(object sender, EventArgs e)
        {
            if(txFlat.Items.Count > 0)
                txFlat.Focus();
        }
        //-----------------------------------------------------------------------------------------------------------------------
    }
    public static class Extensions
    {
        public static void processInSortedOrder<TKey, TValue>(this IDictionary<TKey, TValue> dict)
        {
            foreach (var key in dict.Keys.OrderBy(x => x))
            {
                Console.WriteLine("{0}: {1}", key, dict[key]);
            }
        }
    }
    public class ConnectionStrings
    {
        public const string SQL =
            "Data Source={0};Initial Catalog={1};User ID={2};Password={3};Connection Timeout={4}";
    }
}
