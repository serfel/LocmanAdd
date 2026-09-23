/*-------------------------------------------------------------------------------------------------------------
** program:			TX Text Control Words
** description:	Implements a typical word processing application build up on the main features of TextControl's Components. 
**
** copyright:		© Text Control GmbH
**-----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Drawing;
using TXTextControl;
using TXTextControl.Windows.Forms;
using TXTextControl.Windows.Forms.Ribbon;
using System.Linq;
using System.Diagnostics;

namespace TX_Text_Control_Words {

	/*-------------------------------------------------------------------------------------------------------------
	** class MainWindow
	**-----------------------------------------------------------------------------------------------------------*/
	public partial class MainWindow {


		/*-------------------------------------------------------------------------------------------------------------
		** M E M B E R S
		**-----------------------------------------------------------------------------------------------------------*/

		private RibbonGroup m_grpPreview;
		private RibbonButton TXITEM_ClosePreview;
		private RibbonGroup m_grpNavigate;
		private RibbonButton TXITEM_FirstRecord;
		private RibbonButton TXITEM_PreviousRecord;
		private RibbonButton TXITEM_NextRecord;
		private RibbonButton TXITEM_LastRecord;

		private IList<byte[]> m_lstMergedFiles = null;

		private int m_iPreviewIndex = 0;
		private int m_nPreviewCount = 0;

		private List<Sidebar> m_memorizedShownSidebars = new List<Sidebar>();


		/*-------------------------------------------------------------------------------------------------------------
		** M E T H O D S
		**-----------------------------------------------------------------------------------------------------------*/

		/*-------------------------------------------------------------------------------------------------------------
		** AddPreviewGroup method
		**	Adds a new group to the previewtab.
		**-----------------------------------------------------------------------------------------------------------*/
		private void AddPreviewGroup() {
			m_grpPreview = new RibbonGroup
			{
				Text = Лоцман_добавка.Properties.Resources.RIBBON_GROUP_PREVIEW,
				LargeIcon = ResourceProvider.GetSmallIcon(ResourceProvider.FileMenuItem.TXITEM_Exit.ToString(), m_DPI),
				SmallIcon = ResourceProvider.GetSmallIcon(ResourceProvider.FileMenuItem.TXITEM_Exit.ToString(), m_DPI),
				IsAddToQuickAccessToolbarEnabled = false,
				HorizontalContentAlignment = HorizontalAlignment.Center
			};
			m_grpPreview.DialogBoxLauncher.Visible = false;
			m_previewTab.RibbonGroups.Add(m_grpPreview);
			
			AddClosePreviewButton();
		}

		/*-------------------------------------------------------------------------------------------------------------
		** AddClosePreviewButton method
		**	Adds a new button to the preview group for closing.
		**-----------------------------------------------------------------------------------------------------------*/
		private void AddClosePreviewButton() {
			TXITEM_ClosePreview = new RibbonButton
			{
				DisplayMode = IconTextRelation.LargeIconLabeled,
				IsAddToQuickAccessToolbarEnabled = false,
			};

			TXITEM_ClosePreview.Click += ClosePreview_Click;
			TXITEM_ClosePreview.Apply(ResourceProvider.FileMenuItem.TXITEM_Exit.ToString(), m_DPI);
			m_grpPreview.RibbonItems.Add(TXITEM_ClosePreview);
		}

		/*-------------------------------------------------------------------------------------------------------------
		** ClosePreview_Click method
		**	Close the preview tab and select the ReportingTab.
		**-----------------------------------------------------------------------------------------------------------*/
		void ClosePreview_Click(object sender, EventArgs e) {
			HandleClosePreview();
			m_ribbon.SelectedTab = m_reportingTab;
		}


		/*-------------------------------------------------------------------------------------------------------------
		** AddNavigateGroup method
		**	Adds a new group for navigating forward or backward, to first or to last preview.
		**-----------------------------------------------------------------------------------------------------------*/
		private void AddNavigateGroup() {
			m_grpNavigate = new RibbonGroup
			{
				Text = Лоцман_добавка.Properties.Resources.RIBBON_GROUP_NAVIGATE,
				LargeIcon = ResourceProvider.GetSmallIcon(ResourceProvider.GeneralItem.TXITEM_NavigateToLast.ToString(), m_DPI),
				SmallIcon = ResourceProvider.GetSmallIcon(ResourceProvider.GeneralItem.TXITEM_NavigateToLast.ToString(), m_DPI),
				IsAddToQuickAccessToolbarEnabled = false
			};
			m_grpNavigate.DialogBoxLauncher.Visible = false;
			m_previewTab.RibbonGroups.Add(m_grpNavigate);

			AddFirstRecordButton();
			AddPreviousRecordButton();
			AddNextRecordButton();
			AddLastRecordButton();
		}


		/*-------------------------------------------------------------------------------------------------------------
		** AddFirstRecordButton method
		**	Add a button to navigation group for navigating to the first preview/record.
		**-----------------------------------------------------------------------------------------------------------*/
		private void AddFirstRecordButton() {
			TXITEM_FirstRecord = new RibbonButton
			{
				DisplayMode = IconTextRelation.LargeIconLabeled,
				IsAddToQuickAccessToolbarEnabled = false,
				Text = Лоцман_добавка.Properties.Resources.PREVIEWTAB_NAVIGATEGRP_FIRST_RECORD
			};
			TXITEM_FirstRecord.Click += BtnFirstRecord_Click;
			TXITEM_FirstRecord.ToolTip.Opening += RecordButton_ToolTip_Opening;
			TXITEM_FirstRecord.Apply(ResourceProvider.GeneralItem.TXITEM_NavigateToFirst.ToString(), m_DPI, 
				RibbonButtonExtensions.RibbonButtonResource.All & ~RibbonButtonExtensions.RibbonButtonResource.Label);
			m_grpNavigate.RibbonItems.Add(TXITEM_FirstRecord);
		}

		/*-------------------------------------------------------------------------------------------------------------
		** BtnFirstRecord_Click method
		**	Navigate to the first preview/record.
		**-----------------------------------------------------------------------------------------------------------*/
		void BtnFirstRecord_Click(object sender, EventArgs e) {
			m_iPreviewIndex = 0;
			m_textControl.Load(m_lstMergedFiles[m_iPreviewIndex], BinaryStreamType.InternalUnicodeFormat);
			UpdateNavigateButtons();
		}

		/*-------------------------------------------------------------------------------------------------------------
		** AddPreviousRecordButton method
		**	Add a new button to the navigation group for navigating to the previous preview/record.
		**-----------------------------------------------------------------------------------------------------------*/
		private void AddPreviousRecordButton() {
			TXITEM_PreviousRecord = new RibbonButton
			{
				DisplayMode = IconTextRelation.LargeIconLabeled,
				IsAddToQuickAccessToolbarEnabled = false,
				Text = Лоцман_добавка.Properties.Resources.PREVIEWTAB_NAVIGATEGRP_PREVIOUS_RECORD
			};
			TXITEM_PreviousRecord.Click += BtnPreviousRecord_Click;
			TXITEM_PreviousRecord.ToolTip.Opening += RecordButton_ToolTip_Opening;
			TXITEM_PreviousRecord.Apply(ResourceProvider.GeneralItem.TXITEM_NavigateToPrevious.ToString(), m_DPI,
				RibbonButtonExtensions.RibbonButtonResource.All & ~RibbonButtonExtensions.RibbonButtonResource.Label);
			m_grpNavigate.RibbonItems.Add(TXITEM_PreviousRecord);
		}

		/*-------------------------------------------------------------------------------------------------------------
		** BtnPreviousRecord_Click method
		**	Navigate to the previous preview/record.
		**-----------------------------------------------------------------------------------------------------------*/
		void BtnPreviousRecord_Click(object sender, EventArgs e) {
			m_iPreviewIndex--;
			m_textControl.Load(m_lstMergedFiles[m_iPreviewIndex], BinaryStreamType.InternalUnicodeFormat);
			UpdateNavigateButtons();
		}

		/*-------------------------------------------------------------------------------------------------------------
		** AddNextRecordButton method
		**	Add button to navigation group for navigating to the next preview/record.
		**-----------------------------------------------------------------------------------------------------------*/
		private void AddNextRecordButton() {
			TXITEM_NextRecord = new RibbonButton
			{
				DisplayMode = IconTextRelation.LargeIconLabeled,
				IsAddToQuickAccessToolbarEnabled = false,
				Text = Лоцман_добавка.Properties.Resources.PREVIEWTAB_NAVIGATEGRP_NEXT_RECORD
			};
			TXITEM_NextRecord.Click += BtnNextRecord_Click;
			TXITEM_NextRecord.ToolTip.Opening += RecordButton_ToolTip_Opening;
			TXITEM_NextRecord.Apply(ResourceProvider.GeneralItem.TXITEM_NavigateToNext.ToString(), m_DPI,
				RibbonButtonExtensions.RibbonButtonResource.All & ~RibbonButtonExtensions.RibbonButtonResource.Label);

			m_grpNavigate.RibbonItems.Add(TXITEM_NextRecord);
		}

		/*-------------------------------------------------------------------------------------------------------------
		** BtnNextRecord_Click method
		**	Navigate to the next preview/record.
		**-----------------------------------------------------------------------------------------------------------*/
		void BtnNextRecord_Click(object sender, EventArgs e) {
			m_iPreviewIndex++;
			m_textControl.Load(m_lstMergedFiles[m_iPreviewIndex], BinaryStreamType.InternalUnicodeFormat);
			UpdateNavigateButtons();
		}

		/*-------------------------------------------------------------------------------------------------------------
		** RecordButton_ToolTip_Opening method
		**	Sets the tooltips on opening.
		**-----------------------------------------------------------------------------------------------------------*/
		void RecordButton_ToolTip_Opening(object sender, EventArgs e) {
			SetToolTipDescription((RibbonButton)sender);
		}

		/*-------------------------------------------------------------------------------------------------------------
		** AddLastRecordButton method
		**	Add button to navigation group for navigating to the last preview/record.
		**-----------------------------------------------------------------------------------------------------------*/
		private void AddLastRecordButton() {
			TXITEM_LastRecord = new RibbonButton
			{
				DisplayMode = IconTextRelation.LargeIconLabeled,
				IsAddToQuickAccessToolbarEnabled = false,
				Text = Лоцман_добавка.Properties.Resources.PREVIEWTAB_NAVIGATEGRP_LAST_RECORD
			};
			TXITEM_LastRecord.Click += BtnLastRecord_Click;
			TXITEM_LastRecord.ToolTip.Opening += RecordButton_ToolTip_Opening;
			TXITEM_LastRecord.Apply(ResourceProvider.GeneralItem.TXITEM_NavigateToLast.ToString(), m_DPI,
				RibbonButtonExtensions.RibbonButtonResource.All & ~RibbonButtonExtensions.RibbonButtonResource.Label);
			m_grpNavigate.RibbonItems.Add(TXITEM_LastRecord);
		}

		/*-------------------------------------------------------------------------------------------------------------
		** BtnLastRecord_Click method
		**	Show the last preview/record.
		**-----------------------------------------------------------------------------------------------------------*/
		void BtnLastRecord_Click(object sender, EventArgs e) {
			m_iPreviewIndex = m_nPreviewCount - 1;
			m_textControl.Load(m_lstMergedFiles[m_iPreviewIndex], BinaryStreamType.InternalUnicodeFormat);
			UpdateNavigateButtons();
		}

		/*-------------------------------------------------------------------------------------------------------------
		** SetToolTipDescription method
		**	Set the tooltips on opening for the button.
		**-----------------------------------------------------------------------------------------------------------*/
		private void SetToolTipDescription(RibbonButton navigateButton) {
			int iDataSetNumber = 0;

			if (navigateButton == TXITEM_FirstRecord) iDataSetNumber = 0;
			else if (navigateButton == TXITEM_PreviousRecord) iDataSetNumber = m_iPreviewIndex - 1;
			else if (navigateButton == TXITEM_NextRecord) iDataSetNumber = m_iPreviewIndex + 1;
			else if (navigateButton == TXITEM_LastRecord) iDataSetNumber = m_nPreviewCount - 1;
			else Debug.WriteLine("SetToolTipDescription: Unknown navigation button.");

			navigateButton.ToolTip.Title = navigateButton.Text;
			navigateButton.ToolTip.Description = string.Format(Лоцман_добавка.Properties.Resources.GO_TO_RECORD_TOOLTIP, (iDataSetNumber + 1));
		}

		/*-------------------------------------------------------------------------------------------------------------
		** UpdateNavigateButtons method
		** Hide the table tools group and enable the navigation buttons if the action is possible.
		**-----------------------------------------------------------------------------------------------------------*/
		private void UpdateNavigateButtons() {
			m_tableToolsGroup.Visible = false;
			TXITEM_FirstRecord.Enabled = m_iPreviewIndex > 0;
			TXITEM_PreviousRecord.Enabled = m_iPreviewIndex > 0;

			TXITEM_NextRecord.Enabled = m_iPreviewIndex < m_nPreviewCount - 1;
			TXITEM_LastRecord.Enabled = m_iPreviewIndex < m_nPreviewCount - 1;
		}

		/*-------------------------------------------------------------------------------------------------------------
		** Ribbon_TabIndexChanged method
		** Handle the closing/leaving of the preview tab.
		** Memorize which sidebars are shown when selecting the preview tab for beeing able to restore the screen
		** setting.
		**-----------------------------------------------------------------------------------------------------------*/
		private void Ribbon_TabIndexChanged(object sender, System.EventArgs e) {
			if (m_reportingPreviewGroup.Visible && m_ribbon.SelectedTab != m_previewTab) {
				HandleClosePreview();
			}
			else if (m_ribbon.SelectedTab == m_previewTab) {
				MemorizeShownSidebars();
			}
		}

		/*-------------------------------------------------------------------------------------------------------------
		** MemorizeShownSidebars method
		** Memorize the shown/visible sidebars by storing them in a local variable.
		**-----------------------------------------------------------------------------------------------------------*/
		private void MemorizeShownSidebars() {

			List<Sidebar> availableSidebars = new List<Sidebar>(this.Controls.OfType<Sidebar>());

			// Store which sidebars are visible at this point
			// for being able to show these again after leaving the preview tab
			m_memorizedShownSidebars = new List<Sidebar>(availableSidebars.Where<Sidebar>(x => { return x.IsShown; }));

			// Hide all sidebars
			foreach (var visibleSidebar in m_memorizedShownSidebars)
				visibleSidebar.IsShown = false;
		}

		/*-------------------------------------------------------------------------------------------------------------
		** ShowMemorizedShownSidebars method
		** Shows the memorized shown sidebars and clears the list.
		**-----------------------------------------------------------------------------------------------------------*/
		private void ShowMemorizedShownSidebars() {
			if (m_memorizedShownSidebars != null && m_memorizedShownSidebars.Count > 0) {
				// Make the sidebars visible again
				foreach (var sidebar in m_memorizedShownSidebars) {
					sidebar.IsShown = true;
				}
				m_memorizedShownSidebars.Clear();
			}
		}

		/*-------------------------------------------------------------------------------------------------------------
		** HandleClosePreview method
		** Handle the closing of the preview tab by resetting the TextControl's EditMode and load the previous
		** content of the TextControl. Hide also the PreviewGroup and show the previous shown sidebars.
		**-----------------------------------------------------------------------------------------------------------*/
		private void HandleClosePreview() {
			m_textControl.EditMode = m_editMode;
			if (m_textControlContent != null) {
				m_textControl.Load(m_textControlContent, BinaryStreamType.InternalUnicodeFormat);
			}
			m_reportingPreviewGroup.Visible = false;
			TXITEM_Preview.Enabled = true;

			ShowMemorizedShownSidebars();
		}
	}
}
