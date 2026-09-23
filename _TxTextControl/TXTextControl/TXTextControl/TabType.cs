namespace TXTextControl
{
	/// <summary>Determines the tabulator type.</summary>
	public enum TabType
	{
		/// <summary>The tab position is at the left side of the text.</summary>
		LeftTab = 1,
		/// <summary>The tab position is at the right side of the text.</summary>
		RightTab,
		/// <summary>The text is centered to the tab position.</summary>
		CenterTab,
		/// <summary>The decimal sign is aligned at the tab position.</summary>
		DecimalTab,
		/// <summary>The tab is positioned right most and the text is diplayed at the left of this position. The tab position set with the TabPositions property is ignored. Only one tab of this kind is possible in a paragraph.</summary>
		RightBorderTab
	}
}
