using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Common;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Threading;
using DocumentServer.Data.ConnectionUI;
using DocumentServer.Properties;

namespace ns16
{
	internal class Class144 : IDataConnectionProperties, ICustomTypeDescriptor
	{
		[CompilerGenerated]
		private EventHandler eventHandler_0;

		private string string_0;

		private DbConnectionStringBuilder dbConnectionStringBuilder_0;

		private static ResourceManager resourceManager_0;

		public virtual bool IsExtensible => !this.dbConnectionStringBuilder_0.IsFixedSize;

		public virtual object this[string propertyName]
		{
			get
			{
				if (propertyName == null)
				{
					throw new ArgumentNullException("propertyName");
				}
				object value = null;
				if (!this.dbConnectionStringBuilder_0.TryGetValue(propertyName, out value))
				{
					return null;
				}
				if (this.dbConnectionStringBuilder_0.ShouldSerialize(propertyName))
				{
					return this.dbConnectionStringBuilder_0[propertyName];
				}
				object obj = this.dbConnectionStringBuilder_0[propertyName];
				if (obj != null)
				{
					return obj;
				}
				return DBNull.Value;
			}
			set
			{
				if (propertyName == null)
				{
					throw new ArgumentNullException("propertyName");
				}
				this.dbConnectionStringBuilder_0.Remove(propertyName);
				if (value == DBNull.Value)
				{
					this.method_0(EventArgs.Empty);
					return;
				}
				object value2 = null;
				this.dbConnectionStringBuilder_0.TryGetValue(propertyName, out value2);
				this.dbConnectionStringBuilder_0[propertyName] = value;
				if (object.Equals(value2, value))
				{
					this.dbConnectionStringBuilder_0.Remove(propertyName);
				}
				this.method_0(EventArgs.Empty);
			}
		}

		public virtual bool IsComplete => true;

		public DbConnectionStringBuilder DbConnectionStringBuilder_0 => this.dbConnectionStringBuilder_0;

		protected virtual PropertyDescriptor PropertyDescriptor_0 => TypeDescriptor.GetDefaultProperty(this.dbConnectionStringBuilder_0, noCustomTypeDesc: true);

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

		static Class144()
		{
			Class144.resourceManager_0 = new ResourceManager(typeof(Resources));
		}

		public Class144(string string_1)
		{
			this.string_0 = string_1;
			DbProviderFactory factory = DbProviderFactories.GetFactory(string_1);
			this.dbConnectionStringBuilder_0 = factory.CreateConnectionStringBuilder();
			this.dbConnectionStringBuilder_0.BrowsableConnectionString = false;
		}

		public virtual void Reset()
		{
			this.dbConnectionStringBuilder_0.Clear();
			this.method_0(EventArgs.Empty);
		}

		public virtual void Parse(string string_1)
		{
			this.dbConnectionStringBuilder_0.ConnectionString = string_1;
			this.method_0(EventArgs.Empty);
		}

		public virtual void Add(string propertyName)
		{
			if (!this.dbConnectionStringBuilder_0.ContainsKey(propertyName))
			{
				this.dbConnectionStringBuilder_0.Add(propertyName, string.Empty);
				this.method_0(EventArgs.Empty);
			}
		}

		public virtual bool Contains(string propertyName)
		{
			return this.dbConnectionStringBuilder_0.ContainsKey(propertyName);
		}

		public virtual void Remove(string propertyName)
		{
			if (this.dbConnectionStringBuilder_0.ContainsKey(propertyName))
			{
				this.dbConnectionStringBuilder_0.Remove(propertyName);
				this.method_0(EventArgs.Empty);
			}
		}

		public virtual void Reset(string propertyName)
		{
			if (this.dbConnectionStringBuilder_0.ContainsKey(propertyName))
			{
				this.dbConnectionStringBuilder_0.Remove(propertyName);
				this.method_0(EventArgs.Empty);
			}
		}

		public virtual void Test()
		{
			string text = this.vmethod_0();
			if (text != null && text.Length != 0)
			{
				DbConnection dbConnection = null;
				dbConnection = DbProviderFactories.GetFactory(this.string_0).CreateConnection();
				try
				{
					dbConnection.ConnectionString = text;
					dbConnection.Open();
					this.vmethod_1(dbConnection);
				}
				finally
				{
					dbConnection.Dispose();
				}
				return;
			}
			throw new InvalidOperationException(Class144.smethod_0("ADODOTNET_CONNECTION_PROPERTIES_NO_PROPERTIES"));
		}

