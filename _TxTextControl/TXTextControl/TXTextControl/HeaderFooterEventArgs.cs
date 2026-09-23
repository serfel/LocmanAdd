using System;

namespace TXTextControl
{
	/// <summary>The event argument header and footer related events.</summary>
	public class HeaderFooterEventArgs : EventArgs
	{
		private TextControlCore textControlCore_0;

		private HeaderFooterType headerFooterType_0 = HeaderFooterType.Header;

		private int int_0;

		/// <summary>Gets an object that represents the header or footer which causes the event.</summary>
		public HeaderFooter HeaderFooter => new HeaderFooter(this.textControlCore_0, this.headerFooterType_0, this.int_0, bConnectedToPrevious: false);

		internal HeaderFooterEventArgs(TextControlCore textControlCore_1, HeaderFooterType iHFType, int iSectionNumber)
		{
			this.textControlCore_0 = textControlCore_1;
			this.headerFooterType_0 = iHFType;
			this.int_0 = iSectionNumber;
		}
	}
}
