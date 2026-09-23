using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using ns21;

namespace TXTextControl
{
	/// <summary>The LoadSettings class provides properties for advanced settings and information during load operations.</summary>
	[Serializable]
	public sealed class LoadSettings : LoadSaveSettingsBase
	{
		private bool bool_0;

		private ApplicationFieldFormat applicationFieldFormat_0;

		private string[] string_0;

		private string string_1 = string.Empty;

		private long long_0;

		private int int_0;

		private DateTime dateTime_0 = new DateTime(0L);

		private string string_2 = string.Empty;

		private string string_3 = string.Empty;

		private DocumentAccessPermissions documentAccessPermissions_0 = DocumentAccessPermissions.AllowAll;

		private string[] string_4;

		private string string_5;

		private string string_6 = string.Empty;

		private string string_7 = string.Empty;

		private Dictionary<EmbeddedDataFormat, object> dictionary_0;

		private string string_8 = string.Empty;

		private DateTime dateTime_1 = new DateTime(0L);

		private bool bool_1 = true;

		private string string_9 = string.Empty;

		private int int_1;

		private StreamType streamType_0;

		private bool bool_2 = true;

		private bool bool_3 = true;

		private bool bool_4;

		private PageMargins pageMargins = new PageMargins(-1.0, -1.0, -1.0, -1.0);

		private PageSize pageSize_0 = new PageSize(0.0, 0.0);

		private PDFImportSettings pdfimportSettings_0 = PDFImportSettings.GenerateTextFrames | PDFImportSettings.LoadEmbeddedFiles;

		private UserDefinedPropertyDictionary userDefinedPropertyDictionary_0;

		private bool bool_5;

		/// <summary>Specifies whether or not a new paragraph is created before text is loaded.</summary>
		public bool AddParagraph
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

		/// <summary>Specifies the format of text fields which are imported.</summary>
		public ApplicationFieldFormat ApplicationFieldFormat
		{
			get
			{
				return this.applicationFieldFormat_0;
			}
			set
			{
				this.applicationFieldFormat_0 = value;
			}
		}

		/// <summary>Specifies an array of strings containing the type names of fields which are to be imported.</summary>
		public string[] ApplicationFieldTypeNames
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

		/// <summary>Gets the document's author.</summary>
		[Obfuscation(Exclude = true)]
		public string Author
		{
			get
			{
				return this.string_1;
			}
			internal set
			{
				this.string_1 = value;
			}
		}

		/// <summary>Gets the number of bytes read during the load operation.</summary>
		public long BytesRead => this.long_0;

		public int ConvertedMergeBlocks => this.int_0;

		/// <summary>Gets the document's creation date.</summary>
		[Obfuscation(Exclude = true)]
		public DateTime CreationDate
		{
			get
			{
				return this.dateTime_0;
			}
			internal set
			{
				this.dateTime_0 = value;
			}
		}

		/// <summary>Gets the application, which has created the document.</summary>
		[Obfuscation(Exclude = true)]
		public string CreatorApplication
		{
			get
			{
				return this.string_2;
			}
			internal set
			{
				this.string_2 = value;
			}
		}

		/// <summary>Gets the path and filename of the CSS file belonging to a HTML or XML document.</summary>
		public string CssFileName => this.string_3;

		/// <summary>Specifies how a document can be accessed after it has been loaded.</summary>
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

		/// <summary>Gets the document's keywords.</summary>
		[Obfuscation(Exclude = true)]
		public string[] DocumentKeywords
		{
			get
			{
				return this.string_4;
			}
			internal set
			{
				this.string_4 = value;
			}
		}

		/// <summary>SpreadsheetML only. Gets or sets the name of the part of the document to be loaded.</summary>
		public string DocumentPartName
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

		/// <summary>Gets the document's subject string.</summary>
		[Obfuscation(Exclude = true)]
		public string DocumentSubject
		{
			get
			{
				return this.string_6;
			}
			internal set
			{
				this.string_6 = value;
			}
		}

		/// <summary>Gets the document's title.</summary>
		[Obfuscation(Exclude = true)]
		public string DocumentTitle
		{
			get
			{
				return this.string_7;
			}
			internal set
			{
				this.string_7 = value;
			}
		}

