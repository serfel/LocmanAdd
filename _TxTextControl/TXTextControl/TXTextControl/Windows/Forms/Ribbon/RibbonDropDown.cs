using System;
using System.ComponentModel;
using System.Drawing;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using ns21;

namespace TXTextControl.Windows.Forms.Ribbon
{
	[ToolboxItem(false)]
	public class RibbonDropDown : ToolStripDropDownMenu
	{
		private delegate IntPtr Delegate15(IntPtr intptr_0, int int_0, IntPtr intptr_1, IntPtr intptr_2);

		internal RibbonDropDown ribbonDropDown_0;

		private Control control_0;

		private MethodInfo methodInfo_0;

		private object object_0;

		private MethodInfo methodInfo_1;

		private object object_1;

		private PropertyInfo propertyInfo_0;

		private string string_0 = string.Empty;

		private bool bool_0;

		private IntPtr intptr_0 = IntPtr.Zero;

		internal uint uint_0;

		private Delegate15 m_KeyTipWndProc;

		private IntPtr intptr_1 = IntPtr.Zero;

		private bool bool_1;

		private bool bool_2;

		protected override Padding DefaultPadding => new Padding(2);

		public RibbonDropDown Owner
		{
			get
			{
				return this.ribbonDropDown_0;
			}
			set
			{
				this.ribbonDropDown_0 = value;
			}
		}

		internal bool Boolean_0
		{
			get
			{
				return this.bool_1;
			}
			set
			{
				this.bool_1 = value;
			}
		}

		internal bool Boolean_1
		{
			get
			{
				return this.bool_2;
			}
			set
			{
				if (this.bool_2 != value)
				{
					this.bool_2 = value;
					base.AutoClose = this.bool_2;
				}
			}
		}

		internal RibbonDropDown()
			: this(null)
		{
		}

		internal RibbonDropDown(RibbonDropDown owner)
		{
			base.AutoClose = false;
			base.ShowImageMargin = false;
			base.ShowCheckMargin = false;
			this.ribbonDropDown_0 = owner;
			this.methodInfo_0 = this.method_4("UpScrollButton", out this.object_0);
			this.methodInfo_1 = this.method_4("DownScrollButton", out this.object_1);
			this.propertyInfo_0 = typeof(ToolStripDropDownMenu).GetProperty("RequiresScrollButtons", BindingFlags.Instance | BindingFlags.NonPublic);
		}

		protected override void SetVisibleCore(bool visible)
		{
			if (!visible)
			{
				if (this.intptr_0 != IntPtr.Zero)
				{
					Class429.DestroyWindow(this.intptr_0);
					this.intptr_0 = IntPtr.Zero;
				}
				if (!this.bool_0)
				{
					this.bool_1 = false;
					this.string_0 = string.Empty;
				}
			}
			base.SetVisibleCore(visible);
			if (visible && !base.AutoClose)
			{
				Class429.PostMessage(base.Handle, 6, 2, 0);
			}
			if (!visible)
			{
				this.control_0 = null;
				this.bool_1 = false;
				this.string_0 = string.Empty;
			}
			if (visible && this.bool_1 && this.intptr_0 == IntPtr.Zero)
			{
				this.intptr_0 = Class429.CreateWindowEx(0u, "STATIC", "", 1342177280u, 10, 10, 10, 10, base.Handle, IntPtr.Zero, IntPtr.Zero, IntPtr.Zero);
				this.m_KeyTipWndProc = method_3;
				this.intptr_1 = Class429.smethod_11(this.intptr_0, -4);
				Class429.smethod_12(this.intptr_0, -4, Marshal.GetFunctionPointerForDelegate((Delegate)this.m_KeyTipWndProc));
			}
		}

