using System;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using ns27;
using TXTextControl.Windows.Forms.Ribbon;

namespace TXTextControl.Windows.Forms.Ribbon
{
	internal class Class564 : ToolStripDropDownButton, IRibbonToolStripItem
	{
		private RibbonMenuButton ribbonMenuButton_0;

		private int int_0 = Class519.Class520.Int32_0;

		private PointF pointF_0 = PointF.Empty;

		[CompilerGenerated]
		private bool bool_0;

		protected override ToolStripItemDisplayStyle DefaultDisplayStyle => ToolStripItemDisplayStyle.Image;

		bool IRibbonToolStripItem.IsToolStripItemAdded
		{
			[CompilerGenerated]
			get
			{
				return this.bool_0;
			}
			[CompilerGenerated]
			set
			{
				this.bool_0 = value;
			}
		}

		RibbonTab IRibbonToolStripItem.RibbonTab => Class517.smethod_19(this.ribbonMenuButton_0);

		object IRibbonToolStripItem.Parent => this.ribbonMenuButton_0;

		PointF IRibbonToolStripItem.DPI
		{
			get
			{
				if (this.pointF_0.IsEmpty)
				{
					return ((IRibbonItem)this.ribbonMenuButton_0).DPI;
				}
				return this.pointF_0;
			}
			set
			{
				if (this.pointF_0.X != value.X || this.pointF_0.Y != value.Y)
				{
					this.pointF_0 = value;
					Class517.smethod_57(this, this.ribbonMenuButton_0.SmallIcon, this.pointF_0);
				}
			}
		}

		internal Class564(RibbonMenuButton ribbonMenuButton_1)
			: base(ribbonMenuButton_1.Text)
		{
			base.ImageScaling = ToolStripItemImageScaling.None;
			base.AutoToolTip = false;
			this.ribbonMenuButton_0 = ribbonMenuButton_1;
			base.ImageAlign = ContentAlignment.MiddleLeft;
			base.ShowDropDownArrow = false;
		}

		public override Size GetPreferredSize(Size constrainingSize)
		{
			Size preferredSize = base.GetPreferredSize(constrainingSize);
			int width = preferredSize.Width + this.int_0;
			return new Size(width, preferredSize.Height);
		}

		protected override void OnParentChanged(ToolStrip oldParent, ToolStrip newParent)
		{
			if (newParent != null)
			{
				Graphics graphics = base.Parent.CreateGraphics();
				this.int_0 = Class517.smethod_45(float_0: new PointF(graphics.DpiX, graphics.DpiY).X, int_0: Class519.Class520.Int32_0);
				graphics.Dispose();
			}
			base.OnParentChanged(oldParent, newParent);
		}

		protected override void OnClick(EventArgs eventArgs_0)
		{
			this.ribbonMenuButton_0.InvokeOnClick(eventArgs_0);
		}

		protected override void OnDropDownShow(EventArgs eventArgs_0)
		{
			IRibbonItem ribbonItem = this.ribbonMenuButton_0;
			if (ribbonItem.DPI.IsEmpty)
			{
				Graphics graphics = base.Parent.CreateGraphics();
				PointF dpi = new PointF(graphics.DpiX, graphics.DpiY);
				graphics.Dispose();
				ribbonItem.AwareOfDPI(dpi);
			}
			RibbonDropDown ribbonDropDown = this.ribbonMenuButton_0.method_18();
			if (ribbonDropDown.Items.Count > 0)
			{
				ribbonDropDown.Owner = Class517.smethod_1(base.Parent);
				if (this.RightToLeft == RightToLeft.Yes)
				{
					ribbonDropDown.Show(base.Parent.PointToScreen(new Point(this.Bounds.Right, this.Bounds.Bottom)), ToolStripDropDownDirection.BelowLeft);
				}
				else
				{
					ribbonDropDown.Show(base.Parent.PointToScreen(new Point(this.Bounds.X, this.Bounds.Bottom)));
				}
			}
			base.OnDropDownShow(eventArgs_0);
		}

		protected override void OnMouseEnter(EventArgs eventArgs_0)
		{
			this.ribbonMenuButton_0.ToolTip.method_3(new Point(this.Bounds.X, this.Bounds.Bottom), base.Width, base.Parent, ((IRibbonToolStripItem)this).DPI);
			base.OnMouseEnter(eventArgs_0);
		}

		protected override void OnMouseLeave(EventArgs eventArgs_0)
		{
			this.ribbonMenuButton_0.ToolTip.method_2();
			base.OnMouseLeave(eventArgs_0);
		}

		protected override void OnPaint(PaintEventArgs paintEventArgs_0)
		{
			base.OnPaint(paintEventArgs_0);
			Size size = Class466.smethod_3((uint)this.pointF_0.X);
			Class517.smethod_17(rectangle_0: new Rectangle(size.Width + 1, 0, base.Width - size.Width - 2, base.Height), graphics_0: paintEventArgs_0.Graphics, color_0: this.Enabled ? SystemColors.ControlText : SystemColors.ControlDark, arrowDirection_0: ArrowDirection.Down, pointF_1: ((IRibbonItem)this.ribbonMenuButton_0).DPI);
		}
	}
}
