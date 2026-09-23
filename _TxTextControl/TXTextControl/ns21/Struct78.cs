using System;
using System.Runtime.InteropServices;

namespace ns21
{
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto, Pack = 1, Size = 46)]
	internal struct Struct78
	{
		private ushort ushort_0;

		private ushort ushort_1;

		internal bool bool_0;

		internal ushort ushort_2;

		internal IntPtr intptr_0;

		internal int int_0;

		internal bool bool_1;

		internal bool bool_2;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 28)]
		private byte[] byte_0;

		internal Struct78(bool bool_3)
		{
			this.ushort_0 = 46;
			this.ushort_1 = (ushort)(bool_3 ? 1u : 0u);
			this.bool_0 = false;
			this.ushort_2 = 0;
			this.intptr_0 = IntPtr.Zero;
			this.int_0 = 0;
			this.bool_1 = false;
			this.bool_2 = false;
			this.byte_0 = new byte[28];
		}

		internal void method_0()
		{
			if (this.intptr_0 != IntPtr.Zero)
			{
				Marshal.FreeBSTR(this.intptr_0);
			}
			this.intptr_0 = IntPtr.Zero;
		}
	}
}
