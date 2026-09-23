using System.Drawing.Drawing2D;
using ns17;
using TXTextControl.Drawing;

namespace ns18
{
	internal class Class349 : ShapeObject
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

		public Class349(Shape shape_0)
		{
			base.shape = shape_0;
			base.shape.Class174_0.Class172_0.Clear();
			base.adj = Helper.FmlaLiteralValue(12500.0);
			base.SetLoadedAvLstValues(base.shape);
		}

		internal override void CreateGraphicsPaths()
		{
			base.CreateBaseVariables(base.shape);
			this.double_11 = Helper.FmlaPinTo(0.0, base.adj, 50000.0);
			this.double_12 = Helper.FmlaMultiplyDivide(base.wd2, this.double_11, 50000.0);
			this.double_13 = Helper.FmlaMultiplyDivide(base.hd2, this.double_11, 50000.0);
			this.double_14 = Helper.FmlaCosine(this.double_12, 2700000.0);
			this.double_15 = Helper.FmlaSine(this.double_13, 2700000.0);
			this.double_16 = Helper.FmlaAddSubtract(base.double_2, 0.0, this.double_14);
			this.double_17 = Helper.FmlaAddSubtract(base.double_2, this.double_14, 0.0);
			this.double_18 = Helper.FmlaAddSubtract(base.double_7, 0.0, this.double_15);
			this.double_19 = Helper.FmlaAddSubtract(base.double_7, this.double_15, 0.0);
			this.double_20 = Helper.FmlaAddSubtract(base.double_7, 0.0, this.double_13);
			if (base.shape.Class174_0.Class172_0.Count == 0)
			{
				double num = ((base.shape.Class174_0.Dictionary_0 == null || !base.shape.Class174_0.Dictionary_0.ContainsKey("adj")) ? 12500.0 : base.adj);
				AdjustObject adjustObject = new Class171(new Class177(base.double_2 / 12700.0, this.double_20 / 12700.0, bool_1: false), "Adj", 0.0, 50000.0, num, base.shape, bool_0: true);
				adjustObject.DefaultValue = 12500.0;
				base.shape.Class174_0.Class172_0.method_0(adjustObject);
			}
			else
			{
				base.shape.Class174_0.Class172_0[0].AdjustRectangle.Class178_0.Class177_1 = new Class177(base.double_2 / 12700.0, this.double_20 / 12700.0, bool_1: false);
			}
			base.shape.Class174_0.Dictionary_0 = null;
			Class175[] array = new Class175[1];
			GraphicsPath graphicsPath = DrawHelper.PathBegin();
			Class175 @class = new Class175(bool_1: true, Enum32.const_5);
			Class177 class2 = DrawHelper.MoveTo(base.double_3, base.double_7);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_16, this.double_18);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, base.double_2, base.t);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_17, this.double_18);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, base.double_5, base.double_7);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_17, this.double_19);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, base.double_2, base.double_0);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_16, this.double_19);
			DrawHelper.Close(graphicsPath);
			@class.List_0.Add(graphicsPath);
			array[0] = @class;
			base.shape.Class183_0.Class175_0 = array;
		}
	}
}
