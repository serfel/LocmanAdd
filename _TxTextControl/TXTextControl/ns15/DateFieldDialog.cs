using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using ns12;
using DocumentServer.Fields;
using DocumentServer.Properties;
using DocumentServer.Windows.Forms;

namespace ns15
{
	internal class DateFieldDialog : HighDpiForm
	{
		private Dialog0 dialog0_0;

		private Class135 class135_0;

		private IContainer icontainer_0;

		private Label lblFormats;

		private TextBox tbFormat;

		private ListBox lbFormats;

		private Button btnCancel;

		private Button btnOK;

		private CheckBox cbPreserveFormatting;

		private TableLayoutPanel tlpMainPanel;

		public DateFieldDialog(DateField dateField_0)
		{
			this.InitializeComponent();
			this.dialog0_0 = new Dialog0(dateField_0);
			this.class135_0 = new Class135(this.dialog0_0);
			this.lbFormats.DataSource = this.dialog0_0.List_0;
			this.lbFormats.DisplayMember = "Value";
			this.lbFormats.ValueMember = "Key";
			this.Text = Resources.DATEFIELD_DIALOG_TITLE;
			this.lblFormats.Text = Resources.DATEFIELD_LABEL_DATE_FORMATS;
			this.cbPreserveFormatting.Text = Resources.DATEFIELD_CHECK_BOX_PRESERVE_FORMAT;
			this.btnOK.Text = Resources.DATEFIELD_BUTTON_OK;
			this.btnCancel.Text = Resources.DATEFIELD_BUTTON_CANCEL;
			this.method_2();
		}

		private void DateFieldDialog_Load(object sender, EventArgs e)
		{
			this.method_3();
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

		private void method_2()
		{
			this.cbPreserveFormatting.Checked = this.class135_0.PreserveFormatting;
			this.tbFormat.Text = this.class135_0.String_0;
		}

		private void method_3()
		{
			this.lbFormats.SelectedIndex = -1;
			foreach (object item in this.lbFormats.Items)
			{
				if (((KeyValuePair<string, string>)item).Key == this.tbFormat.Text)
				{
					this.lbFormats.SelectedItem = item;
					break;
				}
			}
		}

		private void method_4()
		{
			if (this.class135_0.PreserveFormatting != this.cbPreserveFormatting.Checked)
			{
				this.dialog0_0.PreserveFormatting = this.cbPreserveFormatting.Checked;
			}
			if (this.class135_0.String_0 != this.tbFormat.Text)
			{
				this.dialog0_0.String_0 = this.tbFormat.Text;
			}
		}

		private void lbFormats_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (this.lbFormats.SelectedValue != null)
			{
				this.tbFormat.Text = this.lbFormats.SelectedValue.ToString();
			}
		}

