using System;
using System.Drawing;
using ns21;

namespace TXTextControl.ServerVisualisation
{
	[Serializable]
	public class UserInput : MarshalByRefObject
	{
		[Serializable]
		public enum MouseButtons
		{
			None = 0,
			Left = 1,
			Right = 2,
			Middle = 0x10,
			XButton1 = 0x20,
			XButton2 = 0x40
		}

		[Serializable]
		public enum ModifierKeys
		{
			None = 0,
			Shift = 4,
			Control = 8,
			Alt = 0x800
		}

		private bool bool_0;

		private IntPtr intptr_0 = IntPtr.Zero;

		internal UserInput(bool bIsDialog)
		{
			this.bool_0 = bIsDialog;
		}

		internal void method_0(IntPtr intptr_1)
		{
			this.intptr_0 = intptr_1;
		}

		public bool SendMouseDown(Point viewLocation, MouseButtons button, ModifierKeys modifierKeys)
		{
			bool result = false;
			if (this.intptr_0 != IntPtr.Zero)
			{
				if ((button & MouseButtons.Left) != 0)
				{
					this.method_1(this.intptr_0, 2067, (int)button | (int)modifierKeys, Class429.smethod_3(viewLocation.X, viewLocation.Y));
					result = true;
				}
				else if ((button & MouseButtons.Right) != 0)
				{
					this.method_1(this.intptr_0, 2070, (int)button | (int)modifierKeys, Class429.smethod_3(viewLocation.X, viewLocation.Y));
					result = true;
				}
			}
			return result;
		}

		public bool SendMouseMove(Point viewLocation, MouseButtons button, ModifierKeys modifierKeys)
		{
			bool result = false;
			if (this.intptr_0 != IntPtr.Zero)
			{
				this.method_1(this.intptr_0, 2068, (int)button | (int)modifierKeys, Class429.smethod_3(viewLocation.X, viewLocation.Y));
				result = true;
			}
			return result;
		}

		public bool SendMouseUp(Point viewLocation, MouseButtons button, ModifierKeys modifierKeys)
		{
			bool result = false;
			if (this.intptr_0 != IntPtr.Zero)
			{
				if ((button & MouseButtons.Left) != 0)
				{
					this.method_1(this.intptr_0, 2066, (int)button | (int)modifierKeys, Class429.smethod_3(viewLocation.X, viewLocation.Y));
					result = true;
				}
				else if ((button & MouseButtons.Right) != 0)
				{
					this.method_1(this.intptr_0, 2069, (int)button | (int)modifierKeys, Class429.smethod_3(viewLocation.X, viewLocation.Y));
					result = true;
				}
			}
			return result;
		}

		public bool SendMouseDoubleClick(Point viewLocation, MouseButtons button, ModifierKeys modifierKeys)
		{
			bool result = false;
			if (this.intptr_0 != IntPtr.Zero)
			{
				if ((button & MouseButtons.Left) != 0)
				{
					this.method_1(this.intptr_0, 2125, (int)button | (int)modifierKeys, Class429.smethod_3(viewLocation.X, viewLocation.Y));
					result = true;
				}
				else if ((button & MouseButtons.Right) != 0)
				{
					this.method_1(this.intptr_0, 2126, (int)button | (int)modifierKeys, Class429.smethod_3(viewLocation.X, viewLocation.Y));
					result = true;
				}
			}
			return result;
		}

		public bool SendMouseWheel(Point viewLocation, int delta, MouseButtons button, ModifierKeys modifierKeys)
		{
			bool result = false;
			if (this.intptr_0 != IntPtr.Zero)
			{
				this.method_1(this.intptr_0, 2127, Class429.smethod_3((int)button | (int)modifierKeys, delta), Class429.smethod_3(viewLocation.X, viewLocation.Y));
			}
			return result;
		}

		public bool SendKeyDown(int keyCode, ModifierKeys modifierKeys)
		{
			bool result = false;
			if (this.intptr_0 != IntPtr.Zero)
			{
				this.method_1(this.intptr_0, 2062, keyCode, (int)modifierKeys);
			}
			return result;
		}

		public bool SendKeyPress(int keyChar, ModifierKeys modifierKeys)
		{
			bool result = false;
			if (this.intptr_0 != IntPtr.Zero)
			{
				this.method_1(this.intptr_0, 2063, keyChar, (int)modifierKeys);
			}
			return result;
		}

		public bool SendKeyUp(int keyCode, ModifierKeys modifierKeys)
		{
			bool result = false;
			if (this.intptr_0 != IntPtr.Zero)
			{
				this.method_1(this.intptr_0, 2072, keyCode, (int)modifierKeys);
			}
			return result;
		}

		private int method_1(IntPtr intptr_1, int int_0, int int_1, int int_2)
		{
			return Class429.SendMessage_1(intptr_1, int_0, int_1, int_2);
		}
	}
}
