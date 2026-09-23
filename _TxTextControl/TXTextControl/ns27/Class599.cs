using System;
using System.ComponentModel;
using TXTextControl;

namespace ns27
{
	internal sealed class Class599 : TypeDescriptionProvider
	{
		internal Class599(TypeDescriptionProvider typeDescriptionProvider_0)
			: base(typeDescriptionProvider_0)
		{
		}

		public override ICustomTypeDescriptor GetTypeDescriptor(Type objectType, object instance)
		{
			if (objectType.Assembly == typeof(TextControl).Assembly)
			{
				IComponent component = instance as IComponent;
				if (component != null && component.Site != null)
				{
					return new Class600(base.GetTypeDescriptor(objectType, instance), component);
				}
			}
			return base.GetTypeDescriptor(objectType, instance);
		}
	}
}
