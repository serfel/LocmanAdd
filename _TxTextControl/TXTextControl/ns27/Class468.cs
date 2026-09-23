using System;
using System.Drawing;
using System.Windows.Forms;
using ns21;

namespace ns27
{
	internal class Class468
	{
		internal static uint smethod_0(Graphics graphics_0, Control control_0)
		{
			uint num = Class429.smethod_15(control_0.Handle);
			if (num != 0)
			{
				if (control_0.Font.IsSystemFont)
				{
					control_0.Font = Class467.smethod_2(num);
				}
				else
				{
					Class468.smethod_2(num, graphics_0, control_0);
				}
			}
			return num;
		}

		internal static void smethod_1(uint uint_0, Class429.Struct83 struct83_0, Form form_0)
		{
			Control control = form_0.Controls[0];
			Size preferredSize = control.PreferredSize;
			struct83_0.int_2 = struct83_0.int_0 + preferredSize.Width + form_0.Padding.Left + form_0.Padding.Right;
			struct83_0.int_3 = struct83_0.int_1 + preferredSize.Height + form_0.Padding.Top + form_0.Padding.Bottom;
			Class429.smethod_13(form_0.Handle, ref struct83_0, bool_0: false, uint_0);
			Class429.SetWindowPos(form_0.Handle, IntPtr.Zero, struct83_0.int_0, struct83_0.int_1, struct83_0.int_2 - struct83_0.int_0, struct83_0.int_3 - struct83_0.int_1, 20u);
		}

		internal static bool smethod_2(uint uint_0, Graphics graphics_0, Control control_0)
		{
			bool result = false;
			if (uint_0 != 0)
			{
				Graphics graphics = ((graphics_0 == null) ? control_0.CreateGraphics() : graphics_0);
				bool flag = false;
				if (((float)uint_0 != graphics.DpiX && control_0.Font.Unit != GraphicsUnit.Pixel) || (flag = uint_0 != 96 && control_0.Font.Unit == GraphicsUnit.Pixel))
				{
					control_0.Font = new Font(control_0.Font.Name, control_0.Font.Size * (float)uint_0 / (flag ? 96f : graphics.DpiX), control_0.Font.Style, control_0.Font.Unit);
					result = true;
				}
				if (graphics_0 == null)
				{
					graphics.Dispose();
				}
			}
			return result;
		}
	}
}
