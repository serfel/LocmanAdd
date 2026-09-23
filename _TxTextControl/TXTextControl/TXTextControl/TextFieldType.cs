using System;

namespace TXTextControl
{
	/// <summary>Specifies types of text fields.</summary>
	[Flags]
	public enum TextFieldType
	{
		/// <summary>The field type is HypertextLink.</summary>
		HypertextLink = 0x200,
		/// <summary>The field type is DocumentLink.</summary>
		DocumentLink = 0x400,
		/// <summary>The field type is PageNumberField.</summary>
		PageNumberField = 0x20800,
		/// <summary>The field type is TextField.</summary>
		TextField = 0x4000,
		/// <summary>The field type is ApplicationField.</summary>
		ApplicationField = 0x18000,
		/// <summary>The field type is CheckFormField.</summary>
		CheckFormField = 0x40000,
		/// <summary>The field type is SelectionFormField.</summary>
		SelectionFormField = 0x80000,
		/// <summary>The field type is TextFormField.</summary>
		TextFormField = 0x100000,
		/// <summary>The field type is DateFormField.</summary>
		DateFormField = 0x200000,
		/// <summary>Specifies all types of FormFields.</summary>
		FormFields = 0x3C0000,
		/// <summary>Specifies all types of text fields.</summary>
		All = 0x3FCF00
	}
}
