using System.Collections.Generic;
using System.Reflection;

namespace DocumentServer.Json
{
	[Obfuscation(Exclude = true)]
	internal static class JsonConvert
	{
		public static object DeserializeObject(string json)
		{
			return new JsonParser(json).Parse();
		}

		public static T Deserialize<T>(string json)
		{
			return new JsonParser(json).Parse<T>();
		}

		public static Dictionary<string, object>[] DeserializeArray(string json)
		{
			return new JsonParser(json).ParseArray<Dictionary<string, object>>();
		}

		public static T[] DeserializeArray<T>(string json)
		{
			return new JsonParser(json).ParseArray<T>();
		}

		public static string Serialize(object obj)
		{
			return new Serializer(obj).Serialize();
		}

		public static T ConvertToType<T>(object obj)
		{
			T gparam_ = (T)typeof(T).CreateInstanceOrGetDefault();
			JsonParser.smethod_0(ref gparam_, obj);
			return gparam_;
		}
	}
}
