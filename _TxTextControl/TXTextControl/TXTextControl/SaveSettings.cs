using System;
using System.IO;
using System.Runtime.InteropServices;
using ns21;

namespace TXTextControl
{
	/// <summary>The SaveSettings class provides properties for advanced settings and information during save operations.</summary>
	[Serializable]
	public sealed class SaveSettings : LoadSaveSettingsBase
	{
		private string string_0 = string.Empty;

		private long long_0;

		private DateTime dateTime_0 = new DateTime(0L);

		private string string_1 = string.Empty;

		private string string_2 = string.Empty;

		private CssSaveMode cssSaveMode_0;

		private DigitalSignature digitalSignature_0;

		private DocumentAccessPermissions documentAccessPermissions_0 = DocumentAccessPermissions.AllowAll;

		private string[] string_3;

		private string[] string_4;

		private string string_5 = string.Empty;

		private string string_6 = string.Empty;

		private int int_0;

		private int int_1;

		private int int_2;

		private ImageSaveMode imageSaveMode_0;

		private string string_7 = string.Empty;

		private DateTime dateTime_1 = new DateTime(0L);

		private OmittedContent omittedContent_0;

		private PageMargins pageMargins = new PageMargins(-1.0, -1.0, -1.0, -1.0);

		private PageSize pageSize_0 = new PageSize(0.0, 0.0);

		private bool bool_0 = true;

		private string string_8 = string.Empty;

		private StreamType streamType_0;

		private UserDefinedPropertyDictionary userDefinedPropertyDictionary_0;

		private bool bool_1;

		/// <summary>Sets the document's author which will be saved in the document.</summary>
		public string Author
		{
			get
			{
				return this.string_0;
			}
			set
			{
				this.string_0 = value;
			}
		}

		/// <summary>Gets the number of bytes written during a save operation.</summary>
		public long BytesWritten => this.long_0;

		/// <summary>Sets the document's creation date which will be saved in the document.</summary>
		public DateTime CreationDate
		{
			get
			{
				return this.dateTime_0;
			}
			set
			{
				this.dateTime_0 = value;
			}
		}

		/// <summary>Sets the application, which has created the document.</summary>
		public string CreatorApplication
		{
			get
			{
				return this.string_1;
			}
			set
			{
				this.string_1 = value;
			}
		}

		/// <summary>HTML only. Sets the path and filename of a CSS file belonging to a HTML document.</summary>
		public string CssFileName
		{
			get
			{
				return this.string_2;
			}
			set
			{
				this.string_2 = value;
			}
		}

		/// <summary>HTML only. Specifies how to save stylesheet data with a HTML document.</summary>
		public CssSaveMode CssSaveMode
		{
			get
			{
				return this.cssSaveMode_0;
			}
			set
			{
				this.cssSaveMode_0 = value;
			}
		}

		/// <summary>Specifies a DigitalSignature object, which defines an X.509 certificate.</summary>
		public DigitalSignature DigitalSignature
		{
			get
			{
				return this.digitalSignature_0;
			}
			set
			{
				this.digitalSignature_0 = value;
			}
		}

		/// <summary>Specifies how a document can be accessed after it has been opened.</summary>
		public DocumentAccessPermissions DocumentAccessPermissions
		{
			get
			{
				return this.documentAccessPermissions_0;
			}
			set
			{
				this.documentAccessPermissions_0 = value;
			}
		}

		/// <summary>Sets the document's keywords which will be saved in the document.</summary>
		public string[] DocumentKeywords
		{
			get
			{
				return this.string_3;
			}
			set
			{
				this.string_3 = value;
			}
		}

		/// <summary>Specifies an array of strings containing Javascript.</summary>
		public string[] DocumentLevelJavaScriptActions
		{
			get
			{
				return this.string_4;
			}
			set
			{
				this.string_4 = value;
			}
		}

		/// <summary>Sets the document's subject string which will be saved in the document.</summary>
		public string DocumentSubject
		{
			get
			{
				return this.string_5;
			}
			set
			{
				this.string_5 = value;
			}
		}

		/// <summary>Sets the document's title that will be saved in the document.</summary>
		public string DocumentTitle
		{
			get
			{
				return this.string_6;
			}
			set
			{
				this.string_6 = value;
			}
		}

