/*-------------------------------------------------------------------------------------------------------------
** program:			TX Text Control Words
** description:	Implements a typical word processing application build up on the main features of TextControl's Components. 
**
** copyright:		© Text Control GmbH
**-----------------------------------------------------------------------------------------------------------*/
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using TXTextControl.Windows.Forms.Ribbon;
using System.Collections.ObjectModel;
using TXTextControl.Windows.Forms;
using System.Diagnostics;
using System;
using System.Globalization;
using TXTextControl;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text.RegularExpressions;
using System.Collections;
using System.Data.SqlClient;
using Лоцман_добавка;
using static TXTextControl.InlineStyle;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;

namespace TX_Text_Control_Words
{
   /*-------------------------------------------------------------------------------------------------------------
	** class MainWindow
	**-----------------------------------------------------------------------------------------------------------*/
   public partial class Справка : TXTextControl.Windows.Forms.Ribbon.RibbonForm
   {

      /*-------------------------------------------------------------------------------------------------------------
		** M E M B E R S
		**-----------------------------------------------------------------------------------------------------------*/
      public string[] SelSplit { get; set; }
      public Dictionary<string, string> Dict = new Dictionary<string, string>();
      public DataTable Атрибуты { get; set; }
      public Dictionary<string, string> sАтрибуты = new Dictionary<string, string>();
      public Dictionary<int, string> dАтрибуты { get; set; }
      private string addr;
      public string Address
      {
         get { return addr; }
         set
         {
            addr = value;
            m_textControl.ПутьСохранения = Application.StartupPath + "\\Справки\\" + addr.Replace(",", "\\");
         }
      }
      public string City { get; set; }
      public int Number { get; set; }
      public string ShortAddress { get; set; }
      string outPath;
      public string OutPath
      {
         get { return outPath; }
         set
         {
            outPath = value;
            //SetWindowTitle(value);
            m_fileHandler.m_documentFileName = value;
            m_fileHandler.IsDocumentDirty = true;
            m_fileHandler.StreamType = StreamType.WordprocessingML;
            FileHandler_DocumentFileNameChanged(null, new FileHandling.DocumentFileNameChangedEventArgs(value));
         }
      }
      public DataTable dt { get; set; }
      public string БоцманConnectionString { get; set; }
      private int fileFilterIndex;

      public string Id { get; set; }

      public int FileFilterIndex
      {
         get { return fileFilterIndex; }
         set
         {
            fileFilterIndex = value;
            m_textControl.FileFilterIndex = value;
         }
      }

      // Calculate the DPI before using the ResourceProvider for getting the images.
      private float m_DPI = 96; // Application's DPI (by default the VS Designer use 96 DPI)

      // File Handling
      public FileHandling.FileHandler m_fileHandler;
      private FileDragDropHandler m_dragDropHandler;

      // Application Menu (see also ApplicationMenu.cs & ApplicationMenuEvents)
      // Dynamically created RibbonButtons:
      private RibbonButton m_btnAppMenu_OpenSample_Invoice;
      private RibbonButton m_btnAppMenu_OpenSample_PackingList;
      private RibbonButton m_btnAppMenu_OpenSample_ShipLabel;
      private RibbonButton m_btnAppMenu_Print_TXITEM_Print;
      private RibbonButton m_btnAppMenu_Print_TXITEM_Print_Quick;
      private RibbonButton m_btnAppMenu_Print_TXITEM_Print_Preview;

      // RibbonButtons of the QuickAccessToolbar: 	
      //		m_btnAppMenu_TXITEM_Save, 
      //		m_btnAppMenu_TXITEM_Open, 
      //		m_btnAppMenu_TXITEM_New,
      //		m_btnAppMenu_TXITEM_Print, ...
      private RibbonButton m_btnUndo, m_btnRedo;

      // User Access Control
      private UserAccessControl m_UAC;

      /*-------------------------------------------------------------------------------------------------------------
		** C O N S T R U C T O R S
		**-----------------------------------------------------------------------------------------------------------*/
      public Справка()
      {
         InitializeComponent();

         // Set main window icon
         //this.Icon = new Icon(typeof(MainWindow), "Icons.tx.ico");
         //this.TopMost = true;

         // Initialize - FileHandler
         m_fileHandler = new FileHandling.FileHandler(m_textControl);
         m_fileHandler.MaxRecentFiles = 3;
         m_fileHandler.ShowMessageBox += FileHandler_ShowMessageBox;
         m_fileHandler.DocumentDirtyChanged += FileHandler_DocumentDirtyChanged;
         m_fileHandler.DocumentFileNameChanged += FileHandler_DocumentFileNameChanged;
         m_fileHandler.RecentFileListChanged += FileHandler_RecentFileListChanged;
         m_fileHandler.UserInputRequested += FileHandler_UserInputRequested;
         m_fileHandler.PropertyChanged += FileHandler_PropertyChanged_SetButtonStates;
         //m_fileHandler.боцман = (Боцман)this.Parent;
         m_fileHandler.Родитель = Id;

         // Intialize - Drag n' drop handler
         m_dragDropHandler = new FileDragDropHandler();

         // Set ruler- and statusbar background colors
         Color color_rulerbars = Color.FromArgb(255, 245, 246, 247);
         m_rulerBarHor.DisplayColors.GradientBackColor = color_rulerbars;
         m_rulerBarHor.DisplayColors.BackColor = color_rulerbars;
         m_rulerBarVert.DisplayColors.GradientBackColor = color_rulerbars;
         m_rulerBarVert.DisplayColors.BackColor = color_rulerbars;
         SetStatusBarColor(Color.FromArgb(255, 43, 86, 154));

         // Initialize - User Access Control
         //m_UAC = new UserAccessControl(m_textControl);
         //m_UAC.KnownUsers.CollectionChanged += KnownUsers_CollectionChanged;

         //LocalizeWindow();

         //SetWindowTitle(m_fileHandler.DocumentTitle);

         //LoadAppSettings();

      } // Constructor

      /*-------------------------------------------------------------------------------------------------------------
		** M E T H O D S
		**-----------------------------------------------------------------------------------------------------------*/

