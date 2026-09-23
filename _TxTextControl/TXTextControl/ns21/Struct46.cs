using System;
using System.Runtime.InteropServices;

namespace ns21
{
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode, Pack = 1, Size = 97)]
	internal struct Struct46
	{
		internal ushort ushort_0;

		internal uint uint_0;

		internal uint uint_1;

		internal ushort ushort_1;

		internal uint uint_2;

		internal byte byte_0;

		internal uint uint_3;

		internal IntPtr intptr_0;

		internal uint uint_4;

		internal ushort ushort_2;

		internal uint uint_5;

		internal uint uint_6;

		internal ushort ushort_3;

		internal ushort ushort_4;

		internal uint uint_7;

		internal uint uint_8;

		internal uint uint_9;

		internal IntPtr intptr_1;

		internal ushort ushort_5;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 28)]
		private byte[] byte_1;

		internal Struct46(int int_0, int int_1, int int_2, string string_0, Enum52 enum52_0)
		{
			this.ushort_0 = (ushort)(51 + IntPtr.Size + 30 + IntPtr.Size);
			this.uint_0 = 0u;
			this.uint_1 = 0u;
			this.ushort_1 = 0;
			this.uint_2 = 0u;
			this.byte_0 = 0;
			this.uint_3 = (uint)int_2;
			this.intptr_0 = ((string_0 == null || string_0 == string.Empty) ? IntPtr.Zero : Marshal.StringToBSTR(string_0));
			this.uint_4 = (uint)int_1;
			this.ushort_2 = 0;
			this.uint_5 = 0u;
			this.uint_6 = 0u;
			this.ushort_3 = (ushort)enum52_0;
			this.ushort_4 = (ushort)int_0;
			this.uint_7 = 0u;
			this.uint_8 = 0u;
			this.uint_9 = uint.MaxValue;
			this.intptr_1 = IntPtr.Zero;
			this.ushort_5 = 0;
			this.byte_1 = new byte[28];
		}
	}
}
