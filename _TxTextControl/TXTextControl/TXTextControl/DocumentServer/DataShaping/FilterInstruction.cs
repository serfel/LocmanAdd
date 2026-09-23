using System;
using System.Runtime.CompilerServices;
using ns11;
using DocumentServer.DataSources;

namespace DocumentServer.DataShaping
{
	/// <summary>The FilterInstruction class is used to filter merge block data by certain conditions before merging.</summary>
	public class FilterInstruction
	{
		[CompilerGenerated]
		private string string_0;

		[CompilerGenerated]
		private RelationalOperator relationalOperator_0;

		[CompilerGenerated]
		private object object_0;

		[CompilerGenerated]
		private LogicalOperator logicalOperator_0;

		/// <summary>Gets or sets the name of the table column whose content this merge condition is compared to.</summary>
		public string ColumnName
		{
			[CompilerGenerated]
			get
			{
				return this.string_0;
			}
			[CompilerGenerated]
			set
			{
				this.string_0 = value;
			}
		}

		/// <summary>Gets or sets the relational operator used as the comparison operator.</summary>
		public RelationalOperator ComparisonOperator
		{
			[CompilerGenerated]
			get
			{
				return this.relationalOperator_0;
			}
			[CompilerGenerated]
			set
			{
				this.relationalOperator_0 = value;
			}
		}

		/// <summary>Gets or sets the value the table column content is compared to using the specified comparison operator.</summary>
		public object CompareTo
		{
			[CompilerGenerated]
			get
			{
				return this.object_0;
			}
			[CompilerGenerated]
			set
			{
				this.object_0 = value;
			}
		}

		/// <summary>Gets or sets the logical operator by which to logically connect a filter instruction to the previous one if a filter consists of a collection of multiple filter instructions.</summary>
		public LogicalOperator LogicalOperator
		{
			[CompilerGenerated]
			get
			{
				return this.logicalOperator_0;
			}
			[CompilerGenerated]
			set
			{
				this.logicalOperator_0 = value;
			}
		}

		public FilterInstruction(string columnName, RelationalOperator comparisonOperator, object compareTo, LogicalOperator logicalOperator)
		{
			this.ColumnName = columnName;
			this.ComparisonOperator = comparisonOperator;
			this.CompareTo = compareTo;
			this.LogicalOperator = logicalOperator;
		}

		public FilterInstruction(string columnName, RelationalOperator comparisonOperator, object compareTo)
			: this(columnName, comparisonOperator, compareTo, LogicalOperator.And)
		{
		}

		public FilterInstruction(string columnName, RelationalOperator comparisonOperator)
			: this(columnName, comparisonOperator, "", LogicalOperator.And)
		{
		}

		internal FilterInstruction()
			: this("", RelationalOperator.Equals)
		{
		}

		internal bool method_0(IDataRowAdapter idataRowAdapter_0)
		{
			object fieldData = idataRowAdapter_0.GetFieldData(this.ColumnName);
			if (fieldData == null)
			{
				return true;
			}
			return this.ComparisonOperator switch
			{
				RelationalOperator.Equals => this.method_1(fieldData), 
				RelationalOperator.NotEqual => this.method_2(fieldData), 
				RelationalOperator.LessThan => this.method_3(fieldData), 
				RelationalOperator.GreaterThan => this.method_4(fieldData), 
				RelationalOperator.GreaterThanOrEqualTo => this.method_5(fieldData), 
				RelationalOperator.LessThanOrEqualTo => this.method_6(fieldData), 
				RelationalOperator.IsBlank => this.method_7(fieldData), 
				RelationalOperator.IsNotBlank => this.method_8(fieldData), 
				_ => false, 
			};
		}

		private bool method_1(object object_1)
		{
			return FilterInstruction.smethod_0(object_1, this.CompareTo, (double fValue, double fCompareTo) => fValue == fCompareTo, (string strValue, string strCompareTo) => strValue.CompareTo(strCompareTo) == 0);
		}

		private bool method_2(object object_1)
		{
			return FilterInstruction.smethod_0(object_1, this.CompareTo, (double fValue, double fCompareTo) => fValue != fCompareTo, (string strValue, string strCompareTo) => strValue.CompareTo(strCompareTo) != 0);
		}

		private bool method_3(object object_1)
		{
			return FilterInstruction.smethod_0(object_1, this.CompareTo, (double fValue, double fCompareTo) => fValue < fCompareTo, (string strValue, string strCompareTo) => strValue.CompareTo(strCompareTo) < 0);
		}

		private bool method_4(object object_1)
		{
			return FilterInstruction.smethod_0(object_1, this.CompareTo, (double fValue, double fCompareTo) => fValue > fCompareTo, (string strValue, string strCompareTo) => strValue.CompareTo(strCompareTo) > 0);
		}

		private bool method_5(object object_1)
		{
			return FilterInstruction.smethod_0(object_1, this.CompareTo, (double fValue, double fCompareTo) => fValue >= fCompareTo, (string strValue, string strCompareTo) => strValue.CompareTo(strCompareTo) >= 0);
		}

		private bool method_6(object object_1)
		{
			return FilterInstruction.smethod_0(object_1, this.CompareTo, (double fValue, double fCompareTo) => fValue <= fCompareTo, (string strValue, string strCompareTo) => strValue.CompareTo(strCompareTo) <= 0);
		}

		private bool method_7(object object_1)
		{
			if (object_1 == null)
			{
				return true;
			}
			return string.IsNullOrEmpty(object_1.ToString());
		}

		private bool method_8(object object_1)
		{
			if (object_1 == null)
			{
				return false;
			}
			return !string.IsNullOrEmpty(object_1.ToString());
		}

		private static bool smethod_0(object object_1, object object_2, Func<double, double, bool> func_0, Func<string, string, bool> func_1)
		{
			if (object_2 != null && object_1 != null)
			{
				if (func_0 != null && Class134.smethod_1(object_1, out var double_) && Class134.smethod_1(object_2, out var double_2))
				{
					return func_0(double_, double_2);
				}
				if (func_1 != null)
				{
					Class134.smethod_3(object_1, out var arg);
					Class134.smethod_3(object_2, out var arg2);
					return func_1(arg, arg2);
				}
				return false;
			}
			return false;
		}
	}
}
