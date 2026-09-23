using System;
using System.Collections.Generic;

namespace ns0
{
	internal class Class71
	{
		public int[,] int_0;

		private int int_1;

		private int int_2;

		private int int_3;

		internal Class71(int int_4, int int_5, int int_6)
		{
			this.int_3 = int_6;
			this.int_2 = int_4;
			this.int_1 = int_5;
			this.int_0 = new int[int_5, int_5];
		}

		internal int[,] method_0(int[,] int_4)
		{
			int_4.GetLength(0);
			int_4.GetLength(1);
			List<int[,]> list = new List<int[,]>();
			int[] array = new int[8];
			int[,] item = this.method_10(int_4);
			list.Add(item);
			int[,] item2 = this.method_11(int_4);
			list.Add(item2);
			int[,] item3 = this.method_12(int_4);
			list.Add(item3);
			int[,] item4 = this.method_13(int_4);
			list.Add(item4);
			int[,] item5 = this.method_14(int_4);
			list.Add(item5);
			int[,] item6 = this.method_15(int_4);
			list.Add(item6);
			int[,] item7 = this.method_16(int_4);
			list.Add(item7);
			int[,] item8 = this.method_17(int_4);
			list.Add(item8);
			int num = 0;
			foreach (int[,] item9 in list)
			{
				array[num] = 0;
				for (int i = 0; i < this.int_1; i++)
				{
					int j = 0;
					int num2 = 0;
					while (j <= this.int_1 - 5)
					{
						if (item9[j, i] == item9[j + 1, i] && item9[j, i] == item9[j + 2, i] && item9[j, i] == item9[j + 3, i] && item9[j, i] == item9[j + 4, i])
						{
							array[num] += 3;
							num2 += 3;
							for (j += 4; j < this.int_1 - 1 && item9[j, i] == item9[j + 1, i]; j++)
							{
								array[num]++;
								num2++;
							}
						}
						else
						{
							j++;
						}
					}
				}
				for (int k = 0; k < this.int_1; k++)
				{
					int l = 0;
					int num3 = 0;
					while (l <= this.int_1 - 5)
					{
						if (item9[k, l] == item9[k, l + 1] && item9[k, l] == item9[k, l + 2] && item9[k, l] == item9[k, l + 3] && item9[k, l] == item9[k, l + 4])
						{
							array[num] += 3;
							num3 += 3;
							for (l += 4; l < this.int_1 - 1 && item9[k, l] == item9[k, l + 1]; l++)
							{
								array[num]++;
								num3++;
							}
						}
						else
						{
							l++;
						}
					}
				}
				int num4 = 0;
				for (int m = 1; m < this.int_1; m++)
				{
					for (int n = 1; n < this.int_1; n++)
					{
						if (item9[n, m] == item9[n - 1, m] && item9[n, m - 1] == item9[n, m] && item9[n - 1, m - 1] == item9[n, m])
						{
							num4 += 3;
						}
					}
				}
				array[num] += num4;
				int num5 = 0;
				int[] array2 = new int[11]
				{
					1, 0, 1, 1, 1, 0, 1, 0, 0, 0,
					0
				};
				int[] array3 = new int[11]
				{
					0, 0, 0, 0, 1, 0, 1, 1, 1, 0,
					1
				};
				int[] array4 = new int[15]
				{
					0, 0, 0, 0, 1, 0, 1, 1, 1, 0,
					1, 0, 0, 0, 0
				};
				for (int num6 = 0; num6 < this.int_1; num6++)
				{
					for (int num7 = 0; num7 < this.int_1; num7++)
					{
						if (num7 < this.int_1 - 10)
						{
							if (item9[num7, num6] == array2[0] && item9[num7 + 1, num6] == array2[1] && item9[num7 + 2, num6] == array2[2] && item9[num7 + 3, num6] == array2[3] && item9[num7 + 4, num6] == array2[4] && item9[num7 + 5, num6] == array2[5] && item9[num7 + 6, num6] == array2[6] && item9[num7 + 7, num6] == array2[7] && item9[num7 + 8, num6] == array2[8] && item9[num7 + 9, num6] == array2[9] && item9[num7 + 10, num6] == array2[10])
							{
								num5 += 40;
							}
							if (item9[num7, num6] == array3[0] && item9[num7 + 1, num6] == array3[1] && item9[num7 + 2, num6] == array3[2] && item9[num7 + 3, num6] == array3[3] && item9[num7 + 4, num6] == array3[4] && item9[num7 + 5, num6] == array3[5] && item9[num7 + 6, num6] == array3[6] && item9[num7 + 7, num6] == array3[7] && item9[num7 + 8, num6] == array3[8] && item9[num7 + 9, num6] == array3[9] && item9[num7 + 10, num6] == array3[10])
							{
								num5 += 40;
							}
						}
						if (num7 < this.int_1 - 14 && item9[num7, num6] == array4[0] && item9[num7 + 1, num6] == array4[1] && item9[num7 + 2, num6] == array4[2] && item9[num7 + 3, num6] == array4[3] && item9[num7 + 4, num6] == array4[4] && item9[num7 + 5, num6] == array4[5] && item9[num7 + 6, num6] == array4[6] && item9[num7 + 7, num6] == array4[7] && item9[num7 + 8, num6] == array4[8] && item9[num7 + 9, num6] == array4[9] && item9[num7 + 10, num6] == array4[10] && item9[num7 + 11, num6] == array4[11] && item9[num7 + 12, num6] == array4[12] && item9[num7 + 13, num6] == array4[13] && item9[num7 + 14, num6] == array4[14])
						{
							num5 += 40;
						}
					}
				}
				for (int num8 = 0; num8 < this.int_1; num8++)
				{
					for (int num9 = 0; num9 < this.int_1 - 10; num9++)
					{
						if (num9 < 6 && item9[num8, num9] == array4[0] && item9[num8, num9 + 1] == array4[1] && item9[num8, num9 + 2] == array4[2] && item9[num8, num9 + 3] == array4[3] && item9[num8, num9 + 4] == array4[4] && item9[num8, num9 + 5] == array4[5] && item9[num8, num9 + 6] == array4[6] && item9[num8, num9 + 7] == array4[7] && item9[num8, num9 + 8] == array4[8] && item9[num8, num9 + 9] == array4[9] && item9[num8, num9 + 10] == array4[10] && item9[num8, num9 + 11] == array4[11] && item9[num8, num9 + 12] == array4[12] && item9[num8, num9 + 13] == array4[13] && item9[num8, num9 + 14] == array4[14])
						{
							num5 += 40;
						}
						if (item9[num8, num9] == array2[0] && item9[num8, num9 + 1] == array2[1] && item9[num8, num9 + 2] == array2[2] && item9[num8, num9 + 3] == array2[3] && item9[num8, num9 + 4] == array2[4] && item9[num8, num9 + 5] == array2[5] && item9[num8, num9 + 6] == array2[6] && item9[num8, num9 + 7] == array2[7] && item9[num8, num9 + 8] == array2[8] && item9[num8, num9 + 9] == array2[9] && item9[num8, num9 + 10] == array2[10])
						{
							num5 += 40;
						}
						if (item9[num8, num9] == array3[0] && item9[num8, num9 + 1] == array3[1] && item9[num8, num9 + 2] == array3[2] && item9[num8, num9 + 3] == array3[3] && item9[num8, num9 + 4] == array3[4] && item9[num8, num9 + 5] == array3[5] && item9[num8, num9 + 6] == array3[6] && item9[num8, num9 + 7] == array3[7] && item9[num8, num9 + 8] == array3[8] && item9[num8, num9 + 9] == array3[9] && item9[num8, num9 + 10] == array3[10])
						{
							num5 += 40;
						}
					}
				}
				array[num] += num5;
				int num10 = 0;
				int num11 = 0;
				for (int num12 = 0; num12 < this.int_1; num12++)
				{
					for (int num13 = 0; num13 < this.int_1; num13++)
					{
						if (item9[num13, num12] == 1)
						{
							num11++;
						}
					}
				}
				float num14 = num11 / (this.int_1 * this.int_1);
				num14 = num14 * 100f - 50f;
				int num15 = (int)Math.Abs(num14);
				num10 = num15 * 2;
				array[num] += num10;
				num++;
			}
			int num16 = array[0];
			int num17 = 0;
			for (int num18 = 0; num18 < 8; num18++)
			{
				if (num16 > array[num18])
				{
					num16 = array[num18];
					num17 = num18;
				}
			}
			for (int num19 = 0; num19 < 2; num19++)
			{
				for (int num20 = 0; num20 < this.int_1; num20++)
				{
					if (int_4[num19, num20] == -1)
					{
						int_4[num19, num20] = 0;
					}
				}
			}
			return num17 switch
			{
				0 => this.method_10(int_4), 
				1 => this.method_11(int_4), 
				2 => this.method_12(int_4), 
				3 => this.method_13(int_4), 
				4 => this.method_14(int_4), 
				5 => this.method_15(int_4), 
				6 => this.method_16(int_4), 
				7 => this.method_17(int_4), 
				_ => null, 
			};
		}

