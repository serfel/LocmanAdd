using System;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace ns8
{
	internal class Class117
	{
		private static Type type_0;

		private static PropertyInfo propertyInfo_0;

		private static PropertyInfo propertyInfo_1;

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

		public string String_0
		{
			get
			{
				return (string)Class117.propertyInfo_0.GetValue(this.Object_0, null);
			}
			set
			{
				Class117.propertyInfo_0.SetValue(this.Object_0, value, null);
			}
		}

		public double Double_0
		{
			get
			{
				return (double)this.method_1().GetValue(0);
			}
			set
			{
				this.method_1().SetValue(value, 0);
			}
		}

		static Class117()
		{
			if (!(Class123.Assembly_0 == null))
			{
				Class117.type_0 = Class123.Assembly_0.GetType("System.Windows.Forms.DataVisualization.Charting.DataPoint");
				Class117.propertyInfo_0 = Class117.type_0.GetProperty("AxisLabel");
				Class117.propertyInfo_1 = Class117.type_0.GetProperty("YValues");
			}
		}

		public Class117(object object_1)
		{
			this.Object_0 = object_1;
		}

		public Class117(double double_0, string string_0)
		{
			this.Object_0 = Activator.CreateInstance(Class117.type_0, 0.0, double_0);
			this.String_0 = string_0;
		}

		public Class117(double double_0)
			: this(double_0, string.Empty)
		{
		}

		public void method_0(double double_0, int int_0)
		{
			this.method_1().SetValue(double_0, int_0);
		}

		private Array method_1()
		{
			return (Array)Class117.propertyInfo_1.GetValue(this.Object_0, null);
		}
	}
}
