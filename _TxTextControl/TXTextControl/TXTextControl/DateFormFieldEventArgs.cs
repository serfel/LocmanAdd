using System;

namespace TXTextControl
{
	/// <summary>The DateFormFieldEventArgs class provides data for the TextControl.FormFieldDateChanged event.</summary>
	public class DateFormFieldEventArgs : EventArgs
	{
		private TextControlCore textControlCore_0;

		private TextPart textPart_0;

		private int int_0;

		/// <summary>Gets an object representing the DateFormField that causes the event.</summary>
		public DateFormField DateFormField => new DateFormField(this.textControlCore_0, this.textPart_0, this.int_0);

		internal DateFormFieldEventArgs(TextControlCore textControlCore_1, TextPart iTextPart, int iFieldID)
		{
			this.textControlCore_0 = textControlCore_1;
			this.textPart_0 = iTextPart;
			this.int_0 = iFieldID;
		}
	}
}
