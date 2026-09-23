using System;
using System.Runtime.InteropServices;

namespace ns21
{
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode, Pack = 1, Size = 92)]
	internal struct Struct69
	{
		internal ushort ushort_0;

		internal ushort ushort_1;

		internal int int_0;

		internal int int_1;

		internal int int_2;

		internal Class429.Struct82 struct82_0;

		internal ushort ushort_2;

		internal ushort ushort_3;

		internal Class429.Struct83 struct83_0;

		internal uint uint_0;

		internal string string_0;

		internal int int_3;

		internal int int_4;

		internal IntPtr intptr_0;

		internal ushort ushort_4;

		internal int int_5;

		internal ushort ushort_5;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 12)]
		internal byte[] byte_0;

		internal Struct69(ushort ushort_6)
		{
			this.ushort_0 = ushort_6;
			this.ushort_1 = ushort.MaxValue;
			this.int_0 = 0;
			this.int_1 = int.MaxValue;
			this.int_2 = int.MaxValue;
			this.struct82_0 = new Class429.Struct82(0, 0);
			this.ushort_2 = 0;
			this.ushort_3 = 0;
			this.struct83_0 = new Class429.Struct83(-1, -1, -1, -1);
			this.uint_0 = 0u;
			this.string_0 = null;
			this.int_3 = 0;
			this.int_4 = 0;
			this.intptr_0 = IntPtr.Zero;
			this.ushort_4 = 0;
			this.int_5 = 0;
			this.ushort_5 = ushort.MaxValue;
			this.byte_0 = new byte[12];
		}

		internal Struct69(int int_6, int int_7, Class429.Struct82 struct82_1, int int_8, int int_9)
		{
			Enum109 @enum = int_9 switch
			{
				1 => Enum109.const_1, 
				2 => Enum109.const_2, 
				3 => Enum109.const_3, 
				_ => (Enum109)0, 
			};
			this.ushort_0 = 1600;
			this.ushort_1 = Struct69.smethod_0(int_6);
			this.int_0 = int_7;
			this.int_1 = struct82_1.int_0;
			this.int_2 = ((int_8 > 0) ? Class429.smethod_3(struct82_1.int_1, int_8) : struct82_1.int_1);
			this.struct82_0 = new Class429.Struct82(0, 0);
			this.ushort_2 = 100;
			this.ushort_3 = 100;
			this.struct83_0 = new Class429.Struct83(0, 0, 0, 0);
			this.uint_0 = (uint)@enum | ((int_8 > 0) ? 4096u : 0u) | ((((uint)int_6 & 0x10000u) != 0) ? 1024u : 0u) | ((((uint)int_6 & 0x100000u) != 0) ? 131072u : 0u);
			this.string_0 = null;
			this.int_3 = 0;
			this.int_4 = 0;
			this.intptr_0 = IntPtr.Zero;
			this.ushort_4 = 0;
			this.int_5 = (((int_6 & 0x40002) == 262146) ? int.MinValue : 0);
			this.ushort_5 = 0;
			this.byte_0 = new byte[12];
		}

		internal void method_0()
		{
			if (this.intptr_0 != IntPtr.Zero)
			{
				Marshal.FreeHGlobal(this.intptr_0);
			}
			this.intptr_0 = IntPtr.Zero;
		}

		internal static ushort smethod_0(int int_6)
		{
			ushort result = 0;
			for (int i = 0; i <= 3; i++)
			{
				if ((int_6 & (1 << i)) != 0)
				{
					result = (ushort)i;
				}
			}
			return result;
		}
	}
}
