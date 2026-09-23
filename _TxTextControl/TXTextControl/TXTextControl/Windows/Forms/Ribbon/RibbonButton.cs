using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using ns21;

namespace TXTextControl.Windows.Forms.Ribbon
{
	/// <summary>The RibbonButton class is a button control which can be added to a RibbonGroup or to a RibbonMenuButton where it is stored as an item of the drop-down menu.</summary>
	[ToolboxItem(false)]
	public class RibbonButton : Control, INotifyPropertyChanged, IRibbonItem, IContentItem, IEnabledItem, IRibbonToolStripItemProvider, IScalable
	{
		protected class ButtonStructure
		{
			private string[] string_0 = new string[2] { "", "" };

			private Rectangle?[] nullable_0 = new Rectangle?[2] { null, null };

			[CompilerGenerated]
			private IconTextRelation iconTextRelation_0;

			[CompilerGenerated]
			private Rectangle? nullable_1;

			[CompilerGenerated]
			private Rectangle? nullable_2;

			[CompilerGenerated]
			private Rectangle? nullable_3;

			[CompilerGenerated]
			private Rectangle? nullable_4;

			[CompilerGenerated]
			private Rectangle? nullable_5;

			[CompilerGenerated]
			private Rectangle? nullable_6;

			[CompilerGenerated]
			private Rectangle rectangle_0;

			[CompilerGenerated]
			private Rectangle rectangle_1;

			[CompilerGenerated]
			private Rectangle rectangle_2;

			[CompilerGenerated]
			private Size size_0;

			internal IconTextRelation IconTextRelation_0
			{
				[CompilerGenerated]
				get
				{
					return this.iconTextRelation_0;
				}
				[CompilerGenerated]
				set
				{
					this.iconTextRelation_0 = value;
				}
			}

			internal string[] String_0 => this.string_0;

			internal Rectangle?[] Nullable_0 => this.nullable_0;

			internal Rectangle? Nullable_1
			{
				[CompilerGenerated]
				get
				{
					return this.nullable_1;
				}
				[CompilerGenerated]
				set
				{
					this.nullable_1 = value;
				}
			}

			internal Rectangle? Nullable_2
			{
				[CompilerGenerated]
				get
				{
					return this.nullable_2;
				}
				[CompilerGenerated]
				set
				{
					this.nullable_2 = value;
				}
			}

			internal Rectangle? Nullable_3
			{
				[CompilerGenerated]
				get
				{
					return this.nullable_3;
				}
				[CompilerGenerated]
				set
				{
					this.nullable_3 = value;
				}
			}

			internal Rectangle? Nullable_4
			{
				[CompilerGenerated]
				get
				{
					return this.nullable_4;
				}
				[CompilerGenerated]
				set
				{
					this.nullable_4 = value;
				}
			}

			internal Rectangle? Nullable_5
			{
				[CompilerGenerated]
				get
				{
					return this.nullable_5;
				}
				[CompilerGenerated]
				set
				{
					this.nullable_5 = value;
				}
			}

			internal Rectangle? Nullable_6
			{
				[CompilerGenerated]
				get
				{
					return this.nullable_6;
				}
				[CompilerGenerated]
				set
				{
					this.nullable_6 = value;
				}
			}

			internal Rectangle Rectangle_0
			{
				[CompilerGenerated]
				get
				{
					return this.rectangle_0;
				}
				[CompilerGenerated]
				set
				{
					this.rectangle_0 = value;
				}
			}

			internal Rectangle Rectangle_1
			{
				[CompilerGenerated]
				get
				{
					return this.rectangle_1;
				}
				[CompilerGenerated]
				set
				{
					this.rectangle_1 = value;
				}
			}

			internal Rectangle Rectangle_2
			{
				[CompilerGenerated]
				get
				{
					return this.rectangle_2;
				}
				[CompilerGenerated]
				set
				{
					this.rectangle_2 = value;
				}
			}

			internal Size Size_0
			{
				[CompilerGenerated]
				get
				{
					return this.size_0;
				}
				[CompilerGenerated]
				set
				{
					this.size_0 = value;
				}
			}

			internal ButtonStructure(IconTextRelation displayMode)
			{
				this.IconTextRelation_0 = displayMode;
			}
		}

		protected bool m_bButtonEnabled = true;

		protected bool m_bChecked;

		private bool bool_0;

		protected bool m_bDrawLargeIconBorder;

		private bool bool_1;

		protected bool m_bHandleCreated;

		protected bool m_bHasDropDown;

		private bool bool_2 = true;

		protected bool m_bIsInside;

		protected bool m_bIsRibbonDropDownItem;

		protected bool m_bIsRightToLeft;

		private bool bool_3 = true;

		private bool bool_4 = true;

		private bool bool_5;

		private bool bool_6 = true;

		private bool bool_7;

		private int int_0;

		private int int_1;

		private int int_2;

		protected PointF m_pntDpi = PointF.Empty;

		private string string_0 = "";

		private string string_1 = string.Empty;

		protected ButtonStructure m_bsButtonStructure = new ButtonStructure(IconTextRelation.LargeIconLabeled);

		private Color color_0;

		private IconTextRelation iconTextRelation_0 = IconTextRelation.LargeIconLabeled;

		protected System.Drawing.Image m_imgLargeIcon;

		protected System.Drawing.Image m_imgSmallIcon;

		private ImageAttributes imageAttributes_0;

		internal IRibbonItem iribbonItem_0;

		protected Padding m_padArrowMarginsSmallIcon;

		protected Padding m_padArrowMarginsVerticalLargeIcon;

		protected Padding m_padArrowMarginsHorizontalLargeIcon;

		protected Padding m_padImageMarginsLargeIcon;

		protected Padding m_padImageMarginsScmallIcon;

		private Padding padding_0;

		private Padding padding_1;

		private Padding padding_2;

		private Regex regex_0 = new Regex("\\s+");

		protected RibbonGroup m_rgRibbonGroup;

		private RibbonItemCollection ribbonItemCollection_0;

		protected RibbonToolTip m_rttToolTip;

		private Size size_0;

		protected Size m_szArrowBoundsVertical;

		protected Size m_szArrowBoundsHorizontalSmallIcon;

		protected Size m_szArrowBoundsHorizontalLargeIcon;

		protected Size m_szLargeImageSize;

		protected Size m_szSmallImageSize;

		private TextFormatFlags textFormatFlags_0 = TextFormatFlags.NoPrefix | TextFormatFlags.RightToLeft;

		private TextFormatFlags textFormatFlags_1 = TextFormatFlags.NoPrefix;

		private TextFormatFlags textFormatFlags_2 = TextFormatFlags.NoPrefix | TextFormatFlags.RightToLeft | TextFormatFlags.TextBoxControl | TextFormatFlags.WordBreak;

		private TextFormatFlags textFormatFlags_3 = TextFormatFlags.NoPrefix | TextFormatFlags.TextBoxControl | TextFormatFlags.WordBreak;

		protected ToolStripItem m_tsiToolStripItem;

		protected VisualStyleRenderer m_vsrBackgroundRenderer;

		protected VisualStyleRenderer m_vsrToggleRenderer;

		private PropertyChangedEventHandler propertyChangedEventHandler_0;

		[CompilerGenerated]
		private bool bool_8;

		[CompilerGenerated]
		private bool bool_9;

		[CompilerGenerated]
		private bool bool_10;

		[CompilerGenerated]
		private bool bool_11;

		/// <summary>Gets or sets the description text that appears on this button in a RibbonMenuButton's drop down menu when the DisplayMode property of the button is set to IconTextRelation.LargeIconLabeled.</summary>
		[Category("Appearance")]
		[DefaultValue("")]
		public string Description
		{
			get
			{
				return this.string_0;
			}
			set
			{
				if (this.string_0 != (this.string_0 = value))
				{
					this.bool_0 = this.string_0 != null && this.string_0.Length > 0;
					if (this.m_bIsRibbonDropDownItem)
					{
						this.method_6();
					}
					this.vmethod_0("Description");
				}
			}
		}

