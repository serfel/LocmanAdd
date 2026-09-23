using System;
using System.Collections.Generic;
using System.Globalization;

namespace ns22
{
	internal class Class402
	{
		internal const int int_0 = 3;

		internal const int int_1 = 5;

		internal const int int_2 = 6;

		internal const int int_3 = 8;

		internal const int int_4 = 9;

		internal const int int_5 = 10;

		internal const int int_6 = 11;

		internal const int int_7 = 12;

		internal const int int_8 = 13;

		internal const int int_9 = 14;

		internal const int int_10 = 15;

		internal const int int_11 = 16;

		internal const int int_12 = 17;

		internal const int int_13 = 41;

		internal const int int_14 = 42;

		internal const int int_15 = 18;

		internal const int int_16 = 19;

		internal const int int_17 = 20;

		internal const int int_18 = 21;

		internal const int int_19 = 22;

		internal const int int_20 = 23;

		internal const int int_21 = 24;

		internal const int int_22 = 25;

		internal const int int_23 = 26;

		internal const int int_24 = 27;

		internal const int int_25 = 28;

		internal const int int_26 = 29;

		internal const int int_27 = 30;

		internal const int int_28 = 31;

		internal const int int_29 = 32;

		internal const int int_30 = 33;

		internal const int int_31 = 34;

		internal int int_32;

		internal List<Class402> list_0;

		internal string string_0;

		internal char char_0;

		internal int int_33;

		internal int int_34;

		internal Class399.Enum48 enum48_0;

		internal Class402 class402_0;

		internal Class402(int int_35, Class399.Enum48 enum48_1)
		{
			this.int_32 = int_35;
			this.enum48_0 = enum48_1;
		}

		internal Class402(int int_35, Class399.Enum48 enum48_1, char char_1)
		{
			this.int_32 = int_35;
			this.enum48_0 = enum48_1;
			this.char_0 = char_1;
		}

		internal Class402(int int_35, Class399.Enum48 enum48_1, string string_1)
		{
			this.int_32 = int_35;
			this.enum48_0 = enum48_1;
			this.string_0 = string_1;
		}

		internal Class402(int int_35, Class399.Enum48 enum48_1, int int_36)
		{
			this.int_32 = int_35;
			this.enum48_0 = enum48_1;
			this.int_33 = int_36;
		}

		internal Class402(int int_35, Class399.Enum48 enum48_1, int int_36, int int_37)
		{
			this.int_32 = int_35;
			this.enum48_0 = enum48_1;
			this.int_33 = int_36;
			this.int_34 = int_37;
		}

		internal Class402 method_0()
		{
			if ((this.enum48_0 & Class399.Enum48.const_7) != 0 && this.int_32 == 25 && this.list_0 != null)
			{
				this.list_0.Reverse(0, this.list_0.Count);
			}
			return this;
		}

		internal Class402 method_1(bool bool_0, int int_35, int int_36)
		{
			if (int_35 == 0 && int_36 == 0)
			{
				return new Class402(23, this.enum48_0);
			}
			if (int_35 == 1 && int_36 == 1)
			{
				return this;
			}
			switch (this.int_32)
			{
			default:
			{
				Class402 @class = new Class402(bool_0 ? 27 : 26, this.enum48_0, int_35, int_36);
				@class.method_2(this);
				return @class;
			}
			case 9:
			case 10:
			case 11:
				this.method_5(bool_0 ? 6 : 3, int_35, int_36);
				return this;
			}
		}

		internal void method_2(Class402 class402_1)
		{
			if (this.list_0 == null)
			{
				this.list_0 = new List<Class402>(4);
			}
			Class402 @class = class402_1.method_6();
			this.list_0.Add(@class);
			@class.class402_0 = this;
		}

		internal int method_3()
		{
			if (this.list_0 != null)
			{
				return this.list_0.Count;
			}
			return 0;
		}

		internal int method_4()
		{
			return this.int_32;
		}

		private void method_5(int int_35, int int_36, int int_37)
		{
			this.int_32 += int_35 - 9;
			this.int_33 = int_36;
			this.int_34 = int_37;
		}

		private Class402 method_6()
		{
			switch (this.method_4())
			{
			case 24:
				return this.method_11();
			case 25:
				return this.method_12();
			case 26:
			case 27:
				return this.method_9();
			default:
				return this;
			case 29:
				return this.method_8();
			case 5:
			case 11:
				return this.method_10();
			}
		}

		private Class402 method_7(int int_35)
		{
			return this.method_3() switch
			{
				0 => new Class402(int_35, this.enum48_0), 
				1 => this.method_13(0), 
				_ => this, 
			};
		}

		private Class402 method_8()
		{
			Class402 @class = this;
			while (@class.method_4() == 29)
			{
				@class = @class.method_13(0);
			}
			return @class;
		}

		private Class402 method_9()
		{
			Class402 @class = this;
			int num = this.method_4();
			int num2 = this.int_33;
			int num3 = this.int_34;
			while (@class.method_3() != 0)
			{
				Class402 class2 = @class.method_13(0);
				if (class2.method_4() != num)
				{
					int num4 = class2.method_4();
					if ((num4 < 3 || num4 > 5 || num != 26) && (num4 < 6 || num4 > 8 || num != 27))
					{
						break;
					}
				}
				if ((@class.int_33 == 0 && class2.int_33 > 1) || class2.int_34 < class2.int_33 * 2)
				{
					break;
				}
				@class = class2;
				if (@class.int_33 > 0)
				{
					num2 = (@class.int_33 = ((2147483646 / @class.int_33 < num2) ? int.MaxValue : (@class.int_33 * num2)));
				}
				if (@class.int_34 > 0)
				{
					num3 = (@class.int_34 = ((2147483646 / @class.int_34 < num3) ? int.MaxValue : (@class.int_34 * num3)));
				}
			}
			if (num2 != int.MaxValue)
			{
				return @class;
			}
			return new Class402(22, this.enum48_0);
		}

