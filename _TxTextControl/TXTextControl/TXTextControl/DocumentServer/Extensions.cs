using System.Drawing;

namespace TXTextControl.DocumentServer
{
	internal static class Extensions
	{
		public static Bitmap ToImage(this string fileName)
		{
			return new Bitmap(typeof(MailMerge), "Images." + fileName);
		}

		public static Bitmap ToSmallImage(this string fileName)
		{
			return ("Small." + fileName).ToImage();
		}
	}
}
