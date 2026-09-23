using System.ComponentModel;
using TXTextControl;
using TXTextControl.Windows.Forms;

namespace ns26
{
	internal class Class458 : Class457
	{
		internal override Row vmethod_0(IConditionalInstructionElement iconditionalInstructionElement_0)
		{
			return new Class460(this, iconditionalInstructionElement_0 as Condition);
		}

		protected override void vmethod_2()
		{
			base.vmethod_2();
			this.method_11();
		}

		protected override void vmethod_1(object sender, PropertyChangedEventArgs e)
		{
			base.vmethod_1(sender, e);
			if (e.PropertyName == "IsValidCondition")
			{
				base.method_9(sender as Class460);
			}
			else if (e.PropertyName == "LogicalConnective")
			{
				this.method_11();
			}
		}

		private void method_11()
		{
			bool flag = false;
			if (base.List_1.Count <= 0)
			{
				return;
			}
			(base.List_1[0] as Class460).Condition_0.Boolean_1 = true;
			for (int i = 0; i < base.List_1.Count; i++)
			{
				Class460 @class = base.List_1[i] as Class460;
				@class.Boolean_0 = false;
				@class.Boolean_1 = false;
				if (!flag)
				{
					if (!@class.Condition_0.Boolean_1 && @class.Condition_0.LogicalConnective == Condition.LogicalConnectives.And)
					{
						(base.List_1[i - 1] as Class460).Boolean_0 = true;
						flag = true;
					}
				}
				else if (flag && @class.Condition_0.LogicalConnective == Condition.LogicalConnectives.const_1)
				{
					(base.List_1[i - 1] as Class460).Boolean_1 = true;
					flag = false;
				}
				if (flag && i == base.List_1.Count - 1)
				{
					@class.Boolean_1 = true;
					flag = false;
				}
			}
		}
	}
}
