using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using ns13;
using ns4;
using DocumentServer.DataSources;
using DocumentServer.Properties;

namespace DocumentServer.Windows.Forms
{
	/// <summary>The EditDataRelationsDialog class allows the user to add or remove data relations to or from the current data source.</summary>
	public class EditDataRelationsDialog : HighDpiForm
	{
		private DataSet dataSet_0;

		private DataSourceManager dataSourceManager_0;

		private IContainer icontainer_0;

		private ListBox m_lbRelations;

		private Label m_lblDataRels;

		private System.Windows.Forms.Button m_btnOK;

		private System.Windows.Forms.Button m_btnDelete;

		private System.Windows.Forms.Button m_btnAdd;

		private TableLayoutPanel tableLayoutPanel2;

		private TableLayoutPanel tableLayoutPanel1;

		public EditDataRelationsDialog(DataSourceManager dataSourceManager)
		{
			this.InitializeComponent();
			this.method_2();
			this.dataSourceManager_0 = dataSourceManager;
			this.dataSet_0 = dataSourceManager.method_13();
			if (this.dataSet_0 == null)
			{
				throw new Exception(Resources.EXC_EDIT_DATA_RELS_DLG_WRONG_DB_TYPE);
			}
			this.method_3(this.dataSet_0.Relations);
		}

		private void method_2()
		{
			this.Text = Resources.EDIT_DATA_RELS_DLG_TITLE;
			this.m_lblDataRels.Text = Resources.EDIT_DATA_RELS_DLG_LBL_DATA_RELS;
			this.m_btnAdd.Text = Resources.EDIT_DATA_RELS_DLG_BTN_ADD;
			this.m_btnDelete.Text = Resources.EDIT_DATA_RELS_DLG_BTN_DEL;
			this.m_btnOK.Text = Resources.EDIT_DATA_RELS_DLG_BTN_OK;
		}

