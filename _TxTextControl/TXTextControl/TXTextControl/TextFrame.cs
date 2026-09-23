using System;
using System.ComponentModel;
using System.Drawing;
using ns21;
using TXTextControl.DataVisualization;

namespace TXTextControl
{
	/// <summary>The TextFrame object represents a rectangle that can be filled with text by an end-user and can be edited like the main text.</summary>
	public class TextFrame : FrameBase, IFormattedText
	{
		/// <summary>Gets a collection of all Microsoft Word or Heiler HighEdit fields that have been created or imported from a Microsoft Word or RTF document.</summary>
		[Browsable(false)]
		public ApplicationFieldCollection ApplicationFields
		{
			get
			{
				if (base.textControlCore_0 != null && base.textControlCore_0.isHandleCreated)
				{
					return new ApplicationFieldCollection(base.textControlCore_0, this.method_6());
				}
				return null;
			}
		}

		/// <summary>Gets or sets the background color of a text frame.</summary>
		[Browsable(false)]
		public Color BackColor
		{
			get
			{
				return base.Color_0;
			}
			set
			{
				base.Color_0 = value;
			}
		}

		/// <summary>Gets a collection of all barcodes contained in a text frame.</summary>
		[Browsable(false)]
		public BarcodeCollection Barcodes
		{
			get
			{
				if (base.textControlCore_0 != null && base.textControlCore_0.isHandleCreated)
				{
					return new BarcodeCollection(base.textControlCore_0, this.method_6());
				}
				return null;
			}
		}

		/// <summary>Gets or sets the width, in twips, of a text frame's border line.</summary>
		[Browsable(false)]
		public int BorderWidth
		{
			get
			{
				return base.Int32_8;
			}
			set
			{
				base.Int32_8 = value;
			}
		}

		/// <summary>Gets a collection of all charts contained in a text frame.</summary>
		[Browsable(false)]
		public ChartCollection Charts
		{
			get
			{
				if (base.textControlCore_0 != null && base.textControlCore_0.isHandleCreated)
				{
					return new ChartCollection(base.textControlCore_0, this.method_6());
				}
				return null;
			}
		}

		/// <summary>Gets a collection of all links in a text frame which point to targets in the same document.</summary>
		[Browsable(false)]
		public DocumentLinkCollection DocumentLinks
		{
			get
			{
				if (base.textControlCore_0 != null && base.textControlCore_0.isHandleCreated)
				{
					return new DocumentLinkCollection(base.textControlCore_0, this.method_6());
				}
				return null;
			}
		}

		/// <summary>Gets a collection of all targets in a text frame.</summary>
		[Browsable(false)]
		public DocumentTargetCollection DocumentTargets
		{
			get
			{
				if (base.textControlCore_0 != null && base.textControlCore_0.isHandleCreated)
				{
					return new DocumentTargetCollection(base.textControlCore_0, this.method_6());
				}
				return null;
			}
		}

		/// <summary>Gets a collection of all drawings contained in a text frame.</summary>
		[Browsable(false)]
		public DrawingCollection Drawings
		{
			get
			{
				if (base.textControlCore_0 != null && base.textControlCore_0.isHandleCreated)
				{
					return new DrawingCollection(base.textControlCore_0, this.method_6());
				}
				return null;
			}
		}

		/// <summary>Gets a collection of all editable regions in the text frame.</summary>
		[Browsable(false)]
		public EditableRegionCollection EditableRegions
		{
			get
			{
				if (base.textControlCore_0 != null && base.textControlCore_0.isHandleCreated)
				{
					return new EditableRegionCollection(base.textControlCore_0, this.method_6());
				}
				return null;
			}
		}

		/// <summary>Gets a collection of all form fields contained in a text frame.</summary>
		[Browsable(false)]
		public FormFieldCollection FormFields
		{
			get
			{
				if (base.textControlCore_0 != null && base.textControlCore_0.isHandleCreated)
				{
					return new FormFieldCollection(base.textControlCore_0, this.method_6());
				}
				return null;
			}
		}

