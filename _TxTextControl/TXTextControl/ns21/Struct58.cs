using System.Runtime.InteropServices;

namespace ns21
{
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode, Pack = 1, Size = 41)]
	internal struct Struct58
	{
		private ushort ushort_0;

		internal uint uint_0;

		internal uint uint_1;

		internal byte byte_0;

		internal ushort ushort_1;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 28)]
		private byte[] byte_1;

		internal Struct58(uint uint_2)
		{
			this.ushort_0 = 41;
			this.uint_0 = uint_2;
			this.uint_1 = 2147483648u;
			this.byte_0 = 0;
			this.ushort_1 = 0;
			this.byte_1 = new byte[28];
		}
	}
}
