using System;
using System.Drawing;
using ns21;

namespace TXTextControl
{
	/// <summary>An instance of the TextFrameCollection class contains all text frames in a Text Control document or part of the document represented through objects of the type TextFrame.</summary>
	public sealed class TextFrameCollection : FrameBaseCollection
	{
		internal TextFrameCollection(TextControlCore textControlCore_0, TextPart iTextPart)
			: base(textControlCore_0, Enum108.const_5, iTextPart)
		{
		}

		/// <summary>Inserts a text frame inline, which means that it is treated in the text like a single character. The frame is inserted at the specified text position.</summary>
		/// <param name="textFrame">Specifies the text frame to add.</param>
		/// <param name="textPosition">Specifies the text position at which the text frame is to be inserted.</param>
		public bool Add(TextFrame textFrame, int textPosition)
		{
			return textFrame.method_1(base.m_tx, base.m_iTextPart, 1, textPosition, new Point(0, 0), 0, 0, IntPtr.Zero);
		}

		/// <summary>Inserts a text frame which is anchored to the paragraph containing the specified text position. The frame has the specified horizontal alignment. TextFrameInsertionMode.FixedOnPage and TextFrameInsertionMode.AsCharacter cannot be specified with this overload.</summary>
		/// <param name="textFrame">Specifies the text frame to add.</param>
		/// <param name="alignment">Specifies the text frame's horizontal alignment.</param>
		/// <param name="textPosition">Specifies the text position at which the text frame is to be inserted.</param>
		/// <param name="insertionMode">Specifies how the text flow is handled.</param>
		public bool Add(TextFrame textFrame, HorizontalAlignment alignment, int textPosition, TextFrameInsertionMode insertionMode)
		{
			if (insertionMode == TextFrameInsertionMode.AsCharacter)
			{
				throw new ArgumentOutOfRangeException(insertionMode.ToString());
			}
			if (alignment == HorizontalAlignment.Justify)
			{
				throw new ArgumentOutOfRangeException(alignment.ToString());
			}
			return textFrame.method_1(base.m_tx, base.m_iTextPart, (int)(insertionMode | TextFrameInsertionMode.MoveWithText), textPosition, new Point(0, 0), 0, (int)alignment, IntPtr.Zero);
		}

		/// <summary>Inserts a text frame which is anchored to the paragraph containing the specified text position. The frame has the specified position relative to the paragraph containing its anchor position. TextFrameInsertionMode.FixedOnPage and TextFrameInsertionMode.AsCharacter cannot be specified with this overload.</summary>
		/// <param name="textFrame">Specifies the text frame to add.</param>
		/// <param name="location">Specifies the location, in twips, at which the text frame is to be inserted.</param>
		/// <param name="textPosition">Specifies the text position at which the text frame is to be inserted.</param>
		/// <param name="insertionMode">Specifies how the text flow is handled.</param>
		public bool Add(TextFrame textFrame, Point location, int textPosition, TextFrameInsertionMode insertionMode)
		{
			if (insertionMode == TextFrameInsertionMode.AsCharacter)
			{
				throw new ArgumentOutOfRangeException(insertionMode.ToString());
			}
			return textFrame.method_1(base.m_tx, base.m_iTextPart, (int)(insertionMode | TextFrameInsertionMode.MoveWithText), textPosition, location, 0, 0, IntPtr.Zero);
		}

		/// <summary>Inserts a text frame that has a fixed geometrical position in the document. This position is specified through a page number and a location on this page. TextFrameInsertionMode.MoveWithText and TextFrameInsertionMode.AsCharacter cannot be specified with this overload.</summary>
		/// <param name="textFrame">Specifies the text frame to add.</param>
		/// <param name="page">Specifies the number of a page beginning with 1 where the text frame is located.</param>
		/// <param name="location">Specifies the location, in twips, at which the text frame is to be inserted.</param>
		/// <param name="insertionMode">Specifies how the text flow is handled.</param>
		public bool Add(TextFrame textFrame, int pageNumber, Point location, TextFrameInsertionMode insertionMode)
		{
			if (insertionMode == TextFrameInsertionMode.AsCharacter)
			{
				throw new ArgumentOutOfRangeException(insertionMode.ToString());
			}
			return textFrame.method_1(base.m_tx, base.m_iTextPart, (int)insertionMode, -1, location, pageNumber, 0, IntPtr.Zero);
		}

