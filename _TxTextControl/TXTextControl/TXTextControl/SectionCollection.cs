using System;
using System.Collections;
using ns21;

namespace TXTextControl
{
	/// <summary>An instance of the SectionCollection class contains all sections of a document.</summary>
	public sealed class SectionCollection : ICollection, IEnumerable
	{
		public class SectionEnumerator : IEnumerator
		{
			private SectionCollection sectionCollection_0;

			private int int_0;

			public object Current
			{
				get
				{
					if (this.int_0 <= 0 || this.int_0 > this.sectionCollection_0.Count)
					{
						throw new InvalidOperationException();
					}
					return new Section(this.sectionCollection_0.textControlCore_0, this.int_0);
				}
			}

			public SectionEnumerator(SectionCollection sectionCollection_1)
			{
				this.sectionCollection_0 = sectionCollection_1;
				this.int_0 = 0;
			}

			public bool MoveNext()
			{
				if (this.int_0 < this.sectionCollection_0.Count)
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
		public int Count => this.textControlCore_0.method_30(Enum83.const_231, 0, 0);

		bool ICollection.IsSynchronized => false;

		object ICollection.SyncRoot => this;

		public Section this[int number]
		{
			get
			{
				if (number > 0 && number <= this.Count)
				{
					return new Section(this.textControlCore_0, number);
				}
				return null;
			}
		}

		internal SectionCollection(TextControlCore textControlCore_1)
		{
			this.textControlCore_0 = textControlCore_1;
		}

		/// <summary>Adds a new section at the current text input position. The new section ends at the end position of the section containing the input position. If a new section is inserted in a paragraph or table, the paragraph or table is split into two paragraphs or tables.</summary>
		/// <param name="sectionBreakKind">Specifies the kind of the section break.</param>
		public bool Add(SectionBreakKind sectionBreakKind)
		{
			if (this.textControlCore_0.method_30(Enum83.const_220, (int)sectionBreakKind, -1) != 0)
			{
				return true;
			}
			return false;
		}

		/// <summary>Adds a new section at the specified text input position. The new section ends at the end position of the section containing the input position. If a new section is inserted in a paragraph or table, the paragraph or table is split into two paragraphs or tables.</summary>
		/// <param name="sectionBreakKind">Specifies the kind of the section break.</param>
		/// <param name="textPosition">Specifies the text position at which the section is to be inserted.</param>
		public bool Add(SectionBreakKind sectionBreakKind, int textPosition)
		{
			if (this.textControlCore_0.method_30(Enum83.const_220, (int)sectionBreakKind, textPosition) != 0)
			{
				return true;
			}
			return false;
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
			SectionCollection sectionCollection = new SectionCollection(this.textControlCore_0);
			foreach (Section item in sectionCollection)
			{
				array.SetValue(item, index++);
			}
		}

		/// <summary>Returns an enumerator that can be used to iterate through the collection.</summary>
		public SectionEnumerator GetEnumerator()
		{
			return new SectionEnumerator(this);
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return new SectionEnumerator(this);
		}

		/// <summary>Gets the Section with the current text input position from the collection.</summary>
		public Section GetItem()
		{
			int num = this.textControlCore_0.method_30(Enum83.const_232, 0, 0);
			if (num != 0)
			{
				return new Section(this.textControlCore_0, num);
			}
			return null;
		}
	}
}
