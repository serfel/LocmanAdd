using System;
using System.Drawing;
using System.Globalization;
using System.Reflection;
using TXTextControl;

namespace ns20
{
	internal class Control11 : Control10
	{
		internal override Color BackColor
		{
			get
			{
				return this.method_19(base.m_Control, "BackColor", SystemColors.Window);
			}
			set
			{
				this.method_20(base.m_Control, value, "BackColor", SystemColors.Window);
			}
		}

		internal override Color BorderColor
		{
			get
			{
				return this.method_19(base.m_Control, "BorderColor", SystemColors.WindowText);
			}
			set
			{
				this.method_20(base.m_Control, value, "BorderColor", SystemColors.WindowText);
			}
		}

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

		internal Control11(object object_0, TextControlCore textControlCore_0)
		{
			base.m_tx = textControlCore_0;
			this.method_18();
			base.m_Control = ((object_0 == null) ? Activator.CreateInstance(base.m_typeControl) : object_0);
		}

		private void method_18()
		{
			Assembly assembly = null;
			Assembly assembly2 = null;
			AssemblyName assemblyName = new AssemblyName();
			assemblyName.CultureInfo = new CultureInfo("");
			byte[] publicKeyToken = new byte[8] { 23, 255, 248, 167, 116, 0, 76, 102 }; //{ 107, 131, 254, 154, 117, 207, 182, 56 };
			assemblyName.SetPublicKeyToken(publicKeyToken);
			assemblyName.Version = new Version(29, 0, 500, 500);
			assemblyName.Name = "TXDrawing.WPF";
			assembly = Assembly.Load(assemblyName);
			assemblyName.Name = "TXDrawing";
			assembly2 = Assembly.Load(assemblyName);
			base.m_typeControl = assembly.GetType("TXTextControl.WPF.Drawing.TXDrawingControl");
			base.type_0 = assembly2.GetType("TXTextControl.Drawing.ShapeCollection");
			base.type_1 = assembly2.GetType("TXTextControl.Drawing.Shape");
		}

		private Color method_19(object object_0, string string_0, Color color_0)
		{
			object value = object_0.GetType().GetProperty(string_0).GetValue(object_0, null);
			if (value == null)
			{
				return color_0;
			}
			Type type = value.GetType();
			return Color.FromArgb(Convert.ToInt32((byte)type.GetProperty("A").GetValue(value, null)), Convert.ToInt32((byte)type.GetProperty("R").GetValue(value, null)), Convert.ToInt32((byte)type.GetProperty("G").GetValue(value, null)), Convert.ToInt32((byte)type.GetProperty("B").GetValue(value, null)));
		}

		private bool method_20(object object_0, Color color_0, string string_0, Color color_1)
		{
			bool result = false;
			PropertyInfo property = object_0.GetType().GetProperty(string_0);
			Type propertyType = property.PropertyType;
			if (color_0 == color_1)
			{
				if (property.GetValue(object_0, null) != null)
				{
					property.SetValue(object_0, null, null);
					result = true;
				}
			}
			else
			{
				Type[] genericArguments = propertyType.GetGenericArguments();
				Type type = genericArguments[0];
				object obj = Activator.CreateInstance(type);
				type.GetProperty("A").SetValue(obj, color_0.A, null);
				type.GetProperty("R").SetValue(obj, color_0.R, null);
				type.GetProperty("G").SetValue(obj, color_0.G, null);
				type.GetProperty("B").SetValue(obj, color_0.B, null);
				if (property.GetValue(object_0, null) != obj)
				{
					property.SetValue(object_0, obj, null);
					result = true;
				}
			}
			return result;
		}
	}
}
