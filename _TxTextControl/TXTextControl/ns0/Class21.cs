using System;
using System.IO;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml;
using TXTextControl.Barcode;

namespace ns0
{
	internal class Class21
	{
		private object object_0;

		private PropertyInfo propertyInfo_0;

		private PropertyInfo propertyInfo_1;

		private PropertyInfo propertyInfo_2;

		private PropertyInfo propertyInfo_3;

		private PropertyInfo propertyInfo_4;

		private PropertyInfo propertyInfo_5;

		private PropertyInfo propertyInfo_6;

		private PropertyInfo propertyInfo_7;

		private PropertyInfo propertyInfo_8;

		private MethodInfo methodInfo_0;

		internal Type type_0;

		internal Class21(object object_1)
		{
			this.object_0 = object_1;
			this.type_0 = object_1.GetType();
			this.propertyInfo_0 = this.type_0.GetProperty("Alignment");
			this.propertyInfo_1 = this.type_0.GetProperty("Angle");
			this.propertyInfo_2 = this.type_0.GetProperty("Text");
			this.propertyInfo_3 = this.type_0.GetProperty("BarcodeType");
			this.propertyInfo_4 = this.type_0.GetProperty("UpperTextLength");
			this.propertyInfo_8 = this.type_0.GetProperty("ShowText");
			this.propertyInfo_6 = this.type_0.GetProperty("BackColorAsInternalColor", BindingFlags.Instance | BindingFlags.NonPublic);
			this.propertyInfo_7 = this.type_0.GetProperty("ForeColorAsInternalColor", BindingFlags.Instance | BindingFlags.NonPublic);
			this.propertyInfo_5 = this.type_0.GetProperty("ControlSize", BindingFlags.Instance | BindingFlags.NonPublic);
			this.methodInfo_0 = this.type_0.GetMethod("LoadSerializedData", BindingFlags.Instance | BindingFlags.NonPublic);
		}

		internal void method_0(Stream stream_0, SerializationFormat serializationFormat_0)
		{
			if (serializationFormat_0 == SerializationFormat.Binary)
			{
				BinaryFormatter binaryFormatter = new BinaryFormatter();
				this.methodInfo_0.Invoke(this.object_0, new object[1] { binaryFormatter.Deserialize(stream_0) });
			}
			else
			{
				XmlReader xmlReader = XmlReader.Create(stream_0);
				this.methodInfo_0.Invoke(this.object_0, new object[1] { this.method_8(xmlReader) });
				xmlReader.Close();
			}
		}

		internal void method_1(string string_0, SerializationFormat serializationFormat_0)
		{
			if (serializationFormat_0 == SerializationFormat.Binary)
			{
				FileStream fileStream = new FileStream(string_0, FileMode.Open);
				BinaryFormatter binaryFormatter = new BinaryFormatter();
				this.methodInfo_0.Invoke(this.object_0, new object[1] { binaryFormatter.Deserialize(fileStream) });
				fileStream.Close();
			}
			else
			{
				XmlReader xmlReader = XmlReader.Create(string_0);
				this.methodInfo_0.Invoke(this.object_0, new object[1] { this.method_8(xmlReader) });
				xmlReader.Close();
			}
		}

		internal void method_2(TextReader textReader_0)
		{
			XmlReader xmlReader = XmlReader.Create(textReader_0);
			this.methodInfo_0.Invoke(this.object_0, new object[1] { this.method_8(xmlReader) });
			xmlReader.Close();
		}

		internal void method_3(XmlReader xmlReader_0)
		{
			this.methodInfo_0.Invoke(this.object_0, new object[1] { this.method_8(xmlReader_0) });
			xmlReader_0.Close();
		}

		internal void method_4(Stream stream_0, SerializationFormat serializationFormat_0)
		{
			if (serializationFormat_0 == SerializationFormat.Binary)
			{
				BinaryFormatter binaryFormatter = new BinaryFormatter();
				binaryFormatter.Serialize(stream_0, this.method_12());
				return;
			}
			XmlWriterSettings xmlWriterSettings = new XmlWriterSettings();
			xmlWriterSettings.NewLineOnAttributes = true;
			xmlWriterSettings.Indent = true;
			XmlWriter xmlWriter = XmlWriter.Create(stream_0, xmlWriterSettings);
			this.method_10(xmlWriter, this.method_12());
			xmlWriter.Close();
		}

