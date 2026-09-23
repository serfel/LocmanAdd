using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using TXTextControl.Barcode;

namespace ns0
{
	internal class Class59 : CodeGeneratorBase
	{
		public int int_0 = 1;

		public int int_1 = 1;

		public int int_2;

		private int int_3;

		private int int_4;

		private string[] string_0 = Class69.string_2;

		private string[] string_1 = Class69.string_1;

		private string[] string_2 = Class69.string_0;

		internal override void UpdateBarcodeSettings(Class38 p_bstSettings)
		{
			string text = ((p_bstSettings.Text != null) ? p_bstSettings.Text : "a");
			while (text.Length < p_bstSettings.UpperTextLength)
			{
				text += "a";
			}
			string text2 = p_bstSettings.String_1;
			Class37 barcodeImage = this.GetBarcodeImage(p_bstSettings, text);
			p_bstSettings.Single_0 = barcodeImage.float_0;
			p_bstSettings.Nullable_0 = barcodeImage.float_1;
			p_bstSettings.String_1 = text2;
		}

		internal override bool IsTextValid(string input, int p_iMaxLength)
		{
			if (input.Length >= 1 && input.Length <= p_iMaxLength)
			{
				string pattern = "[a-zA-Z0-9 ^\\xA1-\\xFE\\*\\-\\.!\"#$+%&'\\\\(),-:;<=>?\\[\\]\\{\\}\\@\\^_\\|\\~\\a\\b\\t\\n\\f\\r]{" + input.Length + "}";
				Regex regex = new Regex(pattern);
				if (regex.IsMatch(input))
				{
					return true;
				}
			}
			return false;
		}

		internal override Class37 GetBarcodeImage(Class38 p_bsSettings, string p_strText)
		{
			this.int_0 = 1;
			this.int_1 = 1;
			int[,] array = this.method_0(p_strText);
			Class77 @class = new Class77();
			Class37 result = @class.method_2(array, 1, this.int_0, this.int_1);
			p_bsSettings.String_1 = p_strText;
			return result;
		}

		public int[,] method_0(string string_3)
		{
			List<int> list = this.method_2(string_3);
			int count = list.Count;
			this.int_0 = 1;
			this.int_1 = 11;
			this.int_4 = 7;
			if (count > 3)
			{
				this.int_1 = 14;
			}
			if (count > 6)
			{
				this.int_1 = 17;
			}
			if (count > 9)
			{
				this.int_0 = 2;
				this.int_1 = 11;
				this.int_4 = 9;
			}
			if (count > 12)
			{
				this.int_1 = 14;
			}
			if (count > 18)
			{
				this.int_1 = 17;
				this.int_4 = 10;
			}
			if (count > 23)
			{
				this.int_1 = 20;
				this.int_4 = 11;
			}
			if (count > 28)
			{
				this.int_0 = 3;
				this.int_1 = 20;
				this.int_4 = 26;
			}
			if (count > 33)
			{
				this.int_0 = 3;
				this.int_1 = 26;
				this.int_4 = 32;
			}
			if (count > 45)
			{
				this.int_1 = 32;
				this.int_4 = 38;
			}
			if (count > 57)
			{
				this.int_1 = 38;
				this.int_4 = 44;
			}
			if (count > 69)
			{
				this.int_0 = 4;
				this.int_1 = 32;
				this.int_4 = 38;
			}
			if (count > 89)
			{
				this.int_1 = 38;
				this.int_4 = 44;
			}
			if (count > 107)
			{
				this.int_1 = 44;
				this.int_4 = 50;
			}
			if (count >= 125)
			{
				List<int> list2 = new List<int>();
				for (int i = 0; i < 125; i++)
				{
					list2.Add(list[i]);
				}
				list = list2;
			}
			this.int_3 = this.int_0;
			List<int> list3 = this.method_1(list);
			this.int_2 = this.int_3 * 17 + 20 + 1;
			if (this.int_3 >= 3)
			{
				this.int_2 += 10;
			}
			int[,] array = new int[this.int_2, this.int_1];
			int num = 0;
			for (int j = 0; j < this.int_1; j++)
			{
				for (int k = 0; k < this.int_2; k++)
				{
					if (k == this.int_2 - 1)
					{
						array[k, j] = 1;
						continue;
					}
					array[k, j] = list3[num];
					num++;
				}
			}
			return array;
		}

