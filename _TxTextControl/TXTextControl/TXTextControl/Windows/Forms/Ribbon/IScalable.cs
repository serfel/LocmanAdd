namespace TXTextControl.Windows.Forms.Ribbon
{
	internal interface IScalable
	{
		IconTextRelation DefaultDisplayMode { get; }

		bool IsScalable { get; set; }

		void SetDisplayMode(IconTextRelation value);
	}
}
