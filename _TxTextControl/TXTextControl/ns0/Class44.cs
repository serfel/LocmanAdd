using System.Text.RegularExpressions;
using TXTextControl.Barcode;

namespace ns0
{
	internal class Class44 : CodeGeneratorBase
	{
		public static string string_0 = "Country code: 1-3 digits for the country code\t\t\ncompany code: 4-7 digits for the company\t\narticle code: 13 - length(country code and company code)";

		private string string_1 = "";

		private string string_2 = "101";

		private string string_3 = "01010";

		private short short_0;

		internal override void UpdateBarcodeSettings(Class38 p_bstSettings)
		{
			string p_strText = "012345678912";
			string text = p_bstSettings.String_1;
			p_bstSettings.Single_0 = this.GetBarcodeImage(p_bstSettings, p_strText).float_0;
			p_bstSettings.String_1 = text;
		}

		internal override bool IsTextValid(string input, int p_iMaxLength)
		{
			Regex regex = new Regex("^\\d{12}$");
			if (regex.IsMatch(input))
			{
				return true;
			}
			return false;
		}

		internal override Class37 GetBarcodeImage(Class38 p_bsSettings, string p_strText)
		{
			string text = this.string_1 + this.string_2;
			short short_ = short.Parse(string.Concat(p_strText[0]));
			bool[] array = this.method_3(short_);
			text += this.method_1(short.Parse(string.Concat(p_strText[1])), bool_0: false);
			for (int i = 2; i <= 6; i++)
			{
				short short_2 = short.Parse(string.Concat(p_strText[i]));
				text += this.method_1(short_2, array[i - 2]);
			}
			text += this.string_3;
			for (int j = 7; j <= 11; j++)
			{
				short short_3 = short.Parse(string.Concat(p_strText[j]));
				text += this.method_2(short_3);
			}
			this.short_0 = this.method_0(p_strText);
			text += this.method_2(this.short_0);
			text += this.string_2;
			text += this.string_1;
			Class64 @class = new Class64();
			Class37 result = @class.method_14(text, new EAN13());
			p_bsSettings.String_1 = p_strText + this.short_0;
			return result;
		}

		private short method_0(string string_4)
		{
			int num = 0;
			for (int num2 = string_4.Length - 1; num2 >= 0; num2--)
			{
				num = ((num2 % 2 != 0) ? (num + 3 * short.Parse(string.Concat(string_4[num2]))) : (num + short.Parse(string.Concat(string_4[num2]))));
			}
			num %= 10;
			num = (10 - num) % 10;
			return (short)num;
		}

		private string method_1(short short_1, bool bool_0)
		{
			if (!bool_0)
			{
				switch (short_1)
				{
				case 0:
					return "0001101";
				case 1:
					return "0011001";
				case 2:
					return "0010011";
				case 3:
					return "0111101";
				case 4:
					return "0100011";
				case 5:
					return "0110001";
				case 6:
					return "0101111";
				case 7:
					return "0111011";
				case 8:
					return "0110111";
				case 9:
					return "0001011";
				}
			}
			else
			{
				switch (short_1)
				{
				case 0:
					return "0100111";
				case 1:
					return "0110011";
				case 2:
					return "0011011";
				case 3:
					return "0100001";
				case 4:
					return "0011101";
				case 5:
					return "0111001";
				case 6:
					return "0000101";
				case 7:
					return "0010001";
				case 8:
					return "0001001";
				case 9:
					return "0010111";
				}
			}
			return "";
		}

		private string method_2(short short_1)
		{
			return short_1 switch
			{
				0 => "1110010", 
				1 => "1100110", 
				2 => "1101100", 
				3 => "1000010", 
				4 => "1011100", 
				5 => "1001110", 
				6 => "1010000", 
				7 => "1000100", 
				8 => "1001000", 
				9 => "1110100", 
				_ => "", 
			};
		}

		private bool[] method_3(short short_1)
		{
			bool[] result = new bool[0];
			switch (short_1)
			{
			case 0:
			{
				bool[] array = new bool[5];
				result = array;
				break;
			}
			case 1:
				result = new bool[5] { false, true, false, true, true };
				break;
			case 2:
				result = new bool[5] { false, true, true, false, true };
				break;
			case 3:
				result = new bool[5] { false, true, true, true, false };
				break;
			case 4:
				result = new bool[5] { true, false, false, true, true };
				break;
			case 5:
				result = new bool[5] { true, true, false, false, true };
				break;
			case 6:
				result = new bool[5] { true, true, true, false, false };
				break;
			case 7:
				result = new bool[5] { true, false, true, false, true };
				break;
			case 8:
				result = new bool[5] { true, false, true, true, false };
				break;
			case 9:
				result = new bool[5] { true, true, false, true, false };
				break;
			}
			return result;
		}
	}
}
