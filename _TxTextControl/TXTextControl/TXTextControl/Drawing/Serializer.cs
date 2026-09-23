using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Xml;
using ns17;

namespace TXTextControl.Drawing
{
	internal static class Serializer
	{
		internal class Class182 : IComparer<System.Xml.XmlElement>
		{
			public int Compare(System.Xml.XmlElement x, System.Xml.XmlElement y)
			{
				string text = x.Attributes["name"].Value.Substring(3);
				int num = ((text.Length != 0) ? Convert.ToInt32(text) : 0);
				string text2 = y.Attributes["name"].Value.Substring(3);
				int value = ((text2.Length != 0) ? Convert.ToInt32(text2) : 0);
				return num.CompareTo(value);
			}
		}

		internal static void Load(Stream stream, SerializationFormat format, out Shape[] shapes, TXDrawing kernel, bool addShapeOffset)
		{
			if (format == SerializationFormat.Binary)
			{
				shapes = null;
				return;
			}
			XmlReader xmlReader = XmlReader.Create(stream);
			shapes = Serializer.ReadXML(xmlReader, kernel, addShapeOffset);
			xmlReader.Close();
		}

		private static Shape[] ReadXML(XmlReader p_xmlReader, TXDrawing p_icControl, bool addShapeOffset)
		{
			p_xmlReader.Read();
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.Load(p_xmlReader);
			XmlNodeList elementsByTagName = xmlDocument.GetElementsByTagName("wp:wpc");
			XmlNodeList elementsByTagName2 = xmlDocument.GetElementsByTagName("wp:wsp");
			bool flag = elementsByTagName.Count > 0;
			Shape[] array = new Shape[elementsByTagName2.Count];
			double borderOffset = 0.0;
			if (flag)
			{
				bool flag2 = elementsByTagName[0].Attributes["tx"] != null;
				foreach (System.Xml.XmlElement childNode in elementsByTagName[0].ChildNodes)
				{
					Serializer.HandleWPC_BG(childNode, p_icControl);
					Serializer.HandleWPC_Whole(childNode, p_icControl);
				}
				if (!flag2)
				{
					p_icControl.Int32_3 = p_icControl.BorderWidth;
				}
				if (addShapeOffset)
				{
					borderOffset = MeasuringHelper.Twips2EMU(p_icControl.BorderWidth / 2);
				}
			}
			int num = 0;
			while (true)
			{
				if (num < elementsByTagName2.Count)
				{
					System.Xml.XmlElement xmlElement = ((System.Xml.XmlElement)elementsByTagName2[num])["wp:spPr"];
					System.Xml.XmlElement xmlElement2 = xmlElement["a:prstGeom"];
					if (xmlElement2 == null)
					{
						break;
					}
					array[num] = new Shape(Serializer.GetType(xmlElement2));
					XmlAttribute xmlAttribute;
					if ((xmlAttribute = elementsByTagName2[num].Attributes["autosize"]) != null)
					{
						array[num].method_5((xmlAttribute.Value == "1") ? true : false);
					}
					else
					{
						array[num].method_5(!flag);
					}
					XmlAttribute xmlAttribute2;
					if ((xmlAttribute2 = elementsByTagName2[num].Attributes["movable"]) != null)
					{
						array[num].Movable = ((xmlAttribute2.Value == "1") ? true : false);
					}
					else
					{
						array[num].Movable = flag;
					}
					XmlAttribute xmlAttribute3;
					if ((xmlAttribute3 = elementsByTagName2[num].Attributes["sizable"]) != null)
					{
						array[num].Sizable = ((xmlAttribute3.Value == "1") ? true : false);
					}
					else
					{
						array[num].Sizable = flag;
					}
					XmlAttribute xmlAttribute4;
					if ((xmlAttribute4 = elementsByTagName2[num].Attributes["selected"]) != null && xmlAttribute4.Value == "1")
					{
						array[num].Boolean_8 = true;
					}
					XmlAttribute xmlAttribute5;
					if ((xmlAttribute5 = elementsByTagName2[num].Attributes["fitToCanvas"]) != null && xmlAttribute5.Value == "1")
					{
						array[num].Boolean_7 = true;
					}
					array[num].Class174_0.Dictionary_0 = Serializer.GetAvLstValues(xmlElement2);
					System.Xml.XmlElement xmlElement3 = xmlElement["a:xfrm"];
					if (xmlElement3.Attributes["rot"] != null)
					{
						array[num].Int32_4 = Convert.ToInt32(xmlElement3.Attributes["rot"].Value) / 60000;
					}
					array[num].Class174_0.Class178_1 = Serializer.GetShapeBounds(xmlElement3, borderOffset);
					bool isFlipH = xmlElement3.Attributes["flipH"] != null;
					bool isFlipV = xmlElement3.Attributes["flipV"] != null;
					array[num].Flip_1 = Helper.GetFlipEnum(isFlipH, isFlipV);
					System.Xml.XmlElement solidFill;
					if ((solidFill = xmlElement["a:solidFill"]) != null)
					{
						Class176 internalColor = Serializer.GetInternalColor(solidFill);
						Color fillColor = ((internalColor.String_0 != null) ? Color.FromName(internalColor.String_0) : Color.FromArgb(internalColor.Byte_0, internalColor.Byte_3, internalColor.Byte_2, internalColor.Byte_1));
						array[num].Fill_0 = new Shape.Fill(fillColor, array[num]);
					}
					else if ((solidFill = xmlElement["a:noFill"]) != null)
					{
						array[num].Fill_0 = new Shape.Fill(Color.FromArgb(0, 255, 255, 255), array[num]);
					}
					System.Xml.XmlElement xmlElement4 = xmlElement["a:ln"];
					if (xmlElement4 != null)
					{
						array[num].Outline_0 = Serializer.GetInternalOutline(xmlElement4, array[num]);
					}
					array[num].Boolean_9 = false;
					num++;
					continue;
				}
				bool flag4 = (p_icControl.ShapeCollection_0.Boolean_0 = !flag && array.Length == 1 && array[0].AutoSize && p_icControl.BorderWidth == 0);
				p_icControl.IsCanvasVisible = !flag4;
				return array;
			}
			p_icControl.IsCanvasVisible = true;
			return new Shape[0];
		}

