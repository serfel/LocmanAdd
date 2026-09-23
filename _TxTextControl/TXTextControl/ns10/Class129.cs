using System.Collections.Generic;
using System.Data;
using System.Linq;
using DocumentServer.DataSources;

namespace ns10
{
	internal class Class129 : IDataRowAdapter
	{
		private DataRow dataRow_0;

		private Class130 class130_0;

		private Dictionary<string, List<IDataRowAdapter>> dictionary_0 = new Dictionary<string, List<IDataRowAdapter>>();

		private Dictionary<string, Class130> dictionary_1 = new Dictionary<string, Class130>();

		public object this[string key]
		{
			get
			{
				if (this.dataRow_0 != null && this.dataRow_0.Table.Columns.Contains(key))
				{
					return this.dataRow_0[key] ?? "";
				}
				return "";
			}
		}

		public IDataTableAdapter Table => this.class130_0;

		public Class129(DataRow dataRow_1, Class130 class130_1)
		{
			this.dataRow_0 = dataRow_1;
			this.class130_0 = class130_1;
		}

		public IDataRowAdapter[] GetChildRows(string tableName)
		{
			tableName = tableName.ToLower();
			if (this.dictionary_0.ContainsKey(tableName))
			{
				return this.dictionary_0[tableName].ToArray();
			}
			if (this.dataRow_0 != null)
			{
				this.dictionary_0.Add(tableName, new List<IDataRowAdapter>());
				List<IDataRowAdapter> list = this.dictionary_0[tableName];
				if (this.class130_0.ChildTableNames.Contains(tableName))
				{
					DataRelation dataRelation = this.method_0(tableName);
					if (dataRelation != null)
					{
						DataRow[] childRows = this.dataRow_0.GetChildRows(dataRelation);
						Class130 class130_ = this.method_1(dataRelation);
						DataRow[] array = childRows;
						foreach (DataRow dataRow_ in array)
						{
							list.Add(new Class129(dataRow_, class130_));
						}
					}
				}
				return list.ToArray();
			}
			return new IDataRowAdapter[0];
		}

		private DataRelation method_0(string string_0)
		{
			foreach (DataRelation childRelation in this.class130_0.DataTable_0.ChildRelations)
			{
				if (!(childRelation.ChildTable.TableName.ToLower() != string_0.ToLower()))
				{
					return childRelation;
				}
			}
			return null;
		}

		private Class130 method_1(DataRelation dataRelation_0)
		{
			string key = dataRelation_0.ChildTable.TableName.ToLower();
			if (this.dictionary_1.ContainsKey(key))
			{
				return this.dictionary_1[key];
			}
			Class130 @class = new Class130(dataRelation_0.ChildTable);
			this.dictionary_1.Add(key, @class);
			return @class;
		}
	}
}
