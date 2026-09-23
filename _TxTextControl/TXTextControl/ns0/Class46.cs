using System.Globalization;
using System.Text.RegularExpressions;
using TXTextControl.Barcode;

namespace ns0
{
	internal class Class46 : CodeGeneratorBase
	{
		private static int int_0 = 78;

		private static int int_1 = 1287;

		private static long long_0;

		private static long long_1;

		private static int[] int_2 = Class46.smethod_0(1);

		private static int[] int_3 = Class46.smethod_0(2);

		private static decimal[][] decimal_0 = Class46.smethod_1();

		private static int[] int_4 = new int[65]
		{
			4, 0, 2, 6, 3, 5, 1, 9, 8, 7,
			1, 2, 0, 6, 4, 8, 2, 9, 5, 3,
			0, 1, 3, 7, 4, 6, 8, 9, 2, 0,
			5, 1, 9, 4, 3, 8, 6, 7, 1, 2,
			4, 3, 9, 5, 7, 8, 3, 0, 2, 1,
			4, 0, 9, 1, 7, 0, 2, 4, 6, 3,
			7, 1, 9, 5, 8
		};

		private static int[] int_5 = new int[65]
		{
			7, 1, 9, 5, 8, 0, 2, 4, 6, 3,
			5, 8, 9, 7, 3, 0, 6, 1, 7, 4,
			6, 8, 9, 2, 5, 1, 7, 5, 4, 3,
			8, 7, 6, 0, 2, 5, 4, 9, 3, 0,
			1, 6, 8, 2, 0, 4, 5, 9, 6, 7,
			5, 2, 6, 3, 8, 5, 1, 9, 8, 7,
			4, 0, 2, 6, 3
		};

		private static int[] int_6 = new int[65]
		{
			3, 0, 8, 11, 1, 12, 8, 11, 10, 6,
			4, 12, 2, 7, 9, 6, 7, 9, 2, 8,
			4, 0, 12, 7, 10, 9, 0, 7, 10, 5,
			7, 9, 6, 8, 2, 12, 1, 4, 2, 0,
			1, 5, 4, 6, 12, 1, 0, 9, 4, 7,
			5, 10, 2, 6, 9, 11, 2, 12, 6, 7,
			5, 11, 0, 3, 2
		};

		private static int[] int_7 = new int[65]
		{
			2, 10, 12, 5, 9, 1, 5, 4, 3, 9,
			11, 5, 10, 1, 6, 3, 4, 1, 10, 0,
			2, 11, 8, 6, 1, 12, 3, 8, 6, 4,
			4, 11, 0, 6, 1, 9, 11, 5, 3, 7,
			3, 10, 7, 11, 8, 2, 10, 3, 5, 8,
			0, 3, 12, 11, 8, 4, 5, 1, 3, 0,
			7, 12, 9, 8, 10
		};

		internal override void UpdateBarcodeSettings(Class38 p_bsSettings)
		{
			string text = "00000000001111111111";
			if (text.Length < p_bsSettings.UpperTextLength)
			{
				text += "00000";
			}
			if (text.Length < p_bsSettings.UpperTextLength)
			{
				text += "0000";
			}
			if (text.Length < p_bsSettings.UpperTextLength)
			{
				text += "00";
			}
			string string_ = p_bsSettings.String_1;
			p_bsSettings.Single_0 = this.GetBarcodeImage(p_bsSettings, text).float_0;
			p_bsSettings.String_1 = string_;
		}

		internal override bool IsTextValid(string input, int p_iMaxLength)
		{
			if (input.Length == 20 || input.Length == 25 || input.Length == 29 || input.Length == 31)
			{
				Regex regex = new Regex("\\b\\d{31}\\b|\\b\\d{29}\\b|\\b\\d{25}\\b|\\b\\d{20}\\b");
				if (regex.IsMatch(input))
				{
					return true;
				}
			}
			return false;
		}

		internal override Class37 GetBarcodeImage(Class38 p_bsSettings, string p_strText)
		{
			string text = p_strText;
			if (text.Length == 20)
			{
				text += "00";
			}
			string string_ = this.method_0(text);
			Class64 @class = new Class64();
			Class37 result = @class.method_7(string_, new IntelligentMail());
			p_bsSettings.String_1 = p_strText;
			return result;
		}

