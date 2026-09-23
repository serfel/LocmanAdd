/*-------------------------------------------------------------------------------------------------------------
** program:			TX Text Control Words
** description:	Implements a typical word processing application build up on the main features of TextControl's Components. 
**
** copyright:		© Text Control GmbH
**-----------------------------------------------------------------------------------------------------------*/
using System.Drawing;
using System.Windows.Forms;
using TXTextControl;
using DocumentServer.Fields;
using TXTextControl.Windows.Forms;
using TXTextControl.Windows.Forms.Ribbon;

namespace TX_Text_Control_Words {

	/*-------------------------------------------------------------------------------------------------------------
	** class MainWindow
	** Capsulates the adding of the contextmenu items for editing and deleting ApplicationFields.
	**-----------------------------------------------------------------------------------------------------------*/
	public partial class MainWindow {

		/*-------------------------------------------------------------------------------------------------------------
		** AddFieldContextMenuItems
		** Add a item to contextmenustrip for editing the the ApplicationField's settings and another one for
		** deleting the ApplicationField at the current input position.
		**-----------------------------------------------------------------------------------------------------------*/
		private void AddFieldContextMenuItems(ContextMenuStrip contextMenuStrip) {
			// Populate the ContextMenu
			ApplicationField field = m_textControl.ApplicationFields.GetItem();
			if (field != null) {
				// Separator Item
				contextMenuStrip.Items.Add(new ToolStripSeparator());

				// Field Properties Item
				var txItemID_FieldProperties = RibbonReportingTab.RibbonItem.TXITEM_FieldProperties.ToString();
				var itmFieldProps = new ToolStripMenuItem(
					ResourceProvider.GetText(txItemID_FieldProperties), ResourceProvider.GetSmallIcon(txItemID_FieldProperties, m_DPI)) 
					{ Enabled = m_textControl.CanEdit };
				itmFieldProps.Click += MnuItm_Properties_Click;
				contextMenuStrip.Items.Add(itmFieldProps);
				
				// Delete Field Item
				var txItemID_DeleteField = RibbonReportingTab.RibbonItem.TXITEM_DeleteField.ToString();
				var itmDeleteField = new ToolStripMenuItem(
					ResourceProvider.GetText(txItemID_DeleteField),
					ResourceProvider.GetSmallIcon(txItemID_DeleteField, m_DPI)) 
					{ Enabled = m_textControl.CanEdit };
				itmDeleteField.Click += MnuItm_Delete_Click;
				contextMenuStrip.Items.Add(itmDeleteField);
			}
		}

		/*-------------------------------------------------------------------------------------------------------------
		** MnuItm_Properties_Click
		** Show a dialog for editing the field's settings.
		**-----------------------------------------------------------------------------------------------------------*/
		private void MnuItm_Properties_Click(object sender, System.EventArgs e) {
			FieldSettings();
		}

		/*-------------------------------------------------------------------------------------------------------------
		** MnuItm_Delete_Click
		** Delete field.
		**-----------------------------------------------------------------------------------------------------------*/
		private void MnuItm_Delete_Click(object sender, System.EventArgs e) {
			DeleteField();
		}

		/*-------------------------------------------------------------------------------------------------------------
		** MnuItm_Delete_Click
		** Delete ApplicationField at current input position if available.
		**-----------------------------------------------------------------------------------------------------------*/
		private void DeleteField() {
			var field = m_textControl.ApplicationFields.GetItem();
			if (field == null) return;
			m_textControl.ApplicationFields.Remove(field);
		}

		/*-------------------------------------------------------------------------------------------------------------
		** MnuItm_Delete_Click
		** Show dialog for editing the field's settings dependend on the field's type.
		**-----------------------------------------------------------------------------------------------------------*/
		private void FieldSettings() {
			// Show field's corresponding property dialog
			bool bRTL = this.RightToLeft == System.Windows.Forms.RightToLeft.Yes;
			try {
				var field = m_textControl.ApplicationFields.GetItem();

				switch (field.TypeName) {
					case MergeField.TYPE_NAME:
						var mergeField = new MergeField(field);
						mergeField.ShowDialog(this, bRTL);
						break;

					case DateField.TYPE_NAME:
						var dateField = new DateField(field);
						dateField.ShowDialog(this, bRTL);
						break;

					case IncludeText.TYPE_NAME:
						var includeTextField = new IncludeText(field);
						includeTextField.ShowDialog(this, bRTL);
						break;

					case IfField.TYPE_NAME:
						var ifField = new IfField(field);
						ifField.ShowDialog(this, bRTL);
						break;

					case NextIfField.TYPE_NAME:
						var nextIf = new NextIfField(field);
						nextIf.ShowDialog(this, bRTL);
						break;
				}
			}
			catch { }
		}
	}
}