using System;
using ns17;

namespace TXTextControl.Drawing
{
	internal static class MeasuringHelper
	{
		internal enum Enum33
		{
			const_0 = 1,
			const_1,
			const_2,
			const_3,
			const_4,
			const_5,
			const_6
		}

		internal static int DotNet2Tw(double val, Enum33 unit)
		{
			return unit switch
			{
				Enum33.const_0 => MeasuringHelper.In2Tw(val), 
				Enum33.const_1 => MeasuringHelper.WPF2Tw(val), 
				Enum33.const_2 => (int)Math.Round(val), 
				Enum33.const_3 => MeasuringHelper.mm2Tw(val), 
				Enum33.const_4 => MeasuringHelper.cm2Tw(val), 
				Enum33.const_5 => (int)Math.Round(val * 20.0), 
				_ => 0, 
			};
		}

		internal static int In2Tw(double val)
		{
			return (int)Math.Round(val * 14.4);
		}

		internal static int mm2Tw(double val)
		{
			return (int)Math.Round(val * 1440.0 / 25.4);
		}

		internal static int cm2Tw(double val)
		{
			return (int)Math.Round(val * 1440.0 / 2.54);
		}

		internal static int WPF2Tw(double val)
		{
			return (int)Math.Round(val * 15.0);
		}

		internal static double Tw2DotNet(double val, Enum33 unit)
		{
			return MeasuringHelper.Tw2DotNet(val, unit, 2);
		}

		internal static double Tw2DotNet(double val, Enum33 unit, int iDecimals)
		{
			return unit switch
			{
				Enum33.const_0 => val * 10.0 / 144.0, 
				Enum33.const_1 => val / 15.0, 
				Enum33.const_2 => val, 
				Enum33.const_3 => val * 25.4 / 1440.0, 
				Enum33.const_4 => val * 2.54 / 1440.0, 
				Enum33.const_5 => val / 20.0, 
				_ => 0.0, 
			};
		}

		internal static int WPF2Pt(double val)
		{
			return (int)Math.Round(val * 3.0 / 4.0);
		}

		internal static Class177 GetPointOnElipse(double angle, double elipseWidth, double elipseHeight, bool isEmu)
		{
			double num = angle * Math.PI / 180.0;
			double num2 = Math.Atan2(Math.Sin(num), Math.Cos(num) * (elipseHeight / elipseWidth));
			double num3 = Math.Cos(num2) * elipseWidth;
			double num4 = Math.Sin(num2) * elipseHeight;
			return new Class177(elipseWidth + num3, elipseHeight + num4, isEmu);
		}

		internal static Class177 GetPointOnElipse(double angle, double radius)
		{
			double num = angle * Math.PI / 180.0;
			double double_ = Math.Cos(num) * radius;
			double double_2 = Math.Sin(num) * radius;
			return new Class177(double_, double_2, bool_1: false);
		}

		internal static double EMU2Twips(double emu)
		{
			return emu / 12700.0 * 20.0;
		}

		internal static double Twips2EMU(double twips)
		{
			return twips / 20.0 * 12700.0;
		}

		internal static double ZoomValue(double value, int zoomFactor, bool viseVersa)
		{
			if (!viseVersa)
			{
				return value * (double)zoomFactor / 100.0;
			}
			return value * 100.0 / (double)zoomFactor;
		}

		internal static double Twips2Pixels(double twips, int zoomFactor)
		{
			return MeasuringHelper.ZoomValue(twips * 0.00069444444444444447 * (double)Helper.DPI, zoomFactor, viseVersa: false);
		}

		internal static double Pixel2Twips(double pixel, int zoomFactor)
		{
			return MeasuringHelper.ZoomValue(pixel * 1440.0 / (double)Helper.DPI, zoomFactor, viseVersa: true);
		}

		internal static double Pixel2Twips(double pixel, int zoomFactor, double dpi)
		{
			return MeasuringHelper.ZoomValue(pixel * 1440.0 / dpi, zoomFactor, viseVersa: true);
		}

		internal static bool AreEqual(Class177[] pointsA, Class177[] pointsB)
		{
			if (pointsA.Length == pointsB.Length)
			{
				int num = 0;
				while (true)
				{
					if (num < pointsA.Length)
					{
						if (!pointsA[num].method_3(pointsB[num]))
						{
							break;
						}
						num++;
						continue;
					}
					return true;
				}
				return false;
			}
			return false;
		}

