using System.Collections.Generic;
using System.Text.RegularExpressions;
using TXTextControl.Barcode;

namespace ns0
{
	internal class Class47 : CodeGeneratorBase
	{
		private string[] string_0 = new string[10] { "00111", "11100", "11010", "11001", "10110", "10101", "10011", "01110", "01101", "01011" };

		private string string_1 = "1";

		private string string_2 = "0123456789";

		internal override void UpdateBarcodeSettings(Class38 p_bstSettings)
		{
			string p_strText = "01234567890";
			string text = p_bstSettings.String_1;
			p_bstSettings.Single_0 = this.GetBarcodeImage(p_bstSettings, p_strText).float_0;
			p_bstSettings.String_1 = text;
		}

		internal override bool IsTextValid(string input, int p_iMaxLength)
		{
			if (input.Length >= 11 && input.Length <= 13)
			{
				string pattern = "[0-9]{" + input.Length + "}";
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
			int int_;
			List<string> list_ = this.method_0(p_strText, out int_);
			Class64 @class = new Class64();
			Class37 result = @class.method_5(list_, new PLANET());
			p_bsSettings.String_1 = (p_bsSettings.Boolean_1 ? (p_strText + int_) : p_strText);
			return result;
		}

		public List<string> method_0(string string_3, out int int_0)
		{
			List<string> list = new List<string>();
			list.Add(this.string_1);
			int num = 0;
			for (int i = 0; i < string_3.Length; i++)
			{
				char c = string_3[i];
				for (int j = 0; j < this.string_2.Length; j++)
				{
					if (c.Equals(this.string_2[j]))
					{
						list.Add(this.string_0[j]);
						num += int.Parse(string.Concat(c));
						break;
					}
				}
			}
			int_0 = 10 - num % 10;
			list.Add(this.string_0[int_0]);
			list.Add(this.string_1);
			return list;
		}
	}
}
