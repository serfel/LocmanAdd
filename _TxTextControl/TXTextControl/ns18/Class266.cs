using System.Drawing.Drawing2D;
using ns17;
using TXTextControl.Drawing;

namespace ns18
{
	internal class Class266 : ShapeObject
	{
		private double double_11;

		private double double_12;

		private double double_13;

		private double double_14;

		private double double_15;

		public Class266(Shape shape_0)
		{
			base.shape = shape_0;
			base.shape.Class174_0.Class172_0.Clear();
		}

		internal override void CreateGraphicsPaths()
		{
			base.CreateBaseVariables(base.shape);
			this.double_11 = Helper.FmlaMultiplyDivide(base.double_1, 3675.0, 21600.0);
			this.double_12 = Helper.FmlaMultiplyDivide(base.double_1, 20782.0, 21600.0);
			this.double_13 = Helper.FmlaMultiplyDivide(base.double_8, 9298.0, 21600.0);
			this.double_14 = Helper.FmlaMultiplyDivide(base.double_8, 12286.0, 21600.0);
			this.double_15 = Helper.FmlaMultiplyDivide(base.double_8, 18595.0, 21600.0);
			Class175[] array = new Class175[3];
			GraphicsPath graphicsPath = DrawHelper.PathBegin();
			Class175 @class = new Class175(bool_1: false, Enum32.const_5);
			Class177 point = DrawHelper.MoveTo(0.0, 20782.0);
			base.ipt2 = new Class177(9298.0, 23542.0, bool_1: true);
			base.ipt3 = new Class177(9298.0, 18022.0, bool_1: true);
			base.ipt4 = new Class177(18595.0, 18022.0, bool_1: true);
			point = DrawHelper.CubicBezTo(graphicsPath, point, base.ipt2, base.ipt3, base.ipt4);
			point = DrawHelper.LnTo(graphicsPath, point.Double_2, point.Double_3, 18595.0, 3675.0);
			point = DrawHelper.LnTo(graphicsPath, point.Double_2, point.Double_3, 0.0, 3675.0);
			DrawHelper.Close(graphicsPath);
			point = DrawHelper.MoveTo(1532.0, 3675.0);
			point = DrawHelper.LnTo(graphicsPath, point.Double_2, point.Double_3, 1532.0, 1815.0);
			point = DrawHelper.LnTo(graphicsPath, point.Double_2, point.Double_3, 20000.0, 1815.0);
			point = DrawHelper.LnTo(graphicsPath, point.Double_2, point.Double_3, 20000.0, 16252.0);
			base.ipt2 = new Class177(19298.0, 16252.0, bool_1: true);
			base.ipt3 = new Class177(18595.0, 16352.0, bool_1: true);
			base.ipt4 = new Class177(18595.0, 16352.0, bool_1: true);
			point = DrawHelper.CubicBezTo(graphicsPath, point, base.ipt2, base.ipt3, base.ipt4);
			point = DrawHelper.LnTo(graphicsPath, point.Double_2, point.Double_3, 18595.0, 3675.0);
			DrawHelper.Close(graphicsPath);
			point = DrawHelper.MoveTo(2972.0, 1815.0);
			point = DrawHelper.LnTo(graphicsPath, point.Double_2, point.Double_3, 2972.0, 0.0);
			point = DrawHelper.LnTo(graphicsPath, point.Double_2, point.Double_3, 21600.0, 0.0);
			point = DrawHelper.LnTo(graphicsPath, point.Double_2, point.Double_3, 21600.0, 14392.0);
			base.ipt2 = new Class177(20800.0, 14392.0, bool_1: true);
			base.ipt3 = new Class177(20000.0, 14467.0, bool_1: true);
			base.ipt4 = new Class177(20000.0, 14467.0, bool_1: true);
			point = DrawHelper.CubicBezTo(graphicsPath, point, base.ipt2, base.ipt3, base.ipt4);
			point = DrawHelper.LnTo(graphicsPath, point.Double_2, point.Double_3, 20000.0, 1815.0);
			DrawHelper.Close(graphicsPath);
			@class.List_0.Add(graphicsPath);
			array[0] = @class;
			graphicsPath = DrawHelper.PathBegin();
			@class = new Class175(bool_1: true, Enum32.const_4);
			point = DrawHelper.MoveTo(0.0, 3675.0);
			point = DrawHelper.LnTo(graphicsPath, point.Double_2, point.Double_3, 18595.0, 3675.0);
			point = DrawHelper.LnTo(graphicsPath, point.Double_2, point.Double_3, 18595.0, 18022.0);
			base.ipt2 = new Class177(9298.0, 18022.0, bool_1: true);
			base.ipt3 = new Class177(9298.0, 23542.0, bool_1: true);
			base.ipt4 = new Class177(0.0, 20782.0, bool_1: true);
			point = DrawHelper.CubicBezTo(graphicsPath, point, base.ipt2, base.ipt3, base.ipt4);
			DrawHelper.Close(graphicsPath);
			point = DrawHelper.MoveTo(1532.0, 3675.0, graphicsPath, @class, out graphicsPath);
			point = DrawHelper.LnTo(graphicsPath, point.Double_2, point.Double_3, 1532.0, 1815.0);
			point = DrawHelper.LnTo(graphicsPath, point.Double_2, point.Double_3, 20000.0, 1815.0);
			point = DrawHelper.LnTo(graphicsPath, point.Double_2, point.Double_3, 20000.0, 16252.0);
			base.ipt2 = new Class177(19298.0, 16252.0, bool_1: true);
			base.ipt3 = new Class177(18595.0, 16352.0, bool_1: true);
			base.ipt4 = new Class177(18595.0, 16352.0, bool_1: true);
			point = DrawHelper.CubicBezTo(graphicsPath, point, base.ipt2, base.ipt3, base.ipt4);
			point = DrawHelper.MoveTo(2972.0, 1815.0, graphicsPath, @class, out graphicsPath);
			point = DrawHelper.LnTo(graphicsPath, point.Double_2, point.Double_3, 2972.0, 0.0);
			point = DrawHelper.LnTo(graphicsPath, point.Double_2, point.Double_3, 21600.0, 0.0);
			point = DrawHelper.LnTo(graphicsPath, point.Double_2, point.Double_3, 21600.0, 14392.0);
			base.ipt2 = new Class177(20800.0, 14392.0, bool_1: true);
			base.ipt3 = new Class177(20000.0, 14467.0, bool_1: true);
			base.ipt4 = new Class177(20000.0, 14467.0, bool_1: true);
			point = DrawHelper.CubicBezTo(graphicsPath, point, base.ipt2, base.ipt3, base.ipt4);
			@class.List_0.Add(graphicsPath);
			array[1] = @class;
			graphicsPath = DrawHelper.PathBegin();
			@class = new Class175(bool_1: false, Enum32.const_4);
			point = DrawHelper.MoveTo(0.0, 20782.0);
			base.ipt2 = new Class177(9298.0, 23542.0, bool_1: true);
			base.ipt3 = new Class177(9298.0, 18022.0, bool_1: true);
			base.ipt4 = new Class177(18595.0, 18022.0, bool_1: true);
			point = DrawHelper.CubicBezTo(graphicsPath, point, base.ipt2, base.ipt3, base.ipt4);
			point = DrawHelper.LnTo(graphicsPath, point.Double_2, point.Double_3, 18595.0, 16352.0);
			base.ipt2 = new Class177(18595.0, 16352.0, bool_1: true);
			base.ipt3 = new Class177(19298.0, 16252.0, bool_1: true);
			base.ipt4 = new Class177(20000.0, 16252.0, bool_1: true);
			point = DrawHelper.CubicBezTo(graphicsPath, point, base.ipt2, base.ipt3, base.ipt4);
			point = DrawHelper.LnTo(graphicsPath, point.Double_2, point.Double_3, 20000.0, 14467.0);
			base.ipt2 = new Class177(20000.0, 14467.0, bool_1: true);
			base.ipt3 = new Class177(20800.0, 14392.0, bool_1: true);
			base.ipt4 = new Class177(21600.0, 14392.0, bool_1: true);
			point = DrawHelper.CubicBezTo(graphicsPath, point, base.ipt2, base.ipt3, base.ipt4);
			point = DrawHelper.LnTo(graphicsPath, point.Double_2, point.Double_3, 21600.0, 0.0);
			point = DrawHelper.LnTo(graphicsPath, point.Double_2, point.Double_3, 2972.0, 0.0);
			point = DrawHelper.LnTo(graphicsPath, point.Double_2, point.Double_3, 2972.0, 1815.0);
			point = DrawHelper.LnTo(graphicsPath, point.Double_2, point.Double_3, 1532.0, 1815.0);
			point = DrawHelper.LnTo(graphicsPath, point.Double_2, point.Double_3, 1532.0, 3675.0);
			point = DrawHelper.LnTo(graphicsPath, point.Double_2, point.Double_3, 0.0, 3675.0);
			DrawHelper.Close(graphicsPath);
			@class.List_0.Add(graphicsPath);
			array[2] = @class;
			base.shape.Class183_0.Class175_0 = array;
		}
	}
}
