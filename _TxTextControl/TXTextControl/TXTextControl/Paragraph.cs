using System;
using System.Runtime.InteropServices;
using ns21;

namespace TXTextControl
{
	/// <summary>A Paragraph object represents a single paragraph in a Text Control document.</summary>
	public class Paragraph
	{
		private enum Enum71
		{
			const_0 = 1,
			const_1 = 2,
			const_2 = 4,
			const_3 = 8,
			const_4 = 0xF,
			const_5 = 0x10,
			const_6 = 0x20,
			const_7 = 0x40,
			const_8 = 79
		}

		private TextControlCore textControlCore_0;

		private int int_0 = 1;

		private int int_1 = 1;

		private TextPart textPart_0;

		private Enum71 enum71_0;

		private ParagraphFormat paragraphFormat_0;

		private ListFormat listFormat_0;

		private string string_0 = string.Empty;

		private int int_2;

		private int int_3;

		private int int_4;

		private string string_1 = string.Empty;

		private int int_5 = 1;

		private int int_6 = 1;

		/// <summary>Gets or sets the paragraph's formatting attributes.</summary>
		public ParagraphFormat Format
		{
			get
			{
				return this.paragraphFormat_0;
			}
			set
			{
				value.method_3(this.paragraphFormat_0);
				this.paragraphFormat_0.method_11();
			}
		}

		/// <summary>Gets or sets the paragraph's formatting style.</summary>
		public string FormattingStyle
		{
			get
			{
				this.method_0(Enum71.const_7);
				return this.string_0;
			}
			set
			{
				this.string_0 = value;
				if (this.int_0 != 0 && this.textControlCore_0 != null && this.textControlCore_0.isHandleCreated)
				{
					this.textControlCore_0.method_37(this.textPart_0, 1919, this.int_0, this.string_0);
				}
			}
		}

		/// <summary>Gets the number of characters in the paragraph including the paragraph end character.</summary>
		public int Length
		{
			get
			{
				this.method_0(Enum71.const_1);
				return this.int_2;
			}
		}

		/// <summary>Gets or sets the paragraph's bulleted or numbered list and/or its formatting attributes.</summary>
		public ListFormat ListFormat
		{
			get
			{
				return this.listFormat_0;
			}
			set
			{
				value.method_3(this.listFormat_0);
				this.listFormat_0.method_12();
			}
		}

		/// <summary>Gets the number of lines the paragraph consists of.</summary>
		public int Lines
		{
			get
			{
				this.method_0(Enum71.const_3);
				return this.int_3;
			}
		}

		/// <summary>Gets the paragraph's number.</summary>
		public int Number => this.int_0;

		/// <summary>Gets the paragraph's list number.</summary>
		public int ListNumber
		{
			get
			{
				this.method_0(Enum71.const_5);
				return this.int_4;
			}
		}

		/// <summary>Gets the paragraph's list number text.</summary>
		public string ListNumberText
		{
			get
			{
				this.method_0(Enum71.const_6);
				return this.string_1;
			}
		}

		/// <summary>Gets the number (one-based) of the paragraph's first character.</summary>
		public int Start
		{
			get
			{
				this.method_0(Enum71.const_0);
				return this.int_5;
			}
		}

		/// <summary>Gets the number (one-based) of the paragraph's first line.</summary>
		public int StartLine
		{
			get
			{
				this.method_0(Enum71.const_2);
				return this.int_6;
			}
		}

		/// <summary>Gets the paragraph's text.</summary>
		public string Text
		{
			get
			{
				this.Save(out var stringData, StringStreamType.PlainText);
				return stringData;
			}
		}

		internal Paragraph(TextControlCore textControlCore_1, TextPart iTextPart, int iNumber, int iMaxNumber)
		{
			this.textControlCore_0 = textControlCore_1;
			this.int_0 = iNumber;
			this.int_1 = iMaxNumber;
			this.textPart_0 = iTextPart;
			this.paragraphFormat_0 = new ParagraphFormat(this.Start);
			this.listFormat_0 = new ListFormat(this.Start);
			this.paragraphFormat_0.method_1(textControlCore_1, iTextPart);
			this.listFormat_0.method_1(textControlCore_1, iTextPart);
		}

		/// <summary>Saves the paragraph's text in a byte array with the specified format.</summary>
		/// <param name="binaryData">Specifies a byte array into which the paragraph's text is saved.</param>
		/// <param name="binaryStreamType">Specifies one of the BinaryStreamType values.</param>
		public void Save(out byte[] binaryData, BinaryStreamType binaryStreamType)
		{
			this.Save(out binaryData, binaryStreamType, new SaveSettings());
		}

