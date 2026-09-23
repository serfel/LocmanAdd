/*------------------------------------------------------------------------------------------------
** program:			TX Text Control Hyperlinks Sample
** description:	Shows you how to add hypertext links and targets to your documents, and how to 
**                  respond to events fired by TX Text Control when a hypertext link is clicked					
**
** copyright:		© Text Control GmbH
**----------------------------------------------------------------------------------------------*/
using System.Windows.Forms;

namespace Step3 {

    public class frmHyperlinks : System.Windows.Forms.Form {

        private System.Windows.Forms.Button cmdOK;
        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtLinkedText;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboLinkTo;
        private System.ComponentModel.Container components = null;

        public frmHyperlinks() {
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
            this.cmdOK = new System.Windows.Forms.Button();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtLinkedText = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cboLinkTo = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmdOK
            // 
            this.cmdOK.Location = new System.Drawing.Point(272, 16);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(88, 24);
            this.cmdOK.TabIndex = 4;
            this.cmdOK.Text = "OK";
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // cmdCancel
            // 
            this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdCancel.Location = new System.Drawing.Point(272, 48);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(88, 24);
            this.cmdCancel.TabIndex = 5;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtLinkedText);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(8, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(248, 72);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Link text";
            // 
            // txtLinkedText
            // 
            this.txtLinkedText.Location = new System.Drawing.Point(16, 42);
            this.txtLinkedText.Name = "txtLinkedText";
            this.txtLinkedText.Size = new System.Drawing.Size(216, 20);
            this.txtLinkedText.TabIndex = 3;
            this.txtLinkedText.Text = "";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(16, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(192, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Enter text to be displayed for the link";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cboLinkTo);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(8, 88);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(248, 96);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Link location";
            // 
            // cboLinkTo
            // 
            this.cboLinkTo.Location = new System.Drawing.Point(16, 64);
            this.cboLinkTo.Name = "cboLinkTo";
            this.cboLinkTo.Size = new System.Drawing.Size(208, 21);
            this.cboLinkTo.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(16, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(192, 32);
            this.label2.TabIndex = 2;
            this.label2.Text = "Enter a web page location or select a target from the popup list:";
            // 
            // frmHyperlinks
            // 
            this.AcceptButton = this.cmdOK;
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.CancelButton = this.cmdCancel;
            this.ClientSize = new System.Drawing.Size(370, 192);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "frmHyperlinks";
            this.Text = "Hypertext Link";
            this.Load += new System.EventHandler(this.frmHyperlinks_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        #endregion

        public TXTextControl.TextControl tx;

        // Check if both a link text and a target have been entered. Depending on
        // the type of link, create a hypertext link or document link and insert
        // it into the document. If a link already exists, keep it and change its 
        // properties. Finally, close the form.
        private void cmdOK_Click(object sender, System.EventArgs e) {
            if (txtLinkedText.Text == "")
                MessageBox.Show("Hyperlink contains no text. Please enter the text to be shown as a hyperlink in the Linked Text field.", Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (cboLinkTo.Text == "")
                MessageBox.Show("No target specified. Please enter a target URL in the Link To field.", Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            else {
                TXTextControl.HypertextLink HyperLink = tx.HypertextLinks.GetItem();
                TXTextControl.DocumentLink DocumentLink = tx.DocumentLinks.GetItem();

                if (cboLinkTo.Text.StartsWith("#")) {
                    // Find the target
                    TXTextControl.DocumentTarget SelectedTarget = null;
                    foreach (TXTextControl.DocumentTarget CurrentTarget in tx.DocumentTargets)
                        if ("#" + CurrentTarget.TargetName == cboLinkTo.Text)
                            SelectedTarget = CurrentTarget;

                    if (DocumentLink == null) {
                        // Insert a new document link
                        TXTextControl.DocumentLink NewLink =
                            new TXTextControl.DocumentLink(
                            txtLinkedText.Text,
                            SelectedTarget);
                        NewLink.DoubledInputPosition = true;
                        tx.DocumentLinks.Add(NewLink);
                    }
                    else {
                        // Update an existing document link
                        DocumentLink.DocumentTarget = SelectedTarget;
                        DocumentLink.Text = txtLinkedText.Text;
                    }
                }
                else {
                    if (HyperLink == null) {
                        // Insert a new hypertext link
                        TXTextControl.HypertextLink NewLink =
                            new TXTextControl.HypertextLink(
                            txtLinkedText.Text, cboLinkTo.Text);
                        NewLink.DoubledInputPosition = true;
                        tx.HypertextLinks.Add(NewLink);
                    }
                    else {
                        // Update an existing hypertext link
                        HyperLink.Text = txtLinkedText.Text;
                        HyperLink.Target = cboLinkTo.Text;
                    }
                }

                Close();
            }
        }

        // Close the form
        private void cmdCancel_Click(object sender, System.EventArgs e) {
            Close();
        }

        // Initialize the form's text box and combo box. Information displayed
        // will depend on whether a new hyperlink is inserted or an existing
        // hyperlink is edited.
        private void frmHyperlinks_Load(object sender, System.EventArgs e) {
            TXTextControl.HypertextLink HyperLink = tx.HypertextLinks.GetItem();
            TXTextControl.DocumentLink DocumentLink = tx.DocumentLinks.GetItem();

            if (HyperLink != null) {
                // If there is an existing hypertext link at the input position,
                // copy its text and target to the text boxes on the form.
                txtLinkedText.Text = HyperLink.Text;
                cboLinkTo.Text = HyperLink.Target;
            }
            else if (DocumentLink != null) {
                txtLinkedText.Text = DocumentLink.Text;
                cboLinkTo.Text = DocumentLink.DocumentTarget.Name;
            }
            else {
                // If there is no hypertext link at the input position, but
                // some text has been selected, then copy this text to the
                // Linked Text text box.
                if (tx.Selection.Length > 0)
                    txtLinkedText.Text = tx.Selection.Text;
            }

            // Initialize Targets listbox
            foreach (TXTextControl.DocumentTarget Target in tx.DocumentTargets)
                cboLinkTo.Items.Add("#" + Target.TargetName);
        }
    }
}
