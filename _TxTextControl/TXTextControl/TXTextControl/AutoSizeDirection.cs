namespace TXTextControl
{
	/// <summary>Determines values for the AutoSize.AutoExpand and AutoSize.AutoShrink properties.</summary>
	public enum AutoSizeDirection
	{
		/// <summary>The control does not shrink automatically.</summary>
		None = 1,
		/// <summary>The control automatically shrinks vertically.</summary>
		Vertical,
		/// <summary>The control automatically shrinks horizontally.</summary>
		Horizontal,
		/// <summary>The control automatically shrinks in both directions.</summary>
		Both
	}
}
