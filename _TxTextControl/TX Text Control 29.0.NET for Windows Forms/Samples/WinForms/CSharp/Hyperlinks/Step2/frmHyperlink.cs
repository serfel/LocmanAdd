/*------------------------------------------------------------------------------------------------
** program:			TX Text Control Hyperlinks Sample
** description:	Shows you how to add hypertext links and targets to your documents, and how to 
**                  respond to events fired by TX Text Control when a hypertext link is clicked					
**
** copyright:		© Text Control GmbH
**----------------------------------------------------------------------------------------------*/
using System.Windows.Forms;

namespace Step2 {

    public class frmHyperlinks : System.Windows.Forms.Form {

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtLinkedText;
        private System.Windows.Forms.TextBox txtLinkTo;
        private System.Windows.Forms.Button cmdOK;
        private System.Windows.Forms.Button cmdCancel;
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtLinkedText = new System.Windows.Forms.TextBox();
            this.txtLinkTo = new System.Windows.Forms.TextBox();
            this.cmdOK = new System.Windows.Forms.Button();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(8, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Linked text:";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(8, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Link to:";
            // 
            // txtLinkedText
            // 
            this.txtLinkedText.Location = new System.Drawing.Point(80, 16);
            this.txtLinkedText.Name = "txtLinkedText";
            this.txtLinkedText.Size = new System.Drawing.Size(176, 20);
            this.txtLinkedText.TabIndex = 2;
            this.txtLinkedText.Text = "";
            // 
            // txtLinkTo
            // 
            this.txtLinkTo.Location = new System.Drawing.Point(80, 40);
            this.txtLinkTo.Name = "txtLinkTo";
            this.txtLinkTo.Size = new System.Drawing.Size(176, 20);
            this.txtLinkTo.TabIndex = 3;
            this.txtLinkTo.Text = "";
            // 
            // cmdOK
            // 
            this.cmdOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.cmdOK.Location = new System.Drawing.Point(280, 8);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(88, 24);
            this.cmdOK.TabIndex = 4;
            this.cmdOK.Text = "OK";
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // cmdCancel
            // 
            this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdCancel.Location = new System.Drawing.Point(280, 40);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(88, 24);
            this.cmdCancel.TabIndex = 5;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // frmHyperlinks
            // 
            this.AcceptButton = this.cmdOK;
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.CancelButton = this.cmdCancel;
            this.ClientSize = new System.Drawing.Size(376, 78);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdOK);
            this.Controls.Add(this.txtLinkTo);
            this.Controls.Add(this.txtLinkedText);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "frmHyperlinks";
            this.Text = "Hypertext Link";
            this.Load += new System.EventHandler(this.frmHyperlinks_Load);
            this.ResumeLayout(false);

        }
        #endregion

        public TXTextControl.TextControl tx;

        // Check if both a link text and a target have been entered. Create a hypertext link 
        // and insert it into the document. If a link already exists, keep it and change its 
        // properties. Finally, close the form.
        private void cmdOK_Click(object sender, System.EventArgs e) {
            if (txtLinkedText.Text == "")
                MessageBox.Show("Hyperlink contains no text. Please enter the text to be shown as a hyperlink in the Linked Text field.", Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (txtLinkTo.Text == "")
                MessageBox.Show("No target specified. Please enter a target URL in the Link To field.", Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            else {
                TXTextControl.HypertextLink HyperLink = tx.HypertextLinks.GetItem();
                if (HyperLink == null) {
                    // Insert a new link
                    TXTextControl.HypertextLink NewLink =
                        new TXTextControl.HypertextLink(
                        txtLinkedText.Text, txtLinkTo.Text);
                    NewLink.DoubledInputPosition = true;
                    tx.HypertextLinks.Add(NewLink);
                }
                else {
                    // Update an existing link
                    HyperLink.Text = txtLinkedText.Text;
                    HyperLink.Target = txtLinkTo.Text;
                }

                Close();
            }
        }

        // Close the form
        private void cmdCancel_Click(object sender, System.EventArgs e) {
            Close();
        }

        // Initialize the form's text boxes. Information displayed
        // will depend on whether a new hyperlink is inserted or an existing
        // hyperlink is edited.
        private void frmHyperlinks_Load(object sender, System.EventArgs e) {
            TXTextControl.HypertextLink HyperLink = tx.HypertextLinks.GetItem();

            if (HyperLink != null) {
                // If there is an existing hypertext link at the input position,
                // copy its text and target to the text boxes on the form.
                txtLinkedText.Text = HyperLink.Text;
                txtLinkTo.Text = HyperLink.Target;
            }
            else {
                // If there is no hypertext link at the input position, but
                // some text has been selected, then copy this text to the
                // Linked Text text box.
                if (tx.Selection.Length > 0)
                    txtLinkedText.Text = tx.Selection.Text;
            }
        }
    }
}
