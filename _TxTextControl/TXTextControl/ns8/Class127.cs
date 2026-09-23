using System;
using System.Drawing;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace ns8
{
	internal class Class127
	{
		private static Type type_0;

		private static PropertyInfo propertyInfo_0;

		private static PropertyInfo propertyInfo_1;

		[CompilerGenerated]
		private object object_0;

		public bool Boolean_0
		{
			get
			{
				return (bool)Class127.propertyInfo_0.GetValue(this.Object_0, null);
			}
			set
			{
				Class127.propertyInfo_0.SetValue(this.Object_0, value, null);
			}
		}

		public Color Color_0
		{
			get
			{
				return (Color)Class127.propertyInfo_1.GetValue(this.Object_0, null);
			}
			set
			{
				Class127.propertyInfo_1.SetValue(this.Object_0, value, null);
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

		static Class127()
		{
			if (!(Class123.Assembly_0 == null))
			{
				Class127.type_0 = Class123.Assembly_0.GetType("System.Windows.Forms.DataVisualization.Charting.TickMark");
				Class127.propertyInfo_0 = Class127.type_0.GetProperty("Enabled");
				Class127.propertyInfo_1 = Class127.type_0.GetProperty("LineColor");
			}
		}

		public Class127(object object_1)
		{
			this.Object_0 = object_1;
		}
	}
}
