using System;

namespace TXTextControl
{
	/// <summary>Determines how an Image can be inserted in the text.</summary>
	[Flags]
	public enum ImageInsertionMode
	{
		/// <summary>The image is inserted in the text as a single character.</summary>
		AsCharacter = 0x1,
		/// <summary>The image is inserted at a certain geometrical location above the text. This means that the image overwrites the text.</summary>
		AboveTheText = 0x80002,
		/// <summary>The image is inserted at a certain geometrical location. The text stops at the top and continues at the bottom of the image.</summary>
		DisplaceCompleteLines = 0x4,
		/// <summary>The image is inserted at a certain geometrical location. The text flows around the image and empty areas at the left and right side are filled.</summary>
		DisplaceText = 0x8,
		/// <summary>The image is anchored to a paragraph and moved with the text. This member cannot be used with the ImageCollection.Add methods.</summary>
		MoveWithText = 0x10000,
		/// <summary>The image is fixed positioned on a page. This member cannot be used with the ImageCollection.Add methods.</summary>
		FixedOnPage = 0x20000,
		/// <summary>The image is inserted at a certain geometrical location below the text. This means that the text overwrites the image.</summary>
		BelowTheText = 0x40002
	}
}
