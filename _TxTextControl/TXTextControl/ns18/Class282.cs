using System.Drawing.Drawing2D;
using ns17;
using TXTextControl.Drawing;

namespace ns18
{
	internal class Class282 : ShapeObject
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

		private double double_87;

		private double double_88;

		private double double_89;

		private double double_90;

		private double double_91;

		private double double_92;

		private double double_93;

		private double double_94;

		private double double_95;

		private double double_96;

		private double double_97;

		private double double_98;

		private double double_99;

		private double double_100;

		private double double_101;

		private double double_102;

		private double double_103;

		private double double_104;

		private double double_105;

		private double double_106;

		private double double_107;

		private double double_108;

		private double double_109;

		private double double_110;

		private double double_111;

		private double double_112;

		private double double_113;

		private double double_114;

		private double double_115;

		private double double_116;

		public Class282(Shape shape_0)
		{
			base.shape = shape_0;
			base.shape.Class174_0.Class172_0.Clear();
			base.adj1 = Helper.FmlaLiteralValue(15000.0);
			base.adj2 = Helper.FmlaLiteralValue(3526.0);
			base.SetLoadedAvLstValues(base.shape);
		}

		internal override void CreateGraphicsPaths()
		{
			base.CreateBaseVariables(base.shape);
			this.double_11 = Helper.FmlaPinTo(0.0, base.adj1, 20000.0);
			this.double_12 = Helper.FmlaPinTo(0.0, base.adj2, 5358.0);
			this.double_13 = Helper.FmlaMultiplyDivide(base.double_6, this.double_11, 100000.0);
			this.double_14 = Helper.FmlaMultiplyDivide(base.double_6, this.double_12, 100000.0);
			this.double_15 = Helper.FmlaMultiplyDivide(this.double_13, 1.0, 2.0);
			this.double_16 = Helper.FmlaMultiplyDivide(this.double_14, 1.0, 2.0);
			this.double_17 = Helper.FmlaAddSubtract(this.double_15, this.double_16, 0.0);
			this.double_18 = Helper.FmlaAddSubtract(base.hd2, 0.0, this.double_13);
			this.double_19 = Helper.FmlaAddSubtract(base.wd2, 0.0, this.double_13);
			this.double_20 = Helper.FmlaAddSubtract(this.double_19, 0.0, this.double_18);
			this.double_21 = Helper.FmlaIfElse(this.double_20, this.double_18, this.double_19);
			this.double_22 = Helper.FmlaArcTan(this.double_21, this.double_17);
			this.double_23 = Helper.FmlaAddSubtract(19800000.0, 0.0, this.double_22);
			this.double_24 = Helper.FmlaAddSubtract(19800000.0, this.double_22, 0.0);
			this.double_25 = Helper.FmlaCosine(this.double_19, this.double_23);
			this.double_26 = Helper.FmlaSine(this.double_18, this.double_23);
			this.double_27 = Helper.FmlaArcTan(this.double_25, this.double_26);
			this.double_28 = Helper.FmlaCosine(this.double_18, this.double_27);
			this.double_29 = Helper.FmlaSine(this.double_19, this.double_27);
			this.double_30 = Helper.FmlaModulo(this.double_28, this.double_29, 0.0);
			this.double_31 = Helper.FmlaMultiplyDivide(this.double_19, this.double_18, this.double_30);
			this.double_32 = Helper.FmlaCosine(this.double_31, this.double_27);
			this.double_33 = Helper.FmlaSine(this.double_31, this.double_27);
			this.double_34 = Helper.FmlaAddSubtract(base.double_2, this.double_32, 0.0);
			this.double_35 = Helper.FmlaAddSubtract(base.double_7, this.double_33, 0.0);
			this.double_36 = Helper.FmlaCosine(this.double_19, this.double_24);
			this.double_37 = Helper.FmlaSine(this.double_18, this.double_24);
			this.double_38 = Helper.FmlaArcTan(this.double_36, this.double_37);
			this.double_39 = Helper.FmlaCosine(this.double_18, this.double_38);
			this.double_40 = Helper.FmlaSine(this.double_19, this.double_38);
			this.double_41 = Helper.FmlaModulo(this.double_39, this.double_40, 0.0);
			this.double_42 = Helper.FmlaMultiplyDivide(this.double_19, this.double_18, this.double_41);
			this.double_43 = Helper.FmlaCosine(this.double_42, this.double_38);
			this.double_44 = Helper.FmlaSine(this.double_42, this.double_38);
			this.double_45 = Helper.FmlaAddSubtract(base.double_2, this.double_43, 0.0);
			this.double_46 = Helper.FmlaAddSubtract(base.double_7, this.double_44, 0.0);
			this.double_47 = Helper.FmlaAddSubtract(this.double_34, 0.0, this.double_45);
			this.double_48 = Helper.FmlaAddSubtract(this.double_35, 0.0, this.double_46);
			this.double_49 = Helper.FmlaModulo(this.double_47, this.double_48, 0.0);
			this.double_11 = Helper.FmlaArcTan(this.double_48, this.double_47);
			this.double_50 = Helper.FmlaSine(this.double_14, this.double_11);
			this.double_51 = Helper.FmlaCosine(this.double_14, this.double_11);
			this.double_52 = Helper.FmlaAddSubtract(this.double_45, this.double_50, 0.0);
			this.double_53 = Helper.FmlaAddSubtract(this.double_46, this.double_51, 0.0);
			this.double_54 = Helper.FmlaAddSubtract(this.double_34, 0.0, this.double_50);
			this.double_55 = Helper.FmlaAddSubtract(this.double_35, 0.0, this.double_51);
			this.double_56 = Helper.FmlaSine(this.double_13, this.double_11);
			this.double_57 = Helper.FmlaCosine(this.double_13, this.double_11);
			this.double_58 = Helper.FmlaAddSubtract(this.double_53, this.double_56, 0.0);
			this.double_59 = Helper.FmlaAddSubtract(this.double_52, 0.0, this.double_57);
			this.double_60 = Helper.FmlaAddSubtract(this.double_55, this.double_56, 0.0);
			this.double_61 = Helper.FmlaAddSubtract(this.double_54, 0.0, this.double_57);
			this.double_62 = Helper.FmlaAddSubtract(base._3cd4, this.double_22, 0.0);
			this.double_63 = Helper.FmlaCosine(this.double_19, this.double_62);
			this.double_64 = Helper.FmlaSine(this.double_18, this.double_62);
			this.double_65 = Helper.FmlaArcTan(this.double_63, this.double_64);
			this.double_66 = Helper.FmlaCosine(this.double_18, this.double_65);
			this.double_67 = Helper.FmlaSine(this.double_19, this.double_65);
			this.double_68 = Helper.FmlaModulo(this.double_66, this.double_67, 0.0);
			this.double_69 = Helper.FmlaMultiplyDivide(this.double_19, this.double_18, this.double_68);
			this.double_70 = Helper.FmlaCosine(this.double_69, this.double_65);
			this.double_71 = Helper.FmlaSine(this.double_69, this.double_65);
			this.double_72 = Helper.FmlaAddSubtract(base.double_2, this.double_70, 0.0);
			this.double_73 = Helper.FmlaAddSubtract(base.double_7, this.double_71, 0.0);
			this.double_74 = Helper.FmlaAddSubtract(base.double_2, 0.0, this.double_70);
			this.double_75 = Helper.FmlaAddSubtract(this.double_72, 0.0, this.double_14);
			this.double_76 = Helper.FmlaAddSubtract(this.double_74, this.double_14, 0.0);
			this.double_77 = Helper.FmlaAddSubtract(this.double_73, 0.0, this.double_13);
			this.double_78 = Helper.FmlaAddSubtract(this.double_27, 0.0, this.double_65);
			this.double_79 = Helper.FmlaAddSubtract(1800000.0, 0.0, this.double_22);
			this.double_80 = Helper.FmlaAddSubtract(1800000.0, this.double_22, 0.0);
			this.double_81 = Helper.FmlaCosine(this.double_19, this.double_79);
			this.double_82 = Helper.FmlaSine(this.double_18, this.double_79);
			this.double_83 = Helper.FmlaArcTan(this.double_81, this.double_82);
			this.double_84 = Helper.FmlaAddSubtract(base.double_1, 0.0, this.double_46);
			this.double_85 = Helper.FmlaCosine(this.double_19, this.double_80);
			this.double_86 = Helper.FmlaSine(this.double_18, this.double_80);
			this.double_87 = Helper.FmlaArcTan(this.double_85, this.double_86);
			this.double_88 = Helper.FmlaAddSubtract(base.double_1, 0.0, this.double_35);
			this.double_89 = Helper.FmlaAddSubtract(base.double_1, 0.0, this.double_60);
			this.double_90 = Helper.FmlaAddSubtract(base.double_1, 0.0, this.double_58);
			this.double_91 = Helper.FmlaLiteralValue(this.double_59);
			this.double_92 = Helper.FmlaAddSubtract(this.double_83, 0.0, this.double_38);
			this.double_93 = Helper.FmlaAddSubtract(base.cd4, this.double_22, 0.0);
			this.double_94 = Helper.FmlaCosine(this.double_19, this.double_93);
			this.double_95 = Helper.FmlaSine(this.double_18, this.double_93);
			this.double_96 = Helper.FmlaArcTan(this.double_94, this.double_95);
			this.double_97 = Helper.FmlaAddSubtract(base.double_1, 0.0, this.double_73);
			this.double_98 = Helper.FmlaAddSubtract(base.double_1, 0.0, this.double_77);
			this.double_99 = Helper.FmlaAddSubtract(9000000.0, this.double_22, 0.0);
			this.double_100 = Helper.FmlaCosine(this.double_19, this.double_99);
			this.double_101 = Helper.FmlaSine(this.double_18, this.double_99);
			this.double_102 = Helper.FmlaArcTan(this.double_100, this.double_101);
			this.double_103 = Helper.FmlaAddSubtract(base.double_8, 0.0, this.double_45);
			this.double_104 = Helper.FmlaAddSubtract(base.double_8, 0.0, this.double_59);
			this.double_105 = Helper.FmlaAddSubtract(base.double_8, 0.0, this.double_61);
			this.double_106 = Helper.FmlaAddSubtract(12600000.0, this.double_22, 0.0);
			this.double_107 = Helper.FmlaCosine(this.double_19, this.double_106);
			this.double_108 = Helper.FmlaSine(this.double_18, this.double_106);
			this.double_109 = Helper.FmlaArcTan(this.double_107, this.double_108);
			this.double_110 = Helper.FmlaAddSubtract(base.double_8, 0.0, this.double_34);
			this.double_111 = Helper.FmlaAddSubtract(base.double_8, 0.0, this.double_61);
			this.double_112 = Helper.FmlaAddSubtract(base.double_8, 0.0, this.double_59);
			this.double_113 = Helper.FmlaAddDivide(this.double_61, this.double_59, 2.0);
			this.double_114 = Helper.FmlaAddDivide(this.double_60, this.double_58, 2.0);
			this.double_115 = Helper.FmlaAddSubtract(base.double_0, 0.0, this.double_114);
			this.double_116 = Helper.FmlaAddDivide(base.double_5, 0.0, this.double_113);
			if (base.shape.Class174_0.Class172_0.Count == 0)
			{
				double num = ((base.shape.Class174_0.Dictionary_0 == null || !base.shape.Class174_0.Dictionary_0.ContainsKey("adj1")) ? 15000.0 : base.adj1);
				AdjustObject adjustObject = new Class171(new Class177(this.double_72 / 12700.0, this.double_73 / 12700.0, bool_1: false), "Adj1", 0.0, 20000.0, num, base.shape, bool_0: false);
				adjustObject.DefaultValue = 15000.0;
				base.shape.Class174_0.Class172_0.method_0(adjustObject);
				num = ((base.shape.Class174_0.Dictionary_0 == null || !base.shape.Class174_0.Dictionary_0.ContainsKey("adj2")) ? 3526.0 : base.adj2);
				adjustObject = new Class170(new Class177(this.double_74 / 12700.0, this.double_73 / 12700.0, bool_1: false), "Adj2", 0.0, 5358.0, num, base.shape, bool_0: true);
				adjustObject.DefaultValue = 3526.0;
				base.shape.Class174_0.Class172_0.method_0(adjustObject);
			}
			else
			{
				base.shape.Class174_0.Class172_0[0].AdjustRectangle.Class178_0.Class177_1 = new Class177(this.double_72 / 12700.0, this.double_73 / 12700.0, bool_1: false);
				base.shape.Class174_0.Class172_0[1].AdjustRectangle.Class178_0.Class177_1 = new Class177(this.double_74 / 12700.0, this.double_73 / 12700.0, bool_1: false);
			}
			base.shape.Class174_0.Dictionary_0 = null;
			Class175[] array = new Class175[1];
			GraphicsPath graphicsPath = DrawHelper.PathBegin();
			Class175 @class = new Class175(bool_1: true, Enum32.const_5);
			Class177 class2 = DrawHelper.MoveTo(this.double_34, this.double_35);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_61, this.double_60);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_59, this.double_58);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_45, this.double_46);
			class2 = DrawHelper.ArcTo(graphicsPath, this.double_19, this.double_18, this.double_38, this.double_92, class2);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_59, this.double_90);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_61, this.double_89);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_34, this.double_88);
			class2 = DrawHelper.ArcTo(graphicsPath, this.double_19, this.double_18, this.double_87, this.double_78, class2);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_75, this.double_98);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_76, this.double_98);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_74, this.double_97);
			class2 = DrawHelper.ArcTo(graphicsPath, this.double_19, this.double_18, this.double_96, this.double_78, class2);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_105, this.double_89);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_104, this.double_90);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_103, this.double_84);
			class2 = DrawHelper.ArcTo(graphicsPath, this.double_19, this.double_18, this.double_102, this.double_92, class2);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_112, this.double_58);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_111, this.double_60);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_110, this.double_35);
			class2 = DrawHelper.ArcTo(graphicsPath, this.double_19, this.double_18, this.double_109, this.double_78, class2);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_76, this.double_77);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_75, this.double_77);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_72, this.double_73);
			class2 = DrawHelper.ArcTo(graphicsPath, this.double_19, this.double_18, this.double_65, this.double_78, class2);
			DrawHelper.Close(graphicsPath);
			@class.List_0.Add(graphicsPath);
			array[0] = @class;
			base.shape.Class183_0.Class175_0 = array;
		}
	}
}
