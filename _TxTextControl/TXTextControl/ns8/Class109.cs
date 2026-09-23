using System;
using System.Drawing;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace ns8
{
	internal class Class109
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
				return (string)Class109.propertyInfo_2.GetValue(this.Object_0, null);
			}
			set
			{
				Class109.propertyInfo_2.SetValue(this.Object_0, value, null);
			}
		}

		public Class111 Class111_0 => new Class111(Class109.propertyInfo_4.GetValue(this.Object_0, null));

		public Class111 Class111_1 => new Class111(Class109.propertyInfo_5.GetValue(this.Object_0, null));

		public Class111 Class111_2 => new Class111(Class109.propertyInfo_6.GetValue(this.Object_0, null));

		public Class111 Class111_3 => new Class111(Class109.propertyInfo_7.GetValue(this.Object_0, null));

		public Class106 Class106_0 => new Class106(Class109.propertyInfo_1.GetValue(this.Object_0, null));

		public Color Color_0
		{
			get
			{
				return (Color)Class109.propertyInfo_0.GetValue(this.Object_0, null);
			}
			set
			{
				Class109.propertyInfo_0.SetValue(this.Object_0, value, null);
			}
		}

		static Class109()
		{
			if (!(Class123.Assembly_0 == null))
			{
				Class109.type_0 = Class123.Assembly_0.GetType("System.Windows.Forms.DataVisualization.Charting.ChartArea");
				Class109.propertyInfo_0 = Class109.type_0.GetProperty("BackColor");
				Class109.propertyInfo_1 = Class109.type_0.GetProperty("Area3DStyle");
				Class109.propertyInfo_2 = Class109.type_0.GetProperty("Name");
				Class109.propertyInfo_3 = Class109.type_0.GetProperty("Axes");
				Class109.propertyInfo_4 = Class109.type_0.GetProperty("AxisX");
				Class109.propertyInfo_5 = Class109.type_0.GetProperty("AxisX2");
				Class109.propertyInfo_6 = Class109.type_0.GetProperty("AxisY");
				Class109.propertyInfo_7 = Class109.type_0.GetProperty("AxisY2");
			}
		}

		public Class109(object object_1)
		{
			this.Object_0 = object_1;
		}

		public Class109(object object_1, bool bool_0)
			: this(object_1)
		{
			this.Class106_0.Boolean_0 = bool_0;
			if (bool_0)
			{
				this.Class106_0.Int32_0 = 2;
			}
			this.Color_0 = Color.Transparent;
			this.Class111_0.Font_0 = new Font("Segoe UI", 10f);
			this.Class111_0.Class119_0.Font_0 = new Font("Segoe UI", 9f);
			this.Class111_2.Font_0 = new Font("Segoe UI", 10f);
			this.Class111_2.Class119_0.Font_0 = new Font("Segoe UI", 9f);
		}

		public Class109(bool bool_0)
			: this(Activator.CreateInstance(Class109.type_0), bool_0)
		{
		}
	}
}
