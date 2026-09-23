using System;
using System.Runtime.InteropServices;
using ns21;

namespace TXTextControl
{
	/// <summary>The XmlErrorEventArgs class provides data for the TextControl.XmlNotWellFormed and TextControl.XmlInvalid events.</summary>
	public class XmlErrorEventArgs : EventArgs
	{
		private int int_0;

		private int int_1;

		private int int_2;

		private int int_3;

		private string string_0;

		private string string_1;

		/// <summary>Gets the absolute file position in the XML document where the error occurred.</summary>
		public int FilePosition => this.int_0;

		/// <summary>Gets the line number in the XML document that contains the error.</summary>
		public int LineNumber => this.int_1;

		/// <summary>Gets the character position within the line where the error occurred.</summary>
		public int LinePosition => this.int_2;

		/// <summary>Gets the reason for the error.</summary>
		public string Reason => this.string_0;

		/// <summary>Gets the URL of the XML document containing the error.</summary>
		public string URL => this.string_1;

		internal XmlErrorEventArgs(Struct73 xmlError)
		{
			this.int_0 = xmlError.int_0;
			this.int_1 = xmlError.int_1;
			this.int_2 = xmlError.int_2;
			this.int_3 = xmlError.int_3;
			this.string_0 = ((xmlError.intptr_0 != IntPtr.Zero) ? Marshal.PtrToStringBSTR(xmlError.intptr_0) : string.Empty);
			this.string_1 = ((xmlError.intptr_1 != IntPtr.Zero) ? Marshal.PtrToStringBSTR(xmlError.intptr_1) : string.Empty);
		}
	}
}
