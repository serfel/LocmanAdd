using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using ns10;
using ns8;
using TXTextControl.DataVisualization;
using DocumentServer.DataSources;
using DocumentServer.Properties;

namespace DocumentServer.Windows.Forms
{
	/// <summary>The ChartDataRelationDialog class allows the user to prepare a ChartFrame object to display data from a data relation defined in a mail merge data source.</summary>
	public class ChartDataRelationDialog : HighDpiForm
	{
		private Class123 class123_0;

		private ChartFrame chartFrame_0;

		private DataSourceManager dataSourceManager_0;

		private IContainer icontainer_0;

		private System.Windows.Forms.Button m_btnOK;

		private System.Windows.Forms.Button m_btnCancel;

		private TableLayoutPanel tableLayoutPanel1;

		private ComboBox m_cbMainTable;

		private ComboBox m_cbChildTable;

		private Label m_lblMainTbl;

		private Label m_lblChildTbl;

		private Label m_lblAxisLbls;

		private Label m_lblValues;

		private ComboBox m_cbAxisLabels;

		private ComboBox m_cbValues;

		private TableLayoutPanel tableLayoutPanel2;

		public ChartDataRelationDialog(ChartFrame chartFrame, DataSourceManager dataSourceManager)
		{
			this.InitializeComponent();
			this.method_2();
			this.chartFrame_0 = chartFrame;
			this.class123_0 = new Class123(chartFrame);
			this.dataSourceManager_0 = dataSourceManager;
			if (this.dataSourceManager_0.MasterDataTableInfo != null)
			{
				this.method_3();
				this.method_5();
			}
		}

		private void method_2()
		{
			this.Text = Resources.SET_CHART_DATA_REL_DLG_TITLE;
			this.m_lblMainTbl.Text = Resources.SET_CHART_DATA_REL_DLG_LBL_MAIN_TBL;
			this.m_lblChildTbl.Text = Resources.SET_CHART_DATA_REL_DLG_LBL_CHILD_TBL;
			this.m_lblAxisLbls.Text = Resources.SET_CHART_DATA_REL_DLG_LBL_AXIS_LBLS;
			this.m_lblValues.Text = Resources.SET_CHART_DATA_REL_DLG_LBL_VALUES;
			this.m_btnOK.Text = Resources.SET_CHART_DATA_REL_DLG_BTN_OK;
			this.m_btnCancel.Text = Resources.SET_CHART_DATA_REL_DLG_BTN_CANCEL;
		}

		public new void Show(IWin32Window owner)
		{
			throw new NotSupportedException();
		}

		public new void Show()
		{
			this.Show(null);
		}

		public new DialogResult ShowDialog()
		{
			return this.ShowDialog(null);
		}

		public new DialogResult ShowDialog(IWin32Window owner)
		{
			if (this.dataSourceManager_0.Enum28_0 == Enum28.const_0 || this.dataSourceManager_0.MasterDataTableInfo == null)
			{
				throw new Exception(Resources.EXC_DATASOURCEMGR_NO_DATA_SOURCE_LOADED);
			}
			return base.ShowDialog(owner);
		}

		private void method_3()
		{
			string text3 = (this.m_cbMainTable.DisplayMember = (this.m_cbChildTable.DisplayMember = "TableName"));
			text3 = (this.m_cbAxisLabels.DisplayMember = (this.m_cbValues.DisplayMember = "ColumnName"));
			this.method_4();
		}

		private void method_4()
		{
			foreach (DataTableInfo dataTable in this.dataSourceManager_0.DataTables)
			{
				if (dataTable.ChildTables.Count != 0)
				{
					this.m_cbMainTable.Items.Add(dataTable);
				}
			}
			this.m_cbMainTable.SelectedItem = this.dataSourceManager_0.MasterDataTableInfo;
		}

