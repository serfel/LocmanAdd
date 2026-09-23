using System;
using System.Drawing;
using System.Runtime.InteropServices;
using ns21;

namespace TXTextControl
{
	/// <summary>The event argument for editable region related events.</summary>
	public class EditableRegionEventArgs : EventArgs
	{
		private TextControlCore textControlCore_0;

		private TextPart textPart_0;

		private int int_0;

		private EditableRegion editableRegion_0;

		/// <summary>Gets an object that represents the editable region which causes the event.</summary>
		public EditableRegion EditableRegion
		{
			get
			{
				if (this.editableRegion_0 == null)
				{
					this.editableRegion_0 = new EditableRegion(this.textControlCore_0, this.textPart_0, 0, this.int_0);
				}
				return this.editableRegion_0;
			}
		}

		internal EditableRegionEventArgs(TextControlCore textControlCore_1, TextPart iTextPart, int iInternalID, bool bDeleted)
		{
			this.textControlCore_0 = textControlCore_1;
			this.textPart_0 = iTextPart;
			this.int_0 = iInternalID;
			if (!bDeleted)
			{
				return;
			}
			Struct46 struct46_ = new Struct46(this.int_0, 0, 0, string.Empty, Enum52.const_1);
			try
			{
				if (this.textControlCore_0.method_58(this.textPart_0, Enum83.const_325, 0, ref struct46_) != IntPtr.Zero)
				{
					this.editableRegion_0 = new EditableRegion(this.int_0, (struct46_.intptr_0 != IntPtr.Zero) ? Marshal.PtrToStringBSTR(struct46_.intptr_0) : string.Empty, (int)struct46_.uint_3);
					Color color = Class429.smethod_2((int)struct46_.uint_2);
					if (struct46_.byte_0 < byte.MaxValue)
					{
						color = Color.FromArgb(struct46_.byte_0, color);
					}
					this.editableRegion_0.HighlightColor = color;
					this.editableRegion_0.HighlightMode = ((((uint)struct46_.ushort_1 & (true ? 1u : 0u)) != 0) ? HighlightMode.Activated : (((struct46_.ushort_1 & 2) == 0) ? HighlightMode.Never : HighlightMode.Always));
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
