/*------------------------------------------------------------------------------------------------
** program:			TX Text Control Editing from code Sample
** description:	There are various applications which require text to be edited from program code. 
**                  Using TX Text Control, anything that can be done using the mouse and 
**                  clicking menu items, can also be done from program code.
**                  						
** copyright:		© Text Control GmbH
**----------------------------------------------------------------------------------------------*/
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace Editing_from_code {

    public class Form1 : System.Windows.Forms.Form {

        private TXTextControl.TextControl textControl1;
        private System.Windows.Forms.MainMenu mainMenu1;
        private System.Windows.Forms.MenuItem mnuEdit;
        private System.Windows.Forms.MenuItem mnuEdit_Bold;
        private System.Windows.Forms.MenuItem mnuEdit_Find;
        private System.Windows.Forms.MenuItem mnuEdit_Append;
        private System.Windows.Forms.MenuItem mnuPage;
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
            this.mnuEdit_Bold = new System.Windows.Forms.MenuItem();
            this.mnuEdit_Find = new System.Windows.Forms.MenuItem();
            this.mnuEdit_Append = new System.Windows.Forms.MenuItem();
            this.mnuPage = new System.Windows.Forms.MenuItem();
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
            this.textControl1.Size = new System.Drawing.Size(939, 440);
            this.textControl1.TabIndex = 0;
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.mnuEdit});
            // 
            // mnuEdit
            // 
            this.mnuEdit.Index = 0;
            this.mnuEdit.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.mnuEdit_Bold,
            this.mnuEdit_Find,
            this.mnuEdit_Append,
            this.mnuPage});
            this.mnuEdit.Text = "&Edit";
            // 
            // mnuEdit_Bold
            // 
            this.mnuEdit_Bold.Index = 0;
            this.mnuEdit_Bold.Text = "Select and set to bold";
            this.mnuEdit_Bold.Click += new System.EventHandler(this.mnuEdit_Bold_Click);
            // 
            // mnuEdit_Find
            // 
            this.mnuEdit_Find.Index = 1;
            this.mnuEdit_Find.Text = "Find and set to bold";
            this.mnuEdit_Find.Click += new System.EventHandler(this.mnuEdit_Find_Click);
            // 
            // mnuEdit_Append
            // 
            this.mnuEdit_Append.Index = 2;
            this.mnuEdit_Append.Text = "Append files";
            this.mnuEdit_Append.Click += new System.EventHandler(this.mnuEdit_Append_Click);
            // 
            // mnuPage
            // 
            this.mnuPage.Index = 3;
            this.mnuPage.Text = "Goto page...";
            this.mnuPage.Click += new System.EventHandler(this.mnuPage_Click);
            // 
            // Form1
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(939, 440);
            this.Controls.Add(this.textControl1);
            this.Menu = this.mainMenu1;
            this.Name = "Form1";
            this.Text = "Editing Text From Code";
            this.ResumeLayout(false);

        }
        #endregion

        [STAThread]
        static void Main() {
            Application.Run(new Form1());
        }


        private void mnuEdit_Bold_Click(object sender, System.EventArgs e) {
            textControl1.Text = "TX Text Control";
            textControl1.Selection.Start = 3;
            textControl1.Selection.Length = 4;
            textControl1.Selection.Bold = true;
        }

        private void mnuEdit_Find_Click(object sender, System.EventArgs e) {
            textControl1.Text = "TX Text Control";
            textControl1.Find("Text", 0, TXTextControl.FindOptions.NoMessageBox);
            textControl1.Selection.FontSize = 400;
        }

        private void mnuEdit_Append_Click(object sender, System.EventArgs e) {
            textControl1.Load("TestFiles\\Caption.rtf", TXTextControl.StreamType.RichTextFormat);
            textControl1.Append("TestFiles\\net.htm", TXTextControl.StreamType.HTMLFormat, TXTextControl.AppendSettings.None);

        }

        private void mnuPage_Click(object sender, System.EventArgs e) {
            frmGotoPage GotoPage = new frmGotoPage();
            GotoPage.ShowDialog();

            if (GotoPage.PageNo > 0 && GotoPage.PageNo <= textControl1.Pages) {
                TXTextControl.InputPosition InputPosition =
                    new TXTextControl.InputPosition(GotoPage.PageNo, 1, 0);
                textControl1.InputPosition = InputPosition;
            }
            else {
                MessageBox.Show("Page number outside valid range.");
            }
        }
    }
}
