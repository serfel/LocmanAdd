using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.CompilerServices;
using ns17;

namespace TXTextControl.Drawing
{
	internal static class DrawHelper
	{
		internal struct Struct31
		{
			private const int int_0 = -333;

			private const int int_1 = 500;

			private const int int_2 = -50;

			private const int int_3 = 240;

			private const int int_4 = 240;

			private const int int_5 = 255;

			private const int int_6 = 160;

			private int int_7;

			private int int_8;

			private int int_9;

			public int Int32_0 => this.int_7;

			public int Int32_1 => this.int_9;

			public int Int32_2 => this.int_8;

			public Struct31(Color color_0)
			{
				int r = color_0.R;
				int g = color_0.G;
				int b = color_0.B;
				int num = Math.Max(Math.Max(r, g), b);
				int num2 = Math.Min(Math.Min(r, g), b);
				int num3 = num + num2;
				this.int_9 = (num3 * 240 + 255) / 510;
				int num4 = num - num2;
				if (num4 == 0)
				{
					this.int_8 = 0;
					this.int_7 = 160;
					return;
				}
				if (this.int_9 <= 120)
				{
					this.int_8 = (num4 * 240 + num3 / 2) / num3;
				}
				else
				{
					this.int_8 = (num4 * 240 + (510 - num3) / 2) / (510 - num3);
				}
				int num5 = ((num - r) * 40 + num4 / 2) / num4;
				int num6 = ((num - g) * 40 + num4 / 2) / num4;
				int num7 = ((num - b) * 40 + num4 / 2) / num4;
				if (r == num)
				{
					this.int_7 = num7 - num6;
				}
				else if (g == num)
				{
					this.int_7 = 80 + num5 - num7;
				}
				else
				{
					this.int_7 = 160 + num6 - num5;
				}
				if (this.int_7 < 0)
				{
					this.int_7 += 240;
				}
				if (this.int_7 > 240)
				{
					this.int_7 -= 240;
				}
			}

			public Color method_0(float float_0)
			{
				int num = this.method_2(-333, bool_0: true);
				return Struct31.smethod_3(this.int_7, num - (int)((float)(num - 0) * float_0), this.int_8);
			}

			[SpecialName]
			public static bool smethod_0(Struct31 struct31_0, Struct31 struct31_1)
			{
				return struct31_0.Equals(struct31_1);
			}

			[SpecialName]
			public static bool smethod_1(Struct31 struct31_0, Struct31 struct31_1)
			{
				return !struct31_0.Equals(struct31_1);
			}

			public override bool Equals(object obj)
			{
				if (!(obj is Struct31))
				{
					return false;
				}
				Struct31 @struct = (Struct31)obj;
				if (this.int_7 == @struct.int_7 && this.int_8 == @struct.int_8)
				{
					return this.int_9 == @struct.int_9;
				}
				return false;
			}

			public override int GetHashCode()
			{
				return (this.int_7 << 6) | (this.int_8 << 2) | this.int_9;
			}

			public Color method_1(float float_0)
			{
				int num = this.int_9;
				int num2 = this.method_2(500, bool_0: true);
				return Struct31.smethod_3(this.int_7, num + (int)((float)(num2 - num) * float_0), this.int_8);
			}

			private int method_2(int int_10, bool bool_0)
			{
				return Struct31.smethod_2(this.int_9, int_10, bool_0);
			}

			private static int smethod_2(int int_10, int int_11, bool bool_0)
			{
				if (int_11 == 0)
				{
					return int_10;
				}
				if (bool_0)
				{
					if (int_11 > 0)
					{
						return (int)((int_10 * (1000 - int_11) + 241L * int_11) / 1000L);
					}
					return int_10 * (int_11 + 1000) / 1000;
				}
				int num = int_10;
				num += (int)(int_11 * 240L / 1000L);
				if (num < 0)
				{
					num = 0;
				}
				if (num > 240)
				{
					num = 240;
				}
				return num;
			}

			public static Color smethod_3(int int_10, int int_11, int int_12)
			{
				byte red;
				byte green;
				byte blue;
				if (int_12 == 0)
				{
					red = (green = (blue = (byte)(int_11 * 255 / 240)));
					if (int_10 == 160)
					{
					}
				}
				else
				{
					int num = ((int_11 > 120) ? (int_11 + int_12 - (int_11 * int_12 + 120) / 240) : ((int_11 * (240 + int_12) + 120) / 240));
					int int_13 = 2 * int_11 - num;
					red = (byte)((Struct31.smethod_4(int_13, num, int_10 + 80) * 255 + 120) / 240);
					green = (byte)((Struct31.smethod_4(int_13, num, int_10) * 255 + 120) / 240);
					blue = (byte)((Struct31.smethod_4(int_13, num, int_10 - 80) * 255 + 120) / 240);
				}
				return Color.FromArgb(red, green, blue);
			}

