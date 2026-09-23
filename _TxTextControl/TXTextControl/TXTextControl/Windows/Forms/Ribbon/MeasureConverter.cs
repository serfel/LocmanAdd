using System;
using System.Globalization;

namespace TXTextControl.Windows.Forms.Ribbon
{
	internal static class MeasureConverter
	{
		private static MeasuringUnit m_iUnit = MeasuringUnit.Point;

		private static int m_iDecimals = 1;

		private static bool m_bShowAllDecimals = false;

		internal static MeasuringUnit Unit
		{
			get
			{
				return MeasureConverter.m_iUnit;
			}
			set
			{
				MeasureConverter.m_iUnit = value;
			}
		}

		internal static int Decimals
		{
			get
			{
				return MeasureConverter.m_iDecimals;
			}
			set
			{
				MeasureConverter.m_iDecimals = value;
			}
		}

		internal static bool ShowAllDecimals
		{
			get
			{
				return MeasureConverter.m_bShowAllDecimals;
			}
			set
			{
				MeasureConverter.m_bShowAllDecimals = value;
			}
		}

		internal static object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (value == null)
			{
				return null;
			}
			if (value.GetType() != typeof(int))
			{
				return null;
			}
			double num = TwipsConverter.Tw2DotNet((int)value, MeasureConverter.m_iUnit, MeasureConverter.m_iDecimals);
			if (targetType == typeof(double))
			{
				return num;
			}
			if (!(targetType == typeof(string)) && !(targetType == typeof(object)))
			{
				return null;
			}
			return MeasureConverter.m_bShowAllDecimals ? num.ToString("F" + MeasureConverter.m_iDecimals) : num.ToString();
		}

		internal static object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (value == null)
			{
				return -1;
			}
			try
			{
				if (value.GetType() == typeof(decimal))
				{
					return TwipsConverter.DotNet2Tw(decimal.ToDouble((decimal)value), MeasureConverter.m_iUnit);
				}
				if (value.GetType() == typeof(double))
				{
					return TwipsConverter.DotNet2Tw((double)value, MeasureConverter.m_iUnit);
				}
				if (value.GetType() == typeof(string))
				{
					return TwipsConverter.DotNet2Tw(double.Parse(value as string), MeasureConverter.m_iUnit);
				}
			}
			catch
			{
			}
			return -1;
		}
	}
}
