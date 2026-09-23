using System;
using System.ComponentModel;
using TXTextControl.DocumentServer;

namespace ns1
{
	internal sealed class Class80 : TypeDescriptionProvider
	{
		internal Class80(TypeDescriptionProvider typeDescriptionProvider_0)
			: base(typeDescriptionProvider_0)
		{
		}

		public override ICustomTypeDescriptor GetTypeDescriptor(Type objectType, object instance)
		{
			if (objectType.Assembly == typeof(MailMerge).Assembly)
			{
				IComponent component = instance as IComponent;
				if (component != null && component.Site != null)
				{
					return new Class81(base.GetTypeDescriptor(objectType, instance), component);
				}
			}
			return base.GetTypeDescriptor(objectType, instance);
		}
	}
}