		/// <summary>Gets a System.Collections.Generic.Dictionary containing additional embedded data contained in a PDF document.</summary>
		public Dictionary<EmbeddedDataFormat, object> EmbeddedData
		{
			get
			{
				return this.dictionary_0;
			}
			internal set
			{
				this.dictionary_0 = value;
			}
		}

		/// <summary>Sets a file path that is used to search for resources like images or hypertext links.</summary>
		public string ImageSearchPath
		{
			get
			{
				return this.string_8;
			}
			set
			{
				this.string_8 = value;
			}
		}

		/// <summary>Gets the date the document is last modified.</summary>
		[Obfuscation(Exclude = true)]
		public DateTime LastModificationDate
		{
			get
			{
				return this.dateTime_1;
			}
			internal set
			{
				this.dateTime_1 = value;
			}
		}

		/// <summary>Specifies whether or not the document background color is loaded.</summary>
		public bool LoadDocumentBackColor
		{
			get
			{
				return this.bool_1;
			}
			set
			{
				this.bool_1 = value;
			}
		}

		/// <summary>Gets the name and path of the file that has been loaded.</summary>
		public string LoadedFile => this.string_9;

		public int LoadedFormatVersion => this.int_1;

		/// <summary>Gets the StreamType of the file that has been loaded.</summary>
		public StreamType LoadedStreamType => this.streamType_0;

		/// <summary>Specifies whether or not hypertext links are loaded.</summary>
		public bool LoadHypertextLinks
		{
			get
			{
				return this.bool_2;
			}
			set
			{
				this.bool_2 = value;
			}
		}

		/// <summary>Specifies whether or not images are loaded.</summary>
		public bool LoadImages
		{
			get
			{
				return this.bool_3;
			}
			set
			{
				this.bool_3 = value;
			}
		}

		/// <summary>DOCX, DOC and RTF Formats only: Specifies whether or not bookmarks which extend over several characters are converted to SubTextParts.</summary>
		public bool LoadSubTextParts
		{
			get
			{
				return this.bool_4;
			}
			set
			{
				this.bool_4 = value;
			}
		}

		/// <summary>Gets the margins of the loaded document's pages.</summary>
		public PageMargins PageMargins => this.pageMargins;

		/// <summary>Gets the width and height of the loaded document's pages.</summary>
		public PageSize PageSize => this.pageSize_0;

		/// <summary>Specifies how the document structure is generated when a PDF document is imported.</summary>
		public PDFImportSettings PDFImportSettings
		{
			get
			{
				return this.pdfimportSettings_0;
			}
			set
			{
				this.pdfimportSettings_0 = value;
			}
		}

		/// <summary>Gets a dictionary with all user-defined document properties contained in the loaded document.</summary>
		public UserDefinedPropertyDictionary UserDefinedDocumentProperties => this.userDefinedPropertyDictionary_0;

		public bool ValidateFormat
		{
			get
			{
				return this.bool_5;
			}
			set
			{
				this.bool_5 = value;
			}
		}

		/// <summary>Gets the names of all document parts from the specified file.</summary>
		/// <param name="path">Specifies a file from which the document is loaded.</param>
		/// <param name="streamType">Specifies one of the StreamType values.</param>
		public static string[] GetDocumentPartNames(string path, StreamType streamType)
		{
			if (streamType != StreamType.SpreadsheetML)
			{
				throw new ArgumentOutOfRangeException("streamType");
			}
			string[] result = null;
			Class408 @class = null;
			FileStream fileStream = null;
			if (path.Length != 0)
			{
				try
				{
					@class = new Class408();
					fileStream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read);
					return @class.method_9(fileStream.SafeFileHandle.DangerousGetHandle(), IntPtr.Zero, 0u);
				}
				catch (Exception ex)
				{
					throw ex;
				}
				finally
				{
					fileStream?.Close();
					@class?.Dispose();
				}
			}
			return result;
		}

		/// <summary>Gets the names of all document parts from the specified byte array.</summary>
		/// <param name="binaryData">Specifies a byte array from which the document is loaded.</param>
		/// <param name="streamType">Specifies one of the StreamType values.</param>
		public static string[] GetDocumentPartNames(byte[] binaryData, StreamType streamType)
		{
			if (streamType != StreamType.SpreadsheetML)
			{
				throw new ArgumentOutOfRangeException("streamType");
			}
			string[] result = null;
			Class408 @class = null;
			IntPtr intPtr = IntPtr.Zero;
			if (binaryData.Length != 0)
			{
				try
				{
					@class = new Class408();
					intPtr = Marshal.AllocHGlobal(binaryData.Length);
					Marshal.Copy(binaryData, 0, intPtr, binaryData.Length);
					return @class.method_9(IntPtr.Zero, intPtr, (uint)binaryData.Length);
				}
				catch (Exception ex)
				{
					throw ex;
				}
				finally
				{
					if (intPtr != IntPtr.Zero)
					{
						Marshal.FreeHGlobal(intPtr);
					}
					@class?.Dispose();
				}
			}
			return result;
		}

