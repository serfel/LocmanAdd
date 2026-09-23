using System.Drawing;
using System.Windows.Forms;
using ns3;

namespace DocumentServer.HighDpi
{
	internal static class SystemInformation
	{
		private static class Class167
		{
			public const int CXVSCROLL = 2;

			public const int CXSIZE = 30;

			public const int CYSIZE = 31;

			public const int CXFRAME = 32;

			public const int CYFRAME = 33;

			public const int CXSMICON = 49;

			public const int CYSMICON = 50;

			public const int CXMENUCHECK = 71;

			public const int CYMENUCHECK = 72;
		}

		public static Size GetMenuCheckSize(uint uDpi)
		{
			if (uDpi != 0)
			{
				try
				{
					return new Size(Class96.GetSystemMetricsForDpi(71, uDpi), Class96.GetSystemMetricsForDpi(72, uDpi));
				}
				catch
				{
				}
			}
			return System.Windows.Forms.SystemInformation.MenuCheckSize;
		}

		public static Size GetCaptionButtonSize(uint uDpi)
		{
			if (uDpi != 0)
			{
				try
				{
					return new Size(Class96.GetSystemMetricsForDpi(30, uDpi), Class96.GetSystemMetricsForDpi(31, uDpi));
				}
				catch
				{
				}
			}
			return System.Windows.Forms.SystemInformation.CaptionButtonSize;
		}

		public static Size GetFrameBorderSize(uint uDpi)
		{
			if (uDpi != 0)
			{
				try
				{
					return new Size(Class96.GetSystemMetricsForDpi(32, uDpi), Class96.GetSystemMetricsForDpi(33, uDpi));
				}
				catch
				{
				}
			}
			return System.Windows.Forms.SystemInformation.FrameBorderSize;
		}

		public static Size GetSmallIconSize(uint uDpi)
		{
			if (uDpi != 0)
			{
				try
				{
					return new Size(Class96.GetSystemMetricsForDpi(49, uDpi), Class96.GetSystemMetricsForDpi(50, uDpi));
				}
				catch
				{
				}
			}
			return System.Windows.Forms.SystemInformation.SmallIconSize;
		}

		public static int GetVerticalScrollBarWidth(uint uDpi)
		{
			if (uDpi != 0)
			{
				try
				{
					return Class96.GetSystemMetricsForDpi(2, uDpi);
				}
				catch
				{
				}
			}
			return System.Windows.Forms.SystemInformation.VerticalScrollBarWidth;
		}
	}
}
