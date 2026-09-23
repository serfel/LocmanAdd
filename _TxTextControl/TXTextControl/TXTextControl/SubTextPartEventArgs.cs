using System;
using System.Drawing;
using System.Runtime.InteropServices;
using ns21;

namespace TXTextControl
{
	/// <summary>The event argument object for SubTextPart related events.</summary>
	public class SubTextPartEventArgs : EventArgs
	{
		private TextControlCore textControlCore_0;

		private TextPart textPart_0;

		private int int_0;

		private SubTextPart subTextPart_0;

		/// <summary>Gets an object that represents the subtextpart which causes the event.</summary>
		public SubTextPart SubTextPart
		{
			get
			{
				if (this.subTextPart_0 == null)
				{
					this.subTextPart_0 = new SubTextPart(this.textControlCore_0, this.textPart_0, 0, this.int_0);
				}
				return this.subTextPart_0;
			}
		}

		internal SubTextPartEventArgs(TextControlCore textControlCore_1, TextPart iTextPart, int iInternalID, bool bDeleted)
		{
			this.textControlCore_0 = textControlCore_1;
			this.textPart_0 = iTextPart;
			this.int_0 = iInternalID;
			if (!bDeleted)
			{
				return;
			}
			Struct46 struct46_ = new Struct46(this.int_0, 0, 0, string.Empty, Enum52.const_0);
			struct46_.ushort_5 |= 1;
			try
			{
				if (this.textControlCore_0.method_58(this.textPart_0, Enum83.const_325, 0, ref struct46_) != IntPtr.Zero)
				{
					this.subTextPart_0 = new SubTextPart((struct46_.intptr_0 != IntPtr.Zero) ? Marshal.PtrToStringBSTR(struct46_.intptr_0) : string.Empty, (int)struct46_.uint_3);
					Color color = Class429.smethod_2((int)struct46_.uint_2);
					if (struct46_.byte_0 < byte.MaxValue)
					{
						color = Color.FromArgb(struct46_.byte_0, color);
					}
					this.subTextPart_0.HighlightColor = color;
					this.subTextPart_0.HighlightMode = ((((uint)struct46_.ushort_1 & (true ? 1u : 0u)) != 0) ? HighlightMode.Activated : (((struct46_.ushort_1 & 2) == 0) ? HighlightMode.Never : HighlightMode.Always));
					if (struct46_.intptr_1 != IntPtr.Zero)
					{
						this.subTextPart_0.Data = Marshal.PtrToStringBSTR(struct46_.intptr_1);
					}
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
			finally
			{
				if (struct46_.intptr_0 != IntPtr.Zero)
				{
					Marshal.FreeBSTR(struct46_.intptr_0);
				}
				if (struct46_.intptr_1 != IntPtr.Zero)
				{
					Marshal.FreeBSTR(struct46_.intptr_1);
				}
			}
		}
	}
}
