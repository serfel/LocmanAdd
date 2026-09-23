using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using ns10;
using ns6;
using DocumentServer.DataShaping;
using DocumentServer.DataSources;
using DocumentServer.Properties;
using TXTextControl;

namespace DocumentServer.Windows.Forms
{
	/// <summary>The InsertMergeBlockDialog class allows the user to design and insert a merge block based on the currently selected master table.</summary>
	public class InsertMergeBlockDialog : HighDpiForm
	{
		private Color color_0;

		private byte byte_0;

		private static int[] int_0;

		private DataTableInfo dataTableInfo_0;

		private object object_0;

		private DataSourceManager dataSourceManager_0;

		private FilterInstruction[] filterInstruction_0;

		private SortingInstruction[] sortingInstruction_0;

		[CompilerGenerated]
		private bool bool_0;

		[CompilerGenerated]
		private BlockTemplateType blockTemplateType_0;

		[CompilerGenerated]
		private Table table_0;

		private IContainer icontainer_0;

		private System.Windows.Forms.Button m_btnOK;

		private System.Windows.Forms.Button m_btnCancel;

		private TreeView m_tvColumns;

		private Label m_lblListBox;

		private RadioButton m_rbParagraph;

		private RadioButton m_rbTableRow;

		private Panel panel1;

		private CheckBox m_cbHeaderRow;

		private System.Windows.Forms.Button m_btnMoveUp;

		private System.Windows.Forms.Button m_btnMoveDown;

		private System.Windows.Forms.Button m_btnColor;

		private System.Windows.Forms.Button m_btnFilterAndSort;

		private TableLayoutPanel tableLayoutPanel1;

		/// <summary>Returns a MergeBlockInfo object describing the merge block to be inserted.</summary>
		public MergeBlockInfo MergeBlockInfo
		{
			get
			{
				MergeBlockInfo mergeBlockInfo = this.method_9(this.m_tvColumns.Nodes, this.dataTableInfo_0.TableName);
				mergeBlockInfo.Filters = ((this.filterInstruction_0 != null) ? new List<FilterInstruction>(this.filterInstruction_0) : new List<FilterInstruction>());
				mergeBlockInfo.SortingInstructions = ((this.sortingInstruction_0 != null) ? new List<SortingInstruction>(this.sortingInstruction_0) : new List<SortingInstruction>());
				return mergeBlockInfo;
			}
		}

		/// <summary>Indicates whether a separate header row has to be added to the table containing the repeating merge block.</summary>
		public bool AddTableHeaderRow
		{
			[CompilerGenerated]
			get
			{
				return this.bool_0;
			}
			[CompilerGenerated]
			private set
			{
				this.bool_0 = value;
			}
		}

		/// <summary>Returns the selected highlight color to be used for the sub text part representing the merge block.</summary>
		public Color HighlightColor => Color.FromArgb(this.byte_0, this.color_0.R, this.color_0.G, this.color_0.B);

		/// <summary>Indicates the type of the merge block to be created.</summary>
		public BlockTemplateType BlockType
		{
			[CompilerGenerated]
			get
			{
				return this.blockTemplateType_0;
			}
			[CompilerGenerated]
			private set
			{
				this.blockTemplateType_0 = value;
			}
		}

		/// <summary>Returns the newly created TXTextControl.Table if the merge block was inserted as a table row.</summary>
		public Table CreatedTable
		{
			[CompilerGenerated]
			get
			{
				return this.table_0;
			}
			[CompilerGenerated]
			private set
			{
				this.table_0 = value;
			}
		}

		static InsertMergeBlockDialog()
		{
			InsertMergeBlockDialog.int_0 = new int[16];
			for (int i = 0; i < InsertMergeBlockDialog.int_0.Length; i++)
			{
				InsertMergeBlockDialog.int_0[i] = 16777215;
			}
		}

