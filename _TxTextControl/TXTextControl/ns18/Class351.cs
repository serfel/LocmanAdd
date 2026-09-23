using System.Drawing.Drawing2D;
using ns17;
using TXTextControl.Drawing;

namespace ns18
{
	internal class Class351 : ShapeObject
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

		public Class351(Shape shape_0)
		{
			base.shape = shape_0;
			base.shape.Class174_0.Class172_0.Clear();
			base.adj = Helper.FmlaLiteralValue(28868.0);
			base.double_9 = Helper.FmlaLiteralValue(115470.0);
			base.SaveHF = true;
			base.SetLoadedAvLstValues(base.shape);
		}

		internal override void CreateGraphicsPaths()
		{
			base.CreateBaseVariables(base.shape);
			this.double_11 = Helper.FmlaPinTo(0.0, base.adj, 50000.0);
			this.double_12 = Helper.FmlaMultiplyDivide(base.wd2, base.double_9, 100000.0);
			this.double_13 = Helper.FmlaCosine(this.double_12, 1800000.0);
			this.double_14 = Helper.FmlaAddSubtract(base.double_2, 0.0, this.double_13);
			this.double_15 = Helper.FmlaAddSubtract(base.double_2, this.double_13, 0.0);
			this.double_16 = Helper.FmlaAddSubtract(base.double_7, base.hd4, 0.0);
			this.double_17 = Helper.FmlaMultiplyDivide(this.double_12, this.double_11, 50000.0);
			this.double_18 = Helper.FmlaMultiplyDivide(base.hd2, this.double_11, 50000.0);
			this.double_19 = Helper.FmlaMultiplyDivide(this.double_17, 1.0, 2.0);
			this.double_20 = Helper.FmlaAddSubtract(base.double_2, 0.0, this.double_17);
			this.double_21 = Helper.FmlaAddSubtract(base.double_2, 0.0, this.double_19);
			this.double_22 = Helper.FmlaAddSubtract(base.double_2, this.double_19, 0.0);
			this.double_23 = Helper.FmlaAddSubtract(base.double_2, this.double_17, 0.0);
			this.double_24 = Helper.FmlaSine(this.double_18, 3600000.0);
			this.double_25 = Helper.FmlaAddSubtract(base.double_7, 0.0, this.double_24);
			this.double_26 = Helper.FmlaAddSubtract(base.double_7, this.double_24, 0.0);
			this.double_27 = Helper.FmlaAddSubtract(base.double_7, 0.0, this.double_18);
			if (base.shape.Class174_0.Class172_0.Count == 0)
			{
				double num = ((base.shape.Class174_0.Dictionary_0 == null || !base.shape.Class174_0.Dictionary_0.ContainsKey("adj")) ? 28868.0 : base.adj);
				AdjustObject adjustObject = new Class171(new Class177(base.double_2 / 12700.0, this.double_27 / 12700.0, bool_1: false), "Adj", 0.0, 50000.0, num, base.shape, bool_0: true);
				adjustObject.DefaultValue = 28868.0;
				base.shape.Class174_0.Class172_0.method_0(adjustObject);
			}
			else
			{
				base.shape.Class174_0.Class172_0[0].AdjustRectangle.Class178_0.Class177_1 = new Class177(base.double_2 / 12700.0, this.double_27 / 12700.0, bool_1: false);
			}
			base.shape.Class174_0.Dictionary_0 = null;
			Class175[] array = new Class175[1];
			GraphicsPath graphicsPath = DrawHelper.PathBegin();
			Class175 @class = new Class175(bool_1: true, Enum32.const_5);
			Class177 class2 = DrawHelper.MoveTo(this.double_14, base.hd4);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_21, this.double_25);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, base.double_2, base.t);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_22, this.double_25);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_15, base.hd4);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_23, base.double_7);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_15, this.double_16);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_22, this.double_26);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, base.double_2, base.double_0);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_21, this.double_26);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_14, this.double_16);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_20, base.double_7);
			DrawHelper.Close(graphicsPath);
			@class.List_0.Add(graphicsPath);
			array[0] = @class;
			base.shape.Class183_0.Class175_0 = array;
		}
	}
}
