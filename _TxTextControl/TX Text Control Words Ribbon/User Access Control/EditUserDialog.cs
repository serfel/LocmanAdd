/*-------------------------------------------------------------------------------------------------------------
** program:			TX Text Control Words
** description:	Implements a typical word processing application build up on the main features of TextControl's Components. 
**
** copyright:		© Text Control GmbH
**-----------------------------------------------------------------------------------------------------------*/
using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace TX_Text_Control_Words {

	/*-------------------------------------------------------------------------------------------------------
	** Class EditUserDialog
	** Implements a dialog for creating or editing a user. Available settings are the user's name and 
	** password. The current password will be requested on applying the changes.
	**-----------------------------------------------------------------------------------------------------*/
	public partial class EditUserDialog : Form {

		/*-------------------------------------------------------------------------------------------------------
		** M E M B E R S
		**-----------------------------------------------------------------------------------------------------*/
		private bool m_requestCurrentPwd = false;
		private UserInfo m_userInfo;

		/*-------------------------------------------------------------------------------------------------------
		** C O N S T R U C T O R S
		**-----------------------------------------------------------------------------------------------------*/

		/*-------------------------------------------------------------------------------------------------------
		** Construct the dialog for creating a new user info.
		**-----------------------------------------------------------------------------------------------------*/
		public EditUserDialog() : this(null) { }

		/*-------------------------------------------------------------------------------------------------------
		** Construct the dialog for editing the user info.
		**-----------------------------------------------------------------------------------------------------*/
		public EditUserDialog(UserInfo userInfo) {
			InitializeComponent();
			LocalizeDialog();

			m_userInfo = userInfo;
			if (userInfo != null) m_txtName.Text = userInfo.Name;
		}

		/*-------------------------------------------------------------------------------------------------------
		** P R O P E R T I E S
		**-----------------------------------------------------------------------------------------------------*/

		/*-------------------------------------------------------------------------------------------------------
		** Username
		**-----------------------------------------------------------------------------------------------------*/
		public string Username { get { return m_txtName.Text; } }

		/*-------------------------------------------------------------------------------------------------------
		** NewPassword
		**-----------------------------------------------------------------------------------------------------*/
		public string NewPassword { get { return m_txtNewPassword.Text; } }

		/*-------------------------------------------------------------------------------------------------------
		** CurrentPassword
		**-----------------------------------------------------------------------------------------------------*/
		public string CurrentPassword { get { return m_txtCurrentPassword.Text; } }

		/*-------------------------------------------------------------------------------------------------------
		** AllowEmptyPassword
		**-----------------------------------------------------------------------------------------------------*/
		public bool AllowEmptyPassword { get; set; }

		/*-------------------------------------------------------------------------------------------------------
		** RequestCurrentPassword
		** Hide/Show the UI elements for requesting the current password.
		**-----------------------------------------------------------------------------------------------------*/
		public bool RequestCurrentPassword {
			get { return m_requestCurrentPwd; }
			set {
				if (value == m_requestCurrentPwd) return;
				m_requestCurrentPwd = value;
				m_lblNewPassword.Text = value ? Properties.Resources.EDIT_USER_DLG_LBL_NEW_PASSWORD : Properties.Resources.EDIT_USER_DLG_LBL_PASSWORD;
				m_lblCurrentPassword.Visible = value;
				m_txtCurrentPassword.Visible = value;
			}
		}

		/*-------------------------------------------------------------------------------------------------------
		** E V E N T H A N D L E R
		**-----------------------------------------------------------------------------------------------------*/

		/*-------------------------------------------------------------------------------------------------------
		** BtnOK_Click method
		** Validate the user's password if required and return DialogResult.OK if password is valid.
		**-----------------------------------------------------------------------------------------------------*/
		private void BtnOK_Click(object sender, EventArgs e) {
			if (m_requestCurrentPwd && !m_userInfo.ValidatePassword(m_txtCurrentPassword.Text)) {
				Utils.MessageBox.Show(this, Properties.Resources.EDIT_USER_DLG_WRONG_PASSWORD, ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return;
			}
			DialogResult = System.Windows.Forms.DialogResult.OK;
			Close();
		}

		/*-------------------------------------------------------------------------------------------------------
		** TxtNewPassword_TextChanged method
		** Validate textbox data on new password change.
		**-----------------------------------------------------------------------------------------------------*/
		private void TxtNewPassword_TextChanged(object sender, EventArgs e) {
			ValidateInput();
		}

		/*-------------------------------------------------------------------------------------------------------
		** TxtCurrentPassword_TextChanged method
		** Validate textbox data on current password change.
		**-----------------------------------------------------------------------------------------------------*/
		private void TxtCurrentPassword_TextChanged(object sender, EventArgs e) {
			ValidateInput();
		}

		/*-------------------------------------------------------------------------------------------------------
		** TxtPasswordConfirm_TextChanged method
		** Validate textbox data on password's confirmation change.
		**-----------------------------------------------------------------------------------------------------*/
		private void TxtPasswordConfirm_TextChanged(object sender, EventArgs e) {
			ValidateInput();
		}

		/*-------------------------------------------------------------------------------------------------------
		** TxtName_TextChanged method
		** Validate textbox data on user's name change.
		**-----------------------------------------------------------------------------------------------------*/
		private void TxtName_TextChanged(object sender, EventArgs e) {
			ValidateInput();
		}

		/*-------------------------------------------------------------------------------------------------------
		** ValidateInput method
		** Enable OK button if input is valid otherwise disable button.
		** Conditions for enabling:
		**	Username contains minimum one none whitespace character
		** AND Current password field is not empty if requested
		** AND New password is not empty if emptiness is denied
		** AND New password is equal to password confirmation
		**-----------------------------------------------------------------------------------------------------*/
		private void ValidateInput() {
			m_btnOK.Enabled =
				(m_txtName.Text.Trim().Length > 0)
				&& (!m_requestCurrentPwd || (m_txtCurrentPassword.Text.Length > 0))
				&& (AllowEmptyPassword || (m_txtNewPassword.Text.Length > 0))
				&& (m_txtNewPassword.Text == m_txtPasswordConfirm.Text);
		}

		/*-------------------------------------------------------------------------------------------------------
		** Window_Load method
		** Validate the input data on window loaded.
		**-----------------------------------------------------------------------------------------------------*/
		private void Window_Load(object sender, EventArgs e) {
			ValidateInput();
		}

		/*-------------------------------------------------------------------------------------------------------
		** TxtName_Leave method
		** Trim name and replace multiple spaces with one space on keyboard focus leaved the textbox.
		**-----------------------------------------------------------------------------------------------------*/
		private void TxtName_Leave(object sender, EventArgs e) {
			m_txtName.Text = Regex.Replace(m_txtName.Text.Trim(), @"\s+", " ");	// Trim name and replace multiple spaces with one space
		}


		/*-------------------------------------------------------------------------------------------------------
		** M E T H O D S
		**-----------------------------------------------------------------------------------------------------*/

		/*-------------------------------------------------------------------------------------------------------
		** LocalizeDialog method
		**-----------------------------------------------------------------------------------------------------*/
		private void LocalizeDialog() {
			this.Text = Properties.Resources.EDIT_USER_DLG_TITLE;
			m_btnOK.Text = Properties.Resources.BTN_OK;
			m_btnCancel.Text = Properties.Resources.BTN_CANCEL;
			m_lblName.Text = Properties.Resources.EDIT_USER_DLG_LBL_USER_NAME;
			m_lblNewPassword.Text = Properties.Resources.EDIT_USER_DLG_LBL_PASSWORD;
			m_lblCurrentPassword.Text = Properties.Resources.EDIT_USER_DLG_LBL_PASSWORD;
			m_lblPasswordConfirm.Text = Properties.Resources.EDIT_USER_DLG_LBL_PASSWORD_CONFIRM;
		}
	}
}
