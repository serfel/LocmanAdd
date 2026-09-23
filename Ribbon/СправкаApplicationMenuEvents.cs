/*-------------------------------------------------------------------------------------------------------------
** program:			TX Text Control Words
** description:	Implements a typical word processing application build up on the main features of 
**						TextControl's Components. 
**
** copyright:		© Text Control GmbH
**-----------------------------------------------------------------------------------------------------------*/
using System;
using System.Diagnostics;
using System.Drawing.Printing;
using System.IO;
using System.Reflection;
using TXTextControl;
using TXTextControl.Windows.Forms;
using TXTextControl.Windows.Forms.Ribbon;

namespace TX_Text_Control_Words {

	/*-------------------------------------------------------------------------------------------------------------
	** class MainWindow
	** Capsulates the EventHandler's of the applicaton menu.
	**-----------------------------------------------------------------------------------------------------------*/
	public partial class Справка
	{
		/*-------------------------------------------------------------------------------------------------------------
		** BtnAppMenu_New_Click
		** Create a new document in the same window.
		**-----------------------------------------------------------------------------------------------------------*/
		void BtnAppMenu_New_Click(object sender, EventArgs e) {
			m_fileHandler.New();
		}

		/*-------------------------------------------------------------------------------------------------------------
		** BtnAppMenu_Exit_Click
		** Initialize the closing of the application.
		**-----------------------------------------------------------------------------------------------------------*/
		void BtnAppMenu_Exit_Click(object sender, EventArgs e) {
			Close();
		}

		/*-------------------------------------------------------------------------------------------------------------
		** BtnAppMenu_About_Click
		** Show information about the application in a new dialog.
		**-----------------------------------------------------------------------------------------------------------*/
		void BtnAppMenu_About_Click(object sender, EventArgs e) {
			
		}

		/*-------------------------------------------------------------------------------------------------------------
		** BtnAppMenu_Options_Click
		** Show dialog for setting the application's options.
		**-----------------------------------------------------------------------------------------------------------*/
		void BtnAppMenu_Options_Click(object sender, EventArgs e) {
			var dlg = new OptionsDialog(m_textControl, m_fileHandler);
			dlg.RightToLeft = this.RightToLeft;
			dlg.ShowDialog(this);
		}

		/*-------------------------------------------------------------------------------------------------------------
		** BtnAppMenu_UserAdmin_Click
		** Show dialog for administrate users.
		**-----------------------------------------------------------------------------------------------------------*/
		void BtnAppMenu_UserAdmin_Click(object sender, EventArgs e) {
			m_UAC.ShowUserAdminDialog(this);
		}

		/*-------------------------------------------------------------------------------------------------------------
		** BtnAppMenu_UserAccess_Click
		** Show dialog for managing the user's accesspermissions.
		**-----------------------------------------------------------------------------------------------------------*/
		void BtnAppMenu_UserAccess_Click(object sender, EventArgs e) {
			m_UAC.ShowUserAccessDialog(this);
		}

		/*-------------------------------------------------------------------------------------------------------------
		** BtnAppMenu_SaveAs_ButtonClick
		** Show dialog for saving the document as file.
		**-----------------------------------------------------------------------------------------------------------*/
		void BtnAppMenu_SaveAs_Click(object sender, EventArgs e) {
			m_fileHandler.SaveAs();
		}

		/*-------------------------------------------------------------------------------------------------------------
		** BtnAppMenu_Save_Click
		** Save the document in current file otherwise opening a dialog for saving the document in a new file location.
		**-----------------------------------------------------------------------------------------------------------*/
		void BtnAppMenu_Save_Click(object sender, EventArgs e) 
		{
			if (this.OutPath != "")
			{
				string filename = System.Windows.Forms.Application.StartupPath + "\\Справки\\" + this.OutPath;
				if (!Directory.Exists(Path.GetDirectoryName(filename)))
					Directory.CreateDirectory(Path.GetDirectoryName(filename));
				m_fileHandler.Save(filename, StreamType.WordprocessingML);
			}
			else m_fileHandler.Save();
		}

		/*-------------------------------------------------------------------------------------------------------------
		** BtnAppMenu_Open_Click
		** Show dialog for opening a document.
		**-----------------------------------------------------------------------------------------------------------*/
		void BtnAppMenu_Open_Click(object sender, EventArgs e) {
			m_fileHandler.Open();
		}

