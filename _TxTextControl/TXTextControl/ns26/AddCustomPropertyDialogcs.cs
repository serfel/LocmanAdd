using System;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Resources;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using ns21;
using ns27;
using TXTextControl;

namespace ns26
{
	internal class AddCustomPropertyDialogcs : Form
	{
		private enum Enum139
		{
			const_0,
			const_1,
			const_2
		}

		private ResourceManager resourceManager_0 = new ResourceManager(typeof(TextControlCore));

		private uint uint_0;

		private Enum139 enum139_0;

		private DocumentSettings documentSettings_0;

		private IContainer icontainer_0;

		private TableLayoutPanel m_tlpMainPanel;

		private Label m_lblName;

		private Label m_lblType;

		private Label m_lblValue;

		private TableLayoutPanel m_tlpValue;

		private TextBox m_tbxValue;

		private ComboBox m_cmbxValue;

		private TextBox m_tbxName;

		private System.Windows.Forms.Button m_btnOK;

		private System.Windows.Forms.Button m_btnCancel;

		private ComboBox m_cmbxType;

		internal Class569.Class577 Class577_0
		{
			get
			{
				object object_ = false;
				switch (this.enum139_0)
				{
				case Enum139.const_0:
					object_ = this.m_tbxValue.Text;
					break;
				case Enum139.const_1:
				{
					if (int.TryParse(this.m_tbxValue.Text, NumberStyles.Integer, Thread.CurrentThread.CurrentUICulture, out var result))
					{
						object_ = result;
						break;
					}
					double.TryParse(this.m_tbxValue.Text, NumberStyles.Number, Thread.CurrentThread.CurrentUICulture, out var result2);
					object_ = result2;
					break;
				}
				case Enum139.const_2:
					object_ = this.m_cmbxValue.SelectedIndex == 0;
					break;
				}
				return new Class569.Class577(this.m_tbxName.Text, object_);
			}
		}

		public AddCustomPropertyDialogcs(DocumentSettings documentSettings_1)
		{
			this.documentSettings_0 = documentSettings_1;
			this.InitializeComponent();
			this.Text = this.resourceManager_0.GetString("ID_ADDCUSTOMPROPERTY_CAPTION");
			this.m_lblName.Text = this.resourceManager_0.GetString("ID_ADDCUSTOMPROPERTY_NAME");
			this.m_lblType.Text = this.resourceManager_0.GetString("ID_ADDCUSTOMPROPERTY_TYPE");
			this.m_cmbxType.Items.AddRange(new object[3]
			{
				this.resourceManager_0.GetString("ID_ADDCUSTOMPROPERTY_TYPE_STRING"),
				this.resourceManager_0.GetString("ID_ADDCUSTOMPROPERTY_TYPE_DOUBLE"),
				this.resourceManager_0.GetString("ID_ADDCUSTOMPROPERTY_TYPE_BOOLEAN")
			});
			this.m_lblValue.Text = this.resourceManager_0.GetString("ID_ADDCUSTOMPROPERTY_VALUE");
			this.m_cmbxValue.Items.AddRange(new object[2]
			{
				this.resourceManager_0.GetString("ID_ADDCUSTOMPROPERTY_VALUE_TRUE"),
				this.resourceManager_0.GetString("ID_ADDCUSTOMPROPERTY_VALUE_NO")
			});
			this.m_btnOK.Text = this.resourceManager_0.GetString("ID_ADDCUSTOMPROPERTY_OK");
			this.m_btnCancel.Text = this.resourceManager_0.GetString("ID_ADDCUSTOMPROPERTY_CANCEL");
			this.method_1();
		}

		private bool method_0(string string_0)
		{
			bool flag;
			if (flag = !string.IsNullOrEmpty(string_0))
			{
				flag &= this.documentSettings_0.UserDefinedDocumentProperties == null || !this.documentSettings_0.UserDefinedDocumentProperties.Contains(string_0);
			}
			return flag;
		}

