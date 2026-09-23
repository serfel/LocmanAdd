using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using ns27;
using TXTextControl;
using TXTextControl.Windows.Forms.Ribbon;

namespace TXTextControl.Windows.Forms.Ribbon
{
	internal class Class496 : ToolStripProfessionalRenderer
	{
		private RibbonForm ribbonForm_0;

		private bool bool_0;

		private bool bool_1;

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

		internal Class496(RibbonForm ribbonForm_1)
		{
			this.ribbonForm_0 = ribbonForm_1;
		}

		protected override void OnRenderToolStripBackground(ToolStripRenderEventArgs toolStripRenderEventArgs_0)
		{
			if (!toolStripRenderEventArgs_0.ToolStrip.IsDropDown && this.ribbonForm_0.QuickAccessToolbarPosition != QuickAccessToolbarPosition.BelowRibbon)
			{
				if (this.Boolean_0)
				{
					Size size = Class466.smethod_2(this.ribbonForm_0.method_12());
					int num = 15;
					VisualStyleRenderer visualStyleRenderer = new VisualStyleRenderer(this.bool_1 ? VisualStyleElement.Window.Caption.Active : VisualStyleElement.Window.Caption.Inactive);
					visualStyleRenderer.DrawBackground(bounds: new Rectangle(-size.Width, -size.Height, toolStripRenderEventArgs_0.ToolStrip.Width + size.Width + num, toolStripRenderEventArgs_0.ToolStrip.Height + size.Height), dc: toolStripRenderEventArgs_0.Graphics);
				}
				else
				{
					toolStripRenderEventArgs_0.Graphics.Clear(Color.Transparent);
				}
			}
			else
			{
				base.OnRenderToolStripBackground(toolStripRenderEventArgs_0);
			}
		}

		protected override void OnRenderToolStripBorder(ToolStripRenderEventArgs toolStripRenderEventArgs_0)
		{
			if (toolStripRenderEventArgs_0.ToolStrip.IsDropDown)
			{
				base.OnRenderToolStripBorder(toolStripRenderEventArgs_0);
			}
		}

		protected override void OnRenderItemText(ToolStripItemTextRenderEventArgs toolStripItemTextRenderEventArgs_0)
		{
			if (toolStripItemTextRenderEventArgs_0.ToolStrip.IsDropDown)
			{
				base.OnRenderItemText(toolStripItemTextRenderEventArgs_0);
			}
			else if (toolStripItemTextRenderEventArgs_0.Text != null)
			{
				GraphicsPath graphicsPath = new GraphicsPath();
				graphicsPath.AddString(toolStripItemTextRenderEventArgs_0.Text, toolStripItemTextRenderEventArgs_0.TextFont.FontFamily, (int)toolStripItemTextRenderEventArgs_0.TextFont.Style, DpiConverter.PointToPix(toolStripItemTextRenderEventArgs_0.TextFont.Size, toolStripItemTextRenderEventArgs_0.Graphics.DpiY), toolStripItemTextRenderEventArgs_0.TextRectangle.Location, new StringFormat());
				toolStripItemTextRenderEventArgs_0.Graphics.SmoothingMode = SmoothingMode.HighQuality;
				toolStripItemTextRenderEventArgs_0.Graphics.FillPath(Brushes.Black, graphicsPath);
				graphicsPath.Dispose();
			}
		}

		protected override void OnRenderOverflowButtonBackground(ToolStripItemRenderEventArgs toolStripItemRenderEventArgs_0)
		{
			uint num = this.ribbonForm_0.method_11(toolStripItemRenderEventArgs_0.Graphics);
			int num2 = DpiConverter.DPI96toPix(3, num);
			int num3 = DpiConverter.DPI96toPix(5, num);
			if (toolStripItemRenderEventArgs_0.Item.Selected)
			{
				toolStripItemRenderEventArgs_0.Graphics.Clear(Color.FromArgb(20, Color.Navy));
			}
			Rectangle empty = Rectangle.Empty;
			empty = new Rectangle(toolStripItemRenderEventArgs_0.Item.Width / 2 - num2, toolStripItemRenderEventArgs_0.Item.Height / 2 - num3 / 2, num2, num3);
			base.DrawArrow(new ToolStripArrowRenderEventArgs(toolStripItemRenderEventArgs_0.Graphics, toolStripItemRenderEventArgs_0.Item, empty, SystemColors.ControlText, (toolStripItemRenderEventArgs_0.Item.RightToLeft != RightToLeft.Yes) ? ArrowDirection.Right : ArrowDirection.Left));
			empty.Offset(num2, 0);
			base.DrawArrow(new ToolStripArrowRenderEventArgs(toolStripItemRenderEventArgs_0.Graphics, toolStripItemRenderEventArgs_0.Item, empty, SystemColors.ControlText, (toolStripItemRenderEventArgs_0.Item.RightToLeft != RightToLeft.Yes) ? ArrowDirection.Right : ArrowDirection.Left));
		}

		protected override void OnRenderArrow(ToolStripArrowRenderEventArgs toolStripArrowRenderEventArgs_0)
		{
			uint num = this.ribbonForm_0.method_11(toolStripArrowRenderEventArgs_0.Graphics);
			Class517.smethod_17(toolStripArrowRenderEventArgs_0.Graphics, toolStripArrowRenderEventArgs_0.ArrowRectangle, toolStripArrowRenderEventArgs_0.Item.Enabled ? SystemColors.ControlText : SystemColors.ControlDark, toolStripArrowRenderEventArgs_0.Direction, new PointF(num, num));
		}
	}
}
