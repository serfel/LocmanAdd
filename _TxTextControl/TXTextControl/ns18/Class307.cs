using System.Drawing.Drawing2D;
using ns17;
using TXTextControl.Drawing;

namespace ns18
{
	internal class Class307 : ShapeObject
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

		public Class307(Shape shape_0)
		{
			base.shape = shape_0;
			base.shape.Class174_0.Class172_0.Clear();
			base.adj1 = Helper.FmlaLiteralValue(23520.0);
			base.adj2 = Helper.FmlaLiteralValue(11760.0);
			base.SetLoadedAvLstValues(base.shape);
		}

		internal override void CreateGraphicsPaths()
		{
			base.CreateBaseVariables(base.shape);
			this.double_11 = Helper.FmlaPinTo(0.0, base.adj1, 36745.0);
			this.double_12 = Helper.FmlaMultiplyDivide(this.double_11, 2.0, 1.0);
			this.double_13 = Helper.FmlaAddSubtract(100000.0, 0.0, this.double_12);
			this.double_14 = Helper.FmlaPinTo(0.0, base.adj2, this.double_13);
			this.double_15 = Helper.FmlaMultiplyDivide(base.double_1, this.double_11, 100000.0);
			this.double_16 = Helper.FmlaMultiplyDivide(base.double_1, this.double_14, 200000.0);
			this.double_17 = Helper.FmlaMultiplyDivide(base.double_8, 73490.0, 200000.0);
			this.double_18 = Helper.FmlaAddSubtract(base.double_7, 0.0, this.double_16);
			this.double_19 = Helper.FmlaAddSubtract(base.double_7, this.double_16, 0.0);
			this.double_20 = Helper.FmlaAddSubtract(this.double_18, 0.0, this.double_15);
			this.double_21 = Helper.FmlaAddSubtract(this.double_19, this.double_15, 0.0);
			this.double_22 = Helper.FmlaAddSubtract(base.double_2, 0.0, this.double_17);
			this.double_23 = Helper.FmlaAddSubtract(base.double_2, this.double_17, 0.0);
			this.double_24 = Helper.FmlaAddDivide(this.double_20, this.double_18, 2.0);
			this.double_25 = Helper.FmlaAddDivide(this.double_19, this.double_21, 2.0);
			if (base.shape.Class174_0.Class172_0.Count == 0)
			{
				double num = ((base.shape.Class174_0.Dictionary_0 == null || !base.shape.Class174_0.Dictionary_0.ContainsKey("adj1")) ? 23520.0 : base.adj1);
				AdjustObject adjustObject = new Class171(new Class177(base.double_3 / 12700.0, this.double_20 / 12700.0, bool_1: false), "Adj1", 0.0, 36745.0, num, base.shape, bool_0: true);
				adjustObject.DefaultValue = 23520.0;
				base.shape.Class174_0.Class172_0.method_0(adjustObject);
				num = ((base.shape.Class174_0.Dictionary_0 == null || !base.shape.Class174_0.Dictionary_0.ContainsKey("adj2")) ? 11760.0 : base.adj2);
				adjustObject = new Class171(new Class177(base.double_5 / 12700.0, this.double_18 / 12700.0, bool_1: false), "Adj2", 0.0, this.double_13, num, base.shape, bool_0: true);
				adjustObject.DefaultValue = 11760.0;
				base.shape.Class174_0.Class172_0.method_0(adjustObject);
			}
			else
			{
				base.shape.Class174_0.Class172_0[0].AdjustRectangle.Class178_0.Class177_1 = new Class177(base.double_3 / 12700.0, this.double_20 / 12700.0, bool_1: false);
				base.shape.Class174_0.Class172_0[1].AdjustRectangle.Class178_0.Class177_1 = new Class177(base.double_5 / 12700.0, this.double_18 / 12700.0, bool_1: false);
			}
			base.shape.Class174_0.Dictionary_0 = null;
			Class175[] array = new Class175[1];
			GraphicsPath graphicsPath = DrawHelper.PathBegin();
			Class175 @class = new Class175(bool_1: true, Enum32.const_5);
			Class177 class2 = DrawHelper.MoveTo(this.double_22, this.double_20);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_23, this.double_20);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_23, this.double_18);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_22, this.double_18);
			DrawHelper.Close(graphicsPath);
			class2 = DrawHelper.MoveTo(this.double_22, this.double_19);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_23, this.double_19);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_23, this.double_21);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_22, this.double_21);
			DrawHelper.Close(graphicsPath);
			@class.List_0.Add(graphicsPath);
			array[0] = @class;
			base.shape.Class183_0.Class175_0 = array;
		}
	}
}
