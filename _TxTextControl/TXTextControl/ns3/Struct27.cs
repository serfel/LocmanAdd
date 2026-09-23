using System.Drawing;

namespace ns3
{
	internal struct Struct27
	{
		internal int int_0;

		internal int int_1;

		internal int int_2;

		internal int int_3;

		public int Int32_0 => this.int_2 - this.int_0;

		public int Int32_1 => this.int_3 - this.int_1;

		internal Struct27(int int_4, int int_5, int int_6, int int_7)
		{
			this.int_0 = int_4;
			this.int_1 = int_5;
			this.int_2 = int_6;
			this.int_3 = int_7;
		}

		internal Struct27(Rectangle rectangle_0)
		{
			this.int_0 = rectangle_0.Left;
			this.int_1 = rectangle_0.Top;
			this.int_2 = rectangle_0.Right;
			this.int_3 = rectangle_0.Bottom;
		}

		internal Rectangle method_0()
		{
			return new Rectangle(this.int_0, this.int_1, this.Int32_0, this.Int32_1);
		}
	}
}
