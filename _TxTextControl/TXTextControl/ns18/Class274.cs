using System.Drawing.Drawing2D;
using ns17;
using TXTextControl.Drawing;

namespace ns18
{
	internal class Class274 : ShapeObject
	{
		public Class274(Shape shape_0)
		{
			base.shape = shape_0;
			base.shape.Class174_0.Class172_0.Clear();
		}

		internal override void CreateGraphicsPaths()
		{
			base.CreateBaseVariables(base.shape);
			Class175[] array = new Class175[1];
			GraphicsPath graphicsPath = DrawHelper.PathBegin();
			Class175 @class = new Class175(bool_1: true, Enum32.const_5);
			Class177 class2 = DrawHelper.MoveTo(0.0, 12700.0);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, 12700.0, 0.0);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, 63500.0, 0.0);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, 63500.0, 63500.0);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, 0.0, 63500.0);
			DrawHelper.Close(graphicsPath);
			@class.List_0.Add(graphicsPath);
			array[0] = @class;
			base.shape.Class183_0.Class175_0 = array;
		}
	}
}
