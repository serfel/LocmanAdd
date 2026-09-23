using System.Collections;
using System.Collections.Generic;

namespace ns29
{
	internal class Class596 : CollectionBase
	{
		internal bool bool_0;

		internal Class595 this[int int_0] => (Class595)base.List[int_0];

		internal void method_0(IEnumerable<Class595> ienumerable_0)
		{
			if (this.bool_0)
			{
				return;
			}
			foreach (Class595 item in ienumerable_0)
			{
				base.List.Add(item);
			}
		}
	}
}
