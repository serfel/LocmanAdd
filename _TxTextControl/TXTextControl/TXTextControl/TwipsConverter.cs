using System;

namespace TXTextControl
{
	internal static class TwipsConverter
	{
		internal static int DotNet2Tw(double val, MeasuringUnit unit)
		{
			return unit switch
			{
				MeasuringUnit.CentiInch => TwipsConverter.In2Tw(val), 
				MeasuringUnit.StandardWPF => TwipsConverter.WPF2Tw(val), 
				MeasuringUnit.Twips => (int)Math.Round(val), 
				MeasuringUnit.Millimeter => TwipsConverter.mm2Tw(val), 
				MeasuringUnit.Centimeter => TwipsConverter.cm2Tw(val), 
				MeasuringUnit.Point => (int)Math.Round(val * 20.0), 
				_ => 0, 
			};
		}

		internal static int In2Tw(double val)
		{
			return (int)Math.Round(val * 14.4);
		}

		internal static int mm2Tw(double val)
		{
			return (int)Math.Round(val * 1440.0 / 25.4);
		}

		internal static int cm2Tw(double val)
		{
			return (int)Math.Round(val * 1440.0 / 2.54);
		}

		internal static int WPF2Tw(double val)
		{
			return (int)Math.Round(val * 15.0);
		}

		internal static double Tw2DotNet(int val, MeasuringUnit unit)
		{
			return TwipsConverter.Tw2DotNet(val, unit, 2);
		}

		internal static double Tw2DotNet(int val, MeasuringUnit unit, int iDecimals)
		{
			return unit switch
			{
				MeasuringUnit.CentiInch => Math.Round((double)val * 10.0 / 144.0, iDecimals), 
				MeasuringUnit.StandardWPF => Math.Round((double)val / 15.0, iDecimals), 
				MeasuringUnit.Twips => val, 
				MeasuringUnit.Millimeter => Math.Round((double)val * 25.4 / 1440.0, iDecimals), 
				MeasuringUnit.Centimeter => Math.Round((double)val * 2.54 / 1440.0, iDecimals), 
				MeasuringUnit.Point => Math.Round((double)val / 20.0, iDecimals), 
				_ => 0.0, 
			};
		}

		internal static int WPF2Pt(double val)
		{
			return (int)Math.Round(val * 3.0 / 4.0);
		}
	}
}
