using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Xml;
using TXTextControl;

namespace ns19
{
	internal class Class378
	{
		private static Regex regex_0 = new Regex("[^\\s]+");

		private static Regex regex_1 = new Regex("[A-Za-z]\\s*[-\\d,\\.\\+\\s]*");

		private static Regex regex_2 = new Regex("\\w+\\s*\\([-\\d,\\.\\+\\seE]+\\)");

		private static Regex regex_3 = new Regex("\\w+\\s*\\([-\\d,\\.\\+\\s(deg)]+\\)");

		private static Regex regex_4 = new Regex("\\w[-\\w\\s]*:[^;}]+");

		private static Regex regex_5 = new Regex("[\\.\\w][^}]+");

		private static Regex regex_6 = new Regex("[+-]*(\\d*\\.)*\\d+([eE][+-]\\d+)*\\w*");

		private static Regex regex_7 = new Regex("[+-]*(\\d*\\.)*\\d+");

		private static Regex regex_8 = new Regex("\\d+%*");

		private static Regex regex_9 = new Regex("[a-z%]+");

		private static Regex regex_10 = new Regex("#[^)]+");

		internal static System.Xml.XmlElement smethod_0(XmlTextReader xmlTextReader_0, out XmlDocument xmlDocument_0)
		{
			xmlTextReader_0.DtdProcessing = DtdProcessing.Ignore;
			xmlTextReader_0.WhitespaceHandling = WhitespaceHandling.None;
			xmlDocument_0 = new XmlDocument();
			xmlDocument_0.PreserveWhitespace = true;
			xmlDocument_0.Load(xmlTextReader_0);
			xmlTextReader_0.Read();
			return xmlDocument_0["svg"];
		}

		internal static void smethod_1(Class376 class376_0, System.Xml.XmlElement xmlElement_0)
		{
			ITransformAttribute[] itransformAttribute_ = null;
			Struct40 struct40_ = new Struct40("black");
			Struct38 struct38_ = new Struct38("Arial");
			Struct41 struct41_ = new Struct41("none");
			Struct39 struct39_ = new Struct39("start");
			SizeF sizeF_ = ((!Class378.smethod_6(xmlElement_0.Attributes, ref itransformAttribute_, class376_0.RectangleF_1)) ? class376_0.RectangleF_1.Size : (itransformAttribute_[0] as Class387).RectangleF_0.Size);
			foreach (XmlNode item in xmlElement_0)
			{
				Class378.smethod_2(item, class376_0, itransformAttribute_, struct40_, struct41_, struct38_, struct39_, class376_0.RectangleF_1, sizeF_, bool_0: false);
			}
			class376_0.method_0();
		}

		private static void smethod_2(XmlNode xmlNode_0, Class376 class376_0, ITransformAttribute[] itransformAttribute_0, Struct40 struct40_0, Struct41 struct41_0, Struct38 struct38_0, Struct39 struct39_0, RectangleF rectangleF_0, SizeF sizeF_0, bool bool_0)
		{
			if (bool_0)
			{
				switch (xmlNode_0.Name)
				{
				case "style":
				{
					Class380[] array = Class378.smethod_37(xmlNode_0.InnerText);
					Class380[] array2 = array;
					foreach (Class380 @class in array2)
					{
						class376_0.Dictionary_0.Add(@class.Identifier, @class);
					}
					break;
				}
				case "radialGradient":
				{
					Class385 class3 = new Class385(xmlNode_0 as System.Xml.XmlElement);
					class376_0.Dictionary_0.Add(class3.Identifier, class3);
					break;
				}
				case "linearGradient":
				{
					Class384 class2 = new Class384(xmlNode_0 as System.Xml.XmlElement);
					class376_0.Dictionary_0.Add(class2.Identifier, class2);
					break;
				}
				default:
					if (xmlNode_0.Attributes != null)
					{
						XmlAttribute xmlAttribute = xmlNode_0.Attributes["id"];
						class376_0.Dictionary_0.Add(xmlAttribute.Value, new Class379(xmlNode_0));
					}
					break;
				}
				return;
			}
			if (xmlNode_0.Name != "svg")
			{
				Class387 class4 = Class378.smethod_4(class376_0, ref struct40_0, ref struct41_0, ref struct38_0, ref struct39_0, ref itransformAttribute_0, xmlNode_0.Attributes, rectangleF_0, sizeF_0);
				if (class4 != null)
				{
					sizeF_0 = class4.RectangleF_0.Size;
				}
			}
			switch (xmlNode_0.Name)
			{
			case "defs":
			case "g":
			case "svg":
				if (xmlNode_0.Name == "svg")
				{
					string value = xmlNode_0.Attributes["width"].Value;
					string value2 = xmlNode_0.Attributes["height"].Value;
					if (!string.IsNullOrEmpty(value) && !string.IsNullOrEmpty(value2))
					{
						Struct37 struct37_ = new Struct37(value);
						float width = Class378.smethod_36(struct37_, rectangleF_0.Width, struct38_0.Single_0);
						Struct37 struct37_2 = new Struct37(value2);
						float height = Class378.smethod_36(struct37_2, rectangleF_0.Height, struct38_0.Single_0);
						rectangleF_0 = new RectangleF(0f, 0f, width, height);
					}
					sizeF_0 = ((!Class378.smethod_6(xmlNode_0.Attributes, ref itransformAttribute_0, rectangleF_0)) ? rectangleF_0.Size : (itransformAttribute_0[0] as Class387).RectangleF_0.Size);
				}
				foreach (XmlNode item in xmlNode_0)
				{
					Class378.smethod_2(item, class376_0, itransformAttribute_0, struct40_0, struct41_0, struct38_0, struct39_0, rectangleF_0, sizeF_0, xmlNode_0.Name == "defs");
				}
				return;
			case "style":
			{
				Class380[] array3 = Class378.smethod_37(xmlNode_0.InnerText);
				Class380[] array4 = array3;
				foreach (Class380 class6 in array4)
				{
					class376_0.Dictionary_0.Add(class6.Identifier, class6);
				}
				return;
			}
			case "radialGradient":
			{
				Class385 class5 = new Class385(xmlNode_0 as System.Xml.XmlElement);
				class376_0.Dictionary_0.Add(class5.Identifier, class5);
				return;
			}
			}
			Class378.smethod_3(xmlNode_0.Name, class376_0.Dictionary_0, ref itransformAttribute_0, ref struct40_0, ref struct41_0, ref struct38_0, ref struct39_0, sizeF_0);
			switch (xmlNode_0.Name)
			{
			case "symbol":
				Class378.smethod_43(xmlNode_0 as System.Xml.XmlElement, class376_0, itransformAttribute_0, struct40_0, struct41_0, struct38_0, struct39_0, rectangleF_0, sizeF_0);
				break;
			case "use":
				Class378.smethod_44(xmlNode_0 as System.Xml.XmlElement, class376_0, itransformAttribute_0, struct40_0, struct41_0, struct38_0, struct39_0, rectangleF_0, sizeF_0);
				break;
			case "text":
				Class378.smethod_45(xmlNode_0 as System.Xml.XmlElement, class376_0, itransformAttribute_0, struct40_0, struct41_0, struct38_0, struct39_0, rectangleF_0, sizeF_0);
				break;
			case "rect":
				Class378.smethod_10(xmlNode_0 as System.Xml.XmlElement, class376_0, itransformAttribute_0, struct40_0, struct41_0, struct38_0, struct39_0, sizeF_0);
				break;
			case "circle":
				Class378.smethod_12(xmlNode_0 as System.Xml.XmlElement, class376_0, itransformAttribute_0, struct40_0, struct41_0, struct38_0, struct39_0, sizeF_0);
				break;
			case "ellipse":
				Class378.smethod_13(xmlNode_0 as System.Xml.XmlElement, class376_0, itransformAttribute_0, struct40_0, struct41_0, struct38_0, struct39_0, sizeF_0);
				break;
			case "line":
				Class378.smethod_15(xmlNode_0 as System.Xml.XmlElement, class376_0, itransformAttribute_0, struct40_0, struct41_0, struct38_0, struct39_0, sizeF_0);
				break;
			case "polyline":
				Class378.smethod_16(xmlNode_0 as System.Xml.XmlElement, class376_0, itransformAttribute_0, struct40_0, struct41_0, struct38_0, struct39_0, sizeF_0);
				break;
			case "polygon":
				Class378.smethod_17(xmlNode_0 as System.Xml.XmlElement, class376_0, itransformAttribute_0, struct40_0, struct41_0, struct38_0, struct39_0, sizeF_0);
				break;
			case "path":
				Class378.smethod_47(xmlNode_0 as System.Xml.XmlElement, class376_0, itransformAttribute_0, struct40_0, struct41_0, struct38_0, struct39_0, sizeF_0);
				break;
			}
		}

