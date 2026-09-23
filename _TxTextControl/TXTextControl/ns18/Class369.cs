using System.Drawing.Drawing2D;
using ns17;
using TXTextControl.Drawing;

namespace ns18
{
	internal class Class369 : ShapeObject
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

		private double double_43;

		private double double_44;

		public Class369(Shape shape_0)
		{
			base.shape = shape_0;
			base.shape.Class174_0.Class172_0.Clear();
			base.adj1 = Helper.FmlaLiteralValue(-20833.0);
			base.adj2 = Helper.FmlaLiteralValue(62500.0);
			base.SetLoadedAvLstValues(base.shape);
		}

		internal override void CreateGraphicsPaths()
		{
			base.CreateBaseVariables(base.shape);
			this.double_11 = Helper.FmlaMultiplyDivide(base.double_8, base.adj1, 100000.0);
			this.double_12 = Helper.FmlaMultiplyDivide(base.double_1, base.adj2, 100000.0);
			this.double_13 = Helper.FmlaAddSubtract(base.double_2, this.double_11, 0.0);
			this.double_14 = Helper.FmlaAddSubtract(base.double_7, this.double_12, 0.0);
			this.double_15 = Helper.FmlaAddSubtract(this.double_13, 0.0, base.double_2);
			this.double_16 = Helper.FmlaAddSubtract(this.double_14, 0.0, base.double_7);
			this.double_17 = Helper.FmlaMultiplyDivide(this.double_11, base.double_1, base.double_8);
			this.double_18 = Helper.FmlaAbsoluteValue(this.double_12);
			this.double_19 = Helper.FmlaAbsoluteValue(this.double_17);
			this.double_20 = Helper.FmlaAddSubtract(this.double_18, 0.0, this.double_19);
			this.double_21 = Helper.FmlaIfElse(this.double_11, 7.0, 2.0);
			this.double_22 = Helper.FmlaIfElse(this.double_11, 10.0, 5.0);
			this.double_23 = Helper.FmlaMultiplyDivide(base.double_8, this.double_21, 12.0);
			this.double_24 = Helper.FmlaMultiplyDivide(base.double_8, this.double_22, 12.0);
			this.double_25 = Helper.FmlaIfElse(this.double_12, 7.0, 2.0);
			this.double_26 = Helper.FmlaIfElse(this.double_12, 10.0, 5.0);
			this.double_27 = Helper.FmlaMultiplyDivide(base.double_1, this.double_25, 12.0);
			this.double_28 = Helper.FmlaMultiplyDivide(base.double_1, this.double_26, 12.0);
			this.double_29 = Helper.FmlaIfElse(this.double_11, base.double_3, this.double_13);
			this.double_30 = Helper.FmlaIfElse(this.double_20, base.double_3, this.double_29);
			this.double_31 = Helper.FmlaIfElse(this.double_12, this.double_23, this.double_13);
			this.double_32 = Helper.FmlaIfElse(this.double_20, this.double_31, this.double_23);
			this.double_33 = Helper.FmlaIfElse(this.double_11, this.double_13, base.double_5);
			this.double_34 = Helper.FmlaIfElse(this.double_20, base.double_5, this.double_33);
			this.double_35 = Helper.FmlaIfElse(this.double_12, this.double_13, this.double_23);
			this.double_36 = Helper.FmlaIfElse(this.double_20, this.double_35, this.double_23);
			this.double_37 = Helper.FmlaIfElse(this.double_11, this.double_27, this.double_14);
			this.double_38 = Helper.FmlaIfElse(this.double_20, this.double_27, this.double_37);
			this.double_39 = Helper.FmlaIfElse(this.double_12, base.t, this.double_14);
			this.double_40 = Helper.FmlaIfElse(this.double_20, this.double_39, base.t);
			this.double_41 = Helper.FmlaIfElse(this.double_11, this.double_14, this.double_27);
			this.double_42 = Helper.FmlaIfElse(this.double_20, this.double_27, this.double_41);
			this.double_43 = Helper.FmlaIfElse(this.double_12, this.double_14, base.double_0);
			this.double_44 = Helper.FmlaIfElse(this.double_20, this.double_43, base.double_0);
			if (base.shape.Class174_0.Class172_0.Count == 0)
			{
				double num = ((base.shape.Class174_0.Dictionary_0 == null || !base.shape.Class174_0.Dictionary_0.ContainsKey("adj1")) ? (-20833.0) : base.adj1);
				AdjustObject adjustObject = new Class170(new Class177(this.double_13 / 12700.0, this.double_14 / 12700.0, bool_1: false), "Adj1", -2147483647.0, 2147483647.0, num, base.shape, bool_0: false);
				adjustObject.DefaultValue = -20833.0;
				base.shape.Class174_0.Class172_0.method_0(adjustObject);
				num = ((base.shape.Class174_0.Dictionary_0 == null || !base.shape.Class174_0.Dictionary_0.ContainsKey("adj2")) ? 62500.0 : base.adj2);
				adjustObject = new Class171(new Class177(this.double_13 / 12700.0, this.double_14 / 12700.0, bool_1: false), "Adj2", -2147483647.0, 2147483647.0, num, base.shape, bool_0: false);
				adjustObject.DefaultValue = 62500.0;
				base.shape.Class174_0.Class172_0.method_0(adjustObject);
			}
			else
			{
				base.shape.Class174_0.Class172_0[0].AdjustRectangle.Class178_0.Class177_1 = new Class177(this.double_13 / 12700.0, this.double_14 / 12700.0, bool_1: false);
				base.shape.Class174_0.Class172_0[1].AdjustRectangle.Class178_0.Class177_1 = new Class177(this.double_13 / 12700.0, this.double_14 / 12700.0, bool_1: false);
			}
			base.shape.Class174_0.Dictionary_0 = null;
			Class175[] array = new Class175[1];
			GraphicsPath graphicsPath = DrawHelper.PathBegin();
			Class175 @class = new Class175(bool_1: true, Enum32.const_5);
			Class177 class2 = DrawHelper.MoveTo(base.double_3, base.t);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_23, base.t);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_32, this.double_40);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_24, base.t);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, base.double_5, base.t);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, base.double_5, this.double_27);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_34, this.double_42);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, base.double_5, this.double_28);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, base.double_5, base.double_0);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_24, base.double_0);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_36, this.double_44);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_23, base.double_0);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, base.double_3, base.double_0);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, base.double_3, this.double_28);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_30, this.double_38);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, base.double_3, this.double_27);
			DrawHelper.Close(graphicsPath);
			@class.List_0.Add(graphicsPath);
			array[0] = @class;
			base.shape.Class183_0.Class175_0 = array;
		}
	}
}
