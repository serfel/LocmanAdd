namespace DocumentServer.Json
{
	/// <summary>Is thrown when calling the method MailMerge.MergeJsonData with a JSON string containing an unexpected character.</summary>
	public class UnexpectedTokenException : ParserException
	{
		public UnexpectedTokenException(int pos, char token)
			: base("Unexpected token: '" + token + "'", pos)
		{
		}
	}
}
