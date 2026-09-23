using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace ns16
{
	internal sealed class Class157
	{
		private const int int_0 = 1024;

		private Class157()
		{
		}

		public static bool smethod_0(ref Message message_0)
		{
			if (message_0.Msg == 274)
			{
				return ((int)message_0.WParam & 0xFFF0) == 61824;
			}
			return false;
		}

		public static bool smethod_1()
		{
			bool bool_ = false;
			if (Environment.OSVersion.Version.Major >= 5)
			{
				Process currentProcess = Process.GetCurrentProcess();
				try
				{
					Class159.IsWow64Process(currentProcess.Handle, out bool_);
					return bool_;
				}
				catch (Exception)
				{
					return false;
				}
			}
			return bool_;
		}

		public static string[] smethod_2(string string_0, int int_1)
		{
			UIntPtr uintptr_ = UIntPtr.Zero;
			int num = 0;
			string[] array = null;
			try
			{
				num = Class159.RegOpenKeyEx(Class159.uintptr_0, string_0, 0, int_1, out uintptr_);
			}
			catch
			{
			}
			if (num == 0 && !object.Equals(uintptr_, UIntPtr.Zero))
			{
				uint uint_ = 0u;
				try
				{
					num = Class159.RegQueryInfoKey(uintptr_, null, IntPtr.Zero, IntPtr.Zero, out var _, IntPtr.Zero, IntPtr.Zero, out uint_, IntPtr.Zero, IntPtr.Zero, IntPtr.Zero, IntPtr.Zero);
				}
				catch
				{
				}
				if (num == 0)
				{
					array = new string[uint_];
					for (uint num2 = 0u; num2 < uint_; num2++)
					{
						StringBuilder stringBuilder = new StringBuilder(1024);
						uint uint_3 = 1024u;
						try
						{
							num = Class159.RegEnumValue(uintptr_, num2, stringBuilder, ref uint_3, IntPtr.Zero, IntPtr.Zero, IntPtr.Zero, IntPtr.Zero);
						}
						catch
						{
						}
						if (num == 0)
						{
							array[num2] = stringBuilder.ToString();
						}
					}
				}
			}
			if (array != null)
			{
				return array;
			}
			return new string[0];
		}

		public static void smethod_3(Form form_0, ref Message message_0)
		{
			Control control = Class157.smethod_4(form_0);
			if (control != null)
			{
				message_0.HWnd = control.Handle;
				message_0.Msg = 83;
				message_0.WParam = IntPtr.Zero;
				Class159.Class160 @class = new Class159.Class160();
				@class.int_1 = 1;
				@class.int_2 = form_0.Handle.ToInt32();
				@class.intptr_0 = control.Handle;
				@class.int_3 = 0;
				@class.struct29_0.int_0 = Class159.smethod_1((int)message_0.LParam);
				@class.struct29_0.int_1 = Class159.smethod_2((int)message_0.LParam);
				message_0.LParam = Marshal.AllocHGlobal(Marshal.SizeOf((object)@class));
				Marshal.StructureToPtr((object)@class, message_0.LParam, fDeleteOld: false);
			}
		}

		public static Control smethod_4(Form form_0)
		{
			Control control = form_0;
			ContainerControl containerControl = null;
			while ((containerControl = control as ContainerControl) != null && containerControl.ActiveControl != null)
			{
				control = containerControl.ActiveControl;
			}
			return control;
		}
	}
}
