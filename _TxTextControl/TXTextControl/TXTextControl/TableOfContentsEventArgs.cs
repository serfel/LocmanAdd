using System;
using System.Runtime.InteropServices;
using ns21;

namespace TXTextControl
{
	/// <summary>The TableOfContentsEventArgs class provides data for the TableOfContentsCreated, TableOfContentsDeleted, TableOfContentsEntered and TableOfContentsLeft events.</summary>
	public class TableOfContentsEventArgs : EventArgs
	{
		private TextControlCore textControlCore_0;

		private TextPart textPart_0;

		private int int_0;

		private TableOfContents tableOfContents_0;

		/// <summary>Gets an object that represents the table of contents which causes the event.</summary>
		public TableOfContents TableOfContents
		{
			get
			{
				if (this.tableOfContents_0 == null)
				{
					this.tableOfContents_0 = new TableOfContents(this.textControlCore_0, this.textPart_0, 0, this.int_0);
				}
				return this.tableOfContents_0;
			}
		}

		internal TableOfContentsEventArgs(TextControlCore textControlCore_1, TextPart iTextPart, int iInternalID, bool bDeleted)
		{
			this.textControlCore_0 = textControlCore_1;
			this.textPart_0 = iTextPart;
			this.int_0 = iInternalID;
			if (!bDeleted)
			{
				return;
			}
			Struct46 struct46_ = new Struct46(this.int_0, 0, 0, string.Empty, Enum52.const_4);
			try
			{
				if (this.textControlCore_0.method_58(this.textPart_0, Enum83.const_325, 0, ref struct46_) != IntPtr.Zero)
				{
					this.tableOfContents_0 = new TableOfContents(null, TextPart.Auto, 0, this.int_0);
					this.tableOfContents_0.Int32_0 = (int)struct46_.uint_3;
					if (struct46_.intptr_0 != IntPtr.Zero)
					{
						this.tableOfContents_0.Name = Marshal.PtrToStringBSTR(struct46_.intptr_0);
					}
					ushort ushort_ = Class429.smethod_5((int)struct46_.uint_9);
					this.tableOfContents_0.MinimumStructureLevel = Class429.smethod_9(ushort_);
					this.tableOfContents_0.MaximumStructureLevel = Class429.smethod_10(ushort_);
					TableOfContents.Enum81 @enum = (TableOfContents.Enum81)Class429.smethod_6((int)struct46_.uint_9);
					this.tableOfContents_0.HasLinks = (((@enum & TableOfContents.Enum81.const_0) != 0) ? true : false);
					this.tableOfContents_0.HasPageNumbers = (((@enum & TableOfContents.Enum81.const_1) != 0) ? true : false);
					this.tableOfContents_0.HasRightAlignedPageNumbers = (((@enum & TableOfContents.Enum81.const_2) != 0) ? true : false);
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
			}
		}
	}
}
