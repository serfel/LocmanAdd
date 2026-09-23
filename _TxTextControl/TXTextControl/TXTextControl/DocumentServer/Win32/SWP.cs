using System;

namespace DocumentServer.Win32
{
	[Flags]
	public enum SWP : uint
	{
		NOSIZE = 0x1u,
		NOMOVE = 0x2u,
		NOZORDER = 0x4u,
		NOREDRAW = 0x8u,
		NOACTIVATE = 0x10u,
		FRAMECHANGED = 0x20u,
		SHOWWINDOW = 0x40u,
		HIDEWINDOW = 0x80u
	}
}