		private List<int> method_1(List<int> list_0)
		{
			Class69 @class = new Class69();
			int num = 0;
			int num2 = 0;
			int num3 = 0;
			int num4 = 0;
			switch (this.int_0)
			{
			case 1:
				switch (this.int_1)
				{
				case 17:
					num = 35;
					num2 = 35;
					num4 = 2;
					break;
				case 14:
					num = 7;
					num2 = 7;
					num4 = 1;
					break;
				case 11:
					num = 0;
					num2 = 8;
					break;
				case 28:
					num = 24;
					num2 = 32;
					break;
				case 24:
					num = 8;
					num2 = 16;
					num4 = 2;
					break;
				case 20:
					num = 18;
					num2 = 18;
					break;
				}
				break;
			case 2:
				switch (this.int_1)
				{
				case 14:
					num = 7;
					num2 = 7;
					num4 = 1;
					break;
				case 11:
					num = 0;
					num2 = 8;
					break;
				case 8:
					num = 0;
					num2 = 0;
					break;
				case 20:
					num = 18;
					num2 = 18;
					break;
				case 17:
					num = 35;
					num2 = 35;
					num4 = 2;
					break;
				case 26:
					num = 26;
					num2 = 34;
					num4 = 2;
					break;
				case 23:
					num = 8;
					num2 = 16;
					num4 = 2;
					break;
				}
				break;
			case 3:
				switch (this.int_1)
				{
				case 20:
					num = 0;
					num2 = 32;
					num3 = 16;
					break;
				case 15:
					num = 36;
					num2 = 36;
					num3 = 36;
					break;
				case 6:
					num = 0;
					num2 = 0;
					num3 = 0;
					break;
				case 8:
					num = 6;
					num2 = 6;
					num3 = 6;
					break;
				case 10:
					num = 14;
					num2 = 14;
					num4 = 2;
					num3 = 14;
					break;
				case 12:
					num = 24;
					num2 = 24;
					num3 = 24;
					break;
				case 32:
					num = 20;
					num2 = 36;
					num3 = 28;
					num4 = 2;
					break;
				case 26:
					num = 0;
					num2 = 16;
					num3 = 8;
					break;
				case 44:
					num = 0;
					num2 = 48;
					num3 = 24;
					break;
				case 38:
					num = 14;
					num2 = 46;
					num3 = 30;
					num4 = 2;
					break;
				}
				break;
			case 4:
				switch (this.int_1)
				{
				case 20:
					num = 0;
					num2 = 32;
					num3 = 16;
					break;
				case 15:
					num = 36;
					num2 = 36;
					num3 = 36;
					break;
				case 6:
					num = 0;
					num2 = 0;
					num3 = 0;
					break;
				case 8:
					num = 6;
					num2 = 6;
					num3 = 6;
					break;
				case 10:
					num = 14;
					num2 = 14;
					num4 = 2;
					num3 = 14;
					break;
				case 12:
					num = 24;
					num2 = 24;
					num3 = 24;
					break;
				case 32:
					num = 20;
					num2 = 36;
					num3 = 28;
					num4 = 2;
					break;
				case 26:
					num = 0;
					num2 = 16;
					num3 = 8;
					break;
				case 44:
					num = 0;
					num2 = 48;
					num3 = 24;
					break;
				case 38:
					num = 14;
					num2 = 46;
					num3 = 30;
					num4 = 2;
					break;
				}
				break;
			}
			List<int> list = new List<int>();
			_ = list_0.Count;
			while (list_0.Count < this.int_0 * this.int_1 - this.int_4)
			{
				list_0.Add(900);
			}
			int[] array = this.method_3(list_0);
			for (int num5 = array.Length - 1; num5 >= 0; num5--)
			{
				list_0.Add(array[num5]);
			}
			if (this.int_0 == 3 || this.int_0 == 4)
			{
				this.int_0++;
			}
			this.int_0 += 2;
			int num6 = 1;
			int num7 = 1;
			int num8 = 0;
			while (num8 < list_0.Count + 1)
			{
				try
				{
					int num9 = 0;
					string text = "";
					if (num8 == list_0.Count)
					{
						text = Class68.string_0[(num7 - 1 + num2) % 52];
						num8++;
					}
					else
					{
						num9 = list_0[num8];
						if (this.int_0 == 6)
						{
							if (num6 == 1)
							{
								text = Class68.string_0[(num7 - 1 + num) % 52];
							}
							else if (num6 == this.int_0)
							{
								text = Class68.string_0[(num7 - 1 + num2) % 52];
							}
							else if (num6 == 3)
							{
								text = Class68.string_1[(num7 - 1 + num3) % 52];
							}
							else
							{
								text = @class.method_1(num9, num7, num4);
								num8++;
							}
						}
						else if (this.int_0 == 7)
						{
							if (num6 == 1)
							{
								text = Class68.string_0[(num7 - 1 + num) % 52];
							}
							else if (num6 == this.int_0)
							{
								text = Class68.string_0[(num7 - 1 + num2) % 52];
							}
							else if (num6 == 4)
							{
								text = Class68.string_1[(num7 - 1 + num3) % 52];
							}
							else
							{
								text = @class.method_1(num9, num7, num4);
								num8++;
							}
						}
						else if (num6 == 1)
						{
							text = Class68.string_0[(num7 - 1 + num) % 52];
						}
						else if (num6 == this.int_0)
						{
							text = Class68.string_0[(num7 - 1 + num2) % 52];
						}
						else
						{
							text = @class.method_1(num9, num7, num4);
							num8++;
						}
					}
					for (int i = 0; i < text.Length; i++)
					{
						short item = 0;
						if (i % 2 == 0)
						{
							item = 1;
						}
						for (int num10 = int.Parse(string.Concat(text[i])); num10 > 0; num10--)
						{
							list.Add(item);
						}
					}
					num6++;
					if (num6 > this.int_0)
					{
						num6 = 1;
						num7++;
						if (num7 > this.int_1)
						{
							num7 = 1;
						}
					}
				}
				catch (Exception)
				{
				}
			}
			return list;
		}

