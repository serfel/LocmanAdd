using System;
using ns21;

namespace TXTextControl
{
	/// <summary>The event argument object for text field related events.</summary>
	public class TextFieldEventArgs : EventArgs
	{
		private TextControlCore textControlCore_0;

		private TextPart textPart_0;

		private int int_0;

		private TextField textField_0;

		internal int Int32_0 => this.int_0;

		/// <summary>Gets an object that represents the text field which causes the event.</summary>
		public TextField TextField
		{
			get
			{
				if (this.textField_0 == null)
				{
					this.textField_0 = this.method_0(this.textControlCore_0, this.textPart_0, this.int_0);
				}
				return this.textField_0;
			}
		}

		internal TextFieldEventArgs(TextControlCore textControlCore_1, TextPart iTextPart, int iFieldID, bool bCreateObject)
		{
			this.textControlCore_0 = textControlCore_1;
			this.textPart_0 = iTextPart;
			this.int_0 = iFieldID;
			if (bCreateObject)
			{
				this.textField_0 = this.method_0(textControlCore_1, iTextPart, iFieldID);
				this.textField_0.vmethod_0(bool_9: true);
			}
		}

		private TextField method_0(TextControlCore textControlCore_1, TextPart textPart_1, int int_1)
		{
			Struct56 struct56_ = new Struct56(0, 0u)
			{
				ushort_2 = 1
			};
			textControlCore_1.method_55(textPart_1, Enum83.const_177, int_1, ref struct56_);
			return TextFieldCollectionBase.CreateTextField(textControlCore_1, textPart_1, int_1, (Enum105)struct56_.byte_0);
		}
	}
}
