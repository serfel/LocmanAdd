using System.Drawing.Drawing2D;
using ns17;
using TXTextControl.Drawing;

namespace ns18
{
	internal class Class278 : ShapeObject
	{
		private double double_11;

		private double double_12;

		private double double_13;

		private double double_14;

		public Class278(Shape shape_0)
		{
			base.shape = shape_0;
			base.shape.Class174_0.Class172_0.Clear();
		}

		internal override void CreateGraphicsPaths()
		{
			base.CreateBaseVariables(base.shape);
			this.double_11 = Helper.FmlaMultiplyDivide(base.double_8, 1018.0, 21600.0);
			this.double_12 = Helper.FmlaMultiplyDivide(base.double_8, 20582.0, 21600.0);
			this.double_13 = Helper.FmlaMultiplyDivide(base.double_1, 3163.0, 21600.0);
			this.double_14 = Helper.FmlaMultiplyDivide(base.double_1, 18437.0, 21600.0);
			Class175[] array = new Class175[1];
			GraphicsPath graphicsPath = DrawHelper.PathBegin();
			Class175 @class = new Class175(bool_1: true, Enum32.const_5);
			Class177 class2 = DrawHelper.MoveTo(3475.0, 0.0);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, 18125.0, 0.0);
			class2 = DrawHelper.ArcTo(graphicsPath, 3475.0, 10800.0, base._3cd4, base.cd2, class2);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, 3475.0, 21600.0);
			class2 = DrawHelper.ArcTo(graphicsPath, 3475.0, 10800.0, base.cd4, base.cd2, class2);
			DrawHelper.Close(graphicsPath);
			@class.List_0.Add(graphicsPath);
			array[0] = @class;
			base.shape.Class183_0.Class175_0 = array;
		}
	}
}
