using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Printing;
using System.Globalization;
using System.IO;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using ns21;
using ns23;
using ns24;
using TXTextControl.DataVisualization;
using TXTextControl.ServerVisualisation;

namespace TXTextControl
{
	/// <summary>The ServerTextControl class implements a component that provide high-level text processing features for server-based applications.</summary>
	[ToolboxBitmap(typeof(ServerTextControl))]
	public class ServerTextControl : Component, IFormattedText, ITextControl
	{
		public string ѕуть—охранени€ { get; set; }
		public int FileFilterIndex { get; set; }

		private delegate IntPtr Delegate14(IntPtr intptr_0, int int_0, IntPtr intptr_1, IntPtr intptr_2);

		internal TextControlCore textControlCore_0;

		public ResourceManager resourceManager_0;

		internal Class408 class408_0;

		private Container container_0;

		private TextControlCore.Delegate7 delegate7_0;

		private TextControlCore.Delegate9 delegate9_0;

		private TextControlCore.Delegate10 delegate10_0;

		private TextControlCore.Delegate11 delegate11_0;

		private TextControlCore.Delegate12 delegate12_0;

		private ViewMode viewMode_0 = ViewMode.PageView;

		private Delegate14 m_WndProc;

		private IntPtr intptr_0 = IntPtr.Zero;

		private EventHandler eventHandler_0;

		private EventHandler eventHandler_1;

		private ImageEventHandler imageEventHandler_0;

		private ImageEventHandler imageEventHandler_1;

		private TextFrameEventHandler textFrameEventHandler_0;

		private TextFrameEventHandler textFrameEventHandler_1;

		private ChartEventHandler chartEventHandler_0;

		private ChartEventHandler chartEventHandler_1;

		private BarcodeEventHandler barcodeEventHandler_0;

		private BarcodeEventHandler barcodeEventHandler_1;

		private DrawingEventHandler drawingEventHandler_0;

		private DrawingEventHandler drawingEventHandler_1;

		private TableEventHandler tableEventHandler_0;

		private TableEventHandler tableEventHandler_1;

		private SubTextPartEventHandler subTextPartEventHandler_0;

		private SubTextPartEventHandler subTextPartEventHandler_1;

		private EditableRegionEventHandler editableRegionEventHandler_0;

		private EditableRegionEventHandler editableRegionEventHandler_1;

		private TrackedChangeEventHandler trackedChangeEventHandler_0;

		private TrackedChangeEventHandler trackedChangeEventHandler_1;

		private DocumentTargetEventHandler documentTargetEventHandler_0;

		private DocumentTargetEventHandler documentTargetEventHandler_1;

		private TableOfContentsEventHandler tableOfContentsEventHandler_0;

		private TableOfContentsEventHandler tableOfContentsEventHandler_1;

		private TextFieldEventHandler textFieldEventHandler_0;

		private TextFieldEventHandler textFieldEventHandler_1;

		private XmlErrorEventHandler xmlErrorEventHandler_0;

		private XmlErrorEventHandler xmlErrorEventHandler_1;

		private SpellCheckTextEventHandler spellCheckTextEventHandler_0;

		private HyphenateWordEventHandler hyphenateWordEventHandler_0;

		private AdaptFontEventHandler adaptFontEventHandler_0;

		private Color color_0 = SystemColors.Window;

		private int int_0;

		private DocumentSettings documentSettings_0 = new DocumentSettings();

		private Font font_0 = new Font("Arial", 10f);

		private FontSettings fontSettings_0 = new FontSettings();

		private FontUnderlineStyle fontUnderlineStyle_0 = FontUnderlineStyle.Single;

		private Color color_1 = SystemColors.WindowText;

		private string string_0 = "Standard";

		private FormulaReferenceStyle formulaReferenceStyle_0 = FormulaReferenceStyle.A1;

		private InputPosition inputPosition_0 = new InputPosition(1, 1, 0);

		private bool bool_0;

		private bool bool_1 = true;

		private bool bool_2;

		private bool bool_3;

		private bool bool_4;

		private bool bool_5;

		private ListFormat listFormat_0 = new ListFormat(0);

		private PageMargins pageMargins_0 = new PageMargins();

		private PageSize pageSize_0 = new PageSize();

		private ParagraphFormat paragraphFormat_0 = new ParagraphFormat(0);

		private object object_0;

		internal Class415 class415_0;

		private string string_1 = string.Empty;

		private Color color_2 = SystemColors.Window;

		private bool bool_6 = true;

		private ViewMode viewMode_1 = ViewMode.PageView;

		[CompilerGenerated]
		private Class431 class431_0;

		/// <summary>Gets a collection of all Microsoft Word or Heiler HighEdit fields that have been created or imported from a Microsoft Word or RTF document.</summary>
		[Browsable(false)]
		public ApplicationFieldCollection ApplicationFields
		{
			get
			{
				//
				if (this.textControlCore_0.isHandleCreated)
				{
					return new ApplicationFieldCollection(this.textControlCore_0, TextPart.Auto);
				}
				return null;
			}
		}

		/// <summary>Gets or sets the background color of the control.</summary>
		[Attribute3("PROP_BACKCOLOR")]
		[Category("Appearance")]
		public Color BackColor
		{
			get
			{
				if (this.textControlCore_0.isHandleCreated)
				{
					int[] array = new int[1];
					int num = this.textControlCore_0.method_41(Enum83.const_26, 0, array);
					this.color_0 = ((num == 1) ? SystemColors.Window : ((array[0] == 1610612736) ? Color.Transparent : Class429.smethod_2(array[0])));
				}
				return this.color_0;
			}
			set
			{
				if (this.color_0 != value)
				{
					if (this.textControlCore_0.isHandleCreated)
					{
						this.textControlCore_0.method_30(Enum83.const_41, (value == SystemColors.Window) ? 1 : 0, Class429.smethod_0(value));
					}
					this.color_0 = value;
				}
			}
		}

		/// <summary>Gets a collection of all barcodes in a document.</summary>
		[Browsable(false)]
		public BarcodeCollection Barcodes
		{
			get
			{
				//
				if (this.textControlCore_0.isHandleCreated)
				{
					return new BarcodeCollection(this.textControlCore_0, TextPart.Auto);
				}
				return null;
			}
		}

		/// <summary>Gets or sets the baseline alignment, in twips, of the control.</summary>
		[DefaultValue(0)]
		[Category("Appearance")]
		[Attribute3("PROP_BASELINE")]
		public int Baseline
		{
			get
			{
				return this.int_0;
			}
			set
			{
				if (this.int_0 != value)
				{
					if (value < -960 || value > 960)
					{
						throw new ArgumentOutOfRangeException();
					}
					this.int_0 = value;
					if (this.textControlCore_0.isHandleCreated)
					{
						this.textControlCore_0.method_12(TextPart.Auto);
						this.textControlCore_0.method_29(TextPart.Auto, 1160, (value == 0) ? 2 : ((value < 0) ? 8 : 4), Math.Abs(value));
						this.textControlCore_0.method_15(TextPart.Auto);
					}
				}
			}
		}

		/// <summary>Gets a collection of all charts in a document.</summary>
		[Browsable(false)]
		public ChartCollection Charts
		{
			get
			{
				//
				if (this.textControlCore_0.isHandleCreated)
				{
					return new ChartCollection(this.textControlCore_0, TextPart.Auto);
				}
				return null;
			}
		}

		internal Class431 Class431_0
		{
			[CompilerGenerated]
			get
			{
				return this.class431_0;
			}
			[CompilerGenerated]
			set
			{
				this.class431_0 = value;
			}
		}

		/// <summary>Gets a collection of all links that point to targets in the same document.</summary>
		[Browsable(false)]
		public DocumentLinkCollection DocumentLinks
		{
			get
			{
				//
				if (this.textControlCore_0.isHandleCreated)
				{
					return new DocumentLinkCollection(this.textControlCore_0, TextPart.Auto);
				}
				return null;
			}
		}

		/// <summary>Gets a DocumentSettings object providing properties which inform about general document settings, such as author and title, contained in the document the user is currently working on.</summary>
		[Browsable(false)]
		public DocumentSettings DocumentSettings => this.documentSettings_0;

		/// <summary>Gets a collection of all targets in the document.</summary>
		[Browsable(false)]
		public DocumentTargetCollection DocumentTargets
		{
			get
			{
				//
				if (this.textControlCore_0.isHandleCreated)
				{
					return new DocumentTargetCollection(this.textControlCore_0, TextPart.Auto);
				}
				return null;
			}
		}

		/// <summary>Gets a collection of all drawings in a document.</summary>
		[Browsable(false)]
		public DrawingCollection Drawings
		{
			get
			{
				//
				if (this.textControlCore_0.isHandleCreated)
				{
					return new DrawingCollection(this.textControlCore_0, TextPart.Auto);
				}
				return null;
			}
		}

		/// <summary>Gets a collection of all editable regions contained in the document.</summary>
		[Browsable(false)]
		public EditableRegionCollection EditableRegions
		{
			get
			{
				//
				if (this.textControlCore_0.isHandleCreated)
				{
					return new EditableRegionCollection(this.textControlCore_0, TextPart.Auto);
				}
				return null;
			}
		}

		/// <summary>Gets or sets the control's font.</summary>
		[Category("Appearance")]
		[Attribute3("PROP_FONT")]
		public Font Font
		{
			get
			{
				return this.font_0;
			}
			set
			{
				if (!this.font_0.Equals(value))
				{
					this.font_0 = (Font)value.Clone();
					if (this.textControlCore_0.isHandleCreated)
					{
						this.textControlCore_0.method_9(TextPart.Auto);
					}
				}
			}
		}

