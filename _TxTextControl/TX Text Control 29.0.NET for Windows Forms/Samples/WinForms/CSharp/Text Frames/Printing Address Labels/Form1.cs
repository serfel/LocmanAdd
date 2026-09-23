/*------------------------------------------------------------------------------------------------
** program:			TX Text Control Printing Address Labels Sample
** description:	Describes how you can control and manipulate text using text frames.						
**
** copyright:		© Text Control GmbH
**----------------------------------------------------------------------------------------------*/
using System;
using System.Drawing;
using System.ComponentModel;
using System.Windows.Forms;

namespace Printing_Address_Labels {

    public class LabelPrinter : System.Windows.Forms.Form {

        #region Menu items

        private TXTextControl.ButtonBar buttonBar1;
        private TXTextControl.RulerBar rulerBar1;
        private TXTextControl.StatusBar statusBar1;
        private TXTextControl.TextControl textControl1;
        private TXTextControl.RulerBar rulerBar2;
        #endregion
        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem newToolStripMenuItem;
        private ToolStripMenuItem openToolStripMenuItem;
        private ToolStripSeparator toolStripMenuItem1;
        private ToolStripMenuItem saveAsToolStripMenuItem;
        private ToolStripSeparator toolStripMenuItem2;
        private ToolStripMenuItem printToolStripMenuItem;
        private ToolStripMenuItem pageSetupToolStripMenuItem;
        private ToolStripSeparator toolStripMenuItem3;
        private ToolStripMenuItem exitToolStripMenuItem;
        private ToolStripMenuItem editToolStripMenuItem;
        private ToolStripMenuItem cutToolStripMenuItem;
        private ToolStripMenuItem copyToolStripMenuItem;
        private ToolStripMenuItem pasteToolStripMenuItem;
        private ToolStripMenuItem formatToolStripMenuItem;
        private ToolStripMenuItem characterToolStripMenuItem;
        private ToolStripMenuItem paragraphToolStripMenuItem;
        private ToolStripMenuItem styleToolStripMenuItem;
        private ToolStripMenuItem labelToolStripMenuItem;
        private ToolStripMenuItem insertGroupToolStripMenuItem;
        private ToolStripMenuItem propertiesToolStripMenuItem;
        private ToolStripMenuItem fillInToolStripMenuItem;
        private IContainer components = null;

