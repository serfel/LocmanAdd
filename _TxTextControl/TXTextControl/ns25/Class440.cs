using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Reflection;
using System.Runtime.CompilerServices;
using TXTextControl.DataVisualization;
using TXTextControl.ProxyClasses.Charts;

namespace ns25
{
	internal class Class440
	{
		private bool? nullable_0 = null;

		private ChartFrame chartFrame_0;

		private static Type type_0;

		private static PropertyInfo propertyInfo_0;

		private static PropertyInfo propertyInfo_1;

		private static PropertyInfo propertyInfo_2;

		private static PropertyInfo propertyInfo_3;

		private static PropertyInfo propertyInfo_4;

		private static PropertyInfo propertyInfo_5;

		private static PropertyInfo propertyInfo_6;

		[CompilerGenerated]
		private object object_0;

		[CompilerGenerated]
		private static Assembly assembly_0;

		internal ChartFrame ChartFrame_0
		{
			get
			{
				return this.chartFrame_0;
			}
			set
			{
				this.chartFrame_0 = value;
				this.Object_0 = this.chartFrame_0.Chart;
			}
		}

		internal object Object_0
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

		internal static Assembly Assembly_0
		{
			[CompilerGenerated]
			get
			{
				return Class440.assembly_0;
			}
			[CompilerGenerated]
			private set
			{
				Class440.assembly_0 = value;
			}
		}

		internal bool? Nullable_0
		{
			get
			{
				if (this.Class435_0.Count != 0)
				{
					bool? flag = null;
					foreach (Class437 item in (IEnumerable<Class437>)this.Class435_0)
					{
						if (!flag.HasValue)
						{
							flag = item.Class434_0.Boolean_0;
						}
						else if (flag != item.Class434_0.Boolean_0)
						{
							flag = null;
							break;
						}
					}
					this.nullable_0 = flag;
				}
				return this.nullable_0;
			}
			private set
			{
				this.nullable_0 = value;
				if (!this.nullable_0.HasValue)
				{
					return;
				}
				foreach (Class437 item in (IEnumerable<Class437>)this.Class435_0)
				{
					item.Class434_0.Boolean_0 = this.nullable_0 ?? false;
				}
			}
		}

		internal Size Size_0
		{
			get
			{
				return (Size)Class440.propertyInfo_1.GetValue(this.Object_0, null);
			}
			set
			{
				Class440.propertyInfo_1.SetValue(this.Object_0, value, null);
			}
		}

		internal Class452 Class452_0 => new Class452(Class440.propertyInfo_2.GetValue(this.Object_0, null));

		internal Class435 Class435_0 => new Class435(Class440.propertyInfo_3.GetValue(this.Object_0, null));

		internal Class449 Class449_0 => new Class449(Class440.propertyInfo_4.GetValue(this.Object_0, null));

		internal Class441 Class441_0 => new Class441(Class440.propertyInfo_5.GetValue(this.Object_0, null));

		internal TextAntiAliasingQuality TextAntiAliasingQuality_0
		{
			get
			{
				return this.method_0(Class440.propertyInfo_6.GetValue(this.Object_0, null));
			}
			set
			{
				Class440.propertyInfo_6.SetValue(this.Object_0, this.method_1(value), null);
			}
		}

		static Class440()
		{
			Class440.Assembly_0 = null;
			Class440.smethod_0();
			if (!(Class440.Assembly_0 == null))
			{
				Class440.type_0 = Class440.Assembly_0.GetType("System.Windows.Forms.DataVisualization.Charting.Chart");
				Class440.propertyInfo_0 = Class440.type_0.GetProperty("Font");
				Class440.propertyInfo_1 = Class440.type_0.GetProperty("Size");
				Class440.propertyInfo_2 = Class440.type_0.GetProperty("Series");
				Class440.propertyInfo_3 = Class440.type_0.GetProperty("ChartAreas");
				Class440.propertyInfo_4 = Class440.type_0.GetProperty("Legends");
				Class440.propertyInfo_5 = Class440.type_0.GetProperty("Titles");
				Class440.propertyInfo_6 = Class440.type_0.GetProperty("TextAntiAliasingQuality");
			}
		}

		public Class440(Size size_0, bool bool_0)
		{
			if (!(Class440.Assembly_0 == null))
			{
				this.Object_0 = Activator.CreateInstance(Class440.type_0);
				Class440.propertyInfo_0.SetValue(this.Object_0, new Font("Segoe UI", 8f), null);
				this.Nullable_0 = bool_0;
				this.Size_0 = size_0;
				this.TextAntiAliasingQuality_0 = TextAntiAliasingQuality.Normal;
			}
		}

