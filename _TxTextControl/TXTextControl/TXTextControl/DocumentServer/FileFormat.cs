namespace TXTextControl.DocumentServer
{
	/// <summary>Determines a certain text format.</summary>
	public enum FileFormat
	{
		/// <summary>Specifies Microsoft Word format.</summary>
		MSWord,
		/// <summary>Specifies RTF format (Rich Text Format).</summary>
		RichTextFormat,
		/// <summary>Specifies Microsoft Office Open XML format.</summary>
		WordprocessingML,
		/// <summary>Specifies the internal TX Text Control format. Text is stored in Unicode format.</summary>
		InternalUnicodeFormat
	}
}
