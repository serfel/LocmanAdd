using System;
using System.Collections.Generic;
using System.Globalization;
using DocumentServer.DataShaping;

namespace ns11
{
	internal class Class134 : IComparer<object>, IEqualityComparer<object>
	{
		private SortOrder sortOrder_0;

		public Class134(SortOrder sortOrder_1)
		{
			this.sortOrder_0 = sortOrder_1;
		}

		public Class134()
			: this(SortOrder.Ascending)
		{
		}

		int IComparer<object>.Compare(object x, object y)
		{
			return Class134.smethod_0(x, y, method_0, method_1);
		}

		bool IEqualityComparer<object>.Equals(object x, object y)
		{
			return Class134.smethod_0(x, y, method_0, method_1) == 0;
		}

		int IEqualityComparer<object>.GetHashCode(object obj)
		{
			return obj.GetHashCode();
		}

		private int method_0(double double_0, double double_1)
		{
			int num = ((double_0 < double_1) ? (-1) : ((double_0 != double_1) ? 1 : 0));
			if (this.sortOrder_0 == SortOrder.Descending)
			{
				num *= -1;
			}
			return num;
		}

		private int method_1(string string_0, string string_1)
		{
			int num = string_0.CompareTo(string_1);
			if (this.sortOrder_0 == SortOrder.Descending)
			{
				num *= -1;
			}
			return num;
		}

		private static int smethod_0(object object_0, object object_1, Func<double, double, int> func_0, Func<string, string, int> func_1)
		{
			if (object_1 != null && object_0 != null)
			{
				if (func_0 != null && Class134.smethod_1(object_0, out var double_) && Class134.smethod_1(object_1, out var double_2))
				{
					return func_0(double_, double_2);
				}
				if (func_1 != null)
				{
					Class134.smethod_3(object_0, out var string_);
					Class134.smethod_3(object_1, out var string_2);
					return func_1(string_, string_2);
				}
				return 0;
			}
			return 0;
		}

		internal static bool smethod_1(object object_0, out double double_0, CultureInfo cultureInfo_0 = null)
		{
			cultureInfo_0 = cultureInfo_0 ?? CultureInfo.InvariantCulture;
			if (Class134.smethod_2(out double_0, object_0))
			{
				return true;
			}
			Class134.smethod_3(object_0, out var string_);
			if (!double.TryParse(string_, NumberStyles.Number, cultureInfo_0, out double_0))
			{
				return false;
			}
			return true;
		}

		internal static bool smethod_2(out double double_0, object object_0)
		{
			double_0 = 0.0;
			switch (Type.GetTypeCode(object_0.GetType()))
			{
			default:
				return false;
			case TypeCode.SByte:
				double_0 = (sbyte)object_0;
				break;
			case TypeCode.Byte:
				double_0 = (int)(byte)object_0;
				break;
			case TypeCode.Int16:
				double_0 = (short)object_0;
				break;
			case TypeCode.UInt16:
				double_0 = (int)(ushort)object_0;
				break;
			case TypeCode.Int32:
				double_0 = (int)object_0;
				break;
			case TypeCode.UInt32:
				double_0 = (uint)object_0;
				break;
			case TypeCode.Int64:
				double_0 = (long)object_0;
				break;
			case TypeCode.UInt64:
				double_0 = (ulong)object_0;
				break;
			case TypeCode.Single:
				double_0 = (float)object_0;
				break;
			case TypeCode.Double:
				double_0 = (double)object_0;
				break;
			case TypeCode.Decimal:
				double_0 = (double)(decimal)object_0;
				break;
			}
			return true;
		}

		internal static void smethod_3(object object_0, out string string_0, CultureInfo cultureInfo_0 = null)
		{
			cultureInfo_0 = cultureInfo_0 ?? CultureInfo.InvariantCulture;
			string_0 = ((object_0 != null) ? string.Format(cultureInfo_0, "{0}", new object[1] { object_0 }) : "");
		}
	}
}
