using System;
using System.Runtime.InteropServices;
using ns21;

namespace TXTextControl
{
	/// <summary>The DocumentTargetEventArgs class provides data for the DocumentTargetCreated and DocumentTargetDeleted events.</summary>
	public class DocumentTargetEventArgs : EventArgs
	{
		private TextControlCore textControlCore_0;

		private TextPart textPart_0;

		private int int_0;

		private DocumentTarget documentTarget_0;

		/// <summary>Gets an object that represents the document target which causes the event.</summary>
		public DocumentTarget DocumentTarget
		{
			get
			{
				if (this.documentTarget_0 == null)
				{
					this.documentTarget_0 = new DocumentTarget(this.textControlCore_0, this.textPart_0, 0, this.int_0);
				}
				return this.documentTarget_0;
			}
		}

		internal DocumentTargetEventArgs(TextControlCore textControlCore_1, TextPart iTextPart, int iInternalID, bool bDeleted)
		{
			this.textControlCore_0 = textControlCore_1;
			this.textPart_0 = iTextPart;
			this.int_0 = iInternalID;
			if (!bDeleted)
			{
				return;
			}
			Struct46 struct46_ = new Struct46(this.int_0, 0, 0, string.Empty, Enum52.const_3);
			struct46_.ushort_5 |= 1;
			try
			{
				if (this.textControlCore_0.method_58(this.textPart_0, Enum83.const_325, 0, ref struct46_) != IntPtr.Zero)
				{
					this.documentTarget_0 = new DocumentTarget(null, TextPart.Auto, 0, this.int_0);
					this.documentTarget_0.Int32_0 = (int)struct46_.uint_3;
					if (struct46_.intptr_0 != IntPtr.Zero)
					{
						this.documentTarget_0.Name = Marshal.PtrToStringBSTR(struct46_.intptr_0);
					}
					if (struct46_.intptr_1 != IntPtr.Zero)
					{
						this.documentTarget_0.TargetName = Marshal.PtrToStringBSTR(struct46_.intptr_1);
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
