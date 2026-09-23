using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using ns21;
using TXTextControl.Windows.Forms.Ribbon;

namespace TXTextControl.Windows.Forms.Ribbon
{
	/// <summary>The RibbonLabel class represents a label which is inherited from the System.Windows.Forms.Control class.</summary>
	[ToolboxItem(false)]
	public class RibbonLabel : Control, IRibbonItem, IContentItem, IEnabledItem
	{
		internal class Class518
		{
			[CompilerGenerated]
			private Rectangle? nullable_0;

			[CompilerGenerated]
			private Rectangle? nullable_1;

			[CompilerGenerated]
			private Size size_0;

			[CompilerGenerated]
			private IconTextRelation iconTextRelation_0;

			internal Rectangle? Nullable_0
			{
				[CompilerGenerated]
				get
				{
					return this.nullable_0;
				}
				[CompilerGenerated]
				set
				{
					this.nullable_0 = value;
				}
			}

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

			internal Class518(IconTextRelation iconTextRelation_1)
			{
				this.IconTextRelation_0 = iconTextRelation_1;
			}
		}

		private bool bool_0 = true;

		private bool bool_1;

		private bool bool_2;

		private bool bool_3 = true;

		private bool bool_4;

		private int int_0;

		private int int_1;

		private int int_2;

		private string string_0 = string.Empty;

		private PointF pointF_0 = PointF.Empty;

		private Color color_0;

		private System.Drawing.Image image_0;

		protected ImageAttributes m_iaImageAttribute;

		private Padding padding_0;

		private IRibbonItem iribbonItem_0;

		private Padding padding_1;

		private RibbonGroup ribbonGroup_0;

		private RibbonItemCollection ribbonItemCollection_0;

		private RibbonToolTip ribbonToolTip_0;

		private Size size_0;

		private TextFormatFlags textFormatFlags_0 = TextFormatFlags.NoPrefix | TextFormatFlags.RightToLeft;

		private TextFormatFlags textFormatFlags_1 = TextFormatFlags.NoPrefix;

		private Class518 class518_0 = new Class518(IconTextRelation.NoIconLabeled);

		[CompilerGenerated]
		private bool bool_5;

		[CompilerGenerated]
		private bool bool_6;

		/// <summary>Gets the RibbonItemCollection that contains this RibbonLabel.</summary>
		[Category("Behavior")]
		public RibbonItemCollection ParentCollection => this.ribbonItemCollection_0;

		/// <summary>Gets or sets a 16x16 1/96 inch icon for this RibbonLabel.</summary>
		[Category("Appearance")]
		[DefaultValue(null)]
		public System.Drawing.Image SmallIcon
		{
			get
			{
				return this.image_0;
			}
			set
			{
				if (this.image_0 != (this.image_0 = value))
				{
					this.method_1(bool_7: false);
				}
			}
		}

		/// <summary>Gets an object of type RibbonToolTip that displays text when the mouse pointer hovers over the item.</summary>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		[Category("Misc")]
		public RibbonToolTip ToolTip => this.ribbonToolTip_0;

		internal string String_0 => base.Name;

		internal IconTextRelation IconTextRelation_0 => this.class518_0.IconTextRelation_0;

		public new Color DefaultBackColor => Color.Transparent;

		protected override Padding DefaultMargin => new Padding(0);

