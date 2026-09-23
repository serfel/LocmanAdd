using System;
using System.Drawing;
using System.Reflection;
using System.Runtime.CompilerServices;
using DocumentServer.ProxyClasses.Charts;

namespace ns8
{
	internal class Class110
	{
		private static Type type_0;

		private static PropertyInfo propertyInfo_0;

		private static PropertyInfo propertyInfo_1;

		private static PropertyInfo propertyInfo_2;

		private static PropertyInfo propertyInfo_3;

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

		public bool Boolean_0
		{
			get
			{
				return (bool)Class110.propertyInfo_0.GetValue(this.Object_0, null);
			}
			set
			{
				Class110.propertyInfo_0.SetValue(this.Object_0, value, null);
			}
		}

		public ChartDashStyle ChartDashStyle_0
		{
			get
			{
				return Class123.smethod_5(Class110.propertyInfo_1.GetValue(this.Object_0, null));
			}
			set
			{
				Class110.propertyInfo_1.SetValue(this.Object_0, Class123.smethod_6(value), null);
			}
		}

		public Color Color_0
		{
			get
			{
				return (Color)Class110.propertyInfo_2.GetValue(this.Object_0, null);
			}
			set
			{
				Class110.propertyInfo_2.SetValue(this.Object_0, value, null);
			}
		}

		public int Int32_0
		{
			get
			{
				return (int)Class110.propertyInfo_3.GetValue(this.Object_0, null);
			}
			set
			{
				Class110.propertyInfo_3.SetValue(this.Object_0, value, null);
			}
		}

		static Class110()
		{
			if (!(Class123.Assembly_0 == null))
			{
				Class110.type_0 = Class123.Assembly_0.GetType("System.Windows.Forms.DataVisualization.Charting.Grid");
				Class110.propertyInfo_0 = Class110.type_0.GetProperty("Enabled");
				Class110.propertyInfo_1 = Class110.type_0.GetProperty("LineDashStyle");
				Class110.propertyInfo_2 = Class110.type_0.GetProperty("LineColor");
				Class110.propertyInfo_3 = Class110.type_0.GetProperty("LineWidth");
			}
		}

		public Class110(object object_1)
		{
			this.Object_0 = object_1;
		}

		public Class110()
		{
			if (!(Class123.Assembly_0 == null))
			{
				this.Object_0 = Activator.CreateInstance(Class110.type_0);
			}
		}
	}
}