		private Class402 method_10()
		{
			if (Class395.smethod_2(this.string_0))
			{
				this.int_32 = 22;
				this.string_0 = null;
			}
			else if (Class395.smethod_3(this.string_0))
			{
				this.char_0 = Class395.smethod_0(this.string_0);
				this.string_0 = null;
				this.int_32 += -2;
			}
			else if (Class395.smethod_4(this.string_0))
			{
				this.char_0 = Class395.smethod_0(this.string_0);
				this.string_0 = null;
				this.int_32 += -1;
			}
			return this;
		}

		private Class402 method_11()
		{
			if (this.list_0 == null)
			{
				return new Class402(22, this.enum48_0);
			}
			bool flag = false;
			bool flag2 = false;
			Class399.Enum48 @enum = Class399.Enum48.const_0;
			int i = 0;
			int j;
			for (j = 0; i < this.list_0.Count; i++, j++)
			{
				Class402 @class = this.list_0[i];
				if (j < i)
				{
					this.list_0[j] = @class;
				}
				if (@class.int_32 == 24)
				{
					for (int k = 0; k < @class.list_0.Count; k++)
					{
						@class.list_0[k].class402_0 = this;
					}
					this.list_0.InsertRange(i + 1, @class.list_0);
					j--;
					continue;
				}
				if (@class.int_32 != 11 && @class.int_32 != 9)
				{
					if (@class.int_32 == 22)
					{
						j--;
						continue;
					}
					flag = false;
					flag2 = false;
					continue;
				}
				Class399.Enum48 enum2 = @class.enum48_0 & (Class399.Enum48)65;
				if (@class.int_32 == 11)
				{
					if (!flag || @enum != enum2 || flag2 || !Class395.smethod_1(@class.string_0))
					{
						flag = true;
						flag2 = !Class395.smethod_1(@class.string_0);
						@enum = enum2;
						continue;
					}
				}
				else if (!flag || @enum != enum2 || flag2)
				{
					flag = true;
					flag2 = false;
					@enum = enum2;
					continue;
				}
				j--;
				Class402 class2 = this.list_0[j];
				Class395 class3;
				if (class2.int_32 == 9)
				{
					class3 = new Class395();
					class3.method_1(class2.char_0, class2.char_0);
				}
				else
				{
					class3 = Class395.smethod_7(class2.string_0);
				}
				if (@class.int_32 == 9)
				{
					class3.method_1(@class.char_0, @class.char_0);
				}
				else
				{
					Class395 class395_ = Class395.smethod_7(@class.string_0);
					class3.method_0(class395_);
				}
				class2.int_32 = 11;
				class2.string_0 = class3.method_7();
			}
			if (j < i)
			{
				this.list_0.RemoveRange(j, i - j);
			}
			return this.method_7(22);
		}

		private Class402 method_12()
		{
			if (this.list_0 == null)
			{
				return new Class402(23, this.enum48_0);
			}
			bool flag = false;
			Class399.Enum48 @enum = Class399.Enum48.const_0;
			int num = 0;
			int num2 = 0;
			while (num < this.list_0.Count)
			{
				Class402 @class = this.list_0[num];
				if (num2 < num)
				{
					this.list_0[num2] = @class;
				}
				if (@class.int_32 == 25 && (@class.enum48_0 & Class399.Enum48.const_7) == (this.enum48_0 & Class399.Enum48.const_7))
				{
					for (int i = 0; i < @class.list_0.Count; i++)
					{
						@class.list_0[i].class402_0 = this;
					}
					this.list_0.InsertRange(num + 1, @class.list_0);
					num2--;
				}
				else if (@class.int_32 != 12 && @class.int_32 != 9)
				{
					if (@class.int_32 == 23)
					{
						num2--;
					}
					else
					{
						flag = false;
					}
				}
				else
				{
					Class399.Enum48 enum2 = @class.enum48_0 & (Class399.Enum48)65;
					if (flag && @enum == enum2)
					{
						Class402 class2 = this.list_0[--num2];
						if (class2.int_32 == 9)
						{
							class2.int_32 = 12;
							class2.string_0 = Convert.ToString(class2.char_0, CultureInfo.InvariantCulture);
						}
						if ((enum2 & Class399.Enum48.const_7) == 0)
						{
							if (@class.int_32 == 9)
							{
								class2.string_0 += @class.char_0;
							}
							else
							{
								class2.string_0 += @class.string_0;
							}
						}
						else if (@class.int_32 == 9)
						{
							class2.string_0 = @class.char_0 + class2.string_0;
						}
						else
						{
							class2.string_0 = @class.string_0 + class2.string_0;
						}
					}
					else
					{
						flag = true;
						@enum = enum2;
					}
				}
				num++;
				num2++;
			}
			if (num2 < num)
			{
				this.list_0.RemoveRange(num2, num - num2);
			}
			return this.method_7(23);
		}

		private Class402 method_13(int int_35)
		{
			return this.list_0[int_35];
		}
	}
}