      /*-------------------------------------------------------------------------------------------------------------
		** KnownUsers_CollectionChanged
		** Update the registered usernames in Ribbon's PermissionTab when the User Access Control notifies about
		** a change of the known users.
		**-----------------------------------------------------------------------------------------------------------*/
      private void KnownUsers_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
      {
         // Update registered user list in permission tab
         m_permissionsTab.RegisteredUserNames = m_UAC.KnownUsers.Select(ui => ui.Name).ToArray();
      }

      /*-------------------------------------------------------------------------------------------------------------
		** LocalizeWindow
		** Localize this window's UI Elements
		**-----------------------------------------------------------------------------------------------------------*/
      private void LocalizeWindow()
      {
         // Status bar
         m_statusBar.LineText = Лоцман_добавка.Properties.Resources.STATUSBAR_LINE;
         m_statusBar.PageText = Лоцман_добавка.Properties.Resources.STATUSBAR_PAGE;
         m_statusBar.ColumnText = Лоцман_добавка.Properties.Resources.STATUSBAR_COLUMN;
         m_statusBar.SectionText = Лоцман_добавка.Properties.Resources.STATUSBAR_SECTION;

         // Contextual Tab Group headers
         m_tableToolsGroup.Header = Лоцман_добавка.Properties.Resources.CONT_TAB_GRP_TBL_TOOLS;
         m_frameToolsGroup.Header = Лоцман_добавка.Properties.Resources.CONT_TAB_GRP_FRAME_TOOLS;

         // Set individual text to contextual ribbon tabs so the text in the 
         // contextual tab group header is completely visible
         m_frameLayoutTab.Text = Лоцман_добавка.Properties.Resources.RIBBON_TAB_FRAME_FORMAT_HEADER;
         m_tableLayoutTab.Text = Лоцман_добавка.Properties.Resources.RIBBON_TAB_TABLE_FORMAT_HEADER;
         m_chartLayoutTab.Text = Лоцман_добавка.Properties.Resources.RIBBON_TAB_CHART_FORMAT_HEADER;
      }

      /*-------------------------------------------------------------------------------------------------------------
		** LoadAppSettings
		** Load the application's settings.
		**-----------------------------------------------------------------------------------------------------------*/
      private void LoadAppSettings()
      {

         // Recent items
         m_fileHandler.RecentFiles = new System.Collections.Specialized.StringCollection();

         // Right to left
         this.RightToLeft = RightToLeft.No;
         switch (this.RightToLeft)
         {
            case RightToLeft.No:
               this.RightToLeftLayout = false;
               m_ribbon.RightToLeftLayout = false;
               m_rulerBarVert.Dock = DockStyle.Left;
               break;

            case RightToLeft.Yes:
               this.RightToLeftLayout = true;
               m_ribbon.RightToLeftLayout = true;
               m_rulerBarVert.Dock = DockStyle.Right;
               break;
         }
      }

      /*-------------------------------------------------------------------------------------------------------------
		** SaveAppSettings
		** Save the application's settings.
		**-----------------------------------------------------------------------------------------------------------*/
      private void SaveAppSettings()
      {

         // Users
         // Clone user list and reset access settings before saving
         //Лоцман_добавка.Properties.Settings.Default.KnownUsers = m_UAC.KnownUsers.ToList<UserInfo>().ConvertAll(ui => new UserInfo(ui) { AccessGranted = false });
         Лоцман_добавка.Properties.Settings.Default.Save();
      }

      /*-------------------------------------------------------------------------------------------------------------
		** SetWindowTitle
		** Set the window title. Show document's title and the document dirty state. 
		**-----------------------------------------------------------------------------------------------------------*/
      private void SetWindowTitle(string documentTitle, bool isDocumentDirty = false)
      {
         string asterisk = isDocumentDirty ? "*" : "";
         string title = string.Format("{0}{1} - {2}", documentTitle, asterisk, "Боцман");
         Text = title;
         Refresh();
      }
      /*-------------------------------------------------------------------------------------------------------------
    ** SetStatusBarColor
    ** Customize the StatusBar's style by setting the color.
    **-----------------------------------------------------------------------------------------------------------*/
      private void SetStatusBarColor(Color col)
      {
         m_statusBar.DisplayColors.BackColorBottom = col;
         m_statusBar.DisplayColors.BackColorMiddle = col;
         m_statusBar.DisplayColors.BackColorTop = col;
         m_statusBar.DisplayColors.FrameColor = col;
         m_statusBar.DisplayColors.SeparatorColorLight = col;
         m_statusBar.DisplayColors.ForeColor = Color.White;
         m_statusBar.DisplayColors.SeparatorColorDark = Color.White;
      }

      //-------------------------------------------------------------------------------------------
      public void CreateFile()
      {
         m_fileHandler.Open("Шаблоны\\Шапка ГОКУ ЦТИ.docx");
         //this.m_textControl.Load("Шаблоны\\Шапка ГОКУ ЦТИ.docx", TXTextControl.StreamType.MSWord);
         //this.m_textControl.Append("Шаблоны\\net.htm", TXTextControl.StreamType.HTMLFormat, TXTextControl.AppendSettings.None);
         //TXTextControl.InputPosition InputPosition = new TXTextControl.InputPosition(GotoPage.PageNo, 1, 0);
         //textControl1.InputPosition = InputPosition;
         //return;

         m_textControl.Selection.Start = m_textControl.Text.Length;
         m_textControl.Selection.Length = 1;
         m_textControl.Selection.Bold = false;
         m_textControl.Selection.Text = "";

         string text = "♠0♠♣Date♣\r\n";
         text += "♠0♠♣Number♣\r\n";
         text += "♠0♠♣Address♣\r\n";
         text += "♠0♠♣City♣\r\n";
         text += "♠0♠♣ShortAddress♣\r\n";
         text += "исполнитель ♠0♠♣27♣\r\n";

         int x = 0;
         string Родитель = Id;
         DataTable _dt = dt;
         /*
			while (Родитель != "0")
			{
				_dt = CreateTable(Родитель);
				БоцманAdapter.SelectCommand.CommandText = string.Format(@"SELECT * FROM Базовая WHERE Id={0}", Родитель);
				DataSet SDS = new DataSet();
				БоцманAdapter.DataAdapter.Fill(SDS);
				if (SDS.Tables[0].Rows.Count == 0)
				{
					break;
				}
				else
				{
					string Тип_Объекта = SDS.Tables[0].Rows[0]["Тип_Объекта"].ToString();
					for (int k = 0; k < _dt.Rows.Count; k++)
					{
						string addingText = _dt.Rows[k]["Res"].ToString() + " " + $"♠{x}♠♣" + _dt.Rows[k][1] + "♣" + " " + _dt.Rows[k][2] + "\r\n";
						text += addingText;
					}
					if (Тип_Объекта.IndexOf("строение") > 0 || Тип_Объекта.ToString().IndexOf("жилой дом") >= 0)
					{
						break;
					}
					Родитель = SDS.Tables[0].Rows[0]["Родитель"].ToString();
					x++;
				}
			}
			*/
         m_textControl.Selection.Start = m_textControl.Text.Length;
         m_textControl.Selection.Length = 1;
         m_textControl.Selection.Bold = true;
         m_textControl.Selection.Text = "";

         this.m_textControl.Selection.Text = text;
      }

