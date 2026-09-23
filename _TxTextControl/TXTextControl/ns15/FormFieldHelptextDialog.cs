using System;
using System.ComponentModel;
using System.Drawing;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using DocumentServer.Fields;
using DocumentServer.Properties;
using DocumentServer.Windows.Forms;

namespace ns15
{
	internal class FormFieldHelptextDialog : HighDpiForm
	{
		[CompilerGenerated]
		private string string_0;

		[CompilerGenerated]
		private string string_1;

		private IContainer icontainer_0;

		private Button btnCancel;

		private Button btnOK;

		private TabControl tbcHelp;

		private TabPage tabPageStatusText;

		private TextBox tbStatus;

		private RadioButton rbStatusText;

		private RadioButton rbStatusNone;

		private TabPage tabPageHelpText;

		private TextBox tbHelp;

		private RadioButton rbHelpText;

		private RadioButton rbHelpNone;

		private TableLayoutPanel tableLayoutPanel1;

		private TableLayoutPanel tableLayoutPanel2;

		private TableLayoutPanel tableLayoutPanel3;

		public string String_0
		{
			[CompilerGenerated]
			get
			{
				return this.string_0;
			}
			[CompilerGenerated]
			set
			{
				this.string_0 = value;
			}
		}

		public string String_1
		{
			[CompilerGenerated]
			get
			{
				return this.string_1;
			}
			[CompilerGenerated]
			set
			{
				this.string_1 = value;
			}
		}

		public FormFieldHelptextDialog()
		{
			this.InitializeComponent();
			this.Text = Resources.HELPTEXT_DIALOG_TITLE;
			this.tabPageStatusText.Text = Resources.HELPTEXT_TABPAGE_STATUS_TEXT;
			this.rbStatusNone.Text = Resources.HELPTEXT_RADIO_BTN_STATUS_NONE;
			this.rbStatusText.Text = Resources.HELPTEXT_RADIO_BTN_STATUS_CUSTOM;
			this.tabPageHelpText.Text = Resources.HELPTEXT_TABPAGE_HELP_TEXT;
			this.rbHelpNone.Text = Resources.HELPTEXT_RADIO_BTN_HELP_NONE;
			this.rbHelpText.Text = Resources.HELPTEXT_RADIO_BTN_HELP_CUSTOM;
			this.btnOK.Text = Resources.HELPTEXT_BUTTON_OK;
			this.btnCancel.Text = Resources.HELPTEXT_BUTTON_CANCEL;
		}

		[Obfuscation(Exclude = true)]
		public DocumentServer.Fields.DialogResult ShowFieldDialog(IWin32Window owner)
		{
			return base.ShowDialog(owner) switch
			{
				System.Windows.Forms.DialogResult.Cancel => DocumentServer.Fields.DialogResult.Cancel, 
				System.Windows.Forms.DialogResult.OK => DocumentServer.Fields.DialogResult.OK, 
				_ => DocumentServer.Fields.DialogResult.None, 
			};
		}

		private void tbStatus_Enter(object sender, EventArgs e)
		{
			this.rbStatusText.Checked = true;
		}

		private void rbStatusText_Enter(object sender, EventArgs e)
		{
			this.tbStatus.Focus();
		}

		private void tbHelp_Enter(object sender, EventArgs e)
		{
			this.rbHelpText.Checked = true;
		}

		private void rbHelpText_Enter(object sender, EventArgs e)
		{
			this.tbHelp.Focus();
		}

		private void btnOK_Click(object sender, EventArgs e)
		{
			if (this.rbStatusNone.Checked)
			{
				this.String_0 = "";
			}
			else
			{
				this.String_0 = this.tbStatus.Text;
			}
			if (this.rbHelpNone.Checked)
			{
				this.String_1 = "";
			}
			else
			{
				this.String_1 = this.tbHelp.Text;
			}
		}

