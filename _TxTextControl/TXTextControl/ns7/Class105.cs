using System;
using System.Reflection;

namespace ns7
{
	internal class Class105
	{
		public const string string_0 = "System.Windows.Forms.SaveFileDialog, System.Windows.Forms, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089";

		private static Type type_0;

		private static MethodInfo methodInfo_0;

		private static PropertyInfo propertyInfo_0;

		private static PropertyInfo propertyInfo_1;

		private static PropertyInfo propertyInfo_2;

		private static PropertyInfo propertyInfo_3;

		private object object_0;

		private const string string_1 = "System.Windows.Forms.IWin32Window, System.Windows.Forms, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089";

		public string String_0
		{
			get
			{
				return (string)Class105.propertyInfo_0.GetValue(this.object_0, null);
			}
			set
			{
				Class105.propertyInfo_0.SetValue(this.object_0, value, null);
			}
		}

		public bool Boolean_0
		{
			get
			{
				return (bool)Class105.propertyInfo_1.GetValue(this.object_0, null);
			}
			set
			{
				Class105.propertyInfo_1.SetValue(this.object_0, value, null);
			}
		}

		public bool Boolean_1
		{
			get
			{
				return (bool)Class105.propertyInfo_2.GetValue(this.object_0, null);
			}
			set
			{
				Class105.propertyInfo_2.SetValue(this.object_0, value, null);
			}
		}

		public string String_1
		{
			get
			{
				return (string)Class105.propertyInfo_3.GetValue(this.object_0, null);
			}
			set
			{
				Class105.propertyInfo_3.SetValue(this.object_0, value, null);
			}
		}

		static Class105()
		{
			Class105.type_0 = Type.GetType("System.Windows.Forms.SaveFileDialog, System.Windows.Forms, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089");
			Class105.propertyInfo_0 = Class105.type_0.GetProperty("Filter");
			Class105.propertyInfo_1 = Class105.type_0.GetProperty("OverwritePrompt");
			Class105.propertyInfo_2 = Class105.type_0.GetProperty("AddExtension");
			Class105.propertyInfo_3 = Class105.type_0.GetProperty("FileName");
			Type type = Type.GetType("System.Windows.Forms.IWin32Window, System.Windows.Forms, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089");
			Class105.methodInfo_0 = Class105.type_0.GetMethod("ShowDialog", new Type[1] { type });
		}

		public Class105()
		{
			this.object_0 = Activator.CreateInstance(Class105.type_0);
		}

		internal bool method_0(object object_1)
		{
			return (bool)Class105.methodInfo_0.Invoke(this.object_0, new object[1] { object_1 });
		}
	}
}
