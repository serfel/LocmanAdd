using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using ns16;
using DocumentServer.Properties;
using DocumentServer.Windows.Forms;

namespace DocumentServer.Data.ConnectionUI
{
	[Obfuscation(Exclude = true)]
	internal class DatabaseConnectionSourceDialog : HighDpiForm
	{
		private Label dataSourceLabel;

		private Dictionary<Class154, Class153> dictionary_0 = new Dictionary<Class154, Class153>();

		private DatabaseConnectionDialog databaseConnectionDialog_0;

		private IContainer icontainer_0;

		private TableLayoutPanel mainTableLayoutPanel;

		private ListBox dataSourceListBox;

		private Label dataProviderLabel;

		private ComboBox dataProviderComboBox;

		private GroupBox descriptionGroupBox;

		private RichTextBox descriptionLabel;

		private CheckBox saveSelectionCheckBox;

		private System.Windows.Forms.Button okButton;

		private System.Windows.Forms.Button cancelButton;

		private TableLayoutPanel tableLayoutPanel1;

		private Label dataSourceLabel_1;

		public string Title
		{
			get
			{
				return this.Text;
			}
			set
			{
				this.Text = value;
			}
		}

		public string HeaderLabel
		{
			get
			{
				if (this.dataSourceLabel == null)
				{
					return string.Empty;
				}
				return this.dataSourceLabel.Text;
			}
			set
			{
				if ((this.dataSourceLabel == null && (value == null || value.Length == 0)) || (this.dataSourceLabel != null && value == this.dataSourceLabel.Text))
				{
					return;
				}
				if (value != null)
				{
					if (this.dataSourceLabel == null)
					{
						this.dataSourceLabel = new Label();
						this.dataSourceLabel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
						this.dataSourceLabel.FlatStyle = FlatStyle.System;
						this.dataSourceLabel.Location = new Point(12, 12);
						this.dataSourceLabel.Margin = new Padding(3);
						this.dataSourceLabel.Name = "dataSourceLabel";
						this.dataSourceLabel.Width = this.mainTableLayoutPanel.Width;
						this.dataSourceLabel.TabIndex = 100;
						base.Controls.Add(this.dataSourceLabel);
					}
					this.dataSourceLabel.Text = value;
					this.MinimumSize = Size.Empty;
					this.dataSourceLabel.Height = Class158.smethod_0(this.dataSourceLabel);
					int num = this.dataSourceLabel.Bottom + this.dataSourceLabel.Margin.Bottom + this.mainTableLayoutPanel.Margin.Top - this.mainTableLayoutPanel.Top;
					this.mainTableLayoutPanel.Anchor &= ~AnchorStyles.Bottom;
					base.Height += num;
					this.mainTableLayoutPanel.Anchor |= AnchorStyles.Bottom;
					this.mainTableLayoutPanel.Top += num;
					this.MinimumSize = base.Size;
				}
				else if (this.dataSourceLabel != null)
				{
					int num2 = this.dataSourceLabel.Height;
					try
					{
						base.Controls.Remove(this.dataSourceLabel);
					}
					finally
					{
						this.dataSourceLabel.Dispose();
						this.dataSourceLabel = null;
					}
					this.MinimumSize = Size.Empty;
					this.mainTableLayoutPanel.Top -= num2;
					this.mainTableLayoutPanel.Anchor &= ~AnchorStyles.Bottom;
					base.Height -= num2;
					this.mainTableLayoutPanel.Anchor |= AnchorStyles.Bottom;
					this.MinimumSize = base.Size;
				}
			}
		}

