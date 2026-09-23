using System.Drawing.Drawing2D;
using ns17;
using TXTextControl.Drawing;

namespace ns18
{
	internal class Class350 : ShapeObject
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

		public Class350(Shape shape_0)
		{
			base.shape = shape_0;
			base.shape.Class174_0.Class172_0.Clear();
			base.adj = Helper.FmlaLiteralValue(19098.0);
			base.double_9 = Helper.FmlaLiteralValue(105146.0);
			base.SaveHF = true;
			base.double_10 = Helper.FmlaLiteralValue(110557.0);
			base.SaveVF = true;
			base.SetLoadedAvLstValues(base.shape);
		}

		internal override void CreateGraphicsPaths()
		{
			base.CreateBaseVariables(base.shape);
			this.double_11 = Helper.FmlaPinTo(0.0, base.adj, 50000.0);
			this.double_12 = Helper.FmlaMultiplyDivide(base.wd2, base.double_9, 100000.0);
			this.double_13 = Helper.FmlaMultiplyDivide(base.hd2, base.double_10, 100000.0);
			this.double_14 = Helper.FmlaMultiplyDivide(base.double_7, base.double_10, 100000.0);
			this.double_15 = Helper.FmlaCosine(this.double_12, 1080000.0);
			this.double_16 = Helper.FmlaCosine(this.double_12, 18360000.0);
			this.double_17 = Helper.FmlaSine(this.double_13, 1080000.0);
			this.double_18 = Helper.FmlaSine(this.double_13, 18360000.0);
			this.double_19 = Helper.FmlaAddSubtract(base.double_2, 0.0, this.double_15);
			this.double_20 = Helper.FmlaAddSubtract(base.double_2, 0.0, this.double_16);
			this.double_21 = Helper.FmlaAddSubtract(base.double_2, this.double_16, 0.0);
			this.double_22 = Helper.FmlaAddSubtract(base.double_2, this.double_15, 0.0);
			this.double_23 = Helper.FmlaAddSubtract(this.double_14, 0.0, this.double_17);
			this.double_24 = Helper.FmlaAddSubtract(this.double_14, 0.0, this.double_18);
			this.double_25 = Helper.FmlaMultiplyDivide(this.double_12, this.double_11, 50000.0);
			this.double_26 = Helper.FmlaMultiplyDivide(this.double_13, this.double_11, 50000.0);
			this.double_27 = Helper.FmlaCosine(this.double_25, 20520000.0);
			this.double_28 = Helper.FmlaCosine(this.double_25, 3240000.0);
			this.double_29 = Helper.FmlaSine(this.double_26, 3240000.0);
			this.double_30 = Helper.FmlaSine(this.double_26, 20520000.0);
			this.double_31 = Helper.FmlaAddSubtract(base.double_2, 0.0, this.double_27);
			this.double_32 = Helper.FmlaAddSubtract(base.double_2, 0.0, this.double_28);
			this.double_33 = Helper.FmlaAddSubtract(base.double_2, this.double_28, 0.0);
			this.double_34 = Helper.FmlaAddSubtract(base.double_2, this.double_27, 0.0);
			this.double_35 = Helper.FmlaAddSubtract(this.double_14, 0.0, this.double_29);
			this.double_36 = Helper.FmlaAddSubtract(this.double_14, 0.0, this.double_30);
			this.double_37 = Helper.FmlaAddSubtract(this.double_14, this.double_26, 0.0);
			this.double_38 = Helper.FmlaAddSubtract(this.double_14, 0.0, this.double_26);
			if (base.shape.Class174_0.Class172_0.Count == 0)
			{
				double num = ((base.shape.Class174_0.Dictionary_0 == null || !base.shape.Class174_0.Dictionary_0.ContainsKey("adj")) ? 19098.0 : base.adj);
				AdjustObject adjustObject = new Class171(new Class177(base.double_2 / 12700.0, this.double_38 / 12700.0, bool_1: false), "Adj", 0.0, 50000.0, num, base.shape, bool_0: true);
				adjustObject.DefaultValue = 19098.0;
				base.shape.Class174_0.Class172_0.method_0(adjustObject);
			}
			else
			{
				base.shape.Class174_0.Class172_0[0].AdjustRectangle.Class178_0.Class177_1 = new Class177(base.double_2 / 12700.0, this.double_38 / 12700.0, bool_1: false);
			}
			base.shape.Class174_0.Dictionary_0 = null;
			Class175[] array = new Class175[1];
			GraphicsPath graphicsPath = DrawHelper.PathBegin();
			Class175 @class = new Class175(bool_1: true, Enum32.const_5);
			Class177 class2 = DrawHelper.MoveTo(this.double_19, this.double_23);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_32, this.double_35);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, base.double_2, base.t);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_33, this.double_35);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_22, this.double_23);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_34, this.double_36);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_21, this.double_24);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, base.double_2, this.double_37);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_20, this.double_24);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_31, this.double_36);
			DrawHelper.Close(graphicsPath);
			@class.List_0.Add(graphicsPath);
			array[0] = @class;
			base.shape.Class183_0.Class175_0 = array;
		}
	}
}
