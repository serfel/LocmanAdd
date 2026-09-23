using System;
using System.Drawing;
using System.Reflection;
using System.Runtime.CompilerServices;
using DocumentServer.ProxyClasses.Charts;

namespace ns8
{
	internal class Class114
	{
		private static Type type_0;

		private static PropertyInfo propertyInfo_0;

		private static PropertyInfo propertyInfo_1;

		private static PropertyInfo propertyInfo_2;

		private static PropertyInfo propertyInfo_3;

		private static PropertyInfo propertyInfo_4;

		private static PropertyInfo propertyInfo_5;

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
				return (string)Class114.propertyInfo_0.GetValue(this.Object_0, null);
			}
			set
			{
				Class114.propertyInfo_0.SetValue(this.Object_0, value, null);
			}
		}

		public Docking Docking_0
		{
			get
			{
				return Class123.smethod_1(Class114.propertyInfo_1.GetValue(this.Object_0, null));
			}
			set
			{
				Class114.propertyInfo_1.SetValue(this.Object_0, Class123.smethod_2(value), null);
			}
		}

		public Font Font_0
		{
			get
			{
				return (Font)Class114.propertyInfo_2.GetValue(this.Object_0, null);
			}
			set
			{
				Class114.propertyInfo_2.SetValue(this.Object_0, value, null);
			}
		}

		public Color Color_0
		{
			get
			{
				return (Color)Class114.propertyInfo_3.GetValue(this.Object_0, null);
			}
			set
			{
				Class114.propertyInfo_3.SetValue(this.Object_0, value, null);
			}
		}

		public string String_1
		{
			get
			{
				return (string)Class114.propertyInfo_4.GetValue(this.Object_0, null);
			}
			set
			{
				Class114.propertyInfo_4.SetValue(this.Object_0, value, null);
			}
		}

		public TextOrientation TextOrientation_0
		{
			get
			{
				return Class123.smethod_3(Class114.propertyInfo_5.GetValue(this.Object_0, null));
			}
			set
			{
				Class114.propertyInfo_5.SetValue(this.Object_0, Class123.smethod_4(value), null);
			}
		}

		static Class114()
		{
			if (!(Class123.Assembly_0 == null))
			{
				Class114.type_0 = Class123.Assembly_0.GetType("System.Windows.Forms.DataVisualization.Charting.Title");
				Class114.propertyInfo_0 = Class114.type_0.GetProperty("DockedToChartArea");
				Class114.propertyInfo_1 = Class114.type_0.GetProperty("Docking");
				Class114.propertyInfo_2 = Class114.type_0.GetProperty("Font");
				Class114.propertyInfo_3 = Class114.type_0.GetProperty("ForeColor");
				Class114.propertyInfo_4 = Class114.type_0.GetProperty("Text");
				Class114.propertyInfo_5 = Class114.type_0.GetProperty("TextOrientation");
			}
		}

		public Class114()
		{
			this.Object_0 = null;
			if (!(Class123.Assembly_0 == null))
			{
				this.Object_0 = Activator.CreateInstance(Class114.type_0, null);
			}
		}

		public Class114(object object_1)
		{
			this.Object_0 = object_1;
		}

		public Class114(string string_0)
		{
			this.Object_0 = Activator.CreateInstance(Class114.type_0, string_0);
			this.Font_0 = new Font("Segoe UI", 14f);
		}
	}
}
