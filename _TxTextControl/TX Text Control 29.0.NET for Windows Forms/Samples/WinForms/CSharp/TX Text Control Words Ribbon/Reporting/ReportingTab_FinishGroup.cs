/*-------------------------------------------------------------------------------------------------------------
** program:			TX Text Control Words
** description:	Implements a typical word processing application build up on the main features of TextControl's Components. 
**
** copyright:		© Text Control GmbH
**-----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Threading;
using System.Windows.Forms;
using TX_Text_Control_Words.Properties;
using TXTextControl;
using TXTextControl.Windows.Forms;
using TXTextControl.Windows.Forms.Ribbon;

namespace TX_Text_Control_Words {

	/*------------------------------------------------------------------------------------------------
	** Class MainWindow
	** Capsulates of the finish group for the ribbontab. The finish group contains a button for
	** previewing the result of a merge, a menu for choosing whether the merging should the results
	** appended or separated to multiple documents.
	**----------------------------------------------------------------------------------------------*/
	public partial class MainWindow {

		/*------------------------------------------------------------------------------------------------
		** M E M B E R S
		**----------------------------------------------------------------------------------------------*/

		private RibbonGroup TXITEM_FinishGroup;
		private RibbonButton TXITEM_Preview;

		private MergeWaitDialog m_dlgMergeWait;
		private byte[] m_textControlContent = null;
		private EditMode m_editMode = EditMode.Edit;


		/*------------------------------------------------------------------------------------------------
		** M E T H O D S
		**----------------------------------------------------------------------------------------------*/

		/*------------------------------------------------------------------------------------------------
		** AddFinishGroup
		** Create and append a finish group to reporting tab. 
		**----------------------------------------------------------------------------------------------*/
		private void AddFinishGroup() {

			TXITEM_FinishGroup = new RibbonGroup
			{
				Text = Resources.HEADER_FinishGroup,
				SmallIcon = Images.GetSmallIcon("FinishGroup"),
				LargeIcon = Images.GetSmallIcon("FinishAndMerge"),
				HorizontalContentAlignment = TXTextControl.HorizontalAlignment.Center,
				Enabled = false
			};
			TXITEM_FinishGroup.DialogBoxLauncher.Visible = false;
			m_reportingTab.RibbonGroups.Add(TXITEM_FinishGroup);

			// Fill group with a preview button and a menu for finishing and merging
			AddPreviewButton();
			AddFinishAndMergeButton();
		}

		/*------------------------------------------------------------------------------------------------
		** AddPreviewButton
		** Create and append a button to finish group. On click the previewing of the merge result starts.
		**----------------------------------------------------------------------------------------------*/
		private void AddPreviewButton() {

			TXITEM_Preview = new RibbonButton
			{
				Text = Resources.LABEL_Preview,
				KeyTip = Resources.KEYTIP_Preview,
				SmallIcon = Images.GetSmallIcon("Preview"),
				LargeIcon = Images.GetLargeIcon("Preview"),
				DisplayMode = IconTextRelation.LargeIconLabeled,
			};
			TXITEM_Preview.ToolTip.Title = Resources.TOOLTIPTITLE_Preview;
			TXITEM_Preview.ToolTip.Description = Resources.TOOLTIP_Preview;

			TXITEM_Preview.Click += BtnPreview_Click;

			TXITEM_FinishGroup.RibbonItems.Add(TXITEM_Preview);
		}


		/*------------------------------------------------------------------------------------------------
		** BtnPreview_Click
		** Show a dialog for choosing the dialog maximum count of previews and preview the count of 
		** merge results.
		**----------------------------------------------------------------------------------------------*/
		void BtnPreview_Click(object sender, EventArgs e) {

			LimitPreviewDataDialog m_dlgLimitPreviewData = new LimitPreviewDataDialog();
			if (m_dlgLimitPreviewData.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
				MergePreviewAsync(m_dlgLimitPreviewData.MaxPreviews);
			}
		}

		/*------------------------------------------------------------------------------------------------
		** MergePreviewAsync
		** Start a asynchronous process for displaying the progress of the merging for the preview
		** in a new dialog.
		**----------------------------------------------------------------------------------------------*/
		private void MergePreviewAsync(int nMaxPreviews) {

			ThreadPool.QueueUserWorkItem(MergePreviewCallback, nMaxPreviews);
		}

		/*------------------------------------------------------------------------------------------------
		** MergePreviewCallback
		** Start a asynchronous process for displaying the progress of the merging for the preview
		** in a new dialog.
		**----------------------------------------------------------------------------------------------*/
		private void MergePreviewCallback(object state) {

			int nMaxPreviews = (int)state;
			BeginInvoke((Action)ShowMergeWaitDialog);
			MergePreview(nMaxPreviews);
			BeginInvoke((Action)CloseMergeWaitDialog);
		}

		/*------------------------------------------------------------------------------------------------
		** MergePreview
		** Use the the TextControl's document as template and creates a limited count previews by merging
		** the data of the last selected master table. Shows the result in the TextControl in 
		** 'Preview mode'. 'Preview mode': TextControl's document is not editable.
		**----------------------------------------------------------------------------------------------*/
		private void MergePreview(int nMaxPreviews) {

			m_textControl.Save(out m_textControlContent, BinaryStreamType.InternalUnicodeFormat);
			Invoke((Action)(() => SetLastSelectedMasterTable()));
			m_lstMergedFiles = m_reportingTab.DataSourceManager.Merge(m_textControlContent, nMaxPreviews, m_textControl);
			if (m_lstMergedFiles.Count > 0) {
				Invoke((Action)(() => {
					m_iPreviewIndex = 0;
					m_nPreviewCount = Math.Min(nMaxPreviews, m_lstMergedFiles.Count);
					m_textControl.Load(m_lstMergedFiles[0], BinaryStreamType.InternalUnicodeFormat);
					m_reportingPreviewGroup.Visible = true;
					m_ribbon.SelectedTab = m_previewTab;
					m_editMode = m_textControl.EditMode;
					m_textControl.EditMode = EditMode.ReadAndSelect;
					TXITEM_Preview.Enabled = false;
					UpdateNavigateButtons();
				}));
			}
			else {
				m_lstMergedFiles = null;
			}
		}


		/*------------------------------------------------------------------------------------------------
		** AddFinishAndMergeButton
		** Appends a button to the finish group for merging into the current document.
		**----------------------------------------------------------------------------------------------*/
		private void AddFinishAndMergeButton() {

			RibbonSplitButton TXITEM_FinishAndMerge = new RibbonSplitButton
			{
				Text = Resources.LABEL_FinishAndMerge,
				KeyTip = Resources.KEYTIP_FinishAndMerge,
				SmallIcon = Images.GetSmallIcon("FinishAndMerge"),
				LargeIcon = Images.GetLargeIcon("FinishAndMerge")
			};
			TXITEM_FinishAndMerge.ToolTip.Title = Resources.TOOLTIPTITLE_FinishAndMerge;
			TXITEM_FinishAndMerge.ToolTip.Description = Resources.TOOLTIP_FinishAndMerge;

			TXITEM_FinishAndMerge.ButtonClick += BtnFinishMerge_Click;
			AddFinishAndMergeMenu(TXITEM_FinishAndMerge);

			TXITEM_FinishGroup.RibbonItems.Add(TXITEM_FinishAndMerge);

			m_reportingTab.DataSourceManager.IsMergingPossibleChanged += DataSourceManager_IsMergingPossibleChanged;
		}

		/*------------------------------------------------------------------------------------------------
		** BtnFinishMerge_Click
		** Merge data asynchronous into current document.
		**----------------------------------------------------------------------------------------------*/
		void BtnFinishMerge_Click(object sender, System.EventArgs e) {
			MergeIntoCurrentDocAsync();
		}

		/*------------------------------------------------------------------------------------------------
		** DataSourceManager_IsMergingPossibleChanged
		** Enable/Disable finish group if merging 'is'/'is not' possible.
		**----------------------------------------------------------------------------------------------*/
		void DataSourceManager_IsMergingPossibleChanged(object sender, EventArgs e) {
			TXITEM_FinishGroup.Enabled = m_reportingTab.DataSourceManager.IsMergingPossible;
		}


		/*------------------------------------------------------------------------------------------------
		** AddFinishAndMergeMenu
		** Add buttons to the splitted button for determine the kind of merge. Data can be merged into 
		** the current document, in a single file, in multiple files, or for immediately printing.
		**----------------------------------------------------------------------------------------------*/
		private void AddFinishAndMergeMenu(RibbonSplitButton splitButton) {

			// Merge into Current Document:
			var TXITEM_FinishAndMerge_IntoCurrentDocument = new RibbonButton
			{
				Text = Resources.HEADER_FinishAndMerge_IntoCurrentDocument,
				SmallIcon = Images.GetSmallIcon("FinishAndMerge_IntoCurrentDocument"),
				DisplayMode = IconTextRelation.SmallIconLabeled
			};
			TXITEM_FinishAndMerge_IntoCurrentDocument.ToolTip.Title = Resources.TOOLTIPTITLE_FinishAndMerge_IntoCurrentDocument;
			TXITEM_FinishAndMerge_IntoCurrentDocument.ToolTip.Description = Resources.TOOLTIP_FinishAndMerge_IntoCurrentDocument;
			TXITEM_FinishAndMerge_IntoCurrentDocument.Click += BtnMergeIntoCur_Click;


			// Merge into Single File:
			var TXITEM_FinishAndMerge_IntoSingleFile = new RibbonButton
			{
				Text = Resources.HEADER_FinishAndMerge_IntoSingleFile,
				SmallIcon = Images.GetSmallIcon("FinishAndMerge_IntoSingleFile"),
				DisplayMode = IconTextRelation.SmallIconLabeled
			};
			TXITEM_FinishAndMerge_IntoSingleFile.ToolTip.Title = Resources.TOOLTIPTITLE_FinishAndMerge_IntoSingleFile;
			TXITEM_FinishAndMerge_IntoSingleFile.ToolTip.Description = Resources.TOOLTIP_FinishAndMerge_IntoSingleFile;
			TXITEM_FinishAndMerge_IntoSingleFile.Click += BtnMergeIntoSingleFile_Click;

			// Merge into Multiple Files:
			var TXITEM_FinishAndMerge_IntoIndividualDocument = new RibbonMenuButton
			{
				Text = Resources.HEADER_FinishAndMerge_IntoIndividualDocument,
				SmallIcon = Images.GetSmallIcon("FinishAndMerge_IntoIndividualDocument"),
				DisplayMode = IconTextRelation.SmallIconLabeled
			};
			TXITEM_FinishAndMerge_IntoIndividualDocument.ToolTip.Title = Resources.TOOLTIPTITLE_FinishAndMerge_IntoIndividualDocument;
			TXITEM_FinishAndMerge_IntoIndividualDocument.ToolTip.Description = Resources.TOOLTIP_FinishAndMerge_IntoIndividualDocument;
			AddMergeIntoSeparateFilesMenu(TXITEM_FinishAndMerge_IntoIndividualDocument);

			// Print Document:
			var TXITEM_FinishAndMerge_PrintDocument = new RibbonButton
			{
				Text = Resources.HEADER_FinishAndMerge_PrintDocument,
				SmallIcon = Images.GetSmallIcon("FinishAndMerge_PrintDocument"),
				DisplayMode = IconTextRelation.SmallIconLabeled
			};
			TXITEM_FinishAndMerge_PrintDocument.ToolTip.Title = Resources.TOOLTIPTITLE_FinishAndMerge_PrintDocument;
			TXITEM_FinishAndMerge_PrintDocument.ToolTip.Description = Resources.TOOLTIP_FinishAndMerge_PrintDocument;
			TXITEM_FinishAndMerge_PrintDocument.Click += BtnMergePrint_Click;

			// Add buttons to drop down menu
			splitButton.DropDownItems.AddRange(
				new Control[] { 
					TXITEM_FinishAndMerge_IntoCurrentDocument,
					TXITEM_FinishAndMerge_IntoSingleFile,
					TXITEM_FinishAndMerge_IntoIndividualDocument,
					TXITEM_FinishAndMerge_PrintDocument
				});
		}

		/*------------------------------------------------------------------------------------------------
		** BtnMergeIntoCur_Click
		** Merge data asynchronous into current document.
		**----------------------------------------------------------------------------------------------*/
		void BtnMergeIntoCur_Click(object sender, System.EventArgs e) {
			MergeIntoCurrentDocAsync();
		}

		/*------------------------------------------------------------------------------------------------
		** BtnMergeIntoSingleFile_Click
		** Start the asynchronous merging into a single file .
		**----------------------------------------------------------------------------------------------*/
		void BtnMergeIntoSingleFile_Click(object sender, System.EventArgs e) {

			// Create Filter for Save As Dialog
			var streamTypes = new List<StreamType>{
										StreamType.AdobePDF,
										StreamType.RichTextFormat,
										StreamType.MSWord,
										StreamType.WordprocessingML,
										StreamType.PlainText,
										StreamType.InternalUnicodeFormat,
										StreamType.HTMLFormat
									};
			string filter = string.Join("|", streamTypes.ConvertAll(x => x.ToFilterString()));

			// Create Save As Dialog
			SaveFileDialog sfd = new SaveFileDialog()
			{
				Filter = filter
			};

			if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
				// Merge async to the choosen file.
				var choosenStreamType = System.IO.Path.GetExtension(sfd.FileName).ToTxStreamType();
				var mergeInfo = new MergeIntoSingleFileInfo(choosenStreamType, sfd.FileName);
				ThreadPool.QueueUserWorkItem(MergeIntoSingleFileCallback, mergeInfo);
			}
		}

		/*------------------------------------------------------------------------------------------------
		** AddMergeIntoSeparateFilesMenu
		** Add a button to passed menu for merging the data into separate files. 
		**----------------------------------------------------------------------------------------------*/
		private void AddMergeIntoSeparateFilesMenu(RibbonMenuButton menuButton) {

			AddMergeIntoMenuButtons(
				menuButton,
				Properties.Resources.BTN_MERGE_INTO_INDIV_X_FILES_TOOLTIP,
				BtnMergeIntoSeparateFiles_Click);
		}

		/*------------------------------------------------------------------------------------------------
		** BtnMergeIntoSeparateFiles_Click
		** Start the asynchronous merging separate files.
		**----------------------------------------------------------------------------------------------*/
		void BtnMergeIntoSeparateFiles_Click(object sender, System.EventArgs e) {

			var btn = sender as RibbonButton;
			if (btn == null) return;
			MergeIntoSeparateFilesAsync(btn.Text.ToTxStreamType());
		}


		/*------------------------------------------------------------------------------------------------
		** AddMergeIntoMenuButtons
		** Add buttons for determine the exporting document type for a merge (PDF, RTF, DOCX, DOC, HTMl,
		** TXT).
		**----------------------------------------------------------------------------------------------*/
		private void AddMergeIntoMenuButtons(
			RibbonMenuButton menuButton,
			string toolTipTextTemplate,
			EventHandler clickHandler) {

			var TXITEM_FinishAndMerge_IntoIndividualDocument_PDF = new RibbonButton
			{
				Text = "PDF",
				DisplayMode = IconTextRelation.NoIconLabeled
			};
			TXITEM_FinishAndMerge_IntoIndividualDocument_PDF.ToolTip.Description = string.Format(toolTipTextTemplate, TXITEM_FinishAndMerge_IntoIndividualDocument_PDF.Text);
			TXITEM_FinishAndMerge_IntoIndividualDocument_PDF.Click += clickHandler;

			var TXITEM_FinishAndMerge_IntoIndividualDocument_RTF = new RibbonButton
			{
				Text = "RTF",
				DisplayMode = IconTextRelation.NoIconLabeled
			};
			TXITEM_FinishAndMerge_IntoIndividualDocument_RTF.ToolTip.Description = string.Format(toolTipTextTemplate, TXITEM_FinishAndMerge_IntoIndividualDocument_RTF.Text);
			TXITEM_FinishAndMerge_IntoIndividualDocument_RTF.Click += clickHandler;

			var TXITEM_FinishAndMerge_IntoIndividualDocument_DOCX = new RibbonButton
			{
				Text = "DOCX",
				DisplayMode = IconTextRelation.NoIconLabeled
			};
			TXITEM_FinishAndMerge_IntoIndividualDocument_DOCX.ToolTip.Description = string.Format(toolTipTextTemplate, TXITEM_FinishAndMerge_IntoIndividualDocument_DOCX.Text);
			TXITEM_FinishAndMerge_IntoIndividualDocument_DOCX.Click += clickHandler;

			var TXITEM_FinishAndMerge_IntoIndividualDocument_DOC = new RibbonButton
			{
				Text = "DOC",
				DisplayMode = IconTextRelation.NoIconLabeled
			};
			TXITEM_FinishAndMerge_IntoIndividualDocument_DOC.ToolTip.Description = string.Format(toolTipTextTemplate, TXITEM_FinishAndMerge_IntoIndividualDocument_DOC.Text);
			TXITEM_FinishAndMerge_IntoIndividualDocument_DOC.Click += clickHandler;

			var TXITEM_FinishAndMerge_IntoIndividualDocument_HTML = new RibbonButton
			{
				Text = "HTML",
				DisplayMode = IconTextRelation.NoIconLabeled
			};
			TXITEM_FinishAndMerge_IntoIndividualDocument_HTML.ToolTip.Description = string.Format(toolTipTextTemplate, TXITEM_FinishAndMerge_IntoIndividualDocument_HTML.Text);
			TXITEM_FinishAndMerge_IntoIndividualDocument_HTML.Click += clickHandler;

			var TXITEM_FinishAndMerge_IntoIndividualDocument_TXT = new RibbonButton
			{
				Text = "TXT",
				DisplayMode = IconTextRelation.NoIconLabeled
			};
			TXITEM_FinishAndMerge_IntoIndividualDocument_TXT.ToolTip.Description = string.Format(toolTipTextTemplate, TXITEM_FinishAndMerge_IntoIndividualDocument_TXT.Text);
			TXITEM_FinishAndMerge_IntoIndividualDocument_TXT.Click += clickHandler;

			menuButton.DropDownItems.AddRange(
				new Control[] { TXITEM_FinishAndMerge_IntoIndividualDocument_PDF, TXITEM_FinishAndMerge_IntoIndividualDocument_RTF, TXITEM_FinishAndMerge_IntoIndividualDocument_DOCX, TXITEM_FinishAndMerge_IntoIndividualDocument_DOC, TXITEM_FinishAndMerge_IntoIndividualDocument_HTML, TXITEM_FinishAndMerge_IntoIndividualDocument_TXT });
		}

		/*------------------------------------------------------------------------------------------------
		** BtnMergePrint_Click
		** Start the merge for printing.
		**----------------------------------------------------------------------------------------------*/
		void BtnMergePrint_Click(object sender, System.EventArgs e) {
			MergePrintAsync();
		}

		/*------------------------------------------------------------------------------------------------
		** MergeIntoCurrentDocAsync
		** Start a new process for asynchronous merging into the current document.
		**----------------------------------------------------------------------------------------------*/
		private void MergeIntoCurrentDocAsync() {
			if (!m_fileHandler.HandleUnsavedChanges()) return;
			ThreadPool.QueueUserWorkItem(MergeIntoCurrentDocCallback);
		}

		/*------------------------------------------------------------------------------------------------
		** MergeIntoCurrentDocCallback
		** Show a progress dialog during the merging into the current document.
		**----------------------------------------------------------------------------------------------*/
		private void MergeIntoCurrentDocCallback(object state) {
			BeginInvoke((Action)ShowMergeWaitDialog);
			MergeIntoCurrentDocument();
			BeginInvoke((Action)CloseMergeWaitDialog);
		}

		/*------------------------------------------------------------------------------------------------
		** MergeIntoCurrentDocument
		** Merge data into the current document by using reportingtab's datasourcemanager.
		**----------------------------------------------------------------------------------------------*/
		private void MergeIntoCurrentDocument() {
			var dm = m_reportingTab.DataSourceManager;
			byte[] document;
			m_textControl.Save(out document, BinaryStreamType.InternalUnicodeFormat);
			IList<byte[]> mergeResult = dm.Merge(document, m_textControl);

			if (mergeResult.Count == 0) {
				Utils.MessageBox.Show(this, Properties.Resources.MERGE_NO_MERGE_RESULTS,
					ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
				return;
			}
			Invoke((Action)m_textControl.ResetContents);
			foreach (byte[] doc in mergeResult) {
				m_textControl.Append(doc, BinaryStreamType.InternalUnicodeFormat, AppendSettings.StartWithNewSection);
			}
		}

		/*------------------------------------------------------------------------------------------------
		** class MergeIntoSeparateFilesInfo
		** Used to pass information about the output folder and streamtype,
		**	to one of the async callback methods.
		**----------------------------------------------------------------------------------------------*/
		private sealed class MergeIntoSeparateFilesInfo {
			public MergeIntoSeparateFilesInfo(TXTextControl.StreamType streamType, string dirName) {
				this.StreamType = streamType;
				this.DirectoryName = dirName;
			}
			public StreamType StreamType { get; private set; }
			public string DirectoryName { get; private set; }
		}

		/*------------------------------------------------------------------------------------------------
		** MergeIntoSeparateFilesAsync
		** Shows a dialog for choosing the output folder for the merge result and starts a
		** asynchronous process for merging the data into separate files.
		**----------------------------------------------------------------------------------------------*/
		private void MergeIntoSeparateFilesAsync(StreamType streamType) {
			var dlg = new FolderBrowserDialog
			{
				ShowNewFolderButton = true
			};
			if (dlg.ShowDialog(this) == System.Windows.Forms.DialogResult.OK) {
				var mergeInfo = new MergeIntoSeparateFilesInfo(streamType, dlg.SelectedPath);
				ThreadPool.QueueUserWorkItem(MergeIntoSeparateFilesCallback, mergeInfo);
			}
		}

		/*------------------------------------------------------------------------------------------------
		** MergeIntoSeparateFilesCallback
		** Merge data into separate files and show a dialog during progress for displaying the 
		** progress state of the merging.
		**----------------------------------------------------------------------------------------------*/
		private void MergeIntoSeparateFilesCallback(object state) {
			var mergeInfo = state as MergeIntoSeparateFilesInfo;
			if (mergeInfo == null) return;

			BeginInvoke((Action)ShowMergeWaitDialog);
			MergeIntoSeparateFiles(mergeInfo.StreamType, mergeInfo.DirectoryName);
			BeginInvoke((Action)CloseMergeWaitDialog);
		}

		/*------------------------------------------------------------------------------------------------
		** MergeIntoSeparateFiles
		** Merge data into separate files by using a ServerTextControl.
		**----------------------------------------------------------------------------------------------*/
		private void MergeIntoSeparateFiles(StreamType streamType, string dirName) {
			var dm = m_reportingTab.DataSourceManager;

			byte[] document;
			m_textControl.Save(out document, BinaryStreamType.InternalUnicodeFormat);
			IEnumerable<byte[]> mergeResult = dm.Merge(document, m_textControl);

			using (var txTmp = new ServerTextControl()) {
				txTmp.Create();
				int nDataRow = 0;
				string fileNamePrefix = string.Format("\\MergedDocument_{0:yy-MM-dd}_{0:HH-mm-ss}_", DateTime.Now),
					fileExt = streamType.ToFileExt();
				foreach (byte[] doc in mergeResult) {
					txTmp.Load(doc, BinaryStreamType.InternalUnicodeFormat);
					string strFileName = string.Format("{0}{1}{2}{3}",
						dirName, fileNamePrefix, string.Format("{0:00000}", nDataRow++), fileExt);
					txTmp.Save(strFileName, streamType);
				}
			}
		}


		/*------------------------------------------------------------------------------------------------
		** class MergeIntoSingleFileInfo
		** Used to pass information about the output file and streamtype,
		**	to one of the async callback methods.
		**----------------------------------------------------------------------------------------------*/
		private sealed class MergeIntoSingleFileInfo {
			public MergeIntoSingleFileInfo(TXTextControl.StreamType streamType, string fileName) {
				this.StreamType = streamType;
				this.FileName = fileName;
			}
			public StreamType StreamType { get; private set; }
			public string FileName { get; private set; }
		}

		/*------------------------------------------------------------------------------------------------
		** MergeIntoSingleFileCallback
		** Merge data into a single file and show a dialog during the progress for displaying the 
		** progress state of the merging.
		**----------------------------------------------------------------------------------------------*/
		private void MergeIntoSingleFileCallback(object state) {
			var mergeInfo = state as MergeIntoSingleFileInfo;
			if (mergeInfo == null) return;

			BeginInvoke((Action)ShowMergeWaitDialog);
			MergeIntoSingleFile(mergeInfo.StreamType, mergeInfo.FileName);
			BeginInvoke((Action)CloseMergeWaitDialog);
		}

		/*------------------------------------------------------------------------------------------------
		** MergeIntoSingleFile
		** Merge into a single file by using ReportingTab's Datasourcemanager.
		**----------------------------------------------------------------------------------------------*/
		private void MergeIntoSingleFile(StreamType streamType, string fileName) {

			var dm = m_reportingTab.DataSourceManager;

			// Use TextControl's document as template.
			byte[] document;
			m_textControl.Save(out document, BinaryStreamType.InternalUnicodeFormat);

			// Create reports.
			IList<byte[]> mergeResult = dm.Merge(document, m_textControl);

			using (var txTmp = new ServerTextControl()) {
				txTmp.Create();

				// Concatenated reports by fully load first one for applying also page settings etc.
				// and append others as new sections.
				for (int i = 0; i < mergeResult.Count; i++) {
					byte[] doc = mergeResult[i];
					if (i == 0)
						txTmp.Load(doc, BinaryStreamType.InternalUnicodeFormat);
					else
						txTmp.Append(doc, BinaryStreamType.InternalUnicodeFormat, AppendSettings.StartWithNewSection);
				}

				// Save merge result into file.
				txTmp.Save(fileName, streamType);
			}
		}


		/*------------------------------------------------------------------------------------------------
		** MergePrintAsync
		** Show a print dialog for choosing the document settings for printing. Afterwards merge the data
		** for the printing document and print the merge result.
		**----------------------------------------------------------------------------------------------*/
		private void MergePrintAsync() {
			var printDoc = new PrintDocument();
			var printDlg = new PrintDialog
			{
				UseEXDialog = true,
				AllowCurrentPage = false,
				AllowSelection = false,
				AllowSomePages = false,
				Document = printDoc
			};
			if (printDlg.ShowDialog(this) == System.Windows.Forms.DialogResult.OK) {
				ThreadPool.QueueUserWorkItem(MergePrintCallback, printDlg.Document);
			}
		}

		/*------------------------------------------------------------------------------------------------
		** MergePrintCallback
		** Start the merge into the printing document and show a progress dialog while the merge.
		**----------------------------------------------------------------------------------------------*/
		private void MergePrintCallback(object state) {
			var printDoc = state as PrintDocument;
			if (printDoc == null) return;
			BeginInvoke((Action)ShowMergeWaitDialog);
			MergePrint(printDoc);
			BeginInvoke((Action)CloseMergeWaitDialog);
		}

		/*------------------------------------------------------------------------------------------------
		** MergePrint
		** Merge the data into the passed document by using a ServerTextControl and the ReportingTab's
		** DataSourceManager.
		**----------------------------------------------------------------------------------------------*/
		private void MergePrint(PrintDocument printDoc) {
			var dm = m_reportingTab.DataSourceManager;

			byte[] document;
			m_textControl.Save(out document, BinaryStreamType.InternalUnicodeFormat);
			IEnumerable<byte[]> mergeResult = dm.Merge(document, m_textControl);
			using (var txTmp = new ServerTextControl()) {
				txTmp.Create();
				foreach (byte[] doc in mergeResult) {
					txTmp.Append(doc, BinaryStreamType.InternalUnicodeFormat, AppendSettings.StartWithNewSection);
				}
				txTmp.Print(printDoc);
			}
		}


		/*------------------------------------------------------------------------------------------------
		** ShowMergeWaitDialog
		** Close a running merge dialog and shows a new one. 
		**----------------------------------------------------------------------------------------------*/
		private void ShowMergeWaitDialog() {
			if (m_dlgMergeWait != null) {
				try { m_dlgMergeWait.CloseDialog(); }
				catch { }
				m_dlgMergeWait = null;
			}
			m_dlgMergeWait = new MergeWaitDialog();
			m_dlgMergeWait.Owner = this;
			m_dlgMergeWait.ShowDialog();
		}

		/*------------------------------------------------------------------------------------------------
		** CloseMergeWaitDialog
		** Initialize the closing of the dialog.
		**----------------------------------------------------------------------------------------------*/
		private void CloseMergeWaitDialog() {
			if (m_dlgMergeWait != null) {
				try {
					m_dlgMergeWait.CloseDialog();
					m_dlgMergeWait = null;
				}
				catch { }
			}
		}

		/*------------------------------------------------------------------------------------------------
		** SetLastSelectedMasterTable
		** Sets the last selected master table of the ReportingTab's MasterTable Menu as datasource.
		**----------------------------------------------------------------------------------------------*/
		private void SetLastSelectedMasterTable() {
			RibbonMenuButton rmbtnTXITEM_SelectMasterTable = m_reportingTab.FindItem(RibbonReportingTab.RibbonItem.TXITEM_SelectMasterTable) as RibbonMenuButton;
			foreach (Control dropDownItem in rmbtnTXITEM_SelectMasterTable.DropDownItems) {
				RibbonToggleButton rtbnTable = dropDownItem as RibbonToggleButton;
				if (rtbnTable != null && rtbnTable.Checked) {
					m_reportingTab.DataSourceManager.MasterDataTableInfo = rtbnTable.Tag as TXTextControl.DocumentServer.DataSources.DataTableInfo;
					break;
				}
			}
		}
	}


	/*------------------------------------------------------------------------------------------------
	** static class ReportingTabExtensions
	** Capsulates helper extensions for the ReportingTab. 
	** Extends the StreamType class and String class.
	**----------------------------------------------------------------------------------------------*/
	public static partial class ReportingTabExtensions {


		/*------------------------------------------------------------------------------------------------
		** ToSmallImageResName
		** Get the resource name of a small image by the image's filename.
		**----------------------------------------------------------------------------------------------*/
		public static string ToSmallImageResName(this string imageFileName) {
			return "Images.Small_32bit." + imageFileName;
		}


		/*------------------------------------------------------------------------------------------------
		** ToLargeImageResName
		** Get the resource name of a large image by the image's filename.
		**----------------------------------------------------------------------------------------------*/
		public static string ToLargeImageResName(this string imageFileName) {
			return "Images.Large_32bit." + imageFileName;
		}

		/*------------------------------------------------------------------------------------------------
		** ToTxStreamType
		** Determines the StreamType by a file extension and returns this. Returns the WordprocessingML
		** StreamType as default value if none StreamType is defined for a file extension.
		**----------------------------------------------------------------------------------------------*/
		public static StreamType ToTxStreamType(this string fileExt) {
			if (fileExt.StartsWith(".")) fileExt = fileExt.Substring(1);
			switch (fileExt.ToLower()) {
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
			}

			// Default to DOCX
			return StreamType.WordprocessingML;
		}


		/*------------------------------------------------------------------------------------------------
		** ToTxStreamType
		** Determines the file extension by the streamtype and returns this. Returns the file extension
		** '.docx' if none file extension is defined for this StreamType.
		**----------------------------------------------------------------------------------------------*/
		public static string ToFilterString(this StreamType streamType) {
			switch (streamType) {
				case StreamType.AdobePDF:
				case StreamType.AdobePDFA:
					return Properties.Resources.APP_MENU_SAVE_AS_PDF + "|*.pdf";

				case StreamType.HTMLFormat:
					return Properties.Resources.APP_MENU_SAVE_AS_HTML + "|*.htm;*.html";

				case StreamType.InternalFormat:
				case StreamType.InternalUnicodeFormat:
					return Properties.Resources.APP_MENU_SAVE_AS_TX + "|*.tx";

				case StreamType.MSWord:
					return Properties.Resources.APP_MENU_SAVE_AS_DOC + "|*.doc";

				case StreamType.PlainAnsiText:
				case StreamType.PlainText:
					return Properties.Resources.APP_MENU_SAVE_AS_TXT + "|*.txt";

				case StreamType.RichTextFormat:
					return Properties.Resources.APP_MENU_SAVE_AS_RTF + "|*.rtf";

				case StreamType.WordprocessingML:
					return Properties.Resources.APP_MENU_SAVE_AS_DOCX + "|*.docx";
			}

			// Default to DOCX
			return Properties.Resources.APP_MENU_SAVE_AS_DOCX + "|*.docx";
		}


		/*------------------------------------------------------------------------------------------------
		** ToFileExt
		** Determines the file extension by the streamtype and returns this. Returns an empty string if
		** none file extension is defined for the streamtype.
		**----------------------------------------------------------------------------------------------*/
		public static string ToFileExt(this StreamType streamType) {
			switch (streamType) {
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
			}

			return "";
		}
	}


}
