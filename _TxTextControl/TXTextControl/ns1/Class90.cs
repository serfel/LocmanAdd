using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;

namespace ns1
{
	internal class Class90 : TypeConverter
	{
		private const string string_0 = "(none)";

		private List<string> list_0 = new List<string>();

		internal Class90(params string[] string_1)
		{
			this.list_0.AddRange(string_1);
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
			foreach (IComponent component2 in context.Container.Components)
			{
				ISite site = component2.Site;
				Component component = site.Component as Component;
				if (component != null && this.list_0.Contains(component.GetType().Name) && site.Name == value as string)
				{
					return component;
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
			if (component != null && component.Site != null && this.list_0.Contains(value.GetType().Name))
			{
				return component.Site.Name;
			}
			return value;
		}

		public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
		{
			List<string> list = new List<string>();
			list.Add("(none)");
			foreach (IComponent component2 in context.Container.Components)
			{
				ISite site = component2.Site;
				Component component = site.Component as Component;
				if (component != null && this.list_0.Contains(component.GetType().Name))
				{
					list.Add(site.Name);
				}
			}
			return new StandardValuesCollection(list.ToArray());
		}
	}
}
