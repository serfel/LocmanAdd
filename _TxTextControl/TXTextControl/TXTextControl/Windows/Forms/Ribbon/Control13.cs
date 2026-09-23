using System.Windows.Forms;
using TXTextControl.Windows.Forms.Ribbon;

namespace TXTextControl.Windows.Forms.Ribbon
{
	internal class Control13 : Control.ControlAccessibleObject
	{
		private IContentItem icontentItem_0;

		public override AccessibleRole Role => this.icontentItem_0.GetType().ToString() switch
		{
			"TXTextControl.Windows.Forms.Ribbon.RibbonSplitButton" => AccessibleRole.ButtonDropDown, 
			"TXTextControl.Windows.Forms.Ribbon.RibbonMenuButton" => AccessibleRole.MenuPopup, 
			"TXTextControl.Windows.Forms.Ribbon.RibbonToggleButton" => AccessibleRole.CheckButton, 
			"TXTextControl.Windows.Forms.Ribbon.RibbonButton" => AccessibleRole.PushButton, 
			"TXTextControl.Windows.Forms.Ribbon.RibbonTextBox" => AccessibleRole.Text, 
			"TXTextControl.Windows.Forms.Ribbon.RibbonListView" => AccessibleRole.List, 
			_ => AccessibleRole.None, 
		};

		public override string Name
		{
			get
			{
				if (this.icontentItem_0 is RibbonTextBox)
				{
					RibbonTextBox ribbonTextBox = this.icontentItem_0 as RibbonTextBox;
					return ribbonTextBox.Label + " " + base.Name + " " + ribbonTextBox.TextBoxLabel;
				}
				_ = base.Name;
				if (string.IsNullOrEmpty(base.Name))
				{
					return this.icontentItem_0.ToolTip.Title;
				}
				return base.Name;
			}
			set
			{
				base.Name = value;
			}
		}

		internal Control13(Control control_0)
			: base(control_0)
		{
			this.icontentItem_0 = control_0 as IContentItem;
		}
	}
}
