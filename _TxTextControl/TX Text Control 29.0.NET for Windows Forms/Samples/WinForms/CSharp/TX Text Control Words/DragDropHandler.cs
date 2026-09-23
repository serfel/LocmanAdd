/*-------------------------------------------------------------------------------------------------------------
** program:			TX Text Control Words
** description:	Implements a typical word processing application build up on the main features of TextControl's Components. 
**
** copyright:		© Text Control GmbH
**-----------------------------------------------------------------------------------------------------------*/
using System;
using System.IO;
using System.Windows.Forms;

namespace TX_Text_Control_Words {

	/*------------------------------------------------------------------------------------------------
	** E N U M S
	**----------------------------------------------------------------------------------------------*/

	public enum ImageType {
		UNKNOWN,

		bmp, jpg, gif, tif, png, emf, wmf,
	}

	/*------------------------------------------------------------------------------------------------
	** Class FileDragDropHandler
	** Implements a handler for handling the drag and drop of documents and images into a TextControl.
	** Drag and drop is available for all supported documents and images of TX Text Control.
	** The fileextension specifies the file's content. The extension specifies the corresponding
	** TX Text Control's StreamType or ImageType. 
	**----------------------------------------------------------------------------------------------*/
	class FileDragDropHandler {

		/*------------------------------------------------------------------------------------------------
		** E N U M S
		**----------------------------------------------------------------------------------------------*/

		public enum DraggedFileType {
			UNKNOWN,
			Document,
			Image,
		}

		/*------------------------------------------------------------------------------------------------
		** P R O P E R T I E S
		**----------------------------------------------------------------------------------------------*/

		/*------------------------------------------------------------------------------------------------
		** FileType
		**----------------------------------------------------------------------------------------------*/
		public DraggedFileType FileType { get; private set; }

		/*------------------------------------------------------------------------------------------------
		** ImageType
		**----------------------------------------------------------------------------------------------*/
		public ImageType ImageType { get; private set; }

		/*------------------------------------------------------------------------------------------------
		** FileName
		**----------------------------------------------------------------------------------------------*/
		public string FileName { get; private set; }

		/*------------------------------------------------------------------------------------------------
		** StreamType
		**----------------------------------------------------------------------------------------------*/
		public TXTextControl.StreamType StreamType { get; private set; }

		/*------------------------------------------------------------------------------------------------
		** CanDrop
		**----------------------------------------------------------------------------------------------*/
		public bool CanDrop { get; private set; }

		/*------------------------------------------------------------------------------------------------
		** P U B L I C   M E T H O D S
		**----------------------------------------------------------------------------------------------*/

		/*------------------------------------------------------------------------------------------------
		** Reset method
		** Resets the internal state of the drag & drop handler
		**----------------------------------------------------------------------------------------------*/
		public void Reset() {
			FileName = string.Empty;
			StreamType = 0;
			CanDrop = false;
			FileType = DraggedFileType.UNKNOWN;
			ImageType = ImageType.UNKNOWN;
		}

		/*------------------------------------------------------------------------------------------------
		** CheckDraggedFiles method
		** Resets the internal state of the drag & drop handler and checks whether file can be loaded from
		** TextControl.
		**----------------------------------------------------------------------------------------------*/
		public void CheckDraggedFiles(string[] fileList) {
			Reset();

			if (fileList != null) {
				// Get first parameter from the list and check if it is a supported file type
				FileName = fileList[0];

				switch (Path.GetExtension(FileName).ToLower()) {
					case ".rtf":
						FileType = DraggedFileType.Document;
						StreamType = TXTextControl.StreamType.RichTextFormat;
						break;

					case ".htm":
					case ".html":
						FileType = DraggedFileType.Document;
						StreamType = TXTextControl.StreamType.HTMLFormat;
						break;

					case ".doc":
						FileType = DraggedFileType.Document;
						StreamType = TXTextControl.StreamType.MSWord;
						break;

					case ".docx":
						FileType = DraggedFileType.Document;
						StreamType = TXTextControl.StreamType.WordprocessingML;
						break;

					case ".pdf":
						FileType = DraggedFileType.Document;
						StreamType = TXTextControl.StreamType.AdobePDF;
						break;

					case ".xml":
						FileType = DraggedFileType.Document;
						StreamType = TXTextControl.StreamType.XMLFormat;
						break;

					case ".txt":
						FileType = DraggedFileType.Document;
						StreamType = TXTextControl.StreamType.PlainText;
						break;

					case ".tx":
						FileType = DraggedFileType.Document;
						StreamType = TXTextControl.StreamType.InternalUnicodeFormat;
						break;

					case ".xlsx":
						FileType = DraggedFileType.Document;
						StreamType = TXTextControl.StreamType.SpreadsheetML;
						break;

					case ".jpeg":
					case ".jpg":
						FileType = DraggedFileType.Image;
						ImageType = ImageType.jpg;
						break;

					case ".tif":
						FileType = DraggedFileType.Image;
						ImageType = ImageType.tif;
						break;

					case ".bmp":
						FileType = DraggedFileType.Image;
						ImageType = ImageType.bmp;
						break;

					case ".gif":
						FileType = DraggedFileType.Image;
						ImageType = ImageType.gif;
						break;

					case ".png":
						FileType = DraggedFileType.Image;
						ImageType = ImageType.png;
						break;

					case ".wmf":
						FileType = DraggedFileType.Image;
						ImageType = ImageType.wmf;
						break;

					case ".emf":
						FileType = DraggedFileType.Image;
						ImageType = ImageType.emf;
						break;
					default:
						FileType = DraggedFileType.UNKNOWN;
						ImageType = ImageType.UNKNOWN;
						FileName = String.Empty;
						break;
				}

				if (FileType != DraggedFileType.UNKNOWN) CanDrop = true;
			}
		}

		/*------------------------------------------------------------------------------------------------
		** GetDragDropEffect method
		** Calculates a drag&drop effect depending on the allowed effects.
		**----------------------------------------------------------------------------------------------*/
		public DragDropEffects GetDragDropEffect(DragDropEffects allowedEffects) {
			if ((allowedEffects & DragDropEffects.Copy) == DragDropEffects.Copy) {
				return DragDropEffects.Copy;
			}
			else if ((allowedEffects & DragDropEffects.Move) == DragDropEffects.Move) {
				return DragDropEffects.Move;
			}
			else { return DragDropEffects.None; }
		}
	}
}

