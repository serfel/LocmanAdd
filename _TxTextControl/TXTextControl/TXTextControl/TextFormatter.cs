using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using ns21;

namespace TXTextControl
{
	[EditorBrowsable(EditorBrowsableState.Never)]
	public sealed class TextFormatter
	{
		private IntPtr intptr_0 = IntPtr.Zero;

		private TextControlCore textControlCore_0;

		internal TextFormatter(TextControlCore textControlCore_1)
		{
			this.textControlCore_0 = textControlCore_1;
			this.intptr_0 = textControlCore_1.method_64(TextPart.Auto, Enum83.const_138, 0u, 0);
		}

		internal void method_0()
		{
			if (this.intptr_0 != IntPtr.Zero)
			{
				Class429.DestroyWindow(this.intptr_0);
				this.intptr_0 = IntPtr.Zero;
			}
		}

		public Rectangle MeasureText(byte[] byteData)
		{
			if (this.intptr_0 == IntPtr.Zero)
			{
				return new Rectangle(0, 0, 0, 0);
			}
			Class429.Struct83 struct83_ = default(Class429.Struct83);
			IntPtr intPtr = Marshal.AllocHGlobal(byteData.Length);
			Marshal.Copy(byteData, 0, intPtr, byteData.Length);
			int num = Class429.SendMessage_4(this.intptr_0, 1300, intPtr, ref struct83_);
			Marshal.FreeHGlobal(intPtr);
			if (num != 1)
			{
				throw new FilterException(FilterException.FilterError.Internal);
			}
			return struct83_.method_0();
		}
	}
}
