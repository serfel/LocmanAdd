using System;
using System.Collections;
using System.Drawing;
using ns21;

namespace TXTextControl
{
	/// <summary>An instance of the TextPartCollection class contains all text parts in a TX Text Control document.</summary>
	public class TextPartCollection : ICollection, IEnumerable
	{
		public class TextPartEnumerator : IEnumerator
		{
			private int int_0;

			private int int_1;

			private int int_2;

			private int int_3;

			private int int_4 = 1;

			private HeaderFooterType headerFooterType_0;

			private TextPartCollection textPartCollection_0;

			public object Current
			{
				get
				{
					if (this.int_0 > 0)
					{
						return new MainText(this.textPartCollection_0.textControlCore_0);
					}
					if (this.int_1 > 0)
					{
						return new TextFrame(this.textPartCollection_0.textControlCore_0, TextPart.MainText, this.int_1);
					}
					if (this.int_2 <= 0)
					{
						throw new InvalidOperationException();
					}
					return new HeaderFooter(this.textPartCollection_0.textControlCore_0, this.headerFooterType_0, this.int_4, bConnectedToPrevious: false);
				}
			}

			public TextPartEnumerator(TextPartCollection tpc)
			{
				this.textPartCollection_0 = tpc;
				this.int_3 = this.textPartCollection_0.textControlCore_0.method_30(Enum83.const_231, 0, 0);
			}

			public bool MoveNext()
			{
				if (this.int_0 >= 0)
				{
					if (this.int_0 == 0)
					{
						this.int_0 = 1;
						return true;
					}
					this.int_0 = -1;
				}
				if (this.int_1 >= 0)
				{
					this.int_1 = this.textPartCollection_0.textControlCore_0.method_29(TextPart.MainText, 1239, this.int_1, Class429.smethod_3(32, 1));
					if (this.int_1 > 0)
					{
						return true;
					}
					this.int_1 = -1;
				}
				if (this.int_4 > 0)
				{
					while (this.int_4 <= this.int_3)
					{
						Enum93 @enum = (Enum93)this.textPartCollection_0.textControlCore_0.method_30(Enum83.const_133, this.int_4, 0);
						int num = 0;
						if (((@enum & Enum93.const_5) == 0 && (this.int_4 != 1 || (@enum & Enum93.const_18) == 0)) || this.int_2 != num++)
						{
							if (((@enum & Enum93.const_7) == 0 && (this.int_4 != 1 || (@enum & Enum93.const_20) == 0)) || this.int_2 != num++)
							{
								if (((@enum & Enum93.const_4) == 0 && (this.int_4 != 1 || (@enum & Enum93.const_17) == 0)) || this.int_2 != num++)
								{
									if (((@enum & Enum93.const_6) == 0 && (this.int_4 != 1 || (@enum & Enum93.const_19) == 0)) || this.int_2 != num++)
									{
										if (((@enum & Enum93.const_11) == 0 && (this.int_4 != 1 || (@enum & Enum93.const_21) == 0)) || this.int_2 != num++)
										{
											if (((@enum & Enum93.const_16) == 0 && (this.int_4 != 1 || (@enum & Enum93.const_22) == 0)) || this.int_2 != num++)
											{
												this.int_4++;
												this.int_2 = 0;
												continue;
											}
											this.int_2++;
											this.headerFooterType_0 = HeaderFooterType.EvenFooter;
											return true;
										}
										this.int_2++;
										this.headerFooterType_0 = HeaderFooterType.EvenHeader;
										return true;
									}
									this.int_2++;
									this.headerFooterType_0 = HeaderFooterType.Footer;
									return true;
								}
								this.int_2++;
								this.headerFooterType_0 = HeaderFooterType.Header;
								return true;
							}
							this.int_2++;
							this.headerFooterType_0 = HeaderFooterType.FirstPageFooter;
							return true;
						}
						this.int_2++;
						this.headerFooterType_0 = HeaderFooterType.FirstPageHeader;
						return true;
					}
					this.int_4 = -1;
				}
				return false;
			}

			public void Reset()
			{
				this.int_0 = 0;
				this.int_1 = 0;
				this.int_4 = 1;
				this.int_2 = 0;
			}
		}

		private TextControlCore textControlCore_0;

		private ITextControl itextControl_0;

		int ICollection.Count => this.Count;

