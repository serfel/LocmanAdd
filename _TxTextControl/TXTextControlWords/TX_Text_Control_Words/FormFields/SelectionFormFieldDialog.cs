using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using TXTextControl;

namespace TX_Text_Control_Words.FormFields
{
	public class SelectionFormFieldDialog : Form
	{
		private SelectionFormField m_field;

		private IContainer components;

		private GroupBox grpBoxItems;

		private System.Windows.Forms.Button m_btnComboBoxListItemMoveUp;

		private DataGridView itemsControl;

		private System.Windows.Forms.Button btnCancel;

		private System.Windows.Forms.Button m_btnOK;

		private DataGridViewTextBoxColumn colData;

		private EmptyWidthControl emptyWidthControl;

		private System.Windows.Forms.Button m_btnNewDropDownListItem;

		private System.Windows.Forms.Button m_btnDeleteDropDownItem;

		private TableLayoutPanel tableLayoutPanel1;

		private TableLayoutPanel tableLayoutPanel2;

		private TableLayoutPanel tableLayoutPanel3;

		private System.Windows.Forms.Button m_btnComboBoxListItemMoveDown;

		public SelectionFormFieldDialog(SelectionFormField field)
		{
			this.InitializeComponent();
			this.m_field = field;
			if (field.Items != null)
			{
				foreach (string item in from s in field.Items.Distinct()
					where !string.IsNullOrEmpty(s)
					select s)
				{
					DataGridViewRowCollection rows = this.itemsControl.Rows;
					object[] values = new string[1] { item };
					rows.Add(values);
				}
			}
			this.itemsControl.SelectionChanged += itemsControl_SelectionChanged;
			this.itemsControl.Rows.CollectionChanged += Rows_CollectionChanged;
			this.emptyWidthControl.Value = field.EmptyWidth;
			this.UpdateButtons();
		}

		private void itemsControl_SelectionChanged(object sender, EventArgs e)
		{
			this.UpdateButtons();
		}

		private void Rows_CollectionChanged(object sender, CollectionChangeEventArgs e)
		{
			this.UpdateButtons();
		}

		private void m_btnOK_Click(object sender, EventArgs e)
		{
			int num = (RegionInfo.CurrentRegion.IsMetric ? 1 : 100);
			MeasuringUnit measuringUnit = ((!RegionInfo.CurrentRegion.IsMetric) ? MeasuringUnit.CentiInch : MeasuringUnit.Millimeter);
			this.m_field.EmptyWidth = this.emptyWidthControl.Value;
			List<string> list = new List<string>();
			for (int i = 0; i < this.itemsControl.Rows.Count; i++)
			{
				DataGridViewRow dataGridViewRow = this.itemsControl.Rows[i];
				string text = (string)dataGridViewRow.Cells[0].Value;
				if (!string.IsNullOrEmpty(text))
				{
					list.Add(text);
				}
			}
			this.m_field.Items = ((list.Count > 0) ? list.Distinct().ToArray() : new string[1] { "" });
		}

		private void btnDown_Click(object sender, EventArgs e)
		{
			DataGridViewRow dataGridViewRow = this.itemsControl.SelectedRows[0];
			int rowIndex = dataGridViewRow.Index + 1;
			this.itemsControl.Rows.Remove(dataGridViewRow);
			this.itemsControl.Rows.Insert(rowIndex, dataGridViewRow);
			dataGridViewRow.Selected = true;
		}

		private void btnUp_Click(object sender, EventArgs e)
		{
			DataGridViewRow dataGridViewRow = this.itemsControl.SelectedRows[0];
			int rowIndex = dataGridViewRow.Index - 1;
			this.itemsControl.Rows.Remove(dataGridViewRow);
			this.itemsControl.Rows.Insert(rowIndex, dataGridViewRow);
			dataGridViewRow.Selected = true;
		}

		private void m_btnNewDropDownListItem_Click(object sender, EventArgs e)
		{
			int index = this.itemsControl.Rows.Add();
			this.itemsControl.CurrentCell = this.itemsControl.Rows[index].Cells[0];
			this.itemsControl.BeginEdit(selectAll: true);
		}

		private void m_btnDeleteDropDownItem_Click(object sender, EventArgs e)
		{
			DataGridViewRow dataGridViewRow = this.itemsControl.SelectedRows[0];
			this.itemsControl.Rows.Remove(dataGridViewRow);
		}

		private void itemsControl_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
		{
			e.Cancel = this.hasDuplicate((string)e.FormattedValue, e.RowIndex);
		}

