using System;

namespace TXTextControl
{
	[Flags]
	public enum DocumentAccessPermissions
	{
		None = 0x0,
		AllowAll = 0xFF,
		AllowAuthoring = 0x1,
		AllowAuthoringFields = 0x2,
		AllowContentAccessibility = 0x4,
		AllowDocumentAssembly = 0x8,
		AllowExtractContents = 0x10,
		AllowGeneralEditing = 0x20,
		AllowHighLevelPrinting = 0x40,
		AllowLowLevelPrinting = 0x80
	}
}
