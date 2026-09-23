using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using ns21;

namespace TXTextControl
{
	/// <summary>The TableCellFormat object represents the formatting attributes of a table cell.</summary>
	public class TableCellFormat
	{
		private enum Enum75
		{
			const_0 = 1,
			const_1 = 2,
			const_2 = 4,
			const_3 = 8,
			const_4 = 0x10,
			const_5 = 0x20,
			const_6 = 0x40,
			const_7 = 0x80,
			const_8 = 0x100,
			const_9 = 0x200,
			const_10 = 0x400,
			const_11 = 0x800,
			const_12 = 0x1000,
			const_13 = 0x2000,
			const_14 = 0x4000,
			const_15 = 0x8000,
			const_16 = 0x10000,
			const_17 = 0x20000,
			const_18 = 0x40000,
			const_19 = 0x80000,
			const_20 = 0xFFFFF,
			const_21 = 0x100000,
			const_22 = 0x1FFFFF
		}

		private enum Enum76
		{
			const_0 = 1,
			const_1 = 2,
			const_2 = 4,
			const_3 = 8
		}

		private Enum75 enum75_0;

		private Enum75 enum75_1;

		private Enum75 enum75_2;

		private TextControlCore textControlCore_0;

		private TextPart textPart_0;

		private int int_0;

		private int int_1;

		private int int_2;

		private Color color_0 = SystemColors.Window;

		private int int_3;

		private int int_4;

		private int int_5;

		private int int_6;

		private int int_7 = 30;

		private int int_8;

		private int int_9 = 30;

		private int int_10;

		private VerticalAlignment verticalAlignment_0;

		private Color color_1 = SystemColors.WindowText;

		private Color color_2 = SystemColors.WindowText;

		private Color color_3 = SystemColors.WindowText;

		private Color color_4 = SystemColors.WindowText;

		private string string_0 = string.Empty;

		private TextType textType_0;

		private bool bool_0 = true;

		private bool bool_1 = true;

		private int int_11;

		private int int_12;

		private int int_13;

		/// <summary>Gets or sets the table cell's background color.</summary>
		[Browsable(false)]
		public Color BackColor
		{
			get
			{
				this.method_2(Enum75.const_9);
				return this.color_0;
			}
			set
			{
				this.color_0 = value;
				this.enum75_0 |= Enum75.const_9;
				this.method_3();
			}
		}

		/// <summary>Gets or sets, in twips, the width of the table cell's left border.</summary>
		[Browsable(false)]
		public int LeftBorderWidth
		{
			get
			{
				this.method_2(Enum75.const_0);
				return this.int_3;
			}
			set
			{
				this.int_3 = value;
				this.enum75_0 |= Enum75.const_0;
				this.method_3();
			}
		}

		/// <summary>Gets or sets, in twips, the width of the table cell's top border.</summary>
		[Browsable(false)]
		public int TopBorderWidth
		{
			get
			{
				this.method_2(Enum75.const_1);
				return this.int_4;
			}
			set
			{
				this.int_4 = value;
				this.enum75_0 |= Enum75.const_1;
				this.method_3();
			}
		}

		/// <summary>Gets or sets, in twips, the width of the table cell's right border.</summary>
		[Browsable(false)]
		public int RightBorderWidth
		{
			get
			{
				this.method_2(Enum75.const_2);
				return this.int_5;
			}
			set
			{
				this.int_5 = value;
				this.enum75_0 |= Enum75.const_2;
				this.method_3();
			}
		}

		/// <summary>Gets or sets, in twips, the width of the table cell's bottom border.</summary>
		[Browsable(false)]
		public int BottomBorderWidth
		{
			get
			{
				this.method_2(Enum75.const_3);
				return this.int_6;
			}
			set
			{
				this.int_6 = value;
				this.enum75_0 |= Enum75.const_3;
				this.method_3();
			}
		}

		/// <summary>Gets or sets, in twips, the distance between the table cell's left border and its text.</summary>
		[Browsable(false)]
		public int LeftTextDistance
		{
			get
			{
				this.method_2(Enum75.const_4);
				return this.int_7;
			}
			set
			{
				this.int_7 = value;
				this.enum75_0 |= Enum75.const_4;
				this.method_3();
			}
		}

		/// <summary>Gets or sets, in twips, the distance between the table cell's top border and its text.</summary>
		[Browsable(false)]
		public int TopTextDistance
		{
			get
			{
				this.method_2(Enum75.const_5);
				return this.int_8;
			}
			set
			{
				this.int_8 = value;
				this.enum75_0 |= Enum75.const_5;
				this.method_3();
			}
		}

