using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using ns21;

namespace TXTextControl.ServerVisualisation
{
	public class DialogViewGenerator : Component
	{
		private delegate IntPtr Delegate13(IntPtr intptr_0, int int_0, IntPtr intptr_1, IntPtr intptr_2);

		internal IntPtr intptr_0 = IntPtr.Zero;

		private IntPtr intptr_1 = IntPtr.Zero;

		private CaretStateEventArgs caretStateEventArgs_0;

		private Delegate13 m_WndProc;

		private IntPtr intptr_2 = IntPtr.Zero;

		private Enum83 enum83_0;

		private bool bool_0;

		private ActivationState activationState_0 = ActivationState.Deactivated;

		private UserInput userInput_0 = new UserInput(bIsDialog: true);

		private View view_0 = new View(typeof(DialogViewGenerator));

		private EventHandler eventHandler_0;

		private CaretStateEventHandler caretStateEventHandler_0;

		private ShowErrorMessageEventHandler showErrorMessageEventHandler_0;

		private ShowDialogBoxEventHandler showDialogBoxEventHandler_0;

		[DefaultValue(ActivationState.Deactivated)]
		[Browsable(false)]
		public ActivationState ActivationState
		{
			get
			{
				return this.activationState_0;
			}
			set
			{
				if (this.activationState_0 == value)
				{
					return;
				}
				this.activationState_0 = value;
				if (this.intptr_0 != IntPtr.Zero)
				{
					this.intptr_1 = Class429.SendMessage_32(this.intptr_0, 2071, (uint)this.activationState_0, this.intptr_1);
					this.view_0.method_1(Enum84.const_78, 0u);
					if (this.caretStateEventArgs_0 != null && this.caretStateEventArgs_0.method_0())
					{
						this.OnCaretStateChanged(this.caretStateEventArgs_0);
					}
				}
			}
		}

		[Browsable(false)]
		public string Caption
		{
			get
			{
				if (this.intptr_0 != IntPtr.Zero)
				{
					StringBuilder stringBuilder = new StringBuilder(Class429.GetWindowTextLength(this.intptr_0) + 1);
					Class429.GetWindowText(this.intptr_0, stringBuilder, stringBuilder.Capacity);
					return stringBuilder.ToString();
				}
				return string.Empty;
			}
		}

		[Browsable(false)]
		public UserInput UserInput => this.userInput_0;

		[Browsable(false)]
		public View View => this.view_0;

