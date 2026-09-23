using System;
using System.Drawing;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace ns8
{
	internal class Class119
	{
		private static Type type_0;

		private static PropertyInfo propertyInfo_0;

		private static PropertyInfo propertyInfo_1;

		private static PropertyInfo propertyInfo_2;

		private static PropertyInfo propertyInfo_3;

		[CompilerGenerated]
		private object object_0;

		public bool Boolean_0
		{
			get
			{
				return (bool)Class119.propertyInfo_0.GetValue(this.Object_0, null);
			}
			set
			{
				Class119.propertyInfo_0.SetValue(this.Object_0, value, null);
			}
		}

		public Font Font_0
		{
			get
			{
				return (Font)Class119.propertyInfo_1.GetValue(this.Object_0, null);
			}
			set
			{
				Class119.propertyInfo_1.SetValue(this.Object_0, value, null);
			}
		}

		public Color Color_0
		{
			get
			{
				return (Color)Class119.propertyInfo_2.GetValue(this.Object_0, null);
			}
			set
			{
				Class119.propertyInfo_2.SetValue(this.Object_0, value, null);
			}
		}

		public string String_0
		{
			get
			{
				return (string)Class119.propertyInfo_3.GetValue(this.Object_0, null);
			}
			set
			{
				Class119.propertyInfo_3.SetValue(this.Object_0, value, null);
			}
		}

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

		static Class119()
		{
			if (!(Class123.Assembly_0 == null))
			{
				Class119.type_0 = Class123.Assembly_0.GetType("System.Windows.Forms.DataVisualization.Charting.LabelStyle");
				Class119.propertyInfo_0 = Class119.type_0.GetProperty("Enabled");
				Class119.propertyInfo_1 = Class119.type_0.GetProperty("Font");
				Class119.propertyInfo_2 = Class119.type_0.GetProperty("ForeColor");
				Class119.propertyInfo_3 = Class119.type_0.GetProperty("Format");
			}
		}

		public Class119(object object_1)
		{
			this.Object_0 = object_1;
		}
	}
}
