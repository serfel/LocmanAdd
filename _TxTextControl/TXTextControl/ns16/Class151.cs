using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.IO;
using Microsoft.Win32;

namespace ns16
{
	internal class Class151 : Class150
	{
		private class Class164 : StringConverter
		{
			private StandardValuesCollection standardValuesCollection_0;

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
				if (this.standardValuesCollection_0 == null)
				{
					string[] array = null;
					if (Class157.smethod_1())
					{
						List<string> list = new List<string>();
						list.AddRange(Class157.smethod_2("SOFTWARE\\Microsoft\\Microsoft SQL Server\\Instance Names\\SQL", 257));
						list.AddRange(Class157.smethod_2("SOFTWARE\\Microsoft\\Microsoft SQL Server\\Instance Names\\SQL", 513));
						array = list.ToArray();
					}
					else
					{
						RegistryKey registryKey = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Microsoft SQL Server\\Instance Names\\SQL");
						if (registryKey != null)
						{
							using (registryKey)
							{
								array = registryKey.GetValueNames();
							}
						}
					}
					if (array != null)
					{
						for (int i = 0; i < array.Length; i++)
						{
							if (string.Equals(array[i], "MSSQLSERVER", StringComparison.OrdinalIgnoreCase))
							{
								array[i] = ".";
							}
							else
							{
								array[i] = ".\\" + array[i];
							}
						}
						this.standardValuesCollection_0 = new StandardValuesCollection(array);
					}
					else
					{
						this.standardValuesCollection_0 = new StandardValuesCollection(new string[0]);
					}
				}
				return this.standardValuesCollection_0;
			}
		}

		private string string_1;

		public override bool IsComplete
		{
			get
			{
				if (!base.IsComplete)
				{
					return false;
				}
				if (base.DbConnectionStringBuilder_0["AttachDbFilename"] is string && (base.DbConnectionStringBuilder_0["AttachDbFilename"] as string).Length != 0)
				{
					return true;
				}
				return false;
			}
		}

		public Class151()
			: this(null)
		{
		}

		public Class151(string string_2)
		{
			this.string_1 = ".";
			if (string_2 != null && string_2.Length > 0)
			{
				this.string_1 = this.string_1 + "\\" + string_2;
			}
			else
			{
				TypeConverter.StandardValuesCollection standardValues = new Class164().GetStandardValues(null);
				if (standardValues.Count > 0)
				{
					this.string_1 = standardValues[0] as string;
				}
			}
			this.method_2();
		}

		public override void Reset()
		{
			base.Reset();
			this.method_2();
		}

		public override void Test()
		{
			string text = base.DbConnectionStringBuilder_0["AttachDbFilename"] as string;
			try
			{
				if (text != null && text.Length != 0)
				{
					base.DbConnectionStringBuilder_0["AttachDbFilename"] = Path.GetFullPath(text);
					if (!File.Exists(base.DbConnectionStringBuilder_0["AttachDbFilename"] as string))
					{
						throw new InvalidOperationException(Class144.smethod_0("SQLFILECONNECTIONPROPS_CANT_TEST_NON_EXISTENT_MDF"));
					}
					base.Test();
					return;
				}
				throw new InvalidOperationException(Class144.smethod_0("SQLFILECONNECTIONPROPS_NO_FILE_SPECIFIED"));
			}
			catch (SqlException ex)
			{
				if (ex.Number == -2)
				{
					throw new ApplicationException(ex.Errors[0].Message + Environment.NewLine + Class144.smethod_0("SQLFILECONNECTIONPROPS_TIMEOUT_REASONS"));
				}
				throw;
			}
			finally
			{
				if (text != null && text.Length > 0)
				{
					base.DbConnectionStringBuilder_0["AttachDbFilename"] = text;
				}
			}
		}

		protected override PropertyDescriptorCollection GetProperties(Attribute[] attributes)
		{
			PropertyDescriptorCollection propertyDescriptorCollection = base.GetProperties(attributes);
			PropertyDescriptor propertyDescriptor = propertyDescriptorCollection.Find("DataSource", ignoreCase: true);
			if (propertyDescriptor != null)
			{
				int num = propertyDescriptorCollection.IndexOf(propertyDescriptor);
				PropertyDescriptor[] array = new PropertyDescriptor[propertyDescriptorCollection.Count];
				propertyDescriptorCollection.CopyTo(array, 0);
				array[num] = new Class156(propertyDescriptor, new TypeConverterAttribute(typeof(Class164)));
				(array[num] as Class156).Delegate3_0 = method_3;
				(array[num] as Class156).Delegate4_0 = method_4;
				propertyDescriptorCollection = new PropertyDescriptorCollection(array, readOnly: true);
			}
			return propertyDescriptorCollection;
		}

		private void method_2()
		{
			this["Data Source"] = this.string_1;
			this["User Instance"] = true;
			this["Connection Timeout"] = 30;
		}

		private bool method_3(object object_0)
		{
			if (this["Data Source"] is string)
			{
				return !(this["Data Source"] as string).Equals(this.string_1, StringComparison.OrdinalIgnoreCase);
			}
			return true;
		}

		private void method_4(object object_0)
		{
			this["Data Source"] = this.string_1;
		}
	}
}
