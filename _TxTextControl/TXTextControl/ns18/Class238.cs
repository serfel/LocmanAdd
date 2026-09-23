using System.Drawing.Drawing2D;
using ns17;
using TXTextControl.Drawing;

namespace ns18
{
	internal class Class238 : ShapeObject
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

		private double double_45;

		private double double_46;

		private double double_47;

		private double double_48;

		private double double_49;

		private double double_50;

		private double double_51;

		private double double_52;

		public Class238(Shape shape_0)
		{
			base.shape = shape_0;
			base.shape.Class174_0.Class172_0.Clear();
			base.adj1 = Helper.FmlaLiteralValue(25000.0);
			base.adj2 = Helper.FmlaLiteralValue(50000.0);
			base.adj3 = Helper.FmlaLiteralValue(25000.0);
			base.SetLoadedAvLstValues(base.shape);
		}

		internal override void CreateGraphicsPaths()
		{
			base.CreateBaseVariables(base.shape);
			this.double_11 = Helper.FmlaMultiplyDivide(50000.0, base.double_8, base.double_6);
			this.double_12 = Helper.FmlaPinTo(0.0, base.adj2, this.double_11);
			this.double_13 = Helper.FmlaPinTo(0.0, base.adj1, 100000.0);
			this.double_14 = Helper.FmlaMultiplyDivide(base.double_6, this.double_13, 100000.0);
			this.double_15 = Helper.FmlaMultiplyDivide(base.double_6, this.double_12, 100000.0);
			this.double_16 = Helper.FmlaAddDivide(this.double_14, this.double_15, 4.0);
			this.double_17 = Helper.FmlaAddSubtract(base.wd2, 0.0, this.double_16);
			this.double_18 = Helper.FmlaMultiplyDivide(this.double_17, 2.0, 1.0);
			this.double_19 = Helper.FmlaMultiplyDivide(this.double_18, this.double_18, 1.0);
			this.double_20 = Helper.FmlaMultiplyDivide(this.double_14, this.double_14, 1.0);
			this.double_21 = Helper.FmlaAddSubtract(this.double_19, 0.0, this.double_20);
			this.double_22 = Helper.FmlaSquareRoot(this.double_21);
			this.double_23 = Helper.FmlaMultiplyDivide(this.double_22, base.double_1, this.double_18);
			this.double_24 = Helper.FmlaMultiplyDivide(100000.0, this.double_23, base.double_6);
			this.double_25 = Helper.FmlaPinTo(0.0, base.adj3, this.double_24);
			this.double_26 = Helper.FmlaMultiplyDivide(base.double_6, base.adj3, 100000.0);
			this.double_27 = Helper.FmlaAddSubtract(this.double_17, this.double_14, 0.0);
			this.double_28 = Helper.FmlaMultiplyDivide(base.double_1, base.double_1, 1.0);
			this.double_29 = Helper.FmlaMultiplyDivide(this.double_26, this.double_26, 1.0);
			this.double_30 = Helper.FmlaAddSubtract(this.double_28, 0.0, this.double_29);
			this.double_31 = Helper.FmlaSquareRoot(this.double_30);
			this.double_32 = Helper.FmlaMultiplyDivide(this.double_31, this.double_17, base.double_1);
			this.double_33 = Helper.FmlaAddSubtract(this.double_17, this.double_32, 0.0);
			this.double_34 = Helper.FmlaAddSubtract(this.double_27, this.double_32, 0.0);
			this.double_35 = Helper.FmlaAddSubtract(this.double_15, 0.0, this.double_14);
			this.double_36 = Helper.FmlaMultiplyDivide(this.double_35, 1.0, 2.0);
			this.double_37 = Helper.FmlaAddSubtract(this.double_33, 0.0, this.double_36);
			this.double_38 = Helper.FmlaAddSubtract(this.double_34, this.double_36, 0.0);
			this.double_39 = Helper.FmlaMultiplyDivide(this.double_15, 1.0, 2.0);
			this.double_40 = Helper.FmlaAddSubtract(base.double_5, 0.0, this.double_39);
			this.double_41 = Helper.FmlaAddSubtract(base.t, this.double_26, 0.0);
			this.double_42 = Helper.FmlaArcTan(this.double_26, this.double_32);
			this.double_43 = Helper.FmlaAddSubtract(0.0, 0.0, this.double_42);
			this.double_44 = Helper.FmlaAddSubtract(base.t, this.double_23, 0.0);
			this.double_45 = Helper.FmlaAddDivide(this.double_17, this.double_27, 2.0);
			this.double_46 = Helper.FmlaMultiplyDivide(this.double_14, 1.0, 2.0);
			this.double_47 = Helper.FmlaArcTan(this.double_23, this.double_46);
			this.double_48 = Helper.FmlaAddSubtract(this.double_47, 0.0, this.double_42);
			this.double_49 = Helper.FmlaAddSubtract(0.0, 0.0, this.double_48);
			this.double_50 = Helper.FmlaAddSubtract(base.cd4, 0.0, this.double_42);
			this.double_51 = Helper.FmlaAddSubtract(this.double_42, this.double_47, 0.0);
			this.double_52 = Helper.FmlaAddSubtract(base.cd4, 0.0, this.double_47);
			if (base.shape.Class174_0.Class172_0.Count == 0)
			{
				double num = ((base.shape.Class174_0.Dictionary_0 == null || !base.shape.Class174_0.Dictionary_0.ContainsKey("adj1")) ? 25000.0 : base.adj1);
				AdjustObject adjustObject = new Class170(new Class177(this.double_34 / 12700.0, this.double_41 / 12700.0, bool_1: false), "Adj1", 0.0, this.double_12, num, base.shape, bool_0: false);
				adjustObject.DefaultValue = 25000.0;
				base.shape.Class174_0.Class172_0.method_0(adjustObject);
				num = ((base.shape.Class174_0.Dictionary_0 == null || !base.shape.Class174_0.Dictionary_0.ContainsKey("adj2")) ? 50000.0 : base.adj2);
				adjustObject = new Class170(new Class177(this.double_37 / 12700.0, base.t / 12700.0, bool_1: false), "Adj2", 0.0, this.double_11, num, base.shape, bool_0: true);
				adjustObject.DefaultValue = 50000.0;
				base.shape.Class174_0.Class172_0.method_0(adjustObject);
				num = ((base.shape.Class174_0.Dictionary_0 == null || !base.shape.Class174_0.Dictionary_0.ContainsKey("adj3")) ? 25000.0 : base.adj3);
				adjustObject = new Class171(new Class177(base.double_5 / 12700.0, this.double_41 / 12700.0, bool_1: false), "Adj3", 0.0, this.double_24, num, base.shape, bool_0: false);
				adjustObject.DefaultValue = 25000.0;
				base.shape.Class174_0.Class172_0.method_0(adjustObject);
			}
			else
			{
				base.shape.Class174_0.Class172_0[0].AdjustRectangle.Class178_0.Class177_1 = new Class177(this.double_34 / 12700.0, this.double_41 / 12700.0, bool_1: false);
				base.shape.Class174_0.Class172_0[1].AdjustRectangle.Class178_0.Class177_1 = new Class177(this.double_37 / 12700.0, base.t / 12700.0, bool_1: false);
				base.shape.Class174_0.Class172_0[2].AdjustRectangle.Class178_0.Class177_1 = new Class177(base.double_5 / 12700.0, this.double_41 / 12700.0, bool_1: false);
			}
			base.shape.Class174_0.Dictionary_0 = null;
			Class175[] array = new Class175[3];
			GraphicsPath graphicsPath = DrawHelper.PathBegin();
			Class175 @class = new Class175(bool_1: false, Enum32.const_5);
			Class177 class2 = DrawHelper.MoveTo(this.double_40, base.t);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_38, this.double_41);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_34, this.double_41);
			class2 = DrawHelper.ArcTo(graphicsPath, this.double_17, base.double_1, this.double_50, this.double_51, class2);
			class2 = DrawHelper.ArcTo(graphicsPath, this.double_17, base.double_1, this.double_52, this.double_48, class2);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_37, this.double_41);
			DrawHelper.Close(graphicsPath);
			@class.List_0.Add(graphicsPath);
			array[0] = @class;
			graphicsPath = DrawHelper.PathBegin();
			@class = new Class175(bool_1: false, Enum32.const_1);
			class2 = DrawHelper.MoveTo(this.double_17, base.double_0);
			class2 = DrawHelper.ArcTo(graphicsPath, this.double_17, base.double_1, base.cd4, base.cd4, class2);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_14, base.t);
			class2 = DrawHelper.ArcTo(graphicsPath, this.double_17, base.double_1, base.cd2, -5400000.0, class2);
			DrawHelper.Close(graphicsPath);
			@class.List_0.Add(graphicsPath);
			array[1] = @class;
			graphicsPath = DrawHelper.PathBegin();
			@class = new Class175(bool_1: true, Enum32.const_4);
			class2 = DrawHelper.MoveTo(this.double_45, this.double_44);
			class2 = DrawHelper.ArcTo(graphicsPath, this.double_17, base.double_1, this.double_52, this.double_48, class2);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_37, this.double_41);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_40, base.t);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_38, this.double_41);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_34, this.double_41);
			class2 = DrawHelper.ArcTo(graphicsPath, this.double_17, base.double_1, this.double_50, this.double_42, class2);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_17, base.double_0);
			class2 = DrawHelper.ArcTo(graphicsPath, this.double_17, base.double_1, base.cd4, base.cd4, class2);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_14, base.t);
			class2 = DrawHelper.ArcTo(graphicsPath, this.double_17, base.double_1, base.cd2, -5400000.0, class2);
			@class.List_0.Add(graphicsPath);
			array[2] = @class;
			base.shape.Class183_0.Class175_0 = array;
		}
	}
}
