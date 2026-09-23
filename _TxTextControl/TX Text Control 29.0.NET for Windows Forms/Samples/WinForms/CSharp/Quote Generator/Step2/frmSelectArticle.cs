/*------------------------------------------------------------------------------------------------
** program:			TX Text Control Quote Generator Sample
** description:	This sample program shows how to use Text Control in office applications.  						
**
** copyright:		© Text Control GmbH
**----------------------------------------------------------------------------------------------*/
using System.Data;

namespace QuoteGenerator {

    public class frmSelectArticle : System.Windows.Forms.Form {

        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.ListBox lstArticle;
        internal System.Windows.Forms.Button cmdCancel;
        internal System.Windows.Forms.Button cmdOK;
        private System.ComponentModel.Container components = null;

        public frmSelectArticle() {
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
            this.lstArticle = new System.Windows.Forms.ListBox();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.cmdOK = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Label1
            // 
            this.Label1.Location = new System.Drawing.Point(8, 8);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(104, 16);
            this.Label1.TabIndex = 5;
            this.Label1.Text = "Product Code";
            // 
            // lstArticle
            // 
            this.lstArticle.Location = new System.Drawing.Point(8, 32);
            this.lstArticle.Name = "lstArticle";
            this.lstArticle.Size = new System.Drawing.Size(184, 173);
            this.lstArticle.TabIndex = 4;
            // 
            // cmdCancel
            // 
            this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdCancel.Location = new System.Drawing.Point(208, 48);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(80, 24);
            this.cmdCancel.TabIndex = 7;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // cmdOK
            // 
            this.cmdOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.cmdOK.Location = new System.Drawing.Point(208, 16);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(80, 24);
            this.cmdOK.TabIndex = 6;
            this.cmdOK.Text = "OK";
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // frmSelectArticle
            // 
            this.AcceptButton = this.cmdOK;
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.CancelButton = this.cmdCancel;
            this.ClientSize = new System.Drawing.Size(304, 214);
            this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.cmdCancel,
																		  this.cmdOK,
																		  this.Label1,
																		  this.lstArticle});
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "frmSelectArticle";
            this.Text = "Select Article";
            this.Load += new System.EventHandler(this.frmSelectArticle_Load);
            this.ResumeLayout(false);

        }
        #endregion

        public DataSet ArticleData;
        public int SelectedProductRowIndex = -1;

        private void frmSelectArticle_Load(object sender, System.EventArgs e) {
            FillProductCodeListbox();
            lstArticle.SelectedIndex = 0;
        }

        private void FillProductCodeListbox() {
            foreach (DataRow row in ArticleData.Tables[0].Rows) {
                lstArticle.Items.Add(row[0]);
            }
        }

        private void cmdOK_Click(object sender, System.EventArgs e) {
            SelectedProductRowIndex = lstArticle.SelectedIndex;
            Close();
        }

        private void cmdCancel_Click(object sender, System.EventArgs e) {
            Close();
        }
    }
}
