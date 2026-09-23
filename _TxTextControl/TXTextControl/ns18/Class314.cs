using System.Drawing.Drawing2D;
using ns17;
using TXTextControl.Drawing;

namespace ns18
{
	internal class Class314 : ShapeObject
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

		private double double_42;

		public Class314(Shape shape_0)
		{
			base.shape = shape_0;
			base.shape.Class174_0.Class172_0.Clear();
			base.adj = Helper.FmlaLiteralValue(18750.0);
			base.SetLoadedAvLstValues(base.shape);
		}

		internal override void CreateGraphicsPaths()
		{
			base.CreateBaseVariables(base.shape);
			this.double_11 = Helper.FmlaPinTo(0.0, base.adj, 50000.0);
			this.double_12 = Helper.FmlaMultiplyDivide(base.double_6, this.double_11, 100000.0);
			this.double_13 = Helper.FmlaAddSubtract(base.wd2, 0.0, this.double_12);
			this.double_14 = Helper.FmlaAddSubtract(base.hd2, 0.0, this.double_12);
			this.double_15 = Helper.FmlaArcTan(base.double_8, base.double_1);
			this.double_16 = Helper.FmlaCosine(this.double_14, this.double_15);
			this.double_17 = Helper.FmlaSine(this.double_13, this.double_15);
			this.double_18 = Helper.FmlaModulo(this.double_16, this.double_17, 0.0);
			this.double_19 = Helper.FmlaMultiplyDivide(this.double_13, this.double_14, this.double_18);
			this.double_20 = Helper.FmlaMultiplyDivide(this.double_12, 1.0, 2.0);
			this.double_21 = Helper.FmlaArcTan(this.double_19, this.double_20);
			this.double_22 = Helper.FmlaMultiplyDivide(this.double_21, 2.0, 1.0);
			this.double_23 = Helper.FmlaAddSubtract(-10800000.0, this.double_22, 0.0);
			this.double_24 = Helper.FmlaArcTan(base.double_8, base.double_1);
			this.double_25 = Helper.FmlaAddSubtract(this.double_24, 0.0, this.double_21);
			this.double_26 = Helper.FmlaAddSubtract(this.double_25, 0.0, base.cd2);
			this.double_27 = Helper.FmlaCosine(this.double_14, this.double_25);
			this.double_28 = Helper.FmlaSine(this.double_13, this.double_25);
			this.double_29 = Helper.FmlaModulo(this.double_27, this.double_28, 0.0);
			this.double_30 = Helper.FmlaMultiplyDivide(this.double_13, this.double_14, this.double_29);
			this.double_31 = Helper.FmlaCosine(this.double_30, this.double_25);
			this.double_32 = Helper.FmlaSine(this.double_30, this.double_25);
			this.double_33 = Helper.FmlaAddSubtract(base.double_2, this.double_31, 0.0);
			this.double_34 = Helper.FmlaAddSubtract(base.double_7, this.double_32, 0.0);
			this.double_35 = Helper.FmlaAddSubtract(base.double_2, 0.0, this.double_31);
			this.double_36 = Helper.FmlaAddSubtract(base.double_7, 0.0, this.double_32);
			this.double_37 = Helper.FmlaCosine(base.wd2, 2700000.0);
			this.double_38 = Helper.FmlaSine(base.hd2, 2700000.0);
			this.double_39 = Helper.FmlaAddSubtract(base.double_2, 0.0, this.double_37);
			this.double_40 = Helper.FmlaAddSubtract(base.double_2, this.double_37, 0.0);
			this.double_41 = Helper.FmlaAddSubtract(base.double_7, 0.0, this.double_38);
			this.double_42 = Helper.FmlaAddSubtract(base.double_7, this.double_38, 0.0);
			if (base.shape.Class174_0.Class172_0.Count == 0)
			{
				double num = ((base.shape.Class174_0.Dictionary_0 == null || !base.shape.Class174_0.Dictionary_0.ContainsKey("adj")) ? 18750.0 : base.adj);
				AdjustObject adjustObject = new Class169(new Class177(this.double_12 / 12700.0, base.double_7 / 12700.0, bool_1: false), "Adj", 0.0, 50000.0, num, base.shape, bool_0: false);
				adjustObject.DefaultValue = 18750.0;
				base.shape.Class174_0.Class172_0.method_0(adjustObject);
			}
			else
			{
				base.shape.Class174_0.Class172_0[0].AdjustRectangle.Class178_0.Class177_1 = new Class177(this.double_12 / 12700.0, base.double_7 / 12700.0, bool_1: false);
			}
			base.shape.Class174_0.Dictionary_0 = null;
			Class175[] array = new Class175[1];
			GraphicsPath graphicsPath = DrawHelper.PathBegin();
			Class175 @class = new Class175(bool_1: true, Enum32.const_5);
			Class177 currentPathEndLocation = DrawHelper.MoveTo(base.double_3, base.double_7);
			currentPathEndLocation = DrawHelper.ArcTo(graphicsPath, base.wd2, base.hd2, base.cd2, base.cd4, currentPathEndLocation);
			currentPathEndLocation = DrawHelper.ArcTo(graphicsPath, base.wd2, base.hd2, base._3cd4, base.cd4, currentPathEndLocation);
			currentPathEndLocation = DrawHelper.ArcTo(graphicsPath, base.wd2, base.hd2, 0.0, base.cd4, currentPathEndLocation);
			currentPathEndLocation = DrawHelper.ArcTo(graphicsPath, base.wd2, base.hd2, base.cd4, base.cd4, currentPathEndLocation);
			DrawHelper.Close(graphicsPath);
			currentPathEndLocation = DrawHelper.MoveTo(this.double_33, this.double_34);
			currentPathEndLocation = DrawHelper.ArcTo(graphicsPath, this.double_13, this.double_14, this.double_25, this.double_23, currentPathEndLocation);
			DrawHelper.Close(graphicsPath);
			currentPathEndLocation = DrawHelper.MoveTo(this.double_35, this.double_36);
			currentPathEndLocation = DrawHelper.ArcTo(graphicsPath, this.double_13, this.double_14, this.double_26, this.double_23, currentPathEndLocation);
			DrawHelper.Close(graphicsPath);
			@class.List_0.Add(graphicsPath);
			array[0] = @class;
			base.shape.Class183_0.Class175_0 = array;
		}
	}
}
