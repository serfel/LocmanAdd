using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using System.Xml;
using DocumentServer.DataBaseConnection;
using DocumentServer.Properties;

namespace ns4
{
	internal class Class102
	{
		public enum Enum18
		{
			const_0,
			const_1,
			DataRowMergedEventArgs,
			BlockMergingEventArgs,
			FieldMergedEventArgs,
			const_5,
			const_6
		}

		public enum Enum19
		{
			const_0,
			const_1,
			DataRowMergedEventArgs,
			BlockMergingEventArgs,
			FieldMergedEventArgs
		}

		private List<Class101> list_0;

		internal const string string_0 = "Report Data Source Configuration (*.rdsc)|*.rdsc";

		[CompilerGenerated]
		private string string_1;

		[CompilerGenerated]
		private string string_2;

		[CompilerGenerated]
		private string string_3;

		public string String_0
		{
			[CompilerGenerated]
			get
			{
				return this.string_1;
			}
			[CompilerGenerated]
			set
			{
				this.string_1 = value;
			}
		}

		public string String_1
		{
			[CompilerGenerated]
			get
			{
				return this.string_2;
			}
			[CompilerGenerated]
			set
			{
				this.string_2 = value;
			}
		}

		public string String_2
		{
			[CompilerGenerated]
			get
			{
				return this.string_3;
			}
			[CompilerGenerated]
			set
			{
				this.string_3 = value;
			}
		}

		public List<Class101> List_0
		{
			get
			{
				if (this.list_0 == null)
				{
					this.list_0 = new List<Class101>();
				}
				return this.list_0;
			}
			set
			{
				this.list_0 = value;
			}
		}

		public Class102(string string_4)
		{
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.Load(string_4);
			this.method_2(xmlDocument);
		}

		public Class102(XmlDocument xmlDocument_0)
		{
			this.method_2(xmlDocument_0);
		}

		public Class102(Class99 class99_0)
		{
			this.method_3(class99_0);
		}

		public Class102()
		{
			this.String_0 = string.Empty;
			this.String_1 = string.Empty;
			this.String_2 = string.Empty;
		}

		public Class102(DbConnectionAdapter dbConnectionAdapter_0)
		{
			Class99 @class = dbConnectionAdapter_0 as Class99;
			if (@class == null)
			{
				throw new Exception(Resources.EXC_DB_CONNECTION_ADAPTER_TYPE);
			}
			this.method_3(@class);
		}

		public void method_0(string string_4)
		{
			string contents = this.method_1();
			File.WriteAllText(string_4, contents, new UTF8Encoding(encoderShouldEmitUTF8Identifier: false));
		}

		public string method_1()
		{
			XmlDocument xmlDocument = this.method_4();
			using StringWriter stringWriter = new StringWriter();
			using XmlTextWriter xmlTextWriter = new XmlTextWriter(stringWriter);
			xmlTextWriter.Formatting = Formatting.Indented;
			xmlTextWriter.Indentation = 3;
			xmlDocument.WriteTo(xmlTextWriter);
			xmlTextWriter.Flush();
			return stringWriter.GetStringBuilder().ToString();
		}

