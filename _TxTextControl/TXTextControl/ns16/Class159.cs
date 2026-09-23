using System;
using System.Runtime.InteropServices;
using System.Text;

namespace ns16
{
	internal sealed class Class159
	{
		[ComImport]
		[Guid("2206CCB1-19C1-11D1-89E0-00C04FD7A829")]
		[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		internal interface IDataInitialize
		{
			void GetDataSource([In][MarshalAs(UnmanagedType.IUnknown)] object pUnkOuter, [In][MarshalAs(UnmanagedType.U4)] int dwClsCtx, [In][MarshalAs(UnmanagedType.LPWStr)] string pwszInitializationString, [In] ref Guid riid, [In][Out][MarshalAs(UnmanagedType.IUnknown)] ref object ppDataSource);

			void GetInitializationString([In][MarshalAs(UnmanagedType.IUnknown)] object pDataSource, [In][MarshalAs(UnmanagedType.I1)] bool fIncludePassword, [MarshalAs(UnmanagedType.LPWStr)] out string ppwszInitString);

			void Unused_CreateDBInstance();

			void Unused_CreateDBInstanceEx();

			void Unused_LoadStringFromStorage();

			void Unused_WriteStringToStorage();
		}

		[ComImport]
		[Guid("2206CCB0-19C1-11D1-89E0-00C04FD7A829")]
		[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		internal interface IDBPromptInitialize
		{
			void PromptDataSource([In][MarshalAs(UnmanagedType.IUnknown)] object pUnkOuter, [In] IntPtr hwndParent, [In][MarshalAs(UnmanagedType.U4)] int dwPromptOptions, [In][MarshalAs(UnmanagedType.U4)] int cSourceTypeFilter, [In] IntPtr rgSourceTypeFilter, [In][MarshalAs(UnmanagedType.LPWStr)] string pwszszzProviderFilter, [In] ref Guid riid, [In][Out][MarshalAs(UnmanagedType.IUnknown)] ref object ppDataSource);

			void Unused_PromptFileName();
		}

		[StructLayout(LayoutKind.Sequential)]
		internal class Class160
		{
			public int int_0 = Marshal.SizeOf(typeof(Class160));

			public int int_1;

			public int int_2;

			public IntPtr intptr_0;

			public int int_3;

			public Struct29 struct29_0;
		}

		internal struct Struct29
		{
			public int int_0;

			public int int_1;
		}

		internal static readonly UIntPtr uintptr_0 = new UIntPtr(2147483650u);

		internal const int int_0 = 256;

		internal const int int_1 = 512;

		internal const int int_2 = 1;

		internal static Guid guid_0 = new Guid("00000000-0000-0000-c000-000000000046");

		internal static Guid guid_1 = new Guid("2206CDB2-19C1-11d1-89E0-00C04FD7A829");

		internal static Guid guid_2 = new Guid("C8B522D0-5CF3-11ce-ADE5-00AA0044773D");

		internal static Guid guid_3 = new Guid("C8B522CD-5CF3-11ce-ADE5-00AA0044773D");

		internal const int int_3 = -2147217842;

		internal const int int_4 = 1;

		internal const int int_5 = 7;

		internal const int int_6 = 83;

		internal const int int_7 = 123;

		internal const int int_8 = 274;

		internal const int int_9 = 61824;

		internal const int int_10 = 1;

		internal const int int_11 = 1;

		internal const int int_12 = 3;

		internal const int int_13 = 2;

		internal const int int_14 = 16;

		internal const ushort ushort_0 = 2;

		internal const short short_0 = 100;

		private Class159()
		{
		}

		internal static bool smethod_0(short short_1)
		{
			return (short_1 & -2) == 0;
		}

		internal static short smethod_1(int int_15)
		{
			return (short)(int_15 & 0xFFFF);
		}

		internal static short smethod_2(int int_15)
		{
			return (short)((int_15 >> 16) & 0xFFFF);
		}

		[DllImport("odbc32.dll")]
		internal static extern short SQLAllocEnv(out IntPtr intptr_0);

		[DllImport("odbc32.dll")]
		internal static extern short SQLAllocConnect(IntPtr intptr_0, out IntPtr intptr_1);

		[DllImport("odbc32.dll", CharSet = CharSet.Unicode)]
		internal static extern short SQLDriverConnectW(IntPtr intptr_0, IntPtr intptr_1, string string_0, short short_1, StringBuilder stringBuilder_0, short short_2, out short short_3, ushort ushort_1);

		[DllImport("odbc32.dll")]
		internal static extern short SQLDisconnect(IntPtr intptr_0);

		[DllImport("odbc32.dll")]
		internal static extern short SQLFreeConnect(IntPtr intptr_0);

		[DllImport("odbc32.dll")]
		internal static extern short SQLFreeEnv(IntPtr intptr_0);

		[DllImport("odbccp32.dll", CharSet = CharSet.Unicode)]
		internal static extern bool SQLGetInstalledDrivers(char[] char_0, int int_15, ref int int_16);

		[DllImport("odbccp32.dll", CharSet = CharSet.Unicode)]
		internal static extern int SQLGetPrivateProfileString(string string_0, string string_1, string string_2, StringBuilder stringBuilder_0, int int_15, string string_3);

		[DllImport("kernel32")]
		[return: MarshalAs(UnmanagedType.Bool)]
		internal static extern bool IsWow64Process(IntPtr intptr_0, out bool bool_0);

		[DllImport("advapi32")]
		internal static extern int RegOpenKeyEx(UIntPtr uintptr_1, string string_0, int int_15, int int_16, out UIntPtr uintptr_2);

		[DllImport("advapi32")]
		internal static extern int RegQueryValueEx(UIntPtr uintptr_1, string string_0, uint uint_0, ref uint uint_1, IntPtr intptr_0, ref int int_15);

		[DllImport("advapi32.dll")]
		internal static extern int RegQueryInfoKey(UIntPtr uintptr_1, byte[] byte_0, IntPtr intptr_0, IntPtr intptr_1, out uint uint_0, IntPtr intptr_2, IntPtr intptr_3, out uint uint_1, IntPtr intptr_4, IntPtr intptr_5, IntPtr intptr_6, IntPtr intptr_7);

		[DllImport("advapi32.dll")]
		internal static extern int RegEnumValue(UIntPtr uintptr_1, uint uint_0, StringBuilder stringBuilder_0, ref uint uint_1, IntPtr intptr_0, IntPtr intptr_1, IntPtr intptr_2, IntPtr intptr_3);

		[DllImport("advapi32")]
		internal static extern uint RegCloseKey(UIntPtr uintptr_1);
	}
}
