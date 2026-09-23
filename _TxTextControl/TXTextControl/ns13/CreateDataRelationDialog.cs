using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using DocumentServer.Properties;
using DocumentServer.Windows.Forms;

namespace ns13
{
	internal class CreateDataRelationDialog : HighDpiForm
	{
		private DataSet dataSet_0;

		private IContainer icontainer_0;

		private CheckedListBox m_clbMainTable;

		private Button m_btnOK;

		private Button m_btnCancel;

		private CheckedListBox m_clbChildTable;

		private TableLayoutPanel tableLayoutPanel1;

		private ComboBox m_cbMainTable;

		private ComboBox m_cbChildTable;

		private Label m_lblTblMain;

		private Label m_lblTblChild;

		private Label m_lblColMain;

		private Label m_lblColChild;

		private TableLayoutPanel tableLayoutPanel2;

		internal static DialogResult smethod_0(DataSet dataSet_1, Form form_0)
		{
			return new CreateDataRelationDialog(dataSet_1)
			{
				RightToLeft = form_0.RightToLeft
			}.ShowDialog(form_0);
		}

		private void m_cbMainTable_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.method_6(this.m_clbMainTable, (string)this.m_cbMainTable.SelectedItem);
		}

		private void m_cbChildTable_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.method_6(this.m_clbChildTable, (string)this.m_cbChildTable.SelectedItem);
		}

		private void m_clbMainTable_ItemCheck(object sender, ItemCheckEventArgs e)
		{
			this.m_clbMainTable.ItemCheck -= m_clbMainTable_ItemCheck;
			if (e.NewValue == CheckState.Unchecked)
			{
				e.NewValue = CheckState.Checked;
			}
			else
			{
				for (int i = 0; i < this.m_clbMainTable.Items.Count; i++)
				{
					this.m_clbMainTable.SetItemChecked(i, value: false);
				}
			}
			this.m_clbMainTable.ItemCheck += m_clbMainTable_ItemCheck;
		}

		private void m_clbChildTable_ItemCheck(object sender, ItemCheckEventArgs e)
		{
			this.m_clbChildTable.ItemCheck -= m_clbChildTable_ItemCheck;
			if (e.NewValue == CheckState.Unchecked)
			{
				e.NewValue = CheckState.Checked;
			}
			else
			{
				for (int i = 0; i < this.m_clbChildTable.Items.Count; i++)
				{
					this.m_clbChildTable.SetItemChecked(i, value: false);
				}
			}
			this.m_clbChildTable.ItemCheck += m_clbChildTable_ItemCheck;
		}

		private void m_btnOK_Click(object sender, EventArgs e)
		{
			if (this.m_clbMainTable.CheckedItems.Count == 0)
			{
				MessageBox.Show(Resources.CREATE_DATA_REL_DLG_MSG_SEL_MAIN_TBL_COL, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				return;
			}
			if (this.m_clbChildTable.CheckedItems.Count == 0)
			{
				MessageBox.Show(Resources.CREATE_DATA_REL_DLG_MSG_SEL_CHILD_TBL_COL, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				return;
			}
			string string_ = (string)this.m_cbMainTable.SelectedItem;
			string string_2 = (string)this.m_clbMainTable.CheckedItems[0];
			string string_3 = (string)this.m_cbChildTable.SelectedItem;
			string string_4 = (string)this.m_clbChildTable.CheckedItems[0];
			if (this.method_2("", string_, string_2, string_3, string_4))
			{
				base.DialogResult = DialogResult.OK;
			}
			base.Close();
		}

		private bool method_2(string string_0, string string_1, string string_2, string string_3, string string_4)
		{
			DataRelation dataRelation = null;
			try
			{
				dataRelation = new DataRelation(string_0, this.dataSet_0.Tables[string_1].Columns[string_2], this.dataSet_0.Tables[string_3].Columns[string_4], createConstraints: false);
				this.dataSet_0.Relations.Add(dataRelation);
			}
			catch (ArgumentException)
			{
				return true;
			}
			catch
			{
				if (dataRelation != null)
				{
					try
					{
						this.dataSet_0.Relations.Remove(dataRelation);
					}
					catch
					{
					}
				}
				return false;
			}
			return true;
		}

		private CreateDataRelationDialog(DataSet dataSet_1)
		{
			if (dataSet_1 == null)
			{
				throw new ArgumentNullException("dataSet");
			}
			this.InitializeComponent();
			this.method_3();
			this.dataSet_0 = dataSet_1;
			this.method_4();
		}

		private void method_3()
		{
			this.Text = Resources.CREATE_DATA_REL_DLG_TITLE;
			this.m_lblTblMain.Text = Resources.CREATE_DATA_REL_DLG_LBL_TBL_MAIN;
			this.m_lblTblChild.Text = Resources.CREATE_DATA_REL_DLG_LBL_TBL_CHILD;
			this.m_lblColMain.Text = Resources.CREATE_DATA_REL_DLG_LBL_COL_MAIN;
			this.m_lblColChild.Text = Resources.CREATE_DATA_REL_DLG_LBL_COL_CHILD;
			this.m_btnOK.Text = Resources.CREATE_DATA_REL_DLG_BTN_OK;
			this.m_btnCancel.Text = Resources.CREATE_DATA_REL_DLG_BTN_CANCEL;
		}

		private void method_4()
		{
			this.method_5();
		}

		private void method_5()
		{
			foreach (DataTable table in this.dataSet_0.Tables)
			{
				this.m_cbMainTable.Items.Add(table.TableName);
				this.m_cbChildTable.Items.Add(table.TableName);
			}
			this.m_cbMainTable.SelectedItem = this.dataSet_0.Tables[0].TableName;
			this.m_cbChildTable.SelectedIndex = Math.Min(this.m_cbChildTable.Items.Count - 1, 0);
		}

		private void method_6(CheckedListBox checkedListBox_0, string string_0)
		{
			checkedListBox_0.Items.Clear();
			DataTable dataTable = this.dataSet_0.Tables[string_0];
			if (dataTable == null)
			{
				return;
			}
			foreach (DataColumn column in dataTable.Columns)
			{
				checkedListBox_0.Items.Add(column.ColumnName);
			}
			if (checkedListBox_0.Items.Count != 0)
			{
				checkedListBox_0.SetItemChecked(0, value: true);
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
			this.m_clbMainTable = new System.Windows.Forms.CheckedListBox();
			this.m_btnOK = new System.Windows.Forms.Button();
			this.m_btnCancel = new System.Windows.Forms.Button();
			this.m_clbChildTable = new System.Windows.Forms.CheckedListBox();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.m_cbMainTable = new System.Windows.Forms.ComboBox();
			this.m_cbChildTable = new System.Windows.Forms.ComboBox();
			this.m_lblTblMain = new System.Windows.Forms.Label();
			this.m_lblTblChild = new System.Windows.Forms.Label();
			this.m_lblColMain = new System.Windows.Forms.Label();
			this.m_lblColChild = new System.Windows.Forms.Label();
			this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
			this.tableLayoutPanel1.SuspendLayout();
			this.tableLayoutPanel2.SuspendLayout();
			base.SuspendLayout();
			this.m_clbMainTable.CheckOnClick = true;
			this.m_clbMainTable.Dock = System.Windows.Forms.DockStyle.Left;
			this.m_clbMainTable.FormattingEnabled = true;
			this.m_clbMainTable.IntegralHeight = false;
			this.m_clbMainTable.Location = new System.Drawing.Point(3, 56);
			this.m_clbMainTable.MinimumSize = new System.Drawing.Size(189, 267);
			this.m_clbMainTable.Name = "m_clbMainTable";
			this.m_clbMainTable.Size = new System.Drawing.Size(189, 267);
			this.m_clbMainTable.TabIndex = 3;
			this.m_clbMainTable.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(m_clbMainTable_ItemCheck);
			this.m_btnOK.AutoSize = true;
			this.m_btnOK.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.m_btnOK.Dock = System.Windows.Forms.DockStyle.Top;
			this.m_btnOK.Location = new System.Drawing.Point(160, 332);
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
			this.m_btnCancel.Location = new System.Drawing.Point(238, 332);
			this.m_btnCancel.Margin = new System.Windows.Forms.Padding(3, 3, 0, 0);
			this.m_btnCancel.MinimumSize = new System.Drawing.Size(72, 23);
			this.m_btnCancel.Name = "m_btnCancel";
			this.m_btnCancel.Size = new System.Drawing.Size(72, 23);
			this.m_btnCancel.TabIndex = 2;
			this.m_btnCancel.Text = "Cancel";
			this.m_btnCancel.UseVisualStyleBackColor = true;
			this.m_clbChildTable.CheckOnClick = true;
			this.m_clbChildTable.Dock = System.Windows.Forms.DockStyle.Left;
			this.m_clbChildTable.FormattingEnabled = true;
			this.m_clbChildTable.IntegralHeight = false;
			this.m_clbChildTable.Location = new System.Drawing.Point(166, 56);
			this.m_clbChildTable.MinimumSize = new System.Drawing.Size(189, 267);
			this.m_clbChildTable.Name = "m_clbChildTable";
			this.m_clbChildTable.Size = new System.Drawing.Size(189, 267);
			this.m_clbChildTable.TabIndex = 7;
			this.m_clbChildTable.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(m_clbChildTable_ItemCheck);
			this.tableLayoutPanel1.AutoSize = true;
			this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.tableLayoutPanel1.ColumnCount = 3;
			this.tableLayoutPanel2.SetColumnSpan(this.tableLayoutPanel1, 3);
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 47.05882f));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5.882353f));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 47.05883f));
			this.tableLayoutPanel1.Controls.Add(this.m_clbChildTable, 2, 3);
			this.tableLayoutPanel1.Controls.Add(this.m_clbMainTable, 0, 3);
			this.tableLayoutPanel1.Controls.Add(this.m_cbMainTable, 0, 1);
			this.tableLayoutPanel1.Controls.Add(this.m_cbChildTable, 2, 1);
			this.tableLayoutPanel1.Controls.Add(this.m_lblTblMain, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.m_lblTblChild, 2, 0);
			this.tableLayoutPanel1.Controls.Add(this.m_lblColMain, 0, 2);
			this.tableLayoutPanel1.Controls.Add(this.m_lblColChild, 2, 2);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0, 0, 0, 3);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 4;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100f));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(310, 326);
			this.tableLayoutPanel1.TabIndex = 0;
			this.m_cbMainTable.Dock = System.Windows.Forms.DockStyle.Left;
			this.m_cbMainTable.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.m_cbMainTable.FormattingEnabled = true;
			this.m_cbMainTable.Location = new System.Drawing.Point(3, 16);
			this.m_cbMainTable.MinimumSize = new System.Drawing.Size(189, 0);
			this.m_cbMainTable.Name = "m_cbMainTable";
			this.m_cbMainTable.Size = new System.Drawing.Size(189, 21);
			this.m_cbMainTable.TabIndex = 1;
			this.m_cbMainTable.SelectedIndexChanged += new System.EventHandler(m_cbMainTable_SelectedIndexChanged);
			this.m_cbChildTable.Dock = System.Windows.Forms.DockStyle.Left;
			this.m_cbChildTable.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.m_cbChildTable.FormattingEnabled = true;
			this.m_cbChildTable.Location = new System.Drawing.Point(166, 16);
			this.m_cbChildTable.MinimumSize = new System.Drawing.Size(189, 0);
			this.m_cbChildTable.Name = "m_cbChildTable";
			this.m_cbChildTable.Size = new System.Drawing.Size(189, 21);
			this.m_cbChildTable.TabIndex = 5;
			this.m_cbChildTable.SelectedIndexChanged += new System.EventHandler(m_cbChildTable_SelectedIndexChanged);
			this.m_lblTblMain.AutoSize = true;
			this.m_lblTblMain.Dock = System.Windows.Forms.DockStyle.Top;
			this.m_lblTblMain.Location = new System.Drawing.Point(3, 0);
			this.m_lblTblMain.Name = "m_lblTblMain";
			this.m_lblTblMain.Size = new System.Drawing.Size(139, 13);
			this.m_lblTblMain.TabIndex = 0;
			this.m_lblTblMain.Text = "Main Table:";
			this.m_lblTblChild.AutoSize = true;
			this.m_lblTblChild.Dock = System.Windows.Forms.DockStyle.Top;
			this.m_lblTblChild.Location = new System.Drawing.Point(166, 0);
			this.m_lblTblChild.Name = "m_lblTblChild";
			this.m_lblTblChild.Size = new System.Drawing.Size(141, 13);
			this.m_lblTblChild.TabIndex = 4;
			this.m_lblTblChild.Text = "Child Table:";
			this.m_lblColMain.AutoSize = true;
			this.m_lblColMain.Dock = System.Windows.Forms.DockStyle.Top;
			this.m_lblColMain.Location = new System.Drawing.Point(3, 40);
			this.m_lblColMain.Name = "m_lblColMain";
			this.m_lblColMain.Size = new System.Drawing.Size(139, 13);
			this.m_lblColMain.TabIndex = 2;
			this.m_lblColMain.Text = "Column:";
			this.m_lblColChild.AutoSize = true;
			this.m_lblColChild.Dock = System.Windows.Forms.DockStyle.Top;
			this.m_lblColChild.Location = new System.Drawing.Point(166, 40);
			this.m_lblColChild.Name = "m_lblColChild";
			this.m_lblColChild.Size = new System.Drawing.Size(141, 13);
			this.m_lblColChild.TabIndex = 6;
			this.m_lblColChild.Text = "Column:";
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
			this.tableLayoutPanel2.Size = new System.Drawing.Size(310, 342);
			this.tableLayoutPanel2.TabIndex = 3;
			base.AcceptButton = this.m_btnOK;
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.CancelButton = this.m_btnCancel;
			base.ClientSize = new System.Drawing.Size(324, 356);
			base.Controls.Add(this.tableLayoutPanel2);
			this.MinimumSize = new System.Drawing.Size(340, 395);
			base.Name = "CreateDataRelationDialog";
			base.Padding = new System.Windows.Forms.Padding(7);
			this.RightToLeftLayout = true;
			base.ShowIcon = false;
			base.ShowInTaskbar = false;
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Create Data Relation";
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			this.tableLayoutPanel2.ResumeLayout(false);
			this.tableLayoutPanel2.PerformLayout();
			base.ResumeLayout(false);
			base.PerformLayout();
		}
	}
}
