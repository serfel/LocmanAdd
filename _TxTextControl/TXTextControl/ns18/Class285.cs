using System.Drawing.Drawing2D;
using ns17;
using TXTextControl.Drawing;

namespace ns18
{
	internal class Class285 : ShapeObject
	{
		private double double_11;

		private double double_12;

		private double double_13;

		private double double_14;

		private double double_15;

		private double double_16;

		private double double_17;

		private double double_18;

		private double double_19;

		private double double_20;

		public Class285(Shape shape_0)
		{
			base.shape = shape_0;
			base.shape.Class174_0.Class172_0.Clear();
		}

		internal override void CreateGraphicsPaths()
		{
			base.CreateBaseVariables(base.shape);
			this.double_11 = Helper.FmlaMultiplyDivide(base.double_8, 49.0, 48.0);
			this.double_12 = Helper.FmlaMultiplyDivide(base.double_8, 10.0, 48.0);
			this.double_13 = Helper.FmlaAddSubtract(base.double_2, 0.0, this.double_11);
			this.double_14 = Helper.FmlaAddSubtract(base.double_2, 0.0, this.double_12);
			this.double_15 = Helper.FmlaAddSubtract(base.double_2, this.double_12, 0.0);
			this.double_16 = Helper.FmlaAddSubtract(base.double_2, this.double_11, 0.0);
			this.double_17 = Helper.FmlaAddSubtract(base.t, 0.0, base.hd3);
			this.double_18 = Helper.FmlaMultiplyDivide(base.double_8, 1.0, 6.0);
			this.double_19 = Helper.FmlaMultiplyDivide(base.double_8, 5.0, 6.0);
			this.double_20 = Helper.FmlaMultiplyDivide(base.double_1, 2.0, 3.0);
			Class175[] array = new Class175[1];
			GraphicsPath graphicsPath = DrawHelper.PathBegin();
			Class175 @class = new Class175(bool_1: true, Enum32.const_5);
			Class177 point = DrawHelper.MoveTo(base.double_2, base.hd4);
			base.ipt2 = new Class177(this.double_15, this.double_17, bool_1: true);
			base.ipt3 = new Class177(this.double_16, base.hd4, bool_1: true);
			base.ipt4 = new Class177(base.double_2, base.double_0, bool_1: true);
			point = DrawHelper.CubicBezTo(graphicsPath, point, base.ipt2, base.ipt3, base.ipt4);
			base.ipt2 = new Class177(this.double_13, base.hd4, bool_1: true);
			base.ipt3 = new Class177(this.double_14, this.double_17, bool_1: true);
			base.ipt4 = new Class177(base.double_2, base.hd4, bool_1: true);
			point = DrawHelper.CubicBezTo(graphicsPath, point, base.ipt2, base.ipt3, base.ipt4);
			DrawHelper.Close(graphicsPath);
			@class.List_0.Add(graphicsPath);
			array[0] = @class;
			base.shape.Class183_0.Class175_0 = array;
		}
	}
}
