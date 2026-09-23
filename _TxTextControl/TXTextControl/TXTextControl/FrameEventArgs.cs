using System;

namespace TXTextControl
{
	/// <summary>The event argument for frame related events.</summary>
	public class FrameEventArgs : EventArgs
	{
		private TextControlCore textControlCore_0;

		private TextPart textPart_0;

		private int int_0;

		/// <summary>Gets an object that represents the frame which causes the event.</summary>
		public FrameBase Frame => new FrameCollection(this.textControlCore_0, this.textPart_0).GetFrame(this.int_0);

		internal FrameEventArgs(TextControlCore textControlCore_1, TextPart iTextPart, int iObjectID)
		{
			this.textControlCore_0 = textControlCore_1;
			this.textPart_0 = iTextPart;
			this.int_0 = iObjectID;
		}
	}
}
