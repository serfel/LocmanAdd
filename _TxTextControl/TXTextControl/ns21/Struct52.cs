using System.Runtime.InteropServices;

namespace ns21
{
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode, Pack = 1, Size = 12)]
	internal struct Struct52
	{
		internal ushort ushort_0;

		internal ushort ushort_1;

		internal string string_0;

		internal Struct52(int int_0, int int_1, string string_1)
		{
			this.ushort_0 = (ushort)int_0;
			this.ushort_1 = (ushort)int_1;
			this.string_0 = string_1;
		}
	}
}
