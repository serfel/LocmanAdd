using System;

namespace TXTextControl
{
	internal static class DpiConverter
	{
		internal static int DPI96toPix(int val, float dpi)
		{
			return (int)Math.Round((float)val * dpi / 96f);
		}

		internal static int PointToPix(float val, float dpi)
		{
			return (int)Math.Round(val * dpi / 72f);
		}
	}
}
