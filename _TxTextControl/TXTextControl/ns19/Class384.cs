using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Xml;
using TXTextControl;

namespace ns19
{
	internal class Class384 : Class383
	{
		private Struct36? nullable_0;

		private Struct36? nullable_1;

		private Struct36? nullable_2;

		private Struct36? nullable_3;

		private bool bool_0;

		private XmlAttribute xmlAttribute_0;

		internal Class384(System.Xml.XmlElement xmlElement_0)
			: base(xmlElement_0)
		{
			base.string_0 = xmlElement_0.Attributes["id"].Value;
			string attribute = xmlElement_0.GetAttribute("x1");
			string attribute2 = xmlElement_0.GetAttribute("y1");
			string attribute3 = xmlElement_0.GetAttribute("x2");
			string attribute4 = xmlElement_0.GetAttribute("y2");
			this.nullable_0 = (string.IsNullOrEmpty(attribute) ? null : new Struct36?(new Struct36(attribute)));
			this.nullable_1 = (string.IsNullOrEmpty(attribute2) ? null : new Struct36?(new Struct36(attribute2)));
			this.nullable_2 = (string.IsNullOrEmpty(attribute3) ? null : new Struct36?(new Struct36(attribute3)));
			this.nullable_3 = (string.IsNullOrEmpty(attribute4) ? null : new Struct36?(new Struct36(attribute4)));
			string attribute5 = xmlElement_0.GetAttribute("gradientUnits");
			this.bool_0 = !string.IsNullOrEmpty(attribute5) && attribute5 == "userSpaceOnUse";
			this.xmlAttribute_0 = xmlElement_0.Attributes["xlink:href"];
		}

		internal override Brush vmethod_0(Class376 class376_0, Class377 class377_0)
		{
			Def value = null;
			Class384 @class = null;
			List<Class386> list = base.list_0;
			if (this.xmlAttribute_0 != null)
			{
				if (!class376_0.Dictionary_0.TryGetValue(this.xmlAttribute_0.Value.Substring(1), out value))
				{
					throw new NullReferenceException(this.xmlAttribute_0.Value);
				}
				if (!(value is Class384))
				{
					throw new InvalidCastException();
				}
				@class = value as Class384;
				if (list.Count == 0)
				{
					list = @class.list_0;
				}
			}
			if (list.Count == 0)
			{
				throw new Exception("No Gradient Stops found.");
			}
			this.nullable_0 = (this.nullable_0.HasValue ? this.nullable_0.Value : ((@class == null || !@class.nullable_0.HasValue) ? new Struct36(0f, Struct37.Enum45.const_8) : @class.nullable_0.Value));
			this.nullable_1 = (this.nullable_1.HasValue ? this.nullable_1.Value : ((@class == null || !@class.nullable_1.HasValue) ? new Struct36(0f, Struct37.Enum45.const_8) : @class.nullable_1.Value));
			this.nullable_2 = (this.nullable_2.HasValue ? this.nullable_2.Value : ((@class == null || !@class.nullable_2.HasValue) ? new Struct36(100f, Struct37.Enum45.const_8) : @class.nullable_2.Value));
			this.nullable_3 = (this.nullable_3.HasValue ? this.nullable_3.Value : ((@class == null || !@class.nullable_3.HasValue) ? new Struct36(0f, Struct37.Enum45.const_8) : @class.nullable_3.Value));
			float num = Class378.smethod_35(this.nullable_0.Value, 100f, class377_0.Single_0) * (float)((this.nullable_0.Value.Struct37_0.Enum45_0 == Struct37.Enum45.const_8) ? 1 : 100);
			float num2 = Class378.smethod_35(this.nullable_1.Value, 100f, class377_0.Single_0) * (float)((this.nullable_1.Value.Struct37_0.Enum45_0 == Struct37.Enum45.const_8) ? 1 : 100);
			float num3 = Class378.smethod_35(this.nullable_2.Value, 100f, class377_0.Single_0) * (float)((this.nullable_2.Value.Struct37_0.Enum45_0 == Struct37.Enum45.const_8) ? 1 : 100);
			float num4 = Class378.smethod_35(this.nullable_3.Value, 100f, class377_0.Single_0) * (float)((this.nullable_3.Value.Struct37_0.Enum45_0 == Struct37.Enum45.const_8) ? 1 : 100);
			RectangleF bounds = class377_0.GraphicsPath_0.GetBounds();
			PointF pointF = new PointF(num * bounds.Width / 100f, num2 * bounds.Height / 100f);
			PointF pointF2 = new PointF(num3 * bounds.Width / 100f, num4 * bounds.Height / 100f);
			SizeF sizeF = new SizeF((pointF2.X - pointF.X) / 2f, (pointF2.Y - pointF.Y) * 2f);
			float num5 = sizeF.Width / sizeF.Height;
			float angle = 90f - (float)(Math.Atan(num5) * 180.0 / Math.PI);
			float[] array = new float[list.Count + 2];
			Color[] array2 = new Color[list.Count + 2];
			float num6 = 1f;
			for (int i = 0; i < list.Count; i++)
			{
				Class386 class2 = list[i];
				array[i + 1] = class2.Single_0 / 100f / num6;
				ref Color reference = ref array2[i + 1];
				reference = class2.Color_0;
			}
			array[0] = 0f;
			array[array.Length - 1] = 1f;
			ref Color reference2 = ref array2[0];
			reference2 = list[0].Color_0;
			ref Color reference3 = ref array2[array2.Length - 1];
			reference3 = list[list.Count - 1].Color_0;
			LinearGradientBrush linearGradientBrush = new LinearGradientBrush(bounds, Color.Black, Color.Black, angle, isAngleScaleable: false);
			ColorBlend colorBlend = new ColorBlend();
			colorBlend.Positions = array;
			colorBlend.Colors = array2;
			linearGradientBrush.InterpolationColors = colorBlend;
			return linearGradientBrush;
		}
	}
}
