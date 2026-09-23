using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using ns16;
using DocumentServer.Properties;

namespace DocumentServer.Data.ConnectionUI
{
	[Obfuscation(Exclude = true)]
	internal class SqlFileConnectionUIControl : UserControl, IDataConnectionUIControl
	{
		private bool bool_0;

		private IDataConnectionProperties idataConnectionProperties_0;

		private IContainer icontainer_0;

		private Label databaseFileLabel;

		private TableLayoutPanel databaseFileTableLayoutPanel;

		private TextBox databaseFileTextBox;

		private System.Windows.Forms.Button browseButton;

		private GroupBox logonGroupBox;

		private RadioButton windowsAuthenticationRadioButton;

		private RadioButton sqlAuthenticationRadioButton;

		private TableLayoutPanel loginTableLayoutPanel;

		private Label userNameLabel;

		private TextBox userNameTextBox;

		private Label passwordLabel;

		private TextBox passwordTextBox;

		private CheckBox savePasswordCheckBox;

		private IDataConnectionProperties IDataConnectionProperties_0 => this.idataConnectionProperties_0;

		public SqlFileConnectionUIControl()
		{
			this.InitializeComponent();
			this.RightToLeft = RightToLeft.Inherit;
			int num = Class158.smethod_2(this.savePasswordCheckBox);
			if (this.savePasswordCheckBox.Height < num)
			{
				this.savePasswordCheckBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
				this.loginTableLayoutPanel.Height += this.loginTableLayoutPanel.Margin.Bottom;
				this.loginTableLayoutPanel.Margin = new Padding(this.loginTableLayoutPanel.Margin.Left, this.loginTableLayoutPanel.Margin.Top, this.loginTableLayoutPanel.Margin.Right, 0);
			}
			this.browseButton.Text = Resources.SQLEXPRESSCONNECTION_UICONTROL_BUTTON_BROWSE;
			this.databaseFileLabel.Text = Resources.SQLEXPRESSCONNECTION_UICONTROL_LABEL_DBFILE;
			this.logonGroupBox.Text = Resources.SQLEXPRESSCONNECTION_UICONTROL_GROUPBOX_LOGON;
			this.passwordLabel.Text = Resources.SQLEXPRESSCONNECTION_UICONTROL_LABEL_PASSWORD;
			this.savePasswordCheckBox.Text = Resources.SQLEXPRESSCONNECTION_UICONTROL_CHECKBOX_SAVE_PWD;
			this.sqlAuthenticationRadioButton.Text = Resources.SQLEXPRESSCONNECTION_UICONTROL_RADIO_SQL_AUTH;
			this.userNameLabel.Text = Resources.SQLEXPRESSCONNECTION_UICONTROL_LABEL_USERNAME;
			this.windowsAuthenticationRadioButton.Text = Resources.SQLEXPRESSCONNECTION_UICONTROL_RADIO_WINDOWS_AUTH;
		}

		public void Initialize(IDataConnectionProperties connectionProperties)
		{
			if (!(connectionProperties is Class151))
			{
				throw new ArgumentException(Resources.SQLFILECONNECTION_UICONTROL_INVALID_CONNECTION_PROPERTIES);
			}
			this.idataConnectionProperties_0 = connectionProperties;
		}

		public void LoadProperties()
		{
			this.bool_0 = true;
			this.databaseFileTextBox.Text = this.IDataConnectionProperties_0["AttachDbFilename"] as string;
			string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
			if (this.databaseFileTextBox.Text.StartsWith(folderPath, StringComparison.OrdinalIgnoreCase))
			{
				this.databaseFileTextBox.Text = this.databaseFileTextBox.Text.Substring(folderPath.Length + 1);
			}
			if ((bool)this.IDataConnectionProperties_0["Integrated Security"])
			{
				this.windowsAuthenticationRadioButton.Checked = true;
			}
			else
			{
				this.sqlAuthenticationRadioButton.Checked = true;
			}
			this.userNameTextBox.Text = this.IDataConnectionProperties_0["User ID"] as string;
			this.passwordTextBox.Text = this.IDataConnectionProperties_0["Password"] as string;
			this.savePasswordCheckBox.Checked = (bool)this.IDataConnectionProperties_0["Persist Security Info"];
			this.bool_0 = false;
		}

