using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.OleDb;
using Microsoft.Win32;

namespace ns16
{
	internal class Class146 : Class144
	{
		private bool bool_0;

		public bool Boolean_0
		{
			get
			{
				return this.bool_0;
			}
			set
			{
				this.bool_0 = value;
			}
		}

		public override bool IsComplete
		{
			get
			{
				if (base.DbConnectionStringBuilder_0["Provider"] is string && (base.DbConnectionStringBuilder_0["Provider"] as string).Length != 0)
				{
					return true;
				}
				return false;
			}
		}

		public Class146()
			: base("System.Data.OleDb")
		{
		}

		protected override PropertyDescriptorCollection GetProperties(Attribute[] attributes)
		{
			PropertyDescriptorCollection propertyDescriptorCollection = base.GetProperties(attributes);
			if (this.bool_0)
			{
				PropertyDescriptor propertyDescriptor = propertyDescriptorCollection.Find("Provider", ignoreCase: true);
				if (propertyDescriptor != null)
				{
					int num = propertyDescriptorCollection.IndexOf(propertyDescriptor);
					PropertyDescriptor[] array = new PropertyDescriptor[propertyDescriptorCollection.Count];
					propertyDescriptorCollection.CopyTo(array, 0);
					array[num] = new Class156(propertyDescriptor, ReadOnlyAttribute.Yes);
					(array[num] as Class156).Delegate3_0 = method_1;
					propertyDescriptorCollection = new PropertyDescriptorCollection(array, readOnly: true);
				}
			}
			return propertyDescriptorCollection;
		}

		public static List<string> smethod_1()
		{
			OleDbDataReader enumerator = OleDbEnumerator.GetEnumerator(Type.GetTypeFromCLSID(Class159.guid_2));
			Dictionary<string, string> dictionary = new Dictionary<string, string>();
			using (enumerator)
			{
				while (enumerator.Read())
				{
					int num = (int)enumerator["SOURCES_TYPE"];
					if (num == 1 || num == 3)
					{
						dictionary[enumerator["SOURCES_CLSID"] as string] = null;
					}
				}
			}
			List<string> list = new List<string>(dictionary.Count);
			RegistryKey registryKey = Registry.ClassesRoot.OpenSubKey("CLSID");
			using (registryKey)
			{
				foreach (KeyValuePair<string, string> item in dictionary)
				{
					RegistryKey registryKey2 = registryKey.OpenSubKey(item.Key + "\\ProgID");
					if (registryKey2 != null)
					{
						using (registryKey2)
						{
							list.Add(registryKey2.GetValue(null) as string);
						}
					}
				}
			}
			list.Sort();
			while (list.Contains("MSDASQL.1"))
			{
				list.Remove("MSDASQL.1");
			}
			return list;
		}

		private bool method_1(object object_0)
		{
			return false;
		}
	}
}
