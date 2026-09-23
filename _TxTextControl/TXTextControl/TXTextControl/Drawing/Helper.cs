using System;
using ns17;

namespace TXTextControl.Drawing
{
	internal static class Helper
	{
		internal static int DPI { get; set; }

		internal static double FmlaMultiplyDivide(double x, double y, double z)
		{
			return x * y / z;
		}

		internal static double FmlaAddSubtract(double x, double y, double z)
		{
			return x + y - z;
		}

		internal static double FmlaAddDivide(double x, double y, double z)
		{
			return (x + y) / z;
		}

		internal static double FmlaIfElse(double x, double y, double z)
		{
			if (x > 0.0)
			{
				return y;
			}
			return z;
		}

		internal static double FmlaAbsoluteValue(double x)
		{
			if (x < 0.0)
			{
				return -1.0 * x;
			}
			return x;
		}

		internal static double FmlaArcTan(double x, double y)
		{
			return Math.Atan2(y, x) * (180.0 / Math.PI) * 60000.0;
		}

		internal static double FmlaCosineArcTan(double x, double y, double z)
		{
			double num = Helper.FmlaArcTan(y, z) / 60000.0;
			double num2 = Math.Cos(num * (Math.PI / 180.0));
			return x * num2;
		}

		internal static double FmlaCosine(double x, double y)
		{
			return x * Math.Cos(y / 60000.0 * (Math.PI / 180.0));
		}

		internal static double FmlaMaximumValue(double x, double y)
		{
			return Math.Max(x, y);
		}

		internal static double FmlaMinimumValue(double x, double y)
		{
			return Math.Min(x, y);
		}

		internal static double FmlaModulo(double x, double y, double z)
		{
			return Math.Sqrt(Math.Pow(x, 2.0) + Math.Pow(y, 2.0) + Math.Pow(z, 2.0));
		}

		internal static double FmlaPinTo(double x, double y, double z)
		{
			if (y < x)
			{
				return x;
			}
			if (y > z)
			{
				return z;
			}
			return y;
		}

		internal static double FmlaSineArcTan(double x, double y, double z)
		{
			double num = Helper.FmlaArcTan(y, z) / 60000.0;
			double num2 = Math.Sin(num * (Math.PI / 180.0));
			return x * num2;
		}

		internal static double FmlaSine(double x, double y)
		{
			return x * Math.Sin(y / 60000.0 * (Math.PI / 180.0));
		}

		internal static double FmlaSquareRoot(double x)
		{
			return Math.Sqrt(x);
		}

		internal static double FmlaTangent(double x, double y)
		{
			return x * Math.Tan(y / 60000.0 * (Math.PI / 180.0));
		}

		internal static double FmlaLiteralValue(double x)
		{
			return x;
		}

