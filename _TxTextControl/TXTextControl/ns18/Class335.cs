using System.Drawing.Drawing2D;
using ns17;
using TXTextControl.Drawing;

namespace ns18
{
	internal class Class335 : ShapeObject
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

		public Class335(Shape shape_0)
		{
			base.shape = shape_0;
			base.shape.Class174_0.Class172_0.Clear();
			base.adj1 = Helper.FmlaLiteralValue(16667.0);
			base.adj2 = Helper.FmlaLiteralValue(0.0);
			base.SetLoadedAvLstValues(base.shape);
		}

		internal override void CreateGraphicsPaths()
		{
			base.CreateBaseVariables(base.shape);
			this.double_11 = Helper.FmlaPinTo(0.0, base.adj1, 50000.0);
			this.double_12 = Helper.FmlaPinTo(0.0, base.adj2, 50000.0);
			this.double_13 = Helper.FmlaMultiplyDivide(base.double_6, this.double_11, 100000.0);
			this.double_14 = Helper.FmlaAddSubtract(base.double_5, 0.0, this.double_13);
			this.double_15 = Helper.FmlaMultiplyDivide(base.double_6, this.double_12, 100000.0);
			this.double_16 = Helper.FmlaAddSubtract(base.double_5, 0.0, this.double_15);
			this.double_17 = Helper.FmlaAddSubtract(base.double_0, 0.0, this.double_15);
			this.double_18 = Helper.FmlaAddSubtract(this.double_13, 0.0, this.double_15);
			this.double_19 = Helper.FmlaMultiplyDivide(this.double_13, 29289.0, 100000.0);
			this.double_20 = Helper.FmlaMultiplyDivide(this.double_15, 29289.0, 100000.0);
			this.double_21 = Helper.FmlaIfElse(this.double_18, this.double_19, this.double_20);
			this.double_22 = Helper.FmlaAddSubtract(base.double_5, 0.0, this.double_21);
			this.double_23 = Helper.FmlaAddSubtract(base.double_0, 0.0, this.double_20);
			if (base.shape.Class174_0.Class172_0.Count == 0)
			{
				double num = ((base.shape.Class174_0.Dictionary_0 == null || !base.shape.Class174_0.Dictionary_0.ContainsKey("adj1")) ? 16667.0 : base.adj1);
				AdjustObject adjustObject = new Class170(new Class177(this.double_14 / 12700.0, base.t / 12700.0, bool_1: false), "Adj1", 0.0, 50000.0, num, base.shape, bool_0: true);
				adjustObject.DefaultValue = 16667.0;
				base.shape.Class174_0.Class172_0.method_0(adjustObject);
				num = ((base.shape.Class174_0.Dictionary_0 == null || !base.shape.Class174_0.Dictionary_0.ContainsKey("adj2")) ? 0.0 : base.adj2);
				adjustObject = new Class170(new Class177(this.double_15 / 12700.0, base.double_0 / 12700.0, bool_1: false), "Adj2", 0.0, 50000.0, num, base.shape, bool_0: false);
				adjustObject.DefaultValue = 0.0;
				base.shape.Class174_0.Class172_0.method_0(adjustObject);
			}
			else
			{
				base.shape.Class174_0.Class172_0[0].AdjustRectangle.Class178_0.Class177_1 = new Class177(this.double_14 / 12700.0, base.t / 12700.0, bool_1: false);
				base.shape.Class174_0.Class172_0[1].AdjustRectangle.Class178_0.Class177_1 = new Class177(this.double_15 / 12700.0, base.double_0 / 12700.0, bool_1: false);
			}
			base.shape.Class174_0.Dictionary_0 = null;
			Class175[] array = new Class175[1];
			GraphicsPath graphicsPath = DrawHelper.PathBegin();
			Class175 @class = new Class175(bool_1: true, Enum32.const_5);
			Class177 class2 = DrawHelper.MoveTo(this.double_13, base.t);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_14, base.t);
			class2 = DrawHelper.ArcTo(graphicsPath, this.double_13, this.double_13, base._3cd4, base.cd4, class2);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, base.double_5, this.double_17);
			class2 = DrawHelper.ArcTo(graphicsPath, this.double_15, this.double_15, 0.0, base.cd4, class2);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_15, base.double_0);
			class2 = DrawHelper.ArcTo(graphicsPath, this.double_15, this.double_15, base.cd4, base.cd4, class2);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, base.double_3, this.double_13);
			class2 = DrawHelper.ArcTo(graphicsPath, this.double_13, this.double_13, base.cd2, base.cd4, class2);
			DrawHelper.Close(graphicsPath);
			@class.List_0.Add(graphicsPath);
			array[0] = @class;
			base.shape.Class183_0.Class175_0 = array;
		}
	}
}