		/// <summary>Gets a FontSettings object which provides properties determining which fonts can be used in a document.</summary>
		[Attribute3("PROP_FONTSETTINGS")]
		[Category("Behavior")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		public FontSettings FontSettings => this.fontSettings_0;

		/// <summary>Gets or sets underlining style for the text displayed by the control.</summary>
		[DefaultValue(FontUnderlineStyle.Single)]
		[Attribute3("PROP_FONTUNDERLINESTYLE")]
		[Category("Appearance")]
		public FontUnderlineStyle FontUnderlineStyle
		{
			get
			{
				return this.fontUnderlineStyle_0;
			}
			set
			{
				if (this.fontUnderlineStyle_0 == value)
				{
					return;
				}
				this.fontUnderlineStyle_0 = value;
				if (this.textControlCore_0.isHandleCreated && this.Font.Underline)
				{
					int int_ = 0;
					switch (this.fontUnderlineStyle_0)
					{
					case FontUnderlineStyle.Doubled:
						int_ = 4672;
						break;
					case FontUnderlineStyle.DoubledWordsOnly:
						int_ = 4288;
						break;
					case FontUnderlineStyle.Single:
						int_ = 16912;
						break;
					case FontUnderlineStyle.SingleWordsOnly:
						int_ = 16528;
						break;
					}
					this.textControlCore_0.method_12(TextPart.Auto);
					this.textControlCore_0.method_29(TextPart.Auto, 1154, int_, 0);
					this.textControlCore_0.method_15(TextPart.Auto);
				}
			}
		}

		/// <summary>Gets or sets the foreground color of the control.</summary>
		[Attribute3("PROP_FORECOLOR")]
		[Category("Appearance")]
		public Color ForeColor
		{
			get
			{
				return this.color_1;
			}
			set
			{
				if (this.color_1 != value)
				{
					this.color_1 = value;
					if (this.textControlCore_0.isHandleCreated)
					{
						int[] int_ = new int[2]
						{
							Class429.smethod_0(value),
							0
						};
						this.textControlCore_0.method_12(TextPart.Auto);
						this.textControlCore_0.method_40(TextPart.Auto, 1168, (value == SystemColors.WindowText) ? 1 : 2, int_);
						this.textControlCore_0.method_15(TextPart.Auto);
					}
				}
			}
		}

		/// <summary>Gets or sets the name of a printer the text dimensions and capabilities of which are used to format the document.</summary>
		[TypeConverter(typeof(Class418))]
		[DefaultValue("Standard")]
		[Category("Layout")]
		[Attribute3("PROP_FORMATTINGPRINTER")]
		public string FormattingPrinter
		{
			get
			{
				if (this.textControlCore_0.isHandleCreated)
				{
					return this.textControlCore_0.method_26();
				}
				return this.string_0;
			}
			set
			{
				if (this.string_0 != value)
				{
					this.string_0 = value;
					if (this.textControlCore_0.isHandleCreated)
					{
						this.textControlCore_0.method_27(value);
					}
				}
			}
		}

		/// <summary>Gets a collection of all form fields contained in the document.</summary>
		[Browsable(false)]
		public FormFieldCollection FormFields
		{
			get
			{
				if (this.textControlCore_0.isHandleCreated)
				{
					return new FormFieldCollection(this.textControlCore_0, TextPart.Auto);
				}
				return null;
			}
		}

		/// <summary>Gets or sets a value determining how references to table cells in formulas are specified.</summary>
		[Attribute3("PROP_FORMULAREFSTYLE")]
		[DefaultValue(FormulaReferenceStyle.A1)]
		[Category("Behavior")]
		public FormulaReferenceStyle FormulaReferenceStyle
		{
			get
			{
				if (this.textControlCore_0.isHandleCreated)
				{
					int[] array = new int[1];
					int[] array2 = array;
					this.textControlCore_0.method_41(Enum83.const_25, 0, array2);
					this.formulaReferenceStyle_0 = ((((uint)array2[0] & 0x100u) != 0) ? FormulaReferenceStyle.R1C1 : FormulaReferenceStyle.A1);
				}
				return this.formulaReferenceStyle_0;
			}
			set
			{
				if (this.formulaReferenceStyle_0 != value)
				{
					this.formulaReferenceStyle_0 = value;
					if (this.textControlCore_0.isHandleCreated)
					{
						this.textControlCore_0.method_30(Enum83.const_40, 0, (this.formulaReferenceStyle_0 == FormulaReferenceStyle.R1C1) ? 256 : 65536);
					}
				}
			}
		}

		/// <summary>Gets a collection of all images, textframes, charts and barcodes in a document.</summary>
		[Browsable(false)]
		public FrameCollection Frames
		{
			get
			{
				if (this.textControlCore_0.isHandleCreated)
				{
					return new FrameCollection(this.textControlCore_0, TextPart.Auto);
				}
				return null;
			}
		}

		/// <summary>Gets a collection of all headers and footers the current document contains.</summary>
		[Browsable(false)]
		public HeaderFooterCollection HeadersAndFooters
		{
			get
			{
				//
				if (this.textControlCore_0.isHandleCreated)
				{
					return new HeaderFooterCollection(this.textControlCore_0, 0);
				}
				return null;
			}
		}

		/// <summary>Gets a collection of all hypertext links contained in the main text of the document.</summary>
		[Browsable(false)]
		public HypertextLinkCollection HypertextLinks
		{
			get
			{
				//
				if (this.textControlCore_0.isHandleCreated)
				{
					return new HypertextLinkCollection(this.textControlCore_0, TextPart.Auto);
				}
				return null;
			}
		}

		/// <summary>Gets a collection of all images contained in the main text of the document.</summary>
		[Browsable(false)]
		public ImageCollection Images
		{
			get
			{
				if (this.textControlCore_0.isHandleCreated)
				{
					return new ImageCollection(this.textControlCore_0, TextPart.Auto);
				}
				return null;
			}
		}

		/// <summary>Gets a collection of all inline styles the current document contains.</summary>
		[Browsable(false)]
		public InlineStyleCollection InlineStyles
		{
			get
			{
				
				if (this.textControlCore_0.isHandleCreated)
				{
					return new InlineStyleCollection(this.textControlCore_0);
				}
				return null;
			}
		}

		/// <summary>Gets or sets the current text input position.</summary>
		[Browsable(false)]
		public InputPosition InputPosition
		{
			get
			{
				return this.inputPosition_0;
			}
			set
			{
				value.method_1(this.inputPosition_0);
				this.inputPosition_0.method_3();
			}
		}

		/// <summary>Gets a value indicating whether the control is completely created.</summary>
		[Browsable(false)]
		public bool IsCreated => this.textControlCore_0.isHandleCreated;

		public virtual bool Boolean_0 => this.bool_0;

		/// <summary>Gets or sets a value indicating whether formulas in tables are automatically calculated when the text of an input cell is changed.</summary>
		[Category("Behavior")]
		[Attribute3("PROP_ISFORMULACALCENABLED")]
		[DefaultValue(true)]
		public bool IsFormulaCalculationEnabled
		{
			get
			{
				if (this.textControlCore_0.isHandleCreated)
				{
					int[] array = new int[1];
					int[] array2 = array;
					this.textControlCore_0.method_41(Enum83.const_25, 0, array2);
					this.bool_1 = (array2[0] & 0x80) != 0;
				}
				return this.bool_1;
			}
			set
			{
				if (this.bool_1 != value)
				{
					this.bool_1 = value;
					if (this.textControlCore_0.isHandleCreated)
					{
						this.textControlCore_0.method_30(Enum83.const_40, 0, this.bool_1 ? 128 : 512);
					}
				}
			}
		}

		/// <summary>Gets or sets a value indicating whether language detection is active or not.</summary>
		[DefaultValue(false)]
		[Category("Behavior")]
		[Attribute3("PROP_ISLANGUAGEDETECTIONENABLED")]
		public bool IsLanguageDetectionEnabled
		{
			get
			{
				return this.bool_2;
			}
			set
			{
				if (this.bool_2 != value)
				{
					this.bool_2 = value;
					if (this.textControlCore_0.isHandleCreated)
					{
						this.textControlCore_0.method_77(Enum83.const_275, this.bool_2 ? 3 : 2, this.delegate12_0);
					}
				}
			}
		}

		/// <summary>Gets or sets a value indicating whether spell checking is active or not.</summary>
		[Category("Behavior")]
		[DefaultValue(false)]
		[Attribute3("PROP_ISSPELLCHECKINGENABLED")]
		public bool IsSpellCheckingEnabled
		{
			get
			{
				return this.bool_3;
			}
			set
			{
				if (this.bool_3 != value)
				{
					this.bool_3 = value;
					if (this.textControlCore_0.isHandleCreated)
					{
						this.textControlCore_0.method_76(Enum83.const_275, this.bool_3 ? 1 : 0, this.delegate10_0);
					}
				}
			}
		}

		/// <summary>Gets or sets a value indicating whether hyphenation is active or not.</summary>
		[DefaultValue(false)]
		[Attribute3("PROP_ISHYPHENATIONENABLED")]
		[Category("Behavior")]
		public bool IsHyphenationEnabled
		{
			get
			{
				return this.bool_4;
			}
			set
			{
				if (this.bool_4 != value)
				{
					this.bool_4 = value;
					if (this.textControlCore_0.isHandleCreated)
					{
						this.textControlCore_0.method_78(Enum83.const_38, this.bool_4 ? 1 : 0, this.delegate11_0);
					}
				}
			}
		}

		/// <summary>Gets or sets a value indicating whether the page orientation is landscape or portrait.</summary>
		[Attribute3("PROP_LANDSCAPE")]
		[Category("Layout")]
		[DefaultValue(false)]
		public bool Landscape
		{
			get
			{
				return this.bool_5;
			}
			set
			{
				if (this.bool_5 != value)
				{
					this.bool_5 = value;
					this.pageSize_0.Boolean_0 = this.bool_5;
					if (this.textControlCore_0.isHandleCreated)
					{
						this.textControlCore_0.method_30(Enum83.const_235, 0, this.bool_5 ? 1073741824 : int.MinValue);
						this.pageSize_0.method_2();
						this.pageSize_0.method_6();
					}
				}
			}
		}

		/// <summary>Gets a collection of all lines contained in the main text of the document.</summary>
		[Browsable(false)]
		public LineCollection Lines
		{
			get
			{
				if (this.textControlCore_0.isHandleCreated)
				{
					return new LineCollection(this.textControlCore_0, TextPart.Auto);
				}
				return null;
			}
		}

		/// <summary>Gets or sets the type and the formatting attributes of a bulleted or numbered list.</summary>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		[Category("Appearance")]
		[Attribute3("PROP_LIST")]
		public ListFormat ListFormat
		{
			get
			{
				return this.listFormat_0;
			}
			set
			{
				value.method_3(this.listFormat_0);
				this.listFormat_0.method_12();
			}
		}

		/// <summary>Gets a collection of all misspelled words in the main text of the document.</summary>
		[Browsable(false)]
		public MisspelledWordCollection MisspelledWords
		{
			get
			{
				if (this.textControlCore_0.isHandleCreated)
				{
					return new MisspelledWordCollection(this.textControlCore_0, TextPart.Auto);
				}
				return null;
			}
		}

		/// <summary>Gets or sets the margins for the pages of the current document.</summary>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		[Category("Layout")]
		[Attribute3("PROP_PAGEMARGINS")]
		public PageMargins PageMargins
		{
			get
			{
				return this.pageMargins_0;
			}
			set
			{
				this.pageMargins_0 = value;
				this.pageMargins_0.method_1(this.textControlCore_0, 0);
				this.pageMargins_0.method_2();
				this.pageMargins_0.method_6();
			}
		}

		/// <summary>Gets the number of pages contained in the current document.</summary>
		[Browsable(false)]
		public int Pages
		{
			get
			{
				if (!this.textControlCore_0.isHandleCreated)
				{
					return 0;
				}
				return this.textControlCore_0.method_30(Enum83.const_56, 0, 0);
			}
		}

		/// <summary>Specifies the width and height of the pages for the current document.</summary>
		[Category("Layout")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		[Attribute3("PROP_PAGESIZE")]
		public PageSize PageSize
		{
			get
			{
				return this.pageSize_0;
			}
			set
			{
				this.pageSize_0 = value;
				this.pageSize_0.method_1(this.textControlCore_0, 0);
				this.pageSize_0.Boolean_0 = this.bool_5;
				this.pageSize_0.method_6();
			}
		}

		/// <summary>Gets or sets the measure used for page sizes and page margins.</summary>
		[DefaultValue(MeasuringUnit.CentiInch)]
		[Browsable(false)]
		public MeasuringUnit PageUnit
		{
			get
			{
				return this.textControlCore_0.MeasuringUnit_0;
			}
			set
			{
				this.textControlCore_0.MeasuringUnit_0 = value;
				this.pageSize_0.method_8(PageSize.Attribute.All, PageSize.Attribute.All);
				this.pageMargins_0.method_8(PageMargins.Attribute.All, PageMargins.Attribute.All);
			}
		}

		/// <summary>Gets or sets the paragraph formatting attributes of the text displayed by the control.</summary>
		[Attribute3("PROP_PARAGRAPH")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		[Category("Appearance")]
		public ParagraphFormat ParagraphFormat
		{
			get
			{
				return this.paragraphFormat_0;
			}
			set
			{
				value.method_3(this.paragraphFormat_0);
				this.paragraphFormat_0.method_11();
			}
		}

		/// <summary>Gets a collection of all paragraphs contained in the main text of the document.</summary>
		[Browsable(false)]
		public ParagraphCollection Paragraphs
		{
			get
			{
				if (this.textControlCore_0.isHandleCreated)
				{
					return new ParagraphCollection(this.textControlCore_0, TextPart.Auto);
				}
				return null;
			}
		}

		/// <summary>Gets a collection of all paragraph styles the current document contains.</summary>
		[Browsable(false)]
		public ParagraphStyleCollection ParagraphStyles
		{
			get
			{
				
				if (this.textControlCore_0.isHandleCreated)
				{
					return new ParagraphStyleCollection(this.textControlCore_0);
				}
				return null;
			}
		}

		/// <summary>Gets or sets the current selection in the main text of the document.</summary>
		[Browsable(false)]
		public Selection Selection
		{
			get
			{
				Selection result = null;
				if (this.textControlCore_0.isHandleCreated)
				{
					result = new Selection(this.textControlCore_0, TextPart.Auto);
				}
				return result;
			}
			set
			{
				value.method_0(this.textControlCore_0, TextPart.Auto);
				value.method_4();
			}
		}

		/// <summary>Gets a collection of all sections in the document.</summary>
		[Browsable(false)]
		public SectionCollection Sections
		{
			get
			{
				//
				if (this.textControlCore_0.isHandleCreated)
				{
					return new SectionCollection(this.textControlCore_0);
				}
				return null;
			}
		}

		/// <summary>Specifies the spell checking component to be used with a ServerTextControl.</summary>
		[Browsable(false)]
		public object SpellChecker
		{
			get
			{
				return this.object_0;
			}
			set
			{
				if (value == null)
				{
					this.class415_0 = null;
				}
				else
				{
					if (!(value.GetType().Name == "TXSpell"))
					{
						throw new ArgumentException(this.resourceManager_0.GetString("ERR_INVALIDTXSPELL"));
					}
					this.class415_0 = new Class415(value);
				}
				this.object_0 = value;
			}
		}

		/// <summary>Gets a collection of all subtextparts contained in the document.</summary>
		[Browsable(false)]
		public SubTextPartCollection SubTextParts
		{
			get
			{
				//
				if (this.textControlCore_0.isHandleCreated)
				{
					return new SubTextPartCollection(this.textControlCore_0, TextPart.Auto);
				}
				return null;
			}
		}

		/// <summary>Gets a collection of all tables contained in the document.</summary>
		[Browsable(false)]
		public TableCollection Tables
		{
			get
			{
				if (this.textControlCore_0.isHandleCreated)
				{
					return new TableCollection(this.textControlCore_0, TextPart.Auto);
				}
				return null;
			}
		}

		/// <summary>Gets a collection of all tables of contents in the document.</summary>
		[Browsable(false)]
		public TableOfContentsCollection TablesOfContents
		{
			get
			{
				
				if (this.textControlCore_0.isHandleCreated)
				{
					return new TableOfContentsCollection(this.textControlCore_0, TextPart.Auto);
				}
				return null;
			}
		}

		/// <summary>Gets or sets the control's text.</summary>
		[Attribute3("PROP_TEXT")]
		[Category("Appearance")]
		[DefaultValue("")]
		public string Text
		{
			get
			{
				if (this.textControlCore_0.isHandleCreated)
				{
					this.Save(out this.string_1, StringStreamType.PlainText);
				}
				return this.string_1;
			}
			set
			{
				this.string_1 = value;
				if (this.textControlCore_0.isHandleCreated)
				{
					this.Load(this.string_1, StringStreamType.PlainText);
				}
			}
		}

		/// <summary>Gets or sets the background color for the text.</summary>
		[Attribute3("PROP_TEXTBACKCOLOR")]
		[Category("Appearance")]
		public Color TextBackColor
		{
			get
			{
				if (!this.bool_6)
				{
					return this.color_2;
				}
				return this.BackColor;
			}
			set
			{
				if (this.color_2 != value)
				{
					this.color_2 = value;
					this.bool_6 = this.color_2 == this.BackColor;
					if (this.textControlCore_0.isHandleCreated)
					{
						int[] int_ = new int[2]
						{
							0,
							Class429.smethod_0(value)
						};
						this.textControlCore_0.method_12(TextPart.Auto);
						this.textControlCore_0.method_40(TextPart.Auto, 1168, (value == this.BackColor) ? 16 : ((value == SystemColors.Window) ? 4 : 8), int_);
						this.textControlCore_0.method_15(TextPart.Auto);
					}
				}
			}
		}

		/// <summary>Gets a collection of all characters contained in the main text of the document.</summary>
		[Browsable(false)]
		public TextCharCollection TextChars
		{
			get
			{
				if (this.textControlCore_0.isHandleCreated)
				{
					return new TextCharCollection(this.textControlCore_0, TextPart.Auto);
				}
				return null;
			}
		}

		/// <summary>Gets a collection of all standard text fields contained in the main text of the document.</summary>
		[Browsable(false)]
		public TextFieldCollection TextFields
		{
			get
			{
				if (this.textControlCore_0.isHandleCreated)
				{
					return new TextFieldCollection(this.textControlCore_0, TextPart.Auto);
				}
				return null;
			}
		}

		/// <summary>Gets a collection of all text frames the current document contains.</summary>
		[Browsable(false)]
		public TextFrameCollection TextFrames
		{
			get
			{
				//
				if (this.textControlCore_0.isHandleCreated)
				{
					return new TextFrameCollection(this.textControlCore_0, TextPart.Auto);
				}
				return null;
			}
		}

		/// <summary>Gets a collection of all text parts the current document contains.</summary>
		[Browsable(false)]
		public TextPartCollection TextParts
		{
			get
			{
				//
				if (this.textControlCore_0.isHandleCreated)
				{
					return new TextPartCollection(this.textControlCore_0, this);
				}
				return null;
			}
		}

		/// <summary>Gets a collection of all changes made in the active part of the document.</summary>
		[Browsable(false)]
		public TrackedChangeCollection TrackedChanges
		{
			get
			{
				//
				if (this.textControlCore_0.isHandleCreated)
				{
					return new TrackedChangeCollection(this.textControlCore_0, TextPart.Auto);
				}
				return null;
			}
		}

		[Browsable(false)]
		public ViewMode ViewMode_0
		{
			get
			{
				return this.viewMode_1;
			}
			set
			{
				if (this.viewMode_1 != value)
				{
					if (this.textControlCore_0.isHandleCreated)
					{
						this.viewMode_1 = value;
						this.textControlCore_0.method_30(Enum83.const_227, 0, (int)this.viewMode_1);
					}
					else
					{
						this.viewMode_1 = value;
					}
				}
			}
		}

		/// <summary>Occurs when a new document has been loaded.</summary>
		[Attribute3("EVENT_DOCUMENTLOADED")]
		[Category("Behavior")]
		public event EventHandler DocumentLoaded
		{
			add
			{
				EventHandler eventHandler = this.eventHandler_0;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange(ref this.eventHandler_0, value2, eventHandler2);
				}
				while ((object)eventHandler != eventHandler2);
			}
			remove
			{
				EventHandler eventHandler = this.eventHandler_0;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange(ref this.eventHandler_0, value2, eventHandler2);
				}
				while ((object)eventHandler != eventHandler2);
			}
		}

		/// <summary>Occurs when all text contents have been deleted and all attributes have been reset to the state after initialization.</summary>
		[Category("Behavior")]
		[Attribute3("EVENT_CONTENTSRESET")]
		public event EventHandler ContentsReset
		{
			add
			{
				EventHandler eventHandler = this.eventHandler_1;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange(ref this.eventHandler_1, value2, eventHandler2);
				}
				while ((object)eventHandler != eventHandler2);
			}
			remove
			{
				EventHandler eventHandler = this.eventHandler_1;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange(ref this.eventHandler_1, value2, eventHandler2);
				}
				while ((object)eventHandler != eventHandler2);
			}
		}

		/// <summary>Occurs when a new image has been created.</summary>
		[Attribute2("CAT_IMAGES")]
		[Attribute3("EVENT_IMAGECREATED")]
		public event ImageEventHandler ImageCreated
		{
			add
			{
				ImageEventHandler imageEventHandler = this.imageEventHandler_0;
				ImageEventHandler imageEventHandler2;
				do
				{
					imageEventHandler2 = imageEventHandler;
					ImageEventHandler value2 = (ImageEventHandler)Delegate.Combine(imageEventHandler2, value);
					imageEventHandler = Interlocked.CompareExchange(ref this.imageEventHandler_0, value2, imageEventHandler2);
				}
				while ((object)imageEventHandler != imageEventHandler2);
			}
			remove
			{
				ImageEventHandler imageEventHandler = this.imageEventHandler_0;
				ImageEventHandler imageEventHandler2;
				do
				{
					imageEventHandler2 = imageEventHandler;
					ImageEventHandler value2 = (ImageEventHandler)Delegate.Remove(imageEventHandler2, value);
					imageEventHandler = Interlocked.CompareExchange(ref this.imageEventHandler_0, value2, imageEventHandler2);
				}
				while ((object)imageEventHandler != imageEventHandler2);
			}
		}

		/// <summary>Occurs when an image has been deleted.</summary>
		[Attribute3("EVENT_IMAGEDELETED")]
		[Attribute2("CAT_IMAGES")]
		public event ImageEventHandler ImageDeleted
		{
			add
			{
				ImageEventHandler imageEventHandler = this.imageEventHandler_1;
				ImageEventHandler imageEventHandler2;
				do
				{
					imageEventHandler2 = imageEventHandler;
					ImageEventHandler value2 = (ImageEventHandler)Delegate.Combine(imageEventHandler2, value);
					imageEventHandler = Interlocked.CompareExchange(ref this.imageEventHandler_1, value2, imageEventHandler2);
				}
				while ((object)imageEventHandler != imageEventHandler2);
			}
			remove
			{
				ImageEventHandler imageEventHandler = this.imageEventHandler_1;
				ImageEventHandler imageEventHandler2;
				do
				{
					imageEventHandler2 = imageEventHandler;
					ImageEventHandler value2 = (ImageEventHandler)Delegate.Remove(imageEventHandler2, value);
					imageEventHandler = Interlocked.CompareExchange(ref this.imageEventHandler_1, value2, imageEventHandler2);
				}
				while ((object)imageEventHandler != imageEventHandler2);
			}
		}

