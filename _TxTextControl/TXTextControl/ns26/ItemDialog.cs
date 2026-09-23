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
	internal class ItemDialog : Form
	{
		private ResourceManager resourceManager_0 = new ResourceManager(typeof(TextControlCore));

		private string string_0;

		private ListBox listBox_0;

		private uint uint_0;

		private IContainer icontainer_0;

		private TableLayoutPanel m_tlpMainPanel;

		private TextBox m_tbxItemText;

		private Label m_lblItemText;

		private System.Windows.Forms.Button m_btnOK;

		private System.Windows.Forms.Button m_btnCancel;

		internal string String_0 => this.m_tbxItemText.Text;

		public ItemDialog(string string_1, ListBox listBox_1, TextControl textControl_0)
		{
			this.listBox_0 = listBox_1;
			this.InitializeComponent();
			if ((this.string_0 = string_1) != null)
			{
				this.Text = this.resourceManager_0.GetString("ID_ITEM_CAPTION_EDIT");
				this.m_tbxItemText.Text = string_1;
			}
			else
			{
				this.Text = this.resourceManager_0.GetString("ID_ITEM_CAPTION_NEW");
			}
			this.m_lblItemText.Text = this.resourceManager_0.GetString("ID_ITEM_TEXT");
			this.m_btnOK.Text = this.resourceManager_0.GetString("ID_ITEM_OK");
			this.m_btnCancel.Text = this.resourceManager_0.GetString("ID_ITEM_CANCEL");
		}

		internal void m_tbxItemText_TextChanged(object sender, EventArgs e)
		{
			this.m_btnOK.Enabled = this.m_tbxItemText.Text.Length > 0 && (this.string_0 != null || !this.listBox_0.Items.Contains(this.m_tbxItemText.Text));
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
			this.m_tbxItemText = new System.Windows.Forms.TextBox();
			this.m_lblItemText = new System.Windows.Forms.Label();
			this.m_btnOK = new System.Windows.Forms.Button();
			this.m_btnCancel = new System.Windows.Forms.Button();
			this.m_tlpMainPanel.SuspendLayout();
			base.SuspendLayout();
			this.m_tlpMainPanel.AutoSize = true;
			this.m_tlpMainPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.m_tlpMainPanel.ColumnCount = 3;
			this.m_tlpMainPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100f));
			this.m_tlpMainPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.m_tlpMainPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.m_tlpMainPanel.Controls.Add(this.m_tbxItemText, 0, 1);
			this.m_tlpMainPanel.Controls.Add(this.m_lblItemText, 0, 0);
			this.m_tlpMainPanel.Controls.Add(this.m_btnOK, 1, 2);
			this.m_tlpMainPanel.Controls.Add(this.m_btnCancel, 2, 2);
			this.m_tlpMainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.m_tlpMainPanel.Location = new System.Drawing.Point(14, 13);
			this.m_tlpMainPanel.Margin = new System.Windows.Forms.Padding(0);
			this.m_tlpMainPanel.Name = "m_tlpMainPanel";
			this.m_tlpMainPanel.RowCount = 3;
			this.m_tlpMainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.m_tlpMainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.m_tlpMainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.m_tlpMainPanel.Size = new System.Drawing.Size(540, 124);
			this.m_tlpMainPanel.TabIndex = 0;
			this.m_tlpMainPanel.SetColumnSpan(this.m_tbxItemText, 3);
			this.m_tbxItemText.Dock = System.Windows.Forms.DockStyle.Top;
			this.m_tbxItemText.Location = new System.Drawing.Point(0, 37);
			this.m_tbxItemText.Margin = new System.Windows.Forms.Padding(0, 6, 0, 6);
			this.m_tbxItemText.MinimumSize = new System.Drawing.Size(546, 4);
			this.m_tbxItemText.Name = "m_tbxItemText";
			this.m_tbxItemText.Size = new System.Drawing.Size(546, 31);
			this.m_tbxItemText.TabIndex = 1;
			this.m_tbxItemText.TextChanged += new System.EventHandler(m_tbxItemText_TextChanged);
			this.m_lblItemText.AutoSize = true;
			this.m_tlpMainPanel.SetColumnSpan(this.m_lblItemText, 3);
			this.m_lblItemText.Dock = System.Windows.Forms.DockStyle.Top;
			this.m_lblItemText.Location = new System.Drawing.Point(0, 0);
			this.m_lblItemText.Margin = new System.Windows.Forms.Padding(0, 0, 0, 6);
			this.m_lblItemText.Name = "m_lblItemText";
			this.m_lblItemText.Size = new System.Drawing.Size(540, 25);
			this.m_lblItemText.TabIndex = 0;
			this.m_lblItemText.Text = "Item Text:";
			this.m_btnOK.AutoSize = true;
			this.m_btnOK.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.m_btnOK.Dock = System.Windows.Forms.DockStyle.Top;
			this.m_btnOK.Enabled = false;
			this.m_btnOK.Location = new System.Drawing.Point(228, 80);
			this.m_btnOK.Margin = new System.Windows.Forms.Padding(6, 6, 6, 0);
			this.m_btnOK.MinimumSize = new System.Drawing.Size(150, 44);
			this.m_btnOK.Name = "m_btnOK";
			this.m_btnOK.Size = new System.Drawing.Size(150, 44);
			this.m_btnOK.TabIndex = 2;
			this.m_btnOK.Text = "OK";
			this.m_btnOK.UseVisualStyleBackColor = true;
			this.m_btnOK.Click += new System.EventHandler(m_btnOK_Click);
			this.m_btnCancel.AutoSize = true;
			this.m_btnCancel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.m_btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.m_btnCancel.Dock = System.Windows.Forms.DockStyle.Top;
			this.m_btnCancel.Location = new System.Drawing.Point(390, 80);
			this.m_btnCancel.Margin = new System.Windows.Forms.Padding(6, 6, 0, 0);
			this.m_btnCancel.MinimumSize = new System.Drawing.Size(150, 44);
			this.m_btnCancel.Name = "m_btnCancel";
			this.m_btnCancel.Size = new System.Drawing.Size(150, 44);
			this.m_btnCancel.TabIndex = 3;
			this.m_btnCancel.Text = "Cancel";
			this.m_btnCancel.UseVisualStyleBackColor = true;
			base.AcceptButton = this.m_btnOK;
			base.AutoScaleDimensions = new System.Drawing.SizeF(12f, 25f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.CancelButton = this.m_btnCancel;
			base.ClientSize = new System.Drawing.Size(568, 150);
			base.Controls.Add(this.m_tlpMainPanel);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "ItemDialog";
			base.Padding = new System.Windows.Forms.Padding(14, 13, 14, 13);
			base.ShowIcon = false;
			base.ShowInTaskbar = false;
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.m_tlpMainPanel.ResumeLayout(false);
			this.m_tlpMainPanel.PerformLayout();
			base.ResumeLayout(false);
			base.PerformLayout();
		}
	}
}
