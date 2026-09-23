namespace TXTextControl
{
	/// <summary>Specifies the kind of a bulleted or numbered list.</summary>
	public enum ListType
	{
		/// <summary>The text is neither a bulleted nor a numbered list.</summary>
		None = 1,
		/// <summary>The list is a bulleted list.</summary>
		Bulleted = 2,
		/// <summary>The list is a numbered list.</summary>
		Numbered = 4,
		/// <summary>The list is a structured list. All numbers of higher levels (lower level numbers) are displayed in front of the list number. The additional text of all levels in front and behind the list numbers is also displayed.</summary>
		Structured = 8
	}
}
