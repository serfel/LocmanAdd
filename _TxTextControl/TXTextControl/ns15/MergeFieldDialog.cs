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
	internal class MergeFieldDialog : HighDpiForm
	{
		private Dialog3 dialog3_0;

		private Class138 class138_0;

		private IContainer icontainer_0;

		private GroupBox grpProperties;

		private GroupBox grpOptions;

		private ListBox lbTextFormat;

		private Label lblFormat;

		private TextBox tbName;

		private Label lblName;

		private TextBox tbTextAfter;

		private TextBox tbTextBefore;

		private CheckBox cbTextBefore;

		private CheckBox cbPreserveFormatting;

		private Button btnCancel;

		private Button btnOK;

		private TextBox tbNumFmt;

		private CheckBox cbNumFmt;

		private TextBox tbDateTimeFmt;

		private CheckBox cbDateTimeFmt;

		private TableLayoutPanel tableLayoutPanel3;

		private TableLayoutPanel tableLayoutPanel4;

		private CheckBox cbTextAfter;

		private TableLayoutPanel tableLayoutPanel1;

		private TableLayoutPanel tableLayoutPanel2;

		public MergeFieldDialog(MergeField mergeField_0)
		{
			this.InitializeComponent();
			this.dialog3_0 = new Dialog3(mergeField_0);
			this.class138_0 = new Class138(this.dialog3_0);
			this.Text = Resources.MERGEFIELD_DIALOG_TITLE;
			this.grpProperties.Text = Resources.MERGEFIELD_GROUP_FIELD_PROPERTIES;
			this.lblName.Text = Resources.MERGEFIELD_LABEL_NAME;
			this.lblFormat.Text = Resources.MERGEFIELD_LABEL_FORMAT;
			this.lbTextFormat.Items.AddRange(new object[5]
			{
				Resources.MERGEFIELD_FORMAT_NONE,
				Resources.MERGEFIELD_FORMAT_UPPER,
				Resources.MERGEFIELD_FORMAT_LOWER,
				Resources.MERGEFIELD_FORMAT_FIRST_CAP,
				Resources.MERGEFIELD_FORMAT_TITLE_CASE
			});
			this.grpOptions.Text = Resources.MERGEFIELD_GROUP_FIELD_OPTIONS;
			this.cbTextBefore.Text = Resources.MERGEFIELD_LABEL_TEXT_BEFORE;
			this.cbTextAfter.Text = Resources.MERGEFIELD_LABEL_TEXT_AFTER;
			this.cbDateTimeFmt.Text = Resources.MERGEFIELD_LABEL_DATE_TIME_FORMAT;
			this.cbNumFmt.Text = Resources.MERGEFIELD_LABEL_NUMERIC_FORMAT;
			this.cbPreserveFormatting.Text = Resources.MERGEFIELD_CHECK_BOX_PRESERVE_FORMAT;
			this.btnOK.Text = Resources.MERGEFIELD_BUTTON_OK;
			this.btnCancel.Text = Resources.MERGEFIELD_BUTTON_CANCEL;
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
			this.tbName.Text = this.class138_0.String_1;
			if (this.class138_0.String_2.Length != 0)
			{
				this.cbTextBefore.Checked = true;
				this.tbTextBefore.Text = this.class138_0.String_2;
			}
			if (this.class138_0.String_3.Length != 0)
			{
				this.cbTextAfter.Checked = true;
				this.tbTextAfter.Text = this.class138_0.String_3;
			}
			if (this.class138_0.String_4.Length != 0)
			{
				this.cbDateTimeFmt.Checked = true;
				this.tbDateTimeFmt.Text = this.class138_0.String_4;
			}
			if (this.class138_0.String_5.Length != 0)
			{
				this.cbNumFmt.Checked = true;
				this.tbNumFmt.Text = this.class138_0.String_5;
			}
			this.cbPreserveFormatting.Checked = this.class138_0.PreserveFormatting;
			this.lbTextFormat.SelectedIndex = this.class138_0.Int32_0;
		}

		private void method_3()
		{
			bool flag = false;
			if (this.cbTextBefore.Checked)
			{
				if (this.class138_0.String_2 != this.tbTextBefore.Text)
				{
					this.dialog3_0.String_2 = this.tbTextBefore.Text;
					flag = true;
				}
			}
			else if (!string.IsNullOrEmpty(this.class138_0.String_2))
			{
				this.dialog3_0.String_2 = string.Empty;
				flag = true;
			}
			if (this.cbTextAfter.Checked)
			{
				if (this.class138_0.String_3 != this.tbTextAfter.Text)
				{
					this.dialog3_0.String_3 = this.tbTextAfter.Text;
					flag = true;
				}
			}
			else if (!string.IsNullOrEmpty(this.class138_0.String_3))
			{
				this.dialog3_0.String_3 = string.Empty;
				flag = true;
			}
			if (this.cbDateTimeFmt.Checked)
			{
				if (this.class138_0.String_4 != this.tbDateTimeFmt.Text)
				{
					this.dialog3_0.String_4 = this.tbDateTimeFmt.Text;
					flag = true;
				}
			}
			else if (!string.IsNullOrEmpty(this.class138_0.String_4))
			{
				this.dialog3_0.String_4 = string.Empty;
				flag = true;
			}
			if (this.cbNumFmt.Checked)
			{
				if (this.class138_0.String_5 != this.tbNumFmt.Text)
				{
					this.dialog3_0.String_5 = this.tbNumFmt.Text;
					flag = true;
				}
			}
			else if (!string.IsNullOrEmpty(this.class138_0.String_5))
			{
				this.dialog3_0.String_5 = string.Empty;
				flag = true;
			}
			if (this.class138_0.PreserveFormatting != this.cbPreserveFormatting.Checked)
			{
				this.dialog3_0.PreserveFormatting = this.cbPreserveFormatting.Checked;
				flag = true;
			}
			if (this.class138_0.Int32_0 != this.lbTextFormat.SelectedIndex)
			{
				this.dialog3_0.Int32_0 = this.lbTextFormat.SelectedIndex;
				flag = true;
			}
			if (flag)
			{
				this.dialog3_0.String_0 = this.class138_0.String_0;
			}
			if (this.class138_0.String_1 != this.tbName.Text)
			{
				this.dialog3_0.String_1 = this.tbName.Text;
			}
		}

		private void btnOK_Click(object sender, EventArgs e)
		{
			this.method_3();
			base.Close();
		}

		private void cbTextBefore_CheckedChanged(object sender, EventArgs e)
		{
			this.tbTextBefore.Enabled = this.cbTextBefore.Checked;
			if (this.tbTextBefore.Enabled)
			{
				this.tbTextBefore.Focus();
			}
		}

		private void cbTextAfter_CheckedChanged(object sender, EventArgs e)
		{
			this.tbTextAfter.Enabled = this.cbTextAfter.Checked;
			if (this.tbTextAfter.Enabled)
			{
				this.tbTextAfter.Focus();
			}
		}

		private void cbDateTimeFmt_CheckedChanged(object sender, EventArgs e)
		{
			this.tbDateTimeFmt.Enabled = this.cbDateTimeFmt.Checked;
			if (this.tbDateTimeFmt.Enabled)
			{
				this.tbDateTimeFmt.Focus();
			}
		}

		private void cbNumFmt_CheckedChanged(object sender, EventArgs e)
		{
			this.tbNumFmt.Enabled = this.cbNumFmt.Checked;
			if (this.tbNumFmt.Enabled)
			{
				this.tbNumFmt.Focus();
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
			this.grpProperties = new System.Windows.Forms.GroupBox();
			this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
			this.lblFormat = new System.Windows.Forms.Label();
			this.lbTextFormat = new System.Windows.Forms.ListBox();
			this.lblName = new System.Windows.Forms.Label();
			this.tbName = new System.Windows.Forms.TextBox();
			this.grpOptions = new System.Windows.Forms.GroupBox();
			this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
			this.cbPreserveFormatting = new System.Windows.Forms.CheckBox();
			this.tbNumFmt = new System.Windows.Forms.TextBox();
			this.cbTextBefore = new System.Windows.Forms.CheckBox();
			this.cbNumFmt = new System.Windows.Forms.CheckBox();
			this.tbTextBefore = new System.Windows.Forms.TextBox();
			this.tbDateTimeFmt = new System.Windows.Forms.TextBox();
			this.cbTextAfter = new System.Windows.Forms.CheckBox();
			this.cbDateTimeFmt = new System.Windows.Forms.CheckBox();
			this.tbTextAfter = new System.Windows.Forms.TextBox();
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnOK = new System.Windows.Forms.Button();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
			this.grpProperties.SuspendLayout();
			this.tableLayoutPanel3.SuspendLayout();
			this.grpOptions.SuspendLayout();
			this.tableLayoutPanel4.SuspendLayout();
			this.tableLayoutPanel1.SuspendLayout();
			this.tableLayoutPanel2.SuspendLayout();
			base.SuspendLayout();
			this.grpProperties.AutoSize = true;
			this.grpProperties.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.grpProperties.Controls.Add(this.tableLayoutPanel3);
			this.grpProperties.Dock = System.Windows.Forms.DockStyle.Fill;
			this.grpProperties.Location = new System.Drawing.Point(0, 0);
			this.grpProperties.Margin = new System.Windows.Forms.Padding(0, 0, 3, 3);
			this.grpProperties.Name = "grpProperties";
			this.grpProperties.Size = new System.Drawing.Size(115, 135);
			this.grpProperties.TabIndex = 0;
			this.grpProperties.TabStop = false;
			this.grpProperties.Text = "grpProperties";
			this.tableLayoutPanel3.AutoSize = true;
			this.tableLayoutPanel3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.tableLayoutPanel3.ColumnCount = 1;
			this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100f));
			this.tableLayoutPanel3.Controls.Add(this.lblFormat, 0, 2);
			this.tableLayoutPanel3.Controls.Add(this.lbTextFormat, 0, 3);
			this.tableLayoutPanel3.Controls.Add(this.lblName, 0, 0);
			this.tableLayoutPanel3.Controls.Add(this.tbName, 0, 1);
			this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 16);
			this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(0);
			this.tableLayoutPanel3.Name = "tableLayoutPanel3";
			this.tableLayoutPanel3.RowCount = 4;
			this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100f));
			this.tableLayoutPanel3.Size = new System.Drawing.Size(109, 116);
			this.tableLayoutPanel3.TabIndex = 5;
			this.lblFormat.AutoSize = true;
			this.lblFormat.Dock = System.Windows.Forms.DockStyle.Top;
			this.lblFormat.Location = new System.Drawing.Point(3, 39);
			this.lblFormat.Name = "lblFormat";
			this.lblFormat.Size = new System.Drawing.Size(103, 13);
			this.lblFormat.TabIndex = 4;
			this.lblFormat.Text = "lblFormat";
			this.lbTextFormat.Dock = System.Windows.Forms.DockStyle.Left;
			this.lbTextFormat.FormattingEnabled = true;
			this.lbTextFormat.IntegralHeight = false;
			this.lbTextFormat.Location = new System.Drawing.Point(3, 55);
			this.lbTextFormat.MinimumSize = new System.Drawing.Size(173, 111);
			this.lbTextFormat.Name = "lbTextFormat";
			this.lbTextFormat.Size = new System.Drawing.Size(173, 111);
			this.lbTextFormat.TabIndex = 5;
			this.lblName.AutoSize = true;
			this.lblName.Dock = System.Windows.Forms.DockStyle.Top;
			this.lblName.Location = new System.Drawing.Point(3, 0);
			this.lblName.Name = "lblName";
			this.lblName.Size = new System.Drawing.Size(103, 13);
			this.lblName.TabIndex = 0;
			this.lblName.Text = "lblName";
			this.tbName.Dock = System.Windows.Forms.DockStyle.Left;
			this.tbName.Location = new System.Drawing.Point(3, 16);
			this.tbName.MinimumSize = new System.Drawing.Size(173, 20);
			this.tbName.Name = "tbName";
			this.tbName.Size = new System.Drawing.Size(173, 20);
			this.tbName.TabIndex = 1;
			this.grpOptions.AutoSize = true;
			this.grpOptions.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.grpOptions.Controls.Add(this.tableLayoutPanel4);
			this.grpOptions.Dock = System.Windows.Forms.DockStyle.Fill;
			this.grpOptions.Location = new System.Drawing.Point(121, 0);
			this.grpOptions.Margin = new System.Windows.Forms.Padding(3, 0, 0, 3);
			this.grpOptions.Name = "grpOptions";
			this.grpOptions.Size = new System.Drawing.Size(115, 135);
			this.grpOptions.TabIndex = 1;
			this.grpOptions.TabStop = false;
			this.grpOptions.Text = "grpOptions";
			this.tableLayoutPanel4.AutoSize = true;
			this.tableLayoutPanel4.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.tableLayoutPanel4.ColumnCount = 1;
			this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100f));
			this.tableLayoutPanel4.Controls.Add(this.cbPreserveFormatting, 0, 8);
			this.tableLayoutPanel4.Controls.Add(this.tbNumFmt, 0, 7);
			this.tableLayoutPanel4.Controls.Add(this.cbTextBefore, 0, 0);
			this.tableLayoutPanel4.Controls.Add(this.cbNumFmt, 0, 6);
			this.tableLayoutPanel4.Controls.Add(this.tbTextBefore, 0, 1);
			this.tableLayoutPanel4.Controls.Add(this.tbDateTimeFmt, 0, 5);
			this.tableLayoutPanel4.Controls.Add(this.cbTextAfter, 0, 2);
			this.tableLayoutPanel4.Controls.Add(this.cbDateTimeFmt, 0, 4);
			this.tableLayoutPanel4.Controls.Add(this.tbTextAfter, 0, 3);
			this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 16);
			this.tableLayoutPanel4.Margin = new System.Windows.Forms.Padding(0);
			this.tableLayoutPanel4.Name = "tableLayoutPanel4";
			this.tableLayoutPanel4.RowCount = 9;
			this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel4.Size = new System.Drawing.Size(109, 116);
			this.tableLayoutPanel4.TabIndex = 5;
			this.cbPreserveFormatting.AutoSize = true;
			this.cbPreserveFormatting.Dock = System.Windows.Forms.DockStyle.Top;
			this.cbPreserveFormatting.Location = new System.Drawing.Point(3, 199);
			this.cbPreserveFormatting.Margin = new System.Windows.Forms.Padding(3, 3, 3, 7);
			this.cbPreserveFormatting.Name = "cbPreserveFormatting";
			this.cbPreserveFormatting.Size = new System.Drawing.Size(103, 17);
			this.cbPreserveFormatting.TabIndex = 8;
			this.cbPreserveFormatting.Text = "cbPreserveFormatting";
			this.cbPreserveFormatting.UseVisualStyleBackColor = true;
			this.tbNumFmt.Dock = System.Windows.Forms.DockStyle.Left;
			this.tbNumFmt.Enabled = false;
			this.tbNumFmt.Location = new System.Drawing.Point(3, 173);
			this.tbNumFmt.MinimumSize = new System.Drawing.Size(175, 20);
			this.tbNumFmt.Name = "tbNumFmt";
			this.tbNumFmt.Size = new System.Drawing.Size(175, 20);
			this.tbNumFmt.TabIndex = 7;
			this.cbTextBefore.AutoSize = true;
			this.cbTextBefore.CheckAlign = System.Drawing.ContentAlignment.TopLeft;
			this.cbTextBefore.Dock = System.Windows.Forms.DockStyle.Top;
			this.cbTextBefore.Location = new System.Drawing.Point(3, 3);
			this.cbTextBefore.Name = "cbTextBefore";
			this.cbTextBefore.Size = new System.Drawing.Size(103, 17);
			this.cbTextBefore.TabIndex = 0;
			this.cbTextBefore.Text = "cbTextBefore";
			this.cbTextBefore.UseVisualStyleBackColor = true;
			this.cbTextBefore.CheckedChanged += new System.EventHandler(cbTextBefore_CheckedChanged);
			this.cbNumFmt.AutoSize = true;
			this.cbNumFmt.CheckAlign = System.Drawing.ContentAlignment.TopLeft;
			this.cbNumFmt.Dock = System.Windows.Forms.DockStyle.Top;
			this.cbNumFmt.Location = new System.Drawing.Point(3, 150);
			this.cbNumFmt.Name = "cbNumFmt";
			this.cbNumFmt.Size = new System.Drawing.Size(103, 17);
			this.cbNumFmt.TabIndex = 6;
			this.cbNumFmt.Text = "cbNumFmt";
			this.cbNumFmt.UseVisualStyleBackColor = true;
			this.cbNumFmt.CheckedChanged += new System.EventHandler(cbNumFmt_CheckedChanged);
			this.tbTextBefore.Dock = System.Windows.Forms.DockStyle.Left;
			this.tbTextBefore.Enabled = false;
			this.tbTextBefore.Location = new System.Drawing.Point(3, 26);
			this.tbTextBefore.MinimumSize = new System.Drawing.Size(175, 20);
			this.tbTextBefore.Name = "tbTextBefore";
			this.tbTextBefore.Size = new System.Drawing.Size(175, 20);
			this.tbTextBefore.TabIndex = 1;
			this.tbDateTimeFmt.Dock = System.Windows.Forms.DockStyle.Left;
			this.tbDateTimeFmt.Enabled = false;
			this.tbDateTimeFmt.Location = new System.Drawing.Point(3, 124);
			this.tbDateTimeFmt.MinimumSize = new System.Drawing.Size(175, 20);
			this.tbDateTimeFmt.Name = "tbDateTimeFmt";
			this.tbDateTimeFmt.Size = new System.Drawing.Size(175, 20);
			this.tbDateTimeFmt.TabIndex = 5;
			this.cbTextAfter.AutoSize = true;
			this.cbTextAfter.CheckAlign = System.Drawing.ContentAlignment.TopLeft;
			this.cbTextAfter.Dock = System.Windows.Forms.DockStyle.Top;
			this.cbTextAfter.Location = new System.Drawing.Point(3, 52);
			this.cbTextAfter.Name = "cbTextAfter";
			this.cbTextAfter.Size = new System.Drawing.Size(103, 17);
			this.cbTextAfter.TabIndex = 2;
			this.cbTextAfter.Text = "cbTextAfter";
			this.cbTextAfter.UseVisualStyleBackColor = true;
			this.cbTextAfter.CheckedChanged += new System.EventHandler(cbTextAfter_CheckedChanged);
			this.cbDateTimeFmt.AutoSize = true;
			this.cbDateTimeFmt.CheckAlign = System.Drawing.ContentAlignment.TopLeft;
			this.cbDateTimeFmt.Dock = System.Windows.Forms.DockStyle.Top;
			this.cbDateTimeFmt.Location = new System.Drawing.Point(3, 101);
			this.cbDateTimeFmt.Name = "cbDateTimeFmt";
			this.cbDateTimeFmt.Size = new System.Drawing.Size(103, 17);
			this.cbDateTimeFmt.TabIndex = 4;
			this.cbDateTimeFmt.Text = "cbDateTimeFmt";
			this.cbDateTimeFmt.UseVisualStyleBackColor = true;
			this.cbDateTimeFmt.CheckedChanged += new System.EventHandler(cbDateTimeFmt_CheckedChanged);
			this.tbTextAfter.Dock = System.Windows.Forms.DockStyle.Left;
			this.tbTextAfter.Enabled = false;
			this.tbTextAfter.Location = new System.Drawing.Point(3, 75);
			this.tbTextAfter.MinimumSize = new System.Drawing.Size(175, 20);
			this.tbTextAfter.Name = "tbTextAfter";
			this.tbTextAfter.Size = new System.Drawing.Size(175, 20);
			this.tbTextAfter.TabIndex = 3;
			this.btnCancel.AutoSize = true;
			this.btnCancel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Dock = System.Windows.Forms.DockStyle.Top;
			this.btnCancel.Location = new System.Drawing.Point(164, 141);
			this.btnCancel.Margin = new System.Windows.Forms.Padding(3, 3, 0, 0);
			this.btnCancel.MinimumSize = new System.Drawing.Size(72, 23);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(72, 23);
			this.btnCancel.TabIndex = 3;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnOK.AutoSize = true;
			this.btnOK.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnOK.Dock = System.Windows.Forms.DockStyle.Top;
			this.btnOK.Location = new System.Drawing.Point(86, 141);
			this.btnOK.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
			this.btnOK.MinimumSize = new System.Drawing.Size(72, 23);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(72, 23);
			this.btnOK.TabIndex = 2;
			this.btnOK.Text = "OK";
			this.btnOK.UseVisualStyleBackColor = true;
			this.btnOK.Click += new System.EventHandler(btnOK_Click);
			this.tableLayoutPanel1.ColumnCount = 3;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100f));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel1.Controls.Add(this.btnOK, 1, 1);
			this.tableLayoutPanel1.Controls.Add(this.btnCancel, 2, 1);
			this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(7, 7);
			this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 2;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100f));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.Size = new System.Drawing.Size(236, 164);
			this.tableLayoutPanel1.TabIndex = 4;
			this.tableLayoutPanel2.AutoSize = true;
			this.tableLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.tableLayoutPanel2.ColumnCount = 2;
			this.tableLayoutPanel1.SetColumnSpan(this.tableLayoutPanel2, 3);
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50f));
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50f));
			this.tableLayoutPanel2.Controls.Add(this.grpProperties, 0, 0);
			this.tableLayoutPanel2.Controls.Add(this.grpOptions, 1, 0);
			this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
			this.tableLayoutPanel2.Name = "tableLayoutPanel2";
			this.tableLayoutPanel2.RowCount = 1;
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50f));
			this.tableLayoutPanel2.Size = new System.Drawing.Size(236, 138);
			this.tableLayoutPanel2.TabIndex = 4;
			base.AcceptButton = this.btnOK;
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.CancelButton = this.btnCancel;
			base.ClientSize = new System.Drawing.Size(250, 178);
			base.Controls.Add(this.tableLayoutPanel1);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "MergeFieldDialog";
			base.Padding = new System.Windows.Forms.Padding(7);
			this.RightToLeftLayout = true;
			base.ShowInTaskbar = false;
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.grpProperties.ResumeLayout(false);
			this.grpProperties.PerformLayout();
			this.tableLayoutPanel3.ResumeLayout(false);
			this.tableLayoutPanel3.PerformLayout();
			this.grpOptions.ResumeLayout(false);
			this.grpOptions.PerformLayout();
			this.tableLayoutPanel4.ResumeLayout(false);
			this.tableLayoutPanel4.PerformLayout();
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			this.tableLayoutPanel2.ResumeLayout(false);
			this.tableLayoutPanel2.PerformLayout();
			base.ResumeLayout(false);
		}
	}
}
