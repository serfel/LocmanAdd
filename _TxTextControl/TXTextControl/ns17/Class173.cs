using System.Collections.Generic;
using TXTextControl.Drawing;

namespace ns17
{
	internal class Class173
	{
		private Class178 class178_0;

		private double double_0;

		private double double_1;

		private double double_2 = 120.0;

		private double double_3 = 120.0;

		private List<AdjustObject> list_0 = new List<AdjustObject>();

		internal Class178 Class178_0 => this.class178_0;

		internal List<AdjustObject> List_0 => this.list_0;

		internal double Double_0
		{
			get
			{
				return this.double_3;
			}
			set
			{
				this.double_3 = value;
			}
		}

		internal double Double_1
		{
			get
			{
				return this.double_2;
			}
			set
			{
				this.double_2 = value;
			}
		}

		internal double Double_2
		{
			get
			{
				return this.double_0;
			}
			set
			{
				this.double_0 = value;
			}
		}

		internal double Double_3
		{
			get
			{
				return this.double_1;
			}
			set
			{
				this.double_1 = value;
			}
		}

		internal Class173(Class178 class178_1)
		{
			this.class178_0 = class178_1;
		}

		internal bool method_0(double double_4, double double_5)
		{
			if (this.double_0 <= double_4 && double_4 <= this.double_0 + this.double_2 && this.double_1 <= double_5 && double_5 <= this.double_1 + this.double_3)
			{
				return true;
			}
			return false;
		}

		internal void method_1(int int_0, Shape shape_0)
		{
			double num = shape_0.Class174_0.Class178_1.Double_3 / (shape_0.Class183_0.Class179_0.Double_3 / 12700.0);
			double num2 = shape_0.Class174_0.Class178_1.Double_2 / (shape_0.Class183_0.Class179_0.Double_2 / 12700.0);
			int num3 = (int)(MeasuringHelper.ZoomValue(shape_0.Class174_0.Class178_1.Double_0 + this.class178_0.Double_0 * num, int_0, viseVersa: false) - this.class178_0.Double_3 / 2.0);
			int num4 = (int)(MeasuringHelper.ZoomValue(shape_0.Class174_0.Class178_1.Double_1 + this.class178_0.Double_1 * num2, int_0, viseVersa: false) - this.class178_0.Double_2 / 2.0);
			if (shape_0.AutoSize && !Helper.IsShapeBoundsCrossingShape(shape_0.Type))
			{
				int num5 = (int)MeasuringHelper.ZoomValue(Helper.GetX(shape_0.Class174_0.Class178_1.Double_0, shape_0.Class174_0.Class178_1.Double_3), int_0, viseVersa: false);
				int num6 = (int)Helper.GetWidth(MeasuringHelper.ZoomValue(num, int_0, viseVersa: false));
				if (num3 < num5)
				{
					num3 = num5;
				}
				else if ((double)num3 + this.class178_0.Double_3 > (double)(num5 + num6))
				{
					num3 = num5 + num6 - (int)this.class178_0.Double_3;
				}
				int num7 = (int)MeasuringHelper.ZoomValue(Helper.GetY(shape_0.Class174_0.Class178_1.Double_1, shape_0.Class174_0.Class178_1.Double_2), int_0, viseVersa: false);
				int num8 = (int)Helper.GetHeight(MeasuringHelper.ZoomValue(num2, int_0, viseVersa: false));
				if (num4 < num7)
				{
					num4 = num7;
				}
				else if ((double)num4 + this.class178_0.Double_2 > (double)(num7 + num8))
				{
					num4 = num7 + num8 - (int)this.class178_0.Double_2;
				}
			}
			this.Double_2 = num3;
			this.Double_3 = num4;
		}
	}
}
