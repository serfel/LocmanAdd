using System;
using System.Collections.Generic;
using System.ComponentModel;
using Microsoft.Win32;

namespace ns16
{
	internal class Class148 : Class147
	{
		private class Class161 : StringConverter
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
				List<string> list = new List<string>();
				list.Add("SQLOLEDB");
				foreach (string item in Class148.List_0)
				{
					list.Add(item);
				}
				return new StandardValuesCollection(list);
			}
		}

		private static bool bool_1;

		private static List<string> list_0;

		private static bool bool_2;

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
					if ((base.DbConnectionStringBuilder_0["Integrated Security"] != null && base.DbConnectionStringBuilder_0["Integrated Security"].ToString().Equals("SSPI", StringComparison.OrdinalIgnoreCase)) || (base.DbConnectionStringBuilder_0["User ID"] is string && (base.DbConnectionStringBuilder_0["User ID"] as string).Length != 0))
					{
						return true;
					}
					return false;
				}
				return false;
			}
		}

		public static List<string> List_0
		{
			get
			{
				if (Class148.list_0 == null)
				{
					Class148.list_0 = new List<string>();
					foreach (string item in Class146.smethod_1())
					{
						if (item.StartsWith("SQLNCLI"))
						{
							int num = item.IndexOf(".");
							if (num > 0)
							{
								Class148.list_0.Add(item.Substring(0, num).ToUpperInvariant());
							}
						}
					}
					Class148.list_0.Sort();
				}
				return Class148.list_0;
			}
		}

		private static bool Boolean_1
		{
			get
			{
				if (!Class148.bool_2)
				{
					RegistryKey registryKey = null;
					try
					{
						Class148.bool_1 = Class148.List_0.Count > 0;
					}
					finally
					{
						registryKey?.Close();
					}
					Class148.bool_2 = true;
				}
				return Class148.bool_1;
			}
		}

		public Class148()
			: base("SQLOLEDB")
		{
			this.method_3();
		}

		public override void Reset()
		{
			base.Reset();
			this.method_3();
		}

		protected override PropertyDescriptorCollection GetProperties(Attribute[] attributes)
		{
			PropertyDescriptorCollection properties = base.GetProperties(attributes);
			if (Class148.Boolean_1)
			{
				Class156 @class = properties.Find("Provider", ignoreCase: true) as Class156;
				if (@class != null)
				{
					if (!base.Boolean_0)
					{
						@class.method_8(bool_0: false);
					}
					@class.method_9(typeof(Class161));
				}
			}
			return properties;
		}

		private void method_3()
		{
			this["Integrated Security"] = "SSPI";
		}
	}
}
