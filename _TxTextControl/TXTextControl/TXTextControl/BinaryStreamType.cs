using System;

namespace TXTextControl
{
	/// <summary>Determines a certain text format that must tbe stored in a one-dimensional byte array.</summary>
	[Flags]
	public enum BinaryStreamType
	{
		/// <summary>Specifies the Text Control format. Text is stored in ANSI format.</summary>
		InternalFormat = 0x2,
		/// <summary>Specifies the Text Control format. Text is stored in Unicode format.</summary>
		InternalUnicodeFormat = 0x20,
		/// <summary>Specifies Microsoft Word format.</summary>
		MSWord = 0x40,
		/// <summary>Specifies Adobe Portable Document Format (PDF). How a PDF document is loaded depends on the LoadSettings.PDFImportSettings property. Only a complete document can be saved with this format.</summary>
		AdobePDF = 0x200,
		/// <summary>Specifies Microsoft Word format (Office Open XML version).</summary>
		WordprocessingML = 0x400,
		/// <summary>Specifies Adobe Portable Document Format Archive (PDF/A). This format can only be used in saving operations and only a complete document can be saved with this format.</summary>
		AdobePDFA = 0x800,
		/// <summary>Specifies Microsoft Excel format (Office Open XML version).</summary>
		SpreadsheetML = 0x1000
	}
}
