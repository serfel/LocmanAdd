using System.Reflection;

namespace DocumentServer.Json
{
	[Obfuscation(Exclude = true)]
	internal class CircularReferenceException : SerializerException
	{
		public CircularReferenceException(string message)
			: base(message)
		{
		}
	}
}
