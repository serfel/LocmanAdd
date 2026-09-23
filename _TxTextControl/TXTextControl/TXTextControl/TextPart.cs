namespace TXTextControl
{
	/// <summary>Represents a part of the document, which can be the main text, a header or footer or a text frame.</summary>
	internal enum TextPart
	{
		Auto = 0,
		Header = 1,
		FirstPageHeader = 2,
		Footer = 4,
		FirstPageFooter = 8,
		MainText = 0x10,
		EvenHeader = 0x80,
		EvenFooter = 0x8000
	}
}