		public event EventHandler Closed
		{
			add
			{
				EventHandler eventHandler = this.eventHandler_0;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange(ref this.eventHandler_0, value2, eventHandler2);
				}
				while ((object)eventHandler != eventHandler2);
			}
			remove
			{
				EventHandler eventHandler = this.eventHandler_0;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange(ref this.eventHandler_0, value2, eventHandler2);
				}
				while ((object)eventHandler != eventHandler2);
			}
		}

		public event CaretStateEventHandler CaretStateChanged
		{
			add
			{
				CaretStateEventHandler caretStateEventHandler = this.caretStateEventHandler_0;
				CaretStateEventHandler caretStateEventHandler2;
				do
				{
					caretStateEventHandler2 = caretStateEventHandler;
					CaretStateEventHandler value2 = (CaretStateEventHandler)Delegate.Combine(caretStateEventHandler2, value);
					caretStateEventHandler = Interlocked.CompareExchange(ref this.caretStateEventHandler_0, value2, caretStateEventHandler2);
				}
				while ((object)caretStateEventHandler != caretStateEventHandler2);
			}
			remove
			{
				CaretStateEventHandler caretStateEventHandler = this.caretStateEventHandler_0;
				CaretStateEventHandler caretStateEventHandler2;
				do
				{
					caretStateEventHandler2 = caretStateEventHandler;
					CaretStateEventHandler value2 = (CaretStateEventHandler)Delegate.Remove(caretStateEventHandler2, value);
					caretStateEventHandler = Interlocked.CompareExchange(ref this.caretStateEventHandler_0, value2, caretStateEventHandler2);
				}
				while ((object)caretStateEventHandler != caretStateEventHandler2);
			}
		}

		public event ShowErrorMessageEventHandler ShowErrorMessage
		{
			add
			{
				ShowErrorMessageEventHandler showErrorMessageEventHandler = this.showErrorMessageEventHandler_0;
				ShowErrorMessageEventHandler showErrorMessageEventHandler2;
				do
				{
					showErrorMessageEventHandler2 = showErrorMessageEventHandler;
					ShowErrorMessageEventHandler value2 = (ShowErrorMessageEventHandler)Delegate.Combine(showErrorMessageEventHandler2, value);
					showErrorMessageEventHandler = Interlocked.CompareExchange(ref this.showErrorMessageEventHandler_0, value2, showErrorMessageEventHandler2);
				}
				while ((object)showErrorMessageEventHandler != showErrorMessageEventHandler2);
			}
			remove
			{
				ShowErrorMessageEventHandler showErrorMessageEventHandler = this.showErrorMessageEventHandler_0;
				ShowErrorMessageEventHandler showErrorMessageEventHandler2;
				do
				{
					showErrorMessageEventHandler2 = showErrorMessageEventHandler;
					ShowErrorMessageEventHandler value2 = (ShowErrorMessageEventHandler)Delegate.Remove(showErrorMessageEventHandler2, value);
					showErrorMessageEventHandler = Interlocked.CompareExchange(ref this.showErrorMessageEventHandler_0, value2, showErrorMessageEventHandler2);
				}
				while ((object)showErrorMessageEventHandler != showErrorMessageEventHandler2);
			}
		}

		public event ShowDialogBoxEventHandler ShowDialogBox
		{
			add
			{
				ShowDialogBoxEventHandler showDialogBoxEventHandler = this.showDialogBoxEventHandler_0;
				ShowDialogBoxEventHandler showDialogBoxEventHandler2;
				do
				{
					showDialogBoxEventHandler2 = showDialogBoxEventHandler;
					ShowDialogBoxEventHandler value2 = (ShowDialogBoxEventHandler)Delegate.Combine(showDialogBoxEventHandler2, value);
					showDialogBoxEventHandler = Interlocked.CompareExchange(ref this.showDialogBoxEventHandler_0, value2, showDialogBoxEventHandler2);
				}
				while ((object)showDialogBoxEventHandler != showDialogBoxEventHandler2);
			}
			remove
			{
				ShowDialogBoxEventHandler showDialogBoxEventHandler = this.showDialogBoxEventHandler_0;
				ShowDialogBoxEventHandler showDialogBoxEventHandler2;
				do
				{
					showDialogBoxEventHandler2 = showDialogBoxEventHandler;
					ShowDialogBoxEventHandler value2 = (ShowDialogBoxEventHandler)Delegate.Remove(showDialogBoxEventHandler2, value);
					showDialogBoxEventHandler = Interlocked.CompareExchange(ref this.showDialogBoxEventHandler_0, value2, showDialogBoxEventHandler2);
				}
				while ((object)showDialogBoxEventHandler != showDialogBoxEventHandler2);
			}
		}

		internal DialogViewGenerator()
		{
		}

		internal bool method_0(TextControlCore textControlCore_0, TextPart textPart_0, Enum83 enum83_1, ushort ushort_0, int int_0)
		{
			bool result = false;
			if (this.intptr_0 != IntPtr.Zero && enum83_1 == this.enum83_0)
			{
				result = true;
			}
			else if (this.intptr_0 == IntPtr.Zero)
			{
				result = this.method_1(textControlCore_0.method_64(textPart_0, enum83_1, (uint)Class429.smethod_3(ushort_0, 1), int_0));
				this.enum83_0 = enum83_1;
			}
			return result;
		}

		internal bool method_1(IntPtr intptr_3)
		{
			bool result = false;
			if (this.intptr_0 == IntPtr.Zero && intptr_3 != IntPtr.Zero)
			{
				this.intptr_0 = intptr_3;
				this.intptr_1 = Class429.SendMessage_30(this.intptr_0, 2071, 4u, 0);
				this.m_WndProc = method_2;
				this.intptr_2 = Class429.smethod_11(this.intptr_0, -4);
				Class429.smethod_12(this.intptr_0, -4, Marshal.GetFunctionPointerForDelegate((Delegate)this.m_WndProc));
				this.userInput_0.method_0(this.intptr_0);
				this.view_0.method_0(this.intptr_0);
				this.caretStateEventArgs_0 = new CaretStateEventArgs(this.intptr_0);
				result = true;
			}
			return result;
		}

		protected override void Dispose(bool disposing)
		{
			if (this.intptr_0 != IntPtr.Zero)
			{
				this.bool_0 = true;
				Class429.SendMessage_1(this.intptr_0, 273, Class429.smethod_3(2, 0), 0);
				this.bool_0 = false;
			}
			this.activationState_0 = ActivationState.Deactivated;
			base.Dispose(disposing);
		}

		private IntPtr method_2(IntPtr intptr_3, int int_0, IntPtr intptr_4, IntPtr intptr_5)
		{
			IntPtr result = Class429.CallWindowProc(this.intptr_2, intptr_3, int_0, intptr_4, intptr_5);
			switch (int_0)
			{
			case 2:
				this.intptr_0 = IntPtr.Zero;
				this.userInput_0.method_0(this.intptr_0);
				this.view_0.method_0(this.intptr_0);
				this.caretStateEventArgs_0 = null;
				if (!this.bool_0)
				{
					base.Dispose();
					this.OnClosed(EventArgs.Empty);
				}
				break;
			case 2068:
			case 2127:
				if (result.ToInt32() == 1)
				{
					this.view_0.method_1(Enum84.const_78, 0u);
				}
				break;
			case 2124:
				this.OnShowDialogBox(new ShowDialogBoxEventArgs(intptr_5));
				break;
			case 2062:
			case 2066:
			case 2067:
			case 2072:
				this.view_0.method_1(Enum84.const_78, 0u);
				if (this.caretStateEventArgs_0 != null && this.caretStateEventArgs_0.method_0())
				{
					this.OnCaretStateChanged(this.caretStateEventArgs_0);
				}
				break;
			case 2073:
				this.OnShowErrorMessage(new ShowErrorMessageEventArgs(Marshal.PtrToStringUni(intptr_5), intptr_4));
				break;
			}
			return result;
		}

		protected virtual void OnClosed(EventArgs eventArgs_0)
		{
			if (this.eventHandler_0 != null)
			{
				this.eventHandler_0(this, eventArgs_0);
			}
		}

		protected virtual void OnCaretStateChanged(CaretStateEventArgs caretStateEventArgs_1)
		{
			if (this.caretStateEventHandler_0 != null)
			{
				this.caretStateEventHandler_0(this, caretStateEventArgs_1);
			}
		}

		protected virtual void OnShowErrorMessage(ShowErrorMessageEventArgs showErrorMessageEventArgs_0)
		{
			if (this.showErrorMessageEventHandler_0 != null)
			{
				this.showErrorMessageEventHandler_0(this, showErrorMessageEventArgs_0);
			}
		}

		protected virtual void OnShowDialogBox(ShowDialogBoxEventArgs showDialogBoxEventArgs_0)
		{
			if (this.showDialogBoxEventHandler_0 != null)
			{
				this.showDialogBoxEventHandler_0(this, showDialogBoxEventArgs_0);
			}
		}
	}
}
