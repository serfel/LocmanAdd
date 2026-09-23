using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;

namespace ns21
{
	internal class Class423 : TypeConverter
	{
		private const string string_0 = "(none)";

		private string string_1;

		internal Class423(string string_2)
		{
			this.string_1 = string_2;
		}

		public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
		{
			return true;
		}

		public override bool GetStandardValuesExclusive(ITypeDescriptorContext context)
		{
			return true;
		}

		public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
		{
			if (sourceType == typeof(string))
			{
				return true;
			}
			return base.CanConvertFrom(context, sourceType);
		}

		public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
		{
			if (!(value is string))
			{
				return value;
			}
			if (value as string== "(none)")
			{
				return null;
			}
			foreach (IComponent component3 in context.Container.Components)
			{
				ISite site = component3.Site;
				Component component2 = site.Component as Component;
				if (component2 != null && component2.GetType().Name == this.string_1 && site.Name == value as string)
				{
					return component2;
				}
			}
			return value;
		}

		public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
		{
			if (value == null)
			{
				return "(none)";
			}
			IComponent component = value as IComponent;
			if (component != null && value.GetType().Name == this.string_1)
			{
				return component.Site.Name;
			}
			return value;
		}

		public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
		{
			List<string> list = new List<string>();
			list.Add("(none)");
			foreach (IComponent component3 in context.Container.Components)
			{
				ISite site = component3.Site;
				Component component2 = site.Component as Component;
				if (component2 != null && component2.GetType().Name == this.string_1)
				{
					list.Add(site.Name);
				}
			}
			string[] values = list.ToArray();
			return new StandardValuesCollection(values);
		}
	}
}
