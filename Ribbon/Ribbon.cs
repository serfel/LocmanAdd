/*-------------------------------------------------------------------------------------------------------------
** program:			TX Text Control Words
** description:	Implements a typical word processing application build up on the main features of 
**						TextControl's Components. 
**
** copyright:		© Text Control GmbH
**-----------------------------------------------------------------------------------------------------------*/
using System;
using System.Diagnostics;
using System.Linq;
using System.Drawing;
using TXTextControl.Windows.Forms;
using TXTextControl.Windows.Forms.Ribbon;

namespace TX_Text_Control_Words {

	/*-------------------------------------------------------------------------------------------------------------
	** class MainWindow
	**	Capsulates the functionalities of MainWindow's Ribbon.
	**-----------------------------------------------------------------------------------------------------------*/
	public partial class MainWindow {

		/*-------------------------------------------------------------------------------------------------------------
		** InitializeRibbon
		**	Initialize the MainWindow's ribbon by adding an application menu to ribbon. 
		**-----------------------------------------------------------------------------------------------------------*/
		private void InitializeRibbon() {
			m_ribbon.SelectedIndex = 1;

			CustomizeReportingTab();
			CustomizePreviewTab();
			CustomizeViewTab();

			InitializeAppMenu();
			InitializeQuickAccessToolbar();
		}

		/*-------------------------------------------------------------------------------------------------------------
		** CustomizeViewTab
		**	Customize the ViewTab by adding a button for toggling the application's orientation.
		**-----------------------------------------------------------------------------------------------------------*/
		private void CustomizeViewTab() {
			AddAppViewGroup(m_viewTab);
		}

		/*-------------------------------------------------------------------------------------------------------------
		** CustomizeReportingTab
		**	Customize the ReportingTab by adding a button for toggling the FieldNavigator, adding a button for opening
		** the sample database and add a group for prepare and finish a merge.
		**-----------------------------------------------------------------------------------------------------------*/
		private void CustomizeReportingTab() {
			AddOpenSampleDbMenuButton();
			AddFinishGroup();
		}

		/*-------------------------------------------------------------------------------------------------------------
		** CustomizePreviewTab
		**	Customize the Preview Tab by adding a group for navigate to a merge result and leaving the preview 'mode'.
		**-----------------------------------------------------------------------------------------------------------*/
		private void CustomizePreviewTab() {
			m_reportingPreviewGroup.Header = Лоцман_добавка.Properties.Resources.CONTEXTUAL_TAB_GROUP_REPORTING;
			m_previewTab.Text = Лоцман_добавка.Properties.Resources.RIBBON_TAB_PREVIEW_HEADER;
			AddPreviewGroup();
			AddNavigateGroup();
		}

		/*-------------------------------------------------------------------------------------------------------------
		** InitializeQuickAccessToolbar
		**	Initialize the quick access toolbar by adding buttons for saving, opening and creating a new document.
		** Add buttons for undoing and redoing actions, and printing the document.
		**-----------------------------------------------------------------------------------------------------------*/
		private void InitializeQuickAccessToolbar() {
			// Create buttons which only appear in the quick access toolbar
			
			// Undo
			m_btnUndo = new RibbonButton
			{
				Enabled = false
			};
			m_btnUndo.Click += (sender, e) => { m_textControl.Undo(); };
			m_textControl.PropertyChanged += (sender, e) => { if (e.PropertyName == "CanUndo") m_btnUndo.Enabled = m_textControl.CanUndo; };
			m_btnUndo.Apply(ResourceProvider.GeneralItem.TXITEM_Undo.ToString(), m_DPI,
				RibbonButtonExtensions.RibbonButtonResource.ToolTip | RibbonButtonExtensions.RibbonButtonResource.SmallImageSource | RibbonButtonExtensions.RibbonButtonResource.Label);
			
			// Redo
			m_btnRedo = new RibbonButton
			{
				Enabled = false
			};
			m_btnRedo.Click += (sender, e) => { m_textControl.Redo(); };
			m_textControl.PropertyChanged += (sender, e) => { if (e.PropertyName == "CanRedo") m_btnRedo.Enabled = m_textControl.CanRedo; };
			m_btnRedo.Apply(ResourceProvider.GeneralItem.TXITEM_Redo.ToString(), m_DPI,
				RibbonButtonExtensions.RibbonButtonResource.ToolTip | RibbonButtonExtensions.RibbonButtonResource.SmallImageSource | RibbonButtonExtensions.RibbonButtonResource.Label);


			// Set default quick access toolbar items
			SetQuickAccessToolbarStandardItems(new RibbonButton[] {
				m_btnAppMenu_TXITEM_Save, m_btnAppMenu_TXITEM_Open, m_btnAppMenu_TXITEM_New,
				m_btnUndo, m_btnRedo, m_btnAppMenu_TXITEM_Print
			});
		}
	}

