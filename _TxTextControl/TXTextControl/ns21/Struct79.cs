using System;
using System.Runtime.InteropServices;

namespace ns21
{
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode, Pack = 1, Size = 49)]
	internal struct Struct79
	{
		internal ushort ushort_0;

		internal short short_0;

		internal short short_1;

		internal uint uint_0;

		internal uint uint_1;

		internal sbyte sbyte_0;

		internal short short_2;

		internal ushort ushort_1;

		internal IntPtr intptr_0;

		internal sbyte sbyte_1;

		internal ushort ushort_2;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 19)]
		private byte[] byte_0;

		internal void method_0()
		{
			this.ushort_0 = 49;
			this.short_0 = -1;
			this.short_1 = -1;
			this.uint_0 = 2147483648u;
			this.uint_1 = 2147483648u;
			this.sbyte_0 = -1;
			this.short_2 = -1;
			this.ushort_1 = 0;
			this.intptr_0 = IntPtr.Zero;
			this.sbyte_1 = -1;
			this.ushort_2 = 0;
			this.byte_0 = new byte[19];
		}
	}
}
