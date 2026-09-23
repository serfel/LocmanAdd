using System.Collections.Generic;

namespace ns0
{
	internal class Class64
	{
		protected bool bool_0 = true;

		internal Class37 method_0(List<string> list_0, FourState class20_0)
		{
			float num = 1f;
			float num2 = 0f;
			foreach (string item in list_0)
			{
				num2 += (float)item.Length;
			}
			num2 *= 2f;
			num2 -= 1f;
			float num3 = 8f;
			float num4 = 0f;
			Class37 @class = new Class37(num2, num3);
			for (int i = 0; i < list_0.Count; i++)
			{
				string text = list_0[i];
				for (int j = 0; j < text.Length; j++)
				{
					if (text[j] == 'A')
					{
						@class.method_0(new Class30((float)i + num4, 0f, 1f, num * 5f));
					}
					else if (text[j] == 'D')
					{
						@class.method_0(new Class30((float)i + num4, 3f, 1f, 5f));
					}
					else if (text[j] == 'F')
					{
						@class.method_0(new Class30((float)i + num4, 0f, 1f, num3));
					}
					else if (text[j] == 'T')
					{
						@class.method_0(new Class30((float)i + num4, 3f, 1f, 2f));
					}
					num4 += 2f;
				}
				num4 -= 1f;
			}
			return @class;
		}

		internal Class37 method_1(List<string> list_0, Class3 class3_0)
		{
			float num = 1f;
			float float_ = (float)list_0.Count * num * 9f + 1f;
			float num2 = 100f;
			float num3 = 0f;
			Class37 @class = new Class37(float_, num2);
			for (int i = 0; i < list_0.Count; i++)
			{
				string text = list_0[i];
				num3 = 0f;
				for (int j = 0; j < text.Length; j++)
				{
					if (j % 2 == 0)
					{
						@class.method_0(new Class30((float)(i * 9) * num + num3, 0f, (float)int.Parse(string.Concat(text[j])) * num, num2));
					}
					num3 += (float)int.Parse(string.Concat(text[j])) * num;
				}
			}
			@class.method_0(new Class30((float)(list_0.Count * 9) * num, 0f, num, num2));
			return @class;
		}

		internal Class37 method_2(List<string> list_0, Code11 class2_0)
		{
			float num = 0f;
			foreach (string item in list_0)
			{
				num += (float)item.Length;
			}
			num += (float)list_0.Count;
			float num2 = 8f;
			num2 = 100f;
			int num3 = 1;
			Class37 @class = new Class37(num, num2);
			int num4 = 1;
			int num5 = 0;
			for (int i = 0; i < list_0.Count; i++)
			{
				string text = list_0[i];
				for (int j = 0; j < text.Length; j++)
				{
					if (text[j] == '1')
					{
						int num6 = j + 1;
						while (num6 < text.Length && text[num6] == '1')
						{
							num6++;
							num4++;
						}
						@class.method_0(new Class30(j + num3, 0f, num4, num2));
						num5 = j + num3 + num4;
						num4 = 1;
					}
					else
					{
						num5++;
					}
				}
				num3 += text.Length + 1;
				num5++;
			}
			@class.float_0 = num5;
			return @class;
		}

		internal Class37 method_3(List<string> list_0, Class14 class14_0)
		{
			float num = 0f;
			foreach (string item in list_0)
			{
				num += (float)item.Length;
			}
			num *= 2f;
			num -= 1f;
			float float_ = 6f;
			float num2 = 0f;
			Class37 @class = new Class37(num, float_);
			for (int i = 0; i < list_0.Count; i++)
			{
				string text = list_0[i];
				for (int j = 0; j < text.Length; j++)
				{
					if (text[j] == 'A')
					{
						@class.method_0(new Class30((float)i + num2, 0f, 1f, 4f));
					}
					else if (text[j] == 'D')
					{
						@class.method_0(new Class30((float)i + num2, 2f, 1f, 4f));
					}
					else if (text[j] == 'F')
					{
						@class.method_0(new Class30((float)i + num2, 0f, 1f, 6f));
					}
					else if (text[j] == 'T')
					{
						@class.method_0(new Class30((float)i + num2, 2f, 1f, 2f));
					}
					num2 += 2f;
				}
				num2 -= 1f;
			}
			return @class;
		}