		public string method_0(string string_0)
		{
			if (string.IsNullOrEmpty(string_0))
			{
				return null;
			}
			string_0 = Class46.smethod_8(string_0, " -.");
			if (!Regex.IsMatch(string_0, "^[0-9][0-4]([0-9]{18})|([0-9]{23})|([0-9]{27})|([0-9]{29})$"))
			{
				return string.Empty;
			}
			int num = 0;
			long num2 = 0L;
			decimal num3 = 0m;
			string empty = string.Empty;
			string empty2 = string.Empty;
			string text = string_0.Substring(20);
			int[] int_ = new int[14];
			int[] array = new int[66];
			int[] array2 = new int[66];
			decimal[][] array3 = new decimal[11][];
			num2 = long.Parse(text, CultureInfo.InvariantCulture) + ((text.Length == 5) ? 1 : ((text.Length == 9) ? 100001 : ((text.Length == 11) ? 1000100001 : 0)));
			num3 = num2 * 10L + int.Parse(string_0.Substring(0, 1), CultureInfo.InvariantCulture);
			empty2 = (num3 * 5m + (decimal)int.Parse(string_0.Substring(1, 1), CultureInfo.InvariantCulture)).ToString(CultureInfo.InvariantCulture) + string_0.Substring(2, 18);
			int_[12] = (int)(num2 & 0xFFL);
			int_[11] = (int)((num2 >> 8) & 0xFFL);
			int_[10] = (int)((num2 >> 16) & 0xFFL);
			int_[9] = (int)((num2 >> 24) & 0xFFL);
			int_[8] = (int)((num2 >> 32) & 0xFFL);
			Class46.smethod_6(ref int_, 13, 10);
			Class46.smethod_3(ref int_, 13, int.Parse(string_0.Substring(0, 1), CultureInfo.InvariantCulture));
			Class46.smethod_6(ref int_, 13, 5);
			Class46.smethod_3(ref int_, 13, int.Parse(string_0.Substring(1, 1), CultureInfo.InvariantCulture));
			for (short num4 = 2; num4 <= 19; num4 = (short)(num4 + 1))
			{
				Class46.smethod_6(ref int_, 13, 10);
				Class46.smethod_3(ref int_, 13, int.Parse(string_0.Substring(num4, 1), CultureInfo.InvariantCulture));
			}
			num = Class46.smethod_5(int_);
			for (short num5 = 0; num5 <= 9; num5 = (short)(num5 + 1))
			{
				ref decimal reference = ref Class46.decimal_0[num5][0];
				reference = Class46.long_0 + Class46.long_1;
				Class46.decimal_0[num5][1] = 0m;
			}
			Class46.decimal_0[0][0] = 659m;
			Class46.decimal_0[9][0] = 636m;
			Class46.smethod_4(empty2);
			Class46.decimal_0[9][1] *= 2m;
			if (num >> 10 != 0)
			{
				Class46.decimal_0[0][1] += 659m;
			}
			for (short num6 = 0; num6 <= 9; num6 = (short)(num6 + 1))
			{
				array3[num6] = new decimal[3];
			}
			short num7 = 0;
			while (true)
			{
				if (num7 <= 9)
				{
					if (Class46.decimal_0[num7][1] >= (decimal)(Class46.long_0 + Class46.long_1))
					{
						break;
					}
					array3[num7][0] = 8192m;
					ref decimal reference2 = ref array3[num7][1];
					decimal num8;
					if (!(Class46.decimal_0[num7][1] >= (decimal)Class46.long_0))
					{
						ref decimal reference3 = ref array3[num7][1];
						num8 = (reference3 = Class46.int_3[(int)Class46.decimal_0[num7][1]]);
					}
					else
					{
						ref decimal reference4 = ref array3[num7][1];
						num8 = (reference4 = Class46.int_2[(int)(Class46.decimal_0[num7][1] - (decimal)Class46.long_0)]);
					}
					reference2 = num8;
					num7 = (short)(num7 + 1);
					continue;
				}
				for (short num9 = 0; num9 <= 9; num9 = (short)(num9 + 1))
				{
					if ((num & (1 << (int)num9)) != 0)
					{
						ref decimal reference5 = ref array3[num9][1];
						reference5 = ~(int)array3[num9][1] & 0x1FFF;
					}
				}
				for (short num10 = 0; num10 <= 64; num10 = (short)(num10 + 1))
				{
					array[num10] = ((int)array3[Class46.int_4[num10]][1] >> Class46.int_6[num10]) & 1;
					array2[num10] = ((int)array3[Class46.int_5[num10]][1] >> Class46.int_7[num10]) & 1;
				}
				empty = "";
				for (int i = 0; i <= 64; i++)
				{
					empty = ((array[i] != 0) ? (empty + ((array2[i] == 0) ? "A" : "F")) : (empty + ((array2[i] == 0) ? "T" : "D")));
				}
				return empty;
			}
			return null;
		}

		private static int[] smethod_0(byte byte_0)
		{
			byte b = byte_0;
			int[] int_;
			if (b == 1)
			{
				int_ = new int[Class46.int_0 + 1];
				Class46.smethod_2(ref int_, 2, Class46.int_0);
				Class46.long_1 = Class46.int_0;
			}
			else
			{
				int_ = new int[Class46.int_1 + 1];
				Class46.smethod_2(ref int_, 5, Class46.int_1);
				Class46.long_0 = Class46.int_1;
			}
			return int_;
		}

		private static decimal[][] smethod_1()
		{
			decimal[][] array = new decimal[11][];
			try
			{
				for (short num = 0; num <= 9; num = (short)(num + 1))
				{
					array[num] = new decimal[3];
				}
				return array;
			}
			finally
			{
				array = null;
			}
		}