		internal bool method_0(StreamType streamType_1, TextControlCore textControlCore_0, Enum104 enum104_0, DocumentSettings documentSettings_0)
		{
			bool result = false;
			string strFileName = string.Empty;
			if (textControlCore_0 != null && textControlCore_0.isHandleCreated)
			{
				streamType_1 &= ~StreamType.CascadingStylesheet;
				streamType_1 &= ~StreamType.AdobePDFA;
				if (streamType_1 == (StreamType)0)
				{
					throw new ArgumentOutOfRangeException("iStreamType");
				}
				int iFilterIndex = textControlCore_0.GetTextControl().OpenFileDialog(base.GetFilterString(streamType_1), out strFileName);
				if (strFileName.Length > 0)
				{
					this.method_1(strFileName, base.StreamTypeFromFilterIndex(iFilterIndex, streamType_1), textControlCore_0, enum104_0, documentSettings_0);
					result = true;
				}
				return result;
			}
			throw new InvalidOperationException(base.m_rm.GetString("ERR_NOTLOADED"));
		}

		internal void method_1(string string_10, StreamType streamType_1, TextControlCore textControlCore_0, Enum104 enum104_0, DocumentSettings documentSettings_0)
		{
			if (textControlCore_0 != null && textControlCore_0.isHandleCreated)
			{
				streamType_1 &= ~StreamType.CascadingStylesheet;
				streamType_1 &= ~StreamType.AdobePDFA;
				if (streamType_1 == (StreamType)0)
				{
					throw new ArgumentOutOfRangeException("iStreamType");
				}
				if (string_10.Length == 0)
				{
					return;
				}
				FileStream fileStream = new FileStream(string_10, FileMode.Open, FileAccess.Read, FileShare.Read);
				try
				{
					this.method_2(fileStream, streamType_1, textControlCore_0, enum104_0, documentSettings_0);
				}
				catch (Exception ex)
				{
					throw ex;
				}
				finally
				{
					fileStream.Close();
					this.string_9 = string_10;
					this.streamType_0 = streamType_1;
				}
				return;
			}
			throw new InvalidOperationException(base.m_rm.GetString("ERR_NOTLOADED"));
		}

		internal void method_2(FileStream fileStream_0, StreamType streamType_1, TextControlCore textControlCore_0, Enum104 enum104_0, DocumentSettings documentSettings_0)
		{
			if (textControlCore_0 != null && textControlCore_0.isHandleCreated)
			{
				textControlCore_0.GetTextControl().CheckStreamType(streamType_1);
				if (streamType_1 == StreamType.AdobePDF)
				{
					this.method_4(fileStream_0, streamType_1, textControlCore_0, enum104_0, documentSettings_0);
					return;
				}
				Struct53 struct53_ = new Struct53(enum104_0);
				try
				{
					if (documentSettings_0 != null)
					{
						textControlCore_0.method_23(bool_1: true);
					}
					struct53_.safeFileHandle_0 = fileStream_0.SafeFileHandle;
					struct53_.ushort_1 = base.GetTxFormat(streamType_1);
					this.method_6(ref struct53_, textControlCore_0, fileStream_0.Name, 0, streamType_1);
					textControlCore_0.method_46(base.m_iTextPart, 1625, 0, ref struct53_);
					if (base.m_iReportingMergeBlockFormat == ReportingMergeBlockFormat.SubTextParts)
					{
						this.int_0 = MergeBlockConverter.DocumentTargetsToSubTextParts(textControlCore_0, out var blockNamesInvalid);
						if (blockNamesInvalid.Count > 0)
						{
							throw new MergeBlockConversionException(blockNamesInvalid);
						}
					}
				}
				catch (Exception ex)
				{
					throw ex;
				}
				finally
				{
					this.method_7(struct53_, textControlCore_0);
					struct53_.method_0();
					if (documentSettings_0 != null)
					{
						documentSettings_0.method_0(this);
						textControlCore_0.method_23(bool_1: false);
					}
				}
				return;
			}
			throw new InvalidOperationException(base.m_rm.GetString("ERR_NOTLOADED"));
		}

