using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Xml;
using TXTextControl;

namespace ns19
{
	internal class Class376
	{
		private Graphics graphics_0;

		private RectangleF rectangleF_0;

		private RectangleF rectangleF_1;

		private Class387 class387_0;

		private Dictionary<string, Def> dictionary_0 = new Dictionary<string, Def>();

		private List<Class377> list_0 = new List<Class377>();

		private ImageProvider.ImageSetting imageSetting_0;

		internal List<Class377> List_0 => this.list_0;

		internal RectangleF RectangleF_0 => this.rectangleF_0;

		internal RectangleF RectangleF_1 => this.rectangleF_1;

		internal Graphics Graphics_0 => this.graphics_0;

		internal Dictionary<string, Def> Dictionary_0 => this.dictionary_0;

		internal ImageProvider.ImageSetting ImageSetting_0 => this.imageSetting_0;

		internal Class376(Graphics graphics_1, System.Xml.XmlElement xmlElement_0, RectangleF rectangleF_2, AlignX alignX_0, AlignY alignY_0, ImageProvider.ImageSetting imageSetting_1)
		{
			this.imageSetting_0 = imageSetting_1;
			this.graphics_0 = graphics_1;
			this.rectangleF_0 = rectangleF_2;
			string attribute = xmlElement_0.GetAttribute("width");
			string attribute2 = xmlElement_0.GetAttribute("height");
			if (!string.IsNullOrEmpty(attribute) && !string.IsNullOrEmpty(attribute2))
			{
				Struct37 struct37_ = new Struct37(attribute);
				float width = Class378.smethod_36(struct37_, rectangleF_2.Width, 16f);
				Struct37 struct37_2 = new Struct37(attribute2);
				float height = Class378.smethod_36(struct37_2, rectangleF_2.Height, 16f);
				this.rectangleF_1 = new RectangleF(0f, 0f, width, height);
			}
			else
			{
				string attribute3 = xmlElement_0.GetAttribute("viewBox");
				if (!string.IsNullOrEmpty(attribute3))
				{
					RectangleF rectangleF = Class378.smethod_20(attribute3);
					this.rectangleF_1 = new RectangleF(0f, 0f, rectangleF.Width, rectangleF.Height);
				}
				else
				{
					this.rectangleF_1 = RectangleF.Empty;
				}
			}
			this.class387_0 = new Class387(this.rectangleF_1, this.rectangleF_0, alignX_0, alignY_0);
		}

		internal Class376(Graphics graphics_1, System.Xml.XmlElement xmlElement_0, float float_0, PointF pointF_0, AlignX alignX_0, AlignY alignY_0)
		{
			this.graphics_0 = graphics_1;
			string attribute = xmlElement_0.GetAttribute("width");
			string attribute2 = xmlElement_0.GetAttribute("height");
			if (!string.IsNullOrEmpty(attribute) && !string.IsNullOrEmpty(attribute2))
			{
				Struct37 struct37_ = new Struct37(attribute);
				float width = Class378.smethod_36(struct37_, graphics_1.ClipBounds.Width, 16f);
				Struct37 struct37_2 = new Struct37(attribute2);
				float height = Class378.smethod_36(struct37_2, graphics_1.ClipBounds.Height, 16f);
				this.rectangleF_1 = new RectangleF(0f, 0f, width, height);
			}
			else
			{
				string attribute3 = xmlElement_0.GetAttribute("viewBox");
				if (!string.IsNullOrEmpty(attribute3))
				{
					RectangleF rectangleF = Class378.smethod_20(attribute3);
					this.rectangleF_1 = new RectangleF(0f, 0f, rectangleF.Width, rectangleF.Height);
				}
				else
				{
					this.rectangleF_1 = RectangleF.Empty;
				}
			}
			if (!this.rectangleF_1.IsEmpty)
			{
				float num = graphics_1.DpiX / 96f * float_0;
				float num2 = graphics_1.DpiY / 96f * float_0;
				float num3 = this.rectangleF_1.Width * num;
				float num4 = this.rectangleF_1.Height * num2;
				float x = pointF_0.X - num3 / 2f;
				float y = pointF_0.Y - num4 / 2f;
				this.rectangleF_0 = new RectangleF(x, y, num3, num4);
			}
			this.class387_0 = new Class387(this.rectangleF_1, this.rectangleF_0, alignX_0, alignY_0);
		}

		internal void method_0()
		{
			PixelOffsetMode pixelOffsetMode = this.graphics_0.PixelOffsetMode;
			SmoothingMode smoothingMode = this.graphics_0.SmoothingMode;
			this.graphics_0.PixelOffsetMode = PixelOffsetMode.Half;
			this.graphics_0.SmoothingMode = SmoothingMode.HighQuality;
			foreach (Class377 item in this.list_0)
			{
				GraphicsPath graphicsPath_ = null;
				float num = 1f;
				if (item.ITransformAttribute_0 != null)
				{
					ITransformAttribute[] iTransformAttribute_ = item.ITransformAttribute_0;
					foreach (ITransformAttribute transformAttribute in iTransformAttribute_)
					{
						if (transformAttribute is Class391)
						{
							num *= (transformAttribute as Class391).Single_0;
						}
						else if (transformAttribute is Class387)
						{
							num *= (transformAttribute as Class387).method_0(this.graphics_0, item.GraphicsPath_0, out this.rectangleF_1, ref graphicsPath_);
						}
						transformAttribute.ApplyTransformation(item.GraphicsPath_0, ref graphicsPath_);
					}
				}
				float num2 = this.class387_0.method_0(this.graphics_0, item.GraphicsPath_0, out this.rectangleF_1, ref graphicsPath_);
				this.class387_0.ApplyTransformation(item.GraphicsPath_0, ref graphicsPath_);
				this.graphics_0.SetClip(graphicsPath_);
				if (item.Def_0 != null)
				{
					this.graphics_0.FillPath((item.Def_0 as Class381).vmethod_0(this, item), item.GraphicsPath_0);
				}
				if (item.Pen_0 != null)
				{
					item.Pen_0.Width = (int)(item.Pen_0.Width * num * num2);
					_ = item.Pen_0.DashCap;
					this.graphics_0.DrawPath(item.Pen_0, item.GraphicsPath_0);
				}
			}
			this.graphics_0.PixelOffsetMode = pixelOffsetMode;
			this.graphics_0.SmoothingMode = smoothingMode;
		}
	}
}
