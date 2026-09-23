using System;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Globalization;
using System.Reflection;
using System.Security.Permissions;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using ns16;
using DocumentServer.Properties;

namespace DocumentServer.Data.ConnectionUI
{
	[Obfuscation(Exclude = true)]
	internal class OdbcConnectionUIControl : UserControl, IDataConnectionUIControl
	{
		private bool bool_0;

		private object[] object_0;

		private Thread thread_0;

		private IDataConnectionProperties idataConnectionProperties_0;

		private IContainer icontainer_0;

		private GroupBox dataSourceGroupBox;

		private RadioButton useDataSourceNameRadioButton;

		private TableLayoutPanel dataSourceNameTableLayoutPanel;

		private ComboBox dataSourceNameComboBox;

		private System.Windows.Forms.Button refreshButton;

		private RadioButton useConnectionStringRadioButton;

		private TableLayoutPanel connectionStringTableLayoutPanel;

		private TextBox connectionStringTextBox;

		private System.Windows.Forms.Button buildButton;

		private GroupBox loginGroupBox;

		private TableLayoutPanel loginTableLayoutPanel;

		private Label userNameLabel;

		private TextBox userNameTextBox;

		private Label passwordLabel;

		private TextBox passwordTextBox;

		private IDataConnectionProperties IDataConnectionProperties_0 => this.idataConnectionProperties_0;

		public OdbcConnectionUIControl()
		{
			this.InitializeComponent();
			this.RightToLeft = RightToLeft.Inherit;
			this.dataSourceNameComboBox.AccessibleName = OdbcConnectionUIControl.smethod_0(this.useDataSourceNameRadioButton.Text);
			this.connectionStringTextBox.AccessibleName = OdbcConnectionUIControl.smethod_0(this.useConnectionStringRadioButton.Text);
			this.thread_0 = Thread.CurrentThread;
			this.buildButton.Text = Resources.ODBCCONNECTION_UICONTROL_BUTTON_BUILD;
			this.dataSourceGroupBox.Text = Resources.ODBCCONNECTION_UICONTROL_GROUPBOX_DATASOURCE;
			this.loginGroupBox.Text = Resources.ODBCCONNECTION_UICONTROL_GROUPBOX_LOGIN;
			this.passwordLabel.Text = Resources.ODBCCONNECTION_UICONTROL_LABEL_PASSWORD;
			this.refreshButton.Text = Resources.ODBCCONNECTION_UICONTROL_BUTTON_REFRESH;
			this.useConnectionStringRadioButton.Text = Resources.ODBCCONNECTION_UICONTROL_RADIO_USE_CONNECTION_STRING;
			this.useDataSourceNameRadioButton.Text = Resources.ODBCCONNECTION_UICONTROL_RADIO_USE_DATASOURCE_NAME;
			this.userNameLabel.Text = Resources.ODBCCONNECTION_UICONTROL_LABEL_USERNAME;
		}

		public void Initialize(IDataConnectionProperties connectionProperties)
		{
			if (!(connectionProperties is Class145))
			{
				throw new ArgumentException(Resources.ODBCCONNECTION_UICONTROL_INVALID_CONNECTION_PROPS);
			}
			this.idataConnectionProperties_0 = connectionProperties;
		}

		public void LoadProperties()
		{
			this.bool_0 = true;
			this.method_2();
			if (this.IDataConnectionProperties_0.ToFullString().Length != 0 && (!(this.IDataConnectionProperties_0["Dsn"] is string) || (this.IDataConnectionProperties_0["Dsn"] as string).Length <= 0))
			{
				this.useConnectionStringRadioButton.Checked = true;
			}
			else
			{
				this.useDataSourceNameRadioButton.Checked = true;
			}
			this.method_1();
			this.bool_0 = false;
		}