		public DatabaseConnectionSourceDialog()
		{
			this.InitializeComponent();
			if (this.icontainer_0 == null)
			{
				this.icontainer_0 = new Container();
			}
			this.icontainer_0.Add(new Class166(this));
			this.Text = Resources.DATACONNECTIONSOURCE_DIALOG_TITLE;
			this.cancelButton.Text = Resources.DATACONNECTIONSOURCE_DIALOG_BUTTON_CANCEL;
			this.okButton.Text = Resources.DATACONNECTIONSOURCE_DIALOG_BUTTON_OK;
			this.dataProviderLabel.Text = Resources.DATACONNECTIONSOURCE_DIALOG_LABEL_DATAPROVIDER;
			this.dataSourceLabel_1.Text = Resources.DATACONNECTIONSOURCE_DIALOG_LABEL_DATASOURCE;
			this.descriptionGroupBox.Text = Resources.DATACONNECTIONSOURCE_DIALOG_GROUPBOX_DESCRIPTION;
			this.saveSelectionCheckBox.Text = Resources.DATACONNECTIONSOURCE_DIALOG_CHECKBOX_SAVESELECTION;
		}

		public DatabaseConnectionSourceDialog(DatabaseConnectionDialog mainDialog)
			: this()
		{
			this.databaseConnectionDialog_0 = mainDialog;
		}

		protected override void OnLoad(EventArgs eventArgs_0)
		{
			if (this.databaseConnectionDialog_0 != null)
			{
				foreach (Class154 item in this.databaseConnectionDialog_0.Class142_0)
				{
					if (item != this.databaseConnectionDialog_0.Class154_0)
					{
						this.dataSourceListBox.Items.Add(item);
					}
				}
				if (this.databaseConnectionDialog_0.Class142_0.method_1(this.databaseConnectionDialog_0.Class154_0))
				{
					this.dataSourceListBox.Sorted = false;
					this.dataSourceListBox.Items.Add(this.databaseConnectionDialog_0.Class154_0);
				}
				int num = this.dataSourceListBox.Width - (this.dataSourceListBox.Width - this.dataSourceListBox.ClientSize.Width);
				foreach (object item2 in this.dataSourceListBox.Items)
				{
					Size size = TextRenderer.MeasureText((item2 as Class154).String_1, this.dataSourceListBox.Font);
					size.Width += 3;
					num = Math.Max(num, size.Width);
				}
				num += this.dataSourceListBox.Width - this.dataSourceListBox.ClientSize.Width;
				num = Math.Max(num, this.dataSourceListBox.MinimumSize.Width);
				int num2 = num - this.dataSourceListBox.Size.Width;
				base.Width += num2 * 2;
				this.MinimumSize = base.Size;
				if (this.databaseConnectionDialog_0.Class154_1 != null)
				{
					this.dataSourceListBox.SelectedItem = this.databaseConnectionDialog_0.Class154_1;
					if (this.databaseConnectionDialog_0.Class153_0 != null)
					{
						this.dataProviderComboBox.SelectedItem = this.databaseConnectionDialog_0.Class153_0;
					}
				}
				foreach (Class154 item3 in this.dataSourceListBox.Items)
				{
					Class153 class3 = this.databaseConnectionDialog_0.method_4(item3);
					if (class3 != null)
					{
						this.dictionary_0[item3] = class3;
					}
				}
			}
			this.saveSelectionCheckBox.Checked = this.databaseConnectionDialog_0.Boolean_1;
			this.method_3();
			base.OnLoad(eventArgs_0);
		}

		protected override void OnRightToLeftLayoutChanged(EventArgs eventArgs_0)
		{
			base.OnRightToLeftLayoutChanged(eventArgs_0);
			if (this.RightToLeftLayout && this.RightToLeft == RightToLeft.Yes)
			{
				Class158.smethod_4(this.dataSourceLabel_1, this.dataSourceListBox);
				Class158.smethod_4(this.dataProviderLabel, this.dataProviderComboBox);
			}
			else
			{
				Class158.smethod_6(this.dataProviderLabel, this.dataProviderComboBox);
				Class158.smethod_6(this.dataSourceLabel_1, this.dataSourceListBox);
			}
		}

