using System;

namespace TXTextControl
{
	/// <summary>The CheckFormFieldEventArgs class provides data for the TextControl.FormFieldCheckChanged event.</summary>
	public class CheckFormFieldEventArgs : EventArgs
	{
		private TextControlCore textControlCore_0;

		private TextPart textPart_0;

		private int int_0;

		/// <summary>Gets an object representing the CheckFormField that causes the event.</summary>
		public CheckFormField CheckFormField => new CheckFormField(this.textControlCore_0, this.textPart_0, this.int_0);

		internal CheckFormFieldEventArgs(TextControlCore textControlCore_1, TextPart iTextPart, int iFieldID)
		{
			this.textControlCore_0 = textControlCore_1;
			this.textPart_0 = iTextPart;
			this.int_0 = iFieldID;
		}
	}
}
