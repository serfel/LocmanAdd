/*------------------------------------------------------------------------------------------------
** program:			TX Text Control Permissions Workflow Sample
** description:	Explains the typical workflow when working with document permissions and user 
**						specific editable regions.
**
** copyright:		© Text Control GmbH
**----------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Workflow {

    public partial class frmLogin : Form {

        public string Username { get; set; }

        private List<User> m_users;

        // Form constructor
        public frmLogin(List<User> Users) {
            InitializeComponent();

            // fill the combo box with usernames
            m_users = Users;
            cbUsernames.Items.Clear();
            cbUsernames.Items.AddRange(m_users.ToArray());
            cbUsernames.DisplayMember = "Name";

            if (cbUsernames.Items.Count > 0)
                cbUsernames.SelectedIndex = 0;
        }

        private void CheckValues(object sender, EventArgs e) {
            btnOK.Enabled =
                (cbUsernames.SelectedIndex > -1 && tbPassword.Text != "") ? true : false;
        }

        private void btnOK_Click(object sender, EventArgs e) {
            // check whether password is correct or not
            if (tbPassword.Text == ((User)cbUsernames.SelectedItem).Password) {
                Username = ((User)cbUsernames.SelectedItem).Name;
                this.DialogResult = DialogResult.OK;
            }
            else
                MessageBox.Show("Password is not correct.",
                    "Login", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