		private List<int> method_2(string string_3)
		{
			List<int> list = new List<int>();
			string text = "0123456789&§§,:#-.$/+%*=^";
			string text2 = ";<>@[\\]_`~!§§§§§-§§§\"|§()?{}\u00b4";
			string text3 = "ABCDEFGHIJKLMNOPQRSTUVWXYZ ";
			char c = string_3[0];
			if (text2.Contains(string.Concat(c)))
			{
				c = 'A';
			}
			else if (c > '\u0080')
			{
				c = 'a';
			}
			if (!text3.Contains(string.Concat(char.ToUpper(c))) && c != ' ')
			{
				if (text.Contains(string.Concat(c)))
				{
					list.Add(28);
				}
			}
			else
			{
				list.Add(27);
			}
			foreach (char c2 in string_3)
			{
				int item = 0;
				if (c2 == ' ')
				{
					list.Add(26);
				}
				else if (c2 > '\u0080')
				{
					list.Add(913);
					item = c2;
					list.Add(item);
				}
				else if (text.Contains(string.Concat(c2)))
				{
					if (text3.Contains(string.Concat(c)))
					{
						list.Add(28);
					}
					else if (text3.Contains(string.Concat(char.ToUpper(c))))
					{
						list.Add(28);
					}
					for (int j = 0; j < text.Length; j++)
					{
						if (text[j].Equals(c2))
						{
							item = j;
							break;
						}
					}
					list.Add(item);
				}
				else if (text2.Contains(string.Concat(c2)))
				{
					list.Add(29);
					for (int k = 0; k < text2.Length; k++)
					{
						if (text2[k].Equals(c2))
						{
							item = k;
							break;
						}
					}
					list.Add(item);
				}
				else if (text3.Contains(string.Concat(c2)))
				{
					if (text3.Contains(string.Concat(char.ToUpper(c))))
					{
						list.Add(28);
						list.Add(28);
					}
					else if (text.Contains(string.Concat(c)))
					{
						list.Add(28);
					}
					item = c2 - 65;
					list.Add(item);
				}
				else if (text3.Contains(string.Concat(char.ToUpper(c2))))
				{
					if (text3.Contains(string.Concat(c)))
					{
						list.Add(27);
					}
					else if (text.Contains(string.Concat(c)))
					{
						list.Add(27);
					}
					item = c2 - 97;
					list.Add(item);
				}
				if (!text2.Contains(string.Concat(c2)) && c2 != ' ' && c2 < '\u0080')
				{
					c = c2;
				}
			}
			List<int> list2 = new List<int>();
			bool flag = false;
			for (int l = 0; l < list.Count; l += 2)
			{
				if (list[l] == 913)
				{
					list2.Add(list[l]);
					list2.Add(list[l + 1]);
					flag = true;
				}
				else if (l + 2 < list.Count && list[l + 1] == 913)
				{
					int num = list[l];
					int item2 = num * 30 + 29;
					list2.Add(item2);
					list2.Add(list[l + 1]);
					list2.Add(list[l + 2]);
					l++;
					flag = true;
				}
				if (!flag)
				{
					int num2 = list[l];
					int num3 = 29;
					if (l + 1 < list.Count)
					{
						num3 = list[l + 1];
					}
					int item3 = num2 * 30 + num3;
					list2.Add(item3);
				}
				flag = false;
			}
			return list2;
		}

