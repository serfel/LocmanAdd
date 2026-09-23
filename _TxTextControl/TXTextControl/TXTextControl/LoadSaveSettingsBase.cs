using System;
using System.Resources;
using ns21;

namespace TXTextControl
{
	[Serializable]
	public abstract class LoadSaveSettingsBase
	{
		protected ResourceManager m_rm;

		protected internal string m_strDocumentBasePath = string.Empty;

		protected internal EmbeddedFile[] m_arEmbeddedFiles;

		protected internal string m_strMasterPassword = string.Empty;

		protected internal ReportingMergeBlockFormat m_iReportingMergeBlockFormat = ReportingMergeBlockFormat.Default;

		protected internal string m_strUserPassword = string.Empty;

		internal TextPart m_iTextPart;

		public string DocumentBasePath
		{
			get
			{
				return this.m_strDocumentBasePath;
			}
			set
			{
				this.m_strDocumentBasePath = value;
			}
		}

		public EmbeddedFile[] EmbeddedFiles
		{
			get
			{
				return this.m_arEmbeddedFiles;
			}
			set
			{
				this.m_arEmbeddedFiles = value;
			}
		}

		public string MasterPassword
		{
			get
			{
				return this.m_strMasterPassword;
			}
			set
			{
				this.m_strMasterPassword = value;
			}
		}

		public ReportingMergeBlockFormat ReportingMergeBlockFormat
		{
			get
			{
				return this.m_iReportingMergeBlockFormat;
			}
			set
			{
				this.m_iReportingMergeBlockFormat = value;
			}
		}

		public string UserPassword
		{
			get
			{
				return this.m_strUserPassword;
			}
			set
			{
				this.m_strUserPassword = value;
			}
		}

		internal TextPart TextPart
		{
			set
			{
				this.m_iTextPart = value;
			}
		}

		internal LoadSaveSettingsBase()
		{
			this.m_rm = new ResourceManager(typeof(TextControlCore));
		}

		internal string GetFilterString(StreamType iStreamType)
		{
			string text = "";
			switch (iStreamType)
			{
			case StreamType.InternalFormat:
				text = this.m_rm.GetString("FILEFORMAT_TX");
				break;
			case StreamType.InternalUnicodeFormat:
				text = this.m_rm.GetString("FILEFORMAT_TXU");
				break;
			default:
				if ((iStreamType & StreamType.RichTextFormat) != 0)
				{
					text += this.m_rm.GetString("FILEFORMAT_RTF");
				}
				if ((iStreamType & StreamType.HTMLFormat) != 0)
				{
					text += this.m_rm.GetString("FILEFORMAT_HTML");
				}
				if ((iStreamType & StreamType.WordprocessingML) != 0)
				{
					text += this.m_rm.GetString("FILEFORMAT_DOCX");
				}
				if ((iStreamType & StreamType.MSWord) != 0)
				{
					text += this.m_rm.GetString("FILEFORMAT_WORD");
				}
				if ((iStreamType & StreamType.XMLFormat) != 0)
				{
					text += this.m_rm.GetString("FILEFORMAT_XML");
				}
				if ((iStreamType & StreamType.CascadingStylesheet) != 0)
				{
					text += this.m_rm.GetString("FILEFORMAT_CSS");
				}
				if ((iStreamType & StreamType.AdobePDF) != 0)
				{
					text += this.m_rm.GetString("FILEFORMAT_PDF");
				}
				if ((iStreamType & StreamType.AdobePDFA) != 0)
				{
					text += this.m_rm.GetString("FILEFORMAT_PDFA");
				}
				if ((iStreamType & StreamType.SpreadsheetML) != 0)
				{
					text += this.m_rm.GetString("FILEFORMAT_XLSX");
				}
				if ((iStreamType & StreamType.PlainAnsiText) != 0)
				{
					text += this.m_rm.GetString("FILEFORMAT_TEXT");
				}
				if ((iStreamType & StreamType.PlainText) != 0)
				{
					text += this.m_rm.GetString("FILEFORMAT_UNICODE");
				}
				if ((iStreamType & StreamType.InternalUnicodeFormat) != 0)
				{
					text += this.m_rm.GetString("FILEFORMAT_TXU");
				}
				break;
			}
			if (text.Length > 1)
			{
				text = text.Remove(text.Length - 1, 1);
			}
			return text;
		}