		protected override void OnRightToLeftChanged(EventArgs eventArgs_0)
		{
			base.OnRightToLeftChanged(eventArgs_0);
			if (base.ParentForm != null && base.ParentForm.RightToLeftLayout && this.RightToLeft == RightToLeft.Yes)
			{
				Class158.smethod_3(this.useDataSourceNameRadioButton);
				Class158.smethod_3(this.dataSourceNameTableLayoutPanel);
				Class158.smethod_3(this.useConnectionStringRadioButton);
				Class158.smethod_3(this.connectionStringTableLayoutPanel);
			}
			else
			{
				Class158.smethod_5(this.connectionStringTableLayoutPanel);
				Class158.smethod_5(this.useConnectionStringRadioButton);
				Class158.smethod_5(this.dataSourceNameTableLayoutPanel);
				Class158.smethod_5(this.useDataSourceNameRadioButton);
			}
		}

		protected override void ScaleControl(SizeF factor, BoundsSpecified specified)
		{
			Size size = base.Size;
			this.MinimumSize = Size.Empty;
			base.ScaleControl(factor, specified);
			this.MinimumSize = new Size((int)Math.Round((float)size.Width * factor.Width), (int)Math.Round((float)size.Height * factor.Height));
		}

		[UIPermission(SecurityAction.LinkDemand, Window = UIPermissionWindow.AllWindows)]
		protected override bool ProcessDialogKey(Keys keyData)
		{
			if (base.ActiveControl == this.useDataSourceNameRadioButton && (keyData & Keys.KeyCode) == Keys.Down)
			{
				this.useConnectionStringRadioButton.Focus();
				return true;
			}
			if (base.ActiveControl == this.useConnectionStringRadioButton && (keyData & Keys.KeyCode) == Keys.Down)
			{
				this.useDataSourceNameRadioButton.Focus();
				return true;
			}
			return base.ProcessDialogKey(keyData);
		}

		protected override void OnParentChanged(EventArgs eventArgs_0)
		{
			base.OnParentChanged(eventArgs_0);
			if (base.Parent == null)
			{
				this.OnFontChanged(eventArgs_0);
			}
		}

		private void useDataSourceNameRadioButton_CheckedChanged(object sender, EventArgs e)
		{
			if (this.useDataSourceNameRadioButton.Checked)
			{
				this.dataSourceNameTableLayoutPanel.Enabled = true;
				if (!this.bool_0)
				{
					string value = this.IDataConnectionProperties_0["Dsn"] as string;
					string value2 = (this.IDataConnectionProperties_0.Contains("uid") ? (this.IDataConnectionProperties_0["uid"] as string) : null);
					string value3 = (this.IDataConnectionProperties_0.Contains("pwd") ? (this.IDataConnectionProperties_0["pwd"] as string) : null);
					this.IDataConnectionProperties_0.Parse(string.Empty);
					this.IDataConnectionProperties_0["Dsn"] = value;
					this.IDataConnectionProperties_0["uid"] = value2;
					this.IDataConnectionProperties_0["pwd"] = value3;
				}
				this.method_1();
				this.connectionStringTableLayoutPanel.Enabled = false;
			}
			else
			{
				this.dataSourceNameTableLayoutPanel.Enabled = false;
				if (!this.bool_0)
				{
					string value4 = this.IDataConnectionProperties_0["Dsn"] as string;
					string value5 = (this.IDataConnectionProperties_0.Contains("uid") ? (this.IDataConnectionProperties_0["uid"] as string) : null);
					string value6 = (this.IDataConnectionProperties_0.Contains("pwd") ? (this.IDataConnectionProperties_0["pwd"] as string) : null);
					this.IDataConnectionProperties_0.Parse(this.connectionStringTextBox.Text);
					this.IDataConnectionProperties_0["Dsn"] = value4;
					this.IDataConnectionProperties_0["uid"] = value5;
					this.IDataConnectionProperties_0["pwd"] = value6;
				}
				this.method_1();
				this.connectionStringTableLayoutPanel.Enabled = true;
			}
		}

