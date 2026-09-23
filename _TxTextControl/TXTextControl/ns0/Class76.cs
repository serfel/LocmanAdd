namespace ns0
{
	internal class Class76
	{
		private int[] int_0;

		private int[] int_1;

		private int method_0(int int_2, int int_3, int[] int_4, int[] int_5, int int_6)
		{
			if (int_2 != 0 && int_3 != 0)
			{
				return int_5[(int_4[int_2] + int_4[int_3]) % (int_6 - 1)];
			}
			return 0;
		}

		internal Class76(int int_2, int int_3)
		{
			this.int_0 = new int[int_2];
			this.int_1 = new int[int_2];
			this.int_0[0] = 1 - int_2;
			this.int_1[0] = 1;
			for (int i = 1; i < int_2; i++)
			{
				this.int_1[i] = this.int_1[i - 1] * 2;
				if (this.int_1[i] >= int_2)
				{
					this.int_1[i] ^= int_3;
				}
				this.int_0[this.int_1[i]] = i;
			}
		}

		internal int[] method_1()
		{
			return this.int_0;
		}

		internal int[] method_2()
		{
			return this.int_1;
		}

		internal int[] method_3(int[] int_2, int int_3, int int_4, int int_5, int int_6)
		{
			int[] array = new int[int_3 + int_4];
			for (int i = 0; i < int_3; i++)
			{
				array[i] = int_2[i];
			}
			int[] array2 = new int[int_5];
			int[] array3 = new int[int_5];
			array2[0] = 1 - int_5;
			array3[0] = 1;
			for (int i = 1; i < int_5; i++)
			{
				array3[i] = array3[i - 1] * 2;
				if (array3[i] >= int_5)
				{
					array3[i] ^= int_6;
				}
				array2[array3[i]] = i;
			}
			int[] array4 = new int[int_4 + 1];
			for (int i = 1; i <= int_4; i++)
			{
				array4[i] = 0;
			}
			array4[0] = 1;
			for (int i = 1; i <= int_4; i++)
			{
				array4[i] = array4[i - 1];
				for (int num = i - 1; num >= 1; num--)
				{
					array4[num] = array4[num - 1] ^ this.method_0(array4[num], array3[i], array2, array3, int_5);
				}
				array4[0] = this.method_0(array4[0], array3[i], array2, array3, int_5);
			}
			int[] array5 = new int[int_3 + int_4 + 1];
			for (int i = 0; i < int_3; i++)
			{
				array5[i] = array[i];
			}
			for (int i = int_3; i < int_3 + int_4; i++)
			{
				array5[i] = 0;
			}
			for (int i = 0; i < int_3; i++)
			{
				int int_7 = array5[int_3] ^ array5[i];
				for (int num = 0; num < int_4; num++)
				{
					int int_8 = array4[int_4 - num - 1];
					int num2 = this.method_0(int_7, int_8, array2, array3, int_5);
					array5[int_3 + num] = array5[int_3 + num + 1] ^ num2;
				}
			}
			int[] array6 = new int[array5.Length - 1];
			for (int i = 0; i < array6.Length; i++)
			{
				array6[i] = array5[i];
			}
			return array6;
		}
	}
}
