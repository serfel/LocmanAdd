using System;
using System.Runtime.InteropServices;

namespace ns21
{
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode, Pack = 1, Size = 61)]
	internal struct Struct57
	{
		private ushort ushort_0;

		private string string_0;

		private uint uint_0;

		private byte byte_0;

		internal uint uint_1;

		internal uint uint_2;

		internal IntPtr intptr_0;

		internal ushort ushort_1;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 28)]
		private byte[] byte_1;

		internal Struct57(string string_1, uint uint_3, byte byte_2, int int_0)
		{
			this.ushort_0 = 61;
			this.string_0 = string_1;
			this.uint_0 = uint_3;
			this.byte_0 = byte_2;
			this.uint_1 = 0u;
			this.uint_2 = 0u;
			this.intptr_0 = IntPtr.Zero;
			this.ushort_1 = (ushort)int_0;
			this.byte_1 = new byte[28];
		}

		internal void method_0()
		{
			if (this.intptr_0 != IntPtr.Zero)
			{
				Marshal.FreeHGlobal(this.intptr_0);
			}
			this.intptr_0 = IntPtr.Zero;
		}
	}
}
