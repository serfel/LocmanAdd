using System;
using System.Drawing;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace ns25
{
	internal class Class437
	{
		private static Type type_0;

		private static PropertyInfo propertyInfo_0;

		private static PropertyInfo propertyInfo_1;

		private static PropertyInfo propertyInfo_2;

		private static PropertyInfo propertyInfo_3;

		private static PropertyInfo propertyInfo_4;

		private static PropertyInfo propertyInfo_5;

		private static PropertyInfo propertyInfo_6;

		private static PropertyInfo propertyInfo_7;

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
				return (string)Class437.propertyInfo_2.GetValue(this.Object_0, null);
			}
			set
			{
				Class437.propertyInfo_2.SetValue(this.Object_0, value, null);
			}
		}

		public Class439 Class439_0 => new Class439(Class437.propertyInfo_4.GetValue(this.Object_0, null));

		public Class439 Class439_1 => new Class439(Class437.propertyInfo_5.GetValue(this.Object_0, null));

		public Class439 Class439_2 => new Class439(Class437.propertyInfo_6.GetValue(this.Object_0, null));

		public Class439 Class439_3 => new Class439(Class437.propertyInfo_7.GetValue(this.Object_0, null));

		public Class434 Class434_0 => new Class434(Class437.propertyInfo_1.GetValue(this.Object_0, null));

		public Color Color_0
		{
			get
			{
				return (Color)Class437.propertyInfo_0.GetValue(this.Object_0, null);
			}
			set
			{
				Class437.propertyInfo_0.SetValue(this.Object_0, value, null);
			}
		}

		static Class437()
		{
			if (!(Class440.Assembly_0 == null))
			{
				Class437.type_0 = Class440.Assembly_0.GetType("System.Windows.Forms.DataVisualization.Charting.ChartArea");
				Class437.propertyInfo_0 = Class437.type_0.GetProperty("BackColor");
				Class437.propertyInfo_1 = Class437.type_0.GetProperty("Area3DStyle");
				Class437.propertyInfo_2 = Class437.type_0.GetProperty("Name");
				Class437.propertyInfo_3 = Class437.type_0.GetProperty("Axes");
				Class437.propertyInfo_4 = Class437.type_0.GetProperty("AxisX");
				Class437.propertyInfo_5 = Class437.type_0.GetProperty("AxisX2");
				Class437.propertyInfo_6 = Class437.type_0.GetProperty("AxisY");
				Class437.propertyInfo_7 = Class437.type_0.GetProperty("AxisY2");
			}
		}

		public Class437(object object_1)
		{
			this.Object_0 = object_1;
		}

		public Class437(object object_1, bool bool_0)
			: this(object_1)
		{
			this.Class434_0.Boolean_0 = bool_0;
			if (bool_0)
			{
				this.Class434_0.Int32_0 = 2;
			}
			this.Color_0 = Color.Transparent;
			this.Class439_0.Font_0 = new Font("Segoe UI", 10f);
			this.Class439_0.Class448_0.Font_0 = new Font("Segoe UI", 9f);
			this.Class439_2.Font_0 = new Font("Segoe UI", 10f);
			this.Class439_2.Class448_0.Font_0 = new Font("Segoe UI", 9f);
		}

		public Class437(bool bool_0)
			: this(Activator.CreateInstance(Class437.type_0), bool_0)
		{
		}
	}
}