		/// <summary>Occurs when a new text frame has been created.</summary>
		[Attribute3("EVENT_TEXTFRAMECREATED")]
		[Attribute2("CAT_TEXTFRAMES")]
		public event TextFrameEventHandler TextFrameCreated
		{
			add
			{
				TextFrameEventHandler textFrameEventHandler = this.textFrameEventHandler_0;
				TextFrameEventHandler textFrameEventHandler2;
				do
				{
					textFrameEventHandler2 = textFrameEventHandler;
					TextFrameEventHandler value2 = (TextFrameEventHandler)Delegate.Combine(textFrameEventHandler2, value);
					textFrameEventHandler = Interlocked.CompareExchange(ref this.textFrameEventHandler_0, value2, textFrameEventHandler2);
				}
				while ((object)textFrameEventHandler != textFrameEventHandler2);
			}
			remove
			{
				TextFrameEventHandler textFrameEventHandler = this.textFrameEventHandler_0;
				TextFrameEventHandler textFrameEventHandler2;
				do
				{
					textFrameEventHandler2 = textFrameEventHandler;
					TextFrameEventHandler value2 = (TextFrameEventHandler)Delegate.Remove(textFrameEventHandler2, value);
					textFrameEventHandler = Interlocked.CompareExchange(ref this.textFrameEventHandler_0, value2, textFrameEventHandler2);
				}
				while ((object)textFrameEventHandler != textFrameEventHandler2);
			}
		}

		/// <summary>Occurs when a text frame has been deleted.</summary>
		[Attribute2("CAT_TEXTFRAMES")]
		[Attribute3("EVENT_TEXTFRAMEDELETED")]
		public event TextFrameEventHandler TextFrameDeleted
		{
			add
			{
				TextFrameEventHandler textFrameEventHandler = this.textFrameEventHandler_1;
				TextFrameEventHandler textFrameEventHandler2;
				do
				{
					textFrameEventHandler2 = textFrameEventHandler;
					TextFrameEventHandler value2 = (TextFrameEventHandler)Delegate.Combine(textFrameEventHandler2, value);
					textFrameEventHandler = Interlocked.CompareExchange(ref this.textFrameEventHandler_1, value2, textFrameEventHandler2);
				}
				while ((object)textFrameEventHandler != textFrameEventHandler2);
			}
			remove
			{
				TextFrameEventHandler textFrameEventHandler = this.textFrameEventHandler_1;
				TextFrameEventHandler textFrameEventHandler2;
				do
				{
					textFrameEventHandler2 = textFrameEventHandler;
					TextFrameEventHandler value2 = (TextFrameEventHandler)Delegate.Remove(textFrameEventHandler2, value);
					textFrameEventHandler = Interlocked.CompareExchange(ref this.textFrameEventHandler_1, value2, textFrameEventHandler2);
				}
				while ((object)textFrameEventHandler != textFrameEventHandler2);
			}
		}

		/// <summary>Occurs when a new chart has been created.</summary>
		[Attribute2("CAT_CHARTS")]
		[Attribute3("EVENT_CHARTCREATED")]
		public event ChartEventHandler ChartCreated
		{
			add
			{
				ChartEventHandler chartEventHandler = this.chartEventHandler_0;
				ChartEventHandler chartEventHandler2;
				do
				{
					chartEventHandler2 = chartEventHandler;
					ChartEventHandler value2 = (ChartEventHandler)Delegate.Combine(chartEventHandler2, value);
					chartEventHandler = Interlocked.CompareExchange(ref this.chartEventHandler_0, value2, chartEventHandler2);
				}
				while ((object)chartEventHandler != chartEventHandler2);
			}
			remove
			{
				ChartEventHandler chartEventHandler = this.chartEventHandler_0;
				ChartEventHandler chartEventHandler2;
				do
				{
					chartEventHandler2 = chartEventHandler;
					ChartEventHandler value2 = (ChartEventHandler)Delegate.Remove(chartEventHandler2, value);
					chartEventHandler = Interlocked.CompareExchange(ref this.chartEventHandler_0, value2, chartEventHandler2);
				}
				while ((object)chartEventHandler != chartEventHandler2);
			}
		}

		/// <summary>Occurs when a chart has been deleted.</summary>
		[Attribute3("EVENT_CHARTDELETED")]
		[Attribute2("CAT_CHARTS")]
		public event ChartEventHandler ChartDeleted
		{
			add
			{
				ChartEventHandler chartEventHandler = this.chartEventHandler_1;
				ChartEventHandler chartEventHandler2;
				do
				{
					chartEventHandler2 = chartEventHandler;
					ChartEventHandler value2 = (ChartEventHandler)Delegate.Combine(chartEventHandler2, value);
					chartEventHandler = Interlocked.CompareExchange(ref this.chartEventHandler_1, value2, chartEventHandler2);
				}
				while ((object)chartEventHandler != chartEventHandler2);
			}
			remove
			{
				ChartEventHandler chartEventHandler = this.chartEventHandler_1;
				ChartEventHandler chartEventHandler2;
				do
				{
					chartEventHandler2 = chartEventHandler;
					ChartEventHandler value2 = (ChartEventHandler)Delegate.Remove(chartEventHandler2, value);
					chartEventHandler = Interlocked.CompareExchange(ref this.chartEventHandler_1, value2, chartEventHandler2);
				}
				while ((object)chartEventHandler != chartEventHandler2);
			}
		}

		/// <summary>Occurs when a new barcode has been created.</summary>
		[Attribute2("CAT_BARCODES")]
		[Attribute3("EVENT_BARCODECREATED")]
		public event BarcodeEventHandler BarcodeCreated
		{
			add
			{
				BarcodeEventHandler barcodeEventHandler = this.barcodeEventHandler_0;
				BarcodeEventHandler barcodeEventHandler2;
				do
				{
					barcodeEventHandler2 = barcodeEventHandler;
					BarcodeEventHandler value2 = (BarcodeEventHandler)Delegate.Combine(barcodeEventHandler2, value);
					barcodeEventHandler = Interlocked.CompareExchange(ref this.barcodeEventHandler_0, value2, barcodeEventHandler2);
				}
				while ((object)barcodeEventHandler != barcodeEventHandler2);
			}
			remove
			{
				BarcodeEventHandler barcodeEventHandler = this.barcodeEventHandler_0;
				BarcodeEventHandler barcodeEventHandler2;
				do
				{
					barcodeEventHandler2 = barcodeEventHandler;
					BarcodeEventHandler value2 = (BarcodeEventHandler)Delegate.Remove(barcodeEventHandler2, value);
					barcodeEventHandler = Interlocked.CompareExchange(ref this.barcodeEventHandler_0, value2, barcodeEventHandler2);
				}
				while ((object)barcodeEventHandler != barcodeEventHandler2);
			}
		}

		/// <summary>Occurs when a barcode has been deleted.</summary>
		[Attribute2("CAT_BARCODES")]
		[Attribute3("EVENT_BARCODEDELETED")]
		public event BarcodeEventHandler BarcodeDeleted
		{
			add
			{
				BarcodeEventHandler barcodeEventHandler = this.barcodeEventHandler_1;
				BarcodeEventHandler barcodeEventHandler2;
				do
				{
					barcodeEventHandler2 = barcodeEventHandler;
					BarcodeEventHandler value2 = (BarcodeEventHandler)Delegate.Combine(barcodeEventHandler2, value);
					barcodeEventHandler = Interlocked.CompareExchange(ref this.barcodeEventHandler_1, value2, barcodeEventHandler2);
				}
				while ((object)barcodeEventHandler != barcodeEventHandler2);
			}
			remove
			{
				BarcodeEventHandler barcodeEventHandler = this.barcodeEventHandler_1;
				BarcodeEventHandler barcodeEventHandler2;
				do
				{
					barcodeEventHandler2 = barcodeEventHandler;
					BarcodeEventHandler value2 = (BarcodeEventHandler)Delegate.Remove(barcodeEventHandler2, value);
					barcodeEventHandler = Interlocked.CompareExchange(ref this.barcodeEventHandler_1, value2, barcodeEventHandler2);
				}
				while ((object)barcodeEventHandler != barcodeEventHandler2);
			}
		}

		/// <summary>Occurs when a new drawing has been created.</summary>
		[Attribute2("CAT_DRAWINGS")]
		[Attribute3("EVENT_DRAWINGCREATED")]
		public event DrawingEventHandler DrawingCreated
		{
			add
			{
				DrawingEventHandler drawingEventHandler = this.drawingEventHandler_0;
				DrawingEventHandler drawingEventHandler2;
				do
				{
					drawingEventHandler2 = drawingEventHandler;
					DrawingEventHandler value2 = (DrawingEventHandler)Delegate.Combine(drawingEventHandler2, value);
					drawingEventHandler = Interlocked.CompareExchange(ref this.drawingEventHandler_0, value2, drawingEventHandler2);
				}
				while ((object)drawingEventHandler != drawingEventHandler2);
			}
			remove
			{
				DrawingEventHandler drawingEventHandler = this.drawingEventHandler_0;
				DrawingEventHandler drawingEventHandler2;
				do
				{
					drawingEventHandler2 = drawingEventHandler;
					DrawingEventHandler value2 = (DrawingEventHandler)Delegate.Remove(drawingEventHandler2, value);
					drawingEventHandler = Interlocked.CompareExchange(ref this.drawingEventHandler_0, value2, drawingEventHandler2);
				}
				while ((object)drawingEventHandler != drawingEventHandler2);
			}
		}

		/// <summary>Occurs when a drawing has been deleted.</summary>
		[Attribute2("CAT_DRAWINGS")]
		[Attribute3("EVENT_DRAWINGDELETED")]
		public event DrawingEventHandler DrawingDeleted
		{
			add
			{
				DrawingEventHandler drawingEventHandler = this.drawingEventHandler_1;
				DrawingEventHandler drawingEventHandler2;
				do
				{
					drawingEventHandler2 = drawingEventHandler;
					DrawingEventHandler value2 = (DrawingEventHandler)Delegate.Combine(drawingEventHandler2, value);
					drawingEventHandler = Interlocked.CompareExchange(ref this.drawingEventHandler_1, value2, drawingEventHandler2);
				}
				while ((object)drawingEventHandler != drawingEventHandler2);
			}
			remove
			{
				DrawingEventHandler drawingEventHandler = this.drawingEventHandler_1;
				DrawingEventHandler drawingEventHandler2;
				do
				{
					drawingEventHandler2 = drawingEventHandler;
					DrawingEventHandler value2 = (DrawingEventHandler)Delegate.Remove(drawingEventHandler2, value);
					drawingEventHandler = Interlocked.CompareExchange(ref this.drawingEventHandler_1, value2, drawingEventHandler2);
				}
				while ((object)drawingEventHandler != drawingEventHandler2);
			}
		}

		/// <summary>Occurs after a new table has been created when loading a document which contains a table without an identifier.</summary>
		[Attribute3("EVENT_TABLECREATED")]
		[Attribute2("CAT_TABLE")]
		public event TableEventHandler TableCreated
		{
			add
			{
				TableEventHandler tableEventHandler = this.tableEventHandler_0;
				TableEventHandler tableEventHandler2;
				do
				{
					tableEventHandler2 = tableEventHandler;
					TableEventHandler value2 = (TableEventHandler)Delegate.Combine(tableEventHandler2, value);
					tableEventHandler = Interlocked.CompareExchange(ref this.tableEventHandler_0, value2, tableEventHandler2);
				}
				while ((object)tableEventHandler != tableEventHandler2);
			}
			remove
			{
				TableEventHandler tableEventHandler = this.tableEventHandler_0;
				TableEventHandler tableEventHandler2;
				do
				{
					tableEventHandler2 = tableEventHandler;
					TableEventHandler value2 = (TableEventHandler)Delegate.Remove(tableEventHandler2, value);
					tableEventHandler = Interlocked.CompareExchange(ref this.tableEventHandler_0, value2, tableEventHandler2);
				}
				while ((object)tableEventHandler != tableEventHandler2);
			}
		}

		/// <summary>Occurs after a table has been deleted.</summary>
		[Attribute3("EVENT_TABLEDELETED")]
		[Attribute2("CAT_TABLE")]
		public event TableEventHandler TableDeleted
		{
			add
			{
				TableEventHandler tableEventHandler = this.tableEventHandler_1;
				TableEventHandler tableEventHandler2;
				do
				{
					tableEventHandler2 = tableEventHandler;
					TableEventHandler value2 = (TableEventHandler)Delegate.Combine(tableEventHandler2, value);
					tableEventHandler = Interlocked.CompareExchange(ref this.tableEventHandler_1, value2, tableEventHandler2);
				}
				while ((object)tableEventHandler != tableEventHandler2);
			}
			remove
			{
				TableEventHandler tableEventHandler = this.tableEventHandler_1;
				TableEventHandler tableEventHandler2;
				do
				{
					tableEventHandler2 = tableEventHandler;
					TableEventHandler value2 = (TableEventHandler)Delegate.Remove(tableEventHandler2, value);
					tableEventHandler = Interlocked.CompareExchange(ref this.tableEventHandler_1, value2, tableEventHandler2);
				}
				while ((object)tableEventHandler != tableEventHandler2);
			}
		}

		/// <summary>Occurs when a subtextpart has been created.</summary>
		[Attribute2("CAT_SUBTEXTPARTS")]
		[Attribute3("EVENT_SUBTEXTPARTCREATED")]
		public event SubTextPartEventHandler SubTextPartCreated
		{
			add
			{
				SubTextPartEventHandler subTextPartEventHandler = this.subTextPartEventHandler_0;
				SubTextPartEventHandler subTextPartEventHandler2;
				do
				{
					subTextPartEventHandler2 = subTextPartEventHandler;
					SubTextPartEventHandler value2 = (SubTextPartEventHandler)Delegate.Combine(subTextPartEventHandler2, value);
					subTextPartEventHandler = Interlocked.CompareExchange(ref this.subTextPartEventHandler_0, value2, subTextPartEventHandler2);
				}
				while ((object)subTextPartEventHandler != subTextPartEventHandler2);
			}
			remove
			{
				SubTextPartEventHandler subTextPartEventHandler = this.subTextPartEventHandler_0;
				SubTextPartEventHandler subTextPartEventHandler2;
				do
				{
					subTextPartEventHandler2 = subTextPartEventHandler;
					SubTextPartEventHandler value2 = (SubTextPartEventHandler)Delegate.Remove(subTextPartEventHandler2, value);
					subTextPartEventHandler = Interlocked.CompareExchange(ref this.subTextPartEventHandler_0, value2, subTextPartEventHandler2);
				}
				while ((object)subTextPartEventHandler != subTextPartEventHandler2);
			}
		}

		/// <summary>Occurs when a subtextpart has been deleted.</summary>
		[Attribute3("EVENT_SUBTEXTPARTDELETED")]
		[Attribute2("CAT_SUBTEXTPARTS")]
		public event SubTextPartEventHandler SubTextPartDeleted
		{
			add
			{
				SubTextPartEventHandler subTextPartEventHandler = this.subTextPartEventHandler_1;
				SubTextPartEventHandler subTextPartEventHandler2;
				do
				{
					subTextPartEventHandler2 = subTextPartEventHandler;
					SubTextPartEventHandler value2 = (SubTextPartEventHandler)Delegate.Combine(subTextPartEventHandler2, value);
					subTextPartEventHandler = Interlocked.CompareExchange(ref this.subTextPartEventHandler_1, value2, subTextPartEventHandler2);
				}
				while ((object)subTextPartEventHandler != subTextPartEventHandler2);
			}
			remove
			{
				SubTextPartEventHandler subTextPartEventHandler = this.subTextPartEventHandler_1;
				SubTextPartEventHandler subTextPartEventHandler2;
				do
				{
					subTextPartEventHandler2 = subTextPartEventHandler;
					SubTextPartEventHandler value2 = (SubTextPartEventHandler)Delegate.Remove(subTextPartEventHandler2, value);
					subTextPartEventHandler = Interlocked.CompareExchange(ref this.subTextPartEventHandler_1, value2, subTextPartEventHandler2);
				}
				while ((object)subTextPartEventHandler != subTextPartEventHandler2);
			}
		}

		/// <summary>Occurs when an editable region has been created.</summary>
		[Attribute2("CAT_SUBTEXTPARTS")]
		[Attribute3("EVENT_EDITABLEREGIONCREATED")]
		public event EditableRegionEventHandler EditableRegionCreated
		{
			add
			{
				EditableRegionEventHandler editableRegionEventHandler = this.editableRegionEventHandler_0;
				EditableRegionEventHandler editableRegionEventHandler2;
				do
				{
					editableRegionEventHandler2 = editableRegionEventHandler;
					EditableRegionEventHandler value2 = (EditableRegionEventHandler)Delegate.Combine(editableRegionEventHandler2, value);
					editableRegionEventHandler = Interlocked.CompareExchange(ref this.editableRegionEventHandler_0, value2, editableRegionEventHandler2);
				}
				while ((object)editableRegionEventHandler != editableRegionEventHandler2);
			}
			remove
			{
				EditableRegionEventHandler editableRegionEventHandler = this.editableRegionEventHandler_0;
				EditableRegionEventHandler editableRegionEventHandler2;
				do
				{
					editableRegionEventHandler2 = editableRegionEventHandler;
					EditableRegionEventHandler value2 = (EditableRegionEventHandler)Delegate.Remove(editableRegionEventHandler2, value);
					editableRegionEventHandler = Interlocked.CompareExchange(ref this.editableRegionEventHandler_0, value2, editableRegionEventHandler2);
				}
				while ((object)editableRegionEventHandler != editableRegionEventHandler2);
			}
		}