		internal static double GetDrawingMLEnumValue(string DrawingMLEnum, Shape shape)
		{
			switch (DrawingMLEnum)
			{
			case "3cd4":
				return 16200000.0;
			case "3cd8":
				return 8100000.0;
			case "5cd8":
				return 13500000.0;
			case "7cd8":
				return 18900000.0;
			case "b":
				return shape.Class183_0.Class179_0.Double_0;
			case "cd2":
				return 10800000.0;
			case "cd4":
				return 5400000.0;
			case "cd8":
				return 2700000.0;
			case "h":
				return shape.Class183_0.Class179_0.Double_0;
			case "hc":
				return Helper.FmlaMultiplyDivide(shape.Class183_0.Class179_0.Double_1, 1.0, 2.0);
			case "hd2":
				return Helper.FmlaMultiplyDivide(shape.Class183_0.Class179_0.Double_0, 1.0, 2.0);
			case "hd3":
				return Helper.FmlaMultiplyDivide(shape.Class183_0.Class179_0.Double_0, 1.0, 3.0);
			case "hd4":
				return Helper.FmlaMultiplyDivide(shape.Class183_0.Class179_0.Double_0, 1.0, 4.0);
			case "hd5":
				return Helper.FmlaMultiplyDivide(shape.Class183_0.Class179_0.Double_0, 1.0, 5.0);
			case "hd6":
				return Helper.FmlaMultiplyDivide(shape.Class183_0.Class179_0.Double_0, 1.0, 6.0);
			case "hd8":
				return Helper.FmlaMultiplyDivide(shape.Class183_0.Class179_0.Double_0, 1.0, 8.0);
			case "hd10":
				return Helper.FmlaMultiplyDivide(shape.Class183_0.Class179_0.Double_0, 1.0, 10.0);
			case "hd12":
				return Helper.FmlaMultiplyDivide(shape.Class183_0.Class179_0.Double_0, 1.0, 12.0);
			case "hd32":
				return Helper.FmlaMultiplyDivide(shape.Class183_0.Class179_0.Double_0, 1.0, 32.0);
			case "l":
				return 0.0;
			case "ls":
				return Helper.FmlaMaximumValue(shape.Class183_0.Class179_0.Double_1, shape.Class183_0.Class179_0.Double_0);
			case "r":
				return shape.Class183_0.Class179_0.Double_1;
			case "ss":
				return Helper.FmlaMinimumValue(shape.Class183_0.Class179_0.Double_1, shape.Class183_0.Class179_0.Double_0);
			case "ssd2":
			{
				double x = Helper.FmlaMinimumValue(shape.Class183_0.Class179_0.Double_1, shape.Class183_0.Class179_0.Double_0);
				return Helper.FmlaMultiplyDivide(x, 1.0, 2.0);
			}
			case "ssd4":
				return Helper.FmlaMultiplyDivide(Helper.FmlaMinimumValue(shape.Class183_0.Class179_0.Double_1, shape.Class183_0.Class179_0.Double_0), 1.0, 4.0);
			case "ssd6":
				return Helper.FmlaMultiplyDivide(Helper.FmlaMinimumValue(shape.Class183_0.Class179_0.Double_1, shape.Class183_0.Class179_0.Double_0), 1.0, 6.0);
			case "ssd8":
				return Helper.FmlaMultiplyDivide(Helper.FmlaMinimumValue(shape.Class183_0.Class179_0.Double_1, shape.Class183_0.Class179_0.Double_0), 1.0, 8.0);
			case "ssd16":
				return Helper.FmlaMultiplyDivide(Helper.FmlaMinimumValue(shape.Class183_0.Class179_0.Double_1, shape.Class183_0.Class179_0.Double_0), 1.0, 16.0);
			case "ssd32":
				return Helper.FmlaMultiplyDivide(Helper.FmlaMinimumValue(shape.Class183_0.Class179_0.Double_1, shape.Class183_0.Class179_0.Double_0), 1.0, 32.0);
			case "t":
				return 0.0;
			case "vc":
				return Helper.FmlaMultiplyDivide(shape.Class183_0.Class179_0.Double_0, 1.0, 2.0);
			case "w":
				return shape.Class183_0.Class179_0.Double_1;
			case "wd2":
				return Helper.FmlaMultiplyDivide(shape.Class183_0.Class179_0.Double_1, 1.0, 2.0);
			case "wd3":
				return Helper.FmlaMultiplyDivide(shape.Class183_0.Class179_0.Double_1, 1.0, 3.0);
			case "wd4":
				return Helper.FmlaMultiplyDivide(shape.Class183_0.Class179_0.Double_1, 1.0, 4.0);
			case "wd5":
				return Helper.FmlaMultiplyDivide(shape.Class183_0.Class179_0.Double_1, 1.0, 5.0);
			case "wd6":
				return Helper.FmlaMultiplyDivide(shape.Class183_0.Class179_0.Double_1, 1.0, 6.0);
			case "wd8":
				return Helper.FmlaMultiplyDivide(shape.Class183_0.Class179_0.Double_1, 1.0, 8.0);
			case "wd10":
				return Helper.FmlaMultiplyDivide(shape.Class183_0.Class179_0.Double_1, 1.0, 10.0);
			case "wd12":
				return Helper.FmlaMultiplyDivide(shape.Class183_0.Class179_0.Double_1, 1.0, 12.0);
			default:
				throw new ArgumentException();
			case "wd32":
				return Helper.FmlaMultiplyDivide(shape.Class183_0.Class179_0.Double_1, 1.0, 32.0);
			}
		}

