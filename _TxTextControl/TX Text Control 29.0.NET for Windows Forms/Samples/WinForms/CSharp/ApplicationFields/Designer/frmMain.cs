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
using System.Drawing;
using System.Windows.Forms;
using TXTextControl.DocumentServer.Fields;

namespace MailMerge_Designer {

    public partial class frmMain : Form {

        public frmMain() {

            InitializeComponent();
            textControl1.RulerBar = rulerBar2;
            textControl1.ButtonBar = buttonBar1;
            textControl1.StatusBar = statusBar1;
            textControl1.VerticalRulerBar = rulerBar1;
        }

        // private variables

        private DataSet ds;
        private FieldDisplayMode curDisplayMode = FieldDisplayMode.ShowFieldText;
        private string sLoadedFile;
        private TXTextControl.StreamType stLoadedStreamType;
        private bool bDirtyFlag = false;

        private enum FieldDisplayMode {
            ShowFieldCodes,
            ShowFieldText,
            PreviewField
        }

        private void iFFieldToolStripMenuItem_Click(object sender, EventArgs e) {
            InsertIFField();
        }

        private void includeTextToolStripMenuItem_Click(object sender, EventArgs e) {
            InsertIncludeTextField();
        }

        private void dateToolStripMenuItem_Click(object sender, EventArgs e) {
            InsertDateField();
        }

        private void tsbSelectRecipients_Click(object sender, EventArgs e) {
            SelectRecipients();
        }

        void mergeFieldMenuItem_Click(object sender, EventArgs e) {
            ToolStripMenuItem mergeFieldMenuItem = (ToolStripMenuItem)sender;
            MergeField newMergeField = new MergeField();
            newMergeField.ApplicationField.HighlightMode = TXTextControl.HighlightMode.Activated;
            newMergeField.ApplicationField.DoubledInputPosition = true;
            newMergeField.ApplicationField.Editable = false;

            newMergeField.Name = mergeFieldMenuItem.Text;
            newMergeField.Text = "«" + mergeFieldMenuItem.Text + "»";

            textControl1.ApplicationFields.Add(newMergeField.ApplicationField);

            UpdateFieldValues();
        }

        private void tscbDataTables_SelectedIndexChanged(object sender, EventArgs e) {
            SetDataBinding(tscbDataTables.SelectedItem.ToString());
        }

        private void tsbFieldDelete_Click(object sender, EventArgs e) {
            DeleteField();
        }

        private void tsbFieldSettings_Click(object sender, EventArgs e) {
            FieldSettings();
        }


        private void textControl1_MouseUp(object sender, MouseEventArgs e) {
            int iDpi = (int)(1440 / textControl1.CreateGraphics().DpiX);

            Point pCurLocTX = new Point(e.X * iDpi + textControl1.ScrollLocation.X, e.Y * iDpi + textControl1.ScrollLocation.Y);
            Point pCurLocForm = new Point(e.X + textControl1.ScrollLocation.X / iDpi, e.Y + textControl1.ScrollLocation.Y / iDpi);


            if (e.Button == MouseButtons.Right) {
                textControl1.InputPosition = new TXTextControl.InputPosition(pCurLocTX);

                if (textControl1.ApplicationFields.GetItem() == null)
                    return;

                cmField.Show(textControl1, e.Location);
            }
        }

        private void textControl1_TextFieldEntered(object sender, TXTextControl.TextFieldEventArgs e) {
            tsbFieldDelete.Enabled = true;
            tsbFieldSettings.Enabled = true;
        }

        private void textControl1_TextFieldLeft(object sender, TXTextControl.TextFieldEventArgs e) {
            tsbFieldDelete.Enabled = false;
            tsbFieldSettings.Enabled = false;
        }


        private void bindingSource1_CurrentChanged(object sender, EventArgs e) {
            UpdateFieldValues();
        }

        private void tsbShowFieldCodes_Click(object sender, EventArgs e) {
            ShowFieldCodes();
        }

        private void tsbShowFieldText_Click(object sender, EventArgs e) {
            ShowFieldText();
        }

        private void tsbPreview_Click(object sender, EventArgs e) {
            ShowPreview();
        }

        private void tsbPreview_CheckStateChanged(object sender, EventArgs e) {
            bindingNavigator1.Enabled = tsbPreview.Checked;
        }


