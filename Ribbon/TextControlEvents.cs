/*-------------------------------------------------------------------------------------------------------------
** program:			TX Text Control Words
** description:	Implements a typical word processing application build up on the main features of 
**						TextControl's Components. 
**
** copyright:		© Text Control GmbH
**-----------------------------------------------------------------------------------------------------------*/
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using TXTextControl;
using TXTextControl.DataVisualization;

namespace TX_Text_Control_Words
{

	/*----------------------------------------------------------------------------------------------------------
	** class MainWindow
	**	Capsulates the handling of TextControl's events.
	**--------------------------------------------------------------------------------------------------------*/
	public partial class MainWindow {

		/*-------------------------------------------------------------------------------------------------------
		** E V E N T H A N D L E R S
		**-----------------------------------------------------------------------------------------------------*/

		/*-------------------------------------------------------------------------------------------------------
		** TextControl_InputPositionChanged
		**	Show ribbon's table tools group if input position is in a table and the preview mode is inactive.
		**-----------------------------------------------------------------------------------------------------*/
		private void TextControl_InputPositionChanged(object sender, EventArgs e)
		{
			m_tableToolsGroup.Visible = false; // m_textControl.Tables.GetItem() != null && !m_reportingPreviewGroup.Visible;
		}

		/*-------------------------------------------------------------------------------------------------------
		** TextControl_InputPositionChanged
		**	Update filehandler's dirty state on change.
		**-----------------------------------------------------------------------------------------------------*/
		private void TextControl_Changed(object sender, EventArgs e) {

			m_fileHandler.IsDocumentDirty = true;
		}

		/*-------------------------------------------------------------------------------------------------------
		** TextControl_TextContextMenuOpening
		**	Customize the contextmenu by adding additional items if a frame is selected or TextField.
		**-----------------------------------------------------------------------------------------------------*/
		void TextControl_TextContextMenuOpening(object sender, TXTextControl.TextContextMenuEventArgs e) {

			if ((e.ContextMenuLocation & ContextMenuLocation.SelectedFrame) != 0) {
				AddFrameContextMenuItems(e.TextContextMenu);
			}
			if ((e.ContextMenuLocation & ContextMenuLocation.TextField) != 0) {
				AddFieldContextMenuItems(e.TextContextMenu);
			}
		}

		/*--------------------------------------------------------------------------------------------------------
		** TextControl_PropertyChanged
		**	Update the ribbon button's enabling.
		**------------------------------------------------------------------------------------------------------*/
		private void TextControl_PropertyChanged(object sender, PropertyChangedEventArgs e) {

			switch (e.PropertyName) {
				case "CanPrint":
					m_btnAppMenu_Print_TXITEM_Print.Enabled = m_textControl.CanPrint;
					m_btnAppMenu_TXITEM_Print.Enabled = m_textControl.CanPrint;
					m_btnAppMenu_Print_TXITEM_Print_Quick.Enabled = m_textControl.CanPrint;
					m_btnAppMenu_Print_TXITEM_Print_Preview.Enabled = m_textControl.CanPrint;
					break;
			}
		}

		/*--------------------------------------------------------------------------------------------------------
		** TextControl_FrameSelected
		**	Customize the ribbon group for frame tools by changing the header.
		**------------------------------------------------------------------------------------------------------*/
		private void TextControl_FrameSelected(object sender, TXTextControl.FrameEventArgs e) {

			var chartFrame = e.Frame as ChartFrame;
			if (chartFrame != null) {
				m_frameToolsGroup.Header = Лоцман_добавка.Properties.Resources.CONT_TAB_GRP_CHART_TOOLS;	// Rename frame tools tab group temporarily
				if (!m_frameToolsGroup.ContextualTabs.Contains(m_chartLayoutTab)) m_frameToolsGroup.ContextualTabs.Add(m_chartLayoutTab);
			}
			m_frameToolsGroup.Visible = true;
		}

		/*--------------------------------------------------------------------------------------------------------
		** TextControl_DrawingActivated
		** Show frame tools group on drawing is activated.
		**------------------------------------------------------------------------------------------------------*/
		private void TextControl_DrawingActivated(object sender, 
			TXTextControl.DataVisualization.DrawingEventArgs e) {

			m_frameToolsGroup.Visible = true;
		}

		/*--------------------------------------------------------------------------------------------------------
		** TextControl_FrameDeselected
		** Hide frame tools group if none drawing is selected.
		**------------------------------------------------------------------------------------------------------*/
		private void TextControl_FrameDeselected(object sender, TXTextControl.FrameEventArgs e) {

			FrameBase frame = m_textControl.Frames.GetItem();
			// Restore frame tools group's settings (see TextControl_FrameSelected)
			if ((e.Frame is ChartFrame) && !(frame is ChartFrame)) {
				m_frameToolsGroup.Header = Лоцман_добавка.Properties.Resources.CONT_TAB_GRP_FRAME_TOOLS;	// Restore old group header
				m_frameToolsGroup.ContextualTabs.Remove(m_chartLayoutTab);
			}
			// Hide frametools group (see also TextControl_DrawingActivated)
			if ((frame == null) && (m_textControl.Drawings.GetActivatedItem() == null)) {
				m_frameToolsGroup.Visible = false;
			}
		}

