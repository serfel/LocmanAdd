using System.Collections.Generic;
using System.Text.RegularExpressions;
using TXTextControl;

namespace ns19
{
	internal class Class380 : Def
	{
		private string string_0 = "";

		private List<string> list_0 = new List<string>();

		public string Identifier => this.string_0;

		internal List<string> List_0 => this.list_0;

		internal Class380(string string_1, List<string> list_1)
		{
			this.string_0 = string_1;
			this.list_0.AddRange(list_1);
		}

		internal static List<string> smethod_0(string string_1, out string[] string_2)
		{
			string_2 = null;
			string[] array = string_1.Split('{');
			int num = 0;
			if (array.Length > 1)
			{
				num = 1;
				string_2 = Class378.smethod_40(array[0]).Split(',');
			}
			List<string> list = new List<string>();
			foreach (Match item in Class378.smethod_38(array[num]))
			{
				list.Add(item.Value);
			}
			return list;
		}
	}
}