		protected override void OnRightToLeftChanged(EventArgs eventArgs_0)
		{
			base.OnRightToLeftChanged(eventArgs_0);
			if (base.ParentForm != null && base.ParentForm.RightToLeftLayout && this.RightToLeft == RightToLeft.Yes)
			{
				Class158.smethod_4(this.databaseFileLabel, this.databaseFileTableLayoutPanel);
				Class158.smethod_3(this.windowsAuthenticationRadioButton);
				Class158.smethod_3(this.sqlAuthenticationRadioButton);
				Class158.smethod_3(this.loginTableLayoutPanel);
			}
			else
			{
				Class158.smethod_5(this.loginTableLayoutPanel);
				Class158.smethod_5(this.sqlAuthenticationRadioButton);
				Class158.smethod_5(this.windowsAuthenticationRadioButton);
				Class158.smethod_6(this.databaseFileLabel, this.databaseFileTableLayoutPanel);
			}
		}

		protected override void ScaleControl(SizeF factor, BoundsSpecified specified)
		{
			Size size = base.Size;
			this.MinimumSize = Size.Empty;
			base.ScaleControl(factor, specified);
			this.MinimumSize = new Size((int)Math.Round((float)size.Width * factor.Width), (int)Math.Round((float)size.Height * factor.Height));
		}

		protected override void OnParentChanged(EventArgs eventArgs_0)
		{
			base.OnParentChanged(eventArgs_0);
			if (base.Parent == null)
			{
				this.OnFontChanged(eventArgs_0);
			}
		}

		private void databaseFileTextBox_TextChanged(object sender, EventArgs e)
		{
			if (!this.bool_0)
			{
				this.IDataConnectionProperties_0["AttachDbFilename"] = ((this.databaseFileTextBox.Text.Trim().Length > 0) ? this.databaseFileTextBox.Text.Trim() : null);
			}
		}