		private static void smethod_3(string string_0, Dictionary<string, Def> dictionary_0, ref ITransformAttribute[] itransformAttribute_0, ref Struct40 struct40_0, ref Struct41 struct41_0, ref Struct38 struct38_0, ref Struct39 struct39_0, SizeF sizeF_0)
		{
			if (dictionary_0.TryGetValue(string_0, out var value) && value is Class380)
			{
				Class378.smethod_5(ref struct40_0, ref struct41_0, ref struct38_0, ref struct39_0, ref itransformAttribute_0, sizeF_0, (value as Class380).List_0);
			}
		}

		private static Class387 smethod_4(Class376 class376_0, ref Struct40 struct40_0, ref Struct41 struct41_0, ref Struct38 struct38_0, ref Struct39 struct39_0, ref ITransformAttribute[] itransformAttribute_0, XmlAttributeCollection xmlAttributeCollection_0, RectangleF rectangleF_0, SizeF sizeF_0)
		{
			Class387 result = null;
			if (xmlAttributeCollection_0 != null)
			{
				if (Class378.smethod_6(xmlAttributeCollection_0, ref itransformAttribute_0, rectangleF_0))
				{
					result = itransformAttribute_0[0] as Class387;
				}
				{
					foreach (XmlAttribute item in xmlAttributeCollection_0)
					{
						switch (item.Name.ToLower())
						{
						case "style":
						{
							MatchCollection matchCollection = Class378.regex_4.Matches(item.Value);
							List<string> list = new List<string>();
							foreach (Match item2 in matchCollection)
							{
								list.Add(item2.Value);
							}
							Class378.smethod_5(ref struct40_0, ref struct41_0, ref struct38_0, ref struct39_0, ref itransformAttribute_0, sizeF_0, list);
							break;
						}
						case "class":
							Class378.smethod_3("." + item.Value, class376_0.Dictionary_0, ref itransformAttribute_0, ref struct40_0, ref struct41_0, ref struct38_0, ref struct39_0, sizeF_0);
							break;
						case "transform":
						{
							MatchCollection matchCollection_ = Class378.regex_2.Matches(item.Value);
							Class378.smethod_7(ref itransformAttribute_0, matchCollection_);
							break;
						}
						default:
							Class378.smethod_8(ref struct40_0, ref struct41_0, ref struct38_0, ref struct39_0, sizeF_0, new string[2] { item.Name, item.Value });
							break;
						}
					}
					return result;
				}
			}
			return result;
		}

		private static void smethod_5(ref Struct40 struct40_0, ref Struct41 struct41_0, ref Struct38 struct38_0, ref Struct39 struct39_0, ref ITransformAttribute[] itransformAttribute_0, SizeF sizeF_0, List<string> list_0)
		{
			foreach (string item in list_0)
			{
				string[] array = item.Split(':');
				if (array[0] == "transform")
				{
					MatchCollection matchCollection_ = Class378.regex_3.Matches(array[1]);
					Class378.smethod_7(ref itransformAttribute_0, matchCollection_);
				}
				else
				{
					Class378.smethod_8(ref struct40_0, ref struct41_0, ref struct38_0, ref struct39_0, sizeF_0, array);
				}
			}
		}

		private static bool smethod_6(XmlAttributeCollection xmlAttributeCollection_0, ref ITransformAttribute[] itransformAttribute_0, RectangleF rectangleF_0)
		{
			XmlAttribute xmlAttribute = xmlAttributeCollection_0["viewBox"];
			if (xmlAttribute != null)
			{
				XmlAttribute xmlAttribute2 = xmlAttributeCollection_0["preserveAspectRatio"];
				ITransformAttribute[] array;
				if (itransformAttribute_0 == null)
				{
					array = new ITransformAttribute[1]
					{
						new Class387(Class378.smethod_22(0, xmlAttribute.Value), xmlAttribute2?.Value, rectangleF_0)
					};
				}
				else
				{
					array = new ITransformAttribute[itransformAttribute_0.Length + 1];
					Array.Copy(itransformAttribute_0, 0, array, 1, itransformAttribute_0.Length);
					array[0] = new Class387(Class378.smethod_22(0, xmlAttribute.Value), xmlAttribute2?.Value, rectangleF_0);
				}
				itransformAttribute_0 = array;
				return true;
			}
			return false;
		}

		private static void smethod_7(ref ITransformAttribute[] itransformAttribute_0, MatchCollection matchCollection_0)
		{
			ITransformAttribute[] array;
			if (itransformAttribute_0 == null)
			{
				array = new ITransformAttribute[matchCollection_0.Count];
			}
			else
			{
				array = new ITransformAttribute[matchCollection_0.Count + itransformAttribute_0.Length];
				Array.Copy(itransformAttribute_0, 0, array, matchCollection_0.Count, itransformAttribute_0.Length);
			}
			int num = 0;
			for (int num2 = matchCollection_0.Count - 1; num2 >= 0; num2--)
			{
				Match match = matchCollection_0[num2];
				string text = match.Value.Substring(0, match.Value.IndexOf('('));
				string string_ = match.Value.Substring(text.Length + 1, match.Value.Length - text.Length - 2);
				float[] array2 = Class378.smethod_22(0, string_);
				switch (text.ToLower())
				{
				case "matrix":
					array[num] = new Class388(array2);
					break;
				case "translate":
					array[num] = new Class389(array2);
					break;
				case "rotate":
					array[num] = new Class390(array2);
					break;
				case "scale":
					array[num] = new Class391(array2);
					break;
				case "skewx":
					array[num] = new Class392(array2, bool_1: true);
					break;
				case "skewy":
					array[num] = new Class392(array2, bool_1: false);
					break;
				default:
					throw new NotSupportedException(text);
				}
				num++;
			}
			itransformAttribute_0 = array;
		}

		private static void smethod_8(ref Struct40 struct40_0, ref Struct41 struct41_0, ref Struct38 struct38_0, ref Struct39 struct39_0, SizeF sizeF_0, string[] string_0)
		{
			switch (string_0[0])
			{
			case "font-family":
				struct38_0.String_0 = string_0[1];
				break;
			case "font-style":
				struct38_0.String_1 = string_0[1];
				break;
			case "font-variant":
				struct38_0.String_2 = string_0[1];
				break;
			case "font-weight":
				struct38_0.Int32_0 = Class378.smethod_31(string_0[1], struct38_0.Int32_0);
				break;
			case "font-stretch":
				struct38_0.String_3 = string_0[1];
				break;
			case "font-size":
				struct38_0.Single_0 = Class378.smethod_29(string_0[1], sizeF_0.Width, struct38_0.Single_0);
				break;
			case "font-size-adjust":
				struct38_0.String_4 = string_0[1];
				break;
			case "font":
				struct38_0.String_5 = string_0[1];
				break;
			case "text-anchor":
				struct39_0.String_0 = string_0[1];
				break;
			case "dominant-baseline":
				struct39_0.String_1 = string_0[1];
				break;
			case "alignment-baseline":
				struct39_0.String_2 = string_0[1];
				break;
			case "baseline-shift":
				struct39_0.String_3 = string_0[1];
				break;
			case "fill":
				struct40_0.String_0 = string_0[1];
				break;
			case "fill-rule":
				struct40_0.String_1 = string_0[1];
				break;
			case "fill-opacity":
				struct40_0.String_2 = string_0[1];
				break;
			case "stroke":
				struct41_0.String_0 = string_0[1];
				break;
			case "stroke-width":
				struct41_0.String_1 = string_0[1];
				break;
			case "stroke-linecap":
				struct41_0.String_2 = string_0[1];
				break;
			case "stroke-linejoin":
				struct41_0.String_3 = string_0[1];
				break;
			case "stroke-miterlimit":
				struct41_0.String_4 = string_0[1];
				break;
			case "stroke-dasharray":
				struct41_0.String_5 = string_0[1];
				break;
			case "stroke-dashoffset":
				struct41_0.String_6 = string_0[1];
				break;
			case "stroke-opacity":
				struct41_0.String_7 = string_0[1];
				break;
			}
		}

