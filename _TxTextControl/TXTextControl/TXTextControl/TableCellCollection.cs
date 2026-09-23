using System;
using ns21;

namespace TXTextControl
{
	/// <summary>An instance of the TableCellCollection class contains all cells of a table in a Text Control document represented through TableCell objects.</summary>
	public sealed class TableCellCollection : TablePartCollection
	{
		/// <summary>Gets a value indicating whether table cells can be removed.</summary>
		public bool CanRemove => 0 != base.m_tx.method_29(base.m_iTextPart, 1259, 5, 0);

		public TableCell this[int row, int column] => this.GetItem(row, column);

		internal TableCellCollection(TextControlCore textControlCore_0, TextPart iTextPart, int iID)
			: base(textControlCore_0, iTextPart, iID, Enum79.const_2)
		{
		}

		/// <summary>Copies the elements of the collection to an array, starting at a particular index.</summary>
		/// <param name="array">Specifies the array to copy to.</param>
		/// <param name="index">Specifies the index of the destination array at which to begin copying.</param>
		public override void CopyTo(Array array, int index)
		{
			TableCellCollection tableCellCollection = new TableCellCollection(base.m_tx, base.m_iTextPart, base.m_iID);
			foreach (TableCell item in tableCellCollection)
			{
				array.SetValue(item, index++);
			}
		}

		/// <summary>Gets the table cell at the current input position.</summary>
		public TableCell GetItem()
		{
			int[] array = new int[2];
			int[] array2 = array;
			int num = base.m_tx.method_40(base.m_iTextPart, 1275, 2, array2);
			if (num == base.m_iID && array2[0] != 0 && array2[1] != 0)
			{
				return new TableCell(base.m_tx, base.m_iTextPart, base.m_iID, array2[0], array2[1]);
			}
			return null;
		}

		/// <summary>Gets the cell with the specified row and column number.</summary>
		/// <param name="row">Specifies the row number.</param>
		/// <param name="column">Specifies the column number.</param>
		public TableCell GetItem(int row, int column)
		{
			short[] array = new short[2];
			short[] array2 = array;
			base.m_tx.method_43(base.m_iTextPart, 1266, base.m_iID, array2);
			if (row <= 0 || row > array2[0] || column <= 0 || column > array2[1])
			{
				throw new ArgumentOutOfRangeException();
			}
			return new TableCell(base.m_tx, base.m_iTextPart, base.m_iID, row, column);
		}

		/// <summary>Removes the table cell at the current text input position or all selected table cells when a text selection exists.</summary>
		public bool Remove()
		{
			return 0 != base.m_tx.method_29(base.m_iTextPart, 1274, 1, 0);
		}
	}
}
