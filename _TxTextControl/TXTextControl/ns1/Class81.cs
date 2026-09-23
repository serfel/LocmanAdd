using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using TXTextControl.DocumentServer;

namespace ns1
{
	internal class Class81 : CustomTypeDescriptor
	{
		private IServiceProvider iserviceProvider_0;

		private MailMerge mailMerge_0;

		internal Class81(ICustomTypeDescriptor icustomTypeDescriptor_0, IComponent icomponent_0)
			: base(icustomTypeDescriptor_0)
		{
			if (icomponent_0 != null)
			{
				this.mailMerge_0 = icomponent_0 as MailMerge;
				this.iserviceProvider_0 = icomponent_0.Site;
			}
		}

		public override AttributeCollection GetAttributes()
		{
			if (this.mailMerge_0 != null)
			{
				this.mailMerge_0.int_1++;
			}
			AttributeCollection attributes = base.GetAttributes();
			if (this.mailMerge_0 == null)
			{
				return attributes;
			}
			int num = this.mailMerge_0.int_1--;
			if (num == this.mailMerge_0.int_3)
			{
				if (this.mailMerge_0.attributeCollection_0 != null && attributes != null && attributes.Equals(this.mailMerge_0.attributeCollection_0))
				{
					this.mailMerge_0.int_2 = num;
					return this.mailMerge_0.attributeCollection_1;
				}
			}
			else if (num == this.mailMerge_0.int_2 - 1)
			{
				this.mailMerge_0.int_2--;
				return this.mailMerge_0.attributeCollection_1;
			}
			this.mailMerge_0.attributeCollection_0 = attributes;
			this.mailMerge_0.int_3 = num;
			this.mailMerge_0.int_2 = num;
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
						DesignerAttribute item = new DesignerAttribute(typeof(ComponentDesigner));
						list.Add(item);
						continue;
					}
				}
				list.Add(item2);
			}
			this.mailMerge_0.attributeCollection_1 = new AttributeCollection(list.ToArray());
			return this.mailMerge_0.attributeCollection_1;
		}
	}
}
