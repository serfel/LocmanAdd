using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using TXTextControl.Barcode;

namespace ns0
{
	internal class Class61 : CodeGeneratorBase
	{
		public enum Enum6
		{
			const_0,
			const_1
		}

		private int int_0;

		private int int_1;

		private int int_2;

		private int int_3;

		private int int_4;

		private int int_5;

		private int int_6;

		private int int_7;

		private int int_8;

		private int[] int_9;

		public Enum6 enum6_0;

		public int[,] int_10;

		public static string string_0 = "ASCII";

		private Class75 class75_0;

		internal override void UpdateBarcodeSettings(Class38 p_bstSettings)
		{
			string text = ((p_bstSettings.Text != null) ? p_bstSettings.Text : "a");
			while (text.Length < p_bstSettings.UpperTextLength)
			{
				text = ((text.Length % 2 != 0) ? (text + 'A') : (text + 'a'));
			}
			string string_ = p_bstSettings.String_1;
			p_bstSettings.Single_0 = this.GetBarcodeImage(p_bstSettings, text).float_0;
			p_bstSettings.String_1 = string_;
		}

		internal override bool IsTextValid(string input, int p_iMaxLength)
		{
			if (input.Length >= 1 && input.Length <= p_iMaxLength)
			{
				string pattern = "[a-zA-Z0-9 €ƒ„…†‡ˆ‰Š‹Œ\u008dŽ\u0090‘’“”•–—\u02dc™š›œ\u009džŸ¡¢£¤¥¦§\u00a8©ª«¬®\u00af°±²³\u00b4µ¶·\u00b8¹º»¼½¾¿¿ÀÁÂÃÄÅÆÇÈÉÊËÌÍÎÏÐÑÒÓÔÕÖ×ØÙÚÛÜÝÞßàáâãäåæçèéêëìíîïðñòóôõö÷øùúûüýþÿ\\a\\b\\t\\f\\r\\n\\*\\-\\.!\"#+$%&'\\\\(),-:;<=>?\\[\\]\\{\\}\\@\\^_\\|\\~]{" + input.Length + "}";
				Regex regex = new Regex(pattern);
				if (regex.IsMatch(input))
				{
					return true;
				}
			}
			return false;
		}

		internal Class61(int int_11, Enum6 enum6_1)
		{
			this.int_1 = int_11;
			this.enum6_0 = enum6_1;
			this.class75_0 = new Class75();
		}

		internal int method_0(string string_1, Enum6 enum6_1)
		{
			int num = this.class75_0.method_1(string_1.Length, this.enum6_0);
			return 17 + num * 4;
		}

		internal override Class37 GetBarcodeImage(Class38 p_bsSettings, string p_strText)
		{
			int num = 0;
			num = ((!this.enum6_0.Equals(Enum6.const_0)) ? 1662 : 2419);
			if (p_strText.Length > num)
			{
				p_strText = p_strText.Substring(0, num);
			}
			this.int_0 = this.class75_0.method_1(p_strText.Length, this.enum6_0);
			this.int_2 = 17 + this.int_0 * 4;
			this.int_10 = new int[this.int_2, this.int_2];
			int[] array = this.class75_0.method_0(this.int_0);
			this.int_3 = (array[1] * array[2] + array[3] * array[4]) * 8;
			this.int_4 = array[1];
			this.int_6 = array[2];
			this.int_5 = array[3];
			this.int_7 = array[4];
			this.int_8 = array[5];
			Class71 @class = new Class71(this.int_0, this.int_2, this.int_1);
			this.int_9 = this.method_1(p_strText);
			this.int_10 = @class.method_4(this.int_10);
			@class.method_1(this.int_10);
			this.int_10 = this.method_8(this.int_10, this.int_9);
			this.int_10 = @class.method_0(this.int_10);
			Class77 class2 = new Class77();
			class2.float_0 = 1f;
			p_bsSettings.String_1 = p_strText;
			return class2.method_5(this.int_10);
		}