		internal Class37 method_4(List<string> list_0, Codabar class1_0)
		{
			int num = 1;
			float float_ = list_0.Count * 1 * 10 + 1;
			float num2 = 50f;
			int num3 = 0;
			Class37 @class = new Class37(float_, num2);
			for (int i = 0; i < list_0.Count; i++)
			{
				string text = list_0[i];
				for (int j = 0; j < text.Length; j++)
				{
					if (j % 2 == 0)
					{
						if (text[j] == '0')
						{
							@class.method_0(new Class30(num3, 0f, num, num2));
							num3 += num;
						}
						else if (text[j] == '1')
						{
							@class.method_0(new Class30(num3, 0f, num * 2, num2));
							num3 += num * 2;
						}
					}
					else
					{
						num3 = ((text[j] != '0') ? (num3 + num * 2) : (num3 + num));
					}
				}
				num3 += num;
			}
			return @class;
		}

		internal Class37 method_5(List<string> list_0, PLANET class11_0)
		{
			float num = 0f;
			foreach (string item in list_0)
			{
				num += (float)item.Length;
			}
			num *= 3f;
			num -= 2f;
			float num2 = 50f;
			int num3 = 0;
			Class37 @class = new Class37(num, num2);
			for (int i = 0; i < list_0.Count; i++)
			{
				string text = list_0[i];
				for (int j = 0; j < text.Length; j++)
				{
					if (text[j] == '1')
					{
						@class.method_0(new Class30(num3, 0f, 1f, num2));
					}
					else
					{
						@class.method_0(new Class30(num3, 25f, 1f, num2 / 2f));
					}
					num3 += 3;
				}
			}
			return @class;
		}

		internal Class37 method_6(string string_0, Class12 class12_0)
		{
			float num = 1f;
			float num2 = (float)string_0.Length * num * 3f;
			float num3 = 100f;
			Class37 @class = new Class37(num2 - 2f, num3);
			float num4 = 0f;
			for (int i = 0; i < string_0.Length; i++)
			{
				char c = string_0[i];
				Class23 class23_;
				if (c == '0')
				{
					num4 = num3 / 2f;
					class23_ = new Class23(num, num3 - num4);
				}
				else
				{
					num4 = num3;
					class23_ = new Class23(num, num4);
				}
				Class33 class33_ = new Class33((float)(i * 3) * num, num3 - num4);
				Class30 class30_ = new Class30(class33_, class23_);
				@class.method_0(class30_);
			}
			return @class;
		}

		internal Class37 method_7(string string_0, IntelligentMail class7_0)
		{
			float num = 1f;
			float float_ = (float)string_0.Length * num * 3f;
			float num2 = 100f;
			Class37 @class = new Class37(float_, num2);
			for (int i = 0; i < string_0.Length; i++)
			{
				switch (string_0[i])
				{
				case 'A':
					@class.method_0(new Class30((float)(i * 3) * num, 0f, num * 2f, num2 * 2f / 3f));
					break;
				case 'T':
					@class.method_0(new Class30((float)(i * 3) * num, num2 * 1f / 3f, num * 2f, num2 * 1f / 3f));
					break;
				case 'F':
					@class.method_0(new Class30((float)(i * 3) * num, 0f, num * 2f, num2));
					break;
				case 'D':
					@class.method_0(new Class30((float)(i * 3) * num, num2 * 1f / 3f, num * 2f, num2 * 2f / 3f));
					break;
				}
			}
			return @class;
		}

