using System.Collections.Generic;
using System.Data;
using DocumentServer.DataSources;

namespace ns10
{
	internal class Class130 : IDataTableAdapter
	{
		private DataTable dataTable_0;

		private List<string> list_0 = new List<string>();

		private List<IDataRowAdapter> list_1 = new List<IDataRowAdapter>();

		private List<string> list_2 = new List<string>();

		public string TableName
		{
			get
			{
				if (this.dataTable_0 != null)
				{
					return this.dataTable_0.TableName;
				}
				return "";
			}
		}

		public string[] ColumnNames
		{
			get
			{
				if (this.list_0.Count == 0 && this.dataTable_0 != null)
				{
					foreach (DataColumn column in this.dataTable_0.Columns)
					{
						this.list_0.Add(column.ColumnName.ToLower());
					}
				}
				return this.list_0.ToArray();
			}
		}

		public IDataRowAdapter[] Rows
		{
			get
			{
				if (this.list_1.Count == 0 && this.dataTable_0 != null)
				{
					foreach (DataRow row in this.dataTable_0.Rows)
					{
						this.list_1.Add(new Class129(row, this));
					}
				}
				return this.list_1.ToArray();
			}
		}

		public string[] ChildTableNames
		{
			get
			{
				if (this.list_2.Count == 0 && this.dataTable_0 != null)
				{
					foreach (DataRelation childRelation in this.dataTable_0.ChildRelations)
					{
						this.list_2.Add(childRelation.ChildTable.TableName.ToLower());
					}
				}
				return this.list_2.ToArray();
			}
		}

		internal DataTable DataTable_0 => this.dataTable_0;

		public Class130(DataTable dataTable_1)
		{
			this.dataTable_0 = dataTable_1;
		}
	}
}
