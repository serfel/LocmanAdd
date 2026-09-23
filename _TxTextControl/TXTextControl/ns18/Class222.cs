using System.Drawing.Drawing2D;
using ns17;
using TXTextControl.Drawing;

namespace ns18
{
	internal class Class222 : ShapeObject
	{
		public Class222(Shape shape_0)
		{
			base.shape = shape_0;
			base.shape.Class174_0.Class172_0.Clear();
		}

		internal override void CreateGraphicsPaths()
		{
			base.CreateBaseVariables(base.shape);
			Class175[] array = new Class175[2];
			GraphicsPath newGraphicPath = DrawHelper.PathBegin();
			Class175 @class = new Class175(bool_1: true, Enum32.const_4);
			Class177 class2 = DrawHelper.MoveTo(0.0, 0.0);
			class2 = DrawHelper.LnTo(newGraphicPath, class2.Double_2, class2.Double_3, 127000.0, 127000.0);
			class2 = DrawHelper.MoveTo(0.0, 127000.0, newGraphicPath, @class, out newGraphicPath);
			class2 = DrawHelper.LnTo(newGraphicPath, class2.Double_2, class2.Double_3, 127000.0, 0.0);
			@class.List_0.Add(newGraphicPath);
			array[0] = @class;
			newGraphicPath = DrawHelper.PathBegin();
			@class = new Class175(bool_1: false, Enum32.const_5);
			class2 = DrawHelper.MoveTo(0.0, 0.0);
			class2 = DrawHelper.LnTo(newGraphicPath, class2.Double_2, class2.Double_3, 0.0, 127000.0);
			class2 = DrawHelper.LnTo(newGraphicPath, class2.Double_2, class2.Double_3, 127000.0, 127000.0);
			class2 = DrawHelper.LnTo(newGraphicPath, class2.Double_2, class2.Double_3, 127000.0, 0.0);
			DrawHelper.Close(newGraphicPath);
			@class.List_0.Add(newGraphicPath);
			array[1] = @class;
			base.shape.Class183_0.Class175_0 = array;
		}
	}
}
