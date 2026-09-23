using System.Drawing.Drawing2D;
using ns17;
using TXTextControl.Drawing;

namespace ns18
{
	internal class Class276 : ShapeObject
	{
		private double double_11;

		private double double_12;

		public Class276(Shape shape_0)
		{
			base.shape = shape_0;
			base.shape.Class174_0.Class172_0.Clear();
		}

		internal override void CreateGraphicsPaths()
		{
			base.CreateBaseVariables(base.shape);
			this.double_11 = Helper.FmlaMultiplyDivide(base.double_8, 3.0, 4.0);
			this.double_12 = Helper.FmlaMultiplyDivide(base.double_1, 3.0, 4.0);
			Class175[] array = new Class175[3];
			GraphicsPath graphicsPath = DrawHelper.PathBegin();
			Class175 @class = new Class175(bool_1: false, Enum32.const_5);
			Class177 class2 = DrawHelper.MoveTo(0.0, 12700.0);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, 12700.0, 0.0);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, 25400.0, 12700.0);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, 12700.0, 25400.0);
			DrawHelper.Close(graphicsPath);
			@class.List_0.Add(graphicsPath);
			array[0] = @class;
			graphicsPath = DrawHelper.PathBegin();
			@class = new Class175(bool_1: true, Enum32.const_4);
			class2 = DrawHelper.MoveTo(0.0, 12700.0);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, 25400.0, 12700.0);
			@class.List_0.Add(graphicsPath);
			array[1] = @class;
			graphicsPath = DrawHelper.PathBegin();
			@class = new Class175(bool_1: true, Enum32.const_4);
			class2 = DrawHelper.MoveTo(0.0, 12700.0);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, 12700.0, 0.0);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, 25400.0, 12700.0);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, 12700.0, 25400.0);
			DrawHelper.Close(graphicsPath);
			@class.List_0.Add(graphicsPath);
			array[2] = @class;
			base.shape.Class183_0.Class175_0 = array;
		}
	}
}
