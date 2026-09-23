using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Xml;
using ns19;

namespace TXTextControl
{
	[Obfuscation(Exclude = true)]
	internal class ImageProvider
	{
		[Obfuscation(Exclude = true)]
		internal enum ImageKind
		{
			Small_16x16 = 0x10,
			Large_32x32 = 0x20,
			Large_76x76 = 76
		}

		[Obfuscation(Exclude = true)]
		internal class ImageSetting
		{
			private CultureInfo cultureInfo_0 = CultureInfo.CurrentUICulture;

			[CompilerGenerated]
			private Color? nullable_0;

			[CompilerGenerated]
			private Color? nullable_1;

			[CompilerGenerated]
			private bool bool_0;

			[CompilerGenerated]
			private bool bool_1;

			public CultureInfo Culture
			{
				get
				{
					return this.cultureInfo_0;
				}
				set
				{
					this.cultureInfo_0 = value;
				}
			}

			public Color? Stroke
			{
				[CompilerGenerated]
				get
				{
					return this.nullable_0;
				}
				[CompilerGenerated]
				set
				{
					this.nullable_0 = value;
				}
			}

			public Color? Fill
			{
				[CompilerGenerated]
				get
				{
					return this.nullable_1;
				}
				[CompilerGenerated]
				set
				{
					this.nullable_1 = value;
				}
			}

			public bool DrawGroupMarker
			{
				[CompilerGenerated]
				get
				{
					return this.bool_0;
				}
				[CompilerGenerated]
				set
				{
					this.bool_0 = value;
				}
			}

			public bool CheckCulture
			{
				[CompilerGenerated]
				get
				{
					return this.bool_1;
				}
				[CompilerGenerated]
				set
				{
					this.bool_1 = value;
				}
			}
		}

		private static XmlDocument xmlDocument_0;

		private static XmlDocument xmlDocument_1;

		static ImageProvider()
		{
			ImageProvider.xmlDocument_0 = new XmlDocument();
			ImageProvider.xmlDocument_1 = new XmlDocument();
			Assembly executingAssembly = Assembly.GetExecutingAssembly();
			
			ImageProvider.xmlDocument_0.Load(executingAssembly.GetManifestResourceStream("TXTextControl.TXTextControl.ImagePathes.xml"));
			ImageProvider.xmlDocument_1.Load(executingAssembly.GetManifestResourceStream("TXTextControl.TXTextControl.GroupMarker.xml"));
		}

		[Obfuscation(Exclude = true)]
		internal static Bitmap GetBitmap(string itemID, ImageKind imageKind, double dpi)
		{
			return ImageProvider.GetBitmap(itemID, imageKind, dpi, new ImageSetting());
		}

		[Obfuscation(Exclude = true)]
		internal static Bitmap GetBitmap(string itemID, ImageKind imageKind, double dpi, ImageSetting settings)
		{
			if (string.IsNullOrEmpty(itemID))
			{
				return null;
			}
			try
			{
				Stream stream = null;
				if (settings.CheckCulture && settings.Culture.TwoLetterISOLanguageName != "en")
				{
					stream = ImageProvider.smethod_0(itemID + "_" + settings.Culture.TwoLetterISOLanguageName.ToUpper(), imageKind);
				}
				if (stream == null)
				{
					string text = itemID.Replace("TXITEM_", "");
					string name = string.Concat("TXTextControl.Images.", imageKind, ".", text, ".svg");

					var n = Assembly.GetAssembly(typeof(ImageProvider)).GetManifestResourceNames();

					stream = Assembly.GetAssembly(typeof(ImageProvider)).GetManifestResourceStream(name);
					if (stream == null && (stream = ImageProvider.smethod_0(itemID, imageKind)) == null)
					{
						return null;
					}
				}
				Size size_ = imageKind switch
				{
					ImageKind.Large_76x76 => new Size(76, 76), 
					ImageKind.Small_16x16 => new Size(16, 16), 
					_ => new Size(32, 32), 
				};
				Bitmap bitmap_ = ImageProvider.smethod_1(size_, dpi, out var bool_, out var double_);
				bitmap_ = ImageProvider.smethod_2(stream, bitmap_, settings);
				stream.Dispose();
				if (bitmap_ != null && !bool_)
				{
					Bitmap bitmap = new Bitmap((int)((double)size_.Width * double_), (int)((double)size_.Height * double_));
					bitmap.SetResolution((int)dpi, (int)dpi);
					Graphics graphics = Graphics.FromImage(bitmap);
					graphics.DrawImage(bitmap_, new Rectangle(0, 0, bitmap.Width, bitmap.Height), 0, 0, bitmap_.Width, bitmap_.Height, GraphicsUnit.Pixel);
					bitmap_.Dispose();
					graphics.Dispose();
					return bitmap;
				}
				return bitmap_;
			}
			catch
			{
			}
			return null;
		}

