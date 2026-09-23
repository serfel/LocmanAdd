using System;

namespace TXTextControl.Barcode
{
	public sealed class TextValidatedEventArgs : EventArgs
	{
		private BarcodeType barcodeType_0;

		private string string_0;

		private bool bool_0;

		private string string_1;

		private bool bool_1;

		public BarcodeType BarcodeType => this.barcodeType_0;

		public string ErrorMessage
		{
			get
			{
				return this.string_1;
			}
			set
			{
				this.string_1 = value;
			}
		}

		public bool IsInvalidText
		{
			get
			{
				return this.bool_0;
			}
			set
			{
				this.bool_0 |= value;
			}
		}

		public string ValidatedText => this.string_0;

		public bool SuppressCheckSum
		{
			get
			{
				return this.bool_1;
			}
			set
			{
				this.bool_1 = value;
			}
		}

		internal TextValidatedEventArgs(BarcodeType barcodeType, string validatedText, bool isInvalidText, string errorMessage)
		{
			this.barcodeType_0 = barcodeType;
			this.string_0 = validatedText;
			this.bool_0 = isInvalidText;
			this.string_1 = errorMessage;
		}
	}
}
