using System;
using System.Drawing;
using System.Reflection;
using System.Runtime.CompilerServices;
using TXTextControl.ProxyClasses.Charts;

namespace ns25
{
	internal class Class443
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
				return (string)Class443.propertyInfo_0.GetValue(this.Object_0, null);
			}
			set
			{
				Class443.propertyInfo_0.SetValue(this.Object_0, value, null);
			}
		}

		public Docking Docking_0
		{
			get
			{
				return Class440.smethod_1(Class443.propertyInfo_1.GetValue(this.Object_0, null));
			}
			set
			{
				Class443.propertyInfo_1.SetValue(this.Object_0, Class440.smethod_2(value), null);
			}
		}

		public Font Font_0
		{
			get
			{
				return (Font)Class443.propertyInfo_2.GetValue(this.Object_0, null);
			}
			set
			{
				Class443.propertyInfo_2.SetValue(this.Object_0, value, null);
			}
		}

		public Color Color_0
		{
			get
			{
				return (Color)Class443.propertyInfo_3.GetValue(this.Object_0, null);
			}
			set
			{
				Class443.propertyInfo_3.SetValue(this.Object_0, value, null);
			}
		}

		public string String_1
		{
			get
			{
				return (string)Class443.propertyInfo_4.GetValue(this.Object_0, null);
			}
			set
			{
				Class443.propertyInfo_4.SetValue(this.Object_0, value, null);
			}
		}

		public TextOrientation TextOrientation_0
		{
			get
			{
				return Class440.smethod_3(Class443.propertyInfo_5.GetValue(this.Object_0, null));
			}
			set
			{
				Class443.propertyInfo_5.SetValue(this.Object_0, Class440.smethod_4(value), null);
			}
		}

		static Class443()
		{
			if (!(Class440.Assembly_0 == null))
			{
				Class443.type_0 = Class440.Assembly_0.GetType("System.Windows.Forms.DataVisualization.Charting.Title");
				Class443.propertyInfo_0 = Class443.type_0.GetProperty("DockedToChartArea");
				Class443.propertyInfo_1 = Class443.type_0.GetProperty("Docking");
				Class443.propertyInfo_2 = Class443.type_0.GetProperty("Font");
				Class443.propertyInfo_3 = Class443.type_0.GetProperty("ForeColor");
				Class443.propertyInfo_4 = Class443.type_0.GetProperty("Text");
				Class443.propertyInfo_5 = Class443.type_0.GetProperty("TextOrientation");
			}
		}

		public Class443()
		{
			this.Object_0 = null;
			if (!(Class440.Assembly_0 == null))
			{
				this.Object_0 = Activator.CreateInstance(Class443.type_0, null);
			}
		}

		public Class443(object object_1)
		{
			this.Object_0 = object_1;
		}

		public Class443(string string_0)
		{
			this.Object_0 = Activator.CreateInstance(Class443.type_0, string_0);
			this.Font_0 = new Font("Segoe UI", 14f);
		}
	}
}
