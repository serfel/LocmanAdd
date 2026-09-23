using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;

namespace ns27
{
	internal sealed class Class602 : CustomTypeDescriptor
	{
		private IServiceProvider iserviceProvider_0;

		internal Class602(ICustomTypeDescriptor icustomTypeDescriptor_0, IComponent icomponent_0)
			: base(icustomTypeDescriptor_0)
		{
			if (icomponent_0 != null)
			{
				this.iserviceProvider_0 = icomponent_0.Site;
			}
		}

		public override AttributeCollection GetAttributes()
		{
			AttributeCollection attributes = base.GetAttributes();
			List<Attribute> list = new List<Attribute>();
			foreach (Attribute item2 in attributes)
			{
				DesignerAttribute designerAttribute = item2 as DesignerAttribute;
				if (designerAttribute != null && designerAttribute.DesignerBaseTypeName.StartsWith("System.ComponentModel.Design.IDesigner"))
				{
					ITypeResolutionService typeResolutionService = null;
					if (this.iserviceProvider_0 != null)
					{
						typeResolutionService = (ITypeResolutionService)this.iserviceProvider_0.GetService(typeof(ITypeResolutionService));
					}
					if (typeResolutionService != null && typeResolutionService.GetType(designerAttribute.DesignerTypeName) == null)
					{
						DesignerAttribute item = new DesignerAttribute("System.Windows.Forms.Design.ParentControlDesigner, System.Design");
						list.Add(item);
						continue;
					}
				}
				list.Add(item2);
			}
			return new AttributeCollection(list.ToArray());
		}
	}
}
