using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace DocumentServer.Json
{
	[Obfuscation(Exclude = true)]
	internal class JsonParser : Parser<object>
	{
		private enum Enum26
		{
			const_0,
			const_1,
			const_2,
			const_3
		}

		private enum Enum27
		{
			const_0,
			const_1,
			const_2,
			const_3,
			const_4,
			const_5,
			const_6,
			const_7,
			const_8,
			const_9
		}

		private Enum27 enum27_0;

		private string string_0;

		private object object_0;

		private object object_1;

		private List<object> list_0;

		private Dictionary<string, object> dictionary_0;

		private StringBuilder stringBuilder_0;

		protected override bool IsDone => this.enum27_0 == Enum27.const_9;

		public JsonParser(string json)
			: this(json, 0)
		{
		}

		private JsonParser(string json, int start)
			: base(json, start)
		{
			this.enum27_0 = Enum27.const_0;
		}

		public TObj Parse<TObj>()
		{
			TObj gparam_ = (TObj)typeof(TObj).CreateInstanceOrGetDefault();
			JsonParser.smethod_0(ref gparam_, base.Parse());
			return gparam_;
		}

		public TObj[] ParseArray<TObj>()
		{
			object obj = base.Parse();
			if (obj == null)
			{
				return null;
			}
			if (!obj.GetType().IsArray)
			{
				throw new ArgumentException("Provided JSON string must contain an array.", "json");
			}
			object[] object_ = (object[])obj;
			List<TObj> list_ = new List<TObj>();
			JsonParser.smethod_1(ref list_, object_);
			return list_.ToArray();
		}

		protected override void ParseNextTokens()
		{
			switch (this.enum27_0)
			{
			case Enum27.const_0:
				this.method_0();
				break;
			case Enum27.const_1:
				this.method_1();
				break;
			case Enum27.const_2:
				this.method_7();
				break;
			case Enum27.const_3:
				this.method_11();
				break;
			case Enum27.const_4:
				this.method_12();
				break;
			case Enum27.const_5:
				this.method_13();
				break;
			case Enum27.const_6:
				this.method_14();
				break;
			case Enum27.const_7:
				this.method_15();
				break;
			case Enum27.const_8:
				this.method_16();
				break;
			}
		}

		private void method_0()
		{
			base.White();
			char c = base.Peek();
			switch (c)
			{
			case '-':
			case '0':
			case '1':
			case '2':
			case '3':
			case '4':
			case '5':
			case '6':
			case '7':
			case '8':
			case '9':
				this.enum27_0 = Enum27.const_3;
				return;
			}
			switch (c)
			{
			case '[':
				base.Consume();
				this.list_0 = new List<object>();
				this.enum27_0 = Enum27.const_2;
				break;
			case '"':
				base.Consume();
				this.stringBuilder_0 = new StringBuilder();
				this.enum27_0 = Enum27.const_4;
				break;
			case '{':
				base.Consume();
				this.dictionary_0 = new Dictionary<string, object>();
				this.enum27_0 = Enum27.const_1;
				break;
			default:
				throw new UnexpectedTokenException(base.m_pos, c);
			case 'f':
			case 't':
				this.enum27_0 = Enum27.const_7;
				break;
			case 'n':
				this.enum27_0 = Enum27.const_8;
				break;
			}
		}

		private void method_1()
		{
			base.White();
			char c = base.Peek();
			switch (c)
			{
			case ',':
				this.method_4();
				break;
			case '"':
				this.method_2();
				break;
			default:
				this.method_6(c);
				break;
			case '}':
				this.method_5();
				break;
			case ':':
				this.method_3();
				break;
			}
		}

		private void method_2()
		{
			if (this.string_0 == null)
			{
				base.Consume();
				this.stringBuilder_0 = new StringBuilder();
				this.enum27_0 = Enum27.const_4;
			}
			else
			{
				JsonParser jsonParser = new JsonParser(base.m_input, base.m_pos);
				this.object_0 = jsonParser.Parse();
				base.m_pos = jsonParser.Position;
			}
		}

		private void method_3()
		{
			if (this.stringBuilder_0 == null || this.string_0 != null)
			{
				throw new UnexpectedTokenException(base.m_pos, ':');
			}
			base.Consume();
			this.string_0 = this.stringBuilder_0.ToString();
			this.stringBuilder_0 = null;
		}

		private void method_4()
		{
			if (this.string_0 == null || this.object_0 == null)
			{
				throw new UnexpectedTokenException(base.m_pos, ',');
			}
			base.Consume();
			this.method_17();
		}

		private void method_5()
		{
			if (this.string_0 != null && this.object_0 != null)
			{
				base.Consume();
				this.method_17();
			}
			else
			{
				if (this.stringBuilder_0 != null || this.dictionary_0.Count != 0 || this.string_0 != null || this.object_0 != null)
				{
					throw new UnexpectedTokenException(base.m_pos, '}');
				}
				base.Consume();
			}
			base.m_result = this.dictionary_0;
			this.dictionary_0 = null;
			this.enum27_0 = Enum27.const_9;
		}

		private void method_6(char char_0)
		{
			if (this.string_0 != null && this.object_0 == null)
			{
				JsonParser jsonParser = new JsonParser(base.m_input, base.m_pos);
				object obj = jsonParser.Parse();
				this.object_0 = obj ?? ((object)Enum26.const_3);
				base.m_pos = jsonParser.Position;
				return;
			}
			throw new UnexpectedTokenException(base.m_pos, char_0);
		}

		private void method_7()
		{
			base.White();
			char c = base.Peek();
			switch (c)
			{
			default:
				this.method_10(c);
				break;
			case ']':
				this.method_9();
				break;
			case ',':
				this.method_8();
				break;
			}
		}

		private void method_8()
		{
			if (this.object_1 == null)
			{
				throw new UnexpectedTokenException(base.m_pos, ',');
			}
			base.Consume();
			this.method_18();
		}

		private void method_9()
		{
			if (this.object_1 != null)
			{
				base.Consume();
				this.method_18();
			}
			else
			{
				if (this.list_0.Count != 0 || this.object_1 != null)
				{
					throw new UnexpectedTokenException(base.m_pos, ']');
				}
				base.Consume();
			}
			base.m_result = this.list_0.ToArray();
			this.list_0 = null;
			this.enum27_0 = Enum27.const_9;
		}

		private void method_10(char char_0)
		{
			if (this.object_1 == null)
			{
				JsonParser jsonParser = new JsonParser(base.m_input, base.m_pos);
				object obj = jsonParser.Parse();
				this.object_1 = obj ?? ((object)Enum26.const_3);
				base.m_pos = jsonParser.Position;
				return;
			}
			throw new UnexpectedTokenException(base.m_pos, char_0);
		}

		private void method_11()
		{
			NumberParser numberParser = new NumberParser(base.m_input, base.m_pos);
			base.m_result = numberParser.Parse();
			double num = (double)base.m_result;
			if (Math.Abs(num) <= 9.2233720368547758E+18 && Math.Abs(num % 1.0) <= double.Epsilon)
			{
				if (Math.Abs(num) <= 2147483647.0)
				{
					base.m_result = (int)Math.Round(num);
				}
				else
				{
					base.m_result = (long)Math.Round(num);
				}
			}
			base.m_pos = numberParser.Position;
			this.enum27_0 = Enum27.const_9;
		}

		private void method_12()
		{
			char c = base.Consume();
			if (c.IsControlChar())
			{
				throw new UnexpectedTokenException(base.m_pos - 1, c);
			}
			switch (c)
			{
			default:
				this.stringBuilder_0.Append(c);
				break;
			case '\\':
				this.enum27_0 = Enum27.const_5;
				break;
			case '"':
				if (this.dictionary_0 != null)
				{
					this.enum27_0 = Enum27.const_1;
					break;
				}
				base.m_result = this.stringBuilder_0.ToString();
				this.stringBuilder_0 = null;
				this.enum27_0 = Enum27.const_9;
				break;
			}
		}

		private void method_13()
		{
			char c = base.Consume();
			switch (c)
			{
			case '"':
			case '/':
			case '\\':
				this.stringBuilder_0.Append(c);
				this.enum27_0 = Enum27.const_4;
				break;
			case 'f':
				this.stringBuilder_0.Append('\f');
				this.enum27_0 = Enum27.const_4;
				break;
			case 'b':
				this.stringBuilder_0.Append('\b');
				this.enum27_0 = Enum27.const_4;
				break;
			case 'r':
				this.stringBuilder_0.Append('\r');
				this.enum27_0 = Enum27.const_4;
				break;
			default:
				throw new UnexpectedTokenException(base.m_pos - 1, c);
			case 't':
				this.stringBuilder_0.Append('\t');
				this.enum27_0 = Enum27.const_4;
				break;
			case 'u':
				this.enum27_0 = Enum27.const_6;
				break;
			case 'n':
				this.stringBuilder_0.Append('\n');
				this.enum27_0 = Enum27.const_4;
				break;
			}
		}

		private void method_14()
		{
			string text = base.Consume(4);
			try
			{
				char value = (char)Convert.ToUInt16(text, 16);
				this.stringBuilder_0.Append(value);
				this.enum27_0 = Enum27.const_4;
			}
			catch (FormatException)
			{
				throw new InvalidCodePointException(base.m_pos - 4, text);
			}
		}

		private void method_15()
		{
			char c = base.Peek();
			Enum26 @enum;
			switch (c)
			{
			case 't':
			{
				string text2 = base.Consume(4);
				if (text2 != "true")
				{
					throw new UnknownLiteralNameTokenException(base.m_pos - 4, text2);
				}
				@enum = Enum26.const_1;
				break;
			}
			default:
				throw new UnexpectedTokenException(base.m_pos, c);
			case 'f':
			{
				string text = base.Consume(5);
				if (text != "false")
				{
					throw new UnknownLiteralNameTokenException(base.m_pos - 5, text);
				}
				@enum = Enum26.const_2;
				break;
			}
			}
			base.m_result = @enum == Enum26.const_1;
			this.enum27_0 = Enum27.const_9;
		}

		private void method_16()
		{
			string text = base.Consume(4);
			if (text != "null")
			{
				throw new UnknownLiteralNameTokenException(base.m_pos - 4, text);
			}
			base.m_result = null;
			this.enum27_0 = Enum27.const_9;
		}

		private void method_17()
		{
			if (this.object_0 is Enum26)
			{
				if ((Enum26)this.object_0 != Enum26.const_3)
				{
					throw new UnknownParseErrorException(base.m_pos, "If m_currentPropVal is of type \"LiteralNameToken\" in AddPropToObject() its value must be \"LiteralNameToken.Null\".");
				}
				this.object_0 = null;
			}
			try
			{
				this.dictionary_0.Add(this.string_0, this.object_0);
			}
			catch (ArgumentException)
			{
				throw new ExistingPropertyException(base.m_pos, this.string_0);
			}
			this.string_0 = null;
			this.object_0 = null;
		}

		private void method_18()
		{
			if (this.object_1 is Enum26)
			{
				if ((Enum26)this.object_1 != Enum26.const_3)
				{
					throw new UnknownParseErrorException(base.m_pos, "If m_currentArrayElem is of type \"LiteralNameToken\" in AddElemToArray() its value must be \"LiteralNameToken.Null\".");
				}
				this.object_1 = null;
			}
			this.list_0.Add(this.object_1);
			this.object_1 = null;
		}

		internal static void smethod_0<TObj>(ref TObj gparam_0, object object_2, Type type_0 = null)
		{
			bool isNullable = false;
			type_0 = ((!(type_0 != null)) ? ((gparam_0 == null) ? typeof(TObj) : gparam_0.GetType().GetUnderlyingType(out isNullable)) : type_0.GetUnderlyingType(out isNullable));
			if (type_0 == typeof(object) && object_2 != null)
			{
				type_0 = object_2.GetType().GetUnderlyingType(out isNullable);
			}
			if (isNullable && object_2 == null)
			{
				gparam_0 = default(TObj);
			}
			else if (!type_0.IsSimpleType() && !type_0.IsCorrectDictType() && !type_0.IsEnumerableType())
			{
				if (object_2 != null && type_0 == typeof(DateTime) && object_2.GetType().IsIntegralType())
				{
					gparam_0 = (TObj)(object)JsonParser.ConvertFromUnixTimestamp(Convert.ToInt64(object_2));
					return;
				}
				if (object_2 == null)
				{
					gparam_0 = default(TObj);
					return;
				}
				if (gparam_0 == null)
				{
					throw new ArgumentException($"For some reason an object which is to be filled with values is null. Perhaps type \"{type_0.Name}\" is missing a default constructor?");
				}
				Dictionary<string, object> dictionary = object_2 as Dictionary<string, object>;
				if (dictionary == null)
				{
					dictionary = (Dictionary<string, object>)JsonConvert.DeserializeObject(JsonConvert.Serialize(object_2));
				}
				PropertyInfo[] publicSettableProps = type_0.GetPublicSettableProps();
				foreach (PropertyInfo propertyInfo in publicSettableProps)
				{
					if (dictionary.ContainsKey(propertyInfo.Name))
					{
						try
						{
							JsonParser.smethod_2(propertyInfo, dictionary[propertyInfo.Name], gparam_0);
						}
						catch (Exception ex)
						{
							throw new Exception(string.Format("Could not deserialize property {1}.{0}: {2}", propertyInfo.Name, type_0.Name, ex.Message));
						}
					}
				}
			}
			else if (!type_0.IsEnum && type_0.IsNumericType())
			{
				gparam_0 = (TObj)Convert.ChangeType(object_2, type_0);
			}
			else
			{
				gparam_0 = (TObj)object_2;
			}
		}

		private static void smethod_1<TObj>(ref List<TObj> list_1, object[] object_2)
		{
			list_1.AddRange(object_2.Select(delegate(object elem)
			{
				TObj gparam_ = (TObj)typeof(TObj).CreateInstanceOrGetDefault();
				if (gparam_ == null)
				{
					throw new ArgumentException($"Requested array element type \"{typeof(TObj).Name}\" must have a default constructor.", "TObj");
				}
				JsonParser.smethod_0(ref gparam_, elem);
				return gparam_;
			}));
		}

		private static void smethod_2<TObj>(PropertyInfo propertyInfo_0, object object_2, TObj gparam_0)
		{
			object gparam_ = propertyInfo_0.PropertyType.CreateInstanceOrGetDefault();
			JsonParser.smethod_0(ref gparam_, object_2, propertyInfo_0.PropertyType);
			Type underlyingType = propertyInfo_0.PropertyType.GetUnderlyingType();
			if (gparam_ != null)
			{
				if (underlyingType.IsEnum && gparam_.TryConvertToDecimal(out var dec))
				{
					gparam_ = Enum.ToObject(underlyingType, (int)dec);
				}
				gparam_ = ((!underlyingType.IsArray) ? Convert.ChangeType(gparam_, underlyingType) : JsonParser.smethod_3((object[])gparam_, underlyingType.GetElementType()));
			}
			propertyInfo_0.SetValue(gparam_0, gparam_, null);
		}

		[Obfuscation(Exclude = true)]
		internal static T[] ConvertToArray<T>(object[] array)
		{
			List<T> list_ = new List<T>();
			JsonParser.smethod_1(ref list_, array);
			return list_.ToArray();
		}

		internal static object smethod_3(object[] object_2, Type type_0)
		{
			return typeof(JsonParser).GetMethod("ConvertToArray", BindingFlags.Static | BindingFlags.NonPublic).MakeGenericMethod(type_0).Invoke(null, new object[1] { object_2 });
		}

		public static DateTime ConvertFromUnixTimestamp(long timestamp)
		{
			return new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc).AddSeconds(timestamp);
		}
	}
}
