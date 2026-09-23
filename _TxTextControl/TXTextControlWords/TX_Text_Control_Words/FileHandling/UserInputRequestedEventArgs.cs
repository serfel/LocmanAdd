using System;

namespace TX_Text_Control_Words.FileHandling
{
	public class UserInputRequestedEventArgs : EventArgs
	{
		public string Value { get; set; }

		public string Caption { get; private set; }

		public string Label { get; private set; }

		public bool IsPasswordRequest { get; private set; }

		public UserInputRequestReason Reason { get; private set; }

		public DialogResult DialogResult { get; set; }

		public UserInputRequestedEventArgs(string current, string caption, string label, bool isPasswordRequest = false, UserInputRequestReason reason = UserInputRequestReason.Unknown)
		{
			this.Value = current;
			this.Caption = caption;
			this.Label = label;
			this.IsPasswordRequest = isPasswordRequest;
			this.DialogResult = DialogResult.Cancel;
		}
	}
}
