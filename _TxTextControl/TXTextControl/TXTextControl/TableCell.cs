using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using ns21;

namespace TXTextControl
{
	/// <summary>Represents a single cell of a table in a Text Control document.</summary>
	public class TableCell
	{
		private TextControlCore textControlCore_0;

		private TextPart textPart_0;

		private int int_0;

		private int int_1;

		private int int_2;

		private TableCellFormat tableCellFormat_0 = new TableCellFormat();

		/// <summary>Gets or sets the formatting attributes of a table cell.</summary>
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

		/// <summary>Gets the table cell's column number.</summary>
		[Browsable(false)]
		public int Column => this.int_2;

		/// <summary>Gets the number of characters in the table cell.</summary>
		[Browsable(false)]
		public int Length
		{
			get
			{
				int[] array = new int[4] { this.int_1, this.int_2, 0, 0 };
				this.textControlCore_0.method_40(this.textPart_0, 1271, this.int_0, array);
				return 1 + array[3] - array[2];
			}
		}

		/// <summary>Gets or sets the cell's name.</summary>
		[Browsable(false)]
		public string Name
		{
			get
			{
				Struct51 struct51_ = new Struct51(this.int_1, this.int_2);
				string result = string.Empty;
				struct51_.ushort_3 = 1;
				if (this.textControlCore_0.method_69(this.textPart_0, Enum83.const_110, this.int_0, ref struct51_) != 0 && struct51_.intptr_0 != IntPtr.Zero)
				{
					result = Marshal.PtrToStringBSTR(struct51_.intptr_0);
					Marshal.FreeBSTR(struct51_.intptr_0);
				}
				return result;
			}
			set
			{
				Struct51 struct51_ = new Struct51(this.int_1, this.int_2)
				{
					intptr_0 = Marshal.StringToBSTR(value)
				};
				try
				{
					this.textControlCore_0.method_69(this.textPart_0, Enum83.const_111, this.int_0, ref struct51_);
				}
				catch (Exception ex)
				{
					throw ex;
				}
				finally
				{
					Marshal.FreeBSTR(struct51_.intptr_0);
				}
			}
		}

		/// <summary>Gets or sets the table cell's formula.</summary>
		[Browsable(false)]
		public string Formula
		{
			get
			{
				Struct51 struct51_ = new Struct51(this.int_1, this.int_2);
				string result = string.Empty;
				struct51_.ushort_3 = 2;
				if (this.textControlCore_0.method_69(this.textPart_0, Enum83.const_110, this.int_0, ref struct51_) != 0 && struct51_.intptr_1 != IntPtr.Zero)
				{
					result = Marshal.PtrToStringBSTR(struct51_.intptr_1);
					Marshal.FreeBSTR(struct51_.intptr_1);
				}
				return result;
			}
			set
			{
				Struct51 struct51_ = new Struct51(this.int_1, this.int_2)
				{
					intptr_1 = Marshal.StringToBSTR(value)
				};
				try
				{
					this.textControlCore_0.method_69(this.textPart_0, Enum83.const_111, this.int_0, ref struct51_);
				}
				catch (FilterException ex)
				{
					throw new FormulaException(ex.Reason, struct51_.ushort_4);
				}
				catch (Exception ex2)
				{
					throw ex2;
				}
				finally
				{
					Marshal.FreeBSTR(struct51_.intptr_1);
				}
			}
		}

		/// <summary>Gets or sets, in twips, the horizontal position of the cell.</summary>
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

		/// <summary>Gets the table cell's row number.</summary>
		[Browsable(false)]
		public int Row => this.int_1;

		/// <summary>Gets the index (one-based) of the first character in the table cell.</summary>
		[Browsable(false)]
		public int Start
		{
			get
			{
				int[] array = new int[4] { this.int_1, this.int_2, 0, 0 };
				this.textControlCore_0.method_40(this.textPart_0, 1271, this.int_0, array);
				return array[2];
			}
		}

		/// <summary>Gets or sets the cell's text.</summary>
		[Browsable(false)]
		public string Text
		{
			get
			{
				IntPtr intPtr = IntPtr.Zero;
				string empty = string.Empty;
				try
				{
					intPtr = this.textControlCore_0.method_64(this.textPart_0, Enum83.const_170, (uint)this.int_0, Class429.smethod_3(this.int_1, this.int_2));
					return Marshal.PtrToStringUni(Class429.GlobalLock(intPtr));
				}
				catch (Exception ex)
				{
					throw ex;
				}
				finally
				{
					if (intPtr != IntPtr.Zero)
					{
						Marshal.FreeHGlobal(intPtr);
					}
				}
			}
			set
			{
				Struct52 struct52_ = new Struct52(this.int_1, this.int_2, value);
				this.textControlCore_0.method_70(this.textPart_0, Enum83.const_171, this.int_0, ref struct52_);
			}
		}

		/// <summary>Gets or sets, in twips, the width of the cell.</summary>
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

		internal TableCell(TextControlCore textControlCore_1, TextPart iTextPart, int iID, int iRow, int iColumn)
		{
			this.textControlCore_0 = textControlCore_1;
			this.textPart_0 = iTextPart;
			this.int_0 = iID;
			this.int_1 = iRow;
			this.int_2 = iColumn;
			this.tableCellFormat_0.method_0(textControlCore_1, iTextPart, iID, iRow, iColumn);
		}

		/// <summary>Selects the table cell.</summary>
		public void Select()
		{
			int[] int_ = new int[4] { this.int_1, this.int_2, 0, 0 };
			this.textControlCore_0.method_40(this.textPart_0, 1957, this.int_0, int_);
		}
	}
}
