using System.Drawing.Drawing2D;
using ns17;
using TXTextControl.Drawing;

namespace ns18
{
	internal class Class225 : ShapeObject
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

		private double double_117;

		private double double_118;

		private double double_119;

		private double double_120;

		private double double_121;

		private double double_122;

		private double double_123;

		private double double_124;

		private double double_125;

		private double double_126;

		private double double_127;

		private double double_128;

		private double double_129;

		private double double_130;

		private double double_131;

		private double double_132;

		private double double_133;

		private double double_134;

		private double double_135;

		private double double_136;

		private double double_137;

		private double double_138;

		private double double_139;

		private double double_140;

		private double double_141;

		private double double_142;

		private double double_143;

		private double double_144;

		private double double_145;

		private double double_146;

		private double double_147;

		private double double_148;

		private double double_149;

		private double double_150;

		private double double_151;

		private double double_152;

		private double double_153;

		private double double_154;

		private double double_155;

		private double double_156;

		private double double_157;

		private double double_158;

		private double double_159;

		private double double_160;

		private double double_161;

		private double double_162;

		private double double_163;

		private double double_164;

		private double double_165;

		private double double_166;

		private double double_167;

		private double double_168;

		private double double_169;

		private double double_170;

		private double double_171;

		private double double_172;

		private double double_173;

		private double double_174;

		private double double_175;

		private double double_176;

		private double double_177;

		private double double_178;

		private double double_179;

		private double double_180;

		private double double_181;

		private double double_182;

		private double double_183;

		private double double_184;

		private double double_185;

		private double double_186;

		private double double_187;

		private double double_188;

		private double double_189;

		private double double_190;

		private double double_191;

		private double double_192;

		private double double_193;

		private double double_194;

		private double double_195;

		private double double_196;

		private double double_197;

		private double double_198;

		private double double_199;

		private double double_200;

		public Class225(Shape shape_0)
		{
			base.shape = shape_0;
			base.shape.Class174_0.Class172_0.Clear();
			base.adj1 = Helper.FmlaLiteralValue(12500.0);
			base.adj2 = Helper.FmlaLiteralValue(1142319.0);
			base.adj3 = Helper.FmlaLiteralValue(20457681.0);
			base.adj4 = Helper.FmlaLiteralValue(10800000.0);
			base.adj5 = Helper.FmlaLiteralValue(12500.0);
			base.SetLoadedAvLstValues(base.shape);
		}

