using System.Reflection;

namespace DocumentServer.Json
{
	[Obfuscation(Exclude = true)]
	internal class UnknownSerializerException : SerializerException
	{
		public UnknownSerializerException(string message)
			: base(message)
		{
		}
	}
}