		private static void HandleWPC_BG(System.Xml.XmlElement child, TXDrawing p_icControl)
		{
			System.Xml.XmlElement solidFill;
			if (child.Name == "wp:bg" && (solidFill = child["a:solidFill"]) != null)
			{
				p_icControl.Class176_2 = Serializer.GetInternalColor(solidFill);
			}
		}

		private static void HandleWPC_Whole(System.Xml.XmlElement child, TXDrawing p_icControl)
		{
			System.Xml.XmlElement xmlElement;
			if (child.Name == "wp:whole" && (xmlElement = child["a:ln"]) != null)
			{
				XmlAttribute xmlAttribute;
				if ((xmlAttribute = xmlElement.Attributes["w"]) != null)
				{
					p_icControl.Int32_2 = (int)MeasuringHelper.EMU2Twips(Convert.ToInt32(xmlAttribute.Value));
				}
				System.Xml.XmlElement solidFill;
				if ((solidFill = xmlElement["a:solidFill"]) != null)
				{
					p_icControl.Class176_3 = Serializer.GetInternalColor(solidFill);
				}
			}
		}

		private static Dictionary<string, string> GetAvLstValues(System.Xml.XmlElement xePrstGeom)
		{
			System.Xml.XmlElement xmlElement = xePrstGeom["a:avLst"];
			Dictionary<string, string> dictionary = null;
			if (xmlElement != null)
			{
				dictionary = new Dictionary<string, string>();
				for (int i = 0; i < xmlElement.ChildNodes.Count; i++)
				{
					XmlNode xmlNode = xmlElement.ChildNodes[i];
					string value = xmlNode.Attributes[0].Value;
					string value2 = xmlNode.Attributes[1].Value;
					dictionary.Add(value, value2.Substring(4));
				}
			}
			return dictionary;
		}

		private static Class178 GetShapeBounds(System.Xml.XmlElement xfrm, double borderOffset)
		{
			_ = xfrm.Attributes["flipH"];
			_ = xfrm.Attributes["flipV"];
			System.Xml.XmlElement xmlElement = xfrm["a:ext"];
			int num = Convert.ToInt32(xmlElement.Attributes["cx"].Value);
			int num2 = Convert.ToInt32(xmlElement.Attributes["cy"].Value);
			System.Xml.XmlElement xmlElement2 = xfrm["a:off"];
			int num3 = Convert.ToInt32(xmlElement2.Attributes["x"].Value);
			int num4 = Convert.ToInt32(xmlElement2.Attributes["y"].Value);
			return new Class178((double)num3 + borderOffset, (double)num4 + borderOffset, num, num2, bool_1: true);
		}

