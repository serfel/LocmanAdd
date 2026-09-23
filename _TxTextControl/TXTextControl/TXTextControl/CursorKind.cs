namespace TXTextControl
{
	/// <summary>Determines the kind of the cursor at a certain location in a document.</summary>
	public enum CursorKind
	{
		/// <summary>The cursor is an I-beam.</summary>
		IBeam = 1,
		/// <summary>The cursor is an arrow cursor pointing to northeast.</summary>
		ArrowNE,
		/// <summary>The cursor is a vertical splitting cursor.</summary>
		VSplit,
		/// <summary>The cursor is an up arrow cursor.</summary>
		UpArrow,
		/// <summary>The cursor is a standard arrow cursor pointing to northwest.</summary>
		Arrow,
		/// <summary>The cursor is a down arrow cursor.</summary>
		DownArrow,
		/// <summary>The cursor is a two-headed horizontal (west/east) sizing cursor.</summary>
		SizeWE,
		/// <summary>The cursor is the two-headed vertical (north/south) sizing cursor.</summary>
		SizeNS,
		/// <summary>The cursor is the two-headed diagonal (northwest/southeast) sizing cursor.</summary>
		SizeNWSE,
		/// <summary>The cursor is the two-headed diagonal (northeast/southwest) sizing cursor.</summary>
		SizeNESW,
		/// <summary>The cursor is the four-headed sizing cursor, which consists of four joined arrows that point north, south, east, and west.</summary>
		SizeAll,
		/// <summary>The cursor is the crosshair cursor.</summary>
		Cross,
		const_12,
		/// <summary>The cursor is the standard cursor for copying data during a drag and drop operation.</summary>
		DragDropCopy,
		/// <summary>The cursor is the standard cursor for moving data during a drag and drop operation.</summary>
		DragDropMove,
		ThickCross,
		Hand
	}
}
