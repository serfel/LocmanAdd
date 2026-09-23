/*-------------------------------------------------------------------------------------------------------------
** program:			TX Text Control Words
** description:	Implements a typical word processing application build up on the main features of 
**						TextControl's Components. 
**
** copyright:		© Text Control GmbH
**-----------------------------------------------------------------------------------------------------------*/
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace TX_Text_Control_Words {

	/*-------------------------------------------------------------------------------------------------------------
	** class MainWindow
	** Capsulates the handling of events thrown by the FileHandler. 
	**-----------------------------------------------------------------------------------------------------------*/
	public partial class MainWindow {

		/*-------------------------------------------------------------------------------------------------------------
		** FileHandler_ShowMessageBox
		** Show a dialog on request of the filehandler for showing a dialog.
		**-----------------------------------------------------------------------------------------------------------*/
		void FileHandler_ShowMessageBox(object sender, FileHandling.ShowMessageBoxEventArgs e) {
			// Show MessageBox based on the event args
			string caption = e.Caption ?? "Боцман";
			DialogResult res
				= Utils.MessageBox.Show(this, e.Text, caption, e.Button.ToWinFormsButton(), e.Icon.ToWinFormsIcon());
			e.DialogResult = res.ToFileHandlerDialogResult();
		}

		/*-------------------------------------------------------------------------------------------------------------
		** FileHandler_DocumentDirtyChanged
		** Update the window's title on change of the filehandler's dirty state.
		**-----------------------------------------------------------------------------------------------------------*/
		void FileHandler_DocumentDirtyChanged(object sender, FileHandling.DocumentDirtyChangedEventArgs e) {
			SetWindowTitle(m_fileHandler.DocumentTitle, e.NewValue);
		}

		/*-------------------------------------------------------------------------------------------------------------
		** FileHandler_PropertyChanged_SetButtonStates
		** Update the enabling of the save button on change of FileHandler's CanSave Property.
		**-----------------------------------------------------------------------------------------------------------*/
		void FileHandler_PropertyChanged_SetButtonStates(object sender, PropertyChangedEventArgs e) {
			switch (e.PropertyName) 
			{
				case "CanSave":
					m_btnAppMenu_TXITEM_Save.Enabled = !m_fileHandler.CanSave;
					m_btnAppMenu_TXITEM_Save.Enabled = m_fileHandler.CanSave;
					break;
			}
		}

		/*-------------------------------------------------------------------------------------------------------------
		** FileHandler_DocumentFileNameChanged
		** Update the window's title on change of the document's title.
		**-----------------------------------------------------------------------------------------------------------*/
		void FileHandler_DocumentFileNameChanged(object sender, FileHandling.DocumentFileNameChangedEventArgs e) 
		{
			SetWindowTitle(m_fileHandler.DocumentTitle, m_fileHandler.IsDocumentDirty);
		}


		/*-------------------------------------------------------------------------------------------------------------
		** FileHandler_RecentFileListChanged
		** Update the corresponding recent item list in the application menu on change of the collection of the
		** Filehandler.
		**-----------------------------------------------------------------------------------------------------------*/
		void FileHandler_RecentFileListChanged(object sender, EventArgs e)
		{
			SetRecentItemsList(m_fileHandler.RecentFiles);
		}


		/*-------------------------------------------------------------------------------------------------------------
		** FileHandler_UserInputRequested
		** Show a dialog for requesting an input from user and forward these values to EventArgs back to the filehandler.
		**-----------------------------------------------------------------------------------------------------------*/
		void FileHandler_UserInputRequested(object sender, FileHandling.UserInputRequestedEventArgs e) {
			// Ask user for password and set event args
			var dlg = new UserPromptDialog(e.Caption, e.Label, e.Value);
			dlg.RightToLeft = this.RightToLeft;
			dlg.IsPassword = e.IsPasswordRequest;
			if (dlg.ShowDialog(this) == System.Windows.Forms.DialogResult.OK) {
				e.DialogResult = FileHandling.DialogResult.OK;
				e.Value = dlg.Value;
			}
		}
	}

	/*-------------------------------------------------------------------------------------------------------------
	** ReportingTabExtensions2
	** Capsulates extensions for converting the FileHandler's MessageBox types to an correspong object 
	** of WinForms Framework.
	**-----------------------------------------------------------------------------------------------------------*/
	public static partial class ReportingTabExtensions2 {


		public static MessageBoxButtons ToWinFormsButton(this FileHandling.MessageBoxButton button) {
			switch (button) {
				case FileHandling.MessageBoxButton.OKCancel:
					return MessageBoxButtons.OKCancel;

				case FileHandling.MessageBoxButton.AbortRetryIgnore:
					return MessageBoxButtons.AbortRetryIgnore;

				case FileHandling.MessageBoxButton.YesNoCancel:
					return MessageBoxButtons.YesNoCancel;

				case FileHandling.MessageBoxButton.YesNo:
					return MessageBoxButtons.YesNo;

				case FileHandling.MessageBoxButton.RetryCancel:
					return MessageBoxButtons.RetryCancel;
			}
			return MessageBoxButtons.OK;
		}


		public static MessageBoxIcon ToWinFormsIcon(this FileHandling.MessageBoxIcon icon) {
			switch (icon) {
				case FileHandling.MessageBoxIcon.Error:
					return MessageBoxIcon.Error;

				case FileHandling.MessageBoxIcon.Question:
					return MessageBoxIcon.Question;

				case FileHandling.MessageBoxIcon.Exclamation:
					return MessageBoxIcon.Exclamation;

				case FileHandling.MessageBoxIcon.Information:
					return MessageBoxIcon.Information;
			}

			return MessageBoxIcon.None;
		}


		public static FileHandling.DialogResult ToFileHandlerDialogResult(this DialogResult res) {
			switch (res) {
				case DialogResult.Abort:
				case DialogResult.Cancel:
				case DialogResult.Ignore:
				case DialogResult.None:
					return FileHandling.DialogResult.Cancel;

				case DialogResult.No:
					return FileHandling.DialogResult.No;

				case DialogResult.Yes:
					return FileHandling.DialogResult.Yes;
			}

			return FileHandling.DialogResult.OK;
		}
	}
}
