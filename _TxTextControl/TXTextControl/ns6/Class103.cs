using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.CompilerServices;
using ns1;
using TXTextControl;
using TXTextControl.DataVisualization;

namespace ns6
{
	internal class Class103
	{
		internal enum Enum21
		{
			const_0,
			const_1,
			const_2,
			const_3
		}

		private MethodInfo methodInfo_0;

		private MethodInfo methodInfo_1;

		private MethodInfo methodInfo_2;

		private MethodInfo methodInfo_3;

		private MethodInfo methodInfo_4;

		private PropertyInfo propertyInfo_0;

		private PropertyInfo propertyInfo_1;

		private PropertyInfo propertyInfo_2;

		private PropertyInfo propertyInfo_3;

		private PropertyInfo propertyInfo_4;

		private PropertyInfo propertyInfo_5;

		private PropertyInfo propertyInfo_6;

		protected const string string_0 = "Property not found.";

		[CompilerGenerated]
		private Enum21 enum21_0;

		[CompilerGenerated]
		private object object_0;

		internal Enum21 Enum21_0
		{
			[CompilerGenerated]
			get
			{
				return this.enum21_0;
			}
			[CompilerGenerated]
			private set
			{
				this.enum21_0 = value;
			}
		}

		internal object Object_0
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

		internal Struct24 Struct24_0
		{
			get
			{
				if (this.Object_0 == null)
				{
					return default(Struct24);
				}
				return new Struct24((PageSize)Class103.smethod_1("PageSize", this.Object_0), (PageMargins)Class103.smethod_1("PageMargins", this.Object_0), (bool)Class103.smethod_1("Landscape", this.Object_0), (string)Class103.smethod_1("FormattingPrinter", this.Object_0));
			}
		}

		public TableCollection TableCollection_0
		{
			get
			{
				if (this.propertyInfo_0 == null)
				{
					return null;
				}
				return (TableCollection)this.propertyInfo_0.GetValue(this.Object_0, null);
			}
		}

		public Selection Selection_0
		{
			get
			{
				return (Selection)this.propertyInfo_1.GetValue(this.Object_0, null);
			}
			set
			{
				this.propertyInfo_1.SetValue(this.Object_0, value, null);
			}
		}

		public SubTextPartCollection SubTextPartCollection_0 => (SubTextPartCollection)this.propertyInfo_2.GetValue(this.Object_0, null);

		public InputPosition InputPosition_0
		{
			get
			{
				return (InputPosition)this.propertyInfo_3.GetValue(this.Object_0, null);
			}
			set
			{
				this.propertyInfo_3.SetValue(this.Object_0, value, null);
			}
		}

		public ApplicationFieldCollection ApplicationFieldCollection_0 => (ApplicationFieldCollection)this.propertyInfo_4.GetValue(this.Object_0, null);

		public TextFieldCollection TextFieldCollection_0 => (TextFieldCollection)this.propertyInfo_5.GetValue(this.Object_0, null);

		public BarcodeCollection BarcodeCollection_0 => (BarcodeCollection)this.propertyInfo_6.GetValue(this.Object_0, null);

		internal Class103(object object_1)
			: this(object_1, bool_0: false)
		{
		}

		internal Class103(object object_1, bool bool_0)
		{
			this.Object_0 = object_1;
			this.Enum21_0 = Class103.smethod_2(this.Object_0);
			if (this.Object_0 != null && !bool_0)
			{
				this.method_0(this.Object_0);
			}
		}

		private void method_0(object object_1)
		{
			Type type = object_1.GetType();
			this.methodInfo_0 = type.GetMethod("Load", new Type[3]
			{
				typeof(byte[]),
				typeof(BinaryStreamType),
				typeof(LoadSettings)
			});
			this.methodInfo_1 = type.GetMethod("Save", new Type[2]
			{
				typeof(byte[]).MakeByRefType(),
				typeof(BinaryStreamType)
			});
			this.methodInfo_2 = type.GetMethod("BeginUndoAction", new Type[1] { typeof(string) });
			this.methodInfo_3 = type.GetMethod("EndUndoAction", Type.EmptyTypes);
			this.methodInfo_4 = type.GetMethod("Undo", Type.EmptyTypes);
			this.propertyInfo_0 = type.GetProperty("Tables");
			this.propertyInfo_1 = type.GetProperty("Selection");
			this.propertyInfo_2 = type.GetProperty("SubTextParts");
			this.propertyInfo_3 = type.GetProperty("InputPosition");
			this.propertyInfo_4 = type.GetProperty("ApplicationFields");
			this.propertyInfo_5 = type.GetProperty("TextFields");
			this.propertyInfo_6 = type.GetProperty("Barcodes");
		}

		public void method_1(byte[] byte_0, BinaryStreamType binaryStreamType_0, LoadSettings loadSettings_0)
		{
			if (this.Object_0 != null)
			{
				this.methodInfo_0.Invoke(this.Object_0, new object[3] { byte_0, binaryStreamType_0, loadSettings_0 });
			}
		}

		public void method_2(out byte[] byte_0, BinaryStreamType binaryStreamType_0)
		{
			if (this.Object_0 == null)
			{
				byte_0 = new byte[0];
				return;
			}
			object[] array = new object[2] { null, binaryStreamType_0 };
			this.methodInfo_1.Invoke(this.Object_0, array);
			byte_0 = (byte[])array[0];
		}

		public void method_3(string string_1)
		{
			if (this.methodInfo_2 != null)
			{
				this.methodInfo_2.Invoke(this.Object_0, new object[1] { string_1 });
			}
		}

		public void method_4()
		{
			if (this.methodInfo_3 != null)
			{
				this.methodInfo_3.Invoke(this.Object_0, null);
			}
		}

		public void method_5()
		{
			if (this.methodInfo_4 != null)
			{
				this.methodInfo_4.Invoke(this.Object_0, null);
			}
		}

		internal static bool smethod_0(object object_1)
		{
			return Class103.smethod_2(object_1) != Enum21.const_0;
		}

		internal static object smethod_1(string string_1, object object_1)
		{
			PropertyDescriptor propertyDescriptor = TypeDescriptor.GetProperties(object_1)[string_1];
			if (propertyDescriptor == null)
			{
				throw new ArgumentException("Property not found.", string_1);
			}
			return propertyDescriptor.GetValue(object_1);
		}

		private static Enum21 smethod_2(object object_1)
		{
			if (object_1 == null)
			{
				return Enum21.const_0;
			}
			if (object_1 is ServerTextControl)
			{
				return Enum21.const_1;
			}
			string fullName = object_1.GetType().FullName;
			if (!(fullName == "TXTextControl.WPF.TextControl"))
			{
				if (!(fullName == "TXTextControl.TextControl"))
				{
					return Enum21.const_0;
				}
				return Enum21.const_2;
			}
			return Enum21.const_3;
		}
	}
}
