using System;
using System.Drawing;
using System.Runtime.InteropServices;
using ns21;
using TXTextControl;
using TXTextControl.DataVisualization;

namespace ns20
{
	internal class Control4 : ControlList
	{
		internal Control4(TextControlCore textControlCore_0)
			: base(textControlCore_0)
		{
		}

		internal override ControlProxy CreateControlProxy(object control)
		{
			if (control != null && control.GetType().FullName != "TXTextControl.Barcode.TXBarcodeControl" && control.GetType().FullName != "TXTextControl.WPF.Barcode.TXBarcodeControl")
			{
				throw new ArgumentException(base.m_tx.method_1().GetString("ERR_INVALIDBARCODE"));
			}
			Control7 control2 = null;
			switch (base.m_tx.GetTextControl().GetControlType())
			{
			default:
				return new Control7(control);
			case Enum116.const_3:
				try
				{
					return new Control7(control);
				}
				catch
				{
					return new Control8(control, base.m_tx);
				}
			case Enum116.const_4:
				return new Control8(control, base.m_tx);
			}
		}

		internal IntPtr method_0(int int_0, ref Struct66 struct66_0)
		{
			Control7 control = null;
			IntPtr result = IntPtr.Zero;
			try
			{
				control = base[int_0] as Control7;
				if (control != null)
				{
					Color color_ = control.Color_0;
					struct66_0.uint_1 = ((color_ == SystemColors.Window) ? 1073741824u : ((uint)Class429.smethod_0(color_)));
					struct66_0.ushort_3 = color_.A;
					color_ = control.ForeColor;
					struct66_0.uint_0 = ((color_ == SystemColors.WindowText) ? 1073741824u : ((uint)Class429.smethod_0(color_)));
					struct66_0.ushort_5 = (ushort)control.Int32_0;
					struct66_0.ushort_4 = (ushort)control.Int32_2;
					struct66_0.ushort_6 = (ushort)control.Int32_1;
					struct66_0.intptr_0 = Marshal.StringToBSTR(control.Text);
					char[] array = KernelHelper.StringArray2CharArray(control.method_3());
					struct66_0.intptr_1 = Marshal.AllocHGlobal(array.Length * 2);
					Marshal.Copy(array, 0, struct66_0.intptr_1, array.Length);
					result = new IntPtr(1);
					return result;
				}
				return result;
			}
			catch
			{
				return result;
			}
		}

		internal IntPtr method_1(int int_0, ref Struct66 struct66_0)
		{
			Control7 control = null;
			IntPtr result = IntPtr.Zero;
			try
			{
				control = base[int_0] as Control7;
				if (control != null)
				{
					Color color;
					if (struct66_0.uint_1 == 1073741824)
					{
						color = SystemColors.Window;
					}
					else
					{
						color = Class429.smethod_2((int)struct66_0.uint_1);
						if (struct66_0.ushort_3 < 255)
						{
							color = Color.FromArgb(struct66_0.ushort_3, color);
						}
					}
					if (control.Color_0 != color)
					{
						control.Color_0 = color;
						result = new IntPtr(1);
					}
					color = ((struct66_0.uint_0 == 1073741824) ? SystemColors.WindowText : Class429.smethod_2((int)struct66_0.uint_0));
					if (control.ForeColor != color)
					{
						control.ForeColor = color;
						result = new IntPtr(1);
					}
					if (control.Int32_0 != struct66_0.ushort_5)
					{
						control.Int32_0 = struct66_0.ushort_5;
						result = new IntPtr(1);
					}
					if (control.Int32_2 != struct66_0.ushort_4)
					{
						control.Int32_2 = struct66_0.ushort_4;
						result = new IntPtr(1);
					}
					if (control.Int32_1 != struct66_0.ushort_6)
					{
						control.Int32_1 = struct66_0.ushort_6;
						result = new IntPtr(1);
					}
					string text = Marshal.PtrToStringUni(struct66_0.intptr_0);
					if (control.Text != text)
					{
						if (text.Length > control.Int32_3)
						{
							control.Int32_3 = text.Length;
						}
						control.Text = text;
						if (text.Length < control.Int32_3)
						{
							control.Int32_3 = text.Length;
						}
						result = new IntPtr(1);
						return result;
					}
					return result;
				}
				return result;
			}
			catch
			{
				return result;
			}
		}

		internal IntPtr method_2(int int_0, ref Struct67 struct67_0)
		{
			Control7 control = null;
			IntPtr result = IntPtr.Zero;
			try
			{
				control = base[int_0] as Control7;
				if (control != null)
				{
					switch (struct67_0.uint_0)
					{
					case 1u:
						struct67_0.intptr_0 = Marshal.StringToBSTR(control.method_1((int)struct67_0.uint_1));
						break;
					case 2u:
					{
						string string_ = Marshal.PtrToStringBSTR(struct67_0.intptr_0);
						if (!control.method_2((int)struct67_0.uint_1, string_, out var string_2))
						{
							Marshal.FreeBSTR(struct67_0.intptr_0);
							struct67_0.intptr_0 = Marshal.StringToBSTR(string_2);
							struct67_0.uint_0 |= 65536u;
						}
						break;
					}
					}
					result = new IntPtr(1);
					return result;
				}
				return result;
			}
			catch
			{
				return result;
			}
		}
	}
}
