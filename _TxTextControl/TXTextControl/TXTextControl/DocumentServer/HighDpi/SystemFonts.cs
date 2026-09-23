using System.Drawing;
using System.Runtime.InteropServices;
using ns3;

namespace DocumentServer.HighDpi
{
	internal static class SystemFonts
	{
		public static Font GetCaptionFont(uint uDpi)
		{
			if (uDpi != 0)
			{
				try
				{
					Struct28 struct28_ = default(Struct28);
					Marshal.SizeOf(typeof(Struct26));
					struct28_.int_0 = Marshal.SizeOf((object)struct28_);
					if (Class96.SystemParametersInfoForDpi(41, struct28_.int_0, ref struct28_, 0, uDpi))
					{
						return Font.FromLogFont(struct28_.struct26_0);
					}
				}
				catch
				{
				}
			}
			return System.Drawing.SystemFonts.CaptionFont;
		}

		public static Font GetMenuFont(uint uDpi)
		{
			if (uDpi != 0)
			{
				try
				{
					Struct28 struct28_ = default(Struct28);
					struct28_.int_0 = Marshal.SizeOf((object)struct28_);
					if (Class96.SystemParametersInfoForDpi(41, struct28_.int_0, ref struct28_, 0, uDpi))
					{
						return Font.FromLogFont(struct28_.struct26_2);
					}
				}
				catch
				{
				}
			}
			return System.Drawing.SystemFonts.MenuFont;
		}

		public static Font GetMessageBoxFont(uint uDpi)
		{
			if (uDpi != 0)
			{
				try
				{
					Struct28 struct28_ = default(Struct28);
					struct28_.int_0 = Marshal.SizeOf((object)struct28_);
					if (Class96.SystemParametersInfoForDpi(41, struct28_.int_0, ref struct28_, 0, uDpi))
					{
						return Font.FromLogFont(struct28_.struct26_4);
					}
				}
				catch
				{
				}
			}
			return System.Drawing.SystemFonts.MessageBoxFont;
		}

		public static Font GetSmallCaptionFont(uint uDpi)
		{
			if (uDpi != 0)
			{
				try
				{
					Struct28 struct28_ = default(Struct28);
					Marshal.SizeOf(typeof(Struct26));
					struct28_.int_0 = Marshal.SizeOf((object)struct28_);
					if (Class96.SystemParametersInfoForDpi(41, struct28_.int_0, ref struct28_, 0, uDpi))
					{
						return Font.FromLogFont(struct28_.struct26_1);
					}
				}
				catch
				{
				}
			}
			return System.Drawing.SystemFonts.SmallCaptionFont;
		}

		public static Font GetStatusFont(uint uDpi)
		{
			if (uDpi != 0)
			{
				try
				{
					Struct28 struct28_ = default(Struct28);
					Marshal.SizeOf(typeof(Struct26));
					struct28_.int_0 = Marshal.SizeOf((object)struct28_);
					if (Class96.SystemParametersInfoForDpi(41, struct28_.int_0, ref struct28_, 0, uDpi))
					{
						return Font.FromLogFont(struct28_.struct26_3);
					}
				}
				catch
				{
				}
			}
			return System.Drawing.SystemFonts.StatusFont;
		}
	}
}
