using System;
using System.Runtime.InteropServices;

namespace ns21
{
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	internal struct Struct67
	{
		internal ushort ushort_0;

		internal ushort ushort_1;

		internal ushort ushort_2;

		internal uint uint_0;

		internal uint uint_1;

		internal IntPtr intptr_0;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
		internal uint[] uint_2;
	}
}
