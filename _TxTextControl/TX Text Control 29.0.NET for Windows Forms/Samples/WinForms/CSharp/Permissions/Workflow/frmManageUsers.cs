/*------------------------------------------------------------------------------------------------
** program:			TX Text Control Permissions Workflow Sample
** description:	Explains the typical workflow when working with document permissions and user 
**						specific editable regions.
**
** copyright:		© Text Control GmbH
**----------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Workflow {

    public partial class frmManageUsers : Form {

        public List<User> Users { get; set; }

        // Form constructor
        public frmManageUsers(List<User> Users) {
            this.Users = Users;
            InitializeComponent();
            UpdateUserList();
        }

        private void btnNew_Click(object sender, EventArgs e) {
            // open "new user" form
            frmNewUser frmNewUser = new frmNewUser();

            if (frmNewUser.ShowDialog(this) == DialogResult.OK) {
                // check if user already exists
                if (Users.Where(p => p.Name == frmNewUser.NewUser.Name).Count() == 0) {
                    // add a new user to the list of users
                    Users.Add(frmNewUser.NewUser);
                    // update the list view
                    UpdateUserList();
                }
                else
                    MessageBox.Show("Username already exists. Please choose another username.",
                        "New User", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void UpdateUserList() {
            lbUsers.Items.Clear();
            lbUsers.DisplayMember = "Name";
            lbUsers.Items.AddRange(Users.ToArray());

            if (lbUsers.Items.Count > 0)
                lbUsers.SelectedIndex = 0;
        }

        private void btnDelete_Click(object sender, EventArgs e) {
            // delete user from list of users
            Users.Remove((User)lbUsers.SelectedItem);
            UpdateUserList();
        }

        private void lbUsers_SelectedIndexChanged(object sender, EventArgs e) {
            btnDelete.Enabled = (lbUsers.SelectedItem != null) ? true : false;
        }

        private void btnOK_Click(object sender, EventArgs e) {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
