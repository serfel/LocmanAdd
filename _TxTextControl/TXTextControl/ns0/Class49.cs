using System.Collections.Generic;
using System.Text.RegularExpressions;
using TXTextControl.Barcode;

namespace ns0
{
	internal class Class49 : CodeGeneratorBase
	{
		private string[] string_0 = new string[38]
		{
			"TTFF", "TDAF", "TDFA", "DTAF", "DTFA", "DDAA", "TADF", "TFTF", "TFDA", "DATF",
			"A", "F", "DADA", "DFTA", "TAFD", "TFAD", "TFFT", "DAAD", "DAFT", "DFAT",
			"ATDF", "ADTF", "ADDA", "FTTF", "FTDA", "FDTA", "ATFD", "ADAD", "ADFT", "FTAD",
			"FTFT", "FDAT", "AADD", "AFTD", "AFDT", "FATD", "FADT", "FFTT"
		};

		private string string_1 = "A";

		private string string_2 = "F";

		private string string_3 = "0123456789()ABCDEFGHIJKLMNOPQRSTUVWXYZ";

		internal override bool IsTextValid(string input, int p_iMaxLength)
		{
			string text = string.Empty;
			for (int i = 0; i < input.Length; i++)
			{
				text = ((!char.IsLower(input[i])) ? (text + input[i]) : (text + char.ToUpper(input[i])));
			}
			input = text;
			if (input.Length >= 1 && input.Length <= p_iMaxLength)
			{
				string pattern = "[A-Z0-9()]{" + input.Length + "}";
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
			string string_;
			List<string> list_ = this.method_0(p_strText, out string_);
			Class64 @class = new Class64();
			Class37 result = @class.method_3(list_, new Class14());
			p_bsSettings.String_1 = (p_bsSettings.Boolean_1 ? (p_strText + string_) : p_strText);
			return result;
		}

		private List<string> method_0(string string_4, out string string_5)
		{
			List<string> list = new List<string>();
			list.Add(this.string_1);
			int num = 0;
			int num2 = 0;
			for (int i = 0; i < string_4.Length; i++)
			{
				char c = string_4[i];
				if (char.IsLower(c))
				{
					c = char.ToUpper(c);
				}
				int num3 = 0;
				int num4 = 0;
				int num5 = 3;
				for (int j = 0; j < this.string_3.Length; j++)
				{
					if (!c.Equals(this.string_3[j]))
					{
						continue;
					}
					string text = this.string_0[j];
					list.Add(text);
					for (int num6 = text.Length - 1; num6 >= 0; num6--)
					{
						num5 = ((num6 != 0) ? 3 : 4);
						if (text[num6] == 'A')
						{
							num3 += num5 - num6;
						}
						else if (text[num6] == 'D')
						{
							num4 += num5 - num6;
						}
						else if (text[num6] == 'F')
						{
							num3 += num5 - num6;
							num4 += num5 - num6;
						}
					}
					break;
				}
				if (num3 == 6)
				{
					num3 = 0;
				}
				if (num4 == 6)
				{
					num4 = 0;
				}
				num += num3;
				num2 += num4;
			}
			num %= 6;
			num2 %= 6;
			if (num == 0)
			{
				num = 6;
			}
			if (num2 == 0)
			{
				num2 = 6;
			}
			string[,] array = new string[6, 6]
			{
				{ "0", "1", "2", "3", "4", "5" },
				{ "6", "7", "8", "9", "A", "B" },
				{ "C", "D", "E", "F", "G", "H" },
				{ "I", "J", "K", "L", "M", "N" },
				{ "O", "P", "Q", "R", "S", "T" },
				{ "U", "V", "W", "X", "Y", "Z" }
			};
			string_5 = array[num - 1, num2 - 1];
			for (int k = 0; k < this.string_3.Length; k++)
			{
				if (string_5 == string.Concat(this.string_3[k]))
				{
					list.Add(this.string_0[k]);
				}
			}
			list.Add(this.string_2);
			return list;
		}
	}
}