		/// <summary>Gets a collection of all images, textframes, charts, barcodes and drawings in a text frame.</summary>
		public FrameCollection Frames
		{
			get
			{
				if (base.textControlCore_0 != null && base.textControlCore_0.isHandleCreated)
				{
					return new FrameCollection(base.textControlCore_0, this.method_6());
				}
				return null;
			}
		}

		/// <summary>Gets a collection of all hypertext links in a text frame.</summary>
		[Browsable(false)]
		public HypertextLinkCollection HypertextLinks
		{
			get
			{
				if (base.textControlCore_0 != null && base.textControlCore_0.isHandleCreated)
				{
					return new HypertextLinkCollection(base.textControlCore_0, this.method_6());
				}
				return null;
			}
		}

		/// <summary>Gets a collection of all images contained in a text frame.</summary>
		[Browsable(false)]
		public ImageCollection Images
		{
			get
			{
				if (base.textControlCore_0 != null && base.textControlCore_0.isHandleCreated)
				{
					return new ImageCollection(base.textControlCore_0, this.method_6());
				}
				return null;
			}
		}

		/// <summary>(Only for compatibility) Gets or sets a value determining whether a text frame is treated as a single character or the document's text either flows around or overwrites the text frame.</summary>
		[Browsable(false)]
		public new TextFrameInsertionMode InsertionMode
		{
			get
			{
				return (TextFrameInsertionMode)base.InsertionMode;
			}
			set
			{
				base.InsertionMode = (FrameInsertionMode)value;
			}
		}

		/// <summary>Gets or sets the distances, in twips, between the text frame's border line and the text.</summary>
		[Browsable(false)]
		public int[] InternalMargins
		{
			get
			{
				return base.Int32_7;
			}
			set
			{
				base.Int32_7 = value;
			}
		}

		/// <summary>Gets a collection of all text lines contained in a text frame.</summary>
		[Browsable(false)]
		public LineCollection Lines
		{
			get
			{
				if (base.textControlCore_0 != null && base.textControlCore_0.isHandleCreated)
				{
					return new LineCollection(base.textControlCore_0, this.method_6());
				}
				return null;
			}
		}

		/// <summary>Gets a collection of all misspelled words the text frame contains.</summary>
		[Browsable(false)]
		public MisspelledWordCollection MisspelledWords
		{
			get
			{
				if (base.textControlCore_0 != null && base.textControlCore_0.isHandleCreated)
				{
					return new MisspelledWordCollection(base.textControlCore_0, this.method_6());
				}
				return null;
			}
		}

		/// <summary>Gets a collection of all paragraphs contained in a text frame.</summary>
		[Browsable(false)]
		public ParagraphCollection Paragraphs
		{
			get
			{
				if (base.textControlCore_0 != null && base.textControlCore_0.isHandleCreated)
				{
					return new ParagraphCollection(base.textControlCore_0, this.method_6());
				}
				return null;
			}
		}

		/// <summary>Gets or sets the current selection in a text frame.</summary>
		[Browsable(false)]
		public Selection Selection
		{
			get
			{
				if (base.textControlCore_0 != null && base.textControlCore_0.isHandleCreated)
				{
					return new Selection(base.textControlCore_0, this.method_6());
				}
				return null;
			}
			set
			{
				value.method_0(base.textControlCore_0, this.method_6());
				value.method_4();
			}
		}

		/// <summary>Gets a collection of all subtextparts in a text frame.</summary>
		[Browsable(false)]
		public SubTextPartCollection SubTextParts
		{
			get
			{
				if (base.textControlCore_0 != null && base.textControlCore_0.isHandleCreated)
				{
					return new SubTextPartCollection(base.textControlCore_0, this.method_6());
				}
				return null;
			}
		}

		/// <summary>Gets a collection of all tables in a text frame.</summary>
		[Browsable(false)]
		public TableCollection Tables
		{
			get
			{
				if (base.textControlCore_0 != null && base.textControlCore_0.isHandleCreated)
				{
					return new TableCollection(base.textControlCore_0, this.method_6());
				}
				return null;
			}
		}