		/*-------------------------------------------------------------------------------------------------------------
		** TextControl_DrawingDeactivated
		** Hide frame tools group if none drawing is selected.
		**-----------------------------------------------------------------------------------------------------------*/
		private void TextControl_DrawingDeactivated(object sender, TXTextControl.DataVisualization.DrawingEventArgs e) {

			if ((m_textControl.Frames.GetItem() == null) && (m_textControl.Drawings.GetActivatedItem() == null)) {
				m_frameToolsGroup.Visible = false;
			}
		}

		/*-------------------------------------------------------------------------------------------------------------
		** TextControl_KeyDown
		** Implement ShortCuts for TextControl.
		**-----------------------------------------------------------------------------------------------------------*/
		private void TextControl_KeyDown(object sender, KeyEventArgs e) {

			switch (e.KeyCode) {
				case Keys.Insert:	// Toggle insertion mode					
					if (e.Control || e.Alt || e.Shift) break;
					ToggleInsertionMode();
					break;

				case Keys.A:		// Ctrl-A: Select all
					if (!e.Control || e.Alt || e.Shift) break;
					m_textControl.SelectAll();
					break;

				case Keys.S:		// Ctrl-S: save
					if (!e.Control || e.Alt || e.Shift) break;
					m_fileHandler.Save();
					break;

				case Keys.O:		// Ctrl-O: open
					if (!e.Control || e.Alt || e.Shift) break;
					m_fileHandler.Open();
					break;

				case Keys.F:		// Ctrl-F: search
					if (!e.Control || e.Alt || e.Shift) break;
					m_textControl.Find();
					break;

				case Keys.P:
					if (!e.Control || e.Alt || e.Shift) break;
					if (m_textControl.CanPrint) {
						m_textControl.Print(m_fileHandler.DocumentTitle);
					}
					else e.Handled = true;
					break;
			}
		}

		/*-------------------------------------------------------------------------------------------------------------
		** TextControl_DragDrop
		** Initialize the drag n' drop of documents and images.
		**-----------------------------------------------------------------------------------------------------------*/
		private void TextControl_DragDrop(object sender, DragEventArgs e) {

			if (m_dragDropHandler.CanDrop) {
				switch (m_dragDropHandler.FileType) {
					case FileDragDropHandler.DraggedFileType.Document:
						OpenDroppedDocument();
						break;

					case FileDragDropHandler.DraggedFileType.Image:
						InsertDroppedImage(e);
						break;
				}
			}
		}

		/*-------------------------------------------------------------------------------------------------------------
		** TextControl_DragEnter
		** Check whether drag is possible.
		**-----------------------------------------------------------------------------------------------------------*/
		private void TextControl_DragEnter(object sender, DragEventArgs e) {

			m_dragDropHandler.Reset();
			m_dragDropHandler.CheckDraggedFiles((string[])e.Data.GetData(DataFormats.FileDrop));
		}

		/*-------------------------------------------------------------------------------------------------------------
		** TextControl_DragOver
		** Show effect for drag action.
		**-----------------------------------------------------------------------------------------------------------*/
		private void TextControl_DragOver(object sender, DragEventArgs e) {

			if (m_dragDropHandler.CanDrop) {
				e.Effect = m_dragDropHandler.GetDragDropEffect(e.AllowedEffect);
			}
		}


		/*-------------------------------------------------------------------------------------------------------------
		** TextControl_HypertextLinkClicked
		** Open the hypertextlink.
		**-----------------------------------------------------------------------------------------------------------*/
		private void TextControl_HypertextLinkClicked(object sender, TXTextControl.HypertextLinkEventArgs e) {

			OpenHyperlink(e.HypertextLink.Target);
		}

		/*-------------------------------------------------------------------------------------------------------------
		** ToggleInsertionMode
		** Switch the TextControl's insertion mode between overwrite and insert.
		**-----------------------------------------------------------------------------------------------------------*/
		private void ToggleInsertionMode() {

			m_textControl.InsertionMode
				= m_textControl.InsertionMode == TXTextControl.InsertionMode.Insert
				? TXTextControl.InsertionMode.Overwrite
				: TXTextControl.InsertionMode.Insert;
		}

