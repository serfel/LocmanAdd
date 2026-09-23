using System;
using System.Collections;
using ns21;

namespace TXTextControl
{
	/// <summary>An instance of the PageCollection class contains all pages of a document.</summary>
	public sealed class PageCollection : ICollection, IEnumerable
	{
		public class PageEnumerator : IEnumerator
		{
			private PageCollection pageCollection_0;

			private int int_0;

			public object Current
			{
				get
				{
					if (this.int_0 <= 0 || this.int_0 > this.pageCollection_0.Count)
					{
						throw new InvalidOperationException();
					}
					return new Page(this.pageCollection_0.textControlCore_0, this.int_0);
				}
			}

			public PageEnumerator(PageCollection pageCollection_1)
			{
				this.pageCollection_0 = pageCollection_1;
				this.int_0 = 0;
			}

			public bool MoveNext()
			{
				if (this.int_0 < this.pageCollection_0.Count)
				{
					this.int_0++;
					return true;
				}
				return false;
			}

			public void Reset()
			{
				this.int_0 = 0;
			}
		}

		private TextControlCore textControlCore_0;

		int ICollection.Count => this.Count;

		/// <summary>Gets the number of elements contained in the collection.</summary>
		public int Count => this.textControlCore_0.method_30(Enum83.const_56, 0, 0);

		bool ICollection.IsSynchronized => false;

		object ICollection.SyncRoot => this;

		public Page this[int number]
		{
			get
			{
				if (number > 0 && number <= this.Count)
				{
					return new Page(this.textControlCore_0, number);
				}
				return null;
			}
		}

		internal PageCollection(TextControlCore textControlCore_1)
		{
			this.textControlCore_0 = textControlCore_1;
		}

		void ICollection.CopyTo(Array array, int index)
		{
			this.CopyTo(array, index);
		}

		/// <summary>Copies the elements of the collection to an array, starting at a particular index.</summary>
		/// <param name="array">Specifies the array to copy to.</param>
		/// <param name="index">Specifies the index of the destination array at which to begin copying.</param>
		public void CopyTo(Array array, int index)
		{
			PageCollection pageCollection = new PageCollection(this.textControlCore_0);
			foreach (Page item in pageCollection)
			{
				array.SetValue(item, index++);
			}
		}

		/// <summary>Returns an enumerator that can be used to iterate through the collection.</summary>
		public PageEnumerator GetEnumerator()
		{
			return new PageEnumerator(this);
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return new PageEnumerator(this);
		}

		/// <summary>Gets the Page containing the current text input position from the collection.</summary>
		public Page GetItem()
		{
			int[] array = new int[2];
			int[] int_ = array;
			int num = this.textControlCore_0.method_40(TextPart.MainText, 1129, 0, int_);
			if (num > 0)
			{
				return new Page(this.textControlCore_0, num);
			}
			return null;
		}

		/// <summary>Gets the Page at a certain text input position.</summary>
		/// <param name="textPosition">Specifies a zero-based text input position.</param>
		public Page GetItem(int textPosition)
		{
			int num = this.textControlCore_0.method_30(Enum83.const_318, 0, textPosition);
			if (num != 0)
			{
				return new Page(this.textControlCore_0, num);
			}
			return null;
		}
	}
}
