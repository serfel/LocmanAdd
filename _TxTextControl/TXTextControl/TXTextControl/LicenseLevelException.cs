using System;

namespace TXTextControl
{
	/// <summary>A LicenseLevelException is thrown when a feature is not contained in the currently licensed product level.</summary>
	public class LicenseLevelException : Exception
	{
		/// <summary>Initializes a new instance of the LicenseLevelException class.</summary>
		public LicenseLevelException()
		{
		}

		/// <summary>Initializes a new instance of the LicenseLevelException class with a specified error message.</summary>
		/// <param name="message">The error message that explains the reason for the exception.</param>
		public LicenseLevelException(string message)
			: base(message)
		{
		}

		/// <summary>Initializes a new instance of the LicenseLevelException class with a specified error message and a reference to the inner exception that is the cause of this exception.</summary>
		/// <param name="message">The error message that explains the reason for the exception.</param>
		/// <param name="innerException">The exception that is the cause of the current exception.</param>
		public LicenseLevelException(string message, Exception inner)
			: base(message, inner)
		{
		}
	}
}
