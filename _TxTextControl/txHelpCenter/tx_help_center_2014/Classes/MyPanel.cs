using System.Windows.Forms;

namespace tx_help_center_2014.Classes
{
	public class MyPanel : Panel
	{
		public MyPanel()
		{
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, value: true);
		}
	}
}
