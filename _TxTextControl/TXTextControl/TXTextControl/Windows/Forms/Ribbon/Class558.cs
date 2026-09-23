using System.Windows.Forms;
using TXTextControl.Windows.Forms.Ribbon;

namespace TXTextControl.Windows.Forms.Ribbon
{
	internal class Class558 : Class557
	{
		private Class559[][] class559_1;

		internal Class559[][] Class559_1 => this.class559_1;

		internal Class558(int int_1)
			: base(int_1)
		{
			this.class559_1 = new Class559[int_1][];
		}

		internal int method_2()
		{
			int num = 0;
			Class559[][] array = this.class559_1;
			foreach (Class559[] array2 in array)
			{
				int num2 = 0;
				Class559[] array3 = array2;
				foreach (Class559 @class in array3)
				{
					if (@class != null)
					{
						IScalable scalable = @class.IRibbonItem_0 as IScalable;
						IconTextRelation scaleMode = ((scalable == null || scalable.IsScalable) ? @class.IconTextRelation_0 : scalable.DefaultDisplayMode);
						num2 += (int)@class.IRibbonItem_0.GetSize(scaleMode).Width + ((Control)@class.IRibbonItem_0).Margin.Horizontal;
					}
				}
				if (num < num2)
				{
					num = num2;
				}
			}
			return num;
		}
	}
}