		internal static Class179 GetPathSize(ShapeType shapeType)
		{
			return shapeType switch
			{
				ShapeType.IrregularSeal1 => new Class179(21600.0, 21600.0, bool_1: true), 
				ShapeType.IrregularSeal2 => new Class179(21600.0, 21600.0, bool_1: true), 
				ShapeType.LightningBolt => new Class179(21600.0, 21600.0, bool_1: true), 
				ShapeType.ChartX => new Class179(200.0, 200.0, bool_1: false), 
				ShapeType.ChartStar => new Class179(200.0, 200.0, bool_1: false), 
				ShapeType.ChartPlus => new Class179(200.0, 200.0, bool_1: false), 
				ShapeType.CloudCallout => new Class179(43200.0, 43200.0, bool_1: true), 
				ShapeType.Cloud => new Class179(43200.0, 43200.0, bool_1: true), 
				ShapeType.FlowChartProcess => new Class179(20.0, 20.0, bool_1: false), 
				ShapeType.FlowChartDecision => new Class179(40.0, 40.0, bool_1: false), 
				ShapeType.FlowChartInputOutput => new Class179(100.0, 100.0, bool_1: false), 
				ShapeType.FlowChartPredefinedProcess => new Class179(160.0, 160.0, bool_1: false), 
				ShapeType.FlowChartInternalStorage => new Class179(160.0, 160.0, bool_1: false), 
				ShapeType.FlowChartDocument => new Class179(21600.0, 21600.0, bool_1: true), 
				ShapeType.FlowChartMultidocument => new Class179(21600.0, 21600.0, bool_1: true), 
				ShapeType.FlowChartTerminator => new Class179(21600.0, 21600.0, bool_1: true), 
				ShapeType.FlowChartPreparation => new Class179(200.0, 200.0, bool_1: false), 
				ShapeType.FlowChartManualInput => new Class179(100.0, 100.0, bool_1: false), 
				ShapeType.FlowChartManualOperation => new Class179(100.0, 100.0, bool_1: false), 
				ShapeType.FlowChartPunchedCard => new Class179(100.0, 100.0, bool_1: false), 
				ShapeType.FlowChartPunchedTape => new Class179(400.0, 400.0, bool_1: false), 
				ShapeType.FlowChartCollate => new Class179(40.0, 40.0, bool_1: false), 
				ShapeType.FlowChartSort => new Class179(40.0, 40.0, bool_1: false), 
				ShapeType.FlowChartExtract => new Class179(40.0, 40.0, bool_1: false), 
				ShapeType.FlowChartMerge => new Class179(40.0, 40.0, bool_1: false), 
				ShapeType.FlowChartOfflineStorage => new Class179(100.0, 100.0, bool_1: false), 
				ShapeType.FlowChartOnlineStorage => new Class179(120.0, 120.0, bool_1: false), 
				ShapeType.FlowChartMagneticDisk => new Class179(120.0, 120.0, bool_1: false), 
				ShapeType.FlowChartMagneticDrum => new Class179(120.0, 120.0, bool_1: false), 
				ShapeType.FlowChartDisplay => new Class179(120.0, 120.0, bool_1: false), 
				ShapeType.FlowChartOffpageConnector => new Class179(200.0, 200.0, bool_1: false), 
				_ => new Class179(12700.0, 12700.0, bool_1: true), 
			};
		}

		internal static double GetX(Shape shape, int borderOffset, bool asEmu)
		{
			double num = (asEmu ? (shape.Class174_0.Class178_1.Double_4 + MeasuringHelper.Twips2EMU(borderOffset)) : (shape.Class174_0.Class178_1.Double_0 + (double)borderOffset));
			if (shape.Class174_0.Class178_1.Double_7 < 0.0)
			{
				num += (asEmu ? (shape.Class174_0.Class178_1.Double_7 + MeasuringHelper.Twips2EMU(borderOffset)) : (shape.Class174_0.Class178_1.Double_3 + (double)borderOffset));
			}
			return num;
		}

		internal static double GetX(double x, double width)
		{
			if (width < 0.0)
			{
				x += width;
			}
			return x;
		}

		internal static double GetY(Shape shape, int borderOffset, bool asEmu)
		{
			double num = (asEmu ? (shape.Class174_0.Class178_1.Double_5 + MeasuringHelper.Twips2EMU(borderOffset)) : (shape.Class174_0.Class178_1.Double_1 + (double)borderOffset));
			if (shape.Class174_0.Class178_1.Double_6 < 0.0)
			{
				num += (asEmu ? (shape.Class174_0.Class178_1.Double_6 + MeasuringHelper.Twips2EMU(borderOffset)) : (shape.Class174_0.Class178_1.Double_2 + (double)borderOffset));
			}
			return num;
		}