		/// <summary>Sets the RibbonButton's superordinate display settings and gets its corresponding text icon relation rendering to the current group's width.</summary>
		[DefaultValue(IconTextRelation.LargeIconLabeled)]
		[Category("Appearance")]
		public IconTextRelation DisplayMode
		{
			get
			{
				return this.m_bsButtonStructure.IconTextRelation_0;
			}
			set
			{
				if (this.iconTextRelation_0 != (this.iconTextRelation_0 = value))
				{
					this.vmethod_0("DisplayMode");
				}
				((IScalable)this).SetDisplayMode(value);
			}
		}

		/// <summary>Gets or sets a value indicating whether the RibbonButton can be added to the quick access toolbar.</summary>
		[Category("Behavior")]
		[DefaultValue(true)]
		public bool IsAddToQuickAccessToolbarEnabled
		{
			get
			{
				return this.bool_2;
			}
			set
			{
				if (this.bool_2 != (this.bool_2 = value))
				{
					this.vmethod_0("IsAddToQuickAccessToolbarEnabled");
				}
			}
		}

		/// <summary>Gets or sets value indicating whether the RibbonButton changes its display mode when the related ribbon group is scaled by resizing the application.</summary>
		[Category("Behavior")]
		[DefaultValue(true)]
		public bool IsScalable
		{
			get
			{
				return this.bool_3;
			}
			set
			{
				if (this.bool_3 = (this.bool_3 = value))
				{
					this.m_rgRibbonGroup.method_2();
				}
			}
		}

		/// <summary>Gets or sets a 32x32 1/96 inch icon for this RibbonButton.</summary>
		[DefaultValue(null)]
		[Category("Appearance")]
		public System.Drawing.Image LargeIcon
		{
			get
			{
				return this.m_imgLargeIcon;
			}
			set
			{
				if (this.m_imgLargeIcon != (this.m_imgLargeIcon = value))
				{
					base.Invalidate();
					this.vmethod_0("LargeIcon");
				}
			}
		}

		/// <summary>Gets or sets the keyboard shortcut of the RibbonButton.</summary>
		[Category("Behavior")]
		[Attribute3("PROP_RIBBON_KEYTIP")]
		public string KeyTip
		{
			get
			{
				return this.string_1;
			}
			set
			{
				if (this.string_1 != (this.string_1 = value))
				{
					this.vmethod_0("KeyTip");
				}
			}
		}

		/// <summary>Gets the RibbonItemCollection that contains this RibbonButton.</summary>
		[Category("Behavior")]
		public RibbonItemCollection ParentCollection => this.ribbonItemCollection_0;

		/// <summary>Gets or sets a 16x16 1/96 inch icon for this RibbonButton.</summary>
		[Category("Appearance")]
		[DefaultValue(null)]
		public System.Drawing.Image SmallIcon
		{
			get
			{
				return this.m_imgSmallIcon;
			}
			set
			{
				this.method_3(value, this.m_pntDpi);
			}
		}

