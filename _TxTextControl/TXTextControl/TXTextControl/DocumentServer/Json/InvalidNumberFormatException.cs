namespace DocumentServer.Json
{
	/// <summary>Is thrown when calling the method MailMerge.MergeJsonData with a JSON string containing a number with an invalid number format.</summary>
	public class InvalidNumberFormatException : ParserException
	{
		public InvalidNumberFormatException(int pos, string number)
			: base("Invalid number format: " + number, pos)
		{
		}
	}
}