		public InsertMergeBlockDialog(DataSourceManager dataSourceManager, object textControl, DataTableInfo tableInfo)
		{
			this.InitializeComponent();
			this.dataSourceManager_0 = dataSourceManager;
			this.object_0 = textControl;
			this.dataTableInfo_0 = tableInfo;
			this.CreatedTable = null;
			this.method_2();
			this.AddTableHeaderRow = this.m_cbHeaderRow.Checked;
			this.m_cbHeaderRow.Enabled = this.m_rbTableRow.Checked;
			this.method_3(this.m_tvColumns.Nodes, tableInfo);
			this.color_0 = Color.FromArgb(255, 255, 0, 0);
			this.byte_0 = 60;
		}

		private void method_2()
		{
			this.Text = Resources.INS_MERGE_BLOCK_DLG_TITLE;
			this.m_lblListBox.Text = Resources.INS_MERGE_BLOCK_DLG_ADD_HEADER_ROW;
			this.m_rbParagraph.Text = Resources.INS_MERGE_BLOCK_DLG_PLAIN_PAR;
			this.m_rbTableRow.Text = Resources.INS_MERGE_BLOCK_DLG_TBL_ROW;
			this.m_btnMoveUp.Text = Resources.INS_MERGE_BLOCK_DLG_MOVE_UP;
			this.m_btnMoveDown.Text = Resources.INS_MERGE_BLOCK_DLG_MOVE_DOWN;
			this.m_btnFilterAndSort.Text = Resources.INS_MERGE_BLOCK_DLG_FLT_AND_SORT;
			this.m_cbHeaderRow.Text = Resources.INS_MERGE_BLOCK_DLG_ADD_HEADER_ROW;
			this.m_btnColor.Text = Resources.INS_MERGE_BLOCK_DLG_BTN_COLOR;
			this.m_btnOK.Text = Resources.INS_MERGE_BLOCK_DLG_BTN_OK;
			this.m_btnCancel.Text = Resources.INS_MERGE_BLOCK_DLG_BTN_CANCEL;
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
			DialogResult dialogResult = DialogResult.None;
			if (this.dataSourceManager_0.Enum28_0 == Enum28.const_0)
			{
				throw new Exception(Resources.EXC_DATASOURCEMGR_NO_DATA_SOURCE_LOADED);
			}
			Class103 @class = new Class103(this.object_0);
			if (@class.ApplicationFieldCollection_0.GetItem() == null && @class.TextFieldCollection_0.GetItem() == null)
			{
				try
				{
					dialogResult = base.ShowDialog(owner);
					if (dialogResult != DialogResult.OK)
					{
						return dialogResult;
					}
					MergeBlockSettings mergeBlockSettings = new MergeBlockSettings(this.BlockType, this.AddTableHeaderRow, this.HighlightColor, FieldDisplayMode.ShowFieldText);
					this.dataSourceManager_0.InsertMergeBlock(this.object_0, this.MergeBlockInfo, mergeBlockSettings);
					this.CreatedTable = mergeBlockSettings.CreatedTable;
					return dialogResult;
				}
				catch (Exception ex)
				{
					throw new Exception(string.Format(Resources.EXC_SHOWDLG_FAILED, ex.ToString()));
				}
			}
			throw new Exception(Resources.EXC_INS_MERGE_BLOCK_INSIDE_TEXT_FIELD);
		}

		private void m_btnOK_Click(object sender, EventArgs e)
		{
			if (this.m_rbParagraph.Checked)
			{
				this.BlockType = BlockTemplateType.PlainParagraph;
			}
			else if (this.m_rbTableRow.Checked)
			{
				this.BlockType = BlockTemplateType.TableRow;
			}
			base.DialogResult = DialogResult.OK;
			base.Close();
		}

