using System;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace ns8
{
	internal class Class118
	{
		private static Type type_0;

		private static PropertyInfo propertyInfo_0;

		[CompilerGenerated]
		private object object_0;

		public bool Boolean_0
		{
			get
			{
				return (bool)Class118.propertyInfo_0.GetValue(this.Object_0, null);
			}
			set
			{
				Class118.propertyInfo_0.SetValue(this.Object_0, value, null);
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

		static Class118()
		{
			if (!(Class123.Assembly_0 == null))
			{
				Class118.type_0 = Class123.Assembly_0.GetType("System.Windows.Forms.DataVisualization.Charting.ElementPosition");
				Class118.propertyInfo_0 = Class118.type_0.GetProperty("Auto");
			}
		}

		public Class118(object object_1)
		{
			this.Object_0 = object_1;
		}
	}
}
