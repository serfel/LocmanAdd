using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Resources;
using System.Security.Permissions;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace TXTextControl.Windows.Forms.Ribbon
{
	[PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
	public class RibbonTabDesigner : ScrollableControlDesigner
	{
		public override void Initialize(IComponent component)
		{
			base.Initialize(component);
		}

		public override void InitializeNewComponent(IDictionary defaultValues)
		{
			RibbonTab ribbonTab = this.Control as RibbonTab;
			if (ribbonTab == null || defaultValues == null || defaultValues["Parent"] == null)
			{
				return;
			}
			Control control = defaultValues["Parent"] as Control;
			while (!(control is Ribbon) && (control = control.Parent) != null)
			{
			}
			if (control != null)
			{
				try
				{
					IDesignerHost designerHost = (IDesignerHost)base.Component.Site.GetService(typeof(IDesignerHost));
					if (designerHost != null)
					{
						using DesignerTransaction designerTransaction = designerHost.CreateTransaction();
						Ribbon ribbon = control as Ribbon;
						ribbon.Controls.Add(ribbonTab);
						ribbon.SelectedTab = ribbonTab;
						designerTransaction.Commit();
					}
				}
				catch
				{
				}
			}
			else
			{
				ResourceManager resourceManager = new ResourceManager(typeof(TextControlDesigner));
				MessageBox.Show(resourceManager.GetString("ERR_ADDRIBBONTAB"), "TX Text Control");
				ribbonTab.Site.Container.Remove(ribbonTab);
			}
		}
	}
}
