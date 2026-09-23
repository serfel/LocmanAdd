using System;

namespace TXTextControl
{
	/// <summary>Specifies the format of additionally provided data when a PDF document is imported.</summary>
	[Flags]
	public enum EmbeddedDataFormat
	{
		/// <summary>Specifies an XML format where each line of text has attributes such as page number and geometrical position.</summary>
		TextCoordinates = 0x1,
		/// <summary>Specifies an XML format with information about the position and the kind of all form fields contained in the PDF document.</summary>
		FormFields = 0x2,
		/// <summary>Specifies the PDF document's metadata.</summary>
		MetaData = 0x4
	}
}