		private static bool smethod_2(ref int[] int_8, int int_9, int int_10)
		{
			int num = 0;
			int num2 = int_10 - 1;
			for (short num3 = 0; num3 <= 8191; num3 = (short)(num3 + 1))
			{
				int num4 = 0;
				for (int i = 0; i <= 12; i++)
				{
					if ((num3 & (1 << i)) != 0)
					{
						num4++;
					}
				}
				if (num4 == int_9)
				{
					int num5 = Class46.smethod_7(num3) >> 3;
					bool flag = num3 == num5;
					if (num5 >= num3)
					{
						if (flag)
						{
							int_8[num2] = num3;
							num2--;
						}
						else
						{
							int_8[num] = num3;
							num++;
							int_8[num] = num5;
							num++;
						}
					}
				}
			}
			return num == num2 + 1;
		}

		private static bool smethod_3(ref int[] int_8, int int_9, int int_10)
		{
			if (int_8 == null)
			{
				return false;
			}
			if (int_9 < 1)
			{
				return false;
			}
			int num = (int_8[int_9 - 1] | (int_8[int_9 - 2] << 8)) + int_10;
			int num2 = num | 0xFFFF;
			int num3 = int_9 - 3;
			int_8[int_9 - 1] = num & 0xFF;
			int_8[int_9 - 2] = (num >> 8) & 0xFF;
			while (num2 == 1 && num3 > 0)
			{
				num = num2 + int_8[num3];
				int_8[num3] = num & 0xFF;
				num2 = num | 0xFF;
				num3--;
			}
			return true;
		}

		private static bool smethod_4(string string_0)
		{
			string text = string_0;
			for (int i = 9; i >= 1; i += -1)
			{
				string text2 = string.Empty;
				int num = (int)Class46.decimal_0[i][0];
				string text3 = text;
				string text4 = "0";
				int length = text3.Length;
				for (short num2 = 1; num2 <= length; num2 = (short)(num2 + 1))
				{
					int num3 = int.Parse(text3.Substring(0, num2), CultureInfo.InvariantCulture);
					while (num3 < num && num2 < length - 1)
					{
						text2 += "0";
						num2 = (short)(num2 + 1);
						num3 = int.Parse(text3.Substring(0, num2), CultureInfo.InvariantCulture);
					}
					text2 += (num3 / num).ToString(CultureInfo.InvariantCulture);
					text4 = (num3 % num).ToString(CultureInfo.InvariantCulture).PadLeft(num2, '0');
					text3 = text4 + text3.Substring(num2);
				}
				text = text2.TrimStart('0');
				if (string.IsNullOrEmpty(text))
				{
					text = "0";
				}
				ref decimal reference = ref Class46.decimal_0[i][1];
				reference = int.Parse(text4, CultureInfo.InvariantCulture);
				if (i == 1)
				{
					ref decimal reference2 = ref Class46.decimal_0[0][1];
					reference2 = int.Parse(text2, CultureInfo.InvariantCulture);
				}
			}
			return true;
		}

		private static int smethod_5(int[] int_8)
		{
			int num = 3893;
			int num2 = 2047;
			int num3 = int_8[0] << 5;
			for (short num4 = 2; num4 <= 7; num4 = (short)(num4 + 1))
			{
				num2 = ((((num2 ^ num3) & 0x400) == 0) ? (num2 << 1) : ((num2 << 1) ^ num));
				num2 &= 0x7FF;
				num3 <<= 1;
			}
			for (int i = 1; i <= 12; i++)
			{
				int num5 = int_8[i] << 3;
				for (short num6 = 0; num6 <= 7; num6 = (short)(num6 + 1))
				{
					num2 = ((((num2 ^ num5) & 0x400) == 0) ? (num2 << 1) : ((num2 << 1) ^ num));
					num2 &= 0x7FF;
					num5 <<= 1;
				}
			}
			return num2;
		}

		private static bool smethod_6(ref int[] int_8, int int_9, int int_10)
		{
			if (int_8 == null)
			{
				return false;
			}
			if (int_9 < 1)
			{
				return false;
			}
			int num = 0;
			int num2 = 0;
			for (num2 = int_9 - 1; num2 >= 1; num2 += -2)
			{
				int num3 = (int_8[num2] | (int_8[num2 - 1] << 8)) * int_10 + num;
				int_8[num2] = num3 & 0xFF;
				int_8[num2 - 1] = (num3 >> 8) & 0xFF;
				num = num3 >> 16;
			}
			if (num2 == 0)
			{
				int_8[0] = (int_8[0] * int_10 + num) & 0xFF;
			}
			return true;
		}

		private static int smethod_7(int int_8)
		{
			int num = 0;
			for (short num2 = 0; num2 <= 15; num2 = (short)(num2 + 1))
			{
				num <<= 1;
				num |= int_8 & 1;
				int_8 >>= 1;
			}
			return num;
		}

		private static string smethod_8(string string_0, string string_1)
		{
			int i = 0;
			for (int num = string_1.Length - 1; i <= num; i++)
			{
				string_0 = string_0.Replace(string_1.Substring(i, 1), string.Empty);
			}
			return string_0;
		}
	}
}