		[Obfuscation(Exclude = true)]
		internal static string GetSVG(string itemID, ImageKind imageKind)
		{
			return ImageProvider.GetSVG(itemID, imageKind, null);
		}

		[Obfuscation(Exclude = true)]
		internal static string GetSVG(string itemID, ImageKind imageKind, CultureInfo culture)
		{
			Stream stream = null;
			if (culture != null && culture.TwoLetterISOLanguageName != "en")
			{
				stream = ImageProvider.smethod_0(itemID + "_" + culture.TwoLetterISOLanguageName.ToUpper(), imageKind);
			}
			if (stream == null)
			{
				string text = itemID.Replace("TXITEM_", "");
				string name = string.Concat("TXTextControl.TXTextControl.Images.", imageKind, ".", text, ".svg");
				stream = Assembly.GetAssembly(typeof(ImageProvider)).GetManifestResourceStream(name);
				if (stream == null && (stream = ImageProvider.smethod_0(itemID, imageKind)) == null)
				{
					name = string.Concat("TXTextControl.TXTextControl.Images.", imageKind, ".dummy.svg");
					stream = Assembly.GetAssembly(typeof(ImageProvider)).GetManifestResourceStream(name);
				}
			}
			StreamReader streamReader = new StreamReader(stream);
			return streamReader.ReadToEnd();
		}

		private static Stream smethod_0(string string_0, ImageKind imageKind_0)
		{
			Stream result = null;
			XmlNode xmlNode = ImageProvider.xmlDocument_0.SelectSingleNode("ImageContainers/" + string_0 + "/" + imageKind_0);
			if (xmlNode != null)
			{
				string name = "TXTextControl." + xmlNode.FirstChild.Value;
				//var n = Assembly.GetExecutingAssembly().GetManifestResourceNames();
				result = Assembly.GetAssembly(typeof(ImageProvider)).GetManifestResourceStream(name);
			}
			return result;
		}

		private static Bitmap smethod_1(Size size_0, double double_0, out bool bool_0, out double double_1)
		{
			double_1 = double_0 / 96.0;
			int num = ((bool_0 = double_1 % 2.0 == 0.0) ? ((int)double_1) : ((int)Math.Ceiling(double_1)));
			Bitmap bitmap = new Bitmap(size_0.Width * num, size_0.Height * num, PixelFormat.Format32bppArgb);
			bitmap.SetResolution((int)double_0, (int)double_0);
			return bitmap;
		}

		private static Bitmap smethod_2(Stream stream_0, Bitmap bitmap_0, ImageSetting imageSetting_0)
		{
			Graphics graphics_ = Graphics.FromImage(bitmap_0);
			if (stream_0 == null)
			{
				return null;
			}
			ImageProvider.smethod_3(graphics_, new RectangleF(0f, 0f, bitmap_0.Width, bitmap_0.Height), stream_0, imageSetting_0);
			return bitmap_0;
		}

		private static void smethod_3(Graphics graphics_0, RectangleF rectangleF_0, Stream stream_0, ImageSetting imageSetting_0)
		{
			try
			{
				XmlTextReader xmlTextReader = new XmlTextReader(stream_0);
				XmlDocument xmlDocument;
				System.Xml.XmlElement xmlElement = Class378.smethod_0(xmlTextReader, out xmlDocument);
				if (xmlElement != null)
				{
					if (imageSetting_0.DrawGroupMarker)
					{
						XmlNode xmlNode = xmlDocument.ImportNode(ImageProvider.xmlDocument_1.LastChild.FirstChild, deep: true);
						XmlNode firstChild = xmlNode.FirstChild;
						XmlNodeList elementsByTagName = xmlDocument.GetElementsByTagName("style");
						XmlNode xmlNode2;
						if (elementsByTagName.Count == 0)
						{
							xmlNode2 = xmlDocument.CreateElement("style");
							xmlElement.InsertBefore(xmlNode2, xmlElement.FirstChild);
						}
						else
						{
							xmlNode2 = elementsByTagName[0];
						}
						xmlNode2.InnerText += firstChild.InnerText;
						for (int i = 1; i < ImageProvider.xmlDocument_1.DocumentElement.ChildNodes.Count; i++)
						{
							XmlNode node = ImageProvider.xmlDocument_1.DocumentElement.ChildNodes.Item(i);
							node = xmlDocument.ImportNode(node, deep: true);
							xmlElement.AppendChild(node);
						}
					}
					Class376 class376_ = new Class376(graphics_0, xmlElement, rectangleF_0, AlignX.Left, AlignY.Top, imageSetting_0);
					Class378.smethod_1(class376_, xmlElement);
				}
				xmlTextReader.Close();
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
	}
}
