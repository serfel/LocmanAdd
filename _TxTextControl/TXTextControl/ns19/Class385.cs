using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Xml;
using TXTextControl;

namespace ns19
{
	internal class Class385 : Class383
	{
		private Struct36 struct36_0;

		private Struct36 struct36_1;

		private Struct36 struct36_2;

		private Struct36 struct36_3;

		private Struct37 struct37_0;

		private bool bool_0;

		private XmlAttribute xmlAttribute_0;

		internal Class385(System.Xml.XmlElement xmlElement_0)
			: base(xmlElement_0)
		{
			base.string_0 = xmlElement_0.Attributes["id"].Value;
			string attribute = xmlElement_0.GetAttribute("cx");
			string attribute2 = xmlElement_0.GetAttribute("cy");
			string attribute3 = xmlElement_0.GetAttribute("r");
			string attribute4 = xmlElement_0.GetAttribute("fx");
			string attribute5 = xmlElement_0.GetAttribute("fy");
			this.struct36_0 = (string.IsNullOrEmpty(attribute) ? new Struct36("50%") : new Struct36(attribute));
			this.struct36_1 = (string.IsNullOrEmpty(attribute2) ? new Struct36("50%") : new Struct36(attribute2));
			this.struct37_0 = (string.IsNullOrEmpty(attribute3) ? new Struct37("50%") : new Struct37(attribute3));
			this.struct36_2 = (string.IsNullOrEmpty(attribute4) ? this.struct36_0 : new Struct36(attribute4));
			this.struct36_3 = (string.IsNullOrEmpty(attribute4) ? this.struct36_1 : new Struct36(attribute5));
			string attribute6 = xmlElement_0.GetAttribute("gradientUnits");
			this.bool_0 = !string.IsNullOrEmpty(attribute6) && attribute6 == "userSpaceOnUse";
			this.xmlAttribute_0 = xmlElement_0.Attributes["xlink:href"];
		}

		internal override Brush vmethod_0(Class376 class376_0, Class377 class377_0)
		{
			Def value = null;
			Class385 @class = null;
			List<Class386> list = base.list_0;
			if (this.xmlAttribute_0 != null)
			{
				if (!class376_0.Dictionary_0.TryGetValue(this.xmlAttribute_0.Value.Substring(1), out value))
				{
					throw new NullReferenceException(this.xmlAttribute_0.Value);
				}
				if (!(value is Class385))
				{
					throw new InvalidCastException();
				}
				@class = value as Class385;
				if (list.Count == 0)
				{
					list = @class.list_0;
				}
			}
			if (list.Count == 0)
			{
				throw new Exception("No Gradient Stops found.");
			}
			Class378.smethod_35(this.struct36_0, 100f, class377_0.Single_0);
			_ = this.struct36_0.Struct37_0.Enum45_0;
			Class378.smethod_35(this.struct36_1, 100f, class377_0.Single_0);
			_ = this.struct36_1.Struct37_0.Enum45_0;
			Class378.smethod_36(this.struct37_0, 100f, class377_0.Single_0);
			_ = this.struct37_0.Enum45_0;
			float[] array = new float[list.Count];
			Color[] array2 = new Color[list.Count];
			int num = list.Count - 1;
			for (int i = 0; i < list.Count; i++)
			{
				Class386 class2 = list[i];
				ref Color reference = ref array2[num];
				reference = class2.Color_0;
				array[i] = class2.Single_0 / 100f;
				num--;
			}
			class377_0.GraphicsPath_0.GetBounds();
			PathGradientBrush pathGradientBrush = new PathGradientBrush(class377_0.GraphicsPath_0);
			ColorBlend colorBlend = new ColorBlend();
			colorBlend.Colors = array2;
			colorBlend.Positions = array;
			pathGradientBrush.InterpolationColors = colorBlend;
			class377_0.GraphicsPath_0.GetBounds();
			return pathGradientBrush;
		}
	}
}
