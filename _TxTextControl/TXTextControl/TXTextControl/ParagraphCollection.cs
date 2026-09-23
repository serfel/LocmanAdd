using System;
using System.Collections;
using System.Drawing;
using ns21;

namespace TXTextControl
{
	/// <summary>An instance of the ParagraphCollection class contains all paragraphs in a Text Control document or part of the document represented through objects of the type Paragraph.</summary>
	public class ParagraphCollection : ICollection, IEnumerable
	{
		public class ParagraphEnumerator : IEnumerator
		{
			private ParagraphCollection paragraphCollection_0;

			private int int_0;

			public object Current
			{
				get
				{
					int count = this.paragraphCollection_0.Count;
					if (this.int_0 <= 0 || this.int_0 > count)
					{
						throw new InvalidOperationException();
					}
					return new Paragraph(this.paragraphCollection_0.textControlCore_0, this.paragraphCollection_0.textPart_0, this.int_0, count);
				}
			}

			public ParagraphEnumerator(ParagraphCollection paragraphCollection_1)
			{
				this.paragraphCollection_0 = paragraphCollection_1;
				this.int_0 = 0;
			}

			public bool MoveNext()
			{
				if (this.int_0 < this.paragraphCollection_0.Count)
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

		private int int_0;

		int ICollection.Count => this.Count;

		/// <summary>Gets the number of elements contained in the collection.</summary>
		public int Count => this.int_0;

		bool ICollection.IsSynchronized => false;

		object ICollection.SyncRoot => this;

		public Paragraph this[int number]
		{
			get
			{
				if (number > 0 && number <= this.int_0)
				{
					return new Paragraph(this.textControlCore_0, this.textPart_0, number, this.int_0);
				}
				return null;
			}
		}

		internal ParagraphCollection(TextControlCore textControlCore_1, TextPart iTextPart)
		{
			this.textControlCore_0 = textControlCore_1;
			this.textPart_0 = iTextPart;
			this.int_0 = this.textControlCore_0.method_29(this.textPart_0, 1912, 0, 0);
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
			ParagraphCollection paragraphCollection = new ParagraphCollection(this.textControlCore_0, this.textPart_0);
			foreach (Paragraph item in paragraphCollection)
			{
				array.SetValue(item, index++);
			}
		}

		/// <summary>Returns an enumerator that can be used to iterate through the collection.</summary>
		public ParagraphEnumerator GetEnumerator()
		{
			return new ParagraphEnumerator(this);
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return new ParagraphEnumerator(this);
		}

		/// <summary>Gets the paragraph at a certain geometrical position.</summary>
		/// <param name="location">Specifies the paragraph's location.</param>
		public Paragraph GetItem(Point location)
		{
			Class429.Struct82 struct82_ = new Class429.Struct82(location.X, location.Y);
			int num = this.textControlCore_0.method_35(this.textPart_0, Enum83.const_243, 0, ref struct82_);
			if (num != 0)
			{
				return new Paragraph(this.textControlCore_0, this.textPart_0, num, this.int_0);
			}
			return null;
		}

		/// <summary>Gets the paragraph at a certain text input position.</summary>
		/// <param name="textPosition">Specifies a zero-based text position.</param>
		public Paragraph GetItem(int textPosition)
		{
			int num = this.textControlCore_0.method_29(this.textPart_0, 1914, 0, textPosition);
			if (num != 0)
			{
				return new Paragraph(this.textControlCore_0, this.textPart_0, num, this.int_0);
			}
			return null;
		}
	}
}
