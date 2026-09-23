using System.Drawing.Drawing2D;
using ns17;
using TXTextControl.Drawing;

namespace ns18
{
	internal class Class345 : ShapeObject
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

		public Class345(Shape shape_0)
		{
			base.shape = shape_0;
			base.shape.Class174_0.Class172_0.Clear();
			base.adj = Helper.FmlaLiteralValue(37500.0);
			base.SetLoadedAvLstValues(base.shape);
		}

		internal override void CreateGraphicsPaths()
		{
			base.CreateBaseVariables(base.shape);
			this.double_11 = Helper.FmlaPinTo(0.0, base.adj, 50000.0);
			this.double_12 = Helper.FmlaCosine(base.wd2, 1800000.0);
			this.double_13 = Helper.FmlaSine(base.hd2, 3600000.0);
			this.double_14 = Helper.FmlaAddSubtract(base.double_2, 0.0, this.double_12);
			this.double_15 = Helper.FmlaMultiplyDivide(base.double_8, 3.0, 4.0);
			this.double_16 = Helper.FmlaAddSubtract(base.double_2, this.double_12, 0.0);
			this.double_17 = Helper.FmlaAddSubtract(base.double_7, 0.0, this.double_13);
			this.double_18 = Helper.FmlaMultiplyDivide(base.double_1, 3.0, 4.0);
			this.double_19 = Helper.FmlaAddSubtract(base.double_7, this.double_13, 0.0);
			this.double_20 = Helper.FmlaMultiplyDivide(base.wd2, this.double_11, 50000.0);
			this.double_21 = Helper.FmlaMultiplyDivide(base.hd2, this.double_11, 50000.0);
			this.double_22 = Helper.FmlaCosine(this.double_20, 900000.0);
			this.double_23 = Helper.FmlaCosine(this.double_20, 2700000.0);
			this.double_24 = Helper.FmlaCosine(this.double_20, 4500000.0);
			this.double_25 = Helper.FmlaSine(this.double_21, 4500000.0);
			this.double_26 = Helper.FmlaSine(this.double_21, 2700000.0);
			this.double_27 = Helper.FmlaSine(this.double_21, 900000.0);
			this.double_28 = Helper.FmlaAddSubtract(base.double_2, 0.0, this.double_22);
			this.double_29 = Helper.FmlaAddSubtract(base.double_2, 0.0, this.double_23);
			this.double_30 = Helper.FmlaAddSubtract(base.double_2, 0.0, this.double_24);
			this.double_31 = Helper.FmlaAddSubtract(base.double_2, this.double_24, 0.0);
			this.double_32 = Helper.FmlaAddSubtract(base.double_2, this.double_23, 0.0);
			this.double_33 = Helper.FmlaAddSubtract(base.double_2, this.double_22, 0.0);
			this.double_34 = Helper.FmlaAddSubtract(base.double_7, 0.0, this.double_25);
			this.double_35 = Helper.FmlaAddSubtract(base.double_7, 0.0, this.double_26);
			this.double_36 = Helper.FmlaAddSubtract(base.double_7, 0.0, this.double_27);
			this.double_37 = Helper.FmlaAddSubtract(base.double_7, this.double_27, 0.0);
			this.double_38 = Helper.FmlaAddSubtract(base.double_7, this.double_26, 0.0);
			this.double_39 = Helper.FmlaAddSubtract(base.double_7, this.double_25, 0.0);
			this.double_40 = Helper.FmlaAddSubtract(base.double_7, 0.0, this.double_21);
			if (base.shape.Class174_0.Class172_0.Count == 0)
			{
				double num = ((base.shape.Class174_0.Dictionary_0 == null || !base.shape.Class174_0.Dictionary_0.ContainsKey("adj")) ? 37500.0 : base.adj);
				AdjustObject adjustObject = new Class171(new Class177(base.double_2 / 12700.0, this.double_40 / 12700.0, bool_1: false), "Adj", 0.0, 50000.0, num, base.shape, bool_0: true);
				adjustObject.DefaultValue = 37500.0;
				base.shape.Class174_0.Class172_0.method_0(adjustObject);
			}
			else
			{
				base.shape.Class174_0.Class172_0[0].AdjustRectangle.Class178_0.Class177_1 = new Class177(base.double_2 / 12700.0, this.double_40 / 12700.0, bool_1: false);
			}
			base.shape.Class174_0.Dictionary_0 = null;
			Class175[] array = new Class175[1];
			GraphicsPath graphicsPath = DrawHelper.PathBegin();
			Class175 @class = new Class175(bool_1: true, Enum32.const_5);
			Class177 class2 = DrawHelper.MoveTo(base.double_3, base.double_7);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_28, this.double_36);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_14, base.hd4);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_29, this.double_35);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, base.wd4, this.double_17);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_30, this.double_34);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, base.double_2, base.t);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_31, this.double_34);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_15, this.double_17);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_32, this.double_35);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_16, base.hd4);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_33, this.double_36);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, base.double_5, base.double_7);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_33, this.double_37);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_16, this.double_18);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_32, this.double_38);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_15, this.double_19);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_31, this.double_39);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, base.double_2, base.double_0);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_30, this.double_39);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, base.wd4, this.double_19);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_29, this.double_38);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_14, this.double_18);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_28, this.double_37);
			DrawHelper.Close(graphicsPath);
			@class.List_0.Add(graphicsPath);
			array[0] = @class;
			base.shape.Class183_0.Class175_0 = array;
		}
	}
}
