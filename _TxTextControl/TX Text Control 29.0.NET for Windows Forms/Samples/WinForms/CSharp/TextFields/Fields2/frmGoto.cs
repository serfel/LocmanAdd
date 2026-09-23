/*------------------------------------------------------------------------------------------------
** program:			TX Text Control Text Fields Sample
** description:	Text Fields are markers which are inserted in the text. They can be used to 
**                  implement a wide range of special functions in a text processor.						
**
** copyright:		© Text Control GmbH
**----------------------------------------------------------------------------------------------*/
using System;
using System.Windows.Forms;

namespace Fields2 {

    public class frmGoto : System.Windows.Forms.Form {

        internal System.Windows.Forms.TextBox TextBox1;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.Button cmdCancel;
        internal System.Windows.Forms.Button cmdOK;
        private System.ComponentModel.Container components = null;

        public frmGoto() {
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
            this.TextBox1 = new System.Windows.Forms.TextBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.cmdOK = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // TextBox1
            // 
            this.TextBox1.Location = new System.Drawing.Point(128, 16);
            this.TextBox1.Name = "TextBox1";
            this.TextBox1.Size = new System.Drawing.Size(32, 20);
            this.TextBox1.TabIndex = 11;
            this.TextBox1.Text = "1";
            // 
            // Label1
            // 
            this.Label1.Location = new System.Drawing.Point(8, 16);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(112, 16);
            this.Label1.TabIndex = 10;
            this.Label1.Text = "Go to Bookmark no.";
            // 
            // cmdCancel
            // 
            this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdCancel.Location = new System.Drawing.Point(96, 48);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(80, 24);
            this.cmdCancel.TabIndex = 9;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // cmdOK
            // 
            this.cmdOK.Location = new System.Drawing.Point(8, 48);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(80, 24);
            this.cmdOK.TabIndex = 8;
            this.cmdOK.Text = "Ok";
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // frmGoto
            // 
            this.AcceptButton = this.cmdOK;
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.CancelButton = this.cmdCancel;
            this.ClientSize = new System.Drawing.Size(184, 86);
            this.Controls.Add(this.TextBox1);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdOK);
            this.Name = "frmGoto";
            this.Text = "Goto Bookmark";
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        public TXTextControl.TextControl tx;

        private void cmdCancel_Click(object sender, System.EventArgs e) {
            Close();
        }

        private void cmdOK_Click(object sender, System.EventArgs e) {
            if (Convert.ToInt32(TextBox1.Text) > tx.TextFields.Count) {
                MessageBox.Show("Invalid bookmark number!");
            }
            else {
                foreach (TXTextControl.TextField Field in tx.TextFields) {
                    if (Field.ID == Convert.ToInt32(TextBox1.Text)) {
                        tx.Selection.Start = Field.Start - 1;
                        tx.Selection.Length = Field.Length;
                    }
                }
            }
            Close();
        }
    }
}
