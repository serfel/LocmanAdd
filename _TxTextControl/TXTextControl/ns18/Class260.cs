using System.Drawing.Drawing2D;
using ns17;
using TXTextControl.Drawing;

namespace ns18
{
	internal class Class260 : ShapeObject
	{
		private double double_11;

		public Class260(Shape shape_0)
		{
			base.shape = shape_0;
			base.shape.Class174_0.Class172_0.Clear();
		}

		internal override void CreateGraphicsPaths()
		{
			base.CreateBaseVariables(base.shape);
			this.double_11 = Helper.FmlaMultiplyDivide(base.double_1, 5.0, 6.0);
			Class175[] array = new Class175[3];
			GraphicsPath graphicsPath = DrawHelper.PathBegin();
			Class175 @class = new Class175(bool_1: false, Enum32.const_5);
			Class177 currentPathEndLocation = DrawHelper.MoveTo(0.0, 12700.0);
			currentPathEndLocation = DrawHelper.ArcTo(graphicsPath, 38100.0, 12700.0, base.cd2, base.cd2, currentPathEndLocation);
			currentPathEndLocation = DrawHelper.LnTo(graphicsPath, currentPathEndLocation.Double_2, currentPathEndLocation.Double_3, 76200.0, 63500.0);
			currentPathEndLocation = DrawHelper.ArcTo(graphicsPath, 38100.0, 12700.0, 0.0, base.cd2, currentPathEndLocation);
			DrawHelper.Close(graphicsPath);
			@class.List_0.Add(graphicsPath);
			array[0] = @class;
			graphicsPath = DrawHelper.PathBegin();
			@class = new Class175(bool_1: true, Enum32.const_4);
			currentPathEndLocation = DrawHelper.MoveTo(76200.0, 12700.0);
			currentPathEndLocation = DrawHelper.ArcTo(graphicsPath, 38100.0, 12700.0, 0.0, base.cd2, currentPathEndLocation);
			@class.List_0.Add(graphicsPath);
			array[1] = @class;
			graphicsPath = DrawHelper.PathBegin();
			@class = new Class175(bool_1: true, Enum32.const_4);
			currentPathEndLocation = DrawHelper.MoveTo(0.0, 12700.0);
			currentPathEndLocation = DrawHelper.ArcTo(graphicsPath, 38100.0, 12700.0, base.cd2, base.cd2, currentPathEndLocation);
			currentPathEndLocation = DrawHelper.LnTo(graphicsPath, currentPathEndLocation.Double_2, currentPathEndLocation.Double_3, 76200.0, 63500.0);
			currentPathEndLocation = DrawHelper.ArcTo(graphicsPath, 38100.0, 12700.0, 0.0, base.cd2, currentPathEndLocation);
			DrawHelper.Close(graphicsPath);
			@class.List_0.Add(graphicsPath);
			array[2] = @class;
			base.shape.Class183_0.Class175_0 = array;
		}
	}
}
