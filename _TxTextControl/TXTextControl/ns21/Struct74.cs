using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;

namespace ns21
{
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode, Pack = 1)]
	internal struct Struct74
	{
		internal int int_0;

		internal int int_1;

		internal bool bool_0;

		internal int int_2;

		internal uint uint_0;

		[MarshalAs(UnmanagedType.Interface)]
		internal IDataObject idataObject_0;
	}
}
