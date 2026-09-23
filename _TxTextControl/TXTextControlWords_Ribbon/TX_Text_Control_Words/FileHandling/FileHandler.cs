using System;
using System.Collections.Specialized;
using System.ComponentModel;
using System.IO;
using TX_Text_Control_Words.Properties;
using TXTextControl;

namespace TX_Text_Control_Words.FileHandling
{
	public class FileHandler : INotifyPropertyChanged
	{
		private TextControl m_textControl;

		private bool m_isDocumentDirty;

		private string m_documentFileName = "";

		private StringCollection m_recentFiles;

		private int m_maxRecentFiles = 10;

		private StreamType m_streamType = StreamType.InternalUnicodeFormat;

		private bool m_CanSave;

		private string m_masterPassword = "";

		private string m_pdfUserPwd = "";

		private const StreamType DefaultSaveTypes = StreamType.InternalFormat | StreamType.HTMLFormat | StreamType.RichTextFormat | StreamType.PlainText | StreamType.InternalUnicodeFormat | StreamType.MSWord | StreamType.AdobePDF | StreamType.WordprocessingML | StreamType.AdobePDFA;

		private const StreamType DefaultExportTypes = StreamType.CascadingStylesheet | StreamType.AdobePDF | StreamType.AdobePDFA;

		private const StreamType DefaultLoadTypes = StreamType.PlainAnsiText | StreamType.InternalFormat | StreamType.HTMLFormat | StreamType.RichTextFormat | StreamType.PlainText | StreamType.InternalUnicodeFormat | StreamType.MSWord | StreamType.XMLFormat | StreamType.AdobePDF | StreamType.WordprocessingML | StreamType.AdobePDFA | StreamType.SpreadsheetML;

		private const StreamType DefaultInsertTypes = StreamType.PlainAnsiText | StreamType.InternalFormat | StreamType.HTMLFormat | StreamType.RichTextFormat | StreamType.PlainText | StreamType.InternalUnicodeFormat | StreamType.MSWord | StreamType.XMLFormat | StreamType.WordprocessingML | StreamType.SpreadsheetML;

		public bool CanSave
		{
			get
			{
				return this.m_CanSave;
			}
			private set
			{
				this.m_CanSave = value;
				this.OnPropertyChanged("CanSave");
			}
		}

		public StreamType StreamType
		{
			get
			{
				return this.m_streamType;
			}
			private set
			{
				this.m_streamType = value;
				this.OnPropertyChanged("StreamType");
			}
		}

		public bool IsDocumentDirty
		{
			get
			{
				return this.m_isDocumentDirty;
			}
			set
			{
				this.SetDocumentDirty(value);
				this.OnPropertyChanged("IsDocumentDirty");
			}
		}

		public string CssFileName { get; set; }

		public CssSaveMode CssSaveMode { get; set; }

		public string PDFUserPassword
		{
			get
			{
				return this.m_pdfUserPwd;
			}
			set
			{
				this.m_pdfUserPwd = value;
			}
		}

		public PDFImportSettings PDFImportSettings { get; set; }

		public string PDFCertPasswd { get; set; }

		public string PDFCertFilePath { get; set; }

		public DigitalSignature PDFSignature { get; set; }

		public bool IsDocTargetBased { get; private set; }

		public int MaxRecentFiles
		{
			get
			{
				return this.m_maxRecentFiles;
			}
			set
			{
				if (value < 1)
				{
					throw new IndexOutOfRangeException();
				}
				this.m_maxRecentFiles = value;
				int count = this.m_recentFiles.Count;
				this.TrimRecentFilesList();
				if (this.m_recentFiles.Count < count)
				{
					this.OnRecentFileListChanged();
				}
			}
		}

		public StringCollection RecentFiles
		{
			get
			{
				return this.m_recentFiles;
			}
			set
			{
				this.m_recentFiles = value ?? new StringCollection();
				this.TrimRecentFilesList();
				this.OnRecentFileListChanged();
			}
		}

		public string DocumentFileName
		{
			get
			{
				return this.m_documentFileName;
			}
			private set
			{
				value = value ?? "";
				string documentFileName = this.m_documentFileName;
				this.m_documentFileName = value;
				if (value != documentFileName)
				{
					this.OnDocumentFileNameChanged(value);
				}
			}
		}

		public string DocumentTitle
		{
			get
			{
				if (!string.IsNullOrEmpty(this.m_documentFileName))
				{
					return Path.GetFileName(this.m_documentFileName);
				}
				return Resources.DOC_TITLE_UNTITLED;
			}
		}

