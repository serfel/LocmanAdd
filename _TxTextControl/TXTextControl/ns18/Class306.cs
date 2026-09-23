using System.Drawing.Drawing2D;
using ns17;
using TXTextControl.Drawing;

namespace ns18
{
	internal class Class306 : ShapeObject
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

		public Class306(Shape shape_0)
		{
			base.shape = shape_0;
			base.shape.Class174_0.Class172_0.Clear();
			base.adj1 = Helper.FmlaLiteralValue(23520.0);
			base.adj2 = Helper.FmlaLiteralValue(5880.0);
			base.adj3 = Helper.FmlaLiteralValue(11760.0);
			base.SetLoadedAvLstValues(base.shape);
		}

		internal override void CreateGraphicsPaths()
		{
			base.CreateBaseVariables(base.shape);
			this.double_11 = Helper.FmlaPinTo(1000.0, base.adj1, 36745.0);
			this.double_12 = Helper.FmlaAddSubtract(0.0, 0.0, this.double_11);
			this.double_13 = Helper.FmlaAddDivide(73490.0, this.double_12, 4.0);
			this.double_14 = Helper.FmlaMultiplyDivide(36745.0, base.double_8, base.double_1);
			this.double_15 = Helper.FmlaMinimumValue(this.double_13, this.double_14);
			this.double_16 = Helper.FmlaPinTo(1000.0, base.adj3, this.double_15);
			this.double_17 = Helper.FmlaMultiplyDivide(-4.0, this.double_16, 1.0);
			this.double_18 = Helper.FmlaAddSubtract(73490.0, this.double_17, this.double_11);
			this.double_19 = Helper.FmlaPinTo(0.0, base.adj2, this.double_18);
			this.double_20 = Helper.FmlaMultiplyDivide(base.double_1, this.double_11, 200000.0);
			this.double_21 = Helper.FmlaMultiplyDivide(base.double_1, this.double_19, 100000.0);
			this.double_22 = Helper.FmlaMultiplyDivide(base.double_1, this.double_16, 100000.0);
			this.double_23 = Helper.FmlaMultiplyDivide(base.double_8, 73490.0, 200000.0);
			this.double_24 = Helper.FmlaAddSubtract(base.double_7, 0.0, this.double_20);
			this.double_25 = Helper.FmlaAddSubtract(base.double_7, this.double_20, 0.0);
			this.double_26 = Helper.FmlaAddSubtract(this.double_21, this.double_22, 0.0);
			this.double_27 = Helper.FmlaAddSubtract(this.double_24, 0.0, this.double_26);
			this.double_28 = Helper.FmlaAddSubtract(this.double_27, 0.0, this.double_22);
			this.double_29 = Helper.FmlaAddSubtract(base.double_0, 0.0, this.double_28);
			this.double_30 = Helper.FmlaAddSubtract(base.double_2, 0.0, this.double_23);
			this.double_31 = Helper.FmlaAddSubtract(base.double_2, this.double_23, 0.0);
			this.double_32 = Helper.FmlaAddSubtract(base.double_2, 0.0, this.double_22);
			if (base.shape.Class174_0.Class172_0.Count == 0)
			{
				double num = ((base.shape.Class174_0.Dictionary_0 == null || !base.shape.Class174_0.Dictionary_0.ContainsKey("adj1")) ? 23520.0 : base.adj1);
				AdjustObject adjustObject = new Class171(new Class177(base.double_3 / 12700.0, this.double_24 / 12700.0, bool_1: false), "Adj1", 1000.0, 36745.0, num, base.shape, bool_0: true);
				adjustObject.DefaultValue = 23520.0;
				base.shape.Class174_0.Class172_0.method_0(adjustObject);
				num = ((base.shape.Class174_0.Dictionary_0 == null || !base.shape.Class174_0.Dictionary_0.ContainsKey("adj2")) ? 5880.0 : base.adj2);
				adjustObject = new Class171(new Class177(base.double_5 / 12700.0, this.double_27 / 12700.0, bool_1: false), "Adj2", 0.0, this.double_18, num, base.shape, bool_0: true);
				adjustObject.DefaultValue = 5880.0;
				base.shape.Class174_0.Class172_0.method_0(adjustObject);
				num = ((base.shape.Class174_0.Dictionary_0 == null || !base.shape.Class174_0.Dictionary_0.ContainsKey("adj3")) ? 11760.0 : base.adj3);
				adjustObject = new Class170(new Class177(this.double_32 / 12700.0, base.t / 12700.0, bool_1: false), "Adj3", 1000.0, this.double_15, num, base.shape, bool_0: true);
				adjustObject.DefaultValue = 11760.0;
				base.shape.Class174_0.Class172_0.method_0(adjustObject);
			}
			else
			{
				base.shape.Class174_0.Class172_0[0].AdjustRectangle.Class178_0.Class177_1 = new Class177(base.double_3 / 12700.0, this.double_24 / 12700.0, bool_1: false);
				base.shape.Class174_0.Class172_0[1].AdjustRectangle.Class178_0.Class177_1 = new Class177(base.double_5 / 12700.0, this.double_27 / 12700.0, bool_1: false);
				base.shape.Class174_0.Class172_0[2].AdjustRectangle.Class178_0.Class177_1 = new Class177(this.double_32 / 12700.0, base.t / 12700.0, bool_1: false);
			}
			base.shape.Class174_0.Dictionary_0 = null;
			Class175[] array = new Class175[1];
			GraphicsPath graphicsPath = DrawHelper.PathBegin();
			Class175 @class = new Class175(bool_1: true, Enum32.const_5);
			Class177 currentPathEndLocation = DrawHelper.MoveTo(base.double_2, this.double_28);
			currentPathEndLocation = DrawHelper.ArcTo(graphicsPath, this.double_22, this.double_22, base._3cd4, 21600000.0, currentPathEndLocation);
			DrawHelper.Close(graphicsPath);
			currentPathEndLocation = DrawHelper.MoveTo(base.double_2, this.double_29);
			currentPathEndLocation = DrawHelper.ArcTo(graphicsPath, this.double_22, this.double_22, base.cd4, 21600000.0, currentPathEndLocation);
			DrawHelper.Close(graphicsPath);
			currentPathEndLocation = DrawHelper.MoveTo(this.double_30, this.double_24);
			currentPathEndLocation = DrawHelper.LnTo(graphicsPath, currentPathEndLocation.Double_2, currentPathEndLocation.Double_3, this.double_31, this.double_24);
			currentPathEndLocation = DrawHelper.LnTo(graphicsPath, currentPathEndLocation.Double_2, currentPathEndLocation.Double_3, this.double_31, this.double_25);
			currentPathEndLocation = DrawHelper.LnTo(graphicsPath, currentPathEndLocation.Double_2, currentPathEndLocation.Double_3, this.double_30, this.double_25);
			DrawHelper.Close(graphicsPath);
			@class.List_0.Add(graphicsPath);
			array[0] = @class;
			base.shape.Class183_0.Class175_0 = array;
		}
	}
}
