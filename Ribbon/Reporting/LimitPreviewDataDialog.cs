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
	** Class LimitPreviewDataDialog
	** Implements a dialog for limiting the count of previews by setting a maximum.
	**----------------------------------------------------------------------------------------------*/
	public partial class LimitPreviewDataDialog : Form {


		/*-------------------------------------------------------------------------------------------------------------
		** P R O P E R T I E S 
		**-----------------------------------------------------------------------------------------------------------*/

		internal int MaxPreviews {
			get { return (int)m_nudResultsCount.Value; }
		}

		/*-------------------------------------------------------------------------------------------------------------
		** C O N S T R U C T O R
		**-----------------------------------------------------------------------------------------------------------*/
		public LimitPreviewDataDialog() {
			InitializeComponent();

			// Localize
			Text = Лоцман_добавка.Properties.Resources.LIMIT_PREVIEW_DATA_DLG_TITLE;
			m_lblText.Text = Лоцман_добавка.Properties.Resources.LIMIT_PREVIEW_DATA_DLG_TEXT;
			m_btnOK.Text = Лоцман_добавка.Properties.Resources.LIMIT_PREVIEW_DATA_DLG_OK;
			m_btnCancel.Text = Лоцман_добавка.Properties.Resources.LIMIT_PREVIEW_DATA_DLG_CANCEL;
		}//Constructor


		/*-------------------------------------------------------------------------------------------------------------
		** E V E N T H A N D L E R
		**-----------------------------------------------------------------------------------------------------------*/

		/*-------------------------------------------------------------------------------------------------------------
		** m_btnOK_Click
		** Close the dialog and return 'OK' as DialogResult for signaling a maximum count of previews is choosen.
		**-----------------------------------------------------------------------------------------------------------*/
		private void m_btnOK_Click(object sender, EventArgs e) {
			this.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.Close();
		}

		/*-------------------------------------------------------------------------------------------------------------
		** m_btnCancel_Click
		** Close the dialog and return 'Cancel' as DialogResult for signaling the action is cancled.
		**-----------------------------------------------------------------------------------------------------------*/
		private void m_btnCancel_Click(object sender, EventArgs e) {
			this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.Close();
		}

	}
}
