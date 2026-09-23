using TXTextControl;

namespace DocumentServer.Fields
{
	internal static class ApplicationFieldExtensions
	{
		public static string GetFieldName(this ApplicationField appField)
		{
			if (appField.TypeName == null)
			{
				return "";
			}
			if (appField.TypeName == "MERGEFIELD")
			{
				if (appField.Parameters == null)
				{
					return string.Empty;
				}
				if (appField.Parameters.Length == 0)
				{
					return string.Empty;
				}
				return appField.Parameters[0];
			}
			return string.Empty;
		}
	}
}
