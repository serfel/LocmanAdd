using System;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using TXTextControl.Windows.Forms.Ribbon;

namespace TXTextControl.Windows.Forms.Ribbon
{
	internal class Class515
	{
		private bool bool_0;

		private bool bool_1;

		private DialogBoxLauncher dialogBoxLauncher_0;

		private Padding padding_0;

		private Padding padding_1;

		private RibbonGroup ribbonGroup_0;

		private Size size_0;

		private VisualStyleRenderer visualStyleRenderer_0;

		private PointF pointF_0 = PointF.Empty;

		internal bool Boolean_0
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

		internal Padding Padding_0 => this.padding_1;

		internal DialogBoxLauncher DialogBoxLauncher_0 => this.dialogBoxLauncher_0;

		internal bool Boolean_1
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

		internal Padding Padding_1
		{
			get
			{
				return this.padding_0;
			}
			set
			{
				if (this.padding_0 != (this.padding_0 = value))
				{
					this.ribbonGroup_0.MinimumSize = new Size(this.ribbonGroup_0.MinimumSize.Width, Class517.smethod_32(this.ribbonGroup_0));
				}
			}
		}

		internal Size Size_0 => this.size_0;

		internal Class515(RibbonGroup ribbonGroup_1)
		{
			try
			{
				this.visualStyleRenderer_0 = new VisualStyleRenderer(VisualStyleElement.ToolBar.Button.Normal);
			}
			catch
			{
			}
			this.ribbonGroup_0 = ribbonGroup_1;
			this.ribbonGroup_0.Class514_0.MouseMove += method_5;
			this.ribbonGroup_0.Class514_0.MouseLeave += method_4;
			this.dialogBoxLauncher_0 = new DialogBoxLauncher(ribbonGroup_1);
		}

		internal static double smethod_0(Font font_0, float float_0)
		{
			return Math.Max(val2: TextRenderer.MeasureText("A", font_0).Height, val1: Class517.smethod_45(Class519.Class523.Class525.Size_0.Height, float_0));
		}

		internal void method_0(PointF pointF_1)
		{
			if (this.pointF_0.X != pointF_1.X || this.pointF_0.Y != pointF_1.Y)
			{
				this.pointF_0 = pointF_1;
				this.padding_0 = Class517.smethod_51(Class519.Class523.Class524.Padding_0, pointF_1);
				this.padding_1 = Class517.smethod_51(Class519.Class523.Class524.Padding_1, pointF_1);
				this.size_0 = Class517.smethod_48(Class519.Class523.Class525.Size_0, pointF_1);
				this.DialogBoxLauncher_0.Padding_0 = Class517.smethod_51(Class519.Class523.Class525.Padding_0, pointF_1);
				this.DialogBoxLauncher_0.Size_0 = Class517.smethod_48(Class519.Class523.Class525.Size_0, pointF_1);
				this.method_3();
			}
		}

		internal void method_1(Graphics graphics_0)
		{
			int x = ((this.ribbonGroup_0.RightToLeft == RightToLeft.No) ? this.padding_0.Left : this.padding_0.Right);
			int y = this.ribbonGroup_0.Height - this.size_0.Height;
			int width = this.ribbonGroup_0.Width - this.padding_0.Horizontal;
			Rectangle rectangle = new Rectangle(x, y, width, this.size_0.Height);
			StringFormat stringFormat = new StringFormat();
			stringFormat.Alignment = StringAlignment.Center;
			stringFormat.LineAlignment = StringAlignment.Center;
			graphics_0.DrawString(this.ribbonGroup_0.Text, this.ribbonGroup_0.Font, new SolidBrush(this.ribbonGroup_0.Color_0), rectangle, stringFormat);
			if (this.dialogBoxLauncher_0.Visible)
			{
				if (this.visualStyleRenderer_0 != null)
				{
					this.visualStyleRenderer_0.DrawBackground(graphics_0, this.dialogBoxLauncher_0.Rectangle_0);
				}
				graphics_0.DrawImage(Class517.Bitmap_5, this.dialogBoxLauncher_0.Rectangle_0, 0, 0, Class517.Bitmap_5.Width, Class517.Bitmap_5.Height, GraphicsUnit.Pixel, this.dialogBoxLauncher_0.ImageAttributes_0);
			}
		}

