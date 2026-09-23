using System.Drawing.Drawing2D;
using ns17;
using TXTextControl.Drawing;

namespace ns18
{
	internal class Class325 : ShapeObject
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

		public Class325(Shape shape_0)
		{
			base.shape = shape_0;
			base.shape.Class174_0.Class172_0.Clear();
			base.adj1 = Helper.FmlaLiteralValue(18515.0);
			base.adj2 = Helper.FmlaLiteralValue(18515.0);
			base.adj3 = Helper.FmlaLiteralValue(18515.0);
			base.adj4 = Helper.FmlaLiteralValue(48123.0);
			base.SetLoadedAvLstValues(base.shape);
		}

		internal override void CreateGraphicsPaths()
		{
			base.CreateBaseVariables(base.shape);
			this.double_11 = Helper.FmlaPinTo(0.0, base.adj2, 50000.0);
			this.double_12 = Helper.FmlaMultiplyDivide(this.double_11, 2.0, 1.0);
			this.double_13 = Helper.FmlaPinTo(0.0, base.adj1, this.double_12);
			this.double_14 = Helper.FmlaAddSubtract(50000.0, 0.0, this.double_11);
			this.double_15 = Helper.FmlaPinTo(0.0, base.adj3, this.double_14);
			this.double_16 = Helper.FmlaMultiplyDivide(this.double_15, 2.0, 1.0);
			this.double_17 = Helper.FmlaAddSubtract(100000.0, 0.0, this.double_16);
			this.double_18 = Helper.FmlaPinTo(this.double_13, base.adj4, this.double_17);
			this.double_19 = Helper.FmlaMultiplyDivide(base.double_6, this.double_11, 100000.0);
			this.double_20 = Helper.FmlaMultiplyDivide(base.double_6, this.double_13, 200000.0);
			this.double_21 = Helper.FmlaMultiplyDivide(base.double_6, this.double_15, 100000.0);
			this.double_22 = Helper.FmlaMultiplyDivide(base.double_8, this.double_18, 200000.0);
			this.double_23 = Helper.FmlaMultiplyDivide(base.double_1, this.double_18, 200000.0);
			this.double_24 = Helper.FmlaAddSubtract(base.double_5, 0.0, this.double_21);
			this.double_25 = Helper.FmlaAddSubtract(base.double_2, 0.0, this.double_22);
			this.double_26 = Helper.FmlaAddSubtract(base.double_2, this.double_22, 0.0);
			this.double_27 = Helper.FmlaAddSubtract(base.double_2, 0.0, this.double_19);
			this.double_28 = Helper.FmlaAddSubtract(base.double_2, this.double_19, 0.0);
			this.double_29 = Helper.FmlaAddSubtract(base.double_2, 0.0, this.double_20);
			this.double_30 = Helper.FmlaAddSubtract(base.double_2, this.double_20, 0.0);
			this.double_31 = Helper.FmlaAddSubtract(base.double_0, 0.0, this.double_21);
			this.double_32 = Helper.FmlaAddSubtract(base.double_7, 0.0, this.double_23);
			this.double_33 = Helper.FmlaAddSubtract(base.double_7, this.double_23, 0.0);
			this.double_34 = Helper.FmlaAddSubtract(base.double_7, 0.0, this.double_19);
			this.double_35 = Helper.FmlaAddSubtract(base.double_7, this.double_19, 0.0);
			this.double_36 = Helper.FmlaAddSubtract(base.double_7, 0.0, this.double_20);
			this.double_37 = Helper.FmlaAddSubtract(base.double_7, this.double_20, 0.0);
			if (base.shape.Class174_0.Class172_0.Count == 0)
			{
				double num = ((base.shape.Class174_0.Dictionary_0 == null || !base.shape.Class174_0.Dictionary_0.ContainsKey("adj1")) ? 18515.0 : base.adj1);
				AdjustObject adjustObject = new Class170(new Class177(this.double_29 / 12700.0, this.double_21 / 12700.0, bool_1: false), "Adj1", 0.0, this.double_12, num, base.shape, bool_0: true);
				adjustObject.DefaultValue = 18515.0;
				base.shape.Class174_0.Class172_0.method_0(adjustObject);
				num = ((base.shape.Class174_0.Dictionary_0 == null || !base.shape.Class174_0.Dictionary_0.ContainsKey("adj2")) ? 18515.0 : base.adj2);
				adjustObject = new Class170(new Class177(this.double_27 / 12700.0, base.t / 12700.0, bool_1: false), "Adj2", 0.0, 50000.0, num, base.shape, bool_0: true);
				adjustObject.DefaultValue = 18515.0;
				base.shape.Class174_0.Class172_0.method_0(adjustObject);
				num = ((base.shape.Class174_0.Dictionary_0 == null || !base.shape.Class174_0.Dictionary_0.ContainsKey("adj3")) ? 18515.0 : base.adj3);
				adjustObject = new Class171(new Class177(base.double_5 / 12700.0, this.double_21 / 12700.0, bool_1: false), "Adj3", 0.0, this.double_14, num, base.shape, bool_0: false);
				adjustObject.DefaultValue = 18515.0;
				base.shape.Class174_0.Class172_0.method_0(adjustObject);
				num = ((base.shape.Class174_0.Dictionary_0 == null || !base.shape.Class174_0.Dictionary_0.ContainsKey("adj4")) ? 48123.0 : base.adj4);
				adjustObject = new Class171(new Class177(base.double_3 / 12700.0, this.double_32 / 12700.0, bool_1: false), "Adj4", this.double_13, this.double_17, num, base.shape, bool_0: true);
				adjustObject.DefaultValue = 48123.0;
				base.shape.Class174_0.Class172_0.method_0(adjustObject);
			}
			else
			{
				base.shape.Class174_0.Class172_0[0].AdjustRectangle.Class178_0.Class177_1 = new Class177(this.double_29 / 12700.0, this.double_21 / 12700.0, bool_1: false);
				base.shape.Class174_0.Class172_0[1].AdjustRectangle.Class178_0.Class177_1 = new Class177(this.double_27 / 12700.0, base.t / 12700.0, bool_1: false);
				base.shape.Class174_0.Class172_0[2].AdjustRectangle.Class178_0.Class177_1 = new Class177(base.double_5 / 12700.0, this.double_21 / 12700.0, bool_1: false);
				base.shape.Class174_0.Class172_0[3].AdjustRectangle.Class178_0.Class177_1 = new Class177(base.double_3 / 12700.0, this.double_32 / 12700.0, bool_1: false);
			}
			base.shape.Class174_0.Dictionary_0 = null;
			Class175[] array = new Class175[1];
			GraphicsPath graphicsPath = DrawHelper.PathBegin();
			Class175 @class = new Class175(bool_1: true, Enum32.const_5);
			Class177 class2 = DrawHelper.MoveTo(base.double_3, base.double_7);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_21, this.double_34);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_21, this.double_36);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_25, this.double_36);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_25, this.double_32);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_29, this.double_32);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_29, this.double_21);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_27, this.double_21);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, base.double_2, base.t);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_28, this.double_21);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_30, this.double_21);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_30, this.double_32);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_26, this.double_32);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_26, this.double_36);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_24, this.double_36);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_24, this.double_34);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, base.double_5, base.double_7);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_24, this.double_35);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_24, this.double_37);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_26, this.double_37);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_26, this.double_33);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_30, this.double_33);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_30, this.double_31);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_28, this.double_31);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, base.double_2, base.double_0);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_27, this.double_31);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_29, this.double_31);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_29, this.double_33);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_25, this.double_33);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_25, this.double_37);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_21, this.double_37);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_21, this.double_35);
			DrawHelper.Close(graphicsPath);
			@class.List_0.Add(graphicsPath);
			array[0] = @class;
			base.shape.Class183_0.Class175_0 = array;
		}
	}
}