		/// <summary>Gets or sets, in twips, the distance between the table cell's right border and its text.</summary>
		[Browsable(false)]
		public int RightTextDistance
		{
			get
			{
				this.method_2(Enum75.const_6);
				return this.int_9;
			}
			set
			{
				this.int_9 = value;
				this.enum75_0 |= Enum75.const_6;
				this.method_3();
			}
		}

		/// <summary>Gets or sets, in twips, the distance between the table cell's bottom border and its text.</summary>
		[Browsable(false)]
		public int BottomTextDistance
		{
			get
			{
				this.method_2(Enum75.const_7);
				return this.int_10;
			}
			set
			{
				this.int_10 = value;
				this.enum75_0 |= Enum75.const_7;
				this.method_3();
			}
		}

		/// <summary>Gets or sets the vertical alignment of the text in the table cell.</summary>
		[Browsable(false)]
		public VerticalAlignment VerticalAlignment
		{
			get
			{
				this.method_2(Enum75.const_11);
				return this.verticalAlignment_0;
			}
			set
			{
				this.verticalAlignment_0 = value;
				this.enum75_0 |= Enum75.const_11;
				this.method_3();
			}
		}

		/// <summary>Gets or sets the color of the table cell's left border.</summary>
		[Browsable(false)]
		public Color LeftBorderColor
		{
			get
			{
				this.method_2(Enum75.const_15);
				return this.color_1;
			}
			set
			{
				this.color_1 = value;
				this.enum75_0 |= Enum75.const_15;
				this.method_3();
			}
		}

		/// <summary>Gets or sets the color of the table cell's top border.</summary>
		[Browsable(false)]
		public Color TopBorderColor
		{
			get
			{
				this.method_2(Enum75.const_16);
				return this.color_2;
			}
			set
			{
				this.color_2 = value;
				this.enum75_0 |= Enum75.const_16;
				this.method_3();
			}
		}

		/// <summary>Gets or sets the color of the table cell's right border.</summary>
		[Browsable(false)]
		public Color RightBorderColor
		{
			get
			{
				this.method_2(Enum75.const_17);
				return this.color_3;
			}
			set
			{
				this.color_3 = value;
				this.enum75_0 |= Enum75.const_17;
				this.method_3();
			}
		}

		/// <summary>Gets or sets the color of the table cell's bottom border.</summary>
		[Browsable(false)]
		public Color BottomBorderColor
		{
			get
			{
				this.method_2(Enum75.const_18);
				return this.color_4;
			}
			set
			{
				this.color_4 = value;
				this.enum75_0 |= Enum75.const_18;
				this.method_3();
			}
		}

		/// <summary>Gets or sets a number format for the table cell.</summary>
		public string NumberFormat
		{
			get
			{
				this.method_2(Enum75.const_21);
				return this.string_0;
			}
			set
			{
				this.string_0 = value;
				this.enum75_0 |= Enum75.const_21;
				this.method_3();
			}
		}

		/// <summary>Gets or sets the text type of the table cell which determines whether the cell's text is interpreted as a number or as text When the type is Standard, the cell's text is interpreted as text and it is displayed as it is.</summary>
		[Browsable(false)]
		public TextType TextType
		{
			get
			{
				this.method_2(Enum75.const_19);
				return this.textType_0;
			}
			set
			{
				this.textType_0 = value;
				this.enum75_0 |= Enum75.const_19;
				this.method_3();
			}
		}

		[Browsable(false)]
		internal bool Boolean_0
		{
			get
			{
				this.method_2(Enum75.const_13);
				return this.bool_0;
			}
			set
			{
				this.bool_0 = value;
				this.enum75_0 |= Enum75.const_13;
				this.method_3();
			}
		}

		[Browsable(false)]
		internal bool Boolean_1
		{
			get
			{
				this.method_2(Enum75.const_14);
				return this.bool_1;
			}
			set
			{
				this.bool_1 = value;
				this.enum75_0 |= Enum75.const_14;
				this.method_3();
			}
		}

		[Browsable(false)]
		internal int Int32_0
		{
			get
			{
				this.method_2(Enum75.const_12);
				return this.int_11;
			}
			set
			{
				this.int_11 = value;
				this.enum75_0 |= Enum75.const_12;
				this.method_3();
			}
		}

		[Browsable(false)]
		internal int Int32_1
		{
			get
			{
				this.method_2(Enum75.const_8);
				return this.int_12;
			}
			set
			{
				this.int_12 = value;
				this.enum75_0 |= Enum75.const_8;
				this.method_3();
			}
		}