			private static int smethod_4(int int_10, int int_11, int int_12)
			{
				if (int_12 < 0)
				{
					int_12 += 240;
				}
				if (int_12 > 240)
				{
					int_12 -= 240;
				}
				if (int_12 < 40)
				{
					return int_10 + ((int_11 - int_10) * int_12 + 20) / 40;
				}
				if (int_12 < 120)
				{
					return int_11;
				}
				if (int_12 < 160)
				{
					return int_10 + ((int_11 - int_10) * (160 - int_12) + 20) / 40;
				}
				return int_10;
			}

			public override string ToString()
			{
				return this.int_7 + ", " + this.int_9 + ", " + this.int_8;
			}
		}

		internal static Class177 ArcTo(GraphicsPath graphicsPath_0, double ellipseWidth, double ellipseHeight, double angleStart, double angleSweep, Class177 currentPathEndLocation)
		{
			if (ellipseWidth != 0.0 && ellipseHeight != 0.0)
			{
				Class179 ellipseSize = new Class179(ellipseWidth, ellipseHeight, bool_1: true);
				return DrawHelper.ArcTo(graphicsPath_0, currentPathEndLocation, ellipseSize, new Class177(angleStart, angleSweep, bool_1: false));
			}
			return currentPathEndLocation;
		}

		private static Class177 ArcTo(GraphicsPath graphicsPath_0, Class177 currentPathEndLocation, Class179 ellipseSize, Class177 angles)
		{
			double num = angles.Double_0 / 60000.0;
			double num2 = angles.Double_1 / 60000.0;
			double angle = (angles.Double_0 + angles.Double_1) / 60000.0;
			Class177 pointOnElipse = MeasuringHelper.GetPointOnElipse(num, ellipseSize.Double_3, ellipseSize.Double_2, isEmu: true);
			Class177 pointOnElipse2 = MeasuringHelper.GetPointOnElipse(angle, ellipseSize.Double_3, ellipseSize.Double_2, isEmu: true);
			pointOnElipse2.method_1(0.0 - pointOnElipse.Double_2, 0.0 - pointOnElipse.Double_3);
			pointOnElipse2.method_1(currentPathEndLocation.Double_2, currentPathEndLocation.Double_3);
			Class177 @class = new Class177(currentPathEndLocation.Double_2 - pointOnElipse.Double_2, currentPathEndLocation.Double_3 - pointOnElipse.Double_3, bool_1: true);
			graphicsPath_0.AddArc(new RectangleF(new PointF((float)@class.Double_2, (float)@class.Double_3), new SizeF((float)ellipseSize.Double_3 * 2f, (float)ellipseSize.Double_2 * 2f)), (float)num, (float)num2);
			return pointOnElipse2;
		}

		internal static void Close(GraphicsPath graphicsPath_0)
		{
			graphicsPath_0.CloseFigure();
		}

		internal static Class177 CubicBezTo(GraphicsPath graphicsPath_0, Class177 point1, Class177 point2, Class177 point3, Class177 point4)
		{
			graphicsPath_0.AddBezier(new PointF((float)point1.Double_2, (float)point1.Double_3), new PointF((float)point2.Double_2, (float)point2.Double_3), new PointF((float)point3.Double_2, (float)point3.Double_3), new PointF((float)point4.Double_2, (float)point4.Double_3));
			return point4;
		}

		internal static Class177 LnTo(GraphicsPath graphicsPath_0, double startX, double startY, double endX, double endY)
		{
			Class177 @class = new Class177(startX, startY, bool_1: true);
			Class177 class2 = new Class177(endX, endY, bool_1: true);
			graphicsPath_0.AddLine(new Point((int)@class.Double_2, (int)@class.Double_3), new Point((int)class2.Double_2, (int)class2.Double_3));
			return class2;
		}

		internal static Class177 MoveTo(double x, double y)
		{
			return new Class177(x, y, bool_1: true);
		}