		private static Class176 GetInternalColor(System.Xml.XmlElement solidFill)
		{
			System.Xml.XmlElement xmlElement = solidFill["a:srgbClr"];
			XmlAttribute xmlAttribute;
			Class176 @class;
			if ((xmlAttribute = xmlElement.Attributes["syscol"]) != null)
			{
				@class = Class176.smethod_3(xmlAttribute.Value);
			}
			else
			{
				string value = xmlElement.Attributes["val"].Value;
				int value2 = int.Parse(value, NumberStyles.HexNumber);
				byte[] bytes = BitConverter.GetBytes(value2);
				if (!BitConverter.IsLittleEndian)
				{
					Array.Reverse(bytes);
				}
				@class = new Class176();
				@class.Byte_1 = bytes[0];
				@class.Byte_2 = bytes[1];
				@class.Byte_3 = bytes[2];
			}
			System.Xml.XmlElement xmlElement2 = xmlElement["a:alpha"];
			if (xmlElement2 != null)
			{
				XmlAttribute xmlAttribute2;
				if ((xmlAttribute2 = xmlElement2.Attributes["RGBAlphaVal"]) != null)
				{
					@class.Byte_0 = Convert.ToByte(xmlAttribute2.Value);
				}
				else
				{
					string value3 = xmlElement2.Attributes["val"].Value;
					int num = Convert.ToInt32(value3);
					@class.Byte_0 = Convert.ToByte((double)num / 1000.0 / 100.0 * 255.0);
				}
			}
			return @class;
		}

		private static Shape.Outline GetInternalOutline(System.Xml.XmlElement line, Shape shape)
		{
			System.Xml.XmlElement xmlElement = line["a:solidFill"];
			Color outlineColor = default(Color);
			if (xmlElement != null)
			{
				System.Xml.XmlElement xmlElement2 = xmlElement["a:srgbClr"];
				XmlAttribute xmlAttribute;
				if ((xmlAttribute = xmlElement2.Attributes["syscol"]) != null)
				{
					outlineColor = Color.FromName(xmlAttribute.Value);
				}
				else
				{
					string value = xmlElement2.Attributes["val"].Value;
					int value2 = int.Parse(value, NumberStyles.HexNumber);
					byte[] bytes = BitConverter.GetBytes(value2);
					if (!BitConverter.IsLittleEndian)
					{
						Array.Reverse(bytes);
					}
					outlineColor = Color.FromArgb(bytes[2], bytes[1], bytes[0]);
				}
			}
			else if (line["a:noFill"] != null)
			{
				outlineColor = Color.Transparent;
			}
			int width = 20;
			if (line.Attributes["w"] != null)
			{
				width = (int)Math.Round(MeasuringHelper.EMU2Twips(Convert.ToInt32(line.Attributes["w"].Value)), MidpointRounding.ToEven);
			}
			return new Shape.Outline(outlineColor, width, shape);
		}

		private static ShapeType GetType(System.Xml.XmlElement prstGeom)
		{
			string value = prstGeom.Attributes["prst"].Value;
			return Serializer.GetShapeType(value);
		}

		internal static ShapeType GetShapeType(string shapeTypeDecleration)
		{
			switch (shapeTypeDecleration)
			{
			case "rect":
				return ShapeType.Rectangle;
			case "diagStripe":
				return ShapeType.DiagonalStripe;
			case "lineInv":
				return ShapeType.LineInverse;
			case "rtTriangle":
				return ShapeType.RightTriangle;
			case "round1Rect":
				return ShapeType.Round1Rectangle;
			case "round2DiagRect":
				return ShapeType.Round2DiagonalRectangle;
			case "round2SameRect":
				return ShapeType.Round2SameRectangle;
			case "roundRect":
				return ShapeType.RoundRectangle;
			case "snip1Rect":
				return ShapeType.Snip1Rectangle;
			case "snip2DiagRect":
				return ShapeType.Snip2DiagonalRectangle;
			case "snip2SameRect":
				return ShapeType.Snip2SameRectangle;
			case "snipRoundRect":
				return ShapeType.SnipRoundRectangle;
			case "uturnArrow":
				return ShapeType.UTurnArrow;
			case "wedgeRectCallout":
				return ShapeType.WedgeRectangleCallout;
			case "wedgeRoundRectCallout":
				return ShapeType.WedgeRoundRectangleCallout;
			default:
				try
				{
					return (ShapeType)Enum.Parse(typeof(ShapeType), char.ToUpper(shapeTypeDecleration[0]) + shapeTypeDecleration.Substring(1));
				}
				catch
				{
					return ShapeType.Rectangle;
				}
			}
		}

		internal static void Save(TXDrawing kernel, Stream stream, SerializationFormat format, Shape[] internalShape, bool isWPC, int borderOffset)
		{
			if (format != SerializationFormat.Binary)
			{
				XmlWriterSettings xmlWriterSettings = new XmlWriterSettings();
				xmlWriterSettings.NewLineOnAttributes = true;
				xmlWriterSettings.Indent = true;
				XmlWriter xmlWriter = XmlWriter.Create(stream, xmlWriterSettings);
				Serializer.WriteXML(kernel, xmlWriter, internalShape, isWPC, borderOffset);
				xmlWriter.Close();
			}
		}

