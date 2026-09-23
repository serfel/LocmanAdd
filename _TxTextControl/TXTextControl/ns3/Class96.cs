using System;
using System.Runtime.InteropServices;

namespace ns3
{
	internal sealed class Class96
	{
		internal static ushort smethod_0(int int_0)
		{
			return (ushort)((uint)int_0 & 0xFFFFu);
		}

		[DllImport("shell32.dll")]
		public static extern IntPtr SHBrowseForFolder(ref Struct25 struct25_0);

		[DllImport("shell32.dll", CharSet = CharSet.Unicode)]
		public static extern bool SHGetPathFromIDList(IntPtr intptr_0, IntPtr intptr_1);

		[DllImport("user32.dll")]
		public static extern IntPtr SendMessage(HandleRef handleRef_0, uint uint_0, long long_0, IntPtr intptr_0);

		[DllImport("user32.dll", CharSet = CharSet.Auto, EntryPoint = "SendMessage")]
		public static extern IntPtr SendMessage_1(HandleRef handleRef_0, int int_0, int int_1, string string_0);

		[DllImport("Comdlg32.dll", CharSet = CharSet.Unicode)]
		public static extern bool GetOpenFileName([In][Out] Class94 class94_0);

		[DllImport("user32.dll")]
		internal static extern int GetSystemMetricsForDpi(int int_0, uint uint_0);

		[DllImport("Comdlg32.dll", CharSet = CharSet.Auto, SetLastError = true)]
		public static extern int ChooseColor([In][Out] Class95 class95_0);

		[DllImport("user32.dll", SetLastError = true)]
		public static extern int GetWindowLong(IntPtr intptr_0, int int_0);

		[DllImport("user32.dll")]
		public static extern int SetWindowLong(IntPtr intptr_0, int int_0, int int_1);

		[DllImport("user32.dll")]
		internal static extern bool AdjustWindowRectEx(ref Struct27 struct27_0, uint uint_0, bool bool_0, uint uint_1);

		[DllImport("user32.dll")]
		internal static extern bool AdjustWindowRectExForDpi(ref Struct27 struct27_0, uint uint_0, bool bool_0, uint uint_1, uint uint_2);

		[DllImport("user32.dll", CharSet = CharSet.Auto, EntryPoint = "GetWindowLong")]
		internal static extern IntPtr GetWindowLong_1(IntPtr intptr_0, int int_0);

		[DllImport("user32.dll", CharSet = CharSet.Auto)]
		internal static extern IntPtr GetWindowLongPtr(IntPtr intptr_0, int int_0);

		[DllImport("user32.dll")]
		internal static extern bool SetWindowPos(IntPtr intptr_0, IntPtr intptr_1, int int_0, int int_1, int int_2, int int_3, uint uint_0);

		[DllImport("user32.dll")]
		internal static extern uint GetDpiForWindow(IntPtr intptr_0);

		[DllImport("user32.dll", CharSet = CharSet.Auto)]
		internal static extern bool GetWindowRect(IntPtr intptr_0, ref Struct27 struct27_0);

		[DllImport("user32.dll", CharSet = CharSet.Auto)]
		public static extern bool SystemParametersInfoForDpi(int int_0, int int_1, ref Struct28 struct28_0, int int_2, uint uint_0);
	}
}
