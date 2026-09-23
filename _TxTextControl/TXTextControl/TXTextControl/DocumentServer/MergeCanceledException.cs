using System;
using DocumentServer.Properties;

namespace TXTextControl.DocumentServer
{
	/// <summary>A MergeCanceledException is thrown through the Merge method when the current merge process was canceled through the DataRowMergedEventArgs.Cancel property.</summary>
	public class MergeCanceledException : Exception
	{
		public MergeCanceledException()
			: base(Resources.EXC_MAILMERGE_MERGE_CANCELED)
		{
		}
	}
}
