using System.Drawing.Drawing2D;
using ns17;
using TXTextControl.Drawing;

namespace ns18
{
	internal class Class256 : ShapeObject
	{
		private double double_11;

		private double double_12;

		public Class256(Shape shape_0)
		{
			base.shape = shape_0;
			base.shape.Class174_0.Class172_0.Clear();
		}

		internal override void CreateGraphicsPaths()
		{
			base.CreateBaseVariables(base.shape);
			this.double_11 = Helper.FmlaMultiplyDivide(base.double_1, 17322.0, 21600.0);
			this.double_12 = Helper.FmlaMultiplyDivide(base.double_1, 20172.0, 21600.0);
			Class175[] array = new Class175[1];
			GraphicsPath graphicsPath = DrawHelper.PathBegin();
			Class175 @class = new Class175(bool_1: true, Enum32.const_5);
			Class177 class2 = DrawHelper.MoveTo(0.0, 0.0);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, 21600.0, 0.0);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, 21600.0, 17322.0);
			base.ipt2 = new Class177(10800.0, 17322.0, bool_1: true);
			base.ipt3 = new Class177(10800.0, 23922.0, bool_1: true);
			base.ipt4 = new Class177(0.0, 20172.0, bool_1: true);
			class2 = DrawHelper.CubicBezTo(graphicsPath, class2, base.ipt2, base.ipt3, base.ipt4);
			DrawHelper.Close(graphicsPath);
			@class.List_0.Add(graphicsPath);
			array[0] = @class;
			base.shape.Class183_0.Class175_0 = array;
		}
	}
}
