using System.Drawing.Drawing2D;
using ns17;
using TXTextControl.Drawing;

namespace ns18
{
	internal class Class226 : ShapeObject
	{
		private double double_11;

		private double double_12;

		private double double_13;

		private double double_14;

		private double double_15;

		private double double_16;

		private double double_17;

		private double double_18;

		public Class226(Shape shape_0)
		{
			base.shape = shape_0;
			base.shape.Class174_0.Class172_0.Clear();
		}

		internal override void CreateGraphicsPaths()
		{
			base.CreateBaseVariables(base.shape);
			this.double_11 = Helper.FmlaMultiplyDivide(base.double_8, 2977.0, 21600.0);
			this.double_12 = Helper.FmlaMultiplyDivide(base.double_1, 3262.0, 21600.0);
			this.double_13 = Helper.FmlaMultiplyDivide(base.double_8, 17087.0, 21600.0);
			this.double_14 = Helper.FmlaMultiplyDivide(base.double_1, 17337.0, 21600.0);
			this.double_15 = Helper.FmlaMultiplyDivide(base.double_8, 67.0, 21600.0);
			this.double_16 = Helper.FmlaMultiplyDivide(base.double_1, 21577.0, 21600.0);
			this.double_17 = Helper.FmlaMultiplyDivide(base.double_8, 21582.0, 21600.0);
			this.double_18 = Helper.FmlaMultiplyDivide(base.double_1, 1235.0, 21600.0);
			Class175[] array = new Class175[2];
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
			array[1] = @class;
			base.shape.Class183_0.Class175_0 = array;
		}
	}
}
