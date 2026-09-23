using System;
using System.ComponentModel;
using System.Globalization;
using ns21;

namespace TXTextControl
{
	/// <summary>The MisspelledWord class represents a misspelled word in a document's text.</summary>
	public class MisspelledWord
	{
		private int int_0;

		private int int_1;

		private int int_2;

		private TextControlCore textControlCore_0;

		private int int_3;

		private TextPart textPart_0;

		/// <summary>Gets the culture of the misspelled word.</summary>
		public CultureInfo Culture
		{
			get
			{
				this.method_0();
				if (this.int_2 != 0)
				{
					return new CultureInfo(this.int_2);
				}
				return null;
			}
		}

		/// <summary>Gets or sets a value which marks the misspelled word as duplicate.</summary>
		public bool IsDuplicate
		{
			get
			{
				if (this.textControlCore_0 != null)
				{
					int num = this.textControlCore_0.method_29(this.textPart_0, 1959, this.int_3, 0);
					if ((num & 2) == 0)
					{
						return false;
					}
					return true;
				}
				return false;
			}
			set
			{
				if (this.textControlCore_0 != null)
				{
					this.textControlCore_0.method_29(this.textPart_0, 1960, this.int_3, value ? 2 : 131072);
				}
			}
		}

		/// <summary>Gets or sets a value which marks the misspelled word as ignored.</summary>
		public bool IsIgnored
		{
			get
			{
				if (this.textControlCore_0 != null)
				{
					int num = this.textControlCore_0.method_29(this.textPart_0, 1959, this.int_3, 0);
					if ((num & 1) == 0)
					{
						return false;
					}
					return true;
				}
				return false;
			}
			set
			{
				if (this.textControlCore_0 != null)
				{
					this.textControlCore_0.method_29(this.textPart_0, 1960, this.int_3, value ? 1 : 65536);
				}
			}
		}

		/// <summary>Gets the length of a misspelled word.</summary>
		public int Length
		{
			get
			{
				this.method_0();
				return this.int_1;
			}
		}

		/// <summary>Gets the number of this misspelled word.</summary>
		public int Number => this.int_3;

		/// <summary>Gets the starting position of a misspelled word.</summary>
		public int Start
		{
			get
			{
				this.method_0();
				return this.int_0;
			}
		}

		/// <summary>Gets the text of the misspelled word.</summary>
		public string Text
		{
			get
			{
				if (this.method_0())
				{
					SaveSettings saveSettings = new SaveSettings();
					saveSettings.TextPart = this.textPart_0;
					this.textControlCore_0.method_16(this.textPart_0, this.int_0 - 1, this.int_1);
					saveSettings.method_4(out var string_, StringStreamType.PlainText, this.textControlCore_0, Enum104.const_7);
					this.textControlCore_0.method_17(this.textPart_0);
					return string_;
				}
				return null;
			}
		}

		/// <summary>Initializes a new instance of the MisspelledWord class with the specified starting position and length.</summary>
		/// <param name="start">Specifies the starting position of the misspelled word.</param>
		/// <param name="length">Specifies the length of the misspelled word.</param>
		public MisspelledWord(int start, int length)
		{
			if (start < 1 || length < 1)
			{
				throw new ArgumentOutOfRangeException();
			}
			this.int_0 = start;
			this.int_1 = length;
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		internal MisspelledWord(TextControlCore textControlCore_1, TextPart iTextPart, int iNumber)
		{
			this.textControlCore_0 = textControlCore_1;
			this.int_3 = iNumber;
			this.textPart_0 = iTextPart;
		}

		/// <summary>Selects the misspelled word in the text.</summary>
		public void Select()
		{
			if (this.method_0())
			{
				this.textControlCore_0.method_5(this.textPart_0, this.int_0 - 1, this.int_1);
			}
		}

		private bool method_0()
		{
			if (this.textControlCore_0 != null)
			{
				int[] array = new int[2];
				int num = this.textControlCore_0.method_40(this.textPart_0, 1947, this.int_3, array);
				if (num != 0)
				{
					this.int_0 = array[0];
					this.int_1 = 1 + array[1] - array[0];
					this.int_2 = Class429.smethod_6(num);
					return true;
				}
			}
			return false;
		}

		internal bool method_1(TextPart textPart_1, string string_0, bool bool_0)
		{
			if (this.int_3 != 0 && this.textControlCore_0 != null)
			{
				return 0 != this.textControlCore_0.method_37(textPart_1, bool_0 ? 1963 : 1948, this.int_3, string_0);
			}
			return false;
		}
	}
}
