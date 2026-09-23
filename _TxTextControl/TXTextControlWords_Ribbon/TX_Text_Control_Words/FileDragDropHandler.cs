using System.IO;
using System.Windows.Forms;
using TXTextControl;

namespace TX_Text_Control_Words
{
	internal class FileDragDropHandler
	{
		public enum DraggedFileType
		{
			UNKNOWN,
			Document,
			Image
		}

		public DraggedFileType FileType { get; private set; }

		public ImageType ImageType { get; private set; }

		public string FileName { get; private set; }

		public StreamType StreamType { get; private set; }

		public bool CanDrop { get; private set; }

		public void Reset()
		{
			this.FileName = string.Empty;
			this.StreamType = (StreamType)0;
			this.CanDrop = false;
			this.FileType = DraggedFileType.UNKNOWN;
			this.ImageType = ImageType.UNKNOWN;
		}

		public void CheckDraggedFiles(string[] fileList)
		{
			this.Reset();
			if (fileList != null)
			{
				this.FileName = fileList[0];
				switch (Path.GetExtension(this.FileName).ToLower())
				{
				case ".rtf":
					this.FileType = DraggedFileType.Document;
					this.StreamType = StreamType.RichTextFormat;
					break;
				case ".htm":
				case ".html":
					this.FileType = DraggedFileType.Document;
					this.StreamType = StreamType.HTMLFormat;
					break;
				case ".doc":
					this.FileType = DraggedFileType.Document;
					this.StreamType = StreamType.MSWord;
					break;
				case ".docx":
					this.FileType = DraggedFileType.Document;
					this.StreamType = StreamType.WordprocessingML;
					break;
				case ".pdf":
					this.FileType = DraggedFileType.Document;
					this.StreamType = StreamType.AdobePDF;
					break;
				case ".xml":
					this.FileType = DraggedFileType.Document;
					this.StreamType = StreamType.XMLFormat;
					break;
				case ".txt":
					this.FileType = DraggedFileType.Document;
					this.StreamType = StreamType.PlainText;
					break;
				case ".tx":
					this.FileType = DraggedFileType.Document;
					this.StreamType = StreamType.InternalUnicodeFormat;
					break;
				case ".xlsx":
					this.FileType = DraggedFileType.Document;
					this.StreamType = StreamType.SpreadsheetML;
					break;
				case ".jpeg":
				case ".jpg":
					this.FileType = DraggedFileType.Image;
					this.ImageType = ImageType.jpg;
					break;
				case ".tif":
					this.FileType = DraggedFileType.Image;
					this.ImageType = ImageType.tif;
					break;
				case ".bmp":
					this.FileType = DraggedFileType.Image;
					this.ImageType = ImageType.bmp;
					break;
				case ".gif":
					this.FileType = DraggedFileType.Image;
					this.ImageType = ImageType.gif;
					break;
				case ".png":
					this.FileType = DraggedFileType.Image;
					this.ImageType = ImageType.png;
					break;
				case ".wmf":
					this.FileType = DraggedFileType.Image;
					this.ImageType = ImageType.wmf;
					break;
				case ".emf":
					this.FileType = DraggedFileType.Image;
					this.ImageType = ImageType.emf;
					break;
				default:
					this.FileType = DraggedFileType.UNKNOWN;
					this.ImageType = ImageType.UNKNOWN;
					this.FileName = string.Empty;
					break;
				}
				if (this.FileType != 0)
				{
					this.CanDrop = true;
				}
			}
		}

		public DragDropEffects GetDragDropEffect(DragDropEffects allowedEffects)
		{
			if ((allowedEffects & DragDropEffects.Copy) == DragDropEffects.Copy)
			{
				return DragDropEffects.Copy;
			}
			if ((allowedEffects & DragDropEffects.Move) == DragDropEffects.Move)
			{
				return DragDropEffects.Move;
			}
			return DragDropEffects.None;
		}
	}
}
