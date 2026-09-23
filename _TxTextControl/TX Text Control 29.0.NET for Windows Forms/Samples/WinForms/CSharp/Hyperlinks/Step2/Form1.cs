/*------------------------------------------------------------------------------------------------
** program:			TX Text Control Hyperlinks Sample
** description:	Shows you how to add hypertext links and targets to your documents, and how to 
**                  respond to events fired by TX Text Control when a hypertext link is clicked					
**
** copyright:		© Text Control GmbH
**----------------------------------------------------------------------------------------------*/
using System;
using System.Drawing;
using System.ComponentModel;
using System.Windows.Forms;

namespace Step2 {

    public class Form1 : System.Windows.Forms.Form {

        private TXTextControl.TextControl textControl1;
        private System.Windows.Forms.MainMenu mainMenu1;
        private System.Windows.Forms.MenuItem mnuEdit;
        private System.Windows.Forms.MenuItem mnuInsert;
        private System.Windows.Forms.MenuItem mnuView;
        private System.Windows.Forms.MenuItem mnuEdit_Hyperlink;
        private System.Windows.Forms.MenuItem mnuInsert_Hyperlink;
        private System.Windows.Forms.MenuItem mnuView_Hyperlinks;
        private IContainer components;

        public Form1() {
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
            this.components = new System.ComponentModel.Container();
            this.textControl1 = new TXTextControl.TextControl();
            this.mainMenu1 = new System.Windows.Forms.MainMenu(this.components);
            this.mnuEdit = new System.Windows.Forms.MenuItem();
            this.mnuEdit_Hyperlink = new System.Windows.Forms.MenuItem();
            this.mnuInsert = new System.Windows.Forms.MenuItem();
            this.mnuInsert_Hyperlink = new System.Windows.Forms.MenuItem();
            this.mnuView = new System.Windows.Forms.MenuItem();
            this.mnuView_Hyperlinks = new System.Windows.Forms.MenuItem();
            this.SuspendLayout();
            // 
            // textControl1
            // 
            this.textControl1.AllowDrag = true;
            this.textControl1.AllowDrop = true;
            this.textControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textControl1.Font = new System.Drawing.Font("Arial", 10F);
            this.textControl1.Location = new System.Drawing.Point(0, 0);
            this.textControl1.Name = "textControl1";
            this.textControl1.PageMargins.Bottom = 79.03;
            this.textControl1.PageMargins.Left = 79.03;
            this.textControl1.PageMargins.Right = 79.03;
            this.textControl1.PageMargins.Top = 79.03;
            this.textControl1.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.textControl1.Size = new System.Drawing.Size(384, 241);
            this.textControl1.TabIndex = 0;
            this.textControl1.ViewMode = TXTextControl.ViewMode.Normal;
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.mnuEdit,
            this.mnuInsert,
            this.mnuView});
            // 
            // mnuEdit
            // 
            this.mnuEdit.Index = 0;
            this.mnuEdit.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.mnuEdit_Hyperlink});
            this.mnuEdit.Text = "&Edit";
            this.mnuEdit.Popup += new System.EventHandler(this.mnuEdit_Popup);
            // 
            // mnuEdit_Hyperlink
            // 
            this.mnuEdit_Hyperlink.Index = 0;
            this.mnuEdit_Hyperlink.Text = "&Hyperlink...";
            this.mnuEdit_Hyperlink.Click += new System.EventHandler(this.mnuEdit_Hyperlink_Click);
            // 
            // mnuInsert
            // 
            this.mnuInsert.Index = 1;
            this.mnuInsert.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.mnuInsert_Hyperlink});
            this.mnuInsert.Text = "&Insert";
            this.mnuInsert.Popup += new System.EventHandler(this.mnuInsert_Popup);
            // 
            // mnuInsert_Hyperlink
            // 
            this.mnuInsert_Hyperlink.Index = 0;
            this.mnuInsert_Hyperlink.Text = "&Hyperlink...";
            this.mnuInsert_Hyperlink.Click += new System.EventHandler(this.mnuInsert_Hyperlink_Click);
            // 
            // mnuView
            // 
            this.mnuView.Index = 2;
            this.mnuView.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.mnuView_Hyperlinks});
            this.mnuView.Text = "&View";
            // 
            // mnuView_Hyperlinks
            // 
            this.mnuView_Hyperlinks.Checked = true;
            this.mnuView_Hyperlinks.Index = 0;
            this.mnuView_Hyperlinks.Text = "Hyperlinks";
            this.mnuView_Hyperlinks.Click += new System.EventHandler(this.mnuViewHyperlinks_Click);
            // 
            // Form1
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(384, 241);
            this.Controls.Add(this.textControl1);
            this.Menu = this.mainMenu1;
            this.Name = "Form1";
            this.Text = "TX Text Control - Hyperlinks Step 2";
            this.ResumeLayout(false);

        }
        #endregion

        [STAThread]
        static void Main() {
            Application.Run(new Form1());
        }

        // Open a dialog box to insert a hypertext link
        private void mnuInsert_Hyperlink_Click(object sender, System.EventArgs e) {
            frmHyperlinks Hyperlinks = new frmHyperlinks();
            Hyperlinks.tx = textControl1;
            Hyperlinks.ShowDialog();
            HighlightHyperlinks(textControl1, mnuView_Hyperlinks.Checked);
        }

        // Open a dialog box to edit the properties of a hypertext link 
        private void mnuEdit_Hyperlink_Click(object sender, System.EventArgs e) {
            frmHyperlinks Hyperlinks = new frmHyperlinks();
            Hyperlinks.tx = textControl1;
            Hyperlinks.ShowDialog();
        }

        // Disable Edit Hyperlinks menu item if no hyperlink is selected
        private void mnuEdit_Popup(object sender, System.EventArgs e) {
            // Disable Edit Hyperlinks menu item if no hyperlink is selected
            mnuEdit_Hyperlink.Enabled = (textControl1.HypertextLinks.GetItem() != null);
        }

        // Disable Insert Hyperlinks menu item while inside a hyperlink
        private void mnuInsert_Popup(object sender, System.EventArgs e) {
            // Disable Insert Hyperlinks menu item while inside a hyperlink
            mnuInsert_Hyperlink.Enabled = (textControl1.HypertextLinks.GetItem() == null);
        }

        // Show hypertext links as normal text or blue and underlined, depending
        // on the Highlight parameter
        void HighlightHyperlinks(TXTextControl.TextControl tx, bool Highlight) {
            int PreviousStart = tx.Selection.Start, PreviousLength = tx.Selection.Length;

            foreach (TXTextControl.HypertextLink Link in tx.HypertextLinks) {
                tx.Selection.Start = Link.Start - 1;
                tx.Selection.Length = Link.Length;
                if (Highlight) {
                    tx.Selection.ForeColor = Color.Blue;
                    tx.Selection.Underline = TXTextControl.FontUnderlineStyle.Single;
                }
                else {
                    tx.Selection.ForeColor = Color.Black;
                    tx.Selection.Underline = TXTextControl.FontUnderlineStyle.None;
                }
            }
            tx.Selection.Start = PreviousStart;
            tx.Selection.Length = PreviousLength;
        }

        // Switch hyperlink display
        private void mnuViewHyperlinks_Click(object sender, System.EventArgs e) {
            mnuView_Hyperlinks.Checked = !mnuView_Hyperlinks.Checked;
            HighlightHyperlinks(textControl1, mnuView_Hyperlinks.Checked);
        }
    }
}
