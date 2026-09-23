/*------------------------------------------------------------------------------------------------
** program:			TX Text Control Editing from code Sample
** description:	There are various applications which require text to be edited from program code. 
**                  Using TX Text Control, anything that can be done using the mouse and 
**                  clicking menu items, can also be done from program code.
**                  						
** copyright:		© Text Control GmbH
**----------------------------------------------------------------------------------------------*/
using System;

namespace Editing_from_code {

    public class frmGotoPage : System.Windows.Forms.Form {

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPageNo;
        private System.Windows.Forms.Button cmdOK;
        private System.Windows.Forms.Button cmdCancel;
        private System.ComponentModel.Container components = null;

        public frmGotoPage() {
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtPageNo = new System.Windows.Forms.TextBox();
            this.cmdOK = new System.Windows.Forms.Button();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(16, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Goto page no.";
            // 
            // txtPageNo
            // 
            this.txtPageNo.Location = new System.Drawing.Point(120, 16);
            this.txtPageNo.Name = "txtPageNo";
            this.txtPageNo.Size = new System.Drawing.Size(56, 20);
            this.txtPageNo.TabIndex = 1;
            this.txtPageNo.Text = "1";
            // 
            // cmdOK
            // 
            this.cmdOK.Location = new System.Drawing.Point(192, 8);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(80, 24);
            this.cmdOK.TabIndex = 2;
            this.cmdOK.Text = "OK";
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // cmdCancel
            // 
            this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdCancel.Location = new System.Drawing.Point(192, 40);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(80, 24);
            this.cmdCancel.TabIndex = 3;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // frmGotoPage
            // 
            this.AcceptButton = this.cmdOK;
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.CancelButton = this.cmdCancel;
            this.ClientSize = new System.Drawing.Size(282, 72);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdOK);
            this.Controls.Add(this.txtPageNo);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "frmGotoPage";
            this.Text = "Goto Page";
            this.ResumeLayout(false);

        }
        #endregion

        public int PageNo;

        private void cmdCancel_Click(object sender, System.EventArgs e) {
            PageNo = 0;
            Close();
        }

        private void cmdOK_Click(object sender, System.EventArgs e) {
            try {
                PageNo = Convert.ToInt32(txtPageNo.Text);
            } catch {
                PageNo = 0;
            }
            Close();
        }
    }
}
