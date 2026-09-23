using System.Drawing.Drawing2D;
using ns17;
using TXTextControl.Drawing;

namespace ns18
{
	internal class Class322 : ShapeObject
	{
		private double double_11;

		private double double_12;

		private double double_13;

		private double double_14;

		public Class322(Shape shape_0)
		{
			base.shape = shape_0;
			base.shape.Class174_0.Class172_0.Clear();
		}

		internal override void CreateGraphicsPaths()
		{
			base.CreateBaseVariables(base.shape);
			this.double_11 = Helper.FmlaModulo(base.double_8, base.double_1, 0.0);
			this.double_12 = Helper.FmlaMultiplyDivide(1.0, this.double_11, 20.0);
			this.double_13 = Helper.FmlaAddSubtract(0.0, base.double_0, this.double_12);
			this.double_14 = Helper.FmlaAddSubtract(0.0, base.double_5, this.double_12);
			Class175[] array = new Class175[4];
			GraphicsPath graphicsPath = DrawHelper.PathBegin();
			Class175 @class = new Class175(bool_1: true, Enum32.const_5);
			Class177 class2 = DrawHelper.MoveTo(base.double_3, base.t);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_12, base.t);
			class2 = DrawHelper.ArcTo(graphicsPath, this.double_12, this.double_12, 0.0, base.cd4, class2);
			DrawHelper.Close(graphicsPath);
			@class.List_0.Add(graphicsPath);
			array[0] = @class;
			graphicsPath = DrawHelper.PathBegin();
			@class = new Class175(bool_1: true, Enum32.const_5);
			class2 = DrawHelper.MoveTo(base.double_3, this.double_13);
			class2 = DrawHelper.ArcTo(graphicsPath, this.double_12, this.double_12, base._3cd4, base.cd4, class2);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, base.double_3, base.double_0);
			DrawHelper.Close(graphicsPath);
			@class.List_0.Add(graphicsPath);
			array[1] = @class;
			graphicsPath = DrawHelper.PathBegin();
			@class = new Class175(bool_1: true, Enum32.const_5);
			class2 = DrawHelper.MoveTo(base.double_5, base.t);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, base.double_5, this.double_12);
			class2 = DrawHelper.ArcTo(graphicsPath, this.double_12, this.double_12, base.cd4, base.cd4, class2);
			DrawHelper.Close(graphicsPath);
			@class.List_0.Add(graphicsPath);
			array[2] = @class;
			graphicsPath = DrawHelper.PathBegin();
			@class = new Class175(bool_1: true, Enum32.const_5);
			class2 = DrawHelper.MoveTo(this.double_14, base.double_0);
			class2 = DrawHelper.ArcTo(graphicsPath, this.double_12, this.double_12, base.cd2, base.cd4, class2);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, base.double_5, base.double_0);
			DrawHelper.Close(graphicsPath);
			@class.List_0.Add(graphicsPath);
			array[3] = @class;
			base.shape.Class183_0.Class175_0 = array;
		}
	}
}
