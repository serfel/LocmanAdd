using System.Text.RegularExpressions;
using TXTextControl.Barcode;

namespace ns0
{
	internal class Class53 : CodeGeneratorBase
	{
		public static string string_0 = "digits only, any length";

		private string string_1 = "11011010";

		private string string_2 = "11010110";

		private string string_3 = "";

		private string string_4;

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

		internal override Class37 GetBarcodeImage(Class38 p_bsSettings, string p_strText)
		{
			string text = this.string_3 + this.string_1;
			foreach (char c in p_strText)
			{
				text += this.method_1(short.Parse(string.Concat(c)));
			}
			this.method_0(p_strText);
			if (p_bsSettings.Boolean_0)
			{
				text += this.method_1(short.Parse(this.string_4));
			}
			text += this.string_2;
			text += this.string_3;
			Class64 @class = new Class64();
			Class37 result = @class.method_9(text, new Class17());
			p_bsSettings.String_1 = ((!p_bsSettings.Boolean_0 || !p_bsSettings.Boolean_1) ? p_strText : (p_strText + this.string_4));
			return result;
		}

		internal override bool IsTextValid(string input, int p_iMaxLength)
		{
			if (input.Length >= 1 && input.Length <= p_iMaxLength)
			{
				Regex regex = new Regex("\\d{" + input.Length + "}");
				if (regex.IsMatch(input))
				{
					return true;
				}
			}
			return false;
		}

		private void method_0(string string_5)
		{
			int num = 0;
			int num2 = 0;
			for (int num3 = string_5.Length - 1; num3 > 0; num3--)
			{
				if (num3 % 2 == 0)
				{
					num += int.Parse(string.Concat(string_5[num3]));
				}
				else
				{
					num2 += int.Parse(string.Concat(string_5[num3]));
				}
			}
			this.string_4 = ((10 - (3 * num + num2) % 10) % 10).ToString();
		}

		private string method_1(short short_0)
		{
			return short_0 switch
			{
				0 => "10101110111010", 
				1 => "11101010101110", 
				2 => "10111010101110", 
				3 => "11101110101010", 
				4 => "10101110101110", 
				5 => "11101011101010", 
				6 => "10111011101010", 
				7 => "10101011101110", 
				8 => "11101010111010", 
				9 => "10111010111010", 
				_ => "", 
			};
		}
	}
}
