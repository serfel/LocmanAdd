using System.Runtime.InteropServices;

namespace ns21
{
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode, Pack = 1, Size = 166)]
	internal struct Struct61
	{
		internal ushort ushort_0;

		internal ushort ushort_1;

		internal short short_0;

		internal short short_1;

		internal sbyte sbyte_0;

		internal ushort ushort_2;

		internal ushort ushort_3;

		internal ushort ushort_4;

		internal byte byte_0;

		internal short short_2;

		internal char char_0;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
		internal byte[] byte_1;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
		internal char[] char_1;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
		internal char[] char_2;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
		internal char[] char_3;

		internal Struct61(ushort ushort_5)
		{
			this.ushort_0 = 166;
			this.ushort_1 = ushort_5;
			this.short_0 = -1;
			this.short_1 = -1;
			this.sbyte_0 = 0;
			this.ushort_2 = 0;
			this.ushort_3 = 0;
			this.ushort_4 = 0;
			this.byte_0 = 0;
			this.short_2 = 0;
			this.char_0 = '\0';
			this.byte_1 = new byte[2];
			this.char_1 = new char[20];
			this.char_2 = new char[20];
			this.char_3 = new char[32];
		}
	}
}
