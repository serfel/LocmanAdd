using System;
using System.Collections;
using System.Drawing;
using ns21;

namespace TXTextControl
{
	/// <summary>The MisspelledWordCollection contains all misspelled words in the main part of a Text Control document.</summary>
	public class MisspelledWordCollection : ICollection, IEnumerable
	{
		public class MisspelledWordEnumerator : IEnumerator
		{
			private MisspelledWordCollection misspelledWordCollection_0;

			private int int_0;

			public object Current
			{
				get
				{
					if (this.int_0 <= 0 || this.int_0 > this.misspelledWordCollection_0.Count)
					{
						throw new InvalidOperationException();
					}
					return new MisspelledWord(this.misspelledWordCollection_0.textControlCore_0, this.misspelledWordCollection_0.textPart_0, this.int_0);
				}
			}

			public MisspelledWordEnumerator(MisspelledWordCollection misspelledWordCollection_1)
			{
				this.misspelledWordCollection_0 = misspelledWordCollection_1;
				this.int_0 = 0;
			}

			public bool MoveNext()
			{
				if (this.int_0 < this.misspelledWordCollection_0.Count)
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
		public int Count => this.textControlCore_0.method_29(this.textPart_0, 1946, 0, 0);

		bool ICollection.IsSynchronized => false;

		object ICollection.SyncRoot => this;

		public MisspelledWord this[int number]
		{
			get
			{
				if (number > 0 && number <= this.Count)
				{
					return new MisspelledWord(this.textControlCore_0, this.textPart_0, number);
				}
				return null;
			}
		}

		internal MisspelledWordCollection(TextControlCore textControlCore_1, TextPart iTextPart)
		{
			this.textControlCore_0 = textControlCore_1;
			this.textPart_0 = iTextPart;
		}

		/// <summary>Returns the number of misspelled words with a special meaning from the collection.</summary>
		/// <param name="kind">Specifies the word's kind.</param>
		public int GetCount(MisspelledWordKind kind)
		{
			return this.textControlCore_0.method_29(this.textPart_0, 1946, (int)kind, 0);
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
			MisspelledWordCollection misspelledWordCollection = new MisspelledWordCollection(this.textControlCore_0, this.textPart_0);
			foreach (MisspelledWord item in misspelledWordCollection)
			{
				array.SetValue(item, index++);
			}
		}

		/// <summary>Returns an enumerator that can be used to iterate through the collection.</summary>
		public MisspelledWordEnumerator GetEnumerator()
		{
			return new MisspelledWordEnumerator(this);
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return new MisspelledWordEnumerator(this);
		}

		/// <summary>Gets the misspelled word at the current text input position. If there is no misspelled word, the next possible word is returned. If there is no misspelled word between the current input position and the end of the text, the first word is returned.</summary>
		public MisspelledWord GetItem()
		{
			return this.GetItem(MisspelledWordKind.All);
		}

		/// <summary>Gets the misspelled word of the specified kind at the current text input position. If there is no misspelled word, the next possible word of is returned. If there is no misspelled word of the specified kind between the current input position and the end of the text, the first word of the specified kind is returned.</summary>
		/// <param name="kind">Specifies the word's kind.</param>
		public MisspelledWord GetItem(MisspelledWordKind kind)
		{
			int num = this.textControlCore_0.method_29(this.textPart_0, 1949, Class429.smethod_3(4, (int)kind), -1);
			if (num != 0)
			{
				return new MisspelledWord(this.textControlCore_0, this.textPart_0, num);
			}
			return null;
		}

		/// <summary>Gets the misspelled word at the specified text input position. If there is no misspelled word, the next possible word is returned. If there is no misspelled word between the specified input position and the end of the text, the first word is returned.</summary>
		/// <param name="textPosition">Specifies a zero-based text postion.</param>
		public MisspelledWord GetItem(int textPosition)
		{
			return this.GetItem(textPosition, MisspelledWordKind.All);
		}

		/// <summary>Gets the misspelled word of the specified kind at the specified text input position. If there is no misspelled word, the next possible word is returned. If there is no misspelled word of the specified kind between the specified input position and the end of the text, the first word of the specified kind is returned.</summary>
		/// <param name="textPosition">Specifies a zero-based text postion.</param>
		/// <param name="kind">Specifies the word's kind.</param>
		public MisspelledWord GetItem(int textPosition, MisspelledWordKind kind)
		{
			int num = this.textControlCore_0.method_29(this.textPart_0, 1949, Class429.smethod_3(4, (int)kind), textPosition);
			if (num != 0)
			{
				return new MisspelledWord(this.textControlCore_0, this.textPart_0, num);
			}
			return null;
		}

		/// <summary>Gets the misspelled word at a certain geometrical location. If there is no misspelled word, null is returned.</summary>
		/// <param name="location">Specifies the word's location.</param>
		public MisspelledWord GetItem(Point location)
		{
			Class429.Struct82 struct82_ = new Class429.Struct82(location.X, location.Y);
			int num = this.textControlCore_0.method_35(this.textPart_0, Enum83.const_70, Class429.smethod_3(0, 0), ref struct82_);
			if (num >= 0)
			{
				int num2 = this.textControlCore_0.method_29(this.textPart_0, 1949, 0, num);
				if (num2 != 0)
				{
					return new MisspelledWord(this.textControlCore_0, this.textPart_0, num2);
				}
			}
			return null;
		}

		/// <summary>Changes the text of the specified misspelled word and marks it as ignored. Ignored misspelled words are not underlined with a red zigzag line.</summary>
		/// <param name="misspelledWord">Specifies the misspelled word to change.</param>
		/// <param name="changedText">Specifies the changed text.</param>
		public bool Ignore(MisspelledWord misspelledWord, string changedText)
		{
			return misspelledWord.method_1(this.textPart_0, changedText, bool_0: true);
		}

		/// <summary>Removes the specified misspelled word from a Text Control document. The method removes the word's reference in the list of misspelled words, but not the word's text in the document.</summary>
		/// <param name="misspelledWord">Specifies the misspelled word to remove.</param>
		public bool Remove(MisspelledWord misspelledWord)
		{
			return misspelledWord.method_1(this.textPart_0, null, bool_0: false);
		}

		/// <summary>Removes the specified misspelled word from a Text Control document. The method removes the word's reference in the list of misspelled words and replaces the word's text with the specified text.</summary>
		/// <param name="misspelledWord">Specifies the misspelled word to remove.</param>
		/// <param name="correctedText">Specifies the corrected text.</param>
		public bool Remove(MisspelledWord misspelledWord, string correctedText)
		{
			return misspelledWord.method_1(this.textPart_0, correctedText, bool_0: false);
		}
	}
}
