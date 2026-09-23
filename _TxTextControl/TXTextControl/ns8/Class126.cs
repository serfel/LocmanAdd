using System;
using System.Drawing;
using System.Reflection;
using System.Runtime.CompilerServices;
using DocumentServer.ProxyClasses.Charts;

namespace ns8
{
	internal class Class126
	{
		public enum Enum23
		{
			const_0 = -1,
			const_1,
			DataRowMergedEventArgs,
			BlockMergingEventArgs,
			FieldMergedEventArgs,
			const_5,
			const_6,
			const_7,
			const_8,
			ImageFieldMergedEventArgs,
			IncludeTextMergingEventArgs,
			ChartMergedEventArgs,
			BarcodeMergedEventArgs,
			ImageMergedEventArgs,
			const_14,
			const_15,
			MailMerge,
			TXTextControl_002EDocumentServer,
			const_18,
			const_19,
			const_20,
			const_21,
			const_22,
			const_23,
			const_24,
			const_25,
			const_26,
			const_27,
			const_28,
			const_29,
			const_30,
			const_31,
			const_32,
			const_33,
			const_34,
			const_35
		}

		private static Type type_0;

		private static PropertyInfo propertyInfo_0;

		private static PropertyInfo propertyInfo_1;

		private static PropertyInfo propertyInfo_2;

		private static PropertyInfo propertyInfo_3;

		private static PropertyInfo propertyInfo_4;

		private static PropertyInfo propertyInfo_5;

		private static PropertyInfo propertyInfo_6;

		private static PropertyInfo propertyInfo_7;

		private static PropertyInfo propertyInfo_8;

		private static PropertyInfo propertyInfo_9;

		private static PropertyInfo propertyInfo_10;

		private static PropertyInfo propertyInfo_11;

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

		public int Int32_0
		{
			get
			{
				return (int)Class126.propertyInfo_0.GetValue(this.Object_0, null);
			}
			set
			{
				Class126.propertyInfo_0.SetValue(this.Object_0, value, null);
			}
		}

		public Class115 Class115_0 => new Class115(Class126.propertyInfo_1.GetValue(this.Object_0, null));

		public string String_0
		{
			get
			{
				return (string)Class126.propertyInfo_5.GetValue(this.Object_0, null);
			}
			set
			{
				Class126.propertyInfo_5.SetValue(this.Object_0, value, null);
			}
		}

		public string String_1
		{
			get
			{
				return (string)Class126.propertyInfo_6.GetValue(this.Object_0, null);
			}
			set
			{
				Class126.propertyInfo_6.SetValue(this.Object_0, value, null);
			}
		}

		public bool Boolean_0
		{
			get
			{
				return (bool)Class126.propertyInfo_8.GetValue(this.Object_0, null);
			}
			set
			{
				Class126.propertyInfo_8.SetValue(this.Object_0, value, null);
			}
		}

		public Font Font_0
		{
			get
			{
				return (Font)Class126.propertyInfo_9.GetValue(this.Object_0, null);
			}
			set
			{
				Class126.propertyInfo_9.SetValue(this.Object_0, value, null);
			}
		}

		public Color Color_0
		{
			get
			{
				return (Color)Class126.propertyInfo_10.GetValue(this.Object_0, null);
			}
			set
			{
				Class126.propertyInfo_10.SetValue(this.Object_0, value, null);
			}
		}

		public Color Color_1
		{
			get
			{
				return (Color)Class126.propertyInfo_11.GetValue(this.Object_0, null);
			}
			set
			{
				Class126.propertyInfo_11.SetValue(this.Object_0, value, null);
			}
		}

		public Enum23 Enum23_0
		{
			get
			{
				return Class126.smethod_1(Class126.propertyInfo_7.GetValue(this.Object_0, null));
			}
			set
			{
				Class126.propertyInfo_7.SetValue(this.Object_0, Class126.smethod_0(value), null);
			}
		}

		public Color Color_2
		{
			get
			{
				return (Color)Class126.propertyInfo_4.GetValue(this.Object_0, null);
			}
			set
			{
				Class126.propertyInfo_4.SetValue(this.Object_0, value, null);
			}
		}

		public MarkerStyle MarkerStyle_0
		{
			get
			{
				return Class123.smethod_7(Class126.propertyInfo_2.GetValue(this.Object_0, null));
			}
			set
			{
				Class126.propertyInfo_2.SetValue(this.Object_0, Class123.smethod_8(value), null);
			}
		}

		public int Int32_1
		{
			get
			{
				return (int)Class126.propertyInfo_3.GetValue(this.Object_0, null);
			}
			set
			{
				Class126.propertyInfo_3.SetValue(this.Object_0, value, null);
			}
		}

		static Class126()
		{
			if (!(Class123.Assembly_0 == null))
			{
				Class126.type_0 = Class123.Assembly_0.GetType("System.Windows.Forms.DataVisualization.Charting.Series");
				Class126.propertyInfo_0 = Class126.type_0.GetProperty("BorderWidth");
				Class126.propertyInfo_1 = Class126.type_0.GetProperty("Points");
				Class126.propertyInfo_4 = Class126.type_0.GetProperty("MarkerColor");
				Class126.propertyInfo_2 = Class126.type_0.GetProperty("MarkerStyle");
				Class126.propertyInfo_3 = Class126.type_0.GetProperty("MarkerSize");
				Class126.propertyInfo_5 = Class126.type_0.GetProperty("Name");
				Class126.propertyInfo_6 = Class126.type_0.GetProperty("ChartArea");
				Class126.propertyInfo_7 = Class126.type_0.GetProperty("ChartType");
				Class126.propertyInfo_8 = Class126.type_0.GetProperty("IsValueShownAsLabel");
				Class126.propertyInfo_9 = Class126.type_0.GetProperty("Font");
				Class126.propertyInfo_10 = Class126.type_0.GetProperty("LabelBackColor");
				Class126.propertyInfo_11 = Class126.type_0.GetProperty("LabelBorderColor");
			}
		}

		public Class126()
		{
			this.Object_0 = null;
			if (!(Class123.Assembly_0 == null))
			{
				this.Object_0 = Activator.CreateInstance(Class126.type_0, null);
			}
		}

		public Class126(object object_1)
		{
			this.Object_0 = object_1;
		}

		public Class126(Enum23 enum23_0, int int_0)
		{
			this.Object_0 = Activator.CreateInstance(Class126.type_0);
			this.Enum23_0 = enum23_0;
			for (int i = 0; i < int_0; i++)
			{
				this.Class115_0.Add(new Class117(0.0));
			}
		}

		public Class126(Enum23 enum23_0)
			: this(enum23_0, 0)
		{
		}

		public Class126(Class126 class126_0)
			: this(class126_0.Enum23_0)
		{
			for (int i = 0; i < class126_0.Class115_0.Count; i++)
			{
				this.Class115_0.Add(new Class117(0.0, class126_0.Class115_0[i].String_0));
			}
		}

		private static object smethod_0(Enum23 enum23_0)
		{
			return Class123.Assembly_0.GetType("System.Windows.Forms.DataVisualization.Charting.SeriesChartType").GetField(enum23_0.ToString()).GetRawConstantValue();
		}

		private static Enum23 smethod_1(object object_1)
		{
			string text = (string)object_1.GetType().GetMethod("ToString", Type.EmptyTypes).Invoke(object_1, null);
			foreach (Enum23 value in Enum.GetValues(typeof(Enum23)))
			{
				if (value.ToString() == text)
				{
					return value;
				}
			}
			return Enum23.const_0;
		}
	}
}
