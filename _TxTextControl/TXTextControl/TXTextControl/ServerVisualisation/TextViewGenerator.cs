using System;
using System.ComponentModel;
using System.Drawing;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading;
using ns20;
using ns21;
using ns24;
using TXTextControl.DataVisualization;

namespace TXTextControl.ServerVisualisation
{
	[ToolboxItem(false)]
	public class TextViewGenerator : ServerTextControl, INotifyPropertyChanged
	{
		[Serializable]
		public enum DialogBoxKind
		{
			FontDialog = 1,
			FormattingStylesDialog,
			ImageAttributesDialog,
			InsertTableDialog,
			LanguageDialog,
			ListFormatDialog,
			ParagraphFormatDialog,
			SectionFormatDialog,
			TabDialog,
			TableFormatDialog,
			TextFrameAttributesDialog,
			ChartLayoutDialog,
			BarcodeLayoutDialog,
			FindDialog,
			ReplaceDialog,
			ForeColor,
			TextBackColor,
			DrawingLayoutDialog,
			AddSymbolDialog,
			FrameFillColorDialog,
			FrameLineColorDialog,
			PageColorDialog,
			TableOfContentsDialog
		}

		public sealed class Colors : ColorBase
		{
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

			public Colors()
				: base(7, 1934, 1935)
			{
			}

			public bool ShouldSerializeDesktopColor()
			{
				return base.m_aiColors[0] != Color.Empty;
			}

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

			public void ResetFormFieldColor()
			{
				ref Color reference = ref base.m_aiColors[6];
				reference = Color.Empty;
				base.method_0();
			}
		}

		private DialogViewGenerator dialogViewGenerator_0 = new DialogViewGenerator();

		private CaretStateEventArgs caretStateEventArgs_0;

		private EventHandler eventHandler_2;

		private DocumentPermissions documentPermissions_0;

		private DrawingFrame drawingFrame_0;

		private bool bool_7;

		private EventHandler eventHandler_3;

		private DocumentSizeChangedEventHandler documentSizeChangedEventHandler_0;

		private EventHandler eventHandler_4;

		private EventHandler eventHandler_5;

		private EventHandler eventHandler_6;

		private EventHandler eventHandler_7;

		private EventHandler eventHandler_8;

		private EventHandler eventHandler_9;

		private EventHandler eventHandler_10;

		private CaretStateEventHandler caretStateEventHandler_0;

		private TextContextMenuEventHandler textContextMenuEventHandler_0;

		private DrawShapeEventHandler drawShapeEventHandler_0;

		private DrawComboboxEventHandler drawComboboxEventHandler_0;

		private EventHandler eventHandler_11;

		private DrawDateControlEventHandler drawDateControlEventHandler_0;

		private EventHandler eventHandler_12;

		private EventHandler eventHandler_13;

		private EventHandler eventHandler_14;

		private ShowDialogBoxEventHandler showDialogBoxEventHandler_0;

		private ShowErrorMessageEventHandler showErrorMessageEventHandler_0;

		private ImageEventHandler imageEventHandler_2;

		private ImageEventHandler imageEventHandler_3;

		private TextFrameEventHandler textFrameEventHandler_2;

		private TextFrameEventHandler textFrameEventHandler_3;

		private ChartEventHandler chartEventHandler_2;

		private ChartEventHandler chartEventHandler_3;

		private BarcodeEventHandler barcodeEventHandler_2;

		private BarcodeEventHandler barcodeEventHandler_3;

		private DrawingEventHandler drawingEventHandler_2;

		private DrawingEventHandler drawingEventHandler_3;

		private FrameEventHandler frameEventHandler_0;

		private FrameEventHandler frameEventHandler_1;

		private DrawingEventHandler drawingEventHandler_4;

		private DrawingEventHandler drawingEventHandler_5;

		private TextFrameEventHandler textFrameEventHandler_4;

		private TextFrameEventHandler textFrameEventHandler_5;

		private FrameEventHandler frameEventHandler_2;

		private FrameEventHandler frameEventHandler_3;

		private TextFieldEventHandler textFieldEventHandler_2;

		private TextFieldEventHandler textFieldEventHandler_3;

		private TextFieldEventHandler textFieldEventHandler_4;

		private CheckFormFieldEventHandler checkFormFieldEventHandler_0;

		private DateFormFieldEventHandler dateFormFieldEventHandler_0;

		private SelectionFormFieldEventHandler selectionFormFieldEventHandler_0;

		private TextFormFieldEventHandler textFormFieldEventHandler_0;

		private HypertextLinkEventHandler hypertextLinkEventHandler_0;

		private DocumentLinkEventHandler documentLinkEventHandler_0;

		private SubTextPartEventHandler subTextPartEventHandler_2;

		private SubTextPartEventHandler subTextPartEventHandler_3;

		private SubTextPartEventHandler subTextPartEventHandler_4;

		private SubTextPartEventHandler subTextPartEventHandler_5;

		private EditableRegionEventHandler editableRegionEventHandler_2;

		private EditableRegionEventHandler editableRegionEventHandler_3;

		private CannotTrackChangeEventHandler cannotTrackChangeEventHandler_0;

		private TrackedChangeEventHandler trackedChangeEventHandler_2;

		private TrackedChangeEventHandler trackedChangeEventHandler_3;

		private TableOfContentsEventHandler tableOfContentsEventHandler_2;

		private TableOfContentsEventHandler tableOfContentsEventHandler_3;

		private HeaderFooterEventHandler headerFooterEventHandler_0;

		private HeaderFooterEventHandler headerFooterEventHandler_1;

		private PropertyChangedEventHandler propertyChangedEventHandler_0;

		private ActivationState activationState_0 = ActivationState.Deactivated;

		private bool bool_8;

		private bool bool_9;

		private bool bool_10 = true;

		private bool bool_11;

		private int int_1;

		private DialogUnit dialogUnit_0;

		private Colors colors_0 = new Colors();

		private DocumentPermissions documentPermissions_1 = new DocumentPermissions();

		private bool bool_12;

		private bool bool_13 = true;

		private EditMode editMode_0 = EditMode.Edit;

		private InputFormat inputFormat_0 = new InputFormat();

		private bool bool_14;

		private bool bool_15;

		private Point point_0 = new Point(0, 0);

		private PermanentControlChar permanentControlChar_0 = PermanentControlChar.ObjectAnchor;

		private RulerBarViewGenerator rulerBarViewGenerator_0;

		private bool bool_16;

		private StatusBarViewGenerator statusBarViewGenerator_0;

		private bool bool_17 = true;

		private UserInput userInput_0 = new UserInput(bIsDialog: false);

		private string[] string_2;

		private RulerBarViewGenerator rulerBarViewGenerator_1;

		private View view_0 = new View(typeof(TextViewGenerator));

		[Browsable(false)]
		public DialogViewGenerator DialogViewGenerator_0
		{
			get
			{
				if (base.textControlCore_0.IntPtr_0 != IntPtr.Zero)
				{
					if (!this.dialogViewGenerator_0.method_0(base.textControlCore_0, TextPart.Auto, Enum83.const_94, 0, 0))
					{
						return null;
					}
					return this.dialogViewGenerator_0;
				}
				return null;
			}
		}

		[Attribute3("PROP_ACTIVATIONSTATE")]
		[Category("Appearance")]
		[DefaultValue(ActivationState.Deactivated)]
		public ActivationState ActivationState
		{
			get
			{
				return this.activationState_0;
			}
			set
			{
				if (this.activationState_0 == value)
				{
					return;
				}
				this.activationState_0 = value;
				base.textControlCore_0.method_29(TextPart.Auto, 2071, (int)this.activationState_0, 0);
				if (this.activationState_0 == ActivationState.Activated)
				{
					if (this.rulerBarViewGenerator_0 != null)
					{
						this.method_7(this.rulerBarViewGenerator_0.intptr_0);
					}
					if (this.rulerBarViewGenerator_1 != null)
					{
						this.method_7(this.rulerBarViewGenerator_1.intptr_0);
					}
					if (this.statusBarViewGenerator_0 != null)
					{
						this.method_7(this.statusBarViewGenerator_0.intptr_0);
					}
				}
				if (this.caretStateEventArgs_0 != null && this.caretStateEventArgs_0.method_0())
				{
					this.OnCaretStateChanged(this.caretStateEventArgs_0);
				}
			}
		}

		[DefaultValue(false)]
		[Attribute3("PROP_ALLOWDRAG")]
		[Category("Behavior")]
		public bool AllowDrag
		{
			get
			{
				return this.bool_8;
			}
			set
			{
				if (this.bool_8 != value)
				{
					this.bool_8 = value;
					if (base.textControlCore_0.isHandleCreated)
					{
						base.textControlCore_0.method_30(Enum83.const_30, this.bool_8 ? 8388608 : 16777216, 0);
					}
				}
			}
		}