      private void ИнформацияИнвентДокументов_FormClosing(object sender, FormClosingEventArgs e)
      {
         /*
			Utilites u = new Utilites(квартиры.боцман);
			if (ПерезаписатьСвойства && MessageBox.Show("Внимание", "Сохранить изменения?", MessageBoxButtons.OKCancel) == DialogResult.OK)
			{
				foreach (var item in Изменившиеся)
				{
					int ___id = item.Key;
					foreach (var subitem in Изменившиеся[___id])
					{
						квартиры.боцман.InsertOrUpdate(___id, subitem.Key, subitem.Value);
					}
				}
			}
			else
			{

			}

			квартиры.боцман.справка = new TX_Text_Control_Words.Справка();
			Utilites.ОтправкаВСправку tag = new Utilites.ОтправкаВСправку();
			tag.Название = "СПРАВКА - ХАРАКТЕРИСТИКА";
			tag.idКвартиры = квартиры.IdКвартиры;

			string НомерСправки = u.ЗагрузкаСправки(tag.idКвартиры.ToString(), tag.Название, "").ToString();

			квартиры.боцман.справка.m_textControl.Text = "";// new TX_Text_Control_Words.Справка();
			квартиры.боцман.справка.m_textControl.Tables.Clear();

			квартиры.боцман.справка.m_fileHandler.боцман = квартиры.боцман;
			квартиры.боцман.справка.m_fileHandler.Родитель = tag.idКвартиры.ToString();
			Application.DoEvents();
			квартиры.боцман.справка.Show();
			u.SetPageMargins(квартиры.боцман.справка);

			//u.ДобавитьТекст(квартиры.боцман.справка, "\r\n");

			int КолКомнат = 0;
			int.TryParse(tхКолКомнат.Text, out КолКомнат);


			//u.ДобавитьТаблицу(11 + (квартиры.ТипКвартиры == "Коммунальная квартира" ? КолКомнат : 0), 2, "                                              СПРАВКА - ХАРАКТЕРИСТИКА\r\n\r\n", true, false, false);
			u.ДобавитьТекст(квартиры.боцман.справка, "                                                   СПРАВКА - ХАРАКТЕРИСТИКА\r\n\r\n", true, false, TXTextControl.FontUnderlineStyle.None, 11);
			u.ДобавитьТекст(квартиры.боцман.справка, $"                                                                                                                                                         {DateTime.Now.ToLongDateString()}\r\n\r\n", true, false, TXTextControl.FontUnderlineStyle.SingleWordsOnly, 11);
			u.ДобавитьТекст(квартиры.боцман.справка, "\r\n");

			int rows = 12 + (квартиры.ТипКвартиры == "Коммунальная квартира" ? КолКомнат : 0), cols = 2;
			квартиры.боцман.справка.m_textControl.Selection.Start = квартиры.боцман.справка.m_textControl.Text.Length;
			квартиры.боцман.справка.m_textControl.Selection.Length = 1;
			квартиры.боцман.справка.m_textControl.Selection.Bold = false;
			квартиры.боцман.справка.m_textControl.Selection.Italic = false;
			квартиры.боцман.справка.m_textControl.Selection.FontName = "Times New Roman";
			квартиры.боцман.справка.m_textControl.Selection.FontSize = 11 * 20;
			квартиры.боцман.справка.m_textControl.Selection.Text = "";
			квартиры.боцман.справка.m_textControl.Tables.Add(rows, cols);

			квартиры.боцман.справка.m_textControl.BorderStyle = TXTextControl.BorderStyle.None;

			var table = квартиры.боцман.справка.m_textControl.Tables[m_textControl.Tables.Count];
			for (int x = 1; x <= rows; x++)
			{
				table.Rows[x].MinimumHeight = 500;
				for (int y = 1; y <= cols; y++)
				{
					table.Cells[x, y].CellFormat = new TXTextControl.TableCellFormat();
					table.Cells[x, y].CellFormat.VerticalAlignment = TXTextControl.VerticalAlignment.Center;
				}
			}
			table.Columns[1].Width = 230 * 20;
			table.Columns[2].Width = 290 * 20;

			table.Cells[1, 1].Text = "1. Город";
			table.Cells[2, 1].Text = "2. Улица";
			table.Cells[3, 1].Text = "3. Общая площадь квартиры, кв.м.___________";
			table.Cells[4, 1].Text = "4. Общая площадь дома, кв.м._______________";
			table.Cells[5, 1].Text = "5. Действительная(приведенная) \r\n"
													   + "стоимость дома ___________________________";
			table.Cells[6, 1].Text = "6. Жилая площадь квартиры, кв.м.___________";
			table.Cells[7, 1].Text = "7. Количество жилых комнат________________";
			table.Cells[8, 1].Text = "8. Стоимость 1кв.м.________________________";
			table.Cells[9, 1].Text = "9. Коэффициент пересчета на 1995г.__________";
			table.Cells[10, 1].Text = "    Коэффициент пересчета на 2010г.__________";
			table.Cells[11, 1].Text = "10. Стоимость квартиры____________________";
			table.Cells[12, 1].Text = "11. Инвентарный номер____________________";

			table.Cells[1, 2].Text = квартиры.Город;
			table.Cells[2, 2].Text = квартиры.Улица + " дом " + квартиры.Дом + " кв " + квартиры.Квартира;

			table.Cells[3, 2].Text = textBox47.Text + " кв.м";
			table.Cells[4, 2].Text = textBox1.Text + " кв.м";

			table.Cells[5, 2].Text = textBox2.Text + " руб.";

			table.Cells[6, 2].Text = textBox48.Text + " кв.м";
			table.Cells[7, 2].Text = tхКолКомнат.Text;

			double oneMeter = 0D;
			if (rb33.Checked) double.TryParse(tx33.Text.Replace(".", ","), out oneMeter);
			if (rb34.Checked) double.TryParse(tx34.Text.Replace(".", ","), out oneMeter);
			if (rb35.Checked) double.TryParse(tx35.Text.Replace(".", ","), out oneMeter);
			if (rb36.Checked) double.TryParse(tx36.Text.Replace(".", ","), out oneMeter);
			table.Cells[8, 2].Text = oneMeter.ToString() + " руб.";


			table.Cells[9, 2].Text = textBox5.Text;
			table.Cells[10, 2].Text = textBox4.Text;

			if (checkBox1.Checked)
				table.Cells[11, 2].Text = textBox5.Text + " руб.";

			table.Cells[12, 2].Text = textBox7.Text;
			*/
      }


