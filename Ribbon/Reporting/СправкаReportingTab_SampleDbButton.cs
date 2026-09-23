/*-------------------------------------------------------------------------------------------------------------
** program:			TX Text Control Words
** description:	Implements a typical word processing application build up on the main features of 
**						TextControl's Components. 
**
** copyright:		© Text Control GmbH
**-----------------------------------------------------------------------------------------------------------*/
using System;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using TXTextControl.Windows.Forms.Ribbon;

namespace TX_Text_Control_Words {

	/*-------------------------------------------------------------------------------------------------------------
	** class MainWindow
	** Capsulates the implementation of the ribbon's button for opening a sample database.
	**-----------------------------------------------------------------------------------------------------------*/
	partial class Справка
	{

		/*-------------------------------------------------------------------------------------------------------------
		** M E M B E R S
		**-----------------------------------------------------------------------------------------------------------*/

		private RibbonButton m_mnuBtnOpenSampleDb;

		/*-------------------------------------------------------------------------------------------------------------
		** M E T H O D S
		**-----------------------------------------------------------------------------------------------------------*/

		/*-------------------------------------------------------------------------------------------------------------
		** AddOpenSampleDbMenuButton method
		** Adds a new button to 'ReportingTab'=>'DataSource' menu for opening the sample database 'sample_db.xml', 
		** which is placed in executable's parent folder.
		**-----------------------------------------------------------------------------------------------------------*/
		private void AddOpenSampleDbMenuButton() {
			m_mnuBtnOpenSampleDb = new RibbonButton
			{
				DisplayMode = IconTextRelation.SmallIconLabeled,
				Text = Лоцман_добавка.Properties.Resources.OPEN_SAMPLE_DB_MENU_BTN_TEXT,
				SmallIcon = Images.GetSmallIcon("DataSource_LoadSample")
			};
			m_mnuBtnOpenSampleDb.ToolTip.Description = Лоцман_добавка.Properties.Resources.OPEN_SAMPLE_DB_MENU_BTN_TOOLTIP;

			// On Click load Sample DB
			m_mnuBtnOpenSampleDb.Click += (object sender, EventArgs e) => { LoadSampleDB(); };

			var btnSelDataSrc = (RibbonSplitButton)m_reportingTab.FindItem(RibbonReportingTab.RibbonItem.TXITEM_DataSource);
			btnSelDataSrc.DropDownItems.Insert(4, m_mnuBtnOpenSampleDb);
		}

		/*-------------------------------------------------------------------------------------------------------------
		** LoadSampleDB method
		** Load the sample database 'sample_db.xml', of executable's parent folder, by using the DataSoureManager
		** of the ReportingTab.
		**-----------------------------------------------------------------------------------------------------------*/
		private void LoadSampleDB() {
			string dir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
			string fileName = dir + "\\..\\sample_db.xml";
			try {
				m_reportingTab.DataSourceManager.LoadXmlFile(fileName);
				// Enable "Edit Data Relations" button
				m_reportingTab.FindItem(RibbonReportingTab.RibbonItem.TXITEM_EditDataRelations).Enabled = true;
			}
			catch (Exception exc) {
				MessageBox.Show(exc.Message, "Боцман", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
	}
}