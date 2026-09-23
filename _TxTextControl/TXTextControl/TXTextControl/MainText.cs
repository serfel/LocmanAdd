using ns21;
using TXTextControl.DataVisualization;

namespace TXTextControl
{
	/// <summary>The MainText class represents the main text of a TX Text Control document.</summary>
	public class MainText : IFormattedText
	{
		internal TextControlCore textControlCore_0;

		/// <summary>Gets a collection of all Microsoft Word or Heiler HighEdit fields that have been created or imported from a Microsoft Word or RTF document.</summary>
		public ApplicationFieldCollection ApplicationFields
		{
			get
			{
				if (this.textControlCore_0 != null && this.textControlCore_0.isHandleCreated)
				{
					return new ApplicationFieldCollection(this.textControlCore_0, TextPart.MainText);
				}
				return null;
			}
		}

		/// <summary>Gets a collection of all barcodes contained in the main text of the document.</summary>
		public BarcodeCollection Barcodes
		{
			get
			{
				if (this.textControlCore_0 != null && this.textControlCore_0.isHandleCreated)
				{
					return new BarcodeCollection(this.textControlCore_0, TextPart.MainText);
				}
				return null;
			}
		}

		/// <summary>Gets a collection of all charts contained in the main text of the document.</summary>
		public ChartCollection Charts
		{
			get
			{
				if (this.textControlCore_0 != null && this.textControlCore_0.isHandleCreated)
				{
					return new ChartCollection(this.textControlCore_0, TextPart.MainText);
				}
				return null;
			}
		}

		/// <summary>Gets a collection of all links in the main text of the document which point to targets in the same document.</summary>
		public DocumentLinkCollection DocumentLinks
		{
			get
			{
				if (this.textControlCore_0 != null && this.textControlCore_0.isHandleCreated)
				{
					return new DocumentLinkCollection(this.textControlCore_0, TextPart.MainText);
				}
				return null;
			}
		}

		/// <summary>Gets a collection of all targets in the main text of the document.</summary>
		public DocumentTargetCollection DocumentTargets
		{
			get
			{
				if (this.textControlCore_0 != null && this.textControlCore_0.isHandleCreated)
				{
					return new DocumentTargetCollection(this.textControlCore_0, TextPart.MainText);
				}
				return null;
			}
		}

		/// <summary>Gets a collection of all drawings contained in the main text of the document.</summary>
		public DrawingCollection Drawings
		{
			get
			{
				if (this.textControlCore_0 != null && this.textControlCore_0.isHandleCreated)
				{
					return new DrawingCollection(this.textControlCore_0, TextPart.MainText);
				}
				return null;
			}
		}

		public EditableRegionCollection EditableRegions
		{
			get
			{
				if (this.textControlCore_0 != null && this.textControlCore_0.isHandleCreated)
				{
					return new EditableRegionCollection(this.textControlCore_0, TextPart.MainText);
				}
				return null;
			}
		}

		/// <summary>Gets a collection of all form fields contained in the main text of the document.</summary>
		public FormFieldCollection FormFields
		{
			get
			{
				if (this.textControlCore_0 != null && this.textControlCore_0.isHandleCreated)
				{
					return new FormFieldCollection(this.textControlCore_0, TextPart.MainText);
				}
				return null;
			}
		}

		/// <summary>Gets a collection of all images, textframes, charts, barcodes and drawings contained in the main text of the document.</summary>
		public FrameCollection Frames
		{
			get
			{
				if (this.textControlCore_0 != null && this.textControlCore_0.isHandleCreated)
				{
					return new FrameCollection(this.textControlCore_0, TextPart.MainText);
				}
				return null;
			}
		}

		/// <summary>Gets a collection of all hypertext links contained in the main text of the document.</summary>
		public HypertextLinkCollection HypertextLinks
		{
			get
			{
				if (this.textControlCore_0 != null && this.textControlCore_0.isHandleCreated)
				{
					return new HypertextLinkCollection(this.textControlCore_0, TextPart.MainText);
				}
				return null;
			}
		}

		/// <summary>Gets a collection of all images contained in the main text of the document.</summary>
		public ImageCollection Images
		{
			get
			{
				if (this.textControlCore_0 != null && this.textControlCore_0.isHandleCreated)
				{
					return new ImageCollection(this.textControlCore_0, TextPart.MainText);
				}
				return null;
			}
		}

		/// <summary>Gets a collection of all text lines contained in the main text of the document.</summary>
		public LineCollection Lines
		{
			get
			{
				if (this.textControlCore_0 != null && this.textControlCore_0.isHandleCreated)
				{
					return new LineCollection(this.textControlCore_0, TextPart.MainText);
				}
				return null;
			}
		}

