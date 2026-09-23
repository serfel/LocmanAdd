using System;

namespace TXTextControl
{
	/// <summary>Determines a certain text format that can be stored as a string.</summary>
	[Flags]
	public enum StringStreamType
	{
		/// <summary>Specifies HTML format (Hypertext Markup Language).</summary>
		HTMLFormat = 0x4,
		/// <summary>Specifies RTF format (Rich Text Format).</summary>
		RichTextFormat = 0x8,
		/// <summary>Specifies Text in Windows Unicode format (an end of a paragraph is marked with the control characters 13 and 10).</summary>
		PlainText = 0x10,
		/// <summary>Specifies XML format (Extensible Markup Language).</summary>
		XMLFormat = 0x80,
		/// <summary>Specifies CSS format (Cascading Style Sheet). This format can only be used in saving operations.</summary>
		CascadingStylesheet = 0x100
	}
}
