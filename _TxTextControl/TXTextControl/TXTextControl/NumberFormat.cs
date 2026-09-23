using System.ComponentModel;
using ns21;

namespace TXTextControl
{
	/// <summary>Specifies the format of a numbered list.</summary>
	[TypeConverter(typeof(Class422))]
	public enum NumFormat
	{
		/// <summary>A text selection contains different number formats.</summary>
		None = 0,
		/// <summary>The list is numbered with Arabic numbers (1, 2, 3...).</summary>
		ArabicNumbers = 3,
		/// <summary>The list is numbered with letters (a, b, c...).</summary>
		Letters = 4,
		/// <summary>The list is numbered with capital letters (A, B, C...).</summary>
		CapitalLetters = 5,
		/// <summary>The list is numbered with Roman numbers (I, II, III...).</summary>
		RomanNumbers = 6,
		/// <summary>The list is numbered with small Roman numbers (i, ii, iii...).</summary>
		SmallRomanNumbers = 7
	}
}