		private void m_tvColumns_BeforeCheck(object sender, TreeViewCancelEventArgs e)
		{
			if (e.Action == TreeViewAction.Unknown)
			{
				return;
			}
			if (!e.Node.Checked)
			{
				if (e.Node.Parent != null)
				{
					TreeNodeCollection treeNodeCollection_ = ((e.Node.Parent.Parent == null) ? this.m_tvColumns.Nodes : e.Node.Parent.Parent.Nodes);
					if (this.method_4(treeNodeCollection_, bool_1: true) == 0)
					{
						MessageBox.Show(this, Resources.INS_MERGE_BLOCK_DLG_MSG_AT_LEAST_ONE_COL, Resources.INS_MERGE_BLOCK_DLG_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
						e.Cancel = true;
					}
				}
				return;
			}
			TreeNodeCollection treeNodeCollection = this.method_8(e.Node);
			if (this.method_4(treeNodeCollection) != 1 || !this.method_6(treeNodeCollection))
			{
				return;
			}
			switch (MessageBox.Show(this, Resources.INS_MERGE_BLOCK_DLG_MSG_UNCHECK_CHILD_COLS, Resources.INS_MERGE_BLOCK_DLG_TITLE, MessageBoxButtons.YesNo, MessageBoxIcon.Question))
			{
			case DialogResult.No:
				e.Cancel = true;
				break;
			case DialogResult.Yes:
				foreach (TreeNode item in treeNodeCollection)
				{
					this.method_7(item.Nodes, bool_1: false);
				}
				break;
			}
		}

		private void m_tvColumns_AfterCheck(object sender, TreeViewEventArgs e)
		{
			if (e.Node.Checked)
			{
				if (e.Node.Nodes.Count > 0)
				{
					this.method_7(e.Node.Nodes, bool_1: false);
				}
				if (e.Node.Parent != null)
				{
					e.Node.Parent.Checked = false;
				}
			}
			this.m_btnOK.Enabled = this.method_5(this.m_tvColumns.Nodes);
		}

		private void m_tvColumns_AfterSelect(object sender, TreeViewEventArgs e)
		{
			if (e.Node == null)
			{
				System.Windows.Forms.Button btnMoveUp = this.m_btnMoveUp;
				this.m_btnMoveDown.Enabled = false;
				btnMoveUp.Enabled = false;
			}
			else
			{
				TreeNodeCollection treeNodeCollection = this.method_8(e.Node);
				this.m_btnMoveUp.Enabled = e.Node.Index >= 1;
				this.m_btnMoveDown.Enabled = e.Node.Index >= 0 && e.Node.Index < treeNodeCollection.Count - 1;
			}
		}

		private void m_cbHeaderRow_CheckedChanged(object sender, EventArgs e)
		{
			this.AddTableHeaderRow = this.m_cbHeaderRow.Checked;
		}

		private void m_rbTableRow_CheckedChanged(object sender, EventArgs e)
		{
			this.m_cbHeaderRow.Enabled = this.m_rbTableRow.Checked;
		}

		private void m_btnMoveUp_Click(object sender, EventArgs e)
		{
			if (this.m_tvColumns.SelectedNode != null)
			{
				TreeNodeCollection treeNodeCollection = this.method_8(this.m_tvColumns.SelectedNode);
				int index = this.m_tvColumns.SelectedNode.Index;
				if (index >= 1)
				{
					TreeNode treeNode = treeNodeCollection[index];
					treeNodeCollection.RemoveAt(index);
					treeNodeCollection.Insert(index - 1, treeNode);
					this.m_tvColumns.SelectedNode = treeNode;
				}
			}
		}

		private void m_btnMoveDown_Click(object sender, EventArgs e)
		{
			if (this.m_tvColumns.SelectedNode != null)
			{
				TreeNodeCollection treeNodeCollection = this.method_8(this.m_tvColumns.SelectedNode);
				int index = this.m_tvColumns.SelectedNode.Index;
				if (index < treeNodeCollection.Count - 1)
				{
					TreeNode treeNode = treeNodeCollection[index];
					treeNodeCollection.RemoveAt(index);
					treeNodeCollection.Insert(index + 1, treeNode);
					this.m_tvColumns.SelectedNode = treeNode;
				}
			}
		}

		private void m_btnFilterAndSort_Click(object sender, EventArgs e)
		{
			FilterAndSortDialog filterAndSortDialog = new FilterAndSortDialog(this.dataTableInfo_0.Columns.Select((DataColumnInfo dataColumnInfo_0) => dataColumnInfo_0.ColumnName).ToArray())
			{
				RightToLeft = this.RightToLeft,
				Filters = this.filterInstruction_0,
				SortingInstructions = this.sortingInstruction_0
			};
			if (filterAndSortDialog.ShowDialog(this) == DialogResult.OK)
			{
				this.filterInstruction_0 = filterAndSortDialog.Filters;
				this.sortingInstruction_0 = filterAndSortDialog.SortingInstructions;
			}
		}

		private void m_btnColor_Click(object sender, EventArgs e)
		{
			ColorDialog colorDialog = new ColorDialog
			{
				FullOpen = true,
				Color = this.color_0,
				CustomColors = InsertMergeBlockDialog.int_0
			};
			if (colorDialog.ShowDialog(this) == DialogResult.OK)
			{
				this.color_0 = colorDialog.Color;
				InsertMergeBlockDialog.int_0 = colorDialog.CustomColors;
			}
		}

		private void method_3(TreeNodeCollection treeNodeCollection_0, DataTableInfo dataTableInfo_1)
		{
			foreach (DataColumnInfo column in dataTableInfo_1.Columns)
			{
				treeNodeCollection_0.Add(column.ColumnName);
			}
			foreach (DataTableInfo childTable in dataTableInfo_1.ChildTables)
			{
				TreeNode treeNode = new TreeNode(childTable.TableName);
				treeNodeCollection_0.Add(treeNode);
				this.method_3(treeNode.Nodes, childTable);
			}
		}

		private int method_4(TreeNodeCollection treeNodeCollection_0, bool bool_1 = false)
		{
			int num = 0;
			foreach (TreeNode item in treeNodeCollection_0)
			{
				if (item.Checked && (!bool_1 || item.Nodes.Count == 0))
				{
					num++;
				}
			}
			return num;
		}

		private bool method_5(TreeNodeCollection treeNodeCollection_0, bool bool_1 = true)
		{
			if (treeNodeCollection_0.Count == 0)
			{
				return false;
			}
			if (this.method_4(treeNodeCollection_0) > 0)
			{
				return true;
			}
			if (bool_1 && this.method_6(treeNodeCollection_0))
			{
				return true;
			}
			return false;
		}

		private bool method_6(TreeNodeCollection treeNodeCollection_0)
		{
			foreach (TreeNode item in treeNodeCollection_0)
			{
				if (this.method_5(item.Nodes))
				{
					return true;
				}
			}
			return false;
		}

		private void method_7(TreeNodeCollection treeNodeCollection_0, bool bool_1)
		{
			foreach (TreeNode item in treeNodeCollection_0)
			{
				item.Checked = bool_1;
				this.method_7(item.Nodes, bool_1);
			}
		}

		private TreeNodeCollection method_8(TreeNode treeNode_0)
		{
			if (treeNode_0.Parent != null)
			{
				return treeNode_0.Parent.Nodes;
			}
			return treeNode_0.TreeView.Nodes;
		}

		private MergeBlockInfo method_9(TreeNodeCollection treeNodeCollection_0, string string_0)
		{
			MergeBlockInfo mergeBlockInfo = new MergeBlockInfo(string_0);
			foreach (TreeNode item in treeNodeCollection_0)
			{
				if (item.Checked)
				{
					mergeBlockInfo.ColumnNames.Add(item.Text);
				}
				else if (item.Nodes.Count > 0)
				{
					MergeBlockInfo mergeBlockInfo2 = this.method_9(item.Nodes, item.Text);
					if (mergeBlockInfo2.ColumnNames.Count > 0)
					{
						mergeBlockInfo.ChildBlocks.Add(mergeBlockInfo2);
					}
				}
			}
			return mergeBlockInfo;
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
			this.m_tvColumns = new System.Windows.Forms.TreeView();
			this.m_lblListBox = new System.Windows.Forms.Label();
			this.m_rbParagraph = new System.Windows.Forms.RadioButton();
			this.m_rbTableRow = new System.Windows.Forms.RadioButton();
			this.panel1 = new System.Windows.Forms.Panel();
			this.m_cbHeaderRow = new System.Windows.Forms.CheckBox();
			this.m_btnMoveUp = new System.Windows.Forms.Button();
			this.m_btnMoveDown = new System.Windows.Forms.Button();
			this.m_btnColor = new System.Windows.Forms.Button();
			this.m_btnFilterAndSort = new System.Windows.Forms.Button();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.panel1.SuspendLayout();
			this.tableLayoutPanel1.SuspendLayout();
			base.SuspendLayout();
			this.m_btnOK.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.m_btnOK.AutoSize = true;
			this.tableLayoutPanel1.SetColumnSpan(this.m_btnOK, 2);
			this.m_btnOK.Enabled = false;
			this.m_btnOK.Location = new System.Drawing.Point(270, 482);
			this.m_btnOK.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.m_btnOK.MinimumSize = new System.Drawing.Size(112, 35);
			this.m_btnOK.Name = "m_btnOK";
			this.m_btnOK.Size = new System.Drawing.Size(112, 35);
			this.m_btnOK.TabIndex = 6;
			this.m_btnOK.Text = "OK";
			this.m_btnOK.UseVisualStyleBackColor = true;
			this.m_btnOK.Click += new System.EventHandler(m_btnOK_Click);
			this.m_btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.m_btnCancel.AutoSize = true;
			this.m_btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.m_btnCancel.Location = new System.Drawing.Point(390, 482);
			this.m_btnCancel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.m_btnCancel.MinimumSize = new System.Drawing.Size(112, 35);
			this.m_btnCancel.Name = "m_btnCancel";
			this.m_btnCancel.Size = new System.Drawing.Size(112, 35);
			this.m_btnCancel.TabIndex = 7;
			this.m_btnCancel.Text = "Cancel";
			this.m_btnCancel.UseVisualStyleBackColor = true;
			this.m_tvColumns.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.m_tvColumns.CheckBoxes = true;
			this.tableLayoutPanel1.SetColumnSpan(this.m_tvColumns, 3);
			this.m_tvColumns.Location = new System.Drawing.Point(4, 25);
			this.m_tvColumns.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.m_tvColumns.Name = "m_tvColumns";
			this.tableLayoutPanel1.SetRowSpan(this.m_tvColumns, 4);
			this.m_tvColumns.ShowLines = false;
			this.m_tvColumns.Size = new System.Drawing.Size(308, 375);
			this.m_tvColumns.TabIndex = 0;
			this.m_tvColumns.BeforeCheck += new System.Windows.Forms.TreeViewCancelEventHandler(m_tvColumns_BeforeCheck);
			this.m_tvColumns.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(m_tvColumns_AfterCheck);
			this.m_tvColumns.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(m_tvColumns_AfterSelect);
			this.m_lblListBox.AutoSize = true;
			this.tableLayoutPanel1.SetColumnSpan(this.m_lblListBox, 4);
			this.m_lblListBox.Location = new System.Drawing.Point(4, 0);
			this.m_lblListBox.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.m_lblListBox.Name = "m_lblListBox";
			this.m_lblListBox.Size = new System.Drawing.Size(160, 20);
			this.m_lblListBox.TabIndex = 0;
			this.m_lblListBox.Text = "Select table columns:";
			this.m_rbParagraph.AutoSize = true;
			this.m_rbParagraph.Dock = System.Windows.Forms.DockStyle.Left;
			this.m_rbParagraph.Location = new System.Drawing.Point(0, 0);
			this.m_rbParagraph.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.m_rbParagraph.Name = "m_rbParagraph";
			this.m_rbParagraph.Size = new System.Drawing.Size(145, 38);
			this.m_rbParagraph.TabIndex = 0;
			this.m_rbParagraph.Text = "Plain paragraph";
			this.m_rbParagraph.UseVisualStyleBackColor = true;
			this.m_rbTableRow.AutoSize = true;
			this.m_rbTableRow.Checked = true;
			this.m_rbTableRow.Dock = System.Windows.Forms.DockStyle.Left;
			this.m_rbTableRow.Location = new System.Drawing.Point(145, 0);
			this.m_rbTableRow.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.m_rbTableRow.Name = "m_rbTableRow";
			this.m_rbTableRow.Size = new System.Drawing.Size(102, 38);
			this.m_rbTableRow.TabIndex = 1;
			this.m_rbTableRow.TabStop = true;
			this.m_rbTableRow.Text = "Table row";
			this.m_rbTableRow.UseVisualStyleBackColor = true;
			this.m_rbTableRow.CheckedChanged += new System.EventHandler(m_rbTableRow_CheckedChanged);
			this.panel1.AutoSize = true;
			this.tableLayoutPanel1.SetColumnSpan(this.panel1, 4);
			this.panel1.Controls.Add(this.m_rbTableRow);
			this.panel1.Controls.Add(this.m_rbParagraph);
			this.panel1.Location = new System.Drawing.Point(5, 405);
			this.panel1.Margin = new System.Windows.Forms.Padding(5, 0, 0, 0);
			this.panel1.MinimumSize = new System.Drawing.Size(260, 38);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(260, 38);
			this.panel1.TabIndex = 4;
			this.m_cbHeaderRow.AutoSize = true;
			this.m_cbHeaderRow.Checked = true;
			this.m_cbHeaderRow.CheckState = System.Windows.Forms.CheckState.Checked;
			this.tableLayoutPanel1.SetColumnSpan(this.m_cbHeaderRow, 4);
			this.m_cbHeaderRow.Location = new System.Drawing.Point(5, 443);
			this.m_cbHeaderRow.Margin = new System.Windows.Forms.Padding(5, 0, 0, 0);
			this.m_cbHeaderRow.Name = "m_cbHeaderRow";
			this.m_cbHeaderRow.Size = new System.Drawing.Size(186, 24);
			this.m_cbHeaderRow.TabIndex = 4;
			this.m_cbHeaderRow.Text = "Add table header row";
			this.m_cbHeaderRow.UseVisualStyleBackColor = true;
			this.m_cbHeaderRow.CheckedChanged += new System.EventHandler(m_cbHeaderRow_CheckedChanged);
			this.m_btnMoveUp.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.m_btnMoveUp.AutoSize = true;
			this.tableLayoutPanel1.SetColumnSpan(this.m_btnMoveUp, 2);
			this.m_btnMoveUp.Enabled = false;
			this.m_btnMoveUp.Location = new System.Drawing.Point(320, 25);
			this.m_btnMoveUp.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.m_btnMoveUp.MinimumSize = new System.Drawing.Size(152, 35);
			this.m_btnMoveUp.Name = "m_btnMoveUp";
			this.m_btnMoveUp.Size = new System.Drawing.Size(182, 35);
			this.m_btnMoveUp.TabIndex = 1;
			this.m_btnMoveUp.Text = "Move &up";
			this.m_btnMoveUp.UseVisualStyleBackColor = true;
			this.m_btnMoveUp.Click += new System.EventHandler(m_btnMoveUp_Click);
			this.m_btnMoveDown.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.m_btnMoveDown.AutoSize = true;
			this.tableLayoutPanel1.SetColumnSpan(this.m_btnMoveDown, 2);
			this.m_btnMoveDown.Enabled = false;
			this.m_btnMoveDown.Location = new System.Drawing.Point(320, 70);
			this.m_btnMoveDown.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.m_btnMoveDown.MinimumSize = new System.Drawing.Size(152, 35);
			this.m_btnMoveDown.Name = "m_btnMoveDown";
			this.m_btnMoveDown.Size = new System.Drawing.Size(182, 35);
			this.m_btnMoveDown.TabIndex = 2;
			this.m_btnMoveDown.Text = "Move &down";
			this.m_btnMoveDown.UseVisualStyleBackColor = true;
			this.m_btnMoveDown.Click += new System.EventHandler(m_btnMoveDown_Click);
			this.m_btnColor.AutoSize = true;
			this.m_btnColor.Location = new System.Drawing.Point(4, 482);
			this.m_btnColor.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.m_btnColor.MinimumSize = new System.Drawing.Size(112, 35);
			this.m_btnColor.Name = "m_btnColor";
			this.m_btnColor.Size = new System.Drawing.Size(112, 35);
			this.m_btnColor.TabIndex = 5;
			this.m_btnColor.Text = "Color…";
			this.m_btnColor.UseVisualStyleBackColor = true;
			this.m_btnColor.Click += new System.EventHandler(m_btnColor_Click);
			this.m_btnFilterAndSort.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.m_btnFilterAndSort.AutoSize = true;
			this.tableLayoutPanel1.SetColumnSpan(this.m_btnFilterAndSort, 2);
			this.m_btnFilterAndSort.Location = new System.Drawing.Point(320, 115);
			this.m_btnFilterAndSort.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.m_btnFilterAndSort.MinimumSize = new System.Drawing.Size(152, 35);
			this.m_btnFilterAndSort.Name = "m_btnFilterAndSort";
			this.m_btnFilterAndSort.Size = new System.Drawing.Size(182, 35);
			this.m_btnFilterAndSort.TabIndex = 3;
			this.m_btnFilterAndSort.Text = "&Filter && Sort…";
			this.m_btnFilterAndSort.UseVisualStyleBackColor = true;
			this.m_btnFilterAndSort.Click += new System.EventHandler(m_btnFilterAndSort_Click);
			this.tableLayoutPanel1.AutoSize = true;
			this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.tableLayoutPanel1.ColumnCount = 5;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100f));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel1.Controls.Add(this.m_tvColumns, 0, 1);
			this.tableLayoutPanel1.Controls.Add(this.m_btnCancel, 4, 8);
			this.tableLayoutPanel1.Controls.Add(this.m_btnColor, 0, 8);
			this.tableLayoutPanel1.Controls.Add(this.m_btnFilterAndSort, 3, 3);
			this.tableLayoutPanel1.Controls.Add(this.m_cbHeaderRow, 0, 6);
			this.tableLayoutPanel1.Controls.Add(this.m_btnMoveUp, 3, 1);
			this.tableLayoutPanel1.Controls.Add(this.m_lblListBox, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.m_btnMoveDown, 3, 2);
			this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 5);
			this.tableLayoutPanel1.Controls.Add(this.m_btnOK, 2, 8);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(5, 5);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 9;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100f));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10f));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.Size = new System.Drawing.Size(506, 522);
			this.tableLayoutPanel1.TabIndex = 8;
			base.AcceptButton = this.m_btnOK;
			base.AutoScaleDimensions = new System.Drawing.SizeF(9f, 20f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.CancelButton = this.m_btnCancel;
			base.ClientSize = new System.Drawing.Size(516, 532);
			base.Controls.Add(this.tableLayoutPanel1);
			base.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.MinimumSize = new System.Drawing.Size(415, 534);
			base.Name = "InsertMergeBlockDialog";
			base.Padding = new System.Windows.Forms.Padding(5);
			this.RightToLeftLayout = true;
			base.ShowIcon = false;
			base.ShowInTaskbar = false;
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Insert Merge Block";
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			base.ResumeLayout(false);
			base.PerformLayout();
		}
	}
}
