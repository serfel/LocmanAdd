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
    public partial class dlg_mergefield : Form {

        private MergeField m_mergeField;
        private CollectionSync m_collectionSync;


        public dlg_mergefield(MergeField MergeField, CollectionSync collSync) {
            m_collectionSync = collSync;
            InitializeComponent();
            m_mergeField = MergeField;

            tb_fieldText.Text = m_mergeField.Text;
            tb_name.Text = m_mergeField.MergeFieldName;

            if (m_mergeField.TextBefore != "") {
                cb_textBefore.Checked = true;
                tb_textBefore.Text = m_mergeField.TextBefore;
            }
            if (m_mergeField.TextAfter != "") {
                cb_textAfter.Checked = true;
                tb_textAfter.Text = m_mergeField.TextAfter;
            }

            cb_mappedField.Checked = m_mergeField.Mapped;
            cb_preserveFormatting.Checked = m_mergeField.PreserveFormatting;

            switch (m_mergeField.TextFormat) {
                case MergeField.TextFormatOptions.None:
                    lb_textFormat.SelectedItem = "(none)";
                    break;
                case MergeField.TextFormatOptions.Uppercase:
                    lb_textFormat.SelectedItem = "UPPERCASE";
                    break;
                case MergeField.TextFormatOptions.Lowercase:
                    lb_textFormat.SelectedItem = "lowercase";
                    break;
                case MergeField.TextFormatOptions.TitleCase:
                    lb_textFormat.SelectedItem = "Title Case";
                    break;
                case MergeField.TextFormatOptions.FirstCapital:
                    lb_textFormat.SelectedItem = "First capital";
                    break;
            }
        }

        private void ApplySettings() {
            m_mergeField.PreserveFormatting = cb_preserveFormatting.Checked;
            m_mergeField.Mapped = cb_mappedField.Checked;

            if (cb_textBefore.Checked && tb_textBefore.Text != "")
                m_mergeField.TextBefore = tb_textBefore.Text;
            else
                m_mergeField.TextBefore = "";

            if (cb_textAfter.Checked && tb_textAfter.Text != "")
                m_mergeField.TextAfter = tb_textAfter.Text;
            else
                m_mergeField.TextAfter = "";

            m_mergeField.MergeFieldName = tb_name.Text;

            switch (lb_textFormat.SelectedItem.ToString()) {
                case "UPPERCASE":
                    m_mergeField.TextFormat = MergeField.TextFormatOptions.Uppercase;
                    break;
                case "lowercase":
                    m_mergeField.TextFormat = MergeField.TextFormatOptions.Lowercase;
                    break;
                case "First capital":
                    m_mergeField.TextFormat = MergeField.TextFormatOptions.FirstCapital;
                    break;
                case "Title Case":
                    m_mergeField.TextFormat = MergeField.TextFormatOptions.TitleCase;
                    break;
                case "(none)":
                    m_mergeField.TextFormat = MergeField.TextFormatOptions.None;
                    break;
            }

            m_mergeField.Text = tb_fieldText.Text;
            tb_fieldText.Text = m_mergeField.Text;

            m_collectionSync.SyncCollections();
        }

        private void btn_ok_Click(object sender, EventArgs e) {
            ApplySettings();
            this.Close();
        }

        private void btn_apply_Click(object sender, EventArgs e) {
            ApplySettings();
            btn_apply.Enabled = false;
        }

        private void cb_textBefore_CheckedChanged(object sender, EventArgs e) {
            tb_textBefore.Enabled = cb_textBefore.Checked;
            btn_apply.Enabled = true;
            if (cb_textBefore.Enabled)
                tb_textBefore.Focus();
        }

        private void cb_textAfter_CheckedChanged(object sender, EventArgs e) {
            tb_textAfter.Enabled = cb_textAfter.Checked;
            btn_apply.Enabled = true;
            if (cb_textAfter.Enabled)
                tb_textAfter.Focus();
        }

        private void tb_name_Click(object sender, EventArgs e) {
            tb_name.SelectAll();
        }

        private void tb_fieldText_Click(object sender, EventArgs e) {
            tb_fieldText.SelectAll();
        }

        private void tb_textBefore_Click(object sender, EventArgs e) {
            tb_textBefore.SelectAll();
        }

        private void tb_textAfter_Click(object sender, EventArgs e) {
            tb_textAfter.SelectAll();
        }

        private void tb_name_TextChanged(object sender, EventArgs e) {
            btn_apply.Enabled = true;
        }

        private void tb_fieldText_TextChanged(object sender, EventArgs e) {
            btn_apply.Enabled = true;
        }

        private void lb_textFormat_SelectedIndexChanged(object sender, EventArgs e) {
            btn_apply.Enabled = true;
        }

        private void cb_preserveFormatting_CheckedChanged(object sender, EventArgs e) {
            btn_apply.Enabled = true;
        }

        private void cb_mappedField_CheckedChanged(object sender, EventArgs e) {
            btn_apply.Enabled = true;
        }

        private void tb_textBefore_TextChanged(object sender, EventArgs e) {
            btn_apply.Enabled = true;
        }

        private void tb_textAfter_TextChanged(object sender, EventArgs e) {
            btn_apply.Enabled = true;
        }
    
    }
}