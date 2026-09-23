using System;
using System.Collections;
using ns21;

namespace TXTextControl
{
	/// <summary>An instance of this class contains all elements of an XML document that have the same element name.</summary>
	public class XmlElementCollection : ICollection, IEnumerable
	{
		private TextControlCore textControlCore_0;

		private string string_0;

		internal int int_0;

		internal XmlElement[] xmlElement_0;

		/// <summary>Gets the number of XML elements in the collection.</summary>
		public virtual int Count => this.int_0;

		bool ICollection.IsSynchronized => false;

		object ICollection.SyncRoot => this;

		internal XmlElementCollection(TextControlCore textControlCore_1, string name)
		{
			this.textControlCore_0 = textControlCore_1;
			this.string_0 = name;
			this.method_0();
		}

		private void method_0()
		{
			this.method_1();
			Struct72 struct72_ = new Struct72(this.string_0, 0, null, 0, 0u);
			this.int_0 = (int)this.textControlCore_0.method_67(Enum83.const_199, 0, ref struct72_);
			if (this.int_0 > 0)
			{
				this.xmlElement_0 = new XmlElement[this.int_0];
			}
			for (int i = 0; i < this.int_0; i++)
			{
				this.xmlElement_0[i] = new XmlElement(this.textControlCore_0, this.string_0, i + 1, null, 0);
			}
		}

		private void method_1()
		{
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
			this.xmlElement_0.CopyTo(array, index);
		}

		internal XmlElement method_2(int int_1)
		{
			if (int_1 <= this.int_0 && int_1 > 0)
			{
				if (this.int_0 > 0)
				{
					return this.xmlElement_0[int_1 - 1];
				}
				return null;
			}
			throw new ArgumentOutOfRangeException("index");
		}

		/// <summary>Returns an enumerator that can be used to iterate through the collection.</summary>
		public virtual IEnumerator GetEnumerator()
		{
			return new Class430(this);
		}

		/// <summary>Returns the item with the current input position.</summary>
		public XmlElement GetItem()
		{
			int int_ = this.textControlCore_0.method_39(Enum83.const_201, 0, this.string_0).ToInt32();
			return this.method_2(int_);
		}

		/// <summary>Returns the item with the specified index.</summary>
		/// <param name="index">The one based index of the XmlElement.</param>
		public XmlElement GetItem(int index)
		{
			return this.method_2(index);
		}

		/// <summary>Adds the specified XML element to the collection.</summary>
		/// <param name="element">Specified an instance of the XmlElement object.</param>
		/// <param name="before">Specifies a relative position in the collection.</param>
		/// <param name="after">Specifies a relative position in the collection.</param>
		public bool Add(XmlElement element, int before, int after)
		{
			int int_ = 0;
			short num = 0;
			bool flag = false;
			if (this.textControlCore_0 != null)
			{
				if (before >= 0)
				{
					int_ = before;
					flag = true;
				}
				else if (after >= 0)
				{
					int_ = after;
				}
				ushort ushort_ = (ushort)(flag ? 1u : 2u);
				Struct72 struct72_ = new Struct72(this.string_0, int_, null, 0, 0u, ushort_);
				num = (short)this.textControlCore_0.method_68(Enum83.const_193, element.Text, ref struct72_);
				if (num == 2)
				{
					this.method_0();
				}
			}
			return num == 2;
		}

		/// <summary>Removes an XML element from an XML document.</summary>
		/// <param name="index">Specifies the one-based index of the XML element in the collection.</param>
		public bool Remove(int index)
		{
			short num = 0;
			int num2 = this.int_0;
			if (index >= 0 && index <= num2 && this.textControlCore_0 != null)
			{
				Struct72 struct72_ = new Struct72(this.string_0, index, null, 0, 0u);
				num = (short)(int)this.textControlCore_0.method_67(Enum83.const_194, 0, ref struct72_);
				if (num == 2)
				{
					this.method_0();
				}
			}
			return num == 2;
		}
	}
}