		[Browsable(false)]
		internal int Int32_2
		{
			get
			{
				this.method_2(Enum75.const_10);
				return this.int_13;
			}
			set
			{
				this.int_13 = value;
				this.enum75_0 |= Enum75.const_10;
				this.method_3();
			}
		}

		internal void method_0(TextControlCore textControlCore_1, TextPart textPart_1, int int_14, int int_15, int int_16)
		{
			this.textControlCore_0 = textControlCore_1;
			this.textPart_0 = textPart_1;
			this.int_0 = int_14;
			this.int_1 = int_15;
			this.int_2 = int_16;
		}

		internal void method_1(TableCellFormat tableCellFormat_0)
		{
			tableCellFormat_0.color_0 = this.color_0;
			tableCellFormat_0.int_3 = this.int_3;
			tableCellFormat_0.int_4 = this.int_4;
			tableCellFormat_0.int_5 = this.int_5;
			tableCellFormat_0.int_6 = this.int_6;
			tableCellFormat_0.int_7 = this.int_7;
			tableCellFormat_0.int_8 = this.int_8;
			tableCellFormat_0.int_9 = this.int_9;
			tableCellFormat_0.int_10 = this.int_10;
			tableCellFormat_0.verticalAlignment_0 = this.verticalAlignment_0;
			tableCellFormat_0.int_11 = this.int_11;
			tableCellFormat_0.bool_0 = this.bool_0;
			tableCellFormat_0.bool_1 = this.bool_1;
			tableCellFormat_0.color_1 = this.color_1;
			tableCellFormat_0.color_2 = this.color_2;
			tableCellFormat_0.color_3 = this.color_3;
			tableCellFormat_0.color_4 = this.color_4;
			tableCellFormat_0.textType_0 = this.textType_0;
			tableCellFormat_0.string_0 = this.string_0;
			tableCellFormat_0.enum75_0 = this.enum75_0;
		}