		public int[] method_1(string string_1)
		{
			Class70 @class = new Class70();
			string text = @class.method_0(this.int_0, this.int_3, string_1, this.enum6_0);
			string[] array = new string[this.int_4];
			string[] array2 = new string[this.int_5];
			int num = 0;
			for (int i = 0; i < this.int_4; i++)
			{
				array[i] = text.Substring(i * this.int_6 * 8, this.int_6 * 8);
				num += this.int_6 * 8;
			}
			for (int j = 0; j < this.int_5; j++)
			{
				if (j == 0)
				{
					array2[j] = text.Substring(num, this.int_7 * 8);
				}
				else
				{
					array2[j] = text.Substring(j * this.int_7 * 8 + num, this.int_7 * 8);
				}
			}
			List<string[]> list = new List<string[]>();
			string[] array3 = array;
			foreach (string string_2 in array3)
			{
				list.Add(this.method_7(string_2));
			}
			if (this.int_5 > 0)
			{
				string[] array4 = array2;
				foreach (string string_3 in array4)
				{
					list.Add(this.method_7(string_3));
				}
			}
			text = "";
			int num2 = Math.Max(this.int_6, this.int_7);
			int count = list.Count;
			for (int m = 0; m < num2; m++)
			{
				for (int n = 0; n < count; n++)
				{
					if (m < list[n].Length)
					{
						text += list[n][m];
					}
				}
			}
			List<string[]> list2 = new List<string[]>();
			string[] array5 = array;
			foreach (string string_4 in array5)
			{
				string[] item = this.method_2(string_4);
				list2.Add(item);
			}
			if (this.int_5 > 0)
			{
				string[] array6 = array2;
				foreach (string string_5 in array6)
				{
					string[] item2 = this.method_2(string_5);
					list2.Add(item2);
				}
			}
			for (int num5 = 0; num5 < this.int_8; num5++)
			{
				for (int num6 = 0; num6 < list2.Count; num6++)
				{
					text += list2[num6][num5];
				}
			}
			List<int> list3 = new List<int>();
			string text2 = text;
			for (int num7 = 0; num7 < text2.Length; num7++)
			{
				if (text2[num7].Equals('0'))
				{
					list3.Add(0);
				}
				else
				{
					list3.Add(1);
				}
			}
			return list3.ToArray();
		}

		public string[] method_2(string string_1)
		{
			List<string> list = new List<string>();
			string[] array = this.method_7(string_1);
			int[] array2 = new int[array.Length];
			for (int i = 0; i < array.Length; i++)
			{
				array2[i] = this.method_4(array[i]);
			}
			Class72 @class = new Class72();
			Class74[] array3 = @class.method_0(array2, array.Length, 0);
			array3 = this.method_3(array3, this.int_8 - array3[0].int_1);
			Class74[] class74_ = @class.method_1(this.int_8);
			Class73 class2 = new Class73();
			bool? nullable_;
			Class74[] array4 = class2.method_5(array3, class74_, out nullable_);
			for (int j = 0; j < array4.Length; j++)
			{
				try
				{
					list.Add(this.method_6(array4[j].int_0));
				}
				catch (Exception)
				{
					list.Add("00000000");
				}
			}
			while (list.Count < this.int_8)
			{
				if (nullable_.HasValue)
				{
					if (nullable_.Value)
					{
						list.Add("00000000");
					}
					else
					{
						list.Insert(0, "00000000");
					}
				}
				else
				{
					list.Add("00000000");
				}
			}
			return list.ToArray();
		}

		private Class74[] method_3(Class74[] class74_0, int int_11)
		{
			foreach (Class74 @class in class74_0)
			{
				@class.int_1 += int_11;
			}
			return class74_0;
		}

		private int method_4(string string_1)
		{
			string value = string_1.Replace(" ", "");
			return Convert.ToInt32(value, 2);
		}

		private int[] method_5(string[] string_1, int int_11)
		{
			int[] array = new int[int_11];
			for (int i = 0; i < int_11; i++)
			{
				array[i] = this.method_4(string_1[i]);
			}
			return array;
		}

		private string method_6(int int_11)
		{
			string text = "";
			text = Convert.ToString(int_11, 2);
			while (text.Length < 8)
			{
				text = '0' + text;
			}
			return text;
		}

		public string[] method_7(string string_1)
		{
			int num = string_1.Length / 8;
			string[] array = new string[num];
			for (int i = 0; i < num; i++)
			{
				array[i] = string_1.Substring(i * 8, 8);
			}
			return array;
		}

		public int[,] method_8(int[,] int_11, int[] int_12)
		{
			Stack<int> stack = new Stack<int>();
			for (int num = int_12.Length - 1; num >= 0; num--)
			{
				stack.Push(int_12[num]);
			}
			bool flag = true;
			int num2 = this.int_2 - 1;
			int num3 = this.int_2 - 1;
			while (stack.Count > 0)
			{
				if (num2 > 0 && int_11[num2, num3] == -1)
				{
					int_11[num2, num3] = stack.Pop();
					if (stack.Count > 0)
					{
						int_11[num2 - 1, num3] = stack.Pop();
					}
				}
				else if (num2 > 1 && int_11[num2 - 1, num3] == -1 && int_11[num2, num3] != -1)
				{
					int_11[num2 - 1, num3] = stack.Pop();
				}
				if (num2 == 6)
				{
					num2--;
				}
				else if (num3 == 0 && flag)
				{
					flag = false;
					num2 -= 2;
					num3--;
				}
				else if (num3 == this.int_2 - 1 && !flag)
				{
					flag = true;
					num2 -= 2;
					num3++;
				}
				num3 = ((!flag) ? (num3 + 1) : (num3 - 1));
			}
			return int_11;
		}
	}
}