		internal void method_3(byte[] byte_0, BinaryStreamType binaryStreamType_0, TextControlCore textControlCore_0, Enum104 enum104_0, DocumentSettings documentSettings_0)
		{
			if (textControlCore_0 != null && textControlCore_0.isHandleCreated)
			{
				textControlCore_0.GetTextControl().CheckStreamType((StreamType)binaryStreamType_0);
				if (binaryStreamType_0 == BinaryStreamType.AdobePDF)
				{
					this.method_4(new MemoryStream(byte_0), (StreamType)binaryStreamType_0, textControlCore_0, enum104_0, documentSettings_0);
					return;
				}
				Struct53 struct53_ = new Struct53(enum104_0);
				try
				{
					if (documentSettings_0 != null)
					{
						textControlCore_0.method_23(bool_1: true);
					}
					struct53_.ushort_1 = base.GetTxFormat((StreamType)binaryStreamType_0);
					struct53_.intptr_1 = Marshal.AllocHGlobal(byte_0.Length);
					Marshal.Copy(byte_0, 0, struct53_.intptr_1, byte_0.Length);
					this.method_6(ref struct53_, textControlCore_0, string.Empty, byte_0.Length, (StreamType)binaryStreamType_0);
					textControlCore_0.method_46(base.m_iTextPart, 1625, 0, ref struct53_);
					if (base.m_iReportingMergeBlockFormat == ReportingMergeBlockFormat.SubTextParts)
					{
						this.int_0 = MergeBlockConverter.DocumentTargetsToSubTextParts(textControlCore_0, out var blockNamesInvalid);
						if (blockNamesInvalid.Count > 0)
						{
							throw new MergeBlockConversionException(blockNamesInvalid);
						}
					}
				}
				catch (Exception ex)
				{
					throw ex;
				}
				finally
				{
					this.method_7(struct53_, textControlCore_0);
					struct53_.method_0();
					if (documentSettings_0 != null)
					{
						documentSettings_0.method_0(this);
						textControlCore_0.method_23(bool_1: false);
					}
				}
				return;
			}
			throw new InvalidOperationException(base.m_rm.GetString("ERR_NOTLOADED"));
		}

		private void method_4(Stream stream_0, StreamType streamType_1, TextControlCore textControlCore_0, Enum104 enum104_0, DocumentSettings documentSettings_0)
		{
			if (streamType_1 != StreamType.AdobePDF)
			{
				return;
			}
			TextFormatter textFormatter = new TextFormatter(textControlCore_0);
			try
			{
				if (documentSettings_0 != null)
				{
					textControlCore_0.method_23(bool_1: true);
				}
				//Assembly assembly = textControlCore_0.class408_0.method_2("txpdf", "29.0.1600.500");
				Type type = typeof(TXFilter);
				Type[] types = new Type[3]
				{
					typeof(Stream),
					typeof(LoadSettings),
					typeof(TextFormatter)
				};
				object[] parameters = new object[3] { stream_0, this, textFormatter };
				byte[] array = (byte[])type.GetMethod("Import", types).Invoke(null, parameters);
				if (array != null)
				{
					this.method_3(array, BinaryStreamType.InternalUnicodeFormat, textControlCore_0, enum104_0, null);
				}
			}
			catch (TargetInvocationException ex)
			{
				throw ex.InnerException;
			}
			finally
			{
				textFormatter?.method_0();
				if (documentSettings_0 != null)
				{
					documentSettings_0.method_0(this);
					textControlCore_0.method_23(bool_1: false);
				}
			}
		}

