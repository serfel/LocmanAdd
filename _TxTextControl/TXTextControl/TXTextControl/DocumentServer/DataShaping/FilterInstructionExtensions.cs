using System.Collections.Generic;
using System.Linq;
using DocumentServer.DataSources;
using DocumentServer.Properties;

namespace DocumentServer.DataShaping
{
	internal static class FilterInstructionExtensions
	{
		public static bool Match(this FilterInstruction[] filters, IDataRowAdapter row)
		{
			if (filters.Length == 0)
			{
				return true;
			}
			if (filters.Length == 1)
			{
				return filters[0].method_0(row);
			}
			return filters.ToAndOrTree().Any((FilterInstruction[] andConnected) => andConnected.All((FilterInstruction filterInstruction_0) => filterInstruction_0.method_0(row)));
		}

		public static FilterInstruction[][] ToAndOrTree(this FilterInstruction[] filters)
		{
			List<FilterInstruction[]> list = new List<FilterInstruction[]>();
			List<FilterInstruction> list2 = new List<FilterInstruction>();
			foreach (FilterInstruction filterInstruction in filters)
			{
				switch (filterInstruction.LogicalOperator)
				{
				case LogicalOperator.const_1:
					list.Add(list2.ToArray());
					list2.Clear();
					list2.Add(filterInstruction);
					break;
				case LogicalOperator.And:
					list2.Add(filterInstruction);
					break;
				}
			}
			if (list2.Count > 0)
			{
				list.Add(list2.ToArray());
			}
			return list.ToArray();
		}

		public static string ToLocalizedString(this LogicalOperator logOp)
		{
			return logOp switch
			{
				LogicalOperator.const_1 => Resources.FILTERDESIGNER_LOG_OP_OR, 
				LogicalOperator.And => Resources.FILTERDESIGNER_LOG_OP_AND, 
				_ => "", 
			};
		}

		public static string ToLocalizedString(this RelationalOperator relOp)
		{
			return relOp switch
			{
				RelationalOperator.Equals => Resources.FILTERDESIGNER_REL_OP_EQUALS, 
				RelationalOperator.NotEqual => Resources.FILTERDESIGNER_REL_OP_NOT_EQUAL, 
				RelationalOperator.LessThan => Resources.FILTERDESIGNER_REL_OP_LESS_THAN, 
				RelationalOperator.GreaterThan => Resources.FILTERDESIGNER_REL_OP_GREATER_THAN, 
				RelationalOperator.GreaterThanOrEqualTo => Resources.FILTERDESIGNER_REL_OP_GREATER_THAN_OR_EQUAL, 
				RelationalOperator.LessThanOrEqualTo => Resources.FILTERDESIGNER_REL_OP_LESS_THAN_OR_EQUAL, 
				RelationalOperator.IsBlank => Resources.FILTERDESIGNER_REL_OP_IS_BLANK, 
				RelationalOperator.IsNotBlank => Resources.FILTERDESIGNER_REL_OP_IS_NOT_BLANK, 
				_ => "", 
			};
		}
	}
}
