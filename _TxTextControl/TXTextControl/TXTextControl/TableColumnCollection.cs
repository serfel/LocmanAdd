using System;
using ns21;

namespace TXTextControl
{
	/// <summary>Contains all columns of a table in a Text Control document</summary>
	public sealed class TableColumnCollection : TablePartCollection
	{
		/// <summary>Gets a value indicating whether a new column can be inserted at the current input position.</summary>
		public bool CanAdd => 0 != base.m_tx.method_29(base.m_iTextPart, 1259, 4, 0);

		/// <summary>Gets a value indicating whether table columns can be removed.</summary>
		public bool CanRemove => 0 != base.m_tx.method_29(base.m_iTextPart, 1259, 5, 0);

		public TableColumn this[int column] => this.GetItem(column);

		internal TableColumnCollection(TextControlCore textControlCore_0, TextPart iTextPart, int iID)
			: base(textControlCore_0, iTextPart, iID, Enum79.const_1)
		{
		}

		/// <summary>Copies the elements of the collection to an array, starting at a particular index.</summary>
		/// <param name="array">Specifies the array to copy to.</param>
		/// <param name="index">Specifies the index of the destination array at which to begin copying.</param>
		public override void CopyTo(Array array, int index)
		{
			TableColumnCollection tableColumnCollection = new TableColumnCollection(base.m_tx, base.m_iTextPart, base.m_iID);
			foreach (TableColumn item in tableColumnCollection)
			{
				array.SetValue(item, index++);
			}
		}

		/// <summary>Adds a new table column at the current text input position.</summary>
		/// <param name="position">Specifies the position where to add the column.</param>
		public bool Add(TableAddPosition position)
		{
			return 0 != base.m_tx.method_29(base.m_iTextPart, 1273, (int)position, 0);
		}

		/// <summary>Gets the table column at the current input position.</summary>
		public TableColumn GetItem()
		{
			int[] array = new int[2];
			int[] array2 = array;
			int num = base.m_tx.method_40(base.m_iTextPart, 1275, 2, array2);
			if (num == base.m_iID && array2[1] != 0)
			{
				return new TableColumn(base.m_tx, base.m_iTextPart, base.m_iID, array2[1]);
			}
			return null;
		}

		/// <summary>Gets the table column with the specified number.</summary>
		/// <param name="column">Specifies the column number.</param>
		public TableColumn GetItem(int column)
		{
			short[] array = new short[2];
			short[] array2 = array;
			base.m_tx.method_43(base.m_iTextPart, 1266, base.m_iID, array2);
			if (column <= 0 || column > array2[1])
			{
				throw new ArgumentOutOfRangeException();
			}
			return new TableColumn(base.m_tx, base.m_iTextPart, base.m_iID, column);
		}

		/// <summary>Removes the table column at the current text input position or all selected table columns when a text selection exists.</summary>
		public bool Remove()
		{
			return 0 != base.m_tx.method_29(base.m_iTextPart, 1274, 0, 0);
		}
	}
}
