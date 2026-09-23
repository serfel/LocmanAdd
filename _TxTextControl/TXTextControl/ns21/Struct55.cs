using System;
using System.Runtime.InteropServices;

namespace ns21
{
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode, Pack = 1, Size = 28)]
	internal struct Struct55
	{
		internal int int_0;

		internal uint uint_0;

		internal uint uint_1;

		internal IntPtr intptr_0;

		internal IntPtr intptr_1;

		internal Struct55(int int_1, string string_0)
		{
			this.int_0 = 0;
			this.uint_0 = (uint)int_1;
			if (string_0.Length > 0)
			{
				this.uint_1 = (uint)((string_0.Length + 1) * 2);
				this.intptr_0 = Marshal.StringToHGlobalUni(string_0);
			}
			else
			{
				this.uint_1 = 0u;
				this.intptr_0 = IntPtr.Zero;
			}
			this.intptr_1 = IntPtr.Zero;
		}

		internal Struct55(int int_1)
		{
			this.int_0 = 0;
			this.uint_0 = (uint)int_1;
			this.uint_1 = 0u;
			this.intptr_0 = IntPtr.Zero;
			this.intptr_1 = IntPtr.Zero;
		}

		internal Struct55(string string_0)
		{
			this.int_0 = 0;
			this.uint_0 = 0u;
			if (string_0.Length > 0)
			{
				this.uint_1 = (uint)((string_0.Length + 1) * 2);
				this.intptr_0 = Marshal.StringToHGlobalUni(string_0);
			}
			else
			{
				this.uint_1 = 0u;
				this.intptr_0 = IntPtr.Zero;
			}
			this.intptr_1 = IntPtr.Zero;
		}

		internal void method_0()
		{
			if (this.intptr_0 != IntPtr.Zero)
			{
				Marshal.FreeHGlobal(this.intptr_0);
			}
			this.intptr_0 = IntPtr.Zero;
			if (this.intptr_1 != IntPtr.Zero)
			{
				Marshal.FreeHGlobal(this.intptr_1);
			}
			this.intptr_1 = IntPtr.Zero;
		}
	}
}
