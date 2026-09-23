using System.Drawing.Drawing2D;
using ns17;
using TXTextControl.Drawing;

namespace ns18
{
	internal class Class309 : ShapeObject
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

		public Class309(Shape shape_0)
		{
			base.shape = shape_0;
			base.shape.Class174_0.Class172_0.Clear();
			base.adj1 = Helper.FmlaLiteralValue(23520.0);
			base.SetLoadedAvLstValues(base.shape);
		}

		internal override void CreateGraphicsPaths()
		{
			base.CreateBaseVariables(base.shape);
			this.double_11 = Helper.FmlaPinTo(0.0, base.adj1, 51965.0);
			this.double_12 = Helper.FmlaMultiplyDivide(base.double_6, this.double_11, 100000.0);
			this.double_13 = Helper.FmlaArcTan(base.double_8, base.double_1);
			this.double_14 = Helper.FmlaSine(1.0, this.double_13);
			this.double_15 = Helper.FmlaCosine(1.0, this.double_13);
			this.double_16 = Helper.FmlaTangent(1.0, this.double_13);
			this.double_17 = Helper.FmlaModulo(base.double_8, base.double_1, 0.0);
			this.double_18 = Helper.FmlaMultiplyDivide(this.double_17, 51965.0, 100000.0);
			this.double_19 = Helper.FmlaAddSubtract(this.double_17, 0.0, this.double_18);
			this.double_20 = Helper.FmlaMultiplyDivide(this.double_15, this.double_19, 2.0);
			this.double_21 = Helper.FmlaMultiplyDivide(this.double_14, this.double_19, 2.0);
			this.double_22 = Helper.FmlaMultiplyDivide(this.double_14, this.double_12, 2.0);
			this.double_23 = Helper.FmlaMultiplyDivide(this.double_15, this.double_12, 2.0);
			this.double_24 = Helper.FmlaAddSubtract(this.double_20, 0.0, this.double_22);
			this.double_25 = Helper.FmlaAddSubtract(this.double_21, this.double_23, 0.0);
			this.double_26 = Helper.FmlaAddSubtract(this.double_20, this.double_22, 0.0);
			this.double_27 = Helper.FmlaAddSubtract(this.double_21, 0.0, this.double_23);
			this.double_28 = Helper.FmlaAddSubtract(base.double_2, 0.0, this.double_26);
			this.double_29 = Helper.FmlaMultiplyDivide(this.double_28, this.double_16, 1.0);
			this.double_30 = Helper.FmlaAddSubtract(this.double_29, this.double_27, 0.0);
			this.double_31 = Helper.FmlaAddSubtract(base.double_5, 0.0, this.double_26);
			this.double_32 = Helper.FmlaAddSubtract(base.double_5, 0.0, this.double_24);
			this.double_33 = Helper.FmlaAddSubtract(base.double_7, 0.0, this.double_25);
			this.double_34 = Helper.FmlaMultiplyDivide(this.double_33, 1.0, this.double_16);
			this.double_35 = Helper.FmlaAddSubtract(this.double_32, 0.0, this.double_34);
			this.double_36 = Helper.FmlaAddSubtract(this.double_24, this.double_34, 0.0);
			this.double_37 = Helper.FmlaAddSubtract(base.double_0, 0.0, this.double_25);
			this.double_38 = Helper.FmlaAddSubtract(base.double_0, 0.0, this.double_27);
			this.double_39 = Helper.FmlaAddSubtract(base.double_0, 0.0, this.double_30);
			this.double_40 = Helper.FmlaAddSubtract(base.double_5, 0.0, this.double_20);
			this.double_41 = Helper.FmlaAddSubtract(base.double_0, 0.0, this.double_21);
			if (base.shape.Class174_0.Class172_0.Count == 0)
			{
				double num = ((base.shape.Class174_0.Dictionary_0 == null || !base.shape.Class174_0.Dictionary_0.ContainsKey("adj1")) ? 23520.0 : base.adj1);
				AdjustObject adjustObject = new Class171(new Class177(base.double_3 / 12700.0, this.double_12 / 12700.0, bool_1: false), "Adj1", 0.0, 51965.0, num, base.shape, bool_0: false);
				adjustObject.DefaultValue = 23520.0;
				base.shape.Class174_0.Class172_0.method_0(adjustObject);
			}
			else
			{
				base.shape.Class174_0.Class172_0[0].AdjustRectangle.Class178_0.Class177_1 = new Class177(base.double_3 / 12700.0, this.double_12 / 12700.0, bool_1: false);
			}
			base.shape.Class174_0.Dictionary_0 = null;
			Class175[] array = new Class175[1];
			GraphicsPath graphicsPath = DrawHelper.PathBegin();
			Class175 @class = new Class175(bool_1: true, Enum32.const_5);
			Class177 class2 = DrawHelper.MoveTo(this.double_24, this.double_25);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_26, this.double_27);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, base.double_2, this.double_30);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_31, this.double_27);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_32, this.double_25);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_35, base.double_7);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_32, this.double_37);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_31, this.double_38);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, base.double_2, this.double_39);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_26, this.double_38);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_24, this.double_37);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_36, base.double_7);
			DrawHelper.Close(graphicsPath);
			@class.List_0.Add(graphicsPath);
			array[0] = @class;
			base.shape.Class183_0.Class175_0 = array;
		}
	}
}
