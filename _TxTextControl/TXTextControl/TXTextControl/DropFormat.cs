using System;

namespace TXTextControl
{
	[Flags]
	public enum DropFormat
	{
		RichTextFormat = 0x1,
		Image = 0x2,
		PlainText = 0x4,
		HTMLFormat = 0x8,
		All = 0xF
	}
}