		/// <summary>Occurs when an editable region has been deleted.</summary>
		[Attribute2("CAT_SUBTEXTPARTS")]
		[Attribute3("EVENT_EDITABLEREGIONDELETED")]
		public event EditableRegionEventHandler EditableRegionDeleted
		{
			add
			{
				EditableRegionEventHandler editableRegionEventHandler = this.editableRegionEventHandler_1;
				EditableRegionEventHandler editableRegionEventHandler2;
				do
				{
					editableRegionEventHandler2 = editableRegionEventHandler;
					EditableRegionEventHandler value2 = (EditableRegionEventHandler)Delegate.Combine(editableRegionEventHandler2, value);
					editableRegionEventHandler = Interlocked.CompareExchange(ref this.editableRegionEventHandler_1, value2, editableRegionEventHandler2);
				}
				while ((object)editableRegionEventHandler != editableRegionEventHandler2);
			}
			remove
			{
				EditableRegionEventHandler editableRegionEventHandler = this.editableRegionEventHandler_1;
				EditableRegionEventHandler editableRegionEventHandler2;
				do
				{
					editableRegionEventHandler2 = editableRegionEventHandler;
					EditableRegionEventHandler value2 = (EditableRegionEventHandler)Delegate.Remove(editableRegionEventHandler2, value);
					editableRegionEventHandler = Interlocked.CompareExchange(ref this.editableRegionEventHandler_1, value2, editableRegionEventHandler2);
				}
				while ((object)editableRegionEventHandler != editableRegionEventHandler2);
			}
		}

		/// <summary>Occurs when a tracked change has been created.</summary>
		[Attribute2("CAT_SUBTEXTPARTS")]
		[Attribute3("EVENT_TRACKEDCHANGECREATED")]
		public event TrackedChangeEventHandler TrackedChangeCreated
		{
			add
			{
				TrackedChangeEventHandler trackedChangeEventHandler = this.trackedChangeEventHandler_0;
				TrackedChangeEventHandler trackedChangeEventHandler2;
				do
				{
					trackedChangeEventHandler2 = trackedChangeEventHandler;
					TrackedChangeEventHandler value2 = (TrackedChangeEventHandler)Delegate.Combine(trackedChangeEventHandler2, value);
					trackedChangeEventHandler = Interlocked.CompareExchange(ref this.trackedChangeEventHandler_0, value2, trackedChangeEventHandler2);
				}
				while ((object)trackedChangeEventHandler != trackedChangeEventHandler2);
			}
			remove
			{
				TrackedChangeEventHandler trackedChangeEventHandler = this.trackedChangeEventHandler_0;
				TrackedChangeEventHandler trackedChangeEventHandler2;
				do
				{
					trackedChangeEventHandler2 = trackedChangeEventHandler;
					TrackedChangeEventHandler value2 = (TrackedChangeEventHandler)Delegate.Remove(trackedChangeEventHandler2, value);
					trackedChangeEventHandler = Interlocked.CompareExchange(ref this.trackedChangeEventHandler_0, value2, trackedChangeEventHandler2);
				}
				while ((object)trackedChangeEventHandler != trackedChangeEventHandler2);
			}
		}

		/// <summary>Occurs when a tracked change has been deleted.</summary>
		[Attribute3("EVENT_TRACKEDCHANGEDELETED")]
		[Attribute2("CAT_SUBTEXTPARTS")]
		public event TrackedChangeEventHandler TrackedChangeDeleted
		{
			add
			{
				TrackedChangeEventHandler trackedChangeEventHandler = this.trackedChangeEventHandler_1;
				TrackedChangeEventHandler trackedChangeEventHandler2;
				do
				{
					trackedChangeEventHandler2 = trackedChangeEventHandler;
					TrackedChangeEventHandler value2 = (TrackedChangeEventHandler)Delegate.Combine(trackedChangeEventHandler2, value);
					trackedChangeEventHandler = Interlocked.CompareExchange(ref this.trackedChangeEventHandler_1, value2, trackedChangeEventHandler2);
				}
				while ((object)trackedChangeEventHandler != trackedChangeEventHandler2);
			}
			remove
			{
				TrackedChangeEventHandler trackedChangeEventHandler = this.trackedChangeEventHandler_1;
				TrackedChangeEventHandler trackedChangeEventHandler2;
				do
				{
					trackedChangeEventHandler2 = trackedChangeEventHandler;
					TrackedChangeEventHandler value2 = (TrackedChangeEventHandler)Delegate.Remove(trackedChangeEventHandler2, value);
					trackedChangeEventHandler = Interlocked.CompareExchange(ref this.trackedChangeEventHandler_1, value2, trackedChangeEventHandler2);
				}
				while ((object)trackedChangeEventHandler != trackedChangeEventHandler2);
			}
		}

		/// <summary>Occurs when a document target has been created.</summary>
		[Attribute2("CAT_DOCUMENTTARGETS")]
		[Attribute3("EVENT_DOCUMENTTARGETCREATED")]
		public event DocumentTargetEventHandler DocumentTargetCreated
		{
			add
			{
				DocumentTargetEventHandler documentTargetEventHandler = this.documentTargetEventHandler_0;
				DocumentTargetEventHandler documentTargetEventHandler2;
				do
				{
					documentTargetEventHandler2 = documentTargetEventHandler;
					DocumentTargetEventHandler value2 = (DocumentTargetEventHandler)Delegate.Combine(documentTargetEventHandler2, value);
					documentTargetEventHandler = Interlocked.CompareExchange(ref this.documentTargetEventHandler_0, value2, documentTargetEventHandler2);
				}
				while ((object)documentTargetEventHandler != documentTargetEventHandler2);
			}
			remove
			{
				DocumentTargetEventHandler documentTargetEventHandler = this.documentTargetEventHandler_0;
				DocumentTargetEventHandler documentTargetEventHandler2;
				do
				{
					documentTargetEventHandler2 = documentTargetEventHandler;
					DocumentTargetEventHandler value2 = (DocumentTargetEventHandler)Delegate.Remove(documentTargetEventHandler2, value);
					documentTargetEventHandler = Interlocked.CompareExchange(ref this.documentTargetEventHandler_0, value2, documentTargetEventHandler2);
				}
				while ((object)documentTargetEventHandler != documentTargetEventHandler2);
			}
		}

		/// <summary>Occurs when a document target has been deleted.</summary>
		[Attribute2("CAT_DOCUMENTTARGETS")]
		[Attribute3("EVENT_DOCUMENTTARGETDELETED")]
		public event DocumentTargetEventHandler DocumentTargetDeleted
		{
			add
			{
				DocumentTargetEventHandler documentTargetEventHandler = this.documentTargetEventHandler_1;
				DocumentTargetEventHandler documentTargetEventHandler2;
				do
				{
					documentTargetEventHandler2 = documentTargetEventHandler;
					DocumentTargetEventHandler value2 = (DocumentTargetEventHandler)Delegate.Combine(documentTargetEventHandler2, value);
					documentTargetEventHandler = Interlocked.CompareExchange(ref this.documentTargetEventHandler_1, value2, documentTargetEventHandler2);
				}
				while ((object)documentTargetEventHandler != documentTargetEventHandler2);
			}
			remove
			{
				DocumentTargetEventHandler documentTargetEventHandler = this.documentTargetEventHandler_1;
				DocumentTargetEventHandler documentTargetEventHandler2;
				do
				{
					documentTargetEventHandler2 = documentTargetEventHandler;
					DocumentTargetEventHandler value2 = (DocumentTargetEventHandler)Delegate.Remove(documentTargetEventHandler2, value);
					documentTargetEventHandler = Interlocked.CompareExchange(ref this.documentTargetEventHandler_1, value2, documentTargetEventHandler2);
				}
				while ((object)documentTargetEventHandler != documentTargetEventHandler2);
			}
		}

		/// <summary>Occurs when a table of contents has been created.</summary>
		[Attribute3("EVENT_TOCCREATED")]
		[Attribute2("CAT_TOC")]
		public event TableOfContentsEventHandler TableOfContentsCreated
		{
			add
			{
				TableOfContentsEventHandler tableOfContentsEventHandler = this.tableOfContentsEventHandler_0;
				TableOfContentsEventHandler tableOfContentsEventHandler2;
				do
				{
					tableOfContentsEventHandler2 = tableOfContentsEventHandler;
					TableOfContentsEventHandler value2 = (TableOfContentsEventHandler)Delegate.Combine(tableOfContentsEventHandler2, value);
					tableOfContentsEventHandler = Interlocked.CompareExchange(ref this.tableOfContentsEventHandler_0, value2, tableOfContentsEventHandler2);
				}
				while ((object)tableOfContentsEventHandler != tableOfContentsEventHandler2);
			}
			remove
			{
				TableOfContentsEventHandler tableOfContentsEventHandler = this.tableOfContentsEventHandler_0;
				TableOfContentsEventHandler tableOfContentsEventHandler2;
				do
				{
					tableOfContentsEventHandler2 = tableOfContentsEventHandler;
					TableOfContentsEventHandler value2 = (TableOfContentsEventHandler)Delegate.Remove(tableOfContentsEventHandler2, value);
					tableOfContentsEventHandler = Interlocked.CompareExchange(ref this.tableOfContentsEventHandler_0, value2, tableOfContentsEventHandler2);
				}
				while ((object)tableOfContentsEventHandler != tableOfContentsEventHandler2);
			}
		}

		/// <summary>Occurs when a table of contents has been deleted.</summary>
		[Attribute3("EVENT_TOCDELETED")]
		[Attribute2("CAT_TOC")]
		public event TableOfContentsEventHandler TableOfContentsDeleted
		{
			add
			{
				TableOfContentsEventHandler tableOfContentsEventHandler = this.tableOfContentsEventHandler_1;
				TableOfContentsEventHandler tableOfContentsEventHandler2;
				do
				{
					tableOfContentsEventHandler2 = tableOfContentsEventHandler;
					TableOfContentsEventHandler value2 = (TableOfContentsEventHandler)Delegate.Combine(tableOfContentsEventHandler2, value);
					tableOfContentsEventHandler = Interlocked.CompareExchange(ref this.tableOfContentsEventHandler_1, value2, tableOfContentsEventHandler2);
				}
				while ((object)tableOfContentsEventHandler != tableOfContentsEventHandler2);
			}
			remove
			{
				TableOfContentsEventHandler tableOfContentsEventHandler = this.tableOfContentsEventHandler_1;
				TableOfContentsEventHandler tableOfContentsEventHandler2;
				do
				{
					tableOfContentsEventHandler2 = tableOfContentsEventHandler;
					TableOfContentsEventHandler value2 = (TableOfContentsEventHandler)Delegate.Remove(tableOfContentsEventHandler2, value);
					tableOfContentsEventHandler = Interlocked.CompareExchange(ref this.tableOfContentsEventHandler_1, value2, tableOfContentsEventHandler2);
				}
				while ((object)tableOfContentsEventHandler != tableOfContentsEventHandler2);
			}
		}

		/// <summary>Occurs when a text field has been created.</summary>
		[Attribute3("EVENT_FIELDCREATED")]
		[Attribute2("CAT_FIELDS")]
		public event TextFieldEventHandler TextFieldCreated
		{
			add
			{
				TextFieldEventHandler textFieldEventHandler = this.textFieldEventHandler_0;
				TextFieldEventHandler textFieldEventHandler2;
				do
				{
					textFieldEventHandler2 = textFieldEventHandler;
					TextFieldEventHandler value2 = (TextFieldEventHandler)Delegate.Combine(textFieldEventHandler2, value);
					textFieldEventHandler = Interlocked.CompareExchange(ref this.textFieldEventHandler_0, value2, textFieldEventHandler2);
				}
				while ((object)textFieldEventHandler != textFieldEventHandler2);
			}
			remove
			{
				TextFieldEventHandler textFieldEventHandler = this.textFieldEventHandler_0;
				TextFieldEventHandler textFieldEventHandler2;
				do
				{
					textFieldEventHandler2 = textFieldEventHandler;
					TextFieldEventHandler value2 = (TextFieldEventHandler)Delegate.Remove(textFieldEventHandler2, value);
					textFieldEventHandler = Interlocked.CompareExchange(ref this.textFieldEventHandler_0, value2, textFieldEventHandler2);
				}
				while ((object)textFieldEventHandler != textFieldEventHandler2);
			}
		}

		/// <summary>Occurs when a text field has been deleted.</summary>
		[Attribute2("CAT_FIELDS")]
		[Attribute3("EVENT_FIELDDELETED")]
		public event TextFieldEventHandler TextFieldDeleted
		{
			add
			{
				TextFieldEventHandler textFieldEventHandler = this.textFieldEventHandler_1;
				TextFieldEventHandler textFieldEventHandler2;
				do
				{
					textFieldEventHandler2 = textFieldEventHandler;
					TextFieldEventHandler value2 = (TextFieldEventHandler)Delegate.Combine(textFieldEventHandler2, value);
					textFieldEventHandler = Interlocked.CompareExchange(ref this.textFieldEventHandler_1, value2, textFieldEventHandler2);
				}
				while ((object)textFieldEventHandler != textFieldEventHandler2);
			}
			remove
			{
				TextFieldEventHandler textFieldEventHandler = this.textFieldEventHandler_1;
				TextFieldEventHandler textFieldEventHandler2;
				do
				{
					textFieldEventHandler2 = textFieldEventHandler;
					TextFieldEventHandler value2 = (TextFieldEventHandler)Delegate.Remove(textFieldEventHandler2, value);
					textFieldEventHandler = Interlocked.CompareExchange(ref this.textFieldEventHandler_1, value2, textFieldEventHandler2);
				}
				while ((object)textFieldEventHandler != textFieldEventHandler2);
			}
		}

		/// <summary>Occurs when a loaded XML document is not well-formed.</summary>
		[Attribute3("EVENT_XMLNOTWELLFORMED")]
		[Attribute2("CAT_XML")]
		public event XmlErrorEventHandler XmlNotWellFormed
		{
			add
			{
				XmlErrorEventHandler xmlErrorEventHandler = this.xmlErrorEventHandler_0;
				XmlErrorEventHandler xmlErrorEventHandler2;
				do
				{
					xmlErrorEventHandler2 = xmlErrorEventHandler;
					XmlErrorEventHandler value2 = (XmlErrorEventHandler)Delegate.Combine(xmlErrorEventHandler2, value);
					xmlErrorEventHandler = Interlocked.CompareExchange(ref this.xmlErrorEventHandler_0, value2, xmlErrorEventHandler2);
				}
				while ((object)xmlErrorEventHandler != xmlErrorEventHandler2);
			}
			remove
			{
				XmlErrorEventHandler xmlErrorEventHandler = this.xmlErrorEventHandler_0;
				XmlErrorEventHandler xmlErrorEventHandler2;
				do
				{
					xmlErrorEventHandler2 = xmlErrorEventHandler;
					XmlErrorEventHandler value2 = (XmlErrorEventHandler)Delegate.Remove(xmlErrorEventHandler2, value);
					xmlErrorEventHandler = Interlocked.CompareExchange(ref this.xmlErrorEventHandler_0, value2, xmlErrorEventHandler2);
				}
				while ((object)xmlErrorEventHandler != xmlErrorEventHandler2);
			}
		}

		/// <summary>Occurs when a loaded or changed XML document cannot be validated with the document type definition (DTD) referenced in the document.</summary>
		[Attribute3("EVENT_XMLINVALID")]
		[Attribute2("CAT_XML")]
		public event XmlErrorEventHandler XmlInvalid
		{
			add
			{
				XmlErrorEventHandler xmlErrorEventHandler = this.xmlErrorEventHandler_1;
				XmlErrorEventHandler xmlErrorEventHandler2;
				do
				{
					xmlErrorEventHandler2 = xmlErrorEventHandler;
					XmlErrorEventHandler value2 = (XmlErrorEventHandler)Delegate.Combine(xmlErrorEventHandler2, value);
					xmlErrorEventHandler = Interlocked.CompareExchange(ref this.xmlErrorEventHandler_1, value2, xmlErrorEventHandler2);
				}
				while ((object)xmlErrorEventHandler != xmlErrorEventHandler2);
			}
			remove
			{
				XmlErrorEventHandler xmlErrorEventHandler = this.xmlErrorEventHandler_1;
				XmlErrorEventHandler xmlErrorEventHandler2;
				do
				{
					xmlErrorEventHandler2 = xmlErrorEventHandler;
					XmlErrorEventHandler value2 = (XmlErrorEventHandler)Delegate.Remove(xmlErrorEventHandler2, value);
					xmlErrorEventHandler = Interlocked.CompareExchange(ref this.xmlErrorEventHandler_1, value2, xmlErrorEventHandler2);
				}
				while ((object)xmlErrorEventHandler != xmlErrorEventHandler2);
			}
		}