		private void method_1()
		{
			bool flag;
			if (flag = this.method_0(this.m_tbxName.Text))
			{
				switch (this.enum139_0)
				{
				case Enum139.const_0:
					flag &= !string.IsNullOrEmpty(this.m_tbxValue.Text);
					break;
				case Enum139.const_1:
				{
					flag &= double.TryParse(this.m_tbxValue.Text, NumberStyles.Number, Thread.CurrentThread.CurrentUICulture, out var _);
					break;
				}
				case Enum139.const_2:
					flag &= this.m_cmbxValue.SelectedIndex >= 0;
					break;
				}
			}
			this.m_btnOK.Enabled = flag;
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

		private void m_btnOK_Click(object sender, EventArgs e)
		{
			base.Close();
		}

		private void m_cmbxType_SelectedIndexChanged(object sender, EventArgs e)
		{
			int selectedIndex = (sender as ComboBox).SelectedIndex;
			this.m_tbxValue.Text = "";
			this.m_cmbxValue.SelectedIndex = -1;
			switch (selectedIndex)
			{
			case 0:
				this.m_tbxValue.Visible = true;
				this.m_cmbxValue.Visible = false;
				this.enum139_0 = Enum139.const_0;
				break;
			case 1:
				this.m_tbxValue.Visible = true;
				this.m_cmbxValue.Visible = false;
				this.enum139_0 = Enum139.const_1;
				break;
			case 2:
				this.m_tbxValue.Visible = false;
				this.m_cmbxValue.Visible = true;
				this.enum139_0 = Enum139.const_2;
				break;
			}
		}

		private void m_tbxName_TextChanged(object sender, EventArgs e)
		{
			this.method_1();
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
			this.m_lblName = new System.Windows.Forms.Label();
			this.m_lblType = new System.Windows.Forms.Label();
			this.m_lblValue = new System.Windows.Forms.Label();
			this.m_tlpValue = new System.Windows.Forms.TableLayoutPanel();
			this.m_tbxValue = new System.Windows.Forms.TextBox();
			this.m_cmbxValue = new System.Windows.Forms.ComboBox();
			this.m_tbxName = new System.Windows.Forms.TextBox();
			this.m_btnOK = new System.Windows.Forms.Button();
			this.m_btnCancel = new System.Windows.Forms.Button();
			this.m_cmbxType = new System.Windows.Forms.ComboBox();
			this.m_tlpMainPanel.SuspendLayout();
			this.m_tlpValue.SuspendLayout();
			base.SuspendLayout();
			this.m_tlpMainPanel.AutoSize = true;
			this.m_tlpMainPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.m_tlpMainPanel.ColumnCount = 4;
			this.m_tlpMainPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.m_tlpMainPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100f));
			this.m_tlpMainPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.m_tlpMainPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.m_tlpMainPanel.Controls.Add(this.m_lblName, 0, 0);
			this.m_tlpMainPanel.Controls.Add(this.m_lblType, 0, 1);
			this.m_tlpMainPanel.Controls.Add(this.m_lblValue, 0, 2);
			this.m_tlpMainPanel.Controls.Add(this.m_tlpValue, 1, 2);
			this.m_tlpMainPanel.Controls.Add(this.m_tbxName, 1, 0);
			this.m_tlpMainPanel.Controls.Add(this.m_btnOK, 2, 3);
			this.m_tlpMainPanel.Controls.Add(this.m_btnCancel, 3, 3);
			this.m_tlpMainPanel.Controls.Add(this.m_cmbxType, 1, 1);
			this.m_tlpMainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.m_tlpMainPanel.Location = new System.Drawing.Point(7, 7);
			this.m_tlpMainPanel.Name = "m_tlpMainPanel";
			this.m_tlpMainPanel.RowCount = 4;
			this.m_tlpMainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.m_tlpMainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.m_tlpMainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.m_tlpMainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100f));
			this.m_tlpMainPanel.Size = new System.Drawing.Size(263, 182);
			this.m_tlpMainPanel.TabIndex = 0;
			this.m_lblName.AutoSize = true;
			this.m_lblName.Dock = System.Windows.Forms.DockStyle.Top;
			this.m_lblName.Location = new System.Drawing.Point(0, 3);
			this.m_lblName.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
			this.m_lblName.Name = "m_lblName";
			this.m_lblName.Size = new System.Drawing.Size(38, 13);
			this.m_lblName.TabIndex = 1;
			this.m_lblName.Text = "Name:";
			this.m_lblType.AutoSize = true;
			this.m_lblType.Dock = System.Windows.Forms.DockStyle.Top;
			this.m_lblType.Location = new System.Drawing.Point(0, 29);
			this.m_lblType.Margin = new System.Windows.Forms.Padding(0, 6, 3, 3);
			this.m_lblType.Name = "m_lblType";
			this.m_lblType.Size = new System.Drawing.Size(38, 13);
			this.m_lblType.TabIndex = 3;
			this.m_lblType.Text = "Type:";
			this.m_lblValue.AutoSize = true;
			this.m_lblValue.Dock = System.Windows.Forms.DockStyle.Top;
			this.m_lblValue.Location = new System.Drawing.Point(0, 56);
			this.m_lblValue.Margin = new System.Windows.Forms.Padding(0, 6, 3, 3);
			this.m_lblValue.Name = "m_lblValue";
			this.m_lblValue.Size = new System.Drawing.Size(38, 13);
			this.m_lblValue.TabIndex = 5;
			this.m_lblValue.Text = "Value:";
			this.m_tlpValue.AutoSize = true;
			this.m_tlpValue.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.m_tlpValue.ColumnCount = 1;
			this.m_tlpMainPanel.SetColumnSpan(this.m_tlpValue, 3);
			this.m_tlpValue.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100f));
			this.m_tlpValue.Controls.Add(this.m_tbxValue, 0, 0);
			this.m_tlpValue.Controls.Add(this.m_cmbxValue, 0, 1);
			this.m_tlpValue.Dock = System.Windows.Forms.DockStyle.Fill;
			this.m_tlpValue.Location = new System.Drawing.Point(41, 50);
			this.m_tlpValue.Margin = new System.Windows.Forms.Padding(0, 0, 0, 15);
			this.m_tlpValue.MinimumSize = new System.Drawing.Size(0, 27);
			this.m_tlpValue.Name = "m_tlpValue";
			this.m_tlpValue.RowCount = 3;
			this.m_tlpValue.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.m_tlpValue.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.m_tlpValue.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100f));
			this.m_tlpValue.Size = new System.Drawing.Size(222, 53);
			this.m_tlpValue.TabIndex = 6;
			this.m_tbxValue.Location = new System.Drawing.Point(3, 3);
			this.m_tbxValue.Margin = new System.Windows.Forms.Padding(3, 3, 0, 3);
			this.m_tbxValue.MinimumSize = new System.Drawing.Size(183, 20);
			this.m_tbxValue.Name = "m_tbxValue";
			this.m_tbxValue.Size = new System.Drawing.Size(183, 20);
			this.m_tbxValue.TabIndex = 7;
			this.m_tbxValue.TextChanged += new System.EventHandler(m_tbxName_TextChanged);
			this.m_cmbxValue.Dock = System.Windows.Forms.DockStyle.Top;
			this.m_cmbxValue.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.m_cmbxValue.FormattingEnabled = true;
			this.m_cmbxValue.Location = new System.Drawing.Point(3, 29);
			this.m_cmbxValue.Margin = new System.Windows.Forms.Padding(3, 3, 0, 3);
			this.m_cmbxValue.MaximumSize = new System.Drawing.Size(183, 0);
			this.m_cmbxValue.MinimumSize = new System.Drawing.Size(183, 0);
			this.m_cmbxValue.Name = "m_cmbxValue";
			this.m_cmbxValue.Size = new System.Drawing.Size(183, 21);
			this.m_cmbxValue.TabIndex = 8;
			this.m_cmbxValue.Visible = false;
			this.m_cmbxValue.SelectedIndexChanged += new System.EventHandler(m_tbxName_TextChanged);
			this.m_tlpMainPanel.SetColumnSpan(this.m_tbxName, 3);
			this.m_tbxName.Dock = System.Windows.Forms.DockStyle.Left;
			this.m_tbxName.Location = new System.Drawing.Point(44, 0);
			this.m_tbxName.Margin = new System.Windows.Forms.Padding(3, 0, 0, 3);
			this.m_tbxName.MinimumSize = new System.Drawing.Size(183, 20);
			this.m_tbxName.Name = "m_tbxName";
			this.m_tbxName.Size = new System.Drawing.Size(183, 20);
			this.m_tbxName.TabIndex = 2;
			this.m_tbxName.TextChanged += new System.EventHandler(m_tbxName_TextChanged);
			this.m_btnOK.AutoSize = true;
			this.m_btnOK.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.m_btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.m_btnOK.Dock = System.Windows.Forms.DockStyle.Top;
			this.m_btnOK.Location = new System.Drawing.Point(107, 121);
			this.m_btnOK.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
			this.m_btnOK.MinimumSize = new System.Drawing.Size(75, 23);
			this.m_btnOK.Name = "m_btnOK";
			this.m_btnOK.Size = new System.Drawing.Size(75, 23);
			this.m_btnOK.TabIndex = 9;
			this.m_btnOK.Text = "OK";
			this.m_btnOK.UseVisualStyleBackColor = true;
			this.m_btnOK.Click += new System.EventHandler(m_btnOK_Click);
			this.m_btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.m_btnCancel.Dock = System.Windows.Forms.DockStyle.Top;
			this.m_btnCancel.Location = new System.Drawing.Point(188, 121);
			this.m_btnCancel.Margin = new System.Windows.Forms.Padding(3, 3, 0, 0);
			this.m_btnCancel.MinimumSize = new System.Drawing.Size(75, 23);
			this.m_btnCancel.Name = "m_btnCancel";
			this.m_btnCancel.Size = new System.Drawing.Size(75, 23);
			this.m_btnCancel.TabIndex = 10;
			this.m_btnCancel.Text = "Cancel";
			this.m_btnCancel.UseVisualStyleBackColor = true;
			this.m_tlpMainPanel.SetColumnSpan(this.m_cmbxType, 3);
			this.m_cmbxType.Dock = System.Windows.Forms.DockStyle.Top;
			this.m_cmbxType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.m_cmbxType.FormattingEnabled = true;
			this.m_cmbxType.Location = new System.Drawing.Point(44, 26);
			this.m_cmbxType.Margin = new System.Windows.Forms.Padding(3, 3, 0, 3);
			this.m_cmbxType.MaximumSize = new System.Drawing.Size(183, 0);
			this.m_cmbxType.MinimumSize = new System.Drawing.Size(183, 0);
			this.m_cmbxType.Name = "m_cmbxType";
			this.m_cmbxType.Size = new System.Drawing.Size(183, 21);
			this.m_cmbxType.TabIndex = 4;
			this.m_cmbxType.SelectedIndexChanged += new System.EventHandler(m_cmbxType_SelectedIndexChanged);
			base.AcceptButton = this.m_btnOK;
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.CancelButton = this.m_btnCancel;
			base.ClientSize = new System.Drawing.Size(277, 196);
			base.Controls.Add(this.m_tlpMainPanel);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "AddCustomPropertyDialogcs";
			base.Padding = new System.Windows.Forms.Padding(7);
			base.ShowIcon = false;
			base.ShowInTaskbar = false;
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Add Custom Property";
			this.m_tlpMainPanel.ResumeLayout(false);
			this.m_tlpMainPanel.PerformLayout();
			this.m_tlpValue.ResumeLayout(false);
			this.m_tlpValue.PerformLayout();
			base.ResumeLayout(false);
			base.PerformLayout();
		}
	}
}
