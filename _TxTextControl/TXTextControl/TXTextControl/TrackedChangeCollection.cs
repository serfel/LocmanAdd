using System;
using System.Collections;

namespace TXTextControl
{
	/// <summary>Contains all tracked changes in the main text or another part of a document.</summary>
	public sealed class TrackedChangeCollection : ICollection, IEnumerable
	{
		public class TrackedChangeEnumerator : IEnumerator
		{
			private TrackedChangeCollection trackedChangeCollection_0;

			private int int_0;

			public object Current
			{
				get
				{
					if (this.int_0 <= 0 || this.int_0 > this.trackedChangeCollection_0.Count)
					{
						throw new InvalidOperationException();
					}
					return new TrackedChange(this.trackedChangeCollection_0.textControlCore_0, this.trackedChangeCollection_0.textPart_0, this.int_0, 0);
				}
			}

			public TrackedChangeEnumerator(TrackedChangeCollection stpc)
			{
				this.trackedChangeCollection_0 = stpc;
				this.int_0 = 0;
			}

			public bool MoveNext()
			{
				if (this.int_0 < this.trackedChangeCollection_0.Count)
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

		private TextPart textPart_0;

		int ICollection.Count => this.Count;

		/// <summary>Gets the number of elements contained in the collection.</summary>
		public int Count => this.textControlCore_0.method_29(this.textPart_0, 1979, 2, 0);

		bool ICollection.IsSynchronized => false;

		object ICollection.SyncRoot => this;

		public TrackedChange this[int number]
		{
			get
			{
				if (number > 0 && number <= this.Count)
				{
					return new TrackedChange(this.textControlCore_0, this.textPart_0, number, 0);
				}
				return null;
			}
		}

		internal TrackedChangeCollection(TextControlCore textControlCore_1, TextPart iTextPart)
		{
			this.textControlCore_0 = textControlCore_1;
			this.textPart_0 = iTextPart;
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
			foreach (TrackedChange item in this)
			{
				array.SetValue(item, index++);
			}
		}

		/// <summary>Returns an enumerator that can be used to iterate through the collection.</summary>
		public TrackedChangeEnumerator GetEnumerator()
		{
			return new TrackedChangeEnumerator(this);
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return new TrackedChangeEnumerator(this);
		}

		/// <summary>Gets the change at the current text input position. If there is more than one change at the current input position the innermost change is returned.</summary>
		public TrackedChange GetItem()
		{
			int num = this.textControlCore_0.method_29(this.textPart_0, 1982, 2, 0);
			if (num != 0)
			{
				return new TrackedChange(this.textControlCore_0, this.textPart_0, 0, num);
			}
			return null;
		}

		/// <summary>Gets the next or the previous change in the textflow. The search begins at the current text input position.</summary>
		/// <param name="next">If this parameter is true, the next change in the textflow is returned.</param>
		public TrackedChange GetItem(bool next)
		{
			int num = this.textControlCore_0.method_29(this.textPart_0, 1982, 2, next ? 1 : 2);
			if (num != 0)
			{
				return new TrackedChange(this.textControlCore_0, this.textPart_0, 0, num);
			}
			return null;
		}

		/// <summary>Removes a tracked change from the collection. Depending on the accept parameter the change is either accepted or rejected. When a change is rejected, inserted text is removed and deleted text is reinserted.</summary>
		/// <param name="trackedChange">Specifies the tracked change to remove.</param>
		/// <param name="accept">When this parameter is true, the change is accepted, otherwise, it is rejected.</param>
		public bool Remove(TrackedChange trackedChange, bool accept)
		{
			return trackedChange.method_3(accept);
		}
	}
}
