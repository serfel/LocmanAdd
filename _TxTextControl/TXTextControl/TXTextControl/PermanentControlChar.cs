using System;

namespace TXTextControl
{
	/// <summary>Defines a control character which is shown permanently on the screen.</summary>
	[Flags]
	public enum PermanentControlChar
	{
		/// <summary>Shows the control character of a space.</summary>
		Space = 0x1,
		/// <summary>Shows the control character of a tabstop.</summary>
		Tab = 0x2,
		/// <summary>Shows the control character for the end of a paragraph.</summary>
		ParagraphEnd = 0x4,
		/// <summary>Shows the control character of a forced line break.</summary>
		ForcedLineBreak = 0x8,
		/// <summary>Shows the anchor position of an image, text frame, chart, barcode or drawing.</summary>
		ObjectAnchor = 0x10,
		/// <summary>Marks a forced page break.</summary>
		ForcedPageBreak = 0x20,
		/// <summary>Marks a section break.</summary>
		SectionBreak = 0x40,
		/// <summary>Shows the control character of a hyphen.</summary>
		Hyphen = 0x80,
		/// <summary>Shows the control character of a non-breaking space.</summary>
		NonBreakingSpace = 0x100,
		/// <summary>Shows the control character for the end of a table cell.</summary>
		TableCellEnd = 0x200,
		/// <summary>Shows a dot in front of the first line of a paragraph with one of the pagination settings 'keep with next', 'page break before' and 'keep lines together'.</summary>
		Pagination = 0x400,
		/// <summary>Shows all control characters.</summary>
		All = 0x7FF
	}
}
