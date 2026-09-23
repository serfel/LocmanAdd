namespace DocumentServer.Json
{
	/// <summary>Is thrown when calling the method MailMerge.MergeJsonData with a JSON string containing an unknown character sequence at a position where one of the strings "true", "false" or "null" are expected.</summary>
	public class UnknownLiteralNameTokenException : ParserException
	{
		public UnknownLiteralNameTokenException(int pos, string literalNameToken)
			: base("Unknown literal name token: " + literalNameToken, pos)
		{
		}
	}
}
