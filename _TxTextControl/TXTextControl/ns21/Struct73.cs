using System;
using System.Runtime.InteropServices;

namespace ns21
{
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode, Pack = 1, Size = 32)]
	internal struct Struct73
	{
		internal int int_0;

		internal int int_1;

		internal int int_2;

		internal int int_3;

		internal IntPtr intptr_0;

		internal IntPtr intptr_1;

		internal void method_0()
		{
			this.int_0 = 0;
			this.int_1 = 0;
			this.int_2 = 0;
			this.int_3 = 0;
			this.intptr_0 = IntPtr.Zero;
			this.intptr_1 = IntPtr.Zero;
		}

		internal void method_1()
		{
			if (this.intptr_0 != IntPtr.Zero)
			{
				Marshal.FreeBSTR(this.intptr_0);
			}
			this.intptr_0 = IntPtr.Zero;
			if (this.intptr_1 != IntPtr.Zero)
			{
				Marshal.FreeBSTR(this.intptr_1);
			}
			this.intptr_1 = IntPtr.Zero;
		}
	}
}
