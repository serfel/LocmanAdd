using System.Drawing.Drawing2D;
using ns17;
using TXTextControl.Drawing;

namespace ns18
{
	internal class Class287 : ShapeObject
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

		public Class287(Shape shape_0)
		{
			base.shape = shape_0;
			base.shape.Class174_0.Class172_0.Clear();
			base.adj = Helper.FmlaLiteralValue(25000.0);
			base.double_10 = Helper.FmlaLiteralValue(115470.0);
			base.SaveVF = true;
			base.SetLoadedAvLstValues(base.shape);
		}

		internal override void CreateGraphicsPaths()
		{
			base.CreateBaseVariables(base.shape);
			this.double_11 = Helper.FmlaMultiplyDivide(50000.0, base.double_8, base.double_6);
			this.double_12 = Helper.FmlaPinTo(0.0, base.adj, this.double_11);
			this.double_13 = Helper.FmlaMultiplyDivide(base.hd2, base.double_10, 100000.0);
			this.double_14 = Helper.FmlaMultiplyDivide(base.double_6, this.double_12, 100000.0);
			this.double_15 = Helper.FmlaAddSubtract(base.double_5, 0.0, this.double_14);
			this.double_16 = Helper.FmlaSine(this.double_13, 3600000.0);
			this.double_17 = Helper.FmlaAddSubtract(base.double_7, 0.0, this.double_16);
			this.double_18 = Helper.FmlaAddSubtract(base.double_7, this.double_16, 0.0);
			this.double_19 = Helper.FmlaMultiplyDivide(this.double_11, -1.0, 2.0);
			this.double_20 = Helper.FmlaAddSubtract(this.double_12, this.double_19, 0.0);
			this.double_21 = Helper.FmlaIfElse(this.double_20, 4.0, 2.0);
			this.double_22 = Helper.FmlaIfElse(this.double_20, 3.0, 2.0);
			this.double_23 = Helper.FmlaIfElse(this.double_20, this.double_19, 0.0);
			this.double_24 = Helper.FmlaAddDivide(this.double_12, this.double_23, this.double_19);
			this.double_25 = Helper.FmlaMultiplyDivide(this.double_24, this.double_22, -1.0);
			this.double_26 = Helper.FmlaAddSubtract(this.double_21, this.double_25, 0.0);
			this.double_27 = Helper.FmlaMultiplyDivide(base.double_8, this.double_26, 24.0);
			this.double_28 = Helper.FmlaMultiplyDivide(base.double_1, this.double_26, 24.0);
			this.double_29 = Helper.FmlaAddSubtract(base.double_5, 0.0, this.double_27);
			this.double_30 = Helper.FmlaAddSubtract(base.double_0, 0.0, this.double_28);
			if (base.shape.Class174_0.Class172_0.Count == 0)
			{
				double num = ((base.shape.Class174_0.Dictionary_0 == null || !base.shape.Class174_0.Dictionary_0.ContainsKey("adj")) ? 25000.0 : base.adj);
				AdjustObject adjustObject = new Class170(new Class177(this.double_14 / 12700.0, base.t / 12700.0, bool_1: false), "Adj", 0.0, this.double_11, num, base.shape, bool_0: false);
				adjustObject.DefaultValue = 25000.0;
				base.shape.Class174_0.Class172_0.method_0(adjustObject);
			}
			else
			{
				base.shape.Class174_0.Class172_0[0].AdjustRectangle.Class178_0.Class177_1 = new Class177(this.double_14 / 12700.0, base.t / 12700.0, bool_1: false);
			}
			base.shape.Class174_0.Dictionary_0 = null;
			Class175[] array = new Class175[1];
			GraphicsPath graphicsPath = DrawHelper.PathBegin();
			Class175 @class = new Class175(bool_1: true, Enum32.const_5);
			Class177 class2 = DrawHelper.MoveTo(base.double_3, base.double_7);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_14, this.double_17);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_15, this.double_17);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, base.double_5, base.double_7);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_15, this.double_18);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_14, this.double_18);
			DrawHelper.Close(graphicsPath);
			@class.List_0.Add(graphicsPath);
			array[0] = @class;
			base.shape.Class183_0.Class175_0 = array;
		}
	}
}
