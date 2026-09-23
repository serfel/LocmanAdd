using System;
using System.ComponentModel;
using System.Data;
using System.Data.Odbc;
using System.Data.OleDb;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Reflection;
using System.Security.Permissions;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using ns16;
using DocumentServer.Properties;

namespace DocumentServer.Data.ConnectionUI
{
	[Obfuscation(Exclude = true)]
	internal class SqlConnectionUIControl : UserControl, IDataConnectionUIControl
	{
		private class Class165
		{
			private IDataConnectionProperties idataConnectionProperties_0;

			public string String_0
			{
				get
				{
					if (this.idataConnectionProperties_0 is Class148)
					{
						return this.idataConnectionProperties_0["Provider"] as string;
					}
					return null;
				}
			}

			public string String_1
			{
				get
				{
					return this.idataConnectionProperties_0[this.String_7] as string;
				}
				set
				{
					if (value != null && value.Trim().Length > 0)
					{
						this.idataConnectionProperties_0[this.String_7] = value.Trim();
					}
					else
					{
						this.idataConnectionProperties_0.Reset(this.String_7);
					}
				}
			}

			public bool Boolean_0
			{
				get
				{
					if (this.idataConnectionProperties_0 is Class150)
					{
						return (bool)this.idataConnectionProperties_0["User Instance"];
					}
					return false;
				}
			}

			public bool Boolean_1
			{
				get
				{
					if (this.idataConnectionProperties_0 is Class150)
					{
						return (bool)this.idataConnectionProperties_0["Integrated Security"];
					}
					if (this.idataConnectionProperties_0 is Class146)
					{
						if (this.idataConnectionProperties_0.Contains("Integrated Security") && this.idataConnectionProperties_0["Integrated Security"] is string)
						{
							return (this.idataConnectionProperties_0["Integrated Security"] as string).Equals("SSPI", StringComparison.OrdinalIgnoreCase);
						}
						return false;
					}
					if (this.idataConnectionProperties_0 is Class145)
					{
						if (this.idataConnectionProperties_0.Contains("Trusted_Connection") && this.idataConnectionProperties_0["Trusted_Connection"] is string)
						{
							return (this.idataConnectionProperties_0["Trusted_Connection"] as string).Equals("Yes", StringComparison.OrdinalIgnoreCase);
						}
						return false;
					}
					return false;
				}
				set
				{
					if (this.idataConnectionProperties_0 is Class150)
					{
						if (value)
						{
							this.idataConnectionProperties_0["Integrated Security"] = value;
						}
						else
						{
							this.idataConnectionProperties_0.Reset("Integrated Security");
						}
					}
					if (this.idataConnectionProperties_0 is Class146)
					{
						if (value)
						{
							this.idataConnectionProperties_0["Integrated Security"] = "SSPI";
						}
						else
						{
							this.idataConnectionProperties_0.Reset("Integrated Security");
						}
					}
					if (this.idataConnectionProperties_0 is Class145)
					{
						if (value)
						{
							this.idataConnectionProperties_0["Trusted_Connection"] = "Yes";
						}
						else
						{
							this.idataConnectionProperties_0.Remove("Trusted_Connection");
						}
					}
				}
			}

			public string String_2
			{
				get
				{
					return this.idataConnectionProperties_0[this.String_8] as string;
				}
				set
				{
					if (value != null && value.Trim().Length > 0)
					{
						this.idataConnectionProperties_0[this.String_8] = value.Trim();
					}
					else
					{
						this.idataConnectionProperties_0.Reset(this.String_8);
					}
				}
			}

			public string String_3
			{
				get
				{
					return this.idataConnectionProperties_0[this.String_9] as string;
				}
				set
				{
					if (value != null && value.Length > 0)
					{
						this.idataConnectionProperties_0[this.String_9] = value;
					}
					else
					{
						this.idataConnectionProperties_0.Reset(this.String_9);
					}
				}
			}

			public bool Boolean_2
			{
				get
				{
					if (this.idataConnectionProperties_0 is Class145)
					{
						return false;
					}
					return (bool)this.idataConnectionProperties_0["Persist Security Info"];
				}
				set
				{
					if (value)
					{
						this.idataConnectionProperties_0["Persist Security Info"] = value;
					}
					else
					{
						this.idataConnectionProperties_0.Reset("Persist Security Info");
					}
				}
			}

			public string String_4
			{
				get
				{
					return this.idataConnectionProperties_0[this.String_10] as string;
				}
				set
				{
					if (value != null && value.Trim().Length > 0)
					{
						this.idataConnectionProperties_0[this.String_10] = value.Trim();
					}
					else
					{
						this.idataConnectionProperties_0.Reset(this.String_10);
					}
				}
			}

