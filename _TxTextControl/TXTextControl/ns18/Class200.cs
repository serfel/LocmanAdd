using System.Drawing.Drawing2D;
using ns17;
using TXTextControl.Drawing;

namespace ns18
{
	internal class Class200 : ShapeObject
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

		private double double_25;

		private double double_26;

		private double double_27;

		private double double_28;

		private double double_29;

		private double double_30;

		public Class200(Shape shape_0)
		{
			base.shape = shape_0;
			base.shape.Class174_0.Class172_0.Clear();
		}

		internal override void CreateGraphicsPaths()
		{
			base.CreateBaseVariables(base.shape);
			this.double_11 = Helper.FmlaMultiplyDivide(base.double_6, 3.0, 8.0);
			this.double_12 = Helper.FmlaAddSubtract(base.double_7, 0.0, this.double_11);
			this.double_13 = Helper.FmlaAddSubtract(base.double_7, this.double_11, 0.0);
			this.double_14 = Helper.FmlaAddSubtract(base.double_2, 0.0, this.double_11);
			this.double_15 = Helper.FmlaAddSubtract(base.double_2, this.double_11, 0.0);
			this.double_16 = Helper.FmlaMultiplyDivide(base.double_6, 3.0, 4.0);
			this.double_17 = Helper.FmlaMultiplyDivide(this.double_16, 7.0, 8.0);
			this.double_18 = Helper.FmlaMultiplyDivide(this.double_16, 3.0, 4.0);
			this.double_19 = Helper.FmlaMultiplyDivide(this.double_16, 5.0, 8.0);
			this.double_20 = Helper.FmlaMultiplyDivide(this.double_16, 3.0, 8.0);
			this.double_21 = Helper.FmlaMultiplyDivide(this.double_16, 1.0, 4.0);
			this.double_22 = Helper.FmlaAddSubtract(this.double_12, this.double_18, 0.0);
			this.double_23 = Helper.FmlaAddSubtract(this.double_12, this.double_19, 0.0);
			this.double_24 = Helper.FmlaAddSubtract(this.double_12, this.double_21, 0.0);
			this.double_25 = Helper.FmlaAddSubtract(this.double_14, this.double_17, 0.0);
			this.double_26 = Helper.FmlaAddSubtract(this.double_14, this.double_18, 0.0);
			this.double_27 = Helper.FmlaAddSubtract(this.double_14, this.double_19, 0.0);
			this.double_28 = Helper.FmlaAddSubtract(this.double_14, this.double_20, 0.0);
			this.double_29 = Helper.FmlaAddSubtract(this.double_14, this.double_21, 0.0);
			this.double_30 = Helper.FmlaMultiplyDivide(this.double_16, 1.0, 8.0);
			Class175[] array = new Class175[4];
			GraphicsPath graphicsPath = DrawHelper.PathBegin();
			Class175 @class = new Class175(bool_1: false, Enum32.const_5);
			Class177 class2 = DrawHelper.MoveTo(base.double_3, base.t);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, base.double_5, base.t);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, base.double_5, base.double_0);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, base.double_3, base.double_0);
			DrawHelper.Close(graphicsPath);
			class2 = DrawHelper.MoveTo(this.double_15, this.double_24);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_26, this.double_12);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, base.double_2, this.double_24);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_27, this.double_24);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_27, this.double_23);
			class2 = DrawHelper.ArcTo(graphicsPath, this.double_30, this.double_30, 0.0, base.cd4, class2);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_28, this.double_22);
			class2 = DrawHelper.ArcTo(graphicsPath, this.double_30, this.double_30, base.cd4, base.cd4, class2);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_29, this.double_24);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_14, this.double_24);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_14, this.double_23);
			class2 = DrawHelper.ArcTo(graphicsPath, this.double_20, this.double_20, base.cd2, -5400000.0, class2);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, base.double_2, this.double_13);
			class2 = DrawHelper.ArcTo(graphicsPath, this.double_20, this.double_20, base.cd4, -5400000.0, class2);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_25, this.double_24);
			DrawHelper.Close(graphicsPath);
			@class.List_0.Add(graphicsPath);
			array[0] = @class;
			graphicsPath = DrawHelper.PathBegin();
			@class = new Class175(bool_1: false, Enum32.const_0);
			class2 = DrawHelper.MoveTo(this.double_15, this.double_24);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_26, this.double_12);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, base.double_2, this.double_24);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_27, this.double_24);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_27, this.double_23);
			class2 = DrawHelper.ArcTo(graphicsPath, this.double_30, this.double_30, 0.0, base.cd4, class2);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_28, this.double_22);
			class2 = DrawHelper.ArcTo(graphicsPath, this.double_30, this.double_30, base.cd4, base.cd4, class2);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_29, this.double_24);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_14, this.double_24);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_14, this.double_23);
			class2 = DrawHelper.ArcTo(graphicsPath, this.double_20, this.double_20, base.cd2, -5400000.0, class2);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, base.double_2, this.double_13);
			class2 = DrawHelper.ArcTo(graphicsPath, this.double_20, this.double_20, base.cd4, -5400000.0, class2);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_25, this.double_24);
			DrawHelper.Close(graphicsPath);
			@class.List_0.Add(graphicsPath);
			array[1] = @class;
			graphicsPath = DrawHelper.PathBegin();
			@class = new Class175(bool_1: true, Enum32.const_4);
			class2 = DrawHelper.MoveTo(this.double_15, this.double_24);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_25, this.double_24);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_25, this.double_23);
			class2 = DrawHelper.ArcTo(graphicsPath, this.double_20, this.double_20, 0.0, base.cd4, class2);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_28, this.double_13);
			class2 = DrawHelper.ArcTo(graphicsPath, this.double_20, this.double_20, base.cd4, base.cd4, class2);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_14, this.double_24);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_29, this.double_24);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_29, this.double_23);
			class2 = DrawHelper.ArcTo(graphicsPath, this.double_30, this.double_30, base.cd2, -5400000.0, class2);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, base.double_2, this.double_22);
			class2 = DrawHelper.ArcTo(graphicsPath, this.double_30, this.double_30, base.cd4, -5400000.0, class2);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_27, this.double_24);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, base.double_2, this.double_24);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_26, this.double_12);
			DrawHelper.Close(graphicsPath);
			@class.List_0.Add(graphicsPath);
			array[2] = @class;
			graphicsPath = DrawHelper.PathBegin();
			@class = new Class175(bool_1: true, Enum32.const_4);
			class2 = DrawHelper.MoveTo(base.double_3, base.t);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, base.double_5, base.t);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, base.double_5, base.double_0);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, base.double_3, base.double_0);
			DrawHelper.Close(graphicsPath);
			@class.List_0.Add(graphicsPath);
			array[3] = @class;
			base.shape.Class183_0.Class175_0 = array;
		}
	}
}
