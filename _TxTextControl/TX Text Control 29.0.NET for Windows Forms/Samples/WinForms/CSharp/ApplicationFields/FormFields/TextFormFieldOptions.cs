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

namespace FormFields {
    // this class implements the dialog box for the MS Word FormTextBox fields
    public partial class TextFormFieldOptions : Form {

        private FormText _formTextBox;

        // constructor accepts a FormTextBox object
        public TextFormFieldOptions(FormText formTextBox) {
            InitializeComponent();
            _formTextBox = formTextBox;
            getValues();
        }

        // sets the control values of the dialog
        private void getValues() {
            tbName.Text = _formTextBox.Name;
            tbDefault.Text = _formTextBox.Default;

            switch (_formTextBox.Type) {
                case FormText.FormTextBoxType.RegularText:
                    cbType.SelectedIndex = 0;
                    break;
                case FormText.FormTextBoxType.Number:
                    cbType.SelectedIndex = 1;
                    break;
                case FormText.FormTextBoxType.Date:
                    cbType.SelectedIndex = 2;
                    break;
                case FormText.FormTextBoxType.CurrentDate:
                    cbType.SelectedIndex = 3;
                    break;
                case FormText.FormTextBoxType.CurrentTime:
                    cbType.SelectedIndex = 4;
                    break;
                case FormText.FormTextBoxType.Calculation:
                    cbType.SelectedIndex = 4;
                    break;
            }

            switch (_formTextBox.Format) {
                case FormText.FormTextBoxFormat.UPPERCASE:
                    cbFormat.SelectedIndex = 0;
                    break;
                case FormText.FormTextBoxFormat.lowercase:
                    cbFormat.SelectedIndex = 1;
                    break;
                case FormText.FormTextBoxFormat.Firstcapital:
                    cbFormat.SelectedIndex = 2;
                    break;
                case FormText.FormTextBoxFormat.TitleCase:
                    cbFormat.SelectedIndex = 3;
                    break;
                case FormText.FormTextBoxFormat.None:
                    cbFormat.SelectedIndex = 4;
                    break;
            }

            nudLength.Value = _formTextBox.MaxLength;
            cbCalculate.Checked = _formTextBox.CalcOnExit;
            cbFillIn.Checked = _formTextBox.Enabled;
        }

        // sets the field values
        private void setValues() {
            _formTextBox.Name = tbName.Text;
            _formTextBox.Default = tbDefault.Text;

            switch (cbType.SelectedIndex) {
                case 0:
                    _formTextBox.Type = FormText.FormTextBoxType.RegularText;
                    break;
                case 1:
                    _formTextBox.Type = FormText.FormTextBoxType.Number;
                    break;
                case 2:
                    _formTextBox.Type = FormText.FormTextBoxType.Date;
                    break;
                case 3:
                    _formTextBox.Type = FormText.FormTextBoxType.CurrentDate;
                    break;
                case 4:
                    _formTextBox.Type = FormText.FormTextBoxType.CurrentTime;
                    break;
                case 5:
                    _formTextBox.Type = FormText.FormTextBoxType.Calculation;
                    break;
            }

            switch (cbFormat.SelectedIndex) {
                case 0:
                    _formTextBox.Format = FormText.FormTextBoxFormat.UPPERCASE;
                    break;
                case 1:
                    _formTextBox.Format = FormText.FormTextBoxFormat.lowercase;
                    break;
                case 2:
                    _formTextBox.Format = FormText.FormTextBoxFormat.Firstcapital;
                    break;
                case 3:
                    _formTextBox.Format = FormText.FormTextBoxFormat.TitleCase;
                    break;
                case 4:
                    _formTextBox.Format = FormText.FormTextBoxFormat.None;
                    break;
            }

            _formTextBox.MaxLength = (int)nudLength.Value;
            _formTextBox.CalcOnExit = cbCalculate.Checked;
            _formTextBox.Enabled = cbFillIn.Checked;
        }

        private void btnOK_Click(object sender, EventArgs e) {
            setValues();
            this.Close();
        }
    }
}