		private void method_2(Enum75 enum75_3)
		{
			if (this.int_0 == 0 || this.textControlCore_0 == null || !this.textControlCore_0.isHandleCreated || (((enum75_3 & Enum75.const_20) == 0 || (this.enum75_1 & Enum75.const_20) != 0) && ((enum75_3 & Enum75.const_21) == 0 || (this.enum75_1 & Enum75.const_21) != 0)))
			{
				return;
			}
			Struct51 struct51_ = new Struct51(this.int_1, this.int_2);
			if ((enum75_3 & Enum75.const_21) != 0)
			{
				struct51_.ushort_3 = 4;
			}
			if (this.textControlCore_0.method_69(this.textPart_0, Enum83.const_110, this.int_0, ref struct51_) == 0)
			{
				return;
			}
			if ((enum75_3 & Enum75.const_21) != 0)
			{
				this.string_0 = string.Empty;
				if (struct51_.intptr_2 != IntPtr.Zero)
				{
					this.string_0 = Marshal.PtrToStringBSTR(struct51_.intptr_2);
					Marshal.FreeBSTR(struct51_.intptr_2);
					if (this.string_0.Length == 0)
					{
						this.enum75_2 |= Enum75.const_21;
					}
				}
				this.enum75_1 |= Enum75.const_21;
			}
			if ((enum75_3 & Enum75.const_20) != 0)
			{
				if (struct51_.uint_0 == 2147483648u)
				{
					this.color_0 = SystemColors.Window;
					this.enum75_2 |= Enum75.const_9;
				}
				else
				{
					this.color_0 = ((struct51_.uint_0 == 1073741824) ? SystemColors.Window : ((struct51_.uint_0 == 1342177280) ? Class429.smethod_2(this.textControlCore_0.GetTextControl().GetBackColor()) : Class429.smethod_2((int)struct51_.uint_0)));
				}
				if (struct51_.short_0 == -1)
				{
					this.int_3 = 0;
					this.enum75_2 |= Enum75.const_0;
				}
				else
				{
					this.int_3 = struct51_.short_0;
				}
				if (struct51_.short_1 == -1)
				{
					this.int_4 = 0;
					this.enum75_2 |= Enum75.const_1;
				}
				else
				{
					this.int_4 = struct51_.short_1;
				}
				if (struct51_.short_2 == -1)
				{
					this.int_5 = 0;
					this.enum75_2 |= Enum75.const_2;
				}
				else
				{
					this.int_5 = struct51_.short_2;
				}
				if (struct51_.short_3 == -1)
				{
					this.int_6 = 0;
					this.enum75_2 |= Enum75.const_3;
				}
				else
				{
					this.int_6 = struct51_.short_3;
				}
				if (struct51_.short_4 == -1)
				{
					this.int_7 = 0;
					this.enum75_2 |= Enum75.const_4;
				}
				else
				{
					this.int_7 = struct51_.short_4;
				}
				if (struct51_.short_5 == -1)
				{
					this.int_8 = 0;
					this.enum75_2 |= Enum75.const_5;
				}
				else
				{
					this.int_8 = struct51_.short_5;
				}
				if (struct51_.short_6 == -1)
				{
					this.int_9 = 0;
					this.enum75_2 |= Enum75.const_6;
				}
				else
				{
					this.int_9 = struct51_.short_6;
				}
				if (struct51_.short_7 == -1)
				{
					this.int_10 = 0;
					this.enum75_2 |= Enum75.const_7;
				}
				else
				{
					this.int_10 = struct51_.short_7;
				}
				if (struct51_.uint_2 == 2147483648u)
				{
					this.color_1 = SystemColors.WindowText;
					this.enum75_2 |= Enum75.const_15;
				}
				else
				{
					this.color_1 = ((struct51_.uint_2 == 1073741824) ? SystemColors.WindowText : Class429.smethod_2((int)struct51_.uint_2));
				}
				if (struct51_.uint_3 == 2147483648u)
				{
					this.color_2 = SystemColors.WindowText;
					this.enum75_2 |= Enum75.const_16;
				}
				else
				{
					this.color_2 = ((struct51_.uint_3 == 1073741824) ? SystemColors.WindowText : Class429.smethod_2((int)struct51_.uint_3));
				}
				if (struct51_.uint_4 == 2147483648u)
				{
					this.color_3 = SystemColors.WindowText;
					this.enum75_2 |= Enum75.const_17;
				}
				else
				{
					this.color_3 = ((struct51_.uint_4 == 1073741824) ? SystemColors.WindowText : Class429.smethod_2((int)struct51_.uint_4));
				}
				if (struct51_.uint_5 == 2147483648u)
				{
					this.color_4 = SystemColors.WindowText;
					this.enum75_2 |= Enum75.const_18;
				}
				else
				{
					this.color_4 = ((struct51_.uint_5 == 1073741824) ? SystemColors.WindowText : Class429.smethod_2((int)struct51_.uint_5));
				}
				if (struct51_.byte_0 == byte.MaxValue)
				{
					this.verticalAlignment_0 = VerticalAlignment.Top;
					this.enum75_2 |= Enum75.const_11;
				}
				else
				{
					this.verticalAlignment_0 = (VerticalAlignment)struct51_.byte_0;
				}
				if (struct51_.int_0 == -1)
				{
					this.int_12 = 0;
					this.enum75_2 |= Enum75.const_8;
				}
				else
				{
					this.int_12 = struct51_.int_0;
				}
				if (struct51_.int_1 == -1)
				{
					this.int_13 = 0;
					this.enum75_2 |= Enum75.const_10;
				}
				else
				{
					this.int_13 = struct51_.int_1;
				}
				if (struct51_.short_8 == -1)
				{
					this.int_11 = 0;
					this.enum75_2 |= Enum75.const_12;
				}
				else
				{
					this.int_11 = struct51_.short_8;
				}
				if (((uint)struct51_.byte_1 & (true ? 1u : 0u)) != 0)
				{
					this.bool_0 = true;
				}
				else if ((struct51_.byte_1 & 2u) != 0)
				{
					this.bool_0 = false;
				}
				else
				{
					this.bool_0 = true;
					this.enum75_2 |= Enum75.const_13;
				}
				if ((struct51_.byte_1 & 8u) != 0)
				{
					this.bool_1 = true;
				}
				else if ((struct51_.byte_1 & 4u) != 0)
				{
					this.bool_1 = false;
				}
				else
				{
					this.bool_1 = false;
					this.enum75_2 |= Enum75.const_14;
				}
				if (struct51_.byte_4 == byte.MaxValue)
				{
					this.textType_0 = TextType.Standard;
					this.enum75_2 |= Enum75.const_19;
				}
				else
				{
					this.textType_0 = (TextType)struct51_.byte_4;
				}
				this.enum75_1 |= Enum75.const_20;
			}
		}

