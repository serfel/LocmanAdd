using System.Collections.Generic;
using System.Text.RegularExpressions;
using TXTextControl.Barcode;

namespace ns0
{
	internal class Class41 : CodeGeneratorBase
	{
		private string string_0 = "A";

		private string string_1 = "B";

		private string string_2 = "0123456789-$:/.+ABCD";

		private int int_0 = 16;

		private bool bool_0;

		private string[] string_3 = new string[20]
		{
			"0001", "0010", "0001", "1000", "0100", "1000", "0001", "0010", "0100", "1000",
			"0010", "0100", "1011", "1101", "1110", "0111", "0100", "0001", "0001", "0010"
		};

		private string[] string_4 = new string[20]
		{
			"001", "001", "010", "100", "001", "001", "100", "100", "100", "010",
			"010", "010", "000", "000", "000", "000", "011", "110", "011", "011"
		};

		internal override bool IsTextValid(string input, int p_iMaxLength)
		{
			if (input.Length >= 1 && input.Length <= p_iMaxLength)
			{
				string pattern = "[0-9-$:\\/\\.+]{" + input.Length + "}";
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
			string text = ((p_bstSettings.Text != null) ? p_bstSettings.Text : "aaa");
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
			string string_ = this.string_0 + p_strText + this.string_1;
			char c = '\0';
			if (p_bsSettings.Boolean_0)
			{
				c = this.method_1(string_, this.int_0);
				string_ = this.string_0 + p_strText + c + this.string_1;
			}
			List<string> list_ = this.method_0(string_);
			Class64 @class = new Class64();
			Class37 result = @class.method_4(list_, new Codabar());
			string text = ((!p_bsSettings.Boolean_0 || !p_bsSettings.Boolean_1) ? p_strText : (p_strText + c));
			text = (p_bsSettings.String_1 = (this.bool_0 ? (this.string_0 + text + this.string_1) : text));
			return result;
		}

		private List<string> method_0(string string_5)
		{
			List<string> list = new List<string>();
			for (int i = 0; i < string_5.Length; i++)
			{
				char c = string_5[i];
				for (int j = 0; j < this.string_2.Length; j++)
				{
					if (c.Equals(this.string_2[j]))
					{
						string text = this.string_3[j];
						string text2 = this.string_4[j];
						string text3 = "";
						text3 = text3 + text[0] + text2[0];
						text3 = text3 + text[1] + text2[1];
						text3 = text3 + text[2] + text2[2];
						text3 += text[3];
						list.Add(text3);
						break;
					}
				}
			}
			return list;
		}

		private char method_1(string string_5, int int_1)
		{
			int num = 0;
			foreach (char char_ in string_5)
			{
				num += this.method_2(char_);
			}
			int j;
			for (j = int_1; j < num; j += int_1)
			{
			}
			return this.string_2[j - num];
		}

		private int method_2(char char_0)
		{
			if ('0' <= char_0 && char_0 <= '9')
			{
				return (int)char.GetNumericValue(char_0);
			}
			return char_0 switch
			{
				'+' => 15, 
				'-' => 10, 
				'.' => 14, 
				'/' => 13, 
				'$' => 11, 
				'A' => 16, 
				'B' => 17, 
				'C' => 18, 
				'D' => 19, 
				':' => 12, 
				_ => -1, 
			};
		}
	}
}
