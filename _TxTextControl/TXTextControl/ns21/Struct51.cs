using System;
using System.Runtime.InteropServices;

namespace ns21
{
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode, Pack = 1, Size = 136)]
	internal struct Struct51
	{
		internal ushort ushort_0;

		internal ushort ushort_1;

		internal ushort ushort_2;

		internal int int_0;

		internal int int_1;

		internal short short_0;

		internal short short_1;

		internal short short_2;

		internal short short_3;

		internal short short_4;

		internal short short_5;

		internal short short_6;

		internal short short_7;

		internal uint uint_0;

		internal byte byte_0;

		internal byte byte_1;

		internal short short_8;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
		private byte[] byte_2;

		private uint uint_1;

		internal uint uint_2;

		internal uint uint_3;

		internal uint uint_4;

		internal uint uint_5;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
		private byte[] byte_3;

		internal ushort ushort_3;

		internal IntPtr intptr_0;

		internal IntPtr intptr_1;

		internal IntPtr intptr_2;

		internal byte byte_4;

		internal ushort ushort_4;

		internal ushort ushort_5;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 11)]
		private byte[] byte_5;

		internal Struct51(int int_2, int int_3)
		{
			this.ushort_0 = (ushort)(112 + 3 * IntPtr.Size);
			this.ushort_1 = (ushort)int_2;
			this.ushort_2 = (ushort)int_3;
			this.int_0 = -1;
			this.int_1 = -1;
			this.short_0 = -1;
			this.short_1 = -1;
			this.short_2 = -1;
			this.short_3 = -1;
			this.short_4 = -1;
			this.short_5 = -1;
			this.short_6 = -1;
			this.short_7 = -1;
			this.uint_0 = 2147483648u;
			this.byte_0 = byte.MaxValue;
			this.byte_1 = 0;
			this.short_8 = -1;
			this.byte_2 = new byte[4];
			this.uint_1 = 0u;
			this.uint_2 = 2147483648u;
			this.uint_3 = 2147483648u;
			this.uint_4 = 2147483648u;
			this.uint_5 = 2147483648u;
			this.byte_3 = new byte[32];
			this.ushort_3 = 0;
			this.intptr_0 = IntPtr.Zero;
			this.intptr_1 = IntPtr.Zero;
			this.intptr_2 = IntPtr.Zero;
			this.byte_4 = byte.MaxValue;
			this.ushort_4 = 0;
			this.ushort_5 = 0;
			this.byte_5 = new byte[11];
		}
	}
}
