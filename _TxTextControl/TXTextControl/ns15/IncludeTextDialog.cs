using System;
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
	internal class IncludeTextDialog : HighDpiForm
	{
		private Dialog2 dialog2_0;

		private Class137 class137_0;

		private IContainer icontainer_0;

		private Label lblFormat;

		private Label lblFileName;

		private TextBox tbFileName;

		private ListBox lbTextFormat;

		private Label lblBookmark;

		private TextBox tbBookmark;

		private CheckBox cbPreserveFormatting;

		private GroupBox grpOptions;

		private TableLayoutPanel tableLayoutPanel1;

		private TableLayoutPanel tableLayoutPanel2;

		private Button btnOK;

		private Button btnCancel;

		public IncludeTextDialog(IncludeText includeText_0)
		{
			this.InitializeComponent();
			this.dialog2_0 = new Dialog2(includeText_0);
			this.class137_0 = new Class137(this.dialog2_0);
			this.Text = Resources.INCLUDETEXT_DIALOG_TITLE;
			this.lblFileName.Text = Resources.INCLUDETEXT_LABEL_FILENAME;
			this.lblBookmark.Text = Resources.INCLUDETEXT_LABEL_BOOKMARK;
			this.grpOptions.Text = Resources.INCLUDETEXT_GROUP_FIELD_OPTIONS;
			this.lblFormat.Text = Resources.INCLUDETEXT_LABEL_TEXT_FORMAT;
			this.lbTextFormat.Items.AddRange(new object[5]
			{
				Resources.INCLUDETEXT_LIST_FORMAT_NONE,
				Resources.INCLUDETEXT_LIST_FORMAT_UPPER,
				Resources.INCLUDETEXT_LIST_FORMAT_LOWER,
				Resources.INCLUDETEXT_LIST_FORMAT_FIRST_CAP,
				Resources.INCLUDETEXT_LIST_FORMAT_TITLE_CASE
			});
			this.cbPreserveFormatting.Text = Resources.INCLUDETEXT_CHECK_BOX_PRESERVE_FORMAT;
			this.btnOK.Text = Resources.INCLUDETEXT_BUTTON_OK;
			this.btnCancel.Text = Resources.INCLUDETEXT_BUTTON_CANCEL;
			this.method_2();
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
			this.tbFileName.Text = this.class137_0.String_1;
			this.tbBookmark.Text = this.class137_0.String_0;
			this.cbPreserveFormatting.Checked = this.class137_0.PreserveFormatting;
			this.lbTextFormat.SelectedIndex = this.class137_0.Int32_0;
		}

		private void method_3()
		{
			if (this.class137_0.String_1 != this.tbFileName.Text)
			{
				this.dialog2_0.String_0 = this.tbFileName.Text;
			}
			if (this.class137_0.String_0 != this.tbBookmark.Text)
			{
				this.dialog2_0.String_1 = this.tbBookmark.Text;
			}
			if (this.class137_0.PreserveFormatting != this.cbPreserveFormatting.Checked)
			{
				this.dialog2_0.PreserveFormatting = this.cbPreserveFormatting.Checked;
			}
			if (this.class137_0.Int32_0 != this.lbTextFormat.SelectedIndex)
			{
				this.dialog2_0.Int32_0 = this.lbTextFormat.SelectedIndex;
			}
		}

		private void btnOK_Click(object sender, EventArgs e)
		{
			this.method_3();
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
			this.lblFormat = new System.Windows.Forms.Label();
			this.lblFileName = new System.Windows.Forms.Label();
			this.tbFileName = new System.Windows.Forms.TextBox();
			this.lbTextFormat = new System.Windows.Forms.ListBox();
			this.lblBookmark = new System.Windows.Forms.Label();
			this.tbBookmark = new System.Windows.Forms.TextBox();
			this.cbPreserveFormatting = new System.Windows.Forms.CheckBox();
			this.grpOptions = new System.Windows.Forms.GroupBox();
			this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.btnOK = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.grpOptions.SuspendLayout();
			this.tableLayoutPanel2.SuspendLayout();
			this.tableLayoutPanel1.SuspendLayout();
			base.SuspendLayout();
			this.lblFormat.AutoSize = true;
			this.lblFormat.Dock = System.Windows.Forms.DockStyle.Top;
			this.lblFormat.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.lblFormat.Location = new System.Drawing.Point(3, 0);
			this.lblFormat.Name = "lblFormat";
			this.lblFormat.Size = new System.Drawing.Size(207, 13);
			this.lblFormat.TabIndex = 0;
			this.lblFormat.Text = "x";
			this.lblFileName.AutoSize = true;
			this.tableLayoutPanel1.SetColumnSpan(this.lblFileName, 3);
			this.lblFileName.Dock = System.Windows.Forms.DockStyle.Top;
			this.lblFileName.Location = new System.Drawing.Point(3, 0);
			this.lblFileName.Name = "lblFileName";
			this.lblFileName.Size = new System.Drawing.Size(213, 13);
			this.lblFileName.TabIndex = 0;
			this.lblFileName.Text = "x";
			this.tableLayoutPanel1.SetColumnSpan(this.tbFileName, 3);
			this.tbFileName.Location = new System.Drawing.Point(3, 16);
			this.tbFileName.MinimumSize = new System.Drawing.Size(270, 20);
			this.tbFileName.Name = "tbFileName";
			this.tbFileName.Size = new System.Drawing.Size(270, 20);
			this.tbFileName.TabIndex = 1;
			this.lbTextFormat.FormattingEnabled = true;
			this.lbTextFormat.IntegralHeight = false;
			this.lbTextFormat.Location = new System.Drawing.Point(3, 16);
			this.lbTextFormat.MinimumSize = new System.Drawing.Size(238, 95);
			this.lbTextFormat.Name = "lbTextFormat";
			this.lbTextFormat.Size = new System.Drawing.Size(238, 95);
			this.lbTextFormat.TabIndex = 1;
			this.lblBookmark.AutoSize = true;
			this.tableLayoutPanel1.SetColumnSpan(this.lblBookmark, 3);
			this.lblBookmark.Dock = System.Windows.Forms.DockStyle.Top;
			this.lblBookmark.Location = new System.Drawing.Point(3, 39);
			this.lblBookmark.Name = "lblBookmark";
			this.lblBookmark.Size = new System.Drawing.Size(213, 13);
			this.lblBookmark.TabIndex = 2;
			this.lblBookmark.Text = "x";
			this.tableLayoutPanel1.SetColumnSpan(this.tbBookmark, 3);
			this.tbBookmark.Location = new System.Drawing.Point(3, 55);
			this.tbBookmark.MinimumSize = new System.Drawing.Size(270, 20);
			this.tbBookmark.Name = "tbBookmark";
			this.tbBookmark.Size = new System.Drawing.Size(270, 20);
			this.tbBookmark.TabIndex = 3;
			this.cbPreserveFormatting.AutoSize = true;
			this.cbPreserveFormatting.Dock = System.Windows.Forms.DockStyle.Top;
			this.cbPreserveFormatting.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.cbPreserveFormatting.Location = new System.Drawing.Point(3, 117);
			this.cbPreserveFormatting.Name = "cbPreserveFormatting";
			this.cbPreserveFormatting.Size = new System.Drawing.Size(207, 14);
			this.cbPreserveFormatting.TabIndex = 2;
			this.cbPreserveFormatting.UseVisualStyleBackColor = true;
			this.grpOptions.AutoSize = true;
			this.grpOptions.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.tableLayoutPanel1.SetColumnSpan(this.grpOptions, 3);
			this.grpOptions.Controls.Add(this.tableLayoutPanel2);
			this.grpOptions.Dock = System.Windows.Forms.DockStyle.Fill;
			this.grpOptions.Location = new System.Drawing.Point(0, 78);
			this.grpOptions.Margin = new System.Windows.Forms.Padding(0);
			this.grpOptions.Name = "grpOptions";
			this.grpOptions.Size = new System.Drawing.Size(219, 153);
			this.grpOptions.TabIndex = 4;
			this.grpOptions.TabStop = false;
			this.tableLayoutPanel2.AutoSize = true;
			this.tableLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.tableLayoutPanel2.ColumnCount = 1;
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100f));
			this.tableLayoutPanel2.Controls.Add(this.lblFormat, 0, 0);
			this.tableLayoutPanel2.Controls.Add(this.lbTextFormat, 0, 1);
			this.tableLayoutPanel2.Controls.Add(this.cbPreserveFormatting, 0, 2);
			this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 16);
			this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
			this.tableLayoutPanel2.Name = "tableLayoutPanel2";
			this.tableLayoutPanel2.RowCount = 3;
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel2.Size = new System.Drawing.Size(213, 134);
			this.tableLayoutPanel2.TabIndex = 8;
			this.tableLayoutPanel1.ColumnCount = 3;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100f));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel1.Controls.Add(this.btnOK, 1, 5);
			this.tableLayoutPanel1.Controls.Add(this.grpOptions, 0, 4);
			this.tableLayoutPanel1.Controls.Add(this.btnCancel, 2, 5);
			this.tableLayoutPanel1.Controls.Add(this.lblBookmark, 0, 2);
			this.tableLayoutPanel1.Controls.Add(this.lblFileName, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.tbFileName, 0, 1);
			this.tableLayoutPanel1.Controls.Add(this.tbBookmark, 0, 3);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(7, 7);
			this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 6;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.Size = new System.Drawing.Size(219, 219);
			this.tableLayoutPanel1.TabIndex = 7;
			this.btnOK.AutoSize = true;
			this.btnOK.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnOK.Dock = System.Windows.Forms.DockStyle.Top;
			this.btnOK.Location = new System.Drawing.Point(69, 234);
			this.btnOK.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
			this.btnOK.MinimumSize = new System.Drawing.Size(72, 23);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(72, 23);
			this.btnOK.TabIndex = 5;
			this.btnOK.UseVisualStyleBackColor = true;
			this.btnOK.Click += new System.EventHandler(btnOK_Click);
			this.btnCancel.AutoSize = true;
			this.btnCancel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Dock = System.Windows.Forms.DockStyle.Top;
			this.btnCancel.Location = new System.Drawing.Point(147, 234);
			this.btnCancel.Margin = new System.Windows.Forms.Padding(3, 3, 0, 0);
			this.btnCancel.MinimumSize = new System.Drawing.Size(72, 23);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(72, 23);
			this.btnCancel.TabIndex = 6;
			this.btnCancel.UseVisualStyleBackColor = true;
			base.AcceptButton = this.btnOK;
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.CancelButton = this.btnCancel;
			base.ClientSize = new System.Drawing.Size(233, 233);
			base.Controls.Add(this.tableLayoutPanel1);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "IncludeTextDialog";
			base.Padding = new System.Windows.Forms.Padding(7);
			this.RightToLeftLayout = true;
			base.ShowIcon = false;
			base.ShowInTaskbar = false;
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.grpOptions.ResumeLayout(false);
			this.grpOptions.PerformLayout();
			this.tableLayoutPanel2.ResumeLayout(false);
			this.tableLayoutPanel2.PerformLayout();
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			base.ResumeLayout(false);
		}
	}
}
