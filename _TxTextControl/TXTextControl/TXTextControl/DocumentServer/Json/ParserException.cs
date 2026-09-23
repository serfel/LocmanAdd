using System;

namespace DocumentServer.Json
{
	/// <summary>Base class of all JSON parser related exceptions which can be thrown when calling method MailMerge.MergeJsonData with an incorrect JSON string.</summary>
	public abstract class ParserException : Exception
	{
		public ParserException(string message, int pos)
			: base($"{message} (Position: {pos})")
		{
		}
	}
}
