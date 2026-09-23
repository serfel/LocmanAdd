using System.Drawing;

namespace TXTextControl.Windows.Forms.Ribbon
{
	internal interface IRibbonItem
	{
		PointF DPI { get; }

		bool HasSmallIcon { get; set; }

		bool HasLargeIcon { get; set; }

		bool InternalVisible { get; set; }

		RibbonGroup RibbonGroup { get; set; }

		bool IsDefaultRibbonTabItem { get; set; }

		bool IsRibbonDropDownItem { get; set; }

		bool IsUpdatingItemEnabled { get; set; }

		string KeyTip { get; set; }

		bool OwnerEnabled { get; set; }

		RibbonItemCollection ParentCollection { get; }

		void AwareOfDPI(PointF dpi);

		SizeF GetSize(IconTextRelation scaleMode);

		void ParentVisibleChanged(bool isVisible);

		void PerformStandardKeyboardAction();

		void SetDropDownItemSize();

		void SetParentCollection(RibbonItemCollection parentCollection);
	}
}
