using System;
using TXTextControl;

namespace TX_Text_Control_Words.Utils
{
	internal static class TwipsConverter
	{
		internal static int DotNet2Twips(double val, MeasuringUnit unit)
		{
			return unit switch
			{
				MeasuringUnit.CentiInch => TwipsConverter.MilliInch2Twips(val), 
				MeasuringUnit.Millimeter => TwipsConverter.Millimeters2Twips(val), 
				MeasuringUnit.Centimeter => TwipsConverter.Centimeters2Twips(val), 
				MeasuringUnit.Point => (int)Math.Round(val * 20.0), 
				MeasuringUnit.StandardWPF => TwipsConverter.WPF2Twips(val), 
				MeasuringUnit.Twips => (int)Math.Round(val), 
				_ => 0, 
			};
		}

		internal static int MilliInch2Twips(double val)
		{
			return (int)Math.Round(val * 14.4);
		}

		internal static int Millimeters2Twips(double val)
		{
			return (int)Math.Round(val * 1440.0 / 25.4);
		}

		internal static int Centimeters2Twips(double val)
		{
			return (int)Math.Round(val * 1440.0 / 2.54);
		}

		internal static int WPF2Twips(double val)
		{
			return (int)Math.Round(val * 15.0);
		}

		internal static double Twips2DotNet(int val, MeasuringUnit unit)
		{
			return TwipsConverter.Twips2DotNet(val, unit, 2);
		}

		internal static double Twips2DotNet(int val, MeasuringUnit unit, int iDecimals)
		{
			return unit switch
			{
				MeasuringUnit.CentiInch => Math.Round((double)val * 10.0 / 144.0, iDecimals), 
				MeasuringUnit.Millimeter => Math.Round((double)val * 25.4 / 1440.0, iDecimals), 
				MeasuringUnit.Centimeter => Math.Round((double)val * 2.54 / 1440.0, iDecimals), 
				MeasuringUnit.Point => Math.Round((double)val / 20.0, iDecimals), 
				MeasuringUnit.StandardWPF => Math.Round((double)val / 15.0, iDecimals), 
				MeasuringUnit.Twips => val, 
				_ => 0.0, 
			};
		}

		internal static int WPF2Pt(double val)
		{
			return (int)Math.Round(val * 3.0 / 4.0);
		}
	}
}
