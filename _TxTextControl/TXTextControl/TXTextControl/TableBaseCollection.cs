using System;
using System.Collections;
using ns21;

namespace TXTextControl
{
	/// <summary>The base class for table collections.</summary>
	public class TableBaseCollection : ICollection, IEnumerable
	{
		public class TableEnumerator : IEnumerator
		{
			private int int_0;

			private int int_1;

			private TableBaseCollection tableBaseCollection_0;

			public object Current => new Table(this.tableBaseCollection_0.textControlCore_0, this.tableBaseCollection_0.textPart_0, this.int_0, this.int_1);

			public TableEnumerator(TableBaseCollection tableBaseCollection_1)
			{
				this.tableBaseCollection_0 = tableBaseCollection_1;
			}

			public bool MoveNext()
			{
				int int_ = this.tableBaseCollection_0.textControlCore_0.method_29(this.tableBaseCollection_0.textPart_0, 1270, this.int_0, this.tableBaseCollection_0.int_0);
				this.int_0 = Class429.smethod_5(int_);
				this.int_1 = Class429.smethod_6(int_);
				return this.int_0 != 0;
			}

			public void Reset()
			{
				this.int_0 = 0;
			}
		}

		internal TextControlCore textControlCore_0;

		internal TextPart textPart_0;

		private int int_0;

		int ICollection.Count => this.Count;

		/// <summary>Gets the number of tables contained in the collection.</summary>
		public int Count
		{
			get
			{
				int num = -1;
				int num2 = 0;
				do
				{
					num++;
					num2 = Class429.smethod_5(this.textControlCore_0.method_29(this.textPart_0, 1270, num2, this.int_0));
				}
				while (num2 != 0);
				return num;
			}
		}

		bool ICollection.IsSynchronized => false;

		object ICollection.SyncRoot => this;

		public Table this[int number]
		{
			get
			{
				if (number > 0)
				{
					TableBaseCollection tableBaseCollection = new TableBaseCollection(this.textControlCore_0, this.int_0, this.textPart_0);
					foreach (Table item in tableBaseCollection)
					{
						if (number-- == 1)
						{
							return item;
						}
					}
				}
				return null;
			}
		}

		internal TableBaseCollection(TextControlCore textControlCore_1, int iOuterTableID, TextPart iTextPart)
		{
			this.textControlCore_0 = textControlCore_1;
			this.textPart_0 = iTextPart;
			this.int_0 = iOuterTableID;
		}

		/// <summary>Removes all tables contained in the collection from a Text Control document.</summary>
		public void Clear()
		{
			int num = 0;
			this.textControlCore_0.method_19(this.textPart_0, null);
			do
			{
				num = this.textControlCore_0.method_29(this.textPart_0, 1270, 0, this.int_0);
				if (num != 0)
				{
					Table table = new Table(this.textControlCore_0, this.textPart_0, Class429.smethod_5(num), Class429.smethod_6(num));
					table.method_1();
				}
			}
			while (num != 0);
			this.textControlCore_0.method_20(this.textPart_0);
		}

		void ICollection.CopyTo(Array array, int index)
		{
			this.CopyTo(array, index);
		}

		/// <summary>Copies the elements of the collection to an array, starting at a particular index.</summary>
		/// <param name="array">Specifies the array to copy to.</param>
		/// <param name="index">Specifies the index of the destination array at which to begin copying.</param>
		public void CopyTo(Array array, int index)
		{
			TableBaseCollection tableBaseCollection = new TableBaseCollection(this.textControlCore_0, this.int_0, this.textPart_0);
			foreach (Table item in tableBaseCollection)
			{
				array.SetValue(item, index++);
			}
		}

		/// <summary>Gets a particular table from the collection.</summary>
		/// <param name="id">Specifies the table's identifier.</param>
		public Table GetItem(int int_1)
		{
			TableBaseCollection tableBaseCollection = new TableBaseCollection(this.textControlCore_0, this.int_0, this.textPart_0);
			foreach (Table item in tableBaseCollection)
			{
				if (item.Int32_0 == int_1)
				{
					return item;
				}
			}
			return null;
		}

		/// <summary>Removes a particular table from the collection.</summary>
		/// <param name="id">Specifies the table's identifier.</param>
		public bool Remove(int int_1)
		{
			return this.GetItem(int_1)?.method_1() ?? false;
		}

		/// <summary>Returns an enumerator that can be used to iterate through the collection.</summary>
		public TableEnumerator GetEnumerator()
		{
			return new TableEnumerator(this);
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return new TableEnumerator(this);
		}
	}
}
