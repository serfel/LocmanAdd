using System;
using System.ComponentModel;
using System.Globalization;

namespace ns21
{
	internal class Class417 : ExpandableObjectConverter
	{
		public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destType)
		{
			if (destType == typeof(string))
			{
				return "";
			}
			return base.ConvertTo(context, culture, value, destType);
		}
	}
}