        public LabelPrinter() {
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
            this.buttonBar1 = new TXTextControl.ButtonBar();
            this.rulerBar1 = new TXTextControl.RulerBar();
            this.statusBar1 = new TXTextControl.StatusBar();
            this.textControl1 = new TXTextControl.TextControl();
            this.rulerBar2 = new TXTextControl.RulerBar();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.printToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pageSetupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.formatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.characterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.paragraphToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.styleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.labelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.insertGroupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.propertiesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fillInToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.formatToolStripMenuItem,
            this.labelToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(939, 24);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem,
            this.toolStripMenuItem1,
            this.saveAsToolStripMenuItem,
            this.toolStripMenuItem2,
            this.printToolStripMenuItem,
            this.pageSetupToolStripMenuItem,
            this.toolStripMenuItem3,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.newToolStripMenuItem.Text = "&New";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.openToolStripMenuItem.Text = "&Open...";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(130, 6);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.saveAsToolStripMenuItem.Text = "&Save As...";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(130, 6);
            // 
            // printToolStripMenuItem
            // 
            this.printToolStripMenuItem.Name = "printToolStripMenuItem";
            this.printToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.printToolStripMenuItem.Text = "&Print...";
            this.printToolStripMenuItem.Click += new System.EventHandler(this.printToolStripMenuItem_Click);
            // 
            // pageSetupToolStripMenuItem
            // 
            this.pageSetupToolStripMenuItem.Name = "pageSetupToolStripMenuItem";
            this.pageSetupToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.pageSetupToolStripMenuItem.Text = "Page S&etup";
            this.pageSetupToolStripMenuItem.Click += new System.EventHandler(this.pageSetupToolStripMenuItem_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(130, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cutToolStripMenuItem,
            this.copyToolStripMenuItem,
            this.pasteToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "&Edit";
            // 
            // cutToolStripMenuItem
            // 
            this.cutToolStripMenuItem.Name = "cutToolStripMenuItem";
            this.cutToolStripMenuItem.Size = new System.Drawing.Size(102, 22);
            this.cutToolStripMenuItem.Text = "Cu&t";
            this.cutToolStripMenuItem.Click += new System.EventHandler(this.cutToolStripMenuItem_Click);
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(102, 22);
            this.copyToolStripMenuItem.Text = "&Copy";
            this.copyToolStripMenuItem.Click += new System.EventHandler(this.copyToolStripMenuItem_Click);
            // 
            // pasteToolStripMenuItem
            // 
            this.pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
            this.pasteToolStripMenuItem.Size = new System.Drawing.Size(102, 22);
            this.pasteToolStripMenuItem.Text = "&Paste";
            this.pasteToolStripMenuItem.Click += new System.EventHandler(this.pasteToolStripMenuItem_Click);
            // 
            // formatToolStripMenuItem
            // 
            this.formatToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.characterToolStripMenuItem,
            this.paragraphToolStripMenuItem,
            this.styleToolStripMenuItem});
            this.formatToolStripMenuItem.Name = "formatToolStripMenuItem";
            this.formatToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.formatToolStripMenuItem.Text = "&Format";
            // 
            // characterToolStripMenuItem
            // 
            this.characterToolStripMenuItem.Name = "characterToolStripMenuItem";
            this.characterToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.characterToolStripMenuItem.Text = "&Character...";
            this.characterToolStripMenuItem.Click += new System.EventHandler(this.characterToolStripMenuItem_Click);
            // 
            // paragraphToolStripMenuItem
            // 
            this.paragraphToolStripMenuItem.Name = "paragraphToolStripMenuItem";
            this.paragraphToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.paragraphToolStripMenuItem.Text = "&Paragraph...";
            this.paragraphToolStripMenuItem.Click += new System.EventHandler(this.paragraphToolStripMenuItem_Click);
            // 
            // styleToolStripMenuItem
            // 
            this.styleToolStripMenuItem.Name = "styleToolStripMenuItem";
            this.styleToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.styleToolStripMenuItem.Text = "&Style...";
            this.styleToolStripMenuItem.Click += new System.EventHandler(this.styleToolStripMenuItem_Click);
            // 
            // labelToolStripMenuItem
            // 
            this.labelToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.insertGroupToolStripMenuItem,
            this.propertiesToolStripMenuItem,
            this.fillInToolStripMenuItem});
            this.labelToolStripMenuItem.Name = "labelToolStripMenuItem";
            this.labelToolStripMenuItem.Size = new System.Drawing.Size(47, 20);
            this.labelToolStripMenuItem.Text = "&Label";
            this.labelToolStripMenuItem.DropDownOpening += new System.EventHandler(this.labelToolStripMenuItem_DropDownOpening);
            // 
            // insertGroupToolStripMenuItem
            // 
            this.insertGroupToolStripMenuItem.Name = "insertGroupToolStripMenuItem";
            this.insertGroupToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.insertGroupToolStripMenuItem.Text = "Insert &Group...";
            this.insertGroupToolStripMenuItem.Click += new System.EventHandler(this.insertGroupToolStripMenuItem_Click);
            // 
            // propertiesToolStripMenuItem
            // 
            this.propertiesToolStripMenuItem.Name = "propertiesToolStripMenuItem";
            this.propertiesToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.propertiesToolStripMenuItem.Text = "&Properties...";
            this.propertiesToolStripMenuItem.Click += new System.EventHandler(this.propertiesToolStripMenuItem_Click);
            // 
            // fillInToolStripMenuItem
            // 
            this.fillInToolStripMenuItem.Name = "fillInToolStripMenuItem";
            this.fillInToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.fillInToolStripMenuItem.Text = "&Fill In";
            this.fillInToolStripMenuItem.Click += new System.EventHandler(this.fillInToolStripMenuItem_Click);
            // 
            // LabelPrinter
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
            this.Name = "LabelPrinter";
            this.Text = "TX Text Control - Label Printer";
            this.Load += new System.EventHandler(this.LabelPrinter_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        [STAThread]
        static void Main() {
            Application.EnableVisualStyles();
            Application.Run(new LabelPrinter());
        }

        private void LabelPrinter_Load(object sender, System.EventArgs e) {
            textControl1.ButtonBar = buttonBar1;
            textControl1.RulerBar = rulerBar1;
            textControl1.VerticalRulerBar = rulerBar2;
            textControl1.StatusBar = statusBar1;
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e) {
            textControl1.ResetContents();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e) {
            textControl1.Load();
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e) {
            textControl1.Save();
        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e) {
            textControl1.Print("Label Printer");
        }

        private void pageSetupToolStripMenuItem_Click(object sender, EventArgs e) {
            textControl1.SectionFormatDialog(0);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e) {
            Close();
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e) {
            textControl1.Cut();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e) {
            textControl1.Copy();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e) {
            textControl1.Paste();
        }

        private void characterToolStripMenuItem_Click(object sender, EventArgs e) {
            textControl1.FontDialog();
        }

        private void paragraphToolStripMenuItem_Click(object sender, EventArgs e) {
            textControl1.ParagraphFormatDialog();
        }

        private void styleToolStripMenuItem_Click(object sender, EventArgs e) {
            textControl1.FormattingStylesDialog();
        }

        private void insertGroupToolStripMenuItem_Click(object sender, EventArgs e) {
            int row, col, xpos, ypos;
            const double TwipsInMm = 56.7;

            InsertLabelGroup frmIlg = new InsertLabelGroup();
            frmIlg.PageHeight = (int)textControl1.PageSize.Height;
            frmIlg.PageWidth = (int)textControl1.PageSize.Width;

            frmIlg.ShowDialog();

            for (row = 1; row <= frmIlg.NoOfRows; row++) {
                for (col = 1; col <= frmIlg.NoOfColumns; col++) {
                    xpos = frmIlg.PageMarginLeft +
                       (col - 1) * (frmIlg.LabelWidth + frmIlg.SpaceHorizontal);
                    ypos = frmIlg.PageMarginTop +
                        (row - 1) * (frmIlg.LabelHeight + frmIlg.SpaceVertical);
                    TXTextControl.TextFrame NewFrame = new TXTextControl.TextFrame(
                        new Size(Convert.ToInt32(frmIlg.LabelWidth * TwipsInMm),
                            Convert.ToInt32(frmIlg.LabelHeight * TwipsInMm)));
                    NewFrame.BorderWidth = 0;
                    textControl1.TextFrames.Add(NewFrame, 1,
                        new Point(Convert.ToInt32(xpos * TwipsInMm), Convert.ToInt32(ypos * TwipsInMm)),
                        TXTextControl.TextFrameInsertionMode.DisplaceText);
                }
            }
        }

        private void propertiesToolStripMenuItem_Click(object sender, EventArgs e) {
            textControl1.TextFrameAttributesDialog();
        }

        private void fillInToolStripMenuItem_Click(object sender, EventArgs e) {
            int n = 0;

            foreach (TXTextControl.TextFrame Frame in textControl1.TextFrames) {
                Frame.Selection.Text = "Text Frame #" + Convert.ToString(n++);
            }
        }

        private void labelToolStripMenuItem_DropDownOpening(object sender, EventArgs e) {
            propertiesToolStripMenuItem.Enabled = (textControl1.TextFrames.GetItem() != null);
            fillInToolStripMenuItem.Enabled = (textControl1.TextFrames.Count > 0);
        }
    }
}
