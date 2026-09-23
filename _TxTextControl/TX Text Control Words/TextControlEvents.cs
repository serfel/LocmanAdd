/*-------------------------------------------------------------------------------------------------------------
** program:			TX Text Control Words
** description:	Implements a typical word processing application build up on the main features of TextControl's Components. 
**
** copyright:		© Text Control GmbH
**-----------------------------------------------------------------------------------------------------------*/
using System;
using System.Windows.Forms;
using System.Drawing;
using System.Linq;
using TXTextControl.DataVisualization;
using TXTextControl;
using TXTextControl.Windows.Forms;
using TX_Text_Control_Words.Properties;

namespace TX_Text_Control_Words {

	/*-------------------------------------------------------------------------------------------------------------
	** partial class MainWindow
	** Capsulates the events of MainWindow's TextControl.
	**-----------------------------------------------------------------------------------------------------------*/
	public partial class MainWindow : Form {

		/*-------------------------------------------------------------------------------------------------------------
		** E V E N T H A N D L E R
		**-----------------------------------------------------------------------------------------------------------*/

		/*-------------------------------------------------------------------------------------------------------------
		** TextControl_GotFocus method
		**	Update the toolstrip.
		**-----------------------------------------------------------------------------------------------------------*/
		private void TextControl_GotFocus(object sender, EventArgs e) {
			UpdateToolstripState();
		}

		/*-------------------------------------------------------------------------------------------------------------
		** TextControl_Changed method
		**	Update the toolstrip and updates the filehandler's dirty state because the filehandler doesn't observe
		** the TextControl.
		**-----------------------------------------------------------------------------------------------------------*/
		private void TextControl_Changed(object sender, EventArgs e) {
			m_fileHandler.IsDocumentDirty = true;
			UpdateToolstripState();
		}

		/*-------------------------------------------------------------------------------------------------------------
		** TextControl_InputPositionChanged method
		**	Update the toolstrip.
		**-----------------------------------------------------------------------------------------------------------*/
		private void TextControl_InputPositionChanged(object sender, EventArgs e) {
			UpdateToolstripState();
		}

		/*-------------------------------------------------------------------------------------------------------------
		** TextControl_DocumentLoaded method
		**	Update the toolstrip.
		**-----------------------------------------------------------------------------------------------------------*/
		private void TextControl_DocumentLoaded(object sender, EventArgs e) {
			UpdateToolstripState();
		}

		/*-------------------------------------------------------------------------------------------------------------
		** TextControl_ContentsReset method
		**	Update the toolstrip.
		**-----------------------------------------------------------------------------------------------------------*/
		private void TextControl_ContentsReset(object sender, EventArgs e) {
			UpdateToolstripState();
		}

		/*-------------------------------------------------------------------------------------------------------------
		** TextControl_KeyDown method
		**-----------------------------------------------------------------------------------------------------------*/
		private void TextControl_KeyDown(object sender, KeyEventArgs e) {
			HandleKeyDownEvent(e);
		}

