using System;
using System.Resources;

namespace TXTextControl
{
	/// <summary>The NumberFormatException class informs about an invalid syntax of a numberformat used to display a formula result.</summary>
	public class NumberFormatException : Exception
	{
		private int int_0;

		private FilterException.FilterError filterError_0;

		public override string Message
		{
			get
			{
				if (this.filterError_0 == FilterException.FilterError.NotWellFormed)
				{
					ResourceManager resourceManager = new ResourceManager(typeof(TextControlCore));
					return resourceManager.GetString("ERR_NUMBERFORMAT_SYNTAX");
				}
				return base.Message;
			}
		}

		/// <summary>Gets the one-based character index of the first invalid character in the numberformat string.</summary>
		public int CharacterIndex => this.int_0;

		internal NumberFormatException(FilterException.FilterError error, int iCharacterIndex)
		{
			this.filterError_0 = error;
			this.int_0 = iCharacterIndex;
		}
	}
}
