using System;
using System.Reflection;

namespace DocumentServer.Json
{
	[Obfuscation(Exclude = true)]
	internal abstract class SerializerException : Exception
	{
		public SerializerException(string message)
			: base(message)
		{
		}
	}
}
