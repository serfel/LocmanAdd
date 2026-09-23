using System.ComponentModel;
using System.Drawing;
using ns21;

namespace TXTextControl.DataVisualization
{
	/// <summary>An instance of the DrawingFrame class represents a drawing and its layout in a Text Control document.</summary>
	public class DrawingFrame : FrameBase
	{
		private object object_0;

		/// <summary>Gets the drawing control associated with the drawing frame.</summary>
		[Browsable(false)]
		public object Drawing => this.object_0;

		/// <summary>Sets a value between 1 and 100, which is the quality of a lossy data compression used, if the drawing's bitmap image is exported.</summary>
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

		/// <summary>Gets or sets the file name, when the drawing's bitmap image is exported.</summary>
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

		/// <summary>Gets or sets the format used, if a drawing's bitmap image is exported.</summary>
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

		/// <summary>Gets or sets the maximum resolution in dots per inch in which the drawing's bitmap image is saved.</summary>
		[Browsable(false)]
		public int ExportResolution
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

		/// <summary>Determines whether the drawing's bitmap image is stored through its binary data or through a file reference.</summary>
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

		/// <summary>Initializes a new instance of the DrawingFrame class.</summary>
		/// <param name="drawing">Specifies the drawing control associated with the drawing frame.</param>
		public DrawingFrame(object drawing)
			: base(Enum107.const_9)
		{
			this.object_0 = drawing;
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		internal DrawingFrame(TextControlCore textControlCore_1, TextPart iTextPart, int iObjectID, object drawing)
			: base(textControlCore_1, iTextPart, iObjectID, Enum107.const_9)
		{
			this.object_0 = drawing;
		}

		/// <summary>Activates the drawing so that its contents can be edited. A drawing can only be activated, if the text part that contains the drawing has the input focus.</summary>
		public bool Activate()
		{
			if (base.textControlCore_0 != null && base.textControlCore_0.isHandleCreated)
			{
				return 0 != base.textControlCore_0.method_29(base.textPart_0, 1974, base.int_1, 1);
			}
			return false;
		}

		/// <summary>Add the current state of the drawing which is connected with this DrawingFrame to the undo stack. Programmatic changes performed with the drawing's properties and methods are not automatically added to a TextControl's undo stack. Calling this method is not necessary, when the drawing frame's layout in the text is changed.</summary>
		public void AddUndoUnit()
		{
			if (base.textControlCore_0 != null && base.textControlCore_0.isHandleCreated)
			{
				base.textControlCore_0.method_30((Enum83)2077, base.int_1, 0);
			}
		}

		/// <summary>Refreshes the complete drawing. Programmatic changes performed with the drawing's properties and methods are not automatically refreshed. Calling this method is not necessary, when the drawing frame's layout in the text is changed.</summary>
		public void Refresh()
		{
			if (base.textControlCore_0 != null && base.textControlCore_0.isHandleCreated)
			{
				base.textControlCore_0.method_30(Enum83.const_291, base.int_1, 0);
			}
		}

		/// <summary>Refreshes the specified part of drawing. Programmatic changes performed with the drawing's properties and methods are not automatically refreshed. Calling this method is not necessary, when the drawing frame's layout in the text is changed.</summary>
		/// <param name="clipRectangle">Specifies the rectangular part of the drawing to refresh, in pixels, relative to the top-left corner of the drawing.</param>
		public void Refresh(Rectangle clipRectangle)
		{
			if (base.textControlCore_0 != null && base.textControlCore_0.isHandleCreated)
			{
				Class429.Struct83 struct83_ = new Class429.Struct83(clipRectangle);
				base.textControlCore_0.method_32(Enum83.const_291, base.int_1, ref struct83_);
			}
		}
	}
}
