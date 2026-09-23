/*-------------------------------------------------------------------------------------------------------------
** program:			TX Text Control Words
** description:	Implements a typical word processing application build up on the main features of TextControl's Components. 
**
** copyright:		© Text Control GmbH
**-----------------------------------------------------------------------------------------------------------*/
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using TX_Text_Control_Words.Properties;
using TXTextControl.Windows.Forms.Ribbon;
using System.Collections.ObjectModel;
using TXTextControl.Windows.Forms;
using System.Diagnostics;
using System;
using System.Globalization;
using TXTextControl;

namespace TX_Text_Control_Words {

	/*-------------------------------------------------------------------------------------------------------------
	** class MainWindow
	**-----------------------------------------------------------------------------------------------------------*/
	public partial class MainWindow : TXTextControl.Windows.Forms.Ribbon.RibbonForm {

		/*-------------------------------------------------------------------------------------------------------------
		** M E M B E R S
		**-----------------------------------------------------------------------------------------------------------*/

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
			this.Icon = new Icon(typeof(MainWindow), "Icons.tx.ico");

			// Initialize - FileHandler
			m_fileHandler = new FileHandling.FileHandler(m_textControl);
			m_fileHandler.MaxRecentFiles = Properties.Settings.Default.RecentFilesMaxItemCount;
			m_fileHandler.ShowMessageBox += FileHandler_ShowMessageBox;
			m_fileHandler.DocumentDirtyChanged += FileHandler_DocumentDirtyChanged;
			m_fileHandler.DocumentFileNameChanged += FileHandler_DocumentFileNameChanged;
			m_fileHandler.RecentFileListChanged += FileHandler_RecentFileListChanged;
			m_fileHandler.UserInputRequested += FileHandler_UserInputRequested;
			m_fileHandler.PropertyChanged += FileHandler_PropertyChanged_SetButtonStates;

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
			m_statusBar.LineText = Resources.STATUSBAR_LINE;
			m_statusBar.PageText = Resources.STATUSBAR_PAGE;
			m_statusBar.ColumnText = Resources.STATUSBAR_COLUMN;
			m_statusBar.SectionText = Resources.STATUSBAR_SECTION;

			// Contextual Tab Group headers
			m_tableToolsGroup.Header = Resources.CONT_TAB_GRP_TBL_TOOLS;
			m_frameToolsGroup.Header = Resources.CONT_TAB_GRP_FRAME_TOOLS;

			// Set individual text to contextual ribbon tabs so the text in the 
			// contextual tab group header is completely visible
			m_frameLayoutTab.Text = Properties.Resources.RIBBON_TAB_FRAME_FORMAT_HEADER;
			m_tableLayoutTab.Text = Properties.Resources.RIBBON_TAB_TABLE_FORMAT_HEADER;
			m_chartLayoutTab.Text = Properties.Resources.RIBBON_TAB_CHART_FORMAT_HEADER;
		}

		/*-------------------------------------------------------------------------------------------------------------
		** LoadAppSettings
		** Load the application's settings.
		**-----------------------------------------------------------------------------------------------------------*/
		private void LoadAppSettings() {

			// Users
			if (Properties.Settings.Default.KnownUsers != null) {
				m_UAC.KnownUsers.Set(Properties.Settings.Default.KnownUsers);
			}
			// Recent items
			m_fileHandler.RecentFiles = Properties.Settings.Default.RecentFiles;

			// Right to left
			this.RightToLeft = Properties.Settings.Default.RightToLeft;
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
			Properties.Settings.Default.RecentFiles = m_fileHandler.RecentFiles;

			// Users
			// Clone user list and reset access settings before saving
			Properties.Settings.Default.KnownUsers = m_UAC.KnownUsers.ToList<UserInfo>().ConvertAll(ui => new UserInfo(ui) { AccessGranted = false });
			Properties.Settings.Default.Save();
		}

		/*-------------------------------------------------------------------------------------------------------------
		** SetWindowTitle
		** Set the window title. Show document's title and the document dirty state. 
		**-----------------------------------------------------------------------------------------------------------*/
		private void SetWindowTitle(string documentTitle, bool isDocumentDirty = false) {
			string asterisk = isDocumentDirty ? "*" : "";
			string title = string.Format("{0}{1} - {2}", documentTitle, asterisk, ProductName);
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

	} // class MainWindow
}
