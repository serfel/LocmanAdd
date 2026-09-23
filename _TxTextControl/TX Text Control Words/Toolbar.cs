/*-------------------------------------------------------------------------------------------------------------
** program:			TX Text Control Words
** description:	Implements a typical word processing application build up on the main features of TextControl's Components. 
**
** copyright:		© Text Control GmbH
**-----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TX_Text_Control_Words.Properties;
using TXTextControl;
using TXTextControl.Windows.Forms;

namespace TX_Text_Control_Words {

	/*-------------------------------------------------------------------------------------------------------------
	** partial class MainWindow
	** Capsulates all functionalities related to the MainWindow's toolbar.
	**-----------------------------------------------------------------------------------------------------------*/
	partial class MainWindow {

		/*-------------------------------------------------------------------------------------------------------------
		** M E T H O D S
		**-----------------------------------------------------------------------------------------------------------*/

		/*-------------------------------------------------------------------------------------------------------------
		** LocalizeToolbar method
		** Localize the toolbar by setting foreach ToolStrip MenuItem's text by the application's resource.
		** The resource's name is the menuitem's name concatenated with "_TEXT".
		**-----------------------------------------------------------------------------------------------------------*/
		private void LocalizeToolbar() {

			// Localize dropdown menu.
			foreach (ToolStripMenuItem item in menuStrip.Items) {
				ActionOnBottomUp(item, (x) => {
					string resNameOfText;  // Resource's name for getting the text.

					// Set Text
					if (x.Name != "") { // Ignore unnamed items because the name is the prefix of resource's id.

						resNameOfText = x.Name.ToUpper() + "_" + "TEXT";

						try {
							string text = Properties.Resources.ResourceManager.GetString(resNameOfText);
							if (text != null) { x.Text = text; }
						}
						catch { Debug.WriteLine(String.Format("Resource not found by {0}", resNameOfText)); }
					}
				});
			}
		}


		/*-------------------------------------------------------------------------------------------------------------
		** UpdateToolbarImages method
		** Update toolbar's images by using the menu item's tag which specifies the image's source.
		**		Item's tag prefixed with 
		**			- 'TXITEM_' specifies to set the image by using TX TextControl's ImageProvider.
		**			- 'TXIMAGE_' specifies to set the image by using the embedded resources.
		**-----------------------------------------------------------------------------------------------------------*/
		private void UpdateToolbarImages()
		{
			foreach (ToolStripMenuItem item in menuStrip.Items)
			{
				ActionOnBottomUp(item, (x) =>	x.UpdateImage(menuStrip.DeviceDpi));
			}
		}

		/*-------------------------------------------------------------------------------------------------------------
		** ActionOnBottomUp method
		** Traverse the item's DropDown-Items and execute onSubItemAction from bottom to top.
		**-----------------------------------------------------------------------------------------------------------*/
		private void ActionOnBottomUp(ToolStripMenuItem item, Action<ToolStripMenuItem> onSubItemAction) {
			foreach (var subitem in item.DropDownItems) {
				if (subitem.GetType() == typeof(ToolStripMenuItem)) { // Filter the collection because items like Separators
					ToolStripMenuItem toolStripMenuSubItem = (ToolStripMenuItem)subitem;
					// Step down
					ActionOnBottomUp(toolStripMenuSubItem, onSubItemAction);
				}
			}
			// Execute
			onSubItemAction(item);
		}

		/*-------------------------------------------------------------------------------------------------------------
		** UpdateToolbar_Format_List method
		** Update enable states of submenuitems (Format->List).
		**-----------------------------------------------------------------------------------------------------------*/
		private void UpdateToolbar_Format_List() {
			// Uncheck all list items
			foreach (var obj in mnuFormat_List.DropDownItems) {
				var item = obj as ToolStripMenuItem;
				if (item == null) continue;

				item.Checked = false;
			}

			switch (textControl.Selection.ListFormat.Type) {
				case TXTextControl.ListType.Bulleted:
					mnuFormat_List_Bullets.Checked = true;
					return;

				case TXTextControl.ListType.None: return;
			}

			switch (textControl.Selection.ListFormat.NumberFormat) {
				case TXTextControl.NumFormat.ArabicNumbers:
					mnuFormat_List_ArabicNumbers.Checked = true;
					break;

				case TXTextControl.NumFormat.CapitalLetters:
					mnuFormat_List_CapitalLetters.Checked = true;
					break;

				case TXTextControl.NumFormat.Letters:
					mnuFormat_List_Letters.Checked = true;
					break;

				case TXTextControl.NumFormat.RomanNumbers:
					mnuFormat_List_RomanNumbers.Checked = true;
					break;

				case TXTextControl.NumFormat.SmallRomanNumbers:
					mnuFormat_List_SmallRomanNumbers.Checked = true;
					break;
			}
		}//CheckListMenuItem

		/*-------------------------------------------------------------------------------------------------------------
		** UpdateToolbar_SetRecentItemsList method
		** Sets the "File->Recent File"'s submenu by using the passend list of recent files.
		** Adds foreach recent file a menuitem for opening this file. Add also a menuitem for clearing the list of
		** recent files.
		**-----------------------------------------------------------------------------------------------------------*/
		private void UpdateToolbar_SetRecentItemsList(System.Collections.Specialized.StringCollection recentItems) {
			// Clear current menu
			mnuFile_RecentFiles.DropDownItems.Clear();

			// Remove not existing files
			foreach (string file in m_fileHandler.RecentFiles) {
				if (!System.IO.File.Exists(file)) {
					m_fileHandler.RecentFiles.Remove(file);
				}
			}

			// Setup Recent files menu
			foreach (string fileName in recentItems) {
				ToolStripMenuItem mnuItm = new ToolStripMenuItem();
				mnuItm.Text = System.IO.Path.GetFileName(fileName);
				mnuItm.Tag = fileName;
				mnuItm.Click += (sender, e) => {
					// Open recent file by using the filehandler.
					ToolStripMenuItem mnuItem_RecentFile = sender as ToolStripMenuItem;
					m_fileHandler.OpenRecentFile((string)mnuItem_RecentFile.Tag);
				};

				mnuFile_RecentFiles.DropDownItems.Add(mnuItm);
			}

			// Insert Clear menu entry
			if (mnuFile_RecentFiles.DropDownItems.Count > 0) {
				mnuFile_RecentFiles.Enabled = true;

				// Add Separator
				mnuFile_RecentFiles.DropDownItems.Add(new ToolStripSeparator());

				// Add MenuItem for clearing filehandler's recentfiles.
				ToolStripMenuItem clearListItm = new ToolStripMenuItem();
				clearListItm.Text = Properties.Resources.MNUFILE_RECENTFILES_CLEAR_TEXT;
				clearListItm.Click += (sender, e) => {
					// Clear filehandler's recentfile list.
					while (m_fileHandler.RecentFiles.Count > 0) {
						m_fileHandler.RemoveRecentFile(m_fileHandler.RecentFiles[0]);
					}
				};

				mnuFile_RecentFiles.DropDownItems.Add(clearListItm);
			}
			else {
				mnuFile_RecentFiles.Enabled = false;
			}
		}//SetRecentItemsList

		/*-------------------------------------------------------------------------------------------------------------
		** E V E N T H A N D L E R
		**-----------------------------------------------------------------------------------------------------------*/

		/*-------------------------------------------------------------------------------------------------------------
		** FILE MENU - EVENTHANDLER
		**-----------------------------------------------------------------------------------------------------------*/

		/*-------------------------------------------------------------------------------------------------------------
		** mnuFile_DropDownOpening method
		** Update the enable states of the file menu.
		**-----------------------------------------------------------------------------------------------------------*/
		private void mnuFile_DropDownOpening(object sender, EventArgs e) {
			mnuFile_PageSetup.Enabled = textControl.CanEdit;
			mnuFile_Print.Enabled = textControl.CanPrint;
			mnuFile_PrintPreview.Enabled = textControl.CanPrint;
		}

		/*-------------------------------------------------------------------------------------------------------------
		** mnuFile_Open_Click method
		** Open file.
		**-----------------------------------------------------------------------------------------------------------*/
		private void mnuFile_Open_Click(object sender, EventArgs e) {
			FileOpen();
		}

		/*-------------------------------------------------------------------------------------------------------------
		** mnuFile_New_Click method
		** Create a new document.
		**-----------------------------------------------------------------------------------------------------------*/
		private void mnuFile_New_Click(object sender, EventArgs e) {
			m_fileHandler.New();
		}

		/*-------------------------------------------------------------------------------------------------------------
		** mnuFile_Save_Click method
		** Save the TextControl's content in file.
		**-----------------------------------------------------------------------------------------------------------*/
		private void mnuFile_Save_Click(object sender, System.EventArgs e) {
			m_fileHandler.Save();
		}

		/*-------------------------------------------------------------------------------------------------------------
		** mnuFile_SaveAs_Click method
		** Save the TextControl's content in a new file.
		**-----------------------------------------------------------------------------------------------------------*/
		private void mnuFile_SaveAs_Click(object sender, System.EventArgs e) {
			m_fileHandler.SaveAs();
		}

		/*-------------------------------------------------------------------------------------------------------------
		** mnuFile_PrintPreview_Click method
		** Show a printpreview.
		**-----------------------------------------------------------------------------------------------------------*/
		private void mnuFile_PrintPreview_Click(object sender, System.EventArgs e) {
			PrintPreview();
		}

		/*-------------------------------------------------------------------------------------------------------------
		** mnuFile_Print_Click method
		** Print the document.
		**-----------------------------------------------------------------------------------------------------------*/
		private void mnuFile_Print_Click(object sender, System.EventArgs e) {
			Print();
		}

		/*-------------------------------------------------------------------------------------------------------------
		** mnuFile_Exit_Click method
		** Initialize the closing of the application.
		**-----------------------------------------------------------------------------------------------------------*/
		private void mnuFile_Exit_Click(object sender, EventArgs e) {
			Close();
		}

		/*-------------------------------------------------------------------------------------------------------------
		** mnuFile_Export_Click method
		** Save the document as PDF.
		**-----------------------------------------------------------------------------------------------------------*/
		private void mnuFile_Export_Click(object sender, System.EventArgs e) {
			try {
				// Force exception in standard version:
				textControl.Sections.GetItem();

				var saveSettings = new SaveSettings
				{
					CssFileName = m_fileHandler.CssFileName,
					CssSaveMode = m_fileHandler.CssSaveMode,
					UserPassword = m_fileHandler.PDFUserPassword
				};

				if (m_fileHandler.PDFSignature != null) saveSettings.DigitalSignature = m_fileHandler.PDFSignature;

				var sfd = new SaveFileDialog()
				{
					Title = Resources.EXPORTDLG_TITLE,
					Filter = "Adobe PDF (*.pdf)|*.pdf|Adobe PDF/A (*.pdf)|*.pdf"
				};

				if (sfd.ShowDialog(this) == System.Windows.Forms.DialogResult.OK) {
					switch (sfd.FilterIndex) {
						case 1:
							textControl.Save(sfd.FileName, TXTextControl.StreamType.AdobePDF);
							break;
						case 2:
							textControl.Save(sfd.FileName, TXTextControl.StreamType.AdobePDFA);
							break;
					}
				}
			}
			catch (Exception ex) {
				Utils.MessageBox.Show(this, ex.Message, Properties.Resources.MSG_EXPORTDOCUMENT_TITLE);
			}
		}

		/*-------------------------------------------------------------------------------------------------------------
		** mnuFile_PageSetup_Click method
		** Show a dialog for the page's setup.
		**-----------------------------------------------------------------------------------------------------------*/
		private void mnuFile_PageSetup_Click(object sender, System.EventArgs e) {
			PageSetup.ShowDialog(textControl, m_fileHandler);
		}

		/*-------------------------------------------------------------------------------------------------------------
		** mnuFile_UserAccess_Click method
		** Show a dialog for handling the access permissions of application's user.
		**-----------------------------------------------------------------------------------------------------------*/
		private void mnuFile_UserAccess_Click(object sender, EventArgs e) {
			m_UAC.ShowUserAccessDialog(this);
		}

		/*-------------------------------------------------------------------------------------------------------------
		** mnuFile_UserManagement_Click method
		** Show a dialog for removing, adding, editing users.
		**-----------------------------------------------------------------------------------------------------------*/
		private void mnuFile_UserManagement_Click(object sender, EventArgs e) {
			m_UAC.ShowUserAdminDialog(this);
		}

		/*-------------------------------------------------------------------------------------------------------------
		** mnuFile_Options_Click method
		** Show a dialog for setting the application's options.
		**-----------------------------------------------------------------------------------------------------------*/
		private void mnuFile_Options_Click(object sender, EventArgs e) {
			OptionsDialog dlgOptions = new OptionsDialog(textControl, m_fileHandler)
			{
				RightToLeft = textControl.RightToLeft
			};
			dlgOptions.ShowDialog(this);
		}

		/*-------------------------------------------------------------------------------------------------------------
		** EDIT MENU - EVENTHANDLER
		**-----------------------------------------------------------------------------------------------------------*/

		/*-------------------------------------------------------------------------------------------------------------
		** mnuEdit_DropDownOpening method
		** Update enable state of the menuitems.
		**-----------------------------------------------------------------------------------------------------------*/
		private void mnuEdit_DropDownOpening(object sender, System.EventArgs e) {
			mnuEdit_Undo.Enabled = textControl.CanUndo;
			mnuEdit_Redo.Enabled = textControl.CanRedo;
			mnuEdit_Cut.Enabled = textControl.CanCopy && textControl.CanEdit;
			mnuEdit_Copy.Enabled = textControl.CanCopy;
			mnuEdit_Paste.Enabled = textControl.CanPaste;
			mnuEdit_Replace.Enabled = textControl.CanEdit;
			mnuEdit_Undo.Text = Properties.Resources.MNUEDIT_UNDO_TEXT + " " + textControl.UndoActionName;
			mnuEdit_Redo.Text = Properties.Resources.MNUEDIT_REDO_TEXT + " " + textControl.RedoActionName;
			mnuEdit_Permissions.Enabled = textControl.CanEdit;

			mnuEdit_ProtectDocument.Checked = (textControl.EditMode == TXTextControl.EditMode.ReadAndSelect);

			if (textControl.CanEdit) {
				// Hypertext links are not available in the Standard version. Accessing them
				// would throw an exception if this sample program is used with a Standard version
				// of Text Control.
				try {
					mnuEdit_Hyperlink.Enabled = (textControl.HypertextLinks.GetItem() != null) || (textControl.DocumentLinks.GetItem() != null);
					mnuEdit_Target.Enabled = (textControl.DocumentTargets.GetItem() != null);
					mnuEdit_TableOfContents.Enabled = textControl.TablesOfContents.GetItem() != null;
				}
				catch { }
			}
			else {
				mnuEdit_Hyperlink.Enabled = false;
				mnuEdit_Target.Enabled = false;
				mnuEdit_TableOfContents.Enabled = false;
			}

			mnuEdit_Reviewing.Enabled = textControl.CanEdit;
		}

		/*-------------------------------------------------------------------------------------------------------------
		** mnuEdit_Undo_Click method
		** Undo the last TextControl action.
		**-----------------------------------------------------------------------------------------------------------*/
		private void mnuEdit_Undo_Click(object sender, System.EventArgs e) {
			textControl.Undo();
		}

		/*-------------------------------------------------------------------------------------------------------------
		** mnuEdit_Redo_Click method
		** Redo the last TextControl action.
		**-----------------------------------------------------------------------------------------------------------*/
		private void mnuEdit_Redo_Click(object sender, System.EventArgs e) {
			textControl.Redo();
		}

		/*-------------------------------------------------------------------------------------------------------------
		** mnuEdit_Cut_Click method
		** Cut TextControl's selection and copy to clipboard.
		**-----------------------------------------------------------------------------------------------------------*/
		private void mnuEdit_Cut_Click(object sender, System.EventArgs e) {
			textControl.Cut();
		}

		/*-------------------------------------------------------------------------------------------------------------
		** mnuEdit_Copy_Click method
		** Copy TextControl's selection to clipboard.
		**-----------------------------------------------------------------------------------------------------------*/
		private void mnuEdit_Copy_Click(object sender, System.EventArgs e) {
			textControl.Copy();
		}

		/*-------------------------------------------------------------------------------------------------------------
		** mnuEdit_Paste_Click method
		** Paste clipboard's data in TextControl.
		**-----------------------------------------------------------------------------------------------------------*/
		private void mnuEdit_Paste_Click(object sender, System.EventArgs e) {
			textControl.Paste();
		}

		/*-------------------------------------------------------------------------------------------------------------
		** mnuEdit_SelectAll_Click method
		** Select all content of TextControl.
		**-----------------------------------------------------------------------------------------------------------*/
		private void mnuEdit_SelectAll_Click(object sender, System.EventArgs e) {
			textControl.SelectAll();
		}

		/*-------------------------------------------------------------------------------------------------------------
		** mnuEdit_Find_Click method
		** Open TextControl's find dialog.
		**-----------------------------------------------------------------------------------------------------------*/
		private void mnuEdit_Find_Click(object sender, System.EventArgs e) {
			textControl.Find();
		}

		/*-------------------------------------------------------------------------------------------------------------
		** mnuEdit_Replace_Click method
		** Replace selection with clipboard's data.
		**-----------------------------------------------------------------------------------------------------------*/
		private void mnuEdit_Replace_Click(object sender, System.EventArgs e) {
			textControl.Replace();
		}

		/*-------------------------------------------------------------------------------------------------------------
		** mnuEdit_Hyperlink_Click method
		** Show TextControl's build-in dialog for editing and adding a hyperlink.
		**-----------------------------------------------------------------------------------------------------------*/
		private void mnuEdit_Hyperlink_Click(object sender, System.EventArgs e) {
			var dlg = new TXTextControl.HyperlinkDialog(textControl);
			if (dlg.ShowDialog(this) == DialogResult.OK) m_fileHandler.IsDocumentDirty = true;
		}

		/*-------------------------------------------------------------------------------------------------------------
		** mnuEdit_Target_Click method
		** Show dialog for editing a DocumentTarget's name
		**-----------------------------------------------------------------------------------------------------------*/
		private void mnuEdit_Target_Click(object sender, System.EventArgs e) {
			var dlg = new BookmarkDialog(textControl)
			{
				Owner = this,
				StartPosition = FormStartPosition.CenterParent
			};

			if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK) m_fileHandler.IsDocumentDirty = true;
		}

		/*-------------------------------------------------------------------------------------------------------------
		** mnuEdit_TableOfContents_Edit_Click method
		** Show dialog for editing the table of content at the current input position.
		**-----------------------------------------------------------------------------------------------------------*/
		private void mnuEdit_TableOfContents_Edit_Click(object sender, EventArgs e) {
			textControl.TableOfContentsDialog();
		}

		/*-------------------------------------------------------------------------------------------------------------
		** mnuEdit_TableOfContents_Delete_Click method
		** Deletes the table of content at the current input position.
		**-----------------------------------------------------------------------------------------------------------*/
		private void mnuEdit_TableOfContents_Delete_Click(object sender, EventArgs e) {
			var toc = textControl.TablesOfContents.GetItem();
			if (toc != null) {
				textControl.TablesOfContents.Remove(toc);
			}
		}

		/*-------------------------------------------------------------------------------------------------------------
		** mnuEdit_TableOfContents_Update_Click method
		** Updates the table of content at the current input position.
		**-----------------------------------------------------------------------------------------------------------*/
		private void mnuEdit_TableOfContents_Update_Click(object sender, EventArgs e) {
			var toc = textControl.TablesOfContents.GetItem();
			if (toc != null) {
				toc.Update();
			}
		}


		/*-------------------------------------------------------------------------------------------------------------
		** mnuEdit_ProtectDocument_Click method
		** Un-/Protect the document by setting TextControl's EditMode.
		**-----------------------------------------------------------------------------------------------------------*/
		private void mnuEdit_ProtectDocument_Click(object sender, EventArgs e) {
			if (mnuEdit_ProtectDocument.Checked) {
				textControl.EditMode = TXTextControl.EditMode.Edit;
			}
			else {
				textControl.EditMode = (TXTextControl.EditMode.ReadAndSelect | TXTextControl.EditMode.UsePassword);
			}
		}

		/*-------------------------------------------------------------------------------------------------------------
		** EDIT MENU - PERMISSIONS - EVENTHANDLER
		**-----------------------------------------------------------------------------------------------------------*/

		/*-------------------------------------------------------------------------------------------------------------
		** mnuEdit_Permissions_DropDownOpening method
		** Enable/Disable sub menu items.
		**-----------------------------------------------------------------------------------------------------------*/
		private void mnuEdit_Permissions_DropDownOpening(object sender, EventArgs e) {
			mnuEdit_Permissions_AllowCopy.Checked = textControl.DocumentPermissions.AllowCopy;
			mnuEdit_Permissions_AllowFormatting.Checked = textControl.DocumentPermissions.AllowFormatting;
			mnuEdit_Permissions_AllowFormattingStyles.Checked = textControl.DocumentPermissions.AllowFormattingStyles;
			mnuEdit_Permissions_AllowPrinting.Checked = textControl.DocumentPermissions.AllowPrinting;
			mnuEdit_Permissions_ReadOnly.Checked = textControl.DocumentPermissions.ReadOnly;
			mnuEdit_Permissions_AllowEditingFormFields.Checked = textControl.DocumentPermissions.AllowEditingFormFields;
		}

		/*-------------------------------------------------------------------------------------------------------------
		** mnuEdit_Permissions_ReadOnly_Click method
		** Switch the readonly permission.
		**-----------------------------------------------------------------------------------------------------------*/
		private void mnuEdit_Permissions_ReadOnly_Click(object sender, EventArgs e) {
			textControl.DocumentPermissions.ReadOnly = !mnuEdit_Permissions_ReadOnly.Checked;
		}

		/*-------------------------------------------------------------------------------------------------------------
		** mnuEdit_Permissions_AllowCopy_Click method
		** Switch the copy permission.
		**-----------------------------------------------------------------------------------------------------------*/
		private void mnuEdit_Permissions_AllowCopy_Click(object sender, EventArgs e) {
			textControl.DocumentPermissions.AllowCopy = !mnuEdit_Permissions_AllowCopy.Checked;
		}

		/*-------------------------------------------------------------------------------------------------------------
		** mnuEdit_Permissions_AllowFormatting_Click method
		** Switch the permission to format the document's content.
		**-----------------------------------------------------------------------------------------------------------*/
		private void mnuEdit_Permissions_AllowFormatting_Click(object sender, EventArgs e) {
			textControl.DocumentPermissions.AllowFormatting = !mnuEdit_Permissions_AllowFormatting.Checked;
		}

		/*-------------------------------------------------------------------------------------------------------------
		** mnuEdit_Permissions_AllowFormattingStyles_Click method
		** Switch the permission to set formatting styles.
		**-----------------------------------------------------------------------------------------------------------*/
		private void mnuEdit_Permissions_AllowFormattingStyles_Click(object sender, EventArgs e) {
			textControl.DocumentPermissions.AllowFormattingStyles = !mnuEdit_Permissions_AllowFormattingStyles.Checked;
		}

		/*-------------------------------------------------------------------------------------------------------------
		** mnuEdit_Permissions_AllowPrinting_Click method
		** Switch the permission for printing.
		**-----------------------------------------------------------------------------------------------------------*/
		private void mnuEdit_Permissions_AllowPrinting_Click(object sender, EventArgs e) {
			textControl.DocumentPermissions.AllowPrinting = !mnuEdit_Permissions_AllowPrinting.Checked;
		}

		/*-------------------------------------------------------------------------------------------------------------
		** mnuEdit_Permissions_AllowPrinting_Click method
		** Switch the permission for allowing the editing of formfields.
		**-----------------------------------------------------------------------------------------------------------*/
		private void mnuEdit_Permissions_AllowEditingFormFields_Click(object sender, EventArgs e) {
			textControl.DocumentPermissions.AllowEditingFormFields = !textControl.DocumentPermissions.AllowEditingFormFields;
		}


		/*-------------------------------------------------------------------------------------------------------------
		** EDIT MENU - REVIEWING - EVENTHANDLER
		**-----------------------------------------------------------------------------------------------------------*/

		/*-------------------------------------------------------------------------------------------------------------
		** mnuEdit_Reviewing_DropDownOpening method
		** Update the items of the reviewing menu. A reviewing of changes is not possible if none change is available.
		**-----------------------------------------------------------------------------------------------------------*/
		private void mnuEdit_Reviewing_DropDownOpening(object sender, EventArgs e) {
			try {
				mnuEdit_Reviewing_ReviewChanges.Enabled = textControl.TrackedChanges.Count > 0;
				mnuEdit_Reviewing_TrackChanges.Checked = textControl.IsTrackChangesEnabled;
			}
			catch (TXTextControl.LicenseLevelException) { }
		}

		/*-------------------------------------------------------------------------------------------------------------
		** mnuEdit_Reviewing_TrackChanges_CheckedChanged method
		** Enable/Disable the tracking of changes.
		**-----------------------------------------------------------------------------------------------------------*/
		private void mnuEdit_Reviewing_TrackChanges_CheckedChanged(object sender, EventArgs e) {
			textControl.IsTrackChangesEnabled = ((ToolStripMenuItem)sender).Checked;
		}

		/*-------------------------------------------------------------------------------------------------------------
		** mnuEdit_Reviewing_ReviewChanges_Click method
		** Shows a dialog for reviewing the tracked changes.
		**-----------------------------------------------------------------------------------------------------------*/
		private void mnuEdit_Reviewing_ReviewChanges_Click(object sender, EventArgs e) {
			new TrackedChangesDialog(textControl.TrackedChanges, textControl.UserNames) { RightToLeft = this.RightToLeft }.ShowDialog(this);
		}

		/*-------------------------------------------------------------------------------------------------------------
		** VIEW  MENU - EVENTHANDLER
		**-----------------------------------------------------------------------------------------------------------*/

		/*-------------------------------------------------------------------------------------------------------------
		** mnuView_DropDownOpening method
		** Update button's check and enable state.
		**-----------------------------------------------------------------------------------------------------------*/
		private void mnuView_DropDownOpening(object sender, System.EventArgs e) {
			mnuView_Draft.Checked = (textControl.ViewMode == TXTextControl.ViewMode.Normal);
			mnuView_PageLayout.Checked = (textControl.ViewMode == TXTextControl.ViewMode.PageView);
			mnuView_Toolbar.Checked = toolStrip.Visible;
			mnuView_ButtonBar.Checked = m_buttonBar.Visible;
			mnuView_StatusBar.Checked = m_statusBar.Visible;
			mnuView_HorizontalRuler.Checked = m_horizontalRulerBar.Visible;
			mnuView_VerticalRuler.Checked = m_verticalRulerBar.Visible;
			mnuView_HeadersAndFooters.Enabled = (textControl.ViewMode == TXTextControl.ViewMode.PageView);

			mnuView_TextFrameMarkerLines.Checked = textControl.TextFrameMarkerLines;
			mnuView_DocumentTargetMarkers.Checked = textControl.DocumentTargetMarkers;
			mnuView_DrawingMarkerLines.Checked = textControl.DrawingMarkerLines;

			mnuView_FormLayout.Checked = IsFormLayoutRightToLeft();
		}

		/*-------------------------------------------------------------------------------------------------------------
		** mnuView_Draft_Click method
		** Display document as draft.
		**-----------------------------------------------------------------------------------------------------------*/
		private void mnuView_Draft_Click(object sender, System.EventArgs e) {
			textControl.ViewMode = TXTextControl.ViewMode.Normal;
		}

		/*-------------------------------------------------------------------------------------------------------------
		** mnuView_PageLayout_Click method
		** Display document in pagelayout.
		**-----------------------------------------------------------------------------------------------------------*/
		private void mnuView_PageLayout_Click(object sender, System.EventArgs e) {
			textControl.ViewMode = TXTextControl.ViewMode.PageView;
		}

		/*-------------------------------------------------------------------------------------------------------------
		** mnuView_Toolbar_Click method
		** Show/hide toolstrip.
		**-----------------------------------------------------------------------------------------------------------*/
		private void mnuView_Toolbar_Click(object sender, System.EventArgs e) {
			toolStrip.Visible = !toolStrip.Visible;
		}

		/*-------------------------------------------------------------------------------------------------------------
		** mnuView_ButtonBar_Click method
		** Show/hide buttonbar.
		**-----------------------------------------------------------------------------------------------------------*/
		private void mnuView_ButtonBar_Click(object sender, System.EventArgs e) {
			m_buttonBar.Visible = !m_buttonBar.Visible;
		}

		/*-------------------------------------------------------------------------------------------------------------
		** mnuView_StatusBar_Click method
		** Show/Hide statusbar.
		**-----------------------------------------------------------------------------------------------------------*/
		private void mnuView_StatusBar_Click(object sender, System.EventArgs e) {
			m_statusBar.Visible = !m_statusBar.Visible;
		}

		/*-------------------------------------------------------------------------------------------------------------
		** mnuView_HorizontalRuler_Click method
		** Show/Hide horizontal ruler.
		**-----------------------------------------------------------------------------------------------------------*/
		private void mnuView_HorizontalRuler_Click(object sender, System.EventArgs e) {
			m_horizontalRulerBar.Visible = !m_horizontalRulerBar.Visible;
		}

		/*-------------------------------------------------------------------------------------------------------------
		** mnuView_VerticalRuler_Click method
		** Show/Hide vertically ruler.
		**-----------------------------------------------------------------------------------------------------------*/
		private void mnuView_VerticalRuler_Click(object sender, System.EventArgs e) {
			m_verticalRulerBar.Visible = !m_verticalRulerBar.Visible;
		}

		/*-------------------------------------------------------------------------------------------------------------
		** mnuView_Zoom_DropDownOpening method
		** Update the zoom menu.
		**-----------------------------------------------------------------------------------------------------------*/
		private void mnuView_Zoom_DropDownOpening(object sender, EventArgs e) {
			mnuView_Zoom_25.Checked = (textControl.ZoomFactor == 25);
			mnuView_Zoom_50.Checked = (textControl.ZoomFactor == 50);
			mnuView_Zoom_75.Checked = (textControl.ZoomFactor == 75);
			mnuView_Zoom_100.Checked = (textControl.ZoomFactor == 100);
			mnuView_Zoom_150.Checked = (textControl.ZoomFactor == 150);
			mnuView_Zoom_200.Checked = (textControl.ZoomFactor == 200);
			mnuView_Zoom_300.Checked = (textControl.ZoomFactor == 300);
		}

		/*-------------------------------------------------------------------------------------------------------------
		** mnuView_Zoom_25_Click method
		** Set zoomfactor to 25 percentage.
		**-----------------------------------------------------------------------------------------------------------*/
		private void mnuView_Zoom_25_Click(object sender, System.EventArgs e) {
			textControl.ZoomFactor = 25;
		}

		/*-------------------------------------------------------------------------------------------------------------
		** mnuView_Zoom_50_Click method
		** Set zoomfactor to 50 percentage.
		**-----------------------------------------------------------------------------------------------------------*/
		private void mnuView_Zoom_50_Click(object sender, System.EventArgs e) {
			textControl.ZoomFactor = 50;
		}

		/*-------------------------------------------------------------------------------------------------------------
		** mnuView_Zoom_75_Click method
		** Set zoomfactor to 75 percentage.
		**-----------------------------------------------------------------------------------------------------------*/
		private void mnuView_Zoom_75_Click(object sender, System.EventArgs e) {
			textControl.ZoomFactor = 75;
		}

		/*-------------------------------------------------------------------------------------------------------------
		** mnuView_Zoom_100_Click method
		** Set zoomfactor to 50 percentage.
		**-----------------------------------------------------------------------------------------------------------*/
		private void mnuView_Zoom_100_Click(object sender, System.EventArgs e) {
			textControl.ZoomFactor = 100;
		}

		/*-------------------------------------------------------------------------------------------------------------
		** mnuView_Zoom_150_Click method
		** Set zoomfactor to 150 percentage.
		**-----------------------------------------------------------------------------------------------------------*/
		private void mnuView_Zoom_150_Click(object sender, System.EventArgs e) {
			textControl.ZoomFactor = 150;
		}

		/*-------------------------------------------------------------------------------------------------------------
		** mnuView_Zoom_200_Click method
		** Set zoomfactor to 200 percentage.
		**-----------------------------------------------------------------------------------------------------------*/
		private void mnuView_Zoom_200_Click(object sender, System.EventArgs e) {
			textControl.ZoomFactor = 200;
		}

		/*-------------------------------------------------------------------------------------------------------------
		** mnuView_Zoom_300_Click method
		** Set zoomfactor to 300 percentage.
		**-----------------------------------------------------------------------------------------------------------*/
		private void mnuView_Zoom_300_Click(object sender, System.EventArgs e) {
			textControl.ZoomFactor = 300;
		}

		/*-------------------------------------------------------------------------------------------------------------
		** mnuView_Zoom_400_Click method
		** Set zoomfactor to 400 percentage.
		**-----------------------------------------------------------------------------------------------------------*/
		private void mnuView_Zoom_400_Click(object sender, EventArgs e) {
			textControl.ZoomFactor = 400;
		}

		/*-------------------------------------------------------------------------------------------------------------
		** mnuView_FormLayout_Click method
		** Sets the application's orientation from right to left when the button is checked otherwise from left to right.
		** This setting will be saved in the application's settings. 
		** Requests for a restart of the application because the setting takes effect when the application is restarted.
		**-----------------------------------------------------------------------------------------------------------*/
		private void mnuView_FormLayout_Click(object sender, EventArgs e) {

			// Set and save choosen orientation.
			if (!((sender) as ToolStripMenuItem).Checked) {
				Properties.Settings.Default.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			}
			else {
				Properties.Settings.Default.RightToLeft = System.Windows.Forms.RightToLeft.No;
			}
			Properties.Settings.Default.Save();

			// Request a restart for applying the new orientation.
			var result = Utils.MessageBox.Show(
				this,
				Resources.MSG_FORMLAYOUTCHANGED_TEXT,
				Resources.MSG_FORMLAYOUTCHANGED_TITLE,
				MessageBoxButtons.YesNo,
				MessageBoxIcon.Information);

			if (result == System.Windows.Forms.DialogResult.Yes) {
				Application.Restart();
			}
		}

		/*-------------------------------------------------------------------------------------------------------------
		** mnuView_HeadersAndFooters_Click method
		** Activate the header. If none header is available in the section then add a new one and activate this.
		**-----------------------------------------------------------------------------------------------------------*/
		private void mnuView_HeadersAndFooters_Click(object sender, System.EventArgs e) {
			try {
				TXTextControl.Section currentSection = textControl.Sections.GetItem();
				TXTextControl.HeaderFooter headerFooter = null;
				if (currentSection.HeadersAndFooters.GetItem(TXTextControl.HeaderFooterType.FirstPageHeader) != null) {
					headerFooter = currentSection.HeadersAndFooters.GetItem(TXTextControl.HeaderFooterType.FirstPageHeader);
				}
				else if (currentSection.HeadersAndFooters.GetItem(TXTextControl.HeaderFooterType.Header) != null) {
					headerFooter = currentSection.HeadersAndFooters.GetItem(TXTextControl.HeaderFooterType.Header);
				}
				else {
					currentSection.HeadersAndFooters.Add(TXTextControl.HeaderFooterType.Header);
					textControl.HeaderFooterActivationStyle = TXTextControl.HeaderFooterActivationStyle.ActivateClick;
					headerFooter = currentSection.HeadersAndFooters.GetItem(TXTextControl.HeaderFooterType.Header);
				}
				headerFooter.Activate();
			}
			catch (Exception ex) {
				Utils.MessageBox.Show(this, ex.Message, ProductName);
			}
		}

		/*-------------------------------------------------------------------------------------------------------------
		** mnuView_TextFrameMarkerLines_Click method
		** Shows/Hides the markerlines of TextFrames.
		**-----------------------------------------------------------------------------------------------------------*/
		private void mnuView_TextFrameMarkerLines_Click(object sender, System.EventArgs e) {
			textControl.TextFrameMarkerLines = !textControl.TextFrameMarkerLines;
		}

		/*-------------------------------------------------------------------------------------------------------------
		** mnuView_DrawingMarkerLines_Click method
		** Shows/Hides the markerlines of drawings.
		**-----------------------------------------------------------------------------------------------------------*/
		private void mnuView_DrawingMarkerLines_Click(object sender, EventArgs e) {
			textControl.DrawingMarkerLines = !textControl.DrawingMarkerLines;
		}

		/*-------------------------------------------------------------------------------------------------------------
		** mnuView_DocumentTargetMarkers_Click method
		** Show/Hide markers for documenttargets.
		**-----------------------------------------------------------------------------------------------------------*/
		private void mnuView_DocumentTargetMarkers_Click(object sender, EventArgs e) {
			textControl.DocumentTargetMarkers = !textControl.DocumentTargetMarkers;
		}


		/*-------------------------------------------------------------------------------------------------------------
		** INSERT  MENU - EVENTHANDLER
		**-----------------------------------------------------------------------------------------------------------*/

		/*-------------------------------------------------------------------------------------------------------------
		** mnuInsert_DropDownOpening method
		** Update the Insert menu.
		**-----------------------------------------------------------------------------------------------------------*/
		private void mnuInsert_DropDownOpening(object sender, System.EventArgs e) {

			try {
				var isHeaderFooterActivated = (textControl.TextParts.GetItem() as HeaderFooter) != null;
				mnuInsert_pageNum.Enabled = textControl.CanEdit && isHeaderFooterActivated;
				mnuInsert_PageNum_Insert.Enabled = isHeaderFooterActivated;
			}
			catch (TXTextControl.LicenseLevelException) { }


			mnuInsert_File.Enabled =
			mnuInsert_Shapes.Enabled =
			mnuInsert_Image.Enabled =
			mnuInsert_TextFrame.Enabled =
			mnuInsert_Chart.Enabled =
			mnuInsert_Fields.Enabled =
			mnuInsert_Symbol.Enabled =
			mnuInsert_EditableRegion.Enabled = textControl.CanEdit;
			mnuInsert_Break.Enabled = (textControl.CanEdit || textControl.CanDocumentFormat);

			mnuInsert_FormFields.Enabled = textControl.CanEdit;

			if (textControl.CanEdit) {
				// Try/Catch is required because hypertext links are not available in the Standard version. 
				// of Text Control. Accessing them would throw an exception if this sample program is used 
				// with a Standard Version.
				try {
					mnuInsert_Hyperlink.Enabled = textControl.HypertextLinks.CanAdd;
					mnuInsert_Target.Enabled = textControl.DocumentTargets.CanAdd;
					mnuInsert_TableOfContents.Enabled = textControl.TablesOfContents.GetItem() == null;

					EditableRegion[] currentEditableRegions = textControl.EditableRegions.GetItems();
					mnuInsert_EditableRegion_Remove.Enabled = (currentEditableRegions != null && currentEditableRegions.Length > 0);
					if (mnuInsert_EditableRegion_Remove.Enabled) {
						mnuInsert_EditableRegion_Remove_Everyone.Enabled = currentEditableRegions.Any(r => string.IsNullOrEmpty(r.UserName));
					}
				}
				catch { }
			}
			else {
				mnuInsert_Hyperlink.Enabled = false;
				mnuInsert_Target.Enabled = false;
				mnuInsert_TableOfContents.Enabled = false;
			}
		}

		/*-------------------------------------------------------------------------------------------------------------
		** mnuInsert_File_Click method
		** Shows a dialog for inserting a document at input position.
		**-----------------------------------------------------------------------------------------------------------*/
		private void mnuInsert_File_Click(object sender, System.EventArgs e) {
			try {
				m_fileHandler.Insert();
			}
			catch (Exception ex) {
				Utils.MessageBox.Show(this, ex.Message, ProductName);
			}
		}

		/*-------------------------------------------------------------------------------------------------------------
		** mnuInsert_Image_Click method
		** Show a dialog for inserting an image at input position.
		**-----------------------------------------------------------------------------------------------------------*/
		private void mnuInsert_Image_Click(object sender, System.EventArgs e) {
			TXTextControl.Image imageNew = new TXTextControl.Image();
			try {
				textControl.Images.Add(imageNew, TXTextControl.HorizontalAlignment.Left, -1, TXTextControl.ImageInsertionMode.DisplaceText);
			}
			catch (Exception exc) {
				Utils.MessageBox.Show(this, exc.Message, ProductName);
			}
		}

		/*-------------------------------------------------------------------------------------------------------------
		** mnuInsert_TableOfContents_Click method
		** Shows a dialog for inserting a new table of contents at the current input position. 
		**-----------------------------------------------------------------------------------------------------------*/
		private void mnuInsert_TableOfContents_Click(object sender, EventArgs e) {
			textControl.TableOfContentsDialog();
		}

		/*-------------------------------------------------------------------------------------------------------------
		** mnuInsert_PageNum_Delete_Click method
		** Remove all pagenumber fields from each header and footer.
		**-----------------------------------------------------------------------------------------------------------*/
		private void mnuInsert_PageNum_Delete_Click(object sender, EventArgs e) {
			RemovePageNumbers();
		}

		/*-------------------------------------------------------------------------------------------------------------
		** mnuInsert_Fields_deleteField_Click method
		** Remove the field at inputposition.
		**-----------------------------------------------------------------------------------------------------------*/
		private void mnuInsert_Fields_deleteField_Click(object sender, EventArgs e) {
			DeleteField();
		}

		/*-------------------------------------------------------------------------------------------------------------
		** mnuInsert_Shapes_DrawingCanvas_Click method
		** Insert a drawing at inputposition.
		**-----------------------------------------------------------------------------------------------------------*/
		private void mnuInsert_Shapes_DrawingCanvas_Click(object sender, EventArgs e) {
			InsertDrawingCanvas();
		}

		/*-------------------------------------------------------------------------------------------------------------
		** mnuInsert_TextFrame_Click method
		** Insert a TextFrame at inputposition.
		**-----------------------------------------------------------------------------------------------------------*/
		private void mnuInsert_TextFrame_Click(object sender, System.EventArgs e) {
			try {
				// Force Exception if standard version:
				textControl.TextFrames.GetItem();
				Size sizeTextFrame = new Size(2268, 2268);   // Arbitrary size (Frame is inserted with the mouse anyway)

				TXTextControl.TextFrame textFrameNew = new TXTextControl.TextFrame(sizeTextFrame);
				textControl.TextFrames.Add(textFrameNew, TXTextControl.TextFrameInsertionMode.DisplaceText | TXTextControl.TextFrameInsertionMode.MoveWithText);
			}
			catch (Exception ex) {
				Utils.MessageBox.Show(this, ex.Message, ProductName);
			}
		}

		/*-------------------------------------------------------------------------------------------------------------
		** mnuInsert_Symbol_Click method
		** Show TextControl's build-in dialog for inserting a symbol.
		**-----------------------------------------------------------------------------------------------------------*/
		private void mnuInsert_Symbol_Click(object sender, EventArgs e) {
			textControl.AddSymbolDialog();
		}

		/*-------------------------------------------------------------------------------------------------------------
		** mnuInsert_Hyperlink_Click method
		** Show TextControl's build-in dialog for inserting a hyperlink.
		**-----------------------------------------------------------------------------------------------------------*/
		private void mnuInsert_Hyperlink_Click(object sender, System.EventArgs e) {
			var dlg = new TXTextControl.HyperlinkDialog(textControl);
			if (dlg.ShowDialog(this) == DialogResult.OK) m_fileHandler.IsDocumentDirty = true;
		}

		/*-------------------------------------------------------------------------------------------------------------
		** mnuInsert_Target_Click method
		** Show a dialog for inserting a documenttarget.
		**-----------------------------------------------------------------------------------------------------------*/
		private void mnuInsert_Target_Click(object sender, System.EventArgs e) {
			var dlg = new TXTextControl.BookmarkDialog(textControl)
			{
				Owner = this,
				RightToLeftLayout = true
			};

			if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK) m_fileHandler.IsDocumentDirty = true;
		}

		/*-------------------------------------------------------------------------------------------------------------
		** mnuInsert_Fields_DropDownOpening method
		** Update the 'Field' menu.
		**-----------------------------------------------------------------------------------------------------------*/
		private void mnuInsert_Fields_DropDownOpening(object sender, EventArgs e) {
			switch (m_fldDispModeCur) {
				case FieldDisplayMode.ShowFieldText:
					mnuInsert_Fields_showFieldCodes.Checked = false;
					mnuInsert_Fields_showFieldText.Checked = true;
					break;

				case FieldDisplayMode.ShowFieldCodes:
					mnuInsert_Fields_showFieldCodes.Checked = true;
					mnuInsert_Fields_showFieldText.Checked = false;
					break;
			}

			mnuInsert_Fields_highlightMergeFields.Checked = m_bHighlightFields == HighlightMode.Activated;
			mnuInsert_Fields_deleteField.Enabled = FieldAtCurrentPos();
		}

		/*-------------------------------------------------------------------------------------------------------------
		** mnuInsert_Fields_insertMergeField_Click method
		** Show dialog for inserting a mergefield at current position.
		**-----------------------------------------------------------------------------------------------------------*/
		private void mnuInsert_Fields_insertMergeField_Click(object sender, EventArgs e) {
			InsertMergeField();
		}

		/*-------------------------------------------------------------------------------------------------------------
		** mnuInsert_Fields_insertSpecialField_IF_Click method
		** Show dialog for inserting a IfField at current position.
		**-----------------------------------------------------------------------------------------------------------*/
		private void mnuInsert_Fields_insertSpecialField_IF_Click(object sender, EventArgs e) {
			InsertIfField();
		}

		/*-------------------------------------------------------------------------------------------------------------
		** mnuInsert_Fields_insertSpecialField_inclText_Click method
		** Show dialog for inserting a IncludeTextField at current position.
		**-----------------------------------------------------------------------------------------------------------*/
		private void mnuInsert_Fields_insertSpecialField_inclText_Click(object sender, EventArgs e) {
			InsertIncludeTextField();
		}

		/*-------------------------------------------------------------------------------------------------------------
		** mnuInsert_Fields_insertSpecialField_date_Click method
		** Show dialog for inserting a field at current position for displaying a date.
		**-----------------------------------------------------------------------------------------------------------*/
		private void mnuInsert_Fields_insertSpecialField_date_Click(object sender, EventArgs e) {
			InsertDateField();
		}

		/*-------------------------------------------------------------------------------------------------------------
		** mnuInsert_Fields_insertSpecialField_next_Click method
		** Show dialog for inserting a NextField at current position.
		**-----------------------------------------------------------------------------------------------------------*/
		private void mnuInsert_Fields_insertSpecialField_next_Click(object sender, EventArgs e) {
			InsertNextField();
		}

		/*-------------------------------------------------------------------------------------------------------------
		** mnuInsert_Fields_insertSpecialField_nextif_Click method
		** Show dialog for inserting a NextIfField at current position.
		**-----------------------------------------------------------------------------------------------------------*/
		private void mnuInsert_Fields_insertSpecialField_nextif_Click(object sender, EventArgs e) {
			InsertNextIfField();
		}

		/*-------------------------------------------------------------------------------------------------------------
		** mnuInsert_Fields_highlightMergeFields_Click method
		** Un-/highlight mergefields.
		**-----------------------------------------------------------------------------------------------------------*/
		private void mnuInsert_Fields_highlightMergeFields_Click(object sender, EventArgs e) {
			// Switch highlighting mode.
			m_bHighlightFields = (m_bHighlightFields == HighlightMode.Activated) ? HighlightMode.Never : HighlightMode.Activated;
			mnuInsert_Fields_highlightMergeFields.Checked = (m_bHighlightFields == HighlightMode.Activated);

			// Refresh the field and block-properties.
			SetDefaultFieldAndBlockProperties();
		}

		/*-------------------------------------------------------------------------------------------------------------
		** mnuInsert_Fields_showFieldCodes_Click method
		** Set the field's text for showing the field's codes.
		**-----------------------------------------------------------------------------------------------------------*/
		private void mnuInsert_Fields_showFieldCodes_Click(object sender, EventArgs e) {
			if (mnuInsert_Fields_showFieldCodes.Checked) return;

			m_fldDispModeCur = FieldDisplayMode.ShowFieldCodes;
			UpdateFieldValues();
		}

		/*-------------------------------------------------------------------------------------------------------------
		** mnuInsert_Fields_showFieldText_Click method
		** Set the field's text for showing the field's type.
		**-----------------------------------------------------------------------------------------------------------*/
		private void mnuInsert_Fields_showFieldText_Click(object sender, EventArgs e) {
			if (mnuInsert_Fields_showFieldText.Checked) return;

			m_fldDispModeCur = FieldDisplayMode.ShowFieldText;
			UpdateFieldValues();
		}


		/*-------------------------------------------------------------------------------------------------------------
		**	MENU EVENTHANDLERS - FORMFIELDS
		**-----------------------------------------------------------------------------------------------------------*/

		/*-------------------------------------------------------------------------------------------------------------
		** mnuInsert_FormFields_DropDownOpening method
		**	Disables the menuitems for inserting new FormFields if no FormField can be added.
		**	Disables the menuitem for deleting a FormField if no FormField is available at the current input position.
		**-----------------------------------------------------------------------------------------------------------*/
		private void mnuInsert_FormFields_DropDownOpening(object sender, EventArgs e) {
			try {
				foreach (ToolStripMenuItem item in mnuInsert_FormFields.DropDownItems) {
					item.Enabled = textControl.FormFields.CanAdd;
				}
			}
			catch (LicenseLevelException) { }
		}

		/*-------------------------------------------------------------------------------------------------------------
		** mnuInsert_FormFields_TextFormField_Click method
		**	Inserts a new TextFormField.
		**-----------------------------------------------------------------------------------------------------------*/
		private void mnuInsert_FormFields_TextFormField_Click(object sender, EventArgs e) {

			TextFormField field = new TextFormField(GetFormFieldWidth());
			textControl.FormFields.Add(field);
		}

		/*-------------------------------------------------------------------------------------------------------------
		** mnuInsert_FormFields_CheckFormField_Click method
		**	Inserts a new CheckFormField.
		**-----------------------------------------------------------------------------------------------------------*/
		private void mnuInsert_FormFields_CheckFormField_Click(object sender, EventArgs e) {

			CheckFormField field = new CheckFormField(false);
			textControl.FormFields.Add(field);
		}

		/*-------------------------------------------------------------------------------------------------------------
		** mnuInsert_FormFields_ComboBoxFormField_Click method
		**	Shows a dialog for inserting a new ComboBox FormField. A ComboBox FormField is a special SelectionFormField
		**	which qualifies to any input text.
		**-----------------------------------------------------------------------------------------------------------*/
		private void mnuInsert_FormFields_ComboBoxFormField_Click(object sender, EventArgs e) {

			SelectionFormField field = new SelectionFormField(GetFormFieldWidth())
			{
				Editable = true,
				IsDropDownArrowVisible = true
			};
			var dlg = new FormFields.SelectionFormFieldDialog(field) { Text = Properties.Resources.SELECTIONFORMFIELD_DLG_COMBOBOX_TITLE, RightToLeft = this.RightToLeft };

			if (dlg.ShowDialog(this) == System.Windows.Forms.DialogResult.OK) {
				textControl.FormFields.Add(field);
			}

		}

		/*-------------------------------------------------------------------------------------------------------------
		** mnuInsert_FormFields_DropDownListFormField_Click method
		**	Shows a dialog for inserting a new SelectionFormField.
		**-----------------------------------------------------------------------------------------------------------*/
		private void mnuInsert_FormFields_DropDownListFormField_Click(object sender, EventArgs e) {

			SelectionFormField field = new SelectionFormField(GetFormFieldWidth())
			{
				Editable = false,
				IsDropDownArrowVisible = true
			};
			var dlg = new FormFields.SelectionFormFieldDialog(field) { Text = Properties.Resources.SELECTIONFORMFIELD_DLG_DROPDOWN_TITLE, RightToLeft = this.RightToLeft };

			if (dlg.ShowDialog(this) == System.Windows.Forms.DialogResult.OK) {
				textControl.FormFields.Add(field);
			}
		}

		/*-------------------------------------------------------------------------------------------------------------
		** mnuInsert_FormFields_DatePicker_Click method
		**	Inserts a new default DateFormField at input position.
		**-----------------------------------------------------------------------------------------------------------*/
		private void mnuInsert_FormFields_DatePicker_Click(object sender, EventArgs e) {

			DateFormField field = new DateFormField(GetFormFieldWidth())
			{
				IsDateControlVisible = true
			};

			textControl.FormFields.Add(field);
		}


		/*-------------------------------------------------------------------------------------------------------------
		** GetFormFieldWidth method
		**	Calculates the width for a new FormField.
		** If input position is in a table then return the cell's width (for filling the cell)
		** else return the default width.
		**-----------------------------------------------------------------------------------------------------------*/
		private int GetFormFieldWidth() {
			var width = DEFAULT_FORMFIELD_EMPTYWIDTH;

			var table = textControl.Tables.GetItem();
			if (textControl.Tables.GetItem() != null) {
				var cell = table.Cells.GetItem();
				if (cell != null) {
					width = cell.Width;
				}
			}

			return width;
		}

		/*-------------------------------------------------------------------------------------------------------------
		**	MENU EVENTHANDLERS - PAGE NUMBERS
		**-----------------------------------------------------------------------------------------------------------*/

		/*-------------------------------------------------------------------------------------------------------------
		** mnuInsert_PageNum_Click method
		** Insert a field for displaying the pagenumber if a header or footer is activated.
		**-----------------------------------------------------------------------------------------------------------*/
		private void mnuInsert_PageNum_Click(object sender, EventArgs e) {
			InsertPageNumber();
		}


		/*-------------------------------------------------------------------------------------------------------------
		** MENU EVENTHANDLERS - CHARTS
		**-----------------------------------------------------------------------------------------------------------*/

		/*-------------------------------------------------------------------------------------------------------------
		** mnuInsert_chart_pie3D_Click method
		** Insert a pie-chart in 3D style.
		**-----------------------------------------------------------------------------------------------------------*/
		private void mnuInsert_chart_pie3D_Click(object sender, EventArgs e) {
			TryInsertMSChart("Pie", true);
		}

		/*-------------------------------------------------------------------------------------------------------------
		** mnuInsert_chart_area_Click method
		** Insert a area-chart.
		**-----------------------------------------------------------------------------------------------------------*/
		private void mnuInsert_chart_area_Click(object sender, EventArgs e) {
			TryInsertMSChart("Area", false);
		}

		/*-------------------------------------------------------------------------------------------------------------
		** mnuInsert_chart_bar_Click method
		** Insert a Bar-chart.
		**-----------------------------------------------------------------------------------------------------------*/
		private void mnuInsert_chart_bar_Click(object sender, EventArgs e) {
			TryInsertMSChart("Bar", false);
		}

		/*-------------------------------------------------------------------------------------------------------------
		** mnuInsert_chart_column_Click method
		** Insert a Column-chart.
		**-----------------------------------------------------------------------------------------------------------*/
		private void mnuInsert_chart_column_Click(object sender, EventArgs e) {
			TryInsertMSChart("Column", false);
		}

		/*-------------------------------------------------------------------------------------------------------------
		** mnuInsert_chart_pie_Click method
		** Insert a Pie-chart.
		**-----------------------------------------------------------------------------------------------------------*/
		private void mnuInsert_chart_pie_Click(object sender, EventArgs e) {
			TryInsertMSChart("Pie", false);
		}

		/*-------------------------------------------------------------------------------------------------------------
		** mnuInsert_chart_line_Click method
		** Insert a Line-chart.
		**-----------------------------------------------------------------------------------------------------------*/
		private void mnuInsert_chart_clusteredBar_Click(object sender, EventArgs e) {
			TryInsertMSChart("Bar", false);
		}

		/*-------------------------------------------------------------------------------------------------------------
		** mnuInsert_EditableRegion_Add_User_Click method
		** Shows a dialog for inserting an EditableRegion for a user.
		**-----------------------------------------------------------------------------------------------------------*/
		private void mnuInsert_EditableRegion_Add_User_Click(object sender, EventArgs e) {
			if (textControl.Selection.Length == 0) {
				Utils.MessageBox.Show(this, Properties.Resources.MSG_SELECT_DOCUMENTPART, ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
				return;
			}

			User_Access_Control.AddEditableRegionDialog dlg = new User_Access_Control.AddEditableRegionDialog(m_UAC)
			{
				Owner = this,
				RightToLeft = this.RightToLeft
			};
			dlg.ShowDialog(this);
		}

		/*-------------------------------------------------------------------------------------------------------------
		** mnuInsert_EditableRegion_Add_Everyone_Click method
		** Creates a EditableRegion at selection which is editable for everyone.
		**-----------------------------------------------------------------------------------------------------------*/
		private void mnuInsert_EditableRegion_Add_Everyone_Click(object sender, EventArgs e) {
			if (textControl.Selection.Length == 0) {
				Utils.MessageBox.Show(this, Properties.Resources.MSG_SELECT_DOCUMENTPART, ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
				return;
			}

			textControl.EditableRegions.Add(new TXTextControl.EditableRegion("", 0));
		}

		/*-------------------------------------------------------------------------------------------------------------
		** mnuInsert_EditableRegion_Remove_User_Click method
		** Show a dialog for typing in a user's name and remove the first user's editable region at current position.
		**-----------------------------------------------------------------------------------------------------------*/
		private void mnuInsert_EditableRegion_Remove_User_Click(object sender, EventArgs e) {
			// Remove region of user
			string userName = "";
			if (InputBoxDialog.ShowInputBox(Resources.INPUTBOXDLG_REMOVE_EDITABLEREGION_TITLE, ref userName, this)) {
				if (!string.IsNullOrEmpty(userName)) {
					try {
						TXTextControl.EditableRegion removed = textControl.EditableRegions.Remove((textControl.Selection.Length > 0), userName);
						if (removed == null) Utils.MessageBox.Show(this, Properties.Resources.MSG_EDITABLEREGION_NA_FOR_USER, ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

					}
					catch (TXTextControl.LicenseLevelException) {
						throw;
					}
				}
			}
		}

		/*-------------------------------------------------------------------------------------------------------------
		** mnuInsert_EditableRegion_Remove_Everyone_Click method
		** Remove the editable region at input position which is editable for everyone.
		**-----------------------------------------------------------------------------------------------------------*/
		private void mnuInsert_EditableRegion_Remove_Everyone_Click(object sender, EventArgs e) {
			textControl.EditableRegions.Remove(textControl.Selection.Length > 0);
		}


		/*-------------------------------------------------------------------------------------------------------------
		** FORMAT  MENU - EVENTHANDLER
		**-----------------------------------------------------------------------------------------------------------*/

		/*-------------------------------------------------------------------------------------------------------------
		** mnuFormat_DropDownOpening method
		** Update 'Format' menu.
		**-----------------------------------------------------------------------------------------------------------*/
		private void mnuFormat_DropDownOpening(object sender, System.EventArgs e) {
			mnuFormat_Character.Enabled = textControl.CanCharacterFormat;
			mnuFormat_Paragraph.Enabled = textControl.CanParagraphFormat;
			mnuFormat_List.Enabled = textControl.CanParagraphFormat;
			mnuFormat_Styles.Enabled = textControl.CanStyleFormat;

			mnuFormat_HeadersAndFooters.Enabled =
			mnuFormat_Columns.Enabled =
			mnuFormat_PageBorders.Enabled =
			mnuFormat_Tabs.Enabled = textControl.CanDocumentFormat;

			mnuFormat_FormFields.Enabled = textControl.CanEdit;

			if (textControl.CanEdit) {
				mnuFormat_Image.Enabled = (textControl.Images.GetItem() != null);
				mnuFormat_Language.Enabled = true;

				try { mnuFormat_TextFrame.Enabled = (textControl.TextFrames.GetItem() != null); }
				catch { mnuFormat_TextFrame.Enabled = false; }

				try {
					mnuFormat_Shape.Enabled = (textControl.Drawings.GetItem() != null);
				}
				catch { mnuFormat_Shape.Enabled = false; }

				try {
					mnuFormat_ChartLayout.Enabled = (textControl.Charts.GetItem() != null);
				}
				catch { mnuFormat_ChartLayout.Enabled = false; }
			}
			else {
				mnuFormat_TextFrame.Enabled = false;
				mnuFormat_Shape.Enabled = false;
				mnuFormat_ChartLayout.Enabled = false;
				mnuFormat_Image.Enabled = false;
				mnuFormat_Language.Enabled = false;
			}
		}

		/*-------------------------------------------------------------------------------------------------------------
		** mnuFormat_Character_Click method
		** Show TextControl's build-in dialog for editing the fontsettings.
		**-----------------------------------------------------------------------------------------------------------*/
		private void mnuFormat_Character_Click(object sender, System.EventArgs e) {
			if (textControl.FontDialog() == System.Windows.Forms.DialogResult.OK) {
				m_fileHandler.IsDocumentDirty = true;
			}
		}

		/*-------------------------------------------------------------------------------------------------------------
		** mnuFormat_Paragraph_Click method
		** Show TextControl's build-in dialog for editing the paragraph's format.
		**-----------------------------------------------------------------------------------------------------------*/
		private void mnuFormat_Paragraph_Click(object sender, System.EventArgs e) {
			if (textControl.ParagraphFormatDialog() == System.Windows.Forms.DialogResult.OK) {
				m_fileHandler.IsDocumentDirty = true;
			}
		}

		/*-------------------------------------------------------------------------------------------------------------
		** mnuFormat_Tabs_Click method
		** Show TextControl's build-in dialog for editing the tabulator-settings.
		**-----------------------------------------------------------------------------------------------------------*/
		private void mnuFormat_Tabs_Click(object sender, System.EventArgs e) {
			if (textControl.TabDialog() == System.Windows.Forms.DialogResult.OK) {
				m_fileHandler.IsDocumentDirty = true;
			}
		}

		/*-------------------------------------------------------------------------------------------------------------
		** mnuFormat_Styles_Click method
		** Show TextControl's build-in dialog for editing the formattingsstyles.
		**-----------------------------------------------------------------------------------------------------------*/
		private void mnuFormat_Styles_Click(object sender, System.EventArgs e) {
			if (textControl.FormattingStylesDialog() == System.Windows.Forms.DialogResult.OK) {
				m_fileHandler.IsDocumentDirty = true;
			}
		}

		/*-------------------------------------------------------------------------------------------------------------
		** mnuFormat_HeadersFooters_Click method
		** Show TextControl's build-in dialog for editing the section's format.
		**-----------------------------------------------------------------------------------------------------------*/
		private void mnuFormat_HeadersFooters_Click(object sender, EventArgs e) {
			try {
				if (textControl.SectionFormatDialog(1) == System.Windows.Forms.DialogResult.OK) {
					m_fileHandler.IsDocumentDirty = true;
				}
			}
			catch (Exception ex) {
				Utils.MessageBox.Show(this, ex.Message, ProductName);
			}
		}

		/*-------------------------------------------------------------------------------------------------------------
		** mnuFormat_Image_Click method
		** Show TextControl's build-in dialog for setting the image's attribute.
		**-----------------------------------------------------------------------------------------------------------*/
		private void mnuFormat_Image_Click(object sender, System.EventArgs e) {
			if (textControl.ImageAttributesDialog() == System.Windows.Forms.DialogResult.OK) {
				m_fileHandler.IsDocumentDirty = true;
			}
		}

		/*-------------------------------------------------------------------------------------------------------------
		** mnuFormat_List_DropDownOpening method
		** Update the 'List' menu.
		**-----------------------------------------------------------------------------------------------------------*/
		private void mnuFormat_List_DropDownOpening(object sender, EventArgs e) {
			mnuFormat_List_IncreaseLevel.Enabled
				= (textControl.Selection.ListFormat.Type != TXTextControl.ListType.None)
				&& (textControl.Selection.ListFormat.Level < TXTextControl.ListFormat.MaxLevel);
			mnuFormat_List_DecreaseLevel.Enabled
				= (textControl.Selection.ListFormat.Type != TXTextControl.ListType.None)
				&& (textControl.Selection.ListFormat.Level > 1);

			UpdateToolbar_Format_List();
		}

		/*-------------------------------------------------------------------------------------------------------------
		** mnuFormat_List_Attributes_Click method
		** Show TextControl's build-in dialog for formatting the list.
		**-----------------------------------------------------------------------------------------------------------*/
		private void mnuFormat_List_Attributes_Click(object sender, System.EventArgs e) {
			if (textControl.ListFormatDialog() == System.Windows.Forms.DialogResult.OK) {
				m_fileHandler.IsDocumentDirty = true;
			}
		}

		/*-------------------------------------------------------------------------------------------------------------
		** mnuFormat_List_IncreaseLevel_Click method
		** Increase the list's level and indention.
		**-----------------------------------------------------------------------------------------------------------*/
		private void mnuFormat_List_IncreaseLevel_Click(object sender, System.EventArgs e) {
			textControl.Selection.ListFormat.Level += 1;
			textControl.Selection.IncreaseIndent();
		}

		/*-------------------------------------------------------------------------------------------------------------
		** mnuFormat_List_DecreaseLevel_Click method
		** Decrease the list's level and indention.
		**-----------------------------------------------------------------------------------------------------------*/
		private void mnuFormat_List_DecreaseLevel_Click(object sender, System.EventArgs e) {
			if (textControl.Selection.ListFormat.Level >= 2) {
				textControl.Selection.ListFormat.Level -= 1;
				textControl.Selection.DecreaseIndent();
			}
		}

		/*-------------------------------------------------------------------------------------------------------------
		** mnuFormat_List_ArabicNumbers_Click method
		** Un-/set list as arabic numbered.
		**-----------------------------------------------------------------------------------------------------------*/
		private void mnuFormat_List_ArabicNumbers_Click(object sender, System.EventArgs e) {
			if (mnuFormat_List_ArabicNumbers.Checked) {
				textControl.Selection.ListFormat.Type = TXTextControl.ListType.None;
				textControl.Selection.ListFormat.NumberFormat = TXTextControl.NumFormat.None;
			}
			else {
				textControl.Selection.ListFormat.Type = TXTextControl.ListType.Numbered;
				textControl.Selection.ListFormat.NumberFormat = TXTextControl.NumFormat.ArabicNumbers;
			}
		}

		/*-------------------------------------------------------------------------------------------------------------
		** mnuFormat_List_CapitalLetters_Click method
		** Un-/set list as numbered with capital-letters.
		**-----------------------------------------------------------------------------------------------------------*/
		private void mnuFormat_List_CapitalLetters_Click(object sender, System.EventArgs e) {
			if (mnuFormat_List_CapitalLetters.Checked) {
				textControl.Selection.ListFormat.Type = TXTextControl.ListType.None;
				textControl.Selection.ListFormat.NumberFormat = TXTextControl.NumFormat.None;
			}
			else {
				textControl.Selection.ListFormat.Type = TXTextControl.ListType.Numbered;
				textControl.Selection.ListFormat.NumberFormat = TXTextControl.NumFormat.CapitalLetters;
			}
		}

		/*-------------------------------------------------------------------------------------------------------------
		** mnuFormat_List_Letters_Click method
		** Un-/set list as numbered with letters.
		**-----------------------------------------------------------------------------------------------------------*/
		private void mnuFormat_List_Letters_Click(object sender, System.EventArgs e) {
			if (mnuFormat_List_Letters.Checked) {
				textControl.Selection.ListFormat.Type = TXTextControl.ListType.None;
				textControl.Selection.ListFormat.NumberFormat = TXTextControl.NumFormat.None;
			}
			else {
				textControl.Selection.ListFormat.Type = TXTextControl.ListType.Numbered;
				textControl.Selection.ListFormat.NumberFormat = TXTextControl.NumFormat.Letters;
			}
		}

		/*-------------------------------------------------------------------------------------------------------------
		** mnuFormat_List_RomanNumbers_Click method
		** Un-/set list as numbered with romannumbers.
		**-----------------------------------------------------------------------------------------------------------*/
		private void mnuFormat_List_RomanNumbers_Click(object sender, System.EventArgs e) {
			if (mnuFormat_List_RomanNumbers.Checked) {
				textControl.Selection.ListFormat.Type = TXTextControl.ListType.None;
				textControl.Selection.ListFormat.NumberFormat = TXTextControl.NumFormat.None;
			}
			else {
				textControl.Selection.ListFormat.Type = TXTextControl.ListType.Numbered;
				textControl.Selection.ListFormat.NumberFormat = TXTextControl.NumFormat.RomanNumbers;
			}
		}

		/*-------------------------------------------------------------------------------------------------------------
		** mnuFormat_List_SmallRomanNumbers_Click method
		** Un-/set list as numbered with small romannumbers.
		**-----------------------------------------------------------------------------------------------------------*/
		private void mnuFormat_List_SmallRomanNumbers_Click(object sender, System.EventArgs e) {
			if (mnuFormat_List_SmallRomanNumbers.Checked) {
				textControl.Selection.ListFormat.Type = TXTextControl.ListType.None;
				textControl.Selection.ListFormat.NumberFormat = TXTextControl.NumFormat.None;

			}
			else {
				textControl.Selection.ListFormat.Type = TXTextControl.ListType.Numbered;
				textControl.Selection.ListFormat.NumberFormat = TXTextControl.NumFormat.SmallRomanNumbers;
			}
		}

		/*-------------------------------------------------------------------------------------------------------------
		** mnuFormat_List_Bullets_Click method
		** Un-/set list with bullets.
		**-----------------------------------------------------------------------------------------------------------*/
		private void mnuFormat_List_Bullets_Click(object sender, System.EventArgs e) {
			if (mnuFormat_List_Bullets.Checked) {
				textControl.Selection.ListFormat.Type = TXTextControl.ListType.None;
				textControl.Selection.ListFormat.NumberFormat = TXTextControl.NumFormat.None;
			}
			else {
				textControl.Selection.ListFormat.Type = TXTextControl.ListType.Bulleted;
			}
		}

		/*-------------------------------------------------------------------------------------------------------------
		** mnuFormat_borders_Click method
		** Shows TextControl's build-in dialog for editing the borders's settings.
		**-----------------------------------------------------------------------------------------------------------*/
		private void mnuFormat_borders_Click(object sender, EventArgs e) {
			try {
				if (textControl.SectionFormatDialog(3) == System.Windows.Forms.DialogResult.OK) {
					m_fileHandler.IsDocumentDirty = true;
				}
			}
			catch (Exception ex) {
				Utils.MessageBox.Show(this, ex.Message, ProductName);
			}
		}

		/*-------------------------------------------------------------------------------------------------------------
		** mnuFormat_Columns_Click method
		** Shows TextControl's build-in dialog for editing the columns's settings.
		**-----------------------------------------------------------------------------------------------------------*/
		private void mnuFormat_Columns_Click(object sender, EventArgs e) {
			try {
				if (textControl.SectionFormatDialog(2) == System.Windows.Forms.DialogResult.OK) {
					m_fileHandler.IsDocumentDirty = true;
				}
			}
			catch (Exception ex) {
				Utils.MessageBox.Show(this, ex.Message, ProductName);
			}
		}

		/*-------------------------------------------------------------------------------------------------------------
		** mnuFormat_TextFrame_Click method
		** Shows TextControl's build-in dialog for editing the textframe's attributes.
		**-----------------------------------------------------------------------------------------------------------*/
		private void mnuFormat_TextFrame_Click(object sender, System.EventArgs e) {
			try {
				if (textControl.TextFrameAttributesDialog() == System.Windows.Forms.DialogResult.OK) {
					m_fileHandler.IsDocumentDirty = true;
				}
			}
			catch { }
		}

		/*-------------------------------------------------------------------------------------------------------------
		** mnuFormat_Shape_Click method
		** Shows TextControl's build-in dialog for editing the drawing's layout.
		**-----------------------------------------------------------------------------------------------------------*/
		private void mnuFormat_Shape_Click(object sender, EventArgs e) {
			textControl.DrawingLayoutDialog();
		}

		/*-------------------------------------------------------------------------------------------------------------
		** mnuFormat_Language_Click method
		** Shows TextControl's build-in dialog for editing the set language.
		**-----------------------------------------------------------------------------------------------------------*/
		private void mnuFormat_Language_Click(object sender, EventArgs e) {
			textControl.LanguageDialog();
		}

		/*-------------------------------------------------------------------------------------------------------------
		** mnuFormat_ChartLayout_DropDownOpening method
		** Update the chart's layout menu.
		**-----------------------------------------------------------------------------------------------------------*/
		private void mnuFormat_ChartLayout_DropDownOpening(object sender, EventArgs e) {
			mnuFormat_ChartLayout_Axes.Enabled = textControl.CanEdit;
			mnuFormat_ChartLayout_AxisTitles.Enabled = textControl.CanEdit;
			mnuFormat_ChartLayout_DataLabels.Enabled = textControl.CanEdit;
			mnuFormat_ChartLayout_HorGridLines.Enabled = textControl.CanEdit;
			mnuFormat_ChartLayout_Legend.Enabled = textControl.CanEdit;
			mnuFormat_ChartLayout_ChartTitle.Enabled = textControl.CanEdit;
			mnuFormat_ChartLayout_VertGridLines.Enabled = textControl.CanEdit;
		}

		/*-------------------------------------------------------------------------------------------------------------
		** mnuFormat_Chart_ChartTitle_None_Click method
		** Hide all titles of chart.
		**-----------------------------------------------------------------------------------------------------------*/
		private void mnuFormat_Chart_ChartTitle_None_Click(object sender, EventArgs e) {
			try { ClearChartTitles(); }
			catch { }
		}

		/*-------------------------------------------------------------------------------------------------------------
		** mnuFormat_Chart_ChartTitle_CenteredOverlay_Click method
		** Set chart's title centered and as overlay.
		**-----------------------------------------------------------------------------------------------------------*/
		private void mnuFormat_Chart_ChartTitle_CenteredOverlay_Click(object sender, EventArgs e) {
			try { SetChartTitleCenteredOverlay(); }
			catch { }
		}

		/*-------------------------------------------------------------------------------------------------------------
		** mnuFormat_Chart_ChartTitle_AboveChart_Click method
		** Set chart's title above chart.
		**-----------------------------------------------------------------------------------------------------------*/
		private void mnuFormat_Chart_ChartTitle_AboveChart_Click(object sender, EventArgs e) {
			try { SetChartTitleAboveChart(); }
			catch { }
		}

		/*-------------------------------------------------------------------------------------------------------------
		** mnuFormat_Chart_AxisTitles_None_Click method
		** Hide chart's axistitles. 
		**-----------------------------------------------------------------------------------------------------------*/
		private void mnuFormat_Chart_AxisTitles_None_Click(object sender, EventArgs e) {
			try { ClearChartAxisTitles(); }
			catch { }
		}

		/*-------------------------------------------------------------------------------------------------------------
		** mnuFormat_Chart_AxisTitles_BelowChart_Click method
		** Set chart's axistitles below chart.
		**-----------------------------------------------------------------------------------------------------------*/
		private void mnuFormat_Chart_AxisTitles_BelowChart_Click(object sender, EventArgs e) {
			try { SetAxisTitlesBelowChart(); }
			catch { }
		}

		/*-------------------------------------------------------------------------------------------------------------
		** mnuFormat_Chart_AxisTitles_Vertical_Click method
		** Show chart's axistitles vertically. 
		**-----------------------------------------------------------------------------------------------------------*/
		private void mnuFormat_Chart_AxisTitles_Vertical_Click(object sender, EventArgs e) {
			try { SetVerticalAxisTitle(); }
			catch { }
		}

		/*-------------------------------------------------------------------------------------------------------------
		** mnuFormat_Chart_Legend_None_Click method
		** Hide chart's legend.
		**-----------------------------------------------------------------------------------------------------------*/
		private void mnuFormat_Chart_Legend_None_Click(object sender, EventArgs e) {
			try { DisableChartLegend(); }
			catch { }
		}

		/*-------------------------------------------------------------------------------------------------------------
		** mnuFormat_Chart_Legend_Top_Click method
		** Show chart's legend top.
		**-----------------------------------------------------------------------------------------------------------*/
		private void mnuFormat_Chart_Legend_Top_Click(object sender, EventArgs e) {
			try { SetChartLegendTop(); }
			catch { }
		}

		/*-------------------------------------------------------------------------------------------------------------
		** mnuFormat_Chart_Legend_Right_Click method
		** Show chart's legend right.
		**-----------------------------------------------------------------------------------------------------------*/
		private void mnuFormat_Chart_Legend_Right_Click(object sender, EventArgs e) {
			try { SetChartLegendRight(); }
			catch { }
		}

		/*-------------------------------------------------------------------------------------------------------------
		** mnuFormat_Chart_Legend_Bottom_Click method
		** Show chart's legend bottom.
		**-----------------------------------------------------------------------------------------------------------*/
		private void mnuFormat_Chart_Legend_Bottom_Click(object sender, EventArgs e) {
			try { SetChartLegendBottom(); }
			catch { }
		}

		/*-------------------------------------------------------------------------------------------------------------
		** mnuFormat_Chart_Legend_Left_Click method
		** Show chart's legend left.
		**-----------------------------------------------------------------------------------------------------------*/
		private void mnuFormat_Chart_Legend_Left_Click(object sender, EventArgs e) {
			try { SetChartLegendLeft(); }
			catch { }
		}

		/*-------------------------------------------------------------------------------------------------------------
		** mnuFormat_Chart_DataLabels_None_Click method
		** Hide chart's datalabels.
		**-----------------------------------------------------------------------------------------------------------*/
		private void mnuFormat_Chart_DataLabels_None_Click(object sender, EventArgs e) {
			try { RemoveChartDataLabels(); }
			catch { }
		}

		/*-------------------------------------------------------------------------------------------------------------
		** mnuFormat_Chart_DataLabels_OutsideEnd_Click method
		** Set chart's datalabels outside and at the end.
		**-----------------------------------------------------------------------------------------------------------*/
		private void mnuFormat_Chart_DataLabels_OutsideEnd_Click(object sender, EventArgs e) {
			try { SetChartDataLabelsOutsideEnd(); }
			catch { }
		}

		/*-------------------------------------------------------------------------------------------------------------
		** mnuFormat_Chart_Axes_leftToRight_Click method
		** Set chart's axes flow direction from left to right.
		**-----------------------------------------------------------------------------------------------------------*/
		private void mnuFormat_Chart_Axes_leftToRight_Click(object sender, EventArgs e) {
			try { SetChartAxesLeftToRight(); }
			catch { }
		}

		/*-------------------------------------------------------------------------------------------------------------
		** mnuFormat_Chart_Axes_withoutLabeling_Click method
		** Hide chart's axeslabels.
		**-----------------------------------------------------------------------------------------------------------*/
		private void mnuFormat_Chart_Axes_withoutLabeling_Click(object sender, EventArgs e) {
			try { RemoveLabelsFromAxes(); }
			catch { }
		}

		/*-------------------------------------------------------------------------------------------------------------
		** mnuFormat_Chart_HorizGridlines_None_Click method
		** Hide chart's horizontal gridlines.
		**-----------------------------------------------------------------------------------------------------------*/
		private void mnuFormat_Chart_HorizGridlines_None_Click(object sender, EventArgs e) {
			try { RemoveHorizChartGridLines(); }
			catch { }
		}

		/*-------------------------------------------------------------------------------------------------------------
		** mnuFormat_Chart_HorizGridlines_Major_Click method
		** Show chart's major horizontal gridlines.
		**-----------------------------------------------------------------------------------------------------------*/
		private void mnuFormat_Chart_HorizGridlines_Major_Click(object sender, EventArgs e) {
			try { SetMajorHorizChartGridLines(); }
			catch { }
		}

		/*-------------------------------------------------------------------------------------------------------------
		** mnuFormat_Chart_HorizGridlines_Minor_Click method
		** Show chart's minor horizontal gridlines.
		**-----------------------------------------------------------------------------------------------------------*/
		private void mnuFormat_Chart_HorizGridlines_Minor_Click(object sender, EventArgs e) {
			try { SetMinorHorizChartGridLines(); }
			catch { }
		}

		/*-------------------------------------------------------------------------------------------------------------
		** mnuFormat_Chart_HorizGridlines_MajAndMin_Click method
		** Show minor and major horizontal gridlines.
		**-----------------------------------------------------------------------------------------------------------*/
		private void mnuFormat_Chart_HorizGridlines_MajAndMin_Click(object sender, EventArgs e) {
			try { SetMajAndMinHorizChartGridLines(); }
			catch { }
		}

		/*-------------------------------------------------------------------------------------------------------------
		** mnuFormat_Chart_VertGridlines_None_Click method
		** Hide chart's vertical gridlines.
		**-----------------------------------------------------------------------------------------------------------*/
		private void mnuFormat_Chart_VertGridlines_None_Click(object sender, EventArgs e) {
			try { RemoveChartGridLines(); }
			catch { }
		}

		/*-------------------------------------------------------------------------------------------------------------
		** mnuFormat_Chart_VertGridlines_Major_Click method
		** Show chart's major vertical gridlines.
		**-----------------------------------------------------------------------------------------------------------*/
		private void mnuFormat_Chart_VertGridlines_Major_Click(object sender, EventArgs e) {
			try { SetMajorVertChartGridLines(); }
			catch { }
		}

		/*-------------------------------------------------------------------------------------------------------------
		** mnuFormat_Chart_VertGridlines_Minor_Click method
		** Show chart's minor vertical gridlines.
		**-----------------------------------------------------------------------------------------------------------*/
		private void mnuFormat_Chart_VertGridlines_Minor_Click(object sender, EventArgs e) {
			try { SetMinorVertChartGridLines(); }
			catch { }
		}

		/*-------------------------------------------------------------------------------------------------------------
		** mnuFormat_Chart_VertGridlines_MajAndMin_Click method
		** Show chart's minor and major vertical gridlines.
		**-----------------------------------------------------------------------------------------------------------*/
		private void mnuFormat_Chart_VertGridlines_MajAndMin_Click(object sender, EventArgs e) {
			try { SetMajAndMinVertChartGridLines(); }
			catch { }
		}


		/*-------------------------------------------------------------------------------------------------------------
		** FORMAT  MENU -  FORMFIELDS  -  EVENTHANDLER
		**-----------------------------------------------------------------------------------------------------------*/

		/*-------------------------------------------------------------------------------------------------------------
		** mnuFormat_FormFields_DropDownOpening method
		**	Enables the delete and editing option when an formfield is available at input position.
		** Update the checkstate for the highlight button.
		**-----------------------------------------------------------------------------------------------------------*/
		private void mnuFormat_FormFields_DropDownOpening(object sender, EventArgs e) {
			try {
				mnuFormat_FormFields_Delete.Enabled =
				mnuFormat_FormFields_Properties.Enabled = (textControl.FormFields.GetItem() != null);
				mnuFormat_FormFields_ConditionalInstructions.Enabled = textControl.IsFormFieldValidationEnabled;
				mnuFormat_FormFields_IsFormFieldValidationEnabled.Checked = textControl.IsFormFieldValidationEnabled;
			}
			catch (LicenseLevelException) { }
		}


		/*-------------------------------------------------------------------------------------------------------------
		** mnuFormat_FormFields_Properties_Click method
		**	Shows a dialog for editing the formfield at input position. 
		**-----------------------------------------------------------------------------------------------------------*/
		private void mnuFormat_FormFields_Properties_Click(object sender, EventArgs e) {
			var field = textControl.FormFields.GetItem();
			if (field != null) {
				Form dlg = null;

				if (field is SelectionFormField) {
					dlg = new FormFields.SelectionFormFieldDialog((SelectionFormField)field);
				}
				else if (field is TextFormField) {
					dlg = new FormFields.TextFormFieldDialog((TextFormField)field);
				}
				else if (field is CheckFormField) {
					dlg = new FormFields.CheckFormFieldDialog((CheckFormField)field);
				}
				else if (field is DateFormField) {
					dlg = new FormFields.DateFormFieldDialog((DateFormField)field);
				}

				if (dlg != null) {
					dlg.RightToLeft = this.RightToLeft;
					dlg.ShowDialog(this);
				}
			}
		}

		/*-------------------------------------------------------------------------------------------------------------
		** mnuFormat_FormFields_Delete_Click method
		**	Deletes the field at input position.
		**-----------------------------------------------------------------------------------------------------------*/
		private void mnuFormat_FormFields_Delete_Click(object sender, EventArgs e) {
			var field = textControl.FormFields.GetItem();
			if (field != null) {
				textControl.FormFields.Remove(field);
			}
		}

		/*-------------------------------------------------------------------------------------------------------------
		** mnuFormat_FormFields_IsFormFieldValidationEnabled_Click method
		**	Switchs the enabling of form field's validation.
		**-----------------------------------------------------------------------------------------------------------*/
		private void mnuFormat_FormFields_IsFormFieldValidationEnabled_Click(object sender, EventArgs e) {
			textControl.IsFormFieldValidationEnabled = !textControl.IsFormFieldValidationEnabled;
		}

		/*-------------------------------------------------------------------------------------------------------
		**	mnuFormat_FormFields_ConditionalInstructions_Click method
		** Opens the dialog for managing the conditional-instructions.
		**-----------------------------------------------------------------------------------------------------*/
		private void mnuFormat_FormFields_ConditionalInstructions_Click(object sender, EventArgs e) {
			// Requires the enabling of form field's validation. (see Form's loaded event)
			textControl.ManageConditionalInstructionsDialog();
		}

		/*-------------------------------------------------------------------------------------------------------------
		** TABLE  MENU - EVENTHANDLER
		**-----------------------------------------------------------------------------------------------------------*/


		/*-------------------------------------------------------------------------------------------------------------
		** mnuTable_DropDownOpening method
		** Update the 'Table' menu.
		**-----------------------------------------------------------------------------------------------------------*/
		private void mnuTable_DropDownOpening(object sender, System.EventArgs e) {
			TXTextControl.Table table = textControl.Tables.GetItem();
			mnuTable_GridLines.Checked = textControl.Tables.GridLines;
			mnuTable_Select.Enabled = (table != null);
			mnuTable_Insert.Enabled = textControl.CanEdit;

			if (textControl.CanTableFormat) {
				if (table != null) {
					mnuTable_Properties.Enabled = true;
					mnuTable_Delete.Enabled = true;
					mnuTable_Split.Enabled = table.CanSplit;
					mnuTable_Merge_Cells.Enabled = table.CanMergeCells;
					mnuTable_Split_Cells.Enabled = table.CanSplitCells;
				}
				else {
					mnuTable_Properties.Enabled = false;
					mnuTable_Delete.Enabled = false;
					mnuTable_Split.Enabled = false;
					mnuTable_Merge_Cells.Enabled = false;
					mnuTable_Split_Cells.Enabled = false;
				}
			}
			else {
				mnuTable_Insert.Enabled = false;
				mnuTable_Delete.Enabled = false;
				mnuTable_Split.Enabled = false;
				mnuTable_Split_Cells.Enabled = false;
				mnuTable_Merge_Cells.Enabled = false;
				mnuTable_Properties.Enabled = false;
			}
		}

		/*-------------------------------------------------------------------------------------------------------------
		** mnuTable_Insert_DropDownOpening method
		** Update the 'Table->Insert' menu.
		**-----------------------------------------------------------------------------------------------------------*/
		private void mnuTable_Insert_DropDownOpening(object sender, System.EventArgs e) {
			mnuTable_Insert_Table.Enabled = textControl.Tables.CanAdd;

			TXTextControl.Table tableAtInputPosition = textControl.Tables.GetItem();
			if (tableAtInputPosition == null) {
				mnuTable_Insert_ColumnToTheLeft.Enabled = false;
				mnuTable_Insert_ColumnToTheRight.Enabled = false;
				mnuTable_Insert_RowAbove.Enabled = false;
				mnuTable_Insert_RowBelow.Enabled = false;
			}
			else {
				mnuTable_Insert_ColumnToTheLeft.Enabled = tableAtInputPosition.Columns.CanAdd;
				mnuTable_Insert_ColumnToTheRight.Enabled = tableAtInputPosition.Columns.CanAdd;
				mnuTable_Insert_RowAbove.Enabled = tableAtInputPosition.Rows.CanAdd;
				mnuTable_Insert_RowBelow.Enabled = tableAtInputPosition.Rows.CanAdd;
			}
		}

		/*-------------------------------------------------------------------------------------------------------------
		** mnuTable_Insert_Table_Click method
		** Insert a table.
		**-----------------------------------------------------------------------------------------------------------*/
		private void mnuTable_Insert_Table_Click(object sender, System.EventArgs e) {
			if (textControl.Tables.Add()) {
				m_fileHandler.IsDocumentDirty = true;
			}
		}

		/*-------------------------------------------------------------------------------------------------------------
		** mnuTable_Insert_ColumnToTheLeft_Click method
		** Append a column left to table. 
		**-----------------------------------------------------------------------------------------------------------*/
		private void mnuTable_Insert_ColumnToTheLeft_Click(object sender, System.EventArgs e) {
			textControl.Tables.GetItem().Columns.Add(TXTextControl.TableAddPosition.Before);
		}

		/*-------------------------------------------------------------------------------------------------------------
		** mnuTable_Insert_ColumnToTheRight_Click method
		** Append a column right to table.
		**-----------------------------------------------------------------------------------------------------------*/
		private void mnuTable_Insert_ColumnToTheRight_Click(object sender, System.EventArgs e) {
			textControl.Tables.GetItem().Columns.Add(TXTextControl.TableAddPosition.After);
		}

		/*-------------------------------------------------------------------------------------------------------------
		** mnuTable_Insert_RowAbove_Click method
		** Add row above current row.
		**-----------------------------------------------------------------------------------------------------------*/
		private void mnuTable_Insert_RowAbove_Click(object sender, System.EventArgs e) {
			textControl.Tables.GetItem().Rows.Add(TXTextControl.TableAddPosition.Before, 1);
		}

		/*-------------------------------------------------------------------------------------------------------------
		** mnuTable_Insert_RowBelow_Click method
		** Add row below current row.
		**-----------------------------------------------------------------------------------------------------------*/
		private void mnuTable_Insert_RowBelow_Click(object sender, System.EventArgs e) {
			textControl.Tables.GetItem().Rows.Add(TXTextControl.TableAddPosition.After, 1);
		}

		/*-------------------------------------------------------------------------------------------------------------
		** mnuTable_Delete_DropDownOpening method
		** Update the 'Table->Delete' menu.
		**-----------------------------------------------------------------------------------------------------------*/
		private void mnuTable_Delete_DropDownOpening(object sender, System.EventArgs e) {
			TXTextControl.Table tableAtInputPosition = textControl.Tables.GetItem();

			if (tableAtInputPosition == null) {
				mnuTable_Delete_Table.Enabled = false;
				mnuTable_Delete_Column.Enabled = false;
				mnuTable_Delete_Rows.Enabled = false;
				mnuTable_Delete_Cells.Enabled = false;
			}
			else {
				mnuTable_Delete_Table.Enabled = tableAtInputPosition.Columns.CanRemove;
				mnuTable_Delete_Column.Enabled = tableAtInputPosition.Columns.CanRemove;
				mnuTable_Delete_Rows.Enabled = tableAtInputPosition.Rows.CanRemove;
				mnuTable_Delete_Cells.Enabled = tableAtInputPosition.Cells.CanRemove;
				mnuTable_Delete_Cells_entireColumn.Enabled = tableAtInputPosition.Columns.CanRemove;
				mnuTable_Delete_Cells_entireRow.Enabled = tableAtInputPosition.Rows.CanRemove;
			}
		}

		/*-------------------------------------------------------------------------------------------------------------
		** mnuTable_Delete_Table_Click method
		** Delete table.
		**-----------------------------------------------------------------------------------------------------------*/
		private void mnuTable_Delete_Table_Click(object sender, System.EventArgs e) {
			textControl.Tables.Remove();
		}

		/*-------------------------------------------------------------------------------------------------------------
		** mnuTable_Delete_Column_Click method
		** Delete column.
		**-----------------------------------------------------------------------------------------------------------*/
		private void mnuTable_Delete_Column_Click(object sender, System.EventArgs e) {
			textControl.Tables.GetItem().Columns.Remove();
		}

		/*-------------------------------------------------------------------------------------------------------------
		** mnuTable_Delete_Rows_Click method
		** Delete table's rows in selection.
		**-----------------------------------------------------------------------------------------------------------*/
		private void mnuTable_Delete_Rows_Click(object sender, System.EventArgs e) {
			textControl.Tables.GetItem().Rows.Remove();
		}

		/*-------------------------------------------------------------------------------------------------------------
		** mnuTable_Delete_Cells_shiftLeft_Click method
		** Delete selected cells.
		**-----------------------------------------------------------------------------------------------------------*/
		private void mnuTable_Delete_Cells_shiftLeft_Click(object sender, EventArgs e) {
			textControl.Tables.GetItem().Cells.Remove();
		}

		/*-------------------------------------------------------------------------------------------------------------
		** mnuTable_Delete_Cells_entireRow_Click method
		** Delete entire row.
		**-----------------------------------------------------------------------------------------------------------*/
		private void mnuTable_Delete_Cells_entireRow_Click(object sender, EventArgs e) {
			textControl.Tables.GetItem().Rows.Remove();
		}

		/*-------------------------------------------------------------------------------------------------------------
		** mnuTable_Delete_Cells_entireColumn_Click method
		** Delete entire column.
		**-----------------------------------------------------------------------------------------------------------*/
		private void mnuTable_Delete_Cells_entireColumn_Click(object sender, EventArgs e) {
			textControl.Tables.GetItem().Columns.Remove();
		}

		/*-------------------------------------------------------------------------------------------------------------
		** mnuTable_Merge_Cells_Click method
		** Merge table's cells.
		**-----------------------------------------------------------------------------------------------------------*/
		private void mnuTable_Merge_Cells_Click(object sender, EventArgs e) {
			textControl.Tables.GetItem().MergeCells();
		}

		/*-------------------------------------------------------------------------------------------------------------
		** mnuTable_Split_Cells_Click method
		** Split cells.
		**-----------------------------------------------------------------------------------------------------------*/
		private void mnuTable_Split_Cells_Click(object sender, EventArgs e) {
			textControl.Tables.GetItem().SplitCells();
		}

		/*-------------------------------------------------------------------------------------------------------------
		** mnuTable_Split_DropDownOpening method
		** Update the 'Table->Split' menu.
		**-----------------------------------------------------------------------------------------------------------*/
		private void mnuTable_Split_DropDownOpening(object sender, EventArgs e) {
			TXTextControl.Table tableAtInputPosition = textControl.Tables.GetItem();

			if (tableAtInputPosition == null) {
				mnuTable_Split_Above.Enabled = false;
				mnuTable_Split_Below.Enabled = false;
			}
			else {
				mnuTable_Split_Above.Enabled = true;
				mnuTable_Split_Below.Enabled = true;
			}

		}

		/*-------------------------------------------------------------------------------------------------------------
		** mnuTable_Split_Above_Click method
		** Split the table above.
		**-----------------------------------------------------------------------------------------------------------*/
		private void mnuTable_Split_Above_Click(object sender, System.EventArgs e) {
			textControl.Tables.GetItem().Split(TXTextControl.TableAddPosition.Before);
		}

		/*-------------------------------------------------------------------------------------------------------------
		** mnuTable_Split_Below_Click method
		** Split the table below.
		**-----------------------------------------------------------------------------------------------------------*/
		private void mnuTable_Split_Below_Click(object sender, System.EventArgs e) {
			textControl.Tables.GetItem().Split(TXTextControl.TableAddPosition.After);
		}

		/*-------------------------------------------------------------------------------------------------------------
		** mnuTable_Select_DropDownOpening method
		** Update the 'Table->Select' menu.
		**-----------------------------------------------------------------------------------------------------------*/
		private void mnuTable_Select_DropDownOpening(object sender, System.EventArgs e) {
			TXTextControl.Table tableAtInputPosition = null;
			TXTextControl.TableRow rowAtInputPosition = null;
			TXTextControl.TableCell cellAtInputPosition = null;
			TXTextControl.TableColumn columnAtInputPosition = null;

			tableAtInputPosition = textControl.Tables.GetItem();
			if (tableAtInputPosition != null) {
				rowAtInputPosition = tableAtInputPosition.Rows.GetItem();
				cellAtInputPosition = tableAtInputPosition.Cells.GetItem();
				columnAtInputPosition = tableAtInputPosition.Columns.GetItem();
			}

			mnuTable_Select_Table.Enabled = (tableAtInputPosition != null);
			mnuTable_Select_Row.Enabled = (rowAtInputPosition != null);
			mnuTable_Select_Cell.Enabled = (cellAtInputPosition != null);
			mnuTable_Select_Column.Enabled = (columnAtInputPosition != null);
		}

		/*-------------------------------------------------------------------------------------------------------------
		** mnuTable_Select_Table_Click method
		** Select the whole table.
		**-----------------------------------------------------------------------------------------------------------*/
		private void mnuTable_Select_Table_Click(object sender, System.EventArgs e) {
			textControl.Tables.GetItem().Select();
		}

		/*-------------------------------------------------------------------------------------------------------------
		** mnuTable_Select_Row_Click method
		** Selects the row.
		**-----------------------------------------------------------------------------------------------------------*/
		private void mnuTable_Select_Row_Click(object sender, System.EventArgs e) {
			textControl.Tables.GetItem().Rows.GetItem().Select();
		}

		/*-------------------------------------------------------------------------------------------------------------
		** mnuTable_Select_Column_Click method
		** Selects the column.
		**-----------------------------------------------------------------------------------------------------------*/
		private void mnuTable_Select_Column_Click(object sender, EventArgs e) {
			textControl.Tables.GetItem().Columns.GetItem().Select();
		}

		/*-------------------------------------------------------------------------------------------------------------
		** mnuTable_Select_Cell_Click method
		** Selects the cell.
		**-----------------------------------------------------------------------------------------------------------*/
		private void mnuTable_Select_Cell_Click(object sender, System.EventArgs e) {
			textControl.Tables.GetItem().Cells.GetItem().Select();
		}

		/*-------------------------------------------------------------------------------------------------------------
		** mnuTable_GridLines_Click method
		** Show/hide table's gridlines.
		**-----------------------------------------------------------------------------------------------------------*/
		private void mnuTable_GridLines_Click(object sender, System.EventArgs e) {
			textControl.Tables.GridLines = !textControl.Tables.GridLines;
		}

		/*-------------------------------------------------------------------------------------------------------------
		** mnuTable_Properties_Click method
		** Show dialog for editing the table's format.
		**-----------------------------------------------------------------------------------------------------------*/
		private void mnuTable_Properties_Click(object sender, System.EventArgs e) {
			textControl.TableFormatDialog();
		}

		/*-------------------------------------------------------------------------------------------------------------
		** mnuTable_Formulas_DropDownOpening method
		** Update 'Formulas' menu.
		**-----------------------------------------------------------------------------------------------------------*/
		private void mnuTable_Formulas_DropDownOpening(object sender, EventArgs e) {
			try {
				mnuTable_Formulas_A1Style.Checked = textControl.FormulaReferenceStyle == FormulaReferenceStyle.A1;
				mnuTable_Formulas_R1C1Style.Checked = textControl.FormulaReferenceStyle == FormulaReferenceStyle.R1C1;
				mnuTable_Formulas_EditFormula.Enabled = textControl.Tables.GetItem() != null;
				mnuTable_Formulas_AutomaticCalculation.Checked = textControl.IsFormulaCalculationEnabled;
			}
			catch (LicenseLevelException) { }
		}

		/*-------------------------------------------------------------------------------------------------------------
		** mnuTable_Formulas_A1Style_Click method
		** Set the formula's referencestyle to A1.
		**-----------------------------------------------------------------------------------------------------------*/
		private void mnuTable_Formulas_A1Style_Click(object sender, EventArgs e) {
			textControl.FormulaReferenceStyle = FormulaReferenceStyle.A1;
		}

		/*-------------------------------------------------------------------------------------------------------------
		** mnuTable_Formulas_R1C1Style_Click method
		** Set the formula's referencestyle to R1C1.
		**-----------------------------------------------------------------------------------------------------------*/
		private void mnuTable_Formulas_R1C1Style_Click(object sender, EventArgs e) {
			textControl.FormulaReferenceStyle = FormulaReferenceStyle.R1C1;
		}

		/*-------------------------------------------------------------------------------------------------------------
		** mnuTable_Formulas_EditFormula_Click method
		** Show dialog for editing the formula.
		**-----------------------------------------------------------------------------------------------------------*/
		private void mnuTable_Formulas_EditFormula_Click(object sender, EventArgs e) {
			int tabGroupIDFormula = 2;
			textControl.TableFormatDialog(tabGroupIDFormula);
		}

		/*-------------------------------------------------------------------------------------------------------------
		** mnuTable_Formulas_AutomaticCalculation_Click method
		** Turn on/off the automatic calculation of formulas.
		**-----------------------------------------------------------------------------------------------------------*/
		private void mnuTable_Formulas_AutomaticCalculation_Click(object sender, EventArgs e) {
			textControl.IsFormulaCalculationEnabled = mnuTable_Formulas_AutomaticCalculation.Checked;
		}


		/*-------------------------------------------------------------------------------------------------------------
		** HELP  MENU - EVENTHANDLER
		**-----------------------------------------------------------------------------------------------------------*/

		/*-------------------------------------------------------------------------------------------------------------
		** mnuHelp_AboutTXTextControlWords_Click method
		** Show dialog with information about this application.
		**-----------------------------------------------------------------------------------------------------------*/
		private void mnuHelp_AboutTXTextControlWords_Click(object sender, EventArgs e) {
			AboutBox.Show(this, textControl.GetVersionInfo());
		}


		/*-------------------------------------------------------------------------------------------------------------
		** HELPERS
		**-----------------------------------------------------------------------------------------------------------*/

		/*-------------------------------------------------------------------------------------------------------
		** IsFormLayoutRigthToLeft method
		** Calculates whether the form's orientation is set to 'right to left'.
		**-----------------------------------------------------------------------------------------------------*/
		private bool IsFormLayoutRightToLeft() {
			switch (this.RightToLeft) {
				case System.Windows.Forms.RightToLeft.Yes:
					return true;
				case System.Windows.Forms.RightToLeft.No:
					return false;
				default:
					// Check system's settings
					return CultureInfo.CurrentUICulture.TextInfo.IsRightToLeft;
			}
		}

	}

	public static partial class ToolbarExtensions {

		public static void UpdateImage(this ToolStripMenuItem menuItem, float dpi) {

			string strTxItem = menuItem.Tag as string;

			if(strTxItem != null)
			{
				if (strTxItem.StartsWith("TXITEM_"))
				{
					// Set small image by using ResourceProvider
					menuItem.ImageScaling = ToolStripItemImageScaling.None;
					menuItem.Image = ResourceProvider.GetSmallIcon(strTxItem, dpi);
				}
				else if (strTxItem.StartsWith("TXIMAGE_"))
				{
					// Remove prefix which indicates the image is embedded in the project.
					menuItem.Image = Images.GetIcon(strTxItem.Replace("TXIMAGE_", ""));
					menuItem.ImageScaling = ToolStripItemImageScaling.None;
				}
			}
		}
	}
}
