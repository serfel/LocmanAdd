using System.Drawing.Drawing2D;
using ns17;
using TXTextControl.Drawing;

namespace ns18
{
	internal class Class249 : ShapeObject
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

		public Class249(Shape shape_0)
		{
			base.shape = shape_0;
			base.shape.Class174_0.Class172_0.Clear();
			base.adj1 = Helper.FmlaLiteralValue(25000.0);
			base.adj2 = Helper.FmlaLiteralValue(50000.0);
			base.adj3 = Helper.FmlaLiteralValue(12500.0);
			base.SetLoadedAvLstValues(base.shape);
		}

		internal override void CreateGraphicsPaths()
		{
			base.CreateBaseVariables(base.shape);
			this.double_11 = Helper.FmlaPinTo(0.0, base.adj1, 100000.0);
			this.double_12 = Helper.FmlaPinTo(25000.0, base.adj2, 75000.0);
			this.double_13 = Helper.FmlaAddSubtract(100000.0, 0.0, this.double_11);
			this.double_14 = Helper.FmlaMultiplyDivide(this.double_13, 1.0, 2.0);
			this.double_15 = Helper.FmlaAddSubtract(this.double_11, 0.0, this.double_14);
			this.double_16 = Helper.FmlaMaximumValue(0.0, this.double_15);
			this.double_17 = Helper.FmlaPinTo(this.double_16, base.adj3, this.double_11);
			this.double_18 = Helper.FmlaMultiplyDivide(base.double_8, this.double_12, 200000.0);
			this.double_19 = Helper.FmlaAddSubtract(base.double_2, 0.0, this.double_18);
			this.double_20 = Helper.FmlaAddSubtract(this.double_19, base.wd8, 0.0);
			this.double_21 = Helper.FmlaAddSubtract(base.double_5, 0.0, this.double_20);
			this.double_22 = Helper.FmlaAddSubtract(base.double_5, 0.0, this.double_19);
			this.double_23 = Helper.FmlaAddSubtract(base.double_5, 0.0, base.wd8);
			this.double_24 = Helper.FmlaMultiplyDivide(base.double_1, this.double_17, 100000.0);
			this.double_25 = Helper.FmlaMultiplyDivide(4.0, this.double_24, base.double_8);
			this.double_26 = Helper.FmlaMultiplyDivide(this.double_20, this.double_20, base.double_8);
			this.double_27 = Helper.FmlaAddSubtract(this.double_20, 0.0, this.double_26);
			this.double_28 = Helper.FmlaMultiplyDivide(this.double_25, this.double_27, 1.0);
			this.double_29 = Helper.FmlaAddSubtract(base.double_0, 0.0, this.double_28);
			this.double_30 = Helper.FmlaMultiplyDivide(this.double_20, 1.0, 2.0);
			this.double_31 = Helper.FmlaMultiplyDivide(this.double_25, this.double_30, 1.0);
			this.double_32 = Helper.FmlaAddSubtract(base.double_0, 0.0, this.double_31);
			this.double_33 = Helper.FmlaAddSubtract(base.double_5, 0.0, this.double_30);
			this.double_26 = Helper.FmlaMultiplyDivide(base.double_1, this.double_11, 100000.0);
			this.double_34 = Helper.FmlaAddSubtract(this.double_26, 0.0, this.double_24);
			this.double_35 = Helper.FmlaMultiplyDivide(this.double_19, this.double_19, base.double_8);
			this.double_36 = Helper.FmlaAddSubtract(this.double_19, 0.0, this.double_35);
			this.double_37 = Helper.FmlaMultiplyDivide(this.double_25, this.double_36, 1.0);
			this.double_38 = Helper.FmlaAddSubtract(this.double_37, this.double_34, 0.0);
			this.double_39 = Helper.FmlaAddSubtract(base.double_0, 0.0, this.double_38);
			this.double_40 = Helper.FmlaAddSubtract(this.double_24, this.double_34, this.double_38);
			this.double_41 = Helper.FmlaAddSubtract(this.double_40, this.double_24, 0.0);
			this.double_42 = Helper.FmlaAddSubtract(this.double_41, this.double_34, 0.0);
			this.double_43 = Helper.FmlaAddSubtract(base.double_0, 0.0, this.double_42);
			this.double_44 = Helper.FmlaAddSubtract(base.double_0, 0.0, this.double_26);
			this.double_45 = Helper.FmlaMultiplyDivide(this.double_24, 14.0, 16.0);
			this.double_46 = Helper.FmlaAddDivide(this.double_45, this.double_44, 2.0);
			this.double_47 = Helper.FmlaAddSubtract(base.double_0, 0.0, this.double_46);
			this.double_48 = Helper.FmlaAddSubtract(this.double_37, this.double_44, 0.0);
			this.double_49 = Helper.FmlaAddSubtract(base.double_0, 0.0, this.double_48);
			this.double_50 = Helper.FmlaAddSubtract(this.double_38, this.double_44, 0.0);
			this.double_51 = Helper.FmlaAddSubtract(base.double_0, 0.0, this.double_50);
			this.double_52 = Helper.FmlaMultiplyDivide(this.double_19, 1.0, 2.0);
			this.double_53 = Helper.FmlaMultiplyDivide(this.double_25, this.double_52, 1.0);
			this.double_54 = Helper.FmlaAddSubtract(this.double_53, this.double_44, 0.0);
			this.double_55 = Helper.FmlaAddSubtract(base.double_0, 0.0, this.double_54);
			this.double_56 = Helper.FmlaAddSubtract(base.double_5, 0.0, this.double_52);
			this.double_57 = Helper.FmlaAddSubtract(this.double_42, this.double_44, 0.0);
			this.double_58 = Helper.FmlaAddSubtract(base.double_0, 0.0, this.double_57);
			this.double_59 = Helper.FmlaAddSubtract(this.double_28, this.double_34, 0.0);
			this.double_60 = Helper.FmlaAddSubtract(base.double_0, 0.0, this.double_59);
			this.double_61 = Helper.FmlaAddSubtract(this.double_26, this.double_26, this.double_59);
			this.double_62 = Helper.FmlaAddSubtract(base.double_0, 0.0, this.double_61);
			if (base.shape.Class174_0.Class172_0.Count == 0)
			{
				double num = ((base.shape.Class174_0.Dictionary_0 == null || !base.shape.Class174_0.Dictionary_0.ContainsKey("adj1")) ? 25000.0 : base.adj1);
				AdjustObject adjustObject = new Class171(new Class177(base.double_2 / 12700.0, this.double_44 / 12700.0, bool_1: false), "Adj1", 0.0, 100000.0, num, base.shape, bool_0: true);
				adjustObject.DefaultValue = 25000.0;
				base.shape.Class174_0.Class172_0.method_0(adjustObject);
				num = ((base.shape.Class174_0.Dictionary_0 == null || !base.shape.Class174_0.Dictionary_0.ContainsKey("adj2")) ? 50000.0 : base.adj2);
				adjustObject = new Class170(new Class177(this.double_19 / 12700.0, base.t / 12700.0, bool_1: false), "Adj2", 25000.0, 100000.0, num, base.shape, bool_0: true);
				adjustObject.DefaultValue = 50000.0;
				base.shape.Class174_0.Class172_0.method_0(adjustObject);
				num = ((base.shape.Class174_0.Dictionary_0 == null || !base.shape.Class174_0.Dictionary_0.ContainsKey("adj3")) ? 12500.0 : base.adj3);
				adjustObject = new Class171(new Class177(base.double_3 / 12700.0, this.double_24 / 12700.0, bool_1: false), "Adj3", this.double_16, this.double_11, num, base.shape, bool_0: false);
				adjustObject.DefaultValue = 12500.0;
				base.shape.Class174_0.Class172_0.method_0(adjustObject);
			}
			else
			{
				base.shape.Class174_0.Class172_0[0].AdjustRectangle.Class178_0.Class177_1 = new Class177(base.double_2 / 12700.0, this.double_44 / 12700.0, bool_1: false);
				base.shape.Class174_0.Class172_0[1].AdjustRectangle.Class178_0.Class177_1 = new Class177(this.double_19 / 12700.0, base.t / 12700.0, bool_1: false);
				base.shape.Class174_0.Class172_0[2].AdjustRectangle.Class178_0.Class177_1 = new Class177(base.double_3 / 12700.0, this.double_24 / 12700.0, bool_1: false);
			}
			base.shape.Class174_0.Dictionary_0 = null;
			Class175[] array = new Class175[3];
			GraphicsPath graphicsPath = DrawHelper.PathBegin();
			Class175 @class = new Class175(bool_1: false, Enum32.const_5);
			Class177 point = DrawHelper.MoveTo(base.double_3, base.double_0);
			base.ipt2 = new Class177(this.double_30, this.double_32, bool_1: true);
			base.ipt3 = new Class177(this.double_20, this.double_29, bool_1: true);
			point = DrawHelper.QuadBezTo(graphicsPath, point, base.ipt2, base.ipt3);
			point = DrawHelper.LnTo(graphicsPath, point.Double_2, point.Double_3, this.double_19, this.double_39);
			base.ipt2 = new Class177(base.double_2, this.double_43, bool_1: true);
			base.ipt3 = new Class177(this.double_22, this.double_39, bool_1: true);
			point = DrawHelper.QuadBezTo(graphicsPath, point, base.ipt2, base.ipt3);
			point = DrawHelper.LnTo(graphicsPath, point.Double_2, point.Double_3, this.double_21, this.double_29);
			base.ipt2 = new Class177(this.double_33, this.double_32, bool_1: true);
			base.ipt3 = new Class177(base.double_5, base.double_0, bool_1: true);
			point = DrawHelper.QuadBezTo(graphicsPath, point, base.ipt2, base.ipt3);
			point = DrawHelper.LnTo(graphicsPath, point.Double_2, point.Double_3, this.double_23, this.double_47);
			point = DrawHelper.LnTo(graphicsPath, point.Double_2, point.Double_3, base.double_5, this.double_26);
			base.ipt2 = new Class177(this.double_56, this.double_55, bool_1: true);
			base.ipt3 = new Class177(this.double_22, this.double_49, bool_1: true);
			point = DrawHelper.QuadBezTo(graphicsPath, point, base.ipt2, base.ipt3);
			point = DrawHelper.LnTo(graphicsPath, point.Double_2, point.Double_3, this.double_22, this.double_51);
			base.ipt2 = new Class177(base.double_2, this.double_58, bool_1: true);
			base.ipt3 = new Class177(this.double_19, this.double_51, bool_1: true);
			point = DrawHelper.QuadBezTo(graphicsPath, point, base.ipt2, base.ipt3);
			point = DrawHelper.LnTo(graphicsPath, point.Double_2, point.Double_3, this.double_19, this.double_49);
			base.ipt2 = new Class177(this.double_52, this.double_55, bool_1: true);
			base.ipt3 = new Class177(base.double_3, this.double_26, bool_1: true);
			point = DrawHelper.QuadBezTo(graphicsPath, point, base.ipt2, base.ipt3);
			point = DrawHelper.LnTo(graphicsPath, point.Double_2, point.Double_3, base.wd8, this.double_47);
			DrawHelper.Close(graphicsPath);
			@class.List_0.Add(graphicsPath);
			array[0] = @class;
			graphicsPath = DrawHelper.PathBegin();
			@class = new Class175(bool_1: false, Enum32.const_1);
			point = DrawHelper.MoveTo(this.double_20, this.double_60);
			point = DrawHelper.LnTo(graphicsPath, point.Double_2, point.Double_3, this.double_20, this.double_29);
			point = DrawHelper.LnTo(graphicsPath, point.Double_2, point.Double_3, this.double_19, this.double_39);
			base.ipt2 = new Class177(base.double_2, this.double_43, bool_1: true);
			base.ipt3 = new Class177(this.double_22, this.double_39, bool_1: true);
			point = DrawHelper.QuadBezTo(graphicsPath, point, base.ipt2, base.ipt3);
			point = DrawHelper.LnTo(graphicsPath, point.Double_2, point.Double_3, this.double_21, this.double_29);
			point = DrawHelper.LnTo(graphicsPath, point.Double_2, point.Double_3, this.double_21, this.double_60);
			base.ipt2 = new Class177(base.double_2, this.double_62, bool_1: true);
			base.ipt3 = new Class177(this.double_20, this.double_60, bool_1: true);
			point = DrawHelper.QuadBezTo(graphicsPath, point, base.ipt2, base.ipt3);
			DrawHelper.Close(graphicsPath);
			@class.List_0.Add(graphicsPath);
			array[1] = @class;
			graphicsPath = DrawHelper.PathBegin();
			@class = new Class175(bool_1: true, Enum32.const_4);
			point = DrawHelper.MoveTo(base.double_3, base.double_0);
			point = DrawHelper.LnTo(graphicsPath, point.Double_2, point.Double_3, base.wd8, this.double_47);
			point = DrawHelper.LnTo(graphicsPath, point.Double_2, point.Double_3, base.double_3, this.double_26);
			base.ipt2 = new Class177(this.double_52, this.double_55, bool_1: true);
			base.ipt3 = new Class177(this.double_19, this.double_49, bool_1: true);
			point = DrawHelper.QuadBezTo(graphicsPath, point, base.ipt2, base.ipt3);
			point = DrawHelper.LnTo(graphicsPath, point.Double_2, point.Double_3, this.double_19, this.double_51);
			base.ipt2 = new Class177(base.double_2, this.double_58, bool_1: true);
			base.ipt3 = new Class177(this.double_22, this.double_51, bool_1: true);
			point = DrawHelper.QuadBezTo(graphicsPath, point, base.ipt2, base.ipt3);
			point = DrawHelper.LnTo(graphicsPath, point.Double_2, point.Double_3, this.double_22, this.double_49);
			base.ipt2 = new Class177(this.double_56, this.double_55, bool_1: true);
			base.ipt3 = new Class177(base.double_5, this.double_26, bool_1: true);
			point = DrawHelper.QuadBezTo(graphicsPath, point, base.ipt2, base.ipt3);
			point = DrawHelper.LnTo(graphicsPath, point.Double_2, point.Double_3, this.double_23, this.double_47);
			point = DrawHelper.LnTo(graphicsPath, point.Double_2, point.Double_3, base.double_5, base.double_0);
			base.ipt2 = new Class177(this.double_33, this.double_32, bool_1: true);
			base.ipt3 = new Class177(this.double_21, this.double_29, bool_1: true);
			point = DrawHelper.QuadBezTo(graphicsPath, point, base.ipt2, base.ipt3);
			point = DrawHelper.LnTo(graphicsPath, point.Double_2, point.Double_3, this.double_22, this.double_39);
			base.ipt2 = new Class177(base.double_2, this.double_43, bool_1: true);
			base.ipt3 = new Class177(this.double_19, this.double_39, bool_1: true);
			point = DrawHelper.QuadBezTo(graphicsPath, point, base.ipt2, base.ipt3);
			point = DrawHelper.LnTo(graphicsPath, point.Double_2, point.Double_3, this.double_20, this.double_29);
			base.ipt2 = new Class177(this.double_30, this.double_32, bool_1: true);
			base.ipt3 = new Class177(base.double_3, base.double_0, bool_1: true);
			point = DrawHelper.QuadBezTo(graphicsPath, point, base.ipt2, base.ipt3);
			DrawHelper.Close(graphicsPath);
			point = DrawHelper.MoveTo(this.double_19, this.double_39, graphicsPath, @class, out graphicsPath);
			point = DrawHelper.LnTo(graphicsPath, point.Double_2, point.Double_3, this.double_19, this.double_49);
			point = DrawHelper.MoveTo(this.double_22, this.double_49, graphicsPath, @class, out graphicsPath);
			point = DrawHelper.LnTo(graphicsPath, point.Double_2, point.Double_3, this.double_22, this.double_39);
			point = DrawHelper.MoveTo(this.double_20, this.double_60, graphicsPath, @class, out graphicsPath);
			point = DrawHelper.LnTo(graphicsPath, point.Double_2, point.Double_3, this.double_20, this.double_29);
			point = DrawHelper.MoveTo(this.double_21, this.double_29, graphicsPath, @class, out graphicsPath);
			point = DrawHelper.LnTo(graphicsPath, point.Double_2, point.Double_3, this.double_21, this.double_60);
			@class.List_0.Add(graphicsPath);
			array[2] = @class;
			base.shape.Class183_0.Class175_0 = array;
		}
	}
}
