using System;
using System.Collections;
using ns21;

namespace TXTextControl
{
	/// <summary>An instance of the HeaderFooterCollection class contains the headers and footers in a Text Control document represented through objects of the type HeaderFooter.</summary>
	public class HeaderFooterCollection : ICollection, IEnumerable
	{
		public class HeaderFooterEnumerator : IEnumerator
		{
			private HeaderFooterCollection headerFooterCollection_0;

			private int int_0;

			public object Current
			{
				get
				{
					int num = 0;
					Enum93 @enum = (Enum93)this.headerFooterCollection_0.textControlCore_0.method_30(Enum83.const_133, this.headerFooterCollection_0.int_0, 0);
					if (((@enum & Enum93.const_4) != 0 || (@enum & Enum93.const_17) != 0) && ++num == this.int_0)
					{
						return new HeaderFooter(this.headerFooterCollection_0.textControlCore_0, HeaderFooterType.Header, this.headerFooterCollection_0.int_0, (@enum & Enum93.const_17) != 0);
					}
					if (((@enum & Enum93.const_5) != 0 || (@enum & Enum93.const_18) != 0) && ++num == this.int_0)
					{
						return new HeaderFooter(this.headerFooterCollection_0.textControlCore_0, HeaderFooterType.FirstPageHeader, this.headerFooterCollection_0.int_0, (@enum & Enum93.const_18) != 0);
					}
					if (((@enum & Enum93.const_6) != 0 || (@enum & Enum93.const_19) != 0) && ++num == this.int_0)
					{
						return new HeaderFooter(this.headerFooterCollection_0.textControlCore_0, HeaderFooterType.Footer, this.headerFooterCollection_0.int_0, (@enum & Enum93.const_19) != 0);
					}
					if (((@enum & Enum93.const_7) != 0 || (@enum & Enum93.const_20) != 0) && ++num == this.int_0)
					{
						return new HeaderFooter(this.headerFooterCollection_0.textControlCore_0, HeaderFooterType.FirstPageFooter, this.headerFooterCollection_0.int_0, (@enum & Enum93.const_20) != 0);
					}
					if (((@enum & Enum93.const_11) != 0 || (@enum & Enum93.const_21) != 0) && ++num == this.int_0)
					{
						return new HeaderFooter(this.headerFooterCollection_0.textControlCore_0, HeaderFooterType.EvenHeader, this.headerFooterCollection_0.int_0, (@enum & Enum93.const_21) != 0);
					}
					if (((@enum & Enum93.const_16) == 0 && (@enum & Enum93.const_22) == 0) || ++num != this.int_0)
					{
						throw new InvalidOperationException();
					}
					return new HeaderFooter(this.headerFooterCollection_0.textControlCore_0, HeaderFooterType.EvenFooter, this.headerFooterCollection_0.int_0, (@enum & Enum93.const_22) != 0);
				}
			}

			public HeaderFooterEnumerator(HeaderFooterCollection hfc)
			{
				this.headerFooterCollection_0 = hfc;
				this.int_0 = 0;
			}

