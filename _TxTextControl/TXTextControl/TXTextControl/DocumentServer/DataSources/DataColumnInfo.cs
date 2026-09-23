using System;
using System.Data;
using System.Runtime.CompilerServices;

namespace DocumentServer.DataSources
{
	/// <summary>The DataColumnInfo class provides basic information about a table column in a data source.</summary>
	public class DataColumnInfo
	{
		[CompilerGenerated]
		private string string_0;

		[CompilerGenerated]
		private string string_1;

		[CompilerGenerated]
		private Type type_0;

		[CompilerGenerated]
		private DataTableInfo dataTableInfo_0;

		/// <summary>Gets a descriptive or friendly column name.</summary>
		public string Caption
		{
			[CompilerGenerated]
			get
			{
				return this.string_0;
			}
			[CompilerGenerated]
			internal set
			{
				this.string_0 = value;
			}
		}

		/// <summary>Gets the column name.</summary>
		public string ColumnName
		{
			[CompilerGenerated]
			get
			{
				return this.string_1;
			}
			[CompilerGenerated]
			internal set
			{
				this.string_1 = value;
			}
		}

		/// <summary>Gets the data type of this table column.</summary>
		public Type DataType
		{
			[CompilerGenerated]
			get
			{
				return this.type_0;
			}
			[CompilerGenerated]
			private set
			{
				this.type_0 = value;
			}
		}

		/// <summary>Gets an object of type DataTableInfo which represents the table this column belongs to.</summary>
		public DataTableInfo DataTableInfo
		{
			[CompilerGenerated]
			get
			{
				return this.dataTableInfo_0;
			}
			[CompilerGenerated]
			internal set
			{
				this.dataTableInfo_0 = value;
			}
		}

		internal DataColumnInfo(string columnName, Type dataType, DataTableInfo table)
		{
			this.DataTableInfo = table;
			this.Caption = (this.ColumnName = columnName);
			this.DataType = dataType;
		}

		internal DataColumnInfo(DataColumn column, DataTableInfo table)
		{
			this.ColumnName = column.ColumnName;
			this.Caption = column.Caption;
			this.DataType = column.DataType;
			this.DataTableInfo = table;
		}
	}
}
