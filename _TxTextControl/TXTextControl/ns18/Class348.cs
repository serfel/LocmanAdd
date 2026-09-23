using System.Drawing.Drawing2D;
using ns17;
using TXTextControl.Drawing;

namespace ns18
{
	internal class Class348 : ShapeObject
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

		public Class348(Shape shape_0)
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
			this.double_12 = Helper.FmlaMultiplyDivide(base.wd2, 98079.0, 100000.0);
			this.double_13 = Helper.FmlaMultiplyDivide(base.wd2, 92388.0, 100000.0);
			this.double_14 = Helper.FmlaMultiplyDivide(base.wd2, 83147.0, 100000.0);
			this.double_15 = Helper.FmlaCosine(base.wd2, 2700000.0);
			this.double_16 = Helper.FmlaMultiplyDivide(base.wd2, 55557.0, 100000.0);
			this.double_17 = Helper.FmlaMultiplyDivide(base.wd2, 38268.0, 100000.0);
			this.double_18 = Helper.FmlaMultiplyDivide(base.wd2, 19509.0, 100000.0);
			this.double_19 = Helper.FmlaMultiplyDivide(base.hd2, 98079.0, 100000.0);
			this.double_20 = Helper.FmlaMultiplyDivide(base.hd2, 92388.0, 100000.0);
			this.double_21 = Helper.FmlaMultiplyDivide(base.hd2, 83147.0, 100000.0);
			this.double_22 = Helper.FmlaSine(base.hd2, 2700000.0);
			this.double_23 = Helper.FmlaMultiplyDivide(base.hd2, 55557.0, 100000.0);
			this.double_24 = Helper.FmlaMultiplyDivide(base.hd2, 38268.0, 100000.0);
			this.double_25 = Helper.FmlaMultiplyDivide(base.hd2, 19509.0, 100000.0);
			this.double_26 = Helper.FmlaAddSubtract(base.double_2, 0.0, this.double_12);
			this.double_27 = Helper.FmlaAddSubtract(base.double_2, 0.0, this.double_13);
			this.double_28 = Helper.FmlaAddSubtract(base.double_2, 0.0, this.double_14);
			this.double_29 = Helper.FmlaAddSubtract(base.double_2, 0.0, this.double_15);
			this.double_30 = Helper.FmlaAddSubtract(base.double_2, 0.0, this.double_16);
			this.double_31 = Helper.FmlaAddSubtract(base.double_2, 0.0, this.double_17);
			this.double_32 = Helper.FmlaAddSubtract(base.double_2, 0.0, this.double_18);
			this.double_33 = Helper.FmlaAddSubtract(base.double_2, this.double_18, 0.0);
			this.double_34 = Helper.FmlaAddSubtract(base.double_2, this.double_17, 0.0);
			this.double_35 = Helper.FmlaAddSubtract(base.double_2, this.double_16, 0.0);
			this.double_36 = Helper.FmlaAddSubtract(base.double_2, this.double_15, 0.0);
			this.double_37 = Helper.FmlaAddSubtract(base.double_2, this.double_14, 0.0);
			this.double_38 = Helper.FmlaAddSubtract(base.double_2, this.double_13, 0.0);
			this.double_39 = Helper.FmlaAddSubtract(base.double_2, this.double_12, 0.0);
			this.double_40 = Helper.FmlaAddSubtract(base.double_7, 0.0, this.double_19);
			this.double_41 = Helper.FmlaAddSubtract(base.double_7, 0.0, this.double_20);
			this.double_42 = Helper.FmlaAddSubtract(base.double_7, 0.0, this.double_21);
			this.double_43 = Helper.FmlaAddSubtract(base.double_7, 0.0, this.double_22);
			this.double_44 = Helper.FmlaAddSubtract(base.double_7, 0.0, this.double_23);
			this.double_45 = Helper.FmlaAddSubtract(base.double_7, 0.0, this.double_24);
			this.double_46 = Helper.FmlaAddSubtract(base.double_7, 0.0, this.double_25);
			this.double_47 = Helper.FmlaAddSubtract(base.double_7, this.double_25, 0.0);
			this.double_48 = Helper.FmlaAddSubtract(base.double_7, this.double_24, 0.0);
			this.double_49 = Helper.FmlaAddSubtract(base.double_7, this.double_23, 0.0);
			this.double_50 = Helper.FmlaAddSubtract(base.double_7, this.double_22, 0.0);
			this.double_51 = Helper.FmlaAddSubtract(base.double_7, this.double_21, 0.0);
			this.double_52 = Helper.FmlaAddSubtract(base.double_7, this.double_20, 0.0);
			this.double_53 = Helper.FmlaAddSubtract(base.double_7, this.double_19, 0.0);
			this.double_54 = Helper.FmlaMultiplyDivide(base.wd2, this.double_11, 50000.0);
			this.double_55 = Helper.FmlaMultiplyDivide(base.hd2, this.double_11, 50000.0);
			this.double_56 = Helper.FmlaMultiplyDivide(this.double_54, 99518.0, 100000.0);
			this.double_57 = Helper.FmlaMultiplyDivide(this.double_54, 95694.0, 100000.0);
			this.double_58 = Helper.FmlaMultiplyDivide(this.double_54, 88192.0, 100000.0);
			this.double_59 = Helper.FmlaMultiplyDivide(this.double_54, 77301.0, 100000.0);
			this.double_60 = Helper.FmlaMultiplyDivide(this.double_54, 63439.0, 100000.0);
			this.double_61 = Helper.FmlaMultiplyDivide(this.double_54, 47140.0, 100000.0);
			this.double_62 = Helper.FmlaMultiplyDivide(this.double_54, 29028.0, 100000.0);
			this.double_63 = Helper.FmlaMultiplyDivide(this.double_54, 9802.0, 100000.0);
			this.double_64 = Helper.FmlaMultiplyDivide(this.double_55, 99518.0, 100000.0);
			this.double_65 = Helper.FmlaMultiplyDivide(this.double_55, 95694.0, 100000.0);
			this.double_66 = Helper.FmlaMultiplyDivide(this.double_55, 88192.0, 100000.0);
			this.double_67 = Helper.FmlaMultiplyDivide(this.double_55, 77301.0, 100000.0);
			this.double_68 = Helper.FmlaMultiplyDivide(this.double_55, 63439.0, 100000.0);
			this.double_69 = Helper.FmlaMultiplyDivide(this.double_55, 47140.0, 100000.0);
			this.double_70 = Helper.FmlaMultiplyDivide(this.double_55, 29028.0, 100000.0);
			this.double_71 = Helper.FmlaMultiplyDivide(this.double_55, 9802.0, 100000.0);
			this.double_72 = Helper.FmlaAddSubtract(base.double_2, 0.0, this.double_56);
			this.double_73 = Helper.FmlaAddSubtract(base.double_2, 0.0, this.double_57);
			this.double_74 = Helper.FmlaAddSubtract(base.double_2, 0.0, this.double_58);
			this.double_75 = Helper.FmlaAddSubtract(base.double_2, 0.0, this.double_59);
			this.double_76 = Helper.FmlaAddSubtract(base.double_2, 0.0, this.double_60);
			this.double_77 = Helper.FmlaAddSubtract(base.double_2, 0.0, this.double_61);
			this.double_78 = Helper.FmlaAddSubtract(base.double_2, 0.0, this.double_62);
			this.double_79 = Helper.FmlaAddSubtract(base.double_2, 0.0, this.double_63);
			this.double_80 = Helper.FmlaAddSubtract(base.double_2, this.double_63, 0.0);
			this.double_81 = Helper.FmlaAddSubtract(base.double_2, this.double_62, 0.0);
			this.double_82 = Helper.FmlaAddSubtract(base.double_2, this.double_61, 0.0);
			this.double_83 = Helper.FmlaAddSubtract(base.double_2, this.double_60, 0.0);
			this.double_84 = Helper.FmlaAddSubtract(base.double_2, this.double_59, 0.0);
			this.double_85 = Helper.FmlaAddSubtract(base.double_2, this.double_58, 0.0);
			this.double_86 = Helper.FmlaAddSubtract(base.double_2, this.double_57, 0.0);
			this.double_87 = Helper.FmlaAddSubtract(base.double_2, this.double_56, 0.0);
			this.double_88 = Helper.FmlaAddSubtract(base.double_7, 0.0, this.double_64);
			this.double_89 = Helper.FmlaAddSubtract(base.double_7, 0.0, this.double_65);
			this.double_90 = Helper.FmlaAddSubtract(base.double_7, 0.0, this.double_66);
			this.double_91 = Helper.FmlaAddSubtract(base.double_7, 0.0, this.double_67);
			this.double_92 = Helper.FmlaAddSubtract(base.double_7, 0.0, this.double_68);
			this.double_93 = Helper.FmlaAddSubtract(base.double_7, 0.0, this.double_69);
			this.double_94 = Helper.FmlaAddSubtract(base.double_7, 0.0, this.double_70);
			this.double_95 = Helper.FmlaAddSubtract(base.double_7, 0.0, this.double_71);
			this.double_96 = Helper.FmlaAddSubtract(base.double_7, this.double_71, 0.0);
			this.double_97 = Helper.FmlaAddSubtract(base.double_7, this.double_70, 0.0);
			this.double_98 = Helper.FmlaAddSubtract(base.double_7, this.double_69, 0.0);
			this.double_99 = Helper.FmlaAddSubtract(base.double_7, this.double_68, 0.0);
			this.double_100 = Helper.FmlaAddSubtract(base.double_7, this.double_67, 0.0);
			this.double_101 = Helper.FmlaAddSubtract(base.double_7, this.double_66, 0.0);
			this.double_102 = Helper.FmlaAddSubtract(base.double_7, this.double_65, 0.0);
			this.double_103 = Helper.FmlaAddSubtract(base.double_7, this.double_64, 0.0);
			this.double_104 = Helper.FmlaCosine(this.double_54, 2700000.0);
			this.double_105 = Helper.FmlaSine(this.double_55, 2700000.0);
			this.double_106 = Helper.FmlaAddSubtract(base.double_2, 0.0, this.double_104);
			this.double_107 = Helper.FmlaAddSubtract(base.double_7, 0.0, this.double_105);
			this.double_108 = Helper.FmlaAddSubtract(base.double_2, this.double_104, 0.0);
			this.double_109 = Helper.FmlaAddSubtract(base.double_7, this.double_105, 0.0);
			this.double_110 = Helper.FmlaAddSubtract(base.double_7, 0.0, this.double_55);
			if (base.shape.Class174_0.Class172_0.Count == 0)
			{
				double num = ((base.shape.Class174_0.Dictionary_0 == null || !base.shape.Class174_0.Dictionary_0.ContainsKey("adj")) ? 37500.0 : base.adj);
				AdjustObject adjustObject = new Class171(new Class177(base.double_2 / 12700.0, this.double_110 / 12700.0, bool_1: false), "Adj", 0.0, 50000.0, num, base.shape, bool_0: true);
				adjustObject.DefaultValue = 37500.0;
				base.shape.Class174_0.Class172_0.method_0(adjustObject);
			}
			else
			{
				base.shape.Class174_0.Class172_0[0].AdjustRectangle.Class178_0.Class177_1 = new Class177(base.double_2 / 12700.0, this.double_110 / 12700.0, bool_1: false);
			}
			base.shape.Class174_0.Dictionary_0 = null;
			Class175[] array = new Class175[1];
			GraphicsPath graphicsPath = DrawHelper.PathBegin();
			Class175 @class = new Class175(bool_1: true, Enum32.const_5);
			Class177 class2 = DrawHelper.MoveTo(base.double_3, base.double_7);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_72, this.double_95);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_26, this.double_46);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_73, this.double_94);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_27, this.double_45);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_74, this.double_93);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_28, this.double_44);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_75, this.double_92);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_29, this.double_43);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_76, this.double_91);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_30, this.double_42);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_77, this.double_90);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_31, this.double_41);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_78, this.double_89);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_32, this.double_40);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_79, this.double_88);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, base.double_2, base.t);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_80, this.double_88);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_33, this.double_40);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_81, this.double_89);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_34, this.double_41);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_82, this.double_90);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_35, this.double_42);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_83, this.double_91);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_36, this.double_43);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_84, this.double_92);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_37, this.double_44);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_85, this.double_93);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_38, this.double_45);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_86, this.double_94);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_39, this.double_46);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_87, this.double_95);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, base.double_5, base.double_7);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_87, this.double_96);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_39, this.double_47);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_86, this.double_97);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_38, this.double_48);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_85, this.double_98);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_37, this.double_49);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_84, this.double_99);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_36, this.double_50);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_83, this.double_100);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_35, this.double_51);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_82, this.double_101);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_34, this.double_52);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_81, this.double_102);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_33, this.double_53);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_80, this.double_103);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, base.double_2, base.double_0);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_79, this.double_103);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_32, this.double_53);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_78, this.double_102);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_31, this.double_52);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_77, this.double_101);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_30, this.double_51);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_76, this.double_100);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_29, this.double_50);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_75, this.double_99);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_28, this.double_49);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_74, this.double_98);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_27, this.double_48);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_73, this.double_97);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_26, this.double_47);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_72, this.double_96);
			DrawHelper.Close(graphicsPath);
			@class.List_0.Add(graphicsPath);
			array[0] = @class;
			base.shape.Class183_0.Class175_0 = array;
		}
	}
}
