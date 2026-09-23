using System;
using System.Globalization;

namespace ns19
{
	internal struct Struct35
	{
		internal enum Enum44
		{
			const_0,
			const_1,
			const_2,
			const_3
		}

		private float float_0;

		private Enum44 enum44_0;

		internal float Single_0 => this.float_0;

		internal Enum44 Enum44_0 => this.enum44_0;

		internal Struct35(string string_0)
		{
			string[] array = Class378.smethod_41(string_0);
			float.TryParse(array[0], NumberStyles.Float, CultureInfo.InvariantCulture, out this.float_0);
			this.enum44_0 = Enum44.const_3;
			if (array.Length == 2)
			{
				switch (array[1])
				{
				case "rad":
					this.enum44_0 = Enum44.const_2;
					break;
				case "grad":
					this.enum44_0 = Enum44.const_1;
					break;
				case "deg":
					this.enum44_0 = Enum44.const_0;
					break;
				default:
					throw new NotSupportedException(array[1]);
				}
			}
		}
	}
}