		internal void method_1(int[,] int_4)
		{
			this.int_0 = new int[this.int_1, this.int_1];
			for (int i = 0; i < this.int_1; i++)
			{
				for (int j = 0; j < this.int_1; j++)
				{
					this.int_0[i, j] = int_4[i, j];
				}
			}
		}

		internal int[,] method_2(int[] int_4, int[,] int_5)
		{
			int[,] int_6 = int_5;
			int[] array = new int[6];
			int[] array2 = new int[2];
			int[] array3 = new int[7];
			int[] array4 = new int[7];
			int[] array5 = new int[2];
			int[] array6 = new int[6];
			for (int i = 0; i <= 5; i++)
			{
				array[i] = int_4[i];
				array4[i] = int_4[i];
			}
			array4[6] = int_4[6];
			array2[0] = int_4[6];
			array5[0] = int_4[7];
			array2[1] = int_4[7];
			array5[1] = int_4[8];
			array3[0] = int_4[8];
			for (int i = 9; i < 15; i++)
			{
				array3[i - 8] = int_4[i];
				array6[i - 9] = int_4[i];
			}
			int_6 = this.method_8(0, 8, bool_0: false, array, int_6);
			int_6 = this.method_8(7, 8, bool_0: false, array2, int_6);
			int_6 = this.method_8(this.int_1 - 7, 8, bool_0: false, array3, int_6);
			int_6 = this.method_8(8, 5, bool_0: true, array6, int_6);
			int_6 = this.method_8(8, 8, bool_0: true, array5, int_6);
			return this.method_8(8, this.int_1 - 1, bool_0: true, array4, int_6);
		}

