using System;
using System.ComponentModel;
using ns21;

namespace TXTextControl
{
	/// <summary>An instance of the Table class represents a table in a Text Control document.</summary>
	public class Table
	{
		private TextControlCore textControlCore_0;

		private TextPart textPart_0;

		private int int_0;

		private int int_1;

		/// <summary>Checks whether table cells can be merged.</summary>
		public bool CanMergeCells
		{
			get
			{
				int[] array = new int[2];
				int[] int_ = array;
				int num = this.textControlCore_0.method_40(this.textPart_0, 1275, 2, int_);
				if (this.int_0 == num)
				{
					return this.textControlCore_0.method_29(this.textPart_0, 1259, 8, 0) != 0;
				}
				return false;
			}
		}

		/// <summary>Checks whether this table can be split.</summary>
		public bool CanSplit
		{
			get
			{
				int[] array = new int[2];
				int[] int_ = array;
				int num = this.textControlCore_0.method_40(this.textPart_0, 1275, 2, int_);
				if (this.int_0 == num)
				{
					return this.textControlCore_0.method_29(this.textPart_0, 1259, 7, 0) != 0;
				}
				return false;
			}
		}

		/// <summary>Checks whether previously merged table cells in this table can be split.</summary>
		public bool CanSplitCells
		{
			get
			{
				int[] array = new int[2];
				int[] int_ = array;
				int num = this.textControlCore_0.method_40(this.textPart_0, 1275, 2, int_);
				if (this.int_0 == num)
				{
					return this.textControlCore_0.method_29(this.textPart_0, 1259, 9, 0) != 0;
				}
				return false;
			}
		}

		/// <summary>Gets a collection of all table cells the table consists of.</summary>
		[Browsable(false)]
		public TableCellCollection Cells
		{
			get
			{
				if (this.textControlCore_0 == null)
				{
					return null;
				}
				return new TableCellCollection(this.textControlCore_0, this.textPart_0, this.Int32_2);
			}
		}

		/// <summary>Gets a collection of all columns the table consists of.</summary>
		[Browsable(false)]
		public TableColumnCollection Columns
		{
			get
			{
				if (this.textControlCore_0 == null)
				{
					return null;
				}
				return new TableColumnCollection(this.textControlCore_0, this.textPart_0, this.Int32_2);
			}
		}

		[Browsable(false)]
		public int Int32_0
		{
			get
			{
				if (this.int_1 == 0)
				{
					if (this.textControlCore_0 != null)
					{
						return this.textControlCore_0.method_29(this.textPart_0, 1276, this.int_0, 0);
					}
					return 0;
				}
				return this.int_1;
			}
			set
			{
				if (value >= 10 && value <= 32767)
				{
					if (this.textControlCore_0 != null)
					{
						this.textControlCore_0.method_29(this.textPart_0, 1263, this.Int32_2, value);
					}
					this.int_1 = value;
					return;
				}
				throw new ArgumentOutOfRangeException();
			}
		}

		/// <summary>Gets the nested level for the specified table.</summary>
		[Browsable(false)]
		public int NestedLevel => this.textControlCore_0.method_29(this.textPart_0, 1278, this.Int32_2, 0);

		/// <summary>Gets a collection of all tables nested in this table.</summary>
		[Browsable(false)]
		public TableBaseCollection NestedTables
		{
			get
			{
				if (this.textControlCore_0 != null && this.int_0 != 0)
				{
					return new TableBaseCollection(this.textControlCore_0, this.int_0, this.textPart_0);
				}
				return null;
			}
		}

		/// <summary>Gets a table's outermost table.</summary>
		[Browsable(false)]
		public Table OuterMostTable
		{
			get
			{
				if (this.textControlCore_0 != null)
				{
					int num = this.textControlCore_0.method_29(this.textPart_0, 1279, this.int_0, 0);
					if (num != 0)
					{
						return new Table(this.textControlCore_0, this.textPart_0, Class429.smethod_5(num), Class429.smethod_6(num));
					}
				}
				return null;
			}
		}

		/// <summary>Gets a table's outer table.</summary>
		[Browsable(false)]
		public Table OuterTable
		{
			get
			{
				if (this.textControlCore_0 != null)
				{
					int num = this.textControlCore_0.method_29(this.textPart_0, 1279, this.int_0, 1);
					if (num != 0)
					{
						return new Table(this.textControlCore_0, this.textPart_0, Class429.smethod_5(num), Class429.smethod_6(num));
					}
				}
				return null;
			}
		}

