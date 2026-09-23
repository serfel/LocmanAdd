using System;
using TXTextControl.Drawing;

namespace ns17
{
	internal class Class179
	{
		private double double_0 = -1.0;

		private double double_1 = -1.0;

		private double double_2 = -1.0;

		private double double_3 = -1.0;

		private bool bool_0;

		internal double Double_0
		{
			get
			{
				return this.double_1;
			}
			set
			{
				this.double_1 = value;
				this.double_3 = MeasuringHelper.Twips2EMU(this.double_1);
			}
		}

		internal double Double_1
		{
			get
			{
				return this.double_0;
			}
			set
			{
				this.double_0 = value;
				this.double_2 = MeasuringHelper.Twips2EMU(this.double_0);
			}
		}

		internal double Double_2
		{
			get
			{
				return this.double_3;
			}
			set
			{
				this.double_3 = value;
				this.double_1 = MeasuringHelper.EMU2Twips(this.double_3);
			}
		}

		internal double Double_3
		{
			get
			{
				return this.double_2;
			}
			set
			{
				this.double_2 = value;
				this.double_0 = MeasuringHelper.EMU2Twips(this.double_2);
			}
		}

		internal Class179(double double_4, double double_5, bool bool_1)
		{
			if (this.bool_0 = bool_1)
			{
				this.double_2 = double_4;
				this.double_3 = double_5;
				this.double_0 = (int)MeasuringHelper.EMU2Twips(this.double_2);
				this.double_1 = (int)MeasuringHelper.EMU2Twips(this.double_3);
			}
			else
			{
				this.double_0 = double_4;
				this.double_1 = double_5;
				this.double_2 = (int)MeasuringHelper.Twips2EMU(double_4);
				this.double_3 = (int)MeasuringHelper.Twips2EMU(double_5);
			}
		}

		internal void method_0(double double_4, double double_5)
		{
			this.double_0 += double_4;
			this.double_1 += double_5;
		}

		internal bool method_1(Class179 class179_0)
		{
			if (Math.Round(this.Double_1, MidpointRounding.ToEven) == Math.Round(class179_0.Double_1, MidpointRounding.ToEven))
			{
				return Math.Round(this.Double_0, MidpointRounding.ToEven) == Math.Round(class179_0.Double_0, MidpointRounding.ToEven);
			}
			return false;
		}
	}
}