		/// <summary>Inserts a text frame that has a fixed geometrical position in the document. This location is specified through a document position relative to the top left corner of the complete document. TextFrameInsertionMode.MoveWithText and TextFrameInsertionMode.AsCharacter cannot be specified with this overload.</summary>
		/// <param name="textFrame">Specifies the text frame to add.</param>
		/// <param name="location">Specifies the location, in twips, at which the text frame is to be inserted.</param>
		/// <param name="insertionMode">Specifies how the text flow is handled.</param>
		public bool Add(TextFrame textFrame, Point location, TextFrameInsertionMode insertionMode)
		{
			if (insertionMode == TextFrameInsertionMode.AsCharacter)
			{
				throw new ArgumentOutOfRangeException(insertionMode.ToString());
			}
			return textFrame.method_1(base.m_tx, base.m_iTextPart, (int)insertionMode, -1, location, 0, 0, IntPtr.Zero);
		}

		/// <summary>Inserts a text frame with the built-in mouse interface. The text frame's size is determined through the end-user. A cross cursor indicates where the text frame can be inserted. Changing the document or pressing the ESC key aborts the insertion process.</summary>
		/// <param name="textFrame">Specifies the text frame to add.</param>
		/// <param name="insertionMode">Specifies how the text flow is handled.</param>
		public bool Add(TextFrame textFrame, TextFrameInsertionMode insertionMode)
		{
			return textFrame.method_1(base.m_tx, base.m_iTextPart, (int)(insertionMode | (TextFrameInsertionMode)1048576), -1, new Point(0, 0), 0, 0, IntPtr.Zero);
		}

		/// <summary>Copies the elements of the collection to an array, starting at a particular index.</summary>
		/// <param name="array">Specifies the array to copy to.</param>
		/// <param name="index">Specifies the index of the destination array at which to begin copying.</param>
		public override void CopyTo(Array array, int index)
		{
			TextFrameCollection textFrameCollection = new TextFrameCollection(base.m_tx, base.m_iTextPart);
			foreach (TextFrame item in textFrameCollection)
			{
				array.SetValue(item, index++);
			}
		}

		/// <summary>Deactivates the activated text frame and sets the input focus back to the text part that contains the text frame.</summary>
		public bool DeactivateItem()
		{
			if (base.m_tx != null && base.m_tx.isHandleCreated)
			{
				return 0 != base.m_tx.method_29(base.m_iTextPart, 1889, 0, 0);
			}
			return false;
		}

		/// <summary>Returns the currently activated text frame. An activated text frame has the input focus and can be edited. The method returns null, if no text frame is activated.</summary>
		public TextFrame GetActivatedItem()
		{
			int num = base.m_tx.method_29(base.m_iTextPart, 1975, 0, 32);
			if (num != 0)
			{
				return new TextFrame(base.m_tx, base.m_iTextPart, num);
			}
			return null;
		}

		/// <summary>Gets the text frame selected by the user or null if no text frame is selected.</summary>
		public TextFrame GetItem()
		{
			int num = base.m_tx.method_29(base.m_iTextPart, 1247, 0, 32);
			if (num != 0)
			{
				return new TextFrame(base.m_tx, base.m_iTextPart, num);
			}
			return null;
		}

		/// <summary>Gets the text frame with the specified identifier.</summary>
		/// <param name="id">Specifies the text frame's identifier set with the ID property.</param>
		public TextFrame GetItem(int int_0)
		{
			int num = base.m_tx.method_29(base.m_iTextPart, 1932, 32, int_0);
			if (num != 0)
			{
				return new TextFrame(base.m_tx, base.m_iTextPart, num);
			}
			return null;
		}

		/// <summary>Gets the text frame with the specified name.</summary>
		/// <param name="name">Specifies the text frame's name set with the Name property.</param>
		public TextFrame GetItem(string name)
		{
			int num = base.m_tx.method_37(base.m_iTextPart, 1933, 32, name);
			if (num != 0)
			{
				return new TextFrame(base.m_tx, base.m_iTextPart, num);
			}
			return null;
		}

		/// <summary>Removes a text frame from a Text Control document.</summary>
		/// <param name="textFrame">Specifies the text frame to remove.</param>
		public bool Remove(TextFrame textFrame)
		{
			return textFrame.method_2(base.m_iTextPart);
		}
	}
}
