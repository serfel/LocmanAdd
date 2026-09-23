using System.Collections.Generic;
using System.Runtime.CompilerServices;
using ns11;
using DocumentServer.DataSources;

namespace DocumentServer.DataShaping
{
	/// <summary>The SortingInstruction class contains merge block data sorting information such as the sort order and the column name to sort the data rows after.</summary>
	public class SortingInstruction
	{
		[CompilerGenerated]
		private string string_0;

		[CompilerGenerated]
		private SortOrder sortOrder_0;

		/// <summary>Gets or sets the table column name to order the data by.</summary>
		public string OrderBy
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

		/// <summary>Gets or sets the sort order (ascending / descending).</summary>
		public SortOrder SortOrder
		{
			[CompilerGenerated]
			get
			{
				return this.sortOrder_0;
			}
			[CompilerGenerated]
			set
			{
				this.sortOrder_0 = value;
			}
		}

		internal IComparer<object> IComparer_0 => SortingInstruction.smethod_0(this.SortOrder);

		internal static IEqualityComparer<object> IEqualityComparer_0 => new Class134();

		public SortingInstruction(string orderBy, SortOrder sortOrder)
		{
			this.OrderBy = orderBy;
			this.SortOrder = sortOrder;
		}

		/// <summary>Sets the column name to order the data by and sets the sort order to SortOrder.Ascending.</summary>
		/// <param name="orderBy">The name of the column to order the block data by.</param>
		public SortingInstruction(string orderBy)
			: this(orderBy, SortOrder.Ascending)
		{
		}

		internal SortingInstruction()
			: this("")
		{
		}

		private static IComparer<object> smethod_0(SortOrder sortOrder_1 = SortOrder.Ascending)
		{
			return new Class134(sortOrder_1);
		}

		internal object method_0(IDataRowAdapter idataRowAdapter_0)
		{
			return idataRowAdapter_0.GetFieldData(this.OrderBy) ?? "";
		}
	}
}