		/// <summary>Gets an object of type RibbonToolTip that displays text when the mouse pointer hovers over the item.</summary>
		[Category("Misc")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		public RibbonToolTip ToolTip => this.m_rttToolTip;

		internal string String_0 => base.Name;

		internal bool Boolean_0
		{
			[CompilerGenerated]
			get
			{
				return this.bool_8;
			}
			[CompilerGenerated]
			set
			{
				this.bool_8 = value;
			}
		}

		internal bool Boolean_1
		{
			get
			{
				return this.bool_5;
			}
			set
			{
				this.bool_5 = value;
			}
		}

		public new Color DefaultBackColor => Color.Transparent;

		protected override Padding DefaultMargin => new Padding(0);

		protected override Size DefaultSize => this.size_0;

		public new bool Enabled
		{
			get
			{
				if (this.bool_4)
				{
					return base.Enabled;
				}
				return false;
			}
			set
			{
				base.Enabled = value;
			}
		}

		public new bool Visible
		{
			get
			{
				return base.Visible;
			}
			set
			{
				bool internalVisible = (base.Visible = value);
				((IRibbonItem)this).InternalVisible = internalVisible;
			}
		}

		IRibbonItem IContentItem.Original
		{
			get
			{
				return this.iribbonItem_0;
			}
			set
			{
				this.iribbonItem_0 = value;
			}
		}

		PointF IRibbonItem.DPI => this.m_pntDpi;

		bool IRibbonItem.HasSmallIcon
		{
			[CompilerGenerated]
			get
			{
				return this.bool_9;
			}
			[CompilerGenerated]
			set
			{
				this.bool_9 = value;
			}
		}

		bool IRibbonItem.HasLargeIcon
		{
			[CompilerGenerated]
			get
			{
				return this.bool_10;
			}
			[CompilerGenerated]
			set
			{
				this.bool_10 = value;
			}
		}

		bool IRibbonItem.IsDefaultRibbonTabItem
		{
			[CompilerGenerated]
			get
			{
				return this.bool_11;
			}
			[CompilerGenerated]
			set
			{
				this.bool_11 = value;
			}
		}

		bool IRibbonItem.IsRibbonDropDownItem
		{
			get
			{
				return this.m_bIsRibbonDropDownItem;
			}
			set
			{
				this.m_bIsRibbonDropDownItem = value;
			}
		}

		bool IRibbonItem.IsUpdatingItemEnabled
		{
			get
			{
				return this.bool_7;
			}
			set
			{
				if (this.bool_7 = value)
				{
					this.method_6();
				}
			}
		}

		bool IRibbonItem.OwnerEnabled
		{
			get
			{
				return this.bool_4;
			}
			set
			{
				if (this.bool_4 != (this.bool_4 = value))
				{
					this.UpdateEnableRendering();
				}
			}
		}

		bool IRibbonItem.InternalVisible
		{
			get
			{
				return this.bool_6;
			}
			set
			{
				if (this.bool_6 == (this.bool_6 = value))
				{
					return;
				}
				if (!((IRibbonItem)this).IsRibbonDropDownItem)
				{
					Class517.smethod_25(this.m_rgRibbonGroup);
				}
				if (!(this is RibbonMenuButton) || (this.m_rgRibbonGroup != null && this.m_rgRibbonGroup.Boolean_0))
				{
					return;
				}
				foreach (Control dropDownItem in (this as RibbonMenuButton).DropDownItems)
				{
					RibbonButton ribbonButton = dropDownItem as RibbonButton;
					if (ribbonButton != null)
					{
						((IRibbonItem)ribbonButton).OwnerEnabled = value;
					}
				}
			}
		}

		RibbonGroup IRibbonItem.RibbonGroup
		{
			get
			{
				return this.m_rgRibbonGroup;
			}
			set
			{
				if (this.m_rgRibbonGroup != (this.m_rgRibbonGroup = value) && this.m_rgRibbonGroup != null)
				{
					base.Font = this.m_rgRibbonGroup.Font;
					((IRibbonItem)this).IsUpdatingItemEnabled = true;
				}
			}
		}

		bool IEnabledItem.Enabled
		{
			get
			{
				return this.Enabled;
			}
			set
			{
				this.Enabled = value;
			}
		}

		ToolStripItem IRibbonToolStripItemProvider.ToolStripItem
		{
			get
			{
				if (this.m_tsiToolStripItem == null)
				{
					this.CreateToolStripItem();
				}
				return this.m_tsiToolStripItem;
			}
			set
			{
				this.m_tsiToolStripItem = value;
			}
		}

		bool IRibbonToolStripItemProvider.IsToolStripItemAdded
		{
			get
			{
				bool result = false;
				if (this.m_tsiToolStripItem != null)
				{
					result = (this.m_tsiToolStripItem as IRibbonToolStripItem).IsToolStripItemAdded;
				}
				return result;
			}
		}

		IconTextRelation IScalable.DefaultDisplayMode => this.iconTextRelation_0;

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

		/// <summary>Initializes a new instance of the RibbonButton class.</summary>
		public RibbonButton()
		{
			try
			{
				this.m_vsrBackgroundRenderer = new VisualStyleRenderer(VisualStyleElement.ToolBar.Button.Normal);
				this.m_vsrToggleRenderer = new VisualStyleRenderer(VisualStyleElement.ToolBar.Button.Normal);
			}
			catch
			{
			}
			base.SetStyle(ControlStyles.SupportsTransparentBackColor | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, value: true);
			base.SetStyle(ControlStyles.StandardDoubleClick, value: false);
			base.BackColor = this.DefaultBackColor;
			this.color_0 = this.ForeColor;
			this.m_rttToolTip = new RibbonToolTip(this);
		}

		internal static int smethod_0(Font font_0, PointF pointF_0)
		{
			return Math.Max(TextRenderer.MeasureText("A", font_0, default(Size), TextFormatFlags.NoPrefix).Height + Class517.smethod_51(Class519.Class526.Padding_6, pointF_0).Vertical, Class517.smethod_45(Class519.Class521.Size_1.Height, pointF_0.Y) + Class517.smethod_51(Class519.Class526.Padding_4, pointF_0).Vertical);
		}

		internal int method_0()
		{
			return Math.Max(TextRenderer.MeasureText("A", base.Font, default(Size), TextFormatFlags.NoPrefix).Height + this.padding_1.Vertical, this.m_szSmallImageSize.Height + this.m_padImageMarginsScmallIcon.Vertical);
		}

		protected virtual void CreateToolStripItem()
		{
			this.m_tsiToolStripItem = new Class563(this);
			this.m_tsiToolStripItem.Enabled = this.Enabled;
			Class517.smethod_57(this.m_tsiToolStripItem, this.m_imgSmallIcon, this.m_pntDpi);
			if (this is RibbonToggleButton)
			{
				((Class563)this.m_tsiToolStripItem).method_0();
			}
		}

		protected VisualStyleElement GetCurrentToggleStyle()
		{
			if (this.m_bHandleCreated)
			{
				Point location = base.PointToScreen(this.m_bsButtonStructure.Rectangle_0.Location);
				Rectangle rectangle = new Rectangle(location, this.m_bsButtonStructure.Rectangle_0.Size);
				int num = Control.MousePosition.X;
				int num2 = Control.MousePosition.Y;
				if (rectangle.Contains(new Point(num, num2)))
				{
					return Class517.smethod_14(this.m_bChecked);
				}
				return Class517.smethod_13(this.m_bChecked);
			}
			return Class517.smethod_13(this.m_bChecked);
		}

		private void method_1()
		{
			this.m_bIsInside = true;
			try
			{
				this.m_vsrBackgroundRenderer = ((this.m_rgRibbonGroup != null && !this.m_rgRibbonGroup.Boolean_2) ? new VisualStyleRenderer(Class517.smethod_14(bool_0: false)) : ((!this.m_bHasDropDown || this is RibbonSplitButton) ? new VisualStyleRenderer(Class517.smethod_13(bool_0: false)) : new VisualStyleRenderer(VisualStyleElement.Button.GroupBox.Normal)));
				this.m_vsrToggleRenderer = ((this.m_rgRibbonGroup == null || !this.m_rgRibbonGroup.Boolean_2) ? new VisualStyleRenderer(Class517.smethod_14(this.m_bChecked)) : new VisualStyleRenderer(Class517.smethod_13(this.m_bChecked)));
			}
			catch
			{
			}
			base.Invalidate();
		}

		private void method_2()
		{
			this.m_bIsInside = false;
			try
			{
				this.m_vsrBackgroundRenderer = new VisualStyleRenderer(Class517.smethod_13(bool_0: false));
				this.m_vsrToggleRenderer = new VisualStyleRenderer(Class517.smethod_13(this.m_bChecked));
			}
			catch
			{
			}
			base.Invalidate();
		}

		[Obfuscation(Exclude = true)]
		internal void InvokeOnClick(EventArgs eventArgs_0)
		{
			if (this.m_rgRibbonGroup == null || !this.m_rgRibbonGroup.Boolean_2)
			{
				if (this is RibbonToggleButton)
				{
					((RibbonToggleButton)this).method_19(!((RibbonToggleButton)this).Checked, bool_13: true);
				}
				else if (this is RibbonSplitButton)
				{
					((RibbonSplitButton)this).method_23(!((RibbonSplitButton)this).Checked, bool_17: true, bool_18: true);
				}
				base.OnClick(eventArgs_0);
			}
		}

		internal void method_3(System.Drawing.Image image_0, PointF pointF_0)
		{
			if (this.m_imgSmallIcon != (this.m_imgSmallIcon = image_0))
			{
				if (this.m_tsiToolStripItem != null)
				{
					Class517.smethod_57(this.m_tsiToolStripItem, image_0, pointF_0);
				}
				base.Invalidate();
				this.vmethod_0("SmallIcon");
			}
		}

		protected void UpdateEnableRendering()
		{
			this.int_2 = ((!this.Enabled || !this.m_bButtonEnabled) ? 65 : 0);
			try
			{
				this.m_vsrBackgroundRenderer = ((!this.Enabled || !this.m_bButtonEnabled) ? new VisualStyleRenderer(VisualStyleElement.ToolBar.Button.Disabled) : new VisualStyleRenderer(Class517.smethod_13(bool_0: false)));
			}
			catch
			{
			}
			this.color_0 = (this.Enabled ? this.ForeColor : ControlPaint.LightLight(this.ForeColor));
			this.imageAttributes_0 = Class517.smethod_20(this.int_2);
			if (this.m_tsiToolStripItem != null)
			{
				this.m_tsiToolStripItem.Enabled = this.Enabled;
			}
			if (this.m_bHasDropDown)
			{
				foreach (Control dropDownItem in (this as RibbonMenuButton).DropDownItems)
				{
					(dropDownItem as IRibbonItem).OwnerEnabled = this.Enabled;
				}
			}
			if (!this.Enabled)
			{
				this.m_rttToolTip.method_2();
			}
		}

		internal void method_4(Color? nullable_0, PointF pointF_0)
		{
			if (this.m_imgLargeIcon != null)
			{
				bool flag = !nullable_0.HasValue || nullable_0.Value.A == 0 || (nullable_0.Value.R == byte.MaxValue && nullable_0.Value.G == byte.MaxValue && nullable_0.Value.B == byte.MaxValue);
				ImageProvider.ImageSetting imageSetting = new ImageProvider.ImageSetting();
				imageSetting.Fill = (flag ? Color.White : Color.FromArgb(255, nullable_0.Value));
				imageSetting.Stroke = Color.Gray;
				this.m_imgLargeIcon = Class517.smethod_56(this.String_0, ImageProvider.ImageKind.Large_32x32, imageSetting, pointF_0);
				base.Invalidate();
				this.vmethod_0("LargeIcon");
			}
		}

		internal void method_5(Color? nullable_0, PointF pointF_0)
		{
			if (this.m_imgSmallIcon != null)
			{
				bool flag = !nullable_0.HasValue || nullable_0.Value.A == 0 || (nullable_0.Value.R == byte.MaxValue && nullable_0.Value.G == byte.MaxValue && nullable_0.Value.B == byte.MaxValue);
				ImageProvider.ImageSetting imageSetting = new ImageProvider.ImageSetting();
				imageSetting.Fill = (flag ? Color.White : Color.FromArgb(255, nullable_0.Value));
				imageSetting.Stroke = Color.Gray;
				this.m_imgSmallIcon = Class517.smethod_56(this.String_0, ImageProvider.ImageKind.Small_16x16, imageSetting, pointF_0);
				if (this.m_tsiToolStripItem != null)
				{
					Class517.smethod_57(this.m_tsiToolStripItem, this.m_imgSmallIcon, this.m_pntDpi);
				}
				base.Invalidate();
				this.vmethod_0("SmallIcon");
			}
		}

		protected override AccessibleObject CreateAccessibilityInstance()
		{
			return new Control13(this);
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				((IContentItem)this).ToolTip.Dispose();
				if (this.m_imgLargeIcon != null)
				{
					this.m_imgLargeIcon.Dispose();
				}
				if (this.m_imgSmallIcon != null)
				{
					this.m_imgSmallIcon.Dispose();
				}
				if (this.m_tsiToolStripItem != null)
				{
					this.m_tsiToolStripItem.Dispose();
				}
			}
			base.Dispose(disposing);
		}