		private int[,] method_3(int[,] int_4)
		{
			int[] array = null;
			switch (this.int_2)
			{
			case 7:
				array = new int[18]
				{
					0, 0, 1, 0, 1, 0, 0, 1, 0, 0,
					1, 1, 1, 1, 1, 0, 0, 0
				};
				break;
			case 8:
				array = new int[18]
				{
					0, 0, 1, 1, 1, 1, 0, 1, 1, 0,
					1, 0, 0, 0, 0, 1, 0, 0
				};
				break;
			case 9:
				array = new int[18]
				{
					1, 0, 0, 1, 1, 0, 0, 1, 0, 1,
					0, 1, 1, 0, 0, 1, 0, 0
				};
				break;
			case 10:
				array = new int[18]
				{
					1, 1, 0, 0, 1, 0, 1, 1, 0, 0,
					1, 0, 0, 1, 0, 1, 0, 0
				};
				break;
			case 11:
				array = new int[18]
				{
					0, 1, 1, 0, 1, 1, 1, 1, 1, 1,
					0, 1, 1, 1, 0, 1, 0, 0
				};
				break;
			case 12:
				array = new int[18]
				{
					0, 1, 0, 0, 0, 1, 1, 0, 1, 1,
					1, 0, 0, 0, 1, 1, 0, 0
				};
				break;
			case 13:
				array = new int[18]
				{
					1, 1, 1, 0, 0, 0, 1, 0, 0, 0,
					0, 1, 1, 0, 1, 1, 0, 0
				};
				break;
			case 14:
				array = new int[18]
				{
					1, 0, 1, 1, 0, 0, 0, 0, 0, 1,
					1, 0, 0, 1, 1, 1, 0, 0
				};
				break;
			case 15:
				array = new int[18]
				{
					0, 0, 0, 1, 0, 1, 0, 0, 1, 0,
					0, 1, 1, 1, 1, 1, 0, 0
				};
				break;
			case 16:
				array = new int[18]
				{
					0, 0, 0, 1, 1, 1, 1, 0, 1, 1,
					0, 1, 0, 0, 0, 0, 1, 0
				};
				break;
			case 17:
				array = new int[18]
				{
					1, 0, 1, 1, 1, 0, 1, 0, 0, 0,
					1, 0, 1, 0, 0, 0, 1, 0
				};
				break;
			case 18:
				array = new int[18]
				{
					1, 1, 1, 0, 1, 0, 0, 0, 0, 1,
					0, 1, 0, 1, 0, 0, 1, 0
				};
				break;
			case 19:
				array = new int[18]
				{
					0, 1, 0, 0, 1, 1, 0, 0, 1, 0,
					1, 0, 1, 1, 0, 0, 1, 0
				};
				break;
			case 20:
				array = new int[18]
				{
					0, 1, 1, 0, 0, 1, 0, 1, 1, 0,
					0, 1, 0, 0, 1, 0, 1, 0
				};
				break;
			case 21:
				array = new int[18]
				{
					1, 1, 0, 0, 0, 0, 0, 1, 0, 1,
					1, 0, 1, 0, 1, 0, 1, 0
				};
				break;
			case 22:
				array = new int[18]
				{
					1, 0, 0, 1, 0, 0, 1, 1, 0, 0,
					0, 1, 0, 1, 1, 0, 1, 0
				};
				break;
			case 23:
				array = new int[18]
				{
					0, 0, 1, 1, 0, 1, 1, 1, 1, 1,
					1, 0, 1, 1, 1, 0, 1, 0
				};
				break;
			case 24:
				array = new int[18]
				{
					0, 0, 1, 0, 0, 0, 1, 1, 0, 1,
					1, 1, 0, 0, 0, 1, 1, 0
				};
				break;
			case 25:
				array = new int[18]
				{
					1, 0, 0, 0, 0, 1, 1, 1, 1, 0,
					0, 0, 1, 0, 0, 1, 1, 0
				};
				break;
			case 26:
				array = new int[18]
				{
					1, 1, 0, 1, 0, 1, 0, 1, 1, 1,
					1, 1, 0, 1, 0, 1, 1, 0
				};
				break;
			case 27:
				array = new int[18]
				{
					0, 1, 1, 1, 0, 0, 0, 1, 0, 0,
					0, 0, 1, 1, 0, 1, 1, 0
				};
				break;
			case 28:
				array = new int[18]
				{
					0, 1, 0, 1, 1, 0, 0, 0, 0, 0,
					1, 1, 0, 0, 1, 1, 1, 0
				};
				break;
			case 29:
				array = new int[18]
				{
					1, 1, 1, 1, 1, 1, 0, 0, 1, 1,
					0, 0, 1, 0, 1, 1, 1, 0
				};
				break;
			case 30:
				array = new int[18]
				{
					1, 0, 1, 0, 1, 1, 1, 0, 1, 0,
					1, 1, 0, 1, 1, 1, 1, 0
				};
				break;
			case 31:
				array = new int[18]
				{
					0, 0, 0, 0, 1, 0, 1, 0, 0, 1,
					0, 0, 1, 1, 1, 1, 1, 0
				};
				break;
			case 32:
				array = new int[18]
				{
					1, 0, 1, 0, 1, 0, 1, 1, 1, 0,
					0, 1, 0, 0, 0, 0, 0, 1
				};
				break;
			case 33:
				array = new int[18]
				{
					0, 0, 0, 0, 1, 1, 1, 1, 0, 1,
					1, 0, 1, 0, 0, 0, 0, 1
				};
				break;
			case 34:
				array = new int[18]
				{
					0, 1, 0, 1, 1, 1, 0, 1, 0, 0,
					0, 1, 0, 1, 0, 0, 0, 1
				};
				break;
			case 35:
				array = new int[18]
				{
					1, 1, 1, 1, 1, 0, 0, 1, 1, 1,
					1, 0, 1, 1, 0, 0, 0, 1
				};
				break;
			case 36:
				array = new int[18]
				{
					1, 1, 0, 1, 0, 0, 0, 0, 1, 1,
					0, 1, 0, 0, 1, 0, 0, 1
				};
				break;
			case 37:
				array = new int[18]
				{
					0, 1, 1, 1, 0, 1, 0, 0, 0, 0,
					1, 0, 1, 0, 1, 0, 0, 1
				};
				break;
			case 38:
				array = new int[18]
				{
					0, 0, 1, 0, 0, 1, 1, 0, 0, 1,
					0, 1, 0, 1, 1, 0, 0, 1
				};
				break;
			case 39:
				array = new int[18]
				{
					1, 0, 0, 0, 0, 0, 1, 0, 1, 0,
					1, 0, 1, 1, 1, 0, 0, 1
				};
				break;
			case 40:
				array = new int[18]
				{
					1, 0, 0, 1, 0, 1, 1, 0, 0, 0,
					1, 1, 0, 0, 0, 1, 0, 1
				};
				break;
			}
			int num = int_4.GetUpperBound(0) + 1;
			if (this.int_2 > 6)
			{
				int num2 = num - 11;
				int num3 = 0;
				for (int i = 0; i < 6; i++)
				{
					for (int j = 0; j < 3; j++)
					{
						int_4[i, j + num2] = array[num3];
						num3++;
					}
				}
				num3 = 0;
				for (int k = 0; k < 6; k++)
				{
					for (int l = 0; l < 3; l++)
					{
						int_4[l + num2, k] = array[num3];
						num3++;
					}
				}
			}
			return int_4;
		}