		internal static double GetY(double y, double height)
		{
			if (height < 0.0)
			{
				y += height;
			}
			return y;
		}

		internal static double GetWidth(Shape shape, bool asEmu)
		{
			double num = (asEmu ? shape.Class174_0.Class178_1.Double_7 : shape.Class174_0.Class178_1.Double_3);
			if (num < 0.0)
			{
				num *= -1.0;
			}
			return num;
		}

		internal static double GetWidth(double width)
		{
			if (width < 0.0)
			{
				width *= -1.0;
			}
			return width;
		}

		internal static double GetHeight(Shape shape, bool asEmu)
		{
			double num = (asEmu ? shape.Class174_0.Class178_1.Double_6 : shape.Class174_0.Class178_1.Double_2);
			if (num < 0.0)
			{
				num *= -1.0;
			}
			return num;
		}

		internal static double GetHeight(double height)
		{
			if (height < 0.0)
			{
				height *= -1.0;
			}
			return height;
		}

		internal static Flip GetFlipEnum(double width, double height)
		{
			bool flag = width < 0.0;
			bool flag2 = height < 0.0;
			if (!flag && !flag2)
			{
				return Flip.None;
			}
			if (flag)
			{
				if (flag2)
				{
					return (Flip)3;
				}
				return Flip.Horizontal;
			}
			return Flip.Vertical;
		}

		internal static Flip GetFlipEnum(bool isFlipH, bool isFlipV)
		{
			if (!isFlipH && !isFlipV)
			{
				return Flip.None;
			}
			if (isFlipH)
			{
				if (isFlipV)
				{
					return (Flip)3;
				}
				return Flip.Horizontal;
			}
			return Flip.Vertical;
		}

		internal static Class178 ConvertToValidBounds(Class178 bounds, out Flip flip)
		{
			bool flag = bounds.Double_3 < 0.0;
			bool flag2 = bounds.Double_2 < 0.0;
			double double_ = (flag ? (bounds.Double_0 + bounds.Double_3) : bounds.Double_0);
			double double_2 = (flag2 ? (bounds.Double_1 + bounds.Double_2) : bounds.Double_1);
			double double_3 = (flag ? (0.0 - bounds.Double_3) : bounds.Double_3);
			double double_4 = (flag2 ? (0.0 - bounds.Double_2) : bounds.Double_2);
			flip = Helper.GetFlipEnum(flag, flag2);
			return new Class178(double_, double_2, double_3, double_4, bool_1: false);
		}

		internal static bool AreValidShapeBounds(double canvasWidth, double canvasHeight, Class178 bounds, double[] graphicsOffsetPath)
		{
			if (Helper.IsValidShapeX(canvasWidth, bounds.Double_0, bounds.Double_3, out var correctNewX) && Helper.IsValidShapeY(canvasHeight, bounds.Double_1, bounds.Double_2, out correctNewX) && Helper.IsValidShapeWidth(canvasWidth, bounds.Double_3, bounds.Double_0, out correctNewX) && Helper.IsValidShapeHeight(canvasHeight, bounds.Double_2, bounds.Double_1, out correctNewX))
			{
				return true;
			}
			return false;
		}

		internal static bool IsValidShapeWidth(double canvasWidth, double newWidth, double shapeX, out double correctNewWidth)
		{
			return Helper.IsValidShapeSizeValue(canvasWidth, newWidth, shapeX, out correctNewWidth);
		}

		internal static bool IsValidShapeHeight(double canvasHeight, double newHeight, double shapeY, out double correctNewHeight)
		{
			return Helper.IsValidShapeSizeValue(canvasHeight, newHeight, shapeY, out correctNewHeight);
		}

		internal static bool IsValidShapeSizeValue(double canvaSizeValue, double newSizeValue, double shapeLocationValue, out double correctNewSizeValue)
		{
			bool result = true;
			if (newSizeValue < 0.0)
			{
				result = false;
				correctNewSizeValue = 0.0;
			}
			else if (shapeLocationValue + newSizeValue > canvaSizeValue)
			{
				if (Math.Round(shapeLocationValue + newSizeValue, MidpointRounding.ToEven) > canvaSizeValue)
				{
					result = false;
				}
				correctNewSizeValue = Math.Round(canvaSizeValue - shapeLocationValue, MidpointRounding.ToEven);
			}
			else
			{
				correctNewSizeValue = newSizeValue;
			}
			return result;
		}

