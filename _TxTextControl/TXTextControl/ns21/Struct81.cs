using System;
using System.Runtime.InteropServices;

namespace ns21
{
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode, Pack = 1)]
	internal struct Struct81
	{
		internal ushort ushort_0;

		internal ushort ushort_1;

		internal ushort ushort_2;

		internal ushort ushort_3;

		internal ushort ushort_4;

		internal IntPtr intptr_0;

		internal uint uint_0;

		internal long long_0;

		internal long long_1;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
		private byte[] byte_0;

		internal void method_0()
		{
			this.ushort_0 = 0;
			this.ushort_1 = 0;
			this.ushort_2 = 0;
			this.ushort_3 = 0;
			this.ushort_4 = 0;
			this.intptr_0 = new IntPtr(-1);
			this.uint_0 = 0u;
			this.long_0 = 0L;
			this.long_1 = 0L;
			this.byte_0 = new byte[32];
		}
	}
}
