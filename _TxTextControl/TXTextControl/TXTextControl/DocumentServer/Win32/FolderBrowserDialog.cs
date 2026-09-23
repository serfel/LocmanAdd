using System;
using System.Runtime.InteropServices;
using ns3;

namespace DocumentServer.Win32
{
	internal static class FolderBrowserDialog
	{
		private static string m_initialPath;

		private static int OnBrowseEvent(IntPtr hWnd, int uMsg, IntPtr lParam, IntPtr lpData)
		{
			switch (uMsg)
			{
			case 2:
			{
				IntPtr intPtr = Marshal.AllocHGlobal(1024 * Marshal.SystemDefaultCharSize);
				if (Class96.SHGetPathFromIDList(lParam, intPtr))
				{
					Class96.SendMessage(new HandleRef(null, hWnd), 1128u, 0L, intPtr);
				}
				Marshal.FreeHGlobal(intPtr);
				break;
			}
			case 1:
				Class96.SendMessage_1(new HandleRef(null, hWnd), 1127, 1, FolderBrowserDialog.m_initialPath);
				break;
			}
			return 0;
		}

		private static string SelectPath(string caption, string initialPath, Enum15 flags, IntPtr parentHandle)
		{
			FolderBrowserDialog.m_initialPath = initialPath;
			string result = null;
			IntPtr intPtr = Marshal.AllocHGlobal(1024);
			IntPtr intPtr2 = IntPtr.Zero;
			Struct25 struct25_ = default(Struct25);
			struct25_.intptr_0 = parentHandle;
			struct25_.intptr_1 = IntPtr.Zero;
			struct25_.string_0 = initialPath;
			struct25_.string_1 = caption;
			struct25_.uint_0 = (uint)flags;
			struct25_.delegate0_0 = OnBrowseEvent;
			struct25_.intptr_2 = IntPtr.Zero;
			struct25_.int_0 = 0;
			try
			{
				intPtr2 = Class96.SHBrowseForFolder(ref struct25_);
				if (Class96.SHGetPathFromIDList(intPtr2, intPtr))
				{
					result = Marshal.PtrToStringAuto(intPtr);
				}
			}
			finally
			{
				Marshal.FreeCoTaskMem(intPtr2);
			}
			Marshal.FreeHGlobal(intPtr);
			return result;
		}

		public static string SelectFolder(string caption, string initialPath, IntPtr parentHandle)
		{
			return FolderBrowserDialog.SelectPath(caption, initialPath, Enum15.flag_6 | Enum15.flag_15, parentHandle);
		}
	}
}
