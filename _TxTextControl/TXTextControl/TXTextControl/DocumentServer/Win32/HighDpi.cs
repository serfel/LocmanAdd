using System;
using ns3;

namespace DocumentServer.Win32
{
	internal static class HighDpi
	{
		internal static IntPtr GetWindowLong(IntPtr hWnd, int nIndex)
		{
			if (IntPtr.Size != 4)
			{
				return Class96.GetWindowLongPtr(hWnd, nIndex);
			}
			return Class96.GetWindowLong_1(hWnd, nIndex);
		}

		internal static bool AdjustWindowRect(IntPtr hWnd, ref Struct27 lpRect, bool bMenu, uint uDpi)
		{
			uint dwStyle = (uint)HighDpi.GetWindowLong(hWnd, -16).ToInt32();
			uint dwExStyle = (uint)HighDpi.GetWindowLong(hWnd, -20).ToInt32();
			return HighDpi.AdjustWindowRect(ref lpRect, dwStyle, bMenu, dwExStyle, uDpi);
		}

		internal static bool AdjustWindowRect(ref Struct27 lpRect, uint dwStyle, bool bMenu, uint dwExStyle, uint uDpi)
		{
			if (uDpi != 0)
			{
				try
				{
					return Class96.AdjustWindowRectExForDpi(ref lpRect, dwStyle, bMenu, dwExStyle, uDpi);
				}
				catch
				{
				}
			}
			return Class96.AdjustWindowRectEx(ref lpRect, dwStyle, bMenu, dwExStyle);
		}

		internal static uint GetDpiForWindow(IntPtr hWnd)
		{
			uint result = 0u;
			try
			{
				result = Class96.GetDpiForWindow(hWnd);
				return result;
			}
			catch
			{
				return result;
			}
		}
	}
}
