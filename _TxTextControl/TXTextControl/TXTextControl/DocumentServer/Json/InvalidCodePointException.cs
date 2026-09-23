namespace DocumentServer.Json
{
	/// <summary>Is thrown when calling the method MailMerge.MergeJsonData with a JSON string containing an invalid hexadecimal unicode code point.</summary>
	public class InvalidCodePointException : ParserException
	{
		public InvalidCodePointException(int pos, string codePoint)
			: base("Invalid unicode code point: " + codePoint, pos)
		{
		}
	}
}
