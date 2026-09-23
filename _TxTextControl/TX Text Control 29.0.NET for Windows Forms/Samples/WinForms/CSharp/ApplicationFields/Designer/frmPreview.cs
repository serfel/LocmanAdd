/*------------------------------------------------------------------------------------------------
** program:			TX Text Control Mail Merge Sample
** description:	Shows how to use the DocumentServer.MailMerge class in Windows Forms projects 
**              to merge TXTextControl.ApplicationFields in template documents with data from 
**              various data sources. The MailMerge class encapsulates powerful mail merge 
**              capabilities in a ready-to-use component. The DocumentServer.MailMerge class 
**              is part of the TXTextControl.DocumentServer namespace.
**
** copyright:		© Text Control GmbH
**----------------------------------------------------------------------------------------------*/
using System;
using System.Data;
using System.Windows.Forms;

namespace MailMerge_Designer {

    public partial class frmPreview : Form {

        public DataTable DataTable;
        public byte[] Document;

        public frmPreview() {

            InitializeComponent();
        }

        private void frmPreview_Load(object sender, EventArgs e) {
            textControl1.CreateControl();

            // use the DocumentServer.MailMerge component to merge the document

            using (TXTextControl.ServerTextControl tx = new TXTextControl.ServerTextControl()) {
                tx.Create();

                using (TXTextControl.DocumentServer.MailMerge mailMerge = new TXTextControl.DocumentServer.MailMerge()) {
                    mailMerge.TextComponent = tx;
                    mailMerge.LoadTemplateFromMemory(Document, TXTextControl.DocumentServer.FileFormat.InternalUnicodeFormat);
                    mailMerge.Merge(DataTable, true);

                    byte[] data = null;
                    TXTextControl.SaveSettings ss = new TXTextControl.SaveSettings();
                    mailMerge.SaveDocumentToMemory(out data, TXTextControl.BinaryStreamType.InternalUnicodeFormat, ss);

                    textControl1.Load(data, TXTextControl.BinaryStreamType.InternalUnicodeFormat);
                }
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void toolStripButton2_Click(object sender, EventArgs e) {
            textControl1.Save();
        }

        private void toolStripButton3_Click(object sender, EventArgs e) {
            textControl1.Print("Mail Merge");
        }

        private void deleteFieldToolStripMenuItem_Click(object sender, EventArgs e) {

        }

    }
}