		private void btnOK_Click(object sender, EventArgs e)
		{
			this.method_4();
			base.Close();
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
			this.lblFormats = new System.Windows.Forms.Label();
			this.tbFormat = new System.Windows.Forms.TextBox();
			this.lbFormats = new System.Windows.Forms.ListBox();
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnOK = new System.Windows.Forms.Button();
			this.cbPreserveFormatting = new System.Windows.Forms.CheckBox();
			this.tlpMainPanel = new System.Windows.Forms.TableLayoutPanel();
			this.tlpMainPanel.SuspendLayout();
			base.SuspendLayout();
			this.lblFormats.AutoSize = true;
			this.lblFormats.Location = new System.Drawing.Point(12, 9);
			this.lblFormats.Name = "lblFormats";
			this.lblFormats.Size = new System.Drawing.Size(0, 13);
			this.lblFormats.TabIndex = 0;
			this.tlpMainPanel.SetColumnSpan(this.tbFormat, 3);
			this.tbFormat.Dock = System.Windows.Forms.DockStyle.Top;
			this.tbFormat.Location = new System.Drawing.Point(3, 3);
			this.tbFormat.Name = "tbFormat";
			this.tbFormat.Size = new System.Drawing.Size(192, 20);
			this.tbFormat.TabIndex = 1;
			this.tlpMainPanel.SetColumnSpan(this.lbFormats, 3);
			this.lbFormats.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lbFormats.FormattingEnabled = true;
			this.lbFormats.IntegralHeight = false;
			this.lbFormats.Location = new System.Drawing.Point(3, 29);
			this.lbFormats.MinimumSize = new System.Drawing.Size(252, 160);
			this.lbFormats.Name = "lbFormats";
			this.lbFormats.Size = new System.Drawing.Size(252, 160);
			this.lbFormats.TabIndex = 2;
			this.lbFormats.SelectedIndexChanged += new System.EventHandler(lbFormats_SelectedIndexChanged);
			this.btnCancel.AutoSize = true;
			this.btnCancel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Dock = System.Windows.Forms.DockStyle.Right;
			this.btnCancel.Location = new System.Drawing.Point(123, 74);
			this.btnCancel.MinimumSize = new System.Drawing.Size(72, 23);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(72, 23);
			this.btnCancel.TabIndex = 5;
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnOK.AutoSize = true;
			this.btnOK.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnOK.Dock = System.Windows.Forms.DockStyle.Right;
			this.btnOK.Location = new System.Drawing.Point(45, 74);
			this.btnOK.MinimumSize = new System.Drawing.Size(72, 23);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(72, 23);
			this.btnOK.TabIndex = 4;
			this.btnOK.UseVisualStyleBackColor = true;
			this.btnOK.Click += new System.EventHandler(btnOK_Click);
			this.cbPreserveFormatting.AutoSize = true;
			this.tlpMainPanel.SetColumnSpan(this.cbPreserveFormatting, 3);
			this.cbPreserveFormatting.Dock = System.Windows.Forms.DockStyle.Top;
			this.cbPreserveFormatting.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.cbPreserveFormatting.Location = new System.Drawing.Point(3, 54);
			this.cbPreserveFormatting.Name = "cbPreserveFormatting";
			this.cbPreserveFormatting.Size = new System.Drawing.Size(192, 14);
			this.cbPreserveFormatting.TabIndex = 3;
			this.cbPreserveFormatting.UseVisualStyleBackColor = true;
			this.tlpMainPanel.AutoSize = true;
			this.tlpMainPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.tlpMainPanel.ColumnCount = 3;
			this.tlpMainPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100f));
			this.tlpMainPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tlpMainPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tlpMainPanel.Controls.Add(this.tbFormat, 0, 0);
			this.tlpMainPanel.Controls.Add(this.btnCancel, 2, 3);
			this.tlpMainPanel.Controls.Add(this.btnOK, 1, 3);
			this.tlpMainPanel.Controls.Add(this.cbPreserveFormatting, 0, 2);
			this.tlpMainPanel.Controls.Add(this.lbFormats, 0, 1);
			this.tlpMainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tlpMainPanel.Location = new System.Drawing.Point(7, 7);
			this.tlpMainPanel.Margin = new System.Windows.Forms.Padding(0);
			this.tlpMainPanel.Name = "tlpMainPanel";
			this.tlpMainPanel.RowCount = 4;
			this.tlpMainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tlpMainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100f));
			this.tlpMainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tlpMainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tlpMainPanel.Size = new System.Drawing.Size(198, 100);
			this.tlpMainPanel.TabIndex = 0;
			base.AcceptButton = this.btnOK;
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.CancelButton = this.btnCancel;
			base.ClientSize = new System.Drawing.Size(212, 114);
			base.Controls.Add(this.tlpMainPanel);
			base.Controls.Add(this.lblFormats);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "DateFieldDialog";
			base.Padding = new System.Windows.Forms.Padding(7);
			this.RightToLeftLayout = true;
			base.ShowIcon = false;
			base.ShowInTaskbar = false;
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			base.Load += new System.EventHandler(DateFieldDialog_Load);
			this.tlpMainPanel.ResumeLayout(false);
			this.tlpMainPanel.PerformLayout();
			base.ResumeLayout(false);
			base.PerformLayout();
		}
	}
}