		internal void method_5(string string_10, StringStreamType stringStreamType_0, TextControlCore textControlCore_0, Enum104 enum104_0, DocumentSettings documentSettings_0)
		{
			if (textControlCore_0 != null && textControlCore_0.isHandleCreated)
			{
				textControlCore_0.GetTextControl().CheckStreamType((StreamType)stringStreamType_0);
				Struct53 struct53_ = new Struct53(enum104_0);
				int int_ = 0;
				try
				{
					if (documentSettings_0 != null)
					{
						textControlCore_0.method_23(bool_1: true);
					}
					struct53_.ushort_1 = base.GetTxFormat((StreamType)stringStreamType_0);
					switch (stringStreamType_0)
					{
					case StringStreamType.RichTextFormat:
					case StringStreamType.XMLFormat:
					case StringStreamType.CascadingStylesheet:
						struct53_.intptr_1 = Marshal.StringToHGlobalAnsi(string_10);
						int_ = string_10.Length;
						break;
					case StringStreamType.HTMLFormat:
					case StringStreamType.PlainText:
						struct53_.intptr_1 = Marshal.StringToHGlobalUni(string_10);
						int_ = string_10.Length * 2;
						break;
					}
					this.method_6(ref struct53_, textControlCore_0, string.Empty, int_, (StreamType)stringStreamType_0);
					textControlCore_0.method_46(base.m_iTextPart, 1625, 0, ref struct53_);
				}
				catch (Exception ex)
				{
					throw ex;
				}
				finally
				{
					this.method_7(struct53_, textControlCore_0);
					struct53_.method_0();
					if (documentSettings_0 != null)
					{
						documentSettings_0.method_0(this);
						textControlCore_0.method_23(bool_1: false);
					}
				}
				return;
			}
			throw new InvalidOperationException(base.m_rm.GetString("ERR_NOTLOADED"));
		}

		private void method_6(ref Struct53 struct53_0, TextControlCore textControlCore_0, string string_10, int int_2, StreamType streamType_1)
		{
			Struct54 @struct = new Struct54(0);
			if (string_10.Length > 0)
			{
				@struct.intptr_4 = Marshal.StringToBSTR(string_10);
			}
			if (this.string_8.Length > 0)
			{
				@struct.intptr_0 = Marshal.StringToBSTR(this.string_8);
			}
			if (base.m_strDocumentBasePath.Length > 0)
			{
				@struct.intptr_1 = Marshal.StringToBSTR(base.m_strDocumentBasePath);
			}
			@struct.uint_5 = (uint)int_2;
			@struct.int_0 = TwipsConverter.DotNet2Tw((this.pageSize_0.Width != 0.0) ? this.pageSize_0.Width : textControlCore_0.GetTextControl().GetPageSize().Width, textControlCore_0.MeasuringUnit_0);
			@struct.int_1 = TwipsConverter.DotNet2Tw((this.pageSize_0.Height != 0.0) ? this.pageSize_0.Height : textControlCore_0.GetTextControl().GetPageSize().Height, textControlCore_0.MeasuringUnit_0);
			@struct.short_1 = (short)TwipsConverter.DotNet2Tw((this.pageMargins.Left != -1.0) ? this.pageMargins.Left : textControlCore_0.GetTextControl().GetPageMargins().Left, textControlCore_0.MeasuringUnit_0);
			@struct.short_2 = (short)TwipsConverter.DotNet2Tw((this.pageMargins.Top != -1.0) ? this.pageMargins.Top : textControlCore_0.GetTextControl().GetPageMargins().Top, textControlCore_0.MeasuringUnit_0);
			@struct.short_3 = (short)TwipsConverter.DotNet2Tw((this.pageMargins.Right != -1.0) ? this.pageMargins.Right : textControlCore_0.GetTextControl().GetPageMargins().Right, textControlCore_0.MeasuringUnit_0);
			@struct.short_4 = (short)TwipsConverter.DotNet2Tw((this.pageMargins.Bottom != -1.0) ? this.pageMargins.Bottom : textControlCore_0.GetTextControl().GetPageMargins().Bottom, textControlCore_0.MeasuringUnit_0);
			if (!this.bool_3)
			{
				@struct.enum119_0 &= (Struct54.Enum119)4294967231u;
			}
			if (!this.bool_2)
			{
				@struct.enum119_0 &= (Struct54.Enum119)4294966271u;
			}
			if (this.bool_4)
			{
				@struct.enum119_0 |= Struct54.Enum119.const_23;
			}
			switch (this.applicationFieldFormat_0)
			{
			case ApplicationFieldFormat.MSWordTXFormFields:
				@struct.enum119_0 |= Struct54.Enum119.const_16;
				break;
			case ApplicationFieldFormat.MSWord:
				@struct.enum119_0 |= Struct54.Enum119.const_16;
				@struct.enum119_0 &= (Struct54.Enum119)3758096383u;
				break;
			case ApplicationFieldFormat.HighEdit:
				@struct.enum119_0 |= Struct54.Enum119.const_17;
				break;
			}
			if (this.string_0 != null)
			{
				char[] array = KernelHelper.StringArray2CharArray(this.string_0);
				@struct.intptr_15 = Marshal.AllocHGlobal(array.Length * 2);
				Marshal.Copy(array, 0, @struct.intptr_15, array.Length);
			}
			if (struct53_0.intptr_1 != IntPtr.Zero && streamType_1 == StreamType.HTMLFormat)
			{
				@struct.enum119_0 |= Struct54.Enum119.const_19;
			}
			if (this.bool_5)
			{
				struct53_0.uint_0 |= 32u;
			}
			if (this.bool_0)
			{
				struct53_0.uint_0 |= 4u;
			}
			if (this.string_5 != null)
			{
				@struct.intptr_22 = Marshal.StringToBSTR(this.string_5);
			}
			if (base.m_strMasterPassword.Length > 0)
			{
				@struct.intptr_10 = Marshal.StringToBSTR(base.m_strMasterPassword);
			}
			Marshal.StructureToPtr((object)@struct, struct53_0.intptr_4, fDeleteOld: false);
		}