		/*-------------------------------------------------------------------------------------------------------------
		** TextControl_TextContextMenuOpening method
		** Shows a customized contextmenu if TextControl is editable.
		** Show a contextmenu for application fields if a application field is selected.
		** Else if a ChartFrame is selected then append an entry to build-in menu for showing a dialog to edit 
		** this ChartFrame.
		**-----------------------------------------------------------------------------------------------------------*/
		private void TextControl_TextContextMenuOpening(object sender, TXTextControl.TextContextMenuEventArgs e) {
			// Showing different context menus depending on the selected items
			if (!textControl.CanEdit) return;
			if ((e.ContextMenuLocation & TXTextControl.ContextMenuLocation.TextField) != 0) {

				// FORM FIELDS
				var formField = textControl.FormFields.GetItem();
				if (formField != null) {
					AddFormFieldContextMenuItems(e.TextContextMenu, formField);
				}

				// APPLICATION FIELDS
				var appField = textControl.ApplicationFields.GetItem();
				if (appField != null) {
					// Separator
					e.TextContextMenu.Items.Add(new ToolStripSeparator());

					// Field Properties
					e.TextContextMenu.Items.Add(
						ResourceProvider.GetText("TXITEM_FieldProperties") + "...",
						ResourceProvider.GetSmallIcon("TXITEM_FieldProperties", DeviceDpi),
						(ctxMenuItem_FieldProperties, eArgsFieldProperties) => FieldSettings());

					// Delete Field
					e.TextContextMenu.Items.Add(
						ResourceProvider.GetText("TXITEM_DeleteField") + "...",
						ResourceProvider.GetSmallIcon("TXITEM_DeleteField", DeviceDpi),
						(ctxMenuItem_DeleteField, eArgsDeleteField) => DeleteField());
				}
			}

			if ((e.ContextMenuLocation & TXTextControl.ContextMenuLocation.SelectedFrame) != 0) {
				// Populate TextContol's buildin context menu

				// FRAME OBJECT
				var frame = textControl.Frames.GetItem();
				if (frame != null) {
					AddNameContextMenuItems(e.TextContextMenu);

					// CHARTFRAME
					if (frame is ChartFrame) {
						AddChartContextMenuItems(e.TextContextMenu);
					}
				}

			}
		}


		/*-------------------------------------------------------------------------------------------------------------
		** TextControl_HypertextLinkClicked method
		** Open the hypertextlink.
		**-----------------------------------------------------------------------------------------------------------*/
		private void TextControl_HypertextLinkClicked(object sender, TXTextControl.HypertextLinkEventArgs e) {
			OpenHyperlink(e.HypertextLink.Target);
		}

		/*-------------------------------------------------------------------------------------------------------------
		** TextControl_DragDrop method
		** If file is a document then open this else if file is an image then insert the image at mouse position.
		**-----------------------------------------------------------------------------------------------------------*/
		private void TextControl_DragDrop(object sender, DragEventArgs e) {
			if (m_fileDragDropHandler.CanDrop) {
				switch (m_fileDragDropHandler.FileType) {
					case FileDragDropHandler.DraggedFileType.Document:
						OpenDroppedDocument();
						break;

					case FileDragDropHandler.DraggedFileType.Image:
						InsertDroppedImage(e);
						break;
				}
			}
		}

		/*-------------------------------------------------------------------------------------------------------------
		** TextControl_DragEnter method
		** Reinitialize the DragDropHandler for the new started drag action.
		**-----------------------------------------------------------------------------------------------------------*/
		private void TextControl_DragEnter(object sender, DragEventArgs e) {
			m_fileDragDropHandler.Reset();
			m_fileDragDropHandler.CheckDraggedFiles((string[])e.Data.GetData(DataFormats.FileDrop));
		}

		/*-------------------------------------------------------------------------------------------------------------
		** TextControl_DragOver method
		** The dragdrop handler handles which effect should be shown for the drag over action.
		**-----------------------------------------------------------------------------------------------------------*/
		private void TextControl_DragOver(object sender, DragEventArgs e) {
			if (m_fileDragDropHandler.CanDrop) {
				e.Effect = m_fileDragDropHandler.GetDragDropEffect(e.AllowedEffect);
			}
		}

		/*-------------------------------------------------------------------------------------------------------------
		** HandleKeyDownEvent method
		** Handles a keydown event by analyzing the KeyEventArgs.
		** On key:
		**		Insert		: Switch TextControl's Insertion between Overwrite and Insert
		**		Ctrl-A		: Select all
		**		Ctrl-S		: Save
		**		Ctrl-O		: Show dialog for opening documents
		**		Ctrl-F		: Show UI for find
		**-----------------------------------------------------------------------------------------------------------*/
		private void HandleKeyDownEvent(KeyEventArgs e) {
			switch (e.KeyCode) {
				case Keys.Insert:
					// Toggle insertion mode
					if (e.Control || e.Alt || e.Shift) break;
					textControl.InsertionMode
						= textControl.InsertionMode == TXTextControl.InsertionMode.Insert
						? TXTextControl.InsertionMode.Overwrite
						: TXTextControl.InsertionMode.Insert;
					break;
			}
		}

