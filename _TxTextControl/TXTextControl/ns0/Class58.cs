using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using TXTextControl.Barcode;

namespace ns0
{
	internal class Class58 : CodeGeneratorBase
	{
		private enum Enum4
		{
			const_0,
			const_1,
			const_2,
			const_3,
			const_4
		}

		private class Class67
		{
			public int int_0;

			public int int_1;

			public Class67(int int_2, int int_3)
			{
				this.int_0 = int_2;
				this.int_1 = int_3;
			}
		}

		private enum Enum5
		{
			const_0,
			const_1,
			const_2
		}

		private int int_0 = 31;

		private int int_1 = 34;

		private int int_2 = 64;

		private int int_3 = 67;

		private static char char_0 = '~';

		private static char char_1 = '~';

		private bool bool_0;

		private Enum5 enum5_0;

		private bool bool_1;

		private bool bool_2;

		private string string_0 = "";

		private string string_1 = "";

		private string string_2 = "";

		private int int_4;

		private string string_3 = "§ABCDEFGHIJKLMNOPQRSTUVWXYZ§§" + Class58.char_0 + Class58.char_1 + "§ §\"#$%&\u00b4()*+,-./0123456789:";

		private string string_4 = "\u00b4abcdefghijklmnopqrstuvwxyz§§" + Class58.char_0 + Class58.char_1 + "§{§}~§;<=>?[\\]^_ ,./:@!|";

		private char[] char_2;

		private char[] char_3;

		private char[] char_4;

		internal override void UpdateBarcodeSettings(Class38 p_bstSettings)
		{
			string text = ((p_bstSettings.Text != null) ? p_bstSettings.Text : "1");
			while (text.Length < p_bstSettings.UpperTextLength)
			{
				text += "1";
			}
			string text2 = p_bstSettings.String_1;
			Class37 barcodeImage = this.GetBarcodeImage(p_bstSettings, text);
			p_bstSettings.Single_0 = barcodeImage.float_0;
			p_bstSettings.Nullable_0 = barcodeImage.float_1;
			p_bstSettings.String_1 = text2;
		}

		internal override bool IsTextValid(string input, int p_iMaxLength)
		{
			if (input.Length >= 3 && input.Length <= p_iMaxLength)
			{
				string pattern = "[)>~[0-9]{2}~[0-9]{2}[0-9 ]{9}|[0-9A-Z ]{6}~[0-9]{3}~[0-9]{3}~[0-9A-Z*-.!\"#$+%&'\\\\(), -:;<=>?[]{}@^_|~\\a\\b\\t\\n\\f\\r]*";
				Regex regex = new Regex(pattern);
				if (input.Substring(0, 3) == "[)>")
				{
					if (regex.IsMatch(input))
					{
						return true;
					}
				}
				else
				{
					pattern = "[0-9]{3}~[0-9]{3}~[0-9A-Z ]{6}|[0-9 ]{9}~[0-9A-Z*-.!\"#$+%&'\\\\(), -:;<=>?[]{}@^_|~\\a\\b\\t\\n\\f\\r]*";
					regex = new Regex(pattern);
					if (regex.IsMatch(input))
					{
						return true;
					}
				}
			}
			return false;
		}

		internal override Class37 GetBarcodeImage(Class38 p_bsSettings, string p_strText)
		{
			int[,] array = this.method_1(p_strText);
			Class77 @class = new Class77();
			Class37 result = @class.method_3(array);
			p_bsSettings.String_1 = p_strText;
			return result;
		}

