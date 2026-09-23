using System;
using System.Collections;
using ns21;

namespace TXTextControl
{
	/// <summary>The TablePartCollection class is the base class of the TableRowCollection, TableColumnCollection and TableCellCollection classes.</summary>
	public abstract class TablePartCollection : ICollection, IEnumerable
	{
		public class TablePartEnumerator : IEnumerator
		{
			private int int_0;

			private int int_1;

			private int int_2;

			private TablePartCollection tablePartCollection_0;

			public object Current
			{
				get
				{
					if (this.int_0 >= 0)
					{
						switch (this.tablePartCollection_0.m_iType)
						{
						case Enum79.const_0:
							if (this.int_0 >= this.int_1)
							{
								return null;
							}
							return new TableRow(this.tablePartCollection_0.m_tx, this.tablePartCollection_0.m_iTextPart, this.tablePartCollection_0.m_iID, this.int_0 + 1);
						case Enum79.const_1:
							if (this.int_0 >= this.int_2)
							{
								return null;
							}
							return new TableColumn(this.tablePartCollection_0.m_tx, this.tablePartCollection_0.m_iTextPart, this.tablePartCollection_0.m_iID, this.int_0 + 1);
						case Enum79.const_2:
							if (this.int_0 >= this.int_1 * this.int_2)
							{
								return null;
							}
							return new TableCell(this.tablePartCollection_0.m_tx, this.tablePartCollection_0.m_iTextPart, this.tablePartCollection_0.m_iID, this.int_0 / this.int_2 + 1, this.int_0 % this.int_2 + 1);
						}
					}
					return null;
				}
			}

			public TablePartEnumerator(TablePartCollection tpc)
			{
				this.tablePartCollection_0 = tpc;
				this.int_0 = -1;
				short[] array = new short[2];
				short[] array2 = array;
				this.tablePartCollection_0.m_tx.method_43(this.tablePartCollection_0.m_iTextPart, 1266, this.tablePartCollection_0.m_iID, array2);
				this.int_1 = array2[0];
				this.int_2 = array2[1];
			}

			public bool MoveNext()
			{
				this.int_0++;
				return this.tablePartCollection_0.m_iType switch
				{
					Enum79.const_0 => this.int_0 < this.int_1, 
					Enum79.const_1 => this.int_0 < this.int_2, 
					Enum79.const_2 => this.int_0 < this.int_1 * this.int_2, 
					_ => false, 
				};
			}

			public void Reset()
			{
				this.int_0 = -1;
			}
		}

		internal TextControlCore m_tx;

		internal TextPart m_iTextPart;

		private Enum79 m_iType;

		protected int m_iID;

		int ICollection.Count => this.Count;

		/// <summary>Gets the number of elements contained in the collection.</summary>
		public int Count
		{
			get
			{
				short[] array = new short[2];
				short[] array2 = array;
				this.m_tx.method_43(this.m_iTextPart, 1266, this.m_iID, array2);
				return this.m_iType switch
				{
					Enum79.const_0 => array2[0], 
					Enum79.const_1 => array2[1], 
					Enum79.const_2 => array2[0] * array2[1], 
					_ => 0, 
				};
			}
		}

		bool ICollection.IsSynchronized => false;

		object ICollection.SyncRoot => this;

		internal TablePartCollection(TextControlCore textControlCore_0, TextPart iTextPart, int iID, Enum79 iType)
		{
			this.m_tx = textControlCore_0;
			this.m_iTextPart = iTextPart;
			this.m_iType = iType;
			this.m_iID = iID;
		}

		void ICollection.CopyTo(Array array, int index)
		{
			this.CopyTo(array, index);
		}

		public abstract void CopyTo(Array array, int index);

		/// <summary>Returns an enumerator that can be used to iterate through the collection.</summary>
		public TablePartEnumerator GetEnumerator()
		{
			return new TablePartEnumerator(this);
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return new TablePartEnumerator(this);
		}
	}
}
