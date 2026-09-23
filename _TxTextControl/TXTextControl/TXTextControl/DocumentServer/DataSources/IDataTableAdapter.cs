namespace DocumentServer.DataSources
{
	/// <summary>The IDataTableAdapter interface contains properties and methods implemented by data table instances used in the BlockMerging event.</summary>
	public interface IDataTableAdapter
	{
		/// <summary>Returns the name of the table.</summary>
		string TableName { get; }

		/// <summary>Returns the table's column names as a string array.</summary>
		string[] ColumnNames { get; }

		/// <summary>Returns the table's data as an array of objects implementing the IDataRowAdapter interface.</summary>
		IDataRowAdapter[] Rows { get; }

		/// <summary>Returns the names of the child relations in this table as a string array.</summary>
		string[] ChildTableNames { get; }
	}
}