		protected override bool IsInputKey(Keys keyData)
		{
			if (keyData == Keys.Escape)
			{
				return true;
			}
			return base.IsInputKey(keyData);
		}

		protected override void OnBackColorChanged(EventArgs eventArgs_0)
		{
			this.vmethod_0("BackColor");
			base.OnBackColorChanged(eventArgs_0);
		}

		protected override void OnClick(EventArgs eventArgs_0)
		{
			if (this.Enabled)
			{
				if (!(this is RibbonMenuButton))
				{
					Class517.smethod_28(this);
				}
				if (this.iribbonItem_0 != null)
				{
					(this.iribbonItem_0 as RibbonButton).Tag = base.Tag;
					(this.iribbonItem_0 as RibbonButton).OnClick(new EventArgs());
				}
				else if (this.m_rgRibbonGroup == null || !this.m_rgRibbonGroup.Boolean_2)
				{
					base.OnClick(eventArgs_0);
				}
			}
		}

		protected override void OnEnabledChanged(EventArgs eventArgs_0)
		{
			this.UpdateEnableRendering();
			this.vmethod_0("Enabled");
			base.OnEnabledChanged(eventArgs_0);
		}

		protected override void OnFontChanged(EventArgs eventArgs_0)
		{
			if (this.m_bHasDropDown)
			{
				foreach (Control dropDownItem in (this as RibbonMenuButton).DropDownItems)
				{
					dropDownItem.Font = base.Font;
				}
			}
			this.m_rttToolTip.Font_0 = base.Font;
			this.vmethod_0("Font");
			base.OnFontChanged(eventArgs_0);
		}

		protected override void OnForeColorChanged(EventArgs eventArgs_0)
		{
			this.color_0 = (this.Enabled ? base.ForeColor : ControlPaint.LightLight(base.ForeColor));
			this.vmethod_0("ForeColor");
			base.OnForeColorChanged(eventArgs_0);
		}

		protected override void OnGotFocus(EventArgs eventArgs_0)
		{
			this.method_1();
			base.OnGotFocus(eventArgs_0);
		}

		protected override void OnKeyDown(KeyEventArgs keyEventArgs_0)
		{
			switch (keyEventArgs_0.KeyCode)
			{
			case Keys.Escape:
			{
				Control control = this;
				while (control != null && !(control is Ribbon) && !(control is RibbonDropDown))
				{
					control = control.Parent;
				}
				if (control != null)
				{
					if (control is Ribbon)
					{
						((Ribbon)control).method_10();
					}
					if (control is RibbonDropDown)
					{
						((RibbonDropDown)control).Close();
					}
				}
				break;
			}
			case Keys.Return:
			case Keys.Space:
				this.OnClick(EventArgs.Empty);
				break;
			}
			base.OnKeyDown(keyEventArgs_0);
		}

		protected override void OnLostFocus(EventArgs eventArgs_0)
		{
			this.method_2();
			base.OnLostFocus(eventArgs_0);
		}

		protected override void OnHandleCreated(EventArgs eventArgs_0)
		{
			base.OnHandleCreated(eventArgs_0);
			this.m_bHandleCreated = true;
			if (this.Visible && this.ContextMenuStrip == null && this.m_rgRibbonGroup != null)
			{
				RibbonTab ribbonTab = this.m_rgRibbonGroup.Class498_0.Control_0 as RibbonTab;
				if (ribbonTab != null)
				{
					this.ContextMenuStrip = ribbonTab.ContextMenuStrip_0;
				}
			}
		}

		protected override void OnMouseDown(MouseEventArgs mevent)
		{
			this.m_rttToolTip.method_2();
			base.OnMouseDown(mevent);
		}

		protected override void OnMouseEnter(EventArgs eventargs)
		{
			this.method_1();
			Point? nullable_ = Class517.smethod_21(this);
			this.m_rttToolTip.method_3(nullable_, base.Width, this.m_rttToolTip.Control_0, this.m_pntDpi);
			base.OnMouseEnter(eventargs);
		}

		protected override void OnMouseLeave(EventArgs eventargs)
		{
			this.method_2();
			this.m_rttToolTip.method_2();
			base.OnMouseLeave(eventargs);
		}

		protected override void OnMouseUp(MouseEventArgs mevent)
		{
			if (this.m_rgRibbonGroup == null || !this.m_rgRibbonGroup.Boolean_2)
			{
				base.OnMouseUp(mevent);
			}
		}

		protected override void OnPaint(PaintEventArgs pea)
		{
			pea.Graphics.FillRectangle(new SolidBrush(this.BackColor), pea.ClipRectangle);
			this.method_13(pea.Graphics);
			base.OnPaint(pea);
		}

		protected override void OnRightToLeftChanged(EventArgs eventArgs_0)
		{
			this.method_7(this.m_bsButtonStructure, bool_12: false);
			if (this is RibbonMenuButton)
			{
				foreach (Control dropDownItem in (this as RibbonMenuButton).DropDownItems)
				{
					dropDownItem.RightToLeft = (this.m_bIsRightToLeft ? RightToLeft.Yes : RightToLeft.No);
				}
			}
			base.OnRightToLeftChanged(eventArgs_0);
		}

		protected override void OnSizeChanged(EventArgs eventArgs_0)
		{
			if (this.m_bIsRibbonDropDownItem)
			{
				this.int_1 = base.Width;
				this.method_7(this.m_bsButtonStructure, bool_12: false);
			}
			base.OnSizeChanged(eventArgs_0);
		}

		protected override void OnTextChanged(EventArgs eventArgs_0)
		{
			this.bool_1 = base.Text != null && base.Text.Length > 0;
			if (this.m_tsiToolStripItem != null)
			{
				this.m_tsiToolStripItem.Text = base.Text;
			}
			this.method_6();
			this.vmethod_0("Text");
			base.OnTextChanged(eventArgs_0);
		}

		protected override void WndProc(ref Message message)
		{
			Class429.Enum121 msg = (Class429.Enum121)message.Msg;
			if (msg != Class429.Enum121.const_56)
			{
				base.WndProc(ref message);
			}
		}

