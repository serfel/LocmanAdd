namespace DocumentServer.DataSources
{
	/// <summary>Determines the type of repeating merge block which is inserted when using the DataSourceManager.InsertMergeBlock method.</summary>
	public enum BlockTemplateType
	{
		/// <summary>Insert a table row based repeating merge block.</summary>
		TableRow,
		/// <summary>Insert a paragraph based repeating merge block.</summary>
		PlainParagraph
	}
}
