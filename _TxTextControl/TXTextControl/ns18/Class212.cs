using System.Drawing.Drawing2D;
using ns17;
using TXTextControl.Drawing;

namespace ns18
{
	internal class Class212 : ShapeObject
	{
		private double double_11;

		private double double_12;

		private double double_13;

		private double double_14;

		private double double_15;

		private double double_16;

		public Class212(Shape shape_0)
		{
			base.shape = shape_0;
			base.shape.Class174_0.Class172_0.Clear();
			base.adj1 = Helper.FmlaLiteralValue(18750.0);
			base.adj2 = Helper.FmlaLiteralValue(-8333.0);
			base.adj3 = Helper.FmlaLiteralValue(18750.0);
			base.adj4 = Helper.FmlaLiteralValue(-16667.0);
			base.adj5 = Helper.FmlaLiteralValue(112500.0);
			base.adj6 = Helper.FmlaLiteralValue(-46667.0);
			base.SetLoadedAvLstValues(base.shape);
		}

		internal override void CreateGraphicsPaths()
		{
			base.CreateBaseVariables(base.shape);
			this.double_11 = Helper.FmlaMultiplyDivide(base.double_1, base.adj1, 100000.0);
			this.double_12 = Helper.FmlaMultiplyDivide(base.double_8, base.adj2, 100000.0);
			this.double_13 = Helper.FmlaMultiplyDivide(base.double_1, base.adj3, 100000.0);
			this.double_14 = Helper.FmlaMultiplyDivide(base.double_8, base.adj4, 100000.0);
			this.double_15 = Helper.FmlaMultiplyDivide(base.double_1, base.adj5, 100000.0);
			this.double_16 = Helper.FmlaMultiplyDivide(base.double_8, base.adj6, 100000.0);
			if (base.shape.Class174_0.Class172_0.Count == 0)
			{
				double num = ((base.shape.Class174_0.Dictionary_0 == null || !base.shape.Class174_0.Dictionary_0.ContainsKey("adj2")) ? (-8333.0) : base.adj2);
				AdjustObject adjustObject = new Class170(new Class177(this.double_12 / 12700.0, this.double_11 / 12700.0, bool_1: false), "Adj2", -2147483647.0, 2147483647.0, num, base.shape, bool_0: false);
				adjustObject.DefaultValue = -8333.0;
				base.shape.Class174_0.Class172_0.method_0(adjustObject);
				num = ((base.shape.Class174_0.Dictionary_0 == null || !base.shape.Class174_0.Dictionary_0.ContainsKey("adj1")) ? 18750.0 : base.adj1);
				adjustObject = new Class171(new Class177(this.double_12 / 12700.0, this.double_11 / 12700.0, bool_1: false), "Adj1", -2147483647.0, 2147483647.0, num, base.shape, bool_0: false);
				adjustObject.DefaultValue = 18750.0;
				base.shape.Class174_0.Class172_0.method_0(adjustObject);
				num = ((base.shape.Class174_0.Dictionary_0 == null || !base.shape.Class174_0.Dictionary_0.ContainsKey("adj4")) ? (-16667.0) : base.adj4);
				adjustObject = new Class170(new Class177(this.double_14 / 12700.0, this.double_13 / 12700.0, bool_1: false), "Adj4", -2147483647.0, 2147483647.0, num, base.shape, bool_0: false);
				adjustObject.DefaultValue = -16667.0;
				base.shape.Class174_0.Class172_0.method_0(adjustObject);
				num = ((base.shape.Class174_0.Dictionary_0 == null || !base.shape.Class174_0.Dictionary_0.ContainsKey("adj3")) ? 18750.0 : base.adj3);
				adjustObject = new Class171(new Class177(this.double_14 / 12700.0, this.double_13 / 12700.0, bool_1: false), "Adj3", -2147483647.0, 2147483647.0, num, base.shape, bool_0: false);
				adjustObject.DefaultValue = 18750.0;
				base.shape.Class174_0.Class172_0.method_0(adjustObject);
				num = ((base.shape.Class174_0.Dictionary_0 == null || !base.shape.Class174_0.Dictionary_0.ContainsKey("adj6")) ? (-46667.0) : base.adj6);
				adjustObject = new Class170(new Class177(this.double_16 / 12700.0, this.double_15 / 12700.0, bool_1: false), "Adj6", -2147483647.0, 2147483647.0, num, base.shape, bool_0: false);
				adjustObject.DefaultValue = -46667.0;
				base.shape.Class174_0.Class172_0.method_0(adjustObject);
				num = ((base.shape.Class174_0.Dictionary_0 == null || !base.shape.Class174_0.Dictionary_0.ContainsKey("adj5")) ? 112500.0 : base.adj5);
				adjustObject = new Class171(new Class177(this.double_16 / 12700.0, this.double_15 / 12700.0, bool_1: false), "Adj5", -2147483647.0, 2147483647.0, num, base.shape, bool_0: false);
				adjustObject.DefaultValue = 112500.0;
				base.shape.Class174_0.Class172_0.method_0(adjustObject);
			}
			else
			{
				base.shape.Class174_0.Class172_0[0].AdjustRectangle.Class178_0.Class177_1 = new Class177(this.double_12 / 12700.0, this.double_11 / 12700.0, bool_1: false);
				base.shape.Class174_0.Class172_0[1].AdjustRectangle.Class178_0.Class177_1 = new Class177(this.double_12 / 12700.0, this.double_11 / 12700.0, bool_1: false);
				base.shape.Class174_0.Class172_0[2].AdjustRectangle.Class178_0.Class177_1 = new Class177(this.double_14 / 12700.0, this.double_13 / 12700.0, bool_1: false);
				base.shape.Class174_0.Class172_0[3].AdjustRectangle.Class178_0.Class177_1 = new Class177(this.double_14 / 12700.0, this.double_13 / 12700.0, bool_1: false);
				base.shape.Class174_0.Class172_0[4].AdjustRectangle.Class178_0.Class177_1 = new Class177(this.double_16 / 12700.0, this.double_15 / 12700.0, bool_1: false);
				base.shape.Class174_0.Class172_0[5].AdjustRectangle.Class178_0.Class177_1 = new Class177(this.double_16 / 12700.0, this.double_15 / 12700.0, bool_1: false);
			}
			base.shape.Class174_0.Dictionary_0 = null;
			Class175[] array = new Class175[2];
			GraphicsPath graphicsPath = DrawHelper.PathBegin();
			Class175 @class = new Class175(bool_1: true, Enum32.const_5);
			Class177 class2 = DrawHelper.MoveTo(base.double_3, base.t);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, base.double_5, base.t);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, base.double_5, base.double_0);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, base.double_3, base.double_0);
			DrawHelper.Close(graphicsPath);
			@class.List_0.Add(graphicsPath);
			array[0] = @class;
			graphicsPath = DrawHelper.PathBegin();
			@class = new Class175(bool_1: true, Enum32.const_4);
			class2 = DrawHelper.MoveTo(this.double_12, this.double_11);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_14, this.double_13);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_16, this.double_15);
			@class.List_0.Add(graphicsPath);
			array[1] = @class;
			base.shape.Class183_0.Class175_0 = array;
		}
	}
}