		public event PropertyChangedEventHandler PropertyChanged;

		public event EventHandler<ShowMessageBoxEventArgs> ShowMessageBox;

		public event EventHandler<DocumentDirtyChangedEventArgs> DocumentDirtyChanged;

		public event EventHandler<DocumentFileNameChangedEventArgs> DocumentFileNameChanged;

		public event EventHandler RecentFileListChanged;

		public event EventHandler<UserInputRequestedEventArgs> UserInputRequested;

		protected void OnPropertyChanged(string name)
		{
			this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
		}

		public FileHandler(TextControl textControl)
		{
			this.m_textControl = textControl;
			this.CssFileName = "";
			this.CssSaveMode = CssSaveMode.None;
			this.DocumentFileName = "";
			this.PDFCertFilePath = "";
			this.PDFCertPasswd = "";
			this.PDFUserPassword = "";
			this.m_recentFiles = new StringCollection();
			this.PDFImportSettings = PDFImportSettings.GenerateTextFrames | PDFImportSettings.LoadEmbeddedFiles;
			this.PropertyChanged += delegate(object sender, PropertyChangedEventArgs propargs)
			{
				if (propargs.PropertyName == "StreamType" || propargs.PropertyName == "IsDocumentDirty")
				{
					this.RefreshCanSave();
				}
			};
		}

		private string GetNotAvailableFileFormatMessage(LicenseLevelException exc)
		{
			string fILEHANDLER_MSGTEMPLATE_NAFILEFORMAT = Resources.FILEHANDLER_MSGTEMPLATE_NAFILEFORMAT;
			VersionInfo versionInfo = this.m_textControl.GetVersionInfo();
			string text = string.Format(fILEHANDLER_MSGTEMPLATE_NAFILEFORMAT, versionInfo.Level.ToString());
			string text2 = exc.Message.Remove(0, exc.Message.IndexOf('.') + 1);
			return text + text2;
		}

		public void OpenRecentFile(string fileName)
		{
			if (File.Exists(fileName))
			{
				this.Open(fileName);
				return;
			}
			ShowMessageBoxEventArgs showMessageBoxEventArgs = new ShowMessageBoxEventArgs(Resources.MSG_REMOVE_FILE_FROM_LIST, MessageBoxButton.YesNo, MessageBoxIcon.Question);
			this.OnShowMessageBox(showMessageBoxEventArgs);
			if (showMessageBoxEventArgs.DialogResult == DialogResult.Yes)
			{
				this.RemoveRecentFile(fileName);
			}
		}

		public void Open(string fileName = "", bool bKeepPdfSecSettings = false)
		{
			if (!bKeepPdfSecSettings && !this.HandleUnsavedChanges())
			{
				return;
			}
			var anon = new { this.PDFCertFilePath, this.PDFCertPasswd, this.PDFUserPassword, this.PDFSignature };
			if (!bKeepPdfSecSettings)
			{
				this.PDFCertFilePath = "";
				this.PDFCertPasswd = "";
				this.PDFUserPassword = "";
				this.PDFSignature = null;
			}
			LoadSettings loadSettings = new LoadSettings
			{
				ApplicationFieldFormat = ApplicationFieldFormat.MSWordTXFormFields,
				LoadSubTextParts = true,
				PDFImportSettings = this.PDFImportSettings,
				UserPassword = this.PDFUserPassword,
				ReportingMergeBlockFormat = ReportingMergeBlockFormat.SubTextParts,
				DocumentPartName = string.Empty
			};
			try
			{
				if (string.IsNullOrEmpty(fileName))
				{
					this.m_textControl.Load(StreamType.PlainAnsiText | StreamType.InternalFormat | StreamType.HTMLFormat | StreamType.RichTextFormat | StreamType.PlainText | StreamType.InternalUnicodeFormat | StreamType.MSWord | StreamType.XMLFormat | StreamType.AdobePDF | StreamType.WordprocessingML | StreamType.AdobePDFA | StreamType.SpreadsheetML, loadSettings);
				}
				else
				{
					if (!File.Exists(fileName))
					{
						ShowMessageBoxEventArgs e = new ShowMessageBoxEventArgs(string.Format(Resources.MSG_FILE_DOES_NOT_EXIST, fileName), MessageBoxButton.OK, MessageBoxIcon.Error);
						this.OnShowMessageBox(e);
						return;
					}
					string extension = Path.GetExtension(fileName);
					StreamType streamType = extension.ToTXStreamType();
					if (streamType == (StreamType)(-1))
					{
						this.OnShowMessageBox(new ShowMessageBoxEventArgs(string.Format(Resources.MSG_UNKNOWN_FILE_TYPE, extension), MessageBoxButton.OK, MessageBoxIcon.Information));
						return;
					}
					this.m_textControl.Load(fileName, streamType, loadSettings);
				}
			}
			catch (FilterException exc)
			{
				if (string.IsNullOrEmpty(fileName))
				{
					fileName = loadSettings.LoadedFile;
				}
				this.HandleFilterException(exc, fileName);
				return;
			}
			catch (LicenseLevelException exc2)
			{
				string notAvailableFileFormatMessage = this.GetNotAvailableFileFormatMessage(exc2);
				this.OnShowMessageBox(new ShowMessageBoxEventArgs(notAvailableFileFormatMessage, MessageBoxButton.OK, MessageBoxIcon.Information));
				return;
			}
			catch (MergeBlockConversionException exc3)
			{
				this.HandleMergeBlockConversionException(exc3);
			}
			catch (Exception ex)
			{
				this.OnShowMessageBox(new ShowMessageBoxEventArgs(ex.Message, MessageBoxButton.OK, MessageBoxIcon.Information));
				return;
			}
			if (!string.IsNullOrEmpty(loadSettings.LoadedFile))
			{
				this.DocumentFileName = loadSettings.LoadedFile;
				this.IsDocTargetBased = loadSettings.ConvertedMergeBlocks > 0;
				this.StreamType = loadSettings.LoadedStreamType;
				this.IsDocumentDirty = false;
				this.CssFileName = loadSettings.CssFileName;
				this.CssSaveMode = CssSaveMode.None;
				this.AddRecentFile(loadSettings.LoadedFile);
				this.m_masterPassword = loadSettings.MasterPassword;
				this.PDFUserPassword = loadSettings.UserPassword;
			}
			else if (!bKeepPdfSecSettings)
			{
				this.PDFCertFilePath = anon.PDFCertFilePath;
				this.PDFCertPasswd = anon.PDFCertPasswd;
				this.PDFUserPassword = anon.PDFUserPassword;
				this.PDFSignature = anon.PDFSignature;
			}
		}

