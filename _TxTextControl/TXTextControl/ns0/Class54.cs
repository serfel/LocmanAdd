using System.Text.RegularExpressions;
using TXTextControl.Barcode;

namespace ns0
{
	internal class Class54 : CodeGeneratorBase
	{
		private static string string_0 = "";

		private string string_1 = "NWNNWNWNN";

		private char[] char_0 = new char[43]
		{
			'0', '1', '2', '3', '4', '5', '6', '7', '8', '9',
			'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J',
			'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T',
			'U', 'V', 'W', 'X', 'Y', 'Z', '-', '.', ' ', '$',
			'/', '+', '%'
		};

		internal override void UpdateBarcodeSettings(Class38 p_bstSettings)
		{
			string text = "012";
			while (text.Length < p_bstSettings.UpperTextLength)
			{
				text += '0';
			}
			string text2 = p_bstSettings.String_1;
			p_bstSettings.Single_0 = this.GetBarcodeImage(p_bstSettings, text).float_0;
			p_bstSettings.String_1 = text2;
		}

		internal override bool IsTextValid(string input, int p_iMaxLength)
		{
			if (input.Length >= 1 && input.Length <= p_iMaxLength)
			{
				string pattern = "[A-Z0-9 \\*\\-\\$\\&\\%\\.\\/\\+]{" + input.Length + "}";
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
			string text = Class54.string_0 + this.method_0(this.string_1);
			int num = 0;
			foreach (char char_ in p_strText)
			{
				int num2 = this.method_1(char_);
				num += num2;
				text += this.method_0(this.method_2(num2));
			}
			num %= 43;
			string text2 = this.method_0(this.method_2(num));
			if (p_bsSettings.Boolean_0)
			{
				text += text2;
			}
			text += this.method_0(this.string_1);
			text += Class54.string_0;
			Class64 @class = new Class64();
			Class37 result = @class.method_8(text, new Class19());
			p_bsSettings.String_1 = ((!p_bsSettings.Boolean_0 || !p_bsSettings.Boolean_1) ? p_strText : (p_strText + num));
			return result;
		}

		private string method_0(string string_2)
		{
			string text = "";
			bool flag = true;
			for (int i = 0; i < string_2.Length; i++)
			{
				if (string_2[i].Equals('N'))
				{
					if (flag)
					{
						text += "1";
						flag = false;
					}
					else
					{
						text += "0";
						flag = true;
					}
				}
				else if (flag)
				{
					text += "111";
					flag = false;
				}
				else
				{
					text += "000";
					flag = true;
				}
			}
			return text + "0";
		}

		private int method_1(char char_1)
		{
			int num = 0;
			while (true)
			{
				if (num < this.char_0.Length)
				{
					if (this.char_0[num].Equals(char.ToUpper(char_1)))
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

		private string method_2(int int_0)
		{
			return int_0 switch
			{
				0 => "NNNWWNWNN", 
				1 => "WNNWNNNNW", 
				2 => "NNWWNNNNW", 
				3 => "WNWWNNNNN", 
				4 => "NNNWWNNNW", 
				5 => "WNNWWNNNN", 
				6 => "NNWWWNNNN", 
				7 => "NNNWNNWNW", 
				8 => "WNNWNNWNN", 
				9 => "NNWWNNWNN", 
				10 => "WNNNNWNNW", 
				11 => "NNWNNWNNW", 
				12 => "WNWNNWNNN", 
				13 => "NNNNWWNNW", 
				14 => "WNNNWWNNN", 
				15 => "NNWNWWNNN", 
				16 => "NNNNNWWNW", 
				17 => "WNNNNWWNN", 
				18 => "NNWNNWWNN", 
				19 => "NNNNWWWNN", 
				20 => "WNNNNNNWW", 
				21 => "NNWNNNNWW", 
				22 => "WNWNNNNWN", 
				23 => "NNNNWNNWW", 
				24 => "WNNNWNNWN", 
				25 => "NNWNWNNWN", 
				26 => "NNNNNNWWW", 
				27 => "WNNNNNWWN", 
				28 => "NNWNNNWWN", 
				29 => "NNNNWNWWN", 
				30 => "WWNNNNNNW", 
				31 => "NWWNNNNNW", 
				32 => "WWWNNNNNN", 
				33 => "NWNNWNNNW", 
				34 => "WWNNWNNNN", 
				35 => "NWWNWNNNN", 
				36 => "NWNNNNWNW", 
				37 => "WWNNNNWNN", 
				38 => "NWWNNNWNN", 
				39 => "NWNWNWNNN", 
				40 => "NWNWNNNWN", 
				41 => "NWNNNWNWN", 
				42 => "NNNWNWNWN", 
				_ => "", 
			};
		}
	}
}