			public string String_5
			{
				get
				{
					return this.idataConnectionProperties_0[this.String_11] as string;
				}
				set
				{
					if (value != null && value.Trim().Length > 0)
					{
						this.idataConnectionProperties_0[this.String_11] = value.Trim();
					}
					else
					{
						this.idataConnectionProperties_0.Reset(this.String_11);
					}
				}
			}

			public string String_6
			{
				get
				{
					return this.String_4;
				}
				set
				{
					this.String_4 = value;
				}
			}

			private string String_7
			{
				get
				{
					if (!(this.idataConnectionProperties_0 is Class150))
					{
						if (!(this.idataConnectionProperties_0 is Class146))
						{
							if (!(this.idataConnectionProperties_0 is Class145))
							{
								return null;
							}
							return "SERVER";
						}
						return "Data Source";
					}
					return "Data Source";
				}
			}

			private string String_8
			{
				get
				{
					if (!(this.idataConnectionProperties_0 is Class150))
					{
						if (!(this.idataConnectionProperties_0 is Class146))
						{
							if (!(this.idataConnectionProperties_0 is Class145))
							{
								return null;
							}
							return "UID";
						}
						return "User ID";
					}
					return "User ID";
				}
			}

			private string String_9
			{
				get
				{
					if (!(this.idataConnectionProperties_0 is Class150))
					{
						if (!(this.idataConnectionProperties_0 is Class146))
						{
							if (!(this.idataConnectionProperties_0 is Class145))
							{
								return null;
							}
							return "PWD";
						}
						return "Password";
					}
					return "Password";
				}
			}

			private string String_10
			{
				get
				{
					if (!(this.idataConnectionProperties_0 is Class150))
					{
						if (!(this.idataConnectionProperties_0 is Class146))
						{
							if (!(this.idataConnectionProperties_0 is Class145))
							{
								return null;
							}
							return "DATABASE";
						}
						return "Initial Catalog";
					}
					return "Initial Catalog";
				}
			}

			private string String_11
			{
				get
				{
					if (!(this.idataConnectionProperties_0 is Class150))
					{
						if (!(this.idataConnectionProperties_0 is Class146))
						{
							if (!(this.idataConnectionProperties_0 is Class145))
							{
								return null;
							}
							return "AttachDBFileName";
						}
						return "Initial File Name";
					}
					return "AttachDbFilename";
				}
			}

			public Class165(IDataConnectionProperties idataConnectionProperties_1)
			{
				this.idataConnectionProperties_0 = idataConnectionProperties_1;
			}

			public IDbConnection method_0()
			{
				IDbConnection result = null;
				string text = string.Empty;
				if (this.idataConnectionProperties_0 is Class150 || this.idataConnectionProperties_0 is Class146)
				{
					if (this.idataConnectionProperties_0 is Class146)
					{
						text = text + "Provider=" + this.idataConnectionProperties_0["Provider"].ToString() + ";";
					}
					text = text + "Data Source='" + this.String_1.Replace("'", "''") + "';";
					if (this.Boolean_0)
					{
						text += "User Instance=true;";
					}
					if (this.Boolean_1)
					{
						text = text + "Integrated Security=" + this.idataConnectionProperties_0["Integrated Security"].ToString() + ";";
					}
					else
					{
						text = text + "User ID='" + this.String_2.Replace("'", "''") + "';";
						text = text + "Password='" + this.String_3.Replace("'", "''") + "';";
					}
					if (this.idataConnectionProperties_0 is Class150)
					{
						text += "Pooling=False;";
					}
				}
				if (this.idataConnectionProperties_0 is Class145)
				{
					text += "DRIVER={SQL Server};";
					text = text + "SERVER={" + this.String_1.Replace("}", "}}") + "};";
					if (this.Boolean_1)
					{
						text += "Trusted_Connection=Yes;";
					}
					else
					{
						text = text + "UID={" + this.String_2.Replace("}", "}}") + "};";
						text = text + "PWD={" + this.String_3.Replace("}", "}}") + "};";
					}
				}
				if (this.idataConnectionProperties_0 is Class150)
				{
					result = new SqlConnection(text);
				}
				if (this.idataConnectionProperties_0 is Class146)
				{
					result = new OleDbConnection(text);
				}
				if (this.idataConnectionProperties_0 is Class145)
				{
					result = new OdbcConnection(text);
				}
				return result;
			}
		}

		private bool bool_0;

		private object[] object_0;

		private object[] object_1;

		private Thread thread_0;

		private Thread thread_1;

		private Thread thread_2;

		private string string_0;

		private bool bool_1;

		private Class165 class165_0;

		private IContainer icontainer_0;