		internal int[,] method_4(int[,] int_4)
		{
			int[,] array = int_4;
			for (int i = 0; i < this.int_1; i++)
			{
				for (int j = 0; j < this.int_1; j++)
				{
					array[i, j] = -1;
				}
			}
			array = this.method_5(3, 3, array);
			array = this.method_5(this.int_1 - 4, 3, array);
			array = this.method_5(3, this.int_1 - 4, array);
			int[] int_5 = new int[1] { 1 };
			int[] array2 = new int[1];
			int[] int_6 = array2;
			array = this.method_8(8, this.int_1 - 8, bool_0: false, int_5, array);
			array = this.method_8(this.int_1 - 8, 8, bool_0: false, int_6, array);
			array = this.method_7(array);
			int[] int_7 = new int[15]
			{
				0, 1, 0, 1, 1, 1, 0, 1, 1, 0,
				1, 1, 0, 1, 0
			};
			array = this.method_2(int_7, array);
			array = this.method_3(array);
			int[] int_8 = new int[6] { 6, 0, 0, 0, 0, 0 };
			switch (this.int_2)
			{
			case 2:
				int_8 = new int[6] { 6, 18, 0, 0, 0, 0 };
				break;
			case 3:
				int_8 = new int[6] { 6, 22, 0, 0, 0, 0 };
				break;
			case 4:
				int_8 = new int[6] { 6, 26, 0, 0, 0, 0 };
				break;
			case 5:
				int_8 = new int[6] { 6, 30, 0, 0, 0, 0 };
				break;
			case 6:
				int_8 = new int[6] { 6, 34, 0, 0, 0, 0 };
				break;
			case 7:
				int_8 = new int[6] { 6, 22, 38, 0, 0, 0 };
				break;
			case 8:
				int_8 = new int[6] { 6, 24, 42, 0, 0, 0 };
				break;
			case 9:
				int_8 = new int[6] { 6, 26, 46, 0, 0, 0 };
				break;
			case 10:
				int_8 = new int[6] { 6, 28, 50, 0, 0, 0 };
				break;
			case 11:
				int_8 = new int[6] { 6, 30, 54, 0, 0, 0 };
				break;
			case 12:
				int_8 = new int[6] { 6, 32, 58, 0, 0, 0 };
				break;
			case 13:
				int_8 = new int[6] { 6, 34, 62, 0, 0, 0 };
				break;
			case 14:
				int_8 = new int[6] { 6, 26, 46, 66, 0, 0 };
				break;
			case 15:
				int_8 = new int[6] { 6, 26, 48, 70, 0, 0 };
				break;
			case 16:
				int_8 = new int[6] { 6, 26, 50, 74, 0, 0 };
				break;
			case 17:
				int_8 = new int[6] { 6, 30, 54, 78, 0, 0 };
				break;
			case 18:
				int_8 = new int[6] { 6, 30, 56, 82, 0, 0 };
				break;
			case 19:
				int_8 = new int[6] { 6, 30, 58, 86, 0, 0 };
				break;
			case 20:
				int_8 = new int[6] { 6, 34, 62, 90, 0, 0 };
				break;
			case 21:
				int_8 = new int[6] { 6, 28, 50, 72, 94, 0 };
				break;
			case 22:
				int_8 = new int[6] { 6, 26, 50, 74, 98, 0 };
				break;
			case 23:
				int_8 = new int[6] { 6, 30, 54, 78, 102, 0 };
				break;
			case 24:
				int_8 = new int[6] { 6, 28, 54, 80, 106, 0 };
				break;
			case 25:
				int_8 = new int[6] { 6, 32, 58, 84, 110, 0 };
				break;
			case 26:
				int_8 = new int[6] { 6, 30, 58, 86, 114, 0 };
				break;
			case 27:
				int_8 = new int[6] { 6, 34, 62, 90, 118, 0 };
				break;
			case 28:
				int_8 = new int[6] { 6, 26, 50, 74, 98, 122 };
				break;
			case 29:
				int_8 = new int[6] { 6, 30, 54, 78, 102, 126 };
				break;
			case 30:
				int_8 = new int[6] { 6, 26, 52, 78, 104, 130 };
				break;
			case 31:
				int_8 = new int[6] { 6, 30, 56, 82, 108, 134 };
				break;
			case 32:
				int_8 = new int[6] { 6, 34, 60, 86, 112, 138 };
				break;
			case 33:
				int_8 = new int[6] { 6, 30, 58, 86, 114, 142 };
				break;
			case 34:
				int_8 = new int[6] { 6, 34, 62, 90, 118, 146 };
				break;
			case 35:
				int_8 = new int[7] { 6, 30, 54, 78, 102, 126, 150 };
				break;
			case 36:
				int_8 = new int[7] { 6, 24, 50, 76, 102, 128, 154 };
				break;
			case 37:
				int_8 = new int[7] { 6, 28, 54, 80, 106, 132, 158 };
				break;
			case 38:
				int_8 = new int[7] { 6, 32, 58, 84, 110, 136, 162 };
				break;
			case 39:
				int_8 = new int[7] { 6, 26, 54, 82, 110, 138, 166 };
				break;
			case 40:
				int_8 = new int[7] { 6, 30, 58, 86, 114, 142, 170 };
				break;
			}
			array = this.method_6(int_8, array);
			int num = 0;
			for (int k = 0; k < this.int_1; k++)
			{
				for (int l = 0; l < this.int_1; l++)
				{
					if (array[k, l] == -1)
					{
						num++;
					}
				}
			}
			return array;
		}

