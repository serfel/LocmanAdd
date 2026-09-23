using System.Drawing.Drawing2D;
using ns17;
using TXTextControl.Drawing;

namespace ns18
{
	internal class Class275 : ShapeObject
	{
		private double double_11;

		private double double_12;

		public Class275(Shape shape_0)
		{
			base.shape = shape_0;
			base.shape.Class174_0.Class172_0.Clear();
		}

		internal override void CreateGraphicsPaths()
		{
			base.CreateBaseVariables(base.shape);
			this.double_11 = Helper.FmlaMultiplyDivide(base.double_1, 9.0, 10.0);
			this.double_12 = Helper.FmlaMultiplyDivide(base.double_1, 4.0, 5.0);
			Class175[] array = new Class175[1];
			GraphicsPath graphicsPath = DrawHelper.PathBegin();
			Class175 @class = new Class175(bool_1: true, Enum32.const_5);
			Class177 currentPathEndLocation = DrawHelper.MoveTo(0.0, 25400.0);
			currentPathEndLocation = DrawHelper.ArcTo(graphicsPath, 63500.0, 25400.0, base.cd2, -10800000.0, currentPathEndLocation);
			currentPathEndLocation = DrawHelper.ArcTo(graphicsPath, 63500.0, 25400.0, base.cd2, base.cd2, currentPathEndLocation);
			currentPathEndLocation = DrawHelper.LnTo(graphicsPath, currentPathEndLocation.Double_2, currentPathEndLocation.Double_3, 254000.0, 228600.0);
			currentPathEndLocation = DrawHelper.ArcTo(graphicsPath, 63500.0, 25400.0, 0.0, -10800000.0, currentPathEndLocation);
			currentPathEndLocation = DrawHelper.ArcTo(graphicsPath, 63500.0, 25400.0, 0.0, base.cd2, currentPathEndLocation);
			DrawHelper.Close(graphicsPath);
			@class.List_0.Add(graphicsPath);
			array[0] = @class;
			base.shape.Class183_0.Class175_0 = array;
		}
	}
}
