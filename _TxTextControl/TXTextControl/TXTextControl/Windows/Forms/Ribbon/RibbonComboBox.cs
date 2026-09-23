using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using ns21;
using TXTextControl.Windows.Forms.Ribbon;

namespace TXTextControl.Windows.Forms.Ribbon
{
	/// <summary>The RibbonComboBox class represents a combobox which is inherited from the System.Windows.Forms.ComboBox class.</summary>
	[ToolboxItem(false)]
	public class RibbonComboBox : ComboBox, IRibbonItem, IContentItem, IEnabledItem
	{
		private bool bool_0 = true;

		private bool bool_1 = true;

		private bool bool_2;

		private bool bool_3;

		private string string_0 = string.Empty;

		private PointF pointF_0 = PointF.Empty;

		protected RibbonGroup m_rgRibbonGroup;

		private RibbonItemCollection ribbonItemCollection_0;

		private RibbonToolTip ribbonToolTip_0;

		private IRibbonItem iribbonItem_0;

		[CompilerGenerated]
		private bool bool_4;

		/// <summary>Gets or sets the keyboard shortcut of the RibbonComboBox.</summary>
		[Category("Behavior")]
		[Attribute3("PROP_RIBBON_KEYTIP")]
		public string KeyTip
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

		/// <summary>Gets the RibbonItemCollection that contains this RibbonComboBox.</summary>
		[Category("Behavior")]
		public RibbonItemCollection ParentCollection => this.ribbonItemCollection_0;

		/// <summary>Gets an object of type RibbonToolTip that displays text when the mouse pointer hovers over the item.</summary>
		[Category("Misc")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		public RibbonToolTip ToolTip => this.ribbonToolTip_0;

		public new Color DefaultBackColor => Color.Transparent;

		public new bool Enabled
		{
			get
			{
				if (this.bool_0)
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
			get
			{
				return false;
			}
			set
			{
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
				return this.bool_1;
			}
			set
			{
				if (this.bool_1 != (this.bool_1 = value) && !((IRibbonItem)this).IsRibbonDropDownItem)
				{
					Class517.smethod_25(this.m_rgRibbonGroup);
				}
			}
		}

		bool IRibbonItem.IsRibbonDropDownItem
		{
			get
			{
				return this.bool_2;
			}
			set
			{
				this.bool_2 = value;
			}
		}

		bool IRibbonItem.IsDefaultRibbonTabItem
		{
			[CompilerGenerated]
			get
			{
				return this.bool_4;
			}
			[CompilerGenerated]
			set
			{
				this.bool_4 = value;
			}
		}

		bool IRibbonItem.IsUpdatingItemEnabled
		{
			get
			{
				return this.bool_3;
			}
			set
			{
				this.bool_3 = value;
			}
		}

		bool IRibbonItem.OwnerEnabled
		{
			get
			{
				return this.bool_0;
			}
			set
			{
				this.bool_0 = value;
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

		public new int Width
		{
			get
			{
				return base.Width;
			}
			set
			{
				base.Width = value;
				if (this.m_rgRibbonGroup != null && this.iribbonItem_0 == null && !this.bool_2 && this.bool_3)
				{
					this.m_rgRibbonGroup.method_2();
				}
			}
		}

		/// <summary>Initializes a new instance of the RibbonComboBox class.</summary>
		public RibbonComboBox()
		{
			base.SetStyle(ControlStyles.SupportsTransparentBackColor | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, value: true);
			this.BackColor = this.DefaultBackColor;
			this.ribbonToolTip_0 = new RibbonToolTip(this);
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				((IContentItem)this).ToolTip.Dispose();
			}
			base.Dispose(disposing);
		}

		protected override void OnDropDown(EventArgs eventArgs_0)
		{
			(base.TopLevelControl as RibbonDropDown)?.method_1(bool_3: true);
			base.OnDropDown(eventArgs_0);
		}

		protected override void OnDropDownClosed(EventArgs eventArgs_0)
		{
			(base.TopLevelControl as RibbonDropDown)?.method_1(bool_3: false);
			base.OnDropDownClosed(eventArgs_0);
		}

		protected override void OnFontChanged(EventArgs eventArgs_0)
		{
			this.ribbonToolTip_0.Font_0 = base.Font;
			base.OnFontChanged(eventArgs_0);
		}

		protected override void OnKeyDown(KeyEventArgs keyEventArgs_0)
		{
			if ((keyEventArgs_0.KeyCode == Keys.Down || keyEventArgs_0.KeyCode == Keys.Up) && !base.DroppedDown)
			{
				base.DroppedDown = true;
				return;
			}
			if (keyEventArgs_0.KeyCode == Keys.Return)
			{
				keyEventArgs_0.SuppressKeyPress = true;
				keyEventArgs_0.Handled = true;
			}
			base.OnKeyDown(keyEventArgs_0);
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
			this.ribbonToolTip_0.method_3(nullable_, this.Width, this.ribbonToolTip_0.Control_0, this.pointF_0);
			base.OnMouseEnter(eventargs);
		}

		protected override void OnMouseLeave(EventArgs eventargs)
		{
			base.OnMouseLeave(eventargs);
			if (this.ribbonToolTip_0 != null)
			{
				this.ribbonToolTip_0.method_2();
			}
		}

		public override bool PreProcessMessage(ref Message msg)
		{
			if (this.m_rgRibbonGroup != null && this.m_rgRibbonGroup.Boolean_2)
			{
				return true;
			}
			return base.PreProcessMessage(ref msg);
		}

		protected override void WndProc(ref Message message)
		{
			if (this.m_rgRibbonGroup != null && this.m_rgRibbonGroup.Boolean_2)
			{
				switch (message.Msg)
				{
				case 513:
				case 515:
				case 738:
					return;
				}
				base.WndProc(ref message);
			}
			else
			{
				Class429.Enum121 msg = (Class429.Enum121)message.Msg;
				if (msg != Class429.Enum121.const_56)
				{
					base.WndProc(ref message);
				}
			}
		}

		void IRibbonItem.AwareOfDPI(PointF dpi)
		{
			if (this.pointF_0.X != dpi.X || this.pointF_0.Y != dpi.Y)
			{
				this.pointF_0 = dpi;
				base.Margin = Class517.smethod_51(Class519.Class523.Padding_4, dpi);
			}
		}

		SizeF IRibbonItem.GetSize(IconTextRelation scaleMode)
		{
			return new SizeF(this.Width, base.Height);
		}

		void IRibbonItem.ParentVisibleChanged(bool isVisible)
		{
		}

		void IRibbonItem.PerformStandardKeyboardAction()
		{
			base.Focus();
		}

		void IRibbonItem.SetDropDownItemSize()
		{
			DockStyle dock = base.Dock;
			base.Dock = DockStyle.None;
			base.Size = base.Size;
			base.Dock = dock;
		}

		void IRibbonItem.SetParentCollection(RibbonItemCollection parentCollection)
		{
			this.ribbonItemCollection_0 = parentCollection;
		}
	}
}
