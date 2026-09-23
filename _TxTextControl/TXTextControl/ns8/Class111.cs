using System;
using System.Drawing;
using System.Reflection;
using System.Runtime.CompilerServices;
using DocumentServer.ProxyClasses.Charts;

namespace ns8
{
	internal class Class111
	{
		public enum Enum22
		{
			const_0,
			const_1,
			DataRowMergedEventArgs,
			BlockMergingEventArgs
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
				return (double)Class111.propertyInfo_1.GetValue(this.Object_0, null);
			}
			set
			{
				Class111.propertyInfo_1.SetValue(this.Object_0, value, null);
			}
		}

		public Class119 Class119_0
		{
			get
			{
				return new Class119(Class111.propertyInfo_2.GetValue(this.Object_0, null));
			}
			set
			{
				Class111.propertyInfo_2.SetValue(this.Object_0, value, null);
			}
		}

		public Color Color_0
		{
			get
			{
				return (Color)Class111.propertyInfo_15.GetValue(this.Object_0, null);
			}
			set
			{
				Class111.propertyInfo_15.SetValue(this.Object_0, value, null);
			}
		}

		public ChartDashStyle ChartDashStyle_0
		{
			get
			{
				return Class123.smethod_5(Class111.propertyInfo_0.GetValue(this.Object_0, null));
			}
			set
			{
				Class111.propertyInfo_0.SetValue(this.Object_0, Class123.smethod_6(value), null);
			}
		}

		public Class127 Class127_0 => new Class127(Class111.propertyInfo_16.GetValue(this.Object_0, null));

		public double Double_1
		{
			get
			{
				return (double)Class111.propertyInfo_4.GetValue(this.Object_0, null);
			}
			set
			{
				Class111.propertyInfo_4.SetValue(this.Object_0, value, null);
			}
		}

		public double Double_2
		{
			get
			{
				return (double)Class111.propertyInfo_3.GetValue(this.Object_0, null);
			}
			set
			{
				Class111.propertyInfo_3.SetValue(this.Object_0, value, null);
			}
		}

		public Class127 Class127_1 => new Class127(Class111.propertyInfo_17.GetValue(this.Object_0, null));

		public TextOrientation TextOrientation_0
		{
			get
			{
				return Class123.smethod_3(Class111.propertyInfo_5.GetValue(this.Object_0, null));
			}
			set
			{
				Class111.propertyInfo_5.SetValue(this.Object_0, Class123.smethod_4(value), null);
			}
		}

		public string String_0
		{
			get
			{
				return (string)Class111.propertyInfo_7.GetValue(this.Object_0, null);
			}
			set
			{
				Class111.propertyInfo_7.SetValue(this.Object_0, value, null);
			}
		}

		public StringAlignment StringAlignment_0
		{
			get
			{
				return (StringAlignment)Class111.propertyInfo_6.GetValue(this.Object_0, null);
			}
			set
			{
				Class111.propertyInfo_6.SetValue(this.Object_0, value, null);
			}
		}

		public Font Font_0
		{
			get
			{
				return (Font)Class111.propertyInfo_8.GetValue(this.Object_0, null);
			}
			set
			{
				Class111.propertyInfo_8.SetValue(this.Object_0, value, null);
			}
		}

		public Color Color_1
		{
			get
			{
				return (Color)Class111.propertyInfo_9.GetValue(this.Object_0, null);
			}
			set
			{
				Class111.propertyInfo_9.SetValue(this.Object_0, value, null);
			}
		}

		public Enum22 Enum22_0
		{
			get
			{
				return this.method_0(Class111.propertyInfo_10.GetValue(this.Object_0, null));
			}
			set
			{
				Class111.propertyInfo_10.SetValue(this.Object_0, this.method_1(value), null);
			}
		}

		public Class110 Class110_0 => new Class110(Class111.propertyInfo_11.GetValue(this.Object_0, null));

		public Class110 Class110_1 => new Class110(Class111.propertyInfo_12.GetValue(this.Object_0, null));

		public bool Boolean_0
		{
			get
			{
				return (bool)Class111.propertyInfo_13.GetValue(this.Object_0, null);
			}
			set
			{
				Class111.propertyInfo_13.SetValue(this.Object_0, value, null);
			}
		}

		public bool Boolean_1
		{
			get
			{
				return (bool)Class111.propertyInfo_14.GetValue(this.Object_0, null);
			}
			set
			{
				Class111.propertyInfo_14.SetValue(this.Object_0, value, null);
			}
		}

		static Class111()
		{
			if (!(Class123.Assembly_0 == null))
			{
				Class111.type_0 = Class123.Assembly_0.GetType("System.Windows.Forms.DataVisualization.Charting.Axis");
				Class111.propertyInfo_0 = Class111.type_0.GetProperty("LineDashStyle");
				Class111.propertyInfo_15 = Class111.type_0.GetProperty("LineColor");
				Class111.propertyInfo_7 = Class111.type_0.GetProperty("Title");
				Class111.propertyInfo_2 = Class111.type_0.GetProperty("LabelStyle");
				Class111.propertyInfo_8 = Class111.type_0.GetProperty("TitleFont");
				Class111.propertyInfo_9 = Class111.type_0.GetProperty("TitleForeColor");
				Class111.propertyInfo_6 = Class111.type_0.GetProperty("TitleAlignment");
				Class111.propertyInfo_10 = Class111.type_0.GetProperty("Enabled");
				Class111.propertyInfo_11 = Class111.type_0.GetProperty("MajorGrid");
				Class111.propertyInfo_12 = Class111.type_0.GetProperty("MinorGrid");
				Class111.propertyInfo_1 = Class111.type_0.GetProperty("Interval");
				Class111.propertyInfo_3 = Class111.type_0.GetProperty("Minimum");
				Class111.propertyInfo_4 = Class111.type_0.GetProperty("Maximum");
				Class111.propertyInfo_13 = Class111.type_0.GetProperty("AutoMaximum", BindingFlags.Instance | BindingFlags.NonPublic);
				Class111.propertyInfo_14 = Class111.type_0.GetProperty("AutoMinimum", BindingFlags.Instance | BindingFlags.NonPublic);
				Class111.propertyInfo_5 = Class111.type_0.GetProperty("TextOrientation");
				Class111.propertyInfo_16 = Class111.type_0.GetProperty("MajorTickMark");
				Class111.propertyInfo_17 = Class111.type_0.GetProperty("MinorTickMark");
			}
		}

		public Class111(object object_1)
		{
			this.Object_0 = object_1;
		}

		public Class111()
		{
			this.Object_0 = null;
			if (!(Class123.Assembly_0 == null))
			{
				this.Object_0 = Activator.CreateInstance(Class111.type_0, null);
			}
		}

		private Enum22 method_0(object object_1)
		{
			string text = (string)object_1.GetType().GetMethod("ToString", Type.EmptyTypes).Invoke(object_1, null);
			foreach (Enum22 value in Enum.GetValues(typeof(Enum22)))
			{
				if (value.ToString() == text)
				{
					return value;
				}
			}
			return Enum22.BlockMergingEventArgs;
		}

		private object method_1(Enum22 enum22_0)
		{
			return Class123.Assembly_0.GetType("System.Windows.Forms.DataVisualization.Charting.AxisEnabled").GetField(enum22_0.ToString()).GetRawConstantValue();
		}
	}
}
