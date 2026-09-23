using System;
using System.Runtime.InteropServices;

namespace ns21
{
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto, Pack = 1, Size = 48)]
	internal struct Struct77
	{
		private ushort ushort_0;

		private IntPtr intptr_0;

		internal Class429.Struct82 struct82_0;

		internal uint uint_0;

		internal ushort ushort_1;

		internal uint uint_1;

		internal ushort ushort_2;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 18)]
		private byte[] byte_0;

		internal void method_0()
		{
			this.ushort_0 = 48;
			this.intptr_0 = IntPtr.Zero;
			this.struct82_0.int_0 = 0;
			this.struct82_0.int_1 = 0;
			this.uint_0 = 0u;
			this.ushort_1 = 0;
			this.uint_1 = 0u;
			this.ushort_2 = 0;
			this.byte_0 = new byte[18];
		}
	}
}
