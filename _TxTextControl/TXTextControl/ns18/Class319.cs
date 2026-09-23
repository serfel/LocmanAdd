using System.Drawing.Drawing2D;
using ns17;
using TXTextControl.Drawing;

namespace ns18
{
	internal class Class319 : ShapeObject
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

		private double double_31;

		private double double_32;

		private double double_33;

		public Class319(Shape shape_0)
		{
			base.shape = shape_0;
			base.shape.Class174_0.Class172_0.Clear();
			base.adj1 = Helper.FmlaLiteralValue(0.0);
			base.adj2 = Helper.FmlaLiteralValue(16200000.0);
			base.SetLoadedAvLstValues(base.shape);
		}

		internal override void CreateGraphicsPaths()
		{
			base.CreateBaseVariables(base.shape);
			this.double_11 = Helper.FmlaPinTo(0.0, base.adj1, 21599999.0);
			this.double_12 = Helper.FmlaPinTo(0.0, base.adj2, 21599999.0);
			this.double_13 = Helper.FmlaAddSubtract(this.double_12, 0.0, this.double_11);
			this.double_14 = Helper.FmlaAddSubtract(this.double_13, 21600000.0, 0.0);
			this.double_15 = Helper.FmlaIfElse(this.double_13, this.double_13, this.double_14);
			this.double_16 = Helper.FmlaSine(base.wd2, this.double_11);
			this.double_17 = Helper.FmlaCosine(base.hd2, this.double_11);
			this.double_18 = Helper.FmlaCosineArcTan(base.wd2, this.double_17, this.double_16);
			this.double_19 = Helper.FmlaSineArcTan(base.hd2, this.double_17, this.double_16);
			this.double_20 = Helper.FmlaAddSubtract(base.double_2, this.double_18, 0.0);
			this.double_21 = Helper.FmlaAddSubtract(base.double_7, this.double_19, 0.0);
			this.double_22 = Helper.FmlaSine(base.wd2, this.double_12);
			this.double_23 = Helper.FmlaCosine(base.hd2, this.double_12);
			this.double_24 = Helper.FmlaCosineArcTan(base.wd2, this.double_23, this.double_22);
			this.double_25 = Helper.FmlaSineArcTan(base.hd2, this.double_23, this.double_22);
			this.double_26 = Helper.FmlaAddSubtract(base.double_2, this.double_24, 0.0);
			this.double_27 = Helper.FmlaAddSubtract(base.double_7, this.double_25, 0.0);
			this.double_28 = Helper.FmlaCosine(base.wd2, 2700000.0);
			this.double_29 = Helper.FmlaSine(base.hd2, 2700000.0);
			this.double_30 = Helper.FmlaAddSubtract(base.double_2, 0.0, this.double_28);
			this.double_31 = Helper.FmlaAddSubtract(base.double_2, this.double_28, 0.0);
			this.double_32 = Helper.FmlaAddSubtract(base.double_7, 0.0, this.double_29);
			this.double_33 = Helper.FmlaAddSubtract(base.double_7, this.double_29, 0.0);
			if (base.shape.Class174_0.Class172_0.Count == 0)
			{
				double num = ((base.shape.Class174_0.Dictionary_0 == null || !base.shape.Class174_0.Dictionary_0.ContainsKey("adj1")) ? 0.0 : base.adj1);
				AdjustObject adjustObject = new Class168(new Class177(this.double_20 / 12700.0, this.double_21 / 12700.0, bool_1: false), "Adj1", 0.0, 21599999.0, num, base.shape, bool_0: false);
				adjustObject.DefaultValue = 0.0;
				base.shape.Class174_0.Class172_0.method_0(adjustObject);
				num = ((base.shape.Class174_0.Dictionary_0 == null || !base.shape.Class174_0.Dictionary_0.ContainsKey("adj2")) ? 16200000.0 : base.adj2);
				adjustObject = new Class168(new Class177(this.double_26 / 12700.0, this.double_27 / 12700.0, bool_1: false), "Adj2", 0.0, 21599999.0, num, base.shape, bool_0: false);
				adjustObject.DefaultValue = 16200000.0;
				base.shape.Class174_0.Class172_0.method_0(adjustObject);
			}
			else
			{
				base.shape.Class174_0.Class172_0[0].AdjustRectangle.Class178_0.Class177_1 = new Class177(this.double_20 / 12700.0, this.double_21 / 12700.0, bool_1: false);
				base.shape.Class174_0.Class172_0[1].AdjustRectangle.Class178_0.Class177_1 = new Class177(this.double_26 / 12700.0, this.double_27 / 12700.0, bool_1: false);
			}
			base.shape.Class174_0.Dictionary_0 = null;
			Class175[] array = new Class175[1];
			GraphicsPath graphicsPath = DrawHelper.PathBegin();
			Class175 @class = new Class175(bool_1: true, Enum32.const_5);
			Class177 currentPathEndLocation = DrawHelper.MoveTo(this.double_20, this.double_21);
			currentPathEndLocation = DrawHelper.ArcTo(graphicsPath, base.wd2, base.hd2, this.double_11, this.double_15, currentPathEndLocation);
			currentPathEndLocation = DrawHelper.LnTo(graphicsPath, currentPathEndLocation.Double_2, currentPathEndLocation.Double_3, base.double_2, base.double_7);
			DrawHelper.Close(graphicsPath);
			@class.List_0.Add(graphicsPath);
			array[0] = @class;
			base.shape.Class183_0.Class175_0 = array;
		}
	}
}