		void IRibbonItem.AwareOfDPI(PointF dpi)
		{
			if (dpi.X == this.m_pntDpi.X && dpi.Y == this.m_pntDpi.Y)
			{
				return;
			}
			this.m_pntDpi = dpi;
			this.m_padArrowMarginsSmallIcon = Class517.smethod_51(Class519.Class526.Padding_0, dpi);
			this.m_padArrowMarginsVerticalLargeIcon = Class517.smethod_51(Class519.Class526.Padding_1, dpi);
			this.m_padArrowMarginsHorizontalLargeIcon = Class517.smethod_51(Class519.Class526.Padding_2, dpi);
			this.m_padImageMarginsLargeIcon = Class517.smethod_51(Class519.Class526.Padding_3, dpi);
			this.m_padImageMarginsScmallIcon = Class517.smethod_51(Class519.Class526.Padding_4, dpi);
			this.padding_0 = Class517.smethod_51(Class519.Class526.Padding_5, dpi);
			this.padding_1 = Class517.smethod_51(Class519.Class526.Padding_6, dpi);
			this.padding_2 = Class517.smethod_51(Class519.Class526.Padding_7, dpi);
			this.size_0 = Class517.smethod_48(Class519.Class526.Size_0, dpi);
			this.m_szArrowBoundsVertical = Class517.smethod_48(Class519.Class526.Size_1, dpi);
			this.m_szArrowBoundsHorizontalSmallIcon = Class517.smethod_48(Class519.Class526.Size_2, dpi);
			this.m_szArrowBoundsHorizontalLargeIcon = Class517.smethod_48(Class519.Class526.Size_3, dpi);
			this.m_szLargeImageSize = Class517.smethod_48(Class519.Class521.Size_0, dpi);
			this.m_szSmallImageSize = Class517.smethod_48(Class519.Class521.Size_1, dpi);
			this.int_0 = this.method_0();
			base.Margin = Class517.smethod_51(Class519.Class523.Padding_3, dpi);
			this.int_1 = 0;
			this.method_7(this.m_bsButtonStructure, bool_12: false);
			base.Size = this.m_bsButtonStructure.Size_0;
			if (!(this is RibbonMenuButton))
			{
				return;
			}
			if ((this as RibbonMenuButton).ribbonDropDown_0 != null)
			{
				(this as RibbonMenuButton).ribbonDropDown_0.Items.Clear();
			}
			(this as RibbonMenuButton).ribbonDropDown_0 = null;
			foreach (IRibbonItem dropDownItem in (this as RibbonMenuButton).DropDownItems)
			{
				dropDownItem.AwareOfDPI(dpi);
			}
		}

		SizeF IRibbonItem.GetSize(IconTextRelation scaleMode)
		{
			ButtonStructure buttonStructure = new ButtonStructure(scaleMode);
			this.method_7(buttonStructure, bool_12: true);
			return new SizeF(buttonStructure.Size_0.Width, buttonStructure.Size_0.Height);
		}

		void IRibbonItem.ParentVisibleChanged(bool isVisible)
		{
		}

		void IRibbonItem.PerformStandardKeyboardAction()
		{
			this.OnClick(EventArgs.Empty);
		}

		void IRibbonItem.SetDropDownItemSize()
		{
			DockStyle dock = base.Dock;
			base.Dock = DockStyle.None;
			base.Size = ((IRibbonItem)this).GetSize(this.m_bsButtonStructure.IconTextRelation_0).ToSize();
			base.Dock = dock;
		}

		void IRibbonItem.SetParentCollection(RibbonItemCollection parentCollection)
		{
			this.ribbonItemCollection_0 = parentCollection;
		}

		void IScalable.SetDisplayMode(IconTextRelation value)
		{
			this.m_bsButtonStructure.IconTextRelation_0 = value;
			if (!this.m_pntDpi.IsEmpty)
			{
				this.method_7(this.m_bsButtonStructure, bool_12: false);
				base.Size = this.m_bsButtonStructure.Size_0;
				base.Invalidate();
			}
		}

		internal virtual void vmethod_0(string string_2)
		{
			this.propertyChangedEventHandler_0?.Invoke(this, new PropertyChangedEventArgs(string_2));
		}

		internal void method_6()
		{
			if (this.bool_7 && !this.m_pntDpi.IsEmpty)
			{
				this.method_7(this.m_bsButtonStructure, bool_12: false);
				base.Size = this.m_bsButtonStructure.Size_0;
				if (!this.m_bIsRibbonDropDownItem && this.m_rgRibbonGroup != null && this.iribbonItem_0 == null)
				{
					this.m_rgRibbonGroup.method_2();
				}
			}
		}

		private void method_7(ButtonStructure buttonStructure_0, bool bool_12)
		{
			if (!this.m_pntDpi.IsEmpty)
			{
				this.m_bIsRightToLeft = (this.m_rgRibbonGroup != null && this.m_rgRibbonGroup.RightToLeft == RightToLeft.Yes) || this.RightToLeft == RightToLeft.Yes;
				switch (buttonStructure_0.IconTextRelation_0)
				{
				case IconTextRelation.LargeIconLabeled:
					this.method_8(buttonStructure_0, bool_12);
					break;
				case IconTextRelation.NoIconLabeled:
					this.method_12(buttonStructure_0, bool_12);
					break;
				case IconTextRelation.SmallIconUnlabeled:
					this.method_11(buttonStructure_0, bool_12);
					break;
				case IconTextRelation.SmallIconLabeled:
					this.method_10(buttonStructure_0, bool_12);
					break;
				}
				if (!bool_12)
				{
					this.UpdateBackgroundBounds(buttonStructure_0);
				}
			}
		}