		internal override void CreateGraphicsPaths()
		{
			base.CreateBaseVariables(base.shape);
			this.double_11 = Helper.FmlaPinTo(0.0, base.adj5, 25000.0);
			this.double_12 = Helper.FmlaMultiplyDivide(this.double_11, 2.0, 1.0);
			this.double_13 = Helper.FmlaPinTo(0.0, base.adj1, this.double_12);
			this.double_14 = Helper.FmlaPinTo(1.0, base.adj3, 21599999.0);
			this.double_15 = Helper.FmlaPinTo(0.0, base.adj4, 21599999.0);
			this.double_16 = Helper.FmlaMultiplyDivide(base.double_6, this.double_13, 100000.0);
			this.double_17 = Helper.FmlaMultiplyDivide(base.double_6, this.double_11, 100000.0);
			this.double_18 = Helper.FmlaMultiplyDivide(this.double_16, 1.0, 2.0);
			this.double_19 = Helper.FmlaAddSubtract(base.wd2, this.double_18, this.double_17);
			this.double_20 = Helper.FmlaAddSubtract(base.hd2, this.double_18, this.double_17);
			this.double_21 = Helper.FmlaAddSubtract(this.double_19, 0.0, this.double_16);
			this.double_22 = Helper.FmlaAddSubtract(this.double_20, 0.0, this.double_16);
			this.double_23 = Helper.FmlaAddSubtract(this.double_21, this.double_18, 0.0);
			this.double_24 = Helper.FmlaAddSubtract(this.double_22, this.double_18, 0.0);
			this.double_25 = Helper.FmlaSine(this.double_23, this.double_14);
			this.double_26 = Helper.FmlaCosine(this.double_24, this.double_14);
			this.double_27 = Helper.FmlaCosineArcTan(this.double_23, this.double_26, this.double_25);
			this.double_28 = Helper.FmlaSineArcTan(this.double_24, this.double_26, this.double_25);
			this.double_29 = Helper.FmlaAddSubtract(base.double_2, this.double_27, 0.0);
			this.double_30 = Helper.FmlaAddSubtract(base.double_7, this.double_28, 0.0);
			this.double_31 = Helper.FmlaMinimumValue(this.double_21, this.double_22);
			this.double_32 = Helper.FmlaMultiplyDivide(this.double_27, this.double_27, 1.0);
			this.double_33 = Helper.FmlaMultiplyDivide(this.double_28, this.double_28, 1.0);
			this.double_34 = Helper.FmlaMultiplyDivide(this.double_31, this.double_31, 1.0);
			this.double_35 = Helper.FmlaAddSubtract(this.double_32, 0.0, this.double_34);
			this.double_36 = Helper.FmlaAddSubtract(this.double_33, 0.0, this.double_34);
			this.double_37 = Helper.FmlaMultiplyDivide(this.double_35, this.double_36, this.double_32);
			this.double_38 = Helper.FmlaMultiplyDivide(this.double_37, 1.0, this.double_33);
			this.double_39 = Helper.FmlaAddSubtract(1.0, 0.0, this.double_38);
			this.double_40 = Helper.FmlaSquareRoot(this.double_39);
			this.double_41 = Helper.FmlaMultiplyDivide(this.double_35, 1.0, this.double_27);
			this.double_42 = Helper.FmlaMultiplyDivide(this.double_41, 1.0, this.double_28);
			this.double_43 = Helper.FmlaAddDivide(1.0, this.double_40, this.double_42);
			this.double_44 = Helper.FmlaArcTan(1.0, this.double_43);
			this.double_45 = Helper.FmlaAddSubtract(this.double_44, 21600000.0, 0.0);
			this.double_46 = Helper.FmlaIfElse(this.double_44, this.double_44, this.double_45);
			this.double_47 = Helper.FmlaAddSubtract(this.double_46, 0.0, this.double_14);
			this.double_48 = Helper.FmlaAddSubtract(this.double_47, 21600000.0, 0.0);
			this.double_49 = Helper.FmlaIfElse(this.double_47, this.double_47, this.double_48);
			this.double_50 = Helper.FmlaAddSubtract(this.double_49, 0.0, base.cd2);
			this.double_51 = Helper.FmlaAddSubtract(this.double_49, 0.0, 21600000.0);
			this.double_52 = Helper.FmlaIfElse(this.double_50, this.double_51, this.double_49);
			this.double_53 = Helper.FmlaAbsoluteValue(this.double_52);
			this.double_54 = Helper.FmlaPinTo(0.0, base.adj2, this.double_53);
			this.double_55 = Helper.FmlaAddSubtract(this.double_14, this.double_54, 0.0);
			this.double_56 = Helper.FmlaSine(this.double_23, this.double_55);
			this.double_57 = Helper.FmlaCosine(this.double_24, this.double_55);
			this.double_58 = Helper.FmlaCosineArcTan(this.double_23, this.double_57, this.double_56);
			this.double_59 = Helper.FmlaSineArcTan(this.double_24, this.double_57, this.double_56);
			this.double_60 = Helper.FmlaAddSubtract(base.double_2, this.double_58, 0.0);
			this.double_61 = Helper.FmlaAddSubtract(base.double_7, this.double_59, 0.0);
			this.double_62 = Helper.FmlaSine(this.double_19, this.double_15);
			this.double_63 = Helper.FmlaCosine(this.double_20, this.double_15);
			this.double_64 = Helper.FmlaCosineArcTan(this.double_19, this.double_63, this.double_62);
			this.double_65 = Helper.FmlaSineArcTan(this.double_20, this.double_63, this.double_62);
			this.double_66 = Helper.FmlaAddSubtract(base.double_2, this.double_64, 0.0);
			this.double_67 = Helper.FmlaAddSubtract(base.double_7, this.double_65, 0.0);
			this.double_68 = Helper.FmlaCosine(this.double_17, this.double_55);
			this.double_69 = Helper.FmlaSine(this.double_17, this.double_55);
			this.double_70 = Helper.FmlaAddSubtract(this.double_29, this.double_68, 0.0);
			this.double_71 = Helper.FmlaAddSubtract(this.double_30, this.double_69, 0.0);
			this.double_72 = Helper.FmlaCosine(this.double_17, this.double_55);
			this.double_73 = Helper.FmlaSine(this.double_17, this.double_55);
			this.double_74 = Helper.FmlaAddSubtract(this.double_29, 0.0, this.double_72);
			this.double_75 = Helper.FmlaAddSubtract(this.double_30, 0.0, this.double_73);
			this.double_76 = Helper.FmlaAddSubtract(this.double_74, 0.0, base.double_2);
			this.double_77 = Helper.FmlaAddSubtract(this.double_75, 0.0, base.double_7);
			this.double_78 = Helper.FmlaAddSubtract(this.double_70, 0.0, base.double_2);
			this.double_79 = Helper.FmlaAddSubtract(this.double_71, 0.0, base.double_7);
			this.double_80 = Helper.FmlaMinimumValue(this.double_19, this.double_20);
			this.double_81 = Helper.FmlaMultiplyDivide(this.double_76, this.double_80, this.double_19);
			this.double_82 = Helper.FmlaMultiplyDivide(this.double_77, this.double_80, this.double_20);
			this.double_83 = Helper.FmlaMultiplyDivide(this.double_78, this.double_80, this.double_19);
			this.double_84 = Helper.FmlaMultiplyDivide(this.double_79, this.double_80, this.double_20);
			this.double_85 = Helper.FmlaAddSubtract(this.double_83, 0.0, this.double_81);
			this.double_86 = Helper.FmlaAddSubtract(this.double_84, 0.0, this.double_82);
			this.double_87 = Helper.FmlaModulo(this.double_85, this.double_86, 0.0);
			this.double_88 = Helper.FmlaMultiplyDivide(this.double_81, this.double_84, 1.0);
			this.double_89 = Helper.FmlaMultiplyDivide(this.double_83, this.double_82, 1.0);
			this.double_90 = Helper.FmlaAddSubtract(this.double_88, 0.0, this.double_89);
			this.double_91 = Helper.FmlaMultiplyDivide(this.double_80, this.double_80, 1.0);
			this.double_92 = Helper.FmlaMultiplyDivide(this.double_87, this.double_87, 1.0);
			this.double_93 = Helper.FmlaMultiplyDivide(this.double_91, this.double_92, 1.0);
			this.double_94 = Helper.FmlaMultiplyDivide(this.double_90, this.double_90, 1.0);
			this.double_95 = Helper.FmlaAddSubtract(this.double_93, 0.0, this.double_94);
			this.double_96 = Helper.FmlaMaximumValue(this.double_95, 0.0);
			this.double_97 = Helper.FmlaSquareRoot(this.double_96);
			this.double_98 = Helper.FmlaMultiplyDivide(this.double_86, -1.0, 1.0);
			this.double_99 = Helper.FmlaIfElse(this.double_98, -1.0, 1.0);
			this.double_100 = Helper.FmlaMultiplyDivide(this.double_99, this.double_85, 1.0);
			this.double_101 = Helper.FmlaMultiplyDivide(this.double_100, this.double_97, 1.0);
			this.double_102 = Helper.FmlaMultiplyDivide(this.double_90, this.double_86, 1.0);
			this.double_103 = Helper.FmlaAddDivide(this.double_102, this.double_101, this.double_92);
			this.double_104 = Helper.FmlaAddSubtract(this.double_102, 0.0, this.double_101);
			this.double_105 = Helper.FmlaMultiplyDivide(this.double_104, 1.0, this.double_92);
			this.double_106 = Helper.FmlaAbsoluteValue(this.double_86);
			this.double_107 = Helper.FmlaMultiplyDivide(this.double_106, this.double_97, 1.0);
			this.double_108 = Helper.FmlaMultiplyDivide(this.double_90, this.double_85, -1.0);
			this.double_109 = Helper.FmlaAddDivide(this.double_108, this.double_107, this.double_92);
			this.double_110 = Helper.FmlaAddSubtract(this.double_108, 0.0, this.double_107);
			this.double_111 = Helper.FmlaMultiplyDivide(this.double_110, 1.0, this.double_92);
			this.double_112 = Helper.FmlaAddSubtract(this.double_83, 0.0, this.double_103);
			this.double_113 = Helper.FmlaAddSubtract(this.double_83, 0.0, this.double_105);
			this.double_114 = Helper.FmlaAddSubtract(this.double_84, 0.0, this.double_109);
			this.double_115 = Helper.FmlaAddSubtract(this.double_84, 0.0, this.double_111);
			this.double_116 = Helper.FmlaModulo(this.double_112, this.double_114, 0.0);
			this.double_117 = Helper.FmlaModulo(this.double_113, this.double_115, 0.0);
			this.double_118 = Helper.FmlaAddSubtract(this.double_117, 0.0, this.double_116);
			this.double_119 = Helper.FmlaIfElse(this.double_118, this.double_103, this.double_105);
			this.double_120 = Helper.FmlaIfElse(this.double_118, this.double_109, this.double_111);
			this.double_121 = Helper.FmlaMultiplyDivide(this.double_119, this.double_19, this.double_80);
			this.double_122 = Helper.FmlaMultiplyDivide(this.double_120, this.double_20, this.double_80);
			this.double_123 = Helper.FmlaAddSubtract(base.double_2, this.double_121, 0.0);
			this.double_124 = Helper.FmlaAddSubtract(base.double_7, this.double_122, 0.0);
			this.double_125 = Helper.FmlaMultiplyDivide(this.double_76, this.double_31, this.double_21);
			this.double_126 = Helper.FmlaMultiplyDivide(this.double_77, this.double_31, this.double_22);
			this.double_127 = Helper.FmlaMultiplyDivide(this.double_78, this.double_31, this.double_21);
			this.double_128 = Helper.FmlaMultiplyDivide(this.double_79, this.double_31, this.double_22);
			this.double_129 = Helper.FmlaAddSubtract(this.double_127, 0.0, this.double_125);
			this.double_130 = Helper.FmlaAddSubtract(this.double_128, 0.0, this.double_126);
			this.double_131 = Helper.FmlaModulo(this.double_129, this.double_130, 0.0);
			this.double_132 = Helper.FmlaMultiplyDivide(this.double_125, this.double_128, 1.0);
			this.double_133 = Helper.FmlaMultiplyDivide(this.double_127, this.double_126, 1.0);
			this.double_134 = Helper.FmlaAddSubtract(this.double_132, 0.0, this.double_133);
			this.double_135 = Helper.FmlaMultiplyDivide(this.double_31, this.double_31, 1.0);
			this.double_136 = Helper.FmlaMultiplyDivide(this.double_131, this.double_131, 1.0);
			this.double_137 = Helper.FmlaMultiplyDivide(this.double_135, this.double_136, 1.0);
			this.double_138 = Helper.FmlaMultiplyDivide(this.double_134, this.double_134, 1.0);
			this.double_139 = Helper.FmlaAddSubtract(this.double_137, 0.0, this.double_138);
			this.double_140 = Helper.FmlaMaximumValue(this.double_139, 0.0);
			this.double_141 = Helper.FmlaSquareRoot(this.double_140);
			this.double_142 = Helper.FmlaMultiplyDivide(this.double_99, this.double_129, 1.0);
			this.double_143 = Helper.FmlaMultiplyDivide(this.double_142, this.double_141, 1.0);
			this.double_144 = Helper.FmlaMultiplyDivide(this.double_134, this.double_130, 1.0);
			this.double_145 = Helper.FmlaAddDivide(this.double_144, this.double_143, this.double_136);
			this.double_146 = Helper.FmlaAddSubtract(this.double_144, 0.0, this.double_143);
			this.double_147 = Helper.FmlaMultiplyDivide(this.double_146, 1.0, this.double_136);
			this.double_148 = Helper.FmlaAbsoluteValue(this.double_130);
			this.double_149 = Helper.FmlaMultiplyDivide(this.double_148, this.double_141, 1.0);
			this.double_150 = Helper.FmlaMultiplyDivide(this.double_134, this.double_129, -1.0);
			this.double_151 = Helper.FmlaAddDivide(this.double_150, this.double_149, this.double_136);
			this.double_152 = Helper.FmlaAddSubtract(this.double_150, 0.0, this.double_149);
			this.double_153 = Helper.FmlaMultiplyDivide(this.double_152, 1.0, this.double_136);
			this.double_154 = Helper.FmlaAddSubtract(this.double_125, 0.0, this.double_145);
			this.double_155 = Helper.FmlaAddSubtract(this.double_125, 0.0, this.double_147);
			this.double_156 = Helper.FmlaAddSubtract(this.double_126, 0.0, this.double_151);
			this.double_157 = Helper.FmlaAddSubtract(this.double_126, 0.0, this.double_153);
			this.double_158 = Helper.FmlaModulo(this.double_154, this.double_156, 0.0);
			this.double_159 = Helper.FmlaModulo(this.double_155, this.double_157, 0.0);
			this.double_160 = Helper.FmlaAddSubtract(this.double_159, 0.0, this.double_158);
			this.double_161 = Helper.FmlaIfElse(this.double_160, this.double_145, this.double_147);
			this.double_162 = Helper.FmlaIfElse(this.double_160, this.double_151, this.double_153);
			this.double_163 = Helper.FmlaMultiplyDivide(this.double_161, this.double_21, this.double_31);
			this.double_164 = Helper.FmlaMultiplyDivide(this.double_162, this.double_22, this.double_31);
			this.double_165 = Helper.FmlaAddSubtract(base.double_2, this.double_163, 0.0);
			this.double_166 = Helper.FmlaAddSubtract(base.double_7, this.double_164, 0.0);
			this.double_167 = Helper.FmlaArcTan(this.double_163, this.double_164);
			this.double_168 = Helper.FmlaAddSubtract(this.double_167, 21600000.0, 0.0);
			this.double_169 = Helper.FmlaIfElse(this.double_167, this.double_167, this.double_168);
			this.double_170 = Helper.FmlaAddSubtract(this.double_15, 0.0, this.double_169);
			this.double_171 = Helper.FmlaAddSubtract(this.double_170, 0.0, 21600000.0);
			this.double_172 = Helper.FmlaIfElse(this.double_170, this.double_171, this.double_170);
			this.double_173 = Helper.FmlaAddSubtract(this.double_123, 0.0, this.double_165);
			this.double_174 = Helper.FmlaAddSubtract(this.double_124, 0.0, this.double_166);
			this.double_175 = Helper.FmlaModulo(this.double_173, this.double_174, 0.0);
			this.double_176 = Helper.FmlaMultiplyDivide(this.double_175, 1.0, 2.0);
			this.double_177 = Helper.FmlaAddSubtract(this.double_176, 0.0, this.double_17);
			this.double_178 = Helper.FmlaIfElse(this.double_177, this.double_123, this.double_70);
			this.double_179 = Helper.FmlaIfElse(this.double_177, this.double_124, this.double_71);
			this.double_180 = Helper.FmlaIfElse(this.double_177, this.double_165, this.double_74);
			this.double_181 = Helper.FmlaIfElse(this.double_177, this.double_166, this.double_75);
			this.double_182 = Helper.FmlaArcTan(this.double_121, this.double_122);
			this.double_183 = Helper.FmlaAddSubtract(this.double_182, 21600000.0, 0.0);
			this.double_184 = Helper.FmlaIfElse(this.double_182, this.double_182, this.double_183);
			this.double_185 = Helper.FmlaAddSubtract(this.double_184, 0.0, this.double_15);
			this.double_186 = Helper.FmlaAddSubtract(this.double_185, 21600000.0, 0.0);
			this.double_187 = Helper.FmlaIfElse(this.double_185, this.double_185, this.double_186);
			this.double_188 = Helper.FmlaSine(this.double_23, this.double_15);
			this.double_189 = Helper.FmlaCosine(this.double_24, this.double_15);
			this.double_129 = Helper.FmlaCosineArcTan(this.double_23, this.double_189, this.double_188);
			this.double_130 = Helper.FmlaSineArcTan(this.double_24, this.double_189, this.double_188);
			this.double_190 = Helper.FmlaAddSubtract(base.double_2, this.double_129, 0.0);
			this.double_191 = Helper.FmlaAddSubtract(base.double_7, this.double_130, 0.0);
			this.double_192 = Helper.FmlaAddSubtract(this.double_15, 0.0, base.cd4);
			this.double_193 = Helper.FmlaAddSubtract(this.double_55, base.cd4, 0.0);
			this.double_194 = Helper.FmlaAddSubtract(this.double_55, base.cd2, 0.0);
			this.double_195 = Helper.FmlaCosine(this.double_19, 2700000.0);
			this.double_196 = Helper.FmlaSine(this.double_20, 2700000.0);
			this.double_197 = Helper.FmlaAddSubtract(base.double_2, 0.0, this.double_195);
			this.double_198 = Helper.FmlaAddSubtract(base.double_2, this.double_195, 0.0);
			this.double_199 = Helper.FmlaAddSubtract(base.double_7, 0.0, this.double_196);
			this.double_200 = Helper.FmlaAddSubtract(base.double_7, this.double_196, 0.0);
			if (base.shape.Class174_0.Class172_0.Count == 0)
			{
				double num = ((base.shape.Class174_0.Dictionary_0 == null || !base.shape.Class174_0.Dictionary_0.ContainsKey("adj2")) ? 1142319.0 : base.adj2);
				AdjustObject adjustObject = new Class168(new Class177(this.double_60 / 12700.0, this.double_61 / 12700.0, bool_1: false), "Adj2", 0.0, this.double_53, num, base.shape, bool_0: false);
				adjustObject.DefaultValue = 1142319.0;
				base.shape.Class174_0.Class172_0.method_0(adjustObject);
				num = ((base.shape.Class174_0.Dictionary_0 == null || !base.shape.Class174_0.Dictionary_0.ContainsKey("adj4")) ? 10800000.0 : base.adj4);
				adjustObject = new Class168(new Class177(this.double_66 / 12700.0, this.double_67 / 12700.0, bool_1: false), "Adj4", 0.0, 21599999.0, num, base.shape, bool_0: false);
				adjustObject.DefaultValue = 10800000.0;
				base.shape.Class174_0.Class172_0.method_0(adjustObject);
				num = ((base.shape.Class174_0.Dictionary_0 == null || !base.shape.Class174_0.Dictionary_0.ContainsKey("adj1")) ? 12500.0 : base.adj1);
				adjustObject = new Class169(new Class177(this.double_123 / 12700.0, this.double_124 / 12700.0, bool_1: false), "Adj1", 0.0, this.double_12, num, base.shape, bool_0: false);
				adjustObject.DefaultValue = 12500.0;
				base.shape.Class174_0.Class172_0.method_0(adjustObject);
				num = ((base.shape.Class174_0.Dictionary_0 == null || !base.shape.Class174_0.Dictionary_0.ContainsKey("adj3")) ? 20457681.0 : base.adj3);
				adjustObject = new Class168(new Class177(this.double_123 / 12700.0, this.double_124 / 12700.0, bool_1: false), "Adj3", 0.0, 21599999.0, num, base.shape, bool_0: false);
				adjustObject.DefaultValue = 20457681.0;
				base.shape.Class174_0.Class172_0.method_0(adjustObject);
				num = ((base.shape.Class174_0.Dictionary_0 == null || !base.shape.Class174_0.Dictionary_0.ContainsKey("adj5")) ? 12500.0 : base.adj5);
				adjustObject = new Class169(new Class177(this.double_74 / 12700.0, this.double_75 / 12700.0, bool_1: false), "Adj5", 0.0, 25000.0, num, base.shape, bool_0: true);
				adjustObject.DefaultValue = 12500.0;
				base.shape.Class174_0.Class172_0.method_0(adjustObject);
			}
			else
			{
				base.shape.Class174_0.Class172_0[0].AdjustRectangle.Class178_0.Class177_1 = new Class177(this.double_60 / 12700.0, this.double_61 / 12700.0, bool_1: false);
				base.shape.Class174_0.Class172_0[1].AdjustRectangle.Class178_0.Class177_1 = new Class177(this.double_66 / 12700.0, this.double_67 / 12700.0, bool_1: false);
				base.shape.Class174_0.Class172_0[2].AdjustRectangle.Class178_0.Class177_1 = new Class177(this.double_123 / 12700.0, this.double_124 / 12700.0, bool_1: false);
				base.shape.Class174_0.Class172_0[3].AdjustRectangle.Class178_0.Class177_1 = new Class177(this.double_123 / 12700.0, this.double_124 / 12700.0, bool_1: false);
				base.shape.Class174_0.Class172_0[4].AdjustRectangle.Class178_0.Class177_1 = new Class177(this.double_74 / 12700.0, this.double_75 / 12700.0, bool_1: false);
			}
			base.shape.Class174_0.Dictionary_0 = null;
			Class175[] array = new Class175[1];
			GraphicsPath graphicsPath = DrawHelper.PathBegin();
			Class175 @class = new Class175(bool_1: true, Enum32.const_5);
			Class177 currentPathEndLocation = DrawHelper.MoveTo(this.double_66, this.double_67);
			currentPathEndLocation = DrawHelper.ArcTo(graphicsPath, this.double_19, this.double_20, this.double_15, this.double_187, currentPathEndLocation);
			currentPathEndLocation = DrawHelper.LnTo(graphicsPath, currentPathEndLocation.Double_2, currentPathEndLocation.Double_3, this.double_178, this.double_179);
			currentPathEndLocation = DrawHelper.LnTo(graphicsPath, currentPathEndLocation.Double_2, currentPathEndLocation.Double_3, this.double_60, this.double_61);
			currentPathEndLocation = DrawHelper.LnTo(graphicsPath, currentPathEndLocation.Double_2, currentPathEndLocation.Double_3, this.double_180, this.double_181);
			currentPathEndLocation = DrawHelper.LnTo(graphicsPath, currentPathEndLocation.Double_2, currentPathEndLocation.Double_3, this.double_165, this.double_166);
			currentPathEndLocation = DrawHelper.ArcTo(graphicsPath, this.double_21, this.double_22, this.double_169, this.double_172, currentPathEndLocation);
			DrawHelper.Close(graphicsPath);
			@class.List_0.Add(graphicsPath);
			array[0] = @class;
			base.shape.Class183_0.Class175_0 = array;
		}
	}
}
