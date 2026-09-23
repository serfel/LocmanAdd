using System;

namespace TXTextControl
{
	/// <summary>Specifies how the document structure is generated when a PDF document is imported.</summary>
	[Flags]
	public enum PDFImportSettings
	{
		/// <summary>Text only,images and paragraph formatting are discarded. This option is best suited for searching PDF files.</summary>
		GenerateLines = 0x1,
		/// <summary>Generates paragraphs from the text flow. Images are discarded.</summary>
		GenerateParagraphs = 0x2,
		/// <summary>Default. Uses tables, images and text frames to create a document that best matches the original document's appearance.</summary>
		GenerateTextFrames = 0x4,
		/// <summary>Obsolete. This setting will be removed in a future version. Use LoadEmbeddedData instead.</summary>
		[Obsolete]
		GenerateXML = 0x8,
		/// <summary>Default. Files embedded in the PDF document are loaded and provided through the LoadSettings.EmbeddedFiles property.</summary>
		LoadEmbeddedFiles = 0x10,
		/// <summary>Provides the PDF document's metadata, form fields and text coordinates through the LoadSettings.EmbeddedData property.</summary>
		LoadEmbeddedData = 0x20,
		/// <summary>Same as GenerateTextFrames, but only the first page is loaded. Can be used for previewing the document.</summary>
		GenerateTextFramesFirstPageOnly = 0x80
	}
}