		private static void WriteXML(TXDrawing kernel, XmlWriter p_xmlWriter, Shape[] p_risData, bool isWPC, int borderOffset)
		{
			XmlDocument xmlDocument = new XmlDocument();
			System.Xml.XmlElement xmlElement = (System.Xml.XmlElement)xmlDocument.AppendChild(xmlDocument.CreateElement("w", "document", "http://purl.oclc.org/ooxml/wordprocessingml/main"));
			xmlElement.SetAttribute("xmlns:a", "http://purl.oclc.org/ooxml/drawingml/main");
			xmlElement.SetAttribute("xmlns:wp", "http://purl.oclc.org/ooxml/drawingml/wordprocessingDrawing");
			System.Xml.XmlElement xmlElement2 = xmlElement;
			if (isWPC)
			{
				System.Xml.XmlElement xmlElement3 = xmlDocument.CreateElement("wp", "wpc", "http://purl.oclc.org/ooxml/drawingml/wordprocessingDrawing");
				xmlElement.AppendChild(xmlElement3);
				XmlAttribute xmlAttribute = xmlDocument.CreateAttribute("tx");
				xmlAttribute.Value = "1";
				xmlElement3.Attributes.Append(xmlAttribute);
				System.Xml.XmlElement newChild = Serializer.CreateCT_BackgroundFormatting(kernel, xmlDocument);
				xmlElement3.AppendChild(newChild);
				System.Xml.XmlElement newChild2 = Serializer.CreateCT_WholeE2oFormatting(kernel, xmlDocument);
				xmlElement3.AppendChild(newChild2);
				xmlElement2 = xmlElement3;
			}
			foreach (Shape shape in p_risData)
			{
				xmlElement2.AppendChild(Serializer.ShapeToXML(shape, xmlDocument, borderOffset));
			}
			xmlDocument.Save(p_xmlWriter);
		}

		private static System.Xml.XmlElement CreateCT_BackgroundFormatting(TXDrawing kernel, XmlDocument doc)
		{
			System.Xml.XmlElement xmlElement = doc.CreateElement("wp", "bg", "http://purl.oclc.org/ooxml/drawingml/wordprocessingDrawing");
			if (kernel.BackColor != null)
			{
				xmlElement.AppendChild(Serializer.CreateCT_ColorChoice_WPC_BG(kernel, doc));
			}
			return xmlElement;
		}

		private static System.Xml.XmlElement CreateCT_WholeE2oFormatting(TXDrawing kernel, XmlDocument doc)
		{
			System.Xml.XmlElement xmlElement = doc.CreateElement("wp", "whole", "http://purl.oclc.org/ooxml/drawingml/wordprocessingDrawing");
			if (kernel.BorderWidth > 0)
			{
				xmlElement.AppendChild(Serializer.CreateCT_LineProperties_WPC_Whole(kernel, doc));
			}
			return xmlElement;
		}

		private static System.Xml.XmlElement ShapeToXML(Shape shape, XmlDocument doc, int borderOffset)
		{
			System.Xml.XmlElement xmlElement = doc.CreateElement("wp", "wsp", "http://purl.oclc.org/ooxml/drawingml/wordprocessingDrawing");
			XmlAttribute xmlAttribute = doc.CreateAttribute("autosize");
			xmlAttribute.Value = (shape.AutoSize ? "1" : "0");
			xmlElement.Attributes.Append(xmlAttribute);
			XmlAttribute xmlAttribute2 = doc.CreateAttribute("movable");
			xmlAttribute2.Value = (shape.Movable ? "1" : "0");
			xmlElement.Attributes.Append(xmlAttribute2);
			XmlAttribute xmlAttribute3 = doc.CreateAttribute("sizable");
			xmlAttribute3.Value = (shape.Sizable ? "1" : "0");
			xmlElement.Attributes.Append(xmlAttribute3);
			if (shape.IsSelected)
			{
				XmlAttribute xmlAttribute4 = doc.CreateAttribute("selected");
				xmlAttribute4.Value = "1";
				xmlElement.Attributes.Append(xmlAttribute4);
			}
			if (!shape.CanFitToCanvas)
			{
				XmlAttribute xmlAttribute5 = doc.CreateAttribute("fitToCanvas");
				xmlAttribute5.Value = "1";
				xmlElement.Attributes.Append(xmlAttribute5);
			}
			System.Xml.XmlElement newChild = doc.CreateElement("wp", "cNvSpPr", "http://purl.oclc.org/ooxml/drawingml/wordprocessingDrawing");
			xmlElement.AppendChild(newChild);
			xmlElement.AppendChild(Serializer.CreateShapePropterties(shape, doc, borderOffset));
			System.Xml.XmlElement newChild2 = doc.CreateElement("wp", "bodyPr", "http://purl.oclc.org/ooxml/drawingml/wordprocessingDrawing");
			xmlElement.AppendChild(newChild2);
			return xmlElement;
		}

