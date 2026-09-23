using System;

namespace TXTextControl.ServerVisualisation
{
	public class ShowDialogBoxEventArgs : EventArgs
	{
		private DialogViewGenerator dialogViewGenerator_0;

		public DialogViewGenerator DialogBox => this.dialogViewGenerator_0;

		internal ShowDialogBoxEventArgs(IntPtr dialogHandle)
		{
			this.dialogViewGenerator_0 = new DialogViewGenerator();
			this.dialogViewGenerator_0.method_1(dialogHandle);
		}

		internal ShowDialogBoxEventArgs(IntPtr dialogHandle, DialogViewGenerator dialogBox)
		{
			this.dialogViewGenerator_0 = dialogBox;
			this.dialogViewGenerator_0.method_1(dialogHandle);
		}

		internal void method_0()
		{
			this.dialogViewGenerator_0.Dispose();
		}
	}
}
