using System.Drawing.Drawing2D;
using ns17;
using TXTextControl.Drawing;

namespace ns18
{
	internal class Class310 : ShapeObject
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

		private double double_53;

		private double double_54;

		private double double_55;

		private double double_56;

		private double double_57;

		private double double_58;

		private double double_59;

		private double double_60;

		private double double_61;

		private double double_62;

		private double double_63;

		private double double_64;

		private double double_65;

		public Class310(Shape shape_0)
		{
			base.shape = shape_0;
			base.shape.Class174_0.Class172_0.Clear();
			base.adj1 = Helper.FmlaLiteralValue(23520.0);
			base.adj2 = Helper.FmlaLiteralValue(6600000.0);
			base.adj3 = Helper.FmlaLiteralValue(11760.0);
			base.SetLoadedAvLstValues(base.shape);
		}

		internal override void CreateGraphicsPaths()
		{
			base.CreateBaseVariables(base.shape);
			this.double_11 = Helper.FmlaPinTo(0.0, base.adj1, 50000.0);
			this.double_12 = Helper.FmlaPinTo(4200000.0, base.adj2, 6600000.0);
			this.double_13 = Helper.FmlaMultiplyDivide(this.double_11, 2.0, 1.0);
			this.double_14 = Helper.FmlaAddSubtract(100000.0, 0.0, this.double_13);
			this.double_15 = Helper.FmlaPinTo(0.0, base.adj3, this.double_14);
			this.double_16 = Helper.FmlaMultiplyDivide(base.double_1, this.double_11, 100000.0);
			this.double_17 = Helper.FmlaMultiplyDivide(base.double_1, this.double_15, 200000.0);
			this.double_18 = Helper.FmlaMultiplyDivide(base.double_8, 73490.0, 200000.0);
			this.double_19 = Helper.FmlaAddSubtract(base.double_2, 0.0, this.double_18);
			this.double_20 = Helper.FmlaAddSubtract(base.double_2, this.double_18, 0.0);
			this.double_21 = Helper.FmlaAddSubtract(base.double_7, 0.0, this.double_17);
			this.double_22 = Helper.FmlaAddSubtract(base.double_7, this.double_17, 0.0);
			this.double_23 = Helper.FmlaAddSubtract(this.double_21, 0.0, this.double_16);
			this.double_24 = Helper.FmlaAddSubtract(this.double_22, this.double_16, 0.0);
			this.double_25 = Helper.FmlaAddSubtract(this.double_12, 0.0, base.cd4);
			this.double_26 = Helper.FmlaTangent(base.hd2, this.double_25);
			this.double_27 = Helper.FmlaModulo(this.double_26, base.hd2, 0.0);
			this.double_28 = Helper.FmlaMultiplyDivide(this.double_27, this.double_16, base.hd2);
			this.double_29 = Helper.FmlaMultiplyDivide(this.double_28, 1.0, 2.0);
			this.double_30 = Helper.FmlaAddSubtract(base.double_2, this.double_26, this.double_29);
			this.double_31 = Helper.FmlaMultiplyDivide(this.double_26, this.double_23, base.hd2);
			this.double_32 = Helper.FmlaAddSubtract(this.double_30, 0.0, this.double_31);
			this.double_33 = Helper.FmlaMultiplyDivide(this.double_26, this.double_21, base.hd2);
			this.double_34 = Helper.FmlaAddSubtract(this.double_30, 0.0, this.double_33);
			this.double_35 = Helper.FmlaMultiplyDivide(this.double_26, this.double_22, base.hd2);
			this.double_36 = Helper.FmlaAddSubtract(this.double_30, 0.0, this.double_35);
			this.double_37 = Helper.FmlaMultiplyDivide(this.double_26, this.double_24, base.hd2);
			this.double_38 = Helper.FmlaAddSubtract(this.double_30, 0.0, this.double_37);
			this.double_39 = Helper.FmlaMultiplyDivide(this.double_26, 2.0, 1.0);
			this.double_40 = Helper.FmlaAddSubtract(this.double_30, 0.0, this.double_39);
			this.double_41 = Helper.FmlaAddSubtract(this.double_30, this.double_28, 0.0);
			this.double_42 = Helper.FmlaAddSubtract(this.double_32, this.double_28, 0.0);
			this.double_43 = Helper.FmlaAddSubtract(this.double_34, this.double_28, 0.0);
			this.double_44 = Helper.FmlaAddSubtract(this.double_36, this.double_28, 0.0);
			this.double_45 = Helper.FmlaAddSubtract(this.double_38, this.double_28, 0.0);
			this.double_46 = Helper.FmlaAddSubtract(this.double_40, this.double_28, 0.0);
			this.double_47 = Helper.FmlaMultiplyDivide(this.double_16, base.hd2, this.double_27);
			this.double_48 = Helper.FmlaAddSubtract(this.double_30, this.double_47, 0.0);
			this.double_49 = Helper.FmlaAddSubtract(this.double_41, 0.0, this.double_47);
			this.double_50 = Helper.FmlaIfElse(this.double_25, this.double_48, this.double_41);
			this.double_51 = Helper.FmlaIfElse(this.double_25, this.double_30, this.double_49);
			this.double_52 = Helper.FmlaMultiplyDivide(this.double_16, this.double_26, this.double_27);
			this.double_53 = Helper.FmlaAddSubtract(0.0, 0.0, this.double_52);
			this.double_54 = Helper.FmlaIfElse(this.double_25, this.double_52, base.t);
			this.double_55 = Helper.FmlaIfElse(this.double_25, base.t, this.double_53);
			this.double_56 = Helper.FmlaAddSubtract(base.double_8, 0.0, this.double_50);
			this.double_57 = Helper.FmlaAddSubtract(base.double_8, 0.0, this.double_51);
			this.double_58 = Helper.FmlaAddSubtract(base.double_1, 0.0, this.double_54);
			this.double_59 = Helper.FmlaAddSubtract(base.double_1, 0.0, this.double_55);
			this.double_60 = Helper.FmlaAddDivide(this.double_50, this.double_51, 2.0);
			this.double_61 = Helper.FmlaAddDivide(this.double_57, this.double_56, 2.0);
			this.double_62 = Helper.FmlaAddDivide(this.double_54, this.double_55, 2.0);
			this.double_63 = Helper.FmlaAddDivide(this.double_23, this.double_21, 2.0);
			this.double_64 = Helper.FmlaAddDivide(this.double_22, this.double_24, 2.0);
			this.double_65 = Helper.FmlaAddDivide(this.double_59, this.double_58, 2.0);
			if (base.shape.Class174_0.Class172_0.Count == 0)
			{
				double num = ((base.shape.Class174_0.Dictionary_0 == null || !base.shape.Class174_0.Dictionary_0.ContainsKey("adj1")) ? 23520.0 : base.adj1);
				AdjustObject adjustObject = new Class171(new Class177(base.double_3 / 12700.0, this.double_23 / 12700.0, bool_1: false), "Adj1", 0.0, 50000.0, num, base.shape, bool_0: true);
				adjustObject.DefaultValue = 23520.0;
				base.shape.Class174_0.Class172_0.method_0(adjustObject);
				num = ((base.shape.Class174_0.Dictionary_0 == null || !base.shape.Class174_0.Dictionary_0.ContainsKey("adj2")) ? 6600000.0 : base.adj2);
				adjustObject = new Class168(new Class177(this.double_51 / 12700.0, base.t / 12700.0, bool_1: false), "Adj2", 4200000.0, 6600000.0, num, base.shape, bool_0: true);
				adjustObject.DefaultValue = 6600000.0;
				base.shape.Class174_0.Class172_0.method_0(adjustObject);
				num = ((base.shape.Class174_0.Dictionary_0 == null || !base.shape.Class174_0.Dictionary_0.ContainsKey("adj3")) ? 11760.0 : base.adj3);
				adjustObject = new Class171(new Class177(base.double_5 / 12700.0, this.double_21 / 12700.0, bool_1: false), "Adj3", 0.0, this.double_14, num, base.shape, bool_0: true);
				adjustObject.DefaultValue = 11760.0;
				base.shape.Class174_0.Class172_0.method_0(adjustObject);
			}
			else
			{
				base.shape.Class174_0.Class172_0[0].AdjustRectangle.Class178_0.Class177_1 = new Class177(base.double_3 / 12700.0, this.double_23 / 12700.0, bool_1: false);
				base.shape.Class174_0.Class172_0[1].AdjustRectangle.Class178_0.Class177_1 = new Class177(this.double_51 / 12700.0, base.t / 12700.0, bool_1: false);
				base.shape.Class174_0.Class172_0[2].AdjustRectangle.Class178_0.Class177_1 = new Class177(base.double_5 / 12700.0, this.double_21 / 12700.0, bool_1: false);
			}
			base.shape.Class174_0.Dictionary_0 = null;
			Class175[] array = new Class175[1];
			GraphicsPath graphicsPath = DrawHelper.PathBegin();
			Class175 @class = new Class175(bool_1: true, Enum32.const_5);
			Class177 class2 = DrawHelper.MoveTo(this.double_19, this.double_23);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_32, this.double_23);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_51, this.double_55);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_50, this.double_54);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_42, this.double_23);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_20, this.double_23);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_20, this.double_21);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_43, this.double_21);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_44, this.double_22);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_20, this.double_22);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_20, this.double_24);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_45, this.double_24);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_57, this.double_59);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_56, this.double_58);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_38, this.double_24);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_19, this.double_24);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_19, this.double_22);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_36, this.double_22);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_34, this.double_21);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_19, this.double_21);
			DrawHelper.Close(graphicsPath);
			@class.List_0.Add(graphicsPath);
			array[0] = @class;
			base.shape.Class183_0.Class175_0 = array;
		}
	}
}
