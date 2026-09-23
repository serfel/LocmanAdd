using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using ns14;
using ns6;
using DocumentServer.DataSources;
using DocumentServer.Properties;
using TXTextControl.DocumentServer;

namespace DocumentServer.Windows.Forms
{
	/// <summary>The EditMergeBlocksDialog class allows the user to remove or rename merge blocks contained in the current document.</summary>
	public class EditMergeBlocksDialog : HighDpiForm
	{
		private Class103 class103_0;

		private DataSourceManager dataSourceManager_0;

		private IList<MergeBlockInfo> ilist_0;

		private IContainer icontainer_0;

		private ListBox m_lbBlockNames;

		private Label m_lblSelMergeBlock;

		private System.Windows.Forms.Button m_btnOK;

		private System.Windows.Forms.Button m_btnDelete;

		private System.Windows.Forms.Button m_btnGoto;

		private System.Windows.Forms.Button m_btnRename;

		private System.Windows.Forms.Button m_btnFilterAndSort;

		private TableLayoutPanel tableLayoutPanel2;

		private TableLayoutPanel tableLayoutPanel1;

		public EditMergeBlocksDialog(DataSourceManager dataSourceManager, object textControl)
		{
			this.InitializeComponent();
			this.method_2();
			this.dataSourceManager_0 = dataSourceManager;
			this.class103_0 = new Class103(textControl);
			this.ilist_0 = this.class103_0.GetMergeBlocksFlattened();
			this.method_3();
		}

		private void method_2()
		{
			this.Text = Resources.EDIT_MERGE_BLOCK_DLG_TITLE;
			this.m_lblSelMergeBlock.Text = Resources.EDIT_MERGE_BLOCK_DLG_LBL_SEL_MERGE_BLOCK;
			this.m_btnGoto.Text = Resources.EDIT_MERGE_BLOCK_DLG_BTN_GOTO;
			this.m_btnDelete.Text = Resources.EDIT_MERGE_BLOCK_DLG_BTN_DEL;
			this.m_btnFilterAndSort.Text = Resources.EDIT_MERGE_BLOCK_DLG_BTN_FLT_SORT;
			this.m_btnRename.Text = Resources.EDIT_MERGE_BLOCK_DLG_BTN_RENAME;
			this.m_btnOK.Text = Resources.EDIT_MERGE_BLOCK_DLG_BTN_OK;
		}

		private void method_3()
		{
			this.m_lbBlockNames.Items.Clear();
			if (this.ilist_0 == null)
			{
				return;
			}
			this.m_lbBlockNames.DisplayMember = "Name";
			foreach (MergeBlockInfo item in this.ilist_0)
			{
				this.m_lbBlockNames.Items.Add(new MergeBlockListItem(item));
			}
		}

		public new void Show(IWin32Window owner)
		{
			throw new NotSupportedException();
		}

		public new void Show()
		{
			this.Show(null);
		}

		private void m_lbBlockNames_SelectedIndexChanged(object sender, EventArgs e)
		{
			System.Windows.Forms.Button btnDelete = this.m_btnDelete;
			System.Windows.Forms.Button btnGoto = this.m_btnGoto;
			System.Windows.Forms.Button btnFilterAndSort = this.m_btnFilterAndSort;
			bool flag2 = (this.m_btnRename.Enabled = this.m_lbBlockNames.SelectedIndex > -1);
			bool flag4 = (btnFilterAndSort.Enabled = flag2);
			bool enabled = (btnGoto.Enabled = flag4);
			btnDelete.Enabled = enabled;
		}

		private void m_btnGoto_Click(object sender, EventArgs e)
		{
			(this.m_lbBlockNames.SelectedItem as MergeBlockListItem)?.ScrollToBlock();
		}

