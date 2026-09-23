using System;
using System.Runtime.InteropServices;

namespace ns21
{
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode, Pack = 1, Size = 78)]
	internal struct Struct50
	{
		internal ushort ushort_0;

		internal string string_0;

		internal bool bool_0;

		internal bool bool_1;

		internal uint uint_0;

		internal uint uint_1;

		internal uint uint_2;

		internal bool bool_2;

		internal string string_1;

		internal ushort ushort_1;

		internal ushort ushort_2;

		internal IntPtr intptr_0;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 24)]
		private byte[] byte_0;

		internal void method_0()
		{
			this.ushort_0 = 78;
			this.string_0 = string.Empty;
			this.bool_0 = true;
			this.bool_1 = true;
			this.uint_0 = 1u;
			this.uint_1 = 1u;
			this.uint_2 = 1u;
			this.bool_2 = true;
			this.string_1 = string.Empty;
			this.ushort_1 = 100;
			this.ushort_2 = 2;
			this.intptr_0 = IntPtr.Zero;
			this.byte_0 = new byte[24];
		}
	}
}