		private void itemsControl_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
		{
			this.m_btnNewDropDownListItem.Enabled = false;
			this.m_btnComboBoxListItemMoveDown.Enabled = false;
			this.m_btnComboBoxListItemMoveUp.Enabled = false;
			this.m_btnDeleteDropDownItem.Enabled = false;
			this.m_btnOK.Enabled = false;
		}

		private void itemsControl_CellEndEdit(object sender, DataGridViewCellEventArgs e)
		{
			if (this.itemsControl.SelectedCells.Count > 0)
			{
				string value = (string)this.itemsControl.SelectedCells[0].Value;
				if (string.IsNullOrEmpty(value))
				{
					this.itemsControl.Rows.Remove(this.itemsControl.SelectedRows[0]);
				}
			}
			this.UpdateButtons();
		}

		private void UpdateButtons()
		{
			this.m_btnComboBoxListItemMoveUp.Enabled = this.canMoveUp();
			this.m_btnComboBoxListItemMoveDown.Enabled = this.canMoveDown();
			this.m_btnNewDropDownListItem.Enabled = true;
			this.m_btnDeleteDropDownItem.Enabled = this.itemsControl.SelectedRows.Count > 0;
			this.m_btnOK.Enabled = true;
		}

		private bool canMoveUp()
		{
			if (this.itemsControl.SelectedRows.Count > 0)
			{
				return this.itemsControl.SelectedRows[0].Index > 0;
			}
			return false;
		}

		private bool canMoveDown()
		{
			if (this.itemsControl.SelectedRows.Count == 1)
			{
				int index = this.itemsControl.SelectedRows[0].Index;
				int num = this.itemsControl.Rows.Count - 1;
				return index < num;
			}
			return false;
		}