		private List<int> method_0(string string_5)
		{
			this.bool_2 = true;
			Enum4 @enum = Enum4.const_0;
			this.string_0 = "";
			this.string_1 = "";
			this.string_2 = "";
			Enum4 enum2 = Enum4.const_0;
			if (string_5.Contains("[)>"))
			{
				for (int i = 5; i < Math.Min(26, string_5.Length); i++)
				{
					switch (@enum)
					{
					case Enum4.const_0:
						if (string_5[i].Equals(Class58.char_0))
						{
							enum2 = Enum4.const_2;
						}
						break;
					case Enum4.const_2:
						if (string_5[i] == Class58.char_0)
						{
							enum2 = Enum4.const_3;
						}
						else
						{
							this.string_0 += string_5[i];
						}
						break;
					case Enum4.const_3:
						if (string_5[i] == Class58.char_0)
						{
							enum2 = Enum4.const_4;
						}
						else
						{
							this.string_1 += string_5[i];
						}
						break;
					case Enum4.const_4:
						if (string_5[i] == Class58.char_0)
						{
							i = 30;
						}
						else
						{
							this.string_2 += string_5[i];
						}
						break;
					}
					@enum = enum2;
				}
				this.string_0 = this.string_0.Substring(2);
			}
			else
			{
				this.string_2 = string_5.Substring(0, 3);
				this.string_1 = string_5.Substring(4, 3);
				this.string_0 = "";
				bool flag = false;
				int num = 8;
				while (!flag)
				{
					if (!string_5[num].Equals('~'))
					{
						this.string_0 += string_5[num];
						num++;
					}
					else
					{
						flag = true;
					}
				}
			}
			this.bool_1 = false;
			if (Regex.IsMatch(this.string_0, "([A-Z ])", RegexOptions.IgnoreCase))
			{
				this.bool_1 = true;
			}
			if (this.bool_1)
			{
				while (this.string_0.Length < 6)
				{
					this.string_0 += ' ';
					this.int_4++;
				}
			}
			else
			{
				while (this.string_0.Length < 9)
				{
					this.string_0 = '0' + this.string_0;
					this.int_4++;
				}
			}
			if (string_5.Contains("[)>"))
			{
				int num2 = this.string_0.Length - this.int_4 + 1 + this.string_1.Length + 1 + this.string_2.Length + 1;
				string_5 = string_5.Substring(0, 9) + string_5.Substring(9 + num2);
			}
			else
			{
				string_5 = this.string_2 + this.string_1 + this.string_0;
			}
			List<int> list = new List<int>();
			string text = Convert.ToString(int.Parse(this.string_2), 2);
			while (text.Length < 10)
			{
				text = '0' + text;
			}
			string text2 = Convert.ToString(int.Parse(this.string_1), 2);
			while (text2.Length < 10)
			{
				text2 = '0' + text2;
			}
			list = this.method_2(this.string_0);
			string text3 = "";
			if (this.bool_1)
			{
				for (int num3 = list.Count - 1; num3 >= 0; num3--)
				{
					int num4 = list[num3];
					string text4 = Convert.ToString(int.Parse(string.Concat(num4)), 2);
					while (text4.Length < 6)
					{
						text4 = '0' + text4;
					}
					text3 += text4;
				}
			}
			else
			{
				for (int j = 0; j < list.Count; j++)
				{
					int num5 = list[j];
					string text5 = Convert.ToString(int.Parse(string.Concat(num5)), 2);
					while (text5.Length < 6)
					{
						text5 = '0' + text5;
					}
					text3 += text5;
				}
			}
			list = new List<int>();
			string text6 = "";
			if (this.bool_1)
			{
				text6 = text3.Substring(text3.Length - 2, 2) + "0011";
				text6 += text3.Substring(text3.Length - 8, 6);
				text6 += text3.Substring(text3.Length - 14, 6);
				text6 += text3.Substring(text3.Length - 20, 6);
				text6 += text3.Substring(text3.Length - 26, 6);
				text6 += text3.Substring(text3.Length - 32, 6);
				text6 += text2.Substring(text2.Length - 2, 2);
				text6 += text3.Substring(0, 4);
				text6 += text2.Substring(2, 6);
				text6 += text.Substring(6, 4);
				text6 += text2.Substring(0, 2);
				text6 += text.Substring(0, 6);
			}
			else
			{
				string text7 = Convert.ToString(int.Parse(string.Concat(this.string_0.Length)), 2);
				while (text7.Length < 6)
				{
					text7 = '0' + text7;
				}
				text6 = text3.Substring(text3.Length - 2, 2) + "0010";
				text6 += text3.Substring(text3.Length - 8, 6);
				text6 += text3.Substring(text3.Length - 14, 6);
				text6 += text3.Substring(text3.Length - 20, 6);
				text6 += text3.Substring(text3.Length - 26, 6);
				text6 += text7.Substring(text7.Length - 2, 2);
				text6 += text3.Substring(0, 4);
				text6 += text2.Substring(text2.Length - 2, 2);
				text6 += text7.Substring(0, 4);
				text6 += text2.Substring(2, 6);
				text6 += text.Substring(6, 4);
				text6 += text2.Substring(0, 2);
				text6 += text.Substring(0, 6);
			}
			_ = text6.Length;
			for (int k = 0; k < text6.Length; k += 6)
			{
				list.Add(Convert.ToInt32(text6.Substring(k, 6), 2));
			}
			this.bool_2 = false;
			return list;
		}

