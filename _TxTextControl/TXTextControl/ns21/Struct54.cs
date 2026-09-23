using System;
using System.Runtime.InteropServices;

namespace ns21
{
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode, Pack = 1, Size = 514)]
	internal struct Struct54
	{
		internal enum Enum119 : uint
		{
			const_0 = 1u,
			const_1 = 2u,
			const_2 = 4u,
			const_3 = 8u,
			const_4 = 0x10u,
			const_5 = 0x20u,
			const_6 = 0x40u,
			const_7 = 0x80u,
			const_8 = 0x100u,
			const_9 = 0x200u,
			const_10 = 0x400u,
			const_11 = 0x800u,
			const_12 = 0x1000u,
			const_13 = 0x10000u,
			const_14 = 0x20000u,
			const_15 = 0x40000u,
			const_16 = 0x80000u,
			const_17 = 0x100000u,
			const_18 = 0x200000u,
			const_19 = 0x400000u,
			const_20 = 0x800000u,
			const_21 = 0x1000000u,
			const_22 = 0x2000000u,
			const_23 = 0x4000000u,
			const_24 = 0x8000000u,
			const_25 = 0x10000000u,
			const_26 = 0x20000000u
		}

		internal ushort ushort_0;

		internal short short_0;

		internal IntPtr intptr_0;

		internal IntPtr intptr_1;

		internal int int_0;

		internal int int_1;

		internal short short_1;

		internal short short_2;

		internal short short_3;

		internal short short_4;

		internal IntPtr intptr_2;

		internal uint uint_0;

		internal int int_2;

		internal uint uint_1;

		internal uint uint_2;

		internal uint uint_3;

		internal ushort ushort_1;

		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
		internal string string_0;

		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
		internal string string_1;

		internal Enum119 enum119_0;

		internal uint uint_4;

		internal IntPtr intptr_3;

		internal IntPtr intptr_4;

		internal IntPtr intptr_5;

		internal IntPtr intptr_6;

		internal uint uint_5;

		internal IntPtr intptr_7;

		internal IntPtr intptr_8;

		internal ushort ushort_2;

		internal ushort ushort_3;

		internal ushort ushort_4;

		internal IntPtr intptr_9;

		internal uint uint_6;

		internal IntPtr intptr_10;

		internal IntPtr intptr_11;

		internal ushort ushort_5;

		internal IntPtr intptr_12;

		internal IntPtr intptr_13;

		internal IntPtr intptr_14;

		internal IntPtr intptr_15;

		internal ushort ushort_6;

		internal IntPtr intptr_16;

		internal IntPtr intptr_17;

		internal ushort ushort_7;

		internal IntPtr intptr_18;

		internal IntPtr intptr_19;

		internal IntPtr intptr_20;

		internal IntPtr intptr_21;

		internal IntPtr intptr_22;

		internal IntPtr intptr_23;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 124)]
		private byte[] byte_0;

		internal Struct54(short short_5)
		{
			this.ushort_0 = 0;
			this.short_0 = short_5;
			this.intptr_0 = IntPtr.Zero;
			this.intptr_1 = IntPtr.Zero;
			this.int_0 = 0;
			this.int_1 = 0;
			this.short_1 = -1;
			this.short_2 = -1;
			this.short_3 = -1;
			this.short_4 = -1;
			this.intptr_2 = IntPtr.Zero;
			this.uint_0 = 2147483648u;
			this.int_2 = 0;
			this.uint_1 = 2147483648u;
			this.uint_2 = 2147483648u;
			this.uint_3 = 2147483648u;
			this.ushort_1 = 10;
			this.string_0 = string.Empty;
			this.string_1 = string.Empty;
			this.enum119_0 = (Enum119)704644288u;
			this.uint_4 = 0u;
			this.intptr_3 = IntPtr.Zero;
			this.intptr_4 = IntPtr.Zero;
			this.intptr_5 = IntPtr.Zero;
			this.intptr_6 = IntPtr.Zero;
			this.uint_5 = 0u;
			this.intptr_7 = IntPtr.Zero;
			this.intptr_8 = IntPtr.Zero;
			this.ushort_2 = 0;
			this.ushort_3 = 0;
			this.ushort_4 = 0;
			this.intptr_9 = IntPtr.Zero;
			this.uint_6 = 0u;
			this.intptr_10 = IntPtr.Zero;
			this.intptr_11 = IntPtr.Zero;
			this.ushort_5 = 0;
			this.intptr_12 = IntPtr.Zero;
			this.intptr_13 = IntPtr.Zero;
			this.intptr_14 = IntPtr.Zero;
			this.intptr_15 = IntPtr.Zero;
			this.ushort_6 = 0;
			this.intptr_16 = IntPtr.Zero;
			this.intptr_17 = IntPtr.Zero;
			this.ushort_7 = 0;
			this.intptr_18 = IntPtr.Zero;
			this.intptr_19 = IntPtr.Zero;
			this.intptr_20 = IntPtr.Zero;
			this.intptr_21 = IntPtr.Zero;
			this.intptr_22 = IntPtr.Zero;
			this.intptr_23 = IntPtr.Zero;
			this.byte_0 = new byte[124];
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
			if (this.intptr_4 != IntPtr.Zero)
			{
				Marshal.FreeBSTR(this.intptr_4);
			}
			this.intptr_4 = IntPtr.Zero;
			if (this.intptr_8 != IntPtr.Zero)
			{
				Marshal.FreeHGlobal(this.intptr_8);
			}
			this.intptr_8 = IntPtr.Zero;
			if (this.intptr_11 != IntPtr.Zero)
			{
				Marshal.FreeBSTR(this.intptr_11);
			}
			this.intptr_11 = IntPtr.Zero;
			if (this.intptr_14 != IntPtr.Zero)
			{
				Marshal.FreeBSTR(this.intptr_14);
			}
			this.intptr_14 = IntPtr.Zero;
			if (this.intptr_15 != IntPtr.Zero)
			{
				Marshal.FreeHGlobal(this.intptr_15);
			}
			this.intptr_15 = IntPtr.Zero;
			if (this.intptr_18 != IntPtr.Zero)
			{
				Marshal.FreeHGlobal(this.intptr_18);
			}
			this.intptr_18 = IntPtr.Zero;
			if (this.intptr_19 != IntPtr.Zero)
			{
				Marshal.FreeHGlobal(this.intptr_19);
			}
			this.intptr_19 = IntPtr.Zero;
			if (this.intptr_20 != IntPtr.Zero)
			{
				Marshal.FreeHGlobal(this.intptr_20);
			}
			this.intptr_20 = IntPtr.Zero;
			if (this.intptr_21 != IntPtr.Zero)
			{
				Marshal.FreeHGlobal(this.intptr_21);
			}
			this.intptr_21 = IntPtr.Zero;
			if (this.intptr_22 != IntPtr.Zero)
			{
				Marshal.FreeBSTR(this.intptr_22);
			}
			this.intptr_22 = IntPtr.Zero;
			if (this.intptr_23 != IntPtr.Zero)
			{
				Marshal.FreeHGlobal(this.intptr_23);
			}
			this.intptr_23 = IntPtr.Zero;
		}
	}
}
