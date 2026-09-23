using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;
using ns21;
using TXTextControl;
using TXTextControl.DataVisualization;

namespace ns20
{
	internal class Control6 : ControlList
	{
		private EventHandler eventHandler_0;

		internal Control6(TextControlCore textControlCore_0)
			: base(textControlCore_0)
		{
			this.eventHandler_0 = method_3;
		}

		internal override ControlProxy CreateControlProxy(object control)
		{
			if (control != null && control.GetType().FullName != "TXTextControl.Drawing.TXDrawingControl" && control.GetType().FullName != "TXTextControl.WPF.Drawing.TXDrawingControl")
			{
				throw new ArgumentException(base.m_tx.method_1().GetString("ERR_INVALIDDRAWING"));
			}
			Control10 control2 = null;
			switch (base.m_tx.GetTextControl().GetControlType())
			{
			default:
				control2 = new Control10(control);
				break;
			case Enum116.const_3:
				try
				{
					control2 = new Control10(control);
				}
				catch
				{
					control2 = new Control11(control, base.m_tx);
				}
				break;
			case Enum116.const_4:
				control2 = new Control11(control, base.m_tx);
				break;
			}
			control2.method_14(this.eventHandler_0);
			return control2;
		}

		internal IntPtr method_0(int int_0, int zoomFactor)
		{
			IntPtr result = IntPtr.Zero;
			try
			{
				Control10 control = base[int_0] as Control10;
				if (control != null)
				{
					control.ZoomFactor = zoomFactor;
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

		internal IntPtr method_1(int int_0, IntPtr intptr_0)
		{
			IntPtr result = IntPtr.Zero;
			try
			{
				Control10 control = base[int_0] as Control10;
				if (control != null)
				{
					int[] array = control.SizeToContent();
					for (int i = 0; i < 4; i++)
					{
						Marshal.WriteInt32(intptr_0, i * 4, array[i]);
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

		internal IntPtr method_2(int int_0, IntPtr intptr_0)
		{
			IntPtr result = IntPtr.Zero;
			try
			{
				Control10 control = base[int_0] as Control10;
				if (control != null)
				{
					int num = Marshal.ReadInt32(intptr_0);
					int num2 = Marshal.ReadInt32(intptr_0, 4);
					control.SetCanvasSize(num, num2);
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

		private void method_3(object sender, EventArgs e)
		{
			foreach (KeyValuePair<int, ControlProxy> item in this)
			{
				if (item.Value.Component.Equals(sender))
				{
					Control10 control = item.Value as Control10;
					if (control != null)
					{
						DrawingFrame drawingFrame = new DrawingFrame(base.m_tx, TextPart.Auto, item.Key, control.Component);
						int[] array = control.SizeToContent();
						Size size = drawingFrame.Size;
						drawingFrame.Size = new Size(size.Width - array[0] + array[2], size.Height - array[1] + array[3]);
					}
				}
			}
		}

		internal IntPtr method_4(int int_0, ref Struct66 struct66_0)
		{
			Control10 control = null;
			IntPtr result = IntPtr.Zero;
			Marshal.SizeOf((object)struct66_0);
			try
			{
				control = base[int_0] as Control10;
				if (control != null)
				{
					if (control.IsCanvasVisible)
					{
						Color color_ = control.BackColor;
						struct66_0.uint_1 = ((color_ == SystemColors.Window) ? 1073741824u : ((uint)Class429.smethod_0(color_)));
						struct66_0.ushort_3 = color_.A;
						color_ = control.BorderColor;
						struct66_0.uint_2 = ((color_ == SystemColors.WindowText) ? 1073741824u : ((uint)Class429.smethod_0(color_)));
						struct66_0.ushort_7 = (ushort)control.BorderWidth;
						struct66_0.ushort_6 = ushort.MaxValue;
						struct66_0.ushort_8 = ushort.MaxValue;
					}
					else
					{
						Color color_ = control.vmethod_0();
						struct66_0.uint_1 = ((color_ == SystemColors.Window) ? 1073741824u : ((uint)Class429.smethod_0(color_)));
						struct66_0.ushort_3 = color_.A;
						color_ = control.vmethod_2();
						struct66_0.uint_2 = ((color_ == SystemColors.WindowText) ? 1073741824u : ((uint)Class429.smethod_0(color_)));
						struct66_0.ushort_7 = (ushort)control.method_5();
						struct66_0.ushort_6 = (ushort)control.method_7();
						struct66_0.ushort_8 = (ushort)control.method_9();
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

		internal IntPtr method_5(int int_0, ref Struct66 struct66_0)
		{
			Control10 control = null;
			IntPtr result = IntPtr.Zero;
			IntPtr intPtr = new IntPtr(1);
			try
			{
				control = base[int_0] as Control10;
				if (control != null)
				{
					Color color;
					if (control.IsCanvasVisible)
					{
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
						control.BackColor = color;
						control.BorderColor = ((struct66_0.uint_2 == 1073741824) ? SystemColors.WindowText : Class429.smethod_2((int)struct66_0.uint_2));
						control.BorderWidth = struct66_0.ushort_7;
						result = intPtr;
						return result;
					}
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
					if (control.vmethod_1(color))
					{
						result = intPtr;
					}
					color = ((struct66_0.uint_2 == 1073741824) ? SystemColors.WindowText : Class429.smethod_2((int)struct66_0.uint_2));
					if (control.vmethod_3(color))
					{
						result = intPtr;
					}
					if (control.method_6(struct66_0.ushort_7))
					{
						result = intPtr;
					}
					if (control.method_8(struct66_0.ushort_6))
					{
						result = intPtr;
					}
					if (control.method_10(struct66_0.ushort_8))
					{
						result = intPtr;
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
	}
}
