using System;

namespace TXTextControl
{
	/// <summary>Determines how the frame of an image, text frame, chart, barcode or drawing can be inserted in the text.</summary>
	[Flags]
	public enum FrameInsertionMode
	{
		/// <summary>The frame is inserted in the text as a single character.</summary>
		AsCharacter = 0x1,
		/// <summary>The frame is inserted at a certain geometrical location above the text. This means that the frame overwrites the text.</summary>
		AboveTheText = 0x80002,
		/// <summary>The frame is inserted at a certain geometrical location. The text stops at the top and continues at the bottom of the frame.</summary>
		DisplaceCompleteLines = 0x4,
		/// <summary>The frame is inserted at a certain geometrical location. The text flows around the frame and empty areas at the left and right side are filled.</summary>
		DisplaceText = 0x8,
		/// <summary>The frame is anchored to a paragraph and moved with the text.</summary>
		MoveWithText = 0x10000,
		/// <summary>The frame is fixed positioned on a page.</summary>
		FixedOnPage = 0x20000,
		/// <summary>The frame is inserted at a certain geometrical location below the text. This means that the text overwrites the frame.</summary>
		BelowTheText = 0x40002
	}
}