		private static void smethod_9(GraphicsPath graphicsPath_0, Class376 class376_0, ITransformAttribute[] itransformAttribute_0, Struct40 struct40_0, Struct41 struct41_0, Struct38 struct38_0, Struct39 struct39_0, SizeF sizeF_0, float float_0)
		{
			Class381 @class = null;
			if (struct40_0.String_0.StartsWith("url(#"))
			{
				Match match = Class378.regex_10.Match(struct40_0.String_0);
				if (match.Length > 0 && class376_0.Dictionary_0.TryGetValue(match.Value.Substring(1), out var value) && value is Class383)
				{
					@class = value as Class383;
				}
			}
			else
			{
				@class = struct40_0.method_0();
			}
			if (@class != null)
			{
				graphicsPath_0.FillMode = Class378.smethod_28(struct40_0.String_1);
			}
			Pen pen_ = struct41_0.method_0(sizeF_0, float_0);
			class376_0.List_0.Add(new Class377(graphicsPath_0, itransformAttribute_0, pen_, @class, sizeF_0, float_0));
		}

		private static void smethod_10(System.Xml.XmlElement xmlElement_0, Class376 class376_0, ITransformAttribute[] itransformAttribute_0, Struct40 struct40_0, Struct41 struct41_0, Struct38 struct38_0, Struct39 struct39_0, SizeF sizeF_0)
		{
			string attribute = xmlElement_0.GetAttribute("x");
			string attribute2 = xmlElement_0.GetAttribute("y");
			string attribute3 = xmlElement_0.GetAttribute("width");
			string attribute4 = xmlElement_0.GetAttribute("height");
			string attribute5 = xmlElement_0.GetAttribute("rx");
			string attribute6 = xmlElement_0.GetAttribute("ry");
			Struct36 struct36_ = (string.IsNullOrEmpty(attribute) ? new Struct36(0f) : new Struct36(attribute));
			Struct36 struct36_2 = (string.IsNullOrEmpty(attribute2) ? new Struct36(0f) : new Struct36(attribute2));
			Struct37 struct37_ = new Struct37(attribute3);
			Struct37 struct37_2 = new Struct37(attribute4);
			Struct37? nullable_ = (string.IsNullOrEmpty(attribute5) ? null : new Struct37?(new Struct37(attribute5)));
			Struct37? nullable_2 = (string.IsNullOrEmpty(attribute6) ? null : new Struct37?(new Struct37(attribute6)));
			float x = Class378.smethod_35(struct36_, sizeF_0.Width, struct38_0.Single_0);
			float y = Class378.smethod_35(struct36_2, sizeF_0.Height, struct38_0.Single_0);
			float num = Class378.smethod_36(struct37_, sizeF_0.Width, struct38_0.Single_0);
			float num2 = Class378.smethod_36(struct37_2, sizeF_0.Height, struct38_0.Single_0);
			SizeF sizeF = Class378.smethod_18(nullable_, num / 2f, nullable_2, num2 / 2f, sizeF_0, struct38_0.Single_0);
			RectangleF rectangleF_ = new RectangleF(x, y, num, num2);
			RectangleF rectangleF_2 = new RectangleF(new PointF(x, y), sizeF);
			if (rectangleF_2.Width != 0f && rectangleF_2.Height != 0f)
			{
				Class378.smethod_14(rectangleF_, rectangleF_2, sizeF, class376_0, itransformAttribute_0, struct40_0, struct41_0, struct38_0, struct39_0, sizeF_0);
				return;
			}
			if (xmlElement_0.GetAttribute("name") == "ColorRect")
			{
				struct41_0.String_0 = ((!class376_0.ImageSetting_0.Stroke.HasValue) ? "none" : ("rgb(" + class376_0.ImageSetting_0.Stroke.Value.R + "," + class376_0.ImageSetting_0.Stroke.Value.G + "," + class376_0.ImageSetting_0.Stroke.Value.B + ")"));
				struct40_0.String_0 = ((!class376_0.ImageSetting_0.Fill.HasValue) ? "none" : ("rgb(" + class376_0.ImageSetting_0.Fill.Value.R + "," + class376_0.ImageSetting_0.Fill.Value.G + "," + class376_0.ImageSetting_0.Fill.Value.B + ")"));
			}
			Class378.smethod_11(rectangleF_, class376_0, itransformAttribute_0, struct40_0, struct41_0, struct38_0, struct39_0, sizeF_0, struct38_0.Single_0);
		}

		private static void smethod_11(RectangleF rectangleF_0, Class376 class376_0, ITransformAttribute[] itransformAttribute_0, Struct40 struct40_0, Struct41 struct41_0, Struct38 struct38_0, Struct39 struct39_0, SizeF sizeF_0, float float_0)
		{
			GraphicsPath graphicsPath = new GraphicsPath();
			graphicsPath.AddRectangle(rectangleF_0);
			Class378.smethod_9(graphicsPath, class376_0, itransformAttribute_0, struct40_0, struct41_0, struct38_0, struct39_0, sizeF_0, float_0);
		}

		private static void smethod_12(System.Xml.XmlElement xmlElement_0, Class376 class376_0, ITransformAttribute[] itransformAttribute_0, Struct40 struct40_0, Struct41 struct41_0, Struct38 struct38_0, Struct39 struct39_0, SizeF sizeF_0)
		{
			string attribute = xmlElement_0.GetAttribute("cx");
			string attribute2 = xmlElement_0.GetAttribute("cy");
			string attribute3 = xmlElement_0.GetAttribute("r");
			Struct36 struct36_ = (string.IsNullOrEmpty(attribute) ? new Struct36(0f) : new Struct36(attribute));
			Struct36 struct36_2 = (string.IsNullOrEmpty(attribute2) ? new Struct36(0f) : new Struct36(attribute2));
			Struct37 struct37_ = (string.IsNullOrEmpty(attribute3) ? new Struct37(0f) : new Struct37(attribute3));
			float num = Class378.smethod_35(struct36_, sizeF_0.Width, struct38_0.Single_0);
			float num2 = Class378.smethod_35(struct36_2, sizeF_0.Height, struct38_0.Single_0);
			float num3 = ((struct37_.Enum45_0 != Struct37.Enum45.const_8) ? Class378.smethod_36(struct37_, sizeF_0.Width, struct38_0.Single_0) : (struct37_.Single_0 / 100f * (float)(Math.Sqrt(Math.Pow(sizeF_0.Width, 2.0) + Math.Pow(sizeF_0.Height, 2.0)) / Math.Sqrt(2.0))));
			SizeF sizeF_ = new SizeF(num3 * 2f, num3 * 2f);
			RectangleF rectangleF = new RectangleF(num - sizeF_.Width / 2f, num2 - sizeF_.Height / 2f, sizeF_.Width, sizeF_.Height);
			Class378.smethod_14(rectangleF, rectangleF, sizeF_, class376_0, itransformAttribute_0, struct40_0, struct41_0, struct38_0, struct39_0, sizeF_0);
		}