      void AddCell(int row, int col, string num, Color color)
      {
         m_textControl.Tables[m_textControl.Tables.Count].Cells[row, col].CellFormat.BackColor = color;
         //m_textControl.Tables[m_textControl.Tables.Count].Cells[row, col].CellFormat. = color;
         m_textControl.Tables[m_textControl.Tables.Count].Cells[row, col].Text = num;
      }

      public void CreateЗапрос(string Улица, string Дом, string Адрес, ArrayList Поля, SortedDictionary<int, int> Flats, string tbServer, string Catalog, string tbUser, string tbPassword, string ConnectionTimeout, DataTable __stVers)
      {
         //m_fileHandler.Open("Шаблоны\\Шапка ГОКУ ЦТИ.docx");
         //this.m_textControl.Load("Шаблоны\\Шапка ГОКУ ЦТИ.docx", TXTextControl.StreamType.MSWord);
         //this.m_textControl.Append("Шаблоны\\net.htm", TXTextControl.StreamType.HTMLFormat, TXTextControl.AppendSettings.None);
         //TXTextControl.InputPosition InputPosition = new TXTextControl.InputPosition(GotoPage.PageNo, 1, 0);
         //textControl1.InputPosition = InputPosition;
         //return;
         Application.DoEvents();

         m_textControl.Selection.Start = m_textControl.Text.Length;
         m_textControl.Selection.Length = 1;
         m_textControl.Selection.FontSize = 240;
         m_textControl.Selection.Bold = false;
         string txt = @"		";
         if (m_textControl.Tables.Count == 0)
            txt += @"На Ваш запрос ГОКУ ""ЦТИ"" сообщает сведения о собственниках жилых помещений по адресу: ";
         m_textControl.Selection.Text = txt;
         m_textControl.Selection.Start = m_textControl.Text.Length;
         m_textControl.Selection.Length = 1;
         m_textControl.Selection.Bold = true;
         m_textControl.Selection.Text = $@"{Адрес}";
         m_textControl.Selection.Start = m_textControl.Text.Length;
         m_textControl.Selection.Text = "\r\n\r\n";

         m_textControl.Selection.Start = m_textControl.Text.Length;
         m_textControl.Selection.Length = 1;
         m_textControl.Selection.FontSize = 200; // 20х
         m_textControl.Selection.Bold = false;
         m_textControl.Tables.Add(300, Поля.Count, 190);
         //m_textControl.Tables[m_textControl.Tables.Count].W
         m_textControl.BorderStyle = TXTextControl.BorderStyle.FixedSingle;
         //m_textControl.Tables[m_textControl.Tables.Count].Select();

         //AddCell(1, 1, "Правообладатели", Color.LightGray);
         //AddCell(2, 1, "1", Color.LightGray);
         //AddCell(1, 2, "Дата регистрации в ГОКУ <<ЦТИ>>", Color.LightGray);
         //AddCell(2, 2, "2", Color.LightGray);
         //AddCell(1, 2, "Документы-основания", Color.LightGray);
         //AddCell(2, 2, "2", Color.LightGray);
         int cnt = 1;

         foreach (var p in Поля)
         {
            string text = ((CheckBox)p).Text;
            if (text == "Ф.И.О.") text = "Правообладатели";
            if (text == "Тип договора") text = "Документы основания";
            AddCell(1, cnt, ((CheckBox)p).Text, Color.LightGray);
            AddCell(2, cnt, ((CheckBox)p).Tag.ToString(), Color.LightGray);
            cnt++;
         }
         int currentRow = 3;
         foreach (var NumKv in Flats.Keys.OrderBy(x => x))
         {
            bool ВнесенаИнфаПоКвартире = false;
            Application.DoEvents();
            Dictionary<string, ArrayList> dogovors = new Dictionary<string, ArrayList>();
            ArrayList ar = new ArrayList();
            using (SqlConnection con = new SqlConnection(string.Format(ConnectionStrings.SQL, new object[] { tbServer, Catalog, tbUser, tbPassword, ConnectionTimeout })))
            {
               string Инвентстоимость = "";
               string Этаж = "";
               string Приведеннаяплощадь = "";
               string Жилаяплощадь = "";
               string Общаяплощадь = "";
               string Долевоеучастие = "";

               string ТипКвартиры = "";

               int Id = Flats[NumKv];
               con.Open();
               using (SqlCommand sc = new SqlCommand($@"Select vwObjects._ID As vwObjects__ID, vwTypesAndAttributes1.stAttrName As vwTypesAndAttributes1_stAttrName, stAttributes1.stValue As stAttributes1_stValue, stLinks.inIdParent As stLinks_inIdParent, stLinks.inIdChild As stLinks_inIdChild From vwObjects Inner Join stAttributes stAttributes1 On stAttributes1.inIdVersion = vwObjects._ID Inner Join vwTypesAndAttributes vwTypesAndAttributes1 On vwTypesAndAttributes1.inId = stAttributes1.inIdTypeAttr Inner Join stLinks On stLinks.inIdParent = vwObjects._ID Where stLinks.inIdChild = '{Id}'"))
               {
                  sc.Connection = con;
                  using (SqlDataReader dr = sc.ExecuteReader())
                  {
                     var stVers = new DataTable("Table");
                     stVers.Load(dr);
                     for (int x = 0; x < stVers.Rows.Count; x++) // Список Id Собственников
                     {
                        string val = stVers.Rows[x]["stAttributes1_stValue"].ToString();
                        switch (stVers.Rows[x]["vwTypesAndAttributes1_stAttrName"].ToString())
                        {
                           case "Этаж №": Этаж = val; break;
                        }
                     }
                  }
               }
               using (SqlCommand sc = new SqlCommand($@"Select vwObjects._ID As vwObjects__ID, vwTypesAndAttributes1.stAttrName As vwTypesAndAttributes1_stAttrName, vwObjects._TYPE As vwObjects__TYPE, stAttributes1.stValue As stAttributes1_stValue, vwObjects._TYPE As vwObjects__TYPE From vwObjects Inner Join stAttributes stAttributes1 On stAttributes1.inIdVersion = vwObjects._ID Inner Join vwTypesAndAttributes vwTypesAndAttributes1 On vwTypesAndAttributes1.inId = stAttributes1.inIdTypeAttr Where vwObjects._ID = '{Id}'"))
               {
                  sc.Connection = con;
                  using (SqlDataReader dr = sc.ExecuteReader())
                  {
                     var stVers = new DataTable("Table");
                     stVers.Load(dr);
                     if (stVers.Rows.Count > 0)
                        ТипКвартиры = stVers.Rows[0]["vwObjects__TYPE"].ToString();
                     for (int x = 0; x < stVers.Rows.Count; x++) // Список Id Собственников
                     {
                        string val = stVers.Rows[x]["stAttributes1_stValue"].ToString();
                        switch (stVers.Rows[x]["vwTypesAndAttributes1_stAttrName"].ToString())
                        {
                           case "Инвентаризационная стоимость на день инвентаризации":
                              {
                                 Инвентстоимость = val;
                              }
                              break;
                           case "Площадь квартиры по внутреннему обмеру приведенная": Приведеннаяплощадь = val; break;
                           case "Площадь квартиры по внутреннему обмеру оосновная": Жилаяплощадь = val; break;
                           case "Площадь квартиры по внутреннему обмеру общая полезная": Общаяплощадь = val; break;
                        }
                        Application.DoEvents();
                     }
                  }
               }

               var ИнвСтоимость1kvm = "";
               if (Инвентстоимость == "")
               {
                  for (int x = 0; x < __stVers.Rows.Count; x++)
                  {
                     if (__stVers.Rows[x]["stAttributes1_stValue"].ToString() == NumKv.ToString() && __stVers.Rows[x]["vwTypesAndAttributes2_stAttrName"].ToString() == "Стоимость 1 кв.м. в ценах на 01.01.2010 года")
                     {
                        ИнвСтоимость1kvm = __stVers.Rows[x]["stAttributes2_stValue"].ToString();
                        break;
                     }
                  }
               }

               //Select vwObjects._ID As vwObjects__ID, vwTypesAndAttributes.stAttrName As vwTypesAndAttributes_stAttrName, stAttributes.stValue As stAttributes_stValue From vwLinks Inner Join vwObjects On vwLinks.inIdChild = vwObjects._ID Inner Join stAttributes On stAttributes.inIdVersion = vwObjects._ID Inner Join vwTypesAndAttributes On stAttributes.inIdTypeAttr = vwTypesAndAttributes.inId Inner Join stAttributes stAttributes1 On stAttributes1.inIdVersion = vwObjects._ID Inner Join vwTypesAndAttributes vwTypesAndAttributes1 On stAttributes1.inIdTypeAttr = vwTypesAndAttributes1.inId Where vwLinks.inIdParent = '{Id}' And vwTypesAndAttributes1.stAttrName = 'Статус владельца' And stAttributes1.stValue = 'текущий'
               //using (SqlCommand sc = new SqlCommand($@"Select vwObjects._ID As vwObjects__ID, vwObjects._STATE As vwObjects__STATE From vwLinks Inner Join vwObjects On vwLinks.inIdChild = vwObjects._ID Where vwLinks.inIdParent = '{Id}' And vwObjects._STATE = 'Текущий'"))
               // Ids собственников
               using (SqlCommand sc = new SqlCommand($@"Select vwObjects._ID As vwObjects__ID From vwLinks Inner Join vwObjects On vwLinks.inIdChild = vwObjects._ID Inner Join stAttributes stAttributes1 On stAttributes1.inIdVersion = vwObjects._ID Inner Join vwTypesAndAttributes vwTypesAndAttributes1 On stAttributes1.inIdTypeAttr = vwTypesAndAttributes1.inId Where vwLinks.inIdParent = '{Id}' And vwTypesAndAttributes1.stAttrName = 'Статус владельца' And stAttributes1.stValue = 'текущий'"))
               {
                  sc.Connection = con;
                  using (SqlDataReader dr = sc.ExecuteReader())
                  {
                     var stVers = new DataTable("Table");
                     stVers.Load(dr);
                     for (int x = 0; x < stVers.Rows.Count; x++) // Список Id Собственников
                     {
                        int id = int.Parse(stVers.Rows[x][0].ToString());
                        string Типдоговора = "";
                        string Датазаписи = "";

                        using (SqlConnection conn = new SqlConnection(string.Format(ConnectionStrings.SQL, new object[] { tbServer, Catalog, tbUser, tbPassword, ConnectionTimeout })))
                        {
                           conn.Open(); // Список собственников

                           bool ЕстьДубликат = false;
                           using (SqlCommand scn = new SqlCommand($@"Select vwTypesAndAttributes.stAttrName As vwTypesAndAttributes_stAttrName, stAttributes.stValue As stAttributes_stValue From vwObjects Inner Join vwLinks On vwObjects._ID = vwLinks.inIdParent Inner Join vwObjects vwObjects1 On vwLinks.inIdChild = vwObjects1._ID Inner Join stAttributes On stAttributes.inIdVersion = vwObjects1._ID Inner Join vwTypesAndAttributes On vwTypesAndAttributes.inId = stAttributes.inIdTypeAttr Where vwObjects._ID = '{id}'"))
                           {
                              scn.Connection = conn;
                              using (SqlDataReader drn = scn.ExecuteReader())
                              {
                                 var stVersn = new DataTable("Table");
                                 stVersn.Load(drn);
                                 for (int xn = 0; xn < stVersn.Rows.Count; xn++)
                                 {
                                    ЕстьДубликат = true;
                                    if (stVersn.Rows[xn]["vwTypesAndAttributes_stAttrName"].ToString() == "Дубликат договора")
                                    {
                                       Типдоговора = stVersn.Rows[xn]["stAttributes_stValue"].ToString();
                                    }
                                    if (stVersn.Rows[xn]["vwTypesAndAttributes_stAttrName"].ToString() == "Дата выдачи дубликата договора")
                                    {
                                       Датазаписи = stVersn.Rows[xn]["stAttributes_stValue"].ToString();
                                    }
                                    if (Датазаписи != "" && Типдоговора != "")
                                    {
                                       if (!dogovors.ContainsKey(Типдоговора + "☺" + Датазаписи))
                                          dogovors.Add(Типдоговора + "☺" + Датазаписи, new ArrayList() { id });
                                       else dogovors[Типдоговора + "☺" + Датазаписи].Add(id);
                                       break;
                                    }
                                 }
                              }
                           }

                           if (!ЕстьДубликат)
                              using (SqlCommand scn = new SqlCommand($@"Select vwObjects._ID As vwObjects__ID, vwTypesAndAttributes1.stAttrName As vwTypesAndAttributes1_stAttrName, stAttributes1.stValue As stAttributes1_stValue From vwObjects Inner Join stAttributes stAttributes1 On stAttributes1.inIdVersion =  vwObjects._ID Inner Join vwTypesAndAttributes vwTypesAndAttributes1 On  vwTypesAndAttributes1.inId = stAttributes1.inIdTypeAttr Where vwObjects._ID = '{id}'"))
                              {
                                 scn.Connection = conn;
                                 using (SqlDataReader drn = scn.ExecuteReader())
                                 {
                                    var stVersn = new DataTable("Table");
                                    stVersn.Load(drn);
                                    Договоры договор = new Договоры();
                                    for (int xn = 0; xn < stVersn.Rows.Count; xn++)
                                    {
                                       if (ЕстьДубликат) break;

                                       if (!ЕстьДубликат)
                                       {
                                          if (stVersn.Rows[xn]["vwTypesAndAttributes1_stAttrName"].ToString() == "Тип договора")
                                          {
                                             Типдоговора = stVersn.Rows[xn]["stAttributes1_stValue"].ToString();
                                             Типдоговора = Типдоговора.Replace("Договора", "Договор");
                                             Типдоговора = Типдоговора.Replace("договора", "Договор");
                                             Типдоговора = Типдоговора.Replace("договор", "Договор");
                                             договор.Договор = Типдоговора;
                                          }
                                          if (stVersn.Rows[xn]["vwTypesAndAttributes1_stAttrName"].ToString() == "Дата записи")
                                          {
                                             Датазаписи = stVersn.Rows[xn]["stAttributes1_stValue"].ToString();
                                             договор.Дата = Датазаписи;
                                          }
                                          if (Датазаписи != "" && Типдоговора != "")
                                          {
                                             break;
                                          }
                                       }
                                    }
                                    if (!dogovors.ContainsKey(договор.Договор + "☺" + договор.Дата))
                                       dogovors.Add(договор.Договор + "☺" + договор.Дата, new ArrayList() { id });
                                    else dogovors[договор.Договор + "☺" + договор.Дата].Add(id);
                                    Application.DoEvents();
                                 }
                              }
                           conn.Close();
                        }
                        Application.DoEvents();
                     }

                  }
               }
               con.Close();

               //if (dogovors.Count == 0) continue;

               AddCell(currentRow, 1, "Квартира № " + NumKv, Color.White);
               m_textControl.Tables[m_textControl.Tables.Count].Select(currentRow, 1, currentRow, Поля.Count);
               m_textControl.Selection.Bold = true;
               if (m_textControl.Tables[m_textControl.Tables.Count].CanMergeCells)
                  m_textControl.Tables[m_textControl.Tables.Count].MergeCells();
               currentRow++;
               m_textControl.Tables[m_textControl.Tables.Count].Select(currentRow, 1, currentRow, Поля.Count);
               m_textControl.Selection.Bold = false;

               if (dogovors.Count == 0)
                  dogovors.Add("-☺-", new ArrayList() { "-" });

               if (dogovors.Count > 0)
               {
                  foreach (var d in dogovors.Keys)
                  {
                     var Договор = dogovors[d];
                     string ФИО = "";

                     string Датадоговора = d.Split('☺')[1];
                     string КоличествоКомнат = "";
                     string ПлощадьЖилая = "";

                     foreach (var id in dogovors[d])
                     {
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
                                    string val = stVersn.Rows[xn]["stAttributes1_stValue"].ToString();
                                    switch (stVersn.Rows[xn]["vwTypesAndAttributes1_stAttrName"].ToString())
                                    {
                                       case "Ф.И.О. владельца": ФИО += val + " \r\n"; break;
                                       //case Инвентстоимость = val; break;
                                       //case Этаж = val; break;
                                       case "Количество комнат": КоличествоКомнат = val; break;
                                       case "Площадь жилая": ПлощадьЖилая = val; break;
                                       //case "Дата записи": Датадоговора = val; break;
                                       //case Приведеннаяплощадь = val; break;
                                       //case Жилаяплощадь = val; break;
                                       //case Общаяплощадь = val; break;
                                       case "Доля владельца": Долевоеучастие = val; break;
                                          //case Площадькомнаты = val; break;
                                    }
                                 }
                              }
                           }
                           conn.Close();
                        }
                     }

                     if (Долевоеучастие == "Все доли" || Долевоеучастие == "Всё доли" || Долевоеучастие == "1" || Долевоеучастие == "все" || Долевоеучастие == "всё") Долевоеучастие = "Всё";

                     //AddCell(currentRow, 1, ФИО, Color.White);
                     if (Датадоговора.Split(' ').Length == 2)
                        Датадоговора = Датадоговора.Split(' ')[0];
                     //AddCell(currentRow, 2, Датадоговора, Color.White);
                     //AddCell(currentRow, 2, d, Color.White);

                     cnt = 1;
                     foreach (var p in Поля)
                     {
                        var val = ((CheckBox)p).Text;
                        switch (val)
                        {
                           case "Ф.И.О.": val = ФИО; break;
                           case "Тип договора":
                              val = d.Split('☺')[0]; break;
                           case "Этаж": val = Этаж; break;
                           case "Дата договора": val = Датадоговора; break;
                           case "Долевое участие":
                              {
                                 if (ТипКвартиры != "Коммунальная квартира")
                                    val = Долевоеучастие;
                                 else
                                 {
                                    string комнат = "комнат";
                                    switch (КоличествоКомнат)
                                    {
                                       case "1": комнат = "комната"; break;
                                       case "2":
                                       case "3":
                                       case "4": комнат = "комнаты"; break;
                                    }
                                    val = $@"{КоличествоКомнат} {комнат} площадью {ПлощадьЖилая} кв.м ({Долевоеучастие} доли)";
                                    val = val.Replace("доли доли", "доли");
                                    val = val.Replace("Всё доли", "Всё");
                                 }
                              }
                              break;
                           case "Общая площадь, кв.м.": val = NormalizeDouble(Общаяплощадь, 1); break;
                           case "Жилая площадь, кв.м.": val = NormalizeDouble(Жилаяплощадь, 1); break;
                           case "Приведенная площадь кв.м.": val = NormalizeDouble(Приведеннаяплощадь, 1); break;
                           case "Инвент.стоимость":
                              {
                                 if (Инвентстоимость != "")
                                 {
                                    //double di = 0D;
                                    //double.TryParse(Инвентстоимость.Replace(".", ","), out di);
                                    //val = Math.Round(di, 2).ToString("{0.00}");

                                    val = NormalizeDouble(Инвентстоимость, 2);
                                 }
                                 else
                                 {
                                    if (ИнвСтоимость1kvm != "")
                                    {
                                       /*
                                       double dd2 = 0D;
                                       if (ИнвСтоимость2 != "")
                                                   {
                                          double.TryParse(ИнвСтоимость2.Replace(".", ","), out dd2);
                                       }
                                       */
                                       double dd = 0D;
                                       double.TryParse(ИнвСтоимость1kvm.Replace(".", ","), out dd);
                                       double op = 0D;
                                       double.TryParse(Общаяплощадь.Replace(".", ","), out op);
                                       //val = Math.Round(dd * op, 2).ToString("{0.00}");

                                       //if (ИнвСтоимость == ИнвСтоимость2)
                                       val = NormalizeDouble(dd * op, 2);
                                       //else val = NormalizeDouble(dd * op, 2) + "\r\n" + NormalizeDouble(dd2 * op, 2);												
                                    }
                                    //else
                                    {
                                       //MessageBox.Show($@"В квартире {NumKv} не заполнена (или заполнена ошибочно) инвентаризационная стоимость.");
                                       //val = "";
                                    }
                                 }
                              }
                              break;
                        }
                        // Здесь определение, была ли внесена инфа по квартире
                        /*
                        if (!ВнесенаИнфаПоКвартире
                           || ((CheckBox)p).Text == "Ф.И.О."
                           || ((CheckBox)p).Text == "Тип договора"
                           || ((CheckBox)p).Text == "Дата договора"
                           || ((CheckBox)p).Text == "Долевое участие");
                        */
                        //{
                        AddCell(currentRow, cnt++, val, Color.White);
                        //}
                     }
                     //ВнесенаИнфаПоКвартире = true;
                     currentRow++;
                  }
               } 
            }
         }

         try
         {
            int tcnt = m_textControl.Tables.Count;
            while (   m_textControl.Tables[tcnt].Cells[m_textControl.Tables[tcnt].Rows.Count, 1].Text == ""
                   && m_textControl.Tables[tcnt].Cells[m_textControl.Tables[tcnt].Rows.Count, 2].Text == ""
                   && m_textControl.Tables[tcnt].Cells[m_textControl.Tables[tcnt].Rows.Count, 3].Text == "")
            {
               m_textControl.Tables[tcnt].Rows[m_textControl.Tables[tcnt].Rows.Count].Select();
               m_textControl.Tables[tcnt].Rows.Remove();
               Application.DoEvents();
            }
            m_textControl.Selection.Start = m_textControl.Text.Length;
            m_textControl.Selection.Length = 1;
            m_textControl.Selection.Bold = true;
            m_textControl.Selection.Text = "";
         }
         catch (Exception ex)
         {
            MessageBox.Show(ex.Message);
         }
      }
      public struct Договоры
      {
         public string Дата;
         public string Договор;
      }

      public string NormalizeDouble(string number, int numDigits)
      {
         double di = 0D;
         double.TryParse(number.Replace(".", ","), out di);
         if (numDigits == 1)
            return Math.Round(di, numDigits).ToString("0.0");
         if (numDigits == 2)
            return Math.Round(di, numDigits).ToString("0.00");
         if (numDigits == 3)
            return Math.Round(di, numDigits).ToString("0.000");
         return "";
      }
      public string NormalizeDouble(double number, int numDigits)
      {
         if (numDigits == 1)
            return Math.Round(number, numDigits).ToString("0.0");
         if (numDigits == 2)
            return Math.Round(number, numDigits).ToString("0.00");
         if (numDigits == 3)
            return Math.Round(number, numDigits).ToString("0.000");
         return "";
      }
      public void LoadFile(string file)
      {
         FileStream fs = new FileStream(file, FileMode.Open);
         m_textControl.Load(fs, StreamType.WordprocessingML);
         fs.Close();

         /*
      bool НезаполненныеПоляЕсть = false;
      Незаполненные_поля незаполненныеПоля = new Незаполненные_поля();
      string Квартира = "";
      // Обработка и замена
      string pattern = @"♠.*?♠♣.*?♣";
      Regex rgx = new Regex(pattern);
      foreach (Match match in rgx.Matches(m_textControl.Text))
      {
         string Атрибут = match.ToString().Substring(match.ToString().IndexOf("♠♣") + 2, match.ToString().Length - 1 - match.ToString().IndexOf("♠♣") - 2);

         if (Атрибут == "Number")  continue;
         if (Атрибут == "Date")    continue;
         if (Атрибут == "Address") continue;
         if (Атрибут == "ShortAddress") continue;
         if (Атрибут == "City")    continue;				

         int Позиция = int.Parse(match.ToString().Substring(1, match.ToString().IndexOf("♠", 1) - 1));
         int Id = int.Parse(SelSplit[0]);

         //Найдем объект из указанной позиции
         int _Id = Id;
         for (int k = 0; k < Позиция; k++)
         {
            БоцманAdapter.SelectCommand.CommandText = string.Format(@"SELECT Родитель FROM Базовая WHERE Id={0}", _Id);
            _Id = int.Parse(БоцманAdapter.SelectCommand.ExecuteScalar().ToString());
         }
         dt = CreateTable(_Id.ToString());

         string selectString = $"Атрибут={Атрибут}";
         DataRowCollection allRows = dt.Rows;
         DataRow[] searchedRows = dt.Select(selectString);
         if (searchedRows.Length == 1)
         {
            int rowIndex = allRows.IndexOf(searchedRows[0]);
            string Значение = dt.Rows[rowIndex]["Значение"].ToString();

            ReplaceText(match.ToString(), Значение);

            Application.DoEvents();
         }
         else
         {
            if (Атрибут == "58")
            {
               БоцманAdapter.SelectCommand.CommandText = string.Format(@"SELECT Тип_Объекта FROM Базовая WHERE Id={0}", Id);
               string Тип_Объекта = БоцманAdapter.SelectCommand.ExecuteScalar().ToString();
               switch (Тип_Объекта)
               {
                  case "Однокомнатная квартира": CheckFillRoom(Id, 1); ReplaceText(match.ToString(), "1"); break;
                  case "Двухкомнатная квартира": CheckFillRoom(Id, 2); ReplaceText(match.ToString(), "2"); break;
                  case "Трехкомнатная квартира": CheckFillRoom(Id, 3); ReplaceText(match.ToString(), "3"); break;
                  case "Четырехкомнатная квартира": CheckFillRoom(Id, 4); ReplaceText(match.ToString(), "4"); break;
                  case "Пятикомнатная квартира": CheckFillRoom(Id, 5); ReplaceText(match.ToString(), "5"); break;
                  case "Шестикомнатная квартира": CheckFillRoom(Id, 6); ReplaceText(match.ToString(), "6"); break;
                  case "Семикомнатная квартира": CheckFillRoom(Id, 7); ReplaceText(match.ToString(), "7"); break;
                  case "Восьмикомнатная квартира": CheckFillRoom(Id, 8); ReplaceText(match.ToString(), "8"); break;
               }
            }
            else
            {
               НезаполненныеПоляЕсть = true;
               незаполненныеПоля.textBox1.Text += sАтрибуты[Атрибут] + "\r\n";
            }
            // MessageBox.Show("Не заполнено поле " + sАтрибуты[Атрибут], "Проблема!!!");
         }
      }

      ReplaceText("♠0♠♣Date♣", DateTime.Now.ToShortDateString());
      ReplaceText("♠0♠♣Address♣", Address);
      ReplaceText("♠0♠♣ShortAddress♣", ShortAddress);
      ReplaceText("♠0♠♣City♣", City);

      ReplaceText("1 квартиры", "квартира");
      ReplaceText("все квартиры", "квартира");
      ReplaceText("Всё квартиры", "квартира");
      ReplaceText("Основание: договора купли-продажи", "Основание: Договор купли-продажи");
      ReplaceText("Основание: Договора купли-продажи", "Основание: Договор купли-продажи");

      if (НезаполненныеПоляЕсть)
      {
         незаполненныеПоля.Show();
      }
      */
      }

      DataTable CreateTable(string Id)
      {
         DataSet SDS = new DataSet();
         /*
			БоцманAdapter.SelectCommand.CommandText = string.Format("Select * From Свойства Where Id={0}", Id);			
			БоцманAdapter.DataAdapter.Fill(SDS);
			SDS.Tables[0].Columns.Add("Res");
			for (int x = 0; x < SDS.Tables[0].Rows.Count; x++)
			{
				SDS.Tables[0].Rows[x]["Res"] = dАтрибуты[int.Parse(SDS.Tables[0].Rows[x][1].ToString())];
			}
			*/
         return SDS.Tables[0];
      }
      void CheckFillRoom(int Id, int numRooms)
      {
         if (MessageBox.Show(this, $"Видимо, количество комнат {numRooms},\r\nно, это поле не заполнено.\r\nЗаполнить его?") == DialogResult.OK)
         {
            ЗаполнениеКомнат(Id, numRooms);
         }
      }
      void ЗаполнениеКомнат(int IdКвартира, int numRooms)
      {
         DataSet SDS = new DataSet();
         /*
			БоцманAdapter.SelectCommand.CommandText = string.Format("Select * From Свойства Where Id={0}", IdКвартира);
			БоцманAdapter.DataAdapter.Fill(SDS);
			DataTable dt = SDS.Tables[0];

			bool ЕстьТакоеСвойство = false;
			for (int k = 0; k < dt.Rows.Count; k++)
			{
				if (dt.Rows[k]["Атрибут"].ToString() == "58")
				{
					//UPDATE
					ЕстьТакоеСвойство = true;
				}
			}
			if (!ЕстьТакоеСвойство)
			{
				БоцманAdapter.InsertCommand.CommandText = $"Insert Into Свойства (Id,Атрибут,Значение) Values ({IdКвартира},58,{numRooms})";
				БоцманAdapter.InsertCommand.ExecuteNonQuery();
			}
			*/
      }

      void ReplaceText(string what, string towhat)
      {
         try
         {
            int pos = m_textControl.Find(what, 0, FindOptions.NoMessageBox);
            if (pos > 0)
            {
               m_textControl.Selection.FontName = "Courier New";
               m_textControl.Selection.FontSize = 200;
               m_textControl.Selection.GrowFont();
               m_textControl.Selection.Bold = true;
               m_textControl.Selection.Text = towhat;
            }
         }
         catch
         {
         }
      }
      //-------------------------------------------------------------------------------------------
   } // class MainWindow
}
