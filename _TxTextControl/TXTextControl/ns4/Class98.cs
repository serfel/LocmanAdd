using System.Collections.Generic;
using System.Data;
using System.Runtime.CompilerServices;

namespace ns4
{
	internal class Class98
	{
		[CompilerGenerated]
		private DataTable dataTable_0;

		[CompilerGenerated]
		private List<string> list_0;

		public DataTable DataTable_0
		{
			[CompilerGenerated]
			get
			{
				return this.dataTable_0;
			}
			[CompilerGenerated]
			private set
			{
				this.dataTable_0 = value;
			}
		}

		public int Int32_0
		{
			get
			{
				if (this.DataTable_0 == null)
				{
					return 0;
				}
				return this.DataTable_0.Rows.Count;
			}
		}

		public List<string> List_0
		{
			[CompilerGenerated]
			get
			{
				return this.list_0;
			}
			[CompilerGenerated]
			private set
			{
				this.list_0 = value;
			}
		}

		public string String_0
		{
			get
			{
				if (this.DataTable_0 == null)
				{
					return string.Empty;
				}
				return this.DataTable_0.TableName;
			}
		}

		public Class98(DataTable dataTable_1)
		{
			this.DataTable_0 = dataTable_1;
			this.List_0 = new List<string>();
			if (dataTable_1 == null)
			{
				return;
			}
			foreach (DataColumn column in this.DataTable_0.Columns)
			{
				this.List_0.Add(column.ColumnName);
			}
		}
	}
}
