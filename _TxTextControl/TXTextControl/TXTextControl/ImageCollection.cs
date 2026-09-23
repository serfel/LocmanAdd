using System;
using System.Drawing;
using System.Runtime.InteropServices;
using ns21;

namespace TXTextControl
{
	/// <summary>Contains all images of a Text Control document or part of the document.</summary>
	public sealed class ImageCollection : FrameBaseCollection
	{
		private enum Enum65
		{
			const_0,
			const_1,
			const_2,
			const_3
		}

		/// <summary>Gets all available filters for importing images.</summary>
		public string ImportFilters => this.method_1(Enum65.const_2);

		/// <summary>Gets all available filters for exporting images.</summary>
		public string ExportFilters => this.method_1(Enum65.const_3);

		internal ImageCollection(TextControlCore textControlCore_0, TextPart iTextPart)
			: base(textControlCore_0, Enum108.const_2, iTextPart)
		{
		}

		/// <summary>Inserts an image inline, which means that it is treated in the text like a single character. The image is inserted at the current text input position. A file open dialog box is shown to get the image's file name and filter.</summary>
		public bool Add()
		{
			Image image = new Image();
			if (this.method_0(image))
			{
				return image.method_1(base.m_tx, base.m_iTextPart, 1, -1, new Point(0, 0), 0, 0, IntPtr.Zero);
			}
			return false;
		}

		/// <summary>Inserts an image inline, which means that it is treated in the text like a single character. The image is inserted at the specified text input position. A file open dialog box is shown to get the image's file name and filter. To avoid opening the dialog box set the Image.FileName and the Image.FilterIndex properties of the specified Image object.</summary>
		/// <param name="image">Specifies the image to add.</param>
		/// <param name="textPosition">Specifies the text position at which the image is to be inserted.</param>
		public bool Add(Image image, int textPosition)
		{
			if (this.method_0(image))
			{
				return image.method_1(base.m_tx, base.m_iTextPart, 1, textPosition, new Point(0, 0), 0, 0, IntPtr.Zero);
			}
			return false;
		}

		/// <summary>Inserts a new image which is anchored to the specified text position. It has the specified horizontal alignment and a textflow which is given through the insertionMode parameter. Anchored images are moved with the text. A file open dialog box is shown to get the image's file name and filter. To avoid opening the dialog box set the Image.FileName and the Image.FilterIndex properties of the specified Image object.</summary>
		/// <param name="image">Specifies the image to add.</param>
		/// <param name="alignment">Specifies the image's horizontal alignment.</param>
		/// <param name="textPosition">Specifies the text position at which the image is to be inserted.</param>
		/// <param name="insertionMode">Specifies how the text flow is handled.</param>
		public bool Add(Image image, HorizontalAlignment alignment, int textPosition, ImageInsertionMode insertionMode)
		{
			if (insertionMode == ImageInsertionMode.AsCharacter)
			{
				throw new ArgumentOutOfRangeException(insertionMode.ToString());
			}
			if (alignment == HorizontalAlignment.Justify)
			{
				throw new ArgumentOutOfRangeException(alignment.ToString());
			}
			if (this.method_0(image))
			{
				return image.method_1(base.m_tx, base.m_iTextPart, (int)(insertionMode | ImageInsertionMode.MoveWithText), textPosition, new Point(0, 0), 0, (int)alignment, IntPtr.Zero);
			}
			return false;
		}

		/// <summary>Inserts a new image which is anchored to the specified text position. It has the specified location relative to the paragraph it is anchored to and a textflow which is given through the insertionMode parameter. Anchored images are moved with the text. A file open dialog box is shown to get the image's file name and filter. To avoid opening the dialog box set the Image.FileName and the Image.FilterIndex properties of the specified Image object.</summary>
		/// <param name="image">Specifies the image to add.</param>
		/// <param name="location">Specifies the location, in twips, at which the image is to be inserted.</param>
		/// <param name="textPosition">Specifies the text position at which the image is to be inserted.</param>
		/// <param name="insertionMode">Specifies how the text flow is handled.</param>
		public bool Add(Image image, Point location, int textPosition, ImageInsertionMode insertionMode)
		{
			if (insertionMode == ImageInsertionMode.AsCharacter)
			{
				throw new ArgumentOutOfRangeException(insertionMode.ToString());
			}
			if (this.method_0(image))
			{
				return image.method_1(base.m_tx, base.m_iTextPart, (int)(insertionMode | ImageInsertionMode.MoveWithText), textPosition, location, 0, 0, IntPtr.Zero);
			}
			return false;
		}

