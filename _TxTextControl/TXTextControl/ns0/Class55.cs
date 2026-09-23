using System.Collections.Generic;
using System.Text.RegularExpressions;
using TXTextControl.Barcode;

namespace ns0
{
	internal class Class55 : CodeGeneratorBase
	{
		private enum Enum0
		{
			const_0,
			const_1,
			const_2
		}

		private int int_0 = 64;

		private int int_1 = 67;

		private string[] string_0 = new string[60]
		{
			"FFF", "FFA", "FFD", "FAF", "FAA", "FAD", "FDF", "FDA", "FDD", "AFF",
			"AFA", "AFD", "AAF", "AAA", "AAD", "ADF", "ADA", "ADD", "DFF", "DFA",
			"DFD", "DAF", "DAA", "DAD", "DDF", "DDA", "FDT", "FTF", "FTA", "FTD",
			"FTT", "AFT", "AAT", "ADT", "ATF", "ATA", "ATD", "ATT", "DFT", "DAT",
			"DDT", "DTF", "DTA", "DTD", "DTT", "TFT", "TAT", "TDT", "TTA", "TTF",
			"DTF", "DTA", "DTD", "DTT", "TFT", "TAT", "TTF", "TTA", "TTD", "TTT"
		};

		private string[] string_1 = new string[64]
		{
			"FFF", "FFA", "FTF", "FFT", "FAF", "FAA", "FAD", "FAT", "FDF", "FDA",
			"FDD", "FDT", "FTF", "FTA", "FTD", "FTT", "AFF", "AFA", "AFD", "AFT",
			"AAF", "AAA", "AAD", "AAT", "ADT", "ADA", "ADD", "ADT", "ATF", "ATA",
			"ATD", "ATT", "DFF", "DFA", "DFD", "DFT", "DAF", "DAA", "DAD", "DAT",
			"DDF", "DDA", "DDD", "DDT", "DTF", "DTA", "DTD", "DTT", "TFF", "TFA",
			"TFD", "TFT", "TAF", "TAA", "TAD", "TAT", "TDF", "TDA", "TDD", "TDT",
			"TTF", "TTA", "TTD", "TTT"
		};

		private string[] string_2 = new string[10] { "FF", "FA", "FD", "AF", "AA", "AD", "DF", "DA", "DD", "TF" };

		private string string_3 = "AT";

		private string string_4 = "AT";

		private string string_5 = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789 #";

		internal override void UpdateBarcodeSettings(Class38 p_bstSettings)
		{
			string p_strText = "39549554";
			string text = p_bstSettings.String_1;
			p_bstSettings.Single_0 = this.GetBarcodeImage(p_bstSettings, p_strText).float_0;
			p_bstSettings.String_1 = text;
		}

		internal override bool IsTextValid(string input, int p_iMaxLength)
		{
			if (input.Length == 8)
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
			new List<string>();
			string string_ = this.method_1("11" + p_strText, Enum0.const_0);
			List<string> list_ = this.method_0(string_);
			Class64 @class = new Class64();
			Class37 result = @class.method_0(list_, new FourState());
			p_bsSettings.String_1 = p_strText;
			return result;
		}

		private List<string> method_0(string string_6)
		{
			List<int> list = new List<int>();
			List<string> list2 = new List<string>();
			for (int i = 0; i < string_6.Length - 2; i += 3)
			{
				string text = string.Concat(string_6[i], string_6[i + 1], string_6[i + 2]);
				for (int j = 0; j < this.string_0.Length; j++)
				{
					if (text == this.string_1[j])
					{
						int item = j;
						list.Add(item);
					}
				}
			}
			Class76 @class = new Class76(this.int_0, this.int_1);
			int[] array = @class.method_3(list.ToArray(), list.Count, 4, this.int_0, this.int_1);
			list2.Add(this.string_3);
			for (int k = 0; k < array.Length; k++)
			{
				list2.Add(this.string_1[array[k]]);
			}
			list2.Add(this.string_4);
			return list2;
		}

		private string method_1(string string_6, Enum0 enum0_0)
		{
			string text = "";
			switch (enum0_0)
			{
			case Enum0.const_0:
				foreach (char c2 in string_6)
				{
					int num = c2 - 48;
					string text3 = this.string_2[num];
					text += text3;
				}
				text += "T";
				break;
			case Enum0.const_1:
			{
				for (int k = 0; k < string_6.Length; k++)
				{
					char c3 = string_6[k];
					for (int l = 0; l < this.string_5.Length; l++)
					{
						if (c3.Equals(this.string_5[l]))
						{
							string text4 = this.string_0[l];
							text += text4;
							for (int num2 = text4.Length - 1; num2 >= 0; num2--)
							{
							}
						}
					}
				}
				break;
			}
			case Enum0.const_2:
				foreach (char c in string_6)
				{
					string text2 = this.string_0[(uint)c];
					text += text2;
				}
				break;
			}
			return text;
		}
	}
}
