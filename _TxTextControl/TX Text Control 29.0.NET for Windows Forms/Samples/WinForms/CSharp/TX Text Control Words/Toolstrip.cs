/*-------------------------------------------------------------------------------------------------------------
** program:			TX Text Control Words
** description:	Implements a typical word processing application build up on the main features of TextControl's Components. 
**
** copyright:		© Text Control GmbH
**-----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TXTextControl.Windows.Forms;

namespace TX_Text_Control_Words {

	/*-------------------------------------------------------------------------------------------------------------
	** partial class MainWindow
	** Capsulates all functionalities related to the MainWindow's Toolstrip.
	**-----------------------------------------------------------------------------------------------------------*/
	partial class MainWindow {

		/*-------------------------------------------------------------------------------------------------------------
		** M E T H O D S
		**-----------------------------------------------------------------------------------------------------------*/

		/*-------------------------------------------------------------------------------------------------------------
		** UpdateToolstripState method
		**	Update the ToolStrip's buttons.
		**-----------------------------------------------------------------------------------------------------------*/
		private void UpdateToolstripState() {
			mnuBtnCopy.Enabled = textControl.CanCopy;
			mnuBtnCut.Enabled = textControl.CanCopy && textControl.CanEdit;
			mnuBtnPaste.Enabled = textControl.CanPaste;
			mnuBtnUndo.Enabled = textControl.CanUndo;
			mnuBtnRedo.Enabled = textControl.CanRedo;
			mnuBtnColumns.Enabled = textControl.CanEdit;
			mnuBtnMarginsAndPaper.Enabled = textControl.CanEdit;
			mnuBtnHeadersAndFooters.Enabled = textControl.CanEdit;
			mnuBtnPageBorders.Enabled = textControl.CanEdit;
			mnuBtnSelectObjects.Checked = textControl.SelectObjects;
		}

		/*-------------------------------------------------------------------------------------------------------------
		** LocalizeToolstrip method
		** Sets the local texts of all buttons.
		**-----------------------------------------------------------------------------------------------------------*/
		private void LocalizeToolstrip() {
			foreach (var item in toolStrip.Items) {
				if (item.GetType() == typeof(ToolStripButton)) { // Filtering ToolStripButtons
					ToolStripButton toolStripButton = (ToolStripButton)item;

					toolStripButton.ImageScaling = ToolStripItemImageScaling.None;

					// Text
					//		Format of resource for menu's text: ToolStripMenuItem.Name.ToUpper() + "_" + TEXT
					string resource = toolStripButton.Name.ToUpper() + "_" + "TEXT";
					try {
						toolStripButton.ToolTipText = Properties.Resources.ResourceManager.GetString(resource);
					}
					catch {
						Debug.WriteLine(toolStripButton.Name + String.Format(": Resource not found by {0}", resource));
					}

				}
			}
		}

		/*-------------------------------------------------------------------------------------------------------------
		** UpdateToolstripImages method
		** Update toolstrip's images by using the menu item's tag which specifies the image's source.
		**		Item's tag prefixed with 
		**			- 'TXITEM_' specifies to set the image by using TX TextControl's ImageProvider.
		**			- 'TXIMAGE_' specifies to set the image by using the embedded resources.
		**-----------------------------------------------------------------------------------------------------------*/
		private void UpdateToolstripImages()
		{
			foreach (var toolStripButton in toolStrip.Items.OfType<ToolStripButton>())
			{
				var tag = toolStripButton.Tag as string;

				if (tag != null && tag.StartsWith("TXITEM_"))
				{
					toolStripButton.ImageScaling = ToolStripItemImageScaling.None;
					toolStripButton.Apply(tag, toolStrip.DeviceDpi);
				}
			}
		}

		/*-------------------------------------------------------------------------------------------------------------
		** E V E N T H A N D L E R S
		**-----------------------------------------------------------------------------------------------------------*/

		/*-------------------------------------------------------------------------------------------------------------
		** mnuBtnNewFile_Click method
		** Create a new document.
		**-----------------------------------------------------------------------------------------------------------*/
		private void mnuBtnNewFile_Click(object sender, EventArgs e) {
			FileNew();
		}

		/*-------------------------------------------------------------------------------------------------------------
		** mnuBtnOpenFile_Click method
		** Open file as document and load content in TextControl.
		**-----------------------------------------------------------------------------------------------------------*/
		private void mnuBtnOpenFile_Click(object sender, EventArgs e) {
			FileOpen();
		}

		/*-------------------------------------------------------------------------------------------------------------
		** mnuBtnSave_Click method
		** Override loaded file else show dialog for saving document to new file.
		**-----------------------------------------------------------------------------------------------------------*/
		private void mnuBtnSave_Click(object sender, EventArgs e) {
			FileSave();
		}

		/*-------------------------------------------------------------------------------------------------------------
		** mnuBtnOpenFile_Click method
		** Open a file as document.
		**-----------------------------------------------------------------------------------------------------------*/
		private void mnuBtnPrint_Click(object sender, EventArgs e) {
			Print();
		}

		/*-------------------------------------------------------------------------------------------------------------
		** mnuBtnPrintPreview_Click method
		** Print preview.
		**-----------------------------------------------------------------------------------------------------------*/
		private void mnuBtnPrintPreview_Click(object sender, EventArgs e) {
			PrintPreview();
		}

		/*-------------------------------------------------------------------------------------------------------------
		** mnuBtnCut_Click method
		** Remove selection and copy to clipboard
		**-----------------------------------------------------------------------------------------------------------*/
		private void mnuBtnCut_Click(object sender, EventArgs e) {
			textControl.Cut();
		}

		/*-------------------------------------------------------------------------------------------------------------
		** mnuBtnCopy_Click method
		** Copy selection to clipboard.
		**-----------------------------------------------------------------------------------------------------------*/
		private void mnuBtnCopy_Click(object sender, EventArgs e) {
			textControl.Copy();
		}

		/*-------------------------------------------------------------------------------------------------------------
		** mnuBtnPaste_Click method
		** Paste data from clipboard.
		**-----------------------------------------------------------------------------------------------------------*/
		private void mnuBtnPaste_Click(object sender, EventArgs e) {
			textControl.Paste();
		}

		/*-------------------------------------------------------------------------------------------------------------
		** mnuBtnUndo_Click method
		** Undo document change.
		**-----------------------------------------------------------------------------------------------------------*/
		private void mnuBtnUndo_Click(object sender, EventArgs e) {
			textControl.Undo();
		}

		/*-------------------------------------------------------------------------------------------------------------
		** mnuBtnRedo_Click method
		** Redo document operation.
		**-----------------------------------------------------------------------------------------------------------*/
		private void mnuBtnRedo_Click(object sender, EventArgs e) {
			textControl.Redo();
		}

		/*-------------------------------------------------------------------------------------------------------------
		** mnuBtnFind_Click method
		** Show dialog for searching.
		**-----------------------------------------------------------------------------------------------------------*/
		private void mnuBtnFind_Click(object sender, EventArgs e) {
			textControl.Find();
		}

		/*-------------------------------------------------------------------------------------------------------------
		** mnuBtnMarginsAndPaper_Click method
		** Show dialog for editing the document's margins and paper settings.
		**-----------------------------------------------------------------------------------------------------------*/
		private void mnuBtnMarginsAndPaper_Click(object sender, EventArgs e) {
			try {
				textControl.SectionFormatDialog(0);
			}
			catch (Exception ex) {
				MessageBox.Show(ex.Message, ProductName);
			}
		}

		/*-------------------------------------------------------------------------------------------------------------
		** mnuBtnOpenFile_Click method
		** Show dialog for editing the header's or footer's format.
		**-----------------------------------------------------------------------------------------------------------*/
		private void mnuBtnHeadersAndFooters_Click(object sender, EventArgs e) {
			try {
				textControl.SectionFormatDialog(1);
			}
			catch (Exception ex) {
				MessageBox.Show(ex.Message, ProductName);
			}
		}

		/*-------------------------------------------------------------------------------------------------------------
		** mnuBtnColumns_Click method
		** Show dialog for editing the page's column settings.
		**-----------------------------------------------------------------------------------------------------------*/
		private void mnuBtnColumns_Click(object sender, EventArgs e) {
			try {
				textControl.SectionFormatDialog(2);
			}
			catch (Exception ex) {
				MessageBox.Show(ex.Message, ProductName);
			}
		}

		/*-------------------------------------------------------------------------------------------------------------
		** mnuBtnPageBorders_Click method
		** Show dialog for editing the pageborder's setting.
		**-----------------------------------------------------------------------------------------------------------*/
		private void mnuBtnPageBorders_Click(object sender, EventArgs e) {
			try {
				textControl.SectionFormatDialog(3);
			}
			catch (Exception ex) {
				MessageBox.Show(ex.Message, ProductName);
			}
		}

		/*-------------------------------------------------------------------------------------------------------------
		** mnuBtnSelectObjects_Click method
		** Sets TextControl's selection mode to a mode for enable the selection of objects via click.
		**-----------------------------------------------------------------------------------------------------------*/
		private void mnuBtnSelectObjects_Click(object sender, EventArgs e) {
			if (mnuBtnSelectObjects.Checked) textControl.SelectObjects = false;
			else textControl.SelectObjects = true;
			mnuBtnSelectObjects.Checked = !mnuBtnSelectObjects.Checked;
		}

		/*-------------------------------------------------------------------------------------------------------------
		** mnuBtnInserBreak_Click method
		** Show dialog for inserting a break.
		**-----------------------------------------------------------------------------------------------------------*/
		private void mnuBtnInserBreak_Click(object sender, EventArgs e) {
			var dlg = new InsertBreakDialog(textControl) { RightToLeft = this.RightToLeft };
			if (dlg.ShowDialog(this) == System.Windows.Forms.DialogResult.OK) {
				m_fileHandler.IsDocumentDirty = true;
			}
		}

		/*-------------------------------------------------------------------------------------------------------------
		** mnuBtnDeleteField_Click method
		** Delete field.
		**-----------------------------------------------------------------------------------------------------------*/
		private void mnuBtnDeleteField_Click(object sender, EventArgs e) {
			DeleteField();
		}

		/*-------------------------------------------------------------------------------------------------------------
		** mnuBtnFieldSettings_Click method
		** Show dialog for editing the field's settings.
		**-----------------------------------------------------------------------------------------------------------*/
		private void mnuBtnFieldSettings_Click(object sender, EventArgs e) {
			FieldSettings();
		}

	}

	public static partial class ToolstripExtensions {

		public static void Apply(this ToolStripButton button, string txitem, float dpi) {
			var image = ResourceProvider.GetSmallIcon(txitem, dpi);
			if (image != null) {
				button.Image = image;
			}
			else {
				button.Image = ResourceProvider.GetSmallIcon("dummy", dpi);
				Debug.WriteLine(button.Name + String.Format(": Small icon not found by '{0}' via ResourceProvider.", txitem));
			}
		}

	}
}
