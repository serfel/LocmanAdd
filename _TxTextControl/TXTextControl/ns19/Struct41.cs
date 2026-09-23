using System.Drawing;
using System.Drawing.Drawing2D;

namespace ns19
{
	internal struct Struct41
	{
		private string string_0;

		private string string_1;

		private string string_2;

		private string string_3;

		private string string_4;

		private string string_5;

		private string string_6;

		private string string_7;

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

		internal string String_6
		{
			get
			{
				return this.string_6;
			}
			set
			{
				this.string_6 = value;
			}
		}

		internal string String_7
		{
			get
			{
				return this.string_7;
			}
			set
			{
				this.string_7 = value;
			}
		}

		internal Struct41(string string_8)
		{
			this.string_0 = string_8;
			this.string_1 = "1";
			this.string_2 = "butt";
			this.string_3 = "miter";
			this.string_4 = "4";
			this.string_5 = "none";
			this.string_6 = "0";
			this.string_7 = "1";
		}

		internal Pen method_0(SizeF sizeF_0, float float_0)
		{
			Color? color = Class378.smethod_23(this.string_0);
			if (color.HasValue)
			{
				Pen pen = new Pen(width: Class378.smethod_36(new Struct37(this.string_1), sizeF_0.Width, float_0), color: color.Value);
				pen.MiterLimit = Class378.smethod_42(this.string_4);
				pen.LineJoin = Class378.smethod_34(this.string_3);
				LineCap lineCap3 = (pen.EndCap = (pen.StartCap = Class378.smethod_32(this.string_2)));
				if (this.string_5 != "none")
				{
					pen.DashPattern = Class378.smethod_33(this.string_5);
				}
				return pen;
			}
			return null;
		}
	}
}
