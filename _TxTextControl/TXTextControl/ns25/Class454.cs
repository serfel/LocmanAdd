using System;
using System.Drawing;
using System.Reflection;
using System.Runtime.CompilerServices;
using TXTextControl.ProxyClasses.Charts;

namespace ns25
{
	internal class Class454
	{
		public enum SeriesChartType
		{
			UNKNOWN = -1,
			Point,
			FastPoint,
			Bubble,
			Line,
			Spline,
			StepLine,
			FastLine,
			Bar,
			StackedBar,
			StackedBar100,
			Column,
			StackedColumn,
			StackedColumn100,
			Area,
			SplineArea,
			StackedArea,
			StackedArea100,
			Pie,
			Doughnut,
			Stock,
			Candlestick,
			Range,
			SplineRange,
			RangeBar,
			RangeColumn,
			Radar,
			Polar,
			ErrorBar,
			BoxPlot,
			Renko,
			ThreeLineBreak,
			Kagi,
			PointAndFigure,
			Funnel,
			Pyramid
		}

		private static Type type_0;

		private static PropertyInfo propertyInfo_0;

		private static PropertyInfo propertyInfo_1;

		private static PropertyInfo propertyInfo_2;

		private static PropertyInfo propertyInfo_3;

		private static PropertyInfo propertyInfo_4;

		private static PropertyInfo propertyInfo_5;

		private static PropertyInfo propertyInfo_6;

		private static PropertyInfo propertyInfo_7;

		private static PropertyInfo propertyInfo_8;

		private static PropertyInfo propertyInfo_9;

		private static PropertyInfo propertyInfo_10;

		private static PropertyInfo propertyInfo_11;

		[CompilerGenerated]
		private object object_0;

		public object Object_0
		{
			[CompilerGenerated]
			get
			{
				return this.object_0;
			}
			[CompilerGenerated]
			private set
			{
				this.object_0 = value;
			}
		}

		public int Int32_0
		{
			get
			{
				return (int)Class454.propertyInfo_0.GetValue(this.Object_0, null);
			}
			set
			{
				Class454.propertyInfo_0.SetValue(this.Object_0, value, null);
			}
		}

		public Class444 Class444_0 => new Class444(Class454.propertyInfo_1.GetValue(this.Object_0, null));

		public string String_0
		{
			get
			{
				return (string)Class454.propertyInfo_5.GetValue(this.Object_0, null);
			}
			set
			{
				Class454.propertyInfo_5.SetValue(this.Object_0, value, null);
			}
		}

		public string String_1
		{
			get
			{
				return (string)Class454.propertyInfo_6.GetValue(this.Object_0, null);
			}
			set
			{
				Class454.propertyInfo_6.SetValue(this.Object_0, value, null);
			}
		}

		public bool Boolean_0
		{
			get
			{
				return (bool)Class454.propertyInfo_8.GetValue(this.Object_0, null);
			}
			set
			{
				Class454.propertyInfo_8.SetValue(this.Object_0, value, null);
			}
		}

		public Font Font_0
		{
			get
			{
				return (Font)Class454.propertyInfo_9.GetValue(this.Object_0, null);
			}
			set
			{
				Class454.propertyInfo_9.SetValue(this.Object_0, value, null);
			}
		}

		public Color Color_0
		{
			get
			{
				return (Color)Class454.propertyInfo_10.GetValue(this.Object_0, null);
			}
			set
			{
				Class454.propertyInfo_10.SetValue(this.Object_0, value, null);
			}
		}

		public Color Color_1
		{
			get
			{
				return (Color)Class454.propertyInfo_11.GetValue(this.Object_0, null);
			}
			set
			{
				Class454.propertyInfo_11.SetValue(this.Object_0, value, null);
			}
		}

		public SeriesChartType SeriesChartType_0
		{
			get
			{
				return Class454.smethod_1(Class454.propertyInfo_7.GetValue(this.Object_0, null));
			}
			set
			{
				Class454.propertyInfo_7.SetValue(this.Object_0, Class454.smethod_0(value), null);
			}
		}

