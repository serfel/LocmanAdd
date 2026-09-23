using System;

namespace TXTextControl
{
	/// <summary>Determines search options for the Find methods.</summary>
	[Flags]
	public enum FindOptions
	{
		/// <summary>The search starts at the end of the control's document and searches to the beginning of the document.</summary>
		Reverse = 0x1,
		/// <summary>Locates only instances of the search text that have the exact casing.</summary>
		MatchCase = 0x4,
		/// <summary>The search text, if found, is not highlighted.</summary>
		NoHighlight = 0x8,
		/// <summary>Does not display message boxes to inform about search results.</summary>
		NoMessageBox = 0x10,
		/// <summary>Locates only instances of the search text which are whole words.</summary>
		MatchWholeWord = 0x40
	}
}
