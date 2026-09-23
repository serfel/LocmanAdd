using System;
using System.Collections;
using System.Collections.Generic;
using DocumentServer.Properties;

namespace DocumentServer.DataSources
{
	/// <summary>An instance of the DataTableInfoCollection class contains all data tables in a data source represented through objects of the type DataTableInfo.</summary>
	public sealed class DataTableInfoCollection : ICollection<DataTableInfo>, IEnumerable<DataTableInfo>, IEnumerable
	{
		private List<DataTableInfo> list_0;

		public DataTableInfo this[string name]
		{
			get
			{
				List<DataTableInfo> list = new List<DataTableInfo>();
				foreach (DataTableInfo item in this.list_0)
				{
					if (name.Equals(item.TableName, StringComparison.OrdinalIgnoreCase))
					{
						list.Add(item);
					}
				}
				if (list.Count == 0)
				{
					return null;
				}
				if (list.Count != 1)
				{
					throw new Exception(Resources.EXC_DATASOURCEMGR_MULTIPLE_TABLES_SAME_NAME);
				}
				return list[0];
			}
		}

		public DataTableInfo this[int index] => this.list_0[index];

		/// <summary>Gets the number of elements contained in the collection.</summary>
		public int Count => this.list_0.Count;

		/// <summary>Gets a value indicating whether the collection is read only.</summary>
		public bool IsReadOnly => true;

		internal DataTableInfoCollection()
		{
			this.list_0 = new List<DataTableInfo>();
		}

		internal DataTableInfoCollection(IEnumerable<DataTableInfo> tables)
			: this()
		{
			this.list_0.AddRange(tables);
		}

		internal void method_0(DataTableInfo dataTableInfo_0)
		{
			this.list_0.Add(dataTableInfo_0);
		}

		internal void method_1()
		{
			this.list_0.Clear();
		}

		internal DataTableInfo[] method_2()
		{
			return this.list_0.ToArray();
		}

		internal bool method_3(DataTableInfo dataTableInfo_0)
		{
			foreach (DataTableInfo item in this.list_0)
			{
				if (item.Type_0 != null && dataTableInfo_0.Type_0 != null && item.Type_0 == dataTableInfo_0.Type_0 && item.TableName == dataTableInfo_0.TableName)
				{
					return true;
				}
			}
			return false;
		}

		public void Add(DataTableInfo item)
		{
			throw new NotSupportedException();
		}

		public void Clear()
		{
			throw new NotSupportedException();
		}

		public bool Contains(DataTableInfo item)
		{
			return this.list_0.Contains(item);
		}

		public bool Contains(string tableName)
		{
			foreach (DataTableInfo item in this.list_0)
			{
				if (tableName.ToLower() == item.TableName.ToLower())
				{
					return true;
				}
			}
			return false;
		}

		public void CopyTo(DataTableInfo[] array, int arrayIndex)
		{
			this.list_0.CopyTo(array, arrayIndex);
		}

		public bool Remove(DataTableInfo item)
		{
			throw new NotSupportedException();
		}

		/// <summary>Returns an enumerator that can be used to iterate through the collection.</summary>
		public IEnumerator<DataTableInfo> GetEnumerator()
		{
			return this.list_0.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.GetEnumerator();
		}
	}
}
