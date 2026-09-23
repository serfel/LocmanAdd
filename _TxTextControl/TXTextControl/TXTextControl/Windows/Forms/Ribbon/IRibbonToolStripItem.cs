using System.Drawing;

namespace TXTextControl.Windows.Forms.Ribbon
{
	internal interface IRibbonToolStripItem
	{
		RibbonTab RibbonTab { get; }

		bool IsToolStripItemAdded { get; set; }

		object Parent { get; }

		PointF DPI { get; set; }
	}
}
