using System;
using System.ComponentModel;
using System.Drawing;
using System.Resources;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using ns21;
using ns27;
using TXTextControl;

namespace ns26
{
	internal class NewItemsDialog : Form
	{
		private ResourceManager resourceManager_0 = new ResourceManager(typeof(TextControlCore));

		private TextControl textControl_0;

		private uint uint_0;

		private IContainer icontainer_0;

		private TableLayoutPanel m_tlpMainPanel;

		private System.Windows.Forms.Button m_btnOK;

		private System.Windows.Forms.Button m_btnCancel;

		private TableLayoutPanel m_tlpItems;

		private ListBox m_lbxItems;

		private System.Windows.Forms.Button m_btnAdd;

		private System.Windows.Forms.Button m_btnRemove;

		private System.Windows.Forms.Button m_btnEdit;

		private Label m_lblItems;

		private System.Windows.Forms.Button m_btnMoveDown;

		private System.Windows.Forms.Button m_btnMoveUp;

		internal string[] String_0
		{
			get
			{
				string[] array = new string[this.m_lbxItems.Items.Count];
				for (int i = 0; i < array.Length; i++)
				{
					array[i] = this.m_lbxItems.Items[i].ToString();
				}
				return array;
			}
		}

		internal NewItemsDialog(string[] string_0, TextControl textControl_1)
		{
			this.textControl_0 = textControl_1;
			this.InitializeComponent();
			this.m_lbxItems.Items.AddRange(string_0);
			if (this.m_lbxItems.Items.Count > 0)
			{
				this.m_lbxItems.SelectedIndex = 0;
			}
			this.Text = this.resourceManager_0.GetString("ID_NEWITEMS_CAPTION");
			this.m_lblItems.Text = this.resourceManager_0.GetString("ID_NEWITEMS_ITEMS");
			this.m_btnAdd.Text = this.resourceManager_0.GetString("ID_NEWITEMS_ADD");
			this.m_btnRemove.Text = this.resourceManager_0.GetString("ID_NEWITEMS_REMOVE");
			this.m_btnEdit.Text = this.resourceManager_0.GetString("ID_NEWITEMS_EDIT");
			this.m_btnMoveUp.Text = this.resourceManager_0.GetString("ID_NEWITEMS_MOVE_UP");
			this.m_btnMoveDown.Text = this.resourceManager_0.GetString("ID_NEWITEMS_MOVE_DOWN");
			this.m_btnOK.Text = this.resourceManager_0.GetString("ID_NEWITEMS_OK");
			this.m_btnCancel.Text = this.resourceManager_0.GetString("ID_NEWITEMS_CANCEL");
		}

		private void m_btnAdd_Click(object sender, EventArgs e)
		{
			ItemDialog itemDialog = new ItemDialog(null, this.m_lbxItems, this.textControl_0);
			itemDialog.RightToLeft = this.textControl_0.RightToLeft;
			if (itemDialog.ShowDialog() == DialogResult.OK)
			{
				int num = this.m_lbxItems.SelectedIndex + 1;
				this.m_lbxItems.Items.Insert(num, itemDialog.String_0);
				this.m_lbxItems.SelectedIndex = num;
			}
		}

		private void m_btnRemove_Click(object sender, EventArgs e)
		{
			int selectedIndex = this.m_lbxItems.SelectedIndex;
			this.m_lbxItems.Items.RemoveAt(selectedIndex);
			this.m_lbxItems.SelectedIndex = Math.Min(this.m_lbxItems.Items.Count - 1, selectedIndex);
		}

		private void m_btnEdit_Click(object sender, EventArgs e)
		{
			ItemDialog itemDialog = new ItemDialog(this.m_lbxItems.SelectedItem.ToString(), this.m_lbxItems, this.textControl_0);
			itemDialog.RightToLeft = this.textControl_0.RightToLeft;
			if (itemDialog.ShowDialog() == DialogResult.OK)
			{
				int selectedIndex = this.m_lbxItems.SelectedIndex;
				this.m_lbxItems.Items.RemoveAt(selectedIndex);
				this.m_lbxItems.Items.Insert(selectedIndex, itemDialog.String_0);
				this.m_lbxItems.SelectedIndex = selectedIndex;
			}
		}

		private void m_btnMoveUp_Click(object sender, EventArgs e)
		{
			this.method_0(this.m_lbxItems.SelectedIndex, -1, this.m_lbxItems.SelectedItem);
			this.m_btnMoveUp.Select();
		}

		private void m_btnMoveDown_Click(object sender, EventArgs e)
		{
			this.method_0(this.m_lbxItems.SelectedIndex, 1, this.m_lbxItems.SelectedItem);
			this.m_btnMoveDown.Select();
		}

