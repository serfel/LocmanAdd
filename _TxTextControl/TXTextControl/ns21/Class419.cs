using System;
using System.ComponentModel;
using System.Globalization;
using TXTextControl;

namespace ns21
{
	internal class Class419 : TypeConverter
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
				if (array.Length == 1)
				{
					double num = (double)converter.ConvertFromString(context, culture, array[0]);
					return new PageMargins(num, num, num, num);
				}
				if (array.Length == 4)
				{
					return new PageMargins((double)converter.ConvertFromString(context, culture, array[0]), (double)converter.ConvertFromString(context, culture, array[1]), (double)converter.ConvertFromString(context, culture, array[2]), (double)converter.ConvertFromString(context, culture, array[3]));
				}
			}
			return base.ConvertFrom(context, culture, value);
		}

		public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destType)
		{
			PageMargins pageMargins = value as PageMargins;
			if (pageMargins != null && destType == typeof(string))
			{
				TypeConverter converter = TypeDescriptor.GetConverter(typeof(double));
				return string.Join(",", converter.ConvertToString(context, culture, pageMargins.Left), converter.ConvertToString(context, culture, pageMargins.Top), converter.ConvertToString(context, culture, pageMargins.Right), converter.ConvertToString(context, culture, pageMargins.Bottom));
			}
			return base.ConvertTo(context, culture, value, destType);
		}
	}
}
