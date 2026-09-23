using System;
using System.Globalization;

namespace TXTextControl
{
	/// <summary>The HyphenateWordEventArgs class provides data for the TextControl.HyphenateWord, ServerTextControl.HyphenateWord and WPF.TextControl.HyphenateWord events.</summary>
	public class HyphenateWordEventArgs : EventArgs
	{
		private string string_0;

		private int int_0;

		private int int_1;

		private CultureInfo cultureInfo_0;

		/// <summary>Gets or sets the position at which the word should be divided.</summary>
		public int DividePos
		{
			get
			{
				return this.int_1;
			}
			set
			{
				this.int_1 = value;
			}
		}

		/// <summary>Gets the maximum dividing position.</summary>
		public int MaxDividePos => this.int_0;

		/// <summary>Gets the word to hyphenate.</summary>
		public string Word => this.string_0;

		/// <summary>Gets the culture of the word to hyphenate.</summary>
		public CultureInfo Culture => this.cultureInfo_0;

		internal HyphenateWordEventArgs(string strWord, int iMaxDividePos, int iDividePos, CultureInfo cultureInfo_1)
		{
			this.string_0 = strWord;
			this.int_0 = iMaxDividePos;
			this.int_1 = iDividePos;
			this.cultureInfo_0 = cultureInfo_1;
		}
	}
}
