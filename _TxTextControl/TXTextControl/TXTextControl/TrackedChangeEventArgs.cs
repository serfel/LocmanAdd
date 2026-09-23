using System;
using System.Runtime.InteropServices;
using ns21;

namespace TXTextControl
{
	/// <summary>The event argument for a tracked change related event.</summary>
	public class TrackedChangeEventArgs : EventArgs
	{
		private TextControlCore textControlCore_0;

		private TextPart textPart_0;

		private int int_0;

		private TrackedChange trackedChange_0;

		/// <summary>Gets an object that represents the tracked change which causes the event.</summary>
		public TrackedChange TrackedChange
		{
			get
			{
				if (this.trackedChange_0 == null)
				{
					this.trackedChange_0 = new TrackedChange(this.textControlCore_0, this.textPart_0, 0, this.int_0);
				}
				return this.trackedChange_0;
			}
		}

		internal TrackedChangeEventArgs(TextControlCore textControlCore_1, TextPart iTextPart, int iInternalID, bool bDeleted)
		{
			this.textControlCore_0 = textControlCore_1;
			this.textPart_0 = iTextPart;
			this.int_0 = iInternalID;
			if (!bDeleted)
			{
				return;
			}
			Struct46 struct46_ = new Struct46(this.int_0, 0, 0, string.Empty, Enum52.const_2);
			try
			{
				if (this.textControlCore_0.method_58(this.textPart_0, Enum83.const_325, 0, ref struct46_) != IntPtr.Zero)
				{
					this.trackedChange_0 = new TrackedChange(this.int_0, (struct46_.intptr_0 != IntPtr.Zero) ? Marshal.PtrToStringBSTR(struct46_.intptr_0) : string.Empty, (ChangeKind)(struct46_.ushort_1 & 0x7000), DateTime.FromFileTimeUtc((long)(((ulong)struct46_.uint_8 << 32) + struct46_.uint_7)));
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
