using System.Drawing.Drawing2D;
using ns17;
using TXTextControl.Drawing;

namespace ns18
{
	internal class Class199 : ShapeObject
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

		public Class199(Shape shape_0)
		{
			base.shape = shape_0;
			base.shape.Class174_0.Class172_0.Clear();
		}

		internal override void CreateGraphicsPaths()
		{
			base.CreateBaseVariables(base.shape);
			this.double_11 = Helper.FmlaMultiplyDivide(base.double_6, 3.0, 8.0);
			this.double_12 = Helper.FmlaAddSubtract(base.double_7, 0.0, this.double_11);
			this.double_13 = Helper.FmlaAddSubtract(base.double_7, this.double_11, 0.0);
			this.double_14 = Helper.FmlaAddSubtract(base.double_2, 0.0, this.double_11);
			this.double_15 = Helper.FmlaAddSubtract(base.double_2, this.double_11, 0.0);
			this.double_16 = Helper.FmlaMultiplyDivide(base.double_6, 3.0, 4.0);
			this.double_17 = Helper.FmlaMultiplyDivide(this.double_16, 1455.0, 21600.0);
			this.double_18 = Helper.FmlaMultiplyDivide(this.double_16, 1905.0, 21600.0);
			this.double_19 = Helper.FmlaMultiplyDivide(this.double_16, 2325.0, 21600.0);
			this.double_20 = Helper.FmlaMultiplyDivide(this.double_16, 16155.0, 21600.0);
			this.double_21 = Helper.FmlaMultiplyDivide(this.double_16, 17010.0, 21600.0);
			this.double_22 = Helper.FmlaMultiplyDivide(this.double_16, 19335.0, 21600.0);
			this.double_23 = Helper.FmlaMultiplyDivide(this.double_16, 19725.0, 21600.0);
			this.double_24 = Helper.FmlaMultiplyDivide(this.double_16, 20595.0, 21600.0);
			this.double_25 = Helper.FmlaMultiplyDivide(this.double_16, 5280.0, 21600.0);
			this.double_26 = Helper.FmlaMultiplyDivide(this.double_16, 5730.0, 21600.0);
			this.double_27 = Helper.FmlaMultiplyDivide(this.double_16, 6630.0, 21600.0);
			this.double_28 = Helper.FmlaMultiplyDivide(this.double_16, 7492.0, 21600.0);
			this.double_29 = Helper.FmlaMultiplyDivide(this.double_16, 9067.0, 21600.0);
			this.double_30 = Helper.FmlaMultiplyDivide(this.double_16, 9555.0, 21600.0);
			this.double_31 = Helper.FmlaMultiplyDivide(this.double_16, 13342.0, 21600.0);
			this.double_32 = Helper.FmlaMultiplyDivide(this.double_16, 14580.0, 21600.0);
			this.double_33 = Helper.FmlaMultiplyDivide(this.double_16, 15592.0, 21600.0);
			this.double_34 = Helper.FmlaAddSubtract(this.double_14, this.double_17, 0.0);
			this.double_35 = Helper.FmlaAddSubtract(this.double_14, this.double_18, 0.0);
			this.double_36 = Helper.FmlaAddSubtract(this.double_14, this.double_19, 0.0);
			this.double_37 = Helper.FmlaAddSubtract(this.double_14, this.double_20, 0.0);
			this.double_38 = Helper.FmlaAddSubtract(this.double_14, this.double_21, 0.0);
			this.double_39 = Helper.FmlaAddSubtract(this.double_14, this.double_22, 0.0);
			this.double_40 = Helper.FmlaAddSubtract(this.double_14, this.double_23, 0.0);
			this.double_41 = Helper.FmlaAddSubtract(this.double_14, this.double_24, 0.0);
			this.double_42 = Helper.FmlaAddSubtract(this.double_12, this.double_25, 0.0);
			this.double_43 = Helper.FmlaAddSubtract(this.double_12, this.double_26, 0.0);
			this.double_44 = Helper.FmlaAddSubtract(this.double_12, this.double_27, 0.0);
			this.double_45 = Helper.FmlaAddSubtract(this.double_12, this.double_28, 0.0);
			this.double_46 = Helper.FmlaAddSubtract(this.double_12, this.double_29, 0.0);
			this.double_47 = Helper.FmlaAddSubtract(this.double_12, this.double_30, 0.0);
			this.double_48 = Helper.FmlaAddSubtract(this.double_12, this.double_31, 0.0);
			this.double_49 = Helper.FmlaAddSubtract(this.double_12, this.double_32, 0.0);
			this.double_50 = Helper.FmlaAddSubtract(this.double_12, this.double_33, 0.0);
			this.double_51 = Helper.FmlaAddSubtract(this.double_12, this.double_34, 0.0);
			Class175[] array = new Class175[4];
			GraphicsPath graphicsPath = DrawHelper.PathBegin();
			Class175 @class = new Class175(bool_1: false, Enum32.const_5);
			Class177 class2 = DrawHelper.MoveTo(base.double_3, base.t);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, base.double_5, base.t);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, base.double_5, base.double_0);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, base.double_3, base.double_0);
			DrawHelper.Close(graphicsPath);
			class2 = DrawHelper.MoveTo(this.double_14, this.double_42);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_14, this.double_47);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_34, this.double_47);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_35, this.double_46);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_36, this.double_46);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_36, this.double_50);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_38, this.double_50);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_38, this.double_48);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_39, this.double_48);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_41, this.double_49);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_15, this.double_49);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_15, this.double_44);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_41, this.double_44);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_40, this.double_45);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_38, this.double_45);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_38, this.double_44);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_37, this.double_43);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_35, this.double_43);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_34, this.double_42);
			DrawHelper.Close(graphicsPath);
			@class.List_0.Add(graphicsPath);
			array[0] = @class;
			graphicsPath = DrawHelper.PathBegin();
			@class = new Class175(bool_1: false, Enum32.const_0);
			class2 = DrawHelper.MoveTo(this.double_14, this.double_42);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_14, this.double_47);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_34, this.double_47);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_35, this.double_46);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_36, this.double_46);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_36, this.double_50);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_38, this.double_50);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_38, this.double_48);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_39, this.double_48);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_41, this.double_49);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_15, this.double_49);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_15, this.double_44);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_41, this.double_44);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_40, this.double_45);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_38, this.double_45);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_38, this.double_44);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_37, this.double_43);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_35, this.double_43);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_34, this.double_42);
			DrawHelper.Close(graphicsPath);
			@class.List_0.Add(graphicsPath);
			array[1] = @class;
			graphicsPath = DrawHelper.PathBegin();
			@class = new Class175(bool_1: true, Enum32.const_4);
			class2 = DrawHelper.MoveTo(this.double_14, this.double_42);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_34, this.double_42);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_35, this.double_43);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_37, this.double_43);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_38, this.double_44);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_38, this.double_45);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_40, this.double_45);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_41, this.double_44);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_15, this.double_44);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_15, this.double_49);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_41, this.double_49);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_39, this.double_48);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_38, this.double_48);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_38, this.double_50);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_36, this.double_50);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_36, this.double_46);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_35, this.double_46);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_34, this.double_47);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_14, this.double_47);
			DrawHelper.Close(graphicsPath);
			@class.List_0.Add(graphicsPath);
			array[2] = @class;
			graphicsPath = DrawHelper.PathBegin();
			@class = new Class175(bool_1: true, Enum32.const_4);
			class2 = DrawHelper.MoveTo(base.double_3, base.t);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, base.double_5, base.t);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, base.double_5, base.double_0);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, base.double_3, base.double_0);
			DrawHelper.Close(graphicsPath);
			@class.List_0.Add(graphicsPath);
			array[3] = @class;
			base.shape.Class183_0.Class175_0 = array;
		}
	}
}
