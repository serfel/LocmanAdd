using System;
using System.Drawing;
using System.Windows.Forms;
using ns27;

namespace TXTextControl.Windows.Forms.Ribbon
{
	internal class Class516 : ToolTip
	{
		private Font font_0;

		private Font font_1;

		private TextFormatFlags textFormatFlags_0 = TextFormatFlags.NoPrefix | TextFormatFlags.TextBoxControl | TextFormatFlags.WordBreak;

		private TextFormatFlags textFormatFlags_1 = TextFormatFlags.NoPrefix | TextFormatFlags.RightToLeft | TextFormatFlags.TextBoxControl | TextFormatFlags.WordBreak;

		private TextFormatFlags textFormatFlags_2 = TextFormatFlags.NoPrefix;

		private TextFormatFlags textFormatFlags_3 = TextFormatFlags.NoPrefix | TextFormatFlags.RightToLeft;

		private string string_0;

		private string string_1;

		private Point point_0;

		private Control control_0;

		private Size size_0;

		private Size size_1;

		private Padding padding_0;

		private Padding padding_1;

		private Rectangle rectangle_0;

		private Rectangle rectangle_1;

		internal Class516(string string_2, string string_3, PointF pointF_0, Control control_1)
		{
			this.string_0 = string_2;
			this.string_1 = string_3;
			this.control_0 = control_1;
			Font prototype = Class467.smethod_1((uint)pointF_0.X);
			this.font_1 = new Font(prototype, FontStyle.Bold);
			this.font_0 = new Font(prototype, FontStyle.Regular);
			this.method_3(pointF_0);
			base.OwnerDraw = true;
			base.Draw += Class516_Draw;
			base.Popup += Class516_Popup;
			control_1.MouseLeave += method_0;
			this.point_0 = Class517.smethod_49(new Point(10, 27), pointF_0);
		}

		private void Class516_Draw(object sender, DrawToolTipEventArgs e)
		{
			e.Graphics.FillRectangle(new SolidBrush(SystemColors.Window), e.Bounds);
			e.DrawBorder();
			TextRenderer.DrawText(e.Graphics, this.string_0, this.font_1, this.rectangle_1, SystemColors.ControlText, (this.control_0.RightToLeft == RightToLeft.Yes) ? this.textFormatFlags_3 : this.textFormatFlags_2);
			TextRenderer.DrawText(e.Graphics, this.string_1, this.font_0, this.rectangle_0, SystemColors.ControlText, (this.control_0.RightToLeft == RightToLeft.Yes) ? this.textFormatFlags_1 : this.textFormatFlags_0);
		}

		private void Class516_Popup(object sender, PopupEventArgs e)
		{
			int num = 0;
			int num2 = 0;
			num = this.size_0.Width + this.padding_0.Horizontal;
			int num3 = this.size_0.Height + this.padding_0.Vertical;
			int num4 = this.size_1.Height + this.padding_1.Vertical;
			num2 = num3 + num4;
			e.ToolTipSize = new Size(num, num2);
		}

		private void method_0(object sender, EventArgs e)
		{
			base.Active = false;
			base.Active = true;
		}

		internal void method_1(PointF pointF_0)
		{
			Font prototype = Class467.smethod_1((uint)pointF_0.X);
			this.font_1 = new Font(prototype, FontStyle.Bold);
			this.font_0 = new Font(prototype, FontStyle.Regular);
			this.method_3(pointF_0);
			this.point_0 = Class517.smethod_49(new Point(10, 27), pointF_0);
		}

		internal void method_2()
		{
			base.Show(this.string_1, this.control_0, this.point_0, 32000);
		}

		private void method_3(PointF pointF_0)
		{
			Size size = Class517.smethod_48(Class519.Class541.Size_0, pointF_0);
			int height = Class517.smethod_45(Class519.Class541.Int32_0, pointF_0.Y);
			int height2 = Class517.smethod_45(Class519.Class541.Int32_1, pointF_0.Y);
			this.padding_1 = Class517.smethod_51(Class519.Class541.Padding_0, pointF_0);
			this.padding_0 = Class517.smethod_51(Class519.Class541.Padding_1, pointF_0);
			this.size_0 = TextRenderer.MeasureText(this.string_0, this.font_1, new Size(size.Width, height), (this.control_0.RightToLeft == RightToLeft.Yes) ? this.textFormatFlags_3 : this.textFormatFlags_2);
			this.size_0 = new Size(Math.Max(size.Width - this.padding_0.Horizontal, this.size_0.Width), this.size_0.Height);
			int width = this.size_0.Width + this.padding_0.Horizontal - this.padding_1.Horizontal;
			this.size_1 = TextRenderer.MeasureText(this.string_1, this.font_0, new Size(width, height2), (this.control_0.RightToLeft == RightToLeft.Yes) ? this.textFormatFlags_1 : this.textFormatFlags_0);
			this.size_1 = new Size(this.size_0.Width + this.padding_0.Horizontal - this.padding_1.Horizontal, this.size_1.Height);
			size = Class517.smethod_48(Class519.Class541.Size_0, pointF_0);
			int y = this.padding_0.Top + this.size_0.Height + this.padding_1.Top;
			int width2 = this.size_0.Width + this.padding_0.Horizontal;
			int num = this.size_0.Height + this.padding_0.Vertical;
			int num2 = this.size_1.Height + this.padding_1.Vertical;
			int height3 = num + num2;
			Size size2 = new Size(width2, height3);
			if (this.control_0.RightToLeft == RightToLeft.Yes)
			{
				this.rectangle_1 = new Rectangle(size2.Width - this.padding_0.Right - this.size_0.Width, this.padding_0.Top, this.size_0.Width, this.size_0.Height);
				this.rectangle_0 = new Rectangle(size2.Width - this.padding_1.Right - this.size_1.Width, y, this.size_1.Width, this.size_1.Height);
			}
			else
			{
				this.rectangle_1 = new Rectangle(this.padding_0.Left, this.padding_0.Top, this.size_0.Width, this.size_0.Height);
				this.rectangle_0 = new Rectangle(this.padding_1.Left, y, this.size_1.Width, this.size_1.Height);
			}
		}
	}
}