		internal Class37 method_8(string string_0, Class19 class19_0)
		{
			float float_ = 100f;
			bool flag = false;
			Class37 @class = new Class37(string_0.Length, float_);
			float num = 0f;
			int num2 = 0;
			for (int i = 0; i < string_0.Length; i++)
			{
				char c = string_0[i];
				if (c != '0')
				{
					if (!flag)
					{
						num2 = i;
					}
					if (i == string_0.Length - 1)
					{
						num += 1f;
						Class33 class33_ = new Class33(num2, 0f);
						Class23 class23_ = new Class23(num, float_);
						Class30 class30_ = new Class30(class33_, class23_);
						@class.method_0(class30_);
					}
					num += 1f;
					flag = true;
				}
				else
				{
					if (flag)
					{
						Class33 class33_2 = new Class33(num2, 0f);
						Class23 class23_2 = new Class23(num, float_);
						Class30 class30_2 = new Class30(class33_2, class23_2);
						@class.method_0(class30_2);
					}
					num = 0f;
					flag = false;
				}
			}
			return @class;
		}

		internal Class37 method_9(string string_0, Class17 class17_0)
		{
			new List<short>();
			float float_ = 100f;
			float float_2 = string_0.Length;
			bool flag = false;
			Class37 @class = new Class37(float_2, float_);
			float_2 = 0f;
			int num = 0;
			for (int i = 0; i < string_0.Length; i++)
			{
				char c = string_0[i];
				if (c != '0')
				{
					if (!flag)
					{
						num = i;
					}
					if (i == string_0.Length - 1)
					{
						float_2 += 1f;
						Class33 class33_ = new Class33(num, 0f);
						Class23 class23_ = new Class23(float_2, float_);
						Class30 class30_ = new Class30(class33_, class23_);
						@class.method_0(class30_);
					}
					float_2 += 1f;
					flag = true;
				}
				else
				{
					if (flag)
					{
						Class33 class33_2 = new Class33(num, 0f);
						Class23 class23_2 = new Class23(float_2, float_);
						Class30 class30_2 = new Class30(class33_2, class23_2);
						@class.method_0(class30_2);
					}
					float_2 = 0f;
					flag = false;
				}
			}
			return @class;
		}

		internal Class37 method_10(string[] string_0, string string_1, Class18 class18_0)
		{
			float float_ = 100f;
			int num = string_1.Length / 2 + 1;
			float float_2 = num * 14;
			Class37 @class = new Class37(float_2, float_);
			float num2 = 0f;
			foreach (string text in string_0)
			{
				float num3 = 1f;
				for (int j = 0; j < text.Length; j++)
				{
					if (text[j] == '1')
					{
						num3 = 2.5f;
					}
					else if (text[j] == '0')
					{
						num3 = 1f;
					}
					if (j % 2 == 0)
					{
						Class33 class33_ = new Class33(num2, 0f);
						Class23 class23_ = new Class23(num3, float_);
						Class30 class30_ = new Class30(class33_, class23_);
						@class.method_0(class30_);
					}
					num2 += num3;
				}
			}
			return @class;
		}

		internal Class37 method_11(string string_0, string string_1, Class15 class15_0)
		{
			new List<short>();
			float num = 100f;
			float float_ = string_0.Length;
			bool flag = false;
			Class37 @class = new Class37(float_, num);
			float_ = 0f;
			int num2 = 0;
			for (int i = 0; i < string_0.Length; i++)
			{
				char c = string_0[i];
				if (c != '0')
				{
					if (!flag)
					{
						num2 = i;
					}
					if (i == string_0.Length - 1)
					{
						float_ += 1f;
						Class33 class33_ = new Class33(num2, 0f);
						float float_2 = num - 5f;
						if (i <= 14 || i >= string_0.Length - 20 || i == string_0.Length / 2 || i == string_0.Length / 2 - 1 || i == string_0.Length / 2 + 1)
						{
							float_2 = num;
						}
						Class23 class23_ = new Class23(float_, float_2);
						Class30 class30_ = new Class30(class33_, class23_);
						@class.method_0(class30_);
					}
					float_ += 1f;
					flag = true;
					continue;
				}
				if (flag)
				{
					Class33 class33_2 = new Class33(num2, 0f);
					float float_3 = num - 5f;
					if (i <= 16 || i >= string_0.Length - 16 || i == string_0.Length / 2 || i == string_0.Length / 2 - 1 || i == string_0.Length / 2 + 1 || i == string_0.Length / 2 + 2 || i == string_0.Length / 2 + 3 || i == string_0.Length / 2 + 4)
					{
						float_3 = num;
					}
					Class23 class23_2 = new Class23(float_, float_3);
					Class30 class30_2 = new Class30(class33_2, class23_2);
					@class.method_0(class30_2);
				}
				float_ = 0f;
				flag = false;
			}
			Class35 class35_ = new Class35("Arial", 6f);
			string string_2 = string.Concat(string_1[0]);
			string string_3 = string_1.Substring(1, 5);
			string string_4 = string_1.Substring(6, 5);
			string string_5 = string.Concat(string_1[string_1.Length - 1]);
			float num3 = 6f;
			@class.method_3(new Class36(string_2, class35_, new Class33(3f, num - 20f)));
			num3 = 15.5f;
			@class.method_3(new Class36(string_3, class35_, new Class33(33f, num - 20f)));
			num3 = 54.5f;
			@class.method_3(new Class36(string_4, class35_, new Class33(72f, num - 20f)));
			num3 = (float)string_0.Length - 5.8f;
			@class.method_3(new Class36(string_5, class35_, new Class33(num3 + 3f, num - 20f)));
			return @class;
		}

