using System;

namespace TXTextControl
{
	/// <summary>Determines a certain text format.</summary>
	[Flags]
	public enum StreamType
	{
		/// <summary>Specifies text in Windows ANSI format (an end of a paragraph is marked with the control characters 13 and 10).</summary>
		PlainAnsiText = 0x1,
		/// <summary>Specifies the Text Control format. Text is stored in ANSI format.</summary>
		InternalFormat = 0x2,
		/// <summary>Specifies HTML format (Hypertext Markup Language).</summary>
		HTMLFormat = 0x4,
		/// <summary>Specifies RTF format (Rich Text Format).</summary>
		RichTextFormat = 0x8,
		/// <summary>Specifies text in Windows Unicode format (an end of a paragraph is marked with the control characters 13 and 10).</summary>
		PlainText = 0x10,
		/// <summary>Specifies the Text Control format. Text is stored in Unicode format.</summary>
		InternalUnicodeFormat = 0x20,
		/// <summary>Specifies Microsoft Word format (.DOC version).</summary>
		MSWord = 0x40,
		/// <summary>Specifies XML format (Extensible Markup Language).</summary>
		XMLFormat = 0x80,
		/// <summary>Specifies CSS format (Cascading Style Sheet). This format can only be used in saving operations.</summary>
		CascadingStylesheet = 0x100,
		/// <summary>Specifies Adobe Portable Document Format (PDF). How a PDF document is loaded depends on the LoadSettings.PDFImportSettings property. Only a complete document can be saved with this format.</summary>
		AdobePDF = 0x200,
		/// <summary>Specifies Microsoft Word format (Office Open XML version).</summary>
		WordprocessingML = 0x400,
		/// <summary>Specifies Adobe Portable Document Format Archive (PDF/A). This format can only be used in saving operations and only a complete document can be saved with this format.</summary>
		AdobePDFA = 0x800,
		/// <summary>Specifies Microsoft Excel format (Office Open XML version).</summary>
		SpreadsheetML = 0x1000,
		All = 0x1FFF
	}
}
