using System.Drawing;
using System.Runtime.InteropServices;
using ns21;

namespace ns27
{
	internal class Class467
	{
		public static Font smethod_0(uint uint_0)
		{
			if (uint_0 != 0)
			{
				try
				{
					Class429.Struct95 struct95_ = default(Class429.Struct95);
					Marshal.SizeOf(typeof(Class429.Struct88));
					struct95_.int_0 = Marshal.SizeOf((object)struct95_);
					if (Class429.SystemParametersInfoForDpi(41, struct95_.int_0, ref struct95_, 0, uint_0))
					{
						return Font.FromLogFont(struct95_.struct88_0);
					}
				}
				catch
				{
				}
			}
			return SystemFonts.CaptionFont;
		}

		public static Font smethod_1(uint uint_0)
		{
			if (uint_0 != 0)
			{
				try
				{
					Class429.Struct95 struct95_ = default(Class429.Struct95);
					struct95_.int_0 = Marshal.SizeOf((object)struct95_);
					if (Class429.SystemParametersInfoForDpi(41, struct95_.int_0, ref struct95_, 0, uint_0))
					{
						return Font.FromLogFont(struct95_.struct88_2);
					}
				}
				catch
				{
				}
			}
			return SystemFonts.MenuFont;
		}

		public static Font smethod_2(uint uint_0)
		{
			if (uint_0 != 0)
			{
				try
				{
					Class429.Struct95 struct95_ = default(Class429.Struct95);
					struct95_.int_0 = Marshal.SizeOf((object)struct95_);
					if (Class429.SystemParametersInfoForDpi(41, struct95_.int_0, ref struct95_, 0, uint_0))
					{
						return Font.FromLogFont(struct95_.struct88_4);
					}
				}
				catch
				{
				}
			}
			return SystemFonts.MessageBoxFont;
		}

		public static Font smethod_3(uint uint_0)
		{
			if (uint_0 != 0)
			{
				try
				{
					Class429.Struct95 struct95_ = default(Class429.Struct95);
					Marshal.SizeOf(typeof(Class429.Struct88));
					struct95_.int_0 = Marshal.SizeOf((object)struct95_);
					if (Class429.SystemParametersInfoForDpi(41, struct95_.int_0, ref struct95_, 0, uint_0))
					{
						return Font.FromLogFont(struct95_.struct88_1);
					}
				}
				catch
				{
				}
			}
			return SystemFonts.SmallCaptionFont;
		}

		public static Font smethod_4(uint uint_0)
		{
			if (uint_0 != 0)
			{
				try
				{
					Class429.Struct95 struct95_ = default(Class429.Struct95);
					Marshal.SizeOf(typeof(Class429.Struct88));
					struct95_.int_0 = Marshal.SizeOf((object)struct95_);
					if (Class429.SystemParametersInfoForDpi(41, struct95_.int_0, ref struct95_, 0, uint_0))
					{
						return Font.FromLogFont(struct95_.struct88_3);
					}
				}
				catch
				{
				}
			}
			return SystemFonts.StatusFont;
		}
	}
}