		private void m_lbxItems_SelectedIndexChanged(object sender, EventArgs e)
		{
			System.Windows.Forms.Button btnRemove = this.m_btnRemove;
			bool enabled = (this.m_btnEdit.Enabled = this.m_lbxItems.SelectedIndex >= 0);
			btnRemove.Enabled = enabled;
			this.m_btnMoveUp.Enabled = this.m_lbxItems.SelectedIndex > 0;
			this.m_btnMoveDown.Enabled = this.m_lbxItems.SelectedIndex >= 0 && this.m_lbxItems.SelectedIndex < this.m_lbxItems.Items.Count - 1;
		}

		private void m_btnOK_Click(object sender, EventArgs e)
		{
			base.DialogResult = DialogResult.OK;
		}

		protected override void OnHandleCreated(EventArgs eventArgs_0)
		{
			this.uint_0 = Class468.smethod_0(null, this);
			Class429.Struct83 struct83_ = default(Class429.Struct83);
			Class429.GetWindowRect(base.Handle, ref struct83_);
			Class468.smethod_1(this.uint_0, struct83_, this);
			base.OnHandleCreated(eventArgs_0);
		}

		protected override void WndProc(ref Message message)
		{
			int msg = message.Msg;
			if (msg == 736)
			{
				uint num = Class429.smethod_5(message.WParam.ToInt32());
				if (num != this.uint_0)
				{
					Class429.Struct83 struct83_ = (Class429.Struct83)Marshal.PtrToStructure(message.LParam, typeof(Class429.Struct83));
					this.Font = new Font(this.Font.Name, this.Font.Size * (float)num / (float)this.uint_0, this.Font.Style, this.Font.Unit);
					this.uint_0 = num;
					Class468.smethod_1(this.uint_0, struct83_, this);
				}
			}
			else
			{
				base.WndProc(ref message);
			}
		}

