using System;
using System.ComponentModel;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using DocumentServer.Fields;
using DocumentServer.Properties;
using DocumentServer.Windows.Forms;

namespace ns15
{
	internal class FormCheckboxDialog : HighDpiForm
	{
		private FormCheckBox formCheckBox_0;

		private string string_0;

		private string string_1;

		private IContainer icontainer_0;

		private GroupBox grpSize;

		private GroupBox grpSettings;

		private CheckBox cbCalculate;

		private CheckBox cbEnabled;

		private TextBox tbName;

		private Label lblName;

		private Button btnCancel;

		private Button btnOK;

		private Button btnAddHelpText;

		private RadioButton rbSizeAuto;

		private RadioButton rbSizeExactly;

		private NumericUpDown nudSize;

		private RadioButton rbNotChecked;

		private RadioButton rbChecked;

		private TableLayoutPanel tableLayoutPanel1;

		private TableLayoutPanel tableLayoutPanel2;

		private TableLayoutPanel tableLayoutPanel3;

		public FormCheckboxDialog(FormCheckBox formCheckBox_1)
		{
			this.InitializeComponent();
			this.formCheckBox_0 = formCheckBox_1;
			this.Text = Resources.FORMCHECKBOX_DIALOG_TITLE;
			this.grpSize.Text = Resources.FORMCHECKBOX_GROUP_SIZE;
			this.rbSizeAuto.Text = Resources.FORMCHECKBOX_RADIO_BTN_AUTO;
			this.rbSizeExactly.Text = Resources.FORMCHECKBOX_RADIO_BTN_EXACTLY;
			this.grpSettings.Text = Resources.FORMCHECKBOX_GROUP_SETTINGS;
			this.lblName.Text = Resources.FORMCHECKBOX_LABEL_NAME;
			this.rbChecked.Text = Resources.FORMCHECKBOX_RADIO_BTN_CHECKED;
			this.rbNotChecked.Text = Resources.FORMCHECKBOX_RADIO_BTN_NOT_CHECKED;
			this.cbEnabled.Text = Resources.FORMCHECKBOX_CHECK_BOX_ENABLED;
			this.cbCalculate.Text = Resources.FORMCHECKBOX_CHECK_BOX_CALC_ON_EXIT;
			this.btnAddHelpText.Text = Resources.FORMCHECKBOX_BUTTON_ADD_HELP_TEXT;
			this.btnOK.Text = Resources.FORMCHECKBOX_BUTTON_OK;
			this.btnCancel.Text = Resources.FORMCHECKBOX_BUTTON_CANCEL;
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
			this.tbName.Text = this.formCheckBox_0.Name;
			this.string_0 = this.formCheckBox_0.HelpText;
			this.string_1 = this.formCheckBox_0.StatusText;
			if (this.formCheckBox_0.SizeAuto)
			{
				this.rbSizeAuto.Checked = true;
				this.rbSizeExactly.Checked = false;
			}
			else
			{
				this.rbSizeAuto.Checked = false;
				this.rbSizeExactly.Checked = true;
			}
			this.nudSize.Value = this.formCheckBox_0.Size;
			this.cbEnabled.Checked = this.formCheckBox_0.Enabled;
			this.cbCalculate.Checked = this.formCheckBox_0.CalcOnExit;
			this.rbChecked.Checked = this.formCheckBox_0.Checked;
			this.rbNotChecked.Checked = !this.rbChecked.Checked;
		}

		private void method_3()
		{
			this.formCheckBox_0.Name = this.tbName.Text;
			this.formCheckBox_0.HelpText = this.string_0;
			this.formCheckBox_0.StatusText = this.string_1;
			this.formCheckBox_0.CalcOnExit = this.cbCalculate.Checked;
			this.formCheckBox_0.Enabled = this.cbEnabled.Checked;
			this.formCheckBox_0.Size = (int)this.nudSize.Value;
			this.formCheckBox_0.SizeAuto = this.rbSizeAuto.Checked;
			this.formCheckBox_0.Checked = this.rbChecked.Checked;
		}