		private int[,] method_5(int int_4, int int_5, int[,] int_6)
		{
			int[] int_7 = new int[1] { 1 };
			int_6 = this.method_8(int_4, int_5, bool_0: false, int_7, int_6);
			int_6 = this.method_9(int_4 - 1, int_5 - 1, 3, bool_0: true, int_6);
			int_6 = this.method_9(int_4 - 2, int_5 - 2, 5, bool_0: false, int_6);
			int_6 = this.method_9(int_4 - 3, int_5 - 3, 7, bool_0: true, int_6);
			int_6 = this.method_9(int_4 - 4, int_5 - 4, 9, bool_0: false, int_6);
			return int_6;
		}

		private int[,] method_6(int[] int_4, int[,] int_5)
		{
			Stack<Class34> stack = new Stack<Class34>();
			for (int i = 0; i < int_4.Length; i++)
			{
				for (int j = 0; j < int_4.Length; j++)
				{
					if ((int_4[i] > 6 || (int_4[i] == 6 && int_4[i] < int_5.GetUpperBound(0) - 10 && int_4[j] < int_5.GetUpperBound(0) - 10)) && (int_4[j] > 6 || (int_4[j] == 6 && int_4[i] > 6 && int_4[j] < int_5.GetUpperBound(0) - 10 && int_4[i] < int_5.GetUpperBound(0) - 10)))
					{
						stack.Push(new Class34(int_4[i], int_4[j]));
					}
				}
			}
			int[] int_6 = new int[1] { 1 };
			while (stack.Count > 0)
			{
				Class34 @class = stack.Pop();
				int_5 = this.method_8(@class.int_0, @class.int_1, bool_0: false, int_6, int_5);
				int_5 = this.method_9(@class.int_0 - 1, @class.int_1 - 1, 3, bool_0: false, int_5);
				int_5 = this.method_9(@class.int_0 - 2, @class.int_1 - 2, 5, bool_0: true, int_5);
			}
			return int_5;
		}