		internal static bool IsValidShapeX(double iCanvasWidth, double newX, double shapeWidth, out double correctNewX)
		{
			return Helper.IsValidShapeLocationValue(iCanvasWidth, newX, shapeWidth, out correctNewX);
		}

		internal static bool IsValidShapeY(double canvasHeight, double newY, double shapeHeight, out double correctNewY)
		{
			return Helper.IsValidShapeLocationValue(canvasHeight, newY, shapeHeight, out correctNewY);
		}

		internal static bool IsValidShapeLocationValue(double canvasSizeValue, double newLocationValue, double shapeSizeValue, out double correctNewLocationValue)
		{
			bool result = true;
			if (newLocationValue < 0.0)
			{
				result = false;
				correctNewLocationValue = 0.0;
			}
			else if (newLocationValue + shapeSizeValue > canvasSizeValue)
			{
				if (Math.Round(newLocationValue + shapeSizeValue, MidpointRounding.ToEven) > canvasSizeValue)
				{
					result = false;
				}
				correctNewLocationValue = canvasSizeValue - shapeSizeValue;
			}
			else
			{
				correctNewLocationValue = Math.Round(newLocationValue, MidpointRounding.ToEven);
			}
			return result;
		}

		internal static Class178 UpdateFlip(Class178 bounds, bool isFlipH, bool isFlipV)
		{
			bool flag = isFlipH;
			bool flag2 = isFlipV;
			double num;
			double double_;
			if (flag)
			{
				num = ((bounds.Double_3 > 0.0) ? (0.0 - bounds.Double_3) : bounds.Double_3);
				double_ = ((bounds.Double_3 > 0.0) ? (bounds.Double_0 - num) : bounds.Double_0);
			}
			else
			{
				num = ((bounds.Double_3 < 0.0) ? (0.0 - bounds.Double_3) : bounds.Double_3);
				double_ = ((bounds.Double_3 < 0.0) ? (bounds.Double_0 - num) : bounds.Double_0);
			}
			double num2;
			double double_2;
			if (flag2)
			{
				num2 = ((bounds.Double_2 > 0.0) ? (0.0 - bounds.Double_2) : bounds.Double_2);
				double_2 = ((bounds.Double_2 > 0.0) ? (bounds.Double_1 - num2) : bounds.Double_1);
			}
			else
			{
				num2 = ((bounds.Double_2 < 0.0) ? (0.0 - bounds.Double_2) : bounds.Double_2);
				double_2 = ((bounds.Double_2 < 0.0) ? (bounds.Double_1 - num2) : bounds.Double_1);
			}
			return new Class178(double_, double_2, num, num2, bool_1: false);
		}

		internal static Class178 GetRealBounds(Class178 shapeBounds, Class177 rotationCenter, double angle, out Class177[] ripRealBounds)
		{
			ripRealBounds = new Class177[4];
			ripRealBounds[0] = MeasuringHelper.ConsiderAngle(shapeBounds.Class177_7, rotationCenter, angle);
			ripRealBounds[1] = MeasuringHelper.ConsiderAngle(shapeBounds.Class177_9, rotationCenter, angle);
			ripRealBounds[2] = MeasuringHelper.ConsiderAngle(shapeBounds.Class177_2, rotationCenter, angle);
			ripRealBounds[3] = MeasuringHelper.ConsiderAngle(shapeBounds.Class177_4, rotationCenter, angle);
			double num = double.MaxValue;
			double num2 = double.MinValue;
			double num3 = double.MaxValue;
			double num4 = double.MinValue;
			for (int i = 0; i < ripRealBounds.Length; i++)
			{
				if (ripRealBounds[i].Double_0 < num)
				{
					num = ripRealBounds[i].Double_0;
				}
				if (ripRealBounds[i].Double_0 > num2)
				{
					num2 = ripRealBounds[i].Double_0;
				}
				if (ripRealBounds[i].Double_1 < num3)
				{
					num3 = ripRealBounds[i].Double_1;
				}
				if (ripRealBounds[i].Double_1 > num4)
				{
					num4 = ripRealBounds[i].Double_1;
				}
			}
			return new Class178(Math.Round(num, MidpointRounding.ToEven), Math.Round(num3, MidpointRounding.ToEven), Math.Round(num2 - num, MidpointRounding.ToEven), Math.Round(num4 - num3, MidpointRounding.ToEven), bool_1: false);
		}

