using System.Drawing;
using System.Windows.Forms;
using ns21;

namespace ns27
{
	internal class Class466
	{
		private const int int_0 = 2;

		private const int int_1 = 30;

		private const int int_2 = 31;

		private const int int_3 = 32;

		private const int int_4 = 33;

		private const int int_5 = 49;

		private const int int_6 = 50;

		private const int int_7 = 71;

		private const int int_8 = 72;

		public static Size smethod_0(uint uint_0)
		{
			if (uint_0 != 0)
			{
				try
				{
					return new Size(Class429.GetSystemMetricsForDpi(71, uint_0), Class429.GetSystemMetricsForDpi(72, uint_0));
				}
				catch
				{
				}
			}
			return SystemInformation.MenuCheckSize;
		}

		public static Size smethod_1(uint uint_0)
		{
			if (uint_0 != 0)
			{
				try
				{
					return new Size(Class429.GetSystemMetricsForDpi(30, uint_0), Class429.GetSystemMetricsForDpi(31, uint_0));
				}
				catch
				{
				}
			}
			return SystemInformation.CaptionButtonSize;
		}

		public static Size smethod_2(uint uint_0)
		{
			if (uint_0 != 0)
			{
				try
				{
					return new Size(Class429.GetSystemMetricsForDpi(32, uint_0), Class429.GetSystemMetricsForDpi(33, uint_0));
				}
				catch
				{
				}
			}
			return SystemInformation.FrameBorderSize;
		}

		public static Size smethod_3(uint uint_0)
		{
			if (uint_0 != 0)
			{
				try
				{
					return new Size(Class429.GetSystemMetricsForDpi(49, uint_0), Class429.GetSystemMetricsForDpi(50, uint_0));
				}
				catch
				{

				}
			}
			return SystemInformation.SmallIconSize;
		}

		public static int smethod_4(uint uint_0)
		{
			if (uint_0 != 0)
			{
				try
				{
					return Class429.GetSystemMetricsForDpi(2, uint_0);
				}
				catch
				{
				}
			}
			return SystemInformation.VerticalScrollBarWidth;
		}
	}
}
