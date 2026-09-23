namespace TXTextControl.Windows.Forms.Ribbon
{
	/// <summary>Specifies the position of the text and the kind of icon relative to each other on objects of type RibbonButton and RibbonTextBox:</summary>
	public enum IconTextRelation
	{
		/// <summary>Only the item's text is displayed.</summary>
		NoIconLabeled = 1,
		/// <summary>The item's small icon is displayed, but not its text.</summary>
		SmallIconUnlabeled = 2,
		/// <summary>The item displayes its small icon horizontally before the text.</summary>
		SmallIconLabeled = 4,
		/// <summary>If the object is part of a RibbonGroup the item displayes its large icon above its text. If the item is an object of type RibbonButton and inserted as a drop-down item, the image is displayed horizontally before the text and the description text.</summary>
		LargeIconLabeled = 8
	}
}
