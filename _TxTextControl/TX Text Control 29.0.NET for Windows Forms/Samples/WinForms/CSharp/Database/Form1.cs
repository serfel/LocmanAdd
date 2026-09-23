/*------------------------------------------------------------------------------------------------
** program:			TX Text Control Database Sample
** description:	    Shows you how to save the contents of a Text Control to a database.						
**
** copyright:		© Text Control GmbH
**----------------------------------------------------------------------------------------------*/
using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace Database {

    public class Form1 : System.Windows.Forms.Form {

        private System.Windows.Forms.Button cmdPrevious;
        private System.Windows.Forms.Button cmdNext;
        private TXTextControl.TextControl textControl1;
        private TXTextControl.TextControl textControl2;
        private System.ComponentModel.Container components = null;

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
            this.cmdPrevious = new System.Windows.Forms.Button();
            this.cmdNext = new System.Windows.Forms.Button();
            this.textControl1 = new TXTextControl.TextControl();
            this.textControl2 = new TXTextControl.TextControl();
            this.SuspendLayout();
            // 
            // cmdPrevious
            // 
            this.cmdPrevious.Location = new System.Drawing.Point(192, 240);
            this.cmdPrevious.Name = "cmdPrevious";
            this.cmdPrevious.Size = new System.Drawing.Size(88, 24);
            this.cmdPrevious.TabIndex = 2;
            this.cmdPrevious.Text = "<< Previous";
            this.cmdPrevious.Click += new System.EventHandler(this.cmdPrevious_Click);
            // 
            // cmdNext
            // 
            this.cmdNext.Location = new System.Drawing.Point(288, 240);
            this.cmdNext.Name = "cmdNext";
            this.cmdNext.Size = new System.Drawing.Size(88, 24);
            this.cmdNext.TabIndex = 3;
            this.cmdNext.Text = "Next >>";
            this.cmdNext.Click += new System.EventHandler(this.cmdNext_Click);
            // 
            // textControl1
            // 
            this.textControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.textControl1.Font = new System.Drawing.Font("Arial", 10F);
            this.textControl1.Location = new System.Drawing.Point(0, 0);
            this.textControl1.Name = "textControl1";
            this.textControl1.Size = new System.Drawing.Size(400, 112);
            this.textControl1.TabIndex = 4;
            this.textControl1.Text = "textControl1";
            this.textControl1.ViewMode = TXTextControl.ViewMode.Normal;
            // 
            // textControl2
            // 
            this.textControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.textControl2.Font = new System.Drawing.Font("Arial", 10F);
            this.textControl2.Location = new System.Drawing.Point(0, 112);
            this.textControl2.Name = "textControl2";
            this.textControl2.Size = new System.Drawing.Size(400, 120);
            this.textControl2.TabIndex = 5;
            this.textControl2.Text = "textControl2";
            this.textControl2.ViewMode = TXTextControl.ViewMode.Normal;
            // 
            // Form1
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(400, 278);
            this.Controls.Add(this.textControl2);
            this.Controls.Add(this.textControl1);
            this.Controls.Add(this.cmdNext);
            this.Controls.Add(this.cmdPrevious);
            this.Name = "Form1";
            this.Text = "Database Sample Program";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }
        #endregion

        [STAThread]
        static void Main() {
            Application.Run(new Form1());
        }


        private DataSet dsRTFData = new DataSet("rtf");
        private int iCurrentRow = 0;

        private void Form1_Load(object sender, System.EventArgs e) {
            dsRTFData.ReadXml("rtf sample database.xml");
            GetRecord();
        }

        private void cmdPrevious_Click(object sender, System.EventArgs e) {
            PutRecord();
            iCurrentRow -= 1;
            GetRecord();
        }

        private void cmdNext_Click(object sender, System.EventArgs e) {
            PutRecord();
            iCurrentRow += 1;
            GetRecord();
        }

        private void SetButtonState() {
            cmdPrevious.Enabled = (iCurrentRow > 0);
            cmdNext.Enabled = (iCurrentRow < dsRTFData.Tables[0].Rows.Count - 1);
        }

        private void GetRecord() {
            string sRTFData = dsRTFData.Tables[0].Rows[iCurrentRow].ItemArray[0].ToString();

            textControl1.Load(sRTFData, TXTextControl.StringStreamType.RichTextFormat);
            textControl2.Text = sRTFData;
            SetButtonState();
        }

        private void PutRecord() {
            string sRTFData;

            textControl1.Save(out sRTFData, TXTextControl.StringStreamType.RichTextFormat);
            dsRTFData.Tables[0].Rows[iCurrentRow][0] = sRTFData;
        }
    }
}
