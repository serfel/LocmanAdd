using System.Drawing.Drawing2D;
using ns17;
using TXTextControl.Drawing;

namespace ns18
{
	internal class Class243 : ShapeObject
	{
		private double double_11;

		private double double_12;

		private double double_13;

		private double double_14;

		private double double_15;

		private double double_16;

		private double double_17;

		private double double_18;

		private double double_19;

		private double double_20;

		public Class243(Shape shape_0)
		{
			base.shape = shape_0;
			base.shape.Class174_0.Class172_0.Clear();
			base.adj = Helper.FmlaLiteralValue(25000.0);
			base.SetLoadedAvLstValues(base.shape);
		}

		internal override void CreateGraphicsPaths()
		{
			base.CreateBaseVariables(base.shape);
			this.double_11 = Helper.FmlaPinTo(0.0, base.adj, 50000.0);
			this.double_12 = Helper.FmlaMultiplyDivide(base.double_6, this.double_11, 100000.0);
			this.double_13 = Helper.FmlaAddSubtract(base.wd2, 0.0, this.double_12);
			this.double_14 = Helper.FmlaAddSubtract(base.hd2, 0.0, this.double_12);
			this.double_15 = Helper.FmlaCosine(base.wd2, 2700000.0);
			this.double_16 = Helper.FmlaSine(base.hd2, 2700000.0);
			this.double_17 = Helper.FmlaAddSubtract(base.double_2, 0.0, this.double_15);
			this.double_18 = Helper.FmlaAddSubtract(base.double_2, this.double_15, 0.0);
			this.double_19 = Helper.FmlaAddSubtract(base.double_7, 0.0, this.double_16);
			this.double_20 = Helper.FmlaAddSubtract(base.double_7, this.double_16, 0.0);
			if (base.shape.Class174_0.Class172_0.Count == 0)
			{
				double num = ((base.shape.Class174_0.Dictionary_0 == null || !base.shape.Class174_0.Dictionary_0.ContainsKey("adj")) ? 25000.0 : base.adj);
				AdjustObject adjustObject = new Class169(new Class177(this.double_12 / 12700.0, base.double_7 / 12700.0, bool_1: false), "Adj", 0.0, 50000.0, num, base.shape, bool_0: false);
				adjustObject.DefaultValue = 25000.0;
				base.shape.Class174_0.Class172_0.method_0(adjustObject);
			}
			else
			{
				base.shape.Class174_0.Class172_0[0].AdjustRectangle.Class178_0.Class177_1 = new Class177(this.double_12 / 12700.0, base.double_7 / 12700.0, bool_1: false);
			}
			base.shape.Class174_0.Dictionary_0 = null;
			Class175[] array = new Class175[1];
			GraphicsPath graphicsPath = DrawHelper.PathBegin();
			Class175 @class = new Class175(bool_1: true, Enum32.const_5);
			Class177 currentPathEndLocation = DrawHelper.MoveTo(base.double_3, base.double_7);
			currentPathEndLocation = DrawHelper.ArcTo(graphicsPath, base.wd2, base.hd2, base.cd2, base.cd4, currentPathEndLocation);
			currentPathEndLocation = DrawHelper.ArcTo(graphicsPath, base.wd2, base.hd2, base._3cd4, base.cd4, currentPathEndLocation);
			currentPathEndLocation = DrawHelper.ArcTo(graphicsPath, base.wd2, base.hd2, 0.0, base.cd4, currentPathEndLocation);
			currentPathEndLocation = DrawHelper.ArcTo(graphicsPath, base.wd2, base.hd2, base.cd4, base.cd4, currentPathEndLocation);
			DrawHelper.Close(graphicsPath);
			currentPathEndLocation = DrawHelper.MoveTo(this.double_12, base.double_7);
			currentPathEndLocation = DrawHelper.ArcTo(graphicsPath, this.double_13, this.double_14, base.cd2, -5400000.0, currentPathEndLocation);
			currentPathEndLocation = DrawHelper.ArcTo(graphicsPath, this.double_13, this.double_14, base.cd4, -5400000.0, currentPathEndLocation);
			currentPathEndLocation = DrawHelper.ArcTo(graphicsPath, this.double_13, this.double_14, 0.0, -5400000.0, currentPathEndLocation);
			currentPathEndLocation = DrawHelper.ArcTo(graphicsPath, this.double_13, this.double_14, base._3cd4, -5400000.0, currentPathEndLocation);
			DrawHelper.Close(graphicsPath);
			@class.List_0.Add(graphicsPath);
			array[0] = @class;
			base.shape.Class183_0.Class175_0 = array;
		}
	}
}
