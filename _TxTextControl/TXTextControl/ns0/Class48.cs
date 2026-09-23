using System.Text.RegularExpressions;
using TXTextControl.Barcode;

namespace ns0
{
	internal class Class48 : CodeGeneratorBase
	{
		internal override void UpdateBarcodeSettings(Class38 p_bstSettings)
		{
			string text = "12345";
			while (text.Length < p_bstSettings.UpperTextLength)
			{
				text += "11";
			}
			string string_ = p_bstSettings.String_1;
			p_bstSettings.Single_0 = this.GetBarcodeImage(p_bstSettings, text).float_0;
			p_bstSettings.String_1 = string_;
		}

		internal override bool IsTextValid(string input, int p_iMaxLength)
		{
			if (input.Length == 5 || input.Length == 9 || input.Length == 11)
			{
				Regex regex = new Regex("\\b\\d{11}\\b|\\b\\d{9}\\b|\\b\\d{5}\\b");
				if (regex.IsMatch(input))
				{
					return true;
				}
			}
			return false;
		}

		internal override Class37 GetBarcodeImage(Class38 p_bsSettings, string p_strText)
		{
			int num = 0;
			string text = "1";
			foreach (char c in p_strText)
			{
				num += int.Parse(string.Concat(c));
				text += this.method_0(int.Parse(string.Concat(c)));
			}
			int j;
			for (j = num; j % 10 != 0; j++)
			{
			}
			num = j - num;
			text += this.method_0(num);
			text += "1";
			Class64 @class = new Class64();
			Class37 result = @class.method_6(text, new Class12());
			p_bsSettings.String_1 = (p_bsSettings.Boolean_1 ? (p_strText + num) : p_strText);
			return result;
		}

		private string method_0(int int_0)
		{
			return int_0 switch
			{
				0 => "11000", 
				1 => "00011", 
				2 => "00101", 
				3 => "00110", 
				4 => "01001", 
				5 => "01010", 
				6 => "01100", 
				7 => "10001", 
				8 => "10010", 
				9 => "10100", 
				_ => "", 
			};
		}
	}
}
