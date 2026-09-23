/*------------------------------------------------------------------------------------------------
** program:			TX Text Control Mail Merge Sample
** description:	This chapter shows how to use the DocumentServer.MailMerge class in 
**                  Windows Forms projects to merge TXTextControl.ApplicationFields in 
**                  template documents with data from various data sources			
**
** copyright:		© Text Control GmbH
**----------------------------------------------------------------------------------------------*/
using System;
using System.Data;
using System.Windows.Forms;
using TXTextControl.DocumentServer.Fields;
using TXTextControl;

namespace MailMerge_Simple {

    public partial class Form1 : Form {

        public Form1() {
            InitializeComponent();
        }

        private DataSet dsAddresses;

        private void InsertMergeField(string Name) {
            // create a new TXTextControl.DocumentServer.Fields.MergeField
            // and add it to TextControl
            MergeField mergeField = new MergeField();
            mergeField.Name = Name;
            mergeField.Text = "{ " + Name + " }";
            mergeField.ApplicationField.HighlightMode = HighlightMode.Activated;
            mergeField.ApplicationField.DoubledInputPosition = true;

            textControl1.ApplicationFields.Add(mergeField.ApplicationField);
        }

        private void Form1_Load(object sender, EventArgs e) {
            // create a new DataSet and load the XML file
            dsAddresses = new DataSet();
            dsAddresses.ReadXml(Application.StartupPath + "\\data.xml");

            // create a new ToolStripMenuItem for each database field
            foreach (DataColumn col in dsAddresses.Tables[0].Columns) {
                ToolStripMenuItem mnuItem = new ToolStripMenuItem(col.ColumnName);
                mnuItem.Click += new EventHandler(mnuItem_Click);
                addToolStripMenuItem.DropDown.Items.Add(mnuItem);
            }

            textControl1.Selection.Load(Application.StartupPath + "\\instructions.tx", StreamType.InternalUnicodeFormat);
        }

        void mnuItem_Click(object sender, EventArgs e) {
            ToolStripMenuItem item = (ToolStripMenuItem)sender;
            InsertMergeField(item.Text);
        }

        private void mergeToolStripMenuItem_Click(object sender, EventArgs e) {
            mailMerge1.Merge(dsAddresses.Tables[0], true);
        }

        private void propertiesToolStripMenuItem_Click(object sender, EventArgs e) {
            MergeField mergeField = new MergeField(textControl1.ApplicationFields.GetItem());
            mergeField.ShowDialog();
        }

        private void applicationFieldsToolStripMenuItem_DropDownOpening(object sender, EventArgs e) {
            propertiesToolStripMenuItem.Enabled = textControl1.ApplicationFields.GetItem() == null ? false : true;
            addToolStripMenuItem.Enabled = textControl1.ApplicationFields.CanAdd == true ? true : false;
        }

        private void mailMergeToolStripMenuItem_DropDownOpening(object sender, EventArgs e) {
            mergeToolStripMenuItem.Enabled = textControl1.ApplicationFields.Count > 0 ? true : false;
        }

    }
}