		internal void method_5(string string_0, SerializationFormat serializationFormat_0)
		{
			if (serializationFormat_0 == SerializationFormat.Binary)
			{
				FileStream fileStream = new FileStream(string_0, FileMode.Create);
				BinaryFormatter binaryFormatter = new BinaryFormatter();
				binaryFormatter.Serialize(fileStream, this.method_12());
				fileStream.Close();
			}
			else
			{
				XmlWriterSettings xmlWriterSettings = new XmlWriterSettings();
				xmlWriterSettings.NewLineOnAttributes = true;
				xmlWriterSettings.Indent = true;
				XmlWriter xmlWriter = XmlWriter.Create(string_0, xmlWriterSettings);
				this.method_10(xmlWriter, this.method_12());
				xmlWriter.Close();
			}
		}

		internal void method_6(TextWriter textWriter_0)
		{
			XmlWriterSettings xmlWriterSettings = new XmlWriterSettings();
			xmlWriterSettings.NewLineOnAttributes = true;
			xmlWriterSettings.Indent = true;
			XmlWriter xmlWriter = XmlWriter.Create(textWriter_0, xmlWriterSettings);
			this.method_10(xmlWriter, this.method_12());
			xmlWriter.Close();
		}

		internal void method_7(XmlWriter xmlWriter_0)
		{
			this.method_10(xmlWriter_0, this.method_12());
		}

		private Class62 method_8(XmlReader xmlReader_0)
		{
			Class62 @class = new Class62();
			xmlReader_0.ReadToFollowing("Alignment");
			switch (xmlReader_0.ReadElementContentAsString())
			{
			case "TopLeft":
				@class.alignment_0 = Alignment.TopLeft;
				break;
			case "TopCenter":
				@class.alignment_0 = Alignment.TopCenter;
				break;
			case "TopRight":
				@class.alignment_0 = Alignment.TopRight;
				break;
			case "MiddleLeft":
				@class.alignment_0 = Alignment.MiddleLeft;
				break;
			case "MiddleCenter":
				@class.alignment_0 = Alignment.MiddleCenter;
				break;
			case "MiddleRight":
				@class.alignment_0 = Alignment.MiddleRight;
				break;
			case "BottomLeft":
				@class.alignment_0 = Alignment.BottomLeft;
				break;
			case "BottomCenter":
				@class.alignment_0 = Alignment.BottomCenter;
				break;
			case "BottomRight":
				@class.alignment_0 = Alignment.BottomRight;
				break;
			}
			xmlReader_0.ReadToFollowing("Angle");
			@class.int_1 = Convert.ToInt32(xmlReader_0.ReadElementContentAsString());
			xmlReader_0.ReadToFollowing("BackColor");
			@class.class26_0 = this.method_9(xmlReader_0.ReadElementContentAsString());
			xmlReader_0.ReadToFollowing("BarcodeType");
			switch (xmlReader_0.ReadElementContentAsString())
			{
			case "AztecCode":
				@class.barcodeType_0 = BarcodeType.AztecCode;
				break;
			case "Code128":
				@class.barcodeType_0 = BarcodeType.Code128;
				break;
			case "Code39":
				@class.barcodeType_0 = BarcodeType.Code39;
				break;
			case "EAN13":
				@class.barcodeType_0 = BarcodeType.EAN13;
				break;
			case "EAN8":
				@class.barcodeType_0 = BarcodeType.EAN8;
				break;
			case "IntelligentMail":
				@class.barcodeType_0 = BarcodeType.IntelligentMail;
				break;
			case "Interleaved2of5":
				@class.barcodeType_0 = BarcodeType.Interleaved2of5;
				break;
			case "Postnet":
				@class.barcodeType_0 = BarcodeType.Postnet;
				break;
			case "QRCode":
				@class.barcodeType_0 = BarcodeType.QRCode;
				break;
			case "UPCA":
				@class.barcodeType_0 = BarcodeType.UPCA;
				break;
			case "Datamatrix":
				@class.barcodeType_0 = BarcodeType.Datamatrix;
				break;
			case "PDF417":
				@class.barcodeType_0 = BarcodeType.PDF417;
				break;
			case "MicroPDF":
				@class.barcodeType_0 = BarcodeType.MicroPDF;
				break;
			case "Maxicode":
				@class.barcodeType_0 = BarcodeType.Maxicode;
				break;
			case "RoyalMail":
				@class.barcodeType_0 = BarcodeType.RoyalMail;
				break;
			case "PLANET":
				@class.barcodeType_0 = BarcodeType.PLANET;
				break;
			case "Code93":
				@class.barcodeType_0 = BarcodeType.Code93;
				break;
			case "Code11":
				@class.barcodeType_0 = BarcodeType.Code11;
				break;
			case "FourState":
				@class.barcodeType_0 = BarcodeType.FourState;
				break;
			case "Codabar":
				@class.barcodeType_0 = BarcodeType.Codabar;
				break;
			}
			xmlReader_0.ReadToFollowing("ForeColor");
			@class.class26_1 = this.method_9(xmlReader_0.ReadElementContentAsString());
			xmlReader_0.ReadToFollowing("MaximumTextLength");
			@class.int_0 = Convert.ToInt32(xmlReader_0.ReadElementContentAsString());
			xmlReader_0.ReadToFollowing("Size");
			string text = xmlReader_0.ReadElementContentAsString();
			int num = text.IndexOf('=') + 1;
			int length = text.IndexOf(',') - num;
			int num2 = text.LastIndexOf('=') + 1;
			int length2 = text.IndexOf('}') - num2;
			string value = text.Substring(num, length);
			string value2 = text.Substring(num2, length2);
			@class.class25_0 = new Class25(Convert.ToInt32(value), Convert.ToInt32(value2));
			xmlReader_0.ReadToFollowing("ShowText");
			@class.bool_0 = Convert.ToBoolean(xmlReader_0.ReadElementContentAsString());
			xmlReader_0.ReadToFollowing("Text");
			@class.string_1 = xmlReader_0.ReadElementContentAsString();
			return @class;
		}

