using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using ns16;
using DocumentServer.Data.ConnectionUI;
using DocumentServer.DataSources;
using DocumentServer.Properties;

namespace DocumentServer.Windows.Forms
{
	/// <summary>The DatabaseConnectionDialog class allows the user to build connection strings and to connect to specific data sources.</summary>
	public class DatabaseConnectionDialog : HighDpiForm
	{
		private class Class141 : IDataConnectionProperties
		{
			[CompilerGenerated]
			private EventHandler eventHandler_0;

			private string string_0;

			[Browsable(false)]
			public bool IsExtensible => false;

			public object this[string propertyName]
			{
				get
				{
					if (propertyName == "ConnectionString")
					{
						return this.String_0;
					}
					return null;
				}
				set
				{
					if (propertyName == "ConnectionString")
					{
						this.String_0 = value as string;
					}
				}
			}

			[Browsable(false)]
			public bool IsComplete => true;

			public string String_0
			{
				get
				{
					return this.ToFullString();
				}
				set
				{
					this.Parse(value);
				}
			}

			public event EventHandler PropertyChanged
			{
				[CompilerGenerated]
				add
				{
					EventHandler eventHandler = this.eventHandler_0;
					EventHandler eventHandler2;
					do
					{
						eventHandler2 = eventHandler;
						EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
						eventHandler = Interlocked.CompareExchange(ref this.eventHandler_0, value2, eventHandler2);
					}
					while ((object)eventHandler != eventHandler2);
				}
				[CompilerGenerated]
				remove
				{
					EventHandler eventHandler = this.eventHandler_0;
					EventHandler eventHandler2;
					do
					{
						eventHandler2 = eventHandler;
						EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
						eventHandler = Interlocked.CompareExchange(ref this.eventHandler_0, value2, eventHandler2);
					}
					while ((object)eventHandler != eventHandler2);
				}
			}

			public void Reset()
			{
				this.string_0 = string.Empty;
			}

			public void Parse(string string_1)
			{
				this.string_0 = string_1;
				if (this.eventHandler_0 != null)
				{
					this.eventHandler_0(this, EventArgs.Empty);
				}
			}

			public void Add(string propertyName)
			{
			}

			public bool Contains(string propertyName)
			{
				return propertyName == "ConnectionString";
			}

			public void Remove(string propertyName)
			{
			}

			public void Reset(string propertyName)
			{
				this.string_0 = string.Empty;
			}

			public void Test()
			{
			}

			public string ToFullString()
			{
				return this.string_0;
			}

			public string ToDisplayString()
			{
				return this.string_0;
			}
		}

		internal class Class142 : ICollection, IEnumerable
		{
			private List<Class154> list_0 = new List<Class154>();

			private DatabaseConnectionDialog databaseConnectionDialog_0;

			public int Count => this.list_0.Count;

			public bool Boolean_0 => this.databaseConnectionDialog_0.bool_0;

			public bool IsSynchronized => false;

			public object SyncRoot
			{
				get
				{
					throw new NotSupportedException();
				}
			}

			public Class142(DatabaseConnectionDialog databaseConnectionDialog_1)
			{
				this.databaseConnectionDialog_0 = databaseConnectionDialog_1;
			}

			public void method_0(Class154 class154_0)
			{
				if (class154_0 == null)
				{
					throw new ArgumentNullException("item");
				}
				if (this.databaseConnectionDialog_0.bool_0)
				{
					throw new InvalidOperationException(Resources.DATACONNECTION_DIALOG_CANT_MODIFY_STATE);
				}
				if (!this.list_0.Contains(class154_0))
				{
					this.list_0.Add(class154_0);
				}
			}

			public bool method_1(Class154 class154_0)
			{
				return this.list_0.Contains(class154_0);
			}

			public bool method_2(Class154 class154_0)
			{
				if (this.databaseConnectionDialog_0.bool_0)
				{
					throw new InvalidOperationException(Resources.DATACONNECTION_DIALOG_CANT_MODIFY_STATE);
				}
				bool result = this.list_0.Remove(class154_0);
				if (class154_0 == this.databaseConnectionDialog_0.Class154_1)
				{
					this.databaseConnectionDialog_0.method_11(null, bool_3: true);
				}
				return result;
			}

			public void method_3()
			{
				if (this.databaseConnectionDialog_0.bool_0)
				{
					throw new InvalidOperationException(Resources.DATACONNECTION_DIALOG_CANT_MODIFY_STATE);
				}
				this.list_0.Clear();
				this.databaseConnectionDialog_0.method_11(null, bool_3: true);
			}

			public void method_4(Class154[] class154_0, int int_0)
			{
				this.list_0.CopyTo(class154_0, int_0);
			}

			public IEnumerator GetEnumerator()
			{
				return this.list_0.GetEnumerator();
			}

			public void CopyTo(Array array, int index)
			{
				throw new NotSupportedException();
			}
		}

		private class PropertyGridUIControl : UserControl, IDataConnectionUIControl
		{
			private IDataConnectionProperties idataConnectionProperties_0;

			private DatabaseConnectionAdvancedDialog.Class152 propertyGrid;

			public PropertyGridUIControl()
			{
				this.propertyGrid = new DatabaseConnectionAdvancedDialog.Class152();
				base.SuspendLayout();
				this.propertyGrid.CommandsVisibleIfAvailable = true;
				this.propertyGrid.Dock = DockStyle.Fill;
				this.propertyGrid.Location = Point.Empty;
				this.propertyGrid.Margin = new Padding(0);
				this.propertyGrid.Name = "propertyGrid";
				this.propertyGrid.TabIndex = 0;
				base.Controls.Add(this.propertyGrid);
				base.Name = "PropertyGridUIControl";
				base.ResumeLayout(performLayout: false);
				base.PerformLayout();
			}

