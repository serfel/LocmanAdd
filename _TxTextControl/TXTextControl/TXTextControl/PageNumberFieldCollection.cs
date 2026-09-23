using System;
using ns21;

namespace TXTextControl
{
	/// <summary>An instance of the PageNumberFieldCollection class contains the page number fields in a header or footer of a Text Control document.</summary>
	public sealed class PageNumberFieldCollection : TextFieldCollectionBase
	{
		public PageNumberField this[int number]
		{
			get
			{
				int int_ = base.m_tx.method_29(base.m_iTextPart, 2006, number, 133128);
				int num = Class429.smethod_5(int_);
				if (num == 0)
				{
					return null;
				}
				return new PageNumberField(base.m_tx, base.m_iTextPart, num, (Enum105)Class429.smethod_6(int_));
			}
		}

		internal PageNumberFieldCollection(TextControlCore textControlCore_0, TextPart iTextPart)
			: base(textControlCore_0, (Enum106)133120, iTextPart)
		{
		}

		/// <summary>Copies the elements of the collection to an array, starting at a particular index.</summary>
		/// <param name="array">Specifies the array to copy to.</param>
		/// <param name="index">Specifies the index of the destination array at which to begin copying.</param>
		public override void CopyTo(Array array, int index)
		{
			PageNumberFieldCollection pageNumberFieldCollection = new PageNumberFieldCollection(base.m_tx, base.m_iTextPart);
			foreach (PageNumberField item in pageNumberFieldCollection)
			{
				array.SetValue(item, index++);
			}
		}

		/// <summary>Inserts a new page number field at the current input position of a header or footer.</summary>
		/// <param name="pageNumberField">Specifies the page number field to add.</param>
		public bool Add(PageNumberField pageNumberField)
		{
			return pageNumberField.method_1(base.m_tx, base.m_iTextPart);
		}

		/// <summary>Removes all page number fields contained in the collection from the document.</summary>
		/// <param name="keepText">If this parameter is set to true, all page number fields are removed without deleting their texts.</param>
		public void Clear(bool keepText)
		{
			base.DeleteAllFields(keepText);
		}

		/// <summary>Removes a page number from a header or footer of a Text control document.</summary>
		/// <param name="pageNumberField">Specifies the page number field to remove.</param>
		public bool Remove(PageNumberField pageNumberField)
		{
			return pageNumberField.method_2(bool_9: false);
		}

		/// <summary>Gets the page number field at the current input position or null if there is no page number field at the current input position.</summary>
		public PageNumberField GetItem()
		{
			int int_ = base.m_tx.method_29(base.m_iTextPart, 1218, 0, 133128);
			int num = Class429.smethod_5(int_);
			if (num == 0)
			{
				return null;
			}
			return new PageNumberField(base.m_tx, base.m_iTextPart, num, (Enum105)Class429.smethod_6(int_));
		}

		/// <summary>Gets the page number field with the specified id. An id can be set with the PageNumberField.ID property.</summary>
		/// <param name="id">Specifies the page number field's identifier.</param>
		public PageNumberField GetItem(int int_0)
		{
			foreach (PageNumberField item in this)
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
