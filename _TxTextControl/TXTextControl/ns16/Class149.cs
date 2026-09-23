using System;
using System.ComponentModel;
using Microsoft.Win32;

namespace ns16
{
	internal class Class149 : Class147
	{
		private class Class162 : StringConverter
		{
			public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
			{
				return true;
			}

			public override bool GetStandardValuesExclusive(ITypeDescriptorContext context)
			{
				return true;
			}

			public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
			{
				return new StandardValuesCollection(new string[2] { "Microsoft.Jet.OLEDB.4.0", "Microsoft.ACE.OLEDB.12.0" });
			}
		}

		private static bool bool_1;

		private static bool bool_2;

		private bool bool_3;

		public override object this[string propertyName]
		{
			set
			{
				base[propertyName] = value;
				if (string.Equals(propertyName, "Provider", StringComparison.OrdinalIgnoreCase))
				{
					if (value != null && value != DBNull.Value)
					{
						this.method_3(base.DbConnectionStringBuilder_0, EventArgs.Empty);
					}
					else
					{
						this.bool_3 = false;
					}
				}
				if (string.Equals(propertyName, "Data Source", StringComparison.Ordinal))
				{
					this.method_4(base.DbConnectionStringBuilder_0, EventArgs.Empty);
				}
			}
		}

		public override bool IsComplete
		{
			get
			{
				if (!base.IsComplete)
				{
					return false;
				}
				if (base.DbConnectionStringBuilder_0["Data Source"] is string && (base.DbConnectionStringBuilder_0["Data Source"] as string).Length != 0)
				{
					return true;
				}
				return false;
			}
		}

		private static bool Boolean_1
		{
			get
			{
				if (!Class149.bool_2)
				{
					RegistryKey registryKey = null;
					try
					{
						registryKey = Registry.ClassesRoot.OpenSubKey("Microsoft.ACE.OLEDB.12.0");
						Class149.bool_1 = registryKey != null;
					}
					finally
					{
						registryKey?.Close();
					}
					Class149.bool_2 = true;
				}
				return Class149.bool_1;
			}
		}

		public Class149()
			: base("Microsoft.Jet.OLEDB.4.0")
		{
			this.bool_3 = false;
		}

		public override void Reset()
		{
			base.Reset();
			this.bool_3 = false;
		}

		public override void Remove(string propertyName)
		{
			base.Remove(propertyName);
			if (string.Equals(propertyName, "Provider", StringComparison.OrdinalIgnoreCase))
			{
				this.bool_3 = false;
			}
			if (string.Equals(propertyName, "Data Source", StringComparison.Ordinal))
			{
				this.method_4(base.DbConnectionStringBuilder_0, EventArgs.Empty);
			}
		}

		public override void Reset(string propertyName)
		{
			base.Reset(propertyName);
			if (string.Equals(propertyName, "Provider", StringComparison.OrdinalIgnoreCase))
			{
				this.bool_3 = false;
			}
			if (string.Equals(propertyName, "Data Source", StringComparison.Ordinal))
			{
				this.method_4(base.DbConnectionStringBuilder_0, EventArgs.Empty);
			}
		}

		public override void Test()
		{
			string text = base.DbConnectionStringBuilder_0["Data Source"] as string;
			if (text == null || text.Length == 0)
			{
				throw new InvalidOperationException(Class144.smethod_0("OLEDB_ACCESS_CONNECTION_PROPERTIES_MUST_SPECIFY_DATASOURCE"));
			}
			base.Test();
		}

		public override string ToDisplayString()
		{
			string text = null;
			if (base.DbConnectionStringBuilder_0.ContainsKey("Jet OLEDB:Database Password") && base.DbConnectionStringBuilder_0.ShouldSerialize("Jet OLEDB:Database Password"))
			{
				text = base.DbConnectionStringBuilder_0["Jet OLEDB:Database Password"] as string;
				base.DbConnectionStringBuilder_0.Remove("Jet OLEDB:Database Password");
			}
			string result = base.ToDisplayString();
			if (text != null)
			{
				base.DbConnectionStringBuilder_0["Jet OLEDB:Database Password"] = text;
			}
			return result;
		}

		protected override PropertyDescriptorCollection GetProperties(Attribute[] attributes)
		{
			PropertyDescriptorCollection propertyDescriptorCollection = base.GetProperties(attributes);
			if (Class149.Boolean_1)
			{
				Class156 @class = propertyDescriptorCollection.Find("Provider", ignoreCase: true) as Class156;
				if (@class != null)
				{
					if (!base.Boolean_0)
					{
						@class.method_8(bool_0: false);
					}
					@class.method_9(typeof(Class162));
					@class.AddValueChanged(base.DbConnectionStringBuilder_0, method_3);
				}
				PropertyDescriptor propertyDescriptor = propertyDescriptorCollection.Find("DataSource", ignoreCase: true);
				if (propertyDescriptor != null)
				{
					int num = propertyDescriptorCollection.IndexOf(propertyDescriptor);
					PropertyDescriptor[] array = new PropertyDescriptor[propertyDescriptorCollection.Count];
					propertyDescriptorCollection.CopyTo(array, 0);
					array[num] = new Class156(propertyDescriptor);
					array[num].AddValueChanged(base.DbConnectionStringBuilder_0, method_4);
					propertyDescriptorCollection = new PropertyDescriptorCollection(array, readOnly: true);
				}
			}
			PropertyDescriptor propertyDescriptor2 = propertyDescriptorCollection.Find("Jet OLEDB:Database Password", ignoreCase: true);
			if (propertyDescriptor2 != null)
			{
				int num2 = propertyDescriptorCollection.IndexOf(propertyDescriptor2);
				PropertyDescriptor[] array2 = new PropertyDescriptor[propertyDescriptorCollection.Count];
				propertyDescriptorCollection.CopyTo(array2, 0);
				array2[num2] = new Class156(propertyDescriptor2, PasswordPropertyTextAttribute.Yes);
				propertyDescriptorCollection = new PropertyDescriptorCollection(array2, readOnly: true);
			}
			return propertyDescriptorCollection;
		}

		private void method_3(object sender, EventArgs e)
		{
			if (Class149.Boolean_1)
			{
				this.bool_3 = true;
			}
		}

		private void method_4(object sender, EventArgs e)
		{
			if (!Class149.Boolean_1 || this.bool_3)
			{
				return;
			}
			string text = this["Data Source"] as string;
			if (text != null)
			{
				text = text.Trim().ToUpperInvariant();
				if (text.EndsWith(".ACCDB", StringComparison.Ordinal))
				{
					base["Provider"] = "Microsoft.ACE.OLEDB.12.0";
				}
				else
				{
					base["Provider"] = "Microsoft.Jet.OLEDB.4.0";
				}
			}
		}
	}
}
