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

	/*------------------------------------------------------------------------------------------------
	** Partial Class MainWindow
	** Capsulates the event handling for FileHandler events.
	**----------------------------------------------------------------------------------------------*/
	public partial class MainWindow {

		/*------------------------------------------------------------------------------------------------
		** FileHandler_ShowMessageBox method
		** Show a WinForm's MessageBox if the FileHandler requests a messagebox.
		**----------------------------------------------------------------------------------------------*/
		void FileHandler_ShowMessageBox(object sender, FileHandling.ShowMessageBoxEventArgs e) {
			string caption = e.Caption ?? ProductName;
			DialogResult res
				 = Utils.MessageBox.Show(this, e.Text, caption, e.Button.ToWinFormsButton(), e.Icon.ToWinFormsIcon());
			e.DialogResult = res.ToFileHandlerDialogResult();
		}

		/*------------------------------------------------------------------------------------------------
		** FileHandler_DocumentDirtyChanged method
		** Update the window's title on change of the DocumentDirty Property because the dirty state
		** is part of this title.
		**----------------------------------------------------------------------------------------------*/
		void FileHandler_DocumentDirtyChanged(object sender, FileHandling.DocumentDirtyChangedEventArgs e) {
			SetWindowTitle(m_fileHandler.DocumentTitle, e.NewValue);
		}

		/*------------------------------------------------------------------------------------------------
		** FileHandler_PropertyChanged_CanSave method
		** Update the enable state of the toolbar's save button on change of CanSave property.
		**----------------------------------------------------------------------------------------------*/
		void FileHandler_PropertyChanged_CanSave(object sender, PropertyChangedEventArgs e) {
			switch (e.PropertyName) {
				case "CanSave":
					mnuFile_Save.Enabled = m_fileHandler.CanSave;
					mnuBtnSave.Enabled = m_fileHandler.CanSave;
					break;
			}
		}

		/*------------------------------------------------------------------------------------------------
		** FileHandler_DocumentFileNameChanged method
		** Update the window's title on change of the DocumentFileName Property because the document's
		** filename is part of this title.
		**----------------------------------------------------------------------------------------------*/
		void FileHandler_DocumentFileNameChanged(object sender, FileHandling.DocumentFileNameChangedEventArgs e) {
			SetWindowTitle(m_fileHandler.DocumentTitle, m_fileHandler.IsDocumentDirty);
		}

		/*------------------------------------------------------------------------------------------------
		** FileHandler_RecentFileListChanged method
		** Update the shown list of recent files in toolbar's filemenu by the the list of the FileHandler.
		**----------------------------------------------------------------------------------------------*/
		void FileHandler_RecentFileListChanged(object sender, EventArgs e) {
			UpdateToolbar_SetRecentItemsList(m_fileHandler.RecentFiles);
		}

		/*------------------------------------------------------------------------------------------------
		** FileHandler_RecentFileListChanged method
		** Forwards the FileHandler's request to the user by showing a dialog for getting the user's input.
		** This data will be stored in the event args for forwarding the user's input back to the FileHandler.
		**----------------------------------------------------------------------------------------------*/
		void FileHandler_UserInputRequested(object sender, FileHandling.UserInputRequestedEventArgs e) {
			var dlg = new UserPromptDialog(e.Caption, e.Label, e.Value)
			{
				ShowIcon = false,
				RightToLeft = this.RightToLeft,
				IsPassword = e.IsPasswordRequest
			};

			if (dlg.ShowDialog(this) == System.Windows.Forms.DialogResult.OK) {
				e.DialogResult = FileHandling.DialogResult.OK;
				e.Value = dlg.Value;
			}
		}
	}

	/*------------------------------------------------------------------------------------------------
	** Partial Class Extensions
	** Implements additional methods for converting the FileHandler's MessageBoxButton and
	** MessageBoxIcon, DialogResult Enumeration's value to a corresponding WinForms Enumeration's 
	** value.
	**----------------------------------------------------------------------------------------------*/
	public static partial class Extensions {

		/*------------------------------------------------------------------------------------------------
		** ToWinFormsButton method
		** Converts the FileHandling.MessageBoxButton to a System.Windows.Forms.MessageBoxButton value.
		**----------------------------------------------------------------------------------------------*/
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


		/*------------------------------------------------------------------------------------------------
		** ToWinFormsIcon method
		** Converts the FileHandling.MessageBoxIcon to a System.Windows.Forms.MessageBoxIcon value.
		**----------------------------------------------------------------------------------------------*/
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


		/*------------------------------------------------------------------------------------------------
		** ToFileHandlerDialogResult method
		** Converts the System.Windows.Forms.DialogResult value to FileHanlding.DialogResult.
		**----------------------------------------------------------------------------------------------*/
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
