using System.ComponentModel;
using System.ComponentModel.Design;
using System.Resources;
using System.Windows.Forms;
using TXTextControl.Windows.Forms;

namespace TXTextControl
{
	public class SidebarActionList : DesignerActionList
	{
		private DesignerActionUIService designerActionUISvc;

		private Sidebar m_sbSidebar;

		private ResourceManager m_rm;

		public Sidebar.SidebarContentLayout ContentLayout
		{
			get
			{
				return this.m_sbSidebar.ContentLayout;
			}
			set
			{
				this.m_sbSidebar.ContentLayout = value;
			}
		}

		public TextControl TextControl
		{
			get
			{
				return this.m_sbSidebar.TextControl;
			}
			set
			{
				this.m_sbSidebar.TextControl = value;
			}
		}

		public DockStyle Dock
		{
			get
			{
				return this.m_sbSidebar.Dock;
			}
			set
			{
				this.m_sbSidebar.Dock = value;
			}
		}

		public string Text
		{
			get
			{
				return this.m_sbSidebar.Text;
			}
			set
			{
				this.m_sbSidebar.Text = value;
			}
		}

		public bool ShowTitle
		{
			get
			{
				return this.m_sbSidebar.ShowTitle;
			}
			set
			{
				this.m_sbSidebar.ShowTitle = value;
			}
		}

		public bool ShowPinButton
		{
			get
			{
				return this.m_sbSidebar.ShowPinButton;
			}
			set
			{
				this.m_sbSidebar.ShowPinButton = value;
			}
		}

		public bool ShowCloseButton
		{
			get
			{
				return this.m_sbSidebar.ShowCloseButton;
			}
			set
			{
				this.m_sbSidebar.ShowCloseButton = value;
			}
		}

		public SidebarActionList(IComponent component)
			: base(component)
		{
			this.m_sbSidebar = component as Sidebar;
			this.m_rm = new ResourceManager(typeof(TextControlDesigner));
			this.designerActionUISvc = base.GetService(typeof(DesignerActionUIService)) as DesignerActionUIService;
		}

		public override DesignerActionItemCollection GetSortedActionItems()
		{
			DesignerActionItemCollection designerActionItemCollection = new DesignerActionItemCollection();
			designerActionItemCollection.Add(new DesignerActionHeaderItem("Layout"));
			designerActionItemCollection.Add(new DesignerActionPropertyItem("ContentLayout", "ContentLayout", "Layout", this.m_rm.GetString("PROP_CONTENTLAYOUT")));
			designerActionItemCollection.Add(new DesignerActionPropertyItem("Dock", "Dock", "Layout", this.m_rm.GetString("PROP_SIDEBARDOCK")));
			designerActionItemCollection.Add(new DesignerActionHeaderItem("Behavior"));
			designerActionItemCollection.Add(new DesignerActionPropertyItem("TextControl", "TextControl", "Behavior", this.m_rm.GetString("PROP_TEXTCONTROL")));
			designerActionItemCollection.Add(new DesignerActionHeaderItem("Appearance"));
			designerActionItemCollection.Add(new DesignerActionPropertyItem("Text", "Text", "Appearance", this.m_rm.GetString("PROP_SIDEBARTEXT")));
			designerActionItemCollection.Add(new DesignerActionPropertyItem("ShowTitle", "ShowTitle", "Appearance", this.m_rm.GetString("PROP_SHOWTITLE")));
			designerActionItemCollection.Add(new DesignerActionPropertyItem("ShowPinButton", "ShowPinButton", "Appearance", this.m_rm.GetString("PROP_SHOWPINBUTTON")));
			designerActionItemCollection.Add(new DesignerActionPropertyItem("ShowCloseButton", "ShowCloseButton", "Appearance", this.m_rm.GetString("PROP_SHOWCLOSEBUTTON")));
			return designerActionItemCollection;
		}
	}
}
