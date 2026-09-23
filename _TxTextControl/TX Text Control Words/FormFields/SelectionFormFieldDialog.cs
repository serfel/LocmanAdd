/*-------------------------------------------------------------------------------------------------------------
** program:			TX Text Control Words
** description:	Implements a typical word processing application build up on the main features of 
**						TextControl's Components. 
**
** copyright:		© Text Control GmbH
**-----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using TXTextControl;

namespace TX_Text_Control_Words.FormFields {

	/*----------------------------------------------------------------------------------------------------------
	** class SelectionFormFieldDialog
	**		A dialog for editing the SelectionFormField's properties.
	**--------------------------------------------------------------------------------------------------------*/
	public partial class SelectionFormFieldDialog : Form {

		/*-------------------------------------------------------------------------------------------------------
		** M E M B E R S
		**-----------------------------------------------------------------------------------------------------*/
		SelectionFormField m_field;

		/*-------------------------------------------------------------------------------------------------------
		** C O N S T R U C T O R
		**-----------------------------------------------------------------------------------------------------*/
		public SelectionFormFieldDialog(SelectionFormField field) {
			InitializeComponent();

			m_field = field;

			if (field.Items != null) {
				// Populate item list
				foreach (string item in field.Items.Distinct().Where(s => !String.IsNullOrEmpty(s))) {
					itemsControl.Rows.Add(new string[] { item });
				}
			}

			// Observe actions on datagrid for updating the move-buttons.
			itemsControl.SelectionChanged += itemsControl_SelectionChanged;
			itemsControl.Rows.CollectionChanged += Rows_CollectionChanged;

			// Init Empty Width Control
			emptyWidthControl.Value = field.EmptyWidth;

			// Enable/Disable buttons
			UpdateButtons();
		}


		/*-------------------------------------------------------------------------------------------------------
		** E V E N T H A N D L E R S
		**-----------------------------------------------------------------------------------------------------*/

		/*-------------------------------------------------------------------------------------------------------
		** itemsControl_SelectionChanged
		**-----------------------------------------------------------------------------------------------------*/
		private void itemsControl_SelectionChanged(object sender, EventArgs e) {
			UpdateButtons();
		}

		/*-------------------------------------------------------------------------------------------------------
		** Rows_CollectionChanged
		**-----------------------------------------------------------------------------------------------------*/
		private void Rows_CollectionChanged(object sender, CollectionChangeEventArgs e) {
			UpdateButtons();
		}

		/*-------------------------------------------------------------------------------------------------------
		** btnOK_Click
		**		Apply new settings to field.
		**-----------------------------------------------------------------------------------------------------*/
		private void m_btnOK_Click(object sender, EventArgs e) {
			// Apply Empty Width to field
			var dValueMultiplicator = RegionInfo.CurrentRegion.IsMetric ? 1 : 100;
			var measuringUnitEmptyWidth = RegionInfo.CurrentRegion.IsMetric ? MeasuringUnit.Millimeter : MeasuringUnit.CentiInch;
			m_field.EmptyWidth = emptyWidthControl.Value;

			// Apply items to field
			var newItems = new List<string>();
			for (int i = 0; i < itemsControl.Rows.Count; i++) {
				var row = itemsControl.Rows[i];
				var str = (string)row.Cells[0].Value;

				if (String.IsNullOrEmpty(str)) {
					// Skip empty entries.
					continue;
				}
				else {
					newItems.Add(str);
				}
			}
			m_field.Items = newItems.Count > 0 ? newItems.Distinct().ToArray() : new[] { "" };
		}

		/*-------------------------------------------------------------------------------------------------------
		** btnDown_Click
		**		Move selected item below next.
		**-----------------------------------------------------------------------------------------------------*/
		private void btnDown_Click(object sender, EventArgs e) {
			// Move selected item below the next item.
			var item = itemsControl.SelectedRows[0];
			var newIndex = item.Index + 1;

			itemsControl.Rows.Remove(item);
			itemsControl.Rows.Insert(newIndex, item);

			// Reselect item
			item.Selected = true;
		}

		/*-------------------------------------------------------------------------------------------------------
		** btnUp_Click
		**		Move selected item above previous item.
		**-----------------------------------------------------------------------------------------------------*/
		private void btnUp_Click(object sender, EventArgs e) {
			// Move selected item above the previous item.
			var item = itemsControl.SelectedRows[0];
			var newIndex = item.Index - 1;

			itemsControl.Rows.Remove(item);
			itemsControl.Rows.Insert(newIndex, item);

			// Reselect item
			item.Selected = true;
		}

		/*-------------------------------------------------------------------------------------------------------
		** m_btnNewDropDownListItem_Click
		**		Adds a new item to list.
		**-----------------------------------------------------------------------------------------------------*/
		private void m_btnNewDropDownListItem_Click(object sender, EventArgs e) {
			var idx = itemsControl.Rows.Add();
			itemsControl.CurrentCell = itemsControl.Rows[idx].Cells[0];
			itemsControl.BeginEdit(true);
		}

		/*-------------------------------------------------------------------------------------------------------
		** m_btnDeleteDropDownItem_Click
		**		Removes the first selected item.
		**-----------------------------------------------------------------------------------------------------*/
		private void m_btnDeleteDropDownItem_Click(object sender, EventArgs e) {
			var firstSelectedRow = itemsControl.SelectedRows[0];
			itemsControl.Rows.Remove(firstSelectedRow);
		}

		/*-------------------------------------------------------------------------------------------------------
		** itemsControl_CellValidating
		**		Denies when value already exists in list.
		**-----------------------------------------------------------------------------------------------------*/
		private void itemsControl_CellValidating(object sender, DataGridViewCellValidatingEventArgs e) {
			e.Cancel = hasDuplicate((string)e.FormattedValue, e.RowIndex);
		}

		/*-------------------------------------------------------------------------------------------------------
		** itemsControl_CellBeginEdit
		**		Denies the applying of settings when editing cells.
		**-----------------------------------------------------------------------------------------------------*/
		private void itemsControl_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e) {
			m_btnNewDropDownListItem.Enabled = false;
			m_btnComboBoxListItemMoveDown.Enabled = false;
			m_btnComboBoxListItemMoveUp.Enabled = false;
			m_btnDeleteDropDownItem.Enabled = false;
			m_btnOK.Enabled = false;
		}

		/*-------------------------------------------------------------------------------------------------------
		** itemsControl_CellEndEdit
		**		Activate the OK Button and remove row when first cell is empty.
		**-----------------------------------------------------------------------------------------------------*/
		private void itemsControl_CellEndEdit(object sender, DataGridViewCellEventArgs e) {

			if (itemsControl.SelectedCells.Count > 0) {
				var cellsValue = (string)itemsControl.SelectedCells[0].Value;
				if (String.IsNullOrEmpty(cellsValue)) {
					itemsControl.Rows.Remove(itemsControl.SelectedRows[0]);
				}
			}

			UpdateButtons();
		}

		/*-------------------------------------------------------------------------------------------------------
		** H E L P E R   M E T H O D S
		**-----------------------------------------------------------------------------------------------------*/

		/*-------------------------------------------------------------------------------------------------------
		** UpdateButtons
		**		Updates all buttons.
		**-----------------------------------------------------------------------------------------------------*/
		private void UpdateButtons() {
			// Enables the buttons for moving an item upwards or downwards if this action is possible.
			m_btnComboBoxListItemMoveUp.Enabled = canMoveUp();
			m_btnComboBoxListItemMoveDown.Enabled = canMoveDown();

			m_btnNewDropDownListItem.Enabled = true;
			m_btnDeleteDropDownItem.Enabled = itemsControl.SelectedRows.Count > 0;
			m_btnOK.Enabled = true;
		}

		/*-------------------------------------------------------------------------------------------------------
		** canMoveUp
		**		Checks whether the selected item can move above the previous item. An item can move upwards when
		**		the item has an item above them.
		** Returns
		**		'True' if the selected item can move up else 'False'.
		**-----------------------------------------------------------------------------------------------------*/
		private bool canMoveUp() {
			return itemsControl.SelectedRows.Count > 0
				&& itemsControl.SelectedRows[0].Index > 0;
		}

		/*-------------------------------------------------------------------------------------------------------
		** canMoveDown
		**		Checks whether the selected item can move below the next item. An item can move downwards when
		**		an item is below them.
		** Returns
		**		'True' if the selected item can move up else 'False'.
		**-----------------------------------------------------------------------------------------------------*/
		private bool canMoveDown() {
			var rowSelected = itemsControl.SelectedRows.Count == 1;
			if (rowSelected) {

				var iSelectedRow = itemsControl.SelectedRows[0].Index;
				var iLastRow = itemsControl.Rows.Count - 1;

				return iSelectedRow < iLastRow;
			}
			return false;
		}

		/*-------------------------------------------------------------------------------------------------------
		** hasDuplicate
		**		Checks whether the row's first cell at the passed index in the list is equal to another row's 
		**		first cell's value.
		**-----------------------------------------------------------------------------------------------------*/
		private bool hasDuplicate(string s, int rowIdx) {
			for (int i = 0; i < itemsControl.Rows.Count; i++) {
				DataGridViewRow row = itemsControl.Rows[i];
				var v = (string)row.Cells[0].Value;
				if (v == s && i != rowIdx) {
					return true;
				}
			}

			return false;
		}

	}
}