	/*-------------------------------------------------------------------------------------------------------------
	** class RibbonButtonExtensions
	**	Capsulates additional functionalities for RibbonButtons.
	**-----------------------------------------------------------------------------------------------------------*/
	public static partial class RibbonButtonExtensions {

		[Flags]
		public enum RibbonButtonResource {
			LargeImageSource = 2,
			ToolTipTitle = 4,
			ToolTipDescription = 8,
			Label = 16,
			KeyTip = 32,
			SmallImageSource = 64,
			ToolTip = ToolTipTitle | ToolTipDescription,
			All = ToolTipTitle | LargeImageSource | ToolTipDescription | Label | KeyTip | SmallImageSource
		}

		/*-------------------------------------------------------------------------------------------------------------
		** Apply
		**	Applies the default settings of the TXITEM to the button by using the TX Text Control Resources.
		**-----------------------------------------------------------------------------------------------------------*/
		public static void Apply(this RibbonButton btn, string txitem, float dpi, RibbonButtonResource option = RibbonButtonResource.All) {

			// Icons
			// Small Icon
			if (option.HasFlag(RibbonButtonResource.SmallImageSource)) {
				var smallIcon = ResourceProvider.GetSmallIcon(txitem, dpi);
				if (smallIcon != null) {
					btn.SmallIcon = smallIcon;
				}
				else {
					Debug.WriteLine(String.Format(btn.Name + ": Small Icon not found by '{0}' via ResourceProvider.", txitem));
					btn.SmallIcon = ResourceProvider.GetSmallIcon("dummy", dpi); ;
				}
			}

			// Large Icon
			if (option.HasFlag(RibbonButtonResource.LargeImageSource)) {
				var largeIcon = ResourceProvider.GetLargeIcon(txitem, dpi);
				if (largeIcon != null) {
					btn.LargeIcon = largeIcon;
				}
				else {
					Debug.WriteLine(String.Format(btn.Name + ": Large Icon not found by '{0}' via ResourceProvider.", txitem));
					btn.LargeIcon = ResourceProvider.GetLargeIcon("dummy", dpi); ;
				}
			}

			// ToolTip
			if (option.HasFlag(RibbonButtonResource.ToolTipTitle)) {
				var toolTipDesc = ResourceProvider.GetToolTipDescription(txitem);
				if (toolTipDesc != "") btn.ToolTip.Description = toolTipDesc;
				else Debug.WriteLine(String.Format(btn.Name + ": Tooltip description not found by '{0}' via ResourceProvider.", txitem));
			}

			if (option.HasFlag(RibbonButtonResource.ToolTipDescription)) {
				var toolTipTitle = ResourceProvider.GetToolTipTitle(txitem);
				if (toolTipTitle != "") btn.ToolTip.Title = toolTipTitle;
				else Debug.WriteLine(String.Format(btn.Name + ": Tooltip title not found by '{0}' via ResourceProvider.", txitem));
			}

			// Text
			if (option.HasFlag(RibbonButtonResource.Label)) {
				var text = ResourceProvider.GetText(txitem);
				if (text != "") btn.Text = text;
				else Debug.WriteLine(String.Format(btn.Name + ": Text not found by '{0}' via ResourceProvider.", txitem));
			}

			// KeyTip
			if (option.HasFlag(RibbonButtonResource.KeyTip)) {
				var keyTip = ResourceProvider.GetKeyTip(txitem);
				if (keyTip != "") btn.KeyTip = keyTip;
				else Debug.WriteLine(String.Format(btn.Name + ": KeyTip not found by '{0}' via ResourceProvider.", txitem));
			}
		}
	}
}