using System.Windows.Forms;

namespace TXTextControl.Windows.Forms.Ribbon
{
	internal interface IRibbonToolStripItemProvider
	{
		bool IsAddToQuickAccessToolbarEnabled { get; set; }

		bool IsToolStripItemAdded { get; }

		ToolStripItem ToolStripItem { get; set; }
	}
}