		private static System.Xml.XmlElement CreateShapePropterties(Shape shape, XmlDocument doc, int borderOffset)
		{
			System.Xml.XmlElement xmlElement = doc.CreateElement("wp", "spPr", "http://purl.oclc.org/ooxml/drawingml/wordprocessingDrawing");
			System.Xml.XmlElement newChild = Serializer.CreateCT_Transform2D(shape, doc, borderOffset);
			xmlElement.AppendChild(newChild);
			System.Xml.XmlElement newChild2 = Serializer.CreateEG_Geometry(shape, doc);
			xmlElement.AppendChild(newChild2);
			System.Xml.XmlElement newChild3 = Serializer.CreateEG_FillProperties(shape, doc);
			xmlElement.AppendChild(newChild3);
			System.Xml.XmlElement newChild4 = Serializer.CreateCT_LineProperties_Shape(shape, doc);
			xmlElement.AppendChild(newChild4);
			System.Xml.XmlElement newChild5 = doc.CreateElement("a", "scene3d", "http://purl.oclc.org/ooxml/drawingml/main");
			xmlElement.AppendChild(newChild5);
			System.Xml.XmlElement newChild6 = doc.CreateElement("a", "sp3d", "http://purl.oclc.org/ooxml/drawingml/main");
			xmlElement.AppendChild(newChild6);
			System.Xml.XmlElement newChild7 = doc.CreateElement("a", "extLst", "http://purl.oclc.org/ooxml/drawingml/main");
			xmlElement.AppendChild(newChild7);
			return xmlElement;
		}

		private static System.Xml.XmlElement CreateCT_Transform2D(Shape shape, XmlDocument doc, int borderOffset)
		{
			System.Xml.XmlElement xmlElement = doc.CreateElement("a", "xfrm", "http://purl.oclc.org/ooxml/drawingml/main");
			System.Xml.XmlElement xmlElement2 = doc.CreateElement("a", "off", "http://purl.oclc.org/ooxml/drawingml/main");
			System.Xml.XmlAttribute xmlAttribute = doc.CreateAttribute("x");
			xmlAttribute.Value = Math.Round(Helper.GetX(shape, -borderOffset, asEmu: true), MidpointRounding.ToEven).ToString();
			xmlElement2.Attributes.Append(xmlAttribute);
			XmlAttribute xmlAttribute2 = doc.CreateAttribute("y");
			xmlAttribute2.Value = Math.Round(Helper.GetY(shape, -borderOffset, asEmu: true), MidpointRounding.ToEven).ToString();
			xmlElement2.Attributes.Append(xmlAttribute2);
			xmlElement.AppendChild(xmlElement2);
			System.Xml.XmlElement xmlElement3 = doc.CreateElement("a", "ext", "http://purl.oclc.org/ooxml/drawingml/main");
			XmlAttribute xmlAttribute3 = doc.CreateAttribute("cx");
			xmlAttribute3.Value = Math.Round(Helper.GetWidth(shape, asEmu: true), MidpointRounding.ToEven).ToString();
			xmlElement3.Attributes.Append(xmlAttribute3);
			XmlAttribute xmlAttribute4 = doc.CreateAttribute("cy");
			xmlAttribute4.Value = Math.Round(Helper.GetHeight(shape, asEmu: true), MidpointRounding.ToEven).ToString();
			xmlElement3.Attributes.Append(xmlAttribute4);
			xmlElement.AppendChild(xmlElement3);
			if (shape.Angle != 0)
			{
				XmlAttribute xmlAttribute5 = doc.CreateAttribute("rot");
				xmlAttribute5.Value = (shape.Angle * 60000).ToString();
				xmlElement.Attributes.Append(xmlAttribute5);
			}
			if ((shape.Flip & Flip.Horizontal) == Flip.Horizontal)
			{
				XmlAttribute xmlAttribute6 = doc.CreateAttribute("flipH");
				xmlAttribute6.Value = "1";
				xmlElement.Attributes.Append(xmlAttribute6);
			}
			if ((shape.Flip & Flip.Vertical) == Flip.Vertical)
			{
				XmlAttribute xmlAttribute7 = doc.CreateAttribute("flipV");
				xmlAttribute7.Value = "1";
				xmlElement.Attributes.Append(xmlAttribute7);
			}
			return xmlElement;
		}

		private static System.Xml.XmlElement CreateEG_Geometry(Shape shape, XmlDocument doc)
		{
			System.Xml.XmlElement xmlElement = doc.CreateElement("a", "prstGeom", "http://purl.oclc.org/ooxml/drawingml/main");
			XmlAttribute xmlAttribute = doc.CreateAttribute("prst");
			xmlAttribute.Value = Serializer.GetShapeTypeDeclaration(shape.Type);
			xmlElement.Attributes.Append(xmlAttribute);
			System.Xml.XmlElement xmlElement2 = Serializer.CreateAvLst(shape, doc);
			if (xmlElement2.ChildNodes.Count > 0)
			{
				xmlElement.AppendChild(xmlElement2);
			}
			return xmlElement;
		}

