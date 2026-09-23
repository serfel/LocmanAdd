using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using TXTextControl.Barcode;

namespace ns0
{
	internal class Class57 : CodeGeneratorBase
	{
		internal class Class66
		{
			internal int int_0;

			internal int int_1;

			public Class66(int int_2, int int_3)
			{
				this.int_0 = int_2;
				this.int_1 = int_3;
			}
		}

		private int int_0 = 256;

		private int int_1 = 301;

		private int[,] int_2;

		private int int_3;

		private int int_4;

		private int[] int_5;

		private int int_6;

		private int int_7;

		public int int_8 = 1304;

		internal override void UpdateBarcodeSettings(Class38 p_bstSettings)
		{
			string text = ((p_bstSettings.Text != null) ? p_bstSettings.Text : "A");
			while (text.Length < p_bstSettings.UpperTextLength)
			{
				text += 'A';
			}
			string string_ = p_bstSettings.String_1;
			p_bstSettings.Single_0 = this.GetBarcodeImage(p_bstSettings, text).float_0;
			p_bstSettings.String_1 = string_;
		}

		internal override bool IsTextValid(string input, int p_iMaxLength)
		{
			if (input.Length >= 1 && input.Length <= p_iMaxLength)
			{
				string pattern = "[a-zA-Z0-9 ¡¢£¤¥¦§\u00a8©ª«¬®\u00af°±²³\u00b4µ¶·\u00b8¹º»¼½¾¿¿ÀÁÂÃÄÅÆÇÈÉÊËÌÍÎÏÐÑÒÓÔÕÖ×ØÙÚÛÜÝÞßàáâãäåæçèéêëìíîïðñòóôõö÷øùúûüýþÿ\\r\\n\\*\\-\\.!\"#$%+&'\\\\(),-:;<=>?\\[\\]\\{\\}\\@\\^_\\|\\~\\a\\b\\t\\n\\f\\r]{" + input.Length + "}";
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
			new Class76(this.int_0, this.int_1);
			Class77 @class = new Class77();
			int[,] array = this.method_0(p_strText);
			Class37 result = @class.method_4(array, 1, this.int_3 + this.int_7);
			p_bsSettings.String_1 = p_strText;
			return result;
		}

		public int[,] method_0(string string_0)
		{
			int num = 5;
			int num2 = 1;
			this.int_3 = 8;
			this.int_4 = this.int_3;
			this.int_6 = 1;
			if (string_0.Length > this.int_8)
			{
				string_0 = string_0.Substring(0, this.int_8);
			}
			int[] array = this.method_1(string_0);
			if (array.Length > 3)
			{
				num = 7;
				this.int_3 = 10;
				this.int_4 = this.int_3;
			}
			if (array.Length > 5)
			{
				num = 10;
				this.int_3 = 12;
				this.int_4 = this.int_3;
			}
			if (array.Length > 8)
			{
				num = 12;
				this.int_3 = 14;
				this.int_4 = this.int_3;
			}
			if (array.Length > 12)
			{
				num = 14;
				this.int_3 = 16;
				this.int_4 = this.int_3;
			}
			if (array.Length > 18)
			{
				num = 18;
				this.int_3 = 18;
				this.int_4 = this.int_3;
			}
			if (array.Length > 22)
			{
				num = 20;
				this.int_3 = 20;
				this.int_4 = this.int_3;
			}
			if (array.Length > 30)
			{
				num = 24;
				this.int_3 = 22;
				this.int_4 = this.int_3;
			}
			if (array.Length > 36)
			{
				num = 28;
				this.int_3 = 24;
				this.int_4 = this.int_3;
			}
			if (array.Length > 44)
			{
				num = 36;
				this.int_4 = 14;
				this.int_3 = this.int_4 * 2;
				this.int_6 = 4;
			}
			if (array.Length > 62)
			{
				num = 42;
				this.int_4 = 16;
				this.int_3 = this.int_4 * 2;
			}
			if (array.Length > 86)
			{
				num = 48;
				this.int_4 = 18;
				this.int_3 = this.int_4 * 2;
			}
			if (array.Length > 114)
			{
				num = 56;
				this.int_4 = 20;
				this.int_3 = this.int_4 * 2;
			}
			if (array.Length > 144)
			{
				num = 68;
				this.int_4 = 22;
				this.int_3 = this.int_4 * 2;
			}
			if (array.Length > 174)
			{
				num = 84;
				this.int_4 = 24;
				this.int_3 = this.int_4 * 2;
				num2 = 2;
			}
			if (array.Length > 204)
			{
				num = 112;
				this.int_4 = 14;
				this.int_3 = this.int_4 * 4;
				num2 = 2;
				this.int_6 = 16;
			}
			if (array.Length > 280)
			{
				num = 144;
				this.int_4 = 16;
				this.int_3 = this.int_4 * 4;
				num2 = 4;
			}
			if (array.Length > 368)
			{
				num = 192;
				this.int_4 = 18;
				this.int_3 = this.int_4 * 4;
			}
			if (array.Length > 456)
			{
				num = 224;
				this.int_4 = 20;
				this.int_3 = this.int_4 * 4;
			}
			if (array.Length > 576)
			{
				num = 272;
				this.int_4 = 22;
				this.int_3 = this.int_4 * 4;
			}
			if (array.Length > 696)
			{
				num = 336;
				this.int_4 = 24;
				this.int_3 = this.int_4 * 4;
				num2 = 6;
			}
			if (array.Length > 816)
			{
				num = 408;
				this.int_4 = 18;
				this.int_3 = this.int_4 * 6;
				this.int_6 = 36;
			}
			if (array.Length > 1050)
			{
				num = 496;
				this.int_4 = 20;
				this.int_3 = this.int_4 * 6;
				num2 = 8;
			}
			Class76 @class = new Class76(this.int_0, this.int_1);
			int[] array2 = null;
			if (num2 == 1)
			{
				array2 = @class.method_3(array, array.Length, num, this.int_0, this.int_1);
			}
			string text = "";
			switch (num2)
			{
			case 2:
			{
				int[] array57 = new int[array.Length / 2];
				int[] array58 = new int[array.Length / 2];
				for (int num15 = 0; num15 < array.Length; num15++)
				{
					if (num15 % 2 == 0)
					{
						array57[num15 / 2] = array[num15];
					}
					else
					{
						array58[num15 / 2] = array[num15];
					}
				}
				int[] array59 = @class.method_3(array57, array57.Length, num / 2, this.int_0, this.int_1);
				int[] array60 = @class.method_3(array58, array58.Length, num / 2, this.int_0, this.int_1);
				int[] array61 = new int[num / 2];
				int[] array62 = new int[num / 2];
				for (int num16 = 0; num16 < num / 2; num16++)
				{
					array61[num16] = array59[num16 + array57.Length];
					array62[num16] = array60[num16 + array58.Length];
				}
				array2 = new int[array59.Length * 2];
				for (int num17 = 0; num17 < array57.Length + array58.Length; num17++)
				{
					if (num17 % 2 == 0)
					{
						array2[num17] = array57[num17 / 2];
					}
					else
					{
						array2[num17] = array58[num17 / 2];
					}
				}
				for (int num18 = 0; num18 < array61.Length + array62.Length; num18++)
				{
					if (num18 % 2 == 0)
					{
						array2[num18 + array57.Length + array58.Length] = array61[num18 / 2];
					}
					else
					{
						array2[num18 + array57.Length + array58.Length] = array62[num18 / 2];
					}
				}
				break;
			}
			case 4:
			{
				int[] array27 = new int[array.Length / 4];
				int[] array28 = new int[array.Length / 4];
				int[] array29 = new int[array.Length / 4];
				int[] array30 = new int[array.Length / 4];
				for (int m = 0; m < array.Length; m++)
				{
					if (m % 4 == 0)
					{
						array27[m / 4] = array[m];
					}
					else if (m % 4 == 1)
					{
						array28[m / 4] = array[m];
					}
					else if (m % 4 == 2)
					{
						array29[m / 4] = array[m];
					}
					else if (m % 4 == 3)
					{
						array30[m / 4] = array[m];
					}
				}
				int num5 = array.Length / 4;
				int num6 = num / 4;
				int[] array31 = @class.method_3(array27, num5, num6, this.int_0, this.int_1);
				int[] array32 = @class.method_3(array28, num5, num6, this.int_0, this.int_1);
				int[] array33 = @class.method_3(array29, num5, num6, this.int_0, this.int_1);
				int[] array34 = @class.method_3(array30, num5, num6, this.int_0, this.int_1);
				int[] array35 = new int[num6];
				int[] array36 = new int[num6];
				int[] array37 = new int[num6];
				int[] array38 = new int[num6];
				for (int n = 0; n < num6; n++)
				{
					array35[n] = array31[n + num5];
					array36[n] = array32[n + num5];
					array37[n] = array33[n + num5];
					array38[n] = array34[n + num5];
				}
				array2 = new int[array31.Length * 4];
				for (int num7 = 0; num7 < array.Length; num7++)
				{
					if (num7 % 4 == 0)
					{
						array2[num7] = array27[num7 / 4];
					}
					else if (num7 % 4 == 1)
					{
						array2[num7] = array28[num7 / 4];
					}
					else if (num7 % 4 == 2)
					{
						array2[num7] = array29[num7 / 4];
					}
					else if (num7 % 4 == 3)
					{
						array2[num7] = array30[num7 / 4];
					}
				}
				for (int num8 = 0; num8 < num; num8++)
				{
					if (num8 % 4 == 0)
					{
						array2[num8 + num5 * 4] = array35[num8 / 4];
					}
					else if (num8 % 4 == 1)
					{
						array2[num8 + num5 * 4] = array36[num8 / 4];
					}
					else if (num8 % 4 == 2)
					{
						array2[num8 + num5 * 4] = array37[num8 / 4];
					}
					else if (num8 % 4 == 3)
					{
						array2[num8 + num5 * 4] = array38[num8 / 4];
					}
				}
				break;
			}
			case 6:
			{
				int[] array39 = new int[array.Length / 6];
				int[] array40 = new int[array.Length / 6];
				int[] array41 = new int[array.Length / 6];
				int[] array42 = new int[array.Length / 6];
				int[] array43 = new int[array.Length / 6];
				int[] array44 = new int[array.Length / 6];
				for (int num9 = 0; num9 < array.Length; num9++)
				{
					if (num9 % 6 == 0)
					{
						array39[num9 / 6] = array[num9];
					}
					else if (num9 % 6 == 1)
					{
						array40[num9 / 6] = array[num9];
					}
					else if (num9 % 6 == 2)
					{
						array41[num9 / 6] = array[num9];
					}
					else if (num9 % 6 == 3)
					{
						array42[num9 / 6] = array[num9];
					}
					else if (num9 % 6 == 4)
					{
						array43[num9 / 6] = array[num9];
					}
					else if (num9 % 6 == 5)
					{
						array44[num9 / 6] = array[num9];
					}
				}
				int num10 = array.Length / 6;
				int num11 = num / 6;
				int[] array45 = @class.method_3(array39, num10, num11, this.int_0, this.int_1);
				int[] array46 = @class.method_3(array40, num10, num11, this.int_0, this.int_1);
				int[] array47 = @class.method_3(array41, num10, num11, this.int_0, this.int_1);
				int[] array48 = @class.method_3(array42, num10, num11, this.int_0, this.int_1);
				int[] array49 = @class.method_3(array43, num10, num11, this.int_0, this.int_1);
				int[] array50 = @class.method_3(array44, num10, num11, this.int_0, this.int_1);
				int[] array51 = new int[num11];
				int[] array52 = new int[num11];
				int[] array53 = new int[num11];
				int[] array54 = new int[num11];
				int[] array55 = new int[num11];
				int[] array56 = new int[num11];
				for (int num12 = 0; num12 < num11; num12++)
				{
					array51[num12] = array45[num12 + num10];
					array52[num12] = array46[num12 + num10];
					array53[num12] = array47[num12 + num10];
					array54[num12] = array48[num12 + num10];
					array55[num12] = array49[num12 + num10];
					array56[num12] = array50[num12 + num10];
				}
				array2 = new int[array45.Length * 6];
				for (int num13 = 0; num13 < array.Length; num13++)
				{
					if (num13 % 6 == 0)
					{
						array2[num13] = array39[num13 / 6];
					}
					else if (num13 % 6 == 1)
					{
						array2[num13] = array40[num13 / 6];
					}
					else if (num13 % 6 == 2)
					{
						array2[num13] = array41[num13 / 6];
					}
					else if (num13 % 6 == 3)
					{
						array2[num13] = array42[num13 / 6];
					}
					else if (num13 % 6 == 4)
					{
						array2[num13] = array43[num13 / 6];
					}
					else if (num13 % 6 == 5)
					{
						array2[num13] = array44[num13 / 6];
					}
				}
				for (int num14 = 0; num14 < num; num14++)
				{
					if (num14 % 6 == 0)
					{
						array2[num14 + num10 * 6] = array51[num14 / 6];
					}
					else if (num14 % 6 == 1)
					{
						array2[num14 + num10 * 6] = array52[num14 / 6];
					}
					else if (num14 % 6 == 2)
					{
						array2[num14 + num10 * 6] = array53[num14 / 6];
					}
					else if (num14 % 6 == 3)
					{
						array2[num14 + num10 * 6] = array54[num14 / 6];
					}
					else if (num14 % 6 == 4)
					{
						array2[num14 + num10 * 6] = array55[num14 / 6];
					}
					else if (num14 % 6 == 5)
					{
						array2[num14 + num10 * 6] = array56[num14 / 6];
					}
				}
				break;
			}
			case 8:
			{
				int[] array3 = new int[array.Length / 8];
				int[] array4 = new int[array.Length / 8];
				int[] array5 = new int[array.Length / 8];
				int[] array6 = new int[array.Length / 8];
				int[] array7 = new int[array.Length / 8];
				int[] array8 = new int[array.Length / 8];
				int[] array9 = new int[array.Length / 8];
				int[] array10 = new int[array.Length / 8];
				for (int i = 0; i < array.Length; i++)
				{
					if (i % 8 == 0)
					{
						array3[i / 8] = array[i];
					}
					else if (i % 8 == 1)
					{
						array4[i / 8] = array[i];
					}
					else if (i % 8 == 2)
					{
						array5[i / 8] = array[i];
					}
					else if (i % 8 == 3)
					{
						array6[i / 8] = array[i];
					}
					else if (i % 8 == 4)
					{
						array7[i / 8] = array[i];
					}
					else if (i % 8 == 5)
					{
						array8[i / 8] = array[i];
					}
					else if (i % 8 == 6)
					{
						array9[i / 8] = array[i];
					}
					else if (i % 8 == 7)
					{
						array10[i / 8] = array[i];
					}
				}
				int num3 = array.Length / 8;
				int num4 = num / 8;
				int[] array11 = @class.method_3(array3, num3, num4, this.int_0, this.int_1);
				int[] array12 = @class.method_3(array4, num3, num4, this.int_0, this.int_1);
				int[] array13 = @class.method_3(array5, num3, num4, this.int_0, this.int_1);
				int[] array14 = @class.method_3(array6, num3, num4, this.int_0, this.int_1);
				int[] array15 = @class.method_3(array7, num3, num4, this.int_0, this.int_1);
				int[] array16 = @class.method_3(array8, num3, num4, this.int_0, this.int_1);
				int[] array17 = @class.method_3(array9, num3, num4, this.int_0, this.int_1);
				int[] array18 = @class.method_3(array10, num3, num4, this.int_0, this.int_1);
				int[] array19 = new int[num4];
				int[] array20 = new int[num4];
				int[] array21 = new int[num4];
				int[] array22 = new int[num4];
				int[] array23 = new int[num4];
				int[] array24 = new int[num4];
				int[] array25 = new int[num4];
				int[] array26 = new int[num4];
				for (int j = 0; j < num4; j++)
				{
					array19[j] = array11[j + num3];
					array20[j] = array12[j + num3];
					array21[j] = array13[j + num3];
					array22[j] = array14[j + num3];
					array23[j] = array15[j + num3];
					array24[j] = array16[j + num3];
					array25[j] = array17[j + num3];
					array26[j] = array18[j + num3];
				}
				array2 = new int[array11.Length * 8];
				for (int k = 0; k < array.Length; k++)
				{
					if (k % 8 == 0)
					{
						array2[k] = array3[k / 8];
					}
					else if (k % 8 == 1)
					{
						array2[k] = array4[k / 8];
					}
					else if (k % 8 == 2)
					{
						array2[k] = array5[k / 8];
					}
					else if (k % 8 == 3)
					{
						array2[k] = array6[k / 8];
					}
					else if (k % 8 == 4)
					{
						array2[k] = array7[k / 8];
					}
					else if (k % 8 == 5)
					{
						array2[k] = array8[k / 8];
					}
					else if (k % 8 == 6)
					{
						array2[k] = array9[k / 8];
					}
					else if (k % 8 == 7)
					{
						array2[k] = array10[k / 8];
					}
				}
				for (int l = 0; l < num; l++)
				{
					if (l % 8 == 0)
					{
						array2[l + num3 * 8] = array19[l / 8];
					}
					else if (l % 8 == 1)
					{
						array2[l + num3 * 8] = array20[l / 8];
					}
					else if (l % 8 == 2)
					{
						array2[l + num3 * 8] = array21[l / 8];
					}
					else if (l % 8 == 3)
					{
						array2[l + num3 * 8] = array22[l / 8];
					}
					else if (l % 8 == 4)
					{
						array2[l + num3 * 8] = array23[l / 8];
					}
					else if (l % 8 == 5)
					{
						array2[l + num3 * 8] = array24[l / 8];
					}
					else if (l % 8 == 6)
					{
						array2[l + num3 * 8] = array25[l / 8];
					}
					else if (l % 8 == 7)
					{
						array2[l + num3 * 8] = array26[l / 8];
					}
				}
				break;
			}
			}
			string[] array63 = new string[array2.Length];
			for (int num19 = 0; num19 < array2.Length; num19++)
			{
				string text2 = Convert.ToString(array2[num19], 2);
				while (text2.Length < 8)
				{
					text2 = '0' + text2;
				}
				array63[num19] = text2;
			}
			for (int num20 = 0; num20 < array63.Length; num20++)
			{
				text += array63[num20];
			}
			_ = text.Length;
			int[] array64 = new int[text.Length];
			for (int num21 = 0; num21 < text.Length; num21++)
			{
				array64[num21] = short.Parse(string.Concat(text[num21]));
			}
			return this.method_2(array64);
		}

		private int[] method_1(string string_0)
		{
			List<int> list = new List<int>();
			for (int i = 0; i < string_0.Length; i++)
			{
				int item;
				if (i < string_0.Length - 1 && char.IsDigit(string_0[i]) && char.IsDigit(string_0[i + 1]))
				{
					string value = string_0.Substring(i, 2);
					item = Convert.ToInt32(value) + 130;
					i++;
				}
				else if (char.IsDigit(string_0[i]))
				{
					string value = string_0.Substring(i, 1);
					item = Convert.ToInt32(value) + 49;
				}
				else
				{
					int num = string_0[i] + 1;
					if (num > 128)
					{
						list.Add(235);
						item = num - 128;
					}
					else
					{
						item = num;
					}
				}
				list.Add(item);
			}
			int[] array = new int[24]
			{
				3, 5, 8, 12, 18, 22, 30, 36, 44, 62,
				86, 114, 144, 174, 204, 280, 368, 456, 576, 696,
				816, 1050, 1304, 1558
			};
			bool flag = true;
			int num2 = 0;
			while (flag)
			{
				int[] array2 = array;
				foreach (int num3 in array2)
				{
					if (num3 == list.Count && num3 != 12 && num3 != 36)
					{
						flag = false;
						break;
					}
				}
				if (flag)
				{
					num2++;
					if (num2 > 1)
					{
						int num4 = 0;
						int num5 = 149 * list.Count % 253 + 1;
						int num6 = 129 + num5;
						num4 = ((num6 > 254) ? (num6 - 254) : num6);
						list.Add(num4);
					}
					else
					{
						list.Add(129);
					}
				}
			}
			if (list.Count > 8)
			{
				while (list.Count <= 12)
				{
					list.Add(129);
				}
			}
			else if (list.Count > 30)
			{
				while (list.Count <= 36)
				{
					list.Add(129);
				}
			}
			return list.ToArray();
		}

		private int[,] method_2(int[] int_9)
		{
			Class66[] array = this.method_3();
			this.int_7 = this.int_6;
			if (this.int_6 == 1)
			{
				this.int_7 = 2;
			}
			else if (this.int_6 == 4)
			{
				this.int_7 = this.int_6;
			}
			else if (this.int_6 == 16)
			{
				this.int_7 = this.int_6 - 8;
			}
			else if (this.int_6 == 36)
			{
				this.int_7 = this.int_6 - 24;
			}
			this.int_2 = new int[this.int_3 + this.int_7, this.int_3 + this.int_7];
			int num = 0;
			for (int i = 0; i < this.int_3 + this.int_7; i++)
			{
				for (int j = 0; j < this.int_3 + this.int_7; j++)
				{
					if (i != 0 && i != this.int_4 + 2 && i != this.int_4 * 2 + 4 && i != this.int_4 * 3 + 6 && i != this.int_4 * 4 + 8 && i != this.int_4 * 5 + 10)
					{
						if (j != this.int_4 + 1 && j != this.int_4 * 2 + 3 && j != this.int_4 * 3 + 5 && j != this.int_4 * 4 + 7 && j != this.int_4 * 5 + 9 && j != this.int_4 * 6 + 11)
						{
							if (i != this.int_4 + 1 && i != this.int_4 * 2 + 3 && i != this.int_4 * 3 + 5 && i != this.int_4 * 4 + 7 && i != this.int_4 * 5 + 9 && i != this.int_4 * 6 + 11)
							{
								if (j != 0 && j != this.int_4 + 2 && j != this.int_4 * 2 + 4 && j != this.int_4 * 3 + 6 && j != this.int_4 * 4 + 8 && j != this.int_4 * 5 + 10)
								{
									if (num >= array.Length)
									{
										this.int_2[j, i] = 0;
										continue;
									}
									if (array[num].int_0 == -1)
									{
										this.int_2[j, i] = 0;
										continue;
									}
									if (array[num].int_0 == -2)
									{
										this.int_2[j, i] = 1;
										continue;
									}
									int num2 = (array[num].int_0 - 1) * 8 + (array[num].int_1 - 1);
									this.int_2[j, i] = int_9[num2];
									num++;
								}
								else
								{
									this.int_2[j, i] = 1;
								}
							}
							else
							{
								this.int_2[j, i] = 1;
							}
						}
						else if (i % 2 == 0)
						{
							this.int_2[j, i] = 0;
						}
						else
						{
							this.int_2[j, i] = 1;
						}
					}
					else if (j % 2 == 0)
					{
						this.int_2[j, i] = 1;
					}
					else
					{
						this.int_2[j, i] = 0;
					}
				}
			}
			return this.int_2;
		}

		internal Class66[] method_3()
		{
			Class66[] array = new Class66[this.int_3 * this.int_3];
			this.int_5 = new int[this.int_3 * this.int_3];
			this.method_4();
			int num = 0;
			for (int i = 0; i < this.int_3; i++)
			{
				for (int j = 0; j < this.int_3; j++)
				{
					int num2 = this.int_5[i * this.int_3 + j];
					switch (num2)
					{
					case 0:
					{
						Class66 class3 = (array[num] = new Class66(-1, -1));
						num++;
						break;
					}
					case 1:
					{
						Class66 class2 = (array[num] = new Class66(-2, -2));
						num++;
						break;
					}
					default:
					{
						Class66 @class = (array[num] = new Class66(num2 / 10, num2 % 10));
						num++;
						break;
					}
					}
				}
			}
			return array;
		}

		internal void method_4()
		{
			int i;
			int j;
			for (i = 0; i < this.int_3; i++)
			{
				for (j = 0; j < this.int_3; j++)
				{
					this.int_5[i * this.int_3 + j] = 0;
				}
			}
			int num = 1;
			i = 4;
			j = 0;
			while (i < this.int_3 || j < this.int_3)
			{
				if (i == this.int_3 && j == 0)
				{
					this.method_7(num++);
				}
				if (i == this.int_3 - 2 && j == 0 && this.int_3 % 4 == 0)
				{
					this.method_8(num++);
				}
				if (i == this.int_3 - 2 && j == 0 && this.int_3 % 8 == 4)
				{
					this.method_9(num++);
				}
				if (i == this.int_3 + 4 && j == 2 && this.int_3 % 8 != 0)
				{
					this.method_10(num++);
				}
				while (i >= 0 && j < this.int_3)
				{
					if (i < this.int_3 && j >= 0 && this.int_5[i * this.int_3 + j] == 0)
					{
						this.method_6(i, j, num++);
					}
					i -= 2;
					j += 2;
				}
				i++;
				j += 3;
				while (i < this.int_3 && j >= 0)
				{
					if (i >= 0 && j < this.int_3 && this.int_5[i * this.int_3 + j] == 0)
					{
						this.method_6(i, j, num++);
					}
					i += 2;
					j -= 2;
				}
				i += 3;
				j++;
			}
			if (this.int_5[this.int_3 * this.int_3 - 1] == 0)
			{
				int[] array = this.int_5;
				int num2 = this.int_3 * this.int_3 - 1;
				this.int_5[this.int_3 * this.int_3 - this.int_3 - 2] = 1;
				array[num2] = 1;
			}
		}

		internal void method_5(int int_9, int int_10, int int_11, int int_12)
		{
			if (int_9 < 0)
			{
				int_9 += this.int_3;
				int_10 += 4 - (this.int_3 + 4) % 8;
			}
			if (int_10 < 0)
			{
				int_10 += this.int_3;
				int_9 += 4 - (this.int_3 + 4) % 8;
			}
			this.int_5[int_9 * this.int_3 + int_10] = 10 * int_11 + int_12;
		}

		internal void method_6(int int_9, int int_10, int int_11)
		{
			this.method_5(int_9 - 2, int_10 - 2, int_11, 1);
			this.method_5(int_9 - 2, int_10 - 1, int_11, 2);
			this.method_5(int_9 - 1, int_10 - 2, int_11, 3);
			this.method_5(int_9 - 1, int_10 - 1, int_11, 4);
			this.method_5(int_9 - 1, int_10, int_11, 5);
			this.method_5(int_9, int_10 - 2, int_11, 6);
			this.method_5(int_9, int_10 - 1, int_11, 7);
			this.method_5(int_9, int_10, int_11, 8);
		}

		internal void method_7(int int_9)
		{
			this.method_5(this.int_3 - 1, 0, int_9, 1);
			this.method_5(this.int_3 - 1, 1, int_9, 2);
			this.method_5(this.int_3 - 1, 2, int_9, 3);
			this.method_5(0, this.int_3 - 2, int_9, 4);
			this.method_5(0, this.int_3 - 1, int_9, 5);
			this.method_5(1, this.int_3 - 1, int_9, 6);
			this.method_5(2, this.int_3 - 1, int_9, 7);
			this.method_5(3, this.int_3 - 1, int_9, 8);
		}

		internal void method_8(int int_9)
		{
			this.method_5(this.int_3 - 3, 0, int_9, 1);
			this.method_5(this.int_3 - 2, 0, int_9, 2);
			this.method_5(this.int_3 - 1, 0, int_9, 3);
			this.method_5(0, this.int_3 - 4, int_9, 4);
			this.method_5(0, this.int_3 - 3, int_9, 5);
			this.method_5(0, this.int_3 - 2, int_9, 6);
			this.method_5(0, this.int_3 - 1, int_9, 7);
			this.method_5(1, this.int_3 - 1, int_9, 8);
		}

		internal void method_9(int int_9)
		{
			this.method_5(this.int_3 - 3, 0, int_9, 1);
			this.method_5(this.int_3 - 2, 0, int_9, 2);
			this.method_5(this.int_3 - 1, 0, int_9, 3);
			this.method_5(0, this.int_3 - 2, int_9, 4);
			this.method_5(0, this.int_3 - 1, int_9, 5);
			this.method_5(1, this.int_3 - 1, int_9, 6);
			this.method_5(2, this.int_3 - 1, int_9, 7);
			this.method_5(3, this.int_3 - 1, int_9, 8);
		}

		internal void method_10(int int_9)
		{
			this.method_5(this.int_3 - 1, 0, int_9, 1);
			this.method_5(this.int_3 - 1, this.int_3 - 1, int_9, 2);
			this.method_5(0, this.int_3 - 3, int_9, 3);
			this.method_5(0, this.int_3 - 2, int_9, 4);
			this.method_5(0, this.int_3 - 1, int_9, 5);
			this.method_5(1, this.int_3 - 3, int_9, 6);
			this.method_5(1, this.int_3 - 2, int_9, 7);
			this.method_5(1, this.int_3 - 1, int_9, 8);
		}
	}
}