		private void method_2(XmlDocument xmlDocument_0)
		{
			if (xmlDocument_0.DocumentElement.Name != Enum18.const_0.ToString())
			{
				throw new Exception(Resources.EXC_INVALID_REPORT_DATA_SOURCE_CONFIG);
			}
			XmlNodeList elementsByTagName = xmlDocument_0.DocumentElement.GetElementsByTagName(Enum18.const_1.ToString());
			if (elementsByTagName.Count != 0 && elementsByTagName.Count <= 1)
			{
				XmlElement obj = (elementsByTagName[0] as XmlElement) ?? throw new Exception(Resources.EXC_INVALID_REPORT_DATA_SOURCE_CONFIG);
				elementsByTagName = xmlDocument_0.DocumentElement.GetElementsByTagName(Enum18.DataRowMergedEventArgs.ToString());
				if (elementsByTagName.Count != 0 && elementsByTagName.Count <= 1)
				{
					XmlElement xmlElement = elementsByTagName[0] as XmlElement;
					if (xmlElement == null)
					{
						throw new Exception(Resources.EXC_INVALID_REPORT_DATA_SOURCE_CONFIG);
					}
					elementsByTagName = xmlDocument_0.DocumentElement.GetElementsByTagName(Enum18.BlockMergingEventArgs.ToString());
					if (elementsByTagName.Count != 0 && elementsByTagName.Count <= 1)
					{
						XmlElement xmlElement2 = elementsByTagName[0] as XmlElement;
						if (xmlElement2 == null)
						{
							throw new Exception(Resources.EXC_INVALID_REPORT_DATA_SOURCE_CONFIG);
						}
						string value = (obj.Attributes[Enum19.BlockMergingEventArgs.ToString()] ?? throw new Exception(Resources.EXC_INVALID_REPORT_DATA_SOURCE_CONFIG)).Value;
						if (string.IsNullOrEmpty(value))
						{
							throw new Exception(Resources.EXC_INVALID_REPORT_DATA_SOURCE_CONFIG);
						}
						string value2 = (obj.Attributes[Enum19.FieldMergedEventArgs.ToString()] ?? throw new Exception(Resources.EXC_INVALID_REPORT_DATA_SOURCE_CONFIG)).Value;
						if (string.IsNullOrEmpty(value2))
						{
							throw new Exception(Resources.EXC_INVALID_REPORT_DATA_SOURCE_CONFIG);
						}
						string value3 = (xmlElement.Attributes[Enum19.const_0.ToString()] ?? throw new Exception(Resources.EXC_INVALID_REPORT_DATA_SOURCE_CONFIG)).Value;
						if (string.IsNullOrEmpty(value2))
						{
							throw new Exception(Resources.EXC_INVALID_REPORT_DATA_SOURCE_CONFIG);
						}
						List<Class101> list = new List<Class101>();
						foreach (XmlElement item in xmlElement2.GetElementsByTagName(Enum18.FieldMergedEventArgs.ToString()))
						{
							list.Add(new Class101(item));
						}
						this.String_1 = value;
						this.String_2 = value2;
						this.String_0 = value3;
						this.List_0 = list;
						return;
					}
					throw new Exception(Resources.EXC_INVALID_REPORT_DATA_SOURCE_CONFIG);
				}
				throw new Exception(Resources.EXC_INVALID_REPORT_DATA_SOURCE_CONFIG);
			}
			throw new Exception(Resources.EXC_INVALID_REPORT_DATA_SOURCE_CONFIG);
		}

		private void method_3(Class99 class99_0)
		{
			if (class99_0.SelectedTable != null && class99_0.SelectedTable.DataTable_0 != null)
			{
				this.String_0 = class99_0.SelectedTable.String_0;
				this.String_2 = class99_0.String_1;
				this.String_1 = class99_0.String_0;
				foreach (DataRelation dataRelation in class99_0.DataRelations)
				{
					Class101 item = new Class101(dataRelation.RelationName, dataRelation.ParentTable.TableName, dataRelation.ParentColumns[0].ColumnName, dataRelation.ChildTable.TableName, dataRelation.ChildColumns[0].ColumnName);
					this.List_0.Add(item);
				}
				return;
			}
			throw new Exception(Resources.EXC_CANNOT_SAVE_DB_CONNECTION_SETTINGS);
		}

		private XmlDocument method_4()
		{
			XmlDocument xmlDocument = new XmlDocument();
			XmlDeclaration newChild = xmlDocument.CreateXmlDeclaration("1.0", "utf-8", "");
			xmlDocument.AppendChild(newChild);
			XmlElement xmlElement = xmlDocument.CreateElement(Enum18.const_0.ToString());
			xmlDocument.AppendChild(xmlElement);
			XmlElement xmlElement2 = xmlDocument.CreateElement(Enum18.const_1.ToString());
			xmlElement.AppendChild(xmlElement2);
			XmlAttribute xmlAttribute = xmlDocument.CreateAttribute(Enum19.BlockMergingEventArgs.ToString());
			xmlAttribute.Value = this.String_1;
			xmlElement2.Attributes.Append(xmlAttribute);
			xmlAttribute = xmlDocument.CreateAttribute(Enum19.FieldMergedEventArgs.ToString());
			xmlAttribute.Value = this.String_2;
			xmlElement2.Attributes.Append(xmlAttribute);
			XmlElement xmlElement3 = xmlDocument.CreateElement(Enum18.DataRowMergedEventArgs.ToString());
			xmlElement.AppendChild(xmlElement3);
			xmlAttribute = xmlDocument.CreateAttribute(Enum19.const_0.ToString());
			xmlAttribute.Value = this.String_0;
			xmlElement3.Attributes.Append(xmlAttribute);
			XmlElement xmlElement4 = xmlDocument.CreateElement(Enum18.BlockMergingEventArgs.ToString());
			xmlElement.AppendChild(xmlElement4);
			foreach (Class101 item in this.List_0)
			{
				item.method_0(xmlElement4);
			}
			return xmlDocument;
		}
	}
}
