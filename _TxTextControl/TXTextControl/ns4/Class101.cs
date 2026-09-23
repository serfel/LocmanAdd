using System;
using System.Runtime.CompilerServices;
using System.Xml;
using DocumentServer.Properties;

namespace ns4
{
	internal class Class101
	{
		[CompilerGenerated]
		private string string_0;

		[CompilerGenerated]
		private string string_1;

		[CompilerGenerated]
		private string string_2;

		[CompilerGenerated]
		private string string_3;

		[CompilerGenerated]
		private string string_4;

		public string String_0
		{
			[CompilerGenerated]
			get
			{
				return this.string_0;
			}
			[CompilerGenerated]
			private set
			{
				this.string_0 = value;
			}
		}

		public string String_1
		{
			[CompilerGenerated]
			get
			{
				return this.string_1;
			}
			[CompilerGenerated]
			private set
			{
				this.string_1 = value;
			}
		}

		public string String_2
		{
			[CompilerGenerated]
			get
			{
				return this.string_2;
			}
			[CompilerGenerated]
			private set
			{
				this.string_2 = value;
			}
		}

		public string String_3
		{
			[CompilerGenerated]
			get
			{
				return this.string_3;
			}
			[CompilerGenerated]
			private set
			{
				this.string_3 = value;
			}
		}

		public string String_4
		{
			[CompilerGenerated]
			get
			{
				return this.string_4;
			}
			[CompilerGenerated]
			private set
			{
				this.string_4 = value;
			}
		}

		public Class101(XmlElement xmlElement_0)
		{
			this.method_1(xmlElement_0);
		}

		public Class101(string string_5, string string_6, string string_7, string string_8, string string_9)
		{
			this.String_0 = string_6;
			this.String_1 = string_7;
			this.String_2 = string_8;
			this.String_3 = string_9;
			this.String_4 = string_5;
		}

		public Class101(string string_5, string string_6, string string_7, string string_8)
			: this(string.Empty, string_5, string_6, string_7, string_8)
		{
		}

		internal void method_0(XmlElement xmlElement_0)
		{
			XmlDocument ownerDocument = xmlElement_0.OwnerDocument;
			XmlElement xmlElement = ownerDocument.CreateElement(Class102.Enum18.FieldMergedEventArgs.ToString());
			xmlElement_0.AppendChild(xmlElement);
			XmlAttribute xmlAttribute = ownerDocument.CreateAttribute(Class102.Enum19.const_0.ToString());
			xmlAttribute.Value = this.String_4;
			xmlElement.Attributes.Append(xmlAttribute);
			XmlElement xmlElement2 = ownerDocument.CreateElement(Class102.Enum18.const_5.ToString());
			xmlElement.AppendChild(xmlElement2);
			xmlAttribute = ownerDocument.CreateAttribute(Class102.Enum19.const_1.ToString());
			xmlAttribute.Value = this.String_0;
			xmlElement2.Attributes.Append(xmlAttribute);
			xmlAttribute = ownerDocument.CreateAttribute(Class102.Enum19.DataRowMergedEventArgs.ToString());
			xmlAttribute.Value = this.String_1;
			xmlElement2.Attributes.Append(xmlAttribute);
			XmlElement xmlElement3 = ownerDocument.CreateElement(Class102.Enum18.const_6.ToString());
			xmlElement.AppendChild(xmlElement3);
			xmlAttribute = ownerDocument.CreateAttribute(Class102.Enum19.const_1.ToString());
			xmlAttribute.Value = this.String_2;
			xmlElement3.Attributes.Append(xmlAttribute);
			xmlAttribute = ownerDocument.CreateAttribute(Class102.Enum19.DataRowMergedEventArgs.ToString());
			xmlAttribute.Value = this.String_3;
			xmlElement3.Attributes.Append(xmlAttribute);
		}

		private void method_1(XmlElement xmlElement_0)
		{
			XmlAttribute xmlAttribute = xmlElement_0.Attributes[Class102.Enum19.const_0.ToString()];
			if (xmlAttribute == null)
			{
				throw new Exception(Resources.EXC_INVALID_REPORT_DATA_SOURCE_CONFIG);
			}
			this.String_4 = xmlAttribute.Value;
			XmlNodeList elementsByTagName = xmlElement_0.GetElementsByTagName(Class102.Enum18.const_5.ToString());
			if (elementsByTagName.Count != 0 && elementsByTagName.Count <= 1)
			{
				XmlElement obj = (elementsByTagName[0] as XmlElement) ?? throw new Exception(Resources.EXC_INVALID_REPORT_DATA_SOURCE_CONFIG);
				elementsByTagName = xmlElement_0.GetElementsByTagName(Class102.Enum18.const_6.ToString());
				if (elementsByTagName.Count != 0 && elementsByTagName.Count <= 1)
				{
					XmlElement xmlElement = elementsByTagName[0] as XmlElement;
					if (xmlElement == null)
					{
						throw new Exception(Resources.EXC_INVALID_REPORT_DATA_SOURCE_CONFIG);
					}
					xmlAttribute = obj.Attributes[Class102.Enum19.const_1.ToString()];
					if (xmlAttribute == null)
					{
						throw new Exception(Resources.EXC_INVALID_REPORT_DATA_SOURCE_CONFIG);
					}
					this.String_0 = xmlAttribute.Value;
					xmlAttribute = obj.Attributes[Class102.Enum19.DataRowMergedEventArgs.ToString()];
					if (xmlAttribute == null)
					{
						throw new Exception(Resources.EXC_INVALID_REPORT_DATA_SOURCE_CONFIG);
					}
					this.String_1 = xmlAttribute.Value;
					xmlAttribute = xmlElement.Attributes[Class102.Enum19.const_1.ToString()];
					if (xmlAttribute == null)
					{
						throw new Exception(Resources.EXC_INVALID_REPORT_DATA_SOURCE_CONFIG);
					}
					this.String_2 = xmlAttribute.Value;
					xmlAttribute = xmlElement.Attributes[Class102.Enum19.DataRowMergedEventArgs.ToString()];
					if (xmlAttribute == null)
					{
						throw new Exception(Resources.EXC_INVALID_REPORT_DATA_SOURCE_CONFIG);
					}
					this.String_3 = xmlAttribute.Value;
					return;
				}
				throw new Exception(Resources.EXC_INVALID_REPORT_DATA_SOURCE_CONFIG);
			}
			throw new Exception(Resources.EXC_INVALID_REPORT_DATA_SOURCE_CONFIG);
		}
	}
}
