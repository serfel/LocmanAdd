using TXTextControl;

namespace TX_Text_Control_Words.FileHandling
{
	public static class Extensions
	{
		public static StreamType ToTXStreamType(this string fileExt)
		{
			switch (fileExt.ToLower())
			{
			case ".rtf":
				return StreamType.RichTextFormat;
			case ".htm":
			case ".html":
				return StreamType.HTMLFormat;
			case ".tx":
				return StreamType.InternalUnicodeFormat;
			case ".doc":
				return StreamType.MSWord;
			case ".docx":
				return StreamType.WordprocessingML;
			case ".pdf":
				return StreamType.AdobePDF;
			case ".txt":
				return StreamType.PlainText;
			case ".xlsx":
				return StreamType.SpreadsheetML;
			default:
				return (StreamType)(-1);
			}
		}
	}
}
