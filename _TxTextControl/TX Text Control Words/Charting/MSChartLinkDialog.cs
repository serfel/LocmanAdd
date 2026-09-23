/*-------------------------------------------------------------------------------------------------------------
** program:			TX Text Control Words
** description:	Implements a typical word processing application build up on the main features of 
**						TextControl's Components. 
**
** copyright:		© Text Control GmbH
**-----------------------------------------------------------------------------------------------------------*/
using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace TX_Text_Control_Words {

	/*------------------------------------------------------------------------------------------------
	** Class MSChartLinkDialog
	** Implements a dialog for displaying a message about the missing Chart Control.
	**----------------------------------------------------------------------------------------------*/
	public partial class MSChartLinkDialog : Form {

		/*------------------------------------------------------------------------------------------------
		** P U B L I C    S T A T I C
		**----------------------------------------------------------------------------------------------*/

		/*------------------------------------------------------------------------------------------------
		** Show method
		** Shows the dialog.
		**----------------------------------------------------------------------------------------------*/
		public static DialogResult Show(Form owner) {
			var frm = new MSChartLinkDialog();
			frm.RightToLeft = owner.RightToLeft;
			return frm.ShowDialog(owner);
		}

		/*------------------------------------------------------------------------------------------------
		** C O N S T R U C T O R
		**----------------------------------------------------------------------------------------------*/

		private MSChartLinkDialog() {
			InitializeComponent();
		}

		/*------------------------------------------------------------------------------------------------
		** E V E N T H A N D L E R S
		**----------------------------------------------------------------------------------------------*/

		/*------------------------------------------------------------------------------------------------
		** linkLabel1_LinkClicked method
		** Initial a process which can process the link e.g. a browser application on link clicked.
		**----------------------------------------------------------------------------------------------*/
		private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
			Process.Start("http://www.microsoft.com/download/en/details.aspx?id=14422");
		}

		/*------------------------------------------------------------------------------------------------
		** frmMSChartLink_Load method
		** Sets the dialog title on load.
		**----------------------------------------------------------------------------------------------*/
		private void frmMSChartLink_Load(object sender, EventArgs e) {
			Text = ProductName;
		}

		/*------------------------------------------------------------------------------------------------
		** btnOK_Click method
		** Closes the dialog on click.
		**----------------------------------------------------------------------------------------------*/
		private void btnOK_Click(object sender, EventArgs e) {
			Close();
		}
	}
}
