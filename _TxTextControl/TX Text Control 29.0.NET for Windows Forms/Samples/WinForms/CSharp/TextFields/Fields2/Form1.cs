/*------------------------------------------------------------------------------------------------
** program:			TX Text Control Text Fields Sample
** description:	Text Fields are markers which are inserted in the text. They can be used to 
**                  implement a wide range of special functions in a text processor.						
**
** copyright:		© Text Control GmbH
**----------------------------------------------------------------------------------------------*/
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace Fields2 {

    public class Form1 : System.Windows.Forms.Form {

        private System.Windows.Forms.MainMenu mainMenu1;
        private System.Windows.Forms.MenuItem mnuBookmark;
        private System.Windows.Forms.MenuItem mnuBookmark_Insert;
        private System.Windows.Forms.MenuItem mnuBookmark_Goto;
        private TXTextControl.TextControl textControl1;
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
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            this.mainMenu1 = new System.Windows.Forms.MainMenu(this.components);
            this.mnuBookmark = new System.Windows.Forms.MenuItem();
            this.mnuBookmark_Insert = new System.Windows.Forms.MenuItem();
            this.mnuBookmark_Goto = new System.Windows.Forms.MenuItem();
            this.textControl1 = new TXTextControl.TextControl();
            this.SuspendLayout();
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.mnuBookmark});
            // 
            // mnuBookmark
            // 
            this.mnuBookmark.Index = 0;
            this.mnuBookmark.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.mnuBookmark_Insert,
            this.mnuBookmark_Goto});
            this.mnuBookmark.Text = "Bookmark";
            // 
            // mnuBookmark_Insert
            // 
            this.mnuBookmark_Insert.Index = 0;
            this.mnuBookmark_Insert.Text = "Insert...";
            this.mnuBookmark_Insert.Click += new System.EventHandler(this.mnuBookmark_Insert_Click);
            // 
            // mnuBookmark_Goto
            // 
            this.mnuBookmark_Goto.Index = 1;
            this.mnuBookmark_Goto.Text = "Goto...";
            this.mnuBookmark_Goto.Click += new System.EventHandler(this.mnuBookmark_Goto_Click);
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
            // Form1
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(939, 440);
            this.Controls.Add(this.textControl1);
            this.Menu = this.mainMenu1;
            this.Name = "Form1";
            this.Text = "Fields2 Sample Program";
            this.ResumeLayout(false);

        }
        #endregion

        [STAThread]
        static void Main() {
            Application.Run(new Form1());
        }

        int FieldID = 1;

        private void mnuBookmark_Insert_Click(object sender, System.EventArgs e) {
            // Do some error checking
            if (textControl1.Text == "") {
                MessageBox.Show("Cannot insert a bookmark if the Text Control is empty.");
            }
            else if (textControl1.Selection.Length == 0) {
                textControl1.Selection.Length = 1;
            }
            else {
                // Now turn the selected text into a new field
                TXTextControl.TextField NewField = new TXTextControl.TextField();
                NewField.ID = FieldID;
                NewField.Text = textControl1.Selection.Text;
                textControl1.Selection.Text = "";
                FieldID += 1;
                textControl1.TextFields.Add(NewField);
            }
        }

        private void mnuBookmark_Goto_Click(object sender, System.EventArgs e) {
            frmGoto BookmarkGotoDialog = new frmGoto();

            BookmarkGotoDialog.tx = textControl1;
            BookmarkGotoDialog.ShowDialog();
        }
    }
}
