using System;
using ns21;

namespace TXTextControl
{
	/// <summary>An instance of the TextFieldCollection class contains all standard text fields in a Text Control document or part of the document represented through objects of the type TextField.</summary>
	public sealed class TextFieldCollection : TextFieldCollectionBase
	{
		public TextField this[int number]
		{
			get
			{
				int int_ = base.m_tx.method_29(base.m_iTextPart, 2006, number, (int)(base.m_iEnumType | Enum106.const_3));
				int num = Class429.smethod_5(int_);
				if (num != 0)
				{
					return TextFieldCollectionBase.CreateTextField(base.m_tx, base.m_iTextPart, num, (Enum105)Class429.smethod_6(int_));
				}
				return null;
			}
		}

		internal TextFieldCollection(TextControlCore textControlCore_0, TextPart iTextPart)
			: base(textControlCore_0, Enum106.const_10, iTextPart)
		{
		}

		internal TextFieldCollection(TextControlCore textControlCore_0, TextPart iTextPart, Enum106 iEnumType)
			: base(textControlCore_0, iEnumType, iTextPart)
		{
		}

		/// <summary>Copies the elements of the collection to an array, starting at a particular index.</summary>
		/// <param name="array">Specifies the array to copy to.</param>
		/// <param name="index">Specifies the index of the destination array at which to begin copying.</param>
		public override void CopyTo(Array array, int index)
		{
			TextFieldCollection textFieldCollection = new TextFieldCollection(base.m_tx, base.m_iTextPart);
			foreach (TextField item in textFieldCollection)
			{
				array.SetValue(item, index++);
			}
		}

		/// <summary>Inserts a new standard text field at the current input position.</summary>
		/// <param name="textField">Specifies the text field to add.</param>
		public bool Add(TextField textField)
		{
			return textField.method_1(base.m_tx, base.m_iTextPart);
		}

		/// <summary>Removes all text fields from a Text Control document.</summary>
		/// <param name="keepText">If this parameter is set to true, all text fields are removed without deleting their texts.</param>
		public void Clear(bool keepText)
		{
			base.DeleteAllFields(keepText);
		}

		/// <summary>Removes the specified text field from the Text Control document.</summary>
		/// <param name="textField">Specifies the text field to remove.</param>
		public bool Remove(TextField textField)
		{
			return textField.method_2(bool_9: false);
		}

		/// <summary>Removes the specified text field from the Text Control document. The field's visible text remains in the document, when the keepText parameter is set to true.</summary>
		/// <param name="textField">Specifies the text field to remove.</param>
		/// <param name="keepText">If this parameter is set to true, the field is removed without deleting its text.</param>
		public bool Remove(TextField textField, bool keepText)
		{
			return textField.method_2(keepText);
		}

		/// <summary>Gets the text field at the current text input position or null, if there is no text field at the current text input position.</summary>
		public TextField GetItem()
		{
			int int_ = base.m_tx.method_29(base.m_iTextPart, 1218, 0, (int)(base.m_iEnumType | Enum106.const_3));
			int num = Class429.smethod_5(int_);
			if (num != 0)
			{
				return TextFieldCollectionBase.CreateTextField(base.m_tx, base.m_iTextPart, num, (Enum105)Class429.smethod_6(int_));
			}
			return null;
		}

		/// <summary>Gets the text field with the specified id, previously set with the ID property.</summary>
		/// <param name="id">Specifies the text field's identifier set with the ID property.</param>
		public TextField GetItem(int int_0)
		{
			foreach (TextField item in this)
			{
				if (item.Int32_0 == int_0)
				{
					return item;
				}
			}
			return null;
		}
	}
}