		private int[,] method_7(int[,] int_4)
		{
			int num = this.int_1 - 16;
			int[] array = new int[num];
			for (int i = 0; i < num; i++)
			{
				if (i % 2 == 0)
				{
					array[i] = 1;
				}
				else
				{
					array[i] = 0;
				}
			}
			int_4 = this.method_8(8, 6, bool_0: false, array, int_4);
			int_4 = this.method_8(6, this.int_1 - 9, bool_0: true, array, int_4);
			return int_4;
		}

		private int[,] method_8(int int_4, int int_5, bool bool_0, int[] int_6, int[,] int_7)
		{
			for (int i = 0; i < int_6.Length; i++)
			{
				if (!bool_0)
				{
					int_7[int_4 + i, int_5] = int_6[i];
				}
				else
				{
					int_7[int_4, int_5 - i] = int_6[i];
				}
			}
			return int_7;
		}

		private int[,] method_9(int int_4, int int_5, int int_6, bool bool_0, int[,] int_7)
		{
			for (int i = int_4; i < int_6 + int_4; i++)
			{
				for (int j = int_5; j < int_6 + int_5; j++)
				{
					if ((j == int_5 || j == int_5 + int_6 - 1 || i == int_4 || i == int_4 + int_6 - 1) && i >= 0 && j >= 0 && i < this.int_1 && j < this.int_1)
					{
						if (bool_0)
						{
							int_7[i, j] = 1;
						}
						else
						{
							int_7[i, j] = 0;
						}
					}
				}
			}
			return int_7;
		}

