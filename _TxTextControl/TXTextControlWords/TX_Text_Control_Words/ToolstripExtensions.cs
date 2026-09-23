using System.Drawing;
using System.Windows.Forms;
using TXTextControl.Windows.Forms;

namespace TX_Text_Control_Words
{
	public static class ToolstripExtensions
	{
		public static void Apply(this ToolStripButton button, string txitem, float dpi)
		{
			Bitmap smallIcon = ResourceProvider.GetSmallIcon(txitem, dpi);
			if (smallIcon != null)
			{
				button.Image = smallIcon;
			}
			else
			{
				button.Image = ResourceProvider.GetSmallIcon("dummy", dpi);
			}
		}
	}
}
