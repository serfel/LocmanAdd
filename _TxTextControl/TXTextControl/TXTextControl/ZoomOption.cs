namespace TXTextControl
{
	/// <summary>Specifies options how to set the zoom factor of a TextControl.</summary>
	public enum ZoomOption
	{
		/// <summary>The zoom factor is calculated so that the current visible page becomes completely visible.</summary>
		WholePage = 1,
		/// <summary>The zoom factor is calculated so that the complete width of a page becomes visible.</summary>
		PageWidth,
		/// <summary>The zoom factor is calculated so that the complete text of a line becomes visible.</summary>
		TextWidth
	}
}
