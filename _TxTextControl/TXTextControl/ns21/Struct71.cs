using System;
using System.Runtime.InteropServices;

namespace ns21
{
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode, Pack = 1, Size = 206)]
	internal struct Struct71
	{
		internal ushort ushort_0;

		internal IntPtr intptr_0;

		internal ushort ushort_1;

		internal IntPtr intptr_1;

		internal ushort ushort_2;

		internal uint uint_0;

		internal ushort ushort_3;

		internal ushort ushort_4;

		internal uint uint_1;

		internal uint uint_2;

		internal ushort ushort_5;

		internal ushort ushort_6;

		internal ushort ushort_7;

		internal ushort ushort_8;

		internal ushort ushort_9;

		internal ushort ushort_10;

		internal ushort ushort_11;

		internal ushort ushort_12;

		internal uint uint_3;

		internal ushort ushort_13;

		internal short short_0;

		internal ushort ushort_14;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 42)]
		internal byte[] byte_0;

		internal ushort ushort_15;

		internal IntPtr intptr_2;

		internal IntPtr intptr_3;

		internal uint uint_4;

		internal uint uint_5;

		internal IntPtr intptr_4;

		internal uint uint_6;

		internal uint uint_7;

		internal IntPtr intptr_5;

		internal ushort ushort_16;

		internal short short_1;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
		internal byte[] byte_1;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 14)]
		internal byte[] byte_2;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 28)]
		internal byte[] byte_3;

		internal Struct71(string string_0)
		{
			this.ushort_0 = (ushort)(116 + 6 * IntPtr.Size + 42);
			this.intptr_0 = IntPtr.Zero;
			this.ushort_1 = 0;
			this.intptr_1 = IntPtr.Zero;
			this.ushort_2 = 0;
			this.uint_0 = 0u;
			this.ushort_3 = 0;
			this.ushort_4 = 0;
			this.uint_1 = 2147483648u;
			this.uint_2 = 2147483648u;
			this.ushort_5 = 0;
			this.ushort_6 = 32768;
			this.ushort_7 = 32768;
			this.ushort_8 = 32768;
			this.ushort_9 = 32768;
			this.ushort_10 = 32768;
			this.ushort_11 = 0;
			this.ushort_12 = 0;
			this.uint_3 = 0u;
			this.ushort_13 = 0;
			this.short_0 = -1;
			this.ushort_14 = 0;
			this.byte_0 = new byte[42];
			this.ushort_15 = 0;
			this.intptr_2 = IntPtr.Zero;
			this.intptr_3 = IntPtr.Zero;
			this.uint_4 = 0u;
			this.uint_5 = 0u;
			this.uint_6 = 2147483648u;
			this.uint_7 = 2147483648u;
			this.intptr_5 = IntPtr.Zero;
			if (Marshal.SizeOf(typeof(Struct61)) > 166)
			{
				throw new InsufficientMemoryException();
			}
			this.intptr_4 = Marshal.AllocHGlobal(166);
			this.ushort_16 = 0;
			this.short_1 = 0;
			this.byte_1 = new byte[4];
			this.byte_2 = new byte[14];
			this.byte_3 = new byte[28];
		}

		internal void method_0()
		{
			if (this.intptr_0 != IntPtr.Zero)
			{
				Marshal.FreeBSTR(this.intptr_0);
			}
			this.intptr_0 = IntPtr.Zero;
			if (this.intptr_1 != IntPtr.Zero)
			{
				Marshal.FreeBSTR(this.intptr_1);
			}
			this.intptr_1 = IntPtr.Zero;
			if (this.intptr_2 != IntPtr.Zero)
			{
				Marshal.FreeHGlobal(this.intptr_2);
			}
			this.intptr_2 = IntPtr.Zero;
			if (this.intptr_3 != IntPtr.Zero)
			{
				Marshal.FreeBSTR(this.intptr_3);
			}
			this.intptr_3 = IntPtr.Zero;
			if (this.intptr_4 != IntPtr.Zero)
			{
				Marshal.FreeHGlobal(this.intptr_4);
			}
			this.intptr_4 = IntPtr.Zero;
			if (this.intptr_5 != IntPtr.Zero)
			{
				Marshal.FreeBSTR(this.intptr_5);
			}
			this.intptr_5 = IntPtr.Zero;
		}
	}
}
