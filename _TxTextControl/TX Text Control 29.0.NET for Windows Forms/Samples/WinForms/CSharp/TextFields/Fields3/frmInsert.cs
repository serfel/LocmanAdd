/*------------------------------------------------------------------------------------------------
** program:			TX Text Control Text Fields Sample
** description:	Text Fields are markers which are inserted in the text. They can be used to 
**                  implement a wide range of special functions in a text processor.						
**
** copyright:		© Text Control GmbH
**----------------------------------------------------------------------------------------------*/
using System.Windows.Forms;

namespace Fields3 {

    public class frmInsertDialog : System.Windows.Forms.Form {

        private System.ComponentModel.Container components = null;

        public frmInsertDialog() {
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
            this.Label1 = new System.Windows.Forms.Label();
            this.TextBox1 = new System.Windows.Forms.TextBox();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.cmdOK = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Label1
            // 
            this.Label1.Location = new System.Drawing.Point(8, 8);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(240, 16);
            this.Label1.TabIndex = 1;
            this.Label1.Text = "Bookmark title:";
            // 
            // TextBox1
            // 
            this.TextBox1.Location = new System.Drawing.Point(8, 24);
            this.TextBox1.Name = "TextBox1";
            this.TextBox1.Size = new System.Drawing.Size(240, 20);
            this.TextBox1.TabIndex = 2;
            this.TextBox1.Text = "";
            // 
            // cmdCancel
            // 
            this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdCancel.Location = new System.Drawing.Point(176, 56);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(72, 24);
            this.cmdCancel.TabIndex = 4;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // cmdOK
            // 
            this.cmdOK.Location = new System.Drawing.Point(96, 56);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(72, 24);
            this.cmdOK.TabIndex = 3;
            this.cmdOK.Text = "OK";
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // frmInsertDialog
            // 
            this.AcceptButton = this.cmdOK;
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.CancelButton = this.cmdCancel;
            this.ClientSize = new System.Drawing.Size(256, 86);
            this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.Label1,
																		  this.TextBox1,
																		  this.cmdCancel,
																		  this.cmdOK});
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "frmInsertDialog";
            this.Text = "Insert Bookmark";
            this.ResumeLayout(false);

        }
        #endregion

        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.TextBox TextBox1;
        internal System.Windows.Forms.Button cmdCancel;
        internal System.Windows.Forms.Button cmdOK;

        public TXTextControl.TextControl tx;

        private void cmdOK_Click(object sender, System.EventArgs e) {
            TXTextControl.TextField Field = new TXTextControl.TextField();

            Field.Name = TextBox1.Text;
            Field.Text = tx.Selection.Text;
            tx.Selection.Text = "";
            if (!tx.TextFields.Add(Field)) {
                MessageBox.Show("Could not insert a bookmark. The cursor is probably inside a text field.");
            }
            Close();
        }

        private void cmdCancel_Click(object sender, System.EventArgs e) {
            Close();
        }
    }
}