		internal static Class177 MoveTo(double x, double y, GraphicsPath graphicsPath_0, Class175 pathHelper, out GraphicsPath newGraphicPath)
		{
			pathHelper.List_0.Add(graphicsPath_0);
			newGraphicPath = DrawHelper.PathBegin();
			return new Class177(x, y, bool_1: true);
		}

		internal static GraphicsPath PathBegin()
		{
			return new GraphicsPath();
		}

		internal static void FillPathes(Graphics graphics_0, Shape shape, Class175 pathHelper, Matrix translateMatrix)
		{
			if (pathHelper.Enum32_0 == Enum32.const_4)
			{
				return;
			}
			foreach (GraphicsPath item in pathHelper.List_0)
			{
				GraphicsPath graphicsPath2 = (GraphicsPath)item.Clone();
				graphicsPath2.Transform(translateMatrix);
				graphics_0.FillPath(new SolidBrush(DrawHelper.GetColor(shape.ShapeFill.Color, pathHelper.Enum32_0)), graphicsPath2);
			}
		}

		internal static void DrawPathes(Graphics graphics_0, Shape shape, Class175 pathHelper, Matrix translateMatrix, Pen penToUse)
		{
			if (!pathHelper.Boolean_0)
			{
				return;
			}
			foreach (GraphicsPath item in pathHelper.List_0)
			{
				GraphicsPath graphicsPath2 = (GraphicsPath)item.Clone();
				graphicsPath2.Transform(translateMatrix);
				graphics_0.DrawPath(penToUse, graphicsPath2);
			}
		}

		private static Color GetColor(Color normColor, Enum32 fillMode)
		{
			return fillMode switch
			{
				Enum32.const_0 => Color.FromArgb(normColor.A, new Struct31(normColor).method_0(-0.1f)), 
				Enum32.const_1 => Color.FromArgb(normColor.A, new Struct31(normColor).method_0(-0.2f)), 
				Enum32.const_2 => Color.FromArgb(normColor.A, new Struct31(normColor).method_1(0.81f)), 
				Enum32.const_3 => Color.FromArgb(normColor.A, new Struct31(normColor).method_1(0.4f)), 
				_ => normColor, 
			};
		}

		private static int CalculateColorValue(int colorValue, double dBrightnessFactor)
		{
			if (dBrightnessFactor > 1.0)
			{
				return (int)Math.Min(255.0, (double)colorValue * dBrightnessFactor);
			}
			return (int)Math.Max(0.0, (double)colorValue * dBrightnessFactor);
		}

		internal static Class177 QuadBezTo(GraphicsPath graphicsPath_0, Class177 point1, Class177 controlPoint, Class177 point4)
		{
			Class177 @class = new Class177(controlPoint.Double_2 * 2.0 / 3.0 + point1.Double_2 / 3.0, controlPoint.Double_3 * 2.0 / 3.0 + point1.Double_3 / 3.0, bool_1: true);
			Class177 class2 = new Class177(controlPoint.Double_2 * 2.0 / 3.0 + point4.Double_2 / 3.0, controlPoint.Double_3 * 2.0 / 3.0 + point4.Double_3 / 3.0, bool_1: true);
			graphicsPath_0.AddBezier(new PointF((float)point1.Double_2, (float)point1.Double_3), new PointF((float)@class.Double_2, (float)@class.Double_3), new PointF((float)class2.Double_2, (float)class2.Double_3), new PointF((float)point4.Double_2, (float)point4.Double_3));
			return point4;
		}

		internal static RectangleF TwipsRectToPixel(object rectangle)
		{
			double num;
			double num2;
			double num3;
			double num4;
			if (rectangle is Class178)
			{
				num = MeasuringHelper.Twips2Pixels(((Class178)rectangle).Double_0, 100);
				num2 = MeasuringHelper.Twips2Pixels(((Class178)rectangle).Double_1, 100);
				num3 = MeasuringHelper.Twips2Pixels(((Class178)rectangle).Double_3, 100);
				num4 = MeasuringHelper.Twips2Pixels(((Class178)rectangle).Double_2, 100);
			}
			else
			{
				num = MeasuringHelper.Twips2Pixels(((Class173)rectangle).Double_2, 100);
				num2 = MeasuringHelper.Twips2Pixels(((Class173)rectangle).Double_3, 100);
				num3 = MeasuringHelper.Twips2Pixels(((Class173)rectangle).Double_1, 100);
				num4 = MeasuringHelper.Twips2Pixels(((Class173)rectangle).Double_0, 100);
			}
			return new RectangleF((float)num, (float)num2, (float)num3, (float)num4);
		}
	}
}
