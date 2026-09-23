using System.Collections.Generic;
using System.Data;
using ns4;

namespace DocumentServer.DataBaseConnection
{
	internal abstract class DbConnectionAdapter
	{
		protected Class98 m_selectedTable;

		protected List<string> m_tableNames;

		protected List<string> m_viewNames;

		internal Class98 SelectedTable => this.m_selectedTable;

		internal List<string> TableNames => this.m_tableNames;

		internal List<string> ViewNames => this.m_viewNames;

		internal abstract List<DataRelation> DataRelations { get; }

		internal abstract bool IsConnected { get; }

		internal abstract DataTable GetTable(string strTable);

		internal abstract void SelectTable(string strTableName);

		internal abstract void Close();

		internal abstract void GetTableAndViewNames();

		internal abstract DataSet GetDataSet(List<string> tableNames);

		internal abstract DataSet GetDataSet();

		internal abstract bool AddDataRelation(string mainTableName, string mainColName, string childTableName, string childColName);

		internal abstract bool AddDataRelation(string relationName, string mainTableName, string mainColName, string childTableName, string childColName);

		internal abstract bool RemoveDataRelation(string name);
	}
}
