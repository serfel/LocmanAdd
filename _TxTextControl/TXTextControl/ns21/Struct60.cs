using System.Runtime.InteropServices;

namespace ns21
{
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode, Pack = 1, Size = 28)]
	internal struct Struct60
	{
		internal uint uint_0;

		internal uint uint_1;

		internal int int_0;

		internal string string_0;

		internal string string_1;

		internal Struct60(string string_2, string string_3, int int_1, uint uint_2)
		{
			this.uint_0 = 28u;
			this.uint_1 = uint_2;
			this.int_0 = int_1;
			this.string_0 = string_2;
			this.string_1 = string_3;
		}
	}
}
