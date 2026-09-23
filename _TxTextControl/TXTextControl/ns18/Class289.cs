using System.Drawing.Drawing2D;
using ns17;
using TXTextControl.Drawing;

namespace ns18
{
	internal class Class289 : ShapeObject
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

		public Class289(Shape shape_0)
		{
			base.shape = shape_0;
			base.shape.Class174_0.Class172_0.Clear();
			base.adj = Helper.FmlaLiteralValue(12500.0);
			base.SetLoadedAvLstValues(base.shape);
		}

		internal override void CreateGraphicsPaths()
		{
			base.CreateBaseVariables(base.shape);
			this.double_11 = Helper.FmlaPinTo(0.0, base.adj, 25000.0);
			this.double_12 = Helper.FmlaMultiplyDivide(base.double_6, this.double_11, 100000.0);
			this.double_13 = Helper.FmlaMultiplyDivide(this.double_12, 1.0, 2.0);
			this.double_14 = Helper.FmlaMultiplyDivide(this.double_12, 1.0, 4.0);
			this.double_15 = Helper.FmlaAddSubtract(this.double_12, this.double_13, 0.0);
			this.double_16 = Helper.FmlaAddSubtract(this.double_12, this.double_12, 0.0);
			this.double_17 = Helper.FmlaAddSubtract(base.double_0, 0.0, this.double_12);
			this.double_18 = Helper.FmlaAddSubtract(base.double_0, 0.0, this.double_13);
			this.double_19 = Helper.FmlaAddSubtract(this.double_17, 0.0, this.double_13);
			this.double_20 = Helper.FmlaAddSubtract(base.double_5, 0.0, this.double_12);
			this.double_21 = Helper.FmlaAddSubtract(base.double_5, 0.0, this.double_13);
			if (base.shape.Class174_0.Class172_0.Count == 0)
			{
				double num = ((base.shape.Class174_0.Dictionary_0 == null || !base.shape.Class174_0.Dictionary_0.ContainsKey("adj")) ? 12500.0 : base.adj);
				AdjustObject adjustObject = new Class170(new Class177(this.double_12 / 12700.0, base.t / 12700.0, bool_1: false), "Adj", 0.0, 25000.0, num, base.shape, bool_0: false);
				adjustObject.DefaultValue = 12500.0;
				base.shape.Class174_0.Class172_0.method_0(adjustObject);
			}
			else
			{
				base.shape.Class174_0.Class172_0[0].AdjustRectangle.Class178_0.Class177_1 = new Class177(this.double_12 / 12700.0, base.t / 12700.0, bool_1: false);
			}
			base.shape.Class174_0.Dictionary_0 = null;
			Class175[] array = new Class175[3];
			GraphicsPath graphicsPath = DrawHelper.PathBegin();
			Class175 @class = new Class175(bool_1: false, Enum32.const_5);
			Class177 currentPathEndLocation = DrawHelper.MoveTo(base.double_5, this.double_13);
			currentPathEndLocation = DrawHelper.ArcTo(graphicsPath, this.double_13, this.double_13, 0.0, base.cd4, currentPathEndLocation);
			currentPathEndLocation = DrawHelper.LnTo(graphicsPath, currentPathEndLocation.Double_2, currentPathEndLocation.Double_3, this.double_21, this.double_13);
			currentPathEndLocation = DrawHelper.ArcTo(graphicsPath, this.double_14, this.double_14, 0.0, base.cd2, currentPathEndLocation);
			currentPathEndLocation = DrawHelper.LnTo(graphicsPath, currentPathEndLocation.Double_2, currentPathEndLocation.Double_3, this.double_20, this.double_12);
			currentPathEndLocation = DrawHelper.LnTo(graphicsPath, currentPathEndLocation.Double_2, currentPathEndLocation.Double_3, this.double_13, this.double_12);
			currentPathEndLocation = DrawHelper.ArcTo(graphicsPath, this.double_13, this.double_13, base._3cd4, -5400000.0, currentPathEndLocation);
			currentPathEndLocation = DrawHelper.LnTo(graphicsPath, currentPathEndLocation.Double_2, currentPathEndLocation.Double_3, base.double_3, this.double_18);
			currentPathEndLocation = DrawHelper.ArcTo(graphicsPath, this.double_13, this.double_13, base.cd2, -10800000.0, currentPathEndLocation);
			currentPathEndLocation = DrawHelper.LnTo(graphicsPath, currentPathEndLocation.Double_2, currentPathEndLocation.Double_3, this.double_12, this.double_17);
			currentPathEndLocation = DrawHelper.LnTo(graphicsPath, currentPathEndLocation.Double_2, currentPathEndLocation.Double_3, this.double_21, this.double_17);
			currentPathEndLocation = DrawHelper.ArcTo(graphicsPath, this.double_13, this.double_13, base.cd4, -5400000.0, currentPathEndLocation);
			DrawHelper.Close(graphicsPath);
			currentPathEndLocation = DrawHelper.MoveTo(this.double_13, this.double_16);
			currentPathEndLocation = DrawHelper.ArcTo(graphicsPath, this.double_13, this.double_13, base.cd4, -5400000.0, currentPathEndLocation);
			currentPathEndLocation = DrawHelper.ArcTo(graphicsPath, this.double_14, this.double_14, 0.0, -10800000.0, currentPathEndLocation);
			DrawHelper.Close(graphicsPath);
			@class.List_0.Add(graphicsPath);
			array[0] = @class;
			graphicsPath = DrawHelper.PathBegin();
			@class = new Class175(bool_1: false, Enum32.const_1);
			currentPathEndLocation = DrawHelper.MoveTo(this.double_13, this.double_16);
			currentPathEndLocation = DrawHelper.ArcTo(graphicsPath, this.double_13, this.double_13, base.cd4, -5400000.0, currentPathEndLocation);
			currentPathEndLocation = DrawHelper.ArcTo(graphicsPath, this.double_14, this.double_14, 0.0, -10800000.0, currentPathEndLocation);
			DrawHelper.Close(graphicsPath);
			currentPathEndLocation = DrawHelper.MoveTo(this.double_21, this.double_12);
			currentPathEndLocation = DrawHelper.ArcTo(graphicsPath, this.double_13, this.double_13, base.cd4, -16200000.0, currentPathEndLocation);
			currentPathEndLocation = DrawHelper.ArcTo(graphicsPath, this.double_14, this.double_14, base.cd2, -10800000.0, currentPathEndLocation);
			DrawHelper.Close(graphicsPath);
			@class.List_0.Add(graphicsPath);
			array[1] = @class;
			graphicsPath = DrawHelper.PathBegin();
			@class = new Class175(bool_1: true, Enum32.const_4);
			currentPathEndLocation = DrawHelper.MoveTo(base.double_3, this.double_15);
			currentPathEndLocation = DrawHelper.ArcTo(graphicsPath, this.double_13, this.double_13, base.cd2, base.cd4, currentPathEndLocation);
			currentPathEndLocation = DrawHelper.LnTo(graphicsPath, currentPathEndLocation.Double_2, currentPathEndLocation.Double_3, this.double_20, this.double_12);
			currentPathEndLocation = DrawHelper.LnTo(graphicsPath, currentPathEndLocation.Double_2, currentPathEndLocation.Double_3, this.double_20, this.double_13);
			currentPathEndLocation = DrawHelper.ArcTo(graphicsPath, this.double_13, this.double_13, base.cd2, base.cd2, currentPathEndLocation);
			currentPathEndLocation = DrawHelper.LnTo(graphicsPath, currentPathEndLocation.Double_2, currentPathEndLocation.Double_3, base.double_5, this.double_19);
			currentPathEndLocation = DrawHelper.ArcTo(graphicsPath, this.double_13, this.double_13, 0.0, base.cd4, currentPathEndLocation);
			currentPathEndLocation = DrawHelper.LnTo(graphicsPath, currentPathEndLocation.Double_2, currentPathEndLocation.Double_3, this.double_12, this.double_17);
			currentPathEndLocation = DrawHelper.LnTo(graphicsPath, currentPathEndLocation.Double_2, currentPathEndLocation.Double_3, this.double_12, this.double_18);
			currentPathEndLocation = DrawHelper.ArcTo(graphicsPath, this.double_13, this.double_13, 0.0, base.cd2, currentPathEndLocation);
			DrawHelper.Close(graphicsPath);
			currentPathEndLocation = DrawHelper.MoveTo(this.double_20, this.double_12, graphicsPath, @class, out graphicsPath);
			currentPathEndLocation = DrawHelper.LnTo(graphicsPath, currentPathEndLocation.Double_2, currentPathEndLocation.Double_3, this.double_21, this.double_12);
			currentPathEndLocation = DrawHelper.ArcTo(graphicsPath, this.double_13, this.double_13, base.cd4, -5400000.0, currentPathEndLocation);
			currentPathEndLocation = DrawHelper.MoveTo(this.double_21, this.double_12, graphicsPath, @class, out graphicsPath);
			currentPathEndLocation = DrawHelper.LnTo(graphicsPath, currentPathEndLocation.Double_2, currentPathEndLocation.Double_3, this.double_21, this.double_13);
			currentPathEndLocation = DrawHelper.ArcTo(graphicsPath, this.double_14, this.double_14, 0.0, base.cd2, currentPathEndLocation);
			currentPathEndLocation = DrawHelper.MoveTo(this.double_13, this.double_16, graphicsPath, @class, out graphicsPath);
			currentPathEndLocation = DrawHelper.LnTo(graphicsPath, currentPathEndLocation.Double_2, currentPathEndLocation.Double_3, this.double_13, this.double_15);
			currentPathEndLocation = DrawHelper.ArcTo(graphicsPath, this.double_14, this.double_14, base.cd2, base.cd2, currentPathEndLocation);
			currentPathEndLocation = DrawHelper.ArcTo(graphicsPath, this.double_13, this.double_13, 0.0, base.cd2, currentPathEndLocation);
			currentPathEndLocation = DrawHelper.MoveTo(this.double_12, this.double_15, graphicsPath, @class, out graphicsPath);
			currentPathEndLocation = DrawHelper.LnTo(graphicsPath, currentPathEndLocation.Double_2, currentPathEndLocation.Double_3, this.double_12, this.double_17);
			@class.List_0.Add(graphicsPath);
			array[2] = @class;
			base.shape.Class183_0.Class175_0 = array;
		}
	}
}
