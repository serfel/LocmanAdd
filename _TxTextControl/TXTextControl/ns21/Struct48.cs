using System.Runtime.InteropServices;

namespace ns21
{
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode, Pack = 1, Size = 40)]
	internal struct Struct48
	{
		internal enum Enum118 : ushort
		{
			const_0 = 2,
			const_1 = 4,
			const_2 = 8,
			const_3 = 0x10,
			const_4 = 0x20,
			const_5 = 0x40,
			const_6 = 0x80,
			const_7 = 0x100
		}

		internal ushort ushort_0;

		internal ushort ushort_1;

		internal ushort ushort_2;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
		internal int[] int_0;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
		internal int[] int_1;

		internal ushort ushort_3;

		internal void method_0()
		{
			this.ushort_0 = 40;
			this.ushort_1 = 1;
			this.ushort_2 = 100;
			this.ushort_3 = 0;
			this.int_0 = new int[4];
			this.int_1 = new int[4];
		}
	}
}
