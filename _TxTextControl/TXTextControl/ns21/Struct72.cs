using System.Runtime.InteropServices;

namespace ns21
{
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode, Pack = 1, Size = 32)]
	internal struct Struct72
	{
		internal ushort ushort_0;

		internal ushort ushort_1;

		internal int int_0;

		[MarshalAs(UnmanagedType.LPWStr)]
		internal string string_0;

		[MarshalAs(UnmanagedType.LPWStr)]
		internal string string_1;

		internal int int_1;

		internal uint uint_0;

		internal Struct72(string string_2, int int_2, string string_3, int int_3, uint uint_1)
		{
			this.ushort_0 = 24;
			this.ushort_1 = 0;
			this.uint_0 = uint_1;
			this.string_0 = string_2;
			this.int_0 = int_2;
			this.string_1 = string_3;
			this.int_1 = int_3;
		}

		internal Struct72(string string_2, int int_2, string string_3, int int_3, uint uint_1, ushort ushort_2)
		{
			this.ushort_0 = 24;
			this.ushort_1 = ushort_2;
			this.uint_0 = uint_1;
			this.string_0 = string_2;
			this.int_0 = int_2;
			this.string_1 = string_3;
			this.int_1 = int_3;
		}
	}
}
