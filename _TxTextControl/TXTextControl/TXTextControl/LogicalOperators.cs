using System.Reflection;

namespace TXTextControl
{
	[Obfuscation(Exclude = true)]
	internal enum LogicalOperators
	{
		Undefined,
		EqualsTo,
		DoesNotEqualTo,
		Contains,
		StartsWith,
		EndsWith,
		DoesNotContain,
		DoesNotStartWith,
		DoesNotEndWith,
		IsGreaterThan,
		IsGreaterThanOrEqual,
		IsLessThan,
		IsLessThanOrEqual,
		MatchesRegex,
		DoesNotMatchRegex
	}
}
