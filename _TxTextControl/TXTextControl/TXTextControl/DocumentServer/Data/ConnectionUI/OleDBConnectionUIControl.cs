using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Globalization;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using Microsoft.Win32;
using ns16;
using DocumentServer.Properties;

namespace DocumentServer.Data.ConnectionUI
{
	[Obfuscation(Exclude = true)]
	internal class OleDBConnectionUIControl : UserControl, IDataConnectionUIControl
	{
		private struct Struct30
		{
			private string string_0;

			private string string_1;

			public string String_0 => this.string_0;

			public string String_1 => this.string_1;

			public Struct30(string string_2, string string_3)
			{
				this.string_0 = string_2;
				this.string_1 = string_3;
			}

			public override string ToString()
			{
				return this.string_1;
			}
		}

		private bool bool_0;

		private object[] object_0;

		private Thread thread_0;

		private Thread thread_1;

		private IDataConnectionProperties idataConnectionProperties_0;

		private IContainer icontainer_0;

		private Label providerLabel;

		private TableLayoutPanel providerTableLayoutPanel;

		private ComboBox providerComboBox;

		private System.Windows.Forms.Button dataLinksButton;

		private GroupBox dataSourceGroupBox;

		private TableLayoutPanel dataSourceTableLayoutPanel;

		private Label dataSourceLabel;

		private TextBox dataSourceTextBox;

		private Label locationLabel;

		private TextBox locationTextBox;

		private GroupBox logonGroupBox;

		private RadioButton integratedSecurityRadioButton;

		private RadioButton nativeSecurityRadioButton;

		private TableLayoutPanel loginTableLayoutPanel;

		private TableLayoutPanel subLoginTableLayoutPanel;

		private Label userNameLabel;

		private TextBox userNameTextBox;

		private Label passwordLabel;

		private TextBox passwordTextBox;

		private TableLayoutPanel subSubLoginTableLayoutPanel;

		private CheckBox blankPasswordCheckBox;

		private CheckBox allowSavingPasswordCheckBox;

		private Label initialCatalogLabel;

		private ComboBox initialCatalogComboBox;

		private IDataConnectionProperties IDataConnectionProperties_0 => this.idataConnectionProperties_0;

		public OleDBConnectionUIControl()
		{
			this.InitializeComponent();
			this.RightToLeft = RightToLeft.Inherit;
			this.thread_0 = Thread.CurrentThread;
			this.allowSavingPasswordCheckBox.Text = Resources.OLEDBCONNECTION_UICONTROL_CHECKBOX_ALLOW_SAVING_PWD;
			this.blankPasswordCheckBox.Text = Resources.OLEDBCONNECTION_UICONTROL_CHECKBOX_BLANK_PWD;
			this.dataLinksButton.Text = Resources.OLEDBCONNECTION_UICONTROL_BUTTON_DATALINKS;
			this.dataSourceGroupBox.Text = Resources.OLEDBCONNECTION_UICONTROL_GROUPBOX_DATASOURCE;
			this.dataSourceLabel.Text = Resources.OLEDBCONNECTION_UICONTROL_LABEL_DATASOURCE;
			this.initialCatalogLabel.Text = Resources.OLEDBCONNECTION_UICONTROL_LABEL_INIT_CATALOG;
			this.integratedSecurityRadioButton.Text = Resources.OLEDBCONNECTION_UICONTROL_RADIO_INTEGR_SECURITY;
			this.locationLabel.Text = Resources.OLEDBCONNECTION_UICONTROL_LABEL_LOCATION;
			this.logonGroupBox.Text = Resources.OLEDBCONNECTION_UICONTROL_GROUPBOX_LOGON;
			this.nativeSecurityRadioButton.Text = Resources.OLEDBCONNECTION_UICONTROL_RADIO_NATIVE_SECURITY;
			this.passwordLabel.Text = Resources.OLEDBCONNECTION_UICONTROL_LABEL_PASSWORD;
			this.providerLabel.Text = Resources.OLEDBCONNECTION_UICONTROL_LABEL_PROVIDER;
			this.userNameLabel.Text = Resources.OLEDBCONNECTION_UICONTROL_LABEL_USERNAME;
		}

		public void Initialize(IDataConnectionProperties connectionProperties)
		{
			this.Initialize(connectionProperties, disableProviderSelection: false);
		}

