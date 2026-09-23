using System;
using System.Runtime.InteropServices;
using Microsoft.Win32.SafeHandles;
using ns21;

namespace TXTextControl
{
	/// <summary>The EmbeddedFile class represents a file embedded in another document.</summary>
	public class EmbeddedFile
	{
		private string string_0;

		private string string_1;

		private byte[] byte_0;

		private SafeFileHandle safeFileHandle_0;

		private DateTime? nullable_0 = null;

		private string string_2;

		private string string_3;

		private string string_4;

		private DateTime? nullable_1 = null;

		private string string_5;

		/// <summary>Gets or sets the file's creation date.</summary>
		public DateTime? CreationDate
		{
			get
			{
				return this.nullable_0;
			}
			set
			{
				this.nullable_0 = value;
			}
		}

		/// <summary>Gets the file's data.</summary>
		public object Data
		{
			get
			{
				if (this.string_0 == null)
				{
					return this.byte_0;
				}
				return this.string_0;
			}
		}

		/// <summary>Gets or sets an optional file description.</summary>
		public string Description
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

		/// <summary>Gets the file's name.</summary>
		public string FileName => this.string_3;

		/// <summary>Gets or sets an optional string specifying the file's type using types specified through the Multipurpose Internet Mail Extensions (MIME) specification.</summary>
		public string MIMEType
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

		/// <summary>Gets or sets the date the file was last modified.</summary>
		public DateTime? LastModificationDate
		{
			get
			{
				return this.nullable_1;
			}
			set
			{
				this.nullable_1 = value;
			}
		}

		/// <summary>PDF/A only. Gets or sets an optional string describing the relationship of the embedded file and the containing document.</summary>
		public string Relationship
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

		/// <summary>Initializes a new instance of an embedded file with the specified name. The file's data is given through the specified file handle. When the document is saved, the data is read from the file and embedded in the document.</summary>
		/// <param name="fileName">Specifies the file's name.</param>
		/// <param name="handle">Identifies a file from which the data to embed is read.</param>
		/// <param name="metaData">Specifies additional metadata with properties of the document which is embedded.</param>
		public EmbeddedFile(string fileName, SafeFileHandle handle, string metaData)
		{
			if (string.IsNullOrEmpty(fileName))
			{
				throw new ArgumentException();
			}
			this.string_3 = fileName;
			this.safeFileHandle_0 = handle;
			if (!string.IsNullOrEmpty(metaData))
			{
				this.string_1 = metaData;
			}
		}

		/// <summary>Initializes a new instance of an embedded file with the specified name and string data.</summary>
		/// <param name="fileName">Specifies the file's name.</param>
		/// <param name="data">Specifies the file's data.</param>
		/// <param name="metaData">Specifies additional metadata with properties of the document which is embedded.</param>
		public EmbeddedFile(string fileName, string data, string metaData)
		{
			if (string.IsNullOrEmpty(fileName))
			{
				throw new ArgumentException();
			}
			this.string_3 = fileName;
			this.string_0 = data;
			if (!string.IsNullOrEmpty(metaData))
			{
				this.string_1 = metaData;
			}
		}

		/// <summary>Initializes a new instance of an embedded file with the specified name and binary data.</summary>
		/// <param name="fileName">Specifies the file's name.</param>
		/// <param name="data">Specifies the file's data.</param>
		/// <param name="metaData">Specifies additional metadata with properties of the document which is embedded.</param>
		public EmbeddedFile(string fileName, byte[] data, string metaData)
		{
			if (string.IsNullOrEmpty(fileName))
			{
				throw new ArgumentException();
			}
			this.string_3 = fileName;
			this.byte_0 = data;
			if (!string.IsNullOrEmpty(metaData))
			{
				this.string_1 = metaData;
			}
		}

		public int GetUnmanagedBufferSize()
		{
			int num = Marshal.SizeOf(typeof(Struct81));
			if (this.string_3 != null)
			{
				num += (this.string_3.Length + 1) * 2;
			}
			if (this.string_2 != null)
			{
				num += (this.string_2.Length + 1) * 2;
			}
			if (this.string_5 != null)
			{
				num += (this.string_5.Length + 1) * 2;
			}
			if (this.string_4 != null)
			{
				num += (this.string_4.Length + 1) * 2;
			}
			if (this.string_1 != null)
			{
				num += (this.string_1.Length + 1) * 2;
			}
			if (this.string_0 != null)
			{
				num += this.string_0.Length * 2;
			}
			else if (this.byte_0 != null)
			{
				num += this.byte_0.Length;
			}
			return num;
		}

