using System.Drawing;
using ns17;

namespace TXTextControl.Drawing
{
	internal static class Converter
	{
		internal static Color InternalToColor(Class176 internalColor)
		{
			if (internalColor.String_0 != null)
			{
				return Color.FromName(internalColor.String_0);
			}
			return Color.FromArgb(internalColor.Byte_0, internalColor.Byte_3, internalColor.Byte_2, internalColor.Byte_1);
		}

		internal static Class176 ColorToInternal(Color color)
		{
			if (color.IsNamedColor)
			{
				return Class176.smethod_2(color.Name, color.A, color.R, color.G, color.B);
			}
			return Class176.smethod_1(color.A, color.R, color.G, color.B);
		}
	}
}