		public void Insert()
		{
			LoadSettings loadSettings = new LoadSettings
			{
				ApplicationFieldFormat = ApplicationFieldFormat.MSWordTXFormFields,
				LoadSubTextParts = true,
				DocumentPartName = ""
			};
			this.m_textControl.Selection.Load(StreamType.PlainAnsiText | StreamType.InternalFormat | StreamType.HTMLFormat | StreamType.RichTextFormat | StreamType.PlainText | StreamType.InternalUnicodeFormat | StreamType.MSWord | StreamType.XMLFormat | StreamType.WordprocessingML | StreamType.SpreadsheetML, loadSettings);
			if (loadSettings.LoadedFile != "")
			{
				this.IsDocumentDirty = true;
			}
		}

		private void RefreshCanSave()
		{
			this.CanSave = this.m_isDocumentDirty && (this.StreamType & (StreamType.InternalFormat | StreamType.HTMLFormat | StreamType.RichTextFormat | StreamType.PlainText | StreamType.InternalUnicodeFormat | StreamType.MSWord | StreamType.AdobePDF | StreamType.WordprocessingML | StreamType.AdobePDFA)) == this.StreamType;
		}

		public bool Save()
		{
			if (!this.CanSave)
			{
				return false;
			}
			if (!this.TryDetermineMergeBlockSaveFormat(out var blockFormat))
			{
				return false;
			}
			SaveSettings saveSettings = new SaveSettings
			{
				CssFileName = this.CssFileName,
				CssSaveMode = this.CssSaveMode,
				LastModificationDate = DateTime.Now,
				MasterPassword = this.m_masterPassword,
				ReportingMergeBlockFormat = blockFormat,
				UserPassword = this.PDFUserPassword
			};
			if (this.PDFSignature != null)
			{
				saveSettings.DigitalSignature = this.PDFSignature;
			}
			try
			{
				if (!string.IsNullOrEmpty(this.m_documentFileName))
				{
					this.m_textControl.Save(this.m_documentFileName, this.StreamType, saveSettings);
				}
				else
				{
					this.m_textControl.Save(StreamType.InternalFormat | StreamType.HTMLFormat | StreamType.RichTextFormat | StreamType.PlainText | StreamType.InternalUnicodeFormat | StreamType.MSWord | StreamType.AdobePDF | StreamType.WordprocessingML | StreamType.AdobePDFA, saveSettings);
				}
			}
			catch (LicenseLevelException exc)
			{
				string notAvailableFileFormatMessage = this.GetNotAvailableFileFormatMessage(exc);
				this.OnShowMessageBox(new ShowMessageBoxEventArgs(notAvailableFileFormatMessage, MessageBoxButton.OK, MessageBoxIcon.Error));
			}
			catch (Exception ex)
			{
				this.OnShowMessageBox(new ShowMessageBoxEventArgs(ex.Message, MessageBoxButton.OK, MessageBoxIcon.Error));
			}
			if (!string.IsNullOrEmpty(saveSettings.SavedFile))
			{
				this.DocumentFileName = saveSettings.SavedFile;
				this.StreamType = saveSettings.SavedStreamType;
				this.IsDocumentDirty = false;
				this.AddRecentFile(this.m_documentFileName);
				return true;
			}
			return false;
		}