		public int[,] method_1(string string_5)
		{
			this.int_4 = 0;
			int[,] array = this.method_4();
			List<int> list = new List<int>();
			List<int> list2 = new List<int>();
			list = this.method_0(string_5);
			if (string_5.Contains("[)>"))
			{
				list2 = this.method_2(string_5.Substring(0, 9) + string_5.Substring(9 + this.string_0.Length + 1 + this.string_2.Length + 1 + this.string_1.Length + 1));
			}
			else
			{
				int num = 9;
				if (this.bool_1)
				{
					num = 6;
				}
				list2 = this.method_2(string_5.Substring(8 + num - this.int_4));
			}
			for (int i = 0; i < list2.Count; i++)
			{
				list.Add(list2[i]);
			}
			list2 = list;
			if (!this.bool_0 && list2.Count < 93)
			{
				list2.Add(63);
			}
			while (list2.Count < 93)
			{
				list2.Add(58);
			}
			switch (this.enum5_0)
			{
			case Enum5.const_0:
				list2.Add(58);
				break;
			case Enum5.const_1:
				list2.Add(58);
				break;
			case Enum5.const_2:
				list2.Insert(0, 4);
				break;
			}
			list2 = this.method_3(list2);
			List<string> list3 = new List<string>();
			for (int j = 0; j < list2.Count; j++)
			{
				string text = Convert.ToString(list2[j], 2).ToString();
				while (text.Length < 6)
				{
					text = '0' + text;
				}
				list3.Add(text);
			}
			string text2 = "";
			for (int k = 0; k < 9; k++)
			{
				text2 += list3[k];
			}
			Class67[] array2 = this.method_5();
			for (int l = 0; l < array2.Length; l++)
			{
				Class67 @class = array2[l];
				array[@class.int_0, @class.int_1] = short.Parse(string.Concat(text2[l]));
			}
			Class67[] array3 = new Class67[11]
			{
				new Class67(9, 12),
				new Class67(9, 18),
				new Class67(19, 21),
				new Class67(9, 21),
				new Class67(9, 9),
				new Class67(21, 12),
				new Class67(21, 18),
				new Class67(7, 18),
				new Class67(7, 12),
				new Class67(21, 9),
				new Class67(21, 21)
			};
			for (int m = 0; m < array3.Length; m++)
			{
				array[array3[m].int_0, array3[m].int_1] = short.Parse(string.Concat(list3[m + 9][0]));
				array[array3[m].int_0 - 1, array3[m].int_1] = short.Parse(string.Concat(list3[m + 9][1]));
				array[array3[m].int_0, array3[m].int_1 + 1] = short.Parse(string.Concat(list3[m + 9][2]));
				array[array3[m].int_0 - 1, array3[m].int_1 + 1] = short.Parse(string.Concat(list3[m + 9][3]));
				array[array3[m].int_0, array3[m].int_1 + 2] = short.Parse(string.Concat(list3[m + 9][4]));
				array[array3[m].int_0 - 1, array3[m].int_1 + 2] = short.Parse(string.Concat(list3[m + 9][5]));
			}
			int num2 = 2;
			int num3 = 0;
			int num4 = 0;
			int num5 = 1;
			for (int n = 20; n < 136; n++)
			{
				num2 = 2 * num5;
				if (array[num2 - 1, num3] == -2)
				{
					array[num2 - 1, num3] = short.Parse(string.Concat(list3[n][0]));
					array[num2 - 2, num3] = short.Parse(string.Concat(list3[n][1]));
					array[num2 - 1, num3 + 1] = short.Parse(string.Concat(list3[n][2]));
					array[num2 - 2, num3 + 1] = short.Parse(string.Concat(list3[n][3]));
					array[num2 - 1, num3 + 2] = short.Parse(string.Concat(list3[n][4]));
					array[num2 - 2, num3 + 2] = short.Parse(string.Concat(list3[n][5]));
				}
				else
				{
					n--;
				}
				if (num4 % 2 == 0)
				{
					num5++;
					if (num5 > 14)
					{
						num4++;
						num5 = 14;
						num3 = 3 * num4;
					}
				}
				else
				{
					num5--;
					if (num5 < 1)
					{
						num4++;
						num5 = 1;
						num3 = 3 * num4;
					}
				}
			}
			num2 = this.int_0 - 3;
			num3 = 1;
			for (int num6 = 136; num6 < 144; num6++)
			{
				array[num2, num3] = short.Parse(string.Concat(list3[num6][0]));
				array[num2 + 1, num3 + 1] = short.Parse(string.Concat(list3[num6][1]));
				array[num2, num3 + 1] = short.Parse(string.Concat(list3[num6][2]));
				array[num2, num3 + 2] = short.Parse(string.Concat(list3[num6][3]));
				array[num2 + 1, num3 + 3] = short.Parse(string.Concat(list3[num6][4]));
				array[num2, num3 + 3] = short.Parse(string.Concat(list3[num6][5]));
				num3 += 4;
			}
			int[,] array4 = new int[30, 33];
			for (int num7 = 0; num7 < 30; num7++)
			{
				for (int num8 = 0; num8 < 33; num8++)
				{
					array4[num7, num8] = array[num7, num8];
				}
			}
			return array4;
		}

