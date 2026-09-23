using System;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using TXTextControl.Windows.Forms.Ribbon;

namespace TXTextControl.Windows.Forms.Ribbon
{
	internal class Class565 : ToolStripSplitButton, IRibbonToolStripItem
	{
		private RibbonSplitButton ribbonSplitButton_0;

		protected VisualStyleRenderer visualStyleRenderer_0;

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

		RibbonTab IRibbonToolStripItem.RibbonTab => Class517.smethod_19(this.ribbonSplitButton_0);

		object IRibbonToolStripItem.Parent => this.ribbonSplitButton_0;

		PointF IRibbonToolStripItem.DPI
		{
			get
			{
				if (this.pointF_0.IsEmpty)
				{
					return ((IRibbonItem)this.ribbonSplitButton_0).DPI;
				}
				return this.pointF_0;
			}
			set
			{
				if (this.pointF_0.X != value.X || this.pointF_0.Y != value.Y)
				{
					this.pointF_0 = value;
					Class517.smethod_57(this, this.ribbonSplitButton_0.SmallIcon, this.pointF_0);
				}
			}
		}

		internal Class565(RibbonSplitButton ribbonSplitButton_1)
			: base(ribbonSplitButton_1.Text)
		{
			base.ImageScaling = ToolStripItemImageScaling.None;
			base.AutoToolTip = false;
			try
			{
				this.visualStyleRenderer_0 = new VisualStyleRenderer(VisualStyleElement.ToolBar.Button.Checked);
			}
			catch
			{
			}
			this.ribbonSplitButton_0 = ribbonSplitButton_1;
			base.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		}

		protected override void OnParentChanged(ToolStrip oldParent, ToolStrip newParent)
		{
			if (newParent != null)
			{
				Graphics graphics = newParent.CreateGraphics();
				PointF pointF = new PointF(graphics.DpiX, graphics.DpiY);
				graphics.Dispose();
				base.DropDownButtonWidth = Class517.smethod_45(Class519.Class520.Int32_0, pointF.X);
			}
			base.OnParentChanged(oldParent, newParent);
		}

		protected override void OnButtonClick(EventArgs eventArgs_0)
		{
			this.ribbonSplitButton_0.method_22();
		}

		protected override void OnDropDownShow(EventArgs eventArgs_0)
		{
			IRibbonItem ribbonItem = this.ribbonSplitButton_0;
			if (ribbonItem.DPI.IsEmpty)
			{
				Graphics graphics = base.Parent.CreateGraphics();
				PointF dpi = new PointF(graphics.DpiX, graphics.DpiY);
				graphics.Dispose();
				ribbonItem.AwareOfDPI(dpi);
			}
			RibbonDropDown ribbonDropDown = this.ribbonSplitButton_0.method_18();
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
			this.ribbonSplitButton_0.ToolTip.method_3(new Point(this.Bounds.X, this.Bounds.Bottom), base.Width, base.Parent, ((IRibbonToolStripItem)this).DPI);
			base.OnMouseEnter(eventArgs_0);
		}

		protected override void OnMouseLeave(EventArgs eventArgs_0)
		{
			this.ribbonSplitButton_0.ToolTip.method_2();
			base.OnMouseLeave(eventArgs_0);
		}

		protected override void OnPaint(PaintEventArgs paintEventArgs_0)
		{
			base.OnPaint(paintEventArgs_0);
			if (this.ribbonSplitButton_0.Checkable && this.ribbonSplitButton_0.Checked)
			{
				Rectangle rectangle = ((this.RightToLeft == RightToLeft.Yes) ? new Rectangle(paintEventArgs_0.ClipRectangle.X + base.DropDownButtonWidth, paintEventArgs_0.ClipRectangle.Y, paintEventArgs_0.ClipRectangle.Width - base.DropDownButtonWidth, paintEventArgs_0.ClipRectangle.Height) : new Rectangle(paintEventArgs_0.ClipRectangle.X, paintEventArgs_0.ClipRectangle.Y, paintEventArgs_0.ClipRectangle.Width - base.DropDownButtonWidth, paintEventArgs_0.ClipRectangle.Height));
				if (this.visualStyleRenderer_0 != null)
				{
					this.visualStyleRenderer_0.DrawBackground(paintEventArgs_0.Graphics, rectangle);
				}
				paintEventArgs_0.Graphics.DrawImage(this.Image, new Point(rectangle.X + 2, paintEventArgs_0.ClipRectangle.Y + 3));
			}
		}
	}
}