		/// <summary>Sets a value between 1 and 100, which is the quality of a lossy image compression used when a document is saved.</summary>
		public int ImageCompressionQuality
		{
			get
			{
				return this.int_0;
			}
			set
			{
				this.int_0 = value;
			}
		}

		/// <summary>Sets the format used for saving all images contained in the document.</summary>
		public int ImageExportFilterIndex
		{
			get
			{
				return this.int_1;
			}
			set
			{
				this.int_1 = value;
			}
		}

		/// <summary>Sets the maximum resolution for all images in the document in dots per inch when the document is saved.</summary>
		public int ImageMaxResolution
		{
			get
			{
				return this.int_2;
			}
			set
			{
				this.int_2 = value;
			}
		}

		/// <summary>Determines whether the document's images are stored through its data or through its file reference.</summary>
		public ImageSaveMode ImageSaveMode
		{
			get
			{
				return this.imageSaveMode_0;
			}
			set
			{
				this.imageSaveMode_0 = value;
			}
		}

		/// <summary>Sets a file path that is used to save resources like images when images are saved as file link.</summary>
		public string ImageSavePath
		{
			get
			{
				return this.string_7;
			}
			set
			{
				this.string_7 = value;
			}
		}

		/// <summary>Sets the date the document is last modified.</summary>
		public DateTime LastModificationDate
		{
			get
			{
				return this.dateTime_1;
			}
			set
			{
				this.dateTime_1 = value;
			}
		}

		/// <summary>Specifies data to be omitted when the document is saved.</summary>
		public OmittedContent OmittedContent
		{
			get
			{
				return this.omittedContent_0;
			}
			set
			{
				this.omittedContent_0 = value;
			}
		}

		/// <summary>Sets the margins saved for the document's pages.</summary>
		public PageMargins PageMargins
		{
			set
			{
				value.method_3(this.pageMargins);
			}
		}

		/// <summary>Sets the width and height saved for the document's pages.</summary>
		public PageSize PageSize
		{
			set
			{
				this.pageSize_0 = value;
			}
		}

		/// <summary>Specifies whether or not the document background color is saved.</summary>
		public bool SaveDocumentBackColor
		{
			get
			{
				return this.bool_0;
			}
			set
			{
				this.bool_0 = value;
			}
		}

		/// <summary>Read only. Gets the name and path of the file that has been saved.</summary>
		public string SavedFile => this.string_8;

		/// <summary>Read only. Gets the StreamType of the file that has been saved.</summary>
		public StreamType SavedStreamType => this.streamType_0;

		/// <summary>Sets a dictionary with all user-defined document properties which will be saved in the document.</summary>
		public UserDefinedPropertyDictionary UserDefinedDocumentProperties
		{
			get
			{
				return this.userDefinedPropertyDictionary_0;
			}
			set
			{
				this.userDefinedPropertyDictionary_0 = value;
			}
		}

		internal bool Boolean_0
		{
			set
			{
				this.bool_1 = value;
			}
		}

		internal bool method_0(StreamType streamType_1, TextControlCore textControlCore_0, Enum104 enum104_0)
		{
			bool result = false;
			string strFileName = string.Empty;
			if (textControlCore_0 != null && textControlCore_0.isHandleCreated)
			{
				ITextControl textControl = textControlCore_0.GetTextControl();
				if (textControl.FileFilterIndex != 0)
					streamType_1 = StreamType.InternalUnicodeFormat;

				int iFilterIndex = textControl.SaveFileDialog(base.GetFilterString(streamType_1), out strFileName);
				if (strFileName.Length > 0)
				{
					this.method_1(strFileName, base.StreamTypeFromFilterIndex(iFilterIndex, streamType_1), textControlCore_0, enum104_0);
					result = true;
				}
				return result;
			}
			throw new InvalidOperationException(base.m_rm.GetString("ERR_NOTLOADED"));
		}

