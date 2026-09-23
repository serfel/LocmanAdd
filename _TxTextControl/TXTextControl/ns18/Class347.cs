using System.Drawing.Drawing2D;
using ns17;
using TXTextControl.Drawing;

namespace ns18
{
	internal class Class347 : ShapeObject
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

		private double double_82;

		private double double_83;

		private double double_84;

		private double double_85;

		private double double_86;

		public Class347(Shape shape_0)
		{
			base.shape = shape_0;
			base.shape.Class174_0.Class172_0.Clear();
			base.adj = Helper.FmlaLiteralValue(37500.0);
			base.SetLoadedAvLstValues(base.shape);
		}

		internal override void CreateGraphicsPaths()
		{
			base.CreateBaseVariables(base.shape);
			this.double_11 = Helper.FmlaPinTo(0.0, base.adj, 50000.0);
			this.double_12 = Helper.FmlaCosine(base.wd2, 900000.0);
			this.double_13 = Helper.FmlaCosine(base.wd2, 1800000.0);
			this.double_14 = Helper.FmlaCosine(base.wd2, 2700000.0);
			this.double_15 = Helper.FmlaLiteralValue(base.wd4);
			this.double_16 = Helper.FmlaCosine(base.wd2, 4500000.0);
			this.double_17 = Helper.FmlaSine(base.hd2, 4500000.0);
			this.double_18 = Helper.FmlaSine(base.hd2, 3600000.0);
			this.double_19 = Helper.FmlaSine(base.hd2, 2700000.0);
			this.double_20 = Helper.FmlaLiteralValue(base.hd4);
			this.double_21 = Helper.FmlaSine(base.hd2, 900000.0);
			this.double_22 = Helper.FmlaAddSubtract(base.double_2, 0.0, this.double_12);
			this.double_23 = Helper.FmlaAddSubtract(base.double_2, 0.0, this.double_13);
			this.double_24 = Helper.FmlaAddSubtract(base.double_2, 0.0, this.double_14);
			this.double_25 = Helper.FmlaAddSubtract(base.double_2, 0.0, this.double_15);
			this.double_26 = Helper.FmlaAddSubtract(base.double_2, 0.0, this.double_16);
			this.double_27 = Helper.FmlaAddSubtract(base.double_2, this.double_16, 0.0);
			this.double_28 = Helper.FmlaAddSubtract(base.double_2, this.double_15, 0.0);
			this.double_29 = Helper.FmlaAddSubtract(base.double_2, this.double_14, 0.0);
			this.double_30 = Helper.FmlaAddSubtract(base.double_2, this.double_13, 0.0);
			this.double_31 = Helper.FmlaAddSubtract(base.double_2, this.double_12, 0.0);
			this.double_32 = Helper.FmlaAddSubtract(base.double_7, 0.0, this.double_17);
			this.double_33 = Helper.FmlaAddSubtract(base.double_7, 0.0, this.double_18);
			this.double_34 = Helper.FmlaAddSubtract(base.double_7, 0.0, this.double_19);
			this.double_35 = Helper.FmlaAddSubtract(base.double_7, 0.0, this.double_20);
			this.double_36 = Helper.FmlaAddSubtract(base.double_7, 0.0, this.double_21);
			this.double_37 = Helper.FmlaAddSubtract(base.double_7, this.double_21, 0.0);
			this.double_38 = Helper.FmlaAddSubtract(base.double_7, this.double_20, 0.0);
			this.double_39 = Helper.FmlaAddSubtract(base.double_7, this.double_19, 0.0);
			this.double_40 = Helper.FmlaAddSubtract(base.double_7, this.double_18, 0.0);
			this.double_41 = Helper.FmlaAddSubtract(base.double_7, this.double_17, 0.0);
			this.double_42 = Helper.FmlaMultiplyDivide(base.wd2, this.double_11, 50000.0);
			this.double_43 = Helper.FmlaMultiplyDivide(base.hd2, this.double_11, 50000.0);
			this.double_44 = Helper.FmlaMultiplyDivide(this.double_42, 99144.0, 100000.0);
			this.double_45 = Helper.FmlaMultiplyDivide(this.double_42, 92388.0, 100000.0);
			this.double_46 = Helper.FmlaMultiplyDivide(this.double_42, 79335.0, 100000.0);
			this.double_47 = Helper.FmlaMultiplyDivide(this.double_42, 60876.0, 100000.0);
			this.double_48 = Helper.FmlaMultiplyDivide(this.double_42, 38268.0, 100000.0);
			this.double_49 = Helper.FmlaMultiplyDivide(this.double_42, 13053.0, 100000.0);
			this.double_50 = Helper.FmlaMultiplyDivide(this.double_43, 99144.0, 100000.0);
			this.double_51 = Helper.FmlaMultiplyDivide(this.double_43, 92388.0, 100000.0);
			this.double_52 = Helper.FmlaMultiplyDivide(this.double_43, 79335.0, 100000.0);
			this.double_53 = Helper.FmlaMultiplyDivide(this.double_43, 60876.0, 100000.0);
			this.double_54 = Helper.FmlaMultiplyDivide(this.double_43, 38268.0, 100000.0);
			this.double_55 = Helper.FmlaMultiplyDivide(this.double_43, 13053.0, 100000.0);
			this.double_56 = Helper.FmlaAddSubtract(base.double_2, 0.0, this.double_44);
			this.double_57 = Helper.FmlaAddSubtract(base.double_2, 0.0, this.double_45);
			this.double_58 = Helper.FmlaAddSubtract(base.double_2, 0.0, this.double_46);
			this.double_59 = Helper.FmlaAddSubtract(base.double_2, 0.0, this.double_47);
			this.double_60 = Helper.FmlaAddSubtract(base.double_2, 0.0, this.double_48);
			this.double_61 = Helper.FmlaAddSubtract(base.double_2, 0.0, this.double_49);
			this.double_62 = Helper.FmlaAddSubtract(base.double_2, this.double_49, 0.0);
			this.double_63 = Helper.FmlaAddSubtract(base.double_2, this.double_48, 0.0);
			this.double_64 = Helper.FmlaAddSubtract(base.double_2, this.double_47, 0.0);
			this.double_65 = Helper.FmlaAddSubtract(base.double_2, this.double_46, 0.0);
			this.double_66 = Helper.FmlaAddSubtract(base.double_2, this.double_45, 0.0);
			this.double_67 = Helper.FmlaAddSubtract(base.double_2, this.double_44, 0.0);
			this.double_68 = Helper.FmlaAddSubtract(base.double_7, 0.0, this.double_50);
			this.double_69 = Helper.FmlaAddSubtract(base.double_7, 0.0, this.double_51);
			this.double_70 = Helper.FmlaAddSubtract(base.double_7, 0.0, this.double_52);
			this.double_71 = Helper.FmlaAddSubtract(base.double_7, 0.0, this.double_53);
			this.double_72 = Helper.FmlaAddSubtract(base.double_7, 0.0, this.double_54);
			this.double_73 = Helper.FmlaAddSubtract(base.double_7, 0.0, this.double_55);
			this.double_74 = Helper.FmlaAddSubtract(base.double_7, this.double_55, 0.0);
			this.double_75 = Helper.FmlaAddSubtract(base.double_7, this.double_54, 0.0);
			this.double_76 = Helper.FmlaAddSubtract(base.double_7, this.double_53, 0.0);
			this.double_77 = Helper.FmlaAddSubtract(base.double_7, this.double_52, 0.0);
			this.double_78 = Helper.FmlaAddSubtract(base.double_7, this.double_51, 0.0);
			this.double_79 = Helper.FmlaAddSubtract(base.double_7, this.double_50, 0.0);
			this.double_80 = Helper.FmlaCosine(this.double_42, 2700000.0);
			this.double_81 = Helper.FmlaSine(this.double_43, 2700000.0);
			this.double_82 = Helper.FmlaAddSubtract(base.double_2, 0.0, this.double_80);
			this.double_83 = Helper.FmlaAddSubtract(base.double_7, 0.0, this.double_81);
			this.double_84 = Helper.FmlaAddSubtract(base.double_2, this.double_80, 0.0);
			this.double_85 = Helper.FmlaAddSubtract(base.double_7, this.double_81, 0.0);
			this.double_86 = Helper.FmlaAddSubtract(base.double_7, 0.0, this.double_43);
			if (base.shape.Class174_0.Class172_0.Count == 0)
			{
				double num = ((base.shape.Class174_0.Dictionary_0 == null || !base.shape.Class174_0.Dictionary_0.ContainsKey("adj")) ? 37500.0 : base.adj);
				AdjustObject adjustObject = new Class171(new Class177(base.double_2 / 12700.0, this.double_86 / 12700.0, bool_1: false), "Adj", 0.0, 50000.0, num, base.shape, bool_0: true);
				adjustObject.DefaultValue = 37500.0;
				base.shape.Class174_0.Class172_0.method_0(adjustObject);
			}
			else
			{
				base.shape.Class174_0.Class172_0[0].AdjustRectangle.Class178_0.Class177_1 = new Class177(base.double_2 / 12700.0, this.double_86 / 12700.0, bool_1: false);
			}
			base.shape.Class174_0.Dictionary_0 = null;
			Class175[] array = new Class175[1];
			GraphicsPath graphicsPath = DrawHelper.PathBegin();
			Class175 @class = new Class175(bool_1: true, Enum32.const_5);
			Class177 class2 = DrawHelper.MoveTo(base.double_3, base.double_7);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_56, this.double_73);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_22, this.double_36);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_57, this.double_72);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_23, this.double_35);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_58, this.double_71);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_24, this.double_34);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_59, this.double_70);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_25, this.double_33);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_60, this.double_69);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_26, this.double_32);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_61, this.double_68);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, base.double_2, base.t);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_62, this.double_68);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_27, this.double_32);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_63, this.double_69);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_28, this.double_33);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_64, this.double_70);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_29, this.double_34);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_65, this.double_71);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_30, this.double_35);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_66, this.double_72);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_31, this.double_36);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_67, this.double_73);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, base.double_5, base.double_7);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_67, this.double_74);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_31, this.double_37);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_66, this.double_75);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_30, this.double_38);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_65, this.double_76);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_29, this.double_39);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_64, this.double_77);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_28, this.double_40);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_63, this.double_78);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_27, this.double_41);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_62, this.double_79);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, base.double_2, base.double_0);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_61, this.double_79);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_26, this.double_41);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_60, this.double_78);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_25, this.double_40);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_59, this.double_77);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_24, this.double_39);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_58, this.double_76);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_23, this.double_38);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_57, this.double_75);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_22, this.double_37);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_56, this.double_74);
			DrawHelper.Close(graphicsPath);
			@class.List_0.Add(graphicsPath);
			array[0] = @class;
			base.shape.Class183_0.Class175_0 = array;
		}
	}
}