		internal void method_3()
		{
			if (this.int_0 == 0 || this.textControlCore_0 == null || !this.textControlCore_0.isHandleCreated)
			{
				return;
			}
			if ((this.enum75_0 & Enum75.const_22) != 0)
			{
				Struct51 struct51_ = new Struct51(this.int_1, this.int_2);
				try
				{
					if ((this.enum75_0 & Enum75.const_9) != 0)
					{
						struct51_.uint_0 = ((Class429.smethod_0(this.color_0) == this.textControlCore_0.GetTextControl().GetBackColor()) ? 1342177280u : ((this.color_0 == SystemColors.Window) ? 1073741824u : ((uint)Class429.smethod_0(this.color_0))));
					}
					if ((this.enum75_0 & Enum75.const_0) != 0)
					{
						struct51_.short_0 = (short)this.int_3;
					}
					if ((this.enum75_0 & Enum75.const_1) != 0)
					{
						struct51_.short_1 = (short)this.int_4;
					}
					if ((this.enum75_0 & Enum75.const_2) != 0)
					{
						struct51_.short_2 = (short)this.int_5;
					}
					if ((this.enum75_0 & Enum75.const_3) != 0)
					{
						struct51_.short_3 = (short)this.int_6;
					}
					if ((this.enum75_0 & Enum75.const_4) != 0)
					{
						struct51_.short_4 = (short)this.int_7;
					}
					if ((this.enum75_0 & Enum75.const_5) != 0)
					{
						struct51_.short_5 = (short)this.int_8;
					}
					if ((this.enum75_0 & Enum75.const_6) != 0)
					{
						struct51_.short_6 = (short)this.int_9;
					}
					if ((this.enum75_0 & Enum75.const_7) != 0)
					{
						struct51_.short_7 = (short)this.int_10;
					}
					if ((this.enum75_0 & Enum75.const_15) != 0)
					{
						struct51_.uint_2 = ((this.color_1 == SystemColors.WindowText) ? 1073741824u : ((uint)Class429.smethod_0(this.color_1)));
					}
					if ((this.enum75_0 & Enum75.const_16) != 0)
					{
						struct51_.uint_3 = ((this.color_2 == SystemColors.WindowText) ? 1073741824u : ((uint)Class429.smethod_0(this.color_2)));
					}
					if ((this.enum75_0 & Enum75.const_17) != 0)
					{
						struct51_.uint_4 = ((this.color_3 == SystemColors.WindowText) ? 1073741824u : ((uint)Class429.smethod_0(this.color_3)));
					}
					if ((this.enum75_0 & Enum75.const_18) != 0)
					{
						struct51_.uint_5 = ((this.color_4 == SystemColors.WindowText) ? 1073741824u : ((uint)Class429.smethod_0(this.color_4)));
					}
					if ((this.enum75_0 & Enum75.const_8) != 0)
					{
						struct51_.int_0 = (short)this.int_12;
					}
					if ((this.enum75_0 & Enum75.const_10) != 0)
					{
						struct51_.int_1 = (short)this.int_13;
					}
					if ((this.enum75_0 & Enum75.const_11) != 0)
					{
						struct51_.byte_0 = (byte)this.verticalAlignment_0;
					}
					if ((this.enum75_0 & Enum75.const_12) != 0)
					{
						struct51_.short_8 = (short)this.int_11;
					}
					if ((this.enum75_0 & Enum75.const_13) != 0)
					{
						struct51_.byte_1 |= (byte)(this.bool_0 ? 1 : 2);
					}
					if ((this.enum75_0 & Enum75.const_14) != 0)
					{
						struct51_.byte_1 |= (byte)(this.bool_1 ? 8 : 4);
					}
					if ((this.enum75_0 & Enum75.const_19) != 0)
					{
						struct51_.byte_4 = (byte)((this.textType_0 == TextType.Number) ? 1 : 0);
					}
					if ((this.enum75_0 & Enum75.const_21) != 0)
					{
						struct51_.intptr_2 = Marshal.StringToBSTR(this.string_0);
					}
					this.textControlCore_0.method_69(this.textPart_0, Enum83.const_111, this.int_0, ref struct51_);
				}
				catch (FilterException ex)
				{
					throw new NumberFormatException(ex.Reason, struct51_.ushort_5);
				}
				catch (Exception ex2)
				{
					throw ex2;
				}
				finally
				{
					if (struct51_.intptr_2 != IntPtr.Zero)
					{
						Marshal.FreeBSTR(struct51_.intptr_2);
					}
				}
			}
			this.enum75_2 &= ~this.enum75_0;
			this.enum75_0 = (Enum75)0;
		}
	}
}
