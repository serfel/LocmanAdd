using System.Collections.Generic;

namespace DocumentServer.DataSources
{
	internal static class StringExtensions
	{
		public static bool IsChildColumnName(this string name)
		{
			string[] array = name.Split('.');
			if (array.Length < 2)
			{
				return false;
			}
			string[] array2 = array;
			int num = 0;
			while (true)
			{
				if (num < array2.Length)
				{
					if (array2[num].Trim().Length == 0)
					{
						break;
					}
					num++;
					continue;
				}
				return true;
			}
			return false;
		}

		public static string ToChildColumnName(this string name)
		{
			string[] array = name.Split('.');
			if (array.Length < 2)
			{
				return string.Empty;
			}
			string text = array[array.Length - 1].Trim();
			if (text.Length <= 0)
			{
				return string.Empty;
			}
			return text;
		}

		public static string[] ToChildTableNames(this string fieldName)
		{
			List<string> list = new List<string>();
			string[] array = fieldName.Split('.');
			if (array.Length < 2)
			{
				return new string[0];
			}
			int num = 0;
			while (true)
			{
				if (num < array.Length - 1)
				{
					string text = array[num].Trim();
					if (text.Length == 0)
					{
						break;
					}
					list.Add(text);
					num++;
					continue;
				}
				return list.ToArray();
			}
			return new string[0];
		}
	}
}
