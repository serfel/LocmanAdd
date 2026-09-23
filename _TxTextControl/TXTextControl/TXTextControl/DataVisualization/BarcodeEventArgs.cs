using System;

namespace TXTextControl.DataVisualization
{
	/// <summary>The BarcodeEventArgs class provides data for all events that occur with barcodes.</summary>
	public class BarcodeEventArgs : EventArgs
	{
		private TextControlCore textControlCore_0;

		private TextPart textPart_0;

		private int int_0;

		private object object_0;

		/// <summary>Gets an object that represents the barcode which causes the event.</summary>
		public BarcodeFrame BarcodeFrame => new BarcodeFrame(this.textControlCore_0, this.textPart_0, this.int_0, this.object_0);

		internal BarcodeEventArgs(TextControlCore textControlCore_1, TextPart iTextPart, int iObjectID, object barcode)
		{
			this.textControlCore_0 = textControlCore_1;
			this.textPart_0 = iTextPart;
			this.int_0 = iObjectID;
			this.object_0 = barcode;
		}
	}
}
