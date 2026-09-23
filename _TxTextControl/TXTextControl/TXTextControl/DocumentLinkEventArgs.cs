using System;

namespace TXTextControl
{
	/// <summary>The event argument object for document nink related events.</summary>
	public class DocumentLinkEventArgs : EventArgs
	{
		private TextControlCore textControlCore_0;

		private TextPart textPart_0;

		private int int_0;

		/// <summary>Gets an object that represents the clicked document link.</summary>
		public DocumentLink DocumentLink => new DocumentLink(this.textControlCore_0, this.textPart_0, this.int_0);

		internal DocumentLinkEventArgs(TextControlCore textControlCore_1, TextPart iTextPart, int iFieldID)
		{
			this.textControlCore_0 = textControlCore_1;
			this.textPart_0 = iTextPart;
			this.int_0 = iFieldID;
		}
	}
}