		private Label serverLabel;

		private TableLayoutPanel serverTableLayoutPanel;

		private ComboBox serverComboBox;

		private System.Windows.Forms.Button refreshButton;

		private GroupBox logonGroupBox;

		private RadioButton windowsAuthenticationRadioButton;

		private RadioButton sqlAuthenticationRadioButton;

		private TableLayoutPanel loginTableLayoutPanel;

		private Label userNameLabel;

		private TextBox userNameTextBox;

		private Label passwordLabel;

		private TextBox passwordTextBox;

		private CheckBox savePasswordCheckBox;

		private GroupBox databaseGroupBox;

		private RadioButton selectDatabaseRadioButton;

		private ComboBox selectDatabaseComboBox;

		private RadioButton attachDatabaseRadioButton;

		private TableLayoutPanel attachDatabaseTableLayoutPanel;

		private TextBox attachDatabaseTextBox;

		private System.Windows.Forms.Button browseButton;

		private Label logicalDatabaseNameLabel;

		private TextBox logicalDatabaseNameTextBox;

		private Class165 Class165_0 => this.class165_0;

		public SqlConnectionUIControl()
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
			this.selectDatabaseComboBox.AccessibleName = SqlConnectionUIControl.smethod_0(this.selectDatabaseRadioButton.Text);
			this.attachDatabaseTextBox.AccessibleName = SqlConnectionUIControl.smethod_0(this.attachDatabaseRadioButton.Text);
			this.thread_0 = Thread.CurrentThread;
			this.attachDatabaseRadioButton.Text = Resources.SQLCONNECTION_UICONTROL_RADIO_ATTACH_DATABASE;
			this.browseButton.Text = Resources.SQLCONNECTION_UICONTROL_BUTTON_BROWSE;
			this.databaseGroupBox.Text = Resources.SQLCONNECTION_UICONTROL_GROUPBOX_DATABASE;
			this.logicalDatabaseNameLabel.Text = Resources.SQLCONNECTION_UICONTROL_LABEL_LOGICAL_DB_NAME;
			this.logonGroupBox.Text = Resources.SQLCONNECTION_UICONTROL_GROUPBOX_LOGON;
			this.passwordLabel.Text = Resources.SQLCONNECTION_UICONTROL_LABEL_PASSWORD;
			this.refreshButton.Text = Resources.SQLCONNECTION_UICONTROL_BUTTON_REFRESH;
			this.savePasswordCheckBox.Text = Resources.SQLCONNECTION_UICONTROL_CHECKBOX_SAVE_PWD;
			this.selectDatabaseRadioButton.Text = Resources.SQLCONNECTION_UICONTROL_RADIO_SELECT_DATABASE;
			this.serverLabel.Text = Resources.SQLCONNECTION_UICONTROL_LABEL_SERVER;
			this.sqlAuthenticationRadioButton.Text = Resources.SQLCONNECTION_UICONTROL_RADIO_SQL_AUTH;
			this.userNameLabel.Text = Resources.SQLCONNECTION_UICONTROL_LABEL_USERNAME;
			this.windowsAuthenticationRadioButton.Text = Resources.SQLCONNECTION_UICONTROL_RADIO_WINDOWS_AUTH;
		}

		public void Initialize(IDataConnectionProperties connectionProperties)
		{
			if (connectionProperties == null)
			{
				throw new ArgumentNullException("connectionProperties");
			}
			if (!(connectionProperties is Class150) && !(connectionProperties is Class148))
			{
				throw new ArgumentException(Resources.SQLCONNECTION_UICONTROL_INVALID_CONNECTION_PROPS);
			}
			if (connectionProperties is Class148)
			{
				this.string_0 = connectionProperties["Provider"] as string;
			}
			if (connectionProperties is Class145)
			{
				this.savePasswordCheckBox.Enabled = false;
			}
			this.class165_0 = new Class165(connectionProperties);
		}