		public Class440(ChartFrame chartFrame_1)
		{
			if (!(Class440.Assembly_0 == null))
			{
				this.ChartFrame_0 = chartFrame_1;
				this.Object_0 = chartFrame_1.Chart;
				this.TextAntiAliasingQuality_0 = TextAntiAliasingQuality.Normal;
			}
		}

		public Class440()
			: this(new Size(3000, 3000), bool_0: false)
		{
		}

		private TextAntiAliasingQuality method_0(object object_1)
		{
			MethodInfo method = object_1.GetType().GetMethod("ToString", Type.EmptyTypes);
			string text = (string)method.Invoke(object_1, null);
			foreach (TextAntiAliasingQuality value in Enum.GetValues(typeof(TextAntiAliasingQuality)))
			{
				if (value.ToString() == text)
				{
					return value;
				}
			}
			return TextAntiAliasingQuality.UNKNOWN;
		}

		private object method_1(TextAntiAliasingQuality textAntiAliasingQuality_0)
		{
			Type type = Class440.Assembly_0.GetType("System.Windows.Forms.DataVisualization.Charting.TextAntiAliasingQuality");
			return type.GetField(textAntiAliasingQuality_0.ToString()).GetRawConstantValue();
		}

		private static void smethod_0()
		{
			Class440.Assembly_0 = null;
			AssemblyName assemblyName = new AssemblyName();
			assemblyName.Name = "System.Windows.Forms.DataVisualization";
			assemblyName.CultureInfo = new CultureInfo("");
			assemblyName.Version = ((Environment.Version.Major >= 4) ? new Version(4, 0, 0, 0) : new Version(3, 5, 0, 0));
			assemblyName.ProcessorArchitecture = ProcessorArchitecture.MSIL;
			AssemblyName assemblyName2 = assemblyName;
			assemblyName2.SetPublicKeyToken(new byte[8] { 49, 191, 56, 86, 173, 54, 78, 53 });
			try
			{
				Class440.Assembly_0 = Assembly.Load(assemblyName2);
			}
			catch
			{
			}
		}

		internal static Docking smethod_1(object object_1)
		{
			MethodInfo method = object_1.GetType().GetMethod("ToString", Type.EmptyTypes);
			string text = (string)method.Invoke(object_1, null);
			foreach (Docking value in Enum.GetValues(typeof(Docking)))
			{
				if (value.ToString() == text)
				{
					return value;
				}
			}
			return Docking.Top;
		}

		internal static object smethod_2(Docking docking_0)
		{
			Type type = Class440.Assembly_0.GetType("System.Windows.Forms.DataVisualization.Charting.Docking");
			return type.GetField(docking_0.ToString()).GetRawConstantValue();
		}

		internal static TextOrientation smethod_3(object object_1)
		{
			MethodInfo method = object_1.GetType().GetMethod("ToString", Type.EmptyTypes);
			string text = (string)method.Invoke(object_1, null);
			foreach (TextOrientation value in Enum.GetValues(typeof(TextOrientation)))
			{
				if (value.ToString() == text)
				{
					return value;
				}
			}
			return TextOrientation.Auto;
		}

		internal static object smethod_4(TextOrientation textOrientation_0)
		{
			Type type = Class440.Assembly_0.GetType("System.Windows.Forms.DataVisualization.Charting.TextOrientation");
			return type.GetField(textOrientation_0.ToString()).GetRawConstantValue();
		}

		internal static ChartDashStyle smethod_5(object object_1)
		{
			MethodInfo method = object_1.GetType().GetMethod("ToString", Type.EmptyTypes);
			string text = (string)method.Invoke(object_1, null);
			foreach (ChartDashStyle value in Enum.GetValues(typeof(ChartDashStyle)))
			{
				if (value.ToString() == text)
				{
					return value;
				}
			}
			return ChartDashStyle.Solid;
		}

		internal static object smethod_6(ChartDashStyle chartDashStyle_0)
		{
			Type type = Class440.Assembly_0.GetType("System.Windows.Forms.DataVisualization.Charting.ChartDashStyle");
			return type.GetField(chartDashStyle_0.ToString()).GetRawConstantValue();
		}

		internal static MarkerStyle smethod_7(object object_1)
		{
			MethodInfo method = object_1.GetType().GetMethod("ToString", Type.EmptyTypes);
			string text = (string)method.Invoke(object_1, null);
			foreach (MarkerStyle value in Enum.GetValues(typeof(MarkerStyle)))
			{
				if (value.ToString() == text)
				{
					return value;
				}
			}
			return MarkerStyle.None;
		}

		internal static object smethod_8(MarkerStyle markerStyle_0)
		{
			Type type = Class440.Assembly_0.GetType("System.Windows.Forms.DataVisualization.Charting.MarkerStyle");
			return type.GetField(markerStyle_0.ToString()).GetRawConstantValue();
		}
	}
}
