namespace TXTextControl
{
	/// <summary>Determines how a TextFrame can be inserted in the text.</summary>
	public enum TextFrameInsertionMode
	{
		/// <summary>The text frame is inserted in the text as a single character.</summary>
		AsCharacter = 1,
		/// <summary>The text frame is inserted at a certain geometrical location above the text. This means that the text frame overwrites the text.</summary>
		AboveTheText = 524290,
		/// <summary>The text frame is inserted at a certain geometrical location. The text stops at the top and continues at the bottom of the text frame.</summary>
		DisplaceCompleteLines = 4,
		/// <summary>The text frame is inserted at a certain geometrical location. The text flows around the text frame and empty areas at the left and right side are filled.</summary>
		DisplaceText = 8,
		/// <summary>The text frame is anchored to a paragraph and moved with the text.</summary>
		MoveWithText = 0x10000,
		/// <summary>The text frame is fixed positioned on a page.</summary>
		FixedOnPage = 0x20000,
		/// <summary>The text frame is inserted at a certain geometrical location below the text. This means that the text overwrites the text frame.</summary>
		BelowTheText = 262146
	}
}