		protected override void OnMouseWheel(MouseEventArgs mouseEventArgs_0)
		{
			if ((bool)this.propertyInfo_0.GetValue(this, null))
			{
				if (mouseEventArgs_0.Delta > 0)
				{
					if (this.methodInfo_0 != null && this.object_0 != null)
					{
						this.methodInfo_0.Invoke(this.object_0, null);
					}
				}
				else if (this.methodInfo_1 != null && this.object_1 != null)
				{
					this.methodInfo_1.Invoke(this.object_1, null);
				}
			}
			base.OnMouseWheel(mouseEventArgs_0);
		}

		protected override bool IsInputKey(Keys keyData)
		{
			if (keyData == Keys.Escape)
			{
				return true;
			}
			return base.IsInputKey(keyData);
		}

		protected override bool ProcessDialogKey(Keys keyData)
		{
			if ((keyData & (Keys.Control | Keys.Alt)) == 0)
			{
				Keys keys = keyData & Keys.KeyCode;
				switch (keys)
				{
				case Keys.Left:
				case Keys.Up:
				case Keys.Right:
				case Keys.Down:
					if (keys == Keys.Down && this.control_0 == null)
					{
						this.control_0 = this.method_0(this.control_0, bool_3: true, bool_4: true, bool_5: true, bool_6: true);
					}
					else
					{
						this.control_0 = this.method_0(this.control_0, keys == Keys.Right || keys == Keys.Down, bool_4: false, bool_5: false, bool_6: true);
					}
					if (this.control_0 != null)
					{
						this.method_2();
						return true;
					}
					break;
				case Keys.Tab:
					this.control_0 = this.method_0(this.control_0, (keyData & Keys.Shift) == 0, bool_4: true, bool_5: true, bool_6: true);
					if (this.control_0 != null)
					{
						this.method_2();
						return true;
					}
					break;
				}
			}
			return base.ProcessDialogKey(keyData);
		}

		private Control method_0(Control control_1, bool bool_3, bool bool_4, bool bool_5, bool bool_6)
		{
			if (this.Items.Count > 0)
			{
				ToolStripControlHost toolStripControlHost = this.Items[0] as ToolStripControlHost;
				if (toolStripControlHost != null)
				{
					Control control = toolStripControlHost.Control;
					Control control2 = control_1?.Parent;
					bool flag = false;
					Control control3 = control_1;
					do
					{
						control_1 = control.GetNextControl(control_1, bool_3);
						if (control_1 != null)
						{
							if (control_1.CanSelect && (!bool_4 || control_1.TabStop) && (bool_5 || control_1.Parent == control2))
							{
								control_1.Focus();
								return control_1;
							}
							continue;
						}
						if (!bool_6)
						{
							break;
						}
						if (!flag)
						{
							flag = true;
							continue;
						}
						return null;
					}
					while (control_1 != control3);
				}
			}
			return null;
		}

		protected override void OnKeyDown(KeyEventArgs keyEventArgs_0)
		{
			if (keyEventArgs_0.KeyCode == Keys.Escape)
			{
				this.bool_0 = true;
				base.Close();
				this.bool_0 = false;
			}
			base.OnKeyDown(keyEventArgs_0);
		}

		protected override void OnKeyPress(KeyPressEventArgs keyPressEventArgs_0)
		{
			if (this.bool_1 && this.Items.Count > 0 && char.IsLetterOrDigit(keyPressEventArgs_0.KeyChar))
			{
				ToolStripControlHost toolStripControlHost = this.Items[0] as ToolStripControlHost;
				if (toolStripControlHost != null)
				{
					Control control = toolStripControlHost.Control;
					if (KeyTipHelper.SelectRibbonItemFromKeyTip(control, keyPressEventArgs_0.KeyChar, ref this.string_0, out var _))
					{
						if (this.string_0 != string.Empty)
						{
							base.Invalidate(invalidateChildren: true);
						}
					}
					else
					{
						Class429.MessageBeep(0);
					}
				}
			}
			base.OnKeyPress(keyPressEventArgs_0);
		}

