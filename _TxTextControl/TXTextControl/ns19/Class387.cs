using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using TXTextControl;

namespace ns19
{
	internal class Class387 : ITransformAttribute
	{
		private RectangleF rectangleF_0;

		private RectangleF rectangleF_1;

		private AlignX alignX_0;

		private AlignY alignY_0;

		private bool bool_0 = true;

		internal RectangleF RectangleF_0 => this.rectangleF_0;

		internal RectangleF RectangleF_1 => this.rectangleF_1;

		internal Class387(float[] float_0, string string_0, RectangleF rectangleF_2)
		{
			this.rectangleF_0 = new RectangleF(float_0[0], float_0[1], float_0[2], float_0[3]);
			if (string.IsNullOrEmpty(string_0))
			{
				this.alignX_0 = AlignX.Center;
				this.alignY_0 = AlignY.Center;
			}
			else
			{
				if (string_0 == "none")
				{
					this.alignX_0 = AlignX.Stretch;
					this.alignY_0 = AlignY.Stretch;
				}
				else
				{
					this.alignX_0 = Class378.smethod_26(string_0);
					this.alignY_0 = Class378.smethod_27(string_0);
				}
				this.bool_0 = Class378.smethod_25(string_0);
			}
			this.rectangleF_1 = rectangleF_2;
		}

		internal Class387(RectangleF rectangleF_2, RectangleF rectangleF_3, AlignX alignX_1, AlignY alignY_1)
		{
			this.rectangleF_0 = rectangleF_2;
			this.rectangleF_1 = rectangleF_3;
			this.alignX_0 = alignX_1;
			this.alignY_0 = alignY_1;
		}

		public void ApplyTransformation(GraphicsPath graphicsPath, ref GraphicsPath clipPath)
		{
		}

		internal float method_0(Graphics graphics_0, GraphicsPath graphicsPath_0, out RectangleF rectangleF_2, ref GraphicsPath graphicsPath_1)
		{
			float num = this.rectangleF_1.Width / this.rectangleF_1.Height;
			float num2 = this.rectangleF_0.Width / this.rectangleF_0.Height;
			bool flag = (this.bool_0 ? (num <= num2) : (num >= num2));
			bool flag2 = (this.bool_0 ? (num >= num2) : (num <= num2));
			Matrix matrix = new Matrix();
			float num3 = ((flag || this.alignX_0 == AlignX.Stretch) ? (this.rectangleF_1.Width / this.rectangleF_0.Width) : (this.rectangleF_1.Height / this.rectangleF_0.Height));
			float num4 = ((flag2 || this.alignY_0 == AlignY.Stretch) ? (this.rectangleF_1.Height / this.rectangleF_0.Height) : (this.rectangleF_1.Width / this.rectangleF_0.Width));
			float num5;
			if (flag)
			{
				num5 = this.rectangleF_1.X / num3 - this.rectangleF_0.Left;
			}
			else
			{
				switch (this.alignX_0)
				{
				default:
					throw new NotSupportedException("");
				case AlignX.Stretch:
				case AlignX.Left:
					num5 = this.rectangleF_1.X / num3 - this.rectangleF_0.Left;
					break;
				case AlignX.Center:
					num5 = this.rectangleF_1.X / num3 - this.rectangleF_0.Left + this.rectangleF_1.Width / 2f / num3 - this.rectangleF_0.Width / 2f;
					break;
				case AlignX.Right:
					num5 = this.rectangleF_1.Right / num3 - this.rectangleF_0.Right;
					break;
				}
			}
			num5 *= num3;
			float num6;
			if (flag2)
			{
				num6 = this.rectangleF_1.Y / num4 - this.rectangleF_0.Top;
			}
			else
			{
				switch (this.alignY_0)
				{
				default:
					throw new NotSupportedException("");
				case AlignY.Stretch:
				case AlignY.Top:
					num6 = this.rectangleF_1.Y / num4 - this.rectangleF_0.Top;
					break;
				case AlignY.Center:
					num6 = this.rectangleF_1.Y / num4 - this.rectangleF_0.Top + this.rectangleF_1.Height / 2f / num4 - this.rectangleF_0.Height / 2f;
					break;
				case AlignY.Bottom:
					num6 = this.rectangleF_1.Bottom / num4 - this.rectangleF_0.Bottom;
					break;
				}
			}
			num6 *= num4;
			matrix.Translate(num5, num6);
			matrix.Scale(num3, num4);
			graphicsPath_0.Transform(matrix);
			rectangleF_2 = new RectangleF(this.rectangleF_0.X + num5, this.rectangleF_0.Y + num6, this.rectangleF_0.Width * num3, this.rectangleF_0.Height * num4);
			if (graphicsPath_1 == null)
			{
				graphicsPath_1 = new GraphicsPath();
				graphicsPath_1.AddRectangle(this.rectangleF_1);
			}
			else
			{
				Matrix matrix2 = new Matrix();
				matrix2.Translate(this.rectangleF_1.X, this.rectangleF_1.Y);
				RectangleF bounds = graphicsPath_1.GetBounds();
				num3 = Math.Min(num3, this.rectangleF_1.Width / bounds.Right);
				num4 = Math.Min(this.rectangleF_1.Height / bounds.Bottom, num4);
				matrix2.Scale(num3, num4);
				graphicsPath_1.Transform(matrix2);
			}
			if (flag2)
			{
				return num4;
			}
			return num3;
		}
	}
}