		internal static bool AreEqual(double[] doubleArrayA, double[] doubleArrayB)
		{
			if (doubleArrayA.Length == doubleArrayB.Length)
			{
				int num = 0;
				while (true)
				{
					if (num < doubleArrayA.Length)
					{
						if (doubleArrayA[num] != doubleArrayB[num])
						{
							break;
						}
						num++;
						continue;
					}
					return true;
				}
				return false;
			}
			return false;
		}

		internal static Class177 ConsiderAngle(Class177 shapePointCorner, Class177 rotationCenter, double sweepAngle)
		{
			Class177 @class = new Class177(shapePointCorner.Double_0 - rotationCenter.Double_0, shapePointCorner.Double_1 - rotationCenter.Double_1, bool_1: false);
			double num = sweepAngle * Math.PI / 180.0;
			double num2 = @class.Double_0 * Math.Cos(num) - @class.Double_1 * Math.Sin(num);
			double num3 = @class.Double_0 * Math.Sin(num) + @class.Double_1 * Math.Cos(num);
			return new Class177(num2 + rotationCenter.Double_0, num3 + rotationCenter.Double_1, bool_1: false);
		}

		internal static double[] GetMaxBoundsOffset(Class177[] realBounds, Class178 borderBounds, double angle)
		{
			Class177 @class = realBounds[0];
			Class177 class2 = realBounds[1];
			Class177 class3 = realBounds[2];
			Class177 class4 = realBounds[3];
			double num = angle % 360.0;
			double[] array = new double[2];
			double[] array2 = new double[2];
			if (num < 90.0)
			{
				array = MeasuringHelper.CalculateMaxHorizontalOffset(@class, class2, class3, class4, borderBounds.Double_9, borderBounds.Double_11, borderBounds.Double_10, borderBounds.Double_8, borderBounds.Class179_0);
				array2 = MeasuringHelper.CalculateMaxVerticalOffset(@class, class3, class2, class4, borderBounds.Double_9, borderBounds.Double_11, borderBounds.Double_10, borderBounds.Double_8, borderBounds.Class179_0);
			}
			else if (num < 180.0)
			{
				array = MeasuringHelper.CalculateMaxHorizontalOffset(class3, class4, @class, class2, borderBounds.Double_10, borderBounds.Double_11, borderBounds.Double_9, borderBounds.Double_8, borderBounds.Class179_0);
				array2 = MeasuringHelper.CalculateMaxVerticalOffset(class2, class4, @class, class3, borderBounds.Double_9, borderBounds.Double_8, borderBounds.Double_10, borderBounds.Double_11, borderBounds.Class179_0);
			}
			else if (num < 270.0)
			{
				array = MeasuringHelper.CalculateMaxHorizontalOffset(@class, class2, class3, class4, borderBounds.Double_10, borderBounds.Double_8, borderBounds.Double_9, borderBounds.Double_11, borderBounds.Class179_0);
				array2 = MeasuringHelper.CalculateMaxVerticalOffset(@class, class3, class2, class4, borderBounds.Double_10, borderBounds.Double_8, borderBounds.Double_9, borderBounds.Double_11, borderBounds.Class179_0);
			}
			else
			{
				array = MeasuringHelper.CalculateMaxHorizontalOffset(class3, class4, @class, class2, borderBounds.Double_9, borderBounds.Double_8, borderBounds.Double_10, borderBounds.Double_11, borderBounds.Class179_0);
				array2 = MeasuringHelper.CalculateMaxVerticalOffset(class2, class4, @class, class3, borderBounds.Double_10, borderBounds.Double_11, borderBounds.Double_9, borderBounds.Double_8, borderBounds.Class179_0);
			}
			return new double[4]
			{
				Math.Round(array[0], MidpointRounding.AwayFromZero),
				Math.Round(array2[0], MidpointRounding.AwayFromZero),
				Math.Round(array[1], MidpointRounding.AwayFromZero),
				Math.Round(array2[1], MidpointRounding.AwayFromZero)
			};
		}