		/// <summary>Gets a collection of all rows the table consists of.</summary>
		[Browsable(false)]
		public TableRowCollection Rows
		{
			get
			{
				if (this.textControlCore_0 == null)
				{
					return null;
				}
				return new TableRowCollection(this.textControlCore_0, this.textPart_0, this.Int32_2);
			}
		}

		internal int Int32_1 => this.int_0;

		private int Int32_2
		{
			get
			{
				if (this.int_0 == 0)
				{
					return this.int_1;
				}
				return this.int_0;
			}
		}

		internal Table(TextControlCore textControlCore_1, TextPart iTextPart, int iTableID, int iUserID)
		{
			this.textControlCore_0 = textControlCore_1;
			this.int_0 = iTableID;
			this.textPart_0 = iTextPart;
			this.int_1 = iUserID;
		}

		/// <summary>Merges all selected table cells in this table. The Table.CanMergeCells property can be used to determine, if table cells can be merged or not.</summary>
		public bool MergeCells()
		{
			if (this.CanMergeCells)
			{
				return 0 != this.textControlCore_0.method_29(this.textPart_0, 1283, 0, 0);
			}
			return false;
		}

		/// <summary>Selects the complete table.</summary>
		public void Select()
		{
			int[] array = new int[4];
			int[] int_ = array;
			this.textControlCore_0.method_40(this.textPart_0, 1957, this.Int32_2, int_);
		}

		/// <summary>Selects the part of the table defined through two table cells.</summary>
		/// <param name="startRow">Specifies the row number where the selection begins.</param>
		/// <param name="startColumn">Specifies the column number where the selection begins.</param>
		/// <param name="stopRow">Specifies the row number where the selection ends.</param>
		/// <param name="stopColumn">Specifies the column number where the selection ends.</param>
		public void Select(int startRow, int startColumn, int stopRow, int stopColumn)
		{
			int[] int_ = new int[4]
			{
				Math.Min(startRow, stopRow),
				Math.Min(startColumn, stopColumn),
				Math.Max(startRow, stopRow),
				Math.Max(startColumn, stopColumn)
			};
			this.textControlCore_0.method_40(this.textPart_0, 1957, this.Int32_2, int_);
		}

		/// <summary>Splits a table below or above the current input position. If the table does not contain the current input position it cannot be split. The Table.CanSplit property can be used to determine if a table can be split or not. If a table is split above the first row a new line is inserted above the table and if a table is split below the last row a new line is inserted below the table. This is useful to insert text above or below a nested table that immediately starts and/or ends at the beginning or the end of the cell in which it is nested.</summary>
		/// <param name="position">Specifies the position where to split the table.</param>
		public bool Split(TableAddPosition position)
		{
			if (this.CanSplit)
			{
				return 0 != this.textControlCore_0.method_29(this.textPart_0, 1277, (int)position, 0);
			}
			return false;
		}

		/// <summary>Splits all selected table cells in this table. Only previously merged cells can be split. The Table.CanSplitCells property can be used to determine, if table cells can be split or not.</summary>
		public bool SplitCells()
		{
			if (this.CanSplitCells)
			{
				return 0 != this.textControlCore_0.method_29(this.textPart_0, 1283, 1, 0);
			}
			return false;
		}

		private void method_0(out int int_2, out int int_3)
		{
			short[] array = new short[2];
			short[] array2 = array;
			this.textControlCore_0.method_43(this.textPart_0, 1266, this.Int32_2, array2);
			int[] array3 = new int[4] { 1, 1, 0, 0 };
			this.textControlCore_0.method_40(this.textPart_0, 1271, this.Int32_2, array3);
			int[] array4 = new int[4]
			{
				array2[0],
				array2[1],
				0,
				0
			};
			this.textControlCore_0.method_40(this.textPart_0, 1271, this.Int32_2, array4);
			int_2 = array3[2] - 1;
			int_3 = 2 + array4[3] - array3[2];
		}

		internal bool method_1()
		{
			this.textControlCore_0.method_10(bool_1: true);
			this.textControlCore_0.method_30(Enum83.const_152, 1, 0);
			this.Select();
			this.textControlCore_0.method_30(Enum83.const_152, 0, 0);
			bool result = this.textControlCore_0.method_29(this.textPart_0, 1258, 0, 0) != 0;
			this.textControlCore_0.method_10(bool_1: false);
			return result;
		}
	}
}
