using System.ComponentModel.Design;
using System.Security.Permissions;

namespace TXTextControl.DocumentServer
{
	[PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
	public class MailMergeDesigner : ComponentDesigner
	{
		private DesignerActionListCollection m_actionLists;

		public override DesignerActionListCollection ActionLists
		{
			get
			{
				if (this.m_actionLists == null)
				{
					this.m_actionLists = new DesignerActionListCollection();
					this.m_actionLists.Add(new MailMergeActionList(base.Component));
				}
				return this.m_actionLists;
			}
		}
	}
}
