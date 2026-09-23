using System;
using System.Collections;
using System.Drawing;
using ns21;

namespace TXTextControl
{
	/// <summary>An instance of the LineCollection class contains all text lines in a Text Control document or part of the document represented through objects of the type Line.</summary>
	public class LineCollection : ICollection, IEnumerable
	{
		public class LineEnumerator : IEnumerator
		{
			private LineCollection lineCollection_0;

			private int int_0;

			public object Current
			{
				get
				{
					if (this.int_0 <= 0 || this.int_0 > this.lineCollection_0.Count)
					{
						throw new InvalidOperationException();
					}
					return new Line(this.lineCollection_0.textControlCore_0, this.lineCollection_0.textPart_0, this.int_0);
				}
			}

			public LineEnumerator(LineCollection lineCollection_1)
			{
				this.lineCollection_0 = lineCollection_1;
				this.int_0 = 0;
			}

			public bool MoveNext()
			{
				if (this.int_0 < this.lineCollection_0.Count)
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
		public int Count => this.textControlCore_0.method_29(this.textPart_0, 1139, 0, 0);

		bool ICollection.IsSynchronized => false;

		object ICollection.SyncRoot => this;

		public Line this[int number]
		{
			get
			{
				if (number > 0 && number <= this.Count)
				{
					return new Line(this.textControlCore_0, this.textPart_0, number);
				}
				return null;
			}
		}

		internal LineCollection(TextControlCore textControlCore_1, TextPart iTextPart)
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
			LineCollection lineCollection = new LineCollection(this.textControlCore_0, this.textPart_0);
			foreach (Line item in lineCollection)
			{
				array.SetValue(item, index++);
			}
		}

		/// <summary>Returns an enumerator that can be used to iterate through the collection.</summary>
		public LineEnumerator GetEnumerator()
		{
			return new LineEnumerator(this);
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return new LineEnumerator(this);
		}

		/// <summary>Gets the line at a certain geometrical position.</summary>
		/// <param name="location">Specifies the line's location.</param>
		public Line GetItem(Point location)
		{
			Class429.Struct82 struct82_ = new Class429.Struct82(location.X, location.Y);
			int num = this.textControlCore_0.method_35(this.textPart_0, Enum83.const_18, 0, ref struct82_);
			if (num != 0)
			{
				return new Line(this.textControlCore_0, this.textPart_0, num);
			}
			return null;
		}

		/// <summary>Gets the line at a certain text position.</summary>
		/// <param name="textPosition">Specifies a zero-based text position.</param>
		public Line GetItem(int textPosition)
		{
			int num = this.textControlCore_0.method_29(this.textPart_0, 1141, 0, textPosition);
			if (num != 0)
			{
				return new Line(this.textControlCore_0, this.textPart_0, num);
			}
			return null;
		}
	}
}