		private void m_btnDelete_Click(object sender, EventArgs e)
		{
			MergeBlockListItem mergeBlockListItem = this.m_lbBlockNames.SelectedItem as MergeBlockListItem;
			if (mergeBlockListItem != null)
			{
				this.class103_0.SubTextPartCollection_0.Remove(mergeBlockListItem.SubTextPart, keepText: true, keepNested: false);
				this.ilist_0.Remove(mergeBlockListItem.MergeBlockInfo);
				this.method_3();
			}
		}

		private void m_btnRename_Click(object sender, EventArgs e)
		{
			MergeBlockListItem mergeBlockListItem = this.m_lbBlockNames.SelectedItem as MergeBlockListItem;
			if (mergeBlockListItem != null)
			{
				UserPromptDialog_1 userPromptDialog_ = new UserPromptDialog_1(Resources.EDIT_MERGE_BLOCK_DLG_INPUT_DLG_TITLE, Resources.EDIT_MERGE_BLOCK_DLG_INPUT_DLG_LBL, mergeBlockListItem.Name);
				if (userPromptDialog_.ShowDialog(this) == DialogResult.OK)
				{
					mergeBlockListItem.Name = userPromptDialog_.String_0;
					this.method_3();
				}
			}
		}

		private void m_btnFilterAndSort_Click(object sender, EventArgs e)
		{
			string[] array = new string[0];
			MergeBlockListItem mergeBlockListItem = this.m_lbBlockNames.SelectedItem as MergeBlockListItem;
			if (mergeBlockListItem == null)
			{
				return;
			}
			MergeBlockMetaData metaData = mergeBlockListItem.SubTextPart.GetMergeBlockMetaData();
			DataShapingInfo dataShapingInfo = metaData.DataShapingInfo ?? new DataShapingInfo();
			DataTableInfo dataTableInfo = this.dataSourceManager_0.DataTables.FirstOrDefault((DataTableInfo t) => t.TableName.Equals(metaData.Name, StringComparison.OrdinalIgnoreCase));
			if (dataTableInfo != null)
			{
				array = dataTableInfo.Columns.Select((DataColumnInfo dataColumnInfo_0) => dataColumnInfo_0.ColumnName).ToArray();
			}
			else if (mergeBlockListItem.MergeBlockInfo != null)
			{
				array = mergeBlockListItem.MergeBlockInfo.ColumnNames.ToArray();
			}
			if (array.Length != 0)
			{
				FilterAndSortDialog filterAndSortDialog = new FilterAndSortDialog(array)
				{
					RightToLeft = this.RightToLeft,
					Filters = dataShapingInfo.Filters,
					SortingInstructions = dataShapingInfo.SortingInstructions
				};
				if (filterAndSortDialog.ShowDialog(this) == DialogResult.OK)
				{
					filterAndSortDialog.StoreBlockMetaData(mergeBlockListItem.SubTextPart);
				}
			}
			else
			{
				MessageBox.Show(this, Resources.EDIT_MERGE_BLOCK_DLG_NO_FIELD_NAMES, Resources.EDIT_MERGE_BLOCK_DLG_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
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
			this.m_lbBlockNames = new System.Windows.Forms.ListBox();
			this.m_lblSelMergeBlock = new System.Windows.Forms.Label();
			this.m_btnOK = new System.Windows.Forms.Button();
			this.m_btnDelete = new System.Windows.Forms.Button();
			this.m_btnGoto = new System.Windows.Forms.Button();
			this.m_btnRename = new System.Windows.Forms.Button();
			this.m_btnFilterAndSort = new System.Windows.Forms.Button();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
			this.tableLayoutPanel1.SuspendLayout();
			this.tableLayoutPanel2.SuspendLayout();
			base.SuspendLayout();
			this.m_lbBlockNames.Dock = System.Windows.Forms.DockStyle.Fill;
			this.m_lbBlockNames.FormattingEnabled = true;
			this.m_lbBlockNames.HorizontalScrollbar = true;
			this.m_lbBlockNames.IntegralHeight = false;
			this.m_lbBlockNames.Location = new System.Drawing.Point(0, 16);
			this.m_lbBlockNames.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
			this.m_lbBlockNames.MinimumSize = new System.Drawing.Size(162, 199);
			this.m_lbBlockNames.Name = "m_lbBlockNames";
			this.tableLayoutPanel2.SetRowSpan(this.m_lbBlockNames, 5);
			this.m_lbBlockNames.Size = new System.Drawing.Size(227, 296);
			this.m_lbBlockNames.TabIndex = 1;
			this.m_lbBlockNames.SelectedIndexChanged += new System.EventHandler(m_lbBlockNames_SelectedIndexChanged);
			this.m_lblSelMergeBlock.AutoSize = true;
			this.tableLayoutPanel2.SetColumnSpan(this.m_lblSelMergeBlock, 2);
			this.m_lblSelMergeBlock.Dock = System.Windows.Forms.DockStyle.Top;
			this.m_lblSelMergeBlock.Location = new System.Drawing.Point(0, 0);
			this.m_lblSelMergeBlock.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
			this.m_lblSelMergeBlock.Name = "m_lblSelMergeBlock";
			this.m_lblSelMergeBlock.Size = new System.Drawing.Size(302, 13);
			this.m_lblSelMergeBlock.TabIndex = 0;
			this.m_lblSelMergeBlock.Text = "Select Merge Block:";
			this.m_btnOK.AutoSize = true;
			this.m_btnOK.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.m_btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.m_btnOK.Dock = System.Windows.Forms.DockStyle.Top;
			this.m_btnOK.Location = new System.Drawing.Point(233, 318);
			this.m_btnOK.Margin = new System.Windows.Forms.Padding(3, 3, 0, 0);
			this.m_btnOK.MinimumSize = new System.Drawing.Size(72, 23);
			this.m_btnOK.Name = "m_btnOK";
			this.m_btnOK.Size = new System.Drawing.Size(72, 23);
			this.m_btnOK.TabIndex = 5;
			this.m_btnOK.Text = "&OK";
			this.m_btnOK.UseVisualStyleBackColor = true;
			this.m_btnDelete.AutoSize = true;
			this.m_btnDelete.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.m_btnDelete.Dock = System.Windows.Forms.DockStyle.Top;
			this.m_btnDelete.Enabled = false;
			this.m_btnDelete.Location = new System.Drawing.Point(233, 103);
			this.m_btnDelete.Margin = new System.Windows.Forms.Padding(3, 3, 0, 3);
			this.m_btnDelete.MinimumSize = new System.Drawing.Size(72, 23);
			this.m_btnDelete.Name = "m_btnDelete";
			this.m_btnDelete.Size = new System.Drawing.Size(72, 23);
			this.m_btnDelete.TabIndex = 4;
			this.m_btnDelete.Text = "&Delete";
			this.m_btnDelete.UseVisualStyleBackColor = true;
			this.m_btnDelete.Click += new System.EventHandler(m_btnDelete_Click);
			this.m_btnGoto.AutoSize = true;
			this.m_btnGoto.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.m_btnGoto.Dock = System.Windows.Forms.DockStyle.Top;
			this.m_btnGoto.Enabled = false;
			this.m_btnGoto.Location = new System.Drawing.Point(233, 16);
			this.m_btnGoto.Margin = new System.Windows.Forms.Padding(3, 3, 0, 3);
			this.m_btnGoto.MinimumSize = new System.Drawing.Size(72, 23);
			this.m_btnGoto.Name = "m_btnGoto";
			this.m_btnGoto.Size = new System.Drawing.Size(72, 23);
			this.m_btnGoto.TabIndex = 2;
			this.m_btnGoto.Text = "&Go to…";
			this.m_btnGoto.UseVisualStyleBackColor = true;
			this.m_btnGoto.Click += new System.EventHandler(m_btnGoto_Click);
			this.m_btnRename.AutoSize = true;
			this.m_btnRename.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.m_btnRename.Dock = System.Windows.Forms.DockStyle.Top;
			this.m_btnRename.Enabled = false;
			this.m_btnRename.Location = new System.Drawing.Point(233, 45);
			this.m_btnRename.Margin = new System.Windows.Forms.Padding(3, 3, 0, 3);
			this.m_btnRename.MinimumSize = new System.Drawing.Size(72, 23);
			this.m_btnRename.Name = "m_btnRename";
			this.m_btnRename.Size = new System.Drawing.Size(72, 23);
			this.m_btnRename.TabIndex = 3;
			this.m_btnRename.Text = "&Rename";
			this.m_btnRename.UseVisualStyleBackColor = true;
			this.m_btnRename.Click += new System.EventHandler(m_btnRename_Click);
			this.m_btnFilterAndSort.AutoSize = true;
			this.m_btnFilterAndSort.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.m_btnFilterAndSort.Dock = System.Windows.Forms.DockStyle.Top;
			this.m_btnFilterAndSort.Enabled = false;
			this.m_btnFilterAndSort.Location = new System.Drawing.Point(233, 74);
			this.m_btnFilterAndSort.Margin = new System.Windows.Forms.Padding(3, 3, 0, 3);
			this.m_btnFilterAndSort.MinimumSize = new System.Drawing.Size(72, 23);
			this.m_btnFilterAndSort.Name = "m_btnFilterAndSort";
			this.m_btnFilterAndSort.Size = new System.Drawing.Size(72, 23);
			this.m_btnFilterAndSort.TabIndex = 6;
			this.m_btnFilterAndSort.Text = "&Filter && sort";
			this.m_btnFilterAndSort.UseVisualStyleBackColor = true;
			this.m_btnFilterAndSort.Click += new System.EventHandler(m_btnFilterAndSort_Click);
			this.tableLayoutPanel1.AutoSize = true;
			this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.tableLayoutPanel1.ColumnCount = 2;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100f));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.m_btnOK, 1, 1);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(7, 7);
			this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 2;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100f));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.Size = new System.Drawing.Size(305, 341);
			this.tableLayoutPanel1.TabIndex = 7;
			this.tableLayoutPanel2.AutoSize = true;
			this.tableLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.tableLayoutPanel2.ColumnCount = 2;
			this.tableLayoutPanel1.SetColumnSpan(this.tableLayoutPanel2, 2);
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100f));
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel2.Controls.Add(this.m_lbBlockNames, 0, 1);
			this.tableLayoutPanel2.Controls.Add(this.m_btnDelete, 1, 4);
			this.tableLayoutPanel2.Controls.Add(this.m_btnGoto, 1, 1);
			this.tableLayoutPanel2.Controls.Add(this.m_btnRename, 1, 2);
			this.tableLayoutPanel2.Controls.Add(this.m_btnFilterAndSort, 1, 3);
			this.tableLayoutPanel2.Controls.Add(this.m_lblSelMergeBlock, 0, 0);
			this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
			this.tableLayoutPanel2.MinimumSize = new System.Drawing.Size(241, 211);
			this.tableLayoutPanel2.Name = "tableLayoutPanel2";
			this.tableLayoutPanel2.RowCount = 6;
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100f));
			this.tableLayoutPanel2.Size = new System.Drawing.Size(305, 315);
			this.tableLayoutPanel2.TabIndex = 8;
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.CancelButton = this.m_btnOK;
			base.ClientSize = new System.Drawing.Size(319, 355);
			base.Controls.Add(this.tableLayoutPanel1);
			this.MinimumSize = new System.Drawing.Size(335, 394);
			base.Name = "EditMergeBlocksDialog";
			base.Padding = new System.Windows.Forms.Padding(7);
			this.RightToLeftLayout = true;
			base.ShowIcon = false;
			base.ShowInTaskbar = false;
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Edit Merge Blocks";
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			this.tableLayoutPanel2.ResumeLayout(false);
			this.tableLayoutPanel2.PerformLayout();
			base.ResumeLayout(false);
			base.PerformLayout();
		}
	}
}
