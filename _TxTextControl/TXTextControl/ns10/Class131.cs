using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Xml;
using DocumentServer.DataSources;

namespace ns10
{
	internal class Class131 : IDataTableAdapter
	{
		private IEnumerable ienumerable_0;

		private List<Class132> list_0 = new List<Class132>();

		private Type type_0;

		internal Dictionary<string, Dictionary<object, Class131>> dictionary_0 = new Dictionary<string, Dictionary<object, Class131>>();

		private string string_0;

		private List<string> list_1 = new List<string>();

		private List<string> list_2 = new List<string>();

		public string TableName
		{
			get
			{
				if (this.string_0 == null)
				{
					if (!(this.type_0 != null))
					{
						return "";
					}
					return this.type_0.Name.ToLower();
				}
				return this.string_0;
			}
		}

		public string[] ColumnNames => this.list_1.ToArray();

		public IDataRowAdapter[] Rows => this.list_0.ToArray();

		public string[] ChildTableNames => this.list_2.ToArray();

		public Class131(object object_0)
			: this(object_0, null)
		{
		}

		public Class131(object object_0, string string_1)
		{
			Type type = object_0.GetType();
			if (Class131.smethod_0(type) && !Class131.smethod_4(type))
			{
				this.method_3((IEnumerable)object_0, string_1);
				return;
			}
			this.method_3(new object[1] { object_0 }, string_1);
		}

		internal string method_0()
		{
			return this.method_1(Thread.CurrentThread.CurrentCulture);
		}

		internal string method_1(IFormatProvider iformatProvider_0)
		{
			XmlDocument xmlDocument = new XmlDocument();
			XmlElement xmlElement = xmlDocument.CreateElement("Database");
			xmlDocument.AppendChild(xmlElement);
			this.method_2(xmlDocument, iformatProvider_0);
			foreach (Class132 item in this.list_0)
			{
				xmlElement.AppendChild(item.method_0(xmlDocument, iformatProvider_0));
			}
			XmlWriterSettings settings = new XmlWriterSettings
			{
				Encoding = new UTF8Encoding(encoderShouldEmitUTF8Identifier: false),
				ConformanceLevel = ConformanceLevel.Document
			};
			using MemoryStream memoryStream = new MemoryStream();
			using XmlWriter xmlWriter = XmlWriter.Create(memoryStream, settings);
			xmlWriter.WriteStartDocument();
			xmlDocument.WriteTo(xmlWriter);
			xmlWriter.Flush();
			byte[] bytes = memoryStream.ToArray();
			return Encoding.UTF8.GetString(bytes);
		}

		internal List<XmlElement> method_2(XmlDocument xmlDocument_0, IFormatProvider iformatProvider_0)
		{
			List<XmlElement> list = new List<XmlElement>();
			foreach (Class132 item in this.list_0)
			{
				list.Add(item.method_0(xmlDocument_0, iformatProvider_0));
			}
			return list;
		}

		private void method_3(IEnumerable ienumerable_1, string string_1)
		{
			this.ienumerable_0 = ienumerable_1;
			this.string_0 = string_1?.ToLower();
			if (ienumerable_1 == null)
			{
				return;
			}
			object obj = null;
			IEnumerator enumerator = ienumerable_1.GetEnumerator();
			try
			{
				if (enumerator.MoveNext())
				{
					object current = enumerator.Current;
					obj = current;
					this.type_0 = current.GetType();
				}
			}
			finally
			{
				IDisposable disposable = enumerator as IDisposable;
				if (disposable != null)
				{
					disposable.Dispose();
				}
			}
			if (this.type_0 == null)
			{
				return;
			}
			if (Class131.smethod_4(this.type_0))
			{
				this.method_5((IDictionary)obj);
			}
			else
			{
				this.method_4();
			}
			foreach (object item in this.ienumerable_0)
			{
				this.list_0.Add(new Class132(item, this));
			}
		}

		private void method_4()
		{
			if (this.type_0 == null)
			{
				return;
			}
			PropertyInfo[] properties = this.type_0.GetProperties(BindingFlags.Instance | BindingFlags.Public);
			foreach (PropertyInfo propertyInfo_ in properties)
			{
				string text = Class132.smethod_3(propertyInfo_);
				if (text != null)
				{
					this.method_6(text, propertyInfo_);
				}
			}
		}

