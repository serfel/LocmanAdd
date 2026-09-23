/*------------------------------------------------------------------------------------------------
** program:			TX Text Control Înserting Text Frames Sample
** description:	Describes how you can control and manipulate text using text frames.						
**
** copyright:		© Text Control GmbH
**----------------------------------------------------------------------------------------------*/

using System;
using System.Drawing;
using System.ComponentModel;
using System.Windows.Forms;

namespace InsertingTextFrames {

    public class Form1 : System.Windows.Forms.Form {

        private TXTextControl.TextControl textControl1;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem textFrameToolStripMenuItem;
        private ToolStripMenuItem insertToolStripMenuItem;
        private ToolStripMenuItem propertiesToolStripMenuItem;
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
            this.textFrameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.insertToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.propertiesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textControl1
            // 
            this.textControl1.AllowDrag = true;
            this.textControl1.AllowDrop = true;
            this.textControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textControl1.Font = new System.Drawing.Font("Arial", 10F);
            this.textControl1.Location = new System.Drawing.Point(0, 24);
            this.textControl1.Name = "textControl1";
            this.textControl1.PageMargins.Bottom = 79.03;
            this.textControl1.PageMargins.Left = 79.03;
            this.textControl1.PageMargins.Right = 79.03;
            this.textControl1.PageMargins.Top = 79.03;
            this.textControl1.Size = new System.Drawing.Size(939, 437);
            this.textControl1.TabIndex = 0;
            this.textControl1.Text = "textControl1";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.textFrameToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(939, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // textFrameToolStripMenuItem
            // 
            this.textFrameToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.insertToolStripMenuItem,
            this.propertiesToolStripMenuItem});
            this.textFrameToolStripMenuItem.Name = "textFrameToolStripMenuItem";
            this.textFrameToolStripMenuItem.Size = new System.Drawing.Size(82, 20);
            this.textFrameToolStripMenuItem.Text = "Text &Frames";
            this.textFrameToolStripMenuItem.DropDownOpening += new System.EventHandler(this.textFrameToolStripMenuItem_DropDownOpening);
            // 
            // insertToolStripMenuItem
            // 
            this.insertToolStripMenuItem.Name = "insertToolStripMenuItem";
            this.insertToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.insertToolStripMenuItem.Text = "&Insert";
            this.insertToolStripMenuItem.Click += new System.EventHandler(this.insertToolStripMenuItem_Click);
            // 
            // propertiesToolStripMenuItem
            // 
            this.propertiesToolStripMenuItem.Name = "propertiesToolStripMenuItem";
            this.propertiesToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.propertiesToolStripMenuItem.Text = "&Properties...";
            this.propertiesToolStripMenuItem.Click += new System.EventHandler(this.propertiesToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(939, 461);
            this.Controls.Add(this.textControl1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "TX Text Control - Inserting Text Frames";
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

        private void insertToolStripMenuItem_Click(object sender, EventArgs e) {
            TXTextControl.TextFrame NewFrame = new TXTextControl.TextFrame(new Size(1000, 1000));
            textControl1.TextFrames.Add(NewFrame, TXTextControl.HorizontalAlignment.Left,
                -1, TXTextControl.TextFrameInsertionMode.DisplaceText);
        }

        private void propertiesToolStripMenuItem_Click(object sender, EventArgs e) {
            textControl1.TextFrameAttributesDialog();
        }

        private void textFrameToolStripMenuItem_DropDownOpening(object sender, EventArgs e) {
            propertiesToolStripMenuItem.Enabled = (textControl1.TextFrames.GetItem() != null);
        }

    }
}