		internal static Class178 GetBounds(Shape[] shapes, int zoomFactor)
		{
			if (shapes.Length == 0)
			{
				return null;
			}
			Shape shape = shapes[0];
			shape.Class174_0.method_7();
			double num = shape.Class174_0.Class178_2.Double_9;
			double num2 = shape.Class174_0.Class178_2.Double_11;
			double num3 = shape.Class174_0.Class178_2.Double_10;
			double num4 = shape.Class174_0.Class178_2.Double_8;
			for (int i = 1; i < shapes.Length; i++)
			{
				shape = shapes[i];
				shape.Class174_0.method_7();
				double double_ = shape.Class174_0.Class178_2.Double_9;
				num = ((double_ < num) ? double_ : num);
				double double_2 = shape.Class174_0.Class178_2.Double_11;
				num2 = ((double_2 < num2) ? double_2 : num2);
				double double_3 = shape.Class174_0.Class178_2.Double_10;
				num3 = ((double_3 > num3) ? double_3 : num3);
				double double_4 = shape.Class174_0.Class178_2.Double_8;
				num4 = ((double_4 > num4) ? double_4 : num4);
			}
			return new Class178(MeasuringHelper.ZoomValue(num, zoomFactor, viseVersa: false), MeasuringHelper.ZoomValue(num2, zoomFactor, viseVersa: false), MeasuringHelper.ZoomValue(num3 - num, zoomFactor, viseVersa: false), MeasuringHelper.ZoomValue(num4 - num2, zoomFactor, viseVersa: false), bool_1: false);
		}

		internal static Class178 GetMaxBounds(Class178 shapeBounds, Class178 canvasBounds, int angle)
		{
			Helper.GetRealBounds(shapeBounds, new Class177(shapeBounds.Double_0 + shapeBounds.Double_3 / 2.0, shapeBounds.Double_1 + shapeBounds.Double_2 / 2.0, bool_1: false), angle, out var ripRealBounds);
			double[] maxBoundsOffset = MeasuringHelper.GetMaxBoundsOffset(ripRealBounds, canvasBounds, angle);
			Class179 class179_ = new Class179(shapeBounds.Double_3 + maxBoundsOffset[0] + maxBoundsOffset[2], shapeBounds.Double_2 + maxBoundsOffset[1] + maxBoundsOffset[3], bool_1: false);
			Class177 class177_ = new Class177(shapeBounds.Double_0 - maxBoundsOffset[0], shapeBounds.Double_1 - maxBoundsOffset[1], bool_1: false);
			return new Class178(class177_, class179_);
		}

		internal static bool IsShapeBoundsCrossingShape(ShapeType type)
		{
			return type switch
			{
				ShapeType.Callout1 => true, 
				ShapeType.Callout2 => true, 
				ShapeType.Callout3 => true, 
				ShapeType.AccentCallout1 => true, 
				ShapeType.AccentCallout2 => true, 
				ShapeType.AccentCallout3 => true, 
				ShapeType.BorderCallout1 => true, 
				ShapeType.BorderCallout2 => true, 
				ShapeType.BorderCallout3 => true, 
				ShapeType.AccentBorderCallout1 => true, 
				ShapeType.AccentBorderCallout2 => true, 
				ShapeType.AccentBorderCallout3 => true, 
				ShapeType.WedgeRectangleCallout => true, 
				ShapeType.WedgeRoundRectangleCallout => true, 
				ShapeType.WedgeEllipseCallout => true, 
				ShapeType.CloudCallout => true, 
				ShapeType.LeftArrowCallout => true, 
				ShapeType.RightArrowCallout => true, 
				ShapeType.UpArrowCallout => true, 
				ShapeType.DownArrowCallout => true, 
				ShapeType.LeftRightArrowCallout => true, 
				ShapeType.UpDownArrowCallout => true, 
				ShapeType.QuadArrowCallout => true, 
				ShapeType.Teardrop => true, 
				_ => false, 
			};
		}
	}
}
