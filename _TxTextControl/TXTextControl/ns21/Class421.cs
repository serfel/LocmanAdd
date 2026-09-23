using System;
using System.ComponentModel;
using System.Globalization;
using System.Resources;
using TXTextControl;

namespace ns21
{
	internal class Class421 : TypeConverter
	{
		public override bool CanConvertFrom(ITypeDescriptorContext context, Type t)
		{
			if (t == typeof(string))
			{
				return true;
			}
			return base.CanConvertFrom(context, t);
		}

		public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
		{
			string text = value as string;
			if (text != null)
			{
				ResourceManager resourceManager = new ResourceManager(typeof(TextControlCore));
				FontUnderlineStyle[] array = (FontUnderlineStyle[])Enum.GetValues(typeof(FontUnderlineStyle));
				foreach (FontUnderlineStyle fontUnderlineStyle in array)
				{
					if (resourceManager.GetString(fontUnderlineStyle.ToString()) == text)
					{
						return fontUnderlineStyle;
					}
				}
			}
			return base.ConvertFrom(context, culture, value);
		}

		public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destType)
		{
			if (value.GetType() == typeof(FontUnderlineStyle) && destType == typeof(string))
			{
				FontUnderlineStyle fontUnderlineStyle = (FontUnderlineStyle)value;
				ResourceManager resourceManager = new ResourceManager(typeof(TextControlCore));
				string @string = resourceManager.GetString(fontUnderlineStyle.ToString());
				if (@string != null)
				{
					return @string;
				}
			}
			return base.ConvertTo(context, culture, value, destType);
		}
	}
}
