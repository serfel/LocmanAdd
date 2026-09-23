using System;
using System.Reflection;

namespace ns29
{
	internal class Class593 : IComparable<Class593>
	{
		internal int int_0;

		internal int int_1;

		internal bool bool_0;

		internal string string_0;

		internal Class593(int int_2, int int_3, string string_1)
		{
			this.int_0 = int_2;
			this.int_1 = int_3;
			this.string_0 = string_1;
		}

		[Obfuscation(Exclude = true)]
		public int CompareTo(Class593 other)
		{
			int num = this.int_0.CompareTo(other.int_0);
			if (num == 0)
			{
				return this.int_1.CompareTo(other.int_1);
			}
			return num;
		}
	}
}
