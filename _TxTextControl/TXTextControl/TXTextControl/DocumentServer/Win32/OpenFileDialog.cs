using System.Runtime.InteropServices;
using ns3;

namespace DocumentServer.Win32
{
	internal static class OpenFileDialog
	{
		public static string SelectFile(string filter, string initialDir, string title)
		{
			Class94 @class = new Class94();
			@class.int_0 = Marshal.SizeOf((object)@class);
			filter = filter ?? "";
			@class.string_0 = OpenFileDialog.PrepareFilterString(filter);
			@class.string_2 = new string(new char[256]);
			@class.int_3 = @class.string_2.Length;
			@class.string_3 = new string(new char[64]);
			@class.int_4 = @class.string_3.Length;
			@class.string_4 = initialDir;
			@class.string_5 = title;
			if (Class96.GetOpenFileName(@class))
			{
				return @class.string_2;
			}
			return null;
		}

		private static string PrepareFilterString(string filter)
		{
			filter = filter.Replace('|', '\0');
			if (!filter.EndsWith("\0\0"))
			{
				filter += "\0\0";
			}
			return filter;
		}
	}
}
