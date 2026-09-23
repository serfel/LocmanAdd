using System.Text.RegularExpressions;

namespace DocumentServer.DataSources
{
	internal static class Extensions
	{
		public static bool ContainsSpecialCharacters(this string memberName)
		{
			return Regex.IsMatch(memberName, "[^0-9a-zA-Z_]+");
		}
	}
}
