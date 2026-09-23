namespace TXTextControl.Windows.Forms.Ribbon
{
	internal class Class556
	{
		private bool bool_0;

		private int int_0 = int.MaxValue;

		private int int_1 = int.MinValue;

		private Class560[] class560_0 = new Class560[0];

		internal bool Boolean_0 => this.bool_0;

		internal Class560[] Class560_0 => this.class560_0;

		internal int Int32_0 => this.int_1;

		internal int Int32_1 => this.int_0;

		internal Class556(int int_2, Class560[] class560_1, bool bool_1)
		{
			if (!(this.bool_0 = bool_1))
			{
				this.int_1 = this.method_0(class560_1);
			}
			this.int_0 = int_2;
			this.class560_0 = class560_1;
		}

		private int method_0(Class560[] class560_1)
		{
			int num = 0;
			foreach (Class560 @class in class560_1)
			{
				num += @class.Int32_0;
			}
			return num;
		}
	}
}
