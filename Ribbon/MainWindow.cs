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

namespace TX_Text_Control_Words
{
	/*-------------------------------------------------------------------------------------------------------------
	** class MainWindow
	**-----------------------------------------------------------------------------------------------------------*/
	public partial class MainWindow : TXTextControl.Windows.Forms.Ribbon.RibbonForm {

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
		private FileHandling.FileHandler m_fileHandler;
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
		public MainWindow() {
			InitializeComponent();

			// Set main window icon
			//this.Icon = new Icon(typeof(MainWindow), "Icons.tx.ico");

			// Initialize - FileHandler
			m_fileHandler = new FileHandling.FileHandler(m_textControl);
			m_fileHandler.MaxRecentFiles = 5;
			m_fileHandler.ShowMessageBox += FileHandler_ShowMessageBox;
			m_fileHandler.DocumentDirtyChanged += FileHandler_DocumentDirtyChanged;
			m_fileHandler.DocumentFileNameChanged += FileHandler_DocumentFileNameChanged;
			m_fileHandler.RecentFileListChanged += FileHandler_RecentFileListChanged;
			m_fileHandler.UserInputRequested += FileHandler_UserInputRequested;
			m_fileHandler.PropertyChanged += FileHandler_PropertyChanged_SetButtonStates;
			//m_fileHandler.боцман = (Боцман)this.Parent;
			m_fileHandler.Родитель = "-1";

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
			m_UAC = new UserAccessControl(m_textControl);
			m_UAC.KnownUsers.CollectionChanged += KnownUsers_CollectionChanged;

			LocalizeWindow();

			SetWindowTitle(m_fileHandler.DocumentTitle);

			LoadAppSettings();

		} // Constructor

		/*-------------------------------------------------------------------------------------------------------------
		** M E T H O D S
		**-----------------------------------------------------------------------------------------------------------*/

		/*-------------------------------------------------------------------------------------------------------------
		** KnownUsers_CollectionChanged
		** Update the registered usernames in Ribbon's PermissionTab when the User Access Control notifies about
		** a change of the known users.
		**-----------------------------------------------------------------------------------------------------------*/
		private void KnownUsers_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) {
			// Update registered user list in permission tab
			m_permissionsTab.RegisteredUserNames = m_UAC.KnownUsers.Select(ui => ui.Name).ToArray();
		}

		/*-------------------------------------------------------------------------------------------------------------
		** LocalizeWindow
		** Localize this window's UI Elements
		**-----------------------------------------------------------------------------------------------------------*/
		private void LocalizeWindow() {
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
		private void LoadAppSettings() {

			// Users
			m_fileHandler.RecentFiles = new System.Collections.Specialized.StringCollection();

			// Right to left
			this.RightToLeft = new RightToLeft();
			switch (this.RightToLeft) {
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
		private void SaveAppSettings() {

			// RecentFiles
			//Лоцман_добавка.Properties.Settings.Default.RecentFiles = m_fileHandler.RecentFiles;

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
        private void SetStatusBarColor(Color col) {
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
			/*
			int x = 0;
			string Родитель = Id;
			DataTable _dt = dt;
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
			m_textControl.Selection.Start = m_textControl.Text.Length;
			m_textControl.Selection.Length = 1;
			m_textControl.Selection.Bold = true;
			m_textControl.Selection.Text = "";
			*/
			this.m_textControl.Selection.Text = text;
		}
		public void LoadFile(string file)
		{
			FileStream fs = new FileStream(file, FileMode.Open);
			m_textControl.Load(fs, StreamType.InternalFormat);
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
			/*
			БоцманAdapter.SelectCommand.CommandText = string.Format("Select * From Свойства Where Id={0}", IdКвартира);
			DataSet SDS = new DataSet();
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