		internal int method_0(IntPtr intptr_0)
		{
			Struct81 @struct = default(Struct81);
			int num = Marshal.SizeOf(typeof(Struct81));
			int num2 = 0;
			@struct.method_0();
			if (this.string_3 != null)
			{
				@struct.ushort_0 = (ushort)((this.string_3.Length + 1) * 2);
			}
			if (this.string_2 != null)
			{
				@struct.ushort_1 = (ushort)((this.string_2.Length + 1) * 2);
			}
			if (this.string_5 != null)
			{
				@struct.ushort_2 = (ushort)((this.string_5.Length + 1) * 2);
			}
			if (this.string_4 != null)
			{
				@struct.ushort_3 = (ushort)((this.string_4.Length + 1) * 2);
			}
			if (this.string_1 != null)
			{
				@struct.ushort_4 = (ushort)((this.string_1.Length + 1) * 2);
			}
			if (this.safeFileHandle_0 != null)
			{
				@struct.intptr_0 = this.safeFileHandle_0.DangerousGetHandle();
			}
			if (this.string_0 != null)
			{
				@struct.uint_0 = (uint)(this.string_0.Length * 2);
			}
			else if (this.byte_0 != null)
			{
				@struct.uint_0 = (uint)this.byte_0.Length;
			}
			if (this.nullable_0.HasValue)
			{
				@struct.long_0 = this.nullable_0.Value.ToFileTimeUtc();
			}
			if (this.nullable_1.HasValue)
			{
				@struct.long_1 = this.nullable_1.Value.ToFileTimeUtc();
			}
			num += @struct.ushort_0 + @struct.ushort_1 + @struct.ushort_2 + @struct.ushort_3 + @struct.ushort_4 + (int)@struct.uint_0;
			Marshal.StructureToPtr((object)@struct, intptr_0, fDeleteOld: false);
			num2 += Marshal.SizeOf(typeof(Struct81));
			if (this.string_3 != null)
			{
				char[] array = this.string_3.ToCharArray();
				Marshal.Copy(array, 0, new IntPtr(intptr_0.ToInt64() + num2), array.Length);
				num2 += @struct.ushort_0;
				Marshal.WriteInt16(new IntPtr(intptr_0.ToInt64() + num2 - 2L), 0);
			}
			if (this.string_2 != null)
			{
				char[] array2 = this.string_2.ToCharArray();
				Marshal.Copy(array2, 0, new IntPtr(intptr_0.ToInt64() + num2), array2.Length);
				num2 += @struct.ushort_1;
				Marshal.WriteInt16(new IntPtr(intptr_0.ToInt64() + num2 - 2L), 0);
			}
			if (this.string_5 != null)
			{
				char[] array3 = this.string_5.ToCharArray();
				Marshal.Copy(array3, 0, new IntPtr(intptr_0.ToInt64() + num2), array3.Length);
				num2 += @struct.ushort_2;
				Marshal.WriteInt16(new IntPtr(intptr_0.ToInt64() + num2 - 2L), 0);
			}
			if (this.string_4 != null)
			{
				char[] array4 = this.string_4.ToCharArray();
				Marshal.Copy(array4, 0, new IntPtr(intptr_0.ToInt64() + num2), array4.Length);
				num2 += @struct.ushort_3;
				Marshal.WriteInt16(new IntPtr(intptr_0.ToInt64() + num2 - 2L), 0);
			}
			if (this.string_1 != null)
			{
				char[] array5 = this.string_1.ToCharArray();
				Marshal.Copy(array5, 0, new IntPtr(intptr_0.ToInt64() + num2), array5.Length);
				num2 += @struct.ushort_4;
				Marshal.WriteInt16(new IntPtr(intptr_0.ToInt64() + num2 - 2L), 0);
			}
			if (this.string_0 != null)
			{
				char[] array6 = this.string_0.ToCharArray();
				Marshal.Copy(array6, 0, new IntPtr(intptr_0.ToInt64() + num2), array6.Length);
			}
			else if (this.byte_0 != null)
			{
				Marshal.Copy(this.byte_0, 0, new IntPtr(intptr_0.ToInt64() + num2), this.byte_0.Length);
			}
			return num;
		}
	}
}
