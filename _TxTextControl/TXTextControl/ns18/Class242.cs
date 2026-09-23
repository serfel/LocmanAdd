using System.Drawing.Drawing2D;
using ns17;
using TXTextControl.Drawing;

namespace ns18
{
	internal class Class242 : ShapeObject
	{
		private double double_11;

		private double double_12;

		private double double_13;

		private double double_14;

		private double double_15;

		private double double_16;

		private double double_17;

		private double double_18;

		public Class242(Shape shape_0)
		{
			base.shape = shape_0;
			base.shape.Class174_0.Class172_0.Clear();
		}

		internal override void CreateGraphicsPaths()
		{
			base.CreateBaseVariables(base.shape);
			this.double_11 = Helper.FmlaMultiplyDivide(base.double_8, 2894.0, 21600.0);
			this.double_12 = Helper.FmlaMultiplyDivide(base.double_8, 7906.0, 21600.0);
			this.double_13 = Helper.FmlaMultiplyDivide(base.double_8, 13694.0, 21600.0);
			this.double_14 = Helper.FmlaMultiplyDivide(base.double_8, 18706.0, 21600.0);
			this.double_15 = Helper.FmlaMultiplyDivide(base.double_1, 2894.0, 21600.0);
			this.double_16 = Helper.FmlaMultiplyDivide(base.double_1, 7906.0, 21600.0);
			this.double_17 = Helper.FmlaMultiplyDivide(base.double_1, 13694.0, 21600.0);
			this.double_18 = Helper.FmlaMultiplyDivide(base.double_1, 18706.0, 21600.0);
			Class175[] array = new Class175[1];
			GraphicsPath graphicsPath = DrawHelper.PathBegin();
			Class175 @class = new Class175(bool_1: true, Enum32.const_5);
			Class177 class2 = DrawHelper.MoveTo(base.double_3, this.double_16);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_11, this.double_15);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_12, base.t);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_13, base.t);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_14, this.double_15);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, base.double_5, this.double_16);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, base.double_5, this.double_17);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_14, this.double_18);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_13, base.double_0);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_12, base.double_0);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_11, this.double_18);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, base.double_3, this.double_17);
			DrawHelper.Close(graphicsPath);
			@class.List_0.Add(graphicsPath);
			array[0] = @class;
			base.shape.Class183_0.Class175_0 = array;
		}
	}
}
