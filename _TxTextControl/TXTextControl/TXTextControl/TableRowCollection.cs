using System;
using ns21;

namespace TXTextControl
{
	/// <summary>An instance of the TableRowCollection class contains all rows of a table in a Text Control document represented through objects of the type TableRow.</summary>
	public sealed class TableRowCollection : TablePartCollection
	{
		/// <summary>Gets a value indicating whether a new row can be inserted at the current input position.</summary>
		public bool CanAdd => 0 != base.m_tx.method_29(base.m_iTextPart, 1259, 2, 0);

		/// <summary>Gets a value indicating whether selected rows can be removed.</summary>
		public bool CanRemove => 0 != base.m_tx.method_29(base.m_iTextPart, 1259, 3, 0);

		public TableRow this[int row] => this.GetItem(row);

		internal TableRowCollection(TextControlCore textControlCore_0, TextPart iTextPart, int iID)
			: base(textControlCore_0, iTextPart, iID, Enum79.const_0)
		{
		}

		/// <summary>Copies the elements of the collection to an array, starting at a particular index.</summary>
		/// <param name="array">Specifies the array to copy to.</param>
		/// <param name="index">Specifies the index of the destination array at which to begin copying.</param>
		public override void CopyTo(Array array, int index)
		{
			TableRowCollection tableRowCollection = new TableRowCollection(base.m_tx, base.m_iTextPart, base.m_iID);
			foreach (TableRow item in tableRowCollection)
			{
				array.SetValue(item, index++);
			}
		}

		/// <summary>Adds new table rows at the current text input position.</summary>
		/// <param name="position">Specifies the position where to add the rows.</param>
		/// <param name="count">Specifies the number of rows to add.</param>
		public bool Add(TableAddPosition position, int count)
		{
			return 0 != base.m_tx.method_29(base.m_iTextPart, 1257, (int)position, count);
		}

		/// <summary>Gets the table row at the current input position.</summary>
		public TableRow GetItem()
		{
			int[] array = new int[2];
			int[] array2 = array;
			int num = base.m_tx.method_40(base.m_iTextPart, 1275, 2, array2);
			if (num == base.m_iID && array2[0] != 0)
			{
				return new TableRow(base.m_tx, base.m_iTextPart, base.m_iID, array2[0]);
			}
			return null;
		}

		/// <summary>Gets the table row with the specified number.</summary>
		/// <param name="row">Specifies the row number.</param>
		public TableRow GetItem(int row)
		{
			short[] array = new short[2];
			short[] array2 = array;
			base.m_tx.method_43(base.m_iTextPart, 1266, base.m_iID, array2);
			if (row <= 0 || row > array2[0])
			{
				throw new ArgumentOutOfRangeException();
			}
			return new TableRow(base.m_tx, base.m_iTextPart, base.m_iID, row);
		}

		/// <summary>Removes the selected table rows or the row at the current text input position.</summary>
		public bool Remove()
		{
			return 0 != base.m_tx.method_29(base.m_iTextPart, 1258, 0, 0);
		}
	}
}
