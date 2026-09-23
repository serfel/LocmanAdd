using System;
using System.Collections;
using System.Drawing;
using ns21;

namespace TXTextControl
{
	/// <summary>An instance of the TextCharCollection class contains all characters in a Text Control document or part of the document represented through objects of the type TextChar.</summary>
	public class TextCharCollection : ICollection, IEnumerable
	{
		public class TextCharEnumerator : IEnumerator
		{
			private TextCharCollection textCharCollection_0;

			private int int_0;

			public object Current
			{
				get
				{
					if (this.int_0 <= 0 || this.int_0 > this.textCharCollection_0.Count)
					{
						throw new InvalidOperationException();
					}
					return new TextChar(this.textCharCollection_0.textControlCore_0, this.textCharCollection_0.textPart_0, this.int_0);
				}
			}

			public TextCharEnumerator(TextCharCollection tcc)
			{
				this.textCharCollection_0 = tcc;
				this.int_0 = 0;
			}

			public bool MoveNext()
			{
				if (this.int_0 < this.textCharCollection_0.Count)
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
		public int Count => this.textControlCore_0.method_29(this.textPart_0, 1136, 0, 0);

		bool ICollection.IsSynchronized => false;

		object ICollection.SyncRoot => this;

		public TextChar this[int number]
		{
			get
			{
				if (number > 0 && number <= this.Count)
				{
					return new TextChar(this.textControlCore_0, this.textPart_0, number);
				}
				return null;
			}
		}

		internal TextCharCollection(TextControlCore textControlCore_1, TextPart iTextPart)
		{
			this.textControlCore_0 = textControlCore_1;
			this.textPart_0 = iTextPart;
		}

		/// <summary>Inserts a character at the current text input position.</summary>
		/// <param name="character">Specifies the character to insert.</param>
		public bool Add(char character)
		{
			return this.Add(character, "", -1);
		}

		/// <summary>Inserts a character at the current text input position using the specified font.</summary>
		/// <param name="character">Specifies the character to insert.</param>
		/// <param name="fontName">Specifies the name of the font which is used for the specified character.</param>
		public bool Add(char character, string fontName)
		{
			return this.Add(character, fontName, -1);
		}

		/// <summary>Inserts a character at the specified position using the specified font.</summary>
		/// <param name="character">Specifies the character to insert.</param>
		/// <param name="fontName">Specifies the name of the font which is used for the specified character.</param>
		/// <param name="textPosition">Specifies a text input position.</param>
		public bool Add(char character, string fontName, int textPosition)
		{
			bool result = false;
			if (Convert.ToUInt16(character) >= 32)
			{
				if (textPosition >= 0)
				{
					this.textControlCore_0.method_14(this.textPart_0, textPosition, 0);
				}
				if (this.textControlCore_0.method_37(this.textPart_0, 1972, Convert.ToInt32(character), fontName) == 2)
				{
					result = true;
				}
				if (textPosition >= 0)
				{
					this.textControlCore_0.method_15(this.textPart_0);
				}
			}
			return result;
		}

		/// <summary>Inserts a control character at the current text input position.</summary>
		/// <param name="controlChar">Specifies a control character to insert.</param>
		public bool Add(ControlChars controlChar)
		{
			return this.Add(controlChar, -1);
		}

		/// <summary>Inserts a control character at the specified text input position.</summary>
		/// <param name="controlChar">Specifies a control character to insert.</param>
		/// <param name="textPosition">Specifies a text input position.</param>
		public bool Add(ControlChars controlChar, int textPosition)
		{
			bool result = false;
			if (textPosition >= 0)
			{
				this.textControlCore_0.method_14(this.textPart_0, textPosition, 0);
			}
			if (this.textControlCore_0.method_37(this.textPart_0, 1972, (ushort)controlChar, "") == 2)
			{
				result = true;
			}
			if (textPosition >= 0)
			{
				this.textControlCore_0.method_15(this.textPart_0);
			}
			return result;
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
			TextCharCollection textCharCollection = new TextCharCollection(this.textControlCore_0, this.textPart_0);
			foreach (TextChar item in textCharCollection)
			{
				array.SetValue(item, index++);
			}
		}

		/// <summary>Returns an enumerator that can be used to iterate through the collection.</summary>
		public TextCharEnumerator GetEnumerator()
		{
			return new TextCharEnumerator(this);
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return new TextCharEnumerator(this);
		}

		/// <summary>Gets a particular character from the collection specified through a certain geometrical position.</summary>
		/// <param name="location">Specifies the character's location.</param>
		/// <param name="getNearest">Specifies whether the nearest character is returned.</param>
		public TextChar GetItem(Point location, bool getNearest)
		{
			int count = this.Count;
			if (count > 0)
			{
				Class429.Struct82 struct82_ = new Class429.Struct82(location.X, location.Y);
				Enum110 int_ = Enum110.const_1 | (getNearest ? Enum110.const_0 : Enum110.const_3);
				int num = this.textControlCore_0.method_35(this.textPart_0, Enum83.const_70, Class429.smethod_3(0, (int)int_), ref struct82_);
				if (num >= 0)
				{
					if (num == count)
					{
						num--;
					}
					return new TextChar(this.textControlCore_0, this.textPart_0, num + 1);
				}
			}
			return null;
		}

		/// <summary>Removes a character from a Text Control document. The method can also be used to remove control characters. Single control characters which are important for other formatting attributes, i.e. a table cell end character, cannot be removed through this method.</summary>
		/// <param name="textChar">Specifies the character to remove.</param>
		public bool Remove(TextChar textChar)
		{
			bool result = false;
			this.textControlCore_0.method_14(this.textPart_0, textChar.Number - 1, 0);
			if (this.textControlCore_0.method_29(this.textPart_0, 771, 0, 0) == 2)
			{
				result = true;
			}
			this.textControlCore_0.method_15(this.textPart_0);
			return result;
		}
	}
}
