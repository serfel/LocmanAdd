using System;
using System.ComponentModel;
using System.Drawing.Printing;
using System.Globalization;

namespace ns21
{
	internal class Class418 : TypeConverter
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
			if (value is string)
			{
				return value;
			}
			return base.ConvertFrom(context, culture, value);
		}

		public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
		{
			return true;
		}

		public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
		{
			PrinterSettings.StringCollection installedPrinters = PrinterSettings.InstalledPrinters;
			string[] array = new string[installedPrinters.Count + 2];
			array[0] = "Standard";
			array[1] = "Display";
			for (int i = 0; i < installedPrinters.Count; i++)
			{
				array[i + 2] = installedPrinters[i];
			}
			return new StandardValuesCollection(array);
		}

		public override bool GetStandardValuesExclusive(ITypeDescriptorContext context)
		{
			return false;
		}
	}
}
