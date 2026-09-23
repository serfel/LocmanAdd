using System;
using ns21;

namespace TXTextControl
{
	/// <summary>The FormFieldCollection contains all form fields in a Text Control document or part of the document.</summary>
	public sealed class FormFieldCollection : TextFieldCollectionBase
	{
		/// <summary>Gets a collection of all conditional instructions that references to the form fields of the collection.</summary>
		public ConditionalInstructionCollection ConditionalInstructions
		{
			get
			{
				if (base.m_tx != null && base.m_tx.isHandleCreated)
				{
					IConditionalInstructionsManager conditionalInstructionsManager = base.m_tx.GetTextControl().GetConditionalInstructionsManager();
					conditionalInstructionsManager = ((conditionalInstructionsManager == null || !conditionalInstructionsManager.IsFormFieldValidationEnabled) ? null : conditionalInstructionsManager);
					return new ConditionalInstructionCollection(conditionalInstructionsManager, base.m_iTextPart, this);
				}
				return null;
			}
		}

		public FormField this[int number]
		{
			get
			{
				int int_ = base.m_tx.method_29(base.m_iTextPart, 2006, number, (int)(base.m_iEnumType | Enum106.const_3));
				int num = Class429.smethod_5(int_);
				if (num != 0)
				{
					return (FormField)TextFieldCollectionBase.CreateTextField(base.m_tx, base.m_iTextPart, num, (Enum105)Class429.smethod_6(int_));
				}
				return null;
			}
		}

		internal FormFieldCollection(TextControlCore textControlCore_0, TextPart iTextPart)
			: base(textControlCore_0, Enum106.const_18, iTextPart)
		{
		}

		/// <summary>Copies the elements of the collection to an array, starting at a particular index.</summary>
		/// <param name="array">Specifies the array to copy to.</param>
		/// <param name="index">Specifies the index of the destination array at which to begin copying.</param>
		public override void CopyTo(Array array, int index)
		{
			FormFieldCollection formFieldCollection = new FormFieldCollection(base.m_tx, base.m_iTextPart);
			foreach (FormField item in formFieldCollection)
			{
				array.SetValue(item, index++);
			}
		}

		/// <summary>Inserts the specified form field at the current input position.</summary>
		/// <param name="formField">Specifies the form field to add.</param>
		public bool Add(FormField formField)
		{
			return formField.method_1(base.m_tx, base.m_iTextPart);
		}

		/// <summary>Removes all form fields from a Text Control document.</summary>
		public void Clear()
		{
			base.DeleteAllFields(keepText: false);
		}

		/// <summary>Removes the specified form field from a Text Control document.</summary>
		/// <param name="formField">Specifies the formr field to remove.</param>
		public bool Remove(FormField formField)
		{
			return formField.method_2(bool_9: false);
		}

		/// <summary>Gets the form field at the current input position or null if there is no form field at the current input position.</summary>
		public FormField GetItem()
		{
			int int_ = base.m_tx.method_29(base.m_iTextPart, 1218, 0, (int)(base.m_iEnumType | Enum106.const_3));
			int num = Class429.smethod_5(int_);
			if (num != 0)
			{
				return (FormField)TextFieldCollectionBase.CreateTextField(base.m_tx, base.m_iTextPart, num, (Enum105)Class429.smethod_6(int_));
			}
			return null;
		}

		/// <summary>Gets the form field with the specified id, previously set with the FormField.ID property.</summary>
		/// <param name="id">Specifies the form field's identifier.</param>
		public FormField GetItem(int int_0)
		{
			foreach (FormField item in this)
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
