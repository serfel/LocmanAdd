namespace ns0
{
	internal class Class63
	{
		internal int[] int_0;

		internal int int_1;

		internal short[] short_0;

		internal Class63(int[] int_2)
		{
			this.int_0 = int_2;
		}

		internal Class63(short[] short_1)
		{
			this.short_0 = short_1;
		}

		public override string ToString()
		{
			string text = "";
			short[] array = this.short_0;
			foreach (short num in array)
			{
				text += num;
			}
			return text;
		}
	}
}