		private void method_8(ButtonStructure buttonStructure_0, bool bool_12)
		{
			int num = 1;
			int num2 = 1;
			int num3 = 0;
			int num4 = 0;
			if (this.m_bIsRibbonDropDownItem)
			{
				Size size = default(Size);
				if (this.bool_1)
				{
					Font font = (this.bool_0 ? new Font(this.Font, FontStyle.Bold) : this.Font);
					size = TextRenderer.MeasureText(base.Text, font, default(Size), TextFormatFlags.NoPrefix);
				}
				Size size2 = default(Size);
				if (this.bool_0)
				{
					size2 = this.method_9(this.string_0, base.Font, bool_12: true, buttonStructure_0);
				}
				num = this.m_szLargeImageSize.Width + this.m_padImageMarginsLargeIcon.Horizontal + Math.Max(size.Width, size2.Width) + this.padding_0.Horizontal;
				if (this.m_bHasDropDown)
				{
					num += this.m_padArrowMarginsHorizontalLargeIcon.Horizontal + this.m_szArrowBoundsHorizontalLargeIcon.Width;
				}
				num = Math.Max(this.int_1, num);
				if (!bool_12)
				{
					int num5 = (this.bool_0 ? this.padding_2.Vertical : this.padding_0.Vertical);
					num2 = Math.Max(this.m_padImageMarginsLargeIcon.Top + size.Height + size2.Height + num5, this.m_szLargeImageSize.Height + this.m_padImageMarginsLargeIcon.Vertical);
					int num6 = (this.m_bIsRightToLeft ? (num - this.m_szLargeImageSize.Width - this.m_padImageMarginsLargeIcon.Horizontal - this.padding_0.Right - size.Width) : (this.m_szLargeImageSize.Width + this.m_padImageMarginsLargeIcon.Horizontal));
					if (this.bool_1)
					{
						int num7 = (this.bool_0 ? this.m_padImageMarginsLargeIcon.Top : (num2 / 2 - size.Height / 2));
						ref Rectangle? reference = ref buttonStructure_0.Nullable_0[0];
						reference = new Rectangle(num6, num7, size.Width, size.Height);
						buttonStructure_0.Nullable_0[1] = null;
					}
					else
					{
						buttonStructure_0.Nullable_0[0] = null;
						buttonStructure_0.Nullable_0[1] = null;
					}
					if (this.bool_0)
					{
						int num8 = (this.m_bIsRightToLeft ? (num - this.m_szLargeImageSize.Width - this.m_padImageMarginsLargeIcon.Horizontal - this.padding_0.Right - size2.Width) : num6);
						int num9 = (this.bool_1 ? (this.m_padImageMarginsLargeIcon.Top + size.Height + this.padding_0.Top) : (num2 / 2 - size2.Height / 2));
						buttonStructure_0.Nullable_1 = new Rectangle(num8, num9, size2.Width, size2.Height);
					}
					else
					{
						buttonStructure_0.Nullable_1 = null;
					}
					num3 = (this.m_bIsRightToLeft ? (num - this.m_padImageMarginsLargeIcon.Right - this.m_szLargeImageSize.Width) : this.m_padImageMarginsLargeIcon.Left);
					num4 = (num2 - this.m_szLargeImageSize.Height) / 2;
				}
			}
			else
			{
				Size size3 = this.method_9(base.Text, base.Font, bool_12: false, buttonStructure_0);
				num = (this.m_bIsRibbonDropDownItem ? this.int_1 : Math.Max(size3.Width + this.padding_0.Horizontal, this.m_szLargeImageSize.Width + this.m_padImageMarginsLargeIcon.Horizontal));
				num2 = this.int_0 * 3;
				if (!bool_12)
				{
					int num10 = (num - size3.Width) / 2;
					int num11 = this.m_szLargeImageSize.Height + this.m_padImageMarginsLargeIcon.Top + this.padding_0.Top + buttonStructure_0.Nullable_0[0].Value.Y;
					ref Rectangle? reference2 = ref buttonStructure_0.Nullable_0[0];
					reference2 = new Rectangle(num10 + buttonStructure_0.Nullable_0[0].Value.X, num11, buttonStructure_0.Nullable_0[0].Value.Width, buttonStructure_0.Nullable_0[0].Value.Height);
					if (buttonStructure_0.String_0[1].Length > 0)
					{
						ref Rectangle? reference3 = ref buttonStructure_0.Nullable_0[1];
						reference3 = new Rectangle(num10 + buttonStructure_0.Nullable_0[1].Value.X, num11 + buttonStructure_0.Nullable_0[1].Value.Y, buttonStructure_0.Nullable_0[1].Value.Width, buttonStructure_0.Nullable_0[1].Value.Height);
					}
					else
					{
						buttonStructure_0.Nullable_0[1] = null;
					}
					if (this.m_bHasDropDown)
					{
						buttonStructure_0.Nullable_3 = new Rectangle(buttonStructure_0.Nullable_3.Value.X + num10, buttonStructure_0.Nullable_3.Value.Y + num11, this.m_szArrowBoundsVertical.Width, this.m_szArrowBoundsVertical.Height);
					}
					num3 = num / 2 - this.m_szLargeImageSize.Width / 2;
					num4 = this.m_padImageMarginsLargeIcon.Top;
				}
			}
			if (!bool_12)
			{
				buttonStructure_0.Nullable_2 = new Rectangle(num3, num4, this.m_szLargeImageSize.Width, this.m_szLargeImageSize.Height);
			}
			buttonStructure_0.Size_0 = new Size(num, num2);
		}

		private Size method_9(string string_2, Font font_0, bool bool_12, ButtonStructure buttonStructure_0)
		{
			Size size = TextRenderer.MeasureText(string_2, font_0, default(Size), TextFormatFlags.NoPrefix);
			Size size2 = size;
			Size size3 = default(Size);
			float num = float.MaxValue;
			int length = string_2.Length;
			int startIndex = string_2.Length;
			if (!bool_12 || !this.bool_5)
			{
				MatchCollection matchCollection = this.regex_0.Matches(string_2);
				for (int i = 0; i < matchCollection.Count; i++)
				{
					Match match = matchCollection[i];
					Size size4 = TextRenderer.MeasureText(string_2.Substring(0, match.Index), font_0, default(Size), TextFormatFlags.NoPrefix);
					Size size5 = TextRenderer.MeasureText(string_2.Substring(match.Index + match.Length), font_0, default(Size), TextFormatFlags.NoPrefix);
					float num2 = Math.Abs(size4.Width - size5.Width);
					if (num2 < num)
					{
						size2 = size4;
						size3 = size5;
						num = num2;
						length = match.Index;
						startIndex = match.Index + match.Length;
					}
				}
			}
			buttonStructure_0.String_0[0] = string_2.Substring(0, length);
			buttonStructure_0.String_0[1] = string_2.Substring(startIndex);
			int num3 = ((!this.m_bHasDropDown || this.m_bIsRibbonDropDownItem) ? Math.Max(size2.Width, size3.Width) : Math.Max(size2.Width, size3.Width + this.m_szArrowBoundsVertical.Width + this.m_padArrowMarginsVerticalLargeIcon.Horizontal));
			int num4 = num3 / 2 - size2.Width / 2;
			ref Rectangle? reference = ref buttonStructure_0.Nullable_0[0];
			reference = new Rectangle(num4, 0, size2.Width, size2.Height);
			int num5 = TextRenderer.MeasureText("X X", font_0).Width;
			int num6 = ((!bool_12 || !this.bool_5) ? TextRenderer.MeasureText("X X", font_0, new Size(num5 - Class517.smethod_45(1, this.m_pntDpi.X), 0), TextFormatFlags.EndEllipsis | TextFormatFlags.WordBreak).Height : TextRenderer.MeasureText("X", font_0, new Size(num5 - Class517.smethod_45(1, this.m_pntDpi.X), 0)).Height);
			if (buttonStructure_0.String_0[1].Length == 0)
			{
				ref Rectangle? reference2 = ref buttonStructure_0.Nullable_0[1];
				reference2 = default(Rectangle);
				if (this.m_bHasDropDown && !this.m_bIsRibbonDropDownItem)
				{
					buttonStructure_0.Nullable_3 = new Rectangle(num3 / 2 - this.m_szArrowBoundsVertical.Width / 2, size.Height + size.Height / 2 - this.m_szArrowBoundsVertical.Height / 2 + this.m_padArrowMarginsVerticalLargeIcon.Top, this.m_szArrowBoundsVertical.Width, this.m_szArrowBoundsVertical.Height);
				}
			}
			else
			{
				int num7 = num3 / 2 - size3.Width / 2;
				int num8 = num6 - size3.Height;
				if (this.m_bHasDropDown && !this.m_bIsRibbonDropDownItem)
				{
					num7 -= (this.m_szArrowBoundsVertical.Width + this.m_padArrowMarginsVerticalLargeIcon.Horizontal) / 2;
					buttonStructure_0.Nullable_3 = new Rectangle(num7 + size3.Width + this.m_padArrowMarginsVerticalLargeIcon.Left, size.Height + size.Height / 2 - this.m_szArrowBoundsVertical.Height / 2 + this.m_padArrowMarginsVerticalLargeIcon.Top, this.m_szArrowBoundsVertical.Width, this.m_szArrowBoundsVertical.Height);
				}
				ref Rectangle? reference3 = ref buttonStructure_0.Nullable_0[1];
				reference3 = new Rectangle(num7, num8, size3.Width, size3.Height);
			}
			return new Size(num3, num6);
		}

