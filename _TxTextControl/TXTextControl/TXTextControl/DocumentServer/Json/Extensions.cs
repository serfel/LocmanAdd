using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace DocumentServer.Json
{
	internal static class Extensions
	{
		private static readonly DateTime Epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

		public static Type GetUnderlyingType(this Type type, out bool isNullable)
		{
			isNullable = type.IsNullableType();
			if (!isNullable)
			{
				return type;
			}
			return Nullable.GetUnderlyingType(type);
		}

		public static Type GetUnderlyingType(this Type type)
		{
			bool isNullable;
			return type.GetUnderlyingType(out isNullable);
		}

		public static bool IsSimpleType(this Type type)
		{
			if (type.IsNumericType())
			{
				return true;
			}
			TypeCode typeCode = Type.GetTypeCode(type);
			if ((uint)(typeCode - 3) > 1u && typeCode != TypeCode.String)
			{
				return false;
			}
			return true;
		}

		public static bool IsNumericType(this Type type)
		{
			TypeCode typeCode = Type.GetTypeCode(type);
			if ((uint)(typeCode - 5) <= 10u)
			{
				return true;
			}
			return false;
		}

		public static bool IsIntegralType(this Type type)
		{
			TypeCode typeCode = Type.GetTypeCode(type);
			if ((uint)(typeCode - 5) <= 7u)
			{
				return true;
			}
			return false;
		}

		public static bool TryConvertToDecimal(this object obj, out decimal dec)
		{
			bool result = true;
			dec = default(decimal);
			switch (Type.GetTypeCode(obj.GetType()))
			{
			default:
				result = false;
				break;
			case TypeCode.SByte:
				dec = new decimal((sbyte)obj);
				break;
			case TypeCode.Byte:
				dec = new decimal((byte)obj);
				break;
			case TypeCode.Int16:
				dec = new decimal((short)obj);
				break;
			case TypeCode.UInt16:
				dec = new decimal((ushort)obj);
				break;
			case TypeCode.Int32:
				dec = new decimal((int)obj);
				break;
			case TypeCode.UInt32:
				dec = new decimal((uint)obj);
				break;
			case TypeCode.Int64:
				dec = new decimal((long)obj);
				break;
			case TypeCode.UInt64:
				dec = new decimal((ulong)obj);
				break;
			case TypeCode.Single:
				dec = new decimal((float)obj);
				break;
			case TypeCode.Double:
				dec = new decimal((double)obj);
				break;
			case TypeCode.Decimal:
				dec = (decimal)obj;
				break;
			}
			return result;
		}

		public static PropertyInfo[] GetPublicGettableProps(this Type type)
		{
			List<PropertyInfo> list = new List<PropertyInfo>();
			PropertyInfo[] properties = type.GetProperties(BindingFlags.Instance | BindingFlags.Public);
			foreach (PropertyInfo propertyInfo in properties)
			{
				if (propertyInfo.GetIndexParameters().Length == 0)
				{
					MethodInfo getMethod = propertyInfo.GetGetMethod();
					if (!(getMethod == null) && getMethod.IsPublic)
					{
						list.Add(propertyInfo);
					}
				}
			}
			return list.ToArray();
		}

		public static PropertyInfo[] GetPublicSettableProps(this Type type)
		{
			List<PropertyInfo> list = new List<PropertyInfo>();
			PropertyInfo[] properties = type.GetProperties(BindingFlags.Instance | BindingFlags.Public);
			foreach (PropertyInfo propertyInfo in properties)
			{
				if (propertyInfo.GetIndexParameters().Length == 0)
				{
					MethodInfo setMethod = propertyInfo.GetSetMethod();
					if (!(setMethod == null) && setMethod.IsPublic)
					{
						list.Add(propertyInfo);
					}
				}
			}
			return list.ToArray();
		}

		public static bool IsEnumerableType(this Type type)
		{
			if (!(type == typeof(IEnumerable)))
			{
				return type.GetInterfaces().Any((Type t) => t == typeof(IEnumerable));
			}
			return true;
		}

		public static bool IsGenericEnumerableType(this Type type)
		{
			if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(IEnumerable<>))
			{
				return true;
			}
			return type.GetInterfaces().Any((Type t) => t.IsGenericType && t.GetGenericTypeDefinition() == typeof(IEnumerable<>));
		}

		public static bool IsCorrectDictType(this Type type)
		{
			if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Dictionary<, >))
			{
				return type.GetGenericArguments()[0] == typeof(string);
			}
			return false;
		}

		public static bool IsNullableType(this Type type)
		{
			if (type.IsGenericType)
			{
				return type.GetGenericTypeDefinition().Equals(typeof(Nullable<>));
			}
			return false;
		}

		public static object CreateInstanceOrGetDefault(this Type type)
		{
			if (Type.GetTypeCode(type) == TypeCode.String)
			{
				return string.Empty;
			}
			if (!type.IsValueType && !(type.GetConstructor(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, Type.EmptyTypes, null) != null))
			{
				return null;
			}
			return Activator.CreateInstance(type, nonPublic: true);
		}

		public static bool IsControlChar(this char char_0)
		{
			if (char_0 >= '\0')
			{
				return char_0 <= '\u001f';
			}
			return false;
		}

		public static long ToUnixTimestamp(this DateTime dateTime)
		{
			return (long)Math.Round((dateTime.ToUniversalTime() - Extensions.Epoch).TotalSeconds);
		}
	}
}
