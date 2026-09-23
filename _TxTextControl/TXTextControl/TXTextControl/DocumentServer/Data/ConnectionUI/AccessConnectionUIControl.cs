using System;
using System.ComponentModel;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using ns16;
using DocumentServer.Properties;

namespace DocumentServer.Data.ConnectionUI
{
	[Obfuscation(Exclude = true)]
	internal class AccessConnectionUIControl : UserControl, IDataConnectionUIControl
	{
		private bool bool_0;

		private IDataConnectionProperties idataConnectionProperties_0;

		private IContainer icontainer_0;

		private Label databaseFileLabel;

		private TableLayoutPanel databaseFileTableLayoutPanel;

		private TextBox databaseFileTextBox;

		private System.Windows.Forms.Button browseButton;

		private GroupBox logonGroupBox;

		private TableLayoutPanel loginTableLayoutPanel;

		private Label userNameLabel;

		private TextBox userNameTextBox;

		private Label passwordLabel;

		private TextBox passwordTextBox;

		private CheckBox savePasswordCheckBox;

		private string String_0
		{
			get
			{
				if (!(this.IDataConnectionProperties_0 is Class145))
				{
					return "Data Source";
				}
				return "DBQ";
			}
		}

		private string String_1
		{
			get
			{
				if (!(this.IDataConnectionProperties_0 is Class145))
				{
					return "User ID";
				}
				return "UID";
			}
		}

		private string String_2
		{
			get
			{
				if (!(this.IDataConnectionProperties_0 is Class145))
				{
					return "Jet OLEDB:Database Password";
				}
				return "PWD";
			}
		}

		private IDataConnectionProperties IDataConnectionProperties_0 => this.idataConnectionProperties_0;

		public AccessConnectionUIControl()
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
			this.browseButton.Text = Resources.ACCESSCONNECTION_UICONTROL_BUTTON_BROWSE;
			this.databaseFileLabel.Text = Resources.ACCESSCONNECTION_UICONTROL_LABEL_DBFILENAME;
			this.logonGroupBox.Text = Resources.ACCESSCONNECTION_UICONTROL_GROUPBOX_LOGON;
			this.passwordLabel.Text = Resources.ACCESSCONNECTION_UICONTROL_LABEL_PASSWORD;
			this.savePasswordCheckBox.Text = Resources.ACCESSCONNECTION_UICONTROL_CHECKBOX_SAVE_PWD;
			this.userNameLabel.Text = Resources.ACCESSCONNECTION_UICONTROL_LABEL_USERNAME;
		}

		public void Initialize(IDataConnectionProperties connectionProperties)
		{
			if (connectionProperties == null)
			{
				throw new ArgumentNullException("connectionProperties");
			}
			if (!(connectionProperties is Class149))
			{
				throw new ArgumentException(Resources.ACCESSCONNECTION_UICONTROL_INVALID_CON_PROPS);
			}
			if (connectionProperties is Class145)
			{
				this.savePasswordCheckBox.Enabled = false;
			}
			this.idataConnectionProperties_0 = connectionProperties;
		}

		public void LoadProperties()
		{
			this.bool_0 = true;
			this.databaseFileTextBox.Text = this.IDataConnectionProperties_0[this.String_0] as string;
			this.userNameTextBox.Text = this.IDataConnectionProperties_0[this.String_1] as string;
			if (this.userNameTextBox.Text.Length == 0)
			{
				this.userNameTextBox.Text = "Admin";
			}
			this.passwordTextBox.Text = this.IDataConnectionProperties_0[this.String_2] as string;
			if (!(this.IDataConnectionProperties_0 is Class145))
			{
				this.savePasswordCheckBox.Checked = (bool)this.IDataConnectionProperties_0["Persist Security Info"];
			}
			else
			{
				this.savePasswordCheckBox.Checked = false;
			}
			this.bool_0 = false;
		}

		protected override void OnRightToLeftChanged(EventArgs eventArgs_0)
		{
			base.OnRightToLeftChanged(eventArgs_0);
			if (base.ParentForm != null && base.ParentForm.RightToLeftLayout && this.RightToLeft == RightToLeft.Yes)
			{
				Class158.smethod_4(this.databaseFileLabel, this.databaseFileTableLayoutPanel);
			}
			else
			{
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
				this.IDataConnectionProperties_0[this.String_0] = ((this.databaseFileTextBox.Text.Trim().Length > 0) ? this.databaseFileTextBox.Text.Trim() : null);
			}
		}

		private void browseButton_Click(object sender, EventArgs e)
		{
			OpenFileDialog openFileDialog = new OpenFileDialog();
			openFileDialog.Title = Resources.ACCESSCONNECTION_UICONTROL_BROWSEFILE_TITLE;
			openFileDialog.Multiselect = false;
			openFileDialog.RestoreDirectory = true;
			openFileDialog.Filter = Resources.ACCESSCONNECTION_UICONTROL_BROWSEFILE_FILTER;
			openFileDialog.DefaultExt = Resources.ACCESSCONNECTION_UICONTROL_BROWSEFILE_DEFAULT_EXT;
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

		private void userNameTextBox_TextChanged(object sender, EventArgs e)
		{
			if (!this.bool_0)
			{
				this.IDataConnectionProperties_0[this.String_1] = ((this.userNameTextBox.Text.Trim().Length > 0) ? this.userNameTextBox.Text.Trim() : null);
				if (this.IDataConnectionProperties_0[this.String_1] != null && this.IDataConnectionProperties_0[this.String_1].Equals("Admin"))
				{
					this.IDataConnectionProperties_0[this.String_1] = null;
				}
			}
		}

		private void passwordTextBox_TextChanged(object sender, EventArgs e)
		{
			if (!this.bool_0)
			{
				this.IDataConnectionProperties_0[this.String_2] = ((this.passwordTextBox.Text.Length > 0) ? this.passwordTextBox.Text : null);
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
			System.ComponentModel.ComponentResourceManager componentResourceManager = new System.ComponentModel.ComponentResourceManager(typeof(DocumentServer.Data.ConnectionUI.AccessConnectionUIControl));
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
			this.databaseFileTextBox.Leave += new System.EventHandler(userNameTextBox_Leave);
			this.databaseFileTextBox.TextChanged += new System.EventHandler(databaseFileTextBox_TextChanged);
			componentResourceManager.ApplyResources(this.browseButton, "browseButton");
			this.browseButton.Name = "browseButton";
			this.browseButton.Click += new System.EventHandler(browseButton_Click);
			componentResourceManager.ApplyResources(this.logonGroupBox, "logonGroupBox");
			this.logonGroupBox.Controls.Add(this.loginTableLayoutPanel);
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
			componentResourceManager.ApplyResources(this, "$this");
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.Controls.Add(this.logonGroupBox);
			base.Controls.Add(this.databaseFileTableLayoutPanel);
			base.Controls.Add(this.databaseFileLabel);
			this.MinimumSize = new System.Drawing.Size(300, 148);
			base.Name = "AccessConnectionUIControl";
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