		public Color Color_2
		{
			get
			{
				return (Color)Class454.propertyInfo_4.GetValue(this.Object_0, null);
			}
			set
			{
				Class454.propertyInfo_4.SetValue(this.Object_0, value, null);
			}
		}

		public MarkerStyle MarkerStyle_0
		{
			get
			{
				return Class440.smethod_7(Class454.propertyInfo_2.GetValue(this.Object_0, null));
			}
			set
			{
				Class454.propertyInfo_2.SetValue(this.Object_0, Class440.smethod_8(value), null);
			}
		}

		public int Int32_1
		{
			get
			{
				return (int)Class454.propertyInfo_3.GetValue(this.Object_0, null);
			}
			set
			{
				Class454.propertyInfo_3.SetValue(this.Object_0, value, null);
			}
		}

		static Class454()
		{
			if (!(Class440.Assembly_0 == null))
			{
				Class454.type_0 = Class440.Assembly_0.GetType("System.Windows.Forms.DataVisualization.Charting.Series");
				Class454.propertyInfo_0 = Class454.type_0.GetProperty("BorderWidth");
				Class454.propertyInfo_1 = Class454.type_0.GetProperty("Points");
				Class454.propertyInfo_4 = Class454.type_0.GetProperty("MarkerColor");
				Class454.propertyInfo_2 = Class454.type_0.GetProperty("MarkerStyle");
				Class454.propertyInfo_3 = Class454.type_0.GetProperty("MarkerSize");
				Class454.propertyInfo_5 = Class454.type_0.GetProperty("Name");
				Class454.propertyInfo_6 = Class454.type_0.GetProperty("ChartArea");
				Class454.propertyInfo_7 = Class454.type_0.GetProperty("ChartType");
				Class454.propertyInfo_8 = Class454.type_0.GetProperty("IsValueShownAsLabel");
				Class454.propertyInfo_9 = Class454.type_0.GetProperty("Font");
				Class454.propertyInfo_10 = Class454.type_0.GetProperty("LabelBackColor");
				Class454.propertyInfo_11 = Class454.type_0.GetProperty("LabelBorderColor");
			}
		}

		public Class454()
		{
			this.Object_0 = null;
			if (!(Class440.Assembly_0 == null))
			{
				this.Object_0 = Activator.CreateInstance(Class454.type_0, null);
			}
		}

		public Class454(object object_1)
		{
			this.Object_0 = object_1;
		}

		public Class454(SeriesChartType seriesChartType_0, int int_0)
		{
			this.Object_0 = Activator.CreateInstance(Class454.type_0);
			this.SeriesChartType_0 = seriesChartType_0;
			for (int i = 0; i < int_0; i++)
			{
				this.Class444_0.Add(new Class446(0.0));
			}
		}

		public Class454(SeriesChartType seriesChartType_0)
			: this(seriesChartType_0, 0)
		{
		}

		public Class454(Class454 class454_0)
			: this(class454_0.SeriesChartType_0)
		{
			for (int i = 0; i < class454_0.Class444_0.Count; i++)
			{
				this.Class444_0.Add(new Class446(0.0, class454_0.Class444_0[i].String_0));
			}
		}

		private static object smethod_0(SeriesChartType seriesChartType_0)
		{
			Type type = Class440.Assembly_0.GetType("System.Windows.Forms.DataVisualization.Charting.SeriesChartType");
			return type.GetField(seriesChartType_0.ToString()).GetRawConstantValue();
		}

		private static SeriesChartType smethod_1(object object_1)
		{
			MethodInfo method = object_1.GetType().GetMethod("ToString", Type.EmptyTypes);
			string text = (string)method.Invoke(object_1, null);
			foreach (SeriesChartType value in Enum.GetValues(typeof(SeriesChartType)))
			{
				if (value.ToString() == text)
				{
					return value;
				}
			}
			return SeriesChartType.UNKNOWN;
		}
	}
}
