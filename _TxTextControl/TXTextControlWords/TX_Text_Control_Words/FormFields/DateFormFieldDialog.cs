using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using TX_Text_Control_Words.Properties;
using TXTextControl;

namespace TX_Text_Control_Words.FormFields
{
	public class DateFormFieldDialog : Form
	{
		private readonly string PLACEHOLDER_DEFAULT = Resources.DATEFORMFIELD_DLG_PLACEHOLDER_DEFAULT;

		private string[] m_supportedDateFormats;

		private DateFormField m_dateFormField;

		private IContainer components;

		private TextBox m_tbCurrentDateFormat;

		private ListBox m_listBoxDateFormat;

		private System.Windows.Forms.Button m_btnCancel;

		private System.Windows.Forms.Button m_btnOK;

		private EmptyWidthControl m_emptyWidthControl;

		private TableLayoutPanel tableLayoutPanel1;

		private TableLayoutPanel tableLayoutPanel2;

		private GroupBox groupBox1;

		private TableLayoutPanel tableLayoutPanel3;

		public DateFormFieldDialog(DateFormField dateFormField)
		{
			this.InitializeComponent();
			this.m_dateFormField = dateFormField;
			this.m_supportedDateFormats = this.m_dateFormField.SupportedDateFormats;
			this.m_listBoxDateFormat.Items.Add(this.PLACEHOLDER_DEFAULT);
			ListBox.ObjectCollection items = this.m_listBoxDateFormat.Items;
			object[] supportedDateFormats = this.m_supportedDateFormats;
			items.AddRange(supportedDateFormats);
			try
			{
				this.m_listBoxDateFormat.SelectedItem = (string.IsNullOrEmpty(this.m_dateFormField.DateFormat) ? this.PLACEHOLDER_DEFAULT : this.m_dateFormField.DateFormat);
			}
			catch
			{
			}
			this.m_emptyWidthControl.Value = dateFormField.EmptyWidth;
		}

		private void m_listBoxDateFormat_SelectedValueChanged(object sender, EventArgs e)
		{
			int selectedIndex = this.m_listBoxDateFormat.SelectedIndex;
			if (selectedIndex >= 0)
			{
				this.m_tbCurrentDateFormat.Text = this.GetTextBoxText((string)this.m_listBoxDateFormat.SelectedItem);
			}
		}

		private void m_btnOK_Click(object sender, EventArgs e)
		{
			string text = (string)this.m_listBoxDateFormat.SelectedItem;
			this.m_dateFormField.DateFormat = ((text != null && text != this.PLACEHOLDER_DEFAULT) ? text : string.Empty);
			this.m_dateFormField.EmptyWidth = this.m_emptyWidthControl.Value;
		}

		private string GetTextBoxText(string dateFormat)
		{
			DateTime? date = this.m_dateFormField.Date;
			if (string.IsNullOrEmpty(dateFormat) || dateFormat == this.PLACEHOLDER_DEFAULT)
			{
				return this.PLACEHOLDER_DEFAULT;
			}
			if (!date.HasValue)
			{
				return DateTime.Now.ToString(dateFormat);
			}
			return date.Value.ToString(dateFormat);
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TX_Text_Control_Words.FormFields.DateFormFieldDialog));
			this.m_tbCurrentDateFormat = new System.Windows.Forms.TextBox();
			this.m_listBoxDateFormat = new System.Windows.Forms.ListBox();
			this.m_btnCancel = new System.Windows.Forms.Button();
			this.m_btnOK = new System.Windows.Forms.Button();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
			this.m_emptyWidthControl = new TX_Text_Control_Words.FormFields.EmptyWidthControl();
			this.tableLayoutPanel1.SuspendLayout();
			this.tableLayoutPanel2.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.tableLayoutPanel3.SuspendLayout();
			base.SuspendLayout();
			resources.ApplyResources(this.m_tbCurrentDateFormat, "m_tbCurrentDateFormat");
			this.m_tbCurrentDateFormat.Name = "m_tbCurrentDateFormat";
			this.m_tbCurrentDateFormat.ReadOnly = true;
			resources.ApplyResources(this.m_listBoxDateFormat, "m_listBoxDateFormat");
			this.m_listBoxDateFormat.FormatString = "t";
			this.m_listBoxDateFormat.FormattingEnabled = true;
			this.m_listBoxDateFormat.Name = "m_listBoxDateFormat";
			this.m_listBoxDateFormat.SelectedValueChanged += new System.EventHandler(m_listBoxDateFormat_SelectedValueChanged);
			this.m_btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			resources.ApplyResources(this.m_btnCancel, "m_btnCancel");
			this.m_btnCancel.Name = "m_btnCancel";
			this.m_btnCancel.UseVisualStyleBackColor = true;
			this.m_btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
			resources.ApplyResources(this.m_btnOK, "m_btnOK");
			this.m_btnOK.Name = "m_btnOK";
			this.m_btnOK.UseVisualStyleBackColor = true;
			this.m_btnOK.Click += new System.EventHandler(m_btnOK_Click);
			resources.ApplyResources(this.tableLayoutPanel1, "tableLayoutPanel1");
			this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 2);
			this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 1);
			this.tableLayoutPanel1.Controls.Add(this.m_emptyWidthControl, 0, 0);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			resources.ApplyResources(this.tableLayoutPanel2, "tableLayoutPanel2");
			this.tableLayoutPanel2.Controls.Add(this.m_btnOK, 1, 0);
			this.tableLayoutPanel2.Controls.Add(this.m_btnCancel, 2, 0);
			this.tableLayoutPanel2.Name = "tableLayoutPanel2";
			resources.ApplyResources(this.groupBox1, "groupBox1");
			this.groupBox1.Controls.Add(this.tableLayoutPanel3);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.TabStop = false;
			resources.ApplyResources(this.tableLayoutPanel3, "tableLayoutPanel3");
			this.tableLayoutPanel3.Controls.Add(this.m_listBoxDateFormat, 0, 1);
			this.tableLayoutPanel3.Controls.Add(this.m_tbCurrentDateFormat, 0, 0);
			this.tableLayoutPanel3.Name = "tableLayoutPanel3";
			resources.ApplyResources(this.m_emptyWidthControl, "m_emptyWidthControl");
			this.m_emptyWidthControl.Name = "m_emptyWidthControl";
			this.m_emptyWidthControl.Value = 102;
			base.AcceptButton = this.m_btnOK;
			base.AutoScaleDimensions = new System.Drawing.SizeF(96f, 96f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
			this.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			base.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			resources.ApplyResources(this, "$this");
			base.CancelButton = this.m_btnCancel;
			base.Controls.Add(this.tableLayoutPanel1);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "DateFormFieldDialog";
			base.ShowIcon = false;
			base.ShowInTaskbar = false;
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			this.tableLayoutPanel2.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.tableLayoutPanel3.ResumeLayout(false);
			this.tableLayoutPanel3.PerformLayout();
			base.ResumeLayout(false);
			base.PerformLayout();
		}
	}
}
