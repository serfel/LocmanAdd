/*------------------------------------------------------------------------------------------------
** program:			TX Text Control DataSourceManagerSample
** description:	Shows you how to use the DataSourceManager to create your own template designer 
**                  for templates that are compatible with MailMerge.
**
** copyright:		© Text Control GmbH
**----------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using TXTextControl.DocumentServer.DataSources;
using TXTextControl.DocumentServer.Fields;

namespace DataSourceManagerSample {

    public partial class Form1 : Form {

        public Form1() {
            InitializeComponent();
        }

        // private fields
        private DataSourceManager dsManager;
        private byte[] previewTemplate;

        private void btnDataSource_Click(object sender, EventArgs e) {
            // create new merge data
            Order order = new Order() {
                OrderID = 123,
                Customer = new Customer() {
                    Name = "Peter Welch"
                },
                OrderItems = new List<OrderItem>()
                {
                    new OrderItem() {
                        Product = new Product() {
                            Name = "Product A" },
                        Quantity = 2 }
                }
            };

            // create a new instance of the DataSourceManager
            dsManager = new DataSourceManager();

            // load the data source
            dsManager.LoadSingleObject(order);

            // attach events to monitor available
            // merge fields and merge blocks
            dsManager.PossibleMergeFieldColumnsChanged +=
                DsManager_PossibleMergeFieldColumnsChanged;
            dsManager.PossibleMergeBlockTablesChanged +=
                DsManager_PossibleMergeBlockTablesChanged;

            // attach the available tables to the combobox
            cbMasterTable.DataSource = new List<DataTableInfo>(dsManager.DataTables);
            cbMasterTable.DisplayMember = "TableName";

            //UpdateDataSourceDropDowns();
            cbPreview.Enabled = gbMergeElements.Enabled = true;
        }

        private void DsManager_PossibleMergeBlockTablesChanged(object sender, EventArgs e) {
            // attach the available merge blocks to the combobox
            cbMergeBlocks.Text = "";
            cbMergeBlocks.DataSource = new List<DataTableInfo>(dsManager.PossibleMergeBlockTables);
            cbMergeBlocks.DisplayMember = "TableName";
        }

        private void DsManager_PossibleMergeFieldColumnsChanged(object sender, EventArgs e) {
            // attach the available merge fields to the combobox
            cbMergeFields.Text = "";
            cbMergeFields.DataSource = new List<DataColumnInfo>(dsManager.PossibleMergeFieldColumns);
            cbMergeFields.DisplayMember = "ColumnName";
        }

        private void cbMasterTable_SelectedIndexChanged(object sender, EventArgs e) {
            // set a new master table to change the internal state
            dsManager.MasterDataTableInfo =
                cbMasterTable.SelectedItem as DataTableInfo;
        }

        private void btnInsertMergeBlock_Click(object sender, EventArgs e) {
            // insert a merge block based on the selected block name
            TXTextControl.DocumentServer.Windows.Forms.InsertMergeBlockDialog dlgMergeBlock =
                new TXTextControl.DocumentServer.Windows.Forms.InsertMergeBlockDialog(
                    dsManager, textControl1, cbMergeBlocks.SelectedItem as DataTableInfo);

            dlgMergeBlock.ShowDialog(this);
        }

        private void btnInsertMergeField_Click(object sender, EventArgs e) {
            // create and insert a new merge field
            MergeField mergeField = new MergeField();
            mergeField.Name = ((DataColumnInfo)cbMergeFields.SelectedItem).ColumnName;
            mergeField.Text = "«" + mergeField.Name + "»";
            mergeField.ApplicationField.DoubledInputPosition = true;
            mergeField.ApplicationField.HighlightMode = TXTextControl.HighlightMode.Activated;

            textControl1.ApplicationFields.Add(mergeField.ApplicationField);
        }

        private void cbPreview_CheckedChanged(object sender, EventArgs e) {
            // preview the mail merge document
            if (cbPreview.Checked) {
                // save the template 
                gbMergeElements.Enabled = false;
                textControl1.EditMode = TXTextControl.EditMode.ReadAndSelect;
                textControl1.Save(out previewTemplate,
                    TXTextControl.BinaryStreamType.InternalUnicodeFormat);

                // merge the template using the DataSourceManager
                IList<byte[]> documents =
                    dsManager.Merge(previewTemplate, textControl1);

                // load the merged document into TextControl
                textControl1.Load(documents[0],
                    TXTextControl.BinaryStreamType.InternalUnicodeFormat);
            }
            else {
                // load back the stored template
                gbMergeElements.Enabled = true;
                textControl1.EditMode = TXTextControl.EditMode.Edit;
                textControl1.Load(previewTemplate,
                    TXTextControl.BinaryStreamType.InternalUnicodeFormat);
            }
        }

        private void textControl1_SubTextPartEntered(object sender, TXTextControl.SubTextPartEventArgs e) {
            if (DataSourceManager.IsMergeBlock(e.SubTextPart)) {
                if (dsManager.DataTables.Contains(e.SubTextPart.Name.Remove(0, TXTextControl.DocumentServer.MailMerge.MergeBlockNamePrefix.Length)))
                    dsManager.MasterDataTableInfo = dsManager.DataTables[e.SubTextPart.Name.Remove(0, TXTextControl.DocumentServer.MailMerge.MergeBlockNamePrefix.Length)];
            }
        }

        private void textControl1_SubTextPartLeft(object sender, TXTextControl.SubTextPartEventArgs e) {
            dsManager.MasterDataTableInfo = cbMasterTable.SelectedItem as DataTableInfo;
        }
    }
}