		public void Initialize(IDataConnectionProperties connectionProperties, bool disableProviderSelection)
		{
			if (!(connectionProperties is Class146))
			{
				throw new ArgumentException(Resources.OLEDBCONNECTION_UICONTROL_INVALID_CONNECTION_PROPS);
			}
			this.method_0();
			this.providerComboBox.Enabled = !disableProviderSelection;
			this.dataLinksButton.Enabled = false;
			this.dataSourceGroupBox.Enabled = false;
			this.logonGroupBox.Enabled = false;
			this.initialCatalogLabel.Enabled = false;
			this.initialCatalogComboBox.Enabled = false;
			this.idataConnectionProperties_0 = connectionProperties;
		}

		public void LoadProperties()
		{
			this.bool_0 = true;
			string text = this.IDataConnectionProperties_0["Provider"] as string;
			if (text != null && text.Length > 0)
			{
				object obj = null;
				foreach (Struct30 item in this.providerComboBox.Items)
				{
					if (!item.String_0.Equals(text))
					{
						if (item.String_0.StartsWith(text + ".", StringComparison.OrdinalIgnoreCase) && (obj == null || item.String_0.CompareTo(((Struct30)obj).String_0) > 0))
						{
							obj = item;
						}
						continue;
					}
					obj = item;
					break;
				}
				this.providerComboBox.SelectedItem = obj;
			}
			else
			{
				this.providerComboBox.SelectedItem = null;
			}
			if (this.IDataConnectionProperties_0.Contains("Data Source") && this.IDataConnectionProperties_0["Data Source"] is string)
			{
				this.dataSourceTextBox.Text = this.IDataConnectionProperties_0["Data Source"] as string;
			}
			else
			{
				this.dataSourceTextBox.Text = null;
			}
			if (this.IDataConnectionProperties_0.Contains("Location") && this.IDataConnectionProperties_0["Location"] is string)
			{
				this.locationTextBox.Text = this.IDataConnectionProperties_0["Location"] as string;
			}
			else
			{
				this.locationTextBox.Text = null;
			}
			if (this.IDataConnectionProperties_0.Contains("Integrated Security") && this.IDataConnectionProperties_0["Integrated Security"] is string && (this.IDataConnectionProperties_0["Integrated Security"] as string).Length > 0)
			{
				this.integratedSecurityRadioButton.Checked = true;
			}
			else
			{
				this.nativeSecurityRadioButton.Checked = true;
			}
			if (this.IDataConnectionProperties_0.Contains("User ID") && this.IDataConnectionProperties_0["User ID"] is string)
			{
				this.userNameTextBox.Text = this.IDataConnectionProperties_0["User ID"] as string;
			}
			else
			{
				this.userNameTextBox.Text = null;
			}
			if (this.IDataConnectionProperties_0.Contains("Password") && this.IDataConnectionProperties_0["Password"] is string)
			{
				this.passwordTextBox.Text = this.IDataConnectionProperties_0["Password"] as string;
				this.blankPasswordCheckBox.Checked = this.passwordTextBox.Text.Length == 0;
			}
			else
			{
				this.passwordTextBox.Text = null;
				this.blankPasswordCheckBox.Checked = false;
			}
			if (this.IDataConnectionProperties_0.Contains("Persist Security Info") && this.IDataConnectionProperties_0["Persist Security Info"] is bool)
			{
				this.allowSavingPasswordCheckBox.Checked = (bool)this.IDataConnectionProperties_0["Persist Security Info"];
			}
			else
			{
				this.allowSavingPasswordCheckBox.Checked = false;
			}
			if (this.IDataConnectionProperties_0.Contains("Initial Catalog") && this.IDataConnectionProperties_0["Initial Catalog"] is string)
			{
				this.initialCatalogComboBox.Text = this.IDataConnectionProperties_0["Initial Catalog"] as string;
			}
			else
			{
				this.initialCatalogComboBox.Text = null;
			}
			this.bool_0 = false;
		}

		public override Size GetPreferredSize(Size proposedSize)
		{
			Size result = base.GetPreferredSize(proposedSize);
			int num = this.logonGroupBox.Padding.Left + this.loginTableLayoutPanel.Margin.Left + this.blankPasswordCheckBox.Margin.Left + this.blankPasswordCheckBox.Width + this.blankPasswordCheckBox.Margin.Right + this.allowSavingPasswordCheckBox.Margin.Left + this.allowSavingPasswordCheckBox.Width + this.allowSavingPasswordCheckBox.Margin.Right + this.loginTableLayoutPanel.Margin.Right + this.logonGroupBox.Padding.Right;
			if (num > result.Width)
			{
				result = new Size(num, result.Height);
			}
			return result;
		}

