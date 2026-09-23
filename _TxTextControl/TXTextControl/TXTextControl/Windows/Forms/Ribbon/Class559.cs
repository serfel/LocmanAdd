using TXTextControl.Windows.Forms.Ribbon;

namespace TXTextControl.Windows.Forms.Ribbon
{
	internal class Class559
	{
		private IconTextRelation iconTextRelation_0 = IconTextRelation.SmallIconUnlabeled;

		private IRibbonItem iribbonItem_0;

		internal IconTextRelation IconTextRelation_0 => this.iconTextRelation_0;

		internal IRibbonItem IRibbonItem_0 => this.iribbonItem_0;

		internal Class559(IRibbonItem iribbonItem_1)
		{
			if (iribbonItem_1 is RibbonLabel)
			{
				this.iconTextRelation_0 = (iribbonItem_1 as RibbonLabel).IconTextRelation_0;
			}
			this.iribbonItem_0 = iribbonItem_1;
		}

		internal Class559(IRibbonItem iribbonItem_1, IconTextRelation iconTextRelation_1)
		{
			this.iribbonItem_0 = iribbonItem_1;
			this.iconTextRelation_0 = iconTextRelation_1;
		}
	}
}
