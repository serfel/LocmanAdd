using System;

namespace TX_Text_Control_Words.FileHandling
{
	public class DocumentDirtyChangedEventArgs : EventArgs
	{
		public bool NewValue { get; private set; }

		public DocumentDirtyChangedEventArgs(bool newValue)
		{
			this.NewValue = newValue;
		}
	}
}
