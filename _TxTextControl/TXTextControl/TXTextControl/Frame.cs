using System;

namespace TXTextControl
{
	/// <summary>Determines which frameborders are visible of an image, text frame, chart, barcode or drawing.</summary>
	[Flags]
	public enum Frame
	{
		/// <summary>The paragraph has no frame.</summary>
		None = 0x8F0000,
		/// <summary>The paragraph has a left frame line.</summary>
		LeftLine = 0x1,
		/// <summary>The paragraph has a right frame line.</summary>
		RightLine = 0x2,
		/// <summary>The paragraph has a frame line at the top.</summary>
		TopLine = 0x4,
		/// <summary>The paragraph has frame line at the bottom.</summary>
		BottomLine = 0x8,
		/// <summary>The paragraph has a complete frame.</summary>
		Box = 0xF,
		/// <summary>The paragraph has a complete frame. If the following or the previous paragraph also has a frame, the frames are merged to a single frame.</summary>
		MergedBox = 0x8F
	}
}