		private static void smethod_13(System.Xml.XmlElement xmlElement_0, Class376 class376_0, ITransformAttribute[] itransformAttribute_0, Struct40 struct40_0, Struct41 struct41_0, Struct38 struct38_0, Struct39 struct39_0, SizeF sizeF_0)
		{
			string attribute = xmlElement_0.GetAttribute("cx");
			string attribute2 = xmlElement_0.GetAttribute("cy");
			string attribute3 = xmlElement_0.GetAttribute("rx");
			string attribute4 = xmlElement_0.GetAttribute("ry");
			Struct36 struct36_ = (string.IsNullOrEmpty(attribute) ? new Struct36(0f) : new Struct36(attribute));
			Struct36 struct36_2 = (string.IsNullOrEmpty(attribute2) ? new Struct36(0f) : new Struct36(attribute2));
			Struct37 value = (string.IsNullOrEmpty(attribute3) ? new Struct37(0f) : new Struct37(attribute3));
			Struct37 value2 = (string.IsNullOrEmpty(attribute4) ? new Struct37(0f) : new Struct37(attribute4));
			float num = Class378.smethod_35(struct36_, sizeF_0.Width, struct38_0.Single_0);
			float num2 = Class378.smethod_35(struct36_2, sizeF_0.Height, struct38_0.Single_0);
			SizeF sizeF = Class378.smethod_19(value, value2, sizeF_0, struct38_0.Single_0);
			sizeF = new SizeF(sizeF.Width * 2f, sizeF.Height * 2f);
			RectangleF rectangleF = new RectangleF(num - sizeF.Width / 2f, num2 - sizeF.Height / 2f, sizeF.Width, sizeF.Height);
			Class378.smethod_14(rectangleF, rectangleF, sizeF, class376_0, itransformAttribute_0, struct40_0, struct41_0, struct38_0, struct39_0, sizeF_0);
		}

		private static void smethod_14(RectangleF rectangleF_0, RectangleF rectangleF_1, SizeF sizeF_0, Class376 class376_0, ITransformAttribute[] itransformAttribute_0, Struct40 struct40_0, Struct41 struct41_0, Struct38 struct38_0, Struct39 struct39_0, SizeF sizeF_1)
		{
			GraphicsPath graphicsPath = new GraphicsPath();
			graphicsPath.AddArc(rectangleF_1, 180f, 90f);
			rectangleF_1.X = rectangleF_0.Right - sizeF_0.Width;
			graphicsPath.AddArc(rectangleF_1, 270f, 90f);
			rectangleF_1.Y = rectangleF_0.Bottom - sizeF_0.Height;
			graphicsPath.AddArc(rectangleF_1, 0f, 90f);
			rectangleF_1.X = rectangleF_0.Left;
			graphicsPath.AddArc(rectangleF_1, 90f, 90f);
			graphicsPath.CloseFigure();
			Class378.smethod_9(graphicsPath, class376_0, itransformAttribute_0, struct40_0, struct41_0, struct38_0, struct39_0, sizeF_1, struct38_0.Single_0);
		}

		private static void smethod_15(System.Xml.XmlElement xmlElement_0, Class376 class376_0, ITransformAttribute[] itransformAttribute_0, Struct40 struct40_0, Struct41 struct41_0, Struct38 struct38_0, Struct39 struct39_0, SizeF sizeF_0)
		{
			string attribute = xmlElement_0.GetAttribute("x1");
			string attribute2 = xmlElement_0.GetAttribute("y1");
			string attribute3 = xmlElement_0.GetAttribute("x2");
			string attribute4 = xmlElement_0.GetAttribute("y2");
			Struct36 struct36_ = (string.IsNullOrEmpty(attribute) ? new Struct36(0f) : new Struct36(attribute));
			Struct36 struct36_2 = (string.IsNullOrEmpty(attribute2) ? new Struct36(0f) : new Struct36(attribute2));
			Struct36 struct36_3 = (string.IsNullOrEmpty(attribute3) ? new Struct36(0f) : new Struct36(attribute3));
			Struct36 struct36_4 = (string.IsNullOrEmpty(attribute4) ? new Struct36(0f) : new Struct36(attribute4));
			float x = Class378.smethod_35(struct36_, sizeF_0.Width, struct38_0.Single_0);
			float y = Class378.smethod_35(struct36_2, sizeF_0.Height, struct38_0.Single_0);
			float x2 = Class378.smethod_35(struct36_3, sizeF_0.Width, struct38_0.Single_0);
			float y2 = Class378.smethod_35(struct36_4, sizeF_0.Height, struct38_0.Single_0);
			GraphicsPath graphicsPath = new GraphicsPath();
			graphicsPath.AddLine(x, y, x2, y2);
			Class378.smethod_9(graphicsPath, class376_0, itransformAttribute_0, struct40_0, struct41_0, struct38_0, struct39_0, sizeF_0, struct38_0.Single_0);
		}

		private static void smethod_16(System.Xml.XmlElement xmlElement_0, Class376 class376_0, ITransformAttribute[] itransformAttribute_0, Struct40 struct40_0, Struct41 struct41_0, Struct38 struct38_0, Struct39 struct39_0, SizeF sizeF_0)
		{
			string attribute = xmlElement_0.GetAttribute("points");
			PointF[] points = Class378.smethod_21(null, attribute, sizeF_0, struct38_0.Single_0);
			GraphicsPath graphicsPath = new GraphicsPath();
			graphicsPath.AddLines(points);
			Class378.smethod_9(graphicsPath, class376_0, itransformAttribute_0, struct40_0, struct41_0, struct38_0, struct39_0, sizeF_0, struct38_0.Single_0);
		}

		private static void smethod_17(System.Xml.XmlElement xmlElement_0, Class376 class376_0, ITransformAttribute[] itransformAttribute_0, Struct40 struct40_0, Struct41 struct41_0, Struct38 struct38_0, Struct39 struct39_0, SizeF sizeF_0)
		{
			string attribute = xmlElement_0.GetAttribute("points");
			PointF[] points = Class378.smethod_21(null, attribute, sizeF_0, struct38_0.Single_0);
			GraphicsPath graphicsPath = new GraphicsPath();
			graphicsPath.AddPolygon(points);
			Class378.smethod_9(graphicsPath, class376_0, itransformAttribute_0, struct40_0, struct41_0, struct38_0, struct39_0, sizeF_0, struct38_0.Single_0);
		}

		private static SizeF smethod_18(Struct37? nullable_0, float float_0, Struct37? nullable_1, float float_1, SizeF sizeF_0, float float_2)
		{
			SizeF sizeF = Class378.smethod_19(nullable_0, nullable_1, sizeF_0, float_2);
			return new SizeF(Math.Min(sizeF.Width, float_0), Math.Min(sizeF.Height, float_1));
		}

		private static SizeF smethod_19(Struct37? nullable_0, Struct37? nullable_1, SizeF sizeF_0, float float_0)
		{
			float? num = ((!nullable_0.HasValue) ? null : new float?(Class378.smethod_36(nullable_0.Value, sizeF_0.Width, float_0)));
			float? num2 = ((!nullable_1.HasValue) ? null : new float?(Class378.smethod_36(nullable_1.Value, sizeF_0.Height, float_0)));
			if (!num.HasValue && !num2.HasValue)
			{
				num = 0f;
				num2 = 0f;
			}
			else if (!num.HasValue || !num2.HasValue)
			{
				if (num.HasValue)
				{
					num2 = num.Value;
				}
				else
				{
					num = num2.Value;
				}
			}
			return new SizeF(num.Value, num2.Value);
		}

		internal static RectangleF smethod_20(string string_0)
		{
			MatchCollection matchCollection = Class378.regex_0.Matches(string_0);
			float x = float.Parse(matchCollection[0].Value, CultureInfo.InvariantCulture);
			float y = float.Parse(matchCollection[1].Value, CultureInfo.InvariantCulture);
			float width = float.Parse(matchCollection[2].Value, CultureInfo.InvariantCulture);
			float height = float.Parse(matchCollection[3].Value, CultureInfo.InvariantCulture);
			return new RectangleF(x, y, width, height);
		}

