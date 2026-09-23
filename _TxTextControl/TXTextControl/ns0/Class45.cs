using System.Text.RegularExpressions;
using TXTextControl.Barcode;

namespace ns0
{
	internal class Class45 : CodeGeneratorBase
	{
		private short short_0;

		private string string_0 = "";

		private string string_1 = "101";

		private string string_2 = "01010";

		internal override void UpdateBarcodeSettings(Class38 p_bstSettings)
		{
			string p_strText = "0123456";
			string text = p_bstSettings.String_1;
			p_bstSettings.Single_0 = this.GetBarcodeImage(p_bstSettings, p_strText).float_0;
			p_bstSettings.String_1 = text;
		}

		internal override bool IsTextValid(string input, int p_iMaxLength)
		{
			Regex regex = new Regex("^\\d{7}$");
			if (regex.IsMatch(input))
			{
				return true;
			}
			return false;
		}

		internal override Class37 GetBarcodeImage(Class38 p_bsSettings, string p_strText)
		{
			string text = this.string_0 + this.string_1;
			for (int i = 0; i < 4; i++)
			{
				short short_ = short.Parse(string.Concat(p_strText[i]));
				text += this.method_1(short_);
			}
			text += this.string_2;
			for (int j = 4; j < p_strText.Length; j++)
			{
				short short_2 = short.Parse(string.Concat(p_strText[j]));
				text += this.method_2(short_2);
			}
			this.short_0 = this.method_0(p_strText);
			text += this.method_2(this.short_0);
			text += this.string_1;
			text += this.string_0;
			Class64 @class = new Class64();
			Class37 result = @class.method_12(text, new Class6());
			p_bsSettings.String_1 = p_strText + this.short_0;
			return result;
		}

		private short method_0(string string_3)
		{
			int num = 0;
			for (int num2 = string_3.Length - 1; num2 >= 0; num2--)
			{
				num = ((num2 % 2 != 1) ? (num + 3 * short.Parse(string.Concat(string_3[num2]))) : (num + short.Parse(string.Concat(string_3[num2]))));
			}
			num %= 10;
			num = (10 - num) % 10;
			return (short)num;
		}

		private string method_1(short short_1)
		{
			return short_1 switch
			{
				0 => "0001101", 
				1 => "0011001", 
				2 => "0010011", 
				3 => "0111101", 
				4 => "0100011", 
				5 => "0110001", 
				6 => "0101111", 
				7 => "0111011", 
				8 => "0110111", 
				9 => "0001011", 
				_ => "", 
			};
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
	}
}
