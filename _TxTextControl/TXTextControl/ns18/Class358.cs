using System.Drawing.Drawing2D;
using ns17;
using TXTextControl.Drawing;

namespace ns18
{
	internal class Class358 : ShapeObject
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

		public Class358(Shape shape_0)
		{
			base.shape = shape_0;
			base.shape.Class174_0.Class172_0.Clear();
			base.adj = Helper.FmlaLiteralValue(100000.0);
			base.SetLoadedAvLstValues(base.shape);
		}

		internal override void CreateGraphicsPaths()
		{
			base.CreateBaseVariables(base.shape);
			this.double_11 = Helper.FmlaPinTo(0.0, base.adj, 200000.0);
			this.double_12 = Helper.FmlaSquareRoot(2.0);
			this.double_13 = Helper.FmlaMultiplyDivide(base.wd2, this.double_12, 1.0);
			this.double_14 = Helper.FmlaMultiplyDivide(base.hd2, this.double_12, 1.0);
			this.double_15 = Helper.FmlaMultiplyDivide(this.double_13, this.double_11, 100000.0);
			this.double_16 = Helper.FmlaMultiplyDivide(this.double_14, this.double_11, 100000.0);
			this.double_17 = Helper.FmlaCosine(this.double_15, 2700000.0);
			this.double_18 = Helper.FmlaSine(this.double_16, 2700000.0);
			this.double_19 = Helper.FmlaAddSubtract(base.double_2, this.double_17, 0.0);
			this.double_20 = Helper.FmlaAddSubtract(base.double_7, 0.0, this.double_18);
			this.double_21 = Helper.FmlaAddDivide(base.double_2, this.double_19, 2.0);
			this.double_22 = Helper.FmlaAddDivide(base.double_7, this.double_20, 2.0);
			this.double_23 = Helper.FmlaCosine(base.wd2, 2700000.0);
			this.double_24 = Helper.FmlaSine(base.hd2, 2700000.0);
			this.double_25 = Helper.FmlaAddSubtract(base.double_2, 0.0, this.double_23);
			this.double_26 = Helper.FmlaAddSubtract(base.double_2, this.double_23, 0.0);
			this.double_27 = Helper.FmlaAddSubtract(base.double_7, 0.0, this.double_24);
			this.double_28 = Helper.FmlaAddSubtract(base.double_7, this.double_24, 0.0);
			if (base.shape.Class174_0.Class172_0.Count == 0)
			{
				double num = ((base.shape.Class174_0.Dictionary_0 == null || !base.shape.Class174_0.Dictionary_0.ContainsKey("adj")) ? 100000.0 : base.adj);
				AdjustObject adjustObject = new Class170(new Class177(this.double_19 / 12700.0, base.t / 12700.0, bool_1: false), "Adj", 0.0, 200000.0, num, base.shape, bool_0: false);
				adjustObject.DefaultValue = 100000.0;
				base.shape.Class174_0.Class172_0.method_0(adjustObject);
			}
			else
			{
				base.shape.Class174_0.Class172_0[0].AdjustRectangle.Class178_0.Class177_1 = new Class177(this.double_19 / 12700.0, base.t / 12700.0, bool_1: false);
			}
			base.shape.Class174_0.Dictionary_0 = null;
			Class175[] array = new Class175[1];
			GraphicsPath graphicsPath = DrawHelper.PathBegin();
			Class175 @class = new Class175(bool_1: true, Enum32.const_5);
			Class177 currentPathEndLocation = DrawHelper.MoveTo(base.double_3, base.double_7);
			currentPathEndLocation = DrawHelper.ArcTo(graphicsPath, base.wd2, base.hd2, base.cd2, base.cd4, currentPathEndLocation);
			base.ipt2 = new Class177(this.double_21, base.t, bool_1: true);
			base.ipt3 = new Class177(this.double_19, this.double_20, bool_1: true);
			currentPathEndLocation = DrawHelper.QuadBezTo(graphicsPath, currentPathEndLocation, base.ipt2, base.ipt3);
			base.ipt2 = new Class177(base.double_5, this.double_22, bool_1: true);
			base.ipt3 = new Class177(base.double_5, base.double_7, bool_1: true);
			currentPathEndLocation = DrawHelper.QuadBezTo(graphicsPath, currentPathEndLocation, base.ipt2, base.ipt3);
			currentPathEndLocation = DrawHelper.ArcTo(graphicsPath, base.wd2, base.hd2, 0.0, base.cd4, currentPathEndLocation);
			currentPathEndLocation = DrawHelper.ArcTo(graphicsPath, base.wd2, base.hd2, base.cd4, base.cd4, currentPathEndLocation);
			DrawHelper.Close(graphicsPath);
			@class.List_0.Add(graphicsPath);
			array[0] = @class;
			base.shape.Class183_0.Class175_0 = array;
		}
	}
}