		private static PointF[] smethod_21(PointF? nullable_0, string string_0, SizeF sizeF_0, float float_0)
		{
			MatchCollection matchCollection = Class378.regex_6.Matches(string_0);
			int num = (nullable_0.HasValue ? 1 : 0);
			PointF[] array = new PointF[matchCollection.Count / 2 + num];
			for (int i = 0; i < matchCollection.Count; i += 2)
			{
				Struct36 struct36_ = new Struct36(matchCollection[i].Value);
				Struct36 struct36_2 = new Struct36(matchCollection[i + 1].Value);
				float x = Class378.smethod_35(struct36_, sizeF_0.Width, float_0);
				float y = Class378.smethod_35(struct36_2, sizeF_0.Height, float_0);
				ref PointF reference = ref array[num];
				reference = new PointF(x, y);
				num++;
			}
			if (nullable_0.HasValue)
			{
				ref PointF reference2 = ref array[0];
				reference2 = nullable_0.Value;
			}
			return array;
		}

		private static float[] smethod_22(int int_0, string string_0)
		{
			MatchCollection matchCollection = Class378.regex_6.Matches(string_0);
			float[] array = new float[matchCollection.Count + int_0];
			for (int i = 0; i < matchCollection.Count; i++)
			{
				float num = (array[i + int_0] = float.Parse(matchCollection[i].Value, CultureInfo.InvariantCulture));
			}
			return array;
		}

		internal static Color? smethod_23(string string_0)
		{
			string text;
			if ((text = string_0) != null && text == "none")
			{
				return null;
			}
			if (string_0.StartsWith("#"))
			{
				return ColorTranslator.FromHtml(string_0);
			}
			if (string_0.StartsWith("rgb"))
			{
				MatchCollection matchCollection = Class378.regex_8.Matches(string_0);
				if (matchCollection[0].Value.EndsWith("%"))
				{
					throw new NotSupportedException(string_0);
				}
				return Color.FromArgb(int.Parse(matchCollection[0].Value), int.Parse(matchCollection[1].Value), int.Parse(matchCollection[2].Value));
			}
			return Color.FromName(Class378.regex_0.Match(string_0).Value);
		}

		internal static float smethod_24(string string_0)
		{
			float result = -1f;
			if (!float.TryParse(string_0, NumberStyles.Float, CultureInfo.InvariantCulture, out result))
			{
				throw new ArgumentException(string_0);
			}
			return 255f * result;
		}

		internal static bool smethod_25(string string_0)
		{
			string[] array = string_0.Split(' ');
			if (array.Length > 1)
			{
				return array[1].ToLower() == "meet";
			}
			return true;
		}

		internal static AlignX smethod_26(string string_0)
		{
			return string_0.Substring(0, string_0.IndexOf('Y')) switch
			{
				"xMax" => AlignX.Right, 
				"xMid" => AlignX.Center, 
				"xMin" => AlignX.Left, 
				_ => throw new NotSupportedException(string_0), 
			};
		}

		internal static AlignY smethod_27(string string_0)
		{
			return string_0.Split(' ')[0].Substring(string_0.IndexOf('Y')) switch
			{
				"YMax" => AlignY.Bottom, 
				"YMid" => AlignY.Center, 
				"YMin" => AlignY.Top, 
				_ => throw new NotSupportedException(string_0), 
			};
		}

		internal static FillMode smethod_28(string string_0)
		{
			string text;
			if ((text = string_0.ToLower()) != null && text == "evenodd")
			{
				return FillMode.Alternate;
			}
			return FillMode.Winding;
		}

		internal static float smethod_29(string string_0, float float_0, float float_1)
		{
			switch (string_0)
			{
			case "xx-small":
				return 4f;
			case "x-small":
				return 10f;
			case "small":
				return 13f;
			case "medium":
				return 16f;
			case "large":
				return 18f;
			case "x-large":
				return 24f;
			case "xx-large":
				return 32f;
			case "larger":
				return float_1 += 6f;
			case "smaller":
				return float_1 -= 6f;
			default:
				try
				{
					Struct37 struct37_ = new Struct37(string_0);
					return Class378.smethod_36(struct37_, float_0, float_1);
				}
				catch
				{
					throw new NotSupportedException(string_0);
				}
			}
		}

		internal static FontStyle smethod_30(string string_0)
		{
			return string_0 switch
			{
				"oblique" => FontStyle.Regular, 
				"italic" => FontStyle.Italic, 
				"normal" => FontStyle.Regular, 
				_ => throw new NotSupportedException(string_0), 
			};
		}

		internal static int smethod_31(string string_0, int int_0)
		{
			switch (string_0)
			{
			case "bolder":
				return Math.Min(int_0 += 100, 900);
			case "lighter":
				return Math.Max(int_0 -= 100, 100);
			case "bold":
				return 700;
			case "normal":
				return 400;
			default:
			{
				if (!int.TryParse(string_0, out var result))
				{
					throw new NotSupportedException(string_0);
				}
				return result;
			}
			}
		}

		internal static LineCap smethod_32(string string_0)
		{
			return string_0.ToLower() switch
			{
				"square" => LineCap.Square, 
				"round" => LineCap.Round, 
				"butt" => LineCap.Flat, 
				_ => LineCap.Flat, 
			};
		}

		internal static float[] smethod_33(string string_0)
		{
			if (string_0 == "none")
			{
				return new float[0];
			}
			float[] array = Class378.smethod_22(0, string_0);
			if (array.Length > 0 && array.Length % 2 != 0)
			{
				float[] array2 = new float[array.Length + 1];
				Array.Copy(array, array2, array.Length);
				array2[array.Length] = array[array.Length - 1];
				return array2;
			}
			return array;
		}

		internal static LineJoin smethod_34(string string_0)
		{
			return string_0.ToLower() switch
			{
				"bevel" => LineJoin.Bevel, 
				"round" => LineJoin.Round, 
				"miter" => LineJoin.Miter, 
				_ => LineJoin.Miter, 
			};
		}

		internal static float smethod_35(Struct36 struct36_0, float float_0, float float_1)
		{
			return Class378.smethod_36(struct36_0.Struct37_0, float_0, float_1);
		}

		internal static float smethod_36(Struct37 struct37_0, float float_0, float float_1)
		{
			return struct37_0.Enum45_0 switch
			{
				Struct37.Enum45.const_0 => struct37_0.Single_0 * float_1, 
				Struct37.Enum45.const_2 => struct37_0.Single_0, 
				Struct37.Enum45.const_3 => struct37_0.Single_0 * 96f, 
				Struct37.Enum45.const_4 => struct37_0.Single_0 * 96f / 2.54f, 
				Struct37.Enum45.const_5 => struct37_0.Single_0 * 96f / 25.4f, 
				Struct37.Enum45.const_6 => struct37_0.Single_0 * 96f / 72f, 
				Struct37.Enum45.const_7 => struct37_0.Single_0 * 96f / 864f, 
				Struct37.Enum45.const_8 => struct37_0.Single_0 * float_0 / 100f, 
				_ => struct37_0.Single_0, 
			};
		}

		private static Class380[] smethod_37(string string_0)
		{
			MatchCollection matchCollection = Class378.smethod_39(string_0);
			Dictionary<string, Class380> dictionary = new Dictionary<string, Class380>();
			for (int i = 0; i < matchCollection.Count; i++)
			{
				string[] string_;
				List<string> list = Class380.smethod_0(matchCollection[i].Value, out string_);
				string[] array = string_;
				foreach (string text in array)
				{
					if (dictionary.ContainsKey(text))
					{
						dictionary[text].List_0.AddRange(list);
					}
					else
					{
						dictionary.Add(text, new Class380(text, list));
					}
				}
			}
			List<Class380> list2 = new List<Class380>();
			foreach (KeyValuePair<string, Class380> item in dictionary)
			{
				list2.Add(item.Value);
			}
			return list2.ToArray();
		}

		internal static MatchCollection smethod_38(string string_0)
		{
			return Class378.regex_4.Matches(string_0);
		}

		internal static MatchCollection smethod_39(string string_0)
		{
			return Class378.regex_5.Matches(string_0);
		}

		internal static string smethod_40(string string_0)
		{
			return Class378.regex_0.Match(string_0).Value;
		}

