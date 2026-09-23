using System;
using System.Drawing;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace ns25
{
	internal class Class455
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
				return (bool)Class455.propertyInfo_0.GetValue(this.Object_0, null);
			}
			set
			{
				Class455.propertyInfo_0.SetValue(this.Object_0, value, null);
			}
		}

		public Color Color_0
		{
			get
			{
				return (Color)Class455.propertyInfo_1.GetValue(this.Object_0, null);
			}
			set
			{
				Class455.propertyInfo_1.SetValue(this.Object_0, value, null);
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

		static Class455()
		{
			if (!(Class440.Assembly_0 == null))
			{
				Class455.type_0 = Class440.Assembly_0.GetType("System.Windows.Forms.DataVisualization.Charting.TickMark");
				Class455.propertyInfo_0 = Class455.type_0.GetProperty("Enabled");
				Class455.propertyInfo_1 = Class455.type_0.GetProperty("LineColor");
			}
		}

		public Class455(object object_1)
		{
			this.Object_0 = object_1;
		}
	}
}
