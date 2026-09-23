/*------------------------------------------------------------------------------------------------
** program:			TX Text Control Quote Generator Sample
** description:	This sample program shows how to use Text Control in office applications.  						
**
** copyright:		© Text Control GmbH
**----------------------------------------------------------------------------------------------*/
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace QuoteGenerator {
    public class frmEditor : System.Windows.Forms.Form {
        #region Windows Form Designer generated code


        private TXTextControl.ButtonBar buttonBar1;
        private TXTextControl.RulerBar rulerBar1;
        private TXTextControl.StatusBar statusBar1;
        private TXTextControl.TextControl textControl1;
        private TXTextControl.RulerBar rulerBar2;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem printToolStripMenuItem;
        private ToolStripSeparator toolStripMenuItem1;
        private ToolStripMenuItem exitToolStripMenuItem;
        private IContainer components = null;

        public frmEditor() {
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


        private void InitializeComponent() {
            this.buttonBar1 = new TXTextControl.ButtonBar();
            this.rulerBar1 = new TXTextControl.RulerBar();
            this.statusBar1 = new TXTextControl.StatusBar();
            this.textControl1 = new TXTextControl.TextControl();
            this.rulerBar2 = new TXTextControl.RulerBar();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.printToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.printToolStripMenuItem,
            this.toolStripMenuItem1,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // printToolStripMenuItem
            // 
            this.printToolStripMenuItem.Name = "printToolStripMenuItem";
            this.printToolStripMenuItem.Size = new System.Drawing.Size(108, 22);
            this.printToolStripMenuItem.Text = "&Print...";
            this.printToolStripMenuItem.Click += new System.EventHandler(this.printToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(105, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(108, 22);
            this.exitToolStripMenuItem.Text = "&Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // frmEditor
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
            this.Name = "frmEditor";
            this.Text = "TX Text Control Quote Generator - Step 1";
            this.Load += new System.EventHandler(this.frmEditor_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        public string AddressField;
        public string CustomerIDField;
        public string DateField;
        public string DearXXField;

        private void frmEditor_Load(object sender, System.EventArgs e) {

            // Load document template
            textControl1.Load("DocumentTemplate.tx", TXTextControl.StreamType.InternalFormat);

            // Fill template with data
            MacroField Field = new MacroField();
            Field.SelectByID(textControl1, MacroField.ID.FieldAddress).Text = AddressField;
            Field.SelectByID(textControl1, MacroField.ID.FieldCustomerID).Text = CustomerIDField;
            Field.SelectByID(textControl1, MacroField.ID.FieldDearXX).Text = DearXXField;
            Field.SelectByID(textControl1, MacroField.ID.FieldDate).Text = DateField;

            // Connect toolbars
            textControl1.StatusBar = statusBar1;
            textControl1.ButtonBar = buttonBar1;
            textControl1.RulerBar = rulerBar1;
            textControl1.VerticalRulerBar = rulerBar2;
        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e) {
            textControl1.Print(this.Text);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e) {
            Close();
        }


    }
}
