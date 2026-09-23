using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace ns8
{
	internal class Class112 : IEnumerable<Class114>, IList<Class114>, ICollection<Class114>, IEnumerable
	{
		public class Class113 : IEnumerator<Class114>, IDisposable, IEnumerator
		{
			private IEnumerator ienumerator_0;

			public Class114 Current => new Class114(this.ienumerator_0.Current);

			object IEnumerator.Current => this.Current;

			public Class113(IEnumerator ienumerator_1)
			{
				this.ienumerator_0 = ienumerator_1;
			}

			public void Dispose()
			{
				((IDisposable)this.ienumerator_0).Dispose();
			}

			public bool MoveNext()
			{
				return this.ienumerator_0.MoveNext();
			}

			public void Reset()
			{
				this.ienumerator_0.Reset();
			}
		}

		[CompilerGenerated]
		private object object_0;

		public object Object_0
		{
			[CompilerGenerated]
			get
			{
				return this.object_0;
			}
			[CompilerGenerated]
			private set
			{
				this.object_0 = value;
			}
		}

		public Class114 this[int index]
		{
			get
			{
				return new Class114(((IList)this.Object_0)[index]);
			}
			set
			{
				((IList)this.Object_0)[index] = value.Object_0;
			}
		}

		public int Count => ((ICollection)this.Object_0).Count;

		public bool IsReadOnly => ((IList)this.Object_0).IsReadOnly;

		public Class112(object object_1)
		{
			this.Object_0 = object_1;
		}

		IEnumerator<Class114> IEnumerable<Class114>.GetEnumerator()
		{
			return this.method_0();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.method_0();
		}

		public int IndexOf(Class114 item)
		{
			return ((IList)this.Object_0).IndexOf(item);
		}

		public void Insert(int index, Class114 item)
		{
			((IList)this.Object_0).Insert(index, item.Object_0);
		}

		public void RemoveAt(int index)
		{
			((IList)this.Object_0).RemoveAt(index);
		}

		public void Add(Class114 item)
		{
			((IList)this.Object_0).Add(item.Object_0);
		}

		public void Clear()
		{
			((IList)this.Object_0).Clear();
		}

		public bool Contains(Class114 item)
		{
			return ((IList)this.Object_0).Contains(item.Object_0);
		}

		public void CopyTo(Class114[] array, int arrayIndex)
		{
		}

		public bool Remove(Class114 item)
		{
			((IList)this.Object_0).Remove(item.Object_0);
			return true;
		}

		private IEnumerator<Class114> method_0()
		{
			return new Class113(((IEnumerable)this.Object_0).GetEnumerator());
		}
	}
}
