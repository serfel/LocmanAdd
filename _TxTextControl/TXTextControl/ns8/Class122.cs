using System;
using System.Drawing;
using System.Reflection;
using System.Runtime.CompilerServices;
using DocumentServer.ProxyClasses.Charts;

namespace ns8
{
	internal class Class122
	{
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
				return (string)Class122.propertyInfo_0.GetValue(this.Object_0, null);
			}
			set
			{
				Class122.propertyInfo_0.SetValue(this.Object_0, value, null);
			}
		}

		public StringAlignment StringAlignment_0
		{
			get
			{
				return (StringAlignment)Class122.propertyInfo_1.GetValue(this.Object_0, null);
			}
			set
			{
				Class122.propertyInfo_1.SetValue(this.Object_0, value, null);
			}
		}

		public Docking Docking_0
		{
			get
			{
				return Class123.smethod_1(Class122.propertyInfo_2.GetValue(this.Object_0, null));
			}
			set
			{
				Class122.propertyInfo_2.SetValue(this.Object_0, Class123.smethod_2(value), null);
			}
		}

		public bool Boolean_0
		{
			get
			{
				return (bool)Class122.propertyInfo_3.GetValue(this.Object_0, null);
			}
			set
			{
				Class122.propertyInfo_3.SetValue(this.Object_0, value, null);
			}
		}

		public Font Font_0
		{
			get
			{
				return (Font)Class122.propertyInfo_4.GetValue(this.Object_0, null);
			}
			set
			{
				Class122.propertyInfo_4.SetValue(this.Object_0, value, null);
			}
		}

		public Color Color_0
		{
			get
			{
				return (Color)Class122.propertyInfo_5.GetValue(this.Object_0, null);
			}
			set
			{
				Class122.propertyInfo_5.SetValue(this.Object_0, value, null);
			}
		}

		public Class118 Class118_0 => new Class118(Class122.propertyInfo_6.GetValue(this.Object_0, null));

		static Class122()
		{
			if (!(Class123.Assembly_0 == null))
			{
				Class122.type_0 = Class123.Assembly_0.GetType("System.Windows.Forms.DataVisualization.Charting.Legend");
				Class122.propertyInfo_0 = Class122.type_0.GetProperty("Name");
				Class122.propertyInfo_1 = Class122.type_0.GetProperty("Alignment");
				Class122.propertyInfo_2 = Class122.type_0.GetProperty("Docking");
				Class122.propertyInfo_3 = Class122.type_0.GetProperty("Enabled");
				Class122.propertyInfo_4 = Class122.type_0.GetProperty("Font");
				Class122.propertyInfo_5 = Class122.type_0.GetProperty("ForeColor");
				Class122.propertyInfo_6 = Class122.type_0.GetProperty("Position");
			}
		}

		public Class122(string string_0)
		{
			this.Object_0 = null;
			if (!(Class123.Assembly_0 == null))
			{
				this.Object_0 = Activator.CreateInstance(Class122.type_0);
				this.Font_0 = new Font("Segoe UI", 9f);
				this.Docking_0 = Docking.Bottom;
				this.StringAlignment_0 = StringAlignment.Center;
				this.String_0 = string_0;
			}
		}

		public Class122(object object_1)
		{
			this.Object_0 = object_1;
		}
	}
}