		internal static string GetShapeTypeDeclaration(ShapeType type)
		{
			string text = type.ToString();
			text = char.ToLower(text[0]) + text.Substring(1);
			return type switch
			{
				ShapeType.RoundRectangle => "roundRect", 
				ShapeType.Round1Rectangle => "round1Rect", 
				ShapeType.Round2SameRectangle => "round2SameRect", 
				ShapeType.Round2DiagonalRectangle => "round2DiagRect", 
				ShapeType.SnipRoundRectangle => "snipRoundRect", 
				ShapeType.Snip1Rectangle => "snip1Rect", 
				ShapeType.Snip2SameRectangle => "snip2SameRect", 
				ShapeType.Snip2DiagonalRectangle => "snip2DiagRect", 
				ShapeType.LineInverse => "lineInv", 
				ShapeType.RightTriangle => "rtTriangle", 
				ShapeType.Rectangle => "rect", 
				ShapeType.WedgeRectangleCallout => "wedgeRectCallout", 
				ShapeType.WedgeRoundRectangleCallout => "wedgeRoundRectCallout", 
				ShapeType.DiagonalStripe => "diagStripe", 
				ShapeType.UTurnArrow => "uturnArrow", 
				_ => text, 
			};
		}

		private static System.Xml.XmlElement CreateAvLst(Shape shape, XmlDocument doc)
		{
			bool flag = true;
			System.Xml.XmlElement xmlElement = doc.CreateElement("a", "avLst", "http://purl.oclc.org/ooxml/drawingml/main");
			List<System.Xml.XmlElement> list = new List<System.Xml.XmlElement>();
			foreach (AdjustObject item in shape.Class174_0.Class172_0)
			{
				flag = item.Value == item.DefaultValue && flag;
				System.Xml.XmlElement xmlElement2 = doc.CreateElement("a", "gd", "http://purl.oclc.org/ooxml/drawingml/main");
				XmlAttribute xmlAttribute = doc.CreateAttribute("name");
				xmlAttribute.Value = item.AdjustPropertyName.ToLower();
				xmlElement2.Attributes.Append(xmlAttribute);
				XmlAttribute xmlAttribute2 = doc.CreateAttribute("fmla");
				xmlAttribute2.Value = "val " + Math.Round(item.Value);
				xmlElement2.Attributes.Append(xmlAttribute2);
				list.Add(xmlElement2);
			}
			list.Sort(new Class182());
			if (shape.Class183_0.ShapeObject_0.SaveHF)
			{
				flag = false;
				System.Xml.XmlElement xmlElement3 = doc.CreateElement("a", "gd", "http://purl.oclc.org/ooxml/drawingml/main");
				XmlAttribute xmlAttribute3 = doc.CreateAttribute("name");
				xmlAttribute3.Value = "hf";
				xmlElement3.Attributes.Append(xmlAttribute3);
				XmlAttribute xmlAttribute4 = doc.CreateAttribute("fmla");
				xmlAttribute4.Value = "val " + Math.Round(shape.Class183_0.ShapeObject_0.Double_0);
				xmlElement3.Attributes.Append(xmlAttribute4);
				list.Add(xmlElement3);
			}
			if (shape.Class183_0.ShapeObject_0.SaveVF)
			{
				flag = false;
				System.Xml.XmlElement xmlElement4 = doc.CreateElement("a", "gd", "http://purl.oclc.org/ooxml/drawingml/main");
				XmlAttribute xmlAttribute5 = doc.CreateAttribute("name");
				xmlAttribute5.Value = "vf";
				xmlElement4.Attributes.Append(xmlAttribute5);
				XmlAttribute xmlAttribute6 = doc.CreateAttribute("fmla");
				xmlAttribute6.Value = "val " + Math.Round(shape.Class183_0.ShapeObject_0.Double_1);
				xmlElement4.Attributes.Append(xmlAttribute6);
				list.Add(xmlElement4);
			}
			if (flag)
			{
				return doc.CreateElement("a", "avLst", "http://purl.oclc.org/ooxml/drawingml/main");
			}
			foreach (System.Xml.XmlElement item2 in list)
			{
				xmlElement.AppendChild(item2);
			}
			return xmlElement;
		}

		private static System.Xml.XmlElement CreateEG_FillProperties(Shape shape, XmlDocument doc)
		{
			string localName = "solidFill";
			switch (shape.ShapeFill.Enum35_0)
			{
			case Enum35.const_0:
				localName = "noFill";
				break;
			case Enum35.const_1:
				localName = "solidFill";
				break;
			case Enum35.const_2:
				localName = "solidFill";
				break;
			case Enum35.const_3:
				localName = "solidFill";
				break;
			case Enum35.const_4:
				localName = "solidFill";
				break;
			case Enum35.const_5:
				localName = "solidFill";
				break;
			}
			_ = shape.ShapeFill.Color;
			System.Xml.XmlElement xmlElement = doc.CreateElement("a", localName, "http://purl.oclc.org/ooxml/drawingml/main");
			xmlElement.AppendChild(Serializer.CreateEG_ColorChoice(shape, doc));
			return xmlElement;
		}