		internal Class37 method_12(string string_0, Class6 class6_0)
		{
			new List<short>();
			float float_ = 100f;
			float float_2 = string_0.Length;
			bool flag = false;
			Class37 @class = new Class37(float_2, float_);
			float_2 = 0f;
			int num = 0;
			for (int i = 0; i < string_0.Length; i++)
			{
				char c = string_0[i];
				if (c != '0')
				{
					if (!flag)
					{
						num = i;
					}
					if (i == string_0.Length - 1)
					{
						float_2 += 1f;
						Class33 class33_ = new Class33(num, 0f);
						Class23 class23_ = new Class23(float_2, float_);
						Class30 class30_ = new Class30(class33_, class23_);
						@class.method_0(class30_);
					}
					float_2 += 1f;
					flag = true;
				}
				else
				{
					if (flag)
					{
						Class33 class33_2 = new Class33(num, 0f);
						Class23 class23_2 = new Class23(float_2, float_);
						Class30 class30_2 = new Class30(class33_2, class23_2);
						@class.method_0(class30_2);
					}
					float_2 = 0f;
					flag = false;
				}
			}
			return @class;
		}

		internal Class37 method_13(Class63[] class63_0)
		{
			float num = (class63_0.Length - 1) * 11 + 13;
			float float_ = 100f;
			float float_2 = num;
			Class37 @class = new Class37(float_2, float_);
			float num2 = 0f;
			foreach (Class63 class2 in class63_0)
			{
				for (int j = 0; j < class2.int_0.Length; j++)
				{
					int num3 = class2.int_0[j];
					Class33 class33_ = new Class33(num2, 0f);
					Class23 class3 = new Class23(num3, float_);
					if (j % 2 == 0)
					{
						Class30 class30_ = new Class30(class33_, class3);
						@class.method_0(class30_);
					}
					num2 += class3.float_0;
				}
			}
			return @class;
		}

		internal Class37 method_14(string string_0, EAN13 class5_0)
		{
			float float_ = 100f;
			float float_2 = string_0.Length;
			bool flag = false;
			Class37 @class = new Class37(float_2, float_);
			float_2 = 0f;
			int num = 0;
			for (int i = 0; i < string_0.Length; i++)
			{
				char c = string_0[i];
				if (c != '0')
				{
					if (!flag)
					{
						num = i;
					}
					if (i == string_0.Length - 1)
					{
						float_2 += 1f;
						Class33 class33_ = new Class33(num, 0f);
						Class23 class23_ = new Class23(float_2, float_);
						Class30 class30_ = new Class30(class33_, class23_);
						@class.method_0(class30_);
					}
					float_2 += 1f;
					flag = true;
				}
				else
				{
					if (flag)
					{
						Class33 class33_2 = new Class33(num, 0f);
						Class23 class23_2 = new Class23(float_2, float_);
						Class30 class30_2 = new Class30(class33_2, class23_2);
						@class.method_0(class30_2);
					}
					float_2 = 0f;
					flag = false;
				}
			}
			return @class;
		}
	}
}
