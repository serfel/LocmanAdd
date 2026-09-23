using System;
using System.Drawing;
using ns21;

namespace TXTextControl
{
	/// <summary>An instance of the InputPosition class represents the current text input position of a TXTextControl document.</summary>
	public class InputPosition
	{
		/// <summary>Determines a position to where the input position is scrolled.</summary>
		public enum ScrollPosition
		{
			/// <summary>Scrolls the current input position into the visible part of the document using a default position depending on the previous position.</summary>
			Auto = 0,
			/// <summary>Scrolls the input position to the left side of the visible portion of the document</summary>
			Left = 1,
			/// <summary>Scrolls the input position to the right side of the visible portion of the document.</summary>
			Right = 2,
			/// <summary>Scrolls the input position to the top of the visible portion of the document.</summary>
			Top = 4,
			/// <summary>Scrolls the input position to the bottom of the visible portion of the document.</summary>
			Bottom = 8
		}

		private enum Enum67
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
			const_10 = 0x3FF
		}

		private int int_0;

		private int int_1;

		private int int_2;

		private int int_3 = -1;

		private int int_4;

		private int int_5 = -1;

		private Enum67 enum67_0;

		private Point point_0 = new Point(-1, -1);

		private Size size_0 = new Size(0, 0);

		private TextControlCore textControlCore_0;

		private TextPart textPart_0;

		private bool bool_0;

		private TextFieldPosition textFieldPosition_0;

		/// <summary>Gets the page number of the current text input position.</summary>
		public int Page
		{
			get
			{
				this.method_2(Enum67.const_0);
				return this.int_0;
			}
		}

		/// <summary>Gets the page number in the section containing the current text input position.</summary>
		public int PageInSection
		{
			get
			{
				this.method_2(Enum67.const_7);
				return this.int_1;
			}
		}

		/// <summary>Gets the line number of the current text input position.</summary>
		public int Line
		{
			get
			{
				this.method_2(Enum67.const_1);
				return this.int_2;
			}
		}

		/// <summary>Gets the column number of the current text input position.</summary>
		public int Column
		{
			get
			{
				this.method_2(Enum67.const_2);
				return this.int_3;
			}
		}

		/// <summary>Gets the section number of the current text input position.</summary>
		public int Section
		{
			get
			{
				this.method_2(Enum67.const_6);
				return this.int_4;
			}
		}

		/// <summary>Gets the text position of the current text input position.</summary>
		public int TextPosition
		{
			get
			{
				this.method_2(Enum67.const_3);
				return this.int_5;
			}
		}

		/// <summary>Gets the geometric location of the current text input position.</summary>
		public Point Location
		{
			get
			{
				this.method_2(Enum67.const_4);
				return this.point_0;
			}
		}

		/// <summary>Gets the size of the caret, in pixels, at the current text input position.</summary>
		public Size CaretSize
		{
			get
			{
				this.method_2(Enum67.const_8);
				return this.size_0;
			}
		}

		/// <summary>Shows or hides a marker which indicates the current text input position when the TextControl is inactive and the blinking caret is not visible.</summary>
		public bool InactiveMarker
		{
			get
			{
				this.method_2(Enum67.const_9);
				return this.bool_0;
			}
			set
			{
				this.bool_0 = value;
				this.enum67_0 |= Enum67.const_9;
				this.method_3();
			}
		}

		/// <summary>Creates a new input position from a page, line and column number.</summary>
		/// <param name="page">Specifies a page number.</param>
		/// <param name="line">Specifies a line number.</param>
		/// <param name="column">Specifies a column number.</param>
		public InputPosition(int page, int line, int column)
		{
			this.int_0 = page;
			this.int_2 = line;
			this.int_3 = column;
			this.enum67_0 = (Enum67)7;
		}

		/// <summary>Creates a new input position from a text position.</summary>
		/// <param name="textPosition">Specifies a text position.</param>
		public InputPosition(int textPosition)
		{
			this.int_5 = textPosition;
			this.enum67_0 = Enum67.const_3;
		}

		/// <summary>Creates a new input position from a text position with a special handling at the beginning and the end of a TextField.</summary>
		/// <param name="textPosition">Specifies a text position.</param>
		/// <param name="textFieldPosition">If the textPosition parameter is a position at the beginning or at the end of a TextField with a doubled input position, this parameter can be used to define whether the position is inside or outside the field.</param>
		public InputPosition(int textPosition, TextFieldPosition textFieldPosition)
		{
			this.int_5 = textPosition;
			this.textFieldPosition_0 = textFieldPosition;
			this.enum67_0 = (Enum67)40;
		}

		/// <summary>Creates a new input position from a geometric location.</summary>
		/// <param name="location">Specifies a geometric location.</param>
		public InputPosition(Point location)
		{
			this.point_0 = location;
			this.enum67_0 = Enum67.const_4;
		}

		/// <summary>Scrolls the current input position into the visible part of the document using a default position depending on the previous position.</summary>
		public void ScrollTo()
		{
			if (this.textControlCore_0 != null && this.textControlCore_0.isHandleCreated)
			{
				this.textControlCore_0.method_30(Enum83.const_301, 0, 0);
			}
		}

