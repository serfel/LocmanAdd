using System.Drawing.Drawing2D;
using ns17;
using TXTextControl.Drawing;

namespace ns18
{
	internal class Class303 : ShapeObject
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

		public Class303(Shape shape_0)
		{
			base.shape = shape_0;
			base.shape.Class174_0.Class172_0.Clear();
		}

		internal override void CreateGraphicsPaths()
		{
			base.CreateBaseVariables(base.shape);
			this.double_11 = Helper.FmlaMultiplyDivide(base.double_8, 5022.0, 21600.0);
			this.double_12 = Helper.FmlaMultiplyDivide(base.double_8, 8472.0, 21600.0);
			this.double_13 = Helper.FmlaMultiplyDivide(base.double_8, 8757.0, 21600.0);
			this.double_14 = Helper.FmlaMultiplyDivide(base.double_8, 10012.0, 21600.0);
			this.double_15 = Helper.FmlaMultiplyDivide(base.double_8, 12860.0, 21600.0);
			this.double_16 = Helper.FmlaMultiplyDivide(base.double_8, 13917.0, 21600.0);
			this.double_17 = Helper.FmlaMultiplyDivide(base.double_8, 16577.0, 21600.0);
			this.double_18 = Helper.FmlaMultiplyDivide(base.double_1, 3890.0, 21600.0);
			this.double_19 = Helper.FmlaMultiplyDivide(base.double_1, 6080.0, 21600.0);
			this.double_20 = Helper.FmlaMultiplyDivide(base.double_1, 7437.0, 21600.0);
			this.double_21 = Helper.FmlaMultiplyDivide(base.double_1, 9705.0, 21600.0);
			this.double_22 = Helper.FmlaMultiplyDivide(base.double_1, 12007.0, 21600.0);
			this.double_23 = Helper.FmlaMultiplyDivide(base.double_1, 14277.0, 21600.0);
			this.double_24 = Helper.FmlaMultiplyDivide(base.double_1, 14915.0, 21600.0);
			Class175[] array = new Class175[1];
			GraphicsPath graphicsPath = DrawHelper.PathBegin();
			Class175 @class = new Class175(bool_1: true, Enum32.const_5);
			Class177 class2 = DrawHelper.MoveTo(8472.0, 0.0);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, 12860.0, 6080.0);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, 11050.0, 6797.0);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, 16577.0, 12007.0);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, 14767.0, 12877.0);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, 21600.0, 21600.0);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, 10012.0, 14915.0);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, 12222.0, 13987.0);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, 5022.0, 9705.0);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, 7602.0, 8382.0);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, 0.0, 3890.0);
			DrawHelper.Close(graphicsPath);
			@class.List_0.Add(graphicsPath);
			array[0] = @class;
			base.shape.Class183_0.Class175_0 = array;
		}
	}
}
