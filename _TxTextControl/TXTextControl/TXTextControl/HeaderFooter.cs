using System;
using System.ComponentModel;
using ns21;
using TXTextControl.DataVisualization;

namespace TXTextControl
{
	/// <summary>An instance of the HeaderFooter class represents a header or footer in a Text Control document.The TextControl class has events that inform about different occurrences like activation or deactivation of a header or footer.</summary>
	public class HeaderFooter : IFormattedText
	{
		private TextControlCore textControlCore_0;

		private HeaderFooterType headerFooterType_0 = HeaderFooterType.Header;

		private int int_0;

		private bool bool_0 = true;

		private int int_1 = 567;

		/// <summary>Gets a collection of all Microsoft Word or Heiler HighEdit fields that have been created or imported from a Microsoft Word or RTF document.</summary>
		[Browsable(false)]
		public ApplicationFieldCollection ApplicationFields
		{
			get
			{
				if (this.textControlCore_0 != null && this.textControlCore_0.isHandleCreated)
				{
					TextPart textPart = this.method_0();
					if (textPart != 0)
					{
						return new ApplicationFieldCollection(this.textControlCore_0, textPart);
					}
				}
				return null;
			}
		}

		/// <summary>Gets a collection of all barcodes contained in a header or footer.</summary>
		[Browsable(false)]
		public BarcodeCollection Barcodes
		{
			get
			{
				if (this.textControlCore_0 != null && this.textControlCore_0.isHandleCreated)
				{
					TextPart textPart = this.method_0();
					if (textPart != 0)
					{
						return new BarcodeCollection(this.textControlCore_0, textPart);
					}
				}
				return null;
			}
		}

		/// <summary>Gets a collection of all charts contained in a header or footer.</summary>
		[Browsable(false)]
		public ChartCollection Charts
		{
			get
			{
				if (this.textControlCore_0 != null && this.textControlCore_0.isHandleCreated)
				{
					TextPart textPart = this.method_0();
					if (textPart != 0)
					{
						return new ChartCollection(this.textControlCore_0, textPart);
					}
				}
				return null;
			}
		}

		/// <summary>Gets a collection of all links in a header or footer which point to targets in the same document.</summary>
		[Browsable(false)]
		public DocumentLinkCollection DocumentLinks
		{
			get
			{
				if (this.textControlCore_0 != null && this.textControlCore_0.isHandleCreated)
				{
					TextPart textPart = this.method_0();
					if (textPart != 0)
					{
						return new DocumentLinkCollection(this.textControlCore_0, textPart);
					}
				}
				return null;
			}
		}

		/// <summary>Gets a collection of all targets in a header or footer.</summary>
		[Browsable(false)]
		public DocumentTargetCollection DocumentTargets
		{
			get
			{
				if (this.textControlCore_0 != null && this.textControlCore_0.isHandleCreated)
				{
					TextPart textPart = this.method_0();
					if (textPart != 0)
					{
						return new DocumentTargetCollection(this.textControlCore_0, textPart);
					}
				}
				return null;
			}
		}

		/// <summary>Gets a collection of all drawings contained in a header or footer.</summary>
		[Browsable(false)]
		public DrawingCollection Drawings
		{
			get
			{
				if (this.textControlCore_0 != null && this.textControlCore_0.isHandleCreated)
				{
					TextPart textPart = this.method_0();
					if (textPart != 0)
					{
						return new DrawingCollection(this.textControlCore_0, textPart);
					}
				}
				return null;
			}
		}

		/// <summary>Gets or sets a value specifying whether the header or footer is connected with the header or footer of the previous section.</summary>
		[Browsable(false)]
		[DefaultValue(true)]
		public bool ConnectedToPrevious
		{
			get
			{
				return this.bool_0;
			}
			set
			{
				if (this.bool_0 == value)
				{
					return;
				}
				this.bool_0 = value;
				if (this.textControlCore_0 == null || !this.textControlCore_0.isHandleCreated)
				{
					return;
				}
				Enum93 @enum = (Enum93)this.headerFooterType_0;
				if (this.bool_0)
				{
					switch (@enum)
					{
					case Enum93.const_7:
						@enum = Enum93.const_20;
						break;
					case Enum93.const_4:
						@enum = Enum93.const_17;
						break;
					case Enum93.const_5:
						@enum = Enum93.const_18;
						break;
					case Enum93.const_6:
						@enum = Enum93.const_19;
						break;
					case Enum93.const_16:
						@enum = Enum93.const_22;
						break;
					case Enum93.const_11:
						@enum = Enum93.const_21;
						break;
					}
				}
				this.textControlCore_0.method_30(Enum83.const_127, (this.int_0 == 0) ? 65534 : this.int_0, (int)@enum);
			}
		}

