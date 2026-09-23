using System;
using System.Runtime.InteropServices;
using TXTextControl;

namespace ns21
{
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode, Pack = 1, Size = 46)]
	internal struct Struct47
	{
		private ushort ushort_0;

		private short short_0;

		private short short_1;

		private byte byte_0;

		internal ushort ushort_1;

		internal ushort ushort_2;

		internal uint uint_0;

		internal byte byte_1;

		internal ushort ushort_3;

		internal IntPtr intptr_0;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 28)]
		private byte[] byte_2;

		internal Struct47(short short_2, short short_3)
		{
			this.ushort_0 = 46;
			this.short_0 = short_2;
			this.short_1 = short_3;
			this.byte_0 = 1;
			this.ushort_1 = 0;
			this.ushort_2 = 1;
			this.uint_0 = (uint)Class429.smethod_0(TableOfContents.DefaultHighlightColor);
			this.byte_1 = TableOfContents.DefaultHighlightColor.A;
			this.ushort_3 = 0;
			this.intptr_0 = IntPtr.Zero;
			this.byte_2 = new byte[28];
		}
	}
}
