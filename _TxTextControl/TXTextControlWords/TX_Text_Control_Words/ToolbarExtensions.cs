using System.Windows.Forms;
using TXTextControl.Windows.Forms;

namespace TX_Text_Control_Words
{
	public static class ToolbarExtensions
	{
		public static void UpdateImage(this ToolStripMenuItem menuItem, float dpi)
		{
			string text = menuItem.Tag as string;
			if (text != null)
			{
				if (text.StartsWith("TXITEM_"))
				{
					menuItem.ImageScaling = ToolStripItemImageScaling.None;
					menuItem.Image = ResourceProvider.GetSmallIcon(text, dpi);
				}
				else if (text.StartsWith("TXIMAGE_"))
				{
					menuItem.Image = Images.GetIcon(text.Replace("TXIMAGE_", ""));
					menuItem.ImageScaling = ToolStripItemImageScaling.None;
				}
			}
		}
	}
}
