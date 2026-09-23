using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace tx_help_center_2014
{
	internal static class Program
	{
		internal class NativeMethods
		{
			[DllImport("user32.dll", SetLastError = true)]
			internal static extern bool SetProcessDPIAware();
		}

		[STAThread]
		private static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(defaultValue: false);
			Application.Run(new frmMain());
		}
	}
}
