using TXTextControl.Windows.Forms.Ribbon;

namespace TXTextControl.Windows.Forms.Ribbon
{
	internal class Class557
	{
		private int int_0;

		private IconTextRelation iconTextRelation_0 = IconTextRelation.SmallIconUnlabeled;

		private Class559[] class559_0;

		private bool bool_0 = true;

		internal bool Boolean_0
		{
			get
			{
				return this.bool_0;
			}
			set
			{
				this.bool_0 = value;
			}
		}

		internal int Int32_0 => this.int_0;

		internal IconTextRelation IconTextRelation_0 => this.iconTextRelation_0;

		internal Class559[] Class559_0
		{
			get
			{
				return this.class559_0;
			}
			set
			{
				this.class559_0 = value;
			}
		}

		internal Class557(int int_1)
		{
			this.class559_0 = new Class559[int_1];
		}

		internal int method_0()
		{
			int num = 0;
			Class559[] array = this.class559_0;
			foreach (Class559 @class in array)
			{
				if (@class == null)
				{
					break;
				}
				IScalable scalable = @class.IRibbonItem_0 as IScalable;
				IconTextRelation iconTextRelation = ((scalable == null || scalable.IsScalable) ? @class.IconTextRelation_0 : scalable.DefaultDisplayMode);
				@class.IRibbonItem_0.GetType();
				int num2 = (int)@class.IRibbonItem_0.GetSize(iconTextRelation).Width + 1;
				if (num < num2)
				{
					num = num2;
				}
				if (@class.IRibbonItem_0 is IScalable && iconTextRelation > this.iconTextRelation_0)
				{
					this.iconTextRelation_0 = iconTextRelation;
				}
				this.int_0++;
			}
			return num;
		}

		internal void method_1(Class559[] class559_1)
		{
			for (int i = 0; i < class559_1.Length && class559_1[i] != null; i++)
			{
				this.class559_0[i] = class559_1[i];
			}
		}
	}
}
