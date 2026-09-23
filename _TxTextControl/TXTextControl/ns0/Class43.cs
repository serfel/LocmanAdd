using System.Collections.Generic;
using System.Text.RegularExpressions;
using TXTextControl.Barcode;

namespace ns0
{
	internal class Class43 : CodeGeneratorBase
	{
		private string[] string_0 = new string[56]
		{
			"131112", "111213", "111312", "111411", "121113", "121212", "121311", "111114", "131211", "141111",
			"211113", "211212", "211311", "221112", "221211", "231111", "112113", "112212", "112311", "122112",
			"132111", "111123", "111222", "111321", "121122", "131121", "212112", "212211", "211122", "211221",
			"221121", "222111", "112122", "112221", "122121", "123111", "121131", "311112", "311211", "321111",
			"112131", "113121", "211131", "121221", "312111", "311121", "122211", "111141", "114111", "411111",
			"111132", "111231", "113112", "113211", "213111", "212121"
		};

		private string string_1 = "111141";

		private string string_2 = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ-. $/+%";

		internal override bool IsTextValid(string input, int p_iMaxLength)
		{
			if (input.Length >= 1 && input.Length <= p_iMaxLength)
			{
				string pattern = "[A-Z0-9 .$\\/+%]{" + input.Length + "}";
				Regex regex = new Regex(pattern);
				if (regex.IsMatch(input))
				{
					return true;
				}
			}
			return false;
		}

		internal override void UpdateBarcodeSettings(Class38 p_bstSettings)
		{
			string text = ((p_bstSettings.Text != null) ? p_bstSettings.Text : "A");
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
			string string_;
			List<string> list_ = this.method_0(p_strText, out string_);
			Class64 @class = new Class64();
			Class37 result = @class.method_1(list_, new Class3());
			p_bsSettings.String_1 = (p_bsSettings.Boolean_1 ? (p_strText + string_) : p_strText);
			return result;
		}

		private List<string> method_0(string string_3, out string string_4)
		{
			List<string> list = new List<string>();
			list.Add(this.string_1);
			int num = 0;
			int num2 = 0;
			int num3 = string_3.Length;
			int num4 = string_3.Length + 1;
			for (int i = 0; i < string_3.Length; i++)
			{
				char c = string_3[i];
				if (char.IsLower(c))
				{
					c = char.ToUpper(c);
				}
				for (int j = 0; j < this.string_2.Length; j++)
				{
					if (c.Equals(this.string_2[j]))
					{
						list.Add(this.string_0[j]);
						num += j * num3;
						num2 += j * num4;
						num3--;
						num4--;
						if (num3 == 0)
						{
							num3 = 20;
						}
						if (num4 == 0)
						{
							num4 = 15;
						}
						break;
					}
				}
			}
			int num5 = num % 47;
			string_4 = ((num5 < this.string_2.Length) ? this.string_2[num5].ToString() : "#");
			list.Add(this.string_0[num5]);
			num2 += num5;
			num5 = num2 % 47;
			string_4 += ((num5 < this.string_2.Length) ? this.string_2[num5].ToString() : "#");
			list.Add(this.string_0[num5]);
			list.Add(this.string_1);
			return list;
		}
	}
}