		[DefaultValue(false)]
		[Attribute3("PROP_ALLOWDROP")]
		[Category("Behavior")]
		public bool AllowDrop
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
					if (base.textControlCore_0.isHandleCreated)
					{
						base.textControlCore_0.method_30(Enum83.const_30, this.bool_9 ? 4194304 : 33554432, 0);
					}
				}
			}
		}

		[Category("Behavior")]
		[Attribute3("PROP_ALLOWUNDO")]
		[DefaultValue(true)]
		public bool AllowUndo
		{
			get
			{
				return this.bool_10;
			}
			set
			{
				if (this.bool_10 != value)
				{
					this.bool_10 = value;
					if (base.textControlCore_0.isHandleCreated)
					{
						base.textControlCore_0.method_30(Enum83.const_205, this.bool_10 ? 1 : 0, 0);
					}
				}
			}
		}

		[Browsable(false)]
		public bool CanCopy
		{
			get
			{
				if (!base.textControlCore_0.isHandleCreated)
				{
					return false;
				}
				return base.textControlCore_0.method_29(TextPart.Auto, 2046, 0, 0) != 0;
			}
		}

		[Browsable(false)]
		public bool CanPaste
		{
			get
			{
				if (!base.textControlCore_0.isHandleCreated)
				{
					return false;
				}
				return base.textControlCore_0.method_29(TextPart.Auto, 2047, 0, 0) != 0;
			}
		}

		[Browsable(false)]
		public bool CanUndo
		{
			get
			{
				if (!base.textControlCore_0.isHandleCreated)
				{
					return false;
				}
				return (base.textControlCore_0.method_29(TextPart.Auto, 2031, 0, 0) & 0xFFFF) != 0;
			}
		}

		[Browsable(false)]
		public bool CanRedo
		{
			get
			{
				if (!base.textControlCore_0.isHandleCreated)
				{
					return false;
				}
				return (base.textControlCore_0.method_29(TextPart.Auto, 2031, 0, 0) & 0xFFFF0000L) != 0L;
			}
		}

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

		[Attribute3("PROP_CONTROLCHARS")]
		[DefaultValue(false)]
		[Category("Appearance")]
		public bool ControlChars
		{
			get
			{
				if (base.textControlCore_0.isHandleCreated)
				{
					Enum90 @enum = (Enum90)base.textControlCore_0.method_30(Enum83.const_6, 0, 0);
					this.bool_11 = (@enum & Enum90.const_4) != 0;
				}
				return this.bool_11;
			}
			set
			{
				if (this.bool_11 != value)
				{
					this.bool_11 = value;
					if (base.textControlCore_0.isHandleCreated)
					{
						base.textControlCore_0.method_30(Enum83.const_30, this.bool_11 ? 16 : 2048, 0);
					}
				}
			}
		}

		[DefaultValue(0)]
		[Category("Appearance")]
		[Attribute3("PROP_RESOLUTION")]
		public int Resolution
		{
			get
			{
				if (base.textControlCore_0.isHandleCreated)
				{
					this.int_1 = base.textControlCore_0.method_29(TextPart.Auto, 2138, 0, 0);
				}
				return this.int_1;
			}
			set
			{
				if (this.int_1 != value)
				{
					this.int_1 = value;
					if (base.textControlCore_0.isHandleCreated)
					{
						base.textControlCore_0.method_29(TextPart.Auto, 2139, value, 0);
					}
				}
			}
		}

		[Attribute3("PROP_DIALOGUNIT")]
		[Category("Appearance")]
		[DefaultValue(DialogUnit.Auto)]
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
					if (base.textControlCore_0.isHandleCreated)
					{
						base.textControlCore_0.method_4(this.dialogUnit_0);
					}
				}
			}
		}

		[Category("Appearance")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		[Attribute3("PROP_DISPLAYCOLORS")]
		[RefreshProperties(RefreshProperties.Repaint)]
		[TypeConverter(typeof(Class417))]
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

		[Category("Behavior")]
		[TypeConverter(typeof(Class417))]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		[Attribute3("PROP_DOCUMENTPERMISSIONS")]
		public DocumentPermissions DocumentPermissions => this.documentPermissions_1;

		[DefaultValue(false)]
		[Attribute3("PROP_TARGETMARKERS")]
		[Category("Appearance")]
		public bool DocumentTargetMarkers
		{
			get
			{
				if (base.textControlCore_0.IntPtr_0 != IntPtr.Zero)
				{
					Enum90 @enum = (Enum90)base.textControlCore_0.method_30(Enum83.const_6, 0, 0);
					this.bool_12 = (@enum & Enum90.const_12) != 0;
				}
				return this.bool_12;
			}
			set
			{
				if (this.bool_12 != value)
				{
					this.bool_12 = value;
					if (base.textControlCore_0.IntPtr_0 != IntPtr.Zero)
					{
						base.textControlCore_0.method_30(Enum83.const_30, this.bool_12 ? 1048576 : 134217728, 0);
					}
				}
			}
		}

		[DefaultValue(true)]
		[Attribute3("PROP_DRAWINGMARKERLINES")]
		[Category("Appearance")]
		public bool DrawingMarkerLines
		{
			get
			{
				if (base.textControlCore_0.IntPtr_0 != IntPtr.Zero)
				{
					int[] array = new int[1];
					int[] array2 = array;
					base.textControlCore_0.method_41(Enum83.const_25, 0, array2);
					this.bool_13 = (array2[0] & 0x8000) != 0;
				}
				return this.bool_13;
			}
			set
			{
				if (this.bool_13 != value)
				{
					this.bool_13 = value;
					if (base.textControlCore_0.IntPtr_0 != IntPtr.Zero)
					{
						base.textControlCore_0.method_30(Enum83.const_40, 0, (!this.bool_13) ? 1 : 32768);
					}
				}
			}
		}

		[Category("Behavior")]
		[Attribute3("PROP_EDITMODE")]
		[DefaultValue(EditMode.Edit)]
		public EditMode EditMode
		{
			get
			{
				if (base.textControlCore_0.IntPtr_0 != IntPtr.Zero)
				{
					Enum91 @enum = (Enum91)base.textControlCore_0.method_30(Enum83.const_25, 0, 0);
					this.editMode_0 = (((@enum & Enum91.const_15) != 0) ? EditMode.Edit : (((@enum & Enum91.const_3) != 0) ? EditMode.ReadAndSelect : EditMode.ReadOnly));
				}
				return this.editMode_0;
			}
			set
			{
				if (base.textControlCore_0.IntPtr_0 == IntPtr.Zero)
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
				base.textControlCore_0.method_30(Enum83.const_323, Class429.smethod_3((int)@enum, 1), 0);
			}
		}

		[Browsable(false)]
		public InputFormat InputFormat => this.inputFormat_0;

		public override bool Boolean_0
		{
			get
			{
				if (this.EditMode == EditMode.ReadAndSelect)
				{
					return this.DocumentPermissions.ReadOnly;
				}
				return false;
			}
		}

		[Attribute3("PROP_ISAPPLYCONDITIONALINSTRUCTIONSENABLED")]
		[Category("Behavior")]
		[DefaultValue(false)]
		public bool IsFormFieldValidationEnabled
		{
			get
			{
				return this.bool_14;
			}
			set
			{
				if (this.bool_14 != (this.bool_14 = value))
				{
					if (this.bool_14 && base.Class431_0 == null)
					{
						base.Class431_0 = new Class431(this);
					}
					if (base.Class431_0 != null && base.IsCreated)
					{
						base.Class431_0.method_10(this.bool_14);
					}
				}
			}
		}

		[Category("Behavior")]
		[Attribute3("PROP_ISTRACKCHANGESENABLED")]
		[DefaultValue(false)]
		public bool IsTrackChangesEnabled
		{
			get
			{
				if (base.textControlCore_0.isHandleCreated)
				{
					int[] array = new int[1];
					int[] array2 = array;
					base.textControlCore_0.method_41(Enum83.const_25, 0, array2);
					this.bool_15 = (array2[0] & 0x40) != 0;
				}
				return this.bool_15;
			}
			set
			{
				if (this.bool_15 != value)
				{
					this.bool_15 = value;
					if (base.textControlCore_0.isHandleCreated)
					{
						base.textControlCore_0.method_30(Enum83.const_40, 0, this.bool_15 ? 64 : 1024);
					}
				}
			}
		}

		[Browsable(false)]
		public Point Location
		{
			get
			{
				return this.point_0;
			}
			set
			{
				this.point_0 = value;
				if (base.textControlCore_0.IntPtr_0 != IntPtr.Zero)
				{
					Class429.SetWindowPos(base.textControlCore_0.IntPtr_0, IntPtr.Zero, this.point_0.X, this.point_0.Y, 0, 0, 29u);
				}
			}
		}

		[DefaultValue(PermanentControlChar.ObjectAnchor)]
		[Attribute3("PROP_PERMANENTCONTROLCHARS")]
		[Category("Appearance")]
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
					if (base.textControlCore_0.IntPtr_0 != IntPtr.Zero)
					{
						base.textControlCore_0.method_30(Enum83.const_296, (int)this.permanentControlChar_0, 0);
					}
				}
			}
		}

		[Browsable(false)]
		public string RedoActionName
		{
			get
			{
				string result = null;
				if (base.textControlCore_0.isHandleCreated)
				{
					TxUndoAction txUndoAction = (TxUndoAction)Class429.smethod_6(base.textControlCore_0.method_29(TextPart.Auto, 2031, 0, 0));
					switch (txUndoAction)
					{
					case TxUndoAction.UNDO_USERNAME:
					{
						IntPtr intPtr = base.textControlCore_0.method_64(TextPart.Auto, Enum83.const_313, 2u, 0);
						if (intPtr != IntPtr.Zero)
						{
							result = Marshal.PtrToStringBSTR(intPtr);
							Marshal.FreeBSTR(intPtr);
						}
						break;
					}
					default:
						result = base.resourceManager_0.GetString(txUndoAction.ToString());
						break;
					case (TxUndoAction)0:
						break;
					}
				}
				return result;
			}
		}

		[Attribute3("PROP_RULERBAR")]
		[Category("Behavior")]
		[DefaultValue(null)]
		public RulerBarViewGenerator RulerBar
		{
			get
			{
				return this.rulerBarViewGenerator_0;
			}
			set
			{
				if (this.rulerBarViewGenerator_0 != null)
				{
					this.method_8(this.rulerBarViewGenerator_0.intptr_0);
				}
				this.rulerBarViewGenerator_0 = value;
				if (this.rulerBarViewGenerator_0 != null)
				{
					this.method_7(this.rulerBarViewGenerator_0.intptr_0);
				}
			}
		}

		[DefaultValue(false)]
		[Category("Appearance")]
		[Attribute3("PROP_SELECTOBJECTS")]
		public bool SelectObjects
		{
			get
			{
				if (base.textControlCore_0.IntPtr_0 != IntPtr.Zero)
				{
					int[] array = new int[1];
					int[] array2 = array;
					base.textControlCore_0.method_41(Enum83.const_25, 0, array2);
					this.bool_16 = (array2[0] & 4) != 0;
				}
				return this.bool_16;
			}
			set
			{
				if (this.bool_16 != value)
				{
					this.bool_16 = value;
					if (base.textControlCore_0.IntPtr_0 != IntPtr.Zero)
					{
						base.textControlCore_0.method_30(Enum83.const_40, 0, this.bool_16 ? 4 : 8192);
					}
				}
			}
		}

		[DefaultValue(null)]
		[Attribute3("PROP_STATUSBAR")]
		[Category("Behavior")]
		public StatusBarViewGenerator StatusBar
		{
			get
			{
				return this.statusBarViewGenerator_0;
			}
			set
			{
				if (this.statusBarViewGenerator_0 != null)
				{
					this.method_8(this.statusBarViewGenerator_0.intptr_0);
				}
				this.statusBarViewGenerator_0 = value;
				if (this.statusBarViewGenerator_0 != null)
				{
					this.method_7(this.statusBarViewGenerator_0.intptr_0);
				}
			}
		}

		[Attribute3("PROP_MARKERLINES")]
		[DefaultValue(true)]
		[Category("Appearance")]
		public bool TextFrameMarkerLines
		{
			get
			{
				if (base.textControlCore_0.IntPtr_0 != IntPtr.Zero)
				{
					Enum90 @enum = (Enum90)base.textControlCore_0.method_30(Enum83.const_6, 0, 0);
					this.bool_17 = (@enum & Enum90.const_26) != 0;
				}
				return this.bool_17;
			}
			set
			{
				if (this.bool_17 != value)
				{
					this.bool_17 = value;
					if (base.textControlCore_0.IntPtr_0 != IntPtr.Zero)
					{
						base.textControlCore_0.method_30(Enum83.const_30, this.bool_17 ? 536870912 : 262144, 0);
					}
				}
			}
		}

		[Browsable(false)]
		public string UndoActionName
		{
			get
			{
				string result = null;
				if (base.textControlCore_0.isHandleCreated)
				{
					TxUndoAction txUndoAction = (TxUndoAction)Class429.smethod_5(base.textControlCore_0.method_29(TextPart.Auto, 2031, 0, 0));
					switch (txUndoAction)
					{
					case TxUndoAction.UNDO_USERNAME:
					{
						IntPtr intPtr = base.textControlCore_0.method_64(TextPart.Auto, Enum83.const_313, 1u, 0);
						if (intPtr != IntPtr.Zero)
						{
							result = Marshal.PtrToStringBSTR(intPtr);
							Marshal.FreeBSTR(intPtr);
						}
						break;
					}
					default:
						result = base.resourceManager_0.GetString(txUndoAction.ToString());
						break;
					case (TxUndoAction)0:
						break;
					}
				}
				return result;
			}
		}

		[Browsable(false)]
		public UserInput UserInput => this.userInput_0;

		[Category("Behavior")]
		[Attribute3("PROP_USERNAMES")]
		public string[] UserNames
		{
			get
			{
				return this.string_2;
			}
			set
			{
				this.string_2 = value;
				if (base.textControlCore_0.isHandleCreated)
				{
					base.textControlCore_0.method_3(this.string_2);
					if (this.editMode_0 == EditMode.ReadAndSelect)
					{
						this.method_12();
					}
				}
			}
		}

		[DefaultValue(null)]
		[Attribute3("PROP_VERTRULERBAR")]
		[Category("Behavior")]
		public RulerBarViewGenerator VerticalRulerBar
		{
			get
			{
				return this.rulerBarViewGenerator_1;
			}
			set
			{
				if (this.rulerBarViewGenerator_1 != null && value == null)
				{
					this.method_8(this.rulerBarViewGenerator_1.intptr_0);
				}
				this.rulerBarViewGenerator_1 = value;
				if (this.rulerBarViewGenerator_1 != null)
				{
					this.rulerBarViewGenerator_1.Alignment = RulerBarAlignment.Left;
					this.method_7(this.rulerBarViewGenerator_1.intptr_0);
				}
			}
		}

		[Browsable(false)]
		public View View => this.view_0;

		[Browsable(false)]
		public ViewMode ViewMode
		{
			get
			{
				return base.ViewMode_0;
			}
			set
			{
				base.ViewMode_0 = value;
			}
		}

		[Attribute3("EVENT_CHARFORMATCHANGED")]
		[Category("Format")]
		public event EventHandler CharFormatChanged
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

		[Attribute3("EVENT_DOCUMENTSIZECHANGED")]
		[Category("Behavior")]
		public event DocumentSizeChangedEventHandler DocumentSizeChanged
		{
			add
			{
				DocumentSizeChangedEventHandler documentSizeChangedEventHandler = this.documentSizeChangedEventHandler_0;
				DocumentSizeChangedEventHandler documentSizeChangedEventHandler2;
				do
				{
					documentSizeChangedEventHandler2 = documentSizeChangedEventHandler;
					DocumentSizeChangedEventHandler value2 = (DocumentSizeChangedEventHandler)Delegate.Combine(documentSizeChangedEventHandler2, value);
					documentSizeChangedEventHandler = Interlocked.CompareExchange(ref this.documentSizeChangedEventHandler_0, value2, documentSizeChangedEventHandler2);
				}
				while ((object)documentSizeChangedEventHandler != documentSizeChangedEventHandler2);
			}
			remove
			{
				DocumentSizeChangedEventHandler documentSizeChangedEventHandler = this.documentSizeChangedEventHandler_0;
				DocumentSizeChangedEventHandler documentSizeChangedEventHandler2;
				do
				{
					documentSizeChangedEventHandler2 = documentSizeChangedEventHandler;
					DocumentSizeChangedEventHandler value2 = (DocumentSizeChangedEventHandler)Delegate.Remove(documentSizeChangedEventHandler2, value);
					documentSizeChangedEventHandler = Interlocked.CompareExchange(ref this.documentSizeChangedEventHandler_0, value2, documentSizeChangedEventHandler2);
				}
				while ((object)documentSizeChangedEventHandler != documentSizeChangedEventHandler2);
			}
		}

		[Category("Behavior")]
		[Attribute3("EVENT_FORMATTINGSTYLELISTCHANGED")]
		public event EventHandler FormattingStyleListChanged
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

		[Attribute3("EVENT_INPUTFORMATTINGSTYLECHANGED")]
		[Category("Behavior")]
		public event EventHandler InputFormattingStyleChanged
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

		[Attribute3("EVENT_FORMATTINGSTYLECHANGED")]
		[Category("Behavior")]
		public event EventHandler FormattingStyleChanged
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

		[Attribute3("EVENT_INPUTPOSITIONCHANGED")]
		[Category("Behavior")]
		public event EventHandler InputPositionChanged
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

		[Attribute3("EVENT_INPUTPARAGRAPHCHANGED")]
		[Category("Behavior")]
		public event EventHandler InputParagraphChanged
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

		[Attribute3("EVENT_PARAGRAPHFORMATCHANGED")]
		[Category("Format")]
		public event EventHandler ParagraphFormatChanged
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

		[Attribute3("EVENT_PAGEFORMATCHANGED")]
		[Category("Format")]
		public event EventHandler PageFormatChanged
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

		[Category("Behavior")]
		[Attribute3("EVENT_CARETSTATECHANGED")]
		public event CaretStateEventHandler CaretStateChanged
		{
			add
			{
				CaretStateEventHandler caretStateEventHandler = this.caretStateEventHandler_0;
				CaretStateEventHandler caretStateEventHandler2;
				do
				{
					caretStateEventHandler2 = caretStateEventHandler;
					CaretStateEventHandler value2 = (CaretStateEventHandler)Delegate.Combine(caretStateEventHandler2, value);
					caretStateEventHandler = Interlocked.CompareExchange(ref this.caretStateEventHandler_0, value2, caretStateEventHandler2);
				}
				while ((object)caretStateEventHandler != caretStateEventHandler2);
			}
			remove
			{
				CaretStateEventHandler caretStateEventHandler = this.caretStateEventHandler_0;
				CaretStateEventHandler caretStateEventHandler2;
				do
				{
					caretStateEventHandler2 = caretStateEventHandler;
					CaretStateEventHandler value2 = (CaretStateEventHandler)Delegate.Remove(caretStateEventHandler2, value);
					caretStateEventHandler = Interlocked.CompareExchange(ref this.caretStateEventHandler_0, value2, caretStateEventHandler2);
				}
				while ((object)caretStateEventHandler != caretStateEventHandler2);
			}
		}

		[Category("Behavior")]
		[Attribute3("EVENT_TEXTCONTEXTMENUOPENING")]
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

		[Category("Behavior")]
		[Attribute3("EVENT_DRAWSHAPE")]
		public event DrawShapeEventHandler DrawShape
		{
			add
			{
				DrawShapeEventHandler drawShapeEventHandler = this.drawShapeEventHandler_0;
				DrawShapeEventHandler drawShapeEventHandler2;
				do
				{
					drawShapeEventHandler2 = drawShapeEventHandler;
					DrawShapeEventHandler value2 = (DrawShapeEventHandler)Delegate.Combine(drawShapeEventHandler2, value);
					drawShapeEventHandler = Interlocked.CompareExchange(ref this.drawShapeEventHandler_0, value2, drawShapeEventHandler2);
				}
				while ((object)drawShapeEventHandler != drawShapeEventHandler2);
			}
			remove
			{
				DrawShapeEventHandler drawShapeEventHandler = this.drawShapeEventHandler_0;
				DrawShapeEventHandler drawShapeEventHandler2;
				do
				{
					drawShapeEventHandler2 = drawShapeEventHandler;
					DrawShapeEventHandler value2 = (DrawShapeEventHandler)Delegate.Remove(drawShapeEventHandler2, value);
					drawShapeEventHandler = Interlocked.CompareExchange(ref this.drawShapeEventHandler_0, value2, drawShapeEventHandler2);
				}
				while ((object)drawShapeEventHandler != drawShapeEventHandler2);
			}
		}

		[Category("Behavior")]
		[Attribute3("EVENT_DRAWCOMBOBOX")]
		public event DrawComboboxEventHandler DrawCombobox
		{
			add
			{
				DrawComboboxEventHandler drawComboboxEventHandler = this.drawComboboxEventHandler_0;
				DrawComboboxEventHandler drawComboboxEventHandler2;
				do
				{
					drawComboboxEventHandler2 = drawComboboxEventHandler;
					DrawComboboxEventHandler value2 = (DrawComboboxEventHandler)Delegate.Combine(drawComboboxEventHandler2, value);
					drawComboboxEventHandler = Interlocked.CompareExchange(ref this.drawComboboxEventHandler_0, value2, drawComboboxEventHandler2);
				}
				while ((object)drawComboboxEventHandler != drawComboboxEventHandler2);
			}
			remove
			{
				DrawComboboxEventHandler drawComboboxEventHandler = this.drawComboboxEventHandler_0;
				DrawComboboxEventHandler drawComboboxEventHandler2;
				do
				{
					drawComboboxEventHandler2 = drawComboboxEventHandler;
					DrawComboboxEventHandler value2 = (DrawComboboxEventHandler)Delegate.Remove(drawComboboxEventHandler2, value);
					drawComboboxEventHandler = Interlocked.CompareExchange(ref this.drawComboboxEventHandler_0, value2, drawComboboxEventHandler2);
				}
				while ((object)drawComboboxEventHandler != drawComboboxEventHandler2);
			}
		}

		[Category("Behavior")]
		[Attribute3("EVENT_REMOVECOMBOBOX")]
		public event EventHandler RemoveCombobox
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

		[Category("Behavior")]
		[Attribute3("EVENT_DRAWDATECONTROL")]
		public event DrawDateControlEventHandler DrawDateControl
		{
			add
			{
				DrawDateControlEventHandler drawDateControlEventHandler = this.drawDateControlEventHandler_0;
				DrawDateControlEventHandler drawDateControlEventHandler2;
				do
				{
					drawDateControlEventHandler2 = drawDateControlEventHandler;
					DrawDateControlEventHandler value2 = (DrawDateControlEventHandler)Delegate.Combine(drawDateControlEventHandler2, value);
					drawDateControlEventHandler = Interlocked.CompareExchange(ref this.drawDateControlEventHandler_0, value2, drawDateControlEventHandler2);
				}
				while ((object)drawDateControlEventHandler != drawDateControlEventHandler2);
			}
			remove
			{
				DrawDateControlEventHandler drawDateControlEventHandler = this.drawDateControlEventHandler_0;
				DrawDateControlEventHandler drawDateControlEventHandler2;
				do
				{
					drawDateControlEventHandler2 = drawDateControlEventHandler;
					DrawDateControlEventHandler value2 = (DrawDateControlEventHandler)Delegate.Remove(drawDateControlEventHandler2, value);
					drawDateControlEventHandler = Interlocked.CompareExchange(ref this.drawDateControlEventHandler_0, value2, drawDateControlEventHandler2);
				}
				while ((object)drawDateControlEventHandler != drawDateControlEventHandler2);
			}
		}

		[Category("Behavior")]
		[Attribute3("EVENT_REMOVEDATECONTROL")]
		public event EventHandler RemoveDateControl
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

		[Attribute3("EVENT_CHANGED")]
		[Category("Behavior")]
		public event EventHandler Changed
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

		[Category("Behavior")]
		[Attribute3("EVENT_MAINTEXTACTIVATED")]
		public event EventHandler MainTextActivated
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

		[Category("Behavior")]
		[Attribute3("EVENT_SHOWDIALOG")]
		public event ShowDialogBoxEventHandler ShowDialogBox
		{
			add
			{
				ShowDialogBoxEventHandler showDialogBoxEventHandler = this.showDialogBoxEventHandler_0;
				ShowDialogBoxEventHandler showDialogBoxEventHandler2;
				do
				{
					showDialogBoxEventHandler2 = showDialogBoxEventHandler;
					ShowDialogBoxEventHandler value2 = (ShowDialogBoxEventHandler)Delegate.Combine(showDialogBoxEventHandler2, value);
					showDialogBoxEventHandler = Interlocked.CompareExchange(ref this.showDialogBoxEventHandler_0, value2, showDialogBoxEventHandler2);
				}
				while ((object)showDialogBoxEventHandler != showDialogBoxEventHandler2);
			}
			remove
			{
				ShowDialogBoxEventHandler showDialogBoxEventHandler = this.showDialogBoxEventHandler_0;
				ShowDialogBoxEventHandler showDialogBoxEventHandler2;
				do
				{
					showDialogBoxEventHandler2 = showDialogBoxEventHandler;
					ShowDialogBoxEventHandler value2 = (ShowDialogBoxEventHandler)Delegate.Remove(showDialogBoxEventHandler2, value);
					showDialogBoxEventHandler = Interlocked.CompareExchange(ref this.showDialogBoxEventHandler_0, value2, showDialogBoxEventHandler2);
				}
				while ((object)showDialogBoxEventHandler != showDialogBoxEventHandler2);
			}
		}

		[Attribute3("EVENT_SHOWERRORMESSAGE")]
		[Category("Behavior")]
		public event ShowErrorMessageEventHandler ShowErrorMessage
		{
			add
			{
				ShowErrorMessageEventHandler showErrorMessageEventHandler = this.showErrorMessageEventHandler_0;
				ShowErrorMessageEventHandler showErrorMessageEventHandler2;
				do
				{
					showErrorMessageEventHandler2 = showErrorMessageEventHandler;
					ShowErrorMessageEventHandler value2 = (ShowErrorMessageEventHandler)Delegate.Combine(showErrorMessageEventHandler2, value);
					showErrorMessageEventHandler = Interlocked.CompareExchange(ref this.showErrorMessageEventHandler_0, value2, showErrorMessageEventHandler2);
				}
				while ((object)showErrorMessageEventHandler != showErrorMessageEventHandler2);
			}
			remove
			{
				ShowErrorMessageEventHandler showErrorMessageEventHandler = this.showErrorMessageEventHandler_0;
				ShowErrorMessageEventHandler showErrorMessageEventHandler2;
				do
				{
					showErrorMessageEventHandler2 = showErrorMessageEventHandler;
					ShowErrorMessageEventHandler value2 = (ShowErrorMessageEventHandler)Delegate.Remove(showErrorMessageEventHandler2, value);
					showErrorMessageEventHandler = Interlocked.CompareExchange(ref this.showErrorMessageEventHandler_0, value2, showErrorMessageEventHandler2);
				}
				while ((object)showErrorMessageEventHandler != showErrorMessageEventHandler2);
			}
		}

		[Attribute2("CAT_IMAGES")]
		[Attribute3("EVENT_IMAGESELECTED")]
		public event ImageEventHandler ImageSelected
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

		[Attribute2("CAT_IMAGES")]
		[Attribute3("EVENT_IMAGEDESELECTED")]
		public event ImageEventHandler ImageDeselected
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

		[Attribute3("EVENT_TEXTFRAMESELECTED")]
		[Attribute2("CAT_TEXTFRAMES")]
		public event TextFrameEventHandler TextFrameSelected
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

		[Attribute3("EVENT_TEXTFRAMEDESELECTED")]
		[Attribute2("CAT_TEXTFRAMES")]
		public event TextFrameEventHandler TextFrameDeselected
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

		[Attribute3("EVENT_CHARTSELECTED")]
		[Attribute2("CAT_CHARTS")]
		public event ChartEventHandler ChartSelected
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

		[Attribute2("CAT_CHARTS")]
		[Attribute3("EVENT_CHARTDESELECTED")]
		public event ChartEventHandler ChartDeselected
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

		[Attribute2("CAT_BARCODES")]
		[Attribute3("EVENT_BARCODESELECTED")]
		public event BarcodeEventHandler BarcodeSelected
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

		[Attribute3("EVENT_BARCODEDESELECTED")]
		[Attribute2("CAT_BARCODES")]
		public event BarcodeEventHandler BarcodeDeselected
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

		[Attribute2("CAT_DRAWINGS")]
		[Attribute3("EVENT_DRAWINGSELECTED")]
		public event DrawingEventHandler DrawingSelected
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

		[Attribute3("EVENT_DRAWINGDESELECTED")]
		[Attribute2("CAT_DRAWINGS")]
		public event DrawingEventHandler DrawingDeselected
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

		[Attribute3("EVENT_FRAMESELECTED")]
		[Attribute2("CAT_FRAMES")]
		public event FrameEventHandler FrameSelected
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

		[Attribute3("EVENT_FRAMEDESELECTED")]
		[Attribute2("CAT_FRAMES")]
		public event FrameEventHandler FrameDeselected
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

		[Attribute3("EVENT_DRAWINGACTIVATED")]
		[Attribute2("CAT_DRAWINGS")]
		public event DrawingEventHandler DrawingActivated
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

		[Attribute2("CAT_DRAWINGS")]
		[Attribute3("EVENT_DRAWINGDEACTIVATED")]
		public event DrawingEventHandler DrawingDeactivated
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

		[Attribute2("CAT_TEXTFRAMES")]
		[Attribute3("EVENT_TEXTFRAMEACTIVATED")]
		public event TextFrameEventHandler TextFrameActivated
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

		[Attribute3("EVENT_TEXTFRAMEDEACTIVATED")]
		[Attribute2("CAT_TEXTFRAMES")]
		public event TextFrameEventHandler TextFrameDeactivated
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

		[Attribute3("EVENT_FIELDCLICKED")]
		[Attribute2("CAT_FIELDS")]
		public event TextFieldEventHandler TextFieldClicked
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

		[Attribute3("EVENT_FIELDENTERED")]
		[Attribute2("CAT_FIELDS")]
		public event TextFieldEventHandler TextFieldEntered
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

		[Attribute3("EVENT_FIELDLEFT")]
		[Attribute2("CAT_FIELDS")]
		public event TextFieldEventHandler TextFieldLeft
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

		[Attribute3("EVENT_FORMFIELDCHECKCHANGED")]
		[Attribute2("CAT_FIELDS")]
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

		[Attribute2("CAT_FIELDS")]
		[Attribute3("EVENT_FORMFIELDTEXTCHANGED")]
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

		[Attribute2("CAT_FIELDS")]
		[Attribute3("EVENT_HYPERTEXTLINKCLICKED")]
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

		[Attribute2("CAT_FIELDS")]
		[Attribute3("EVENT_DOCUMENTLINKCLICKED")]
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

		[Attribute3("EVENT_SUBTEXTPARTCLICKED")]
		[Attribute2("CAT_SUBTEXTPARTS")]
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

		[Attribute2("CAT_SUBTEXTPARTS")]
		[Attribute3("EVENT_SUBTEXTPARTDOUBLECLICKED")]
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

		[Attribute3("EVENT_SUBTEXTPARTLEFT")]
		[Attribute2("CAT_SUBTEXTPARTS")]
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

		[Attribute3("EVENT_EDITABLEREGIONENTERED")]
		[Attribute2("CAT_SUBTEXTPARTS")]
		public event EditableRegionEventHandler EditableRegionEntered
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

		[Attribute3("EVENT_EDITABLEREGIONLEFT")]
		[Attribute2("CAT_SUBTEXTPARTS")]
		public event EditableRegionEventHandler EditableRegionLeft
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

		[Attribute3("EVENT_CANNOTTRACKCHANGE")]
		[Category("CAT_SUBTEXTPARTS")]
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

		[Attribute2("CAT_SUBTEXTPARTS")]
		[Attribute3("EVENT_TRACKEDCHANGECHANGED")]
		public event TrackedChangeEventHandler TrackedChangeChanged
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

		[Attribute2("CAT_TOC")]
		[Attribute3("EVENT_TOCENTERED")]
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

		public override void vmethod_0()
		{
			base.vmethod_0();
			if (this.int_1 != 0)
			{
				base.textControlCore_0.method_29(TextPart.Auto, 2139, this.int_1, 0);
			}
			base.textControlCore_0.method_4(this.dialogUnit_0);
			this.caretStateEventArgs_0 = new CaretStateEventArgs(base.textControlCore_0.IntPtr_0);
			this.inputFormat_0.method_6(base.textControlCore_0);
			this.inputFormat_0.method_5((Enum84)0);
			this.view_0.method_0(base.textControlCore_0.IntPtr_0);
			this.userInput_0.method_0(base.textControlCore_0.IntPtr_0);
			this.colors_0.method_5(base.textControlCore_0.IntPtr_0);
			this.colors_0.method_1();
			base.textControlCore_0.method_30(Enum83.const_30, (this.bool_12 ? 1048576 : 134217728) | (this.bool_17 ? 536870912 : 262144) | (this.bool_11 ? 16 : 2048) | (this.bool_9 ? 4194304 : 33554432) | (this.bool_8 ? 8388608 : 16777216), 0);
			base.textControlCore_0.method_30(Enum83.const_40, 6815744, ((!this.bool_13) ? 1 : 32768) | (this.bool_16 ? 4 : 8192) | (this.bool_15 ? 64 : 1024));
			base.textControlCore_0.method_39(Enum83.const_323, (this.editMode_0 == EditMode.Edit) ? 32768 : ((this.editMode_0 != EditMode.ReadAndSelect) ? 1 : 8), "");
			base.textControlCore_0.method_30(Enum83.const_296, (int)this.permanentControlChar_0, 0);
			base.textControlCore_0.method_30(Enum83.const_137, 2048, 0);
			if (this.bool_10)
			{
				base.textControlCore_0.method_30(Enum83.const_205, 1, 0);
			}
			this.eventHandler_2 = method_11;
			this.documentPermissions_1.method_0(base.textControlCore_0);
			if (this.string_2 != null)
			{
				base.textControlCore_0.method_3(this.string_2);
			}
			this.documentPermissions_0 = new DocumentPermissions(base.textControlCore_0, bActual: true);
			this.method_12();
		}

		public DialogViewGenerator GetDialogBox(DialogBoxKind kind)
		{
			return this.GetDialogBox(kind, 0);
		}

		public DialogViewGenerator GetDialogBox(DialogBoxKind kind, int selectedTab)
		{
			Enum83 enum83_ = (Enum83)0;
			int num = 0;
			ushort ushort_ = 0;
			switch (kind)
			{
			case DialogBoxKind.FontDialog:
				enum83_ = Enum83.const_47;
				break;
			case DialogBoxKind.FormattingStylesDialog:
				enum83_ = Enum83.const_143;
				break;
			case DialogBoxKind.ImageAttributesDialog:
				enum83_ = Enum83.const_94;
				num = Class429.smethod_3(4, selectedTab);
				break;
			case DialogBoxKind.InsertTableDialog:
				enum83_ = Enum83.const_295;
				break;
			case DialogBoxKind.LanguageDialog:
				enum83_ = Enum83.const_300;
				ushort_ = ushort.MaxValue;
				break;
			case DialogBoxKind.ListFormatDialog:
				enum83_ = Enum83.const_141;
				break;
			case DialogBoxKind.ParagraphFormatDialog:
				enum83_ = Enum83.const_50;
				ushort_ = (ushort)selectedTab;
				break;
			case DialogBoxKind.SectionFormatDialog:
				enum83_ = Enum83.const_221;
				ushort_ = (ushort)selectedTab;
				break;
			case DialogBoxKind.TabDialog:
				enum83_ = Enum83.const_142;
				break;
			case DialogBoxKind.TableFormatDialog:
				enum83_ = Enum83.const_106;
				ushort_ = (ushort)selectedTab;
				break;
			case DialogBoxKind.TextFrameAttributesDialog:
				enum83_ = Enum83.const_94;
				num = Class429.smethod_3(32, selectedTab);
				break;
			case DialogBoxKind.ChartLayoutDialog:
				enum83_ = Enum83.const_94;
				num = Class429.smethod_3(128, selectedTab);
				break;
			case DialogBoxKind.BarcodeLayoutDialog:
				enum83_ = Enum83.const_94;
				num = Class429.smethod_3(256, selectedTab);
				break;
			case DialogBoxKind.FindDialog:
				enum83_ = Enum83.const_175;
				break;
			case DialogBoxKind.ReplaceDialog:
				enum83_ = Enum83.const_361;
				break;
			case DialogBoxKind.ForeColor:
				enum83_ = Enum83.const_39;
				ushort_ = 32;
				break;
			case DialogBoxKind.TextBackColor:
				enum83_ = Enum83.const_39;
				ushort_ = 64;
				break;
			case DialogBoxKind.DrawingLayoutDialog:
				enum83_ = Enum83.const_94;
				num = Class429.smethod_3(512, selectedTab);
				break;
			case DialogBoxKind.AddSymbolDialog:
				enum83_ = Enum83.const_302;
				break;
			case DialogBoxKind.FrameFillColorDialog:
				enum83_ = Enum83.const_316;
				ushort_ = 256;
				break;
			case DialogBoxKind.FrameLineColorDialog:
				enum83_ = Enum83.const_316;
				ushort_ = 128;
				break;
			case DialogBoxKind.PageColorDialog:
				enum83_ = Enum83.const_316;
				ushort_ = 512;
				break;
			case DialogBoxKind.TableOfContentsDialog:
				enum83_ = Enum83.const_346;
				break;
			}
			if (base.textControlCore_0.IntPtr_0 != IntPtr.Zero)
			{
				if (!this.dialogViewGenerator_0.method_0(base.textControlCore_0, TextPart.Auto, enum83_, ushort_, num))
				{
					return null;
				}
				return this.dialogViewGenerator_0;
			}
			return null;
		}

		public DialogViewGenerator GetDialogBox(PageNumberField pageNumberField)
		{
			if (base.textControlCore_0.IntPtr_0 != IntPtr.Zero)
			{
				if (!this.dialogViewGenerator_0.method_0(base.textControlCore_0, pageNumberField.textPart_0, Enum83.const_294, (ushort)pageNumberField.int_0, 0))
				{
					return null;
				}
				return this.dialogViewGenerator_0;
			}
			return null;
		}

		public void Copy()
		{
			if (base.textControlCore_0.isHandleCreated)
			{
				base.textControlCore_0.method_29(TextPart.Auto, 769, 0, 0);
			}
		}

		public void Cut()
		{
			if (base.textControlCore_0.isHandleCreated)
			{
				base.textControlCore_0.method_29(TextPart.Auto, 768, 0, 0);
			}
		}

		public void Paste()
		{
			if (base.textControlCore_0.isHandleCreated)
			{
				base.textControlCore_0.method_29(TextPart.Auto, 770, 0, 0);
			}
		}

		public void Paste(ClipboardFormat format)
		{
			if (base.textControlCore_0.isHandleCreated)
			{
				base.textControlCore_0.method_29(TextPart.Auto, 2061, (int)format, 0);
			}
		}

		public ClipboardFormat[] GetClipboardFormats()
		{
			if (base.textControlCore_0.isHandleCreated)
			{
				int[] array = new int[10];
				int num = base.textControlCore_0.method_40(TextPart.Auto, 1920, 10, array);
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

		public void ClearUndo()
		{
			if (base.textControlCore_0.isHandleCreated)
			{
				base.textControlCore_0.method_29(TextPart.Auto, 2039, 0, 0);
			}
		}

		public void Undo()
		{
			if (base.textControlCore_0.isHandleCreated)
			{
				base.textControlCore_0.method_29(TextPart.Auto, 2032, 0, 0);
			}
		}

		public void Redo()
		{
			if (base.textControlCore_0.isHandleCreated)
			{
				base.textControlCore_0.method_29(TextPart.Auto, 2040, 0, 0);
			}
		}

		public void BeginUndoAction(string actionName)
		{
			if (base.textControlCore_0.isHandleCreated)
			{
				base.textControlCore_0.method_19(TextPart.Auto, actionName);
				base.textControlCore_0.method_10(bool_1: true);
			}
		}

		public void EndUndoAction()
		{
			if (base.textControlCore_0.isHandleCreated)
			{
				base.textControlCore_0.method_20(TextPart.Auto);
				base.textControlCore_0.method_10(bool_1: false);
			}
		}

		public void Zoom(int zoomFactor)
		{
			this.view_0.ZoomFactor = zoomFactor;
		}

		public void Zoom(ZoomOption zoomOption)
		{
			base.textControlCore_0.method_30(Enum83.const_354, 0, Class429.smethod_3(1, (int)zoomOption));
		}

		public override IntPtr vmethod_1(IntPtr intptr_1, int int_2, IntPtr intptr_2, IntPtr intptr_3)
		{
			IntPtr result = IntPtr.Zero;
			switch (int_2)
			{
			case 2087:
			{
				int num = intptr_2.ToInt32();
				switch (num)
				{
				default:
					this.OnDrawShape(new DrawShapeEventArgs(num, (Class429.Struct83)Marshal.PtrToStructure(intptr_3, typeof(Class429.Struct83))));
					break;
				case 4:
				case 5:
				{
					Class429.Struct83 rect = (Class429.Struct83)Marshal.PtrToStructure(intptr_3, typeof(Class429.Struct83));
					if (rect.int_2 - rect.int_0 != 0)
					{
						if (num == 4)
						{
							this.OnDrawCombobox(new DrawComboboxEventArgs(base.textControlCore_0, rect));
						}
						if (num == 5)
						{
							this.OnDrawDateControl(new DrawDateControlEventArgs(base.textControlCore_0, rect));
						}
					}
					else
					{
						if (num == 4)
						{
							this.OnRemoveCombobox(EventArgs.Empty);
						}
						if (num == 5)
						{
							this.OnRemoveDateControl(EventArgs.Empty);
						}
					}
					break;
				}
				}
				break;
			}
			case 2073:
				this.OnShowErrorMessage(new ShowErrorMessageEventArgs(Marshal.PtrToStringUni(intptr_3), intptr_2));
				break;
			default:
				result = base.vmethod_1(intptr_1, int_2, intptr_2, intptr_3);
				break;
			case 2124:
				this.OnShowDialogBox(new ShowDialogBoxEventArgs(intptr_3, this.dialogViewGenerator_0));
				break;
			case 2093:
				result = new IntPtr(base.textControlCore_0.method_28(Marshal.PtrToStringUni(intptr_2), Marshal.PtrToStringUni(intptr_3)) ? 1 : 0);
				break;
			}
			return result;
		}

		private void method_7(IntPtr intptr_1)
		{
			if (intptr_1 != IntPtr.Zero)
			{
				Class429.SendMessage_6(intptr_1, 2042, Class429.smethod_3(0, 1796), base.textControlCore_0.IntPtr_0);
			}
		}

		private void method_8(IntPtr intptr_1)
		{
			if (intptr_1 != IntPtr.Zero)
			{
				Class429.SendMessage_1(intptr_1, 10, 0, 0);
			}
		}

		internal void method_9(Control10 control10_0, DrawingFrame drawingFrame_1)
		{
			MethodInfo method = base.GetType().GetMethod("DrawingViewChanged", BindingFlags.Instance | BindingFlags.NonPublic);
			control10_0.ClearUndo();
			this.bool_7 = false;
			control10_0.method_12(this.eventHandler_2);
			control10_0.method_16(this, method);
			this.drawingFrame_0 = drawingFrame_1;
		}

		private void method_10(Control10 control10_0, DrawingFrame drawingFrame_1)
		{
			MethodInfo method = base.GetType().GetMethod("DrawingViewChanged", BindingFlags.Instance | BindingFlags.NonPublic);
			if (this.bool_7)
			{
				drawingFrame_1.AddUndoUnit();
			}
			control10_0.method_13(this.eventHandler_2);
			control10_0.method_17(this, method);
			this.drawingFrame_0 = null;
		}

		private void method_11(object sender, EventArgs e)
		{
			this.bool_7 = true;
		}

		[Obfuscation(Exclude = true)]
		private void DrawingViewChanged(object sender, EventArgs e)
		{
			if (this.drawingFrame_0 != null)
			{
				Control10 control = (Control10)base.textControlCore_0.control6_0[this.drawingFrame_0.int_1];
				Rectangle clipRectangle = control.ClipRectangle(e);
				this.drawingFrame_0.Refresh(clipRectangle);
			}
		}

		private void method_12()
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
				this.method_19();
			}
			if (boolean_2 != this.documentPermissions_0.Boolean_1)
			{
				this.method_20();
			}
			if (boolean_3 != this.documentPermissions_0.Boolean_1)
			{
				this.method_21();
			}
			if (allowFormatting != this.documentPermissions_0.AllowFormatting)
			{
				this.method_23();
			}
			if (allowFormattingStyles != this.documentPermissions_0.AllowFormattingStyles)
			{
				this.method_22();
			}
			if (allowPrinting != this.documentPermissions_0.AllowPrinting)
			{
				this.method_17();
			}
			if (readOnly != this.documentPermissions_0.ReadOnly)
			{
				this.method_18();
			}
			if (allowEditingFormFields != this.documentPermissions_0.AllowEditingFormFields)
			{
				this.method_24();
			}
		}

		protected virtual void OnCharFormatChanged(EventArgs eventArgs_0)
		{
			if (this.eventHandler_3 != null)
			{
				this.eventHandler_3(this, eventArgs_0);
			}
		}

		protected virtual void OnDocumentSizeChanged(DocumentSizeChangedEventArgs documentSizeChangedEventArgs_0)
		{
			if (this.documentSizeChangedEventHandler_0 != null)
			{
				this.documentSizeChangedEventHandler_0(this, documentSizeChangedEventArgs_0);
			}
		}

		protected virtual void OnFormattingStyleListChanged(EventArgs eventArgs_0)
		{
			if (this.eventHandler_4 != null)
			{
				this.eventHandler_4(this, eventArgs_0);
			}
		}

		protected virtual void OnInputFormattingStyleChanged(EventArgs eventArgs_0)
		{
			if (this.eventHandler_5 != null)
			{
				this.eventHandler_5(this, eventArgs_0);
			}
		}

		protected virtual void OnFormattingStyleChanged(EventArgs eventArgs_0)
		{
			if (this.eventHandler_6 != null)
			{
				this.eventHandler_6(this, eventArgs_0);
			}
		}

		protected virtual void OnInputPositionChanged(EventArgs eventArgs_0)
		{
			if (this.eventHandler_7 != null)
			{
				this.eventHandler_7(this, eventArgs_0);
			}
		}

		protected virtual void OnInputParagraphChanged(EventArgs eventArgs_0)
		{
			if (this.eventHandler_8 != null)
			{
				this.eventHandler_8(this, eventArgs_0);
			}
		}

		protected virtual void OnParagraphFormatChanged(EventArgs eventArgs_0)
		{
			if (this.eventHandler_9 != null)
			{
				this.eventHandler_9(this, eventArgs_0);
			}
		}

		protected virtual void OnPageFormatChanged(EventArgs eventArgs_0)
		{
			if (this.eventHandler_10 != null)
			{
				this.eventHandler_10(this, eventArgs_0);
			}
		}

		protected virtual void OnCaretStateChanged(CaretStateEventArgs caretStateEventArgs_1)
		{
			if (this.caretStateEventHandler_0 != null)
			{
				this.caretStateEventHandler_0(this, caretStateEventArgs_1);
			}
		}

		protected virtual void OnTextContextMenuOpening(TextContextMenuEventArgs textContextMenuEventArgs_0)
		{
			if (this.textContextMenuEventHandler_0 != null)
			{
				this.textContextMenuEventHandler_0(this, textContextMenuEventArgs_0);
			}
		}

		protected virtual void OnDrawShape(DrawShapeEventArgs drawShapeEventArgs_0)
		{
			if (this.drawShapeEventHandler_0 != null)
			{
				this.drawShapeEventHandler_0(this, drawShapeEventArgs_0);
			}
		}

		protected virtual void OnDrawCombobox(DrawComboboxEventArgs drawComboboxEventArgs_0)
		{
			if (this.drawComboboxEventHandler_0 != null)
			{
				this.drawComboboxEventHandler_0(this, drawComboboxEventArgs_0);
			}
		}

		protected virtual void OnRemoveCombobox(EventArgs eventArgs_0)
		{
			if (this.eventHandler_11 != null)
			{
				this.eventHandler_11(this, eventArgs_0);
			}
		}

		protected virtual void OnDrawDateControl(DrawDateControlEventArgs drawDateControlEventArgs_0)
		{
			if (this.drawDateControlEventHandler_0 != null)
			{
				this.drawDateControlEventHandler_0(this, drawDateControlEventArgs_0);
			}
		}

		protected virtual void OnRemoveDateControl(EventArgs eventArgs_0)
		{
			if (this.eventHandler_12 != null)
			{
				this.eventHandler_12(this, eventArgs_0);
			}
		}

		protected virtual void OnChanged(EventArgs eventArgs_0)
		{
			if (this.eventHandler_13 != null)
			{
				this.eventHandler_13(this, eventArgs_0);
			}
		}

		protected virtual void OnMainTextActivated(EventArgs eventArgs_0)
		{
			if (this.eventHandler_14 != null)
			{
				this.eventHandler_14(this, eventArgs_0);
			}
		}

		protected virtual void OnShowDialogBox(ShowDialogBoxEventArgs showDialogBoxEventArgs_0)
		{
			if (this.showDialogBoxEventHandler_0 != null)
			{
				this.showDialogBoxEventHandler_0(this, showDialogBoxEventArgs_0);
			}
			else
			{
				showDialogBoxEventArgs_0.method_0();
			}
		}

		protected virtual void OnShowErrorMessage(ShowErrorMessageEventArgs showErrorMessageEventArgs_0)
		{
			if (this.showErrorMessageEventHandler_0 != null)
			{
				this.showErrorMessageEventHandler_0(this, showErrorMessageEventArgs_0);
			}
		}

		protected virtual void OnImageSelected(ImageEventArgs imageEventArgs_0)
		{
			if (this.imageEventHandler_2 != null)
			{
				this.imageEventHandler_2(this, imageEventArgs_0);
			}
		}

		protected virtual void OnImageDeselected(ImageEventArgs imageEventArgs_0)
		{
			if (this.imageEventHandler_3 != null)
			{
				this.imageEventHandler_3(this, imageEventArgs_0);
			}
		}

		protected virtual void OnTextFrameSelected(TextFrameEventArgs textFrameEventArgs_0)
		{
			if (this.textFrameEventHandler_2 != null)
			{
				this.textFrameEventHandler_2(this, textFrameEventArgs_0);
			}
		}

		protected virtual void OnTextFrameDeselected(TextFrameEventArgs textFrameEventArgs_0)
		{
			if (this.textFrameEventHandler_3 != null)
			{
				this.textFrameEventHandler_3(this, textFrameEventArgs_0);
			}
		}

		protected virtual void OnChartSelected(ChartEventArgs chartEventArgs_0)
		{
			if (this.chartEventHandler_2 != null)
			{
				this.chartEventHandler_2(this, chartEventArgs_0);
			}
		}

		protected virtual void OnChartDeselected(ChartEventArgs chartEventArgs_0)
		{
			if (this.chartEventHandler_3 != null)
			{
				this.chartEventHandler_3(this, chartEventArgs_0);
			}
		}

		protected virtual void OnBarcodeSelected(BarcodeEventArgs barcodeEventArgs_0)
		{
			if (this.barcodeEventHandler_2 != null)
			{
				this.barcodeEventHandler_2(this, barcodeEventArgs_0);
			}
		}

		protected virtual void OnBarcodeDeselected(BarcodeEventArgs barcodeEventArgs_0)
		{
			if (this.barcodeEventHandler_3 != null)
			{
				this.barcodeEventHandler_3(this, barcodeEventArgs_0);
			}
		}

		protected virtual void OnDrawingSelected(DrawingEventArgs drawingEventArgs_0)
		{
			if (this.drawingEventHandler_2 != null)
			{
				this.drawingEventHandler_2(this, drawingEventArgs_0);
			}
		}

		protected virtual void OnDrawingDeselected(DrawingEventArgs drawingEventArgs_0)
		{
			if (this.drawingEventHandler_3 != null)
			{
				this.drawingEventHandler_3(this, drawingEventArgs_0);
			}
		}

		protected virtual void OnFrameSelected(FrameEventArgs frameEventArgs_0)
		{
			if (this.frameEventHandler_0 != null)
			{
				this.frameEventHandler_0(this, frameEventArgs_0);
			}
		}

		protected virtual void OnFrameDeselected(FrameEventArgs frameEventArgs_0)
		{
			if (this.frameEventHandler_1 != null)
			{
				this.frameEventHandler_1(this, frameEventArgs_0);
			}
		}

		protected virtual void OnDrawingActivated(DrawingEventArgs drawingEventArgs_0)
		{
			if (this.drawingEventHandler_4 != null)
			{
				this.drawingEventHandler_4(this, drawingEventArgs_0);
			}
		}

		protected virtual void OnDrawingDeactivated(DrawingEventArgs drawingEventArgs_0)
		{
			if (this.drawingEventHandler_5 != null)
			{
				this.drawingEventHandler_5(this, drawingEventArgs_0);
			}
		}

		protected virtual void OnTextFrameActivated(TextFrameEventArgs textFrameEventArgs_0)
		{
			if (this.textFrameEventHandler_4 != null)
			{
				this.textFrameEventHandler_4(this, textFrameEventArgs_0);
			}
		}

		protected virtual void OnTextFrameDeactivated(TextFrameEventArgs textFrameEventArgs_0)
		{
			if (this.textFrameEventHandler_5 != null)
			{
				this.textFrameEventHandler_5(this, textFrameEventArgs_0);
			}
		}

		protected virtual void OnFrameMoved(FrameEventArgs frameEventArgs_0)
		{
			if (this.frameEventHandler_2 != null)
			{
				this.frameEventHandler_2(this, frameEventArgs_0);
			}
		}

		protected virtual void OnFrameSized(FrameEventArgs frameEventArgs_0)
		{
			if (this.frameEventHandler_3 != null)
			{
				this.frameEventHandler_3(this, frameEventArgs_0);
			}
		}

		protected virtual void OnTextFieldClicked(TextFieldEventArgs textFieldEventArgs_0)
		{
			if (this.textFieldEventHandler_2 != null)
			{
				this.textFieldEventHandler_2(this, textFieldEventArgs_0);
			}
		}

		protected virtual void OnTextFieldEntered(TextFieldEventArgs textFieldEventArgs_0)
		{
			if (this.textFieldEventHandler_3 != null)
			{
				this.textFieldEventHandler_3(this, textFieldEventArgs_0);
			}
		}

		protected virtual void OnTextFieldLeft(TextFieldEventArgs textFieldEventArgs_0)
		{
			if (this.textFieldEventHandler_4 != null)
			{
				this.textFieldEventHandler_4(this, textFieldEventArgs_0);
			}
		}

		protected virtual void OnFormFieldCheckChanged(CheckFormFieldEventArgs checkFormFieldEventArgs_0)
		{
			if (this.checkFormFieldEventHandler_0 != null)
			{
				this.checkFormFieldEventHandler_0(this, checkFormFieldEventArgs_0);
			}
		}

		protected virtual void OnFormFieldDateChanged(DateFormFieldEventArgs dateFormFieldEventArgs_0)
		{
			if (this.dateFormFieldEventHandler_0 != null)
			{
				this.dateFormFieldEventHandler_0(this, dateFormFieldEventArgs_0);
			}
		}

		protected virtual void OnFormFieldSelectionChanged(SelectionFormFieldEventArgs selectionFormFieldEventArgs_0)
		{
			if (this.selectionFormFieldEventHandler_0 != null)
			{
				this.selectionFormFieldEventHandler_0(this, selectionFormFieldEventArgs_0);
			}
		}

		protected virtual void OnFormFieldTextChanged(TextFormFieldEventArgs textFormFieldEventArgs_0)
		{
			if (this.textFormFieldEventHandler_0 != null)
			{
				this.textFormFieldEventHandler_0(this, textFormFieldEventArgs_0);
			}
		}

		protected virtual void OnHypertextLinkClicked(HypertextLinkEventArgs hypertextLinkEventArgs_0)
		{
			if (this.hypertextLinkEventHandler_0 != null)
			{
				this.hypertextLinkEventHandler_0(this, hypertextLinkEventArgs_0);
			}
		}

		protected virtual void OnDocumentLinkClicked(DocumentLinkEventArgs documentLinkEventArgs_0)
		{
			if (this.documentLinkEventHandler_0 != null)
			{
				this.documentLinkEventHandler_0(this, documentLinkEventArgs_0);
			}
		}

		protected virtual void OnSubTextPartClicked(SubTextPartEventArgs subTextPartEventArgs_0)
		{
			if (this.subTextPartEventHandler_2 != null)
			{
				this.subTextPartEventHandler_2(this, subTextPartEventArgs_0);
			}
		}

		protected virtual void OnSubTextPartDoubleClicked(SubTextPartEventArgs subTextPartEventArgs_0)
		{
			if (this.subTextPartEventHandler_3 != null)
			{
				this.subTextPartEventHandler_3(this, subTextPartEventArgs_0);
			}
		}

		protected virtual void OnSubTextPartEntered(SubTextPartEventArgs subTextPartEventArgs_0)
		{
			if (this.subTextPartEventHandler_4 != null)
			{
				this.subTextPartEventHandler_4(this, subTextPartEventArgs_0);
			}
		}

		protected virtual void OnSubTextPartLeft(SubTextPartEventArgs subTextPartEventArgs_0)
		{
			if (this.subTextPartEventHandler_5 != null)
			{
				this.subTextPartEventHandler_5(this, subTextPartEventArgs_0);
			}
		}

		protected virtual void OnEditableRegionEntered(EditableRegionEventArgs editableRegionEventArgs_0)
		{
			if (this.editableRegionEventHandler_2 != null)
			{
				this.editableRegionEventHandler_2(this, editableRegionEventArgs_0);
			}
		}

		protected virtual void OnEditableRegionLeft(EditableRegionEventArgs editableRegionEventArgs_0)
		{
			if (this.editableRegionEventHandler_3 != null)
			{
				this.editableRegionEventHandler_3(this, editableRegionEventArgs_0);
			}
		}

		protected virtual void OnCannotTrackChange(CannotTrackChangeEventArgs cannotTrackChangeEventArgs_0)
		{
			if (this.cannotTrackChangeEventHandler_0 != null)
			{
				cannotTrackChangeEventArgs_0.DefaultMessage = base.resourceManager_0.GetString("MSG_CANNOTTRACKCHANGE_TEXT");
				this.cannotTrackChangeEventHandler_0(this, cannotTrackChangeEventArgs_0);
			}
		}

		protected virtual void OnTrackedChangeChanged(TrackedChangeEventArgs trackedChangeEventArgs_0)
		{
			if (this.trackedChangeEventHandler_2 != null)
			{
				this.trackedChangeEventHandler_2(this, trackedChangeEventArgs_0);
			}
		}

		protected virtual void OnTrackedChangeStateChanged(TrackedChangeEventArgs trackedChangeEventArgs_0)
		{
			if (this.trackedChangeEventHandler_3 != null)
			{
				this.trackedChangeEventHandler_3(this, trackedChangeEventArgs_0);
			}
		}

		protected virtual void OnTableOfContentsEntered(TableOfContentsEventArgs tableOfContentsEventArgs_0)
		{
			if (this.tableOfContentsEventHandler_2 != null)
			{
				this.tableOfContentsEventHandler_2(this, tableOfContentsEventArgs_0);
			}
		}

		protected virtual void OnTableOfContentsLeft(TableOfContentsEventArgs tableOfContentsEventArgs_0)
		{
			if (this.tableOfContentsEventHandler_3 != null)
			{
				this.tableOfContentsEventHandler_3(this, tableOfContentsEventArgs_0);
			}
		}

		protected virtual void OnHeaderFooterActivated(HeaderFooterEventArgs headerFooterEventArgs_0)
		{
			if (this.headerFooterEventHandler_0 != null)
			{
				this.headerFooterEventHandler_0(this, headerFooterEventArgs_0);
			}
		}

		protected virtual void OnHeaderFooterDeactivated(HeaderFooterEventArgs headerFooterEventArgs_0)
		{
			if (this.headerFooterEventHandler_1 != null)
			{
				this.headerFooterEventHandler_1(this, headerFooterEventArgs_0);
			}
		}

		private void method_13()
		{
			if (this.propertyChangedEventHandler_0 != null)
			{
				this.propertyChangedEventHandler_0(this, new PropertyChangedEventArgs("CanCopy"));
			}
		}

		private void method_14()
		{
			if (this.propertyChangedEventHandler_0 != null)
			{
				this.propertyChangedEventHandler_0(this, new PropertyChangedEventArgs("CanPaste"));
			}
		}

		private void method_15()
		{
			if (this.propertyChangedEventHandler_0 != null)
			{
				this.propertyChangedEventHandler_0(this, new PropertyChangedEventArgs("CanUndo"));
			}
		}

		private void method_16()
		{
			if (this.propertyChangedEventHandler_0 != null)
			{
				this.propertyChangedEventHandler_0(this, new PropertyChangedEventArgs("CanRedo"));
			}
		}

		private void method_17()
		{
			if (this.propertyChangedEventHandler_0 != null)
			{
				this.propertyChangedEventHandler_0(this, new PropertyChangedEventArgs("CanPrint"));
			}
		}

		private void method_18()
		{
			if (this.propertyChangedEventHandler_0 != null)
			{
				this.propertyChangedEventHandler_0(this, new PropertyChangedEventArgs("CanEdit"));
			}
		}

		private void method_19()
		{
			if (this.propertyChangedEventHandler_0 != null)
			{
				this.propertyChangedEventHandler_0(this, new PropertyChangedEventArgs("CanCharacterFormat"));
			}
		}

		private void method_20()
		{
			if (this.propertyChangedEventHandler_0 != null)
			{
				this.propertyChangedEventHandler_0(this, new PropertyChangedEventArgs("CanParagraphFormat"));
			}
		}

		private void method_21()
		{
			if (this.propertyChangedEventHandler_0 != null)
			{
				this.propertyChangedEventHandler_0(this, new PropertyChangedEventArgs("CanTableFormat"));
			}
		}

		private void method_22()
		{
			if (this.propertyChangedEventHandler_0 != null)
			{
				this.propertyChangedEventHandler_0(this, new PropertyChangedEventArgs("CanStyleFormat"));
			}
		}

		private void method_23()
		{
			if (this.propertyChangedEventHandler_0 != null)
			{
				this.propertyChangedEventHandler_0(this, new PropertyChangedEventArgs("CanDocumentFormat"));
			}
		}

		private void method_24()
		{
			if (this.propertyChangedEventHandler_0 != null)
			{
				this.propertyChangedEventHandler_0(this, new PropertyChangedEventArgs("CanEditFormFields"));
			}
		}

		private void method_25()
		{
			this.method_12();
			if (this.caretStateEventArgs_0 != null && this.caretStateEventArgs_0.method_0())
			{
				this.OnCaretStateChanged(this.caretStateEventArgs_0);
			}
			if (this.propertyChangedEventHandler_0 != null)
			{
				this.propertyChangedEventHandler_0(this, new PropertyChangedEventArgs("EditMode"));
			}
		}

		internal override bool vmethod_2(Struct62 struct62_0)
		{
			bool result = false;
			this.inputFormat_0.method_5((Enum84)struct62_0.struct84_0.uint_0);
			this.method_26(struct62_0);
			switch (struct62_0.struct84_0.uint_0)
			{
			case 1796u:
			case 1800u:
			case 1804u:
			case 1805u:
			case 1807u:
			case 1817u:
			case 1818u:
			case 1827u:
			case 1837u:
			case 1853u:
			case 1857u:
			case 1858u:
				if (this.caretStateEventArgs_0 != null && this.caretStateEventArgs_0.method_0())
				{
					this.OnCaretStateChanged(this.caretStateEventArgs_0);
				}
				break;
			}
			switch (struct62_0.struct84_0.uint_0)
			{
			case 1909u:
				this.OnTableOfContentsEntered(new TableOfContentsEventArgs(base.textControlCore_0, (TextPart)struct62_0.uint_1, (int)struct62_0.uint_0, bDeleted: false));
				break;
			case 1910u:
				this.OnTableOfContentsLeft(new TableOfContentsEventArgs(base.textControlCore_0, (TextPart)struct62_0.uint_1, (int)struct62_0.uint_0, bDeleted: false));
				break;
			case 1911u:
				this.OnFormattingStyleChanged(EventArgs.Empty);
				break;
			case 1815u:
				this.OnInputParagraphChanged(EventArgs.Empty);
				break;
			case 1827u:
				this.OnPageFormatChanged(EventArgs.Empty);
				break;
			case 1810u:
			case 1821u:
			case 1828u:
			{
				TextFieldEventArgs textFieldEventArgs_ = new TextFieldEventArgs(base.textControlCore_0, (TextPart)struct62_0.uint_1, (int)struct62_0.uint_0, bCreateObject: false);
				switch (struct62_0.struct84_0.uint_0)
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
				}
				break;
			}
			case 1837u:
				this.OnHeaderFooterActivated(new HeaderFooterEventArgs(base.textControlCore_0, (HeaderFooterType)struct62_0.uint_0, Class429.smethod_6((int)struct62_0.uint_1)));
				break;
			case 1838u:
				this.OnHeaderFooterDeactivated(new HeaderFooterEventArgs(base.textControlCore_0, (HeaderFooterType)struct62_0.uint_0, Class429.smethod_6((int)struct62_0.uint_1)));
				break;
			case 1841u:
				this.OnInputFormattingStyleChanged(EventArgs.Empty);
				break;
			case 1842u:
				this.OnFormattingStyleListChanged(EventArgs.Empty);
				break;
			case 1847u:
				this.OnHypertextLinkClicked(new HypertextLinkEventArgs(base.textControlCore_0, (TextPart)struct62_0.uint_1, (int)struct62_0.uint_0));
				break;
			case 1848u:
				this.OnDocumentLinkClicked(new DocumentLinkEventArgs(base.textControlCore_0, (TextPart)struct62_0.uint_1, (int)struct62_0.uint_0));
				break;
			case 1863u:
				this.method_13();
				break;
			case 1864u:
				this.method_14();
				break;
			case 1865u:
				this.method_15();
				break;
			case 1866u:
				this.method_16();
				break;
			case 1867u:
			{
				TextContextMenuEventArgs textContextMenuEventArgs_ = new TextContextMenuEventArgs((ContextMenuLocation)struct62_0.uint_0, this, (TextPart)struct62_0.uint_1, base.class408_0, base.resourceManager_0, base.class415_0);
				this.OnTextContextMenuOpening(textContextMenuEventArgs_);
				result = true;
				break;
			}
			case 1868u:
			case 1869u:
				this.OnDocumentSizeChanged(new DocumentSizeChangedEventArgs(base.textControlCore_0));
				break;
			case 1823u:
			case 1824u:
			case 1853u:
			case 1854u:
			case 1857u:
			case 1858u:
			case 1871u:
			case 1872u:
			{
				FrameEventArgs frameEventArgs_ = new FrameEventArgs(base.textControlCore_0, (TextPart)struct62_0.uint_1, (int)struct62_0.uint_0);
				switch (struct62_0.struct84_0.uint_0)
				{
				case 1857u:
					this.OnFrameSelected(frameEventArgs_);
					break;
				case 1858u:
					this.OnFrameDeselected(frameEventArgs_);
					break;
				case 1823u:
					this.OnFrameMoved(frameEventArgs_);
					break;
				case 1824u:
					this.OnFrameSized(frameEventArgs_);
					break;
				}
				switch (Class429.SendMessage_1(base.textControlCore_0.IntPtr_0, 1887, (int)struct62_0.uint_0, 0))
				{
				case 5:
					TextFrameEventArgs textFrameEventArgs_ = new TextFrameEventArgs(base.textControlCore_0, (TextPart)struct62_0.uint_1, (int)struct62_0.uint_0);
						switch (struct62_0.struct84_0.uint_0)
						{
						case 1853u:
							this.OnTextFrameActivated(textFrameEventArgs_);
							break;
						case 1854u:
							this.OnTextFrameDeactivated(textFrameEventArgs_);
							break;
						case 1857u:
							this.OnTextFrameSelected(textFrameEventArgs_);
							break;
						case 1858u:
							this.OnTextFrameDeselected(textFrameEventArgs_);
							break;
						}
					break;
				case 7:
					ChartEventArgs chartEventArgs_ = new ChartEventArgs(base.textControlCore_0, (TextPart)struct62_0.uint_1, (int)struct62_0.uint_0, base.textControlCore_0.control5_0[(int)struct62_0.uint_0].Component);
						switch (struct62_0.struct84_0.uint_0)
						{
						case 1857u:
							this.OnChartSelected(chartEventArgs_);
							break;
						case 1858u:
							this.OnChartDeselected(chartEventArgs_);
							break;
						}
					break;
				case 8:
					BarcodeEventArgs barcodeEventArgs_ = new BarcodeEventArgs(base.textControlCore_0, (TextPart)struct62_0.uint_1, (int)struct62_0.uint_0, base.textControlCore_0.control4_0[(int)struct62_0.uint_0].Component);
						switch (struct62_0.struct84_0.uint_0)
						{
						case 1857u:
							this.OnBarcodeSelected(barcodeEventArgs_);
							break;
						case 1858u:
							this.OnBarcodeDeselected(barcodeEventArgs_);
							break;
						}
					break;
				case 9:
					Control10 control = (Control10)base.textControlCore_0.control6_0[(int)struct62_0.uint_0];
						DrawingEventArgs drawingEventArgs_ = new DrawingEventArgs(base.textControlCore_0, (TextPart)struct62_0.uint_1, (int)struct62_0.uint_0, control.Component);
								switch (struct62_0.struct84_0.uint_0)
								{
									case 1871u:
										this.method_9(control, new DrawingFrame(base.textControlCore_0, (TextPart)struct62_0.uint_1, (int)struct62_0.uint_0, control.Component));
										this.OnDrawingActivated(drawingEventArgs_);
										break;
									case 1872u:
										this.method_10(control, new DrawingFrame(base.textControlCore_0, (TextPart)struct62_0.uint_1, (int)struct62_0.uint_0, control.Component));
										this.OnDrawingDeactivated(drawingEventArgs_);
										break;
									case 1857u:
										this.OnDrawingSelected(drawingEventArgs_);
										break;
									case 1858u:
										this.OnDrawingDeselected(drawingEventArgs_);
										break;
								}
					break;
				case 0:
				{
					ImageEventArgs imageEventArgs_ = new ImageEventArgs(base.textControlCore_0, (TextPart)struct62_0.uint_1, (int)struct62_0.uint_0);
					switch (struct62_0.struct84_0.uint_0)
					{
					case 1857u:
						this.OnImageSelected(imageEventArgs_);
						break;
					case 1858u:
						this.OnImageDeselected(imageEventArgs_);
						break;
					}
					break;
				}
				}
				break;
			}
			case 1873u:
				this.OnSubTextPartEntered(new SubTextPartEventArgs(base.textControlCore_0, (TextPart)struct62_0.uint_1, (int)struct62_0.uint_0, bDeleted: false));
				break;
			case 1874u:
				this.OnSubTextPartLeft(new SubTextPartEventArgs(base.textControlCore_0, (TextPart)struct62_0.uint_1, (int)struct62_0.uint_0, bDeleted: false));
				break;
			case 1877u:
				this.OnSubTextPartClicked(new SubTextPartEventArgs(base.textControlCore_0, (TextPart)struct62_0.uint_1, (int)struct62_0.uint_0, bDeleted: false));
				break;
			case 1878u:
				this.OnSubTextPartDoubleClicked(new SubTextPartEventArgs(base.textControlCore_0, (TextPart)struct62_0.uint_1, (int)struct62_0.uint_0, bDeleted: false));
				break;
			case 1883u:
				this.documentPermissions_1.method_4();
				this.method_12();
				result = base.vmethod_2(struct62_0);
				break;
			case 1886u:
				this.method_25();
				break;
			case 1887u:
				this.OnEditableRegionEntered(new EditableRegionEventArgs(base.textControlCore_0, (TextPart)struct62_0.uint_1, (int)struct62_0.uint_0, bDeleted: false));
				this.method_12();
				break;
			case 1888u:
				this.OnEditableRegionLeft(new EditableRegionEventArgs(base.textControlCore_0, (TextPart)struct62_0.uint_1, (int)struct62_0.uint_0, bDeleted: false));
				this.method_12();
				break;
			case 1891u:
				this.documentPermissions_1.method_4();
				result = base.vmethod_2(struct62_0);
				this.method_12();
				break;
			case 1892u:
			{
				CannotTrackChangeEventArgs cannotTrackChangeEventArgs = new CannotTrackChangeEventArgs();
				this.OnCannotTrackChange(cannotTrackChangeEventArgs);
				result = ((!cannotTrackChangeEventArgs.Cancel) ? true : false);
				break;
			}
			case 1895u:
				this.OnTrackedChangeChanged(new TrackedChangeEventArgs(base.textControlCore_0, (TextPart)struct62_0.uint_1, (int)struct62_0.uint_0, bDeleted: false));
				break;
			case 1896u:
				this.OnMainTextActivated(EventArgs.Empty);
				break;
			case 1897u:
				this.OnTrackedChangeStateChanged(new TrackedChangeEventArgs(base.textControlCore_0, (TextPart)struct62_0.uint_1, (int)struct62_0.uint_0, bDeleted: false));
				break;
			case 1901u:
				this.OnFormFieldDateChanged(new DateFormFieldEventArgs(base.textControlCore_0, (TextPart)struct62_0.uint_1, (int)struct62_0.uint_0));
				break;
			case 1902u:
				this.OnFormFieldCheckChanged(new CheckFormFieldEventArgs(base.textControlCore_0, (TextPart)struct62_0.uint_1, (int)struct62_0.uint_0));
				break;
			case 1903u:
				this.OnFormFieldSelectionChanged(new SelectionFormFieldEventArgs(base.textControlCore_0, (TextPart)struct62_0.uint_1, (int)struct62_0.uint_0));
				break;
			case 1904u:
				this.OnFormFieldTextChanged(new TextFormFieldEventArgs(base.textControlCore_0, (TextPart)struct62_0.uint_1, (int)struct62_0.uint_0));
				break;
			case 1799u:
				this.OnChanged(EventArgs.Empty);
				break;
			case 1800u:
				this.OnInputPositionChanged(EventArgs.Empty);
				break;
			case 1804u:
				this.OnCharFormatChanged(EventArgs.Empty);
				break;
			case 1805u:
				this.OnParagraphFormatChanged(EventArgs.Empty);
				break;
			default:
				result = base.vmethod_2(struct62_0);
				break;
			case 1807u:
			case 1817u:
			case 1818u:
			case 1870u:
			case 1879u:
			case 1880u:
				this.view_0.method_1((Enum84)struct62_0.struct84_0.uint_0, struct62_0.uint_0);
				break;
			}
			return result;
		}

		internal override void vmethod_3(Struct62 struct62_0)
		{
			if (base.Class431_0 == null || !this.IsFormFieldValidationEnabled || !base.IsCreated)
			{
				return;
			}
			switch (struct62_0.struct84_0.uint_0)
			{
			case 1853u:
				base.Class431_0.method_7((TextPart)Class429.smethod_3(0, (int)struct62_0.uint_0));
				break;
			case 1837u:
				base.Class431_0.method_7((TextPart)struct62_0.uint_1);
				break;
			case 1811u:
				base.Class431_0.method_4(new TextFieldEventArgs(base.textControlCore_0, (TextPart)struct62_0.uint_1, (int)struct62_0.uint_0, bCreateObject: false).TextField as FormField, (TextPart)struct62_0.uint_1);
				break;
			case 1813u:
				if (new TextFieldEventArgs(base.textControlCore_0, (TextPart)struct62_0.uint_1, (int)struct62_0.uint_0, bCreateObject: false).TextField is FormField)
				{
					base.Class431_0.method_5((int)struct62_0.uint_0, (TextPart)struct62_0.uint_1);
				}
				break;
			case 1886u:
				if (base.Class431_0.Boolean_0 = this.Boolean_0)
				{
					base.Class431_0.method_3();
				}
				break;
			case 1883u:
				base.Class431_0.method_2((TextPart)struct62_0.uint_1);
				break;
			case 1896u:
				base.Class431_0.method_7(TextPart.MainText);
				break;
			case 1901u:
			case 1902u:
			case 1903u:
			case 1904u:
				base.Class431_0.method_6(struct62_0, (TextPart)struct62_0.uint_1);
				break;
			case 1891u:
				base.Class431_0.method_1((TextPart)struct62_0.uint_1);
				break;
			}
		}

		private void method_26(Struct62 struct62_0)
		{
			if (this.statusBarViewGenerator_0 != null && this.statusBarViewGenerator_0.intptr_0 != IntPtr.Zero)
			{
				switch (struct62_0.struct84_0.uint_0)
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
					Class429.SendMessage(this.statusBarViewGenerator_0.intptr_0, 2052, struct62_0.struct84_0.intptr_1.ToInt32(), ref struct62_0);
					break;
				}
			}
			if (this.rulerBarViewGenerator_0 != null && this.rulerBarViewGenerator_0.intptr_0 != IntPtr.Zero)
			{
				switch (struct62_0.struct84_0.uint_0)
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
				case 1898u:
					Class429.SendMessage(this.rulerBarViewGenerator_0.intptr_0, 2052, struct62_0.struct84_0.intptr_1.ToInt32(), ref struct62_0);
					break;
				}
			}
			if (this.rulerBarViewGenerator_1 != null && this.rulerBarViewGenerator_1.intptr_0 != IntPtr.Zero)
			{
				switch (struct62_0.struct84_0.uint_0)
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
				case 1898u:
					Class429.SendMessage(this.rulerBarViewGenerator_1.intptr_0, 2052, struct62_0.struct84_0.intptr_1.ToInt32(), ref struct62_0);
					break;
				}
			}
		}

		public bool ShouldSerializeDisplayColors()
		{
			return !this.colors_0.method_4();
		}

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

		public bool ShouldSerializeLocation()
		{
			return !this.point_0.IsEmpty;
		}

		public void ResetMaxSize()
		{
			this.point_0 = Point.Empty;
		}
	}
}
