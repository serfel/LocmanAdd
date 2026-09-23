using System.Drawing.Drawing2D;
using ns17;
using TXTextControl.Drawing;

namespace ns18
{
	internal class Class239 : ShapeObject
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

		public Class239(Shape shape_0)
		{
			base.shape = shape_0;
			base.shape.Class174_0.Class172_0.Clear();
			base.double_10 = Helper.FmlaLiteralValue(105146.0);
			base.SaveVF = true;
			base.SetLoadedAvLstValues(base.shape);
		}

		internal override void CreateGraphicsPaths()
		{
			base.CreateBaseVariables(base.shape);
			this.double_11 = Helper.FmlaMultiplyDivide(base.hd2, base.double_10, 100000.0);
			this.double_12 = Helper.FmlaCosine(base.wd2, 2160000.0);
			this.double_13 = Helper.FmlaCosine(base.wd2, 4320000.0);
			this.double_14 = Helper.FmlaAddSubtract(base.double_2, 0.0, this.double_12);
			this.double_15 = Helper.FmlaAddSubtract(base.double_2, 0.0, this.double_13);
			this.double_16 = Helper.FmlaAddSubtract(base.double_2, this.double_13, 0.0);
			this.double_17 = Helper.FmlaAddSubtract(base.double_2, this.double_12, 0.0);
			this.double_18 = Helper.FmlaSine(this.double_11, 4320000.0);
			this.double_19 = Helper.FmlaSine(this.double_11, 2160000.0);
			this.double_20 = Helper.FmlaAddSubtract(base.double_7, 0.0, this.double_18);
			this.double_21 = Helper.FmlaAddSubtract(base.double_7, 0.0, this.double_19);
			this.double_22 = Helper.FmlaAddSubtract(base.double_7, this.double_19, 0.0);
			this.double_23 = Helper.FmlaAddSubtract(base.double_7, this.double_18, 0.0);
			Class175[] array = new Class175[1];
			GraphicsPath graphicsPath = DrawHelper.PathBegin();
			Class175 @class = new Class175(bool_1: true, Enum32.const_5);
			Class177 class2 = DrawHelper.MoveTo(base.double_3, base.double_7);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_14, this.double_21);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_15, this.double_20);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_16, this.double_20);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_17, this.double_21);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, base.double_5, base.double_7);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_17, this.double_22);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_16, this.double_23);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_15, this.double_23);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_14, this.double_22);
			DrawHelper.Close(graphicsPath);
			@class.List_0.Add(graphicsPath);
			array[0] = @class;
			base.shape.Class183_0.Class175_0 = array;
		}
	}
}