			public void Initialize(IDataConnectionProperties dataConnectionProperties)
			{
				this.idataConnectionProperties_0 = dataConnectionProperties;
			}

			public void LoadProperties()
			{
				this.propertyGrid.SelectedObject = this.idataConnectionProperties_0;
			}

			public override Size GetPreferredSize(Size proposedSize)
			{
				return this.propertyGrid.GetPreferredSize(proposedSize);
			}
		}

		private DataSourceManager dataSourceManager_0;

		[CompilerGenerated]
		private EventHandler eventHandler_0;

		[CompilerGenerated]
		private EventHandler<EventArgs0> eventHandler_1;

		[CompilerGenerated]
		private ThreadExceptionEventHandler threadExceptionEventHandler_0;

		private bool bool_0;

		private bool bool_1 = true;

		private string string_0;

		private string string_1 = string.Empty;

		private string string_2;

		private string string_3;

		private string string_4 = string.Empty;

		private Class142 class142_0;

		private Class154 class154_0 = Class154.smethod_1();

		private Class154 class154_1;

		private IDictionary<Class154, Class153> idictionary_0 = new Dictionary<Class154, Class153>();

		private bool bool_2 = true;

		private IDictionary<Class154, IDictionary<Class153, IDataConnectionUIControl>> idictionary_1 = new Dictionary<Class154, IDictionary<Class153, IDataConnectionUIControl>>();

		private IDictionary<Class154, IDictionary<Class153, IDataConnectionProperties>> idictionary_2 = new Dictionary<Class154, IDictionary<Class153, IDataConnectionProperties>>();

		private IContainer icontainer_0;

		private Label dataSourceLabel;

		private TextBox dataSourceTextBox;

		private ToolTip toolTip_0;

		private System.Windows.Forms.Button changeDataSourceButton;

		private System.Windows.Forms.Button advancedButton;

		private Panel separatorPanel;

		private System.Windows.Forms.Button testConnectionButton;

		private System.Windows.Forms.Button acceptButton;

		private System.Windows.Forms.Button cancelButton;

		private TableLayoutPanel tableLayoutPanel1;

		private TableLayoutPanel tableLayoutPanel2;

		internal string String_0
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

		internal bool Boolean_0
		{
			get
			{
				return this.bool_1;
			}
			set
			{
				this.bool_1 = value;
			}
		}

		internal string String_1
		{
			get
			{
				return this.string_0;
			}
			set
			{
				if (this.bool_0)
				{
					throw new InvalidOperationException(Resources.DATACONNECTION_DIALOG_CANT_MODIFY_STATE);
				}
				if (value == null)
				{
					value = string.Empty;
				}
				if (!(value == this.string_0))
				{
					this.string_0 = value;
				}
			}
		}

		internal string String_2
		{
			get
			{
				return this.string_1;
			}
			set
			{
				if (this.bool_0)
				{
					throw new InvalidOperationException(Resources.DATACONNECTION_DIALOG_CANT_MODIFY_STATE);
				}
				if (value == null)
				{
					value = string.Empty;
				}
				if (!(value == this.string_1))
				{
					this.string_1 = value;
				}
			}
		}

		internal string String_3
		{
			get
			{
				return this.string_2;
			}
			set
			{
				if (this.bool_0)
				{
					throw new InvalidOperationException(Resources.DATACONNECTION_DIALOG_CANT_MODIFY_STATE);
				}
				if (value == null)
				{
					value = string.Empty;
				}
				if (!(value == this.string_2))
				{
					this.string_2 = value;
				}
			}
		}

		internal string String_4
		{
			get
			{
				return this.string_3;
			}
			set
			{
				if (this.bool_0)
				{
					throw new InvalidOperationException(Resources.DATACONNECTION_DIALOG_CANT_MODIFY_STATE);
				}
				if (value == null)
				{
					value = string.Empty;
				}
				if (!(value == this.string_3))
				{
					this.string_3 = value;
				}
			}
		}

		internal string String_5
		{
			get
			{
				return this.string_4;
			}
			set
			{
				if (this.bool_0)
				{
					throw new InvalidOperationException(Resources.DATACONNECTION_DIALOG_CANT_MODIFY_STATE);
				}
				if (value == null)
				{
					value = string.Empty;
				}
				if (!(value == this.string_4))
				{
					this.string_4 = value;
				}
			}
		}

		internal Class142 Class142_0 => this.class142_0;

		internal Class154 Class154_0 => this.class154_0;

		internal Class154 Class154_1
		{
			get
			{
				if (this.class142_0 == null)
				{
					return null;
				}
				switch (this.class142_0.Count)
				{
				default:
					return this.class154_1;
				case 1:
				{
					IEnumerator enumerator = this.class142_0.GetEnumerator();
					enumerator.MoveNext();
					return (Class154)enumerator.Current;
				}
				case 0:
					return null;
				}
			}
			set
			{
				if (this.Class154_1 != value)
				{
					if (this.bool_0)
					{
						throw new InvalidOperationException(Resources.DATACONNECTION_DIALOG_CANT_MODIFY_STATE);
					}
					this.method_11(value, bool_3: false);
				}
			}
		}