		/// <summary>Inserts a new image which has a fixed geometrical position in the document. This position is specified through a page number and a location on this page. A file open dialog box is shown to get the image's file name and filter. To avoid opening the dialog box set the Image.FileName and the Image.FilterIndex properties of the specified Image object.</summary>
		/// <param name="image">Specifies the image to add.</param>
		/// <param name="pageNumber">Specifies the number of a page beginning with 1 where the image is located.</param>
		/// <param name="location">Specifies the location, in twips, at which the image is to be inserted.</param>
		/// <param name="insertionMode">Specifies how the text flow is handled.</param>
		public bool Add(Image image, int pageNumber, Point location, ImageInsertionMode insertionMode)
		{
			if (insertionMode == ImageInsertionMode.AsCharacter)
			{
				throw new ArgumentOutOfRangeException(insertionMode.ToString());
			}
			if (this.method_0(image))
			{
				return image.method_1(base.m_tx, base.m_iTextPart, (int)insertionMode, -1, location, pageNumber, 0, IntPtr.Zero);
			}
			return false;
		}

		/// <summary>Inserts a new image which has a fixed geometrical position in the document. This position is specified through a location relative to the top left corner of the complete document. All gaps between the pages must be included. A file open dialog box is shown to get the image's file name and filter. To avoid opening the dialog box set the Image.FileName and the Image.FilterIndex properties of the specified Image object.</summary>
		/// <param name="image">Specifies the image to add.</param>
		/// <param name="location">Specifies the location, in twips, at which the image is to be inserted.</param>
		/// <param name="insertionMode">Specifies how the text flow is handled.</param>
		public bool Add(Image image, Point location, ImageInsertionMode insertionMode)
		{
			if (insertionMode == ImageInsertionMode.AsCharacter)
			{
				throw new ArgumentOutOfRangeException(insertionMode.ToString());
			}
			if (this.method_0(image))
			{
				return image.method_1(base.m_tx, base.m_iTextPart, (int)insertionMode, -1, location, 0, 0, IntPtr.Zero);
			}
			return false;
		}

		/// <summary>Copies the elements of the collection to an array, starting at a particular index.</summary>
		/// <param name="array">Specifies the array to copy to.</param>
		/// <param name="index">Specifies the index of the destination array at which to begin copying.</param>
		public override void CopyTo(Array array, int index)
		{
			ImageCollection imageCollection = new ImageCollection(base.m_tx, base.m_iTextPart);
			foreach (Image item in imageCollection)
			{
				array.SetValue(item, index++);
			}
		}

		/// <summary>Gets the image selected by the user.</summary>
		public Image GetItem()
		{
			int num = base.m_tx.method_29(base.m_iTextPart, 1247, 0, 4);
			if (num != 0)
			{
				return new Image(base.m_tx, base.m_iTextPart, num);
			}
			return null;
		}

		/// <summary>Gets the image with the specified identifier. An identifier can be set with the Image.ID property.</summary>
		/// <param name="id">Specifies the image's identifier.</param>
		public Image GetItem(int int_0)
		{
			int num = base.m_tx.method_29(base.m_iTextPart, 1932, 4, int_0);
			if (num != 0)
			{
				return new Image(base.m_tx, base.m_iTextPart, num);
			}
			return null;
		}

		/// <summary>Gets the image with the specified name. A name can be set with the Image.Name property.</summary>
		/// <param name="name">Specifies the image's name.</param>
		public Image GetItem(string name)
		{
			int num = base.m_tx.method_37(base.m_iTextPart, 1933, 4, name);
			if (num != 0)
			{
				return new Image(base.m_tx, base.m_iTextPart, num);
			}
			return null;
		}

		/// <summary>Removes an image from a Text Control document.</summary>
		/// <param name="image">Specifies the image to remove.</param>
		public bool Remove(Image image)
		{
			return image.method_2(base.m_iTextPart);
		}

		private bool method_0(Image image_0)
		{
			bool result = true;
			if (image_0.FileName.Length == 0 && image_0.memoryStream_0 == null && image_0.unmanagedMemoryStream_0 == null)
			{
				string strFileName;
				int filterIndex = base.m_tx.GetTextControl().OpenFileDialog(this.ImportFilters, out strFileName);
				if (strFileName.Length > 0)
				{
					image_0.FileName = strFileName;
					image_0.FilterIndex = filterIndex;
				}
				else
				{
					result = false;
				}
			}
			return result;
		}

		private string method_1(Enum65 enum65_0)
		{
			IntPtr intPtr = IntPtr.Zero;
			string empty = string.Empty;
			try
			{
				intPtr = base.m_tx.method_66(Enum83.const_161, (uint)enum65_0, 0);
				return Marshal.PtrToStringUni(Class429.GlobalLock(intPtr));
			}
			catch (Exception ex)
			{
				throw ex;
			}
			finally
			{
				if (intPtr != IntPtr.Zero)
				{
					Marshal.FreeHGlobal(intPtr);
				}
			}
		}
	}
}
