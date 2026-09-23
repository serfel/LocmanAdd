namespace DocumentServer.Json
{
	public class ExistingPropertyException : ParserException
	{
		public ExistingPropertyException(int pos, string propertyName)
			: base($"Property \"{propertyName}\" already exists.", pos)
		{
		}
	}
}
