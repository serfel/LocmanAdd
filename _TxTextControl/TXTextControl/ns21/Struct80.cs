using System.Runtime.InteropServices;

namespace ns21
{
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode, Pack = 1)]
	internal struct Struct80
	{
		private ushort ushort_0;

		private ushort ushort_1;

		private uint uint_0;

		internal Struct80(int int_0)
		{
			this.ushort_0 = 8;
			this.ushort_1 = (ushort)int_0;
			this.uint_0 = 0u;
		}
	}
}
