/*------------------------------------------------------------------------------------------------
** program:			TX Text Control Permissions Workflow Sample
** description:	Explains the typical workflow when working with document permissions and user 
**						specific editable regions.
**
** copyright:		© Text Control GmbH
**----------------------------------------------------------------------------------------------*/
using System;
using System.Windows.Forms;

namespace Workflow {

    public partial class frmNewUser : Form {

        public User NewUser { get; set; }

        public frmNewUser() {
            InitializeComponent();
        }

        private void TextBoxChanged(object sender, EventArgs e) {
            // enable OK button, if all form elements have been completed
            btnOK.Enabled = ((tbUsername.Text == "" || tbPassword.Text == "" || tbPasswordConfirm.Text == "") ||
                tbPassword.Text != tbPasswordConfirm.Text) ? false : true;
        }

        private void btnOK_Click(object sender, EventArgs e) {
            // create a new user
            this.NewUser = new User() {
                Name = tbUsername.Text,
                Password = tbPassword.Text
            };

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
