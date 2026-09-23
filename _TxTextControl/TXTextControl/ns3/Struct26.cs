using System.Runtime.InteropServices;

namespace ns3
{
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	internal struct Struct26
	{
		internal int int_0;

		internal int int_1;

		internal int int_2;

		internal int int_3;

		internal int int_4;

		internal byte byte_0;

		internal byte byte_1;

		internal byte byte_2;

		internal byte byte_3;

		internal byte byte_4;

		internal byte byte_5;

		internal byte byte_6;

		internal byte byte_7;

		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
		internal string string_0;
	}
}
