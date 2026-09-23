using System.Drawing.Drawing2D;
using ns17;
using TXTextControl.Drawing;

namespace ns18
{
	internal class Class327 : ShapeObject
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

		public Class327(Shape shape_0)
		{
			base.shape = shape_0;
			base.shape.Class174_0.Class172_0.Clear();
			base.adj1 = Helper.FmlaLiteralValue(16667.0);
			base.adj2 = Helper.FmlaLiteralValue(50000.0);
			base.SetLoadedAvLstValues(base.shape);
		}

		internal override void CreateGraphicsPaths()
		{
			base.CreateBaseVariables(base.shape);
			this.double_11 = Helper.FmlaPinTo(0.0, base.adj1, 33333.0);
			this.double_12 = Helper.FmlaPinTo(25000.0, base.adj2, 75000.0);
			this.double_13 = Helper.FmlaAddSubtract(base.double_5, 0.0, base.wd8);
			this.double_14 = Helper.FmlaMultiplyDivide(base.double_8, this.double_12, 200000.0);
			this.double_15 = Helper.FmlaAddSubtract(base.double_2, 0.0, this.double_14);
			this.double_16 = Helper.FmlaAddSubtract(base.double_2, this.double_14, 0.0);
			this.double_17 = Helper.FmlaAddSubtract(this.double_15, base.wd32, 0.0);
			this.double_18 = Helper.FmlaAddSubtract(this.double_16, 0.0, base.wd32);
			this.double_19 = Helper.FmlaAddSubtract(this.double_15, base.wd8, 0.0);
			this.double_20 = Helper.FmlaAddSubtract(this.double_16, 0.0, base.wd8);
			this.double_21 = Helper.FmlaAddSubtract(this.double_19, 0.0, base.wd32);
			this.double_22 = Helper.FmlaAddSubtract(this.double_20, base.wd32, 0.0);
			this.double_23 = Helper.FmlaMultiplyDivide(base.double_1, this.double_11, 200000.0);
			this.double_24 = Helper.FmlaMultiplyDivide(base.double_1, this.double_11, 100000.0);
			this.double_25 = Helper.FmlaAddSubtract(base.double_0, 0.0, this.double_24);
			this.double_26 = Helper.FmlaMultiplyDivide(this.double_25, 1.0, 2.0);
			this.double_27 = Helper.FmlaMultiplyDivide(base.double_1, this.double_11, 400000.0);
			this.double_28 = Helper.FmlaAddSubtract(base.double_0, 0.0, this.double_27);
			this.double_29 = Helper.FmlaAddSubtract(this.double_24, 0.0, this.double_27);
			if (base.shape.Class174_0.Class172_0.Count == 0)
			{
				double num = ((base.shape.Class174_0.Dictionary_0 == null || !base.shape.Class174_0.Dictionary_0.ContainsKey("adj1")) ? 16667.0 : base.adj1);
				AdjustObject adjustObject = new Class171(new Class177(base.double_2 / 12700.0, this.double_24 / 12700.0, bool_1: false), "Adj1", 0.0, 33333.0, num, base.shape, bool_0: false);
				adjustObject.DefaultValue = 16667.0;
				base.shape.Class174_0.Class172_0.method_0(adjustObject);
				num = ((base.shape.Class174_0.Dictionary_0 == null || !base.shape.Class174_0.Dictionary_0.ContainsKey("adj2")) ? 50000.0 : base.adj2);
				adjustObject = new Class170(new Class177(this.double_15 / 12700.0, base.t / 12700.0, bool_1: false), "Adj2", 25000.0, 75000.0, num, base.shape, bool_0: true);
				adjustObject.DefaultValue = 50000.0;
				base.shape.Class174_0.Class172_0.method_0(adjustObject);
			}
			else
			{
				base.shape.Class174_0.Class172_0[0].AdjustRectangle.Class178_0.Class177_1 = new Class177(base.double_2 / 12700.0, this.double_24 / 12700.0, bool_1: false);
				base.shape.Class174_0.Class172_0[1].AdjustRectangle.Class178_0.Class177_1 = new Class177(this.double_15 / 12700.0, base.t / 12700.0, bool_1: false);
			}
			base.shape.Class174_0.Dictionary_0 = null;
			Class175[] array = new Class175[3];
			GraphicsPath graphicsPath = DrawHelper.PathBegin();
			Class175 @class = new Class175(bool_1: false, Enum32.const_5);
			Class177 class2 = DrawHelper.MoveTo(base.double_3, base.t);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_21, base.t);
			class2 = DrawHelper.ArcTo(graphicsPath, base.wd32, this.double_27, base._3cd4, base.cd2, class2);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_17, this.double_23);
			class2 = DrawHelper.ArcTo(graphicsPath, base.wd32, this.double_27, base._3cd4, -10800000.0, class2);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_18, this.double_24);
			class2 = DrawHelper.ArcTo(graphicsPath, base.wd32, this.double_27, base.cd4, -10800000.0, class2);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_22, this.double_23);
			class2 = DrawHelper.ArcTo(graphicsPath, base.wd32, this.double_27, base.cd4, base.cd2, class2);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, base.double_5, base.t);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_13, this.double_26);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, base.double_5, this.double_25);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_16, this.double_25);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_16, this.double_28);
			class2 = DrawHelper.ArcTo(graphicsPath, base.wd32, this.double_27, 0.0, base.cd4, class2);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_17, base.double_0);
			class2 = DrawHelper.ArcTo(graphicsPath, base.wd32, this.double_27, base.cd4, base.cd4, class2);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_15, this.double_25);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, base.double_3, this.double_25);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, base.wd8, this.double_26);
			DrawHelper.Close(graphicsPath);
			@class.List_0.Add(graphicsPath);
			array[0] = @class;
			graphicsPath = DrawHelper.PathBegin();
			@class = new Class175(bool_1: false, Enum32.const_1);
			class2 = DrawHelper.MoveTo(this.double_19, this.double_27);
			class2 = DrawHelper.ArcTo(graphicsPath, base.wd32, this.double_27, 0.0, base.cd4, class2);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_17, this.double_23);
			class2 = DrawHelper.ArcTo(graphicsPath, base.wd32, this.double_27, base._3cd4, -10800000.0, class2);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_19, this.double_24);
			DrawHelper.Close(graphicsPath);
			class2 = DrawHelper.MoveTo(this.double_20, this.double_27);
			class2 = DrawHelper.ArcTo(graphicsPath, base.wd32, this.double_27, base.cd2, -5400000.0, class2);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_18, this.double_23);
			class2 = DrawHelper.ArcTo(graphicsPath, base.wd32, this.double_27, base._3cd4, base.cd2, class2);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_20, this.double_24);
			DrawHelper.Close(graphicsPath);
			@class.List_0.Add(graphicsPath);
			array[1] = @class;
			graphicsPath = DrawHelper.PathBegin();
			@class = new Class175(bool_1: true, Enum32.const_4);
			class2 = DrawHelper.MoveTo(base.double_3, base.t);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_21, base.t);
			class2 = DrawHelper.ArcTo(graphicsPath, base.wd32, this.double_27, base._3cd4, base.cd2, class2);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_17, this.double_23);
			class2 = DrawHelper.ArcTo(graphicsPath, base.wd32, this.double_27, base._3cd4, -10800000.0, class2);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_18, this.double_24);
			class2 = DrawHelper.ArcTo(graphicsPath, base.wd32, this.double_27, base.cd4, -10800000.0, class2);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_22, this.double_23);
			class2 = DrawHelper.ArcTo(graphicsPath, base.wd32, this.double_27, base.cd4, base.cd2, class2);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, base.double_5, base.t);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_13, this.double_26);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, base.double_5, this.double_25);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_16, this.double_25);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_16, this.double_28);
			class2 = DrawHelper.ArcTo(graphicsPath, base.wd32, this.double_27, 0.0, base.cd4, class2);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_17, base.double_0);
			class2 = DrawHelper.ArcTo(graphicsPath, base.wd32, this.double_27, base.cd4, base.cd4, class2);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_15, this.double_25);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, base.double_3, this.double_25);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, base.wd8, this.double_26);
			DrawHelper.Close(graphicsPath);
			class2 = DrawHelper.MoveTo(this.double_19, this.double_27, graphicsPath, @class, out graphicsPath);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_19, this.double_24);
			class2 = DrawHelper.MoveTo(this.double_20, this.double_24, graphicsPath, @class, out graphicsPath);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_20, this.double_27);
			class2 = DrawHelper.MoveTo(this.double_15, this.double_25, graphicsPath, @class, out graphicsPath);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_15, this.double_29);
			class2 = DrawHelper.MoveTo(this.double_16, this.double_29, graphicsPath, @class, out graphicsPath);
			class2 = DrawHelper.LnTo(graphicsPath, class2.Double_2, class2.Double_3, this.double_16, this.double_25);
			@class.List_0.Add(graphicsPath);
			array[2] = @class;
			base.shape.Class183_0.Class175_0 = array;
		}
	}
}
