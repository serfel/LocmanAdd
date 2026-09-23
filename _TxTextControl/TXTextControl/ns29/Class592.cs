using System;
using System.Globalization;
using System.Runtime.InteropServices;

namespace ns29
{
	internal class Class592
	{
		private CultureInfo cultureInfo_0;

		private string string_0;

		internal CultureInfo CultureInfo_0 => this.cultureInfo_0;

		[DllImport("kernel32.dll", CharSet = CharSet.Unicode)]
		internal static extern int GetLocaleInfoW(int int_0, int int_1, IntPtr intptr_0, int int_2);

		internal Class592(CultureInfo cultureInfo_1)
		{
			this.cultureInfo_0 = cultureInfo_1;
			this.string_0 = this.method_0(this.cultureInfo_0);
		}

		public override string ToString()
		{
			return this.string_0;
		}

		private string method_0(CultureInfo cultureInfo_1)
		{
			IntPtr intPtr = Marshal.AllocHGlobal(160);
			Class592.GetLocaleInfoW(cultureInfo_1.LCID, 2, intPtr, 80);
			string result = Marshal.PtrToStringUni(intPtr);
			Marshal.FreeHGlobal(intPtr);
			return result;
		}
	}
}