		/// <summary>Occurs, if the document's text has been altered and the spelling of the new text must be checked.</summary>
		[Attribute2("Behavior")]
		[Attribute3("EVENT_SPELLCHECKTEXT")]
		public event SpellCheckTextEventHandler SpellCheckText
		{
			add
			{
				SpellCheckTextEventHandler spellCheckTextEventHandler = this.spellCheckTextEventHandler_0;
				SpellCheckTextEventHandler spellCheckTextEventHandler2;
				do
				{
					spellCheckTextEventHandler2 = spellCheckTextEventHandler;
					SpellCheckTextEventHandler value2 = (SpellCheckTextEventHandler)Delegate.Combine(spellCheckTextEventHandler2, value);
					spellCheckTextEventHandler = Interlocked.CompareExchange(ref this.spellCheckTextEventHandler_0, value2, spellCheckTextEventHandler2);
				}
				while ((object)spellCheckTextEventHandler != spellCheckTextEventHandler2);
			}
			remove
			{
				SpellCheckTextEventHandler spellCheckTextEventHandler = this.spellCheckTextEventHandler_0;
				SpellCheckTextEventHandler spellCheckTextEventHandler2;
				do
				{
					spellCheckTextEventHandler2 = spellCheckTextEventHandler;
					SpellCheckTextEventHandler value2 = (SpellCheckTextEventHandler)Delegate.Remove(spellCheckTextEventHandler2, value);
					spellCheckTextEventHandler = Interlocked.CompareExchange(ref this.spellCheckTextEventHandler_0, value2, spellCheckTextEventHandler2);
				}
				while ((object)spellCheckTextEventHandler != spellCheckTextEventHandler2);
			}
		}

		/// <summary>Occurs, if a word does not fit on the line and must be hyphenated.</summary>
		[Attribute3("EVENT_HYPHENATEWORD")]
		[Attribute2("Behavior")]
		public event HyphenateWordEventHandler HyphenateWord
		{
			add
			{
				HyphenateWordEventHandler hyphenateWordEventHandler = this.hyphenateWordEventHandler_0;
				HyphenateWordEventHandler hyphenateWordEventHandler2;
				do
				{
					hyphenateWordEventHandler2 = hyphenateWordEventHandler;
					HyphenateWordEventHandler value2 = (HyphenateWordEventHandler)Delegate.Combine(hyphenateWordEventHandler2, value);
					hyphenateWordEventHandler = Interlocked.CompareExchange(ref this.hyphenateWordEventHandler_0, value2, hyphenateWordEventHandler2);
				}
				while ((object)hyphenateWordEventHandler != hyphenateWordEventHandler2);
			}
			remove
			{
				HyphenateWordEventHandler hyphenateWordEventHandler = this.hyphenateWordEventHandler_0;
				HyphenateWordEventHandler hyphenateWordEventHandler2;
				do
				{
					hyphenateWordEventHandler2 = hyphenateWordEventHandler;
					HyphenateWordEventHandler value2 = (HyphenateWordEventHandler)Delegate.Remove(hyphenateWordEventHandler2, value);
					hyphenateWordEventHandler = Interlocked.CompareExchange(ref this.hyphenateWordEventHandler_0, value2, hyphenateWordEventHandler2);
				}
				while ((object)hyphenateWordEventHandler != hyphenateWordEventHandler2);
			}
		}

		/// <summary>Occurs for each font that must be adapted, because it is not supported.</summary>
		[Attribute3("EVENT_ADAPTFONT")]
		[Attribute2("Behavior")]
		public event AdaptFontEventHandler AdaptFont
		{
			add
			{
				AdaptFontEventHandler adaptFontEventHandler = this.adaptFontEventHandler_0;
				AdaptFontEventHandler adaptFontEventHandler2;
				do
				{
					adaptFontEventHandler2 = adaptFontEventHandler;
					AdaptFontEventHandler value2 = (AdaptFontEventHandler)Delegate.Combine(adaptFontEventHandler2, value);
					adaptFontEventHandler = Interlocked.CompareExchange(ref this.adaptFontEventHandler_0, value2, adaptFontEventHandler2);
				}
				while ((object)adaptFontEventHandler != adaptFontEventHandler2);
			}
			remove
			{
				AdaptFontEventHandler adaptFontEventHandler = this.adaptFontEventHandler_0;
				AdaptFontEventHandler adaptFontEventHandler2;
				do
				{
					adaptFontEventHandler2 = adaptFontEventHandler;
					AdaptFontEventHandler value2 = (AdaptFontEventHandler)Delegate.Remove(adaptFontEventHandler2, value);
					adaptFontEventHandler = Interlocked.CompareExchange(ref this.adaptFontEventHandler_0, value2, adaptFontEventHandler2);
				}
				while ((object)adaptFontEventHandler != adaptFontEventHandler2);
			}
		}

		/// <summary>Initializes a new instance of the ServerTextControl class. After initialization the Create method must be called to enable further resources.</summary>
		public ServerTextControl()
			: this(typeof(ServerTextControl))
		{
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public ServerTextControl(Type controlType)
		{
			this.class408_0 = new Class408();
			this.resourceManager_0 = new ResourceManager(typeof(TextControlCore));
			this.textControlCore_0 = new TextControlCore(this.resourceManager_0, this, MeasuringUnit.CentiInch);
			this.textControlCore_0.class408_0 = this.class408_0;
			this.inputPosition_0.method_0(this.textControlCore_0, TextPart.Auto);
			this.paragraphFormat_0.method_1(this.textControlCore_0, TextPart.Auto);
			this.listFormat_0.method_1(this.textControlCore_0, TextPart.Auto);
			this.pageSize_0.method_1(this.textControlCore_0, 0);
			this.pageMargins_0.method_1(this.textControlCore_0, 0);
			this.delegate9_0 = method_2;
			this.delegate10_0 = method_3;
			this.delegate11_0 = method_5;
			this.delegate12_0 = method_4;
			this.method_1();
		}

		/// <summary>Initializes the resources of a newly instantiated object. This method must be called before using the object.</summary>
		public bool Create()
		{
			if (this.textControlCore_0.isHandleCreated)
			{
				return false;
			}
			//
			this.textControlCore_0.IntPtr_0 = Class429.CreateWindowEx(0u, "TX29_DOTNET", "", 2147483648u, 0, 0, 1000, 1000, IntPtr.Zero, IntPtr.Zero, IntPtr.Zero, IntPtr.Zero);
			if (!this.textControlCore_0.isHandleCreated)
			{
				return false;
			}
			this.m_WndProc = method_0;
			this.intptr_0 = Class429.smethod_11(this.textControlCore_0.IntPtr_0, -4);
			Class429.smethod_12(this.textControlCore_0.IntPtr_0, -4, Marshal.GetFunctionPointerForDelegate((Delegate)this.m_WndProc));
			this.textControlCore_0.method_30((Enum83)1348, 3, (int)Enum115.Enterprise);
			this.vmethod_0();
			this.inputPosition_0.method_3();
			this.delegate7_0 = method_6;
			this.textControlCore_0.method_73(Enum83.const_218, 0, this.delegate7_0);
			return true;
		}

		public virtual void vmethod_0()
		{
			this.textControlCore_0.method_30(Enum83.const_205, 0, 0);
			this.textControlCore_0.method_27(this.string_0);
			this.textControlCore_0.method_30(Enum83.const_30, 2097161, 0);
			this.textControlCore_0.method_30(Enum83.const_40, 327698, (this.bool_1 ? 128 : 512) | ((this.formulaReferenceStyle_0 == FormulaReferenceStyle.R1C1) ? 256 : 65536));
			this.textControlCore_0.method_30(Enum83.const_41, (this.color_0 == SystemColors.Window) ? 1 : 0, Class429.smethod_0(this.color_0));
			this.textControlCore_0.method_30(Enum83.const_227, 0, (int)this.viewMode_1);
			this.textControlCore_0.method_30(Enum83.const_235, 0, this.bool_5 ? 1073741824 : int.MinValue);
			this.pageSize_0.Boolean_0 = this.bool_5;
			this.pageSize_0.method_2();
			this.pageSize_0.method_6();
			this.pageMargins_0.method_2();
			this.pageMargins_0.method_6();
			this.textControlCore_0.method_12(TextPart.Auto);
			this.textControlCore_0.method_9(TextPart.Auto);
			this.textControlCore_0.method_29(TextPart.Auto, 1160, (this.int_0 == 0) ? 2 : ((this.int_0 < 0) ? 8 : 4), Math.Abs(this.int_0));
			int[] int_ = new int[2]
			{
				Class429.smethod_0(this.ForeColor),
				Class429.smethod_0(this.TextBackColor)
			};
			this.textControlCore_0.method_40(TextPart.Auto, 1168, ((this.ForeColor == SystemColors.WindowText) ? 1 : 2) | ((this.TextBackColor == this.color_0) ? 16 : ((this.TextBackColor == SystemColors.Window) ? 4 : 8)), int_);
			this.paragraphFormat_0.method_11();
			this.listFormat_0.method_8();
			this.listFormat_0.method_12();
			this.textControlCore_0.method_15(TextPart.Auto);
			if (this.bool_3)
			{
				this.textControlCore_0.method_76(Enum83.const_275, 1, this.delegate10_0);
			}
			if (this.bool_4)
			{
				this.textControlCore_0.method_78(Enum83.const_38, 1, this.delegate11_0);
			}
			if (this.bool_2)
			{
				this.textControlCore_0.method_77(Enum83.const_275, 3, this.delegate12_0);
			}
			if (base.GetType().Equals(typeof(ServerTextControl)))
			{
				this.textControlCore_0.method_29(TextPart.Auto, 2071, 1, 0);
			}
			this.fontSettings_0.method_0(this.textControlCore_0, this.delegate9_0);
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing && this.container_0 != null)
			{
				this.container_0.Dispose();
			}
			if (this.textControlCore_0 != null && this.textControlCore_0.isHandleCreated)
			{
				Class429.DestroyWindow(this.textControlCore_0.IntPtr_0);
				this.textControlCore_0.IntPtr_0 = IntPtr.Zero;
			}
			base.Dispose(disposing);
		}

		private IntPtr method_0(IntPtr intptr_1, int int_1, IntPtr intptr_2, IntPtr intptr_3)
		{
			return this.vmethod_1(intptr_1, int_1, intptr_2, intptr_3);
		}

		public virtual IntPtr vmethod_1(IntPtr intptr_1, int int_1, IntPtr intptr_2, IntPtr intptr_3)
		{
			ControlList controlList = this.textControlCore_0.control4_0;
			IntPtr result = IntPtr.Zero;
			switch (int_1)
			{
			case 2074:
			{
				Struct65 @struct = (Struct65)Marshal.PtrToStructure(intptr_3, typeof(Struct65));
				if (@struct.ushort_3 == 7)
				{
					controlList = this.textControlCore_0.control5_0;
				}
				else if (@struct.ushort_3 == 9)
				{
					controlList = this.textControlCore_0.control6_0;
				}
				result = ((@struct.ushort_2 == 1) ? controlList.DrawControlBitmapToMetafile(@struct.ushort_1, intptr_2, @struct.struct83_0.method_0()) : controlList.PrintControl(@struct.ushort_1, intptr_2, @struct.struct83_0.method_0(), @struct.bool_0));
				break;
			}
			case 2075:
				if (Class429.smethod_6(intptr_2.ToInt32()) == 7)
				{
					controlList = this.textControlCore_0.control5_0;
				}
				else if (Class429.smethod_6(intptr_2.ToInt32()) == 9)
				{
					controlList = this.textControlCore_0.control6_0;
				}
				result = (controlList.RemoveControl(Class429.smethod_5(intptr_2.ToInt32())) ? new IntPtr(1) : IntPtr.Zero);
				break;
			case 2076:
				if (Class429.smethod_6(intptr_2.ToInt32()) == 7)
				{
					controlList = this.textControlCore_0.control5_0;
				}
				else if (Class429.smethod_6(intptr_2.ToInt32()) == 9)
				{
					controlList = this.textControlCore_0.control6_0;
				}
				result = controlList.GetControlImageData(Class429.smethod_5(intptr_2.ToInt32()), intptr_3.ToInt32());
				break;
			case 2078:
			{
				Struct66 struct66_ = (Struct66)Marshal.PtrToStructure(intptr_3, typeof(Struct66));
				if (struct66_.ushort_2 != 7)
				{
					result = ((struct66_.ushort_2 == 8) ? this.textControlCore_0.control4_0.method_0(struct66_.ushort_1, ref struct66_) : this.textControlCore_0.control6_0.method_4(struct66_.ushort_1, ref struct66_));
					Marshal.StructureToPtr((object)struct66_, intptr_3, fDeleteOld: false);
				}
				break;
			}
			case 2079:
			{
				Struct66 struct66_ = (Struct66)Marshal.PtrToStructure(intptr_3, typeof(Struct66));
				if (struct66_.ushort_2 != 7)
				{
					result = ((struct66_.ushort_2 == 8) ? this.textControlCore_0.control4_0.method_1(struct66_.ushort_1, ref struct66_) : this.textControlCore_0.control6_0.method_5(struct66_.ushort_1, ref struct66_));
				}
				break;
			}
			case 2080:
			{
				Struct67 struct67_ = (Struct67)Marshal.PtrToStructure(intptr_3, typeof(Struct67));
				if (struct67_.ushort_2 == 8)
				{
					result = this.textControlCore_0.control4_0.method_2(struct67_.ushort_1, ref struct67_);
					Marshal.StructureToPtr((object)struct67_, intptr_3, fDeleteOld: false);
				}
				break;
			}
			case 2082:
				if (Class429.smethod_6(intptr_2.ToInt32()) == 7)
				{
					controlList = this.textControlCore_0.control5_0;
				}
				else if (Class429.smethod_6(intptr_2.ToInt32()) == 9)
				{
					controlList = this.textControlCore_0.control6_0;
				}
				result = controlList.GetControlData(Class429.smethod_5(intptr_2.ToInt32()), intptr_3);
				break;
			case 2083:
				if (Class429.smethod_6(intptr_2.ToInt32()) == 7)
				{
					controlList = this.textControlCore_0.control5_0;
				}
				else if (Class429.smethod_6(intptr_2.ToInt32()) == 9)
				{
					controlList = this.textControlCore_0.control6_0;
				}
				result = controlList.GetControlDataSize(Class429.smethod_5(intptr_2.ToInt32()));
				break;
			case 2084:
				if (Class429.smethod_6(intptr_2.ToInt32()) == 7)
				{
					controlList = this.textControlCore_0.control5_0;
				}
				else if (Class429.smethod_6(intptr_2.ToInt32()) == 9)
				{
					controlList = this.textControlCore_0.control6_0;
				}
				result = controlList.PasteControlData(Class429.smethod_5(intptr_2.ToInt32()), intptr_3);
				break;
			case 2085:
				if (Class429.smethod_6(intptr_3.ToInt32()) == 7)
				{
					controlList = this.textControlCore_0.control5_0;
				}
				else if (Class429.smethod_6(intptr_3.ToInt32()) == 9)
				{
					controlList = this.textControlCore_0.control6_0;
				}
				result = controlList.CreateControl(Class429.smethod_5(intptr_3.ToInt32()));
				break;
			default:
				result = Class429.CallWindowProc(this.intptr_0, intptr_1, int_1, intptr_2, intptr_3);
				break;
			case 2090:
				if (Class429.smethod_6(intptr_2.ToInt32()) == 9)
				{
					result = this.textControlCore_0.control6_0.method_1(Class429.smethod_5(intptr_2.ToInt32()), intptr_3);
				}
				break;
			case 2091:
				if (Class429.smethod_6(intptr_2.ToInt32()) == 9)
				{
					result = this.textControlCore_0.control6_0.method_2(Class429.smethod_5(intptr_2.ToInt32()), intptr_3);
				}
				break;
			case 2092:
				if (Class429.smethod_6(intptr_2.ToInt32()) == 9)
				{
					result = this.textControlCore_0.control6_0.method_0(Class429.smethod_5(intptr_2.ToInt32()), intptr_3.ToInt32());
				}
				break;
			}
			return result;
		}