		private void method_10(ButtonStructure buttonStructure_0, bool bool_12)
		{
			int num = 1;
			int num2 = 1;
			Size size = TextRenderer.MeasureText(base.Text, base.Font, default(Size), TextFormatFlags.NoPrefix);
			num2 = this.int_0;
			num = this.m_szSmallImageSize.Width + this.m_padImageMarginsScmallIcon.Horizontal + size.Width + this.padding_1.Horizontal;
			if (this.m_bHasDropDown)
			{
				num += (this.m_bIsRibbonDropDownItem ? (this.m_szArrowBoundsHorizontalSmallIcon.Width + this.m_padArrowMarginsSmallIcon.Horizontal) : (this.m_szArrowBoundsVertical.Width + this.m_padArrowMarginsSmallIcon.Horizontal + Class517.smethod_45(2, this.m_pntDpi.X)));
			}
			if (this.m_bIsRibbonDropDownItem)
			{
				num = Math.Max(this.int_1, num);
			}
			if (!bool_12)
			{
				int num3 = (this.m_bIsRightToLeft ? (num - size.Width - this.m_szSmallImageSize.Width - this.m_padImageMarginsScmallIcon.Horizontal - this.padding_1.Right) : (this.m_szSmallImageSize.Width + this.m_padImageMarginsScmallIcon.Horizontal + this.padding_1.Left));
				int num4 = num2 / 2 - size.Height / 2;
				ref Rectangle? reference = ref buttonStructure_0.Nullable_0[0];
				reference = new Rectangle(num3, num4, size.Width, size.Height);
				buttonStructure_0.Nullable_0[1] = null;
				int num5 = (this.m_bIsRightToLeft ? (num - this.m_szSmallImageSize.Width - this.m_padImageMarginsScmallIcon.Right) : this.m_padImageMarginsScmallIcon.Left);
				int num6 = num2 / 2 - this.m_szSmallImageSize.Height / 2;
				buttonStructure_0.Nullable_2 = new Rectangle(num5, num6, this.m_szSmallImageSize.Width, this.m_szSmallImageSize.Height);
			}
			buttonStructure_0.Size_0 = new Size(num, num2);
		}

		private void method_11(ButtonStructure buttonStructure_0, bool bool_12)
		{
			int num = 1;
			int num2 = 1;
			num2 = this.int_0;
			num = this.m_szSmallImageSize.Width + this.m_padImageMarginsScmallIcon.Horizontal;
			buttonStructure_0.Nullable_0[0] = null;
			buttonStructure_0.Nullable_0[1] = null;
			if (this.m_bHasDropDown && !this.m_bIsRibbonDropDownItem)
			{
				num += (this.m_bIsRibbonDropDownItem ? (this.m_padArrowMarginsSmallIcon.Horizontal + this.m_szArrowBoundsHorizontalSmallIcon.Width + this.padding_1.Horizontal - 2) : (this.m_padArrowMarginsSmallIcon.Horizontal + this.m_szArrowBoundsVertical.Width + this.padding_1.Horizontal - Class517.smethod_45(1, this.m_pntDpi.X)));
			}
			if (this.m_bIsRibbonDropDownItem)
			{
				num = Math.Max(this.int_1, num);
			}
			if (!bool_12)
			{
				int num3 = (this.m_bIsRightToLeft ? (num - this.m_szSmallImageSize.Width - this.m_padImageMarginsScmallIcon.Right) : this.m_padImageMarginsScmallIcon.Left);
				int num4 = num2 / 2 - this.m_szSmallImageSize.Height / 2;
				buttonStructure_0.Nullable_2 = new Rectangle(num3, num4, this.m_szSmallImageSize.Width, this.m_szSmallImageSize.Height);
			}
			buttonStructure_0.Size_0 = new Size(num, num2);
		}

		private void method_12(ButtonStructure buttonStructure_0, bool bool_12)
		{
			int num = 1;
			int num2 = 1;
			Size size = TextRenderer.MeasureText(base.Text, base.Font, default(Size), TextFormatFlags.NoPrefix);
			num2 = this.int_0;
			num = size.Width + this.padding_1.Horizontal;
			if (this.m_bHasDropDown)
			{
				num += (this.m_bIsRibbonDropDownItem ? (this.m_szArrowBoundsHorizontalSmallIcon.Width + this.m_padArrowMarginsSmallIcon.Horizontal + Class517.smethod_45(2, this.m_pntDpi.X)) : (this.m_szArrowBoundsVertical.Width + this.m_padArrowMarginsSmallIcon.Horizontal + Class517.smethod_45(2, this.m_pntDpi.X)));
			}
			if (this.m_bIsRibbonDropDownItem)
			{
				num = Math.Max(this.int_1, num);
			}
			if (!bool_12)
			{
				int num3 = (this.m_bIsRightToLeft ? (num - size.Width - this.padding_1.Right) : this.padding_1.Left);
				int num4 = num2 / 2 - size.Height / 2;
				ref Rectangle? reference = ref buttonStructure_0.Nullable_0[0];
				reference = new Rectangle(num3, num4, size.Width, size.Height);
				buttonStructure_0.Nullable_0[1] = null;
			}
			buttonStructure_0.Size_0 = new Size(num, num2);
		}

		protected virtual void UpdateBackgroundBounds(ButtonStructure buttonStructure)
		{
			buttonStructure.Rectangle_0 = new Rectangle(0, 0, buttonStructure.Size_0.Width, buttonStructure.Size_0.Height);
			if (this is RibbonToggleButton)
			{
				if (buttonStructure.IconTextRelation_0 == IconTextRelation.SmallIconLabeled)
				{
					buttonStructure.Rectangle_1 = (this.m_bIsRightToLeft ? new Rectangle(buttonStructure.Size_0.Width - this.m_padImageMarginsScmallIcon.Horizontal - this.m_szSmallImageSize.Width, 0, this.m_padImageMarginsScmallIcon.Horizontal + this.m_szSmallImageSize.Width, buttonStructure.Size_0.Height) : new Rectangle(0, 0, this.m_padImageMarginsScmallIcon.Horizontal + this.m_szSmallImageSize.Width, buttonStructure.Size_0.Height));
				}
				else
				{
					buttonStructure.Rectangle_1 = new Rectangle(0, 0, buttonStructure.Size_0.Width, buttonStructure.Size_0.Height);
				}
			}
			if (!(this is RibbonMenuButton))
			{
				return;
			}
			if (this.m_bIsRibbonDropDownItem)
			{
				if (this.m_bsButtonStructure.IconTextRelation_0 == IconTextRelation.LargeIconLabeled)
				{
					this.m_bsButtonStructure.Nullable_5 = (this.m_bIsRightToLeft ? new Rectangle(this.m_padArrowMarginsHorizontalLargeIcon.Left + Class517.smethod_45(2, this.m_pntDpi.X), buttonStructure.Size_0.Height / 2 - this.m_szArrowBoundsHorizontalLargeIcon.Height / 2 - Class517.smethod_45(1, this.m_pntDpi.Y), this.m_szArrowBoundsHorizontalLargeIcon.Width, this.m_szArrowBoundsHorizontalLargeIcon.Height) : new Rectangle(buttonStructure.Size_0.Width - this.m_padArrowMarginsHorizontalLargeIcon.Right - this.m_szArrowBoundsHorizontalLargeIcon.Width - Class517.smethod_45(1, this.m_pntDpi.X), buttonStructure.Size_0.Height / 2 - this.m_szArrowBoundsHorizontalLargeIcon.Height / 2 - Class517.smethod_45(1, this.m_pntDpi.Y), this.m_szArrowBoundsHorizontalLargeIcon.Width, this.m_szArrowBoundsHorizontalLargeIcon.Height));
					return;
				}
				_ = buttonStructure.Size_0.Width;
				_ = this.m_szArrowBoundsVertical.Width;
				_ = this.m_padArrowMarginsSmallIcon.Horizontal;
				Class517.smethod_45(4, this.m_pntDpi.X);
				this.m_bsButtonStructure.Nullable_6 = (this.m_bIsRightToLeft ? new Rectangle(this.m_padArrowMarginsSmallIcon.Left, buttonStructure.Size_0.Height / 2 - this.m_szArrowBoundsHorizontalSmallIcon.Height / 2 - Class517.smethod_45(1, this.m_pntDpi.Y), this.m_szArrowBoundsHorizontalSmallIcon.Width, this.m_szArrowBoundsHorizontalSmallIcon.Height) : new Rectangle(buttonStructure.Size_0.Width - this.m_padArrowMarginsSmallIcon.Right - this.m_szArrowBoundsHorizontalSmallIcon.Width - 1, buttonStructure.Size_0.Height / 2 - this.m_szArrowBoundsHorizontalSmallIcon.Height / 2 - 1, this.m_szArrowBoundsHorizontalSmallIcon.Width, this.m_szArrowBoundsHorizontalSmallIcon.Height));
			}
			else
			{
				this.m_bsButtonStructure.Nullable_4 = (this.m_bIsRightToLeft ? new Rectangle(this.m_padArrowMarginsSmallIcon.Left + Class517.smethod_45(2, this.m_pntDpi.X), buttonStructure.Size_0.Height / 2 - this.m_szArrowBoundsVertical.Height / 2, this.m_szArrowBoundsVertical.Width, this.m_szArrowBoundsVertical.Height) : new Rectangle(buttonStructure.Size_0.Width - this.m_padArrowMarginsSmallIcon.Right - this.m_szArrowBoundsVertical.Width - Class517.smethod_45(2, this.m_pntDpi.X), buttonStructure.Size_0.Height / 2 - this.m_szArrowBoundsVertical.Height / 2, this.m_szArrowBoundsVertical.Width, this.m_szArrowBoundsVertical.Height));
			}
		}

