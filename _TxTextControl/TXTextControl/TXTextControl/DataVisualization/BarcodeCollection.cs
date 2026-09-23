using System;
using System.Drawing;
using ns21;

namespace TXTextControl.DataVisualization
{
	/// <summary>An instance of the BarcodeCollection class contains all barcodes in a document represented through objects of the type DataVisualization.BarcodeFrame.</summary>
	public class BarcodeCollection : FrameBaseCollection
	{
		internal BarcodeCollection(TextControlCore textControlCore_0, TextPart iTextPart)
			: base(textControlCore_0, Enum108.const_8, iTextPart)
		{
		}

		public bool Add(BarcodeFrame barcodeFrame, int textPosition)
		{
			return this.method_0(barcodeFrame, barcodeFrame.Barcode, FrameInsertionMode.AsCharacter, textPosition, new Point(0, 0), 0, 0);
		}

		public bool Add(BarcodeFrame barcodeFrame, HorizontalAlignment alignment, int textPosition, FrameInsertionMode insertionMode)
		{
			if (insertionMode == FrameInsertionMode.AsCharacter)
			{
				throw new ArgumentOutOfRangeException(insertionMode.ToString());
			}
			if (alignment == HorizontalAlignment.Justify)
			{
				throw new ArgumentOutOfRangeException(alignment.ToString());
			}
			return this.method_0(barcodeFrame, barcodeFrame.Barcode, insertionMode | FrameInsertionMode.MoveWithText, textPosition, new Point(0, 0), 0, (int)alignment);
		}

		public bool Add(BarcodeFrame barcodeFrame, Point location, int textPosition, FrameInsertionMode insertionMode)
		{
			if (insertionMode == FrameInsertionMode.AsCharacter)
			{
				throw new ArgumentOutOfRangeException(insertionMode.ToString());
			}
			return this.method_0(barcodeFrame, barcodeFrame.Barcode, insertionMode | FrameInsertionMode.MoveWithText, textPosition, location, 0, 0);
		}

		public bool Add(BarcodeFrame barcodeFrame, int pageNumber, Point location, FrameInsertionMode insertionMode)
		{
			if (insertionMode == FrameInsertionMode.AsCharacter)
			{
				throw new ArgumentOutOfRangeException(insertionMode.ToString());
			}
			return this.method_0(barcodeFrame, barcodeFrame.Barcode, insertionMode, -1, location, pageNumber, 0);
		}

		public bool Add(BarcodeFrame barcodeFrame, Point location, FrameInsertionMode insertionMode)
		{
			if (insertionMode == FrameInsertionMode.AsCharacter)
			{
				throw new ArgumentOutOfRangeException(insertionMode.ToString());
			}
			return this.method_0(barcodeFrame, barcodeFrame.Barcode, insertionMode, -1, location, 0, 0);
		}

		public bool Add(BarcodeFrame barcodeFrame, FrameInsertionMode insertionMode)
		{
			return this.method_0(barcodeFrame, barcodeFrame.Barcode, insertionMode | (FrameInsertionMode)1048576, -1, new Point(0, 0), 0, 0);
		}

		internal bool method_0(BarcodeFrame barcodeFrame_0, object object_0, FrameInsertionMode frameInsertionMode_0, int int_0, Point point_0, int int_1, int int_2)
		{
			bool flag = false;
			if (object_0 == null)
			{
				throw new ArgumentNullException("component");
			}
			ControlProxy controlProxy = base.m_tx.control4_0.CreateControlProxy(object_0);
			controlProxy.Visible = false;
			IntPtr handle = controlProxy.Handle;
			int num = base.m_tx.method_30(Enum83.const_288, 0, 0);
			base.m_tx.control4_0.Add(num, controlProxy);
			if (!(flag = barcodeFrame_0.method_1(base.m_tx, base.m_iTextPart, (int)frameInsertionMode_0, int_0, point_0, int_1, int_2, handle)) || num != barcodeFrame_0.int_1)
			{
				base.m_tx.control4_0.Remove(num);
				if (flag)
				{
					base.m_tx.method_29(base.m_iTextPart, 1237, barcodeFrame_0.int_1, 0);
				}
			}
			return flag;
		}

		/// <summary>Copies the elements of the collection to an array, starting at a particular index.</summary>
		/// <param name="array">Specifies the array to which to copy.</param>
		/// <param name="index">Specifies the index of the destination array at which to begin copying.</param>
		public override void CopyTo(Array array, int index)
		{
			BarcodeCollection barcodeCollection = new BarcodeCollection(base.m_tx, base.m_iTextPart);
			foreach (BarcodeFrame item in barcodeCollection)
			{
				array.SetValue(item, index++);
			}
		}

		/// <summary>Gets the barcode selected by the user.</summary>
		public BarcodeFrame GetItem()
		{
			int num = base.m_tx.method_29(base.m_iTextPart, 1247, 0, 256);
			if (num != 0)
			{
				return new BarcodeFrame(base.m_tx, base.m_iTextPart, num, base.m_tx.control4_0[num].Component);
			}
			return null;
		}

		/// <summary>Gets the barcode with the specified identifier. An id can be set with the ID property.</summary>
		/// <param name="id">Specifies the barcode's identifier.</param>
		public BarcodeFrame GetItem(int int_0)
		{
			int num = base.m_tx.method_29(base.m_iTextPart, 1932, 256, int_0);
			if (num != 0)
			{
				return new BarcodeFrame(base.m_tx, base.m_iTextPart, num, base.m_tx.control4_0[num].Component);
			}
			return null;
		}

		/// <summary>Gets the barcode with the specified name. A name can be set with the Name property.</summary>
		/// <param name="name">Specifies the barcode's name.</param>
		public BarcodeFrame GetItem(string name)
		{
			int num = base.m_tx.method_37(base.m_iTextPart, 1933, 256, name);
			if (num != 0)
			{
				return new BarcodeFrame(base.m_tx, base.m_iTextPart, num, base.m_tx.control4_0[num].Component);
			}
			return null;
		}

		public bool Remove(BarcodeFrame barcodeFrame)
		{
			return barcodeFrame.method_2(base.m_iTextPart);
		}
	}
}
