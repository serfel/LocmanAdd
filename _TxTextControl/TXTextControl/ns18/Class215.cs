using System.Drawing.Drawing2D;
using ns17;
using TXTextControl.Drawing;

namespace ns18
{
	internal class Class215 : ShapeObject
	{
		private double double_11;

		private double double_12;

		private double double_13;

		private double double_14;

		private double double_15;

		private double double_16;

		private double double_17;

		public Class215(Shape shape_0)
		{
			base.shape = shape_0;
			base.shape.Class174_0.Class172_0.Clear();
			base.adj = Helper.FmlaLiteralValue(16667.0);
			base.SetLoadedAvLstValues(base.shape);
		}

		internal override void CreateGraphicsPaths()
		{
			base.CreateBaseVariables(base.shape);
			this.double_11 = Helper.FmlaPinTo(0.0, base.adj, 50000.0);
			this.double_12 = Helper.FmlaMultiplyDivide(base.double_6, this.double_11, 100000.0);
			this.double_13 = Helper.FmlaAddSubtract(base.double_5, 0.0, this.double_12);
			this.double_14 = Helper.FmlaAddSubtract(base.double_0, 0.0, this.double_12);
			this.double_15 = Helper.FmlaMultiplyDivide(this.double_12, 29289.0, 100000.0);
			this.double_16 = Helper.FmlaAddSubtract(base.double_5, 0.0, this.double_15);
			this.double_17 = Helper.FmlaAddSubtract(base.double_0, 0.0, this.double_15);
			if (base.shape.Class174_0.Class172_0.Count == 0)
			{
				double num = ((base.shape.Class174_0.Dictionary_0 == null || !base.shape.Class174_0.Dictionary_0.ContainsKey("adj")) ? 16667.0 : base.adj);
				AdjustObject adjustObject = new Class171(new Class177(base.double_3 / 12700.0, this.double_12 / 12700.0, bool_1: false), "Adj", 0.0, 50000.0, num, base.shape, bool_0: false);
				adjustObject.DefaultValue = 16667.0;
				base.shape.Class174_0.Class172_0.method_0(adjustObject);
			}
			else
			{
				base.shape.Class174_0.Class172_0[0].AdjustRectangle.Class178_0.Class177_1 = new Class177(base.double_3 / 12700.0, this.double_12 / 12700.0, bool_1: false);
			}
			base.shape.Class174_0.Dictionary_0 = null;
			Class175[] array = new Class175[2];
			GraphicsPath graphicsPath = DrawHelper.PathBegin();
			Class175 @class = new Class175(bool_1: false, Enum32.const_5);
			Class177 currentPathEndLocation = DrawHelper.MoveTo(base.double_3, this.double_12);
			currentPathEndLocation = DrawHelper.ArcTo(graphicsPath, this.double_12, this.double_12, base.cd2, base.cd4, currentPathEndLocation);
			currentPathEndLocation = DrawHelper.LnTo(graphicsPath, currentPathEndLocation.Double_2, currentPathEndLocation.Double_3, this.double_13, base.t);
			currentPathEndLocation = DrawHelper.ArcTo(graphicsPath, this.double_12, this.double_12, base._3cd4, base.cd4, currentPathEndLocation);
			currentPathEndLocation = DrawHelper.LnTo(graphicsPath, currentPathEndLocation.Double_2, currentPathEndLocation.Double_3, base.double_5, this.double_14);
			currentPathEndLocation = DrawHelper.ArcTo(graphicsPath, this.double_12, this.double_12, 0.0, base.cd4, currentPathEndLocation);
			currentPathEndLocation = DrawHelper.LnTo(graphicsPath, currentPathEndLocation.Double_2, currentPathEndLocation.Double_3, this.double_12, base.double_0);
			currentPathEndLocation = DrawHelper.ArcTo(graphicsPath, this.double_12, this.double_12, base.cd4, base.cd4, currentPathEndLocation);
			DrawHelper.Close(graphicsPath);
			@class.List_0.Add(graphicsPath);
			array[0] = @class;
			graphicsPath = DrawHelper.PathBegin();
			@class = new Class175(bool_1: true, Enum32.const_4);
			currentPathEndLocation = DrawHelper.MoveTo(this.double_12, base.double_0);
			currentPathEndLocation = DrawHelper.ArcTo(graphicsPath, this.double_12, this.double_12, base.cd4, base.cd4, currentPathEndLocation);
			currentPathEndLocation = DrawHelper.LnTo(graphicsPath, currentPathEndLocation.Double_2, currentPathEndLocation.Double_3, base.double_3, this.double_12);
			currentPathEndLocation = DrawHelper.ArcTo(graphicsPath, this.double_12, this.double_12, base.cd2, base.cd4, currentPathEndLocation);
			currentPathEndLocation = DrawHelper.MoveTo(this.double_13, base.t, graphicsPath, @class, out graphicsPath);
			currentPathEndLocation = DrawHelper.ArcTo(graphicsPath, this.double_12, this.double_12, base._3cd4, base.cd4, currentPathEndLocation);
			currentPathEndLocation = DrawHelper.LnTo(graphicsPath, currentPathEndLocation.Double_2, currentPathEndLocation.Double_3, base.double_5, this.double_14);
			currentPathEndLocation = DrawHelper.ArcTo(graphicsPath, this.double_12, this.double_12, 0.0, base.cd4, currentPathEndLocation);
			@class.List_0.Add(graphicsPath);
			array[1] = @class;
			base.shape.Class183_0.Class175_0 = array;
		}
	}
}
