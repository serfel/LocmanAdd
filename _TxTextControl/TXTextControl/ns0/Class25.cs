using System;

namespace ns0
{
	[Serializable]
	internal class Class25
	{
		internal double double_0;

		internal double double_1;

		internal Class25()
		{
		}

		internal Class25(int int_0, int int_1)
		{
			this.double_0 = int_0;
			this.double_1 = int_1;
		}

		internal Class25(double double_2, double double_3)
		{
			this.double_0 = double_2;
			this.double_1 = double_3;
		}

		public override string ToString()
		{
			return "{Width=" + this.double_0 + ", Height=" + this.double_1 + "}";
		}
	}
}