		/// <summary>Gets or sets the distance, in twips, of a header or footer to the top or bottom of the page.</summary>
		[Browsable(false)]
		[DefaultValue(567)]
		public int Distance
		{
			get
			{
				if (this.textControlCore_0 != null && this.textControlCore_0.isHandleCreated)
				{
					return this.textControlCore_0.method_30(Enum83.const_129, Class429.smethod_3((int)this.headerFooterType_0, this.int_0), 0);
				}
				return this.int_1;
			}
			set
			{
				if (this.textControlCore_0 != null && this.textControlCore_0.isHandleCreated && this.textControlCore_0.method_30(Enum83.const_130, Class429.smethod_3((int)this.headerFooterType_0, this.int_0), value) != 0)
				{
					this.int_1 = value;
				}
			}
		}

		/// <summary>Gets a collection of all editable regions in the header or footer.</summary>
		[Browsable(false)]
		public EditableRegionCollection EditableRegions
		{
			get
			{
				if (this.textControlCore_0 != null && this.textControlCore_0.isHandleCreated)
				{
					TextPart textPart = this.method_0();
					if (textPart != 0)
					{
						return new EditableRegionCollection(this.textControlCore_0, textPart);
					}
				}
				return null;
			}
		}

		/// <summary>Gets a collection of all form fields contained in a header or footer.</summary>
		[Browsable(false)]
		public FormFieldCollection FormFields
		{
			get
			{
				if (this.textControlCore_0 != null && this.textControlCore_0.isHandleCreated)
				{
					TextPart textPart = this.method_0();
					if (textPart != 0)
					{
						return new FormFieldCollection(this.textControlCore_0, textPart);
					}
				}
				return null;
			}
		}

		/// <summary>Gets a collection of all images, textframes, charts, barcodes and drawings in a header or footer.</summary>
		[Browsable(false)]
		public FrameCollection Frames
		{
			get
			{
				if (this.textControlCore_0 != null && this.textControlCore_0.isHandleCreated)
				{
					TextPart textPart = this.method_0();
					if (textPart != 0)
					{
						return new FrameCollection(this.textControlCore_0, textPart);
					}
				}
				return null;
			}
		}

		/// <summary>Gets a collection of all images the header or footer contains.</summary>
		[Browsable(false)]
		public ImageCollection Images
		{
			get
			{
				if (this.textControlCore_0 != null && this.textControlCore_0.isHandleCreated)
				{
					TextPart textPart = this.method_0();
					if (textPart != 0)
					{
						return new ImageCollection(this.textControlCore_0, textPart);
					}
				}
				return null;
			}
		}

		/// <summary>Gets a collection of all hypertext links the header or footer contains.</summary>
		[Browsable(false)]
		public HypertextLinkCollection HypertextLinks
		{
			get
			{
				if (this.textControlCore_0 != null && this.textControlCore_0.isHandleCreated)
				{
					TextPart textPart = this.method_0();
					if (textPart != 0)
					{
						return new HypertextLinkCollection(this.textControlCore_0, textPart);
					}
				}
				return null;
			}
		}

		/// <summary>Gets a collection of all text lines the header or footer contains.</summary>
		[Browsable(false)]
		public LineCollection Lines
		{
			get
			{
				if (this.textControlCore_0 != null && this.textControlCore_0.isHandleCreated)
				{
					TextPart textPart = this.method_0();
					if (textPart != 0)
					{
						return new LineCollection(this.textControlCore_0, textPart);
					}
				}
				return null;
			}
		}

