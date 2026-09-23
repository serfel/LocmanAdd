using System.Runtime.InteropServices;

namespace ns21
{
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode, Pack = 1, Size = 44)]
	internal struct Struct70
	{
		internal ushort ushort_0;

		internal short short_0;

		internal short short_1;

		internal short short_2;

		internal short short_3;

		internal short short_4;

		internal short short_5;

		internal short short_6;

		internal short short_7;

		internal uint uint_0;

		internal uint uint_1;

		internal uint uint_2;

		internal uint uint_3;

		internal uint uint_4;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
		private byte[] byte_0;

		internal Struct70(short short_8)
		{
			this.ushort_0 = 44;
			this.short_0 = -1;
			this.short_1 = -1;
			this.short_2 = -1;
			this.short_3 = -1;
			this.short_4 = -1;
			this.short_5 = -1;
			this.short_6 = -1;
			this.short_7 = -1;
			this.uint_0 = 2147483648u;
			this.uint_1 = 2147483648u;
			this.uint_2 = 2147483648u;
			this.uint_3 = 2147483648u;
			this.uint_4 = 0u;
			this.byte_0 = new byte[6];
		}
	}
}
