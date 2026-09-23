using System.Reflection;

namespace TXTextControl
{
	[Obfuscation(Exclude = true)]
	internal enum FormFieldType
	{
		Undefined,
		CheckBoxFormField,
		TextFormField,
		DropDownListFormField,
		ComboBoxFormField,
		DateFormField
	}
}
