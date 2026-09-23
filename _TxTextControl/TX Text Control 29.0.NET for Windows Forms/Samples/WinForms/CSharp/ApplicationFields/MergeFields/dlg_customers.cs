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

namespace MergeFieldSample {
    public partial class dlg_customers : Form {

        private TXTextControl.TextControl m_tx;
        private MergeFieldCollection m_mergeFieldCollection;
        private DataSet m_customers = new DataSet();

        // Open an XML database file to display in the data grid
        public dlg_customers(TXTextControl.TextControl TX, MergeFieldCollection MergeFieldCollection) {
            InitializeComponent();
            m_tx = TX;
            m_mergeFieldCollection = MergeFieldCollection;

            m_customers.ReadXml("address.xml");

            dataGridView1.DataSource = m_customers;
            dataGridView1.DataMember = "address_record";
        }

        // Loop through all fields of the MergeFieldCollection
        // and populate them with the database content
        private void btn_merge_Click(object sender, EventArgs e) {
            DataGridViewRow curRow = dataGridView1.SelectedRows[0];

            foreach (MergeField curMergeField in m_mergeFieldCollection) {
                foreach (DataGridViewTextBoxCell curCell in curRow.Cells) {
                    if (curCell.OwningColumn.Name == curMergeField.MergeFieldName)
                        curMergeField.Text = curCell.Value.ToString();
                }
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e) {
            if (dataGridView1.SelectedRows.Count != 0)
                btn_merge.Enabled = true;
            else
                btn_merge.Enabled = false;
        }
    }
}