/*------------------------------------------------------------------------------------------------
** program:			TX Text Control Text Fields Sample
** description:	Text Fields are markers which are inserted in the text. They can be used to 
**                  implement a wide range of special functions in a text processor.						
**
** copyright:		© Text Control GmbH
**----------------------------------------------------------------------------------------------*/
using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace Fields1 {

    public class Form1 : System.Windows.Forms.Form {

        private TXTextControl.TextControl textControl1;
        private TXTextControl.TextControl textControl2;
        private System.Windows.Forms.MainMenu mainMenu1;
        private System.Windows.Forms.MenuItem mnuInsertField;
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
            this.textControl1 = new TXTextControl.TextControl();
            this.textControl2 = new TXTextControl.TextControl();
            this.mainMenu1 = new System.Windows.Forms.MainMenu(this.components);
            this.mnuInsertField = new System.Windows.Forms.MenuItem();
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
            this.textControl1.Size = new System.Drawing.Size(939, 441);
            this.textControl1.TabIndex = 0;
            this.textControl1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.textControl1_MouseUp);
            this.textControl1.TextFieldClicked += new TXTextControl.TextFieldEventHandler(this.textControl1_TextFieldClicked);
            this.textControl1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.textControl1_MouseMove);
            // 
            // textControl2
            // 
            this.textControl2.BorderStyle = TXTextControl.BorderStyle.FixedSingle;
            this.textControl2.Font = new System.Drawing.Font("Arial", 10F);
            this.textControl2.Location = new System.Drawing.Point(40, 208);
            this.textControl2.Name = "textControl2";
            this.textControl2.Size = new System.Drawing.Size(208, 40);
            this.textControl2.TabIndex = 1;
            this.textControl2.Text = "textControl2";
            this.textControl2.ViewMode = TXTextControl.ViewMode.SimpleControl;
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.mnuInsertField});
            // 
            // mnuInsertField
            // 
            this.mnuInsertField.Index = 0;
            this.mnuInsertField.Text = "Insert Field!";
            this.mnuInsertField.Click += new System.EventHandler(this.mnuInsertField_Click);
            // 
            // Form1
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(939, 441);
            this.Controls.Add(this.textControl2);
            this.Controls.Add(this.textControl1);
            this.Menu = this.mainMenu1;
            this.Name = "Form1";
            this.Text = "Fields1 Sample Program";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }
        #endregion

        [STAThread]
        static void Main() {
            Application.Run(new Form1());
        }

        // Field ID - used to give each field a unique ID
        int FieldID;

        private void Form1_Load(object sender, System.EventArgs e) {
            FieldID = 0;
            textControl1.Height = ClientSize.Height;
            textControl1.BringToFront();
        }

        private void mnuInsertField_Click(object sender, System.EventArgs e) {
            TXTextControl.TextField NewField = new TXTextControl.TextField();

            // Insert a new field and increase field ID
            NewField.Text = "--------";
            NewField.ID = FieldID;
            NewField.DoubledInputPosition = true;
            NewField.HighlightMode = TXTextControl.HighlightMode.Activated;
            FieldID += 1;
            textControl1.TextFields.Add(NewField);
        }

        private void textControl1_TextFieldClicked(object sender, TXTextControl.TextFieldEventArgs e) {
            // Field has been clicked on, update text of second TX and display it
            textControl2.Text = "Field clicked, ID: " + e.TextField.ID;
            textControl2.BringToFront();
        }

        private void textControl1_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e) {
            // Hide second TX
            textControl1.BringToFront();
        }

        private void textControl1_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e) {
            // Move the hidden TX to the cursor position
            // Add a little offset so the cursor won't be over the hidden TX
            textControl2.Left = e.X + 10;
            textControl2.Top = e.Y;
        }

    }
}