			public bool MoveNext()
			{
				if (this.int_0 < this.headerFooterCollection_0.Count)
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

		private int int_0;

		int ICollection.Count => this.Count;

		/// <summary>Gets the number of elements contained in the collection.</summary>
		public int Count
		{
			get
			{
				int num = 0;
				Enum93 @enum = (Enum93)this.textControlCore_0.method_30(Enum83.const_133, this.int_0, 0);
				if ((@enum & Enum93.const_4) != 0 || (@enum & Enum93.const_17) != 0)
				{
					num++;
				}
				if ((@enum & Enum93.const_5) != 0 || (@enum & Enum93.const_18) != 0)
				{
					num++;
				}
				if ((@enum & Enum93.const_6) != 0 || (@enum & Enum93.const_19) != 0)
				{
					num++;
				}
				if ((@enum & Enum93.const_7) != 0 || (@enum & Enum93.const_20) != 0)
				{
					num++;
				}
				if ((@enum & Enum93.const_11) != 0 || (@enum & Enum93.const_21) != 0)
				{
					num++;
				}
				if ((@enum & Enum93.const_16) != 0 || (@enum & Enum93.const_22) != 0)
				{
					num++;
				}
				return num;
			}
		}

		bool ICollection.IsSynchronized => false;

		object ICollection.SyncRoot => this;

		internal HeaderFooterCollection(TextControlCore textControlCore_1, int iSectionNumber)
		{
			this.textControlCore_0 = textControlCore_1;
			this.int_0 = iSectionNumber;
		}

		/// <summary>Adds a new header or footer to a Text Control document or to a certain section of the document. If a header or footer is added to the complete document the first section receives the header or footer and all other sections receive headers or footers which are connected to their previous section. To add more than one header or footer a combination of the HeaderFooterType enumeration values can be used.</summary>
		/// <param name="headerFooterType">Specifies the headers and/or footers to add.</param>
		public bool Add(HeaderFooterType headerFooterType)
		{
			this.textControlCore_0.method_30(Enum83.const_126, 0, 0);
			if (this.textControlCore_0.method_30(Enum83.const_127, this.int_0, (int)headerFooterType) != 0)
			{
				int num = this.int_0;
				if (this.int_0 == 0)
				{
					num = 1;
				}
				if (KernelHelper.IsSingleSection(num))
				{
					if ((headerFooterType & HeaderFooterType.Header) != 0)
					{
						TextPart textPart_ = (TextPart)Class429.smethod_3(1, num);
						this.textControlCore_0.method_9(textPart_);
						this.textControlCore_0.method_29(textPart_, 2039, 0, 0);
					}
					if ((headerFooterType & HeaderFooterType.Footer) != 0)
					{
						TextPart textPart_2 = (TextPart)Class429.smethod_3(4, num);
						this.textControlCore_0.method_9(textPart_2);
						this.textControlCore_0.method_29(textPart_2, 2039, 0, 0);
					}
					if ((headerFooterType & HeaderFooterType.FirstPageHeader) != 0)
					{
						TextPart textPart_3 = (TextPart)Class429.smethod_3(2, num);
						this.textControlCore_0.method_9(textPart_3);
						this.textControlCore_0.method_29(textPart_3, 2039, 0, 0);
					}
					if ((headerFooterType & HeaderFooterType.FirstPageFooter) != 0)
					{
						TextPart textPart_4 = (TextPart)Class429.smethod_3(8, num);
						this.textControlCore_0.method_9(textPart_4);
						this.textControlCore_0.method_29(textPart_4, 2039, 0, 0);
					}
					if ((headerFooterType & HeaderFooterType.EvenHeader) != 0)
					{
						TextPart textPart_5 = (TextPart)Class429.smethod_3(128, num);
						this.textControlCore_0.method_9(textPart_5);
						this.textControlCore_0.method_29(textPart_5, 2039, 0, 0);
					}
					if ((headerFooterType & HeaderFooterType.EvenFooter) != 0)
					{
						TextPart textPart_6 = (TextPart)Class429.smethod_3(32768, num);
						this.textControlCore_0.method_9(textPart_6);
						this.textControlCore_0.method_29(textPart_6, 2039, 0, 0);
					}
				}
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
			HeaderFooterCollection headerFooterCollection = new HeaderFooterCollection(this.textControlCore_0, this.int_0);
			foreach (HeaderFooter item in headerFooterCollection)
			{
				array.SetValue(item, index++);
			}
		}

		/// <summary>Returns an enumerator that can be used to iterate through the collection.</summary>
		public HeaderFooterEnumerator GetEnumerator()
		{
			return new HeaderFooterEnumerator(this);
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return new HeaderFooterEnumerator(this);
		}

		/// <summary>Gets a particular header or footer from the collection. If the specified header or footer does not exist in the collection an ArgumentException is thrown.</summary>
		/// <param name="headerFooterType">Specifies the header or footer to return.</param>
		public HeaderFooter GetItem(HeaderFooterType headerFooterType)
		{
			if (headerFooterType != HeaderFooterType.All)
			{
				int num = this.textControlCore_0.method_30(Enum83.const_133, this.int_0, 0);
				if (((uint)num & (uint)headerFooterType) != 0)
				{
					return new HeaderFooter(this.textControlCore_0, headerFooterType, this.int_0, bConnectedToPrevious: false);
				}
				if (((uint)num & (uint)KernelHelper.HFTypeToPrev(headerFooterType)) != 0)
				{
					return new HeaderFooter(this.textControlCore_0, headerFooterType, this.int_0, bConnectedToPrevious: true);
				}
			}
			return null;
		}

		/// <summary>Removes a header or footer from a Text Control document or from a certain section. To remove more than one header or footer a combination of the HeaderFooterType enumeration can be used.</summary>
		/// <param name="headerFooterType">Specifies the headers and/or footers to remove.</param>
		public bool Remove(HeaderFooterType headerFooterType)
		{
			return this.textControlCore_0.method_30(Enum83.const_131, this.int_0, (int)headerFooterType) != 0;
		}
	}
}
