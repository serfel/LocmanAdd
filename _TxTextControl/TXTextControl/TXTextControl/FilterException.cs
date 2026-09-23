using System;
using System.Resources;

namespace TXTextControl
{
	/// <summary>The FilterException class informs about errors which can occur when a text filter is used to convert a document to or from another format.</summary>
	public class FilterException : Exception
	{
		/// <summary>Enumerates errors which can occur when a text filter is used to convert a TX Text Control document to or from another format.</summary>
		public enum FilterError
		{
			/// <summary>The file type is not supported through the filter.</summary>
			WrongFileType = 1,
			/// <summary>There is a logical error in the file.</summary>
			BadToken,
			/// <summary>Unable to allocate enough memory.</summary>
			OutOfMemory,
			/// <summary>File read error.</summary>
			CannotRead,
			/// <summary>File write error.</summary>
			CannotWrite,
			/// <summary>Unable to open the file.</summary>
			CannotOpen,
			/// <summary>The input file is too big.</summary>
			FileTooBig,
			/// <summary>Unsupported format version.</summary>
			Unsupported,
			/// <summary>Unspecified internal error.</summary>
			Internal,
			/// <summary>The filter is obsolete.</summary>
			Obsolete,
			/// <summary>The file contains not well-formed syntax.</summary>
			NotWellFormed,
			/// <summary>The document cannot be imported because the used encryption scheme is not supported.</summary>
			Encrypted,
			/// <summary>The document cannot be saved, because it contains a non-embeddable font.</summary>
			NonEmbeddableFont,
			/// <summary>The specified certificate is invalid or has no private key.</summary>
			InvalidCertificate,
			/// <summary>The specified time server does not exist or retrieves invalid data.</summary>
			InvalidTimeServer,
			/// <summary>The specified user-password is invalid.</summary>
			InvalidPassword,
			EncryptedPassword,
			InvalidReference,
			FormulaCalculation,
			FormulaFunctionParameter
		}

		private FilterError filterError_0;

		private string string_0;

		/// <summary>Gets the error which is the cause of this exception.</summary>
		public FilterError Reason => this.filterError_0;

		public override string Message
		{
			get
			{
				TxError txError = TxError.ERR_UNKNOWN;
				switch (this.filterError_0)
				{
				case FilterError.WrongFileType:
					txError = TxError.ERR_FE_NOT_MY_FILE;
					break;
				case FilterError.BadToken:
					txError = TxError.ERR_FE_BAD_TOKEN;
					break;
				case FilterError.OutOfMemory:
					txError = TxError.ERR_OUTOFMEMORY;
					break;
				case FilterError.CannotRead:
					txError = TxError.ERR_FE_READ_DATA;
					break;
				case FilterError.CannotWrite:
					txError = TxError.ERR_FE_WRITE_DATA;
					break;
				case FilterError.CannotOpen:
					txError = TxError.ERR_FE_OPEN_FILE;
					break;
				case FilterError.FileTooBig:
					txError = TxError.ERR_FE_FILE_TOO_BIG;
					break;
				case FilterError.Unsupported:
					txError = TxError.ERR_FE_UNSUPP;
					break;
				case FilterError.Internal:
					txError = TxError.ERR_INTERNAL;
					break;
				case FilterError.Obsolete:
					txError = TxError.ERR_FE_OUTDATED;
					break;
				case FilterError.NotWellFormed:
					txError = TxError.ERR_FE_NOTWELLFORMED;
					break;
				case FilterError.Encrypted:
					txError = TxError.ERR_FE_ENCRYPTED;
					break;
				case FilterError.NonEmbeddableFont:
					txError = TxError.ERR_FE_NONEMBEDDABLEFONT;
					break;
				case FilterError.InvalidCertificate:
					txError = TxError.ERR_FE_INVALIDCERTIFICATE;
					break;
				case FilterError.InvalidTimeServer:
					txError = TxError.ERR_FE_INVALIDTIMESERVER;
					break;
				case FilterError.InvalidPassword:
					txError = TxError.ERR_FE_INVALIDPASSWORD;
					break;
				case FilterError.EncryptedPassword:
					txError = TxError.ERR_FE_ENCRYPTEDPASSWORD;
					break;
				}
				ResourceManager resourceManager = new ResourceManager(typeof(TextControlCore));
				return resourceManager.GetString(txError.ToString()) + ((this.string_0 == null) ? string.Empty : ("\n" + this.string_0)) + $"\n(1-1D{(int)this.filterError_0:X2})";
			}
		}

		public FilterException(FilterError error)
		{
			this.filterError_0 = error;
		}

		public FilterException(FilterError error, string message)
			: base(message)
		{
			this.filterError_0 = error;
			this.string_0 = message;
		}
	}
}
