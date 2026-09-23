namespace ns0
{
	internal class Class30
	{
		internal float float_0;

		internal float float_1;

		internal float float_2;

		internal float float_3;

		internal Class33 Class33_0
		{
			get
			{
				return new Class33(this.float_0, this.float_1);
			}
			set
			{
				this.float_0 = value.float_0;
				this.float_1 = value.float_1;
			}
		}

		internal Class23 Class23_0
		{
			get
			{
				return new Class23(this.float_2, this.float_3);
			}
			set
			{
				this.float_2 = value.float_0;
				this.float_3 = value.float_1;
			}
		}

		internal Class30()
		{
		}

		internal Class30(float float_4, float float_5, float float_6, float float_7)
		{
			this.float_0 = float_4;
			this.float_1 = float_5;
			this.float_2 = float_6;
			this.float_3 = float_7;
		}

		internal Class30(Class33 class33_0, Class23 class23_0)
		{
			this.float_0 = class33_0.float_0;
			this.float_1 = class33_0.float_1;
			this.float_2 = class23_0.float_0;
			this.float_3 = class23_0.float_1;
		}
	}
}
