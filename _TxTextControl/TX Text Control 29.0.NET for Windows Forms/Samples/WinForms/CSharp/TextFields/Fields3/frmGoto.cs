/*------------------------------------------------------------------------------------------------
** program:			TX Text Control Text Fields Sample
** description:	Text Fields are markers which are inserted in the text. They can be used to 
**                  implement a wide range of special functions in a text processor.						
**
** copyright:		© Text Control GmbH
**----------------------------------------------------------------------------------------------*/

namespace Fields3 {
    public class frmGotoDialog : System.Windows.Forms.Form {
        private System.ComponentModel.Container components = null;

        public frmGotoDialog() {
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
            this.ComboBox1 = new System.Windows.Forms.ComboBox();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.cmdOK = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ComboBox1
            // 
            this.ComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple;
            this.ComboBox1.Location = new System.Drawing.Point(8, 8);
            this.ComboBox1.Name = "ComboBox1";
            this.ComboBox1.Size = new System.Drawing.Size(128, 96);
            this.ComboBox1.TabIndex = 1;
            // 
            // cmdCancel
            // 
            this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdCancel.Location = new System.Drawing.Point(144, 40);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(80, 24);
            this.cmdCancel.TabIndex = 3;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // cmdOK
            // 
            this.cmdOK.Location = new System.Drawing.Point(144, 8);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(80, 24);
            this.cmdOK.TabIndex = 2;
            this.cmdOK.Text = "Ok";
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // frmGotoDialog
            // 
            this.AcceptButton = this.cmdOK;
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.CancelButton = this.cmdCancel;
            this.ClientSize = new System.Drawing.Size(232, 110);
            this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.ComboBox1,
																		  this.cmdCancel,
																		  this.cmdOK});
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmGotoDialog";
            this.Text = "Go To Bookmark";
            this.Load += new System.EventHandler(this.frmGotoDialog_Load);
            this.ResumeLayout(false);

        }
        #endregion

        internal System.Windows.Forms.ComboBox ComboBox1;
        internal System.Windows.Forms.Button cmdCancel;
        internal System.Windows.Forms.Button cmdOK;

        public TXTextControl.TextControl tx;

        private void frmGotoDialog_Load(object sender, System.EventArgs e) {
            foreach (TXTextControl.TextField Field in tx.TextFields) {
                ComboBox1.Items.Add(Field.Name);
            }
        }

        private void cmdOK_Click(object sender, System.EventArgs e) {
            foreach (TXTextControl.TextField Field in tx.TextFields) {
                if (Field.Name == ComboBox1.Text) {
                    tx.Selection.Start = Field.Start - 1;
                    tx.Selection.Length = Field.Length;
                    Field.ScrollTo();
                    return;
                }
            }
            Close();
        }

        private void cmdCancel_Click(object sender, System.EventArgs e) {
            Close();
        }
    }
}
