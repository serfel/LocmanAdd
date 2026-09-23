using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Reflection;
using System.Runtime.CompilerServices;
using TXTextControl.DataVisualization;
using DocumentServer.ProxyClasses.Charts;

namespace ns8
{
	internal class Class123
	{
		private bool? nullable_0;

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
				return Class123.assembly_0;
			}
			[CompilerGenerated]
			private set
			{
				Class123.assembly_0 = value;
			}
		}

		internal bool? Nullable_0
		{
			get
			{
				if (this.Class107_0.Count != 0)
				{
					bool? flag = null;
					foreach (Class109 item in (IEnumerable<Class109>)this.Class107_0)
					{
						if (!flag.HasValue)
						{
							flag = item.Class106_0.Boolean_0;
						}
						else if (flag != item.Class106_0.Boolean_0)
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
				foreach (Class109 item in (IEnumerable<Class109>)this.Class107_0)
				{
					item.Class106_0.Boolean_0 = this.nullable_0.GetValueOrDefault();
				}
			}
		}

		internal Size Size_0
		{
			get
			{
				return (Size)Class123.propertyInfo_1.GetValue(this.Object_0, null);
			}
			set
			{
				Class123.propertyInfo_1.SetValue(this.Object_0, value, null);
			}
		}

		internal Class124 Class124_0 => new Class124(Class123.propertyInfo_2.GetValue(this.Object_0, null));

		internal Class107 Class107_0 => new Class107(Class123.propertyInfo_3.GetValue(this.Object_0, null));

		internal Class120 Class120_0 => new Class120(Class123.propertyInfo_4.GetValue(this.Object_0, null));

		internal Class112 Class112_0 => new Class112(Class123.propertyInfo_5.GetValue(this.Object_0, null));

		internal DataRowMergedEventArgs DataRowMergedEventArgs_0
		{
			get
			{
				return this.method_0(Class123.propertyInfo_6.GetValue(this.Object_0, null));
			}
			set
			{
				Class123.propertyInfo_6.SetValue(this.Object_0, this.method_1(value), null);
			}
		}

		static Class123()
		{
			Class123.Assembly_0 = null;
			Class123.smethod_0();
			if (!(Class123.Assembly_0 == null))
			{
				Class123.type_0 = Class123.Assembly_0.GetType("System.Windows.Forms.DataVisualization.Charting.Chart");
				Class123.propertyInfo_0 = Class123.type_0.GetProperty("Font");
				Class123.propertyInfo_1 = Class123.type_0.GetProperty("Size");
				Class123.propertyInfo_2 = Class123.type_0.GetProperty("Series");
				Class123.propertyInfo_3 = Class123.type_0.GetProperty("ChartAreas");
				Class123.propertyInfo_4 = Class123.type_0.GetProperty("Legends");
				Class123.propertyInfo_5 = Class123.type_0.GetProperty("Titles");
				Class123.propertyInfo_6 = Class123.type_0.GetProperty("TextAntiAliasingQuality");
			}
		}

		public Class123(Size size_0, bool bool_0)
		{
			if (!(Class123.Assembly_0 == null))
			{
				this.Object_0 = Activator.CreateInstance(Class123.type_0);
				Class123.propertyInfo_0.SetValue(this.Object_0, new Font("Segoe UI", 8f), null);
				this.Nullable_0 = bool_0;
				this.Size_0 = size_0;
				this.DataRowMergedEventArgs_0 = DataRowMergedEventArgs.const_0;
			}
		}

		public Class123(ChartFrame chartFrame_1)
		{
			if (!(Class123.Assembly_0 == null))
			{
				this.ChartFrame_0 = chartFrame_1;
				this.Object_0 = chartFrame_1.Chart;
				this.DataRowMergedEventArgs_0 = DataRowMergedEventArgs.const_0;
			}
		}

		public Class123()
			: this(new Size(3000, 3000), bool_0: false)
		{
		}

		private DataRowMergedEventArgs method_0(object object_1)
		{
			string text = (string)object_1.GetType().GetMethod("ToString", Type.EmptyTypes).Invoke(object_1, null);
			foreach (DataRowMergedEventArgs value in Enum.GetValues(typeof(DataRowMergedEventArgs)))
			{
				if (value.ToString() == text)
				{
					return value;
				}
			}
			return DataRowMergedEventArgs.BlockMergingEventArgs;
		}

		private object method_1(DataRowMergedEventArgs dataRowMergedEventArgs_0)
		{
			return Class123.Assembly_0.GetType("System.Windows.Forms.DataVisualization.Charting.TextAntiAliasingQuality").GetField(dataRowMergedEventArgs_0.ToString()).GetRawConstantValue();
		}

		private static void smethod_0()
		{
			Class123.Assembly_0 = null;
			AssemblyName assemblyName = new AssemblyName
			{
				Name = "System.Windows.Forms.DataVisualization",
				CultureInfo = new CultureInfo(""),
				Version = ((Environment.Version.Major >= 4) ? new Version(4, 0, 0, 0) : new Version(3, 5, 0, 0)),
				ProcessorArchitecture = ProcessorArchitecture.MSIL
			};
			assemblyName.SetPublicKeyToken(new byte[8] { 49, 191, 56, 86, 173, 54, 78, 53 });
			try
			{
				Class123.Assembly_0 = Assembly.Load(assemblyName);
			}
			catch
			{
			}
		}

		internal static Docking smethod_1(object object_1)
		{
			string text = (string)object_1.GetType().GetMethod("ToString", Type.EmptyTypes).Invoke(object_1, null);
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
			return Class123.Assembly_0.GetType("System.Windows.Forms.DataVisualization.Charting.Docking").GetField(docking_0.ToString()).GetRawConstantValue();
		}

		internal static TextOrientation smethod_3(object object_1)
		{
			string text = (string)object_1.GetType().GetMethod("ToString", Type.EmptyTypes).Invoke(object_1, null);
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
			return Class123.Assembly_0.GetType("System.Windows.Forms.DataVisualization.Charting.TextOrientation").GetField(textOrientation_0.ToString()).GetRawConstantValue();
		}

		internal static ChartDashStyle smethod_5(object object_1)
		{
			string text = (string)object_1.GetType().GetMethod("ToString", Type.EmptyTypes).Invoke(object_1, null);
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
			return Class123.Assembly_0.GetType("System.Windows.Forms.DataVisualization.Charting.ChartDashStyle").GetField(chartDashStyle_0.ToString()).GetRawConstantValue();
		}

		internal static MarkerStyle smethod_7(object object_1)
		{
			string text = (string)object_1.GetType().GetMethod("ToString", Type.EmptyTypes).Invoke(object_1, null);
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
			return Class123.Assembly_0.GetType("System.Windows.Forms.DataVisualization.Charting.MarkerStyle").GetField(markerStyle_0.ToString()).GetRawConstantValue();
		}
	}
}