		private void method_5(IDictionary idictionary_0)
		{
			if (!Class131.smethod_4(idictionary_0.GetType()))
			{
				throw new ArgumentException("Dictionary is not of the correct type.", "dict");
			}
			foreach (string key in idictionary_0.Keys)
			{
				object obj = idictionary_0[key];
				Type type_ = ((obj != null) ? obj.GetType() : typeof(object));
				this.method_7(key, type_);
			}
		}

		internal static bool smethod_0(Type type_1)
		{
			if (!(type_1 == typeof(IEnumerable)))
			{
				return type_1.GetInterfaces().Any((Type t) => t == typeof(IEnumerable));
			}
			return true;
		}

		public static bool smethod_1(Type type_1)
		{
			if (Class131.smethod_2(type_1))
			{
				return true;
			}
			TypeCode typeCode = Type.GetTypeCode(type_1);
			if ((uint)(typeCode - 3) > 1u && typeCode != TypeCode.String)
			{
				return false;
			}
			return true;
		}

		public static bool smethod_2(Type type_1)
		{
			TypeCode typeCode = Type.GetTypeCode(type_1);
			if ((uint)(typeCode - 5) <= 10u)
			{
				return true;
			}
			return false;
		}

		public static bool smethod_3(out decimal decimal_0, object object_0)
		{
			bool result = true;
			decimal_0 = default(decimal);
			switch (Type.GetTypeCode(object_0.GetType()))
			{
			default:
				result = false;
				break;
			case TypeCode.SByte:
				decimal_0 = new decimal((sbyte)object_0);
				break;
			case TypeCode.Byte:
				decimal_0 = new decimal((byte)object_0);
				break;
			case TypeCode.Int16:
				decimal_0 = new decimal((short)object_0);
				break;
			case TypeCode.UInt16:
				decimal_0 = new decimal((ushort)object_0);
				break;
			case TypeCode.Int32:
				decimal_0 = new decimal((int)object_0);
				break;
			case TypeCode.UInt32:
				decimal_0 = new decimal((uint)object_0);
				break;
			case TypeCode.Int64:
				decimal_0 = new decimal((long)object_0);
				break;
			case TypeCode.UInt64:
				decimal_0 = new decimal((ulong)object_0);
				break;
			case TypeCode.Single:
				decimal_0 = new decimal((float)object_0);
				break;
			case TypeCode.Double:
				decimal_0 = new decimal((double)object_0);
				break;
			case TypeCode.Decimal:
				decimal_0 = (decimal)object_0;
				break;
			}
			return result;
		}

		internal static bool smethod_4(Type type_1)
		{
			if (type_1.IsGenericType && type_1.GetGenericTypeDefinition() == typeof(Dictionary<, >))
			{
				return type_1.GetGenericArguments()[0] == typeof(string);
			}
			return false;
		}

		private void method_6(string string_1, PropertyInfo propertyInfo_0)
		{
			string_1 = string_1.ToLower();
			if (!(propertyInfo_0.PropertyType == this.type_0) && !Class131.smethod_1(propertyInfo_0.PropertyType) && !(propertyInfo_0.PropertyType == typeof(Bitmap)))
			{
				if (Class131.smethod_4(propertyInfo_0.PropertyType))
				{
					this.list_2.Add(string_1);
					return;
				}
				if (Class131.smethod_0(propertyInfo_0.PropertyType))
				{
					this.list_2.Add(string_1);
					return;
				}
				this.list_2.Add(string_1);
				this.list_1.Add(string_1);
			}
			else
			{
				this.list_1.Add(string_1);
			}
		}

		private void method_7(string string_1, Type type_1)
		{
			string_1 = string_1.ToLower();
			if (!Class131.smethod_1(type_1) && !(type_1 == typeof(Bitmap)))
			{
				if (Class131.smethod_4(type_1))
				{
					this.list_2.Add(string_1);
					return;
				}
				if (Class131.smethod_0(type_1))
				{
					this.list_2.Add(string_1);
					return;
				}
				this.list_2.Add(string_1);
				this.list_1.Add(string_1);
			}
			else
			{
				this.list_1.Add(string_1);
			}
		}
	}
}
