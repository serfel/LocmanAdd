using System;

namespace TXTextControl
{
	/// <summary>The TextFormFieldEventArgs class provides data for the TextControl.FormFieldTextChanged event.</summary>
	public class TextFormFieldEventArgs : EventArgs
	{
		private TextControlCore textControlCore_0;

		private TextPart textPart_0;

		private int int_0;

		/// <summary>Gets an object representing the TextFormField that causes the event.</summary>
		public TextFormField TextFormField => new TextFormField(this.textControlCore_0, this.textPart_0, this.int_0);

		internal TextFormFieldEventArgs(TextControlCore textControlCore_1, TextPart iTextPart, int iFieldID)
		{
			this.textControlCore_0 = textControlCore_1;
			this.textPart_0 = iTextPart;
			this.int_0 = iFieldID;
		}
	}
}
