using System;
using System.Drawing;
using System.Reflection;
using System.Runtime.CompilerServices;
using TXTextControl.ProxyClasses.Charts;

namespace ns25
{
	internal class Class439
	{
		public enum AxisEnabled
		{
			Auto,
			True,
			False,
			UNKNOWN
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

		private static PropertyInfo propertyInfo_12;

		private static PropertyInfo propertyInfo_13;

		private static PropertyInfo propertyInfo_14;

		private static PropertyInfo propertyInfo_15;

		private static PropertyInfo propertyInfo_16;

		private static PropertyInfo propertyInfo_17;

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

		public double Double_0
		{
			get
			{
				return (double)Class439.propertyInfo_1.GetValue(this.Object_0, null);
			}
			set
			{
				Class439.propertyInfo_1.SetValue(this.Object_0, value, null);
			}
		}

		public Class448 Class448_0
		{
			get
			{
				return new Class448(Class439.propertyInfo_2.GetValue(this.Object_0, null));
			}
			set
			{
				Class439.propertyInfo_2.SetValue(this.Object_0, value, null);
			}
		}

		public Color Color_0
		{
			get
			{
				return (Color)Class439.propertyInfo_15.GetValue(this.Object_0, null);
			}
			set
			{
				Class439.propertyInfo_15.SetValue(this.Object_0, value, null);
			}
		}

		public ChartDashStyle ChartDashStyle_0
		{
			get
			{
				return Class440.smethod_5(Class439.propertyInfo_0.GetValue(this.Object_0, null));
			}
			set
			{
				Class439.propertyInfo_0.SetValue(this.Object_0, Class440.smethod_6(value), null);
			}
		}

		public Class455 Class455_0 => new Class455(Class439.propertyInfo_16.GetValue(this.Object_0, null));

		public double Double_1
		{
			get
			{
				return (double)Class439.propertyInfo_4.GetValue(this.Object_0, null);
			}
			set
			{
				Class439.propertyInfo_4.SetValue(this.Object_0, value, null);
			}
		}

		public double Double_2
		{
			get
			{
				return (double)Class439.propertyInfo_3.GetValue(this.Object_0, null);
			}
			set
			{
				Class439.propertyInfo_3.SetValue(this.Object_0, value, null);
			}
		}

		public Class455 Class455_1 => new Class455(Class439.propertyInfo_17.GetValue(this.Object_0, null));

		public TextOrientation TextOrientation_0
		{
			get
			{
				return Class440.smethod_3(Class439.propertyInfo_5.GetValue(this.Object_0, null));
			}
			set
			{
				Class439.propertyInfo_5.SetValue(this.Object_0, Class440.smethod_4(value), null);
			}
		}

		public string String_0
		{
			get
			{
				return (string)Class439.propertyInfo_7.GetValue(this.Object_0, null);
			}
			set
			{
				Class439.propertyInfo_7.SetValue(this.Object_0, value, null);
			}
		}

		public StringAlignment StringAlignment_0
		{
			get
			{
				return (StringAlignment)Class439.propertyInfo_6.GetValue(this.Object_0, null);
			}
			set
			{
				Class439.propertyInfo_6.SetValue(this.Object_0, value, null);
			}
		}

		public Font Font_0
		{
			get
			{
				return (Font)Class439.propertyInfo_8.GetValue(this.Object_0, null);
			}
			set
			{
				Class439.propertyInfo_8.SetValue(this.Object_0, value, null);
			}
		}

		public Color Color_1
		{
			get
			{
				return (Color)Class439.propertyInfo_9.GetValue(this.Object_0, null);
			}
			set
			{
				Class439.propertyInfo_9.SetValue(this.Object_0, value, null);
			}
		}

		public AxisEnabled AxisEnabled_0
		{
			get
			{
				return this.method_0(Class439.propertyInfo_10.GetValue(this.Object_0, null));
			}
			set
			{
				Class439.propertyInfo_10.SetValue(this.Object_0, this.method_1(value), null);
			}
		}