		/// <summary>Gets a collection of all misspelled words contained in the main text of the document.</summary>
		public MisspelledWordCollection MisspelledWords
		{
			get
			{
				if (this.textControlCore_0 != null && this.textControlCore_0.isHandleCreated)
				{
					return new MisspelledWordCollection(this.textControlCore_0, TextPart.MainText);
				}
				return null;
			}
		}

		/// <summary>Gets a collection of all paragraphs contained in the main text of the document.</summary>
		public ParagraphCollection Paragraphs
		{
			get
			{
				if (this.textControlCore_0 != null && this.textControlCore_0.isHandleCreated)
				{
					return new ParagraphCollection(this.textControlCore_0, TextPart.MainText);
				}
				return null;
			}
		}

		/// <summary>Gets or sets the current selection in the main text of the document.</summary>
		public Selection Selection
		{
			get
			{
				if (this.textControlCore_0 != null && this.textControlCore_0.isHandleCreated)
				{
					return new Selection(this.textControlCore_0, TextPart.MainText);
				}
				return null;
			}
			set
			{
				value.method_0(this.textControlCore_0, TextPart.MainText);
				value.method_4();
			}
		}

		/// <summary>Gets a collection of all subtextparts contained in the main text of the document.</summary>
		public SubTextPartCollection SubTextParts
		{
			get
			{
				if (this.textControlCore_0 != null && this.textControlCore_0.isHandleCreated)
				{
					return new SubTextPartCollection(this.textControlCore_0, TextPart.MainText);
				}
				return null;
			}
		}

		/// <summary>Gets a collection of all tables contained in the main text of the document.</summary>
		public TableCollection Tables
		{
			get
			{
				if (this.textControlCore_0 != null && this.textControlCore_0.isHandleCreated)
				{
					return new TableCollection(this.textControlCore_0, TextPart.MainText);
				}
				return null;
			}
		}

		/// <summary>Gets a collection of all tables of contents in the main text of the document.</summary>
		public TableOfContentsCollection TablesOfContents
		{
			get
			{
		        //this.textControlCore_0.GetTextControl().ValidateLicense(Enum115.Enterprise);
				if (this.textControlCore_0 != null && this.textControlCore_0.isHandleCreated)
				{
					return new TableOfContentsCollection(this.textControlCore_0, TextPart.MainText);
				}
				return null;
			}
		}

		/// <summary>Gets a collection of all characters contained in the main text of the document.</summary>
		public TextCharCollection TextChars
		{
			get
			{
				if (this.textControlCore_0 != null && this.textControlCore_0.isHandleCreated)
				{
					return new TextCharCollection(this.textControlCore_0, TextPart.MainText);
				}
				return null;
			}
		}

		/// <summary>Gets a collection of all standard text fields contained in the main text of the document.</summary>
		public TextFieldCollection TextFields
		{
			get
			{
				if (this.textControlCore_0 != null && this.textControlCore_0.isHandleCreated)
				{
					return new TextFieldCollection(this.textControlCore_0, TextPart.MainText);
				}
				return null;
			}
		}

		/// <summary>Gets a collection of all text frames contained in the main text of the document.</summary>
		public TextFrameCollection TextFrames
		{
			get
			{
				if (this.textControlCore_0 != null && this.textControlCore_0.isHandleCreated)
				{
					return new TextFrameCollection(this.textControlCore_0, TextPart.MainText);
				}
				return null;
			}
		}

		/// <summary>Gets a collection of all changes made in the main text of the document.</summary>
		public TrackedChangeCollection TrackedChanges
		{
			get
			{
				if (this.textControlCore_0 != null && this.textControlCore_0.isHandleCreated)
				{
					return new TrackedChangeCollection(this.textControlCore_0, TextPart.MainText);
				}
				return null;
			}
		}

		internal MainText(TextControlCore textControlCore_1)
		{
			this.textControlCore_0 = textControlCore_1;
		}

		/// <summary>Finds a text string in the main text of the document.</summary>
		/// <param name="text">Specifies the text to search for.</param>
		/// <param name="start">Specifies the text position where the search starts, beginning with 0.</param>
		/// <param name="options">Specifies search options.</param>
		public int Find(string text, int start, FindOptions options)
		{
			Struct59 struct59_ = new Struct59(text, start, (uint)options);
			return this.textControlCore_0.method_53(TextPart.MainText, Enum83.const_175, 0, ref struct59_);
		}

		/// <summary>Returns a collection containing text fields of the specified types.</summary>
		/// <param name="fieldType">Specifies types of text fields.</param>
		public TextFieldCollection GetTextFields(TextFieldType fieldType)
		{
			if (this.textControlCore_0 != null && this.textControlCore_0.isHandleCreated)
			{
				return new TextFieldCollection(this.textControlCore_0, TextPart.MainText, (Enum106)fieldType);
			}
			return null;
		}
	}
}