		private bool hasDuplicate(string s, int rowIdx)
		{
			for (int i = 0; i < this.itemsControl.Rows.Count; i++)
			{
				DataGridViewRow dataGridViewRow = this.itemsControl.Rows[i];
				string text = (string)dataGridViewRow.Cells[0].Value;
				if (text == s && i != rowIdx)
				{
					return true;
				}
			}
			return false;
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TX_Text_Control_Words.FormFields.SelectionFormFieldDialog));
			this.grpBoxItems = new System.Windows.Forms.GroupBox();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.itemsControl = new System.Windows.Forms.DataGridView();
			this.colData = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.m_btnDeleteDropDownItem = new System.Windows.Forms.Button();
			this.m_btnNewDropDownListItem = new System.Windows.Forms.Button();
			this.m_btnComboBoxListItemMoveUp = new System.Windows.Forms.Button();
			this.m_btnComboBoxListItemMoveDown = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.m_btnOK = new System.Windows.Forms.Button();
			this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
			this.emptyWidthControl = new TX_Text_Control_Words.FormFields.EmptyWidthControl();
			this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
			this.grpBoxItems.SuspendLayout();
			this.tableLayoutPanel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)this.itemsControl).BeginInit();
			this.tableLayoutPanel2.SuspendLayout();
			this.tableLayoutPanel3.SuspendLayout();
			base.SuspendLayout();
			resources.ApplyResources(this.grpBoxItems, "grpBoxItems");
			this.grpBoxItems.Controls.Add(this.tableLayoutPanel1);
			this.grpBoxItems.Name = "grpBoxItems";
			this.grpBoxItems.TabStop = false;
			resources.ApplyResources(this.tableLayoutPanel1, "tableLayoutPanel1");
			this.tableLayoutPanel1.Controls.Add(this.itemsControl, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.m_btnDeleteDropDownItem, 1, 3);
			this.tableLayoutPanel1.Controls.Add(this.m_btnNewDropDownListItem, 1, 2);
			this.tableLayoutPanel1.Controls.Add(this.m_btnComboBoxListItemMoveUp, 1, 0);
			this.tableLayoutPanel1.Controls.Add(this.m_btnComboBoxListItemMoveDown, 1, 1);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.itemsControl.AllowUserToAddRows = false;
			this.itemsControl.AllowUserToResizeColumns = false;
			this.itemsControl.AllowUserToResizeRows = false;
			this.itemsControl.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.itemsControl.BackgroundColor = System.Drawing.SystemColors.Window;
			this.itemsControl.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
			this.itemsControl.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.itemsControl.ColumnHeadersVisible = false;
			this.itemsControl.Columns.AddRange(this.colData);
			resources.ApplyResources(this.itemsControl, "itemsControl");
			this.itemsControl.MultiSelect = false;
			this.itemsControl.Name = "itemsControl";
			this.itemsControl.RowHeadersVisible = false;
			this.tableLayoutPanel1.SetRowSpan(this.itemsControl, 4);
			this.itemsControl.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.itemsControl.StandardTab = true;
			this.itemsControl.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(itemsControl_CellBeginEdit);
			this.itemsControl.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(itemsControl_CellEndEdit);
			this.itemsControl.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(itemsControl_CellValidating);
			resources.ApplyResources(this.colData, "colData");
			this.colData.Name = "colData";
			resources.ApplyResources(this.m_btnDeleteDropDownItem, "m_btnDeleteDropDownItem");
			this.m_btnDeleteDropDownItem.Name = "m_btnDeleteDropDownItem";
			this.m_btnDeleteDropDownItem.Tag = "";
			this.m_btnDeleteDropDownItem.UseVisualStyleBackColor = true;
			this.m_btnDeleteDropDownItem.Click += new System.EventHandler(m_btnDeleteDropDownItem_Click);
			resources.ApplyResources(this.m_btnNewDropDownListItem, "m_btnNewDropDownListItem");
			this.m_btnNewDropDownListItem.Name = "m_btnNewDropDownListItem";
			this.m_btnNewDropDownListItem.Tag = "";
			this.m_btnNewDropDownListItem.UseVisualStyleBackColor = true;
			this.m_btnNewDropDownListItem.Click += new System.EventHandler(m_btnNewDropDownListItem_Click);
			resources.ApplyResources(this.m_btnComboBoxListItemMoveUp, "m_btnComboBoxListItemMoveUp");
			this.m_btnComboBoxListItemMoveUp.Name = "m_btnComboBoxListItemMoveUp";
			this.m_btnComboBoxListItemMoveUp.Tag = "";
			this.m_btnComboBoxListItemMoveUp.UseVisualStyleBackColor = true;
			this.m_btnComboBoxListItemMoveUp.Click += new System.EventHandler(btnUp_Click);
			resources.ApplyResources(this.m_btnComboBoxListItemMoveDown, "m_btnComboBoxListItemMoveDown");
			this.m_btnComboBoxListItemMoveDown.Name = "m_btnComboBoxListItemMoveDown";
			this.m_btnComboBoxListItemMoveDown.Tag = "";
			this.m_btnComboBoxListItemMoveDown.UseVisualStyleBackColor = true;
			this.m_btnComboBoxListItemMoveDown.Click += new System.EventHandler(btnDown_Click);
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			resources.ApplyResources(this.btnCancel, "btnCancel");
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Tag = "Abort the action.";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.m_btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
			resources.ApplyResources(this.m_btnOK, "m_btnOK");
			this.m_btnOK.Name = "m_btnOK";
			this.m_btnOK.Tag = "Confirm the action.";
			this.m_btnOK.UseVisualStyleBackColor = true;
			this.m_btnOK.Click += new System.EventHandler(m_btnOK_Click);
			resources.ApplyResources(this.tableLayoutPanel2, "tableLayoutPanel2");
			this.tableLayoutPanel2.Controls.Add(this.emptyWidthControl, 0, 0);
			this.tableLayoutPanel2.Controls.Add(this.grpBoxItems, 0, 1);
			this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel3, 0, 3);
			this.tableLayoutPanel2.Name = "tableLayoutPanel2";
			resources.ApplyResources(this.emptyWidthControl, "emptyWidthControl");
			this.emptyWidthControl.Name = "emptyWidthControl";
			this.emptyWidthControl.Value = 0;
			resources.ApplyResources(this.tableLayoutPanel3, "tableLayoutPanel3");
			this.tableLayoutPanel3.Controls.Add(this.m_btnOK, 0, 0);
			this.tableLayoutPanel3.Controls.Add(this.btnCancel, 1, 0);
			this.tableLayoutPanel3.Name = "tableLayoutPanel3";
			base.AcceptButton = this.m_btnOK;
			base.AutoScaleDimensions = new System.Drawing.SizeF(96f, 96f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
			this.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			base.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			resources.ApplyResources(this, "$this");
			base.CancelButton = this.btnCancel;
			base.Controls.Add(this.tableLayoutPanel2);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "SelectionFormFieldDialog";
			base.ShowIcon = false;
			base.ShowInTaskbar = false;
			this.grpBoxItems.ResumeLayout(false);
			this.grpBoxItems.PerformLayout();
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)this.itemsControl).EndInit();
			this.tableLayoutPanel2.ResumeLayout(false);
			this.tableLayoutPanel2.PerformLayout();
			this.tableLayoutPanel3.ResumeLayout(false);
			base.ResumeLayout(false);
			base.PerformLayout();
		}
	}
}