		public new bool Enabled
		{
			get
			{
				if (this.bool_3)
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

		PointF IRibbonItem.DPI => this.pointF_0;

		bool IRibbonItem.HasSmallIcon
		{
			[CompilerGenerated]
			get
			{
				return this.bool_5;
			}
			[CompilerGenerated]
			set
			{
				this.bool_5 = value;
			}
		}

		bool IRibbonItem.HasLargeIcon
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		bool IRibbonItem.InternalVisible
		{
			get
			{
				return this.bool_0;
			}
			set
			{
				if (this.bool_0 != (this.bool_0 = value) && !((IRibbonItem)this).IsRibbonDropDownItem)
				{
					Class517.smethod_25(this.ribbonGroup_0);
				}
			}
		}

		bool IRibbonItem.IsDefaultRibbonTabItem
		{
			[CompilerGenerated]
			get
			{
				return this.bool_6;
			}
			[CompilerGenerated]
			set
			{
				this.bool_6 = value;
			}
		}

		bool IRibbonItem.IsRibbonDropDownItem
		{
			get
			{
				return this.bool_1;
			}
			set
			{
				this.bool_1 = value;
			}
		}

		bool IRibbonItem.IsUpdatingItemEnabled
		{
			get
			{
				return this.bool_2;
			}
			set
			{
				if (this.bool_2 = value)
				{
					this.method_1(bool_7: true);
				}
			}
		}

		string IRibbonItem.KeyTip
		{
			get
			{
				return this.string_0;
			}
			set
			{
				this.string_0 = value;
			}
		}

		bool IRibbonItem.OwnerEnabled
		{
			get
			{
				return this.bool_3;
			}
			set
			{
				if (this.bool_3 != (this.bool_3 = value))
				{
					this.method_3();
				}
			}
		}

		RibbonGroup IRibbonItem.RibbonGroup
		{
			get
			{
				return this.ribbonGroup_0;
			}
			set
			{
				if (this.ribbonGroup_0 != (this.ribbonGroup_0 = value) && this.ribbonGroup_0 != null)
				{
					base.Font = this.ribbonGroup_0.Font;
					((IRibbonItem)this).IsUpdatingItemEnabled = true;
				}
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

		/// <summary>Initializes a new instance of the RibbonLabel class.</summary>
		public RibbonLabel()
		{
			base.SetStyle(ControlStyles.SupportsTransparentBackColor | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, value: true);
			base.SetStyle(ControlStyles.Selectable, value: false);
			base.BackColor = this.DefaultBackColor;
			this.color_0 = base.ForeColor;
			this.ribbonToolTip_0 = new RibbonToolTip(this);
			base.TabStop = false;
			this.Dock = DockStyle.Top;
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				((IContentItem)this).ToolTip.Dispose();
				if (this.image_0 != null)
				{
					this.image_0.Dispose();
				}
			}
			base.Dispose(disposing);
		}

		private void method_0(Class518 class518_1)
		{
			this.bool_4 = (this.ribbonGroup_0 != null && this.ribbonGroup_0.RightToLeft == RightToLeft.Yes) || this.RightToLeft == RightToLeft.Yes;
			Size size = TextRenderer.MeasureText(this.Text, this.Font, default(Size), this.bool_4 ? this.textFormatFlags_0 : this.textFormatFlags_1);
			int num = Math.Max(size.Height + this.padding_1.Vertical, this.size_0.Height + this.padding_0.Vertical);
			int num2 = 24;
			int num3 = num / 2 - size.Height / 2;
			switch (class518_1.IconTextRelation_0)
			{
			case IconTextRelation.NoIconLabeled:
			{
				num2 = Math.Max(this.int_1, size.Width + this.padding_1.Horizontal);
				int num4 = (this.bool_4 ? (num2 - size.Width - this.padding_1.Right) : this.padding_1.Left);
				num3 = num / 2 - size.Height / 2;
				class518_1.Nullable_0 = new Rectangle(new Point(num4, num3), size);
				class518_1.Nullable_1 = null;
				break;
			}
			case IconTextRelation.SmallIconUnlabeled:
			{
				num2 = Math.Max(this.int_1, this.size_0.Width + this.padding_0.Horizontal);
				int num5 = (this.bool_4 ? (num2 - this.size_0.Width - this.padding_0.Right) : this.padding_0.Left);
				int num6 = num / 2 - this.size_0.Height / 2;
				class518_1.Nullable_1 = new Rectangle(num5, num6, this.size_0.Width, this.size_0.Height);
				class518_1.Nullable_0 = null;
				break;
			}
			case IconTextRelation.SmallIconLabeled:
			{
				num2 = Math.Max(this.int_1, this.size_0.Width + this.padding_0.Horizontal + size.Width + this.padding_1.Horizontal);
				int num4 = (this.bool_4 ? (num2 - size.Width - this.size_0.Width - this.padding_0.Horizontal - this.padding_1.Right) : (this.size_0.Width + this.padding_0.Horizontal + this.padding_1.Left));
				class518_1.Nullable_0 = new Rectangle(new Point(num4, num3), size);
				int num5 = (this.bool_4 ? (num2 - this.size_0.Width - this.padding_0.Right) : this.padding_0.Left);
				int num6 = num / 2 - this.size_0.Height / 2;
				class518_1.Nullable_1 = new Rectangle(num5, num6, this.size_0.Width, this.size_0.Height);
				break;
			}
			}
			class518_1.Size_0 = new Size(num2, num);
		}

		private void method_1(bool bool_7)
		{
			if (!this.pointF_0.IsEmpty && this.bool_2)
			{
				this.class518_0.IconTextRelation_0 = ((this.image_0 == null) ? IconTextRelation.NoIconLabeled : ((base.Text == null || base.Text.Length == 0) ? IconTextRelation.SmallIconUnlabeled : IconTextRelation.SmallIconLabeled));
				if ((this.method_2() || bool_7) && !this.bool_1 && this.ribbonGroup_0 != null && this.iribbonItem_0 == null)
				{
					this.ribbonGroup_0.method_2();
				}
			}
		}

		private bool method_2()
		{
			this.method_0(this.class518_0);
			bool result = base.Width != this.class518_0.Size_0.Width;
			this.bool_2 = false;
			base.Size = this.class518_0.Size_0;
			this.bool_2 = true;
			return result;
		}

		private void method_3()
		{
			this.int_0 = ((!this.Enabled) ? 65 : 0);
			this.color_0 = ((this.int_0 == 0) ? this.ForeColor : ControlPaint.LightLight(this.ForeColor));
			this.m_iaImageAttribute = Class517.smethod_20(this.int_0);
		}

		protected override void OnEnabledChanged(EventArgs eventArgs_0)
		{
			this.method_3();
			base.OnEnabledChanged(eventArgs_0);
		}

		protected override void OnFontChanged(EventArgs eventArgs_0)
		{
			this.ribbonToolTip_0.Font_0 = base.Font;
			base.OnFontChanged(eventArgs_0);
		}

		protected override void OnForeColorChanged(EventArgs eventArgs_0)
		{
			this.color_0 = ((this.int_0 == 0) ? base.ForeColor : ControlPaint.LightLight(base.ForeColor));
			base.OnForeColorChanged(eventArgs_0);
		}

		protected override void OnMouseDown(MouseEventArgs mevent)
		{
			base.OnMouseDown(mevent);
			if (this.ribbonToolTip_0 != null)
			{
				this.ribbonToolTip_0.method_2();
			}
		}

		protected override void OnMouseEnter(EventArgs eventargs)
		{
			Point? nullable_ = Class517.smethod_21(this);
			this.ribbonToolTip_0.method_3(nullable_, base.Width, this.ribbonToolTip_0.Control_0, this.pointF_0);
			if (eventargs != null)
			{
				base.OnMouseEnter(eventargs);
			}
		}

		protected override void OnMouseLeave(EventArgs eventargs)
		{
			if (eventargs != null)
			{
				base.OnMouseLeave(eventargs);
				if (this.ribbonToolTip_0 != null)
				{
					this.ribbonToolTip_0.method_2();
				}
			}
		}

		protected override void OnPaint(PaintEventArgs pea)
		{
			pea.Graphics.FillRectangle(new SolidBrush(base.BackColor), pea.ClipRectangle);
			switch (this.class518_0.IconTextRelation_0)
			{
			case IconTextRelation.NoIconLabeled:
				TextRenderer.DrawText(pea.Graphics, base.Text, this.Font, this.class518_0.Nullable_0.Value, this.color_0, this.bool_4 ? this.textFormatFlags_0 : this.textFormatFlags_1);
				break;
			case IconTextRelation.SmallIconUnlabeled:
				if (this.image_0 != null)
				{
					pea.Graphics.DrawImage(this.image_0, this.class518_0.Nullable_1.Value, 0, 0, this.size_0.Width, this.size_0.Height, GraphicsUnit.Pixel, this.m_iaImageAttribute);
				}
				break;
			case IconTextRelation.SmallIconLabeled:
				if (this.image_0 != null)
				{
					pea.Graphics.DrawImage(this.image_0, this.class518_0.Nullable_1.Value, 0, 0, this.image_0.Width, this.image_0.Height, GraphicsUnit.Pixel, this.m_iaImageAttribute);
				}
				TextRenderer.DrawText(pea.Graphics, base.Text, this.Font, this.class518_0.Nullable_0.Value, this.color_0, this.bool_4 ? this.textFormatFlags_0 : this.textFormatFlags_1);
				break;
			}
			base.OnPaint(new PaintEventArgs(pea.Graphics, pea.ClipRectangle));
		}

		protected override void OnRightToLeftChanged(EventArgs eventArgs_0)
		{
			this.method_0(this.class518_0);
			base.OnRightToLeftChanged(eventArgs_0);
		}

		protected override void OnSizeChanged(EventArgs eventArgs_0)
		{
			this.int_1 = base.Width;
			this.int_2 = base.Height;
			if (this.bool_1)
			{
				this.method_1(bool_7: false);
			}
			base.OnSizeChanged(eventArgs_0);
		}

		protected override void OnTextChanged(EventArgs eventArgs_0)
		{
			this.method_1(bool_7: true);
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
			if (dpi.X != this.pointF_0.X || dpi.Y != this.pointF_0.Y)
			{
				this.pointF_0 = dpi;
				this.padding_0 = Class517.smethod_51(Class519.Class527.Padding_0, dpi);
				this.size_0 = Class517.smethod_48(Class519.Class527.Size_0, dpi);
				this.padding_1 = Class517.smethod_51(Class519.Class527.Padding_1, dpi);
				base.Margin = Class517.smethod_51(Class519.Class523.Padding_3, dpi);
				this.int_1 = 0;
				this.int_2 = 0;
				this.method_1(bool_7: false);
			}
		}

		SizeF IRibbonItem.GetSize(IconTextRelation scaleMode)
		{
			Class518 @class = new Class518(scaleMode);
			this.method_0(@class);
			return @class.Size_0;
		}

		void IRibbonItem.ParentVisibleChanged(bool isVisible)
		{
		}

		void IRibbonItem.PerformStandardKeyboardAction()
		{
		}

		void IRibbonItem.SetDropDownItemSize()
		{
			DockStyle dock = base.Dock;
			base.Dock = DockStyle.None;
			this.method_1(bool_7: false);
			base.Dock = dock;
		}

		void IRibbonItem.SetParentCollection(RibbonItemCollection parentCollection)
		{
			this.ribbonItemCollection_0 = parentCollection;
		}
	}
}
