using TX_Text_Control_Words.Properties;
using TXTextControl;

namespace TX_Text_Control_Words
{
	public static class ReportingTabExtensions
	{
		public static string ToSmallImageResName(this string imageFileName)
		{
			return "Images.Small_32bit." + imageFileName;
		}

		public static string ToLargeImageResName(this string imageFileName)
		{
			return "Images.Large_32bit." + imageFileName;
		}

		public static StreamType ToTxStreamType(this string fileExt)
		{
			if (fileExt.StartsWith("."))
			{
				fileExt = fileExt.Substring(1);
			}
			switch (fileExt.ToLower())
			{
			case "pdf":
				return StreamType.AdobePDF;
			case "docx":
				return StreamType.WordprocessingML;
			case "htm":
			case "html":
				return StreamType.HTMLFormat;
			case "tx":
				return StreamType.InternalUnicodeFormat;
			case "doc":
				return StreamType.MSWord;
			case "rtf":
				return StreamType.RichTextFormat;
			case "txt":
			case "text":
				return StreamType.PlainText;
			default:
				return StreamType.WordprocessingML;
			}
		}

		public static string ToFilterString(this StreamType streamType)
		{
			switch (streamType)
			{
			case StreamType.AdobePDF:
			case StreamType.AdobePDFA:
				return Resources.APP_MENU_SAVE_AS_PDF + "|*.pdf";
			case StreamType.HTMLFormat:
				return Resources.APP_MENU_SAVE_AS_HTML + "|*.htm;*.html";
			case StreamType.InternalFormat:
			case StreamType.InternalUnicodeFormat:
				return Resources.APP_MENU_SAVE_AS_TX + "|*.tx";
			case StreamType.MSWord:
				return Resources.APP_MENU_SAVE_AS_DOC + "|*.doc";
			case StreamType.PlainAnsiText:
			case StreamType.PlainText:
				return Resources.APP_MENU_SAVE_AS_TXT + "|*.txt";
			case StreamType.RichTextFormat:
				return Resources.APP_MENU_SAVE_AS_RTF + "|*.rtf";
			case StreamType.WordprocessingML:
				return Resources.APP_MENU_SAVE_AS_DOCX + "|*.docx";
			default:
				return Resources.APP_MENU_SAVE_AS_DOCX + "|*.docx";
			}
		}

		public static string ToFileExt(this StreamType streamType)
		{
			switch (streamType)
			{
			case StreamType.AdobePDF:
			case StreamType.AdobePDFA:
				return ".pdf";
			case StreamType.HTMLFormat:
				return ".html";
			case StreamType.InternalFormat:
			case StreamType.InternalUnicodeFormat:
				return ".tx";
			case StreamType.MSWord:
				return ".doc";
			case StreamType.PlainAnsiText:
			case StreamType.PlainText:
				return ".txt";
			case StreamType.RichTextFormat:
				return ".rtf";
			case StreamType.WordprocessingML:
				return ".docx";
			case StreamType.XMLFormat:
				return ".xml";
			default:
				return "";
			}
		}
	}
}
