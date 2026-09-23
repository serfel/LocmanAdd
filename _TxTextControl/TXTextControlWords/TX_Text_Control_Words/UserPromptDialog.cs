using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using TX_Text_Control_Words.Properties;

namespace TX_Text_Control_Words
{
	public class UserPromptDialog : Form
	{
		private IContainer components;

		private TableLayoutPanel tableLayoutPanel1;

		private Button m_btnOK;

		private Button m_btnCancel;

		private Label m_lblInput;

		private TextBox m_txtInput;

		public string Value => this.m_txtInput.Text;

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

		public UserPromptDialog(string caption, string label, string value)
		{
			this.InitializeComponent();
			this.LocalizeDialog();
			this.Text = caption;
			this.m_lblInput.Text = label ?? "";
			this.m_txtInput.Text = value ?? "";
		}

		private void LocalizeDialog()
		{
			this.m_btnOK.Text = Resources.BTN_OK;
			this.m_btnCancel.Text = Resources.BTN_CANCEL;
		}

		private void BtnOK_Click(object sender, EventArgs e)
		{
			base.DialogResult = DialogResult.OK;
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
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.m_lblInput = new System.Windows.Forms.Label();
			this.m_txtInput = new System.Windows.Forms.TextBox();
			this.m_btnOK = new System.Windows.Forms.Button();
			this.m_btnCancel = new System.Windows.Forms.Button();
			this.tableLayoutPanel1.SuspendLayout();
			base.SuspendLayout();
			this.tableLayoutPanel1.AutoSize = true;
			this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.tableLayoutPanel1.ColumnCount = 3;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100f));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel1.Controls.Add(this.m_lblInput, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.m_txtInput, 0, 1);
			this.tableLayoutPanel1.Controls.Add(this.m_btnOK, 1, 3);
			this.tableLayoutPanel1.Controls.Add(this.m_btnCancel, 2, 3);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(7, 7);
			this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 1;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100f));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20f));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(317, 72);
			this.tableLayoutPanel1.TabIndex = 0;
			this.m_lblInput.AutoSize = true;
			this.tableLayoutPanel1.SetColumnSpan(this.m_lblInput, 3);
			this.m_lblInput.Location = new System.Drawing.Point(0, 0);
			this.m_lblInput.Margin = new System.Windows.Forms.Padding(0, 0, 3, 3);
			this.m_lblInput.Name = "m_lblInput";
			this.m_lblInput.Size = new System.Drawing.Size(164, 13);
			this.m_lblInput.TabIndex = 0;
			this.m_lblInput.Text = "&Insert requested information here:";
			this.m_txtInput.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.tableLayoutPanel1.SetColumnSpan(this.m_txtInput, 3);
			this.m_txtInput.Location = new System.Drawing.Point(0, 19);
			this.m_txtInput.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
			this.m_txtInput.Name = "m_txtInput";
			this.m_txtInput.Size = new System.Drawing.Size(317, 20);
			this.m_txtInput.TabIndex = 2;
			this.m_btnOK.AutoSize = true;
			this.m_btnOK.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.m_btnOK.Dock = System.Windows.Forms.DockStyle.Top;
			this.m_btnOK.Location = new System.Drawing.Point(161, 49);
			this.m_btnOK.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
			this.m_btnOK.MinimumSize = new System.Drawing.Size(75, 23);
			this.m_btnOK.Name = "m_btnOK";
			this.m_btnOK.Size = new System.Drawing.Size(75, 23);
			this.m_btnOK.TabIndex = 3;
			this.m_btnOK.Text = "OK";
			this.m_btnOK.UseVisualStyleBackColor = true;
			this.m_btnOK.Click += new System.EventHandler(BtnOK_Click);
			this.m_btnCancel.AutoSize = true;
			this.m_btnCancel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.m_btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.m_btnCancel.Dock = System.Windows.Forms.DockStyle.Top;
			this.m_btnCancel.Location = new System.Drawing.Point(242, 49);
			this.m_btnCancel.Margin = new System.Windows.Forms.Padding(3, 3, 0, 0);
			this.m_btnCancel.MinimumSize = new System.Drawing.Size(75, 23);
			this.m_btnCancel.Name = "m_btnCancel";
			this.m_btnCancel.Size = new System.Drawing.Size(75, 23);
			this.m_btnCancel.TabIndex = 4;
			this.m_btnCancel.Text = "Cancel";
			this.m_btnCancel.UseVisualStyleBackColor = true;
			base.AcceptButton = this.m_btnOK;
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
			this.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			base.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			base.CancelButton = this.m_btnCancel;
			base.ClientSize = new System.Drawing.Size(331, 86);
			base.Controls.Add(this.tableLayoutPanel1);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "UserPromptDialog";
			base.Padding = new System.Windows.Forms.Padding(7);
			this.RightToLeftLayout = true;
			base.ShowIcon = false;
			base.ShowInTaskbar = false;
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "UserPromptDialog";
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			base.ResumeLayout(false);
			base.PerformLayout();
		}
	}
}
