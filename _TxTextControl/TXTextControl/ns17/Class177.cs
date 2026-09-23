using TXTextControl.Drawing;

namespace ns17
{
	internal class Class177
	{
		private double double_0;

		private double double_1;

		private double double_2;

		private double double_3;

		private bool bool_0;

		internal bool Boolean_0 => this.bool_0;

		internal double Double_0
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

		internal double Double_1
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

		internal double Double_2
		{
			get
			{
				return this.double_2;
			}
			set
			{
				this.double_2 = value;
				this.double_0 = (int)MeasuringHelper.EMU2Twips(this.double_2);
			}
		}

		internal double Double_3
		{
			get
			{
				return this.double_3;
			}
			set
			{
				this.double_3 = value;
				this.double_1 = (int)MeasuringHelper.EMU2Twips(this.double_3);
			}
		}

		internal Class177(double double_4, double double_5, bool bool_1)
		{
			if (this.bool_0 = bool_1)
			{
				this.double_2 = double_4;
				this.double_3 = double_5;
				this.double_0 = MeasuringHelper.EMU2Twips(this.double_2);
				this.double_1 = MeasuringHelper.EMU2Twips(this.double_3);
			}
			else
			{
				this.double_0 = double_4;
				this.double_1 = double_5;
				this.double_2 = MeasuringHelper.Twips2EMU(double_4);
				this.double_3 = MeasuringHelper.Twips2EMU(double_5);
			}
		}

		internal void method_0(double double_4, double double_5)
		{
			this.double_0 += double_4;
			this.double_1 += double_5;
			this.double_2 = MeasuringHelper.Twips2EMU(this.double_0);
			this.double_3 = MeasuringHelper.Twips2EMU(this.double_1);
		}

		internal void method_1(double double_4, double double_5)
		{
			this.double_2 += double_4;
			this.double_3 += double_5;
			this.double_0 = MeasuringHelper.EMU2Twips(this.double_2);
			this.double_1 = MeasuringHelper.EMU2Twips(this.double_3);
		}

		internal Class177 method_2()
		{
			return new Class177((int)this.double_2, (int)this.double_3, bool_1: true);
		}

		internal bool method_3(Class177 class177_0)
		{
			if (this.Double_0 == class177_0.Double_0)
			{
				return this.Double_1 == class177_0.Double_1;
			}
			return false;
		}
	}
}
