namespace ns0
{
	internal class Class27
	{
		internal int int_0;

		internal int int_1;

		internal int int_2;

		internal int int_3;

		internal Class34 Class34_0
		{
			get
			{
				return new Class34(this.int_0, this.int_1);
			}
			set
			{
				this.int_0 = value.int_0;
				this.int_1 = value.int_1;
			}
		}

		internal Class25 Class25_0
		{
			get
			{
				return new Class25(this.int_2, this.int_3);
			}
			set
			{
				this.int_2 = (int)value.double_0;
				this.int_3 = (int)value.double_1;
			}
		}

		internal Class27()
		{
		}

		internal Class27(int int_4, int int_5, int int_6, int int_7)
		{
			this.int_0 = int_4;
			this.int_1 = int_5;
			this.int_2 = int_6;
			this.int_3 = int_7;
		}

		internal Class27(Class34 class34_0, Class25 class25_0)
		{
			this.int_0 = class34_0.int_0;
			this.int_1 = class34_0.int_1;
			this.int_2 = (int)class25_0.double_0;
			this.int_3 = (int)class25_0.double_1;
		}
	}
}
