using System.Reflection;

namespace TXTextControl
{
	[Obfuscation(Exclude = true)]
	internal enum Commands
	{
		Undefined,
		AllowFillIn,
		DenyFillIn,
		SetNewValue,
		SetNewItems,
		SetValueAsValid,
		SetValueAsInvalid
	}
}
