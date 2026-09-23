using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace TX_Text_Control_Words
{
	internal static class Images
	{
		public static Bitmap GetIcon(string imageName)
		{
			Bitmap bitmap = null;
			int width = SystemInformation.SmallIconSize.Width;
			int[] source = new int[4] { 16, 24, 32, 64 };
			foreach (int item in source.OrderBy((int x) => x))
			{
				string text = $"TX_Text_Control_Words.Images._{item}.{imageName}.png";
				if (Images.HasEmbeddedImage(text))
				{
					if (item <= width)
					{
						bitmap = Images.GetEmbeddedImage(text);
					}
					else if (bitmap == null)
					{
						return Images.GetEmbeddedImage(text);
					}
				}
			}
			return bitmap;
		}

		private static Bitmap GetEmbeddedImage(string resName)
		{
			Assembly executingAssembly = Assembly.GetExecutingAssembly();
			Bitmap result = null;
			if (executingAssembly.GetManifestResourceNames().Contains(resName))
			{
				Stream manifestResourceStream = executingAssembly.GetManifestResourceStream(resName);
				result = new Bitmap(manifestResourceStream);
			}
			return result;
		}

		private static bool HasEmbeddedImage(string path)
		{
			return Assembly.GetExecutingAssembly().GetManifestResourceNames().Contains(path);
		}
	}
}
