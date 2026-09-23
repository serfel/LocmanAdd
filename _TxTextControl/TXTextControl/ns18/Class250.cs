using System.Drawing.Drawing2D;
using ns17;
using TXTextControl.Drawing;

namespace ns18
{
	internal class Class250 : ShapeObject
	{
		private double double_11;

		private double double_12;

		private double double_13;

		private double double_14;

		private double double_15;

		public Class250(Shape shape_0)
		{
			base.shape = shape_0;
			base.shape.Class174_0.Class172_0.Clear();
		}

		internal override void CreateGraphicsPaths()
		{
			base.CreateBaseVariables(base.shape);
			this.double_11 = Helper.FmlaAddSubtract(base.double_5, 0.0, base.ssd6);
			this.double_12 = Helper.FmlaAddSubtract(base.double_0, 0.0, base.ssd6);
			this.double_13 = Helper.FmlaMultiplyDivide(base.ssd6, 29289.0, 100000.0);
			this.double_14 = Helper.FmlaAddSubtract(base.double_5, 0.0, this.double_13);
			this.double_15 = Helper.FmlaAddSubtract(base.double_0, 0.0, this.double_13);
			Class175[] array = new Class175[1];
			GraphicsPath graphicsPath = DrawHelper.PathBegin();
			Class175 @class = new Class175(bool_1: true, Enum32.const_5);
			Class177 currentPathEndLocation = DrawHelper.MoveTo(base.double_3, base.ssd6);
			currentPathEndLocation = DrawHelper.ArcTo(graphicsPath, base.ssd6, base.ssd6, base.cd2, base.cd4, currentPathEndLocation);
			currentPathEndLocation = DrawHelper.LnTo(graphicsPath, currentPathEndLocation.Double_2, currentPathEndLocation.Double_3, this.double_11, base.t);
			currentPathEndLocation = DrawHelper.ArcTo(graphicsPath, base.ssd6, base.ssd6, base._3cd4, base.cd4, currentPathEndLocation);
			currentPathEndLocation = DrawHelper.LnTo(graphicsPath, currentPathEndLocation.Double_2, currentPathEndLocation.Double_3, base.double_5, this.double_12);
			currentPathEndLocation = DrawHelper.ArcTo(graphicsPath, base.ssd6, base.ssd6, 0.0, base.cd4, currentPathEndLocation);
			currentPathEndLocation = DrawHelper.LnTo(graphicsPath, currentPathEndLocation.Double_2, currentPathEndLocation.Double_3, base.ssd6, base.double_0);
			currentPathEndLocation = DrawHelper.ArcTo(graphicsPath, base.ssd6, base.ssd6, base.cd4, base.cd4, currentPathEndLocation);
			DrawHelper.Close(graphicsPath);
			@class.List_0.Add(graphicsPath);
			array[0] = @class;
			base.shape.Class183_0.Class175_0 = array;
		}
	}
}
