using System;
using System.ComponentModel;

namespace ns16
{
	internal class Class147 : Class146
	{
		private string string_1;

		public Class147(string string_2)
		{
			this.string_1 = string_2;
			this.method_2();
		}

		public override void Reset()
		{
			base.Reset();
			this.method_2();
		}

		protected override PropertyDescriptorCollection GetProperties(Attribute[] attributes)
		{
			bool boolean_ = base.Boolean_0;
			try
			{
				base.Boolean_0 = true;
				return base.GetProperties(attributes);
			}
			finally
			{
				base.Boolean_0 = boolean_;
			}
		}

		private void method_2()
		{
			this["Provider"] = this.string_1;
		}
	}
}
