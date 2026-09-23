/*------------------------------------------------------------------------------------------------
** program:			TX Text Control Permissions Workflow Sample
** description:	Explains the typical workflow when working with document permissions and user 
**						specific editable regions.
**
** copyright:		© Text Control GmbH
**----------------------------------------------------------------------------------------------*/
using System;
using System.Windows.Forms;
using TXTextControl.Windows.Forms.Ribbon;

namespace Workflow {

    public partial class frmEditor : Form {

        public byte[] Document { get; set; }

        private string[] m_sRegisteredUserNames;
        private string m_username;

        // Form constructor to open editor as administrator
        public frmEditor(byte[] Document, string[] RegisteredUserNames) {
            InitializeComponent();

            this.Document = Document;
            m_sRegisteredUserNames = RegisteredUserNames;
        }

        // Form constructor to open editor as specific user
        public frmEditor(byte[] Document, string Username) {
            InitializeComponent();

            this.Document = Document;
            m_username = Username;
        }

        private void BtnExit_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void frmEditor_Load(object sender, EventArgs e) {
            // add an exit button to ribbon
            RibbonButton btnExit = new RibbonButton();
            btnExit.Text = "Close Editor";
            btnExit.Click += BtnExit_Click;

            ribbon1.ApplicationMenuItems.Add(btnExit);

            // load the document
            textControl1.Load(this.Document, TXTextControl.BinaryStreamType.InternalUnicodeFormat);
            ribbonPermissionsTab1.AllowAddingUserNames = false;

            // if in admin mode, set the registered users
            if (m_sRegisteredUserNames != null) {
                ribbonPermissionsTab1.RegisteredUserNames = m_sRegisteredUserNames;
                this.Text += " [Administrator]";
            }

            // set the current user to enable specific editable regions
            if (m_username != null) {
                textControl1.UserNames = new string[] { m_username };
                textControl1.EditMode = TXTextControl.EditMode.ReadAndSelect;
                this.Text += " [" + m_username + "]";
            }
        }

        private void frmEditor_FormClosing(object sender, FormClosingEventArgs e) {
            // check whether editable regions have been added
            if (textControl1.EditableRegions.Count == 0) {
                e.Cancel = MessageBox.Show("You did not create any editable regions. To test this functionality, please add at least one editable region.\r\nDo you want to exit anyway?",
                    "Document Editor", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.No;
            }

            // save the document
            byte[] bDocument = null;
            textControl1.Save(out bDocument, TXTextControl.BinaryStreamType.InternalUnicodeFormat);
            this.Document = bDocument;
        }
    }
}