		private void dataSourceNameComboBox_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Down)
			{
				this.dataSourceNameComboBox_DropDown(sender, e);
			}
		}

		private void dataSourceNameComboBox_DropDown(object sender, EventArgs e)
		{
			if (this.dataSourceNameComboBox.Items.Count == 0)
			{
				Cursor current = Cursor.Current;
				Cursor.Current = Cursors.WaitCursor;
				try
				{
					this.method_2();
				}
				finally
				{
					Cursor.Current = current;
				}
			}
		}

		private void dataSourceNameComboBox_Leave(object sender, EventArgs e)
		{
			if (!this.bool_0)
			{
				this.IDataConnectionProperties_0["Dsn"] = ((this.dataSourceNameComboBox.Text.Length > 0) ? this.dataSourceNameComboBox.Text : null);
			}
			this.method_1();
		}

		private void refreshButton_Click(object sender, EventArgs e)
		{
			this.dataSourceNameComboBox.Items.Clear();
			this.dataSourceNameComboBox_DropDown(sender, e);
		}

		private void connectionStringTextBox_Leave(object sender, EventArgs e)
		{
			if (!this.bool_0)
			{
				string text = (this.IDataConnectionProperties_0.Contains("pwd") ? (this.IDataConnectionProperties_0["pwd"] as string) : null);
				try
				{
					this.IDataConnectionProperties_0.Parse(this.connectionStringTextBox.Text.Trim());
				}
				catch (ArgumentException ex)
				{
					IUIService iUIService = null;
					if (base.ParentForm != null && base.ParentForm.Site != null)
					{
						iUIService = base.ParentForm.Site.GetService(typeof(IUIService)) as IUIService;
					}
					if (iUIService != null)
					{
						iUIService.ShowError(ex);
					}
					else
					{
						Class163.smethod_0(null, ex.Message, MessageBoxIcon.Exclamation);
					}
				}
				if (this.connectionStringTextBox.Text.Trim().Length > 0 && !this.IDataConnectionProperties_0.Contains("pwd") && text != null)
				{
					this.IDataConnectionProperties_0["pwd"] = text;
				}
				this.connectionStringTextBox.Text = this.IDataConnectionProperties_0.ToDisplayString();
			}
			this.method_1();
		}

		private void buildButton_Click(object sender, EventArgs e)
		{
			IntPtr intptr_ = IntPtr.Zero;
			IntPtr intptr_2 = IntPtr.Zero;
			short num = 0;
			try
			{
				num = Class159.SQLAllocEnv(out intptr_);
				if (!Class159.smethod_0(num))
				{
					throw new ApplicationException(Resources.ODBCCONNECTION_UICONTROL_SQL_ALLOC_ENV_FAILED);
				}
				num = Class159.SQLAllocConnect(intptr_, out intptr_2);
				if (!Class159.smethod_0(num))
				{
					throw new ApplicationException(Resources.ODBCCONNECTION_UICONTROL_SQL_ALLOC_CONNECT_FAILED);
				}
				string text = this.IDataConnectionProperties_0.ToFullString();
				StringBuilder stringBuilder = new StringBuilder(1024);
				short short_ = 0;
				num = Class159.SQLDriverConnectW(intptr_2, base.ParentForm.Handle, text, (short)text.Length, stringBuilder, 1024, out short_, 2);
				if (!Class159.smethod_0(num) && num != 100)
				{
					num = Class159.SQLDriverConnectW(intptr_2, base.ParentForm.Handle, null, 0, stringBuilder, 1024, out short_, 2);
				}
				if (!Class159.smethod_0(num) && num != 100)
				{
					throw new ApplicationException(Resources.ODBCCONNECTION_UICONTROL_SQL_DRIVER_CONNECT_FAILED);
				}
				Class159.SQLDisconnect(intptr_2);
				if (short_ > 0)
				{
					this.refreshButton_Click(sender, e);
					this.IDataConnectionProperties_0.Parse(stringBuilder.ToString());
					this.method_1();
				}
			}
			finally
			{
				if (intptr_2 != IntPtr.Zero)
				{
					Class159.SQLFreeConnect(intptr_2);
				}
				if (intptr_ != IntPtr.Zero)
				{
					Class159.SQLFreeEnv(intptr_);
				}
			}
		}

		private void userNameTextBox_Leave(object sender, EventArgs e)
		{
			if (!this.bool_0)
			{
				this.IDataConnectionProperties_0["uid"] = ((this.userNameTextBox.Text.Trim().Length > 0) ? this.userNameTextBox.Text.Trim() : null);
			}
			this.method_1();
		}

		private void passwordTextBox_Leave(object sender, EventArgs e)
		{
			if (!this.bool_0)
			{
				this.IDataConnectionProperties_0["pwd"] = ((this.passwordTextBox.Text.Length > 0) ? this.passwordTextBox.Text : null);
				this.passwordTextBox.Text = this.passwordTextBox.Text;
			}
			this.method_1();
		}

		private void method_0(object sender, EventArgs e)
		{
			Control obj = sender as Control;
			obj.Text = obj.Text.Trim();
			this.method_1();
		}

		private void method_1()
		{
			if (this.IDataConnectionProperties_0["Dsn"] is string && (this.IDataConnectionProperties_0["Dsn"] as string).Length > 0 && this.dataSourceNameComboBox.Items.Contains(this.IDataConnectionProperties_0["Dsn"]))
			{
				this.dataSourceNameComboBox.Text = this.IDataConnectionProperties_0["Dsn"] as string;
			}
			else
			{
				this.dataSourceNameComboBox.Text = null;
			}
			this.connectionStringTextBox.Text = this.IDataConnectionProperties_0.ToDisplayString();
			if (this.IDataConnectionProperties_0.Contains("uid"))
			{
				this.userNameTextBox.Text = this.IDataConnectionProperties_0["uid"] as string;
			}
			else
			{
				this.userNameTextBox.Text = null;
			}
			if (this.IDataConnectionProperties_0.Contains("pwd"))
			{
				this.passwordTextBox.Text = this.IDataConnectionProperties_0["pwd"] as string;
			}
			else
			{
				this.passwordTextBox.Text = null;
			}
		}

		private void method_2()
		{
			DataTable dataTable = new DataTable();
			dataTable.Locale = CultureInfo.InvariantCulture;
			try
			{
				OleDbDataReader enumerator = OleDbEnumerator.GetEnumerator(Type.GetTypeFromCLSID(Class159.guid_3));
				using (enumerator)
				{
					dataTable.Load(enumerator);
				}
			}
			catch
			{
			}
			this.object_0 = new object[dataTable.Rows.Count];
			for (int i = 0; i < this.object_0.Length; i++)
			{
				this.object_0[i] = dataTable.Rows[i]["SOURCES_NAME"] as string;
			}
			Array.Sort(this.object_0);
			if (Thread.CurrentThread == this.thread_0)
			{
				this.method_3();
			}
			else if (base.IsHandleCreated)
			{
				base.BeginInvoke(new ThreadStart(method_3));
			}
		}

		private void method_3()
		{
			if (this.dataSourceNameComboBox.Items.Count == 0)
			{
				if (this.object_0.Length != 0)
				{
					this.dataSourceNameComboBox.Items.AddRange(this.object_0);
				}
				else
				{
					this.dataSourceNameComboBox.Items.Add(string.Empty);
				}
			}
		}

		private static string smethod_0(string string_0)
		{
			if (string_0 == null)
			{
				return null;
			}
			int i = string_0.IndexOf('&');
			if (i == -1)
			{
				return string_0;
			}
			StringBuilder stringBuilder = new StringBuilder(string_0.Substring(0, i));
			for (; i < string_0.Length; i++)
			{
				if (string_0[i] == '&')
				{
					i++;
				}
				if (i < string_0.Length)
				{
					stringBuilder.Append(string_0[i]);
				}
			}
			return stringBuilder.ToString();
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
			System.ComponentModel.ComponentResourceManager componentResourceManager = new System.ComponentModel.ComponentResourceManager(typeof(DocumentServer.Data.ConnectionUI.OdbcConnectionUIControl));
			this.dataSourceGroupBox = new System.Windows.Forms.GroupBox();
			this.connectionStringTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
			this.connectionStringTextBox = new System.Windows.Forms.TextBox();
			this.buildButton = new System.Windows.Forms.Button();
			this.useConnectionStringRadioButton = new System.Windows.Forms.RadioButton();
			this.dataSourceNameTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
			this.dataSourceNameComboBox = new System.Windows.Forms.ComboBox();
			this.refreshButton = new System.Windows.Forms.Button();
			this.useDataSourceNameRadioButton = new System.Windows.Forms.RadioButton();
			this.loginGroupBox = new System.Windows.Forms.GroupBox();
			this.loginTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
			this.userNameLabel = new System.Windows.Forms.Label();
			this.userNameTextBox = new System.Windows.Forms.TextBox();
			this.passwordLabel = new System.Windows.Forms.Label();
			this.passwordTextBox = new System.Windows.Forms.TextBox();
			this.dataSourceGroupBox.SuspendLayout();
			this.connectionStringTableLayoutPanel.SuspendLayout();
			this.dataSourceNameTableLayoutPanel.SuspendLayout();
			this.loginGroupBox.SuspendLayout();
			this.loginTableLayoutPanel.SuspendLayout();
			base.SuspendLayout();
			componentResourceManager.ApplyResources(this.dataSourceGroupBox, "dataSourceGroupBox");
			this.dataSourceGroupBox.Controls.Add(this.connectionStringTableLayoutPanel);
			this.dataSourceGroupBox.Controls.Add(this.useConnectionStringRadioButton);
			this.dataSourceGroupBox.Controls.Add(this.dataSourceNameTableLayoutPanel);
			this.dataSourceGroupBox.Controls.Add(this.useDataSourceNameRadioButton);
			this.dataSourceGroupBox.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.dataSourceGroupBox.Name = "dataSourceGroupBox";
			this.dataSourceGroupBox.TabStop = false;
			componentResourceManager.ApplyResources(this.connectionStringTableLayoutPanel, "connectionStringTableLayoutPanel");
			this.connectionStringTableLayoutPanel.Controls.Add(this.connectionStringTextBox, 0, 0);
			this.connectionStringTableLayoutPanel.Controls.Add(this.buildButton, 1, 0);
			this.connectionStringTableLayoutPanel.Name = "connectionStringTableLayoutPanel";
			componentResourceManager.ApplyResources(this.connectionStringTextBox, "connectionStringTextBox");
			this.connectionStringTextBox.Name = "connectionStringTextBox";
			this.connectionStringTextBox.Leave += new System.EventHandler(connectionStringTextBox_Leave);
			componentResourceManager.ApplyResources(this.buildButton, "buildButton");
			this.buildButton.Name = "buildButton";
			this.buildButton.Click += new System.EventHandler(buildButton_Click);
			componentResourceManager.ApplyResources(this.useConnectionStringRadioButton, "useConnectionStringRadioButton");
			this.useConnectionStringRadioButton.Name = "useConnectionStringRadioButton";
			this.useConnectionStringRadioButton.CheckedChanged += new System.EventHandler(useDataSourceNameRadioButton_CheckedChanged);
			componentResourceManager.ApplyResources(this.dataSourceNameTableLayoutPanel, "dataSourceNameTableLayoutPanel");
			this.dataSourceNameTableLayoutPanel.Controls.Add(this.dataSourceNameComboBox, 0, 0);
			this.dataSourceNameTableLayoutPanel.Controls.Add(this.refreshButton, 1, 0);
			this.dataSourceNameTableLayoutPanel.Name = "dataSourceNameTableLayoutPanel";
			componentResourceManager.ApplyResources(this.dataSourceNameComboBox, "dataSourceNameComboBox");
			this.dataSourceNameComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
			this.dataSourceNameComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
			this.dataSourceNameComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.dataSourceNameComboBox.FormattingEnabled = true;
			this.dataSourceNameComboBox.Name = "dataSourceNameComboBox";
			this.dataSourceNameComboBox.DropDown += new System.EventHandler(dataSourceNameComboBox_DropDown);
			this.dataSourceNameComboBox.SelectedIndexChanged += new System.EventHandler(dataSourceNameComboBox_Leave);
			this.dataSourceNameComboBox.KeyDown += new System.Windows.Forms.KeyEventHandler(dataSourceNameComboBox_KeyDown);
			this.dataSourceNameComboBox.Leave += new System.EventHandler(dataSourceNameComboBox_Leave);
			componentResourceManager.ApplyResources(this.refreshButton, "refreshButton");
			this.refreshButton.Name = "refreshButton";
			this.refreshButton.Click += new System.EventHandler(refreshButton_Click);
			componentResourceManager.ApplyResources(this.useDataSourceNameRadioButton, "useDataSourceNameRadioButton");
			this.useDataSourceNameRadioButton.Name = "useDataSourceNameRadioButton";
			this.useDataSourceNameRadioButton.CheckedChanged += new System.EventHandler(useDataSourceNameRadioButton_CheckedChanged);
			componentResourceManager.ApplyResources(this.loginGroupBox, "loginGroupBox");
			this.loginGroupBox.Controls.Add(this.loginTableLayoutPanel);
			this.loginGroupBox.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.loginGroupBox.Name = "loginGroupBox";
			this.loginGroupBox.TabStop = false;
			componentResourceManager.ApplyResources(this.loginTableLayoutPanel, "loginTableLayoutPanel");
			this.loginTableLayoutPanel.Controls.Add(this.userNameLabel, 0, 0);
			this.loginTableLayoutPanel.Controls.Add(this.userNameTextBox, 1, 0);
			this.loginTableLayoutPanel.Controls.Add(this.passwordLabel, 0, 1);
			this.loginTableLayoutPanel.Controls.Add(this.passwordTextBox, 1, 1);
			this.loginTableLayoutPanel.Name = "loginTableLayoutPanel";
			componentResourceManager.ApplyResources(this.userNameLabel, "userNameLabel");
			this.userNameLabel.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.userNameLabel.Name = "userNameLabel";
			componentResourceManager.ApplyResources(this.userNameTextBox, "userNameTextBox");
			this.userNameTextBox.Name = "userNameTextBox";
			this.userNameTextBox.Leave += new System.EventHandler(userNameTextBox_Leave);
			componentResourceManager.ApplyResources(this.passwordLabel, "passwordLabel");
			this.passwordLabel.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.passwordLabel.Name = "passwordLabel";
			componentResourceManager.ApplyResources(this.passwordTextBox, "passwordTextBox");
			this.passwordTextBox.Name = "passwordTextBox";
			this.passwordTextBox.UseSystemPasswordChar = true;
			this.passwordTextBox.Leave += new System.EventHandler(passwordTextBox_Leave);
			componentResourceManager.ApplyResources(this, "$this");
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.Controls.Add(this.loginGroupBox);
			base.Controls.Add(this.dataSourceGroupBox);
			this.MinimumSize = new System.Drawing.Size(350, 215);
			base.Name = "OdbcConnectionUIControl";
			this.dataSourceGroupBox.ResumeLayout(false);
			this.dataSourceGroupBox.PerformLayout();
			this.connectionStringTableLayoutPanel.ResumeLayout(false);
			this.connectionStringTableLayoutPanel.PerformLayout();
			this.dataSourceNameTableLayoutPanel.ResumeLayout(false);
			this.dataSourceNameTableLayoutPanel.PerformLayout();
			this.loginGroupBox.ResumeLayout(false);
			this.loginGroupBox.PerformLayout();
			this.loginTableLayoutPanel.ResumeLayout(false);
			this.loginTableLayoutPanel.PerformLayout();
			base.ResumeLayout(false);
		}
	}
}
