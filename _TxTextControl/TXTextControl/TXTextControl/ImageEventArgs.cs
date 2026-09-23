using System;

namespace TXTextControl
{
	/// <summary>The ImageEventArgs class provides data for all events that occur with images.</summary>
	public class ImageEventArgs : EventArgs
	{
		private TextControlCore textControlCore_0;

		private TextPart textPart_0;

		private int int_0;

		/// <summary>Gets an object that represents the image which causes the event.</summary>
		public Image Image => new Image(this.textControlCore_0, this.textPart_0, this.int_0);

		internal ImageEventArgs(TextControlCore textControlCore_1, TextPart iTextPart, int iObjectID)
		{
			this.textControlCore_0 = textControlCore_1;
			this.textPart_0 = iTextPart;
			this.int_0 = iObjectID;
		}
	}
}
