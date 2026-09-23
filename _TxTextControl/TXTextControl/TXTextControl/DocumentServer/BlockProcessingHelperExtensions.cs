namespace TXTextControl.DocumentServer
{
	internal static class BlockProcessingHelperExtensions
	{
		public static void RemoveSubTextPartAtPos(this ServerTextControl serverTextControl_0, int pos, bool bKeepText = false)
		{
			foreach (SubTextPart subTextPart in serverTextControl_0.SubTextParts)
			{
				if (subTextPart.Start == pos)
				{
					serverTextControl_0.SubTextParts.Remove(subTextPart, bKeepText, keepNested: false);
					break;
				}
			}
		}
	}
}
