using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace ns8
{
	internal class Class115 : IEnumerable<Class117>, IList<Class117>, ICollection<Class117>, IEnumerable
	{
		public class Class116 : IEnumerator<Class117>, IDisposable, IEnumerator
		{
			private IEnumerator ienumerator_0;

			public Class117 Current => new Class117(this.ienumerator_0.Current);

			Class117 IEnumerator<Class117>.Current => this.Current;

			object IEnumerator.Current => this.Current;

			public Class116(IEnumerator ienumerator_1)
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

		private static Type type_0;

		private static MethodInfo methodInfo_0;

		private static MethodInfo methodInfo_1;

		private static MethodInfo methodInfo_2;

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

		public Class117 this[int index]
		{
			get
			{
				return new Class117(((IList)this.Object_0)[index]);
			}
			set
			{
				((IList)this.Object_0)[index] = value.Object_0;
			}
		}

		public int Count => ((ICollection)this.Object_0).Count;

		public bool IsReadOnly => ((IList)this.Object_0).IsReadOnly;

		public Class115(object object_1)
		{
			this.Object_0 = object_1;
			Class115.type_0 = object_1.GetType();
			Class115.methodInfo_0 = Class115.type_0.GetMethod("AddXY", new Type[2]
			{
				typeof(object),
				typeof(object[])
			});
			Class115.methodInfo_1 = Class115.type_0.GetMethod("DataBindXY", new Type[2]
			{
				typeof(IEnumerable),
				typeof(IEnumerable[])
			});
			Class115.methodInfo_2 = Class115.type_0.GetMethod("DataBindY", new Type[1] { typeof(IEnumerable[]) });
		}

		IEnumerator<Class117> IEnumerable<Class117>.GetEnumerator()
		{
			return this.method_0();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.method_0();
		}

		public int IndexOf(Class117 item)
		{
			return ((IList)this.Object_0).IndexOf(item.Object_0);
		}

		public void Insert(int index, Class117 item)
		{
			((IList)this.Object_0).Insert(index, item.Object_0);
		}

		public void RemoveAt(int index)
		{
			((IList)this.Object_0).RemoveAt(index);
		}

		public void Add(Class117 item)
		{
			((IList)this.Object_0).Add(item.Object_0);
		}

		public void Clear()
		{
			((IList)this.Object_0).Clear();
		}

		public bool Contains(Class117 item)
		{
			return ((IList)this.Object_0).Contains(item.Object_0);
		}

		public void CopyTo(Class117[] array, int arrayIndex)
		{
		}

		public bool Remove(Class117 item)
		{
			((IList)this.Object_0).Remove(item.Object_0);
			return true;
		}

		private IEnumerator<Class117> method_0()
		{
			return new Class116(((IEnumerable)this.Object_0).GetEnumerator());
		}

		public void method_1(object object_1, params object[] object_2)
		{
			Class115.methodInfo_0.Invoke(this.Object_0, new object[2] { object_1, object_2 });
		}

		public void method_2(object object_1, params IEnumerable[] ienumerable_0)
		{
			Class115.methodInfo_1.Invoke(this.Object_0, new object[2] { object_1, ienumerable_0 });
		}

		public void method_3(params IEnumerable[] ienumerable_0)
		{
			Class115.methodInfo_2.Invoke(this.Object_0, new object[1] { ienumerable_0 });
		}
	}
}
