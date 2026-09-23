using System;
using System.Collections;
using ns21;

namespace TXTextControl
{
	/// <summary>The TextFieldCollectionBase class is the base class of the TextFieldCollection, HypertextLinkCollection, DocumentLinkCollection, PageNumberFieldCollection, ApplicationFieldCollection and FormFieldCollection classes.</summary>
	public abstract class TextFieldCollectionBase : ICollection, IEnumerable
	{
		public class TextFieldEnumerator : IEnumerator
		{
			private int int_0 = -1;

			private int int_1;

			private Enum105 enum105_0 = Enum105.const_12;

			private TextFieldCollectionBase textFieldCollectionBase_0;

			public object Current => TextFieldCollectionBase.CreateTextField(this.textFieldCollectionBase_0.m_tx, this.textFieldCollectionBase_0.m_iTextPart, this.int_1, this.enum105_0);

			public TextFieldEnumerator(TextFieldCollectionBase textFieldCollectionBase_1)
			{
				this.textFieldCollectionBase_0 = textFieldCollectionBase_1;
			}

			public bool MoveNext()
			{
				int int_ = this.textFieldCollectionBase_0.m_tx.method_29(this.textFieldCollectionBase_0.m_iTextPart, 1232, this.int_1, (int)(this.textFieldCollectionBase_0.m_iEnumType | Enum106.const_3));
				this.int_1 = Class429.smethod_5(int_);
				this.enum105_0 = (Enum105)Class429.smethod_6(int_);
				if (this.int_1 != 0)
				{
					this.int_0++;
					return true;
				}
				return false;
			}

			public void Reset()
			{
				this.int_0 = -1;
				this.int_1 = 0;
				this.enum105_0 = Enum105.const_12;
			}
		}

		internal TextControlCore m_tx;

		internal TextPart m_iTextPart;

		internal Enum106 m_iEnumType;

		/// <summary>Gets a value indicating whether a new text field can be inserted at the current input position.</summary>
		public bool CanAdd => 0 == this.m_tx.method_29(this.m_iTextPart, 1218, 0, 0);

		int ICollection.Count => this.Count;

		/// <summary>Gets the number of elements contained in the collection.</summary>
		public int Count
		{
			get
			{
				int num = -1;
				int num2 = 0;
				do
				{
					num++;
					num2 = this.m_tx.method_29(this.m_iTextPart, 1232, num2, (int)this.m_iEnumType);
				}
				while (num2 != 0);
				return num;
			}
		}

		bool ICollection.IsSynchronized => false;

		object ICollection.SyncRoot => this;

		internal TextFieldCollectionBase(TextControlCore textControlCore_0, Enum106 iType, TextPart iTextPart)
		{
			this.m_tx = textControlCore_0;
			this.m_iEnumType = iType;
			this.m_iTextPart = iTextPart;
		}

		void ICollection.CopyTo(Array array, int index)
		{
			this.CopyTo(array, index);
		}

		public abstract void CopyTo(Array array, int index);

		/// <summary>Returns an enumerator that can be used to iterate through the collection.</summary>
		public TextFieldEnumerator GetEnumerator()
		{
			return new TextFieldEnumerator(this);
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return new TextFieldEnumerator(this);
		}

		internal void DeleteAllFields(bool keepText)
		{
			int num = 0;
			this.m_tx.method_19(this.m_iTextPart, null);
			do
			{
				num = this.m_tx.method_29(this.m_iTextPart, 1232, 0, (int)this.m_iEnumType);
				if (num != 0)
				{
					this.m_tx.method_29(this.m_iTextPart, 1231, num, (!keepText) ? 1 : 0);
				}
			}
			while (num != 0);
			this.m_tx.method_20(this.m_iTextPart);
		}

		internal static TextField CreateTextField(TextControlCore textControlCore_0, TextPart iTextPart, int iFieldID, Enum105 iFieldType)
		{
			switch (iFieldType)
			{
			case Enum105.const_0:
				return new TextField(textControlCore_0, iTextPart, iFieldID);
			case Enum105.const_1:
				return new HypertextLink(textControlCore_0, iTextPart, iFieldID);
			case Enum105.const_2:
				return new DocumentLink(textControlCore_0, iTextPart, iFieldID);
			case Enum105.const_4:
				return null;
			case Enum105.const_5:
			case Enum105.const_6:
				return new ApplicationField(textControlCore_0, iTextPart, iFieldID, iFieldType);
			case Enum105.const_3:
			case Enum105.const_7:
				return new PageNumberField(textControlCore_0, iTextPart, iFieldID, iFieldType);
			default:
				return null;
			case Enum105.const_8:
				return new CheckFormField(textControlCore_0, iTextPart, iFieldID);
			case Enum105.const_9:
				return new SelectionFormField(textControlCore_0, iTextPart, iFieldID);
			case Enum105.const_10:
				return new TextFormField(textControlCore_0, iTextPart, iFieldID);
			case Enum105.const_11:
				return new DateFormField(textControlCore_0, iTextPart, iFieldID);
			}
		}
	}
}
