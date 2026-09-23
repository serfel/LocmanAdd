using System;
using System.Collections;
using System.Collections.Generic;

namespace DocumentServer.DataSources
{
	/// <summary>An instance of the DataColumnInfoCollection class contains all data columns of a data table in a data source represented through objects of the type DataColumnInfo.</summary>
	public sealed class DataColumnInfoCollection : ICollection<DataColumnInfo>, IEnumerable<DataColumnInfo>, IEnumerable
	{
		private List<DataColumnInfo> list_0;

		public DataColumnInfo this[int index] => this.list_0[index];

		/// <summary>Gets the number of elements contained in the collection.</summary>
		public int Count => this.list_0.Count;

		/// <summary>Gets a value indicating whether the collection is read only.</summary>
		public bool IsReadOnly => true;

		internal DataColumnInfoCollection()
		{
			this.list_0 = new List<DataColumnInfo>();
		}

		internal void method_0(DataColumnInfo dataColumnInfo_0)
		{
			this.list_0.Add(dataColumnInfo_0);
		}

		internal void method_1()
		{
			this.list_0.Clear();
		}

		internal DataColumnInfo[] method_2()
		{
			return this.list_0.ToArray();
		}

		public void Add(DataColumnInfo item)
		{
			throw new NotSupportedException();
		}

		public void Clear()
		{
			throw new NotSupportedException();
		}

		public bool Contains(DataColumnInfo item)
		{
			return this.list_0.Contains(item);
		}

		public void CopyTo(DataColumnInfo[] array, int arrayIndex)
		{
			this.list_0.CopyTo(array, arrayIndex);
		}

		public bool Remove(DataColumnInfo item)
		{
			throw new NotSupportedException();
		}

		/// <summary>Returns an enumerator that can be used to iterate through the collection.</summary>
		public IEnumerator<DataColumnInfo> GetEnumerator()
		{
			return this.list_0.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.list_0.GetEnumerator();
		}
	}
}
