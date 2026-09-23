using System.Drawing.Drawing2D;
using ns17;
using TXTextControl.Drawing;

namespace ns18
{
	internal class Class356 : ShapeObject
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

		public Class356(Shape shape_0)
		{
			base.shape = shape_0;
			base.shape.Class174_0.Class172_0.Clear();
			base.adj = Helper.FmlaLiteralValue(25000.0);
			base.SetLoadedAvLstValues(base.shape);
		}

		internal override void CreateGraphicsPaths()
		{
			base.CreateBaseVariables(base.shape);
			this.double_11 = Helper.FmlaPinTo(12500.0, base.adj, 46875.0);
			this.double_12 = Helper.FmlaAddSubtract(50000.0, 0.0, this.double_11);
			this.double_13 = Helper.FmlaMultiplyDivide(this.double_12, 30274.0, 32768.0);
			this.double_14 = Helper.FmlaMultiplyDivide(this.double_12, 12540.0, 32768.0);
			this.double_15 = Helper.FmlaAddSubtract(this.double_13, 50000.0, 0.0);
			this.double_16 = Helper.FmlaAddSubtract(this.double_14, 50000.0, 0.0);
			this.double_17 = Helper.FmlaAddSubtract(50000.0, 0.0, this.double_13);
			this.double_18 = Helper.FmlaAddSubtract(50000.0, 0.0, this.double_14);
			this.double_19 = Helper.FmlaMultiplyDivide(this.double_12, 23170.0, 32768.0);
			this.double_20 = Helper.FmlaAddSubtract(50000.0, this.double_19, 0.0);
			this.double_21 = Helper.FmlaAddSubtract(50000.0, 0.0, this.double_19);
			this.double_22 = Helper.FmlaMultiplyDivide(this.double_17, 3.0, 4.0);
			this.double_23 = Helper.FmlaMultiplyDivide(this.double_18, 3.0, 4.0);
			this.double_24 = Helper.FmlaAddSubtract(this.double_22, 3662.0, 0.0);
			this.double_25 = Helper.FmlaAddSubtract(this.double_23, 3662.0, 0.0);
			this.double_26 = Helper.FmlaAddSubtract(this.double_23, 12500.0, 0.0);
			this.double_27 = Helper.FmlaAddSubtract(100000.0, 0.0, this.double_22);
			this.double_28 = Helper.FmlaAddSubtract(100000.0, 0.0, this.double_24);
			this.double_29 = Helper.FmlaAddSubtract(100000.0, 0.0, this.double_25);
			this.double_30 = Helper.FmlaAddSubtract(100000.0, 0.0, this.double_26);
			this.double_31 = Helper.FmlaMultiplyDivide(base.double_8, 18436.0, 21600.0);
			this.double_32 = Helper.FmlaMultiplyDivide(base.double_1, 3163.0, 21600.0);
			this.double_33 = Helper.FmlaMultiplyDivide(base.double_8, 3163.0, 21600.0);
			this.double_34 = Helper.FmlaMultiplyDivide(base.double_1, 18436.0, 21600.0);
			this.double_35 = Helper.FmlaMultiplyDivide(base.double_8, this.double_20, 100000.0);
			this.double_36 = Helper.FmlaMultiplyDivide(base.double_8, this.double_21, 100000.0);
			this.double_37 = Helper.FmlaMultiplyDivide(base.double_8, this.double_22, 100000.0);
			this.double_38 = Helper.FmlaMultiplyDivide(base.double_8, this.double_24, 100000.0);
			this.double_39 = Helper.FmlaMultiplyDivide(base.double_8, this.double_25, 100000.0);
			this.double_40 = Helper.FmlaMultiplyDivide(base.double_8, this.double_26, 100000.0);
			this.double_41 = Helper.FmlaMultiplyDivide(base.double_8, this.double_27, 100000.0);
			this.double_42 = Helper.FmlaMultiplyDivide(base.double_8, this.double_28, 100000.0);
			this.double_43 = Helper.FmlaMultiplyDivide(base.double_8, this.double_29, 100000.0);
			this.double_44 = Helper.FmlaMultiplyDivide(base.double_8, this.double_30, 100000.0);
			this.double_45 = Helper.FmlaMultiplyDivide(base.double_8, this.double_11, 100000.0);
			this.double_46 = Helper.FmlaMultiplyDivide(base.double_8, this.double_12, 100000.0);
			this.double_47 = Helper.FmlaMultiplyDivide(base.double_1, this.double_12, 100000.0);
			this.double_48 = Helper.FmlaMultiplyDivide(base.double_1, this.double_20, 100000.0);
			this.double_49 = Helper.FmlaMultiplyDivide(base.double_1, this.double_21, 100000.0);
			this.double_50 = Helper.FmlaMultiplyDivide(base.double_1, this.double_22, 100000.0);
			this.double_51 = Helper.FmlaMultiplyDivide(base.double_1, this.double_24, 100000.0);
			this.double_52 = Helper.FmlaMultiplyDivide(base.double_1, this.double_25, 100000.0);
			this.double_53 = Helper.FmlaMultiplyDivide(base.double_1, this.double_26, 100000.0);
			this.double_54 = Helper.FmlaMultiplyDivide(base.double_1, this.double_27, 100000.0);
			this.double_55 = Helper.FmlaMultiplyDivide(base.double_1, this.double_28, 100000.0);
			this.double_56 = Helper.FmlaMultiplyDivide(base.double_1, this.double_29, 100000.0);
			this.double_57 = Helper.FmlaMultiplyDivide(base.double_1, this.double_30, 100000.0);
			if (base.shape.Class174_0.Class172_0.Count == 0)
			{
				double num = ((base.shape.Class174_0.Dictionary_0 == null || !base.shape.Class174_0.Dictionary_0.ContainsKey("adj")) ? 25000.0 : base.adj);
				AdjustObject adjustObject = new Class170(new Class177(this.double_45 / 12700.0, base.double_7 / 12700.0, bool_1: false), "Adj", 12500.0, 46875.0, num, base.shape, bool_0: false);
				adjustObject.DefaultValue = 25000.0;
				base.shape.Class174_0.Class172_0.method_0(adjustObject);
			}
			else
			{
				base.shape.Class174_0.Class172_0[0].AdjustRectangle.Class178_0.Class177_1 = new Class177(this.double_45 / 12700.0, base.double_7 / 12700.0, bool_1: false);
			}
			base.shape.Class174_0.Dictionary_0 = null;
			Class175[] array = new Class175[1];
			GraphicsPath graphicsPath = DrawHelper.PathBegin();
			Class175 @class = new Class175(bool_1: true, Enum32.const_5);
			Class177 class2 = DrawHelper.MoveTo(base.double_5, base.double_7);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_41, this.double_57);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_41, this.double_53);
			DrawHelper.Close(graphicsPath);
			class2 = DrawHelper.MoveTo(this.double_31, this.double_32);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_42, this.double_52);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_43, this.double_51);
			DrawHelper.Close(graphicsPath);
			class2 = DrawHelper.MoveTo(base.double_2, base.t);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_44, this.double_50);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_40, this.double_50);
			DrawHelper.Close(graphicsPath);
			class2 = DrawHelper.MoveTo(this.double_33, this.double_32);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_39, this.double_51);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_38, this.double_52);
			DrawHelper.Close(graphicsPath);
			class2 = DrawHelper.MoveTo(base.double_3, base.double_7);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_37, this.double_53);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_37, this.double_57);
			DrawHelper.Close(graphicsPath);
			class2 = DrawHelper.MoveTo(this.double_33, this.double_34);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_38, this.double_56);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_39, this.double_55);
			DrawHelper.Close(graphicsPath);
			class2 = DrawHelper.MoveTo(base.double_2, base.double_0);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_40, this.double_54);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_44, this.double_54);
			DrawHelper.Close(graphicsPath);
			class2 = DrawHelper.MoveTo(this.double_31, this.double_34);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_43, this.double_55);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_42, this.double_56);
			DrawHelper.Close(graphicsPath);
			class2 = DrawHelper.MoveTo(this.double_45, base.double_7);
			class2 = DrawHelper.ArcTo(graphicsPath, this.double_46, this.double_47, base.cd2, 21600000.0, class2);
			DrawHelper.Close(graphicsPath);
			@class.List_0.Add(graphicsPath);
			array[0] = @class;
			base.shape.Class183_0.Class175_0 = array;
		}
	}
}
