/*------------------------------------------------------------------------------------------------
** program:			TX Text Control Printing Sample
** description:	This sample shows you how to print with Text Control.
**             
** copyright:		© Text Control GmbH
**----------------------------------------------------------------------------------------------*/

using System;
using System.ComponentModel;
using System.Windows.Forms;
using System.Drawing.Printing;

namespace Printing {

    public class Form1 : System.Windows.Forms.Form {

        private TXTextControl.ButtonBar buttonBar1;
        private TXTextControl.RulerBar rulerBar1;
        private TXTextControl.StatusBar statusBar1;
        private TXTextControl.TextControl textControl1;
        private TXTextControl.RulerBar rulerBar2;
        private IContainer components = null;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem openFileToolStripMenuItem;
        private ToolStripMenuItem printToolStripMenuItem;
        private ToolStripMenuItem withBuiltInDialogToolStripMenuItem;
        private ToolStripMenuItem withCustomizedDialogToolStripMenuItem1;
        private ToolStripMenuItem withoutDialogToolStripMenuItem;

        public Form1() {
            InitializeComponent();
        }

        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        private void InitializeComponent() {
            this.buttonBar1 = new TXTextControl.ButtonBar();
            this.rulerBar1 = new TXTextControl.RulerBar();
            this.statusBar1 = new TXTextControl.StatusBar();
            this.textControl1 = new TXTextControl.TextControl();
            this.rulerBar2 = new TXTextControl.RulerBar();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.printToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.withBuiltInDialogToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.withCustomizedDialogToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.withoutDialogToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonBar1
            // 
            this.buttonBar1.BackColor = System.Drawing.SystemColors.Control;
            this.buttonBar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonBar1.Location = new System.Drawing.Point(0, 24);
            this.buttonBar1.Name = "buttonBar1";
            this.buttonBar1.Size = new System.Drawing.Size(939, 28);
            this.buttonBar1.TabIndex = 0;
            this.buttonBar1.TabStop = false;
            this.buttonBar1.Text = "buttonBar1";
            // 
            // rulerBar1
            // 
            this.rulerBar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.rulerBar1.Location = new System.Drawing.Point(0, 52);
            this.rulerBar1.Name = "rulerBar1";
            this.rulerBar1.Size = new System.Drawing.Size(939, 25);
            this.rulerBar1.TabIndex = 1;
            this.rulerBar1.TabStop = false;
            this.rulerBar1.Text = "rulerBar1";
            // 
            // statusBar1
            // 
            this.statusBar1.BackColor = System.Drawing.SystemColors.Control;
            this.statusBar1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.statusBar1.Location = new System.Drawing.Point(0, 439);
            this.statusBar1.Name = "statusBar1";
            this.statusBar1.Size = new System.Drawing.Size(939, 22);
            this.statusBar1.TabIndex = 2;
            this.statusBar1.TabStop = false;
            // 
            // textControl1
            // 
            this.textControl1.AllowDrag = true;
            this.textControl1.AllowDrop = true;
            this.textControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textControl1.Font = new System.Drawing.Font("Arial", 10F);
            this.textControl1.Location = new System.Drawing.Point(25, 77);
            this.textControl1.Name = "textControl1";
            this.textControl1.PageMargins.Bottom = 79.03;
            this.textControl1.PageMargins.Left = 79.03;
            this.textControl1.PageMargins.Right = 79.03;
            this.textControl1.PageMargins.Top = 79.03;
            this.textControl1.Size = new System.Drawing.Size(914, 362);
            this.textControl1.TabIndex = 3;
            // 
            // rulerBar2
            // 
            this.rulerBar2.Alignment = TXTextControl.RulerBarAlignment.Left;
            this.rulerBar2.Dock = System.Windows.Forms.DockStyle.Left;
            this.rulerBar2.Location = new System.Drawing.Point(0, 77);
            this.rulerBar2.Name = "rulerBar2";
            this.rulerBar2.Size = new System.Drawing.Size(25, 362);
            this.rulerBar2.TabIndex = 4;
            this.rulerBar2.Text = "rulerBar2";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(939, 24);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openFileToolStripMenuItem,
            this.printToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // openFileToolStripMenuItem
            // 
            this.openFileToolStripMenuItem.Name = "openFileToolStripMenuItem";
            this.openFileToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
            this.openFileToolStripMenuItem.Text = "&Open file...";
            this.openFileToolStripMenuItem.Click += new System.EventHandler(this.openFileToolStripMenuItem_Click);
            // 
            // printToolStripMenuItem
            // 
            this.printToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.withBuiltInDialogToolStripMenuItem,
            this.withCustomizedDialogToolStripMenuItem1,
            this.withoutDialogToolStripMenuItem});
            this.printToolStripMenuItem.Name = "printToolStripMenuItem";
            this.printToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
            this.printToolStripMenuItem.Text = "&Print";
            // 
            // withBuiltInDialogToolStripMenuItem
            // 
            this.withBuiltInDialogToolStripMenuItem.Name = "withBuiltInDialogToolStripMenuItem";
            this.withBuiltInDialogToolStripMenuItem.Size = new System.Drawing.Size(211, 22);
            this.withBuiltInDialogToolStripMenuItem.Text = "With Built-In Dialog...";
            this.withBuiltInDialogToolStripMenuItem.Click += new System.EventHandler(this.withBuiltInDialogToolStripMenuItem_Click);
            // 
            // withCustomizedDialogToolStripMenuItem1
            // 
            this.withCustomizedDialogToolStripMenuItem1.Name = "withCustomizedDialogToolStripMenuItem1";
            this.withCustomizedDialogToolStripMenuItem1.Size = new System.Drawing.Size(211, 22);
            this.withCustomizedDialogToolStripMenuItem1.Text = "With Customized Dialog...";
            this.withCustomizedDialogToolStripMenuItem1.Click += new System.EventHandler(this.withCustomizedDialogToolStripMenuItem1_Click);
            // 
            // withoutDialogToolStripMenuItem
            // 
            this.withoutDialogToolStripMenuItem.Name = "withoutDialogToolStripMenuItem";
            this.withoutDialogToolStripMenuItem.Size = new System.Drawing.Size(211, 22);
            this.withoutDialogToolStripMenuItem.Text = "Without Dialog";
            this.withoutDialogToolStripMenuItem.Click += new System.EventHandler(this.withoutDialogToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(939, 461);
            this.Controls.Add(this.textControl1);
            this.Controls.Add(this.rulerBar2);
            this.Controls.Add(this.statusBar1);
            this.Controls.Add(this.rulerBar1);
            this.Controls.Add(this.buttonBar1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Printing Sample Program";
            this.Load += new System.EventHandler(this.Form1_Load);
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

        private void Form1_Load(object sender, System.EventArgs e) {
            textControl1.ButtonBar = buttonBar1;
            textControl1.RulerBar = rulerBar1;
            textControl1.VerticalRulerBar = rulerBar2;
            textControl1.StatusBar = statusBar1;
        }

        private void openFileToolStripMenuItem_Click(object sender, EventArgs e) {
            textControl1.Load();
        }

        private void withBuiltInDialogToolStripMenuItem_Click(object sender, EventArgs e) {
            textControl1.Print("My Print Job");
        }

        private void withoutDialogToolStripMenuItem_Click(object sender, EventArgs e) {
            PrintDocument myPrintDocument = new PrintDocument();

            myPrintDocument.PrinterSettings.FromPage = 1;
            myPrintDocument.PrinterSettings.ToPage = 1;
            textControl1.Print(myPrintDocument);
        }

        private void withCustomizedDialogToolStripMenuItem1_Click(object sender, EventArgs e) {
            PrintDialog myPrintDialog = new PrintDialog();
            PrintDocument myPrintDocument = new PrintDocument();

            myPrintDialog.Document = myPrintDocument;
            myPrintDialog.AllowSomePages = false;
            myPrintDialog.AllowPrintToFile = false;
            myPrintDialog.PrinterSettings.FromPage = 1;
            myPrintDialog.PrinterSettings.ToPage = textControl1.Pages;
            myPrintDialog.UseEXDialog = true;

            if (myPrintDialog.ShowDialog() == DialogResult.OK) {
                textControl1.Print(myPrintDocument);
            }
        }
    }
}
