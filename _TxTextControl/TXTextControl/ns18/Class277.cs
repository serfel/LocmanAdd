using System.Drawing.Drawing2D;
using ns17;
using TXTextControl.Drawing;

namespace ns18
{
	internal class Class277 : ShapeObject
	{
		private double double_11;

		private double double_12;

		private double double_13;

		private double double_14;

		private double double_15;

		private double double_16;

		public Class277(Shape shape_0)
		{
			base.shape = shape_0;
			base.shape.Class174_0.Class172_0.Clear();
		}

		internal override void CreateGraphicsPaths()
		{
			base.CreateBaseVariables(base.shape);
			this.double_11 = Helper.FmlaCosine(base.wd2, 2700000.0);
			this.double_12 = Helper.FmlaSine(base.hd2, 2700000.0);
			this.double_13 = Helper.FmlaAddSubtract(base.double_2, 0.0, this.double_11);
			this.double_14 = Helper.FmlaAddSubtract(base.double_2, this.double_11, 0.0);
			this.double_15 = Helper.FmlaAddSubtract(base.double_7, 0.0, this.double_12);
			this.double_16 = Helper.FmlaAddSubtract(base.double_7, this.double_12, 0.0);
			Class175[] array = new Class175[3];
			GraphicsPath graphicsPath = DrawHelper.PathBegin();
			Class175 @class = new Class175(bool_1: false, Enum32.const_5);
			Class177 currentPathEndLocation = DrawHelper.MoveTo(base.double_3, base.double_7);
			currentPathEndLocation = DrawHelper.ArcTo(graphicsPath, base.wd2, base.hd2, base.cd2, base.cd4, currentPathEndLocation);
			currentPathEndLocation = DrawHelper.ArcTo(graphicsPath, base.wd2, base.hd2, base._3cd4, base.cd4, currentPathEndLocation);
			currentPathEndLocation = DrawHelper.ArcTo(graphicsPath, base.wd2, base.hd2, 0.0, base.cd4, currentPathEndLocation);
			currentPathEndLocation = DrawHelper.ArcTo(graphicsPath, base.wd2, base.hd2, base.cd4, base.cd4, currentPathEndLocation);
			DrawHelper.Close(graphicsPath);
			@class.List_0.Add(graphicsPath);
			array[0] = @class;
			graphicsPath = DrawHelper.PathBegin();
			@class = new Class175(bool_1: true, Enum32.const_4);
			currentPathEndLocation = DrawHelper.MoveTo(this.double_13, this.double_15);
			currentPathEndLocation = DrawHelper.LnTo(graphicsPath, currentPathEndLocation.Double_2, currentPathEndLocation.Double_3, this.double_14, this.double_16);
			currentPathEndLocation = DrawHelper.MoveTo(this.double_14, this.double_15, graphicsPath, @class, out graphicsPath);
			currentPathEndLocation = DrawHelper.LnTo(graphicsPath, currentPathEndLocation.Double_2, currentPathEndLocation.Double_3, this.double_13, this.double_16);
			@class.List_0.Add(graphicsPath);
			array[1] = @class;
			graphicsPath = DrawHelper.PathBegin();
			@class = new Class175(bool_1: true, Enum32.const_4);
			currentPathEndLocation = DrawHelper.MoveTo(base.double_3, base.double_7);
			currentPathEndLocation = DrawHelper.ArcTo(graphicsPath, base.wd2, base.hd2, base.cd2, base.cd4, currentPathEndLocation);
			currentPathEndLocation = DrawHelper.ArcTo(graphicsPath, base.wd2, base.hd2, base._3cd4, base.cd4, currentPathEndLocation);
			currentPathEndLocation = DrawHelper.ArcTo(graphicsPath, base.wd2, base.hd2, 0.0, base.cd4, currentPathEndLocation);
			currentPathEndLocation = DrawHelper.ArcTo(graphicsPath, base.wd2, base.hd2, base.cd4, base.cd4, currentPathEndLocation);
			DrawHelper.Close(graphicsPath);
			@class.List_0.Add(graphicsPath);
			array[2] = @class;
			base.shape.Class183_0.Class175_0 = array;
		}
	}
}
