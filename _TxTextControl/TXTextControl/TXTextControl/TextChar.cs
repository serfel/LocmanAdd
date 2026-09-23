using System.Drawing;
using ns21;

namespace TXTextControl
{
	/// <summary>The TextChar object represents a single character in a document.</summary>
	public class TextChar
	{
		private TextControlCore textControlCore_0;

		private int int_0;

		private TextPart textPart_0;

		/// <summary>Gets the bounding rectangle of the character.</summary>
		public Rectangle Bounds
		{
			get
			{
				Struct44 struct44_ = new Struct44(this.int_0 - 1);
				int num = this.textControlCore_0.method_72(this.textPart_0, Enum83.const_54, 0, ref struct44_);
				return new Rectangle(struct44_.struct83_0.int_0, struct44_.struct83_0.int_1 + num, struct44_.struct83_0.int_2 - struct44_.struct83_0.int_0, struct44_.struct83_0.int_3 - struct44_.struct83_0.int_1);
			}
		}

		/// <summary>Gets the character's number.</summary>
		public int Number => this.int_0;

		/// <summary>Gets the value of the character.</summary>
		public char Char
		{
			get
			{
				int num = this.textControlCore_0.method_29(this.textPart_0, 1973, 0, this.int_0 - 1);
				if (num != 1)
				{
					return (char)num;
				}
				return ' ';
			}
		}

		internal TextChar(TextControlCore textControlCore_1, TextPart iTextPart, int iNumber)
		{
			this.textControlCore_0 = textControlCore_1;
			this.int_0 = iNumber;
			this.textPart_0 = iTextPart;
		}
	}
}