		private void method_0(int int_0, int int_1, object object_0)
		{
			this.m_lbxItems.Items.RemoveAt(int_0);
			this.m_lbxItems.Items.Insert(int_0 + int_1, object_0);
			this.m_lbxItems.SelectedIndex = int_0 + int_1;
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
			this.m_tlpMainPanel = new System.Windows.Forms.TableLayoutPanel();
			this.m_btnOK = new System.Windows.Forms.Button();
			this.m_btnCancel = new System.Windows.Forms.Button();
			this.m_tlpItems = new System.Windows.Forms.TableLayoutPanel();
			this.m_btnMoveDown = new System.Windows.Forms.Button();
			this.m_lbxItems = new System.Windows.Forms.ListBox();
			this.m_btnAdd = new System.Windows.Forms.Button();
			this.m_btnRemove = new System.Windows.Forms.Button();
			this.m_btnEdit = new System.Windows.Forms.Button();
			this.m_btnMoveUp = new System.Windows.Forms.Button();
			this.m_lblItems = new System.Windows.Forms.Label();
			this.m_tlpMainPanel.SuspendLayout();
			this.m_tlpItems.SuspendLayout();
			base.SuspendLayout();
			this.m_tlpMainPanel.AutoSize = true;
			this.m_tlpMainPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.m_tlpMainPanel.ColumnCount = 3;
			this.m_tlpMainPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100f));
			this.m_tlpMainPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.m_tlpMainPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.m_tlpMainPanel.Controls.Add(this.m_btnOK, 1, 2);
			this.m_tlpMainPanel.Controls.Add(this.m_btnCancel, 2, 2);
			this.m_tlpMainPanel.Controls.Add(this.m_tlpItems, 0, 1);
			this.m_tlpMainPanel.Controls.Add(this.m_lblItems, 0, 0);
			this.m_tlpMainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.m_tlpMainPanel.Location = new System.Drawing.Point(7, 7);
			this.m_tlpMainPanel.Margin = new System.Windows.Forms.Padding(0);
			this.m_tlpMainPanel.Name = "m_tlpMainPanel";
			this.m_tlpMainPanel.Padding = new System.Windows.Forms.Padding(5);
			this.m_tlpMainPanel.RowCount = 3;
			this.m_tlpMainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.m_tlpMainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.m_tlpMainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.m_tlpMainPanel.Size = new System.Drawing.Size(332, 204);
			this.m_tlpMainPanel.TabIndex = 0;
			this.m_btnOK.AutoSize = true;
			this.m_btnOK.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.m_btnOK.Dock = System.Windows.Forms.DockStyle.Top;
			this.m_btnOK.Location = new System.Drawing.Point(171, 190);
			this.m_btnOK.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
			this.m_btnOK.MinimumSize = new System.Drawing.Size(75, 23);
			this.m_btnOK.Name = "m_btnOK";
			this.m_btnOK.Size = new System.Drawing.Size(75, 23);
			this.m_btnOK.TabIndex = 8;
			this.m_btnOK.Text = "OK";
			this.m_btnOK.UseVisualStyleBackColor = true;
			this.m_btnOK.Click += new System.EventHandler(m_btnOK_Click);
			this.m_btnCancel.AutoSize = true;
			this.m_btnCancel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.m_btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.m_btnCancel.Dock = System.Windows.Forms.DockStyle.Top;
			this.m_btnCancel.Location = new System.Drawing.Point(252, 190);
			this.m_btnCancel.Margin = new System.Windows.Forms.Padding(3, 3, 0, 0);
			this.m_btnCancel.MinimumSize = new System.Drawing.Size(75, 23);
			this.m_btnCancel.Name = "m_btnCancel";
			this.m_btnCancel.Size = new System.Drawing.Size(75, 23);
			this.m_btnCancel.TabIndex = 9;
			this.m_btnCancel.Text = "Cancel";
			this.m_btnCancel.UseVisualStyleBackColor = true;
			this.m_tlpItems.AutoSize = true;
			this.m_tlpItems.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.m_tlpItems.ColumnCount = 2;
			this.m_tlpMainPanel.SetColumnSpan(this.m_tlpItems, 3);
			this.m_tlpItems.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.m_tlpItems.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.m_tlpItems.Controls.Add(this.m_btnMoveDown, 0, 4);
			this.m_tlpItems.Controls.Add(this.m_lbxItems, 0, 0);
			this.m_tlpItems.Controls.Add(this.m_btnAdd, 1, 0);
			this.m_tlpItems.Controls.Add(this.m_btnRemove, 1, 1);
			this.m_tlpItems.Controls.Add(this.m_btnEdit, 1, 2);
			this.m_tlpItems.Controls.Add(this.m_btnMoveUp, 1, 3);
			this.m_tlpItems.Dock = System.Windows.Forms.DockStyle.Fill;
			this.m_tlpItems.Location = new System.Drawing.Point(5, 21);
			this.m_tlpItems.Margin = new System.Windows.Forms.Padding(0);
			this.m_tlpItems.Name = "m_tlpItems";
			this.m_tlpItems.RowCount = 5;
			this.m_tlpItems.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.m_tlpItems.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.m_tlpItems.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.m_tlpItems.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.m_tlpItems.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100f));
			this.m_tlpItems.Size = new System.Drawing.Size(322, 166);
			this.m_tlpItems.TabIndex = 1;
			this.m_tlpItems.TabStop = true;
			this.m_btnMoveDown.AutoSize = true;
			this.m_btnMoveDown.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.m_btnMoveDown.Dock = System.Windows.Forms.DockStyle.Top;
			this.m_btnMoveDown.Enabled = false;
			this.m_btnMoveDown.Location = new System.Drawing.Point(306, 107);
			this.m_btnMoveDown.Margin = new System.Windows.Forms.Padding(3, 0, 0, 3);
			this.m_btnMoveDown.MinimumSize = new System.Drawing.Size(75, 23);
			this.m_btnMoveDown.Name = "m_btnMoveDown";
			this.m_btnMoveDown.Size = new System.Drawing.Size(75, 23);
			this.m_btnMoveDown.TabIndex = 7;
			this.m_btnMoveDown.Text = "Move Down";
			this.m_btnMoveDown.UseVisualStyleBackColor = true;
			this.m_btnMoveDown.Click += new System.EventHandler(m_btnMoveDown_Click);
			this.m_lbxItems.Dock = System.Windows.Forms.DockStyle.Fill;
			this.m_lbxItems.FormattingEnabled = true;
			this.m_lbxItems.IntegralHeight = false;
			this.m_lbxItems.Location = new System.Drawing.Point(0, 3);
			this.m_lbxItems.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
			this.m_lbxItems.MinimumSize = new System.Drawing.Size(300, 160);
			this.m_lbxItems.Name = "m_lbxItems";
			this.m_tlpItems.SetRowSpan(this.m_lbxItems, 5);
			this.m_lbxItems.Size = new System.Drawing.Size(300, 160);
			this.m_lbxItems.TabIndex = 2;
			this.m_lbxItems.SelectedIndexChanged += new System.EventHandler(m_lbxItems_SelectedIndexChanged);
			this.m_btnAdd.AutoSize = true;
			this.m_btnAdd.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.m_btnAdd.Dock = System.Windows.Forms.DockStyle.Top;
			this.m_btnAdd.Location = new System.Drawing.Point(306, 3);
			this.m_btnAdd.Margin = new System.Windows.Forms.Padding(3, 3, 0, 3);
			this.m_btnAdd.MinimumSize = new System.Drawing.Size(75, 23);
			this.m_btnAdd.Name = "m_btnAdd";
			this.m_btnAdd.Size = new System.Drawing.Size(75, 23);
			this.m_btnAdd.TabIndex = 3;
			this.m_btnAdd.Text = "Add...";
			this.m_btnAdd.UseVisualStyleBackColor = true;
			this.m_btnAdd.Click += new System.EventHandler(m_btnAdd_Click);
			this.m_btnRemove.AutoSize = true;
			this.m_btnRemove.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.m_btnRemove.Dock = System.Windows.Forms.DockStyle.Top;
			this.m_btnRemove.Enabled = false;
			this.m_btnRemove.Location = new System.Drawing.Point(306, 29);
			this.m_btnRemove.Margin = new System.Windows.Forms.Padding(3, 0, 0, 3);
			this.m_btnRemove.MinimumSize = new System.Drawing.Size(75, 23);
			this.m_btnRemove.Name = "m_btnRemove";
			this.m_btnRemove.Size = new System.Drawing.Size(75, 23);
			this.m_btnRemove.TabIndex = 4;
			this.m_btnRemove.Text = "Remove";
			this.m_btnRemove.UseVisualStyleBackColor = true;
			this.m_btnRemove.Click += new System.EventHandler(m_btnRemove_Click);
			this.m_btnEdit.AutoSize = true;
			this.m_btnEdit.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.m_btnEdit.Dock = System.Windows.Forms.DockStyle.Top;
			this.m_btnEdit.Enabled = false;
			this.m_btnEdit.Location = new System.Drawing.Point(306, 55);
			this.m_btnEdit.Margin = new System.Windows.Forms.Padding(3, 0, 0, 3);
			this.m_btnEdit.MinimumSize = new System.Drawing.Size(75, 23);
			this.m_btnEdit.Name = "m_btnEdit";
			this.m_btnEdit.Size = new System.Drawing.Size(75, 23);
			this.m_btnEdit.TabIndex = 5;
			this.m_btnEdit.Text = "Edit...";
			this.m_btnEdit.UseVisualStyleBackColor = true;
			this.m_btnEdit.Click += new System.EventHandler(m_btnEdit_Click);
			this.m_btnMoveUp.AutoSize = true;
			this.m_btnMoveUp.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.m_btnMoveUp.Dock = System.Windows.Forms.DockStyle.Top;
			this.m_btnMoveUp.Enabled = false;
			this.m_btnMoveUp.Location = new System.Drawing.Point(306, 81);
			this.m_btnMoveUp.Margin = new System.Windows.Forms.Padding(3, 0, 0, 3);
			this.m_btnMoveUp.MinimumSize = new System.Drawing.Size(75, 23);
			this.m_btnMoveUp.Name = "m_btnMoveUp";
			this.m_btnMoveUp.Size = new System.Drawing.Size(75, 23);
			this.m_btnMoveUp.TabIndex = 6;
			this.m_btnMoveUp.Text = "Move Up";
			this.m_btnMoveUp.UseVisualStyleBackColor = true;
			this.m_btnMoveUp.Click += new System.EventHandler(m_btnMoveUp_Click);
			this.m_lblItems.AutoSize = true;
			this.m_tlpMainPanel.SetColumnSpan(this.m_lblItems, 3);
			this.m_lblItems.Dock = System.Windows.Forms.DockStyle.Top;
			this.m_lblItems.Location = new System.Drawing.Point(5, 5);
			this.m_lblItems.Margin = new System.Windows.Forms.Padding(0, 0, 3, 3);
			this.m_lblItems.Name = "m_lblItems";
			this.m_lblItems.Size = new System.Drawing.Size(319, 13);
			this.m_lblItems.TabIndex = 0;
			this.m_lblItems.Text = "Items:";
			base.AcceptButton = this.m_btnOK;
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.CancelButton = this.m_btnCancel;
			base.ClientSize = new System.Drawing.Size(346, 218);
			base.Controls.Add(this.m_tlpMainPanel);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.Margin = new System.Windows.Forms.Padding(2);
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "NewItemsDialog";
			base.Padding = new System.Windows.Forms.Padding(7);
			base.ShowIcon = false;
			base.ShowInTaskbar = false;
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Specify Items";
			this.m_tlpMainPanel.ResumeLayout(false);
			this.m_tlpMainPanel.PerformLayout();
			this.m_tlpItems.ResumeLayout(false);
			this.m_tlpItems.PerformLayout();
			base.ResumeLayout(false);
			base.PerformLayout();
		}
	}
}