		public int[] method_3(List<int> list_0)
		{
			int[] array = null;
			int[] array2 = null;
			switch (this.int_4)
			{
			case 32:
			{
				array = new int[32]
				{
					361, 575, 922, 525, 176, 586, 640, 321, 536, 742,
					677, 742, 687, 284, 193, 517, 273, 494, 263, 147,
					593, 800, 571, 320, 803, 133, 231, 390, 685, 330,
					63, 410
				};
				int[] array16 = new int[32];
				array2 = array16;
				break;
			}
			case 26:
			{
				array = new int[26]
				{
					443, 284, 887, 544, 788, 93, 477, 760, 331, 608,
					269, 121, 159, 830, 446, 893, 699, 245, 441, 454,
					325, 858, 131, 847, 764, 169
				};
				int[] array15 = new int[26];
				array2 = array15;
				break;
			}
			case 4:
			{
				array = new int[4] { 522, 568, 723, 809 };
				int[] array14 = new int[4];
				array2 = array14;
				break;
			}
			case 7:
			{
				array = new int[7] { 76, 925, 537, 597, 784, 691, 437 };
				int[] array13 = new int[7];
				array2 = array13;
				break;
			}
			case 8:
			{
				array = new int[8] { 237, 308, 436, 284, 646, 653, 428, 379 };
				int[] array12 = new int[8];
				array2 = array12;
				break;
			}
			case 9:
			{
				array = new int[9] { 567, 527, 622, 257, 289, 362, 501, 441, 205 };
				int[] array11 = new int[9];
				array2 = array11;
				break;
			}
			case 10:
			{
				array = new int[10] { 377, 457, 64, 244, 826, 841, 818, 691, 266, 612 };
				int[] array10 = new int[10];
				array2 = array10;
				break;
			}
			case 11:
			{
				array = new int[11]
				{
					462, 45, 565, 708, 825, 213, 15, 68, 327, 602,
					904
				};
				int[] array9 = new int[11];
				array2 = array9;
				break;
			}
			case 12:
			{
				array = new int[12]
				{
					597, 864, 757, 201, 646, 684, 347, 127, 388, 7,
					69, 851
				};
				int[] array8 = new int[12];
				array2 = array8;
				break;
			}
			case 13:
			{
				array = new int[13]
				{
					764, 713, 342, 384, 606, 583, 322, 592, 678, 204,
					184, 394, 692
				};
				int[] array7 = new int[13];
				array2 = array7;
				break;
			}
			case 15:
			{
				array = new int[15]
				{
					460, 829, 476, 109, 904, 664, 230, 5, 80, 74,
					550, 575, 147, 868, 642
				};
				int[] array6 = new int[15];
				array2 = array6;
				break;
			}
			case 50:
			{
				array = new int[50]
				{
					923, 797, 576, 875, 156, 706, 63, 81, 257, 874,
					411, 416, 778, 50, 205, 303, 188, 535, 909, 155,
					637, 230, 534, 96, 575, 102, 264, 233, 919, 593,
					865, 26, 579, 623, 766, 146, 10, 739, 246, 127,
					71, 244, 211, 477, 920, 876, 427, 820, 718, 435
				};
				int[] array5 = new int[50];
				array2 = array5;
				break;
			}
			case 44:
			{
				array = new int[44]
				{
					476, 36, 659, 848, 678, 64, 764, 840, 157, 915,
					470, 876, 109, 25, 632, 405, 417, 436, 714, 60,
					376, 97, 413, 706, 446, 21, 3, 773, 569, 267,
					272, 213, 31, 560, 231, 758, 103, 271, 572, 436,
					339, 730, 82, 285
				};
				int[] array4 = new int[44];
				array2 = array4;
				break;
			}
			case 38:
			{
				array = new int[38]
				{
					234, 228, 438, 848, 133, 703, 529, 721, 788, 322,
					280, 159, 738, 586, 388, 684, 445, 680, 245, 595,
					614, 233, 812, 32, 284, 658, 745, 229, 95, 689,
					920, 771, 554, 289, 231, 125, 117, 518
				};
				int[] array3 = new int[38];
				array2 = array3;
				break;
			}
			}
			for (int i = 0; i < list_0.Count; i++)
			{
				int num = (list_0[i] + array2[this.int_4 - 1]) % 929;
				int num3;
				int num4;
				for (int num2 = array2.Length - 1; num2 > 0; num2--)
				{
					num3 = num * array[num2] % 929;
					num4 = 929 - num3;
					array2[num2] = (array2[num2 - 1] + num4) % 929;
				}
				num3 = num * array[0] % 929;
				num4 = 929 - num3;
				array2[0] = num4 % 929;
			}
			for (int j = 0; j < array2.Length; j++)
			{
				if (array2[j] != 0)
				{
					array2[j] = 929 - array2[j];
				}
			}
			return array2;
		}
	}
}
