/*-------------------------------------------------------------------------------------------------------------
** program:			TX Text Control Words
** description:	Implements a typical word processing application build up on the main features of 
**						TextControl's Components. 
**
** copyright:		© Text Control GmbH
**-----------------------------------------------------------------------------------------------------------*/
using TXTextControl.Windows.Forms;

namespace TX_Text_Control_Words
{

	/*----------------------------------------------------------------------------------------------------------
	** class MainWindow
	**	Capsulates functionalities related to the MainWindow's sidebars.
	**--------------------------------------------------------------------------------------------------------*/
	partial class MainWindow {

		/*-------------------------------------------------------------------------------------------------------
		** E V E N T H A N D L E R S
		**-----------------------------------------------------------------------------------------------------*/

		/*-------------------------------------------------------------------------------------------------------
		** m_horizontalSidebar_PropertyChanged
		**	Hide the horizontal sidebar's title when ContentLayout is TrackedChanges.
		**-----------------------------------------------------------------------------------------------------*/
		private void m_horizontalSidebar_PropertyChanged(object sender, 
			System.ComponentModel.PropertyChangedEventArgs e) {
			
			Sidebar sidebar = (Sidebar)sender;
			if (e.PropertyName == "ContentLayout") {
				switch (sidebar.ContentLayout) {
					case Sidebar.SidebarContentLayout.TrackedChanges:
						sidebar.ShowTitle = true;
						break;
					default:
						sidebar.ShowTitle = false;
						break;
				}
			}
		}

		/*---------------------------------------------------------------------------------------------------------
		** m_verticalRightSidebar_PropertyChanged
		**	Hide vertical right sidebar's pin button and force the pinning when content shows field's navigator or
		** styles.
		**-------------------------------------------------------------------------------------------------------*/
		private void m_verticalRightSidebar_PropertyChanged(object sender, 
			System.ComponentModel.PropertyChangedEventArgs e) {

			Sidebar sidebar = (Sidebar)sender;
			if (e.PropertyName == "ContentLayout")
				switch (sidebar.ContentLayout) {
					case Sidebar.SidebarContentLayout.ConditionalInstructions:
						sidebar.ShowPinButton = true;
						break;

					case Sidebar.SidebarContentLayout.FieldNavigator:
					case Sidebar.SidebarContentLayout.Styles:
						sidebar.ShowPinButton = false;
						sidebar.IsPinned = true;
						break;
					default:
						sidebar.ShowPinButton = true;
						break;
				}
		}

		/*---------------------------------------------------------------------------------------------------------
		** m_verticalLeftSidebar_PropertyChanged
		**	
		**-------------------------------------------------------------------------------------------------------*/
		private void m_verticalLeftSidebar_PropertyChanged(object sender,
			System.ComponentModel.PropertyChangedEventArgs e)
		{

			Sidebar sidebar = (Sidebar)sender;
			if (e.PropertyName == "ContentLayout")
				switch (sidebar.ContentLayout)
				{
					case Sidebar.SidebarContentLayout.TrackedChanges:
						sidebar.ShowPinButton = true;
						break;

					case Sidebar.SidebarContentLayout.DocumentSettings:
						sidebar.IsPinned = true;
						sidebar.ShowPinButton = false;
						break;
				}

			if (e.PropertyName == "IsShown" || e.PropertyName == "ContentLayout")
			{
				// Update states of toggle buttons.
				m_btnAppMenu_TXITEM_DocumentSettings.Checked = sidebar.IsShown && sidebar.ContentLayout == Sidebar.SidebarContentLayout.DocumentSettings;
			}

		}

	}
}