		private void method_3(DataRelationCollection dataRelationCollection_0)
		{
			this.m_lbRelations.Items.Clear();
			this.m_lbRelations.DisplayMember = "Description";
			foreach (DataRelation item in dataRelationCollection_0)
			{
				if (item.ParentColumns.Length == 1 && item.ChildColumns.Length == 1)
				{
					this.m_lbRelations.Items.Add(new Class97(item));
				}
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

		public new DialogResult ShowDialog()
		{
			return this.ShowDialog(null);
		}

		public new DialogResult ShowDialog(IWin32Window owner)
		{
			DialogResult result = base.ShowDialog(owner);
			this.dataSourceManager_0.method_3();
			this.dataSourceManager_0.method_12();
			return result;
		}

		private void m_lbRelations_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.m_btnDelete.Enabled = this.m_lbRelations.SelectedIndex > -1;
		}

		private void m_btnDelete_Click(object sender, EventArgs e)
		{
			Class97 @class = this.m_lbRelations.SelectedItem as Class97;
			if (@class != null)
			{
				this.m_lbRelations.Items.Remove(@class);
				this.dataSet_0.Relations.Remove(@class.RelationName);
			}
		}

		private void m_btnAdd_Click(object sender, EventArgs e)
		{
			if (CreateDataRelationDialog.smethod_0(this.dataSet_0, this) == DialogResult.OK)
			{
				this.method_3(this.dataSet_0.Relations);
			}
		}

		private void EditDataRelationsDialog_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Escape)
			{
				base.Close();
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
			this.m_lbRelations = new System.Windows.Forms.ListBox();
			this.m_lblDataRels = new System.Windows.Forms.Label();
			this.m_btnOK = new System.Windows.Forms.Button();
			this.m_btnDelete = new System.Windows.Forms.Button();
			this.m_btnAdd = new System.Windows.Forms.Button();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
			this.tableLayoutPanel1.SuspendLayout();
			this.tableLayoutPanel2.SuspendLayout();
			base.SuspendLayout();
			this.m_lbRelations.Dock = System.Windows.Forms.DockStyle.Fill;
			this.m_lbRelations.FormattingEnabled = true;
			this.m_lbRelations.HorizontalScrollbar = true;
			this.m_lbRelations.IntegralHeight = false;
			this.m_lbRelations.Location = new System.Drawing.Point(0, 19);
			this.m_lbRelations.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
			this.m_lbRelations.MinimumSize = new System.Drawing.Size(285, 100);
			this.m_lbRelations.Name = "m_lbRelations";
			this.tableLayoutPanel2.SetRowSpan(this.m_lbRelations, 3);
			this.m_lbRelations.Size = new System.Drawing.Size(292, 149);
			this.m_lbRelations.TabIndex = 1;
			this.m_lbRelations.SelectedIndexChanged += new System.EventHandler(m_lbRelations_SelectedIndexChanged);
			this.m_lblDataRels.AutoSize = true;
			this.tableLayoutPanel2.SetColumnSpan(this.m_lblDataRels, 2);
			this.m_lblDataRels.Dock = System.Windows.Forms.DockStyle.Top;
			this.m_lblDataRels.Location = new System.Drawing.Point(0, 0);
			this.m_lblDataRels.Margin = new System.Windows.Forms.Padding(0, 0, 0, 3);
			this.m_lblDataRels.Name = "m_lblDataRels";
			this.m_lblDataRels.Size = new System.Drawing.Size(370, 13);
			this.m_lblDataRels.TabIndex = 0;
			this.m_lblDataRels.Text = "Select Data Relation:";
			this.m_btnOK.AutoSize = true;
			this.m_btnOK.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.m_btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.m_btnOK.Dock = System.Windows.Forms.DockStyle.Top;
			this.m_btnOK.Location = new System.Drawing.Point(298, 174);
			this.m_btnOK.Margin = new System.Windows.Forms.Padding(0, 3, 0, 0);
			this.m_btnOK.MinimumSize = new System.Drawing.Size(72, 23);
			this.m_btnOK.Name = "m_btnOK";
			this.m_btnOK.Size = new System.Drawing.Size(72, 23);
			this.m_btnOK.TabIndex = 4;
			this.m_btnOK.Text = "&OK";
			this.m_btnOK.UseVisualStyleBackColor = true;
			this.m_btnDelete.AutoSize = true;
			this.m_btnDelete.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.m_btnDelete.Dock = System.Windows.Forms.DockStyle.Top;
			this.m_btnDelete.Enabled = false;
			this.m_btnDelete.Location = new System.Drawing.Point(298, 45);
			this.m_btnDelete.Margin = new System.Windows.Forms.Padding(3, 3, 0, 3);
			this.m_btnDelete.MinimumSize = new System.Drawing.Size(72, 23);
			this.m_btnDelete.Name = "m_btnDelete";
			this.m_btnDelete.Size = new System.Drawing.Size(72, 23);
			this.m_btnDelete.TabIndex = 3;
			this.m_btnDelete.Text = "&Delete";
			this.m_btnDelete.UseVisualStyleBackColor = true;
			this.m_btnDelete.Click += new System.EventHandler(m_btnDelete_Click);
			this.m_btnAdd.AutoSize = true;
			this.m_btnAdd.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.m_btnAdd.Dock = System.Windows.Forms.DockStyle.Top;
			this.m_btnAdd.Location = new System.Drawing.Point(298, 16);
			this.m_btnAdd.Margin = new System.Windows.Forms.Padding(3, 0, 0, 3);
			this.m_btnAdd.MinimumSize = new System.Drawing.Size(72, 23);
			this.m_btnAdd.Name = "m_btnAdd";
			this.m_btnAdd.Size = new System.Drawing.Size(72, 23);
			this.m_btnAdd.TabIndex = 2;
			this.m_btnAdd.Text = "&Add…";
			this.m_btnAdd.UseVisualStyleBackColor = true;
			this.m_btnAdd.Click += new System.EventHandler(m_btnAdd_Click);
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
			this.tableLayoutPanel1.Size = new System.Drawing.Size(370, 197);
			this.tableLayoutPanel1.TabIndex = 5;
			this.tableLayoutPanel2.AutoSize = true;
			this.tableLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.tableLayoutPanel2.ColumnCount = 2;
			this.tableLayoutPanel1.SetColumnSpan(this.tableLayoutPanel2, 2);
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100f));
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel2.Controls.Add(this.m_btnAdd, 1, 1);
			this.tableLayoutPanel2.Controls.Add(this.m_btnDelete, 1, 2);
			this.tableLayoutPanel2.Controls.Add(this.m_lbRelations, 0, 1);
			this.tableLayoutPanel2.Controls.Add(this.m_lblDataRels, 0, 0);
			this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
			this.tableLayoutPanel2.Name = "tableLayoutPanel2";
			this.tableLayoutPanel2.RowCount = 4;
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100f));
			this.tableLayoutPanel2.Size = new System.Drawing.Size(370, 171);
			this.tableLayoutPanel2.TabIndex = 6;
			base.AcceptButton = this.m_btnOK;
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new System.Drawing.Size(384, 211);
			base.Controls.Add(this.tableLayoutPanel1);
			base.KeyPreview = true;
			this.MinimumSize = new System.Drawing.Size(400, 200);
			base.Name = "EditDataRelationsDialog";
			base.Padding = new System.Windows.Forms.Padding(7);
			this.RightToLeftLayout = true;
			base.ShowIcon = false;
			base.ShowInTaskbar = false;
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Edit Data Relations";
			base.KeyDown += new System.Windows.Forms.KeyEventHandler(EditDataRelationsDialog_KeyDown);
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			this.tableLayoutPanel2.ResumeLayout(false);
			this.tableLayoutPanel2.PerformLayout();
			base.ResumeLayout(false);
		}
	}
}
