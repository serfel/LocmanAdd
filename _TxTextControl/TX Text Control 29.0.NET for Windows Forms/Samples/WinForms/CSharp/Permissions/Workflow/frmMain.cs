/*------------------------------------------------------------------------------------------------
** program:			TX Text Control Permissions Workflow Sample
** description:	Explains the typical workflow when working with document permissions and user 
**						specific editable regions.
**
** copyright:		© Text Control GmbH
**----------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Workflow {

    public partial class frmMain : Form {

        public List<User> Users { get; set;}
        private byte[] m_bDocument;

        // Form constructor
        public frmMain() {
            InitializeComponent();

            // read sample document
            m_bDocument = File.ReadAllBytes("permission_document.tx");
            Users = new List<User>();
        }

        private void btnManageUsers_Click(object sender, EventArgs e) {
            // open the "manage users" dialog
            frmManageUsers frmManageUsers = new frmManageUsers(Users);

            if (frmManageUsers.ShowDialog(this) == DialogResult.OK) {
                // set the users
                Users = frmManageUsers.Users;
            }

            gbDesignDocument.Enabled = (Users.Count != 0) ? true : false;
        }

        private void btnDesignDocument_Click(object sender, EventArgs e) {
            // open the editor form in admin mode
            frmEditor editor = new frmEditor(m_bDocument, Users.Select(x => x.Name).ToArray());

            editor.ShowDialog(this);

            // store the saved document
            m_bDocument = editor.Document;
            gbOpenDocument.Enabled = true;
        }

        private void btnOpenDocument_Click(object sender, EventArgs e) {
            // open the login dialog
            frmLogin login = new frmLogin(Users);

            if (login.ShowDialog() == DialogResult.OK) {
                // open the editor in user mode
                frmEditor editor = new frmEditor(m_bDocument, login.Username);

                editor.ShowDialog(this);

                // store  the saved document
                m_bDocument = editor.Document;
            }
        }
    }
}
