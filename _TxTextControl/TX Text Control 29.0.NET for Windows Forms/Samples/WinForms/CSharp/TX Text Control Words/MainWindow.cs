/*-------------------------------------------------------------------------------------------------------------
** program:			TX Text Control Words
** description:	Implements a typical word processing application build up on the main features of 
**						TextControl's Components. 
**
** copyright:		© Text Control GmbH
**-----------------------------------------------------------------------------------------------------------*/
using System;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using TX_Text_Control_Words.Properties;
using TXTextControl;

namespace TX_Text_Control_Words
{

	/*----------------------------------------------------------------------------------------------------------
	** class MainWindow
	**--------------------------------------------------------------------------------------------------------*/
	public partial class MainWindow : Form
	{

		/*-------------------------------------------------------------------------------------------------------
		** M E M B E R S
		**-----------------------------------------------------------------------------------------------------*/

		private FileHandling.FileHandler m_fileHandler;
		private FileDragDropHandler m_fileDragDropHandler;
		private UserAccessControl m_UAC;

		// FORM FIELD SETTINGS
		private const int DEFAULT_FORMFIELD_EMPTYWIDTH = 1701;  // in TWIPS <=> 3cm

		/*------------------------------------------------------------------------------------------------------
		** C O N S T R U C T O R
		**----------------------------------------------------------------------------------------------------*/

		public MainWindow()
		{
			InitializeComponent();

			// File handling
			m_fileHandler = new FileHandling.FileHandler(textControl);
			m_fileHandler.ShowMessageBox += FileHandler_ShowMessageBox;
			m_fileHandler.DocumentDirtyChanged += FileHandler_DocumentDirtyChanged;
			m_fileHandler.DocumentFileNameChanged += FileHandler_DocumentFileNameChanged;
			m_fileHandler.RecentFileListChanged += FileHandler_RecentFileListChanged;
			m_fileHandler.UserInputRequested += FileHandler_UserInputRequested;
			m_fileHandler.PropertyChanged += FileHandler_PropertyChanged_CanSave;
			// File handling - drag n' drop
			m_fileDragDropHandler = new FileDragDropHandler();

			SetWindowTitle(m_fileHandler.DocumentTitle);

			// User Access Control
			m_UAC = new UserAccessControl(ref textControl);

			// Set form icon
			this.Icon = new Icon(Assembly.GetExecutingAssembly().GetManifestResourceStream("TX_Text_Control_Words.Icons.tx.ico"));

			LoadAppSettings();
		}


		/*-------------------------------------------------------------------------------------------------------------
		** E V E N T I N G
		**-----------------------------------------------------------------------------------------------------------*/

		/*-------------------------------------------------------------------------------------------------------------
		** OnLoad
		** Load the application's settings and open the document passed via the application's startup-parameters.
		**-----------------------------------------------------------------------------------------------------------*/
		protected override void OnLoad(EventArgs e)
		{
			// Disable Mini Toolbar in Standard Version.
			textControl.ShowMiniToolbar = IsStandardVersion() ? MiniToolbarButton.None : MiniToolbarButton.LeftButton | MiniToolbarButton.RightButton;

			// Process Commandline-Arguments - Open document 
			var args = Environment.GetCommandLineArgs();
			if (args.Length > 1)
			{
				m_fileHandler.Open(args[1]);
			}

			// Localize by setting the texts dependly on the culture
			LocalizeToolbar();
			LocalizeToolstrip();

			// Setting images dependly on the DPI
			UpdateToolbarImages();
			UpdateToolstripImages();

			base.OnLoad(e);
		}

		/*-------------------------------------------------------------------------------------------------------------
		** OnDpiChanged
		**	Update DPI dependent settings like images.
		**-----------------------------------------------------------------------------------------------------------*/
		protected override void OnDpiChanged(DpiChangedEventArgs e)
		{
			UpdateToolbarImages();
			UpdateToolstripImages();

			base.OnDpiChanged(e);
		}

		/*-------------------------------------------------------------------------------------------------------------
		** OnFormClosing
		** Notify filehandler about the application's closing and save application's settings.
		**-----------------------------------------------------------------------------------------------------------*/
		protected override void OnFormClosing(FormClosingEventArgs e)
		{
			m_fileHandler.ExitApplication();
			SaveAppSettings();

			base.OnFormClosing(e);
		}

