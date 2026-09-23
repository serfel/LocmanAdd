using System.Collections;
using System.ComponentModel.Design;
using System.Drawing;
using System.Security.Permissions;
using System.Windows.Forms.Design;
using TXTextControl.Windows.Forms;

namespace TXTextControl
{
	[PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
	public class SidebarDesigner : ControlDesigner
	{
		private DesignerActionListCollection actionLists;

		public override DesignerActionListCollection ActionLists
		{
			get
			{
				if (this.actionLists == null)
				{
					this.actionLists = new DesignerActionListCollection();
					this.actionLists.Add(new SidebarActionList(base.Component));
				}
				return this.actionLists;
			}
		}

		public override void InitializeNewComponent(IDictionary defaultValues)
		{
			base.InitializeNewComponent(defaultValues);
			if (this.Control is Sidebar)
			{
				Sidebar sidebar = this.Control as Sidebar;
				sidebar.Size = new Size(150, 300);
				sidebar.Text = sidebar.Name;
			}
		}
	}
}
