using System.Collections.Generic;

namespace ns0
{
	internal class Class37
	{
		internal List<Class30> list_0 = new List<Class30>();

		internal List<Class28> list_1 = new List<Class28>();

		internal List<Class29> list_2 = new List<Class29>();

		internal List<Class36> list_3 = new List<Class36>();

		internal float float_0;

		internal float float_1;

		internal Class37(float float_2, float float_3)
		{
			this.float_0 = float_2;
			this.float_1 = float_3;
		}

		internal Class37()
		{
		}

		internal void method_0(Class30 class30_0)
		{
			this.list_0.Add(class30_0);
		}

		internal void method_1(float float_2, Class30 class30_0)
		{
			this.list_2.Add(new Class29(float_2, class30_0));
		}

		internal void method_2(Class28 class28_0)
		{
			this.list_1.Add(class28_0);
		}

		internal void method_3(Class36 class36_0)
		{
			this.list_3.Add(class36_0);
		}
	}
}
