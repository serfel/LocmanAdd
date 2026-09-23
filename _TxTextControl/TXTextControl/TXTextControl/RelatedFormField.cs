using System.Reflection;

namespace TXTextControl
{
	[Obfuscation(Exclude = true)]
	internal class RelatedFormField
	{
		private FormField formField_0;

		private FormFieldType formFieldType_0;

		private int int_0;

		internal FormField FormField_0
		{
			get
			{
				return this.formField_0;
			}
			set
			{
				if (this.formField_0 != (this.formField_0 = value))
				{
					this.formFieldType_0 = this.method_0(this.formField_0);
					this.int_0 = this.formField_0.GetHashCode();
				}
			}
		}

		internal int Int32_0 => this.int_0;

		internal FormFieldType FormFieldType_0
		{
			get
			{
				return this.formFieldType_0;
			}
			set
			{
				this.formFieldType_0 = value;
			}
		}

		private FormFieldType method_0(FormField formField_1)
		{
			FormFieldType formFieldType = FormFieldType.Undefined;
			if (formField_1 is SelectionFormField)
			{
				SelectionFormField selectionFormField = formField_1 as SelectionFormField;
				return selectionFormField.Editable ? FormFieldType.ComboBoxFormField : FormFieldType.DropDownListFormField;
			}
			if (formField_1 is CheckFormField)
			{
				return FormFieldType.CheckBoxFormField;
			}
			return (formField_1 is TextFormField) ? FormFieldType.TextFormField : FormFieldType.DateFormField;
		}
	}
}