		private static System.Xml.XmlElement CreateEG_ColorChoice(Shape shape, XmlDocument doc)
		{
			System.Xml.XmlElement xmlElement = doc.CreateElement("a", "srgbClr", "http://purl.oclc.org/ooxml/drawingml/main");
			XmlAttribute xmlAttribute = doc.CreateAttribute("val");
			xmlAttribute.Value = shape.ShapeFill.Color.R.ToString("X2") + shape.ShapeFill.Color.G.ToString("X2") + shape.ShapeFill.Color.B.ToString("X2");
			xmlElement.Attributes.Append(xmlAttribute);
			int a;
			if ((a = shape.ShapeFill.Color.A) != 255)
			{
				System.Xml.XmlElement xmlElement2 = doc.CreateElement("a", "alpha", "http://purl.oclc.org/ooxml/drawingml/main");
				XmlAttribute xmlAttribute2 = doc.CreateAttribute("val");
				xmlAttribute2.Value = ((int)Math.Round((double)a / 255.0 * 100000.0, MidpointRounding.ToEven)).ToString();
				xmlElement2.Attributes.Append(xmlAttribute2);
				xmlAttribute2 = doc.CreateAttribute("RGBAlphaVal");
				xmlAttribute2.Value = a.ToString();
				xmlElement2.Attributes.Append(xmlAttribute2);
				xmlElement.AppendChild(xmlElement2);
			}
			if (shape.ShapeFill.Color.IsNamedColor)
			{
				XmlAttribute xmlAttribute3 = doc.CreateAttribute("syscol");
				xmlAttribute3.Value = shape.ShapeFill.Color.Name;
				xmlElement.Attributes.Append(xmlAttribute3);
			}
			return xmlElement;
		}

		private static System.Xml.XmlElement CreateCT_LineProperties_Shape(Shape shape, XmlDocument doc)
		{
			System.Xml.XmlElement xmlElement = doc.CreateElement("a", "ln", "http://purl.oclc.org/ooxml/drawingml/main");
			XmlAttribute xmlAttribute = doc.CreateAttribute("w");
			xmlAttribute.Value = Math.Round(MeasuringHelper.Twips2EMU(shape.ShapeOutline.Width), MidpointRounding.ToEven).ToString();
			xmlElement.Attributes.Append(xmlAttribute);
			xmlElement.AppendChild(Serializer.CreateCT_ColorChoice_ShapeOutline(shape, doc));
			return xmlElement;
		}

		private static System.Xml.XmlElement CreateCT_LineProperties_WPC_Whole(TXDrawing kernel, XmlDocument doc)
		{
			System.Xml.XmlElement xmlElement = doc.CreateElement("a", "ln", "http://purl.oclc.org/ooxml/drawingml/main");
			if (kernel.BorderWidth > 0)
			{
				XmlAttribute xmlAttribute = doc.CreateAttribute("w");
				xmlAttribute.Value = Math.Round(MeasuringHelper.Twips2EMU(kernel.BorderWidth), MidpointRounding.ToEven).ToString();
				xmlElement.Attributes.Append(xmlAttribute);
			}
			if (kernel.BorderColor != null)
			{
				xmlElement.AppendChild(Serializer.CreateCT_ColorChoice_WPC_Whole(kernel, doc));
			}
			return xmlElement;
		}

		private static System.Xml.XmlElement CreateCT_ColorChoice_ShapeOutline(Shape shape, XmlDocument doc)
		{
			_ = shape.ShapeOutline.Color;
			System.Xml.XmlElement xmlElement = doc.CreateElement("a", "solidFill", "http://purl.oclc.org/ooxml/drawingml/main");
			System.Xml.XmlElement xmlElement2 = doc.CreateElement("a", "srgbClr", "http://purl.oclc.org/ooxml/drawingml/main");
			XmlAttribute xmlAttribute = doc.CreateAttribute("val");
			xmlAttribute.Value = shape.ShapeOutline.Color.R.ToString("X2") + shape.ShapeOutline.Color.G.ToString("X2") + shape.ShapeOutline.Color.B.ToString("X2");
			xmlElement2.Attributes.Append(xmlAttribute);
			xmlElement.AppendChild(xmlElement2);
			int a;
			if ((a = shape.ShapeOutline.Color.A) != 255)
			{
				System.Xml.XmlElement xmlElement3 = doc.CreateElement("a", "alpha", "http://purl.oclc.org/ooxml/drawingml/main");
				XmlAttribute xmlAttribute2 = doc.CreateAttribute("val");
				xmlAttribute2.Value = ((int)Math.Round((double)a / 255.0 * 100000.0, MidpointRounding.ToEven)).ToString();
				xmlElement3.Attributes.Append(xmlAttribute2);
				xmlAttribute2 = doc.CreateAttribute("RGBAlphaVal");
				xmlAttribute2.Value = a.ToString();
				xmlElement3.Attributes.Append(xmlAttribute2);
				xmlElement2.AppendChild(xmlElement3);
			}
			if (shape.ShapeOutline.Color.IsNamedColor)
			{
				XmlAttribute xmlAttribute3 = doc.CreateAttribute("syscol");
				xmlAttribute3.Value = shape.ShapeOutline.Color.Name;
				xmlElement2.Attributes.Append(xmlAttribute3);
			}
			return xmlElement;
		}

