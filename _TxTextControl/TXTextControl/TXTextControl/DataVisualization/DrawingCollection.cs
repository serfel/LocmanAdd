using System;
using System.Drawing;
using ns21;

namespace TXTextControl.DataVisualization
{
	/// <summary>An instance of the DrawingCollection class contains all drawings in a document represented through objects of the type DataVisualization.DrawingFrame.</summary>
	public class DrawingCollection : FrameBaseCollection
	{
		internal DrawingCollection(TextControlCore textControlCore_0, TextPart iTextPart)
			: base(textControlCore_0, Enum108.const_9, iTextPart)
		{
		}

		public bool Add(DrawingFrame drawingFrame, int textPosition)
		{
			return this.method_0(drawingFrame, drawingFrame.Drawing, FrameInsertionMode.AsCharacter, textPosition, new Point(0, 0), 0, 0);
		}

		public bool Add(DrawingFrame drawingFrame, HorizontalAlignment alignment, int textPosition, FrameInsertionMode insertionMode)
		{
			if (insertionMode == FrameInsertionMode.AsCharacter)
			{
				throw new ArgumentOutOfRangeException(insertionMode.ToString());
			}
			if (alignment == HorizontalAlignment.Justify)
			{
				throw new ArgumentOutOfRangeException(alignment.ToString());
			}
			return this.method_0(drawingFrame, drawingFrame.Drawing, insertionMode | FrameInsertionMode.MoveWithText, textPosition, new Point(0, 0), 0, (int)alignment);
		}

		public bool Add(DrawingFrame drawingFrame, Point location, int textPosition, FrameInsertionMode insertionMode)
		{
			if (insertionMode == FrameInsertionMode.AsCharacter)
			{
				throw new ArgumentOutOfRangeException(insertionMode.ToString());
			}
			return this.method_0(drawingFrame, drawingFrame.Drawing, insertionMode | FrameInsertionMode.MoveWithText, textPosition, location, 0, 0);
		}

		public bool Add(DrawingFrame drawingFrame, int pageNumber, Point location, FrameInsertionMode insertionMode)
		{
			if (insertionMode == FrameInsertionMode.AsCharacter)
			{
				throw new ArgumentOutOfRangeException(insertionMode.ToString());
			}
			return this.method_0(drawingFrame, drawingFrame.Drawing, insertionMode, -1, location, pageNumber, 0);
		}

		public bool Add(DrawingFrame drawingFrame, Point location, FrameInsertionMode insertionMode)
		{
			if (insertionMode == FrameInsertionMode.AsCharacter)
			{
				throw new ArgumentOutOfRangeException(insertionMode.ToString());
			}
			return this.method_0(drawingFrame, drawingFrame.Drawing, insertionMode, -1, location, 0, 0);
		}

		public bool Add(DrawingFrame drawingFrame, FrameInsertionMode insertionMode)
		{
			return this.method_0(drawingFrame, drawingFrame.Drawing, insertionMode | (FrameInsertionMode)1048576, -1, new Point(0, 0), 0, 0);
		}

		internal bool method_0(DrawingFrame drawingFrame_0, object object_0, FrameInsertionMode frameInsertionMode_0, int int_0, Point point_0, int int_1, int int_2)
		{
			bool flag = false;
			if (object_0 == null)
			{
				throw new ArgumentNullException("component");
			}
			ControlProxy controlProxy = base.m_tx.control6_0.CreateControlProxy(object_0);
			controlProxy.Visible = false;
			IntPtr handle = controlProxy.Handle;
			int num = base.m_tx.method_30(Enum83.const_288, 0, 0);
			base.m_tx.control6_0.Add(num, controlProxy);
			if (!(flag = drawingFrame_0.method_1(base.m_tx, base.m_iTextPart, (int)frameInsertionMode_0, int_0, point_0, int_1, int_2, handle)) || num != drawingFrame_0.int_1)
			{
				base.m_tx.control6_0.Remove(num);
				if (flag)
				{
					base.m_tx.method_29(base.m_iTextPart, 1237, drawingFrame_0.int_1, 0);
				}
			}
			return flag;
		}

		/// <summary>Copies the elements of the collection to an array, starting at a particular index.</summary>
		/// <param name="array">Specifies the array to which to copy.</param>
		/// <param name="index">Specifies the index of the destination array at which to begin copying.</param>
		public override void CopyTo(Array array, int index)
		{
			DrawingCollection drawingCollection = new DrawingCollection(base.m_tx, base.m_iTextPart);
			foreach (DrawingFrame item in drawingCollection)
			{
				array.SetValue(item, index++);
			}
		}

		/// <summary>Deactivates the activated drawing and sets the input focus back to the text part that contains the drawing.</summary>
		public bool DeactivateItem()
		{
			return 0 != base.m_tx.method_29(base.m_iTextPart, 1974, 0, 0);
		}

		/// <summary>Returns the currently activated drawing. An activated drawing has the input focus and can be edited. The method returns null, if no drawing is activated.</summary>
		public DrawingFrame GetActivatedItem()
		{
			int num = base.m_tx.method_29(base.m_iTextPart, 1975, 0, 512);
			if (num != 0)
			{
				return new DrawingFrame(base.m_tx, base.m_iTextPart, num, base.m_tx.control6_0[num].Component);
			}
			return null;
		}

		/// <summary>Gets the drawing selected by the user.</summary>
		public DrawingFrame GetItem()
		{
			int num = base.m_tx.method_29(base.m_iTextPart, 1247, 0, 512);
			if (num != 0)
			{
				return new DrawingFrame(base.m_tx, base.m_iTextPart, num, base.m_tx.control6_0[num].Component);
			}
			return null;
		}

		/// <summary>Gets the drawing with the specified identifier. An id can be set with the ID property.</summary>
		/// <param name="id">Specifies the drawing's identifier.</param>
		public DrawingFrame GetItem(int int_0)
		{
			int num = base.m_tx.method_29(base.m_iTextPart, 1932, 512, int_0);
			if (num != 0)
			{
				return new DrawingFrame(base.m_tx, base.m_iTextPart, num, base.m_tx.control6_0[num].Component);
			}
			return null;
		}

		/// <summary>Gets the drawing with the specified name. A name can be set with the Name property.</summary>
		/// <param name="name">Specifies the drawing's name.</param>
		public DrawingFrame GetItem(string name)
		{
			int num = base.m_tx.method_37(base.m_iTextPart, 1933, 512, name);
			if (num != 0)
			{
				return new DrawingFrame(base.m_tx, base.m_iTextPart, num, base.m_tx.control6_0[num].Component);
			}
			return null;
		}

		public bool Remove(DrawingFrame drawingFrame)
		{
			return drawingFrame.method_2(base.m_iTextPart);
		}
	}
}
