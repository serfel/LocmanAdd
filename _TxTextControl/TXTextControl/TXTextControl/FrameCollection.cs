using System;
using ns21;

namespace TXTextControl
{
	/// <summary>An instance of the FrameCollection class contains all images, text frames and charts in a document.</summary>
	public sealed class FrameCollection : FrameBaseCollection
	{
		internal FrameCollection(TextControlCore textControlCore_0, TextPart iTextPart)
			: base(textControlCore_0, Enum108.const_10, iTextPart)
		{
		}

		/// <summary>Copies the elements of the collection to an array, starting at a particular index.</summary>
		/// <param name="array">Specifies the array to copy to.</param>
		/// <param name="index">Specifies the index of the destination array at which to begin copying.</param>
		public override void CopyTo(Array array, int index)
		{
			foreach (FrameBase item in this)
			{
				array.SetValue(item, index++);
			}
		}

		/// <summary>Gets the image, text frame, chart, barcode or drawing selected by the user.</summary>
		public FrameBase GetItem()
		{
			int num = base.m_tx.method_29(base.m_iTextPart, 1247, 0, 932);
			if (num == 0)
			{
				return null;
			}
			return base.GetFrame(num);
		}

		/// <summary>Gets the image, text frame, chart, barcode or drawing with the specified identifier. An identifier can be set with the FrameBase.ID property.</summary>
		/// <param name="id">Specifies the frame's identifier.</param>
		public FrameBase GetItem(int int_0)
		{
			int num = base.m_tx.method_29(base.m_iTextPart, 1932, 932, int_0);
			if (num == 0)
			{
				return null;
			}
			return base.GetFrame(num);
		}

		/// <summary>Gets the image, text frame, chart, barcode or drawing with the specified name. A name can be set with the FrameBase.Name property.</summary>
		/// <param name="name">Specifies the frame's name.</param>
		public FrameBase GetItem(string name)
		{
			int num = base.m_tx.method_37(base.m_iTextPart, 1933, 932, name);
			if (num == 0)
			{
				return null;
			}
			return base.GetFrame(num);
		}

		/// <summary>Removes a frame (image, text frame, chart, barcode or drawing) from a document.</summary>
		/// <param name="frame">Specifies the image, text frame, chart, barcode or drawing to remove.</param>
		public bool Remove(FrameBase frame)
		{
			return frame.method_2(base.m_iTextPart);
		}
	}
}