		/*-------------------------------------------------------------------------------------------------------------
		** OpenHyperlink
		** Open a new application instance if hyperlink links a document. Open a internet browser if the hyperlink
		** links to a HTTP address.
		**-----------------------------------------------------------------------------------------------------------*/
		private void OpenHyperlink(string strTarget) {

			if (strTarget == "") return;

			try {
				Uri uriTarget = new Uri(strTarget, UriKind.RelativeOrAbsolute);
				if (!uriTarget.IsAbsoluteUri) {
					throw new Exception(Лоцман_добавка.Properties.Resources.EXC_ONLY_ABS_PATH_SUPORTED);
				}

				if (uriTarget.IsFile) {
					// Remove any fragment.
					// uriTarget.GetLeftPart(UriPartial.Path) has no effect because the .NET Uri class
					// does not work correct with file URIs containing any query or fragment part.

					strTarget = uriTarget.LocalPath;
					int nPos = strTarget.IndexOf("#");
					if (nPos != -1) {
						strTarget = strTarget.Substring(0, nPos);
					}
				}
				else if (uriTarget.Scheme != Uri.UriSchemeHttp && uriTarget.Scheme != Uri.UriSchemeHttps) {
					strTarget = uriTarget.GetLeftPart(UriPartial.Path);
				}

				if (uriTarget.IsFile && IsMyFile(strTarget)) {
					OpenFileInNewInstance(strTarget);
				}
				else {
					System.Diagnostics.Process.Start(strTarget);
				}
			}
			catch (Exception ex) {
				string msg = ex.Message;
				if (!msg.EndsWith(".")) msg += ".";
				Utils.MessageBox.Show(this, Лоцман_добавка.Properties.Resources.MSG_COULD_NOT_OPEN_LINK + " " + msg, "Hyperlink", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		/*-------------------------------------------------------------------------------------------------------------
		** OpenFileInNewInstance
		** Open the file by passed filepath in a new instance of this application.
		**-----------------------------------------------------------------------------------------------------------*/
		private void OpenFileInNewInstance(string strTarget) {

			// Check if file exists and show message box if not
			if (!File.Exists(strTarget)) {
				Utils.MessageBox.Show(this, string.Format(Лоцман_добавка.Properties.Resources.MSG_FILE_DOES_NOT_EXIST, strTarget), "Hyperlink", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			// Get running demo's exe path
			string exePath = Assembly.GetEntryAssembly().Location;

			// Start new demo instance
			var process = new Process();
			process.StartInfo.FileName = exePath;
			process.StartInfo.Arguments = "\"" + strTarget + "\"";
			process.Start();
		}

		/*-------------------------------------------------------------------------------------------------------
		** IsMyFile
		** Checks if file type of the targeted file is rtf, doc, docx or tx
		**-----------------------------------------------------------------------------------------------------*/
		private bool IsMyFile(string strTarget) {

			string strExt = Path.GetExtension(strTarget).ToLower();

			switch (strExt) {
				case ".rtf":
				case ".doc":
				case ".docx":
				case ".tx":
					return true;
			}

			return false;
		}

		/*-------------------------------------------------------------------------------------------------------
		** OpenDroppedDocument
		** Open the dropped document.
		**-----------------------------------------------------------------------------------------------------*/
		private void OpenDroppedDocument() {

			m_fileHandler.Open(m_dragDropHandler.FileName);
		}

		/*-------------------------------------------------------------------------------------------------------
		** InsertDroppedImage
		** Insert the dropped image in TextControl.
		**-----------------------------------------------------------------------------------------------------*/
		private void InsertDroppedImage(DragEventArgs e) {

			try {
				// Get pixel position of mouse cursor inside Text Control
				Point posCursor = m_textControl.PointToClient(Cursor.Position);

				// Get bounding rectangle of the first character of the paragraph
				// the image was dropped over
				TXTextControl.Paragraph par = m_textControl.Paragraphs.GetItem(posCursor);
				TXTextControl.TextChar charParStart = m_textControl.TextChars[par.Start];
				Rectangle rPar = (charParStart != null) ? charParStart.Bounds : new Rectangle();

				// Get bounding rectangle of the character the image was dropped over
				TXTextControl.TextChar txChar = m_textControl.TextChars.GetItem(posCursor, true);
				Rectangle rChar = (txChar != null) ? txChar.Bounds : new Rectangle();

				// Calculate image position relative to paragraph position
				var posImg = new Point(rChar.Left - rPar.Left + rChar.Width, rChar.Top - rPar.Top);

				// Insert image anchored to paragraph
				var txImg = new TXTextControl.Image() { FileName = m_dragDropHandler.FileName };
				m_textControl.Images.Add(txImg, posImg, par.Start, TXTextControl.ImageInsertionMode.DisplaceText);
			}
			catch (Exception exc) {
				Utils.MessageBox.Show(this, exc.Message, "Боцман");
			}
		}
	}
}
