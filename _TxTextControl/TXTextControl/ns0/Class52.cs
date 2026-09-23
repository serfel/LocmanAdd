using System.Collections.Generic;
using System.Text.RegularExpressions;
using TXTextControl.Barcode;

namespace ns0
{
	internal class Class52 : CodeGeneratorBase
	{
		private string[] string_0 = new string[10] { "00110", "10001", "01001", "11000", "00101", "10100", "01100", "00011", "10010", "01010" };

		private string string_1 = "0000";

		private string string_2 = "100";

		internal override void UpdateBarcodeSettings(Class38 p_bstSettings)
		{
			string text = "0";
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
				Regex regex = new Regex("\\d{" + input.Length + "}");
				if (regex.IsMatch(input))
				{
					return true;
				}
			}
			return false;
		}

		internal override Class37 GetBarcodeImage(Class38 p_bsSettings, string p_strText)
		{
			if ((p_bsSettings.Boolean_0 && p_strText.Length % 2 == 0) || (!p_bsSettings.Boolean_0 && p_strText.Length % 2 != 0))
			{
				p_strText = '0' + p_strText;
			}
			int int_;
			string[] array = this.method_0(p_strText, p_bsSettings.Boolean_0, out int_);
			Class64 @class = new Class64();
			string text = (p_bsSettings.Boolean_0 ? (p_strText + int_) : p_strText);
			Class37 result = @class.method_10(array, text, new Class18());
			string text3 = (p_bsSettings.String_1 = ((!p_bsSettings.Boolean_0 || !p_bsSettings.Boolean_1) ? p_strText : (p_strText + int_)));
			return result;
		}

		public string[] method_0(string string_3, bool bool_0, out int int_0)
		{
			int_0 = -1;
			List<int> list = new List<int>();
			string text = string_3;
			foreach (char c in text)
			{
				list.Add(c - 48);
			}
			if (bool_0)
			{
				string_3 += this.method_1(list, out int_0);
			}
			string[] array = new string[string_3.Length / 2 + 2];
			array[0] = this.string_1;
			for (int j = 1; j < array.Length - 1; j++)
			{
				string text2 = this.string_0[string_3[j * 2 - 2] - 48];
				string text3 = this.string_0[string_3[j * 2 - 1] - 48];
				string text4 = "";
				for (int k = 0; k < 5; k++)
				{
					text4 = text4 + (text2[k] - 48) + (text3[k] - 48);
				}
				array[j] = text4;
			}
			array[array.Length - 1] = this.string_2;
			return array;
		}

		private int method_1(List<int> list_0, out int int_0)
		{
			int num = 0;
			bool flag = true;
			for (int num2 = list_0.Count - 1; num2 >= 0; num2--)
			{
				if (flag)
				{
					num += list_0[num2] * 3;
					flag = false;
				}
				else
				{
					num += list_0[num2];
					flag = true;
				}
			}
			num = 10 - num % 10;
			int_0 = num % 10;
			return num;
		}
	}
}