		int ITextControl.OpenFileDialog(string strFilter, out string strFileName)
		{
			throw new NotSupportedException(this.resourceManager_0.GetString("ERR_SERVER_DIALOG"));
		}

		int ITextControl.SaveFileDialog(string strFilter, out string strFileName)
		{
			throw new NotSupportedException(this.resourceManager_0.GetString("ERR_SERVER_DIALOG"));
		}

		void ITextControl.CheckStreamType(StreamType iStreamType)
		{
			if (iStreamType == StreamType.AdobePDF || iStreamType == StreamType.MSWord || iStreamType == StreamType.WordprocessingML || iStreamType == StreamType.SpreadsheetML)
			{
				//
			}
			if (iStreamType == StreamType.CascadingStylesheet || iStreamType == StreamType.XMLFormat || iStreamType == StreamType.AdobePDFA)
			{
				
			}
		}

		PageSize ITextControl.GetPageSize()
		{
			return this.PageSize;
		}

		PageMargins ITextControl.GetPageMargins()
		{
			return this.PageMargins;
		}

		int ITextControl.GetFontSize()
		{
			return (int)(this.font_0.SizeInPoints * 20f);
		}

		string ITextControl.GetFontName()
		{
			return this.font_0.FontFamily.Name;
		}

		FontUnderlineStyle ITextControl.GetFontUnderlineStyle()
		{
			if (!this.font_0.Underline)
			{
				return FontUnderlineStyle.None;
			}
			return this.fontUnderlineStyle_0;
		}

		bool ITextControl.GetFontBold()
		{
			return this.font_0.Bold;
		}

		bool ITextControl.GetFontItalic()
		{
			return this.font_0.Italic;
		}

		bool ITextControl.GetFontStrikeout()
		{
			return this.font_0.Strikeout;
		}

		int ITextControl.GetBackColor()
		{
			return Class429.smethod_0(this.color_0);
		}

		ViewMode ITextControl.GetViewMode()
		{
			return this.viewMode_0;
		}

		uint ITextControl.GetDocumentBackColor()
		{
			if (!(this.color_0 == SystemColors.Window) && !(this.color_0 == Color.Transparent))
			{
				return (uint)Class429.smethod_0(this.color_0);
			}
			return 2147483648u;
		}

		void ITextControl.SetDocumentBackColor(uint uiColor)
		{
			if (uiColor != 2147483648u && uiColor != 1610612736)
			{
				this.BackColor = ((uiColor == 1073741824) ? SystemColors.Window : Class429.smethod_2((int)uiColor));
			}
		}

		int ITextControl.GetIsInDesignMode()
		{
			return 0;
		}

		string ITextControl.GetVersionKey()
		{
			return "XJ-33277";
		}

		Enum116 ITextControl.GetControlType()
		{
			return Enum116.const_3;
		}

		string ITextControl.GetLicGUID()
		{
			return "0f31e9c2-ca6c-11ea-8338-a0481c909ac9";
		}

		string ITextControl.GetTrialSearchString()
		{
			return "SXSerialNoXXX";
		}

		IConditionalInstructionsManager ITextControl.GetConditionalInstructionsManager()
		{
			return this.Class431_0;
		}

		private void method_1()
		{
			this.container_0 = new Container();
		}

		/// <summary>Raises the DocumentLoaded event.</summary>
		/// <param name="e">Specifies an EventArgs object that contains the event data.</param>
		protected virtual void OnDocumentLoaded(EventArgs eventArgs_0)
		{
			if (this.eventHandler_0 != null)
			{
				this.eventHandler_0(this, eventArgs_0);
			}
		}

		/// <summary>Raises the ContentsReset event.</summary>
		/// <param name="e">Specifies an EventArgs object that contains the event data.</param>
		protected virtual void OnContentsReset(EventArgs eventArgs_0)
		{
			if (this.eventHandler_1 != null)
			{
				this.eventHandler_1(this, eventArgs_0);
			}
		}

		/// <summary>Raises the ImageCreated event.</summary>
		/// <param name="e">Specifies an ImageEventArgs object that contains the event data.</param>
		protected virtual void OnImageCreated(ImageEventArgs imageEventArgs_0)
		{
			if (this.imageEventHandler_0 != null)
			{
				this.imageEventHandler_0(this, imageEventArgs_0);
			}
		}

		/// <summary>Raises the ImageDeleted event.</summary>
		/// <param name="e">Specifies an ImageEventArgs object that contains the event data.</param>
		protected virtual void OnImageDeleted(ImageEventArgs imageEventArgs_0)
		{
			if (this.imageEventHandler_1 != null)
			{
				this.imageEventHandler_1(this, imageEventArgs_0);
			}
		}

		/// <summary>Raises the TextFrameCreated event.</summary>
		/// <param name="e">Specifies an TextFrameEventArgs object that contains the event data.</param>
		protected virtual void OnTextFrameCreated(TextFrameEventArgs textFrameEventArgs_0)
		{
			if (this.textFrameEventHandler_0 != null)
			{
				this.textFrameEventHandler_0(this, textFrameEventArgs_0);
			}
		}

		/// <summary>Raises the TextFrameDeleted event.</summary>
		/// <param name="e">Specifies an TextFrameEventArgs object that contains the event data.</param>
		protected virtual void OnTextFrameDeleted(TextFrameEventArgs textFrameEventArgs_0)
		{
			if (this.textFrameEventHandler_1 != null)
			{
				this.textFrameEventHandler_1(this, textFrameEventArgs_0);
			}
		}

		protected virtual void OnChartCreated(ChartEventArgs chartEventArgs_0)
		{
			if (this.chartEventHandler_0 != null)
			{
				this.chartEventHandler_0(this, chartEventArgs_0);
			}
		}

		protected virtual void OnChartDeleted(ChartEventArgs chartEventArgs_0)
		{
			if (this.chartEventHandler_1 != null)
			{
				this.chartEventHandler_1(this, chartEventArgs_0);
			}
		}

		protected virtual void OnBarcodeCreated(BarcodeEventArgs barcodeEventArgs_0)
		{
			if (this.barcodeEventHandler_0 != null)
			{
				this.barcodeEventHandler_0(this, barcodeEventArgs_0);
			}
		}

		protected virtual void OnBarcodeDeleted(BarcodeEventArgs barcodeEventArgs_0)
		{
			if (this.barcodeEventHandler_1 != null)
			{
				this.barcodeEventHandler_1(this, barcodeEventArgs_0);
			}
		}

		protected virtual void OnDrawingCreated(DrawingEventArgs drawingEventArgs_0)
		{
			if (this.drawingEventHandler_0 != null)
			{
				this.drawingEventHandler_0(this, drawingEventArgs_0);
			}
		}

		protected virtual void OnDrawingDeleted(DrawingEventArgs drawingEventArgs_0)
		{
			if (this.drawingEventHandler_1 != null)
			{
				this.drawingEventHandler_1(this, drawingEventArgs_0);
			}
		}

		/// <summary>Raises the TableCreated event.</summary>
		/// <param name="e">Specifies an TableEventArgs object that contains the event data.</param>
		protected virtual void OnTableCreated(TableEventArgs tableEventArgs_0)
		{
			if (this.tableEventHandler_0 != null)
			{
				this.tableEventHandler_0(this, tableEventArgs_0);
			}
		}

		/// <summary>Raises the TableDeleted event.</summary>
		/// <param name="e">Specifies an TableEventArgs object that contains the event data.</param>
		protected virtual void OnTableDeleted(TableEventArgs tableEventArgs_0)
		{
			if (this.tableEventHandler_1 != null)
			{
				this.tableEventHandler_1(this, tableEventArgs_0);
			}
		}

		/// <summary>Raises the SubTextPartCreated event.</summary>
		/// <param name="e">Specifies an SubTextPartEventArgs object that contains the event data.</param>
		protected virtual void OnSubTextPartCreated(SubTextPartEventArgs subTextPartEventArgs_0)
		{
			if (this.subTextPartEventHandler_0 != null)
			{
				this.subTextPartEventHandler_0(this, subTextPartEventArgs_0);
			}
		}

		/// <summary>Raises the SubTextPartDeleted event.</summary>
		/// <param name="e">Specifies an SubTextPartEventArgs object that contains the event data.</param>
		protected virtual void OnSubTextPartDeleted(SubTextPartEventArgs subTextPartEventArgs_0)
		{
			if (this.subTextPartEventHandler_1 != null)
			{
				this.subTextPartEventHandler_1(this, subTextPartEventArgs_0);
			}
		}

		/// <summary>Raises the EditableRegionCreated event.</summary>
		/// <param name="e">Specifies an EditableRegionEventArgs object that contains the event data.</param>
		protected virtual void OnEditableRegionCreated(EditableRegionEventArgs editableRegionEventArgs_0)
		{
			if (this.editableRegionEventHandler_0 != null)
			{
				this.editableRegionEventHandler_0(this, editableRegionEventArgs_0);
			}
		}

		/// <summary>Raises the EditableRegionDeleted event.</summary>
		/// <param name="e">Specifies an EditableRegionEventArgs object that contains the event data.</param>
		protected virtual void OnEditableRegionDeleted(EditableRegionEventArgs editableRegionEventArgs_0)
		{
			if (this.editableRegionEventHandler_1 != null)
			{
				this.editableRegionEventHandler_1(this, editableRegionEventArgs_0);
			}
		}

		/// <summary>Raises the TrackedChangeCreated event.</summary>
		/// <param name="e">Specifies an TrackedChangeEventArgs object that contains the event data.</param>
		protected virtual void OnTrackedChangeCreated(TrackedChangeEventArgs trackedChangeEventArgs_0)
		{
			if (this.trackedChangeEventHandler_0 != null)
			{
				this.trackedChangeEventHandler_0(this, trackedChangeEventArgs_0);
			}
		}

		/// <summary>Raises the TrackedChangeDeleted event.</summary>
		/// <param name="e">Specifies an TrackedChangeEventArgs object that contains the event data.</param>
		protected virtual void OnTrackedChangeDeleted(TrackedChangeEventArgs trackedChangeEventArgs_0)
		{
			if (this.trackedChangeEventHandler_1 != null)
			{
				this.trackedChangeEventHandler_1(this, trackedChangeEventArgs_0);
			}
		}

		/// <summary>Raises the DocumentTargetCreated event.</summary>
		/// <param name="e">Specifies an DocumentTargetEventArgs object that contains the event data.</param>
		protected virtual void OnDocumentTargetCreated(DocumentTargetEventArgs documentTargetEventArgs_0)
		{
			if (this.documentTargetEventHandler_0 != null)
			{
				this.documentTargetEventHandler_0(this, documentTargetEventArgs_0);
			}
		}

		/// <summary>Raises the DocumentTargetDeleted event.</summary>
		/// <param name="e">Specifies an DocumentTargetEventArgs object that contains the event data.</param>
		protected virtual void OnDocumentTargetDeleted(DocumentTargetEventArgs documentTargetEventArgs_0)
		{
			if (this.documentTargetEventHandler_1 != null)
			{
				this.documentTargetEventHandler_1(this, documentTargetEventArgs_0);
			}
		}

		/// <summary>Raises the TableOfContentsCreated event.</summary>
		/// <param name="e">Specifies an TableOfContentsEventArgs object that contains the event data.</param>
		protected virtual void OnTableOfContentsCreated(TableOfContentsEventArgs tableOfContentsEventArgs_0)
		{
			if (this.tableOfContentsEventHandler_0 != null)
			{
				this.tableOfContentsEventHandler_0(this, tableOfContentsEventArgs_0);
			}
		}

		/// <summary>Raises the TableOfContentsDeleted event.</summary>
		/// <param name="e">Specifies an TableOfContentsEventArgs object that contains the event data.</param>
		protected virtual void OnTableOfContentsDeleted(TableOfContentsEventArgs tableOfContentsEventArgs_0)
		{
			if (this.tableOfContentsEventHandler_1 != null)
			{
				this.tableOfContentsEventHandler_1(this, tableOfContentsEventArgs_0);
			}
		}

		/// <summary>Raises the TextFieldCreated event.</summary>
		/// <param name="e">Specifies a TextFieldEventArgs object that contains the event data.</param>
		protected virtual void OnTextFieldCreated(TextFieldEventArgs textFieldEventArgs_0)
		{
			if (this.textFieldEventHandler_0 != null)
			{
				this.textFieldEventHandler_0(this, textFieldEventArgs_0);
			}
		}

		/// <summary>Raises the TextFieldDeleted event.</summary>
		/// <param name="e">Specifies a TextFieldEventArgs object that contains the event data.</param>
		protected virtual void OnTextFieldDeleted(TextFieldEventArgs textFieldEventArgs_0)
		{
			if (this.textFieldEventHandler_1 != null)
			{
				this.textFieldEventHandler_1(this, textFieldEventArgs_0);
			}
		}

		/// <summary>Raises the XmlNotWellFormed event.</summary>
		/// <param name="e">Specifies an XmlErrorEventArgs object that contains the event data.</param>
		protected virtual void OnXmlNotWellFormed(XmlErrorEventArgs xmlErrorEventArgs_0)
		{
			if (this.xmlErrorEventHandler_0 != null)
			{
				this.xmlErrorEventHandler_0(this, xmlErrorEventArgs_0);
			}
		}

		/// <summary>Raises the XmlInvalid event.</summary>
		/// <param name="e">Specifies an XmlErrorEventArgs object that contains the event data.</param>
		protected virtual void OnXmlInvalid(XmlErrorEventArgs xmlErrorEventArgs_0)
		{
			if (this.xmlErrorEventHandler_1 != null)
			{
				this.xmlErrorEventHandler_1(this, xmlErrorEventArgs_0);
			}
		}

		/// <summary>Raises the SpellCheckText event.</summary>
		/// <param name="e">Specifies an SpellCheckTextEventArgs object that contains the event data.</param>
		protected virtual void OnSpellCheckText(SpellCheckTextEventArgs spellCheckTextEventArgs_0)
		{
			if (this.spellCheckTextEventHandler_0 != null)
			{
				this.spellCheckTextEventHandler_0(this, spellCheckTextEventArgs_0);
			}
		}

		/// <summary>Raises the HyphenateWord event.</summary>
		/// <param name="e">Specifies an HyphenateWordEventArgs object that contains the event data.</param>
		protected virtual void OnHyphenateWord(HyphenateWordEventArgs hyphenateWordEventArgs_0)
		{
			if (this.hyphenateWordEventHandler_0 != null)
			{
				this.hyphenateWordEventHandler_0(this, hyphenateWordEventArgs_0);
			}
		}

		/// <summary>Raises the AdaptFont event.</summary>
		/// <param name="e">Specifies an AdaptFontEventArgs object that contains the event data.</param>
		protected virtual void OnAdaptFont(AdaptFontEventArgs adaptFontEventArgs_0)
		{
			if (this.adaptFontEventHandler_0 != null)
			{
				this.adaptFontEventHandler_0(this, adaptFontEventArgs_0);
			}
		}

		private bool method_2(IntPtr intptr_1, IntPtr intptr_2, IntPtr intptr_3)
		{
			string strFontName = Marshal.PtrToStringUni(intptr_1);
			string text = Marshal.PtrToStringUni(intptr_2);
			string[] array = KernelHelper.Ptr2StringArray(Class429.GlobalLock(intptr_3));
			Class429.GlobalUnlock(intptr_3);
			AdaptFontEventArgs adaptFontEventArgs = new AdaptFontEventArgs(strFontName, text, array);
			this.OnAdaptFont(adaptFontEventArgs);
			if (adaptFontEventArgs.AdaptedFontName != text)
			{
				string[] array2 = array;
				foreach (string text2 in array2)
				{
					if (text2 == adaptFontEventArgs.AdaptedFontName && adaptFontEventArgs.AdaptedFontName.Length < 32)
					{
						Marshal.Copy(adaptFontEventArgs.AdaptedFontName.ToCharArray(), 0, intptr_2, adaptFontEventArgs.AdaptedFontName.Length);
						Marshal.WriteInt16(intptr_2, adaptFontEventArgs.AdaptedFontName.Length * 2, 0);
						break;
					}
				}
			}
			return this.fontSettings_0.AdaptFontEvent;
		}

