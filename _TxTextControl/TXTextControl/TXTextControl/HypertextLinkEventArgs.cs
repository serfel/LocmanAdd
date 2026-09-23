using System;

namespace TXTextControl
{
	/// <summary>The event argument object for hypertext link related events.</summary>
	public class HypertextLinkEventArgs : EventArgs
	{
		private TextControlCore textControlCore_0;

		private TextPart textPart_0;

		private int int_0;

		/// <summary>Gets an object that represents the clicked hypertext link.</summary>
		public HypertextLink HypertextLink => new HypertextLink(this.textControlCore_0, this.textPart_0, this.int_0);

		internal HypertextLinkEventArgs(TextControlCore textControlCore_1, TextPart iTextPart, int iFieldID)
		{
			this.textControlCore_0 = textControlCore_1;
			this.textPart_0 = iTextPart;
			this.int_0 = iFieldID;
		}
	}
}
