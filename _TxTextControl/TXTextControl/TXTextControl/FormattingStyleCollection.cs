using System;
using System.Collections;
using System.Runtime.InteropServices;
using ns21;

namespace TXTextControl
{
	/// <summary>The FormattingStyleCollection contains a collection of formatting styles.</summary>
	public abstract class FormattingStyleCollection : ICollection, IEnumerable
	{
		internal enum Enum60
		{
			const_0 = 1,
			const_1 = 2,
			const_2 = 0xFF
		}

		public class FormattingStyleEnumerator : IEnumerator
		{
			private FormattingStyleCollection formattingStyleCollection_0;

			private int int_0 = -1;

			public virtual object Current
			{
				get
				{
					if (this.int_0 >= 0 && this.int_0 < this.formattingStyleCollection_0.m_iCount)
					{
						switch (this.formattingStyleCollection_0.m_iType)
						{
						case Enum58.const_0:
							return new ParagraphStyle(this.formattingStyleCollection_0.m_tx, this.formattingStyleCollection_0.m_strStyleNames[this.int_0]);
						case Enum58.const_1:
							return new InlineStyle(this.formattingStyleCollection_0.m_tx, this.formattingStyleCollection_0.m_strStyleNames[this.int_0]);
						}
					}
					return null;
				}
			}

			public FormattingStyleEnumerator(FormattingStyleCollection formattingStyleCollection_1)
			{
				this.formattingStyleCollection_0 = formattingStyleCollection_1;
				this.Reset();
			}

			public bool MoveNext()
			{
				if (this.int_0 == this.formattingStyleCollection_0.m_iCount - 1)
				{
					return false;
				}
				this.int_0++;
				return true;
			}

			public void Reset()
			{
				this.int_0 = -1;
			}
		}

		private int m_iCount;

		private Enum58 m_iType;

		internal TextControlCore m_tx;

		internal string[] m_strStyleNames;

		int ICollection.Count => this.m_iCount;

		/// <summary>Gets the number of elements contained in the collection.</summary>
		public int Count => this.m_iCount;

		bool ICollection.IsSynchronized => false;

		object ICollection.SyncRoot => this;

		internal FormattingStyleCollection(TextControlCore textControlCore_0, Enum58 iType)
		{
			this.m_tx = textControlCore_0;
			this.m_iType = iType;
			if (this.m_tx == null)
			{
				return;
			}
			this.m_iCount = this.m_tx.method_29(TextPart.Auto, 1315, (this.m_iType != Enum58.const_0) ? 1 : 2, 0);
			if (0 >= this.m_iCount)
			{
				return;
			}
			this.m_strStyleNames = new string[this.m_iCount];
			IntPtr intPtr = this.m_tx.method_66(Enum83.const_182, (this.m_iType != Enum58.const_0) ? 1u : 2u, 0);
			IntPtr ptr = Class429.GlobalLock(intPtr);
			int num = 0;
			for (int i = 0; i < this.m_iCount; i++)
			{
				string text = string.Empty;
				char c;
				do
				{
					c = (char)Marshal.ReadInt16(ptr, num);
					if (c != 0)
					{
						text += c;
					}
					num += 2;
				}
				while (c != 0);
				if (text.Length != 0)
				{
					this.m_strStyleNames[i] = text;
				}
			}
			Class429.GlobalUnlock(intPtr);
			Marshal.FreeHGlobal(intPtr);
		}

		void ICollection.CopyTo(Array array, int index)
		{
			this.CopyTo(array, index);
		}

		public abstract void CopyTo(Array array, int index);

		/// <summary>Removes a formatting style from a Text Control document.</summary>
		/// <param name="styleName">Specifies the name of the style to remove.</param>
		public bool Remove(string styleName)
		{
			if (this.m_strStyleNames != null)
			{
				string[] strStyleNames = this.m_strStyleNames;
				foreach (string text in strStyleNames)
				{
					if (text == styleName)
					{
						return this.m_tx.method_39(Enum83.const_190, 0, styleName).ToInt32() != 0;
					}
				}
			}
			return false;
		}

		/// <summary>Returns an enumerator that can be used to iterate through the collection.</summary>
		public FormattingStyleEnumerator GetEnumerator()
		{
			return new FormattingStyleEnumerator(this);
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return new FormattingStyleEnumerator(this);
		}
	}
}
