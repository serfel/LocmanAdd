using System.Drawing.Drawing2D;
using ns17;
using TXTextControl.Drawing;

namespace ns18
{
	internal class Class357 : ShapeObject
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

		public Class357(Shape shape_0)
		{
			base.shape = shape_0;
			base.shape.Class174_0.Class172_0.Clear();
			base.adj1 = Helper.FmlaLiteralValue(25000.0);
			base.adj2 = Helper.FmlaLiteralValue(16667.0);
			base.SetLoadedAvLstValues(base.shape);
		}

		internal override void CreateGraphicsPaths()
		{
			base.CreateBaseVariables(base.shape);
			this.double_11 = Helper.FmlaPinTo(1.0, base.adj1, 75000.0);
			this.double_12 = Helper.FmlaMultiplyDivide(70000.0, base.double_8, base.double_6);
			this.double_13 = Helper.FmlaPinTo(0.0, base.adj2, this.double_12);
			this.double_14 = Helper.FmlaMultiplyDivide(base.double_1, this.double_11, 100000.0);
			this.double_15 = Helper.FmlaMultiplyDivide(base.double_6, this.double_13, 100000.0);
			this.double_16 = Helper.FmlaAddSubtract(base.double_5, 0.0, this.double_15);
			this.double_17 = Helper.FmlaAddSubtract(base.t, base.ssd8, 0.0);
			this.double_18 = Helper.FmlaMultiplyDivide(base.cd4, 1.0, 14.0);
			this.double_19 = Helper.FmlaTangent(base.ssd8, this.double_18);
			this.double_20 = Helper.FmlaAddSubtract(this.double_16, 0.0, this.double_19);
			this.double_21 = Helper.FmlaTangent(this.double_14, this.double_18);
			this.double_22 = Helper.FmlaAddSubtract(this.double_17, this.double_14, 0.0);
			this.double_23 = Helper.FmlaAddSubtract(this.double_16, this.double_21, 0.0);
			this.double_24 = Helper.FmlaAddSubtract(this.double_23, this.double_19, 0.0);
			this.double_25 = Helper.FmlaAddSubtract(this.double_22, base.ssd8, 0.0);
			this.double_26 = Helper.FmlaAddSubtract(this.double_25, 0.0, base.t);
			this.double_27 = Helper.FmlaMultiplyDivide(this.double_26, 1.0, 2.0);
			this.double_28 = Helper.FmlaMultiplyDivide(base.double_1, 1.0, 20.0);
			this.double_29 = Helper.FmlaAddSubtract(base.t, this.double_27, this.double_28);
			this.double_30 = Helper.FmlaMultiplyDivide(base.hd6, 1.0, 1.0);
			this.double_31 = Helper.FmlaAddSubtract(base.hd6, this.double_30, 0.0);
			this.double_32 = Helper.FmlaLiteralValue(base.wd6);
			this.double_33 = Helper.FmlaMultiplyDivide(base.hd6, 1.0, 2.0);
			this.double_34 = Helper.FmlaAddSubtract(this.double_22, this.double_33, 0.0);
			this.double_35 = Helper.FmlaLiteralValue(base.wd4);
			if (base.shape.Class174_0.Class172_0.Count == 0)
			{
				double num = ((base.shape.Class174_0.Dictionary_0 == null || !base.shape.Class174_0.Dictionary_0.ContainsKey("adj1")) ? 25000.0 : base.adj1);
				AdjustObject adjustObject = new Class171(new Class177(this.double_23 / 12700.0, this.double_22 / 12700.0, bool_1: false), "Adj1", 1.0, 75000.0, num, base.shape, bool_0: false);
				adjustObject.DefaultValue = 25000.0;
				base.shape.Class174_0.Class172_0.method_0(adjustObject);
				num = ((base.shape.Class174_0.Dictionary_0 == null || !base.shape.Class174_0.Dictionary_0.ContainsKey("adj2")) ? 16667.0 : base.adj2);
				adjustObject = new Class170(new Class177(this.double_16 / 12700.0, this.double_17 / 12700.0, bool_1: false), "Adj2", 0.0, this.double_12, num, base.shape, bool_0: true);
				adjustObject.DefaultValue = 16667.0;
				base.shape.Class174_0.Class172_0.method_0(adjustObject);
			}
			else
			{
				base.shape.Class174_0.Class172_0[0].AdjustRectangle.Class178_0.Class177_1 = new Class177(this.double_23 / 12700.0, this.double_22 / 12700.0, bool_1: false);
				base.shape.Class174_0.Class172_0[1].AdjustRectangle.Class178_0.Class177_1 = new Class177(this.double_16 / 12700.0, this.double_17 / 12700.0, bool_1: false);
			}
			base.shape.Class174_0.Dictionary_0 = null;
			Class175[] array = new Class175[1];
			GraphicsPath graphicsPath = DrawHelper.PathBegin();
			Class175 @class = new Class175(bool_1: true, Enum32.const_5);
			Class177 point = DrawHelper.MoveTo(base.double_3, base.double_0);
			base.ipt2 = new Class177(this.double_32, this.double_31, bool_1: true);
			base.ipt3 = new Class177(this.double_16, this.double_17, bool_1: true);
			point = DrawHelper.QuadBezTo(graphicsPath, point, base.ipt2, base.ipt3);
			point = DrawHelper.LnTo(graphicsPath, point.Double_2, point.Double_3, this.double_20, base.t);
			point = DrawHelper.LnTo(graphicsPath, point.Double_2, point.Double_3, base.double_5, this.double_29);
			point = DrawHelper.LnTo(graphicsPath, point.Double_2, point.Double_3, this.double_24, this.double_25);
			point = DrawHelper.LnTo(graphicsPath, point.Double_2, point.Double_3, this.double_23, this.double_22);
			base.ipt2 = new Class177(this.double_35, this.double_34, bool_1: true);
			base.ipt3 = new Class177(base.double_3, base.double_0, bool_1: true);
			point = DrawHelper.QuadBezTo(graphicsPath, point, base.ipt2, base.ipt3);
			DrawHelper.Close(graphicsPath);
			@class.List_0.Add(graphicsPath);
			array[0] = @class;
			base.shape.Class183_0.Class175_0 = array;
		}
	}
}