		internal StreamType StreamTypeFromFilterIndex(int iFilterIndex, StreamType iStreamType)
		{
			StreamType result = StreamType.PlainAnsiText;
			int num = 0;
			switch (iStreamType)
			{
			case StreamType.InternalFormat:
				if (++num == iFilterIndex)
				{
					result = StreamType.InternalFormat;
				}
				break;
			case StreamType.InternalUnicodeFormat:
				if (++num == iFilterIndex)
				{
					result = StreamType.InternalUnicodeFormat;
				}
				break;
			default:
				if ((iStreamType & StreamType.RichTextFormat) != 0 && ++num == iFilterIndex)
				{
					result = StreamType.RichTextFormat;
				}
				if ((iStreamType & StreamType.HTMLFormat) != 0 && ++num == iFilterIndex)
				{
					result = StreamType.HTMLFormat;
				}
				if ((iStreamType & StreamType.WordprocessingML) != 0 && ++num == iFilterIndex)
				{
					result = StreamType.WordprocessingML;
				}
				if ((iStreamType & StreamType.MSWord) != 0 && ++num == iFilterIndex)
				{
					result = StreamType.MSWord;
				}
				if ((iStreamType & StreamType.XMLFormat) != 0 && ++num == iFilterIndex)
				{
					result = StreamType.XMLFormat;
				}
				if ((iStreamType & StreamType.CascadingStylesheet) != 0 && ++num == iFilterIndex)
				{
					result = StreamType.CascadingStylesheet;
				}
				if ((iStreamType & StreamType.AdobePDF) != 0 && ++num == iFilterIndex)
				{
					result = StreamType.AdobePDF;
				}
				if ((iStreamType & StreamType.AdobePDFA) != 0 && ++num == iFilterIndex)
				{
					result = StreamType.AdobePDFA;
				}
				if ((iStreamType & StreamType.SpreadsheetML) != 0 && ++num == iFilterIndex)
				{
					result = StreamType.SpreadsheetML;
				}
				if ((iStreamType & StreamType.PlainAnsiText) != 0 && ++num == iFilterIndex)
				{
					result = StreamType.PlainAnsiText;
				}
				if ((iStreamType & StreamType.PlainText) != 0 && ++num == iFilterIndex)
				{
					result = StreamType.PlainText;
				}
				if ((iStreamType & StreamType.InternalUnicodeFormat) != 0 && ++num == iFilterIndex)
				{
					result = StreamType.InternalUnicodeFormat;
				}
				break;
			}
			return result;
		}

		internal ushort GetTxFormat(StreamType iStreamType)
		{
			Enum103 @enum = (Enum103)0;
			switch (iStreamType)
			{
			case StreamType.RichTextFormat:
				@enum = Enum103.const_6;
				break;
			case StreamType.PlainAnsiText:
				@enum = Enum103.const_3;
				break;
			case StreamType.InternalFormat:
				@enum = Enum103.const_4;
				break;
			case StreamType.HTMLFormat:
				@enum = Enum103.const_5;
				break;
			case StreamType.MSWord:
				@enum = Enum103.const_10;
				break;
			case StreamType.InternalUnicodeFormat:
				@enum = Enum103.const_9;
				break;
			case StreamType.PlainText:
				@enum = Enum103.const_7;
				break;
			case StreamType.CascadingStylesheet:
				@enum = Enum103.const_12;
				break;
			case StreamType.XMLFormat:
				@enum = Enum103.const_11;
				break;
			default:
				throw new ArgumentException();
			case StreamType.SpreadsheetML:
				@enum = Enum103.const_16;
				break;
			case StreamType.AdobePDF:
			case StreamType.AdobePDFA:
				@enum = Enum103.const_13;
				break;
			case StreamType.WordprocessingML:
				@enum = Enum103.const_15;
				break;
			}
			return (ushort)@enum;
		}
	}
}