		/*-------------------------------------------------------------------------------------------------------------
		** OpenDroppedDocument method
		** Opens the dropped document by using the filehandler for opening and the link provided by the drag n' drop
		** handler.
		**-----------------------------------------------------------------------------------------------------------*/
		private void OpenDroppedDocument() {
			m_fileHandler.Open(m_fileDragDropHandler.FileName);
		}

		/*-------------------------------------------------------------------------------------------------------------
		** InsertDroppedImage method
		** Try to insert the referenced file provided by the drag N' drop handler as an anchored image.
		** The image is anchored to the nearest paragraph of the mouse position. Place the image at the 
		** mouse position.
		**-----------------------------------------------------------------------------------------------------------*/
		private void InsertDroppedImage(DragEventArgs e) {
			// Get pixel position of mouse cursor inside Text Control
			Point posCursor = textControl.PointToClient(Cursor.Position);

			// Get bounding rectangle of the first character of the paragraph
			// the image was dropped over
			TXTextControl.Paragraph par = textControl.Paragraphs.GetItem(posCursor);
			TXTextControl.TextChar charParStart = textControl.TextChars[par.Start];
			Rectangle rPar = (charParStart != null) ? charParStart.Bounds : new Rectangle();

			// Get bounding rectangle of the character the image was dropped over
			TXTextControl.TextChar txChar = textControl.TextChars.GetItem(posCursor, true);
			Rectangle rChar = (txChar != null) ? txChar.Bounds : new Rectangle();

			// Calculate image position relative to paragraph position
			var posImg = new Point(rChar.Left - rPar.Left + rChar.Width, rChar.Top - rPar.Top);

			// Insert image anchored to paragraph
			var txImg = new TXTextControl.Image() { FileName = m_fileDragDropHandler.FileName };
			textControl.Images.Add(txImg, posImg, par.Start, TXTextControl.ImageInsertionMode.DisplaceText);
		}

		/*-------------------------------------------------------------------------------------------------------------
		** AddFormFieldContextMenuItems method
		** Append an item to contextmenu for setting FormField's properties.
		**-----------------------------------------------------------------------------------------------------------*/
		private void AddFormFieldContextMenuItems(ContextMenuStrip contextMenuStrip, FormField field) {
			// Separator
			contextMenuStrip.Items.Add(new ToolStripSeparator());

			// Properties
			contextMenuStrip.Items.Add(Resources.CONTEXTMENU_FORMFIELDS_TEXT,
				ResourceProvider.GetSmallIcon("TXITEM_InsertFormFieldsGroup", DeviceDpi),
				// Show dialog for editing the formfield's properties.
				(sender, e) => {
					Form dlg = null;
					if (field is SelectionFormField) {
						dlg = new FormFields.SelectionFormFieldDialog((SelectionFormField)field)
						{
							Text = field.Editable ? Resources.SELECTIONFORMFIELD_DLG_COMBOBOX_TITLE : Resources.SELECTIONFORMFIELD_DLG_DROPDOWN_TITLE
						};
					}
					else if (field is CheckFormField) {
						dlg = new FormFields.CheckFormFieldDialog((CheckFormField)field);
					}
					else if (field is TextFormField) {
						dlg = new FormFields.TextFormFieldDialog((TextFormField)field);
					}
					else if (field is DateFormField) {
						dlg = new FormFields.DateFormFieldDialog((DateFormField)field);
					}

					if (dlg != null) {
						dlg.RightToLeft = this.RightToLeft;
						dlg.ShowDialog(this);
					}
				}
			);
		}

		/*-------------------------------------------------------------------------------------------------------------
		** AddNameContextMenuItems method
		** Append a item to contextmenustrip for providing a possiblity to edit an object's name.
		**-----------------------------------------------------------------------------------------------------------*/
		private void AddNameContextMenuItems(ContextMenuStrip contextMenuStrip) {
			// Separator
			contextMenuStrip.Items.Add(new ToolStripSeparator());

			// Name 
			contextMenuStrip.Items.Add(
				Properties.Resources.strObjectName,
				ResourceProvider.GetSmallIcon("TXITEM_ObjectName", DeviceDpi), SetObjectName);
		}

