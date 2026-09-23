using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using TXTextControl.Barcode;

namespace ns0
{
	internal class Class56 : CodeGeneratorBase
	{
		private enum Enum1
		{
			const_0,
			const_1,
			const_2,
			const_3,
			const_4
		}

		private enum Enum2
		{
			const_0,
			const_1,
			const_2,
			const_3,
			const_4
		}

		private enum Enum3
		{
			const_0,
			const_1
		}

		internal static string string_0 = "ASCII";

		private int int_0;

		private int int_1;

		private int int_2;

		private int int_3;

		private int int_4;

		private int int_5;

		private int int_6;

		private int int_7;

		private Enum3 enum3_0;

		private static int int_8 = 13728;

		private string string_1 = "\r\n!\"#$%&/'()*+,-.:;<=>?[]{}";

		private string string_2 = "@^_`|\\~\a\b\t\n\f\r";

		private char[] char_0 = new char[28]
		{
			'§', ' ', 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H',
			'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R',
			'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z'
		};

		private char[] char_1 = new char[28]
		{
			'§', ' ', 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h',
			'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r',
			's', 't', 'u', 'v', 'w', 'x', 'y', 'z'
		};

		private char[] char_2 = new char[27]
		{
			'§', ' ', '§', '§', '§', '§', '§', '\a', '\b', '\t',
			'\n', '§', '\f', '\r', '§', '§', '§', '§', '§', '§',
			'@', '\\', '^', '_', '`', '|', '~'
		};

		private char[] char_3 = new char[31]
		{
			'§', '\r', '\n', '§', '§', '§', '!', '"', '#', '$',
			'%', '&', '\'', '(', ')', '*', '+', ',', '-', '.',
			'/', ':', ';', '<', '=', '>', '?', '[', ']', '{',
			'}'
		};

		private char[] char_4 = new char[14]
		{
			'$', ' ', '0', '1', '2', '3', '4', '5', '6', '7',
			'8', '9', ',', '.'
		};

		private int int_9 = 28;

		private int int_10 = 31;

		private int int_11 = 48;

		private int int_12 = 63;

		internal override void UpdateBarcodeSettings(Class38 p_bstSettings)
		{
			this.int_6 = 64;
			this.int_7 = 67;
			this.enum3_0 = Enum3.const_0;
			this.int_3 = 6;
			this.int_9 = 28;
			string text = ((p_bstSettings.Text != null) ? p_bstSettings.Text : "A");
			while (text.Length < p_bstSettings.UpperTextLength)
			{
				text += "a";
			}
			string text2 = p_bstSettings.String_1;
			p_bstSettings.Single_0 = this.GetBarcodeImage(p_bstSettings, text).float_0;
			p_bstSettings.String_1 = text2;
		}

