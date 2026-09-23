namespace DocumentServer.DataSources
{
	/// <summary>The IDataRowAdapter interface contains properties and methods implemented by data row instances used in the BlockMerging event.</summary>
	public interface IDataRowAdapter
	{
		object this[string key] { get; }

		/// <summary>Gets the table the data row belongs to as an instance of a class implementing the IDataTableAdapter interface.</summary>
		IDataTableAdapter Table { get; }

		/// <summary>Returns the data of a child relation with a given name as an array of IDataRowAdapter instances.</summary>
		/// <param name="childTableName">The name of the child table / the child relation.</param>
		IDataRowAdapter[] GetChildRows(string childTableName);
	}
}