		internal void method_1(string string_9, StreamType streamType_1, TextControlCore textControlCore_0, Enum104 enum104_0)
		{
			if (textControlCore_0 != null && textControlCore_0.isHandleCreated)
			{
				if (string_9.Length == 0)
				{
					return;
				}
				FileStream fileStream = new FileStream(string_9, FileMode.OpenOrCreate, FileAccess.Write, FileShare.None);
				try
				{
					this.method_2(fileStream, streamType_1, textControlCore_0, enum104_0);
					this.string_8 = string_9;
					this.streamType_0 = streamType_1;
				}
				catch (Exception ex)
				{
					throw ex;
				}
				finally
				{
					fileStream.Close();
				}
				return;
			}
			throw new InvalidOperationException(base.m_rm.GetString("ERR_NOTLOADED"));
		}

		internal void method_2(FileStream fileStream_0, StreamType streamType_1, TextControlCore textControlCore_0, Enum104 enum104_0)
		{
			if (textControlCore_0 != null && textControlCore_0.isHandleCreated)
			{
				textControlCore_0.GetTextControl().CheckStreamType(streamType_1);
				Struct53 struct53_ = new Struct53(enum104_0);
				byte[] byte_ = null;
				try
				{
					if (base.m_iReportingMergeBlockFormat == ReportingMergeBlockFormat.DocumentTargets && MergeBlockConverter.IsMergeBlockSaveable(streamType_1))
					{
						new SaveSettings().method_3(out byte_, BinaryStreamType.InternalUnicodeFormat, textControlCore_0, Enum104.const_0);
						textControlCore_0.method_14(TextPart.Auto, 0, 0);
						if (!MergeBlockConverter.SubTextPartsToDocumentTargets(textControlCore_0))
						{
							byte_ = null;
						}
					}
					struct53_.safeFileHandle_0 = fileStream_0.SafeFileHandle;
					struct53_.ushort_1 = base.GetTxFormat(streamType_1);
					this.method_5(ref struct53_, textControlCore_0, fileStream_0.Name, streamType_1);
					textControlCore_0.method_46(base.m_iTextPart, 1626, 0, ref struct53_);
					this.method_6(struct53_);
				}
				catch (Exception ex)
				{
					throw ex;
				}
				finally
				{
					struct53_.method_0();
					if (base.m_iReportingMergeBlockFormat == ReportingMergeBlockFormat.DocumentTargets && MergeBlockConverter.IsMergeBlockSaveable(streamType_1))
					{
						if (byte_ != null)
						{
							new LoadSettings().method_3(byte_, BinaryStreamType.InternalUnicodeFormat, textControlCore_0, Enum104.const_0, null);
						}
						textControlCore_0.method_15(TextPart.Auto);
					}
				}
				return;
			}
			throw new InvalidOperationException(base.m_rm.GetString("ERR_NOTLOADED"));
		}

		internal void method_3(out byte[] byte_0, BinaryStreamType binaryStreamType_0, TextControlCore textControlCore_0, Enum104 enum104_0)
		{
			if (textControlCore_0 != null && textControlCore_0.isHandleCreated)
			{
				textControlCore_0.GetTextControl().CheckStreamType((StreamType)binaryStreamType_0);
				Struct53 struct53_ = new Struct53(enum104_0);
				byte_0 = null;
				try
				{
					struct53_.ushort_1 = base.GetTxFormat((StreamType)binaryStreamType_0);
					this.method_5(ref struct53_, textControlCore_0, string.Empty, (StreamType)binaryStreamType_0);
					textControlCore_0.method_46(base.m_iTextPart, 1626, 0, ref struct53_);
					this.method_6(struct53_);
					if (struct53_.intptr_2 != IntPtr.Zero)
					{
						byte_0 = new byte[struct53_.uint_1];
						Marshal.Copy(Class429.GlobalLock(struct53_.intptr_2), byte_0, 0, (int)struct53_.uint_1);
					}
				}
				catch (Exception ex)
				{
					throw ex;
				}
				finally
				{
					struct53_.method_0();
				}
				return;
			}
			throw new InvalidOperationException(base.m_rm.GetString("ERR_NOTLOADED"));
		}