		/// <summary>Gets the number of elements contained in the collection.</summary>
		public int Count
		{
			get
			{
				int num = -1;
				int num2 = 0;
				int num3 = this.textControlCore_0.method_30(Enum83.const_231, 0, 0);
				do
				{
					num++;
					num2 = this.textControlCore_0.method_29(TextPart.MainText, 1239, num2, 32);
				}
				while (num2 != 0);
				for (int i = 1; i <= num3; i++)
				{
					Enum93 @enum = (Enum93)this.textControlCore_0.method_30(Enum83.const_133, i, 0);
					if ((@enum & Enum93.const_4) != 0 || (i == 1 && (@enum & Enum93.const_17) != 0))
					{
						num++;
					}
					if ((@enum & Enum93.const_5) != 0 || (i == 1 && (@enum & Enum93.const_18) != 0))
					{
						num++;
					}
					if ((@enum & Enum93.const_6) != 0 || (i == 1 && (@enum & Enum93.const_19) != 0))
					{
						num++;
					}
					if ((@enum & Enum93.const_7) != 0 || (i == 1 && (@enum & Enum93.const_20) != 0))
					{
						num++;
					}
					if ((@enum & Enum93.const_11) != 0 || (i == 1 && (@enum & Enum93.const_21) != 0))
					{
						num++;
					}
					if ((@enum & Enum93.const_16) != 0 || (i == 1 && (@enum & Enum93.const_22) != 0))
					{
						num++;
					}
				}
				return num + 1;
			}
		}

		bool ICollection.IsSynchronized => false;

		object ICollection.SyncRoot => this;

		internal TextPartCollection(TextControlCore textControlCore_1, ITextControl textcontrol)
		{
			this.textControlCore_0 = textControlCore_1;
			this.itextControl_0 = textcontrol;
		}

		/// <summary>Sets the input focus to the specified text part. If the activated text part is not in the visible part of the document, the document is scrolled.</summary>
		/// <param name="textPart">Specifies the object to activate.</param>
		public bool Activate(object textPart)
		{
			bool result = false;
			MainText mainText = textPart as MainText;
			ITextControl textControl = textPart as ITextControl;
			if (mainText == null && textControl != this.itextControl_0)
			{
				TextFrame textFrame = textPart as TextFrame;
				if (textFrame != null)
				{
					result = textFrame.Activate();
				}
				else
				{
					HeaderFooter headerFooter = textPart as HeaderFooter;
					if (headerFooter != null)
					{
						result = headerFooter.Activate();
					}
				}
			}
			else if (this.textControlCore_0 != null && this.textControlCore_0.isHandleCreated && !(result = 0 != this.textControlCore_0.method_29(TextPart.MainText, 1889, 0, 0)))
			{
				result = 0 != this.textControlCore_0.method_29(TextPart.MainText, 1284, 0, 0);
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
			TextPartCollection textPartCollection = new TextPartCollection(this.textControlCore_0, this.itextControl_0);
			foreach (object item in textPartCollection)
			{
				array.SetValue(item, index++);
			}
		}

		/// <summary>Returns an enumerator that can be used to iterate through the collection.</summary>
		public TextPartEnumerator GetEnumerator()
		{
			return new TextPartEnumerator(this);
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return new TextPartEnumerator(this);
		}

		/// <summary>Gets the text part with the input focus.</summary>
		public object GetItem()
		{
			Point clientOffset;
			return this.GetItem(out clientOffset);
		}

		/// <summary>Gets the text part with the input focus informing about the offset of the text part in the TextControl's client area.</summary>
		/// <param name="clientOffset">Retrieves the text part's offset, in pixels, in the TextControl's client area.</param>
		public object GetItem(out Point clientOffset)
		{
			return this.GetItem(new Point(-1, -1), out clientOffset);
		}

		/// <summary>Gets the text part at the specified geometric location.</summary>
		/// <param name="location">Specifies a location where to search for a text part.</param>
		/// <param name="clientOffset">Retrieves the text part's offset, in pixels, in the TextControl's client area.</param>
		public object GetItem(Point location, out Point clientOffset)
		{
			Struct76 struct76_ = new Struct76(location);
			int num = this.textControlCore_0.method_52(Enum83.const_281, 0, ref struct76_);
			clientOffset = new Point(struct76_.struct82_1.int_0, struct76_.struct82_1.int_1);
			return num switch
			{
				1 => new MainText(this.textControlCore_0), 
				2 => new TextFrame(this.textControlCore_0, TextPart.MainText, struct76_.ushort_1), 
				3 => new HeaderFooter(this.textControlCore_0, (HeaderFooterType)struct76_.ushort_2, struct76_.ushort_3, bConnectedToPrevious: false), 
				_ => null, 
			};
		}

		/// <summary>Gets the main text part of the document.</summary>
		public MainText GetMainText()
		{
			return new MainText(this.textControlCore_0);
		}
	}
}
