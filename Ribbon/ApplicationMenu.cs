/*-------------------------------------------------------------------------------------------------------------
** program:			TX Text Control Words
** description:	Implements a typical word processing application build up on the main features of TextControl's Components. 
**
** copyright:		© Text Control GmbH
**-----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using TXTextControl.Windows.Forms;
using TXTextControl.Windows.Forms.Ribbon;

namespace TX_Text_Control_Words {

	/*-------------------------------------------------------------------------------------------------------------
	** E N U M S
	**-----------------------------------------------------------------------------------------------------------*/

	public enum SampleTemplateType {
		Invoice,
		PackingList,
		ShippingLabel
	}

	/*-------------------------------------------------------------------------------------------------------------
	** class MainWindow
	** Capsulates the customizing of the application's menu.
	**-----------------------------------------------------------------------------------------------------------*/
	public partial class MainWindow {

		/*-------------------------------------------------------------------------------------------------------------
		** M E T H O D S
		**-----------------------------------------------------------------------------------------------------------*/

		/*-------------------------------------------------------------------------------------------------------------
		** InitializeAppMenu
		** Initialize the application's menu.
		** Localize the application menu and fill button's submenus.
		**-----------------------------------------------------------------------------------------------------------*/
		private void InitializeAppMenu()
		{

			// Register event handlers
			m_btnAppMenu_TXITEM_New.Click += BtnAppMenu_New_Click;
			m_btnAppMenu_TXITEM_Open.Click += BtnAppMenu_Open_Click;
			m_btnAppMenu_TXITEM_Save.Click += BtnAppMenu_Save_Click;
			m_btnAppMenu_TXITEM_SaveAs.Click += BtnAppMenu_SaveAs_Click;
			m_btnAppMenu_TXITEM_Print.ButtonClick += BtnAppMenu_Print_ButtonClick;
			m_btnAppMenu_TXITEM_DocumentSettings.Click += BtnAppMenu_TXITEM_DocumentSettings_Click;
			m_btnAppMenu_TXITEM_Options.Click += BtnAppMenu_Options_Click;
			m_btnAppMenu_TXITEM_UserAdministration.Click += BtnAppMenu_UserAdmin_Click;
			m_btnAppMenu_TXITEM_GrantUserAccess.Click += BtnAppMenu_UserAccess_Click;
			m_btnAppMenu_TXITEM_About.Click += BtnAppMenu_About_Click;
			m_btnAppMenu_TXITEM_Exit.Click += BtnAppMenu_Exit_Click;

			// Localize texts and images
			LocalizeAppMenu();

			// Add "Open Sample Template" drop down menu items
			AddOpenSampleTemplateButtons();

			// Add "Print" drop down menu items
			AddPrintButtons();
		}

		/*-------------------------------------------------------------------------------------------------------------
		** SetRecentItemsList
		** Replace the list of recent items in the help pane.
		**-----------------------------------------------------------------------------------------------------------*/
		private void SetRecentItemsList(StringCollection fileList) {
			// Remove all items except the header and the separator
			while (m_ribbon.ApplicationMenuHelpPaneItems.Count > 2) {
				m_ribbon.ApplicationMenuHelpPaneItems.RemoveAt(m_ribbon.ApplicationMenuHelpPaneItems.Count - 1);
			}

			// Add a RibbonButton foreach file in the list
			int i = 1;
			foreach (string fileName in fileList) {
				var btn = new RibbonButton
				{
					Text = i + " " + Path.GetFileName(fileName),
					Tag = fileName,	// Save full file path in Tag property
					DisplayMode = IconTextRelation.NoIconLabeled,
					KeyTip = i.ToString()
				};
				((RibbonToolTip)btn.ToolTip).Description = fileName;
				btn.Click += BtnRecentItem_Click;	// Add click event handler
				m_ribbon.ApplicationMenuHelpPaneItems.Add(btn);
				++i;
			}
		}

		/*-------------------------------------------------------------------------------------------------------------
		** AddOpenSampleTemplateButtons
		** Add buttons to 'Open Sample' button for opening a 'invoice', 'packinglist' and 'shipping label' sample.
		**-----------------------------------------------------------------------------------------------------------*/
		private void AddOpenSampleTemplateButtons() {
			// Create buttons for the sample templates
			// Invoice
			m_btnAppMenu_OpenSample_Invoice = new RibbonButton
			{
				DisplayMode = IconTextRelation.NoIconLabeled,
				Text = Лоцман_добавка.Properties.Resources.APP_MENU_OPEN_SAMPLE_INVOICE,
				Tag = SampleTemplateType.Invoice,
				KeyTip = "1"
			};
			m_btnAppMenu_OpenSample_Invoice.Click += BtnOpenSampleTemplate_Click;

			// Packinglist
			m_btnAppMenu_OpenSample_PackingList = new RibbonButton
			{
				DisplayMode = IconTextRelation.NoIconLabeled,
				Text = Лоцман_добавка.Properties.Resources.APP_MENU_OPEN_SAMPLE_PACK_LST,
				Tag = SampleTemplateType.PackingList,
				KeyTip = "2"
			};
			m_btnAppMenu_OpenSample_PackingList.Click += BtnOpenSampleTemplate_Click;

			// ShippingLabel
			m_btnAppMenu_OpenSample_ShipLabel = new RibbonButton
			{
				DisplayMode = IconTextRelation.NoIconLabeled,
				Text = Лоцман_добавка.Properties.Resources.APP_MENU_OPEN_SAMPLE_SHIP_LBL,
				Tag = SampleTemplateType.ShippingLabel,
				KeyTip = "3"
			};
			m_btnAppMenu_OpenSample_ShipLabel.Click += BtnOpenSampleTemplate_Click;

			// Add buttons to application menu's button for opening a template.
			m_btnAppMenu_OpenSample.DropDownItems.AddRange(new []{
				m_btnAppMenu_OpenSample_Invoice,
				m_btnAppMenu_OpenSample_PackingList,
				m_btnAppMenu_OpenSample_ShipLabel
			});
		}

		/*-------------------------------------------------------------------------------------------------------------
		** AddPrintButtons
		** Add buttons to 'Print' menu for quick printing, showing a print preview.
		**-----------------------------------------------------------------------------------------------------------*/
		private void AddPrintButtons() {

			// Print
			m_btnAppMenu_Print_TXITEM_Print = new RibbonButton
			{
				Name = "m_appMenu_TXITEM_Print",
			};
			m_btnAppMenu_Print_TXITEM_Print.Click += BtnAppMenu_Print_ButtonClick;
			m_btnAppMenu_Print_TXITEM_Print.Apply(ResourceProvider.FileMenuItem.TXITEM_Print.ToString(), m_DPI);

			// Print Quick
			m_btnAppMenu_Print_TXITEM_Print_Quick = new RibbonButton
			{
				Name = "m_appMenu_TXITEM_Print_Quick",
			};
			m_btnAppMenu_Print_TXITEM_Print_Quick.Click += BtnPrintQuick_Click;
			m_btnAppMenu_Print_TXITEM_Print_Quick.Apply(ResourceProvider.FileMenuItem.TXITEM_PrintQuick.ToString(), m_DPI);

			// Print Preview
			m_btnAppMenu_Print_TXITEM_Print_Preview = new RibbonButton
			{
				Name = "m_appMenu_TXITEM_Print_Preview",
			};
			m_btnAppMenu_Print_TXITEM_Print_Preview.Click += BtnPrintPreview_Click;
			m_btnAppMenu_Print_TXITEM_Print_Preview.Apply(ResourceProvider.FileMenuItem.TXITEM_PrintPreview.ToString(), m_DPI);


			m_btnAppMenu_TXITEM_Print.DropDownItems.AddRange(new []{
				m_btnAppMenu_Print_TXITEM_Print,
				m_btnAppMenu_Print_TXITEM_Print_Quick,
				m_btnAppMenu_Print_TXITEM_Print_Preview
			});
		} // AddPrintButtons

		/*-------------------------------------------------------------------------------------------------------------
		** LocalizeAppMenu
		** Localize the application's menu by setting the button's texts.
		**-----------------------------------------------------------------------------------------------------------*/
		private void LocalizeAppMenu() {
			// TXITEMS
			m_btnAppMenu_TXITEM_New.Apply(ResourceProvider.FileMenuItem.TXITEM_New.ToString(), m_DPI);
			m_btnAppMenu_TXITEM_Open.Apply(ResourceProvider.FileMenuItem.TXITEM_Open.ToString(), m_DPI);
			m_btnAppMenu_TXITEM_Save.Apply(ResourceProvider.FileMenuItem.TXITEM_Save.ToString(), m_DPI);
			m_btnAppMenu_TXITEM_SaveAs.Apply(ResourceProvider.FileMenuItem.TXITEM_SaveAs.ToString(), m_DPI);
			m_btnAppMenu_TXITEM_Print.Apply(ResourceProvider.FileMenuItem.TXITEM_Print.ToString(), m_DPI);
			m_btnAppMenu_TXITEM_DocumentSettings.Apply(ResourceProvider.FileMenuItem.TXITEM_DocumentSettings.ToString(), m_DPI);
			m_btnAppMenu_TXITEM_Options.Apply(ResourceProvider.FileMenuItem.TXITEM_Options.ToString(), m_DPI);
			m_btnAppMenu_TXITEM_UserAdministration.Apply(ResourceProvider.FileMenuItem.TXITEM_UserAdministration.ToString(), m_DPI);
			m_btnAppMenu_TXITEM_GrantUserAccess.Apply(ResourceProvider.FileMenuItem.TXITEM_GrantUserAccess.ToString(), m_DPI);
			m_btnAppMenu_TXITEM_About.Apply(ResourceProvider.FileMenuItem.TXITEM_About.ToString(), m_DPI);
			m_btnAppMenu_TXITEM_Exit.Apply(ResourceProvider.FileMenuItem.TXITEM_Exit.ToString(), m_DPI);

			// Additional App Menu Items
			m_lblRecentFilesHeader.Text = Лоцман_добавка.Properties.Resources.APP_MENU_RECENT_ITEMS_HEADER;
			m_btnAppMenu_OpenSample.Text = Лоцман_добавка.Properties.Resources.APP_MENU_OPEN_SAMPLE;
			m_btnAppMenu_OpenSample.SmallIcon = Images.GetSmallIcon("OpenDemo");
			m_btnAppMenu_OpenSample.LargeIcon = Images.GetLargeIcon("OpenDemo");
		}
	}//class MainWindow
}//namespace