		private List<int> method_2(string string_5)
		{
			List<int> list = new List<int>();
			if (string_5 != "")
			{
				bool flag = false;
				bool flag2 = true;
				char c = string_5[0];
				if (this.string_4.Contains(string.Concat(c)))
				{
					list.Add(63);
					flag2 = false;
				}
				for (int i = 0; i < string_5.Length; i++)
				{
					if (i <= string_5.Length - 9 && Regex.IsMatch(string_5.Substring(i, 9), "^([0-9]+$)", RegexOptions.IgnoreCase))
					{
						int num = int.Parse(string_5.Substring(i, 9));
						string text = Convert.ToString(num, 2);
						while (text.Length < 30)
						{
							text = '0' + text;
						}
						if (!this.bool_2)
						{
							list.Add(31);
						}
						list.Add(Convert.ToInt32(text.Substring(0, 6), 2));
						list.Add(Convert.ToInt32(text.Substring(6, 6), 2));
						list.Add(Convert.ToInt32(text.Substring(12, 6), 2));
						list.Add(Convert.ToInt32(text.Substring(18, 6), 2));
						list.Add(Convert.ToInt32(text.Substring(24, 6), 2));
						i += 8;
						continue;
					}
					char c2 = string_5[i];
					int item = 0;
					if (c2 == ' ')
					{
						if (flag)
						{
							item = 59;
						}
						if (this.string_3.Contains(string.Concat(c)))
						{
							item = 32;
						}
						if (this.string_4.Contains(string.Concat(c)))
						{
							item = 47;
						}
						if ((Array.IndexOf(this.char_2, c) > -1 || Array.IndexOf(this.char_3, c) > -1 || Array.IndexOf(this.char_4, c) > -1) && this.bool_0)
						{
							item = 47;
						}
					}
					else
					{
						if (this.string_3.Contains(string.Concat(c2)))
						{
							if (flag2 || (!flag2 && c2 != ',' && c2 != '.' && c2 != '\'' && c2 != ':'))
							{
								if (!flag2)
								{
									list.Add(63);
									flag2 = true;
								}
								else if (flag)
								{
									list.Add(58);
									flag = false;
								}
								for (int j = 0; j < this.string_3.Length; j++)
								{
									if (this.string_3[j].Equals(c2))
									{
										item = j;
										break;
									}
								}
							}
							this.bool_0 = false;
						}
						else if (this.string_4.Contains(string.Concat(c2)))
						{
							if (!flag2 || (flag2 && c2 != ',' && c2 != '.' && c2 != '\'' && c2 != ':'))
							{
								if (flag || flag2)
								{
									list.Add(63);
									flag = false;
									flag2 = false;
								}
								for (int k = 0; k < this.string_4.Length; k++)
								{
									if (this.string_4[k].Equals(c2))
									{
										item = k;
										break;
									}
								}
							}
							this.bool_0 = true;
						}
						else if (Array.IndexOf(this.char_2, c2) > -1)
						{
							if (Array.IndexOf(this.char_2, c) <= -1)
							{
								list.Add(63);
								flag = false;
							}
							else if (Array.IndexOf(this.char_2, c) > -1 && !flag)
							{
								list.Add(60);
								flag = true;
								this.bool_0 = false;
							}
							for (int l = 0; l < this.string_4.Length; l++)
							{
								if (this.char_2[l].Equals(c2))
								{
									item = l;
									break;
								}
							}
						}
						else if (Array.IndexOf(this.char_3, c2) > -1)
						{
							if (Array.IndexOf(this.char_3, c) <= -1)
							{
								list.Add(61);
								flag = false;
							}
							else if (Array.IndexOf(this.char_3, c) > -1 && !flag)
							{
								list.Add(61);
								flag = true;
								this.bool_0 = false;
							}
							for (int m = 0; m < this.char_3.Length; m++)
							{
								if (this.char_3[m].Equals(c2))
								{
									item = m;
									break;
								}
							}
						}
						else if (Array.IndexOf(this.char_4, c2) > -1)
						{
							if (Array.IndexOf(this.char_4, c) <= -1)
							{
								list.Add(62);
								flag = false;
							}
							else if (Array.IndexOf(this.char_4, c) > -1 && !flag)
							{
								list.Add(62);
								flag = true;
								this.bool_0 = false;
							}
							for (int n = 0; n < this.char_4.Length; n++)
							{
								if (this.char_4[n].Equals(c2))
								{
									item = n;
									break;
								}
							}
						}
						c = c2;
					}
					list.Add(item);
				}
			}
			return list;
		}

