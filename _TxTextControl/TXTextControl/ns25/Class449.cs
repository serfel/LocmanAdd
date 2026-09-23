using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace ns25
{
	internal class Class449 : IEnumerable, IList<Class451>, ICollection<Class451>, IEnumerable<Class451>
	{
		public class Class450 : IDisposable, IEnumerator, IEnumerator<Class451>
		{
			private IEnumerator ienumerator_0;

			public Class451 Current => new Class451(this.ienumerator_0.Current);

			object IEnumerator.Current => this.Current;

			public Class450(IEnumerator ienumerator_1)
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

		public Class451 this[int index]
		{
			get
			{
				return new Class451(((IList)this.Object_0)[index]);
			}
			set
			{
				((IList)this.Object_0)[index] = value.Object_0;
			}
		}

		public int Count => ((IList)this.Object_0).Count;

		public bool IsReadOnly => ((IList)this.Object_0).IsReadOnly;

		public Class449(object object_1)
		{
			this.Object_0 = object_1;
		}

		IEnumerator<Class451> IEnumerable<Class451>.GetEnumerator()
		{
			return this.method_0();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.method_0();
		}

		public int IndexOf(Class451 item)
		{
			return ((IList)this.Object_0).IndexOf(item.Object_0);
		}

		public void Insert(int index, Class451 item)
		{
			((IList)this.Object_0).Insert(index, item.Object_0);
		}

		public void RemoveAt(int index)
		{
			((IList)this.Object_0).RemoveAt(index);
		}

		public void Add(Class451 item)
		{
			((IList)this.Object_0).Add(item.Object_0);
		}

		public void Clear()
		{
			((IList)this.Object_0).Clear();
		}

		public bool Contains(Class451 item)
		{
			return ((IList)this.Object_0).Contains(item.Object_0);
		}

		public void CopyTo(Class451[] array, int arrayIndex)
		{
		}

		public bool Remove(Class451 item)
		{
			((IList)this.Object_0).Remove(item.Object_0);
			return true;
		}

		private IEnumerator<Class451> method_0()
		{
			return new Class450(((IEnumerable)this.Object_0).GetEnumerator());
		}
	}
}
