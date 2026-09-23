using System.ComponentModel;

namespace TXTextControl
{
	/// <summary>An instance of the TableColumn class represents a single column of a table in a Text Control document.</summary>
	public class TableColumn
	{
		private TextControlCore textControlCore_0;

		private TextPart textPart_0;

		private int int_0;

		private int int_1;

		private TableCellFormat tableCellFormat_0 = new TableCellFormat();

		/// <summary>Gets or sets the formatting attributes of a table column.</summary>
		[Browsable(false)]
		public TableCellFormat CellFormat
		{
			get
			{
				return this.tableCellFormat_0;
			}
			set
			{
				value.method_1(this.tableCellFormat_0);
				this.tableCellFormat_0.method_3();
			}
		}

		/// <summary>Gets the number of the table column represented through this table column object.</summary>
		[Browsable(false)]
		public int Column => this.int_1;

		/// <summary>Gets or sets, in twips, the horizontal position of the column.</summary>
		[Browsable(false)]
		public int Position
		{
			get
			{
				return this.tableCellFormat_0.Int32_1;
			}
			set
			{
				this.tableCellFormat_0.Int32_1 = value;
			}
		}

		/// <summary>Gets or sets, in twips, the width of the column.</summary>
		[Browsable(false)]
		public int Width
		{
			get
			{
				return this.tableCellFormat_0.Int32_2;
			}
			set
			{
				this.tableCellFormat_0.Int32_2 = value;
			}
		}

		internal TableColumn(TextControlCore textControlCore_1, TextPart iTextPart, int iID, int iColumn)
		{
			this.textControlCore_0 = textControlCore_1;
			this.textPart_0 = iTextPart;
			this.int_0 = iID;
			this.int_1 = iColumn;
			this.tableCellFormat_0.method_0(textControlCore_1, iTextPart, iID, 0, iColumn);
		}

		/// <summary>Selects the table column.</summary>
		public void Select()
		{
			short[] array = new short[2];
			short[] array2 = array;
			this.textControlCore_0.method_43(this.textPart_0, 1266, this.int_0, array2);
			int[] array3 = new int[4] { 1, this.int_1, 0, 0 };
			this.textControlCore_0.method_40(this.textPart_0, 1271, this.int_0, array3);
			int[] array4 = new int[4]
			{
				array2[0],
				this.int_1,
				0,
				0
			};
			this.textControlCore_0.method_40(this.textPart_0, 1271, this.int_0, array4);
			this.textControlCore_0.method_6(this.textPart_0, array3[2] - 1, 1 + array4[3] - array3[2]);
		}
	}
}
