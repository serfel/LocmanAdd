/*------------------------------------------------------------------------------------------------
** program:			TX Text Control Hyperlinks Sample
** description:	Shows you how to add hypertext links and targets to your documents, and how to 
**                  respond to events fired by TX Text Control when a hypertext link is clicked					
**
** copyright:		© Text Control GmbH
**----------------------------------------------------------------------------------------------*/
using System.Windows.Forms;

namespace Step3 {

    public class frmEditTargets : System.Windows.Forms.Form {

        private System.Windows.Forms.Button cmdGoTo;
        private System.Windows.Forms.Button cmdRemove;
        private System.Windows.Forms.Button cmdClose;
        private System.Windows.Forms.ListBox lstTargets;
        private System.ComponentModel.Container components = null;

        public frmEditTargets() {
            InitializeComponent();
        }

        protected override void Dispose(bool disposing) {
            if (disposing) {
                if (components != null) {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.lstTargets = new System.Windows.Forms.ListBox();
            this.cmdGoTo = new System.Windows.Forms.Button();
            this.cmdRemove = new System.Windows.Forms.Button();
            this.cmdClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lstTargets
            // 
            this.lstTargets.Location = new System.Drawing.Point(8, 8);
            this.lstTargets.Name = "lstTargets";
            this.lstTargets.Size = new System.Drawing.Size(176, 134);
            this.lstTargets.TabIndex = 0;
            // 
            // cmdGoTo
            // 
            this.cmdGoTo.Location = new System.Drawing.Point(200, 8);
            this.cmdGoTo.Name = "cmdGoTo";
            this.cmdGoTo.Size = new System.Drawing.Size(96, 24);
            this.cmdGoTo.TabIndex = 1;
            this.cmdGoTo.Text = "Go to";
            this.cmdGoTo.Click += new System.EventHandler(this.cmdGoTo_Click);
            // 
            // cmdRemove
            // 
            this.cmdRemove.Location = new System.Drawing.Point(200, 40);
            this.cmdRemove.Name = "cmdRemove";
            this.cmdRemove.Size = new System.Drawing.Size(96, 24);
            this.cmdRemove.TabIndex = 2;
            this.cmdRemove.Text = "Remove";
            this.cmdRemove.Click += new System.EventHandler(this.cmdRemove_Click);
            // 
            // cmdClose
            // 
            this.cmdClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdClose.Location = new System.Drawing.Point(200, 120);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(96, 24);
            this.cmdClose.TabIndex = 3;
            this.cmdClose.Text = "Close";
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // frmEditTargets
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.CancelButton = this.cmdClose;
            this.ClientSize = new System.Drawing.Size(304, 150);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.cmdRemove);
            this.Controls.Add(this.cmdGoTo);
            this.Controls.Add(this.lstTargets);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "frmEditTargets";
            this.Text = "Document Targets";
            this.Load += new System.EventHandler(this.frmEditTargets_Load);
            this.ResumeLayout(false);

        }
        #endregion


        public TXTextControl.TextControl tx;

        // Fill listbox with target names and select first item
        private void frmEditTargets_Load(object sender, System.EventArgs e) {
            foreach (TXTextControl.DocumentTarget Target in tx.DocumentTargets)
                lstTargets.Items.Add("#" + Target.TargetName);
            if (lstTargets.Items.Count > 0)
                lstTargets.SelectedIndex = 0;
            EnableButtons();
        }

        // Enable Goto and Remove buttons only if an item  is selected 
        // in the targets listbox
        private void EnableButtons() {
            cmdGoTo.Enabled = (lstTargets.SelectedItem != null);
            cmdRemove.Enabled = cmdGoTo.Enabled;
        }

        // Close form
        private void cmdClose_Click(object sender, System.EventArgs e) {
            Close();
        }

        // Jump to a target
        private void cmdGoTo_Click(object sender, System.EventArgs e) {
            foreach (TXTextControl.DocumentTarget Target in tx.DocumentTargets)
                if ("#" + Target.TargetName == lstTargets.SelectedItem.ToString())
                    Target.ScrollTo();
            Close();
        }

        // Remove a target from the document and the targets listbox
        private void cmdRemove_Click(object sender, System.EventArgs e) {
            foreach (TXTextControl.DocumentTarget Target in tx.DocumentTargets)
                if ("#" + Target.TargetName == lstTargets.SelectedItem.ToString()) {
                    if (TargetInUse(Target)) {
                        MessageBox.Show("Target cannot be removed because it is in use by a document link.",
                            Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else {
                        tx.DocumentTargets.Remove(Target);
                        lstTargets.Items.Remove(lstTargets.SelectedItem);
                        if (lstTargets.Items.Count > 0)
                            lstTargets.SelectedIndex = 0;
                        EnableButtons();
                    }
                }
        }

        // Check if a target can be deleted, or if it is pointed to by a link
        private bool TargetInUse(TXTextControl.DocumentTarget Target) {
            bool Result = false;

            foreach (TXTextControl.DocumentLink DocumentLink in tx.DocumentLinks)
                if (DocumentLink.DocumentTarget.TargetName == Target.TargetName)
                    Result = true;
            return Result;
        }
    }
}