		/*-------------------------------------------------------------------------------------------------------------
		** M E T H O D S
		**-----------------------------------------------------------------------------------------------------------*/

		/*-------------------------------------------------------------------------------------------------------------
		** LoadAppSettings
		** Load application's settings (Window's position, size, state). Set the known users for user access control.
		** Set recent files for filehandler.
		**-----------------------------------------------------------------------------------------------------------*/
		private void LoadAppSettings()
		{
			// Take over initial resizing
			this.StartPosition = FormStartPosition.Manual;

			// Right to left
			this.RightToLeft = Settings.Default.RightToLeft;
			switch (this.RightToLeft)
			{
				case RightToLeft.No:
					this.RightToLeftLayout = false;
					m_verticalRulerBar.Dock = DockStyle.Left;
					break;

				case RightToLeft.Yes:
					this.RightToLeftLayout = true;
					m_verticalRulerBar.Dock = DockStyle.Right;
					break;
			}

			// User management
			if (Settings.Default.KnownUsers != null)
			{
				m_UAC.KnownUsers.Set(Settings.Default.KnownUsers);
			}

			// Recent items
			m_fileHandler.RecentFiles = Settings.Default.RecentFiles;
			m_fileHandler.MaxRecentFiles = Settings.Default.RecentFilesMaxItemCount;
		}

		/*-------------------------------------------------------------------------------------------------------------
		** SaveAppSettings
		** Save application's settings (Window's position, size, state). Save the known users of user access control.
		** Save recent files of filehandler.
		**-----------------------------------------------------------------------------------------------------------*/
		private void SaveAppSettings()
		{
			Settings.Default.RecentFiles = m_fileHandler.RecentFiles;

			// Stores user list in application settings.
			// Clone user list and reset access settings before saving
			Settings.Default.KnownUsers = m_UAC.KnownUsers.ToList().
																		ConvertAll(ui => new UserInfo(ui) { AccessGranted = false });

			Settings.Default.Save();

		}

		/*-------------------------------------------------------------------------------------------------------------
		** FileNew
		** Create a new document and update the window's title.
		**-----------------------------------------------------------------------------------------------------------*/
		private void FileNew()
		{
			m_fileHandler.New();
			SetWindowTitle(m_fileHandler.DocumentTitle);
		}

		/*-------------------------------------------------------------------------------------------------------------
		** FileOpen
		** Open a document via file browser dialog.
		**-----------------------------------------------------------------------------------------------------------*/
		private void FileOpen()
		{
			m_fileHandler.Open();
		}

		/*-------------------------------------------------------------------------------------------------------------
		** FileSave
		** Save document.
		**-----------------------------------------------------------------------------------------------------------*/
		private void FileSave()
		{
			try
			{
				m_fileHandler.Save();
			}
			catch (Exception ex)
			{
				Utils.MessageBox.Show(this, ex.Message, Resources.MSG_SAVINGDOCUMENT_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		/*-------------------------------------------------------------------------------------------------------------
		** Print
		** Print document.
		**-----------------------------------------------------------------------------------------------------------*/
		private void Print()
		{
			textControl.Print(ProductName + " - " + m_fileHandler.DocumentTitle);
		}

		/*-------------------------------------------------------------------------------------------------------------
		** PrintPreview
		** Print preview.
		**-----------------------------------------------------------------------------------------------------------*/
		private void PrintPreview()
		{
			textControl.PrintPreview(ProductName + " - " + m_fileHandler.DocumentTitle);
		}

		/*-------------------------------------------------------------------------------------------------------------
		** SetWindowTitle
		** Set the window title. Show document's title and the document dirty state. 
		**-----------------------------------------------------------------------------------------------------------*/
		private void SetWindowTitle(string documentTitle, bool isDocumentDirty = false)
		{
			string asterisk = isDocumentDirty ? "*" : "";
			this.Text = string.Format("{0}{1} - {2}", documentTitle, asterisk, ProductName);
		}

		/*-------------------------------------------------------------------------------------------------------
		**	IsStandardVersion method
		** Validates whether the standard version of TX TextControl is used.
		**-----------------------------------------------------------------------------------------------------*/
		private bool IsStandardVersion()
		{
			try
			{
				textControl.ApplicationFields.GetItem();
			}
			catch (Exception)
			{
				return true;
			}

			return false;
		}

	} // class MainWindow

}