		private void method_7(Struct53 struct53_0, TextControlCore textControlCore_0)
		{
			Struct54 @struct = (Struct54)Marshal.PtrToStructure(struct53_0.intptr_4, typeof(Struct54));
			this.long_0 = struct53_0.uint_1;
			this.int_1 = @struct.ushort_7;
			if (@struct.intptr_2 != IntPtr.Zero)
			{
				this.string_7 = Marshal.PtrToStringUni(Class429.GlobalLock(@struct.intptr_2));
			}
			this.pageSize_0.Width = ((@struct.int_0 != 0) ? TwipsConverter.Tw2DotNet(@struct.int_0, textControlCore_0.MeasuringUnit_0) : 0.0);
			this.pageSize_0.Height = ((@struct.int_1 != 0) ? TwipsConverter.Tw2DotNet(@struct.int_1, textControlCore_0.MeasuringUnit_0) : 0.0);
			this.pageMargins.Left = ((@struct.short_1 != -1) ? TwipsConverter.Tw2DotNet(@struct.short_1, textControlCore_0.MeasuringUnit_0) : (-1.0));
			this.pageMargins.Top = ((@struct.short_2 != -1) ? TwipsConverter.Tw2DotNet(@struct.short_2, textControlCore_0.MeasuringUnit_0) : (-1.0));
			this.pageMargins.Right = ((@struct.short_3 != -1) ? TwipsConverter.Tw2DotNet(@struct.short_3, textControlCore_0.MeasuringUnit_0) : (-1.0));
			this.pageMargins.Bottom = ((@struct.short_4 != -1) ? TwipsConverter.Tw2DotNet(@struct.short_4, textControlCore_0.MeasuringUnit_0) : (-1.0));
			if (this.bool_1)
			{
				textControlCore_0.GetTextControl().SetDocumentBackColor(@struct.uint_0);
			}
			if (@struct.intptr_8 != IntPtr.Zero)
			{
				this.string_3 = Marshal.PtrToStringUni(Class429.GlobalLock(@struct.intptr_8));
			}
			if (@struct.intptr_19 != IntPtr.Zero)
			{
				string[] array = KernelHelper.Ptr2StringArray(Class429.GlobalLock(@struct.intptr_19), 6);
				if (array.Length == 6)
				{
					if (array[0] != string.Empty)
					{
						this.dateTime_0 = KernelHelper.DateTimeFromUTCString(array[0]);
					}
					if (array[1] != string.Empty)
					{
						this.dateTime_1 = KernelHelper.DateTimeFromUTCString(array[1]);
					}
					this.string_1 = array[2];
					this.string_6 = array[3];
					this.string_2 = array[4];
					if (array[5] != string.Empty)
					{
						this.string_4 = array[5].Split('\t');
					}
				}
				Class429.GlobalUnlock(@struct.intptr_19);
			}
			if (@struct.intptr_20 != IntPtr.Zero)
			{
				this.userDefinedPropertyDictionary_0 = new UserDefinedPropertyDictionary(Class429.GlobalLock(@struct.intptr_20));
				Class429.GlobalUnlock(@struct.intptr_20);
			}
		}
	}
}
