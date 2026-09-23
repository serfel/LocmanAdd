/*-------------------------------------------------------------------------------------------------------------
** program:			TX Text Control Words
** description:	Implements a typical word processing application build up on the main features of 
**						TextControl's Components. 
**
** copyright:		© Text Control GmbH
**-----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using TXTextControl;
using TXTextControl.Barcode;
using TXTextControl.DataVisualization;
using DocumentServer.DataSources;
using TXTextControl.Windows.Forms;
using TXTextControl.Windows.Forms.Ribbon;

namespace TX_Text_Control_Words {

	/*-------------------------------------------------------------------------------------------------------------
	** class MainWindow
	** Capsulates the adding of contextmenu items for setting a FrameBase's name.
	** The DrawingFrame's or TextFrame's name can be set manually by the new contextmenu item. 
	** Generate an additional contextmenu item for choosing a column of database's tabletree. This feature is
	** available for a FrameBase object which is not a ChartFrame, DrawingFrame or TextFrame. 
	**-----------------------------------------------------------------------------------------------------------*/
	public partial class Справка
	{

		/*-------------------------------------------------------------------------------------------------------------
		** AddFrameContextMenuItems
		** Adds the new context menu items, to ContextMenuStrip, for setting the framebase's name.
		**-----------------------------------------------------------------------------------------------------------*/
		private void AddFrameContextMenuItems(ContextMenuStrip contextMenuStrip) {
			FrameBase frame = m_textControl.Frames.GetItem();
			if (frame != null) {
				if (!(frame is ChartFrame)) {
					// Separator
					contextMenuStrip.Items.Add(new ToolStripSeparator());

					if (!(frame is DrawingFrame) && !(frame is TextFrame)) {
						AddSelectFrameDataSourceMenuItem(contextMenuStrip);
					}

					AddFrameNameContextMenuItem(contextMenuStrip);
				}
			}
		}

		/*-------------------------------------------------------------------------------------------------------------
		** AddSelectFrameDataSourceMenuItem
		** Adds an item to ContextMenuStrip for choosing a column from a database's tree.
		**-----------------------------------------------------------------------------------------------------------*/
		private void AddSelectFrameDataSourceMenuItem(ContextMenuStrip contextMenuStrip) {
			var mnuItmNew
				= new ToolStripMenuItem(
					Лоцман_добавка.Properties.Resources.CONTEXTMENU_FRAME_SEL_DATA_SOURCE,
					ResourceProvider.GetSmallIcon(RibbonReportingTab.RibbonItem.TXITEM_DataSource.ToString(), m_DPI));
			mnuItmNew.DropDownOpening += SelectFrameDataSourceMenuItem_DropDownOpening;
			// Add dummy item so down arrow is visible
			mnuItmNew.DropDownItems.Add("-");
			// Only enable menu item if a data source has been loaded and input position is editable
			mnuItmNew.Enabled = m_textControl.CanEdit && (m_reportingTab.DataSourceManager.MasterDataTableInfo != null);
			contextMenuStrip.Items.Add(mnuItmNew);
		}

		/*-------------------------------------------------------------------------------------------------------------
		** SelectFrameDataSourceMenuItem_DropDownOpening
		** Add items to menu for traversing the database's tree and choosing a column.
		**-----------------------------------------------------------------------------------------------------------*/
		void SelectFrameDataSourceMenuItem_DropDownOpening(object sender, EventArgs e) {
			var mnuItm = sender as ToolStripMenuItem;
			if (mnuItm == null) return;
			AddSelectFrameDataSourceMenuItems(mnuItm, m_reportingTab.DataSourceManager.MasterDataTableInfo);
		}

		/*-------------------------------------------------------------------------------------------------------------
		** AddSelectFrameDataSourceMenuItems
		** Add items to menu for traversing the database's tree for column and table and sets a click handler for
		** columns for setting the FrameBase's name.
		**-----------------------------------------------------------------------------------------------------------*/
		private void AddSelectFrameDataSourceMenuItems(ToolStripMenuItem mnuItm, DataTableInfo table) {
			// Remove dummy item
			mnuItm.DropDownItems.Clear();

			// Intialize the tree of context menu items by column names and table names

			// Add items for columns
			foreach (DataColumnInfo col in table.Columns) {
				var itmCol = new ToolStripMenuItem(col.ColumnName,
					ResourceProvider.GetSmallIcon("TXITEM_SelectTableCol", m_DPI),
					FrameDataSourceColItem_Click);
				mnuItm.DropDownItems.Add(itmCol);
			}

			// Add items for child tables
			foreach (DataTableInfo tblChild in table.ChildTables) {
				var itmTbl = new ToolStripMenuItem(tblChild.TableName,
					ResourceProvider.GetSmallIcon("TXITEM_Table", m_DPI));
				itmTbl.Tag = tblChild;
				itmTbl.DropDownOpening += FrameDataSourceTblItem_DropDownOpening;
				itmTbl.DropDownItems.Add("-");	// Add dummy item so drop down arrow is visible
				mnuItm.DropDownItems.Add(itmTbl);
			}
		}

		/*-------------------------------------------------------------------------------------------------------------
		** FrameDataSourceTblItem_DropDownOpening
		** Add items to menu for traversing the database's tree for column and table and sets a click handler for
		** columns for setting the FrameBase's name.
		**-----------------------------------------------------------------------------------------------------------*/
		void FrameDataSourceTblItem_DropDownOpening(object sender, EventArgs e) {
			var mnuItm = sender as ToolStripMenuItem;
			if (mnuItm == null) return;

			var table = mnuItm.Tag as DataTableInfo;
			if (table == null) return;

			AddSelectFrameDataSourceMenuItems(mnuItm, table);
		}

		/*-------------------------------------------------------------------------------------------------------------
		** FrameDataSourceColItem_Click
		** Set the currently selected FrameBase object's name by traversing the ContextMenuStrip's tree of
		** represented datacolumns and datatables.
		**-----------------------------------------------------------------------------------------------------------*/
		private void FrameDataSourceColItem_Click(object sender, EventArgs e) {
			var mnuItm = sender as ToolStripMenuItem;
			if (mnuItm == null) return;

			FrameBase frame = m_textControl.Frames.GetItem();
			if (frame == null) return;

			frame.Name = GenerateFieldName(mnuItm);
		}

		/*-------------------------------------------------------------------------------------------------------------
		** GenerateFieldName
		** Set the currently selected FrameBase object's name by traversing and joining the context menu item's text
		** separated by a dot.
		**-----------------------------------------------------------------------------------------------------------*/
		private string GenerateFieldName(ToolStripMenuItem mnuItm) {
			var tokens = new List<string>();

			while ((mnuItm != null) && !(mnuItm.GetCurrentParent() is ContextMenuStrip)) {
				tokens.Add(mnuItm.Text);
				mnuItm = mnuItm.OwnerItem as ToolStripMenuItem;
			}

			tokens.Reverse();
			return string.Join(".", tokens.ToArray());
		}

		/*-------------------------------------------------------------------------------------------------------------
		** AddFrameNameContextMenuItem
		** Add a new item to ContextMenuStrip for setting the currently selected framebase object's name manually
		** via a dialog.
		**-----------------------------------------------------------------------------------------------------------*/
		private void AddFrameNameContextMenuItem(ContextMenuStrip contextMenuStrip) {
			// Add context menu item for editing frame's name
			if (m_textControl.CanEdit) {
				contextMenuStrip.Items.Add(
					Лоцман_добавка.Properties.Resources.CONTEXTMENU_FRAME_NAME,
					ResourceProvider.GetSmallIcon(RibbonFrameLayoutTab.RibbonItem.TXITEM_ObjectName.ToString(), m_DPI), SetFrameName_Click);
			}
		}

		/*-------------------------------------------------------------------------------------------------------------
		** SetFrameName_Click
		** Show a dialog on click for setting the FrameBase object's name.
		**-----------------------------------------------------------------------------------------------------------*/
		private void SetFrameName_Click(object sender, EventArgs e) {
			// Open a user dialog for setting frame's name
			FrameBase frame = m_textControl.Frames.GetItem();
			if (frame == null) return;

			string strName = frame.Name;
			var dlg = new UserPromptDialog(Лоцман_добавка.Properties.Resources.USR_INP_FRAME_NAME_TITLE, Лоцман_добавка.Properties.Resources.USR_INP_FRAME_NAME_LABEL, strName)
			{
				Owner = this,
				RightToLeft = this.RightToLeft
			};

			if (dlg.ShowDialog(this) == System.Windows.Forms.DialogResult.OK) {
				{
					if (frame.GetType() == typeof(TXTextControl.DataVisualization.BarcodeFrame))
                    {
						((TXBarcodeControl)((TXTextControl.DataVisualization.BarcodeFrame)frame).Barcode).Text = dlg.Value;
					}
					frame.Name = dlg.Value;
				}
			}
		}
	}
}