        private void SelectRecipients() {
            ds = new DataSet();

            openFileDialog1.Filter = "XML Database File | *.xml";

            if (openFileDialog1.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                return;

            // clear the DataTable combobox
            tscbDataTables.Items.Clear();

            // load the XML database
            ds.ReadXml(openFileDialog1.FileName);
            tslDatabaseName.Text = openFileDialog1.SafeFileName + ":";

            // add the DataTables to the combobox
            foreach (DataTable dt in ds.Tables)
                tscbDataTables.Items.Add(dt.TableName);

            tscbDataTables.SelectedIndex = 0;

            // database binding
            bindingSource1.DataSource = ds;
            SetDataBinding(tscbDataTables.SelectedItem.ToString());

            // enable export
            exportToolStripMenuItem.Enabled = true;
        }

        private void DeleteField() {
            textControl1.ApplicationFields.Remove(textControl1.ApplicationFields.GetItem());
        }

        private void FieldSettings() {
            if (textControl1.ApplicationFields.GetItem() == null)
                return;

            curDisplayMode = FieldDisplayMode.ShowFieldText;
            UpdateFieldValues();

            switch (textControl1.ApplicationFields.GetItem().TypeName) {
                case "MERGEFIELD":
                    MergeField mergeField = new MergeField(textControl1.ApplicationFields.GetItem());
                    mergeField.ShowDialog();
                    break;
                case "DATE":
                    DateField dateField = new DateField(textControl1.ApplicationFields.GetItem());
                    dateField.ShowDialog();
                    break;
                case "INCLUDETEXT":
                    IncludeText includeTextField = new IncludeText(textControl1.ApplicationFields.GetItem());
                    includeTextField.ShowDialog();
                    break;
                case "IF":
                    IfField ifField = new IfField(textControl1.ApplicationFields.GetItem());
                    ifField.ShowDialog();
                    break;
            }
        }

        private void SetDataBinding(string DataMember) {
            tsbInsertField.DropDownItems.Clear();
            insertMergeFieldToolStripMenuItem.DropDownItems.Clear();

            bindingSource1.DataMember = DataMember;

            foreach (DataColumn dc in ds.Tables[DataMember].Columns) {
                ToolStripMenuItem mergeFieldMenuItem = new ToolStripMenuItem(dc.ColumnName);
                mergeFieldMenuItem.Click += new EventHandler(mergeFieldMenuItem_Click);

                tsbInsertField.DropDownItems.Add(mergeFieldMenuItem);

                ToolStripMenuItem mergeFieldMenuItem2 = new ToolStripMenuItem(dc.ColumnName);
                mergeFieldMenuItem2.Click += new EventHandler(mergeFieldMenuItem_Click);
                insertMergeFieldToolStripMenuItem.DropDownItems.Add(mergeFieldMenuItem2);
            }

            tsbExport.Enabled = true;
            insertMergeFieldToolStripMenuItem.Enabled = true;
            tsbInsertField.Enabled = true;
            tsbSpecialFields.Enabled = true;
            insertSpecialFieldsToolStripMenuItem.Enabled = true;
        }

        private void UpdateFieldValues() {
            switch (curDisplayMode) {
                case FieldDisplayMode.PreviewField:

                    // get the new selected data row 
                    DataRowView curRow = (DataRowView)bindingSource1.Current;

                    foreach (TXTextControl.ApplicationField appField in textControl1.ApplicationFields) {
                        if (appField.TypeName == "MERGEFIELD") {
                            MergeField field = new MergeField(appField);

                            if (ds.Tables[ds.Tables[bindingSource1.DataMember].TableName].Columns.Contains(field.Name))
                                field.Text = curRow[field.Name].ToString();
                            else
                                field.Text = field.Name;
                        }
                    }

                    break;

                case FieldDisplayMode.ShowFieldCodes:

                    foreach (TXTextControl.ApplicationField appField in textControl1.ApplicationFields) {
                        string fieldSwitches = String.Empty;

                        foreach (string fieldSwitch in appField.Parameters)
                            fieldSwitches += " " + fieldSwitch;

                        appField.Text = "{ " + appField.TypeName + " " + fieldSwitches + " }";
                    }

                    break;

                case FieldDisplayMode.ShowFieldText:

                    foreach (TXTextControl.ApplicationField appField in textControl1.ApplicationFields) {
                        switch (appField.TypeName) {
                            case "MERGEFIELD":
                                MergeField mergeField = new MergeField(appField);
                                mergeField.Text = "«" + mergeField.Name + "»";
                                break;

                            case "IF":
                                IfField ifField = new IfField(appField);
                                ifField.Text = "{" + ifField.TypeName + "}";
                                break;

                            case "DATE":
                                DateField dateField = new DateField(appField);
                                dateField.Text = "{" + dateField.TypeName + "}";
                                break;

                            case "INCLUDETEXT":
                                IncludeText includeText = new IncludeText(appField);
                                includeText.ApplicationField.Text = "{" + includeText.TypeName + "}";
                                break;
                        }
                    }

                    break;
            }
        }

        private void ShowFieldCodes() {
            curDisplayMode = FieldDisplayMode.ShowFieldCodes;

            tsbPreview.Checked = false;
            tsbShowFieldCodes.Checked = true;
            tsbShowFieldText.Checked = false;

            showAllFieldResultsToolStripMenuItem.Checked = false;
            showAllToolStripMenuItem.Checked = true;
            showPreviewToolStripMenuItem.Checked = false;

            UpdateFieldValues();
        }

        private void ShowFieldText() {
            curDisplayMode = FieldDisplayMode.ShowFieldText;

            tsbPreview.Checked = false;
            tsbShowFieldCodes.Checked = false;
            tsbShowFieldText.Checked = true;

            showAllFieldResultsToolStripMenuItem.Checked = true;
            showAllToolStripMenuItem.Checked = false;
            showPreviewToolStripMenuItem.Checked = false;

            UpdateFieldValues();
        }

        private void Export() {
            frmPreview preview = new frmPreview();

            preview.DataTable = ds.Tables[ds.Tables[bindingSource1.DataMember].TableName];

            byte[] data = null;
            textControl1.Save(out data, TXTextControl.BinaryStreamType.InternalUnicodeFormat);
            preview.Document = data;

            preview.ShowDialog();
        }

        private void ShowPreview() {
            tsbPreview.Checked = true;
            tsbShowFieldCodes.Checked = false;
            tsbShowFieldText.Checked = false;

            showAllFieldResultsToolStripMenuItem.Checked = false;
            showAllToolStripMenuItem.Checked = false;
            showPreviewToolStripMenuItem.Checked = true;

            bindingNavigator1.Enabled = tsbPreview.Checked;

            if (tsbPreview.Checked)
                curDisplayMode = FieldDisplayMode.PreviewField;

            UpdateFieldValues();
        }

        private void InsertIFField() {
            IfField newIfField = new IfField();
            newIfField.ApplicationField.DoubledInputPosition = true;
            newIfField.ApplicationField.Deleteable = false;
            newIfField.ApplicationField.Editable = false;
            newIfField.ApplicationField.HighlightMode = TXTextControl.HighlightMode.Activated;

            textControl1.ApplicationFields.Add(newIfField.ApplicationField);
            newIfField.ShowDialog();
        }

        private void InsertDateField() {
            DateField newDateField = new DateField();
            newDateField.ApplicationField.DoubledInputPosition = true;
            newDateField.ApplicationField.Deleteable = false;
            newDateField.ApplicationField.Editable = false;
            newDateField.ApplicationField.HighlightMode = TXTextControl.HighlightMode.Activated;

            textControl1.ApplicationFields.Add(newDateField.ApplicationField);
            newDateField.ShowDialog();
        }

        private void InsertIncludeTextField() {
            IncludeText newIncludeTextField = new IncludeText();
            newIncludeTextField.ApplicationField.DoubledInputPosition = true;
            newIncludeTextField.ApplicationField.Deleteable = false;
            newIncludeTextField.ApplicationField.Editable = false;
            newIncludeTextField.ApplicationField.HighlightMode = TXTextControl.HighlightMode.Activated;

            textControl1.ApplicationFields.Add(newIncludeTextField.ApplicationField);
            newIncludeTextField.ShowDialog();
        }


        private void loadToolStripMenuItem_Click(object sender, EventArgs e) {
            TXTextControl.LoadSettings ls = new TXTextControl.LoadSettings();
            ls.ApplicationFieldFormat = TXTextControl.ApplicationFieldFormat.MSWord;

            textControl1.Load(TXTextControl.StreamType.WordprocessingML | TXTextControl.StreamType.RichTextFormat | TXTextControl.StreamType.MSWord, ls);
            sLoadedFile = ls.LoadedFile;
            stLoadedStreamType = ls.LoadedStreamType;

            this.Text = "TX Text Control Mail Merge Designer: " + sLoadedFile;
            bDirtyFlag = false;
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e) {
            Save();
        }

        private void Save() {
            if (sLoadedFile == null)
                saveAsToolStripMenuItem.PerformClick();
            else {
                textControl1.Save(sLoadedFile, stLoadedStreamType);
                bDirtyFlag = false;
            }
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e) {
            if (bDirtyFlag == true) {
                System.Windows.Forms.DialogResult rslt = MessageBox.Show("Do you want to save the changes?", "TX Text Control Mail Merge Designer", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                if (rslt == System.Windows.Forms.DialogResult.Yes)
                    Save();
                else if (rslt == System.Windows.Forms.DialogResult.Cancel)
                    return;
            }

            this.Text = "TX Text Control Mail Merge Designer: [New Template]";
            sLoadedFile = null;
            textControl1.ResetContents();
            bDirtyFlag = false;
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e) {
            SaveAs();
        }

        private void SaveAs() {
            TXTextControl.SaveSettings ss = new TXTextControl.SaveSettings();
            textControl1.Save(TXTextControl.StreamType.WordprocessingML | TXTextControl.StreamType.RichTextFormat | TXTextControl.StreamType.MSWord, ss);

            sLoadedFile = ss.SavedFile;
            stLoadedStreamType = ss.SavedStreamType;

            bDirtyFlag = false;
        }

        private void textControl1_Changed(object sender, EventArgs e) {
            bDirtyFlag = true;
        }

        private void fileToolStripMenuItem_DropDownOpening(object sender, EventArgs e) {
            saveToolStripMenuItem.Enabled = bDirtyFlag;
        }

        private void tsbExport_Click(object sender, EventArgs e) {
            Export();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e) {
            if (bDirtyFlag == true) {
                System.Windows.Forms.DialogResult rslt = MessageBox.Show("Do you want to save the changes?", "TX Text Control Mail Merge Designer", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                if (rslt == System.Windows.Forms.DialogResult.Yes)
                    Save();
                else if (rslt == System.Windows.Forms.DialogResult.Cancel)
                    return;
            }

            this.Close();
        }

        private void selectRecipientToolStripMenuItem_Click(object sender, EventArgs e) {
            SelectRecipients();
        }

        private void nextRecordToolStripMenuItem_Click(object sender, EventArgs e) {
            bindingSource1.MoveNext();
        }

        private void previousRecordToolStripMenuItem_Click(object sender, EventArgs e) {
            bindingSource1.MovePrevious();
        }

        private void showAllToolStripMenuItem_Click(object sender, EventArgs e) {
            ShowFieldCodes();
        }

        private void showAllFieldResultsToolStripMenuItem_Click(object sender, EventArgs e) {
            ShowFieldText();
        }

        private void showPreviewToolStripMenuItem_Click(object sender, EventArgs e) {
            ShowPreview();
        }

        private void exportToolStripMenuItem_Click(object sender, EventArgs e) {

            Export();
        }

        private void mailMergeToolStripMenuItem_DropDownOpening(object sender, EventArgs e) {
            if (textControl1.ApplicationFields.GetItem() == null) {
                deleteFieldToolStripMenuItem.Enabled = false;
                fieldSettingsToolStripMenuItem.Enabled = false;
            }
            else {
                deleteFieldToolStripMenuItem.Enabled = true;
                fieldSettingsToolStripMenuItem.Enabled = true;
            }

            if (curDisplayMode == FieldDisplayMode.PreviewField) {
                nextRecordToolStripMenuItem.Enabled = true;
                previousRecordToolStripMenuItem.Enabled = true;
            }
            else {
                nextRecordToolStripMenuItem.Enabled = false;
                previousRecordToolStripMenuItem.Enabled = false;
            }
        }

        private void deleteFieldToolStripMenuItem_Click(object sender, EventArgs e) {
            DeleteField();
        }

        private void fieldSettingsToolStripMenuItem_Click(object sender, EventArgs e) {
            FieldSettings();
        }

        private void iFFieldToolStripMenuItem1_Click(object sender, EventArgs e) {
            InsertIFField();
        }

        private void includeTextToolStripMenuItem1_Click(object sender, EventArgs e) {
            InsertIncludeTextField();
        }

        private void dateToolStripMenuItem1_Click(object sender, EventArgs e) {
            InsertDateField();
        }

        private void toolStripMenuItem8_Click(object sender, EventArgs e) {
            DeleteField();
        }

        private void toolStripMenuItem9_Click(object sender, EventArgs e) {
            FieldSettings();
        }

    }
}
