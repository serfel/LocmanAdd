using System;

namespace TXTextControl
{
	/// <summary>The SelectionFormFieldEventArgs class provides data for the TextControl.FormFieldSelectionChanged event.</summary>
	public class SelectionFormFieldEventArgs : EventArgs
	{
		private TextControlCore textControlCore_0;

		private TextPart textPart_0;

		private int int_0;

		/// <summary>Gets an object representing the SelectionFormField that causes the event.</summary>
		public SelectionFormField SelectionFormField => new SelectionFormField(this.textControlCore_0, this.textPart_0, this.int_0);

		internal SelectionFormFieldEventArgs(TextControlCore textControlCore_1, TextPart iTextPart, int iFieldID)
		{
			this.textControlCore_0 = textControlCore_1;
			this.textPart_0 = iTextPart;
			this.int_0 = iFieldID;
		}
	}
}
