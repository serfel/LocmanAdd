using System;
using System.Runtime.InteropServices;
using TXTextControl;

namespace ns21
{
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode, Pack = 1, Size = 31)]
	internal struct Struct56
	{
		internal enum Enum120
		{
			const_0 = 1,
			const_1 = 4
		}

		internal ushort ushort_0;

		internal ushort ushort_1;

		internal ushort ushort_2;

		internal byte byte_0;

		internal uint uint_0;

		internal uint uint_1;

		internal IntPtr intptr_0;

		internal IntPtr intptr_1;

		internal Struct56(byte byte_1, string string_0)
		{
			this.ushort_0 = 31;
			this.ushort_1 = 0;
			this.ushort_2 = 0;
			this.byte_0 = byte_1;
			this.uint_0 = 0u;
			this.intptr_1 = IntPtr.Zero;
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
		}

		internal Struct56(byte byte_1, string[] string_0)
		{
			char[] array = KernelHelper.StringArray2CharArray(string_0);
			this.ushort_0 = 31;
			this.ushort_1 = 0;
			this.ushort_2 = 0;
			this.byte_0 = byte_1;
			this.uint_0 = 0u;
			this.intptr_1 = IntPtr.Zero;
			if (array != null)
			{
				this.uint_1 = (uint)(array.Length * 2);
				this.intptr_0 = Marshal.AllocHGlobal((int)this.uint_1);
				Marshal.Copy(array, 0, this.intptr_0, array.Length);
			}
			else
			{
				this.uint_1 = 0u;
				this.intptr_0 = IntPtr.Zero;
			}
		}

		internal Struct56(byte byte_1, uint uint_2)
		{
			this.ushort_0 = 31;
			this.ushort_1 = 0;
			this.ushort_2 = 0;
			this.byte_0 = byte_1;
			this.uint_0 = uint_2;
			this.uint_1 = 0u;
			this.intptr_0 = IntPtr.Zero;
			this.intptr_1 = IntPtr.Zero;
		}

		internal Struct56(byte byte_1, Struct43 struct43_0)
		{
			this.ushort_0 = 31;
			this.ushort_1 = 0;
			this.ushort_2 = 0;
			this.byte_0 = byte_1;
			this.uint_0 = 0u;
			this.uint_1 = struct43_0.UInt32_0;
			this.intptr_1 = IntPtr.Zero;
			this.intptr_0 = struct43_0.method_0();
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