		public void LoadProperties()
		{
			this.bool_0 = true;
			if (this.string_0 != this.Class165_0.String_0)
			{
				this.selectDatabaseComboBox.Items.Clear();
				this.string_0 = this.Class165_0.String_0;
			}
			this.serverComboBox.Text = this.Class165_0.String_1;
			if (this.Class165_0.Boolean_1)
			{
				this.windowsAuthenticationRadioButton.Checked = true;
			}
			else
			{
				this.sqlAuthenticationRadioButton.Checked = true;
			}
			if (this.bool_1 != this.Class165_0.Boolean_0)
			{
				this.selectDatabaseComboBox.Items.Clear();
			}
			this.bool_1 = this.Class165_0.Boolean_0;
			this.userNameTextBox.Text = this.Class165_0.String_2;
			this.passwordTextBox.Text = this.Class165_0.String_3;
			this.savePasswordCheckBox.Checked = this.Class165_0.Boolean_2;
			if (this.Class165_0.String_5 != null && this.Class165_0.String_5.Length != 0)
			{
				this.attachDatabaseRadioButton.Checked = true;
				this.selectDatabaseComboBox.Text = null;
				this.attachDatabaseTextBox.Text = this.Class165_0.String_5;
				this.logicalDatabaseNameTextBox.Text = this.Class165_0.String_6;
			}
			else
			{
				this.selectDatabaseRadioButton.Checked = true;
				this.selectDatabaseComboBox.Text = this.Class165_0.String_4;
				this.attachDatabaseTextBox.Text = null;
				this.logicalDatabaseNameTextBox.Text = null;
			}
			this.bool_0 = false;
		}

		protected override void OnRightToLeftChanged(EventArgs eventArgs_0)
		{
			base.OnRightToLeftChanged(eventArgs_0);
			if (base.ParentForm != null && base.ParentForm.RightToLeftLayout && this.RightToLeft == RightToLeft.Yes)
			{
				Class158.smethod_4(this.serverLabel, this.serverTableLayoutPanel);
				Class158.smethod_3(this.windowsAuthenticationRadioButton);
				Class158.smethod_3(this.sqlAuthenticationRadioButton);
				Class158.smethod_3(this.loginTableLayoutPanel);
				Class158.smethod_3(this.selectDatabaseRadioButton);
				Class158.smethod_3(this.selectDatabaseComboBox);
				Class158.smethod_3(this.attachDatabaseRadioButton);
				Class158.smethod_3(this.attachDatabaseTableLayoutPanel);
				Class158.smethod_3(this.logicalDatabaseNameLabel);
				Class158.smethod_3(this.logicalDatabaseNameTextBox);
			}
			else
			{
				Class158.smethod_5(this.logicalDatabaseNameTextBox);
				Class158.smethod_5(this.logicalDatabaseNameLabel);
				Class158.smethod_5(this.attachDatabaseTableLayoutPanel);
				Class158.smethod_5(this.attachDatabaseRadioButton);
				Class158.smethod_5(this.selectDatabaseComboBox);
				Class158.smethod_5(this.selectDatabaseRadioButton);
				Class158.smethod_5(this.loginTableLayoutPanel);
				Class158.smethod_5(this.sqlAuthenticationRadioButton);
				Class158.smethod_5(this.windowsAuthenticationRadioButton);
				Class158.smethod_6(this.serverLabel, this.serverTableLayoutPanel);
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
			if (base.ActiveControl == this.selectDatabaseRadioButton && (keyData & Keys.KeyCode) == Keys.Down)
			{
				this.attachDatabaseRadioButton.Focus();
				return true;
			}
			if (base.ActiveControl == this.attachDatabaseRadioButton && (keyData & Keys.KeyCode) == Keys.Down)
			{
				this.selectDatabaseRadioButton.Focus();
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

		private void selectDatabaseComboBox_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Down)
			{
				if (sender == this.serverComboBox)
				{
					this.serverComboBox_DropDown(sender, e);
				}
				if (sender == this.selectDatabaseComboBox)
				{
					this.selectDatabaseComboBox_DropDown(sender, e);
				}
			}
		}

		private void serverComboBox_DropDown(object sender, EventArgs e)
		{
			if (this.serverComboBox.Items.Count != 0)
			{
				return;
			}
			Cursor current = Cursor.Current;
			Cursor.Current = Cursors.WaitCursor;
			try
			{
				if (this.thread_1 != null && this.thread_1.ThreadState != ThreadState.Stopped)
				{
					if (this.thread_1.ThreadState == ThreadState.Running)
					{
						this.thread_1.Join();
						this.method_2();
					}
				}
				else
				{
					this.method_1();
				}
			}
			finally
			{
				Cursor.Current = current;
			}
		}

		private void serverComboBox_TextChanged(object sender, EventArgs e)
		{
			if (!this.bool_0)
			{
				this.Class165_0.String_1 = this.serverComboBox.Text;
				if (this.serverComboBox.Items.Count == 0 && this.thread_1 == null)
				{
					this.thread_1 = new Thread(method_1);
					this.thread_1.Start();
				}
			}
			this.method_0(sender, e);
			this.selectDatabaseComboBox.Items.Clear();
		}

		private void refreshButton_Click(object sender, EventArgs e)
		{
			this.serverComboBox.Items.Clear();
			this.serverComboBox_DropDown(sender, e);
		}

		private void windowsAuthenticationRadioButton_CheckedChanged(object sender, EventArgs e)
		{
			if (this.windowsAuthenticationRadioButton.Checked)
			{
				if (!this.bool_0)
				{
					this.Class165_0.Boolean_1 = true;
					this.Class165_0.String_2 = null;
					this.Class165_0.String_3 = null;
					this.Class165_0.Boolean_2 = false;
				}
				this.loginTableLayoutPanel.Enabled = false;
			}
			else
			{
				if (!this.bool_0)
				{
					this.Class165_0.Boolean_1 = false;
					this.userNameTextBox_TextChanged(sender, e);
					this.passwordTextBox_TextChanged(sender, e);
					this.savePasswordCheckBox_CheckedChanged(sender, e);
				}
				this.loginTableLayoutPanel.Enabled = true;
			}
			this.method_0(sender, e);
			this.selectDatabaseComboBox.Items.Clear();
		}

		private void userNameTextBox_TextChanged(object sender, EventArgs e)
		{
			if (!this.bool_0)
			{
				this.Class165_0.String_2 = this.userNameTextBox.Text;
			}
			this.method_0(sender, e);
			this.selectDatabaseComboBox.Items.Clear();
		}

		private void passwordTextBox_TextChanged(object sender, EventArgs e)
		{
			if (!this.bool_0)
			{
				this.Class165_0.String_3 = this.passwordTextBox.Text;
				this.passwordTextBox.Text = this.passwordTextBox.Text;
			}
			this.selectDatabaseComboBox.Items.Clear();
		}

		private void savePasswordCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			if (!this.bool_0)
			{
				this.Class165_0.Boolean_2 = this.savePasswordCheckBox.Checked;
			}
		}

