namespace DocumentServer.Json
{
	/// <summary>Is thrown when calling the method MailMerge.MergeJsonData and the internal JSON parser encounters an unknown error.</summary>
	public class UnknownParseErrorException : ParserException
	{
		public UnknownParseErrorException(int pos, string message)
			: base(message, pos)
		{
		}
	}
}
