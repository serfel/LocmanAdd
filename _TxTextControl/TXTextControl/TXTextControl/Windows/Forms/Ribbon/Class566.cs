using System.Drawing;
using System.Windows.Forms;

namespace TXTextControl.Windows.Forms.Ribbon
{
	internal class Class566 : ToolStripDropDownButton
	{
		private int int_0 = Class519.Class520.Int32_0;

		private PointF pointF_0 = PointF.Empty;

		protected override ToolStripItemDisplayStyle DefaultDisplayStyle => ToolStripItemDisplayStyle.Image;

		internal Class566()
		{
			base.ShowDropDownArrow = false;
		}

		internal void method_0(PointF pointF_1)
		{
			this.pointF_0 = pointF_1;
		}

		public override Size GetPreferredSize(Size constrainingSize)
		{
			return new Size(height: base.GetPreferredSize(constrainingSize).Height, width: this.int_0);
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

		protected override void OnPaint(PaintEventArgs paintEventArgs_0)
		{
			base.OnPaint(paintEventArgs_0);
			Class517.smethod_17(rectangle_0: new Rectangle(0, 0, base.Width, base.Height), graphics_0: paintEventArgs_0.Graphics, color_0: this.Enabled ? SystemColors.ControlText : SystemColors.ControlDark, arrowDirection_0: ArrowDirection.Down, pointF_1: this.pointF_0);
		}
	}
}