		/// <summary>Gets a collection of all tables of contents in a text frame.</summary>
		[Browsable(false)]
		public TableOfContentsCollection TablesOfContents
		{
			get
			{
				if (base.textControlCore_0 != null && base.textControlCore_0.isHandleCreated)
				{
					return new TableOfContentsCollection(base.textControlCore_0, this.method_6());
				}
				return null;
			}
		}

		/// <summary>Gets a collection of all characters contained in a text frame.</summary>
		[Browsable(false)]
		public TextCharCollection TextChars
		{
			get
			{
				if (base.textControlCore_0 != null && base.textControlCore_0.isHandleCreated)
				{
					return new TextCharCollection(base.textControlCore_0, this.method_6());
				}
				return null;
			}
		}

		/// <summary>Gets a collection of all standard text fields in a text frame.</summary>
		[Browsable(false)]
		public TextFieldCollection TextFields
		{
			get
			{
				if (base.textControlCore_0 != null && base.textControlCore_0.isHandleCreated)
				{
					return new TextFieldCollection(base.textControlCore_0, this.method_6());
				}
				return null;
			}
		}

		[Browsable(false)]
		public TextFrameCollection TextFrames
		{
			get
			{
				if (base.textControlCore_0 != null && base.textControlCore_0.isHandleCreated)
				{
					return new TextFrameCollection(base.textControlCore_0, this.method_6());
				}
				return null;
			}
		}

		/// <summary>Gets a collection of all changes made in a text frame.</summary>
		[Browsable(false)]
		public TrackedChangeCollection TrackedChanges
		{
			get
			{
				if (base.textControlCore_0 != null && base.textControlCore_0.isHandleCreated)
				{
					return new TrackedChangeCollection(base.textControlCore_0, this.method_6());
				}
				return null;
			}
		}

		/// <summary>Gets or sets the text frame's transparency.</summary>
		[Browsable(false)]
		public byte Transparency
		{
			get
			{
				return base.Byte_0;
			}
			set
			{
				base.Byte_0 = value;
			}
		}

		internal IntPtr IntPtr_0 => base.textControlCore_0.method_64(this.method_6(), Enum83.const_329, (uint)base.int_1, 0);

		/// <summary>Initializes a new instance of the TextFrame class.</summary>
		/// <param name="size">Specifies the text frame's size in twips.</param>
		public TextFrame(Size size)
			: base(size, Enum107.const_6)
		{
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		internal TextFrame(TextControlCore textControlCore_1, TextPart iTextPart, int iObjectID)
			: base(textControlCore_1, iTextPart, iObjectID, Enum107.const_6)
		{
		}

		/// <summary>Activates the text frame. The text frame receives the input focus. A text frame can only be activated, if the text part that contains the text frame has the input focus.</summary>
		public bool Activate()
		{
			if (base.textControlCore_0 != null && base.textControlCore_0.isHandleCreated)
			{
				return 0 != base.textControlCore_0.method_29(base.textPart_0, 1889, 0, base.int_1);
			}
			return false;
		}

		/// <summary>Finds a text string in a text frame.</summary>
		/// <param name="text">Specifies the text to search for.</param>
		/// <param name="start">Specifies the text position where the search starts, beginning with 0.</param>
		/// <param name="options">Specifies search options.</param>
		public int Find(string text, int start, FindOptions options)
		{
			Struct59 struct59_ = new Struct59(text, start, (uint)options);
			return base.textControlCore_0.method_53(this.method_6(), Enum83.const_175, 0, ref struct59_);
		}

		/// <summary>Returns a collection containing text fields of the specified types.</summary>
		/// <param name="fieldType">Specifies types of text fields.</param>
		public TextFieldCollection GetTextFields(TextFieldType fieldType)
		{
			if (base.textControlCore_0 != null && base.textControlCore_0.isHandleCreated)
			{
				return new TextFieldCollection(base.textControlCore_0, this.method_6(), (Enum106)fieldType);
			}
			return null;
		}

		internal TextPart method_6()
		{
			return (TextPart)Class429.smethod_3(0, base.int_1);
		}
	}
}
