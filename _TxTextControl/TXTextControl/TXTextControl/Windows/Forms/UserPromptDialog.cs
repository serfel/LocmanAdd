using System;
using System.ComponentModel;
using System.Drawing;
using System.Resources;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using ns21;
using ns27;

namespace TXTextControl.Windows.Forms
{
	public class UserPromptDialog : Form
	{
		private ResourceManager resourceManager_0 = new ResourceManager(typeof(TextControlCore));

		private uint uint_0;

		private IContainer icontainer_0;

		private TableLayoutPanel tableLayoutPanel1;

		private System.Windows.Forms.Button m_btnOK;

		private System.Windows.Forms.Button m_btnCancel;

		private Label m_lblInput;

		private TextBox m_txtInput;

		public bool IsPassword
		{
			get
			{
				if (this.m_txtInput.PasswordChar == '\0')
				{
					return this.m_txtInput.UseSystemPasswordChar;
				}
				return true;
			}
			set
			{
				if (value)
				{
					this.m_txtInput.PasswordChar = '*';
					this.m_txtInput.UseSystemPasswordChar = true;
				}
				else
				{
					this.m_txtInput.PasswordChar = '\0';
					this.m_txtInput.UseSystemPasswordChar = false;
				}
			}
		}

		public string Value => this.m_txtInput.Text;

		public UserPromptDialog(string caption, string label, string value)
		{
			this.InitializeComponent();
			this.method_0();
			this.Text = caption;
			this.m_lblInput.Text = label ?? "";
			this.m_txtInput.Text = value ?? "";
		}

		private void method_0()
		{
			this.m_btnOK.Text = this.resourceManager_0.GetString("ID_FIELDNAVIGATOR_OK");
			this.m_btnCancel.Text = this.resourceManager_0.GetString("ID_FIELDNAVIGATOR_CANCEL");
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
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.m_lblInput = new System.Windows.Forms.Label();
			this.m_txtInput = new System.Windows.Forms.TextBox();
			this.m_btnOK = new System.Windows.Forms.Button();
			this.m_btnCancel = new System.Windows.Forms.Button();
			this.tableLayoutPanel1.SuspendLayout();
			base.SuspendLayout();
			this.tableLayoutPanel1.AutoSize = true;
			this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.tableLayoutPanel1.ColumnCount = 2;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100f));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel1.Controls.Add(this.m_lblInput, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.m_txtInput, 1, 1);
			this.tableLayoutPanel1.Controls.Add(this.m_btnOK, 1, 2);
			this.tableLayoutPanel1.Controls.Add(this.m_btnCancel, 2, 2);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(7, 7);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 1;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 7f));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.Size = new System.Drawing.Size(317, 78);
			this.tableLayoutPanel1.TabIndex = 0;
			this.m_lblInput.AutoSize = true;
			this.tableLayoutPanel1.SetColumnSpan(this.m_lblInput, 2);
			this.m_lblInput.Location = new System.Drawing.Point(3, 0);
			this.m_lblInput.Name = "m_lblInput";
			this.m_lblInput.Size = new System.Drawing.Size(164, 13);
			this.m_lblInput.TabIndex = 0;
			this.m_lblInput.Text = "Insert requested information here:";
			this.m_txtInput.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.tableLayoutPanel1.SetColumnSpan(this.m_txtInput, 2);
			this.m_txtInput.Location = new System.Drawing.Point(3, 23);
			this.m_txtInput.Name = "m_txtInput";
			this.m_txtInput.Size = new System.Drawing.Size(311, 20);
			this.m_txtInput.TabIndex = 2;
			this.m_btnOK.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
			this.m_btnOK.AutoSize = true;
			this.m_btnOK.Location = new System.Drawing.Point(158, 52);
			this.m_btnOK.Name = "m_btnOK";
			this.m_btnOK.Size = new System.Drawing.Size(75, 23);
			this.m_btnOK.TabIndex = 3;
			this.m_btnOK.Text = "&OK";
			this.m_btnOK.UseVisualStyleBackColor = true;
			this.m_btnOK.Click += new System.EventHandler(m_btnOK_Click);
			this.m_btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
			this.m_btnCancel.AutoSize = true;
			this.m_btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.m_btnCancel.Location = new System.Drawing.Point(239, 52);
			this.m_btnCancel.Name = "m_btnCancel";
			this.m_btnCancel.Size = new System.Drawing.Size(75, 23);
			this.m_btnCancel.TabIndex = 4;
			this.m_btnCancel.Text = "&Cancel";
			this.m_btnCancel.UseVisualStyleBackColor = true;
			base.AcceptButton = this.m_btnOK;
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSize = true;
			base.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			base.CancelButton = this.m_btnCancel;
			base.ClientSize = new System.Drawing.Size(331, 92);
			base.Controls.Add(this.tableLayoutPanel1);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "UserPromptDialog";
			base.Padding = new System.Windows.Forms.Padding(7);
			base.ShowInTaskbar = false;
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "UserPromptDialog";
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			base.ResumeLayout(false);
			base.PerformLayout();
		}
	}
}
