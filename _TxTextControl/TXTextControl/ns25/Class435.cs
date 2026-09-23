using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace ns25
{
	internal class Class435 : IList<Class437>, ICollection<Class437>, IEnumerable<Class437>, IEnumerable
	{
		public class Class436 : IEnumerator<Class437>, IDisposable, IEnumerator
		{
			private IEnumerator ienumerator_0;

			public Class437 Current => new Class437(this.ienumerator_0.Current);

			Class437 IEnumerator<Class437>.Current => this.Current;

			object IEnumerator.Current => this.Current;

			public Class436(IEnumerator ienumerator_1)
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

		public Class437 this[int index]
		{
			get
			{
				return new Class437(((IList)this.Object_0)[index]);
			}
			set
			{
				((IList)this.Object_0)[index] = value.Object_0;
			}
		}

		public int Count => ((ICollection)this.Object_0).Count;

		public bool IsReadOnly => false;

		public Class435(object object_1)
		{
			this.Object_0 = object_1;
		}

		IEnumerator<Class437> IEnumerable<Class437>.GetEnumerator()
		{
			return this.method_0();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.method_0();
		}

		public int IndexOf(Class437 item)
		{
			return ((IList)this.Object_0).IndexOf(item.Object_0);
		}

		public void Insert(int index, Class437 item)
		{
			((IList)this.Object_0).Insert(index, item.Object_0);
		}

		public void RemoveAt(int index)
		{
			((IList)this.Object_0).RemoveAt(index);
		}

		public void Add(Class437 item)
		{
			((IList)this.Object_0).Add(item.Object_0);
		}

		public void Clear()
		{
			((IList)this.Object_0).Clear();
		}

		public bool Contains(Class437 item)
		{
			return ((IList)this.Object_0).Contains(item.Object_0);
		}

		public void CopyTo(Class437[] array, int arrayIndex)
		{
			throw new NotSupportedException();
		}

		public bool Remove(Class437 item)
		{
			((IList)this.Object_0).Remove(item.Object_0);
			return true;
		}

		private IEnumerator<Class437> method_0()
		{
			return new Class436(((IEnumerable)this.Object_0).GetEnumerator());
		}
	}
}
