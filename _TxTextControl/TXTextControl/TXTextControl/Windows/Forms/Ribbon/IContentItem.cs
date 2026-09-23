namespace TXTextControl.Windows.Forms.Ribbon
{
	internal interface IContentItem
	{
		IRibbonItem Original { get; set; }

		RibbonToolTip ToolTip { get; }
	}
}