		private List<int> method_3(List<int> list_0)
		{
			Class76 @class = new Class76(this.int_2, this.int_3);
			int[] array = new int[20];
			int[] array2 = new int[62];
			int[] array3 = new int[62];
			for (int i = 0; i < 10; i++)
			{
				array[i] = list_0[i];
			}
			for (int j = 10; j < 94; j++)
			{
				if (j % 2 == 0)
				{
					array3[j / 2 - 5] = list_0[j];
				}
				else
				{
					array2[j / 2 - 5] = list_0[j];
				}
			}
			array = @class.method_3(array, 10, 10, this.int_2, this.int_3);
			array2 = @class.method_3(array2, 42, 20, this.int_2, this.int_3);
			array3 = @class.method_3(array3, 42, 20, this.int_2, this.int_3);
			list_0 = new List<int>();
			for (int k = 0; k < array.Length; k++)
			{
				list_0.Add(array[k]);
			}
			for (int l = 0; l < array3.Length; l++)
			{
				list_0.Add(array3[l]);
				list_0.Add(array2[l]);
			}
			return list_0;
		}

		private int[,] method_4()
		{
			int[,] array = new int[this.int_0, this.int_1];
			for (int i = 0; i < this.int_1; i++)
			{
				for (int j = 0; j < this.int_0; j++)
				{
					array[j, i] = -2;
					if (i % 2 == 1 && j == this.int_0 - 2)
					{
						array[j, i] = -1;
					}
				}
			}
			array[10, 9] = 3;
			array[11, 9] = 3;
			array[11, 10] = 3;
			array[17, 9] = 0;
			array[17, 10] = 0;
			array[18, 10] = 0;
			array[10, 22] = 3;
			array[11, 22] = 0;
			array[10, 23] = 3;
			array[17, 22] = 3;
			array[16, 23] = 0;
			array[17, 23] = 3;
			array[7, 15] = 3;
			array[7, 16] = 0;
			array[8, 16] = 3;
			array[20, 16] = 3;
			array[21, 16] = 0;
			array[20, 17] = 3;
			array[this.int_0 - 3, 0] = 1;
			array[this.int_0 - 2, 0] = 1;
			for (int k = 11; k < 17; k++)
			{
				array[k, 11] = -1;
				array[k, 21] = -1;
			}
			for (int l = 11; l < 18; l++)
			{
				array[l, 12] = -1;
				array[l, 20] = -1;
			}
			array[17, 20] = -1;
			for (int m = 10; m < 18; m++)
			{
				array[m, 13] = -1;
				array[m, 19] = -1;
			}
			for (int n = 10; n < 19; n++)
			{
				array[n, 14] = -1;
				array[n, 18] = -1;
			}
			for (int num = 9; num < 19; num++)
			{
				array[num, 15] = -1;
				array[num, 17] = -1;
			}
			for (int num2 = 9; num2 < 20; num2++)
			{
				array[num2, 16] = -1;
			}
			return array;
		}

