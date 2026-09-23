using System.Drawing;

namespace ns19
{
	internal struct Struct40
	{
		private string string_0;

		private string string_1;

		private string string_2;

		internal string String_0
		{
			get
			{
				return this.string_0;
			}
			set
			{
				this.string_0 = value;
			}
		}

		internal string String_1
		{
			get
			{
				return this.string_1;
			}
			set
			{
				this.string_1 = value;
			}
		}

		internal string String_2
		{
			get
			{
				return this.string_2;
			}
			set
			{
				this.string_2 = value;
			}
		}

		internal Struct40(string string_3)
		{
			this.string_0 = string_3;
			this.string_1 = "nonzero";
			this.string_2 = "1";
		}

		internal Class381 method_0()
		{
			Color? color = Class378.smethod_23(this.string_0);
			if (color.HasValue)
			{
				if (this.string_2 != "1")
				{
					float num = Class378.smethod_24(this.string_2);
					Color color_ = Color.FromArgb((int)num, color.Value);
					return new Class382(color_);
				}
				return new Class382(color.Value);
			}
			return null;
		}
	}
}
