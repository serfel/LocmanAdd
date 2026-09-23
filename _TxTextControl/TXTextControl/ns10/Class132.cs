using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Xml;
using DocumentServer.DataSources;

namespace ns10
{
	internal class Class132 : IDataRowAdapter
	{
		private object object_0;

		private IDictionary idictionary_0;

		private Class131 class131_0;

		public object this[string key]
		{
			get
			{
				object obj = null;
				key = key.ToLower();
				if (this.class131_0 != null && this.class131_0.ColumnNames.Contains(key))
				{
					if (this.object_0 != null)
					{
						PropertyInfo propertyInfo = Class132.smethod_2(this.object_0, key);
						if (propertyInfo != null)
						{
							try
							{
								obj = propertyInfo.GetValue(this.object_0, null);
							}
							catch
							{
							}
						}
					}
					else if (this.idictionary_0 != null)
					{
						try
						{
							obj = this.method_3(this.idictionary_0, key);
						}
						catch
						{
						}
					}
					if (obj == null)
					{
						return "";
					}
					if (obj.GetType().IsEnum)
					{
						return Class132.smethod_0(obj);
					}
					return obj;
				}
				return "";
			}
		}

		public IDataTableAdapter Table => this.class131_0;

		public Class132(object object_1, Class131 class131_1)
		{
			if (Class131.smethod_4(object_1.GetType()))
			{
				this.idictionary_0 = (IDictionary)object_1;
			}
			else
			{
				this.object_0 = object_1;
			}
			this.class131_0 = class131_1;
		}

		public IDataRowAdapter[] GetChildRows(string childTableName)
		{
			childTableName = childTableName.ToLower();
			object obj = null;
			if (this.class131_0 != null && this.class131_0.ChildTableNames.Contains(childTableName))
			{
				if (this.object_0 != null)
				{
					PropertyInfo propertyInfo = Class132.smethod_2(this.object_0, childTableName);
					if (propertyInfo != null)
					{
						try
						{
							obj = propertyInfo.GetValue(this.object_0, null);
						}
						catch
						{
						}
					}
				}
				else if (this.idictionary_0 != null)
				{
					try
					{
						obj = this.method_3(this.idictionary_0, childTableName);
					}
					catch
					{
					}
				}
				if (obj == null)
				{
					return new IDataRowAdapter[0];
				}
				try
				{
					return this.method_1(childTableName, obj).Rows;
				}
				catch
				{
				}
				return new IDataRowAdapter[0];
			}
			return new IDataRowAdapter[0];
		}

		internal XmlElement method_0(XmlDocument xmlDocument_0, IFormatProvider iformatProvider_0)
		{
			XmlElement xmlElement = xmlDocument_0.CreateElement(this.class131_0.TableName);
			List<string> list = new List<string>(this.class131_0.ColumnNames);
			List<string> list2 = new List<string>(this.class131_0.ChildTableNames);
			for (int num = list.Count - 1; num >= 0; num--)
			{
				if (list2.IndexOf(list[num]) > -1)
				{
					list.RemoveAt(num);
				}
			}
			foreach (string item in list)
			{
				XmlElement xmlElement2 = xmlDocument_0.CreateElement(item);
				object obj = this[item];
				if (obj != null)
				{
					Bitmap bitmap = obj as Bitmap;
					decimal decimal_;
					if (bitmap != null)
					{
						using MemoryStream memoryStream = new MemoryStream();
						bitmap.Save(memoryStream, ImageFormat.Png);
						string text2 = (xmlElement2.InnerText = Convert.ToBase64String(memoryStream.ToArray()));
					}
					else if (obj is DateTime)
					{
						xmlElement2.InnerText = ((DateTime)obj).ToString(iformatProvider_0);
					}
					else if (this.method_2(out decimal_, obj))
					{
						xmlElement2.InnerText = decimal_.ToString(iformatProvider_0);
					}
					else
					{
						xmlElement2.InnerText = obj.ToString();
					}
				}
				xmlElement.AppendChild(xmlElement2);
			}
			string[] childTableNames = this.class131_0.ChildTableNames;
			foreach (string childTableName in childTableNames)
			{
				IDataRowAdapter[] childRows = this.GetChildRows(childTableName);
				for (int j = 0; j < childRows.Length; j++)
				{
					Class132 @class = (Class132)childRows[j];
					xmlElement.AppendChild(@class.method_0(xmlDocument_0, iformatProvider_0));
				}
			}
			return xmlElement;
		}