		private static double[] CalculateMaxVerticalOffset(Class177 class177_0, Class177 class177_1, Class177 class177_2, Class177 class177_3, double left, double top, double right, double bottom, Class179 canvasSize)
		{
			double[] array = new double[2];
			bool flag = class177_0.Double_1 < Math.Min(top, bottom);
			bool flag2 = class177_3.Double_1 > Math.Max(top, bottom);
			Class177 class177_4 = new Class177(MeasuringHelper.CalculateX(top, class177_0, class177_1), top, bool_1: false);
			Class177 class177_5 = new Class177(right, MeasuringHelper.CalculateY(right, class177_2, class177_3), bool_1: false);
			double distance = MeasuringHelper.GetDistance(class177_0, class177_4);
			distance = (double.IsNaN(distance) ? double.MaxValue : distance);
			double distance2 = MeasuringHelper.GetDistance(class177_2, class177_5);
			distance2 = (double.IsNaN(distance2) ? double.MaxValue : distance2);
			array[0] = Math.Min(distance, distance2);
			Class177 class177_6 = new Class177(left, MeasuringHelper.CalculateY(left, class177_0, class177_1), bool_1: false);
			Class177 class177_7 = new Class177(MeasuringHelper.CalculateX(bottom, class177_2, class177_3), bottom, bool_1: false);
			distance = MeasuringHelper.GetDistance(class177_1, class177_6);
			distance = (double.IsNaN(distance) ? double.MaxValue : distance);
			distance2 = MeasuringHelper.GetDistance(class177_3, class177_7);
			distance2 = (double.IsNaN(distance2) ? double.MaxValue : distance2);
			array[1] = Math.Min(distance, distance2);
			array[0] = (flag ? (0.0 - array[0]) : array[0]);
			array[1] = (flag2 ? (0.0 - array[1]) : array[1]);
			return array;
		}

		private static double[] CalculateMaxHorizontalOffset(Class177 class177_0, Class177 class177_1, Class177 class177_2, Class177 class177_3, double left, double top, double right, double bottom, Class179 canvasSize)
		{
			double[] array = new double[2];
			bool flag = class177_2.Double_0 < Math.Min(left, right);
			bool flag2 = class177_1.Double_0 > Math.Max(left, right);
			Class177 class177_4 = new Class177(MeasuringHelper.CalculateX(top, class177_0, class177_1), top, bool_1: false);
			Class177 class177_5 = new Class177(left, MeasuringHelper.CalculateY(left, class177_2, class177_3), bool_1: false);
			double distance = MeasuringHelper.GetDistance(class177_0, class177_4);
			distance = (double.IsNaN(distance) ? double.MaxValue : distance);
			double distance2 = MeasuringHelper.GetDistance(class177_2, class177_5);
			distance2 = (double.IsNaN(distance2) ? double.MaxValue : distance2);
			array[0] = Math.Min(distance, distance2);
			Class177 class177_6 = new Class177(right, MeasuringHelper.CalculateY(right, class177_0, class177_1), bool_1: false);
			Class177 class177_7 = new Class177(MeasuringHelper.CalculateX(bottom, class177_2, class177_3), bottom, bool_1: false);
			double distance3 = MeasuringHelper.GetDistance(class177_1, class177_6);
			distance3 = (double.IsNaN(distance3) ? double.MaxValue : distance3);
			double distance4 = MeasuringHelper.GetDistance(class177_3, class177_7);
			distance4 = (double.IsNaN(distance4) ? double.MaxValue : distance4);
			array[1] = Math.Min(distance3, distance4);
			array[0] = (flag ? (0.0 - array[0]) : array[0]);
			array[1] = (flag2 ? (0.0 - array[1]) : array[1]);
			return array;
		}

		private static double GetDistance(Class177 class177_0, Class177 class177_1)
		{
			return Math.Sqrt(Math.Pow(Math.Abs(class177_0.Double_0 - class177_1.Double_0), 2.0) + Math.Pow(Math.Abs(class177_0.Double_1 - class177_1.Double_1), 2.0));
		}

		private static double CalculateY(double x, Class177 class177_0, Class177 class177_1)
		{
			return (class177_0.Double_1 - class177_1.Double_1) * (x - class177_1.Double_0) / (class177_0.Double_0 - class177_1.Double_0) + class177_1.Double_1;
		}

		private static double CalculateX(double y, Class177 class177_0, Class177 class177_1)
		{
			return (class177_0.Double_0 - class177_1.Double_0) * (y - class177_1.Double_1) / (class177_0.Double_1 - class177_1.Double_1) + class177_1.Double_0;
		}

		internal static double GetSpecificX(double specificX, double y, double angle)
		{
			return (specificX - y * Math.Sin(angle)) / Math.Cos(angle);
		}
	}
}
