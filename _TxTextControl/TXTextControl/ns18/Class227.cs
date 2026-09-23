using System.Drawing.Drawing2D;
using ns17;
using TXTextControl.Drawing;

namespace ns18
{
	internal class Class227 : ShapeObject
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

		public Class227(Shape shape_0)
		{
			base.shape = shape_0;
			base.shape.Class174_0.Class172_0.Clear();
			base.adj1 = Helper.FmlaLiteralValue(-20833.0);
			base.adj2 = Helper.FmlaLiteralValue(62500.0);
			base.SetLoadedAvLstValues(base.shape);
		}

		internal override void CreateGraphicsPaths()
		{
			base.CreateBaseVariables(base.shape);
			this.double_11 = Helper.FmlaMultiplyDivide(base.double_8, base.adj1, 100000.0);
			this.double_12 = Helper.FmlaMultiplyDivide(base.double_1, base.adj2, 100000.0);
			this.double_13 = Helper.FmlaAddSubtract(base.double_2, this.double_11, 0.0);
			this.double_14 = Helper.FmlaAddSubtract(base.double_7, this.double_12, 0.0);
			this.double_15 = Helper.FmlaCosineArcTan(base.hd2, this.double_11, this.double_12);
			this.double_16 = Helper.FmlaSineArcTan(base.wd2, this.double_11, this.double_12);
			this.double_17 = Helper.FmlaCosineArcTan(base.wd2, this.double_15, this.double_16);
			this.double_18 = Helper.FmlaSineArcTan(base.hd2, this.double_15, this.double_16);
			this.double_19 = Helper.FmlaAddSubtract(base.double_2, this.double_17, 0.0);
			this.double_20 = Helper.FmlaAddSubtract(base.double_7, this.double_18, 0.0);
			this.double_21 = Helper.FmlaAddSubtract(this.double_19, 0.0, this.double_13);
			this.double_22 = Helper.FmlaAddSubtract(this.double_20, 0.0, this.double_14);
			this.double_23 = Helper.FmlaModulo(this.double_21, this.double_22, 0.0);
			this.double_24 = Helper.FmlaMultiplyDivide(base.double_6, 6600.0, 21600.0);
			this.double_25 = Helper.FmlaAddSubtract(this.double_23, 0.0, this.double_24);
			this.double_26 = Helper.FmlaMultiplyDivide(this.double_25, 1.0, 3.0);
			this.double_27 = Helper.FmlaMultiplyDivide(base.double_6, 1800.0, 21600.0);
			this.double_28 = Helper.FmlaAddSubtract(this.double_26, this.double_27, 0.0);
			this.double_29 = Helper.FmlaMultiplyDivide(this.double_28, this.double_21, this.double_23);
			this.double_30 = Helper.FmlaMultiplyDivide(this.double_28, this.double_22, this.double_23);
			this.double_31 = Helper.FmlaAddSubtract(this.double_29, this.double_13, 0.0);
			this.double_32 = Helper.FmlaAddSubtract(this.double_30, this.double_14, 0.0);
			this.double_33 = Helper.FmlaMultiplyDivide(base.double_6, 4800.0, 21600.0);
			this.double_34 = Helper.FmlaMultiplyDivide(this.double_26, 2.0, 1.0);
			this.double_35 = Helper.FmlaAddSubtract(this.double_33, this.double_34, 0.0);
			this.double_36 = Helper.FmlaMultiplyDivide(this.double_35, this.double_21, this.double_23);
			this.double_37 = Helper.FmlaMultiplyDivide(this.double_35, this.double_22, this.double_23);
			this.double_38 = Helper.FmlaAddSubtract(this.double_36, this.double_13, 0.0);
			this.double_39 = Helper.FmlaAddSubtract(this.double_37, this.double_14, 0.0);
			this.double_40 = Helper.FmlaMultiplyDivide(base.double_6, 1200.0, 21600.0);
			this.double_41 = Helper.FmlaMultiplyDivide(base.double_6, 600.0, 21600.0);
			this.double_42 = Helper.FmlaAddSubtract(this.double_13, this.double_41, 0.0);
			this.double_43 = Helper.FmlaAddSubtract(this.double_31, this.double_40, 0.0);
			this.double_44 = Helper.FmlaAddSubtract(this.double_38, this.double_27, 0.0);
			this.double_45 = Helper.FmlaMultiplyDivide(base.double_8, 2977.0, 21600.0);
			this.double_46 = Helper.FmlaMultiplyDivide(base.double_1, 3262.0, 21600.0);
			this.double_47 = Helper.FmlaMultiplyDivide(base.double_8, 17087.0, 21600.0);
			this.double_48 = Helper.FmlaMultiplyDivide(base.double_1, 17337.0, 21600.0);
			this.double_49 = Helper.FmlaMultiplyDivide(base.double_8, 67.0, 21600.0);
			this.double_50 = Helper.FmlaMultiplyDivide(base.double_1, 21577.0, 21600.0);
			this.double_51 = Helper.FmlaMultiplyDivide(base.double_8, 21582.0, 21600.0);
			this.double_52 = Helper.FmlaMultiplyDivide(base.double_1, 1235.0, 21600.0);
			this.double_53 = Helper.FmlaArcTan(this.double_11, this.double_12);
			if (base.shape.Class174_0.Class172_0.Count == 0)
			{
				double num = ((base.shape.Class174_0.Dictionary_0 == null || !base.shape.Class174_0.Dictionary_0.ContainsKey("adj1")) ? (-20833.0) : base.adj1);
				AdjustObject adjustObject = new Class170(new Class177(this.double_13 / 12700.0, this.double_14 / 12700.0, bool_1: false), "Adj1", -2147483647.0, 2147483647.0, num, base.shape, bool_0: false);
				adjustObject.DefaultValue = -20833.0;
				base.shape.Class174_0.Class172_0.method_0(adjustObject);
				num = ((base.shape.Class174_0.Dictionary_0 == null || !base.shape.Class174_0.Dictionary_0.ContainsKey("adj2")) ? 62500.0 : base.adj2);
				adjustObject = new Class171(new Class177(this.double_13 / 12700.0, this.double_14 / 12700.0, bool_1: false), "Adj2", -2147483647.0, 2147483647.0, num, base.shape, bool_0: false);
				adjustObject.DefaultValue = 62500.0;
				base.shape.Class174_0.Class172_0.method_0(adjustObject);
			}
			else
			{
				base.shape.Class174_0.Class172_0[0].AdjustRectangle.Class178_0.Class177_1 = new Class177(this.double_13 / 12700.0, this.double_14 / 12700.0, bool_1: false);
				base.shape.Class174_0.Class172_0[1].AdjustRectangle.Class178_0.Class177_1 = new Class177(this.double_13 / 12700.0, this.double_14 / 12700.0, bool_1: false);
			}
			base.shape.Class174_0.Dictionary_0 = null;
			Class175[] array = new Class175[5];
			GraphicsPath graphicsPath = DrawHelper.PathBegin();
			Class175 @class = new Class175(bool_1: true, Enum32.const_5);
			Class177 currentPathEndLocation = DrawHelper.MoveTo(3900.0, 14370.0);
			currentPathEndLocation = DrawHelper.ArcTo(graphicsPath, 6753.0, 9190.0, -11429249.0, 7426832.0, currentPathEndLocation);
			currentPathEndLocation = DrawHelper.ArcTo(graphicsPath, 5333.0, 7267.0, -8646143.0, 5396714.0, currentPathEndLocation);
			currentPathEndLocation = DrawHelper.ArcTo(graphicsPath, 4365.0, 5945.0, -8748475.0, 5983381.0, currentPathEndLocation);
			currentPathEndLocation = DrawHelper.ArcTo(graphicsPath, 4857.0, 6595.0, -7859164.0, 7034504.0, currentPathEndLocation);
			currentPathEndLocation = DrawHelper.ArcTo(graphicsPath, 5333.0, 7273.0, -4722533.0, 6541615.0, currentPathEndLocation);
			currentPathEndLocation = DrawHelper.ArcTo(graphicsPath, 6775.0, 9220.0, -2776035.0, 7816140.0, currentPathEndLocation);
			currentPathEndLocation = DrawHelper.ArcTo(graphicsPath, 5785.0, 7867.0, 37501.0, 6842000.0, currentPathEndLocation);
			currentPathEndLocation = DrawHelper.ArcTo(graphicsPath, 6752.0, 9215.0, 1347096.0, 6910353.0, currentPathEndLocation);
			currentPathEndLocation = DrawHelper.ArcTo(graphicsPath, 7720.0, 10543.0, 3974558.0, 4542661.0, currentPathEndLocation);
			currentPathEndLocation = DrawHelper.ArcTo(graphicsPath, 4360.0, 5918.0, -16496525.0, 8804134.0, currentPathEndLocation);
			currentPathEndLocation = DrawHelper.ArcTo(graphicsPath, 4345.0, 5945.0, -14809710.0, 9151131.0, currentPathEndLocation);
			DrawHelper.Close(graphicsPath);
			@class.List_0.Add(graphicsPath);
			array[0] = @class;
			graphicsPath = DrawHelper.PathBegin();
			@class = new Class175(bool_1: true, Enum32.const_5);
			currentPathEndLocation = DrawHelper.MoveTo(this.double_42, this.double_14);
			currentPathEndLocation = DrawHelper.ArcTo(graphicsPath, this.double_41, this.double_41, 0.0, 21600000.0, currentPathEndLocation);
			DrawHelper.Close(graphicsPath);
			@class.List_0.Add(graphicsPath);
			array[1] = @class;
			graphicsPath = DrawHelper.PathBegin();
			@class = new Class175(bool_1: true, Enum32.const_5);
			currentPathEndLocation = DrawHelper.MoveTo(this.double_43, this.double_32);
			currentPathEndLocation = DrawHelper.ArcTo(graphicsPath, this.double_40, this.double_40, 0.0, 21600000.0, currentPathEndLocation);
			DrawHelper.Close(graphicsPath);
			@class.List_0.Add(graphicsPath);
			array[2] = @class;
			graphicsPath = DrawHelper.PathBegin();
			@class = new Class175(bool_1: true, Enum32.const_5);
			currentPathEndLocation = DrawHelper.MoveTo(this.double_44, this.double_39);
			currentPathEndLocation = DrawHelper.ArcTo(graphicsPath, this.double_27, this.double_27, 0.0, 21600000.0, currentPathEndLocation);
			DrawHelper.Close(graphicsPath);
			@class.List_0.Add(graphicsPath);
			array[3] = @class;
			graphicsPath = DrawHelper.PathBegin();
			@class = new Class175(bool_1: true, Enum32.const_4);
			currentPathEndLocation = DrawHelper.MoveTo(4693.0, 26177.0);
			currentPathEndLocation = DrawHelper.ArcTo(graphicsPath, 4345.0, 5945.0, 5204520.0, 1585770.0, currentPathEndLocation);
			currentPathEndLocation = DrawHelper.MoveTo(6928.0, 34899.0, graphicsPath, @class, out graphicsPath);
			currentPathEndLocation = DrawHelper.ArcTo(graphicsPath, 4360.0, 5918.0, 4416628.0, 686848.0, currentPathEndLocation);
			currentPathEndLocation = DrawHelper.MoveTo(16478.0, 39090.0, graphicsPath, @class, out graphicsPath);
			currentPathEndLocation = DrawHelper.ArcTo(graphicsPath, 6752.0, 9215.0, 8257449.0, 844866.0, currentPathEndLocation);
			currentPathEndLocation = DrawHelper.MoveTo(28827.0, 34751.0, graphicsPath, @class, out graphicsPath);
			currentPathEndLocation = DrawHelper.ArcTo(graphicsPath, 6752.0, 9215.0, 387196.0, 959901.0, currentPathEndLocation);
			currentPathEndLocation = DrawHelper.MoveTo(34129.0, 22954.0, graphicsPath, @class, out graphicsPath);
			currentPathEndLocation = DrawHelper.ArcTo(graphicsPath, 5785.0, 7867.0, -4217541.0, 4255042.0, currentPathEndLocation);
			currentPathEndLocation = DrawHelper.MoveTo(41798.0, 15354.0, graphicsPath, @class, out graphicsPath);
			currentPathEndLocation = DrawHelper.ArcTo(graphicsPath, 5333.0, 7273.0, 1819082.0, 1665090.0, currentPathEndLocation);
			currentPathEndLocation = DrawHelper.MoveTo(38324.0, 5426.0, graphicsPath, @class, out graphicsPath);
			currentPathEndLocation = DrawHelper.ArcTo(graphicsPath, 4857.0, 6595.0, -824660.0, 891534.0, currentPathEndLocation);
			currentPathEndLocation = DrawHelper.MoveTo(29078.0, 3952.0, graphicsPath, @class, out graphicsPath);
			currentPathEndLocation = DrawHelper.ArcTo(graphicsPath, 4857.0, 6595.0, -8950887.0, 1091722.0, currentPathEndLocation);
			currentPathEndLocation = DrawHelper.MoveTo(22141.0, 4720.0, graphicsPath, @class, out graphicsPath);
			currentPathEndLocation = DrawHelper.ArcTo(graphicsPath, 4365.0, 5945.0, -9809656.0, 1061181.0, currentPathEndLocation);
			currentPathEndLocation = DrawHelper.MoveTo(14000.0, 5192.0, graphicsPath, @class, out graphicsPath);
			currentPathEndLocation = DrawHelper.ArcTo(graphicsPath, 6753.0, 9190.0, -4002417.0, 739161.0, currentPathEndLocation);
			currentPathEndLocation = DrawHelper.MoveTo(4127.0, 15789.0, graphicsPath, @class, out graphicsPath);
			currentPathEndLocation = DrawHelper.ArcTo(graphicsPath, 6753.0, 9190.0, 9459261.0, 711490.0, currentPathEndLocation);
			@class.List_0.Add(graphicsPath);
			array[4] = @class;
			base.shape.Class183_0.Class175_0 = array;
		}
	}
}
