using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using System.Text;

namespace DocumentServer.Json
{
	[Obfuscation(Exclude = true)]
	internal class Serializer
	{
		private object object_0;

		private Stack<object> stack_0 = new Stack<object>();

		public Serializer(object obj)
		{
			this.object_0 = obj;
		}

		public string Serialize()
		{
			StringBuilder stringBuilder = new StringBuilder();
			this.method_0(this.object_0, stringBuilder);
			return stringBuilder.ToString();
		}

		private void method_0(object object_1, StringBuilder stringBuilder_0)
		{
			if (object_1 == null)
			{
				stringBuilder_0.Append("null");
				return;
			}
			if (this.stack_0.Contains(object_1))
			{
				throw new CircularReferenceException($"Circular reference detected in type \"{object_1.GetType().Name}\". Aborting serialization.");
			}
			this.stack_0.Push(object_1);
			Type type = object_1.GetType();
			if (type.IsSimpleType())
			{
				this.method_2(object_1, stringBuilder_0);
			}
			else if (type == typeof(DateTime))
			{
				stringBuilder_0.Append(((DateTime)object_1).ToUnixTimestamp());
			}
			else if (type.IsCorrectDictType())
			{
				this.method_4((IDictionary)object_1, stringBuilder_0);
			}
			else if (type.IsEnumerableType())
			{
				this.method_3((IEnumerable)object_1, stringBuilder_0);
			}
			else
			{
				this.method_1(object_1, stringBuilder_0);
			}
			this.stack_0.Pop();
		}

		private void method_1(object object_1, StringBuilder stringBuilder_0)
		{
			PropertyInfo[] publicGettableProps = object_1.GetType().GetPublicGettableProps();
			List<string> list = new List<string>();
			PropertyInfo[] array = publicGettableProps;
			foreach (PropertyInfo propertyInfo in array)
			{
				StringBuilder stringBuilder = new StringBuilder();
				stringBuilder.Append("\"");
				stringBuilder.Append(propertyInfo.Name);
				stringBuilder.Append("\":");
				this.method_0(propertyInfo.GetValue(object_1, null), stringBuilder);
				list.Add(stringBuilder.ToString());
			}
			stringBuilder_0.Append("{");
			stringBuilder_0.Append(string.Join(",", list.ToArray()));
			stringBuilder_0.Append("}");
		}

		private void method_2(object object_1, StringBuilder stringBuilder_0)
		{
			if (object_1 is string)
			{
				stringBuilder_0.Append("\"");
				this.method_5((string)object_1, stringBuilder_0);
				stringBuilder_0.Append("\"");
			}
			else if (object_1.GetType().IsNumericType())
			{
				object_1.TryConvertToDecimal(out var dec);
				stringBuilder_0.Append(dec.ToString(CultureInfo.InvariantCulture));
			}
			else if (object_1 is bool)
			{
				if ((bool)object_1)
				{
					stringBuilder_0.Append("true");
				}
				else
				{
					stringBuilder_0.Append("false");
				}
			}
			else
			{
				stringBuilder_0.Append(object_1.ToString());
			}
		}

		private void method_3(IEnumerable ienumerable_0, StringBuilder stringBuilder_0)
		{
			List<string> list = new List<string>();
			foreach (object item in ienumerable_0)
			{
				StringBuilder stringBuilder = new StringBuilder();
				this.method_0(item, stringBuilder);
				list.Add(stringBuilder.ToString());
			}
			stringBuilder_0.Append("[");
			stringBuilder_0.Append(string.Join(",", list.ToArray()));
			stringBuilder_0.Append("]");
		}

		private void method_4(IDictionary idictionary_0, StringBuilder stringBuilder_0)
		{
			if (!idictionary_0.GetType().IsCorrectDictType())
			{
				throw new UnknownSerializerException("SerializeStringKeyDictionary(): the given dictionary is not of the expected type.");
			}
			List<string> list = new List<string>();
			foreach (string key in idictionary_0.Keys)
			{
				StringBuilder stringBuilder = new StringBuilder();
				stringBuilder.Append("\"");
				stringBuilder.Append(key);
				stringBuilder.Append("\":");
				this.method_0(idictionary_0[key], stringBuilder);
				list.Add(stringBuilder.ToString());
			}
			stringBuilder_0.Append("{");
			stringBuilder_0.Append(string.Join(",", list.ToArray()));
			stringBuilder_0.Append("}");
		}

		private void method_5(string string_0, StringBuilder stringBuilder_0)
		{
			char[] array = string_0.ToCharArray();
			int num = array.Length;
			for (int i = 0; i < num; i++)
			{
				char c = array[i];
				switch (c)
				{
				case '\\':
					stringBuilder_0.Append("\\\\");
					continue;
				case '"':
					stringBuilder_0.Append("\\\"");
					continue;
				case '\b':
					stringBuilder_0.Append("\\b");
					continue;
				case '\t':
					stringBuilder_0.Append("\\t");
					continue;
				case '\n':
					stringBuilder_0.Append("\\n");
					continue;
				case '\f':
					stringBuilder_0.Append("\\f");
					continue;
				case '\r':
					stringBuilder_0.Append("\\r");
					continue;
				}
				if (c.IsControlChar())
				{
					stringBuilder_0.Append($"\\u{(int)c:X4}");
				}
				else
				{
					stringBuilder_0.Append(c);
				}
			}
		}
	}
}
