namespace ns0
{
	internal class Class31
	{
		internal double double_0;

		internal double double_1;

		internal double double_2;

		internal double double_3;

		internal Class32 Class32_0
		{
			get
			{
				return new Class32(this.double_0, this.double_1);
			}
			set
			{
				this.double_0 = value.double_0;
				this.double_1 = value.double_1;
			}
		}

		internal Class24 Class24_0
		{
			get
			{
				return new Class24(this.double_2, this.double_3);
			}
			set
			{
				this.double_2 = value.double_0;
				this.double_3 = value.double_1;
			}
		}

		internal Class31()
		{
		}

		internal Class31(double double_4, double double_5, double double_6, double double_7)
		{
			this.double_0 = double_4;
			this.double_1 = double_5;
			this.double_2 = double_6;
			this.double_3 = double_7;
		}

		internal Class31(Class33 class33_0, Class23 class23_0)
		{
			this.double_0 = class33_0.float_0;
			this.double_1 = class33_0.float_1;
			this.double_2 = class23_0.float_0;
			this.double_3 = class23_0.float_1;
		}
	}
}