		private void method_5()
		{
			if (this.class123_0.Class107_0.Count == 0 || this.class123_0.Class124_0.Count == 0)
			{
				return;
			}
			Class109 @class = this.class123_0.Class107_0[0];
			if (this.dataSourceManager_0.MasterDataTableInfo.ChildTables.Count == 0)
			{
				return;
			}
			string name = this.chartFrame_0.Name;
			string string_ = @class.String_0;
			if (name == string.Empty || string_ == string.Empty)
			{
				return;
			}
			string text = "";
			foreach (Class126 item in (IEnumerable<Class126>)this.class123_0.Class124_0)
			{
				if (item.String_1.Equals(@class.String_0, StringComparison.OrdinalIgnoreCase))
				{
					text = item.String_0;
					break;
				}
			}
			if (text == string.Empty)
			{
				return;
			}
			DataTableInfo dataTableInfo = null;
			foreach (object item2 in this.m_cbChildTable.Items)
			{
				if (((DataTableInfo)item2).TableName.Equals(name, StringComparison.OrdinalIgnoreCase))
				{
					this.m_cbChildTable.SelectedItem = item2;
					dataTableInfo = (DataTableInfo)item2;
					break;
				}
			}
			if (dataTableInfo == null)
			{
				return;
			}
			foreach (object item3 in this.m_cbAxisLabels.Items)
			{
				if (((DataColumnInfo)item3).ColumnName.Equals(string_, StringComparison.OrdinalIgnoreCase))
				{
					this.m_cbAxisLabels.SelectedItem = item3;
					break;
				}
			}
			foreach (object item4 in this.m_cbValues.Items)
			{
				if (((DataColumnInfo)item4).ColumnName.Equals(text, StringComparison.OrdinalIgnoreCase))
				{
					this.m_cbValues.SelectedItem = item4;
					break;
				}
			}
		}

		private void m_cbMainTable_SelectedIndexChanged(object sender, EventArgs e)
		{
			DataTableInfo obj = (DataTableInfo)this.m_cbMainTable.SelectedItem;
			this.m_cbChildTable.Items.Clear();
			foreach (DataTableInfo childTable in obj.ChildTables)
			{
				this.m_cbChildTable.Items.Add(childTable);
			}
			this.m_cbChildTable.SelectedIndex = Math.Min(this.m_cbChildTable.Items.Count - 1, 0);
		}

		private void m_cbChildTable_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.method_6((DataTableInfo)this.m_cbChildTable.SelectedItem);
		}

		private void method_6(DataTableInfo dataTableInfo_0)
		{
			this.m_cbAxisLabels.Items.Clear();
			this.m_cbValues.Items.Clear();
			foreach (DataColumnInfo column in dataTableInfo_0.Columns)
			{
				this.m_cbAxisLabels.Items.Add(column);
				this.m_cbValues.Items.Add(column);
			}
			int count = dataTableInfo_0.Columns.Count;
			this.m_cbAxisLabels.SelectedIndex = Math.Min(count - 1, 1);
			this.m_cbValues.SelectedIndex = Math.Min(count - 1, 2);
		}

		private void m_btnOK_Click(object sender, EventArgs e)
		{
			string tableName = ((DataTableInfo)this.m_cbChildTable.SelectedItem).TableName;
			string columnName = ((DataColumnInfo)this.m_cbAxisLabels.SelectedItem).ColumnName;
			string columnName2 = ((DataColumnInfo)this.m_cbValues.SelectedItem).ColumnName;
			this.method_7(tableName, columnName, columnName2);
			base.Close();
		}

