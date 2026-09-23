using System;
using ns21;

namespace TXTextControl
{
	/// <summary>An instance of the ApplicationFieldCollection class contains all created or imported Microsoft Word or Heiler HighEdit fields represented through objects of the type ApplicationField.</summary>
	public sealed class ApplicationFieldCollection : TextFieldCollectionBase
	{
		public ApplicationField this[int number]
		{
			get
			{
				int int_ = base.m_tx.method_29(base.m_iTextPart, 2006, number, 98312);
				int num = Class429.smethod_5(int_);
				if (num == 0)
				{
					return null;
				}
				return new ApplicationField(base.m_tx, base.m_iTextPart, num, (Enum105)Class429.smethod_6(int_));
			}
		}

		internal ApplicationFieldCollection(TextControlCore textControlCore_0, TextPart iTextPart)
			: base(textControlCore_0, (Enum106)98304, iTextPart)
		{
		}

		/// <summary>Copies the elements of the collection to an array, starting at a particular index.</summary>
		/// <param name="array">Specifies the array to copy to.</param>
		/// <param name="index">Specifies the index of the destination array at which to begin copying.</param>
		public override void CopyTo(Array array, int index)
		{
			ApplicationFieldCollection applicationFieldCollection = new ApplicationFieldCollection(base.m_tx, base.m_iTextPart);
			foreach (ApplicationField item in applicationFieldCollection)
			{
				array.SetValue(item, index++);
			}
		}

		/// <summary>Inserts a new object of the type ApplicationField at the current input position.</summary>
		/// <param name="applicationField">Specifies the field to add.</param>
		public bool Add(ApplicationField applicationField)
		{
			return applicationField.method_1(base.m_tx, base.m_iTextPart);
		}

		/// <summary>Removes all fields of the type ApplicationField from a TX Text Control document.</summary>
		/// <param name="keepText">If this parameter is set to true, all fields are removed without deleting their visible text.</param>
		public void Clear(bool keepText)
		{
			base.DeleteAllFields(keepText);
		}

		/// <summary>Removes a field of the type ApplicationField including its visible text from a TX Text Control document.</summary>
		/// <param name="applicationField">Specifies the field to remove.</param>
		public bool Remove(ApplicationField applicationField)
		{
			return applicationField.method_2(bool_9: false);
		}

		/// <summary>Removes a field of the type ApplicationField from a TX Text Control document. The visible text is deleted depending on the keepText parameter.</summary>
		/// <param name="applicationField">Specifies the field to remove.</param>
		/// <param name="keepText">If this parameter is set to true, the field is removed without deleting its visible text.</param>
		public bool Remove(ApplicationField applicationField, bool keepText)
		{
			return applicationField.method_2(keepText);
		}

		/// <summary>Gets the field at the current input position or null, if there is no such field at the current input position.</summary>
		public ApplicationField GetItem()
		{
			int int_ = base.m_tx.method_29(base.m_iTextPart, 1218, 0, 98312);
			int num = Class429.smethod_5(int_);
			if (num == 0)
			{
				return null;
			}
			return new ApplicationField(base.m_tx, base.m_iTextPart, num, (Enum105)Class429.smethod_6(int_));
		}

		/// <summary>Gets the field with the specified id, previously set with the ID property.</summary>
		/// <param name="id">Specifies the field's identifier set with the ID property.</param>
		public ApplicationField GetItem(int int_0)
		{
			foreach (ApplicationField item in this)
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
