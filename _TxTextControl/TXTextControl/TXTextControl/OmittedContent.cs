namespace TXTextControl
{
	public enum OmittedContent
	{
		None = 0,
		SubTextParts = 0x10000,
		TrackedChanges = 0x20000,
		EditableRegions = 0x40000,
		Sections = 0x80000,
		TextFields = 0x100000,
		TablesOfContents = 0x200000
	}
}