		internal static string[] smethod_41(string string_0)
		{
			Match match = Class378.regex_7.Match(string_0);
			Match match2 = Class378.regex_9.Match(string_0);
			if (match2.Value.Length > 0)
			{
				return new string[2] { match.Value, match2.Value };
			}
			return new string[1] { match.Value };
		}

		internal static float smethod_42(string string_0)
		{
			if (!float.TryParse(string_0, NumberStyles.Float, CultureInfo.InvariantCulture, out var result))
			{
				throw new ArgumentException(string_0);
			}
			return result;
		}

		private static void smethod_43(System.Xml.XmlElement xmlElement_0, Class376 class376_0, ITransformAttribute[] itransformAttribute_0, Struct40 struct40_0, Struct41 struct41_0, Struct38 struct38_0, Struct39 struct39_0, RectangleF rectangleF_0, SizeF sizeF_0)
		{
			foreach (XmlNode item in xmlElement_0)
			{
				Class378.smethod_2(item, class376_0, itransformAttribute_0, struct40_0, struct41_0, struct38_0, struct39_0, rectangleF_0, sizeF_0, bool_0: false);
			}
		}

		private static void smethod_44(System.Xml.XmlElement xmlElement_0, Class376 class376_0, ITransformAttribute[] itransformAttribute_0, Struct40 struct40_0, Struct41 struct41_0, Struct38 struct38_0, Struct39 struct39_0, RectangleF rectangleF_0, SizeF sizeF_0)
		{
			string attribute = xmlElement_0.GetAttribute("x");
			string attribute2 = xmlElement_0.GetAttribute("y");
			string attribute3 = xmlElement_0.GetAttribute("width");
			string attribute4 = xmlElement_0.GetAttribute("height");
			Struct36 struct36_ = (string.IsNullOrEmpty(attribute) ? new Struct36(rectangleF_0.X) : new Struct36(attribute));
			Struct36 struct36_2 = (string.IsNullOrEmpty(attribute2) ? new Struct36(rectangleF_0.Y) : new Struct36(attribute2));
			Struct37 struct37_ = (string.IsNullOrEmpty(attribute3) ? new Struct37(rectangleF_0.Width) : new Struct37(attribute3));
			Struct37 struct37_2 = (string.IsNullOrEmpty(attribute4) ? new Struct37(rectangleF_0.Height) : new Struct37(attribute4));
			float num = Class378.smethod_35(struct36_, sizeF_0.Width, struct38_0.Single_0);
			float num2 = Class378.smethod_35(struct36_2, sizeF_0.Height, struct38_0.Single_0);
			float width = Class378.smethod_36(struct37_, sizeF_0.Width, struct38_0.Single_0);
			float height = Class378.smethod_36(struct37_2, sizeF_0.Width, struct38_0.Single_0);
			rectangleF_0 = new RectangleF(0f, 0f, width, height);
			XmlAttribute xmlAttribute = xmlElement_0.Attributes["xlink:href"];
			if (class376_0.Dictionary_0.TryGetValue(xmlAttribute.Value.Substring(1), out var value) && value is Class379)
			{
				if (num != 0f || num2 != 0f)
				{
					MatchCollection matchCollection_ = Class378.regex_2.Matches("translate(" + num + "," + num2 + ")");
					Class378.smethod_7(ref itransformAttribute_0, matchCollection_);
				}
				Class378.smethod_2((value as Class379).XmlNode_0, class376_0, itransformAttribute_0, struct40_0, struct41_0, struct38_0, struct39_0, rectangleF_0, sizeF_0, bool_0: false);
			}
		}

		private static void smethod_45(System.Xml.XmlElement xmlElement_0, Class376 class376_0, ITransformAttribute[] itransformAttribute_0, Struct40 struct40_0, Struct41 struct41_0, Struct38 struct38_0, Struct39 struct39_0, RectangleF rectangleF_0, SizeF sizeF_0)
		{
			xmlElement_0.GetAttribute("x");
			xmlElement_0.GetAttribute("y");
			xmlElement_0.GetAttribute("dx");
			xmlElement_0.GetAttribute("dy");
			xmlElement_0.GetAttribute("rotate");
			xmlElement_0.GetAttribute("textLength");
			xmlElement_0.GetAttribute("lengthAdjust");
			struct38_0.method_0();
			foreach (XmlNode childNode in xmlElement_0.ChildNodes)
			{
				Class378.smethod_46(childNode, null, class376_0, itransformAttribute_0, struct40_0, struct41_0, struct38_0, struct39_0, rectangleF_0, sizeF_0);
			}
		}

		private static RectangleF smethod_46(XmlNode xmlNode_0, PointF[] pointF_0, Class376 class376_0, ITransformAttribute[] itransformAttribute_0, Struct40 struct40_0, Struct41 struct41_0, Struct38 struct38_0, Struct39 struct39_0, RectangleF rectangleF_0, SizeF sizeF_0)
		{
			GraphicsPath graphicsPath = new GraphicsPath();
			return graphicsPath.GetBounds();
		}

		private static void smethod_47(System.Xml.XmlElement xmlElement_0, Class376 class376_0, ITransformAttribute[] itransformAttribute_0, Struct40 struct40_0, Struct41 struct41_0, Struct38 struct38_0, Struct39 struct39_0, SizeF sizeF_0)
		{
			string attribute = xmlElement_0.GetAttribute("d");
			MatchCollection matchCollection = Class378.regex_1.Matches(attribute);
			PointF pointF_ = new PointF(float.MinValue, float.MinValue);
			int num = 0;
			GraphicsPath graphicsPath = new GraphicsPath();
			PointF? nullable_ = null;
			PointF? nullable_2 = null;
			bool flag = false;
			bool flag2 = false;
			bool flag3 = false;
			foreach (Match item in matchCollection)
			{
				flag2 = true;
				flag = true;
				char c = char.ToUpper(item.Value[0]);
				char c2 = c;
				if (c2 == 'M')
				{
					if (flag3 = Class378.smethod_48(item.Value, pointF_, graphicsPath, out pointF_, sizeF_0, struct38_0.Single_0))
					{
						num = graphicsPath.PointCount;
					}
				}
				else
				{
					if (!flag3)
					{
						pointF_ = graphicsPath.PathPoints[graphicsPath.PathPoints.Length - 1];
					}
					switch (c)
					{
					case 'H':
						pointF_ = Class378.smethod_51(item.Value, pointF_, graphicsPath);
						break;
					case 'A':
						pointF_ = Class378.smethod_57(item.Value, pointF_, graphicsPath, flag3);
						break;
					case 'C':
						pointF_ = Class378.smethod_53(item.Value, pointF_, graphicsPath, out nullable_2, sizeF_0, struct38_0.Single_0);
						flag2 = false;
						break;
					case 'Z':
						Class378.smethod_49(pointF_1: (graphicsPath.PointCount <= 0) ? pointF_ : graphicsPath.PathPoints[num], pointF_0: pointF_, graphicsPath_0: graphicsPath);
						break;
					case 'Q':
						pointF_ = Class378.smethod_55(item.Value, pointF_, graphicsPath, out nullable_, sizeF_0, struct38_0.Single_0);
						flag = false;
						break;
					case 'S':
						pointF_ = Class378.smethod_54(item.Value, pointF_, nullable_2.HasValue ? nullable_2.Value : pointF_, graphicsPath, out nullable_2, sizeF_0, struct38_0.Single_0);
						flag2 = false;
						break;
					case 'T':
						pointF_ = Class378.smethod_56(item.Value, pointF_, nullable_.HasValue ? nullable_.Value : pointF_, graphicsPath, out nullable_, sizeF_0, struct38_0.Single_0);
						flag = false;
						break;
					case 'V':
						pointF_ = Class378.smethod_52(item.Value, pointF_, graphicsPath);
						break;
					case 'L':
						pointF_ = Class378.smethod_50(item.Value, pointF_, graphicsPath, sizeF_0, struct38_0.Single_0);
						break;
					}
					flag3 = false;
				}
				if (flag2)
				{
					nullable_2 = null;
				}
				if (flag)
				{
					nullable_ = null;
				}
			}
			Class378.smethod_9(graphicsPath, class376_0, itransformAttribute_0, struct40_0, struct41_0, struct38_0, struct39_0, sizeF_0, struct38_0.Single_0);
		}

