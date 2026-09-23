using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using ns21;
using TXTextControl.Windows.Forms.Ribbon;

namespace TXTextControl.Windows.Forms.Ribbon
{
	/// <summary>The RibbonSeperator class represents a control that provides a seperator between elements in a HorizontalRibbonGroup, an ApplicationMenu or a drop-down menu of a RibbonMenuButton.</summary>
	[ToolboxItem(false)]
	public class RibbonSeperator : Control, IRibbonItem, IEnabledItem
	{
		/// <summary>Determines the alignment of the RibbonSeperator:</summary>
		public enum SeperatorAlignment
		{
			/// <summary>The seperator is aligned horizontally.</summary>
			Horizontal,
			/// <summary>The seperator is aligned vertically.</summary>
			Vertical
		}

		private bool bool_0 = true;

		private bool bool_1 = true;

		private PointF pointF_0 = PointF.Empty;

		private SeperatorAlignment seperatorAlignment_0 = SeperatorAlignment.Vertical;

		private VisualStyleRenderer visualStyleRenderer_0;

		private RibbonItemCollection ribbonItemCollection_0;

		private RibbonGroup ribbonGroup_0;

		private Size size_0 = Size.Empty;

		private Padding padding_0 = new Padding(2);

		[CompilerGenerated]
		private bool bool_2;

		[CompilerGenerated]
		private bool bool_3;

		[CompilerGenerated]
		private bool bool_4;

		[CompilerGenerated]
		private string string_0;

		/// <summary>Gets the alignment of this RibbonSeperator.</summary>
		[Browsable(false)]
		public SeperatorAlignment Alignment
		{
			get
			{
				return this.seperatorAlignment_0;
			}
			internal set
			{
				this.method_0(value);
			}
		}

		/// <summary>Gets the RibbonItemCollection that contains this RibbonSeperator.</summary>
		[Category("Behavior")]
		public RibbonItemCollection ParentCollection => this.ribbonItemCollection_0;

		public override DockStyle Dock => base.Dock;

		public new bool Enabled
		{
			get
			{
				if (this.bool_1)
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
				return this.bool_2;
			}
			[CompilerGenerated]
			set
			{
				this.bool_2 = value;
			}
		}

		bool IRibbonItem.IsRibbonDropDownItem
		{
			[CompilerGenerated]
			get
			{
				return this.bool_3;
			}
			[CompilerGenerated]
			set
			{
				this.bool_3 = value;
			}
		}

		bool IRibbonItem.IsUpdatingItemEnabled
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

		string IRibbonItem.KeyTip
		{
			[CompilerGenerated]
			get
			{
				return this.string_0;
			}
			[CompilerGenerated]
			set
			{
				this.string_0 = value;
			}
		}

		bool IRibbonItem.OwnerEnabled
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

		/// <summary>Initializes a new instance of the RibbonSeperator class.</summary>
		public RibbonSeperator()
		{
			try
			{
				this.visualStyleRenderer_0 = new VisualStyleRenderer(VisualStyleElement.ToolBar.SeparatorHorizontal.Normal);
			}
			catch
			{
			}
			base.SetStyle(ControlStyles.SupportsTransparentBackColor | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, value: true);
			base.SetStyle(ControlStyles.Selectable, value: false);
			this.BackColor = Color.Transparent;
			base.TabStop = false;
		}

		private void method_0(SeperatorAlignment seperatorAlignment_1)
		{
			if ((this.seperatorAlignment_0 = seperatorAlignment_1) == SeperatorAlignment.Horizontal)
			{
				base.Dock = DockStyle.Top;
				base.MinimumSize = new Size(0, this.size_0.Height);
				try
				{
					this.visualStyleRenderer_0 = new VisualStyleRenderer(VisualStyleElement.ToolBar.SeparatorVertical.Normal);
				}
				catch
				{
				}
			}
			else
			{
				base.Dock = DockStyle.Left;
				base.MinimumSize = new Size(this.size_0.Width, 0);
				try
				{
					this.visualStyleRenderer_0 = new VisualStyleRenderer(VisualStyleElement.ToolBar.SeparatorHorizontal.Normal);
				}
				catch
				{
				}
			}
		}

		private void method_1()
		{
			if (base.Parent != null && this.ContextMenuStrip == null)
			{
				this.ContextMenuStrip = base.Parent.ContextMenuStrip;
			}
		}

		protected override void OnHandleCreated(EventArgs eventArgs_0)
		{
			this.method_1();
			base.OnHandleCreated(eventArgs_0);
		}

		protected override void OnPaint(PaintEventArgs pea)
		{
			if (this.visualStyleRenderer_0 != null)
			{
				this.visualStyleRenderer_0.DrawBackground(pea.Graphics, new Rectangle(0, 0, base.Width, base.Height));
			}
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
				base.Margin = Class517.smethod_51(Class519.Class523.Padding_3, dpi);
				base.Size = new Size(0, 0);
				this.size_0 = Class517.smethod_48(Class519.Class528.Size_0, dpi);
				this.method_0(this.seperatorAlignment_0);
			}
		}

		SizeF IRibbonItem.GetSize(IconTextRelation scaleMode)
		{
			return new SizeF(base.Width, base.Height);
		}

		void IRibbonItem.ParentVisibleChanged(bool isVisible)
		{
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

		void IRibbonItem.PerformStandardKeyboardAction()
		{
		}
	}
}