		private void btnOK_Click(object sender, EventArgs e)
		{
			this.method_3();
			base.Close();
		}

		private void btnAddHelpText_Click(object sender, EventArgs e)
		{
			FormFieldHelptextDialog formFieldHelptextDialog = new FormFieldHelptextDialog();
			formFieldHelptextDialog.String_0 = this.string_0;
			formFieldHelptextDialog.String_1 = this.string_1;
			formFieldHelptextDialog.ShowDialog();
			this.string_0 = formFieldHelptextDialog.String_0;
			this.string_1 = formFieldHelptextDialog.String_1;
		}

		private void rbSizeExactly_CheckedChanged(object sender, EventArgs e)
		{
			if (this.rbSizeExactly.Checked)
			{
				this.nudSize.Focus();
			}
		}

		private void nudSize_Enter(object sender, EventArgs e)
		{
			this.rbSizeExactly.Checked = true;
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
			this.grpSize = new System.Windows.Forms.GroupBox();
			this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
			this.rbSizeAuto = new System.Windows.Forms.RadioButton();
			this.nudSize = new System.Windows.Forms.NumericUpDown();
			this.rbSizeExactly = new System.Windows.Forms.RadioButton();
			this.grpSettings = new System.Windows.Forms.GroupBox();
			this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
			this.lblName = new System.Windows.Forms.Label();
			this.rbNotChecked = new System.Windows.Forms.RadioButton();
			this.tbName = new System.Windows.Forms.TextBox();
			this.rbChecked = new System.Windows.Forms.RadioButton();
			this.cbEnabled = new System.Windows.Forms.CheckBox();
			this.cbCalculate = new System.Windows.Forms.CheckBox();
			this.btnAddHelpText = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnOK = new System.Windows.Forms.Button();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.grpSize.SuspendLayout();
			this.tableLayoutPanel3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)this.nudSize).BeginInit();
			this.grpSettings.SuspendLayout();
			this.tableLayoutPanel2.SuspendLayout();
			this.tableLayoutPanel1.SuspendLayout();
			base.SuspendLayout();
			this.grpSize.AutoSize = true;
			this.grpSize.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.tableLayoutPanel1.SetColumnSpan(this.grpSize, 3);
			this.grpSize.Controls.Add(this.tableLayoutPanel3);
			this.grpSize.Dock = System.Windows.Forms.DockStyle.Fill;
			this.grpSize.Location = new System.Drawing.Point(0, 0);
			this.grpSize.Margin = new System.Windows.Forms.Padding(0, 0, 0, 3);
			this.grpSize.Name = "grpSize";
			this.grpSize.Size = new System.Drawing.Size(225, 64);
			this.grpSize.TabIndex = 0;
			this.grpSize.TabStop = false;
			this.tableLayoutPanel3.AutoSize = true;
			this.tableLayoutPanel3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.tableLayoutPanel3.ColumnCount = 2;
			this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100f));
			this.tableLayoutPanel3.Controls.Add(this.rbSizeAuto, 0, 0);
			this.tableLayoutPanel3.Controls.Add(this.nudSize, 1, 1);
			this.tableLayoutPanel3.Controls.Add(this.rbSizeExactly, 0, 1);
			this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 16);
			this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(0);
			this.tableLayoutPanel3.Name = "tableLayoutPanel3";
			this.tableLayoutPanel3.RowCount = 3;
			this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100f));
			this.tableLayoutPanel3.Size = new System.Drawing.Size(219, 45);
			this.tableLayoutPanel3.TabIndex = 3;
			this.rbSizeAuto.AutoSize = true;
			this.rbSizeAuto.Dock = System.Windows.Forms.DockStyle.Top;
			this.rbSizeAuto.Location = new System.Drawing.Point(3, 3);
			this.rbSizeAuto.Name = "rbSizeAuto";
			this.rbSizeAuto.Size = new System.Drawing.Size(14, 13);
			this.rbSizeAuto.TabIndex = 0;
			this.rbSizeAuto.TabStop = true;
			this.rbSizeAuto.UseVisualStyleBackColor = true;
			this.nudSize.AutoSize = true;
			this.nudSize.Dock = System.Windows.Forms.DockStyle.Left;
			this.nudSize.Location = new System.Drawing.Point(23, 22);
			this.nudSize.Name = "nudSize";
			this.nudSize.Size = new System.Drawing.Size(41, 20);
			this.nudSize.TabIndex = 2;
			this.nudSize.Enter += new System.EventHandler(nudSize_Enter);
			this.rbSizeExactly.AutoSize = true;
			this.rbSizeExactly.Dock = System.Windows.Forms.DockStyle.Top;
			this.rbSizeExactly.Location = new System.Drawing.Point(3, 22);
			this.rbSizeExactly.Name = "rbSizeExactly";
			this.rbSizeExactly.Size = new System.Drawing.Size(14, 13);
			this.rbSizeExactly.TabIndex = 1;
			this.rbSizeExactly.TabStop = true;
			this.rbSizeExactly.UseVisualStyleBackColor = true;
			this.rbSizeExactly.CheckedChanged += new System.EventHandler(rbSizeExactly_CheckedChanged);
			this.grpSettings.AutoSize = true;
			this.grpSettings.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.tableLayoutPanel1.SetColumnSpan(this.grpSettings, 3);
			this.grpSettings.Controls.Add(this.tableLayoutPanel2);
			this.grpSettings.Dock = System.Windows.Forms.DockStyle.Fill;
			this.grpSettings.Location = new System.Drawing.Point(0, 67);
			this.grpSettings.Margin = new System.Windows.Forms.Padding(0, 0, 0, 3);
			this.grpSettings.Name = "grpSettings";
			this.grpSettings.Size = new System.Drawing.Size(225, 22);
			this.grpSettings.TabIndex = 1;
			this.grpSettings.TabStop = false;
			this.tableLayoutPanel2.AutoSize = true;
			this.tableLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.tableLayoutPanel2.ColumnCount = 2;
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100f));
			this.tableLayoutPanel2.Controls.Add(this.lblName, 0, 0);
			this.tableLayoutPanel2.Controls.Add(this.rbNotChecked, 1, 2);
			this.tableLayoutPanel2.Controls.Add(this.tbName, 0, 1);
			this.tableLayoutPanel2.Controls.Add(this.rbChecked, 1, 1);
			this.tableLayoutPanel2.Controls.Add(this.cbEnabled, 0, 2);
			this.tableLayoutPanel2.Controls.Add(this.cbCalculate, 0, 3);
			this.tableLayoutPanel2.Controls.Add(this.btnAddHelpText, 0, 4);
			this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 16);
			this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
			this.tableLayoutPanel2.Name = "tableLayoutPanel2";
			this.tableLayoutPanel2.RowCount = 6;
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100f));
			this.tableLayoutPanel2.Size = new System.Drawing.Size(219, 3);
			this.tableLayoutPanel2.TabIndex = 7;
			this.lblName.AutoSize = true;
			this.lblName.Dock = System.Windows.Forms.DockStyle.Top;
			this.lblName.Location = new System.Drawing.Point(3, 0);
			this.lblName.Name = "lblName";
			this.lblName.Size = new System.Drawing.Size(138, 13);
			this.lblName.TabIndex = 0;
			this.lblName.Text = "x";
			this.rbNotChecked.AutoSize = true;
			this.rbNotChecked.Location = new System.Drawing.Point(147, 42);
			this.rbNotChecked.Name = "rbNotChecked";
			this.rbNotChecked.Size = new System.Drawing.Size(14, 13);
			this.rbNotChecked.TabIndex = 3;
			this.rbNotChecked.TabStop = true;
			this.rbNotChecked.UseVisualStyleBackColor = true;
			this.tbName.Location = new System.Drawing.Point(3, 16);
			this.tbName.Name = "tbName";
			this.tbName.Size = new System.Drawing.Size(138, 20);
			this.tbName.TabIndex = 1;
			this.rbChecked.AutoSize = true;
			this.rbChecked.Location = new System.Drawing.Point(147, 16);
			this.rbChecked.Name = "rbChecked";
			this.rbChecked.Size = new System.Drawing.Size(14, 13);
			this.rbChecked.TabIndex = 2;
			this.rbChecked.TabStop = true;
			this.rbChecked.UseVisualStyleBackColor = true;
			this.cbEnabled.AutoSize = true;
			this.cbEnabled.Dock = System.Windows.Forms.DockStyle.Top;
			this.cbEnabled.Location = new System.Drawing.Point(3, 42);
			this.cbEnabled.Name = "cbEnabled";
			this.cbEnabled.Size = new System.Drawing.Size(138, 14);
			this.cbEnabled.TabIndex = 4;
			this.cbEnabled.UseVisualStyleBackColor = true;
			this.cbCalculate.AutoSize = true;
			this.cbCalculate.Dock = System.Windows.Forms.DockStyle.Top;
			this.cbCalculate.Location = new System.Drawing.Point(3, 62);
			this.cbCalculate.Name = "cbCalculate";
			this.cbCalculate.Size = new System.Drawing.Size(138, 14);
			this.cbCalculate.TabIndex = 5;
			this.cbCalculate.UseVisualStyleBackColor = true;
			this.btnAddHelpText.AutoSize = true;
			this.btnAddHelpText.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.btnAddHelpText.Location = new System.Drawing.Point(3, 82);
			this.btnAddHelpText.MinimumSize = new System.Drawing.Size(72, 23);
			this.btnAddHelpText.Name = "btnAddHelpText";
			this.btnAddHelpText.Size = new System.Drawing.Size(72, 23);
			this.btnAddHelpText.TabIndex = 6;
			this.btnAddHelpText.UseVisualStyleBackColor = true;
			this.btnAddHelpText.Click += new System.EventHandler(btnAddHelpText_Click);
			this.btnCancel.AutoSize = true;
			this.btnCancel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Dock = System.Windows.Forms.DockStyle.Top;
			this.btnCancel.Location = new System.Drawing.Point(150, 95);
			this.btnCancel.MinimumSize = new System.Drawing.Size(72, 23);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(72, 23);
			this.btnCancel.TabIndex = 3;
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnOK.AutoSize = true;
			this.btnOK.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnOK.Dock = System.Windows.Forms.DockStyle.Top;
			this.btnOK.Location = new System.Drawing.Point(72, 95);
			this.btnOK.MinimumSize = new System.Drawing.Size(72, 23);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(72, 23);
			this.btnOK.TabIndex = 2;
			this.btnOK.UseVisualStyleBackColor = true;
			this.btnOK.Click += new System.EventHandler(btnOK_Click);
			this.tableLayoutPanel1.AutoSize = true;
			this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.tableLayoutPanel1.ColumnCount = 3;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100f));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel1.Controls.Add(this.grpSize, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.btnCancel, 2, 2);
			this.tableLayoutPanel1.Controls.Add(this.btnOK, 1, 2);
			this.tableLayoutPanel1.Controls.Add(this.grpSettings, 0, 1);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(7, 7);
			this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 3;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100f));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.Size = new System.Drawing.Size(225, 121);
			this.tableLayoutPanel1.TabIndex = 4;
			base.AcceptButton = this.btnOK;
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.CancelButton = this.btnCancel;
			base.ClientSize = new System.Drawing.Size(239, 135);
			base.Controls.Add(this.tableLayoutPanel1);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "FormCheckboxDialog";
			base.Padding = new System.Windows.Forms.Padding(7);
			this.RightToLeftLayout = true;
			base.ShowIcon = false;
			base.ShowInTaskbar = false;
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.grpSize.ResumeLayout(false);
			this.grpSize.PerformLayout();
			this.tableLayoutPanel3.ResumeLayout(false);
			this.tableLayoutPanel3.PerformLayout();
			((System.ComponentModel.ISupportInitialize)this.nudSize).EndInit();
			this.grpSettings.ResumeLayout(false);
			this.grpSettings.PerformLayout();
			this.tableLayoutPanel2.ResumeLayout(false);
			this.tableLayoutPanel2.PerformLayout();
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			base.ResumeLayout(false);
			base.PerformLayout();
		}
	}
}
