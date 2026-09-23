using System;
using System.Drawing;
using System.Globalization;
using System.Reflection;
using TXTextControl;

namespace ns20
{
	internal class Control8 : Control7
	{
		internal override int Height
		{
			get
			{
				double num = (double)base.m_typeControl.GetProperty("Height").GetValue(base.m_Control, null);
				if (double.IsNaN(num))
				{
					num = 150.0;
				}
				Graphics graphics = Graphics.FromHwnd(base.m_tx.IntPtr_0);
				int result = Convert.ToInt32(num / 96.0 * (double)graphics.DpiY);
				graphics.Dispose();
				return result;
			}
		}

		internal override int Width
		{
			get
			{
				double num = (double)base.m_typeControl.GetProperty("Width").GetValue(base.m_Control, null);
				if (double.IsNaN(num))
				{
					num = 150.0;
				}
				Graphics graphics = Graphics.FromHwnd(base.m_tx.IntPtr_0);
				int result = Convert.ToInt32(num / 96.0 * (double)graphics.DpiX);
				graphics.Dispose();
				return result;
			}
		}

		internal override Color ForeColor
		{
			get
			{
				return this.method_7("ForeColor", SystemColors.WindowText);
			}
			set
			{
				if (value.ToArgb() != this.ForeColor.ToArgb())
				{
					this.method_6(value, "ForeColor", SystemColors.WindowText);
					base.method_4("ForeColor");
				}
			}
		}

		internal override Color Color_0
		{
			get
			{
				return this.method_7("BackColor", SystemColors.Window);
			}
			set
			{
				if (value.ToArgb() != this.Color_0.ToArgb())
				{
					this.method_6(value, "BackColor", SystemColors.Window);
					base.method_4("BackColor");
				}
			}
		}

		internal Control8(object object_0, TextControlCore textControlCore_0)
		{
			base.m_tx = textControlCore_0;
			if (object_0 == null)
			{
				this.method_5(null);
				base.m_Control = Activator.CreateInstance(base.m_typeControl);
			}
			else
			{
				this.method_5(object_0.GetType());
				base.m_Control = object_0;
			}
		}

		private void method_5(Type type_0)
		{
			Assembly assembly = null;
			if (type_0 == null)
			{
				AssemblyName assemblyName = new AssemblyName();
				assemblyName.Name = "TXBarcode.WPF";
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
			base.m_typeControl = assembly.GetType("TXTextControl.WPF.Barcode.TXBarcodeControl");
		}

		private void method_6(Color color_0, string string_0, Color color_1)
		{
			PropertyInfo property = base.m_typeControl.GetProperty(string_0);
			Type propertyType = property.PropertyType;
			if (color_0 == color_1)
			{
				property.SetValue(base.m_Control, null, null);
				return;
			}
			Type[] genericArguments = propertyType.GetGenericArguments();
			Type type = genericArguments[0];
			object obj = Activator.CreateInstance(type);
			type.GetProperty("A").SetValue(obj, color_0.A, null);
			type.GetProperty("R").SetValue(obj, color_0.R, null);
			type.GetProperty("G").SetValue(obj, color_0.G, null);
			type.GetProperty("B").SetValue(obj, color_0.B, null);
			property.SetValue(base.m_Control, obj, null);
		}

		private Color method_7(string string_0, Color color_0)
		{
			object value = base.m_typeControl.GetProperty(string_0).GetValue(base.m_Control, null);
			if (value == null)
			{
				return color_0;
			}
			Type type = value.GetType();
			return Color.FromArgb(Convert.ToInt32((byte)type.GetProperty("A").GetValue(value, null)), Convert.ToInt32((byte)type.GetProperty("R").GetValue(value, null)), Convert.ToInt32((byte)type.GetProperty("G").GetValue(value, null)), Convert.ToInt32((byte)type.GetProperty("B").GetValue(value, null)));
		}
	}
}
