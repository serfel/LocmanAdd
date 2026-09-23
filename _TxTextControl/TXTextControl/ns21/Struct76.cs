using System.Drawing;
using System.Runtime.InteropServices;

namespace ns21
{
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto, Pack = 1, Size = 32)]
	internal struct Struct76
	{
		private ushort ushort_0;

		private Class429.Struct82 struct82_0;

		internal ushort ushort_1;

		internal ushort ushort_2;

		internal ushort ushort_3;

		internal Class429.Struct82 struct82_1;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
		private byte[] byte_0;

		internal Struct76(Point point_0)
		{
			this.ushort_0 = 32;
			this.struct82_0.int_0 = point_0.X;
			this.struct82_0.int_1 = point_0.Y;
			this.ushort_1 = 0;
			this.ushort_2 = 0;
			this.ushort_3 = 0;
			this.struct82_1.int_0 = 0;
			this.struct82_1.int_1 = 0;
			this.byte_0 = new byte[8];
		}
	}
}
