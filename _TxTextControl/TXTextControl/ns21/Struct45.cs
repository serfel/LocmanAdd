using System.Runtime.InteropServices;

namespace ns21
{
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode, Pack = 1, Size = 66)]
	internal struct Struct45
	{
		internal ushort ushort_0;

		internal uint uint_0;

		internal uint uint_1;

		internal uint uint_2;

		internal uint uint_3;

		internal Class429.Struct83 struct83_0;

		internal Class429.Struct83 struct83_1;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
		private byte[] byte_0;

		internal void method_0()
		{
			this.ushort_0 = 66;
			this.uint_0 = 0u;
			this.uint_1 = 0u;
			this.struct83_0 = new Class429.Struct83(0, 0, 0, 0);
			this.struct83_1 = new Class429.Struct83(0, 0, 0, 0);
			this.byte_0 = new byte[16];
		}
	}
}
