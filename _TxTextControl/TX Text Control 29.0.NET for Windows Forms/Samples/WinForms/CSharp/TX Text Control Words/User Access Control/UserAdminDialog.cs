/*-------------------------------------------------------------------------------------------------------------
** program:			TX Text Control Words
** description:	Implements a typical word processing application build up on the main features of 
**						TextControl's Components. 
**
** copyright:		© Text Control GmbH
**-----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace TX_Text_Control_Words {

	/*-------------------------------------------------------------------------------------------------------------
	** Class UserAdminDialog
	** Implements a dialog for managing the available users in this application.
	**-----------------------------------------------------------------------------------------------------------*/
	public partial class UserAdminDialog : Form {

		/*-------------------------------------------------------------------------------------------------------------
		** M E M B E R S
		**-----------------------------------------------------------------------------------------------------------*/

		private BindingList<UserInfo> m_users; // Available users in this application

		/*-------------------------------------------------------------------------------------------------------------
		** C O N S T R U C T O R
		**-----------------------------------------------------------------------------------------------------------*/

		public UserAdminDialog(List<UserInfo> users) {
			InitializeComponent();
			LocalizeDialog();

			// Init listbox.
			m_users = new BindingList<UserInfo>(users.ConvertAll(ui => new UserInfo(ui)).OrderBy(ui => ui.Name).ToList());	// Clone and sort list
			m_lbUsers.DataSource = m_users;
		}

		/*-------------------------------------------------------------------------------------------------------------
		** P R O P E R T I E S
		**-----------------------------------------------------------------------------------------------------------*/

		/*-------------------------------------------------------------------------------------------------------------
		** Users
		** New list of application users.
		**-----------------------------------------------------------------------------------------------------------*/
		public List<UserInfo> Users { 
			get { return new List<UserInfo>(m_users); } 
		}

		/*-------------------------------------------------------------------------------------------------------------
		** E V E N T H A N D L E R S
		**-----------------------------------------------------------------------------------------------------------*/

		/*-------------------------------------------------------------------------------------------------------------
		** LbUsers_SelectedValueChanged method
		** Enable the buttons for editing and deleting a user in the listbox if any is selected.
		**-----------------------------------------------------------------------------------------------------------*/
		private void LbUsers_SelectedValueChanged(object sender, EventArgs e) {
			m_btnEdit.Enabled = m_lbUsers.SelectedValue != null;
			m_btnDelete.Enabled = m_lbUsers.SelectedValue != null;
		}

		/*-------------------------------------------------------------------------------------------------------------
		** BtnEdit_Click method
		** Show dialog for editing the user's info and apply the changes to user if a renaming of the name does not
		** conflicts with another user.
		**-----------------------------------------------------------------------------------------------------------*/
		private void BtnEdit_Click(object sender, EventArgs e) {
			var userInfo = m_lbUsers.SelectedValue as UserInfo;
			if (userInfo == null) return;

			// Show edit user dialog
			var dlg = new EditUserDialog(userInfo)
			{
				RequestCurrentPassword = true,
				AllowEmptyPassword = true,
				RightToLeft = this.RightToLeft
			};

			if (dlg.ShowDialog(this) == System.Windows.Forms.DialogResult.OK) {
				// Ensure changed user name does not exist already
				if (!dlg.Username.Equals(userInfo.Name, StringComparison.OrdinalIgnoreCase) && m_users.Any(ui => ui.Name.Equals(dlg.Username, StringComparison.OrdinalIgnoreCase))) {
					Utils.MessageBox.Show(this, Properties.Resources.EDIT_USER_DLG_USER_EXISTS, ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				}
				else {
					userInfo.Name = dlg.Username;
					userInfo.Password = dlg.NewPassword;
				}
			}
		}

		/*-------------------------------------------------------------------------------------------------------------
		** BtnDelete_Click method
		** Deletes the selected user.
		**-----------------------------------------------------------------------------------------------------------*/
		private void BtnDelete_Click(object sender, EventArgs e) {
			var item = m_lbUsers.SelectedValue as UserInfo;
			if (item != null) m_users.Remove(item);
		}

		/*-------------------------------------------------------------------------------------------------------------
		** BtnNew_Click method
		** Show dialog for creating a new user and add them to userlist if no one else exists with the same name.
		**-----------------------------------------------------------------------------------------------------------*/
		private void BtnNew_Click(object sender, EventArgs e) {

			var dlg = new EditUserDialog() { 
				RightToLeft = this.RightToLeft,
				Owner = this
			};

			if (dlg.ShowDialog(this) == System.Windows.Forms.DialogResult.OK) {
				if (m_users.Any(ui => ui.Name.Equals(dlg.Username, StringComparison.OrdinalIgnoreCase))) {

					// User already exists.
					Utils.MessageBox.Show(this, 
						Properties.Resources.EDIT_USER_DLG_USER_EXISTS, 
						ProductName, MessageBoxButtons.OK,  
						MessageBoxIcon.Exclamation);

				}
				else {

					// Add new user.
					m_users.Add(new UserInfo(dlg.Username, dlg.NewPassword));
				}
			}
		}

		/*-------------------------------------------------------------------------------------------------------------
		** BtnOK_Click method
		** Close dialog and return DialogResult.OK.
		**-----------------------------------------------------------------------------------------------------------*/
		private void BtnOK_Click(object sender, EventArgs e) {
			DialogResult = System.Windows.Forms.DialogResult.OK;
			Close();
		}


		/*-------------------------------------------------------------------------------------------------------------
		** H E L P E R   M E T H O D S
		**-----------------------------------------------------------------------------------------------------------*/

		/*-------------------------------------------------------------------------------------------------------------
		** LocalizeDialog method
		** Localize this dialog.
		**-----------------------------------------------------------------------------------------------------------*/
		private void LocalizeDialog() {
			this.Text = Properties.Resources.USER_ADMIN_DLG_TITLE;
			m_btnOK.Text = Properties.Resources.BTN_OK;
			m_btnCancel.Text = Properties.Resources.BTN_CANCEL;
			m_btnDelete.Text = Properties.Resources.USER_ADMIN_DLG_BTN_DELETE;
			m_btnNew.Text = Properties.Resources.USER_ADMIN_DLG_BTN_NEW;
			m_btnEdit.Text = Properties.Resources.USER_ADMIN_DLG_BTN_EDIT;
			m_lblUsers.Text = Properties.Resources.USER_ADMIN_DLG_LBL_USERS;
		}
	}
}