		private Class26 method_9(string string_0)
		{
			Class26 @class = new Class26();
			if (!string_0.StartsWith("Name [/];"))
			{
				int num = string_0.IndexOf("[") + 1;
				int num2 = string_0.IndexOf("]; Color");
				string string_ = string_0.Substring(num, num2 - num);
				@class = new Class26(string_);
			}
			int num3 = string_0.IndexOf('=') + 1;
			int num4 = string_0.IndexOf(',');
			@class.int_0 = Convert.ToInt32(string_0.Substring(num3, num4 - num3));
			string_0 = string_0.Substring(num4 + 4);
			num4 = string_0.IndexOf(',');
			@class.int_1 = Convert.ToInt32(string_0.Substring(0, num4));
			string_0 = string_0.Substring(num4 + 4);
			num4 = string_0.IndexOf(',');
			@class.int_2 = Convert.ToInt32(string_0.Substring(0, num4));
			string_0 = string_0.Substring(num4 + 4);
			num4 = string_0.IndexOf(']');
			@class.int_3 = Convert.ToInt32(string_0.Substring(0, num4));
			return @class;
		}

		private void method_10(XmlWriter xmlWriter_0, Class62 class62_0)
		{
			xmlWriter_0.WriteStartDocument();
			xmlWriter_0.WriteStartElement(class62_0.string_0);
			xmlWriter_0.WriteElementString("Alignment", class62_0.alignment_0.ToString());
			xmlWriter_0.WriteElementString("Angle", class62_0.int_1.ToString());
			string value = this.method_11(class62_0.class26_0);
			xmlWriter_0.WriteElementString("BackColor", value);
			xmlWriter_0.WriteElementString("BarcodeType", class62_0.barcodeType_0.ToString());
			string value2 = this.method_11(class62_0.class26_1);
			xmlWriter_0.WriteElementString("ForeColor", value2);
			xmlWriter_0.WriteElementString("MaximumTextLength", class62_0.int_0.ToString());
			xmlWriter_0.WriteElementString("Size", class62_0.class25_0.ToString());
			xmlWriter_0.WriteElementString("ShowText", class62_0.bool_0.ToString());
			xmlWriter_0.WriteElementString("Text", class62_0.string_1.ToString());
			xmlWriter_0.WriteEndElement();
			xmlWriter_0.WriteEndDocument();
		}

		private string method_11(Class26 class26_0)
		{
			string text = "Name [";
			text += (class26_0.bool_0 ? class26_0.string_0 : "/];");
			object obj = text;
			return string.Concat(obj, "]; Color [A=", class26_0.int_0, ", R=", class26_0.int_1, ", G=", class26_0.int_2, ", B=", class26_0.int_3, "]");
		}

		private Class62 method_12()
		{
			Class62 @class = new Class62();
			@class.alignment_0 = (Alignment)this.propertyInfo_0.GetValue(this.object_0, new object[0]);
			@class.int_1 = (int)this.propertyInfo_1.GetValue(this.object_0, new object[0]);
			@class.class26_0 = (Class26)this.propertyInfo_6.GetValue(this.object_0, new object[0]);
			@class.barcodeType_0 = (BarcodeType)this.propertyInfo_3.GetValue(this.object_0, new object[0]);
			@class.class26_1 = (Class26)this.propertyInfo_7.GetValue(this.object_0, new object[0]);
			@class.int_0 = (int)this.propertyInfo_4.GetValue(this.object_0, new object[0]);
			@class.class25_0 = (Class25)this.propertyInfo_5.GetValue(this.object_0, new object[0]);
			@class.string_1 = (string)this.propertyInfo_2.GetValue(this.object_0, new object[0]);
			@class.bool_0 = (bool)this.propertyInfo_8.GetValue(this.object_0, new object[0]);
			return @class;
		}
	}
}