		internal Class153 Class153_0
		{
			get
			{
				return this.method_4(this.Class154_1);
			}
			set
			{
				if (this.Class153_0 != value)
				{
					if (this.Class154_1 == null)
					{
						throw new InvalidOperationException(Resources.DATACONNECTION_DIALOG_NO_DATASOURCE_SELECTED);
					}
					this.method_5(this.Class154_1, value);
				}
			}
		}

		internal bool Boolean_1
		{
			get
			{
				return this.bool_2;
			}
			set
			{
				this.bool_2 = value;
			}
		}

		internal string String_6
		{
			get
			{
				string text = null;
				if (this.IDataConnectionProperties_0 != null)
				{
					try
					{
						text = this.IDataConnectionProperties_0.ToDisplayString();
					}
					catch
					{
					}
				}
				if (text == null)
				{
					return string.Empty;
				}
				return text;
			}
		}

		internal string String_7
		{
			get
			{
				string text = null;
				if (this.IDataConnectionProperties_0 != null)
				{
					try
					{
						text = this.IDataConnectionProperties_0.ToString();
					}
					catch
					{
					}
				}
				if (text == null)
				{
					return string.Empty;
				}
				return text;
			}
			set
			{
				if (this.bool_0)
				{
					throw new InvalidOperationException(Resources.DATACONNECTION_DIALOG_CANT_MODIFY_STATE);
				}
				if (this.Class153_0 == null)
				{
					throw new InvalidOperationException(Resources.DATACONNECTION_DIALOG_NO_DATAPROVIDER_SELECTED);
				}
				if (this.IDataConnectionProperties_0 != null)
				{
					this.IDataConnectionProperties_0.Parse(value);
				}
			}
		}

		internal string String_8
		{
			get
			{
				return this.acceptButton.Text;
			}
			set
			{
				this.acceptButton.Text = value;
			}
		}

		internal UserControl UserControl_0
		{
			get
			{
				if (this.Class153_0 == null)
				{
					return null;
				}
				if (!this.idictionary_1.ContainsKey(this.Class154_1))
				{
					this.idictionary_1[this.Class154_1] = new Dictionary<Class153, IDataConnectionUIControl>();
				}
				if (!this.idictionary_1[this.Class154_1].ContainsKey(this.Class153_0))
				{
					IDataConnectionUIControl dataConnectionUIControl = null;
					UserControl userControl = null;
					try
					{
						dataConnectionUIControl = ((this.Class154_1 != this.Class154_0) ? this.Class153_0.vmethod_1(this.Class154_1) : this.Class153_0.method_0());
						userControl = dataConnectionUIControl as UserControl;
						if (userControl == null)
						{
							IContainerControl containerControl = dataConnectionUIControl as IContainerControl;
							if (containerControl != null)
							{
								userControl = containerControl.ActiveControl as UserControl;
							}
						}
					}
					catch
					{
					}
					if (dataConnectionUIControl == null || userControl == null)
					{
						dataConnectionUIControl = new PropertyGridUIControl();
						userControl = dataConnectionUIControl as UserControl;
					}
					userControl.Location = Point.Empty;
					userControl.Anchor = AnchorStyles.Top | AnchorStyles.Left;
					userControl.AutoSize = false;
					try
					{
						dataConnectionUIControl.Initialize(this.IDataConnectionProperties_0);
					}
					catch
					{
					}
					this.idictionary_1[this.Class154_1][this.Class153_0] = dataConnectionUIControl;
					this.icontainer_0.Add(userControl);
				}
				UserControl userControl2 = this.idictionary_1[this.Class154_1][this.Class153_0] as UserControl;
				if (userControl2 == null)
				{
					userControl2 = (this.idictionary_1[this.Class154_1][this.Class153_0] as IContainerControl).ActiveControl as UserControl;
				}
				return userControl2;
			}
		}

		internal IDataConnectionProperties IDataConnectionProperties_0
		{
			get
			{
				if (this.Class153_0 == null)
				{
					return null;
				}
				if (!this.idictionary_2.ContainsKey(this.Class154_1))
				{
					this.idictionary_2[this.Class154_1] = new Dictionary<Class153, IDataConnectionProperties>();
				}
				if (!this.idictionary_2[this.Class154_1].ContainsKey(this.Class153_0))
				{
					IDataConnectionProperties dataConnectionProperties = null;
					dataConnectionProperties = ((this.Class154_1 != this.Class154_0) ? this.Class153_0.vmethod_2(this.Class154_1) : this.Class153_0.method_1());
					if (dataConnectionProperties == null)
					{
						dataConnectionProperties = new Class141();
					}
					dataConnectionProperties.PropertyChanged += method_15;
					this.idictionary_2[this.Class154_1][this.Class153_0] = dataConnectionProperties;
				}
				return this.idictionary_2[this.Class154_1][this.Class153_0];
			}
		}

