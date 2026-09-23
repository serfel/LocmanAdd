using System.Drawing.Drawing2D;
using ns17;
using TXTextControl.Drawing;

namespace ns18
{
	internal class Class352 : ShapeObject
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

		public Class352(Shape shape_0)
		{
			base.shape = shape_0;
			base.shape.Class174_0.Class172_0.Clear();
			base.adj = Helper.FmlaLiteralValue(34601.0);
			base.double_9 = Helper.FmlaLiteralValue(102572.0);
			base.SaveHF = true;
			base.double_10 = Helper.FmlaLiteralValue(105210.0);
			base.SaveVF = true;
			base.SetLoadedAvLstValues(base.shape);
		}

		internal override void CreateGraphicsPaths()
		{
			base.CreateBaseVariables(base.shape);
			this.double_11 = Helper.FmlaPinTo(0.0, base.adj, 50000.0);
			this.double_12 = Helper.FmlaMultiplyDivide(base.wd2, base.double_9, 100000.0);
			this.double_13 = Helper.FmlaMultiplyDivide(base.hd2, base.double_10, 100000.0);
			this.double_14 = Helper.FmlaMultiplyDivide(base.double_7, base.double_10, 100000.0);
			this.double_15 = Helper.FmlaMultiplyDivide(this.double_12, 97493.0, 100000.0);
			this.double_16 = Helper.FmlaMultiplyDivide(this.double_12, 78183.0, 100000.0);
			this.double_17 = Helper.FmlaMultiplyDivide(this.double_12, 43388.0, 100000.0);
			this.double_18 = Helper.FmlaMultiplyDivide(this.double_13, 62349.0, 100000.0);
			this.double_19 = Helper.FmlaMultiplyDivide(this.double_13, 22252.0, 100000.0);
			this.double_20 = Helper.FmlaMultiplyDivide(this.double_13, 90097.0, 100000.0);
			this.double_21 = Helper.FmlaAddSubtract(base.double_2, 0.0, this.double_15);
			this.double_22 = Helper.FmlaAddSubtract(base.double_2, 0.0, this.double_16);
			this.double_23 = Helper.FmlaAddSubtract(base.double_2, 0.0, this.double_17);
			this.double_24 = Helper.FmlaAddSubtract(base.double_2, this.double_17, 0.0);
			this.double_25 = Helper.FmlaAddSubtract(base.double_2, this.double_16, 0.0);
			this.double_26 = Helper.FmlaAddSubtract(base.double_2, this.double_15, 0.0);
			this.double_27 = Helper.FmlaAddSubtract(this.double_14, 0.0, this.double_18);
			this.double_28 = Helper.FmlaAddSubtract(this.double_14, this.double_19, 0.0);
			this.double_29 = Helper.FmlaAddSubtract(this.double_14, this.double_20, 0.0);
			this.double_30 = Helper.FmlaMultiplyDivide(this.double_12, this.double_11, 50000.0);
			this.double_31 = Helper.FmlaMultiplyDivide(this.double_13, this.double_11, 50000.0);
			this.double_32 = Helper.FmlaMultiplyDivide(this.double_30, 97493.0, 100000.0);
			this.double_33 = Helper.FmlaMultiplyDivide(this.double_30, 78183.0, 100000.0);
			this.double_34 = Helper.FmlaMultiplyDivide(this.double_30, 43388.0, 100000.0);
			this.double_35 = Helper.FmlaAddSubtract(base.double_2, 0.0, this.double_32);
			this.double_36 = Helper.FmlaAddSubtract(base.double_2, 0.0, this.double_33);
			this.double_37 = Helper.FmlaAddSubtract(base.double_2, 0.0, this.double_34);
			this.double_38 = Helper.FmlaAddSubtract(base.double_2, this.double_34, 0.0);
			this.double_39 = Helper.FmlaAddSubtract(base.double_2, this.double_33, 0.0);
			this.double_40 = Helper.FmlaAddSubtract(base.double_2, this.double_32, 0.0);
			this.double_41 = Helper.FmlaMultiplyDivide(this.double_31, 90097.0, 100000.0);
			this.double_42 = Helper.FmlaMultiplyDivide(this.double_31, 22252.0, 100000.0);
			this.double_43 = Helper.FmlaMultiplyDivide(this.double_31, 62349.0, 100000.0);
			this.double_44 = Helper.FmlaAddSubtract(this.double_14, 0.0, this.double_41);
			this.double_45 = Helper.FmlaAddSubtract(this.double_14, 0.0, this.double_42);
			this.double_46 = Helper.FmlaAddSubtract(this.double_14, this.double_43, 0.0);
			this.double_47 = Helper.FmlaAddSubtract(this.double_14, this.double_31, 0.0);
			this.double_48 = Helper.FmlaAddSubtract(this.double_14, 0.0, this.double_31);
			if (base.shape.Class174_0.Class172_0.Count == 0)
			{
				double num = ((base.shape.Class174_0.Dictionary_0 == null || !base.shape.Class174_0.Dictionary_0.ContainsKey("adj")) ? 34601.0 : base.adj);
				AdjustObject adjustObject = new Class171(new Class177(base.double_2 / 12700.0, this.double_48 / 12700.0, bool_1: false), "Adj", 0.0, 50000.0, num, base.shape, bool_0: true);
				adjustObject.DefaultValue = 34601.0;
				base.shape.Class174_0.Class172_0.method_0(adjustObject);
			}
			else
			{
				base.shape.Class174_0.Class172_0[0].AdjustRectangle.Class178_0.Class177_1 = new Class177(base.double_2 / 12700.0, this.double_48 / 12700.0, bool_1: false);
			}
			base.shape.Class174_0.Dictionary_0 = null;
			Class175[] array = new Class175[1];
			GraphicsPath graphicsPath = DrawHelper.PathBegin();
			Class175 @class = new Class175(bool_1: true, Enum32.const_5);
			Class177 class2 = DrawHelper.MoveTo(this.double_21, this.double_28);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_35, this.double_45);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_22, this.double_27);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_37, this.double_44);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, base.double_2, base.t);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_38, this.double_44);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_25, this.double_27);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_40, this.double_45);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_26, this.double_28);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_39, this.double_46);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_24, this.double_29);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, base.double_2, this.double_47);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_23, this.double_29);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_36, this.double_46);
			DrawHelper.Close(graphicsPath);
			@class.List_0.Add(graphicsPath);
			array[0] = @class;
			base.shape.Class183_0.Class175_0 = array;
		}
	}
}
