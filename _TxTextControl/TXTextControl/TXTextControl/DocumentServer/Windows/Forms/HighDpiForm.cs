using System;
using System.ComponentModel;
using System.Drawing;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using ns3;
using DocumentServer.HighDpi;
using DocumentServer.Win32;

namespace DocumentServer.Windows.Forms
{
	[EditorBrowsable(EditorBrowsableState.Never)]
	public class HighDpiForm : Form
	{
		private uint uint_0;

		[Obfuscation(Exclude = true)]
		protected override void OnHandleCreated(EventArgs eventArgs_0)
		{
			this.uint_0 = DocumentServer.Win32.HighDpi.GetDpiForWindow(base.Handle);
			this.method_0();
			this.method_1((IntPtr)0);
			base.OnHandleCreated(eventArgs_0);
		}

		[Obfuscation(Exclude = true)]
		protected override void WndProc(ref Message message)
		{
			if (message.Msg == 736)
			{
				uint num = Class96.smethod_0(message.WParam.ToInt32());
				if (num != this.uint_0)
				{
					this.Font = new Font(this.Font.Name, this.Font.Size * (float)num / (float)this.uint_0, this.Font.Style, this.Font.Unit);
					this.uint_0 = num;
					this.method_1(message.LParam);
				}
			}
			else
			{
				base.WndProc(ref message);
			}
		}

		private void method_0()
		{
			if (this.uint_0 == 0)
			{
				return;
			}
			if (this.Font.IsSystemFont)
			{
				this.Font = DocumentServer.HighDpi.SystemFonts.GetMessageBoxFont(this.uint_0);
				return;
			}
			using Graphics graphics = base.CreateGraphics();
			bool flag = this.uint_0 != 96 && this.Font.Unit == GraphicsUnit.Pixel;
			if (((float)this.uint_0 != graphics.DpiX && this.Font.Unit != GraphicsUnit.Pixel) || flag)
			{
				this.Font = new Font(this.Font.Name, this.Font.Size * (float)this.uint_0 / (flag ? 96f : graphics.DpiX), this.Font.Style, this.Font.Unit);
			}
		}

		private void method_1(IntPtr intptr_0 = default(IntPtr))
		{
			Struct27 struct27_;
			if (intptr_0 == IntPtr.Zero)
			{
				struct27_ = default(Struct27);
				Class96.GetWindowRect(base.Handle, ref struct27_);
			}
			else
			{
				struct27_ = (Struct27)Marshal.PtrToStructure(intptr_0, typeof(Struct27));
			}
			Size preferredSize = base.Controls[0].PreferredSize;
			struct27_.int_2 = struct27_.int_0 + preferredSize.Width + base.Padding.Left + base.Padding.Right;
			struct27_.int_3 = struct27_.int_1 + preferredSize.Height + base.Padding.Top + base.Padding.Bottom;
			DocumentServer.Win32.HighDpi.AdjustWindowRect(base.Handle, ref struct27_, bMenu: false, this.uint_0);
			Class96.SetWindowPos(base.Handle, IntPtr.Zero, struct27_.int_0, struct27_.int_1, struct27_.Int32_0, struct27_.Int32_1, 20u);
		}
	}
}