		internal void method_4(out string string_9, StringStreamType stringStreamType_0, TextControlCore textControlCore_0, Enum104 enum104_0)
		{
			if (textControlCore_0 != null && textControlCore_0.isHandleCreated)
			{
				textControlCore_0.GetTextControl().CheckStreamType((StreamType)stringStreamType_0);
				Struct53 struct53_ = new Struct53(enum104_0);
				string_9 = null;
				try
				{
					struct53_.ushort_1 = base.GetTxFormat((StreamType)stringStreamType_0);
					this.method_5(ref struct53_, textControlCore_0, string.Empty, (StreamType)stringStreamType_0);
					textControlCore_0.method_46(base.m_iTextPart, 1626, 0, ref struct53_);
					this.method_6(struct53_);
					if (struct53_.intptr_2 != IntPtr.Zero)
					{
						switch (stringStreamType_0)
						{
						case StringStreamType.RichTextFormat:
						case StringStreamType.XMLFormat:
						case StringStreamType.CascadingStylesheet:
							string_9 = Marshal.PtrToStringAnsi(Class429.GlobalLock(struct53_.intptr_2));
							break;
						case StringStreamType.HTMLFormat:
						case StringStreamType.PlainText:
							string_9 = Marshal.PtrToStringUni(Class429.GlobalLock(struct53_.intptr_2));
							break;
						}
					}
				}
				catch (Exception ex)
				{
					throw ex;
				}
				finally
				{
					struct53_.method_0();
				}
				return;
			}
			throw new InvalidOperationException(base.m_rm.GetString("ERR_NOTLOADED"));
		}