		/// <summary>Gets a collection of all misspelled words the header or footer contains.</summary>
		[Browsable(false)]
		public MisspelledWordCollection MisspelledWords
		{
			get
			{
				if (this.textControlCore_0 != null && this.textControlCore_0.isHandleCreated)
				{
					TextPart textPart = this.method_0();
					if (textPart != 0)
					{
						return new MisspelledWordCollection(this.textControlCore_0, textPart);
					}
				}
				return null;
			}
		}

		/// <summary>Gets a collection of all paragraphs the header or footer contains.</summary>
		[Browsable(false)]
		public ParagraphCollection Paragraphs
		{
			get
			{
				if (this.textControlCore_0 != null && this.textControlCore_0.isHandleCreated)
				{
					TextPart textPart = this.method_0();
					if (textPart != 0)
					{
						return new ParagraphCollection(this.textControlCore_0, textPart);
					}
				}
				return null;
			}
		}

		/// <summary>Gets a collection of page number fields in the header or footer.</summary>
		[Browsable(false)]
		public PageNumberFieldCollection PageNumberFields
		{
			get
			{
				if (this.textControlCore_0 != null && this.textControlCore_0.isHandleCreated)
				{
					TextPart textPart = this.method_0();
					if (textPart != 0)
					{
						return new PageNumberFieldCollection(this.textControlCore_0, textPart);
					}
				}
				return null;
			}
		}

		[Browsable(false)]
		public int Section
		{
			get
			{
				if (!KernelHelper.IsSingleSection(this.int_0))
				{
					return 0;
				}
				return this.int_0;
			}
		}

		/// <summary>Gets or sets the current selection in a header or footer.</summary>
		[Browsable(false)]
		public Selection Selection
		{
			get
			{
				if (this.textControlCore_0 != null && this.textControlCore_0.isHandleCreated)
				{
					TextPart textPart = this.method_0();
					if (textPart != 0)
					{
						return new Selection(this.textControlCore_0, textPart);
					}
				}
				return null;
			}
			set
			{
				TextPart textPart = this.method_0();
				if (textPart != 0)
				{
					value.method_0(this.textControlCore_0, textPart);
					value.method_4();
				}
			}
		}

		/// <summary>Gets a collection of all subtextparts in the header or footer.</summary>
		[Browsable(false)]
		public SubTextPartCollection SubTextParts
		{
			get
			{
				if (this.textControlCore_0 != null && this.textControlCore_0.isHandleCreated)
				{
					TextPart textPart = this.method_0();
					if (textPart != 0)
					{
						return new SubTextPartCollection(this.textControlCore_0, textPart);
					}
				}
				return null;
			}
		}

		/// <summary>Gets a collection of all tables in the header or footer.</summary>
		[Browsable(false)]
		public TableCollection Tables
		{
			get
			{
				if (this.textControlCore_0 != null && this.textControlCore_0.isHandleCreated)
				{
					TextPart textPart = this.method_0();
					if (textPart != 0)
					{
						return new TableCollection(this.textControlCore_0, textPart);
					}
				}
				return null;
			}
		}

		/// <summary>Gets a collection of all tables of contents in the header or footer.</summary>
		[Browsable(false)]
		public TableOfContentsCollection TablesOfContents
		{
			get
			{
				//this.textControlCore_0.GetTextControl().ValidateLicense(Enum115.Enterprise);
				if (this.textControlCore_0 != null && this.textControlCore_0.isHandleCreated)
				{
					TextPart textPart = this.method_0();
					if (textPart != 0)
					{
						return new TableOfContentsCollection(this.textControlCore_0, textPart);
					}
				}
				return null;
			}
		}

		/// <summary>Gets a collection of all characters the header or footer contains.</summary>
		[Browsable(false)]
		public TextCharCollection TextChars
		{
			get
			{
				if (this.textControlCore_0 != null && this.textControlCore_0.isHandleCreated)
				{
					TextPart textPart = this.method_0();
					if (textPart != 0)
					{
						return new TextCharCollection(this.textControlCore_0, textPart);
					}
				}
				return null;
			}
		}