		internal event EventHandler VerifySettings
		{
			[CompilerGenerated]
			add
			{
				EventHandler eventHandler = this.eventHandler_0;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange(ref this.eventHandler_0, value2, eventHandler2);
				}
				while ((object)eventHandler != eventHandler2);
			}
			[CompilerGenerated]
			remove
			{
				EventHandler eventHandler = this.eventHandler_0;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange(ref this.eventHandler_0, value2, eventHandler2);
				}
				while ((object)eventHandler != eventHandler2);
			}
		}

		internal event EventHandler<EventArgs0> ContextHelpRequested
		{
			[CompilerGenerated]
			add
			{
				EventHandler<EventArgs0> eventHandler = this.eventHandler_1;
				EventHandler<EventArgs0> eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler<EventArgs0> value2 = (EventHandler<EventArgs0>)Delegate.Combine(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange(ref this.eventHandler_1, value2, eventHandler2);
				}
				while ((object)eventHandler != eventHandler2);
			}
			[CompilerGenerated]
			remove
			{
				EventHandler<EventArgs0> eventHandler = this.eventHandler_1;
				EventHandler<EventArgs0> eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler<EventArgs0> value2 = (EventHandler<EventArgs0>)Delegate.Remove(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange(ref this.eventHandler_1, value2, eventHandler2);
				}
				while ((object)eventHandler != eventHandler2);
			}
		}

		internal event ThreadExceptionEventHandler DialogException
		{
			[CompilerGenerated]
			add
			{
				ThreadExceptionEventHandler threadExceptionEventHandler = this.threadExceptionEventHandler_0;
				ThreadExceptionEventHandler threadExceptionEventHandler2;
				do
				{
					threadExceptionEventHandler2 = threadExceptionEventHandler;
					ThreadExceptionEventHandler value2 = (ThreadExceptionEventHandler)Delegate.Combine(threadExceptionEventHandler2, value);
					threadExceptionEventHandler = Interlocked.CompareExchange(ref this.threadExceptionEventHandler_0, value2, threadExceptionEventHandler2);
				}
				while ((object)threadExceptionEventHandler != threadExceptionEventHandler2);
			}
			[CompilerGenerated]
			remove
			{
				ThreadExceptionEventHandler threadExceptionEventHandler = this.threadExceptionEventHandler_0;
				ThreadExceptionEventHandler threadExceptionEventHandler2;
				do
				{
					threadExceptionEventHandler2 = threadExceptionEventHandler;
					ThreadExceptionEventHandler value2 = (ThreadExceptionEventHandler)Delegate.Remove(threadExceptionEventHandler2, value);
					threadExceptionEventHandler = Interlocked.CompareExchange(ref this.threadExceptionEventHandler_0, value2, threadExceptionEventHandler2);
				}
				while ((object)threadExceptionEventHandler != threadExceptionEventHandler2);
			}
		}

		public DatabaseConnectionDialog(DataSourceManager dataSourceManager)
		{
			this.InitializeComponent();
			this.dataSourceTextBox.Width = 0;
			this.dataSourceManager_0 = dataSourceManager;
			this.icontainer_0.Add(new Class166(this));
			this.string_0 = Resources.DATACONNECTIONSOURCE_DIALOG_TITLE;
			this.string_2 = Resources.DATACONNECTIONSOURCE_DIALOG_BUTTON_OK;
			this.string_3 = Resources.DATACONNECTION_DIALOG_CHANGE_DATASOURCE_TITLE;
			this.class142_0 = new Class142(this);
			this.Text = Resources.DATACONNECTION_DIALOG_TITLE;
			this.acceptButton.Text = Resources.DATACONNECTION_DIALOG_BUTTON_ACCEPT;
			this.advancedButton.Text = Resources.DATACONNECTION_DIALOG_BUTTON_ADVANCED;
			this.cancelButton.Text = Resources.DATACONNECTION_DIALOG_BUTTON_CANCEL;
			this.changeDataSourceButton.Text = Resources.DATACONNECTION_DIALOG_BUTTON_CHANGE;
			this.dataSourceLabel.Text = Resources.DATACONNECTION_DIALOG_LABEL_DATASOURCE;
			this.testConnectionButton.Text = Resources.DATACONNECTION_DIALOG_BUTTON_TEST_CONNECTION;
			this.method_3();
		}

		public new void Show(IWin32Window owner)
		{
			throw new NotSupportedException();
		}

		public new void Show()
		{
			this.Show(null);
		}

		public new DialogResult ShowDialog()
		{
			return this.ShowDialog(null);
		}

		public new DialogResult ShowDialog(IWin32Window owner)
		{
			DialogResult num = DatabaseConnectionDialog.smethod_0(this, owner);
			if (num == DialogResult.OK)
			{
				this.dataSourceManager_0.method_23(this.Class153_0.Name, this.String_7);
			}
			return num;
		}

		private DialogResult method_2(IWin32Window iwin32Window_0)
		{
			return base.ShowDialog(iwin32Window_0);
		}

		private static DialogResult smethod_0(DatabaseConnectionDialog databaseConnectionDialog_0, IWin32Window iwin32Window_0)
		{
			if (databaseConnectionDialog_0 == null)
			{
				throw new ArgumentNullException("dialog");
			}
			Form form = iwin32Window_0 as Form;
			if (databaseConnectionDialog_0.Class142_0.Count == 0)
			{
				throw new InvalidOperationException(Resources.DATACONNECTION_DIALOG_NO_DATASOURCES_AVAILABLE);
			}
			foreach (Class154 item in databaseConnectionDialog_0.Class142_0)
			{
				if (item.Class155_0.Count == 0)
				{
					throw new InvalidOperationException(string.Format(Resources.DATACONNECTION_DIALOG_NO_DATA_PROV_FOR_DATASOURCE, item.String_1.Replace("'", "''")));
				}
			}
			Application.ThreadException += databaseConnectionDialog_0.method_16;
			databaseConnectionDialog_0.bool_0 = true;
			try
			{
				if (databaseConnectionDialog_0.Class154_1 != null && databaseConnectionDialog_0.Class153_0 != null)
				{
					databaseConnectionDialog_0.bool_2 = false;
				}
				else
				{
					DatabaseConnectionSourceDialog databaseConnectionSourceDialog = new DatabaseConnectionSourceDialog(databaseConnectionDialog_0);
					if (form != null)
					{
						databaseConnectionSourceDialog.RightToLeft = form.RightToLeft;
					}
					databaseConnectionSourceDialog.Title = databaseConnectionDialog_0.String_1;
					databaseConnectionSourceDialog.HeaderLabel = databaseConnectionDialog_0.String_2;
					(databaseConnectionSourceDialog.AcceptButton as System.Windows.Forms.Button).Text = databaseConnectionDialog_0.String_3;
					if (databaseConnectionDialog_0.Container != null)
					{
						databaseConnectionDialog_0.Container.Add(databaseConnectionSourceDialog);
					}
					try
					{
						if (form == null)
						{
							databaseConnectionSourceDialog.StartPosition = FormStartPosition.CenterScreen;
						}
						databaseConnectionSourceDialog.ShowDialog(iwin32Window_0);
						if (databaseConnectionDialog_0.Class154_1 == null || databaseConnectionDialog_0.Class153_0 == null)
						{
							return DialogResult.Cancel;
						}
					}
					finally
					{
						if (databaseConnectionDialog_0.Container != null)
						{
							databaseConnectionDialog_0.Container.Remove(databaseConnectionSourceDialog);
						}
						databaseConnectionSourceDialog.Dispose();
					}
				}
				if (iwin32Window_0 == null)
				{
					databaseConnectionDialog_0.StartPosition = FormStartPosition.CenterScreen;
				}
				DialogResult dialogResult;
				while (true)
				{
					dialogResult = databaseConnectionDialog_0.method_2(iwin32Window_0);
					if (dialogResult != DialogResult.Ignore)
					{
						break;
					}
					DatabaseConnectionSourceDialog databaseConnectionSourceDialog2 = new DatabaseConnectionSourceDialog(databaseConnectionDialog_0);
					if (form != null)
					{
						databaseConnectionSourceDialog2.RightToLeft = form.RightToLeft;
					}
					databaseConnectionSourceDialog2.Title = databaseConnectionDialog_0.String_4;
					databaseConnectionSourceDialog2.HeaderLabel = databaseConnectionDialog_0.String_5;
					if (databaseConnectionDialog_0.Container != null)
					{
						databaseConnectionDialog_0.Container.Add(databaseConnectionSourceDialog2);
					}
					try
					{
						if (iwin32Window_0 == null)
						{
							databaseConnectionSourceDialog2.StartPosition = FormStartPosition.CenterScreen;
						}
						dialogResult = databaseConnectionSourceDialog2.ShowDialog(iwin32Window_0);
					}
					finally
					{
						if (databaseConnectionDialog_0.Container != null)
						{
							databaseConnectionDialog_0.Container.Remove(databaseConnectionSourceDialog2);
						}
						databaseConnectionSourceDialog2.Dispose();
					}
				}
				return dialogResult;
			}
			finally
			{
				databaseConnectionDialog_0.bool_0 = false;
				Application.ThreadException -= databaseConnectionDialog_0.method_16;
			}
		}

		private void method_3()
		{
			this.Class142_0.method_0(Class154.Class154_0);
			this.Class142_0.method_0(Class154.Class154_1);
			this.Class142_0.method_0(Class154.Class154_2);
			this.Class142_0.method_0(Class154.Class154_3);
			this.Class154_0.Class155_0.method_0(Class153.Class153_0);
			this.Class154_0.Class155_0.method_0(Class153.Class153_1);
			this.Class154_0.Class155_0.method_0(Class153.Class153_2);
			this.Class142_0.method_0(this.Class154_0);
		}

		internal Class153 method_4(Class154 class154_2)
		{
			if (class154_2 == null)
			{
				return null;
			}
			switch (class154_2.Class155_0.Count)
			{
			default:
				if (!this.idictionary_0.ContainsKey(class154_2))
				{
					return class154_2.Class153_0;
				}
				return this.idictionary_0[class154_2];
			case 1:
			{
				IEnumerator enumerator = class154_2.Class155_0.GetEnumerator();
				enumerator.MoveNext();
				return (Class153)enumerator.Current;
			}
			case 0:
				return null;
			}
		}

		internal void method_5(Class154 class154_2, Class153 class153_0)
		{
			if (this.method_4(class154_2) != class153_0)
			{
				if (class154_2 == null)
				{
					throw new ArgumentNullException("dataSource");
				}
				if (this.bool_0)
				{
					throw new InvalidOperationException(Resources.DATACONNECTION_DIALOG_CANT_MODIFY_STATE);
				}
				this.method_12(class154_2, class153_0, bool_3: false);
			}
		}

		protected override void OnLoad(EventArgs eventArgs_0)
		{
			if (!this.bool_0)
			{
				throw new NotSupportedException(Resources.DATACONNECTION_DIALOG_SHOW_DIALOG_NOT_SUPPORTED);
			}
			this.method_13();
			this.method_14();
			this.method_15(this, EventArgs.Empty);
			base.OnLoad(eventArgs_0);
		}

		protected override void OnShown(EventArgs eventArgs_0)
		{
			base.OnShown(eventArgs_0);
			if (this.UserControl_0 != null)
			{
				this.UserControl_0.Focus();
			}
		}

		internal void method_6(EventArgs eventArgs_0)
		{
			if (this.eventHandler_0 != null)
			{
				this.eventHandler_0(this, eventArgs_0);
			}
		}

		internal void method_7(EventArgs0 eventArgs0_0)
		{
			if (this.eventHandler_1 != null)
			{
				this.eventHandler_1(this, eventArgs0_0);
			}
			if (!eventArgs0_0.Handled)
			{
				this.method_19(null, Resources.DATACONNECTION_DIALOG_NO_HELP_AVAILABLE);
				eventArgs0_0.Handled = true;
			}
		}

		protected override void OnHelpRequested(HelpEventArgs hevent)
		{
			Control control = this;
			ContainerControl containerControl = null;
			while ((containerControl = control as ContainerControl) != null && containerControl != this.UserControl_0 && containerControl.ActiveControl != null)
			{
				control = containerControl.ActiveControl;
			}
			Enum29 enum29_ = Enum29.const_6;
			if (control == this.dataSourceTextBox)
			{
				enum29_ = Enum29.const_7;
			}
			if (control == this.changeDataSourceButton)
			{
				enum29_ = Enum29.const_8;
			}
			if (control == this.UserControl_0)
			{
				enum29_ = Enum29.const_9;
				if (this.UserControl_0 is SqlConnectionUIControl)
				{
					enum29_ = Enum29.const_10;
				}
				if (this.UserControl_0 is SqlFileConnectionUIControl)
				{
					enum29_ = Enum29.const_11;
				}
				if (this.UserControl_0 is AccessConnectionUIControl)
				{
					enum29_ = Enum29.const_12;
				}
				if (this.UserControl_0 is OleDBConnectionUIControl)
				{
					enum29_ = Enum29.const_13;
				}
				if (this.UserControl_0 is OdbcConnectionUIControl)
				{
					enum29_ = Enum29.const_14;
				}
				if (this.UserControl_0 is PropertyGridUIControl)
				{
					enum29_ = Enum29.const_15;
				}
			}
			if (control == this.advancedButton)
			{
				enum29_ = Enum29.const_16;
			}
			if (control == this.testConnectionButton)
			{
				enum29_ = Enum29.const_17;
			}
			if (control == this.acceptButton)
			{
				enum29_ = Enum29.const_18;
			}
			if (control == this.cancelButton)
			{
				enum29_ = Enum29.const_19;
			}
			EventArgs0 eventArgs = new EventArgs0(enum29_, hevent.MousePos);
			this.method_7(eventArgs);
			hevent.Handled = eventArgs.Handled;
			if (!eventArgs.Handled)
			{
				base.OnHelpRequested(hevent);
			}
		}

		internal void method_8(ThreadExceptionEventArgs threadExceptionEventArgs_0)
		{
			if (this.threadExceptionEventHandler_0 != null)
			{
				this.threadExceptionEventHandler_0(this, threadExceptionEventArgs_0);
			}
			else
			{
				this.method_18(null, threadExceptionEventArgs_0.Exception);
			}
		}

		protected override void OnFormClosing(FormClosingEventArgs formClosingEventArgs_0)
		{
			if (base.DialogResult == DialogResult.OK)
			{
				try
				{
					this.method_6(EventArgs.Empty);
				}
				catch (Exception ex)
				{
					ExternalException ex2 = ex as ExternalException;
					if (ex2 == null || ex2.ErrorCode != -2147217842)
					{
						this.method_18(null, ex);
					}
					formClosingEventArgs_0.Cancel = true;
				}
			}
			base.OnFormClosing(formClosingEventArgs_0);
		}

		[SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.UnmanagedCode)]
		protected override void WndProc(ref Message message)
		{
			if (this.bool_1 && Class157.smethod_0(ref message))
			{
				Class157.smethod_3(this, ref message);
				base.DefWndProc(ref message);
			}
			else
			{
				base.WndProc(ref message);
			}
		}

		internal void method_9(Class154 class154_2)
		{
			this.method_11(class154_2, bool_3: false);
		}

		internal void method_10(Class154 class154_2, Class153 class153_0)
		{
			this.method_12(class154_2, class153_0, bool_3: false);
		}

		private void method_11(Class154 class154_2, bool bool_3)
		{
			if (!bool_3 && this.class142_0.Count == 1 && this.class154_1 != class154_2)
			{
				IEnumerator enumerator = this.class142_0.GetEnumerator();
				enumerator.MoveNext();
				if (class154_2 != enumerator.Current)
				{
					throw new InvalidOperationException(Resources.DATACONNECTION_DIALOG_CANT_CHANGE_SINGLE_DATASOURCE);
				}
			}
			if (this.class154_1 == class154_2)
			{
				return;
			}
			if (class154_2 != null)
			{
				if (!this.class142_0.method_1(class154_2))
				{
					throw new InvalidOperationException(Resources.DATACONNECTION_DIALOG_DATASOURCE_NOT_FOUND);
				}
				this.class154_1 = class154_2;
				switch (this.class154_1.Class155_0.Count)
				{
				default:
				{
					Class153 class153_ = this.class154_1.Class153_0;
					if (this.idictionary_0.ContainsKey(this.class154_1))
					{
						class153_ = this.idictionary_0[this.class154_1];
					}
					this.method_12(this.class154_1, class153_, bool_3);
					break;
				}
				case 1:
				{
					IEnumerator enumerator2 = this.class154_1.Class155_0.GetEnumerator();
					enumerator2.MoveNext();
					this.method_12(this.class154_1, (Class153)enumerator2.Current, bool_3: true);
					break;
				}
				case 0:
					this.method_12(this.class154_1, null, bool_3);
					break;
				}
			}
			else
			{
				this.class154_1 = null;
			}
			if (this.bool_0)
			{
				this.method_13();
			}
		}

		private void method_12(Class154 class154_2, Class153 class153_0, bool bool_3)
		{
			if (!bool_3 && class154_2.Class155_0.Count == 1 && ((this.idictionary_0.ContainsKey(class154_2) && this.idictionary_0[class154_2] != class153_0) || (!this.idictionary_0.ContainsKey(class154_2) && class153_0 != null)))
			{
				IEnumerator enumerator = class154_2.Class155_0.GetEnumerator();
				enumerator.MoveNext();
				if (class153_0 != (Class153)enumerator.Current)
				{
					throw new InvalidOperationException(Resources.DATACONNECTION_DIALOG_CANT_CHANGE_SINGLE_DATAPROVIDER);
				}
			}
			if ((!this.idictionary_0.ContainsKey(class154_2) || this.idictionary_0[class154_2] == class153_0) && (this.idictionary_0.ContainsKey(class154_2) || class153_0 == null))
			{
				return;
			}
			if (class153_0 != null)
			{
				if (!class154_2.Class155_0.method_1(class153_0))
				{
					throw new InvalidOperationException(Resources.DATACONNECTION_DIALOG_DATASOURCE_NO_ASSOC);
				}
				this.idictionary_0[class154_2] = class153_0;
			}
			else if (this.idictionary_0.ContainsKey(class154_2))
			{
				this.idictionary_0.Remove(class154_2);
			}
		}

		private void method_13()
		{
			if (this.Class154_1 != null)
			{
				if (this.Class154_1 == this.Class154_0)
				{
					if (this.Class153_0 != null)
					{
						this.dataSourceTextBox.Text = this.Class153_0.DisplayName;
					}
					else
					{
						this.dataSourceTextBox.Text = null;
					}
					this.toolTip_0.SetToolTip(this.dataSourceTextBox, null);
				}
				else
				{
					this.dataSourceTextBox.Text = this.Class154_1.String_1;
					if (this.Class153_0 != null)
					{
						if (this.Class153_0.ShortDisplayName != null)
						{
							this.dataSourceTextBox.Text = string.Format(Resources.DATACONNECTION_DIALOG_DATASOURCE_WITH_SHORT_PROVIDER, this.dataSourceTextBox.Text, this.Class153_0.ShortDisplayName);
						}
						this.toolTip_0.SetToolTip(this.dataSourceTextBox, this.Class153_0.DisplayName);
					}
					else
					{
						this.toolTip_0.SetToolTip(this.dataSourceTextBox, null);
					}
				}
			}
			else
			{
				this.dataSourceTextBox.Text = null;
				this.toolTip_0.SetToolTip(this.dataSourceTextBox, null);
			}
			this.dataSourceTextBox.Select(0, 0);
		}

		private void method_14()
		{
			this.changeDataSourceButton.Enabled = this.Class142_0.Count > 1 || this.Class154_1.Class155_0.Count > 1;
		}

		private void changeDataSourceButton_Click(object sender, EventArgs e)
		{
			base.DialogResult = DialogResult.Ignore;
			base.Close();
		}

		private void advancedButton_Click(object sender, EventArgs e)
		{
			DatabaseConnectionAdvancedDialog databaseConnectionAdvancedDialog = new DatabaseConnectionAdvancedDialog(this.IDataConnectionProperties_0, this);
			DialogResult dialogResult = DialogResult.None;
			try
			{
				if (base.Container != null)
				{
					base.Container.Add(databaseConnectionAdvancedDialog);
				}
				dialogResult = databaseConnectionAdvancedDialog.ShowDialog(this);
			}
			finally
			{
				if (base.Container != null)
				{
					base.Container.Remove(databaseConnectionAdvancedDialog);
				}
				databaseConnectionAdvancedDialog.Dispose();
			}
			if (dialogResult == DialogResult.OK && this.UserControl_0 != null)
			{
				try
				{
					this.idictionary_1[this.Class154_1][this.Class153_0].LoadProperties();
				}
				catch
				{
				}
				this.method_15(this, EventArgs.Empty);
			}
		}

		private void testConnectionButton_Click(object sender, EventArgs e)
		{
			Cursor current = Cursor.Current;
			Cursor.Current = Cursors.WaitCursor;
			try
			{
				this.IDataConnectionProperties_0.Test();
			}
			catch (Exception exception_)
			{
				Cursor.Current = current;
				this.method_18(Resources.DATACONNECTION_DIALOG_TEST_RESULTS, exception_);
				return;
			}
			Cursor.Current = current;
			this.method_17(Resources.DATACONNECTION_DIALOG_TEST_RESULTS, Resources.DATACONNECTION_DIALOG_TEST_CONNECTION_SUCCEEDED);
		}

		private void method_15(object sender, EventArgs e)
		{
			try
			{
				this.acceptButton.Enabled = this.IDataConnectionProperties_0 != null && this.IDataConnectionProperties_0.IsComplete;
			}
			catch
			{
				this.acceptButton.Enabled = true;
			}
		}

		private void acceptButton_Click(object sender, EventArgs e)
		{
			this.acceptButton.Focus();
		}

		private void separatorPanel_Paint(object sender, PaintEventArgs e)
		{
			Graphics graphics = e.Graphics;
			Pen pen = new Pen(ControlPaint.Dark(this.BackColor, 0f));
			Pen pen2 = new Pen(ControlPaint.Light(this.BackColor, 1f));
			int x = this.separatorPanel.Width;
			graphics.DrawLine(pen, 0, 0, x, 0);
			graphics.DrawLine(pen2, 0, 1, x, 1);
		}

		private void method_16(object sender, ThreadExceptionEventArgs e)
		{
			this.method_8(e);
		}

		private void method_17(string string_5, string string_6)
		{
			IUIService iUIService = this.GetService(typeof(IUIService)) as IUIService;
			if (iUIService != null)
			{
				iUIService.ShowMessage(string_6);
			}
			else
			{
				Class163.smethod_0(string_5, string_6, MessageBoxIcon.Asterisk);
			}
		}

		private void method_18(string string_5, Exception exception_0)
		{
			IUIService iUIService = this.GetService(typeof(IUIService)) as IUIService;
			if (iUIService != null)
			{
				iUIService.ShowError(exception_0);
			}
			else
			{
				Class163.smethod_0(string_5, exception_0.Message, MessageBoxIcon.Exclamation);
			}
		}

		private void method_19(string string_5, string string_6)
		{
			IUIService iUIService = this.GetService(typeof(IUIService)) as IUIService;
			if (iUIService != null)
			{
				iUIService.ShowError(string_6);
			}
			else
			{
				Class163.smethod_0(string_5, string_6, MessageBoxIcon.Exclamation);
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
			this.icontainer_0 = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager componentResourceManager = new System.ComponentModel.ComponentResourceManager(typeof(DocumentServer.Windows.Forms.DatabaseConnectionDialog));
			this.dataSourceLabel = new System.Windows.Forms.Label();
			this.dataSourceTextBox = new System.Windows.Forms.TextBox();
			this.changeDataSourceButton = new System.Windows.Forms.Button();
			this.advancedButton = new System.Windows.Forms.Button();
			this.separatorPanel = new System.Windows.Forms.Panel();
			this.testConnectionButton = new System.Windows.Forms.Button();
			this.acceptButton = new System.Windows.Forms.Button();
			this.cancelButton = new System.Windows.Forms.Button();
			this.toolTip_0 = new System.Windows.Forms.ToolTip(this.icontainer_0);
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
			this.tableLayoutPanel1.SuspendLayout();
			this.tableLayoutPanel2.SuspendLayout();
			base.SuspendLayout();
			componentResourceManager.ApplyResources(this.dataSourceLabel, "dataSourceLabel");
			this.tableLayoutPanel2.SetColumnSpan(this.dataSourceLabel, 2);
			this.dataSourceLabel.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.dataSourceLabel.Name = "dataSourceLabel";
			componentResourceManager.ApplyResources(this.dataSourceTextBox, "dataSourceTextBox");
			this.dataSourceTextBox.Name = "dataSourceTextBox";
			this.dataSourceTextBox.ReadOnly = true;
			componentResourceManager.ApplyResources(this.changeDataSourceButton, "changeDataSourceButton");
			this.changeDataSourceButton.Name = "changeDataSourceButton";
			this.changeDataSourceButton.Click += new System.EventHandler(changeDataSourceButton_Click);
			componentResourceManager.ApplyResources(this.advancedButton, "advancedButton");
			this.advancedButton.Name = "advancedButton";
			this.advancedButton.Click += new System.EventHandler(advancedButton_Click);
			this.tableLayoutPanel2.SetColumnSpan(this.separatorPanel, 2);
			componentResourceManager.ApplyResources(this.separatorPanel, "separatorPanel");
			this.separatorPanel.Name = "separatorPanel";
			this.separatorPanel.Paint += new System.Windows.Forms.PaintEventHandler(separatorPanel_Paint);
			componentResourceManager.ApplyResources(this.testConnectionButton, "testConnectionButton");
			this.testConnectionButton.Name = "testConnectionButton";
			this.testConnectionButton.Click += new System.EventHandler(testConnectionButton_Click);
			componentResourceManager.ApplyResources(this.acceptButton, "acceptButton");
			this.acceptButton.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.acceptButton.Name = "acceptButton";
			this.acceptButton.Click += new System.EventHandler(acceptButton_Click);
			componentResourceManager.ApplyResources(this.cancelButton, "cancelButton");
			this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cancelButton.Name = "cancelButton";
			componentResourceManager.ApplyResources(this.tableLayoutPanel1, "tableLayoutPanel1");
			this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.cancelButton, 3, 1);
			this.tableLayoutPanel1.Controls.Add(this.acceptButton, 2, 1);
			this.tableLayoutPanel1.Controls.Add(this.testConnectionButton, 0, 1);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			componentResourceManager.ApplyResources(this.tableLayoutPanel2, "tableLayoutPanel2");
			this.tableLayoutPanel1.SetColumnSpan(this.tableLayoutPanel2, 4);
			this.tableLayoutPanel2.Controls.Add(this.changeDataSourceButton, 1, 1);
			this.tableLayoutPanel2.Controls.Add(this.dataSourceTextBox, 0, 1);
			this.tableLayoutPanel2.Controls.Add(this.separatorPanel, 0, 3);
			this.tableLayoutPanel2.Controls.Add(this.dataSourceLabel, 0, 0);
			this.tableLayoutPanel2.Controls.Add(this.advancedButton, 1, 2);
			this.tableLayoutPanel2.Name = "tableLayoutPanel2";
			base.AcceptButton = this.acceptButton;
			componentResourceManager.ApplyResources(this, "$this");
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.CancelButton = this.cancelButton;
			base.Controls.Add(this.tableLayoutPanel1);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.HelpButton = true;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "DatabaseConnectionDialog";
			base.ShowIcon = false;
			base.ShowInTaskbar = false;
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			this.tableLayoutPanel2.ResumeLayout(false);
			this.tableLayoutPanel2.PerformLayout();
			base.ResumeLayout(false);
			base.PerformLayout();
		}
	}
}
