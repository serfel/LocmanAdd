using System;
using System.Collections;
using System.Collections.Generic;
using TXTextControl.Drawing;

namespace ns17
{
	internal class Class172 : CollectionBase, IEnumerable, IEnumerator
	{
		private int int_0 = -1;

		private List<Class173> list_0 = new List<Class173>();

		private Shape shape_0;

		internal List<Class173> List_0 => this.list_0;

		internal AdjustObject this[int int_1] => (AdjustObject)base.List[int_1];

		internal double[] Double_0
		{
			get
			{
				double[] array = new double[base.Count];
				for (int i = 0; i < array.Length; i++)
				{
					array[i] = ((AdjustObject)base.InnerList[i]).Value;
				}
				return array;
			}
		}

		public object Current
		{
			get
			{
				try
				{
					return base.List[this.int_0];
				}
				catch (IndexOutOfRangeException)
				{
					throw new InvalidOperationException();
				}
			}
		}

		internal Class172(Shape shape_1)
		{
			this.shape_0 = shape_1;
		}

		internal void method_0(AdjustObject adjustObject_0)
		{
			bool flag = true;
			foreach (Class173 item in this.list_0)
			{
				if (item.Class178_0.Double_4 == adjustObject_0.AdjustRectangle.Class178_0.Double_4 && item.Class178_0.Double_5 == adjustObject_0.AdjustRectangle.Class178_0.Double_5)
				{
					adjustObject_0.AdjustRectangle = item;
					item.List_0.Add(adjustObject_0);
					flag = false;
					break;
				}
			}
			if (flag)
			{
				adjustObject_0.AdjustRectangle.List_0.Add(adjustObject_0);
				this.list_0.Add(adjustObject_0.AdjustRectangle);
			}
			base.InnerList.Add(adjustObject_0);
		}

		internal Class173 method_1(Class177 class177_0)
		{
			foreach (Class173 item in this.list_0)
			{
				if (item.method_0(class177_0.Double_0, class177_0.Double_1))
				{
					return item;
				}
			}
			return null;
		}

		public bool MoveNext()
		{
			this.int_0++;
			return this.int_0 < base.List.Count;
		}

		public void Reset()
		{
			this.int_0 = -1;
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return base.GetEnumerator();
		}
	}
}