		private void method_7(string string_0, string string_1, string string_2)
		{
			if (this.class123_0.Class107_0.Count == 0)
			{
				MessageBox.Show(Resources.SET_CHART_DATA_REL_DLG_MSG_AT_LEAST_ONE_AREA, base.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				return;
			}
			if (this.class123_0.Class124_0.Count == 0)
			{
				MessageBox.Show(Resources.SET_CHART_DATA_REL_DLG_MSG_AT_LEAST_ONE_SERIES, base.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				return;
			}
			this.chartFrame_0.Name = string_0;
			while (this.class123_0.Class107_0.Count > 1)
			{
				this.class123_0.Class107_0.RemoveAt(this.class123_0.Class107_0.Count - 1);
			}
			this.class123_0.Class107_0[0].String_0 = string_1;
			while (this.class123_0.Class124_0.Count > 1)
			{
				this.class123_0.Class124_0.RemoveAt(this.class123_0.Class124_0.Count - 1);
			}
			this.class123_0.Class124_0[0].String_0 = string_2;
			foreach (Class117 item in (IEnumerable<Class117>)this.class123_0.Class124_0[0].Class115_0)
			{
				item.String_0 = string_1;
			}
			this.chartFrame_0.Refresh();
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing && this.icontainer_0 != null)
			{
				this.icontainer_0.Dispose();
			}
			base.Dispose(disposing);
		}

		private void InitializeComponent()
		{
			this.m_btnOK = new System.Windows.Forms.Button();
			this.m_btnCancel = new System.Windows.Forms.Button();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.m_cbMainTable = new System.Windows.Forms.ComboBox();
			this.m_cbChildTable = new System.Windows.Forms.ComboBox();
			this.m_lblMainTbl = new System.Windows.Forms.Label();
			this.m_lblChildTbl = new System.Windows.Forms.Label();
			this.m_lblAxisLbls = new System.Windows.Forms.Label();
			this.m_lblValues = new System.Windows.Forms.Label();
			this.m_cbAxisLabels = new System.Windows.Forms.ComboBox();
			this.m_cbValues = new System.Windows.Forms.ComboBox();
			this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
			this.tableLayoutPanel1.SuspendLayout();
			this.tableLayoutPanel2.SuspendLayout();
			base.SuspendLayout();
			this.m_btnOK.AutoSize = true;
			this.m_btnOK.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.m_btnOK.Dock = System.Windows.Forms.DockStyle.Top;
			this.m_btnOK.Location = new System.Drawing.Point(110, 86);
			this.m_btnOK.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
			this.m_btnOK.MinimumSize = new System.Drawing.Size(72, 23);
			this.m_btnOK.Name = "m_btnOK";
			this.m_btnOK.Size = new System.Drawing.Size(72, 23);
			this.m_btnOK.TabIndex = 1;
			this.m_btnOK.Text = "OK";
			this.m_btnOK.UseVisualStyleBackColor = true;
			this.m_btnOK.Click += new System.EventHandler(m_btnOK_Click);
			this.m_btnCancel.AutoSize = true;
			this.m_btnCancel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.m_btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.m_btnCancel.Dock = System.Windows.Forms.DockStyle.Top;
			this.m_btnCancel.Location = new System.Drawing.Point(188, 86);
			this.m_btnCancel.Margin = new System.Windows.Forms.Padding(3, 3, 0, 0);
			this.m_btnCancel.MinimumSize = new System.Drawing.Size(72, 23);
			this.m_btnCancel.Name = "m_btnCancel";
			this.m_btnCancel.Size = new System.Drawing.Size(72, 23);
			this.m_btnCancel.TabIndex = 2;
			this.m_btnCancel.Text = "Cancel";
			this.m_btnCancel.UseVisualStyleBackColor = true;
			this.tableLayoutPanel1.AutoSize = true;
			this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.tableLayoutPanel1.ColumnCount = 3;
			this.tableLayoutPanel2.SetColumnSpan(this.tableLayoutPanel1, 3);
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50f));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15f));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50f));
			this.tableLayoutPanel1.Controls.Add(this.m_cbMainTable, 0, 1);
			this.tableLayoutPanel1.Controls.Add(this.m_cbChildTable, 2, 1);
			this.tableLayoutPanel1.Controls.Add(this.m_lblMainTbl, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.m_lblChildTbl, 2, 0);
			this.tableLayoutPanel1.Controls.Add(this.m_lblAxisLbls, 0, 2);
			this.tableLayoutPanel1.Controls.Add(this.m_lblValues, 2, 2);
			this.tableLayoutPanel1.Controls.Add(this.m_cbAxisLabels, 0, 3);
			this.tableLayoutPanel1.Controls.Add(this.m_cbValues, 2, 3);
			this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0, 0, 0, 3);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 8;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100f));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.Size = new System.Drawing.Size(260, 80);
			this.tableLayoutPanel1.TabIndex = 0;
			this.m_cbMainTable.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.m_cbMainTable.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.m_cbMainTable.FormattingEnabled = true;
			this.m_cbMainTable.Location = new System.Drawing.Point(3, 16);
			this.m_cbMainTable.Name = "m_cbMainTable";
			this.m_cbMainTable.Size = new System.Drawing.Size(116, 21);
			this.m_cbMainTable.TabIndex = 1;
			this.m_cbMainTable.SelectedIndexChanged += new System.EventHandler(m_cbMainTable_SelectedIndexChanged);
			this.m_cbChildTable.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.m_cbChildTable.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.m_cbChildTable.FormattingEnabled = true;
			this.m_cbChildTable.Location = new System.Drawing.Point(140, 16);
			this.m_cbChildTable.Name = "m_cbChildTable";
			this.m_cbChildTable.Size = new System.Drawing.Size(117, 21);
			this.m_cbChildTable.TabIndex = 5;
			this.m_cbChildTable.SelectedIndexChanged += new System.EventHandler(m_cbChildTable_SelectedIndexChanged);
			this.m_lblMainTbl.AutoSize = true;
			this.m_lblMainTbl.Location = new System.Drawing.Point(3, 0);
			this.m_lblMainTbl.Name = "m_lblMainTbl";
			this.m_lblMainTbl.Size = new System.Drawing.Size(63, 13);
			this.m_lblMainTbl.TabIndex = 0;
			this.m_lblMainTbl.Text = "Main Table:";
			this.m_lblChildTbl.AutoSize = true;
			this.m_lblChildTbl.Location = new System.Drawing.Point(140, 0);
			this.m_lblChildTbl.Name = "m_lblChildTbl";
			this.m_lblChildTbl.Size = new System.Drawing.Size(63, 13);
			this.m_lblChildTbl.TabIndex = 4;
			this.m_lblChildTbl.Text = "Child Table:";
			this.m_lblAxisLbls.AutoSize = true;
			this.m_lblAxisLbls.Location = new System.Drawing.Point(3, 40);
			this.m_lblAxisLbls.Name = "m_lblAxisLbls";
			this.m_lblAxisLbls.Size = new System.Drawing.Size(63, 13);
			this.m_lblAxisLbls.TabIndex = 8;
			this.m_lblAxisLbls.Text = "Axis Labels:";
			this.m_lblValues.AutoSize = true;
			this.m_lblValues.Location = new System.Drawing.Point(140, 40);
			this.m_lblValues.Name = "m_lblValues";
			this.m_lblValues.Size = new System.Drawing.Size(42, 13);
			this.m_lblValues.TabIndex = 10;
			this.m_lblValues.Text = "Values:";
			this.m_cbAxisLabels.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.m_cbAxisLabels.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.m_cbAxisLabels.FormattingEnabled = true;
			this.m_cbAxisLabels.Location = new System.Drawing.Point(3, 56);
			this.m_cbAxisLabels.Name = "m_cbAxisLabels";
			this.m_cbAxisLabels.Size = new System.Drawing.Size(116, 21);
			this.m_cbAxisLabels.TabIndex = 9;
			this.m_cbValues.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.m_cbValues.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.m_cbValues.FormattingEnabled = true;
			this.m_cbValues.Location = new System.Drawing.Point(140, 56);
			this.m_cbValues.Name = "m_cbValues";
			this.m_cbValues.Size = new System.Drawing.Size(117, 21);
			this.m_cbValues.TabIndex = 11;
			this.tableLayoutPanel2.AutoSize = true;
			this.tableLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.tableLayoutPanel2.ColumnCount = 3;
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100f));
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel2.Controls.Add(this.m_btnOK, 1, 1);
			this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel1, 0, 0);
			this.tableLayoutPanel2.Controls.Add(this.m_btnCancel, 2, 1);
			this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel2.Location = new System.Drawing.Point(7, 7);
			this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
			this.tableLayoutPanel2.Name = "tableLayoutPanel2";
			this.tableLayoutPanel2.RowCount = 2;
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel2.Size = new System.Drawing.Size(260, 92);
			this.tableLayoutPanel2.TabIndex = 3;
			base.AcceptButton = this.m_btnOK;
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.CancelButton = this.m_btnCancel;
			base.ClientSize = new System.Drawing.Size(274, 106);
			base.Controls.Add(this.tableLayoutPanel2);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.Name = "ChartDataRelationDialog";
			base.Padding = new System.Windows.Forms.Padding(7);
			this.RightToLeftLayout = true;
			base.ShowIcon = false;
			base.ShowInTaskbar = false;
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Set Chart Data Relation";
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			this.tableLayoutPanel2.ResumeLayout(false);
			this.tableLayoutPanel2.PerformLayout();
			base.ResumeLayout(false);
			base.PerformLayout();
		}
	}
}