		public void SaveAs(StreamType? streamType = null)
		{
			if (this.TryDetermineMergeBlockSaveFormat(out var blockFormat))
			{
				SaveSettings saveSettings = new SaveSettings
				{
					CssFileName = this.CssFileName,
					CssSaveMode = this.CssSaveMode,
					MasterPassword = this.m_masterPassword,
					ReportingMergeBlockFormat = blockFormat,
					UserPassword = this.PDFUserPassword
				};
				if (this.PDFSignature != null)
				{
					saveSettings.DigitalSignature = this.PDFSignature;
				}
				streamType = streamType ?? (StreamType.InternalFormat | StreamType.HTMLFormat | StreamType.RichTextFormat | StreamType.PlainText | StreamType.InternalUnicodeFormat | StreamType.MSWord | StreamType.AdobePDF | StreamType.WordprocessingML | StreamType.AdobePDFA);
				try
				{
					this.m_textControl.Save(streamType.Value, saveSettings);
				}
				catch (LicenseLevelException exc)
				{
					string notAvailableFileFormatMessage = this.GetNotAvailableFileFormatMessage(exc);
					this.OnShowMessageBox(new ShowMessageBoxEventArgs(notAvailableFileFormatMessage, MessageBoxButton.OK, MessageBoxIcon.Error));
				}
				catch (Exception ex)
				{
					this.OnShowMessageBox(new ShowMessageBoxEventArgs(ex.Message, MessageBoxButton.OK, MessageBoxIcon.Error));
				}
				if (!string.IsNullOrEmpty(saveSettings.SavedFile))
				{
					this.DocumentFileName = saveSettings.SavedFile;
					this.StreamType = saveSettings.SavedStreamType;
					this.IsDocumentDirty = false;
					this.AddRecentFile(this.m_documentFileName);
				}
			}
		}

		public bool New()
		{
			if (!this.HandleUnsavedChanges())
			{
				return false;
			}
			this.m_textControl.ResetContents();
			this.IsDocumentDirty = false;
			this.DocumentFileName = "";
			this.IsDocTargetBased = false;
			this.PDFUserPassword = "";
			this.PDFCertFilePath = "";
			this.PDFCertPasswd = "";
			this.PDFSignature = null;
			this.m_masterPassword = "";
			return true;
		}

		public bool ExitApplication()
		{
			return this.HandleUnsavedChanges();
		}

		public bool HandleUnsavedChanges()
		{
			if (this.IsDocumentDirty)
			{
				ShowMessageBoxEventArgs showMessageBoxEventArgs = new ShowMessageBoxEventArgs(string.Format(Resources.SAVE_CHANGES_TO, this.DocumentTitle), MessageBoxButton.YesNoCancel, MessageBoxIcon.Question);
				this.OnShowMessageBox(showMessageBoxEventArgs);
				switch (showMessageBoxEventArgs.DialogResult)
				{
				case DialogResult.Cancel:
					return false;
				case DialogResult.Yes:
					if (this.CanSave)
					{
						this.Save();
					}
					else
					{
						this.SaveAs();
					}
					if (string.IsNullOrEmpty(this.m_documentFileName))
					{
						return false;
					}
					break;
				}
			}
			return true;
		}

		internal void RemoveRecentFile(string path)
		{
			int count = this.m_recentFiles.Count;
			this.m_recentFiles.Remove(path);
			if (this.m_recentFiles.Count < count)
			{
				this.OnRecentFileListChanged();
			}
		}

		protected virtual void OnShowMessageBox(ShowMessageBoxEventArgs e)
		{
			if (this.ShowMessageBox != null)
			{
				this.ShowMessageBox(this, e);
			}
		}

		protected virtual void OnDocumentDirtyChanged(bool newValue)
		{
			if (this.DocumentDirtyChanged != null)
			{
				this.DocumentDirtyChanged(this, new DocumentDirtyChangedEventArgs(newValue));
			}
		}

