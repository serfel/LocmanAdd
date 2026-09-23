using System;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace ns25
{
	internal class Class446
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
				return (string)Class446.propertyInfo_0.GetValue(this.Object_0, null);
			}
			set
			{
				Class446.propertyInfo_0.SetValue(this.Object_0, value, null);
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

		static Class446()
		{
			if (!(Class440.Assembly_0 == null))
			{
				Class446.type_0 = Class440.Assembly_0.GetType("System.Windows.Forms.DataVisualization.Charting.DataPoint");
				Class446.propertyInfo_0 = Class446.type_0.GetProperty("AxisLabel");
				Class446.propertyInfo_1 = Class446.type_0.GetProperty("YValues");
			}
		}

		public Class446(object object_1)
		{
			this.Object_0 = object_1;
		}

		public Class446(double double_0, string string_0)
		{
			this.Object_0 = Activator.CreateInstance(Class446.type_0, 0.0, double_0);
			this.String_0 = string_0;
		}

		public Class446(double double_0)
			: this(double_0, string.Empty)
		{
		}

		public void method_0(double double_0, int int_0)
		{
			this.method_1().SetValue(double_0, int_0);
		}

		private Array method_1()
		{
			return (Array)Class446.propertyInfo_1.GetValue(this.Object_0, null);
		}
	}
}