		private static string smethod_0(object object_1)
		{
			FieldInfo field = object_1.GetType().GetField(object_1.ToString());
			if (field != null)
			{
				object[] customAttributes = field.GetCustomAttributes(typeof(DescriptionAttribute), inherit: false);
				if (customAttributes != null && customAttributes.Length != 0)
				{
					return ((DescriptionAttribute)customAttributes[0]).Description;
				}
			}
			return object_1.ToString();
		}

		private Class131 method_1(string string_0, object object_1)
		{
			if (object_1 == null)
			{
				return null;
			}
			object key = this.object_0 ?? this.idictionary_0;
			if (this.class131_0.dictionary_0.ContainsKey(string_0))
			{
				Dictionary<object, Class131> dictionary = this.class131_0.dictionary_0[string_0];
				if (dictionary.ContainsKey(key))
				{
					return dictionary[key];
				}
			}
			else
			{
				this.class131_0.dictionary_0[string_0] = new Dictionary<object, Class131>();
			}
			Class131 @class = new Class131(object_1, string_0);
			this.class131_0.dictionary_0[string_0][key] = @class;
			return @class;
		}

		public static bool smethod_1(object object_1)
		{
			TypeCode typeCode = Type.GetTypeCode(object_1.GetType());
			if ((uint)(typeCode - 5) <= 10u)
			{
				return true;
			}
			return false;
		}

		private bool method_2(out decimal decimal_0, object object_1)
		{
			bool result = true;
			decimal_0 = default(decimal);
			switch (Type.GetTypeCode(object_1.GetType()))
			{
			default:
				result = false;
				break;
			case TypeCode.SByte:
				decimal_0 = new decimal((sbyte)object_1);
				break;
			case TypeCode.Byte:
				decimal_0 = new decimal((byte)object_1);
				break;
			case TypeCode.Int16:
				decimal_0 = new decimal((short)object_1);
				break;
			case TypeCode.UInt16:
				decimal_0 = new decimal((ushort)object_1);
				break;
			case TypeCode.Int32:
				decimal_0 = new decimal((int)object_1);
				break;
			case TypeCode.UInt32:
				decimal_0 = new decimal((uint)object_1);
				break;
			case TypeCode.Int64:
				decimal_0 = new decimal((long)object_1);
				break;
			case TypeCode.UInt64:
				decimal_0 = new decimal((ulong)object_1);
				break;
			case TypeCode.Single:
				decimal_0 = new decimal((float)object_1);
				break;
			case TypeCode.Double:
				decimal_0 = new decimal((double)object_1);
				break;
			case TypeCode.Decimal:
				decimal_0 = (decimal)object_1;
				break;
			}
			return result;
		}

		private object method_3(IDictionary idictionary_1, string string_0)
		{
			string_0 = string_0.ToLower();
			foreach (string key in idictionary_1.Keys)
			{
				if (string_0 == key.ToLower())
				{
					return idictionary_1[key];
				}
			}
			return null;
		}

		internal static PropertyInfo smethod_2(object object_1, string string_0)
		{
			if (object_1 == null)
			{
				return null;
			}
			PropertyInfo[] properties = object_1.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public);
			int num = 0;
			PropertyInfo propertyInfo;
			while (true)
			{
				if (num < properties.Length)
				{
					propertyInfo = properties[num];
					if (Class132.smethod_3(propertyInfo) == string_0.ToLower())
					{
						break;
					}
					num++;
					continue;
				}
				return null;
			}
			return propertyInfo;
		}

		internal static string smethod_3(PropertyInfo propertyInfo_0)
		{
			if (propertyInfo_0 == null)
			{
				return null;
			}
			if (propertyInfo_0.GetIndexParameters().Length != 0)
			{
				return null;
			}
			MethodInfo getMethod = propertyInfo_0.GetGetMethod();
			if (!(getMethod == null) && getMethod.IsPublic && !getMethod.IsStatic)
			{
				string result = propertyInfo_0.Name.ToLower();
				Attribute[] customAttributes = Attribute.GetCustomAttributes(propertyInfo_0, typeof(DisplayNameAttribute));
				if (customAttributes != null && customAttributes.Length != 0)
				{
					result = ((DisplayNameAttribute)customAttributes[0]).DisplayName.ToLower();
				}
				return result;
			}
			return null;
		}
	}
}
