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
	internal class FormTextDialog : HighDpiForm
	{
		private Class140 class140_0;

		private IContainer icontainer_0;

		private ComboBox cbType;

		private Label lblType;

		private ComboBox cbFormat;

		private Label lblTextFmt;

		private NumericUpDown nudLength;

		private Label lblMaxLen;

		private TextBox tbDefault;

		private Label lblDefText;

		private CheckBox cbCalculate;

		private CheckBox cbFillIn;

		private TextBox tbName;

		private Label lblName;

		private Button btnCancel;

		private Button btnOK;

		private Button btnAddHelpText;

		private GroupBox grpFormField;

		private GroupBox grpSettings;

		private TableLayoutPanel tableLayoutPanel3;

		private TableLayoutPanel tableLayoutPanel1;

		private TableLayoutPanel tableLayoutPanel2;

		public FormTextDialog(FormText formText_0)
		{
			this.InitializeComponent();
			this.class140_0 = new Class140(formText_0);
			this.Text = Resources.FORMTEXT_DIALOG_TITLE;
			this.grpFormField.Text = Resources.FORMTEXT_GROUP_TEXT_FORM_FIELD;
			this.lblType.Text = Resources.FORMTEXT_LABEL_TYPE;
			this.cbType.Items.AddRange(new object[6]
			{
				Resources.FORMTEXT_COMBO_BOX_TYPE_REGULAR,
				Resources.FORMTEXT_COMBO_BOX_TYPE_NUMBER,
				Resources.FORMTEXT_COMBO_BOX_TYPE_DATE,
				Resources.FORMTEXT_COMBO_BOX_TYPE_CUR_DATE,
				Resources.FORMTEXT_COMBO_BOX_TYPE_TIME,
				Resources.FORMTEXT_COMBO_BOX_TYPE_CALCULATION
			});
			this.lblDefText.Text = Resources.FORMTEXT_LABEL_DEFAULT_TEXT;
			this.lblMaxLen.Text = Resources.FORMTEXT_LABEL_MAX_LENGTH;
			this.lblTextFmt.Text = Resources.FORMTEXT_LABEL_TEXT_FORMAT;
			this.cbFormat.Items.AddRange(new object[5]
			{
				Resources.FORMTEXT_COMBO_BOX_TEXT_FORMAT_NONE,
				Resources.FORMTEXT_COMBO_BOX_TEXT_FORMAT_UPPER,
				Resources.FORMTEXT_COMBO_BOX_TEXT_FORMAT_LOWER,
				Resources.FORMTEXT_COMBO_BOX_TEXT_FORMAT_FIRST_CAP,
				Resources.FORMTEXT_COMBO_BOX_TEXT_FORMAT_TITLE_CASE
			});
			this.grpSettings.Text = Resources.FORMTEXT_GROUP_FIELD_SETTINGS;
			this.lblName.Text = Resources.FORMTEXT_LABEL_NAME;
			this.cbFillIn.Text = Resources.FORMTEXT_CHECK_BOX_FILL_IN;
			this.cbCalculate.Text = Resources.FORMTEXT_CHECK_BOX_CALC_ON_EXIT;
			this.btnAddHelpText.Text = Resources.FORMTEXT_BUTTON_ADD_HELP_TEXT;
			this.btnOK.Text = Resources.FORMTEXT_BUTTON_OK;
			this.btnCancel.Text = Resources.FORMTEXT_BUTTON_CANCEL;
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
			this.tbName.Text = this.class140_0.String_2;
			this.tbDefault.Text = this.class140_0.String_3;
			this.cbType.SelectedIndex = this.class140_0.Int32_0;
			this.cbFormat.SelectedIndex = this.class140_0.Int32_1;
			this.nudLength.Value = this.class140_0.Int32_2;
			this.cbCalculate.Checked = this.class140_0.Boolean_0;
			this.cbFillIn.Checked = this.class140_0.Boolean_1;
		}

		private void method_3()
		{
			this.class140_0.String_2 = this.tbName.Text;
			this.class140_0.String_3 = this.tbDefault.Text;
			this.class140_0.Int32_0 = this.cbType.SelectedIndex;
			this.class140_0.Int32_1 = this.cbFormat.SelectedIndex;
			this.class140_0.Int32_2 = (int)this.nudLength.Value;
			this.class140_0.Boolean_0 = this.cbCalculate.Checked;
			this.class140_0.Boolean_1 = this.cbFillIn.Checked;
		}

		private void btnOK_Click(object sender, EventArgs e)
		{
			this.method_3();
			base.Close();
		}

		private void btnAddHelpText_Click(object sender, EventArgs e)
		{
			FormFieldHelptextDialog formFieldHelptextDialog = new FormFieldHelptextDialog();
			formFieldHelptextDialog.String_0 = this.class140_0.String_0;
			formFieldHelptextDialog.String_1 = this.class140_0.String_1;
			formFieldHelptextDialog.ShowDialog();
			this.class140_0.String_0 = formFieldHelptextDialog.String_0;
			this.class140_0.String_1 = formFieldHelptextDialog.String_1;
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
			this.cbFormat = new System.Windows.Forms.ComboBox();
			this.lblTextFmt = new System.Windows.Forms.Label();
			this.nudLength = new System.Windows.Forms.NumericUpDown();
			this.lblMaxLen = new System.Windows.Forms.Label();
			this.tbDefault = new System.Windows.Forms.TextBox();
			this.lblDefText = new System.Windows.Forms.Label();
			this.cbType = new System.Windows.Forms.ComboBox();
			this.lblType = new System.Windows.Forms.Label();
			this.btnAddHelpText = new System.Windows.Forms.Button();
			this.cbCalculate = new System.Windows.Forms.CheckBox();
			this.cbFillIn = new System.Windows.Forms.CheckBox();
			this.tbName = new System.Windows.Forms.TextBox();
			this.lblName = new System.Windows.Forms.Label();
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnOK = new System.Windows.Forms.Button();
			this.grpFormField = new System.Windows.Forms.GroupBox();
			this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
			this.grpSettings = new System.Windows.Forms.GroupBox();
			this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			((System.ComponentModel.ISupportInitialize)this.nudLength).BeginInit();
			this.grpFormField.SuspendLayout();
			this.tableLayoutPanel2.SuspendLayout();
			this.grpSettings.SuspendLayout();
			this.tableLayoutPanel3.SuspendLayout();
			this.tableLayoutPanel1.SuspendLayout();
			base.SuspendLayout();
			this.cbFormat.DisplayMember = "1";
			this.cbFormat.Dock = System.Windows.Forms.DockStyle.Top;
			this.cbFormat.FormattingEnabled = true;
			this.cbFormat.Location = new System.Drawing.Point(147, 56);
			this.cbFormat.Name = "cbFormat";
			this.cbFormat.Size = new System.Drawing.Size(156, 21);
			this.cbFormat.TabIndex = 7;
			this.lblTextFmt.AutoSize = true;
			this.lblTextFmt.Dock = System.Windows.Forms.DockStyle.Top;
			this.lblTextFmt.Location = new System.Drawing.Point(147, 40);
			this.lblTextFmt.Name = "lblTextFmt";
			this.lblTextFmt.Size = new System.Drawing.Size(156, 13);
			this.lblTextFmt.TabIndex = 6;
			this.lblTextFmt.Text = "x";
			this.nudLength.Dock = System.Windows.Forms.DockStyle.Top;
			this.nudLength.Location = new System.Drawing.Point(3, 56);
			this.nudLength.Maximum = new decimal(new int[4] { 50000, 0, 0, 0 });
			this.nudLength.Name = "nudLength";
			this.nudLength.Size = new System.Drawing.Size(138, 20);
			this.nudLength.TabIndex = 5;
			this.lblMaxLen.AutoSize = true;
			this.lblMaxLen.Dock = System.Windows.Forms.DockStyle.Top;
			this.lblMaxLen.Location = new System.Drawing.Point(3, 40);
			this.lblMaxLen.Name = "lblMaxLen";
			this.lblMaxLen.Size = new System.Drawing.Size(138, 13);
			this.lblMaxLen.TabIndex = 4;
			this.lblMaxLen.Text = "x";
			this.tbDefault.Dock = System.Windows.Forms.DockStyle.Top;
			this.tbDefault.Location = new System.Drawing.Point(147, 16);
			this.tbDefault.Name = "tbDefault";
			this.tbDefault.Size = new System.Drawing.Size(156, 20);
			this.tbDefault.TabIndex = 3;
			this.lblDefText.AutoSize = true;
			this.lblDefText.Dock = System.Windows.Forms.DockStyle.Top;
			this.lblDefText.Location = new System.Drawing.Point(147, 0);
			this.lblDefText.Name = "lblDefText";
			this.lblDefText.Size = new System.Drawing.Size(156, 13);
			this.lblDefText.TabIndex = 2;
			this.lblDefText.Text = "x";
			this.cbType.DisplayMember = "1";
			this.cbType.Dock = System.Windows.Forms.DockStyle.Top;
			this.cbType.FormattingEnabled = true;
			this.cbType.Location = new System.Drawing.Point(3, 16);
			this.cbType.Name = "cbType";
			this.cbType.Size = new System.Drawing.Size(138, 21);
			this.cbType.TabIndex = 1;
			this.lblType.AutoSize = true;
			this.lblType.Dock = System.Windows.Forms.DockStyle.Top;
			this.lblType.Location = new System.Drawing.Point(3, 0);
			this.lblType.Name = "lblType";
			this.lblType.Size = new System.Drawing.Size(138, 13);
			this.lblType.TabIndex = 0;
			this.lblType.Text = "x";
			this.btnAddHelpText.AutoSize = true;
			this.btnAddHelpText.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.btnAddHelpText.Dock = System.Windows.Forms.DockStyle.Top;
			this.btnAddHelpText.Location = new System.Drawing.Point(3, 82);
			this.btnAddHelpText.MinimumSize = new System.Drawing.Size(202, 20);
			this.btnAddHelpText.Name = "btnAddHelpText";
			this.btnAddHelpText.Size = new System.Drawing.Size(202, 20);
			this.btnAddHelpText.TabIndex = 4;
			this.btnAddHelpText.UseVisualStyleBackColor = true;
			this.btnAddHelpText.Click += new System.EventHandler(btnAddHelpText_Click);
			this.cbCalculate.AutoSize = true;
			this.tableLayoutPanel3.SetColumnSpan(this.cbCalculate, 2);
			this.cbCalculate.Dock = System.Windows.Forms.DockStyle.Top;
			this.cbCalculate.Location = new System.Drawing.Point(3, 62);
			this.cbCalculate.Name = "cbCalculate";
			this.cbCalculate.Size = new System.Drawing.Size(250, 14);
			this.cbCalculate.TabIndex = 3;
			this.cbCalculate.UseVisualStyleBackColor = true;
			this.cbFillIn.AutoSize = true;
			this.tableLayoutPanel3.SetColumnSpan(this.cbFillIn, 2);
			this.cbFillIn.Dock = System.Windows.Forms.DockStyle.Top;
			this.cbFillIn.Location = new System.Drawing.Point(3, 42);
			this.cbFillIn.Name = "cbFillIn";
			this.cbFillIn.Size = new System.Drawing.Size(250, 14);
			this.cbFillIn.TabIndex = 2;
			this.cbFillIn.UseVisualStyleBackColor = true;
			this.tbName.Dock = System.Windows.Forms.DockStyle.Top;
			this.tbName.Location = new System.Drawing.Point(3, 16);
			this.tbName.MinimumSize = new System.Drawing.Size(202, 20);
			this.tbName.Name = "tbName";
			this.tbName.Size = new System.Drawing.Size(202, 20);
			this.tbName.TabIndex = 1;
			this.lblName.AutoSize = true;
			this.tableLayoutPanel3.SetColumnSpan(this.lblName, 2);
			this.lblName.Dock = System.Windows.Forms.DockStyle.Top;
			this.lblName.Location = new System.Drawing.Point(3, 0);
			this.lblName.Name = "lblName";
			this.lblName.Size = new System.Drawing.Size(250, 13);
			this.lblName.TabIndex = 0;
			this.lblName.Text = "x";
			this.btnCancel.AutoSize = true;
			this.btnCancel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Dock = System.Windows.Forms.DockStyle.Top;
			this.btnCancel.Location = new System.Drawing.Point(196, 248);
			this.btnCancel.Margin = new System.Windows.Forms.Padding(3, 3, 0, 0);
			this.btnCancel.MinimumSize = new System.Drawing.Size(72, 23);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(72, 23);
			this.btnCancel.TabIndex = 3;
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnOK.AutoSize = true;
			this.btnOK.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnOK.Dock = System.Windows.Forms.DockStyle.Top;
			this.btnOK.Location = new System.Drawing.Point(118, 248);
			this.btnOK.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
			this.btnOK.MinimumSize = new System.Drawing.Size(72, 23);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(72, 23);
			this.btnOK.TabIndex = 2;
			this.btnOK.UseVisualStyleBackColor = true;
			this.btnOK.Click += new System.EventHandler(btnOK_Click);
			this.tableLayoutPanel1.SetColumnSpan(this.grpFormField, 3);
			this.grpFormField.Controls.Add(this.tableLayoutPanel2);
			this.grpFormField.Dock = System.Windows.Forms.DockStyle.Fill;
			this.grpFormField.Location = new System.Drawing.Point(3, 3);
			this.grpFormField.Name = "grpFormField";
			this.grpFormField.Size = new System.Drawing.Size(262, 109);
			this.grpFormField.TabIndex = 0;
			this.grpFormField.TabStop = false;
			this.tableLayoutPanel2.AutoSize = true;
			this.tableLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.tableLayoutPanel2.ColumnCount = 3;
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100f));
			this.tableLayoutPanel2.Controls.Add(this.cbFormat, 1, 3);
			this.tableLayoutPanel2.Controls.Add(this.nudLength, 0, 3);
			this.tableLayoutPanel2.Controls.Add(this.lblMaxLen, 0, 2);
			this.tableLayoutPanel2.Controls.Add(this.tbDefault, 1, 1);
			this.tableLayoutPanel2.Controls.Add(this.lblTextFmt, 1, 2);
			this.tableLayoutPanel2.Controls.Add(this.cbType, 0, 1);
			this.tableLayoutPanel2.Controls.Add(this.lblType, 0, 0);
			this.tableLayoutPanel2.Controls.Add(this.lblDefText, 1, 0);
			this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 16);
			this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
			this.tableLayoutPanel2.Name = "tableLayoutPanel2";
			this.tableLayoutPanel2.RowCount = 4;
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel2.Size = new System.Drawing.Size(256, 90);
			this.tableLayoutPanel2.TabIndex = 5;
			this.grpSettings.AutoSize = true;
			this.grpSettings.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.tableLayoutPanel1.SetColumnSpan(this.grpSettings, 3);
			this.grpSettings.Controls.Add(this.tableLayoutPanel3);
			this.grpSettings.Dock = System.Windows.Forms.DockStyle.Fill;
			this.grpSettings.Location = new System.Drawing.Point(3, 118);
			this.grpSettings.Name = "grpSettings";
			this.grpSettings.Size = new System.Drawing.Size(262, 124);
			this.grpSettings.TabIndex = 1;
			this.grpSettings.TabStop = false;
			this.tableLayoutPanel3.AutoSize = true;
			this.tableLayoutPanel3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.tableLayoutPanel3.ColumnCount = 2;
			this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100f));
			this.tableLayoutPanel3.Controls.Add(this.btnAddHelpText, 0, 4);
			this.tableLayoutPanel3.Controls.Add(this.cbFillIn, 0, 2);
			this.tableLayoutPanel3.Controls.Add(this.cbCalculate, 0, 3);
			this.tableLayoutPanel3.Controls.Add(this.tbName, 0, 1);
			this.tableLayoutPanel3.Controls.Add(this.lblName, 0, 0);
			this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 16);
			this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(0);
			this.tableLayoutPanel3.Name = "tableLayoutPanel3";
			this.tableLayoutPanel3.RowCount = 6;
			this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100f));
			this.tableLayoutPanel3.Size = new System.Drawing.Size(256, 105);
			this.tableLayoutPanel3.TabIndex = 5;
			this.tableLayoutPanel1.AutoSize = true;
			this.tableLayoutPanel1.ColumnCount = 3;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100f));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel1.Controls.Add(this.grpFormField, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.grpSettings, 0, 1);
			this.tableLayoutPanel1.Controls.Add(this.btnOK, 1, 2);
			this.tableLayoutPanel1.Controls.Add(this.btnCancel, 2, 2);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(7, 7);
			this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 3;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.Size = new System.Drawing.Size(268, 174);
			this.tableLayoutPanel1.TabIndex = 4;
			base.AcceptButton = this.btnOK;
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.CancelButton = this.btnCancel;
			base.ClientSize = new System.Drawing.Size(282, 188);
			base.Controls.Add(this.tableLayoutPanel1);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "FormTextDialog";
			base.Padding = new System.Windows.Forms.Padding(7);
			this.RightToLeftLayout = true;
			base.ShowIcon = false;
			base.ShowInTaskbar = false;
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			((System.ComponentModel.ISupportInitialize)this.nudLength).EndInit();
			this.grpFormField.ResumeLayout(false);
			this.grpFormField.PerformLayout();
			this.tableLayoutPanel2.ResumeLayout(false);
			this.tableLayoutPanel2.PerformLayout();
			this.grpSettings.ResumeLayout(false);
			this.grpSettings.PerformLayout();
			this.tableLayoutPanel3.ResumeLayout(false);
			this.tableLayoutPanel3.PerformLayout();
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			base.ResumeLayout(false);
			base.PerformLayout();
		}
	}
}
