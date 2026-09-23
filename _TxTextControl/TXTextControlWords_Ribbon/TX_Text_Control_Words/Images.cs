using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace TX_Text_Control_Words
{
	public static class Images
	{
		public static Bitmap GetSmallIcon(string imageName)
		{
			return Images.GetIcon("Small." + imageName, SystemInformation.SmallIconSize);
		}

		public static Bitmap GetLargeIcon(string imageName)
		{
			return Images.GetIcon("Large." + imageName, SystemInformation.IconSize);
		}

		private static Bitmap GetIcon(string imageName, Size defaultIconSize)
		{
			Bitmap bitmap = null;
			int width = defaultIconSize.Width;
			foreach (int item in new int[4] { 16, 24, 32, 64 }.OrderByDescending((int x) => x))
			{
				string path = $"TX_Text_Control_Words.Images._{item}.{imageName}.png";
				if (Images.HasEmbeddedImage(path))
				{
					if (width <= item)
					{
						bitmap = Images.GetEmbeddedImage(path);
					}
					else if (bitmap == null)
					{
						return Images.GetEmbeddedImage(path);
					}
				}
			}
			return bitmap;
		}

		private static Bitmap GetEmbeddedImage(string path)
		{
			Assembly executingAssembly = Assembly.GetExecutingAssembly();
			Bitmap result = null;
			if (executingAssembly.GetManifestResourceNames().Contains(path))
			{
				result = new Bitmap(executingAssembly.GetManifestResourceStream(path));
			}
			return result;
		}

		private static bool HasEmbeddedImage(string path)
		{
			return Assembly.GetExecutingAssembly().GetManifestResourceNames().Contains(path);
		}
	}
}