		internal override bool IsTextValid(string input, int p_iMaxLength)
		{
			if (input.Length >= 1 && input.Length <= p_iMaxLength)
			{
				string pattern = "[a-zA-Z0-9 \\r\\n\\*\\-\\.!\"#$%+&'\\\\(),-:;<=>?\\[\\]\\{\\}\\@\\^_\\|\\~\\a\\b\\t\\n\\f\\r]{" + input.Length + "}";
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
			this.int_6 = 64;
			this.int_7 = 67;
			this.enum3_0 = Enum3.const_0;
			this.int_3 = 6;
			this.int_9 = 28;
			new Class76(this.int_6, this.int_7);
			Class77 @class = new Class77();
			string text = this.method_8(p_strText);
			this.int_5 = text.Length * 100 / 77 + 3;
			if (this.int_5 >= Class56.int_8)
			{
				while (this.int_5 >= Class56.int_8)
				{
					p_strText = p_strText.Substring(0, p_strText.Length - p_strText.Length / 10);
					text = this.method_8(p_strText);
					this.int_5 = text.Length * 100 / 77 + 3;
				}
			}
			this.method_3();
			string[] array = this.method_6(text, this.int_3);
			this.int_4 = array.Length;
			int[] int_ = this.method_5(array, array.Length, this.int_2 - this.int_4, this.int_6, this.int_7);
			int[] int_2 = this.method_4();
			string text2 = this.method_2(int_2, int_);
			_ = text2.Length;
			char[,] array2 = this.method_1(text2);
			Class37 result = @class.method_0(array2, 1);
			p_bsSettings.String_1 = p_strText;
			return result;
		}

		private char[,] method_0()
		{
			char[,] array = new char[this.int_0, this.int_0];
			for (int i = 0; i < this.int_0; i++)
			{
				for (int j = 0; j < this.int_0; j++)
				{
					array[i, j] = '3';
				}
			}
			int num = this.int_0 / 2;
			for (int k = 0; k < 9; k++)
			{
				array[num - 4, num - 4 + k] = '1';
			}
			for (int l = 0; l < 5; l++)
			{
				array[num - 2, num - 2 + l] = '1';
			}
			for (int m = 0; m < 9; m++)
			{
				array[num + 4, num - 4 + m] = '1';
			}
			for (int n = 0; n < 5; n++)
			{
				array[num + 2, num - 2 + n] = '1';
			}
			for (int num2 = 0; num2 < 9; num2++)
			{
				array[num - 4 + num2, num - 4] = '1';
			}
			for (int num3 = 0; num3 < 5; num3++)
			{
				array[num - 2 + num3, num - 2] = '1';
			}
			for (int num4 = 0; num4 < 9; num4++)
			{
				array[num - 4 + num4, num + 4] = '1';
			}
			for (int num5 = 0; num5 < 5; num5++)
			{
				array[num - 2 + num5, num + 2] = '1';
			}
			array[num, num] = '1';
			if (this.enum3_0 == Enum3.const_0)
			{
				array[num - 5, num - 5] = '1';
				array[num - 4, num - 5] = '1';
				array[num - 5, num - 4] = '1';
				array[num - 5, num + 5] = '0';
				array[num - 4, num + 5] = '0';
				array[num - 5, num + 4] = '0';
				array[num + 5, num + 5] = '0';
				array[num + 4, num + 5] = '0';
				array[num + 5, num + 4] = '1';
				array[num + 5, num - 5] = '1';
				array[num + 4, num - 5] = '0';
				array[num + 5, num - 4] = '1';
			}
			else if (this.enum3_0 == Enum3.const_1)
			{
				for (int num6 = 0; num6 < 13; num6++)
				{
					array[num - 6 + num6, num - 6] = '1';
				}
				for (int num7 = 0; num7 < 13; num7++)
				{
					array[num - 6 + num7, num + 6] = '1';
				}
				for (int num8 = 0; num8 < 13; num8++)
				{
					array[num - 6, num - 6 + num8] = '1';
				}
				for (int num9 = 0; num9 < 13; num9++)
				{
					array[num + 6, num - 6 + num9] = '1';
				}
				array[num - 7, num - 7] = '1';
				array[num - 6, num - 7] = '1';
				array[num - 7, num - 6] = '1';
				array[num - 7, num + 7] = '0';
				array[num - 6, num + 7] = '0';
				array[num - 7, num + 6] = '0';
				array[num + 7, num + 7] = '0';
				array[num + 6, num + 7] = '0';
				array[num + 7, num + 6] = '1';
				array[num + 7, num - 7] = '1';
				array[num + 6, num - 7] = '0';
				array[num + 7, num - 6] = '1';
				int num10 = 1;
				for (int num11 = 0; num11 < this.int_0; num11++)
				{
					if (num11 % 2 == 0)
					{
						array[num11, num - 16] = '1';
					}
					else
					{
						array[num11, num - 16] = '0';
					}
				}
				for (int num12 = 0; num12 < this.int_0; num12++)
				{
					if (num12 % 2 == 0)
					{
						array[num12, num + 16] = '1';
					}
					else
					{
						array[num12, num + 16] = '0';
					}
				}
				for (int num13 = 0; num13 < this.int_0; num13++)
				{
					if (num13 % 2 == 0)
					{
						array[num - 16, num13] = '1';
					}
					else
					{
						array[num - 16, num13] = '0';
					}
				}
				for (int num14 = 0; num14 < this.int_0; num14++)
				{
					if (num14 % 2 == 0)
					{
						array[num + 16, num14] = '1';
					}
					else
					{
						array[num + 16, num14] = '0';
					}
				}
				if (this.int_1 >= 12)
				{
					num10++;
					for (int num15 = 0; num15 < this.int_0; num15++)
					{
						if (num15 % 2 == 0)
						{
							array[num15, num - this.int_10] = '1';
						}
						else
						{
							array[num15, num - this.int_10] = '0';
						}
					}
					for (int num16 = 0; num16 < this.int_0; num16++)
					{
						if (num16 % 2 == 0)
						{
							array[num16, num + this.int_10] = '1';
						}
						else
						{
							array[num16, num + this.int_10] = '0';
						}
					}
					for (int num17 = 0; num17 < this.int_0; num17++)
					{
						if (num17 % 2 == 0)
						{
							array[num - this.int_10, num17] = '1';
						}
						else
						{
							array[num - this.int_10, num17] = '0';
						}
					}
					for (int num18 = 0; num18 < this.int_0; num18++)
					{
						if (num18 % 2 == 0)
						{
							array[num + this.int_10, num18] = '1';
						}
						else
						{
							array[num + this.int_10, num18] = '0';
						}
					}
				}
				if (this.int_1 >= 20)
				{
					num10++;
					for (int num19 = 0; num19 < this.int_0; num19++)
					{
						if (num19 % 2 == 0)
						{
							array[num19, num - this.int_11] = '1';
						}
						else
						{
							array[num19, num - this.int_11] = '0';
						}
					}
					for (int num20 = 0; num20 < this.int_0; num20++)
					{
						if (num20 % 2 == 0)
						{
							array[num20, num + this.int_11] = '1';
						}
						else
						{
							array[num20, num + this.int_11] = '0';
						}
					}
					for (int num21 = 0; num21 < this.int_0; num21++)
					{
						if (num21 % 2 == 0)
						{
							array[num - this.int_11, num21] = '1';
						}
						else
						{
							array[num - this.int_11, num21] = '0';
						}
					}
					for (int num22 = 0; num22 < this.int_0; num22++)
					{
						if (num22 % 2 == 0)
						{
							array[num + this.int_11, num22] = '1';
						}
						else
						{
							array[num + this.int_11, num22] = '0';
						}
					}
				}
				if (this.int_1 >= 27)
				{
					num10++;
					for (int num23 = 0; num23 < this.int_0; num23++)
					{
						if (num23 % 2 == 0)
						{
							array[num23, num - this.int_12] = '1';
						}
						else
						{
							array[num23, num - this.int_12] = '0';
						}
					}
					for (int num24 = 0; num24 < this.int_0; num24++)
					{
						if (num24 % 2 == 0)
						{
							array[num24, num + this.int_12] = '1';
						}
						else
						{
							array[num24, num + this.int_12] = '0';
						}
					}
					for (int num25 = 0; num25 < this.int_0; num25++)
					{
						if (num25 % 2 == 0)
						{
							array[num - this.int_12, num25] = '1';
						}
						else
						{
							array[num - this.int_12, num25] = '0';
						}
					}
					for (int num26 = 0; num26 < this.int_0; num26++)
					{
						if (num26 % 2 == 0)
						{
							array[num + this.int_12, num26] = '1';
						}
						else
						{
							array[num + this.int_12, num26] = '0';
						}
					}
				}
				for (int num27 = 0; num27 < this.int_1 * 2 + num10; num27++)
				{
					if (num27 % 2 == 0)
					{
						array[num, num - 8 - num27] = '1';
					}
					else
					{
						array[num, num - 8 - num27] = '0';
					}
				}
				for (int num28 = 0; num28 < this.int_1 * 2 + num10; num28++)
				{
					if (num28 % 2 == 0)
					{
						array[num, num + 8 + num28] = '1';
					}
					else
					{
						array[num, num + 8 + num28] = '0';
					}
				}
				for (int num29 = 0; num29 < this.int_1 * 2 + num10; num29++)
				{
					if (num29 % 2 == 0)
					{
						array[num + 8 + num29, num] = '1';
					}
					else
					{
						array[num + 8 + num29, num] = '0';
					}
				}
				for (int num30 = 0; num30 < this.int_1 * 2 + num10; num30++)
				{
					if (num30 % 2 == 0)
					{
						array[num - 8 - num30, num] = '1';
					}
					else
					{
						array[num - 8 - num30, num] = '0';
					}
				}
			}
			return array;
		}

		private char[,] method_1(string string_3)
		{
			char[,] array = this.method_0();
			if (string_3 != "")
			{
				Enum1 @enum = Enum1.const_0;
				int num = this.int_0 / 2;
				int num2 = num - 4;
				int num3 = num - 5;
				int num4 = 4;
				if (this.enum3_0 == Enum3.const_1)
				{
					num2 -= 2;
					num3 -= 2;
					num4 = 6;
				}
				string text = string_3.Substring(0, this.int_9);
				for (int i = 0; i < text.Length; i++)
				{
					switch (@enum)
					{
					case Enum1.const_0:
						num2++;
						if (this.enum3_0 == Enum3.const_1 && num2 == num)
						{
							num2++;
						}
						if (num2 == num + num4)
						{
							num2++;
							num3 += 2;
							@enum = Enum1.const_1;
						}
						break;
					case Enum1.const_1:
						num3++;
						if (this.enum3_0 == Enum3.const_1 && num3 == num)
						{
							num3++;
						}
						if (num3 == num + num4)
						{
							num2 -= 2;
							num3++;
							@enum = Enum1.const_2;
						}
						break;
					case Enum1.const_2:
						num2--;
						if (this.enum3_0 == Enum3.const_1 && num2 == num)
						{
							num2--;
						}
						if (num2 == num - num4)
						{
							num2--;
							num3 -= 2;
							@enum = Enum1.const_3;
						}
						break;
					case Enum1.const_3:
						num3--;
						if (this.enum3_0 == Enum3.const_1 && num3 == num)
						{
							num3--;
						}
						if (num3 == num - num4)
						{
							num2++;
							num3 -= 2;
							@enum = Enum1.const_0;
						}
						break;
					}
					array[num2, num3] = text[i];
				}
				_ = string_3.Length;
				string text2 = string_3.Substring(this.int_9, string_3.Length - this.int_9);
				_ = text2.Length;
				int num5 = 1;
				num2 = num - 5;
				num3 = num - 6;
				int num6 = num + 7;
				int num7 = num + 7;
				int num8 = num - 7;
				int num9 = num - 7;
				if (this.enum3_0 == Enum3.const_1)
				{
					num2 -= 2;
					num3 -= 2;
					num6 += 2;
					num7 += 2;
					num8 -= 2;
					num9 -= 2;
				}
				@enum = Enum1.const_0;
				Stack<char> stack = new Stack<char>();
				string text3 = text2;
				foreach (char item in text3)
				{
					stack.Push(item);
				}
				_ = stack.Count;
				while (stack.Count > 0)
				{
					switch (@enum)
					{
					case Enum1.const_0:
						if (array[num2, num3] != '1' && array[num2, num3] != '0')
						{
							array[num2, num3] = stack.Pop();
							num3--;
							array[num2, num3] = stack.Pop();
							num3++;
							num2++;
							if (num2 > num6)
							{
								@enum = Enum1.const_1;
								num2 -= 2;
								num3++;
								num6 += 2;
							}
						}
						else
						{
							num2++;
						}
						break;
					case Enum1.const_1:
						if (array[num2, num3] != '1' && array[num2, num3] != '0')
						{
							array[num2, num3] = stack.Pop();
							num2++;
							array[num2, num3] = stack.Pop();
							num2--;
							num3++;
							if (num3 > num7)
							{
								@enum = Enum1.const_2;
								num3 -= 2;
								num2--;
								num7 += 2;
							}
						}
						else
						{
							num3++;
						}
						break;
					case Enum1.const_2:
						if (array[num2, num3] != '1' && array[num2, num3] != '0')
						{
							array[num2, num3] = stack.Pop();
							num3++;
							array[num2, num3] = stack.Pop();
							num3--;
							num2--;
							if (num2 < num8)
							{
								num3--;
								num2 += 2;
								num8 -= 2;
								@enum = Enum1.const_3;
							}
						}
						else
						{
							num2--;
						}
						break;
					case Enum1.const_3:
						if (array[num2, num3] != '1' && array[num2, num3] != '0')
						{
							array[num2, num3] = stack.Pop();
							num2--;
							array[num2, num3] = stack.Pop();
							num2++;
							num3--;
							if (num3 < num9)
							{
								num2--;
								num9 -= 2;
								@enum = Enum1.const_0;
								num5++;
								if (num5 == 5 || num5 == 12 || num5 == 20 || num5 == 27)
								{
									num9--;
									num8--;
									num6++;
									num7++;
									num3--;
								}
							}
						}
						else
						{
							num3--;
						}
						break;
					}
				}
			}
			return array;
		}

		private string method_2(int[] int_13, int[] int_14)
		{
			string text = "";
			for (int i = 0; i < int_13.Length; i++)
			{
				string text2 = Convert.ToString(int_13[i], 2);
				while (text2.Length < 4)
				{
					text2 = '0' + text2;
				}
				text += text2;
			}
			for (int j = 0; j < int_14.Length; j++)
			{
				string text3 = Convert.ToString(int_14[j], 2);
				while (text3.Length < this.int_3)
				{
					text3 = '0' + text3;
				}
				text += text3;
			}
			return text;
		}

		private void method_3()
		{
			if (this.int_5 <= 102)
			{
				this.int_0 = 15;
				this.int_2 = 17;
				this.int_3 = 6;
				this.int_1 = 1;
			}
			if (this.int_5 > 102)
			{
				this.int_0 = 19;
				this.int_2 = 40;
				this.int_3 = 6;
				this.int_1 = 2;
			}
			if (this.int_5 > 240)
			{
				this.int_0 = 23;
				this.int_2 = 51;
				this.int_3 = 8;
				this.int_1 = 3;
				this.int_6 = 256;
				this.int_7 = 301;
			}
			if (this.int_5 > 408)
			{
				this.int_0 = 27;
				this.int_2 = 76;
				this.int_1 = 4;
			}
			if (this.int_5 > 608)
			{
				this.enum3_0 = Enum3.const_1;
				this.int_9 = 40;
				this.int_0 = 37;
				this.int_2 = 120;
				this.int_1 = 5;
			}
			if (this.int_5 > 960)
			{
				this.int_0 = 41;
				this.int_2 = 156;
				this.int_1 = 6;
			}
			if (this.int_5 > 1248)
			{
				this.int_0 = 45;
				this.int_2 = 196;
				this.int_1 = 7;
			}
			if (this.int_5 > 1568)
			{
				this.int_0 = 49;
				this.int_2 = 240;
				this.int_1 = 8;
			}
			if (this.int_5 > 1920)
			{
				this.int_0 = 53;
				this.int_2 = 230;
				this.int_1 = 9;
				this.int_3 = 10;
				this.int_6 = 1024;
				this.int_7 = 1033;
			}
			if (this.int_5 > 2300)
			{
				this.int_0 = 57;
				this.int_2 = 272;
				this.int_1 = 10;
			}
			if (this.int_5 > 2720)
			{
				this.int_0 = 61;
				this.int_2 = 316;
				this.int_1 = 11;
			}
			if (this.int_5 > 3160)
			{
				this.int_0 = 67;
				this.int_2 = 364;
				this.int_1 = 12;
			}
			if (this.int_5 > 3640)
			{
				this.int_0 = 71;
				this.int_2 = 416;
				this.int_1 = 13;
			}
			if (this.int_5 > 4160)
			{
				this.int_0 = 75;
				this.int_2 = 470;
				this.int_1 = 14;
			}
			if (this.int_5 > 4700)
			{
				this.int_0 = 79;
				this.int_2 = 528;
				this.int_1 = 15;
			}
			if (this.int_5 > 5280)
			{
				this.int_0 = 83;
				this.int_2 = 588;
				this.int_1 = 16;
			}
			if (this.int_5 > 5880)
			{
				this.int_0 = 87;
				this.int_2 = 652;
				this.int_1 = 17;
			}
			if (this.int_5 > 6520)
			{
				this.int_0 = 91;
				this.int_2 = 720;
				this.int_1 = 18;
			}
			if (this.int_5 > 7200)
			{
				this.int_0 = 95;
				this.int_2 = 790;
				this.int_1 = 19;
			}
			if (this.int_5 > 7900)
			{
				this.int_0 = 101;
				this.int_2 = 864;
				this.int_1 = 20;
			}
			if (this.int_5 > 8640)
			{
				this.int_0 = 105;
				this.int_2 = 940;
				this.int_1 = 21;
			}
			if (this.int_5 > 9400)
			{
				this.int_0 = 109;
				this.int_2 = 1020;
				this.int_1 = 22;
			}
			if (this.int_5 > 10200)
			{
				this.int_0 = 113;
				this.int_2 = 920;
				this.int_1 = 23;
				this.int_3 = 12;
				this.int_6 = 4096;
				this.int_7 = 4201;
			}
			if (this.int_5 > 11040)
			{
				this.int_0 = 117;
				this.int_2 = 992;
				this.int_1 = 24;
			}
			if (this.int_5 > 11904)
			{
				this.int_0 = 121;
				this.int_2 = 1066;
				this.int_1 = 25;
			}
			if (this.int_5 > 12792)
			{
				this.int_0 = 125;
				this.int_2 = 1144;
				this.int_1 = 26;
			}
			if (this.int_5 > 13728)
			{
				this.int_0 = 131;
				this.int_2 = 1224;
				this.int_1 = 27;
			}
			if (this.int_5 > 14688)
			{
				this.int_0 = 135;
				this.int_2 = 1306;
				this.int_1 = 28;
			}
			if (this.int_5 > 15672)
			{
				this.int_0 = 139;
				this.int_2 = 1392;
				this.int_1 = 29;
			}
			if (this.int_5 > 16704)
			{
				this.int_0 = 143;
				this.int_2 = 1480;
				this.int_1 = 30;
			}
			if (this.int_5 > 17760)
			{
				this.int_0 = 147;
				this.int_2 = 1570;
				this.int_1 = 31;
			}
			if (this.int_5 > 18840)
			{
				this.int_0 = 151;
				this.int_2 = 1664;
				this.int_1 = 32;
			}
		}

		private int[] method_4()
		{
			int num = 2;
			int num2 = 6;
			int num3 = 7;
			if (this.enum3_0 == Enum3.const_1)
			{
				num = 5;
				num2 = 11;
				num3 = 10;
			}
			string text = Convert.ToString(this.int_1 - 1, 2);
			while (text.Length < num)
			{
				text = '0' + text;
			}
			string text2 = Convert.ToString(this.int_4 - 1, 2);
			while (text2.Length < num2)
			{
				text2 = '0' + text2;
			}
			_ = text + text2;
			string[] array = this.method_6(text + text2, 4);
			int num4 = array.Length;
			return this.method_5(array, num4, num3 - num4, 16, 19);
		}

		private int[] method_5(string[] string_3, int int_13, int int_14, int int_15, int int_16)
		{
			int[] array = null;
			int[] array2 = new int[string_3.Length];
			for (int i = 0; i < array2.Length; i++)
			{
				array2[i] = Convert.ToInt32(string_3[i], 2);
			}
			Class76 @class = new Class76(int_15, int_16);
			return @class.method_3(array2, int_13, int_14, int_15, int_16);
		}

		private string[] method_6(string string_3, int int_13)
		{
			int num = string_3.Length / int_13;
			if (string_3.Length % int_13 != 0)
			{
				num++;
			}
			string[] array = new string[num];
			int num2 = 0;
			for (int i = 0; i < num; i++)
			{
				for (int j = 0; j < int_13; j++)
				{
					if (i * int_13 + j >= string_3.Length + num2)
					{
						continue;
					}
					switch (this.int_3)
					{
					case 6:
					{
						if (array[i] == "00000")
						{
							array[i] = "000001";
							num2++;
							break;
						}
						if (array[i] == "11111")
						{
							array[i] = "111110";
							num2++;
							break;
						}
						string[] array4;
						string[] array5 = (array4 = array);
						int num5 = i;
						nint num6 = num5;
						array5[num5] = array4[num6] + string_3[i * int_13 + j - num2];
						break;
					}
					case 8:
					{
						if (array[i] == "0000000")
						{
							array[i] = "00000001";
							num2++;
							break;
						}
						if (array[i] == "1111111")
						{
							array[i] = "11111110";
							num2++;
							break;
						}
						string[] array8;
						string[] array9 = (array8 = array);
						int num9 = i;
						nint num10 = num9;
						array9[num9] = array8[num10] + string_3[i * int_13 + j - num2];
						break;
					}
					case 10:
					{
						if (array[i] == "000000000")
						{
							array[i] = "0000000001";
							num2++;
							break;
						}
						if (array[i] == "111111111")
						{
							array[i] = "1111111110";
							num2++;
							break;
						}
						string[] array6;
						string[] array7 = (array6 = array);
						int num7 = i;
						nint num8 = num7;
						array7[num7] = array6[num8] + string_3[i * int_13 + j - num2];
						break;
					}
					case 12:
					{
						if (array[i] == "00000000000")
						{
							array[i] = "000000000001";
							num2++;
							break;
						}
						if (array[i] == "11111111111")
						{
							array[i] = "111111111110";
							num2++;
							break;
						}
						string[] array2;
						string[] array3 = (array2 = array);
						int num3 = i;
						nint num4 = num3;
						array3[num3] = array2[num4] + string_3[i * int_13 + j - num2];
						break;
					}
					}
				}
				if (i == num - 1)
				{
					while (array[num - 1].Length < int_13)
					{
						string[] array10;
						string[] array11 = (array10 = array);
						int num11 = num - 1;
						nint num12 = num11;
						array11[num11] = array10[num12] + '1';
					}
				}
			}
			return array;
		}

		private int[] method_7(List<string> list_0)
		{
			int count = list_0.Count;
			int[] array = new int[count];
			for (int i = 0; i < count; i++)
			{
				string value = list_0[i];
				array[count - 1 - i] = Convert.ToInt32(value, 2);
			}
			return array;
		}

		private string method_8(string string_3)
		{
			List<string> list = new List<string>();
			Enum2 @enum = Enum2.const_0;
			Enum2 enum2 = Enum2.const_0;
			for (int i = 0; i < string_3.Length; i++)
			{
				Class65 @class = null;
				char c = string_3[i];
				if (c.Equals(' '))
				{
					@enum = ((!enum2.Equals(Enum2.const_0)) ? ((!enum2.Equals(Enum2.const_4)) ? Enum2.const_1 : Enum2.const_4) : Enum2.const_0);
				}
				else if (this.string_1.Contains(string.Concat(c)))
				{
					@enum = Enum2.const_3;
				}
				else if (char.IsDigit(c))
				{
					@enum = Enum2.const_4;
				}
				else if (this.string_2.Contains(string.Concat(c)))
				{
					@enum = Enum2.const_2;
				}
				else if (char.IsLower(c))
				{
					@enum = Enum2.const_1;
				}
				else if (char.IsUpper(c))
				{
					@enum = Enum2.const_0;
				}
				@class = this.method_10(c, @enum);
				if (!@enum.Equals(enum2))
				{
					list.Add(this.method_9(enum2, @enum));
				}
				this.method_9(enum2, @enum);
				_ = "encoded " + c + " as " + @class.int_0 + " in " + @class.string_0.ToString();
				list.Add(@class.string_0);
				if (@enum != Enum2.const_3)
				{
					enum2 = @enum;
				}
			}
			string text = string.Empty;
			foreach (string item in list)
			{
				text += item;
			}
			return text;
		}

		private string method_9(Enum2 enum2_0, Enum2 enum2_1)
		{
			string result = string.Empty;
			switch (enum2_0)
			{
			case Enum2.const_0:
				switch (enum2_1)
				{
				case Enum2.const_1:
					result = Convert.ToString(28, 2);
					break;
				case Enum2.const_2:
					result = Convert.ToString(29, 2);
					break;
				case Enum2.const_3:
					result = "00000";
					break;
				case Enum2.const_4:
					result = Convert.ToString(30, 2);
					break;
				}
				break;
			case Enum2.const_1:
				switch (enum2_1)
				{
				case Enum2.const_0:
					result = Convert.ToString(29, 2) + Convert.ToString(29, 2);
					break;
				case Enum2.const_2:
					result = Convert.ToString(29, 2);
					break;
				case Enum2.const_3:
					result = "00000";
					break;
				case Enum2.const_4:
					result = Convert.ToString(30, 2);
					break;
				}
				break;
			case Enum2.const_2:
				switch (enum2_1)
				{
				case Enum2.const_0:
					result = Convert.ToString(29, 2);
					break;
				case Enum2.const_1:
					result = Convert.ToString(28, 2);
					break;
				case Enum2.const_3:
					result = "00000";
					break;
				case Enum2.const_4:
					result = Convert.ToString(29, 2) + Convert.ToString(30, 2);
					break;
				}
				break;
			case Enum2.const_3:
				switch (enum2_1)
				{
				case Enum2.const_0:
					result = Convert.ToString(31, 2);
					break;
				case Enum2.const_1:
					result = Convert.ToString(31, 2) + Convert.ToString(28, 2);
					break;
				case Enum2.const_2:
					result = Convert.ToString(31, 2) + Convert.ToString(29, 2);
					break;
				case Enum2.const_4:
					result = Convert.ToString(31, 2) + Convert.ToString(30, 2);
					break;
				}
				break;
			case Enum2.const_4:
				switch (enum2_1)
				{
				case Enum2.const_0:
					result = "1110";
					break;
				case Enum2.const_1:
					result = "1110" + Convert.ToString(28, 2);
					break;
				case Enum2.const_2:
					result = "1110" + Convert.ToString(29, 2);
					break;
				case Enum2.const_3:
					result = "0000";
					break;
				}
				break;
			}
			return result;
		}

		private Class65 method_10(char char_5, Enum2 enum2_0)
		{
			int num = 0;
			switch (enum2_0)
			{
			case Enum2.const_0:
			{
				for (int j = 0; j < this.char_0.Length; j++)
				{
					if (this.char_0[j] == char_5)
					{
						num = j;
					}
				}
				break;
			}
			case Enum2.const_1:
			{
				for (int l = 0; l < this.char_1.Length; l++)
				{
					if (this.char_1[l].Equals(char_5))
					{
						num = l;
					}
				}
				break;
			}
			case Enum2.const_2:
			{
				for (int m = 0; m < this.char_2.Length; m++)
				{
					if (this.char_2[m] == char_5)
					{
						num = m;
						break;
					}
				}
				break;
			}
			case Enum2.const_3:
			{
				for (int k = 0; k < this.char_3.Length; k++)
				{
					if (this.char_3[k] == char_5)
					{
						num = k;
					}
				}
				break;
			}
			case Enum2.const_4:
			{
				for (int i = 0; i < this.char_4.Length; i++)
				{
					if (this.char_4[i].Equals(char_5))
					{
						num = i;
					}
				}
				break;
			}
			}
			string text = Convert.ToString(num, 2);
			int num2 = 5;
			if (enum2_0.Equals(Enum2.const_4))
			{
				num2 = 4;
			}
			while (text.Length < num2)
			{
				text = '0' + text;
			}
			return new Class65(num, text.ToString());
		}
	}
}
