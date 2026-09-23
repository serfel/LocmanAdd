using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using TXTextControl.Barcode;

namespace ns0
{
	internal class Class60 : CodeGeneratorBase
	{
		internal static string string_0 = "ASCII";

		public double double_0 = 1.0;

		public double double_1 = 1.0;

		private string[] string_1 = Class69.string_2;

		private string[] string_2 = Class69.string_1;

		private string[] string_3 = Class69.string_0;

		private int int_0 = 1;

		private int[,] int_1;

		public int[] int_2 = new int[17]
		{
			1, 1, 1, 1, 1, 1, 1, 1, 0, 1,
			0, 1, 0, 1, 0, 0, 0
		};

		public int[] int_3 = new int[18]
		{
			1, 1, 1, 1, 1, 1, 1, 0, 1, 0,
			0, 0, 1, 0, 1, 0, 0, 1
		};

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
			this.double_0 = 1.0;
			this.double_1 = 1.0;
			int[,] array = this.method_0(p_strText);
			Class77 @class = new Class77();
			Class37 result = @class.method_1(array, 1, (int)this.double_0, (int)this.double_1);
			p_bsSettings.String_1 = p_strText;
			return result;
		}

		public int[,] method_0(string string_4)
		{
			List<int> list = this.method_2(string_4);
			int num = (int)(Math.Pow(Math.Pow(215.0, 2.0) + 204.0 * (double)(list.Count + 1 + 4) / 0.33, 0.5) / 102.0);
			this.double_0 = num;
			this.double_1 = (list.Count + 1 + 4) / num + 1;
			List<int> list2 = this.method_1(list);
			this.int_1 = new int[(int)(this.double_0 * 17.0) + 35, (int)this.double_1];
			int num2 = 0;
			for (int i = 0; (double)i < this.double_1; i++)
			{
				for (int j = 0; (double)j < this.double_0 * 17.0 + 35.0; j++)
				{
					if (j < 17)
					{
						this.int_1[j, i] = this.int_2[j];
						continue;
					}
					if ((double)j >= this.double_0 * 17.0 + 17.0)
					{
						this.int_1[j, i] = this.int_3[j - ((int)(this.double_0 * 17.0) + 17)];
						continue;
					}
					this.int_1[j, i] = list2[num2];
					num2++;
				}
			}
			return this.int_1;
		}

		private List<int> method_1(List<int> list_0)
		{
			Class69 @class = new Class69();
			List<int> list = new List<int>();
			int item = list_0.Count + 1;
			while ((double)list_0.Count < this.double_0 * this.double_1 - 5.0)
			{
				list_0.Add(900);
			}
			list_0.Reverse();
			list_0.Add(item);
			list_0.Reverse();
			int[] array = this.method_3(list_0);
			for (int num = array.Length - 1; num >= 0; num--)
			{
				list_0.Add(array[num]);
			}
			int[] array2 = new int[(int)this.double_1];
			int num2 = 1;
			for (int i = 0; i < array2.Length; i++)
			{
				switch (num2)
				{
				case 1:
					array2[i] = 30 * (i / 3) + ((int)this.double_1 - 1) / 3;
					num2++;
					break;
				case 2:
					array2[i] = 30 * (i / 3) + this.int_0 * 3 + ((int)this.double_1 - 1) % 3;
					num2++;
					break;
				case 3:
					array2[i] = 30 * (i / 3) + ((int)this.double_0 - 1);
					num2 = 1;
					break;
				}
			}
			int[] array3 = new int[(int)this.double_1];
			int num3 = 1;
			for (int j = 0; j < array3.Length; j++)
			{
				switch (num3)
				{
				case 1:
					array3[j] = 30 * (j / 3) + ((int)this.double_0 - 1);
					num3++;
					break;
				case 2:
					array3[j] = 30 * (j / 3) + ((int)this.double_1 - 1) / 3;
					num3++;
					break;
				case 3:
					array3[j] = 30 * (j / 3) + this.int_0 * 3 + ((int)this.double_1 - 1) % 3;
					num3 = 1;
					break;
				}
			}
			this.double_0 += 2.0;
			int num4 = 1;
			int num5 = 1;
			int num6 = 0;
			while (num6 < list_0.Count + 1)
			{
				int num7 = 0;
				string text = "";
				if (num4 > 1 && (double)num4 < this.double_0)
				{
					num7 = list_0[num6];
					num6++;
				}
				else if (num4 == 1)
				{
					num7 = array2[num5 - 1];
				}
				else if ((double)num4 == this.double_0)
				{
					num7 = array3[num5 - 1];
					if (num6 == list_0.Count)
					{
						num6++;
					}
				}
				text = @class.method_0(num7, num5);
				for (int k = 0; k < text.Length; k++)
				{
					short item2 = 0;
					if (k % 2 == 0)
					{
						item2 = 1;
					}
					for (int num8 = int.Parse(string.Concat(text[k])); num8 > 0; num8--)
					{
						list.Add(item2);
					}
				}
				num4++;
				if ((double)num4 > this.double_0)
				{
					num4 = 1;
					num5++;
					if ((double)num5 > this.double_1)
					{
						num5 = 1;
					}
				}
			}
			return list;
		}

		private List<int> method_2(string string_4)
		{
			List<int> list = new List<int>();
			string text = "0123456789&§§,:#-.$/+%*=^";
			string text2 = ";<>@[\\]_`~!§§§§§-§§§\"|§()?{}\u00b4";
			string text3 = "ABCDEFGHIJKLMNOPQRSTUVWXYZ ";
			char c = string_4[0];
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
			foreach (char c2 in string_4)
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

		private int[] method_3(List<int> list_0)
		{
			int[] array = new int[4] { 522, 568, 723, 809 };
			int[] array2 = new int[4];
			int[] array3 = array2;
			for (int i = 0; i < list_0.Count; i++)
			{
				int num = (list_0[i] + array3[3]) % 929;
				int num2 = num * array[3] % 929;
				int num3 = 929 - num2;
				array3[3] = (array3[2] + num3) % 929;
				num2 = num * array[2] % 929;
				num3 = 929 - num2;
				array3[2] = (array3[1] + num3) % 929;
				num2 = num * array[1] % 929;
				num3 = 929 - num2;
				array3[1] = (array3[0] + num3) % 929;
				num2 = num * array[0] % 929;
				num3 = 929 - num2;
				array3[0] = num3 % 929;
			}
			for (int j = 0; j < array3.Length; j++)
			{
				if (array3[j] != 0)
				{
					array3[j] = 929 - array3[j];
				}
			}
			return array3;
		}
	}
}