		private void method_0(object sender, EventArgs e)
		{
			if (this.serverComboBox.Text.Trim().Length > 0 && (this.windowsAuthenticationRadioButton.Checked || this.userNameTextBox.Text.Trim().Length > 0))
			{
				this.databaseGroupBox.Enabled = true;
			}
			else
			{
				this.databaseGroupBox.Enabled = false;
			}
		}

		private void selectDatabaseRadioButton_CheckedChanged(object sender, EventArgs e)
		{
			if (this.selectDatabaseRadioButton.Checked)
			{
				this.selectDatabaseComboBox_TextChanged(sender, e);
				this.attachDatabaseTextBox_TextChanged(sender, e);
				this.selectDatabaseComboBox.Enabled = true;
				this.attachDatabaseTableLayoutPanel.Enabled = false;
				this.logicalDatabaseNameLabel.Enabled = false;
				this.logicalDatabaseNameTextBox.Enabled = false;
			}
			else
			{
				this.attachDatabaseTextBox_TextChanged(sender, e);
				this.logicalDatabaseNameTextBox_TextChanged(sender, e);
				this.selectDatabaseComboBox.Enabled = false;
				this.attachDatabaseTableLayoutPanel.Enabled = true;
				this.logicalDatabaseNameLabel.Enabled = true;
				this.logicalDatabaseNameTextBox.Enabled = true;
			}
		}

		private void selectDatabaseComboBox_TextChanged(object sender, EventArgs e)
		{
			if (!this.bool_0)
			{
				this.Class165_0.String_4 = this.selectDatabaseComboBox.Text;
				if (this.selectDatabaseComboBox.Items.Count == 0 && this.thread_2 == null)
				{
					this.thread_2 = new Thread(method_3);
					this.thread_2.Start();
				}
			}
		}

		private void selectDatabaseComboBox_DropDown(object sender, EventArgs e)
		{
			if (this.selectDatabaseComboBox.Items.Count != 0)
			{
				return;
			}
			Cursor current = Cursor.Current;
			Cursor.Current = Cursors.WaitCursor;
			try
			{
				if (this.thread_2 != null && this.thread_2.ThreadState != ThreadState.Stopped)
				{
					if (this.thread_2.ThreadState == ThreadState.Running)
					{
						this.thread_2.Join();
						this.method_4();
					}
				}
				else
				{
					this.method_3();
				}
			}
			finally
			{
				Cursor.Current = current;
			}
		}

		private void attachDatabaseTextBox_TextChanged(object sender, EventArgs e)
		{
			if (!this.bool_0)
			{
				if (this.selectDatabaseRadioButton.Checked)
				{
					this.Class165_0.String_5 = null;
				}
				else
				{
					this.Class165_0.String_5 = this.attachDatabaseTextBox.Text;
				}
			}
		}

		private void logicalDatabaseNameTextBox_TextChanged(object sender, EventArgs e)
		{
			if (!this.bool_0)
			{
				if (this.selectDatabaseRadioButton.Checked)
				{
					this.Class165_0.String_6 = null;
				}
				else
				{
					this.Class165_0.String_6 = this.logicalDatabaseNameTextBox.Text;
				}
			}
		}