		private void method_5(ref Struct53 struct53_0, TextControlCore textControlCore_0, string string_9, StreamType streamType_1)
		{
			Struct54 @struct = new Struct54(0);
			if (string_9.Length > 0)
			{
				@struct.intptr_4 = Marshal.StringToBSTR(string_9);
			}
			if (this.string_7.Length > 0)
			{
				@struct.intptr_0 = Marshal.StringToBSTR(this.string_7);
			}
			if (base.m_strDocumentBasePath.Length > 0)
			{
				@struct.intptr_1 = Marshal.StringToBSTR(base.m_strDocumentBasePath);
			}
			if (this.string_6.Length > 0)
			{
				@struct.intptr_2 = Marshal.StringToHGlobalUni(this.string_6);
			}
			if (this.string_2.Length > 0)
			{
				@struct.intptr_8 = Marshal.StringToHGlobalUni(this.string_2);
			}
			@struct.enum119_0 |= (Struct54.Enum119)this.cssSaveMode_0;
			@struct.ushort_3 = (ushort)this.int_0;
			@struct.ushort_6 = (ushort)this.int_1;
			@struct.ushort_4 = (ushort)this.int_2;
			@struct.uint_6 = (uint)this.documentAccessPermissions_0;
			if (base.m_strMasterPassword.Length > 0)
			{
				@struct.intptr_10 = Marshal.StringToBSTR(base.m_strMasterPassword);
			}
			if (base.m_strUserPassword.Length > 0)
			{
				@struct.intptr_11 = Marshal.StringToBSTR(base.m_strUserPassword);
			}
			if (this.imageSaveMode_0 == ImageSaveMode.SaveAsData)
			{
				@struct.enum119_0 |= Struct54.Enum119.const_20;
			}
			if (this.imageSaveMode_0 == ImageSaveMode.SaveAsFileReference)
			{
				@struct.enum119_0 |= Struct54.Enum119.const_21;
			}
			ITextControl tc = textControlCore_0.GetTextControl();
			@struct.int_0 = TwipsConverter.DotNet2Tw((this.pageSize_0.Width != 0.0) ? this.pageSize_0.Width : tc.GetPageSize().Width, textControlCore_0.MeasuringUnit_0);
			@struct.int_1 = TwipsConverter.DotNet2Tw((this.pageSize_0.Height != 0.0) ? this.pageSize_0.Height : tc.GetPageSize().Height, textControlCore_0.MeasuringUnit_0);
			@struct.short_1 = (short)TwipsConverter.DotNet2Tw((this.pageMargins.Left != -1.0) ? this.pageMargins.Left : tc.GetPageMargins().Left, textControlCore_0.MeasuringUnit_0);
			@struct.short_2 = (short)TwipsConverter.DotNet2Tw((this.pageMargins.Top != -1.0) ? this.pageMargins.Top : tc.GetPageMargins().Top, textControlCore_0.MeasuringUnit_0);
			@struct.short_3 = (short)TwipsConverter.DotNet2Tw((this.pageMargins.Right != -1.0) ? this.pageMargins.Right : tc.GetPageMargins().Right, textControlCore_0.MeasuringUnit_0);
			@struct.short_4 = (short)TwipsConverter.DotNet2Tw((this.pageMargins.Bottom != -1.0) ? this.pageMargins.Bottom : tc.GetPageMargins().Bottom, textControlCore_0.MeasuringUnit_0);
			if (this.bool_0)
			{
				@struct.uint_0 = textControlCore_0.GetTextControl().GetDocumentBackColor();
			}
			if (this.bool_1)
			{
				@struct.enum119_0 |= Struct54.Enum119.const_15;
			}
			if (streamType_1 == StreamType.AdobePDFA)
			{
				@struct.enum119_0 |= Struct54.Enum119.const_18;
			}
			if (struct53_0.safeFileHandle_0.IsInvalid && streamType_1 == StreamType.HTMLFormat)
			{
				@struct.enum119_0 |= Struct54.Enum119.const_19;
			}
			if (this.digitalSignature_0 != null && this.digitalSignature_0.x509Certificate2_0 != null)
			{
				@struct.intptr_16 = this.digitalSignature_0.x509Certificate2_0.Handle;
				if (this.digitalSignature_0.string_0 != null && this.digitalSignature_0.string_0 != "")
				{
					@struct.intptr_17 = Marshal.StringToBSTR(this.digitalSignature_0.string_0);
				}
			}
			if (this.string_4 != null)
			{
				char[] array = KernelHelper.StringArray2CharArray(this.string_4);
				@struct.intptr_18 = Marshal.AllocHGlobal(array.Length * 2);
				Marshal.Copy(array, 0, @struct.intptr_18, array.Length);
			}
			if (this.dateTime_0.Year != 1 || this.dateTime_1.Year != 1 || this.string_0 != string.Empty || this.string_5 != string.Empty || this.string_1 != string.Empty || this.string_3 != null)
			{
				string[] array2 = new string[6]
				{
					KernelHelper.UTCStringFromDateTime(this.dateTime_0),
					KernelHelper.UTCStringFromDateTime(this.dateTime_1),
					this.string_0,
					this.string_5,
					this.string_1,
					(this.string_3 == null) ? string.Empty : string.Join("\t", this.string_3)
				};
				char[] array3 = KernelHelper.StringArray2CharArray(array2);
				@struct.intptr_19 = Marshal.AllocHGlobal(array3.Length * 2);
				Marshal.Copy(array3, 0, @struct.intptr_19, array3.Length);
			}
			if (this.userDefinedPropertyDictionary_0 != null && this.userDefinedPropertyDictionary_0.Count > 0)
			{
				@struct.intptr_20 = this.userDefinedPropertyDictionary_0.method_1();
			}
			if (base.m_arEmbeddedFiles != null && base.m_arEmbeddedFiles.Length > 0)
			{
				Struct80 struct2 = new Struct80(base.m_arEmbeddedFiles.Length);
				int num = Marshal.SizeOf((object)struct2);
				EmbeddedFile[] arEmbeddedFiles = base.m_arEmbeddedFiles;
				foreach (EmbeddedFile embeddedFile in arEmbeddedFiles)
				{
					num += embeddedFile.GetUnmanagedBufferSize();
				}
				@struct.intptr_23 = Marshal.AllocHGlobal(num);
				Marshal.StructureToPtr((object)struct2, @struct.intptr_23, fDeleteOld: false);
				num = Marshal.SizeOf((object)struct2);
				EmbeddedFile[] arEmbeddedFiles2 = base.m_arEmbeddedFiles;
				foreach (EmbeddedFile embeddedFile2 in arEmbeddedFiles2)
				{
					num += embeddedFile2.method_0(new IntPtr(@struct.intptr_23.ToInt64() + num));
				}
			}
			struct53_0.uint_0 |= (uint)this.omittedContent_0;
			Marshal.StructureToPtr((object)@struct, struct53_0.intptr_4, fDeleteOld: false);
		}

		private void method_6(Struct53 struct53_0)
		{
			this.long_0 = struct53_0.uint_1;
		}
	}
}