		protected override void OnRightToLeftChanged(EventArgs eventArgs_0)
		{
			base.OnRightToLeftChanged(eventArgs_0);
			if (base.ParentForm != null && base.ParentForm.RightToLeftLayout && this.RightToLeft == RightToLeft.Yes)
			{
				Class158.smethod_4(this.providerLabel, this.providerTableLayoutPanel);
				Class158.smethod_3(this.integratedSecurityRadioButton);
				Class158.smethod_3(this.nativeSecurityRadioButton);
				Class158.smethod_3(this.loginTableLayoutPanel);
				Class158.smethod_4(this.initialCatalogLabel, this.initialCatalogComboBox);
			}
			else
			{
				Class158.smethod_6(this.initialCatalogLabel, this.initialCatalogComboBox);
				Class158.smethod_5(this.loginTableLayoutPanel);
				Class158.smethod_5(this.nativeSecurityRadioButton);
				Class158.smethod_5(this.integratedSecurityRadioButton);
				Class158.smethod_6(this.providerLabel, this.providerTableLayoutPanel);
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

		private void method_0()
		{
			Cursor current = Cursor.Current;
			OleDbDataReader oleDbDataReader = null;
			try
			{
				Cursor.Current = Cursors.WaitCursor;
				oleDbDataReader = OleDbEnumerator.GetEnumerator(Type.GetTypeFromCLSID(Class159.guid_2));
				Dictionary<string, string> dictionary = new Dictionary<string, string>();
				while (oleDbDataReader.Read())
				{
					int @int = oleDbDataReader.GetInt32(oleDbDataReader.GetOrdinal("SOURCES_TYPE"));
					if (@int == 1 || @int == 3)
					{
						string key = oleDbDataReader["SOURCES_CLSID"].ToString();
						string text2 = (dictionary[key] = oleDbDataReader["SOURCES_DESCRIPTION"].ToString());
					}
				}
				Dictionary<string, string> dictionary2 = new Dictionary<string, string>(dictionary.Count);
				RegistryKey registryKey = Registry.ClassesRoot.OpenSubKey("CLSID");
				using (registryKey)
				{
					foreach (KeyValuePair<string, string> item in dictionary)
					{
						RegistryKey registryKey2 = registryKey.OpenSubKey(item.Key + "\\ProgID");
						if (registryKey2 == null)
						{
							continue;
						}
						using (registryKey2)
						{
							string text3 = registryKey.OpenSubKey(item.Key + "\\ProgID").GetValue(null) as string;
							if (text3 != null && !text3.Equals("MSDASQL", StringComparison.OrdinalIgnoreCase) && !text3.StartsWith("MSDASQL.", StringComparison.OrdinalIgnoreCase) && !text3.Equals("Microsoft OLE DB Provider for ODBC Drivers"))
							{
								dictionary2[text3] = item.Key;
							}
						}
					}
				}
				foreach (KeyValuePair<string, string> item2 in dictionary2)
				{
					this.providerComboBox.Items.Add(new Struct30(item2.Key, dictionary[item2.Value]));
				}
			}
			finally
			{
				oleDbDataReader?.Dispose();
				Cursor.Current = current;
			}
		}

		private void providerComboBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (this.providerComboBox.SelectedItem is Struct30)
			{
				if (!this.bool_0)
				{
					this.IDataConnectionProperties_0["Provider"] = ((Struct30)this.providerComboBox.SelectedItem).String_0;
				}
				foreach (PropertyDescriptor property in TypeDescriptor.GetProperties(this.IDataConnectionProperties_0))
				{
					if (property.Category.Equals(CategoryAttribute.Default.Category, StringComparison.CurrentCulture))
					{
						this.IDataConnectionProperties_0.Remove(property.DisplayName);
					}
				}
				this.dataLinksButton.Enabled = true;
				this.dataSourceGroupBox.Enabled = true;
				this.logonGroupBox.Enabled = true;
				this.loginTableLayoutPanel.Enabled = true;
				this.initialCatalogLabel.Enabled = true;
				this.initialCatalogComboBox.Enabled = true;
				this.dataSourceLabel.Enabled = false;
				this.dataSourceTextBox.Enabled = false;
				this.locationLabel.Enabled = false;
				this.locationTextBox.Enabled = false;
				this.integratedSecurityRadioButton.Enabled = false;
				this.nativeSecurityRadioButton.Enabled = false;
				this.userNameLabel.Enabled = false;
				this.userNameTextBox.Enabled = false;
				this.passwordLabel.Enabled = false;
				this.passwordTextBox.Enabled = false;
				this.blankPasswordCheckBox.Enabled = false;
				this.allowSavingPasswordCheckBox.Enabled = false;
				this.initialCatalogLabel.Enabled = false;
				this.initialCatalogComboBox.Enabled = false;
				PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(this.IDataConnectionProperties_0);
				PropertyDescriptor propertyDescriptor2 = null;
				if ((propertyDescriptor2 = properties["DataSource"]) != null && propertyDescriptor2.IsBrowsable)
				{
					this.dataSourceLabel.Enabled = true;
					this.dataSourceTextBox.Enabled = true;
				}
				if ((propertyDescriptor2 = properties["Location"]) != null && propertyDescriptor2.IsBrowsable)
				{
					this.locationLabel.Enabled = true;
					this.locationTextBox.Enabled = true;
				}
				this.dataSourceGroupBox.Enabled = this.dataSourceTextBox.Enabled || this.locationTextBox.Enabled;
				if ((propertyDescriptor2 = properties["Integrated Security"]) != null && propertyDescriptor2.IsBrowsable)
				{
					this.integratedSecurityRadioButton.Enabled = true;
				}
				if ((propertyDescriptor2 = properties["User ID"]) != null && propertyDescriptor2.IsBrowsable)
				{
					this.userNameLabel.Enabled = true;
					this.userNameTextBox.Enabled = true;
				}
				if ((propertyDescriptor2 = properties["Password"]) != null && propertyDescriptor2.IsBrowsable)
				{
					this.passwordLabel.Enabled = true;
					this.passwordTextBox.Enabled = true;
					this.blankPasswordCheckBox.Enabled = true;
				}
				if (this.passwordTextBox.Enabled && (propertyDescriptor2 = properties["PersistSecurityInfo"]) != null && propertyDescriptor2.IsBrowsable)
				{
					this.allowSavingPasswordCheckBox.Enabled = true;
				}
				this.loginTableLayoutPanel.Enabled = this.userNameTextBox.Enabled || this.passwordTextBox.Enabled;
				this.nativeSecurityRadioButton.Enabled = this.loginTableLayoutPanel.Enabled;
				this.logonGroupBox.Enabled = this.integratedSecurityRadioButton.Enabled || this.nativeSecurityRadioButton.Enabled;
				if ((propertyDescriptor2 = properties["Initial Catalog"]) != null && propertyDescriptor2.IsBrowsable)
				{
					this.initialCatalogLabel.Enabled = true;
					this.initialCatalogComboBox.Enabled = true;
				}
			}
			else
			{
				if (!this.bool_0)
				{
					this.IDataConnectionProperties_0["Provider"] = null;
				}
				this.dataLinksButton.Enabled = false;
				this.dataSourceGroupBox.Enabled = false;
				this.logonGroupBox.Enabled = false;
				this.initialCatalogLabel.Enabled = false;
				this.initialCatalogComboBox.Enabled = false;
			}
			if (!this.bool_0)
			{
				this.LoadProperties();
			}
			this.initialCatalogComboBox.Items.Clear();
		}

		private void providerComboBox_DropDown(object sender, EventArgs e)
		{
			if (this.providerComboBox.Items.Count > 0)
			{
				int num = 0;
				using (Graphics dc = Graphics.FromHwnd(this.providerComboBox.Handle))
				{
					foreach (Struct30 item in this.providerComboBox.Items)
					{
						int num2 = TextRenderer.MeasureText(dc, item.String_1, this.providerComboBox.Font, new Size(int.MaxValue, int.MaxValue), TextFormatFlags.WordBreak).Width;
						if (num2 > num)
						{
							num = num2;
						}
					}
				}
				this.providerComboBox.DropDownWidth = num + 3;
				if (this.providerComboBox.Items.Count > this.providerComboBox.MaxDropDownItems)
				{
					this.providerComboBox.DropDownWidth += SystemInformation.VerticalScrollBarWidth;
				}
			}
			else
			{
				this.providerComboBox.DropDownWidth = this.providerComboBox.Width;
			}
		}

		private void dataLinksButton_Click(object sender, EventArgs e)
		{
			try
			{
				Class159.IDataInitialize obj = Activator.CreateInstance(Type.GetTypeFromCLSID(Class159.guid_1)) as Class159.IDataInitialize;
				object ppDataSource = null;
				obj.GetDataSource(null, 1, this.IDataConnectionProperties_0.ToFullString(), ref Class159.guid_0, ref ppDataSource);
				((Class159.IDBPromptInitialize)obj).PromptDataSource(null, base.ParentForm.Handle, 18, 0, IntPtr.Zero, null, ref Class159.guid_0, ref ppDataSource);
				string ppwszInitString = null;
				obj.GetInitializationString(ppDataSource, fIncludePassword: true, out ppwszInitString);
				this.IDataConnectionProperties_0.Parse(ppwszInitString);
				this.LoadProperties();
			}
			catch (Exception ex)
			{
				COMException ex2 = ex as COMException;
				if (ex2 == null || ex2.ErrorCode != -2147217842)
				{
					IUIService iUIService = this.GetService(typeof(IUIService)) as IUIService;
					if (iUIService != null)
					{
						iUIService.ShowError(ex);
					}
					else
					{
						Class163.smethod_0(null, ex.Message, MessageBoxIcon.Exclamation);
					}
				}
			}
		}

		private void dataSourceTextBox_TextChanged(object sender, EventArgs e)
		{
			if (!this.bool_0)
			{
				this.IDataConnectionProperties_0["Data Source"] = ((this.dataSourceTextBox.Text.Trim().Length > 0) ? this.dataSourceTextBox.Text.Trim() : null);
			}
			this.initialCatalogComboBox.Items.Clear();
		}

		private void locationTextBox_TextChanged(object sender, EventArgs e)
		{
			if (!this.bool_0)
			{
				this.IDataConnectionProperties_0["Location"] = this.locationTextBox.Text;
			}
			this.initialCatalogComboBox.Items.Clear();
		}

		private void integratedSecurityRadioButton_CheckedChanged(object sender, EventArgs e)
		{
			if (!this.bool_0)
			{
				if (this.integratedSecurityRadioButton.Checked)
				{
					this.IDataConnectionProperties_0["Integrated Security"] = "SSPI";
					this.IDataConnectionProperties_0.Reset("User ID");
					this.IDataConnectionProperties_0.Reset("Password");
					this.IDataConnectionProperties_0.Reset("Persist Security Info");
				}
				else
				{
					this.IDataConnectionProperties_0.Reset("Integrated Security");
					this.userNameTextBox_TextChanged(sender, e);
					this.passwordTextBox_TextChanged(sender, e);
					this.blankPasswordCheckBox_CheckedChanged(sender, e);
					this.allowSavingPasswordCheckBox_CheckedChanged(sender, e);
				}
			}
			this.loginTableLayoutPanel.Enabled = !this.integratedSecurityRadioButton.Checked;
			this.initialCatalogComboBox.Items.Clear();
		}

		private void userNameTextBox_TextChanged(object sender, EventArgs e)
		{
			if (!this.bool_0)
			{
				this.IDataConnectionProperties_0["User ID"] = ((this.userNameTextBox.Text.Trim().Length > 0) ? this.userNameTextBox.Text.Trim() : null);
			}
			this.initialCatalogComboBox.Items.Clear();
		}

		private void passwordTextBox_TextChanged(object sender, EventArgs e)
		{
			if (!this.bool_0)
			{
				this.IDataConnectionProperties_0["Password"] = ((this.passwordTextBox.Text.Length > 0) ? this.passwordTextBox.Text : null);
				if (this.passwordTextBox.Text.Length == 0)
				{
					this.IDataConnectionProperties_0.Remove("Password");
				}
				this.passwordTextBox.Text = this.passwordTextBox.Text;
			}
			this.initialCatalogComboBox.Items.Clear();
		}

		private void blankPasswordCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			if (this.blankPasswordCheckBox.Checked)
			{
				if (!this.bool_0)
				{
					this.IDataConnectionProperties_0["Password"] = string.Empty;
				}
				this.passwordLabel.Enabled = false;
				this.passwordTextBox.Enabled = false;
			}
			else
			{
				if (!this.bool_0)
				{
					this.passwordTextBox_TextChanged(sender, e);
				}
				this.passwordLabel.Enabled = true;
				this.passwordTextBox.Enabled = true;
			}
		}

