using System.Drawing.Drawing2D;
using ns17;
using TXTextControl.Drawing;

namespace ns18
{
	internal class Class312 : ShapeObject
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

		private double double_33;

		private double double_34;

		private double double_35;

		private double double_36;

		private double double_37;

		private double double_38;

		private double double_39;

		private double double_40;

		private double double_41;

		private double double_42;

		private double double_43;

		private double double_44;

		public Class312(Shape shape_0)
		{
			base.shape = shape_0;
			base.shape.Class174_0.Class172_0.Clear();
			base.adj = Helper.FmlaLiteralValue(50000.0);
			base.SetLoadedAvLstValues(base.shape);
		}

		internal override void CreateGraphicsPaths()
		{
			base.CreateBaseVariables(base.shape);
			this.double_11 = Helper.FmlaPinTo(0.0, base.adj, 87500.0);
			this.double_12 = Helper.FmlaMultiplyDivide(base.double_6, this.double_11, 100000.0);
			this.double_13 = Helper.FmlaMultiplyDivide(this.double_12, base.double_8, base.double_6);
			this.double_14 = Helper.FmlaAddSubtract(base.double_6, 0.0, this.double_12);
			this.double_15 = Helper.FmlaMultiplyDivide(this.double_12, this.double_12, this.double_14);
			this.double_16 = Helper.FmlaMultiplyDivide(base.double_6, base.double_6, this.double_14);
			this.double_17 = Helper.FmlaMultiplyDivide(this.double_16, 2.0, 1.0);
			this.double_18 = Helper.FmlaAddSubtract(this.double_17, 0.0, this.double_15);
			this.double_19 = Helper.FmlaAddSubtract(this.double_18, 0.0, this.double_12);
			this.double_20 = Helper.FmlaMultiplyDivide(this.double_19, base.double_8, base.double_6);
			this.double_21 = Helper.FmlaMultiplyDivide(this.double_18, 1.0, 2.0);
			this.double_22 = Helper.FmlaAddSubtract(this.double_21, 0.0, this.double_12);
			this.double_23 = Helper.FmlaMultiplyDivide(this.double_22, base.hd2, base.double_6);
			this.double_24 = Helper.FmlaAddSubtract(base.double_7, 0.0, this.double_23);
			this.double_25 = Helper.FmlaAddSubtract(base.double_7, this.double_23, 0.0);
			this.double_26 = Helper.FmlaMultiplyDivide(this.double_12, 9598.0, 32768.0);
			this.double_27 = Helper.FmlaMultiplyDivide(this.double_26, base.double_8, base.double_6);
			this.double_28 = Helper.FmlaAddSubtract(base.double_6, 0.0, this.double_26);
			this.double_29 = Helper.FmlaMultiplyDivide(base.double_6, base.double_6, 1.0);
			this.double_30 = Helper.FmlaMultiplyDivide(this.double_28, this.double_28, 1.0);
			this.double_31 = Helper.FmlaAddSubtract(this.double_29, 0.0, this.double_30);
			this.double_32 = Helper.FmlaSquareRoot(this.double_31);
			this.double_33 = Helper.FmlaMultiplyDivide(this.double_32, base.hd2, base.double_6);
			this.double_34 = Helper.FmlaAddSubtract(base.double_7, 0.0, this.double_33);
			this.double_35 = Helper.FmlaAddSubtract(base.double_7, this.double_33, 0.0);
			this.double_36 = Helper.FmlaAddSubtract(this.double_20, 0.0, this.double_13);
			this.double_37 = Helper.FmlaMultiplyDivide(this.double_36, 1.0, 2.0);
			this.double_38 = Helper.FmlaAddSubtract(this.double_13, this.double_37, base.double_8);
			this.double_39 = Helper.FmlaMultiplyDivide(this.double_38, -1.0, 1.0);
			this.double_40 = Helper.FmlaMultiplyDivide(base.hd2, -1.0, 1.0);
			this.double_41 = Helper.FmlaArcTan(this.double_39, this.double_40);
			this.double_42 = Helper.FmlaArcTan(this.double_39, base.hd2);
			this.double_43 = Helper.FmlaAddSubtract(this.double_42, 0.0, 21600000.0);
			this.double_44 = Helper.FmlaAddSubtract(this.double_43, 0.0, this.double_41);
			if (base.shape.Class174_0.Class172_0.Count == 0)
			{
				double num = ((base.shape.Class174_0.Dictionary_0 == null || !base.shape.Class174_0.Dictionary_0.ContainsKey("adj")) ? 50000.0 : base.adj);
				AdjustObject adjustObject = new Class170(new Class177(this.double_13 / 12700.0, base.double_7 / 12700.0, bool_1: false), "Adj", 0.0, 87500.0, num, base.shape, bool_0: false);
				adjustObject.DefaultValue = 50000.0;
				base.shape.Class174_0.Class172_0.method_0(adjustObject);
			}
			else
			{
				base.shape.Class174_0.Class172_0[0].AdjustRectangle.Class178_0.Class177_1 = new Class177(this.double_13 / 12700.0, base.double_7 / 12700.0, bool_1: false);
			}
			base.shape.Class174_0.Dictionary_0 = null;
			Class175[] array = new Class175[1];
			GraphicsPath graphicsPath = DrawHelper.PathBegin();
			Class175 @class = new Class175(bool_1: true, Enum32.const_5);
			Class177 currentPathEndLocation = DrawHelper.MoveTo(base.double_5, base.double_0);
			currentPathEndLocation = DrawHelper.ArcTo(graphicsPath, base.double_8, base.hd2, base.cd4, base.cd2, currentPathEndLocation);
			currentPathEndLocation = DrawHelper.ArcTo(graphicsPath, this.double_37, this.double_23, this.double_41, this.double_44, currentPathEndLocation);
			DrawHelper.Close(graphicsPath);
			@class.List_0.Add(graphicsPath);
			array[0] = @class;
			base.shape.Class183_0.Class175_0 = array;
		}
	}
}