		internal int[,] method_10(int[,] int_4)
		{
			int[,] array = (int[,])int_4.Clone();
			for (int i = 0; i < this.int_1; i++)
			{
				for (int j = 0; j < this.int_1; j++)
				{
					if (this.int_0[i, j] == -1 && (i + j) % 2 == 0)
					{
						if (array[i, j] == 0)
						{
							array[i, j] = 1;
						}
						else
						{
							array[i, j] = 0;
						}
					}
				}
			}
			int[] int_5 = null;
			if (this.int_3 == 3)
			{
				int_5 = new int[15]
				{
					0, 1, 1, 0, 1, 0, 1, 0, 1, 0,
					1, 1, 1, 1, 1
				};
			}
			else if (this.int_3 == 1)
			{
				int_5 = new int[15]
				{
					1, 1, 1, 0, 1, 1, 1, 1, 1, 0,
					0, 0, 1, 0, 0
				};
			}
			return this.method_2(int_5, array);
		}

		internal int[,] method_11(int[,] int_4)
		{
			int[,] array = (int[,])int_4.Clone();
			for (int i = 0; i < this.int_1; i++)
			{
				for (int j = 0; j < this.int_1; j++)
				{
					if (this.int_0[i, j] == -1 && j % 2 == 0)
					{
						if (array[i, j] == 0)
						{
							array[i, j] = 1;
						}
						else
						{
							array[i, j] = 0;
						}
					}
				}
			}
			int[] int_5 = null;
			if (this.int_3 == 3)
			{
				int_5 = new int[15]
				{
					0, 1, 1, 0, 0, 0, 0, 0, 1, 1,
					0, 1, 0, 0, 0
				};
			}
			else if (this.int_3 == 1)
			{
				int_5 = new int[15]
				{
					1, 1, 1, 0, 0, 1, 0, 1, 1, 1,
					1, 0, 0, 1, 1
				};
			}
			return this.method_2(int_5, array);
		}

		internal int[,] method_12(int[,] int_4)
		{
			int[,] array = (int[,])int_4.Clone();
			for (int i = 0; i < this.int_1; i++)
			{
				for (int j = 0; j < this.int_1; j++)
				{
					if (this.int_0[i, j] == -1 && i % 3 == 0)
					{
						if (array[i, j] == 0)
						{
							array[i, j] = 1;
						}
						else
						{
							array[i, j] = 0;
						}
					}
				}
			}
			int[] int_5 = null;
			if (this.int_3 == 3)
			{
				int_5 = new int[15]
				{
					0, 1, 1, 1, 1, 1, 1, 0, 0, 1,
					1, 0, 0, 0, 1
				};
			}
			else if (this.int_3 == 1)
			{
				int_5 = new int[15]
				{
					1, 1, 1, 1, 1, 0, 1, 1, 0, 1,
					0, 1, 0, 1, 0
				};
			}
			return this.method_2(int_5, array);
		}

		internal int[,] method_13(int[,] int_4)
		{
			int[,] array = (int[,])int_4.Clone();
			for (int i = 0; i < this.int_1; i++)
			{
				for (int j = 0; j < this.int_1; j++)
				{
					if (this.int_0[i, j] == -1 && (j + i) % 3 == 0)
					{
						if (array[i, j] == 0)
						{
							array[i, j] = 1;
						}
						else
						{
							array[i, j] = 0;
						}
					}
				}
			}
			int[] int_5 = null;
			if (this.int_3 == 3)
			{
				int_5 = new int[15]
				{
					0, 1, 1, 1, 0, 1, 0, 0, 0, 0,
					0, 0, 1, 1, 0
				};
			}
			else if (this.int_3 == 1)
			{
				int_5 = new int[15]
				{
					1, 1, 1, 1, 0, 0, 0, 1, 0, 0,
					1, 1, 1, 0, 1
				};
			}
			return this.method_2(int_5, array);
		}

