using System;

namespace ns0
{
	internal class Class77
	{
		internal float float_0 = 2f;

		internal Class37 method_0(char[,] char_0, int int_0)
		{
			int num = char_0.GetUpperBound(0) + 1;
			Class37 @class = new Class37(num, num);
			for (int i = 0; i < num; i++)
			{
				for (int j = 0; j < num; j++)
				{
					if (char_0[i, j] == '1')
					{
						@class.method_0(new Class30(i * int_0, j * int_0, int_0, int_0));
					}
				}
			}
			return @class;
		}

		internal Class37 method_1(int[,] int_0, int int_1, int int_2, int int_3)
		{
			int num = 0;
			int num2 = 0;
			int num3 = int_2 * 17 + 35;
			Class37 @class = new Class37(num3, int_3 * 3);
			int num4 = 0;
			for (int i = 0; i < num3; i++)
			{
				for (int j = 0; j < int_3; j++)
				{
					if (int_0[i, j] == 1)
					{
						num4 = ((i * int_1 + num > num4) ? (i * int_1 + num) : num4);
						@class.method_0(new Class30(i * int_1 + num, j * int_1 * 3 + num2, int_1, int_1 * 3));
					}
				}
			}
			num += int_1 * num3;
			@class.float_0 = num4 + int_1;
			return @class;
		}

		internal Class37 method_2(int[,] int_0, int int_1, int int_2, int int_3)
		{
			int upperBound = int_0.GetUpperBound(0);
			int upperBound2 = int_0.GetUpperBound(1);
			Class37 @class = new Class37(upperBound, upperBound2 * 3);
			for (int i = 0; i < upperBound; i++)
			{
				for (int j = 0; j < upperBound2; j++)
				{
					if (int_0[i, j] == 1)
					{
						@class.method_0(new Class30(i, j * 3, 1f, 3f));
					}
				}
			}
			return @class;
		}

		internal Class37 method_3(int[,] int_0)
		{
			int num = int_0.GetUpperBound(0) * 10;
			int num2 = num - 24;
			Class37 @class = new Class37(num, num2);
			float num3 = @class.float_0 / (float)int_0.GetUpperBound(0);
			float num4 = (int)(2.0 / Math.Sqrt(3.0) * (double)num3);
			float num5 = 0f;
			float num6 = 0f;
			int num7 = 1;
			float num8 = 0f;
			for (int i = 0; i < int_0.GetUpperBound(1); i++)
			{
				for (int j = 0; j < int_0.GetUpperBound(0); j++)
				{
					Class33[] array = new Class33[6];
					float num9 = (float)j * num3 + num5 + (float)num7;
					float num10 = (float)i * num4 + num4 * 1f / 4f + num6;
					array[0] = new Class33(num9 - 1f, num10 - 1f);
					num9 = (float)j * num3 + num3 * 1f / 2f + num5;
					num10 = (float)i * num4 + num6 + (float)num7;
					array[1] = new Class33(num9 - 1f, num10 - 1f);
					num9 = (float)j * num3 + num3 + num5 - (float)num7;
					num10 = (float)i * num4 + num4 * 1f / 4f + num6;
					array[2] = new Class33(num9 - 1f, num10 - 1f);
					num9 = (float)j * num3 + num3 + num5 - (float)num7;
					num10 = (float)i * num4 + num4 * 3f / 4f + num6;
					array[3] = new Class33(num9 - 1f, num10 - 1f);
					num9 = (float)j * num3 + num3 * 1f / 2f + num5;
					num10 = (float)i * num4 + num4 + num6 - (float)num7;
					array[4] = new Class33(num9 - 1f, num10 - 1f);
					num9 = (float)j * num3 + num5 + (float)num7;
					num10 = (float)i * num4 + num4 * 3f / 4f + num6;
					array[5] = new Class33(num9 - 1f, num10 - 1f);
					if (int_0[j, i] == 1)
					{
						@class.method_2(new Class28(array));
					}
					else if (int_0[j, i] == 3)
					{
						@class.method_2(new Class28(array));
					}
				}
				if (i % 2 == 1)
				{
					num5 = 0f;
				}
				else
				{
					num8 = (num5 = num3 * 1f / 2f);
				}
				num6 = (float)(i - 2) * (0f - num4) / 4f - num4 * 3f / 4f;
			}
			@class.float_0 += num8;
			num5 = 0f;
			num6 = 15f * (0f - num4) / 4f - num4 * 3f / 4f;
			double num11 = num4;
			double num12 = 2.3137254901960786 * (double)num4;
			double num13 = 3.6470588235294117 * (double)num4;
			double num14 = 4.96078431372549 * (double)num4;
			double num15 = 6.2745098039215685 * (double)num4;
			double num16 = 7.5882352941176467 * (double)num4;
			@class.method_1((float)(num16 / 2.0 - num15 / 2.0), new Class30((int)((double)(15f * num3 + num5 - num3 / 2f) - num16 / 2.0) - 1, (int)((double)(17f * num4 + num6) - num16 / 2.0) - 1, (int)num16, (int)num16));
			@class.method_1((float)(num14 / 2.0 - num13 / 2.0), new Class30((int)((double)(15f * num3 + num5 - num3 / 2f) - num14 / 2.0) - 1, (int)((double)(17f * num4 + num6) - num14 / 2.0) - 1, (int)num14, (int)num14));
			@class.method_1((float)(num12 / 2.0 - num11 / 2.0), new Class30((int)((double)(15f * num3 + num5 - num3 / 2f) - num12 / 2.0) - 1, (int)((double)(17f * num4 + num6) - num12 / 2.0) - 1, (int)num12, (int)num12));
			@class.float_0 -= 1f;
			return @class;
		}

		internal Class37 method_4(int[,] int_0, int int_1, int int_2)
		{
			Class37 @class = new Class37(int_2, int_2);
			for (int i = 0; i < int_2; i++)
			{
				for (int j = 0; j < int_2; j++)
				{
					if (int_0[i, j] != 0 && int_0[i, j] == 1)
					{
						@class.method_0(new Class30(i * int_1, j * int_1, int_1, int_1));
					}
				}
			}
			return @class;
		}

		internal Class37 method_5(int[,] int_0)
		{
			this.float_0 = 1f;
			float num = this.float_0;
			float num2 = this.float_0;
			int upperBound = int_0.GetUpperBound(0);
			Class37 @class = new Class37(upperBound + 1, upperBound + 1);
			for (int i = 0; i <= int_0.GetUpperBound(1); i++)
			{
				for (int j = 0; j <= int_0.GetUpperBound(0); j++)
				{
					if (int_0[j, i] == 1)
					{
						@class.method_0(new Class30((float)j * num, (float)i * num2, num, num2));
					}
				}
			}
			return @class;
		}
	}
}
