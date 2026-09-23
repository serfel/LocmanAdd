using System.Drawing.Drawing2D;
using ns17;
using TXTextControl.Drawing;

namespace ns18
{
	internal class Class338 : ShapeObject
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

		private double double_21;

		private double double_22;

		private double double_23;

		private double double_24;

		private double double_25;

		private double double_26;

		private double double_27;

		private double double_28;

		private double double_29;

		private double double_30;

		public Class338(Shape shape_0)
		{
			base.shape = shape_0;
			base.shape.Class174_0.Class172_0.Clear();
			base.adj = Helper.FmlaLiteralValue(4653.0);
			base.SetLoadedAvLstValues(base.shape);
		}

		internal override void CreateGraphicsPaths()
		{
			base.CreateBaseVariables(base.shape);
			this.double_11 = Helper.FmlaPinTo(-4653.0, base.adj, 4653.0);
			this.double_12 = Helper.FmlaMultiplyDivide(base.double_8, 4969.0, 21699.0);
			this.double_13 = Helper.FmlaMultiplyDivide(base.double_8, 6215.0, 21600.0);
			this.double_14 = Helper.FmlaMultiplyDivide(base.double_8, 13135.0, 21600.0);
			this.double_15 = Helper.FmlaMultiplyDivide(base.double_8, 16640.0, 21600.0);
			this.double_16 = Helper.FmlaMultiplyDivide(base.double_1, 7570.0, 21600.0);
			this.double_17 = Helper.FmlaMultiplyDivide(base.double_1, 16515.0, 21600.0);
			this.double_18 = Helper.FmlaMultiplyDivide(base.double_1, this.double_11, 100000.0);
			this.double_19 = Helper.FmlaAddSubtract(this.double_17, 0.0, this.double_18);
			this.double_20 = Helper.FmlaAddSubtract(this.double_17, this.double_18, 0.0);
			this.double_21 = Helper.FmlaMultiplyDivide(base.double_1, this.double_11, 50000.0);
			this.double_22 = Helper.FmlaAddSubtract(this.double_20, this.double_21, 0.0);
			this.double_23 = Helper.FmlaCosine(base.wd2, 2700000.0);
			this.double_24 = Helper.FmlaSine(base.hd2, 2700000.0);
			this.double_25 = Helper.FmlaAddSubtract(base.double_2, 0.0, this.double_23);
			this.double_26 = Helper.FmlaAddSubtract(base.double_2, this.double_23, 0.0);
			this.double_27 = Helper.FmlaAddSubtract(base.double_7, 0.0, this.double_24);
			this.double_28 = Helper.FmlaAddSubtract(base.double_7, this.double_24, 0.0);
			this.double_29 = Helper.FmlaMultiplyDivide(base.double_8, 1125.0, 21600.0);
			this.double_30 = Helper.FmlaMultiplyDivide(base.double_1, 1125.0, 21600.0);
			if (base.shape.Class174_0.Class172_0.Count == 0)
			{
				double num = ((base.shape.Class174_0.Dictionary_0 == null || !base.shape.Class174_0.Dictionary_0.ContainsKey("adj")) ? 4653.0 : base.adj);
				AdjustObject adjustObject = new Class171(new Class177(base.double_2 / 12700.0, this.double_20 / 12700.0, bool_1: false), "Adj", -4653.0, 4653.0, num, base.shape, bool_0: false);
				adjustObject.DefaultValue = 4653.0;
				base.shape.Class174_0.Class172_0.method_0(adjustObject);
			}
			else
			{
				base.shape.Class174_0.Class172_0[0].AdjustRectangle.Class178_0.Class177_1 = new Class177(base.double_2 / 12700.0, this.double_20 / 12700.0, bool_1: false);
			}
			base.shape.Class174_0.Dictionary_0 = null;
			Class175[] array = new Class175[4];
			GraphicsPath graphicsPath = DrawHelper.PathBegin();
			Class175 @class = new Class175(bool_1: false, Enum32.const_5);
			Class177 currentPathEndLocation = DrawHelper.MoveTo(base.double_3, base.double_7);
			currentPathEndLocation = DrawHelper.ArcTo(graphicsPath, base.wd2, base.hd2, base.cd2, 21600000.0, currentPathEndLocation);
			DrawHelper.Close(graphicsPath);
			@class.List_0.Add(graphicsPath);
			array[0] = @class;
			graphicsPath = DrawHelper.PathBegin();
			@class = new Class175(bool_1: true, Enum32.const_1);
			currentPathEndLocation = DrawHelper.MoveTo(this.double_13, this.double_16);
			currentPathEndLocation = DrawHelper.ArcTo(graphicsPath, this.double_29, this.double_30, base.cd2, 21600000.0, currentPathEndLocation);
			currentPathEndLocation = DrawHelper.MoveTo(this.double_14, this.double_16);
			currentPathEndLocation = DrawHelper.ArcTo(graphicsPath, this.double_29, this.double_30, base.cd2, 21600000.0, currentPathEndLocation);
			@class.List_0.Add(graphicsPath);
			array[1] = @class;
			graphicsPath = DrawHelper.PathBegin();
			@class = new Class175(bool_1: true, Enum32.const_4);
			currentPathEndLocation = DrawHelper.MoveTo(this.double_12, this.double_19);
			base.ipt2 = new Class177(base.double_2, this.double_22, bool_1: true);
			base.ipt3 = new Class177(this.double_15, this.double_19, bool_1: true);
			currentPathEndLocation = DrawHelper.QuadBezTo(graphicsPath, currentPathEndLocation, base.ipt2, base.ipt3);
			@class.List_0.Add(graphicsPath);
			array[2] = @class;
			graphicsPath = DrawHelper.PathBegin();
			@class = new Class175(bool_1: true, Enum32.const_4);
			currentPathEndLocation = DrawHelper.MoveTo(base.double_3, base.double_7);
			currentPathEndLocation = DrawHelper.ArcTo(graphicsPath, base.wd2, base.hd2, base.cd2, 21600000.0, currentPathEndLocation);
			DrawHelper.Close(graphicsPath);
			@class.List_0.Add(graphicsPath);
			array[3] = @class;
			base.shape.Class183_0.Class175_0 = array;
		}
	}
}