		internal int[,] method_14(int[,] int_4)
		{
			int[,] array = (int[,])int_4.Clone();
			for (int i = 0; i < this.int_1; i++)
			{
				for (int j = 0; j < this.int_1; j++)
				{
					if (this.int_0[i, j] == -1 && (j / 2 + i / 3) % 2 == 0)
					{
						if (array[i, j] == 0)
						{
							array[i, j] = 1;
						}
						else
						{
							array[i, j] = 0;
						}
					}
				}
			}
			int[] int_5 = null;
			if (this.int_3 == 3)
			{
				int_5 = new int[15]
				{
					0, 1, 0, 0, 1, 0, 0, 1, 0, 1,
					1, 0, 1, 0, 0
				};
			}
			else if (this.int_3 == 1)
			{
				int_5 = new int[15]
				{
					1, 1, 0, 0, 1, 1, 0, 0, 0, 1,
					0, 1, 1, 1, 1
				};
			}
			return this.method_2(int_5, array);
		}

		internal int[,] method_15(int[,] int_4)
		{
			int[,] array = (int[,])int_4.Clone();
			for (int i = 0; i < this.int_1; i++)
			{
				for (int j = 0; j < this.int_1; j++)
				{
					if (this.int_0[i, j] == -1 && j * i % 2 + j * i % 3 == 0)
					{
						if (array[i, j] == 0)
						{
							array[i, j] = 1;
						}
						else
						{
							array[i, j] = 0;
						}
					}
				}
			}
			int[] int_5 = null;
			if (this.int_3 == 3)
			{
				int_5 = new int[15]
				{
					0, 1, 0, 0, 0, 0, 1, 1, 0, 0,
					0, 0, 0, 1, 1
				};
			}
			else if (this.int_3 == 1)
			{
				int_5 = new int[15]
				{
					1, 1, 0, 0, 0, 1, 1, 0, 0, 0,
					1, 1, 0, 0, 0
				};
			}
			return this.method_2(int_5, array);
		}

		internal int[,] method_16(int[,] int_4)
		{
			int[,] array = (int[,])int_4.Clone();
			for (int i = 0; i < this.int_1; i++)
			{
				for (int j = 0; j < this.int_1; j++)
				{
					if (this.int_0[i, j] == -1 && (j * i % 2 + j * i % 3) % 2 == 0)
					{
						if (array[i, j] == 0)
						{
							array[i, j] = 1;
						}
						else
						{
							array[i, j] = 0;
						}
					}
				}
			}
			int[] int_5 = null;
			if (this.int_3 == 3)
			{
				int_5 = new int[15]
				{
					0, 1, 0, 1, 1, 1, 0, 1, 1, 0,
					1, 1, 0, 1, 0
				};
			}
			else if (this.int_3 == 1)
			{
				int_5 = new int[15]
				{
					1, 1, 0, 1, 1, 0, 0, 0, 1, 0,
					0, 0, 0, 0, 1
				};
			}
			return this.method_2(int_5, array);
		}

		internal int[,] method_17(int[,] int_4)
		{
			int[,] array = (int[,])int_4.Clone();
			for (int i = 0; i < this.int_1; i++)
			{
				for (int j = 0; j < this.int_1; j++)
				{
					if (this.int_0[i, j] == -1 && ((j + i) % 2 + j * i % 3) % 2 == 0)
					{
						if (array[i, j] == 0)
						{
							array[i, j] = 1;
						}
						else
						{
							array[i, j] = 0;
						}
					}
				}
			}
			int[] int_5 = null;
			if (this.int_3 == 3)
			{
				int_5 = new int[15]
				{
					0, 1, 0, 1, 0, 1, 1, 1, 1, 1,
					0, 1, 1, 0, 1
				};
			}
			else if (this.int_3 == 1)
			{
				int_5 = new int[15]
				{
					1, 1, 0, 1, 0, 0, 1, 0, 1, 1,
					1, 0, 1, 1, 0
				};
			}
			return this.method_2(int_5, array);
		}
	}
}
