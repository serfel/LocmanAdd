using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Printing;
using System.Globalization;
using System.IO;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Threading;
using System.Windows.Forms;
using Interop.UIAutomationCore;
using ns20;
using ns21;
using ns23;
using ns26;
using ns27;
using ns29;
using TXTextControl.DataVisualization;
using TXTextControl.Windows.Forms.Ribbon;

namespace TXTextControl
{
	/// <summary>The TextControl class implements a Windows Forms control with high-level text editing features.</summary>
	[ToolboxBitmap(typeof(TextControl))]
	[Designer("TXTextControl.TextControlDesigner, TXTextControl.Design.dll, Version=29.0.113.500")]
	public class TextControl : Control, INotifyPropertyChanged, IFormattedText, ITextControl
	{
		public string ѕуть—охранени€ { get; set; }
		public int FileFilterIndex { get; set; }

		/// <summary>The TextControl.Colors class gets, sets or resets the display colors of a Windows Forms TextControl control.</summary>
		public sealed class Colors : ColorBase
		{
			/// <summary>Gets or sets the display color for the area around the pages.</summary>
			[Attribute3("PROP_DISPLAYCOLORS_DESKTOP")]
			[Category("Appearance")]
			public Color DesktopColor
			{
				get
				{
					return base.GetColor(0);
				}
				set
				{
					base.SetColor(value, 0);
				}
			}

			/// <summary>Gets or sets the display color for the shadow at the left and the top edge of the pages.</summary>
			[Attribute3("PROP_DISPLAYCOLORS_LIGHTSHADOW")]
			[Category("Appearance")]
			public Color LightShadowColor
			{
				get
				{
					return base.GetColor(1);
				}
				set
				{
					base.SetColor(value, 1);
				}
			}

			/// <summary>Gets or sets the display color for the shadow at the right and the bottom edge of the pages.</summary>
			[Category("Appearance")]
			[Attribute3("PROP_DISPLAYCOLORS_DARKSHADOW")]
			public Color DarkShadowColor
			{
				get
				{
					return base.GetColor(2);
				}
				set
				{
					base.SetColor(value, 2);
				}
			}

			/// <summary>Gets or sets the display color for the dividing line between headers and footers and the main text.</summary>
			[Category("Appearance")]
			[Attribute3("PROP_DISPLAYCOLORS_HEADERFOOTERLINE")]
			public Color HeaderFooterLineColor
			{
				get
				{
					return base.GetColor(3);
				}
				set
				{
					base.SetColor(value, 3);
				}
			}

			/// <summary>Gets or sets the display color for the label showing which header or footer is activated.</summary>
			[Category("Appearance")]
			[Attribute3("PROP_DISPLAYCOLORS_HEADERFOOTERLABEL")]
			public Color HeaderFooterLabelColor
			{
				get
				{
					return base.GetColor(4);
				}
				set
				{
					base.SetColor(value, 4);
				}
			}

			/// <summary>Gets or sets the highlight color of a form field containing the current text input position.</summary>
			[Category("Appearance")]
			[Attribute3("PROP_DISPLAYCOLORS_ACTIVEFORMFIELD")]
			public Color ActiveFormFieldColor
			{
				get
				{
					return base.GetColor(5);
				}
				set
				{
					base.SetColor(value, 5);
				}
			}

			/// <summary>Gets or sets the highlight color of a form field.</summary>
			[Category("Appearance")]
			[Attribute3("PROP_DISPLAYCOLORS_FORMFIELD")]
			public Color FormFieldColor
			{
				get
				{
					return base.GetColor(6);
				}
				set
				{
					base.SetColor(value, 6);
				}
			}

			/// <summary>Initializes a new instance of the TextControl.Colors class. After creating the object with this constuctor, individual colors can be set. If the Colors object is assigned to the TextControl.DisplayColors property, non-set colors are reset to their default values.</summary>
			public Colors()
				: base(7, 1934, 1935)
			{
			}

			public bool ShouldSerializeDesktopColor()
			{
				return base.m_aiColors[0] != Color.Empty;
			}

			/// <summary>Resets the text control's DesktopColor to its system dependent default value.</summary>
			public void ResetDesktopColor()
			{
				ref Color reference = ref base.m_aiColors[0];
				reference = Color.Empty;
				base.method_0();
			}

			public bool ShouldSerializeLightShadowColor()
			{
				return base.m_aiColors[1] != Color.Empty;
			}

			/// <summary>Resets the text control's LightShadowColor to its system dependent default value.</summary>
			public void ResetLightShadowColor()
			{
				ref Color reference = ref base.m_aiColors[1];
				reference = Color.Empty;
				base.method_0();
			}

			public bool ShouldSerializeDarkShadowColor()
			{
				return base.m_aiColors[2] != Color.Empty;
			}

			/// <summary>Resets the text control's DarkShadowColor to its system dependent default value.</summary>
			public void ResetDarkShadowColor()
			{
				ref Color reference = ref base.m_aiColors[2];
				reference = Color.Empty;
				base.method_0();
			}

			public bool ShouldSerializeHeaderFooterLineColor()
			{
				return base.m_aiColors[3] != Color.Empty;
			}

			/// <summary>Resets the text control's HeaderFooterLineColor to its system dependent default value.</summary>
			public void ResetHeaderFooterLineColor()
			{
				ref Color reference = ref base.m_aiColors[3];
				reference = Color.Empty;
				base.method_0();
			}

			public bool ShouldSerializeHeaderFooterLabelColor()
			{
				return base.m_aiColors[4] != Color.Empty;
			}

			/// <summary>Resets the text control's HeaderFooterLabelColor to its system dependent default value.</summary>
			public void ResetHeaderFooterLabelColor()
			{
				ref Color reference = ref base.m_aiColors[4];
				reference = Color.Empty;
				base.method_0();
			}

			public bool ShouldSerializeActiveFormFieldColor()
			{
				return base.m_aiColors[5] != Color.Empty;
			}

			/// <summary>Resets the text control's ActiveFormFieldColor to its default value.</summary>
			public void ResetActiveFormFieldColor()
			{
				ref Color reference = ref base.m_aiColors[5];
				reference = Color.Empty;
				base.method_0();
			}

			public bool ShouldSerializeFormFieldColor()
			{
				return base.m_aiColors[6] != Color.Empty;
			}

			/// <summary>Resets the text control's FormFieldColor to its default value.</summary>
			public void ResetFormFieldColor()
			{
				ref Color reference = ref base.m_aiColors[6];
				reference = Color.Empty;
				base.method_0();
			}
		}

		private class Class575 : TypeConverter
		{
			public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
			{
				return true;
			}

			public override bool GetStandardValuesExclusive(ITypeDescriptorContext context)
			{
				return true;
			}

			public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
			{
				if (sourceType == typeof(string))
				{
					return true;
				}
				return base.CanConvertFrom(context, sourceType);
			}

			public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
			{
				if (value is string)
				{
					return value;
				}
				return base.ConvertFrom(context, culture, value);
			}

			public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
			{
				List<string> list = new List<string>();
				list.Add("(none)");
				list.Add("(Default)");
				foreach (Component component in context.Container.Components)
				{
					if (component is ContextMenuStrip)
					{
						ContextMenuStrip contextMenuStrip = (ContextMenuStrip)component;
						list.Add(contextMenuStrip.Name);
					}
				}
				string[] values = list.ToArray();
				return new StandardValuesCollection(values);
			}
		}

		private ResourceManager resources;

		private Class408 class408;

		private Container components;

		private string string_0;

		private TextControlCore.Delegate9 delegate9_0;

		private TextControlCore.Delegate10 delegate10_0;

		private TextControlCore.Delegate11 delegate11_0;

		private TextControlCore.Delegate12 delegate12_0;

		private EventHandler eventHandler_0;

		private DocumentPermissions documentPermissions_0;

		internal TextControlCore textControlCore_0;

		internal int int_0;

		private Class603 class603_0;

		private EventHandler eventHandler_1;

		private EventHandler eventHandler_2;

		private EventHandler eventHandler_3;

		private EventHandler eventHandler_4;

		private EventHandler eventHandler_5;

		private EventHandler eventHandler_6;

		private EventHandler eventHandler_7;

		private EventHandler eventHandler_8;

		private EventHandler eventHandler_9;

		private EventHandler eventHandler_10;

		private EventHandler eventHandler_11;

		private EventHandler eventHandler_12;

		private EventHandler eventHandler_13;

		private EventHandler eventHandler_14;

		private EventHandler eventHandler_15;

		private EventHandler eventHandler_16;

		private EventHandler eventHandler_17;

		private EventHandler eventHandler_18;

		private EventHandler eventHandler_19;

		private EventHandler eventHandler_20;

		private EventHandler eventHandler_21;

		private EventHandler eventHandler_22;

		private EventHandler eventHandler_23;

		private EventHandler eventHandler_24;

		private EventHandler eventHandler_25;

		private EventHandler eventHandler_26;

		private Point? nullable_0 = null;

		private TextContextMenuEventHandler textContextMenuEventHandler_0;

		private MiniToolbarInitializedEventHandler miniToolbarInitializedEventHandler_0;

		private MiniToolbarInitializedEventHandler miniToolbarInitializedEventHandler_1;

		internal MiniToolbar miniToolbar_0;

		private MiniToolbarOpeningEventHandler miniToolbarOpeningEventHandler_0;

		private PropertyChangedEventHandler propertyChangedEventHandler_0;

		private TextFieldEventHandler textFieldEventHandler_0;

		private TextFieldEventHandler textFieldEventHandler_1;

		private TextFieldEventHandler textFieldEventHandler_2;

		private TextFieldEventHandler textFieldEventHandler_3;

		private TextFieldEventHandler textFieldEventHandler_4;

		private TextFieldEventHandler textFieldEventHandler_5;

		private TextFieldEventHandler textFieldEventHandler_6;

		private CheckFormFieldEventHandler checkFormFieldEventHandler_0;

		private DateFormFieldEventHandler dateFormFieldEventHandler_0;

		private SelectionFormFieldEventHandler selectionFormFieldEventHandler_0;

		private TextFormFieldEventHandler textFormFieldEventHandler_0;

		private HypertextLinkEventHandler hypertextLinkEventHandler_0;

		private DocumentLinkEventHandler documentLinkEventHandler_0;

		private DocumentTargetEventHandler documentTargetEventHandler_0;

		private DocumentTargetEventHandler documentTargetEventHandler_1;

		private TableOfContentsEventHandler tableOfContentsEventHandler_0;

		private TableOfContentsEventHandler tableOfContentsEventHandler_1;

		private TableOfContentsEventHandler tableOfContentsEventHandler_2;

		private TableOfContentsEventHandler tableOfContentsEventHandler_3;

		private SubTextPartEventHandler subTextPartEventHandler_0;

		private SubTextPartEventHandler subTextPartEventHandler_1;

		private SubTextPartEventHandler subTextPartEventHandler_2;

		private SubTextPartEventHandler subTextPartEventHandler_3;

		private SubTextPartEventHandler subTextPartEventHandler_4;

		private SubTextPartEventHandler subTextPartEventHandler_5;

		private EditableRegionEventHandler editableRegionEventHandler_0;

		private EditableRegionEventHandler editableRegionEventHandler_1;

		private EditableRegionEventHandler editableRegionEventHandler_2;

		private EditableRegionEventHandler editableRegionEventHandler_3;

		private CannotTrackChangeEventHandler cannotTrackChangeEventHandler_0;

		private TrackedChangeEventHandler trackedChangeEventHandler_0;

		private TrackedChangeEventHandler trackedChangeEventHandler_1;

		private TrackedChangeEventHandler trackedChangeEventHandler_2;

		private TrackedChangeEventHandler trackedChangeEventHandler_3;

		private FrameEventHandler frameEventHandler_0;

		private FrameEventHandler frameEventHandler_1;

		private FrameEventHandler frameEventHandler_2;

		private FrameEventHandler frameEventHandler_3;

		private FrameEventHandler frameEventHandler_4;

		private FrameEventHandler frameEventHandler_5;

		private FrameEventHandler frameEventHandler_6;

		private FrameEventHandler frameEventHandler_7;

		private ImageEventHandler imageEventHandler_0;

		private ImageEventHandler imageEventHandler_1;

		private ImageEventHandler imageEventHandler_2;

		private ImageEventHandler imageEventHandler_3;

		private ImageEventHandler imageEventHandler_4;

		private ImageEventHandler imageEventHandler_5;

		private ImageEventHandler imageEventHandler_6;

		private ImageEventHandler imageEventHandler_7;

		private ImageEventHandler imageEventHandler_8;

		private TextFrameEventHandler textFrameEventHandler_0;

		private TextFrameEventHandler textFrameEventHandler_1;

		private TextFrameEventHandler textFrameEventHandler_2;

		private TextFrameEventHandler textFrameEventHandler_3;

		private TextFrameEventHandler textFrameEventHandler_4;

		private TextFrameEventHandler textFrameEventHandler_5;

		private TextFrameEventHandler textFrameEventHandler_6;

		private TextFrameEventHandler textFrameEventHandler_7;

		private TextFrameEventHandler textFrameEventHandler_8;

		private TextFrameEventHandler textFrameEventHandler_9;

		private TextFrameEventHandler textFrameEventHandler_10;

		private TextFrameEventHandler textFrameEventHandler_11;

		private ChartEventHandler chartEventHandler_0;

		private ChartEventHandler chartEventHandler_1;

		private ChartEventHandler chartEventHandler_2;

		private ChartEventHandler chartEventHandler_3;

		private ChartEventHandler chartEventHandler_4;

		private ChartEventHandler chartEventHandler_5;

		private ChartEventHandler chartEventHandler_6;

		private ChartEventHandler chartEventHandler_7;

		private ChartEventHandler chartEventHandler_8;

		private BarcodeEventHandler barcodeEventHandler_0;

		private BarcodeEventHandler barcodeEventHandler_1;

		private BarcodeEventHandler barcodeEventHandler_2;

		private BarcodeEventHandler barcodeEventHandler_3;

		private BarcodeEventHandler barcodeEventHandler_4;

		private BarcodeEventHandler barcodeEventHandler_5;

		private BarcodeEventHandler barcodeEventHandler_6;

		private BarcodeEventHandler barcodeEventHandler_7;

		private BarcodeEventHandler barcodeEventHandler_8;

		private DrawingEventHandler drawingEventHandler_0;

		private DrawingEventHandler drawingEventHandler_1;

		private DrawingEventHandler drawingEventHandler_2;

		private DrawingEventHandler drawingEventHandler_3;

		private DrawingEventHandler drawingEventHandler_4;

		private DrawingEventHandler drawingEventHandler_5;

		private DrawingEventHandler drawingEventHandler_6;

		private DrawingEventHandler drawingEventHandler_7;

		private DrawingEventHandler drawingEventHandler_8;

		private DrawingEventHandler drawingEventHandler_9;

		private DrawingEventHandler drawingEventHandler_10;

		private HeaderFooterEventHandler headerFooterEventHandler_0;

		private HeaderFooterEventHandler headerFooterEventHandler_1;

		private TableEventHandler tableEventHandler_0;

		private TableEventHandler tableEventHandler_1;

		private TableEventHandler tableEventHandler_2;

		private AdaptFontEventHandler adaptFontEventHandler_0;

		private SpellCheckTextEventHandler spellCheckTextEventHandler_0;

		private HyphenateWordEventHandler hyphenateWordEventHandler_0;

		private XmlErrorEventHandler xmlErrorEventHandler_0;

		private XmlErrorEventHandler xmlErrorEventHandler_1;

		private bool bool_0;

		private bool bool_1 = true;

		private bool bool_2;

		private bool bool_3;

		private bool bool_4 = true;

		private AutoSize autoSize_0 = new AutoSize();

		private Color color_0 = SystemColors.Window;

		private BackgroundStyle backgroundStyle_0 = BackgroundStyle.ColorScheme;

		private int int_1;

		private BorderStyle borderStyle_0 = BorderStyle.None;

		private ButtonBar buttonBar_0;

		private int int_2;

		private bool bool_5;

		private Cursor cursor_0 = Cursors.IBeam;

		private Cursor cursor_1;

		private Cursor cursor_2;

		private Cursor cursor_3;

		internal Cursor cursor_4;

		internal Cursor cursor_5;

		private DialogUnit dialogUnit_0;

		private Colors colors_0 = new Colors();

		private DocumentPermissions documentPermissions_1 = new DocumentPermissions();

		private DocumentSettings documentSettings = new DocumentSettings();

		private bool bool_6;

		private bool bool_7 = true;

		private DropFormat dropFormat_0 = DropFormat.All;

		private EditMode editMode_0 = EditMode.Edit;

		private bool bool_8;

		private Cursor cursor_6 = Cursors.UpArrow;

		private FontSettings fontSettings_0 = new FontSettings();

		private FontUnderlineStyle fontUnderlineStyle_0 = FontUnderlineStyle.Single;

		private Color color_1 = SystemColors.WindowText;

		private string string_1 = "Standard";

		private FormulaReferenceStyle formulaReferenceStyle_0 = FormulaReferenceStyle.R1C1;

		private HeaderFooterActivationStyle headerFooterActivationStyle_0;

		private HeaderFooterFrameStyle headerFooterFrameStyle_0 = HeaderFooterFrameStyle.DividingLine;

		private bool bool_9 = true;

		private InputFormat inputFormat_0 = new InputFormat();

		private InputPosition inputPosition_0 = new InputPosition(1, 1, 0);

		private InsertionMode insertionMode_0 = InsertionMode.Insert;

		private bool bool_10;

		private EventHandler eventHandler_27;

		private bool bool_11 = true;

		private bool bool_12;

		private bool bool_13;

		private bool bool_14;

		private bool bool_15;

		private bool bool_16;

		private ListFormat listFormat_0 = new ListFormat(0);

		private PageMargins pageMargins_0 = new PageMargins();

		private PageSize pageSize_0 = new PageSize();

		private ParagraphFormat paragraphFormat_0 = new ParagraphFormat(0);

		private PermanentControlChar permanentControlChar_0 = PermanentControlChar.ObjectAnchor;

		private Ribbon ribbon_0;

		private RulerBar rulerBar_0;

		private ScrollBars scrollBars_0 = ScrollBars.Both;

		private SelectionViewMode selectionViewMode_0 = SelectionViewMode.TransparentBitmap;

		private bool bool_17;

		private MiniToolbarButton miniToolbarButton_0 = MiniToolbarButton.None;

		private Component component_0;

		private Class415 class415_0;

		internal Class589 class589_0 = new Class589();

		private StatusBar statusBar_0;

		private Color color_2 = SystemColors.Window;

		private bool bool_18 = true;

		private bool bool_19 = true;

		private string[] string_2;

		private RulerBar rulerBar_1;

		private ViewMode viewMode_0 = ViewMode.PageView;

		private int int_3 = 100;

		[CompilerGenerated]
		private MiniToolbar miniToolbar_1;

		[CompilerGenerated]
		private MiniToolbar miniToolbar_2;

		[CompilerGenerated]
		private Class456 class456_0;

		protected override Size DefaultSize => new Size(600, 200);

		protected override CreateParams CreateParams
		{
			get
			{
				CreateParams createParams = base.CreateParams;
				createParams.ClassName = this.string_0;
				if (createParams.Width == 0)
				{
					createParams.Width = 600;
				}
				if (createParams.Height == 0)
				{
					createParams.Height = 200;
				}
				createParams.Style |= 3145728;
				createParams.Style &= -33554433;
				return createParams;
			}
		}

		private Class603 Class603_0
		{
			get
			{
				if (this.class603_0 == null)
				{
					this.class603_0 = new Class603(this);
				}
				return this.class603_0;
			}
		}

		internal MiniToolbar MiniToolbar_0
		{
			[CompilerGenerated]
			get
			{
				return this.miniToolbar_1;
			}
			[CompilerGenerated]
			set
			{
				this.miniToolbar_1 = value;
			}
		}

		internal MiniToolbar MiniToolbar_1
		{
			[CompilerGenerated]
			get
			{
				return this.miniToolbar_2;
			}
			[CompilerGenerated]
			set
			{
				this.miniToolbar_2 = value;
			}
		}

		private int Int32_0 => ((this.scrollBars_0 == ScrollBars.Horizontal || this.scrollBars_0 == ScrollBars.Both) ? 1 : 32768) | ((this.scrollBars_0 == ScrollBars.Vertical || this.scrollBars_0 == ScrollBars.Both) ? 2 : 16384) | 4;

		/// <summary>Gets or sets a value indicating whether pressing the TAB key types a TAB character in the control instead of moving the focus to the next control in the tab order.</summary>
		[DefaultValue(true)]
		[Category("Behavior")]
		[Attribute3("PROP_ACCEPTSTAB")]
		public bool AcceptsTab
		{
			get
			{
				return this.bool_1;
			}
			set
			{
				if (this.bool_1 != value)
				{
					this.bool_1 = value;
					this.OnAcceptsTabChanged(EventArgs.Empty);
				}
			}
		}

		/// <summary>Gets or sets a value indicating whether the control can be a source of a Drag&amp;Drop operation.</summary>
		[DefaultValue(false)]
		[Attribute3("PROP_ALLOWDRAG")]
		[Category("Behavior")]
		public bool AllowDrag
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
					if (base.IsHandleCreated)
					{
						this.textControlCore_0.method_30(Enum83.const_30, this.bool_2 ? 8388608 : 16777216, 0);
					}
				}
			}
		}

		/// <summary>Overridden. Gets or sets a value indicating whether the control can accept data that the user drags onto it.</summary>
		public override bool AllowDrop
		{
			get
			{
				return base.AllowDrop;
			}
			set
			{
				base.AllowDrop = value;
				if (this.bool_3 != value)
				{
					this.bool_3 = value;
					if (base.IsHandleCreated)
					{
						this.textControlCore_0.method_30(Enum83.const_30, this.bool_3 ? 4194304 : 33554432, 0);
					}
				}
			}
		}

		/// <summary>Gets or sets a value indicating whether the undo buffer is active or not.</summary>
		[Attribute3("PROP_ALLOWUNDO")]
		[Category("Behavior")]
		[DefaultValue(true)]
		public bool AllowUndo
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
					if (base.IsHandleCreated)
					{
						this.textControlCore_0.method_30(Enum83.const_205, this.bool_4 ? 1 : 0, 0);
					}
				}
			}
		}

		/// <summary>Gets a collection of all application fields contained in the text part with the input focus.</summary>
		[Browsable(false)]
		public ApplicationFieldCollection ApplicationFields
		{
			get
			{
				if (base.IsHandleCreated)
				{
					return new ApplicationFieldCollection(this.textControlCore_0, TextPart.Auto);
				}
				return null;
			}
		}

		/// <summary>Gets or sets values that enable automatic expansion or shrinking of a Text Control's width or height depending on the currently contained text.</summary>
		[Category("Layout")]
		[Attribute3("PROP_AUTOSIZE")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		public AutoSize AutoControlSize
		{
			get
			{
				return this.autoSize_0;
			}
			set
			{
				this.autoSize_0.method_4(value.MaxSize, value.MinSize);
				value.method_2(this.autoSize_0);
				this.autoSize_0.method_5();
			}
		}

		/// <summary>Overridden. Gets or sets the background color of the control.</summary>
		[RefreshProperties(RefreshProperties.Repaint)]
		public override Color BackColor
		{
			get
			{
				if (this.color_0 == Color.Transparent)
				{
					return this.color_0;
				}
				if (base.IsHandleCreated)
				{
					int[] array = new int[1];
					int num = this.textControlCore_0.method_41(Enum83.const_26, 0, array);
					this.color_0 = ((num == 1) ? SystemColors.Window : Class429.smethod_2(array[0]));
				}
				return this.color_0;
			}
			set
			{
				if (this.color_0 != value)
				{
					if (base.IsHandleCreated)
					{
						this.method_30(value, this.viewMode_0);
						this.textControlCore_0.method_30(Enum83.const_41, (value == SystemColors.Window) ? 1 : 0, Class429.smethod_0(value));
					}
					this.color_0 = value;
					this.OnBackColorChanged(EventArgs.Empty);
				}
			}
		}

		/// <summary>Defines the kind of view to display the page background.</summary>
		[Category("Appearance")]
		[Attribute3("PROP_BACKGROUNDSTYLE")]
		[DefaultValue(BackgroundStyle.ColorScheme)]
		public BackgroundStyle BackgroundStyle
		{
			get
			{
				return this.backgroundStyle_0;
			}
			set
			{
				if (this.backgroundStyle_0 != value)
				{
					this.backgroundStyle_0 = value;
					if (base.IsHandleCreated)
					{
						this.textControlCore_0.method_30(Enum83.const_30, (this.backgroundStyle_0 == BackgroundStyle.ColorScheme) ? 2097152 : 67108864, 0);
					}
				}
			}
		}

		/// <summary>Gets a collection of all barcodes contained in the text part with the input focus.</summary>
		[Browsable(false)]
		public BarcodeCollection Barcodes
		{
			get
			{
				if (base.IsHandleCreated)
				{
					return new BarcodeCollection(this.textControlCore_0, TextPart.Auto);
				}
				return null;
			}
		}

		/// <summary>Gets or sets the baseline alignment, in twips, of the Text Control.</summary>
		[Attribute3("PROP_BASELINE")]
		[DefaultValue(0)]
		[Category("Appearance")]
		public int Baseline
		{
			get
			{
				return this.int_1;
			}
			set
			{
				if (this.int_1 != value)
				{
					if (value < -960 || value > 960)
					{
						throw new ArgumentOutOfRangeException();
					}
					this.int_1 = value;
					if (base.IsHandleCreated)
					{
						this.textControlCore_0.method_12(TextPart.Auto);
						this.textControlCore_0.method_29(TextPart.Auto, 1160, (value == 0) ? 2 : ((value < 0) ? 8 : 4), Math.Abs(value));
						this.textControlCore_0.method_15(TextPart.Auto);
					}
				}
			}
		}

		/// <summary>Gets or sets the border type of the Text Control.</summary>
		[Category("Appearance")]
		[Attribute3("PROP_BORDERSTYLE")]
		[DefaultValue(BorderStyle.None)]
		public BorderStyle BorderStyle
		{
			get
			{
				return this.borderStyle_0;
			}
			set
			{
				if (this.borderStyle_0 != value)
				{
					this.borderStyle_0 = value;
					if (base.IsHandleCreated)
					{
						this.textControlCore_0.method_30(Enum83.const_30, (this.borderStyle_0 == BorderStyle.None) ? 4096 : 8, 0);
					}
					this.OnBorderStyleChanged(EventArgs.Empty);
				}
			}
		}

		/// <summary>Specifies the button bar control to be used with a TextControl.</summary>
		[Category("Behavior")]
		[Attribute3("PROP_BUTTONBAR")]
		[TypeConverter(typeof(Class425))]
		[DefaultValue(null)]
		public ButtonBar ButtonBar
		{
			get
			{
				return this.buttonBar_0;
			}
			set
			{
				if (this.buttonBar_0 != null)
				{
					this.buttonBar_0.Disposed -= buttonBar_0_Disposed;
					if (value == null)
					{
						this.method_32(this.buttonBar_0);
					}
				}
				this.buttonBar_0 = value;
				if (this.buttonBar_0 != null)
				{
					if (this.Focused)
					{
						this.method_31(this.buttonBar_0);
					}
					this.buttonBar_0.Disposed += buttonBar_0_Disposed;
				}
				if (this.rulerBar_0 != null)
				{
					this.rulerBar_0.ButtonBar_0 = this.buttonBar_0;
				}
			}
		}

		/// <summary>Informs whether a part of a Text Control document has been selected and can be copied to the clipboard.</summary>
		[Browsable(false)]
		public bool CanCopy
		{
			get
			{
				if (!base.IsHandleCreated)
				{
					return false;
				}
				return this.textControlCore_0.method_29(TextPart.Auto, 2046, 0, 0) != 0;
			}
		}

		/// <summary>Informs whether the clipboard contains a format that can be pasted into a Text Control document.</summary>
		[Browsable(false)]
		public bool CanPaste
		{
			get
			{
				if (!base.IsHandleCreated)
				{
					return false;
				}
				return this.textControlCore_0.method_29(TextPart.Auto, 2047, 0, 0) != 0;
			}
		}

		/// <summary>Gets a value indicating whether the user can undo the previous operation in a Text Control.</summary>
		[Browsable(false)]
		public bool CanUndo
		{
			get
			{
				if (!base.IsHandleCreated)
				{
					return false;
				}
				return (this.textControlCore_0.method_29(TextPart.Auto, 2031, 0, 0) & 0xFFFF) != 0;
			}
		}

		/// <summary>Informs whether an operation can be re-done using the Redo method.</summary>
		[Browsable(false)]
		public bool CanRedo
		{
			get
			{
				if (!base.IsHandleCreated)
				{
					return false;
				}
				return (this.textControlCore_0.method_29(TextPart.Auto, 2031, 0, 0) & 0xFFFF0000L) != 0L;
			}
		}

		/// <summary>Informs whether the document can be printed.</summary>
		[Browsable(false)]
		public bool CanPrint
		{
			get
			{
				if (this.documentPermissions_0 == null)
				{
					return false;
				}
				return this.documentPermissions_0.AllowPrinting;
			}
		}

		/// <summary>Informs whether the document's text and/or formatting attributes can be changed.</summary>
		[Browsable(false)]
		public bool CanEdit
		{
			get
			{
				if (this.documentPermissions_0 == null)
				{
					return false;
				}
				return !this.documentPermissions_0.ReadOnly;
			}
		}

		/// <summary>Informs whether the currently selected text can be formatted with character formatting attributes.</summary>
		[Browsable(false)]
		public bool CanCharacterFormat
		{
			get
			{
				if (this.documentPermissions_0 == null)
				{
					return false;
				}
				return this.documentPermissions_0.Boolean_0;
			}
		}

		/// <summary>Informs whether the currently selected text can be formatted with paragraph formatting attributes.</summary>
		[Browsable(false)]
		public bool CanParagraphFormat
		{
			get
			{
				if (this.documentPermissions_0 == null)
				{
					return false;
				}
				return this.documentPermissions_0.Boolean_1;
			}
		}

		/// <summary>Informs whether the currently selected text can be formatted with table formatting attributes.</summary>
		[Browsable(false)]
		public bool CanTableFormat
		{
			get
			{
				if (this.documentPermissions_0 == null)
				{
					return false;
				}
				return this.documentPermissions_0.Boolean_2;
			}
		}

		/// <summary>Informs whether the document can be formatted with formatting styles.</summary>
		[Browsable(false)]
		public bool CanStyleFormat
		{
			get
			{
				if (this.documentPermissions_0 == null)
				{
					return false;
				}
				return this.documentPermissions_0.AllowFormattingStyles;
			}
		}

		/// <summary>Informs whether the document can be formatted with page and section formatting attributes.</summary>
		[Browsable(false)]
		public bool CanDocumentFormat
		{
			get
			{
				if (this.documentPermissions_0 == null)
				{
					return false;
				}
				return this.documentPermissions_0.AllowFormatting;
			}
		}

		/// <summary>Informs whether form fields can be edited.</summary>
		[Browsable(false)]
		public bool CanEditFormFields
		{
			get
			{
				if (this.documentPermissions_0 == null)
				{
					return false;
				}
				return this.documentPermissions_0.AllowEditingFormFields;
			}
		}

		/// <summary>Gets or sets the width of the caret in pixels.</summary>
		[Category("Appearance")]
		[Attribute3("PROP_CARETWIDTH")]
		[DefaultValue(0)]
		public int CaretWidth
		{
			get
			{
				return this.int_2;
			}
			set
			{
				if (this.int_2 != value)
				{
					if (value < 0 || value > 255)
					{
						throw new ArgumentOutOfRangeException(this.resources.GetString("ERR_CARETWIDTH"));
					}
					this.int_2 = value;
					if (base.IsHandleCreated)
					{
						this.textControlCore_0.method_30(Enum83.const_67, 0, this.int_2);
					}
				}
			}
		}

		/// <summary>Gets a collection of all charts contained in the text part with the input focus.</summary>
		[Browsable(false)]
		public ChartCollection Charts
		{
			get
			{
				if (base.IsHandleCreated)
				{
					return new ChartCollection(this.textControlCore_0, TextPart.Auto);
				}
				return null;
			}
		}

		internal Class456 Class456_0
		{
			[CompilerGenerated]
			get
			{
				return this.class456_0;
			}
			[CompilerGenerated]
			set
			{
				this.class456_0 = value;
			}
		}

		/// <summary>Specifies if control characters are visible or not.</summary>
		[Category("Appearance")]
		[Attribute3("PROP_CONTROLCHARS")]
		[DefaultValue(false)]
		public bool ControlChars
		{
			get
			{
				if (base.IsHandleCreated)
				{
					Enum90 @enum = (Enum90)this.textControlCore_0.method_30(Enum83.const_6, 0, 0);
					this.bool_5 = (@enum & Enum90.const_4) != 0;
				}
				return this.bool_5;
			}
			set
			{
				if (this.bool_5 != value)
				{
					this.bool_5 = value;
					if (base.IsHandleCreated)
					{
						this.textControlCore_0.method_30(Enum83.const_30, this.bool_5 ? 16 : 2048, 0);
					}
				}
			}
		}

		public override Cursor Cursor
		{
			get
			{
				if (!base.DesignMode && base.IsHandleCreated)
				{
					if (this.miniToolbar_0 != null && this.miniToolbar_0.IsHandleCreated && this.miniToolbar_0.Visible && this.miniToolbar_0.Boolean_1)
					{
						Point position = Cursor.Position;
						if (position.X < this.miniToolbar_0.Left - 150 || position.X > this.miniToolbar_0.Right + 150 || position.Y < this.miniToolbar_0.Top - 100 || position.Y > this.miniToolbar_0.Bottom + 100)
						{
							this.miniToolbar_0.Close();
						}
					}
					return this.textControlCore_0.method_29(TextPart.Auto, 2064, 0, 0) switch
					{
						2 => this.cursor_1, 
						3 => this.cursor_3, 
						4 => this.FieldCursor, 
						5 => Cursors.Arrow, 
						6 => this.cursor_2, 
						7 => Cursors.SizeWE, 
						8 => Cursors.SizeNS, 
						9 => Cursors.SizeNWSE, 
						10 => Cursors.SizeNESW, 
						11 => Cursors.SizeAll, 
						12 => Cursors.Cross, 
						_ => this.cursor_0, 
					};
				}
				return this.cursor_0;
			}
			set
			{
				this.cursor_0 = value;
			}
		}

		/// <summary>Gets or sets a value indicating the measuring unit used for sizes and distances in dialogboxes.</summary>
		[DefaultValue(DialogUnit.Auto)]
		[Category("Appearance")]
		[Attribute3("PROP_DIALOGUNIT")]
		public DialogUnit DialogUnit
		{
			get
			{
				return this.dialogUnit_0;
			}
			set
			{
				if (this.dialogUnit_0 != value)
				{
					this.dialogUnit_0 = value;
					if (base.IsHandleCreated)
					{
						this.textControlCore_0.method_4(this.dialogUnit_0);
					}
				}
			}
		}

		/// <summary>Gets or sets the colors of the text control.</summary>
		[Attribute3("PROP_DISPLAYCOLORS")]
		[Category("Appearance")]
		[RefreshProperties(RefreshProperties.Repaint)]
		[TypeConverter(typeof(Class417))]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		public Colors DisplayColors
		{
			get
			{
				return this.colors_0;
			}
			set
			{
				value.method_2(this.colors_0);
				this.colors_0.method_0();
			}
		}

		/// <summary>Gets a collection of all document links contained in the text part with the input focus.</summary>
		[Browsable(false)]
		public DocumentLinkCollection DocumentLinks
		{
			get
			{
				if (base.IsHandleCreated)
				{
					return new DocumentLinkCollection(this.textControlCore_0, TextPart.Auto);
				}
				return null;
			}
		}

		/// <summary>Gets a DocumentPermissions object which provides properties determining how a document can be edited and formatted when the EditMode property is set to EditMode.ReadAndSelect.</summary>
		[Attribute3("PROP_DOCUMENTPERMISSIONS")]
		[Category("Behavior")]
		[TypeConverter(typeof(Class417))]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		public DocumentPermissions DocumentPermissions => this.documentPermissions_1;

		/// <summary>Gets a DocumentSettings object providing properties which inform about general document settings, such as author and title, contained in the document the user is currently working on.</summary>
		[Browsable(false)]
		public DocumentSettings DocumentSettings => this.documentSettings;

		/// <summary>Gets or sets a value indicating that markers for hypertext targets are shown or not.</summary>
		[Category("Appearance")]
		[DefaultValue(false)]
		[Attribute3("PROP_TARGETMARKERS")]
		public bool DocumentTargetMarkers
		{
			get
			{
				if (base.IsHandleCreated)
				{
					Enum90 @enum = (Enum90)this.textControlCore_0.method_30(Enum83.const_6, 0, 0);
					this.bool_6 = (@enum & Enum90.const_12) != 0;
				}
				return this.bool_6;
			}
			set
			{
				if (this.bool_6 != value)
				{
					this.bool_6 = value;
					if (base.IsHandleCreated)
					{
						this.textControlCore_0.method_30(Enum83.const_30, this.bool_6 ? 1048576 : 134217728, 0);
					}
				}
			}
		}

		/// <summary>Gets a collection of all targets contained in the text part with the input focus.</summary>
		[Browsable(false)]
		public DocumentTargetCollection DocumentTargets
		{
			get
			{
				if (base.IsHandleCreated)
				{
					return new DocumentTargetCollection(this.textControlCore_0, TextPart.Auto);
				}
				return null;
			}
		}

		/// <summary>Specifies whether a marker frame is shown around a drawing to indicate its position and size.</summary>
		[Category("Appearance")]
		[Attribute3("PROP_DRAWINGMARKERLINES")]
		[DefaultValue(true)]
		public bool DrawingMarkerLines
		{
			get
			{
				if (base.IsHandleCreated)
				{
					int[] array = new int[1];
					int[] array2 = array;
					this.textControlCore_0.method_41(Enum83.const_25, 0, array2);
					this.bool_7 = (array2[0] & 0x8000) != 0;
				}
				return this.bool_7;
			}
			set
			{
				if (this.bool_7 != value)
				{
					this.bool_7 = value;
					if (base.IsHandleCreated)
					{
						this.textControlCore_0.method_30(Enum83.const_40, 0, (!this.bool_7) ? 1 : 32768);
					}
				}
			}
		}

		/// <summary>Gets a collection of all drawings contained in the text part with the input focus.</summary>
		[Browsable(false)]
		public DrawingCollection Drawings
		{
			get
			{
				
				if (base.IsHandleCreated)
				{
					return new DrawingCollection(this.textControlCore_0, TextPart.Auto);
				}
				return null;
			}
		}

		/// <summary>Gets or sets the formats of data the control can accept when the user drags it onto the control.</summary>
		[Category("Behavior")]
		[Attribute3("PROP_DROPFORMAT")]
		[DefaultValue(DropFormat.All)]
		public DropFormat DropFormats
		{
			get
			{
				return this.dropFormat_0;
			}
			set
			{
				if (this.dropFormat_0 != value)
				{
					this.dropFormat_0 = value;
					if (base.IsHandleCreated)
					{
						this.textControlCore_0.method_30(Enum83.const_273, (int)this.dropFormat_0, 0);
					}
				}
			}
		}

		/// <summary>Gets a collection of all editable regions contained in the document.</summary>
		[Browsable(false)]
		public EditableRegionCollection EditableRegions
		{
			get
			{
				
				if (base.IsHandleCreated)
				{
					return new EditableRegionCollection(this.textControlCore_0, TextPart.Auto);
				}
				return null;
			}
		}

		/// <summary>Gets or sets a value indicating whether the document's text is protected, or can be freely edited and formatted.</summary>
		[DefaultValue(EditMode.Edit)]
		[Category("Behavior")]
		[Attribute3("PROP_EDITMODE")]
		public EditMode EditMode
		{
			get
			{
				if (base.IsHandleCreated)
				{
					Enum91 @enum = (Enum91)this.textControlCore_0.method_30(Enum83.const_25, 0, 0);
					this.editMode_0 = (((@enum & Enum91.const_15) != 0) ? EditMode.Edit : (((@enum & Enum91.const_3) != 0) ? EditMode.ReadAndSelect : EditMode.ReadOnly));
				}
				return this.editMode_0;
			}
			set
			{
				if (!base.IsHandleCreated)
				{
					this.editMode_0 = value & (EditMode)(-2049);
					return;
				}
				Enum91 @enum = (((value & EditMode.UsePassword) != 0) ? Enum91.const_4 : ((Enum91)0u));
				value &= (EditMode)(-2049);
				@enum |= value switch
				{
					EditMode.ReadAndSelect => Enum91.const_3, 
					EditMode.Edit => Enum91.const_15, 
					_ => Enum91.const_0, 
				};
				if (this.textControlCore_0.method_30(Enum83.const_323, (int)@enum, 0) != 0)
				{
					this.method_25();
					this.editMode_0 = value;
				}
			}
		}

		[Attribute3("PROP_ENABLEDPISCALING")]
		[Category("Behavior")]
		[DefaultValue(false)]
		public bool EnableDpiScaling
		{
			get
			{
				if (base.IsHandleCreated)
				{
					int[] array = new int[1];
					int[] array2 = array;
					this.textControlCore_0.method_41(Enum83.const_25, 0, array2);
					this.bool_8 = (array2[0] & int.MinValue) != 0;
				}
				return this.bool_8;
			}
			set
			{
				if (this.bool_8 != value)
				{
					this.bool_8 = value;
					if (base.IsHandleCreated)
					{
						this.textControlCore_0.method_30(Enum83.const_40, 0, this.bool_8 ? int.MinValue : 131072);
					}
				}
			}
		}

		/// <summary>Gets or sets the cursor that is displayed when the mouse pointer is over a marked text field.</summary>
		[Attribute2("CAT_FIELDS")]
		[Attribute3("PROP_FIELDCURSOR")]
		public Cursor FieldCursor
		{
			get
			{
				return this.cursor_6;
			}
			set
			{
				this.cursor_6 = value;
			}
		}

		/// <summary>Gets a FontSettings object which provides properties determining which fonts can be used in a document.</summary>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		[Category("Behavior")]
		[Attribute3("PROP_FONTSETTINGS")]
		public FontSettings FontSettings => this.fontSettings_0;

		/// <summary>Gets or sets underlining style for the text displayed by the control.</summary>
		[Attribute3("PROP_FONTUNDERLINESTYLE")]
		[Category("Appearance")]
		[DefaultValue(FontUnderlineStyle.Single)]
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
				if (base.IsHandleCreated && this.Font.Underline)
				{
					int num = 0;
					switch (this.fontUnderlineStyle_0)
					{
					case FontUnderlineStyle.Doubled:
						num = 4672;
						break;
					case FontUnderlineStyle.DoubledWordsOnly:
						num = 4288;
						break;
					case FontUnderlineStyle.Single:
						num = 16912;
						break;
					case FontUnderlineStyle.SingleWordsOnly:
						num = 16528;
						break;
					}
					this.textControlCore_0.method_12(TextPart.Auto);
					this.textControlCore_0.method_29(TextPart.Auto, 1154, num, 0);
					this.textControlCore_0.method_15(TextPart.Auto);
				}
			}
		}

		/// <summary>Overridden. Gets or sets the foreground color of the control which is the color of the document's text.</summary>
		public override Color ForeColor
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
					if (base.IsHandleCreated)
					{
						int[] array = new int[2]
						{
							Class429.smethod_0(value),
							0
						};
						this.textControlCore_0.method_12(TextPart.Auto);
						this.textControlCore_0.method_40(TextPart.Auto, 1168, (value == SystemColors.WindowText) ? 1 : 2, array);
						this.textControlCore_0.method_15(TextPart.Auto);
					}
					this.OnForeColorChanged(EventArgs.Empty);
				}
			}
		}

		/// <summary>Gets or sets the name of a printer the text dimensions and capabilities of which are used to format the document.</summary>
		[Attribute3("PROP_FORMATTINGPRINTER")]
		[Category("Layout")]
		[DefaultValue("Standard")]
		[TypeConverter(typeof(Class418))]
		public string FormattingPrinter
		{
			get
			{
				if (base.IsHandleCreated)
				{
					return this.textControlCore_0.method_26();
				}
				return this.string_1;
			}
			set
			{
				if (this.string_1 != value)
				{
					this.string_1 = value;
					if (base.IsHandleCreated)
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
				if (base.IsHandleCreated)
				{
					return new FormFieldCollection(this.textControlCore_0, TextPart.Auto);
				}
				return null;
			}
		}

		/// <summary>Gets or sets a value determining how references to table cells in formulas are specified.</summary>
		[Category("Behavior")]
		[Attribute3("PROP_FORMULAREFSTYLE")]
		[DefaultValue(FormulaReferenceStyle.R1C1)]
		public FormulaReferenceStyle FormulaReferenceStyle
		{
			get
			{
				if (base.IsHandleCreated)
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
					if (base.IsHandleCreated)
					{
						this.textControlCore_0.method_30(Enum83.const_40, 0, (this.formulaReferenceStyle_0 == FormulaReferenceStyle.R1C1) ? 256 : 65536);
					}
				}
			}
		}

		/// <summary>Gets a collection of all images, textframes, charts, barcodes and drawings contained in the text part with the input focus.</summary>
		[Browsable(false)]
		public FrameCollection Frames
		{
			get
			{
				if (base.IsHandleCreated)
				{
					return new FrameCollection(this.textControlCore_0, TextPart.Auto);
				}
				return null;
			}
		}

		/// <summary>Gets or sets a value specifying the activation style for headers and footers.</summary>
		[Category("Appearance")]
		[DefaultValue(HeaderFooterActivationStyle.ActivateDoubleClick)]
		[Attribute3("PROP_HEADERFOOTERACTIVATIONSTYLE")]
		public HeaderFooterActivationStyle HeaderFooterActivationStyle
		{
			get
			{
				return this.headerFooterActivationStyle_0;
			}
			set
			{
				if (this.headerFooterActivationStyle_0 != value)
				{
					this.headerFooterActivationStyle_0 = value;
					if (base.IsHandleCreated)
					{
						this.textControlCore_0.method_30(Enum83.const_137, (int)this.headerFooterActivationStyle_0 | (int)this.headerFooterFrameStyle_0, 0);
					}
				}
			}
		}

		/// <summary>Gets or sets a value specifying the frame for activated headers and footers.</summary>
		[Category("Appearance")]
		[Attribute3("PROP_HEADERFOOTERFRAMESTYLE")]
		[DefaultValue(HeaderFooterFrameStyle.DividingLine)]
		public HeaderFooterFrameStyle HeaderFooterFrameStyle
		{
			get
			{
				return this.headerFooterFrameStyle_0;
			}
			set
			{
				if (this.headerFooterFrameStyle_0 != value)
				{
					this.headerFooterFrameStyle_0 = value;
					if (base.IsHandleCreated)
					{
						this.textControlCore_0.method_30(Enum83.const_137, (int)this.headerFooterActivationStyle_0 | (int)this.headerFooterFrameStyle_0, 0);
					}
				}
			}
		}

		/// <summary>Gets a collection of all headers and footers the current document contains.</summary>
		[Browsable(false)]
		public HeaderFooterCollection HeadersAndFooters
		{
			get
			{
				
				if (base.IsHandleCreated)
				{
					return new HeaderFooterCollection(this.textControlCore_0, 0);
				}
				return null;
			}
		}

		/// <summary>Gets or sets a value indicating whether the selected text in the Text Control remains highlighted when the control loses focus.</summary>
		[DefaultValue(true)]
		[Attribute3("PROP_HIDESELECTION")]
		[Category("Behavior")]
		public bool HideSelection
		{
			get
			{
				return this.bool_9;
			}
			set
			{
				if (this.bool_9 != value)
				{
					this.bool_9 = value;
					if (base.IsHandleCreated)
					{
						this.textControlCore_0.method_30(Enum83.const_30, this.bool_9 ? 1024 : 32, 0);
					}
				}
			}
		}

		/// <summary>Gets a collection of all hypertext links contained in the text part with the input focus.</summary>
		[Browsable(false)]
		public HypertextLinkCollection HypertextLinks
		{
			get
			{
				
				if (base.IsHandleCreated)
				{
					return new HypertextLinkCollection(this.textControlCore_0, TextPart.Auto);
				}
				return null;
			}
		}

		/// <summary>Gets a collection of all images contained in the text part with the input focus.</summary>
		[Browsable(false)]
		public ImageCollection Images
		{
			get
			{
				if (base.IsHandleCreated)
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
				
				if (base.IsHandleCreated)
				{
					return new InlineStyleCollection(this.textControlCore_0);
				}
				return null;
			}
		}

		/// <summary>Gets an object of the type InputFormat which represents all formatting attributes at the current text input position.</summary>
		[Browsable(false)]
		public InputFormat InputFormat => this.inputFormat_0;

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

		/// <summary>Specifies whether text is inserted or overwrites existing text.</summary>
		[DefaultValue(InsertionMode.Insert)]
		[Category("Appearance")]
		[Attribute3("PROP_INSERTIONMODE")]
		public InsertionMode InsertionMode
		{
			get
			{
				return this.insertionMode_0;
			}
			set
			{
				if (this.insertionMode_0 != value)
				{
					this.insertionMode_0 = value;
					if (base.IsHandleCreated)
					{
						this.textControlCore_0.method_30(Enum83.const_30, (this.insertionMode_0 == InsertionMode.Insert) ? 8192 : 4, 0);
					}
				}
			}
		}

		/// <summary>Gets or sets a value indicating whether Conditional Instructions are applied to form fields when the EditMode property is set to EditMode.ReadAndSelect and TextControl.DocumentPermissions.ReadOnly to true.</summary>
		[Category("Behavior")]
		[DefaultValue(false)]
		[Attribute3("PROP_ISAPPLYCONDITIONALINSTRUCTIONSENABLED")]
		public bool IsFormFieldValidationEnabled
		{
			get
			{
				return this.bool_10;
			}
			set
			{
				if (this.bool_10 != (this.bool_10 = value))
				{
					if (this.bool_10 && this.Class456_0 == null)
					{
						this.Class456_0 = new Class456(this);
					}
					if (this.Class456_0 != null && base.IsHandleCreated)
					{
						this.Class456_0.method_17(this.bool_10);
					}
					this.method_39();
				}
			}
		}

		/// <summary>Gets or sets a value indicating whether formulas in tables are automatically calculated when the text of an input cell is changed.</summary>
		[DefaultValue(true)]
		[Category("Behavior")]
		[Attribute3("PROP_ISFORMULACALCENABLED")]
		public bool IsFormulaCalculationEnabled
		{
			get
			{
				if (base.IsHandleCreated)
				{
					int[] array = new int[1];
					int[] array2 = array;
					this.textControlCore_0.method_41(Enum83.const_25, 0, array2);
					this.bool_11 = (array2[0] & 0x80) != 0;
				}
				return this.bool_11;
			}
			set
			{
				if (this.bool_11 != value)
				{
					this.bool_11 = value;
					if (base.IsHandleCreated)
					{
						this.textControlCore_0.method_30(Enum83.const_40, 0, this.bool_11 ? 128 : 512);
					}
				}
			}
		}

		/// <summary>Gets or sets a value indicating whether language detection is active or not.</summary>
		[DefaultValue(false)]
		[Attribute3("PROP_ISLANGUAGEDETECTIONENABLED")]
		[Category("Behavior")]
		public bool IsLanguageDetectionEnabled
		{
			get
			{
				return this.bool_12;
			}
			set
			{
				if (this.bool_12 != value)
				{
					this.bool_12 = value;
					if (base.IsHandleCreated)
					{
						this.textControlCore_0.method_77(Enum83.const_275, this.bool_12 ? 3 : 2, this.delegate12_0);
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
				return this.bool_13;
			}
			set
			{
				if (this.bool_13 != value)
				{
					this.bool_13 = value;
					if (base.IsHandleCreated)
					{
						this.textControlCore_0.method_76(Enum83.const_275, this.bool_13 ? 1 : 0, this.delegate10_0);
					}
				}
			}
		}

		/// <summary>Gets or sets a value indicating whether hyphenation is active or not.</summary>
		[DefaultValue(false)]
		[Category("Behavior")]
		[Attribute3("PROP_ISHYPHENATIONENABLED")]
		public bool IsHyphenationEnabled
		{
			get
			{
				return this.bool_14;
			}
			set
			{
				if (this.bool_14 != value)
				{
					this.bool_14 = value;
					if (base.IsHandleCreated)
					{
						this.textControlCore_0.method_78(Enum83.const_38, this.bool_14 ? 1 : 0, this.delegate11_0);
					}
				}
			}
		}

		/// <summary>Gets or sets a value indicating whether track changes is active or not.</summary>
		[Attribute3("PROP_ISTRACKCHANGESENABLED")]
		[DefaultValue(false)]
		[Category("Behavior")]
		public bool IsTrackChangesEnabled
		{
			get
			{
				if (base.IsHandleCreated)
				{
					int[] array = new int[1];
					int[] array2 = array;
					this.textControlCore_0.method_41(Enum83.const_25, 0, array2);
					this.bool_15 = (array2[0] & 0x40) != 0;
				}
				return this.bool_15;
			}
			set
			{
				if (this.bool_15 != value)
				{
					this.bool_15 = value;
					if (base.IsHandleCreated)
					{
						this.textControlCore_0.method_30(Enum83.const_40, 0, this.bool_15 ? 64 : 1024);
					}
				}
			}
		}

		/// <summary>Gets or sets a value indicating whether the page orientation is landscape or portrait.</summary>
		[DefaultValue(false)]
		[Category("Layout")]
		[Attribute3("PROP_LANDSCAPE")]
		public bool Landscape
		{
			get
			{
				return this.bool_16;
			}
			set
			{
				if (this.bool_16 != value)
				{
					this.bool_16 = value;
					this.pageSize_0.Boolean_0 = this.bool_16;
					if (base.IsHandleCreated)
					{
						this.textControlCore_0.method_30(Enum83.const_235, 0, this.bool_16 ? 1073741824 : int.MinValue);
						this.pageSize_0.method_2();
						this.pageSize_0.method_6();
					}
				}
			}
		}

		/// <summary>Gets a collection of all lines contained in the text part with the input focus.</summary>
		[Browsable(false)]
		public LineCollection Lines
		{
			get
			{
				if (base.IsHandleCreated)
				{
					return new LineCollection(this.textControlCore_0, TextPart.Auto);
				}
				return null;
			}
		}

		/// <summary>Gets or sets the type and the formatting attributes of a bulleted or numbered list.</summary>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		[Attribute3("PROP_LIST")]
		[Category("Appearance")]
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

		/// <summary>Gets a collection of all misspelled words contained in the text part with the input focus.</summary>
		[Browsable(false)]
		public MisspelledWordCollection MisspelledWords
		{
			get
			{
				if (base.IsHandleCreated)
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
				if (!base.IsHandleCreated)
				{
					return 0;
				}
				return this.textControlCore_0.method_30(Enum83.const_56, 0, 0);
			}
		}

		/// <summary>Specifies the width and height of the pages for the current document.</summary>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		[Category("Layout")]
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
				this.pageSize_0.Boolean_0 = this.bool_16;
				this.pageSize_0.method_6();
			}
		}

		/// <summary>Gets or sets the measure used for page sizes and page margins.</summary>
		[Browsable(false)]
		[DefaultValue(MeasuringUnit.CentiInch)]
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
		[Category("Appearance")]
		[Attribute3("PROP_PARAGRAPH")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
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

		/// <summary>Gets a collection of all paragraphs contained in the text part with the input focus.</summary>
		[Browsable(false)]
		public ParagraphCollection Paragraphs
		{
			get
			{
				if (base.IsHandleCreated)
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
				
				if (base.IsHandleCreated)
				{
					return new ParagraphStyleCollection(this.textControlCore_0);
				}
				return null;
			}
		}

		/// <summary>Gets or sets a value indicating which control characters are shown permanently on the screen.</summary>
		[Category("Appearance")]
		[Attribute3("PROP_PERMANENTCONTROLCHARS")]
		[DefaultValue(PermanentControlChar.ObjectAnchor)]
		public PermanentControlChar PermanentControlChars
		{
			get
			{
				return this.permanentControlChar_0;
			}
			set
			{
				if (this.permanentControlChar_0 != value)
				{
					this.permanentControlChar_0 = value;
					if (base.IsHandleCreated)
					{
						this.textControlCore_0.method_30(Enum83.const_296, (int)this.permanentControlChar_0, 0);
					}
				}
			}
		}

		/// <summary>Gets a string that represents the name of the action that will be performed when a call to the Redo method is made.</summary>
		[Browsable(false)]
		public string RedoActionName
		{
			get
			{
				string result = null;
				if (base.IsHandleCreated)
				{
					TxUndoAction txUndoAction = (TxUndoAction)Class429.smethod_6(this.textControlCore_0.method_29(TextPart.Auto, 2031, 0, 0));
					switch (txUndoAction)
					{
					case TxUndoAction.UNDO_USERNAME:
					{
						IntPtr intPtr = this.textControlCore_0.method_64(TextPart.Auto, Enum83.const_313, 2u, 0);
						if (intPtr != IntPtr.Zero)
						{
							result = Marshal.PtrToStringBSTR(intPtr);
							Marshal.FreeBSTR(intPtr);
						}
						break;
					}
					default:
						result = this.resources.GetString(txUndoAction.ToString());
						break;
					case (TxUndoAction)0:
						break;
					}
				}
				return result;
			}
		}

		/// <summary>Specifies the ribbon control to be used with a TextControl.</summary>
		[TypeConverter(typeof(Class428))]
		[Category("Behavior")]
		[Attribute3("PROP_RIBBON")]
		[DefaultValue(null)]
		public Ribbon Ribbon
		{
			get
			{
				return this.ribbon_0;
			}
			set
			{
				if (this.ribbon_0 != value)
				{
					
					if (this.ribbon_0 != null)
					{
						this.ribbon_0.TextControl_0 = null;
					}
					this.ribbon_0 = value;
					if (base.IsHandleCreated && this.ribbon_0 != null)
					{
						this.ribbon_0.TextControl_0 = this;
					}
				}
			}
		}

		/// <summary>Specifies the horizontal ruler bar control to be used with a TextControl.</summary>
		[DefaultValue(null)]
		[Category("Behavior")]
		[Attribute3("PROP_RULERBAR")]
		[TypeConverter(typeof(Class426))]
		public RulerBar RulerBar
		{
			get
			{
				return this.rulerBar_0;
			}
			set
			{
				if (this.rulerBar_0 != null)
				{
					this.rulerBar_0.Disposed -= rulerBar_0_Disposed;
					if (value == null)
					{
						this.method_32(this.rulerBar_0);
					}
				}
				this.rulerBar_0 = value;
				if (this.rulerBar_0 != null)
				{
					if (this.Focused)
					{
						this.method_31(this.rulerBar_0);
					}
					this.rulerBar_0.Disposed += rulerBar_0_Disposed;
					this.rulerBar_0.ButtonBar_0 = this.buttonBar_0;
				}
			}
		}

		/// <summary>Gets or sets a value indicating whether a Text Control has horizontal or vertical scroll bars.</summary>
		[Category("Appearance")]
		[DefaultValue(ScrollBars.Both)]
		[Attribute3("PROP_SCROLLBARS")]
		public ScrollBars ScrollBars
		{
			get
			{
				return this.scrollBars_0;
			}
			set
			{
				this.scrollBars_0 = value;
				if (base.IsHandleCreated)
				{
					this.textControlCore_0.method_30(Enum83.const_227, this.Int32_0, (int)this.viewMode_0);
				}
			}
		}

		/// <summary>Gets or sets the coordinates, in twips, of the upper-left corner of the document's visible part relative to the upper-left corner of the complete document.</summary>
		[Browsable(false)]
		public Point ScrollLocation
		{
			get
			{
				Point result = new Point(0, 0);
				if (base.IsHandleCreated)
				{
					result.X = this.textControlCore_0.method_30(Enum83.const_53, 1, 0);
					result.Y = this.textControlCore_0.method_30(Enum83.const_53, 2, 0);
				}
				return result;
			}
			set
			{
				if (base.IsHandleCreated)
				{
					this.textControlCore_0.method_30(Enum83.const_43, 1, value.X);
					this.textControlCore_0.method_30(Enum83.const_43, 2, value.Y);
				}
			}
		}

		/// <summary>Gets a collection of all sections in the document.</summary>
		[Browsable(false)]
		public SectionCollection Sections
		{
			get
			{
				
				if (base.IsHandleCreated)
				{
					return new SectionCollection(this.textControlCore_0);
				}
				return null;
			}
		}

		/// <summary>Gets or sets the current selection in the text part with the input focus.</summary>
		[Browsable(false)]
		public Selection Selection
		{
			get
			{
				Selection result = null;
				if (base.IsHandleCreated)
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

		/// <summary>Specifies whether text selections are displayed with a transparent bitmap or through inverting the text.</summary>
		[DefaultValue(SelectionViewMode.TransparentBitmap)]
		[Category("Appearance")]
		[Attribute3("PROP_SELECTIONVIEWMODE")]
		public SelectionViewMode SelectionViewMode
		{
			get
			{
				return this.selectionViewMode_0;
			}
			set
			{
				this.selectionViewMode_0 = value;
				if (base.IsHandleCreated)
				{
					this.textControlCore_0.method_30(Enum83.const_40, (this.selectionViewMode_0 == SelectionViewMode.TransparentBitmap) ? 65536 : int.MinValue, 0);
				}
			}
		}

		/// <summary>Gets or sets a value controlling the selection of objects which are inserted behind the text.</summary>
		[Category("Appearance")]
		[Attribute3("PROP_SELECTOBJECTS")]
		[DefaultValue(false)]
		public bool SelectObjects
		{
			get
			{
				if (base.IsHandleCreated)
				{
					int[] array = new int[1];
					int[] array2 = array;
					this.textControlCore_0.method_41(Enum83.const_25, 0, array2);
					this.bool_17 = (array2[0] & 4) != 0;
				}
				return this.bool_17;
			}
			set
			{
				if (this.bool_17 != value)
				{
					this.bool_17 = value;
					if (base.IsHandleCreated)
					{
						this.textControlCore_0.method_30(Enum83.const_40, 0, this.bool_17 ? 4 : 8192);
					}
				}
			}
		}

		/// <summary>Gets or sets a value indicating whether a mini toolbar is shown.</summary>
		[DefaultValue(MiniToolbarButton.None)]
		[Attribute3("PROP_SHOWMINITOOLBAR")]
		[Category("Appearance")]
		public MiniToolbarButton ShowMiniToolbar
		{
			get
			{
				if (base.IsHandleCreated)
				{
					int[] array = new int[1];
					int[] array2 = array;
					this.textControlCore_0.method_41(Enum83.const_25, 0, array2);
					this.miniToolbarButton_0 = (MiniToolbarButton)(array2[0] & 0x1018);
				}
				return this.miniToolbarButton_0;
			}
			set
			{
				value &= MiniToolbarButton.LeftButton | MiniToolbarButton.RightButton | MiniToolbarButton.None;
				if ((value & MiniToolbarButton.None) != 0)
				{
					value = MiniToolbarButton.None;
				}
				if (this.miniToolbarButton_0 != value)
				{
					this.miniToolbarButton_0 = value;
					if (base.IsHandleCreated)
					{
						this.textControlCore_0.method_30(Enum83.const_40, 0, (int)this.miniToolbarButton_0);
						this.method_40();
					}
				}
			}
		}

		/// <summary>Specifies the spell checking component to be used with a TextControl.</summary>
		[DefaultValue(null)]
		[Attribute3("PROP_SPELLCHECKER")]
		[Category("Behavior")]
		[TypeConverter(typeof(Class424))]
		public Component SpellChecker
		{
			get
			{
				return this.component_0;
			}
			set
			{
				if (value == null)
				{
					this.class415_0 = null;
					this.class589_0.Class415_0 = null;
				}
				else
				{
					if (!(value.GetType().Name == "TXSpellChecker") || !(value.GetType().Namespace == "TXTextControl.Proofing"))
					{
						throw new ArgumentException(this.resources.GetString("ERR_INVALIDTXSPELLCHECKER"));
					}
					this.class589_0.TextControl_0 = this;
					this.class415_0 = new Class415(value);
					this.class589_0.Class415_0 = this.class415_0;
					if (base.IsHandleCreated)
					{
						this.class415_0.method_4();
					}
				}
				this.component_0 = value;
			}
		}

		/// <summary>Specifies the context menu which is used when the end-user right-clicks a misspelled word.</summary>
		[Category("Behavior")]
		[Attribute3("PROP_SPELLCONTEXTMENU")]
		[DefaultValue("(Default)")]
		[TypeConverter(typeof(Class575))]
		public string SpellCheckContextMenuStrip
		{
			get
			{
				return this.class589_0.String_0;
			}
			set
			{
				this.class589_0.String_0 = value;
			}
		}

		/// <summary>Specifies the status bar control to be used with a TextControl.</summary>
		[TypeConverter(typeof(Class427))]
		[Category("Behavior")]
		[Attribute3("PROP_STATUSBAR")]
		[DefaultValue(null)]
		public StatusBar StatusBar
		{
			get
			{
				return this.statusBar_0;
			}
			set
			{
				if (value == null)
				{
					this.method_32(this.statusBar_0);
				}
				this.statusBar_0 = value;
				if (this.Focused)
				{
					this.method_31(this.statusBar_0);
				}
			}
		}

		/// <summary>Gets a collection of all subtextparts contained in the text part with the input focus.</summary>
		[Browsable(false)]
		public SubTextPartCollection SubTextParts
		{
			get
			{
				
				if (base.IsHandleCreated)
				{
					return new SubTextPartCollection(this.textControlCore_0, TextPart.Auto);
				}
				return null;
			}
		}

		/// <summary>Gets a collection of all tables contained in the text part with the input focus.</summary>
		[Browsable(false)]
		public TableCollection Tables
		{
			get
			{
				if (base.IsHandleCreated)
				{
					return new TableCollection(this.textControlCore_0, TextPart.Auto);
				}
				return null;
			}
		}

		/// <summary>Gets a collection of all tables of contents in the text part with the input focus.</summary>
		[Browsable(false)]
		public TableOfContentsCollection TablesOfContents
		{
			get
			{
				
				if (base.IsHandleCreated)
				{
					return new TableOfContentsCollection(this.textControlCore_0, TextPart.Auto);
				}
				return null;
			}
		}

		/// <summary>Gets or sets the background color for the text.</summary>
		[Attribute3("PROP_TEXTBACKCOLOR")]
		[Category("Appearance")]
		[RefreshProperties(RefreshProperties.Repaint)]
		public Color TextBackColor
		{
			get
			{
				if (!this.bool_18)
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
					this.bool_18 = this.color_2 == this.BackColor;
					if (base.IsHandleCreated)
					{
						int[] array = new int[2]
						{
							0,
							Class429.smethod_0(value)
						};
						this.textControlCore_0.method_12(TextPart.Auto);
						this.textControlCore_0.method_40(TextPart.Auto, 1168, (value == this.BackColor) ? 16 : ((value == SystemColors.Window) ? 4 : 8), array);
						this.textControlCore_0.method_15(TextPart.Auto);
					}
				}
			}
		}

		/// <summary>Gets a collection of all characters contained in the text part with the input focus.</summary>
		[Browsable(false)]
		public TextCharCollection TextChars
		{
			get
			{
				if (base.IsHandleCreated)
				{
					return new TextCharCollection(this.textControlCore_0, TextPart.Auto);
				}
				return null;
			}
		}

		/// <summary>Gets a collection of all standard text fields contained in the text part with the input focus.</summary>
		[Browsable(false)]
		public TextFieldCollection TextFields
		{
			get
			{
				if (base.IsHandleCreated)
				{
					return new TextFieldCollection(this.textControlCore_0, TextPart.Auto);
				}
				return null;
			}
		}

		/// <summary>Gets a collection of all text frames contained in the text part with the input focus.</summary>
		[Browsable(false)]
		public TextFrameCollection TextFrames
		{
			get
			{
				
				if (base.IsHandleCreated)
				{
					return new TextFrameCollection(this.textControlCore_0, TextPart.Auto);
				}
				return null;
			}
		}

		/// <summary>Gets a collection of all main text parts the current document contains.</summary>
		[Browsable(false)]
		public TextPartCollection TextParts
		{
			get
			{
				
				if (base.IsHandleCreated)
				{
					return new TextPartCollection(this.textControlCore_0, this);
				}
				return null;
			}
		}

		/// <summary>Specifies whether text frames that have no border line are shown with marker lines.</summary>
		[DefaultValue(true)]
		[Category("Appearance")]
		[Attribute3("PROP_MARKERLINES")]
		public bool TextFrameMarkerLines
		{
			get
			{
				if (base.IsHandleCreated)
				{
					Enum90 @enum = (Enum90)this.textControlCore_0.method_30(Enum83.const_6, 0, 0);
					this.bool_19 = (@enum & Enum90.const_26) != 0;
				}
				return this.bool_19;
			}
			set
			{
				if (this.bool_19 != value)
				{
					this.bool_19 = value;
					if (base.IsHandleCreated)
					{
						this.textControlCore_0.method_30(Enum83.const_30, this.bool_19 ? 536870912 : 262144, 0);
					}
				}
			}
		}

		/// <summary>Gets a collection of all changes made in the active part of the document.</summary>
		[Browsable(false)]
		public TrackedChangeCollection TrackedChanges
		{
			get
			{
				
				if (base.IsHandleCreated)
				{
					return new TrackedChangeCollection(this.textControlCore_0, TextPart.Auto);
				}
				return null;
			}
		}

		/// <summary>Gets a string that represents the name of the action that will be performed when a call to the Undo method is made.</summary>
		[Browsable(false)]
		public string UndoActionName
		{
			get
			{
				string result = null;
				if (base.IsHandleCreated)
				{
					TxUndoAction txUndoAction = (TxUndoAction)Class429.smethod_5(this.textControlCore_0.method_29(TextPart.Auto, 2031, 0, 0));
					switch (txUndoAction)
					{
					case TxUndoAction.UNDO_USERNAME:
					{
						IntPtr intPtr = this.textControlCore_0.method_64(TextPart.Auto, Enum83.const_313, 1u, 0);
						if (intPtr != IntPtr.Zero)
						{
							result = Marshal.PtrToStringBSTR(intPtr);
							Marshal.FreeBSTR(intPtr);
						}
						break;
					}
					default:
						result = this.resources.GetString(txUndoAction.ToString());
						break;
					case (TxUndoAction)0:
						break;
					}
				}
				return result;
			}
		}

		/// <summary>Gets or sets a list of names specifying users who have access to editable regions.</summary>
		[Attribute3("PROP_USERNAMES")]
		[Category("Behavior")]
		public string[] UserNames
		{
			get
			{
				return this.string_2;
			}
			set
			{
				this.string_2 = value;
				if (base.IsHandleCreated)
				{
					this.textControlCore_0.method_3(this.string_2);
					if (this.editMode_0 == EditMode.ReadAndSelect)
					{
						this.method_25();
					}
				}
			}
		}

		/// <summary>Specifies the vertical ruler bar control to be used with a TextControl.</summary>
		[Category("Behavior")]
		[TypeConverter(typeof(Class426))]
		[Attribute3("PROP_VERTRULERBAR")]
		[DefaultValue(null)]
		public RulerBar VerticalRulerBar
		{
			get
			{
				return this.rulerBar_1;
			}
			set
			{
				if (value == null)
				{
					this.method_32(this.rulerBar_1);
				}
				this.rulerBar_1 = value;
				if (this.Focused)
				{
					this.method_31(this.rulerBar_1);
				}
			}
		}

		/// <summary>Gets or sets the mode how Text Control displays a document.</summary>
		[Category("Appearance")]
		[Attribute3("PROP_VIEWMODE")]
		[DefaultValue(ViewMode.PageView)]
		public ViewMode ViewMode
		{
			get
			{
				return this.viewMode_0;
			}
			set
			{
				if (this.viewMode_0 != value)
				{
					if (base.IsHandleCreated)
					{
						this.method_30(this.color_0, value);
						this.viewMode_0 = value;
						this.textControlCore_0.method_30(Enum83.const_227, this.Int32_0, (int)this.viewMode_0);
						base.SetStyle(ControlStyles.ResizeRedraw, (this.viewMode_0 == ViewMode.FloatingText || this.viewMode_0 == ViewMode.SimpleControl) ? true : false);
					}
					else
					{
						this.viewMode_0 = value;
					}
				}
			}
		}

		/// <summary>Gets or sets a value specifying whether Text Control operates in an edit mode that validates the XML document according to the document's DTD.</summary>
		[DefaultValue(XmlEditMode.NoValidate)]
		[Browsable(false)]
		public XmlEditMode XmlEditMode
		{
			get
			{
				return (XmlEditMode)this.textControlCore_0.method_30(Enum83.const_202, 0, 0);
			}
			set
			{
				this.textControlCore_0.method_30(Enum83.const_203, (int)value, 0);
			}
		}

		/// <summary>Gets or sets the zoom factor, in percent, for a Text Control.</summary>
		[DefaultValue(100)]
		[Attribute3("PROP_ZOOMFACTOR")]
		[Category("Behavior")]
		public int ZoomFactor
		{
			get
			{
				if (base.IsHandleCreated)
				{
					this.int_3 = this.textControlCore_0.method_30(Enum83.const_22, 0, 0);
				}
				return this.int_3;
			}
			set
			{
				if ((this.viewMode_0 != ViewMode.PageView && this.viewMode_0 != ViewMode.Normal) || (value >= 10 && value <= 65535))
				{
					if ((this.viewMode_0 != ViewMode.FloatingText && this.viewMode_0 != ViewMode.SimpleControl) || (value >= 10 && value <= 400))
					{
						this.int_3 = value;
						if (base.IsHandleCreated)
						{
							this.textControlCore_0.method_30(Enum83.const_354, value, 1);
						}
						return;
					}
					throw new ArgumentOutOfRangeException(this.resources.GetString("ERR_ZOOMVAL"));
				}
				throw new ArgumentOutOfRangeException(this.resources.GetString("ERR_ZOOMVAL2"));
			}
		}

		/// <summary>Indicates that the contents of a document have been changed.</summary>
		[Attribute3("EVENT_CHANGED")]
		[Category("Behavior")]
		public event EventHandler Changed
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

		/// <summary>Occurs after one or more formatting styles have been added or removed or if the name of an existing style has been changed.</summary>
		[Attribute3("EVENT_FORMATTINGSTYLELISTCHANGED")]
		[Category("Behavior")]
		public event EventHandler FormattingStyleListChanged
		{
			add
			{
				EventHandler eventHandler = this.eventHandler_2;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange(ref this.eventHandler_2, value2, eventHandler2);
				}
				while ((object)eventHandler != eventHandler2);
			}
			remove
			{
				EventHandler eventHandler = this.eventHandler_2;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange(ref this.eventHandler_2, value2, eventHandler2);
				}
				while ((object)eventHandler != eventHandler2);
			}
		}

		/// <summary>Occurs after the text input position has been moved to a text part formatted with another style.</summary>
		[Category("Behavior")]
		[Attribute3("EVENT_INPUTFORMATTINGSTYLECHANGED")]
		public event EventHandler InputFormattingStyleChanged
		{
			add
			{
				EventHandler eventHandler = this.eventHandler_3;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange(ref this.eventHandler_3, value2, eventHandler2);
				}
				while ((object)eventHandler != eventHandler2);
			}
			remove
			{
				EventHandler eventHandler = this.eventHandler_3;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange(ref this.eventHandler_3, value2, eventHandler2);
				}
				while ((object)eventHandler != eventHandler2);
			}
		}

		/// <summary>Occurs after formatting attributes of one or more formatting styles have been changed.</summary>
		[Category("Behavior")]
		[Attribute3("EVENT_FORMATTINGSTYLECHANGED")]
		public event EventHandler FormattingStyleChanged
		{
			add
			{
				EventHandler eventHandler = this.eventHandler_4;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange(ref this.eventHandler_4, value2, eventHandler2);
				}
				while ((object)eventHandler != eventHandler2);
			}
			remove
			{
				EventHandler eventHandler = this.eventHandler_4;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange(ref this.eventHandler_4, value2, eventHandler2);
				}
				while ((object)eventHandler != eventHandler2);
			}
		}

		/// <summary>Occurs when the text input position has been changed.</summary>
		[Attribute3("EVENT_INPUTPOSITIONCHANGED")]
		[Category("Behavior")]
		public event EventHandler InputPositionChanged
		{
			add
			{
				EventHandler eventHandler = this.eventHandler_5;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange(ref this.eventHandler_5, value2, eventHandler2);
				}
				while ((object)eventHandler != eventHandler2);
			}
			remove
			{
				EventHandler eventHandler = this.eventHandler_5;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange(ref this.eventHandler_5, value2, eventHandler2);
				}
				while ((object)eventHandler != eventHandler2);
			}
		}

		/// <summary>Occurs when the text input position has been moved to another paragraph.</summary>
		[Category("Behavior")]
		[Attribute3("EVENT_INPUTPARAGRAPHCHANGED")]
		public event EventHandler InputParagraphChanged
		{
			add
			{
				EventHandler eventHandler = this.eventHandler_6;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange(ref this.eventHandler_6, value2, eventHandler2);
				}
				while ((object)eventHandler != eventHandler2);
			}
			remove
			{
				EventHandler eventHandler = this.eventHandler_6;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange(ref this.eventHandler_6, value2, eventHandler2);
				}
				while ((object)eventHandler != eventHandler2);
			}
		}

		/// <summary>Occurs when the horizontal scroll position has been changed.</summary>
		[Category("Behavior")]
		[Attribute3("EVENT_HSCROLL")]
		public event EventHandler HScroll
		{
			add
			{
				EventHandler eventHandler = this.eventHandler_7;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange(ref this.eventHandler_7, value2, eventHandler2);
				}
				while ((object)eventHandler != eventHandler2);
			}
			remove
			{
				EventHandler eventHandler = this.eventHandler_7;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange(ref this.eventHandler_7, value2, eventHandler2);
				}
				while ((object)eventHandler != eventHandler2);
			}
		}

		/// <summary>Occurs when the vertical scroll position has been changed.</summary>
		[Category("Behavior")]
		[Attribute3("EVENT_VSCROLL")]
		public event EventHandler VScroll
		{
			add
			{
				EventHandler eventHandler = this.eventHandler_8;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange(ref this.eventHandler_8, value2, eventHandler2);
				}
				while ((object)eventHandler != eventHandler2);
			}
			remove
			{
				EventHandler eventHandler = this.eventHandler_8;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange(ref this.eventHandler_8, value2, eventHandler2);
				}
				while ((object)eventHandler != eventHandler2);
			}
		}

		/// <summary>Occurs when the Text Control has been zoomed.</summary>
		[Attribute3("EVENT_ZOOMED")]
		[Category("Action")]
		public event EventHandler Zoomed
		{
			add
			{
				EventHandler eventHandler = this.eventHandler_9;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange(ref this.eventHandler_9, value2, eventHandler2);
				}
				while ((object)eventHandler != eventHandler2);
			}
			remove
			{
				EventHandler eventHandler = this.eventHandler_9;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange(ref this.eventHandler_9, value2, eventHandler2);
				}
				while ((object)eventHandler != eventHandler2);
			}
		}

		/// <summary>Occurs when the character formatting attributes either of the selected characters or the current text input position have been changed.</summary>
		[Attribute3("EVENT_CHARFORMATCHANGED")]
		[Category("Format")]
		public event EventHandler CharFormatChanged
		{
			add
			{
				EventHandler eventHandler = this.eventHandler_10;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange(ref this.eventHandler_10, value2, eventHandler2);
				}
				while ((object)eventHandler != eventHandler2);
			}
			remove
			{
				EventHandler eventHandler = this.eventHandler_10;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange(ref this.eventHandler_10, value2, eventHandler2);
				}
				while ((object)eventHandler != eventHandler2);
			}
		}

		/// <summary>Occurs when the formatting attributes of the selected paragraphs have been changed.</summary>
		[Category("Format")]
		[Attribute3("EVENT_PARAGRAPHFORMATCHANGED")]
		public event EventHandler ParagraphFormatChanged
		{
			add
			{
				EventHandler eventHandler = this.eventHandler_11;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange(ref this.eventHandler_11, value2, eventHandler2);
				}
				while ((object)eventHandler != eventHandler2);
			}
			remove
			{
				EventHandler eventHandler = this.eventHandler_11;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange(ref this.eventHandler_11, value2, eventHandler2);
				}
				while ((object)eventHandler != eventHandler2);
			}
		}

		/// <summary>Occurs when the page format settings have been changed.</summary>
		[Attribute3("EVENT_PAGEFORMATCHANGED")]
		[Category("Format")]
		public event EventHandler PageFormatChanged
		{
			add
			{
				EventHandler eventHandler = this.eventHandler_12;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange(ref this.eventHandler_12, value2, eventHandler2);
				}
				while ((object)eventHandler != eventHandler2);
			}
			remove
			{
				EventHandler eventHandler = this.eventHandler_12;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange(ref this.eventHandler_12, value2, eventHandler2);
				}
				while ((object)eventHandler != eventHandler2);
			}
		}

		/// <summary>Occurs when the Text Control has automatically expanded its size horizontally.</summary>
		[Category("Behavior")]
		[Attribute3("EVENT_HEXPANDED")]
		public event EventHandler HExpanded
		{
			add
			{
				EventHandler eventHandler = this.eventHandler_13;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange(ref this.eventHandler_13, value2, eventHandler2);
				}
				while ((object)eventHandler != eventHandler2);
			}
			remove
			{
				EventHandler eventHandler = this.eventHandler_13;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange(ref this.eventHandler_13, value2, eventHandler2);
				}
				while ((object)eventHandler != eventHandler2);
			}
		}

		/// <summary>Occurs when the Text Control has automatically expanded its size vertically.</summary>
		[Category("Behavior")]
		[Attribute3("EVENT_VEXPANDED")]
		public event EventHandler VExpanded
		{
			add
			{
				EventHandler eventHandler = this.eventHandler_14;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange(ref this.eventHandler_14, value2, eventHandler2);
				}
				while ((object)eventHandler != eventHandler2);
			}
			remove
			{
				EventHandler eventHandler = this.eventHandler_14;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange(ref this.eventHandler_14, value2, eventHandler2);
				}
				while ((object)eventHandler != eventHandler2);
			}
		}

		/// <summary>Occurs when the Text Control has automatically shrunk its size horizontally.</summary>
		[Category("Behavior")]
		[Attribute3("EVENT_HSHRUNK")]
		public event EventHandler HShrunk
		{
			add
			{
				EventHandler eventHandler = this.eventHandler_15;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange(ref this.eventHandler_15, value2, eventHandler2);
				}
				while ((object)eventHandler != eventHandler2);
			}
			remove
			{
				EventHandler eventHandler = this.eventHandler_15;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange(ref this.eventHandler_15, value2, eventHandler2);
				}
				while ((object)eventHandler != eventHandler2);
			}
		}

		/// <summary>Occurs when the Text Control has automatically shrunk its size vertically.</summary>
		[Attribute3("EVENT_VSHRUNK")]
		[Category("Behavior")]
		public event EventHandler VShrunk
		{
			add
			{
				EventHandler eventHandler = this.eventHandler_16;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange(ref this.eventHandler_16, value2, eventHandler2);
				}
				while ((object)eventHandler != eventHandler2);
			}
			remove
			{
				EventHandler eventHandler = this.eventHandler_16;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange(ref this.eventHandler_16, value2, eventHandler2);
				}
				while ((object)eventHandler != eventHandler2);
			}
		}

		/// <summary>Occurs when the value of the AcceptsTab property has changed.</summary>
		[Category("Behavior")]
		[Attribute3("EVENT_ACCEPTSTABCHANGED")]
		public event EventHandler AcceptsTabChanged
		{
			add
			{
				EventHandler eventHandler = this.eventHandler_17;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange(ref this.eventHandler_17, value2, eventHandler2);
				}
				while ((object)eventHandler != eventHandler2);
			}
			remove
			{
				EventHandler eventHandler = this.eventHandler_17;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange(ref this.eventHandler_17, value2, eventHandler2);
				}
				while ((object)eventHandler != eventHandler2);
			}
		}

		/// <summary>Occurs when the value of the BorderStyle property has changed.</summary>
		[Attribute3("EVENT_BORDERSTYLECHANGED")]
		[Category("Appearance")]
		public event EventHandler BorderStyleChanged
		{
			add
			{
				EventHandler eventHandler = this.eventHandler_18;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange(ref this.eventHandler_18, value2, eventHandler2);
				}
				while ((object)eventHandler != eventHandler2);
			}
			remove
			{
				EventHandler eventHandler = this.eventHandler_18;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange(ref this.eventHandler_18, value2, eventHandler2);
				}
				while ((object)eventHandler != eventHandler2);
			}
		}

		/// <summary>Occurs when the text input position has been moved to another page.</summary>
		[Attribute3("EVENT_PAGECHANGED")]
		[Category("Behavior")]
		public event EventHandler PageChanged
		{
			add
			{
				EventHandler eventHandler = this.eventHandler_19;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange(ref this.eventHandler_19, value2, eventHandler2);
				}
				while ((object)eventHandler != eventHandler2);
			}
			remove
			{
				EventHandler eventHandler = this.eventHandler_19;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange(ref this.eventHandler_19, value2, eventHandler2);
				}
				while ((object)eventHandler != eventHandler2);
			}
		}

		/// <summary>Occurs when the text input position has been moved to another section.</summary>
		[Attribute3("EVENT_SECTIONCHANGED")]
		[Category("Behavior")]
		public event EventHandler SectionChanged
		{
			add
			{
				EventHandler eventHandler = this.eventHandler_20;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange(ref this.eventHandler_20, value2, eventHandler2);
				}
				while ((object)eventHandler != eventHandler2);
			}
			remove
			{
				EventHandler eventHandler = this.eventHandler_20;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange(ref this.eventHandler_20, value2, eventHandler2);
				}
				while ((object)eventHandler != eventHandler2);
			}
		}

		/// <summary>Occurs when a new document has been loaded.</summary>
		[Attribute3("EVENT_DOCUMENTLOADED")]
		[Category("Behavior")]
		public event EventHandler DocumentLoaded
		{
			add
			{
				EventHandler eventHandler = this.eventHandler_21;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange(ref this.eventHandler_21, value2, eventHandler2);
				}
				while ((object)eventHandler != eventHandler2);
			}
			remove
			{
				EventHandler eventHandler = this.eventHandler_21;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange(ref this.eventHandler_21, value2, eventHandler2);
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
				EventHandler eventHandler = this.eventHandler_22;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange(ref this.eventHandler_22, value2, eventHandler2);
				}
				while ((object)eventHandler != eventHandler2);
			}
			remove
			{
				EventHandler eventHandler = this.eventHandler_22;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange(ref this.eventHandler_22, value2, eventHandler2);
				}
				while ((object)eventHandler != eventHandler2);
			}
		}

		/// <summary>Occurs when the main text of the document gets the current text input position from another part of the document, such as a header, a footer or a textframe.</summary>
		[Attribute3("EVENT_MAINTEXTACTIVATED")]
		[Category("Behavior")]
		public event EventHandler MainTextActivated
		{
			add
			{
				EventHandler eventHandler = this.eventHandler_23;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange(ref this.eventHandler_23, value2, eventHandler2);
				}
				while ((object)eventHandler != eventHandler2);
			}
			remove
			{
				EventHandler eventHandler = this.eventHandler_23;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange(ref this.eventHandler_23, value2, eventHandler2);
				}
				while ((object)eventHandler != eventHandler2);
			}
		}

		internal event EventHandler FocusChanged
		{
			add
			{
				EventHandler eventHandler = this.eventHandler_24;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange(ref this.eventHandler_24, value2, eventHandler2);
				}
				while ((object)eventHandler != eventHandler2);
			}
			remove
			{
				EventHandler eventHandler = this.eventHandler_24;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange(ref this.eventHandler_24, value2, eventHandler2);
				}
				while ((object)eventHandler != eventHandler2);
			}
		}

		internal event EventHandler HeaderFooterCreated
		{
			add
			{
				EventHandler eventHandler = this.eventHandler_25;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange(ref this.eventHandler_25, value2, eventHandler2);
				}
				while ((object)eventHandler != eventHandler2);
			}
			remove
			{
				EventHandler eventHandler = this.eventHandler_25;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange(ref this.eventHandler_25, value2, eventHandler2);
				}
				while ((object)eventHandler != eventHandler2);
			}
		}

		internal event EventHandler HeaderFooterDeleted
		{
			add
			{
				EventHandler eventHandler = this.eventHandler_26;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange(ref this.eventHandler_26, value2, eventHandler2);
				}
				while ((object)eventHandler != eventHandler2);
			}
			remove
			{
				EventHandler eventHandler = this.eventHandler_26;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange(ref this.eventHandler_26, value2, eventHandler2);
				}
				while ((object)eventHandler != eventHandler2);
			}
		}

		/// <summary>Occurs immediately before a built-in context menu will be opened.</summary>
		[Attribute3("EVENT_TEXTCONTEXTMENUOPENING")]
		[Category("Behavior")]
		public event TextContextMenuEventHandler TextContextMenuOpening
		{
			add
			{
				TextContextMenuEventHandler textContextMenuEventHandler = this.textContextMenuEventHandler_0;
				TextContextMenuEventHandler textContextMenuEventHandler2;
				do
				{
					textContextMenuEventHandler2 = textContextMenuEventHandler;
					TextContextMenuEventHandler value2 = (TextContextMenuEventHandler)Delegate.Combine(textContextMenuEventHandler2, value);
					textContextMenuEventHandler = Interlocked.CompareExchange(ref this.textContextMenuEventHandler_0, value2, textContextMenuEventHandler2);
				}
				while ((object)textContextMenuEventHandler != textContextMenuEventHandler2);
			}
			remove
			{
				TextContextMenuEventHandler textContextMenuEventHandler = this.textContextMenuEventHandler_0;
				TextContextMenuEventHandler textContextMenuEventHandler2;
				do
				{
					textContextMenuEventHandler2 = textContextMenuEventHandler;
					TextContextMenuEventHandler value2 = (TextContextMenuEventHandler)Delegate.Remove(textContextMenuEventHandler2, value);
					textContextMenuEventHandler = Interlocked.CompareExchange(ref this.textContextMenuEventHandler_0, value2, textContextMenuEventHandler2);
				}
				while ((object)textContextMenuEventHandler != textContextMenuEventHandler2);
			}
		}

		/// <summary>Occurs immediately after the built-in TextMiniToolbar was initialized.</summary>
		public event MiniToolbarInitializedEventHandler TextMiniToolbarInitialized
		{
			add
			{
				MiniToolbarInitializedEventHandler miniToolbarInitializedEventHandler = this.miniToolbarInitializedEventHandler_0;
				MiniToolbarInitializedEventHandler miniToolbarInitializedEventHandler2;
				do
				{
					miniToolbarInitializedEventHandler2 = miniToolbarInitializedEventHandler;
					MiniToolbarInitializedEventHandler value2 = (MiniToolbarInitializedEventHandler)Delegate.Combine(miniToolbarInitializedEventHandler2, value);
					miniToolbarInitializedEventHandler = Interlocked.CompareExchange(ref this.miniToolbarInitializedEventHandler_0, value2, miniToolbarInitializedEventHandler2);
				}
				while ((object)miniToolbarInitializedEventHandler != miniToolbarInitializedEventHandler2);
			}
			remove
			{
				MiniToolbarInitializedEventHandler miniToolbarInitializedEventHandler = this.miniToolbarInitializedEventHandler_0;
				MiniToolbarInitializedEventHandler miniToolbarInitializedEventHandler2;
				do
				{
					miniToolbarInitializedEventHandler2 = miniToolbarInitializedEventHandler;
					MiniToolbarInitializedEventHandler value2 = (MiniToolbarInitializedEventHandler)Delegate.Remove(miniToolbarInitializedEventHandler2, value);
					miniToolbarInitializedEventHandler = Interlocked.CompareExchange(ref this.miniToolbarInitializedEventHandler_0, value2, miniToolbarInitializedEventHandler2);
				}
				while ((object)miniToolbarInitializedEventHandler != miniToolbarInitializedEventHandler2);
			}
		}

		/// <summary>Occurs immediately after the built-in ObjectMiniToolbar was initialized.</summary>
		public event MiniToolbarInitializedEventHandler ObjectMiniToolbarInitialized
		{
			add
			{
				MiniToolbarInitializedEventHandler miniToolbarInitializedEventHandler = this.miniToolbarInitializedEventHandler_1;
				MiniToolbarInitializedEventHandler miniToolbarInitializedEventHandler2;
				do
				{
					miniToolbarInitializedEventHandler2 = miniToolbarInitializedEventHandler;
					MiniToolbarInitializedEventHandler value2 = (MiniToolbarInitializedEventHandler)Delegate.Combine(miniToolbarInitializedEventHandler2, value);
					miniToolbarInitializedEventHandler = Interlocked.CompareExchange(ref this.miniToolbarInitializedEventHandler_1, value2, miniToolbarInitializedEventHandler2);
				}
				while ((object)miniToolbarInitializedEventHandler != miniToolbarInitializedEventHandler2);
			}
			remove
			{
				MiniToolbarInitializedEventHandler miniToolbarInitializedEventHandler = this.miniToolbarInitializedEventHandler_1;
				MiniToolbarInitializedEventHandler miniToolbarInitializedEventHandler2;
				do
				{
					miniToolbarInitializedEventHandler2 = miniToolbarInitializedEventHandler;
					MiniToolbarInitializedEventHandler value2 = (MiniToolbarInitializedEventHandler)Delegate.Remove(miniToolbarInitializedEventHandler2, value);
					miniToolbarInitializedEventHandler = Interlocked.CompareExchange(ref this.miniToolbarInitializedEventHandler_1, value2, miniToolbarInitializedEventHandler2);
				}
				while ((object)miniToolbarInitializedEventHandler != miniToolbarInitializedEventHandler2);
			}
		}

		/// <summary>Occurs to handle displaying context sensitive mini toolbars.</summary>
		[Category("Behavior")]
		[Attribute3("EVENT_MINITOOLBAROPENING")]
		public event MiniToolbarOpeningEventHandler MiniToolbarOpening
		{
			add
			{
				MiniToolbarOpeningEventHandler miniToolbarOpeningEventHandler = this.miniToolbarOpeningEventHandler_0;
				MiniToolbarOpeningEventHandler miniToolbarOpeningEventHandler2;
				do
				{
					miniToolbarOpeningEventHandler2 = miniToolbarOpeningEventHandler;
					MiniToolbarOpeningEventHandler value2 = (MiniToolbarOpeningEventHandler)Delegate.Combine(miniToolbarOpeningEventHandler2, value);
					miniToolbarOpeningEventHandler = Interlocked.CompareExchange(ref this.miniToolbarOpeningEventHandler_0, value2, miniToolbarOpeningEventHandler2);
				}
				while ((object)miniToolbarOpeningEventHandler != miniToolbarOpeningEventHandler2);
			}
			remove
			{
				MiniToolbarOpeningEventHandler miniToolbarOpeningEventHandler = this.miniToolbarOpeningEventHandler_0;
				MiniToolbarOpeningEventHandler miniToolbarOpeningEventHandler2;
				do
				{
					miniToolbarOpeningEventHandler2 = miniToolbarOpeningEventHandler;
					MiniToolbarOpeningEventHandler value2 = (MiniToolbarOpeningEventHandler)Delegate.Remove(miniToolbarOpeningEventHandler2, value);
					miniToolbarOpeningEventHandler = Interlocked.CompareExchange(ref this.miniToolbarOpeningEventHandler_0, value2, miniToolbarOpeningEventHandler2);
				}
				while ((object)miniToolbarOpeningEventHandler != miniToolbarOpeningEventHandler2);
			}
		}

		public event PropertyChangedEventHandler PropertyChanged
		{
			add
			{
				PropertyChangedEventHandler propertyChangedEventHandler = this.propertyChangedEventHandler_0;
				PropertyChangedEventHandler propertyChangedEventHandler2;
				do
				{
					propertyChangedEventHandler2 = propertyChangedEventHandler;
					PropertyChangedEventHandler value2 = (PropertyChangedEventHandler)Delegate.Combine(propertyChangedEventHandler2, value);
					propertyChangedEventHandler = Interlocked.CompareExchange(ref this.propertyChangedEventHandler_0, value2, propertyChangedEventHandler2);
				}
				while ((object)propertyChangedEventHandler != propertyChangedEventHandler2);
			}
			remove
			{
				PropertyChangedEventHandler propertyChangedEventHandler = this.propertyChangedEventHandler_0;
				PropertyChangedEventHandler propertyChangedEventHandler2;
				do
				{
					propertyChangedEventHandler2 = propertyChangedEventHandler;
					PropertyChangedEventHandler value2 = (PropertyChangedEventHandler)Delegate.Remove(propertyChangedEventHandler2, value);
					propertyChangedEventHandler = Interlocked.CompareExchange(ref this.propertyChangedEventHandler_0, value2, propertyChangedEventHandler2);
				}
				while ((object)propertyChangedEventHandler != propertyChangedEventHandler2);
			}
		}

		/// <summary>Occurs when a text field has been clicked on.</summary>
		[Attribute2("CAT_FIELDS")]
		[Attribute3("EVENT_FIELDCLICKED")]
		public event TextFieldEventHandler TextFieldClicked
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

		/// <summary>Occurs when a text field has been created.</summary>
		[Attribute2("CAT_FIELDS")]
		[Attribute3("EVENT_FIELDCREATED")]
		public event TextFieldEventHandler TextFieldCreated
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

		/// <summary>Occurs when a text field has been double-clicked on.</summary>
		[Attribute2("CAT_FIELDS")]
		[Attribute3("EVENT_FIELDDOUBLECLICKED")]
		public event TextFieldEventHandler TextFieldDoubleClicked
		{
			add
			{
				TextFieldEventHandler textFieldEventHandler = this.textFieldEventHandler_2;
				TextFieldEventHandler textFieldEventHandler2;
				do
				{
					textFieldEventHandler2 = textFieldEventHandler;
					TextFieldEventHandler value2 = (TextFieldEventHandler)Delegate.Combine(textFieldEventHandler2, value);
					textFieldEventHandler = Interlocked.CompareExchange(ref this.textFieldEventHandler_2, value2, textFieldEventHandler2);
				}
				while ((object)textFieldEventHandler != textFieldEventHandler2);
			}
			remove
			{
				TextFieldEventHandler textFieldEventHandler = this.textFieldEventHandler_2;
				TextFieldEventHandler textFieldEventHandler2;
				do
				{
					textFieldEventHandler2 = textFieldEventHandler;
					TextFieldEventHandler value2 = (TextFieldEventHandler)Delegate.Remove(textFieldEventHandler2, value);
					textFieldEventHandler = Interlocked.CompareExchange(ref this.textFieldEventHandler_2, value2, textFieldEventHandler2);
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
				TextFieldEventHandler textFieldEventHandler = this.textFieldEventHandler_3;
				TextFieldEventHandler textFieldEventHandler2;
				do
				{
					textFieldEventHandler2 = textFieldEventHandler;
					TextFieldEventHandler value2 = (TextFieldEventHandler)Delegate.Combine(textFieldEventHandler2, value);
					textFieldEventHandler = Interlocked.CompareExchange(ref this.textFieldEventHandler_3, value2, textFieldEventHandler2);
				}
				while ((object)textFieldEventHandler != textFieldEventHandler2);
			}
			remove
			{
				TextFieldEventHandler textFieldEventHandler = this.textFieldEventHandler_3;
				TextFieldEventHandler textFieldEventHandler2;
				do
				{
					textFieldEventHandler2 = textFieldEventHandler;
					TextFieldEventHandler value2 = (TextFieldEventHandler)Delegate.Remove(textFieldEventHandler2, value);
					textFieldEventHandler = Interlocked.CompareExchange(ref this.textFieldEventHandler_3, value2, textFieldEventHandler2);
				}
				while ((object)textFieldEventHandler != textFieldEventHandler2);
			}
		}

		/// <summary>Occurs when the text of a text field has been changed.</summary>
		[Attribute3("EVENT_FIELDCHANGED")]
		[Attribute2("CAT_FIELDS")]
		public event TextFieldEventHandler TextFieldChanged
		{
			add
			{
				TextFieldEventHandler textFieldEventHandler = this.textFieldEventHandler_4;
				TextFieldEventHandler textFieldEventHandler2;
				do
				{
					textFieldEventHandler2 = textFieldEventHandler;
					TextFieldEventHandler value2 = (TextFieldEventHandler)Delegate.Combine(textFieldEventHandler2, value);
					textFieldEventHandler = Interlocked.CompareExchange(ref this.textFieldEventHandler_4, value2, textFieldEventHandler2);
				}
				while ((object)textFieldEventHandler != textFieldEventHandler2);
			}
			remove
			{
				TextFieldEventHandler textFieldEventHandler = this.textFieldEventHandler_4;
				TextFieldEventHandler textFieldEventHandler2;
				do
				{
					textFieldEventHandler2 = textFieldEventHandler;
					TextFieldEventHandler value2 = (TextFieldEventHandler)Delegate.Remove(textFieldEventHandler2, value);
					textFieldEventHandler = Interlocked.CompareExchange(ref this.textFieldEventHandler_4, value2, textFieldEventHandler2);
				}
				while ((object)textFieldEventHandler != textFieldEventHandler2);
			}
		}

		/// <summary>Occurs when the current input position has been moved to a position that belongs to a text field.</summary>
		[Attribute2("CAT_FIELDS")]
		[Attribute3("EVENT_FIELDENTERED")]
		public event TextFieldEventHandler TextFieldEntered
		{
			add
			{
				TextFieldEventHandler textFieldEventHandler = this.textFieldEventHandler_5;
				TextFieldEventHandler textFieldEventHandler2;
				do
				{
					textFieldEventHandler2 = textFieldEventHandler;
					TextFieldEventHandler value2 = (TextFieldEventHandler)Delegate.Combine(textFieldEventHandler2, value);
					textFieldEventHandler = Interlocked.CompareExchange(ref this.textFieldEventHandler_5, value2, textFieldEventHandler2);
				}
				while ((object)textFieldEventHandler != textFieldEventHandler2);
			}
			remove
			{
				TextFieldEventHandler textFieldEventHandler = this.textFieldEventHandler_5;
				TextFieldEventHandler textFieldEventHandler2;
				do
				{
					textFieldEventHandler2 = textFieldEventHandler;
					TextFieldEventHandler value2 = (TextFieldEventHandler)Delegate.Remove(textFieldEventHandler2, value);
					textFieldEventHandler = Interlocked.CompareExchange(ref this.textFieldEventHandler_5, value2, textFieldEventHandler2);
				}
				while ((object)textFieldEventHandler != textFieldEventHandler2);
			}
		}

		/// <summary>Occurs when the current input position has left a text field.</summary>
		[Attribute2("CAT_FIELDS")]
		[Attribute3("EVENT_FIELDLEFT")]
		public event TextFieldEventHandler TextFieldLeft
		{
			add
			{
				TextFieldEventHandler textFieldEventHandler = this.textFieldEventHandler_6;
				TextFieldEventHandler textFieldEventHandler2;
				do
				{
					textFieldEventHandler2 = textFieldEventHandler;
					TextFieldEventHandler value2 = (TextFieldEventHandler)Delegate.Combine(textFieldEventHandler2, value);
					textFieldEventHandler = Interlocked.CompareExchange(ref this.textFieldEventHandler_6, value2, textFieldEventHandler2);
				}
				while ((object)textFieldEventHandler != textFieldEventHandler2);
			}
			remove
			{
				TextFieldEventHandler textFieldEventHandler = this.textFieldEventHandler_6;
				TextFieldEventHandler textFieldEventHandler2;
				do
				{
					textFieldEventHandler2 = textFieldEventHandler;
					TextFieldEventHandler value2 = (TextFieldEventHandler)Delegate.Remove(textFieldEventHandler2, value);
					textFieldEventHandler = Interlocked.CompareExchange(ref this.textFieldEventHandler_6, value2, textFieldEventHandler2);
				}
				while ((object)textFieldEventHandler != textFieldEventHandler2);
			}
		}

		/// <summary>Occurs when the checkmark of a CheckFormField has been changed from checked to unchecked or vice versa.</summary>
		[Attribute2("CAT_FIELDS")]
		[Attribute3("EVENT_FORMFIELDCHECKCHANGED")]
		public event CheckFormFieldEventHandler FormFieldCheckChanged
		{
			add
			{
				CheckFormFieldEventHandler checkFormFieldEventHandler = this.checkFormFieldEventHandler_0;
				CheckFormFieldEventHandler checkFormFieldEventHandler2;
				do
				{
					checkFormFieldEventHandler2 = checkFormFieldEventHandler;
					CheckFormFieldEventHandler value2 = (CheckFormFieldEventHandler)Delegate.Combine(checkFormFieldEventHandler2, value);
					checkFormFieldEventHandler = Interlocked.CompareExchange(ref this.checkFormFieldEventHandler_0, value2, checkFormFieldEventHandler2);
				}
				while ((object)checkFormFieldEventHandler != checkFormFieldEventHandler2);
			}
			remove
			{
				CheckFormFieldEventHandler checkFormFieldEventHandler = this.checkFormFieldEventHandler_0;
				CheckFormFieldEventHandler checkFormFieldEventHandler2;
				do
				{
					checkFormFieldEventHandler2 = checkFormFieldEventHandler;
					CheckFormFieldEventHandler value2 = (CheckFormFieldEventHandler)Delegate.Remove(checkFormFieldEventHandler2, value);
					checkFormFieldEventHandler = Interlocked.CompareExchange(ref this.checkFormFieldEventHandler_0, value2, checkFormFieldEventHandler2);
				}
				while ((object)checkFormFieldEventHandler != checkFormFieldEventHandler2);
			}
		}

		/// <summary>Occurs when the date of a DateFormField has been changed.</summary>
		[Attribute3("EVENT_FORMFIELDDATECHANGED")]
		[Attribute2("CAT_FIELDS")]
		public event DateFormFieldEventHandler FormFieldDateChanged
		{
			add
			{
				DateFormFieldEventHandler dateFormFieldEventHandler = this.dateFormFieldEventHandler_0;
				DateFormFieldEventHandler dateFormFieldEventHandler2;
				do
				{
					dateFormFieldEventHandler2 = dateFormFieldEventHandler;
					DateFormFieldEventHandler value2 = (DateFormFieldEventHandler)Delegate.Combine(dateFormFieldEventHandler2, value);
					dateFormFieldEventHandler = Interlocked.CompareExchange(ref this.dateFormFieldEventHandler_0, value2, dateFormFieldEventHandler2);
				}
				while ((object)dateFormFieldEventHandler != dateFormFieldEventHandler2);
			}
			remove
			{
				DateFormFieldEventHandler dateFormFieldEventHandler = this.dateFormFieldEventHandler_0;
				DateFormFieldEventHandler dateFormFieldEventHandler2;
				do
				{
					dateFormFieldEventHandler2 = dateFormFieldEventHandler;
					DateFormFieldEventHandler value2 = (DateFormFieldEventHandler)Delegate.Remove(dateFormFieldEventHandler2, value);
					dateFormFieldEventHandler = Interlocked.CompareExchange(ref this.dateFormFieldEventHandler_0, value2, dateFormFieldEventHandler2);
				}
				while ((object)dateFormFieldEventHandler != dateFormFieldEventHandler2);
			}
		}

		/// <summary>Occurs when the selected item of a SelectionFormField has been changed.</summary>
		[Attribute3("EVENT_FORMFIELDSELECTIONCHANGED")]
		[Attribute2("CAT_FIELDS")]
		public event SelectionFormFieldEventHandler FormFieldSelectionChanged
		{
			add
			{
				SelectionFormFieldEventHandler selectionFormFieldEventHandler = this.selectionFormFieldEventHandler_0;
				SelectionFormFieldEventHandler selectionFormFieldEventHandler2;
				do
				{
					selectionFormFieldEventHandler2 = selectionFormFieldEventHandler;
					SelectionFormFieldEventHandler value2 = (SelectionFormFieldEventHandler)Delegate.Combine(selectionFormFieldEventHandler2, value);
					selectionFormFieldEventHandler = Interlocked.CompareExchange(ref this.selectionFormFieldEventHandler_0, value2, selectionFormFieldEventHandler2);
				}
				while ((object)selectionFormFieldEventHandler != selectionFormFieldEventHandler2);
			}
			remove
			{
				SelectionFormFieldEventHandler selectionFormFieldEventHandler = this.selectionFormFieldEventHandler_0;
				SelectionFormFieldEventHandler selectionFormFieldEventHandler2;
				do
				{
					selectionFormFieldEventHandler2 = selectionFormFieldEventHandler;
					SelectionFormFieldEventHandler value2 = (SelectionFormFieldEventHandler)Delegate.Remove(selectionFormFieldEventHandler2, value);
					selectionFormFieldEventHandler = Interlocked.CompareExchange(ref this.selectionFormFieldEventHandler_0, value2, selectionFormFieldEventHandler2);
				}
				while ((object)selectionFormFieldEventHandler != selectionFormFieldEventHandler2);
			}
		}

		/// <summary>Occurs when the text of a TextFormField has been changed.</summary>
		[Attribute3("EVENT_FORMFIELDTEXTCHANGED")]
		[Attribute2("CAT_FIELDS")]
		public event TextFormFieldEventHandler FormFieldTextChanged
		{
			add
			{
				TextFormFieldEventHandler textFormFieldEventHandler = this.textFormFieldEventHandler_0;
				TextFormFieldEventHandler textFormFieldEventHandler2;
				do
				{
					textFormFieldEventHandler2 = textFormFieldEventHandler;
					TextFormFieldEventHandler value2 = (TextFormFieldEventHandler)Delegate.Combine(textFormFieldEventHandler2, value);
					textFormFieldEventHandler = Interlocked.CompareExchange(ref this.textFormFieldEventHandler_0, value2, textFormFieldEventHandler2);
				}
				while ((object)textFormFieldEventHandler != textFormFieldEventHandler2);
			}
			remove
			{
				TextFormFieldEventHandler textFormFieldEventHandler = this.textFormFieldEventHandler_0;
				TextFormFieldEventHandler textFormFieldEventHandler2;
				do
				{
					textFormFieldEventHandler2 = textFormFieldEventHandler;
					TextFormFieldEventHandler value2 = (TextFormFieldEventHandler)Delegate.Remove(textFormFieldEventHandler2, value);
					textFormFieldEventHandler = Interlocked.CompareExchange(ref this.textFormFieldEventHandler_0, value2, textFormFieldEventHandler2);
				}
				while ((object)textFormFieldEventHandler != textFormFieldEventHandler2);
			}
		}

		/// <summary>Occurs when a text field has been clicked on that represents the source of a hypertext link.</summary>
		[Attribute3("EVENT_HYPERTEXTLINKCLICKED")]
		[Attribute2("CAT_FIELDS")]
		public event HypertextLinkEventHandler HypertextLinkClicked
		{
			add
			{
				HypertextLinkEventHandler hypertextLinkEventHandler = this.hypertextLinkEventHandler_0;
				HypertextLinkEventHandler hypertextLinkEventHandler2;
				do
				{
					hypertextLinkEventHandler2 = hypertextLinkEventHandler;
					HypertextLinkEventHandler value2 = (HypertextLinkEventHandler)Delegate.Combine(hypertextLinkEventHandler2, value);
					hypertextLinkEventHandler = Interlocked.CompareExchange(ref this.hypertextLinkEventHandler_0, value2, hypertextLinkEventHandler2);
				}
				while ((object)hypertextLinkEventHandler != hypertextLinkEventHandler2);
			}
			remove
			{
				HypertextLinkEventHandler hypertextLinkEventHandler = this.hypertextLinkEventHandler_0;
				HypertextLinkEventHandler hypertextLinkEventHandler2;
				do
				{
					hypertextLinkEventHandler2 = hypertextLinkEventHandler;
					HypertextLinkEventHandler value2 = (HypertextLinkEventHandler)Delegate.Remove(hypertextLinkEventHandler2, value);
					hypertextLinkEventHandler = Interlocked.CompareExchange(ref this.hypertextLinkEventHandler_0, value2, hypertextLinkEventHandler2);
				}
				while ((object)hypertextLinkEventHandler != hypertextLinkEventHandler2);
			}
		}

		/// <summary>Occurs when a text field has been clicked on that represents a link to a target in the document.</summary>
		[Attribute3("EVENT_DOCUMENTLINKCLICKED")]
		[Attribute2("CAT_FIELDS")]
		public event DocumentLinkEventHandler DocumentLinkClicked
		{
			add
			{
				DocumentLinkEventHandler documentLinkEventHandler = this.documentLinkEventHandler_0;
				DocumentLinkEventHandler documentLinkEventHandler2;
				do
				{
					documentLinkEventHandler2 = documentLinkEventHandler;
					DocumentLinkEventHandler value2 = (DocumentLinkEventHandler)Delegate.Combine(documentLinkEventHandler2, value);
					documentLinkEventHandler = Interlocked.CompareExchange(ref this.documentLinkEventHandler_0, value2, documentLinkEventHandler2);
				}
				while ((object)documentLinkEventHandler != documentLinkEventHandler2);
			}
			remove
			{
				DocumentLinkEventHandler documentLinkEventHandler = this.documentLinkEventHandler_0;
				DocumentLinkEventHandler documentLinkEventHandler2;
				do
				{
					documentLinkEventHandler2 = documentLinkEventHandler;
					DocumentLinkEventHandler value2 = (DocumentLinkEventHandler)Delegate.Remove(documentLinkEventHandler2, value);
					documentLinkEventHandler = Interlocked.CompareExchange(ref this.documentLinkEventHandler_0, value2, documentLinkEventHandler2);
				}
				while ((object)documentLinkEventHandler != documentLinkEventHandler2);
			}
		}

		/// <summary>Occurs when a document target has been created.</summary>
		[Attribute3("EVENT_DOCUMENTTARGETCREATED")]
		[Attribute2("CAT_DOCUMENTTARGETS")]
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
		[Attribute2("CAT_TOC")]
		[Attribute3("EVENT_TOCCREATED")]
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
		[Attribute2("CAT_TOC")]
		[Attribute3("EVENT_TOCDELETED")]
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

		/// <summary>Occurs when the current input position has been moved to a position that belongs to a table of contents.</summary>
		[Attribute3("EVENT_TOCENTERED")]
		[Attribute2("CAT_TOC")]
		public event TableOfContentsEventHandler TableOfContentsEntered
		{
			add
			{
				TableOfContentsEventHandler tableOfContentsEventHandler = this.tableOfContentsEventHandler_2;
				TableOfContentsEventHandler tableOfContentsEventHandler2;
				do
				{
					tableOfContentsEventHandler2 = tableOfContentsEventHandler;
					TableOfContentsEventHandler value2 = (TableOfContentsEventHandler)Delegate.Combine(tableOfContentsEventHandler2, value);
					tableOfContentsEventHandler = Interlocked.CompareExchange(ref this.tableOfContentsEventHandler_2, value2, tableOfContentsEventHandler2);
				}
				while ((object)tableOfContentsEventHandler != tableOfContentsEventHandler2);
			}
			remove
			{
				TableOfContentsEventHandler tableOfContentsEventHandler = this.tableOfContentsEventHandler_2;
				TableOfContentsEventHandler tableOfContentsEventHandler2;
				do
				{
					tableOfContentsEventHandler2 = tableOfContentsEventHandler;
					TableOfContentsEventHandler value2 = (TableOfContentsEventHandler)Delegate.Remove(tableOfContentsEventHandler2, value);
					tableOfContentsEventHandler = Interlocked.CompareExchange(ref this.tableOfContentsEventHandler_2, value2, tableOfContentsEventHandler2);
				}
				while ((object)tableOfContentsEventHandler != tableOfContentsEventHandler2);
			}
		}

		/// <summary>Occurs when the current input position has left a table of contents.</summary>
		[Attribute2("CAT_TOC")]
		[Attribute3("EVENT_TOCLEFT")]
		public event TableOfContentsEventHandler TableOfContentsLeft
		{
			add
			{
				TableOfContentsEventHandler tableOfContentsEventHandler = this.tableOfContentsEventHandler_3;
				TableOfContentsEventHandler tableOfContentsEventHandler2;
				do
				{
					tableOfContentsEventHandler2 = tableOfContentsEventHandler;
					TableOfContentsEventHandler value2 = (TableOfContentsEventHandler)Delegate.Combine(tableOfContentsEventHandler2, value);
					tableOfContentsEventHandler = Interlocked.CompareExchange(ref this.tableOfContentsEventHandler_3, value2, tableOfContentsEventHandler2);
				}
				while ((object)tableOfContentsEventHandler != tableOfContentsEventHandler2);
			}
			remove
			{
				TableOfContentsEventHandler tableOfContentsEventHandler = this.tableOfContentsEventHandler_3;
				TableOfContentsEventHandler tableOfContentsEventHandler2;
				do
				{
					tableOfContentsEventHandler2 = tableOfContentsEventHandler;
					TableOfContentsEventHandler value2 = (TableOfContentsEventHandler)Delegate.Remove(tableOfContentsEventHandler2, value);
					tableOfContentsEventHandler = Interlocked.CompareExchange(ref this.tableOfContentsEventHandler_3, value2, tableOfContentsEventHandler2);
				}
				while ((object)tableOfContentsEventHandler != tableOfContentsEventHandler2);
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

		/// <summary>Occurs when a subtextpart has been clicked on.</summary>
		[Attribute2("CAT_SUBTEXTPARTS")]
		[Attribute3("EVENT_SUBTEXTPARTCLICKED")]
		public event SubTextPartEventHandler SubTextPartClicked
		{
			add
			{
				SubTextPartEventHandler subTextPartEventHandler = this.subTextPartEventHandler_2;
				SubTextPartEventHandler subTextPartEventHandler2;
				do
				{
					subTextPartEventHandler2 = subTextPartEventHandler;
					SubTextPartEventHandler value2 = (SubTextPartEventHandler)Delegate.Combine(subTextPartEventHandler2, value);
					subTextPartEventHandler = Interlocked.CompareExchange(ref this.subTextPartEventHandler_2, value2, subTextPartEventHandler2);
				}
				while ((object)subTextPartEventHandler != subTextPartEventHandler2);
			}
			remove
			{
				SubTextPartEventHandler subTextPartEventHandler = this.subTextPartEventHandler_2;
				SubTextPartEventHandler subTextPartEventHandler2;
				do
				{
					subTextPartEventHandler2 = subTextPartEventHandler;
					SubTextPartEventHandler value2 = (SubTextPartEventHandler)Delegate.Remove(subTextPartEventHandler2, value);
					subTextPartEventHandler = Interlocked.CompareExchange(ref this.subTextPartEventHandler_2, value2, subTextPartEventHandler2);
				}
				while ((object)subTextPartEventHandler != subTextPartEventHandler2);
			}
		}

		/// <summary>Occurs when a subtextpart has been double-clicked on.</summary>
		[Attribute3("EVENT_SUBTEXTPARTDOUBLECLICKED")]
		[Attribute2("CAT_SUBTEXTPARTS")]
		public event SubTextPartEventHandler SubTextPartDoubleClicked
		{
			add
			{
				SubTextPartEventHandler subTextPartEventHandler = this.subTextPartEventHandler_3;
				SubTextPartEventHandler subTextPartEventHandler2;
				do
				{
					subTextPartEventHandler2 = subTextPartEventHandler;
					SubTextPartEventHandler value2 = (SubTextPartEventHandler)Delegate.Combine(subTextPartEventHandler2, value);
					subTextPartEventHandler = Interlocked.CompareExchange(ref this.subTextPartEventHandler_3, value2, subTextPartEventHandler2);
				}
				while ((object)subTextPartEventHandler != subTextPartEventHandler2);
			}
			remove
			{
				SubTextPartEventHandler subTextPartEventHandler = this.subTextPartEventHandler_3;
				SubTextPartEventHandler subTextPartEventHandler2;
				do
				{
					subTextPartEventHandler2 = subTextPartEventHandler;
					SubTextPartEventHandler value2 = (SubTextPartEventHandler)Delegate.Remove(subTextPartEventHandler2, value);
					subTextPartEventHandler = Interlocked.CompareExchange(ref this.subTextPartEventHandler_3, value2, subTextPartEventHandler2);
				}
				while ((object)subTextPartEventHandler != subTextPartEventHandler2);
			}
		}

		/// <summary>Occurs when the current input position has been moved to a position that belongs to a subtextpart.</summary>
		[Attribute2("CAT_SUBTEXTPARTS")]
		[Attribute3("EVENT_SUBTEXTPARTENTERED")]
		public event SubTextPartEventHandler SubTextPartEntered
		{
			add
			{
				SubTextPartEventHandler subTextPartEventHandler = this.subTextPartEventHandler_4;
				SubTextPartEventHandler subTextPartEventHandler2;
				do
				{
					subTextPartEventHandler2 = subTextPartEventHandler;
					SubTextPartEventHandler value2 = (SubTextPartEventHandler)Delegate.Combine(subTextPartEventHandler2, value);
					subTextPartEventHandler = Interlocked.CompareExchange(ref this.subTextPartEventHandler_4, value2, subTextPartEventHandler2);
				}
				while ((object)subTextPartEventHandler != subTextPartEventHandler2);
			}
			remove
			{
				SubTextPartEventHandler subTextPartEventHandler = this.subTextPartEventHandler_4;
				SubTextPartEventHandler subTextPartEventHandler2;
				do
				{
					subTextPartEventHandler2 = subTextPartEventHandler;
					SubTextPartEventHandler value2 = (SubTextPartEventHandler)Delegate.Remove(subTextPartEventHandler2, value);
					subTextPartEventHandler = Interlocked.CompareExchange(ref this.subTextPartEventHandler_4, value2, subTextPartEventHandler2);
				}
				while ((object)subTextPartEventHandler != subTextPartEventHandler2);
			}
		}

		/// <summary>Occurs when the current input position has left a subtextpart.</summary>
		[Attribute2("CAT_SUBTEXTPARTS")]
		[Attribute3("EVENT_SUBTEXTPARTLEFT")]
		public event SubTextPartEventHandler SubTextPartLeft
		{
			add
			{
				SubTextPartEventHandler subTextPartEventHandler = this.subTextPartEventHandler_5;
				SubTextPartEventHandler subTextPartEventHandler2;
				do
				{
					subTextPartEventHandler2 = subTextPartEventHandler;
					SubTextPartEventHandler value2 = (SubTextPartEventHandler)Delegate.Combine(subTextPartEventHandler2, value);
					subTextPartEventHandler = Interlocked.CompareExchange(ref this.subTextPartEventHandler_5, value2, subTextPartEventHandler2);
				}
				while ((object)subTextPartEventHandler != subTextPartEventHandler2);
			}
			remove
			{
				SubTextPartEventHandler subTextPartEventHandler = this.subTextPartEventHandler_5;
				SubTextPartEventHandler subTextPartEventHandler2;
				do
				{
					subTextPartEventHandler2 = subTextPartEventHandler;
					SubTextPartEventHandler value2 = (SubTextPartEventHandler)Delegate.Remove(subTextPartEventHandler2, value);
					subTextPartEventHandler = Interlocked.CompareExchange(ref this.subTextPartEventHandler_5, value2, subTextPartEventHandler2);
				}
				while ((object)subTextPartEventHandler != subTextPartEventHandler2);
			}
		}

		/// <summary>Occurs when the current input position has been moved to a position that belongs to an editable region.</summary>
		[Attribute3("EVENT_EDITABLEREGIONENTERED")]
		[Attribute2("CAT_SUBTEXTPARTS")]
		public event EditableRegionEventHandler EditableRegionEntered
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

		/// <summary>Occurs when the current input position has left an editable region.</summary>
		[Attribute3("EVENT_EDITABLEREGIONLEFT")]
		[Attribute2("CAT_SUBTEXTPARTS")]
		public event EditableRegionEventHandler EditableRegionLeft
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

		/// <summary>Occurs when an editable region has been created.</summary>
		[Attribute2("CAT_SUBTEXTPARTS")]
		[Attribute3("EVENT_EDITABLEREGIONCREATED")]
		public event EditableRegionEventHandler EditableRegionCreated
		{
			add
			{
				EditableRegionEventHandler editableRegionEventHandler = this.editableRegionEventHandler_2;
				EditableRegionEventHandler editableRegionEventHandler2;
				do
				{
					editableRegionEventHandler2 = editableRegionEventHandler;
					EditableRegionEventHandler value2 = (EditableRegionEventHandler)Delegate.Combine(editableRegionEventHandler2, value);
					editableRegionEventHandler = Interlocked.CompareExchange(ref this.editableRegionEventHandler_2, value2, editableRegionEventHandler2);
				}
				while ((object)editableRegionEventHandler != editableRegionEventHandler2);
			}
			remove
			{
				EditableRegionEventHandler editableRegionEventHandler = this.editableRegionEventHandler_2;
				EditableRegionEventHandler editableRegionEventHandler2;
				do
				{
					editableRegionEventHandler2 = editableRegionEventHandler;
					EditableRegionEventHandler value2 = (EditableRegionEventHandler)Delegate.Remove(editableRegionEventHandler2, value);
					editableRegionEventHandler = Interlocked.CompareExchange(ref this.editableRegionEventHandler_2, value2, editableRegionEventHandler2);
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
				EditableRegionEventHandler editableRegionEventHandler = this.editableRegionEventHandler_3;
				EditableRegionEventHandler editableRegionEventHandler2;
				do
				{
					editableRegionEventHandler2 = editableRegionEventHandler;
					EditableRegionEventHandler value2 = (EditableRegionEventHandler)Delegate.Combine(editableRegionEventHandler2, value);
					editableRegionEventHandler = Interlocked.CompareExchange(ref this.editableRegionEventHandler_3, value2, editableRegionEventHandler2);
				}
				while ((object)editableRegionEventHandler != editableRegionEventHandler2);
			}
			remove
			{
				EditableRegionEventHandler editableRegionEventHandler = this.editableRegionEventHandler_3;
				EditableRegionEventHandler editableRegionEventHandler2;
				do
				{
					editableRegionEventHandler2 = editableRegionEventHandler;
					EditableRegionEventHandler value2 = (EditableRegionEventHandler)Delegate.Remove(editableRegionEventHandler2, value);
					editableRegionEventHandler = Interlocked.CompareExchange(ref this.editableRegionEventHandler_3, value2, editableRegionEventHandler2);
				}
				while ((object)editableRegionEventHandler != editableRegionEventHandler2);
			}
		}

		/// <summary>Determines how to handle a change of the document that cannot be added to the list of tracked changes.</summary>
		[Attribute3("EVENT_CANNOTTRACKCHANGE")]
		[Attribute2("CAT_SUBTEXTPARTS")]
		public event CannotTrackChangeEventHandler CannotTrackChange
		{
			add
			{
				CannotTrackChangeEventHandler cannotTrackChangeEventHandler = this.cannotTrackChangeEventHandler_0;
				CannotTrackChangeEventHandler cannotTrackChangeEventHandler2;
				do
				{
					cannotTrackChangeEventHandler2 = cannotTrackChangeEventHandler;
					CannotTrackChangeEventHandler value2 = (CannotTrackChangeEventHandler)Delegate.Combine(cannotTrackChangeEventHandler2, value);
					cannotTrackChangeEventHandler = Interlocked.CompareExchange(ref this.cannotTrackChangeEventHandler_0, value2, cannotTrackChangeEventHandler2);
				}
				while ((object)cannotTrackChangeEventHandler != cannotTrackChangeEventHandler2);
			}
			remove
			{
				CannotTrackChangeEventHandler cannotTrackChangeEventHandler = this.cannotTrackChangeEventHandler_0;
				CannotTrackChangeEventHandler cannotTrackChangeEventHandler2;
				do
				{
					cannotTrackChangeEventHandler2 = cannotTrackChangeEventHandler;
					CannotTrackChangeEventHandler value2 = (CannotTrackChangeEventHandler)Delegate.Remove(cannotTrackChangeEventHandler2, value);
					cannotTrackChangeEventHandler = Interlocked.CompareExchange(ref this.cannotTrackChangeEventHandler_0, value2, cannotTrackChangeEventHandler2);
				}
				while ((object)cannotTrackChangeEventHandler != cannotTrackChangeEventHandler2);
			}
		}

		/// <summary>Occurs when the text of a tracked change has been altered.</summary>
		[Attribute2("CAT_SUBTEXTPARTS")]
		[Attribute3("EVENT_TRACKEDCHANGECHANGED")]
		public event TrackedChangeEventHandler TrackedChangeChanged
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

		/// <summary>Occurs when a tracked change has been created.</summary>
		[Attribute2("CAT_SUBTEXTPARTS")]
		[Attribute3("EVENT_TRACKEDCHANGECREATED")]
		public event TrackedChangeEventHandler TrackedChangeCreated
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

		/// <summary>Occurs when a tracked change has been deleted.</summary>
		[Attribute3("EVENT_TRACKEDCHANGEDELETED")]
		[Attribute2("CAT_SUBTEXTPARTS")]
		public event TrackedChangeEventHandler TrackedChangeDeleted
		{
			add
			{
				TrackedChangeEventHandler trackedChangeEventHandler = this.trackedChangeEventHandler_2;
				TrackedChangeEventHandler trackedChangeEventHandler2;
				do
				{
					trackedChangeEventHandler2 = trackedChangeEventHandler;
					TrackedChangeEventHandler value2 = (TrackedChangeEventHandler)Delegate.Combine(trackedChangeEventHandler2, value);
					trackedChangeEventHandler = Interlocked.CompareExchange(ref this.trackedChangeEventHandler_2, value2, trackedChangeEventHandler2);
				}
				while ((object)trackedChangeEventHandler != trackedChangeEventHandler2);
			}
			remove
			{
				TrackedChangeEventHandler trackedChangeEventHandler = this.trackedChangeEventHandler_2;
				TrackedChangeEventHandler trackedChangeEventHandler2;
				do
				{
					trackedChangeEventHandler2 = trackedChangeEventHandler;
					TrackedChangeEventHandler value2 = (TrackedChangeEventHandler)Delegate.Remove(trackedChangeEventHandler2, value);
					trackedChangeEventHandler = Interlocked.CompareExchange(ref this.trackedChangeEventHandler_2, value2, trackedChangeEventHandler2);
				}
				while ((object)trackedChangeEventHandler != trackedChangeEventHandler2);
			}
		}

		/// <summary>Occurs when the state of a tracked change alters from active to inactive or vice versa.</summary>
		[Attribute2("CAT_SUBTEXTPARTS")]
		[Attribute3("EVENT_TRACKEDCHANGESTATECHANGED")]
		public event TrackedChangeEventHandler TrackedChangeStateChanged
		{
			add
			{
				TrackedChangeEventHandler trackedChangeEventHandler = this.trackedChangeEventHandler_3;
				TrackedChangeEventHandler trackedChangeEventHandler2;
				do
				{
					trackedChangeEventHandler2 = trackedChangeEventHandler;
					TrackedChangeEventHandler value2 = (TrackedChangeEventHandler)Delegate.Combine(trackedChangeEventHandler2, value);
					trackedChangeEventHandler = Interlocked.CompareExchange(ref this.trackedChangeEventHandler_3, value2, trackedChangeEventHandler2);
				}
				while ((object)trackedChangeEventHandler != trackedChangeEventHandler2);
			}
			remove
			{
				TrackedChangeEventHandler trackedChangeEventHandler = this.trackedChangeEventHandler_3;
				TrackedChangeEventHandler trackedChangeEventHandler2;
				do
				{
					trackedChangeEventHandler2 = trackedChangeEventHandler;
					TrackedChangeEventHandler value2 = (TrackedChangeEventHandler)Delegate.Remove(trackedChangeEventHandler2, value);
					trackedChangeEventHandler = Interlocked.CompareExchange(ref this.trackedChangeEventHandler_3, value2, trackedChangeEventHandler2);
				}
				while ((object)trackedChangeEventHandler != trackedChangeEventHandler2);
			}
		}

		/// <summary>Occurs when a frame (image, text frame, chart, barcode or drawing) has been clicked on.</summary>
		[Attribute3("EVENT_FRAMECLICKED")]
		[Attribute2("CAT_FRAMES")]
		public event FrameEventHandler FrameClicked
		{
			add
			{
				FrameEventHandler frameEventHandler = this.frameEventHandler_0;
				FrameEventHandler frameEventHandler2;
				do
				{
					frameEventHandler2 = frameEventHandler;
					FrameEventHandler value2 = (FrameEventHandler)Delegate.Combine(frameEventHandler2, value);
					frameEventHandler = Interlocked.CompareExchange(ref this.frameEventHandler_0, value2, frameEventHandler2);
				}
				while ((object)frameEventHandler != frameEventHandler2);
			}
			remove
			{
				FrameEventHandler frameEventHandler = this.frameEventHandler_0;
				FrameEventHandler frameEventHandler2;
				do
				{
					frameEventHandler2 = frameEventHandler;
					FrameEventHandler value2 = (FrameEventHandler)Delegate.Remove(frameEventHandler2, value);
					frameEventHandler = Interlocked.CompareExchange(ref this.frameEventHandler_0, value2, frameEventHandler2);
				}
				while ((object)frameEventHandler != frameEventHandler2);
			}
		}

		/// <summary>Occurs when a frame (image, text frame, chart, barcode or drawing) has been doubleclicked on.</summary>
		[Attribute3("EVENT_FRAMEDOUBLECLICKED")]
		[Attribute2("CAT_FRAMES")]
		public event FrameEventHandler FrameDoubleClicked
		{
			add
			{
				FrameEventHandler frameEventHandler = this.frameEventHandler_1;
				FrameEventHandler frameEventHandler2;
				do
				{
					frameEventHandler2 = frameEventHandler;
					FrameEventHandler value2 = (FrameEventHandler)Delegate.Combine(frameEventHandler2, value);
					frameEventHandler = Interlocked.CompareExchange(ref this.frameEventHandler_1, value2, frameEventHandler2);
				}
				while ((object)frameEventHandler != frameEventHandler2);
			}
			remove
			{
				FrameEventHandler frameEventHandler = this.frameEventHandler_1;
				FrameEventHandler frameEventHandler2;
				do
				{
					frameEventHandler2 = frameEventHandler;
					FrameEventHandler value2 = (FrameEventHandler)Delegate.Remove(frameEventHandler2, value);
					frameEventHandler = Interlocked.CompareExchange(ref this.frameEventHandler_1, value2, frameEventHandler2);
				}
				while ((object)frameEventHandler != frameEventHandler2);
			}
		}

		/// <summary>Occurs when a frame (image, text frame, chart, barcode or drawing) has been moved.</summary>
		[Attribute2("CAT_FRAMES")]
		[Attribute3("EVENT_FRAMEMOVED")]
		public event FrameEventHandler FrameMoved
		{
			add
			{
				FrameEventHandler frameEventHandler = this.frameEventHandler_2;
				FrameEventHandler frameEventHandler2;
				do
				{
					frameEventHandler2 = frameEventHandler;
					FrameEventHandler value2 = (FrameEventHandler)Delegate.Combine(frameEventHandler2, value);
					frameEventHandler = Interlocked.CompareExchange(ref this.frameEventHandler_2, value2, frameEventHandler2);
				}
				while ((object)frameEventHandler != frameEventHandler2);
			}
			remove
			{
				FrameEventHandler frameEventHandler = this.frameEventHandler_2;
				FrameEventHandler frameEventHandler2;
				do
				{
					frameEventHandler2 = frameEventHandler;
					FrameEventHandler value2 = (FrameEventHandler)Delegate.Remove(frameEventHandler2, value);
					frameEventHandler = Interlocked.CompareExchange(ref this.frameEventHandler_2, value2, frameEventHandler2);
				}
				while ((object)frameEventHandler != frameEventHandler2);
			}
		}

		/// <summary>Occurs when a frame (image, text frame, chart, barcode or drawing) has been sized.</summary>
		[Attribute3("EVENT_FRAMESIZED")]
		[Attribute2("CAT_FRAMES")]
		public event FrameEventHandler FrameSized
		{
			add
			{
				FrameEventHandler frameEventHandler = this.frameEventHandler_3;
				FrameEventHandler frameEventHandler2;
				do
				{
					frameEventHandler2 = frameEventHandler;
					FrameEventHandler value2 = (FrameEventHandler)Delegate.Combine(frameEventHandler2, value);
					frameEventHandler = Interlocked.CompareExchange(ref this.frameEventHandler_3, value2, frameEventHandler2);
				}
				while ((object)frameEventHandler != frameEventHandler2);
			}
			remove
			{
				FrameEventHandler frameEventHandler = this.frameEventHandler_3;
				FrameEventHandler frameEventHandler2;
				do
				{
					frameEventHandler2 = frameEventHandler;
					FrameEventHandler value2 = (FrameEventHandler)Delegate.Remove(frameEventHandler2, value);
					frameEventHandler = Interlocked.CompareExchange(ref this.frameEventHandler_3, value2, frameEventHandler2);
				}
				while ((object)frameEventHandler != frameEventHandler2);
			}
		}

		/// <summary>Occurs when a frame (image, text frame, chart, barcode or drawing) has been clicked on with the right mouse button.</summary>
		[Attribute3("EVENT_FRAMERIGHTCLICKED")]
		[Attribute2("CAT_FRAMES")]
		public event FrameEventHandler FrameRightClicked
		{
			add
			{
				FrameEventHandler frameEventHandler = this.frameEventHandler_4;
				FrameEventHandler frameEventHandler2;
				do
				{
					frameEventHandler2 = frameEventHandler;
					FrameEventHandler value2 = (FrameEventHandler)Delegate.Combine(frameEventHandler2, value);
					frameEventHandler = Interlocked.CompareExchange(ref this.frameEventHandler_4, value2, frameEventHandler2);
				}
				while ((object)frameEventHandler != frameEventHandler2);
			}
			remove
			{
				FrameEventHandler frameEventHandler = this.frameEventHandler_4;
				FrameEventHandler frameEventHandler2;
				do
				{
					frameEventHandler2 = frameEventHandler;
					FrameEventHandler value2 = (FrameEventHandler)Delegate.Remove(frameEventHandler2, value);
					frameEventHandler = Interlocked.CompareExchange(ref this.frameEventHandler_4, value2, frameEventHandler2);
				}
				while ((object)frameEventHandler != frameEventHandler2);
			}
		}

		/// <summary>Occurs when a frame (image, text frame, chart, barcode or drawing) has been selected.</summary>
		[Attribute2("CAT_FRAMES")]
		[Attribute3("EVENT_FRAMESELECTED")]
		public event FrameEventHandler FrameSelected
		{
			add
			{
				FrameEventHandler frameEventHandler = this.frameEventHandler_5;
				FrameEventHandler frameEventHandler2;
				do
				{
					frameEventHandler2 = frameEventHandler;
					FrameEventHandler value2 = (FrameEventHandler)Delegate.Combine(frameEventHandler2, value);
					frameEventHandler = Interlocked.CompareExchange(ref this.frameEventHandler_5, value2, frameEventHandler2);
				}
				while ((object)frameEventHandler != frameEventHandler2);
			}
			remove
			{
				FrameEventHandler frameEventHandler = this.frameEventHandler_5;
				FrameEventHandler frameEventHandler2;
				do
				{
					frameEventHandler2 = frameEventHandler;
					FrameEventHandler value2 = (FrameEventHandler)Delegate.Remove(frameEventHandler2, value);
					frameEventHandler = Interlocked.CompareExchange(ref this.frameEventHandler_5, value2, frameEventHandler2);
				}
				while ((object)frameEventHandler != frameEventHandler2);
			}
		}

		/// <summary>Occurs when a frame (image, text frame, chart, barcode or drawing) has been deselected.</summary>
		[Attribute3("EVENT_FRAMEDESELECTED")]
		[Attribute2("CAT_FRAMES")]
		public event FrameEventHandler FrameDeselected
		{
			add
			{
				FrameEventHandler frameEventHandler = this.frameEventHandler_6;
				FrameEventHandler frameEventHandler2;
				do
				{
					frameEventHandler2 = frameEventHandler;
					FrameEventHandler value2 = (FrameEventHandler)Delegate.Combine(frameEventHandler2, value);
					frameEventHandler = Interlocked.CompareExchange(ref this.frameEventHandler_6, value2, frameEventHandler2);
				}
				while ((object)frameEventHandler != frameEventHandler2);
			}
			remove
			{
				FrameEventHandler frameEventHandler = this.frameEventHandler_6;
				FrameEventHandler frameEventHandler2;
				do
				{
					frameEventHandler2 = frameEventHandler;
					FrameEventHandler value2 = (FrameEventHandler)Delegate.Remove(frameEventHandler2, value);
					frameEventHandler = Interlocked.CompareExchange(ref this.frameEventHandler_6, value2, frameEventHandler2);
				}
				while ((object)frameEventHandler != frameEventHandler2);
			}
		}

		/// <summary>Occurs when the layout of a frame (image, text frame, chart, barcode or drawing) has been changed.</summary>
		[Attribute2("CAT_FRAMES")]
		[Attribute3("EVENT_FRAMELAYOUTCHANGED")]
		public event FrameEventHandler FrameLayoutChanged
		{
			add
			{
				FrameEventHandler frameEventHandler = this.frameEventHandler_7;
				FrameEventHandler frameEventHandler2;
				do
				{
					frameEventHandler2 = frameEventHandler;
					FrameEventHandler value2 = (FrameEventHandler)Delegate.Combine(frameEventHandler2, value);
					frameEventHandler = Interlocked.CompareExchange(ref this.frameEventHandler_7, value2, frameEventHandler2);
				}
				while ((object)frameEventHandler != frameEventHandler2);
			}
			remove
			{
				FrameEventHandler frameEventHandler = this.frameEventHandler_7;
				FrameEventHandler frameEventHandler2;
				do
				{
					frameEventHandler2 = frameEventHandler;
					FrameEventHandler value2 = (FrameEventHandler)Delegate.Remove(frameEventHandler2, value);
					frameEventHandler = Interlocked.CompareExchange(ref this.frameEventHandler_7, value2, frameEventHandler2);
				}
				while ((object)frameEventHandler != frameEventHandler2);
			}
		}

		/// <summary>Occurs when an image has been clicked on.</summary>
		[Attribute3("EVENT_IMAGECLICKED")]
		[Attribute2("CAT_IMAGES")]
		public event ImageEventHandler ImageClicked
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

		/// <summary>Occurs when a new image has been created.</summary>
		[Attribute2("CAT_IMAGES")]
		[Attribute3("EVENT_IMAGECREATED")]
		public event ImageEventHandler ImageCreated
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

		/// <summary>Occurs when an image has been deleted.</summary>
		[Attribute2("CAT_IMAGES")]
		[Attribute3("EVENT_IMAGEDELETED")]
		public event ImageEventHandler ImageDeleted
		{
			add
			{
				ImageEventHandler imageEventHandler = this.imageEventHandler_2;
				ImageEventHandler imageEventHandler2;
				do
				{
					imageEventHandler2 = imageEventHandler;
					ImageEventHandler value2 = (ImageEventHandler)Delegate.Combine(imageEventHandler2, value);
					imageEventHandler = Interlocked.CompareExchange(ref this.imageEventHandler_2, value2, imageEventHandler2);
				}
				while ((object)imageEventHandler != imageEventHandler2);
			}
			remove
			{
				ImageEventHandler imageEventHandler = this.imageEventHandler_2;
				ImageEventHandler imageEventHandler2;
				do
				{
					imageEventHandler2 = imageEventHandler;
					ImageEventHandler value2 = (ImageEventHandler)Delegate.Remove(imageEventHandler2, value);
					imageEventHandler = Interlocked.CompareExchange(ref this.imageEventHandler_2, value2, imageEventHandler2);
				}
				while ((object)imageEventHandler != imageEventHandler2);
			}
		}

		/// <summary>Occurs when an image has been doubleclicked on.</summary>
		[Attribute2("CAT_IMAGES")]
		[Attribute3("EVENT_IMAGEDOUBLECLICKED")]
		public event ImageEventHandler ImageDoubleClicked
		{
			add
			{
				ImageEventHandler imageEventHandler = this.imageEventHandler_3;
				ImageEventHandler imageEventHandler2;
				do
				{
					imageEventHandler2 = imageEventHandler;
					ImageEventHandler value2 = (ImageEventHandler)Delegate.Combine(imageEventHandler2, value);
					imageEventHandler = Interlocked.CompareExchange(ref this.imageEventHandler_3, value2, imageEventHandler2);
				}
				while ((object)imageEventHandler != imageEventHandler2);
			}
			remove
			{
				ImageEventHandler imageEventHandler = this.imageEventHandler_3;
				ImageEventHandler imageEventHandler2;
				do
				{
					imageEventHandler2 = imageEventHandler;
					ImageEventHandler value2 = (ImageEventHandler)Delegate.Remove(imageEventHandler2, value);
					imageEventHandler = Interlocked.CompareExchange(ref this.imageEventHandler_3, value2, imageEventHandler2);
				}
				while ((object)imageEventHandler != imageEventHandler2);
			}
		}

		/// <summary>Occurs when an inserted image has been moved.</summary>
		[Attribute2("CAT_IMAGES")]
		[Attribute3("EVENT_IMAGEMOVED")]
		public event ImageEventHandler ImageMoved
		{
			add
			{
				ImageEventHandler imageEventHandler = this.imageEventHandler_4;
				ImageEventHandler imageEventHandler2;
				do
				{
					imageEventHandler2 = imageEventHandler;
					ImageEventHandler value2 = (ImageEventHandler)Delegate.Combine(imageEventHandler2, value);
					imageEventHandler = Interlocked.CompareExchange(ref this.imageEventHandler_4, value2, imageEventHandler2);
				}
				while ((object)imageEventHandler != imageEventHandler2);
			}
			remove
			{
				ImageEventHandler imageEventHandler = this.imageEventHandler_4;
				ImageEventHandler imageEventHandler2;
				do
				{
					imageEventHandler2 = imageEventHandler;
					ImageEventHandler value2 = (ImageEventHandler)Delegate.Remove(imageEventHandler2, value);
					imageEventHandler = Interlocked.CompareExchange(ref this.imageEventHandler_4, value2, imageEventHandler2);
				}
				while ((object)imageEventHandler != imageEventHandler2);
			}
		}

		/// <summary>Occurs when an inserted image has been sized.</summary>
		[Attribute2("CAT_IMAGES")]
		[Attribute3("EVENT_IMAGESIZED")]
		public event ImageEventHandler ImageSized
		{
			add
			{
				ImageEventHandler imageEventHandler = this.imageEventHandler_5;
				ImageEventHandler imageEventHandler2;
				do
				{
					imageEventHandler2 = imageEventHandler;
					ImageEventHandler value2 = (ImageEventHandler)Delegate.Combine(imageEventHandler2, value);
					imageEventHandler = Interlocked.CompareExchange(ref this.imageEventHandler_5, value2, imageEventHandler2);
				}
				while ((object)imageEventHandler != imageEventHandler2);
			}
			remove
			{
				ImageEventHandler imageEventHandler = this.imageEventHandler_5;
				ImageEventHandler imageEventHandler2;
				do
				{
					imageEventHandler2 = imageEventHandler;
					ImageEventHandler value2 = (ImageEventHandler)Delegate.Remove(imageEventHandler2, value);
					imageEventHandler = Interlocked.CompareExchange(ref this.imageEventHandler_5, value2, imageEventHandler2);
				}
				while ((object)imageEventHandler != imageEventHandler2);
			}
		}

		/// <summary>Occurs when an image has been clicked on with the right mouse button.</summary>
		[Attribute3("EVENT_IMAGERIGHTCLICKED")]
		[Attribute2("CAT_IMAGES")]
		public event ImageEventHandler ImageRightClicked
		{
			add
			{
				ImageEventHandler imageEventHandler = this.imageEventHandler_6;
				ImageEventHandler imageEventHandler2;
				do
				{
					imageEventHandler2 = imageEventHandler;
					ImageEventHandler value2 = (ImageEventHandler)Delegate.Combine(imageEventHandler2, value);
					imageEventHandler = Interlocked.CompareExchange(ref this.imageEventHandler_6, value2, imageEventHandler2);
				}
				while ((object)imageEventHandler != imageEventHandler2);
			}
			remove
			{
				ImageEventHandler imageEventHandler = this.imageEventHandler_6;
				ImageEventHandler imageEventHandler2;
				do
				{
					imageEventHandler2 = imageEventHandler;
					ImageEventHandler value2 = (ImageEventHandler)Delegate.Remove(imageEventHandler2, value);
					imageEventHandler = Interlocked.CompareExchange(ref this.imageEventHandler_6, value2, imageEventHandler2);
				}
				while ((object)imageEventHandler != imageEventHandler2);
			}
		}

		/// <summary>Occurs when an image has been selected.</summary>
		[Attribute3("EVENT_IMAGESELECTED")]
		[Attribute2("CAT_IMAGES")]
		public event ImageEventHandler ImageSelected
		{
			add
			{
				ImageEventHandler imageEventHandler = this.imageEventHandler_7;
				ImageEventHandler imageEventHandler2;
				do
				{
					imageEventHandler2 = imageEventHandler;
					ImageEventHandler value2 = (ImageEventHandler)Delegate.Combine(imageEventHandler2, value);
					imageEventHandler = Interlocked.CompareExchange(ref this.imageEventHandler_7, value2, imageEventHandler2);
				}
				while ((object)imageEventHandler != imageEventHandler2);
			}
			remove
			{
				ImageEventHandler imageEventHandler = this.imageEventHandler_7;
				ImageEventHandler imageEventHandler2;
				do
				{
					imageEventHandler2 = imageEventHandler;
					ImageEventHandler value2 = (ImageEventHandler)Delegate.Remove(imageEventHandler2, value);
					imageEventHandler = Interlocked.CompareExchange(ref this.imageEventHandler_7, value2, imageEventHandler2);
				}
				while ((object)imageEventHandler != imageEventHandler2);
			}
		}

		/// <summary>Occurs when an image has been deselected.</summary>
		[Attribute2("CAT_IMAGES")]
		[Attribute3("EVENT_IMAGEDESELECTED")]
		public event ImageEventHandler ImageDeselected
		{
			add
			{
				ImageEventHandler imageEventHandler = this.imageEventHandler_8;
				ImageEventHandler imageEventHandler2;
				do
				{
					imageEventHandler2 = imageEventHandler;
					ImageEventHandler value2 = (ImageEventHandler)Delegate.Combine(imageEventHandler2, value);
					imageEventHandler = Interlocked.CompareExchange(ref this.imageEventHandler_8, value2, imageEventHandler2);
				}
				while ((object)imageEventHandler != imageEventHandler2);
			}
			remove
			{
				ImageEventHandler imageEventHandler = this.imageEventHandler_8;
				ImageEventHandler imageEventHandler2;
				do
				{
					imageEventHandler2 = imageEventHandler;
					ImageEventHandler value2 = (ImageEventHandler)Delegate.Remove(imageEventHandler2, value);
					imageEventHandler = Interlocked.CompareExchange(ref this.imageEventHandler_8, value2, imageEventHandler2);
				}
				while ((object)imageEventHandler != imageEventHandler2);
			}
		}

		/// <summary>Occurs when a text frame has been clicked on.</summary>
		[Attribute3("EVENT_TEXTFRAMECLICKED")]
		[Attribute2("CAT_TEXTFRAMES")]
		public event TextFrameEventHandler TextFrameClicked
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

		/// <summary>Occurs when a new text frame has been created.</summary>
		[Attribute2("CAT_TEXTFRAMES")]
		[Attribute3("EVENT_TEXTFRAMECREATED")]
		public event TextFrameEventHandler TextFrameCreated
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

		/// <summary>Occurs when a text frame has been deleted.</summary>
		[Attribute3("EVENT_TEXTFRAMEDELETED")]
		[Attribute2("CAT_TEXTFRAMES")]
		public event TextFrameEventHandler TextFrameDeleted
		{
			add
			{
				TextFrameEventHandler textFrameEventHandler = this.textFrameEventHandler_2;
				TextFrameEventHandler textFrameEventHandler2;
				do
				{
					textFrameEventHandler2 = textFrameEventHandler;
					TextFrameEventHandler value2 = (TextFrameEventHandler)Delegate.Combine(textFrameEventHandler2, value);
					textFrameEventHandler = Interlocked.CompareExchange(ref this.textFrameEventHandler_2, value2, textFrameEventHandler2);
				}
				while ((object)textFrameEventHandler != textFrameEventHandler2);
			}
			remove
			{
				TextFrameEventHandler textFrameEventHandler = this.textFrameEventHandler_2;
				TextFrameEventHandler textFrameEventHandler2;
				do
				{
					textFrameEventHandler2 = textFrameEventHandler;
					TextFrameEventHandler value2 = (TextFrameEventHandler)Delegate.Remove(textFrameEventHandler2, value);
					textFrameEventHandler = Interlocked.CompareExchange(ref this.textFrameEventHandler_2, value2, textFrameEventHandler2);
				}
				while ((object)textFrameEventHandler != textFrameEventHandler2);
			}
		}

		/// <summary>Occurs when a text frame has been doubleclicked on.</summary>
		[Attribute3("EVENT_TEXTFRAMEDOUBLECLICKED")]
		[Attribute2("CAT_TEXTFRAMES")]
		public event TextFrameEventHandler TextFrameDoubleClicked
		{
			add
			{
				TextFrameEventHandler textFrameEventHandler = this.textFrameEventHandler_3;
				TextFrameEventHandler textFrameEventHandler2;
				do
				{
					textFrameEventHandler2 = textFrameEventHandler;
					TextFrameEventHandler value2 = (TextFrameEventHandler)Delegate.Combine(textFrameEventHandler2, value);
					textFrameEventHandler = Interlocked.CompareExchange(ref this.textFrameEventHandler_3, value2, textFrameEventHandler2);
				}
				while ((object)textFrameEventHandler != textFrameEventHandler2);
			}
			remove
			{
				TextFrameEventHandler textFrameEventHandler = this.textFrameEventHandler_3;
				TextFrameEventHandler textFrameEventHandler2;
				do
				{
					textFrameEventHandler2 = textFrameEventHandler;
					TextFrameEventHandler value2 = (TextFrameEventHandler)Delegate.Remove(textFrameEventHandler2, value);
					textFrameEventHandler = Interlocked.CompareExchange(ref this.textFrameEventHandler_3, value2, textFrameEventHandler2);
				}
				while ((object)textFrameEventHandler != textFrameEventHandler2);
			}
		}

		/// <summary>Occurs when a text frame has been moved.</summary>
		[Attribute3("EVENT_TEXTFRAMEMOVED")]
		[Attribute2("CAT_TEXTFRAMES")]
		public event TextFrameEventHandler TextFrameMoved
		{
			add
			{
				TextFrameEventHandler textFrameEventHandler = this.textFrameEventHandler_4;
				TextFrameEventHandler textFrameEventHandler2;
				do
				{
					textFrameEventHandler2 = textFrameEventHandler;
					TextFrameEventHandler value2 = (TextFrameEventHandler)Delegate.Combine(textFrameEventHandler2, value);
					textFrameEventHandler = Interlocked.CompareExchange(ref this.textFrameEventHandler_4, value2, textFrameEventHandler2);
				}
				while ((object)textFrameEventHandler != textFrameEventHandler2);
			}
			remove
			{
				TextFrameEventHandler textFrameEventHandler = this.textFrameEventHandler_4;
				TextFrameEventHandler textFrameEventHandler2;
				do
				{
					textFrameEventHandler2 = textFrameEventHandler;
					TextFrameEventHandler value2 = (TextFrameEventHandler)Delegate.Remove(textFrameEventHandler2, value);
					textFrameEventHandler = Interlocked.CompareExchange(ref this.textFrameEventHandler_4, value2, textFrameEventHandler2);
				}
				while ((object)textFrameEventHandler != textFrameEventHandler2);
			}
		}

		/// <summary>Occurs when a text frame has been sized.</summary>
		[Attribute2("CAT_TEXTFRAMES")]
		[Attribute3("EVENT_TEXTFRAMESIZED")]
		public event TextFrameEventHandler TextFrameSized
		{
			add
			{
				TextFrameEventHandler textFrameEventHandler = this.textFrameEventHandler_5;
				TextFrameEventHandler textFrameEventHandler2;
				do
				{
					textFrameEventHandler2 = textFrameEventHandler;
					TextFrameEventHandler value2 = (TextFrameEventHandler)Delegate.Combine(textFrameEventHandler2, value);
					textFrameEventHandler = Interlocked.CompareExchange(ref this.textFrameEventHandler_5, value2, textFrameEventHandler2);
				}
				while ((object)textFrameEventHandler != textFrameEventHandler2);
			}
			remove
			{
				TextFrameEventHandler textFrameEventHandler = this.textFrameEventHandler_5;
				TextFrameEventHandler textFrameEventHandler2;
				do
				{
					textFrameEventHandler2 = textFrameEventHandler;
					TextFrameEventHandler value2 = (TextFrameEventHandler)Delegate.Remove(textFrameEventHandler2, value);
					textFrameEventHandler = Interlocked.CompareExchange(ref this.textFrameEventHandler_5, value2, textFrameEventHandler2);
				}
				while ((object)textFrameEventHandler != textFrameEventHandler2);
			}
		}

		/// <summary>Occurs when a text frame has been clicked on with the right mouse button.</summary>
		[Attribute3("EVENT_TEXTFRAMERIGHTCLICKED")]
		[Attribute2("CAT_TEXTFRAMES")]
		public event TextFrameEventHandler TextFrameRightClicked
		{
			add
			{
				TextFrameEventHandler textFrameEventHandler = this.textFrameEventHandler_6;
				TextFrameEventHandler textFrameEventHandler2;
				do
				{
					textFrameEventHandler2 = textFrameEventHandler;
					TextFrameEventHandler value2 = (TextFrameEventHandler)Delegate.Combine(textFrameEventHandler2, value);
					textFrameEventHandler = Interlocked.CompareExchange(ref this.textFrameEventHandler_6, value2, textFrameEventHandler2);
				}
				while ((object)textFrameEventHandler != textFrameEventHandler2);
			}
			remove
			{
				TextFrameEventHandler textFrameEventHandler = this.textFrameEventHandler_6;
				TextFrameEventHandler textFrameEventHandler2;
				do
				{
					textFrameEventHandler2 = textFrameEventHandler;
					TextFrameEventHandler value2 = (TextFrameEventHandler)Delegate.Remove(textFrameEventHandler2, value);
					textFrameEventHandler = Interlocked.CompareExchange(ref this.textFrameEventHandler_6, value2, textFrameEventHandler2);
				}
				while ((object)textFrameEventHandler != textFrameEventHandler2);
			}
		}

		/// <summary>Occurs when a text frame gets the current text input position from another part of the document such as a header, a footer or the main text.</summary>
		[Attribute3("EVENT_TEXTFRAMEACTIVATED")]
		[Attribute2("CAT_TEXTFRAMES")]
		public event TextFrameEventHandler TextFrameActivated
		{
			add
			{
				TextFrameEventHandler textFrameEventHandler = this.textFrameEventHandler_7;
				TextFrameEventHandler textFrameEventHandler2;
				do
				{
					textFrameEventHandler2 = textFrameEventHandler;
					TextFrameEventHandler value2 = (TextFrameEventHandler)Delegate.Combine(textFrameEventHandler2, value);
					textFrameEventHandler = Interlocked.CompareExchange(ref this.textFrameEventHandler_7, value2, textFrameEventHandler2);
				}
				while ((object)textFrameEventHandler != textFrameEventHandler2);
			}
			remove
			{
				TextFrameEventHandler textFrameEventHandler = this.textFrameEventHandler_7;
				TextFrameEventHandler textFrameEventHandler2;
				do
				{
					textFrameEventHandler2 = textFrameEventHandler;
					TextFrameEventHandler value2 = (TextFrameEventHandler)Delegate.Remove(textFrameEventHandler2, value);
					textFrameEventHandler = Interlocked.CompareExchange(ref this.textFrameEventHandler_7, value2, textFrameEventHandler2);
				}
				while ((object)textFrameEventHandler != textFrameEventHandler2);
			}
		}

		/// <summary>Occurs when a text frame loses the current text input position and another part of the document such as a header, a footer or the main text gets it.</summary>
		[Attribute3("EVENT_TEXTFRAMEDEACTIVATED")]
		[Attribute2("CAT_TEXTFRAMES")]
		public event TextFrameEventHandler TextFrameDeactivated
		{
			add
			{
				TextFrameEventHandler textFrameEventHandler = this.textFrameEventHandler_8;
				TextFrameEventHandler textFrameEventHandler2;
				do
				{
					textFrameEventHandler2 = textFrameEventHandler;
					TextFrameEventHandler value2 = (TextFrameEventHandler)Delegate.Combine(textFrameEventHandler2, value);
					textFrameEventHandler = Interlocked.CompareExchange(ref this.textFrameEventHandler_8, value2, textFrameEventHandler2);
				}
				while ((object)textFrameEventHandler != textFrameEventHandler2);
			}
			remove
			{
				TextFrameEventHandler textFrameEventHandler = this.textFrameEventHandler_8;
				TextFrameEventHandler textFrameEventHandler2;
				do
				{
					textFrameEventHandler2 = textFrameEventHandler;
					TextFrameEventHandler value2 = (TextFrameEventHandler)Delegate.Remove(textFrameEventHandler2, value);
					textFrameEventHandler = Interlocked.CompareExchange(ref this.textFrameEventHandler_8, value2, textFrameEventHandler2);
				}
				while ((object)textFrameEventHandler != textFrameEventHandler2);
			}
		}

		/// <summary>Occurs when a text frame has been selected.</summary>
		[Attribute2("CAT_TEXTFRAMES")]
		[Attribute3("EVENT_TEXTFRAMESELECTED")]
		public event TextFrameEventHandler TextFrameSelected
		{
			add
			{
				TextFrameEventHandler textFrameEventHandler = this.textFrameEventHandler_9;
				TextFrameEventHandler textFrameEventHandler2;
				do
				{
					textFrameEventHandler2 = textFrameEventHandler;
					TextFrameEventHandler value2 = (TextFrameEventHandler)Delegate.Combine(textFrameEventHandler2, value);
					textFrameEventHandler = Interlocked.CompareExchange(ref this.textFrameEventHandler_9, value2, textFrameEventHandler2);
				}
				while ((object)textFrameEventHandler != textFrameEventHandler2);
			}
			remove
			{
				TextFrameEventHandler textFrameEventHandler = this.textFrameEventHandler_9;
				TextFrameEventHandler textFrameEventHandler2;
				do
				{
					textFrameEventHandler2 = textFrameEventHandler;
					TextFrameEventHandler value2 = (TextFrameEventHandler)Delegate.Remove(textFrameEventHandler2, value);
					textFrameEventHandler = Interlocked.CompareExchange(ref this.textFrameEventHandler_9, value2, textFrameEventHandler2);
				}
				while ((object)textFrameEventHandler != textFrameEventHandler2);
			}
		}

		/// <summary>Occurs when a text frame has been deselected.</summary>
		[Attribute2("CAT_TEXTFRAMES")]
		[Attribute3("EVENT_TEXTFRAMEDESELECTED")]
		public event TextFrameEventHandler TextFrameDeselected
		{
			add
			{
				TextFrameEventHandler textFrameEventHandler = this.textFrameEventHandler_10;
				TextFrameEventHandler textFrameEventHandler2;
				do
				{
					textFrameEventHandler2 = textFrameEventHandler;
					TextFrameEventHandler value2 = (TextFrameEventHandler)Delegate.Combine(textFrameEventHandler2, value);
					textFrameEventHandler = Interlocked.CompareExchange(ref this.textFrameEventHandler_10, value2, textFrameEventHandler2);
				}
				while ((object)textFrameEventHandler != textFrameEventHandler2);
			}
			remove
			{
				TextFrameEventHandler textFrameEventHandler = this.textFrameEventHandler_10;
				TextFrameEventHandler textFrameEventHandler2;
				do
				{
					textFrameEventHandler2 = textFrameEventHandler;
					TextFrameEventHandler value2 = (TextFrameEventHandler)Delegate.Remove(textFrameEventHandler2, value);
					textFrameEventHandler = Interlocked.CompareExchange(ref this.textFrameEventHandler_10, value2, textFrameEventHandler2);
				}
				while ((object)textFrameEventHandler != textFrameEventHandler2);
			}
		}

		/// <summary>Occurs when the appearance of a text frame (background color, transparency, border, inner margins) has been changed.</summary>
		[Attribute2("CAT_TEXTFRAMES")]
		[Attribute3("EVENT_TEXTFRAMEAPPEARANCECHANGED")]
		public event TextFrameEventHandler TextFrameAppearanceChanged
		{
			add
			{
				TextFrameEventHandler textFrameEventHandler = this.textFrameEventHandler_11;
				TextFrameEventHandler textFrameEventHandler2;
				do
				{
					textFrameEventHandler2 = textFrameEventHandler;
					TextFrameEventHandler value2 = (TextFrameEventHandler)Delegate.Combine(textFrameEventHandler2, value);
					textFrameEventHandler = Interlocked.CompareExchange(ref this.textFrameEventHandler_11, value2, textFrameEventHandler2);
				}
				while ((object)textFrameEventHandler != textFrameEventHandler2);
			}
			remove
			{
				TextFrameEventHandler textFrameEventHandler = this.textFrameEventHandler_11;
				TextFrameEventHandler textFrameEventHandler2;
				do
				{
					textFrameEventHandler2 = textFrameEventHandler;
					TextFrameEventHandler value2 = (TextFrameEventHandler)Delegate.Remove(textFrameEventHandler2, value);
					textFrameEventHandler = Interlocked.CompareExchange(ref this.textFrameEventHandler_11, value2, textFrameEventHandler2);
				}
				while ((object)textFrameEventHandler != textFrameEventHandler2);
			}
		}

		/// <summary>Occurs when a chart has been clicked on.</summary>
		[Attribute3("EVENT_CHARTCLICKED")]
		[Attribute2("CAT_CHARTS")]
		public event ChartEventHandler ChartClicked
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

		/// <summary>Occurs when a new chart has been created.</summary>
		[Attribute2("CAT_CHARTS")]
		[Attribute3("EVENT_CHARTCREATED")]
		public event ChartEventHandler ChartCreated
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

		/// <summary>Occurs when a chart has been deleted.</summary>
		[Attribute2("CAT_CHARTS")]
		[Attribute3("EVENT_CHARTDELETED")]
		public event ChartEventHandler ChartDeleted
		{
			add
			{
				ChartEventHandler chartEventHandler = this.chartEventHandler_2;
				ChartEventHandler chartEventHandler2;
				do
				{
					chartEventHandler2 = chartEventHandler;
					ChartEventHandler value2 = (ChartEventHandler)Delegate.Combine(chartEventHandler2, value);
					chartEventHandler = Interlocked.CompareExchange(ref this.chartEventHandler_2, value2, chartEventHandler2);
				}
				while ((object)chartEventHandler != chartEventHandler2);
			}
			remove
			{
				ChartEventHandler chartEventHandler = this.chartEventHandler_2;
				ChartEventHandler chartEventHandler2;
				do
				{
					chartEventHandler2 = chartEventHandler;
					ChartEventHandler value2 = (ChartEventHandler)Delegate.Remove(chartEventHandler2, value);
					chartEventHandler = Interlocked.CompareExchange(ref this.chartEventHandler_2, value2, chartEventHandler2);
				}
				while ((object)chartEventHandler != chartEventHandler2);
			}
		}

		/// <summary>Occurs when a chart has been doubleclicked on.</summary>
		[Attribute3("EVENT_CHARTDOUBLECLICKED")]
		[Attribute2("CAT_CHARTS")]
		public event ChartEventHandler ChartDoubleClicked
		{
			add
			{
				ChartEventHandler chartEventHandler = this.chartEventHandler_3;
				ChartEventHandler chartEventHandler2;
				do
				{
					chartEventHandler2 = chartEventHandler;
					ChartEventHandler value2 = (ChartEventHandler)Delegate.Combine(chartEventHandler2, value);
					chartEventHandler = Interlocked.CompareExchange(ref this.chartEventHandler_3, value2, chartEventHandler2);
				}
				while ((object)chartEventHandler != chartEventHandler2);
			}
			remove
			{
				ChartEventHandler chartEventHandler = this.chartEventHandler_3;
				ChartEventHandler chartEventHandler2;
				do
				{
					chartEventHandler2 = chartEventHandler;
					ChartEventHandler value2 = (ChartEventHandler)Delegate.Remove(chartEventHandler2, value);
					chartEventHandler = Interlocked.CompareExchange(ref this.chartEventHandler_3, value2, chartEventHandler2);
				}
				while ((object)chartEventHandler != chartEventHandler2);
			}
		}

		/// <summary>Occurs when a chart has been moved.</summary>
		[Attribute3("EVENT_CHARTMOVED")]
		[Attribute2("CAT_CHARTS")]
		public event ChartEventHandler ChartMoved
		{
			add
			{
				ChartEventHandler chartEventHandler = this.chartEventHandler_4;
				ChartEventHandler chartEventHandler2;
				do
				{
					chartEventHandler2 = chartEventHandler;
					ChartEventHandler value2 = (ChartEventHandler)Delegate.Combine(chartEventHandler2, value);
					chartEventHandler = Interlocked.CompareExchange(ref this.chartEventHandler_4, value2, chartEventHandler2);
				}
				while ((object)chartEventHandler != chartEventHandler2);
			}
			remove
			{
				ChartEventHandler chartEventHandler = this.chartEventHandler_4;
				ChartEventHandler chartEventHandler2;
				do
				{
					chartEventHandler2 = chartEventHandler;
					ChartEventHandler value2 = (ChartEventHandler)Delegate.Remove(chartEventHandler2, value);
					chartEventHandler = Interlocked.CompareExchange(ref this.chartEventHandler_4, value2, chartEventHandler2);
				}
				while ((object)chartEventHandler != chartEventHandler2);
			}
		}

		/// <summary>Occurs when a chart has been sized.</summary>
		[Attribute3("EVENT_CHARTSIZED")]
		[Attribute2("CAT_CHARTS")]
		public event ChartEventHandler ChartSized
		{
			add
			{
				ChartEventHandler chartEventHandler = this.chartEventHandler_5;
				ChartEventHandler chartEventHandler2;
				do
				{
					chartEventHandler2 = chartEventHandler;
					ChartEventHandler value2 = (ChartEventHandler)Delegate.Combine(chartEventHandler2, value);
					chartEventHandler = Interlocked.CompareExchange(ref this.chartEventHandler_5, value2, chartEventHandler2);
				}
				while ((object)chartEventHandler != chartEventHandler2);
			}
			remove
			{
				ChartEventHandler chartEventHandler = this.chartEventHandler_5;
				ChartEventHandler chartEventHandler2;
				do
				{
					chartEventHandler2 = chartEventHandler;
					ChartEventHandler value2 = (ChartEventHandler)Delegate.Remove(chartEventHandler2, value);
					chartEventHandler = Interlocked.CompareExchange(ref this.chartEventHandler_5, value2, chartEventHandler2);
				}
				while ((object)chartEventHandler != chartEventHandler2);
			}
		}

		/// <summary>Occurs when a chart has been clicked on with the right mouse button.</summary>
		[Attribute3("EVENT_CHARTRIGHTCLICKED")]
		[Attribute2("CAT_CHARTS")]
		public event ChartEventHandler ChartRightClicked
		{
			add
			{
				ChartEventHandler chartEventHandler = this.chartEventHandler_6;
				ChartEventHandler chartEventHandler2;
				do
				{
					chartEventHandler2 = chartEventHandler;
					ChartEventHandler value2 = (ChartEventHandler)Delegate.Combine(chartEventHandler2, value);
					chartEventHandler = Interlocked.CompareExchange(ref this.chartEventHandler_6, value2, chartEventHandler2);
				}
				while ((object)chartEventHandler != chartEventHandler2);
			}
			remove
			{
				ChartEventHandler chartEventHandler = this.chartEventHandler_6;
				ChartEventHandler chartEventHandler2;
				do
				{
					chartEventHandler2 = chartEventHandler;
					ChartEventHandler value2 = (ChartEventHandler)Delegate.Remove(chartEventHandler2, value);
					chartEventHandler = Interlocked.CompareExchange(ref this.chartEventHandler_6, value2, chartEventHandler2);
				}
				while ((object)chartEventHandler != chartEventHandler2);
			}
		}

		/// <summary>Occurs when a chart has been selected.</summary>
		[Attribute3("EVENT_CHARTSELECTED")]
		[Attribute2("CAT_CHARTS")]
		public event ChartEventHandler ChartSelected
		{
			add
			{
				ChartEventHandler chartEventHandler = this.chartEventHandler_7;
				ChartEventHandler chartEventHandler2;
				do
				{
					chartEventHandler2 = chartEventHandler;
					ChartEventHandler value2 = (ChartEventHandler)Delegate.Combine(chartEventHandler2, value);
					chartEventHandler = Interlocked.CompareExchange(ref this.chartEventHandler_7, value2, chartEventHandler2);
				}
				while ((object)chartEventHandler != chartEventHandler2);
			}
			remove
			{
				ChartEventHandler chartEventHandler = this.chartEventHandler_7;
				ChartEventHandler chartEventHandler2;
				do
				{
					chartEventHandler2 = chartEventHandler;
					ChartEventHandler value2 = (ChartEventHandler)Delegate.Remove(chartEventHandler2, value);
					chartEventHandler = Interlocked.CompareExchange(ref this.chartEventHandler_7, value2, chartEventHandler2);
				}
				while ((object)chartEventHandler != chartEventHandler2);
			}
		}

		/// <summary>Occurs when a chart has been deselected.</summary>
		[Attribute3("EVENT_CHARTDESELECTED")]
		[Attribute2("CAT_CHARTS")]
		public event ChartEventHandler ChartDeselected
		{
			add
			{
				ChartEventHandler chartEventHandler = this.chartEventHandler_8;
				ChartEventHandler chartEventHandler2;
				do
				{
					chartEventHandler2 = chartEventHandler;
					ChartEventHandler value2 = (ChartEventHandler)Delegate.Combine(chartEventHandler2, value);
					chartEventHandler = Interlocked.CompareExchange(ref this.chartEventHandler_8, value2, chartEventHandler2);
				}
				while ((object)chartEventHandler != chartEventHandler2);
			}
			remove
			{
				ChartEventHandler chartEventHandler = this.chartEventHandler_8;
				ChartEventHandler chartEventHandler2;
				do
				{
					chartEventHandler2 = chartEventHandler;
					ChartEventHandler value2 = (ChartEventHandler)Delegate.Remove(chartEventHandler2, value);
					chartEventHandler = Interlocked.CompareExchange(ref this.chartEventHandler_8, value2, chartEventHandler2);
				}
				while ((object)chartEventHandler != chartEventHandler2);
			}
		}

		/// <summary>Occurs when a barcode has been clicked on.</summary>
		[Attribute3("EVENT_BARCODECLICKED")]
		[Attribute2("CAT_BARCODES")]
		public event BarcodeEventHandler BarcodeClicked
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

		/// <summary>Occurs when a new barcode has been created.</summary>
		[Attribute3("EVENT_BARCODECREATED")]
		[Attribute2("CAT_BARCODES")]
		public event BarcodeEventHandler BarcodeCreated
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

		/// <summary>Occurs when a barcode has been deleted.</summary>
		[Attribute2("CAT_BARCODES")]
		[Attribute3("EVENT_BARCODEDELETED")]
		public event BarcodeEventHandler BarcodeDeleted
		{
			add
			{
				BarcodeEventHandler barcodeEventHandler = this.barcodeEventHandler_2;
				BarcodeEventHandler barcodeEventHandler2;
				do
				{
					barcodeEventHandler2 = barcodeEventHandler;
					BarcodeEventHandler value2 = (BarcodeEventHandler)Delegate.Combine(barcodeEventHandler2, value);
					barcodeEventHandler = Interlocked.CompareExchange(ref this.barcodeEventHandler_2, value2, barcodeEventHandler2);
				}
				while ((object)barcodeEventHandler != barcodeEventHandler2);
			}
			remove
			{
				BarcodeEventHandler barcodeEventHandler = this.barcodeEventHandler_2;
				BarcodeEventHandler barcodeEventHandler2;
				do
				{
					barcodeEventHandler2 = barcodeEventHandler;
					BarcodeEventHandler value2 = (BarcodeEventHandler)Delegate.Remove(barcodeEventHandler2, value);
					barcodeEventHandler = Interlocked.CompareExchange(ref this.barcodeEventHandler_2, value2, barcodeEventHandler2);
				}
				while ((object)barcodeEventHandler != barcodeEventHandler2);
			}
		}

		/// <summary>Occurs when a barcode has been doubleclicked on.</summary>
		[Attribute2("CAT_BARCODES")]
		[Attribute3("EVENT_BARCODEDOUBLECLICKED")]
		public event BarcodeEventHandler BarcodeDoubleClicked
		{
			add
			{
				BarcodeEventHandler barcodeEventHandler = this.barcodeEventHandler_3;
				BarcodeEventHandler barcodeEventHandler2;
				do
				{
					barcodeEventHandler2 = barcodeEventHandler;
					BarcodeEventHandler value2 = (BarcodeEventHandler)Delegate.Combine(barcodeEventHandler2, value);
					barcodeEventHandler = Interlocked.CompareExchange(ref this.barcodeEventHandler_3, value2, barcodeEventHandler2);
				}
				while ((object)barcodeEventHandler != barcodeEventHandler2);
			}
			remove
			{
				BarcodeEventHandler barcodeEventHandler = this.barcodeEventHandler_3;
				BarcodeEventHandler barcodeEventHandler2;
				do
				{
					barcodeEventHandler2 = barcodeEventHandler;
					BarcodeEventHandler value2 = (BarcodeEventHandler)Delegate.Remove(barcodeEventHandler2, value);
					barcodeEventHandler = Interlocked.CompareExchange(ref this.barcodeEventHandler_3, value2, barcodeEventHandler2);
				}
				while ((object)barcodeEventHandler != barcodeEventHandler2);
			}
		}

		/// <summary>Occurs when a barcode has been moved.</summary>
		[Attribute3("EVENT_BARCODEMOVED")]
		[Attribute2("CAT_BARCODES")]
		public event BarcodeEventHandler BarcodeMoved
		{
			add
			{
				BarcodeEventHandler barcodeEventHandler = this.barcodeEventHandler_4;
				BarcodeEventHandler barcodeEventHandler2;
				do
				{
					barcodeEventHandler2 = barcodeEventHandler;
					BarcodeEventHandler value2 = (BarcodeEventHandler)Delegate.Combine(barcodeEventHandler2, value);
					barcodeEventHandler = Interlocked.CompareExchange(ref this.barcodeEventHandler_4, value2, barcodeEventHandler2);
				}
				while ((object)barcodeEventHandler != barcodeEventHandler2);
			}
			remove
			{
				BarcodeEventHandler barcodeEventHandler = this.barcodeEventHandler_4;
				BarcodeEventHandler barcodeEventHandler2;
				do
				{
					barcodeEventHandler2 = barcodeEventHandler;
					BarcodeEventHandler value2 = (BarcodeEventHandler)Delegate.Remove(barcodeEventHandler2, value);
					barcodeEventHandler = Interlocked.CompareExchange(ref this.barcodeEventHandler_4, value2, barcodeEventHandler2);
				}
				while ((object)barcodeEventHandler != barcodeEventHandler2);
			}
		}

		/// <summary>Occurs when a barcode has been sized.</summary>
		[Attribute3("EVENT_BARCODESIZED")]
		[Attribute2("CAT_BARCODES")]
		public event BarcodeEventHandler BarcodeSized
		{
			add
			{
				BarcodeEventHandler barcodeEventHandler = this.barcodeEventHandler_5;
				BarcodeEventHandler barcodeEventHandler2;
				do
				{
					barcodeEventHandler2 = barcodeEventHandler;
					BarcodeEventHandler value2 = (BarcodeEventHandler)Delegate.Combine(barcodeEventHandler2, value);
					barcodeEventHandler = Interlocked.CompareExchange(ref this.barcodeEventHandler_5, value2, barcodeEventHandler2);
				}
				while ((object)barcodeEventHandler != barcodeEventHandler2);
			}
			remove
			{
				BarcodeEventHandler barcodeEventHandler = this.barcodeEventHandler_5;
				BarcodeEventHandler barcodeEventHandler2;
				do
				{
					barcodeEventHandler2 = barcodeEventHandler;
					BarcodeEventHandler value2 = (BarcodeEventHandler)Delegate.Remove(barcodeEventHandler2, value);
					barcodeEventHandler = Interlocked.CompareExchange(ref this.barcodeEventHandler_5, value2, barcodeEventHandler2);
				}
				while ((object)barcodeEventHandler != barcodeEventHandler2);
			}
		}

		/// <summary>Occurs when a barcode has been clicked on with the right mouse button.</summary>
		[Attribute2("CAT_BARCODES")]
		[Attribute3("EVENT_BARCODERIGHTCLICKED")]
		public event BarcodeEventHandler BarcodeRightClicked
		{
			add
			{
				BarcodeEventHandler barcodeEventHandler = this.barcodeEventHandler_6;
				BarcodeEventHandler barcodeEventHandler2;
				do
				{
					barcodeEventHandler2 = barcodeEventHandler;
					BarcodeEventHandler value2 = (BarcodeEventHandler)Delegate.Combine(barcodeEventHandler2, value);
					barcodeEventHandler = Interlocked.CompareExchange(ref this.barcodeEventHandler_6, value2, barcodeEventHandler2);
				}
				while ((object)barcodeEventHandler != barcodeEventHandler2);
			}
			remove
			{
				BarcodeEventHandler barcodeEventHandler = this.barcodeEventHandler_6;
				BarcodeEventHandler barcodeEventHandler2;
				do
				{
					barcodeEventHandler2 = barcodeEventHandler;
					BarcodeEventHandler value2 = (BarcodeEventHandler)Delegate.Remove(barcodeEventHandler2, value);
					barcodeEventHandler = Interlocked.CompareExchange(ref this.barcodeEventHandler_6, value2, barcodeEventHandler2);
				}
				while ((object)barcodeEventHandler != barcodeEventHandler2);
			}
		}

		/// <summary>Occurs when a barcode has been selected.</summary>
		[Attribute2("CAT_BARCODES")]
		[Attribute3("EVENT_BARCODESELECTED")]
		public event BarcodeEventHandler BarcodeSelected
		{
			add
			{
				BarcodeEventHandler barcodeEventHandler = this.barcodeEventHandler_7;
				BarcodeEventHandler barcodeEventHandler2;
				do
				{
					barcodeEventHandler2 = barcodeEventHandler;
					BarcodeEventHandler value2 = (BarcodeEventHandler)Delegate.Combine(barcodeEventHandler2, value);
					barcodeEventHandler = Interlocked.CompareExchange(ref this.barcodeEventHandler_7, value2, barcodeEventHandler2);
				}
				while ((object)barcodeEventHandler != barcodeEventHandler2);
			}
			remove
			{
				BarcodeEventHandler barcodeEventHandler = this.barcodeEventHandler_7;
				BarcodeEventHandler barcodeEventHandler2;
				do
				{
					barcodeEventHandler2 = barcodeEventHandler;
					BarcodeEventHandler value2 = (BarcodeEventHandler)Delegate.Remove(barcodeEventHandler2, value);
					barcodeEventHandler = Interlocked.CompareExchange(ref this.barcodeEventHandler_7, value2, barcodeEventHandler2);
				}
				while ((object)barcodeEventHandler != barcodeEventHandler2);
			}
		}

		/// <summary>Occurs when a barcode has been deselected.</summary>
		[Attribute3("EVENT_BARCODEDESELECTED")]
		[Attribute2("CAT_BARCODES")]
		public event BarcodeEventHandler BarcodeDeselected
		{
			add
			{
				BarcodeEventHandler barcodeEventHandler = this.barcodeEventHandler_8;
				BarcodeEventHandler barcodeEventHandler2;
				do
				{
					barcodeEventHandler2 = barcodeEventHandler;
					BarcodeEventHandler value2 = (BarcodeEventHandler)Delegate.Combine(barcodeEventHandler2, value);
					barcodeEventHandler = Interlocked.CompareExchange(ref this.barcodeEventHandler_8, value2, barcodeEventHandler2);
				}
				while ((object)barcodeEventHandler != barcodeEventHandler2);
			}
			remove
			{
				BarcodeEventHandler barcodeEventHandler = this.barcodeEventHandler_8;
				BarcodeEventHandler barcodeEventHandler2;
				do
				{
					barcodeEventHandler2 = barcodeEventHandler;
					BarcodeEventHandler value2 = (BarcodeEventHandler)Delegate.Remove(barcodeEventHandler2, value);
					barcodeEventHandler = Interlocked.CompareExchange(ref this.barcodeEventHandler_8, value2, barcodeEventHandler2);
				}
				while ((object)barcodeEventHandler != barcodeEventHandler2);
			}
		}

		/// <summary>Occurs when a drawing has been clicked on.</summary>
		[Attribute2("CAT_DRAWINGS")]
		[Attribute3("EVENT_DRAWINGCLICKED")]
		public event DrawingEventHandler DrawingClicked
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

		/// <summary>Occurs when a new drawing has been created.</summary>
		[Attribute2("CAT_DRAWINGS")]
		[Attribute3("EVENT_DRAWINGCREATED")]
		public event DrawingEventHandler DrawingCreated
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

		/// <summary>Occurs when a drawing has been deleted.</summary>
		[Attribute3("EVENT_DRAWINGDELETED")]
		[Attribute2("CAT_DRAWINGS")]
		public event DrawingEventHandler DrawingDeleted
		{
			add
			{
				DrawingEventHandler drawingEventHandler = this.drawingEventHandler_2;
				DrawingEventHandler drawingEventHandler2;
				do
				{
					drawingEventHandler2 = drawingEventHandler;
					DrawingEventHandler value2 = (DrawingEventHandler)Delegate.Combine(drawingEventHandler2, value);
					drawingEventHandler = Interlocked.CompareExchange(ref this.drawingEventHandler_2, value2, drawingEventHandler2);
				}
				while ((object)drawingEventHandler != drawingEventHandler2);
			}
			remove
			{
				DrawingEventHandler drawingEventHandler = this.drawingEventHandler_2;
				DrawingEventHandler drawingEventHandler2;
				do
				{
					drawingEventHandler2 = drawingEventHandler;
					DrawingEventHandler value2 = (DrawingEventHandler)Delegate.Remove(drawingEventHandler2, value);
					drawingEventHandler = Interlocked.CompareExchange(ref this.drawingEventHandler_2, value2, drawingEventHandler2);
				}
				while ((object)drawingEventHandler != drawingEventHandler2);
			}
		}

		/// <summary>Occurs when a drawing has been doubleclicked on.</summary>
		[Attribute2("CAT_DRAWINGS")]
		[Attribute3("EVENT_DRAWINGDOUBLECLICKED")]
		public event DrawingEventHandler DrawingDoubleClicked
		{
			add
			{
				DrawingEventHandler drawingEventHandler = this.drawingEventHandler_3;
				DrawingEventHandler drawingEventHandler2;
				do
				{
					drawingEventHandler2 = drawingEventHandler;
					DrawingEventHandler value2 = (DrawingEventHandler)Delegate.Combine(drawingEventHandler2, value);
					drawingEventHandler = Interlocked.CompareExchange(ref this.drawingEventHandler_3, value2, drawingEventHandler2);
				}
				while ((object)drawingEventHandler != drawingEventHandler2);
			}
			remove
			{
				DrawingEventHandler drawingEventHandler = this.drawingEventHandler_3;
				DrawingEventHandler drawingEventHandler2;
				do
				{
					drawingEventHandler2 = drawingEventHandler;
					DrawingEventHandler value2 = (DrawingEventHandler)Delegate.Remove(drawingEventHandler2, value);
					drawingEventHandler = Interlocked.CompareExchange(ref this.drawingEventHandler_3, value2, drawingEventHandler2);
				}
				while ((object)drawingEventHandler != drawingEventHandler2);
			}
		}

		/// <summary>Occurs when a drawing has been moved.</summary>
		[Attribute3("EVENT_DRAWINGMOVED")]
		[Attribute2("CAT_DRAWINGS")]
		public event DrawingEventHandler DrawingMoved
		{
			add
			{
				DrawingEventHandler drawingEventHandler = this.drawingEventHandler_4;
				DrawingEventHandler drawingEventHandler2;
				do
				{
					drawingEventHandler2 = drawingEventHandler;
					DrawingEventHandler value2 = (DrawingEventHandler)Delegate.Combine(drawingEventHandler2, value);
					drawingEventHandler = Interlocked.CompareExchange(ref this.drawingEventHandler_4, value2, drawingEventHandler2);
				}
				while ((object)drawingEventHandler != drawingEventHandler2);
			}
			remove
			{
				DrawingEventHandler drawingEventHandler = this.drawingEventHandler_4;
				DrawingEventHandler drawingEventHandler2;
				do
				{
					drawingEventHandler2 = drawingEventHandler;
					DrawingEventHandler value2 = (DrawingEventHandler)Delegate.Remove(drawingEventHandler2, value);
					drawingEventHandler = Interlocked.CompareExchange(ref this.drawingEventHandler_4, value2, drawingEventHandler2);
				}
				while ((object)drawingEventHandler != drawingEventHandler2);
			}
		}

		/// <summary>Occurs when a drawing has been sized.</summary>
		[Attribute2("CAT_DRAWINGS")]
		[Attribute3("EVENT_DRAWINGSIZED")]
		public event DrawingEventHandler DrawingSized
		{
			add
			{
				DrawingEventHandler drawingEventHandler = this.drawingEventHandler_5;
				DrawingEventHandler drawingEventHandler2;
				do
				{
					drawingEventHandler2 = drawingEventHandler;
					DrawingEventHandler value2 = (DrawingEventHandler)Delegate.Combine(drawingEventHandler2, value);
					drawingEventHandler = Interlocked.CompareExchange(ref this.drawingEventHandler_5, value2, drawingEventHandler2);
				}
				while ((object)drawingEventHandler != drawingEventHandler2);
			}
			remove
			{
				DrawingEventHandler drawingEventHandler = this.drawingEventHandler_5;
				DrawingEventHandler drawingEventHandler2;
				do
				{
					drawingEventHandler2 = drawingEventHandler;
					DrawingEventHandler value2 = (DrawingEventHandler)Delegate.Remove(drawingEventHandler2, value);
					drawingEventHandler = Interlocked.CompareExchange(ref this.drawingEventHandler_5, value2, drawingEventHandler2);
				}
				while ((object)drawingEventHandler != drawingEventHandler2);
			}
		}

		/// <summary>Occurs when a drawing has been clicked on with the right mouse button.</summary>
		[Attribute3("EVENT_DRAWINGRIGHTCLICKED")]
		[Attribute2("CAT_DRAWINGS")]
		public event DrawingEventHandler DrawingRightClicked
		{
			add
			{
				DrawingEventHandler drawingEventHandler = this.drawingEventHandler_6;
				DrawingEventHandler drawingEventHandler2;
				do
				{
					drawingEventHandler2 = drawingEventHandler;
					DrawingEventHandler value2 = (DrawingEventHandler)Delegate.Combine(drawingEventHandler2, value);
					drawingEventHandler = Interlocked.CompareExchange(ref this.drawingEventHandler_6, value2, drawingEventHandler2);
				}
				while ((object)drawingEventHandler != drawingEventHandler2);
			}
			remove
			{
				DrawingEventHandler drawingEventHandler = this.drawingEventHandler_6;
				DrawingEventHandler drawingEventHandler2;
				do
				{
					drawingEventHandler2 = drawingEventHandler;
					DrawingEventHandler value2 = (DrawingEventHandler)Delegate.Remove(drawingEventHandler2, value);
					drawingEventHandler = Interlocked.CompareExchange(ref this.drawingEventHandler_6, value2, drawingEventHandler2);
				}
				while ((object)drawingEventHandler != drawingEventHandler2);
			}
		}

		/// <summary>Occurs when a drawing has been selected.</summary>
		[Attribute3("EVENT_DRAWINGSELECTED")]
		[Attribute2("CAT_DRAWINGS")]
		public event DrawingEventHandler DrawingSelected
		{
			add
			{
				DrawingEventHandler drawingEventHandler = this.drawingEventHandler_7;
				DrawingEventHandler drawingEventHandler2;
				do
				{
					drawingEventHandler2 = drawingEventHandler;
					DrawingEventHandler value2 = (DrawingEventHandler)Delegate.Combine(drawingEventHandler2, value);
					drawingEventHandler = Interlocked.CompareExchange(ref this.drawingEventHandler_7, value2, drawingEventHandler2);
				}
				while ((object)drawingEventHandler != drawingEventHandler2);
			}
			remove
			{
				DrawingEventHandler drawingEventHandler = this.drawingEventHandler_7;
				DrawingEventHandler drawingEventHandler2;
				do
				{
					drawingEventHandler2 = drawingEventHandler;
					DrawingEventHandler value2 = (DrawingEventHandler)Delegate.Remove(drawingEventHandler2, value);
					drawingEventHandler = Interlocked.CompareExchange(ref this.drawingEventHandler_7, value2, drawingEventHandler2);
				}
				while ((object)drawingEventHandler != drawingEventHandler2);
			}
		}

		/// <summary>Occurs when a drawing has been deselected.</summary>
		[Attribute3("EVENT_DRAWINGDESELECTED")]
		[Attribute2("CAT_DRAWINGS")]
		public event DrawingEventHandler DrawingDeselected
		{
			add
			{
				DrawingEventHandler drawingEventHandler = this.drawingEventHandler_8;
				DrawingEventHandler drawingEventHandler2;
				do
				{
					drawingEventHandler2 = drawingEventHandler;
					DrawingEventHandler value2 = (DrawingEventHandler)Delegate.Combine(drawingEventHandler2, value);
					drawingEventHandler = Interlocked.CompareExchange(ref this.drawingEventHandler_8, value2, drawingEventHandler2);
				}
				while ((object)drawingEventHandler != drawingEventHandler2);
			}
			remove
			{
				DrawingEventHandler drawingEventHandler = this.drawingEventHandler_8;
				DrawingEventHandler drawingEventHandler2;
				do
				{
					drawingEventHandler2 = drawingEventHandler;
					DrawingEventHandler value2 = (DrawingEventHandler)Delegate.Remove(drawingEventHandler2, value);
					drawingEventHandler = Interlocked.CompareExchange(ref this.drawingEventHandler_8, value2, drawingEventHandler2);
				}
				while ((object)drawingEventHandler != drawingEventHandler2);
			}
		}

		/// <summary>Occurs when a drawing has been activated.</summary>
		[Attribute2("CAT_DRAWINGS")]
		[Attribute3("EVENT_DRAWINGACTIVATED")]
		public event DrawingEventHandler DrawingActivated
		{
			add
			{
				DrawingEventHandler drawingEventHandler = this.drawingEventHandler_9;
				DrawingEventHandler drawingEventHandler2;
				do
				{
					drawingEventHandler2 = drawingEventHandler;
					DrawingEventHandler value2 = (DrawingEventHandler)Delegate.Combine(drawingEventHandler2, value);
					drawingEventHandler = Interlocked.CompareExchange(ref this.drawingEventHandler_9, value2, drawingEventHandler2);
				}
				while ((object)drawingEventHandler != drawingEventHandler2);
			}
			remove
			{
				DrawingEventHandler drawingEventHandler = this.drawingEventHandler_9;
				DrawingEventHandler drawingEventHandler2;
				do
				{
					drawingEventHandler2 = drawingEventHandler;
					DrawingEventHandler value2 = (DrawingEventHandler)Delegate.Remove(drawingEventHandler2, value);
					drawingEventHandler = Interlocked.CompareExchange(ref this.drawingEventHandler_9, value2, drawingEventHandler2);
				}
				while ((object)drawingEventHandler != drawingEventHandler2);
			}
		}

		/// <summary>Occurs when a drawing has been deactivated.</summary>
		[Attribute2("CAT_DRAWINGS")]
		[Attribute3("EVENT_DRAWINGDEACTIVATED")]
		public event DrawingEventHandler DrawingDeactivated
		{
			add
			{
				DrawingEventHandler drawingEventHandler = this.drawingEventHandler_10;
				DrawingEventHandler drawingEventHandler2;
				do
				{
					drawingEventHandler2 = drawingEventHandler;
					DrawingEventHandler value2 = (DrawingEventHandler)Delegate.Combine(drawingEventHandler2, value);
					drawingEventHandler = Interlocked.CompareExchange(ref this.drawingEventHandler_10, value2, drawingEventHandler2);
				}
				while ((object)drawingEventHandler != drawingEventHandler2);
			}
			remove
			{
				DrawingEventHandler drawingEventHandler = this.drawingEventHandler_10;
				DrawingEventHandler drawingEventHandler2;
				do
				{
					drawingEventHandler2 = drawingEventHandler;
					DrawingEventHandler value2 = (DrawingEventHandler)Delegate.Remove(drawingEventHandler2, value);
					drawingEventHandler = Interlocked.CompareExchange(ref this.drawingEventHandler_10, value2, drawingEventHandler2);
				}
				while ((object)drawingEventHandler != drawingEventHandler2);
			}
		}

		/// <summary>Occurs when a header or footer gets the current text input position from another part of the document such as a textframe or the main text.</summary>
		[Attribute3("EVENT_HFACTIVATED")]
		[Attribute2("CAT_HF")]
		public event HeaderFooterEventHandler HeaderFooterActivated
		{
			add
			{
				HeaderFooterEventHandler headerFooterEventHandler = this.headerFooterEventHandler_0;
				HeaderFooterEventHandler headerFooterEventHandler2;
				do
				{
					headerFooterEventHandler2 = headerFooterEventHandler;
					HeaderFooterEventHandler value2 = (HeaderFooterEventHandler)Delegate.Combine(headerFooterEventHandler2, value);
					headerFooterEventHandler = Interlocked.CompareExchange(ref this.headerFooterEventHandler_0, value2, headerFooterEventHandler2);
				}
				while ((object)headerFooterEventHandler != headerFooterEventHandler2);
			}
			remove
			{
				HeaderFooterEventHandler headerFooterEventHandler = this.headerFooterEventHandler_0;
				HeaderFooterEventHandler headerFooterEventHandler2;
				do
				{
					headerFooterEventHandler2 = headerFooterEventHandler;
					HeaderFooterEventHandler value2 = (HeaderFooterEventHandler)Delegate.Remove(headerFooterEventHandler2, value);
					headerFooterEventHandler = Interlocked.CompareExchange(ref this.headerFooterEventHandler_0, value2, headerFooterEventHandler2);
				}
				while ((object)headerFooterEventHandler != headerFooterEventHandler2);
			}
		}

		/// <summary>Occurs when a header or footer loses the current text input position and another part of the document such as a textframe or the main text gets it.</summary>
		[Attribute3("EVENT_HFDEACTIVATED")]
		[Attribute2("CAT_HF")]
		public event HeaderFooterEventHandler HeaderFooterDeactivated
		{
			add
			{
				HeaderFooterEventHandler headerFooterEventHandler = this.headerFooterEventHandler_1;
				HeaderFooterEventHandler headerFooterEventHandler2;
				do
				{
					headerFooterEventHandler2 = headerFooterEventHandler;
					HeaderFooterEventHandler value2 = (HeaderFooterEventHandler)Delegate.Combine(headerFooterEventHandler2, value);
					headerFooterEventHandler = Interlocked.CompareExchange(ref this.headerFooterEventHandler_1, value2, headerFooterEventHandler2);
				}
				while ((object)headerFooterEventHandler != headerFooterEventHandler2);
			}
			remove
			{
				HeaderFooterEventHandler headerFooterEventHandler = this.headerFooterEventHandler_1;
				HeaderFooterEventHandler headerFooterEventHandler2;
				do
				{
					headerFooterEventHandler2 = headerFooterEventHandler;
					HeaderFooterEventHandler value2 = (HeaderFooterEventHandler)Delegate.Remove(headerFooterEventHandler2, value);
					headerFooterEventHandler = Interlocked.CompareExchange(ref this.headerFooterEventHandler_1, value2, headerFooterEventHandler2);
				}
				while ((object)headerFooterEventHandler != headerFooterEventHandler2);
			}
		}

		/// <summary>Occurs after a new table has been created as a result of a text insertion via the clipboard or when loading a document which contains a table without an identifier.</summary>
		[Attribute2("CAT_TABLE")]
		[Attribute3("EVENT_TABLECREATED")]
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

		/// <summary>Occurs when the design attributes of a selected table have been changed.</summary>
		[Attribute3("EVENT_TABLEFORMATCHANGED")]
		[Attribute2("CAT_TABLE")]
		public event TableEventHandler TableFormatChanged
		{
			add
			{
				TableEventHandler tableEventHandler = this.tableEventHandler_2;
				TableEventHandler tableEventHandler2;
				do
				{
					tableEventHandler2 = tableEventHandler;
					TableEventHandler value2 = (TableEventHandler)Delegate.Combine(tableEventHandler2, value);
					tableEventHandler = Interlocked.CompareExchange(ref this.tableEventHandler_2, value2, tableEventHandler2);
				}
				while ((object)tableEventHandler != tableEventHandler2);
			}
			remove
			{
				TableEventHandler tableEventHandler = this.tableEventHandler_2;
				TableEventHandler tableEventHandler2;
				do
				{
					tableEventHandler2 = tableEventHandler;
					TableEventHandler value2 = (TableEventHandler)Delegate.Remove(tableEventHandler2, value);
					tableEventHandler = Interlocked.CompareExchange(ref this.tableEventHandler_2, value2, tableEventHandler2);
				}
				while ((object)tableEventHandler != tableEventHandler2);
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

		/// <summary>Occurs, if a word does not fit in the line and must be hyphenated.</summary>
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

		/// <summary>Occurs when a loaded XML document is not well-formed.</summary>
		[Attribute2("CAT_XML")]
		[Attribute3("EVENT_XMLNOTWELLFORMED")]
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
		[Attribute2("CAT_XML")]
		[Attribute3("EVENT_XMLINVALID")]
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

		internal event EventHandler IsFormFieldValidationEnabledChanged
		{
			add
			{
				EventHandler eventHandler = this.eventHandler_27;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange(ref this.eventHandler_27, value2, eventHandler2);
				}
				while ((object)eventHandler != eventHandler2);
			}
			remove
			{
				EventHandler eventHandler = this.eventHandler_27;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange(ref this.eventHandler_27, value2, eventHandler2);
				}
				while ((object)eventHandler != eventHandler2);
			}
		}

		/// <summary>Initializes a new instance of the TextControl class.</summary>
		public TextControl()
		{
			this.components = new Container();
			this.resources = new ResourceManager(typeof(TextControlCore));
			TypeDescriptor.AddProvider(new Class599(TypeDescriptor.GetProvider(typeof(TextControl))), typeof(TextControl));
			this.string_0 = "TX29_DOTNET";
			this.textControlCore_0 = new TextControlCore(this.resources, this, MeasuringUnit.CentiInch);
			this.inputPosition_0.method_0(this.textControlCore_0, TextPart.Auto);
			this.paragraphFormat_0.method_1(this.textControlCore_0, TextPart.Auto);
			this.listFormat_0.method_1(this.textControlCore_0, TextPart.Auto);
			this.autoSize_0.method_0(this.textControlCore_0);
			this.pageSize_0.method_1(this.textControlCore_0, 0);
			this.pageMargins_0.method_1(this.textControlCore_0, 0);
			this.inputFormat_0.method_6(this.textControlCore_0);
			this.bool_3 = base.AllowDrop;
			this.Font = new Font("Arial", 10f);
			this.delegate9_0 = method_26;
			this.delegate10_0 = method_27;
			this.delegate11_0 = method_29;
			this.delegate12_0 = method_28;
			this.eventHandler_0 = method_24;
			CreateHandle();
		}

		protected override void CreateHandle()
		{
			if (!SystemInformation.UserInteractive)
			{
				throw new InvalidOperationException(this.resources.GetString("ERR_CANNOTRUNONSERVER"));
			}
			this.class408 = new Class408();
			this.textControlCore_0.class408_0 = this.class408;
			base.CreateHandle();
		}

		protected override void DestroyHandle()
		{
			base.DestroyHandle();
			if (this.class408 != null)
			{
				this.class408.Dispose();
				this.class408 = null;
			}
		}

		/// <summary>Overridden. See Control.OnHandleCreated.</summary>
		/// <param name="e">Specifies an EventArgs object that contains the event data.</param>
		protected override void OnHandleCreated(EventArgs eventArgs_0)
		{
			base.OnHandleCreated(eventArgs_0);
			this.textControlCore_0.IntPtr_0 = base.Handle;
			this.textControlCore_0.method_30((Enum83)1348, 1, (int)Enum115.Enterprise);
			IntPtr intPtr = this.textControlCore_0.method_66(Enum83.const_151, 2u, 0);
			if (intPtr != IntPtr.Zero)
			{
				this.cursor_1 = new Cursor(intPtr);
			}
			intPtr = this.textControlCore_0.method_66(Enum83.const_151, 6u, 0);
			if (intPtr != IntPtr.Zero)
			{
				this.cursor_2 = new Cursor(intPtr);
			}
			intPtr = this.textControlCore_0.method_66(Enum83.const_151, 3u, 0);
			if (intPtr != IntPtr.Zero)
			{
				this.cursor_3 = new Cursor(intPtr);
			}
			intPtr = this.textControlCore_0.method_66(Enum83.const_151, 16u, 0);
			if (intPtr != IntPtr.Zero)
			{
				this.cursor_4 = new Cursor(intPtr);
			}
			intPtr = this.textControlCore_0.method_66(Enum83.const_151, 17u, 0);
			if (intPtr != IntPtr.Zero)
			{
				this.cursor_5 = new Cursor(intPtr);
				this.cursor_6 = this.cursor_5;
			}
			if (this.class415_0 != null)
			{
				this.class415_0.method_4();
			}
			this.colors_0.method_5(base.Handle);
			this.colors_0.method_1();
			this.fontSettings_0.method_0(this.textControlCore_0, this.delegate9_0);
			this.documentPermissions_1.method_0(this.textControlCore_0);
			if (this.string_2 != null)
			{
				this.textControlCore_0.method_3(this.string_2);
			}
			this.documentPermissions_0 = new DocumentPermissions(this.textControlCore_0, bActual: true);
			this.method_0();
			this.inputPosition_0.method_3();
			this.textControlCore_0.Boolean_1 = true;
			this.textControlCore_0.method_30(Enum83.const_30, 131072, 0);
			if (this.ribbon_0 != null)
			{
				this.ribbon_0.TextControl_0 = this;
			}
			this.method_40();
			if (this.Class456_0 != null)
			{
				this.Class456_0.method_17(this.bool_10);
			}
		}

		private void method_0()
		{
			this.textControlCore_0.method_30(Enum83.const_205, 0, 0);
			this.textControlCore_0.method_27(this.string_1);
			this.textControlCore_0.method_4(this.dialogUnit_0);
			this.textControlCore_0.method_30(Enum83.const_30, ((this.borderStyle_0 == BorderStyle.None) ? 4096 : 8) | (this.bool_5 ? 16 : 2048) | (this.bool_9 ? 1024 : 32) | ((this.insertionMode_0 == InsertionMode.Insert) ? 8192 : 4) | ((this.backgroundStyle_0 == BackgroundStyle.ColorScheme) ? 2097152 : 67108864) | (this.bool_19 ? 536870912 : 262144) | (this.bool_6 ? 1048576 : 134217728) | (this.bool_3 ? 4194304 : 33554432) | (this.bool_2 ? 8388608 : 16777216) | 0x80000, 0);
			this.method_30(this.color_0, this.viewMode_0);
			this.textControlCore_0.method_30(Enum83.const_41, (this.color_0 == SystemColors.Window) ? 1 : 0, Class429.smethod_0(this.color_0));
			this.textControlCore_0.method_30(Enum83.const_40, 0x80010 | ((this.selectionViewMode_0 == SelectionViewMode.TransparentBitmap) ? 65536 : int.MinValue), ((!this.bool_7) ? 1 : 32768) | (this.bool_17 ? 4 : 8192) | (this.bool_15 ? 64 : 1024) | (this.bool_11 ? 128 : 512) | ((this.formulaReferenceStyle_0 == FormulaReferenceStyle.R1C1) ? 256 : 65536) | (this.bool_8 ? int.MinValue : 131072) | (int)this.miniToolbarButton_0);
			this.textControlCore_0.method_39(Enum83.const_323, (this.editMode_0 == EditMode.Edit) ? 32768 : ((this.editMode_0 != EditMode.ReadAndSelect) ? 1 : 8), "");
			this.textControlCore_0.method_30(Enum83.const_227, this.Int32_0, (int)this.viewMode_0);
			this.textControlCore_0.method_30(Enum83.const_235, 0, this.bool_16 ? 1073741824 : int.MinValue);
			this.pageSize_0.Boolean_0 = this.bool_16;
			this.pageSize_0.method_2();
			this.pageSize_0.method_6();
			this.pageMargins_0.method_2();
			this.pageMargins_0.method_6();
			this.autoSize_0.method_5();
			this.textControlCore_0.method_30(Enum83.const_354, this.int_3, 0);
			if (this.viewMode_0 == ViewMode.FloatingText || this.viewMode_0 == ViewMode.SimpleControl)
			{
				base.SetStyle(ControlStyles.ResizeRedraw, value: true);
			}
			this.textControlCore_0.method_12(TextPart.Auto);
			this.textControlCore_0.method_9(TextPart.Auto);
			this.textControlCore_0.method_29(TextPart.Auto, 1160, (this.int_1 == 0) ? 2 : ((this.int_1 < 0) ? 8 : 4), Math.Abs(this.int_1));
			int[] array = new int[2]
			{
				Class429.smethod_0(this.ForeColor),
				Class429.smethod_0(this.TextBackColor)
			};
			this.textControlCore_0.method_40(TextPart.Auto, 1168, ((this.ForeColor == SystemColors.WindowText) ? 1 : 2) | ((this.TextBackColor == this.color_0) ? 16 : ((this.TextBackColor == SystemColors.Window) ? 4 : 8)), array);
			this.paragraphFormat_0.method_11();
			this.listFormat_0.method_8();
			this.listFormat_0.method_12();
			this.textControlCore_0.method_15(TextPart.Auto);
			if (this.int_2 != 0)
			{
				this.textControlCore_0.method_30(Enum83.const_67, 0, this.int_2);
			}
			this.textControlCore_0.method_30(Enum83.const_137, (int)this.headerFooterActivationStyle_0 | (int)this.headerFooterFrameStyle_0, 0);
			this.textControlCore_0.method_30(Enum83.const_273, (int)this.dropFormat_0, 0);
			this.textControlCore_0.method_30(Enum83.const_296, (int)this.permanentControlChar_0, 0);
			this.textControlCore_0.method_30(Enum83.const_43, 1, this.textControlCore_0.Boolean_2 ? int.MaxValue : int.MinValue);
			if (this.bool_13)
			{
				this.textControlCore_0.method_76(Enum83.const_275, 1, this.delegate10_0);
			}
			if (this.bool_14)
			{
				this.textControlCore_0.method_78(Enum83.const_38, 1, this.delegate11_0);
			}
			if (this.bool_12)
			{
				this.textControlCore_0.method_77(Enum83.const_275, 3, this.delegate12_0);
			}
			this.method_25();
			this.inputFormat_0.method_5((Enum84)0);
			if (this.bool_4)
			{
				this.textControlCore_0.method_30(Enum83.const_205, 1, 0);
			}
		}

		protected override void OnPaint(PaintEventArgs pea)
		{
			Graphics graphics = pea.Graphics;
			IntPtr hdc = graphics.GetHdc();
			try
			{
				this.textControlCore_0.method_30(Enum83.const_357, (int)hdc, 0);
			}
			catch (Exception ex)
			{
				throw ex;
			}
			finally
			{
				graphics.ReleaseHdc(hdc);
			}
		}

		/// <summary>Overridden. See Control.OnFontChanged.</summary>
		/// <param name="e">Specifies an EventArgs object that contains the event data.</param>
		protected override void OnFontChanged(EventArgs eventArgs_0)
		{
			if (base.IsHandleCreated)
			{
				this.textControlCore_0.method_12(TextPart.Auto);
				this.textControlCore_0.method_9(TextPart.Auto);
				this.textControlCore_0.method_15(TextPart.Auto);
			}
			base.OnFontChanged(eventArgs_0);
		}

		protected override void OnTextChanged(EventArgs eventArgs_0)
		{
			base.Invalidate();
			base.OnTextChanged(eventArgs_0);
		}

		protected override void OnDragEnter(DragEventArgs dea)
		{
			this.method_1(dea, out var struct74_);
			if (struct74_.idataObject_0 != null)
			{
				dea.Effect = (DragDropEffects)this.class408.method_8(base.Handle, Enum83.const_269, ref struct74_);
			}
			base.OnDragEnter(dea);
		}

		protected override void OnDragOver(DragEventArgs dea)
		{
			this.method_1(dea, out var struct74_);
			if (struct74_.idataObject_0 != null)
			{
				dea.Effect = (DragDropEffects)this.class408.method_8(base.Handle, Enum83.const_270, ref struct74_);
			}
			base.OnDragOver(dea);
		}

		protected override void OnDragLeave(EventArgs eventArgs_0)
		{
			Struct74 struct74_ = default(Struct74);
			this.class408.method_8(base.Handle, Enum83.const_271, ref struct74_);
			base.OnDragLeave(eventArgs_0);
		}

		protected override void OnDragDrop(DragEventArgs dea)
		{
			this.method_1(dea, out var struct74_);
			if (struct74_.idataObject_0 != null)
			{
				dea.Effect = (DragDropEffects)this.class408.method_8(base.Handle, Enum83.const_272, ref struct74_);
			}
			base.OnDragDrop(dea);
		}

		private void method_1(DragEventArgs dragEventArgs_0, out Struct74 struct74_0)
		{
			struct74_0.int_0 = dragEventArgs_0.X;
			struct74_0.int_1 = dragEventArgs_0.Y;
			struct74_0.bool_0 = false;
			struct74_0.int_2 = dragEventArgs_0.KeyState;
			struct74_0.uint_0 = (uint)dragEventArgs_0.AllowedEffect;
			struct74_0.idataObject_0 = dragEventArgs_0.Data as System.Runtime.InteropServices.ComTypes.IDataObject;
		}

		protected override void WndProc(ref Message message)
		{
			switch (message.Msg)
			{
			case 123:
				if (this.ContextMenuStrip != null)
				{
					base.WndProc(ref message);
				}
				else
				{
					this.DefWndProc(ref message);
				}
				break;
			case 61:
				message.Result = Class605.UiaReturnRawElementProvider(message.HWnd, message.WParam, message.LParam, this.Class603_0);
				break;
			case 513:
				this.DefWndProc(ref message);
				if (base.Enabled)
				{
					this.OnMouseDown(new MouseEventArgs(MouseButtons.Left, 1, (int)(long)message.LParam & 0xFFFF, ((int)(long)message.LParam >> 16) & 0xFFFF, 0));
				}
				break;
			case 273:
				if (!this.textControlCore_0.control5_0.IsControlHandle(message.LParam) && !this.textControlCore_0.control4_0.IsControlHandle(message.LParam) && !this.textControlCore_0.control6_0.IsControlHandle(message.LParam))
				{
					base.WndProc(ref message);
				}
				else
				{
					this.DefWndProc(ref message);
				}
				break;
			case 2052:
				this.method_20(ref message);
				this.method_19(ref message);
				this.method_21(ref message);
				break;
			case 738:
			case 739:
				this.DefWndProc(ref message);
				break;
			case 2081:
			{
				Struct68 @struct = (Struct68)message.GetLParam(typeof(Struct68));
				string strFilter = Marshal.PtrToStringUni(@struct.intptr_0);
				@struct.int_0 = ((ITextControl)this).OpenFileDialog(strFilter, out string strFileName);
				if (@struct.int_0 > 0 && strFileName != string.Empty)
				{
					@struct.intptr_1 = Marshal.StringToBSTR(strFileName);
					Marshal.StructureToPtr((object)@struct, message.LParam, fDeleteOld: false);
					message.Result = new IntPtr(1);
				}
				break;
			}
			case 2086:
				if (this.class415_0 != null)
				{
					CultureInfo[] cultureInfo_ = ((message.WParam.ToInt32() == 0) ? this.class415_0.method_44() : this.class415_0.method_43());
					message.Result = this.class415_0.method_45(cultureInfo_);
				}
				break;
			default:
				base.WndProc(ref message);
				break;
			case 2074:
			case 2075:
			case 2076:
			case 2078:
			case 2079:
			case 2080:
			case 2082:
			case 2083:
			case 2084:
			case 2085:
			case 2090:
			case 2091:
			case 2092:
				this.method_34(ref message);
				break;
			case 2093:
				message.Result = new IntPtr(this.textControlCore_0.method_28(Marshal.PtrToStringUni(message.WParam), Marshal.PtrToStringUni(message.LParam)) ? 1 : 0);
				break;
			case 2060:
				this.method_33(ref message);
				break;
			}
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				if (this.components != null)
				{
					this.components.Dispose();
				}				
			}
			if (this.cursor_1 != null)
			{
				this.cursor_1.Dispose();
			}
			if (this.cursor_2 != null)
			{
				this.cursor_2.Dispose();
			}
			if (this.cursor_3 != null)
			{
				this.cursor_3.Dispose();
			}
			if (this.cursor_4 != null)
			{
				this.cursor_4.Dispose();
			}
			if (this.cursor_5 != null)
			{
				this.cursor_5.Dispose();
			}
			base.Dispose(disposing);
			if (this.class408 != null)
			{
				this.class408.Dispose();
				this.class408 = null;
			}
			if (this.MiniToolbar_0 != null)
			{
				this.MiniToolbar_0.Dispose();
			}
			if (this.MiniToolbar_1 != null)
			{
				this.MiniToolbar_1.Dispose();
			}
		}

		internal bool method_2()
		{
			return true;
		}

		int ITextControl.OpenFileDialog(string strFilter, out string strFileName)
		{
			int result = 0;
			strFileName = string.Empty;
			OpenFileDialog openFileDialog = new OpenFileDialog();
			openFileDialog.Filter = strFilter;
			openFileDialog.FilterIndex = this.FileFilterIndex;
			if (openFileDialog.ShowDialog() == DialogResult.OK)
			{
				strFileName = openFileDialog.FileName;
				result = openFileDialog.FilterIndex;
			}
			return result;
		}

		int ITextControl.SaveFileDialog(string strFilter, out string strFileName)
		{
			int result = 0;
			strFileName = string.Empty;
			SaveFileDialog saveFileDialog = new SaveFileDialog();
			saveFileDialog.Filter = strFilter;
			saveFileDialog.FilterIndex = this.FileFilterIndex;
			if (saveFileDialog.ShowDialog() == DialogResult.OK)
			{
				strFileName = saveFileDialog.FileName;
				result = saveFileDialog.FilterIndex;
			}
			return result;
		}

		void ITextControl.CheckStreamType(StreamType iStreamType)
		{
			
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
			return (int)(this.Font.SizeInPoints * 20f);
		}

		string ITextControl.GetFontName()
		{
			return this.Font.FontFamily.Name;
		}

		FontUnderlineStyle ITextControl.GetFontUnderlineStyle()
		{
			if (!this.Font.Underline)
			{
				return FontUnderlineStyle.None;
			}
			return this.fontUnderlineStyle_0;
		}

		bool ITextControl.GetFontBold()
		{
			return this.Font.Bold;
		}

		bool ITextControl.GetFontItalic()
		{
			return this.Font.Italic;
		}

		bool ITextControl.GetFontStrikeout()
		{
			return this.Font.Strikeout;
		}

		int ITextControl.GetBackColor()
		{
			return Class429.smethod_0(this.color_0);
		}

		IConditionalInstructionsManager ITextControl.GetConditionalInstructionsManager()
		{
			return this.Class456_0;
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
			return Enum116.const_1;
		}

		string ITextControl.GetLicGUID()
		{
			return "0f31e9bf-ca6c-11ea-8338-a0481c909ac9";
		}

		string ITextControl.GetTrialSearchString()
		{
			return "TXSerialNoXXX";
		}

		/// <summary>Raises the Changed event.</summary>
		/// <param name="e">Specifies an EventArgs object that contains the event data.</param>
		protected virtual void OnChanged(EventArgs eventArgs_0)
		{
			if (this.eventHandler_1 != null)
			{
				this.eventHandler_1(this, eventArgs_0);
			}
		}

		/// <summary>Raises the FormattingStyleListChanged event.</summary>
		/// <param name="e">Specifies an EventArgs object that contains the event data.</param>
		protected virtual void OnFormattingStyleListChanged(EventArgs eventArgs_0)
		{
			if (this.eventHandler_2 != null)
			{
				this.eventHandler_2(this, eventArgs_0);
			}
		}

		/// <summary>Raises the InputFormattingStyleChanged event.</summary>
		/// <param name="e">Specifies an EventArgs object that contains the event data.</param>
		protected virtual void OnInputFormattingStyleChanged(EventArgs eventArgs_0)
		{
			if (this.eventHandler_3 != null)
			{
				this.eventHandler_3(this, eventArgs_0);
			}
		}

		/// <summary>Raises the FormattingStyleChanged event.</summary>
		/// <param name="e">Specifies an EventArgs object that contains the event data.</param>
		protected virtual void OnFormattingStyleChanged(EventArgs eventArgs_0)
		{
			if (this.eventHandler_4 != null)
			{
				this.eventHandler_4(this, eventArgs_0);
			}
		}

		/// <summary>Raises the InputPositionChanged event.</summary>
		/// <param name="e">Specifies an EventArgs object that contains the event data.</param>
		protected virtual void OnInputPositionChanged(EventArgs eventArgs_0)
		{
			if (this.eventHandler_5 != null)
			{
				this.eventHandler_5(this, eventArgs_0);
			}
		}

		/// <summary>Raises the InputParagraphChanged event.</summary>
		/// <param name="e">Specifies an EventArgs object that contains the event data.</param>
		protected virtual void OnInputParagraphChanged(EventArgs eventArgs_0)
		{
			if (this.eventHandler_6 != null)
			{
				this.eventHandler_6(this, eventArgs_0);
			}
		}

		/// <summary>Raises the HScroll event.</summary>
		/// <param name="e">Specifies an EventArgs object that contains the event data.</param>
		protected virtual void OnHScroll(EventArgs eventArgs_0)
		{
			if (this.eventHandler_7 != null)
			{
				this.eventHandler_7(this, eventArgs_0);
			}
		}

		/// <summary>Raises the VScroll event.</summary>
		/// <param name="e">Specifies an EventArgs object that contains the event data.</param>
		protected virtual void OnVScroll(EventArgs eventArgs_0)
		{
			if (this.eventHandler_8 != null)
			{
				this.eventHandler_8(this, eventArgs_0);
			}
		}

		/// <summary>Raises the Zoomed event.</summary>
		/// <param name="e">Specifies an EventArgs object that contains the event data.</param>
		protected virtual void OnZoomed(EventArgs eventArgs_0)
		{
			if (this.eventHandler_9 != null)
			{
				this.eventHandler_9(this, eventArgs_0);
			}
		}

		/// <summary>Raises the CharFormatChanged event.</summary>
		/// <param name="e">Specifies an EventArgs object that contains the event data.</param>
		protected virtual void OnCharFormatChanged(EventArgs eventArgs_0)
		{
			if (this.eventHandler_10 != null)
			{
				this.eventHandler_10(this, eventArgs_0);
			}
		}

		/// <summary>Raises the ParagraphFormatChanged event.</summary>
		/// <param name="e">Specifies an EventArgs object that contains the event data.</param>
		protected virtual void OnParagraphFormatChanged(EventArgs eventArgs_0)
		{
			if (this.eventHandler_11 != null)
			{
				this.eventHandler_11(this, eventArgs_0);
			}
		}

		/// <summary>Raises the PageFormatChanged event.</summary>
		/// <param name="e">Specifies an EventArgs object that contains the event data.</param>
		protected virtual void OnPageFormatChanged(EventArgs eventArgs_0)
		{
			if (this.eventHandler_12 != null)
			{
				this.eventHandler_12(this, eventArgs_0);
			}
		}

		/// <summary>Raises the HExpanded event.</summary>
		/// <param name="e">Specifies an EventArgs object that contains the event data.</param>
		protected virtual void OnHExpanded(EventArgs eventArgs_0)
		{
			if (this.eventHandler_13 != null)
			{
				this.eventHandler_13(this, eventArgs_0);
			}
		}

		/// <summary>Raises the VExpanded event.</summary>
		/// <param name="e">Specifies an EventArgs object that contains the event data.</param>
		protected virtual void OnVExpanded(EventArgs eventArgs_0)
		{
			if (this.eventHandler_14 != null)
			{
				this.eventHandler_14(this, eventArgs_0);
			}
		}

		/// <summary>Raises the HShrunk event.</summary>
		/// <param name="e">Specifies an EventArgs object that contains the event data.</param>
		protected virtual void OnHShrunk(EventArgs eventArgs_0)
		{
			if (this.eventHandler_15 != null)
			{
				this.eventHandler_15(this, eventArgs_0);
			}
		}

		/// <summary>Raises the VShrunk event.</summary>
		/// <param name="e">Specifies an EventArgs object that contains the event data.</param>
		protected virtual void OnVShrunk(EventArgs eventArgs_0)
		{
			if (this.eventHandler_16 != null)
			{
				this.eventHandler_16(this, eventArgs_0);
			}
		}

		/// <summary>Raises the AcceptsTabChanged event.</summary>
		/// <param name="e">Specifies an EventArgs object that contains the event data.</param>
		protected virtual void OnAcceptsTabChanged(EventArgs eventArgs_0)
		{
			if (this.eventHandler_17 != null)
			{
				this.eventHandler_17(this, eventArgs_0);
			}
		}

		/// <summary>Raises the BorderStyleChanged event.</summary>
		/// <param name="e">Specifies an EventArgs object that contains the event data.</param>
		protected virtual void OnBorderStyleChanged(EventArgs eventArgs_0)
		{
			if (this.eventHandler_18 != null)
			{
				this.eventHandler_18(this, eventArgs_0);
			}
		}

		/// <summary>Raises the PageChanged event.</summary>
		/// <param name="e">Specifies an EventArgs object that contains the event data.</param>
		protected virtual void OnPageChanged(EventArgs eventArgs_0)
		{
			if (this.eventHandler_19 != null)
			{
				this.eventHandler_19(this, eventArgs_0);
			}
		}

		/// <summary>Raises the SectionChanged event.</summary>
		/// <param name="e">Specifies an EventArgs object that contains the event data.</param>
		protected virtual void OnSectionChanged(EventArgs eventArgs_0)
		{
			if (this.eventHandler_20 != null)
			{
				this.eventHandler_20(this, eventArgs_0);
			}
		}

		/// <summary>Raises the DocumentLoaded event.</summary>
		/// <param name="e">Specifies an EventArgs object that contains the event data.</param>
		protected virtual void OnDocumentLoaded(EventArgs eventArgs_0)
		{
			if (this.eventHandler_21 != null)
			{
				this.eventHandler_21(this, eventArgs_0);
			}
		}

		/// <summary>Raises the ContentsReset event.</summary>
		/// <param name="e">Specifies an EventArgs object that contains the event data.</param>
		protected virtual void OnContentsReset(EventArgs eventArgs_0)
		{
			if (this.eventHandler_22 != null)
			{
				this.eventHandler_22(this, eventArgs_0);
			}
		}

		/// <summary>Raises the MainTextActivated event.</summary>
		/// <param name="e">Specifies an EventArgs object that contains the event data.</param>
		protected virtual void OnMainTextActivated(EventArgs eventArgs_0)
		{
			if (this.eventHandler_23 != null)
			{
				this.eventHandler_23(this, eventArgs_0);
			}
		}

		protected virtual void OnFocusChanged(EventArgs eventArgs_0)
		{
			if (this.eventHandler_24 != null)
			{
				this.eventHandler_24(this, eventArgs_0);
			}
		}

		protected virtual void OnHeaderFooterCreated(EventArgs eventArgs_0)
		{
			if (this.eventHandler_25 != null)
			{
				this.eventHandler_25(this, eventArgs_0);
			}
		}

		protected virtual void OnHeaderFooterDeleted(EventArgs eventArgs_0)
		{
			if (this.eventHandler_26 != null)
			{
				this.eventHandler_26(this, eventArgs_0);
			}
		}

		/// <summary>Raises the TextContextMenuOpening event.</summary>
		/// <param name="e">Specifies a TextContextMenuEventArgs object that contains the event data.</param>
		protected virtual void OnTextContextMenuOpening(TextContextMenuEventArgs textContextMenuEventArgs_0)
		{
			if (this.textContextMenuEventHandler_0 != null)
			{
				this.textContextMenuEventHandler_0(this, textContextMenuEventArgs_0);
			}
			if (!textContextMenuEventArgs_0.Cancel)
			{
				ContextMenuStrip textContextMenu = textContextMenuEventArgs_0.TextContextMenu;
				if (textContextMenu != null)
				{
					textContextMenu.Closing += method_4;
					textContextMenu.Show(textContextMenuEventArgs_0.Location);
					this.nullable_0 = textContextMenu.PointToScreen(default(Point));
					textContextMenuEventArgs_0.Cancel = true;
				}
			}
		}

		private void method_4(object sender, ToolStripDropDownClosingEventArgs e)
		{
			this.nullable_0 = null;
			if (sender is ContextMenuStrip)
			{
				(sender as ContextMenuStrip).Closing -= method_4;
			}
		}

		/// <summary>Raises the TextMiniToolbarInitialized event.</summary>
		/// <param name="e">Specifies a MiniToolbarInitializedEventArgs object that contains the event data.</param>
		protected virtual void OnTextMiniToolbarInitialized(MiniToolbarInitializedEventArgs miniToolbarInitializedEventArgs_0)
		{
			if (this.miniToolbarInitializedEventHandler_0 != null)
			{
				this.miniToolbarInitializedEventHandler_0(this, miniToolbarInitializedEventArgs_0);
			}
		}

		/// <summary>Raises the ObjectMiniToolbarInitialized event.</summary>
		/// <param name="e">Specifies a MiniToolbarInitializedEventArgs object that contains the event data.</param>
		protected virtual void OnObjectMiniToolbarInitialized(MiniToolbarInitializedEventArgs miniToolbarInitializedEventArgs_0)
		{
			if (this.miniToolbarInitializedEventHandler_1 != null)
			{
				this.miniToolbarInitializedEventHandler_1(this, miniToolbarInitializedEventArgs_0);
			}
		}

		/// <summary>Raises the MiniToolbarOpening event.</summary>
		/// <param name="e">Specifies a MiniToolbarOpeningEventArgs object that contains the event data.</param>
		protected virtual void OnMiniToolbarOpening(MiniToolbarOpeningEventArgs miniToolbarOpeningEventArgs_0)
		{
			if (this.miniToolbarOpeningEventHandler_0 != null)
			{
				this.miniToolbarOpeningEventHandler_0(this, miniToolbarOpeningEventArgs_0);
			}
			if (!miniToolbarOpeningEventArgs_0.Cancel)
			{
				MiniToolbar miniToolbar = (this.miniToolbar_0 = miniToolbarOpeningEventArgs_0.MiniToolbar);
				if (miniToolbar != null)
				{
					miniToolbar.method_5();
					miniToolbar.Closed += method_5;
					Point point = (this.nullable_0.HasValue ? this.nullable_0.Value : new Point(miniToolbarOpeningEventArgs_0.Location.X, miniToolbarOpeningEventArgs_0.Location.Y));
					miniToolbar.Show(new Point(point.X, point.Y - 15), ToolStripDropDownDirection.AboveRight);
					this.miniToolbar_0 = miniToolbar;
					miniToolbarOpeningEventArgs_0.Cancel = true;
				}
			}
		}

		private void method_5(object sender, ToolStripDropDownClosedEventArgs e)
		{
			this.miniToolbar_0 = null;
			if (sender is MiniToolbar)
			{
				(sender as MiniToolbar).Closed -= method_5;
			}
		}

		private void method_6()
		{
			if (this.propertyChangedEventHandler_0 != null)
			{
				this.propertyChangedEventHandler_0(this, new PropertyChangedEventArgs("CanCopy"));
			}
		}

		private void method_7()
		{
			if (this.propertyChangedEventHandler_0 != null)
			{
				this.propertyChangedEventHandler_0(this, new PropertyChangedEventArgs("CanPaste"));
			}
		}

		private void method_8()
		{
			if (this.propertyChangedEventHandler_0 != null)
			{
				this.propertyChangedEventHandler_0(this, new PropertyChangedEventArgs("CanUndo"));
			}
		}

		private void method_9()
		{
			if (this.propertyChangedEventHandler_0 != null)
			{
				this.propertyChangedEventHandler_0(this, new PropertyChangedEventArgs("CanRedo"));
			}
		}

		private void method_10()
		{
			if (this.propertyChangedEventHandler_0 != null)
			{
				this.propertyChangedEventHandler_0(this, new PropertyChangedEventArgs("CanPrint"));
			}
		}

		private void method_11()
		{
			if (this.propertyChangedEventHandler_0 != null)
			{
				this.propertyChangedEventHandler_0(this, new PropertyChangedEventArgs("CanEdit"));
			}
		}

		private void method_12()
		{
			if (this.propertyChangedEventHandler_0 != null)
			{
				this.propertyChangedEventHandler_0(this, new PropertyChangedEventArgs("CanCharacterFormat"));
			}
		}

		private void method_13()
		{
			if (this.propertyChangedEventHandler_0 != null)
			{
				this.propertyChangedEventHandler_0(this, new PropertyChangedEventArgs("CanParagraphFormat"));
			}
		}

		private void method_14()
		{
			if (this.propertyChangedEventHandler_0 != null)
			{
				this.propertyChangedEventHandler_0(this, new PropertyChangedEventArgs("CanTableFormat"));
			}
		}

		private void method_15()
		{
			if (this.propertyChangedEventHandler_0 != null)
			{
				this.propertyChangedEventHandler_0(this, new PropertyChangedEventArgs("CanStyleFormat"));
			}
		}

		private void method_16()
		{
			if (this.propertyChangedEventHandler_0 != null)
			{
				this.propertyChangedEventHandler_0(this, new PropertyChangedEventArgs("CanDocumentFormat"));
			}
		}

		private void method_17()
		{
			if (this.propertyChangedEventHandler_0 != null)
			{
				this.propertyChangedEventHandler_0(this, new PropertyChangedEventArgs("CanEditFormFields"));
			}
		}

		private void method_18()
		{
			this.editMode_0 = this.EditMode;
			if (this.propertyChangedEventHandler_0 != null)
			{
				this.propertyChangedEventHandler_0(this, new PropertyChangedEventArgs("EditMode"));
			}
		}

		/// <summary>Raises the TextFieldClicked event.</summary>
		/// <param name="e">Specifies a TextFieldEventArgs object that contains the event data.</param>
		protected virtual void OnTextFieldClicked(TextFieldEventArgs textFieldEventArgs_0)
		{
			if (this.textFieldEventHandler_0 != null)
			{
				this.textFieldEventHandler_0(this, textFieldEventArgs_0);
			}
		}

		/// <summary>Raises the TextFieldCreated event.</summary>
		/// <param name="e">Specifies a TextFieldEventArgs object that contains the event data.</param>
		protected virtual void OnTextFieldCreated(TextFieldEventArgs textFieldEventArgs_0)
		{
			if (this.textFieldEventHandler_1 != null)
			{
				this.textFieldEventHandler_1(this, textFieldEventArgs_0);
			}
		}

		/// <summary>Raises the TextFieldDoubleClicked event.</summary>
		/// <param name="e">Specifies a TextFieldEventArgs object that contains the event data.</param>
		protected virtual void OnTextFieldDoubleClicked(TextFieldEventArgs textFieldEventArgs_0)
		{
			if (this.textFieldEventHandler_2 != null)
			{
				this.textFieldEventHandler_2(this, textFieldEventArgs_0);
			}
		}

		/// <summary>Raises the TextFieldDeleted event.</summary>
		/// <param name="e">Specifies a TextFieldEventArgs object that contains the event data.</param>
		protected virtual void OnTextFieldDeleted(TextFieldEventArgs textFieldEventArgs_0)
		{
			if (this.textFieldEventHandler_3 != null)
			{
				this.textFieldEventHandler_3(this, textFieldEventArgs_0);
			}
		}

		/// <summary>Raises the TextFieldChanged event.</summary>
		/// <param name="e">Specifies a TextFieldEventArgs object that contains the event data.</param>
		protected virtual void OnTextFieldChanged(TextFieldEventArgs textFieldEventArgs_0)
		{
			if (this.textFieldEventHandler_4 != null)
			{
				this.textFieldEventHandler_4(this, textFieldEventArgs_0);
			}
		}

		/// <summary>Raises the TextFieldEntered event.</summary>
		/// <param name="e">Specifies a TextFieldEventArgs object that contains the event data.</param>
		protected virtual void OnTextFieldEntered(TextFieldEventArgs textFieldEventArgs_0)
		{
			if (this.textFieldEventHandler_5 != null)
			{
				this.textFieldEventHandler_5(this, textFieldEventArgs_0);
			}
		}

		/// <summary>Raises the TextFieldLeft event.</summary>
		/// <param name="e">Specifies a TextFieldEventArgs object that contains the event data.</param>
		protected virtual void OnTextFieldLeft(TextFieldEventArgs textFieldEventArgs_0)
		{
			if (this.textFieldEventHandler_6 != null)
			{
				this.textFieldEventHandler_6(this, textFieldEventArgs_0);
			}
		}

		/// <summary>Raises the FormFieldCheckChanged event.</summary>
		/// <param name="e">Specifies a CheckFormFieldEventArgs object that contains the event data.</param>
		protected virtual void OnFormFieldCheckChanged(CheckFormFieldEventArgs checkFormFieldEventArgs_0)
		{
			if (this.checkFormFieldEventHandler_0 != null)
			{
				this.checkFormFieldEventHandler_0(this, checkFormFieldEventArgs_0);
			}
		}

		/// <summary>Raises the FormFieldDateChanged event.</summary>
		/// <param name="e">Specifies a DateFormFieldEventArgs object that contains the event data.</param>
		protected virtual void OnFormFieldDateChanged(DateFormFieldEventArgs dateFormFieldEventArgs_0)
		{
			if (this.dateFormFieldEventHandler_0 != null)
			{
				this.dateFormFieldEventHandler_0(this, dateFormFieldEventArgs_0);
			}
		}

		/// <summary>Raises the FormFieldSelectionChanged event.</summary>
		/// <param name="e">Specifies a SelectionFormFieldEventArgs object that contains the event data.</param>
		protected virtual void OnFormFieldSelectionChanged(SelectionFormFieldEventArgs selectionFormFieldEventArgs_0)
		{
			if (this.selectionFormFieldEventHandler_0 != null)
			{
				this.selectionFormFieldEventHandler_0(this, selectionFormFieldEventArgs_0);
			}
		}

		/// <summary>Raises the FormFieldTextChanged event.</summary>
		/// <param name="e">Specifies a TextFormFieldEventArgs object that contains the event data.</param>
		protected virtual void OnFormFieldTextChanged(TextFormFieldEventArgs textFormFieldEventArgs_0)
		{
			if (this.textFormFieldEventHandler_0 != null)
			{
				this.textFormFieldEventHandler_0(this, textFormFieldEventArgs_0);
			}
		}

		/// <summary>Raises the HypertextLinkClicked event.</summary>
		/// <param name="e">Specifies a HypertextLinkEventArgs object that contains the event data.</param>
		protected virtual void OnHypertextLinkClicked(HypertextLinkEventArgs hypertextLinkEventArgs_0)
		{
			if (this.hypertextLinkEventHandler_0 != null)
			{
				this.hypertextLinkEventHandler_0(this, hypertextLinkEventArgs_0);
			}
		}

		/// <summary>Raises the DocumentLinkClicked event.</summary>
		/// <param name="e">Specifies a DocumentLinkEventArgs object that contains the event data.</param>
		protected virtual void OnDocumentLinkClicked(DocumentLinkEventArgs documentLinkEventArgs_0)
		{
			if (this.documentLinkEventHandler_0 != null)
			{
				this.documentLinkEventHandler_0(this, documentLinkEventArgs_0);
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

		/// <summary>Raises the TableOfContentsEntered event.</summary>
		/// <param name="e">Specifies an TableOfContentsEventArgs object that contains the event data.</param>
		protected virtual void OnTableOfContentsEntered(TableOfContentsEventArgs tableOfContentsEventArgs_0)
		{
			if (this.tableOfContentsEventHandler_2 != null)
			{
				this.tableOfContentsEventHandler_2(this, tableOfContentsEventArgs_0);
			}
		}

		/// <summary>Raises the TableOfContentsLeft event.</summary>
		/// <param name="e">Specifies an TableOfContentsEventArgs object that contains the event data.</param>
		protected virtual void OnTableOfContentsLeft(TableOfContentsEventArgs tableOfContentsEventArgs_0)
		{
			if (this.tableOfContentsEventHandler_3 != null)
			{
				this.tableOfContentsEventHandler_3(this, tableOfContentsEventArgs_0);
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

		/// <summary>Raises the SubTextPartClicked event.</summary>
		/// <param name="e">Specifies a SubTextPartEventArgs object that contains the event data.</param>
		protected virtual void OnSubTextPartClicked(SubTextPartEventArgs subTextPartEventArgs_0)
		{
			if (this.subTextPartEventHandler_2 != null)
			{
				this.subTextPartEventHandler_2(this, subTextPartEventArgs_0);
			}
		}

		/// <summary>Raises the SubTextPartDoubleClicked event.</summary>
		/// <param name="e">Specifies a SubTextPartEventArgs object that contains the event data.</param>
		protected virtual void OnSubTextPartDoubleClicked(SubTextPartEventArgs subTextPartEventArgs_0)
		{
			if (this.subTextPartEventHandler_3 != null)
			{
				this.subTextPartEventHandler_3(this, subTextPartEventArgs_0);
			}
		}

		/// <summary>Raises the SubTextPartEntered event.</summary>
		/// <param name="e">Specifies a SubTextPartEventArgs object that contains the event data.</param>
		protected virtual void OnSubTextPartEntered(SubTextPartEventArgs subTextPartEventArgs_0)
		{
			if (this.subTextPartEventHandler_4 != null)
			{
				this.subTextPartEventHandler_4(this, subTextPartEventArgs_0);
			}
		}

		/// <summary>Raises the SubTextPartLeft event.</summary>
		/// <param name="e">Specifies a SubTextPartEventArgs object that contains the event data.</param>
		protected virtual void OnSubTextPartLeft(SubTextPartEventArgs subTextPartEventArgs_0)
		{
			if (this.subTextPartEventHandler_5 != null)
			{
				this.subTextPartEventHandler_5(this, subTextPartEventArgs_0);
			}
		}

		/// <summary>Raises the EditableRegionEntered event.</summary>
		/// <param name="e">Specifies an EditableRegionEventArgs object that contains the event data.</param>
		protected virtual void OnEditableRegionEntered(EditableRegionEventArgs editableRegionEventArgs_0)
		{
			if (this.editableRegionEventHandler_0 != null)
			{
				this.editableRegionEventHandler_0(this, editableRegionEventArgs_0);
			}
		}

		/// <summary>Raises the EditableRegionLeft event.</summary>
		/// <param name="e">Specifies an EditableRegionEventArgs object that contains the event data.</param>
		protected virtual void OnEditableRegionLeft(EditableRegionEventArgs editableRegionEventArgs_0)
		{
			if (this.editableRegionEventHandler_1 != null)
			{
				this.editableRegionEventHandler_1(this, editableRegionEventArgs_0);
			}
		}

		/// <summary>Raises the EditableRegionCreated event.</summary>
		/// <param name="e">Specifies an EditableRegionEventArgs object that contains the event data.</param>
		protected virtual void OnEditableRegionCreated(EditableRegionEventArgs editableRegionEventArgs_0)
		{
			if (this.editableRegionEventHandler_2 != null)
			{
				this.editableRegionEventHandler_2(this, editableRegionEventArgs_0);
			}
		}

		/// <summary>Raises the EditableRegionDeleted event.</summary>
		/// <param name="e">Specifies an EditableRegionEventArgs object that contains the event data.</param>
		protected virtual void OnEditableRegionDeleted(EditableRegionEventArgs editableRegionEventArgs_0)
		{
			if (this.editableRegionEventHandler_3 != null)
			{
				this.editableRegionEventHandler_3(this, editableRegionEventArgs_0);
			}
		}

		/// <summary>Raises the CannotTrackChange event.</summary>
		/// <param name="e">Specifies a CannotTrackChangeEventArgs object that contains the event data.</param>
		protected virtual void OnCannotTrackChange(CannotTrackChangeEventArgs cannotTrackChangeEventArgs_0)
		{
			if (this.cannotTrackChangeEventHandler_0 != null)
			{
				cannotTrackChangeEventArgs_0.DefaultMessage = this.resources.GetString("MSG_CANNOTTRACKCHANGE_TEXT");
				this.cannotTrackChangeEventHandler_0(this, cannotTrackChangeEventArgs_0);
			}
			if (!cannotTrackChangeEventArgs_0.Handled)
			{
				DialogResult dialogResult = MessageBox.Show(this, this.resources.GetString("MSG_CANNOTTRACKCHANGE_TEXT"), this.resources.GetString("MSG_CANNOTTRACKCHANGE_CAPTION"), MessageBoxButtons.YesNo, MessageBoxIcon.Question);
				if (dialogResult == DialogResult.Yes)
				{
					cannotTrackChangeEventArgs_0.Cancel = false;
				}
			}
		}

		/// <summary>Raises the TrackedChangeChanged event.</summary>
		/// <param name="e">Specifies an TrackedChangeEventArgs object that contains the event data.</param>
		protected virtual void OnTrackedChangeChanged(TrackedChangeEventArgs trackedChangeEventArgs_0)
		{
			if (this.trackedChangeEventHandler_0 != null)
			{
				this.trackedChangeEventHandler_0(this, trackedChangeEventArgs_0);
			}
		}

		/// <summary>Raises the TrackedChangeCreated event.</summary>
		/// <param name="e">Specifies an TrackedChangeEventArgs object that contains the event data.</param>
		protected virtual void OnTrackedChangeCreated(TrackedChangeEventArgs trackedChangeEventArgs_0)
		{
			if (this.trackedChangeEventHandler_1 != null)
			{
				this.trackedChangeEventHandler_1(this, trackedChangeEventArgs_0);
			}
		}

		/// <summary>Raises the TrackedChangeDeleted event.</summary>
		/// <param name="e">Specifies an TrackedChangeEventArgs object that contains the event data.</param>
		protected virtual void OnTrackedChangeDeleted(TrackedChangeEventArgs trackedChangeEventArgs_0)
		{
			if (this.trackedChangeEventHandler_2 != null)
			{
				this.trackedChangeEventHandler_2(this, trackedChangeEventArgs_0);
			}
		}

		/// <summary>Raises the TrackedChangeStateChanged event.</summary>
		/// <param name="e">Specifies an TrackedChangeEventArgs object that contains the event data.</param>
		protected virtual void OnTrackedChangeStateChanged(TrackedChangeEventArgs trackedChangeEventArgs_0)
		{
			if (this.trackedChangeEventHandler_3 != null)
			{
				this.trackedChangeEventHandler_3(this, trackedChangeEventArgs_0);
			}
		}

		/// <summary>Raises the FrameClicked event.</summary>
		/// <param name="e">Specifies a FrameEventArgs object that contains the event data.</param>
		protected virtual void OnFrameClicked(FrameEventArgs frameEventArgs_0)
		{
			if (this.frameEventHandler_0 != null)
			{
				this.frameEventHandler_0(this, frameEventArgs_0);
			}
		}

		/// <summary>Raises the FrameDoubleClicked event.</summary>
		/// <param name="e">Specifies a FrameEventArgs object that contains the event data.</param>
		protected virtual void OnFrameDoubleClicked(FrameEventArgs frameEventArgs_0)
		{
			if (this.frameEventHandler_1 != null)
			{
				this.frameEventHandler_1(this, frameEventArgs_0);
			}
		}

		/// <summary>Raises the FrameMoved event.</summary>
		/// <param name="e">Specifies a FrameEventArgs object that contains the event data.</param>
		protected virtual void OnFrameMoved(FrameEventArgs frameEventArgs_0)
		{
			if (this.frameEventHandler_2 != null)
			{
				this.frameEventHandler_2(this, frameEventArgs_0);
			}
		}

		/// <summary>Raises the FrameSized event.</summary>
		/// <param name="e">Specifies a FrameEventArgs object that contains the event data.</param>
		protected virtual void OnFrameSized(FrameEventArgs frameEventArgs_0)
		{
			if (this.frameEventHandler_3 != null)
			{
				this.frameEventHandler_3(this, frameEventArgs_0);
			}
		}

		/// <summary>Raises the FrameRightClicked event.</summary>
		/// <param name="e">Specifies a FrameEventArgs object that contains the event data.</param>
		protected virtual void OnFrameRightClicked(FrameEventArgs frameEventArgs_0)
		{
			if (this.frameEventHandler_4 != null)
			{
				this.frameEventHandler_4(this, frameEventArgs_0);
			}
		}

		/// <summary>Raises the FrameSelected event.</summary>
		/// <param name="e">Specifies a FrameEventArgs object that contains the event data.</param>
		protected virtual void OnFrameSelected(FrameEventArgs frameEventArgs_0)
		{
			if (this.frameEventHandler_5 != null)
			{
				this.frameEventHandler_5(this, frameEventArgs_0);
			}
		}

		/// <summary>Raises the FrameDeselected event.</summary>
		/// <param name="e">Specifies a FrameEventArgs object that contains the event data.</param>
		protected virtual void OnFrameDeselected(FrameEventArgs frameEventArgs_0)
		{
			if (this.frameEventHandler_6 != null)
			{
				this.frameEventHandler_6(this, frameEventArgs_0);
			}
		}

		/// <summary>Raises the FrameLayoutChanged event.</summary>
		/// <param name="e">Specifies a FrameEventArgs object that contains the event data.</param>
		protected virtual void OnFrameLayoutChanged(FrameEventArgs frameEventArgs_0)
		{
			if (this.frameEventHandler_7 != null)
			{
				this.frameEventHandler_7(this, frameEventArgs_0);
			}
		}

		/// <summary>Raises the ImageClicked event.</summary>
		/// <param name="e">Specifies an ImageEventArgs object that contains the event data.</param>
		protected virtual void OnImageClicked(ImageEventArgs imageEventArgs_0)
		{
			if (this.imageEventHandler_0 != null)
			{
				this.imageEventHandler_0(this, imageEventArgs_0);
			}
		}

		/// <summary>Raises the ImageCreated event.</summary>
		/// <param name="e">Specifies an ImageEventArgs object that contains the event data.</param>
		protected virtual void OnImageCreated(ImageEventArgs imageEventArgs_0)
		{
			if (this.imageEventHandler_1 != null)
			{
				this.imageEventHandler_1(this, imageEventArgs_0);
			}
		}

		/// <summary>Raises the ImageDeleted event.</summary>
		/// <param name="e">Specifies an ImageEventArgs object that contains the event data.</param>
		protected virtual void OnImageDeleted(ImageEventArgs imageEventArgs_0)
		{
			if (this.imageEventHandler_2 != null)
			{
				this.imageEventHandler_2(this, imageEventArgs_0);
			}
		}

		/// <summary>Raises the ImageDoubleClicked event.</summary>
		/// <param name="e">Specifies an ImageEventArgs object that contains the event data.</param>
		protected virtual void OnImageDoubleClicked(ImageEventArgs imageEventArgs_0)
		{
			if (this.imageEventHandler_3 != null)
			{
				this.imageEventHandler_3(this, imageEventArgs_0);
			}
		}

		/// <summary>Raises the ImageMoved event.</summary>
		/// <param name="e">Specifies an ImageEventArgs object that contains the event data.</param>
		protected virtual void OnImageMoved(ImageEventArgs imageEventArgs_0)
		{
			if (this.imageEventHandler_4 != null)
			{
				this.imageEventHandler_4(this, imageEventArgs_0);
			}
		}

		/// <summary>Raises the ImageSized event.</summary>
		/// <param name="e">Specifies an ImageEventArgs object that contains the event data.</param>
		protected virtual void OnImageSized(ImageEventArgs imageEventArgs_0)
		{
			if (this.imageEventHandler_5 != null)
			{
				this.imageEventHandler_5(this, imageEventArgs_0);
			}
		}

		/// <summary>Raises the ImageRightClicked event.</summary>
		/// <param name="e">Specifies an ImageEventArgs object that contains the event data.</param>
		protected virtual void OnImageRightClicked(ImageEventArgs imageEventArgs_0)
		{
			if (this.imageEventHandler_6 != null)
			{
				this.imageEventHandler_6(this, imageEventArgs_0);
			}
		}

		/// <summary>Raises the ImageSelected event.</summary>
		/// <param name="e">Specifies an ImageEventArgs object that contains the event data.</param>
		protected virtual void OnImageSelected(ImageEventArgs imageEventArgs_0)
		{
			if (this.imageEventHandler_7 != null)
			{
				this.imageEventHandler_7(this, imageEventArgs_0);
			}
		}

		/// <summary>Raises the ImageDeselected event.</summary>
		/// <param name="e">Specifies an ImageEventArgs object that contains the event data.</param>
		protected virtual void OnImageDeselected(ImageEventArgs imageEventArgs_0)
		{
			if (this.imageEventHandler_8 != null)
			{
				this.imageEventHandler_8(this, imageEventArgs_0);
			}
		}

		/// <summary>Raises the TextFrameClicked event.</summary>
		/// <param name="e">Specifies a TextFrameEventArgs object that contains the event data.</param>
		protected virtual void OnTextFrameClicked(TextFrameEventArgs textFrameEventArgs_0)
		{
			if (this.textFrameEventHandler_0 != null)
			{
				this.textFrameEventHandler_0(this, textFrameEventArgs_0);
			}
		}

		/// <summary>Raises the TextFrameCreated event.</summary>
		/// <param name="e">Specifies a TextFrameEventArgs object that contains the event data.</param>
		protected virtual void OnTextFrameCreated(TextFrameEventArgs textFrameEventArgs_0)
		{
			if (this.textFrameEventHandler_1 != null)
			{
				this.textFrameEventHandler_1(this, textFrameEventArgs_0);
			}
		}

		/// <summary>Raises the TextFrameDeleted event.</summary>
		/// <param name="e">Specifies a TextFrameEventArgs object that contains the event data.</param>
		protected virtual void OnTextFrameDeleted(TextFrameEventArgs textFrameEventArgs_0)
		{
			if (this.textFrameEventHandler_2 != null)
			{
				this.textFrameEventHandler_2(this, textFrameEventArgs_0);
			}
		}

		/// <summary>Raises the TextFrameDoubleClicked event.</summary>
		/// <param name="e">Specifies a TextFrameEventArgs object that contains the event data.</param>
		protected virtual void OnTextFrameDoubleClicked(TextFrameEventArgs textFrameEventArgs_0)
		{
			if (this.textFrameEventHandler_3 != null)
			{
				this.textFrameEventHandler_3(this, textFrameEventArgs_0);
			}
		}

		/// <summary>Raises the TextFrameMoved event.</summary>
		/// <param name="e">Specifies a TextFrameEventArgs object that contains the event data.</param>
		protected virtual void OnTextFrameMoved(TextFrameEventArgs textFrameEventArgs_0)
		{
			if (this.textFrameEventHandler_4 != null)
			{
				this.textFrameEventHandler_4(this, textFrameEventArgs_0);
			}
		}

		/// <summary>Raises the TextFrameSized event.</summary>
		/// <param name="e">Specifies a TextFrameEventArgs object that contains the event data.</param>
		protected virtual void OnTextFrameSized(TextFrameEventArgs textFrameEventArgs_0)
		{
			if (this.textFrameEventHandler_5 != null)
			{
				this.textFrameEventHandler_5(this, textFrameEventArgs_0);
			}
		}

		/// <summary>Raises the TextFrameRightClicked event.</summary>
		/// <param name="e">Specifies a TextFrameEventArgs object that contains the event data.</param>
		protected virtual void OnTextFrameRightClicked(TextFrameEventArgs textFrameEventArgs_0)
		{
			if (this.textFrameEventHandler_6 != null)
			{
				this.textFrameEventHandler_6(this, textFrameEventArgs_0);
			}
		}

		/// <summary>Raises the TextFrameActivated event.</summary>
		/// <param name="e">Specifies a TextFrameEventArgs object that contains the event data.</param>
		protected virtual void OnTextFrameActivated(TextFrameEventArgs textFrameEventArgs_0)
		{
			if (this.textFrameEventHandler_7 != null)
			{
				this.textFrameEventHandler_7(this, textFrameEventArgs_0);
			}
		}

		/// <summary>Raises the TextFrameDeactivated event.</summary>
		/// <param name="e">Specifies a TextFrameEventArgs object that contains the event data.</param>
		protected virtual void OnTextFrameDeactivated(TextFrameEventArgs textFrameEventArgs_0)
		{
			if (this.textFrameEventHandler_8 != null)
			{
				this.textFrameEventHandler_8(this, textFrameEventArgs_0);
			}
		}

		/// <summary>Raises the TextFrameSelected event.</summary>
		/// <param name="e">Specifies a TextFrameEventArgs object that contains the event data.</param>
		protected virtual void OnTextFrameSelected(TextFrameEventArgs textFrameEventArgs_0)
		{
			if (this.textFrameEventHandler_9 != null)
			{
				this.textFrameEventHandler_9(this, textFrameEventArgs_0);
			}
		}

		/// <summary>Raises the TextFrameDeselected event.</summary>
		/// <param name="e">Specifies a TextFrameEventArgs object that contains the event data.</param>
		protected virtual void OnTextFrameDeselected(TextFrameEventArgs textFrameEventArgs_0)
		{
			if (this.textFrameEventHandler_10 != null)
			{
				this.textFrameEventHandler_10(this, textFrameEventArgs_0);
			}
		}

		/// <summary>Raises the TextFrameAppearanceChanged event.</summary>
		/// <param name="e">Specifies a TextFrameEventArgs object that contains the event data.</param>
		protected virtual void OnTextFrameAppearanceChanged(TextFrameEventArgs textFrameEventArgs_0)
		{
			if (this.textFrameEventHandler_11 != null)
			{
				this.textFrameEventHandler_11(this, textFrameEventArgs_0);
			}
		}

		protected virtual void OnChartClicked(ChartEventArgs chartEventArgs_0)
		{
			if (this.chartEventHandler_0 != null)
			{
				this.chartEventHandler_0(this, chartEventArgs_0);
			}
		}

		protected virtual void OnChartCreated(ChartEventArgs chartEventArgs_0)
		{
			if (this.chartEventHandler_1 != null)
			{
				this.chartEventHandler_1(this, chartEventArgs_0);
			}
		}

		protected virtual void OnChartDeleted(ChartEventArgs chartEventArgs_0)
		{
			if (this.chartEventHandler_2 != null)
			{
				this.chartEventHandler_2(this, chartEventArgs_0);
			}
		}

		protected virtual void OnChartDoubleClicked(ChartEventArgs chartEventArgs_0)
		{
			if (this.chartEventHandler_3 != null)
			{
				this.chartEventHandler_3(this, chartEventArgs_0);
			}
		}

		protected virtual void OnChartMoved(ChartEventArgs chartEventArgs_0)
		{
			if (this.chartEventHandler_4 != null)
			{
				this.chartEventHandler_4(this, chartEventArgs_0);
			}
		}

		protected virtual void OnChartSized(ChartEventArgs chartEventArgs_0)
		{
			if (this.chartEventHandler_5 != null)
			{
				this.chartEventHandler_5(this, chartEventArgs_0);
			}
		}

		protected virtual void OnChartRightClicked(ChartEventArgs chartEventArgs_0)
		{
			if (this.chartEventHandler_6 != null)
			{
				this.chartEventHandler_6(this, chartEventArgs_0);
			}
		}

		protected virtual void OnChartSelected(ChartEventArgs chartEventArgs_0)
		{
			if (this.chartEventHandler_7 != null)
			{
				this.chartEventHandler_7(this, chartEventArgs_0);
			}
		}

		protected virtual void OnChartDeselected(ChartEventArgs chartEventArgs_0)
		{
			if (this.chartEventHandler_8 != null)
			{
				this.chartEventHandler_8(this, chartEventArgs_0);
			}
		}

		protected virtual void OnBarcodeClicked(BarcodeEventArgs barcodeEventArgs_0)
		{
			if (this.barcodeEventHandler_0 != null)
			{
				this.barcodeEventHandler_0(this, barcodeEventArgs_0);
			}
		}

		protected virtual void OnBarcodeCreated(BarcodeEventArgs barcodeEventArgs_0)
		{
			if (this.barcodeEventHandler_1 != null)
			{
				this.barcodeEventHandler_1(this, barcodeEventArgs_0);
			}
		}

		protected virtual void OnBarcodeDeleted(BarcodeEventArgs barcodeEventArgs_0)
		{
			if (this.barcodeEventHandler_2 != null)
			{
				this.barcodeEventHandler_2(this, barcodeEventArgs_0);
			}
		}

		protected virtual void OnBarcodeDoubleClicked(BarcodeEventArgs barcodeEventArgs_0)
		{
			if (this.barcodeEventHandler_3 != null)
			{
				this.barcodeEventHandler_3(this, barcodeEventArgs_0);
			}
		}

		protected virtual void OnBarcodeMoved(BarcodeEventArgs barcodeEventArgs_0)
		{
			if (this.barcodeEventHandler_4 != null)
			{
				this.barcodeEventHandler_4(this, barcodeEventArgs_0);
			}
		}

		protected virtual void OnBarcodeSized(BarcodeEventArgs barcodeEventArgs_0)
		{
			if (this.barcodeEventHandler_5 != null)
			{
				this.barcodeEventHandler_5(this, barcodeEventArgs_0);
			}
		}

		protected virtual void OnBarcodeRightClicked(BarcodeEventArgs barcodeEventArgs_0)
		{
			if (this.barcodeEventHandler_6 != null)
			{
				this.barcodeEventHandler_6(this, barcodeEventArgs_0);
			}
		}

		protected virtual void OnBarcodeSelected(BarcodeEventArgs barcodeEventArgs_0)
		{
			if (this.barcodeEventHandler_7 != null)
			{
				this.barcodeEventHandler_7(this, barcodeEventArgs_0);
			}
		}

		protected virtual void OnBarcodeDeselected(BarcodeEventArgs barcodeEventArgs_0)
		{
			if (this.barcodeEventHandler_8 != null)
			{
				this.barcodeEventHandler_8(this, barcodeEventArgs_0);
			}
		}

		protected virtual void OnDrawingClicked(DrawingEventArgs drawingEventArgs_0)
		{
			if (this.drawingEventHandler_0 != null)
			{
				this.drawingEventHandler_0(this, drawingEventArgs_0);
			}
		}

		protected virtual void OnDrawingCreated(DrawingEventArgs drawingEventArgs_0)
		{
			if (this.drawingEventHandler_1 != null)
			{
				this.drawingEventHandler_1(this, drawingEventArgs_0);
			}
		}

		protected virtual void OnDrawingDeleted(DrawingEventArgs drawingEventArgs_0)
		{
			if (this.drawingEventHandler_2 != null)
			{
				this.drawingEventHandler_2(this, drawingEventArgs_0);
			}
		}

		protected virtual void OnDrawingDoubleClicked(DrawingEventArgs drawingEventArgs_0)
		{
			if (this.drawingEventHandler_3 != null)
			{
				this.drawingEventHandler_3(this, drawingEventArgs_0);
			}
		}

		protected virtual void OnDrawingMoved(DrawingEventArgs drawingEventArgs_0)
		{
			if (this.drawingEventHandler_4 != null)
			{
				this.drawingEventHandler_4(this, drawingEventArgs_0);
			}
		}

		protected virtual void OnDrawingSized(DrawingEventArgs drawingEventArgs_0)
		{
			if (this.drawingEventHandler_5 != null)
			{
				this.drawingEventHandler_5(this, drawingEventArgs_0);
			}
		}

		protected virtual void OnDrawingRightClicked(DrawingEventArgs drawingEventArgs_0)
		{
			if (this.drawingEventHandler_6 != null)
			{
				this.drawingEventHandler_6(this, drawingEventArgs_0);
			}
		}

		protected virtual void OnDrawingSelected(DrawingEventArgs drawingEventArgs_0)
		{
			if (this.drawingEventHandler_7 != null)
			{
				this.drawingEventHandler_7(this, drawingEventArgs_0);
			}
		}

		protected virtual void OnDrawingDeselected(DrawingEventArgs drawingEventArgs_0)
		{
			if (this.drawingEventHandler_8 != null)
			{
				this.drawingEventHandler_8(this, drawingEventArgs_0);
			}
		}

		protected virtual void OnDrawingActivated(DrawingEventArgs drawingEventArgs_0)
		{
			if (this.drawingEventHandler_9 != null)
			{
				this.drawingEventHandler_9(this, drawingEventArgs_0);
			}
		}

		protected virtual void OnDrawingDeactivated(DrawingEventArgs drawingEventArgs_0)
		{
			if (this.drawingEventHandler_10 != null)
			{
				this.drawingEventHandler_10(this, drawingEventArgs_0);
			}
		}

		/// <summary>Raises the HeaderFooterActivated event.</summary>
		/// <param name="e">Specifies a HeaderFooterEventArgs object that contains the event data.</param>
		protected virtual void OnHeaderFooterActivated(HeaderFooterEventArgs headerFooterEventArgs_0)
		{
			if (this.headerFooterEventHandler_0 != null)
			{
				this.headerFooterEventHandler_0(this, headerFooterEventArgs_0);
			}
		}

		/// <summary>Raises the HeaderFooterDeactivated event.</summary>
		/// <param name="e">Specifies a HeaderFooterEventArgs object that contains the event data.</param>
		protected virtual void OnHeaderFooterDeactivated(HeaderFooterEventArgs headerFooterEventArgs_0)
		{
			if (this.headerFooterEventHandler_1 != null)
			{
				this.headerFooterEventHandler_1(this, headerFooterEventArgs_0);
			}
		}

		/// <summary>Raises the TableCreated event.</summary>
		/// <param name="e">Specifies a TableEventArgs object that contains the event data.</param>
		protected virtual void OnTableCreated(TableEventArgs tableEventArgs_0)
		{
			if (this.tableEventHandler_0 != null)
			{
				this.tableEventHandler_0(this, tableEventArgs_0);
			}
		}

		/// <summary>Raises the TableDeleted event.</summary>
		/// <param name="e">Specifies a TableEventArgs object that contains the event data.</param>
		protected virtual void OnTableDeleted(TableEventArgs tableEventArgs_0)
		{
			if (this.tableEventHandler_1 != null)
			{
				this.tableEventHandler_1(this, tableEventArgs_0);
			}
		}

		/// <summary>Raises the TableFormatChanged event.</summary>
		/// <param name="e">Specifies a TableEventArgs object that contains the event data.</param>
		protected virtual void OnTableFormatChanged(TableEventArgs tableEventArgs_0)
		{
			if (this.tableEventHandler_2 != null)
			{
				this.tableEventHandler_2(this, tableEventArgs_0);
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

		/// <summary>Raises the SpellCheckText event.</summary>
		/// <param name="e">Specifies a SpellCheckTextEventArgs object that contains the event data.</param>
		protected virtual void OnSpellCheckText(SpellCheckTextEventArgs spellCheckTextEventArgs_0)
		{
			if (this.spellCheckTextEventHandler_0 != null)
			{
				this.spellCheckTextEventHandler_0(this, spellCheckTextEventArgs_0);
			}
		}

		/// <summary>Raises the HyphenateWord event.</summary>
		/// <param name="e">Specifies a HyphenateWordEventArgs object that contains the event data.</param>
		protected virtual void OnHyphenateWord(HyphenateWordEventArgs hyphenateWordEventArgs_0)
		{
			if (this.hyphenateWordEventHandler_0 != null)
			{
				this.hyphenateWordEventHandler_0(this, hyphenateWordEventArgs_0);
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

		private void method_19(ref Message message_0)
		{
			Struct62 @struct = (Struct62)message_0.GetLParam(typeof(Struct62));
			this.inputFormat_0.method_5((Enum84)@struct.struct84_0.uint_0);
			Enum84 uint_ = (Enum84)@struct.struct84_0.uint_0;
			if (uint_ == Enum84.const_4 || uint_ == Enum84.const_45 || uint_ == Enum84.const_61)
			{
				this.method_8();
				this.method_9();
			}
			switch (@struct.struct84_0.uint_0)
			{
			case 1796u:
				this.OnFocusChanged(EventArgs.Empty);
				break;
			case 1798u:
				this.textControlCore_0.Boolean_1 = true;
				break;
			case 1799u:
				this.OnChanged(EventArgs.Empty);
				break;
			case 1800u:
				this.OnInputPositionChanged(EventArgs.Empty);
				break;
			case 1801u:
				this.OnHExpanded(EventArgs.Empty);
				break;
			case 1804u:
				this.OnCharFormatChanged(EventArgs.Empty);
				break;
			case 1805u:
				this.OnParagraphFormatChanged(EventArgs.Empty);
				break;
			case 1806u:
				Cursor.Current = this.FieldCursor;
				message_0.Result = new IntPtr(1);
				break;
			case 1807u:
				this.OnZoomed(EventArgs.Empty);
				break;
			case 1808u:
				this.OnVExpanded(EventArgs.Empty);
				break;
			case 1813u:
				this.OnTextFieldDeleted(new TextFieldEventArgs(this.textControlCore_0, (TextPart)@struct.uint_1, (int)@struct.uint_0, bCreateObject: true));
				break;
			case 1815u:
				this.OnInputParagraphChanged(EventArgs.Empty);
				if (this.editMode_0 == EditMode.ReadAndSelect)
				{
					this.method_25();
				}
				break;
			case 1817u:
				this.OnHScroll(EventArgs.Empty);
				break;
			case 1818u:
				this.OnVScroll(EventArgs.Empty);
				break;
			case 1827u:
				this.OnPageFormatChanged(EventArgs.Empty);
				break;
			case 1810u:
			case 1811u:
			case 1812u:
			case 1814u:
			case 1821u:
			case 1828u:
			{
				TextFieldEventArgs textFieldEventArgs_ = new TextFieldEventArgs(this.textControlCore_0, (TextPart)@struct.uint_1, (int)@struct.uint_0, bCreateObject: false);
				switch (@struct.struct84_0.uint_0)
				{
				case 1828u:
					this.OnTextFieldLeft(textFieldEventArgs_);
					break;
				case 1821u:
					this.OnTextFieldEntered(textFieldEventArgs_);
					break;
				case 1810u:
					this.OnTextFieldClicked(textFieldEventArgs_);
					break;
				case 1811u:
					this.OnTextFieldCreated(textFieldEventArgs_);
					break;
				case 1812u:
					this.OnTextFieldDoubleClicked(textFieldEventArgs_);
					break;
				case 1814u:
					this.OnTextFieldChanged(textFieldEventArgs_);
					break;
				}
				break;
			}
			case 1834u:
				this.OnTableDeleted(new TableEventArgs(null, (TextPart)@struct.uint_1, (int)(((long)@struct.uint_0 > 32767L) ? @struct.uint_0 : 0), (int)(((long)@struct.uint_0 <= 32767L) ? @struct.uint_0 : 0)));
				break;
			case 1837u:
				this.OnHeaderFooterActivated(new HeaderFooterEventArgs(this.textControlCore_0, (HeaderFooterType)@struct.uint_0, Class429.smethod_6((int)@struct.uint_1)));
				break;
			case 1838u:
				this.OnHeaderFooterDeactivated(new HeaderFooterEventArgs(this.textControlCore_0, (HeaderFooterType)@struct.uint_0, Class429.smethod_6((int)@struct.uint_1)));				
				break;
			case 1839u:
				this.OnVShrunk(EventArgs.Empty);
				break;
			case 1841u:
				this.OnInputFormattingStyleChanged(EventArgs.Empty);
				break;
			case 1842u:
				this.OnFormattingStyleListChanged(EventArgs.Empty);
				break;
			case 1843u:
				this.OnTableFormatChanged(new TableEventArgs(this.textControlCore_0, (TextPart)@struct.uint_1, (int)(((long)@struct.uint_0 > 32767L) ? @struct.uint_0 : 0), (int)(((long)@struct.uint_0 <= 32767L) ? @struct.uint_0 : 0)));
				break;
			case 1844u:
			case 1845u:
			{
				XmlErrorEventArgs xmlErrorEventArgs = null;
				Struct73 struct73_ = default(Struct73);
				struct73_.method_0();
				try
				{
					if (Class429.SendMessage_37(base.Handle, 1824, 0, ref struct73_) != 0)
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
					switch (@struct.struct84_0.uint_0)
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
			case 1847u:
				this.OnHypertextLinkClicked(new HypertextLinkEventArgs(this.textControlCore_0, (TextPart)@struct.uint_1, (int)@struct.uint_0));
				break;
			case 1848u:
				this.OnDocumentLinkClicked(new DocumentLinkEventArgs(this.textControlCore_0, (TextPart)@struct.uint_1, (int)@struct.uint_0));
				break;
			case 1849u:
				this.OnTableCreated(new TableEventArgs(this.textControlCore_0, (TextPart)@struct.uint_1, (int)@struct.uint_0, 0));
				break;
			case 1850u:
				base.Height = (int)@struct.uint_0;
				base.Invalidate(invalidateChildren: true);
				break;
			case 1851u:
				base.Width = (int)@struct.uint_0;
				base.Invalidate(invalidateChildren: true);
				break;
			case 1852u:
				this.OnHShrunk(EventArgs.Empty);
				break;
			case 1859u:
				this.OnPageChanged(EventArgs.Empty);
				break;
			case 1860u:
				this.OnSectionChanged(EventArgs.Empty);
				break;
			case 1863u:
				this.method_6();
				break;
			case 1864u:
				this.method_7();
				break;
			case 1865u:
				this.method_8();
				break;
			case 1866u:
				this.method_9();
				break;
			case 1867u:
			{
				TextContextMenuEventArgs textContextMenuEventArgs = new TextContextMenuEventArgs((ContextMenuLocation)@struct.uint_0, this, this.textControlCore_0, this.class408, this.resources);
				this.OnTextContextMenuOpening(textContextMenuEventArgs);
				message_0.Result = (textContextMenuEventArgs.Cancel ? new IntPtr(1) : IntPtr.Zero);
				break;
			}
			case 1873u:
				this.OnSubTextPartEntered(new SubTextPartEventArgs(this.textControlCore_0, (TextPart)@struct.uint_1, (int)@struct.uint_0, bDeleted: false));
				break;
			case 1874u:
				this.OnSubTextPartLeft(new SubTextPartEventArgs(this.textControlCore_0, (TextPart)@struct.uint_1, (int)@struct.uint_0, bDeleted: false));
				break;
			case 1875u:
				this.OnSubTextPartCreated(new SubTextPartEventArgs(this.textControlCore_0, (TextPart)@struct.uint_1, (int)@struct.uint_0, bDeleted: false));
				break;
			case 1876u:
				this.OnSubTextPartDeleted(new SubTextPartEventArgs(this.textControlCore_0, (TextPart)@struct.uint_1, (int)@struct.uint_0, bDeleted: true));
				break;
			case 1877u:
				this.OnSubTextPartClicked(new SubTextPartEventArgs(this.textControlCore_0, (TextPart)@struct.uint_1, (int)@struct.uint_0, bDeleted: false));
				break;
			case 1878u:
				this.OnSubTextPartDoubleClicked(new SubTextPartEventArgs(this.textControlCore_0, (TextPart)@struct.uint_1, (int)@struct.uint_0, bDeleted: false));
				break;
			case 1822u:
			case 1823u:
			case 1824u:
			case 1829u:
			case 1830u:
			case 1831u:
			case 1853u:
			case 1854u:
			case 1855u:
			case 1857u:
			case 1858u:
			case 1871u:
			case 1872u:
			case 1881u:
			case 1882u:
			{
				FrameEventArgs frameEventArgs_ = new FrameEventArgs(this.textControlCore_0, (TextPart)@struct.uint_1, (int)@struct.uint_0);
				switch (@struct.struct84_0.uint_0)
				{
				case 1829u:
					this.OnFrameDoubleClicked(frameEventArgs_);
					break;
				case 1822u:
					this.OnFrameClicked(frameEventArgs_);
					break;
				case 1823u:
					this.OnFrameMoved(frameEventArgs_);
					break;
				case 1824u:
					this.OnFrameSized(frameEventArgs_);
					break;
				case 1881u:
					this.OnFrameLayoutChanged(frameEventArgs_);
					break;
				case 1855u:
					this.OnFrameRightClicked(frameEventArgs_);
					break;
				case 1857u:
					this.OnFrameSelected(frameEventArgs_);
					break;
				case 1858u:
					this.OnFrameDeselected(frameEventArgs_);
					break;
				}
				switch (Class429.SendMessage_1(base.Handle, 1887, (int)@struct.uint_0, 0))
				{
				case 5:
					TextFrameEventArgs textFrameEventArgs_ = new TextFrameEventArgs(this.textControlCore_0, (TextPart)@struct.uint_1, (int)@struct.uint_0);
						switch (@struct.struct84_0.uint_0)
						{
						case 1882u:
							this.OnTextFrameAppearanceChanged(textFrameEventArgs_);
							break;
						case 1853u:
							this.OnTextFrameActivated(textFrameEventArgs_);
							break;
						case 1854u:
							this.OnTextFrameDeactivated(textFrameEventArgs_);
							break;
						case 1855u:
							this.OnTextFrameRightClicked(textFrameEventArgs_);
							break;
						case 1857u:
							this.OnTextFrameSelected(textFrameEventArgs_);
							break;
						case 1858u:
							this.OnTextFrameDeselected(textFrameEventArgs_);
							break;
						case 1822u:
							this.OnTextFrameClicked(textFrameEventArgs_);
							break;
						case 1823u:
							this.OnTextFrameMoved(textFrameEventArgs_);
							break;
						case 1824u:
							this.OnTextFrameSized(textFrameEventArgs_);
							break;
						case 1829u:
							this.OnTextFrameDoubleClicked(textFrameEventArgs_);
							break;
						case 1830u:
							this.OnTextFrameDeleted(textFrameEventArgs_);
							break;
						case 1831u:
							this.OnTextFrameCreated(textFrameEventArgs_);
							break;
						}
					break;
				case 7:
					ChartEventArgs chartEventArgs_ = new ChartEventArgs(this.textControlCore_0, (TextPart)@struct.uint_1, (int)@struct.uint_0, this.textControlCore_0.control5_0[(int)@struct.uint_0].Component);
						switch (@struct.struct84_0.uint_0)
						{
						case 1855u:
							this.OnChartRightClicked(chartEventArgs_);
							break;
						case 1857u:
							this.OnChartSelected(chartEventArgs_);
							break;
						case 1858u:
							this.OnChartDeselected(chartEventArgs_);
							break;
						case 1822u:
							this.OnChartClicked(chartEventArgs_);
							break;
						case 1823u:
							this.OnChartMoved(chartEventArgs_);
							break;
						case 1824u:
							this.OnChartSized(chartEventArgs_);
							break;
						case 1829u:
							this.OnChartDoubleClicked(chartEventArgs_);
							break;
						case 1830u:
							this.OnChartDeleted(chartEventArgs_);
							break;
						case 1831u:
							this.OnChartCreated(chartEventArgs_);
							break;
						}
					break;
				case 8:
					BarcodeEventArgs barcodeEventArgs_ = new BarcodeEventArgs(this.textControlCore_0, (TextPart)@struct.uint_1, (int)@struct.uint_0, this.textControlCore_0.control4_0[(int)@struct.uint_0].Component);
						switch (@struct.struct84_0.uint_0)
						{
						case 1855u:
							this.OnBarcodeRightClicked(barcodeEventArgs_);
							break;
						case 1857u:
							this.OnBarcodeSelected(barcodeEventArgs_);
							break;
						case 1858u:
							this.OnBarcodeDeselected(barcodeEventArgs_);
							break;
						case 1822u:
							this.OnBarcodeClicked(barcodeEventArgs_);
							break;
						case 1823u:
							this.OnBarcodeMoved(barcodeEventArgs_);
							break;
						case 1824u:
							this.OnBarcodeSized(barcodeEventArgs_);
							break;
						case 1829u:
							this.OnBarcodeDoubleClicked(barcodeEventArgs_);
							break;
						case 1830u:
							this.OnBarcodeDeleted(barcodeEventArgs_);
							break;
						case 1831u:
							this.OnBarcodeCreated(barcodeEventArgs_);
							break;
						}
					break;
				case 9:
					Control10 control = (Control10)this.textControlCore_0.control6_0[(int)@struct.uint_0];
						DrawingEventArgs drawingEventArgs_ = new DrawingEventArgs(this.textControlCore_0, (TextPart)@struct.uint_1, (int)@struct.uint_0, control.Component);
						switch (@struct.struct84_0.uint_0)
						{
						case 1871u:
							this.method_22(control);
							this.OnDrawingActivated(drawingEventArgs_);
							break;
						case 1872u:
							this.method_23(control, new DrawingFrame(this.textControlCore_0, (TextPart)@struct.uint_1, (int)@struct.uint_0, control.Component));
							this.OnDrawingDeactivated(drawingEventArgs_);
							break;
						case 1855u:
							this.OnDrawingRightClicked(drawingEventArgs_);
							break;
						case 1857u:
							this.OnDrawingSelected(drawingEventArgs_);
							break;
						case 1858u:
							this.OnDrawingDeselected(drawingEventArgs_);
							break;
						case 1822u:
							this.OnDrawingClicked(drawingEventArgs_);
							break;
						case 1823u:
							this.OnDrawingMoved(drawingEventArgs_);
							break;
						case 1824u:
							this.OnDrawingSized(drawingEventArgs_);
							break;
						case 1829u:
							this.OnDrawingDoubleClicked(drawingEventArgs_);
							break;
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
					ImageEventArgs imageEventArgs_ = new ImageEventArgs(this.textControlCore_0, (TextPart)@struct.uint_1, (int)@struct.uint_0);
					switch (@struct.struct84_0.uint_0)
					{
					case 1855u:
						this.OnImageRightClicked(imageEventArgs_);
						break;
					case 1857u:
						this.OnImageSelected(imageEventArgs_);
						break;
					case 1858u:
						this.OnImageDeselected(imageEventArgs_);
						break;
					case 1822u:
						this.OnImageClicked(imageEventArgs_);
						break;
					case 1823u:
						this.OnImageMoved(imageEventArgs_);
						break;
					case 1824u:
						this.OnImageSized(imageEventArgs_);
						break;
					case 1829u:
						this.OnImageDoubleClicked(imageEventArgs_);
						break;
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
			}
			case 1883u:
				this.documentPermissions_1.method_4();
				this.method_25();
				this.OnDocumentLoaded(EventArgs.Empty);
				break;
			case 1885u:
			{
				MiniToolbarOpeningEventArgs miniToolbarOpeningEventArgs_ = new MiniToolbarOpeningEventArgs((ContextMenuLocation)@struct.uint_0, this, this.textControlCore_0);
				this.OnMiniToolbarOpening(miniToolbarOpeningEventArgs_);
				break;
			}
			case 1886u:
				this.method_18();
				break;
			case 1887u:
				this.OnEditableRegionEntered(new EditableRegionEventArgs(this.textControlCore_0, (TextPart)@struct.uint_1, (int)@struct.uint_0, bDeleted: false));
				if (this.editMode_0 == EditMode.ReadAndSelect)
				{
					this.method_25();
				}
				break;
			case 1888u:
				this.OnEditableRegionLeft(new EditableRegionEventArgs(this.textControlCore_0, (TextPart)@struct.uint_1, (int)@struct.uint_0, bDeleted: false));
				if (this.editMode_0 == EditMode.ReadAndSelect)
				{
					this.method_25();
				}
				break;
			case 1889u:
				this.OnEditableRegionCreated(new EditableRegionEventArgs(this.textControlCore_0, (TextPart)@struct.uint_1, (int)@struct.uint_0, bDeleted: false));
				break;
			case 1890u:
				this.OnEditableRegionDeleted(new EditableRegionEventArgs(this.textControlCore_0, (TextPart)@struct.uint_1, (int)@struct.uint_0, bDeleted: true));
				break;
			case 1891u:
				this.documentPermissions_1.method_4();
				this.OnContentsReset(EventArgs.Empty);
				this.method_25();
				break;
			case 1892u:
			{
				CannotTrackChangeEventArgs cannotTrackChangeEventArgs = new CannotTrackChangeEventArgs();
				this.OnCannotTrackChange(cannotTrackChangeEventArgs);
				message_0.Result = (cannotTrackChangeEventArgs.Cancel ? IntPtr.Zero : new IntPtr(1));
				break;
			}
			case 1893u:
				this.OnTrackedChangeCreated(new TrackedChangeEventArgs(this.textControlCore_0, (TextPart)@struct.uint_1, (int)@struct.uint_0, bDeleted: false));
				break;
			case 1894u:
				this.OnTrackedChangeDeleted(new TrackedChangeEventArgs(this.textControlCore_0, (TextPart)@struct.uint_1, (int)@struct.uint_0, bDeleted: true));
				break;
			case 1895u:
				this.OnTrackedChangeChanged(new TrackedChangeEventArgs(this.textControlCore_0, (TextPart)@struct.uint_1, (int)@struct.uint_0, bDeleted: false));
				break;
			case 1896u:
				this.OnMainTextActivated(EventArgs.Empty);
				break;
			case 1897u:
				this.OnTrackedChangeStateChanged(new TrackedChangeEventArgs(this.textControlCore_0, (TextPart)@struct.uint_1, (int)@struct.uint_0, bDeleted: false));
				break;
			case 1899u:
				this.OnHeaderFooterCreated(EventArgs.Empty);
				break;
			case 1900u:
				this.OnHeaderFooterDeleted(EventArgs.Empty);
				break;
			case 1901u:
				this.OnFormFieldDateChanged(new DateFormFieldEventArgs(this.textControlCore_0, (TextPart)@struct.uint_1, (int)@struct.uint_0));
				break;
			case 1902u:
				this.OnFormFieldCheckChanged(new CheckFormFieldEventArgs(this.textControlCore_0, (TextPart)@struct.uint_1, (int)@struct.uint_0));
				break;
			case 1903u:
				this.OnFormFieldSelectionChanged(new SelectionFormFieldEventArgs(this.textControlCore_0, (TextPart)@struct.uint_1, (int)@struct.uint_0));
				break;
			case 1904u:
				this.OnFormFieldTextChanged(new TextFormFieldEventArgs(this.textControlCore_0, (TextPart)@struct.uint_1, (int)@struct.uint_0));
				break;
			case 1905u:
				this.OnDocumentTargetCreated(new DocumentTargetEventArgs(this.textControlCore_0, (TextPart)@struct.uint_1, (int)@struct.uint_0, bDeleted: false));
				break;
			case 1906u:
				this.OnDocumentTargetDeleted(new DocumentTargetEventArgs(this.textControlCore_0, (TextPart)@struct.uint_1, (int)@struct.uint_0, bDeleted: true));
				break;
			case 1907u:
				this.OnTableOfContentsCreated(new TableOfContentsEventArgs(this.textControlCore_0, (TextPart)@struct.uint_1, (int)@struct.uint_0, bDeleted: false));
				break;
			case 1908u:
				this.OnTableOfContentsDeleted(new TableOfContentsEventArgs(this.textControlCore_0, (TextPart)@struct.uint_1, (int)@struct.uint_0, bDeleted: true));
				break;
			case 1909u:
				this.OnTableOfContentsEntered(new TableOfContentsEventArgs(this.textControlCore_0, (TextPart)@struct.uint_1, (int)@struct.uint_0, bDeleted: false));
				break;
			case 1910u:
				this.OnTableOfContentsLeft(new TableOfContentsEventArgs(this.textControlCore_0, (TextPart)@struct.uint_1, (int)@struct.uint_0, bDeleted: false));
				break;
			case 1797u:
			case 1802u:
			case 1803u:
			case 1809u:
			case 1816u:
			case 1819u:
			case 1820u:
			case 1825u:
			case 1826u:
			case 1832u:
			case 1833u:
			case 1835u:
			case 1836u:
			case 1840u:
			case 1846u:
			case 1856u:
			case 1861u:
			case 1862u:
			case 1868u:
			case 1869u:
			case 1870u:
			case 1879u:
			case 1880u:
			case 1884u:
			case 1898u:
				break;
			case 1911u:
				this.OnFormattingStyleChanged(EventArgs.Empty);
				break;
			}
		}

		private void method_20(ref Message message_0)
		{
			if (this.Class456_0 == null || !this.IsFormFieldValidationEnabled || !base.IsHandleCreated)
			{
				return;
			}
			Struct62 struct62_ = (Struct62)message_0.GetLParam(typeof(Struct62));
			switch (struct62_.struct84_0.uint_0)
			{
			case 1853u:
				this.Class456_0.method_12((TextPart)Class429.smethod_3(0, (int)struct62_.uint_0));
				break;
			case 1837u:
				this.Class456_0.method_12((TextPart)struct62_.uint_1);
				break;
			case 1811u:
				this.Class456_0.method_9(new TextFieldEventArgs(this.textControlCore_0, (TextPart)struct62_.uint_1, (int)struct62_.uint_0, bCreateObject: false).TextField as FormField, (TextPart)struct62_.uint_1);
				break;
			case 1813u:
				if (new TextFieldEventArgs(this.textControlCore_0, (TextPart)struct62_.uint_1, (int)struct62_.uint_0, bCreateObject: false).TextField is FormField)
				{
					this.Class456_0.method_10((int)struct62_.uint_0, (TextPart)struct62_.uint_1);
				}
				break;
			case 1886u:
				if (this.Class456_0.Boolean_0 = this.EditMode == EditMode.ReadAndSelect && this.DocumentPermissions.ReadOnly)
				{
					this.Class456_0.method_8();
				}
				break;
			case 1883u:
				this.Class456_0.method_7((TextPart)struct62_.uint_1);
				break;
			case 1896u:
				this.Class456_0.method_12(TextPart.MainText);
				break;
			case 1901u:
			case 1902u:
			case 1903u:
			case 1904u:
				this.Class456_0.method_11(struct62_, (TextPart)struct62_.uint_1);
				break;
			case 1891u:
				this.Class456_0.method_6((TextPart)struct62_.uint_1);
				break;
			}
		}

		private void method_21(ref Message message_0)
		{
			Struct62 struct62_ = (Struct62)message_0.GetLParam(typeof(Struct62));
			if (this.statusBar_0 != null && this.statusBar_0.IsHandleCreated)
			{
				switch (struct62_.struct84_0.uint_0)
				{
				case 1796u:
				case 1797u:
				case 1800u:
				case 1804u:
				case 1807u:
				case 1819u:
				case 1832u:
				case 1837u:
				case 1838u:
				case 1853u:
				case 1854u:
				case 1861u:
					Class429.SendMessage(this.statusBar_0.Handle, 2052, (int)message_0.WParam, ref struct62_);
					break;
				}
			}
			if (this.buttonBar_0 != null && this.buttonBar_0.IsHandleCreated)
			{
				switch (struct62_.struct84_0.uint_0)
				{
				case 1796u:
				case 1797u:
				case 1800u:
				case 1804u:
				case 1805u:
				case 1807u:
				case 1815u:
				case 1832u:
				case 1837u:
				case 1838u:
				case 1841u:
				case 1842u:
				case 1853u:
				case 1854u:
				case 1883u:
				case 1886u:
				case 1887u:
				case 1888u:
				case 1891u:
					Class429.SendMessage(this.buttonBar_0.Handle, 2052, (int)message_0.WParam, ref struct62_);
					break;
				}
			}
			if (this.rulerBar_0 != null && this.rulerBar_0.IsHandleCreated)
			{
				switch (struct62_.struct84_0.uint_0)
				{
				case 1796u:
				case 1797u:
				case 1800u:
				case 1803u:
				case 1805u:
				case 1807u:
				case 1815u:
				case 1817u:
				case 1823u:
				case 1824u:
				case 1827u:
				case 1832u:
				case 1837u:
				case 1838u:
				case 1843u:
				case 1853u:
				case 1854u:
				case 1857u:
				case 1858u:
				case 1860u:
				case 1861u:
				case 1883u:
				case 1886u:
				case 1887u:
				case 1888u:
				case 1891u:
				case 1898u:
					Class429.SendMessage(this.rulerBar_0.Handle, 2052, (int)message_0.WParam, ref struct62_);
					break;
				}
			}
			if (this.rulerBar_1 != null && this.rulerBar_1.IsHandleCreated)
			{
				switch (struct62_.struct84_0.uint_0)
				{
				case 1796u:
				case 1797u:
				case 1800u:
				case 1807u:
				case 1815u:
				case 1818u:
				case 1823u:
				case 1824u:
				case 1827u:
				case 1832u:
				case 1837u:
				case 1838u:
				case 1843u:
				case 1853u:
				case 1854u:
				case 1857u:
				case 1858u:
				case 1859u:
				case 1861u:
				case 1883u:
				case 1886u:
				case 1887u:
				case 1888u:
				case 1891u:
				case 1898u:
					Class429.SendMessage(this.rulerBar_1.Handle, 2052, (int)message_0.WParam, ref struct62_);
					break;
				}
			}
		}

		internal void method_22(Control10 control10_0)
		{
			Control control = control10_0.Component as Control;
			if (control != null)
			{
				control.Visible = true;
				if (control.CanFocus)
				{
					control.Focus();
				}
				control10_0.ClearUndo();
				this.bool_0 = false;
				control10_0.method_12(this.eventHandler_0);
				control.Refresh();
			}
		}

		private void method_23(Control10 control10_0, DrawingFrame drawingFrame_0)
		{
			Control control = drawingFrame_0.Drawing as Control;
			if (control != null)
			{
				control.Visible = false;
				if (control.Handle != IntPtr.Zero)
				{
					Class429.SetWindowPos(control.Handle, IntPtr.Zero, 0, 0, 0, 0, 87u);
				}
				if (this.bool_0)
				{
					drawingFrame_0.AddUndoUnit();
				}
				control10_0.method_13(this.eventHandler_0);
			}
		}

		private void method_24(object sender, EventArgs e)
		{
			this.bool_0 = true;
		}

		private void method_25()
		{
			bool boolean_ = this.documentPermissions_0.Boolean_0;
			bool boolean_2 = this.documentPermissions_0.Boolean_1;
			bool boolean_3 = this.documentPermissions_0.Boolean_2;
			bool allowFormatting = this.documentPermissions_0.AllowFormatting;
			bool allowFormattingStyles = this.documentPermissions_0.AllowFormattingStyles;
			bool allowPrinting = this.documentPermissions_0.AllowPrinting;
			bool readOnly = this.documentPermissions_0.ReadOnly;
			bool allowEditingFormFields = this.documentPermissions_0.AllowEditingFormFields;
			this.documentPermissions_0.method_4();
			if (boolean_ != this.documentPermissions_0.Boolean_0)
			{
				this.method_12();
			}
			if (boolean_2 != this.documentPermissions_0.Boolean_1)
			{
				this.method_13();
			}
			if (boolean_3 != this.documentPermissions_0.Boolean_1)
			{
				this.method_14();
			}
			if (allowFormatting != this.documentPermissions_0.AllowFormatting)
			{
				this.method_16();
			}
			if (allowFormattingStyles != this.documentPermissions_0.AllowFormattingStyles)
			{
				this.method_15();
			}
			if (allowPrinting != this.documentPermissions_0.AllowPrinting)
			{
				this.method_10();
			}
			if (readOnly != this.documentPermissions_0.ReadOnly)
			{
				this.method_11();
			}
			if (allowEditingFormFields != this.documentPermissions_0.AllowEditingFormFields)
			{
				this.method_17();
			}
		}

		private bool method_26(IntPtr intptr_0, IntPtr intptr_1, IntPtr intptr_2)
		{
			string strFontName = Marshal.PtrToStringUni(intptr_0);
			string text = Marshal.PtrToStringUni(intptr_1);
			string[] array = KernelHelper.Ptr2StringArray(Class429.GlobalLock(intptr_2));
			Class429.GlobalLock(intptr_2);
			AdaptFontEventArgs adaptFontEventArgs = new AdaptFontEventArgs(strFontName, text, array);
			this.OnAdaptFont(adaptFontEventArgs);
			if (adaptFontEventArgs.AdaptedFontName != text)
			{
				string[] array2 = array;
				foreach (string text2 in array2)
				{
					if (text2 == adaptFontEventArgs.AdaptedFontName && adaptFontEventArgs.AdaptedFontName.Length < 32)
					{
						Marshal.Copy(adaptFontEventArgs.AdaptedFontName.ToCharArray(), 0, intptr_1, adaptFontEventArgs.AdaptedFontName.Length);
						Marshal.WriteInt16(intptr_1, adaptFontEventArgs.AdaptedFontName.Length * 2, 0);
						break;
					}
				}
			}
			return this.fontSettings_0.AdaptFontEvent;
		}

		private IntPtr method_27(IntPtr intptr_0, ushort ushort_0)
		{
			IntPtr intPtr = IntPtr.Zero;
			try
			{
				string strText = Marshal.PtrToStringUni(intptr_0);
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

		private IntPtr method_28(IntPtr intptr_0, IntPtr intptr_1)
		{
			IntPtr intPtr = IntPtr.Zero;
			try
			{
				string text = Marshal.PtrToStringUni(intptr_0);
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

		private ushort method_29(IntPtr intptr_0, ushort ushort_0, ushort ushort_1, IntPtr intptr_1, bool bool_20, ushort ushort_2)
		{
			ushort num = 0;
			try
			{
				string strWord = Marshal.PtrToStringUni(intptr_0);
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

		private void method_30(Color color_3, ViewMode viewMode_1)
		{
			if (color_3 == Color.Transparent)
			{
				if (viewMode_1 != ViewMode.SimpleControl)
				{
					throw new InvalidOperationException(this.resources.GetString("ERR_TRANSPARENT"));
				}
				base.SetStyle(ControlStyles.UserPaint, value: true);
				base.SetStyle(ControlStyles.SupportsTransparentBackColor, value: true);
				this.textControlCore_0.method_30(Enum83.const_30, 32768, 0);
			}
			else
			{
				base.SetStyle(ControlStyles.UserPaint, value: false);
				base.SetStyle(ControlStyles.SupportsTransparentBackColor, value: false);
				this.textControlCore_0.method_30(Enum83.const_30, 1, 0);
			}
		}

		private void method_31(Control control_0)
		{
			if (control_0 != null)
			{
				Class429.SendMessage_6(control_0.Handle, 2042, Class429.smethod_3(0, 1796), base.Handle);
			}
		}

		private void method_32(Control control_0)
		{
			if (control_0 != null)
			{
				Class429.SendMessage_1(control_0.Handle, 10, 0, 0);
			}
		}

		private void method_33(ref Message message_0)
		{
			Struct63 @struct = (Struct63)message_0.GetLParam(typeof(Struct63));
			message_0.Result = new IntPtr(0);
			MouseButtons button = MouseButtons.None;
			int clicks = 0;
			switch (@struct.int_0)
			{
			case 123:
				if (this.ContextMenuStrip != null)
				{
					Message m = Message.Create(message_0.HWnd, @struct.int_0, @struct.intptr_0, @struct.intptr_1);
					base.WndProc(ref m);
					message_0.Result = new IntPtr(1);
				}
				break;
			case 61:
			{
				IRawElementProviderSimple rawElementProviderSimple = this.Class603_0.method_3((TextPart)@struct.uint_0);
				if (rawElementProviderSimple != null)
				{
					message_0.Result = Class605.UiaReturnRawElementProvider(@struct.intptr_2, @struct.intptr_0, @struct.intptr_1, rawElementProviderSimple);
				}
				break;
			}
			case 512:
				this.OnMouseMove(new MouseEventArgs(Control.MouseButtons, 0, (int)(long)@struct.intptr_1 & 0xFFFF, ((int)(long)@struct.intptr_1 >> 16) & 0xFFFF, 0));
				break;
			case 514:
			case 517:
			case 520:
				switch (@struct.int_0)
				{
				case 520:
					button = MouseButtons.Middle;
					clicks = 1;
					break;
				case 517:
					button = MouseButtons.Right;
					clicks = 1;
					break;
				case 514:
					button = MouseButtons.Left;
					clicks = 1;
					break;
				}
				if (base.Enabled)
				{
					this.OnMouseUp(new MouseEventArgs(button, clicks, (int)(long)@struct.intptr_1 & 0xFFFF, ((int)(long)@struct.intptr_1 >> 16) & 0xFFFF, 0));
				}
				if (base.GetStyle(ControlStyles.UserMouse))
				{
					message_0.Result = new IntPtr(1);
				}
				break;
			case 513:
			case 515:
			case 516:
			case 518:
			case 519:
			case 521:
				switch (@struct.int_0)
				{
				case 513:
					button = MouseButtons.Left;
					clicks = 1;
					break;
				case 515:
					button = MouseButtons.Left;
					clicks = 2;
					break;
				case 516:
					button = MouseButtons.Right;
					clicks = 1;
					break;
				case 518:
					button = MouseButtons.Right;
					clicks = 2;
					break;
				case 519:
					button = MouseButtons.Middle;
					clicks = 1;
					break;
				case 521:
					button = MouseButtons.Middle;
					clicks = 2;
					break;
				}
				if (base.Enabled)
				{
					this.OnMouseDown(new MouseEventArgs(button, clicks, (int)(long)@struct.intptr_1 & 0xFFFF, ((int)(long)@struct.intptr_1 >> 16) & 0xFFFF, 0));
				}
				if (base.GetStyle(ControlStyles.UserMouse))
				{
					message_0.Result = new IntPtr(1);
				}
				break;
			case 256:
			case 257:
			case 258:
			case 260:
			case 261:
			{
				Message m = Message.Create(message_0.HWnd, @struct.int_0, @struct.intptr_0, @struct.intptr_1);
				message_0.Result = new IntPtr(this.ProcessKeyMessage(ref m) ? 1 : 0);
				break;
			}
			}
		}

		private void method_34(ref Message message_0)
		{
			ControlList controlList = this.textControlCore_0.control4_0;
			switch (message_0.Msg)
			{
			case 2074:
			{
				Struct65 @struct = (Struct65)message_0.GetLParam(typeof(Struct65));
				if (@struct.ushort_3 == 7)
				{
					controlList = this.textControlCore_0.control5_0;
				}
				else if (@struct.ushort_3 == 9)
				{
					controlList = this.textControlCore_0.control6_0;
				}
				message_0.Result = ((@struct.ushort_2 == 1) ? controlList.DrawControlBitmapToMetafile(@struct.ushort_1, message_0.WParam, @struct.struct83_0.method_0()) : controlList.PrintControl(@struct.ushort_1, message_0.WParam, @struct.struct83_0.method_0(), @struct.bool_0));
				break;
			}
			case 2075:
				if (Class429.smethod_6(message_0.WParam.ToInt32()) == 7)
				{
					controlList = this.textControlCore_0.control5_0;
				}
				else if (Class429.smethod_6(message_0.WParam.ToInt32()) == 9)
				{
					controlList = this.textControlCore_0.control6_0;
				}
				message_0.Result = (controlList.RemoveControl(Class429.smethod_5(message_0.WParam.ToInt32())) ? new IntPtr(1) : IntPtr.Zero);
				break;
			case 2076:
				if (Class429.smethod_6(message_0.WParam.ToInt32()) == 7)
				{
					controlList = this.textControlCore_0.control5_0;
				}
				else if (Class429.smethod_6(message_0.WParam.ToInt32()) == 9)
				{
					controlList = this.textControlCore_0.control6_0;
				}
				message_0.Result = controlList.GetControlImageData(Class429.smethod_5(message_0.WParam.ToInt32()), message_0.LParam.ToInt32());
				break;
			case 2078:
			{
				Struct66 struct66_ = (Struct66)message_0.GetLParam(typeof(Struct66));
				if (struct66_.ushort_2 != 7)
				{
					message_0.Result = ((struct66_.ushort_2 == 8) ? this.textControlCore_0.control4_0.method_0(struct66_.ushort_1, ref struct66_) : this.textControlCore_0.control6_0.method_4(struct66_.ushort_1, ref struct66_));
					Marshal.StructureToPtr((object)struct66_, message_0.LParam, fDeleteOld: false);
				}
				break;
			}
			case 2079:
			{
				Struct66 struct66_ = (Struct66)message_0.GetLParam(typeof(Struct66));
				if (struct66_.ushort_2 != 7)
				{
					message_0.Result = ((struct66_.ushort_2 == 8) ? this.textControlCore_0.control4_0.method_1(struct66_.ushort_1, ref struct66_) : this.textControlCore_0.control6_0.method_5(struct66_.ushort_1, ref struct66_));
				}
				break;
			}
			case 2080:
			{
				Struct67 struct67_ = (Struct67)message_0.GetLParam(typeof(Struct67));
				if (struct67_.ushort_2 == 8)
				{
					message_0.Result = this.textControlCore_0.control4_0.method_2(struct67_.ushort_1, ref struct67_);
					Marshal.StructureToPtr((object)struct67_, message_0.LParam, fDeleteOld: false);
				}
				break;
			}
			case 2082:
				if (Class429.smethod_6(message_0.WParam.ToInt32()) == 7)
				{
					controlList = this.textControlCore_0.control5_0;
				}
				else if (Class429.smethod_6(message_0.WParam.ToInt32()) == 9)
				{
					controlList = this.textControlCore_0.control6_0;
				}
				message_0.Result = controlList.GetControlData(Class429.smethod_5(message_0.WParam.ToInt32()), message_0.LParam);
				break;
			case 2083:
				if (Class429.smethod_6(message_0.WParam.ToInt32()) == 7)
				{
					controlList = this.textControlCore_0.control5_0;
				}
				else if (Class429.smethod_6(message_0.WParam.ToInt32()) == 9)
				{
					controlList = this.textControlCore_0.control6_0;
				}
				message_0.Result = controlList.GetControlDataSize(Class429.smethod_5(message_0.WParam.ToInt32()));
				break;
			case 2084:
				if (Class429.smethod_6(message_0.WParam.ToInt32()) == 7)
				{
					controlList = this.textControlCore_0.control5_0;
				}
				else if (Class429.smethod_6(message_0.WParam.ToInt32()) == 9)
				{
					controlList = this.textControlCore_0.control6_0;
				}
				message_0.Result = controlList.PasteControlData(Class429.smethod_5(message_0.WParam.ToInt32()), message_0.LParam);
				break;
			case 2085:
				if (Class429.smethod_6(message_0.LParam.ToInt32()) == 7)
				{
					controlList = this.textControlCore_0.control5_0;
				}
				else if (Class429.smethod_6(message_0.LParam.ToInt32()) == 9)
				{
					controlList = this.textControlCore_0.control6_0;
				}
				message_0.Result = controlList.CreateControl(Class429.smethod_5(message_0.LParam.ToInt32()));
				break;
			case 2077:
			case 2081:
			case 2086:
			case 2087:
			case 2088:
			case 2089:
				break;
			case 2090:
				if (Class429.smethod_6(message_0.WParam.ToInt32()) == 9)
				{
					message_0.Result = this.textControlCore_0.control6_0.method_1(Class429.smethod_5(message_0.WParam.ToInt32()), message_0.LParam);
				}
				break;
			case 2091:
				if (Class429.smethod_6(message_0.WParam.ToInt32()) == 9)
				{
					message_0.Result = this.textControlCore_0.control6_0.method_2(Class429.smethod_5(message_0.WParam.ToInt32()), message_0.LParam);
				}
				break;
			case 2092:
				if (Class429.smethod_6(message_0.WParam.ToInt32()) == 9)
				{
					message_0.Result = this.textControlCore_0.control6_0.method_0(Class429.smethod_5(message_0.WParam.ToInt32()), message_0.LParam.ToInt32());
				}
				break;
			}
		}

		/// <summary>Opens a file open dialogbox and appends the selected file to the existing document.</summary>
		/// <param name="appendSettings">Specifies settings on how the document is appended.</param>
		public DialogResult Append(AppendSettings appendSettings)
		{
			return this.Append(StreamType.All, appendSettings);
		}

		/// <summary>Opens a file open dialogbox and appends the selected file with the specified format to the existing document.</summary>
		/// <param name="streamType">Specifies one of the StreamType values.</param>
		/// <param name="appendSettings">Specifies settings on how the document is appended.</param>
		public DialogResult Append(StreamType streamType, AppendSettings appendSettings)
		{
			return this.Append(streamType, new LoadSettings(), appendSettings);
		}

		/// <summary>Loads text with the specified format from the specified file and appends it to the existing document.</summary>
		/// <param name="path">Specifies a file from which the data is loaded.</param>
		/// <param name="streamType">Specifies one of the StreamType values.</param>
		/// <param name="appendSettings">Specifies settings on how the document is appended.</param>
		public void Append(string path, StreamType streamType, AppendSettings appendSettings)
		{
			this.Append(path, streamType, new LoadSettings(), appendSettings);
		}

		/// <summary>Loads text with the specified format from the specified file stream and appends it to the existing document.</summary>
		/// <param name="fileStream">Specifies a file from which the data is loaded.</param>
		/// <param name="streamType">Specifies one of the StreamType values.</param>
		/// <param name="appendSettings">Specifies settings on how the document is appended.</param>
		public void Append(FileStream fileStream, StreamType streamType, AppendSettings appendSettings)
		{
			this.Append(fileStream, streamType, new LoadSettings(), appendSettings);
		}

		/// <summary>Loads text with the specified format from the specified byte array and appends it to the existing document.</summary>
		/// <param name="binaryData">Specifies a byte array from which the data is loaded.</param>
		/// <param name="binaryStreamType">Specifies one of the BinaryStreamType values.</param>
		/// <param name="appendSettings">Specifies settings on how the document is appended.</param>
		public void Append(byte[] binaryData, BinaryStreamType binaryStreamType, AppendSettings appendSettings)
		{
			this.Append(binaryData, binaryStreamType, new LoadSettings(), appendSettings);
		}

		/// <summary>Loads text with the specified format from the specified string and appends it to the existing document.</summary>
		/// <param name="stringData">Specifies a string from which the data is loaded.</param>
		/// <param name="stringStreamType">Specifies one of the StringStreamType values.</param>
		/// <param name="appendSettings">Specifies settings on how the document is appended.</param>
		public void Append(string stringData, StringStreamType stringStreamType, AppendSettings appendSettings)
		{
			this.Append(stringData, stringStreamType, new LoadSettings(), appendSettings);
		}

		/// <summary>Opens a file open dialogbox and appends the selected file with the specified format and special settings to the existing document.</summary>
		/// <param name="streamType">Specifies one of the StreamType values.</param>
		/// <param name="loadSettings">Specifies a LoadSettings object with additional information and settings for the load operation.</param>
		/// <param name="appendSettings">Specifies settings on how the document is appended.</param>
		public DialogResult Append(StreamType streamType, LoadSettings loadSettings, AppendSettings appendSettings)
		{
			if (!loadSettings.method_0(streamType, this.textControlCore_0, (Enum104)(appendSettings | (AppendSettings)2 | (AppendSettings)1), null))
			{
				return DialogResult.Cancel;
			}
			return DialogResult.OK;
		}

		/// <summary>Loads text with the specified format and special settings from the specified file and appends it to the existing document.</summary>
		/// <param name="path">Specifies a file from which the data is loaded.</param>
		/// <param name="streamType">Specifies one of the StreamType values.</param>
		/// <param name="loadSettings">Specifies a LoadSettings object with additional information and settings for the load operation.</param>
		/// <param name="appendSettings">Specifies settings on how the document is appended.</param>
		public void Append(string path, StreamType streamType, LoadSettings loadSettings, AppendSettings appendSettings)
		{
			loadSettings.method_1(path, streamType, this.textControlCore_0, (Enum104)(appendSettings | (AppendSettings)2 | (AppendSettings)1), null);
		}

		/// <summary>Loads text with the specified format and special settings from the specified file stream and appends it to the existing document.</summary>
		/// <param name="fileStream">Specifies a file from which the data is loaded.</param>
		/// <param name="streamType">Specifies one of the StreamType values.</param>
		/// <param name="loadSettings">Specifies a LoadSettings object with additional information and settings for the load operation.</param>
		/// <param name="appendSettings">Specifies settings on how the document is appended.</param>
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
		/// <param name="appendSettings">Specifies settings on how the document is appended.</param>
		public void Append(string stringData, StringStreamType stringStreamType, LoadSettings loadSettings, AppendSettings appendSettings)
		{
			loadSettings.method_5(stringData, stringStreamType, this.textControlCore_0, (Enum104)(appendSettings | (AppendSettings)2 | (AppendSettings)1), null);
		}

		/// <summary>Opens a dialog box to select a file and loads the text from that file.</summary>
		public DialogResult Load()
		{
			return this.Load(StreamType.All);
		}

		/// <summary>Opens a dialog box to select a file in the specified format and loads the text from that file.</summary>
		/// <param name="streamType">Specifies one of the StreamType values.</param>
		public DialogResult Load(StreamType streamType)
		{
			return this.Load(streamType, new LoadSettings());
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

		/// <summary>Opens a dialog box to select a file in the specified format and loads the text from that file using the specified special settings.</summary>
		/// <param name="streamType">Specifies one of the StreamType values.</param>
		/// <param name="loadSettings">Specifies a LoadSettings object with additional information and settings for the load operation.</param>
		public DialogResult Load(StreamType streamType, LoadSettings loadSettings)
		{
			if (!loadSettings.method_0(streamType, this.textControlCore_0, Enum104.const_0, this.documentSettings))
			{
				return DialogResult.Cancel;
			}
			return DialogResult.OK;
		}

		/// <summary>Loads text formatted with the specified format. The new text is read from the specified file and loaded using the given special settings.</summary>
		/// <param name="path">Specifies a file from which the data is loaded.</param>
		/// <param name="streamType">Specifies one of the StreamType values.</param>
		/// <param name="loadSettings">Specifies a LoadSettings object with additional information and settings for the load operation.</param>
		public void Load(string path, StreamType streamType, LoadSettings loadSettings)
		{
			loadSettings.method_1(path, streamType, this.textControlCore_0, Enum104.const_0, this.documentSettings);
		}

		/// <summary>Loads text formatted with the specified format. The new text is read from the specified file stream and loaded using the given special settings.</summary>
		/// <param name="fileStream">Specifies a file from which the data is loaded.</param>
		/// <param name="streamType">Specifies one of the StreamType values.</param>
		/// <param name="loadSettings">Specifies a LoadSettings object with additional information and settings for the load operation.</param>
		public void Load(FileStream fileStream, StreamType streamType, LoadSettings loadSettings)
		{
			loadSettings.method_2(fileStream, streamType, this.textControlCore_0, Enum104.const_0, this.documentSettings);
		}

		/// <summary>Loads text formatted with the specified format. The new text is read from the specified byte array and loaded using the given special settings.</summary>
		/// <param name="binaryData">Specifies a byte array from which the data is loaded.</param>
		/// <param name="binaryStreamType">Specifies one of the BinaryStreamType values.</param>
		/// <param name="loadSettings">Specifies a LoadSettings object with additional information and settings for the load operation.</param>
		public void Load(byte[] binaryData, BinaryStreamType binaryStreamType, LoadSettings loadSettings)
		{
			loadSettings.method_3(binaryData, binaryStreamType, this.textControlCore_0, Enum104.const_0, this.documentSettings);
		}

		/// <summary>Loads text formatted with the specified format. The new text is read from the specified string and loaded using the given special settings.</summary>
		/// <param name="stringData">Specifies a string from which the data is loaded.</param>
		/// <param name="stringStreamType">Specifies one of the StringStreamType values.</param>
		/// <param name="loadSettings">Specifies a LoadSettings object with additional information and settings for the load operation.</param>
		public void Load(string stringData, StringStreamType stringStreamType, LoadSettings loadSettings)
		{
			loadSettings.method_5(stringData, stringStreamType, this.textControlCore_0, Enum104.const_0, this.documentSettings);
		}

		/// <summary>Opens a file save dialogbox and saves the complete contents of a document in a file.</summary>
		public DialogResult Save()
		{
			return this.Save(StreamType.All);
		}

		/// <summary>Opens a file save dialogbox and saves the complete contents of a document in a file with the specified format.</summary>
		/// <param name="streamType">Specifies one of the StreamType values.</param>
		public DialogResult Save(StreamType streamType)
		{
			return this.Save(streamType, new SaveSettings());
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

		/// <summary>Opens a file save dialogbox and saves the complete contents of a document in a file with the specified format and special settings.</summary>
		/// <param name="streamType">Specifies one of the StreamType values.</param>
		/// <param name="saveSettings">Specifies a SaveSettings object with additional information and settings for the save operation.</param>
		public DialogResult Save(StreamType streamType, SaveSettings saveSettings)
		{
			this.documentSettings.method_1(saveSettings);
			if (!saveSettings.method_0(streamType, this.textControlCore_0, Enum104.const_0))
			{
				return DialogResult.Cancel;
			}
			return DialogResult.OK;
		}

		/// <summary>Saves the complete contents of a document in the specified file using the specified format and special settings.</summary>
		/// <param name="path">Specifies a file into which the data is saved.</param>
		/// <param name="streamType">Specifies one of the StreamType values.</param>
		/// <param name="saveSettings">Specifies a SaveSettings object with additional information and settings for the save operation.</param>
		public void Save(string path, StreamType streamType, SaveSettings saveSettings)
		{
			this.documentSettings.method_1(saveSettings);
			saveSettings.method_1(path, streamType, this.textControlCore_0, Enum104.const_0);
		}

		/// <summary>Saves the complete contents of a document in the specified file stream using the specified format and special settings.</summary>
		/// <param name="fileStream">Specifies a file into which the data is saved.</param>
		/// <param name="streamType">Specifies one of the StreamType values.</param>
		/// <param name="saveSettings">Specifies a SaveSettings object with additional information and settings for the save operation.</param>
		public void Save(FileStream fileStream, StreamType streamType, SaveSettings saveSettings)
		{
			this.documentSettings.method_1(saveSettings);
			saveSettings.method_2(fileStream, streamType, this.textControlCore_0, Enum104.const_0);
		}

		/// <summary>Saves the complete contents of a document in the specified byte array using the specified format and special settings.</summary>
		/// <param name="binaryData">Specifies a byte array into which the data is saved.</param>
		/// <param name="binaryStreamType">Specifies one of the BinaryStreamType values.</param>
		/// <param name="saveSettings">Specifies a SaveSettings object with additional information and settings for the save operation.</param>
		public void Save(out byte[] binaryData, BinaryStreamType binaryStreamType, SaveSettings saveSettings)
		{
			this.documentSettings.method_1(saveSettings);
			saveSettings.method_3(out binaryData, binaryStreamType, this.textControlCore_0, Enum104.const_0);
		}

		/// <summary>Saves the complete contents of a document as a string using the specified format and special settings.</summary>
		/// <param name="stringData">Specifies a string into which the data is saved.</param>
		/// <param name="stringStreamType">Specifies one of the StringStreamType values.</param>
		/// <param name="saveSettings">Specifies a SaveSettings object with additional information and settings for the save operation.</param>
		public void Save(out string stringData, StringStreamType stringStreamType, SaveSettings saveSettings)
		{
			this.documentSettings.method_1(saveSettings);
			saveSettings.method_4(out stringData, stringStreamType, this.textControlCore_0, Enum104.const_0);
		}

		/// <summary>Clears the selected text or the character right from the current input position from the Text Control. This method works only if the Text Control has the focus.</summary>
		public void Clear()
		{
			if (base.IsHandleCreated)
			{
				this.textControlCore_0.method_29(TextPart.Auto, 771, 0, 0);
			}
		}

		/// <summary>Copies the current selection in the Text Control to the Clipboard.</summary>
		public void Copy()
		{
			this.method_35(bool_20: true);
		}

		internal void method_35(bool bool_20)
		{
			if (base.IsHandleCreated)
			{
				this.textControlCore_0.method_29(TextPart.Auto, 769, (!bool_20) ? 1 : 0, 0);
			}
		}

		/// <summary>Moves the current selection in the Text Control to the Clipboard.</summary>
		public void Cut()
		{
			this.method_36(bool_20: true);
		}

		internal void method_36(bool bool_20)
		{
			if (base.IsHandleCreated)
			{
				this.textControlCore_0.method_29(TextPart.Auto, 768, (!bool_20) ? 1 : 0, 0);
			}
		}

		/// <summary>Replaces the current selection in the Text Control with the contents of the Clipboard. If the data in the clipboard are provided in several formats, the format with the maximum of information is used.</summary>
		public void Paste()
		{
			if (base.IsHandleCreated)
			{
				this.textControlCore_0.method_29(TextPart.Auto, 770, 0, 0);
			}
		}

		/// <summary>Replaces the current selection in the Text Control with the contents of the Clipboard. Only data provided in the specified format is inserted.</summary>
		/// <param name="format">Specifies the format to paste.</param>
		public void Paste(ClipboardFormat format)
		{
			if (base.IsHandleCreated)
			{
				this.textControlCore_0.method_29(TextPart.Auto, 2061, (int)format, 0);
			}
		}

		/// <summary>Returns an array of ClipboardFormat values. These values specify all the data formats which are currently available in the clipboard and which can be pasted into a TextControl document. If there is no data format available, this method returns null.</summary>
		public ClipboardFormat[] GetClipboardFormats()
		{
			if (base.IsHandleCreated)
			{
				int[] array = new int[10];
				int num = this.textControlCore_0.method_40(TextPart.Auto, 1920, 10, array);
				if (num > 0)
				{
					ClipboardFormat[] array2 = new ClipboardFormat[num];
					for (int i = 0; i < num; i++)
					{
						array2[i] = (ClipboardFormat)array[i];
					}
					return array2;
				}
			}
			return null;
		}

		/// <summary>Clears the undo buffer of the Text Control.</summary>
		public void ClearUndo()
		{
			if (base.IsHandleCreated)
			{
				this.textControlCore_0.method_29(TextPart.Auto, 2039, 0, 0);
			}
		}

		/// <summary>Undoes the last edit operation in the Text Control.</summary>
		public void Undo()
		{
			if (base.IsHandleCreated)
			{
				this.textControlCore_0.method_29(TextPart.Auto, 2032, 0, 0);
			}
		}

		/// <summary>Redoes the last Text Control operation.</summary>
		public void Redo()
		{
			if (base.IsHandleCreated)
			{
				this.textControlCore_0.method_29(TextPart.Auto, 2040, 0, 0);
			}
		}

		/// <summary>Deletes the entire contents of a Text Control.</summary>
		public void ResetContents()
		{
			if (!base.IsHandleCreated)
			{
				return;
			}
			try
			{
				this.documentSettings.method_2();
				this.textControlCore_0.method_30(Enum83.const_69, 0, 0);
				this.textControlCore_0.method_23(bool_1: true);
				this.paragraphFormat_0.method_9();
				this.method_0();
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

		/// <summary>Selects all text in the Text Control.</summary>
		public void SelectAll()
		{
			if (base.IsHandleCreated)
			{
				this.textControlCore_0.method_29(TextPart.Auto, 1158, 0, Class429.smethod_3(0, -1));
			}
		}

		/// <summary>Selects text within the Text Control.</summary>
		/// <param name="start">Specifies the selection's start position.</param>
		/// <param name="length">Specifies the number of selected characters.</param>
		public void Select(int start, int length)
		{
			if (base.IsHandleCreated)
			{
				int[] array = new int[2]
				{
					start + length,
					start
				};
				this.textControlCore_0.method_40(TextPart.Auto, 1158, 1, array);
			}
		}

		/// <summary>Selects the word at the current text input position.</summary>
		public void SelectWord()
		{
			if (base.IsHandleCreated)
			{
				this.textControlCore_0.method_8();
			}
		}

		/// <summary>Opens the built-in Find dialog box to search for a text string in the text part with the input focus. This can be the main text, a text frame or a header or footer.</summary>
		public void Find()
		{
			this.textControlCore_0.method_29(TextPart.Auto, 1651, 0, 0);
		}

		/// <summary>Searches for the specified text string in the text part with the input focus. This can be the main text, a text frame or a header or footer. The search starts at the beginning of the text.</summary>
		/// <param name="text">Specifies the text to search for.</param>
		public int Find(string text)
		{
			Struct59 struct59_ = new Struct59(text);
			return this.textControlCore_0.method_53(TextPart.Auto, Enum83.const_175, 0, ref struct59_);
		}

		/// <summary>Searches for the specified text string in the text part with the input focus. This can be the main text, a text frame or a header or footer. The search is done with the specified find options and starts at the specified position.</summary>
		/// <param name="text">Specifies the text to search for.</param>
		/// <param name="start">Specifies the text position where the search starts, beginning with 0.</param>
		/// <param name="options">Specifies search options.</param>
		public int Find(string text, int start, FindOptions options)
		{
			Struct59 struct59_ = new Struct59(text, start, (uint)options);
			return this.textControlCore_0.method_53(TextPart.Auto, Enum83.const_175, 0, ref struct59_);
		}

		internal void method_37(string string_3, FindOptions findOptions_0, Enum55 enum55_0)
		{
			if (enum55_0 != 0)
			{
				Struct59 struct59_ = new Struct59(string_3, -1, (uint)findOptions_0 | (uint)enum55_0);
				this.textControlCore_0.method_53(TextPart.Auto, Enum83.const_175, 0, ref struct59_);
			}
		}

		/// <summary>Opens the built-in Replace dialog box.</summary>
		public void Replace()
		{
			this.textControlCore_0.method_29(TextPart.Auto, 2045, 0, 0);
		}

		internal void method_38(string string_3, string string_4, FindOptions findOptions_0, Enum55 enum55_0)
		{
			if (enum55_0 != 0)
			{
				Struct60 struct60_ = new Struct60(string_3, string_4, -1, (uint)findOptions_0 | (uint)enum55_0);
				this.textControlCore_0.method_54(TextPart.Auto, Enum83.const_361, 0, ref struct60_);
			}
		}

		/// <summary>Opens the standard print dialog to get printer settings and prints the document.</summary>
		/// <param name="docName">Specifies the document's name.</param>
		public void Print(string docName)
		{
			Class590 @class = new Class590(this.textControlCore_0);
			@class.method_1(docName);
		}

		/// <summary>Prints the document using the printer settings of the specified PrintDocument.</summary>
		/// <param name="printDocument">Specifies an instance of the PrintDocument class.</param>
		public void Print(PrintDocument printDocument)
		{
			Class590 @class = new Class590(this.textControlCore_0);
			@class.method_2(printDocument);
		}

		/// <summary>Prints a single page. This method can be called from the PrintPage event handler.</summary>
		/// <param name="page">Specifies a page number to print.</param>
		/// <param name="ppe">Specifies the event arguments of the print document's PrintPage event.</param>
		public void Print(int page, PrintPageEventArgs ppe)
		{
			Class590 @class = new Class590(this.textControlCore_0);
			@class.method_9(page, ppe);
		}

		/// <summary>Shows a print preview of the current document.</summary>
		/// <param name="docName">Specifies the document's name.</param>
		public void PrintPreview(string docName)
		{
			Class590 @class = new Class590(this.textControlCore_0);
			@class.method_3(docName);
		}

		/// <summary>Shows a print preview of the current document using settings from the specified PrintDocument object.</summary>
		/// <param name="printDocument">Specifies an instance of the PrintDocument class.</param>
		public void PrintPreview(PrintDocument printDocument)
		{
			Class590 @class = new Class590(this.textControlCore_0);
			@class.method_4(printDocument);
		}

		/// <summary>Zooms the contents of the TextControl using the specified zoom factor.</summary>
		/// <param name="zoomFactor">Specifies the zoom factor, in percent.</param>
		public void Zoom(int zoomFactor)
		{
			this.ZoomFactor = zoomFactor;
		}

		/// <summary>Zooms the contents of the TextControl using the specified option.</summary>
		/// <param name="zoomOption">Specifies one of the ZoomOption values.</param>
		public void Zoom(ZoomOption zoomOption)
		{
			this.textControlCore_0.method_30(Enum83.const_354, 0, Class429.smethod_3(1, (int)zoomOption));
		}

		public PageCollection GetPages()
		{
			
			if (base.IsHandleCreated && this.ViewMode == ViewMode.PageView)
			{
				return new PageCollection(this.textControlCore_0);
			}
			return null;
		}

		/// <summary>Gets an array of strings specifying the names of all currently supported fonts. These fonts depend on the formatting device set with the TextControl.FormattingPrinter property. The method returns null, if the TextControl has not been completely initialized.</summary>
		public string[] GetSupportedFonts()
		{
			return this.textControlCore_0.GetSupportedFonts();
		}

		/// <summary>Gets an array of PaperSize structures specifying the names and the size of all currently supported paper sizes. These paper sizes depend on the formatting device set with the TextControl.FormattingPrinter property. The method returns null, if the TextControl has not been completely initialized.</summary>
		public PaperSize[] GetSupportedPaperSizes()
		{
			return this.textControlCore_0.GetSupportedPaperSizes();
		}

		/// <summary>Returns a collection containing text fields of the specified types.</summary>
		/// <param name="fieldType">Specifies types of text fields.</param>
		public TextFieldCollection GetTextFields(TextFieldType fieldType)
		{
			if (!base.IsHandleCreated)
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
			if (base.IsHandleCreated && this.class408 != null)
			{
				return new VersionInfo(this.class408, Enum115.Enterprise);
			}
			return null;
		}

		public string GetVersionString()
		{
			string text = string.Empty;
			if (base.IsHandleCreated && this.class408 != null)
			{
				int num = this.class408.method_6();
				int num2 = num / 100;
				int num3 = num % 100 / 10;
				int num4 = num % 100 % 10;
				int num5 = this.class408.method_7();
				int num6 = ((num5 < 500) ? (num5 % 100) : 0);
				text = num2 + "." + num3;
			}
			return text;
		}

		/// <summary>Begins a user-defined undo operation. All editing and fomatting changes made between BeginUndoAction and EndUndoAction belong to the undo operation. These changes are undone or redone in a single step. The specified user-defined name is available with the UndoActionName property.</summary>
		/// <param name="actionName">Specifies the undo action's name.</param>
		public void BeginUndoAction(string actionName)
		{
			if (base.IsHandleCreated)
			{
				this.textControlCore_0.method_19(TextPart.Auto, actionName);
				this.textControlCore_0.method_10(bool_1: true);
			}
		}

		/// <summary>Ends a user-defined undo operation. All editing and fomatting changes made between BeginUndoAction and EndUndoAction belong to the undo operation. These changes are undone or redone in a single step.</summary>
		public void EndUndoAction()
		{
			if (base.IsHandleCreated)
			{
				this.textControlCore_0.method_20(TextPart.Auto);
				this.textControlCore_0.method_10(bool_1: false);
			}
		}

		/// <summary>Computes the specified point in twips into client coordinates.</summary>
		/// <param name="point">Specifies a document point which client coordinates are computed.</param>
		public Point DocumentToClient(Point point)
		{
			if (!base.IsHandleCreated)
			{
				throw new InvalidOperationException();
			}
			Class429.Struct82 struct82_ = new Class429.Struct82(point.X, point.Y);
			if (this.textControlCore_0.method_35(TextPart.MainText, Enum83.const_320, Class429.smethod_3(1, 2), ref struct82_) == 0)
			{
				throw new InvalidOperationException();
			}
			return new Point(struct82_.int_0, struct82_.int_1);
		}

		/// <summary>Computes the specified rectangle in twips into client coordinates.</summary>
		/// <param name="rectangle">Specifies a document rectangle which client coordinates are computed.</param>
		public Rectangle DocumentToClient(Rectangle rectangle)
		{
			if (!base.IsHandleCreated)
			{
				throw new InvalidOperationException();
			}
			int[] array = new int[4] { rectangle.Left, rectangle.Top, rectangle.Right, rectangle.Bottom };
			if (this.textControlCore_0.method_40(TextPart.MainText, 1990, Class429.smethod_3(2, 2), array) == 0)
			{
				throw new InvalidOperationException();
			}
			return new Rectangle(array[0], array[1], array[2] - array[0], array[3] - array[1]);
		}

		/// <summary>Computes the specified client point into document coordinates.</summary>
		/// <param name="point">Specifies a client point which document coordinates are computed.</param>
		public Point ClientToDocument(Point point)
		{
			if (!base.IsHandleCreated)
			{
				throw new InvalidOperationException();
			}
			Class429.Struct82 struct82_ = new Class429.Struct82(point.X, point.Y);
			if (this.textControlCore_0.method_35(TextPart.MainText, Enum83.const_320, Class429.smethod_3(1, 1), ref struct82_) == 0)
			{
				throw new InvalidOperationException();
			}
			return new Point(struct82_.int_0, struct82_.int_1);
		}

		/// <summary>Computes the specified client rectangle into document coordinates.</summary>
		/// <param name="rectangle">Specifies a client rectangle which document coordinates are computed.</param>
		public Rectangle ClientToDocument(Rectangle rectangle)
		{
			if (!base.IsHandleCreated)
			{
				throw new InvalidOperationException();
			}
			int[] array = new int[4] { rectangle.Left, rectangle.Top, rectangle.Right, rectangle.Bottom };
			if (this.textControlCore_0.method_40(TextPart.MainText, 1990, Class429.smethod_3(2, 1), array) == 0)
			{
				throw new InvalidOperationException();
			}
			return new Rectangle(array[0], array[1], array[2] - array[0], array[3] - array[1]);
		}

		/// <summary>Invokes a built-in dialog box for inserting symbol characters.</summary>
		public void AddSymbolDialog()
		{
			if (!base.IsHandleCreated)
			{
				throw new InvalidOperationException(this.resources.GetString("ERR_NOTLOADED"));
			}
			this.textControlCore_0.method_29(TextPart.Auto, 1972, 0, 0);
		}

		/// <summary>Opens the dialog box showing its first tab.</summary>
		public DialogResult BarcodeLayoutDialog()
		{
			return this.BarcodeLayoutDialog(0);
		}

		/// <summary>Opens the dialog box showing the specified tab.</summary>
		/// <param name="activeTab">Specifies the index of the tab, zero-based, that is displayed when the tabbed dialog box is opened.</param>
		public DialogResult BarcodeLayoutDialog(int activeTab)
		{
			if (!base.IsHandleCreated)
			{
				throw new InvalidOperationException(this.resources.GetString("ERR_NOTLOADED"));
			}
			return this.textControlCore_0.method_29(TextPart.Auto, 1250, 0, Class429.smethod_3(256, activeTab)) switch
			{
				1 => DialogResult.Cancel, 
				2 => DialogResult.OK, 
				_ => throw new TextEditorException(this.resources.GetString("ERR_INTERNAL")), 
			};
		}

		/// <summary>Opens the dialog box showing its first tab.</summary>
		public DialogResult ChartLayoutDialog()
		{
			return this.ChartLayoutDialog(0);
		}

		/// <summary>Opens the dialog box showing the specified tab.</summary>
		/// <param name="activeTab">Specifies the index of the tab, zero-based, that is displayed when the tabbed dialog box is opened.</param>
		public DialogResult ChartLayoutDialog(int activeTab)
		{
			
			if (!base.IsHandleCreated)
			{
				throw new InvalidOperationException(this.resources.GetString("ERR_NOTLOADED"));
			}
			return this.textControlCore_0.method_29(TextPart.Auto, 1250, 0, Class429.smethod_3(128, activeTab)) switch
			{
				1 => DialogResult.Cancel, 
				2 => DialogResult.OK, 
				_ => throw new TextEditorException(this.resources.GetString("ERR_INTERNAL")), 
			};
		}

		/// <summary>Opens a dialog box to create a new Conditional Instruction.</summary>
		public DialogResult ConditionalInstructionDialog()
		{
			
			if (this.FormFields.Count != 0 && this.IsFormFieldValidationEnabled && this.EditMode != EditMode.ReadAndSelect)
			{
				string text = null;
				return this.Class456_0.method_16(ref text);
			}
			return DialogResult.Abort;
		}

		/// <summary>Opens a dialog box to edit a specific Conditional Instruction. If the document does not contain a Conditional Instruction with the specified name, the dialog is opened to create such a Conditional Instruction.</summary>
		/// <param name="name">Specifies the name of the Conditional Instruction to edit or create.</param>
		public DialogResult ConditionalInstructionDialog(string name)
		{
			
			if (this.FormFields.Count != 0 && this.IsFormFieldValidationEnabled && this.EditMode != EditMode.ReadAndSelect)
			{
				string text = name;
				return this.Class456_0.method_16(ref text);
			}
			return DialogResult.Abort;
		}

		/// <summary>Opens the dialog box showing its first tab.</summary>
		public DialogResult DrawingLayoutDialog()
		{
			return this.DrawingLayoutDialog(0);
		}

		/// <summary>Opens the dialog box showing the specified tab.</summary>
		/// <param name="activeTab">Specifies the index of the tab, zero-based, that is displayed when the tabbed dialog box is opened.</param>
		public DialogResult DrawingLayoutDialog(int activeTab)
		{
			if (!base.IsHandleCreated)
			{
				throw new InvalidOperationException(this.resources.GetString("ERR_NOTLOADED"));
			}
			return this.textControlCore_0.method_29(TextPart.Auto, 1250, 0, Class429.smethod_3(512, activeTab)) switch
			{
				1 => DialogResult.Cancel, 
				2 => DialogResult.OK, 
				_ => throw new TextEditorException(this.resources.GetString("ERR_INTERNAL")), 
			};
		}

		/// <summary>Invokes the built-in font dialog box.</summary>
		public DialogResult FontDialog()
		{
			if (!base.IsHandleCreated)
			{
				throw new InvalidOperationException(this.resources.GetString("ERR_NOTLOADED"));
			}
			return this.textControlCore_0.method_29(TextPart.Auto, 1178, 0, 0) switch
			{
				1 => DialogResult.Cancel, 
				2 => DialogResult.OK, 
				_ => throw new TextEditorException(this.resources.GetString("ERR_INTERNAL")), 
			};
		}

		/// <summary>Invokes the built-in dialog box for setting the text color.</summary>
		public DialogResult ForeColorDialog()
		{
			if (!base.IsHandleCreated)
			{
				throw new InvalidOperationException(this.resources.GetString("ERR_NOTLOADED"));
			}
			return this.textControlCore_0.method_29(TextPart.Auto, 1168, 32, 0) switch
			{
				1 => DialogResult.Cancel, 
				2 => DialogResult.OK, 
				_ => throw new TextEditorException(this.resources.GetString("ERR_INTERNAL")), 
			};
		}

		/// <summary>Invokes the built-in dialog box for creating, deleting and modifying formatting styles.</summary>
		public DialogResult FormattingStylesDialog()
		{
			if (!base.IsHandleCreated)
			{
				throw new InvalidOperationException(this.resources.GetString("ERR_NOTLOADED"));
			}
			return this.textControlCore_0.method_30(Enum83.const_143, 0, 0) switch
			{
				1 => DialogResult.Cancel, 
				2 => DialogResult.OK, 
				_ => throw new TextEditorException(this.resources.GetString("ERR_INTERNAL")), 
			};
		}

		/// <summary>Invokes the built-in dialog box for choosing a color for the background of a paragraph or a table cell.</summary>
		public DialogResult FrameFillColorDialog()
		{
			if (!base.IsHandleCreated)
			{
				throw new InvalidOperationException(this.resources.GetString("ERR_NOTLOADED"));
			}
			return this.textControlCore_0.method_30(Enum83.const_316, 256, 0) switch
			{
				1 => DialogResult.Cancel, 
				2 => DialogResult.OK, 
				_ => throw new TextEditorException(this.resources.GetString("ERR_INTERNAL")), 
			};
		}

		/// <summary>Invokes the built-in dialog box for choosing a color for the frame of a paragraph or a table.</summary>
		public DialogResult FrameLineColorDialog()
		{
			if (!base.IsHandleCreated)
			{
				throw new InvalidOperationException(this.resources.GetString("ERR_NOTLOADED"));
			}
			return this.textControlCore_0.method_30(Enum83.const_316, 128, 0) switch
			{
				1 => DialogResult.Cancel, 
				2 => DialogResult.OK, 
				_ => throw new TextEditorException(this.resources.GetString("ERR_INTERNAL")), 
			};
		}

		/// <summary>Opens the dialog box showing its first tab.</summary>
		public DialogResult ImageAttributesDialog()
		{
			return this.ImageAttributesDialog(0);
		}

		/// <summary>Opens the dialog box showing the specified tab.</summary>
		/// <param name="activeTab">Specifies the index of the tab, zero-based, that is displayed when the tabbed dialog box is opened.</param>
		public DialogResult ImageAttributesDialog(int activeTab)
		{
			if (!base.IsHandleCreated)
			{
				throw new InvalidOperationException(this.resources.GetString("ERR_NOTLOADED"));
			}
			return this.textControlCore_0.method_29(TextPart.Auto, 1250, 0, Class429.smethod_3(4, activeTab)) switch
			{
				1 => DialogResult.Cancel, 
				2 => DialogResult.OK, 
				_ => throw new TextEditorException(this.resources.GetString("ERR_INTERNAL")), 
			};
		}

		/// <summary>Invokes the built-in dialog box for setting the language of the selected text.</summary>
		public DialogResult LanguageDialog()
		{
			if (!base.IsHandleCreated)
			{
				throw new InvalidOperationException(this.resources.GetString("ERR_NOTLOADED"));
			}
			return this.textControlCore_0.method_29(TextPart.Auto, 1970, 65535, 0) switch
			{
				1 => DialogResult.Cancel, 
				2 => DialogResult.OK, 
				_ => DialogResult.None, 
			};
		}

		/// <summary>Invokes the built-in dialog box for setting formatting attributes of bulleted and numbered lists.</summary>
		public DialogResult ListFormatDialog()
		{
			if (!base.IsHandleCreated)
			{
				throw new InvalidOperationException(this.resources.GetString("ERR_NOTLOADED"));
			}
			return this.textControlCore_0.method_29(TextPart.Auto, 1306, 0, 0) switch
			{
				1 => DialogResult.Cancel, 
				2 => DialogResult.OK, 
				_ => throw new TextEditorException(this.resources.GetString("ERR_INTERNAL")), 
			};
		}

		/// <summary>Opens a dialog box to add, edit or delete Conditional Instructions inside the document.</summary>
		public DialogResult ManageConditionalInstructionsDialog()
		{
			
			if (!this.IsFormFieldValidationEnabled)
			{
				return DialogResult.Abort;
			}
			DialogResult result;
			if ((result = this.Class456_0.method_15()) == DialogResult.OK)
			{
				this.Class456_0.method_0();
			}
			return result;
		}

		/// <summary>Invokes the built-in dialog box for setting the page color.</summary>
		public DialogResult PageColorDialog()
		{
			if (!base.IsHandleCreated)
			{
				throw new InvalidOperationException(this.resources.GetString("ERR_NOTLOADED"));
			}
			return this.textControlCore_0.method_30(Enum83.const_316, 512, 0) switch
			{
				1 => DialogResult.Cancel, 
				2 => DialogResult.OK, 
				_ => throw new TextEditorException(this.resources.GetString("ERR_INTERNAL")), 
			};
		}

		/// <summary>Opens the dialog box showing its first tab.</summary>
		public DialogResult ParagraphFormatDialog()
		{
			return this.ParagraphFormatDialog(0);
		}

		/// <summary>Opens the dialog box showing the specified tab.</summary>
		/// <param name="activeTab">Specifies the index of the tab, zero-based, that is displayed when the tabbed dialog box is opened.</param>
		public DialogResult ParagraphFormatDialog(int activeTab)
		{
			if (!base.IsHandleCreated)
			{
				throw new InvalidOperationException(this.resources.GetString("ERR_NOTLOADED"));
			}
			return this.textControlCore_0.method_29(TextPart.Auto, 1182, Class429.smethod_3(activeTab, 0), 0) switch
			{
				1 => DialogResult.Cancel, 
				2 => DialogResult.OK, 
				_ => throw new TextEditorException(this.resources.GetString("ERR_INTERNAL")), 
			};
		}

		/// <summary>Invokes the built-in tabbed dialog box for setting section attributes. These are page settings such as margins, size and orientation and all settings concerning headers and footers.</summary>
		/// <param name="activeTab">Specifies the index of the tab, zero-based, that is displayed when the tabbed dialog box is opened.</param>
		public DialogResult SectionFormatDialog(int activeTab)
		{
			
			if (!base.IsHandleCreated)
			{
				throw new InvalidOperationException(this.resources.GetString("ERR_NOTLOADED"));
			}
			return this.textControlCore_0.method_29(TextPart.Auto, 1891, activeTab, 0) switch
			{
				1 => DialogResult.Cancel, 
				2 => DialogResult.OK, 
				_ => throw new TextEditorException(this.resources.GetString("ERR_INTERNAL")), 
			};
		}

		/// <summary>Invokes the built-in dialog box for setting tabs.</summary>
		public DialogResult TabDialog()
		{
			if (!base.IsHandleCreated)
			{
				throw new InvalidOperationException(this.resources.GetString("ERR_NOTLOADED"));
			}
			return this.textControlCore_0.method_29(TextPart.Auto, 1307, 0, 0) switch
			{
				1 => DialogResult.Cancel, 
				2 => DialogResult.OK, 
				_ => throw new TextEditorException(this.resources.GetString("ERR_INTERNAL")), 
			};
		}

		/// <summary>Opens the dialog box showing its first tab.</summary>
		public DialogResult TableFormatDialog()
		{
			return this.TableFormatDialog(0);
		}

		/// <summary>Opens the dialog box showing the specified tab.</summary>
		/// <param name="activeTab">Specifies the index of the tab, zero-based, that is displayed when the tabbed dialog box is opened.</param>
		public DialogResult TableFormatDialog(int activeTab)
		{
			if (!base.IsHandleCreated)
			{
				throw new InvalidOperationException(this.resources.GetString("ERR_NOTLOADED"));
			}
			return this.textControlCore_0.method_29(TextPart.Auto, 1262, Class429.smethod_3(activeTab, 0), 0) switch
			{
				1 => DialogResult.Cancel, 
				2 => DialogResult.OK, 
				_ => throw new TextEditorException(this.resources.GetString("ERR_INTERNAL")), 
			};
		}

		/// <summary>Invokes the built-in dialog box for inserting or changing a table of contents. If the current text input position is in an existing table of contents, the dialog box shows its attributes and the user can change it. Otherwise, a new table of contents is inserted with the specified attributes.</summary>
		public DialogResult TableOfContentsDialog()
		{
			
			if (!base.IsHandleCreated)
			{
				throw new InvalidOperationException(this.resources.GetString("ERR_NOTLOADED"));
			}
			return this.textControlCore_0.method_29(TextPart.Auto, 2016, 0, 0) switch
			{
				1 => DialogResult.Cancel, 
				2 => DialogResult.OK, 
				_ => throw new TextEditorException(this.resources.GetString("ERR_INTERNAL")), 
			};
		}

		/// <summary>Invokes the built-in dialog box for setting the background color of the text.</summary>
		public DialogResult TextBackColorDialog()
		{
			if (!base.IsHandleCreated)
			{
				throw new InvalidOperationException(this.resources.GetString("ERR_NOTLOADED"));
			}
			return this.textControlCore_0.method_29(TextPart.Auto, 1168, 64, 0) switch
			{
				1 => DialogResult.Cancel, 
				2 => DialogResult.OK, 
				_ => throw new TextEditorException(this.resources.GetString("ERR_INTERNAL")), 
			};
		}

		/// <summary>Opens the dialog box showing its first tab.</summary>
		public DialogResult TextFrameAttributesDialog()
		{
			return this.TextFrameAttributesDialog(0);
		}

		/// <summary>Opens the dialog box showing the specified tab.</summary>
		/// <param name="activeTab">Specifies the index of the tab, zero-based, that is displayed when the tabbed dialog box is opened.</param>
		public DialogResult TextFrameAttributesDialog(int activeTab)
		{
			
			if (!base.IsHandleCreated)
			{
				throw new InvalidOperationException(this.resources.GetString("ERR_NOTLOADED"));
			}
			return this.textControlCore_0.method_29(TextPart.Auto, 1250, 0, Class429.smethod_3(32, activeTab)) switch
			{
				1 => DialogResult.Cancel, 
				2 => DialogResult.OK, 
				_ => throw new TextEditorException(this.resources.GetString("ERR_INTERNAL")), 
			};
		}

		/// <summary>Invokes the built-in dialog box for correcting misspelled words.</summary>
		public void SpellCheckDialog()
		{
			if (this.component_0 == null)
			{
				throw new ArgumentException(this.resources.GetString("ERR_NOTXSPELLCHECKER"));
			}
			new Class591(this.component_0).method_42(this);
		}

		/// <summary>Invokes the built-in dialog box for correcting misspelled words using the specified dictionary for making suggestions.</summary>
		/// <param name="suggestionDictionary">Specifies the dictionary used for making suggestions.</param>
		public void SpellCheckDialog(object suggestionDictionary)
		{
			if (this.component_0 == null)
			{
				throw new ArgumentException(this.resources.GetString("ERR_NOTXSPELLCHECKER"));
			}
			new Class591(this.component_0).method_43(this, suggestionDictionary);
		}

		protected override bool IsInputKey(Keys keyData)
		{
			if (keyData != Keys.Tab && keyData != (Keys.Tab | Keys.Shift))
			{
				return base.IsInputKey(keyData);
			}
			return this.bool_1;
		}

		public bool ShouldSerializeAutoControlSize()
		{
			return !this.autoSize_0.method_3();
		}

		/// <summary>Resets the AutoControlSize property to its default values. The default of the AutoControlSize property is a TextControl object that does not automatically expand or shrink its width or height.</summary>
		public void ResetAutoControlSize()
		{
			this.autoSize_0.method_1();
		}

		public bool ShouldSerializeBackColor()
		{
			return this.color_0 != SystemColors.Window;
		}

		/// <summary>Overridden. Resets the BackColor property to its default value. The default value is the system color for the window background.</summary>
		public override void ResetBackColor()
		{
			this.BackColor = SystemColors.Window;
		}

		private void buttonBar_0_Disposed(object sender, EventArgs e)
		{
			if (object.ReferenceEquals(sender, this.buttonBar_0))
			{
				this.buttonBar_0 = null;
				if (this.rulerBar_0 != null)
				{
					this.rulerBar_0.ButtonBar_0 = null;
				}
			}
		}

		public bool ShouldSerializeCursor()
		{
			return this.Cursor != Cursors.IBeam;
		}

		/// <summary>Overridden. Resets the Cursor property to its default value. The default value is the IBeam cursor.</summary>
		public override void ResetCursor()
		{
			this.Cursor = Cursors.IBeam;
		}

		public bool ShouldSerializeDisplayColors()
		{
			return !this.colors_0.method_4();
		}

		/// <summary>Resets all display colors of a text control to their system dependent default values.</summary>
		public void ResetDisplayColors()
		{
			this.colors_0.method_3();
		}

		public bool ShouldSerializeDocumentPermissions()
		{
			return !this.documentPermissions_1.method_2();
		}

		public void ResetDocumentPermissions()
		{
			this.documentPermissions_1.method_1();
		}

		public bool ShouldSerializeFieldCursor()
		{
			return this.FieldCursor != this.cursor_5;
		}

		/// <summary>Resets the FieldCursor property to its default value. The default value is the Hand cursor.</summary>
		public void ResetFieldCursor()
		{
			this.FieldCursor = this.cursor_5;
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

		/// <summary>Overridden. Resets the ForeColor property to its default value. The default value is the system color for the window text.</summary>
		public override void ResetForeColor()
		{
			this.ForeColor = SystemColors.WindowText;
		}

		public bool ShouldSerializeInputPosition()
		{
			return false;
		}

		private void method_39()
		{
			if (this.eventHandler_27 != null)
			{
				this.eventHandler_27(this, new EventArgs());
			}
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

		private void rulerBar_0_Disposed(object sender, EventArgs e)
		{
			if (object.ReferenceEquals(sender, this.rulerBar_0))
			{
				this.rulerBar_0 = null;
			}
		}

		public bool ShouldSerializeScrollLocation()
		{
			return false;
		}

		public bool ShouldSerializeSelection()
		{
			return false;
		}

		private void method_40()
		{
			if (this.miniToolbarButton_0 != MiniToolbarButton.None)
			{
				if (this.MiniToolbar_0 == null)
				{
					this.MiniToolbar_0 = new TextMiniToolbar(this);
					this.OnTextMiniToolbarInitialized(new MiniToolbarInitializedEventArgs(this, isTextMiniToolbar: true));
				}
				if ((this.miniToolbarButton_0 & MiniToolbarButton.RightButton) == MiniToolbarButton.RightButton && this.MiniToolbar_1 == null)
				{
					this.MiniToolbar_1 = new ObjectMiniToolbar(this);
					this.OnObjectMiniToolbarInitialized(new MiniToolbarInitializedEventArgs(this, isTextMiniToolbar: false));
				}
			}
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
