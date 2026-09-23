/*------------------------------------------------------------------------------------------------
** program:			TX Text Control Hyperlinks Sample
** description:	Shows you how to add hypertext links and targets to your documents, and how to 
**                  respond to events fired by TX Text Control when a hypertext link is clicked					
**
** copyright:		© Text Control GmbH
**----------------------------------------------------------------------------------------------*/
using System;
using System.Windows.Forms;

namespace Step1 {

    public class Form1 : System.Windows.Forms.Form {

        private TXTextControl.TextControl textControl1;
        private System.Windows.Forms.Button cmdInsertHyperlink;
        private System.Windows.Forms.Button cmdSaveAs;
        private System.ComponentModel.Container components = null;

        public Form1() {
            // Required for Windows Form Designer support
            InitializeComponent();

            // TODO: Add any constructor code after InitializeComponent call
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
        private void InitializeComponent() {
            this.textControl1 = new TXTextControl.TextControl();
            this.cmdInsertHyperlink = new System.Windows.Forms.Button();
            this.cmdSaveAs = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textControl1
            // 
            this.textControl1.AllowDrag = true;
            this.textControl1.AllowDrop = true;
            this.textControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textControl1.Font = new System.Drawing.Font("Arial", 10F);
            this.textControl1.Location = new System.Drawing.Point(0, 0);
            this.textControl1.Name = "textControl1";
            this.textControl1.PageMargins.Bottom = 79.03;
            this.textControl1.PageMargins.Left = 79.03;
            this.textControl1.PageMargins.Right = 79.03;
            this.textControl1.PageMargins.Top = 79.03;
            this.textControl1.Size = new System.Drawing.Size(384, 176);
            this.textControl1.TabIndex = 0;
            this.textControl1.ViewMode = TXTextControl.ViewMode.Normal;
            // 
            // cmdInsertHyperlink
            // 
            this.cmdInsertHyperlink.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdInsertHyperlink.Location = new System.Drawing.Point(16, 192);
            this.cmdInsertHyperlink.Name = "cmdInsertHyperlink";
            this.cmdInsertHyperlink.Size = new System.Drawing.Size(144, 24);
            this.cmdInsertHyperlink.TabIndex = 1;
            this.cmdInsertHyperlink.Text = "Insert hypertext link";
            this.cmdInsertHyperlink.Click += new System.EventHandler(this.cmdInsertHyperlink_Click);
            // 
            // cmdSaveAs
            // 
            this.cmdSaveAs.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdSaveAs.Location = new System.Drawing.Point(168, 192);
            this.cmdSaveAs.Name = "cmdSaveAs";
            this.cmdSaveAs.Size = new System.Drawing.Size(144, 24);
            this.cmdSaveAs.TabIndex = 2;
            this.cmdSaveAs.Text = "Save as HTML file";
            this.cmdSaveAs.Click += new System.EventHandler(this.cmdSaveAs_Click);
            // 
            // Form1
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(384, 230);
            this.Controls.Add(this.cmdSaveAs);
            this.Controls.Add(this.cmdInsertHyperlink);
            this.Controls.Add(this.textControl1);
            this.Name = "Form1";
            this.Text = "TX Text Control - Hyperlinks Step 1";
            this.ResumeLayout(false);

        }
        #endregion

        [STAThread]
        static void Main() {
            Application.Run(new Form1());
        }


        private void cmdInsertHyperlink_Click(object sender, System.EventArgs e) {
            // Create a HypertextLink object
            TXTextControl.HypertextLink MyLink =
                new TXTextControl.HypertextLink(
                "Text Control Web Site",
                "http://www.textcontrol.com");

            // Insert the hyperlink into the document
            textControl1.HypertextLinks.Add(MyLink);
        }

        private void cmdSaveAs_Click(object sender, System.EventArgs e) {
            textControl1.Save(TXTextControl.StreamType.HTMLFormat);
        }
    }
}
