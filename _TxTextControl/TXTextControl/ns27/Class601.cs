using System;
using System.ComponentModel;
using TXTextControl.Windows.Forms.Ribbon;

namespace ns27
{
	internal sealed class Class601 : TypeDescriptionProvider
	{
		internal Class601(TypeDescriptionProvider typeDescriptionProvider_0)
			: base(typeDescriptionProvider_0)
		{
		}

		public override ICustomTypeDescriptor GetTypeDescriptor(Type objectType, object instance)
		{
			if (objectType.Assembly == typeof(Ribbon).Assembly)
			{
				IComponent component = instance as IComponent;
				if (component != null && component.Site != null)
				{
					return new Class602(base.GetTypeDescriptor(objectType, instance), component);
				}
			}
			return base.GetTypeDescriptor(objectType, instance);
		}
	}
}