		private IntPtr method_3(IntPtr intptr_1, ushort ushort_0)
		{
			IntPtr intPtr = IntPtr.Zero;
			try
			{
				string strText = Marshal.PtrToStringUni(intptr_1);
				CultureInfo cultureInfo = null;
				try
				{
					cultureInfo = ((ushort_0 == 0) ? new CultureInfo("") : new CultureInfo(ushort_0));
				}
				catch
				{
				}
				if (this.class415_0 == null)
				{
					SpellCheckTextEventArgs spellCheckTextEventArgs = new SpellCheckTextEventArgs(strText, cultureInfo);
					this.OnSpellCheckText(spellCheckTextEventArgs);
					if (spellCheckTextEventArgs.MisspelledWords != null)
					{
						if (spellCheckTextEventArgs.MisspelledWords.Length != 0)
						{
							intPtr = Marshal.AllocHGlobal((4 * spellCheckTextEventArgs.MisspelledWords.Length + 1) * 4);
							Marshal.WriteInt32(intPtr, spellCheckTextEventArgs.MisspelledWords.Length);
							for (int i = 0; i < spellCheckTextEventArgs.MisspelledWords.Length; i++)
							{
								Marshal.WriteInt32(intPtr, (4 * i + 1) * 4, spellCheckTextEventArgs.MisspelledWords[i].Start);
								Marshal.WriteInt32(intPtr, (4 * i + 2) * 4, spellCheckTextEventArgs.MisspelledWords[i].Start + spellCheckTextEventArgs.MisspelledWords[i].Length - 1);
								Marshal.WriteInt16(intPtr, (4 * i + 3) * 4, (short)((spellCheckTextEventArgs.MisspelledWords[i].IsDuplicate ? 2 : 0) | (spellCheckTextEventArgs.MisspelledWords[i].IsIgnored ? 1 : 0)));
							}
							return intPtr;
						}
						return intPtr;
					}
					return intPtr;
				}
				this.class415_0.method_3(strText, cultureInfo);
				CollectionBase collectionBase_ = this.class415_0.CollectionBase_1;
				int count = collectionBase_.Count;
				if (count != 0)
				{
					intPtr = Marshal.AllocHGlobal((4 * count + 1) * 4);
					Marshal.WriteInt32(intPtr, count);
					int num = 0;
					{
						foreach (object item in collectionBase_)
						{
							int num2 = this.class415_0.method_24(item) + 1;
							int num3 = this.class415_0.method_25(item);
							short val = (short)(this.class415_0.method_26(item) ? 2 : 0);
							Marshal.WriteInt32(intPtr, (4 * num + 1) * 4, num2);
							Marshal.WriteInt32(intPtr, (4 * num + 2) * 4, num2 + num3 - 1);
							Marshal.WriteInt16(intPtr, (4 * num + 3) * 4, val);
							num++;
						}
						return intPtr;
					}
				}
				return intPtr;
			}
			catch
			{
				if (intPtr != IntPtr.Zero)
				{
					Marshal.FreeHGlobal(intPtr);
					return IntPtr.Zero;
				}
				return intPtr;
			}
		}

		private IntPtr method_4(IntPtr intptr_1, IntPtr intptr_2)
		{
			IntPtr intPtr = IntPtr.Zero;
			try
			{
				string text = Marshal.PtrToStringUni(intptr_1);
				if (this.class415_0 != null)
				{
					this.class415_0.method_12(text);
					CollectionBase collectionBase_ = this.class415_0.CollectionBase_2;
					int count = collectionBase_.Count;
					if (count != 0)
					{
						intPtr = Marshal.AllocHGlobal((4 * count + 1) * 4);
						Marshal.WriteInt32(intPtr, count);
						int num = 0;
						{
							foreach (object item in collectionBase_)
							{
								int num2 = this.class415_0.method_27(item) + 1;
								int num3 = this.class415_0.method_28(item);
								CultureInfo cultureInfo = this.class415_0.method_29(item);
								ushort num4 = (ushort)((cultureInfo != null) ? Class429.smethod_5(cultureInfo.LCID) : 0);
								Marshal.WriteInt32(intPtr, (4 * num + 1) * 4, num2);
								Marshal.WriteInt32(intPtr, (4 * num + 2) * 4, num2 + num3 - 1);
								Marshal.WriteInt16(intPtr, (4 * num + 3) * 4, (short)num4);
								num++;
							}
							return intPtr;
						}
					}
					return intPtr;
				}
				return intPtr;
			}
			catch
			{
				if (intPtr != IntPtr.Zero)
				{
					Marshal.FreeHGlobal(intPtr);
					return IntPtr.Zero;
				}
				return intPtr;
			}
		}

		private ushort method_5(IntPtr intptr_1, ushort ushort_0, ushort ushort_1, IntPtr intptr_2, bool bool_7, ushort ushort_2)
		{
			ushort num = 0;
			try
			{
				string strWord = Marshal.PtrToStringUni(intptr_1);
				CultureInfo cultureInfo = null;
				try
				{
					cultureInfo = ((ushort_2 == 0) ? new CultureInfo("") : new CultureInfo(ushort_2));
				}
				catch
				{
				}
				if (this.class415_0 != null)
				{
					num = (ushort)this.class415_0.method_15(strWord, ushort_0, cultureInfo);
				}
				HyphenateWordEventArgs hyphenateWordEventArgs = new HyphenateWordEventArgs(strWord, ushort_0, num, cultureInfo);
				this.OnHyphenateWord(hyphenateWordEventArgs);
				if (hyphenateWordEventArgs.DividePos <= ushort_0)
				{
					num = (ushort)hyphenateWordEventArgs.DividePos;
					return num;
				}
				return num;
			}
			catch
			{
				return num;
			}
		}

		private bool method_6(IntPtr intptr_1)
		{
			Struct62 struct62_ = (Struct62)Marshal.PtrToStructure(intptr_1, typeof(Struct62));
			this.vmethod_3(struct62_);
			return this.vmethod_2(struct62_);
		}

		internal virtual bool vmethod_2(Struct62 struct62_0)
		{
			bool result = true;
			switch (struct62_0.struct84_0.uint_0)
			{
			case 1811u:
				this.OnTextFieldCreated(new TextFieldEventArgs(this.textControlCore_0, (TextPart)struct62_0.uint_1, (int)struct62_0.uint_0, bCreateObject: false));
				break;
			case 1813u:
				this.OnTextFieldDeleted(new TextFieldEventArgs(this.textControlCore_0, (TextPart)struct62_0.uint_1, (int)struct62_0.uint_0, bCreateObject: true));
				break;
			case 1798u:
				this.textControlCore_0.Boolean_1 = true;
				break;
			case 1844u:
			case 1845u:
			{
				XmlErrorEventArgs xmlErrorEventArgs = null;
				Struct73 struct73_ = default(Struct73);
				struct73_.method_0();
				try
				{
					if (Class429.SendMessage_37(this.textControlCore_0.IntPtr_0, 1824, 0, ref struct73_) != 0)
					{
						xmlErrorEventArgs = new XmlErrorEventArgs(struct73_);
					}
				}
				catch (Exception ex)
				{
					throw ex;
				}
				finally
				{
					struct73_.method_1();
				}
				if (xmlErrorEventArgs != null)
				{
					switch (struct62_0.struct84_0.uint_0)
					{
					case 1844u:
						this.OnXmlNotWellFormed(xmlErrorEventArgs);
						break;
					case 1845u:
						this.OnXmlInvalid(xmlErrorEventArgs);
						break;
					}
				}
				break;
			}
			case 1830u:
			case 1831u:
				switch (Class429.SendMessage_1(this.textControlCore_0.IntPtr_0, 1887, (int)struct62_0.uint_0, 0))
				{
				case 5:
					TextFrameEventArgs textFrameEventArgs_ = new TextFrameEventArgs(this.textControlCore_0, (TextPart)struct62_0.uint_1, (int)struct62_0.uint_0);
						switch (struct62_0.struct84_0.uint_0)
						{
						case 1830u:
							this.OnTextFrameDeleted(textFrameEventArgs_);
							break;
						case 1831u:
							this.OnTextFrameCreated(textFrameEventArgs_);
							break;
						}
					break;
				case 7:
					ChartEventArgs chartEventArgs_ = new ChartEventArgs(this.textControlCore_0, (TextPart)struct62_0.uint_1, (int)struct62_0.uint_0, this.textControlCore_0.control5_0[(int)struct62_0.uint_0].Component);
						switch (struct62_0.struct84_0.uint_0)
						{
						case 1830u:
							this.OnChartDeleted(chartEventArgs_);
							break;
						case 1831u:
							this.OnChartCreated(chartEventArgs_);
							break;
						}
					break;
				case 8:
					BarcodeEventArgs barcodeEventArgs_ = new BarcodeEventArgs(this.textControlCore_0, (TextPart)struct62_0.uint_1, (int)struct62_0.uint_0, this.textControlCore_0.control4_0[(int)struct62_0.uint_0].Component);
						switch (struct62_0.struct84_0.uint_0)
						{
						case 1830u:
							this.OnBarcodeDeleted(barcodeEventArgs_);
							break;
						case 1831u:
							this.OnBarcodeCreated(barcodeEventArgs_);
							break;
						}
					break;
				case 9:
					DrawingEventArgs drawingEventArgs_ = new DrawingEventArgs(this.textControlCore_0, (TextPart)struct62_0.uint_1, (int)struct62_0.uint_0, this.textControlCore_0.control6_0[(int)struct62_0.uint_0].Component);
						switch (struct62_0.struct84_0.uint_0)
						{
						case 1830u:
							this.OnDrawingDeleted(drawingEventArgs_);
							break;
						case 1831u:
							this.OnDrawingCreated(drawingEventArgs_);
							break;
						}
					break;
				case 0:
				{
					ImageEventArgs imageEventArgs_ = new ImageEventArgs(this.textControlCore_0, (TextPart)struct62_0.uint_1, (int)struct62_0.uint_0);
					switch (struct62_0.struct84_0.uint_0)
					{
					case 1830u:
						this.OnImageDeleted(imageEventArgs_);
						break;
					case 1831u:
						this.OnImageCreated(imageEventArgs_);
						break;
					}
					break;
				}
				}
				break;
			case 1834u:
				this.OnTableDeleted(new TableEventArgs(null, (TextPart)struct62_0.uint_1, (int)(((long)struct62_0.uint_0 > 32767L) ? struct62_0.uint_0 : 0), (int)(((long)struct62_0.uint_0 <= 32767L) ? struct62_0.uint_0 : 0)));
				break;
			case 1875u:
				this.OnSubTextPartCreated(new SubTextPartEventArgs(this.textControlCore_0, (TextPart)struct62_0.uint_1, (int)struct62_0.uint_0, bDeleted: false));
				break;
			case 1876u:
				this.OnSubTextPartDeleted(new SubTextPartEventArgs(this.textControlCore_0, (TextPart)struct62_0.uint_1, (int)struct62_0.uint_0, bDeleted: true));
				break;
			case 1849u:
				this.OnTableCreated(new TableEventArgs(this.textControlCore_0, (TextPart)struct62_0.uint_1, (int)struct62_0.uint_0, 0));
				break;
			case 1905u:
				this.OnDocumentTargetCreated(new DocumentTargetEventArgs(this.textControlCore_0, (TextPart)struct62_0.uint_1, (int)struct62_0.uint_0, bDeleted: false));
				break;
			case 1906u:
				this.OnDocumentTargetDeleted(new DocumentTargetEventArgs(this.textControlCore_0, (TextPart)struct62_0.uint_1, (int)struct62_0.uint_0, bDeleted: true));
				break;
			case 1907u:
				this.OnTableOfContentsCreated(new TableOfContentsEventArgs(this.textControlCore_0, (TextPart)struct62_0.uint_1, (int)struct62_0.uint_0, bDeleted: false));
				break;
			case 1908u:
				this.OnTableOfContentsDeleted(new TableOfContentsEventArgs(this.textControlCore_0, (TextPart)struct62_0.uint_1, (int)struct62_0.uint_0, bDeleted: true));
				break;
			case 1889u:
				this.OnEditableRegionCreated(new EditableRegionEventArgs(this.textControlCore_0, (TextPart)struct62_0.uint_1, (int)struct62_0.uint_0, bDeleted: false));
				break;
			case 1890u:
				this.OnEditableRegionDeleted(new EditableRegionEventArgs(this.textControlCore_0, (TextPart)struct62_0.uint_1, (int)struct62_0.uint_0, bDeleted: true));
				break;
			case 1891u:
				this.OnContentsReset(EventArgs.Empty);
				break;
			default:
				result = false;
				break;
			case 1893u:
				this.OnTrackedChangeCreated(new TrackedChangeEventArgs(this.textControlCore_0, (TextPart)struct62_0.uint_1, (int)struct62_0.uint_0, bDeleted: false));
				break;
			case 1894u:
				this.OnTrackedChangeDeleted(new TrackedChangeEventArgs(this.textControlCore_0, (TextPart)struct62_0.uint_1, (int)struct62_0.uint_0, bDeleted: true));
				break;
			case 1883u:
				this.OnDocumentLoaded(EventArgs.Empty);
				break;
			}
			return result;
		}

		internal virtual void vmethod_3(Struct62 struct62_0)
		{
		}

		/// <summary>Clears the selected text or the character right from the current input position.</summary>
		public void Clear()
		{
			if (this.textControlCore_0.isHandleCreated)
			{
				this.textControlCore_0.method_29(TextPart.Auto, 771, 0, 0);
			}
		}

		/// <summary>Deletes the entire contents of the control.</summary>
		public void ResetContents()
		{
			if (!this.textControlCore_0.isHandleCreated)
			{
				return;
			}
			try
			{
				this.documentSettings_0.method_2();
				this.textControlCore_0.method_23(bool_1: true);
				this.textControlCore_0.method_30(Enum83.const_69, 0, 0);
				this.vmethod_0();
			}
			catch (Exception ex)
			{
				throw ex;
			}
			finally
			{
				this.textControlCore_0.method_23(bool_1: false);
			}
		}

		/// <summary>Selects all text in the control.</summary>
		public void SelectAll()
		{
			if (this.textControlCore_0.isHandleCreated)
			{
				this.textControlCore_0.method_29(TextPart.Auto, 1158, 0, Class429.smethod_3(0, -1));
			}
		}

		/// <summary>Selects text within the control.</summary>
		/// <param name="start">Specifies the selection's start position.</param>
		/// <param name="length">Specifies the number of selected characters.</param>
		public void Select(int start, int length)
		{
			if (this.textControlCore_0.isHandleCreated)
			{
				int[] int_ = new int[2]
				{
					start + length,
					start
				};
				this.textControlCore_0.method_40(TextPart.Auto, 1158, 1, int_);
			}
		}

		/// <summary>Selects the word at the current text input position.</summary>
		public void SelectWord()
		{
			if (this.textControlCore_0.isHandleCreated)
			{
				this.textControlCore_0.method_8();
			}
		}

		/// <summary>Finds the specified text string in the main text of the document. The search starts at the beginning of the document.</summary>
		/// <param name="text">Specifies the text to search for.</param>
		public int Find(string text)
		{
			Struct59 struct59_ = new Struct59(text, -1, 16u);
			return this.textControlCore_0.method_53(TextPart.Auto, Enum83.const_175, 0, ref struct59_);
		}

		/// <summary>Finds the specified text string in the main text of the document using the specified find options. The search starts at the specified position.</summary>
		/// <param name="text">Specifies the text to search for.</param>
		/// <param name="start">Specifies the text position where the search starts, beginning with 0.</param>
		/// <param name="options">Specifies search options.</param>
		public int Find(string text, int start, FindOptions options)
		{
			Struct59 struct59_ = new Struct59(text, start, (uint)(options | FindOptions.NoMessageBox));
			return this.textControlCore_0.method_53(TextPart.Auto, Enum83.const_175, 0, ref struct59_);
		}

		/// <summary>Loads text formatted with the specified format. The new text is read from the specified file.</summary>
		/// <param name="path">Specifies a file from which the data is loaded.</param>
		/// <param name="streamType">Specifies one of the StreamType values.</param>
		public void Load(string path, StreamType streamType)
		{
			this.Load(path, streamType, new LoadSettings());
		}

		/// <summary>Loads text formatted with the specified format. The new text is read from the specified file stream.</summary>
		/// <param name="fileStream">Specifies a file from which the data is loaded.</param>
		/// <param name="streamType">Specifies one of the StreamType values.</param>
		public void Load(FileStream fileStream, StreamType streamType)
		{
			this.Load(fileStream, streamType, new LoadSettings());
		}

		/// <summary>Loads text formatted with the specified format. The new text is read from the specified byte array.</summary>
		/// <param name="binaryData">Specifies a byte array from which the data is loaded.</param>
		/// <param name="binaryStreamType">Specifies one of the BinaryStreamType values.</param>
		public void Load(byte[] binaryData, BinaryStreamType binaryStreamType)
		{
			this.Load(binaryData, binaryStreamType, new LoadSettings());
		}

		/// <summary>Loads text formatted with the specified format. The new text is read from the specified string.</summary>
		/// <param name="stringData">Specifies a string from which the data is loaded.</param>
		/// <param name="stringStreamType">Specifies one of the StringStreamType values.</param>
		public void Load(string stringData, StringStreamType stringStreamType)
		{
			this.Load(stringData, stringStreamType, new LoadSettings());
		}

