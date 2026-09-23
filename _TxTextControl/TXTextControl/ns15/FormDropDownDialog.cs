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
	internal class FormDropDownDialog : HighDpiForm
	{
		private FormDropDown formDropDown_0;

		private string string_0;

		private string string_1;

		private IContainer icontainer_0;

		private GroupBox grpSettings;

		private CheckBox cbCalculate;

		private CheckBox cbEnabled;

		private TextBox tbName;

		private Label lblName;

		private Button btnCancel;

		private Button btnOK;

		private Button btnAddHelpText;

		private Label lblItem;

		private TextBox tbItem;

		private Button btnAdd;

		private Button btnRemove;

		private Label lblItems;

		private ListBox lbItems;

		private Button btnUp;

		private Button btnDown;

		private TableLayoutPanel tableLayoutPanel1;

		private TableLayoutPanel tableLayoutPanel3;

		private TableLayoutPanel tableLayoutPanel2;

		public FormDropDownDialog(FormDropDown formDropDown_1)
		{
			this.InitializeComponent();
			this.formDropDown_0 = formDropDown_1;
			this.Text = Resources.FORMDROPDOWN_DIALOG_TITLE;
			this.lblItem.Text = Resources.FORMDROPDOWN_LABEL_ITEM;
			this.btnAdd.Text = Resources.FORMDROPDOWN_BUTTON_ADD;
			this.btnRemove.Text = Resources.FORMDROPDOWN_BUTTON_REMOVE;
			this.lblItems.Text = Resources.FORMDROPDOWN_LABEL_ITEMS;
			this.btnUp.Text = Resources.FORMDROPDOWN_BUTTON_UP;
			this.btnDown.Text = Resources.FORMDROPDOWN_BUTTON_DOWN;
			this.grpSettings.Text = Resources.FORMDROPDOWN_GROUP_SETTINGS;
			this.lblName.Text = Resources.FORMDROPDOWN_LABEL_NAME;
			this.cbEnabled.Text = Resources.FORMDROPDOWN_CHECK_BOX_ENABLED;
			this.cbCalculate.Text = Resources.FORMDROPDOWN_CHECK_BOX_CALC_ON_EXIT;
			this.btnAddHelpText.Text = Resources.FORMDROPDOWN_BUTTON_ADD_HELP_TEXT;
			this.btnOK.Text = Resources.FORMDROPDOWN_BUTTON_OK;
			this.btnCancel.Text = Resources.FORMDROPDOWN_BUTTON_CANCEL;
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

		private void btnAdd_Click(object sender, EventArgs e)
		{
			this.method_2();
		}

		private void method_2()
		{
			this.lbItems.Items.Add(this.tbItem.Text);
			this.tbItem.Text = "";
			this.tbItem.Focus();
		}

		private void tbItem_TextChanged(object sender, EventArgs e)
		{
			if (this.tbItem.Text == string.Empty)
			{
				this.btnAdd.Enabled = false;
			}
			else
			{
				this.btnAdd.Enabled = true;
			}
		}

		private void tbItem_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == '\r')
			{
				this.method_2();
			}
		}

		private void FormDropDownDialog_Load(object sender, EventArgs e)
		{
			this.tbItem.Focus();
		}

		private void lbItems_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (this.lbItems.Items.Count == 0)
			{
				this.btnRemove.Enabled = false;
			}
			else
			{
				this.btnRemove.Enabled = true;
			}
			if (this.lbItems.SelectedIndex == 0)
			{
				this.btnUp.Enabled = false;
			}
			else
			{
				this.btnUp.Enabled = true;
			}
			if (this.lbItems.SelectedIndex == this.lbItems.Items.Count - 1)
			{
				this.btnDown.Enabled = false;
			}
			else
			{
				this.btnDown.Enabled = true;
			}
		}

		private void btnRemove_Click(object sender, EventArgs e)
		{
			this.lbItems.Items.Remove(this.lbItems.SelectedItem);
		}

		private void btnUp_Click(object sender, EventArgs e)
		{
			if (this.lbItems.SelectedIndex != -1)
			{
				int selectedIndex = this.lbItems.SelectedIndex;
				object selectedItem = this.lbItems.SelectedItem;
				this.lbItems.Items.Remove(selectedItem);
				this.lbItems.Items.Insert(selectedIndex - 1, selectedItem);
				this.lbItems.SelectedIndex = selectedIndex - 1;
			}
		}

		private void btnDown_Click(object sender, EventArgs e)
		{
			if (this.lbItems.SelectedIndex != -1)
			{
				int selectedIndex = this.lbItems.SelectedIndex;
				object selectedItem = this.lbItems.SelectedItem;
				this.lbItems.Items.Remove(selectedItem);
				this.lbItems.Items.Insert(selectedIndex + 1, selectedItem);
				this.lbItems.SelectedIndex = selectedIndex + 1;
			}
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

		private void method_3()
		{
			this.tbName.Text = this.formDropDown_0.Name;
			this.string_0 = this.formDropDown_0.HelpText;
			this.string_1 = this.formDropDown_0.StatusText;
			this.cbEnabled.Checked = this.formDropDown_0.Enabled;
			this.cbCalculate.Checked = this.formDropDown_0.CalcOnExit;
			if (this.formDropDown_0.ListEntries == null)
			{
				return;
			}
			foreach (string listEntry in this.formDropDown_0.ListEntries)
			{
				this.lbItems.Items.Add(listEntry);
			}
		}

		private void method_4()
		{
			this.formDropDown_0.Name = this.tbName.Text;
			this.formDropDown_0.HelpText = this.string_0;
			this.formDropDown_0.StatusText = this.string_1;
			this.formDropDown_0.CalcOnExit = this.cbCalculate.Checked;
			this.formDropDown_0.Enabled = this.cbEnabled.Checked;
			object[] array = new object[this.lbItems.Items.Count];
			this.lbItems.Items.CopyTo(array, 0);
			try
			{
				this.formDropDown_0.ListEntries = Array.ConvertAll(array, (object input) => (string)input);
			}
			catch
			{
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
			this.grpSettings = new System.Windows.Forms.GroupBox();
			this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
			this.btnAddHelpText = new System.Windows.Forms.Button();
			this.lblName = new System.Windows.Forms.Label();
			this.cbCalculate = new System.Windows.Forms.CheckBox();
			this.tbName = new System.Windows.Forms.TextBox();
			this.cbEnabled = new System.Windows.Forms.CheckBox();
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnOK = new System.Windows.Forms.Button();
			this.lblItem = new System.Windows.Forms.Label();
			this.tbItem = new System.Windows.Forms.TextBox();
			this.btnAdd = new System.Windows.Forms.Button();
			this.btnRemove = new System.Windows.Forms.Button();
			this.lblItems = new System.Windows.Forms.Label();
			this.lbItems = new System.Windows.Forms.ListBox();
			this.btnUp = new System.Windows.Forms.Button();
			this.btnDown = new System.Windows.Forms.Button();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
			this.grpSettings.SuspendLayout();
			this.tableLayoutPanel2.SuspendLayout();
			this.tableLayoutPanel1.SuspendLayout();
			this.tableLayoutPanel3.SuspendLayout();
			base.SuspendLayout();
			this.tableLayoutPanel1.SetColumnSpan(this.grpSettings, 3);
			this.grpSettings.Controls.Add(this.tableLayoutPanel2);
			this.grpSettings.Dock = System.Windows.Forms.DockStyle.Fill;
			this.grpSettings.Location = new System.Drawing.Point(3, 103);
			this.grpSettings.Name = "grpSettings";
			this.grpSettings.Size = new System.Drawing.Size(216, 119);
			this.grpSettings.TabIndex = 8;
			this.grpSettings.TabStop = false;
			this.tableLayoutPanel2.ColumnCount = 1;
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100f));
			this.tableLayoutPanel2.Controls.Add(this.btnAddHelpText, 0, 4);
			this.tableLayoutPanel2.Controls.Add(this.lblName, 0, 0);
			this.tableLayoutPanel2.Controls.Add(this.cbCalculate, 0, 3);
			this.tableLayoutPanel2.Controls.Add(this.tbName, 0, 1);
			this.tableLayoutPanel2.Controls.Add(this.cbEnabled, 0, 2);
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
			this.tableLayoutPanel2.Size = new System.Drawing.Size(210, 100);
			this.tableLayoutPanel2.TabIndex = 12;
			this.btnAddHelpText.AutoSize = true;
			this.btnAddHelpText.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.btnAddHelpText.Dock = System.Windows.Forms.DockStyle.Left;
			this.btnAddHelpText.Location = new System.Drawing.Point(3, 82);
			this.btnAddHelpText.MinimumSize = new System.Drawing.Size(72, 23);
			this.btnAddHelpText.Name = "btnAddHelpText";
			this.btnAddHelpText.Size = new System.Drawing.Size(72, 23);
			this.btnAddHelpText.TabIndex = 4;
			this.btnAddHelpText.UseVisualStyleBackColor = true;
			this.btnAddHelpText.Click += new System.EventHandler(btnAddHelpText_Click);
			this.lblName.AutoSize = true;
			this.lblName.Dock = System.Windows.Forms.DockStyle.Top;
			this.lblName.Location = new System.Drawing.Point(3, 0);
			this.lblName.Name = "lblName";
			this.lblName.Size = new System.Drawing.Size(204, 13);
			this.lblName.TabIndex = 0;
			this.lblName.Text = "x";
			this.cbCalculate.AutoSize = true;
			this.cbCalculate.Dock = System.Windows.Forms.DockStyle.Top;
			this.cbCalculate.Location = new System.Drawing.Point(3, 62);
			this.cbCalculate.Name = "cbCalculate";
			this.cbCalculate.Size = new System.Drawing.Size(204, 14);
			this.cbCalculate.TabIndex = 3;
			this.cbCalculate.UseVisualStyleBackColor = true;
			this.tbName.Dock = System.Windows.Forms.DockStyle.Left;
			this.tbName.Location = new System.Drawing.Point(3, 16);
			this.tbName.Name = "tbName";
			this.tbName.Size = new System.Drawing.Size(138, 20);
			this.tbName.TabIndex = 1;
			this.cbEnabled.AutoSize = true;
			this.cbEnabled.Dock = System.Windows.Forms.DockStyle.Top;
			this.cbEnabled.Location = new System.Drawing.Point(3, 42);
			this.cbEnabled.Name = "cbEnabled";
			this.cbEnabled.Size = new System.Drawing.Size(204, 14);
			this.cbEnabled.TabIndex = 2;
			this.cbEnabled.UseVisualStyleBackColor = true;
			this.btnCancel.AutoSize = true;
			this.btnCancel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Dock = System.Windows.Forms.DockStyle.Top;
			this.btnCancel.Location = new System.Drawing.Point(147, 228);
			this.btnCancel.MinimumSize = new System.Drawing.Size(72, 23);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(72, 23);
			this.btnCancel.TabIndex = 10;
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnOK.AutoSize = true;
			this.btnOK.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnOK.Dock = System.Windows.Forms.DockStyle.Top;
			this.btnOK.Location = new System.Drawing.Point(69, 228);
			this.btnOK.MinimumSize = new System.Drawing.Size(72, 23);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(72, 23);
			this.btnOK.TabIndex = 9;
			this.btnOK.UseVisualStyleBackColor = true;
			this.btnOK.Click += new System.EventHandler(btnOK_Click);
			this.lblItem.AutoSize = true;
			this.lblItem.Dock = System.Windows.Forms.DockStyle.Top;
			this.lblItem.Location = new System.Drawing.Point(3, 0);
			this.lblItem.Name = "lblItem";
			this.lblItem.Size = new System.Drawing.Size(94, 13);
			this.lblItem.TabIndex = 0;
			this.lblItem.Text = "x";
			this.tbItem.Location = new System.Drawing.Point(3, 16);
			this.tbItem.Name = "tbItem";
			this.tbItem.Size = new System.Drawing.Size(94, 20);
			this.tbItem.TabIndex = 1;
			this.tbItem.TextChanged += new System.EventHandler(tbItem_TextChanged);
			this.tbItem.KeyPress += new System.Windows.Forms.KeyPressEventHandler(tbItem_KeyPress);
			this.btnAdd.AutoSize = true;
			this.btnAdd.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.btnAdd.Dock = System.Windows.Forms.DockStyle.Left;
			this.btnAdd.Enabled = false;
			this.btnAdd.Location = new System.Drawing.Point(3, 45);
			this.btnAdd.MinimumSize = new System.Drawing.Size(72, 23);
			this.btnAdd.Name = "btnAdd";
			this.btnAdd.Size = new System.Drawing.Size(72, 23);
			this.btnAdd.TabIndex = 6;
			this.btnAdd.UseVisualStyleBackColor = true;
			this.btnAdd.Click += new System.EventHandler(btnAdd_Click);
			this.btnRemove.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.btnRemove.Dock = System.Windows.Forms.DockStyle.Left;
			this.btnRemove.Enabled = false;
			this.btnRemove.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.btnRemove.Location = new System.Drawing.Point(3, 74);
			this.btnRemove.MinimumSize = new System.Drawing.Size(72, 23);
			this.btnRemove.Name = "btnRemove";
			this.btnRemove.Size = new System.Drawing.Size(72, 23);
			this.btnRemove.TabIndex = 7;
			this.btnRemove.UseVisualStyleBackColor = true;
			this.btnRemove.Click += new System.EventHandler(btnRemove_Click);
			this.lblItems.AutoSize = true;
			this.lblItems.Dock = System.Windows.Forms.DockStyle.Top;
			this.lblItems.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.lblItems.Location = new System.Drawing.Point(103, 0);
			this.lblItems.Name = "lblItems";
			this.lblItems.Size = new System.Drawing.Size(38, 13);
			this.lblItems.TabIndex = 2;
			this.lblItems.Text = "x";
			this.lbItems.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lbItems.FormattingEnabled = true;
			this.lbItems.IntegralHeight = false;
			this.lbItems.Location = new System.Drawing.Point(103, 16);
			this.lbItems.MinimumSize = new System.Drawing.Size(240, 69);
			this.lbItems.Name = "lbItems";
			this.tableLayoutPanel3.SetRowSpan(this.lbItems, 4);
			this.lbItems.Size = new System.Drawing.Size(240, 81);
			this.lbItems.TabIndex = 3;
			this.lbItems.SelectedIndexChanged += new System.EventHandler(lbItems_SelectedIndexChanged);
			this.btnUp.AutoSize = true;
			this.btnUp.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.btnUp.Location = new System.Drawing.Point(147, 16);
			this.btnUp.MinimumSize = new System.Drawing.Size(72, 23);
			this.btnUp.Name = "btnUp";
			this.btnUp.Size = new System.Drawing.Size(72, 23);
			this.btnUp.TabIndex = 4;
			this.btnUp.UseVisualStyleBackColor = true;
			this.btnUp.Click += new System.EventHandler(btnUp_Click);
			this.btnDown.AutoSize = true;
			this.btnDown.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.btnDown.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.btnDown.Location = new System.Drawing.Point(147, 45);
			this.btnDown.MinimumSize = new System.Drawing.Size(72, 23);
			this.btnDown.Name = "btnDown";
			this.btnDown.Size = new System.Drawing.Size(72, 23);
			this.btnDown.TabIndex = 5;
			this.btnDown.UseVisualStyleBackColor = true;
			this.btnDown.Click += new System.EventHandler(btnDown_Click);
			this.tableLayoutPanel1.AutoSize = true;
			this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.tableLayoutPanel1.ColumnCount = 3;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100f));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.btnOK, 1, 2);
			this.tableLayoutPanel1.Controls.Add(this.btnCancel, 2, 2);
			this.tableLayoutPanel1.Controls.Add(this.grpSettings, 0, 1);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(7, 7);
			this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 3;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.Size = new System.Drawing.Size(222, 142);
			this.tableLayoutPanel1.TabIndex = 11;
			this.tableLayoutPanel3.AutoSize = true;
			this.tableLayoutPanel3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.tableLayoutPanel3.ColumnCount = 3;
			this.tableLayoutPanel1.SetColumnSpan(this.tableLayoutPanel3, 3);
			this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100f));
			this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel3.Controls.Add(this.lblItem, 0, 0);
			this.tableLayoutPanel3.Controls.Add(this.btnDown, 2, 2);
			this.tableLayoutPanel3.Controls.Add(this.tbItem, 0, 1);
			this.tableLayoutPanel3.Controls.Add(this.btnUp, 2, 1);
			this.tableLayoutPanel3.Controls.Add(this.btnAdd, 0, 2);
			this.tableLayoutPanel3.Controls.Add(this.btnRemove, 0, 3);
			this.tableLayoutPanel3.Controls.Add(this.lbItems, 1, 1);
			this.tableLayoutPanel3.Controls.Add(this.lblItems, 1, 0);
			this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(0);
			this.tableLayoutPanel3.Name = "tableLayoutPanel3";
			this.tableLayoutPanel3.RowCount = 5;
			this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100f));
			this.tableLayoutPanel3.Size = new System.Drawing.Size(222, 100);
			this.tableLayoutPanel3.TabIndex = 12;
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.CancelButton = this.btnCancel;
			base.ClientSize = new System.Drawing.Size(236, 156);
			base.Controls.Add(this.tableLayoutPanel1);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "FormDropDownDialog";
			base.Padding = new System.Windows.Forms.Padding(7);
			this.RightToLeftLayout = true;
			base.ShowIcon = false;
			base.ShowInTaskbar = false;
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			base.Load += new System.EventHandler(FormDropDownDialog_Load);
			this.grpSettings.ResumeLayout(false);
			this.tableLayoutPanel2.ResumeLayout(false);
			this.tableLayoutPanel2.PerformLayout();
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			this.tableLayoutPanel3.ResumeLayout(false);
			this.tableLayoutPanel3.PerformLayout();
			base.ResumeLayout(false);
			base.PerformLayout();
		}
	}
}