		private void browseButton_Click(object sender, EventArgs e)
		{
			OpenFileDialog openFileDialog = new OpenFileDialog();
			openFileDialog.Title = Resources.SQLCONNECTION_UICONTROL_BROWSE_FILE_TITLE;
			openFileDialog.Multiselect = false;
			openFileDialog.RestoreDirectory = true;
			openFileDialog.Filter = Resources.SQLCONNECTION_UICONTROL_BROWSE_FILE_FILTER;
			openFileDialog.DefaultExt = Resources.SQLCONNECTION_UICONTROL_BROWSE_FILE_DEFAULT_EXT;
			if (base.Container != null)
			{
				base.Container.Add(openFileDialog);
			}
			try
			{
				if (openFileDialog.ShowDialog(base.ParentForm) == DialogResult.OK)
				{
					this.attachDatabaseTextBox.Text = openFileDialog.FileName.Trim();
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

		private void selectDatabaseComboBox_Leave(object sender, EventArgs e)
		{
			Control obj = sender as Control;
			obj.Text = obj.Text.Trim();
		}

		private void method_1()
		{
			DataTable dataTable = null;
			try
			{
				dataTable = SqlDataSourceEnumerator.Instance.GetDataSources();
			}
			catch
			{
				dataTable = new DataTable();
				dataTable.Locale = CultureInfo.InvariantCulture;
			}
			this.object_0 = new object[dataTable.Rows.Count];
			for (int i = 0; i < this.object_0.Length; i++)
			{
				string text = dataTable.Rows[i]["ServerName"].ToString();
				string text2 = dataTable.Rows[i]["InstanceName"].ToString();
				if (text2.Length == 0)
				{
					this.object_0[i] = text;
				}
				else
				{
					this.object_0[i] = text + "\\" + text2;
				}
			}
			Array.Sort(this.object_0);
			if (Thread.CurrentThread == this.thread_0)
			{
				this.method_2();
			}
			else if (base.IsHandleCreated)
			{
				base.BeginInvoke(new ThreadStart(method_2));
			}
		}

		private void method_2()
		{
			if (this.serverComboBox.Items.Count == 0)
			{
				if (this.object_0.Length != 0)
				{
					this.serverComboBox.Items.AddRange(this.object_0);
				}
				else
				{
					this.serverComboBox.Items.Add(string.Empty);
				}
			}
		}

		private void method_3()
		{
			DataTable dataTable = null;
			IDbConnection dbConnection = null;
			IDataReader dataReader = null;
			try
			{
				dbConnection = this.Class165_0.method_0();
				IDbCommand dbCommand = dbConnection.CreateCommand();
				dbCommand.CommandText = "SELECT CASE WHEN SERVERPROPERTY(N'EDITION') = 'SQL Data Services' OR SERVERPROPERTY(N'EDITION') = 'SQL Azure' THEN 1 ELSE 0 END";
				dbConnection.Open();
				if ((int)dbCommand.ExecuteScalar() == 1)
				{
					dbCommand.CommandText = "SELECT name FROM master.dbo.sysdatabases ORDER BY name";
				}
				else
				{
					dbCommand.CommandText = "SELECT name FROM master.dbo.sysdatabases WHERE HAS_DBACCESS(name) = 1 ORDER BY name";
				}
				dataReader = dbCommand.ExecuteReader();
				dataTable = new DataTable();
				dataTable.Locale = CultureInfo.CurrentCulture;
				dataTable.Load(dataReader);
			}
			catch
			{
				dataTable = new DataTable();
				dataTable.Locale = CultureInfo.InvariantCulture;
			}
			finally
			{
				dataReader?.Dispose();
				dbConnection?.Dispose();
			}
			this.object_1 = new object[dataTable.Rows.Count];
			for (int i = 0; i < this.object_1.Length; i++)
			{
				this.object_1[i] = dataTable.Rows[i]["name"];
			}
			if (Thread.CurrentThread == this.thread_0)
			{
				this.method_4();
			}
			else if (base.IsHandleCreated)
			{
				base.BeginInvoke(new ThreadStart(method_4));
			}
		}

		private void method_4()
		{
			if (this.selectDatabaseComboBox.Items.Count == 0)
			{
				if (this.object_1.Length != 0)
				{
					this.selectDatabaseComboBox.Items.AddRange(this.object_1);
				}
				else
				{
					this.selectDatabaseComboBox.Items.Add(string.Empty);
				}
			}
			this.thread_2 = null;
		}

		private static string smethod_0(string string_1)
		{
			if (string_1 == null)
			{
				return null;
			}
			int i = string_1.IndexOf('&');
			if (i == -1)
			{
				return string_1;
			}
			StringBuilder stringBuilder = new StringBuilder(string_1.Substring(0, i));
			for (; i < string_1.Length; i++)
			{
				if (string_1[i] == '&')
				{
					i++;
				}
				if (i < string_1.Length)
				{
					stringBuilder.Append(string_1[i]);
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
			System.ComponentModel.ComponentResourceManager componentResourceManager = new System.ComponentModel.ComponentResourceManager(typeof(DocumentServer.Data.ConnectionUI.SqlConnectionUIControl));
			this.serverLabel = new System.Windows.Forms.Label();
			this.serverTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
			this.serverComboBox = new System.Windows.Forms.ComboBox();
			this.refreshButton = new System.Windows.Forms.Button();
			this.logonGroupBox = new System.Windows.Forms.GroupBox();
			this.loginTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
			this.userNameLabel = new System.Windows.Forms.Label();
			this.userNameTextBox = new System.Windows.Forms.TextBox();
			this.passwordLabel = new System.Windows.Forms.Label();
			this.passwordTextBox = new System.Windows.Forms.TextBox();
			this.savePasswordCheckBox = new System.Windows.Forms.CheckBox();
			this.sqlAuthenticationRadioButton = new System.Windows.Forms.RadioButton();
			this.windowsAuthenticationRadioButton = new System.Windows.Forms.RadioButton();
			this.databaseGroupBox = new System.Windows.Forms.GroupBox();
			this.logicalDatabaseNameTextBox = new System.Windows.Forms.TextBox();
			this.logicalDatabaseNameLabel = new System.Windows.Forms.Label();
			this.attachDatabaseTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
			this.attachDatabaseTextBox = new System.Windows.Forms.TextBox();
			this.browseButton = new System.Windows.Forms.Button();
			this.attachDatabaseRadioButton = new System.Windows.Forms.RadioButton();
			this.selectDatabaseComboBox = new System.Windows.Forms.ComboBox();
			this.selectDatabaseRadioButton = new System.Windows.Forms.RadioButton();
			this.serverTableLayoutPanel.SuspendLayout();
			this.logonGroupBox.SuspendLayout();
			this.loginTableLayoutPanel.SuspendLayout();
			this.databaseGroupBox.SuspendLayout();
			this.attachDatabaseTableLayoutPanel.SuspendLayout();
			base.SuspendLayout();
			componentResourceManager.ApplyResources(this.serverLabel, "serverLabel");
			this.serverLabel.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.serverLabel.Name = "serverLabel";
			componentResourceManager.ApplyResources(this.serverTableLayoutPanel, "serverTableLayoutPanel");
			this.serverTableLayoutPanel.Controls.Add(this.serverComboBox, 0, 0);
			this.serverTableLayoutPanel.Controls.Add(this.refreshButton, 1, 0);
			this.serverTableLayoutPanel.Name = "serverTableLayoutPanel";
			componentResourceManager.ApplyResources(this.serverComboBox, "serverComboBox");
			this.serverComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
			this.serverComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
			this.serverComboBox.FormattingEnabled = true;
			this.serverComboBox.Name = "serverComboBox";
			this.serverComboBox.Leave += new System.EventHandler(selectDatabaseComboBox_Leave);
			this.serverComboBox.TextChanged += new System.EventHandler(serverComboBox_TextChanged);
			this.serverComboBox.KeyDown += new System.Windows.Forms.KeyEventHandler(selectDatabaseComboBox_KeyDown);
			this.serverComboBox.DropDown += new System.EventHandler(serverComboBox_DropDown);
			componentResourceManager.ApplyResources(this.refreshButton, "refreshButton");
			this.refreshButton.MinimumSize = new System.Drawing.Size(75, 23);
			this.refreshButton.Name = "refreshButton";
			this.refreshButton.Click += new System.EventHandler(refreshButton_Click);
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
			this.userNameTextBox.Leave += new System.EventHandler(selectDatabaseComboBox_Leave);
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
			componentResourceManager.ApplyResources(this.databaseGroupBox, "databaseGroupBox");
			this.databaseGroupBox.Controls.Add(this.logicalDatabaseNameTextBox);
			this.databaseGroupBox.Controls.Add(this.logicalDatabaseNameLabel);
			this.databaseGroupBox.Controls.Add(this.attachDatabaseTableLayoutPanel);
			this.databaseGroupBox.Controls.Add(this.attachDatabaseRadioButton);
			this.databaseGroupBox.Controls.Add(this.selectDatabaseComboBox);
			this.databaseGroupBox.Controls.Add(this.selectDatabaseRadioButton);
			this.databaseGroupBox.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.databaseGroupBox.Name = "databaseGroupBox";
			this.databaseGroupBox.TabStop = false;
			componentResourceManager.ApplyResources(this.logicalDatabaseNameTextBox, "logicalDatabaseNameTextBox");
			this.logicalDatabaseNameTextBox.Name = "logicalDatabaseNameTextBox";
			this.logicalDatabaseNameTextBox.Leave += new System.EventHandler(selectDatabaseComboBox_Leave);
			this.logicalDatabaseNameTextBox.TextChanged += new System.EventHandler(logicalDatabaseNameTextBox_TextChanged);
			componentResourceManager.ApplyResources(this.logicalDatabaseNameLabel, "logicalDatabaseNameLabel");
			this.logicalDatabaseNameLabel.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.logicalDatabaseNameLabel.Name = "logicalDatabaseNameLabel";
			componentResourceManager.ApplyResources(this.attachDatabaseTableLayoutPanel, "attachDatabaseTableLayoutPanel");
			this.attachDatabaseTableLayoutPanel.Controls.Add(this.attachDatabaseTextBox, 0, 0);
			this.attachDatabaseTableLayoutPanel.Controls.Add(this.browseButton, 1, 0);
			this.attachDatabaseTableLayoutPanel.Name = "attachDatabaseTableLayoutPanel";
			componentResourceManager.ApplyResources(this.attachDatabaseTextBox, "attachDatabaseTextBox");
			this.attachDatabaseTextBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			this.attachDatabaseTextBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.FileSystem;
			this.attachDatabaseTextBox.Name = "attachDatabaseTextBox";
			this.attachDatabaseTextBox.Leave += new System.EventHandler(selectDatabaseComboBox_Leave);
			this.attachDatabaseTextBox.TextChanged += new System.EventHandler(attachDatabaseTextBox_TextChanged);
			componentResourceManager.ApplyResources(this.browseButton, "browseButton");
			this.browseButton.MinimumSize = new System.Drawing.Size(75, 23);
			this.browseButton.Name = "browseButton";
			this.browseButton.Click += new System.EventHandler(browseButton_Click);
			componentResourceManager.ApplyResources(this.attachDatabaseRadioButton, "attachDatabaseRadioButton");
			this.attachDatabaseRadioButton.Name = "attachDatabaseRadioButton";
			this.attachDatabaseRadioButton.CheckedChanged += new System.EventHandler(selectDatabaseRadioButton_CheckedChanged);
			componentResourceManager.ApplyResources(this.selectDatabaseComboBox, "selectDatabaseComboBox");
			this.selectDatabaseComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
			this.selectDatabaseComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
			this.selectDatabaseComboBox.FormattingEnabled = true;
			this.selectDatabaseComboBox.Name = "selectDatabaseComboBox";
			this.selectDatabaseComboBox.Leave += new System.EventHandler(selectDatabaseComboBox_Leave);
			this.selectDatabaseComboBox.TextChanged += new System.EventHandler(selectDatabaseComboBox_TextChanged);
			this.selectDatabaseComboBox.KeyDown += new System.Windows.Forms.KeyEventHandler(selectDatabaseComboBox_KeyDown);
			this.selectDatabaseComboBox.DropDown += new System.EventHandler(selectDatabaseComboBox_DropDown);
			componentResourceManager.ApplyResources(this.selectDatabaseRadioButton, "selectDatabaseRadioButton");
			this.selectDatabaseRadioButton.Name = "selectDatabaseRadioButton";
			this.selectDatabaseRadioButton.CheckedChanged += new System.EventHandler(selectDatabaseRadioButton_CheckedChanged);
			componentResourceManager.ApplyResources(this, "$this");
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.Controls.Add(this.databaseGroupBox);
			base.Controls.Add(this.logonGroupBox);
			base.Controls.Add(this.serverTableLayoutPanel);
			base.Controls.Add(this.serverLabel);
			this.MinimumSize = new System.Drawing.Size(350, 360);
			base.Name = "SqlConnectionUIControl";
			this.serverTableLayoutPanel.ResumeLayout(false);
			this.serverTableLayoutPanel.PerformLayout();
			this.logonGroupBox.ResumeLayout(false);
			this.logonGroupBox.PerformLayout();
			this.loginTableLayoutPanel.ResumeLayout(false);
			this.loginTableLayoutPanel.PerformLayout();
			this.databaseGroupBox.ResumeLayout(false);
			this.databaseGroupBox.PerformLayout();
			this.attachDatabaseTableLayoutPanel.ResumeLayout(false);
			this.attachDatabaseTableLayoutPanel.PerformLayout();
			base.ResumeLayout(false);
			base.PerformLayout();
		}
	}
}