		/*-------------------------------------------------------------------------------------------------------------
		** BtnOpenSampleTemplate_Click
		** Load a sample document which is specified by the RibbonButton's Tag-Property.
		**-----------------------------------------------------------------------------------------------------------*/
		void BtnOpenSampleTemplate_Click(object sender, EventArgs e) {
			string fileName = "";
			string exePath = Assembly.GetEntryAssembly().Location;
			string dir = Path.GetDirectoryName(exePath);

			var btn = sender as RibbonButton;
			if (btn == null) return;

			var tmplType = (SampleTemplateType)btn.Tag;

			switch (tmplType) {
				case SampleTemplateType.Invoice:
					fileName = dir + "\\..\\invoice.docx";
					break;

				case SampleTemplateType.PackingList:
					fileName = dir + "\\..\\shippinglabel.docx";
					break;

				case SampleTemplateType.ShippingLabel:
					fileName = dir + "\\..\\packinglist.docx";
					break;
			}
			if (string.IsNullOrEmpty(fileName)) return;

			// Open sample document in new window
			m_fileHandler.Open(fileName);
		}

		/*-------------------------------------------------------------------------------------------------------------
		** BtnRecentItem_Click
		** Open recent loaded document by the filename which is stored in the RibbonButton's Tag Property.
		**-----------------------------------------------------------------------------------------------------------*/
		void BtnRecentItem_Click(object sender, EventArgs e) {
			// Open corresponding recent item
			var btn = sender as RibbonButton;
			if (btn == null) return;
			string path = (string)btn.Tag;
			m_fileHandler.OpenRecentFile(path);
		}

		/*-------------------------------------------------------------------------------------------------------------
		** BtnAppMenu_TXITEM_DocumentSettings_Click
		** Toggle the left sidebar and display the document settings.
		**-----------------------------------------------------------------------------------------------------------*/
		private void BtnAppMenu_TXITEM_DocumentSettings_Click(object sender, EventArgs e)
		{
			if (m_btnAppMenu_TXITEM_DocumentSettings.Checked)
			{
				m_verticalLeftSidebar.IsShown = true;
				m_verticalLeftSidebar.ContentLayout = Sidebar.SidebarContentLayout.DocumentSettings;
			}
			else
			{
				m_verticalLeftSidebar.IsShown = false;
			}
		}

		/*-------------------------------------------------------------------------------------------------------------
		** BtnAppMenu_Print_ButtonClick
		** Print document.
		**-----------------------------------------------------------------------------------------------------------*/
		void BtnAppMenu_Print_ButtonClick(object sender, EventArgs e) {
			Print();
		}

		/*-------------------------------------------------------------------------------------------------------------
		** BtnPrintPreview_Click
		** Print preview.
		**-----------------------------------------------------------------------------------------------------------*/
		void BtnPrintPreview_Click(object sender, EventArgs e) {
			PrintPreview();
		}

		/*-------------------------------------------------------------------------------------------------------------
		** BtnPrintQuick_Click
		** Print document immediately.
		**-----------------------------------------------------------------------------------------------------------*/
		void BtnPrintQuick_Click(object sender, EventArgs e) {
			PrintQuick();
		}

		/*-------------------------------------------------------------------------------------------------------------
		** Print
		** Print document.
		**-----------------------------------------------------------------------------------------------------------*/
		private bool m_bIsInPrintHandler = false;
		private void Print() {
			if (m_bIsInPrintHandler) return;
			m_bIsInPrintHandler = true;
			m_textControl.Print(m_fileHandler.DocumentTitle);
			m_bIsInPrintHandler = false;
		}

		/*-------------------------------------------------------------------------------------------------------------
		** PrintPreview
		** Print a document with a specific title.
		**-----------------------------------------------------------------------------------------------------------*/
		private void PrintPreview() {
			m_textControl.PrintPreview(m_fileHandler.DocumentTitle);
		}

		/*-------------------------------------------------------------------------------------------------------------
		** PrintQuick
		** Immadetely print one copy of the document.
		**-----------------------------------------------------------------------------------------------------------*/
		private void PrintQuick() {
			m_textControl.Print(new PrintDocument()
			{
				PrinterSettings = new PrinterSettings()
				{
					FromPage = 1,
					ToPage = m_textControl.Pages,
					Copies = 1,
					Collate = true,
					PrintFileName = m_fileHandler.DocumentTitle
				},
			});
		}
	}
}