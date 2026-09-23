using System;
using System.Collections.Generic;
using TXTextControl;

namespace ns21
{
	internal class Class393 : IComparer<ConditionalInstruction>
	{
		private int int_0;

		internal Class393(int int_1)
		{
			this.int_0 = int_1;
		}

		public int Compare(ConditionalInstruction x, ConditionalInstruction y)
		{
			int num2 = (y.Int32_0 = this.method_0(y));
			int num3 = num2;
			int num5 = (x.Int32_0 = this.method_0(x));
			int value = num5;
			return num3.CompareTo(value);
		}

		private int method_0(ConditionalInstruction conditionalInstruction_0)
		{
			int num = -1;
			List<int> list = null;
			Instruction[] instructions = conditionalInstruction_0.Instructions;
			foreach (Instruction instruction in instructions)
			{
				switch (instruction.InstructionType)
				{
				case Instruction.InstructionTypes.SetValue:
				{
					if (instruction.FormField.int_0 == this.int_0)
					{
						num = Math.Max(num, 99);
						break;
					}
					bool flag = false;
					Condition[] conditions = conditionalInstruction_0.Conditions;
					foreach (Condition condition in conditions)
					{
						if (condition.FormField.int_0 != this.int_0)
						{
							if (list == null)
							{
								list = this.method_1(conditionalInstruction_0.Instructions);
							}
							if (list.Contains(condition.FormField.int_0))
							{
								int num2 = this.method_2(condition);
								num = Math.Max(num, 60 + num2);
								flag = true;
								break;
							}
						}
					}
					if (!flag)
					{
						if (list == null)
						{
							list = this.method_1(conditionalInstruction_0.Instructions);
						}
						for (int k = 0; k < conditionalInstruction_0.Instructions.Length; k++)
						{
							if (conditionalInstruction_0.Instructions[k] != instruction && instruction.FormField.int_0 == conditionalInstruction_0.Instructions[k].FormField.int_0)
							{
								num = Math.Max(num, 60);
								flag = true;
								break;
							}
						}
					}
					if (!flag)
					{
						num = Math.Max(num, 50);
					}
					break;
				}
				case Instruction.InstructionTypes.SetItems:
					return 100;
				}
			}
			if (num == -1)
			{
				Condition[] conditions2 = conditionalInstruction_0.Conditions;
				foreach (Condition condition2 in conditions2)
				{
					if (list == null)
					{
						list = this.method_1(conditionalInstruction_0.Instructions);
					}
					int num3 = (list.Contains(condition2.FormField.int_0) ? 10 : 0);
					int num4 = this.method_2(condition2);
					num = Math.Max(num, num3 + num4);
				}
			}
			return num;
		}

		private List<int> method_1(Instruction[] instruction_0)
		{
			List<int> list = new List<int>();
			for (int i = 0; i < instruction_0.Length; i++)
			{
				int item = instruction_0[i].FormField.int_0;
				if (!list.Contains(item))
				{
					list.Add(item);
				}
			}
			return list;
		}

		private int method_2(Condition condition_0)
		{
			switch (condition_0.ComparisonOperator)
			{
			default:
				return -1;
			case Condition.ComparisonOperators.const_0:
				return 20;
			case Condition.ComparisonOperators.IsNot:
				return 15;
			case Condition.ComparisonOperators.Contains:
				return 17;
			case Condition.ComparisonOperators.StartsWith:
			case Condition.ComparisonOperators.EndsWith:
				return 16;
			case Condition.ComparisonOperators.DoesNotContain:
				return 14;
			case Condition.ComparisonOperators.DoesNotStartWith:
			case Condition.ComparisonOperators.DoesNotEndWith:
				return 13;
			case Condition.ComparisonOperators.IsGreaterThan:
			case Condition.ComparisonOperators.IsLessThan:
				return 18;
			case Condition.ComparisonOperators.IsGreaterThanOrEqual:
			case Condition.ComparisonOperators.IsLessThanOrEqual:
				return 19;
			}
		}
	}
}