		private static bool smethod_48(string string_0, PointF pointF_0, GraphicsPath graphicsPath_0, out PointF pointF_1, SizeF sizeF_0, float float_0)
		{
			PointF[] array = Class378.smethod_21(null, string_0.Substring(1), sizeF_0, float_0);
			if (array.Length == 1)
			{
				if (!char.IsUpper(string_0[0]) && !float.IsNegativeInfinity(pointF_0.X))
				{
					ref PointF reference = ref array[0];
					reference = new PointF(pointF_0.X + array[0].X, pointF_0.Y + array[0].Y);
				}
				pointF_1 = array[0];
				return true;
			}
			if (array.Length > 1)
			{
				if (!char.IsUpper(string_0[0]) && !float.IsNegativeInfinity(pointF_0.X))
				{
					for (int i = 0; i < array.Length; i++)
					{
						ref PointF reference2 = ref array[i];
						reference2 = new PointF(pointF_0.X + array[0].X, pointF_0.Y + array[0].Y);
					}
				}
				PointF pt = array[0];
				PointF pointF = array[1];
				graphicsPath_0.AddLine(pt, pointF);
				for (int j = 2; j < array.Length; j++)
				{
					pt = pointF;
					pointF = array[j];
					graphicsPath_0.AddLine(pt, pointF);
				}
				pointF_1 = array[array.Length - 1];
				return true;
			}
			pointF_1 = PointF.Empty;
			return false;
		}

		private static PointF smethod_49(PointF pointF_0, PointF pointF_1, GraphicsPath graphicsPath_0)
		{
			graphicsPath_0.CloseFigure();
			return pointF_1;
		}

		private static PointF smethod_50(string string_0, PointF pointF_0, GraphicsPath graphicsPath_0, SizeF sizeF_0, float float_0)
		{
			PointF[] array = Class378.smethod_21(pointF_0, string_0.Substring(1), sizeF_0, float_0);
			if (!char.IsUpper(string_0[0]))
			{
				for (int i = 1; i < array.Length; i++)
				{
					ref PointF reference = ref array[i];
					reference = new PointF(pointF_0.X + array[i].X, pointF_0.Y + array[i].Y);
				}
			}
			PointF pt = array[0];
			PointF pointF = array[1];
			graphicsPath_0.AddLine(pt, pointF);
			for (int j = 2; j < array.Length; j++)
			{
				pt = pointF;
				pointF = array[j];
				graphicsPath_0.AddLine(pt, pointF);
			}
			return array[array.Length - 1];
		}

		private static PointF smethod_51(string string_0, PointF pointF_0, GraphicsPath graphicsPath_0)
		{
			float[] array = Class378.smethod_22(1, string_0.Substring(1));
			PointF[] array2 = new PointF[array.Length];
			if (!char.IsUpper(string_0[0]))
			{
				for (int i = 1; i < array.Length; i++)
				{
					ref PointF reference = ref array2[i];
					reference = new PointF(pointF_0.X + array[i], pointF_0.Y);
				}
			}
			else
			{
				for (int j = 1; j < array.Length; j++)
				{
					ref PointF reference2 = ref array2[j];
					reference2 = new PointF(array[j], pointF_0.Y);
				}
			}
			array2[0] = pointF_0;
			PointF pt = array2[0];
			PointF pointF = array2[1];
			graphicsPath_0.AddLine(pt, pointF);
			for (int k = 2; k < array2.Length; k++)
			{
				pt = pointF;
				pointF = array2[k];
				graphicsPath_0.AddLine(pt, pointF);
			}
			return array2[array2.Length - 1];
		}

		private static PointF smethod_52(string string_0, PointF pointF_0, GraphicsPath graphicsPath_0)
		{
			float[] array = Class378.smethod_22(1, string_0.Substring(1));
			PointF[] array2 = new PointF[array.Length];
			if (!char.IsUpper(string_0[0]))
			{
				for (int i = 1; i < array.Length; i++)
				{
					ref PointF reference = ref array2[i];
					reference = new PointF(pointF_0.X, pointF_0.Y + array[i]);
				}
			}
			else
			{
				for (int j = 1; j < array.Length; j++)
				{
					ref PointF reference2 = ref array2[j];
					reference2 = new PointF(pointF_0.X, array[j]);
				}
			}
			array2[0] = pointF_0;
			PointF pt = array2[0];
			PointF pointF = array2[1];
			graphicsPath_0.AddLine(pt, pointF);
			for (int k = 2; k < array2.Length; k++)
			{
				pt = pointF;
				pointF = array2[k];
				graphicsPath_0.AddLine(pt, pointF);
			}
			return array2[array2.Length - 1];
		}

		private static PointF smethod_53(string string_0, PointF pointF_0, GraphicsPath graphicsPath_0, out PointF? nullable_0, SizeF sizeF_0, float float_0)
		{
			PointF[] array = Class378.smethod_21(pointF_0, string_0.Substring(1), sizeF_0, float_0);
			if (!char.IsUpper(string_0[0]))
			{
				for (int i = 1; i < array.Length; i++)
				{
					ref PointF reference = ref array[i];
					reference = new PointF(pointF_0.X + array[i].X, pointF_0.Y + array[i].Y);
				}
			}
			PointF pt = array[0];
			PointF pt2 = array[1];
			PointF pt3 = array[2];
			PointF pointF = array[3];
			graphicsPath_0.AddBezier(pt, pt2, pt3, pointF);
			if (array.Length > 4)
			{
				for (int j = 4; j < array.Length; j += 3)
				{
					pt = pointF;
					pt2 = array[j];
					pt3 = array[j + 1];
					pointF = array[j + 2];
					graphicsPath_0.AddBezier(pt, pt2, pt3, pointF);
				}
			}
			nullable_0 = array[array.Length - 2];
			return array[array.Length - 1];
		}

		private static PointF smethod_54(string string_0, PointF pointF_0, PointF pointF_1, GraphicsPath graphicsPath_0, out PointF? nullable_0, SizeF sizeF_0, float float_0)
		{
			PointF[] array = Class378.smethod_21(pointF_0, string_0.Substring(1), sizeF_0, float_0);
			if (!char.IsUpper(string_0[0]))
			{
				for (int i = 1; i < array.Length; i++)
				{
					ref PointF reference = ref array[i];
					reference = new PointF(pointF_0.X + array[i].X, pointF_0.Y + array[i].Y);
				}
			}
			PointF pt = array[0];
			PointF pt2 = new PointF(2f * array[0].X - pointF_1.X, 2f * array[0].Y - pointF_1.Y);
			PointF pt3 = array[1];
			PointF pointF = array[2];
			graphicsPath_0.AddBezier(pt, pt2, pt3, pointF);
			if (array.Length > 3)
			{
				for (int j = 3; j < array.Length; j += 2)
				{
					pt = pointF;
					pointF_1 = array[j - 2];
					pt2 = new PointF(2f * array[j - 1].X - pointF_1.X, 2f * array[j - 1].Y - pointF_1.Y);
					pt3 = array[j];
					pointF = array[j + 1];
					graphicsPath_0.AddBezier(pt, pt2, pt3, pointF);
				}
			}
			nullable_0 = array[array.Length - 2];
			return array[array.Length - 1];
		}

