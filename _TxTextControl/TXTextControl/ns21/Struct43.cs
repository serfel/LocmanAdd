using System;
using System.Runtime.InteropServices;

namespace ns21
{
	internal struct Struct43
	{
		internal long long_0;

		internal string string_0;

		internal uint UInt32_0 => (uint)(8 + (this.string_0.Length + 1) * 2);

		internal Struct43(long long_1, string string_1)
		{
			this.long_0 = long_1;
			this.string_0 = string_1;
		}

		internal IntPtr method_0()
		{
			int length = this.string_0.Length;
			char[] array = new char[length + 1];
			IntPtr intPtr = IntPtr.Zero;
			try
			{
				intPtr = Marshal.AllocHGlobal((int)this.UInt32_0);
				Marshal.WriteInt64(intPtr, this.long_0);
				this.string_0.CopyTo(0, array, 0, length);
				array[length] = '\0';
				Marshal.Copy(array, 0, intPtr + 8, array.Length);
				return intPtr;
			}
			catch
			{
				return intPtr;
			}
		}
	}
}