		public Class438 Class438_0 => new Class438(Class439.propertyInfo_11.GetValue(this.Object_0, null));

		public Class438 Class438_1 => new Class438(Class439.propertyInfo_12.GetValue(this.Object_0, null));

		public bool Boolean_0
		{
			get
			{
				return (bool)Class439.propertyInfo_13.GetValue(this.Object_0, null);
			}
			set
			{
				Class439.propertyInfo_13.SetValue(this.Object_0, value, null);
			}
		}

		public bool Boolean_1
		{
			get
			{
				return (bool)Class439.propertyInfo_14.GetValue(this.Object_0, null);
			}
			set
			{
				Class439.propertyInfo_14.SetValue(this.Object_0, value, null);
			}
		}

		static Class439()
		{
			if (!(Class440.Assembly_0 == null))
			{
				Class439.type_0 = Class440.Assembly_0.GetType("System.Windows.Forms.DataVisualization.Charting.Axis");
				Class439.propertyInfo_0 = Class439.type_0.GetProperty("LineDashStyle");
				Class439.propertyInfo_15 = Class439.type_0.GetProperty("LineColor");
				Class439.propertyInfo_7 = Class439.type_0.GetProperty("Title");
				Class439.propertyInfo_2 = Class439.type_0.GetProperty("LabelStyle");
				Class439.propertyInfo_8 = Class439.type_0.GetProperty("TitleFont");
				Class439.propertyInfo_9 = Class439.type_0.GetProperty("TitleForeColor");
				Class439.propertyInfo_6 = Class439.type_0.GetProperty("TitleAlignment");
				Class439.propertyInfo_10 = Class439.type_0.GetProperty("Enabled");
				Class439.propertyInfo_11 = Class439.type_0.GetProperty("MajorGrid");
				Class439.propertyInfo_12 = Class439.type_0.GetProperty("MinorGrid");
				Class439.propertyInfo_1 = Class439.type_0.GetProperty("Interval");
				Class439.propertyInfo_3 = Class439.type_0.GetProperty("Minimum");
				Class439.propertyInfo_4 = Class439.type_0.GetProperty("Maximum");
				Class439.propertyInfo_13 = Class439.type_0.GetProperty("AutoMaximum", BindingFlags.Instance | BindingFlags.NonPublic);
				Class439.propertyInfo_14 = Class439.type_0.GetProperty("AutoMinimum", BindingFlags.Instance | BindingFlags.NonPublic);
				Class439.propertyInfo_5 = Class439.type_0.GetProperty("TextOrientation");
				Class439.propertyInfo_16 = Class439.type_0.GetProperty("MajorTickMark");
				Class439.propertyInfo_17 = Class439.type_0.GetProperty("MinorTickMark");
			}
		}

		public Class439(object object_1)
		{
			this.Object_0 = object_1;
		}

		public Class439()
		{
			this.Object_0 = null;
			if (!(Class440.Assembly_0 == null))
			{
				this.Object_0 = Activator.CreateInstance(Class439.type_0, null);
			}
		}

		private AxisEnabled method_0(object object_1)
		{
			MethodInfo method = object_1.GetType().GetMethod("ToString", Type.EmptyTypes);
			string text = (string)method.Invoke(object_1, null);
			foreach (AxisEnabled value in Enum.GetValues(typeof(AxisEnabled)))
			{
				if (value.ToString() == text)
				{
					return value;
				}
			}
			return AxisEnabled.UNKNOWN;
		}

		private object method_1(AxisEnabled axisEnabled_0)
		{
			Type type = Class440.Assembly_0.GetType("System.Windows.Forms.DataVisualization.Charting.AxisEnabled");
			return type.GetField(axisEnabled_0.ToString()).GetRawConstantValue();
		}
	}
}
