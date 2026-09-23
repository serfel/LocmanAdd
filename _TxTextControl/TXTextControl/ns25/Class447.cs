using System;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace ns25
{
	internal class Class447
	{
		private static Type type_0;

		private static PropertyInfo propertyInfo_0;

		[CompilerGenerated]
		private object object_0;

		public bool Boolean_0
		{
			get
			{
				return (bool)Class447.propertyInfo_0.GetValue(this.Object_0, null);
			}
			set
			{
				Class447.propertyInfo_0.SetValue(this.Object_0, value, null);
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

		static Class447()
		{
			if (!(Class440.Assembly_0 == null))
			{
				Class447.type_0 = Class440.Assembly_0.GetType("System.Windows.Forms.DataVisualization.Charting.ElementPosition");
				Class447.propertyInfo_0 = Class447.type_0.GetProperty("Auto");
			}
		}

		public Class447(object object_1)
		{
			this.Object_0 = object_1;
		}
	}
}
