using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Threading;
using TXTextControl.DataVisualization;

namespace ns20
{
	internal class Control7 : ControlProxy, INotifyPropertyChanged
	{
		private PropertyChangedEventHandler propertyChangedEventHandler_0;

		internal int Int32_0
		{
			get
			{
				return (int)base.m_typeControl.GetProperty("Alignment").GetValue(base.m_Control, null);
			}
			set
			{
				if (value != this.Int32_0)
				{
					base.m_typeControl.GetProperty("Alignment").SetValue(base.m_Control, value, null);
					this.method_4("Alignment");
				}
			}
		}

		internal int Int32_1
		{
			get
			{
				return (int)base.m_typeControl.GetProperty("Angle").GetValue(base.m_Control, null);
			}
			set
			{
				if (value != this.Int32_1)
				{
					base.m_typeControl.GetProperty("Angle").SetValue(base.m_Control, value, null);
					this.method_4("Angle");
				}
			}
		}

		internal virtual Color Color_0
		{
			get
			{
				return (Color)base.m_typeControl.GetProperty("BackColor").GetValue(base.m_Control, null);
			}
			set
			{
				if (value.ToArgb() != this.Color_0.ToArgb())
				{
					base.m_typeControl.GetProperty("BackColor").SetValue(base.m_Control, value, null);
					this.method_4("BackColor");
				}
			}
		}

		internal int Int32_2
		{
			get
			{
				return (int)base.m_typeControl.GetProperty("BarcodeType").GetValue(base.m_Control, null);
			}
			set
			{
				base.m_typeControl.GetProperty("BarcodeType").SetValue(base.m_Control, value, null);
			}
		}

		internal override Color ForeColor
		{
			get
			{
				return base.ForeColor;
			}
			set
			{
				if (value.ToArgb() != base.ForeColor.ToArgb())
				{
					base.ForeColor = value;
					this.method_4("ForeColor");
				}
			}
		}

		internal object Object_0 => base.m_Control;

		internal int Int32_3
		{
			get
			{
				return (int)base.m_typeControl.GetProperty("UpperTextLength").GetValue(base.m_Control, null);
			}
			set
			{
				base.m_typeControl.GetProperty("UpperTextLength").SetValue(base.m_Control, value, null);
			}
		}

		public event PropertyChangedEventHandler PropertyChanged
		{
			add
			{
				PropertyChangedEventHandler propertyChangedEventHandler = this.propertyChangedEventHandler_0;
				PropertyChangedEventHandler propertyChangedEventHandler2;
				do
				{
					propertyChangedEventHandler2 = propertyChangedEventHandler;
					PropertyChangedEventHandler value2 = (PropertyChangedEventHandler)Delegate.Combine(propertyChangedEventHandler2, value);
					propertyChangedEventHandler = Interlocked.CompareExchange(ref this.propertyChangedEventHandler_0, value2, propertyChangedEventHandler2);
				}
				while ((object)propertyChangedEventHandler != propertyChangedEventHandler2);
			}
			remove
			{
				PropertyChangedEventHandler propertyChangedEventHandler = this.propertyChangedEventHandler_0;
				PropertyChangedEventHandler propertyChangedEventHandler2;
				do
				{
					propertyChangedEventHandler2 = propertyChangedEventHandler;
					PropertyChangedEventHandler value2 = (PropertyChangedEventHandler)Delegate.Remove(propertyChangedEventHandler2, value);
					propertyChangedEventHandler = Interlocked.CompareExchange(ref this.propertyChangedEventHandler_0, value2, propertyChangedEventHandler2);
				}
				while ((object)propertyChangedEventHandler != propertyChangedEventHandler2);
			}
		}

		internal Control7()
		{
		}

		internal Control7(object object_0)
		{
			if (object_0 == null)
			{
				this.method_0(null);
				base.m_Control = Activator.CreateInstance(base.m_typeControl);
			}
			else
			{
				this.method_0(object_0.GetType());
				base.m_Control = object_0;
			}
		}

		private void method_0(Type type_0)
		{
			/*
			Assembly assembly = null;
			if (type_0 == null)
			{
				AssemblyName assemblyName = new AssemblyName();
				assemblyName.Name = "TXBarcode.Windows.Forms";
				assemblyName.CultureInfo = new CultureInfo("");
				byte[] publicKeyToken = new byte[8] { 23, 255, 248, 167, 116, 0, 76, 102 }; //{ 107, 131, 254, 154, 117, 207, 182, 56 };
				assemblyName.SetPublicKeyToken(publicKeyToken);
				assemblyName.Version = new Version(29, 0, 500, 500);
				assembly = Assembly.Load(assemblyName);
			}
			else
			{
				assembly = Assembly.GetAssembly(type_0);
			}
			*/
			base.m_typeControl = typeof(TXTextControl.Barcode.TXBarcodeControl);
		}

		internal override void Load(Stream stream)
		{
			object[] parameters = new object[1] { stream };
			Type[] types = new Type[1] { stream.GetType() };
			base.m_typeControl.GetMethod("Load", types).Invoke(base.m_Control, parameters);
		}

		internal override void Save(Stream stream)
		{
			object[] parameters = new object[1] { stream };
			Type[] types = new Type[1] { stream.GetType() };
			base.m_typeControl.GetMethod("Save", types).Invoke(base.m_Control, parameters);
		}

		internal override void SaveImage(Stream stream, ImageFormat format)
		{
			object[] parameters = new object[2] { stream, format };
			Type[] types = new Type[2]
			{
				stream.GetType(),
				format.GetType()
			};
			base.m_typeControl.GetMethod("SaveImage", types).Invoke(base.m_Control, parameters);
		}

		internal override void PrintPaint(Graphics graphics, Rectangle position)
		{
			object[] parameters = new object[2] { graphics, position };
			Type[] types = new Type[2]
			{
				graphics.GetType(),
				position.GetType()
			};
			base.m_typeControl.GetMethod("PrintPaint", types).Invoke(base.m_Control, parameters);
		}

		internal string method_1(int int_0)
		{
			object[] parameters = new object[1] { int_0 };
			return (string)base.m_typeControl.GetMethod("GetDefaultText").Invoke(null, parameters);
		}

		internal bool method_2(int int_0, string string_0, out string string_1)
		{
			object[] array = new object[3] { int_0, string_0, null };
			MethodInfo method = base.m_typeControl.GetMethod("IsTextValid");
			bool result = (bool)method.Invoke(null, array);
			string_1 = (string)array[2];
			return result;
		}

		internal string[] method_3()
		{
			PropertyInfo property = base.m_typeControl.GetProperty("BarcodeType");
			return Enum.GetNames(property.PropertyType);
		}

		internal void method_4(string string_0)
		{
			if (this.propertyChangedEventHandler_0 != null)
			{
				this.propertyChangedEventHandler_0(this, new PropertyChangedEventArgs(string_0));
			}
		}
	}
}
