using System.Drawing;
using ns21;

namespace TXTextControl
{
	/// <summary>An instance of the Line class represents a single line in a Text Control document.</summary>
	public class Line
	{
		private TextControlCore textControlCore_0;

		private int int_0;

		private TextPart textPart_0;

		/// <summary>Gets the line's baseline position.</summary>
		public int Baseline => this.textControlCore_0.method_29(this.textPart_0, 1188, 0, this.int_0 - 1);

		/// <summary>Gets the number of characters in the line including the break character.</summary>
		public int Length
		{
			get
			{
				if (this.int_0 >= this.textControlCore_0.method_29(this.textPart_0, 1139, 0, 0))
				{
					return this.textControlCore_0.method_29(this.textPart_0, 1136, 0, 0) + 1 - this.Start;
				}
				return this.textControlCore_0.method_29(this.textPart_0, 1140, 0, this.int_0) + 1 - this.Start;
			}
		}

		/// <summary>Gets the line's number.</summary>
		public int Number => this.int_0;

		/// <summary>Gets the number of the page to which the line belongs.</summary>
		public int Page => this.textControlCore_0.method_29(this.textPart_0, 1907, 0, this.int_0 - 1);

		/// <summary>Gets the number (one-based) of the first character in the line.</summary>
		public int Start => this.textControlCore_0.method_29(this.textPart_0, 1140, 0, this.int_0 - 1) + 1;

		/// <summary>Gets the line's text.</summary>
		public string Text
		{
			get
			{
				this.Save(out var stringData, StringStreamType.PlainText);
				return stringData;
			}
		}

		/// <summary>Gets the bounding rectangle of the text belonging to the line.</summary>
		public Rectangle TextBounds
		{
			get
			{
				Struct44 struct44_ = new Struct44(this.int_0 - 1);
				int num = this.textControlCore_0.method_72(this.textPart_0, Enum83.const_23, 0, ref struct44_);
				return new Rectangle(struct44_.struct83_0.int_0, struct44_.struct83_0.int_1 + num, struct44_.struct83_0.int_2 - struct44_.struct83_0.int_0, struct44_.struct83_0.int_3 - struct44_.struct83_0.int_1);
			}
		}

		internal Line(TextControlCore textControlCore_1, TextPart iTextPart, int iNumber)
		{
			this.textControlCore_0 = textControlCore_1;
			this.int_0 = iNumber;
			this.textPart_0 = iTextPart;
		}

		/// <summary>Saves the line's text in a byte array with the specified format.</summary>
		/// <param name="binaryData">Specifies a byte array into which the line's text is saved.</param>
		/// <param name="binaryStreamType">Specifies one of the BinaryStreamType values.</param>
		public void Save(out byte[] binaryData, BinaryStreamType binaryStreamType)
		{
			this.Save(out binaryData, binaryStreamType, new SaveSettings());
		}

		/// <summary>Saves the line's text as a string with the specified format.</summary>
		/// <param name="stringData">Specifies a string into which the line's text is saved.</param>
		/// <param name="stringStreamType">Specifies one of the StringStreamType values.</param>
		public void Save(out string stringData, StringStreamType stringStreamType)
		{
			this.Save(out stringData, stringStreamType, new SaveSettings());
		}

		/// <summary>Saves the line's text in a byte array with the specified format and special settings.</summary>
		/// <param name="binaryData">Specifies a byte array into which the line's text is saved.</param>
		/// <param name="binaryStreamType">Specifies one of the BinaryStreamType values.</param>
		/// <param name="saveSettings">Specifies a SaveSettings object with additional information and settings for the save operation.</param>
		public void Save(out byte[] binaryData, BinaryStreamType binaryStreamType, SaveSettings saveSettings)
		{
			saveSettings.TextPart = this.textPart_0;
			this.textControlCore_0.method_16(this.textPart_0, this.Start - 1, this.Length);
			saveSettings.method_3(out binaryData, binaryStreamType, this.textControlCore_0, Enum104.const_7);
			this.textControlCore_0.method_17(this.textPart_0);
		}

		/// <summary>Saves the line's text as a string with the specified format and special settings.</summary>
		/// <param name="stringData">Specifies a string into which the line's text is saved.</param>
		/// <param name="stringStreamType">Specifies one of the StringStreamType values.</param>
		/// <param name="saveSettings">Specifies a SaveSettings object with additional information and settings for the save operation.</param>
		public void Save(out string stringData, StringStreamType stringStreamType, SaveSettings saveSettings)
		{
			saveSettings.TextPart = this.textPart_0;
			this.textControlCore_0.method_16(this.textPart_0, this.Start - 1, this.Length);
			saveSettings.method_4(out stringData, stringStreamType, this.textControlCore_0, Enum104.const_7);
			this.textControlCore_0.method_17(this.textPart_0);
		}
	}
}
