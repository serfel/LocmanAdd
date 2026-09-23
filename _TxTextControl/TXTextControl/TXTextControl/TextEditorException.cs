using System;

namespace TXTextControl
{
	/// <summary>The TextEditorException class informs about errors which can occur during editing text.</summary>
	public class TextEditorException : Exception
	{
		/// <summary>Initializes a new instance of the TextEditorException class.</summary>
		public TextEditorException()
		{
		}

		/// <summary>Initializes a new instance of the TextEditorException class with a specified error message.</summary>
		/// <param name="message">The error message that explains the reason for the exception.</param>
		public TextEditorException(string message)
			: base(message)
		{
		}

		/// <summary>Initializes a new instance of the TextEditorException class with a specified error message and a reference to the inner exception that is the cause of this exception.</summary>
		/// <param name="message">The error message that explains the reason for the exception.</param>
		/// <param name="innerException">The exception that is the cause of the current exception.</param>
		public TextEditorException(string message, Exception inner)
			: base(message, inner)
		{
		}
	}
}