		/// <summary>Loads text formatted with the specified format. The new text is read from the specified file and loaded using the given special settings.</summary>
		/// <param name="path">Specifies a file from which the data is loaded.</param>
		/// <param name="streamType">Specifies one of the StreamType values.</param>
		/// <param name="loadSettings">Specifies a LoadSettings object with additional information and settings for the load operation.</param>
		public void Load(string path, StreamType streamType, LoadSettings loadSettings)
		{
			loadSettings.method_1(path, streamType, this.textControlCore_0, Enum104.const_0, this.documentSettings_0);
		}

		/// <summary>Loads text formatted with the specified format. The new text is read from the specified file stream and loaded using the given special settings.</summary>
		/// <param name="fileStream">Specifies a file from which the data is loaded.</param>
		/// <param name="streamType">Specifies one of the StreamType values.</param>
		/// <param name="loadSettings">Specifies a LoadSettings object with additional information and settings for the load operation.</param>
		public void Load(FileStream fileStream, StreamType streamType, LoadSettings loadSettings)
		{
			loadSettings.method_2(fileStream, streamType, this.textControlCore_0, Enum104.const_0, this.documentSettings_0);
		}

		/// <summary>Loads text formatted with the specified format. The new text is read from the specified byte array and loaded using the given special settings.</summary>
		/// <param name="binaryData">Specifies a byte array from which the data is loaded.</param>
		/// <param name="binaryStreamType">Specifies one of the BinaryStreamType values.</param>
		/// <param name="loadSettings">Specifies a LoadSettings object with additional information and settings for the load operation.</param>
		public void Load(byte[] binaryData, BinaryStreamType binaryStreamType, LoadSettings loadSettings)
		{
			loadSettings.method_3(binaryData, binaryStreamType, this.textControlCore_0, Enum104.const_0, this.documentSettings_0);
		}

		/// <summary>Loads text formatted with the specified format. The new text is read from the specified string and loaded using the given special settings.</summary>
		/// <param name="stringData">Specifies a string from which the data is loaded.</param>
		/// <param name="stringStreamType">Specifies one of the StringStreamType values.</param>
		/// <param name="loadSettings">Specifies a LoadSettings object with additional information and settings for the load operation.</param>
		public void Load(string stringData, StringStreamType stringStreamType, LoadSettings loadSettings)
		{
			loadSettings.method_5(stringData, stringStreamType, this.textControlCore_0, Enum104.const_0, this.documentSettings_0);
		}

		public void Load(string path, StreamType streamType, ref LoadSettings loadSettings, out byte[] internalFormat)
		{
			this.Load(Path.IsPathRooted(path) ? path : Path.Combine(AppDomain.CurrentDomain.BaseDirectory, path), streamType, loadSettings);
			SaveSettings saveSettings = new SaveSettings();
			saveSettings.Boolean_0 = true;
			this.Save(out internalFormat, BinaryStreamType.InternalUnicodeFormat, saveSettings);
		}

		/// <summary>Loads text with the specified format from the specified file and appends it to the existing document.</summary>
		/// <param name="path">Specifies a file from which the data is loaded.</param>
		/// <param name="streamType">Specifies one of the StreamType values.</param>
		/// <param name="appendSettings">Specifies settings how the document is appended.</param>
		public void Append(string path, StreamType streamType, AppendSettings appendSettings)
		{
			this.Append(path, streamType, new LoadSettings(), appendSettings);
		}

		/// <summary>Loads text with the specified format from the specified file stream and appends it to the existing document.</summary>
		/// <param name="fileStream">Specifies a file from which the data is loaded.</param>
		/// <param name="streamType">Specifies one of the StreamType values.</param>
		/// <param name="appendSettings">Specifies settings how the document is appended.</param>
		public void Append(FileStream fileStream, StreamType streamType, AppendSettings appendSettings)
		{
			this.Append(fileStream, streamType, new LoadSettings(), appendSettings);
		}

		/// <summary>Loads text with the specified format from the specified byte array and appends it to the existing document.</summary>
		/// <param name="binaryData">Specifies a byte array from which the data is loaded.</param>
		/// <param name="binaryStreamType">Specifies one of the BinaryStreamType values.</param>
		/// <param name="appendSettings">Specifies settings how the document is appended.</param>
		public void Append(byte[] binaryData, BinaryStreamType binaryStreamType, AppendSettings appendSettings)
		{
			this.Append(binaryData, binaryStreamType, new LoadSettings(), appendSettings);
		}

		/// <summary>Loads text with the specified format from the specified string and appends it to the existing document.</summary>
		/// <param name="stringData">Specifies a string from which the data is loaded.</param>
		/// <param name="stringStreamType">Specifies one of the StringStreamType values.</param>
		/// <param name="appendSettings">Specifies settings how the document is appended.</param>
		public void Append(string stringData, StringStreamType stringStreamType, AppendSettings appendSettings)
		{
			this.Append(stringData, stringStreamType, new LoadSettings(), appendSettings);
		}

		/// <summary>Loads text with the specified format and special settings from the specified file and appends it to the existing document.</summary>
		/// <param name="path">Specifies a file from which the data is loaded.</param>
		/// <param name="streamType">Specifies one of the StreamType values.</param>
		/// <param name="loadSettings">Specifies a LoadSettings object with additional information and settings for the load operation.</param>
		/// <param name="appendSettings">Specifies settings how the document is appended.</param>
		public void Append(string path, StreamType streamType, LoadSettings loadSettings, AppendSettings appendSettings)
		{
			loadSettings.method_1(path, streamType, this.textControlCore_0, (Enum104)(appendSettings | (AppendSettings)2 | (AppendSettings)1), null);
		}

		/// <summary>Loads text with the specified format and special settings from the specified file stream and appends it to the existing document.</summary>
		/// <param name="fileStream">Specifies a file from which the data is loaded.</param>
		/// <param name="streamType">Specifies one of the StreamType values.</param>
		/// <param name="loadSettings">Specifies a LoadSettings object with additional information and settings for the load operation.</param>
		/// <param name="appendSettings">Specifies settings how the document is appended.</param>
		public void Append(FileStream fileStream, StreamType streamType, LoadSettings loadSettings, AppendSettings appendSettings)
		{
			loadSettings.method_2(fileStream, streamType, this.textControlCore_0, (Enum104)(appendSettings | (AppendSettings)2 | (AppendSettings)1), null);
		}

		public void Append(byte[] binaryData, BinaryStreamType binaryStreamType, LoadSettings loadSettings, AppendSettings appendSettings)
		{
			loadSettings.method_3(binaryData, binaryStreamType, this.textControlCore_0, (Enum104)(appendSettings | (AppendSettings)2 | (AppendSettings)1), null);
		}

		/// <summary>Loads text with the specified format and special settings from the specified string and appends it to the existing document.</summary>
		/// <param name="stringData">Specifies a string from which the data is loaded.</param>
		/// <param name="stringStreamType">Specifies one of the StringStreamType values.</param>
		/// <param name="loadSettings">Specifies a LoadSettings object with additional information and settings for the load operation.</param>
		/// <param name="appendSettings">Specifies settings how the document is appended.</param>
		public void Append(string stringData, StringStreamType stringStreamType, LoadSettings loadSettings, AppendSettings appendSettings)
		{
			loadSettings.method_5(stringData, stringStreamType, this.textControlCore_0, (Enum104)(appendSettings | (AppendSettings)2 | (AppendSettings)1), null);
		}

		/// <summary>Prints the document using the printer settings of the specified PrintDocument.</summary>
		/// <param name="printDocument">Specifies an instance of the PrintDocument class.</param>
		public void Print(PrintDocument printDocument)
		{
			Class432 @class = new Class432(this.textControlCore_0);
			@class.method_1(printDocument);
		}

		/// <summary>Prints a single page. This method can be called from the PrintPage event handler.</summary>
		/// <param name="page">Specifies a page number to print.</param>
		/// <param name="ppe">Specifies the event arguments of the print document's PrintPage event.</param>
		public void Print(int page, PrintPageEventArgs ppe)
		{
			Class432 @class = new Class432(this.textControlCore_0);
			@class.method_6(page, ppe);
		}

		/// <summary>Saves the complete contents of a document in the specified file with the specified format.</summary>
		/// <param name="path">Specifies a file into which the data is saved.</param>
		/// <param name="streamType">Specifies one of the StreamType values.</param>
		public void Save(string path, StreamType streamType)
		{
			this.Save(path, streamType, new SaveSettings());
		}

		/// <summary>Saves the complete contents of a document in the specified file stream with the specified format.</summary>
		/// <param name="fileStream">Specifies a file into which the data is saved.</param>
		/// <param name="streamType">Specifies one of the StreamType values.</param>
		public void Save(FileStream fileStream, StreamType streamType)
		{
			this.Save(fileStream, streamType, new SaveSettings());
		}

		/// <summary>Saves the complete contents of a document in the specified byte array with the specified format.</summary>
		/// <param name="binaryData">Specifies a byte array into which the data is saved.</param>
		/// <param name="binaryStreamType">Specifies one of the BinaryStreamType values.</param>
		public void Save(out byte[] binaryData, BinaryStreamType binaryStreamType)
		{
			this.Save(out binaryData, binaryStreamType, new SaveSettings());
		}

		/// <summary>Saves the complete contents of a document as a string with the specified format.</summary>
		/// <param name="stringData">Specifies a string into which the data is saved.</param>
		/// <param name="stringStreamType">Specifies one of the StringStreamType values.</param>
		public void Save(out string stringData, StringStreamType stringStreamType)
		{
			this.Save(out stringData, stringStreamType, new SaveSettings());
		}

		/// <summary>Saves the complete contents of a document in the specified file using the specified format and special settings.</summary>
		/// <param name="path">Specifies a file into which the data is saved.</param>
		/// <param name="streamType">Specifies one of the StreamType values.</param>
		/// <param name="saveSettings">Specifies a SaveSettings object with additional information and settings for the save operation.</param>
		public void Save(string path, StreamType streamType, SaveSettings saveSettings)
		{
			this.documentSettings_0.method_1(saveSettings);
			saveSettings.method_1(path, streamType, this.textControlCore_0, Enum104.const_0);
		}

		/// <summary>Saves the complete contents of a document in the specified file stream using the specified format and special settings.</summary>
		/// <param name="fileStream">Specifies a file into which the data is saved.</param>
		/// <param name="streamType">Specifies one of the StreamType values.</param>
		/// <param name="saveSettings">Specifies a SaveSettings object with additional information and settings for the save operation.</param>
		public void Save(FileStream fileStream, StreamType streamType, SaveSettings saveSettings)
		{
			this.documentSettings_0.method_1(saveSettings);
			saveSettings.method_2(fileStream, streamType, this.textControlCore_0, Enum104.const_0);
		}

		/// <summary>Saves the complete contents of a document in the specified byte array using the specified format and special settings.</summary>
		/// <param name="binaryData">Specifies a byte array into which the data is saved.</param>
		/// <param name="binaryStreamType">Specifies one of the BinaryStreamType values.</param>
		/// <param name="saveSettings">Specifies a SaveSettings object with additional information and settings for the save operation.</param>
		public void Save(out byte[] binaryData, BinaryStreamType binaryStreamType, SaveSettings saveSettings)
		{
			this.documentSettings_0.method_1(saveSettings);
			saveSettings.method_3(out binaryData, binaryStreamType, this.textControlCore_0, Enum104.const_0);
		}

		/// <summary>Saves the complete contents of a document as a string using the specified format and special settings.</summary>
		/// <param name="stringData">Specifies a string into which the data is saved.</param>
		/// <param name="stringStreamType">Specifies one of the StringStreamType values.</param>
		/// <param name="saveSettings">Specifies a SaveSettings object with additional information and settings for the save operation.</param>
		public void Save(out string stringData, StringStreamType stringStreamType, SaveSettings saveSettings)
		{
			this.documentSettings_0.method_1(saveSettings);
			saveSettings.method_4(out stringData, stringStreamType, this.textControlCore_0, Enum104.const_0);
		}

		public void Save(byte[] internalFormat, string path, StreamType streamType, ref SaveSettings saveSettings)
		{
			this.Load(internalFormat, BinaryStreamType.InternalUnicodeFormat);
			this.Save(Path.IsPathRooted(path) ? path : Path.Combine(AppDomain.CurrentDomain.BaseDirectory, path), streamType, saveSettings);
		}

		public PageCollection GetPages()
		{
			//
			if (this.textControlCore_0.isHandleCreated)
			{
				return new PageCollection(this.textControlCore_0);
			}
			return null;
		}

		/// <summary>Gets an array of strings specifying the names of all currently supported fonts. These fonts depend on the formatting device set with the ServerTextControl.FormattingPrinter property. The method returns null if the ServerTextControl has not been completely initialized.</summary>
		public string[] GetSupportedFonts()
		{
			return this.textControlCore_0.GetSupportedFonts();
		}

		/// <summary>Gets an array of PaperSize structures specifying the names and the size of all currently supported paper sizes. These paper sizes depend on the formatting device set with the ServerTextControl.FormattingPrinter property. The method returns null, if the ServerTextControl has not been completely initialized.</summary>
		public PaperSize[] GetSupportedPaperSizes()
		{
			return this.textControlCore_0.GetSupportedPaperSizes();
		}

		/// <summary>Returns a collection containing text fields of the specified types.</summary>
		/// <param name="fieldType">Specifies types of text fields.</param>
		public TextFieldCollection GetTextFields(TextFieldType fieldType)
		{
			if (!this.textControlCore_0.isHandleCreated)
			{
				return null;
			}
			return new TextFieldCollection(this.textControlCore_0, TextPart.Auto, (Enum106)fieldType);
		}

		/// <summary>Returns a collection of XML elements. It is an object of the type XmlElementCollection.</summary>
		/// <param name="elementName">Specifies the XML element's name.</param>
		public XmlElementCollection GetXmlElements(string elementName)
		{
			
			if (elementName == null)
			{
				throw new ArgumentNullException("elementName");
			}
			return new XmlElementCollection(this.textControlCore_0, elementName);
		}

		/// <summary>Returns an object of the type VersionInfo, which provides information about the installed TX Text Control version.</summary>
		public VersionInfo GetVersionInfo()
		{
			if (this.textControlCore_0.isHandleCreated && this.class408_0 != null)
			{
				return new VersionInfo(this.class408_0,Enum115.Enterprise);
			}
			return null;
		}

		public bool ShouldSerializeBackColor()
		{
			return this.color_0 != SystemColors.Window;
		}

		/// <summary>Resets the BackColor property to its default value. The default value is the system color for the window background.</summary>
		public void ResetBackColor()
		{
			this.BackColor = SystemColors.Window;
		}

		public bool ShouldSerializeFont()
		{
			return !this.font_0.Equals(new Font("Arial", 10f));
		}

		/// <summary>Resets the Font property to its default value. The default value is 10 pt Arial.</summary>
		public void ResetFont()
		{
			this.Font = new Font("Arial", 10f);
		}

		public bool ShouldSerializeFontSettings()
		{
			return !this.fontSettings_0.method_2();
		}

		public void ResetFontSettings()
		{
			this.fontSettings_0.method_1();
		}

		public bool ShouldSerializeForeColor()
		{
			return this.color_1 != SystemColors.WindowText;
		}

		/// <summary>Resets the ForeColor property to its default value. The default value is the system color for the window text.</summary>
		public void ResetForeColor()
		{
			this.ForeColor = SystemColors.WindowText;
		}

		public bool ShouldSerializeInputPosition()
		{
			return false;
		}

		public bool ShouldSerializeListFormat()
		{
			return !this.listFormat_0.method_0();
		}

		public void ResetListFormat()
		{
			this.listFormat_0.method_7();
		}

		public bool ShouldSerializePageMargins()
		{
			return !this.pageMargins_0.method_5();
		}

		/// <summary>Resets the PageMargins property to its default value. The default page margins are 1 inch.</summary>
		public void ResetPageMargins()
		{
			this.pageMargins_0.method_4();
		}

		public bool ShouldSerializePageSize()
		{
			return !this.pageSize_0.method_5();
		}

		/// <summary>Resets the PageSize property to its default value. The default page size is US letter (8,5 x 11 inch).</summary>
		public void ResetPageSize()
		{
			this.pageSize_0.method_4();
		}

		public bool ShouldSerializeParagraphFormat()
		{
			return !this.paragraphFormat_0.method_0();
		}

		public void ResetParagraphFormat()
		{
			this.paragraphFormat_0.method_7();
		}

		public bool ShouldSerializeSelection()
		{
			return false;
		}

		public bool ShouldSerializeTextBackColor()
		{
			return this.color_2 != this.BackColor;
		}

		/// <summary>Resets the TextBackColor property to its default value. The default value is the setting of the BackColor property.</summary>
		public void ResetTextBackColor()
		{
			this.TextBackColor = this.BackColor;
		}
	}
}