		private void FormFieldHelptextDialog_Load(object sender, EventArgs e)
		{
			if (this.String_0 != string.Empty)
			{
				this.tbStatus.Text = this.String_0;
				this.rbStatusText.Checked = true;
			}
			if (this.String_1 != string.Empty)
			{
				this.tbHelp.Text = this.String_1;
				this.rbHelpText.Checked = true;
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
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnOK = new System.Windows.Forms.Button();
			this.tbcHelp = new System.Windows.Forms.TabControl();
			this.tabPageStatusText = new System.Windows.Forms.TabPage();
			this.tbStatus = new System.Windows.Forms.TextBox();
			this.rbStatusText = new System.Windows.Forms.RadioButton();
			this.rbStatusNone = new System.Windows.Forms.RadioButton();
			this.tabPageHelpText = new System.Windows.Forms.TabPage();
			this.tbHelp = new System.Windows.Forms.TextBox();
			this.rbHelpText = new System.Windows.Forms.RadioButton();
			this.rbHelpNone = new System.Windows.Forms.RadioButton();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
			this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
			this.tbcHelp.SuspendLayout();
			this.tabPageStatusText.SuspendLayout();
			this.tabPageHelpText.SuspendLayout();
			this.tableLayoutPanel1.SuspendLayout();
			this.tableLayoutPanel2.SuspendLayout();
			this.tableLayoutPanel3.SuspendLayout();
			base.SuspendLayout();
			this.btnCancel.AutoSize = true;
			this.btnCancel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Dock = System.Windows.Forms.DockStyle.Top;
			this.btnCancel.Location = new System.Drawing.Point(115, 98);
			this.btnCancel.MinimumSize = new System.Drawing.Size(72, 23);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(72, 23);
			this.btnCancel.TabIndex = 3;
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnOK.AutoSize = true;
			this.btnOK.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnOK.Dock = System.Windows.Forms.DockStyle.Top;
			this.btnOK.Location = new System.Drawing.Point(37, 98);
			this.btnOK.MinimumSize = new System.Drawing.Size(72, 23);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(72, 23);
			this.btnOK.TabIndex = 2;
			this.btnOK.UseVisualStyleBackColor = true;
			this.btnOK.Click += new System.EventHandler(btnOK_Click);
			this.tableLayoutPanel1.SetColumnSpan(this.tbcHelp, 3);
			this.tbcHelp.Controls.Add(this.tabPageStatusText);
			this.tbcHelp.Controls.Add(this.tabPageHelpText);
			this.tbcHelp.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tbcHelp.Location = new System.Drawing.Point(3, 3);
			this.tbcHelp.Name = "tbcHelp";
			this.tbcHelp.SelectedIndex = 0;
			this.tbcHelp.Size = new System.Drawing.Size(184, 89);
			this.tbcHelp.TabIndex = 0;
			this.tabPageStatusText.Controls.Add(this.tableLayoutPanel2);
			this.tabPageStatusText.Location = new System.Drawing.Point(4, 22);
			this.tabPageStatusText.Name = "tabPageStatusText";
			this.tabPageStatusText.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageStatusText.Size = new System.Drawing.Size(176, 63);
			this.tabPageStatusText.TabIndex = 0;
			this.tabPageStatusText.UseVisualStyleBackColor = true;
			this.tbStatus.Location = new System.Drawing.Point(3, 41);
			this.tbStatus.MinimumSize = new System.Drawing.Size(302, 64);
			this.tbStatus.Multiline = true;
			this.tbStatus.Name = "tbStatus";
			this.tbStatus.Size = new System.Drawing.Size(302, 64);
			this.tbStatus.TabIndex = 2;
			this.tbStatus.Enter += new System.EventHandler(tbStatus_Enter);
			this.rbStatusText.AutoSize = true;
			this.rbStatusText.Dock = System.Windows.Forms.DockStyle.Top;
			this.rbStatusText.Location = new System.Drawing.Point(3, 22);
			this.rbStatusText.Name = "rbStatusText";
			this.rbStatusText.Size = new System.Drawing.Size(302, 13);
			this.rbStatusText.TabIndex = 1;
			this.rbStatusText.UseVisualStyleBackColor = true;
			this.rbStatusText.Enter += new System.EventHandler(rbStatusText_Enter);
			this.rbStatusNone.AutoSize = true;
			this.rbStatusNone.Checked = true;
			this.rbStatusNone.Dock = System.Windows.Forms.DockStyle.Top;
			this.rbStatusNone.Location = new System.Drawing.Point(3, 3);
			this.rbStatusNone.Name = "rbStatusNone";
			this.rbStatusNone.Size = new System.Drawing.Size(302, 13);
			this.rbStatusNone.TabIndex = 0;
			this.rbStatusNone.TabStop = true;
			this.rbStatusNone.UseVisualStyleBackColor = true;
			this.tabPageHelpText.Controls.Add(this.tableLayoutPanel3);
			this.tabPageHelpText.Location = new System.Drawing.Point(4, 22);
			this.tabPageHelpText.Name = "tabPageHelpText";
			this.tabPageHelpText.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageHelpText.Size = new System.Drawing.Size(176, 63);
			this.tabPageHelpText.TabIndex = 1;
			this.tabPageHelpText.UseVisualStyleBackColor = true;
			this.tbHelp.Location = new System.Drawing.Point(3, 41);
			this.tbHelp.MinimumSize = new System.Drawing.Size(302, 64);
			this.tbHelp.Multiline = true;
			this.tbHelp.Name = "tbHelp";
			this.tbHelp.Size = new System.Drawing.Size(302, 64);
			this.tbHelp.TabIndex = 2;
			this.tbHelp.Enter += new System.EventHandler(tbHelp_Enter);
			this.rbHelpText.AutoSize = true;
			this.rbHelpText.Dock = System.Windows.Forms.DockStyle.Top;
			this.rbHelpText.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.rbHelpText.Location = new System.Drawing.Point(3, 22);
			this.rbHelpText.Name = "rbHelpText";
			this.rbHelpText.Size = new System.Drawing.Size(302, 13);
			this.rbHelpText.TabIndex = 1;
			this.rbHelpText.UseVisualStyleBackColor = true;
			this.rbHelpText.Enter += new System.EventHandler(rbHelpText_Enter);
			this.rbHelpNone.AutoSize = true;
			this.rbHelpNone.Checked = true;
			this.rbHelpNone.Dock = System.Windows.Forms.DockStyle.Top;
			this.rbHelpNone.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.rbHelpNone.Location = new System.Drawing.Point(3, 3);
			this.rbHelpNone.Name = "rbHelpNone";
			this.rbHelpNone.Size = new System.Drawing.Size(302, 13);
			this.rbHelpNone.TabIndex = 0;
			this.rbHelpNone.TabStop = true;
			this.rbHelpNone.UseVisualStyleBackColor = true;
			this.tableLayoutPanel1.ColumnCount = 3;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100f));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel1.Controls.Add(this.btnOK, 1, 1);
			this.tableLayoutPanel1.Controls.Add(this.tbcHelp, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.btnCancel, 2, 1);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(7, 7);
			this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 2;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100f));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.Size = new System.Drawing.Size(190, 124);
			this.tableLayoutPanel1.TabIndex = 4;
			this.tableLayoutPanel2.AutoSize = true;
			this.tableLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.tableLayoutPanel2.ColumnCount = 1;
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel2.Controls.Add(this.rbStatusNone, 0, 0);
			this.tableLayoutPanel2.Controls.Add(this.tbStatus, 0, 2);
			this.tableLayoutPanel2.Controls.Add(this.rbStatusText, 0, 1);
			this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
			this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
			this.tableLayoutPanel2.Name = "tableLayoutPanel2";
			this.tableLayoutPanel2.RowCount = 3;
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100f));
			this.tableLayoutPanel2.Size = new System.Drawing.Size(170, 57);
			this.tableLayoutPanel2.TabIndex = 3;
			this.tableLayoutPanel3.ColumnCount = 1;
			this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel3.Controls.Add(this.rbHelpNone, 0, 0);
			this.tableLayoutPanel3.Controls.Add(this.tbHelp, 0, 2);
			this.tableLayoutPanel3.Controls.Add(this.rbHelpText, 0, 1);
			this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 3);
			this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(0);
			this.tableLayoutPanel3.Name = "tableLayoutPanel3";
			this.tableLayoutPanel3.RowCount = 3;
			this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100f));
			this.tableLayoutPanel3.Size = new System.Drawing.Size(170, 57);
			this.tableLayoutPanel3.TabIndex = 3;
			base.AcceptButton = this.btnOK;
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.CancelButton = this.btnCancel;
			base.Controls.Add(this.tableLayoutPanel1);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "FormFieldHelptextDialog";
			base.Padding = new System.Windows.Forms.Padding(7);
			this.RightToLeftLayout = true;
			base.ShowInTaskbar = false;
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			base.Load += new System.EventHandler(FormFieldHelptextDialog_Load);
			this.tbcHelp.ResumeLayout(false);
			this.tabPageStatusText.ResumeLayout(false);
			this.tabPageStatusText.PerformLayout();
			this.tabPageHelpText.ResumeLayout(false);
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			this.tableLayoutPanel2.ResumeLayout(false);
			this.tableLayoutPanel2.PerformLayout();
			this.tableLayoutPanel3.ResumeLayout(false);
			this.tableLayoutPanel3.PerformLayout();
			base.ResumeLayout(false);
		}
	}
}