		protected override void OnGotFocus(EventArgs eventArgs_0)
		{
			if (this.bool_1)
			{
				base.Invalidate(invalidateChildren: true);
			}
			if (this.control_0 != null)
			{
				this.control_0.Focus();
			}
			base.OnGotFocus(eventArgs_0);
		}

		protected override void OnLostFocus(EventArgs eventArgs_0)
		{
			if (this.bool_1)
			{
				base.Invalidate(invalidateChildren: true);
			}
			base.OnLostFocus(eventArgs_0);
		}

		internal void method_1(bool bool_3)
		{
			if (this.Boolean_1)
			{
				base.AutoClose = !bool_3;
			}
		}

		protected override void WndProc(ref Message message)
		{
			switch (message.Msg)
			{
			case 6:
			{
				if (base.AutoClose || !base.Visible)
				{
					break;
				}
				int int_ = message.WParam.ToInt32();
				if (Class429.smethod_5(int_) == 0)
				{
					Control control = null;
					RibbonDropDown ribbonDropDown = null;
					_ = message.LParam;
					control = Control.FromHandle(message.LParam);
					if (control != null)
					{
						ribbonDropDown = control as RibbonDropDown;
					}
					if (ribbonDropDown != null && ribbonDropDown.ribbonDropDown_0 == this)
					{
						break;
					}
					base.Close();
				}
				if (Class429.smethod_5(int_) == 1 || Class429.smethod_5(int_) == 2)
				{
					if (this.Owner != null && this.Owner.Boolean_1)
					{
						this.Owner.AutoClose = false;
					}
					if (this.Boolean_1 && !base.AutoClose)
					{
						base.AutoClose = true;
					}
				}
				break;
			}
			case 1:
				this.uint_0 = Class429.smethod_15(message.HWnd);
				if (this.uint_0 == 0)
				{
					Graphics graphics = Graphics.FromHwnd(message.HWnd);
					this.uint_0 = (uint)graphics.DpiX;
					graphics.Dispose();
				}
				break;
			case 736:
				this.uint_0 = Class429.smethod_5(message.WParam.ToInt32());
				break;
			case 28:
				if (!base.AutoClose && base.Visible && message.WParam.ToInt32() == 0)
				{
					base.Close();
				}
				break;
			}
			base.WndProc(ref message);
		}

		private void method_2()
		{
			if (this.bool_1 && this.Items.Count > 0)
			{
				this.bool_1 = false;
				this.string_0 = string.Empty;
				base.Invalidate(invalidateChildren: true);
			}
		}

		private IntPtr method_3(IntPtr intptr_2, int int_0, IntPtr intptr_3, IntPtr intptr_4)
		{
			IntPtr result = IntPtr.Zero;
			switch (int_0)
			{
			default:
				result = Class429.CallWindowProc(this.intptr_1, intptr_2, int_0, intptr_3, intptr_4);
				break;
			case 133:
				Class429.DefWindowProc(intptr_2, int_0, intptr_3, intptr_4);
				break;
			case 15:
				Class429.DefWindowProc(intptr_2, int_0, intptr_3, intptr_4);
				if (this.bool_1 && this.Items.Count > 0 && this.Focused)
				{
					ToolStripControlHost toolStripControlHost = this.Items[0] as ToolStripControlHost;
					if (toolStripControlHost != null)
					{
						KeyTipHelper.DrawKeyTips(toolStripControlHost.Control, this.string_0, null);
					}
				}
				break;
			}
			return result;
		}

		private MethodInfo method_4(string string_1, out object object_2)
		{
			PropertyInfo property = typeof(ToolStripDropDownMenu).GetProperty(string_1, BindingFlags.Instance | BindingFlags.NonPublic);
			object_2 = null;
			if (property != null)
			{
				object_2 = property.GetValue(this, null);
				return object_2.GetType().GetMethod("Scroll", BindingFlags.Instance | BindingFlags.NonPublic);
			}
			return null;
		}
	}
}
