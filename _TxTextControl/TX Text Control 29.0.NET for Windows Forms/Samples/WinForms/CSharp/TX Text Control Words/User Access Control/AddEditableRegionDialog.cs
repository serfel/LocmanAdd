/*-------------------------------------------------------------------------------------------------------------
** program:			TX Text Control Words
** description:	Implements a typical word processing application build up on the main features of TextControl's Components. 
**
** copyright:		© Text Control GmbH
**-----------------------------------------------------------------------------------------------------------*/
using System;
using System.Linq;
using System.Windows.Forms;
using TXTextControl;

namespace TX_Text_Control_Words.User_Access_Control {

	/*-------------------------------------------------------------------------------------------------------
	** Class AddEditableRegionDialog
	** Implements a dialog for choosing an user and adding a new EditableRegion to the document.
	** The user access control is used for getting a list of available users and for opening a dialog for
	** managing the users.
	**-----------------------------------------------------------------------------------------------------*/
	public partial class AddEditableRegionDialog : Form {

		/*-------------------------------------------------------------------------------------------------------
		** M E M B E R S
		**-----------------------------------------------------------------------------------------------------*/
		private UserAccessControl m_uac;

		/*-------------------------------------------------------------------------------------------------------
		** C O N S T R U C T O R
		**-----------------------------------------------------------------------------------------------------*/
		public AddEditableRegionDialog(UserAccessControl uac) {
			InitializeComponent();

			m_uac = uac;

			// Display the user's name in list view
			m_lbUsers.DisplayMember = "Name";
			m_lbUsers.Items.AddRange(m_uac.KnownUsers.ToArray());

			// Refresh list view on change of user collection
			m_uac.KnownUsers.CollectionChanged += KnownUsers_CollectionChanged;

			LocalizeDialog();
		}

		/*-------------------------------------------------------------------------------------------------------
		** E V E N T H A N D L E R
		**-----------------------------------------------------------------------------------------------------*/

		/*-------------------------------------------------------------------------------------------------------
		** KnownUsers_CollectionChanged method
		** Updates the list view by clearing the list and adding all available users in the User Access Control
		** to list view. Disables the OK Button because none user is selected after updating the list view.
		**-----------------------------------------------------------------------------------------------------*/
		void KnownUsers_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) {
			// Refresh the listbox collection because at least one item is removed or added
			m_lbUsers.Items.Clear();
			ExtendedObservableCollection<UserInfo> newKnownUsers = (ExtendedObservableCollection<UserInfo>)sender;
			m_lbUsers.Items.AddRange(newKnownUsers.ToArray());
			// Refresh state of OK-Button
			m_btnOK.Enabled = false;
		}

		/*-------------------------------------------------------------------------------------------------------
		** m_btnOK_Click method
		** Add foreach selected user an EditableRegion to the TextControl which is managed by the user access
		** control and close this dialog.
		**-----------------------------------------------------------------------------------------------------*/
		private void m_btnOK_Click(object sender, EventArgs e) {
			this.DialogResult = System.Windows.Forms.DialogResult.OK;

			// Create the regions for the selected users
			foreach (UserInfo selectedUI in m_lbUsers.SelectedItems) {
				m_uac.ConnectedTextControl.EditableRegions.Add(new EditableRegion(selectedUI.Name, 0));
			}

			this.Close();
		}

		/*-------------------------------------------------------------------------------------------------------
		** m_btnManage_Click method
		** Show the UserAdminDialog.
		**-----------------------------------------------------------------------------------------------------*/
		private void m_btnManage_Click(object sender, EventArgs e) {
			m_uac.ShowUserAdminDialog();
		}

		/*-------------------------------------------------------------------------------------------------------
		** m_lbUsers_SelectedValueChanged method
		** Update the OK-button's enablestate when minimum one user is selected in the listbox.
		**-----------------------------------------------------------------------------------------------------*/
		private void m_lbUsers_SelectedValueChanged(object sender, EventArgs e) {
			m_btnOK.Enabled = m_lbUsers.SelectedItems.Count > 0;
		}

		/*-------------------------------------------------------------------------------------------------------
		** m_btnCancel_Click method
		** Cancels the adding of an EditableRegion and closes the dialog.
		**-----------------------------------------------------------------------------------------------------*/
		private void m_btnCancel_Click(object sender, EventArgs e) {
			this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.Close();
		}

		/*-------------------------------------------------------------------------------------------------------
		** H E L P E R   M E T H O D S
		**-----------------------------------------------------------------------------------------------------*/

		/*-------------------------------------------------------------------------------------------------------
		** LocalizeDialog method
		**-----------------------------------------------------------------------------------------------------*/
		private void LocalizeDialog() {
			this.Text = Properties.Resources.USER_ADD_REGION_DLG_TITLE;
			m_btnOK.Text = Properties.Resources.BTN_OK;
			m_btnCancel.Text = Properties.Resources.BTN_CANCEL;
			m_btnManage.Text = Properties.Resources.USER_ACC_DLG_BTN_MANAGE;
			m_lblRegUsers.Text = Properties.Resources.USER_ACC_DLG_LBL_USERS;
		}
	}
}
