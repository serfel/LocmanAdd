namespace TXTextControl
{
	/// <summary>Determines a certain clipboard format that can be pasted into a TextControl document.</summary>
	public enum ClipboardFormat
	{
		/// <summary>Specifies formatted text in the internal TX Text Control format.</summary>
		TXTextControlFormat = 2,
		/// <summary>Specifies RTF format (Rich Text Format).</summary>
		RichTextFormat = 3,
		/// <summary>Specifies an image. An image can be pasted, if it is a device dependent or a device independent bitmap, a TIFF image or a Windows metafile.</summary>
		Image = 4,
		/// <summary>Specifies unformatted text.</summary>
		PlainText = 5,
		/// <summary>Specifies a TX Text Control textframe including its contents. The clipbord contains also information about how the textframe is positioned in the document (inline or geometrically positioned).</summary>
		TXTextControlTextframe = 7,
		/// <summary>Specifies an image including information about how the image is positioned in the document (inline or geometrically positioned).</summary>
		TXTextControlImage = 8,
		/// <summary>Specifies HTML format (Hypertext Markup Language).</summary>
		HTMLFormat = 9,
		/// <summary>Specifies a chart.</summary>
		Chart = 10,
		/// <summary>Specifies a barcode.</summary>
		Barcode = 11,
		Drawing = 12
	}
}
