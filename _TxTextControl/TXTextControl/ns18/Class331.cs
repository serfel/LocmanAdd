using System.Drawing.Drawing2D;
using ns17;
using TXTextControl.Drawing;

namespace ns18
{
	internal class Class331 : ShapeObject
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

		public Class331(Shape shape_0)
		{
			base.shape = shape_0;
			base.shape.Class174_0.Class172_0.Clear();
			base.adj1 = Helper.FmlaLiteralValue(8333.0);
			base.adj2 = Helper.FmlaLiteralValue(50000.0);
			base.SetLoadedAvLstValues(base.shape);
		}

		internal override void CreateGraphicsPaths()
		{
			base.CreateBaseVariables(base.shape);
			this.double_11 = Helper.FmlaPinTo(0.0, base.adj2, 100000.0);
			this.double_12 = Helper.FmlaAddSubtract(100000.0, 0.0, this.double_11);
			this.double_13 = Helper.FmlaMinimumValue(this.double_12, this.double_11);
			this.double_14 = Helper.FmlaMultiplyDivide(this.double_13, 1.0, 2.0);
			this.double_15 = Helper.FmlaMultiplyDivide(this.double_14, base.double_1, base.double_6);
			this.double_16 = Helper.FmlaPinTo(0.0, base.adj1, this.double_15);
			this.double_17 = Helper.FmlaMultiplyDivide(base.double_6, this.double_16, 100000.0);
			this.double_18 = Helper.FmlaMultiplyDivide(base.double_1, this.double_11, 100000.0);
			this.double_19 = Helper.FmlaAddSubtract(this.double_18, 0.0, this.double_17);
			this.double_20 = Helper.FmlaAddSubtract(base.double_0, 0.0, this.double_17);
			this.double_21 = Helper.FmlaCosine(base.wd2, 2700000.0);
			this.double_22 = Helper.FmlaSine(this.double_17, 2700000.0);
			this.double_23 = Helper.FmlaAddSubtract(base.double_3, this.double_21, 0.0);
			this.double_24 = Helper.FmlaAddSubtract(this.double_17, 0.0, this.double_22);
			this.double_25 = Helper.FmlaAddSubtract(base.double_0, this.double_22, this.double_17);
			if (base.shape.Class174_0.Class172_0.Count == 0)
			{
				double num = ((base.shape.Class174_0.Dictionary_0 == null || !base.shape.Class174_0.Dictionary_0.ContainsKey("adj1")) ? 8333.0 : base.adj1);
				AdjustObject adjustObject = new Class171(new Class177(base.double_2 / 12700.0, this.double_17 / 12700.0, bool_1: false), "Adj1", 0.0, this.double_15, num, base.shape, bool_0: false);
				adjustObject.DefaultValue = 8333.0;
				base.shape.Class174_0.Class172_0.method_0(adjustObject);
				num = ((base.shape.Class174_0.Dictionary_0 == null || !base.shape.Class174_0.Dictionary_0.ContainsKey("adj2")) ? 50000.0 : base.adj2);
				adjustObject = new Class171(new Class177(base.double_5 / 12700.0, this.double_18 / 12700.0, bool_1: false), "Adj2", 0.0, 100000.0, num, base.shape, bool_0: false);
				adjustObject.DefaultValue = 50000.0;
				base.shape.Class174_0.Class172_0.method_0(adjustObject);
			}
			else
			{
				base.shape.Class174_0.Class172_0[0].AdjustRectangle.Class178_0.Class177_1 = new Class177(base.double_2 / 12700.0, this.double_17 / 12700.0, bool_1: false);
				base.shape.Class174_0.Class172_0[1].AdjustRectangle.Class178_0.Class177_1 = new Class177(base.double_5 / 12700.0, this.double_18 / 12700.0, bool_1: false);
			}
			base.shape.Class174_0.Dictionary_0 = null;
			Class175[] array = new Class175[2];
			GraphicsPath graphicsPath = DrawHelper.PathBegin();
			Class175 @class = new Class175(bool_1: false, Enum32.const_5);
			Class177 currentPathEndLocation = DrawHelper.MoveTo(base.double_3, base.t);
			currentPathEndLocation = DrawHelper.ArcTo(graphicsPath, base.wd2, this.double_17, base._3cd4, base.cd4, currentPathEndLocation);
			currentPathEndLocation = DrawHelper.LnTo(graphicsPath, currentPathEndLocation.Double_2, currentPathEndLocation.Double_3, base.double_2, this.double_19);
			currentPathEndLocation = DrawHelper.ArcTo(graphicsPath, base.wd2, this.double_17, base.cd2, -5400000.0, currentPathEndLocation);
			currentPathEndLocation = DrawHelper.ArcTo(graphicsPath, base.wd2, this.double_17, base._3cd4, -5400000.0, currentPathEndLocation);
			currentPathEndLocation = DrawHelper.LnTo(graphicsPath, currentPathEndLocation.Double_2, currentPathEndLocation.Double_3, base.double_2, this.double_20);
			currentPathEndLocation = DrawHelper.ArcTo(graphicsPath, base.wd2, this.double_17, 0.0, base.cd4, currentPathEndLocation);
			DrawHelper.Close(graphicsPath);
			@class.List_0.Add(graphicsPath);
			array[0] = @class;
			graphicsPath = DrawHelper.PathBegin();
			@class = new Class175(bool_1: true, Enum32.const_4);
			currentPathEndLocation = DrawHelper.MoveTo(base.double_3, base.t);
			currentPathEndLocation = DrawHelper.ArcTo(graphicsPath, base.wd2, this.double_17, base._3cd4, base.cd4, currentPathEndLocation);
			currentPathEndLocation = DrawHelper.LnTo(graphicsPath, currentPathEndLocation.Double_2, currentPathEndLocation.Double_3, base.double_2, this.double_19);
			currentPathEndLocation = DrawHelper.ArcTo(graphicsPath, base.wd2, this.double_17, base.cd2, -5400000.0, currentPathEndLocation);
			currentPathEndLocation = DrawHelper.ArcTo(graphicsPath, base.wd2, this.double_17, base._3cd4, -5400000.0, currentPathEndLocation);
			currentPathEndLocation = DrawHelper.LnTo(graphicsPath, currentPathEndLocation.Double_2, currentPathEndLocation.Double_3, base.double_2, this.double_20);
			currentPathEndLocation = DrawHelper.ArcTo(graphicsPath, base.wd2, this.double_17, 0.0, base.cd4, currentPathEndLocation);
			@class.List_0.Add(graphicsPath);
			array[1] = @class;
			base.shape.Class183_0.Class175_0 = array;
		}
	}
}
