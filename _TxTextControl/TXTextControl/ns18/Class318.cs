using System.Drawing.Drawing2D;
using ns17;
using TXTextControl.Drawing;

namespace ns18
{
	internal class Class318 : ShapeObject
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

		private double double_21;

		private double double_22;

		private double double_23;

		private double double_24;

		public Class318(Shape shape_0)
		{
			base.shape = shape_0;
			base.shape.Class174_0.Class172_0.Clear();
			base.double_9 = Helper.FmlaLiteralValue(105146.0);
			base.SaveHF = true;
			base.double_10 = Helper.FmlaLiteralValue(110557.0);
			base.SaveVF = true;
			base.SetLoadedAvLstValues(base.shape);
		}

		internal override void CreateGraphicsPaths()
		{
			base.CreateBaseVariables(base.shape);
			this.double_11 = Helper.FmlaMultiplyDivide(base.wd2, base.double_9, 100000.0);
			this.double_12 = Helper.FmlaMultiplyDivide(base.hd2, base.double_10, 100000.0);
			this.double_13 = Helper.FmlaMultiplyDivide(base.double_7, base.double_10, 100000.0);
			this.double_14 = Helper.FmlaCosine(this.double_11, 1080000.0);
			this.double_15 = Helper.FmlaCosine(this.double_11, 18360000.0);
			this.double_16 = Helper.FmlaSine(this.double_12, 1080000.0);
			this.double_17 = Helper.FmlaSine(this.double_12, 18360000.0);
			this.double_18 = Helper.FmlaAddSubtract(base.double_2, 0.0, this.double_14);
			this.double_19 = Helper.FmlaAddSubtract(base.double_2, 0.0, this.double_15);
			this.double_20 = Helper.FmlaAddSubtract(base.double_2, this.double_15, 0.0);
			this.double_21 = Helper.FmlaAddSubtract(base.double_2, this.double_14, 0.0);
			this.double_22 = Helper.FmlaAddSubtract(this.double_13, 0.0, this.double_16);
			this.double_23 = Helper.FmlaAddSubtract(this.double_13, 0.0, this.double_17);
			this.double_24 = Helper.FmlaMultiplyDivide(this.double_22, this.double_15, this.double_14);
			Class175[] array = new Class175[1];
			GraphicsPath graphicsPath = DrawHelper.PathBegin();
			Class175 @class = new Class175(bool_1: true, Enum32.const_5);
			Class177 class2 = DrawHelper.MoveTo(this.double_18, this.double_22);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, base.double_2, base.t);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_21, this.double_22);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_20, this.double_23);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_19, this.double_23);
			DrawHelper.Close(graphicsPath);
			@class.List_0.Add(graphicsPath);
			array[0] = @class;
			base.shape.Class183_0.Class175_0 = array;
		}
	}
}