		public override string ToString()
		{
			return this.ToFullString();
		}

		public virtual string ToFullString()
		{
			return this.dbConnectionStringBuilder_0.ConnectionString;
		}

		public virtual string ToDisplayString()
		{
			PropertyDescriptorCollection properties = this.GetProperties(new Attribute[1] { PasswordPropertyTextAttribute.Yes });
			List<KeyValuePair<string, object>> list = new List<KeyValuePair<string, object>>();
			foreach (PropertyDescriptor item in properties)
			{
				string displayName = item.DisplayName;
				if (this.DbConnectionStringBuilder_0.ShouldSerialize(displayName))
				{
					list.Add(new KeyValuePair<string, object>(displayName, this.DbConnectionStringBuilder_0[displayName]));
					this.DbConnectionStringBuilder_0.Remove(displayName);
				}
			}
			try
			{
				return this.DbConnectionStringBuilder_0.ConnectionString;
			}
			finally
			{
				foreach (KeyValuePair<string, object> item2 in list)
				{
					if (item2.Value != null)
					{
						this.DbConnectionStringBuilder_0[item2.Key] = item2.Value;
					}
				}
			}
		}

		protected virtual PropertyDescriptorCollection GetProperties(Attribute[] attributes)
		{
			return TypeDescriptor.GetProperties(this.dbConnectionStringBuilder_0, attributes);
		}

		internal void method_0(EventArgs eventArgs_0)
		{
			if (this.eventHandler_0 != null)
			{
				this.eventHandler_0(this, eventArgs_0);
			}
		}

		protected virtual string vmethod_0()
		{
			return this.dbConnectionStringBuilder_0.ConnectionString;
		}

		protected virtual void vmethod_1(DbConnection dbConnection_0)
		{
		}

		protected static string smethod_0(string string_1)
		{
			return Class144.resourceManager_0.GetString(string_1);
		}

		string ICustomTypeDescriptor.GetClassName()
		{
			return TypeDescriptor.GetClassName(this.dbConnectionStringBuilder_0, noCustomTypeDesc: true);
		}

		string ICustomTypeDescriptor.GetComponentName()
		{
			return TypeDescriptor.GetComponentName(this.dbConnectionStringBuilder_0, noCustomTypeDesc: true);
		}

		AttributeCollection ICustomTypeDescriptor.GetAttributes()
		{
			return TypeDescriptor.GetAttributes(this.dbConnectionStringBuilder_0, noCustomTypeDesc: true);
		}

		object ICustomTypeDescriptor.GetEditor(Type editorBaseType)
		{
			return TypeDescriptor.GetEditor(this.dbConnectionStringBuilder_0, editorBaseType, noCustomTypeDesc: true);
		}

		TypeConverter ICustomTypeDescriptor.GetConverter()
		{
			return TypeDescriptor.GetConverter(this.dbConnectionStringBuilder_0, noCustomTypeDesc: true);
		}

		PropertyDescriptor ICustomTypeDescriptor.GetDefaultProperty()
		{
			return this.PropertyDescriptor_0;
		}

		PropertyDescriptorCollection ICustomTypeDescriptor.GetProperties()
		{
			return this.GetProperties(new Attribute[0]);
		}

		PropertyDescriptorCollection ICustomTypeDescriptor.GetProperties(Attribute[] attributes)
		{
			return this.GetProperties(attributes);
		}

		EventDescriptor ICustomTypeDescriptor.GetDefaultEvent()
		{
			return TypeDescriptor.GetDefaultEvent(this.dbConnectionStringBuilder_0, noCustomTypeDesc: true);
		}

		EventDescriptorCollection ICustomTypeDescriptor.GetEvents()
		{
			return TypeDescriptor.GetEvents(this.dbConnectionStringBuilder_0, noCustomTypeDesc: true);
		}

		EventDescriptorCollection ICustomTypeDescriptor.GetEvents(Attribute[] attributes)
		{
			return TypeDescriptor.GetEvents(this.dbConnectionStringBuilder_0, attributes, noCustomTypeDesc: true);
		}

		object ICustomTypeDescriptor.GetPropertyOwner(PropertyDescriptor propertyDescriptor_0)
		{
			return this.dbConnectionStringBuilder_0;
		}
	}
}
