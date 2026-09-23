using System;

namespace TXTextControl
{
	/// <summary>Specifies the kind of a misspelled word.</summary>
	[Flags]
	public enum MisspelledWordKind
	{
		/// <summary>Specifies all misspelled words which do not have a special meaning.</summary>
		Normal = 0x1,
		/// <summary>Specifies all misspelled words which are marked as ignored.</summary>
		Ignored = 0x2,
		/// <summary>Specifies all misspelled words which are marked as duplicate.</summary>
		Duplicate = 0x4,
		/// <summary>Specifies all misspelled words.</summary>
		All = 0x7
	}
}
