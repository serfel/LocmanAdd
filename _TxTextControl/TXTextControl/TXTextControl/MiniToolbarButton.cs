using System;

namespace TXTextControl
{
	[Flags]
	public enum MiniToolbarButton
	{
		LeftButton = 0x8,
		RightButton = 0x10,
		None = 0x1000
	}
}
