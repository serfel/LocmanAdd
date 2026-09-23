namespace TXTextControl
{
	/// <summary>Determines values for the control characters used in a TextControl document.</summary>
	public enum ControlChars
	{
		/// <summary>Defines the end of a paragraph (Keyboard: ENTER).</summary>
		ParagraphEnd = 10,
		/// <summary>Defines a line break without beginning a new paragraph (Keyboard: SHIFT+ENTER).</summary>
		LineBreak = 11,
		/// <summary>Defines a page break (Keyboard: CTRL+ENTER).</summary>
		PageBreak = 12,
		/// <summary>Defines a page column break (Keyboard: CTRL+SHIFT+ENTER).</summary>
		ColumnBreak = 14,
		/// <summary>Defines a tabulator (Keyboard: TAB).</summary>
		Tab = 9,
		/// <summary>Defines a non-breaking space (Keyboard: CTRL+SHIFT+Space).</summary>
		NonBreakingSpace = 160,
		/// <summary>Defines a non-visible hyphen (Keyboard: CTRL+(-)).</summary>
		NonVisibleHyphen = 0x1F
	}
}
