using System;

namespace TX_Text_Control_Words.FileHandling
{
	public class DocumentFileNameChangedEventArgs : EventArgs
	{
		public string NewName { get; private set; }

		public DocumentFileNameChangedEventArgs(string newName)
		{
			this.NewName = newName;
		}
	}
}
