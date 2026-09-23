namespace DocumentServer.Json
{
	/// <summary>Is thrown when calling the method MailMerge.MergeJsonData with an incomplete JSON string.</summary>
	public class UnexpectedEndOfInputException : ParserException
	{
		public UnexpectedEndOfInputException(int pos)
			: base("Unexpected end of input.", pos)
		{
		}
	}
}
