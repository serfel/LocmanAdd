using System.Drawing.Drawing2D;
using ns17;
using TXTextControl.Drawing;

namespace ns18
{
	internal class Class279 : ShapeObject
	{
		private double double_11;

		private double double_12;

		private double double_13;

		private double double_14;

		private double double_15;

		private double double_16;

		private double double_17;

		public Class279(Shape shape_0)
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
			this.double_13 = Helper.FmlaMultiplyDivide(this.double_12, 1.0, 5.0);
			this.double_14 = Helper.FmlaAddSubtract(base.double_5, 0.0, this.double_12);
			this.double_15 = Helper.FmlaAddSubtract(this.double_14, this.double_13, 0.0);
			this.double_16 = Helper.FmlaAddSubtract(base.double_0, 0.0, this.double_12);
			this.double_17 = Helper.FmlaAddSubtract(this.double_16, this.double_13, 0.0);
			if (base.shape.Class174_0.Class172_0.Count == 0)
			{
				double num = ((base.shape.Class174_0.Dictionary_0 == null || !base.shape.Class174_0.Dictionary_0.ContainsKey("adj")) ? 16667.0 : base.adj);
				AdjustObject adjustObject = new Class170(new Class177(this.double_14 / 12700.0, base.double_0 / 12700.0, bool_1: false), "Adj", 0.0, 50000.0, num, base.shape, bool_0: true);
				adjustObject.DefaultValue = 16667.0;
				base.shape.Class174_0.Class172_0.method_0(adjustObject);
			}
			else
			{
				base.shape.Class174_0.Class172_0[0].AdjustRectangle.Class178_0.Class177_1 = new Class177(this.double_14 / 12700.0, base.double_0 / 12700.0, bool_1: false);
			}
			base.shape.Class174_0.Dictionary_0 = null;
			Class175[] array = new Class175[3];
			GraphicsPath graphicsPath = DrawHelper.PathBegin();
			Class175 @class = new Class175(bool_1: false, Enum32.const_5);
			Class177 class2 = DrawHelper.MoveTo(base.double_3, base.t);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, base.double_5, base.t);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, base.double_5, this.double_16);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_14, base.double_0);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, base.double_3, base.double_0);
			DrawHelper.Close(graphicsPath);
			@class.List_0.Add(graphicsPath);
			array[0] = @class;
			graphicsPath = DrawHelper.PathBegin();
			@class = new Class175(bool_1: false, Enum32.const_1);
			class2 = DrawHelper.MoveTo(this.double_14, base.double_0);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_15, this.double_17);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, base.double_5, this.double_16);
			DrawHelper.Close(graphicsPath);
			@class.List_0.Add(graphicsPath);
			array[1] = @class;
			graphicsPath = DrawHelper.PathBegin();
			@class = new Class175(bool_1: true, Enum32.const_4);
			class2 = DrawHelper.MoveTo(this.double_14, base.double_0);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_15, this.double_17);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, base.double_5, this.double_16);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_14, base.double_0);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, base.double_3, base.double_0);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, base.double_3, base.t);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, base.double_5, base.t);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, base.double_5, this.double_16);
			@class.List_0.Add(graphicsPath);
			array[2] = @class;
			base.shape.Class183_0.Class175_0 = array;
		}
	}
}
