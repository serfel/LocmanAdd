using System.Drawing.Drawing2D;
using ns17;
using TXTextControl.Drawing;

namespace ns18
{
	internal class Class233 : ShapeObject
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

		public Class233(Shape shape_0)
		{
			base.shape = shape_0;
			base.shape.Class174_0.Class172_0.Clear();
			base.adj1 = Helper.FmlaLiteralValue(50000.0);
			base.adj2 = Helper.FmlaLiteralValue(50000.0);
			base.SetLoadedAvLstValues(base.shape);
		}

		internal override void CreateGraphicsPaths()
		{
			base.CreateBaseVariables(base.shape);
			this.double_11 = Helper.FmlaMultiplyDivide(base.double_8, base.adj1, 100000.0);
			this.double_12 = Helper.FmlaAddDivide(base.double_3, this.double_11, 2.0);
			this.double_13 = Helper.FmlaAddDivide(base.double_5, this.double_11, 2.0);
			this.double_14 = Helper.FmlaAddDivide(this.double_11, this.double_13, 2.0);
			this.double_15 = Helper.FmlaAddDivide(this.double_13, base.double_5, 2.0);
			this.double_16 = Helper.FmlaMultiplyDivide(base.double_1, base.adj2, 100000.0);
			this.double_17 = Helper.FmlaAddDivide(base.t, this.double_16, 2.0);
			this.double_18 = Helper.FmlaAddDivide(base.t, this.double_17, 2.0);
			this.double_19 = Helper.FmlaAddDivide(this.double_17, this.double_16, 2.0);
			this.double_20 = Helper.FmlaAddDivide(base.double_0, this.double_16, 2.0);
			if (base.shape.Class174_0.Class172_0.Count == 0)
			{
				double num = ((base.shape.Class174_0.Dictionary_0 == null || !base.shape.Class174_0.Dictionary_0.ContainsKey("adj1")) ? 50000.0 : base.adj1);
				AdjustObject adjustObject = new Class170(new Class177(this.double_11 / 12700.0, this.double_17 / 12700.0, bool_1: false), "Adj1", -2147483647.0, 2147483647.0, num, base.shape, bool_0: false);
				adjustObject.DefaultValue = 50000.0;
				base.shape.Class174_0.Class172_0.method_0(adjustObject);
				num = ((base.shape.Class174_0.Dictionary_0 == null || !base.shape.Class174_0.Dictionary_0.ContainsKey("adj2")) ? 50000.0 : base.adj2);
				adjustObject = new Class171(new Class177(this.double_13 / 12700.0, this.double_16 / 12700.0, bool_1: false), "Adj2", -2147483647.0, 2147483647.0, num, base.shape, bool_0: false);
				adjustObject.DefaultValue = 50000.0;
				base.shape.Class174_0.Class172_0.method_0(adjustObject);
			}
			else
			{
				base.shape.Class174_0.Class172_0[0].AdjustRectangle.Class178_0.Class177_1 = new Class177(this.double_11 / 12700.0, this.double_17 / 12700.0, bool_1: false);
				base.shape.Class174_0.Class172_0[1].AdjustRectangle.Class178_0.Class177_1 = new Class177(this.double_13 / 12700.0, this.double_16 / 12700.0, bool_1: false);
			}
			base.shape.Class174_0.Dictionary_0 = null;
			Class175[] array = new Class175[1];
			GraphicsPath graphicsPath = DrawHelper.PathBegin();
			Class175 @class = new Class175(bool_1: true, Enum32.const_4);
			Class177 point = DrawHelper.MoveTo(base.double_3, base.t);
			base.ipt2 = new Class177(this.double_12, base.t, bool_1: true);
			base.ipt3 = new Class177(this.double_11, this.double_18, bool_1: true);
			base.ipt4 = new Class177(this.double_11, this.double_17, bool_1: true);
			point = DrawHelper.CubicBezTo(graphicsPath, point, base.ipt2, base.ipt3, base.ipt4);
			base.ipt2 = new Class177(this.double_11, this.double_19, bool_1: true);
			base.ipt3 = new Class177(this.double_14, this.double_16, bool_1: true);
			base.ipt4 = new Class177(this.double_13, this.double_16, bool_1: true);
			point = DrawHelper.CubicBezTo(graphicsPath, point, base.ipt2, base.ipt3, base.ipt4);
			base.ipt2 = new Class177(this.double_15, this.double_16, bool_1: true);
			base.ipt3 = new Class177(base.double_5, this.double_20, bool_1: true);
			base.ipt4 = new Class177(base.double_5, base.double_0, bool_1: true);
			point = DrawHelper.CubicBezTo(graphicsPath, point, base.ipt2, base.ipt3, base.ipt4);
			@class.List_0.Add(graphicsPath);
			array[0] = @class;
			base.shape.Class183_0.Class175_0 = array;
		}
	}
}
