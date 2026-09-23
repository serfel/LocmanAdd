/*-------------------------------------------------------------------------------------------------------------
** program:			TX Text Control Words
** description:	Implements a typical word processing application build up on the main features of TextControl's Components. 
**
** copyright:		© Text Control GmbH
**-----------------------------------------------------------------------------------------------------------*/
using System;
using System.Windows.Forms;

namespace TX_Text_Control_Words {

	/*------------------------------------------------------------------------------------------------
	** Class MergeWaitDialog
	** A dialog for displaying the progress of a merge.
	**----------------------------------------------------------------------------------------------*/
	partial class MergeWaitDialog : Form {

		/*------------------------------------------------------------------------------------------------
		** M E M B E R S
		**----------------------------------------------------------------------------------------------*/

		private bool m_bMayClose = false;

		/*------------------------------------------------------------------------------------------------
		** C O N S T R U C T O R
		**----------------------------------------------------------------------------------------------*/
		public MergeWaitDialog() {
			InitializeComponent();
			LocalizeDialog();
		}

		/*------------------------------------------------------------------------------------------------
		** LocalizeDialog method
		** Localize the dialog's data.
		**----------------------------------------------------------------------------------------------*/
		private void LocalizeDialog() {
			this.Text = Лоцман_добавка.Properties.Resources.MERGE_WAIT_DLG_TITLE;
			m_lblMerging.Text = Лоцман_добавка.Properties.Resources.MERGE_WAIT_DLG_LBL_MERGING;
		}

		/*------------------------------------------------------------------------------------------------
		** M E T H O D S
		**----------------------------------------------------------------------------------------------*/

		/*------------------------------------------------------------------------------------------------
		** CloseDialog method
		** Initalize the closing of the dialog.
		**----------------------------------------------------------------------------------------------*/
		public void CloseDialog() {
			m_bMayClose = true;
			Close();
		}

		/*------------------------------------------------------------------------------------------------
		** E V E N T H A N D L E R 
		**----------------------------------------------------------------------------------------------*/

		/*------------------------------------------------------------------------------------------------
		** MergeWaitDialog_FormClosing method
		** Stop the closing if closing is not intialized by the CloseDialog method.
		**----------------------------------------------------------------------------------------------*/
		private void MergeWaitDialog_FormClosing(object sender, FormClosingEventArgs e) {
			if ((e.CloseReason == CloseReason.UserClosing) && !m_bMayClose) e.Cancel = true;
			else m_bMayClose = false;
		}
	}
}
