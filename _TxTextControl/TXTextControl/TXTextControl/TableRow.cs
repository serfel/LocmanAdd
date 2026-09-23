using System.ComponentModel;

namespace TXTextControl
{
	/// <summary>Represents a single row of a table in a Text Control document.</summary>
	public class TableRow
	{
		private TextControlCore textControlCore_0;

		private TextPart textPart_0;

		private int int_0;

		private int int_1;

		private TableCellFormat tableCellFormat_0 = new TableCellFormat();

		/// <summary>Gets or sets a value specifying how the table row is formatted at page breaks.</summary>
		[Browsable(false)]
		public bool AllowPageBreak
		{
			get
			{
				return this.tableCellFormat_0.Boolean_0;
			}
			set
			{
				this.tableCellFormat_0.Boolean_0 = value;
			}
		}

		/// <summary>Gets or sets the formatting attributes of a table row.</summary>
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

		/// <summary>Gets or sets a value specifying whether the table row is part of the table's header.</summary>
		[Browsable(false)]
		public bool IsHeader
		{
			get
			{
				return this.tableCellFormat_0.Boolean_1;
			}
			set
			{
				this.tableCellFormat_0.Boolean_1 = value;
			}
		}

		/// <summary>Gets or sets the minimum height, in twips, of the table row.</summary>
		[Browsable(false)]
		public int MinimumHeight
		{
			get
			{
				return this.tableCellFormat_0.Int32_0;
			}
			set
			{
				this.tableCellFormat_0.Int32_0 = value;
			}
		}

		/// <summary>Gets the number of the table row represented through this table row object.</summary>
		[Browsable(false)]
		public int Row => this.int_1;

		internal TableRow(TextControlCore textControlCore_1, TextPart iTextPart, int iID, int iRow)
		{
			this.textControlCore_0 = textControlCore_1;
			this.textPart_0 = iTextPart;
			this.int_0 = iID;
			this.int_1 = iRow;
			this.tableCellFormat_0.method_0(textControlCore_1, iTextPart, iID, iRow, 0);
		}

		/// <summary>Selects the table row.</summary>
		public void Select()
		{
			short[] array = new short[2];
			short[] array2 = array;
			this.textControlCore_0.method_43(this.textPart_0, 1266, this.int_0, array2);
			int[] array3 = new int[4] { this.int_1, 1, 0, 0 };
			this.textControlCore_0.method_40(this.textPart_0, 1271, this.int_0, array3);
			int[] array4 = new int[4]
			{
				this.int_1,
				array2[1],
				0,
				0
			};
			this.textControlCore_0.method_40(this.textPart_0, 1271, this.int_0, array4);
			this.textControlCore_0.method_5(this.textPart_0, array3[2] - 1, 2 + array4[3] - array3[2]);
		}
	}
}
