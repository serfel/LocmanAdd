using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace ns22
{
	internal class Class399
	{
		internal enum Enum48
		{
			const_0 = 0,
			const_1 = 1,
			const_2 = 2,
			const_3 = 4,
			const_4 = 8,
			const_5 = 0x10,
			const_6 = 0x20,
			const_7 = 0x40,
			const_8 = 0x100,
			const_9 = 0x200
		}

		private class Class400
		{
			internal Class395 class395_0;

			internal bool bool_0;

			internal bool bool_1;

			internal char char_0;

			internal char char_1;

			internal bool bool_2;

			internal bool bool_3 = true;

			internal bool bool_4;

			internal Class400(bool bool_5, bool bool_6)
			{
				this.bool_1 = bool_5;
				this.bool_0 = bool_6;
			}
		}

		private class Class401
		{
			internal char char_0;

			internal int int_0;

			internal char char_1 = '>';
		}

		private const int int_0 = 214748364;

		private const int int_1 = 7;

		private Class402 class402_0;

		private Class402 class402_1;

		private Class402 class402_2;

		private Class402 class402_3;

		private Class402 class402_4;

		private string string_0;

		private int int_2;

		private CultureInfo cultureInfo_0;

		private int int_3;

		private int int_4;

		private int int_5;

		private Hashtable hashtable_0;

		private Hashtable hashtable_1;

		private int[] int_6;

		private List<string> list_0;

		private Enum48 enum48_0;

		private List<Enum48> list_1;

		private bool bool_0;

		private static readonly byte[] byte_0 = new byte[128]
		{
			0, 0, 0, 0, 0, 0, 0, 0, 0, 2,
			2, 0, 2, 2, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 2, 0, 0, 3, 4, 0, 0, 0,
			4, 4, 5, 5, 0, 0, 4, 0, 0, 0,
			0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 5, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
			0, 4, 4, 0, 4, 0, 0, 0, 0, 0,
			0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 5, 4, 0, 0, 0
		};

		private Class399(CultureInfo cultureInfo_1)
		{
			this.cultureInfo_0 = cultureInfo_1;
			this.list_1 = new List<Enum48>();
			this.hashtable_0 = new Hashtable();
		}

		internal static bool smethod_0(string string_1, Enum48 enum48_1, out string string_2)
		{
			Class398 @class = new Class398();
			string_2 = null;
			Class399 class2 = new Class399(((enum48_1 & Enum48.const_9) != 0) ? CultureInfo.InvariantCulture : CultureInfo.CurrentCulture);
			class2.enum48_0 = enum48_1;
			class2.method_0(string_1);
			class2.method_7(@class);
			if (!@class.Boolean_0)
			{
				string_2 = @class.String_0;
				return false;
			}
			class2.method_1(enum48_1);
			class2.method_11(@class);
			if (!@class.Boolean_0)
			{
				string_2 = @class.String_0;
				return false;
			}
			return true;
		}

		internal static string smethod_1(string string_1)
		{
			Class398 @class = new Class398();
			int i = 0;
			while (true)
			{
				if (i < string_1.Length)
				{
					if (string_1[i] == '\\')
					{
						break;
					}
					i++;
					continue;
				}
				return string_1;
			}
			StringBuilder stringBuilder = new StringBuilder();
			Class399 class2 = new Class399(CultureInfo.InvariantCulture);
			class2.method_0(string_1);
			stringBuilder.Append(string_1, 0, i);
			do
			{
				if ((class2.int_2 = i + 1) < string_1.Length)
				{
					stringBuilder.Append(class2.method_34(@class));
					if (!@class.Boolean_0)
					{
						return string_1;
					}
				}
				i = class2.int_2;
				int num = i;
				for (; i < string_1.Length && string_1[i] != '\\'; i++)
				{
				}
				stringBuilder.Append(string_1, num, i - num);
			}
			while (i < string_1.Length);
			return stringBuilder.ToString();
		}

		private void method_0(string string_1)
		{
			if (string_1 == null)
			{
				string_1 = string.Empty;
			}
			this.string_0 = string_1;
			this.int_2 = 0;
		}

		private void method_1(Enum48 enum48_1)
		{
			this.int_2 = 0;
			this.int_3 = 1;
			this.bool_0 = false;
			if (this.list_1.Count > 0)
			{
				this.list_1.RemoveRange(0, this.list_1.Count - 1);
			}
			this.enum48_0 = enum48_1;
			this.class402_0 = null;
		}

		private void method_2(Class398 class398_0)
		{
			if ((this.enum48_0 & Enum48.const_6) != 0)
			{
				while (true)
				{
					if (this.string_0.Length - this.int_2 <= 0 || !Class399.smethod_3(this.string_0[this.int_2]))
					{
						if (this.string_0.Length - this.int_2 == 0)
						{
							break;
						}
						if (this.string_0[this.int_2] == '#')
						{
							while (this.string_0.Length - this.int_2 > 0 && this.string_0[this.int_2] != '\n')
							{
								this.int_2++;
							}
							continue;
						}
						if (this.string_0.Length - this.int_2 < 3 || this.string_0[this.int_2 + 2] != '#' || this.string_0[this.int_2 + 1] != '?' || this.string_0[this.int_2] != '(')
						{
							break;
						}
						while (this.string_0.Length - this.int_2 > 0 && this.string_0[this.int_2] != ')')
						{
							this.int_2++;
						}
						if (this.string_0.Length - this.int_2 == 0)
						{
							class398_0.Boolean_0 = false;
							class398_0.String_0 = "SR.GetString(SR.UnterminatedComment)";
							break;
						}
						this.int_2++;
					}
					else
					{
						this.int_2++;
					}
				}
				return;
			}
			while (this.string_0.Length - this.int_2 >= 3 && this.string_0[this.int_2 + 2] == '#' && this.string_0[this.int_2 + 1] == '?' && this.string_0[this.int_2] == '(')
			{
				while (this.string_0.Length - this.int_2 > 0 && this.string_0[this.int_2] != ')')
				{
					this.int_2++;
				}
				if (this.string_0.Length - this.int_2 != 0)
				{
					this.int_2++;
					continue;
				}
				class398_0.Boolean_0 = false;
				class398_0.String_0 = "SR.GetString(SR.UnterminatedComment)";
				break;
			}
		}

		private string method_3()
		{
			int num = this.int_2;
			while (this.string_0.Length - this.int_2 > 0)
			{
				if (!Class395.smethod_6(this.string_0[this.int_2++]))
				{
					this.int_2--;
					break;
				}
			}
			return this.string_0.Substring(num, this.int_2 - num);
		}

		private int method_4(Class398 class398_0)
		{
			int num = 0;
			int num2;
			while (this.string_0.Length - this.int_2 > 0 && (uint)(num2 = (ushort)(this.string_0[this.int_2] - 48)) <= 9u)
			{
				this.int_2++;
				if (num <= 214748364 && (num != 214748364 || num2 <= 7))
				{
					num *= 10;
					num += num2;
					continue;
				}
				class398_0.Boolean_0 = false;
				class398_0.String_0 = "SR.GetString(SR.CaptureGroupOutOfRange)";
				break;
			}
			return num;
		}

		private bool method_5(Enum48 enum48_1)
		{
			if (enum48_1 != Enum48.const_7 && enum48_1 != Enum48.const_4 && enum48_1 != Enum48.const_9)
			{
				return enum48_1 == Enum48.const_8;
			}
			return true;
		}

		private void method_6()
		{
			bool flag = false;
			while (this.string_0.Length - this.int_2 > 0)
			{
				char c = this.string_0[this.int_2];
				switch (c)
				{
				case '-':
					flag = true;
					break;
				case '+':
					flag = false;
					break;
				default:
				{
					Enum48 @enum = Class399.smethod_2(c);
					if (@enum != 0 && !this.method_5(@enum))
					{
						if (flag)
						{
							this.enum48_0 &= ~@enum;
						}
						else
						{
							this.enum48_0 |= @enum;
						}
						break;
					}
					return;
				}
				}
				this.int_2++;
			}
		}

		private static Enum48 smethod_2(char char_0)
		{
			if (char_0 >= 'A' && char_0 <= 'Z')
			{
				char_0 = (char)(char_0 + 32);
			}
			return char_0 switch
			{
				'i' => Enum48.const_1, 
				'c' => Enum48.const_4, 
				'e' => Enum48.const_8, 
				'x' => Enum48.const_6, 
				'm' => Enum48.const_2, 
				'n' => Enum48.const_3, 
				'r' => Enum48.const_7, 
				's' => Enum48.const_5, 
				_ => Enum48.const_0, 
			};
		}

		private static bool smethod_3(char char_0)
		{
			if (char_0 <= ' ')
			{
				return Class399.byte_0[(uint)char_0] == 2;
			}
			return false;
		}

		private void method_7(Class398 class398_0)
		{
			this.method_9(0, 0);
			this.int_3 = 1;
			while (true)
			{
				if (this.string_0.Length - this.int_2 > 0)
				{
					int num = this.int_2;
					switch (this.string_0[this.int_2++])
					{
					case '[':
						this.method_15(bool_1: false, bool_2: true, class398_0);
						if (!class398_0.Boolean_0)
						{
							return;
						}
						break;
					case '\\':
						if (this.string_0.Length - this.int_2 > 0)
						{
							this.int_2++;
						}
						break;
					case '(':
						if (this.string_0.Length - this.int_2 >= 2 && this.string_0[this.int_2 + 1] == '#' && this.string_0[this.int_2] == '?')
						{
							this.int_2--;
							this.method_2(class398_0);
							if (!class398_0.Boolean_0)
							{
								return;
							}
						}
						else
						{
							this.list_1.Add(this.enum48_0);
							if (this.string_0.Length - this.int_2 > 0 && this.string_0[this.int_2] == '?')
							{
								this.int_2++;
								if (this.string_0.Length - this.int_2 > 1 && (this.string_0[this.int_2] == '<' || this.string_0[this.int_2] == '\''))
								{
									this.int_2++;
									char c = this.string_0[this.int_2];
									if (c != '0' && Class395.smethod_6(c))
									{
										if (c >= '1' && c <= '9')
										{
											this.method_9(this.method_4(class398_0), num);
											if (!class398_0.Boolean_0)
											{
												return;
											}
										}
										else
										{
											this.method_10(this.method_3(), num);
										}
									}
								}
								else
								{
									this.method_6();
									if (this.string_0.Length - this.int_2 > 0)
									{
										if (this.string_0[this.int_2] == ')')
										{
											this.int_2++;
											this.list_1.RemoveAt(this.list_1.Count - 1);
										}
										else if (this.string_0[this.int_2] == '(')
										{
											this.bool_0 = true;
											break;
										}
									}
								}
							}
							else if ((this.enum48_0 & Enum48.const_3) == 0 && !this.bool_0)
							{
								this.method_9(this.int_3++, num);
							}
						}
						this.bool_0 = false;
						break;
					case ')':
						if (this.list_1.Count != 0)
						{
							this.enum48_0 = this.list_1[this.list_1.Count - 1];
							this.list_1.RemoveAt(this.list_1.Count - 1);
						}
						break;
					case '#':
						if ((this.enum48_0 & Enum48.const_6) != 0)
						{
							this.int_2--;
							this.method_2(class398_0);
							if (!class398_0.Boolean_0)
							{
								return;
							}
						}
						break;
					}
					continue;
				}
				this.method_8();
				break;
			}
		}

		private void method_8()
		{
			if (this.hashtable_1 != null)
			{
				for (int i = 0; i < this.list_0.Count; i++)
				{
					while (this.hashtable_0.ContainsKey(this.int_3))
					{
						this.int_3++;
					}
					string key = this.list_0[i];
					int int_ = (int)this.hashtable_1[key];
					this.hashtable_1[key] = this.int_3;
					this.method_9(this.int_3, int_);
					this.int_3++;
				}
			}
			if (this.int_4 < this.int_5)
			{
				this.int_6 = new int[this.int_4];
				int num = 0;
				IDictionaryEnumerator enumerator = this.hashtable_0.GetEnumerator();
				while (enumerator.MoveNext())
				{
					this.int_6[num++] = (int)enumerator.Key;
				}
				Array.Sort(this.int_6, Comparer<int>.Default);
			}
			if (this.hashtable_1 == null && this.int_6 == null)
			{
				return;
			}
			int num2 = 0;
			List<string> list;
			int num3;
			if (this.hashtable_1 == null)
			{
				list = null;
				this.hashtable_1 = new Hashtable();
				this.list_0 = new List<string>();
				num3 = -1;
			}
			else
			{
				list = this.list_0;
				this.list_0 = new List<string>();
				num3 = (int)this.hashtable_1[list[0]];
			}
			for (int j = 0; j < this.int_4; j++)
			{
				int num4 = ((this.int_6 == null) ? j : this.int_6[j]);
				if (num3 == num4)
				{
					this.list_0.Add(list[num2++]);
					num3 = ((num2 == list.Count) ? (-1) : ((int)this.hashtable_1[list[num2]]));
				}
				else
				{
					string text = Convert.ToString(num4, this.cultureInfo_0);
					this.list_0.Add(text);
					this.hashtable_1[text] = num4;
				}
			}
		}

		private void method_9(int int_7, int int_8)
		{
			if (this.hashtable_0.ContainsKey(int_7))
			{
				return;
			}
			this.hashtable_0.Add(int_7, int_8);
			this.int_4++;
			if (this.int_5 <= int_7)
			{
				if (int_7 == int.MaxValue)
				{
					this.int_5 = int_7;
				}
				else
				{
					this.int_5 = int_7 + 1;
				}
			}
		}

		private void method_10(string string_1, int int_7)
		{
			if (this.hashtable_1 == null)
			{
				this.hashtable_1 = new Hashtable();
				this.list_0 = new List<string>();
			}
			if (!this.hashtable_1.ContainsKey(string_1))
			{
				this.hashtable_1.Add(string_1, int_7);
				this.list_0.Add(string_1);
			}
		}

		private Class402 method_11(Class398 class398_0)
		{
			char c = '@';
			bool flag = false;
			this.method_29(new Class402(28, this.enum48_0, 0, -1));
			while (true)
			{
				if (this.string_0.Length - this.int_2 > 0)
				{
					bool flag2 = flag;
					flag = false;
					this.method_2(class398_0);
					if (!class398_0.Boolean_0)
					{
						break;
					}
					int num = this.int_2;
					if ((this.enum48_0 & Enum48.const_6) != 0)
					{
						while (this.string_0.Length - this.int_2 > 0 && (!Class399.smethod_5(c = this.string_0[this.int_2]) || (c == '{' && !this.method_26())))
						{
							this.int_2++;
						}
					}
					else
					{
						while (this.string_0.Length - this.int_2 > 0 && (!Class399.smethod_4(c = this.string_0[this.int_2]) || (c == '{' && !this.method_26())))
						{
							this.int_2++;
						}
					}
					int num2 = this.int_2;
					this.method_2(class398_0);
					if (!class398_0.Boolean_0)
					{
						break;
					}
					if (this.string_0.Length - this.int_2 == 0)
					{
						c = '!';
					}
					else if (Class399.smethod_4(c = this.string_0[this.int_2]))
					{
						flag = Class399.smethod_6(c);
						this.int_2++;
					}
					else
					{
						c = ' ';
					}
					if (num < num2)
					{
						int num3 = num2 - num - (flag ? 1 : 0);
						flag2 = false;
						if (num3 > 0)
						{
							this.method_27(num, num3, bool_1: false);
						}
						if (flag)
						{
							this.method_31(this.string_0[num2 - 1]);
						}
					}
					switch (c)
					{
					case '$':
						this.class402_4 = new Class402(((this.enum48_0 & Enum48.const_2) != 0) ? 15 : 20, this.enum48_0);
						goto IL_041e;
					case '(':
						break;
					case ')':
						if (this.class402_0 != null)
						{
							this.method_33(class398_0);
							if (!class398_0.Boolean_0)
							{
								goto end_IL_067a;
							}
							this.method_28(class398_0);
							if (!class398_0.Boolean_0)
							{
								goto end_IL_067a;
							}
							this.enum48_0 = this.list_1[this.list_1.Count - 1];
							this.list_1.RemoveAt(this.list_1.Count - 1);
							if (this.class402_4 == null)
							{
								continue;
							}
							goto IL_041e;
						}
						class398_0.Boolean_0 = false;
						class398_0.String_0 = "SR.GetString(SR.TooManyParens)";
						goto end_IL_067a;
					case '.':
						if ((this.enum48_0 & Enum48.const_5) != 0)
						{
							this.class402_4 = new Class402(11, this.enum48_0, "\0\u0001\0\0");
						}
						else
						{
							this.method_32('\n');
						}
						goto IL_041e;
					case '*':
					case '+':
					case '?':
					case '{':
						if (this.class402_4 != null)
						{
							this.int_2--;
							goto IL_041e;
						}
						class398_0.Boolean_0 = false;
						class398_0.String_0 = (flag2 ? "SR.GetString(SR.NestedQuantify, ch.ToString())" : "SR.GetString(SR.QuantifyAfterNothing)");
						goto end_IL_067a;
					case '|':
						this.method_30();
						continue;
					case '[':
					{
						Class395 class2 = this.method_15((this.enum48_0 & Enum48.const_1) != 0, bool_2: false, class398_0);
						if (!class398_0.Boolean_0)
						{
							goto end_IL_067a;
						}
						this.class402_4 = new Class402(11, this.enum48_0, class2.method_7());
						goto IL_041e;
					}
					case '\\':
					{
						Class402 @class = this.method_12(class398_0);
						if (!class398_0.Boolean_0)
						{
							goto end_IL_067a;
						}
						this.class402_4 = @class;
						goto IL_041e;
					}
					case '^':
						this.class402_4 = new Class402(((this.enum48_0 & Enum48.const_2) != 0) ? 14 : 18, this.enum48_0);
						goto IL_041e;
					case ' ':
						continue;
					case '!':
						goto IL_0692;
					default:
						{
							class398_0.Boolean_0 = false;
							class398_0.String_0 = "SR.GetString(SR.InternalError)";
							goto end_IL_067a;
						}
						IL_041e:
						this.method_2(class398_0);
						if (!class398_0.Boolean_0)
						{
							goto end_IL_067a;
						}
						goto IL_0430;
					}
					this.list_1.Add(this.enum48_0);
					Class402 class402_;
					if ((class402_ = this.method_23(class398_0)) == null)
					{
						if (!class398_0.Boolean_0)
						{
							break;
						}
						this.list_1.RemoveAt(this.list_1.Count - 1);
					}
					else
					{
						this.class402_1.class402_0 = this.class402_0;
						this.class402_2.class402_0 = this.class402_1;
						this.class402_3.class402_0 = this.class402_2;
						this.class402_0 = this.class402_3;
						this.method_29(class402_);
					}
					continue;
				}
				goto IL_0692;
				IL_0692:
				if (this.class402_0 != null)
				{
					class398_0.Boolean_0 = false;
					class398_0.String_0 = "SR.GetString(SR.NotEnoughParens)";
				}
				else
				{
					this.method_33(class398_0);
				}
				break;
				IL_0430:
				if (this.string_0.Length - this.int_2 != 0 && (flag = this.method_26()))
				{
					c = this.string_0[this.int_2++];
					while (this.class402_4 != null)
					{
						int num;
						int num5;
						int num4;
						switch (c)
						{
						case '{':
							num = this.int_2;
							num5 = (num4 = this.method_4(class398_0));
							if (!class398_0.Boolean_0)
							{
								break;
							}
							if (num < this.int_2 && this.string_0.Length - this.int_2 > 0 && this.string_0[this.int_2] == ',')
							{
								this.int_2++;
								if (this.string_0.Length - this.int_2 != 0 && this.string_0[this.int_2] != '}')
								{
									num5 = this.method_4(class398_0);
									if (!class398_0.Boolean_0)
									{
										break;
									}
								}
								else
								{
									num5 = int.MaxValue;
								}
							}
							if (num != this.int_2 && this.string_0.Length - this.int_2 != 0 && this.string_0[this.int_2++] == '}')
							{
								goto IL_05b3;
							}
							goto IL_063f;
						case '?':
							num4 = 0;
							num5 = 1;
							goto IL_05b3;
						case '*':
							num4 = 0;
							num5 = int.MaxValue;
							goto IL_05b3;
						case '+':
							num4 = 1;
							num5 = int.MaxValue;
							goto IL_05b3;
						default:
							{
								class398_0.Boolean_0 = false;
								class398_0.String_0 = "SR.GetString(SR.InternalError)";
								break;
							}
							IL_05b3:
							this.method_2(class398_0);
							if (!class398_0.Boolean_0)
							{
								break;
							}
							goto IL_05c5;
						}
						goto end_IL_067a;
						IL_063f:
						this.class402_3.method_2(this.class402_4);
						this.class402_4 = null;
						this.int_2 = num - 1;
						break;
						IL_05c5:
						bool flag3;
						if (this.string_0.Length - this.int_2 != 0 && this.string_0[this.int_2] == '?')
						{
							this.int_2++;
							flag3 = true;
						}
						else
						{
							flag3 = false;
						}
						if (num4 <= num5)
						{
							this.class402_3.method_2(this.class402_4.method_1(flag3, num4, num5));
							this.class402_4 = null;
							continue;
						}
						class398_0.Boolean_0 = false;
						class398_0.String_0 = "SR.GetString(SR.IllegalRange)";
						goto end_IL_067a;
					}
				}
				else
				{
					this.class402_3.method_2(this.class402_4);
					this.class402_4 = null;
				}
				continue;
				end_IL_067a:
				break;
			}
			return this.class402_4;
		}

		private Class402 method_12(Class398 class398_0)
		{
			if (this.string_0.Length - this.int_2 == 0)
			{
				class398_0.Boolean_0 = false;
				class398_0.String_0 = "SR.GetString(SR.IllegalEndEscape)";
			}
			else
			{
				char c;
				switch (c = this.string_0[this.int_2])
				{
				case 'D':
					this.int_2++;
					if ((this.enum48_0 & Enum48.const_8) != 0)
					{
						return new Class402(11, this.enum48_0, "\u0001\u0002\00:");
					}
					return new Class402(11, this.enum48_0, Class395.string_24);
				case 'W':
					this.int_2++;
					if ((this.enum48_0 & Enum48.const_8) != 0)
					{
						return new Class402(11, this.enum48_0, "\u0001\n\00:A[_`a{İı");
					}
					return new Class402(11, this.enum48_0, Class395.string_22);
				case 'S':
					this.int_2++;
					if ((this.enum48_0 & Enum48.const_8) != 0)
					{
						return new Class402(11, this.enum48_0, "\u0001\u0004\0\t\u000e !");
					}
					return new Class402(11, this.enum48_0, Class395.string_20);
				case 'P':
				case 'p':
					break;
				case 'd':
					this.int_2++;
					if ((this.enum48_0 & Enum48.const_8) != 0)
					{
						return new Class402(11, this.enum48_0, "\0\u0002\00:");
					}
					return new Class402(11, this.enum48_0, Class395.string_23);
				case 'A':
				case 'B':
				case 'G':
				case 'Z':
				case 'b':
				case 'z':
					this.int_2++;
					return new Class402(this.method_14(c), this.enum48_0);
				default:
					return this.method_13(class398_0);
				case 'w':
					this.int_2++;
					if ((this.enum48_0 & Enum48.const_8) != 0)
					{
						return new Class402(11, this.enum48_0, "\0\n\00:A[_`a{İı");
					}
					return new Class402(11, this.enum48_0, Class395.string_21);
				case 's':
					this.int_2++;
					if ((this.enum48_0 & Enum48.const_8) != 0)
					{
						return new Class402(11, this.enum48_0, "\0\u0004\0\t\u000e !");
					}
					return new Class402(11, this.enum48_0, Class395.string_19);
				}
				this.int_2++;
				string string_ = this.method_38(class398_0);
				if (class398_0.Boolean_0)
				{
					Class395 @class = new Class395();
					@class.method_2(string_, c != 'p', (this.enum48_0 & Enum48.const_1) != 0, this.string_0, class398_0);
					if (class398_0.Boolean_0)
					{
						if ((this.enum48_0 & Enum48.const_1) != 0)
						{
							@class.method_3(this.cultureInfo_0);
						}
						return new Class402(11, this.enum48_0, @class.method_7());
					}
				}
			}
			return null;
		}

		private Class402 method_13(Class398 class398_0)
		{
			int num;
			char c2;
			if (this.string_0.Length - this.int_2 == 0)
			{
				class398_0.Boolean_0 = false;
				class398_0.String_0 = "SR.GetString(SR.IllegalEndEscape)";
			}
			else
			{
				bool flag = false;
				char c = '\0';
				num = this.int_2;
				c2 = this.string_0[this.int_2];
				if (c2 == 'k')
				{
					if (this.string_0.Length - this.int_2 >= 2)
					{
						this.int_2++;
						c2 = this.string_0[this.int_2++];
						if (c2 == '<' || c2 == '\'')
						{
							flag = true;
							c = ((c2 == '\'') ? '\'' : '>');
						}
					}
					if (!flag || this.string_0.Length - this.int_2 <= 0)
					{
						class398_0.Boolean_0 = false;
						class398_0.String_0 = "SR.GetString(SR.MalformedNameRef)";
						goto IL_03e3;
					}
					c2 = this.string_0[this.int_2];
				}
				else if ((c2 == '<' || c2 == '\'') && this.string_0.Length - this.int_2 > 1)
				{
					flag = true;
					c = ((c2 == '\'') ? '\'' : '>');
					this.int_2++;
					c2 = this.string_0[this.int_2];
				}
				if (!flag || c2 < '0' || c2 > '9')
				{
					if (!flag && c2 >= '1' && c2 <= '9')
					{
						if ((this.enum48_0 & Enum48.const_8) == 0)
						{
							int num2 = this.method_4(class398_0);
							if (class398_0.Boolean_0)
							{
								if (this.hashtable_0.ContainsKey(num2))
								{
									return new Class402(13, this.enum48_0, num2);
								}
								if (num2 > 9)
								{
									goto IL_03a6;
								}
								class398_0.Boolean_0 = false;
								class398_0.String_0 = "SR.GetString(SR.UndefinedBackref, capnum.ToString(CultureInfo.CurrentCulture))";
							}
							goto IL_03e3;
						}
						int num3 = -1;
						int num4 = c2 - 48;
						int num5 = this.int_2 - 1;
						while (num4 <= this.int_5)
						{
							if (this.hashtable_0.ContainsKey(num4) && (this.hashtable_0 == null || (int)this.hashtable_0[num4] < num5))
							{
								num3 = num4;
							}
							this.int_2++;
							if (this.string_0.Length - this.int_2 == 0 || (c2 = this.string_0[this.int_2]) < '0' || c2 > '9')
							{
								break;
							}
							num4 = num4 * 10 + (c2 - 48);
						}
						if (num3 >= 0)
						{
							return new Class402(13, this.enum48_0, num3);
						}
					}
					else if (flag && Class395.smethod_6(c2))
					{
						string text = this.method_3();
						if (this.string_0.Length - this.int_2 > 0 && this.string_0[this.int_2++] == c)
						{
							if (this.method_39(text))
							{
								return new Class402(13, this.enum48_0, (int)this.hashtable_1[text]);
							}
							class398_0.Boolean_0 = false;
							class398_0.String_0 = "SR.GetString(SR.UndefinedNameRef, capname)";
							goto IL_03e3;
						}
					}
					goto IL_03a6;
				}
				int num6 = this.method_4(class398_0);
				if (class398_0.Boolean_0)
				{
					if (this.string_0.Length - this.int_2 <= 0 || this.string_0[this.int_2++] != c)
					{
						goto IL_03a6;
					}
					if (this.hashtable_0.ContainsKey(num6))
					{
						return new Class402(13, this.enum48_0, num6);
					}
					class398_0.Boolean_0 = false;
					class398_0.String_0 = "SR.GetString(SR.UndefinedBackref, capnum.ToString(CultureInfo.CurrentCulture))";
				}
			}
			goto IL_03e3;
			IL_03a6:
			this.int_2 = num;
			c2 = this.method_34(class398_0);
			if (class398_0.Boolean_0)
			{
				if ((this.enum48_0 & Enum48.const_1) != 0)
				{
					c2 = char.ToLower(c2, this.cultureInfo_0);
				}
				return new Class402(9, this.enum48_0, c2);
			}
			goto IL_03e3;
			IL_03e3:
			return null;
		}

		private int method_14(char char_0)
		{
			switch (char_0)
			{
			case 'G':
				return 19;
			case 'A':
				return 18;
			case 'B':
				if ((this.enum48_0 & Enum48.const_8) == 0)
				{
					return 17;
				}
				return 42;
			default:
				return 22;
			case 'z':
				return 21;
			case 'b':
				if ((this.enum48_0 & Enum48.const_8) == 0)
				{
					return 16;
				}
				return 41;
			case 'Z':
				return 20;
			}
		}

		private Class395 method_15(bool bool_1, bool bool_2, Class398 class398_0)
		{
			Class400 @class = new Class400(bool_1, bool_2);
			@class.class395_0 = (@class.bool_0 ? null : new Class395());
			if (this.string_0.Length - this.int_2 > 0 && this.string_0[this.int_2] == '^')
			{
				this.int_2++;
				if (!@class.bool_0)
				{
					@class.class395_0.bool_1 = true;
				}
			}
			while (true)
			{
				bool flag;
				if (this.string_0.Length - this.int_2 > 0)
				{
					flag = false;
					@class.char_0 = this.string_0[this.int_2++];
					if (@class.char_0 == ']')
					{
						if (!@class.bool_3)
						{
							@class.bool_4 = true;
							goto IL_032c;
						}
					}
					else
					{
						if (@class.char_0 == '\\' && this.string_0.Length - this.int_2 > 0)
						{
							char c = (@class.char_0 = this.string_0[this.int_2++]);
							if (c <= 'S')
							{
								if (c <= 'D')
								{
									if (c == '-')
									{
										if (!@class.bool_0)
										{
											@class.class395_0.method_1(@class.char_0, @class.char_0);
										}
										goto IL_0304;
									}
									if (c == 'D')
									{
										goto IL_016a;
									}
								}
								else
								{
									if (c == 'P')
									{
										goto IL_01e3;
									}
									if (c == 'S')
									{
										goto IL_01cb;
									}
								}
								goto IL_0194;
							}
							if (c <= 'd')
							{
								if (c != 'W')
								{
									if (c == 'd')
									{
										goto IL_016a;
									}
									goto IL_0194;
								}
							}
							else
							{
								if (c == 'p')
								{
									goto IL_01e3;
								}
								if (c == 's')
								{
									goto IL_01cb;
								}
								if (c != 'w')
								{
									goto IL_0194;
								}
							}
							this.method_18(@class, class398_0);
							if (!class398_0.Boolean_0)
							{
								break;
							}
							goto IL_0304;
						}
						if (@class.char_0 == '[')
						{
							this.method_20(@class);
						}
					}
					goto IL_020c;
				}
				goto IL_032c;
				IL_0304:
				@class.bool_3 = false;
				continue;
				IL_016a:
				this.method_16(@class, class398_0);
				if (!class398_0.Boolean_0)
				{
					break;
				}
				goto IL_0304;
				IL_0194:
				this.int_2--;
				@class.char_0 = this.method_34(class398_0);
				flag = true;
				goto IL_020c;
				IL_032c:
				if (!@class.bool_4)
				{
					class398_0.Boolean_0 = false;
					class398_0.String_0 = "SR.GetString(SR.UnterminatedBracket)";
				}
				else if (!@class.bool_0 && @class.bool_1)
				{
					@class.class395_0.method_3(this.cultureInfo_0);
				}
				break;
				IL_01cb:
				this.method_17(@class, class398_0);
				if (!class398_0.Boolean_0)
				{
					break;
				}
				goto IL_0304;
				IL_01e3:
				this.method_19(@class, class398_0);
				if (!class398_0.Boolean_0)
				{
					break;
				}
				goto IL_0304;
				IL_020c:
				if (@class.bool_2)
				{
					this.method_21(@class, flag, class398_0);
					if (!class398_0.Boolean_0)
					{
						break;
					}
				}
				else if (this.string_0.Length - this.int_2 >= 2 && this.string_0[this.int_2] == '-' && this.string_0[this.int_2 + 1] != ']')
				{
					@class.char_1 = @class.char_0;
					@class.bool_2 = true;
					this.int_2++;
				}
				else if (this.string_0.Length - this.int_2 >= 1 && @class.char_0 == '-' && !flag && this.string_0[this.int_2] == '[' && !@class.bool_3)
				{
					this.method_22(@class, class398_0);
					if (!class398_0.Boolean_0)
					{
						break;
					}
				}
				else if (!@class.bool_0)
				{
					@class.class395_0.method_1(@class.char_0, @class.char_0);
				}
				goto IL_0304;
			}
			return @class.class395_0;
		}

		private void method_16(Class400 class400_0, Class398 class398_0)
		{
			if (!class400_0.bool_0)
			{
				if (class400_0.bool_2)
				{
					class398_0.Boolean_0 = false;
					class398_0.String_0 = "SR.GetString(SR.BadClassInCharRange, ch.ToString())";
				}
				else
				{
					class400_0.class395_0.method_6((this.enum48_0 & Enum48.const_8) != 0, class400_0.char_0 == 'D', this.string_0, class398_0);
				}
			}
		}

		private void method_17(Class400 class400_0, Class398 class398_0)
		{
			if (!class400_0.bool_0)
			{
				if (class400_0.bool_2)
				{
					class398_0.Boolean_0 = false;
					class398_0.String_0 = "SR.GetString(SR.BadClassInCharRange, ch.ToString())";
				}
				else
				{
					class400_0.class395_0.method_5((this.enum48_0 & Enum48.const_8) != 0, class400_0.char_0 == 'S');
				}
			}
		}

		private void method_18(Class400 class400_0, Class398 class398_0)
		{
			if (!class400_0.bool_0)
			{
				if (class400_0.bool_2)
				{
					class398_0.Boolean_0 = false;
					class398_0.String_0 = "SR.GetString(SR.BadClassInCharRange, ch.ToString())";
				}
				else
				{
					class400_0.class395_0.method_4((this.enum48_0 & Enum48.const_8) != 0, class400_0.char_0 == 'W');
				}
			}
		}

		private void method_19(Class400 class400_0, Class398 class398_0)
		{
			if (!class400_0.bool_0)
			{
				if (class400_0.bool_2)
				{
					class398_0.Boolean_0 = false;
					class398_0.String_0 = "SR.GetString(SR.BadClassInCharRange, ch.ToString())";
					return;
				}
				string string_ = this.method_38(class398_0);
				if (class398_0.Boolean_0)
				{
					class400_0.class395_0.method_2(string_, class400_0.char_0 != 'p', class400_0.bool_1, this.string_0, class398_0);
				}
			}
			else
			{
				this.method_38(class398_0);
				_ = class398_0.Boolean_0;
			}
		}

		private void method_20(Class400 class400_0)
		{
			if (this.string_0.Length - this.int_2 > 0 && this.string_0[this.int_2] == ':' && !class400_0.bool_2)
			{
				int num = this.int_2;
				this.int_2++;
				this.method_3();
				if (this.string_0.Length - this.int_2 < 2 || this.string_0[this.int_2++] != ':' || this.string_0[this.int_2++] != ']')
				{
					this.int_2 = num;
				}
			}
		}

		private void method_21(Class400 class400_0, bool bool_1, Class398 class398_0)
		{
			class400_0.bool_2 = false;
			if (class400_0.bool_0)
			{
				return;
			}
			if (class400_0.char_0 == '[' && !bool_1 && !class400_0.bool_3)
			{
				class400_0.class395_0.method_1(class400_0.char_1, class400_0.char_1);
				Class395 class395_ = this.method_15(class400_0.bool_1, bool_2: false, class398_0);
				if (class398_0.Boolean_0)
				{
					class400_0.class395_0.class395_0 = class395_;
					if (this.string_0.Length - this.int_2 > 0 && this.string_0[this.int_2] != ']')
					{
						class398_0.Boolean_0 = false;
						class398_0.String_0 = "SR.GetString(SR.SubtractionMustBeLast)";
					}
				}
			}
			else if (class400_0.char_1 > class400_0.char_0)
			{
				class398_0.Boolean_0 = false;
				class398_0.String_0 = "SR.GetString(SR.ReversedCharRange)";
			}
			else
			{
				class400_0.class395_0.method_1(class400_0.char_1, class400_0.char_0);
			}
		}

		private void method_22(Class400 class400_0, Class398 class398_0)
		{
			if (!class400_0.bool_0)
			{
				this.int_2++;
				Class395 class395_ = this.method_15(class400_0.bool_1, bool_2: false, class398_0);
				if (class398_0.Boolean_0)
				{
					class400_0.class395_0.class395_0 = class395_;
					if (this.string_0.Length - this.int_2 > 0 && this.string_0[this.int_2] != ']')
					{
						class398_0.Boolean_0 = false;
						class398_0.String_0 = "SR.GetString(SR.SubtractionMustBeLast)";
					}
				}
			}
			else
			{
				this.int_2++;
				this.method_15(class400_0.bool_1, bool_2: true, class398_0);
				_ = class398_0.Boolean_0;
			}
		}

		private Class402 method_23(Class398 class398_0)
		{
			Class401 @class = new Class401();
			Class402 class2 = null;
			if (this.string_0.Length - this.int_2 != 0 && this.string_0[this.int_2] == '?' && (this.string_0[this.int_2] != '?' || this.string_0.Length - this.int_2 <= 1 || this.string_0[this.int_2 + 1] != ')'))
			{
				this.int_2++;
				if (this.string_0.Length - this.int_2 == 0)
				{
					goto IL_02a4;
				}
				switch (@class.char_0 = this.string_0[this.int_2++])
				{
				case ':':
					@class.int_0 = 29;
					goto IL_0292;
				default:
					this.int_2--;
					@class.int_0 = 29;
					this.method_6();
					if (this.string_0.Length - this.int_2 != 0)
					{
						if ((@class.char_0 = this.string_0[this.int_2++]) == ')')
						{
							return null;
						}
						if (@class.char_0 == ':')
						{
							goto IL_0292;
						}
					}
					goto IL_02a4;
				case '=':
					this.enum48_0 &= (Enum48)(-65);
					@class.int_0 = 30;
					goto IL_0292;
				case '>':
					@class.int_0 = 32;
					goto IL_0292;
				case '\'':
					@class.char_1 = '\'';
					goto case '<';
				case '<':
					if (this.string_0.Length - this.int_2 != 0)
					{
						char c = (@class.char_0 = this.string_0[this.int_2++]);
						if (c != '!')
						{
							if (c == '=')
							{
								if (@class.char_1 != '\'')
								{
									this.enum48_0 |= Enum48.const_7;
									@class.int_0 = 30;
									goto IL_0292;
								}
							}
							else
							{
								class2 = this.method_24(@class, class398_0);
								if (!class398_0.Boolean_0)
								{
									break;
								}
								if (class2 != null)
								{
									return class2;
								}
							}
						}
						else if (@class.char_1 != '\'')
						{
							this.enum48_0 |= Enum48.const_7;
							@class.int_0 = 31;
							goto IL_0292;
						}
					}
					goto IL_02a4;
				case '(':
					class2 = this.method_25(@class, class398_0);
					if (!class398_0.Boolean_0)
					{
						break;
					}
					if (class2 != null)
					{
						return class2;
					}
					goto IL_0292;
				case '!':
					{
						this.enum48_0 &= (Enum48)(-65);
						@class.int_0 = 31;
						goto IL_0292;
					}
					IL_0292:
					return new Class402(@class.int_0, this.enum48_0);
				}
				goto IL_02b6;
			}
			if ((this.enum48_0 & Enum48.const_3) == 0 && !this.bool_0)
			{
				return new Class402(28, this.enum48_0, this.int_3++, -1);
			}
			this.bool_0 = false;
			return new Class402(29, this.enum48_0);
			IL_02b6:
			return null;
			IL_02a4:
			class398_0.Boolean_0 = false;
			class398_0.String_0 = "SR.GetString(SR.UnrecognizedGrouping)";
			goto IL_02b6;
		}

		private Class402 method_24(Class401 class401_0, Class398 class398_0)
		{
			this.int_2--;
			int num = -1;
			int num2 = -1;
			bool flag = false;
			if (class401_0.char_0 >= '0' && class401_0.char_0 <= '9')
			{
				num = this.method_4(class398_0);
				if (!class398_0.Boolean_0)
				{
					return null;
				}
				if (!this.hashtable_0.ContainsKey(num))
				{
					num = -1;
				}
				if (this.string_0.Length - this.int_2 > 0 && this.string_0[this.int_2] != class401_0.char_1 && this.string_0[this.int_2] != '-')
				{
					class398_0.Boolean_0 = false;
					class398_0.String_0 = "SR.GetString(SR.InvalidGroupName)";
					return null;
				}
				if (num == 0)
				{
					class398_0.Boolean_0 = false;
					class398_0.String_0 = "SR.GetString(SR.CapnumNotZero)";
					return null;
				}
			}
			else if (Class395.smethod_6(class401_0.char_0))
			{
				string text = this.method_3();
				if (this.method_39(text))
				{
					num = (int)this.hashtable_1[text];
				}
				if (this.string_0.Length - this.int_2 > 0 && this.string_0[this.int_2] != class401_0.char_1 && this.string_0[this.int_2] != '-')
				{
					class398_0.Boolean_0 = false;
					class398_0.String_0 = "SR.GetString(SR.InvalidGroupName)";
					return null;
				}
			}
			else
			{
				if (class401_0.char_0 != '-')
				{
					class398_0.Boolean_0 = false;
					class398_0.String_0 = "SR.GetString(SR.InvalidGroupName)";
					return null;
				}
				flag = true;
			}
			if ((num != -1 || flag) && this.string_0.Length - this.int_2 > 0 && this.string_0[this.int_2] == '-')
			{
				this.int_2++;
				class401_0.char_0 = this.string_0[this.int_2];
				if (class401_0.char_0 >= '0' && class401_0.char_0 <= '9')
				{
					num2 = this.method_4(class398_0);
					if (!class398_0.Boolean_0)
					{
						return null;
					}
					if (!this.hashtable_0.ContainsKey(num2))
					{
						class398_0.Boolean_0 = false;
						class398_0.String_0 = "SR.GetString(SR.UndefinedBackref, uncapnum)";
						return null;
					}
					if (this.string_0.Length - this.int_2 > 0 && this.string_0[this.int_2] != class401_0.char_1)
					{
						class398_0.Boolean_0 = false;
						class398_0.String_0 = "SR.GetString(SR.InvalidGroupName)";
						return null;
					}
				}
				else
				{
					if (!Class395.smethod_6(class401_0.char_0))
					{
						class398_0.Boolean_0 = false;
						class398_0.String_0 = "SR.GetString(SR.InvalidGroupName)";
						return null;
					}
					string text2 = this.method_3();
					if (!this.method_39(text2))
					{
						class398_0.Boolean_0 = false;
						class398_0.String_0 = "SR.GetString(SR.UndefinedNameRef, uncapname)";
						return null;
					}
					num2 = (int)this.hashtable_1[text2];
					if (this.string_0.Length - this.int_2 > 0 && this.string_0[this.int_2] != class401_0.char_1)
					{
						class398_0.Boolean_0 = false;
						class398_0.String_0 = "SR.GetString(SR.InvalidGroupName)";
						return null;
					}
				}
			}
			if ((num != -1 || num2 != -1) && this.string_0.Length - this.int_2 > 0 && this.string_0[this.int_2++] == class401_0.char_1)
			{
				return new Class402(28, this.enum48_0, num, num2);
			}
			return null;
		}

		private Class402 method_25(Class401 class401_0, Class398 class398_0)
		{
			int num = this.int_2;
			if (this.string_0.Length - this.int_2 > 0)
			{
				class401_0.char_0 = this.string_0[this.int_2];
				if (class401_0.char_0 >= '0' && class401_0.char_0 <= '9')
				{
					int num2 = this.method_4(class398_0);
					if (!class398_0.Boolean_0)
					{
						return null;
					}
					if (this.string_0.Length - this.int_2 > 0 && this.string_0[this.int_2++] == ')')
					{
						if (this.hashtable_0.ContainsKey(num2))
						{
							return new Class402(33, this.enum48_0, num2);
						}
						class398_0.Boolean_0 = false;
						class398_0.String_0 = "SR.GetString(SR.UndefinedReference, capnum.ToString(CultureInfo.CurrentCulture))";
						return null;
					}
					class398_0.Boolean_0 = false;
					class398_0.String_0 = "SR.GetString(SR.MalformedReference, capnum.ToString(CultureInfo.CurrentCulture))";
					return null;
				}
				if (Class395.smethod_6(class401_0.char_0))
				{
					string text = this.method_3();
					if (this.method_39(text) && this.string_0.Length - this.int_2 > 0 && this.string_0[this.int_2++] == ')')
					{
						return new Class402(33, this.enum48_0, (int)this.hashtable_1[text]);
					}
				}
			}
			class401_0.int_0 = 34;
			this.int_2 = num - 1;
			this.bool_0 = true;
			int num3 = this.string_0.Length - this.int_2;
			if (num3 >= 3 && this.string_0[this.int_2 + 1] == '?')
			{
				char c = this.string_0[this.int_2 + 2];
				switch (c)
				{
				case '#':
					class398_0.Boolean_0 = false;
					class398_0.String_0 = "SR.GetString(SR.AlternationCantHaveComment)";
					return null;
				case '\'':
					class398_0.Boolean_0 = false;
					class398_0.String_0 = "SR.GetString(SR.AlternationCantCapture)";
					return null;
				}
				if (num3 >= 4 && c == '<' && this.string_0[this.int_2 + 3] != '!' && this.string_0[this.int_2 + 3] != '=')
				{
					class398_0.Boolean_0 = false;
					class398_0.String_0 = "SR.GetString(SR.AlternationCantCapture)";
					return null;
				}
			}
			return null;
		}

		private static bool smethod_4(char char_0)
		{
			if (char_0 <= '|')
			{
				return Class399.byte_0[(uint)char_0] >= 4;
			}
			return false;
		}

		private static bool smethod_5(char char_0)
		{
			if (char_0 <= '|')
			{
				return Class399.byte_0[(uint)char_0] >= 2;
			}
			return false;
		}

		private static bool smethod_6(char char_0)
		{
			if (char_0 <= '{')
			{
				return Class399.byte_0[(uint)char_0] >= 5;
			}
			return false;
		}

		private bool method_26()
		{
			int num = this.string_0.Length - this.int_2;
			if (num == 0)
			{
				return false;
			}
			int num2 = this.int_2;
			char c = this.string_0[num2];
			if (c != '{')
			{
				if (c <= '{')
				{
					return Class399.byte_0[(uint)c] >= 5;
				}
				return false;
			}
			int num3 = num2;
			while (--num > 0 && (c = this.string_0[++num3]) >= '0' && c <= '9')
			{
			}
			if (num != 0 && num3 - num2 != 1)
			{
				switch (c)
				{
				case '}':
					return true;
				default:
					return false;
				case ',':
					break;
				}
				while (--num > 0 && (c = this.string_0[++num3]) >= '0' && c <= '9')
				{
				}
				if (num > 0)
				{
					return c == '}';
				}
				return false;
			}
			return false;
		}

		private void method_27(int int_7, int int_8, bool bool_1)
		{
			if (int_8 == 0)
			{
				return;
			}
			Class402 @class;
			if (int_8 > 1)
			{
				string text = this.string_0.Substring(int_7, int_8);
				if ((this.enum48_0 & Enum48.const_1) != 0 && !bool_1)
				{
					StringBuilder stringBuilder = new StringBuilder(text.Length);
					for (int i = 0; i < text.Length; i++)
					{
						stringBuilder.Append(char.ToLower(text[i], this.cultureInfo_0));
					}
					text = stringBuilder.ToString();
				}
				@class = new Class402(12, this.enum48_0, text);
			}
			else
			{
				char c = this.string_0[int_7];
				if ((this.enum48_0 & Enum48.const_1) != 0 && !bool_1)
				{
					c = char.ToLower(c, this.cultureInfo_0);
				}
				@class = new Class402(9, this.enum48_0, c);
			}
			this.class402_3.method_2(@class);
		}

		private void method_28(Class398 class398_0)
		{
			this.class402_3 = this.class402_0;
			this.class402_2 = this.class402_3.class402_0;
			this.class402_1 = this.class402_2.class402_0;
			this.class402_0 = this.class402_1.class402_0;
			if (this.class402_1.method_4() == 34 && this.class402_1.method_3() == 0)
			{
				if (this.class402_4 == null)
				{
					class398_0.Boolean_0 = false;
					class398_0.String_0 = "SR.GetString(SR.IllegalCondition)";
				}
				else
				{
					this.class402_1.method_2(this.class402_4);
					this.class402_4 = null;
				}
			}
		}

		private void method_29(Class402 class402_5)
		{
			this.class402_1 = class402_5;
			this.class402_2 = new Class402(24, this.enum48_0);
			this.class402_3 = new Class402(25, this.enum48_0);
		}

		private void method_30()
		{
			if (this.class402_1.method_4() != 34 && this.class402_1.method_4() != 33)
			{
				this.class402_2.method_2(this.class402_3.method_0());
			}
			else
			{
				this.class402_1.method_2(this.class402_3.method_0());
			}
			this.class402_3 = new Class402(25, this.enum48_0);
		}

		private void method_31(char char_0)
		{
			if ((this.enum48_0 & Enum48.const_1) != 0)
			{
				char_0 = char.ToLower(char_0, this.cultureInfo_0);
			}
			this.class402_4 = new Class402(9, this.enum48_0, char_0);
		}

		private void method_32(char char_0)
		{
			if ((this.enum48_0 & Enum48.const_1) != 0)
			{
				char_0 = char.ToLower(char_0, this.cultureInfo_0);
			}
			this.class402_4 = new Class402(10, this.enum48_0, char_0);
		}

		private void method_33(Class398 class398_0)
		{
			if (this.class402_1.method_4() != 34 && this.class402_1.method_4() != 33)
			{
				this.class402_2.method_2(this.class402_3.method_0());
				this.class402_1.method_2(this.class402_2);
			}
			else
			{
				this.class402_1.method_2(this.class402_3.method_0());
				if ((this.class402_1.method_4() == 33 && this.class402_1.method_3() > 2) || this.class402_1.method_3() > 3)
				{
					class398_0.Boolean_0 = false;
					class398_0.String_0 = "SR.GetString(SR.TooManyAlternates)";
					return;
				}
			}
			this.class402_4 = this.class402_1;
		}

		private char method_34(Class398 class398_0)
		{
			char c = this.string_0[this.int_2++];
			if (c >= '0' && c <= '7')
			{
				this.int_2--;
				return this.method_35();
			}
			switch (c)
			{
			case 'n':
				return '\n';
			case 'r':
				return '\r';
			case 't':
				return '\t';
			case 'u':
				return this.method_36(4, class398_0);
			case 'v':
				return '\v';
			case 'x':
				return this.method_36(2, class398_0);
			case 'a':
				return '\a';
			case 'b':
				return '\b';
			case 'c':
				return this.method_37(class398_0);
			default:
				if ((this.enum48_0 & Enum48.const_8) == 0 && Class395.smethod_6(c))
				{
					class398_0.Boolean_0 = false;
					class398_0.String_0 = "SR.GetString(SR.UnrecognizedEscape, ch.ToString())";
				}
				return c;
			case 'e':
				return '\u001b';
			case 'f':
				return '\f';
			}
		}

		private char method_35()
		{
			int num = 3;
			if (3 > this.string_0.Length - this.int_2)
			{
				num = this.string_0.Length - this.int_2;
			}
			int num2 = 0;
			int num3;
			while (num > 0 && (uint)(num3 = this.string_0[this.int_2] - 48) <= 7u)
			{
				this.int_2++;
				num2 *= 8;
				num2 += num3;
				if ((this.enum48_0 & Enum48.const_8) != 0 && num2 >= 32)
				{
					break;
				}
				num--;
			}
			num2 &= 0xFF;
			return (char)num2;
		}

		private char method_36(int int_7, Class398 class398_0)
		{
			int num = 0;
			if (this.string_0.Length - this.int_2 >= int_7)
			{
				int num2;
				while (int_7 > 0 && (num2 = Class399.smethod_7(this.string_0[this.int_2++])) >= 0)
				{
					num *= 16;
					num += num2;
					int_7--;
				}
			}
			if (int_7 > 0)
			{
				class398_0.Boolean_0 = false;
				class398_0.String_0 = "SR.GetString(SR.TooFewHex)";
			}
			return (char)num;
		}

		private static int smethod_7(char char_0)
		{
			int result;
			if ((uint)(result = char_0 - 48) <= 9u)
			{
				return result;
			}
			if ((uint)(result = char_0 - 97) <= 5u)
			{
				return result + 10;
			}
			if ((uint)(result = char_0 - 65) <= 5u)
			{
				return result + 10;
			}
			return -1;
		}

		private char method_37(Class398 class398_0)
		{
			char result = '#';
			if (this.string_0.Length - this.int_2 <= 0)
			{
				class398_0.Boolean_0 = false;
				class398_0.String_0 = "SR.GetString(SR.MissingControl)";
			}
			else
			{
				result = this.string_0[this.int_2++];
				if (result >= 'a' && result <= 'z')
				{
					result = (char)(result - 32);
				}
				if ((result = (char)(result - 64)) < ' ')
				{
					return result;
				}
				class398_0.Boolean_0 = false;
				class398_0.String_0 = "SR.GetString(SR.UnrecognizedControl)";
			}
			return result;
		}

		private string method_38(Class398 class398_0)
		{
			string result = null;
			if (this.string_0.Length - this.int_2 < 3)
			{
				class398_0.Boolean_0 = false;
				class398_0.String_0 = "SR.GetString(SR.IncompleteSlashP)";
			}
			else
			{
				char c = this.string_0[this.int_2++];
				if (c != '{')
				{
					class398_0.Boolean_0 = false;
					class398_0.String_0 = "SR.GetString(SR.MalformedSlashP)";
				}
				else
				{
					int num = this.int_2;
					while (this.string_0.Length - this.int_2 > 0)
					{
						c = this.string_0[this.int_2++];
						if (!Class395.smethod_6(c) && c != '-')
						{
							this.int_2--;
							break;
						}
					}
					result = this.string_0.Substring(num, this.int_2 - num);
					if (this.string_0.Length - this.int_2 == 0 || this.string_0[this.int_2++] != '}')
					{
						class398_0.Boolean_0 = false;
						class398_0.String_0 = "SR.GetString(SR.IncompleteSlashP)";
					}
				}
			}
			return result;
		}

		private bool method_39(string string_1)
		{
			if (this.hashtable_1 == null)
			{
				return false;
			}
			return this.hashtable_1.ContainsKey(string_1);
		}
	}
}