		public void ScrollTo(ScrollPosition position)
		{
			if (this.textControlCore_0 != null && this.textControlCore_0.isHandleCreated)
			{
				this.textControlCore_0.method_30(Enum83.const_301, (int)position, 0);
			}
		}

		internal void method_0(TextControlCore textControlCore_1, TextPart textPart_1)
		{
			this.textControlCore_0 = textControlCore_1;
			this.textPart_0 = textPart_1;
		}

		internal void method_1(InputPosition inputPosition_0)
		{
			inputPosition_0.int_0 = this.int_0;
			inputPosition_0.int_2 = this.int_2;
			inputPosition_0.int_3 = this.int_3;
			inputPosition_0.int_5 = this.int_5;
			inputPosition_0.point_0 = this.point_0;
			inputPosition_0.size_0 = this.size_0;
			inputPosition_0.textFieldPosition_0 = this.textFieldPosition_0;
			inputPosition_0.enum67_0 = this.enum67_0;
		}

		private void method_2(Enum67 enum67_1)
		{
			if (this.textControlCore_0 == null || !this.textControlCore_0.isHandleCreated)
			{
				return;
			}
			if ((enum67_1 & Enum67.const_0) != 0 || (enum67_1 & Enum67.const_1) != 0 || (enum67_1 & Enum67.const_2) != 0 || (enum67_1 & Enum67.const_6) != 0 || (enum67_1 & Enum67.const_7) != 0)
			{
				int[] array = new int[6];
				int[] array2 = array;
				int num = this.textControlCore_0.method_40(this.textPart_0, 1129, 6, array2);
				if (num > 0)
				{
					this.int_0 = num;
					this.int_2 = array2[0];
					this.int_3 = array2[1];
					this.int_4 = array2[2];
					this.int_1 = array2[5];
				}
			}
			if ((enum67_1 & Enum67.const_3) != 0)
			{
				int[] array3 = new int[2];
				int[] array4 = array3;
				if (this.textControlCore_0.method_40(this.textPart_0, 1132, 0, array4) != 0)
				{
					this.int_5 = array4[0];
				}
			}
			if ((enum67_1 & Enum67.const_4) != 0)
			{
				int[] array5 = new int[2];
				int[] array6 = array5;
				if (this.textControlCore_0.method_40(this.textPart_0, 1132, 0, array6) != 0)
				{
					Struct44 struct44_ = new Struct44(array6[0]);
					int num2 = this.textControlCore_0.method_72(this.textPart_0, Enum83.const_54, 0, ref struct44_);
					this.point_0.X = struct44_.struct83_0.int_0;
					this.point_0.Y = struct44_.struct83_0.int_1 + num2;
				}
			}
			if ((enum67_1 & Enum67.const_8) != 0)
			{
				int num3 = this.textControlCore_0.method_29(this.textPart_0, 1124, 0, 0);
				this.size_0.Width = Class429.smethod_5(num3);
				this.size_0.Height = Class429.smethod_6(num3);
			}
			if ((enum67_1 & Enum67.const_9) != 0)
			{
				Enum91 @enum = (Enum91)this.textControlCore_0.method_29(this.textPart_0, 1151, 0, 0);
				this.bool_0 = (@enum & Enum91.const_14) != 0;
			}
		}

		internal void method_3()
		{
			if (this.textControlCore_0 == null || !this.textControlCore_0.isHandleCreated)
			{
				return;
			}
			if ((this.enum67_0 & Enum67.const_0) != 0 || (this.enum67_0 & Enum67.const_1) != 0 || (this.enum67_0 & Enum67.const_2) != 0)
			{
				int[] array = new int[3] { this.int_0, this.int_2, this.int_3 };
				this.textControlCore_0.method_40(this.textPart_0, 1213, 0, array);
			}
			if ((this.enum67_0 & Enum67.const_3) != 0)
			{
				this.textControlCore_0.method_5(this.textPart_0, this.int_5, 0);
			}
			if ((this.enum67_0 & Enum67.const_5) != 0)
			{
				this.textControlCore_0.method_29(this.textPart_0, 1217, (int)this.textFieldPosition_0, 0);
			}
			if ((this.enum67_0 & Enum67.const_4) != 0)
			{
				int num = this.textControlCore_0.method_29(this.textPart_0, 1192, 1, 0);
				int num2 = this.textControlCore_0.method_29(this.textPart_0, 1192, 2, 0);
				Class429.Struct82 struct82_ = new Class429.Struct82(this.point_0.X - num, this.point_0.Y - num2);
				int num3 = this.textControlCore_0.method_35(this.textPart_0, Enum83.const_70, Class429.smethod_3(1, 1), ref struct82_);
				if (num3 == -1)
				{
					throw new ArgumentOutOfRangeException("Location", this.textControlCore_0.method_83("ERR_NOINPUTPOS"));
				}
				this.textControlCore_0.method_5(this.textPart_0, num3, 0);
			}
			if ((this.enum67_0 & Enum67.const_9) != 0)
			{
				this.textControlCore_0.method_30(Enum83.const_40, this.bool_0 ? 8388608 : 16777216, 0);
			}
		}
	}
}
