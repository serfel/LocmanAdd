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

namespace Step3 {

    public class Form1 : System.Windows.Forms.Form {

        private TXTextControl.TextControl textControl1;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem openToolStripMenuItem;
        private ToolStripMenuItem saveAsToolStripMenuItem;
        private ToolStripMenuItem editToolStripMenuItem;
        private ToolStripMenuItem hyperlinkToolStripMenuItem;
        private ToolStripMenuItem targetToolStripMenuItem;
        private ToolStripMenuItem insertToolStripMenuItem;
        private ToolStripMenuItem hyperlinkToolStripMenuItem1;
        private ToolStripMenuItem targetToolStripMenuItem1;
        private ToolStripMenuItem viewToolStripMenuItem;
        private ToolStripMenuItem hyperlinksToolStripMenuItem;
        private ToolStripMenuItem jumpToTargetsToolStripMenuItem;
        private IContainer components = null;

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
        private void InitializeComponent() {
            this.textControl1 = new TXTextControl.TextControl();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hyperlinkToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.targetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.insertToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hyperlinkToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.targetToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hyperlinksToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.jumpToTargetsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textControl1
            // 
            this.textControl1.AllowDrag = true;
            this.textControl1.AllowDrop = true;
            this.textControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textControl1.Font = new System.Drawing.Font("Arial", 10F);
            this.textControl1.HideSelection = false;
            this.textControl1.Location = new System.Drawing.Point(0, 33);
            this.textControl1.Name = "textControl1";
            this.textControl1.PageMargins.Bottom = 79.03D;
            this.textControl1.PageMargins.Left = 79.03D;
            this.textControl1.PageMargins.Right = 79.03D;
            this.textControl1.PageMargins.Top = 79.03D;
            this.textControl1.Size = new System.Drawing.Size(400, 213);
            this.textControl1.TabIndex = 0;
            this.textControl1.UserNames = null;
            this.textControl1.DocumentLinkClicked += new TXTextControl.DocumentLinkEventHandler(this.textControl1_DocumentLinkClicked);
            // 
            // menuStrip1
            // 
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.insertToolStripMenuItem,
            this.viewToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(400, 33);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.saveAsToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(54, 29);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(188, 34);
            this.openToolStripMenuItem.Text = "&Open...";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(188, 34);
            this.saveAsToolStripMenuItem.Text = "&Save As...";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.hyperlinkToolStripMenuItem,
            this.targetToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(58, 29);
            this.editToolStripMenuItem.Text = "&Edit";
            this.editToolStripMenuItem.DropDownOpening += new System.EventHandler(this.editToolStripMenuItem_DropDownOpening);
            // 
            // hyperlinkToolStripMenuItem
            // 
            this.hyperlinkToolStripMenuItem.Name = "hyperlinkToolStripMenuItem";
            this.hyperlinkToolStripMenuItem.Size = new System.Drawing.Size(201, 34);
            this.hyperlinkToolStripMenuItem.Text = "&Hyperlink...";
            this.hyperlinkToolStripMenuItem.Click += new System.EventHandler(this.hyperlinkToolStripMenuItem_Click);
            // 
            // targetToolStripMenuItem
            // 
            this.targetToolStripMenuItem.Name = "targetToolStripMenuItem";
            this.targetToolStripMenuItem.Size = new System.Drawing.Size(201, 34);
            this.targetToolStripMenuItem.Text = "&Target...";
            this.targetToolStripMenuItem.Click += new System.EventHandler(this.targetToolStripMenuItem_Click);
            // 
            // insertToolStripMenuItem
            // 
            this.insertToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.hyperlinkToolStripMenuItem1,
            this.targetToolStripMenuItem1});
            this.insertToolStripMenuItem.Name = "insertToolStripMenuItem";
            this.insertToolStripMenuItem.Size = new System.Drawing.Size(72, 29);
            this.insertToolStripMenuItem.Text = "&Insert";
            this.insertToolStripMenuItem.DropDownOpening += new System.EventHandler(this.insertToolStripMenuItem_DropDownOpening);
            // 
            // hyperlinkToolStripMenuItem1
            // 
            this.hyperlinkToolStripMenuItem1.Name = "hyperlinkToolStripMenuItem1";
            this.hyperlinkToolStripMenuItem1.Size = new System.Drawing.Size(201, 34);
            this.hyperlinkToolStripMenuItem1.Text = "&Hyperlink...";
            this.hyperlinkToolStripMenuItem1.Click += new System.EventHandler(this.hyperlinkToolStripMenuItem1_Click);
            // 
            // targetToolStripMenuItem1
            // 
            this.targetToolStripMenuItem1.Name = "targetToolStripMenuItem1";
            this.targetToolStripMenuItem1.Size = new System.Drawing.Size(201, 34);
            this.targetToolStripMenuItem1.Text = "&Target...";
            this.targetToolStripMenuItem1.Click += new System.EventHandler(this.targetToolStripMenuItem1_Click);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.hyperlinksToolStripMenuItem,
            this.jumpToTargetsToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(65, 29);
            this.viewToolStripMenuItem.Text = "&View";
            // 
            // hyperlinksToolStripMenuItem
            // 
            this.hyperlinksToolStripMenuItem.Name = "hyperlinksToolStripMenuItem";
            this.hyperlinksToolStripMenuItem.Size = new System.Drawing.Size(239, 34);
            this.hyperlinksToolStripMenuItem.Text = "&Hyperlinks";
            this.hyperlinksToolStripMenuItem.Click += new System.EventHandler(this.hyperlinksToolStripMenuItem_Click);
            // 
            // jumpToTargetsToolStripMenuItem
            // 
            this.jumpToTargetsToolStripMenuItem.Name = "jumpToTargetsToolStripMenuItem";
            this.jumpToTargetsToolStripMenuItem.Size = new System.Drawing.Size(239, 34);
            this.jumpToTargetsToolStripMenuItem.Text = "&Jump to targets";
            this.jumpToTargetsToolStripMenuItem.Click += new System.EventHandler(this.jumpToTargetsToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(8, 19);
            this.ClientSize = new System.Drawing.Size(400, 246);
            this.Controls.Add(this.textControl1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "TX Text Control - Hyperlinks Step 3";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        [STAThread]
        static void Main() {
            Application.EnableVisualStyles();
            Application.Run(new Form1());
        }

        // Show hypertext links as normal text or blue and underlined, depending
        // on the Highlight parameter
        void HighlightHyperlinks(TXTextControl.TextControl tx, bool Highlight) {
            int PreviousStart = tx.Selection.Start, PreviousLength = tx.Selection.Length;

            foreach (TXTextControl.HypertextLink Link in tx.HypertextLinks)
                ShowLink(tx, Link, Highlight);

            foreach (TXTextControl.DocumentLink Link in tx.DocumentLinks)
                ShowLink(tx, Link, Highlight);

            tx.Selection.Start = PreviousStart;
            tx.Selection.Length = PreviousLength;
        }

        // Called by HighlightHyperlinks to set the format of a single link
        private void ShowLink(TXTextControl.TextControl tx, TXTextControl.TextField Link, bool Highlight) {
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

        // Scroll to a document link's target when the link is clicked on
        private void textControl1_DocumentLinkClicked(object sender, TXTextControl.DocumentLinkEventArgs e) {
            if (jumpToTargetsToolStripMenuItem.Checked)
                e.DocumentLink.DocumentTarget.ScrollTo();
        }

        // Open a file
        private void openToolStripMenuItem_Click(object sender, EventArgs e) {
            textControl1.Load();
            hyperlinksToolStripMenuItem.Checked = true;
        }

        // Save to file
        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e) {
            textControl1.Save();
        }

        // Open a dialog box to edit the properties of a hypertext link
        private void hyperlinkToolStripMenuItem_Click(object sender, EventArgs e) {
            frmHyperlinks Hyperlinks = new frmHyperlinks();
            Hyperlinks.tx = textControl1;
            Hyperlinks.ShowDialog();
        }

        // Open a dialog box for editing document targets
        private void targetToolStripMenuItem_Click(object sender, EventArgs e) {
            frmEditTargets EditTargets = new frmEditTargets();
            EditTargets.tx = textControl1;
            EditTargets.ShowDialog();
        }

        // Open a dialog box to insert a hypertext link
        private void hyperlinkToolStripMenuItem1_Click(object sender, EventArgs e) {
            frmHyperlinks Hyperlinks = new frmHyperlinks();
            Hyperlinks.tx = textControl1;
            Hyperlinks.ShowDialog();
            HighlightHyperlinks(textControl1, hyperlinksToolStripMenuItem.Checked);
        }

        // Insert a document target
        private void targetToolStripMenuItem1_Click(object sender, EventArgs e) {
            frmInsertTarget InsertTarget = new frmInsertTarget();
            if (InsertTarget.ShowDialog() == DialogResult.OK) {
                TXTextControl.DocumentTarget Target =
                    new TXTextControl.DocumentTarget(InsertTarget.TargetName);
                textControl1.DocumentTargets.Add(Target);
            }
        }

        // Show hypertext links as normal text or blue and underlined, depending
        // on the Highlight parameter
        private void hyperlinksToolStripMenuItem_Click(object sender, EventArgs e) {
            hyperlinksToolStripMenuItem.Checked = !hyperlinksToolStripMenuItem.Checked;
            HighlightHyperlinks(textControl1, hyperlinksToolStripMenuItem.Checked);
        }

        // Switch checkmark on JumpToTargets menu when clicked
        private void jumpToTargetsToolStripMenuItem_Click(object sender, EventArgs e) {
            jumpToTargetsToolStripMenuItem.Checked = !jumpToTargetsToolStripMenuItem.Checked;
        }

        // Disable Edit Hyperlinks menu item if no hyperlink is selected
        private void editToolStripMenuItem_DropDownOpening(object sender, EventArgs e) {
            hyperlinkToolStripMenuItem.Enabled =
                (textControl1.HypertextLinks.GetItem() != null) ||
                (textControl1.DocumentLinks.GetItem() != null);
        }

        // Disable Insert Hyperlinks menu item while inside a hyperlink
        private void insertToolStripMenuItem_DropDownOpening(object sender, EventArgs e) {
            hyperlinkToolStripMenuItem1.Enabled =
                (textControl1.HypertextLinks.GetItem() == null) &&
                (textControl1.DocumentLinks.GetItem() == null);
            targetToolStripMenuItem1.Enabled = hyperlinkToolStripMenuItem1.Enabled;
        }
    }
}