		private Class67[] method_5()
		{
			return new Class67[54]
			{
				new Class67(19, 15),
				new Class67(19, 17),
				new Class67(16, 9),
				new Class67(16, 10),
				new Class67(17, 11),
				new Class67(16, 11),
				new Class67(13, 22),
				new Class67(12, 22),
				new Class67(13, 23),
				new Class67(12, 23),
				new Class67(17, 21),
				new Class67(16, 22),
				new Class67(13, 9),
				new Class67(12, 9),
				new Class67(13, 10),
				new Class67(12, 10),
				new Class67(10, 12),
				new Class67(10, 20),
				new Class67(18, 20),
				new Class67(19, 12),
				new Class67(18, 12),
				new Class67(19, 13),
				new Class67(18, 13),
				new Class67(19, 14),
				new Class67(15, 23),
				new Class67(14, 23),
				new Class67(19, 18),
				new Class67(19, 19),
				new Class67(18, 19),
				new Class67(19, 20),
				new Class67(8, 15),
				new Class67(8, 17),
				new Class67(10, 21),
				new Class67(11, 23),
				new Class67(15, 22),
				new Class67(14, 22),
				new Class67(15, 9),
				new Class67(14, 9),
				new Class67(15, 10),
				new Class67(14, 10),
				new Class67(10, 10),
				new Class67(10, 11),
				new Class67(21, 17),
				new Class67(19, 9),
				new Class67(18, 9),
				new Class67(19, 10),
				new Class67(19, 11),
				new Class67(18, 11),
				new Class67(6, 15),
				new Class67(6, 16),
				new Class67(7, 17),
				new Class67(6, 17),
				new Class67(21, 15),
				new Class67(20, 15)
			};
		}

		public Class58() : base()
		{
			char[] array = new char[60]
			{
				'À', 'Á', 'Â', 'Ã', 'Ä', 'Å', 'Æ', 'Ç', 'È', 'É',
				'Ê', 'Ì', 'Ì', 'Í', 'Î', 'Ï', 'Ð', 'Ñ', 'Ò', 'Ó',
				'Ô', 'Õ', 'Ö', '×', 'Ø', 'Ù', 'Ú', '§', '§', '\0',
				'\0', '§', 'Û', 'Ü', 'Ý', 'Þ', 'ß', 'ª', '¬', '±',
				'²', '³', 'µ', '¹', 'º', '¼', '½', '¾', '§', '§',
				'§', '§', '§', '§', '§', '§', '§', '§', '§', ' '
			};
			array[29] = Class58.char_0;
			array[30] = Class58.char_1;
			this.char_2 = array;
			char[] array2 = new char[60]
			{
				'à', 'á', 'â', 'ã', 'ä', 'å', 'æ', 'ç', 'è', 'é',
				'ê', 'ë', 'ì', 'í', 'î', 'ï', 'ð', 'ñ', 'ò', 'ó',
				'ô', 'õ', 'ö', '÷', 'ø', 'ù', 'ú', '§', '§', '\0',
				'\0', '§', 'û', 'ü', 'ý', 'þ', 'ÿ', '¡', '\u00a8', '«',
				'\u00af', '°', '\u00b4', '·', '\u00b8', '»', '¿', '§', '§', '§',
				'§', '§', '§', '§', '§', '§', '§', '§', '§', ' '
			};
			array2[29] = Class58.char_0;
			array2[30] = Class58.char_1;
			this.char_3 = array2;
			char[] array3 = new char[59]
			{
				'§', '§', '§', '§', '§', '§', '§', '§', '§', '§',
				'§', '§', '§', '§', '§', '§', '§', '§', '§', '§',
				'§', '§', '§', '§', '§', '§', '§', '§', '§', '§',
				'§', '§', '\0', '\0', '§', '§', '§', '¢', '£', '¤',
				'¥', '¦', '§', '©', '­', '®', '¶', '§', '§', '§',
				'§', '§', '§', '§', '§', '§', '§', '§', ' '
			};
			array3[32] = Class58.char_0;
			array3[33] = Class58.char_1;
			this.char_4 = array3;			
		}
	}
}