		protected void OnDocumentFileNameChanged(string newName)
		{
			if (this.DocumentFileNameChanged != null)
			{
				this.DocumentFileNameChanged(this, new DocumentFileNameChangedEventArgs(newName));
			}
		}

		protected virtual void OnRecentFileListChanged()
		{
			if (this.RecentFileListChanged != null)
			{
				this.RecentFileListChanged(this, EventArgs.Empty);
			}
		}

		protected virtual void OnUserInputRequested(UserInputRequestedEventArgs e)
		{
			if (this.UserInputRequested != null)
			{
				this.UserInputRequested(this, e);
			}
		}

		private void SetDocumentDirty(bool value)
		{
			bool isDocumentDirty = this.m_isDocumentDirty;
			this.m_isDocumentDirty = value;
			if (value != isDocumentDirty)
			{
				this.OnDocumentDirtyChanged(value);
			}
		}

		private void AddRecentFile(string fileName)
		{
			for (int num = this.m_recentFiles.Count - 1; num >= 0; num--)
			{
				if (this.m_recentFiles[num].ToLower() == fileName.ToLower())
				{
					this.m_recentFiles.RemoveAt(num);
					break;
				}
			}
			this.m_recentFiles.Insert(0, fileName);
			this.TrimRecentFilesList();
			this.OnRecentFileListChanged();
		}

		private void TrimRecentFilesList()
		{
			while (this.m_recentFiles.Count > this.m_maxRecentFiles)
			{
				this.m_recentFiles.RemoveAt(this.m_recentFiles.Count - 1);
			}
		}

		private void HandleFilterException(FilterException exc, string fileName)
		{
			if (exc.Reason == FilterException.FilterError.InvalidPassword)
			{
				UserInputRequestedEventArgs userInputRequestedEventArgs = new UserInputRequestedEventArgs(this.PDFUserPassword, Resources.USR_INP_PASSWORD_TITLE, Resources.USR_INP_PASSWORD_LABEL, isPasswordRequest: true, UserInputRequestReason.PdfUserPassword);
				this.OnUserInputRequested(userInputRequestedEventArgs);
				switch (userInputRequestedEventArgs.DialogResult)
				{
				case DialogResult.OK:
					this.PDFUserPassword = userInputRequestedEventArgs.Value ?? "";
					this.Open(fileName, bKeepPdfSecSettings: true);
					return;
				case DialogResult.Cancel:
					return;
				}
			}
			this.OnShowMessageBox(new ShowMessageBoxEventArgs(exc.Message, MessageBoxButton.OK, MessageBoxIcon.Error));
		}

		private void HandleMergeBlockConversionException(MergeBlockConversionException exc)
		{
			string arg = string.Join("\r\n", exc.BlockNamesUnconverted.ToArray());
			ShowMessageBoxEventArgs e = new ShowMessageBoxEventArgs(string.Format(Resources.EXC_MERGE_BLOCK_CONVERSION, arg), MessageBoxButton.OK, MessageBoxIcon.Information);
			this.OnShowMessageBox(e);
		}

		internal bool? ConfirmSaveSubTextPartBlocks(StreamType streamType = (StreamType)0)
		{
			if ((streamType & (StreamType.InternalFormat | StreamType.RichTextFormat | StreamType.InternalUnicodeFormat | StreamType.MSWord | StreamType.WordprocessingML)) == 0)
			{
				return false;
			}
			ShowMessageBoxEventArgs showMessageBoxEventArgs = new ShowMessageBoxEventArgs(Resources.MSG_CONFIRM_UPDATE_MERGE_BLOCK_TYPE, MessageBoxButton.YesNoCancel, MessageBoxIcon.Question);
			this.OnShowMessageBox(showMessageBoxEventArgs);
			return showMessageBoxEventArgs.DialogResult switch
			{
				DialogResult.Yes => true, 
				DialogResult.No => false, 
				DialogResult.Cancel => null, 
				_ => false, 
			};
		}

		private bool TryDetermineMergeBlockSaveFormat(out ReportingMergeBlockFormat blockFormat)
		{
			blockFormat = ReportingMergeBlockFormat.SubTextParts;
			if (this.IsDocTargetBased)
			{
				bool? flag = this.ConfirmSaveSubTextPartBlocks(this.StreamType);
				if (flag == false)
				{
					blockFormat = ReportingMergeBlockFormat.DocumentTargets;
				}
				else if (!flag.HasValue)
				{
					return false;
				}
			}
			return true;
		}
	}
}