		/// <summary>Gets a collection of all standard text fields in the header or footer.</summary>
		[Browsable(false)]
		public TextFieldCollection TextFields
		{
			get
			{
				if (this.textControlCore_0 != null && this.textControlCore_0.isHandleCreated)
				{
					TextPart textPart = this.method_0();
					if (textPart != 0)
					{
						return new TextFieldCollection(this.textControlCore_0, textPart);
					}
				}
				return null;
			}
		}

		/// <summary>Gets a collection of all text frames contained in a header or footer.</summary>
		[Browsable(false)]
		public TextFrameCollection TextFrames
		{
			get
			{
				if (this.textControlCore_0 != null && this.textControlCore_0.isHandleCreated)
				{
					TextPart textPart = this.method_0();
					if (textPart != 0)
					{
						return new TextFrameCollection(this.textControlCore_0, textPart);
					}
				}
				return null;
			}
		}

		/// <summary>Gets a collection of all changes made in the header or footer.</summary>
		[Browsable(false)]
		public TrackedChangeCollection TrackedChanges
		{
			get
			{
				if (this.textControlCore_0 != null && this.textControlCore_0.isHandleCreated)
				{
					TextPart textPart = this.method_0();
					if (textPart != 0)
					{
						return new TrackedChangeCollection(this.textControlCore_0, textPart);
					}
				}
				return null;
			}
		}

		/// <summary>Gets the type of the header or footer.</summary>
		[Browsable(false)]
		public HeaderFooterType Type => this.headerFooterType_0;

		internal IntPtr IntPtr_0 => this.textControlCore_0.method_64(this.method_0(), Enum83.const_330, (uint)Class429.smethod_3((int)this.headerFooterType_0, this.int_0), 0);

		internal HeaderFooter(TextControlCore textControlCore_1, HeaderFooterType iHFType, int iSectionNumber, bool bConnectedToPrevious)
		{
			this.textControlCore_0 = textControlCore_1;
			this.headerFooterType_0 = iHFType;
			this.int_0 = iSectionNumber;
			this.bool_0 = bConnectedToPrevious;
		}

		/// <summary>Activates a header or a footer.</summary>
		public bool Activate()
		{
			if (this.textControlCore_0 != null && this.textControlCore_0.isHandleCreated)
			{
				TextPart textPart = this.method_0();
				if (textPart != 0)
				{
					return 0 != this.textControlCore_0.method_30(Enum83.const_126, Class429.smethod_6((int)textPart), Class429.smethod_5((int)textPart));
				}
			}
			return false;
		}

		/// <summary>Deactivates a header or a footer.</summary>
		public bool Deactivate()
		{
			if (this.textControlCore_0 != null && this.textControlCore_0.isHandleCreated)
			{
				return 0 != this.textControlCore_0.method_30(Enum83.const_126, 0, 0);
			}
			return false;
		}

		/// <summary>Finds a text string in a header or footer.</summary>
		/// <param name="text">Specifies the text to search for.</param>
		/// <param name="start">Specifies the text position where the search starts, beginning with 0.</param>
		/// <param name="options">Specifies search options.</param>
		public int Find(string text, int start, FindOptions options)
		{
			Struct59 struct59_ = new Struct59(text, start, (uint)options);
			TextPart textPart = this.method_0();
			if (textPart != 0)
			{
				return this.textControlCore_0.method_53(textPart, Enum83.const_175, 0, ref struct59_);
			}
			return -1;
		}

		/// <summary>Returns a collection containing text fields of the specified types.</summary>
		/// <param name="fieldType">Specifies types of text fields.</param>
		public TextFieldCollection GetTextFields(TextFieldType fieldType)
		{
			if (this.textControlCore_0 != null && this.textControlCore_0.isHandleCreated)
			{
				TextPart textPart = this.method_0();
				if (textPart != 0)
				{
					return new TextFieldCollection(this.textControlCore_0, textPart, (Enum106)fieldType);
				}
			}
			return null;
		}

		internal TextPart method_0()
		{
			if (this.int_0 != 65535 && (this.int_0 != 0 || this.bool_0))
			{
				return (TextPart)Class429.smethod_3((int)this.headerFooterType_0, (this.int_0 == 0) ? 1 : this.int_0);
			}
			return TextPart.Auto;
		}
	}
}
