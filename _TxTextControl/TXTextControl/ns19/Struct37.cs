using System;
using System.Globalization;

namespace ns19
{
	internal struct Struct37
	{
		internal enum Enum45
		{
			const_0,
			const_1,
			const_2,
			const_3,
			const_4,
			const_5,
			const_6,
			const_7,
			const_8,
			const_9
		}

		private float float_0;

		private Enum45 enum45_0;

		internal float Single_0 => this.float_0;

		internal Enum45 Enum45_0 => this.enum45_0;

		internal Struct37(float float_1)
		{
			this.float_0 = float_1;
			this.enum45_0 = Enum45.const_2;
		}

		internal Struct37(float float_1, Enum45 enum45_1)
		{
			this.float_0 = float_1;
			this.enum45_0 = enum45_1;
		}

		internal Struct37(string string_0)
		{
			string[] array = Class378.smethod_41(string_0);
			float.TryParse(array[0], NumberStyles.Float, CultureInfo.InvariantCulture, out this.float_0);
			if (array.Length == 2)
			{
				switch (array[1].ToLower())
				{
				case "em":
					this.enum45_0 = Enum45.const_0;
					break;
				case "ex":
					this.enum45_0 = Enum45.const_1;
					break;
				case "%":
					this.enum45_0 = Enum45.const_8;
					break;
				case "cm":
					this.enum45_0 = Enum45.const_4;
					break;
				case "mm":
					this.enum45_0 = Enum45.const_5;
					break;
				case "in":
					this.enum45_0 = Enum45.const_3;
					break;
				case "px":
					this.enum45_0 = Enum45.const_2;
					break;
				case "pt":
					this.enum45_0 = Enum45.const_6;
					break;
				case "pc":
					this.enum45_0 = Enum45.const_7;
					break;
				default:
					throw new NotSupportedException(array[1]);
				}
			}
			else
			{
				this.enum45_0 = Enum45.const_2;
			}
		}
	}
}
