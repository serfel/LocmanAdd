namespace TXTextControl
{
	/// <summary>Specifies how the z-order of a frame (image, text frame, chart, barcode or drawing) can be changed.</summary>
	public enum ZOrder
	{
		/// <summary>The frame is moved in front of the text at the top of all other objects.</summary>
		TopMost = int.MaxValue,
		/// <summary>If the frame is behind the text, it becomes the topmost of all objects behind the text. If it is in front of the text, it becomes the topmost of all objects.</summary>
		Top = 2147483646,
		const_2 = 2147483645,
		/// <summary>The frame is moved behind the text below all other objects. This member is only possible, if the insertion mode is BehindTheText.</summary>
		BottomMost = int.MinValue,
		/// <summary>If the frame is in front of the text, it becomes the bottommost of all objects in front of the text. If it is behind the text, it is becomes the bottommost of all objects.</summary>
		Bottom = -2147483647,
		/// <summary>The frame is moved down one plane. If it is the bottommost object in front of the text, it is not moved behind the text.</summary>
		Down = -2147483646
	}
}
