using System.Runtime.InteropServices;

namespace ns21
{
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode, Pack = 1, Size = 20)]
	internal struct Struct44
	{
		internal int int_0;

		internal Class429.Struct83 struct83_0;

		internal Struct44(int int_1)
		{
			this.int_0 = int_1;
			this.struct83_0 = new Class429.Struct83(0, 0, 0, 0);
		}
	}
}