		private static PointF smethod_55(string string_0, PointF pointF_0, GraphicsPath graphicsPath_0, out PointF? nullable_0, SizeF sizeF_0, float float_0)
		{
			PointF[] array = Class378.smethod_21(pointF_0, string_0.Substring(1), sizeF_0, float_0);
			if (!char.IsUpper(string_0[0]))
			{
				for (int i = 1; i < array.Length; i++)
				{
					ref PointF reference = ref array[i];
					reference = new PointF(pointF_0.X + array[i].X, pointF_0.Y + array[i].Y);
				}
			}
			PointF pt = array[0];
			PointF pointF = array[2];
			PointF pointF2 = array[1];
			graphicsPath_0.AddBezier(pt2: new PointF(pointF2.X * 2f / 3f + pt.X / 3f, pointF2.Y * 2f / 3f + pt.Y / 3f), pt3: new PointF(pointF2.X * 2f / 3f + pointF.X / 3f, pointF2.Y * 2f / 3f + pointF.Y / 3f), pt1: pt, pt4: pointF);
			if (array.Length > 3)
			{
				for (int j = 3; j < array.Length; j += 2)
				{
					pt = pointF;
					pointF = array[j + 1];
					pointF2 = array[j];
					graphicsPath_0.AddBezier(pt2: new PointF(pointF2.X * 2f / 3f + pt.X / 3f, pointF2.Y * 2f / 3f + pt.Y / 3f), pt3: new PointF(pointF2.X * 2f / 3f + pointF.X / 3f, pointF2.Y * 2f / 3f + pointF.Y / 3f), pt1: pt, pt4: pointF);
				}
			}
			nullable_0 = array[array.Length - 2];
			return array[array.Length - 1];
		}

		private static PointF smethod_56(string string_0, PointF pointF_0, PointF pointF_1, GraphicsPath graphicsPath_0, out PointF? nullable_0, SizeF sizeF_0, float float_0)
		{
			PointF[] array = Class378.smethod_21(pointF_0, string_0.Substring(1), sizeF_0, float_0);
			if (!char.IsUpper(string_0[0]))
			{
				for (int i = 1; i < array.Length; i++)
				{
					ref PointF reference = ref array[i];
					reference = new PointF(pointF_0.X + array[i].X, pointF_0.Y + array[i].Y);
				}
			}
			PointF pt = array[0];
			PointF pointF = array[1];
			PointF pointF2 = new PointF(2f * array[0].X - pointF_1.X, 2f * array[0].Y - pointF_1.Y);
			graphicsPath_0.AddBezier(pt2: new PointF(pointF2.X * 2f / 3f + pt.X / 3f, pointF2.Y * 2f / 3f + pt.Y / 3f), pt3: new PointF(pointF2.X * 2f / 3f + pointF.X / 3f, pointF2.Y * 2f / 3f + pointF.Y / 3f), pt1: pt, pt4: pointF);
			if (array.Length > 2)
			{
				for (int j = 2; j < array.Length; j++)
				{
					pt = pointF;
					pointF_1 = array[j - 1];
					pointF = array[j];
					pointF2 = new PointF(2f * array[j - 1].X - pointF_1.X, 2f * array[j - 1].Y - pointF_1.Y);
					graphicsPath_0.AddBezier(pt2: new PointF(pointF2.X * 2f / 3f + pt.X / 3f, pointF2.Y * 2f / 3f + pt.Y / 3f), pt3: new PointF(pointF2.X * 2f / 3f + pointF.X / 3f, pointF2.Y * 2f / 3f + pointF.Y / 3f), pt1: pt, pt4: pointF);
				}
			}
			nullable_0 = array[array.Length - 1];
			return array[array.Length - 1];
		}

		private static PointF smethod_57(string string_0, PointF pointF_0, GraphicsPath graphicsPath_0, bool bool_0)
		{
			float[] array = Class378.smethod_22(0, string_0);
			float num = Math.Abs(array[0]);
			float num2 = Math.Abs(array[1]);
			if (num != 0f)
			{
			}
			float num3 = array[2] % 360f * (float)Math.PI / 180f;
			float num4 = array[3];
			float num5 = array[4];
			PointF result = (char.IsUpper(string_0[0]) ? new PointF(array[array.Length - 2], array[array.Length - 1]) : new PointF(pointF_0.X + array[array.Length - 2], pointF_0.Y + array[array.Length - 1]));
			float num6 = (pointF_0.X - result.X) / 2f;
			float num7 = (pointF_0.Y - result.Y) / 2f;
			PointF pointF = new PointF((float)(Math.Cos(num3) * (double)num6 + Math.Sin(num3) * (double)num7), (float)((0.0 - Math.Sin(num3)) * (double)num6 + Math.Cos(num3) * (double)num7));
			float num8 = (float)(Math.Pow(pointF.X, 2.0) / Math.Pow(num, 2.0) + Math.Pow(pointF.Y, 2.0) / Math.Pow(num2, 2.0));
			if (num8 > 1f)
			{
				num = (float)Math.Sqrt(num8) * num;
				num2 = (float)Math.Sqrt(num8) * num2;
			}
			float num9 = (float)Math.Pow(num, 2.0) * (float)Math.Pow(num2, 2.0);
			float num10 = (float)Math.Pow(num, 2.0) * (float)Math.Pow(pointF.Y, 2.0);
			float num11 = (float)Math.Pow(num2, 2.0) * (float)Math.Pow(pointF.X, 2.0);
			float num12 = num9 - num10 - num11;
			float num13 = (float)Math.Pow(num, 2.0) * (float)Math.Pow(pointF.Y, 2.0);
			float num14 = (float)Math.Pow(num2, 2.0) * (float)Math.Pow(pointF.X, 2.0);
			float num15 = num13 + num14;
			float num16 = num12 / num15;
			num16 = ((num16 < 0f) ? 0f : num16);
			num16 = (float)Math.Sqrt(num16);
			float num17 = ((num4 != num5) ? 1 : (-1));
			PointF pointF2 = new PointF(num17 * (num * pointF.Y / num2) * num16, num17 * ((0f - num2 * pointF.X) / num) * num16);
			PointF point = new PointF((float)(Math.Cos(num3) * (double)pointF2.X) - (float)(Math.Sin(num3) * (double)pointF2.Y) + (pointF_0.X + result.X) / 2f, (float)(Math.Sin(num3) * (double)pointF2.X) + (float)(Math.Cos(num3) * (double)pointF2.Y) + (pointF_0.Y + result.Y) / 2f);
			PointF pointF3 = new PointF((pointF.X - pointF2.X) / num, (pointF.Y - pointF2.Y) / num2);
			float startAngle = Class378.smethod_58(new PointF(1f, 0f), pointF3);
			PointF pointF_ = new PointF((0f - pointF.X - pointF2.X) / num, (0f - pointF.Y - pointF2.Y) / num2);
			float num18 = Class378.smethod_58(pointF3, pointF_);
			if (num5 == 0f && num18 > 0f)
			{
				num18 -= 360f;
			}
			else if (num5 == 1f && num18 < 0f)
			{
				num18 += 360f;
			}
			num18 %= 360f;
			RectangleF rect = new RectangleF(point.X - num, point.Y - num2, 2f * num, 2f * num2);
			GraphicsPath graphicsPath = new GraphicsPath();
			float num19 = array[2] % 360f;
			if (num19 != 0f)
			{
				Matrix matrix = new Matrix();
				matrix.RotateAt(0f - num19, point);
				graphicsPath.Transform(matrix);
			}
			graphicsPath.AddArc(rect, startAngle, num18);
			if (num19 != 0f)
			{
				Matrix matrix2 = new Matrix();
				matrix2.RotateAt(num19, point);
				graphicsPath.Transform(matrix2);
			}
			if (!bool_0 && graphicsPath_0.PointCount > 0)
			{
				PointF lastPoint = graphicsPath_0.GetLastPoint();
				PointF pointF4 = graphicsPath.PathPoints[0];
				float offsetX = lastPoint.X - pointF4.X;
				float num20 = lastPoint.Y - pointF4.Y;
				if (num20 != 0f || num20 != 0f)
				{
					Matrix matrix3 = new Matrix();
					matrix3.Translate(offsetX, num20);
					graphicsPath.Transform(matrix3);
				}
			}
			graphicsPath_0.AddPath(graphicsPath, connect: true);
			return result;
		}

		private static float smethod_58(PointF pointF_0, PointF pointF_1)
		{
			float num = pointF_0.X * pointF_1.Y - pointF_1.X * pointF_0.Y;
			float num2 = pointF_0.X * pointF_1.X + pointF_0.Y * pointF_1.Y;
			return (float)(Math.Atan2(num, num2) * (180.0 / Math.PI));
		}
	}
}
