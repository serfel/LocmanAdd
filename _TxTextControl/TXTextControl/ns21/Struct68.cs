using System;
using System.Runtime.InteropServices;

namespace ns21
{
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	internal struct Struct68
	{
		internal ushort ushort_0;

		internal IntPtr intptr_0;

		internal IntPtr intptr_1;

		internal int int_0;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
		internal uint[] uint_0;
	}
}
