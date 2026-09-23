using System;

namespace TXTextControl
{
	/// <summary>Determines how text is appended to the document.</summary>
	[Flags]
	public enum AppendSettings
	{
		/// <summary>The loaded text is inserted at the end of the last paragraph of the existing document.</summary>
		None = 0x0,
		/// <summary>A new paragraph is created at the end of the document and the text is inserted in this paragraph.</summary>
		StartWithNewParagraph = 0x4,
		/// <summary>A new section is created at the end of the document and the text is inserted in this section.</summary>
		StartWithNewSection = 0x8
	}
}
