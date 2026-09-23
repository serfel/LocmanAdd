using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace tx_help_center_2014
{
	internal class Effects
	{
		public enum Effect
		{
			Roll,
			Slide,
			Center,
			Blend
		}

		private static int[] dirmap = new int[8] { 1, 5, 4, 6, 2, 10, 8, 9 };

		private static int[] effmap = new int[4] { 0, 262144, 16, 524288 };

		public static void Animate(Control ctl, Effect effect, int msec, int angle)
		{
			ctl.Visible = !ctl.Visible;
		}

		[DllImport("user32.dll")]
		public static extern bool AnimateWindow(IntPtr handle, int msec, int flags);
	}
}
