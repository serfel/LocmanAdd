using System.Drawing;

namespace ns19
{
	internal struct Struct38
	{
		private string string_0;

		private string string_1;

		private string string_2;

		private int int_0;

		private string string_3;

		private float float_0;

		private string string_4;

		private string string_5;

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

		internal int Int32_0
		{
			get
			{
				return this.int_0;
			}
			set
			{
				this.int_0 = value;
			}
		}

		internal string String_3
		{
			get
			{
				return this.string_3;
			}
			set
			{
				this.string_3 = value;
			}
		}

		internal float Single_0
		{
			get
			{
				return this.float_0;
			}
			set
			{
				this.float_0 = value;
			}
		}

		internal string String_4
		{
			get
			{
				return this.string_4;
			}
			set
			{
				this.string_4 = value;
			}
		}

		internal string String_5
		{
			get
			{
				return this.string_5;
			}
			set
			{
				this.string_5 = value;
			}
		}

		internal Struct38(string string_6)
		{
			this.string_0 = string_6;
			this.string_1 = "normal";
			this.string_2 = "normal";
			this.int_0 = 400;
			this.string_3 = "normal";
			this.float_0 = 16f;
			this.string_4 = "none";
			this.string_5 = "";
		}

		internal Font method_0()
		{
			FontStyle fontStyle = Class378.smethod_30(this.string_1);
			if (this.int_0 >= 600)
			{
				fontStyle |= FontStyle.Bold;
			}
			return new Font(this.string_0, this.float_0, fontStyle);
		}
	}
}
