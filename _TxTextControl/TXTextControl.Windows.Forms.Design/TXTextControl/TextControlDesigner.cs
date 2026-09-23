using System.ComponentModel.Design;
using System.Security.Permissions;
using System.Windows.Forms.Design;

namespace TXTextControl
{
	[PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
	public class TextControlDesigner : ControlDesigner
	{
		private DesignerActionListCollection actionLists;

		public override DesignerActionListCollection ActionLists
		{
			get
			{
				if (this.actionLists == null)
				{
					this.actionLists = new DesignerActionListCollection();
					this.actionLists.Add(new TextControlActionList(base.Component));
				}
				return this.actionLists;
			}
		}
	}
}
