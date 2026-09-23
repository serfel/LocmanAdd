using System;
using System.ComponentModel;
using System.Globalization;
using System.Resources;
using TXTextControl;

namespace ns21
{
	internal class Class422 : TypeConverter
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
				NumFormat[] array = (NumFormat[])Enum.GetValues(typeof(NumFormat));
				foreach (NumFormat numberFormat in array)
				{
					if (resourceManager.GetString(numberFormat.ToString()) == text)
					{
						return numberFormat;
					}
				}
			}
			return base.ConvertFrom(context, culture, value);
		}

		public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destType)
		{
			if (value.GetType() == typeof(NumFormat) && destType == typeof(string))
			{
				NumFormat numberFormat = (NumFormat)value;
				ResourceManager resourceManager = new ResourceManager(typeof(TextControlCore));
				string @string = resourceManager.GetString(numberFormat.ToString());
				if (@string != null)
				{
					return @string;
				}
			}
			return base.ConvertTo(context, culture, value, destType);
		}
	}
}
