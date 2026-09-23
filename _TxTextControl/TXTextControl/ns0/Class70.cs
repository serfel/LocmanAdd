using System;

namespace ns0
{
	internal class Class70
	{
		private int int_0;

		private Class61.Enum6 enum6_0;

		private int int_1;

		private int int_2;

		internal string method_0(int int_3, int int_4, string string_0, Class61.Enum6 enum6_1)
		{
			this.int_2 = int_3;
			this.enum6_0 = enum6_1;
			this.int_0 = int_4;
			this.int_1 = string_0.Length;
			string text = "";
			text += this.method_4();
			text += this.method_5();
			switch (enum6_1)
			{
			case Class61.Enum6.const_0:
			{
				for (int j = 0; j < this.int_1; j++)
				{
					int int_5 = this.method_1(string_0[j]);
					int int_6 = -1;
					if (j < this.int_1 - 1)
					{
						j++;
						int_6 = this.method_1(string_0[j]);
					}
					text += this.method_6(int_5, int_6);
				}
				int num = 0;
				while (text.Length < int_4 && num < 4)
				{
					text += '0';
					num++;
				}
				while (text.Length % 8 > 0)
				{
					text += '0';
				}
				break;
			}
			case Class61.Enum6.const_1:
			{
				for (int i = 0; i < this.int_1; i++)
				{
					text += this.method_2(string_0[i]);
				}
				text += "0000";
				break;
			}
			}
			return this.method_3(text);
		}

		private int method_1(char char_0)
		{
			char[] array = new char[45]
			{
				'0', '1', '2', '3', '4', '5', '6', '7', '8', '9',
				'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j',
				'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't',
				'u', 'v', 'w', 'x', 'y', 'z', ' ', '$', '%', '*',
				'+', '-', '.', '/', ':'
			};
			int num = 0;
			while (true)
			{
				if (num < 45)
				{
					if (array[num] == char.ToLower(char_0))
					{
						break;
					}
					num++;
					continue;
				}
				return -1;
			}
			return num;
		}

		private string method_2(char char_0)
		{
			string text = "";
			text = Convert.ToString(char_0, 2);
			while (text.Length < 8)
			{
				text = '0' + text;
			}
			return text;
		}

		private string method_3(string string_0)
		{
			string text = string_0;
			bool flag = true;
			while (text.Length < this.int_0)
			{
				if (flag)
				{
					text += "11101100";
					flag = false;
				}
				else
				{
					text += "00010001";
					flag = true;
				}
			}
			return text;
		}

		private string method_4()
		{
			return this.enum6_0 switch
			{
				Class61.Enum6.const_0 => "0010", 
				Class61.Enum6.const_1 => "0100", 
				_ => "", 
			};
		}

		private string method_5()
		{
			string text = "";
			switch (this.enum6_0)
			{
			default:
				return "";
			case Class61.Enum6.const_0:
			{
				int num = 9;
				if (this.int_2 > 9)
				{
					num = 11;
				}
				if (this.int_2 > 26)
				{
					num = 13;
				}
				text = this.method_7(this.int_1);
				while (text.Length < num)
				{
					text = '0' + text;
				}
				return text;
			}
			case Class61.Enum6.const_1:
			{
				int num = 8;
				if (this.int_2 > 9)
				{
					num = 16;
				}
				text = this.method_7(this.int_1);
				while (text.Length < num)
				{
					text = '0' + text;
				}
				return text;
			}
			}
		}

		private string method_6(int int_3, int int_4)
		{
			string text = "";
			if (int_4 > -1)
			{
				int num = 0;
				num = int_3 * 45 + int_4;
				text = this.method_7(num);
				while (text.Length < 11)
				{
					text = '0' + text;
				}
				return text;
			}
			text = this.method_7(int_3);
			while (text.Length < 6)
			{
				text = '0' + text;
			}
			return text;
		}

		public string method_7(int int_3)
		{
			return Convert.ToString(int_3, 2);
		}
	}
}
