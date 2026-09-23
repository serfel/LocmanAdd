using System;
using System.Collections.Generic;
using System.Text;

namespace ns16
{
	internal class Class145 : Class144
	{
		private static List<string> list_0;

		public override bool IsComplete
		{
			get
			{
				if ((base.DbConnectionStringBuilder_0["DSN"] is string && (base.DbConnectionStringBuilder_0["DSN"] as string).Length != 0) || (base.DbConnectionStringBuilder_0["DRIVER"] is string && (base.DbConnectionStringBuilder_0["DRIVER"] as string).Length != 0))
				{
					return true;
				}
				return false;
			}
		}

		public static List<string> List_0
		{
			get
			{
				if (Class145.list_0 == null)
				{
					Class145.list_0 = new List<string>();
					foreach (string item in Class145.smethod_1())
					{
						if (!item.Contains("Native") || !item.Contains("Client"))
						{
							continue;
						}
						StringBuilder stringBuilder = new StringBuilder(1024);
						if (Class159.SQLGetPrivateProfileString(item, "Driver", "", stringBuilder, stringBuilder.Capacity, "ODBCINST.INI") > 0 && stringBuilder.Length > 0)
						{
							string text = stringBuilder.ToString();
							int num = text.LastIndexOf('\\');
							if (num > 0)
							{
								Class145.list_0.Add(text.Substring(num + 1).ToUpperInvariant());
							}
						}
					}
					Class145.list_0.Sort();
				}
				return Class145.list_0;
			}
		}

		public Class145()
			: base("System.Data.Odbc")
		{
		}

		private static List<string> smethod_1()
		{
			char[] array = new char[1024];
			int int_ = 0;
			bool flag = true;
			List<string> list = new List<string>();
			try
			{
				for (flag = Class159.SQLGetInstalledDrivers(array, array.Length, ref int_); flag && int_ > 0 && int_ == array.Length - 1 && !((double)array.Length >= Math.Pow(2.0, 30.0)); flag = Class159.SQLGetInstalledDrivers(array, array.Length, ref int_))
				{
					array = new char[array.Length * 2];
				}
			}
			catch (Exception)
			{
				flag = false;
			}
			if (flag)
			{
				int num = 0;
				int num2 = Array.IndexOf(array, '\0', 0, int_ - 1);
				while (num < int_ - 1)
				{
					list.Add(new string(array, num, num2 - num));
					num = num2 + 1;
					num2 = Array.IndexOf(array, '\0', num, int_ - 1 - num2);
				}
			}
			return list;
		}
	}
}
