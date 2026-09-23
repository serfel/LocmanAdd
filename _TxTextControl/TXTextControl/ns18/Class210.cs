using System.Drawing.Drawing2D;
using ns17;
using TXTextControl.Drawing;

namespace ns18
{
	internal class Class210 : ShapeObject
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

		private double double_66;

		private double double_67;

		private double double_68;

		private double double_69;

		private double double_70;

		private double double_71;

		private double double_72;

		private double double_73;

		private double double_74;

		private double double_75;

		private double double_76;

		private double double_77;

		private double double_78;

		private double double_79;

		private double double_80;

		private double double_81;

		public Class210(Shape shape_0)
		{
			base.shape = shape_0;
			base.shape.Class174_0.Class172_0.Clear();
			base.adj1 = Helper.FmlaLiteralValue(10800000.0);
			base.adj2 = Helper.FmlaLiteralValue(0.0);
			base.adj3 = Helper.FmlaLiteralValue(25000.0);
			base.SetLoadedAvLstValues(base.shape);
		}

		internal override void CreateGraphicsPaths()
		{
			base.CreateBaseVariables(base.shape);
			this.double_11 = Helper.FmlaPinTo(0.0, base.adj1, 21599999.0);
			this.double_12 = Helper.FmlaPinTo(0.0, base.adj2, 21599999.0);
			this.double_13 = Helper.FmlaPinTo(0.0, base.adj3, 50000.0);
			this.double_14 = Helper.FmlaAddSubtract(this.double_12, 0.0, this.double_11);
			this.double_15 = Helper.FmlaAddSubtract(this.double_14, 21600000.0, 0.0);
			this.double_16 = Helper.FmlaIfElse(this.double_14, this.double_14, this.double_15);
			this.double_17 = Helper.FmlaAddSubtract(0.0, 0.0, this.double_16);
			this.double_18 = Helper.FmlaSine(base.wd2, this.double_11);
			this.double_19 = Helper.FmlaCosine(base.hd2, this.double_11);
			this.double_20 = Helper.FmlaSine(base.wd2, this.double_12);
			this.double_21 = Helper.FmlaCosine(base.hd2, this.double_12);
			this.double_22 = Helper.FmlaCosineArcTan(base.wd2, this.double_19, this.double_18);
			this.double_23 = Helper.FmlaSineArcTan(base.hd2, this.double_19, this.double_18);
			this.double_24 = Helper.FmlaCosineArcTan(base.wd2, this.double_21, this.double_20);
			this.double_25 = Helper.FmlaSineArcTan(base.hd2, this.double_21, this.double_20);
			this.double_26 = Helper.FmlaAddSubtract(base.double_2, this.double_22, 0.0);
			this.double_27 = Helper.FmlaAddSubtract(base.double_7, this.double_23, 0.0);
			this.double_28 = Helper.FmlaAddSubtract(base.double_2, this.double_24, 0.0);
			this.double_29 = Helper.FmlaAddSubtract(base.double_7, this.double_25, 0.0);
			this.double_30 = Helper.FmlaMultiplyDivide(base.double_6, this.double_13, 100000.0);
			this.double_31 = Helper.FmlaAddSubtract(base.wd2, 0.0, this.double_30);
			this.double_32 = Helper.FmlaAddSubtract(base.hd2, 0.0, this.double_30);
			this.double_33 = Helper.FmlaSine(this.double_31, this.double_12);
			this.double_34 = Helper.FmlaCosine(this.double_32, this.double_12);
			this.double_35 = Helper.FmlaSine(this.double_31, this.double_11);
			this.double_36 = Helper.FmlaCosine(this.double_32, this.double_11);
			this.double_37 = Helper.FmlaCosineArcTan(this.double_31, this.double_34, this.double_33);
			this.double_38 = Helper.FmlaSineArcTan(this.double_32, this.double_34, this.double_33);
			this.double_39 = Helper.FmlaCosineArcTan(this.double_31, this.double_36, this.double_35);
			this.double_40 = Helper.FmlaSineArcTan(this.double_32, this.double_36, this.double_35);
			this.double_41 = Helper.FmlaAddSubtract(base.double_2, this.double_37, 0.0);
			this.double_42 = Helper.FmlaAddSubtract(base.double_7, this.double_38, 0.0);
			this.double_43 = Helper.FmlaAddSubtract(base.double_2, this.double_39, 0.0);
			this.double_44 = Helper.FmlaAddSubtract(base.double_7, this.double_40, 0.0);
			this.double_45 = Helper.FmlaAddSubtract(21600000.0, 0.0, this.double_11);
			this.double_46 = Helper.FmlaAddSubtract(this.double_16, 0.0, this.double_45);
			this.double_47 = Helper.FmlaMaximumValue(this.double_26, this.double_41);
			this.double_48 = Helper.FmlaMaximumValue(this.double_28, this.double_43);
			this.double_49 = Helper.FmlaMaximumValue(this.double_47, this.double_48);
			this.double_50 = Helper.FmlaIfElse(this.double_46, base.double_5, this.double_49);
			this.double_51 = Helper.FmlaAddSubtract(base.cd4, 0.0, this.double_11);
			this.double_52 = Helper.FmlaAddSubtract(27000000.0, 0.0, this.double_11);
			this.double_53 = Helper.FmlaIfElse(this.double_51, this.double_51, this.double_52);
			this.double_54 = Helper.FmlaAddSubtract(this.double_16, 0.0, this.double_53);
			this.double_55 = Helper.FmlaMaximumValue(this.double_27, this.double_42);
			this.double_56 = Helper.FmlaMaximumValue(this.double_29, this.double_44);
			this.double_57 = Helper.FmlaMaximumValue(this.double_55, this.double_56);
			this.double_58 = Helper.FmlaIfElse(this.double_54, base.double_0, this.double_57);
			this.double_59 = Helper.FmlaAddSubtract(base.cd2, 0.0, this.double_11);
			this.double_60 = Helper.FmlaAddSubtract(32400000.0, 0.0, this.double_11);
			this.double_61 = Helper.FmlaIfElse(this.double_59, this.double_59, this.double_60);
			this.double_62 = Helper.FmlaAddSubtract(this.double_16, 0.0, this.double_61);
			this.double_63 = Helper.FmlaMinimumValue(this.double_26, this.double_41);
			this.double_64 = Helper.FmlaMinimumValue(this.double_28, this.double_43);
			this.double_65 = Helper.FmlaMinimumValue(this.double_63, this.double_64);
			this.double_66 = Helper.FmlaIfElse(this.double_62, base.double_3, this.double_65);
			this.double_67 = Helper.FmlaAddSubtract(base._3cd4, 0.0, this.double_11);
			this.double_68 = Helper.FmlaAddSubtract(37800000.0, 0.0, this.double_11);
			this.double_69 = Helper.FmlaIfElse(this.double_67, this.double_67, this.double_68);
			this.double_70 = Helper.FmlaAddSubtract(this.double_16, 0.0, this.double_69);
			this.double_71 = Helper.FmlaMinimumValue(this.double_27, this.double_42);
			this.double_72 = Helper.FmlaMinimumValue(this.double_29, this.double_44);
			this.double_73 = Helper.FmlaMinimumValue(this.double_71, this.double_72);
			this.double_74 = Helper.FmlaIfElse(this.double_70, base.t, this.double_73);
			this.double_75 = Helper.FmlaAddDivide(this.double_26, this.double_43, 2.0);
			this.double_76 = Helper.FmlaAddDivide(this.double_27, this.double_44, 2.0);
			this.double_77 = Helper.FmlaAddDivide(this.double_28, this.double_41, 2.0);
			this.double_78 = Helper.FmlaAddDivide(this.double_29, this.double_42, 2.0);
			this.double_79 = Helper.FmlaAddSubtract(this.double_11, 0.0, base.cd4);
			this.double_80 = Helper.FmlaAddSubtract(this.double_12, base.cd4, 0.0);
			this.double_81 = Helper.FmlaAddDivide(this.double_79, this.double_80, 2.0);
			if (base.shape.Class174_0.Class172_0.Count == 0)
			{
				double num = ((base.shape.Class174_0.Dictionary_0 == null || !base.shape.Class174_0.Dictionary_0.ContainsKey("adj1")) ? 10800000.0 : base.adj1);
				AdjustObject adjustObject = new Class168(new Class177(this.double_26 / 12700.0, this.double_27 / 12700.0, bool_1: false), "Adj1", 0.0, 21599999.0, num, base.shape, bool_0: false);
				adjustObject.DefaultValue = 10800000.0;
				base.shape.Class174_0.Class172_0.method_0(adjustObject);
				num = ((base.shape.Class174_0.Dictionary_0 == null || !base.shape.Class174_0.Dictionary_0.ContainsKey("adj3")) ? 25000.0 : base.adj3);
				adjustObject = new Class169(new Class177(this.double_41 / 12700.0, this.double_42 / 12700.0, bool_1: false), "Adj3", 0.0, 50000.0, num, base.shape, bool_0: true);
				adjustObject.DefaultValue = 25000.0;
				base.shape.Class174_0.Class172_0.method_0(adjustObject);
				num = ((base.shape.Class174_0.Dictionary_0 == null || !base.shape.Class174_0.Dictionary_0.ContainsKey("adj2")) ? 0.0 : base.adj2);
				adjustObject = new Class168(new Class177(this.double_41 / 12700.0, this.double_42 / 12700.0, bool_1: false), "Adj2", 0.0, 21599999.0, num, base.shape, bool_0: false);
				adjustObject.DefaultValue = 0.0;
				base.shape.Class174_0.Class172_0.method_0(adjustObject);
			}
			else
			{
				base.shape.Class174_0.Class172_0[0].AdjustRectangle.Class178_0.Class177_1 = new Class177(this.double_26 / 12700.0, this.double_27 / 12700.0, bool_1: false);
				base.shape.Class174_0.Class172_0[1].AdjustRectangle.Class178_0.Class177_1 = new Class177(this.double_41 / 12700.0, this.double_42 / 12700.0, bool_1: false);
				base.shape.Class174_0.Class172_0[2].AdjustRectangle.Class178_0.Class177_1 = new Class177(this.double_41 / 12700.0, this.double_42 / 12700.0, bool_1: false);
			}
			base.shape.Class174_0.Dictionary_0 = null;
			Class175[] array = new Class175[1];
			GraphicsPath graphicsPath = DrawHelper.PathBegin();
			Class175 @class = new Class175(bool_1: true, Enum32.const_5);
			Class177 currentPathEndLocation = DrawHelper.MoveTo(this.double_26, this.double_27);
			currentPathEndLocation = DrawHelper.ArcTo(graphicsPath, base.wd2, base.hd2, this.double_11, this.double_16, currentPathEndLocation);
			currentPathEndLocation = DrawHelper.LnTo(graphicsPath, currentPathEndLocation.Double_2, currentPathEndLocation.Double_3, this.double_41, this.double_42);
			currentPathEndLocation = DrawHelper.ArcTo(graphicsPath, this.double_31, this.double_32, this.double_12, this.double_17, currentPathEndLocation);
			DrawHelper.Close(graphicsPath);
			@class.List_0.Add(graphicsPath);
			array[0] = @class;
			base.shape.Class183_0.Class175_0 = array;
		}
	}
}
