using System.Collections.Generic;
using System.Text.RegularExpressions;
using TXTextControl.Barcode;

namespace ns0
{
	internal class Class42 : CodeGeneratorBase
	{
		private string[] string_0 = new string[11]
		{
			"101011", "1101011", "1001011", "1100101", "1011011", "1101101", "1001101", "1010011", "1101001", "110101",
			"101101"
		};

		private string[] string_1 = new string[11]
		{
			"00001", "10001", "01001", "11000", "00101", "10100", "01100", "00011", "10010", "10000",
			"00100"
		};

		private string string_2 = "1011001";

		private string string_3 = "0123456789-";

		internal override bool IsTextValid(string input, int p_iMaxLength)
		{
			if (input.Length >= 1 && input.Length <= p_iMaxLength)
			{
				string pattern = "[0-9-]{" + input.Length + "}";
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
			string text = ((p_bstSettings.Text != null) ? p_bstSettings.Text : "01a");
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
			int int_;
			List<string> list_ = this.method_0(p_strText, p_bsSettings.Boolean_0, out int_);
			Class64 @class = new Class64();
			Class37 result = @class.method_2(list_, new Code11());
			p_bsSettings.String_1 = ((!p_bsSettings.Boolean_0 || !p_bsSettings.Boolean_1) ? p_strText : (p_strText + int_));
			return result;
		}

		private List<string> method_0(string string_4, bool bool_0, out int int_0)
		{
			List<string> list = new List<string>();
			list.Add(this.string_2);
			int num = 0;
			int num2 = 0;
			int num3 = string_4.Length;
			int num4 = string_4.Length + 1;
			for (int i = 0; i < string_4.Length; i++)
			{
				char c = string_4[i];
				for (int j = 0; j < this.string_3.Length; j++)
				{
					if (c.Equals(this.string_3[j]))
					{
						list.Add(this.string_0[j]);
						num += j * num3;
						num3--;
						if (num3 <= 0)
						{
							num3 = 10;
						}
						num2 += j * num4;
						num4--;
						if (num4 <= 0)
						{
							num4 = 9;
						}
						break;
					}
				}
			}
			int_0 = num % 11;
			if (bool_0)
			{
				list.Add(this.string_0[int_0]);
			}
			list.Add(this.string_2);
			return list;
		}
	}
}
