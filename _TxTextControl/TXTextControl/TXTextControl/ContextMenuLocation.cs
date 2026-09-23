using System;

namespace TXTextControl
{
	/// <summary>Determines the location in the document where a context menu will be shown.</summary>
	[Flags]
	public enum ContextMenuLocation
	{
		/// <summary>The menu context is a text selection.</summary>
		TextSelection = 0x1,
		/// <summary>The menu context is the text input position.</summary>
		TextInputPosition = 0x2,
		/// <summary>The menu context is the top page margin which contains a header.</summary>
		Header = 0x4,
		/// <summary>The menu context is the top page margin which contains no header.</summary>
		NoHeader = 0x8,
		/// <summary>The menu context is the bottom page margin which contains a footer.</summary>
		Footer = 0x10,
		/// <summary>The menu context is the bottom page margin which contains no footer.</summary>
		NoFooter = 0x20,
		/// <summary>The menu context is the top or the bottom page margin.</summary>
		PageMargin = 0x40,
		/// <summary>The menu context is a PageNumberField.</summary>
		PageNumberField = 0x80,
		/// <summary>The menu context is a selected frame (text frame, image, chart or barcode).</summary>
		SelectedFrame = 0x100,
		/// <summary>The menu context is a text selection or a text input position in a Table.</summary>
		Table = 0x200,
		TextField = 0x400,
		/// <summary>The menu context is a MisspelledWord.</summary>
		MisspelledWord = 0x800,
		TableOfContents = 0x1000
	}
}
