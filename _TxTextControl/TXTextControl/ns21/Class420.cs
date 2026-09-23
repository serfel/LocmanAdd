using System;
using System.ComponentModel;
using System.Globalization;
using TXTextControl;

namespace ns21
{
	internal class Class420 : TypeConverter
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
				text = text.Trim();
				string[] array = text.Split(',');
				TypeConverter converter = TypeDescriptor.GetConverter(typeof(double));
				if (array.Length == 2)
				{
					return new PageSize((double)converter.ConvertFromString(context, culture, array[0]), (double)converter.ConvertFromString(context, culture, array[1]));
				}
			}
			return base.ConvertFrom(context, culture, value);
		}

		public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destType)
		{
			PageSize pageSize = value as PageSize;
			if (pageSize != null && destType == typeof(string))
			{
				TypeConverter converter = TypeDescriptor.GetConverter(typeof(double));
				return string.Join(",", converter.ConvertToString(context, culture, pageSize.Width), converter.ConvertToString(context, culture, pageSize.Height));
			}
			return base.ConvertTo(context, culture, value, destType);
		}
	}
}
