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
using System.Windows.Forms;

namespace MergeFieldSample {
    public partial class MainForm : Form {

        // Global objects
        private MergeFieldCollection MergeFields = new MergeFieldCollection();
        private CollectionSync newSync;

        public MainForm() {
            InitializeComponent();

            // The synchronization object to synchronize the
            // MergeFieldCollection with the ApplicationField collection
            newSync = new CollectionSync(textControl1, MergeFields);
        }

        private void Form1_Load(object sender, EventArgs e) {
            textControl1.ButtonBar = buttonBar1;
        }


        private void saveToolStripMenuItem_DropDownOpening(object sender, EventArgs e) {
            if (textControl1.ApplicationFields.GetItem() == null)
                editToolStripMenuItem.Enabled = false;
            else
                editToolStripMenuItem.Enabled = true;
        }

        private void mergeToolStripMenuItem_DropDownOpening(object sender, EventArgs e) {
            if (MergeFields.Count == 0)
                mergeFieldsToolStripMenuItem.Enabled = false;
            else
                mergeFieldsToolStripMenuItem.Enabled = true;
        }

        // Open the data grid form
        private void mergeFieldsToolStripMenuItem_Click(object sender, EventArgs e) {
            dlg_customers frmCustomers = new dlg_customers(textControl1, MergeFields);
            frmCustomers.ShowDialog();
        }

        // Insert a new MergeField
        private void mergeFieldToolStripMenuItem_Click(object sender, EventArgs e) {
            MergeField newMergeField = new MergeField("MergeField", "MergeField", newSync);
            dlg_mergefield mergeFieldDialog = new dlg_mergefield(newMergeField, newSync);
            mergeFieldDialog.ShowDialog();
        }

        // Edit the MergeField at the current input position
        private void editToolStripMenuItem_Click(object sender, EventArgs e) {
            if (textControl1.ApplicationFields.GetItem() == null)
                return;

            TXTextControl.ApplicationField thisField = textControl1.ApplicationFields.GetItem();
            MergeField curMergeField = new MergeField(thisField);

            dlg_mergefield mergeFieldDialog = new dlg_mergefield(curMergeField, newSync);
            mergeFieldDialog.ShowDialog();
        }

        // Save the document
        private void saveToolStripMenuItem1_Click(object sender, EventArgs e) {
            textControl1.Save();
        }

        // Load a sample document
        private void loadToolStripMenuItem1_Click(object sender, EventArgs e) {
            // LoadSettings to set the format and the fields to be imported
            TXTextControl.LoadSettings ls = new TXTextControl.LoadSettings();
            ls.ApplicationFieldFormat = TXTextControl.ApplicationFieldFormat.MSWord;
            ls.ApplicationFieldTypeNames = new string[] { "MERGEFIELD" };

            // Load the document
            textControl1.Load("invoice.rtf", TXTextControl.StreamType.RichTextFormat, ls);

            newSync.SyncCollections();
        }

    }
}