		/// <summary>Saves the paragraph's text as a string with the specified format.</summary>
		/// <param name="stringData">Specifies a string into which the paragraph's text is saved.</param>
		/// <param name="stringStreamType">Specifies one of the StringStreamType values.</param>
		public void Save(out string stringData, StringStreamType stringStreamType)
		{
			this.Save(out stringData, stringStreamType, new SaveSettings());
		}

		/// <summary>Saves the paragraph's text in a byte array with the specified format and special settings.</summary>
		/// <param name="binaryData">Specifies a byte array into which the paragraph's text is saved.</param>
		/// <param name="binaryStreamType">Specifies one of the BinaryStreamType values.</param>
		/// <param name="saveSettings">Specifies a SaveSettings object with additional information and settings for the save operation.</param>
		public void Save(out byte[] binaryData, BinaryStreamType binaryStreamType, SaveSettings saveSettings)
		{
			saveSettings.TextPart = this.textPart_0;
			this.textControlCore_0.method_16(this.textPart_0, this.Start - 1, this.Length);
			saveSettings.method_3(out binaryData, binaryStreamType, this.textControlCore_0, Enum104.const_7);
			this.textControlCore_0.method_17(this.textPart_0);
		}

		/// <summary>Saves the paragraph's text as a string with the specified format and special settings.</summary>
		/// <param name="stringData">Specifies a string into which the paragraph's text is saved.</param>
		/// <param name="stringStreamType">Specifies one of the StringStreamType values.</param>
		/// <param name="saveSettings">Specifies a SaveSettings object with additional information and settings for the save operation.</param>
		public void Save(out string stringData, StringStreamType stringStreamType, SaveSettings saveSettings)
		{
			saveSettings.TextPart = this.textPart_0;
			this.textControlCore_0.method_16(this.textPart_0, this.Start - 1, this.Length);
			saveSettings.method_4(out stringData, stringStreamType, this.textControlCore_0, Enum104.const_7);
			this.textControlCore_0.method_17(this.textPart_0);
		}

		/// <summary>Selects the paragraph. The paragraph break characters bounding the paragraph are not selected.</summary>
		public void Select()
		{
			this.textControlCore_0.method_5(this.textPart_0, this.Start - 1, (this.int_0 == this.int_1) ? this.Length : (this.Length - 1));
		}

		private void method_0(Enum71 enum71_1)
		{
			if (this.int_0 == 0 || this.textControlCore_0 == null || !this.textControlCore_0.isHandleCreated)
			{
				return;
			}
			if ((enum71_1 & Enum71.const_4) != 0 && (this.enum71_0 & Enum71.const_4) == 0)
			{
				int[] array = new int[4];
				int[] array2 = array;
				if (this.textControlCore_0.method_40(this.textPart_0, 1915, this.int_0, array2) != 0)
				{
					this.int_5 = array2[0];
					this.int_2 = 1 + array2[1] - array2[0];
					this.int_6 = array2[2];
					this.int_3 = 1 + array2[3] - array2[2];
					this.enum71_0 |= Enum71.const_4;
				}
			}
			if ((enum71_1 & Enum71.const_5) != 0 && (this.enum71_0 & Enum71.const_5) == 0)
			{
				this.int_4 = this.textControlCore_0.method_29(this.textPart_0, 1916, this.int_0, 0);
				this.enum71_0 |= Enum71.const_5;
			}
			if ((enum71_1 & Enum71.const_6) != 0 && (this.enum71_0 & Enum71.const_6) == 0)
			{
				IntPtr intPtr = this.textControlCore_0.method_64(this.textPart_0, Enum83.const_247, (uint)this.int_0, 0);
				this.string_1 = string.Empty;
				if (intPtr != IntPtr.Zero)
				{
					this.string_1 = Marshal.PtrToStringBSTR(intPtr);
					Marshal.FreeBSTR(intPtr);
				}
				this.enum71_0 |= Enum71.const_6;
			}
			if ((enum71_1 & Enum71.const_7) != 0 && (this.enum71_0 & Enum71.const_7) == 0)
			{
				IntPtr intPtr2 = this.textControlCore_0.method_64(this.textPart_0, Enum83.const_248, (uint)this.int_0, 0);
				this.string_0 = string.Empty;
				if (intPtr2 != IntPtr.Zero)
				{
					this.string_0 = Marshal.PtrToStringBSTR(intPtr2);
					Marshal.FreeBSTR(intPtr2);
				}
				this.enum71_0 |= Enum71.const_7;
			}
		}
	}
}
