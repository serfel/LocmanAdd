using System;
using System.Drawing;
using System.Reflection;
using System.Runtime.CompilerServices;
using TXTextControl.ProxyClasses.Charts;

namespace ns25
{
	internal class Class451
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
				return (string)Class451.propertyInfo_0.GetValue(this.Object_0, null);
			}
			set
			{
				Class451.propertyInfo_0.SetValue(this.Object_0, value, null);
			}
		}

		public StringAlignment StringAlignment_0
		{
			get
			{
				return (StringAlignment)Class451.propertyInfo_1.GetValue(this.Object_0, null);
			}
			set
			{
				Class451.propertyInfo_1.SetValue(this.Object_0, value, null);
			}
		}

		public Docking Docking_0
		{
			get
			{
				return Class440.smethod_1(Class451.propertyInfo_2.GetValue(this.Object_0, null));
			}
			set
			{
				Class451.propertyInfo_2.SetValue(this.Object_0, Class440.smethod_2(value), null);
			}
		}

		public bool Boolean_0
		{
			get
			{
				return (bool)Class451.propertyInfo_3.GetValue(this.Object_0, null);
			}
			set
			{
				Class451.propertyInfo_3.SetValue(this.Object_0, value, null);
			}
		}

		public Font Font_0
		{
			get
			{
				return (Font)Class451.propertyInfo_4.GetValue(this.Object_0, null);
			}
			set
			{
				Class451.propertyInfo_4.SetValue(this.Object_0, value, null);
			}
		}

		public Color Color_0
		{
			get
			{
				return (Color)Class451.propertyInfo_5.GetValue(this.Object_0, null);
			}
			set
			{
				Class451.propertyInfo_5.SetValue(this.Object_0, value, null);
			}
		}

		public Class447 Class447_0 => new Class447(Class451.propertyInfo_6.GetValue(this.Object_0, null));

		static Class451()
		{
			if (!(Class440.Assembly_0 == null))
			{
				Class451.type_0 = Class440.Assembly_0.GetType("System.Windows.Forms.DataVisualization.Charting.Legend");
				Class451.propertyInfo_0 = Class451.type_0.GetProperty("Name");
				Class451.propertyInfo_1 = Class451.type_0.GetProperty("Alignment");
				Class451.propertyInfo_2 = Class451.type_0.GetProperty("Docking");
				Class451.propertyInfo_3 = Class451.type_0.GetProperty("Enabled");
				Class451.propertyInfo_4 = Class451.type_0.GetProperty("Font");
				Class451.propertyInfo_5 = Class451.type_0.GetProperty("ForeColor");
				Class451.propertyInfo_6 = Class451.type_0.GetProperty("Position");
			}
		}

		public Class451(string string_0)
		{
			this.Object_0 = null;
			if (!(Class440.Assembly_0 == null))
			{
				this.Object_0 = Activator.CreateInstance(Class451.type_0);
				this.Font_0 = new Font("Segoe UI", 9f);
				this.Docking_0 = Docking.Bottom;
				this.StringAlignment_0 = StringAlignment.Center;
				this.String_0 = string_0;
			}
		}

		public Class451(object object_1)
		{
			this.Object_0 = object_1;
		}
	}
}
