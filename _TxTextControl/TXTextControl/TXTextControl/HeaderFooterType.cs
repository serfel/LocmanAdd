using System;

namespace TXTextControl
{
	/// <summary>Determines the type of a header or footer.</summary>
	[Flags]
	public enum HeaderFooterType
	{
		/// <summary>The object is a header. When an even header exists, the object represents the odd header. Otherwise it represents the header of all pages.</summary>
		Header = 0x1,
		/// <summary>The object represents a special header of the document's or section's first page.</summary>
		FirstPageHeader = 0x2,
		/// <summary>The object is a footer. When an even footer exists, this member represents the odd footer. Otherwise it represents the footer of all pages.</summary>
		Footer = 0x4,
		/// <summary>The object represents a special footer of the document's or section's first page.</summary>
		FirstPageFooter = 0x8,
		/// <summary>The object represents an even header.</summary>
		EvenHeader = 0x80,
		/// <summary>The object represents an even footer.</summary>
		EvenFooter = 0x8000,
		All = 0x808F
	}
}
