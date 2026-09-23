using System;

namespace TXTextControl
{
	/// <summary>The AdaptFontEventArgs class provides data for the TextControl.AdaptFont, WPF.TextControl.AdaptFont and ServerTextControl.AdaptFont events.</summary>
	public class AdaptFontEventArgs : EventArgs
	{
		private string string_0;

		private string string_1;

		private string[] string_2;

		/// <summary>Gets the name of the original font which must be adapted.</summary>
		public string FontName => this.string_0;

		/// <summary>Gets or sets the adapted font.</summary>
		public string AdaptedFontName
		{
			get
			{
				return this.string_1;
			}
			set
			{
				this.string_1 = value;
			}
		}

		/// <summary>Gets a list of all fonts currently supported.</summary>
		public string[] SupportedFonts => this.string_2;

		internal AdaptFontEventArgs(string strFontName, string strAdaptedFontName, string[] arrSupportedFonts)
		{
			this.string_0 = strFontName;
			this.string_1 = strAdaptedFontName;
			this.string_2 = arrSupportedFonts;
		}
	}
}
