using System;
using System.Windows.Forms;
using TXTextControl.Windows.Forms.Ribbon;

namespace TXTextControl.Windows.Forms.Ribbon
{
	internal class Class497 : RibbonGroup
	{
		internal override void vmethod_0(Class560 class560_2, bool bool_7)
		{
			base.bool_4 = false;
			base.bool_0 = true;
			base.ribbonMenuButton_0.Visible = false;
			base.class514_0.Controls.Clear();
			base.class514_0.ColumnCount = 0;
			base.class514_0.RowCount = class560_2.Class557_0.Length;
			base.class514_0.RowStyles.Clear();
			if (!bool_7)
			{
				base.class514_0.SetRowSpan(base.ribbonMenuButton_0, 1);
			}
			for (int i = 0; i < class560_2.Class557_0[0].Class559_0.Length; i++)
			{
				base.class514_0.RowStyles.Add(new RowStyle(SizeType.AutoSize));
				Class559 @class = class560_2.Class557_0[0].Class559_0[i];
				Control control;
				if (bool_7)
				{
					Type type = @class.IRibbonItem_0.GetType();
					control = (Control)Activator.CreateInstance(type);
					Class517.smethod_3((Control)@class.IRibbonItem_0, control);
					if (control is IRibbonItem)
					{
						(control as IRibbonItem).AwareOfDPI(base.class498_0.PointF_0);
					}
				}
				else
				{
					control = (Control)@class.IRibbonItem_0;
				}
				IScalable scalable;
				if ((scalable = control as IScalable) != null)
				{
					scalable.SetDisplayMode(@class.IconTextRelation_0);
				}
				base.method_0(base.class514_0, control, 0, i);
			}
			base.bool_0 = false;
		}
	}
}
