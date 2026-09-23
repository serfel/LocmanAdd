using System;

namespace TX_Text_Control_Words.FileHandling
{
	public class ShowMessageBoxEventArgs : EventArgs
	{
		public DialogResult DialogResult { get; set; }

		public MessageBoxButton Button { get; private set; }

		public MessageBoxIcon Icon { get; private set; }

		public string Text { get; private set; }

		public string Caption { get; private set; }

		public ShowMessageBoxEventArgs(string text, string caption, MessageBoxButton button, MessageBoxIcon icon)
		{
			this.Text = text;
			this.Caption = caption;
			this.Button = button;
			this.Icon = icon;
			this.DialogResult = DialogResult.Cancel;
		}

		public ShowMessageBoxEventArgs(string text)
			: this(text, null, MessageBoxButton.OK, MessageBoxIcon.None)
		{
		}

		public ShowMessageBoxEventArgs(string text, string caption)
			: this(text, caption, MessageBoxButton.OK, MessageBoxIcon.None)
		{
		}

		public ShowMessageBoxEventArgs(string text, MessageBoxButton button)
			: this(text, null, button, MessageBoxIcon.None)
		{
		}

		public ShowMessageBoxEventArgs(string text, MessageBoxButton button, MessageBoxIcon icon)
			: this(text, null, button, icon)
		{
		}
	}
}
