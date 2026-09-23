using System.Runtime.InteropServices;

namespace ns21
{
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode, Pack = 1, Size = 20)]
	internal struct Struct59
	{
		internal uint uint_0;

		internal uint uint_1;

		internal int int_0;

		internal string string_0;

		internal Struct59(string string_1)
		{
			this.uint_0 = 20u;
			this.uint_1 = 0u;
			this.int_0 = -1;
			this.string_0 = string_1;
		}

		internal Struct59(string string_1, int int_1, uint uint_2)
		{
			this.uint_0 = 20u;
			this.uint_1 = uint_2;
			this.int_0 = int_1;
			this.string_0 = string_1;
		}
	}
}
