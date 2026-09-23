using System;
using System.Linq;

namespace DocumentServer.DataSources
{
	internal static class IDataRowAdapterExtensions
	{
		public static object GetFieldData(this IDataRowAdapter row, string columnName)
		{
			if (row.Table.ColumnNames.Any((string string_0) => string_0.Equals(columnName, StringComparison.OrdinalIgnoreCase)))
			{
				return row[columnName];
			}
			if (columnName.IsChildColumnName())
			{
				return row.GetNestedChildColumnContent(columnName.ToChildTableNames(), columnName.ToChildColumnName());
			}
			return null;
		}

		public static object GetNestedChildColumnContent(this IDataRowAdapter dataRow, string[] childTableNames, string childColumnName)
		{
			if (childTableNames != null && childTableNames.Length != 0)
			{
				if (string.IsNullOrEmpty(childColumnName))
				{
					return null;
				}
				IDataRowAdapter[] childRows = dataRow.GetChildRows(childTableNames[0]);
				if (childRows.Length != 0)
				{
					IDataRowAdapter dataRowAdapter = childRows[0];
					for (int i = 1; i < childTableNames.Length; i++)
					{
						childRows = dataRowAdapter.GetChildRows(childTableNames[i]);
						if (childRows.Length != 0)
						{
							dataRowAdapter = childRows[0];
							continue;
						}
						dataRowAdapter = null;
						break;
					}
					if (dataRowAdapter != null)
					{
						object obj = dataRowAdapter[childColumnName];
						if (obj != null)
						{
							return obj;
						}
					}
				}
				return null;
			}
			return null;
		}
	}
}
