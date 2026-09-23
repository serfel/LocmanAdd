using System;

namespace TXTextControl.DataVisualization
{
	/// <summary>The ChartEventArgs class provides data for all events that occur with charts.</summary>
	public class ChartEventArgs : EventArgs
	{
		private TextControlCore textControlCore_0;

		private TextPart textPart_0;

		private int int_0;

		private object object_0;

		/// <summary>Gets an object that represents the chart which causes the event.</summary>
		public ChartFrame ChartFrame => new ChartFrame(this.textControlCore_0, this.textPart_0, this.int_0, this.object_0);

		internal ChartEventArgs(TextControlCore textControlCore_1, TextPart iTextPart, int iObjectID, object chart)
		{
			this.textControlCore_0 = textControlCore_1;
			this.textPart_0 = iTextPart;
			this.int_0 = iObjectID;
			this.object_0 = chart;
		}
	}
}
