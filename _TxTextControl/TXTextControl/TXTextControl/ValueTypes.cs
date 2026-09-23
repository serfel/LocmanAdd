using System.Reflection;

namespace TXTextControl
{
	[Obfuscation(Exclude = true)]
	internal enum ValueTypes
	{
		Undefined,
		Checked,
		Unchecked,
		Selected,
		Deselected,
		EmptyValue,
		SpecificItem,
		AnyItem,
		CustomValue,
		Date,
		Year,
		Month,
		DayOfMonth,
		DayOfWeek
	}
}
