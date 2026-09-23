namespace TXTextControl.Barcode
{
	/// <summary>Determines the type of barcode that is created by TX Barcode.</summary>
	public enum BarcodeType
	{
		/// <summary>QR Code is a two-dimensional barcode that encrypts up to 1270 ASCII values or 1850 alphanumeric values. By design TX Barcode switches encryption mode when necessary.</summary>
		QRCode = 1,
		/// <summary>Code128 is an alphanumeric barcode with high information density.</summary>
		Code128,
		/// <summary>EAN 13 is a barcode that encrypts 13 digits and is used for marking retail goods.</summary>
		EAN13,
		/// <summary>UPC-A barcode encrypts 12 digits and is very similar to EAN 13.</summary>
		UPCA,
		/// <summary>EAN 8 is derived from barcode type EAN13 and encrypts 8 digits.</summary>
		EAN8,
		/// <summary>2 of 5 is a barcode that encrypts digits only.</summary>
		Interleaved2of5,
		/// <summary>Postnet is a barcode type that encrypts postal zip codes.</summary>
		Postnet,
		/// <summary>3 of 9 is a barcode that encrypts alphanumeric values.</summary>
		Code39,
		/// <summary>AztecCode is a two-dimensional barcode that encrypts up to 1300 ASCII values.</summary>
		AztecCode,
		/// <summary>Intelligent Mail barcode is a barcode type that encrypts postal zip codes and it the successor of Postnet.</summary>
		IntelligentMail,
		/// <summary>Datamatrix is a two-dimensional barcode that encrypts up to 1301 ASCII values.</summary>
		Datamatrix,
		/// <summary>PDF 417 is a two-dimensional barcode that encrypts up to 1500 ASCII values.</summary>
		PDF417,
		/// <summary>MicroPDF is a two-dimensional barcode that encrypts up to 250 ASCII values.</summary>
		MicroPDF,
		/// <summary>Codabar is a barcode that encrypts digits and the characters '-', '$', ':', '/', '.' and '+'.</summary>
		Codabar,
		/// <summary>4State is a barcode that encrypts 8 digits.</summary>
		FourState,
		/// <summary>Code 11 is a barcode that encrypts up to 50 digits.</summary>
		Code11,
		/// <summary>Code 93 is a barcode that encrypts alphanumeric values and the characters '.', '$', '/', '+', and '%'.</summary>
		Code93,
		/// <summary>PLANET is a barcode that encrypts digits.</summary>
		PLANET,
		/// <summary>Royal Mail is a barcode that encrypts alphanumeric characters and characters ')' and '(' .</summary>
		RoyalMail,
		/// <summary>Maxicode is a two-dimensional barcode that encrypts strings with the following regular expression: "[0-9]{3}~[0-9]{3}~[0-9A-Z ]{6}|[0-9 ]{9}~[0-9A-Z*-.!""#$+%&amp;'\\(), -:;&lt;=&gt;?[]{}@^_|~\a\b\t\n\f\r]*" or "[)&gt;~[0-9]{2}~[0-9]{2}[0-9 ]{9}|[0-9A-Z ]{6}~[0-9]{3}~[0-9]{3}~[0-9A-Z*-.!""#$+%&amp;'\\(), -:;&lt;=&gt;?[]{}@^_|~\a\b\t\n\f\r]*"</summary>
		Maxicode
	}
}
