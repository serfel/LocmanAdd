using System.Drawing.Drawing2D;
using ns17;
using TXTextControl.Drawing;

namespace ns18
{
	internal class Class281 : ShapeObject
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

		private double double_31;

		private double double_32;

		private double double_33;

		private double double_34;

		private double double_35;

		private double double_36;

		private double double_37;

		private double double_38;

		private double double_39;

		private double double_40;

		private double double_41;

		public Class281(Shape shape_0)
		{
			base.shape = shape_0;
			base.shape.Class174_0.Class172_0.Clear();
		}

		internal override void CreateGraphicsPaths()
		{
			base.CreateBaseVariables(base.shape);
			this.double_11 = Helper.FmlaMultiplyDivide(base.double_6, 1.0, 20.0);
			this.double_12 = Helper.FmlaAddSubtract(base.wd2, 0.0, this.double_11);
			this.double_13 = Helper.FmlaAddSubtract(base.hd4, 0.0, this.double_11);
			this.double_14 = Helper.FmlaCosine(base.wd2, 480000.0);
			this.double_15 = Helper.FmlaSine(base.hd4, 480000.0);
			this.double_16 = Helper.FmlaArcTan(this.double_14, this.double_15);
			this.double_17 = Helper.FmlaMultiplyDivide(this.double_16, 2.0, 1.0);
			this.double_18 = Helper.FmlaAddSubtract(base.cd2, 0.0, this.double_16);
			this.double_19 = Helper.FmlaAddSubtract(base.cd2, this.double_17, 0.0);
			this.double_20 = Helper.FmlaAddSubtract(base.cd2, 0.0, this.double_17);
			this.double_21 = Helper.FmlaMultiplyDivide(base.wd2, 1.0, 4.0);
			this.double_22 = Helper.FmlaMultiplyDivide(base.hd4, 1.0, 4.0);
			this.double_23 = Helper.FmlaCosine(base.hd4, this.double_18);
			this.double_24 = Helper.FmlaSine(base.wd2, this.double_18);
			this.double_25 = Helper.FmlaModulo(this.double_23, this.double_24, 0.0);
			this.double_26 = Helper.FmlaMultiplyDivide(base.wd2, base.hd4, this.double_25);
			this.double_27 = Helper.FmlaCosine(this.double_26, this.double_18);
			this.double_28 = Helper.FmlaSine(this.double_26, this.double_18);
			this.double_29 = Helper.FmlaAddSubtract(base.double_2, this.double_27, 0.0);
			this.double_30 = Helper.FmlaAddSubtract(base.hd4, this.double_28, 0.0);
			this.double_31 = Helper.FmlaCosine(this.double_22, this.double_16);
			this.double_32 = Helper.FmlaSine(this.double_21, this.double_16);
			this.double_33 = Helper.FmlaModulo(this.double_31, this.double_32, 0.0);
			this.double_34 = Helper.FmlaMultiplyDivide(this.double_21, this.double_22, this.double_33);
			this.double_35 = Helper.FmlaCosine(this.double_34, this.double_16);
			this.double_36 = Helper.FmlaSine(this.double_34, this.double_16);
			this.double_37 = Helper.FmlaAddSubtract(base.double_2, this.double_35, 0.0);
			this.double_38 = Helper.FmlaAddSubtract(base.double_0, 0.0, this.double_22);
			this.double_39 = Helper.FmlaAddSubtract(this.double_38, this.double_36, 0.0);
			this.double_40 = Helper.FmlaAddSubtract(base.wd2, 0.0, this.double_12);
			this.double_41 = Helper.FmlaMultiplyDivide(base.cd2, 2.0, 1.0);
			Class175[] array = new Class175[1];
			GraphicsPath graphicsPath = DrawHelper.PathBegin();
			Class175 @class = new Class175(bool_1: true, Enum32.const_5);
			Class177 currentPathEndLocation = DrawHelper.MoveTo(this.double_29, this.double_30);
			currentPathEndLocation = DrawHelper.ArcTo(graphicsPath, base.wd2, base.hd4, this.double_18, this.double_19, currentPathEndLocation);
			currentPathEndLocation = DrawHelper.LnTo(graphicsPath, currentPathEndLocation.Double_2, currentPathEndLocation.Double_3, this.double_37, this.double_39);
			currentPathEndLocation = DrawHelper.ArcTo(graphicsPath, this.double_21, this.double_22, this.double_16, this.double_20, currentPathEndLocation);
			DrawHelper.Close(graphicsPath);
			currentPathEndLocation = DrawHelper.MoveTo(this.double_40, base.hd4);
			currentPathEndLocation = DrawHelper.ArcTo(graphicsPath, this.double_12, this.double_13, base.cd2, -21600000.0, currentPathEndLocation);
			DrawHelper.Close(graphicsPath);
			@class.List_0.Add(graphicsPath);
			array[0] = @class;
			base.shape.Class183_0.Class175_0 = array;
		}
	}
}
