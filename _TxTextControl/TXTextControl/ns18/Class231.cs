using System.Drawing.Drawing2D;
using ns17;
using TXTextControl.Drawing;

namespace ns18
{
	internal class Class231 : ShapeObject
	{
		public Class231(Shape shape_0)
		{
			base.shape = shape_0;
			base.shape.Class174_0.Class172_0.Clear();
		}

		internal override void CreateGraphicsPaths()
		{
			base.CreateBaseVariables(base.shape);
			Class175[] array = new Class175[1];
			GraphicsPath graphicsPath = DrawHelper.PathBegin();
			Class175 @class = new Class175(bool_1: true, Enum32.const_4);
			Class177 point = DrawHelper.MoveTo(base.double_3, base.t);
			base.ipt2 = new Class177(base.wd2, base.t, bool_1: true);
			base.ipt3 = new Class177(base.double_5, base.hd2, bool_1: true);
			base.ipt4 = new Class177(base.double_5, base.double_0, bool_1: true);
			point = DrawHelper.CubicBezTo(graphicsPath, point, base.ipt2, base.ipt3, base.ipt4);
			@class.List_0.Add(graphicsPath);
			array[0] = @class;
			base.shape.Class183_0.Class175_0 = array;
		}
	}
}