		private static System.Xml.XmlElement CreateCT_ColorChoice_WPC_BG(TXDrawing kernel, XmlDocument doc)
		{
			System.Xml.XmlElement xmlElement = doc.CreateElement("a", "solidFill", "http://purl.oclc.org/ooxml/drawingml/main");
			System.Xml.XmlElement xmlElement2 = doc.CreateElement("a", "srgbClr", "http://purl.oclc.org/ooxml/drawingml/main");
			XmlAttribute xmlAttribute = doc.CreateAttribute("val");
			xmlAttribute.Value = kernel.BackColor.Byte_3.ToString("X2") + kernel.BackColor.Byte_2.ToString("X2") + kernel.BackColor.Byte_1.ToString("X2");
			xmlElement2.Attributes.Append(xmlAttribute);
			xmlElement.AppendChild(xmlElement2);
			int byte_;
			if ((byte_ = kernel.BackColor.Byte_0) != 255)
			{
				System.Xml.XmlElement xmlElement3 = doc.CreateElement("a", "alpha", "http://purl.oclc.org/ooxml/drawingml/main");
				XmlAttribute xmlAttribute2 = doc.CreateAttribute("val");
				xmlAttribute2.Value = ((int)Math.Round((double)byte_ / 255.0 * 100000.0, MidpointRounding.ToEven)).ToString();
				xmlElement3.Attributes.Append(xmlAttribute2);
				xmlAttribute2 = doc.CreateAttribute("RGBAlphaVal");
				xmlAttribute2.Value = byte_.ToString();
				xmlElement3.Attributes.Append(xmlAttribute2);
				xmlElement2.AppendChild(xmlElement3);
			}
			if (kernel.BackColor.String_0 != null)
			{
				XmlAttribute xmlAttribute3 = doc.CreateAttribute("syscol");
				xmlAttribute3.Value = kernel.BackColor.String_0;
				xmlElement2.Attributes.Append(xmlAttribute3);
			}
			return xmlElement;
		}

		private static System.Xml.XmlElement CreateCT_ColorChoice_WPC_Whole(TXDrawing kernel, XmlDocument doc)
		{
			System.Xml.XmlElement xmlElement = doc.CreateElement("a", "solidFill", "http://purl.oclc.org/ooxml/drawingml/main");
			System.Xml.XmlElement xmlElement2 = doc.CreateElement("a", "srgbClr", "http://purl.oclc.org/ooxml/drawingml/main");
			XmlAttribute xmlAttribute = doc.CreateAttribute("val");
			xmlAttribute.Value = kernel.BorderColor.Byte_3.ToString("X2") + kernel.BorderColor.Byte_2.ToString("X2") + kernel.BorderColor.Byte_1.ToString("X2");
			xmlElement2.Attributes.Append(xmlAttribute);
			xmlElement.AppendChild(xmlElement2);
			int byte_;
			if ((byte_ = kernel.BorderColor.Byte_0) != 255)
			{
				System.Xml.XmlElement xmlElement3 = doc.CreateElement("a", "alpha", "http://purl.oclc.org/ooxml/drawingml/main");
				XmlAttribute xmlAttribute2 = doc.CreateAttribute("val");
				xmlAttribute2.Value = ((int)Math.Round((double)byte_ / 255.0 * 100000.0, MidpointRounding.ToEven)).ToString();
				xmlElement3.Attributes.Append(xmlAttribute2);
				xmlAttribute2 = doc.CreateAttribute("RGBAlphaVal");
				xmlAttribute2.Value = byte_.ToString();
				xmlElement3.Attributes.Append(xmlAttribute2);
				xmlElement2.AppendChild(xmlElement3);
			}
			if (kernel.BorderColor.String_0 != null)
			{
				XmlAttribute xmlAttribute3 = doc.CreateAttribute("syscol");
				xmlAttribute3.Value = kernel.BorderColor.String_0;
				xmlElement2.Attributes.Append(xmlAttribute3);
			}
			return xmlElement;
		}
	}
}