		private void method_13(Graphics graphics_0)
		{
			this.PaintBackground(graphics_0);
			this.method_14(graphics_0);
		}

		protected virtual void PaintBackground(Graphics graphics_0)
		{
			if (this.m_vsrBackgroundRenderer != null)
			{
				this.m_vsrBackgroundRenderer.DrawBackground(graphics_0, this.m_bsButtonStructure.Rectangle_0);
			}
		}

		private void method_14(Graphics graphics_0)
		{
			switch (this.m_bsButtonStructure.IconTextRelation_0)
			{
			case IconTextRelation.LargeIconLabeled:
				if (this.m_imgLargeIcon != null)
				{
					this.method_15(graphics_0);
				}
				this.method_16(graphics_0, base.Text);
				break;
			case IconTextRelation.NoIconLabeled:
				this.method_17(graphics_0, this.Text);
				break;
			case IconTextRelation.SmallIconUnlabeled:
				if (this.m_imgSmallIcon != null || this.m_bChecked)
				{
					this.PaintSmallImage(graphics_0);
				}
				if (this.m_bHasDropDown)
				{
					if (this.m_bIsRibbonDropDownItem)
					{
						Class517.smethod_17(graphics_0, this.m_bsButtonStructure.Nullable_6.Value, this.color_0, (!this.m_bIsRightToLeft) ? ArrowDirection.Right : ArrowDirection.Left, this.m_pntDpi);
					}
					else
					{
						Class517.smethod_17(graphics_0, this.m_bsButtonStructure.Nullable_4.Value, this.color_0, ArrowDirection.Down, this.m_pntDpi);
					}
				}
				break;
			case IconTextRelation.SmallIconLabeled:
				if (this.m_imgSmallIcon != null || this.m_bChecked)
				{
					this.PaintSmallImage(graphics_0);
				}
				this.method_17(graphics_0, this.Text);
				break;
			}
		}

		private void method_15(Graphics graphics_0)
		{
			Rectangle destRect = this.m_bsButtonStructure.Nullable_2.Value;
			if (this.m_bDrawLargeIconBorder && this.m_imgLargeIcon.Width < this.m_bsButtonStructure.Nullable_2.Value.Width)
			{
				int num = destRect.Width / 2 - this.m_imgLargeIcon.Width / 2 + destRect.X;
				int num2 = destRect.Height / 2 - this.m_imgLargeIcon.Height / 2 + destRect.Y;
				destRect = new Rectangle(new Point(num, num2), this.m_imgLargeIcon.Size);
			}
			graphics_0.DrawImage(this.m_imgLargeIcon, destRect, 0, 0, this.m_imgLargeIcon.Width, this.m_imgLargeIcon.Height, GraphicsUnit.Pixel, this.imageAttributes_0);
			if (this.m_bDrawLargeIconBorder)
			{
				graphics_0.DrawRectangle(new Pen(new SolidBrush(Color.LightGray), Class517.smethod_45(1, this.m_pntDpi.X)), this.m_bsButtonStructure.Nullable_2.Value);
			}
		}

		private void method_16(Graphics graphics_0, string string_2)
		{
			if (this.m_bIsRibbonDropDownItem)
			{
				if (this.bool_1)
				{
					Font font = (this.bool_0 ? new Font(this.Font, FontStyle.Bold) : this.Font);
					TextRenderer.DrawText(graphics_0, string_2, font, this.m_bsButtonStructure.Nullable_0[0].Value, this.color_0, this.m_bIsRightToLeft ? this.textFormatFlags_0 : this.textFormatFlags_1);
				}
				if (this.bool_0)
				{
					TextRenderer.DrawText(graphics_0, this.string_0, this.Font, this.m_bsButtonStructure.Nullable_1.Value, this.color_0, this.m_bIsRightToLeft ? this.textFormatFlags_2 : this.textFormatFlags_3);
				}
				if (this.m_bHasDropDown)
				{
					Class517.smethod_17(graphics_0, this.m_bsButtonStructure.Nullable_5.Value, this.color_0, (!this.m_bIsRightToLeft) ? ArrowDirection.Right : ArrowDirection.Left, this.m_pntDpi);
				}
			}
			else
			{
				TextRenderer.DrawText(graphics_0, this.m_bsButtonStructure.String_0[0], this.Font, this.m_bsButtonStructure.Nullable_0[0].Value, this.color_0, this.m_bIsRightToLeft ? this.textFormatFlags_0 : this.textFormatFlags_1);
				if (this.m_bsButtonStructure.String_0[1].Length > 0)
				{
					TextRenderer.DrawText(graphics_0, this.m_bsButtonStructure.String_0[1], this.Font, this.m_bsButtonStructure.Nullable_0[1].Value, this.color_0, this.m_bIsRightToLeft ? this.textFormatFlags_0 : this.textFormatFlags_1);
				}
				if (this.m_bHasDropDown)
				{
					Class517.smethod_17(graphics_0, this.m_bsButtonStructure.Nullable_3.Value, this.color_0, ArrowDirection.Down, this.m_pntDpi);
				}
			}
		}

		protected virtual void PaintSmallImage(Graphics graphics_0)
		{
			if (this.m_bChecked || this.m_imgSmallIcon != null)
			{
				System.Drawing.Image image = ((this.m_imgSmallIcon != null) ? this.m_imgSmallIcon : Class517.Bitmap_2);
				graphics_0.DrawImage(image, this.m_bsButtonStructure.Nullable_2.Value, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, this.imageAttributes_0);
			}
		}

		private void method_17(Graphics graphics_0, string string_2)
		{
			TextRenderer.DrawText(graphics_0, base.Text, this.Font, this.m_bsButtonStructure.Nullable_0[0].Value, this.color_0, this.m_bIsRightToLeft ? this.textFormatFlags_0 : this.textFormatFlags_1);
			if (this.m_bHasDropDown)
			{
				if (this.m_bIsRibbonDropDownItem)
				{
					Class517.smethod_17(graphics_0, this.m_bsButtonStructure.Nullable_6.Value, this.color_0, (!this.m_bIsRightToLeft) ? ArrowDirection.Right : ArrowDirection.Left, this.m_pntDpi);
				}
				else
				{
					Class517.smethod_17(graphics_0, this.m_bsButtonStructure.Nullable_4.Value, this.color_0, ArrowDirection.Down, this.m_pntDpi);
				}
			}
		}
	}
}
