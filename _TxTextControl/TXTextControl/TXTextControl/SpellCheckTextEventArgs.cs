using System;
using System.Globalization;

namespace TXTextControl
{
	/// <summary>The SpellCheckTextEventArgs class provides data for the TextControl.SpellCheckText and WPF.TextControl.SpellCheckText events.</summary>
	public class SpellCheckTextEventArgs : EventArgs
	{
		private string string_0;

		private MisspelledWord[] misspelledWord_0;

		private CultureInfo cultureInfo_0;

		/// <summary>Gets the culture of the text to check.</summary>
		public CultureInfo Culture => this.cultureInfo_0;

		/// <summary>Gets or sets an array of MisspelledWord objects.</summary>
		public MisspelledWord[] MisspelledWords
		{
			get
			{
				return this.misspelledWord_0;
			}
			set
			{
				this.misspelledWord_0 = value;
			}
		}

		/// <summary>Gets the text to check.</summary>
		public string Text => this.string_0;

		internal SpellCheckTextEventArgs(string strText, CultureInfo cultureInfo_1)
		{
			this.string_0 = strText;
			this.cultureInfo_0 = cultureInfo_1;
		}
	}
}
