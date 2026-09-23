using System;
using System.Runtime.InteropServices;
using Microsoft.Win32.SafeHandles;

namespace ns21
{
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode, Pack = 1)]
	internal struct Struct53
	{
		internal ushort ushort_0;

		internal SafeFileHandle safeFileHandle_0;

		internal IntPtr intptr_0;

		internal IntPtr intptr_1;

		internal IntPtr intptr_2;

		internal ushort ushort_1;

		internal IntPtr intptr_3;

		internal uint uint_0;

		internal Class429.Struct82 struct82_0;

		internal uint uint_1;

		internal int int_0;

		internal IntPtr intptr_4;

		internal Struct53(Enum104 enum104_0)
		{
			this.ushort_0 = 1000;
			this.safeFileHandle_0 = new SafeFileHandle(new IntPtr(-1), ownsHandle: true);
			this.intptr_0 = IntPtr.Zero;
			this.intptr_1 = IntPtr.Zero;
			this.intptr_2 = IntPtr.Zero;
			this.ushort_1 = 0;
			this.intptr_3 = IntPtr.Zero;
			this.uint_0 = (uint)enum104_0;
			this.struct82_0.int_0 = 0;
			this.struct82_0.int_1 = 0;
			this.uint_1 = 0u;
			this.int_0 = 0;
			if (Marshal.SizeOf(typeof(Struct54)) > 514)
			{
				throw new InsufficientMemoryException();
			}
			this.intptr_4 = Marshal.AllocHGlobal(514);
		}

		internal void method_0()
		{
			if (this.intptr_1 != IntPtr.Zero)
			{
				Marshal.FreeHGlobal(this.intptr_1);
			}
			this.intptr_1 = IntPtr.Zero;
			if (this.intptr_2 != IntPtr.Zero)
			{
				Marshal.FreeHGlobal(this.intptr_2);
			}
			this.intptr_2 = IntPtr.Zero;
			if (this.intptr_4 != IntPtr.Zero)
			{
				((Struct54)Marshal.PtrToStructure(this.intptr_4, typeof(Struct54))).method_0();
				Marshal.FreeHGlobal(this.intptr_4);
			}
			this.intptr_4 = IntPtr.Zero;
		}
	}
}