		private void allowSavingPasswordCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			if (!this.bool_0)
			{
				this.IDataConnectionProperties_0["Persist Security Info"] = this.allowSavingPasswordCheckBox.Checked;
			}
		}

		private void initialCatalogComboBox_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Down)
			{
				this.initialCatalogComboBox_DropDown(sender, e);
			}
		}

		private void initialCatalogComboBox_TextChanged(object sender, EventArgs e)
		{
			if (!this.bool_0)
			{
				this.IDataConnectionProperties_0["Initial Catalog"] = ((this.initialCatalogComboBox.Text.Trim().Length > 0) ? this.initialCatalogComboBox.Text.Trim() : null);
				if (this.initialCatalogComboBox.Items.Count == 0 && this.thread_1 == null)
				{
					this.thread_1 = new Thread(method_1);
					this.thread_1.Start();
				}
			}
		}

		private void initialCatalogComboBox_DropDown(object sender, EventArgs e)
		{
			if (this.initialCatalogComboBox.Items.Count != 0)
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

		private void initialCatalogComboBox_Leave(object sender, EventArgs e)
		{
			Control obj = sender as Control;
			obj.Text = obj.Text.Trim();
		}

		private void method_1()
		{
			DataTable dataTable = null;
			OleDbConnection oleDbConnection = null;
			try
			{
				OleDbConnectionStringBuilder oleDbConnectionStringBuilder = new OleDbConnectionStringBuilder(this.IDataConnectionProperties_0.ToFullString());
				oleDbConnectionStringBuilder.Remove("Initial Catalog");
				oleDbConnection = new OleDbConnection(oleDbConnectionStringBuilder.ConnectionString);
				oleDbConnection.Open();
				dataTable = oleDbConnection.GetOleDbSchemaTable(OleDbSchemaGuid.Catalogs, null);
			}
			catch
			{
				dataTable = new DataTable();
				dataTable.Locale = CultureInfo.InvariantCulture;
			}
			finally
			{
				oleDbConnection?.Dispose();
			}
			this.object_0 = new object[dataTable.Rows.Count];
			for (int i = 0; i < this.object_0.Length; i++)
			{
				this.object_0[i] = dataTable.Rows[i]["CATALOG_NAME"];
			}
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
			if (this.initialCatalogComboBox.Items.Count == 0)
			{
				if (this.object_0.Length != 0)
				{
					this.initialCatalogComboBox.Items.AddRange(this.object_0);
				}
				else
				{
					this.initialCatalogComboBox.Items.Add(string.Empty);
				}
			}
			this.thread_1 = null;
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
			System.ComponentModel.ComponentResourceManager componentResourceManager = new System.ComponentModel.ComponentResourceManager(typeof(DocumentServer.Data.ConnectionUI.OleDBConnectionUIControl));
			this.providerLabel = new System.Windows.Forms.Label();
			this.providerTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
			this.providerComboBox = new System.Windows.Forms.ComboBox();
			this.dataLinksButton = new System.Windows.Forms.Button();
			this.dataSourceGroupBox = new System.Windows.Forms.GroupBox();
			this.dataSourceTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
			this.dataSourceLabel = new System.Windows.Forms.Label();
			this.dataSourceTextBox = new System.Windows.Forms.TextBox();
			this.locationLabel = new System.Windows.Forms.Label();
			this.locationTextBox = new System.Windows.Forms.TextBox();
			this.logonGroupBox = new System.Windows.Forms.GroupBox();
			this.loginTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
			this.subLoginTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
			this.userNameLabel = new System.Windows.Forms.Label();
			this.userNameTextBox = new System.Windows.Forms.TextBox();
			this.passwordLabel = new System.Windows.Forms.Label();
			this.passwordTextBox = new System.Windows.Forms.TextBox();
			this.subSubLoginTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
			this.blankPasswordCheckBox = new System.Windows.Forms.CheckBox();
			this.allowSavingPasswordCheckBox = new System.Windows.Forms.CheckBox();
			this.nativeSecurityRadioButton = new System.Windows.Forms.RadioButton();
			this.integratedSecurityRadioButton = new System.Windows.Forms.RadioButton();
			this.initialCatalogLabel = new System.Windows.Forms.Label();
			this.initialCatalogComboBox = new System.Windows.Forms.ComboBox();
			this.providerTableLayoutPanel.SuspendLayout();
			this.dataSourceGroupBox.SuspendLayout();
			this.dataSourceTableLayoutPanel.SuspendLayout();
			this.logonGroupBox.SuspendLayout();
			this.loginTableLayoutPanel.SuspendLayout();
			this.subLoginTableLayoutPanel.SuspendLayout();
			this.subSubLoginTableLayoutPanel.SuspendLayout();
			base.SuspendLayout();
			componentResourceManager.ApplyResources(this.providerLabel, "providerLabel");
			this.providerLabel.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.providerLabel.Name = "providerLabel";
			componentResourceManager.ApplyResources(this.providerTableLayoutPanel, "providerTableLayoutPanel");
			this.providerTableLayoutPanel.Controls.Add(this.providerComboBox, 0, 0);
			this.providerTableLayoutPanel.Controls.Add(this.dataLinksButton, 1, -1);
			this.providerTableLayoutPanel.Name = "providerTableLayoutPanel";
			componentResourceManager.ApplyResources(this.providerComboBox, "providerComboBox");
			this.providerComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.providerComboBox.FormattingEnabled = true;
			this.providerComboBox.Name = "providerComboBox";
			this.providerComboBox.Sorted = true;
			this.providerComboBox.SelectedIndexChanged += new System.EventHandler(providerComboBox_SelectedIndexChanged);
			this.providerComboBox.DropDown += new System.EventHandler(providerComboBox_DropDown);
			componentResourceManager.ApplyResources(this.dataLinksButton, "dataLinksButton");
			this.dataLinksButton.MinimumSize = new System.Drawing.Size(83, 23);
			this.dataLinksButton.Name = "dataLinksButton";
			this.dataLinksButton.Click += new System.EventHandler(dataLinksButton_Click);
			componentResourceManager.ApplyResources(this.dataSourceGroupBox, "dataSourceGroupBox");
			this.dataSourceGroupBox.Controls.Add(this.dataSourceTableLayoutPanel);
			this.dataSourceGroupBox.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.dataSourceGroupBox.Name = "dataSourceGroupBox";
			this.dataSourceGroupBox.TabStop = false;
			componentResourceManager.ApplyResources(this.dataSourceTableLayoutPanel, "dataSourceTableLayoutPanel");
			this.dataSourceTableLayoutPanel.Controls.Add(this.dataSourceLabel, 0, 0);
			this.dataSourceTableLayoutPanel.Controls.Add(this.dataSourceTextBox, 1, 0);
			this.dataSourceTableLayoutPanel.Controls.Add(this.locationLabel, 0, 1);
			this.dataSourceTableLayoutPanel.Controls.Add(this.locationTextBox, 1, 1);
			this.dataSourceTableLayoutPanel.Name = "dataSourceTableLayoutPanel";
			componentResourceManager.ApplyResources(this.dataSourceLabel, "dataSourceLabel");
			this.dataSourceLabel.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.dataSourceLabel.Name = "dataSourceLabel";
			componentResourceManager.ApplyResources(this.dataSourceTextBox, "dataSourceTextBox");
			this.dataSourceTextBox.Name = "dataSourceTextBox";
			this.dataSourceTextBox.Leave += new System.EventHandler(initialCatalogComboBox_Leave);
			this.dataSourceTextBox.TextChanged += new System.EventHandler(dataSourceTextBox_TextChanged);
			componentResourceManager.ApplyResources(this.locationLabel, "locationLabel");
			this.locationLabel.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.locationLabel.Name = "locationLabel";
			componentResourceManager.ApplyResources(this.locationTextBox, "locationTextBox");
			this.locationTextBox.Name = "locationTextBox";
			this.locationTextBox.Leave += new System.EventHandler(initialCatalogComboBox_Leave);
			this.locationTextBox.TextChanged += new System.EventHandler(locationTextBox_TextChanged);
			componentResourceManager.ApplyResources(this.logonGroupBox, "logonGroupBox");
			this.logonGroupBox.Controls.Add(this.loginTableLayoutPanel);
			this.logonGroupBox.Controls.Add(this.nativeSecurityRadioButton);
			this.logonGroupBox.Controls.Add(this.integratedSecurityRadioButton);
			this.logonGroupBox.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.logonGroupBox.Name = "logonGroupBox";
			this.logonGroupBox.TabStop = false;
			componentResourceManager.ApplyResources(this.loginTableLayoutPanel, "loginTableLayoutPanel");
			this.loginTableLayoutPanel.Controls.Add(this.subLoginTableLayoutPanel, 0, 0);
			this.loginTableLayoutPanel.Controls.Add(this.subSubLoginTableLayoutPanel, 0, 1);
			this.loginTableLayoutPanel.Name = "loginTableLayoutPanel";
			componentResourceManager.ApplyResources(this.subLoginTableLayoutPanel, "subLoginTableLayoutPanel");
			this.subLoginTableLayoutPanel.Controls.Add(this.userNameLabel, 0, 0);
			this.subLoginTableLayoutPanel.Controls.Add(this.userNameTextBox, 1, 0);
			this.subLoginTableLayoutPanel.Controls.Add(this.passwordLabel, 0, 1);
			this.subLoginTableLayoutPanel.Controls.Add(this.passwordTextBox, 1, 1);
			this.subLoginTableLayoutPanel.Name = "subLoginTableLayoutPanel";
			componentResourceManager.ApplyResources(this.userNameLabel, "userNameLabel");
			this.userNameLabel.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.userNameLabel.Name = "userNameLabel";
			componentResourceManager.ApplyResources(this.userNameTextBox, "userNameTextBox");
			this.userNameTextBox.Name = "userNameTextBox";
			this.userNameTextBox.Leave += new System.EventHandler(initialCatalogComboBox_Leave);
			this.userNameTextBox.TextChanged += new System.EventHandler(userNameTextBox_TextChanged);
			componentResourceManager.ApplyResources(this.passwordLabel, "passwordLabel");
			this.passwordLabel.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.passwordLabel.Name = "passwordLabel";
			componentResourceManager.ApplyResources(this.passwordTextBox, "passwordTextBox");
			this.passwordTextBox.Name = "passwordTextBox";
			this.passwordTextBox.UseSystemPasswordChar = true;
			this.passwordTextBox.TextChanged += new System.EventHandler(passwordTextBox_TextChanged);
			componentResourceManager.ApplyResources(this.subSubLoginTableLayoutPanel, "subSubLoginTableLayoutPanel");
			this.subSubLoginTableLayoutPanel.Controls.Add(this.blankPasswordCheckBox, 0, 0);
			this.subSubLoginTableLayoutPanel.Controls.Add(this.allowSavingPasswordCheckBox, 1, 0);
			this.subSubLoginTableLayoutPanel.Name = "subSubLoginTableLayoutPanel";
			componentResourceManager.ApplyResources(this.blankPasswordCheckBox, "blankPasswordCheckBox");
			this.blankPasswordCheckBox.Name = "blankPasswordCheckBox";
			this.blankPasswordCheckBox.CheckedChanged += new System.EventHandler(blankPasswordCheckBox_CheckedChanged);
			componentResourceManager.ApplyResources(this.allowSavingPasswordCheckBox, "allowSavingPasswordCheckBox");
			this.allowSavingPasswordCheckBox.Name = "allowSavingPasswordCheckBox";
			this.allowSavingPasswordCheckBox.CheckedChanged += new System.EventHandler(allowSavingPasswordCheckBox_CheckedChanged);
			componentResourceManager.ApplyResources(this.nativeSecurityRadioButton, "nativeSecurityRadioButton");
			this.nativeSecurityRadioButton.Name = "nativeSecurityRadioButton";
			this.nativeSecurityRadioButton.CheckedChanged += new System.EventHandler(integratedSecurityRadioButton_CheckedChanged);
			componentResourceManager.ApplyResources(this.integratedSecurityRadioButton, "integratedSecurityRadioButton");
			this.integratedSecurityRadioButton.Name = "integratedSecurityRadioButton";
			this.integratedSecurityRadioButton.CheckedChanged += new System.EventHandler(integratedSecurityRadioButton_CheckedChanged);
			componentResourceManager.ApplyResources(this.initialCatalogLabel, "initialCatalogLabel");
			this.initialCatalogLabel.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.initialCatalogLabel.Name = "initialCatalogLabel";
			componentResourceManager.ApplyResources(this.initialCatalogComboBox, "initialCatalogComboBox");
			this.initialCatalogComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
			this.initialCatalogComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
			this.initialCatalogComboBox.FormattingEnabled = true;
			this.initialCatalogComboBox.Name = "initialCatalogComboBox";
			this.initialCatalogComboBox.Leave += new System.EventHandler(initialCatalogComboBox_Leave);
			this.initialCatalogComboBox.TextChanged += new System.EventHandler(initialCatalogComboBox_TextChanged);
			this.initialCatalogComboBox.KeyDown += new System.Windows.Forms.KeyEventHandler(initialCatalogComboBox_KeyDown);
			this.initialCatalogComboBox.DropDown += new System.EventHandler(initialCatalogComboBox_DropDown);
			componentResourceManager.ApplyResources(this, "$this");
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.Controls.Add(this.initialCatalogComboBox);
			base.Controls.Add(this.initialCatalogLabel);
			base.Controls.Add(this.logonGroupBox);
			base.Controls.Add(this.dataSourceGroupBox);
			base.Controls.Add(this.providerTableLayoutPanel);
			base.Controls.Add(this.providerLabel);
			this.MinimumSize = new System.Drawing.Size(350, 323);
			base.Name = "OleDBConnectionUIControl";
			this.providerTableLayoutPanel.ResumeLayout(false);
			this.providerTableLayoutPanel.PerformLayout();
			this.dataSourceGroupBox.ResumeLayout(false);
			this.dataSourceGroupBox.PerformLayout();
			this.dataSourceTableLayoutPanel.ResumeLayout(false);
			this.dataSourceTableLayoutPanel.PerformLayout();
			this.logonGroupBox.ResumeLayout(false);
			this.logonGroupBox.PerformLayout();
			this.loginTableLayoutPanel.ResumeLayout(false);
			this.loginTableLayoutPanel.PerformLayout();
			this.subLoginTableLayoutPanel.ResumeLayout(false);
			this.subLoginTableLayoutPanel.PerformLayout();
			this.subSubLoginTableLayoutPanel.ResumeLayout(false);
			this.subSubLoginTableLayoutPanel.PerformLayout();
			base.ResumeLayout(false);
			base.PerformLayout();
		}
	}
}
