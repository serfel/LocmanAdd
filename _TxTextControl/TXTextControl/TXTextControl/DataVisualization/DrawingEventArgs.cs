using System;

namespace TXTextControl.DataVisualization
{
	/// <summary>The DrawingEventArgs class provides data for all events that occur with drawings.</summary>
	public class DrawingEventArgs : EventArgs
	{
		private TextControlCore textControlCore_0;

		private TextPart textPart_0;

		private int int_0;

		private object object_0;

		/// <summary>Gets an object that represents the drawing which causes the event.</summary>
		public DrawingFrame DrawingFrame => new DrawingFrame(this.textControlCore_0, this.textPart_0, this.int_0, this.object_0);

		internal DrawingEventArgs(TextControlCore textControlCore_1, TextPart iTextPart, int iObjectID, object drawing)
		{
			this.textControlCore_0 = textControlCore_1;
			this.textPart_0 = iTextPart;
			this.int_0 = iObjectID;
			this.object_0 = drawing;
		}
	}
}
