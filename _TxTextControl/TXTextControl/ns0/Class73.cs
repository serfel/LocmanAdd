using System.Collections.Generic;

namespace ns0
{
	internal class Class73
	{
		private int[] int_0;

		private int[] int_1;

		internal Class73()
		{
			this.int_1 = new int[256];
			this.int_0 = new int[256];
			Class76 @class = new Class76(256, 285);
			int[] array = @class.method_1();
			int[] array2 = @class.method_2();
			array[0] = 0;
			array[1] = 0;
			for (int i = 0; i < this.int_0.Length - 1; i++)
			{
				this.int_0[i + 1] = array[i + 1];
			}
			this.int_1 = array2;
		}

		private Class74[] method_0(Class74[] class74_0, Class74[] class74_1)
		{
			int num = class74_0.Length;
			Class74[] array = new Class74[num];
			for (int i = 0; i < class74_0.Length; i++)
			{
				array[i] = new Class74(class74_0[i].int_0, class74_0[i].int_1);
				if (i < class74_1.Length && class74_0[i].int_1 == class74_1[i].int_1)
				{
					array[i].int_0 = (class74_1[i].int_0 ^= class74_0[i].int_0);
				}
			}
			return array;
		}

		private Class74[] method_1(Class74[] class74_0, int int_2)
		{
			Class74[] array = new Class74[class74_0.Length];
			for (int i = 0; i < class74_0.Length; i++)
			{
				array[i] = new Class74((class74_0[i].int_0 + int_2) % 255, class74_0[i].int_1);
			}
			return array;
		}

		private Class74[] method_2(Class74[] class74_0)
		{
			Class74[] array = new Class74[class74_0.Length];
			for (int i = 0; i < class74_0.Length; i++)
			{
				array[i] = new Class74(this.int_1[class74_0[i].int_0], class74_0[i].int_1);
			}
			return array;
		}

		private Class74[] method_3(Class74[] class74_0, out int int_2)
		{
			List<Class74> list = new List<Class74>();
			int_2 = 1;
			bool flag = false;
			for (int i = 1; i < class74_0.Length; i++)
			{
				for (; class74_0[i].int_0 == 0; i++)
				{
					if (flag)
					{
						break;
					}
					int_2++;
				}
				flag = true;
				list.Add(class74_0[i]);
			}
			return list.ToArray();
		}

		private Class74[] method_4(Class74[] class74_0, int int_2)
		{
			for (int i = 0; i < class74_0.Length; i++)
			{
				class74_0[i].int_1 -= int_2;
			}
			return class74_0;
		}

		internal Class74[] method_5(Class74[] class74_0, Class74[] class74_1, out bool? nullable_0)
		{
			nullable_0 = null;
			Class74[] array = class74_0;
			int int_ = 1;
			for (int i = 0; i < class74_0.Length; i += int_)
			{
				int int_2 = this.int_0[array[0].int_0];
				Class74[] class74_2 = this.method_1(class74_1, int_2);
				Class74[] array2 = this.method_2(class74_2);
				Class74[] class74_3;
				Class74[] class74_4;
				if (array.Length > array2.Length)
				{
					class74_3 = array;
					class74_4 = array2;
				}
				else
				{
					class74_3 = array2;
					class74_4 = array;
				}
				Class74[] class74_5 = this.method_0(class74_3, class74_4);
				array = this.method_3(class74_5, out int_);
				if (int_ > 1 && i + int_ >= class74_0.Length)
				{
					nullable_0 = i + int_ == class74_0.Length;
				}
				class74_1 = this.method_4(class74_1, int_);
			}
			return array;
		}
	}
}
