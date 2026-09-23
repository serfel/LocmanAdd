using System;
using System.Runtime.InteropServices;

namespace ns21
{
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	internal struct Struct66
	{
		internal ushort ushort_0;

		internal ushort ushort_1;

		internal ushort ushort_2;

		internal uint uint_0;

		internal uint uint_1;

		internal ushort ushort_3;

		internal ushort ushort_4;

		internal ushort ushort_5;

		internal ushort ushort_6;

		internal IntPtr intptr_0;

		internal IntPtr intptr_1;

		internal ushort ushort_7;

		internal uint uint_2;

		internal ushort ushort_8;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 18)]
		internal uint[] uint_3;
	}
}
