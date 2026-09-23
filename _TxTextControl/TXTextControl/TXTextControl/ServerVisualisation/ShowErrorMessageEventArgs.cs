using System;
using System.Runtime.InteropServices;

namespace TXTextControl.ServerVisualisation
{
	public class ShowErrorMessageEventArgs : EventArgs
	{
		private string string_0;

		private string string_1;

		public string ErrorMessage => this.string_0;

		public string Caption => this.string_1;

		internal ShowErrorMessageEventArgs(string strErrorMessage, IntPtr pstrCaption)
		{
			this.string_0 = strErrorMessage;
			this.string_1 = ((pstrCaption == IntPtr.Zero) ? null : Marshal.PtrToStringUni(pstrCaption));
		}
	}
}
