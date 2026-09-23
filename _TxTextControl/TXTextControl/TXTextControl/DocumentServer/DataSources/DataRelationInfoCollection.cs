using System;
using System.Collections;
using System.Collections.Generic;

namespace DocumentServer.DataSources
{
	/// <summary>An instance of the DataRelationInfoCollection class contains all data relations in a data source represented through objects of the type DataRelationInfo.</summary>
	public sealed class DataRelationInfoCollection : ICollection<DataRelationInfo>, IEnumerable<DataRelationInfo>, IEnumerable
	{
		private List<DataRelationInfo> list_0;

		public DataRelationInfo this[int index] => this.list_0[index];

		/// <summary>Gets the number of elements contained in the collection.</summary>
		public int Count => this.list_0.Count;

		/// <summary>Gets a value indicating whether the collection is read only.</summary>
		public bool IsReadOnly => true;

		internal DataRelationInfoCollection()
		{
			this.list_0 = new List<DataRelationInfo>();
		}

		internal void method_0(DataRelationInfo dataRelationInfo_0)
		{
			this.list_0.Add(dataRelationInfo_0);
		}

		internal void method_1()
		{
			this.list_0.Clear();
		}

		public void Add(DataRelationInfo item)
		{
			throw new NotSupportedException();
		}

		public void Clear()
		{
			throw new NotSupportedException();
		}

		public bool Contains(DataRelationInfo item)
		{
			return this.list_0.Contains(item);
		}

		public void CopyTo(DataRelationInfo[] array, int arrayIndex)
		{
			this.list_0.CopyTo(array, arrayIndex);
		}

		public bool Remove(DataRelationInfo item)
		{
			throw new NotSupportedException();
		}

		/// <summary>Returns an enumerator that can be used to iterate through the collection.</summary>
		public IEnumerator<DataRelationInfo> GetEnumerator()
		{
			return this.list_0.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.list_0.GetEnumerator();
		}
	}
}
