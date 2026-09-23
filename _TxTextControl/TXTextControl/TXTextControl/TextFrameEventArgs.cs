using System;

namespace TXTextControl
{
	/// <summary>The event argument for text frame related events.</summary>
	public class TextFrameEventArgs : EventArgs
	{
		private TextControlCore textControlCore_0;

		private TextPart textPart_0;

		private int int_0;

		/// <summary>Gets an object that represents the text frame which causes the event.</summary>
		public TextFrame TextFrame => new TextFrame(this.textControlCore_0, this.textPart_0, this.int_0);

		internal TextFrameEventArgs(TextControlCore textControlCore_1, TextPart iTextPart, int iObjectID)
		{
			this.textControlCore_0 = textControlCore_1;
			this.textPart_0 = ((iTextPart == TextPart.Auto) ? TextPart.MainText : iTextPart);
			this.int_0 = iObjectID;
		}
	}
}
