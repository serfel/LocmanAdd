using System;
using System.Drawing;
using System.Runtime.InteropServices;
using ns21;

namespace TXTextControl
{
	internal static class KernelHelper
	{
		internal static string GetString(string str)
		{
			int length = str.Length;
			int i;
			for (i = 0; i < length && str[i] != 0; i++)
			{
			}
			return str.Substring(0, i);
		}

		internal static string GetString(char[] arr)
		{
			int num = arr.Length;
			int i;
			for (i = 0; i < num && arr[i] != 0; i++)
			{
			}
			return new string(arr, 0, i);
		}

		internal static Color TxColor2SysDrawingColor(uint dwColor, bool bBkGnd)
		{
			if (dwColor != 1342177280)
			{
				if (bBkGnd && dwColor == 1073741824)
				{
					return SystemColors.Window;
				}
				if (!bBkGnd && dwColor == 1073741824)
				{
					return SystemColors.WindowText;
				}
				return Class429.smethod_2((int)dwColor);
			}
			return Color.Transparent;
		}

		internal static uint SysDrawingColor2TxColor(Color color, bool bBkGnd)
		{
			if (bBkGnd && color == Color.Transparent)
			{
				return 1342177280u;
			}
			if (bBkGnd && color == SystemColors.Window)
			{
				return 1073741824u;
			}
			if (!bBkGnd && color == SystemColors.WindowText)
			{
				return 1073741824u;
			}
			return (uint)Class429.smethod_0(color);
		}

		internal static uint SysDrawingColor2TxColor(Color? color, bool bBkGnd)
		{
			if (!color.HasValue)
			{
				return 2147483648u;
			}
			return KernelHelper.SysDrawingColor2TxColor(color.Value, bBkGnd);
		}

		internal static char[] StringArray2CharArray(string[] string_0)
		{
			if (string_0 != null && string_0.Length > 0)
			{
				int num = 1;
				foreach (string text in string_0)
				{
					num += text.Length + 1;
				}
				char[] array = new char[num];
				int num2 = 0;
				foreach (string text2 in string_0)
				{
					text2.CopyTo(0, array, num2, text2.Length);
					num2 += text2.Length;
					array[num2++] = '\0';
				}
				array[num2] = '\0';
				return array;
			}
			return null;
		}

		internal static string[] Ptr2StringArray(IntPtr ptr)
		{
			int i = 0;
			int num = 0;
			while ((ushort)Marshal.ReadInt16(ptr, i) != 0)
			{
				for (; (ushort)Marshal.ReadInt16(ptr, i) != 0; i += 2)
				{
				}
				i += 2;
				num++;
			}
			char[] array = new char[i / 2];
			Marshal.Copy(ptr, array, 0, i / 2);
			string[] array2 = new string[num];
			int num2 = 0;
			int num3 = 0;
			while (num2 < num)
			{
				int j;
				for (j = 0; array[num3 + j] != 0; j++)
				{
				}
				array2[num2] = new string(array, num3, j);
				num2++;
				num3 += j + 1;
			}
			return array2;
		}

		internal static string[] Ptr2StringArray(IntPtr ptr, int iStrings)
		{
			int i = 0;
			for (int j = 0; j < iStrings; j++)
			{
				for (; (ushort)Marshal.ReadInt16(ptr, i) != 0; i += 2)
				{
				}
				i += 2;
			}
			char[] array = new char[i / 2];
			Marshal.Copy(ptr, array, 0, i / 2);
			string[] array2 = new string[iStrings];
			int num = 0;
			int num2 = 0;
			while (num < iStrings)
			{
				int k;
				for (k = 0; array[num2 + k] != 0; k++)
				{
				}
				array2[num] = new string(array, num2, k);
				num++;
				num2 += k + 1;
			}
			return array2;
		}

		internal static Enum93 HFTypeToPrev(HeaderFooterType headerFooterType)
		{
			Enum93 @enum = (Enum93)((int)(headerFooterType & (HeaderFooterType.Header | HeaderFooterType.FirstPageHeader | HeaderFooterType.Footer | HeaderFooterType.FirstPageFooter)) << 16);
			if ((headerFooterType & HeaderFooterType.EvenHeader) != 0)
			{
				@enum |= Enum93.const_21;
			}
			if ((headerFooterType & HeaderFooterType.EvenFooter) != 0)
			{
				@enum |= Enum93.const_22;
			}
			return @enum;
		}

		internal static string UTCStringFromDateTime(DateTime dateTime_0)
		{
			if (dateTime_0.Year == 1)
			{
				return string.Empty;
			}
			return dateTime_0.Year.ToString("D4") + '-' + dateTime_0.Month.ToString("D2") + '-' + dateTime_0.Day.ToString("D2") + 'T' + dateTime_0.Hour.ToString("D2") + ':' + dateTime_0.Minute.ToString("D2") + ':' + dateTime_0.Second.ToString("D2");
		}

		internal static DateTime DateTimeFromUTCString(string strUTC)
		{
			return new DateTime(int.Parse(strUTC.Substring(0, 4)), int.Parse(strUTC.Substring(5, 2)), int.Parse(strUTC.Substring(8, 2)), int.Parse(strUTC.Substring(11, 2)), int.Parse(strUTC.Substring(14, 2)), int.Parse(strUTC.Substring(17, 2)), DateTimeKind.Utc);
		}

		internal static PaperSize[] Ptr2PaperSizeArray(IntPtr ptr)
		{
			char[] array = new char[64];
			int num = 136;
			int num2 = 0;
			int num3 = 0;
			while (Marshal.ReadInt32(ptr, num2) != 0)
			{
				num2 += num;
				num3++;
			}
			PaperSize[] array2 = new PaperSize[num3];
			int i = 0;
			num2 = 0;
			for (; i < num3; i++)
			{
				int iWidth = Marshal.ReadInt32(ptr, num2);
				num2 += 4;
				int iHeight = Marshal.ReadInt32(ptr, num2);
				num2 += 4;
				int num4 = 0;
				while (num4 < 64)
				{
					array[num4] = (char)Marshal.ReadInt16(ptr, num2);
					num4++;
					num2 += 2;
				}
				array2[i] = new PaperSize(iWidth, iHeight, KernelHelper.GetString(array));
			}
			return array2;
		}

		internal static int[] PtrInt16ToIntArray(IntPtr ptr)
		{
			int num = 0;
			int num2 = 0;
			while (Marshal.ReadInt16(ptr, num) != 0)
			{
				num += 2;
				num2++;
			}
			int[] array = new int[num2];
			int i = 0;
			num = 0;
			for (; i < num2; i++)
			{
				array[i] = Marshal.ReadInt16(ptr, num);
				num += 2;
			}
			return array;
		}

		internal static int[] PtrInt32ToIntArray(IntPtr ptr)
		{
			int num = 0;
			int num2 = 0;
			while (Marshal.ReadInt32(ptr, num) != 0)
			{
				num += 4;
				num2++;
			}
			int[] array = new int[num2];
			int i = 0;
			num = 0;
			for (; i < num2; i++)
			{
				array[i] = Marshal.ReadInt32(ptr, num);
				num += 4;
			}
			return array;
		}

		internal static bool IsSingleSection(int iSectionNumber)
		{
			if (iSectionNumber != 0)
			{
				return iSectionNumber != 65535;
			}
			return false;
		}
	}
}