		internal void method_2()
		{
			if (this.ribbonGroup_0.RightToLeft == RightToLeft.Yes)
			{
				_ = this.dialogBoxLauncher_0.Size_0.Width;
			}
			Rectangle rectangle_ = ((this.ribbonGroup_0.RightToLeft == RightToLeft.Yes) ? new Rectangle(0, this.ribbonGroup_0.Height - this.dialogBoxLauncher_0.Size_0.Height - this.DialogBoxLauncher_0.Padding_0.Bottom, this.dialogBoxLauncher_0.Size_0.Width, this.dialogBoxLauncher_0.Size_0.Height) : new Rectangle(this.ribbonGroup_0.Class514_0.Right - this.dialogBoxLauncher_0.Size_0.Width - this.dialogBoxLauncher_0.Padding_0.Right, this.ribbonGroup_0.Height - this.dialogBoxLauncher_0.Size_0.Height - this.DialogBoxLauncher_0.Padding_0.Bottom, this.dialogBoxLauncher_0.Size_0.Width, this.dialogBoxLauncher_0.Size_0.Height));
			this.dialogBoxLauncher_0.Rectangle_0 = rectangle_;
			this.dialogBoxLauncher_0.Rectangle_1 = new Rectangle(new Point(rectangle_.X - this.ribbonGroup_0.Class514_0.Left, rectangle_.Y - this.ribbonGroup_0.Class514_0.Top), rectangle_.Size);
		}

		internal void method_3()
		{
			if (!this.pointF_0.IsEmpty)
			{
				Size size = TextRenderer.MeasureText(this.ribbonGroup_0.Text, this.ribbonGroup_0.Font, Size.Empty, TextFormatFlags.NoPrefix);
				this.dialogBoxLauncher_0.method_0();
				int width = size.Width + this.padding_0.Horizontal;
				this.size_0 = new Size(width, Math.Max(this.dialogBoxLauncher_0.Size_0.Height, size.Height));
			}
		}

		private void method_4(object sender, EventArgs e)
		{
			if (!this.bool_0)
			{
				this.bool_1 = false;
			}
			try
			{
				this.visualStyleRenderer_0 = new VisualStyleRenderer(VisualStyleElement.ToolBar.Button.Normal);
			}
			catch
			{
			}
			this.ribbonGroup_0.Invalidate(this.dialogBoxLauncher_0.Rectangle_0);
			this.ribbonGroup_0.ContextMenuStrip = this.ribbonGroup_0.ContextMenuStrip_0;
			this.dialogBoxLauncher_0.ToolTip.method_2();
		}

		private void method_5(object sender, MouseEventArgs e)
		{
			if (!this.dialogBoxLauncher_0.Enabled || this.bool_1 == (this.bool_1 = this.dialogBoxLauncher_0.Rectangle_1.Contains(e.Location)))
			{
				return;
			}
			if (this.bool_1)
			{
				try
				{
					this.visualStyleRenderer_0 = new VisualStyleRenderer(VisualStyleElement.ToolBar.Button.Hot);
				}
				catch
				{
				}
				if (this.dialogBoxLauncher_0.ContextMenuStrip != null)
				{
					this.ribbonGroup_0.ContextMenuStrip = this.dialogBoxLauncher_0.ContextMenuStrip;
				}
				Point? nullable_ = new Point(this.dialogBoxLauncher_0.Rectangle_0.X, this.ribbonGroup_0.Height);
				this.dialogBoxLauncher_0.ToolTip.method_3(nullable_, this.dialogBoxLauncher_0.Rectangle_0.Width, this.dialogBoxLauncher_0.ToolTip.Control_0, this.pointF_0);
			}
			else
			{
				try
				{
					this.visualStyleRenderer_0 = new VisualStyleRenderer(VisualStyleElement.ToolBar.Button.Normal);
				}
				catch
				{
				}
				this.ribbonGroup_0.ContextMenuStrip = this.ribbonGroup_0.ContextMenuStrip_0;
				this.dialogBoxLauncher_0.ToolTip.method_2();
			}
			this.ribbonGroup_0.Invalidate(this.dialogBoxLauncher_0.Rectangle_0);
		}
	}
}