		/*-------------------------------------------------------------------------------------------------------------
		** SetObjectName method
		** Show a dialog for editing the name of the selected frame.
		**-----------------------------------------------------------------------------------------------------------*/
		private void SetObjectName(object sender, EventArgs e) {
			ShowObjectNameDialog(textControl.Frames.GetItem());
		}

		/*-------------------------------------------------------------------------------------------------------------
		** ShowObjectNameDialog method
		** Show a dialog for editing the object's name.
		**-----------------------------------------------------------------------------------------------------------*/
		private void ShowObjectNameDialog(TXTextControl.FrameBase obj) {
			if (obj == null) return;

			string strName = obj.Name;
			if (InputBoxDialog.ShowInputBox(Resources.INPUTBOXDLG_SETOBJECTNAME_TITLE, ref strName, this, true)) {
				obj.Name = strName;
			}
		}

		/*-------------------------------------------------------------------------------------------------------------
		** AddChartContextMenuItems method
		** Append a item to contextmenustrip for providing an option to edit the data of the selected chart.
		**-----------------------------------------------------------------------------------------------------------*/
		private void AddChartContextMenuItems(ContextMenuStrip contextMenuStrip) {
			contextMenuStrip.Items.Add(new ToolStripSeparator());    // Separator

			// Chart data
			contextMenuStrip.Items.Add(
				Properties.Resources.strChartEditDataMenuItemName,
				ResourceProvider.GetSmallIcon("TXITEM_InsertShape", DeviceDpi),
				EditChartData
			);
		}

		/*-------------------------------------------------------------------------------------------------------------
		** EditChartData method
		** Show a dialog for editing the data of the selected chart.
		**-----------------------------------------------------------------------------------------------------------*/
		private void EditChartData(object sender, EventArgs e) {
			EditChartData();
		}
	}

	/*-------------------------------------------------------------------------------------------------------------
	** static class EditableRegionExtensions
	** Capsulates all extension methods related to TX Text Control's EditableRegions.
	**-----------------------------------------------------------------------------------------------------------*/
	internal static class EditableRegionExtensions {

		// EditableRegion._Equals
		// Compares user name, start position and region length
		public static bool _Equals(this EditableRegion region, EditableRegion other) {
			return (region.Start == other.Start) && (region.Length == other.Length)
				&& ((region.UserName == other.UserName) || (string.IsNullOrEmpty(region.UserName) && string.IsNullOrEmpty(other.UserName)));
		}

		/*-------------------------------------------------------------------------------------------------------------
		** EditableRegionCollection.Remove method
		** Remove the first EditableRegion from the collection where the username is equal to the passed username.
		**-----------------------------------------------------------------------------------------------------------*/
		public static EditableRegion Remove(this EditableRegionCollection editableRegionCollection, bool selectedPart, string username = "") {
			TXTextControl.EditableRegion toRemove = editableRegionCollection.GetItem(username);
			if (toRemove != null) {
				editableRegionCollection.Remove(toRemove, selectedPart);
			}
			return toRemove;
		}

		/*-------------------------------------------------------------------------------------------------------------
		** EditableRegionCollection.GetItem method
		** Returns the first EditableRegion from the collection where the username is equal to the passed username.
		** Else returns null if such EditableRegion is not available.
		**-----------------------------------------------------------------------------------------------------------*/
		public static EditableRegion GetItem(this EditableRegionCollection editableRegionCollection, string username = "") {
			EditableRegion[] currentEditableRegions = editableRegionCollection.GetItems();
			// Find current editable region matching the username
			if (string.IsNullOrEmpty(username)) {
				return currentEditableRegions.FirstOrDefault(r => string.IsNullOrEmpty(r.UserName));
			}
			else {
				return currentEditableRegions.FirstOrDefault(r => r.UserName == username);
			}
		}
	}
}