		protected override void OnRightToLeftChanged(EventArgs eventArgs_0)
		{
			base.OnRightToLeftChanged(eventArgs_0);
			if (this.RightToLeftLayout && this.RightToLeft == RightToLeft.Yes)
			{
				Class158.smethod_4(this.dataSourceLabel_1, this.dataSourceListBox);
				Class158.smethod_4(this.dataProviderLabel, this.dataProviderComboBox);
			}
			else
			{
				Class158.smethod_6(this.dataProviderLabel, this.dataProviderComboBox);
				Class158.smethod_6(this.dataSourceLabel_1, this.dataSourceListBox);
			}
		}

		protected override void OnHelpRequested(HelpEventArgs hevent)
		{
			Control control = Class157.smethod_4(this);
			Enum29 enum29_ = Enum29.const_1;
			if (control == this.dataSourceListBox)
			{
				enum29_ = Enum29.const_2;
			}
			if (control == this.dataProviderComboBox)
			{
				enum29_ = Enum29.const_3;
			}
			if (control == this.okButton)
			{
				enum29_ = Enum29.const_4;
			}
			if (control == this.cancelButton)
			{
				enum29_ = Enum29.const_5;
			}
			EventArgs0 eventArgs = new EventArgs0(enum29_, hevent.MousePos);
			this.databaseConnectionDialog_0.method_7(eventArgs);
			hevent.Handled = eventArgs.Handled;
			if (!eventArgs.Handled)
			{
				base.OnHelpRequested(hevent);
			}
		}

		protected override void WndProc(ref Message message)
		{
			if (this.databaseConnectionDialog_0.Boolean_0 && Class157.smethod_0(ref message))
			{
				Class157.smethod_3(this, ref message);
			}
			base.WndProc(ref message);
		}

		private void dataSourceListBox_Format(object sender, ListControlConvertEventArgs e)
		{
			if (e.DesiredType == typeof(string))
			{
				e.Value = (e.ListItem as Class154).String_1;
			}
		}

		private void dataSourceListBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			Class154 @class = this.dataSourceListBox.SelectedItem as Class154;
			this.dataProviderComboBox.Items.Clear();
			if (@class != null)
			{
				foreach (Class153 item in @class.Class155_0)
				{
					this.dataProviderComboBox.Items.Add(item);
				}
				if (!this.dictionary_0.ContainsKey(@class))
				{
					this.dictionary_0.Add(@class, @class.Class153_0);
				}
				this.dataProviderComboBox.SelectedItem = this.dictionary_0[@class];
			}
			else
			{
				this.dataProviderComboBox.Items.Add(string.Empty);
			}
			this.method_2();
			this.method_3();
		}

		private void dataSourceListBox_DoubleClick(object sender, EventArgs e)
		{
			if (this.okButton.Enabled)
			{
				base.DialogResult = DialogResult.OK;
				this.okButton_Click(sender, e);
				base.Close();
			}
		}

		private void dataProviderComboBox_Format(object sender, ListControlConvertEventArgs e)
		{
			if (e.DesiredType == typeof(string))
			{
				e.Value = ((e.ListItem is Class153) ? (e.ListItem as Class153).DisplayName : e.ListItem.ToString());
			}
		}

		private void dataProviderComboBox_DropDown(object sender, EventArgs e)
		{
			if (this.dataProviderComboBox.Items.Count > 0 && !(this.dataProviderComboBox.Items[0] is string))
			{
				int num = 0;
				using (Graphics dc = Graphics.FromHwnd(this.dataProviderComboBox.Handle))
				{
					foreach (Class153 item in this.dataProviderComboBox.Items)
					{
						int num2 = TextRenderer.MeasureText(dc, item.DisplayName, this.dataProviderComboBox.Font, new Size(int.MaxValue, int.MaxValue), TextFormatFlags.WordBreak).Width;
						if (num2 > num)
						{
							num = num2;
						}
					}
				}
				this.dataProviderComboBox.DropDownWidth = num + 3;
				if (this.dataProviderComboBox.Items.Count > this.dataProviderComboBox.MaxDropDownItems)
				{
					this.dataProviderComboBox.DropDownWidth += SystemInformation.VerticalScrollBarWidth;
				}
			}
			else
			{
				this.dataProviderComboBox.DropDownWidth = this.dataProviderComboBox.Width;
			}
		}