		private void databaseFileTextBox_Leave(object sender, EventArgs e)
		{
			if (this.bool_0)
			{
				return;
			}
			string text = ((this.databaseFileTextBox.Text.Trim().Length > 0) ? this.databaseFileTextBox.Text.Trim() : null);
			if (text != null)
			{
				if (!text.EndsWith(".mdf", StringComparison.OrdinalIgnoreCase))
				{
					text += ".mdf";
				}
				try
				{
					if (!Path.IsPathRooted(text))
					{
						text = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), text);
					}
				}
				catch
				{
				}
			}
			this.IDataConnectionProperties_0["AttachDbFilename"] = text;
		}

		private void browseButton_Click(object sender, EventArgs e)
		{
			OpenFileDialog openFileDialog = new OpenFileDialog();
			openFileDialog.Title = Resources.SQLCONNECTION_UICONTROL_BROWSE_FILE_TITLE;
			openFileDialog.Multiselect = false;
			openFileDialog.CheckFileExists = false;
			openFileDialog.RestoreDirectory = true;
			openFileDialog.Filter = Resources.SQLCONNECTION_UICONTROL_BROWSE_FILE_FILTER;
			openFileDialog.DefaultExt = Resources.SQLCONNECTION_UICONTROL_BROWSE_FILE_DEFAULT_EXT;
			openFileDialog.FileName = this.IDataConnectionProperties_0["AttachDbFilename"] as string;
			if (base.Container != null)
			{
				base.Container.Add(openFileDialog);
			}
			try
			{
				if (openFileDialog.ShowDialog(base.ParentForm) == DialogResult.OK)
				{
					this.databaseFileTextBox.Text = openFileDialog.FileName.Trim();
				}
			}
			finally
			{
				if (base.Container != null)
				{
					base.Container.Remove(openFileDialog);
				}
				openFileDialog.Dispose();
			}
		}

		private void windowsAuthenticationRadioButton_CheckedChanged(object sender, EventArgs e)
		{
			if (this.windowsAuthenticationRadioButton.Checked)
			{
				if (!this.bool_0)
				{
					this.IDataConnectionProperties_0["Integrated Security"] = true;
					this.IDataConnectionProperties_0.Reset("User ID");
					this.IDataConnectionProperties_0.Reset("Password");
					this.IDataConnectionProperties_0.Reset("Persist Security Info");
				}
				this.loginTableLayoutPanel.Enabled = false;
			}
			else
			{
				if (!this.bool_0)
				{
					this.IDataConnectionProperties_0["Integrated Security"] = false;
					this.userNameTextBox_TextChanged(sender, e);
					this.passwordTextBox_TextChanged(sender, e);
					this.savePasswordCheckBox_CheckedChanged(sender, e);
				}
				this.loginTableLayoutPanel.Enabled = true;
			}
		}

		private void userNameTextBox_TextChanged(object sender, EventArgs e)
		{
			if (!this.bool_0)
			{
				this.IDataConnectionProperties_0["User ID"] = ((this.userNameTextBox.Text.Trim().Length > 0) ? this.userNameTextBox.Text.Trim() : null);
			}
		}

		private void passwordTextBox_TextChanged(object sender, EventArgs e)
		{
			if (!this.bool_0)
			{
				this.IDataConnectionProperties_0["Password"] = ((this.passwordTextBox.Text.Length > 0) ? this.passwordTextBox.Text : null);
				this.passwordTextBox.Text = this.passwordTextBox.Text;
			}
		}

		private void savePasswordCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			if (!this.bool_0)
			{
				this.IDataConnectionProperties_0["Persist Security Info"] = this.savePasswordCheckBox.Checked;
			}
		}

		private void userNameTextBox_Leave(object sender, EventArgs e)
		{
			Control obj = sender as Control;
			obj.Text = obj.Text.Trim();
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
			System.ComponentModel.ComponentResourceManager componentResourceManager = new System.ComponentModel.ComponentResourceManager(typeof(DocumentServer.Data.ConnectionUI.SqlFileConnectionUIControl));
			this.databaseFileLabel = new System.Windows.Forms.Label();
			this.databaseFileTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
			this.databaseFileTextBox = new System.Windows.Forms.TextBox();
			this.browseButton = new System.Windows.Forms.Button();
			this.logonGroupBox = new System.Windows.Forms.GroupBox();
			this.loginTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
			this.userNameLabel = new System.Windows.Forms.Label();
			this.userNameTextBox = new System.Windows.Forms.TextBox();
			this.passwordLabel = new System.Windows.Forms.Label();
			this.passwordTextBox = new System.Windows.Forms.TextBox();
			this.savePasswordCheckBox = new System.Windows.Forms.CheckBox();
			this.sqlAuthenticationRadioButton = new System.Windows.Forms.RadioButton();
			this.windowsAuthenticationRadioButton = new System.Windows.Forms.RadioButton();
			this.databaseFileTableLayoutPanel.SuspendLayout();
			this.logonGroupBox.SuspendLayout();
			this.loginTableLayoutPanel.SuspendLayout();
			base.SuspendLayout();
			componentResourceManager.ApplyResources(this.databaseFileLabel, "databaseFileLabel");
			this.databaseFileLabel.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.databaseFileLabel.Name = "databaseFileLabel";
			componentResourceManager.ApplyResources(this.databaseFileTableLayoutPanel, "databaseFileTableLayoutPanel");
			this.databaseFileTableLayoutPanel.Controls.Add(this.databaseFileTextBox, 0, 0);
			this.databaseFileTableLayoutPanel.Controls.Add(this.browseButton, 1, 0);
			this.databaseFileTableLayoutPanel.Name = "databaseFileTableLayoutPanel";
			componentResourceManager.ApplyResources(this.databaseFileTextBox, "databaseFileTextBox");
			this.databaseFileTextBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			this.databaseFileTextBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.FileSystem;
			this.databaseFileTextBox.Name = "databaseFileTextBox";
			this.databaseFileTextBox.Leave += new System.EventHandler(databaseFileTextBox_Leave);
			this.databaseFileTextBox.TextChanged += new System.EventHandler(databaseFileTextBox_TextChanged);
			componentResourceManager.ApplyResources(this.browseButton, "browseButton");
			this.browseButton.Name = "browseButton";
			this.browseButton.Click += new System.EventHandler(browseButton_Click);
			componentResourceManager.ApplyResources(this.logonGroupBox, "logonGroupBox");
			this.logonGroupBox.Controls.Add(this.loginTableLayoutPanel);
			this.logonGroupBox.Controls.Add(this.sqlAuthenticationRadioButton);
			this.logonGroupBox.Controls.Add(this.windowsAuthenticationRadioButton);
			this.logonGroupBox.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.logonGroupBox.Name = "logonGroupBox";
			this.logonGroupBox.TabStop = false;
			componentResourceManager.ApplyResources(this.loginTableLayoutPanel, "loginTableLayoutPanel");
			this.loginTableLayoutPanel.Controls.Add(this.userNameLabel, 0, 0);
			this.loginTableLayoutPanel.Controls.Add(this.userNameTextBox, 1, 0);
			this.loginTableLayoutPanel.Controls.Add(this.passwordLabel, 0, 1);
			this.loginTableLayoutPanel.Controls.Add(this.passwordTextBox, 1, 1);
			this.loginTableLayoutPanel.Controls.Add(this.savePasswordCheckBox, 1, 2);
			this.loginTableLayoutPanel.Name = "loginTableLayoutPanel";
			componentResourceManager.ApplyResources(this.userNameLabel, "userNameLabel");
			this.userNameLabel.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.userNameLabel.Name = "userNameLabel";
			componentResourceManager.ApplyResources(this.userNameTextBox, "userNameTextBox");
			this.userNameTextBox.Name = "userNameTextBox";
			this.userNameTextBox.Leave += new System.EventHandler(userNameTextBox_Leave);
			this.userNameTextBox.TextChanged += new System.EventHandler(userNameTextBox_TextChanged);
			componentResourceManager.ApplyResources(this.passwordLabel, "passwordLabel");
			this.passwordLabel.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.passwordLabel.Name = "passwordLabel";
			componentResourceManager.ApplyResources(this.passwordTextBox, "passwordTextBox");
			this.passwordTextBox.Name = "passwordTextBox";
			this.passwordTextBox.UseSystemPasswordChar = true;
			this.passwordTextBox.TextChanged += new System.EventHandler(passwordTextBox_TextChanged);
			componentResourceManager.ApplyResources(this.savePasswordCheckBox, "savePasswordCheckBox");
			this.savePasswordCheckBox.Name = "savePasswordCheckBox";
			this.savePasswordCheckBox.CheckedChanged += new System.EventHandler(savePasswordCheckBox_CheckedChanged);
			componentResourceManager.ApplyResources(this.sqlAuthenticationRadioButton, "sqlAuthenticationRadioButton");
			this.sqlAuthenticationRadioButton.Name = "sqlAuthenticationRadioButton";
			this.sqlAuthenticationRadioButton.CheckedChanged += new System.EventHandler(windowsAuthenticationRadioButton_CheckedChanged);
			componentResourceManager.ApplyResources(this.windowsAuthenticationRadioButton, "windowsAuthenticationRadioButton");
			this.windowsAuthenticationRadioButton.Name = "windowsAuthenticationRadioButton";
			this.windowsAuthenticationRadioButton.CheckedChanged += new System.EventHandler(windowsAuthenticationRadioButton_CheckedChanged);
			componentResourceManager.ApplyResources(this, "$this");
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.Controls.Add(this.logonGroupBox);
			base.Controls.Add(this.databaseFileTableLayoutPanel);
			base.Controls.Add(this.databaseFileLabel);
			this.MinimumSize = new System.Drawing.Size(300, 191);
			base.Name = "SqlFileConnectionUIControl";
			this.databaseFileTableLayoutPanel.ResumeLayout(false);
			this.databaseFileTableLayoutPanel.PerformLayout();
			this.logonGroupBox.ResumeLayout(false);
			this.logonGroupBox.PerformLayout();
			this.loginTableLayoutPanel.ResumeLayout(false);
			this.loginTableLayoutPanel.PerformLayout();
			base.ResumeLayout(false);
			base.PerformLayout();
		}
	}
}
