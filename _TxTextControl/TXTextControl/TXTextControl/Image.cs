using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using ns21;

namespace TXTextControl
{
	/// <summary>The Image object represents an image in a Text Control document.</summary>
	public class Image : FrameBase
	{
		/// <summary>Sets a value between 1 and 100, which is the quality of a lossy data compression used if this image is saved.</summary>
		[Browsable(false)]
		public int ExportCompressionQuality
		{
			get
			{
				return base.Int32_1;
			}
			set
			{
				base.Int32_1 = value;
			}
		}

		/// <summary>Gets or sets the file name of an image used, if a Text Control document is saved.</summary>
		[Browsable(false)]
		public string ExportFileName
		{
			get
			{
				return base.String_0;
			}
			set
			{
				base.String_0 = value;
			}
		}

		/// <summary>Gets or sets the format used if an image is saved.</summary>
		[Browsable(false)]
		public int ExportFilterIndex
		{
			get
			{
				return base.Int32_2;
			}
			set
			{
				base.Int32_2 = value;
			}
		}

		/// <summary>Gets or sets the maximum resolution in dots per inch used if this image is saved.</summary>
		[Browsable(false)]
		public int ExportMaxResolution
		{
			get
			{
				return base.Int32_3;
			}
			set
			{
				base.Int32_3 = value;
			}
		}

		/// <summary>Gets or sets the corresponding file name and path from which an inserted image is loaded.</summary>
		[Browsable(false)]
		public string FileName
		{
			get
			{
				return base.String_1;
			}
			set
			{
				base.String_1 = value;
			}
		}

		/// <summary>Gets or sets the format used, if an image is inserted.</summary>
		[Browsable(false)]
		public int FilterIndex
		{
			get
			{
				return base.Int32_4;
			}
			set
			{
				base.Int32_4 = value;
			}
		}

		/// <summary>Gets or sets an images's horizontal scaling factor in percent.</summary>
		[Browsable(false)]
		public int HorizontalScaling
		{
			get
			{
				return base.Int32_5;
			}
			set
			{
				base.Int32_5 = value;
			}
		}

		/// <summary>(Only for compatibility) Gets or sets a value determining whether an image is treated as a single character or the document's text either flows around or overwrites the image.</summary>
		[Browsable(false)]
		public new ImageInsertionMode InsertionMode
		{
			get
			{
				return (ImageInsertionMode)base.InsertionMode;
			}
			set
			{
				base.InsertionMode = (FrameInsertionMode)value;
			}
		}

		/// <summary>Determines whether the image is stored through its data or through its file reference.</summary>
		[Browsable(false)]
		public ImageSaveMode SaveMode
		{
			get
			{
				return base.ImageSaveMode_0;
			}
			set
			{
				base.ImageSaveMode_0 = value;
			}
		}

		[Browsable(false)]
		public new Size Size
		{
			get
			{
				return base.Size;
			}
			set
			{
				throw new NotSupportedException();
			}
		}

		/// <summary>Gets or sets an images's vertical scaling factor in percent.</summary>
		[Browsable(false)]
		public int VerticalScaling
		{
			get
			{
				return base.Int32_6;
			}
			set
			{
				base.Int32_6 = value;
			}
		}

		/// <summary>Creates an empty instance of the Image class.</summary>
		public Image()
			: base(Enum107.const_1)
		{
		}

		/// <summary>Initializes a new image from the specified image file and filter.</summary>
		/// <param name="fileName">Specifies the name and the path of the file from which the image is loaded.</param>
		/// <param name="filterIndex">Specifies the index of the filter used to load the image.</param>
		public Image(string fileName, int filterIndex)
			: base(fileName, filterIndex, Enum107.const_1)
		{
		}

		/// <summary>Initializes a new image from the specified System.Drawing.Image.</summary>
		/// <param name="image">Specifies a System.Drawing.Image object which is used to initialize the TXTextControl image.</param>
		public Image(System.Drawing.Image image)
			: base(image, Enum107.const_1)
		{
		}

		/// <summary>Initializes a new image from the specified memory stream.</summary>
		/// <param name="memoryStream">Specifies a memory stream from which the data for the TXTextControl image is read.</param>
		public Image(MemoryStream stream)
			: base(stream, Enum107.const_1)
		{
		}

		/// <summary>Initializes a new image from the specified unmanaged memory stream.</summary>
		/// <param name="unmanagedStream">Specifies an unmanaged memory stream from which the data for the TXTextControl image is read.</param>
		internal Image(UnmanagedMemoryStream stream)
			: base(stream, Enum107.const_1)
		{
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		internal Image(TextControlCore textControlCore_1, TextPart iTextPart, int iObjectID)
			: base(textControlCore_1, iTextPart, iObjectID, Enum107.const_1)
		{
		}
	}
}