		private void dataProviderComboBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (this.dataSourceListBox.SelectedItem != null)
			{
				this.dictionary_0[this.dataSourceListBox.SelectedItem as Class154] = this.dataProviderComboBox.SelectedItem as Class153;
			}
			this.method_2();
			this.method_3();
		}

		private void descriptionLabel_Enter(object sender, EventArgs e)
		{
			this.dataSourceListBox.Focus();
		}

		private void method_2()
		{
			if (this.dataProviderComboBox.SelectedItem is Class153)
			{
				if (this.dataSourceListBox.SelectedItem == this.databaseConnectionDialog_0.Class154_0)
				{
					this.descriptionLabel.Text = (this.dataProviderComboBox.SelectedItem as Class153).Description;
				}
				else
				{
					this.descriptionLabel.Text = (this.dataProviderComboBox.SelectedItem as Class153).vmethod_0(this.dataSourceListBox.SelectedItem as Class154);
				}
			}
			else
			{
				this.descriptionLabel.Text = null;
			}
		}

		private void saveSelectionCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			this.databaseConnectionDialog_0.Boolean_1 = this.saveSelectionCheckBox.Checked;
		}

		private void method_3()
		{
			this.okButton.Enabled = this.dataSourceListBox.SelectedItem is Class154 && this.dataProviderComboBox.SelectedItem is Class153;
		}

		private void okButton_Click(object sender, EventArgs e)
		{
			this.databaseConnectionDialog_0.method_9(this.dataSourceListBox.SelectedItem as Class154);
			foreach (Class154 item in this.dataSourceListBox.Items)
			{
				Class153 class153_ = (this.dictionary_0.ContainsKey(item) ? this.dictionary_0[item] : null);
				this.databaseConnectionDialog_0.method_10(item, class153_);
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DocumentServer.Data.ConnectionUI.DatabaseConnectionSourceDialog));
			this.mainTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
			this.dataSourceLabel_1 = new System.Windows.Forms.Label();
			this.dataSourceListBox = new System.Windows.Forms.ListBox();
			this.descriptionGroupBox = new System.Windows.Forms.GroupBox();
			this.descriptionLabel = new System.Windows.Forms.RichTextBox();
			this.dataProviderLabel = new System.Windows.Forms.Label();
			this.dataProviderComboBox = new System.Windows.Forms.ComboBox();
			this.saveSelectionCheckBox = new System.Windows.Forms.CheckBox();
			this.okButton = new System.Windows.Forms.Button();
			this.cancelButton = new System.Windows.Forms.Button();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.mainTableLayoutPanel.SuspendLayout();
			this.descriptionGroupBox.SuspendLayout();
			this.tableLayoutPanel1.SuspendLayout();
			base.SuspendLayout();
			resources.ApplyResources(this.mainTableLayoutPanel, "mainTableLayoutPanel");
			this.tableLayoutPanel1.SetColumnSpan(this.mainTableLayoutPanel, 4);
			this.mainTableLayoutPanel.Controls.Add(this.dataSourceLabel_1, 0, 0);
			this.mainTableLayoutPanel.Controls.Add(this.dataSourceListBox, 0, 1);
			this.mainTableLayoutPanel.Controls.Add(this.descriptionGroupBox, 1, 0);
			this.mainTableLayoutPanel.Controls.Add(this.dataProviderLabel, 0, 2);
			this.mainTableLayoutPanel.Controls.Add(this.dataProviderComboBox, 0, 3);
			this.mainTableLayoutPanel.Name = "mainTableLayoutPanel";
			resources.ApplyResources(this.dataSourceLabel_1, "dataSourceLabel");
			this.dataSourceLabel_1.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.dataSourceLabel_1.Name = "dataSourceLabel";
			resources.ApplyResources(this.dataSourceListBox, "dataSourceListBox");
			this.dataSourceListBox.FormattingEnabled = true;
			this.dataSourceListBox.Name = "dataSourceListBox";
			this.dataSourceListBox.Sorted = true;
			this.dataSourceListBox.SelectedIndexChanged += new System.EventHandler(dataSourceListBox_SelectedIndexChanged);
			this.dataSourceListBox.Format += new System.Windows.Forms.ListControlConvertEventHandler(dataSourceListBox_Format);
			this.dataSourceListBox.DoubleClick += new System.EventHandler(dataSourceListBox_DoubleClick);
			resources.ApplyResources(this.descriptionGroupBox, "descriptionGroupBox");
			this.descriptionGroupBox.Controls.Add(this.descriptionLabel);
			this.descriptionGroupBox.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.descriptionGroupBox.Name = "descriptionGroupBox";
			this.mainTableLayoutPanel.SetRowSpan(this.descriptionGroupBox, 4);
			this.descriptionGroupBox.TabStop = false;
			this.descriptionLabel.BorderStyle = System.Windows.Forms.BorderStyle.None;
			resources.ApplyResources(this.descriptionLabel, "descriptionLabel");
			this.descriptionLabel.Name = "descriptionLabel";
			this.descriptionLabel.ReadOnly = true;
			this.descriptionLabel.TabStop = false;
			this.descriptionLabel.Enter += new System.EventHandler(descriptionLabel_Enter);
			resources.ApplyResources(this.dataProviderLabel, "dataProviderLabel");
			this.dataProviderLabel.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.dataProviderLabel.Name = "dataProviderLabel";
			resources.ApplyResources(this.dataProviderComboBox, "dataProviderComboBox");
			this.dataProviderComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.dataProviderComboBox.FormattingEnabled = true;
			this.dataProviderComboBox.Items.AddRange(new object[1] { resources.GetString("dataProviderComboBox.Items") });
			this.dataProviderComboBox.Name = "dataProviderComboBox";
			this.dataProviderComboBox.Sorted = true;
			this.dataProviderComboBox.DropDown += new System.EventHandler(dataProviderComboBox_DropDown);
			this.dataProviderComboBox.SelectedIndexChanged += new System.EventHandler(dataProviderComboBox_SelectedIndexChanged);
			this.dataProviderComboBox.Format += new System.Windows.Forms.ListControlConvertEventHandler(dataProviderComboBox_Format);
			resources.ApplyResources(this.saveSelectionCheckBox, "saveSelectionCheckBox");
			this.saveSelectionCheckBox.Name = "saveSelectionCheckBox";
			this.saveSelectionCheckBox.CheckedChanged += new System.EventHandler(saveSelectionCheckBox_CheckedChanged);
			resources.ApplyResources(this.okButton, "okButton");
			this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.okButton.Name = "okButton";
			this.okButton.Click += new System.EventHandler(okButton_Click);
			resources.ApplyResources(this.cancelButton, "cancelButton");
			this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cancelButton.Name = "cancelButton";
			resources.ApplyResources(this.tableLayoutPanel1, "tableLayoutPanel1");
			this.tableLayoutPanel1.Controls.Add(this.okButton, 2, 1);
			this.tableLayoutPanel1.Controls.Add(this.mainTableLayoutPanel, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.cancelButton, 3, 1);
			this.tableLayoutPanel1.Controls.Add(this.saveSelectionCheckBox, 0, 1);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			base.AcceptButton = this.okButton;
			resources.ApplyResources(this, "$this");
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.CancelButton = this.cancelButton;
			base.Controls.Add(this.tableLayoutPanel1);
			base.HelpButton = true;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "DatabaseConnectionSourceDialog";
			base.ShowIcon = false;
			base.ShowInTaskbar = false;
			this.mainTableLayoutPanel.ResumeLayout(false);
			this.mainTableLayoutPanel.PerformLayout();
			this.descriptionGroupBox.ResumeLayout(false);
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			base.ResumeLayout(false);
			base.PerformLayout();
		}
	}
}
